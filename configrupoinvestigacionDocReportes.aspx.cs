using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ClosedXML;
using ClosedXML.Excel;
using System.Drawing;
using System.Web.Script.Serialization;
using System.Web.Services;

public partial class configrupoinvestigacionDocReportes : System.Web.UI.Page
{
    Funciones fun = new Funciones();

    Proyecto pro = new Proyecto();
    Cliente cli = new Cliente();
    Localidad loc = new Localidad();
    Institucion ins = new Institucion();
    Estudiantes est = new Estudiantes();
    Docentes doc = new Docentes();
    Asesores ase = new Asesores();
    Estrategias estr = new Estrategias();
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
            //ddDepartamento(dropdepartamento);

            //ddAsesores(dropAsesores);
            ddDepartamentos(dropDepartamento);
            //ddAnio(dropAnio);

            if (Session["codsede"] != null)
            {
                cargarGruposxSede(Session["codsede"].ToString());
                //dropAsesores.SelectedValue = Session["codasesorcoordinador"].ToString();
            }
        }
        
    }


    private void ddAsesores(DropDownList drop)
    {
        drop.DataSource = ins.cargarListadoAsesoresxCoordinadorSeguimiento("2","");
        drop.DataTextField = "nomasesor";
        drop.DataValueField = "codasesorcoordinador";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }

    private void ddAnio(DropDownList drop)
    {
        drop.DataSource = ins.cargarAnios();
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddInstituciones(DropDownList drop, string codmunicipio)
    {
        drop.DataSource = ins.cargarInstitucionxMunicipio(codmunicipio);
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddDepartamentos(DropDownList drop)
    {
        drop.DataSource = ins.cargarDepartamentoMagdalena();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));

    }
    private void ddMunicipios(DropDownList drop, string coddepartamento)
    {
        drop.DataSource = ins.cargarciudadxDepartamento(coddepartamento);
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    protected void dropDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddMunicipios(dropMunicipio, dropDepartamento.SelectedValue);
       
    }
    protected void dropMunicipio_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddInstituciones(dropInstituciones, dropMunicipio.SelectedValue);
      
    }
    protected void dropInstituciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddSedes(dropSedes, dropInstituciones.SelectedValue);
       
    }
    private void ddSedes(DropDownList drop, string codinstitucion)
    {
        drop.DataSource = ins.cargarSedesInstitucion(codinstitucion);
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos"));
    }

    protected void dropAsesores_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        //cargarGruposxAsesor(dropAsesores.SelectedValue);
        //Session["codasesorcoordinador"] = dropAsesores.SelectedValue;
    }

    protected void btnBuscar_Onclick(object sender, EventArgs e)
    {
        cargarGruposxSede(dropSedes.SelectedValue);
        Session["codsede"] = dropSedes.SelectedValue;
    }
    
    //Ver grupos


    private void cargarGruposxSede(string codsede)
    {

        DataTable datos = estr.cargarGruposInvestigacionDocentexSede(codsede);
        GridGrupo.DataSource = datos;
        GridGrupo.DataBind();

    }

   

    protected void imgVerDocentes_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codproyectosede = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

        string script = @"<script type='text/javascript'> $('#dialog-formDocentes').dialog({
                  modal: true,
                  height: 'auto',
                  width: 'auto',
              });
           
            </script>";

        string ca = "";

        DataTable datos = estr.cargarDocentesxSedexGrupoInvestigacion(codproyectosede);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<table  class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<th>Nro</th>";
            ca += "<th>Docentes</th>";
            ca += "</tr>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["nombre"].ToString() + "</td>";
                ca += "</tr>";
            }

        }
      
        lblDocentes.Text = ca;

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }

    protected void lnkEditarGrupo_Click(object sender, EventArgs e)
    {
        string script = @"<script type='text/javascript'> $('#agregar').hide(); $('#conformar').show(); $('#verGrupos').hide();$('#mover').hide();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
       

        LinkButton btndetails = sender as LinkButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codgrupoinvestigacion = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

        Session["codgrupoinvestigacion"] = codgrupoinvestigacion;

        Response.Redirect("configrupoinvestigaciondoceditarReporte.aspx");
    }

  

    protected void lnkInstrumentoS003_Click(object sender, EventArgs e)
    {
        LinkButton btndetails = sender as LinkButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codgrupoinvestigacion = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

        Session["codgrupoinvestigacion"] = codgrupoinvestigacion;

        Response.Redirect("estras003Reporte.aspx");
    }

    protected void lnkFinanciado_Click(object sender, EventArgs e)
    {
        LinkButton btndetails = sender as LinkButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codgrupoinvestigacion = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

        if (estr.actualizarFinanciacion(codgrupoinvestigacion,"Si"))
        {
            string script = @"<script type='text/javascript'> 
                    alert('Financiación cambiada con éxito a Si');
            </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            cargarGruposxSede(dropSedes.SelectedValue);
        }
    }

   
}