using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;

public partial class estracuatromomentos : System.Web.UI.Page
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

                //Cargar los momentos de la Estrategia Nro. 4 para los asesores de FUNTICS
                if (Session["codrol"].ToString() == "13")
                {
                    accordion.InnerHtml = MenuAcordeonAsesorFuntics();
                }

                if (Session["codrol"].ToString() == "12" || Session["codrol"].ToString() == "20" || Session["codrol"].ToString() == "18")
                {
                    accordion.InnerHtml = MenuAcordeonCoordinadorFuntics();
                }
                cerrarSessiones();               
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
    //Para el Asesor Funtics
    private string MenuAcordeonAsesorFuntics()
    {
        string ca = "";

        ca += "<h3>Desarrollo de las sesiones / niveles de juegos</h3>";
        ca += "<div>";
        ca += "<ul>";

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión 1: Conformación de la comunidad de estudiantes que se gozan la ciencia</li>";
        ca += "<ul style='margin-left:20px;'>"; //Submenu 1
        ca += "<li style='list-style-type: circle;'>Memoria de los espacios de formación Nivel 1</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 2 
        ca += "<li style='list-style-type: disc;'><a href='confiredtematica.aspx' >Conformación de las redes temáticas</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estras004_2016.aspx?e=4&m=1&s=1' >Memoria S004 2016</a></li>";
        ca += "</ul>"; //Fin Submenu 2       
        ca += "</ul>"; //Fin Submenu 1

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión 2: Preparándome para gozarme la ciencia</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 2 
        ca += "<li style='list-style-type: disc;'><a href='estras004.aspx?e=4&m=1&s=2' >Memoria S004</a></li>";
        ca += "</ul>"; //Fin Submenu 2  

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión 3: Las rutas para gozarme la ciencia</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 2 
        ca += "<li style='list-style-type: disc;'><a href='estras004.aspx?e=4&m=1&s=3' >Memoria S004</a></li>";
        ca += "</ul>"; //Fin Submenu 2 

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión 4: Encarrílate con la investigación</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 2 
        ca += "<li style='list-style-type: disc;'><a href='estras004.aspx?e=4&m=1&s=4' >Memoria S004</a></li>";
        ca += "</ul>"; //Fin Submenu 2 

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión 5: Haciéndole el juego a la ciencia desde la virtualidad</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 2 
        ca += "<li style='list-style-type: disc;'><a href='estras004.aspx?e=4&m=1&s=5' >Memoria S004</a></li>";
        ca += "</ul>"; //Fin Submenu 2 

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión 6:  Pa' ciencia con las herramientas</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 2 
        ca += "<li style='list-style-type: disc;'><a href='estras004.aspx?e=4&m=1&s=6' >Memoria S004</a></li>";
        ca += "</ul>"; //Fin Submenu 2 

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión 7: En las ferias la investigación es una fiesta</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 2 
        ca += "<li style='list-style-type: disc;'><a href='estras004.aspx?e=4&m=1&s=7' >Memoria S004</a></li>";
        ca += "</ul>"; //Fin Submenu 2 

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión 8: Gocémonos la ciencia respetando los derechos de autor</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 2 
        ca += "<li style='list-style-type: disc;'><a href='estras004.aspx?e=4&m=1&s=8' >Memoria S004</a></li>";
        ca += "</ul>"; //Fin Submenu 2 

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión 9: El goce de preparar el informe de nuestra investigación</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 2 
        ca += "<li style='list-style-type: disc;'><a href='estras004.aspx?e=4&m=1&s=9' >Memoria S004</a></li>";
        ca += "</ul>"; //Fin Submenu 2 

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión 10: Las niñas, los niños y los jóvenes nos gozamos la ciencia divulgando nuestro trabajo</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 2 
        ca += "<li style='list-style-type: disc;'><a href='estras004.aspx?e=4&m=1&s=10' >Memoria S004</a></li>";
        ca += "</ul>"; //Fin Submenu 2 

        ca += "</ul>";
        ca += "</div>";


        return ca;
    }

    //Para el Asesor Funtics
    private string MenuAcordeonCoordinadorFuntics()
    {
        string ca = "";

        ca += "<h3>Momento pedagógico 0: Lineamientos y ruta metodológica de la estrategia</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type: square;'><a href='estracuatroevidenciascoord.aspx?m=0&s=0&a=1' >Lineamientos y ruta metodológica de la estrategia</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estracuatroevidenciascoord.aspx?m=0&s=0&a=2' >Desarrollo de la actividad</a></li>";
        ca += "<li style='list-style-type: square;'><a href='procesosistematizacion.aspx?e=4&m=0' >Proceso de Sistematización</a></li>";
        ca += "</ul>";
        ca += "</div>";

        ca += "<h3>Desarrollo de las sesiones / niveles de juegos</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type: square;'><a href='procesosistematizacion.aspx?e=4&m=1' >Proceso de Sistematización</a></li>";
        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión 1: Conformación de la comunidad de estudiantes que se gozan la ciencia</li>";
        ca += "<ul style='margin-left:20px;'>"; //Submenu 1
        ca += "<li style='list-style-type: circle;'>Memoria de los espacios de formación Nivel 1</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 2 
        ca += "<li style='list-style-type: disc;'><a href='verRedTematica.aspx' >Ver Redes Temáticas conformadas</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estras004coordinador_2016.aspx?e=4&m=1&s=1' >Ver Memorias por asesor 2016</a></li>";
        ca += "</ul>"; //Fin Submenu 2       
        ca += "</ul>"; //Fin Submenu 1

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión 2: Preparándome para gozarme la ciencia</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 2 
        ca += "<li style='list-style-type: disc;'><a href='estras004coordinador.aspx?e=4&m=1&s=2' >Ver Memorias por asesor</a></li>";
        ca += "</ul>"; //Fin Submenu 2  

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión 3: Las rutas para gozarme la ciencia</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 2 
        ca += "<li style='list-style-type: disc;'><a href='estras004coordinador.aspx?e=4&m=1&s=3' >Ver Memorias por asesor</a></li>";
        ca += "</ul>"; //Fin Submenu 2 

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión 4: Encarrílate con la investigación</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 2 
        ca += "<li style='list-style-type: disc;'><a href='estras004coordinador.aspx?e=4&m=1&s=4' >Ver Memorias por asesor</a></li>";
        ca += "</ul>"; //Fin Submenu 2 

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión 5: Haciéndole el juego a la ciencia desde la virtualidad</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 2 
        ca += "<li style='list-style-type: disc;'><a href='estras004coordinador.aspx?e=4&m=1&s=5' >Ver Memorias por asesor</a></li>";
        ca += "</ul>"; //Fin Submenu 2 

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión 6:  Pa' ciencia con las herramientas</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 2 
        ca += "<li style='list-style-type: disc;'><a href='estras004coordinador.aspx?e=4&m=1&s=6' >Ver Memorias por asesor</a></li>";
        ca += "</ul>"; //Fin Submenu 2 

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión 7: En las ferias la investigación es una fiesta</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 2 
        ca += "<li style='list-style-type: disc;'><a href='estras004coordinador.aspx?e=4&m=1&s=7' >Ver Memorias por asesor</a></li>";
        ca += "</ul>"; //Fin Submenu 2 

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión 8: Gocémonos la ciencia respetando los derechos de autor</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 2 
        ca += "<li style='list-style-type: disc;'><a href='estras004coordinador.aspx?e=4&m=1&s=8' >Ver Memorias por asesor</a></li>";
        ca += "</ul>"; //Fin Submenu 2 

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión 9: El goce de preparar el informe de nuestra investigación</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 2 
        ca += "<li style='list-style-type: disc;'><a href='estras004coordinador.aspx?e=4&m=1&s=9' >Ver Memorias por asesor</a></li>";
        ca += "</ul>"; //Fin Submenu 2 

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión 10: Las niñas, los niños y los jóvenes nos gozamos la ciencia divulgando nuestro trabajo</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 2 
        ca += "<li style='list-style-type: disc;'><a href='estras004coordinador.aspx?e=4&m=1&s=10' >Ver Memorias por asesor</a></li>";
        ca += "</ul>"; //Fin Submenu 2 

        ca += "</ul>";
        ca += "</div>";


        return ca;
    }

    public void obtenerGET()
    {
        lblMomento.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
    }
    public void cerrarSessiones()
    {
       
    }
    
   
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }

    
    
}