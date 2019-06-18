using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class acttipos : System.Web.UI.Page
{
    Actividad act = new Actividad();
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
            PanelVerDependencias.Attributes.Add("style", "display:none");
            gvcargarActividades();
        }
    }
    private void gvcargarActividades()
    {
        GridActividades.DataSource = act.cargarActividades();
        GridActividades.DataBind();
    }
    protected void btnAgregarActividad_Click(object sender, EventArgs e)
    {
        if (act.agregarActividad(txtNombreSolicitud.Text.ToUpper(), txtANS.Text))
        {
            mostrarmensaje("exito", "Agregado Correctamente");
            gvcargarActividades();
            txtNombreSolicitud.Text = string.Empty;
            txtANS.Text = string.Empty;
        }
        else
        {
            mostrarmensaje("error", "Ya existe uno igual.");
        }
    }
    protected void imgEdit_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string cod = GridActividades.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  

        lblCodSolicitud.Text = cod;
        string nombre = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
        string ans = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
      
        txtNombre2.Text = nombre;
        txtANS2.Text = ans;
        this.PanelVerDependencias_ModalPopupExtender.Show();
    }
    protected void GridActividades_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = GridActividades.SelectedRow;
        string cod = Convert.ToString(GridActividades.DataKeys[e.RowIndex].Value);
        if (act.eliminarActividad(cod))
        {
            mostrarmensaje("exito", "Eliminada correctamente.");
            gvcargarActividades();
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se logró eliminar la Actividad.");
        }
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        if (act.editarActividad(lblCodSolicitud.Text, txtNombre2.Text, txtANS2.Text))
        {
            gvcargarActividades();
            mostrarmensaje("exito", "Editado Correctamente");
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se logró editar.");
            this.PanelVerDependencias_ModalPopupExtender.Show();
        }
    }
}