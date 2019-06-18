using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sedesmasivo : System.Web.UI.Page
{
    Proyecto pro = new Proyecto();
    Funciones fun = new Funciones();
    Cliente cli = new Cliente();
    Usuario user = new Usuario();
    Localidad loc = new Localidad();
    Institucion ins = new Institucion();
  
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["codperfil"] != null)
        {

        }
        else
            Response.Redirect("Default.aspx");
    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        mensaje.Attributes.Add("style", "display:none");
        if (!IsPostBack)
        {
            //ddProyectos(DropProyecto);
        }
    }
    private void ddProyectos(DropDownList drop)
    {
        drop.DataSource = pro.cargarProyectos();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }

    protected void DropProyecto_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (DropProyecto.SelectedIndex > 0)
        //{
        //    DataRow datoProyecto = pro.buscarProyecto(DropProyecto.SelectedValue);
        //    if (datoProyecto != null)
        //    {
        //        txtFechaIni.Text = fun.convertFechaDia(datoProyecto["fechaini"].ToString());
        //        txtFechaFin.Text = fun.convertFechaDia(datoProyecto["fechafin"].ToString());
        //    }
        //    else
        //        mostrarmensaje("error", "ERROR: No se encontro el proyecto.");

        //}
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            if (ChecarExtension(FileUpload1.FileName))
            {
                DateTime localDateTime = DateTime.Now;
                DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
                string horares = utcDateTime.ToString("yyyy-MM-dd_HHmmss");
                string fileExtension = System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
                string fileNameSave = horares + "_" + fileExtension;
                FileUpload1.SaveAs(Server.MapPath("CSV_Instituciones/" + fileNameSave));


                Label1.Text = "<br /><p style='color:#357ebd;font-weight:bold;'>" + FileUpload1.FileName + " cargado exitosamente</p>";

                lblOculto.Text = Server.MapPath("CSV_Instituciones/" + fileNameSave);
            }
            else
            {
                Label1.Text = "No se permite esta extensión.";
            }
        }
        else
        {
            Label1.Text = "Error al subir el archivo o no es el tipo .CSV";
        }
    }
    bool ChecarExtension(string fileName)
    {
        string ext = Path.GetExtension(fileName);
        switch (ext.ToLower())
        {
            case ".csv":
                return true;
            default:
                return false;
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
           CargarDatos(lblOculto.Text);
        }
        catch
        {
           mostrarmensaje("error","Ocurrio un error debe cargar antes el archivo");
        }
    }
    private void CargarDatos(string strm)
    {
        DataTable tabla = null;
        StreamReader lector = new StreamReader(strm, System.Text.Encoding.Default, false);
        String fila = String.Empty;
        Int32 cantidad = 0;
        do
        {
            fila = lector.ReadLine();
            if (fila == null)
            {
                break;
            }
            if (0 == cantidad++)
            {
                tabla = this.CrearTabla(fila, dropDelimitador.SelectedValue);
            }
            this.AgregarFila(fila, tabla, dropDelimitador.SelectedValue);
        } while (true);

        GridView1.DataSource = tabla;
        GridView1.DataBind();
        if (GridView1.Rows.Count > 0)
        {
            lblNroEnTabla.Text ="<b>Numero de Instituciones <b/>"+ GridView1.Rows.Count.ToString();
            lblNumero.Text = GridView1.Rows.Count.ToString();
        }
        
    }
    private DataTable CrearTabla(String fila, string delimitador)
    {
        int cantidadColumnas;
        DataTable tabla = new DataTable("Datos");
        String[] valores = fila.Split(new char[] { Convert.ToChar(delimitador) });
        cantidadColumnas = valores.Length;
        int idx = 0;
        foreach (String val in valores)
        {
            String nombreColumna = String.Format("{0}", idx++);
            tabla.Columns.Add(nombreColumna, Type.GetType("System.String"));
        }
        return tabla;
    }
    private DataRow AgregarFila(String fila, DataTable tabla, string delimitador)
    {
        int cantidadColumnas = 100;
        String[] valores = fila.Split(new char[] { Convert.ToChar(delimitador) });
        Int32 numeroTotalValores = valores.Length;
        if (numeroTotalValores > cantidadColumnas)
        {
            Int32 diferencia = numeroTotalValores - cantidadColumnas;
            for (Int32 i = 0; i < diferencia; i++)
            {

                String nombreColumna = String.Format("{0}", (cantidadColumnas + i));
                tabla.Columns.Add(nombreColumna, Type.GetType("System.String"));
            }
            cantidadColumnas = numeroTotalValores;
        }
        int idx = 0;
        DataRow dfila = tabla.NewRow();
        foreach (String val in valores)
        {
            String nombreColumna = String.Format("{0}", idx++);
            dfila[nombreColumna] = val.Trim();
        }
        tabla.Rows.Add(dfila);
        return dfila;
    }
    protected void btnActualizarPagos_Click(object sender, EventArgs e)
    {
        recorrerListado();
    }
    private bool validarFechas(string fechaini, string fechafin)
    {
        bool valido = false;
        DateTime fechai = Convert.ToDateTime(fechaini);
        DateTime fechaf = Convert.ToDateTime(fechafin);
        int res = DateTime.Compare(fechai, fechaf);
        if (res < 0)
        {
            valido = true;
        }
        return valido;
    }
    private void recorrerListado()
    {
        Usuario usu = new Usuario();
         int buenos = 0;
         int malos = 0;
         string ca = "";
         string[] reporteMalos = new string[Convert.ToInt32(lblNumero.Text)];

         foreach (GridViewRow gvr in GridView1.Rows)   //loop through GridView
         {
             string nit = HttpUtility.HtmlDecode(GridView1.Rows[gvr.RowIndex].Cells[0].Text);
             string[] variables = new string[22];
              if (nit != null && nit != "")
              {
                  for (int i = 0; i < 22; i++)
                  {
                      variables[i] = HttpUtility.HtmlDecode(GridView1.Rows[gvr.RowIndex].Cells[i].Text);
                  }
                  string nombreinstitucion =  variables[1];
                  string idrector = variables[2];
                  DataRow datotipoinst = ins.buscarTipoInstitucionxNombre(variables[3]);
                  string telefonoinstitucion = variables[4];
                  string faxinstitucion = variables[5];
                  string emailinstitucion = variables[6];
                  DataRow datoclaseinst = ins.buscarClaseInstitucionxNombre(variables[7]);


                  string direccioninstitucion = variables[8];
                  string webinstitucion = variables[9];
                  DataRow datomunicipioInst = loc.buscarMunicipioxNombre(variables[10]);
                  DataRow datozonaInts = ins.buscarZonaxNombre(variables[11]);
                  string nrosedesactivas = variables[12];
                  string nrosedesinactivas = variables[13];
                  DataRow datopropiedadjuridica = ins.buscarPropiedadJuridicaxNombre(variables[14]);

                  string nombresede = variables[15];
                  string dane = variables[16];
                  string consecutivosede = variables[17];
                  string direccionsede = variables[18];
                  DataRow datozona = ins.buscarZonaxNombre(variables[19]);
                  DataRow datomunicipio = loc.buscarMunicipioxNombre(variables[20]);
                  string principalsede = variables[21];

                   
                  
                   DataRow datoInstitucion = ins.buscarInstitucionxNit(nit);




                  if (datomunicipio != null && datomunicipioInst != null)
                  {
                      if (datozonaInts != null)
                      {
                          if (datopropiedadjuridica != null)
                          {
                              if (datoInstitucion != null)
                              {
                                  //Si existe, se adiciona la sede
                                  if (ins.agregarSedexInstitucion(nombresede, dane, consecutivosede, direccionsede, datozona["codigo"].ToString(), datomunicipio["cod"].ToString(), principalsede, datoInstitucion["codigo"].ToString()))
                                  {
                                      buenos++;
                                  }
                                  else
                                  {
                                      malos++;
                                      ca += "NIT Sede -> " + nit + "<br/>";
                                  }
                              }
                              else
                              {
                                  //No existe la institución
                                  //Se crea la institución y se le añade las sedes correspondiente a la tabla sede
                                  DataRow codinstitucion = ins.agregarInstitucionPG(nit, nombreinstitucion, idrector, datotipoinst["codigo"].ToString(), telefonoinstitucion, faxinstitucion, emailinstitucion, datoclaseinst["codigo"].ToString(), direccioninstitucion, webinstitucion, datozonaInts["codigo"].ToString(), datomunicipioInst["cod"].ToString(), nrosedesactivas, nrosedesinactivas, datopropiedadjuridica["codigo"].ToString());
                                  if (codinstitucion != null)
                                  {
                                      DataRow usuario = usu.agregarUsuarioPG(nit, nit, nit, nombreinstitucion, "", "INSTITUCIÓN", "", "", "", "","On",nit);
                                      if (usuario != null)
                                      {
                                          if (usu.relacionarUsuarioRol(usuario["cod"].ToString(), "7"))
                                              buenos++;
                                      }
                                      else
                                      {
                                          malos++;
                                          ca += "Institución Usuario -> " + nit + "<br/>";
                                      }
                                      
                                      if (ins.agregarSedexInstitucion(nombresede, dane, consecutivosede, direccionsede, datozona["codigo"].ToString(), datomunicipio["cod"].ToString(), principalsede, codinstitucion["codigo"].ToString()))
                                      {
                                          buenos++;
                                      }
                                      else
                                      {
                                          malos++;
                                          ca += "NIT Sede -> " + nit + "<br/>";
                                      }
                                  }
                                  else
                                  {
                                      malos++;
                                      ca += "NIT -> " + nit + "<br/>";
                                  }
                              }
                          }
                          else
                          {
                              malos++;
                              ca += "Nit -> " + nit + "Propiedad Jurídica no existe en la Base de Datos<br/>";
                          }
                          
                      }
                      else
                      {
                          malos++;
                          ca += "Nit -> " + nit + "Zona no existe en la Base de Datos<br/>";
                      }
                     
                  }
                  else
                  {
                      malos++;
                      ca += "NIT -> " + nit + ", Municipio para no existe en la Base de Datos.<br/>";
                  }
              }
              else
              {
                  malos++;
                  ca += "NIT -> " + nit + "<br/>";
              }
         }
        
         if (malos > 0)
         {
             lblMensajeMalos.Visible = true;
             lblMensajeMalos.Text = "Error al cargar archivo en su totalidad, No se agregaron las siguientes instituciones: <br />" + ca;
         }
         else
         {
             mostrarmensaje("exito", "Se crearon " + buenos + " y no se lograron crear " + malos);
         }

        //if (validarFechas(txtFechaIni.Text, txtFechaFin.Text))
        //{
        //    foreach (GridViewRow gvr in GridView1.Rows)   //loop through GridView
        //    {
        //        string nit = HttpUtility.HtmlDecode(GridView1.Rows[gvr.RowIndex].Cells[0].Text);
             
        //        string[] variables = new string[15];
        //        if (nit != null && nit != "")
        //        {
        //            for (int i = 0; i < 13; i++)
        //            {
        //                variables[i] = HttpUtility.HtmlDecode(GridView1.Rows[gvr.RowIndex].Cells[i].Text);
        //            }
        //            DataRow datoCliente = cli.buscarClientexNit(nit);
        //            if (datoCliente != null)
        //            {
        //                // Existe el cliente solo hay que:
        //                // Agregar la sede y relacionarla con un proyecto
        //                string codMunicipio = loc.buscarMunicipioxNombre(variables[12]) != null ? loc.buscarMunicipioxNombre(variables[12])["cod"].ToString() : "1";
        //                long idSede = cli.agregarSedeCliente(variables[7], datoCliente["cod"].ToString(), variables[9].ToUpper(), variables[10], variables[11], codMunicipio, variables[8]);
        //                if (idSede != -1)
        //                {
        //                    if (pro.agregarClientexProyecto(idSede.ToString(), DropProyecto.SelectedValue, fun.convertFechaAño(txtFechaIni.Text), fun.convertFechaAño(txtFechaFin.Text)))
        //                        buenos++;
        //                    else
        //                    {
        //                        malos++;
        //                      //  reporteMalos[malos] = nit;
        //                        ca += "NIT -> " + nit + "<br/>";
        //                    }

        //                }
        //                else
        //                {
        //                    malos++;
        //                    //reporteMalos[malos] = nit;
        //                    ca += "NIT -> " + nit + "<br/>";

        //                }
        //            }
        //            else
        //            {
        //                //No existe el cliente, Hay que:
        //                // Crear el usuario, Relacionarlo con el rol 5 (Cliente), Agregar el cliente, Luego agregar su sede y por ultimo relacionarlo con el proyecto.
        //                long idUsuario = user.agregarUsuario(nit, nit, nit, variables[1], variables[2], variables[3], variables[4], variables[7], variables[8], variables[6]);
        //                if (idUsuario != -1)
        //                {
        //                    if (user.relacionarUsuarioRol(idUsuario.ToString(), "4"))//Relacionamos el Consecutivo del usuario y el Rol del cliente = 4
        //                    {
        //                        string tipoCliente = cli.buscarTipoClientexNombre(variables[3]) != null ? cli.buscarTipoClientexNombre(variables[3])["cod"].ToString() : "1";
        //                        long idCliente = cli.agregarCliente(idUsuario.ToString(), nit, variables[1], variables[2], tipoCliente);
        //                        if (idCliente != -1)
        //                        {
        //                            string codMunicipio = loc.buscarMunicipioxNombre(variables[12]) != null ? loc.buscarMunicipioxNombre(variables[12])["cod"].ToString() : "1";
        //                            long idSede = cli.agregarSedeCliente(variables[7], idCliente.ToString(), variables[9].ToUpper(), variables[10], variables[11], codMunicipio, variables[8]);
        //                            if (idSede != -1)
        //                            {
        //                                if (pro.agregarClientexProyecto(idSede.ToString(), DropProyecto.SelectedValue, fun.convertFechaAño(txtFechaIni.Text), fun.convertFechaAño(txtFechaFin.Text)))
        //                                    buenos++;
        //                                else
        //                                {
        //                                    malos++;
        //                                  //  reporteMalos[malos] = nit;
        //                                    ca += "NIT -> " + nit + "<br/>";
        //                                }

        //                            }
        //                            else
        //                            {
        //                                malos++;
        //                              //  reporteMalos[malos] = nit;
        //                                ca += "NIT -> " + nit + "<br/>";
        //                            }
        //                        }
        //                        else
        //                        {
        //                            malos++;
        //                           // reporteMalos[malos] = nit;
        //                            ca += "NIT -> " + nit + "<br/>";
        //                        }
        //                    }
        //                    else
        //                    {
        //                        malos++;
        //                     //   reporteMalos[malos] = nit;
        //                        ca += "NIT -> " + nit + "<br/>";
        //                    }

        //                }
        //                else
        //                {
        //                    malos++;
        //                //    reporteMalos[malos] = nit;
        //                    ca += "NIT -> " + nit + "<br/>";
        //                }

        //            }

        //        }
        //        else 
        //        {
        //            malos++;
        //          //  reporteMalos[malos] = nit;
        //            ca += "NIT -> " + nit + "<br/>";
        //        }
                   
        //    }//Fin del for 
        //    mostrarmensaje("exito","Se crearon " + buenos + " y no se lograron crear " + malos);
        //    if (malos > 0)
        //    {
        //        lblMensajeMalos.Visible =true;
        //        lblMensajeMalos.Text = "Error al cargar archivo en su totalidad, No se agregaron los siguientes clientes: <br />" + ca;
        //        //lblMensajeMalos.Text = "No se agregaron los siguientes clientes<br />";
        //        //for (int i = 0; i < malos; i++)
        //        //{
        //        //    lblMensajeMalos.Text += "NIT -> " + reporteMalos[i+1] + "<br />";
        //        //}
        //    }
          
        //    //int time = 2;
        //    //Response.AppendHeader("Refresh", time + "; Url=" + Request.RawUrl + "");
        //}
        //else
        //{
        //    mostrarmensaje("error", "ERROR: Fechas invalidas.");
        //}
       
       
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    Label lblTipoID = (e.Row.FindControl("lblTipoID") as Label);
        //    DropDownList dropTipoID = (e.Row.FindControl("dropTipoID") as DropDownList);
        //    try
        //    {
        //        dropTipoID.SelectedValue = lblTipoID.Text;
        //    }
        //    catch (Exception) { }
        //    //string cod = DataBinder.Eval(e.Row.DataItem, "cod").ToString();
        //    //gvCargarSubProcesos(GridSubProcesos, cod, lblCodPeriodo.Text);

        //    //porcentajeT += Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "porcentaje"));
        //}
    }

}