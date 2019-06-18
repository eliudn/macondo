using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class esturegistro : System.Web.UI.Page
{
    Funciones fun = new Funciones();
    Institucion ins = new Institucion();
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
        txtIdentificacion.Focus();
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 

        if (!IsPostBack)
        {
            ddTipoDocumento(dropTipoID);
            ddGrados(dropGrado);
            ddInstituciones(dropInstitucion);
            //ddDocente(dropDocente);
            ddEtnia(dropEtnia);
            ddAnio(dropAnio);
     
        }
    }
    private void ddAnio(DropDownList drop)
    {
        drop.DataSource = ins.cargarAnios();
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
    }
    private void ddTipoDocumento(DropDownList drop)
    {
        Estudiantes usu = new Estudiantes();
        DataTable datos = usu.cargarTipoDocumento();
        drop.DataSource = datos;
        drop.DataTextField = "abr";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddGrados(DropDownList drop)
    {
        Institucion usu = new Institucion();
        DataTable datos = usu.cargarGrados();
        drop.DataSource = datos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddEtnia(DropDownList drop)
    {
        Institucion usu = new Institucion();
        DataTable datos = usu.cargarEtnia();
        drop.DataSource = datos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddTipoGrupo(DropDownList drop)
    {
        Institucion usu = new Institucion();
        DataTable datos = usu.cargarTipoGrupo();
        drop.DataSource = datos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
     private void ddInstituciones(DropDownList drop)
        {
            Institucion usu = new Institucion();
            DataTable datos = usu.cargarSedesInstitucionTodo();
            drop.DataSource = datos;
            drop.DataTextField = "nombrecompleto";
            drop.DataValueField = "cod";
            drop.DataBind();
            drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));

            string script = "buscar();";
            if (ScriptManager1.IsInAsyncPostBack)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "scriptkey", script, true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), script, true);
            }
        }
     private void ddDocente(DropDownList drop)
     {
         Docentes usu = new Docentes();
         DataTable datos = usu.cargarDocentes();
         drop.DataSource = datos;
         drop.DataTextField = "nombrecompleto";
         drop.DataValueField = "codigo";
         drop.DataBind();
         drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));

         string script = "buscar();";
         if (ScriptManager1.IsInAsyncPostBack)
         {
             ScriptManager.RegisterStartupScript(this, typeof(Page), "scriptkey", script, true);
         }
         else
         {
             ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), script, true);
         }
     }
    private void cblRoles2(CheckBoxList rol)
    {
        Usuario usu = new Usuario();
        DataTable datos = usu.cargarRoles();
        rol.DataSource = datos;
        rol.DataTextField = "nombre";
        rol.DataValueField = "cod";
        rol.DataBind();
    }
    private void ddRoles(DropDownList drop)
    {
        Usuario usu = new Usuario();
        DataTable datos = usu.cargarRoles();
        drop.DataSource = datos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
  
 
    
    protected void GridUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string item = e.Row.Cells[1].Text;
            foreach (ImageButton button in e.Row.Cells[9].Controls.OfType<ImageButton>())
            {
                if (button.CommandName == "Delete")
                {
                    button.Attributes["onclick"] = "if(!confirm('Desea eliminar el usuario " + item + "?')){ return false; };";
                }
            }
        }
    }

    protected void btnAgregarUsuario_Click(object sender, EventArgs e)
    {
        Estudiantes est = new Estudiantes();
       Docentes doc = new Docentes();
       Institucion ins = new Institucion();

        DateTime localDateTime = DateTime.Now;
        DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
        string horares = utcDateTime.ToString("yyyy-MM-dd_HHmmss");

        DataRow datEstudiante = est.buscarEstudianteIngresado(txtIdentificacion.Text);

        if (datEstudiante == null)
        {
            DataRow datoSede = ins.buscarSedexCod(dropInstitucion.SelectedValue);
            DataRow codestudiante = est.agregarEstudiantePG(txtNombre.Text, txtApellidos.Text, txtIdentificacion.Text, dropGenero.SelectedValue, fun.convertFechaAño(txtFechaIniFiltro.Text), txtTelefono.Text, txtDireccion.Text, txtEmail.Text, dropTipoID.SelectedValue, dropEtnia.SelectedValue);
            if (codestudiante != null)
            {

                if (datoSede != null)
                {
                    if (est.agregarEstuMatricula(datoSede["codigo"].ToString(), codestudiante["codigo"].ToString(), dropAnio.SelectedValue, horares, dropGrado.SelectedValue, dropTipoGrupo.SelectedValue, dropGrupo.SelectedValue))
                    {
                        mostrarmensaje("exito","Estudiante agregado correctamente.");
                        txtIdentificacion.Text = "";
                        txtNombre.Text = "";
                        txtApellidos.Text = "";
                        txtFechaIniFiltro.Text = "";
                        txtTelefono.Text = "";
                        txtCelular.Text = "";
                        txtDireccion.Text = "";
                        txtEmail.Text = "";
                        dropEtnia.SelectedIndex = 0;
                        dropGrado.SelectedIndex = 0;
                        dropInstitucion.SelectedIndex = 0;
                    }
                    else
                    {
                        mostrarmensaje("error", "Error al matricular estudiante.");
                    }
                }
                else
                {
                    mostrarmensaje("error", "Sede no encontrada.");
                }
            }
            else
            {
                mostrarmensaje("error", "Error al agregar estudiante.");
            }
        }
        else
        {
            //Aquí es para agregar al estudiante que exista pero pertenece ya sea a una red temática o grupo de investigación
            if (est.editarDatosEstudiante(txtNombre.Text, txtApellidos.Text, txtIdentificacion.Text, dropGenero.SelectedValue, fun.convertFechaAño(txtFechaIniFiltro.Text))) { }//Actualiza los datos dle estudiante
            DataRow datoestudiante = est.buscarEstudianteIngresado(txtIdentificacion.Text);
            if (datoestudiante != null)
            {
                DataRow datoSede = ins.buscarSedexCod(dropInstitucion.SelectedValue);
                if (datoSede != null)
                {
                    DataRow validarEstudiante = est.buscarMatriculado(datoSede["codigo"].ToString(), datoestudiante["codigo"].ToString(), dropAnio.SelectedValue, dropGrado.SelectedValue, dropTipoGrupo.SelectedValue, dropGrupo.SelectedValue);//busca el estudiante en la tabla ins_estumatricula 
                    if (validarEstudiante == null)
                    {
                        if (est.agregarEstuMatricula(datoSede["codigo"].ToString(), datoestudiante["codigo"].ToString(), dropAnio.SelectedValue, horares, dropGrado.SelectedValue, dropTipoGrupo.SelectedValue, dropGrupo.SelectedValue))
                        {
                            mostrarmensaje("exito", "Estudiante agregado correctamente.");
                            txtIdentificacion.Text = "";
                            txtNombre.Text = "";
                            txtApellidos.Text = "";
                            txtFechaIniFiltro.Text = "";
                            txtTelefono.Text = "";
                            txtCelular.Text = "";
                            txtDireccion.Text = "";
                            txtEmail.Text = "";
                            dropEtnia.SelectedIndex = 0;
                            dropGrado.SelectedIndex = 0;
                            dropInstitucion.SelectedIndex = 0;
                        }
                        else
                        {
                            mostrarmensaje("error", "Error al matricular estudiante.");
                        }
                    }
                    else
                    {
                        if (est.editarEstuMatricula(datoSede["codigo"].ToString(), datoestudiante["codigo"].ToString(), dropAnio.SelectedValue, dropGrado.SelectedValue, dropTipoGrupo.SelectedValue, dropGrupo.SelectedValue))
                        {
                            mostrarmensaje("exito", "Estudiante agregado correctamente.");
                        }
                        else
                        {
                            mostrarmensaje("error", "Error al matricular estudiante.");
                        }
                    }
                }
                else
                {
                    mostrarmensaje("error", "Error al agregar estudiante.");
                }
            }
        }


    }
}