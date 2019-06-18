using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class equicategorias : System.Web.UI.Page
{
    Equipo equi = new Equipo();
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
            gvCargarCategoriasEquipos();
            gvCargarProveedoresEquipos();
        }
    }
    private void gvCargarCategoriasEquipos()
    {
        GridCategorias.DataSource = equi.cargarCategoriaEquipos();
        GridCategorias.DataBind();
    }
    private void gvCargarProveedoresEquipos()
    {
        GridProveedores.DataSource = equi.cargarProveedoresEquipos();
        GridProveedores.DataBind();
    }
    protected void btnAgregarCategorai_Click(object sender, EventArgs e)
    {
        if (equi.agregarCategoriaEquipo(txtNombreCategorias.Text.ToUpper()))
        {
            gvCargarCategoriasEquipos();
            txtNombreCategorias.Text = string.Empty;
            mostrarmensaje("exito", "Categoria Agregada Correctamente");
           
        }
        else
        {
            mostrarmensaje("error", "ERROR: Ya existe una categoria igual.");
        }
    }
    protected void GridCategorias_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = GridCategorias.SelectedRow;
        string coduser = Convert.ToString(GridCategorias.DataKeys[e.RowIndex].Value);
        if (equi.eliminarCategoriaEquipo(coduser))
        {
            mostrarmensaje("exito", "Categoria eliminada correctamente.");
            gvCargarCategoriasEquipos();
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se logró elimnar la categoria.");
        }
    }
    Funciones fun = new Funciones();
    protected void btnAgregarProveedor_Click(object sender, EventArgs e)
    {
        if (txtEmail.Text != "")
        {
            if (fun.email_bien_escrito(txtEmail.Text))
            {
                if (equi.agregarProveedorEquipo(txtNombreProve.Text, txtTelefono.Text, txtEmail.Text))
                {
                    txtNombreProve.Text = string.Empty;
                    txtTelefono.Text = string.Empty;
                    txtEmail.Text = string.Empty;
                    mostrarmensaje("exito", "Proveedor Agregado Correctamente.");
                    gvCargarProveedoresEquipos();
                }
                else
                {
                    mostrarmensaje("error", "ERROR: No se logro agregar el proveedor");
                }
            }
            else
            {
                mostrarmensaje("error", "Correo electronico invalido.");
            }
        }
        else
        {
            if (equi.agregarProveedorEquipo(txtNombreProve.Text, txtTelefono.Text, txtEmail.Text))
            {
                txtNombreProve.Text = string.Empty;
                txtTelefono.Text = string.Empty;
                txtEmail.Text = string.Empty;
                mostrarmensaje("exito", "Proveedor Agregado Correctamente.");
                gvCargarProveedoresEquipos();
            }
            else
            {
                mostrarmensaje("error", "ERROR: No se logro agregar el proveedor");
            }
        }
      
    }
    protected void GridProveedores_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = GridCategorias.SelectedRow;
        string coduser = Convert.ToString(GridProveedores.DataKeys[e.RowIndex].Value);
        if (equi.eliminarProveedorEquipo(coduser))
        {
            mostrarmensaje("exito", "Proveedor eliminado correctamente.");
            gvCargarProveedoresEquipos();
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se logró elimnar el Proveedor.");
        }
    }
}