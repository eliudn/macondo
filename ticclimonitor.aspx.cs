using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ticclimonitor : System.Web.UI.Page
{
    Actividad act = new Actividad();
    Funciones fun = new Funciones();
    Usuario user = new Usuario();
    Proyecto pro = new Proyecto();
    Cliente cli = new Cliente();
    Tickets tic = new Tickets();

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
            PanelAgregarTickets.Attributes.Add("style", "display:none");
            lblCodUsuarioRol.Text = Session["codusuariorol"].ToString();
            lblCodUsuario.Text = Session["codusuario"].ToString();
            lblTipoUsuario.Text = Session["codrol"].ToString();
            GridTickets.PageSize = 30;
            cargarDrops();
            gvCargarTickets();
        }
    }

    private void cargarDrops()
    {
        ddSolicitudes(dropSolicitudAdd);
        ddProyectos(dropProyectosAdd);
    }

    private void ddProyectos(DropDownList drop)
    {
        DataTable datosProyectos = pro.cargarProyectosDeUsuario(lblCodUsuario.Text);
        drop.DataSource = datosProyectos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddSolicitudes(DropDownList drop)
    {
        DataTable datosSolicitudes = cli.cargarSolicitudes();
        drop.DataSource = datosSolicitudes;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }

    protected void GridTickets_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void GridTickets_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    private void gvCargarTickets()
    {
        GridTickets.DataSource = tic.cargarTicketsClientes(lblCodUsuario.Text);
        GridTickets.DataBind();
        if (GridTickets.Rows.Count > 0)
        {
            if (GridTickets.Rows.Count == 1)
            {
                lblNroRegistros.Text = "<b>Se encontró un registro.</b>";
            }
            else
            {
                lblNroRegistros.Text = "<b>Se encontraron " + GridTickets.Rows.Count + " registros.</b>";
            }
        }
        else
        {
            lblNroRegistros.Text = "<b>No se encontraron registros.</b>";
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
    protected void imgVer_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codactivity = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);// Codigo de la actividad
        Response.Redirect("ticclidetalle.aspx?ct=" + codactivity, true);
    }
    protected void btnFiltrarLista_Click(object sender, EventArgs e)
    {
        gvCargarTickets();
    }

    protected void dropSolicitudAdd_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropSolicitudAdd.SelectedIndex > 0)
        {
            //DataRow datoTipoSolicitud = cli.buscarTipoSolicitud(dropSolicitudAdd.SelectedValue);
            //if (datoTipoSolicitud != null)
            //{
            //    lblColorFiltro.Text = "<div style='display:inline;width:35px; height:16px; background-color:#ccc; color:#fff; padding:2px; margin-right:2px; text-align:center'><table><tr><th>Prioridad</th><th>ANS</th></tr><tr><td>" + datoTipoSolicitud["nombrep"].ToString() + "</td><td>Prioridad: " + datoTipoSolicitud["ans"].ToString() + "</td></tr></table></div>";
            //}
            //else
            //{
            //    lblColorFiltro.Text = "";
            //}
        }
    }
    protected void dropProyectosAdd_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropProyectosAdd.SelectedIndex > 0)
        {
            ddAClientesxProyecto(dropCliente, dropProyectosAdd.SelectedValue);
        }
    }
    private void ddAClientesxProyecto(DropDownList drop, string codproyecto)
    {
        drop.DataSource = pro.cargarClienteInProyecto(codproyecto);
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    protected void btnAddTickets_Click(object sender, EventArgs e)
    {
        if (dropCliente.SelectedIndex > 0)
        {
            long cod=tic.agregarTickets(lblCodUsuarioRol.Text, dropSolicitudAdd.SelectedValue, txtDescripcionAdd.Text, "1", dropProyectosAdd.SelectedValue, dropCliente.SelectedValue);
            if (cod!=-1)
            {
                txtDescripcionAdd.Text = string.Empty;
                dropSolicitudAdd.SelectedIndex = 0;
                dropProyectosAdd.SelectedIndex = 0;
                dropCliente.SelectedIndex = 0;
                gvCargarTickets();
                string mensaje = tic.armarCuerpoDelMensaje(lblCodUsuario.Text, cod.ToString(), 1);
                string email = tic.getEmailUsuario(lblCodUsuario.Text);
                string mensaje2 = tic.armarCuerpoDelMensaje(lblCodUsuario.Text, cod.ToString(), 2);
                //string email2 = tic.buscarReceptor();
                string receptor = "";
                Email ema = new Email();
                DataRow datorec = ema.buscarRemitente("2");//tipo Receptor
                if (datorec != null)
                {
                    receptor = datorec["email"].ToString();
                }
                tic.enviarMensajeporcorreo(mensaje, email, cod.ToString());
                tic.enviarMensajeporcorreo(mensaje2, receptor, cod.ToString());
                mostrarmensaje("exito", "Agregado Correctamente");
            }
        }
        else
        {
            mostrarmensaje("error", "ERROR: Debe elegir el cliente.");
            this.PanelAgregarEvento_Modalpopupextender2.Show();
        }
    }

    protected void GridTickets_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string hexret = "#e8a7ab";
        string hexres = "#b4cc38";
        Color _colorret = System.Drawing.ColorTranslator.FromHtml(hexret);
        Color _colorres = System.Drawing.ColorTranslator.FromHtml(hexres);
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string tipo;
            tipo = DataBinder.Eval(e.Row.DataItem, "estado").ToString();
            if (tipo == "Retrasado")
            {
                e.Row.Cells[8].BackColor = _colorret;
            }
            if (tipo == "Resuelto")
            {

                e.Row.Cells[8].BackColor = _colorres;
            }
        }
    }
}