using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Services;

public partial class estra5lineamientosformacion : System.Web.UI.Page
{
    Estrategias est = new Estrategias();
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
            if (Session["codrol"] != null)
            {
                obtenerGET();
		        buscarUsuario();
                
            }
        
        }
    }
    public void obtenerGET()
    {
       //lblMomento.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        Session["m"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        Session["e"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["e"]);
        //lblSesion.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
        Session["s"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
        //Session["a"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["a"]);

        
    }
    private string encabezado()
    {
        string ca = "";

        ca += "<b>Desarrollo de las jornadas de formación </b><br/> ";
        //ca += "<b>Momento: </b>" + lblMomento.Text + " - " + "<b>Sesión:</b> " + lblSesion.Text + "<br/> ";

        return ca;
    }

    private void buscarUsuario()
    {
        Usuario usu = new Usuario();
        DataRow dato = usu.buscarUsuario(Session["codusuario"].ToString());
        if (dato != null)
        {
            lblCodUsuario.Text = dato["cod"].ToString();
            Session["codusuario"] = dato["cod"].ToString();
        }

    }

   
    Funciones fun = new Funciones();
   
    [WebMethod(EnableSession = true)]
    public static string loadReport()
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable lienamientos = est.est_EvidenciasEstras004Coordinador("", "", "", "", "5", "Certificado de cumplimiento de las horas de formación");
        DataTable g002Formato = est.est_EvidenciasEstras004Coordinador("", "", "", "", "5", "G002: Formato de evaluación de eventos de formación");

        DataTable matricula = est.est_matriculafuncionariosCoordinador("", "", "", "", "5", "S001: Formato de inscripción de actores o matrícula");

        //Matricula funcionarios
        double meta3 = 0;
        int count3 = 0;
        int total3 = 100;
        if (matricula != null && matricula.Rows.Count > 0)
        {
            count3 = matricula.Rows.Count;
            meta3 = ((double)count3 / (double)total3) * 100;
            meta3 = Math.Round(meta3, 2);
            //if (meta3 > 100)
            //{
            //    meta3 = 100;
            //}
            count3 = matricula.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>1.</b> Matricula Funcionarios</td>";
        ca += "<td class='center'>" + count3/2 + " de " + total3 + "</td>";
        ca += "<td class='center'>" + meta3 + "%</td>";
        ca += "<td class='noExl center'><a href='estra5detallematrifuncionarios.aspx'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";


        //Lineamientos
        double meta1 = 0;
        int count1 = 0;
        int total1 = 198;
        if (lienamientos != null && lienamientos.Rows.Count > 0)
        {
            count1 = lienamientos.Rows.Count;
            meta1 = ((double)count1 / (double)total1) * 100;
            meta1 = Math.Round(meta1, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}
            count1 = lienamientos.Rows.Count;
        }
        //ca += "<tr>";
        //ca += "<td><b>1.</b> Horas de formación certificadas en la formación en la Investigación como estrategia pedagógica </td>";
        //ca += "<td class='center'>" + count1 + " de " + total1 + "</td>";
        //ca += "<td class='center'>" + meta1 + "%</td>";
        //ca += "<td class='noExl center'><a href='estra5detalleformacion.aspx?a=1'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        //ca += "</tr>";

        //Evidencias
        double meta2 = 0;
        int count2 = 0;
        int total2 = 5;
        if (g002Formato != null && g002Formato.Rows.Count > 0)
        {
            count2 = g002Formato.Rows.Count;
            meta2 = ((double)count2 / (double)total2) * 100;
            meta2 = Math.Round(meta2, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}
            count2 = g002Formato.Rows.Count;
        }
        //ca += "<tr>";
        //ca += "<td><b>2.</b> Sesiones de formación evaluadas y subidas a la plataforma de Ciclón </td>";
        //ca += "<td class='center'>" + count2 + " de " + total2 + "</td>";
        //ca += "<td class='center'>" + meta2 + "%</td>";
        //ca += "<td class='noExl center'><a href='estra5detalleformacion.aspx?a=2'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        //ca += "</tr>";

        return ca;
    }


    

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("reporteindicadores.aspx");
    }

}