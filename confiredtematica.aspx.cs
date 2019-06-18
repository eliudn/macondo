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

public partial class confiredtematica : System.Web.UI.Page
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
           
            lblTipoUsuario.Text = Session["codrol"].ToString();
            ddGrados(DropGrados);
            ddAnio(dropAnio);
            ddAnio(dropAnio2);
            ddAnioRed(dropAnioRed);
            ddGrupos(dropGrupo);
            if (lblTipoUsuario.Text == "13")
            {
                ddDepartamentos(dropDepartamento);

                DataTable dt = new DataTable();
                dt = CreateDataTable();
                Session["myDatatable"] = dt;      
                ViewState["dt"] = dt;
                this.GridSeleccionEstudiantes.DataSource = ((DataTable)Session["myDatatable"]).DefaultView;
                this.GridSeleccionEstudiantes.DataBind();

                DataTable dtDoc = new DataTable();
                dtDoc = CreateDataTableDoc();
                Session["myDatatableDoc"] = dtDoc;
                ViewState["dtDoc"] = dtDoc;
                this.GridSeleccionDocentes.DataSource = ((DataTable)Session["myDatatableDoc"]).DefaultView;
                this.GridSeleccionDocentes.DataBind();

                DataRow dat = ase.buscarAsesorxEstrategiaxIdentificacion(Session["identificacion"].ToString());

                if(dat != null)
                {
                    Session["codasesorcoordinador"] = dat["codasesorcoordinador"].ToString();
                }

                cargarRedesxAsesor();

            }
            else if(lblTipoUsuario.Text == "9")
            {
                ddDepartamentos(dropDepartamento);

                DataTable dt = new DataTable();
                dt = CreateDataTable();
                Session["myDatatable"] = dt;
                ViewState["dt"] = dt;
                this.GridSeleccionEstudiantes.DataSource = ((DataTable)Session["myDatatable"]).DefaultView;
                this.GridSeleccionEstudiantes.DataBind();

                DataTable dtDoc = new DataTable();
                dtDoc = CreateDataTableDoc();
                Session["myDatatableDoc"] = dtDoc;
                ViewState["dtDoc"] = dtDoc;
                this.GridSeleccionDocentes.DataSource = ((DataTable)Session["myDatatableDoc"]).DefaultView;
                this.GridSeleccionDocentes.DataBind();
            }
            else
            {
                Response.Redirect("bienvenida.aspx");
            }
        }
        
    }
    protected void dropAnio2_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable datos = estr.cargarRedesTematicasxAsesorxAnio(Session["codasesorcoordinador"].ToString(), dropAnio2.SelectedItem.ToString());
        GridRed.DataSource = datos;
        GridRed.DataBind();
    }
    private void ddAnio(DropDownList drop)
    {
        drop.DataSource = ins.cargarAnios();
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddAnioRed(DropDownList drop)
    {
        drop.DataSource = ins.cargarAnios();
        drop.DataTextField = "nombre";
        drop.DataValueField = "nombre";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddGrupos(DropDownList drop)
    {
        //drop.DataSource = ins.cargarAnios();
        //drop.DataTextField = "nombre";
        //drop.DataValueField = "codigo";
        //drop.DataBind();
        //drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
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
        GridSeleccionEstudiantes.DataSource = ((DataTable)Session["myDatatable"]).DefaultView;
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
        DataTable dt = ((DataTable)Session["myDatatable"]);

        dt.Rows[index].Delete();
        ViewState["dt"] = dt;
        BindGrid();

        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();$('#Modificarfecha').hide();
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
        GridSeleccionDocentes.DataSource = ((DataTable)Session["myDatatableDoc"]).DefaultView;
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
        DataTable dtDoc = ((DataTable)Session["myDatatableDoc"]);

        dtDoc.Rows[index].Delete();
        ViewState["dtDoc"] = dtDoc;
        BindGridDoc();

        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();$('#Modificarfecha').hide();
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

        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();$('#Modificarfecha').hide();$('#Modificarfecha').hide();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }
    protected void dropMunicipio_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddInstituciones(dropInstituciones, dropMunicipio.SelectedValue);

        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();$('#Modificarfecha').hide();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }
    protected void dropInstituciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddSedes(dropSedes, dropInstituciones.SelectedValue);

        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();$('#Modificarfecha').hide();
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
            DataTable estudiantes = est.cargarEstudiantexSedexGrado(dropSedes.SelectedValue, DropGrados.SelectedValue, "2", dropAnio.SelectedValue, dropGrupo.SelectedValue);

            if (estudiantes != null && estudiantes.Rows.Count > 0)
            {
                DataView dw = estudiantes.DefaultView;
                dw.Sort = "nombre asc";
                GridEstudiante.DataSource = dw.ToTable();
                GridEstudiante.DataBind();
                GridEstudiante.Visible = true;
                btnSeleccionarEstudiantes.Visible = true;
                btnBorrarSeleccion.Visible = true;
                lblEstudentVacio.Visible = false;
                //chkseleccionartodo.Visible = true;

            }
            else
            {
                GridEstudiante.Visible = false;
                btnSeleccionarEstudiantes.Visible = false;
                lblEstudentVacio.Text = "<b style='color:red;'>No hay estudiantes</b>";
            }
        }
        else//Año 2016 sin grupo para los estudiantes
        {
            DataTable estudiantes = est.cargarEstudiantexSedexGradoSinGrupo(dropSedes.SelectedValue, DropGrados.SelectedValue, "2", dropAnio.SelectedValue);

            if (estudiantes != null && estudiantes.Rows.Count > 0)
            {
                DataView dw = estudiantes.DefaultView;
                dw.Sort = "nombre asc";
                GridEstudiante.DataSource = dw.ToTable();
                GridEstudiante.DataBind();
                GridEstudiante.Visible = true;
                btnSeleccionarEstudiantes.Visible = true;
                btnBorrarSeleccion.Visible = true;
                lblEstudentVacio.Visible = false;
                //chkseleccionartodo.Visible = true;

            }
            else
            {
                GridEstudiante.Visible = false;
                btnSeleccionarEstudiantes.Visible = false;
                lblEstudentVacio.Text = "<b style='color:red;'>No hay estudiantes</b>";
            }
        }

        DataTable docentes = doc.cargarDocentesxSede(dropSedes.SelectedValue, dropAnio.SelectedValue);


        if (docentes != null && docentes.Rows.Count > 0)
        {
            GridDocentes.Visible = true;
            btnSeleccionarDocente.Visible = true;
            DataView dwd = docentes.DefaultView;
            dwd.Sort = "nomdocente asc";
            GridDocentes.DataSource = dwd.ToTable();
            GridDocentes.DataBind();
            lblDocVacio.Visible = false;

        }
        else
        {
            GridDocentes.Visible = false;
            btnSeleccionarDocente.Visible = false;
            lblDocVacio.Text = "<b style='color:red;'>No hay docentes</b>";
        }

        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();$('#Modificarfecha').hide();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }

    protected void btnSeleccionarEstudiantes_Click(object sender, EventArgs e)
    {
        int val = 0;
        foreach (GridViewRow row in GridEstudiante.Rows)
        {
            string codestumatricula = GridEstudiante.DataKeys[row.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
            string idestudiante = GridEstudiante.Rows[row.RowIndex].Cells[2].Text;
            string nomestudiante = GridEstudiante.Rows[row.RowIndex].Cells[3].Text;
            string gradoestudiante = GridEstudiante.Rows[row.RowIndex].Cells[4].Text;
            CheckBox dd = (row.FindControl("chkListEstudiante") as CheckBox);
            bool rb = dd.Checked;
            if (rb == true)
            {
                AddDataToTable(codestumatricula, idestudiante, nomestudiante, gradoestudiante, (DataTable)Session["myDatatable"]);
                val++;
            }
        }

        if(val == 0)
        {
            string script = @"<script type='text/javascript'>
                                alert('Seleccione los estudiantes que van a pertenecer a la Red Temática');
                                $('#VerRed').hide(),$('#CrearRed').show();$('#Modificarfecha').hide();
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);  
        }
        else
        {
            BindGrid();
            PanelNomRedtematica.Visible = true;
            ddRedTematica(dropRedTematica);
            btnAgregarEstudiantes.Visible = true;
            btnDeseleccionarEstudiantes.Visible = true;

            string script = @"<script type='text/javascript'>
                                $('#VerRed').hide(),$('#CrearRed').show();$('#Modificarfecha').hide();
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);  
        }
      
    }

    
    private void ddRedTematica(DropDownList drop)
    {
        drop.DataSource = est.cargarRedesTematicas();
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    protected void btnDeseleccionarEstudiantes_Click(object sender, EventArgs e)
    {
        ((DataTable)Session["myDatatable"]).Clear();
        BindGrid();

        string script = @"<script type='text/javascript'>
                                $('#VerRed').hide(),$('#CrearRed').show();$('#Modificarfecha').hide();
                        </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
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

            btnnuevoEstudiante.Visible = false;
            btnEntrar.Visible = false;
            btnEditarDatosEstudiante.Visible = true;
            lnkVolverEditarDatosEstudiante.Visible = true;
            lnkVolver.Visible = false;

           
        }

        string script = @"<script type='text/javascript'> 
                $('#agregar').show();
                $('#VerRed').hide();$('#CrearRed').hide();$('#Modificarfecha').hide();
            </script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
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

            txtFechaN.Text = fun.convertFechaAño(estudiante["fecha_nacimiento"].ToString());
            txtTelefonoNuevo.Text = estudiante["telefono"].ToString();
            txtDireccionNuevo.Text = estudiante["direccion"].ToString();
            txtemailNuevo.Text = estudiante["email"].ToString();

        }
       
    }
    protected void btnEditarDatosEstudiante_Click(object sender, EventArgs e)
    {
        if (est.ActualizarEstudiante(lblIDEstudianteOld.Text,txtIDEstudianteNuevo.Text, txtNomEstudianteNuevo.Text, txtNomApellidoNuevo.Text, fun.convertFechaAño(txtFechaN.Text), dropSexo.SelectedValue, txtTelefonoNuevo.Text, txtDireccionNuevo.Text, txtemailNuevo.Text))
        {
            string script = @"<script type='text/javascript'> 
                alert('Datos editados correctamente.');
                $('#agregar').hide();
                $('#VerRed').hide();$('#CrearRed').fadeIn(500);$('#Modificarfecha').hide();
            </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            btnEditarDatosEstudiante.Visible = false;
            lnkVolverEditarDatosEstudiante.Visible = false;
            lnkVolver.Visible = true;
            btnnuevoEstudiante.Visible = false;

            gvCargarEstudiantesDocentes();
        }
        else
        {
            string script = @"<script type='text/javascript'> 
                alert('Error al editar.');
                $('#agregar').show();
                $('#VerRed').hide();$('#CrearRed').hide();$('#Modificarfecha').hide();
            </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
    }
    protected void lnkVolverEditarDatosEstudiante_Click(object sender, EventArgs e)
    {
        string script = @"<script type='text/javascript'> 
                $('#agregar').hide();
                $('#VerRed').hide();$('#CrearRed').fadeIn(500);$('#Modificarfecha').hide();
            </script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

        btnnuevoEstudiante.Visible = false;
        lnkVolver.Visible = true;
        lnkVolverEditarDatosEstudiante.Visible = false;
    }
    protected void btnAgregarEstudiantes_Click(object sender, EventArgs e)
    {
        if (GridSeleccionEstudiantes != null && GridSeleccionEstudiantes.Rows.Count > 0 && Session["codasesorcoordinador"] != null)//Valida que la tabla Seleccionar estudiantes este llena
        {
            DataRow dat = est.buscarUltimaRedTematicaxSede(dropRedTematica.SelectedValue, dropSedes.SelectedValue, fun.getAñoActual());//buscar el último creado
            int val = 0;
            int valDoc = 0;

            if (dat == null)//si no existe red temática en la base de datos
            {
                DataRow redtem = est.agregarRedTematicaxSede(dropRedTematica.SelectedValue, dropSedes.SelectedValue, "1", Session["codasesorcoordinador"].ToString(), dropAnio.SelectedItem.ToString());

                if (redtem != null)
                {
                    Session["codredtematica"] = redtem["codigo"].ToString();
                    foreach (GridViewRow row in GridSeleccionEstudiantes.Rows)
                    {
                        string codestumatricula = HttpUtility.HtmlDecode(row.Cells[0].Text);
                        DataRow redtematicamatricula = est.agregarEstudiantexRedTematica(redtem["codigo"].ToString(), codestumatricula);
                        if (redtematicamatricula != null)
                        {
                            val++;
                        }
                    }

                    foreach (GridViewRow row2 in GridSeleccionDocentes.Rows)
                    {
                        string codgradodocente = HttpUtility.HtmlDecode(row2.Cells[0].Text);
                        if (est.agregarDocentexRedTematica(codgradodocente, redtem["codigo"].ToString()))
                        {
                            valDoc++;
                        }
                    }
                }
            }
            else
            {
                int consecutivogrupo = Convert.ToInt32(dat["consecutivogrupo"].ToString()) + 1;

                DataRow redtem = est.agregarRedTematicaxSede(dropRedTematica.SelectedValue, dropSedes.SelectedValue, Convert.ToString(consecutivogrupo), Session["codasesorcoordinador"].ToString(), dropAnio.SelectedItem.ToString());

                if (redtem != null)
                {
                    Session["codredtematica"] = redtem["codigo"].ToString();
                    foreach (GridViewRow row in GridSeleccionEstudiantes.Rows)
                    {
                        string codestumatricula = HttpUtility.HtmlDecode(row.Cells[0].Text);
                        DataRow redtematicamatricula = est.agregarEstudiantexRedTematica(redtem["codigo"].ToString(), codestumatricula);
                        if (redtematicamatricula != null)
                        {
                            val++;
                        }
                    }
                    foreach (GridViewRow row2 in GridSeleccionDocentes.Rows)
                    {
                        string codgradodocente = HttpUtility.HtmlDecode(row2.Cells[0].Text);
                        if (est.agregarDocentexRedTematica(codgradodocente, redtem["codigo"].ToString()))
                        {
                            valDoc++;
                        }
                    }
                }
            }
            if (val > 0 && valDoc > 0)
            {
                GridEstudiante.Visible = false;
                GridDocentes.Visible = false;
                dropRedTematica.SelectedIndex = 0;
                dropInstituciones.SelectedIndex = 0;
                dropSedes.Items.Clear();
                DropGrados.SelectedIndex = 0;
                btnDeseleccionarEstudiantes.Visible = false;
                btnDeseleccionarDocentes.Visible = false;
                btnSeleccionarEstudiantes.Visible = false;
                btnSeleccionarDocente.Visible = false;
                PanelNomRedtematica.Visible = false;
                btnAgregarEstudiantes.Visible = false;
                btnAgregarEstudiantes.Enabled = true;

                ((DataTable)Session["myDatatableDoc"]).Clear();
                BindGridDoc();

                ((DataTable)Session["myDatatable"]).Clear();
                BindGrid();

                string script = @"<script type='text/javascript'>$('#CrearRed').hide(),$('#VerRed').fadeIn(500), alert('Red tematica creada exitosamente');$('#Modificarfecha').hide();
                     </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                btnAgregarEstudiantes.Visible = false;
                lnkVerGruposInvestigacion.Visible = true;
                btnnuevoEstudiante.Visible = false;
                lnkVolver.Visible = false;

                cargarRedesxAsesor();

                //Session["realizado"] = "OK";

               
            }
            else if (val > 0 && valDoc == 0)
            {
                GridEstudiante.Visible = false;
                GridDocentes.Visible = false;
                dropRedTematica.SelectedIndex = 0;
                dropInstituciones.SelectedIndex = 0;
                dropSedes.Items.Clear();
                DropGrados.SelectedIndex = 0;
                btnDeseleccionarEstudiantes.Visible = false;
                btnDeseleccionarDocentes.Visible = false;
                btnSeleccionarEstudiantes.Visible = false;
                btnSeleccionarDocente.Visible = false;
                PanelNomRedtematica.Visible = false;
                btnAgregarEstudiantes.Visible = false;
                btnAgregarEstudiantes.Enabled = true;

                ((DataTable)Session["myDatatableDoc"]).Clear();
                BindGridDoc();

                ((DataTable)Session["myDatatable"]).Clear();
                BindGrid();

                //Session["realizado"] = "Sin_Docentes";


                string script = @"<script type='text/javascript'>$('#CrearRed').hide(),$('#VerRed').fadeIn(500),alert('Red tematica creada exitosamente');$('#Modificarfecha').hide();
                     </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                btnAgregarEstudiantes.Visible = false;
                lnkVerGruposInvestigacion.Visible = true;

                cargarRedesxAsesor();

              
            }
            else 
            {
                string script = @"<script type='text/javascript'>
                                alert('Error al crear Red Temática.');
                                $('#VerRed').hide(),$('#CrearRed').show();$('#Modificarfecha').hide();
                        </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        else
        {
            string script = @"<script type='text/javascript'>
                                alert('No hay estudiantes para ingresar en la Red Temática.');
                                $('#VerRed').hide(),$('#CrearRed').show();$('#Modificarfecha').hide();
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
                $('#VerRed').hide(),$('#CrearRed').show();$('#Modificarfecha').hide();$('#Modificarfecha').hide();
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
       

        if(dropSedes.Items != null && dropSedes.SelectedIndex != 0 && DropGrados.SelectedIndex != 0)
        {
            Session["codsede"] = dropSedes.SelectedValue;
            Session["codgrado"] = DropGrados.SelectedValue;

            if (Session["codsede"].ToString() != "")
            {
                string script = @"<script type='text/javascript'> 
                            $('#agregar').fadeIn(500);
                            $('#VerRed').hide();$('#CrearRed').hide();$('#Modificarfecha').hide();
            </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                btnnuevoEstudiante.Visible = false;
                lnkVolverEditarDatosEstudiante.Visible = true;
                lnkVolver.Visible = false;

                txtNomEstudianteNuevo.Text = "";
                txtNomApellidoNuevo.Text ="";
                txtFechaN.Text = "";
                txtTelefonoNuevo.Text = "";
                txtDireccionNuevo.Text = "";
                txtemailNuevo.Text = "";
                txtIDEstudianteNuevo.Text = "";
                
            }
            else
            {
                string script = @"<script type='text/javascript'> 
                                $('#agregar').hide();
                                $('#VerRed').hide();$('#CrearRed').show();
                                alert('Debe seleccionar la sede y el grado.');$('#Modificarfecha').hide();
            </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        else
        {
            string script = @"<script type='text/javascript'> 
                                $('#agregar').hide();
                                $('#VerRed').hide();$('#CrearRed').show();
                                alert('Debe seleccionar la sede y el grado.');$('#Modificarfecha').hide();
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


            DataRow estudiante = estra.agregarEstudiantePG(txtNomEstudianteNuevo.Text, txtNomApellidoNuevo.Text, txtIDEstudianteNuevo.Text, dropSexo.SelectedValue, fun.convertFechaAño(txtFechaN.Text), txtTelefonoNuevo.Text, txtDireccionNuevo.Text, txtemailNuevo.Text, "1", "1");

            if (estudiante != null)
            {
                if (estra.agregarEstuMatricula(dropSedes.SelectedValue, estudiante["codigo"].ToString(), anio["codigo"].ToString(), fun.getFechaAñoHoraActual(), DropGrados.SelectedValue, "2", dropGrupo.SelectedValue))
                {
                    //ca += "true@";
                    txtNomEstudianteNuevo.Text="";
                    txtNomApellidoNuevo.Text = ""; txtIDEstudianteNuevo.Text = ""; dropSexo.SelectedIndex = 0; txtFechaN.Text = ""; txtTelefonoNuevo.Text = ""; txtDireccionNuevo.Text = ""; txtemailNuevo.Text = "";
                    string script = @"<script type='text/javascript'>
                                 $('#agregar').hide();
                                $('#VerRed').hide();$('#CrearRed').show();
                                alert('Datos ingresados correctamente.');$('#Modificarfecha').hide();
                        </script>";

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    lnkVolver.Visible = true;
                    btnAgregarEstudiantes.Visible = false;
                    lnkVerGruposInvestigacion.Visible = false;
                    btnnuevoEstudiante.Visible = false;
                    lnkVolverEditarDatosEstudiante.Visible = false;
                    gvCargarEstudiantesDocentes();
                }
                else
                {
                    string script = @"<script type='text/javascript'>
                                $('#agregar').show();
                                $('#VerRed').hide();$('#CrearRed').hide();
                                alert('Error al matricular.');$('#Modificarfecha').hide();
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
                                alert('Error, la identificación ya se encuentra registrada en el sistema.');$('#Modificarfecha').hide();
                        </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
//                if (estra.agregarEstuMatricula(dropSedes.SelectedValue, estudiante["codigo"].ToString(), anio["codigo"].ToString(), fun.getFechaAñoHoraActual(), DropGrados.SelectedValue, "2"))
//                {
//                    //ca += "true@";
//                    string script = @"<script type='text/javascript'>
//                                 $('#agregar').hide();
//                                $('#VerRed').hide();$('#CrearRed').show();
//                                alert('Datos ingresados correctamente.');
//                        </script>";

//                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

//                    gvCargarEstudiantesDocentes();
//                }
//                else
//                {
//                    string script = @"<script type='text/javascript'>
//                                 $('#agregar').show();
//                                $('#VerRed').hide();$('#CrearRed').hide();
//                                alert('Error al matricular.');
//                        </script>";

//                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
//                }
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


    [WebMethod(EnableSession = true)]
    public static string agregarEstudiante(string txtIDEstudianteNuevo, string txtNomEstudianteNuevo, string txtNomApellidoNuevo, string dropsexo, string txtFechaNacimiento, string txtTelefonoNuevo, string txtDireccionNuevo, string txtemailNuevo, string dropSedes,string dropGrados)
    {
        string ca = "";

        confiredtematica cf = new confiredtematica();
      
            Estudiantes estra = new Estudiantes();
            Funciones fun = new Funciones();
            Institucion ins = new Institucion();
            DataRow anio = ins.buscarAnioON();

        //if (HttpContext.Current.Session["codsede"] != null || HttpContext.Current.Session["codgrado"] != null)
        //{
           
            DataRow estudiante = estra.agregarEstudiantePG(txtNomEstudianteNuevo, txtNomApellidoNuevo, txtIDEstudianteNuevo, dropsexo, fun.convertFechaAño(txtFechaNacimiento), txtTelefonoNuevo, txtDireccionNuevo, txtemailNuevo, "1", "1");

            if (estudiante != null)
            {
                if (estra.agregarEstuMatricula(dropSedes, estudiante["codigo"].ToString(), anio["codigo"].ToString(), fun.getFechaAñoHoraActual(), dropGrados, "2",""))
                {
                    ca += "true@";
                    HttpContext.Current.Session["codsede"] = null;
                    HttpContext.Current.Session["codgrado"] = null;

                    confiredtematica rt = new confiredtematica();

                  

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
        //}
        //else
        //{
        //    ca += "errorSeleccion@";
        //}

      

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string actualizarEstudiante(string txtIDEstudianteNuevo, string txtNomEstudianteNuevo, string txtNomApellidoNuevo, string dropsexo, string txtFechaNacimiento, string txtTelefonoNuevo, string txtDireccionNuevo, string txtemailNuevo)
    {
        string ca = "";
        //Estudiantes estra = new Estudiantes();
        //Funciones fun = new Funciones();
        //if (estra.ActualizarEstudiante(txtIDEstudianteNuevo, txtNomEstudianteNuevo, txtNomApellidoNuevo, fun.convertFechaAño(txtFechaNacimiento), dropsexo, txtTelefonoNuevo, txtDireccionNuevo, txtemailNuevo))
        //{
        //    ca += "true@";
        //}
        //else
        //{
        //    ca += "error@";
        //}

        return ca;
    }

    //Docentes
    protected void btnDeseleccionarDocentes_Click(object sender, EventArgs e)
    {
        ((DataTable)Session["myDatatableDoc"]).Clear();
        BindGridDoc();

        string script = @"<script type='text/javascript'>
                                $('#VerRed').hide(),$('#CrearRed').show();$('#Modificarfecha').hide();
                        </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
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
                AddDataToTableDoc(codgradodocente, identificacion, nomdocente, (DataTable)Session["myDatatableDoc"]);
                val++;
            }
        }

        if (val == 0)
        {
            string script = @"<script type='text/javascript'>
                                alert('Seleccione el/los docentes que van a pertenecer como líderes a la Red Temática');
                                $('#VerRed').hide(),$('#CrearRed').show();$('#Modificarfecha').hide();
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
        else
        {
            BindGridDoc();
            PanelNomRedtematica.Visible = true;
            ddRedTematica(dropRedTematica);
            btnDeseleccionarDocentes.Visible = true;
            string script = @"<script type='text/javascript'>
                                $('#VerRed').hide(),$('#CrearRed').show();$('#Modificarfecha').hide();
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }

    }

    protected void btnMoverDocente_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        string codgradodocente = GridDocentes.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string iddocente = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        string nomdocente = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);

        Session["codgradodocente"] = codgradodocente;

        ddSedes(dropSedeMover, dropInstituciones.SelectedValue);

        string script = @"<script type='text/javascript'> 
            $('#VerRed').hide();$('#CrearRed').hide();$('#agregar').hide();$('#mover').fadeIn(500);$('#Modificarfecha').hide();
            </script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

        btnnuevoEstudiante.Visible = false;
        lnkVolver.Visible = false;
        lnkVolverMoverDocente.Visible = true;
    }

    protected void lnkMoverDocente_Click(object sender, EventArgs e)
    {
        if (Session["codgradodocente"] != null)
        {
            lnkVerGruposInvestigacion.Visible = false;
            btnnuevoEstudiante.Visible = false;
            lnkVolver.Visible = false;
            lnkVolverMoverDocente.Visible = true;
            if (doc.MoverDocenteDeSede(dropSedeMover.SelectedValue, Session["codgradodocente"].ToString(), dropAnio.SelectedValue))
            {
                string script = @"<script type='text/javascript'> 
                                alert('Docente movido correctamente.');
                                $('#VerRed').hide();$('#CrearRed').fadeIn(500);$('#agregar').hide();$('#mover').hide();$('#Modificarfecha').hide();
                </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                gvCargarEstudiantesDocentes();
            }
            else
            {
                string script = @"<script type='text/javascript'> 
                                alert('Error al mover Docente');
                                 $('#VerRed').hide();$('#CrearRed').hide();$('#agregar').hide();$('#mover').show();$('#Modificarfecha').hide();
                </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
            }
        }
        else
        {
            string script = @"<script type='text/javascript'> 
                            alert('No hay docente seleccionado.');
                                $('#VerRed').hide();$('#CrearRed').hide();$('#agregar').hide();$('#mover').show();$('#Modificarfecha').hide();
                </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
    }

    protected void lnkVolverMoverDocente_Click(object sender, EventArgs e)
    {
        string script = @"<script type='text/javascript'>
                    $('#VerRed').hide(),$('#CrearRed').fadeIn(500),$('#agregar').hide(),$('#mover').hide();$('#Modificarfecha').hide();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        lnkVerGruposInvestigacion.Visible = false;
        lnkVolverMoverDocente.Visible = false;
        btnnuevoEstudiante.Visible = false;
        lnkVolver.Visible = true;
    }

    [WebMethod(EnableSession = true)]
    public static string moverDocente(string dropsede, string dropAnio)
    {
        string ca = "";
        Docentes estra = new Docentes();

        if (HttpContext.Current.Session["codgradodocente"] != null)
        {
           
            if (estra.MoverDocenteDeSede(dropsede, HttpContext.Current.Session["codgradodocente"].ToString(), dropAnio))
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
    protected void btnRedTematicaCreada_Click(object sender, EventArgs e)
    {
        Response.Redirect("confiredtematicaedicion.aspx");
    }

    protected void lnkVolver_Click(object sender, EventArgs e)
    {
        string script = @"<script type='text/javascript'>$('#MainContent_btnnuevoEstudiante').hide(),$('#MainContent_lnkVolver').hide(),$('#CrearRed').hide(),$('#VerRed').fadeIn(500);
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        lnkVerGruposInvestigacion.Visible = true;
        //btnnuevoEstudiante.Visible = false;
        //lnkVolver.Visible = false;
    }

    protected void lnkCrearRedesTematicas_Click(object sender, EventArgs e)
    {
        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').fadeIn(500);$('#Modificarfecha').hide();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        lnkVerGruposInvestigacion.Visible = false;
        btnAgregarEstudiantes.Enabled = true;
        btnnuevoEstudiante.Visible = false;
        lnkVolver.Visible = true;
        dropDepartamento.SelectedIndex = 0;
        dropMunicipio.Items.Clear();
        dropInstituciones.Items.Clear();

    }

    private void cargarRedesxAsesor()
    {

        DataTable datos = estr.cargarRedesTematicasxAsesor(Session["codasesorcoordinador"].ToString());
        GridRed.DataSource = datos;
        GridRed.DataBind();

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

            $('#CrearRed').hide(),$('#VerRed').show(),$('#lnkCrearRedesTematicas').hide();
            </script>";

        string ca = "";

        DataTable datos = est.cargarEstudiantesxRedTematica(codproyectosede);

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
            $('#CrearRed').hide(), $('#VerRed').show(),$('#lnkCrearRedesTematicas').hide();$('#Modificarfecha').hide();
            </script>";

        string ca = "";

        DataTable datos = est.cargarDocentesxRedTematica(codproyectosede);

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


    protected void lnkFechaRed_Click(object sender, EventArgs e)
    {
        LinkButton btndetails = sender as LinkButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codredtematicasede = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        lblCodRedTematica.Text = codredtematicasede;

        Session["codredtematicasede"] = codredtematicasede;

        string script = @"<script type='text/javascript'> 
            $('#CrearRed').hide(), $('#VerRed').hide(),$('#lnkCrearRedesTematicas').hide();$('#Modificarfecha').fadeIn(500)
            
            </script>";

        DataRow fecha = estr.buscarRedTematicaxCodModificarFecha(codredtematicasede);
        if (fecha != null)
        {
            lblFechaRed.Text = fecha["fechacreacion"].ToString();
        }

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }

    protected void lnkModificarFecha_Click(object sender, EventArgs e)
    {
        //if (estr.ActualizarFechaRedTematica(lblCodRedTematica.Text, fun.convertFechaAño(txtFechaModificar.Text) + " " + fun.getHoraActual(), fun.getFechaAñoHoraActual()))
        if (estr.ActualizarFechaRedTematica(lblCodRedTematica.Text, dropAnioRed.SelectedValue, fun.getFechaAñoHoraActual()))
        {
            Response.Redirect("confiredtematica.aspx");
            string script = @"<script type='text/javascript'> 
            $('#CrearRed').hide(), $('#VerRed').fadeIn(500),$('#lnkCrearRedesTematicas').hide();$('#Modificarfecha').hide();
            alert('Fecha actualizada correctamente');
            </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

        }
        else
        {
            string script = @"<script type='text/javascript'> 
            $('#CrearRed').hide(), $('#VerRed').hide(),$('#lnkCrearRedesTematicas').hide();$('#Modificarfecha').show()
            </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
        cargarRedesxAsesor();
       
    }

    //[WebMethod(EnableSession = true)]
    //public static string ModificarFecha(string fecha)
    //{
    //    string ca = "";

    //    Estrategias estr = new Estrategias();
    //    Funciones fun = new Funciones();

    //    if (estr.ActualizarFechaRedTematica(HttpContext.Current.Session["codredtematicasede"].ToString(), fun.convertFechaDia(fecha) + " " + fun.getHoraActual()))
    //    {
    //        ca = "exito";
    //    }
    //    else
    //    {
    //        ca = "error";
    //    }

    //    return ca;
    //}

    protected void lnkEditarRed_Click(object sender, EventArgs e)
    {
        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').fadeIn(500);$('#Modificarfecha').hide();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        btnAgregarEstudiantes.Visible = true;
        lnkVerGruposInvestigacion.Visible = false;

        LinkButton btndetails = sender as LinkButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codredtematicasede = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

        Session["codredtematica"] = codredtematicasede;

        Response.Redirect("confiredtematicaeditar.aspx");
    }
    protected void lnkEliminarRedTematica_Click(object sender, EventArgs e)
    {
        LinkButton btndetails = sender as LinkButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        string codredtematicasede = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        est.eliminarEstudianteRedTematica(codredtematicasede) ;
        est.eliminarDocenteRedTematica(codredtematicasede);
        est.eliminarRedTematicaSede(codredtematicasede);

        DataTable datos = est.buscarDatoS004(codredtematicasede);
        if(datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                est.eliminarPreguntasS004(datos.Rows[i]["codigo"].ToString());
            }

        }
        string script = @"<script type='text/javascript'>
                    alert('Datos eliminados correctamente.');
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        dropDepartamento.SelectedIndex = 0;
        dropMunicipio.Items.Clear();

        cargarRedesxAsesor();

    }

    protected void lnkEliminarEstudianteRedTematica_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codestumatricula = GridEstudiante.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string codestudiante = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

        DataRow dat = est.buscarestumatriculaRedTematica(codestumatricula);
        if(dat != null)
        {
            string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();alert('Este estudiante no se puede eliminar, ya pertenece a una red temática');$('#Modificarfecha').hide();
                 </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
        else
        {
            if(est.eliminarEstumatricula(codestumatricula,"2"))
            {
                //if(est.eliminarEstudiante(codestudiante))
                //{
                string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();alert('Estudiante eliminado correctamente.');$('#Modificarfecha').hide();
                    </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);                
                //}
            }
        }

        gvCargarEstudiantesDocentes();

    }

     //Borra todos los estudiantes chequeados  - Roger Jimenez
    protected void btnBorrarSeleccionados_Click(object sender, EventArgs e)
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
                DataRow dat = est.buscarestumatriculaRedTematica(codestumatricula);
                if (dat != null)
                {
                    string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();alert('Algunos Estudiantes seleccionados no se han podido eliminar, ya pertenecen a una red temática');$('#Modificarfecha').hide();
                                 </script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                }
                else
                {
                    if (est.eliminarEstumatricula(codestumatricula, "2"))
                    {
                        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();alert('Todos los Estudiantes Seleccionados fueron eliminados correctamente.');$('#Modificarfecha').hide();
                    </script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                    }
                }
                val++;
            }
        }
        if (val == 0)
        {
            string script = @"<script type='text/javascript'>
                                alert('Seleccione por lo menos un Estudiante a eliminar');
                                $('#VerRed').hide(),$('#CrearRed').show();$('#Modificarfecha').hide();
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
        gvCargarEstudiantesDocentes();       
    }

    protected void chkseleccionartodo_Click(object sender, EventArgs e)
    {
        CheckBox ChkBoxHeader = (CheckBox)GridEstudiante.HeaderRow.FindControl("chkseleccionartodo");
        foreach (GridViewRow row in GridEstudiante.Rows)
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
        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();$('#Modificarfecha').hide();
                    </script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }

    
}