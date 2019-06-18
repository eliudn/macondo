using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;

public partial class estradosmomentos : System.Web.UI.Page
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
               
                if (Session["codrol"].ToString() == "15")//Asesor CUC
                {
                    accordion.InnerHtml = MenuAcordeonAsesorCuc();

                }
                else if (Session["codrol"].ToString() == "2" || Session["codrol"].ToString() == "9" || Session["codrol"].ToString() == "20")//Coordinador CUC
                {
                    accordion.InnerHtml = MenuAcordeonCoordinadorCuc();
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }

    //Para el Asesor Cuc
    private string MenuAcordeonAsesorCuc()
    {
        string ca = "";

        ca += "<h3>Momento 1:  Convocatoria y acompañamiento para la conformación de los grupos</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión No. 1: La ruta metodologica apoyada en herramientas virtuales</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 
        ca += "<li style='list-style-type: disc;'><a href='estras004Sedes.aspx?e=2&m=1&s=1&j=1' >Jornada 1</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estras004Sedes.aspx?e=2&m=1&s=1&j=2' >Jornada 2</a></li>";
        ca += "</ul>"; //Fin Submenu        
        ca += "</ul>";
        ca += "</div>";

        ca += "<h3>Momento 3: Diseño de la trayectoria e investigación</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión No. 2: Contexto mundial de la educación</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 
        ca += "<li style='list-style-type: disc;'><a href='estras004Sedes.aspx?e=2&m=3&s=2&j=3' >Jornada 3</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estras004Sedes.aspx?e=2&m=3&s=2&j=4' >Jornada 4</a></li>";
        ca += "</ul>"; //Fin Submenu        
        ca += "</ul>";
        ca += "</div>";

        ca += "<h3>Momento 4: Recorrido de la trayectoria de indagación</h3>";
        ca += "<div>";
        ca += "<ul>";

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión No. 3:  Las pedagogias fundadas en la investigación</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 
        ca += "<li style='list-style-type: disc;'><a href='estras004Sedes.aspx?e=2&m=4&s=3&j=5' >Jornada 5</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estras004Sedes.aspx?e=2&m=4&s=3&j=6' >Jornada 6</a></li>";
        ca += "</ul>"; //Fin Submenu  

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión No. 4:  Los lineamientos de ciclón, dimensiones, componentes y aprendizajes</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 
        ca += "<li style='list-style-type: disc;'><a href='estras004Sedes.aspx?e=2&m=4&s=4&j=7' >Jornada 7</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estras004Sedes.aspx?e=2&m=4&s=4&j=8' >Jornada 8</a></li>";
        ca += "</ul>"; //Fin Submenu 

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión No. 5:  La propuesta de integración curricular de la IEP</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 
        ca += "<li style='list-style-type: disc;'><a href='estras004Sedes.aspx?e=2&m=4&s=5&j=9' >Jornada 9</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estras004Sedes.aspx?e=2&m=4&s=5&j=10' >Jornada 10</a></li>";
        ca += "</ul>"; //Fin Submenu 

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión No. 6:  Las comuninades de aprendizaje, practicas, saber, conocimiento y tranformación apoyadas en las TICS</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 
        ca += "<li style='list-style-type: disc;'><a href='estras004Sedes.aspx?e=2&m=4&s=6&j=11' >Jornada 11</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estras004Sedes.aspx?e=2&m=4&s=6&j=12' >Jornada 12</a></li>";
        ca += "</ul>"; //Fin Submenu 
      
        ca += "</ul>";
        ca += "</div>";

        ca += "<h3>Momento 5: Recorrido de la trayectoria de indagación</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión No. 7: Maestros (as) producen de saber y conocimiento</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 
        ca += "<li style='list-style-type: disc;'><a href='estras004Sedes.aspx?e=2&m=5&s=7&j=13' >Jornada 13</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estras004Sedes.aspx?e=2&m=5&s=7&j=14' >Jornada 14</a></li>";
        ca += "</ul>"; //Fin Submenu        
        ca += "</ul>";
        ca += "</div>";

        ca += "<h3>Momento 6: Acompañamiento para la propagación de ciclón</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión No. 8: Maestros (as) producen de saber y conocimiento</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 
        ca += "<li style='list-style-type: disc;'><a href='estras004Sedes.aspx?e=2&m=6&s=8&j=15' >Jornada 15</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estras004Sedes.aspx?e=2&m=6&s=8&j=16' >Jornada 16</a></li>";
        ca += "</ul>"; //Fin Submenu        
        ca += "</ul>";
        ca += "</div>";


        return ca;
    }

    //Para el Coordinador Cuc
    private string MenuAcordeonCoordinadorCuc()
    {
        string ca = "";

        ca += "<h3>Momento 0:  La planeación colectiva</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type: square;'><a href='estradosevidencias.aspx?e=2&m=0&s=0'>Lineamientos y rutas</a></li>";
        ca += "<li style='list-style-type: square;'><a href='procesosistematizacion.aspx?e=2&m=0' >Proceso de Sistematización</a></li>";
        ca += "</ul>";
        ca += "</div>";

        ca += "<h3>Momento 1:  Convocatoria y acompañamiento para la conformación de los grupos</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type: square;'><a href='procesosistematizacion.aspx?e=2&m=1' >Proceso de Sistematización</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estradosevidencias.aspx?e=2&m=1&s=Evento' >Eventos de socialización del proyecto y la estrategia en las 320 sedes educativas – prematrícula-</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estradosevidencias.aspx?e=2&m=1&s=Jornada' >Jornada de Lanzamiento del proyecto en las sedes beneficiarias, organizadas con las entidades cooperantes</a></li>";
        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión No. 1: La ruta metodologica apoyada en herramientas virtuales</li>";

        ca += "<ul style='margin-left:40px;'>"; //Submenu 
        ca += "<li style='list-style-type: disc;'><a href='estras004SedesReporte.aspx?e=2&m=1&s=1&j=1' >Jornada 1</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estras004SedesReporte.aspx?e=2&m=1&s=1&j=2' >Jornada 2</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estradossesionvirtual.aspx?s=1' >Asistentes sesión virtual</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estradossesionvirtual_evi.aspx?s=1' >Certificación formación virtual</a></li>";
        ca += "</ul>"; //Fin Submenu        
        ca += "</ul>";
        ca += "</div>";

        ca += "<h3>Momento 3: Diseño de la trayectoria e investigación</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type: square;'><a href='procesosistematizacion.aspx?e=2&m=3' >Proceso de Sistematización</a></li>";
        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión No. 2: Contexto mundial de la educación</li>";

        ca += "<ul style='margin-left:40px;'>"; //Submenu 
        ca += "<li style='list-style-type: disc;'><a href='estras004SedesReporte.aspx?e=2&m=3&s=2&j=3' >Jornada 3</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estras004SedesReporte.aspx?e=2&m=3&s=2&j=4' >Jornada 4</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estradossesionvirtual.aspx?s=2' >Asistentes sesión virtual</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estradossesionvirtual_evi.aspx?s=2' >Certificación formación virtual</a></li>";
        ca += "</ul>"; //Fin Submenu        
        ca += "</ul>";
        ca += "</div>";

        ca += "<h3>Momento 4: Recorrido de la trayectoria de indagación</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type: square;'><a href='procesosistematizacion.aspx?e=2&m=4' >Proceso de Sistematización</a></li>";
        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión No. 3:  Las pedagogias fundadas en la investigación</li>";

        ca += "<ul style='margin-left:40px;'>"; //Submenu 
        ca += "<li style='list-style-type: disc;'><a href='estras004SedesReporte.aspx?e=2&m=4&s=3&j=5' >Jornada 5</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estras004SedesReporte.aspx?e=2&m=4&s=3&j=6' >Jornada 6</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estradossesionvirtual.aspx?s=3' >Asistentes sesión virtual</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estradossesionvirtual_evi.aspx?s=3' >Certificación formación virtual</a></li>";
        ca += "</ul>"; //Fin Submenu  

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión No. 4:  Los lineamientos de ciclón, dimensiones, componentes y aprendizajes</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 
        ca += "<li style='list-style-type: disc;'><a href='estras004SedesReporte.aspx?e=2&m=4&s=4&j=7' >Jornada 7</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estras004SedesReporte.aspx?e=2&m=4&s=4&j=8' >Jornada 8</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estradossesionvirtual.aspx?s=4' >Asistentes sesión virtual</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estradossesionvirtual_evi.aspx?s=4' >Certificación formación virtual</a></li>";
        ca += "</ul>"; //Fin Submenu 

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión No. 5:  La propuesta de integración curricular de la IEP</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 
        ca += "<li style='list-style-type: disc;'><a href='estras004SedesReporte.aspx?e=2&m=4&s=5&j=9' >Jornada 9</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estras004SedesReporte.aspx?e=2&m=4&s=5&j=10' >Jornada 10</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estradossesionvirtual.aspx?s=5' >Asistentes sesión virtual</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estradossesionvirtual_evi.aspx?s=5' >Certificación formación virtual</a></li>";
        ca += "</ul>"; //Fin Submenu 

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión No. 6:  Las comuninades de aprendizaje, practicas, saber, conocimiento y tranformación apoyadas en las TICS</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 
        ca += "<li style='list-style-type: disc;'><a href='estras004SedesReporte.aspx?e=2&m=4&s=6&j=11' >Jornada 11</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estras004SedesReporte.aspx?e=2&m=4&s=6&j=12' >Jornada 12</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estradossesionvirtual.aspx?s=6' >Asistentes sesión virtual</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estradossesionvirtual_evi.aspx?s=6' >Certificación formación virtual</a></li>";
        ca += "</ul>"; //Fin Submenu 

        ca += "</ul>";
        ca += "</div>";

        ca += "<h3>Momento 5: Recorrido de la trayectoria de indagación</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type: square;'><a href='procesosistematizacion.aspx?e=2&m=5' >Proceso de Sistematización</a></li>";
        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión No. 7: Maestros (as) producen de saber y conocimiento</li>";

        ca += "<ul style='margin-left:40px;'>"; //Submenu 
        ca += "<li style='list-style-type: disc;'><a href='estras004SedesReporte.aspx?e=2&m=5&s=7&j=13' >Jornada 13</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estras004SedesReporte.aspx?e=2&m=5&s=7&j=14' >Jornada 14</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estradossesionvirtual.aspx?s=7' >Asistentes sesión virtual</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estradossesionvirtual_evi.aspx?s=7' >Certificación formación virtual</a></li>";
        ca += "</ul>"; //Fin Submenu        
        ca += "</ul>";
        ca += "</div>";

        ca += "<h3>Momento 6: Acompañamiento para la propagación de ciclón</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type: square;'><a href='procesosistematizacion.aspx?e=2&m=6' >Proceso de Sistematización</a></li>";
        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sesión No. 8: Maestros (as) producen de saber y conocimiento</li>";
        ca += "<ul style='margin-left:40px;'>"; //Submenu 
        ca += "<li style='list-style-type: disc;'><a href='estras004SedesReporte.aspx?e=2&m=6&s=8&j=15' >Jornada 15</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estras004SedesReporte.aspx?e=2&m=6&s=8&j=16' >Jornada 16</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estradossesionvirtual.aspx?s=8' >Asistentes sesión virtual</a></li>";
        ca += "<li style='list-style-type: disc;'><a href='estradossesionvirtual_evi.aspx?s=8' >Certificación formación virtual</a></li>";
        ca += "</ul>"; //Fin Submenu        
        ca += "</ul>";
        ca += "</div>";


        return ca;
    }

   

}