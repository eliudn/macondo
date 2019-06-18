using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class confirol : System.Web.UI.Page
{
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
            gvCargarroles();
            ddPerfiles(DropPerfil);
            gvCargarroles(DropRol);
        }
    }
    private void ddPerfiles(DropDownList rol)
    {
        Usuario usu = new Usuario();
        DataTable datos = usu.cargarPerfiles();
        rol.DataSource = datos;
        rol.DataTextField = "nombre";
        rol.DataValueField = "cod";
        rol.DataBind();
    }
    private void gvCargarroles()
    {
        Usuario usu = new Usuario();
        DataTable datos = usu.cargarRolesPerfiles();
        GridRolPerfiles.DataSource = datos;
        GridRolPerfiles.DataBind();
    }
    private void gvCargarroles(DropDownList rol)
    {
        Usuario usu = new Usuario();
        DataTable datos = usu.cargarRolesPerfiles();
        rol.DataSource = datos;
        rol.DataTextField = "nomrol";
        rol.DataValueField = "codrol";
        rol.DataBind();
    }
    protected void GridRolPerfiles_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item = e.Row.Cells[1].Text;

            foreach (ImageButton button in e.Row.Cells[4].Controls.OfType<ImageButton>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('Desea eliminar el usuario " + item + "?')){ return false; };";
                }
            }
        }
    }
    protected void GridRolPerfiles_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string cod = GridRolPerfiles.Rows[e.RowIndex].Cells[0].Text;
        Usuario usu = new Usuario();
        if (usu.eliminarPerfil(cod))
        {
            gvCargarroles();
            ddPerfiles(DropRol);
            mostrarmensaje("exito", "Eliminado Correctamente");
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se pudo eliminar el perfil, se encuentra en uso.");
        }
    }
    protected void btnAgregarRol_Click(object sender, EventArgs e)
    {
        Usuario usu = new Usuario();

        DataRow dat = usu.buscarNombrePerfilRol(DropPerfil.SelectedValue);

        if (dat != null && dat["nombre"].ToString() == txtNombreRol.Text)
        {
            if (usu.AgregarRolPerfiles(txtNombreRol.Text, DropPerfil.SelectedValue))
            {
                txtNombreRol.Text = "";
                gvCargarroles();
                ddPerfiles(DropPerfil);
                mostrarmensaje("exito", "Rol asignado exitosamente al Perfil");
            }
            else
            {
                mostrarmensaje("error", "Error Al Crear Nuevo Rol, Ya existe. ");
            }
        }
        else
        {
            mostrarmensaje("error", "Error Al Crear Nuevo Rol, No se puede asociar con el Perfil");
        }
    }
    protected void GridPerfiles_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item = HttpUtility.HtmlDecode(e.Row.Cells[1].Text);
            foreach (ImageButton button in e.Row.Cells[2].Controls.OfType<ImageButton>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('Desea eliminar el perfil: " + item + "?')){ return false; };";
                }
            }
        }
    }
    protected void btnSeleccioneRol_Click(object sender, EventArgs e)
    {
        lblPerfilEsc.Text = DropPerfil.SelectedValue;
        PanelPerfiles.Visible = true;
        lblPerfil.Text = DropPerfil.Items[DropPerfil.SelectedIndex].Text;
        lbMenudelPerfil(GridMenuPerfil);
        lbCodSuperior(GridMenus, lblPerfilEsc.Text);
    }
    private void lbMenudelPerfil(GridView gridPerfil)
    {
        Menu men = new Menu();
        DataSet datos = men.cargarMenudePerfilHenry(lblPerfilEsc.Text);
        gridPerfil.DataSource = datos;
        gridPerfil.DataBind();

    }
    private void lbCodSuperior(GridView gridDisponibles, String codperfil)
    {
        Menu men = new Menu();
        DataSet datos = men.cargarMenuHenry(codperfil);
        gridDisponibles.DataSource = datos;
        gridDisponibles.DataBind();
    }
    protected void btnPasar_Click(object sender, EventArgs e)
    {
        bool eligio = false;
        bool actualizo = false;
        Menu men = new Menu();
        foreach (GridViewRow gvr in GridMenus.Rows)   //loop through GridView
        {
            CheckBox chkPasar = (gvr.FindControl("cbDisponibles") as CheckBox);
            if (chkPasar.Checked)
            {
                eligio = true;
                string codsel = HttpUtility.HtmlDecode(GridMenus.Rows[gvr.RowIndex].Cells[1].Text);
                if (men.asignarMenuaPerfil(codsel, lblPerfilEsc.Text))
                {
                    actualizo = true;
                }
                else
                {
                    mostrarmensaje("error", "No se pudo quitar item");
                }
            }
        }
        if (eligio)
        {
            if (actualizo)
            {
                mostrarmensaje("exito", "Asignado Correctamente");
                lbMenudelPerfil(GridMenuPerfil);
                lbCodSuperior(GridMenus, lblPerfilEsc.Text);
            }
            else
            {
                mostrarmensaje("error", "ERROR: No se realizaron los cambios.");
            }
        }
        else
        {
            mostrarmensaje("error", "No hay ningún item Seleccionado");
        }
      

    }
    protected void btnEliminardePerfil_Click(object sender, EventArgs e)
    {
        bool eligio = false;
        bool actualizo = false;
        Menu men = new Menu();
        foreach (GridViewRow gvr in GridMenuPerfil.Rows)   //loop through GridView
        {
            CheckBox chkPasar = (gvr.FindControl("cbItem") as CheckBox);
            if (chkPasar.Checked)
            {
                eligio = true;
                string codsel = HttpUtility.HtmlDecode(GridMenuPerfil.Rows[gvr.RowIndex].Cells[1].Text);

                if (men.quitarMenudePerfil(codsel))
                {
                    actualizo = true;
                }
                else
                {
                    mostrarmensaje("error", "No se pudo quitar item");
                }
            }
        }
        if (eligio)
        {
            if (actualizo)
            {
                mostrarmensaje("exito", "Quitado Correctamente");
                lbMenudelPerfil(GridMenuPerfil);
                lbCodSuperior(GridMenus, lblPerfilEsc.Text);
            }
            else
            {
                mostrarmensaje("error", "ERROR: No se realizaron los cambios.");
            }
        }
        else
        {
            mostrarmensaje("error", "No hay ningún item Seleccionado");
        }
       
    }
}