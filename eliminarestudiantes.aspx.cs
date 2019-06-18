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

public partial class eliminarestudiantes : System.Web.UI.Page
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
            ddDepartamentos(dropDepartamento);
        }
        
    }
    //Preparamos la tabla virtual para los estudiantes 
    
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
        lblResultado.Text = "";
        gvCargarEstudiantesDocentes();

    }

    private void gvCargarEstudiantesDocentes()
    {
        DataTable estudiantes = est.cargarEstudiantexSedexGrado(dropSedes.SelectedValue, DropGrados.SelectedValue, "2");



        if (estudiantes != null && estudiantes.Rows.Count > 0)
        {
            DataView dw = estudiantes.DefaultView;
            dw.Sort = "nombre asc";
            GridEstudiante.DataSource = dw.ToTable();
            GridEstudiante.DataBind();
            GridEstudiante.Visible = true;
            btnSeleccionarEstudiantes.Visible = true;

        }
        else
        {
            GridEstudiante.Visible = false;
            btnSeleccionarEstudiantes.Visible = false;
        }

        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
    }

    protected void btnSeleccionarEstudiantes_Click(object sender, EventArgs e)
    {
        int val = 0;
        int error = 0;
        string ca = "";
      
        foreach (GridViewRow row in GridEstudiante.Rows)
        {
            string codestumatricula = GridEstudiante.DataKeys[row.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
            string idestudiante = GridEstudiante.Rows[row.RowIndex].Cells[2].Text;
            string nomestudiante = GridEstudiante.Rows[row.RowIndex].Cells[3].Text;
            string gradoestudiante = GridEstudiante.Rows[row.RowIndex].Cells[4].Text;

            DataRow dat = est.buscarestumatriculaRedTematica(codestumatricula);
            if (dat != null)
            {
                error++;
                ca += "Identificación: " + idestudiante + ", Nombre: " + nomestudiante + "<br />";
            }
            else
            {
                if (est.eliminarEstumatricula(codestumatricula, "2"))
                {
                    if (est.eliminarEstudianteID(idestudiante))
                    {
                        val++;
                    }
                }
            }

        }

        if(error > 0)
        {
            lblResultado.Text = "<b>Estos estudiantes ya pertenecen a una red temática: Imposible eliminar! </b><br />" + ca;
            gvCargarEstudiantesDocentes();
        }
        else
        {
          

            string script = @"<script type='text/javascript'>
                            alert('Eiminados correctamente');
                                $('#VerRed').hide(),$('#CrearRed').show();
                        </script>";

            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

            gvCargarEstudiantesDocentes();
        }
      
    }
 
}