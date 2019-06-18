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



public partial class confiespaciodeapropiacioneditar : System.Web.UI.Page
{
    Funciones fun = new Funciones();
    Estrategias est = new Estrategias();
    Institucion ins = new Institucion();
    Estudiantes estu = new Estudiantes();
    Docentes doc = new Docentes();

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

            if (Session["codigo"] != null)
            {
                ddMunicipios(dropMunicipiosSedes, "20");
                    DataRow dat = est.buscarFeriaNacionalxcodigo(Session["codigo"].ToString());

                    if (dat != null)
                    {

                        ddDepartamentos(dropDepartamento);

                        dropDepartamento.SelectedValue = dat["coddepartamento"].ToString();
                        codigo.Text = dat["codigo"].ToString();


                        nombreferiamunicipal.Text = dat["nombreferiamunicipal"].ToString();
                        numeroasistentes.Text = dat["numeroasistentes"].ToString();
                        numerogrupos.Text = dat["numerogrupos"].ToString();
                        numerodocentes.Text = dat["numerodocentes"].ToString();
                        fechaelaboracion.Text = fun.convertFechaDia(dat["fechaelaboracion"].ToString());
                        horaferia.SelectedValue = dat["horaferia"].ToString();
                        horaferiafinal.SelectedValue = dat["horaferiafinal"].ToString();
                        fechaelaboracioncierre.Text = fun.convertFechaDia(dat["fechaelaboracioncierre"].ToString());
                        horaferiacierre.SelectedValue = dat["horaferiacierre"].ToString();
                        horaferiafinalcierre.SelectedValue = dat["horaferiafinalcierre"].ToString();

                        gvcargarMunicipiosxDepartamento(dropDepartamento.SelectedValue);
                        gvcargarMunicipiosFeriaMunicipal(Session["codigo"].ToString());
                        GridSeleccionMunicipios.Visible = true;
                        gvcargarGruposFeria(Session["codigo"].ToString());

                    }
            
                    //buscarUsuario();

                    dropDepartamento.Enabled = false;
                    dropMunicipio.Enabled = false;
                    dropInstituciones.Enabled = false;
                    dropSedes.Enabled = false;
                    dropRedTematica.Enabled = false;

            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Error al crear o ver Feria Nacional";
            }

        }
    }
   
    protected void BindGrid()
    {
        GridSeleccionMunicipios.DataSource = ((DataTable)Session["myDatatable"]).DefaultView;
        GridSeleccionMunicipios.DataBind();
    }

    protected void GridSeleccionMunicipios_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string item = e.Row.Cells[1].Text;
        foreach (ImageButton button in e.Row.Cells[4].Controls.OfType<ImageButton>())
        {
            if (button.CommandName == "Delete")
            {
                button.Attributes["onclick"] = "if(!confirm('¿Desea eliminar el Municipio con ID " + item + " de la lista?')){ return false; };";
            }
        }
    }
    protected void GridSeleccionMunicipios_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = Convert.ToInt32(e.RowIndex);
        DataTable dt = ((DataTable)Session["myDatatable"]);

        dt.Rows[index].Delete();
        ViewState["dt"] = dt;
        BindGrid();

        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }
    //Preparamos la tabla virtual para los grupos
    private DataTable CreateDataTableGrupos()
    {
        DataTable myDataTable = new DataTable();
        myDataTable.Columns.AddRange(new DataColumn[5] { new DataColumn("codgrupoinvestigacion"), new DataColumn("municipio"), new DataColumn("institucion"), new DataColumn("sede"), new DataColumn("grupos") });
        return myDataTable;
    }
    private void AddDataToTableGrupo(string codgrupoinvestigacion, string municipio, string institucion, string sede, string grupo, DataTable myTableGrupos)
    {
        myTableGrupos.Rows.Add(codgrupoinvestigacion, municipio, institucion, sede, grupo);
    }
    protected void BindGridGrupos()
    {
        GridSeleccionGrupos.DataSource = ((DataTable)Session["myDatatableGrupos"]).DefaultView;
        GridSeleccionGrupos.DataBind();
    }


    protected void GridSeleccionGrupos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string item = e.Row.Cells[3].Text;
        foreach (ImageButton button in e.Row.Cells[5].Controls.OfType<ImageButton>())
        {
            if (button.CommandName == "Delete")
            {
                button.Attributes["onclick"] = "if(!confirm('¿Desea eliminar la sede " + item + " de la lista?')){ return false; };";
            }
        }
    }

    protected void GridSeleccionGrupos_RowDeleting(object sender, EventArgs e)
    {
//        int index = Convert.ToInt32(e.RowIndex);
//        DataTable dt = ((DataTable)Session["myDatatableGrupos"]);

//        dt.Rows[index].Delete();
//        ViewState["dtGrupos"] = dt;
//        if (GridSeleccionGrupos.Rows.Count == 1)
//        {
//            ((DataTable)Session["myDatatableGrupos"]).Clear();
//        }
//        BindGridGrupos();

//        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();
//            </script>";

//        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
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
    
    private void ddDepartamentos(DropDownList drop)
    {
        drop.DataSource = ins.cargarDepartamentoMagdalena();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        //drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));

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
      
    }

    private void gvcargarDocentesAcompañantes(string codredtematicaosede)
    {
        
    }

    private void gvcargarAsesoresxRedTematica(string codredtematicasede)
    {
        
    }

   
    protected void DeleteEstudianteActivo_Click(object sender, ImageClickEventArgs e)
    {
       
       
    }
    protected void DeleteDocenteActivo_Click(object sender, ImageClickEventArgs e)
    {

       

    }
    protected void DeleteAsesorActivo_Click(object sender, ImageClickEventArgs e)
    {

    }
    private void gvcargarEstudiantesBuscados()
    {
      
    }

    private void gvcargarEstudiantesxRedTematica(string codredtematicasede)
    {
       
    }

    private void gvcargarMunicipiosxDepartamento(string coddepartamento)
    {
        GridMunicipio.DataSource = estu.cargarmunicipios(coddepartamento);
        GridMunicipio.DataBind();
    }

    private void gvcargarMunicipiosFeriaMunicipal(string codferiamunicipal)
    {
        GridSeleccionMunicipios.DataSource = estu.cargarmunicipiosmatriculados(codferiamunicipal);
        GridSeleccionMunicipios.DataBind();
    }

    private void gvcargarGruposFeria(string codferiamunicipal)
    {
        GridSeleccionGrupos.DataSource = ins.cargarGruposFeriaMunicipial(codferiamunicipal);
        GridSeleccionGrupos.DataBind();
    }

    private void gvCargarDocentesxSede(string codsede)
    {
        //DataTable docentes = doc.cargarDocentesxSede(codsede, dropAnio.SelectedValue);
        //GridDocentesBuscados.DataSource = docentes;
        //GridDocentesBuscados.DataBind();
    }

  
    protected void btnGuardarEstuLineaInvestigacion_Click(object sender, EventArgs e)
    {
        int val = 0;
        //foreach (GridViewRow row in GridEstudiantesBuscados.Rows)
        //{
        //    string codestumatricula = HttpUtility.HtmlDecode(row.Cells[1].Text);

        //     CheckBox dd = (row.FindControl("chkListEstudiante") as CheckBox);
        //    bool rb = dd.Checked;
        //    if (rb == true)
        //    {
        //        DataRow redtematicamatricula = estu.agregarEstudiantexRedTematica(lblCodGrupoInvestigacion.Text, codestumatricula);
        //            if (redtematicamatricula != null)
        //            {
        //               val++;
        //            }
             
        //    }
        //}

        if(val == 0)
        {
            string script = @"<script type='text/javascript'>
                                $('#ver').show();$('#agregar').hide();$('#mover').hide();
                                alert('Seleccione los estudiantes que van a pertenecer a Grupo de Investigación');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            //lnkAgregarNuevoEstudiante.Visible = true;
        

        }
        else
        {
            string script = @"<script type='text/javascript'>
                                alert('Datos ingresado correctamente.');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            //gvcargarEstudiantesxRedTematica(lblCodGrupoInvestigacion.Text);
            //lnkAgregarNuevoEstudiante.Visible = true;
           

        }
        
    }

   
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Session["codigo"] = null;
        
    
        Response.Redirect("confiespaciodeapropiacionnac.aspx");
    }

   

   
    protected void chkseleccionartodo_Click(object sender, EventArgs e)
    {
        CheckBox ChkBoxHeader = (CheckBox)GridMunicipio.HeaderRow.FindControl("chkseleccionartodo");
        foreach (GridViewRow row in GridMunicipio.Rows)
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
        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();
                    </script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }


    protected void btnSeleccionarEstudiantes_Click(object sender, EventArgs e)
    {
        int val = 0;
        foreach (GridViewRow row in GridMunicipio.Rows)
        {
            string coddepartamento = GridMunicipio.DataKeys[row.RowIndex].Value.ToString(); //Obtener del DataKey de la Row
            string cod = GridMunicipio.Rows[row.RowIndex].Cells[2].Text;
            string tipo = GridMunicipio.Rows[row.RowIndex].Cells[3].Text;
            string nombre = GridMunicipio.Rows[row.RowIndex].Cells[4].Text;
            CheckBox dd = (row.FindControl("chkListEstudiante") as CheckBox);
            bool rb = dd.Checked;
            if (rb == true)
            {
                est.actualizarMunicipiosxFeriaMunicipal(Session["codigo"].ToString(), cod);
                val++;
            }
        }

        if (val == 0)
        {
            string script = @"<script type='text/javascript'>
                                alert('Seleccione los Municipios donde se realizaron las Ferias Municipales');
                                $('#VerRed').hide(),$('#CrearRed').show();
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
        else
        {
            gvcargarMunicipiosFeriaMunicipal(Session["codigo"].ToString()); 
            btnAgregarEstudiantes.Visible = true;
            //btnDeseleccionarEstudiantes.Visible = true;

            string script = @"<script type='text/javascript'>
                                $('#VerRed').hide(),$('#CrearRed').show();
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            gvcargarMunicipiosFeriaMunicipal(Session["codigo"].ToString());
        }

    }

    protected void btnAgregarEstudiantes_Click(object sender, EventArgs e)
    {

        int val = 0;
        int val2 = 0;

        bool feriam = est.actualizarFeriaNacional(dropDepartamento.SelectedValue, nombreferiamunicipal.Text, numeroasistentes.Text, numerogrupos.Text, numerodocentes.Text, fechaelaboracion.Text, horaferia.SelectedValue, horaferiafinal.SelectedValue, fechaelaboracioncierre.Text, horaferiacierre.SelectedValue, horaferiafinalcierre.SelectedValue, Session["codigo"].ToString());

        string script = @"<script type='text/javascript'>$('#CrearRed').hide(),$('#VerRed').fadeIn(500),alert('Feria Nacional actualizada exitosamente.');
                     </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        btnAgregarEstudiantes.Visible = false;

        //if (feriam != null)
        //{
        //    Session["cod"] = feriam.ToString();
        //    est.eliminarMunicipiosFeriaMunicipalxFeria(Session["codigo"].ToString());


        //    foreach (GridViewRow row in GridSeleccionMunicipios.Rows)
        //    {
        //        string codmunicipiomatricula = HttpUtility.HtmlDecode(row.Cells[1].Text);
        //        DataRow feriamunicipalmatricula = estu.agregarMunicipioxFeriaMunicipal(Session["codigo"].ToString(), codmunicipiomatricula);
        //        if (feriamunicipalmatricula != null)
        //        {
        //            val++;
        //        }
        //    }

        //    est.eliminarGruposFeriaMunicipalxFeria(Session["codigo"].ToString());

        //    //Relacionar los grupos
        //    foreach (GridViewRow row2 in GridSeleccionGrupos.Rows)
        //    {
        //        string codgrupo = HttpUtility.HtmlDecode(row2.Cells[0].Text);
        //        DataRow feriagrupomatricula = ins.agregarGruposxFeriaMunicipal(Session["codigo"].ToString(), codgrupo);
        //        if (feriagrupomatricula != null)
        //        {
        //            val2++;
        //        }
        //    }

            
        //}

//        if (val > 0 && val2 > 0)
//        {
//            GridMunicipio.Visible = false;
          
//            btnSeleccionarEstudiantes.Visible = false;

//            btnAgregarEstudiantes.Visible = false;
//            //btnAgregarEstudiantes.Enabled = true;


//            ((DataTable)Session["myDatatable"]).Clear();
//            BindGrid();

//            ((DataTable)Session["myDatatableGrupos"]).Clear();
//            BindGrid();

//            string script = @"<script type='text/javascript'>$('#CrearRed').hide(),$('#VerRed').fadeIn(500), alert('Feria Municipal Actualizada exitosamente');
//                     </script>";

//            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
//            btnAgregarEstudiantes.Visible = false;
       

//            Response.Redirect("confiespaciodeapropiacion.aspx");

//            //Session["realizado"] = "OK";


//        }
//        else if (val > 0 && val2 == 0){

//            string script = @"<script type='text/javascript'>$('#CrearRed').hide(),$('#VerRed').fadeIn(500),alert('Feria Municipal actualizada exitosamente, pero no se agregaron grupos de investagación');
//                     </script>";

//            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
//            btnAgregarEstudiantes.Visible = false;

//            ((DataTable)Session["myDatatable"]).Clear();
//            BindGrid();

//            ((DataTable)Session["myDatatableGrupos"]).Clear();
//            BindGrid();

//            Response.Redirect("confiespaciodeapropiacion.aspx");
//        }
//        else if (val == 0 && val2 > 0)
//        {
//            string script = @"<script type='text/javascript'>$('#CrearRed').hide(),$('#VerRed').fadeIn(500),alert('Feria Municipal actualizada exitosamente, pero no se agregaron los municipios');
//                     </script>";

//            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

//            ((DataTable)Session["myDatatable"]).Clear();
//            BindGrid();

//            ((DataTable)Session["myDatatableGrupos"]).Clear();
//            BindGrid();

//            Response.Redirect("confiespaciodeapropiacion.aspx");
//        }
//        else
//        {
//            string script = @"<script type='text/javascript'>
//                                alert('Error al Actualizar Feria Municipal.');
//                                $('#VerRed').hide(),$('#CrearRed').show();
//                        </script>";

//            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
//        }
       
    }

    protected void lnkEliminarMunicipioFeriaMunicipal_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        //string codigo = GridSeleccionMunicipios.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string cod = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);


        est.eliminarMunicipioFeriaMunicipal(cod, Session["codigo"].ToString());
            
               
                string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();alert('Municipio eliminado correctamente.');
                    </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

       gvcargarMunicipiosFeriaMunicipal(Session["codigo"].ToString());

    }

    private void ddInstituciones(DropDownList drop, string codmunicipio)
    {
        drop.DataSource = ins.cargarInstitucionxMunicipio(codmunicipio);
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
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

        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }
    protected void dropMunicipio_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddInstituciones(dropInstitucionesGrupos, dropMunicipiosSedes.SelectedValue);

        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }
    protected void dropInstituciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddSedes(dropSedesGrupos, dropInstitucionesGrupos.SelectedValue);

        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }

    protected void lnkBuscarGrupos_Click(object sender, EventArgs e)
    {

        DataTable datos = ins.cargarInfoGruposInvestigacionxCodSede(dropSedesGrupos.SelectedValue);
        GridGrupos.DataSource = datos;
        GridGrupos.DataBind();
        lnkAgregarGrupo.Visible = true;

        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }

    protected void chkseleccionartodogrupo_Click(object sender, EventArgs e)
    {
        CheckBox ChkBoxHeader = (CheckBox)GridGrupos.HeaderRow.FindControl("chkseleccionartodogrupo");
        foreach (GridViewRow row in GridGrupos.Rows)
        {
            CheckBox ChkBoxRows = (CheckBox)row.FindControl("chkListGrupo");
            if (ChkBoxHeader.Checked == true)
            {
                ChkBoxRows.Checked = true;
            }
            else
            {
                ChkBoxRows.Checked = false;
            }
        }
        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();
                    </script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }

    protected void lnkAgregarGrupo_Click(object sender, EventArgs e)
    {
        int val = 0;
        int elegido = 0;
        foreach (GridViewRow row in GridGrupos.Rows)
        {
            string codproyectosede = GridGrupos.DataKeys[row.RowIndex].Value.ToString(); //Obtener del DataKey de la Row
            CheckBox dd = (row.FindControl("chkListGrupo") as CheckBox);
            bool rb = dd.Checked;
            if (rb == true)
            {
                DataRow dato = est.buscarProyectoSedexFeriaMunicipal(codproyectosede, Session["codigo"].ToString());
                if (dato == null)
                {
                    DataRow feriagrupomatricula = ins.agregarGruposxFeriaMunicipal(Session["codigo"].ToString(), codproyectosede);
                    if (feriagrupomatricula != null)
                    {
                        val++;
                    }
                }
                else
                {
                    elegido++;
                }
                //AddDataToTableGrupo(codigo, municipio, institucion, sede, grupo, (DataTable)Session["myDatatableGrupos"]);
               
            }
        }

        if (val == 0 && elegido == 0)
        {
            string script = @"<script type='text/javascript'>
                                alert('Seleccione los grupos participantes');
                                $('#VerRed').hide(),$('#CrearRed').show();
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
        else if (val == 0 && elegido > 0)
        {
            string script = @"<script type='text/javascript'>
                                alert('Seleccione los grupos participantes y/o ya existen grupos cargados');
                                $('#VerRed').hide(),$('#CrearRed').show();
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
        else
        {
            gvcargarGruposFeria(Session["codigo"].ToString());
            //PanelNomRedtematica.Visible = true;
            //ddRedTematica(dropFeriaMunicipal);
            btnAgregarEstudiantes.Visible = true;
            //btnDeseleccionarEstudiantes.Visible = true;

            string script = @"<script type='text/javascript'>
                                $('#VerRed').hide(),$('#CrearRed').show();
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

    }

    protected void DeleteGrupo_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        string codproyectodocente = GridSeleccionGrupos.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  

        if (est.eliminarGruposFeriaMunicipalxGrupoxFeria(codproyectodocente, Session["codigo"].ToString())) { }
        gvcargarGruposFeria(Session["codigo"].ToString());

    }

}