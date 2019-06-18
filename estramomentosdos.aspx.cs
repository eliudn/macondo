using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;

public partial class estramomentos : System.Web.UI.Page
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

                //Cargar los momentos de la Estrategia Nro. 1 para los asesores del UniMag
                if (Session["codrol"].ToString() == "11")
                {
                    accordion.InnerHtml = MenuAcordeonAsesorUnimag();
                    btnMomento0.Visible = false;
                    btnMomento2.Visible = false;
                    
                }

                if (Session["codrol"].ToString() == "10" || Session["codrol"].ToString() == "9" || Session["codrol"].ToString() == "20")
                {
                    accordion.InnerHtml = MenuCoordinadorUnimag();
                }

                //Cargar los momentos de la Estrategia Nro. 1 para los coordnadores del MAFERPI
                if (Session["codrol"].ToString() == "17")
                {
                    accordion.InnerHtml = MenuCoordinadorMaferpi();
                    btnMomento0.Visible = false;
                    btnMomento2.Visible = false;
                    btnMomento1.Visible = false;
                    btnMomento4.Visible = false;
                    btnMomento3.Visible = false;
                }

                if (lblMomento.Text == "0")
                    validarRegresoMomento0();
                else if(lblMomento.Text == "1")
                    validarRegresoMomento1();
                else if (lblMomento.Text == "2")
                    validarRegresoMomento2();
                else if (lblMomento.Text == "3")
                    validarRegresoMomento3();
                else if (lblMomento.Text == "4")
                    validarRegresoMomento4();
                else if (lblMomento.Text == "5")
                    validarRegresoMomento5();




                if (Session["g007"] != null)
                {
                        validarRegresog007();
                }
                else if (Session["g008"] != null)
                {
                    validarRegresog007();
                }

                cerrarSessiones();
               
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
    //Para el Asesor Unimag
    private string MenuAcordeonAsesorUnimag()
    {
        string ca = "";

        ca += "<h3>Momento pedagógico 1: Convocatoria y acompañamiento para la conformación del grupo</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type: square;'><a href='configrupoinvestigacion.aspx' >Conformación de los Grupos de Investigación</a></li>";
            ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Proyectos abiertos</li>";
            ca += "<ul style='margin-left:40px;'>"; //Submenu 
            ca += "<li style='list-style-type: square;'><a href='estraunobitacorauno.aspx?e=1&m=1&s=1' >Estar en Ciclón es la vía</a></li>";
            ca += "<li style='list-style-type: square;'><a href='estraunobitacorados.aspx?e=1&m=1&s=2' >Perturbación de la Onda en Ciclón</a></li>";
            ca += "<li style='list-style-type: square;'><a href='estraunobitacoratres.aspx?e=1&m=1&s=3' >Superposición de la Onda</a></li>";
            ca += "</ul>"; //Fin Submenu 
        ca += "<li style='list-style-type: square;'><a href='estras002.aspx?e=1&m=1&s=4&a=10' >Registro de asesoría, acompañamiento y formación </a></li>";
        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'><a href='estraunopreestructurados.aspx?e=1&m=1'>Proyectos preestructurados y semi-Preestructurados</a></li>";
        //ca += "<ul style='margin-left:20px;'>"; //Submenu 
        //ca += "<li style='list-style-type: circle;'><a href='estraunoevidencias.aspx?m=1&s=0&a=7' >Medio Ambiente</a></li>";
        //ca += "<li style='list-style-type: circle;'><a href='estraunoevidencias.aspx?m=1&s=0&a=8' >Bienestar Infantil y juvenil</a></li>";
        //ca += "</ul>"; //Fin Submenu 
       
        ca += "</ul>";
        ca += "</div>";

        ca += "<h3>Momento pedagógico 3: Acompañamiento para el desarrollo de las etapas, diseño y recorrido de las trayectorias de indagación</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type: square;'><a href='estrag007.aspx?e=1&m=3&s=0' >Presupuesto</a></li>";
            ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Proyectos abiertos</li>";
            ca += "<ul style='margin-left:40px;'>"; //Submenu 
            ca += "<li style='list-style-type: square;'><a href='estraunobitacoracinco.aspx?e=1&m=3&s=0' >Trayectorías de indagación</a></li>";
            ca += "<li style='list-style-type: square;'><a href='estraunobitacoraseis.aspx?e=1&m=3' >Recorrido de la trayectoria de indagación</a></li>";
            ca += "</ul>"; //Fin Submenu 
        ca += "<li style='list-style-type: square;'><a href='estras002.aspx?e=1&m=3&s=2&a=6' >Registro de asesoría, acompañamiento y formación </a></li>";
        //ca += "<li style='list-style-type: square;'><a href='estraunoevidenciass007.aspx?e=1&m=3&s=0' >S007: Evaluación de la asesoría</a></li>";

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'><a href='estraunopreestructurados.aspx?e=1&m=3'>Proyectos preestructurados y semi-Preestructurados</a></li>";
        //ca += "<ul style='margin-left:20px;'>"; //Submenu 
        //ca += "<li style='list-style-type: circle;'><a href='estraunoevidencias.aspx?m=3&s=0&a=9' >Medio Ambiente</a></li>";
        //ca += "<li style='list-style-type: circle;'><a href='estraunoevidencias.aspx?m=3&s=0&a=10' >Bienestar Infantil y juvenil</a></li>";
        //ca += "</ul>"; //Fin Submenu 

        ca += "</ul>";
        ca += "</div>";

        ca += "<h3>Momento pedagógico 4: Acompañamiento para la reflexión de Ciclón</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type: square;'><a href='estras003_estategia1.aspx?e=1&m=4&s=0' >Informe de investigación </a></li>";
        ca += "<li style='list-style-type: square;'><a href='estraunobitacorasiete.aspx?e=1&m=4&s=0' >Proyección de la investigación</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estras002.aspx?e=1&m=4&s=0&a=3' >Registro de asesoría, acompañamiento y formación </a></li>";
        ca += "<li style='list-style-type: square;'><a href='estraunobitacora4punto1evi.aspx?d=1' >Informe financiero de ejecución de recursos del primer desembolso</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estraunobitacora4punto1evi.aspx?d=2' >Informe financiero de ejecución de recursos del segundo desembolso</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estraunobitacora4punto1evi.aspx?d=3' >Informe financiero de ejecución de recursos del tercer desembolso</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='configrupoinves003.aspx?e=1&m=4' >S003: Informe de investigación grupos de investigación</a></li>";

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'><a href='estraunopreestructurados.aspx?e=1&m=4'>Proyectos preestructurados y semi-Preestructurados</a></li>";
        //ca += "<ul style='margin-left:20px;'>"; //Submenu 
        //ca += "<li style='list-style-type: circle;'><a href='estraunoevidencias.aspx?m=4&s=0&a=11' >Medio Ambiente</a></li>";
        //ca += "<li style='list-style-type: circle;'><a href='estraunoevidencias.aspx?m=4&s=0&a=12' >Bienestar Infantil y juvenil</a></li>";
        //ca += "</ul>"; //Fin Submenu 

        ca += "</ul>";
        ca += "</div>";

        ca += "<h3>Momento pedagógico 5: Acompañamiento para la propagación de Ciclón</h3>";
        ca += "<div>";
        ca += "<ul>";
        //ca += "<li style='list-style-type: square;'><a href='estraunoevidenciasferias.aspx' >Espacios de apropiación a nivel institucional</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estraunoespaciosapro.aspx?e=1&m=5' >Espacios de apropiación a nivel institucional</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estraunos008.aspx?e=1&m=5' >Resumen Artículo de Investigación </a></li>";
        ca += "<li style='list-style-type: square;'><a href='estraunoparticipantesferias.aspx' >Maestros participantes en Comité de ferias</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='estraunoevidencias.aspx?m=5' >Acta de reunión</a></li>";

        ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'><a href='estraunopreestructurados.aspx?e=1&m=5'>Proyectos preestructurados y semi-Preestructurados</a></li>";
        //ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Preestructurados</li>";
        //ca += "<ul style='margin-left:20px;'>"; //Submenu 
        //ca += "<li style='list-style-type: circle;'><a href='estraunoevidencias.aspx?m=5&s=0&a=13' >Medio Ambiente</a></li>";
        //ca += "<li style='list-style-type: circle;'><a href='estraunoevidencias.aspx?m=5&s=0&a=14' >Bienestar Infantil y juvenil</a></li>";
        //ca += "</ul>"; //Fin Submenu 

        ca += "</ul>";
        ca += "</div>";


        return ca;
    }
    //Para el Coordinador Unimagdalena
    private string MenuCoordinadorUnimag()
    {
        string ca = "";

        ca += "<h3>Momento pedagógico 0: La planeación colectiva</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type: square;'><a href='estraunoevidenciaslineapedago.aspx' >Lineamientos Pedagógicos de los espacios de apropiación</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estraunoevidenciaspropmetodoc.aspx' >Propuesta metadológica o ruta</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estraunoevidenciasplanoperativo.aspx' >Plan Operativo</a></li>";
        ca += "</ul>";
        ca += "</div>";

        // ca += "<h3>Momento pedagógico 1: Convocatoria y acompañamiento para la conformación del grupo</h3>";
        // ca += "<div>";
        // ca += "<ul>";
        // //ca += "<li style='list-style-type: square;'><a href='ginvestigacionlistado.aspx' >Planeación y divulgación de la convocatoria</a></li>";
        // //ca += "<li style='list-style-type: square;'><a href='estrag006.aspx?e=1&m=1&s=0' >G006: Entrega de material pedagógico</a></li>";
        // ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'><a href='ginvestigacionlistado.aspx'>Convocatoria</a></li>";
        // ca += "<ul style='margin-left:20px;'>"; //Submenu 
        // ca += "<li style='list-style-type: circle;'><a href='verGruposInvestigacion.aspx' >Ver Conformación Grupos de Investigación</a></li>";
        // ca += "<li style='list-style-type: circle;'><a href='verestras002.aspx?e=1&m=1&s=4' >S002: Registro de asesoría, acompañamiento y formación</a></li>";
        // ca += "<li style='list-style-type: circle;'><a href='verEstraUnoBitacoraUno.aspx' >B01: Estar en Ciclón es la vía</a></li>";
        // ca += "<li style='list-style-type: circle;'><a href='verestraunobitacorados.aspx' >B02: Perturbación de la Onda en Ciclón</a></li>";
        // ca += "<li style='list-style-type: circle;'><a href='verestraunobitacoratres.aspx' >B03: Superposición de la Onda</a></li>";
        // ca += "<li style='list-style-type: circle;'><a href='procesosistematizacion.aspx?e=1&m=1' >Proceso de Sistematización</a></li>";
        // ca += "<li style='list-style-type: circle;'><a href='estraunoevidenciasformacompa.aspx?e=1&m=1'>Planeación y materiales pedagógicos</a></li>";
        // ca += "</ul>"; //Fin Submenu 

        // ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Jornadas de formación</li>";
        // ca += "<ul style='margin-left:20px;'>"; //Submenu 
        // ca += "<li style='list-style-type: circle;'><a href='estraunojornadaformacion.aspx?m=1&j=1' >Jornada de formación: la pregunta como punto de partida</a></li>";
        // ca += "<li style='list-style-type: circle;'><a href='estraunojornadaformacion.aspx?m=1&j=2' >Jornada de formación: en la ruta metodológica</a></li>";
        // //ca += "<li style='list-style-type: circle;'><a href='estraunoevidenciasjornaforma.aspx?e=1&m=1' >Jornada de formación: la pregunta como punto de partida</a></li>";
        // //ca += "<li style='list-style-type: circle;'><a href='estraunoevidenciasjornaforma2.aspx?e=1&m=1' >Jornada de formación: en la ruta metodológica</a></li>";
        // ca += "</ul>"; //Fin Submenu 

        // ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'><a href='estraunopreestructuradoscoord.aspx?e=1&m=1'>Preestructurados</a></li>";
        // //ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Preestructurados</li>";
        // //ca += "<ul style='margin-left:20px;'>"; //Submenu 
        // //ca += "<li style='list-style-type: circle;'><a href='estraunoevidenciasCoor.aspx?m=1&s=0&a=7' >Medio Ambiente</a></li>";
        // //ca += "<li style='list-style-type: circle;'><a href='estraunoevidenciasCoor.aspx?m=1&s=0&a=8' >Bienestar Infantil y juvenil</a></li>";
        // //ca += "</ul>"; //Fin Submenu 

        // ca += "</ul>";
        // ca += "</div>";

        // ca += "<h3>Momento pedagógico 2: Definición de la linea de investigación y del tipo de asesoria</h3>";
        // ca += "<div>";
        // ca += "<ul>";
        // ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'><a href='estraunogruposlineatematica.aspx'>Grupos de investigación por línea temática</a></li>";
        // ca += "<ul style='margin-left:20px;'>"; //Submenu 
        // //ca += "<li style='list-style-type: square;'><a href='estraunoevidencias.aspx?m=2&s=0' >Cargar Evidencias</a></li>";
        // ca += "<li style='list-style-type: circle;'><a href='procesosistematizacion.aspx?e=1&m=2' >Proceso de Sistematización</a></li>";
        // ca += "</ul>"; //Fin Submenu 

        // ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'><a href='estraunopreestructuradoscoord.aspx?e=1&m=2'>Preestructurados</a></li>";
        // //ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Preestructurados</li>";
        // //ca += "<ul style='margin-left:20px;'>"; //Submenu 
        // //ca += "<li style='list-style-type: circle;'><a href='estraunoevidenciasCoor.aspx?m=1&s=0&a=9' >Medio Ambiente</a></li>";
        // //ca += "<li style='list-style-type: circle;'><a href='estraunoevidenciasCoor.aspx?m=1&s=0&a=10' >Bienestar Infantil y juvenil</a></li>";
        // //ca += "</ul>"; //Fin Submenu 

        // ca += "</ul>";
        // ca += "</div>";

        // ca += "<h3>Momento pedagógico 3: Acompañamiento para el desarrollo de las etapas, diseño y recorrido de las trayectorias de indagación</h3>";
        // ca += "<div>";
        // ca += "<ul>";
        // //ca += "<li style='list-style-type: square;'><a href='estraunoevidencias.aspx?m=3&s=0' >Cargar Evidencias</a></li>";
        // ca += "<li style='list-style-type: square;'><a href='estrag007Reporte.aspx?e=1&m=3&s=0' >B04: Acompañamiento para el desarrollo de las etapas, diseño y recorrido de las trayectorias de indagación</a></li>";
        // ca += "<li style='list-style-type: square;'><a href='verestraunobitacoracinco.aspx?e=1&m=3&s=0' >B05: Trayectorías de indagación</a></li>";
        // ca += "<li style='list-style-type: square;'><a href='verestras002.aspx?e=1&m=3&s=2&a=6' >S002: Registro de asesoría, acompañamiento y formación</a></li>";
        // ca += "<li style='list-style-type: square;'><a href='procesosistematizacion.aspx?e=1&m=3' >Proceso de Sistematización</a></li>";

        // ca += "<li style='list-style-type: square;'><a href='estraunopreestructuradoscoord.aspx?e=1&m=3'>Preestructurados</a></li>";
        // ca += "<li style='list-style-type: square;'><a href='estraunoentregarecursosgrupos.aspx'>Entrega de recursos a grupos</a></li>";
        // //ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Preestructurados</li>";
        // //ca += "<ul style='margin-left:20px;'>"; //Submenu 
        // //ca += "<li style='list-style-type: circle;'><a href='estraunoevidenciasCoor.aspx?m=1&s=0&a=11' >Medio Ambiente</a></li>";
        // //ca += "<li style='list-style-type: circle;'><a href='estraunoevidenciasCoor.aspx?m=1&s=0&a=12' >Bienestar Infantil y juvenil</a></li>";
        // //ca += "</ul>"; //Fin Submenu 

        // ca += "</ul>";
        // ca += "</div>";

        // ca += "<h3>Momento pedagógico 4: Acompañamiento para la reflexión de ciclón</h3>";
        // ca += "<div>";
        // ca += "<ul>";
        // //ca += "<li style='list-style-type: square;'><a href='estraunoevidencias.aspx?m=4&s=0' >Cargar Evidencias</a></li>";
        // ca += "<li style='list-style-type: square;'><a href='procesosistematizacion.aspx?e=1&m=4' >Proceso de Sistematización</a></li>";

        // ca += "<li style='list-style-type: square;'><a href='estraunopreestructuradoscoord.aspx?e=1&m=4'>Preestructurados</a></li>";
        // ca += "<li style='list-style-type: square;'><a href='estras003_estategia1Reporte.aspx'>S003: Informe de investigación </a></li>";
        // ca += "<li style='list-style-type: square;'><a href='estraunobitacorasietereporte.aspx?e=1&m=4&s=0'>B07: Proyección de la investigación </a></li>";
        // ca += "<li style='list-style-type: square;'><a href='estras002reporte.aspx?e=1&m=4&s=0'>S002: Registro de asesoría, acompañamiento y formación </a></li>";
        // ca += "<li style='list-style-type: square;'><a href='estraunobitacora4punto1evireporte.aspx?d=1' >B4.1 - Informe financiero de ejecución de recursos del primer desembolso</a></li>";
        // ca += "<li style='list-style-type: square;'><a href='estraunobitacora4punto1evireporte.aspx?d=2' >B4.1 - Informe financiero de ejecución de recursos del segundo desembolso</a></li>";
        // ca += "<li style='list-style-type: square;'><a href='estraunobitacora4punto1evireporte.aspx?d=3' >B4.1 - Informe financiero de ejecución de recursos del tercer desembolso</a></li>";
        // //ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'>Preestructurados</li>";
        // //ca += "<ul style='margin-left:20px;'>"; //Submenu 
        // //ca += "<li style='list-style-type: circle;'><a href='estraunoevidenciasCoor.aspx?m=1&s=0&a=13' >Medio Ambiente</a></li>";
        // //ca += "<li style='list-style-type: circle;'><a href='estraunoevidenciasCoor.aspx?m=1&s=0&a=14' >Bienestar Infantil y juvenil</a></li>"; 
        // //ca += "</ul>"; //Fin Submenu 

        // ca += "</ul>";
        // ca += "</div>";

        ca += "<h3>Momento pedagógico 5: Acompañamiento para la propagación de ciclón</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type: square;'><a href='confiespaciodeapropiacion.aspx' > Espacio de apropiación municipal </a></li>";
        ca += "<li style='list-style-type: square;'><a href='confiespaciodeapropiaciondep.aspx' > Espacio de apropiación departamental </a></li>";
        ca += "<li style='list-style-type: square;'><a href='confiespaciodeapropiacionreg.aspx' > Espacio de apropiación regional </a></li>";
        ca += "<li style='list-style-type: square;'><a href='confiespaciodeapropiacionnac.aspx' > Espacio de apropiación nacional </a></li>";
        ca += "<li style='list-style-type: square;'><a href='confiespaciodeapropiacionint.aspx' > Espacio de apropiación internacional </a></li>";
        // ca += "<li style='list-style-type: square;'><a href='procesosistematizacion.aspx?e=1&m=5' >Proceso de Sistematización</a></li>";
        // ca += "<li style='list-style-type: square;text-decoration:underline;font-weight:bold'><a href='estraunopreestructuradoscoord.aspx?e=1&m=5'>Preestructurados</a></li>";
        // ca += "<li style='list-style-type: square;'><a href='estraunos008reporte.aspx?e=1&m=5'>S008: Resumen Artículo de Investigación</a></li>";
        // ca += "<li style='list-style-type: square;'><a href='estraunoparticipantesferiasreporte.aspx'>Maestros participantes en Comité de ferias</a></li>";
        //ca += "<ul style='margin-left:20px;'>"; //Submenu 
        //ca += "<li style='list-style-type: circle;'><a href='estraunoevidenciasCoor.aspx?m=1&s=0&a=15' >Medio Ambiente</a></li>";
        //ca += "<li style='list-style-type: circle;'><a href='estraunoevidenciasCoor.aspx?m=1&s=0&a=16' >Bienestar Infantil y juvenil</a></li>";
        //ca += "</ul>"; //Fin Submenu 

        ca += "</ul>";
        ca += "</div>";


        return ca;
    }

    //sólo puede verlo el usuario maferpi
    private string MenuCoordinadorMaferpi()
    {
        string ca = "";

        ca += "<h3>Momento pedagógico 0: La planeación colectiva</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type: square;'><a href='estraunoevidenciaslineapedago.aspx' >Lineamientos Pedagógicos de los espacios de apropiación</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estraunoevidenciaspropmetodoc.aspx' >Propuesta metadológica o ruta</a></li>";
        ca += "<li style='list-style-type: square;'><a href='estraunoevidenciasplanoperativo.aspx' >Plan Operativo</a></li>";
        ca += "</ul>";
        ca += "</div>";

        ca += "<h3>Momento pedagógico 5: Acompañamiento para la propagación de Ciclón</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type: square;'><a href='confiespaciodeapropiacion.aspx' > Espacio de apropiación municipal </a></li>";
        ca += "<li style='list-style-type: square;'><a href='confiespaciodeapropiaciondep.aspx' > Espacio de apropiación departamental </a></li>";
        ca += "<li style='list-style-type: square;'><a href='confiespaciodeapropiacionreg.aspx' > Espacio de apropiación regional </a></li>";
        ca += "<li style='list-style-type: square;'><a href='confiespaciodeapropiacionnac.aspx' > Espacio de apropiación nacional </a></li>";
        ca += "<li style='list-style-type: square;'><a href='confiespaciodeapropiacionint.aspx' > Espacio de apropiación internacional </a></li>";
        ca += "</ul>";
        ca += "</div>";


        return ca;
    }
    

    public void obtenerGET()
    {
        lblMomento.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        //lblSesion.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);

        Session["g007"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["g007"]);
        Session["g008"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["g008"]);
    }
    public void cerrarSessiones()
    {
        Session["g007"] = null;
        Session["g008"] = null;
    }
    private void validarRegresoMomento0()
    {
        btnCargarEvidencias.Visible = true;
        btnMomento0g008.Visible = true;
    }
    private void validarRegresoMomento1()
    {
        if(Session["codrol"].ToString() == "10")//Coordinador UniMag
        {
            btnMomento1CargarEvidencias.Visible = true;
            btnMomento1g006.Visible = true;
            btnMomento1s002.Visible = false;
        }
        else if (Session["codrol"].ToString() == "11")//Asesor UniMag
        {
            btnMomento1Bitacora1.Visible = true;
            btnMomento1Bitacora2.Visible = true;
            btnMomento1Bitacora3.Visible = true;
            btnMomento1s002.Visible = false;
            btnMomento1s002Sesion4.Visible = true;
            //btnMomento1s007.Visible = true;
        }

    }
    private void validarRegresoMomento2()
    {
        if (Session["codrol"].ToString() == "10")//Coordinador UniMag
        {
            btnCargarEvidenciasMomento2.Visible = true;
        
        }
        else if (Session["codrol"].ToString() == "11")//Asesor UniMag
        {
           
        }

    }
    private void validarRegresoMomento3()
    {
        if (Session["codrol"].ToString() == "10")//Coordinador UniMag
        {
            btnCargarEvidenciasMomento3.Visible = true;

        }
        else if (Session["codrol"].ToString() == "11")//Asesor UniMag
        {
            btnMomento3Bitacora4.Visible = true;
            btnMomento3Bitacora5.Visible = true;
            btnMomento3s002Sesion1.Visible = true;
        }

    }
    private void validarRegresoMomento4()
    {
        if (Session["codrol"].ToString() == "10")//Coordinador UniMag
        {
            btnCargarEvidenciasMomento4.Visible = true;

        }
        else if (Session["codrol"].ToString() == "11")//Asesor UniMag
        {
            btnMomento4s002.Visible = true;
            btnMomento4s003.Visible = true;
        }

    }
    private void validarRegresoMomento5()
    {
        if (Session["codrol"].ToString() == "10")//Coordinador UniMag
        {
            btnInscripcionGruposEvidenciasMomento5.Visible = false;

        }
        else if (Session["codrol"].ToString() == "11")//Asesor UniMag
        {
            btnInscripcionGruposEvidenciasMomento5.Visible = true;
            btnActadeReunionMomento5.Visible = true;

        }

    }
    private void validarRegresog007()
    {
      
            btnCargarEvidencias.Visible = true;
 
            btnMomento0EjecucionFinanciera.Visible = true;
            btnMomento0ProduccionSistematizacion.Visible = true;

            //btnMomento1Bitacora1.Visible = true;
            //btnMomento1Bitacora2.Visible = true;
            //btnMomento1Bitacora3.Visible = true;

    }
    private void validarRegresoBitacoras()
    {
       
            btnMomento1Etapa123.Visible = true;
            btnMomento1EvaluacionAsesoria.Visible = true;
            btnMomento1Eventos.Visible = true;
            btnMomento1RegistroVisita.Visible = true;

            //btnMomento1Bitacora1.Visible = true;
            //btnMomento1Bitacora2.Visible = true;
            //btnMomento1Bitacora3.Visible = true;
   }

    private void validarRegresoEvalAsesoria()
    {
    
        btnMomento1Etapa123.Visible = true;
        btnMomento1EvaluacionAsesoria.Visible = true;
        btnMomento1Eventos.Visible = true;
        btnMomento1RegistroVisita.Visible = true;

        //btnMomento1Bitacora1.Visible = false;
        //btnMomento1Bitacora2.Visible = false;
        //btnMomento1Bitacora3.Visible = false;
    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }

    //Momentos

    protected void btnMomento0_Click(object sender, EventArgs e)
    {

        if (Session["codrol"] != null)
        {
         //Validar los botones de los momentos a mostrar, este es para los coordinadores UniMag Momento 0 y usuario Supervisión
            if (Session["codrol"].ToString() == "10" || Session["codrol"].ToString() == "9")
            {
                btnCargarEvidencias.Visible = true;
                btnMomento0g008.Visible = true;
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
   


       
        //btnMomento0Presupuesto.Visible = true;

        //DataRow dato = est.buscarCodEstrategiaxCoordinador(Session["identificacion"].ToString());

        //if (dato != null)
        //{
        //    btnMomento0EjecucionFinanciera.Visible = true;
        //}
 

        //btnMomento0ProduccionSistematizacion.Visible = true;




        //btnMomento1Etapa123.Visible = false;
        //btnMomento1EvaluacionAsesoria.Visible = false;
        //btnMomento1Eventos.Visible = false;
        //btnMomento1RegistroVisita.Visible = false;

        //btnMomento1Bitacora1.Visible = false;
        //btnMomento1Bitacora2.Visible = false;
        //btnMomento1Bitacora3.Visible = false;
        //btnMomento1Bitacora3_1.Visible = false;

    }


    //Coordinadores UniMag 

    protected void btnMomento0g008_Click(object sender, EventArgs e)
    {
        Response.Redirect("estraunoevidenciasplanoperativo.aspx");
    }








    protected void btnCargarEvidencias_Click(object sender, EventArgs e)
    {

        if (Session["codrol"].ToString() == "9")//10 = Supervisor Unimagdalena
        {
            Response.Redirect("listestraunoevidenciassupervisor.aspx?m=0&s=0");
        }
        else if (Session["codrol"].ToString() == "10")// 11 = Coordinador UniMagdalena
        {
            Response.Redirect("listestraunoevidencias.aspx?m=0&s=0");
        }

        //Response.Redirect("estraunoevidencias.aspx?m=0&s=0");

        Response.Redirect("listestraunoevidencias.aspx?m=0&s=0");
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
            if (Session["codrol"].ToString() == "10" || Session["codrol"].ToString() == "9")//10 = Coordinador Unimagdalena
                {
                    btnMomento1g006.Visible = true;
                    btnMomento1s002.Visible = true;
                    btnMomento1CargarEvidencias.Visible = true;
                    btnVerGruposInvestigacion.Visible = true;
                    btnMomento1Bitacora1.Visible = true;
                    btnMomento1Bitacora2.Visible = true;
                    btnMomento1Bitacora3.Visible = true;
                    //btnMomento1s002Sesion4.Visible = true;
                    //btnMomento1s007.Visible = true;
            
                }
                else if (Session["codrol"].ToString() == "11" )// 11 = Asesor UniMagdalena
                {
                    //btnMomento1g006.Visible = true;
                    btnMomento1s002.Visible = false;
                    btnMomento1Bitacora1.Visible = true;
                    btnMomento1Bitacora2.Visible = true;
                    btnMomento1Bitacora3.Visible = true;
                    btnMomento1s002Sesion4.Visible = true;
                    btnConformacionGrupos.Visible = true;
                    //btnMomento1s007.Visible = true;

                    btnCargarEvidenciasMomento3.Visible = false;
                    btnMomento3Bitacora4.Visible = false;
                    btnMomento3Bitacora5.Visible = false;
                    btnMomento3s002Sesion1.Visible = false;
                    btnMomento3s007.Visible = false;

                    btnMomento4s002.Visible = false;
                    //btnMomento4s007.Visible = true;
                    btnMomento4s003.Visible = false;

                    btnInscripcionGruposEvidenciasMomento5.Visible = false;
                    btnActadeReunionMomento5.Visible = false;
                    btnMomento1Preestructurados.Visible = true;

                }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }

        
        
    }
    protected void btnVerGruposInvestigacion_Click(object sender, EventArgs e)
    {
        Response.Redirect("verGruposInvestigacion.aspx");
    }
    protected void btnMomento1Preestructurados_Click(object sender, EventArgs e)
    {
        btnMomento1s002.Visible = false;
        btnMomento1Bitacora1.Visible = false;
        btnMomento1Bitacora2.Visible = false;
        btnMomento1Bitacora3.Visible = false;
        btnMomento1s002Sesion4.Visible = false;
        btnConformacionGrupos.Visible = false;
        //btnMomento1s007.Visible = true;

        btnCargarEvidenciasMomento3.Visible = false;
        btnMomento3Bitacora4.Visible = false;
        btnMomento3Bitacora5.Visible = false;
        btnMomento3s002Sesion1.Visible = false;
        btnMomento3s007.Visible = false;

        btnMomento4s002.Visible = false;
        //btnMomento4s007.Visible = true;
        btnMomento4s003.Visible = false;

        btnInscripcionGruposEvidenciasMomento5.Visible = false;
        btnActadeReunionMomento5.Visible = false;

        btnMomento1Preestructurados.Visible = true;
        btnMomento1PreestructuradosMedioAmbiente.Visible = true;
        btnMomento1PreestructuradosBienestar.Visible = true;

        btnMomento3Preestructurados.Visible = false;
        btnMomento3PreestructuradosMedioAmbiente.Visible = false;
        btnMomento3PreestructuradosBienestar.Visible = false;

        btnMomento4Preestructurados.Visible = false;
        btnMomento4PreestructuradosMedioAmbiente.Visible = false;
        btnMomento4PreestructuradosBienestar.Visible = false;

        btnMomento5Preestructurados.Visible = false;
        btnMomento5PreestructuradosMedioAmbiente.Visible = false;
        btnMomento5PreestructuradosBienestar.Visible = false;


    }
    protected void btnVerMomento1Bitacora1_Click(object sender, EventArgs e)
    {
       
    }
    protected void btnMomento1PreestructuradosMedioAmbiente_Click(object sender, EventArgs e)
    {
        Response.Redirect("estraunoevidencias.aspx?m=1&s=0&a=7");
    }
    protected void btnMomento1PreestructuradosBienestar_Click(object sender, EventArgs e)
    {
        Response.Redirect("estraunoevidencias.aspx?m=1&s=0&a=8");
    }
    protected void btnConformacionGrupos_Click(object sender, EventArgs e)
    {
        if(Session["codrol"].ToString() == "9")//Rol Supervisión: sirve para gerencia
        {
            Response.Redirect("verGruposInvestigacion.aspx");
        }
        else
        {
            Response.Redirect("configrupoinvestigacion.aspx");
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
        if (Session["codrol"].ToString() == "10" || Session["codrol"].ToString() == "9")//Rol Supervisión: sirve para gerencia
        {
            Response.Redirect("verestras002.aspx?e=1&m=1&s=4");//aquí
        }
        //else
        //{
        //    if (Session["codrol"].ToString() == "11")
        //        Response.Redirect("estras002.aspx?e=1&m=1&s=0&a=7");
        //}


        
    }
    protected void btnMomento1Bitacora1_Click(object sender, EventArgs e)
    {
        if (Session["codrol"].ToString() == "9" || Session["codrol"].ToString() == "10")//Rol Supervisión: sirve para gerencia y Coord unimag
        {
            Response.Redirect("verEstraUnoBitacoraUno.aspx");
        }
        else
        {
            Response.Redirect("estraunobitacorauno.aspx?e=1&m=1&s=1");
        }
       
    }
    protected void btnMomento1Bitacora2_Click(object sender, EventArgs e)
    {
        if (Session["codrol"].ToString() == "9" || Session["codrol"].ToString() == "10")//Rol Supervisión: sirve para gerencia
        {
            Response.Redirect("verestraunobitacorados.aspx");
        }
        else
        {
            Response.Redirect("estraunobitacorados.aspx?e=1&m=1&s=2");
        }
       
    }
    protected void btnMomento1Bitacora3_Click(object sender, EventArgs e)
    {
        if (Session["codrol"].ToString() == "9" || Session["codrol"].ToString() == "10")//Rol Supervisión: sirve para gerencia
        {
            Response.Redirect("verestraunobitacoratres.aspx");
        }
        else
        {
            Response.Redirect("estraunobitacoratres.aspx?e=1&m=1&s=3");
        }
        
    }
    protected void btnMomento1s002Sesion4_Click(object sender, EventArgs e)
    {
        if (Session["codrol"].ToString() == "9" || Session["codrol"].ToString() == "10")//Rol Supervisión: sirve para gerencia
        {
            Response.Redirect("verestras002.aspx?e=1&m=1&s=4");
        }
        else
        {
            if (Session["codrol"].ToString() == "11")
            {
                Response.Redirect("estras002.aspx?e=1&m=1&s=4&a=10");
            }
           
        }
        
    }
    protected void btnMomento1s007_Click(object sender, EventArgs e)
    {
        Response.Redirect("estras007.aspx?e=1&m=1&s=5");
    }
    protected void btnMomento1Etapa123_Click(object sender, EventArgs e)
    {
      
        btnMomento1Etapa123.Visible = true;
        btnMomento1EvaluacionAsesoria.Visible = true;
        btnMomento1Eventos.Visible = true;
        btnMomento1RegistroVisita.Visible = true;

        //btnMomento1Bitacora1.Visible = true;
        //btnMomento1Bitacora2.Visible = true;
        //btnMomento1Bitacora3.Visible = true;
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
            if (Session["codrol"].ToString() == "10" || Session["codrol"].ToString() == "9")//10 = Coordinador Unimagdalena
                {
                    btnCargarEvidenciasMomento2.Visible = true;
         
                }
                else if (Session["codrol"].ToString() == "11" )//11 = Asesor Unimagdalena
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
            if (Session["codrol"].ToString() == "10" || Session["codrol"].ToString() == "9")//Coordinador UniMag
                {
                    btnMomento3Bitacora4.Visible = true;
                    btnMomento3Bitacora5.Visible = true;
                    btnMomento3s002Sesion1.Visible = true;
                    btnCargarEvidenciasMomento3.Visible = true;

                }
         else if (Session["codrol"].ToString() == "11" )//Asesor UniMag
                {
                    btnMomento1Bitacora1.Visible = false;
                    btnMomento1Bitacora2.Visible = false;
                    btnMomento1Bitacora3.Visible = false;
                    btnMomento1s002Sesion4.Visible = false;
                    btnConformacionGrupos.Visible = false;
                    //btnMomento1s007.Visible = true;

                    btnCargarEvidenciasMomento3.Visible = false;
                    btnMomento3Bitacora4.Visible = true;
                    btnMomento3Bitacora5.Visible = true;
                    btnMomento3s002Sesion1.Visible = true;
                    btnMomento3s007.Visible = true;

                    btnMomento3Bitacora4.Visible = true;
                    btnMomento3Bitacora5.Visible = true;
                    btnMomento3s002Sesion1.Visible = true;
                    //btnMomento3s007.Visible = true;

                    btnMomento4s002.Visible = false;
                    //btnMomento4s007.Visible = true;
                    btnMomento4s003.Visible = false;

                    btnInscripcionGruposEvidenciasMomento5.Visible = false;
                    btnActadeReunionMomento5.Visible = false;

                    btnMomento1Preestructurados.Visible = false;
                    btnMomento1PreestructuradosMedioAmbiente.Visible = false;
                    btnMomento1PreestructuradosBienestar.Visible = false;

                    btnMomento3Preestructurados.Visible = true;
                    btnMomento4Preestructurados.Visible = false;
                    btnMomento5Preestructurados.Visible = false;
         
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
        if (Session["codrol"] != null)
        {
            if (Session["codrol"].ToString() == "10" || Session["codrol"].ToString() == "9")//Coordinador, supervisión UniMag
            {
                btnMomento3Bitacora4.Visible = true;
                btnMomento3Bitacora5.Visible = true;
                btnMomento3s002Sesion1.Visible = true;
                btnCargarEvidenciasMomento3.Visible = true;
                Response.Redirect("verestraunobitacoracuatro.aspx");

            }
            else if (Session["codrol"].ToString() == "11" )//Asesor UniMag
            {
                Response.Redirect("estrag007.aspx?e=1&m=3&s=0");
            }
        }
       
    }
    protected void btnMomento3Bitacora5_Click(object sender, EventArgs e)
    {
        if (Session["codrol"] != null)
        {
            if (Session["codrol"].ToString() == "10" || Session["codrol"].ToString() == "9")//Coordinador, supervisión UniMag
            {
                btnMomento3Bitacora4.Visible = true;
                btnMomento3Bitacora5.Visible = true;
                btnMomento3s002Sesion1.Visible = true;
                btnCargarEvidenciasMomento3.Visible = true;

            }
            else if (Session["codrol"].ToString() == "11")//Asesor UniMag
            {
                Response.Redirect("estraunobitacoracinco.aspx?e=1&m=3&s=0");
            }
        }
        
    }
    protected void btnMomento3s002Sesion1_Click(object sender, EventArgs e)
    {
        if (Session["codrol"].ToString() == "9" || Session["codrol"].ToString() == "10")//Rol Supervisión: sirve para gerencia
        {
            Response.Redirect("verestras002.aspx?e=1&m=3&s=2&a=6");
        }
        else
        {
            if (Session["codrol"].ToString() == "11")
                Response.Redirect("estras002.aspx?e=1&m=3&s=2&a=6");
        }
        
    }
    protected void btnMomento3s007_Click(object sender, EventArgs e)
    {
        //Response.Redirect("estras007.aspx?e=1&m=3&s=2");
        Response.Redirect("estraunoevidenciass007.aspx?e=1&m=3&s=0");
    }
    //Momento 4
    protected void btnMomento4_Click(object sender, EventArgs e)
    {

        if (Session["codrol"].ToString() == "10")//10 = Coordinador Unimagdalena
        {
            btnCargarEvidenciasMomento4.Visible = true;
            //btnMomento4s002.Visible = true;
            //btnMomento4s007.Visible = true;

        }
        else if (Session["codrol"].ToString() == "11" || Session["codrol"].ToString() == "9")//11 = Asesor Unimagdalena y Supervisión
        {
            //btnCargarEvidenciasMomento4.Visible = true;
            btnMomento4s002.Visible = true;
            //btnMomento4s007.Visible = true;
            btnMomento4s003.Visible = true;
            btnConformacionGrupos.Visible = false;

            btnMomento1Bitacora1.Visible = false;
            btnMomento1Bitacora2.Visible = false;
            btnMomento1Bitacora3.Visible = false;
            btnMomento1s002Sesion4.Visible = false;
            //btnMomento1s007.Visible = true;

            btnCargarEvidenciasMomento3.Visible = false;
            btnMomento3Bitacora4.Visible = false;
            btnMomento3Bitacora5.Visible = false;
            btnMomento3s002Sesion1.Visible = false;
            btnMomento3s007.Visible = false;

            btnMomento3Bitacora4.Visible = false;
            btnMomento3Bitacora5.Visible = false;
            btnMomento3s002Sesion1.Visible = false;

            btnInscripcionGruposEvidenciasMomento5.Visible = false;
            btnActadeReunionMomento5.Visible = false;

            btnMomento1Preestructurados.Visible = false;
            btnMomento1PreestructuradosMedioAmbiente.Visible = false;
            btnMomento1PreestructuradosBienestar.Visible = false;

            btnMomento3Preestructurados.Visible = false;
            btnMomento4Preestructurados.Visible = true;
            btnMomento5Preestructurados.Visible = false;

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
        Response.Redirect("estras003.aspx?e=1&m=4&s=0");
    }

    //Momento 5
    protected void btnMomento5_Click(object sender, EventArgs e)
    {
        if (Session["codrol"] != null)
        {
            if (Session["codrol"].ToString() == "10")//Coordinador UniMag
            {
                //btnMomento3Bitacora4.Visible = true;
                //btnMomento3Bitacora5.Visible = true;
                //btnMomento3s002Sesion1.Visible = true;
                btnCargarEvidenciasMomento3.Visible = false;

            }
            else if (Session["codrol"].ToString() == "11" || Session["codrol"].ToString() == "9") //Asesor UniMag
            {
                btnInscripcionGruposEvidenciasMomento5.Visible = true;
                btnActadeReunionMomento5.Visible = true;

                //btnCargarEvidenciasMomento4.Visible = true;
                btnMomento4s002.Visible = false;
                //btnMomento4s007.Visible = true;
                btnMomento4s003.Visible = false;
                btnConformacionGrupos.Visible = false;

                btnMomento1Bitacora1.Visible = false;
                btnMomento1Bitacora2.Visible = false;
                btnMomento1Bitacora3.Visible = false;
                btnMomento1s002Sesion4.Visible = false;
                //btnMomento1s007.Visible = true;

                btnCargarEvidenciasMomento3.Visible = false;
                btnMomento3Bitacora4.Visible = false;
                btnMomento3Bitacora5.Visible = false;
                btnMomento3s002Sesion1.Visible = false;
                btnMomento3s007.Visible = false;

                btnMomento3Bitacora4.Visible = false;
                btnMomento3Bitacora5.Visible = false;
                btnMomento3s002Sesion1.Visible = false;

                btnMomento1Preestructurados.Visible = false;
                btnMomento1PreestructuradosMedioAmbiente.Visible = false;
                btnMomento1PreestructuradosBienestar.Visible = false;

                btnMomento3Preestructurados.Visible = false;
                btnMomento4Preestructurados.Visible = false;
                btnMomento5Preestructurados.Visible = true;
            }
            else if (Session["codrol"].ToString() == "17" || Session["codrol"].ToString() == "9") //Coordinador MAFERPI
            {
                btnCargarEvidenciasMomento5.Visible = true;
                
            }
        }
        else
        {
            Response.Redirect("Default.aspx");
        }

    }
    protected void btnCargarEvidenciasMomento5_Click(object sender, EventArgs e)
    {
       Response.Redirect("estraunoevidencias.aspx?e=1&m=5&s=0");
    }
    protected void btnInscripcionGruposEvidenciasMomento5_Click(object sender, EventArgs e)
    {
        Response.Redirect("estraunoevidenciasferias.aspx");
    }
    protected void btnActadeReunionMomento5_Click(object sender, EventArgs e)
    {
        Response.Redirect("estraunoevidencias.aspx?m=5");
    }


    protected void btnMomento3Preestructurados_Click(object sender, EventArgs e)
    {
        btnMomento1s002.Visible = false;
        btnMomento1Bitacora1.Visible = false;
        btnMomento1Bitacora2.Visible = false;
        btnMomento1Bitacora3.Visible = false;
        btnMomento1s002Sesion4.Visible = false;
        btnConformacionGrupos.Visible = false;
        //btnMomento1s007.Visible = true;

        btnCargarEvidenciasMomento3.Visible = false;
        btnMomento3Bitacora4.Visible = false;
        btnMomento3Bitacora5.Visible = false;
        btnMomento3s002Sesion1.Visible = false;
        btnMomento3s007.Visible = false;

        btnMomento4s002.Visible = false;
        //btnMomento4s007.Visible = true;
        btnMomento4s003.Visible = false;

        btnInscripcionGruposEvidenciasMomento5.Visible = false;
        btnActadeReunionMomento5.Visible = false;

        btnMomento1Preestructurados.Visible = false;
        btnMomento1PreestructuradosMedioAmbiente.Visible = false;
        btnMomento1PreestructuradosBienestar.Visible = false;

        btnMomento3Preestructurados.Visible = true;
        btnMomento3PreestructuradosMedioAmbiente.Visible = true;
        btnMomento3PreestructuradosBienestar.Visible = true;

        btnMomento4Preestructurados.Visible = false;
        btnMomento4PreestructuradosMedioAmbiente.Visible = false;
        btnMomento4PreestructuradosBienestar.Visible = false;

        btnMomento5Preestructurados.Visible = false;
        btnMomento5PreestructuradosMedioAmbiente.Visible = false;
        btnMomento5PreestructuradosBienestar.Visible = false;


    }

    protected void btnMomento3PreestructuradosMedioAmbiente_Click(object sender, EventArgs e)
    {
        Response.Redirect("estraunoevidencias.aspx?m=3&s=0&a=9");
    }
    protected void btnMomento3PreestructuradosBienestar_Click(object sender, EventArgs e)
    {
        Response.Redirect("estraunoevidencias.aspx?m=3&s=0&a=10");
    }

    protected void btnMomento4Preestructurados_Click(object sender, EventArgs e)
    {
        btnMomento1s002.Visible = false;
        btnMomento1Bitacora1.Visible = false;
        btnMomento1Bitacora2.Visible = false;
        btnMomento1Bitacora3.Visible = false;
        btnMomento1s002Sesion4.Visible = false;
        btnConformacionGrupos.Visible = false;
        //btnMomento1s007.Visible = true;

        btnCargarEvidenciasMomento3.Visible = false;
        btnMomento3Bitacora4.Visible = false;
        btnMomento3Bitacora5.Visible = false;
        btnMomento3s002Sesion1.Visible = false;
        btnMomento3s007.Visible = false;

        btnMomento4s002.Visible = false;
        //btnMomento4s007.Visible = true;
        btnMomento4s003.Visible = false;

        btnInscripcionGruposEvidenciasMomento5.Visible = false;
        btnActadeReunionMomento5.Visible = false;

        btnMomento1Preestructurados.Visible = false;
        btnMomento1PreestructuradosMedioAmbiente.Visible = false;
        btnMomento1PreestructuradosBienestar.Visible = false;

        btnMomento3Preestructurados.Visible = false;
        btnMomento3PreestructuradosMedioAmbiente.Visible = false;
        btnMomento3PreestructuradosBienestar.Visible = false;

        btnMomento4Preestructurados.Visible = true;
        btnMomento4PreestructuradosMedioAmbiente.Visible = true;
        btnMomento4PreestructuradosBienestar.Visible = true;

        btnMomento5Preestructurados.Visible = false;
        btnMomento5PreestructuradosMedioAmbiente.Visible = false;
        btnMomento5PreestructuradosBienestar.Visible = false;


    }

    protected void btnMomento4PreestructuradosMedioAmbiente_Click(object sender, EventArgs e)
    {
        Response.Redirect("estraunoevidencias.aspx?m=4&s=0&a=11");
    }
    protected void btnMomento4PreestructuradosBienestar_Click(object sender, EventArgs e)
    {
        Response.Redirect("estraunoevidencias.aspx?m=4&s=0&a=12");
    }

    protected void btnMomento5Preestructurados_Click(object sender, EventArgs e)
    {
        btnMomento1s002.Visible = false;
        btnMomento1Bitacora1.Visible = false;
        btnMomento1Bitacora2.Visible = false;
        btnMomento1Bitacora3.Visible = false;
        btnMomento1s002Sesion4.Visible = false;
        btnConformacionGrupos.Visible = false;
        //btnMomento1s007.Visible = true;

        btnCargarEvidenciasMomento3.Visible = false;
        btnMomento3Bitacora4.Visible = false;
        btnMomento3Bitacora5.Visible = false;
        btnMomento3s002Sesion1.Visible = false;
        btnMomento3s007.Visible = false;

        btnMomento4s002.Visible = false;
        //btnMomento4s007.Visible = true;
        btnMomento4s003.Visible = false;

        btnInscripcionGruposEvidenciasMomento5.Visible = false;
        btnActadeReunionMomento5.Visible = false;

        btnMomento1Preestructurados.Visible = false;
        btnMomento1PreestructuradosMedioAmbiente.Visible = false;
        btnMomento1PreestructuradosBienestar.Visible = false;

        btnMomento3Preestructurados.Visible = false;
        btnMomento3PreestructuradosMedioAmbiente.Visible = false;
        btnMomento3PreestructuradosBienestar.Visible = false;

        btnMomento4Preestructurados.Visible = false;
        btnMomento4PreestructuradosMedioAmbiente.Visible = false;
        btnMomento4PreestructuradosBienestar.Visible = false;

        btnMomento5Preestructurados.Visible = true;
        btnMomento5PreestructuradosMedioAmbiente.Visible = true;
        btnMomento5PreestructuradosBienestar.Visible = true;


    }

    protected void btnMomento5PreestructuradosMedioAmbiente_Click(object sender, EventArgs e)
    {
        Response.Redirect("estraunoevidencias.aspx?m=5&s=0&a=13");
    }
    protected void btnMomento5PreestructuradosBienestar_Click(object sender, EventArgs e)
    {
        Response.Redirect("estraunoevidencias.aspx?m=5&s=0&a=14");
    }


}