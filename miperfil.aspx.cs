using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class miperfil : System.Web.UI.Page
{
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
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 
        if (!IsPostBack)
        {
            PanelEdicion.Attributes.Add("style", "display:none");
            buscarUsuario();
            buscarRoles();
            PanelOtro.Visible = true;
            buscarImagenUsuario();
        }
    }
    private void buscarRoles()
    {
        Usuario user = new Usuario();
        DataTable datosRoles = user.cargarRolesxCodUsuarioSinCodUsuario(lblCodUsuario.Text, Session["codrol"].ToString());
        if (datosRoles != null && datosRoles.Rows.Count>0)
        {
            rblRoles(rblSeleccionar, datosRoles);
            PanelRoles.Visible = true;
        }
    }
    private void rblRoles(RadioButtonList cbl, DataTable datos)
    {
        cbl.DataSource = datos;
        cbl.DataTextField = "nombre";
        cbl.DataValueField = "codrol";
        cbl.DataBind();
    }
    private void buscarImagenUsuario()
    {
        Usuario usu = new Usuario();
        DataRow dr = usu.buscarImagenUsuario(Session["codusuario"].ToString());
        if (dr != null)
        {
            lblCodImgPerfil.Text = dr["cod"].ToString();
            imgPerfil.ImageUrl = dr["path"].ToString();
            btnSubirFirmaPop.Text = "Cambiar Imagen";
        }
        else
        {
            lblCodImgPerfil.Text = "";
            imgPerfil.ImageUrl = "~/Imagenes/img-default.png";
            btnSubirFirmaPop.Text = "Subir Imagen";
        }
    }
    private void buscarUsuario()
    {
        Usuario usu = new Usuario();
        DataRow dato = usu.buscarUsuario(Session["codusuario"].ToString());
        if (dato != null)
        {
            lblCodUsuario.Text = dato["cod"].ToString();
            lblUsuario.Text = dato["usuario"].ToString();
            txtIdentificacion.Text = dato["identificacion"].ToString();
            txtNombre.Text = dato["pnombre"].ToString();
            txtSNombre.Text = dato["snombre"].ToString();
            txtApellidos.Text = dato["papellido"].ToString();
            txtSApellido.Text = dato["sapellido"].ToString();
            txtTelefono.Text = dato["telefono"].ToString();
            txtCelular.Text = dato["celular"].ToString();
            txtEmail.Text = dato["email"].ToString();
        }

    }
    protected void lnkReestablecerContra_Click(object sender, EventArgs e)
    {
        txtContraActual.Focus();
        txtContraActual.Text = "";
        txtNuevaContra.Text = "";
        txtNuevaContra2.Text = "";
        PanelNuevaContra.Visible = true;
    }
    protected void btnGuardarcontra_Click(object sender, EventArgs e)
    {
        Usuario usu = new Usuario();
        DataRow dato = usu.verificarUsuario2(lblCodUsuario.Text, txtContraActual.Text);
        if (dato != null)
        {
            if (txtNuevaContra.Text == txtNuevaContra2.Text && txtNuevaContra.Text!="" && txtNuevaContra2.Text!="")
            {
                if (usu.editarPass(lblCodUsuario.Text, txtNuevaContra.Text))
                {
                    mostrarmensaje("exito", "Contraseña actualizada correctamente.");
                    PanelNuevaContra.Visible = false;
                    txtContraActual.Text = "";
                    txtNuevaContra.Text = "";
                    txtNuevaContra2.Text = "";
                }
                else
                {
                    mostrarmensaje("error", "Error al Guardar Contraseña");
                }
            }
            else
            {
                lblerrorcontra.Visible = true;
            }
        }
        else
        {
            txtContraActual.Text = "";
            txtNuevaContra.Text = "";
            txtNuevaContra2.Text="";
            txtContraActual.Focus();
            mostrarmensaje("error", "La contraseña ingresada es incorrecta");
        }
    }
    Funciones fun = new Funciones();
    protected void btnCancelar2_Click(object sender, EventArgs e)
    {
        PanelNuevaContra.Visible = false;
    }
    protected void btnSubirFirmaPop_Click(object sender, EventArgs e)
    {
        Response.Write("Esta ingresando al boton");
    }
    protected void btnActualizarDatosTutoria_Click(object sender, EventArgs e)
    {

        string[] variables = subirArchivo(trepador);

        if (variables[0] == "error")
        {
            mostrarmensaje(variables[0], variables[1]);
        }
        else if (variables[0] == "exito")
        {
            Usuario usu = new Usuario();
            //Reposi rep = new Reposi();
            DataRow dato = usu.buscarImagenUsuario(Session["codusuario"].ToString());
            if (dato == null)
            {

                if (usu.agregarArchivoResposi(lblCodUsuario.Text, variables[2], variables[3], variables[4], variables[5], variables[7], Convert.ToInt32(variables[8]), fun.getFechaAñoHoraActual()))
                {
                    lblCodImgPerfil.Text = "1";
                    trepador.PostedFile.SaveAs(variables[6]);
                    mostrarmensaje("exito", "Se ha cargado con éxito.");
                    imgPerfil.ImageUrl = variables[7];
                    btnSubirFirmaPop.Text = "Cambiar Imagen";
                }
                else
                {
                    mostrarmensaje("error", "Error al subir archivo.");
                }
            }
            else
            {

                if (usu.borrarImagenUsuario(Session["codusuario"].ToString()))
                {

                    if (File.Exists(Server.MapPath(dato["path"].ToString())))
                    {
                        try
                        {
                            File.Delete(Server.MapPath(dato["path"].ToString()));
                        }
                        catch
                        {
                        }


                        if (usu.agregarArchivoResposi(lblCodUsuario.Text, variables[2], variables[3], variables[4], variables[5], variables[7], Convert.ToInt32(variables[8]), fun.getFechaAñoHoraActual()))
                        {
                            lblCodImgPerfil.Text = "1";
                            trepador.PostedFile.SaveAs(variables[6]);
                            mostrarmensaje("exito", "Se ha cargado con éxito.");
                            imgPerfil.ImageUrl = variables[7];
                            btnSubirFirmaPop.Text = "Cambiar Imagen";
                        }
                        else
                        {
                            mostrarmensaje("error", "Error al subir archivo.");
                        }
                    }
                    else
                    {
                        //mostrarmensaje("error", "Error al borrar imagen del servidor");
                        if (usu.agregarArchivoResposi(lblCodUsuario.Text, variables[2], variables[3], variables[4], variables[5], variables[7], Convert.ToInt32(variables[8]), fun.getFechaAñoHoraActual()))
                        {
                            trepador.PostedFile.SaveAs(variables[6]);
                            mostrarmensaje("exito", "Se ha cargado con éxito.");
                            imgPerfil.ImageUrl = variables[7];
                            btnSubirFirmaPop.Text = "Cambiar Imagen";
                        }
                        else
                        {
                            mostrarmensaje("error", "Error al subir archivo.");
                        }
                    }

                }
                else
                {
                    mostrarmensaje("error", "Error al borrar imagen de la DB");
                }

            }
        }
        else
        {
            mostrarmensaje("error", "ERROR: Verifique la imagen.");
        }

    }
    private string[] subirArchivo(FileUpload trepador)
    {
        string[] variables = new string[9];
        variables[0] = string.Empty; //estado mensaje
        variables[1] = string.Empty; //mensaje 
        variables[2] = string.Empty; //fileName    
        variables[3] = string.Empty; //fileNameSave
        variables[4] = string.Empty; //fileExtension
        variables[5] = string.Empty; //contentType
        variables[6] = string.Empty; //pathSave
        variables[7] = string.Empty; //pathsinmapSave
        variables[8] = string.Empty; //ContentLength

        //Calculadora de bytes: http://es.calcuworld.com/informatica/calculadora-de-bytes/
        int tamanofile;
        long tamanopermitido = 4194304;//Este dato está en bytes. 4194304 es 4MB, revisar el tamaño en el web.config (maxRequestLength) (kb). 31.700.160KB

        string contentType;
        string pathsinmap = "";
        if (HttpContext.Current.Request.ApplicationPath.Remove(0, 1) == "")
            pathsinmap = "~/FOTOS/";
        else
            pathsinmap = "~/FOTOS/" + HttpContext.Current.Request.ApplicationPath.Remove(0, 1) + "/";
        string path = Server.MapPath(pathsinmap);
        if (trepador.HasFile)
        {
            try
            {
                bool directorio = false;
                if (!Directory.Exists(path))
                {
                    try
                    {
                        Directory.CreateDirectory(path);
                        directorio = true;
                    }
                    catch (Exception exd)
                    {
                        variables[0] = "error"; // estado mensaje
                        variables[1] = "Error : " + exd.Message; //mensaje  
                        return variables;
                        //mostrarmensaje("error", "Error : " + exd.Message);    
                    }
                }
                else
                    directorio = true; //Ya existe el directorio                

                if (directorio == true)
                {
                    tamanofile = trepador.PostedFile.ContentLength;
                    contentType = trepador.PostedFile.ContentType;

                    if (tamanofile > 0 && tamanofile < tamanopermitido)
                    {
                        DateTime localDateTime = DateTime.Now;
                        DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
                        string horares = utcDateTime.ToString("yyyy-MM-dd_HHmmss");

                        string fileExtension = System.IO.Path.GetExtension(trepador.FileName).ToLower();
                        string fileName = System.IO.Path.GetFileName(trepador.PostedFile.FileName).Replace(",", " ");
                        string fileNameSave =  horares + "_" + lblCodUsuario.Text + fileExtension;
                        string pathSave = path + fileNameSave;
                        string pathsinmapSave = pathsinmap + fileNameSave;

                        String[] allowedExtensions = funallowedExtensions();
                        bool extOK = false;
                        for (int i = 0; i < allowedExtensions.Length; i++)
                        {
                            if (fileExtension == allowedExtensions[i])
                            {
                                extOK = true;
                                //para quitar el punto "." de la extension
                                string exte = trepador.PostedFile.FileName;
                                fileExtension = (exte.Substring(exte.LastIndexOf(".") + 1).ToLower());
                            }
                        }

                        if (extOK == false)
                        {
                            variables[0] = "error"; // estado mensaje
                            variables[1] = "Error: No se permite el formato " + fileExtension; //mensaje  
                            return variables;
                            //mostrarmensaje("error", "Error: No se permite el formato " + fileExtension);
                        }
                        else
                        {
                            variables[0] = "exito"; // estado mensaje
                            variables[1] = ""; //mensaje  
                            variables[2] = fileName;  //fileName    
                            variables[3] = fileNameSave; //fileNameSave
                            variables[4] = fileExtension; //fileExtension
                            variables[5] = contentType; //contentType
                            variables[6] = pathSave; //pathSave
                            variables[7] = pathsinmapSave; //pathsinmapSave
                            variables[8] = trepador.PostedFile.ContentLength.ToString(); //ContentLength
                            return variables;
                        }
                    }
                    else
                    {
                        long tan = (tamanopermitido / 1024) / 1024;
                        mostrarmensaje("error", "Tamaño no permitido, solo se aceptan: " + tan.ToString() + " MB");
                    }
                }
            }
            catch (Exception ex)
            {
                mostrarmensaje("error", "Error : " + ex.Message);
            }
        }
        else
        {
            variables[0] = "error"; // estado mensaje
            variables[1] = "Error: Debes seleccionar un archivo"; //mensaje  
            return variables;
            //mostrarmensaje("error", "Error: Debes seleccionar un archivo");
        }
        return variables;
    }
    public String[] funallowedExtensions()
    {
        String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
        return allowedExtensions;
    }
    protected void btnEditarUsuario_Click(object sender, EventArgs e)
    {
        if (email_bien_escrito(txtEmail.Text))
        {
            Usuario usu = new Usuario();
            if (usu.editarUsuario(txtIdentificacion.Text, txtNombre.Text, txtSNombre.Text, txtApellidos.Text, txtSApellido.Text, txtEmail.Text, txtTelefono.Text, txtCelular.Text, lblCodUsuario.Text))
            {
                mostrarmensaje("exito", "Actualizado correctamente.");
            }
            else
            {
                mostrarmensaje("error", "ERROR: No se pudo actualizar");
            }
        }
        else
        {
            mostrarmensaje("error", "ERROR:Cuenta de Correo No Valido.");
        }
        
    }
    private Boolean email_bien_escrito(String email)
    {
        String expresion;
        expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        if (Regex.IsMatch(email, expresion))
        {
            if (Regex.Replace(email, expresion, String.Empty).Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    protected void btnCambiarRol_Click(object sender, EventArgs e)
    {
        Usuario user = new Usuario();
        bool eligio = false;
        for (int i = 0; i < rblSeleccionar.Items.Count; i++)
        {
            if (rblSeleccionar.Items[i].Selected)
            {
                eligio = true;
                if (cbPreferido.Checked)
                {
                    user.editarPreferenciaRol("0", lblCodUsuario.Text, Session["codrol"].ToString());
                    user.editarPreferenciaRol("1", lblCodUsuario.Text, rblSeleccionar.Items[i].Value);
                    Session["codrol"] = rblSeleccionar.Items[i].Value;
                    Session["rol"] = rblSeleccionar.Items[i].Text;
                   
                }
                else
                {
                    Session["codrol"] = rblSeleccionar.Items[i].Value;
                    Session["rol"] = rblSeleccionar.Items[i].Text;
                }
            }
        }

        if (eligio)
        {
            DataRow datoRol = user.buscarUsuarioxRolxCod(lblCodUsuario.Text, Session["codrol"].ToString());
            if (datoRol != null && datoRol["codperfil"].ToString()!="")
            {
                Session["codperfil"] = datoRol["codperfil"];
                Session["codusuariorol"] = datoRol["cod"]; ;
                int time = 1;
                Response.AppendHeader("Refresh", time + "; Url=" + Request.RawUrl + "");
            }
        }
        else
        {
            mostrarmensaje("error", "ERROR: Debes seleccionar el rol por el que quieres cambiar.");
        }
    }
}