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

public partial class configrupoinvestigacion : System.Web.UI.Page
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
            ddAnio(dropAnio);
            //DataRow dato = estr.buscarCodEstraAsesorxCoordinador(Session["identificacion"].ToString());

            //if (dato != null)
            //{
            //    Session["CodAsesorEstraCoordinador"] = dato["codigo"].ToString();

            //}

            if(Session["identificacion"] != null)
            {
                DataRow dat = ase.buscarAsesorxEstrategiaxIdentificacion(Session["identificacion"].ToString());

                if (dat != null)
                {
                    Session["codasesorestrategia"] = dat["codasesorcoordinador"].ToString();
                }

                lblTipoUsuario.Text = Session["codrol"].ToString();
                ddGrados(DropGrados);
                if (lblTipoUsuario.Text == "11" || lblTipoUsuario.Text == "9" )
                {
                    ddDepartamentos(dropDepartamento);
                    //ddInstituciones(dropInstituciones);



                    DataTable dt = new DataTable();
                    dt = CreateDataTable();
                    Session["myDatatableGI"] = dt;
                    ViewState["dt"] = dt;
                    this.GridSeleccionEstudiantes.DataSource = ((DataTable)Session["myDatatableGI"]).DefaultView;
                    this.GridSeleccionEstudiantes.DataBind();

                    DataTable dtDoc = new DataTable();
                    dtDoc = CreateDataTableDoc();
                    Session["myDatatableDocGI"] = dtDoc;
                    ViewState["dtDoc"] = dtDoc;
                    this.GridSeleccionDocentes.DataSource = ((DataTable)Session["myDatatableDocGI"]).DefaultView;
                    this.GridSeleccionDocentes.DataBind();


                    cargarGruposxAsesor();
                }
                else
                {
                    Response.Redirect("bienvenida.aspx");
                }
            }
            else
            {
                Response.Redirect("bienvenida.aspx");
            }

            
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
    //Preparamos la tabla virtual para los estudiantes 
    private DataTable CreateDataTable()
    {
        DataTable myDataTable = new DataTable();
        myDataTable.Columns.AddRange(new DataColumn[4] { new DataColumn("codestumatricula"), new DataColumn("identificacion"), new DataColumn("nombre"), new DataColumn("grado") });
        return myDataTable;
    }
    private void AddDataToTable(string codestumatricula, string identificacion, string nombre, string grado, DataTable myTable)
    {
        myTable.Rows.Add(codestumatricula, identificacion, nombre, grado);
    }
    protected void BindGrid()
    {
        GridSeleccionEstudiantes.DataSource = ((DataTable)Session["myDatatableGI"]).DefaultView;
        GridSeleccionEstudiantes.DataBind();
    }
    protected void GridSeleccionEstudiantes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string item = e.Row.Cells[1].Text;
        foreach (ImageButton button in e.Row.Cells[4].Controls.OfType<ImageButton>())
        {
            if (button.CommandName == "Delete")
            {
                button.Attributes["onclick"] = "if(!confirm('¿Desea eliminar el estudiante con ID " + item + " de la lista?')){ return false; };";
            }
        }
    }
    protected void GridSeleccionEstudiantes_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = Convert.ToInt32(e.RowIndex);
        DataTable dt = ((DataTable)Session["myDatatableGI"]);

        dt.Rows[index].Delete();
        ViewState["dt"] = dt;
        BindGrid();

        string script = @"<script type='text/javascript'> 
                               $('#agregar').hide(); $('#conformar').show(); $('#verGrupos').hide();$('#mover').hide();
            </script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }

    //Preparamos la tabla virtual para los docentes 
    private DataTable CreateDataTableDoc()
    {
        DataTable myDataTable = new DataTable();
        myDataTable.Columns.AddRange(new DataColumn[3] { new DataColumn("codgradodocente"), new DataColumn("identificacion"), new DataColumn("nomdocente") });
        return myDataTable;
    }
    private void AddDataToTableDoc(string codgradodocente, string identificacion, string nomdocente, DataTable myTable)
    {
        myTable.Rows.Add(codgradodocente, identificacion, nomdocente);
    }
    protected void BindGridDoc()
    {
        GridSeleccionDocentes.DataSource = ((DataTable)Session["myDatatableDocGI"]).DefaultView;
        GridSeleccionDocentes.DataBind();
    }
    protected void GridSeleccionDocentes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string item = e.Row.Cells[1].Text;
        foreach (ImageButton button in e.Row.Cells[3].Controls.OfType<ImageButton>())
        {
            if (button.CommandName == "Delete")
            {
                button.Attributes["onclick"] = "if(!confirm('¿Desea eliminar el docente con ID " + item + " de la lista?')){ return false; };";
            }
        }
    }
    protected void GridSeleccionDocentes_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = Convert.ToInt32(e.RowIndex);
        DataTable dtDoc = ((DataTable)Session["myDatatableDocGI"]);

        dtDoc.Rows[index].Delete();
        ViewState["dtDoc"] = dtDoc;
        BindGridDoc();

        string script = @"<script type='text/javascript'> 
                               $('#agregar').hide(); $('#conformar').show(); $('#verGrupos').hide();$('#mover').hide();
            </script>";
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
        string script = @"<script type='text/javascript'> 
                               $('#agregar').hide(); $('#conformar').show(); $('#verGrupos').hide();$('#mover').hide();
            </script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }
    protected void dropMunicipio_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddInstituciones(dropInstituciones, dropMunicipio.SelectedValue);
        string script = @"<script type='text/javascript'> 
                               $('#agregar').hide(); $('#conformar').show(); $('#verGrupos').hide();$('#mover').hide();
            </script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }
    protected void dropInstituciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddSedes(dropSedes, dropInstituciones.SelectedValue);
        string script = @"<script type='text/javascript'> 
                               $('#agregar').hide(); $('#conformar').show(); $('#verGrupos').hide();$('#mover').hide();
            </script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }
    private void ddSedes(DropDownList drop, string codinstitucion)
    {
        drop.DataSource = ins.cargarSedesInstitucion(codinstitucion);
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
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
    protected void btnBuscar_Onclick(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);

        gvCargarEstudiantesDocentes();

    }
    private void gvCargarEstudiantesDocentes()
    {
        if (dropAnio.SelectedValue != "1")
        {
            DataTable estudiantes = est.cargarEstudiantexSedexGrado(dropSedes.SelectedValue, DropGrados.SelectedValue, "1", dropAnio.SelectedValue, dropGrupo.SelectedValue);
            GridEstudiante.DataSource = estudiantes;
            GridEstudiante.DataBind();

            if (estudiantes != null && estudiantes.Rows.Count > 0)
            {
                GridEstudiante.Visible = true;
                btnSeleccionarEstudiantes.Visible = true;
            }
        }
        else//Año 2016 sin grupo para los estudiantes
        {
            DataTable estudiantes = est.cargarEstudiantexSedexGradoSinGrupo(dropSedes.SelectedValue, DropGrados.SelectedValue, "1", dropAnio.SelectedValue);
            GridEstudiante.DataSource = estudiantes;
            GridEstudiante.DataBind();

            if (estudiantes != null && estudiantes.Rows.Count > 0)
            {
                GridEstudiante.Visible = true;
                btnSeleccionarEstudiantes.Visible = true;
            }
        }

        DataTable docentes = doc.cargarDocentesxSede(dropSedes.SelectedValue, dropAnio.SelectedValue);
        GridDocentes.DataSource = docentes;
        GridDocentes.DataBind();

        if (docentes != null && docentes.Rows.Count > 0)
        {
            GridDocentes.Visible = true;
            btnSeleccionarDocente.Visible = true;

        }
        

        string script = @"<script type='text/javascript'> 
                               $('#agregar').hide(); $('#conformar').show(); $('#verGrupos').hide();$('#mover').hide();
            </script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }
    protected void btnSeleccionarEstudiantes_Click(object sender, EventArgs e)
    {
        int val = 0;
        foreach (GridViewRow row in GridEstudiante.Rows)
        {
            string codestumatricula = GridEstudiante.DataKeys[row.RowIndex].Value.ToString();
            string idestudiante = GridEstudiante.Rows[row.RowIndex].Cells[2].Text;
            string nomestudiante = GridEstudiante.Rows[row.RowIndex].Cells[3].Text;
            string gradoestudiante = GridEstudiante.Rows[row.RowIndex].Cells[4].Text;
            CheckBox dd = (row.FindControl("chkListEstudiante") as CheckBox);
            bool rb = dd.Checked;
            if (rb == true)
            {
                AddDataToTable(codestumatricula, idestudiante, nomestudiante, gradoestudiante, (DataTable)Session["myDatatableGI"]);
                val++;
            }
        }

        if(val == 0)
        {
            string script = @"<script type='text/javascript'>
                                $('#agregar').hide(); $('#conformar').show(); $('#verGrupos').hide();$('#mover').hide();
                                 alert('Seleccione los estudiantes que van a pertenecer a Grupo de Investigación');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

           
        }
        else
        {
            BindGrid();
            PanelLineaIngestigacion.Visible = true;
            ddLineaInvestigacion(dropLineaIngestigacion);
            ddAreas(dropArea);
            btnAgregarEstudiantes.Visible = true;
            btnDeseleccionarEstudiantes.Visible = true;
            string script = @"<script type='text/javascript'> 
                                $('#agregar').hide(); $('#conformar').show(); $('#verGrupos').hide();$('#mover').hide();
            </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
           
        }
      
    }
    private void ddLineaInvestigacion(DropDownList drop)
    {
        drop.DataSource = est.cargarLineaInvestigacion();
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddAreas(DropDownList drop)
    {
        drop.DataSource = est.cargarAreas();
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    protected void btnDeseleccionarEstudiantes_Click(object sender, EventArgs e)
    {
        ((DataTable)Session["myDatatableGI"]).Clear();
        BindGrid();
    }
    protected void btnEditarEstudiante_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        string codestumatricula = GridEstudiante.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string codestudiante = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        string idestudiante = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);

        lblCodEstudiante.Text = codestudiante;
        if (idestudiante != "")
        {
            buscarDatosEstudiante(idestudiante);

           
        }

        string script = @"<script type='text/javascript'> 
                               $('#agregar').fadeIn(500); $('#conformar').hide(); $('#verGrupos').hide();$('#mover').hide();
            </script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

        btnAgregarNuevoEstudiante.Visible = false;
        lnkVolver.Visible = false;
        lnkVolverEditarDatosEstudiante.Visible = true;
        lnkVolverMoverDocente.Visible = false;
        lnkVerGruposInvestigacion.Visible = false;
        btnEntrar.Visible = false;
        btnEditarDatosEstudiante.Visible = true;
    }

    private void buscarDatosEstudiante(string idestudiante)
    {
        DataRow estudiante = est.buscarEstudianteIngresado(idestudiante);
        
        if(estudiante != null)
        {
            lblIDEstudianteOld.Text = estudiante["identificacion"].ToString();
            txtNomEstudianteNuevo.Text = estudiante["nombre"].ToString();
            txtNomApellidoNuevo.Text = estudiante["apellido"].ToString();
            txtIDEstudianteNuevo.Text = estudiante["identificacion"].ToString();

            if(estudiante["sexo"].ToString() == "M" || estudiante["sexo"].ToString() == "F")
                dropSexo.SelectedValue = estudiante["sexo"].ToString();
            else
                dropSexo.SelectedIndex = 0;

            txtFechaNacimiento.Text = fun.convertFechaAño(estudiante["fecha_nacimiento"].ToString());
            txtTelefonoNuevo.Text = estudiante["telefono"].ToString();
            txtDireccionNuevo.Text = estudiante["direccion"].ToString();
            txtemailNuevo.Text = estudiante["email"].ToString();

        }
    }
    protected void btnEditarDatosEstudiante_Click(object sender, EventArgs e)
    {
        if (est.ActualizarEstudiante(lblIDEstudianteOld.Text, txtIDEstudianteNuevo.Text, txtNomEstudianteNuevo.Text, txtNomApellidoNuevo.Text, fun.convertFechaAño(txtFechaNacimiento.Text), dropSexo.SelectedValue, txtTelefonoNuevo.Text, txtDireccionNuevo.Text, txtemailNuevo.Text))
        {
            string script = @"<script type='text/javascript'> 
                alert('Datos editados correctamente.');
                $('#agregar').hide(); $('#conformar').fadeIn(500); $('#verGrupos').hide();$('#mover').hide();
            </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            btnEditarDatosEstudiante.Visible = false;
            lnkVolverEditarDatosEstudiante.Visible = false;
            lnkVolver.Visible = true;
            btnAgregarNuevoEstudiante.Visible = true;

            gvCargarEstudiantesDocentes();
        }
        else
        {
            string script = @"<script type='text/javascript'> 
                alert('Error al editar.');
               $('#agregar').show(); $('#conformar').hide(); $('#verGrupos').hide();$('#mover').hide();
            </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
    }
    protected void btnAgregarEstudiantes_Click(object sender, EventArgs e)
    {
        if (Session["codasesorestrategia"] != null)//Valida que la tabla Seleccionar estudiantes este llena
        {
            int val = 0;
            int valDoc = 0;

            DataRow redtem = est.agregarGrupoInvestigacionxSede(dropSedes.SelectedValue, fun.getFechaAñoHoraActual(), Session["codasesorestrategia"].ToString(), dropLineaIngestigacion.SelectedValue,dropArea.SelectedValue,txtNomGrupoInvestigacion.Text);

            if (redtem != null)
            {
                if(GridSeleccionEstudiantes != null && GridSeleccionEstudiantes.Rows.Count > 0)
                {
                     Session["codgrupoinvestigacion"] = redtem["codigo"].ToString();
                foreach (GridViewRow row in GridSeleccionEstudiantes.Rows)
                {
                    string codestumatricula = HttpUtility.HtmlDecode(row.Cells[0].Text);
                    DataRow redtematicamatricula = est.agregarEstudiantexGrupoInvestigacion(redtem["codigo"].ToString(), codestumatricula);
                    if (redtematicamatricula != null)
                    {
                        val++;
                    }
                }
                }
               
                foreach (GridViewRow row2 in GridSeleccionDocentes.Rows)
                {
                    string codgradodocente = HttpUtility.HtmlDecode(row2.Cells[0].Text);
                    if (est.agregarDocentexGrupoInvestigacion(codgradodocente, redtem["codigo"].ToString()))
                    {
                        valDoc++;
                    }
                }
            }
           
            if (val > 0 && valDoc > 0)
            {

                GridEstudiante.Visible = false;
                GridDocentes.Visible = false;
                dropLineaIngestigacion.SelectedIndex = 0;
                dropInstituciones.SelectedIndex = 0;
                dropSedes.Items.Clear();
                DropGrados.SelectedIndex = 0;
                btnDeseleccionarEstudiantes.Visible = false;
                btnDeseleccionarDocentes.Visible = false;
                btnSeleccionarEstudiantes.Visible = false;
                btnSeleccionarDocente.Visible = false;
                PanelLineaIngestigacion.Visible = false;
                btnAgregarEstudiantes.Visible = true;
                txtNomGrupoInvestigacion.Text = "";

                ((DataTable)Session["myDatatableDocGI"]).Clear();
             

                ((DataTable)Session["myDatatableGI"]).Clear();

                lnkVolver.Visible = false;
                lnkVerGruposInvestigacion.Visible = true;

                cargarGruposxAsesor();

                //Session["dropDepartamento"] = dropDepartamento.SelectedValue;
                //Session["dropMunicipio"] = dropMunicipio.SelectedValue;
                //Session["dropInstituciones"] = dropInstituciones.SelectedValue;
                //Session["dropSedes"] = dropSedes.SelectedValue;

                //Session["realizado"] = "OK";

                //Response.Redirect("configrupoinvestigacioneditar.aspx");

                string script = @"<script type='text/javascript'> 
                alert('Grupo de Investigación creado exitosamente.');
               $('#agregar').hide(); $('#verGrupos').fadeIn(500); $('#conformar').hide();$('#mover').hide();
            </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                btnAgregarNuevoEstudiante.Visible = false;

                
            }
            else if (val > 0 && valDoc == 0)
            {
                GridEstudiante.Visible = false;
                GridDocentes.Visible = false;
                dropLineaIngestigacion.SelectedIndex = 0;
                dropInstituciones.SelectedIndex = 0;
                dropSedes.Items.Clear();
                DropGrados.SelectedIndex = 0;
                btnDeseleccionarEstudiantes.Visible = false;
                btnDeseleccionarDocentes.Visible = false;
                btnSeleccionarEstudiantes.Visible = false;
                btnSeleccionarDocente.Visible = false;
                PanelLineaIngestigacion.Visible = false;
                btnAgregarEstudiantes.Visible = true;
                txtNomGrupoInvestigacion.Text = "";

                ((DataTable)Session["myDatatableDocGI"]).Clear();
                BindGridDoc();

                ((DataTable)Session["myDatatableGI"]).Clear();
                BindGrid();

                //Session["realizado"] = "Sin_Docentes";

                //Response.Redirect("configrupoinvestigacioneditar.aspx");

                cargarGruposxAsesor();

                string script = @"<script type='text/javascript'> 
                     alert('Grupo de Investigación creado exitosamente, pero no tiene docentes asignados.');
                     $('#agregar').hide(); $('#verGrupos').fadeIn(500); $('#conformar').hide();$('#mover').hide();
                </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                btnAgregarNuevoEstudiante.Visible = false;
            }
            else if (val == 0 && valDoc > 0)
            {
                GridEstudiante.Visible = false;
                GridDocentes.Visible = false;
                dropLineaIngestigacion.SelectedIndex = 0;
                dropInstituciones.SelectedIndex = 0;
                dropSedes.Items.Clear();
                DropGrados.SelectedIndex = 0;
                btnDeseleccionarEstudiantes.Visible = false;
                btnDeseleccionarDocentes.Visible = false;
                btnSeleccionarEstudiantes.Visible = false;
                btnSeleccionarDocente.Visible = false;
                PanelLineaIngestigacion.Visible = false;
                btnAgregarEstudiantes.Visible = true;
                txtNomGrupoInvestigacion.Text = "";

                ((DataTable)Session["myDatatableDocGI"]).Clear();
                BindGridDoc();

                ((DataTable)Session["myDatatableGI"]).Clear();
                BindGrid();

                //Session["realizado"] = "Sin_Docentes";

                //Response.Redirect("configrupoinvestigacioneditar.aspx");

                cargarGruposxAsesor();

                string script = @"<script type='text/javascript'> 
                     alert('Grupo de Investigación creado exitosamente, pero no tiene estudiantes asignados.');
                     $('#agregar').hide(); $('#verGrupos').fadeIn(500); $('#conformar').hide();$('#mover').hide();
                </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                btnAgregarNuevoEstudiante.Visible = false;
            }
            else 
            {
                string script = @"<script type='text/javascript'>
                                  $('#agregar').hide(); $('#conformar').show(); $('#verGrupos').hide();$('#mover').hide();
                                alert('Error al crear Grupo de Investigación.');
                        </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        else
        {
            string script = @"<script type='text/javascript'>
                                $('#agregar').hide(); $('#conformar').show(); $('#verGrupos').hide();$('#mover').hide();
                                alert('Error al guardar');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
    }

    protected void btnGuardarEdicionEstudiante_Click(object sender, EventArgs e)
    {

        string script = @"<script type='text/javascript'> $('#dialog-form').dialog({
                  modal: true,
                  height: 'auto',
                  width: 'auto',
                  buttons: {
                      Guardar: function () {
                          updateEstudiante(codigo)
                      },
                      Cancelar: function () {
                          $('#dialog-form').dialog('close');
                      }
                  }
              });
            </script>";


        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }
//    protected void btnNuevoEstudiante_Click(object sender, EventArgs e)
//    {
//        string script = @"<script type='text/javascript'>
//                        alert('Hola');
//            </script>";


//        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
//    }
    protected void btnAgregarNuevoEstudiante_Click(object sender, EventArgs e)
    {
        //Cuando presionan el botón "Nuevo estudiante"
        if (dropSedes.Items != null && dropSedes.SelectedIndex != 0 && DropGrados.SelectedIndex != 0)
        {
            Session["codsede"] = dropSedes.SelectedValue;
            Session["codgrado"] = DropGrados.SelectedValue;
            Session["grupo"] = dropGrupo.SelectedValue;

            if (Session["codsede"].ToString() != "")
            {
                string script = @"<script type='text/javascript'> 
                           $('#conformar').hide(); $('#verGrupos').hide();$('#mover').hide(); $('#agregar').fadeIn(500);
            </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                btnAgregarNuevoEstudiante.Visible = false;
                lnkVolverEditarDatosEstudiante.Visible = true;
                lnkVolver.Visible = false;

                txtNomEstudianteNuevo.Text = "";
                txtNomApellidoNuevo.Text = "";
                txtFechaNacimiento.Text = "";
                txtTelefonoNuevo.Text = "";
                txtDireccionNuevo.Text = "";
                txtemailNuevo.Text = "";
                txtIDEstudianteNuevo.Text = "";

            }
            else
            {
                string script = @"<script type='text/javascript'> 
                               $('#agregar').hide(); $('#conformar').show(); $('#verGrupos').hide();$('#mover').hide();
                                alert('Debe seleccionar la sede y el grado.');
            </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        else
        {
            string script = @"<script type='text/javascript'> 
                                $('#agregar').hide(); $('#conformar').show(); $('#verGrupos').hide();$('#mover').hide();
                                alert('Debe seleccionar la sede y el grado.');
            </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
       
    }
    protected void btnEntrar_click(object sender, EventArgs e)
    {

        Estudiantes estra = new Estudiantes();
        Funciones fun = new Funciones();
        Institucion ins = new Institucion();
        DataRow anio = ins.buscarAnioON();

        if (dropSedes.SelectedIndex != 0 && DropGrados.SelectedIndex != 0)
        {


            DataRow estudiante = estra.agregarEstudiantePG(txtNomEstudianteNuevo.Text, txtNomApellidoNuevo.Text, txtIDEstudianteNuevo.Text, dropSexo.SelectedValue, fun.convertFechaAño(txtFechaNacimiento.Text), txtTelefonoNuevo.Text, txtDireccionNuevo.Text, txtemailNuevo.Text, "1", "1");

            if (estudiante != null)
            {
                if (estra.agregarEstuMatricula(dropSedes.SelectedValue, estudiante["codigo"].ToString(), anio["codigo"].ToString(), fun.getFechaAñoHoraActual(), DropGrados.SelectedValue, "1", dropGrupo.SelectedValue))
                {
                    //ca += "true@";
                    txtNomEstudianteNuevo.Text = "";
                    txtNomApellidoNuevo.Text = ""; txtIDEstudianteNuevo.Text = ""; dropSexo.SelectedIndex = 0; txtFechaNacimiento.Text = ""; txtTelefonoNuevo.Text = ""; txtDireccionNuevo.Text = ""; txtemailNuevo.Text = "";
                    string script = @"<script type='text/javascript'>
                                 $('#agregar').hide(); $('#conformar').show(); $('#verGrupos').hide();$('#mover').hide();
                                alert('Datos ingresados correctamente.');
                        </script>";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    lnkVolver.Visible = true;
                    btnAgregarEstudiantes.Visible = false;
                    lnkVerGruposInvestigacion.Visible = false;
                    btnAgregarNuevoEstudiante.Visible = true;
                    lnkVolverEditarDatosEstudiante.Visible = false;
                    gvCargarEstudiantesDocentes();
                }
                else
                {
                    string script = @"<script type='text/javascript'>
                                  $('#agregar').fadeIn(500); $('#conformar').hide(); $('#verGrupos').hide();$('#mover').hide();
                                alert('Error al matricular.');
                        </script>";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    lnkVolver.Visible = true;
                    btnAgregarEstudiantes.Visible = false;
                    lnkVerGruposInvestigacion.Visible = false;
                }

            }
            else
            {
                string script = @"<script type='text/javascript'>
                                 $('#agregar').show();
                                $('#VerRed').hide();$('#CrearRed').hide();
                                alert('Error, la identificación ya se encuentra registrada en el sistema.');
                        </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
//                if (estra.agregarEstuMatricula(dropSedes.SelectedValue, estudiante["codigo"].ToString(), anio["codigo"].ToString(), fun.getFechaAñoHoraActual(), DropGrados.SelectedValue, "2"))
//                {
//                    //ca += "true@";
//                    string script = @"<script type='text/javascript'>
//                                  $('#agregar').hide(); $('#conformar').show(); $('#verGrupos').hide();$('#mover').hide();
//                                alert('Datos ingresados correctamente.');
//                        </script>";

//                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

//                    gvCargarEstudiantesDocentes();
//                }
//                else
//                {
//                    string script = @"<script type='text/javascript'>
//                                  $('#agregar').fadeIn(500); $('#conformar').hide(); $('#verGrupos').hide();$('#mover').hide();
//                                alert('Error al matricular.');
//                        </script>";

//                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                //}
            }
        }
        else
        {
            string script = @"<script type='text/javascript'>
                                alert('Debe seleccionar la sede y/o grado antes de ingresar al estudiante');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }


    }
    protected void lnkVolverEditarDatosEstudiante_Click(object sender, EventArgs e)
    {
        string script = @"<script type='text/javascript'> 
                $('#agregar').hide(); $('#conformar').fadeIn(500); $('#verGrupos').hide();$('#mover').hide();
            </script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

        btnAgregarNuevoEstudiante.Visible = true;
        lnkVolver.Visible = true;
        lnkVolverEditarDatosEstudiante.Visible = false;
    }
    protected void lnkMoverDocente_Click(object sender, EventArgs e)
    {
        LinkButton btndetails = sender as LinkButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        string codgradodocente = GridDocentes.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string iddocente = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        string nomdocente = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);

        Session["codgradodocente"] = codgradodocente;

        ddSedes(dropSedeMover, dropInstituciones.SelectedValue);

        string script = @"<script type='text/javascript'> 
            $('#conformar').hide();$('#verGrupos').hide();$('#agregar').hide();$('#mover').fadeIn(500);
            </script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

        btnAgregarNuevoEstudiante.Visible = false;
        lnkVolver.Visible = false;
        lnkVolverMoverDocente.Visible = true;
    }

    protected void btnMoverDocente_Click(object sender, EventArgs e)
    {
        if (Session["codgradodocente"] != null)
        {
            lnkVerGruposInvestigacion.Visible = false;
            btnAgregarNuevoEstudiante.Visible = false;
            lnkVolver.Visible = false;
            lnkVolverMoverDocente.Visible = true;
            if (doc.MoverDocenteDeSede(dropSedeMover.SelectedValue, Session["codgradodocente"].ToString(), dropAnio.SelectedValue))
            {
                string script = @"<script type='text/javascript'> 
                                alert('Docente movido correctamente.');
                                 $('#conformar').fadeIn(500);$('#verGrupos').hide();$('#agregar').hide();$('#mover').hide();
                </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                gvCargarEstudiantesDocentes();
            }
            else
            {
                string script = @"<script type='text/javascript'> 
                                alert('Error al mover Docente.');
                                 $('#verGrupos').hide();$('#conformar').hide();$('#agregar').hide();$('#mover').show();
                </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        else
        {
            string script = @"<script type='text/javascript'> 
                            alert('No hay docente seleccionado.');
                                $('#verGrupos').hide();$('#conformar').hide();$('#agregar').hide();$('#mover').show();
                </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
    }

    protected void lnkVolverMoverDocente_Click(object sender, EventArgs e)
    {
        string script = @"<script type='text/javascript'>
                    $('#verGrupos').hide();$('#conformar').fadeIn(500);$('#agregar').hide();$('#mover').hide();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        lnkVerGruposInvestigacion.Visible = false;
        lnkVolverMoverDocente.Visible = false;
        btnAgregarNuevoEstudiante.Visible = true;
        lnkVolver.Visible = true;
    }


    [WebMethod(EnableSession = true)]
    public static string agregarEstudiante(string txtIDEstudianteNuevo, string txtNomEstudianteNuevo, string txtNomApellidoNuevo, string dropsexo, string txtFechaNacimiento, string txtTelefonoNuevo, string txtDireccionNuevo, string txtemailNuevo)
    {
        string ca = "";

      
            Estudiantes estra = new Estudiantes();
            Funciones fun = new Funciones();
            Institucion ins = new Institucion();
            DataRow anio = ins.buscarAnioON();

        if (HttpContext.Current.Session["codsede"] != null || HttpContext.Current.Session["codgrado"] != null)
        {
            DataRow estudiante = null;
            if (txtemailNuevo == "0")
            {
                estudiante = estra.agregarEstudiantePG(txtNomEstudianteNuevo, txtNomApellidoNuevo, txtIDEstudianteNuevo, dropsexo, fun.convertFechaAño(txtFechaNacimiento), txtTelefonoNuevo, txtDireccionNuevo, "0", "1", "1");
            }
            else
            {
                estudiante = estra.agregarEstudiantePG(txtNomEstudianteNuevo, txtNomApellidoNuevo, txtIDEstudianteNuevo, dropsexo, fun.convertFechaAño(txtFechaNacimiento), txtTelefonoNuevo, txtDireccionNuevo, txtemailNuevo, "1", "1");
            }
           

            if (estudiante != null)
            {
                if (estra.agregarEstuMatricula(HttpContext.Current.Session["codsede"].ToString(), estudiante["codigo"].ToString(), anio["codigo"].ToString(), fun.getFechaAñoHoraActual(), HttpContext.Current.Session["codgrado"].ToString(), "1", HttpContext.Current.Session["grupo"].ToString()))
                {
                    ca += "true@";
                    HttpContext.Current.Session["codsede"] = null;
                    HttpContext.Current.Session["codgrado"] = null;
                    HttpContext.Current.Session["grupo"] = null;
                }
                else
                {
                    ca += "errorMatricula@";
                }

            }
            else
            {
                ca += "error@";
            }
        }
        else
        {
            ca += "errorSeleccion@";
        }

       

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string actualizarEstudiante(string txtIDEstudianteNuevo, string txtNomEstudianteNuevo, string txtNomApellidoNuevo, string dropsexo, string txtFechaNacimiento, string txtTelefonoNuevo, string txtDireccionNuevo, string txtemailNuevo)
    {
        string ca = "";
        Estudiantes estra = new Estudiantes();
        Funciones fun = new Funciones();
        if (estra.ActualizarEstudiante("",txtIDEstudianteNuevo, txtNomEstudianteNuevo, txtNomApellidoNuevo, fun.convertFechaAño(txtFechaNacimiento), dropsexo, txtTelefonoNuevo, txtDireccionNuevo, txtemailNuevo))
        {
            ca += "true@";
        }
        else
        {
            ca += "error@";
        }

        return ca;
    }

    //Docentes
    protected void btnDeseleccionarDocentes_Click(object sender, EventArgs e)
    {
        ((DataTable)Session["myDatatableDocGI"]).Clear();
        BindGridDoc();
    }
    protected void btnSeleccionarDocente_Click(object sender, EventArgs e)
    {
        int val = 0;
        foreach (GridViewRow row in GridDocentes.Rows)
        {
            string codgradodocente = GridDocentes.Rows[row.RowIndex].Cells[1].Text;
            string identificacion = GridDocentes.Rows[row.RowIndex].Cells[2].Text;
            string nomdocente = GridDocentes.Rows[row.RowIndex].Cells[3].Text;
            CheckBox dd = (row.FindControl("chkListDocente") as CheckBox);
            bool rb = dd.Checked;
            if (rb == true)
            {
                AddDataToTableDoc(codgradodocente, identificacion, nomdocente, (DataTable)Session["myDatatableDocGI"]);
                val++;
            }
        }

        if (val == 0)
        {
            string script = @"<script type='text/javascript'>
                                $('#agregar').hide(); $('#conformar').show(); $('#verGrupos').hide();$('#mover').hide();
                                alert('Seleccione el/los docentes que van a pertenecer como Maestros(as) acompanante(s)');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
        else
        {
            BindGridDoc();
            PanelLineaIngestigacion.Visible = true;
            ddLineaInvestigacion(dropLineaIngestigacion);
            ddAreas(dropArea);
            btnDeseleccionarDocentes.Visible = true;
            btnAgregarEstudiantes.Visible = true;
            string script = @"<script type='text/javascript'> 
                                $('#agregar').hide(); $('#conformar').show(); $('#verGrupos').hide();$('#mover').hide();
            </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

    }

    
    [WebMethod(EnableSession = true)]
    public static string moverDocente(string dropsede, string dropanio)
    {
        string ca = "";
        Docentes estra = new Docentes();

        if (HttpContext.Current.Session["codgradodocente"] != null)
        {
           
            if (estra.MoverDocenteDeSede(dropsede, HttpContext.Current.Session["codgradodocente"].ToString(), dropanio))
            {
                ca += "true@";
                HttpContext.Current.Session["codgradodocente"] = null;
            }
            else
            {
                ca += "error@";
            }
        }
        else
        {
            ca += "error@";
        }
       

        return ca;
    }

    //Ver grupos

    protected void lnkVolver_Click(object sender, EventArgs e)
    {
        string script = @"<script type='text/javascript'>$('#verGrupos').fadeIn(500);$('#conformar').hide();$('#editar').hide();$('#mover').hide();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        btnAgregarNuevoEstudiante.Visible = false;
        lnkVolver.Visible = false;
        lnkVerGruposInvestigacion.Visible = true;
    }

    protected void lnkVerGruposInvestigacion_Click(object sender, EventArgs e)
    {
        string script = @"<script type='text/javascript'>$('#conformar').fadeIn(500);$('#verGrupos').hide();$('#editar').hide();$('#mover').hide()
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        lnkVolver.Visible = true;
        lnkVerGruposInvestigacion.Visible = false;
        btnAgregarNuevoEstudiante.Visible = true;
    }

    private void cargarGruposxAsesor()
    {
        if (Session["codasesorestrategia"] != null)
        {
            DataTable datos = estr.cargarGruposInvestigacionxAsesor(Session["codasesorestrategia"].ToString());
            GridGrupo.DataSource = datos;
            GridGrupo.DataBind();
        }
        else
        {
            mostrarmensaje("error","No está registrado como Asesor, comuniquese con el personal de Soporte de Macondo.");
            lnkVerGruposInvestigacion.Visible = false;
        }

    }

    protected void imgVerEstudiantes_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codproyectosede = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

        string script = @"<script type='text/javascript'> $('#dialog-formEstudiantes').dialog({
                  modal: true,
                  height: 'auto',
                  width: 'auto',
              });

            $('#conformar').hide(), $('#MainContent_btnAgregarNuevoEstudiante').hide(),$('#verGrupos').show(),$('#lnkVerGruposInvestigacion').hide();
            </script>";

        string ca = "";

        DataTable datos = est.cargarEstudiantesxGrupoInvestigacion(codproyectosede);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<table  class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<th>Nro</th>";
            ca += "<th>Estudiantes</th>";
            ca += "</tr>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["nombre"].ToString() + "</td>";
                ca += "</tr>";
            }

        }
        lblDocentes.Text = "";
        lblEstudiantes.Text = ca;

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
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
            $('#conformar').hide(), $('#MainContent_btnAgregarNuevoEstudiante').hide(),$('#verGrupos').show(),$('#lnkVerGruposInvestigacion').hide();
            </script>";

        string ca = "";

        DataTable datos = est.cargarDocentesxGrupoInvestigacion(codproyectosede);

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
        lblEstudiantes.Text = "";
        lblDocentes.Text = ca;

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }

    protected void lnkEditarGrupo_Click(object sender, EventArgs e)
    {
        string script = @"<script type='text/javascript'> $('#agregar').hide(); $('#conformar').show(); $('#verGrupos').hide();$('#mover').hide();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        btnAgregarEstudiantes.Visible = true;
        lnkVerGruposInvestigacion.Visible = false;

        LinkButton btndetails = sender as LinkButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codredtematicasede = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

        Session["codgrupoinvestigacion"] = codredtematicasede;

        Response.Redirect("configrupoinvestigacioneditar.aspx");
    }

    protected void lnkS003_Click(object sender, EventArgs e)
    {
        LinkButton btndetails = sender as LinkButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codredtematicasede = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

        Session["codgrupoinvestigacion"] = codredtematicasede;

        Response.Redirect("estras003_estategia1.aspx");
    }

    protected void lnkEliminarGrupo_Click(object sender, EventArgs e)
    {
        LinkButton btndetails = sender as LinkButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        string codproyectosede = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        est.eliminarEstudiantesGrupoInvestigacionTodo(codproyectosede);
        est.eliminarDocentesGrupoInvestigacionTodo(codproyectosede);
        est.eliminarGrupoInvestigacionSede(codproyectosede);

        //DataTable datos = est.buscarDatoS004(codproyectosede);
        //if (datos != null && datos.Rows.Count > 0)
        //{
        //    for (int i = 0; i < datos.Rows.Count; i++)
        //    {
        //        est.eliminarPreguntasS004(datos.Rows[i]["codigo"].ToString());
        //    }

        //}
        string script = @"<script type='text/javascript'>
                    alert('Datos eliminados correctamente.');
                     $('#agregar').hide(); $('#conformar').hide(); $('#verGrupos').show();$('#mover').hide();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        dropDepartamento.SelectedIndex = 0;
        dropMunicipio.Items.Clear();

        cargarGruposxAsesor();

    }

}