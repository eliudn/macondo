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

public partial class asesorgruposinvestigacion : System.Web.UI.Page
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
        //Session["s"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
        //Session["a"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["a"]);
    }
    private string encabezado()
    {
        string ca = "";

        

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

        DataTable asesoriasGPm3e1 = est.asesoriasGPm3e1("", "", "", "", "");
        DataRow asistentesSesionAsesoria = est.asistentesSesionAsesoria();
        DataTable asesoriasGPCiclon = est.asesoriasGPCiclon("", "", "", "", "");
        
        double meta1 = 0;
        int count1 = 0;
        int total1 = 420;
        if (asesoriasGPm3e1 != null && asesoriasGPm3e1.Rows.Count > 0)
        {
            count1 = asesoriasGPm3e1.Rows.Count;
            meta1 = ((double)count1 / (double)total1) * 100;
            meta1 = Math.Round(meta1, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}
            count1 = asesoriasGPm3e1.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>1.</b> Asesorías realizadas a los grupos de investigación infantiles y juveniles en el momento pedagógico 3, etapa 4</td>";
        ca += "<td class='center'>" + count1 + " de " + total1 + "</td>";
        ca += "<td class='center'>" + meta1 + "%</td>";
        ca += "<td class='noExl center'><a href='asesoriascpm3e1.aspx'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0
        ca += "</tr>";

        //Asistentes a la sesión de asesoría
        double meta2 = 0;
        int count2 = 0;
        int total2 = 44200;
        if (asistentesSesionAsesoria["total"].ToString() != "")
        {
            count2 = Int32.Parse(asistentesSesionAsesoria["total"].ToString());
            meta2 = ((double)count2 / (double)total2) * 100;
            meta2 = Math.Round(meta2, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}
            count2 = Int32.Parse(asistentesSesionAsesoria["total"].ToString());
        }
        ca += "<tr>";
        ca += "<td><b>2.</b> Asistentes a la sesión de asesoría a grupos infantiles y juveniles</td>";
        ca += "<td class='center'>" + count2 + " de " + total2 + "</td>";
        ca += "<td class='center'>" + meta2 + "%</td>";
        ca += "<td class='noExl center'>Sin detalles</td>";
        ca += "</tr>";

        //Asesorías a los grupos infantiles y juveniles  evaluados
        double meta3 = 0;
        int count3 = 0;
        int total3 = 420;
        if (asesoriasGPCiclon != null && asesoriasGPCiclon.Rows.Count > 0)
        {
            count3 = asesoriasGPCiclon.Rows.Count;
            meta3 = ((double)count3 / (double)total3) * 100;
            meta3 = Math.Round(meta3, 2);
            //if (meta3 > 100)
            //{
            //    meta3 = 100;
            //}
            count3 = asesoriasGPCiclon.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>3.</b> Asesorías a los grupos infantiles y juveniles evaluadas y subidas a la plataforma de Ciclón</td>";
        ca += "<td class='center'>" + count3 + " de " + total3 + "</td>";
        ca += "<td class='center'>" + meta3 + "%</td>";
        ca += "<td class='noExl center'><a href='asesoriasgpciclon.aspx'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0
        ca += "</tr>";

        return ca;
    }




    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("reporteindicadores.aspx");
    }

}