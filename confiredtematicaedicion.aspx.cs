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



public partial class confiredtematicaedicion : System.Web.UI.Page
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
          
            ddDepartamentos(dropDepartamento);
            //ddInstituciones(dropInstituciones);
            ddGrados(dropGrados);
            buscarUsuario();

        }
    }
    public void obtenerGET()
    {
        lblEstrategia.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["e"]);
        lblMomento.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        lblSesion.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
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
    private void ddMunicipios(DropDownList drop,  string coddepartamento)
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
    protected void dropSedes_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddRedesTematicas(dropGrupoInvestigacion, dropSedes.SelectedValue);

    }
    protected void dropGrupoInvestigacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvcargarEstudiantesxRedTematica(dropGrupoInvestigacion.SelectedValue);
        gvcargarDocentesAcompañantes(dropGrupoInvestigacion.SelectedValue);
        gvcargarAsesoresxRedTematica(dropGrupoInvestigacion.SelectedValue);

        lblCodGrupoInvestigacion.Text = dropGrupoInvestigacion.SelectedValue;

        btnAgregarEstudiante.Visible = true;
        btnAgregarDocente.Visible = true;
        btnagregarAsesor.Visible = true;

        GridEstudiante.Visible = true;
        GridDocentes.Visible = true;
        GridAsesor.Visible = true;

    }
    private void ddSedes(DropDownList drop, string codinstitucion)
    {
        DataTable datos = ins.cargarSedesInstitucion(codinstitucion);
        drop.DataSource = datos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));

       
    }
    private void ddRedesTematicas(DropDownList drop, string codsede)
    {
        DataTable datos = est.cargarRedTematica(codsede);
        drop.DataSource = datos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));

        if (datos != null && datos.Rows.Count > 0)
        {
            lblCodSede.Text = codsede;

          
        }
        else
        {
            dropGrupoInvestigacion.Items.Clear();
          
        }
    }
    
    private void ddGrados(DropDownList drop)
    {
        drop.DataSource = ins.cargarGrados();
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }

    private void gvcargarIntegrantesEstudiantes(string codgrupoinvestigacion)
    {
        gvcargarEstudiantesxRedTematica(codgrupoinvestigacion);
        lblCodGrupoInvestigacion.Text = codgrupoinvestigacion;
    }

    private void gvcargarDocentesAcompañantes(string codproyectosede)
    {
        GridDocentes.DataSource = estu.cargarDocentesxRedTematica(codproyectosede);
        GridDocentes.DataBind();
    }

    private void gvcargarAsesoresxRedTematica(string codproyectosede)
    {
        GridAsesor.DataSource = estu.cargarAsesorxRedTematica(codproyectosede);
        GridAsesor.DataBind();
    }

    protected void btnAgregarEstudiante_Click(object sender, EventArgs e)
    {
        PanelVerEstudiante.Visible = true;
    }
    protected void btnAgregarDocente_Click(object sender, EventArgs e)
    {
        PanelVerDocentes.Visible = true;
        gvCargarDocentesxSede(lblCodSede.Text);
        btnGuardarDocenteLineaInvestigacion.Visible = true;
    }

    protected void btnagregarAsesor_Click(object sender, EventArgs e)
    {
        PanelVerAsesores.Visible = true;
        gvCargarAsesorxEstrategia1("4");
        btnGuardarAsesorLineaInvestigacion.Visible = true;
    }

    protected void btnBuscarEstudiantesNew_Click(object sender, EventArgs e)
    {
        gvcargarEstudiantesBuscados();
        btnGuardarEstuLineaInvestigacion.Visible = true;
    }
    protected void DeleteEstudianteActivo_Click(object sender, ImageClickEventArgs e)
    {
       
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        string codproyectomatricula = GridEstudiante.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  

        if (estu.eliminarMatriculaEstudianteRedTematica(codproyectomatricula)) { }
        gvcargarEstudiantesxRedTematica(lblCodGrupoInvestigacion.Text);
    }
    protected void DeleteDocenteActivo_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        string codproyectodocente = GridDocentes.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  

        if (estu.eliminarMatriculaDocenteRedTematica(codproyectodocente)) { }
        gvcargarDocentesAcompañantes(lblCodGrupoInvestigacion.Text);

    }
    protected void DeleteAsesorActivo_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        string codproyectosede = GridAsesor.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  

        if (estu.eliminarMatriculaAsesorGrupoInvestigacion(codproyectosede)) { }
        gvCargarAsesorxEstrategia1("4");
        gvcargarAsesoresxRedTematica(lblCodGrupoInvestigacion.Text);

    }
    private void gvcargarEstudiantesBuscados()
    {
        GridEstudiantesBuscados.DataSource = estu.cargarEstudiantexSedexGrado(dropSedes.SelectedValue, dropGrados.SelectedValue, "1");
        GridEstudiantesBuscados.DataBind();
    }

    private void gvcargarEstudiantesxRedTematica(string codgrupoinvestigacion)
    {
        GridEstudiante.DataSource = estu.cargarEstudiantesxRedTematica(codgrupoinvestigacion);
        GridEstudiante.DataBind();
    }

    private void gvCargarDocentesxSede(string codsede)
    {
        DataTable docentes = doc.cargarDocentesxSede(codsede,dropAnio.SelectedValue);
        GridDocentesBuscados.DataSource = docentes;
        GridDocentesBuscados.DataBind();
    }

    private void gvCargarAsesorxEstrategia1(string codestrategia)
    {
        DataTable asesores = estu.cargarAsesorxEstrategia(codestrategia);
        GridAsesoresBuscados.DataSource = asesores;
        GridAsesoresBuscados.DataBind();
    }

    protected void btnGuardarEstuLineaInvestigacion_Click(object sender, EventArgs e)
    {
        int val = 0;
        foreach (GridViewRow row in GridEstudiantesBuscados.Rows)
        {
            string codestumatricula = HttpUtility.HtmlDecode(row.Cells[1].Text);

             CheckBox dd = (row.FindControl("chkListEstudiante") as CheckBox);
            bool rb = dd.Checked;
            if (rb == true)
            {
                DataRow redtematicamatricula = estu.agregarEstudiantexRedTematica(lblCodGrupoInvestigacion.Text, codestumatricula);
                    if (redtematicamatricula != null)
                    {
                       val++;
                    }
             
            }
        }

        if(val == 0)
        {
            string script = @"<script type='text/javascript'>
                                alert('Seleccione los estudiantes que van a pertenecer a la Red Temática');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);  
        }
        else
        {
            string script = @"<script type='text/javascript'>
                                alert('Datos ingresado correctamente.');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            gvcargarEstudiantesxRedTematica(lblCodGrupoInvestigacion.Text);

        }
        
    }

    protected void btnGuardarDocenteLineaInvestigacion_Click(object sender, EventArgs e)
    {
        int valDoc = 0;
        foreach (GridViewRow row2 in GridDocentesBuscados.Rows)
        {
             CheckBox dd = (row2.FindControl("chkListDocente") as CheckBox);
            bool rb = dd.Checked;
            if (rb == true)
            {
                string codgradodocente = HttpUtility.HtmlDecode(row2.Cells[1].Text);
                if (estu.agregarDocentexRedTematica(codgradodocente, lblCodGrupoInvestigacion.Text))
                {
                    valDoc++;
                }
            }
           
        }

        if (valDoc == 0)
        {
            string script = @"<script type='text/javascript'>
                                alert('Seleccione los Docentes que van a pertenecer a la Red Temática');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
        else
        {
            string script = @"<script type='text/javascript'>
                                alert('Datos ingresado correctamente.');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            gvcargarDocentesAcompañantes(lblCodGrupoInvestigacion.Text);
            gvCargarDocentesxSede(lblCodSede.Text);
        }
    }

    protected void btnGuardarAsesorLineaInvestigacion_Click(object sender, EventArgs e)
    {
        int valDoc = 0;
        foreach (GridViewRow row2 in GridAsesoresBuscados.Rows)
        {
            RadioButton rbt = (row2.FindControl("rbtAsesor") as RadioButton);
            //CheckBox dd = (row2.FindControl("chkListDocente") as CheckBox);

            if (rbt.Checked)
            {
                string codasesorcoordinador = HttpUtility.HtmlDecode(row2.Cells[1].Text);
                if (estu.agregarMatriculaAsesorRedTematica(codasesorcoordinador, lblCodGrupoInvestigacion.Text))
                {
                    valDoc++;
                }
            }

        }

        if (valDoc == 0)
        {
            string script = @"<script type='text/javascript'>
                                alert('Seleccione el Asesor que van a pertenecer a la Red Temática');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
        else
        {
            string script = @"<script type='text/javascript'>
                                alert('Datos ingresado correctamente.');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            gvCargarAsesorxEstrategia1("4");
            gvcargarAsesoresxRedTematica(lblCodGrupoInvestigacion.Text);
            
        }
    }

  
}