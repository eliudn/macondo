using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class prodocumentos : System.Web.UI.Page
{
    Proyecto pro = new Proyecto();
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
            PanelEditar.Attributes.Add("style", "display:none");
            ddProyectos(dropProyecto,true);
            ddProyectos(dropProyectoEditar,false);
            gvCargarDocumentos();
        }
    }
    private void ddProyectos(DropDownList drop,bool add)
    {
        drop.DataSource = pro.cargarProyectos();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        if(add)
          drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos"));
        else
          drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void gvCargarDocumentos()
    {
        GridDocumentos.DataSource = pro.cargarDocumentoProyectos();
        GridDocumentos.DataBind();
    }
    protected void btnAgregarDocumento_Click(object sender, EventArgs e)
    {
        if (dropProyecto.SelectedIndex == 0)
        {
            bool agrego = false;
             DataTable datosProyectos =  pro.cargarProyectos();
             if (datosProyectos != null && datosProyectos.Rows.Count >0)
             {
                 for (int i = 0; i < datosProyectos.Rows.Count; i++)
                 {
                     if (pro.agregarDocumentoProyecto(datosProyectos.Rows[i]["cod"].ToString(), txtNombre.Text.ToUpper()))
                     {
                         agrego = true;
                     }
                 }

                 if (agrego)
                 {
                     gvCargarDocumentos();
                     txtNombre.Text = string.Empty;
                     dropProyecto.SelectedIndex = 0;
                     mostrarmensaje("exito", "Documentos agregados correctamente");
                 }
                 else
                     mostrarmensaje("error", "No se logró agregar ningún documento.");
             }
             else
             {
                 mostrarmensaje("error", "ERROR: Debe agregar los proyectos antes de los documentos.");
             }
        }
        else
        {
            if (pro.agregarDocumentoProyecto(dropProyecto.SelectedValue, txtNombre.Text.ToUpper()))
            {
                mostrarmensaje("exito", "Agregado correctamente");
                gvCargarDocumentos();
                txtNombre.Text = string.Empty;
                dropProyecto.SelectedIndex = 0;
            }
            else
            {
                mostrarmensaje("error", "ERROR: No se logró agregar el documento.");
            }
        }
      
    }
    protected void btnEditarProyecto_Click(object sender, EventArgs e)
    {
        if (pro.editarDocumentoProyecto(dropProyectoEditar.SelectedValue, txtNombreEditar.Text.ToUpper(), lblCodProyecto.Text))
        {
            mostrarmensaje("exito", "Editado Correctamente");
            gvCargarDocumentos();
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se logró editar el documento");
        }
    }
    protected void imgEditar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string cod = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        string nombre = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
        string codproyecto = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);

        lblCodProyecto.Text = cod;
        txtNombreEditar.Text = nombre;
        dropProyectoEditar.SelectedValue = codproyecto;
        this.PanelEditar_Modalpopupextender.Show();
    }
    protected void imgDlete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string cod = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

        if (pro.eliminarDocumentoProyecto(cod))
        {
            mostrarmensaje("exito", "Eliminado correctamente.");
            gvCargarDocumentos();
        }
        else
        {
            mostrarmensaje("error", "ERROR: Este documento esta siendo usado");
        }
    }
}