using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
//using Newtonsoft.Json;
//using System.IO;



public partial class confiredescambioasesor : System.Web.UI.Page
{
    Funciones fun = new Funciones();
    Estrategias est = new Estrategias();
    Institucion ins = new Institucion();
    Estudiantes estu = new Estudiantes();
    Docentes doc = new Docentes();

    //string JsonString = string.Empty;
    //ConvertJsonStringToDataTable jDt = new ConvertJsonStringToDataTable();
    //DataTable dt;

    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["codperfil"] != null)
        {

        }
        else
            Response.Redirect("Default.aspx",true);
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
            //ddAnio(dropAnio);
            ddDepartamentos(dropDepartamento);
        }
    }
    public void obtenerGET()
    {
        lblEstrategia.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["e"]);
        lblMomento.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        lblSesion.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
    }
    private void ddAnio(DropDownList drop)
    {
        drop.DataSource = ins.cargarAnios();
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void buscarUsuario()
    {
        Usuario usu = new Usuario();
        DataRow dato = usu.buscarUsuario(Session["codusuario"].ToString());
        if (dato != null)
        {
            lblCodUsuario.Text = dato["cod"].ToString();

        }

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
//        string script = @"<script type='text/javascript'> 
//                               $('#agregar').hide(); $('#conformar').show(); $('#verGrupos').hide();$('#mover').hide();
//            </script>";
//        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }
    protected void dropMunicipio_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddInstituciones(dropInstituciones, dropMunicipio.SelectedValue);
//        string script = @"<script type='text/javascript'> 
//                               $('#agregar').hide(); $('#conformar').show(); $('#verGrupos').hide();$('#mover').hide();
//            </script>";
//        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }
    protected void dropInstituciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddSedes(dropSedes, dropInstituciones.SelectedValue);
//        string script = @"<script type='text/javascript'> 
//                               $('#agregar').hide(); $('#conformar').show(); $('#verGrupos').hide();$('#mover').hide();
//            </script>";
//        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }
    private void ddSedes(DropDownList drop, string codinstitucion)
    {
        drop.DataSource = ins.cargarSedesInstitucion(codinstitucion);
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        gvCargarGruposInvestigacion(dropSedes.SelectedValue);
    }

    private void gvCargarGruposInvestigacion(string codsede)
    {
        DataTable datos = est.cargarRedesSedexSedes(codsede);
        GridGrupos.DataSource = datos;
        GridGrupos.DataBind();
        btnCambiarAsesores.Visible = true;
        DropDownList dropAsesores = null;

        if (datos != null && datos.Rows.Count > 0)
        {
           
            foreach (GridViewRow row in GridGrupos.Rows)
            {
                dropAsesores = (row.FindControl("dropAsesores") as DropDownList);
                ddAsesoresxEstrategia(dropAsesores);
            }
        }
    }

    private void ddAsesoresxEstrategia(DropDownList perfil)
    {
        Asesores ase = new Asesores();
        DataTable datos = ase.cargarAsesoresxEstrategia("4");
        perfil.DataSource = datos;
        perfil.DataTextField = "nombre";
        perfil.DataValueField = "codasesorcoordinador";
        perfil.DataBind();
        perfil.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione..."));
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("estramomentos.aspx");
    }

    protected void btnCambiarAsesores_Click(object sender, EventArgs e)
    {
        int val = 0;
        foreach (GridViewRow row in GridGrupos.Rows)
        {
            string codredtematicasede = GridGrupos.DataKeys[row.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  

            DropDownList dd = (row.FindControl("dropAsesores") as DropDownList);
            if (dd.SelectedIndex != 0)
            {
                if (est.editarAsesorEnRedesTematicas(dd.SelectedValue, codredtematicasede))
               {
                   val++;
               }
            }
        }

        if (val > 0)
        {
            string script = @"<script type='text/javascript'> 
                               alert('Cambios realizados correctamente.');
            </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    gvCargarGruposInvestigacion(dropSedes.SelectedValue);
                    btnCambiarAsesores.Visible = true;
        }
        else
        {
            string script = @"<script type='text/javascript'> 
                               alert('No hubo cambios realizados.');
            </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

    }
  
}