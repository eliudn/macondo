using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class equiregistrar : System.Web.UI.Page
{
    Equipo equ = new Equipo();
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
        if (!IsPostBack)
        {
            ddCategoria(dropCategoria);
            ddFabricante(dropFabricante);
            gvCargarEquipos();
        }
    }
    private void gvCargarEquipos()
    {
        GridEquipos.DataSource = equ.cargarEquipos();
        GridEquipos.DataBind();
    }
    private void ddCategoria(DropDownList drop)
    {
        drop.DataSource = equ.cargarCategoriaEquipos();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddFabricante(DropDownList drop)
    {
        drop.DataSource = equ.cargarProveedoresEquipos();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    protected void btnAgregarEquipo_Click(object sender, EventArgs e)
    {
        if (equ.agregarEquipo(txtModelo.Text, txtDescripcion.Text, dropCategoria.SelectedValue, dropFabricante.SelectedValue))
        {
            mostrarmensaje("exito", "Equipo agregado con exito.");
            gvCargarEquipos();
            txtModelo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            dropCategoria.SelectedIndex = 0;
            dropFabricante.SelectedIndex = 0;
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se logró agregar el equipo");
        }
    }
    protected void GridEquipos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = GridEquipos.SelectedRow;
        string coduser = Convert.ToString(GridEquipos.DataKeys[e.RowIndex].Value);
        if (equ.eliminarEquipo(coduser))
        {
            mostrarmensaje("exito", "Equipo eliminada correctamente.");
            gvCargarEquipos();
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se logró elimnar el Equipo.");
        }
    }
}