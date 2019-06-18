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

public partial class listestraunoevidenciassupervisor : System.Web.UI.Page
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

        DataTable actividad1 = est.cargarTotalEvidenciasEstrategiaConActividad(HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString(), "1", "1");
        DataTable actividad2 = est.cargarTotalEvidenciasEstrategiaConActividad(HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString(), "1", "2");
        DataTable actividad3 = est.cargarTotalEvidenciasEstrategiaConActividad(HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString(), "1", "3");
        DataTable actividad4 = est.cargarTotalEvidenciasEstrategiaConActividad(HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString(), "1", "4");
        DataTable actividad5 = est.cargarTotalEvidenciasEstrategiaConActividad(HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString(), "1", "5");

        int meta = 0;
        int count = 0;
        int total = 1;
        string resonsable = "SIN DEFINIR";
        if (actividad1 != null && actividad1.Rows.Count > 0)
        {
            meta = actividad1.Rows.Count / total * 100;
            //if (meta > 100)
            //{
            //    meta = 100;
            //}
            count = actividad1.Rows.Count;
            resonsable = actividad1.Rows[0]["pnombre"].ToString() + " " + actividad1.Rows[0]["papellido"].ToString();
        }
        ca += "<tr>";
        ca += "<td><b>1.</b> Lineamientos de la estrategia acompañamiento y formación de los grupos de investigación</td>";
        //ca += "<td class='center'>" + resonsable + "</td>";
        ca += "<td class='center'>" + count + " de " + total + "</td>";
        ca += "<td class='center'>" + meta + "%</td>";
        ca += "<td class='center'><a href='estraunoevidenciasactividad.aspx?m=0&s=0&a=1'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        int meta2 = 0;
        int count2 = 0;
        string resonsable2 = "SIN DEFINIR";
        if (actividad2 != null && actividad2.Rows.Count > 0)
        {
            meta2 = actividad2.Rows.Count / total * 100;
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}
            count2 = actividad2.Rows.Count;
            resonsable2 = actividad2.Rows[0]["pnombre"].ToString() + " " + actividad2.Rows[0]["papellido"].ToString();
        }
        ca += "<tr>";
        ca += "<td><b>2.</b> Ruta metodológica de investigación e innovación del Proyecto Ciclón</td>";
        //ca += "<td class='center'>" + resonsable2 + "</td>";
        ca += "<td class='center'>" + count2 + " de " + total + "</td>";
        ca += "<td class='center'>" + meta2 + "%</td>";
        ca += "<td class='center'><a href='estraunoevidenciasactividad.aspx?m=0&s=0&a=2'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        int meta3 = 0;
        int count3 = 0;
        string resonsable3 = "SIN DEFINIR";
        if (actividad3 != null && actividad3.Rows.Count > 0)
        {
            meta3 = actividad3.Rows.Count / total * 100;
            //if (meta3 > 100)
            //{
            //    meta3 = 100;
            //}
            count3 = actividad3.Rows.Count;
            resonsable3 = actividad3.Rows[0]["pnombre"].ToString() + " " + actividad3.Rows[0]["papellido"].ToString();
        }
        ca += "<tr>";
        ca += "<td><b>3.</b> Jornadas de formación dirigidas a los estudiantes</td>";
        //ca += "<td class='center'>" + resonsable3 + "</td>";
        ca += "<td class='center'>" + count3 + " de " + total + "</td>";
        ca += "<td class='center'>" + meta3 + "%</td>";
        ca += "<td class='center'><a href='estraunoevidenciasactividad.aspx?m=0&s=0&a=3'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        double meta4 = 0;
        int count4 = 0;
        int total4 = 2;
        string resonsable4 = "SIN DEFINIR";
        if (actividad4 != null && actividad4.Rows.Count > 0)
        {
            count4 = actividad4.Rows.Count;
            meta4 = ((double)count4 / (double)total4) * 100;
            //if (meta4 > 100)
            //{
            //    meta4 = 100;
            //}
            count4 = actividad4.Rows.Count;
            resonsable4 = actividad4.Rows[0]["pnombre"].ToString() + " " + actividad4.Rows[0]["papellido"].ToString();
        }
        ca += "<tr>";
        ca += "<td><b>4.</b> Lineamientos pedagógicos y logisticos de las ferias institucionales</td>";
        //ca += "<td class='center'>" + resonsable4 + "</td>";
        ca += "<td class='center'>" + count4 + " de " + total4 + "</td>";
        ca += "<td class='center'>" + meta4 + "%</td>";
        ca += "<td class='center'><a href='estraunoevidenciasactividad.aspx?m=0&s=0&a=4'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

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
            resonsable5 = actividad5.Rows[0]["pnombre"].ToString() + " " + actividad5.Rows[0]["papellido"].ToString();
        }
        ca += "<tr>";
        ca += "<td><b>5.</b> Cronograma de trabajo conjunto para organizar la llegada a las instituciones educativas</td>";
        //ca += "<td class='center'>" + resonsable5 + "</td>";
        ca += "<td class='center'>" + count5 + " de " + total5 + "</td>";
        ca += "<td class='center'>" + meta5 + "%</td>";
        ca += "<td class='center'><a href='estraunoevidenciasactividad.aspx?m=0&s=0&a=5'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";
        

        return ca;

 
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("reporteindicadores.aspx");
    }


}