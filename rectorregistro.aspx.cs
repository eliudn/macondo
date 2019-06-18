using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class rectorregistro : System.Web.UI.Page
{
    Funciones fun = new Funciones();
    Institucion ins = new Institucion();
    LineaBase lb = new LineaBase();
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
            if (Session["codrol"].ToString() == "1" || Session["codrol"].ToString() == "7")
            {
                ddTipoDocumento(dropTipoID);
                ddInstituciones(dropInstitucion);

                DataRow dat = ins.buscarDatosRectorConSuInstitucion(Session["dane"].ToString());

                 if (dat != null)
                 {
                     lblCodRector.Text = dat["codigo"].ToString();
                     dropTipoID.SelectedValue = dat["codtipodocumento"].ToString();
                     txtIdentificacion.Text = dat["identificacion"].ToString();
                     txtNombre.Text = dat["nombre"].ToString();
                     txtApellidos.Text = dat["apellido"].ToString();
                     dropGenero.SelectedValue = dat["sexo"].ToString();
                     txtFechaIniFiltro.Text = fun.convertFechaAño(dat["fecha_nacimiento"].ToString());
                     txtTelefono.Text = dat["telefono"].ToString();
                     txtCelular.Text = dat["celular"].ToString();
                     txtEmail.Text = dat["email"].ToString();
                     btnAgregarUsuario.Visible = false;
                 }
                 else
                 {
                     btnEditarUsuario.Visible = false;
                 }
            }
           
           
    
        }
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
  
     private void ddInstituciones(DropDownList drop)
        {
            Institucion usu = new Institucion();
            DataTable datos = usu.cargarInstitucion();
            drop.DataSource = datos;
            drop.DataTextField = "nombre";
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
    
    

    protected void btnAgregarUsuario_Click(object sender, EventArgs e)
    {
      

        DateTime localDateTime = DateTime.Now;
        DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
        string horares = utcDateTime.ToString("yyyy-MM-dd_HHmmss");

        DataRow dat = ins.buscarDatosRectorInstitucion(txtIdentificacion.Text);

        if(dat == null)
        {
            if (ins.agregarRector(txtNombre.Text, txtApellidos.Text, txtIdentificacion.Text, dropGenero.SelectedValue, fun.convertFechaAño(txtFechaIniFiltro.Text), txtTelefono.Text, txtEmail.Text, dropTipoID.SelectedValue,txtCelular.Text))
            {
                mostrarmensaje("exito", "Datos ingresados correctamente.");
            }
            else
            {
                mostrarmensaje("error", "Error al ingresar la información.");
            }
        }
        else
        {
            mostrarmensaje("error", "Datos ya registrados");
        }

      

    }
    protected void btnEditarUsuario_Click(object sender, EventArgs e)
    {
          //DataRow dat = ins.buscarDatosRectorInstitucion(txtIdentificacion.Text);

          //if (dat != null)
          //{
              if (lb.editarDatosRector(dropTipoID.SelectedValue, txtIdentificacion.Text, txtNombre.Text, txtApellidos.Text, dropGenero.SelectedValue, fun.convertFechaAño(txtFechaIniFiltro.Text), txtTelefono.Text, txtCelular.Text, txtEmail.Text, lblCodRector.Text))
              {
                  mostrarmensaje("exito","Editado con exitosamente.");
              }
              else
              {
                  mostrarmensaje("error","Usuario No está en la Base de datos para editar.");
              }
          //}
          //else
          //{
          //    mostrarmensaje("error","El campo Identificación no puede estar vacío.");
          //}
    }

    protected void btnRelacionarRectorConInstitucion_Click(object sender, EventArgs e)
    {
        if(txtIDDocente.Text != "")
        {
            DataRow dat = ins.buscarRectorEnInstitucion(txtIDDocente.Text);

            if (dat == null)
            {
                if (ins.editarDatoInstitucionRector(txtIDDocente.Text, dropInstitucion.SelectedValue))
                {
                    mostrarmensaje("exito", "Rector asociado con la institución.");
                }
            }
            else
            {
                mostrarmensaje("error", "Rector ya asociado con una institución.");
            }
        }
        else
        {
            mostrarmensaje("error", "Digite la Identificación del Rector a asociar.");
        }
       
    }

   
   
}