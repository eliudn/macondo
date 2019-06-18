using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class conficlientes : System.Web.UI.Page
{
    Localidad loc = new Localidad();
    Usuario user = new Usuario();
    Cliente cli = new Cliente();
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["codperfil"] != null)
        {

        }
        else
            Response.Redirect("Default.aspx", true);
    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 
        PanelAgregar_TipoCliente.Attributes.Add("style", "display:none");
        if (!IsPostBack)
        {
            ddMunicipios(dropMunicipio);
            ddTipoCLiente(dropTipoCliente);
        }
    }
    private void ddMunicipios(DropDownList drop)
    {
        drop.DataSource = loc.cargarMunicipios();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }

    private void ddTipoCLiente(DropDownList drop)
    {
        drop.DataSource = cli.cargarTiposCliente();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    protected void btnAgregarCliente_Click(object sender, EventArgs e)
    {
               long idUsuario = user.agregarUsuario(txtId.Text, txtId.Text, txtId.Text, txtNombre.Text,"", txtApellido.Text,"",txtTelefono.Text , txtCelularContacto.Text, txtEmail.Text);
                if (idUsuario != -1)
                {
                    if (user.relacionarUsuarioRol(idUsuario.ToString(), "4"))//Relacionamos el Consecutivo del usuario y el Rol del cliente = 4
                    {
                        long idCliente = cli.agregarCliente(idUsuario.ToString(),txtId.Text,txtNombre.Text,txtApellido.Text,dropTipoCliente.SelectedValue);
                        if (idCliente != -1)
                        {
                            string nombreSede = txtNombre.Text+" "+txtApellido.Text;
                            if (cli.agregarSedeCliente(txtId.Text,idCliente.ToString(), nombreSede.ToUpper(), txtTelefono.Text, txtDireccion.Text, dropMunicipio.SelectedValue, "Principal") != -1)
                            {
                                mostrarmensaje("exito", "Cliente agregado correctamente.");
                                limpiarCampos();
                            }
                            else
                                mostrarmensaje("error", "ERROR: No se logró agregar la sede.");
                        }
                        else
                            mostrarmensaje("error", "ERROR: No se logró crear el cliente.");
                    }
                    else
                        mostrarmensaje("error", "ERROR: No se logró relacionar el usuario con rol de cliente.");

                }
                else
                    mostrarmensaje("error", "ERROR: No se logró agregar el usuario de este cliente.");
    
    }
    private Boolean email_bien_escrito(String email)
    {
        String expresion;
        expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        if (Regex.IsMatch(email, expresion))
        {
            if (Regex.Replace(email, expresion, String.Empty).Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    private void limpiarCampos()
    {
        txtId.Text = string.Empty;
        txtNombre.Text = string.Empty;
        txtApellido.Text = string.Empty;
        txtTelefono.Text = string.Empty;
        txtCelularContacto.Text = string.Empty;
        txtDireccion.Text = string.Empty;
        dropMunicipio.SelectedIndex = 0;
        dropTipoCliente.SelectedIndex = 0;
        txtEmail.Text = string.Empty;
    }
    protected void imgTipoCliente_Click(object sender, ImageClickEventArgs e)
    {
        this.PanelAgregar_TipoCliente_Modalpopupextender.Show();
        txtTipoCliente.Focus();
    }
    protected void btnAgregarNewTipoCliente_Click(object sender, EventArgs e)
    {
        if (cli.agregarTipoCliente(txtTipoCliente.Text))
        {
            ddTipoCLiente(dropTipoCliente);
            txtTipoCliente.Text = "";
            dropTipoCliente.SelectedIndex = 0;
            mostrarmensaje("exito", "Agregado Exitosamente");
        }
        else
            mostrarmensaje("error", "ERROR: No pudo agregarse, ya existe uno igual");
    }
}