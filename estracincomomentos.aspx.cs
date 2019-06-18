using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;

public partial class estracincomomentos : System.Web.UI.Page
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
             
                //Cargar los momentos de la Estrategia Nro. 1 para los asesores del UniMag
                if (Session["codrol"].ToString() == "11")
                {
                  
                }
                if (Session["codrol"].ToString() == "12" || Session["codrol"].ToString() == "20")
                {
                    //Cargar los momentos de la Estrategia Nro. 5 para los coordinadores de funtics
                    accordion.InnerHtml = MenuCoordinadorFuntics();
                }
                if (Session["codrol"].ToString() == "10" || Session["codrol"].ToString() == "20")
                {
                    //Cargar los momentos de la Estrategia Nro. 5 para los coordinadores de unimag
                    accordion2.InnerHtml = MenuCoordinadorUnimag();
                }

            
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }

    //sólo puede verlo el usuario Coord Funtics
    private string MenuCoordinadorFuntics()
    {
        string ca = "";

        ca += "<h3>Sesiones</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type: square;'><a href='estracincoevidenciaslineamientos.aspx' >Lineamientos de formación</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estracincoevidenciasmatricula.aspx' >Soportes de matrícula</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estracincomatriculados.aspx' >Listado de Matrícula Diplomado</a></li>";

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Primera sesión: Formación en La Investigación Como Estrategia Pedagógica</li>";
        ca += "<ul style='margin-left:20px;'>"; //Submenu 
        ca += "<li style='list-style-type: circle;'><a href='estracincos004Coord.aspx?e=5&s=1' >S004: Memoria de los espacios de formación</a></li>";
        ca += "</ul>"; //Fin Submenu 

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Segunda Sesión: La investigación como estrategia pedagógica, eje transversal del currículo</li>";
        ca += "<ul style='margin-left:20px;'>"; //Submenu 
        ca += "<li style='list-style-type: circle;'><a href='estracincos004Coord.aspx?e=5&s=2' >S004: Memoria de los espacios de formación</a></li>";
        ca += "</ul>"; //Fin Submenu 

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Tercera Sesión: La sistematización como producción de saber y conocimiento</li>";
        ca += "<ul style='margin-left:20px;'>"; //Submenu 
        ca += "<li style='list-style-type: circle;'><a href='estracincos004Coord.aspx?e=5&s=3' >S004: Memoria de los espacios de formación</a></li>";
        ca += "</ul>"; //Fin Submenu 

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Cuarta Sesión: comunidades de aprendizaje, práctica, saber, conocimiento y transformación apoyadas en TIC- y la apropaición social y ferias de CTeI</li>";
        ca += "<ul style='margin-left:20px;'>"; //Submenu 
        ca += "<li style='list-style-type: circle;'><a href='estracincos004Coord.aspx?e=5&s=4' >S004: Memoria de los espacios de formación</a></li>";
        ca += "</ul>"; //Fin Submenu 

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Quinta Sesión: Innovación y emprendimiento en el marco del programa Ciclón</li>";
        ca += "<ul style='margin-left:20px;'>"; //Submenu 
        ca += "<li style='list-style-type: circle;'><a href='estracincos004Coord.aspx?e=5&s=5' >S004: Memoria de los espacios de formación</a></li>";
        ca += "</ul>"; //Fin Submenu 

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Sexta Sesión: Actividad de cierre y certificación</li>";
        ca += "<ul style='margin-left:20px;'>"; //Submenu 
        ca += "<li style='list-style-type: circle;'><a href='estracincos004Coord.aspx?e=5&s=6' >S004: Memoria de los espacios de formación</a></li>";
        ca += "</ul>"; //Fin Submenu 

        ca += "</ul>";
        ca += "</div>";

      

        return ca;
    }

    //sólo puede verlo el usuario Coord Unimag
    private string MenuCoordinadorUnimag()
    {
        string ca = "";

        ca += "<h3>Actividades</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type: square;'><a href='estracincoevidencias.aspx?s=1' >Consolidación del cómite departamental</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estracincocomitedepartamental.aspx' >Sesiones Comité departamental</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estracincoevidencias.aspx?s=2' >Creación de los cómites subregionales</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estracincocomiteregional.aspx' >Sesiones comités subregional</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estracincoevidencias.aspx?s=3' >Creación, fortalecimiento y desarrollo de la red de apoyo de los grupos de invetigación</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estracincocomiteredapoyo.aspx' >Encuentros red de apoyo</a></li>";
        ca += "<li style='list-style-type: square;'><a href='procesosistematizacion.aspx?e=5&m=1' >Proceso de Sistematización</a></li>";

        //ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Primera sesión: Formación en La Investigación Como Estrategia Pedagógica</li>";
        //ca += "<ul style='margin-left:20px;'>"; //Submenu 
        //ca += "<li style='list-style-type: circle;'><a href='estracincos004Coord.aspx?e=5&s=1' >S004: Memoria de los espacios de formación</a></li>";
        //ca += "</ul>"; //Fin Submenu 

        //ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Segunda Sesión: La investigación como estrategia pedagógica, eje transversal del currículo</li>";
        //ca += "<ul style='margin-left:20px;'>"; //Submenu 
        //ca += "<li style='list-style-type: circle;'><a href='estracincos004Coord.aspx?e=5&s=2' >S004: Memoria de los espacios de formación</a></li>";
        //ca += "</ul>"; //Fin Submenu 

        //ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Tercera Sesión: La sistematización como producción de saber y conocimiento</li>";
        //ca += "<ul style='margin-left:20px;'>"; //Submenu 
        //ca += "<li style='list-style-type: circle;'><a href='estracincos004Coord.aspx?e=5&s=3' >S004: Memoria de los espacios de formación</a></li>";
        //ca += "</ul>"; //Fin Submenu 

        //ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Cuarta Sesión: comunidades de aprendizaje, práctica, saber, conocimiento y transformación apoyadas en TIC- y la apropaición social y ferias de CTeI</li>";
        //ca += "<ul style='margin-left:20px;'>"; //Submenu 
        //ca += "<li style='list-style-type: circle;'><a href='estracincos004Coord.aspx?e=5&s=4' >S004: Memoria de los espacios de formación</a></li>";
        //ca += "</ul>"; //Fin Submenu 

        //ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Quinta Sesión: Innovación y emprendimiento en el marco del programa Ciclón</li>";
        //ca += "<ul style='margin-left:20px;'>"; //Submenu 
        //ca += "<li style='list-style-type: circle;'><a href='estracincos004Coord.aspx?e=5&s=5' >S004: Memoria de los espacios de formación</a></li>";
        //ca += "</ul>"; //Fin Submenu 

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

    //Momentos

    protected void btnSesion0_Click(object sender, EventArgs e)
    {

        if (Session["codrol"] != null)
        {
         //Validar los botones de los momentos a mostrar, este es para los coordinadores UniMag Momento 0
            if (Session["codrol"].ToString() == "10")//10 = Coordinador Unimagdalena
            {
                btnG004Sesion0.Visible = true;
                btnG009Sesion0.Visible = true;

                btnSesion0G003Consolidacion.Visible = false;
                btnSesion0S10Consolidacion.Visible = false;
                btnSesion0G001Consolidacion.Visible = false;

                btnSesion0G003ComitesSugregionales.Visible = false;
                btnSesion0S10ComitesSugregionales.Visible = false;
                btnSesion0G001ComitesSugregionales.Visible = false;

                btnSesion0S10ApoyoGruposInvestigacion.Visible = false;
                btnSesion0G001ApoyoGruposInvestigacion.Visible = false;

            }
            else if (Session["codrol"].ToString() == "11")// 11 = Asesor UniMagdalena
            {

            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
   


       
       
    }


    //Coordinadores UniMag 

    protected void btnG004Sesion0_Click(object sender, EventArgs e)
    {
        Response.Redirect("estracincoevidencias.aspx?s=0&a=1");
    }
    protected void btnG009Sesion0_Click(object sender, EventArgs e)
    {
        Response.Redirect("estracincoevidencias.aspx?s=0&a=10");
    }

    protected void btnSesion0G003Consolidacion_Click(object sender, EventArgs e)
    {
        Response.Redirect("estracincoevidencias.aspx?s=1&a=2");
    }
    protected void btnSesion0S10Consolidacion_Click(object sender, EventArgs e)
    {
        Response.Redirect("estracincoevidencias.aspx?s=1&a=3");
    }
    protected void btnSesion0G001Consolidacion_Click(object sender, EventArgs e)
    {
        Response.Redirect("estracincoevidencias.aspx?s=1&a=4");
    }
    protected void btnSesion0G003ComitesSugregionales_Click(object sender, EventArgs e)
    {
        Response.Redirect("estracincoevidencias.aspx?s=2&a=5");
    }
    protected void btnSesion0S10ComitesSugregionales_Click(object sender, EventArgs e)
    {
        Response.Redirect("estracincoevidencias.aspx?s=2&a=6");
    }
    protected void btnSesion0G001ComitesSugregionales_Click(object sender, EventArgs e)
    {
        Response.Redirect("estracincoevidencias.aspx?s=2&a=7");
    }
    protected void btnSesion0S10ApoyoGruposInvestigacion_Click(object sender, EventArgs e)
    {
        Response.Redirect("estracincoevidencias.aspx?s=3&a=8");
    }
    protected void btnSesion0G001ApoyoGruposInvestigacion_Click(object sender, EventArgs e)
    {
        Response.Redirect("estracincoevidencias.aspx?s=3&a=9");
    }

    protected void btnSesion0Consolidacion_Click(object sender, EventArgs e)
    {

        if (Session["codrol"] != null)
        {
            //Validar los botones de los momentos a mostrar, este es para los coordinadores UniMag Momento 0
            if (Session["codrol"].ToString() == "10")//10 = Coordinador Unimagdalena
            {
                btnG004Sesion0.Visible = false;
                btnG009Sesion0.Visible = false;

                btnSesion0G003Consolidacion.Visible = true;
                btnSesion0S10Consolidacion.Visible = true;
                btnSesion0G001Consolidacion.Visible = true;

                btnSesion0G003ComitesSugregionales.Visible = false;
                btnSesion0S10ComitesSugregionales.Visible = false;
                btnSesion0G001ComitesSugregionales.Visible = false;

                btnSesion0S10ApoyoGruposInvestigacion.Visible = false;
                btnSesion0G001ApoyoGruposInvestigacion.Visible = false;

            }
            else if (Session["codrol"].ToString() == "11")// 11 = Asesor UniMagdalena
            {

            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
      

    }
  

    protected void btnSesion0ComitesSugregionales_Click(object sender, EventArgs e)
    {
        btnG004Sesion0.Visible = false;
        btnG009Sesion0.Visible = false;

        btnSesion0G003Consolidacion.Visible = false;
        btnSesion0S10Consolidacion.Visible = false;
        btnSesion0G001Consolidacion.Visible = false;

        btnSesion0G003ComitesSugregionales.Visible = true;
        btnSesion0S10ComitesSugregionales.Visible = true;
        btnSesion0G001ComitesSugregionales.Visible = true;

        btnSesion0S10ApoyoGruposInvestigacion.Visible = false;
        btnSesion0G001ApoyoGruposInvestigacion.Visible = false;
    }
   

    protected void btnSesion0ApoyoGruposInvestigacion_Click(object sender, EventArgs e)
    {
        btnG004Sesion0.Visible = false;
        btnG009Sesion0.Visible = false;

        btnSesion0G003Consolidacion.Visible = false;
        btnSesion0S10Consolidacion.Visible = false;
        btnSesion0G001Consolidacion.Visible = false;

        btnSesion0G003ComitesSugregionales.Visible = false;
        btnSesion0S10ComitesSugregionales.Visible = false;
        btnSesion0G001ComitesSugregionales.Visible = false;

        btnSesion0S10ApoyoGruposInvestigacion.Visible = true;
        btnSesion0G001ApoyoGruposInvestigacion.Visible = true;

    }
  



    protected void btnCargarEvidencias_Click(object sender, EventArgs e)
    {
        Response.Redirect("estraunoevidencias.aspx?m=0&s=0");
    }
    
    protected void btnMomento0EjecucionFinanciera_Click(object sender, EventArgs e)
    {
        Response.Redirect("estrag008.aspx?e=1&m=0&s=0&a=1");
    }
   //Momento 1
    protected void btnMomento1_Click(object sender, EventArgs e)
    {

        if (Session["codrol"] != null)
        {
        //Validar los botones de los momentos a mostrar, este es para los coordinadores y asesores UniMag Estrategia Nro. 1 - Momento 1
                if (Session["codrol"].ToString() == "10" )//10 = Coordinador Unimagdalena
                {
                  
            
                }
                else if (Session["codrol"].ToString() == "11")// 11 = Asesor UniMagdalena
                {
                   
                }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }

        
        
    }
    protected void btnMomento1CargarEvidencias_Click(object sender, EventArgs e)
    {
        Response.Redirect("ginvestigacionlistado.aspx");
    }
    protected void btnMomento1g006_Click(object sender, EventArgs e)
    {
        Response.Redirect("estrag006.aspx?e=1&m=1&s=0");
    }
    protected void btnMomento1s002_Click(object sender, EventArgs e)
    {
        Response.Redirect("estras002.aspx?e=1&m=1&s=0&a=7");
    }
    protected void btnMomento1Bitacora1_Click(object sender, EventArgs e)
    {
        Response.Redirect("estraunobitacorauno.aspx?e=1&m=1&s=1");
    }
    protected void btnMomento1Bitacora2_Click(object sender, EventArgs e)
    {
        Response.Redirect("estraunobitacorados.aspx?e=1&m=1&s=2");
    }
    protected void btnMomento1Bitacora3_Click(object sender, EventArgs e)
    {
        Response.Redirect("estraunobitacoratres.aspx?e=1&m=1&s=3");
    }
    protected void btnMomento1s002Sesion4_Click(object sender, EventArgs e)
    {
        Response.Redirect("estras002.aspx?e=1&m=1&s=4&a=10");
    }
    protected void btnMomento1s007_Click(object sender, EventArgs e)
    {
        Response.Redirect("estras007.aspx?e=1&m=1&s=5");
    }
    protected void btnMomento1Etapa123_Click(object sender, EventArgs e)
    {
      
       
    }

   

   

  

    protected void btnMomento1Bitacora3_1_Click(object sender, EventArgs e)
    {
        Response.Redirect("estraunobitacoratres.aspx");
    }

    protected void btnMomento1EvaluacionAsesoria_Click(object sender, EventArgs e)
    {
        Response.Redirect("estraunoevalasesoria.aspx");
    }

    //Momento 2

    protected void btnMomento2_Click(object sender, EventArgs e)
    {
        if (Session["codrol"] != null)
        {
         if (Session["codrol"].ToString() == "10")//10 = Coordinador Unimagdalena
                {
                   
         
                }
                else if (Session["codrol"].ToString() == "11")//11 = Asesor Unimagdalena
                {
                   // btnCargarEvidenciasMomento2.Visible = true;

                }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
       

        //btnMomento1Bitacora1.Visible = false;
        //btnMomento1Bitacora2.Visible = false;
        //btnMomento1Bitacora3.Visible = false;
    }

    protected void btnCargarEvidenciasMomento2_Click(object sender, EventArgs e)
    {
        Response.Redirect("estraunoevidencias.aspx?m=2&s=0");
    }

    //Momento 3

    protected void btnMomento3_Click(object sender, EventArgs e)
    {
        if (Session["codrol"] != null)
        {
         if (Session["codrol"].ToString() == "10" )//Coordinador UniMag
                {
                   

                }
                else if (Session["codrol"].ToString() == "11")//Asesor UniMag
                {
                 
                }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
       

        //btnMomento1Bitacora1.Visible = false;
        //btnMomento1Bitacora2.Visible = false;
        //btnMomento1Bitacora3.Visible = false;
    }
    protected void btnCargarEvidenciasMomento3_Click(object sender, EventArgs e)
    {
        Response.Redirect("estraunoevidencias.aspx?m=3&s=0");
    }
    protected void btnMomento3Bitacora4_Click(object sender, EventArgs e)
    {
        Response.Redirect("estrag007.aspx?e=1&m=3&s=0");
    }
    protected void btnMomento3Bitacora5_Click(object sender, EventArgs e)
    {
        //Response.Redirect("estrag007.aspx?e=1&m=3&s=0");
    }
    protected void btnMomento3s002Sesion1_Click(object sender, EventArgs e)
    {
        Response.Redirect("estras002.aspx?e=1&m=3&s=2&a=6");
    }
    protected void btnMomento3s007_Click(object sender, EventArgs e)
    {
        Response.Redirect("estras007.aspx?e=1&m=3&s=2");
    }
    //Momento 4
    protected void btnMomento4_Click(object sender, EventArgs e)
    {

        if (Session["codrol"].ToString() == "10")//10 = Coordinador Unimagdalena
        {
           

        }
        else if (Session["codrol"].ToString() == "11")//11 = Asesor Unimagdalena
        {
           
        }

        //btnMomento1Bitacora1.Visible = false;
        //btnMomento1Bitacora2.Visible = false;
        //btnMomento1Bitacora3.Visible = false;
    }
    protected void btnCargarEvidenciasMomento4_Click(object sender, EventArgs e)
    {
        Response.Redirect("estraunoevidencias.aspx?m=4&s=0");
    }
    protected void btnMomento4s002_Click(object sender, EventArgs e)
    {
        Response.Redirect("estras002.aspx?e=1&m=4&s=0&a=3");
    }
    protected void btnMomento4s007_Click(object sender, EventArgs e)
    {
        Response.Redirect("estras007.aspx?e=1&m=4&s=0");
    }
    
    protected void btnMomento4s003_Click(object sender, EventArgs e)
    {
        Response.Redirect("s003/estras003.aspx?e=1&m=4&s=0");
    }

    //Momento 5
    protected void btnMomento5_Click(object sender, EventArgs e)
    {
        if (Session["codrol"] != null)
        {
            if (Session["codrol"].ToString() == "10")//Coordinador UniMag
            {
               

            }
            else if (Session["codrol"].ToString() == "11")//Asesor UniMag
            {
               
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }

    }
    protected void btnInscripcionGruposEvidenciasMomento5_Click(object sender, EventArgs e)
    {
        Response.Redirect("estraunoevidenciasferias.aspx");
    }
    protected void btnActadeReunionMomento5_Click(object sender, EventArgs e)
    {
        Response.Redirect("estraunoevidencias.aspx?m=5");
    }
    
    //Sesión 1
    protected void btnSesion1FormacionOnda_Click(object sender, EventArgs e)
    {
        //btnSesion1Tema1.Visible = true;
        //btnSesion2Tema1.Visible = false;

        //btnSesion1Tema1G001.Visible = false;
        //btnSesion1Tema1S005.Visible = false;
        //btnSesion1Tema1S006.Visible = false;
        //btnSesion1Tema1S004.Visible = false;

        //btnSesion2Tema1G001.Visible = false;
        //btnSesion2Tema1S005.Visible = false;
        //btnSesion2Tema1S006.Visible = false;
        //btnSesion2Tema1S004.Visible = false;

        btnG004Sesion0.Visible = false;
        btnG009Sesion0.Visible = false;

        btnSesion0G003Consolidacion.Visible = false;
        btnSesion0S10Consolidacion.Visible = false;
        btnSesion0G001Consolidacion.Visible = false;

        btnSesion0G003ComitesSugregionales.Visible = false;
        btnSesion0S10ComitesSugregionales.Visible = false;
        btnSesion0G001ComitesSugregionales.Visible = false;

        btnSesion0S10ApoyoGruposInvestigacion.Visible = false;
        btnSesion0G001ApoyoGruposInvestigacion.Visible = false;
    }
    //Tema 1
    protected void btnSesion1Tema1_Click(object sender, EventArgs e)
    {
        //btnSesion1Tema1.Visible = true;
        //btnSesion1Tema1G001.Visible = true;
        //btnSesion1Tema1S005.Visible = true;
        //btnSesion1Tema1S006.Visible = true;
        //btnSesion1Tema1S004.Visible = true;

        btnG004Sesion0.Visible = false;
        btnG009Sesion0.Visible = false;

        btnSesion0G003Consolidacion.Visible = false;
        btnSesion0S10Consolidacion.Visible = false;
        btnSesion0G001Consolidacion.Visible = false;

        btnSesion0G003ComitesSugregionales.Visible = false;
        btnSesion0S10ComitesSugregionales.Visible = false;
        btnSesion0G001ComitesSugregionales.Visible = false;

        btnSesion0S10ApoyoGruposInvestigacion.Visible = false;
        btnSesion0G001ApoyoGruposInvestigacion.Visible = false;
    }

    protected void btnSesion1Tema1G001_Click(object sender, EventArgs e)
    {
        Response.Redirect("estracincoevidencias.aspx?s=1&a=1");
    }
    protected void btnSesion1Tema1S005_Click(object sender, EventArgs e)
    {
        mostrarmensaje("error","web");
        //Response.Redirect("estras005.aspx?s=1&a=1");
    }
    protected void btnSesion1Tema1S006_Click(object sender, EventArgs e)
    {
        if (Session["codrol"] != null)//Coord Unimag
        {
            if (Session["codrol"].ToString() == "10")//Coord Unimag
            {
                Response.Redirect("estras006.aspx?e=1&m=1&s=1");
            }
            else if (Session["codrol"].ToString() == "12")//Coord Funtics
            {
                Response.Redirect("estras006.aspx?e=5&m=1&s=1");
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
       
       
    }

    protected void btnSesion1Tema1S004_Click(object sender, EventArgs e)
    {
        if (Session["codrol"] != null)//Coord Unimag
        {
            if (Session["codrol"].ToString() == "10")//Coord Unimag
            {
                Response.Redirect("estras004.aspx?e=1&m=1&s=1");
            }
            else if (Session["codrol"].ToString() == "12")//Coord Funtics
            {
                Response.Redirect("estras004.aspx?e=5&m=1&s=1");
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }


    }

    protected void btnSesion1Tema1G002_Click(object sender, EventArgs e)
    {
        Response.Redirect("estracincoevidencias.aspx?s=1&a=2");
    }

    //Sesión 2
    protected void btnSesion2FormacionOnda_Click(object sender, EventArgs e)
    {
        //btnSesion1Tema1.Visible = false;
        //btnSesion2Tema1.Visible = true;

        //btnSesion1Tema1G001.Visible = false;
        //btnSesion1Tema1S005.Visible = false;
        //btnSesion1Tema1S006.Visible = false;
        //btnSesion1Tema1S004.Visible = false;

        //btnSesion2Tema1G001.Visible = false;
        //btnSesion2Tema1S005.Visible = false;
        //btnSesion2Tema1S006.Visible = false;
        //btnSesion2Tema1S004.Visible = false;

        btnG004Sesion0.Visible = false;
        btnG009Sesion0.Visible = false;

        btnSesion0G003Consolidacion.Visible = false;
        btnSesion0S10Consolidacion.Visible = false;
        btnSesion0G001Consolidacion.Visible = false;

        btnSesion0G003ComitesSugregionales.Visible = false;
        btnSesion0S10ComitesSugregionales.Visible = false;
        btnSesion0G001ComitesSugregionales.Visible = false;

        btnSesion0S10ApoyoGruposInvestigacion.Visible = false;
        btnSesion0G001ApoyoGruposInvestigacion.Visible = false;
    }
    //Tema 2
    protected void btnSesion2Tema1_Click(object sender, EventArgs e)
    {
        //btnSesion1Tema1.Visible = false;
        //btnSesion2Tema1.Visible = true;

        //btnSesion1Tema1G001.Visible = false;
        //btnSesion1Tema1S005.Visible = false;
        //btnSesion1Tema1S006.Visible = false;
        //btnSesion1Tema1S004.Visible = false;

        //btnSesion2Tema1G001.Visible = true;
        //btnSesion2Tema1S005.Visible = true;
        //btnSesion2Tema1S006.Visible = true;
        //btnSesion2Tema1S004.Visible = true;

        btnG004Sesion0.Visible = false;
        btnG009Sesion0.Visible = false;

        btnSesion0G003Consolidacion.Visible = false;
        btnSesion0S10Consolidacion.Visible = false;
        btnSesion0G001Consolidacion.Visible = false;

        btnSesion0G003ComitesSugregionales.Visible = false;
        btnSesion0S10ComitesSugregionales.Visible = false;
        btnSesion0G001ComitesSugregionales.Visible = false;

        btnSesion0S10ApoyoGruposInvestigacion.Visible = false;
        btnSesion0G001ApoyoGruposInvestigacion.Visible = false;
    }

    protected void btnSesion2Tema1G001_Click(object sender, EventArgs e)
    {
        Response.Redirect("estracincoevidencias.aspx?s=2&a=1");
    }
    protected void btnSesion2Tema1S005_Click(object sender, EventArgs e)
    {
        mostrarmensaje("error", "web");
        //Response.Redirect("estras005.aspx?s=1&a=1");
    }
    protected void btnSesion2Tema1S006_Click(object sender, EventArgs e)
    {
        if (Session["codrol"] != null)//Coord Unimag
        {
            if (Session["codrol"].ToString() == "10")//Coord Unimag
            {
                Response.Redirect("estras006.aspx?e=1&m=1&s=2");
            }
            else if (Session["codrol"].ToString() == "12")//Coord Funtics
            {
                Response.Redirect("estras006.aspx?e=5&m=1&s=2");
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }


    }

    protected void btnSesion2Tema1S004_Click(object sender, EventArgs e)
    {
        if (Session["codrol"] != null)//Coord Unimag
        {
            if (Session["codrol"].ToString() == "10")//Coord Unimag
            {
                Response.Redirect("estras004.aspx?e=1&m=1&s=2");
            }
            else if (Session["codrol"].ToString() == "12")//Coord Funtics
            {
                Response.Redirect("estras004.aspx?e=5&m=1&s=2");
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }


    }

    protected void btnSesion2Tema1G002_Click(object sender, EventArgs e)
    {
        Response.Redirect("estracincoevidencias.aspx?s=2&a=2");
    }
}