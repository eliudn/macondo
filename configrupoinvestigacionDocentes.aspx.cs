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

public partial class configrupoinvestigacionDocentes : System.Web.UI.Page
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

            //DataRow dato = estr.buscarCodEstraAsesorxCoordinador(Session["identificacion"].ToString());

            //if (dato != null)
            //{
            //    Session["CodAsesorEstraCoordinador"] = dato["codigo"].ToString();

            //}
            DataRow dat = ase.buscarAsesorxEstrategiaxIdentificacion(Session["identificacion"].ToString());

            if (dat != null)
            {
                Session["codasesorestrategia"] = dat["codasesorcoordinador"].ToString();
            }

            lblTipoUsuario.Text = Session["codrol"].ToString();
            //ddGrados(DropGrados);
            if (lblTipoUsuario.Text == "15" || lblTipoUsuario.Text == "9")
            {
                
                ddDepartamentos(dropDepartamento);
                ddAnio(dropAnio);
                //ddInstituciones(dropInstituciones);

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
    
   

   
   
    protected void btnAgregarEstudiantes_Click(object sender, EventArgs e)
    {
        if ( Session["codasesorestrategia"] != null)//Valida que la tabla Seleccionar estudiantes este llena
        {
            int valDoc = 0;

            DataRow grupo = estr.agregarGrupoInvestigacionxSedeDocente(dropSedes.SelectedValue, fun.getFechaAñoHoraActual(), Session["codasesorestrategia"].ToString(), "0", "0", txtNomGrupoInvestigacion.Text);

            if (grupo != null)
            {
                Session["codgrupoinvestigacion"] = grupo["codigo"].ToString();
               
                foreach (GridViewRow row2 in GridSeleccionDocentes.Rows)
                {
                    string codgradodocente = HttpUtility.HtmlDecode(row2.Cells[0].Text);
                    if (estr.agregarDocentexSedexGrupoInvestigacion(codgradodocente, grupo["codigo"].ToString()))
                    {
                        valDoc++;
                    }
                }
            }
           
            if (valDoc > 0)
            {

               
                GridDocentes.Visible = false;
                //dropLineaIngestigacion.SelectedIndex = 0;
                dropInstituciones.SelectedIndex = 0;
                dropSedes.Items.Clear();
                //DropGrados.SelectedIndex = 0;
               
                btnDeseleccionarDocentes.Visible = false;
              
                btnSeleccionarDocente.Visible = false;
                PanelLineaIngestigacion.Visible = false;
                btnAgregarEstudiantes.Visible = false;
                txtNomGrupoInvestigacion.Text = "";

                ((DataTable)Session["myDatatableDocGI"]).Clear();
             

                lnkVolver.Visible = false;
                lnkVerGruposInvestigacion.Visible = true;

                cargarGruposxAsesor();

             
                string script = @"<script type='text/javascript'> 
                alert('Grupo de Investigación creado exitosamente.');
               $('#agregar').hide(); $('#verGrupos').fadeIn(500); $('#conformar').hide();$('#mover').hide();
            </script>";
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

             
            }
            else if (valDoc == 0)
            {

                string script = @"<script type='text/javascript'>
                                  $('#agregar').hide(); $('#conformar').show(); $('#verGrupos').hide();$('#mover').hide();
                                alert('Error al crear Grupo de Investigación.');
                        </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

                cargarGruposxAsesor();

               
               
            }
          
        }
        else
        {
            string script = @"<script type='text/javascript'>
                                $('#agregar').hide(); $('#conformar').show(); $('#verGrupos').hide();$('#mover').hide();
                                alert('No hay estudiantes para ingresar en la Grupo de Investigación.');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
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

       
        lnkVolver.Visible = false;
        lnkVolverMoverDocente.Visible = true;
    }

    protected void btnMoverDocente_Click(object sender, EventArgs e)
    {
        if (Session["codgradodocente"] != null)
        {
            lnkVerGruposInvestigacion.Visible = false;
          
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
       
        lnkVolver.Visible = true;
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
            //ddLineaInvestigacion(dropLineaIngestigacion);
            //ddAreas(dropArea);
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
        
    }

    private void cargarGruposxAsesor()
    {

        DataTable datos = estr.cargarGruposInvestigacionDocentexAsesor(Session["codasesorestrategia"].ToString());
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
            $('#conformar').hide(), $('#MainContent_btnAgregarNuevoEstudiante').hide(),$('#verGrupos').show(),$('#lnkVerGruposInvestigacion').hide();
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
        btnAgregarEstudiantes.Visible = true;
        lnkVerGruposInvestigacion.Visible = false;

        LinkButton btndetails = sender as LinkButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codgrupoinvestigacion = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

        Session["codgrupoinvestigacion"] = codgrupoinvestigacion;

        Response.Redirect("configrupoinvestigaciondocenteeditar.aspx");
    }

    protected void lnkEliminarGrupo_Click(object sender, EventArgs e)
    {
        LinkButton btndetails = sender as LinkButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        string codgrupo = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        estr.eliminarDocentesS003GrupoInvestigacionTodo(codgrupo);
        estr.eliminaS003rGrupoInvestigacionSede(codgrupo);
        estr.eliminarS003xGrupo(codgrupo);

      
        string script = @"<script type='text/javascript'>
                    alert('Datos eliminados correctamente.');
                     $('#agregar').hide(); $('#conformar').hide(); $('#verGrupos').show();$('#mover').hide();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        dropDepartamento.SelectedIndex = 0;
        dropMunicipio.Items.Clear();

        cargarGruposxAsesor();

    }

    protected void lnkInstrumentoS003_Click(object sender, EventArgs e)
    {
        LinkButton btndetails = sender as LinkButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codgrupoinvestigacion = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

        Session["codgrupoinvestigacion"] = codgrupoinvestigacion;

        Response.Redirect("estras003.aspx");
    }

    protected void lnkEvidencia_Click(object sender, EventArgs e)
    {
        LinkButton btndetails = sender as LinkButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codgrupoinvestigacion = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

        Response.Redirect("configrupodocente_evi.aspx?cod=" + codgrupoinvestigacion);
    }

}