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

public partial class informeacompanamiento : System.Web.UI.Page
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
        //Session["m"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        //lblSesion.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
        //Session["s"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
        //Session["a"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["a"]);
    }
    private string encabezado()
    {
        string ca = "";

        ca += "<b>Informe del desarrollo de las Etapas 1, 2  y 3 </b><br/> ";
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

        DataTable noAsesoriasGP = est.noAsesoriasGP("","","","");
        DataRow noParticipantesAsesorias = est.noParticipantesAsesorias();
        DataTable totalEvaluacionAsesoria = est.totalEvaluacionAsesoria("","","","","");

        //Número de asesorias de los grupos de investigación
        double meta1 = 0;
        int count1 = 0;
        int total1 = 420;
        if (noAsesoriasGP != null && noAsesoriasGP.Rows.Count > 0)
        {
            count1 = noAsesoriasGP.Rows.Count;
            meta1 = ((double)count1 / (double)total1) * 100;
            meta1 = Math.Round(meta1, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}
            count1 = noAsesoriasGP.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>1.</b> Asesoría desarrolladas en el momento pedagógico 1 a los grupos infantiles y juveniles</td>";
        ca += "<td class='center'>" + count1 + " de " + total1 + "</td>";
        ca += "<td class='center'>" + meta1 + "%</td>";
        ca += "<td class='noExl center'><a href='numeroasesoriasgp.aspx'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Total de participantes de las asesorias
        double meta2 = 0;
        int count2 = 0;
        int total2 = 44200;
        if (noParticipantesAsesorias["total"].ToString() != "" )
        {
            count2 =  Int32.Parse(noParticipantesAsesorias["total"].ToString());
            meta2 = ((double)count2 / (double)total2) * 100;
            meta2 = Math.Round(meta2, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}
            count2 = Int32.Parse(noParticipantesAsesorias["total"].ToString());
        }
        ca += "<tr>";
        ca += "<td><b>2.</b> Asistentes a la sesión de asesoría a grupos infantiles y juveniles</td>";
        ca += "<td class='center'>" + count2 + " de " + total2 + "</td>";
        ca += "<td class='center'>" + meta2 + "%</td>";
        ca += "<td class='noExl center'>Sin detalles</td>";
        ca += "</tr>";

        //Total de evaluación asesoria
        double meta3 = 0;
        int count3 = 0;
        int total3 = 420;
        if (totalEvaluacionAsesoria != null && totalEvaluacionAsesoria.Rows.Count > 0)
        {
            count3 = totalEvaluacionAsesoria.Rows.Count;
            meta3 = ((double)count3 / (double)total3) * 100;
            meta3 = Math.Round(meta3, 2);
            //if (meta3 > 100)
            //{
            //    meta3 = 100;
            //}
            count3 = totalEvaluacionAsesoria.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>3.</b> Asesorías a los grupos infantiles y juveniles evaluadas y subidas a la plataforma de Ciclón</td>";
        ca += "<td class='center'>" + count3 + " de " + total3 + "</td>";
        ca += "<td class='center'>" + meta3 + "%</td>";
        ca += "<td class='noExl center'><a href='totalevaluacionasesoria.aspx'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        return ca;
    }



    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("reporteindicadores.aspx");
    }

}