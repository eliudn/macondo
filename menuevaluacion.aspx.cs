using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;

public partial class menuevaluacion : System.Web.UI.Page
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

                accordion.InnerHtml = MenuAcordeonGerencia();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
    //Para el Asesor Unimag
    private string MenuAcordeonGerencia()
    {
        string ca = "";

        ca += "<h3>Línea de base</h3>";
        ca += "<div>";
        ca += "<ul>";

                ca += "<li style='list-style-type: square;'>Instrumento de recolección</li>";
                ca += "<ul style='margin-left:20px;'>"; //Submenu 
                ca += "<li style='list-style-type: circle;'>Instrumento para rectores</li>";
                ca += "<li style='list-style-type: circle;'>Instrumente para coordinadores</li>";
                ca += "<li style='list-style-type: circle;'>Instrumente para docentes</li>";
                ca += "</ul>"; //Fin Submenu 

                ca += "<li style='list-style-type: square;'>Resultados</li>";

        ca += "</ul>";
        ca += "</div>";

        ca += "<h3>Evaluación intermedia</h3>";
        ca += "<div>";
        ca += "<ul>";

                ca += "<li style='list-style-type: square;'><a href='estraunopreestructurados.aspx?e=1&m=3'>Preestructurados</a></li>";
                ca += "<li style='list-style-type: circle;'>Instrumento para institución</li>";
                ca += "<li style='list-style-type: circle;'>Instrumente para docentes</li>";
                ca += "</ul>"; //Fin Submenu 

        ca += "</ul>";
        ca += "</div>";

        ca += "<h3>Evaluación de impacto</h3>";
        ca += "<div>";
        ca += "<ul>";
      
                ca += "<li style='list-style-type: square;'><a href='estraunopreestructurados.aspx?e=1&m=4'>Preestructurados</a></li>";
                ca += "<ul style='margin-left:20px;'>"; //Submenu 
                ca += "<li style='list-style-type: circle;'>Instrumento para rectores</li>";
                ca += "<li style='list-style-type: circle;'>Instrumente para coordinadores</li>";
                ca += "<li style='list-style-type: circle;'>Instrumente para docentes</li>";
                ca += "</ul>"; //Fin Submenu 

        ca += "</ul>";
        ca += "</div>";

        return ca;
    }
   
    public void obtenerGET()
    {
        lblMomento.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
       
    }
   
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }

    //Momentos

   
}