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

public partial class verestudiantesxsedes : System.Web.UI.Page
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
            //if (lblTipoUsuario.Text == "13")
            //{
                ddDepartamentos(dropDepartamento);
      
            //}
            //else if(lblTipoUsuario.Text == "9")
            //{
            //    ddDepartamentos(dropDepartamento);

            //}
            //else
            //{
            //    Response.Redirect("bienvenida.aspx");
            //}
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
        
        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }
    protected void dropMunicipio_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddInstituciones(dropInstituciones, dropMunicipio.SelectedValue);

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
               
                lblEstudentVacio.Visible = false;
                //chkseleccionartodo.Visible = true;

            }
            else
            {
                GridEstudiante.Visible = false;
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
               
                lblEstudentVacio.Visible = false;
                //chkseleccionartodo.Visible = true;

            }
            else
            {
                GridEstudiante.Visible = false;
               
                lblEstudentVacio.Text = "<b style='color:red;'>No hay estudiantes</b>";
            }
        }

        DataTable docentes = doc.cargarDocentesxSede(dropSedes.SelectedValue, dropAnio.SelectedValue);


        if (docentes != null && docentes.Rows.Count > 0)
        {
            GridDocentes.Visible = true;
          
            DataView dwd = docentes.DefaultView;
            dwd.Sort = "nomdocente asc";
            GridDocentes.DataSource = dwd.ToTable();
            GridDocentes.DataBind();
            lblDocVacio.Visible = false;

        }
        else
        {
            GridDocentes.Visible = false;
          
            lblDocVacio.Text = "<b style='color:red;'>No hay docentes</b>";
        }

        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }
}