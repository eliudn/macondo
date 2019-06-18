using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class confiemail : System.Web.UI.Page
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
            buscarEmail();
        }
    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    private void buscarEmail()
    {
        Email ema = new Email();
        GridCorreo.DataSource = ema.cargarCorreos();
        GridCorreo.DataBind();
        //DataRow dato = ema.buscarRemitente("1");

        //if (dato != null)
        //{
        //    lblEmailViejo.Text = dato["email"].ToString();
        //    txtEmail.Text = dato["email"].ToString();
        //    txtPass.Text = dato["pass"].ToString();
        //    txtAsunto.Text = dato["asunto"].ToString();
        //    txtNombre.Text = dato["nombre"].ToString();
        //    txtSMTP.Text = dato["servidorsmtp"].ToString();
        //    txtPuerto.Text = dato["port"].ToString();
        //    dropSsl.Text = dato["seguridadssl"].ToString();
        //    btnEditar.Visible = true;
        //    btnAgregar.Visible = false;
        //}
        //else
        //{
        //    lblEmailViejo.Text = "";
        //    txtEmail.Text = "";
        //    txtPass.Text = "";
        //    txtAsunto.Text = "";
        //    txtNombre.Text = "";
        //    txtSMTP.Text = "";
        //    txtPuerto.Text = "";
        //    btnEditar.Visible = false;
        //    btnAgregar.Visible = true;
        //}
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        //Email ema = new Email();
        //if (ema.editarRemitente(txtEmail.Text.ToLower().Trim(), txtPass.Text, txtNombre.Text, txtAsunto.Text, txtPuerto.Text, txtSMTP.Text, dropSsl.SelectedValue, lblEmailViejo.Text))
        //{
        //    mostrarmensaje("exito", "Editado Correctamente");
        //    buscarEmail();
        //    btnAgregar.Visible = false;
        //    btnEditar.Visible = true;
        //}
        //else
        //{
        //    mostrarmensaje("error", "Error al Actualizar");
        //    btnEditar.Visible = true;
        //}
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        Email ema = new Email();
        if (ema.agregarRemitente(txtEmail.Text.ToLower().Trim(), txtPass.Text, txtNombre.Text, txtAsunto.Text, txtPuerto.Text, txtSMTP.Text, dropSsl.SelectedValue,dropTipo.SelectedValue))
        {
            mostrarmensaje("exito", "Agregado Correctamente");
            buscarEmail();
            txtEmail.Text = string.Empty;
            txtAsunto.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtPass.Text = string.Empty;
            txtPuerto.Text = string.Empty;
            txtSMTP.Text = string.Empty;
            //btnAgregar.Visible = false;
            //btnEditar.Visible = true;
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se pudo agregar");
            btnAgregar.Visible = true;
            //btnEditar.Visible = false;
        }
    }
    protected void ImgEliminar_Click(object sender, ImageClickEventArgs e)
    {
        Email ema = new Email ();
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string cod = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        if (ema.eliminarRemitente(cod))
        {
            mostrarmensaje("exito", "Eliminado");
            buscarEmail();
        }
        else
        {
            mostrarmensaje("error", "ERROR: Este correo esta siendo usado");
        }
    }
    protected void GridCorreo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblTipoCorreo = (e.Row.FindControl("lblTipoCorreo") as Label);
            string tipo = DataBinder.Eval(e.Row.DataItem, "tipo").ToString();
            lblTipoCorreo.Text = tipo.Equals("1") ? "Emisor" : "Receptor";

        }
    }
}