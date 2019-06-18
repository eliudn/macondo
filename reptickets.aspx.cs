using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class reptickets : System.Web.UI.Page
{
    Actividad act = new Actividad();
    Funciones fun = new Funciones();
    Usuario user = new Usuario();
    Proyecto pro = new Proyecto();
    Cliente cli = new Cliente();
    Tickets ticket = new Tickets();

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
            cargarDrops();
            gvCargarTickets();
        }
    }
    private void cargarDrops()
    {
        ddEstados(dropEstadoLista);
        ddProyectos(dropProyectoLista);
        ddSolicitudes(dropSolicitudLista);
        ddPrioridad(dropPrioridadLista);
    }
    private void ddPrioridad(DropDownList drop)
    {
        DataTable datosPrioridades = cli.cargarPrioridades();
        drop.DataSource = datosPrioridades;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos"));
    }
    private void ddEstados(DropDownList drop)
    {
        DataTable datosEstados = act.cargarEstados();
        drop.DataSource = datosEstados;
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
    private void ddSolicitudes(DropDownList drop)
    {
        DataTable datosSolicitudes = cli.cargarSolicitudes();
        drop.DataSource = datosSolicitudes;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos"));
    }
    protected void btnFiltrarLista_Click(object sender, EventArgs e)
    {
        gvCargarTickets();
    }

    private void gvCargarTickets()
    {
        DataTable datosTickets = ticket.cargarTickets(llenarWhereLista());
        if (datosTickets != null && datosTickets.Rows.Count > 0)
        {
            botones.Visible = true;
            lblTickets.Text = cargarTickets(datosTickets);
        }
        else
        {
            botones.Visible = false;
            lblTickets.Text = "No se encontraron tickets con estos parametros.";
        }
    }
    private string llenarWhereLista()
    {
        int numero = 5;
        string[] cond;
        cond = new string[numero];

        cond[0] = string.Empty;  //codproyecto
        cond[1] = string.Empty;  //estado
        cond[2] = string.Empty;  //fechas
        cond[3] = string.Empty; // Prioridad
        cond[4] = string.Empty; // Solicitud
        //cond[5] = string.Empty; // Numero

        if (dropProyectoLista.SelectedIndex > 0)
        {
            cond[0] = "  i.`codproyecto`='" + dropProyectoLista.SelectedValue + "'";
        }

        if (dropEstadoLista.SelectedIndex > 0)
        {
            cond[1] = "  i.`codestado`='" + dropEstadoLista.SelectedValue + "'";
        }

        if (txtFechaIniFiltro.Text != string.Empty && txtFechaFinFiltro.Text != string.Empty)
        {
            cond[2] = "DATE_FORMAT(i.`startday`,'%Y-%m-%d') BETWEEN DATE_FORMAT('" + fun.convertFechaAño(txtFechaIniFiltro.Text) + "','%Y-%m-%d') AND DATE_FORMAT('" + fun.convertFechaAño(txtFechaFinFiltro.Text) + "','%Y-%m-%d')";
        }
        else if (txtFechaIniFiltro.Text != string.Empty)
        {
            cond[2] = "DATE_FORMAT(i.`startday`,'%Y-%m-%d') >= DATE_FORMAT('" + fun.convertFechaAño(txtFechaIniFiltro.Text) + "','%Y-%m-%d')";

        }
        else if (txtFechaFinFiltro.Text != string.Empty)
        {
            cond[2] = "DATE_FORMAT(i.`startday`,'%Y-%m-%d') <= DATE_FORMAT('" + fun.convertFechaAño(txtFechaFinFiltro.Text) + "','%Y-%m-%d')";
        }

        if (dropPrioridadLista.SelectedIndex > 0)
        {
            cond[3] = "pri.`cod`='" + dropPrioridadLista.SelectedValue + "'";
        }

        if (dropSolicitudLista.SelectedIndex > 0)
        {
            cond[4] = " i.`codsolicitud`='" + dropSolicitudLista.SelectedValue + "'";
        }
        //cod
        //  if(txtFiltro.)
        //if (txtFilto.Value != string.Empty)
        //{
        //    cond[5] = " i.`cod`LIKE'" + txtFilto.Value + "%'";
        //}

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
    private string cargarTickets(DataTable datosTickets)
    {
        string ca = "";
        ca = "   <table class='mGridTesoreria'>";
        ca += titulosTabla();
        for (int i = 0; i < datosTickets.Rows.Count; i++)
        {
            ca += armarCliente(datosTickets.Rows[i]);
        }
        ca += "</table>";


        return ca;
    }
    private string titulosTabla()
    {
        string ca = "";
        ca += " <tr>";
        ca += "<th>Nro. Tickets</th>";
        ca += "<th>Fecha de creación</th>";
        ca += "<th>Escalas</th>";
        ca += "<th>Seguimientos</th>";
        ca += "<th>Evidencias</th>";
        ca += "<th>Time Off</th>";
        ca += "<th>Estado</th>";
        ca += "<th>Revisar</th>";
        ca += "</tr>";
        return ca;
    }
    private string armarCliente(DataRow datoCliente)
    {
        string ca = "";
        ca += "<tr>";
        ca += "<td style='text-align:center'>" + datoCliente["cod"].ToString() + "</td>";
        ca += "<td style='text-align:center'>" + datoCliente["createdday"].ToString() + "</td>";
        ca += armarParticipantes(datoCliente["cod"].ToString());
        ca += armarSeguimientos(datoCliente["cod"].ToString());
        ca += armarEvidencias(datoCliente["cod"].ToString());
        ca += armarPruebas(datoCliente["cod"].ToString());

         if (datoCliente["estado"].ToString() == "Resuelto")
        {
            ca += "<td  style='background-color:#B4CC38;text-align:center'>" + datoCliente["estado"].ToString() + "</td>";
        }
         else if (datoCliente["estado"].ToString() == "Retrasado")
         {
             ca += "<td  style='background-color:#E8A7AB;text-align:center'>" + datoCliente["estado"].ToString() + "</td>";
         }
         else
         {
             ca += "<td  style='text-align:center'>" + datoCliente["estado"].ToString() + "</td>";
         }

        ca += "<td  style='text-align:center'><a  href='ticdetalle.aspx?ct=" + datoCliente["cod"].ToString() + "' target='_blank'><img class='imgedicionnota' src='Imagenes/details.png' /></a></td>";
        ca += "</tr>";
        return ca;
    }
    private string armarParticipantes(string cod)
    {
        string ca = "";
        DataTable datosTecnicos = ticket.cargarParticipantesTickets(cod);
        if (datosTecnicos != null && datosTecnicos.Rows.Count > 0)
        {
            ca += "<td  style='text-align:center'>" + datosTecnicos.Rows.Count + "</td>";
        }
        else
        {
            ca += "<td style='background-color:#e96c6c;text-align:center'>0</td>";
        }
        return ca;
    }
    private string armarSeguimientos(string codTicket)
    {
        string ca = "";
        DataTable seguimiento = ticket.cargarSeguimientoTicket(codTicket);
        if (seguimiento != null && seguimiento.Rows.Count > 0)
        {
            ca += "<td  style='text-align:center'>" + seguimiento.Rows.Count + "</td>";
        }
        else
        {
            ca += "<td style='background-color:#e96c6c;text-align:center'>0</td>";
        }
        return ca;
    }
    private string armarEvidencias(string codTicket)
    {
        string ca = "";
        DataTable evidencia = ticket.cargarEvidenciaTicket(codTicket);
        if (evidencia != null && evidencia.Rows.Count > 0)
        {
            ca += "<td  style='text-align:center'>" + evidencia.Rows.Count + "</td>";
        }
        else
        {
            ca += "<td style='background-color:#e96c6c;text-align:center'>0</td>";
        }
        return ca;
    }
    private string armarPruebas(string codTicket)
    {
        string ca = "";
        DataTable timeoff = ticket.cargarTimeOffTicket(codTicket);
        if (timeoff != null && timeoff.Rows.Count > 0)
        {
            ca += "<td  style='text-align:center'>" + timeoff.Rows.Count + "</td>";
        }
        else
        {
            ca += "<td style='background-color:#e96c6c;text-align:center'>0</td>";
        }
        return ca;
    }
    private string armarEstado(string codTicket)
    {
        string ca = "";
        DataTable estado = ticket.cargarSeguimientoTicket(codTicket);
        if (estado != null && estado.Rows.Count > 0)
        {
            if (estado.Rows[0]["nombre"].ToString() == "Resuelto")
            {
                ca += "<td  style='background-color:#B4CC38;text-align:center'>" + estado.Rows[0]["nombre"].ToString() + "</td>";
            }
            else
            {
                ca += "<td  style='text-align:center'>" + estado.Rows[0]["nombre"].ToString() + "</td>";
            }
        }
        else
        {
            ca += "<td style='background-color:#E8A7AB;text-align:center'>Retrasado</td>";
        }
        return ca;
    }


    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment;filename=ReporteTickets.xls");
        Response.Charset = "UTF-8";
        Response.ContentEncoding = System.Text.Encoding.Default;
        Response.ContentType = "application/vnd.ms-excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        lblTickets.RenderControl(htmlWrite);


        Response.Output.Write("\n<body>\n<html>");
        //Response.Output.Write("<table align='center' style='text-align:center;'");
        //Response.Output.Write("<tr><td colspan='2' align='center'><div align='center' style='text-align:center'>" + imagepath + "</div></td></tr>");
        //Response.Output.Write("</table>");
        Response.Write(stringWrite.ToString());
        Response.Output.Write("\n</body>\n</html>");
        Response.End();
    }
}