using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;

public partial class menumanuales : System.Web.UI.Page
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
               
                if (Session["codrol"].ToString() == "18")//Asesor CUC
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

        ca += "<h3>Manuales en PDF</h3>";
        ca += "<div>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 
        ca += "<li style='list-style-type: disc;' ><a href='Manuales/conformacion_grupos_de_investigacion.pdf' target='_blank'> Conformación grupos de investigación</a></li>";
        ca += "<li style='list-style-type: disc;' ><a href='Manuales/creacion_nuevo_estudiante.pdf' target='_blank'>Creación de nuevo estudiante</a></li>";        
        ca += "<li style='list-style-type: disc;' ><a href='Manuales/mover_docente_de_sede.pdf' target='_blank'>Mover docente de sede</a></li>";
        ca += "<li style='list-style-type: disc;' ><a href='Manuales/subir_evidencias.pdf' target='_blank'>Subir evidencias</a></li>";
        ca += "<li style='list-style-type: disc;' ><a href='Manuales/eliminar_red_tematica.pdf' target='_blank'>Eliminar red temática</a></li>";
        ca += "</ul>"; //Fin Submenu
        ca += "</div>";

        return ca;
    }


   

}