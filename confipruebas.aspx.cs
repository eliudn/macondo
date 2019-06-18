using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class confipruebas : System.Web.UI.Page
{
    Email ema = new Email();
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
           txtSm.Focus();
           buscarVariables();
        }
    }
    private void buscarVariables()
    {
        DataRow datoVariables = ema.buscarVariablesPrueba();
        if (datoVariables != null)
        {
            btnAgregar.Visible = false;
            txtSm.Text = datoVariables["sm"].ToString();
            txtCCQ.Text = datoVariables["ccq"].ToString();
            txtTtlNodo.Text = datoVariables["ttlnodo"].ToString();
            txtTtlWeb.Text = datoVariables["ttlweb"].ToString();
            txtAnchoBanda.Text = datoVariables["ancho"].ToString();
        }
        else
        {
            btnEditar.Visible = false;

        }
    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        if (ema.editarVariables(txtSm.Text, txtCCQ.Text, txtTtlNodo.Text, txtTtlWeb.Text, txtAnchoBanda.Text))
            mostrarmensaje("exito", "Editado Correctamente");
        else
            mostrarmensaje("error", "ERROR: No se logro agregar");
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        if (ema.agregarVariables(txtSm.Text, txtCCQ.Text, txtTtlNodo.Text, txtTtlWeb.Text, txtAnchoBanda.Text))
        {
            mostrarmensaje("exito", "Agregado Correctamente");
            btnAgregar.Visible = false;
            btnEditar.Visible = true;
        }
        else
            mostrarmensaje("error", "No se logró agregar");
    }
}