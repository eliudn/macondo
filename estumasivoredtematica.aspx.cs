using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class estumasivoredtematica : System.Web.UI.Page
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
            lblNroEnTabla.Text ="<b>Numero de registros <b/>"+ GridView1.Rows.Count.ToString();
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
             string codredtematicasede = HttpUtility.HtmlDecode(GridView1.Rows[gvr.RowIndex].Cells[0].Text);

            
              if (codredtematicasede != null && codredtematicasede != "")
              {
                  string idEstudiante = HttpUtility.HtmlDecode(GridView1.Rows[gvr.RowIndex].Cells[1].Text);
                  string idDocente = HttpUtility.HtmlDecode(GridView1.Rows[gvr.RowIndex].Cells[2].Text);
                  string codanio = HttpUtility.HtmlDecode(GridView1.Rows[gvr.RowIndex].Cells[3].Text);
                 
                      DataRow datEstudiante = est.buscarMatriculadoxIDEstudiante(idEstudiante, codanio);

                      if(datEstudiante == null)
                      {
                         malos++;
                          ca +=" Estudiante no existe -> " + idEstudiante + "<br/>";
                      }
                      else
                      {
                          //Matricula de estudiante
                            DataRow buscarestudiante = est.buscarEstudianteRedTematica(datEstudiante["codigo"].ToString(), codredtematicasede);
                            if(buscarestudiante == null)
                            {
                                 DataRow redtematicamatricula = est.agregarEstudiantexRedTematica(codredtematicasede, datEstudiante["codigo"].ToString());
                                if (redtematicamatricula != null)
                                {
                                    buenos++;
                                }
                               
                            }
                            else
                            {
                                malos++;
                                ca += " Estudiante ya existe en la red temática -> " + idEstudiante + "<br/>";
                            }
                         

                          //Matricula de docente
                          //DataRow datdocente = doc.buscarDocenteMatriculado(idDocente, codanio);
                          //if(datdocente != null)
                          //{
                          //    DataRow buscardoc = doc.buscarDocenteRedTematica(datdocente["cod"].ToString(), codredtematicasede);

                          //    if(buscardoc == null)
                          //    {
                          //      if (est.agregarDocentexRedTematica(datdocente["cod"].ToString(), codredtematicasede))
                          //      {
                          //          buenos++;
                          //      }
                          //    }
                          //    else
                          //    {
                          //         malos++;
                          //          ca +=" Docente ya existe en la red temática -> " + idDocente + "<br/>";
                          //    }
                                
                          //}
                          //else
                          //{
                          //    malos++;
                          //    ca +=" Docente no existe -> " + idDocente + "<br/>";
                          //}

                          
                      }
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