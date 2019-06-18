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

public partial class estra1gruposevaluacionferia : System.Web.UI.Page
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

        DataTable estra1SedesGruposEvaluacionFeria = est.estra1SedesGruposEvaluacionFeria("", "");
        
        double meta1 = 0;
        int count1 = 0;
        int total1 = 320;
        if (estra1SedesGruposEvaluacionFeria != null && estra1SedesGruposEvaluacionFeria.Rows.Count > 0)
        {
            count1 = estra1SedesGruposEvaluacionFeria.Rows.Count;
            meta1 = ((double)count1 / (double)total1) * 100;
            meta1 = Math.Round(meta1, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}
            count1 = estra1SedesGruposEvaluacionFeria.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>1.</b> Sedes educativas con grupos de investigación presentados para evaluación en feria</td>";
        ca += "<td class='center'>" + count1 + " de " + total1 + "</td>";
        ca += "<td class='center'>" + meta1 + "%</td>";//?m=0&s=0&a=50
        ca += "<td class='noExl center'><a href='estra1sedesgruposevaluacionferia.aspx'><img src='images/detalles.png'> Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detalleestra1gruposevaluacionferia.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";

        return ca;
    }




    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("reporteindicadores.aspx");
    }

}