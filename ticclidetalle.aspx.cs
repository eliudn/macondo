using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ticclidetalle : System.Web.UI.Page
{
    private Tickets ticket;
    private string codTicket;

    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["codperfil"] != null)
        {

        }
        else
            Response.Redirect("Default.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        mensaje.Attributes.Add("style", "display:none");
        if (Request.Params["ct"] != null)
        {
            codTicket = Request.Params["ct"].ToString();
            lblCodUsuarioRol.Text = Session["codusuariorol"].ToString();
            lblCodUsuario.Text = Session["codusuario"].ToString();
            lblTipoUsuario.Text = Session["codrol"].ToString();
        }
        else
        {
            Response.Redirect("ticmonitor.aspx");
        }
        if (!IsPostBack)
        {
            cargarGrillas();
        }
    }

    private void cargarGrillas()
    {
        cargarSeguimiento();
        cargarEvidencia();
        cargarTimeOff();
    }

    private void cargarSeguimiento()
    {
        ticket = new Tickets();
        DataTable seguimiento = ticket.cargarSeguimientoTicket(codTicket);
        if (seguimiento != null)
        {
            GridSeguimiento.DataSource = seguimiento;
            GridSeguimiento.DataBind();
        }
    }
    private void cargarEvidencia()
    {
        ticket = new Tickets();
        DataTable evidencia = ticket.cargarEvidenciaTicket(codTicket);
        if (evidencia != null)
        {
            GridEvidencia.DataSource = evidencia;
            GridEvidencia.DataBind();
        }
    }
    private void cargarTimeOff()
    {
        ticket = new Tickets();
        DataTable timeoff = ticket.cargarTimeOffTicket(codTicket);
        if (timeoff != null)
        {
            GridTimeOff.DataSource = timeoff;
            GridTimeOff.DataBind();
        }
    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void imgDescargar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string filepath = Server.MapPath(HttpUtility.HtmlDecode(gvrow.Cells[5].Text));
        string filename = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
        if (!File.Exists(filepath))
        {
            mostrarmensaje("error", "Lo sentimos el archivo: " + filename + " no existe");
        }
        else
        {
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.ContentType = "application/octet-stream";
            Response.Flush();
            Response.WriteFile(filepath);
            Response.End();
        }
    }
}