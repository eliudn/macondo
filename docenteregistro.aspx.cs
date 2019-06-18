using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class docenteregistro : System.Web.UI.Page
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
        Usuario usu = new Usuario();
       Docentes doc = new Docentes();
       Institucion ins = new Institucion();

        DateTime localDateTime = DateTime.Now;
        DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
        string horares = utcDateTime.ToString("yyyy-MM-dd_HHmmss");

      

         DataRow datDocente = doc.buscarDocenteIngresado(txtIdentificacion.Text);

         if (datDocente != null)
       {
           mostrarmensaje("error", "El Docente ya se encuentra registrado.");
       }
       else
       {
              DataRow datoSede = ins.buscarSedexNit(txtDane.Text);
              if (datoSede != null)
              {
                  if (doc.agregarDocente(txtNombre.Text, txtApellidos.Text, txtIdentificacion.Text, dropGenero.SelectedValue, fun.convertFechaAño(txtFechaIniFiltro.Text), txtTelefono.Text, txtDireccion.Text, txtEmail.Text, dropTipoID.SelectedValue))
                  {
                      if (doc.agregarDocenteGrado(txtIdentificacion.Text, datoSede["codigo"].ToString(), dropAnio.SelectedValue))
                      {
                          DataRow usuario = usu.agregarUsuarioPG(txtIdentificacion.Text, txtIdentificacion.Text, txtIdentificacion.Text, txtNombre.Text, "", txtApellidos.Text, "", txtTelefono.Text, "", txtEmail.Text, "On", txtDane.Text);
                          if (usuario != null)
                          {
                              if (usu.relacionarUsuarioRol(usuario["cod"].ToString(), "3"))
                              {
                                  mostrarmensaje("exito", "Docente registrado exitosamente.");
                                  dropTipoID.SelectedIndex = 0;
                                  txtIdentificacion.Text = "";
                                  txtNombre.Text = "";
                                  txtApellidos.Text = "";
                                  dropGenero.SelectedIndex = 0;
                                  txtFechaIniFiltro.Text = "";
                                  txtTelefono.Text = "";
                                  txtDireccion.Text = "";
                                  txtEmail.Text = "";
                                  txtDane.Text = "";
                              }
                              else { mostrarmensaje("error", "Error al crear Rol"); }
                          }
                          else
                          {
                              mostrarmensaje("error", "Error, usuario ya existe.");
                          }

                      }
                      else
                      {
                          mostrarmensaje("error", "Error al relacionar sede con docente.");
                      }

                  }
                  else
                  {

                      if (doc.agregarDocenteGrado(txtIdentificacion.Text, datoSede["codigo"].ToString(), dropAnio.SelectedValue))
                      {
                          DataRow usuario = usu.agregarUsuarioPG(txtIdentificacion.Text, txtIdentificacion.Text, txtIdentificacion.Text, txtNombre.Text, "", txtApellidos.Text, "", txtTelefono.Text, "", txtEmail.Text, "On", txtDane.Text);
                          if (usuario != null)
                          {
                              if (usu.relacionarUsuarioRol(usuario["cod"].ToString(), "3"))
                              {
                                  mostrarmensaje("exito", "Docente registrado exitosamente.");
                                  dropTipoID.SelectedIndex = 0;
                                  txtIdentificacion.Text = "";
                                  txtNombre.Text = "";
                                  txtApellidos.Text = "";
                                  dropGenero.SelectedIndex = 0;
                                  txtFechaIniFiltro.Text = "";
                                  txtTelefono.Text = "";
                                  txtDireccion.Text = "";
                                  txtEmail.Text = "";
                                  txtDane.Text = "";
                              }
                              else { mostrarmensaje("error", "Error al crear Rol"); }
                          }
                          else
                          {
                              mostrarmensaje("error", "Error, usuario ya existe.");
                          }

                      }
                      else
                      {
                          DataRow usuario = usu.agregarUsuarioPG(txtIdentificacion.Text, txtIdentificacion.Text, txtIdentificacion.Text, txtNombre.Text, "", txtApellidos.Text, "", txtTelefono.Text, "", txtEmail.Text, "On", txtDane.Text);
                          if (usuario != null)
                          {
                              if (usu.relacionarUsuarioRol(usuario["cod"].ToString(), "3")) { mostrarmensaje("exito", "Docente registrado exitosamente."); } else { mostrarmensaje("error", "Error al crear Rol"); }
                          }
                          else
                          {
                              mostrarmensaje("error", "Error, usuario ya existe.");
                          }
                      }

                  }
              }
              else
              {
                  mostrarmensaje("error", "Error, La sede no existe.");
              }
          
               
       
       }

    }
  
}