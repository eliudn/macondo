using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class confisolicitudes : System.Web.UI.Page
{
    Cliente cli = new Cliente();
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
            gvcargarSolicitudes();
            gvcargarCausasIncidente();
            ddPrioridades(dropPrioridad);
            ddPrioridades(dropPrioridad2);
        }
    }
    private void gvcargarSolicitudes()
    {
        GridSolicitudes.DataSource = cli.cargarSolicitudes();
        GridSolicitudes.DataBind();
    }
    private void gvcargarCausasIncidente()
    {
        GridCausaIncidente.DataSource = cli.cargarCausaIncidente();
        GridCausaIncidente.DataBind();
    }
    private void ddPrioridades(DropDownList drop)
    {
        drop.DataSource = cli.cargarPrioridades();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    protected void btnAgregarSolicitud_Click(object sender, EventArgs e)
    {
        if (cli.agregarTipoSolicitud(txtNombreSolicitud.Text, dropPrioridad.SelectedValue, txtANS.Text))
        {
            mostrarmensaje("exito", "Tipo de solicitud agregada correctamente");
            gvcargarSolicitudes();
            txtNombreSolicitud.Text = string.Empty;
            txtANS.Text = string.Empty;
            dropPrioridad.SelectedIndex = 0;
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se logró agregar la solicitud");
        }
    }
    protected void GridSolicitudes_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = GridSolicitudes.SelectedRow;
        string coduser = Convert.ToString(GridSolicitudes.DataKeys[e.RowIndex].Value);
        if (cli.eliminarTipoSolicitud(coduser))
        {
            mostrarmensaje("exito", "Solicitud eliminada correctamente.");
            gvcargarSolicitudes();
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se logró eliminar la Solicitud.");
        }
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        if (cli.editarTipoSolicitud(txtNombre2.Text, dropPrioridad2.SelectedValue, txtANS2.Text, lblCodSolicitud.Text))
        {
            mostrarmensaje("exito", "Editado Correctamente");
            gvcargarSolicitudes();
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se logro guardar los cambios.");
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string cod = GridSolicitudes.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  

        lblCodSolicitud.Text = cod;
        string nombre = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
        string codprioridad = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
        string ans = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);

        txtNombre2.Text = nombre;
        dropPrioridad2.SelectedValue = codprioridad;
        txtANS2.Text = ans;

        this.PanelVerDependencias_ModalPopupExtender.Show();
    }
  
    protected void GridCausaIncidente_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        GridViewRow row = GridCausaIncidente.SelectedRow;
        string coduser = Convert.ToString(GridCausaIncidente.DataKeys[e.RowIndex].Value);
        if (cli.eliminarCausaIncidente(coduser))
        {
            mostrarmensaje("exito", "Causa eliminada correctamente.");
            gvcargarCausasIncidente();
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se logró eliminar la Causa.");
        }
    }
    protected void btnAgregarCausa_Click1(object sender, EventArgs e)
    {
        if (cli.agregarCausaIncidente(txtNombreIncidente.Text))
        {
            txtNombreIncidente.Text = string.Empty;
            gvcargarCausasIncidente();
            mostrarmensaje("exito", "Causa agregada correctamente");
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se logró agregar, Ya existe una igual");
        }
    }
}