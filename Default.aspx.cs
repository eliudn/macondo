using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Management;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Web.Script.Serialization;
using System.Web.Services;


public partial class _Default : System.Web.UI.Page
{
    Funciones fun = new Funciones();
    private void mostrarmensaje(string estado, string texto)
    {
        
    }
    private string[] registrarMAC()
    {
        string[] registro = new string[3];        
        registro[0] = "A0:A8:CD:61:AD:C2";
        registro[1] = "F8:0F:41:C7:F9:1B";
        registro[2] = "A0:A8:CD:61:AD:BE";
        return registro;
    }
    private bool dateVenc()
    {
        Funciones fun = new Funciones();
        string datelimit = "2029-03-15";
        string datetoday = fun.getFechaAñoHoraActual();
        DateTime dlimit = Convert.ToDateTime(datelimit);
        DateTime dhoy = Convert.ToDateTime(datetoday);
        bool estado = false;
        if (dhoy > dlimit)
        {
            estado = true;
        }
        else
        {
            estado = false;
        }
        return estado;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
        //mensaje.Attributes.Add("style", "display:none");// este es el mensaje 
        //txtUsuario.Focus();
        Session.RemoveAll();
        if (!IsPostBack)
        {
          //  string nombrecadena = "conMySql";
            //if (HttpContext.Current.Request.ApplicationPath.Remove(0, 1) != "")
            //    nombrecadena = HttpContext.Current.Request.ApplicationPath.Remove(0, 1);
            
         //   lblMensaje.Text = nombrecadena;
            //lblMensaje.Visible = true;

            if (dateVenc() == true)
            {
                Response.Redirect("erroservidor.html");
            }            
            //validarMAC();
        }
    }
      
	private bool insertarVisita(string codusuario, string codtipousuario)
    {
        Usuario usu = new Usuario();
        bool registro = false;
        long id = usu.agregarVisita(codusuario, codtipousuario);
        if (id != -1)
        {
            registro = true;
            Session["codsession"] = id;
        }
        else
        {
            registro = false;
            Response.Write("ERROR: No se ha registrado tu ingreso, Comuniquese con el administrador");
        }
        return registro;
    }
    private void validarMAC()
    {
        //ManagementObjectSearcher objQuery = null;
        //ManagementObjectCollection queryCollection = null;
        //bool reg = false;
        //try
        //{
        //    objQuery = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration");
        //    queryCollection = objQuery.Get();
        //    foreach (ManagementObject mgmtObject in queryCollection)
        //    {
        //        if (mgmtObject["MacAddress"] != null)
        //        {
        //            string mac = mgmtObject["MacAddress"].ToString();
        //            string[] cond = new string[3];
        //            cond = registrarMAC();
        //            for (int i = 0; i < 3; i++)
        //            {
        //                if (cond[i] != string.Empty)
        //                {
        //                    if (cond[i] == mac)
        //                    {
        //                        //Response.Write("MAC introducida: " + cond[i] + "--");
        //                        reg = true;
        //                    }                            
        //                }
        //            }
        //        }
        //    }
        //    if (reg == false)
        //    {
        //        Response.Redirect("restricted.aspx");
        //    }
        //}
        //catch (Exception ex) { MessageBox.Show(ex.Source); MessageBox.Show(ex.Message); }
    }

 
    public bool enviarMensajeporcorreo(string destino, string nombre, string apellido, string mensaje)
    {
        Usuario ema = new Usuario();
        //DataRow dato = ema.buscarCorreoRemitente();

        //if (dato != null && dato["envio"].ToString() == "si")
        //{
        //    System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

        //    msg.To.Add(destino); //destinatario

        //    msg.From = new MailAddress(dato["email"].ToString(), dato["nombre"].ToString(), System.Text.Encoding.UTF8); //correo emisor, nombre emisor

        //    msg.Subject = dato["asunto"].ToString(); // asunto
        //    msg.SubjectEncoding = System.Text.Encoding.UTF8;

        //    msg.Body = mensaje;

        //    msg.BodyEncoding = System.Text.Encoding.UTF8;
        //    msg.IsBodyHtml = true;

        //    //Aquí es donde se hace lo especial       
        //    SmtpClient client = new SmtpClient();
        //    client.Credentials = new System.Net.NetworkCredential(dato["email"].ToString().Trim(), dato["pass"].ToString().Trim());

        //    client.Port = Convert.ToInt32(dato["port"].ToString());
        //    client.Host = dato["servidorsmtp"].ToString();
        //    client.EnableSsl = Convert.ToBoolean(dato["seguridadssl"].ToString());
        //    client.Timeout = 200000;

        //    try
        //    {
        //        client.Send(msg);
        //        return true;
        //    }
        //    catch (System.Net.Mail.SmtpException ex)
        //    {

        //        Console.WriteLine(ex.Message);
        //        Console.ReadLine();
        //    }
        //}
        return false;
    }
    public string armarCuerpoDelMensajeActividad(string codusuario, string nombre, string apellido, string usuario, int num)
    {

        string ca = "";
        string titulo = "<div><img src='http://www.schoolonline.com.co/ProyectoSchoolOnlineKids/Imagenes/correo.png' width='520' alt='soporte_tecnico_header' />";
        titulo += "  <div style='max-width:650px;background-color:#fff;color:#000; padding:8px 15px 13px 15px; width:626px;'>";
        string saludoEstudiante = "";

        string preambulo = "";
        switch (num)
        {
            case 1:
                preambulo = " <br />Se ha generado la respuesta a su solicitud de la Actividad: #<br />";
                break;
            case 2:
                saludoEstudiante = "<h2>SOLICITUD:</h2>";
                preambulo = " <br />Se ha generado la respuesta a su solicitud Sr(a) " + nombre.ToUpper() + " " + apellido.ToUpper() + " <br /><br />Sus datos de ingreso son los siguientes:";
                break;
        }

        string contrasenia = ActualizarContrasenia(codusuario, usuario);

        string despedida = " </div><div style='background-color:#31669B;color:#ffffff;opacity:0,5;width:626px;height:50px;padding:8px 15px 13px 15px;'>";
        despedida += "<br /> <p style='margin:0 auto;text-align:center'>Copyright © 2016 FUNTICS. Todos los derechos reservados. <a href='http://www.funtics.org/'";
        despedida += "style='text-decoration:none;background-color:#31669B;color:#ffffff;' target='_blank'>www.funtics.org</a> </p></div></div>";

        ca = titulo + saludoEstudiante + preambulo + contrasenia + despedida;
        return ca;
    }

    private string ActualizarContrasenia(string codusuario, string usuario)
    {
        string ca = "";

        Usuario usu = new Usuario();

        Random rdn = new Random();

        int num = rdn.Next(1000000, 9000000);

        string pass = Convert.ToString(num);

        //if (usu.editarContraseña(codusuario, pass))
        //{
        //    ca += "<table>";
        //    ca += "<tr>";
        //    ca += "<td><b>USUARIO:</b></td>";
        //    ca += "<td>" + usuario + "</td>";
        //    ca += "</tr>";
        //    ca += "<tr>";
        //    ca += "<td><b>CONTRASEÑA TEMPORAL:</b></td>";
        //    ca += "<td>" + pass + "</td>";
        //    ca += "</tr>";
        //    ca += "<tr><td colspan='2'>Recuerde modificar su <b>CONTRASEÑA TEMPORAL</b> una vez haya ingresado al sistema.<br/>Link de acceso a la plataforma académica: <a href='http://www.schoolonline.com.co/salesiano'>Ingresar</a></td></tr>";
        //    ca += "</table>";
        //}

        return ca;

    }

    [WebMethod(EnableSession = true)]
    public static string login(string usuario, string contrasenia)
    {
        string ca="";
        Funciones fun = new Funciones();
        Usuario usu = new Usuario();
        _Default def = new _Default();
        DataRow datoUsuario = usu.verificarUsuario(usuario.Replace("'", ""), contrasenia.Replace("'", ""));
        if (datoUsuario != null)
        {
            HttpContext.Current.Session["nombre"] = datoUsuario["pnombre"].ToString() + " " + datoUsuario["papellido"].ToString();
            HttpContext.Current.Session["dane"] = datoUsuario["dane"].ToString();
            if (datoUsuario["estado"].ToString() != "Off")
            {
                HttpContext.Current.Session["usuario"] = datoUsuario["usuario"].ToString();
                HttpContext.Current.Session["identificacion"] = datoUsuario["identificacion"].ToString();
                 DataTable datosRoles = usu.cargarRolesUsuarios(datoUsuario["cod"].ToString());
                 if (datosRoles != null && datosRoles.Rows.Count > 1)
                 {
                     int i = 0; bool seguir = true;
                     while (i < datosRoles.Rows.Count && seguir)
                     {
                         if (datosRoles.Rows[i]["preferencia"].ToString() == "1")
                         {
                             seguir = false;
                         }
                         i++;
                     }

                     if (seguir)//Mostrar los roles
                     {
                         ca = "roles@";
                         ca += "<option value='0' disabled selected>Escoja un rol</option>";
                         for (int j = 0; j < datosRoles.Rows.Count; j++ )
                         {
                             ca += "<option value='" + datosRoles.Rows[j]["codrol"].ToString() +"'>" + datosRoles.Rows[j]["nombre"].ToString() + "</option>";
                         }
                         ca +=  "@" +datoUsuario["cod"].ToString();
                     }
                     else
                     {
                         def.Arracar(datosRoles.Rows[i - 1]);
                         ca = "true@";
                        
                     }

                 }
                else if (datosRoles != null && datosRoles.Rows.Count == 1)
                {
                    def.Arracar(datosRoles.Rows[0]);
                    ca = "true@";
                }
                else
                {
                    ca = "Error: Este usuario no tienes roles asignados,<br />Por favor comunicate con el administrador.";
                }
            }
            else
            {
                ca = "ERROR: Usuario Inactivo";
            }
        }
        else
        {
            ca = "Usuario y/o Contraseña Incorrecta";
        }
 
        return  ca ;
    }

    private void Arracar(DataRow datoUsuario)
    {
        Usuario usu = new Usuario();
        Session["codusuariorol"] = datoUsuario["cod"].ToString();
        Session["codusuario"] = datoUsuario["codusuario"];
        Session["codrol"] = datoUsuario["codrol"];
        Session["rol"] = datoUsuario["nombre"];
        Session["codperfil"] = datoUsuario["codperfil"];
        Session["codestrategia"] = datoUsuario["codestrategia"];

        usu.agregarlogUsuario(HttpContext.Current.Session["identificacion"].ToString());
    }

    private void ddRoles(DropDownList drop, DataTable datos)
    {
        drop.DataSource = datos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "codrol";
        drop.DataBind();
    }
 
    [WebMethod]
    public static string ElegirRol(string droprol, string cu)
    {
        string ca = "";
        Usuario user = new Usuario();
        _Default def = new _Default();
         user.editarPreferenciaRol("1", cu, droprol);
        def.Arracar(user.buscarUsuarioxRolxCod(cu, droprol));
        ca = "true@";
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string contrasenia(string usuario, string radiobutton)
    {
        string ca = "";
        _Default def = new _Default();

        Usuario usu = new Usuario();
        string mensaje = "";
        bool envio = false;

        ////if(usuario != "superadmin")
        ////{
        ////    if (radiobutton != "undefined")
        ////    {
        ////        if (radiobutton == "rbtusuario")//Por Usuarios
        ////        {
        ////            if (usuario != "")
        ////            {
        ////                DataRow dato = usu.buscarUsuarioxUserName(usuario.Replace("'", ""));
        ////                if (dato != null)
        ////                {
        ////                    if (dato["email"].ToString() != "")
        ////                    {
        ////                        mensaje = def.armarCuerpoDelMensajeActividad(dato["cod"].ToString(), dato["nombres"].ToString(), dato["apellidos"].ToString(), dato["usuario"].ToString(), 2);
        ////                        if (dato["email"].ToString() != "" && def.fun.email_bien_escrito(dato["email"].ToString()))
        ////                        {

        ////                            envio = def.enviarMensajeporcorreo(dato["email"].ToString(), dato["nombres"].ToString(), dato["apellidos"].ToString(), mensaje);
        ////                        }


        ////                        if (envio)
        ////                        {
        ////                            ca = "Se ha enviado su contraseña al correo electrónico registrado.";
        ////                        }
        ////                        else
        ////                        {
        ////                            ca = "Error al enviar correo.";
        ////                        }
        ////                    }
        ////                    else
        ////                    {
        ////                        ca = "Su usuario existe pero no tiene asociado un correo electrónico, acerquese al Administrador del Sistema para que le registre su correo electrónico.";
        ////                    }
        ////                }
        ////                else
        ////                {
        ////                    ca = "Usuario No Existe.";
        ////                }
        ////            }
        ////            else
        ////            {
        ////                ca = "El campo Usuario y/o Identificación no puede estar vacío";
        ////            }
	                
        ////        }
        ////        else//Por Identificación
        ////        {
        ////            if(usuario != "")
        ////            {
        ////                DataRow dato = usu.buscarUsuarioxIdentificacion(usuario.Replace("'", ""));
        ////                if (dato != null)
        ////                {
        ////                    if (dato["email"].ToString() != "")
        ////                    {
        ////                        mensaje = def.armarCuerpoDelMensajeActividad(dato["cod"].ToString(), dato["nombres"].ToString(), dato["apellidos"].ToString(), dato["usuario"].ToString(), 2);
        ////                        if (dato["email"].ToString() != "" && def.fun.email_bien_escrito(dato["email"].ToString()))
        ////                        {
        ////                            envio = def.enviarMensajeporcorreo(dato["email"].ToString(), dato["nombres"].ToString(), dato["apellidos"].ToString(), mensaje);
        ////                        }


        ////                        if (envio)
        ////                        {
        ////                             ca = "Se ha enviado su contraseña al correo electrónico registrado.";
        ////                        }
        ////                        else
        ////                        {
        ////                            ca = "Error al enviar correo.";
        ////                        }
        ////                    }
        ////                    else
        ////                    {
        ////                        //lblMensajeCorreo.Visible = true;
        ////                        ca = "Su Identificación existe pero no tiene asociado un correo electrónico, acerquese al Administrador del Sistema para que le registre su correo electrónico.";
        ////                    }
        ////                }
        ////                else
        ////                {
        ////                    //lblMensaje.Visible = true;
        ////                    //lblMensaje.Text = "Usuario y/o Contraseña Incorrecta";
        ////                    ca = "Identificación No Existe.";
        ////                }
        ////            }
        ////            else
        ////            {
        ////                ca = "El campo Usuario y/o Identificación no puede estar vacío";
        ////            }
	               
        ////        }

        ////    }
        ////    else
        ////    {
        ////        //lblMensajeRadioButton.Visible = true;
        ////        ca = "Debe seleccionar una opción.";
        ////    }
        //}
        //else
        //{
        //    ca = "Usuario y/o Identificación No Existe.";
        //}

        return ca;
    }
}