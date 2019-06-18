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



public partial class confiredtematicaeditar : System.Web.UI.Page
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
           
            if (Session["codredtematica"] != null)
            {
                ddAnio(dropAnio);
                //if (Session["realizado"].ToString() == "OK")
                //{
                    //lblRealizado.Visible = true;
                    //lblRealizado.Text = "Red Temática creada con éxito";
                    DataRow dat = est.buscarRedTematicaxCod(Session["codredtematica"].ToString());

                    if (dat != null)
                    {
                        ddDepartamentos(dropDepartamento);
                        ddMunicipios(dropMunicipio);
                        ddInstituciones(dropInstituciones);
                        //ddSedes(dropSedes);
                        ddRedTematica(dropRedTematica);

                        dropDepartamento.SelectedValue = dat["coddepartamento"].ToString();
                        dropMunicipio.SelectedValue = dat["codmunicipio"].ToString();
                        dropInstituciones.SelectedValue = dat["codinstitucion"].ToString();
                        dropSedes.SelectedValue = dat["codsede"].ToString();

                        dropInstituciones_SelectedIndexChanged(null, null);

                        dropRedTematica.SelectedValue = dat["codredtematicasede"].ToString();
                       

                        lblCodProyectoSede.Text = dat["codredtematicasede"].ToString();
                        lblCodSede.Text = dat["codsede"].ToString();
                        lblCodGrupoInvestigacion.Text = Session["codredtematica"].ToString();

                        gvcargarEstudiantesxRedTematica(lblCodProyectoSede.Text);
                        gvcargarDocentesAcompañantes(lblCodProyectoSede.Text);
                        gvcargarAsesoresxRedTematica(lblCodProyectoSede.Text);

                        btnAgregarEstudiante.Visible = true;
                        btnAgregarDocente.Visible = true;
                        btnagregarAsesor.Visible = true;

                        GridEstudiante.Visible = true;
                        GridDocentes.Visible = true;
                        GridAsesor.Visible = true;
                    }
            
                    buscarUsuario();

                    dropDepartamento.Enabled = false;
                    dropMunicipio.Enabled = false;
                    dropInstituciones.Enabled = false;
                    //dropSedes.Enabled = false;
                    dropRedTematica.Enabled = false;
                    //dropAnio.Enabled = false;

            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Error al crear o ver Red Temática";
            }

        }
    }
    protected void dropInstituciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddSedes(dropSedes, dropInstituciones.SelectedValue);

        string script = @"<script type='text/javascript'>$('#ver').show();$('#agregar').hide();$('#mover').hide();</script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }
    private void ddAnio(DropDownList drop)
    {
        drop.DataSource = ins.cargarAnios();
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
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
    private void ddInstituciones(DropDownList drop)
    {
        drop.DataSource = ins.cargarTodasInstituciones();
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
    protected void dropMunicipio_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddInstituciones(dropInstituciones, dropMunicipio.SelectedValue);

        string script = @"<script type='text/javascript'>$('#ver').show();$('#agregar').hide();$('#mover').hide();</script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }
    private void ddInstituciones(DropDownList drop, string codmunicipio)
    {
        drop.DataSource = ins.cargarInstitucionxMunicipio(codmunicipio);
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddMunicipios(DropDownList drop)
    {
  
        drop.DataSource = ins.cargarTodasSedes();
        drop.DataSource = ins.cargarciudad();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    
 
    private void ddSedes(DropDownList drop)
    {
  
        DataTable datos = ins.cargarTodasSedes();
        drop.DataSource = datos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));

       
    }

    private void ddSedes(DropDownList drop, string codinstitucion)
    {
        drop.DataSource = ins.cargarSedesInstitucion(codinstitucion);
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddRedTematica(DropDownList drop)
    {
        DataTable datos = ins.cargarTodoRedTematicayGrupo();
        drop.DataSource = datos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "codredtematicasede";
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

    private void gvcargarIntegrantesEstudiantes(string codredtematica)
    {
        gvcargarEstudiantesxRedTematica(codredtematica);
        lblCodGrupoInvestigacion.Text = codredtematica;
    }

    private void gvcargarDocentesAcompañantes(string codredtematicaosede)
    {
        DataTable datos = estu.cargarDocentesxRedTematica(codredtematicaosede);
        GridDocentes.DataSource = datos;
        GridDocentes.DataBind();

        //if (datos != null && datos.Rows.Count > 0)
        //{
        //    dropAnio.SelectedValue = datos.Rows[0]["codanio"].ToString();
        //}
    }

    private void gvcargarAsesoresxRedTematica(string codredtematicasede)
    {
        GridAsesor.DataSource = estu.cargarAsesorxRedTematica(codredtematicasede);
        GridAsesor.DataBind();
    }

    protected void btnAgregarEstudiante_Click(object sender, EventArgs e)
    {
        PanelVerEstudiante.Visible = true;
        ddGrados(dropGrados);
        if (dropAnio.SelectedValue == "1")
        {
            dropGrupo.Enabled = false;
            dropAnio.SelectedIndex = 0;
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
        string codestumatricula = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

        if (estu.eliminarMatriculaEstudianteRedTematica(codestumatricula)) { }
        gvcargarEstudiantesxRedTematica(lblCodGrupoInvestigacion.Text);
    }
    protected void DeleteDocenteActivo_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        string codredtematicadocente = GridDocentes.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string codgradodocente = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

        if (estu.eliminarMatriculaDocenteRedTematica(codgradodocente)) { }
        gvcargarDocentesAcompañantes(lblCodGrupoInvestigacion.Text);

    }
    protected void DeleteAsesorActivo_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        string codproyectosede = GridAsesor.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  

        if (estu.eliminarMatriculaAsesorRedTematica(codproyectosede)) { }
        gvCargarAsesorxEstrategia1("4");
        gvcargarAsesoresxRedTematica(lblCodGrupoInvestigacion.Text);

    }
    private void gvcargarEstudiantesBuscados()
    {
        if (dropAnio.SelectedValue != "1")
        {
            GridEstudiantesBuscados.DataSource = estu.cargarEstudiantexSedexGrado(dropSedes.SelectedValue, dropGrados.SelectedValue, "2", dropAnio.SelectedValue, dropGrupo.SelectedValue);
            GridEstudiantesBuscados.DataBind();
        }
        else//Año 2016 sin grupo para los estudiantes
        {
            GridEstudiantesBuscados.DataSource = estu.cargarEstudiantexSedexGradoSinGrupo(dropSedes.SelectedValue, dropGrados.SelectedValue, "2", dropAnio.SelectedValue);
            GridEstudiantesBuscados.DataBind();
        }
        
    }

    private void gvcargarEstudiantesxRedTematica(string codredtematicasede)
    {
        DataTable datos = estu.cargarEstudiantesxRedTematica(codredtematicasede);
        GridEstudiante.DataSource = datos;
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
                                $('#ver').show();$('#agregar').hide();$('#mover').hide();
                                alert('Seleccione los estudiantes que van a pertenecer a Red Temática');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            lnkAgregarNuevoEstudiante.Visible = true;
            lnkVolverAlEditar.Visible = false;

        }
        else
        {
            string script = @"<script type='text/javascript'>
                                alert('Datos ingresado correctamente.');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            gvcargarEstudiantesxRedTematica(lblCodGrupoInvestigacion.Text);
            lnkAgregarNuevoEstudiante.Visible = true;
            lnkVolverAlEditar.Visible = false;

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
                            $('#ver').show();$('#agregar').hide();$('#mover').hide();
                                alert('Seleccione los Docentes que van a pertenecer al Grupo de Investigación');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            lnkAgregarNuevoEstudiante.Visible = true;
            lnkVolverAlEditar.Visible = false;

        }
        else
        {
            string script = @"<script type='text/javascript'>
                                alert('Datos ingresado correctamente.');
                        </script>";
            lnkAgregarNuevoEstudiante.Visible = true;
            lnkVolverAlEditar.Visible = false;

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
                                alert('Seleccione el Asesor que van a pertenecer al Grupo de Investigación');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            lnkAgregarNuevoEstudiante.Visible = true;
            lnkVolverAlEditar.Visible = false;
        }
        else
        {
            string script = @"<script type='text/javascript'>
                                alert('Datos ingresado correctamente.');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            lnkAgregarNuevoEstudiante.Visible = true;
            lnkVolverAlEditar.Visible = false;
            gvCargarAsesorxEstrategia1("4");
            gvcargarAsesoresxRedTematica(lblCodGrupoInvestigacion.Text);
            
        }
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Session["codredtematica"] = null;
        dropSedes.Items.Clear();
        dropGrados.Items.Clear();
        dropRedTematica.Items.Clear();
      
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
        Response.Redirect("confiredtematica.aspx");
    }

    protected void lnkAgregarNuevoEstudiante_Click(object sender, EventArgs e)
    {
        if(dropGrados.SelectedIndex > 0)
        {
            string script = @"<script type='text/javascript'>
                              $('#ver').hide();$('#agregar').fadeIn(500);$('#mover').hide();
                        </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            lnkAgregarNuevoEstudiante.Visible = false;
            lnkVolverAlEditar.Visible = true;
        }
        else
        {
            string script = @"<script type='text/javascript'>
                                alert('Error! Debe seleccionar el grado del estudiante, diríjase a la opción - Agregar estudiante -');
                              $('#agregar').hide();$('#ver').show();$('#mover').hide();
                        </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

    }

    protected void lnkVolverAlEditar_Click(object sender, EventArgs e)
    {
        string script = @"<script type='text/javascript'>
                              $('#ver').fadeIn(500);$('#agregar').hide();
                        </script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

        lnkAgregarNuevoEstudiante.Visible = true;
        lnkVolverAlEditar.Visible = false;
    }

    protected void btnEntrar_click(object sender, EventArgs e)
    {
        Estudiantes estra = new Estudiantes();
        Funciones fun = new Funciones();
        Institucion ins = new Institucion();
        DataRow anio = ins.buscarAnioON();

            DataRow estudiante = estra.agregarEstudiantePG(txtNomEstudianteNuevo.Text, txtNomApellidoNuevo.Text, txtIDEstudianteNuevo.Text, dropSexo.SelectedValue, fun.convertFechaAño(txtFechaN.Text), txtTelefonoNuevo.Text, txtDireccionNuevo.Text, txtemailNuevo.Text, "1", "1");

            if (estudiante != null)
            {
                if (estra.agregarEstuMatricula(dropSedes.SelectedValue, estudiante["codigo"].ToString(), anio["codigo"].ToString(), fun.getFechaAñoHoraActual(), dropGrados.SelectedValue, "2", dropGrupo.SelectedValue))
                {
                    //ca += "true@";
                    txtNomEstudianteNuevo.Text = "";
                    txtNomApellidoNuevo.Text = ""; txtIDEstudianteNuevo.Text = ""; dropSexo.SelectedIndex = 0; txtFechaN.Text = ""; txtTelefonoNuevo.Text = ""; txtDireccionNuevo.Text = ""; txtemailNuevo.Text = "";
                    string script = @"<script type='text/javascript'>
                                 $('#agregar').hide();
                                $('#mover').hide();$('#ver').show();
                                alert('Datos ingresados correctamente.');
                        </script>";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    lnkVolverAlEditar.Visible = false;
                    lnkAgregarNuevoEstudiante.Visible = true;
                    gvcargarEstudiantesBuscados();
                }
                else
                {
                    string script = @"<script type='text/javascript'>
                                $('#agregar').show();
                                $('#ver').hide();$('#mover').hide();
                                alert('Error al matricular.');
                        </script>";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    lnkVolverAlEditar.Visible = true;
                    lnkAgregarNuevoEstudiante.Visible = false;
                }

            }
            else
            {
                if (estra.agregarEstuMatricula(dropSedes.SelectedValue, estudiante["codigo"].ToString(), anio["codigo"].ToString(), fun.getFechaAñoHoraActual(), dropGrados.SelectedValue, "2", dropGrupo.SelectedValue))
                {
                    //ca += "true@";
                    string script = @"<script type='text/javascript'>
                                 $('#agregar').hide();
                                $('#mover').hide();$('#ver').show();
                                alert('Datos ingresados correctamente.');
                        </script>";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                    gvcargarEstudiantesBuscados();
                }
                else
                {
                    string script = @"<script type='text/javascript'>
                                 $('#agregar').show();
                                $('#ver').hide();$('#mover').hide();
                                alert('Error al matricular.');
                        </script>";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
            }
      
    }
   
    protected void btnMoverDocente_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        string codgradodocente = GridDocentesBuscados.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string iddocente = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        string nomdocente = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);

        Session["codgradodocente"] = codgradodocente;

        ddSedes(dropSedeMover, dropInstituciones.SelectedValue);

        string script = @"<script type='text/javascript'> 
            $('#ver').hide();$('#agregar').hide();$('#mover').fadeIn(500);
            </script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

        lnkAgregarNuevoEstudiante.Visible = false;
        lnkVolverAlEditar.Visible = false;
        lnkVolverMoverDocente.Visible = true;
    }
    protected void lnkMoverDocente_Click(object sender, EventArgs e)
    {
        if (Session["codgradodocente"] != null)
        {
            
            if (doc.MoverDocenteDeSede(dropSedeMover.SelectedValue, Session["codgradodocente"].ToString(), dropAnio.SelectedValue))
            {
                string script = @"<script type='text/javascript'> 
                                            alert('Docente movido correctamente.');
                                            $('#agregar').hide();$('#ver').fadeIn(500);$('#mover').hide();
                            </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                lnkAgregarNuevoEstudiante.Visible = true;
                lnkVolverAlEditar.Visible = false;
                lnkVolverMoverDocente.Visible = false;
                gvCargarDocentesxSede(dropSedes.SelectedValue);
            }
            else
            {
                string script = @"<script type='text/javascript'> 
                                            alert('Docente movido correctamente.');
                                            $('#ver').hide();$('#agregar').hide();$('#mover').show();
                            </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                lnkAgregarNuevoEstudiante.Visible = false;
                lnkVolverAlEditar.Visible = false;
                lnkVolverMoverDocente.Visible = true;
            }
        }
        else
        {
            string script = @"<script type='text/javascript'> 
                            alert('No hay docente seleccionado.');
                               $('#ver').hide();$('#agregar').hide();$('#mover').show();
                </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            lnkAgregarNuevoEstudiante.Visible = false;
            lnkVolverAlEditar.Visible = false;
            lnkVolverMoverDocente.Visible = true;
        }
    }

    protected void lnkVolverMoverDocente_Click(object sender, EventArgs e)
    {
        string script = @"<script type='text/javascript'>
                   $('#ver').fadeIn(500);$('#agregar').hide();$('#mover').hide();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        lnkVolverMoverDocente.Visible = false;
        lnkAgregarNuevoEstudiante.Visible = true;
        lnkVolverAlEditar.Visible = true;
    }

    protected void btnEditarEstudiante_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        string codestumatricula = GridEstudiante.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string codestudiante = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        string idestudiante = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);

        if (idestudiante != "")
        {
            buscarDatosEstudiante(idestudiante);

            //btnnuevoEstudiante.Visible = false;
            //btnEntrar.Visible = false;
            //btnEditarDatosEstudiante.Visible = true;
            //lnkVolverEditarDatosEstudiante.Visible = true;
            //lnkVolver.Visible = false;

            lnkAgregarNuevoEstudiante.Visible = false;
            btnEntrar.Visible = false;
            btnEditarDatosEstudiante.Visible = true;
            lnkVolverAlEditar.Visible = true;


        }

        string script = @"<script type='text/javascript'> 
                $('#agregar').fadeIn(500);
                $('#ver').hide();$('#mover').hide();
            </script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }
    private void buscarDatosEstudiante(string idestudiante)
    {
        DataRow estudiante = estu.buscarEstudianteIngresado(idestudiante);

        if (estudiante != null)
        {
            lblIDEstudianteOld.Text = estudiante["identificacion"].ToString();
            txtNomEstudianteNuevo.Text = estudiante["nombre"].ToString();
            txtNomApellidoNuevo.Text = estudiante["apellido"].ToString();
            txtIDEstudianteNuevo.Text = estudiante["identificacion"].ToString();

            if (estudiante["sexo"].ToString() == "M" || estudiante["sexo"].ToString() == "F")
                dropSexo.SelectedValue = estudiante["sexo"].ToString();
            else
                dropSexo.SelectedIndex = 0;

            txtFechaN.Text = fun.convertFechaAño(estudiante["fecha_nacimiento"].ToString());
            txtTelefonoNuevo.Text = estudiante["telefono"].ToString();
            txtDireccionNuevo.Text = estudiante["direccion"].ToString();
            txtemailNuevo.Text = estudiante["email"].ToString();

        }

    }

    protected void btnEditarDatosEstudiante_Click(object sender, EventArgs e)
    {
        if (estu.ActualizarEstudiante(lblIDEstudianteOld.Text, txtIDEstudianteNuevo.Text, txtNomEstudianteNuevo.Text, txtNomApellidoNuevo.Text, fun.convertFechaAño(txtFechaN.Text), dropSexo.SelectedValue, txtTelefonoNuevo.Text, txtDireccionNuevo.Text, txtemailNuevo.Text))
        {
            string script = @"<script type='text/javascript'> 
                alert('Datos editados correctamente.');
                $('#agregar').hide();
                $('#mover').hide();$('#ver').fadeIn(500);
            </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            gvcargarEstudiantesxRedTematica(lblCodProyectoSede.Text);
            lnkAgregarNuevoEstudiante.Visible = true;
            lnkVolverAlEditar.Visible = false;
        }
        else
        {
            string script = @"<script type='text/javascript'> 
                alert('Error al editar.');
                $('#agregar').show();
                $('#ver').hide();$('#mover').hide();
            </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            lnkAgregarNuevoEstudiante.Visible = false;
            lnkVolverAlEditar.Visible = true;
        }
    }

    protected void chkAllAsignados_Click(object sender, EventArgs e)
    {
        CheckBox ChkBoxHeader = (CheckBox)GridEstudiantesBuscados.HeaderRow.FindControl("chkAllAsignados");
        foreach (GridViewRow row in GridEstudiantesBuscados.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkListEstudiante");
            if (ChkBoxHeader.Checked == true)
            {
                ChkBoxRows.Checked = true;
            }
            else
            {
                ChkBoxRows.Checked = false;
            }
        }
        string script = @"<script type='text/javascript'> $('#ver').show();$('#agregar').hide();$('#mover').hide();</script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }

    protected void lnkEditarRed_Click(object sender, EventArgs e)
    {
        if (est.editarRedTematicaxCodigo(dropRedTematica.SelectedValue, dropSedes.SelectedValue))
        {
            string script = @"<script type='text/javascript'>$('#ver').show();$('#agregar').hide();$('#mover').hide();alert('Editado correctamente.');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
        else
        {
            string script = @"<script type='text/javascript'>$('#ver').show();$('#agregar').hide();$('#mover').hide();alert('Error al editar.');</script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
    }
}