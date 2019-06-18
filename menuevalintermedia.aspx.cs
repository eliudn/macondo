using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;

public partial class menuevalintermedia : System.Web.UI.Page
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
               
                if (Session["codrol"].ToString() == "18"|| Session["codrol"].ToString() == "20")//Asesor CUC
                {
                    accordion.InnerHtml = MenuAcordeonGerencia();

                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }

    //Menú Gerencia
    private string MenuAcordeonGerencia()
    {
        string ca = "";

        ca += "<h3>Instrumentos de recolección</h3>";
        ca += "<div>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 
        ca += "<li style='list-style-type: square;'>";
        ca += "Instrumento para rectores";
        ca += "<ul style='margin-left:40px;'>";
        ca += "<li style='list-style-type: disc;' ><a href='intermediainstrurectores.aspx' >Instrumento No. 01</a></li>";
        ca += "<li style='list-style-type: disc;' ><a href='intermediainstrurectores2.aspx' >Instrumento No. 02.2</a></li>";
        ca += "</ul>";
        ca += "</li>";
        ca += "<li style='list-style-type: square;'>";
        ca += "Instrumento para coordinadores";
        ca += "<ul style='margin-left:40px;'>";
        ca += "<li style='list-style-type: disc;' ><a href='intermediainstrucoor.aspx' >Instrumento No. 03</a></li>";
        ca += "</ul>";
        ca += "</li>";
        ca += "<li style='list-style-type: square;'>";
        ca += "Instrumento para docentes";
        ca += "<ul style='margin-left:40px;'>";
        ca += "<li style='list-style-type: disc;' ><a href='intermediainstrudocentes.aspx' >Instrumento No. 02.1</a></li>";
        ca += "<li style='list-style-type: disc;' ><a href='intermediainstrudocentes2.aspx' >Instrumento No. 5</a></li>";
        ca += "</ul>";
        ca += "</li>";
        ca += "</ul>"; //Fin Submenu
        ca += "</div>";

        ca += "<h3>Resultados</h3>";
        ca += "<div>"; 
        ca += "<ul style='margin-left:40px;'>"; //Submenu 
        ca += "<li style='list-style-type: disc;'><a href='evalintermediaGeneral.aspx' >Reporte general evaluación intermedia</a></li>";
        ca += "</ul>"; //Fin Submenu     
        ca += "</div>";

        return ca;
    }


   

}