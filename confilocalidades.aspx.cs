using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class confilocalidades : System.Web.UI.Page
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
    Localidad loc = new Localidad();
    protected void Page_Load(object sender, EventArgs e)
    {
        mensaje.Attributes.Add("style", "display:none");
        if (!IsPostBack)
        {
            gvCargarDepartamentos();
            gvCargarMunicipios();
            ddDepartamento(dropDepartamento);
            ddDepartamento(dropDepartamentoEditar);
        }
    }
    private void gvCargarDepartamentos()
    {
       
        DataTable datos = loc.cargarDepartamentos();
        GridDepartamento.DataSource = datos;
        GridDepartamento.DataBind();
    }
    private void ddDepartamento(DropDownList drop)
    {
        drop.DataSource = loc.cargarDepartamentos();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        //drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddMunicipiosSinCodSuperior(DropDownList drop,DropDownList dropFormulario)
    {
        drop.DataSource = loc.cargarMunicipiosSinCodSuperior(dropFormulario.SelectedValue);
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void gvCargarMunicipios()
    {
        DataTable datos = loc.cargarMunicipios();
        GridMunicipios.DataSource = datos;
        GridMunicipios.DataBind();
    }
    protected void btnAgregarDepartamento_Click(object sender, EventArgs e)
    {
        if (loc.agregarDepartamento(txtNombreDepartamento.Text.ToUpper()))
        {
            mostrarmensaje("exito", "Departamento Agregado Correctamente.");
            gvCargarDepartamentos();
            ddDepartamento(dropDepartamento);
            ddDepartamento(dropDepartamentoEditar);
            txtNombreDepartamento.Text = string.Empty;
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se agregó el departamento existe uno igual.");
        }
    }
    protected void ImgEliminar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string cod = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        if (loc.eliminarDepartamento(cod))
        {
            mostrarmensaje("exito", "departamento eliminado");
            gvCargarDepartamentos();
            ddDepartamento(dropDepartamento);
            ddDepartamento(dropDepartamentoEditar);
        }
        else
        {
            mostrarmensaje("error","ERROR: Este departamento esta siendo usado");
        }
    }
   
    protected void btnAgregarMunicipio_Click(object sender, EventArgs e)
    {
        if (PanelPertenece.Visible)
        {
            if (dropSuperior.SelectedIndex > 0)
            {
                if (loc.agregarMunicipio(txtMunicipio.Text.ToUpper(), dropTipoMunicipio.SelectedValue, dropSuperior.SelectedValue, dropDepartamento.SelectedValue))
                {
                    txtMunicipio.Text = string.Empty;
                    mostrarmensaje("exito", "Municipio Agregado Correctamente");
                    gvCargarMunicipios();

                }
                else
                {
                    mostrarmensaje("error", "ERROR: No logró agregar el municipio, Ya existe uno igual");
                }
            }
            else
            {
                mostrarmensaje("error", "ERROR: Debe seleccionar a que municipio pertenece");
            }
         
        }
        else
        {
            if (loc.agregarMunicipio(txtMunicipio.Text, dropTipoMunicipio.SelectedValue, "0", dropDepartamento.SelectedValue))
            {
                txtMunicipio.Text = string.Empty;
                mostrarmensaje("exito", "Municipio Agregado Correctamente");
                gvCargarMunicipios();
            }
            else
            {
                mostrarmensaje("error", "ERROR: No logró agregar el municipio, Ya existe uno igual");
            }
        }
      
    }
  
    protected void GridMunicipios_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label lblPertence = (e.Row.FindControl("lblPertence") as Label);
            string codsuperior = DataBinder.Eval(e.Row.DataItem, "codsuperior").ToString();
            if (codsuperior == "0")
            {
                //No ocurre nada, es un municipio
            }
            else
            {
                DataRow datoMunicipio = loc.buscarMunicipioxCod(codsuperior);
                if (datoMunicipio != null)
                {
                    lblPertence.Text = datoMunicipio["nombre"].ToString();
                }
                else
                {
                    lblPertence.Text = "ERROR";
                }
            }
         
        }      
    }
    protected void ImgEditarMunicipio_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string cod = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        string nombre = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
        string coddepartamento = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
        string tipo = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);
        string codsuperior = HttpUtility.HtmlDecode(gvrow.Cells[6].Text);
        lblCodMunicipio.Text = cod;
        txtMunicipioEditar.Text = nombre;
        dropDepartamentoEditar.SelectedValue = coddepartamento;
        dropTipoEditar.SelectedValue = tipo.ToLower();
         
        this.PanelEditar_Modalpopupextender.Show();
    }
    
    protected void ImgEliminarMunicipio_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string cod = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        if (loc.eliminarMunicipio(cod))
        {
            mostrarmensaje("exito", "Municipio eliminado");
            gvCargarMunicipios();
        }
        else
        {
            mostrarmensaje("error", "ERROR: Este departamento esta siendo usado");
        }
    }
    protected void dropTipoEditar_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropTipoEditar.SelectedValue == "municipio")
        {
            PanelPertenceEditar.Visible = false;
        }
        else
        {
            PanelPertenceEditar.Visible = true;
            ddMunicipiosSinCodSuperior(dropSuperiorEditar,dropDepartamentoEditar);
        }
    }
    protected void btnEditarMunicipio_Click(object sender, EventArgs e)
    {
        if (PanelPertenceEditar.Visible)
        {
            if (dropSuperiorEditar.SelectedIndex > 0)
            {
                if (loc.editarMunicipio(txtMunicipioEditar.Text, dropTipoEditar.SelectedValue, dropSuperiorEditar.SelectedValue, dropDepartamentoEditar.SelectedValue,lblCodMunicipio.Text))
                {
                    mostrarmensaje("exito", "Municio editado correctamente");
                    gvCargarMunicipios();
                }
                else
                {
                    mostrarmensaje("error", "ERROR: No se logro editar el municipio");
                    this.PanelEditar_Modalpopupextender.Show();
                }
            }
            else
            {
                mostrarmensaje("error", "ERROR: Debe seleccionar a que municipio pertenece");
                this.PanelEditar_Modalpopupextender.Show();
            }
        }
        else
        {
            if (loc.editarMunicipio(txtMunicipioEditar.Text, dropTipoEditar.SelectedValue,"0", dropDepartamentoEditar.SelectedValue, lblCodMunicipio.Text))
            {
                mostrarmensaje("exito", "Municio editado correctamente");
                gvCargarMunicipios();
            }
            else
            {
                mostrarmensaje("error", "ERROR: No se logro editar el municipio");
                this.PanelEditar_Modalpopupextender.Show();
            }
        }
    }
    protected void dropTipoMunicipio_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropTipoMunicipio.SelectedValue == "municipio")
        {
            PanelPertenece.Visible = false;
        }
        else
        {
            PanelPertenece.Visible = true;
            ddMunicipiosSinCodSuperior(dropSuperior, dropDepartamento);
        }
    }
}