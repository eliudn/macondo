using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;

public partial class menuevalimpacto : System.Web.UI.Page
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
        ca += "<li style='list-style-type: disc;'>Instrumento para rectores</a></li>";
        ca += "<ul style='margin-left:40px;'>";
        ca += "<li style='list-style-type: disc;' ><a href='evalimpacto01.aspx' >Instrumento No. 01</a></li>";
        ca += "<li style='list-style-type: disc;'>Instrumento para coordinadores</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='#'>Instrumento para docentes</a></li>";
        ca += "</ul>"; //Fin Submenu
        ca += "</div>";

        ca += "<h3>Resultados</h3>";
        ca += "<div>"; 
        ca += "<ul style='margin-left:40px;'>"; //Submenu 
        ca += "<li style='list-style-type: disc;'><a href='evalImpactoGeneral.aspx' >Reporte general evaluación de impacto</a></li>";
        ca += "</ul>"; //Fin Submenu     
        ca += "</div>";

        return ca;
    }


   

}