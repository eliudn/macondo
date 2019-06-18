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



public partial class configrupoinvestigacioneditar : System.Web.UI.Page
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
           
            if (Session["codgrupoinvestigacion"] != null)
            {

              
                    //lblRealizado.Visible = true;
                    //lblRealizado.Text = "Grupo de Investigación creado con éxito";
                    DataRow dat = est.buscarGrupoInvestigacionxCod(Session["codgrupoinvestigacion"].ToString());

                    if (dat != null)
                    {
                        ddAnio(dropAnio);
                        ddDepartamentos(dropDepartamento);
                        ddMunicipios(dropMunicipio, dat["coddepartamento"].ToString());
                        ddInstituciones(dropInstituciones, dat["codmunicipio"].ToString());
                        ddSedes(dropSedes, dat["codinstitucion"].ToString());
                        ddGruposInvestigacion(dropGrupoInvestigacion, dat["codsede"].ToString());
                        ddLineaInvestigacion(dropLineaInvestigacion);

                        dropDepartamento.SelectedValue = dat["coddepartamento"].ToString();
                        dropMunicipio.SelectedValue = dat["codmunicipio"].ToString();
                        dropInstituciones.SelectedValue = dat["codinstitucion"].ToString();
                        dropSedes.SelectedValue = dat["codsede"].ToString();
                        dropGrupoInvestigacion.SelectedValue = dat["codproyectosede"].ToString();
                        dropLineaInvestigacion.SelectedValue = dat["codlineainvestigacion"].ToString();

                        lblCodProyectoSede.Text = dat["codproyectosede"].ToString();
                        lblCodSede.Text = dat["codsede"].ToString();
                        lblCodGrupoInvestigacion.Text = Session["codgrupoinvestigacion"].ToString();

                        gvcargarEstudiantesxGrupoInvestigacion(lblCodProyectoSede.Text);
                        gvcargarDocentesAcompañantes(lblCodProyectoSede.Text);
                        gvcargarAsesoresxGrupoInvestigacion(lblCodProyectoSede.Text);

                        btnAgregarEstudiante.Visible = true;
                        btnAgregarDocente.Visible = true;
                        btnagregarAsesor.Visible = true;

                        GridEstudiante.Visible = true;
                        GridDocentes.Visible = true;
                        GridAsesor.Visible = true;

                        dropDepartamento.Enabled = false;
                        //dropMunicipio.Enabled = false;
                        //dropInstituciones.Enabled = false;
                        //dropSedes.Enabled = false;
                        //dropGrupoInvestigacion.Enabled = false;
                        //dropLineaInvestigacion.Enabled = false;
                        dropAnio.Enabled = false;
                        btnActualizar.Visible = true;
                    }
                    //else if (Session["realizado"].ToString() == "Sin_Docentes")
                    //{
                    //    lblRealizado.Visible = true;
                    //    lblRealizado.Text = "Estudiante ingresados correctamente, Grupo de Investigación sin Docente(s) acompañante(s).";


                    //    if (dat != null)
                    //    {
                    //        ddDepartamentos(dropDepartamento);
                    //        ddMunicipios(dropMunicipio);
                    //        ddInstituciones(dropInstituciones);
                    //        ddSedes(dropSedes);
                    //        ddGruposInvestigacion(dropGrupoInvestigacion);
                    //        ddLineaInvestigacion(dropLineaInvestigacion);

                    //        dropDepartamento.SelectedValue = dat["coddepartamento"].ToString();
                    //        dropMunicipio.SelectedValue = dat["codmunicipio"].ToString();
                    //        dropInstituciones.SelectedValue = dat["codinstitucion"].ToString();
                    //        dropSedes.SelectedValue = dat["codsede"].ToString();
                    //        dropGrupoInvestigacion.SelectedValue = dat["codproyectosede"].ToString();
                    //        dropLineaInvestigacion.SelectedValue = dat["codlineainvestigacion"].ToString();

                    //        lblCodProyectoSede.Text = dat["codproyectosede"].ToString();
                    //        lblCodSede.Text = dat["codsede"].ToString();
                    //        lblCodGrupoInvestigacion.Text = Session["codgrupoinvestigacion"].ToString();

                    //        gvcargarEstudiantesxGrupoInvestigacion(lblCodProyectoSede.Text);
                    //        gvcargarDocentesAcompañantes(lblCodProyectoSede.Text);
                    //        gvcargarAsesoresxGrupoInvestigacion(lblCodProyectoSede.Text);

                    //        btnAgregarEstudiante.Visible = true;
                    //        btnAgregarDocente.Visible = true;
                    //        btnagregarAsesor.Visible = true;

                    //        GridEstudiante.Visible = true;
                    //        GridDocentes.Visible = true;
                    //        GridAsesor.Visible = true;
                    //    }

                    //}


                    //buscarUsuario();

                    //dropDepartamento.Enabled = false;
                    //dropMunicipio.Enabled = false;
                    //dropInstituciones.Enabled = false;
                    //dropSedes.Enabled = false;
                    //dropGrupoInvestigacion.Enabled = false;
                    //dropLineaInvestigacion.Enabled = false;


              
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Error al crear o ver Grupo de Investigación";
            }

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
    private void ddInstituciones(DropDownList drop, string codminicipio)
    {
        drop.DataSource = ins.cargarInstitucionxMunicipio(codminicipio);
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
  
        //drop.DataSource = ins.cargarTodasSedes();
        drop.DataSource = ins.cargarciudadxDepartamento(coddepartamento);
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
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
        DataTable datos = ins.cargarGrupoInvestigacionxCodSede(codsede);
        drop.DataSource = datos;
        drop.DataTextField = "nombregrupo";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));

      
    }
    private void ddLineaInvestigacion(DropDownList drop)
    {
        DataTable datos = ins.cargarTodoLineaInvestigacion();
        drop.DataSource = datos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));

       

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
        DataTable datos = est.cargarDocentesxSedexGrupoInvestigacionUnimag(codproyectosede);
        GridDocentes.DataSource = datos;
        GridDocentes.DataBind();

        if (datos != null && datos.Rows.Count > 0)
        {
            dropAnio.SelectedValue = datos.Rows[0]["codanio"].ToString();
        }
    }

    private void gvcargarAsesoresxGrupoInvestigacion(string codproyectosede)
    {
        GridAsesor.DataSource = estu.cargarAsesorxGrupoInvestigacion(codproyectosede);
        GridAsesor.DataBind();
    }

    protected void btnAgregarEstudiante_Click(object sender, EventArgs e)
    {
        PanelVerEstudiante.Visible = true;
        ddGrados(dropGrados);
        if (dropAnio.SelectedValue == "1")
        {
            dropGrupo.Enabled = false;
        }
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
        gvCargarAsesorxEstrategia1("1");
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

        if (estu.eliminarMatriculaEstudianteGrupoInvestigacion(codproyectomatricula)) { }
        gvcargarEstudiantesxGrupoInvestigacion(lblCodGrupoInvestigacion.Text);
    }
    protected void DeleteDocenteActivo_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        string codproyectodocente = GridDocentes.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  

        if (estu.eliminarMatriculaDocenteGrupoInvestigacion(codproyectodocente)) { }
        gvcargarDocentesAcompañantes(lblCodGrupoInvestigacion.Text);

    }
    protected void DeleteAsesorActivo_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        string codproyectosede = GridAsesor.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  

        if (estu.eliminarMatriculaAsesorGrupoInvestigacion(codproyectosede)) { }
        gvCargarAsesorxEstrategia1("1");
        gvcargarAsesoresxGrupoInvestigacion(lblCodGrupoInvestigacion.Text);

    }
    private void gvcargarEstudiantesBuscados()
    {
        if (dropAnio.SelectedValue != "1")
        {
            GridEstudiantesBuscados.DataSource = estu.cargarEstudiantexSedexGrado(dropSedes.SelectedValue, dropGrados.SelectedValue, "1", dropAnio.SelectedValue, dropGrupo.SelectedValue);
            GridEstudiantesBuscados.DataBind();
        }
        else//Año 2016 sin grupo para los estudiantes
        {
            GridEstudiantesBuscados.DataSource = estu.cargarEstudiantexSedexGradoSinGrupo(dropSedes.SelectedValue, dropGrados.SelectedValue, "1", dropAnio.SelectedValue);
            GridEstudiantesBuscados.DataBind();
        }

        
    }

    private void gvcargarEstudiantesxGrupoInvestigacion(string codgrupoinvestigacion)
    {
        GridEstudiante.DataSource = estu.cargarEstudiantesxGrupoInvestigacion(codgrupoinvestigacion);
        GridEstudiante.DataBind();
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
                                alert('Seleccione los estudiantes que van a pertenecer a Grupo de Investigación');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);  
        }
        else
        {
            string script = @"<script type='text/javascript'>
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
                                alert('Seleccione los Docentes que van a pertenecer al Grupo de Investigación');
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
                if (estu.agregarMatriculaAsesorGrupoInvestigacion(codasesorcoordinador, lblCodGrupoInvestigacion.Text))
                {
                    valDoc++;
                }
            }

        }

        if (valDoc == 0)
        {
            string script = @"<script type='text/javascript'>
                                alert('Seleccione el Asesor que van a pertenecer al Grupo de Investigación');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
        else
        {
            string script = @"<script type='text/javascript'>
                                alert('Datos ingresado correctamente.');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            gvCargarAsesorxEstrategia1("1");
            gvcargarAsesoresxGrupoInvestigacion(lblCodGrupoInvestigacion.Text);
            
        }
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Session["codgrupoinvestigacion"] = null;
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
        Response.Redirect("configrupoinvestigacion.aspx");
    }

    protected void btnActualizar_Onclick(object sender, EventArgs e)
    {
        if (dropLineaInvestigacion.SelectedIndex != 0)
        {
            if (est.updateProyectoSede(dropGrupoInvestigacion.SelectedValue, dropLineaInvestigacion.SelectedValue, dropSedes.SelectedValue))
            {
                string script = @"<script type='text/javascript'>
                                alert('Actualizaco con éxito');
                        </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        else
        {
            string script = @"<script type='text/javascript'>
                                alert('Seleccione una Línea de investigación');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
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
        ddGruposInvestigacion(dropGrupoInvestigacion, dropSedes.SelectedValue);
    }

}