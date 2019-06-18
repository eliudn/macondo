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

public partial class verestudiantesxsede_sindpto : System.Web.UI.Page
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
            ddInstituciones(dropInstituciones);
      
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
    
    private void ddInstituciones(DropDownList drop)
    {
        drop.DataSource = ins.cargarInstitucion();
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
   
   
    protected void dropInstituciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddSedes(dropSedes, dropInstituciones.SelectedValue);

        string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();
            </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);


        string script2 = "buscar();";
        if (ScriptManager1.IsInAsyncPostBack)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "scriptkey", script2, true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), script2, true);
        }

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
        btnBorrarSeleccion.Visible = true;
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

    protected void lnkEliminarMatricula_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codestumatricula = GridEstudiante.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string codestudiante = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

        DataRow dat = est.buscarestumatriculaRedTematica(codestumatricula);
        if (dat != null)
        {
            string script = @"<script type='text/javascript'>$('#VerRed').hide(),$('#CrearRed').show();alert('Este estudiante no se puede eliminar, ya pertenece a una red temática');$('#Modificarfecha').hide();
                 </script>";
            ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        }
        else
        {
            if (est.eliminarEstumatriculaxAnio(codestumatricula, "2", dropAnio.SelectedValue, dropGrupo.SelectedValue))
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
                    if (est.eliminarEstumatriculaxAnio(codestumatricula, "2", dropAnio.SelectedValue, dropGrupo.SelectedValue))
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
}