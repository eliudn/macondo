using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;

public partial class reporteindicadores : System.Web.UI.Page
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
                if (Session["codrol"].ToString() == "9" || Session["codrol"].ToString() == "1" || Session["codrol"].ToString() == "18" || Session["codrol"].ToString() == "20")
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

        ca += "<h3>Estrategia 1</h3>";
        ca += "<div>";
        ca += "<ul>";

        ca += "<li style='list-style-type: square;'><b>Momento 0</b></li><br/>";
        ca += "<ul style='margin-left:20px;'>"; //Submenu 
        ca += "<li style='list-style-type: circle;'><a href='listestraunoevidenciassupervisor.aspx?m=0&s=0' style='text-decoration:underline;' >Diseño de lineamientos y rutas metodológicas</a></li>";
        ca += "<li style='list-style-type: circle;'><a href='estra1disenoaprobacionlineamientos.aspx?m=0&s=0' style='text-decoration:underline;'>Diseño y aprobación de lineamientos de las ferias municipales</a></li>";
        ca += "<li style='list-style-type: circle;'><a href='estra1espaciosmunicipales.aspx?m=0&s=0' style='text-decoration:underline;'>Organizar 56 espacios municipales de de apropiación social</a></li>";
        ca += "<li style='list-style-type: circle;'><a href='estra1gruposevaluacionferia.aspx?m=0&s=0' style='text-decoration:underline;'>Sedes educativas con grupos de investigación presentados para evaluación en feria</a></li>";
        ca += "<li style='list-style-type: circle;'><a href='estra1desarrolloplaneacioncolectiva.aspx?m=0&s=0' style='text-decoration:underline;'>desarrollo de la planeación colectiva</a></li>";
        ca += "</ul>"; //Fin Submenu 

        ca += "<br/><li style='list-style-type: square;'><b>Momento 1</b></li><br/>";
        ca += "<ul style='margin-left:20px;'>"; //Submenu 
        ca += "<li style='list-style-type: circle;'><a href='jornadasformacion.aspx?m=1&e=1' style='text-decoration:underline;'>Desarrollo de las jornadas de formación</a></li>";
        ca += "<li style='list-style-type: circle;'><a href='informedesarrollo.aspx?m=1&s=1' style='text-decoration:underline;'>Informe del desarrollo de las Etapas 1, 2 y 3</a></li>";
        ca += "<li style='list-style-type: circle;'><a href='informeacompanamiento.aspx?m=1&s=1' style='text-decoration:underline;'>Informe del acompañamiento de las etapas 1, 2 y 3</a></li>";
        ca += "</ul>"; //Fin Submenu 

        ca += "<br/><li style='list-style-type: square;'><b>Momento 3</b></li><br/>";
        ca += "<ul style='margin-left:20px;'>"; //Submenu 
        ca += "<li style='list-style-type: circle;'><a href='grupostrayectoriaindagacion.aspx' style='text-decoration:underline;'>Grupos de investigación que elaboran el presupuesto y diseñan las trayectorias de indagación en CICLÓN</a></li>";
        ca += "<li style='list-style-type: circle;'><a href='asesorgruposinvestigacion.aspx?m=3&e=1' style='text-decoration:underline;'>El asesor acompaña a los grupos de investigación a elaborar el presupuesto y desarrollar la etapa 4 Diseño de las trayectorías de indagación</a></li>";
        ca += "<li style='list-style-type: circle;'><a href='asesorgruposinvestigacionetapa5.aspx?m=3&e=1' style='text-decoration:underline;'>El asesor realiza el acompañamiento a los grupos de investigación  en el desarrollo de las investigaciones.</a></li>";
        ca += "</ul>"; //Fin Submenu 

        ca += "<br/><li style='list-style-type: square;'><b>Momento 4</b></li><br/>";
        ca += "<ul style='margin-left:20px;'>"; //Submenu 
        ca += "<li style='list-style-type: circle;'><a href='gruposinvestigacioninformesinvestigacion.aspx?m=4&e=1' style='text-decoration:underline;'>Los grupos de investigación elaboran el informe de investigación para lo cual retoma todos aquellos registros de las etapas de investigación que han realizado durante su desarrollo, y que de acuerdo al diseño metodológico acordado con el asesor cuentan con instrumentos y formatos de apoyo a la investigación</a></li>";
        ca += "<li style='list-style-type: circle;'><a href='asesoracompanamientom4.aspx?m=4&e=1' style='text-decoration:underline;'>El asesor realiza el acompañamiento a los grupos de investigación de  para elaborar sus informes de investigación</a></li>";
        ca += "</ul>"; //Fin Submenu 

        ca += "</ul>";
        ca += "</div>";

        ca += "<h3>Estrategia 2</h3>";
        ca += "<div>";
        ca += "<ul>";

        ca += "<li style='list-style-type: square;'><b>Momento 0</b></li><br/>";
        ca += "<ul style='margin-left:20px;'>"; //Submenu 
        ca += "<li style='list-style-type: circle;'><a href='estra2disenolineamientos.aspx?m=0&e=2' style='text-decoration:underline;'>Diseño de lineamientos de la estrategia de autoformación</a></li>";
        ca += "<li style='list-style-type: circle;'><a href='estra2formarmaestros.aspx?m=0&e=2' style='text-decoration:underline;'>Formar a los maestros(as) acompañantes  coinvestigadores e investigadores en los lineamientos </a></li>";
        ca += "<li style='list-style-type: circle;'><a href='estra2mesastrabajosede.aspx?m=0&e=2' style='text-decoration:underline;'>Mesas de trabajo en cada una de las sedes educativas beneficiarias</a></li>";
        ca += "<li style='list-style-type: circle;'><a href='estra2inscripcionmaestros.aspx?m=0&e=2' style='text-decoration:underline;'>Inscripción de maestros y maestras en las líneas temáticas del Proyecto Ciclón</a></li>";
        ca += "<li style='list-style-type: circle;'><a href='estra2recursoseconomicos.aspx?m=0&e=2' style='text-decoration:underline;'>Entrega de recursos económicos </a></li>";
        ca += "</ul>"; //Fin Submenu 

        ca += "<br/><li style='list-style-type: square;'><b>Momento 1</b></li><br/>";
        ca += "<ul style='margin-left:20px;'>"; //Submenu 
        ca += "<li style='list-style-type: circle;'><a href='estra2convocatoriaacompanamiento.aspx?m=1&e=2' style='text-decoration:underline;'>Convocatoria y acompañamiento para la conformación de los grupos</a></li>";
        ca += "</ul>"; //Fin Submenu 

        ca += "<br/><li style='list-style-type: square;'><b>Momento 3</b></li><br/>";
        ca += "<ul style='margin-left:20px;'>"; //Submenu 
        ca += "<li style='list-style-type: circle;'><a href='estra2sesionformacion2.aspx?m=3&e=2' style='text-decoration:underline;'>Sesión de formación  No. 2. Contexto mundial de la educación</a></li>";
        ca += "</ul>"; //Fin Submenu 

        ca += "<br/><li style='list-style-type: square;'><b>Momento 4</b></li><br/>";
        ca += "<ul style='margin-left:20px;'>"; //Submenu 
        ca += "<li style='list-style-type: circle;'><a href='estra2recorridotrayectorias.aspx?m=4&e=2' style='text-decoration:underline;'>Recorrido de las trayectorias de indagación</a></li>";
        ca += "</ul>"; //Fin Submenu 

        ca += "</ul>";
        ca += "</div>";

        ca += "<h3>Estrategia 4</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type: square;'><a href='estra4momentocero.aspx?s=0' >Momento 0 </a></li>";
        ca += "<li style='list-style-type: square;'><a href='estra4memorias004_2016.aspx?m=1&s=1&e=4' style='text-decoration:underline;'>Sesión 1</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estra4memorias004.aspx?m=1&s=2&e=4' style='text-decoration:underline;'>Sesión 2</a></li>";
       
        ca += "</ul>";
        ca += "</div>";

        ca += "<h3>Estrategia 5</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type: square;'><a href='estra5disenolineamientos.aspx' style='text-decoration:underline;'>Diseño de lineamientos de la estrategia </a></li>";
        ca += "<li style='list-style-type: square;'><a href='estra5lineamientosformacion.aspx' style='text-decoration:underline;'>Formar a los funcionarios de la Gobernación </a></li>";
        ca += "<li style='list-style-type: square;'><a href='estra5sesiones.aspx?s=1' style='text-decoration:underline;'>Primera sesión: Formación en Ondas y la investigación como estrategia pedagógica  </a></li>";
        ca += "<li style='list-style-type: square;'><a href='estra5sesiones.aspx?s=2' style='text-decoration:underline;'>Segunda sesión: Recuperación del acumulado de la experiencia de implementación de la etapa 1  </a></li>";
        ca += "<li style='list-style-type: square;'><a href='estra5sesiones.aspx?s=3' style='text-decoration:underline;'>Tercera sesión: La sistematización como producción de saber y conocimiento </a></li>";

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

    protected void btnEstrategia1_(object sender, EventArgs e)
    {

        if (Session["codrol"] != null)
        {
         //Validar los botones de los momentos a mostrar, este es para usuario Supervisión
            if (Session["codrol"].ToString() == "9" || Session["codrol"].ToString() == "1" || Session["codrol"].ToString() == "18")
            {
                btnMomento0.Visible = true;
                btnMomento1.Visible = true;
                btnMomento3.Visible = true;
                btnMomento4.Visible = true;
                
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
   }
    protected void btnMomento0_(object sender, EventArgs e)
    {
        btnDisenoLineamientos.Visible = true;
        btnMomento0DesarrolloPlaneacionColectiva.Visible = true;
        btnMomento0DisenoAprobacionLineamientos.Visible = true;
        btnMomento0EspaciosMunicipales.Visible = true;
        btnMomento0GruposEvaluacionFeria.Visible = true;
    }

    protected void btnMomento1_(object sender, EventArgs e)
    {
        btnDesarrolloJornadas.Visible = true;
        btnInformeDesarrollo.Visible = true;
        btnInformeAcompanamiento.Visible = true;
    }

    protected void btnMomento3_(object sender, EventArgs e)
    {
        btnGruposTrayectoriaIndagacion.Visible = true;
        btnAsesorGruposInvestigacion.Visible = true;
        btnAsesorAcompanamiento.Visible = true;
    }

    protected void btnMomento4_(object sender, EventArgs e)
    {
        btngruposInvestigacionInformesInvestigacion.Visible = true;
        btnAsesorAcompanamientoM4.Visible = true;
    }
    


    protected void btnDisenoLineamientos_Click(object sender, EventArgs e)
    {
        Response.Redirect("listestraunoevidenciassupervisor.aspx?m=0&s=0");
    }

    protected void btnMomento0DisenoAprobacionLineamientos_Click(object sender, EventArgs e)
    {
        Response.Redirect("estra1disenoaprobacionlineamientos.aspx?m=0&s=0");
    }
    protected void btnMomento0EspaciosMunicipales_Click(object sender, EventArgs e)
    {
        Response.Redirect("estra1espaciosmunicipales.aspx?m=0&s=0");
    }
    protected void btnMomento0GruposEvaluacionFeria_Click(object sender, EventArgs e)
    {
        Response.Redirect("estra1gruposevaluacionferia.aspx?m=0&s=0");
    }

    protected void btnMomento0DesarrolloPlaneacionColectiva_Click(object sender, EventArgs e)
    {
        Response.Redirect("estra1desarrolloplaneacioncolectiva.aspx?m=0&s=0");
    }
    
    protected void btnDesarrolloJornadas_Click(object sender, EventArgs e)
    {
        Response.Redirect("jornadasformacion.aspx?m=1&e=1");
    }

    protected void btnInformeDesarrollo_Click(object sender, EventArgs e)
    {
        Response.Redirect("informedesarrollo.aspx?m=1&s=1");
    }

    protected void btnInformeAcompanamiento_Click(object sender, EventArgs e)
    {
        Response.Redirect("informeacompanamiento.aspx?m=1&s=1");
    }


    //momento 3
    protected void btnGruposTrayectoriaIndagacion_Click(object sender, EventArgs e)
    {
        Response.Redirect("grupostrayectoriaindagacion.aspx");
    }

    protected void btnAsesorGruposInvestigacion_Click(object sender, EventArgs e)
    {
        Response.Redirect("asesorgruposinvestigacion.aspx?m=3&e=1");
    }

     protected void btnAsesorAcompanamiento_Click(object sender, EventArgs e)
    {
        Response.Redirect("asesorgruposinvestigacionetapa5.aspx?m=3&e=1");
    }

    
    //momento 4
     protected void btngruposInvestigacionInformesInvestigacion_Click(object sender, EventArgs e)
    {
        Response.Redirect("gruposinvestigacioninformesinvestigacion.aspx?m=4&e=1");
    }
     protected void btnAsesorAcompanamientoM4_Click(object sender, EventArgs e)
    {
        Response.Redirect("asesoracompanamientom4.aspx?m=4&e=1");
    }


    //Estrategias 2
     protected void btnEstrategia2_(object sender, EventArgs e)
    {

        if (Session["codrol"] != null)
        {
         //Validar los botones de los momentos a mostrar, este es para usuario Supervisión
            if (Session["codrol"].ToString() == "9" || Session["codrol"].ToString() == "1" || Session["codrol"].ToString() == "18")
            {
                btnEstra2Momento0.Visible = true;
                btnEstra2Momento1.Visible = true;
                btnEstra2Momento3.Visible = true;
                btnEstra2Momento4.Visible = true;
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
   }

    protected void btnEstra2Momento0_Click(object sender, EventArgs e)
    {
        btnEstra2Momento0DisenLineamientos.Visible = true;
        btnEstra2Momento0FormarMaestros.Visible = true;
        btnEstra2Momento0MesasTrabajoSede.Visible = true;
        btnEstra2Momento0InscripcionMaestros.Visible = true;
        btnEstra2Momento0RecursosEconomicos.Visible = true;
    }

    protected void btnEstra2Momento0DisenLineamientos_Click(object sender, EventArgs e)
    {
        Response.Redirect("estra2disenolineamientos.aspx?m=0&e=2");
    }
    protected void btnEstra2Momento0FormarMaestros_Click(object sender, EventArgs e)
    {
        Response.Redirect("estra2formarmaestros.aspx?m=0&e=2");
    }

    protected void btnEstra2Momento0MesasTrabajoSede_Click(object sender, EventArgs e)
    {
        Response.Redirect("estra2mesastrabajosede.aspx?m=0&e=2");
    }

    protected void btnEstra2Momento0InscripcionMaestros_Click(object sender, EventArgs e)
    {
        Response.Redirect("estra2inscripcionmaestros.aspx?m=0&e=2");
    }

    protected void btnEstra2Momento0RecursosEconomicos_Click(object sender, EventArgs e)
    {
        Response.Redirect("estra2recursoseconomicos.aspx?m=0&e=2");
    }

    //MOMENTO 1 Estrategias 2
    protected void btnEstra2Momento1_Click(object sender, EventArgs e)
    {
        btnEstra2Momento1ConvocatoriaAcompanamiento.Visible = true;
    }
    protected void btnEstra2Momento1ConvocatoriaAcompanamiento_Click(object sender, EventArgs e)
    {
        Response.Redirect("estra2convocatoriaacompanamiento.aspx?m=1&e=2");
    }
    protected void btnEstra2Momento1Session1_Click(object sender, EventArgs e)
    {
        Response.Redirect("estra2convocatoriaacompanamiento.aspx?m=1&e=2");
    }
    //MOMENTO 3 Estrategias 2
    protected void btnEstra2Momento3_Click(object sender, EventArgs e)
    {
        btnEstra2Momento3SesionFormacion2.Visible = true;
    }
     protected void btnEstra2Momento3SesionFormacion2_Click(object sender, EventArgs e)
    {
        Response.Redirect("estra2sesionformacion2.aspx?m=3&e=2");
    }
     protected void btnEstra2Momento1Session2_Click(object sender, EventArgs e)
     {
         Response.Redirect("estra2sesionformacion2.aspx?m=3&e=2");
     }
     //MOMENTO 4 Estrategias 2
     protected void btnEstra2Momento4_Click(object sender, EventArgs e)
     {
         btnEstra2Momento4RecorridoTrayectorias.Visible = true;
     }
     protected void btnEstra2Momento4RecorridoTrayectorias_Click(object sender, EventArgs e)
     {
         Response.Redirect("estra2recorridotrayectorias.aspx?m=4&e=2");
     }
     protected void btnEstra2Momento1Session3_Click(object sender, EventArgs e)
     {
         Response.Redirect("estra2recorridotrayectorias.aspx?m=4&e=2");
     }


     //Estrategias 4
     protected void btnEstrategia4_(object sender, EventArgs e)
     {

         if (Session["codrol"] != null)
         {
             //Validar los botones de los momentos a mostrar, este es para usuario Supervisión
             if (Session["codrol"].ToString() == "9" || Session["codrol"].ToString() == "1" || Session["codrol"].ToString() == "18")
             {
                 btnEstra4Sesion1.Visible = true;
                 btnEstra4Sesion2.Visible = true;
                 btnMomentoCero.Visible = true;
                
             }
         }
         else
         {
             Response.Redirect("Default.aspx");
         }
     }

     //SESIÓN 1 Estrategias 4
     protected void btnEstra4Sesion1_Click(object sender, EventArgs e)
     {
         Response.Redirect("estra4memorias004_2016.aspx?m=1&s=1&e=4");

     }
     //SESIÓN 1 Estrategias 4
     protected void btnEstra4Sesion2_Click(object sender, EventArgs e)
     {
         Response.Redirect("estra4memorias004.aspx?m=1&s=2&e=4");
     }

     //Momento 0 Estrategias 4
     protected void btnMomentoCero_Click(object sender, EventArgs e)
     {
         Response.Redirect("estra4momentocero.aspx?s=0");
     }

     //Estrategias 5
     protected void btnEstrategia5_(object sender, EventArgs e)
     {

         if (Session["codrol"] != null)
         {
             //Validar los botones de los momentos a mostrar, este es para usuario Supervisión
             if (Session["codrol"].ToString() == "9" || Session["codrol"].ToString() == "1" || Session["codrol"].ToString() == "18")
             {
                 btnDisenoLineamientosEstr5.Visible = true;
                 btnFormarFuncionarios.Visible = true;
                 btnPrimeraSesion.Visible = true;
                 btnSegundaSesion.Visible = true;
                 btnTerceraSesion.Visible = true;

             }
         }
         else
         {
             Response.Redirect("Default.aspx");
         }
     }

     //Estrategias 5
     protected void btnDisenoLineamientosEstr5_Click(object sender, EventArgs e)
     {
         Response.Redirect("estra5disenolineamientos.aspx");
     }

     protected void btnFormarFuncionarios_Click(object sender, EventArgs e)
     {
         Response.Redirect("estra5lineamientosformacion.aspx");
     }

     protected void btnPrimeraSesion_Click(object sender, EventArgs e)
     {
         Response.Redirect("estra5sesiones.aspx?s=1");
     }

     protected void btnSegundaSesion_Click(object sender, EventArgs e)
     {
         Response.Redirect("estra5sesiones.aspx?s=2");
     }

     protected void btnTerceraSesion_Click(object sender, EventArgs e)
     {
         Response.Redirect("estra5sesiones.aspx?s=3");
     }
}