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

public partial class estra2formarmaestros : System.Web.UI.Page
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
        //Session["s"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
        //Session["a"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["a"]);

        ////if(Session["a"] != null)
        //{
            //lblActividad.Text = Session["a"].ToString();
        //}
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

        DataTable estra2MaestrosMatriculados = est.estra2MaestrosMatriculados("", "", "", "");
        DataTable estra2MaestrosAsistencia = est.estra2MaestrosAsistencia("", "", "", "");

        //Maestros y maestras acompañantes / coinvestigadores matriculados en la estrategia  No. 2
        double meta1 = 0;
        int count1 = 0;
        int total1 = 3386;
        if (estra2MaestrosMatriculados != null && estra2MaestrosMatriculados.Rows.Count > 0)
        {
            count1 = estra2MaestrosMatriculados.Rows.Count;
            meta1 = ((double)count1 / (double)total1) * 100;
            meta1 = Math.Round(meta1, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}
            count1 = estra2MaestrosMatriculados.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>1.</b> Maestros y maestras acompañantes / coinvestigadores matriculados en la estrategia  No. 2</td>";
        ca += "<td class='center'>" + count1 + " de " + total1 + "</td>";
        ca += "<td class='center'>" + meta1 + "%</td>";
        ca += "<td class='noExl center'><a href='estra2maestrosmatriculados.aspx'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";



        //Maestros y maestras acompañantes / coinvestigadores matriculados en la estrategia  No. 2
        double meta2 = 0;
        int count2 = 0;
        int total2 = 3386;
        if (estra2MaestrosAsistencia != null && estra2MaestrosAsistencia.Rows.Count > 0)
        {
            count2 = estra2MaestrosAsistencia.Rows.Count;
            meta2 = ((double)count2 / (double)total2) * 100;
            meta2 = Math.Round(meta2, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}
            count2 = estra2MaestrosAsistencia.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>2.</b> Maestros y maestras investigadores formados en los lineamientos del Programa Ciclón y su propuesta metodológica	G001: Registro de asistencia a eventos</td>";
        ca += "<td class='center'>" + count2 + " de " + total2 + "</td>";
        ca += "<td class='center'>" + meta2 + "%</td>";
        ca += "<td class='noExl center'></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";


        //Maestros y maestras inscritos en los espacios de apropiación social formados en los lineamientos del Programa Ciclón y su propuesta metodológica
        double meta3 = 0;
        int count3 = 0;
        int total3 = 320;
        //if (estra2MaestrosMatriculados != null && estra2MaestrosMatriculados.Rows.Count > 0)
        //{
        //    count3 = estra2MaestrosMatriculados.Rows.Count;
        //    meta3 = ((double)count3 / (double)total3) * 100;
        //    meta3 = Math.Round(meta3, 2);
        //    if (meta3 > 100)
        //    {
        //        meta3 = 100;
        //    }
        //    count3 = estra2MaestrosMatriculados.Rows.Count;
        //}
        //ca += "<tr>";
        //ca += "<td><b>3.</b> Maestros y maestras inscritos en los espacios de apropiación social formados en los lineamientos del Programa Ciclón y su propuesta metodológica</td>";
        //ca += "<td class='center'>" + count3 + " de " + total3 + "</td>";
        //ca += "<td class='center'>" + meta3 + "%</td>";
        //ca += "<td class='noExl center'><a href='#'>Pendiente</td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        //ca += "</tr>";


        return ca;
    }


    

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("reporteindicadores.aspx");
    }

}