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



public partial class confimesadetrabajoeditar : System.Web.UI.Page
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

            if (Session["codmesadetrabajo"] != null)
            {

              
                    //lblRealizado.Visible = true;
                    //lblRealizado.Text = "Grupo de Investigación creado con éxito";
                DataRow dat = est.buscarMesadeTrabajoSedexCod(Session["codmesadetrabajo"].ToString());

                    if (dat != null)
                    {
                        ddAnio(dropAnio);
                        ddDepartamentos(dropDepartamento);
                        ddMunicipios(dropMunicipio);
                        ddInstituciones(dropInstituciones);
                        ddSedes(dropSedes);
                        //ddMesadeTrabajo(dropGrupoInvestigacion);
                        //ddLineaInvestigacion(dropLineaInvestigacion);

                        dropDepartamento.SelectedValue = dat["coddepartamento"].ToString();
                        dropMunicipio.SelectedValue = dat["codmunicipio"].ToString();
                        dropInstituciones.SelectedValue = dat["codinstitucion"].ToString();
                        dropSedes.SelectedValue = dat["codsede"].ToString();
                        dropGrupoInvestigacion.Text = dat["nombregrupo"].ToString();
                        //dropLineaInvestigacion.SelectedValue = dat["codlineainvestigacion"].ToString();

                        lblCodProyectoSede.Text = dat["codmesadetrabajo"].ToString();
                        lblCodSede.Text = dat["codsede"].ToString();
                        lblCodGrupoInvestigacion.Text = Session["codmesadetrabajo"].ToString();

                        gvcargarDocentesAcompañantes(lblCodProyectoSede.Text);
                        gvcargarAsesoresxMesadeTrabajo(lblCodProyectoSede.Text);

                        //btnAgregarEstudiante.Visible = true;
                        btnAgregarDocente.Visible = true;
                        btnagregarAsesor.Visible = true;

                        //GridEstudiante.Visible = true;
                        GridDocentes.Visible = true;
                        GridAsesor.Visible = true;

                        dropDepartamento.Enabled = false;
                        dropMunicipio.Enabled = false;
                        dropInstituciones.Enabled = false;
                        dropSedes.Enabled = false;
                        //dropGrupoInvestigacion.Enabled = false;
                        //dropLineaInvestigacion.Enabled = false;

                        dropAnio.Enabled = false;
                    }
             

              
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
    private void ddMesadeTrabajo(DropDownList drop)
    {
        DataTable datos = est.cargarTodoMesadeTrabajo();
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



    private void gvcargarDocentesAcompañantes(string codmesadetrabajo)
    {
        DataTable datos = est.cargarDocentesxSedexMesadeTrabajo(codmesadetrabajo);
        GridDocentes.DataSource = datos;
        GridDocentes.DataBind();

        if(datos != null && datos.Rows.Count > 0)
        {
            dropAnio.SelectedValue = datos.Rows[0]["codanio"].ToString();
        }
    }

    private void gvcargarAsesoresxMesadeTrabajo(string codmesadetrabajo)
    {
        GridAsesor.DataSource = est.cargarAsesorxMesadeTrabajoxSede(codmesadetrabajo);
        GridAsesor.DataBind();
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

   
    
    protected void DeleteDocenteActivo_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        string codgradodocente = GridDocentes.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  

        if (estu.eliminarMatriculaDocenteMesaTrabajo(lblCodGrupoInvestigacion.Text, codgradodocente)) { }
        gvcargarDocentesAcompañantes(lblCodGrupoInvestigacion.Text);

    }
    protected void DeleteAsesorActivo_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        //string codproyectosede = GridAsesor.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row 
        string codgradodocente = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

        if (estu.eliminarMatriculaAsesorGrupoInvestigacion(codgradodocente)) { }
        gvCargarAsesorxEstrategia1("2");
        gvcargarAsesoresxMesadeTrabajo(lblCodGrupoInvestigacion.Text);

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
                if (est.agregarDocentexSedexMesdeTrabajo(codgradodocente, lblCodGrupoInvestigacion.Text))
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

            gvCargarAsesorxEstrategia1("2");
            gvcargarAsesoresxMesadeTrabajo(lblCodGrupoInvestigacion.Text);
            
        }
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Session["codgrupoinvestigacion"] = null;
        dropSedes.Items.Clear();
       
        dropGrupoInvestigacion.Text = "";
        //dropLineaInvestigacion.Items.Clear();
        dropInstituciones.SelectedIndex = 0;
       
        PanelVerDocentes.Visible = false;
        PanelVerAsesores.Visible = false;
        
        GridDocentes.Visible = false;
        GridAsesor.Visible = false;
       
        btnAgregarDocente.Visible = false;
        btnagregarAsesor.Visible = false;
        Response.Redirect("confimesadetrabajo.aspx");
    }
    protected void UploadRepositorio_Click(object sender, ImageClickEventArgs e)
    {

        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

        //string codgradodocente = GridDocentes.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string codgradodocente = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        Session["codgradodocente"] = codgradodocente;

        Response.Redirect("confimesadetrabajoevidencia.aspx?codgradodocente=" + Session["codgradodocente"].ToString() + "&codmesadetrabajo=" + Session["codmesadetrabajo"].ToString());

    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        if (est.editarmesadetrabajodocente(dropGrupoInvestigacion.Text, lblCodProyectoSede.Text))
        {
            string script = @"<script type='text/javascript'>
                                alert('Datos editado correctamente.');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
        else
        {
            string script = @"<script type='text/javascript'>
                                alert('Error al editar nombre.');
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
    }
    
}