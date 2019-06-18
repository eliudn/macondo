using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;
using System.Web.Services;

public partial class bienvenida : System.Web.UI.Page
{
    Funciones fun = new Funciones();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 
        if (!IsPostBack)
        {
            if (Session["codrol"] != null)
            {
                //lblTipoUsuario.Text = Session["codrol"].ToString();
                //if (lblTipoUsuario.Text == "1")//Administrador
                //{
                //    ManualAdmin.Visible = true;
                //}
                //else if (lblTipoUsuario.Text == "4")//Cliente
                //{
                //    ManualCliente.Visible = true;
                //}
                //else if (lblTipoUsuario.Text == "2")//Coordinador
                //{
                //    ManualCoordinador.Visible = true;
                //}
                //else if (lblTipoUsuario.Text == "3")//Agente
                //{
                //    ManualAgente.Visible = true;
                //}
                //else if (lblTipoUsuario.Text == "5")
                //{
                //    ManualTecnico.Visible = true;
                //}

                if (Session["codrol"].ToString() == "3")
                {
                    Usuario usu = new Usuario();
                    string datomensaje = "";
                    bool envio = false;
                    string ca = "";

                    DataRow datt = usu.buscarCodigoVerificacionxDocente(Session["identificacion"].ToString());

                    if(datt != null)
                    {
                        if(datt["estado"].ToString() == "On")
                        {
                           
                            DataRow dato = usu.buscarUsuarioxIdentificacion(Session["identificacion"].ToString());

                            //if (dato["email"].ToString() != "0")
                            //{
                            //    datomensaje = armarCuerpoDelMensajeActividad(dato["cod"].ToString(), dato["pnombre"].ToString(), dato["papellido"].ToString(), dato["usuario"].ToString(), 2);
                            //    if (dato["email"].ToString() != "" && fun.email_bien_escrito(dato["email"].ToString()))
                            //    {

                            //        envio = enviarMensajeporcorreo(dato["email"].ToString(), dato["pnombre"].ToString(), dato["papellido"].ToString(), datomensaje);
                            //    }


                            //    if (envio)
                            //    {
                            //        ca = "Se ha enviado el código de verificación al correo electrónico registrado.";
                            //        txtCodeVerify.Enabled = true;
                            //        btnVerificarCodigo.Visible = true;
                            //    }
                            //    else
                            //    {
                            //        ca = "Error al enviar correo.";
                            //        btnSalirPagina.Visible = true;
                            //    }
                            //}
                            //else
                            //{
                            //    ca = "Su usuario existe pero no tiene asociado un correo electrónico. <br/> Acerquese al Administrador del Sistema para que le registre su correo electrónico.";
                            //    btnRecargarPagina.Visible = true;
                            //    btnSalirPagina.Visible = true;
                            //}
                            lblMensaje.Visible = true;
                            lblMensaje.Text = ca;
                            this.PanelPopup_Modalpopupextender.Show();
                            txtCodeVerify.Enabled = true;
                            btnVerificarCodigo.Visible = true;

                            string c0 = "";
                            c0 += "<br/><p style='font-size:8pt'>La línea de base del programa Ciclón se realiza antes de iniciar la ejecución de Ciclón y busca recoger información sobre los indicadores básicos sobre los cuales se espera que el Programa incida y genere cambios en sus actores. <br/>";
                            c0 += "La información recolectada en este proceso será utilizada para efectos de evaluación de impacto del programa Ciclón garantizando confidencialidad con respecto a la información obtenida, por ello su nombre y datos básicos no aparecerá en los informes de resultados. <br/>";
                            c0 += "Conociendo esta información manifiesto mi interés de ser parte de este proceso dejando constancia que mí participación es voluntaria, libre y consecuente. Acepto responder de manera honesta  los ítem propuesto y me comprometo a plasmar la información de manera completa en los casos que aplique.</p>";
                            lblMensajeCondiciones.Text = c0;
                            lblMensajeCondiciones.Visible = true;
                        }
                        else
                        {
                            this.PanelPopup_Modalpopupextender.Hide();
                            lblMensaje.Visible = false;
                        }

                    }
                    else
                    {
                        btnRecargarPagina.Visible = true;
                        btnSalirPagina.Visible = true;

                    }

                   

                   
                }
            }
            else
            {
                Response.Redirect("default.aspx");
            }
        }
    }

    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }

    protected void btnVerificarCodigo_Click(object sender, EventArgs e)
    {
       
        if(chkAceptarTerminos.Checked)
        {
            Usuario usu = new Usuario();
            DataRow datt = usu.buscarCodigoVerificacionxDocente(Session["identificacion"].ToString());

            if (datt != null)
            {
                if (txtCodeVerify.Text == datt["code"].ToString())
                {
                    this.PanelPopup_Modalpopupextender.Hide();
                    lblMensaje.Visible = false;
                    usu.editarEstadoCodeVerificacion("Off", Session["identificacion"].ToString());
                }
                else
                {
                    this.PanelPopup_Modalpopupextender.Show();
                    mostrarmensaje("error", "Error: Código de verificación inválido.");
                   
                }
            }
        }
        else
        {
             this.PanelPopup_Modalpopupextender.Show();
             mostrarmensaje("error", "Error: Debe aceptar Términos y Condiciones.");
            //lblMensajeCondiciones.Text = ca;
        }
        

    }

    public bool enviarMensajeporcorreo(string destino, string nombre, string apellido, string datmensaje)
    {
        Usuario ema = new Usuario();
        DataRow dato = ema.buscarCorreoRemitente();

        if (dato != null && dato["envio"].ToString() == "si")
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

            msg.To.Add(destino); //destinatario

            msg.From = new MailAddress(dato["email"].ToString(), dato["nombre"].ToString(), System.Text.Encoding.UTF8); //correo emisor, nombre emisor

            msg.Subject = dato["asunto"].ToString(); // asunto
            msg.SubjectEncoding = System.Text.Encoding.UTF8;

            msg.Body = datmensaje;

            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;

            //Aquí es donde se hace lo especial       
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(dato["email"].ToString().Trim(), dato["pass"].ToString().Trim());

            client.Port = Convert.ToInt32(dato["port"].ToString());
            client.Host = dato["servidorsmtp"].ToString();
            client.EnableSsl = Convert.ToBoolean(dato["seguridadssl"].ToString());
            client.Timeout = 200000;

            try
            {
                client.Send(msg);
                return true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {

                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
        return false;
    }
    public string armarCuerpoDelMensajeActividad(string codusuario, string nombre, string apellido, string usuario, int num)
    {
        string nombrecadena = "";
        if (HttpContext.Current.Request.ApplicationPath.Remove(0, 1) != "")
            nombrecadena = HttpContext.Current.Request.ApplicationPath.Remove(0, 1);

        string ca = "";
        string titulo = "<div><img src='' width='520' alt='soporte_tecnico_header' />";
        titulo += "  <div style='max-width:650px;background-color:#fff;color:#000; padding:8px 15px 13px 15px; width:626px;'>";
        string saludoEstudiante = "";

        string preambulo = "";
        switch (num)
        {
            case 1:
                preambulo = " <br />Se ha generado la respuesta a su solicitud: #<br />";
                break;
            case 2:
                saludoEstudiante = "<h2>Se ha generado la respuesta a su solicitud: </h2>";
                preambulo = " <br />Se ha generado la respuesta a su solicitud Sr(a) " + nombre.ToUpper() + " " + apellido.ToUpper() + " <br /><br />:";
                break;
        }

        string contrasenia = ActualizarContrasenia(codusuario, usuario);

        string despedida = " </div><div style='background-color:#31669B;color:#ffffff;opacity:0,5;width:626px;height:50px;padding:8px 15px 13px 15px;'>";
        despedida += "<br /> <p style='margin:0 auto;text-align:center'>Copyright © 2016 Ciclón. Todos los derechos reservados. <a href='http://www.siep.co/'";
        despedida += "style='text-decoration:none;background-color:#31669B;color:#ffffff;' target='_blank'>www.siep.co</a> </p></div></div>";

        ca = titulo + saludoEstudiante + preambulo + contrasenia + despedida;
        return ca;
    }

    private string ActualizarContrasenia(string codusuario, string usuario)
    {
        string ca = "";

        Usuario usu = new Usuario();

        Random rdn = new Random();

        int num = rdn.Next(1000000, 9000000);

        string code = Convert.ToString(num);

        if (usu.agregarCodigoVerificacion(Session["identificacion"].ToString(), code))
        {
            ca += "<table>";
            ca += "<tr><td colspan='2'>Recuerde ingresar el <b>CÓDIGO DE VERIFICACIÓN</b> una vez haya ingresado al sistema.<br/>Link de acceso a la plataforma: <a href='http://www.siep.co/web/bienvenida.aspx'>Acceder</a></td></tr>";
            ca += "<tr>";
            ca += "<td><b>Identificación:</b></td>";
            ca += "<td>" + Session["identificacion"].ToString() + "</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<td><b>CÓDIGO DE VERIFICACIÓN:</b></td>";
            ca += "<td>" + code + "</td>";
            ca += "</tr>";
            ca += "</table>";
        }

        return ca;

    }

    protected void btnSalirPagina_Click(object sender, EventArgs e)
    {
        Response.Redirect("default.aspx");
    }

    protected void btnRecargarPagina_Click(object sender, EventArgs e)
    {
        Response.Redirect("bienvenida.aspx");
    }

    [WebMethod(EnableSession = true)]
    public static bool KeepActiveSession()
    {
        if (HttpContext.Current.Session["datos"] != null)
            return true;
        else
            return false;
    }

    [WebMethod(EnableSession = true)]
    public static void SessionAbandon()
    {
        HttpContext.Current.Session.Remove("datos");
    }


     [WebMethod(EnableSession = true)]
     public static string descarEvi(){
        string ca="";
        LineaBase desEvi= new LineaBase();
        DataTable prue =desEvi.evidenciaDescarga();
           
         if (prue != null && prue.Rows.Count > 0){
            
            for (int i = 0; i < prue.Rows.Count; i++){
                ca+="<a id='descarg' href='http://macondo.programaciclon.edu.co/web/Estrategia_2/web/"+ prue.Rows[i]["nombreguardado"].ToString()+"' download='"+i+"____"+ prue.Rows[i]["nombreguardado"].ToString()+"'  class='download-link'>   "+i+"(-_-)"+ prue.Rows[i]["nombreguardado"].ToString()+"</a>";
            
         }
         }else{
           
            ca+=  "<label>no</label>";

             }


          return ca;
              
    }


}
