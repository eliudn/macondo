using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Defaultviejo : System.Web.UI.Page
{
    Funciones fun = new Funciones();
    protected void Page_Load(object sender, EventArgs e)
    {
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 
        txtUsuario.Focus();
        Session.RemoveAll();
        if (!IsPostBack)
        {
           
        }
    }
    protected void btnEntrar_Click(object sender, EventArgs e)
    {
        Usuario usu = new Usuario();
        DataRow datoUsuario = usu.verificarUsuario(txtUsuario.Text.Replace("'", ""), txtPass.Text.Replace("'", ""));
        if (datoUsuario != null)
        {
            if (datoUsuario["estado"].ToString() != "Off")
            {
                DataTable datosRoles = usu.cargarRolesUsuarios(datoUsuario["cod"].ToString());
                if (datosRoles != null && datosRoles.Rows.Count > 1)
                {
                    int i = 0; bool seguir = true;
                    while (i < datosRoles.Rows.Count && seguir)
                    {
                        if (datosRoles.Rows[i]["preferencia"].ToString() == "1")
                        {
                            seguir = false;
                        }
                        i++;
                    }

                    if (seguir)
                    {
                        ddRoles(dropRoles, datosRoles);
                        PanelRoles.Visible = true;
                        PanelUserPass.Visible = false;
                        lblCodUsuario.Text = datoUsuario["cod"].ToString();
                    }
                    else
                    {
                        Arracar(datosRoles.Rows[i - 1]);
                    }

                }
                else if (datosRoles != null && datosRoles.Rows.Count == 1)
                {
                    Arracar(datosRoles.Rows[0]);
                }
                else
                {
                    lblMensaje.Visible = true;
                    lblMensaje.Text = "Error: Este usuario no tienes roles asignados,<br />Por favor comunicate con el administrador.";
                }  
            }
            else
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "ERROR: Usuario Inactivo";
            }
                
            
        }
        else
        {
            lblMensaje.Visible = true;
            lblMensaje.Text = "Usuario y/o Contraseña Incorrecta";
        }
      
    }
    private void Arracar(DataRow datoUsuario)
    {
        long id = Funciones.insertarVisita(datoUsuario["codusuario"].ToString(), datoUsuario["codrol"].ToString());
        if (id != -1)
        {
            Session["codsession"] = id.ToString();
            Session["codusuariorol"] = datoUsuario["cod"].ToString();
            Session["codusuario"] = datoUsuario["codusuario"];
            Session["codrol"] = datoUsuario["codrol"];
            Session["rol"] = datoUsuario["nombre"];
            Session["codperfil"] = datoUsuario["codperfil"];
            Response.Redirect("bienvenida.aspx",true);
        }
    }
    private void ddRoles(DropDownList drop, DataTable datos)
    {
        drop.DataSource = datos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "codrol";
        drop.DataBind();
    }
    protected void btnElegirRol_Click(object sender, EventArgs e)
    {
        Usuario user = new Usuario();
        user.editarPreferenciaRol("1",lblCodUsuario.Text,dropRoles.SelectedValue);
        Arracar(user.buscarUsuarioxRolxCod(lblCodUsuario.Text, dropRoles.SelectedValue));
    }
}