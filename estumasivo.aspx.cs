using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class estumasivo : System.Web.UI.Page
{
    Proyecto pro = new Proyecto();
    Funciones fun = new Funciones();
    Cliente cli = new Cliente();
    Usuario user = new Usuario();
    Localidad loc = new Localidad();
    Institucion ins = new Institucion();
    Estudiantes est = new Estudiantes();
    Docentes doc = new Docentes();
  
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
                FileUpload1.SaveAs(Server.MapPath("CSV_Estudiantes/" + fileNameSave));


                Label1.Text = "<br /><p style='color:#357ebd;font-weight:bold;'>" + FileUpload1.FileName + " cargado exitosamente</p>";

                lblOculto.Text = Server.MapPath("CSV_Estudiantes/" + fileNameSave);
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
            lblNroEnTabla.Text ="<b>Numero de estudiantes <b/>"+ GridView1.Rows.Count.ToString();
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

         DataRow datAnio = ins.buscarAnioON();

         foreach (GridViewRow gvr in GridView1.Rows)   //loop through GridView
         {
             string nit = HttpUtility.HtmlDecode(GridView1.Rows[gvr.RowIndex].Cells[0].Text);

             int validarGenero = 0;
             int validarTDoc = 0;
             int validarID = 0;
           

             DateTime localDateTime = DateTime.Now;
             DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
             string horares = utcDateTime.ToString("yyyy-MM-dd HH:mm:ss");

              if (nit != null && nit != "")
              {
                  string idDoc = HttpUtility.HtmlDecode(GridView1.Rows[gvr.RowIndex].Cells[2].Text);
                  string genero = HttpUtility.HtmlDecode(GridView1.Rows[gvr.RowIndex].Cells[5].Text);
                  string tdoc = HttpUtility.HtmlDecode(GridView1.Rows[gvr.RowIndex].Cells[1].Text);

                  if (idDoc.Length <= 4)
                  {
                      validarID++;
                  }

                  if (genero == "M" || genero == "F" || genero == "m" || genero == "f")
                  {

                  }
                  else
                  {
                      validarGenero++;
                  }

                  if (tdoc == "CC" || tdoc == "TI" || tdoc == "RC" || tdoc == "CE" || tdoc == "P")
                  {

                  }
                  else
                  {
                      validarTDoc++;
                  }
                  if (validarGenero == 0 || validarTDoc == 0 || validarID == 0)//Carga los docentes
                  {
                      string nomDoc = HttpUtility.HtmlDecode(GridView1.Rows[gvr.RowIndex].Cells[3].Text);
                      string ApeDoc = HttpUtility.HtmlDecode(GridView1.Rows[gvr.RowIndex].Cells[4].Text);

                      string fnac = HttpUtility.HtmlDecode(GridView1.Rows[gvr.RowIndex].Cells[6].Text);

                      string tel = HttpUtility.HtmlDecode(GridView1.Rows[gvr.RowIndex].Cells[7].Text);
                      string dir = HttpUtility.HtmlDecode(GridView1.Rows[gvr.RowIndex].Cells[8].Text);
                      string email = HttpUtility.HtmlDecode(GridView1.Rows[gvr.RowIndex].Cells[9].Text);

                      string grado = HttpUtility.HtmlDecode(GridView1.Rows[gvr.RowIndex].Cells[10].Text);
                      string etnia = HttpUtility.HtmlDecode(GridView1.Rows[gvr.RowIndex].Cells[11].Text);
                      //string iddocente = HttpUtility.HtmlDecode(GridView1.Rows[gvr.RowIndex].Cells[12].Text);
                      string tipogrupo = HttpUtility.HtmlDecode(GridView1.Rows[gvr.RowIndex].Cells[12].Text);
                      string codanio = HttpUtility.HtmlDecode(GridView1.Rows[gvr.RowIndex].Cells[13].Text);
                      string grupo = HttpUtility.HtmlDecode(GridView1.Rows[gvr.RowIndex].Cells[14].Text);

                      DataRow tipodoc = doc.buscarTipoDocumentoxAbr(tdoc);
                      DataRow gradoc = doc.buscarGradoxNombre(grado);
                      DataRow codetnia = ins.buscarEtniaxNombre(etnia);
                      //DataRow codtipogrupo = ins.buscartipoGrupo(tipogrupo);

                      DataRow datEstudiante = est.buscarEstudianteIngresado(idDoc);

                      if (tipodoc != null)
                      {

                          if (codetnia != null)
                          {
                              if (datEstudiante == null)
                              {
                                  DataRow datoSede = ins.buscarSedexNit(nit);
                                  DataRow codestudiante = est.agregarEstudiantePG(nomDoc, ApeDoc, idDoc, genero, fun.convertFechaAño(fnac), tel, dir, email, tipodoc["cod"].ToString(), codetnia["codigo"].ToString());
                                  if (codestudiante != null)
                                  {
                                      if (gradoc != null)
                                      {
                                          if (datoSede != null)
                                          {
                                              //DataRow datDocente = doc.buscarGradoDocente(datoSede["codigo"].ToString(), iddocente);

                                              //if (datDocente != null)
                                              //{
                                              //if (est.agregarEstuMatricula(datDocente["cod"].ToString(), codestudiante["codigo"].ToString(), datAnio["codigo"].ToString(), horares, gradoc["codigo"].ToString(),codtipogrupo["codigo"].ToString()))
                                              if (est.agregarEstuMatricula(datoSede["codigo"].ToString(), codestudiante["codigo"].ToString(), codanio, horares, gradoc["codigo"].ToString(), tipogrupo, grupo))
                                              {
                                                  buenos++;

                                                  DataRow validarEstudianteGI = est.buscarMatriculado(datoSede["codigo"].ToString(), codestudiante["codigo"].ToString(), codanio, gradoc["codigo"].ToString(), "1", grupo);

                                                  if (validarEstudianteGI == null)
                                                      est.agregarEstuMatricula(datoSede["codigo"].ToString(), codestudiante["codigo"].ToString(), codanio, horares, gradoc["codigo"].ToString(), "1", grupo);

                                                  //DataRow usuario = usu.agregarUsuarioPG(idDoc, idDoc, idDoc, nomDoc, "", ApeDoc, "", tel, "", email, "Off", nit);
                                                  //if (usuario != null)
                                                  //{
                                                  //    if (usu.relacionarUsuarioRol(usuario["cod"].ToString(), "4"))
                                                  //        buenos++;
                                                  //}
                                                  //else
                                                  //{
                                                  //    malos++;
                                                  //    ca += "Estudiante Usuario -> " + idDoc + "<br/>";
                                                  //}
                                              }
                                              else
                                              {
                                                  malos++;
                                                  ca += "Error al matricular estudiante: CodEstudiante: " + codestudiante["codigo"].ToString() + ", CodSede: " + datoSede["codigo"].ToString() + ", codAnio: " + codanio + ", codgrado: " + gradoc["codigo"].ToString() + ", grupo: " + tipogrupo;
                                              }

                                              //}
                                          }
                                          else
                                          {
                                              malos++;
                                              ca += "Nit -> " + nit + "<br/>";
                                          }
                                      }
                                      else
                                      {
                                          malos++;
                                          ca += "Grado -> " + grado + "<br/>";
                                      }

                                  }
                                  else
                                  {
                                      malos++;
                                      ca += "Estudiante -> " + idDoc + "<br/>";
                                  }
                              }
                              else
                              {
                                  //Aquí es para agregar al estudiante que exista pero pertenece ya sea a una red temática o grupo de investigación
                                  if (est.editarDatosEstudiante(idDoc, nomDoc, ApeDoc, genero, fun.convertFechaAño(fnac))) { }//Actualiza los datos dle estudiante
                                  DataRow datoestudiante = est.buscarEstudianteIngresado(idDoc);
                                  if (datoestudiante != null)
                                  {
                                      if (gradoc != null)
                                      {
                                          DataRow datoSede = ins.buscarSedexNit(nit);
                                          if (datoSede != null)
                                          {
                                              DataRow validarEstudiante = est.buscarMatriculado(datoSede["codigo"].ToString(), datoestudiante["codigo"].ToString(), codanio, gradoc["codigo"].ToString(), tipogrupo, grupo);//busca el estudiante en la tabla ins_estumatricula 
                                              if (validarEstudiante == null)
                                              {
                                                  if (est.agregarEstuMatricula(datoSede["codigo"].ToString(), datoestudiante["codigo"].ToString(), codanio, horares, gradoc["codigo"].ToString(), tipogrupo, grupo))
                                                  {
                                                      buenos++;
                                                      DataRow validarEstudianteGI = est.buscarMatriculado(datoSede["codigo"].ToString(), datoestudiante["codigo"].ToString(), codanio, gradoc["codigo"].ToString(), "1", grupo);

                                                      if (validarEstudianteGI == null)
                                                          est.agregarEstuMatricula(datoSede["codigo"].ToString(), datoestudiante["codigo"].ToString(), codanio, horares, gradoc["codigo"].ToString(), "1", grupo);
                                                  }
                                                  else
                                                  {
                                                      malos++;
                                                      ca += "Estudiante Usuario -> " + idDoc + "<br/>";
                                                  }
                                              }
                                              else
                                              {
                                                  if (est.editarEstuMatricula(datoSede["codigo"].ToString(), datoestudiante["codigo"].ToString(), codanio, gradoc["codigo"].ToString(), tipogrupo, grupo))
                                                  {
                                                      buenos++;
                                                  }
                                                  else
                                                  {
                                                      malos++;
                                                      ca += "Estudiante Usuario -> " + idDoc + "<br/>";
                                                  }
                                              }
                                          }
                                          else
                                          {
                                              malos++;
                                              ca += "Nit -> " + nit + "<br/>";
                                          }
                                      }
                                      else
                                      {
                                          malos++;
                                          ca += "Grado -> " + grado + "<br/>";
                                      }

                                  }
                              }
                          }
                          else
                          {
                              malos++;
                              ca += "Etnia -> " + etnia + ", ID -> " + idDoc + "<br/>";
                          }
                      }
                      else
                      {
                          malos++;
                          ca += "Tipo documento -> " + tdoc + ", ID -> " + idDoc + "<br/>";
                      }
                   }
                  else
                  {
                      if (validarGenero > 0)
                          mostrarmensaje("error", "Un registro de género es incorrecto.");
                      else if (validarTDoc > 0)
                      {
                          mostrarmensaje("error", "ERROR: Documentos sin tipo de indetificación.");
                      }
                      else if (validarID > 0)
                      {
                          mostrarmensaje("error", "ERROR: La longitud mínima de la identificación es 4 carácteres");
                      }
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
             lblMensajeMalos.Text = "Error al cargar archivo en su totalidad, No se agregaron las siguientes datos: <br />" + ca;
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