using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;

public partial class estratresmomentos : System.Web.UI.Page
{
    Funciones fun = new Funciones();
    Estrategias est = new Estrategias();
    protected void Page_Load(object sender, EventArgs e)
    {
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 
        if (!IsPostBack)
        {
            if (Session["codrol"] != null)
            {
                obtenerGET();
                if (Session["codrol"].ToString() == "9" || Session["codrol"].ToString() == "1" || Session["codrol"].ToString() == "18" || Session["codrol"].ToString() == "19"|| Session["codrol"].ToString() == "20")
                {
                    accordion.InnerHtml = MenuAcordeonVisores();
                }

            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }

    public void obtenerGET()
    {
        //lblSesion.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
    }


    private string MenuAcordeonVisores()
    {
        string ca = "";

        ca += "<h3>Planeación</h3>";
        ca += "<div>";
        ca += "<ul>";

        ca += "<li style='list-style-type: square;'><a href='estratresevidencias.aspx?p=p'>Documento de lineamiento aprobado</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estratresevidencias.aspx?p=p_2'>Plan operativo aprobado</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estratresevidencias.aspx?p=p_3'>Matriz de indicadores</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estratresevidencias.aspx?p=p_4'>Actas de comité técnico</a></li>";
        //ca += "<ul style='margin-left:20px;'>"; //Submenu 
        //ca += "<li style='list-style-type: circle;'><a href='listestraunoevidenciassupervisor.aspx?m=0&s=0' >Diseño de lineamientos y rutas metodológicas</a></li>";
        //ca += "<li style='list-style-type: circle;'><a href='estra1disenoaprobacionlineamientos.aspx?m=0&s=0' >Diseño y aprobación de lineamientos de las ferias municipales</a></li>";
        //ca += "<li style='list-style-type: circle;'><a href='estra1espaciosmunicipales.aspx?m=0&s=0' >Organizar 56 espacios municipales de de apropiación social</a></li>";
        //ca += "<li style='list-style-type: circle;'><a href='estra1gruposevaluacionferia.aspx?m=0&s=0' >Sedes educativas con grupos de investigación presentados para evaluación en feria</a></li>";
        //ca += "<li style='list-style-type: circle;'><a href='estra1desarrolloplaneacioncolectiva.aspx?m=0&s=0' >desarrollo de la planeación colectiva</a></li>";
        //ca += "</ul>"; //Fin Submenu 

        ca += "</ul>";
        ca += "</div>";//Fin Planeación

        ca += "<h3>Evaluación</h3>";
        ca += "<div>";
        ca += "<ul>";

        ca += "<li style='list-style-type: square;'><a href='estratresevidencias.aspx?p=e'>Levantamiento de línea de base</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estratresevidencias.aspx?p=e_2'>Evaluación intermedia</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estratresevidencias.aspx?p=e_3'>Evaluación final</a></li>";


        ca += "</ul>";
        ca += "</div>";

        ca += "<h3>Monitoreo</h3>";
        ca += "<div>";
        ca += "<ul>";

        ca += "<li style='list-style-type: square;'><a href='estratresevidencias.aspx?p=m'>Primer Monitoreo</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estratresevidencias.aspx?p=m_2'>Segundo Monitoreo</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estratresevidencias.aspx?p=m_3'>Tercer Monitoreo</a></li>";
       
        ca += "</ul>";
        ca += "</div>";

        ca += "<h3>Seguimiento</h3>";
        ca += "<div>";
        ca += "<ul>";

        ca += "<li style='list-style-type: square;'><a href='estratresevidencias.aspx?p=s' >Actas de acompañamiento y seguimiento</a></li>";

        ca += "</ul>";
        ca += "</div>";

       
        ca += "<h3>Apropiación y comunicación</h3>";
        ca += "<div>";
        ca += "<ul>";

        ca += "<li style='list-style-type: square;'><a href='estratresevidencias.aspx?p=ac'>Actas de reunión</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estratresevidencias.aspx?p=ac_2' >Actas eventos de transferencia</a></li>";

        ca += "</ul>";
        ca += "</div>";

        ca += "<h3>Sistematización</h3>";
        ca += "<div>";
        ca += "<ul>";

        ca += "<li style='list-style-type: square;'><a href='estratresevidencias.aspx?p=si' >Actas de acompañamiento </a></li>";

        ca += "</ul>";
        ca += "</div>";


        return ca;
    }

    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }

}