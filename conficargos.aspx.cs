using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class conficargos : System.Web.UI.Page
{
    Usuario user = new Usuario();
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
            gvCargarCargos();
        }
    }
    private void gvCargarCargos()
    {
        Usuario usu = new Usuario();
        DataTable datos = usu.cargarCargos();
        GridPerfiles.DataSource = datos;
        GridPerfiles.DataBind();
    }
    protected void btnAgregarPerfil_Click(object sender, EventArgs e)
    {
        if(user.agregarCargo(txtNombrePerfil.Text.ToUpper()))
        {
            txtNombrePerfil.Text = string.Empty;
            gvCargarCargos();
            mostrarmensaje("exito", "Cargo Agregado Correctamente.");
        }
        else
        {
            mostrarmensaje("error", "ERROR: Ya existe un cargo igual.");
        }
    }
  
    protected void ImgEliminar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string cod = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        if (user.eliminarCargo(cod))
        {
            gvCargarCargos();
            mostrarmensaje("exito", "Cargo eliminado correctamente.");
        }
        else
        {
            mostrarmensaje("error", "ERROR: Este cargo se esta usando");
        }
    }
}