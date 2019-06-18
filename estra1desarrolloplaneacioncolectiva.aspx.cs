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

public partial class estra1desarrolloplaneacioncolectiva : System.Web.UI.Page
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
       lblMomento.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
       Session["m"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
       lblSesion.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
       Session["s"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
       Session["a"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["a"]);

        if(Session["a"] != null)
        {
            lblActividad.Text = Session["a"].ToString();
        }
    }
    private string encabezado()
    {
        string ca = "";

        ca += "<b>Momento: </b>" + lblMomento.Text + "<br/> ";
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
    public static string gvCargarTodosListEvidencias()
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable actividad5 = est.cargarTotalEvidenciasEstrategiaConActividad(HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString(), "1", "5");
        DataTable actividad12 = est.cargarTotalEvidenciasEstrategiaConActividad(HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString(), "1", "12");


        double meta5 = 0;
        int count5 = 0;
        int total5 = 4;
        string resonsable5 = "SIN DEFINIR";
        if (actividad5 != null && actividad5.Rows.Count > 0)
        {
            count5 = actividad5.Rows.Count;
            meta5 = ((double)count5 / (double)total5) * 100;
            //if (meta5 > 100)
            //{
            //    meta5 = 100;
            //}
            count5 = actividad5.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>1.</b> Cronograma de trabajo conjunto para organizar la llegada a las instituciones educativas</td>";
        //ca += "<td class='center'>" + resonsable5 + "</td>";
        ca += "<td class='center'>" + count5 + " de " + total5 + "</td>";
        ca += "<td class='center'>" + meta5 + "%</td>";
        ca += "<td class='center'><a href='estraunoevidenciasactividad.aspx?m=0&s=0&a=5'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        double meta6 = 0;
        int count6 = 0;
        int total6 = 1;
        if (actividad12 != null && actividad12.Rows.Count > 0)
        {
            count6 = actividad12.Rows.Count;
            meta6 = ((double)count6 / (double)total6) * 100;
            //if (meta6 > 100)
            //{
            //    meta6 = 100;
            //}
            count6 = actividad12.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>2.</b> Plan operativo aprobado por interventoría</td>";
        //ca += "<td class='center'>" + resonsable5 + "</td>";
        ca += "<td class='center'>" + count6 + " de " + total6 + "</td>";
        ca += "<td class='center'>" + meta6 + "%</td>";
        ca += "<td class='center'><a href='estraunoevidenciasactividad.aspx?m=0&s=0&a=12'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        return ca;

 
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("reporteindicadores.aspx");
    }


}