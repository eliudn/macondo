using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class confiperfiles : System.Web.UI.Page
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
            gvCargarPerfiles();
            ddPerfiles(DropPerfil);
        }
    }
    private void gvCargarPerfiles()
    {
        Usuario usu = new Usuario();
        DataTable datos = usu.cargarPerfiles();
        GridPerfiles.DataSource = datos;
        GridPerfiles.DataBind();
    }
    private void ddPerfiles(DropDownList perfil)
    {
        Usuario usu = new Usuario();
        DataTable datos = usu.cargarPerfiles();
        perfil.DataSource = datos;
        perfil.DataTextField = "nombre";
        perfil.DataValueField = "cod";
        perfil.DataBind();
    }
    protected void GridPerfiles_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string cod = GridPerfiles.Rows[e.RowIndex].Cells[0].Text;
        Usuario usu = new Usuario();
        if (usu.eliminarPerfil(cod))
        {
            gvCargarPerfiles();
            ddPerfiles(DropPerfil);
            mostrarmensaje("exito", "Eliminado Correctamente");
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se pudo eliminar el perfil, se encuentra en uso.");
        }
    }
    protected void btnAgregarPerfil_Click(object sender, EventArgs e)
    {
        Usuario usu = new Usuario();
        if (usu.agregarPerfiles(txtNombrePerfil.Text))
        {
            txtNombrePerfil.Text = "";
            gvCargarPerfiles();
            ddPerfiles(DropPerfil);
            mostrarmensaje("exito", "Perfil Creado Exitosamente");
        }
        else
        {
            mostrarmensaje("error", "Error Al Crear Nuevo Perfil, Ya existe. ");
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
    protected void btnSeleccionePerfil_Click(object sender, EventArgs e)
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