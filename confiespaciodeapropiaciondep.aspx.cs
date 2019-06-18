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

public partial class confiespaciodeapropiacion : System.Web.UI.Page
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
            ddMunicipios(dropMunicipiosSedes,"20");
           
            dropDepartamento.Enabled = false;

            DataTable dt = new DataTable();
            dt = CreateDataTable();
            Session["myDatatable"] = dt;
            ViewState["dt"] = dt;
            this.GridSeleccionMunicipios.DataSource = ((DataTable)Session["myDatatable"]).DefaultView;
            this.GridSeleccionMunicipios.DataBind();

            DataTable dtGrupos = new DataTable();
            dtGrupos = CreateDataTableGrupos();
            Session["myDatatableGrupos"] = dtGrupos;
            ViewState["dtGrupos"] = dtGrupos;
            this.GridSeleccionGrupos.DataSource = ((DataTable)Session["myDatatableGrupos"]).DefaultView;
            this.GridSeleccionGrupos.DataBind();

            DataRow dat = ase.buscarAsesorCoordinadorEstrategiaxIdentificacion(Session["identificacion"].ToString());

            if (dat != null)
            {
                Session["codasesorcoordinador"] = dat["codasesorcoordinador"].ToString();
            }

            cargarFeriasMunicipales();

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
    private void ddGrupos(DropDownList drop)
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
        myDataTable.Columns.AddRange(new DataColumn[4] { new DataColumn("coddepartamento"), new DataColumn("cod"), new DataColumn("tipo"), new DataColumn("nombre") });
        return myDataTable;
    }
    private void AddDataToTable(string coddepartamento, string cod, string tipo, string nombre, DataTable myTable)
    {
        myTable.Rows.Add(coddepartamento, cod, tipo, nombre);
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
    
    protected void GridSeleccionGrupos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int index = Convert.ToInt32(e.RowIndex);
        DataTable dt = ((DataTable)Session["myDatatableGrupos"]);

        dt.Rows[index].Delete();
        ViewState["dtGrupos"] = dt;
        BindGridGrupos();

        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();
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
        DataTable datos = ins.cargarDepartamentoMagdalena();
        drop.DataSource = datos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));

        if (datos != null && datos.Rows.Count > 0)
        {
            dropDepartamento.SelectedValue = datos.Rows[0]["cod"].ToString();
            gvCargarEstudiantesDocentes();
        }

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
        ddInstituciones(dropInstituciones, dropMunicipiosSedes.SelectedValue);

        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }
    protected void dropInstituciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddSedes(dropSedes, dropInstituciones.SelectedValue);

        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();
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
  
    protected void btnBuscar_Onclick(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);

        gvCargarEstudiantesDocentes();

    }

    private void gvCargarEstudiantesDocentes()
    {
        DataTable municipios = est.cargarmunicipios(dropDepartamento.SelectedValue);



        if (municipios != null && municipios.Rows.Count > 0)
        {
            DataView dw = municipios.DefaultView;
            dw.Sort = "nombre asc";
            GridMunicipio.DataSource = dw.ToTable();
            GridMunicipio.DataBind();
            GridMunicipio.Visible = true;
            btnSeleccionarEstudiantes.Visible = true;
            //btnBorrarSeleccion.Visible = true;
            lblEstudentVacio.Visible = false;
            //chkseleccionartodo.Visible = true;

        }
        else
        {
            GridMunicipio.Visible = false;
            btnSeleccionarEstudiantes.Visible = false;
            lblEstudentVacio.Text = "<b style='color:red;'>No hay Municipios</b>";
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
                AddDataToTable(coddepartamento, cod, tipo, nombre, (DataTable)Session["myDatatable"]);
                val++;
            }
        }

        if(val == 0)
        {
            string script = @"<script type='text/javascript'>
                                alert('Seleccione los Municipios donde se realizaron las Ferias Municipales');
                                $('#VerRed').hide(),$('#CrearRed').show();
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);  
        }
        else
        {
            BindGrid();
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

    
    private void ddRedTematica(DropDownList drop)
    {
        drop.DataSource = est.cargarRedesTematicas();
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }

    protected void lnkEvidenciasIns_Click(object sender, EventArgs e)
    {
        LinkButton btndetails = sender as LinkButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        //string codredtematica = GridFeria.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string codredtematica = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        string coddepartamento = HttpUtility.HtmlDecode(gvrow.Cells[7].Text);

        Response.Redirect("confiespaciodeapropiaciondepevidenciasinsc.aspx?cod=" + codredtematica + "&coddep=" + coddepartamento);
    }

    protected void lnkEvidencias_Click(object sender, EventArgs e)
    {
        LinkButton btndetails = sender as LinkButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        //string codredtematica = GridFeria.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string codredtematica = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

        Response.Redirect("confiespaciodeapropiaciondepevidencias.aspx?cod=" + codredtematica);
    }


    protected void lnkVolverEditarDatosEstudiante_Click(object sender, EventArgs e)
    {
        string script = @"<script type='text/javascript'> 
                $('#agregar').hide();
                $('#VerRed').hide();$('#CrearRed').fadeIn(500);
            </script>";
        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

        lnkVolver.Visible = true;
        lnkVolverEditarDatosEstudiante.Visible = false;
    }
    protected void btnAgregarEstudiantes_Click(object sender, EventArgs e)
    {
      
            int val = 0;
            int val2 = 0;
            DataRow feriam = est.agregarFeriaMunicipalxDepartamento(dropDepartamento.SelectedValue, nombreferiamunicipal.Text, numeroasistentes.Text, numerogrupos.Text, numerodocentes.Text, fechaelaboracion.Text, horaferia.SelectedValue, horaferiafinal.SelectedValue, fechaelaboracioncierre.Text, horaferiacierre.SelectedValue, horaferiafinalcierre.SelectedValue);

                if (feriam != null)
                {
                     Session["cod"] = feriam["codigo"].ToString();
                    foreach (GridViewRow row in GridSeleccionMunicipios.Rows)
                    {
                        string codmunicipiomatricula = HttpUtility.HtmlDecode(row.Cells[1].Text);
                        DataRow feriamunicipalmatricula = est.agregarMunicipioxFeriaMunicipal(feriam["codigo"].ToString(), codmunicipiomatricula);
                        if (feriamunicipalmatricula != null)
                        {
                            val++;
                        }
                    }

                    //Relacionar los grupos
                    foreach (GridViewRow row2 in GridSeleccionGrupos.Rows)
                    {
                        string codgrupo = HttpUtility.HtmlDecode(row2.Cells[0].Text);
                        DataRow feriagrupomatricula = ins.agregarGruposxFeriaMunicipal(feriam["codigo"].ToString(), codgrupo);
                        if (feriagrupomatricula != null)
                        {
                            val2++;
                        }
                    }
                }
           
            if (val > 0 && val2 > 0)
            {
                GridMunicipio.Visible = false;
                GridGrupos.Visible = false;
              
                btnSeleccionarEstudiantes.Visible = false;
                lnkAgregarGrupo.Visible = false;
              
              
                ((DataTable)Session["myDatatable"]).Clear();
                BindGrid();

                ((DataTable)Session["myDatatableGrupos"]).Clear();
                BindGridGrupos();

                string script = @"<script type='text/javascript'>$('#CrearRed').hide(),$('#VerRed').fadeIn(500), alert('Feria Departamental creada exitosamente');
                     </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                btnAgregarEstudiantes.Visible = false;
                lnkVerGruposInvestigacion.Visible = true;
                lnkVolver.Visible = false;

                cargarFeriasMunicipales();

                //Session["realizado"] = "OK";

               
            }
            else if (val > 0 && val2 == 0)
            {
                nombreferiamunicipal.Text = "";
                numeroasistentes.Text = "";
                numerogrupos.Text = "";
                fechaelaboracion.Text = "";
                horaferia.SelectedIndex = 0;
                horaferiafinal.SelectedIndex = 0;
                GridMunicipio.Visible = false;
                btnSeleccionarEstudiantes.Visible = false;
              

                ((DataTable)Session["myDatatable"]).Clear();
                BindGrid();

                string script = @"<script type='text/javascript'>$('#CrearRed').hide(),$('#VerRed').fadeIn(500),alert('Feria Departamental creada exitosamente');
                     </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
               
                lnkVerGruposInvestigacion.Visible = true;
                

                cargarFeriasMunicipales();

              
            }
            else if (val == 0 && val2 > 0)
            {
                GridMunicipio.Visible = false;
                GridGrupos.Visible = false;
                lnkAgregarGrupo.Visible = false;
                btnSeleccionarEstudiantes.Visible = false;
               

                ((DataTable)Session["myDatatableGrupos"]).Clear();
                BindGridGrupos();

                string script = @"<script type='text/javascript'>$('#CrearRed').hide(),$('#VerRed').fadeIn(500),alert('Feria Municipal creada exitosamente, pero no se agregaron los municipios');
                     </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                btnAgregarEstudiantes.Visible = false;
                lnkVerGruposInvestigacion.Visible = true;

                cargarFeriasMunicipales();
            }
            else
            {
                ((DataTable)Session["myDatatable"]).Clear();
                BindGrid();

               

                string script = @"<script type='text/javascript'>$('#CrearRed').hide(),$('#VerRed').fadeIn(500), alert('Feria Departamental creada exitosamente');
                     </script>";
                lnkVerGruposInvestigacion.Visible = true;
                lnkVolver.Visible = false;


                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
                cargarFeriasMunicipales();
            }
       
    }

  
    protected void btnEntrar_click(object sender, EventArgs e)
    {

        Estudiantes estra = new Estudiantes();
        Funciones fun = new Funciones();
        Institucion ins = new Institucion();
        DataRow anio = ins.buscarAnioON();


            string script = @"<script type='text/javascript'>
                                alert('Debe seleccionar la sede y/o grado antes de ingresar al estudiante');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
       
     }


    protected void btnRedTematicaCreada_Click(object sender, EventArgs e)
    {
        Response.Redirect("confiespaciodeapropiacionedicion.aspx");
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
        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').fadeIn(500);
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        lnkVerGruposInvestigacion.Visible = false;
        btnAgregarEstudiantes.Enabled = true;
        lnkVolver.Visible = true;

        ddDepartamentos(dropDepartamento);
        //dropDepartamento.SelectedIndex = 0;
        //dropMunicipio.Items.Clear();
        //dropInstituciones.Items.Clear();

    }

    private void cargarFeriasMunicipales()
    {

        DataTable datos = estr.cargarFeriasDepartamentalesMaferpi();
        GridFeria.DataSource = datos;
        GridFeria.DataBind();

    }

    
    protected void lnkEliminarRedTematica_Click(object sender, EventArgs e)
    {
        LinkButton btndetails = sender as LinkButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        string codferiamunicipal = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        est.eliminarMunicipioFeriaMunicipal(codferiamunicipal);
        //est.eliminarDocenteRedTematica(codredtematicasede);
        est.eliminarferiadepartamental(codferiamunicipal);

      
        string script = @"<script type='text/javascript'>
                    alert('Datos eliminados correctamente.');
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        //dropDepartamento.SelectedIndex = 0;
        //dropMunicipio.Items.Clear();

        cargarFeriasMunicipales();

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

    protected void lnkEditarRed_Click(object sender, EventArgs e)
    {
        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').fadeIn(500);
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        //btnAgregarEstudiantes.Visible = true;
        //lnkVerGruposInvestigacion.Visible = false;

        LinkButton btndetails = sender as LinkButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codferiamunicipal = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

        Session["codigo"] = codferiamunicipal;

        Response.Redirect("confiespaciodeapropiacioneditardep.aspx");
    }

    protected void lnkAgregarGrupo_Click(object sender, EventArgs e)
    {
        int val = 0;
        foreach (GridViewRow row in GridGrupos.Rows)
        {
            string codigo = GridGrupos.DataKeys[row.RowIndex].Value.ToString(); //Obtener del DataKey de la Row
            string municipio = GridGrupos.Rows[row.RowIndex].Cells[2].Text;
            string institucion = GridGrupos.Rows[row.RowIndex].Cells[3].Text;
            string sede = GridGrupos.Rows[row.RowIndex].Cells[4].Text;
            string grupo = HttpUtility.HtmlDecode(GridGrupos.Rows[row.RowIndex].Cells[5].Text);
            CheckBox dd = (row.FindControl("chkListGrupo") as CheckBox);
            bool rb = dd.Checked;
            if (rb == true)
            {
                AddDataToTableGrupo(codigo, municipio, institucion, sede, grupo, (DataTable)Session["myDatatableGrupos"]);
                val++;
            }
        }

        if (val == 0)
        {
            string script = @"<script type='text/javascript'>
                                alert('Seleccione los grupos participantes');
                                $('#VerRed').hide(),$('#CrearRed').show();
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
        else
        {
            BindGridGrupos();
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



    protected void lnkBuscarGrupos_Click(object sender, EventArgs e)
    {

        DataTable datos = ins.cargarInfoGruposInvestigacionxCodSede(dropSedes.SelectedValue);
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

    protected void lnkApropiacionMaestros_Click(object sender, EventArgs e)
    {
        LinkButton btndetails = sender as LinkButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        //string codredtematica = GridFeria.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string cod = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

        Response.Redirect("confiapropiaciondptal.aspx?tipo=d" + cod);
    }
}