using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class repactividades : System.Web.UI.Page
{
    Actividad act = new Actividad();
    Funciones fun = new Funciones();
    Usuario user = new Usuario();
    Proyecto pro = new Proyecto();
    
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
            lblCodUsuarioRol.Text = Session["codusuariorol"].ToString();
            lblCodUsuario.Text = Session["codusuario"].ToString();
            lblTipoUsuario.Text = Session["codrol"].ToString();
            ddEstados(dropEstadoLista);
            ddProyectos(dropProyectoLista);

            gvCargarActividades();

            DataTable dtEstImplicados = new DataTable();
            dtEstImplicados = CreateDataTableEstImplicados();
            Session["myDatatableImplicados"] = dtEstImplicados;
        }
 
    }

    private DataTable CreateDataTableEstImplicados()
    { 
        DataTable myDataTable = new DataTable("Listado de actividades");
        myDataTable.Columns.AddRange(new DataColumn[5] { new DataColumn("Orden"), new DataColumn("Participantes"), new DataColumn("Seguimientos"), new DataColumn("Evidencias"), new DataColumn("Pruebas") });
        return myDataTable;
    }
    private void AddDataToTableImplicados(string orden, string Participantes, string Seguimientos, string Evidencias, string Pruebas, DataTable myTable)
    {
        if (myTable == null)
        {
            CreateDataTableEstImplicados();
        }
        myTable.Rows.Add(orden, Participantes, Seguimientos, Evidencias, Pruebas);
    }

    private void ddEstados(DropDownList drop)
    {
        DataTable datosProyectos = act.cargarEstados();
        drop.DataSource = datosProyectos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos"));
    }
    private void ddProyectos(DropDownList drop)
    {
        DataTable datosProyectos = pro.cargarProyectos();
        drop.DataSource = datosProyectos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos"));
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        gvCargarActividades();
    }
    private void gvCargarActividades()
    {
       DataTable datosActividades = act.cargarActividadesAgendadas(llenarWhereLista(lblTipoUsuario.Text, lblCodUsuarioRol.Text));
       if (datosActividades != null && datosActividades.Rows.Count > 0)
       {
           botones.Visible = true;
           lblActividades.Text = cargarActividades(datosActividades);
       }
       else
       {
           botones.Visible = false;
           lblActividades.Text = "No se encontraron actividades con estos parametros.";
       }
    }
    private string llenarWhereLista(string tipousuario, string codusuariorol)
    {
        int numero = 4;
        string[] cond;
        cond = new string[numero];

        cond[0] = string.Empty;  //codproyecto
        cond[1] = string.Empty;  //estado
        cond[2] = string.Empty;  //fechas
        cond[3] = string.Empty; // Filtros adicionales solo para visualizar las actividades de coordinador o un tecnico

        if (dropProyectoLista.SelectedIndex > 0)
        {
            cond[0] = "  a.`codproyecto`='" + dropProyectoLista.SelectedValue + "'";
        }

        if (dropEstadoLista.SelectedIndex > 0)
        {
            cond[1] = "a.`codestado`='" + dropEstadoLista.SelectedValue + "'";
        }

        if (txtFechaIniFiltro.Text != string.Empty && txtFechaFinFiltro.Text != string.Empty)
        {
            cond[2] = "DATE_FORMAT(a.`startday`,'%Y-%m-%d') BETWEEN DATE_FORMAT('" + fun.convertFechaAño(txtFechaIniFiltro.Text) + "','%Y-%m-%d') AND DATE_FORMAT('" + fun.convertFechaAño(txtFechaFinFiltro.Text) + "','%Y-%m-%d')";
        }
        else if (txtFechaIniFiltro.Text != string.Empty)
        {
            cond[2] = "DATE_FORMAT(a.`startday`,'%Y-%m-%d') >= DATE_FORMAT('" + fun.convertFechaAño(txtFechaIniFiltro.Text) + "','%Y-%m-%d')";

        }
        else if (txtFechaFinFiltro.Text != string.Empty)
        {
            cond[2] = "DATE_FORMAT(a.`startday`,'%Y-%m-%d') <= DATE_FORMAT('" + fun.convertFechaAño(txtFechaFinFiltro.Text) + "','%Y-%m-%d')";
        }

        if (tipousuario.Equals("2"))//Coordinador
        {
            cond[3] = "a.codusuariorol='" + codusuariorol + "'";
        }
        else if (tipousuario.Equals("5"))//Tecnico
        {
            cond[3] = "ap.`codusuariorol`='" + codusuariorol + "'";
        }

        string where = "";
        int primero = 0;
        for (int i = 0; i < numero; i++)
        {
            if (cond[i] != string.Empty)
            {
                if (primero == 0)
                {
                    where += "WHERE " + cond[i];
                }
                if (primero > 0)
                {
                    where += " AND " + cond[i];
                }
                if (primero == 0)
                {
                    primero = 1;
                }
            }
        }
        return where;
    }
    private string cargarActividades(DataTable datosActividades)
    {
            string ca = "";
            ca = "<table class='mGridTesoreria'>";
            ca += titulosTabla();
         
            for (int i = 0; i < datosActividades.Rows.Count; i++)
            {
                ca += armarCliente(datosActividades.Rows[i]);
            }
            ca += "</table>";
         return ca;
    }
    private string titulosTabla()
    {
        string ca = "";
        ca += " <tr>";
        ca += "<th>Orden De Trabajo</th>";
        ca += "<th>Fecha creación</th>";
        ca += "<th>Participantes</th>";
        ca += "<th>Seguimientos</th>";
        ca += "<th>Evidencias</th>";
        ca += "<th>Pruebas</th>";
        ca += "<th>Estado</th>";
        ca += "<th>Revisar</th>";
        ca += "</tr>";
        //AddDataToTableImplicados("Orden", "Participantes", "Seguimientos", "Evidencias", "Pruebas", (DataTable)Session["myDatatableImplicados"]);
        return ca;
    }
  
    private string armarCliente(DataRow datoCliente)
    {
        string ca = "";
        ca += "<tr>";

        ca += "<td style='text-align:center'>" + datoCliente["cod"].ToString() + "</td>";

        ca += "<td style='text-align:center'>" + datoCliente["createdday"].ToString() + "</td>";

        string participantes = armarParticipantes(datoCliente["cod"].ToString());
        if (participantes != "")
            ca += "<td  style='text-align:center'>" + participantes + "</td>";
        else
            ca += "<td style='background-color:#e96c6c;text-align:center'>0</td>";

        string seguimientos = armarSeguimientos(datoCliente["cod"].ToString());
        if (seguimientos != "")
           ca += "<td  style='text-align:center'>" + seguimientos + "</td>";
        else
           ca += "<td style='background-color:#e96c6c;text-align:center'>0</td>";
        
        string evidencias = armarEvidencias(datoCliente["cod"].ToString());
        if (evidencias != "")
           ca += "<td  style='text-align:center'>" + evidencias + "</td>";
        else
           ca += "<td style='background-color:#e96c6c;text-align:center'>0</td>";


        string pruebas = armarPruebas(datoCliente["cod"].ToString());
        if (pruebas != "")
            ca += "<td  style='text-align:center'>" + pruebas + "</td>";
        else
            ca += "<td style='background-color:#e96c6c;text-align:center'>0</td>";


        //ca += armarEstado(datoCliente["cod"].ToString()); 
        if (datoCliente["nombre"].ToString() == "Resuelto")
        {
            ca += "<td  style='background-color:#B4CC38;text-align:center'>" + datoCliente["nombre"].ToString() + "</td>";
        }
        else if (datoCliente["nombre"].ToString() == "Retrasado")
        {
            ca += "<td  style='background-color:#E8A7AB;text-align:center'>" + datoCliente["nombre"].ToString() + "</td>";
        }
        else
        {
            ca += "<td  style='text-align:center'>" + datoCliente["nombre"].ToString() + "</td>";
        }

        ca += "<td  style='text-align:center'><a href='actdetalle.aspx?ca=" + datoCliente["cod"].ToString() + "' target='_blank'><img src='Imagenes/details.png' /></a></td>";
        ca += "</tr>";
        //AddDataToTableImplicados(datoCliente["cod"].ToString(), participantes.ToString(), seguimientos.ToString(), evidencias.ToString(), pruebas.ToString(), (DataTable)Session["myDatatableImplicados"]);
        
        return ca;
    }
    private string armarSeguimientos(string codactividad)
    {
        string ca = "";
        DataTable datos = act.cargarSeguimientosActividades(codactividad);

         if(datos != null && datos.Rows.Count > 0)
         {
             ca += datos.Rows.Count + "<br/>";
            //  for(int i=0;i<datos.Rows.Count; i++)
            //{
            //    ca += datos.Rows[i]["usuario"].ToString() + " - " + datos.Rows[i]["rol"].ToString() + "<br/>";
            //}
         }
         return ca;
    }
    private string armarEvidencias(string codactividad)
    {
        string ca = "";
        DataTable datos = act.cargarEvidenciaActividades(codactividad);
        
        if (datos != null && datos.Rows.Count > 0)
        {
            ca += datos.Rows.Count + "<br/>";
            //for (int i = 0; i < datos.Rows.Count; i++)
            //{
            //    ca += datos.Rows[i]["usuario"].ToString() + " - " + datos.Rows[i]["rol"].ToString() + "<br/>";
            //}
        }
        return ca;
    }
    private string armarPruebas(string codactividad)
    {
        string ca = "";

        DataTable datos = act.cargarPruebasActividades(codactividad);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca += datos.Rows.Count + "<br/> ";
            //for (int i = 0; i < datos.Rows.Count; i++)
            //{
            //    ca += datos.Rows[i]["usuario"].ToString() + " - " + datos.Rows[i]["rol"].ToString() + "<br/>";
            //}
        }
        return ca;
    }
    private string armarParticipantes(string codactividad)
    {
        string ca = "";

        DataTable datos = act.cargarParticipantesActividadAgendada(codactividad);

        if(datos != null && datos.Rows.Count > 0)
        {
            ca += datos.Rows.Count + "<br/> ";
            //for(int i=0;i<datos.Rows.Count; i++)
            //{
            //    ca += datos.Rows[i]["tecnico"].ToString() + " - " + datos.Rows[i]["rol"].ToString() + "<br/>";
            //}
        }
        return ca;
    }
    private string armarEstado(string codactividad)
    {
        //return act.cargarSeguimientosActividades(codactividad).Rows.Count;

        string ca = "";
        //DataTable estado = act.cargarEstadoActividades(codactividad);
        //if (estado != null && estado.Rows.Count > 0)
        //{
        //    if (estado.Rows[0]["estado"].ToString() == "Resuelto")
        //    {
        //        ca += "<td  style='background-color:#B4CC38;text-align:center'>" + estado.Rows[0]["estado"].ToString() + "</td>";
        //    }
        //    else if (estado.Rows[0]["estado"].ToString() == "Retrasado")
        //    {
        //        ca += "<td  style='background-color:#E8A7AB;text-align:center'>" + estado.Rows[0]["estado"].ToString() + "</td>";
        //    }
        //    else
        //    {
        //        ca += "<td  style='text-align:center'>" + estado.Rows[0]["estado"].ToString() + "</td>";
        //    }
        //}
        //else
        //{
        //    ca += "<td style='background-color:#E8A7AB;text-align:center'>Retrasado</td>";
        //}
        return ca;
    }

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        XLWorkbook excel = new XLWorkbook();
        //DataTable datosCliente = (DataTable)Session["myDatatableImplicados"];
        //datosCliente.TableName = "Listado Actividades";
        IXLWorksheet hoja = excel.Worksheets.Add((DataTable)Session["myDatatableImplicados"]);

        Response.Clear();
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=\"ReporteActividades.xlsx\"");

        using (var memoryStream = new MemoryStream())
        {
            excel.SaveAs(memoryStream);
            memoryStream.WriteTo(Response.OutputStream);
        }
        Session["LibroExcel"] = null;
        Response.End();
      
    }
}