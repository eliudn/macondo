using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class confiemailcc : System.Web.UI.Page
{
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
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 
        if (!IsPostBack)
        {
            txtEmail.Focus();
            cargarEmail();
        }
    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        Email ema = new Email();
        if (ema.agregarEmailCC(txtEmail.Text.ToLower().Trim(), txtNombre.Text))
        {
            mostrarmensaje("exito", "Agregado Correctamente");
            cargarEmail();
            txtEmail.Text = string.Empty;
            txtNombre.Text = string.Empty;
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se pudo agregar");
            btnAgregar.Visible = true;
            //btnEditar.Visible = false;
        }
    }

    private void cargarEmail()
    {
        Email ema = new Email();
        GridCorreo.DataSource = ema.cargarCorreosCC();
        GridCorreo.DataBind();
    }

    protected void ImgEliminar_Click(object sender, ImageClickEventArgs e)
    {
        Email ema = new Email ();
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string cod = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        if (ema.eliminarEmailCC(cod))
        {
            mostrarmensaje("exito", "Eliminado");
            cargarEmail();
        }
        else
        {
            mostrarmensaje("error", "ERROR: Este correo esta siendo usado");
        }
    }
    protected void GridCorreo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
      
    }
}