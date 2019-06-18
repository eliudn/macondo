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
 


public partial class verEstraUnoBitacoraUno : System.Web.UI.Page
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
       //gvcargarbitacoraunoSupervisor();
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 

        if (!IsPostBack)
        {
            ddAnio(dropAnio);
            ddAsesores(dropAsesores);
             //gvcargarbitacoraunoSupervisor();
             DataRow dato = est.buscarCodEstraAsesorxCoordinador(Session["identificacion"].ToString());

            if (dato != null)
            {
                Session["CodAsesorEstraCoordinador"] = dato["codigo"].ToString();
                gvcargarbitacoraunoxAsesor(dato["codigo"].ToString());

            }

            obtenerGET();
            ddDepartamentos(dropDepartamento);
            //ddInstituciones(dropInstituciones);
            ddGrados(dropGrados);
         

           

        }
    }
    private void ddAnio(DropDownList drop)
    {
        drop.DataSource = ins.cargarAnios();
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddAsesores(DropDownList drop)
    {
        drop.DataSource = est.listarAsesoresSeguimiento("1");
        drop.DataTextField = "asesor";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void gvcargarbitacoraunoxAsesor(string codasesor)
    {
        DataTable datos = est.cargarbitacoraunoxAsesor(codasesor);
        GridBitacoras.DataSource = datos;
        GridBitacoras.DataBind();
		
    }
    protected void dropAsesores_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvcargarbitacoraunoSupervisor();
    }
	/*agregado 22-11-2016 por Jonny Pacheco*/
	 private void gvcargarbitacoraunoSupervisor()
    {
	   DataTable datos = est.cargarbitacoraunoSupervisorxAsesor(dropAsesores.SelectedValue);
        GridBitacoras.DataSource = datos;
        GridBitacoras.DataBind();
	  
	}
	
    public void obtenerGET()
    {
        lblEstrategia.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["e"]);
        lblMomento.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        lblSesion.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
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
        string script = @"<script type='text/javascript'>/*$('#tablabitacoras').hide(),*/$('#insertarbitacoras').show();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }
    protected void dropMunicipio_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddInstituciones(dropInstituciones, dropMunicipio.SelectedValue);
        string script = @"<script type='text/javascript'>/*$('#tablabitacoras').hide()*/,$('#insertarbitacoras').show();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }
    protected void dropInstituciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddSedes(dropSedes, dropInstituciones.SelectedValue);
        string script = @"<script type='text/javascript'>/*$('#tablabitacoras').hide()*/,$('#insertarbitacoras').show();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }
    protected void dropSedes_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddGruposInvestigacion(dropGrupoInvestigacion, dropSedes.SelectedValue);
        //ddGruposInvestigacion(dropGrupoInvestigacion, dropSedes.SelectedValue, Session["CodAsesorEstraCoordinador"].ToString());
        string script = @"<script type='text/javascript'>/*$('#tablabitacoras').hide(),*/$('#insertarbitacoras').show();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

    }
    protected void dropGrupoInvestigacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddLineaInvestigacion(dropLineaInvestigacion, dropGrupoInvestigacion.SelectedValue);
        gvcargarIntegrantesEstudiantes(dropGrupoInvestigacion.SelectedValue);

        string script = @"<script type='text/javascript'>/*$('#tablabitacoras').hide()*/,$('#insertarbitacoras').show();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);


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
    private void ddGruposInvestigacion(DropDownList drop, string codsede)
    {
        DataTable datos = ins.cargarGruposInvestigacionBitacorasSupervision(codsede);
        drop.DataSource = datos;
        drop.DataTextField = "nombregrupo";
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
            dropLineaInvestigacion.Items.Clear();
        }
    }
    private void ddLineaInvestigacion(DropDownList drop, string codgrupoInvestigacion)
    {
        DataTable datos = ins.cargarLineaInvestigacionxGrupo(codgrupoInvestigacion);
        drop.DataSource = datos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));

        if(datos != null && datos.Rows.Count > 0)
        {
            dropLineaInvestigacion.SelectedValue = datos.Rows[0]["codigo"].ToString();
            dropLineaInvestigacion.Enabled = false;

            gvcargarDocentesAcompañantes(datos.Rows[0]["codproyectosede"].ToString());
            gvcargarAsesoresxGrupoInvestigacion(datos.Rows[0]["codproyectosede"].ToString());

            btnAgregarEstudiante.Visible = false;
            btnAgregarDocente.Visible = false;
            btnagregarAsesor.Visible = false;

            GridEstudiante.Visible = true;
            GridDocentes.Visible = true;
            GridAsesor.Visible = true;

            string script = @"<script type='text/javascript'>/*$('#tablabitacoras').hide(),*/$('#insertarbitacoras').show();
            </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

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
        gvcargarEstudiantesxGrupoInvestigacion(codgrupoinvestigacion);
        lblCodGrupoInvestigacion.Text = codgrupoinvestigacion;
    }
   
    private void gvcargarDocentesAcompañantes(string codproyectosede)
    {
        GridDocentes.DataSource = estu.cargarDocentesxGrupoInvestigacion(codproyectosede);
        GridDocentes.DataBind();
    }

    private void gvcargarAsesoresxGrupoInvestigacion(string codproyectosede)
    {
        GridAsesor.DataSource = estu.cargarAsesorxGrupoInvestigacion(codproyectosede);
        GridAsesor.DataBind();
    }

    protected void btnAgregarEstudiante_Click(object sender, EventArgs e)
    {
        PanelVerEstudiante.Visible = true;
        string script = @"<script type='text/javascript'>/*$('#tablabitacoras').hide()*/,$('#insertarbitacoras').show();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }
    protected void btnAgregarDocente_Click(object sender, EventArgs e)
    {
        PanelVerDocentes.Visible = true;
        gvCargarDocentesxSede(lblCodSede.Text);
        btnGuardarDocenteLineaInvestigacion.Visible = true;

        string script = @"<script type='text/javascript'>/*$('#tablabitacoras').hide(),*/$('#insertarbitacoras').show();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }

    protected void btnagregarAsesor_Click(object sender, EventArgs e)
    {
        PanelVerAsesores.Visible = true;
        gvCargarAsesorxEstrategia1("1");
        btnGuardarAsesorLineaInvestigacion.Visible = true;

        string script = @"<script type='text/javascript'>/*$('#tablabitacoras').hide(),*/$('#insertarbitacoras').show();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }

    protected void btnBuscarEstudiantesNew_Click(object sender, EventArgs e)
    {
        gvcargarEstudiantesBuscados();
        btnGuardarEstuLineaInvestigacion.Visible = true;

        string script = @"<script type='text/javascript'>$('#tablabitacoras').hide(),$('#insertarbitacoras').show();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }
    protected void DeleteEstudianteActivo_Click(object sender, ImageClickEventArgs e)
    {
       
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        string codproyectomatricula = GridEstudiante.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  

        if (estu.eliminarMatriculaEstudianteGrupoInvestigacion(codproyectomatricula)) { }
        gvcargarEstudiantesxGrupoInvestigacion(lblCodGrupoInvestigacion.Text);

        string script = @"<script type='text/javascript'>$('#tablabitacoras').hide(),$('#insertarbitacoras').show();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }
    protected void DeleteDocenteActivo_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        string codproyectodocente = GridDocentes.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  

        if (estu.eliminarMatriculaDocenteGrupoInvestigacion(codproyectodocente)) { }
        gvcargarDocentesAcompañantes(lblCodGrupoInvestigacion.Text);

        string script = @"<script type='text/javascript'>$('#tablabitacoras').hide(),$('#insertarbitacoras').show();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

    }
    protected void DeleteAsesorActivo_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        string codproyectosede = GridAsesor.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  

        if (estu.eliminarMatriculaAsesorGrupoInvestigacion(codproyectosede)) { }
        gvCargarAsesorxEstrategia1("1");
        gvcargarAsesoresxGrupoInvestigacion(lblCodGrupoInvestigacion.Text);

        string script = @"<script type='text/javascript'>$('#tablabitacoras').hide(),$('#insertarbitacoras').show();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

    }
    private void gvcargarEstudiantesBuscados()
    {
        GridEstudiantesBuscados.DataSource = estu.cargarEstudiantexSedexGrado(dropSedes.SelectedValue, dropGrados.SelectedValue, "1", dropAnio.SelectedValue,"");
        GridEstudiantesBuscados.DataBind();
    }

    private void gvcargarEstudiantesxGrupoInvestigacion(string codgrupoinvestigacion)
    {
        DataTable estudiantes = estu.cargarEstudiantesxGrupoInvestigacion(codgrupoinvestigacion);
        GridEstudiante.DataSource = estudiantes;
        GridEstudiante.DataBind();

        if (estudiantes != null && estudiantes.Rows.Count > 0)
        {
            dropAnio.SelectedValue = estudiantes.Rows[0]["codanio"].ToString();
            dropAnio.Enabled = false;
        }

    }

    private void gvCargarDocentesxSede(string codsede)
    {
        DataTable docentes = doc.cargarDocentesxSede(codsede, dropAnio.SelectedValue);
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
                DataRow redtematicamatricula = estu.agregarEstudiantexGrupoInvestigacion(lblCodGrupoInvestigacion.Text, codestumatricula);
                    if (redtematicamatricula != null)
                    {
                       val++;
                    }
             
            }
        }

        if(val == 0)
        {
            string script = @"<script type='text/javascript'>
                                $('#tablabitacoras').hide(),$('#insertarbitacoras').show();
                                alert('Seleccione los estudiantes que van a pertenecer a Grupo de Investigación');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);  
        }
        else
        {
            string script = @"<script type='text/javascript'>
                                 $('#tablabitacoras').hide(),$('#insertarbitacoras').show();
                                alert('Datos ingresado correctamente.');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            gvcargarEstudiantesxGrupoInvestigacion(lblCodGrupoInvestigacion.Text);

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
                if (estu.agregarDocentexGrupoInvestigacion(codgradodocente, lblCodGrupoInvestigacion.Text))
                {
                    valDoc++;
                }
            }
           
        }

        if (valDoc == 0)
        {
            string script = @"<script type='text/javascript'>
                                 $('#tablabitacoras').hide(),$('#insertarbitacoras').show();
                                alert('Seleccione los Docentes que van a pertenecer al Grupo de Investigación');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
        else
        {
 
            string script = @"<script type='text/javascript'>
                                $('#tablabitacoras').hide(),$('#insertarbitacoras').show();
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
                if (estu.agregarMatriculaAsesorGrupoInvestigacion(codasesorcoordinador, lblCodGrupoInvestigacion.Text))
                {
                    valDoc++;
                }
            }

        }

        if (valDoc == 0)
        {
            string script = @"<script type='text/javascript'>
                                 $('#tablabitacoras').hide(),$('#insertarbitacoras').show();
                                alert('Seleccione el Asesor que van a pertenecer al Grupo de Investigación');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
        else
        {
            string script = @"<script type='text/javascript'>
                                 $('#tablabitacoras').hide(),$('#insertarbitacoras').show();
                                alert('Datos ingresado correctamente.');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            gvCargarAsesorxEstrategia1("1");
            gvcargarAsesoresxGrupoInvestigacion(lblCodGrupoInvestigacion.Text);

        }
       
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        if (est.agregarBitacora1Estrategia1(dropGrupoInvestigacion.SelectedValue, txtRelato.Text, fun.getFechaAñoHoraActual(), Session["CodAsesorEstraCoordinador"].ToString(), lblEstrategia.Text, lblMomento.Text, lblSesion.Text))
        {
            dropSedes.Items.Clear();
            dropGrados.Items.Clear();
            dropGrupoInvestigacion.Items.Clear();
            dropLineaInvestigacion.Items.Clear();
            dropInstituciones.SelectedIndex = 0;
            PanelVerEstudiante.Visible = false;
            PanelVerDocentes.Visible = false;
            PanelVerAsesores.Visible = false;
            GridEstudiante.Visible = false;
            GridDocentes.Visible = false;
            GridAsesor.Visible = false;
            btnAgregarEstudiante.Visible = false;
            btnAgregarDocente.Visible = false;
            btnagregarAsesor.Visible = false;
            txtRelato.Text = "";

            gvcargarbitacoraunoxAsesor(Session["CodAsesorEstraCoordinador"].ToString());


            string script = @"<script type='text/javascript'>
                                 $('#tablabitacoras').show(),$('#insertarbitacoras').hide();
                                alert('Guardado');
                        </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            //lnkVerGruposInvestigacion.Visible = true;
            lnkVolver.Visible = false;
           
        }
        else
        {
            string script = @"<script type='text/javascript'>
                                 $('#tablabitacoras').hide(),$('#insertarbitacoras').show();
                                alert('Error al Guardar.');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

      
    }

    protected void lknEditar_Click(object sender, EventArgs e)
    {

        LinkButton btndetails = sender as LinkButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        string codbitacora = GridBitacoras.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        lblCodGrupoInvestigacion.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);;

        DataRow dat = est.buscarDatoBitacorauno(codbitacora);

        if(dat != null)
        {
            string script = @"<script type='text/javascript'>
                                 $('#tablabitacoras').hide(),$('#insertarbitacoras').fadeIn(500);
                        </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            txtRelato.Text = dat["relato"].ToString();
            btnGuardar.Visible = false;
            btnEditar.Visible = false;
            lblCodBitacora.Text = codbitacora;
           
            //lnkVerGruposInvestigacion.Visible = false;
            lnkVolver.Visible = true;

            dropDepartamento.SelectedValue = dat["coddepartamento"].ToString();
            dropDepartamento.Enabled = false;
            dropDepartamento_SelectedIndexChanged(null, null);

            dropMunicipio.SelectedValue = dat["codmunicipio"].ToString();
            dropMunicipio.Enabled = false;
            dropMunicipio_SelectedIndexChanged(null, null);

            dropInstituciones.SelectedValue = dat["codinstitucion"].ToString();
            dropInstituciones.Enabled = false;
            dropInstituciones_SelectedIndexChanged(null, null);

            dropSedes.SelectedValue = dat["codsede"].ToString();
            dropSedes.Enabled = false;
            dropSedes_SelectedIndexChanged(null, null);

            dropGrupoInvestigacion.SelectedValue = dat["codproyectosede"].ToString();
            dropGrupoInvestigacion.Enabled = false;
            dropGrupoInvestigacion_SelectedIndexChanged(null, null);

            dropLineaInvestigacion.SelectedValue = dat["codlineainvestigacion"].ToString();
            dropLineaInvestigacion.Enabled = false;

            gvcargarEstudiantesxGrupoInvestigacion(lblCodGrupoInvestigacion.Text);
            gvcargarDocentesAcompañantes(lblCodGrupoInvestigacion.Text);
            gvcargarAsesoresxGrupoInvestigacion(lblCodGrupoInvestigacion.Text);

            

           
        }

        

    }

    protected void lknEvidencias_Click(object sender, EventArgs e)
    {

        LinkButton btndetails = sender as LinkButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        string codbitacora = GridBitacoras.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        lblCodGrupoInvestigacion.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text); ;
        Response.Redirect("estras002evidencias.aspx?codestras002=" + lblCodGrupoInvestigacion.Text);
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        if (est.editarbitacorauno(lblCodBitacora.Text, txtRelato.Text))
        {
            string script = @"<script type='text/javascript'>
                                 $('#insertarbitacoras').hide(),$('#tablabitacoras').fadeIn(500);
                                alert('Datos editados correctamente.');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
    }

    protected void lnkVolver_Click(object sender, EventArgs e)
    {
        string script = @"<script type='text/javascript'>$('#insertarbitacoras').hide(),$('#tablabitacoras').fadeIn(500);
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        lnkVolver.Visible = false;
        //lnkVerGruposInvestigacion.Visible = true;

        dropDepartamento.SelectedIndex = 0;
        dropSedes.Items.Clear();
        dropGrados.Items.Clear();
        dropGrupoInvestigacion.Items.Clear();
        dropLineaInvestigacion.Items.Clear();
        dropInstituciones.Items.Clear();
        PanelVerEstudiante.Visible = false;
        PanelVerDocentes.Visible = false;
        PanelVerAsesores.Visible = false;
        GridEstudiante.Visible = false;
        GridDocentes.Visible = false;
        GridAsesor.Visible = false;
        btnAgregarEstudiante.Visible = false;
        btnAgregarDocente.Visible = false;
        btnagregarAsesor.Visible = false;
        txtRelato.Text = "";
    }

    protected void lnkVerGruposInvestigacion_Click(object sender, EventArgs e)
    {
        string script = @"<script type='text/javascript'>/*$('#tablabitacoras').hide()*/,$('#insertarbitacoras').fadeIn(500);
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        lnkVolver.Visible = true;
        //lnkVerGruposInvestigacion.Visible = false;

      
       
       
        PanelVerEstudiante.Visible = false;
        PanelVerDocentes.Visible = false;
        PanelVerAsesores.Visible = false;
        GridEstudiante.Visible = false;
        GridDocentes.Visible = false;
        GridAsesor.Visible = false;
        btnAgregarEstudiante.Visible = false;
        btnAgregarDocente.Visible = false;
        btnagregarAsesor.Visible = false;
        txtRelato.Text = "";

        dropDepartamento.Enabled = true;
        dropMunicipio.Enabled = true;
        dropInstituciones.Enabled = true;
        dropSedes.Enabled = true;
        dropGrupoInvestigacion.Enabled = true;
        dropLineaInvestigacion.Enabled = true;

        dropMunicipio.Items.Clear();
        dropInstituciones.Items.Clear();
        dropSedes.Items.Clear();
        dropGrupoInvestigacion.Items.Clear();
        dropLineaInvestigacion.Items.Clear();

    }
    
}