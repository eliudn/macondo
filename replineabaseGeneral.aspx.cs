using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using ClosedXML.Excel;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Web.Services;

public partial class replineabaseGeneral : System.Web.UI.Page
{

    LineaBase lb = new LineaBase();
    Institucion inst = new Institucion();
    Docentes doc = new Docentes();

    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["codperfil"] != null)
        {

        }
        else
            Response.Redirect("Default.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 
        if (!IsPostBack)
        {
            if (Session["codrol"].ToString() == "9" || Session["codrol"].ToString() == "1" || Session["codrol"].ToString() == "18"|| Session["codrol"].ToString() == "20")
            {
                accordion.InnerHtml = MenuAcordeonVisores();
            }          
        }
    }

    private string MenuAcordeonVisores()
    {
        string ca = "";

        ca += "<h3>Currículo</h3>";
        ca += "<div>";
        ca += "<ul>";

        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarSedesxUbicacion()'>Total de Sedes por Ubicación</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='sedesxmunicipio()'>Sedes por Municipio</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarCurriculo()'>Énfasis Currículo</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarModeloEducativo()'>Modelo Educativo</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarPEIProcesoInstitucionalEstudiantes()'>Diagnostico uso TIC</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarPEIInvestigacion()'>PEI promueve la Investigación</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarPEIUsoTIC()'>PEI promueve el uso de las TIC</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarUsoTICCurriculo()'>Currículo con apropiación en TIC</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarCompetenciasApropiacionTICPropuestaMen'>Currículo con competencias en TIC</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarDocentesUltimoNivelEducativoAprobado()'>Total de personal docente según último nivel educativo aprobado</a></li>";

        ca += "</ul>";
        ca += "</div>";//Fin Planeación

        ca += "<h3>Equipamiento</h3>";
        ca += "<div>";
        ca += "<ul>";

        ca += "<li style='list-style-type: square;'><a href='#' onclick='cargarSedesxMuicipioEquipamiento()'>Sedes por Municipio</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarEquiposInformaticosXSedes()'>Equipos Informáticos por Sedes</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarSedesxEquiposInformaticodesagregadoGrado()'>Equipos Informáticos desagregados por grados</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarSedesxEquiposInformaticoFueraEscuela()'>Acceso en equipamiento en TICs fuera del horario escolar</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarSedesxSoftwareEducativo()'>IE con Software Educativo</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarSedesxHerramientaWeb()'>IE con herramientas WEB</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarSedesxFormacionDocenteUsoTIC()'>IE con procesos de formación docentes en uso TIC</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarSedesxPlanMejoramientoTIC()'>IE con planes de mejoramiento TIC</a></li>";


        ca += "</ul>";
        ca += "</div>";

        ca += "<h3>Autopercepción Docente</h3>";
        ca += "<div>";
        ca += "<ul>";

        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarSedesxMunicipioAutopercepcion()'>Sedes por Municipio</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarFormulariosxMunicipioAutopercepcion()'>Formularios por Municipio</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo1()'>Pregunta No 1: Identifico las características, usos y oportunidades que ofrecen herramientas tecnológicas y medios audiovisuales, en los procesos educativos</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo2()'>Pregunta No 2: Elaboro actividades de aprendizaje utilizando aplicativos, contenidos, herramientas informáticas y medios audiovisuales</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo3()'>Pregunta No 3: Evalúo la calidad, pertinencia y veracidad de la información disponible en diversos medios como portales educativos y especializados, motores de búsqueda y material</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo4()'>Pregunta No 4: Combino una amplia variedad de herramientas tecnológicas para mejorar la planeación e implementación de mis prácticas educativas</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo5()'>Pregunta No 5: Diseño y publico contenidos digitales u objetos virtuales de aprendizaje mediante el uso adecuado de herramientas tecnológicas</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo6()'>Pregunta No 6: Analizo los riesgos y potencialidades de publicar y compartir distintos tipos de información a través de Internet</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo7()'>Pregunta No 7: Utilizo herramientas tecnológicas complejas o especializadas para diseñar ambientes virtuales de aprendizaje que favorecen el desarrollo de competencias en mis estudiantes y la conformación de comunidades y/o redes de aprendizaje</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo8()'>Pregunta No 8: Utilizo herramientas tecnológicas para ayudar a mis estudiantes a construir aprendizajes significativos y desarrollar pensamiento crítico</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo9()'>Pregunta No 9: Aplico las normas de propiedad intelectual y licenciamiento existentes, referentes al uso de información ajena y propia</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo10()'>Pregunta No 10: Utilizo las TIC para aprender por iniciativa personal y para actualizar los conocimientos y prácticas propios de mi disciplina</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo11()'>Pregunta No 11: Identifico problemáticas educativas en mi práctica docente y las oportunidades, implicaciones y riesgos del uso de las TIC para atenderlas</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo12()'>Pregunta No 12: Conozco una variedad de estrategias y metodologías apoyadas por las TIC, para planear y hacer seguimiento a mi labor docente</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo13()'>Pregunta No 13: Incentivo en mis estudiantes el aprendizaje autónomo y el aprendizaje colaborativo apoyados por TIC</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo14()'>Pregunta No 14: Utilizo TIC con mis estudiantes para atender sus necesidades e intereses y proponer soluciones a problemas de aprendizaje</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo15()'>Pregunta No 15: Implemento estrategias didácticas mediadas por TIC, para fortalecer en mis estudiantes aprendizajes que les permitan resolver problemas de la vida real</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo16()'>Pregunta No 16: Diseño ambientes de aprendizaje mediados por TIC de acuerdo con el desarrollo cognitivo, físico, psicológico y social de mis estudiantes para fomentar el desarrollo de sus competencias</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo17()'>Pregunta No 17: Propongo proyectos educativos mediados con TIC, que permiten la reflexión sobre el aprendizaje propio y la producción de conocimiento</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo18()'>Pregunta No 18: Evalúo los resultados obtenidos con la implementación de estrategias que hacen uso educativo de TIC y promuevo una cultura de seguimiento, retroalimentación y mejoramiento permanente</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo19()'>Pregunta No 19: Me comunico adecuadamente con mis estudiantes y sus familiares, mis colegas e investigadores usando TIC de manera sincrónica y asincrónica</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo20()'>Pregunta No 20: Navego eficientemente en Internet integrando fragmentos de información presentados de forma no lineal</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo21()'>Pregunta No 21: Evalúo la pertinencia de compartir información a través de canales públicos y masivos, respetando las normas de propiedad intelectual y licenciamiento</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo22()'>Pregunta No 22: Participo activamente en redes y comunidades de práctica mediadas por TIC y facilito la participación de mis estudiantes en las mismas, de una forma pertinente y respetuosa</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo23()'>Pregunta No 23: Sistematizo y hago seguimiento a experiencias significativas de uso de TIC</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo24()'>Pregunta No 24: Promuevo en la comunidad educativa comunicaciones efectivas que aportan al mejoramiento de los procesos de convivencia escolar</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo25()'>Pregunta No 25: Utilizo variedad de textos e interfaces para transmitir información y expresar ideas propias combinando texto, audio, imágenes estáticas o dinámicas, videos y gestos</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo26()'>Pregunta No 26: Interpreto y produzco íconos, símbolos y otras formas de representación de la información, para ser utilizados con propósitos educativos</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo27()'>Pregunta No 27: Contribuyo con mis conocimientos y los de mis estudiantes a repositorios de la humanidad de Internet, con textos de diversa naturaleza</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo28()'>Pregunta No 28: Identifico los elementos de la gestión escolar que pueden ser mejorados con el uso de las TIC, en las diferentes actividades institucionales</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo29()'>Pregunta No 29: Conozco políticas escolares para el uso de las TIC que contemplan la privacidad, el impacto ambiental y la salud de los usuarios</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo30()'>Pregunta No 30: Identifico mis necesidades de desarrollo profesional para la innovación educativa con TIC</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo31()'>Pregunta No 31: Propongo y desarrollo procesos de mejoramiento y seguimiento del uso de TIC en la gestión escolar</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo32()'>Pregunta No 32: Adopto políticas escolares existentes para el uso de las TIC en mi institución que contemplan la privacidad, el impacto ambiental y la salud de los usuarios</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo33()'>Pregunta No 32: Adopto políticas escolares existentes para el uso de las TIC en mi institución que contemplan la privacidad, el impacto ambiental y la salud de los usuarios</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo34()'>Pregunta No 34: Selecciono y accedo a programas de formación, apropiados para mis necesidades de desarrollo profesional, para la innovación educativa con TIC</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo35()'>Pregunta No 35: Evalúo los beneficios y utilidades de herramientas TIC en la gestión escolar y en la proyección del PEI dando respuesta a las necesidades de mi institución</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo36()'>Pregunta No 36: Desarrollo políticas escolares para el uso de las TIC en mi institución que contemplan la privacidad, el impacto ambiental y la salud de los usuarios</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo37()'>Pregunta No 37: Dinamizo la formación de mis colegas y los apoyo para que integren las TIC de forma innovadora en sus prácticas pedagógicas</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo38()'>Pregunta No 38: Documento observaciones de mi entorno y mi practica con el apoyo de TIC</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo39()'>Pregunta No 39: Identifico redes, bases de datos y fuentes de información que facilitan mis procesos de investigación</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo40()'>Pregunta No 40: Sé buscar, ordenar, filtrar, conectar y analizar información disponible en Internet</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo41()'>Pregunta No 41: Represento e interpreto datos e información de mis investigaciones en diversos formatos digitales</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo42()'>Pregunta No 42: Utilizo redes profesionales y plataformas especializadas en el desarrollo de mis investigaciones</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo43()'>Pregunta No 43: Contrasto y analizo con mis estudiantes información proveniente de múltiples fuentes digitales</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo44()'>Pregunta No 44: Divulgo los resultados de mis investigaciones utilizando las herramientas que me ofrecen las TIC</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo45()'>Pregunta No 45: Participo activamente en redes y comunidades de práctica, para la construcción colectiva de conocimientos con estudiantes y colegas, con el apoyo de TIC</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo46()'>Pregunta No 46: Utilizo la información disponible en Internet con una actitud crítica y reflexiva</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo47()'>Pregunta No 47: Comprendo las posibilidades de las TIC para potenciar procesos de participación democrática</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo48()'>Pregunta No 48:  Identifico los riesgos de publicar y compartir distintos tipos de información a través de Internet</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo49()'>Pregunta No 49: Utilizo las TIC teniendo en cuenta recomendaciones básicas de salud</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo50()'>Pregunta No 50: Examino y aplico las normas de propiedad intelectual y licenciamiento existentes, referentes al uso de información ajena y propia</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarAutoPercepcionDocentePreguntaNo51()'>Pregunta No 51: Me comunico de manera respetuosa con los demás</a></li>";

        ca += "</ul>";
        ca += "</div>";

        ca += "<h3>Perfil docente</h3>";
        ca += "<div>";
        ca += "<ul>";

        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarFormulariosxMunicipio()' >Formularios diligenciados por municipio</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarFormulariosDiligenciadosxSedes()' >Formularios diligenciados por sede</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarFormulariosxRespondiente()' >Formularios diligenciados por respondiente</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarNivelObtenidoDocente()' >Nivel de formación obtenido</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarFormularioDiligenciadoxNivelEducativo()' >Formularios diligenciados por nivel de trabajo educativo</a></li>";
        ca += "<li style='list-style-type: square;'><b>Formularios diligenciados por desarrollo de docencia</b></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarFomularioDiligenciadoxDocenciaCaracterAcademico()' >Carácter académico</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarFomularioDiligenciadoxDocenciaCaracterTecnicoAgropecuario()' >Carácter técnico agropecuario</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarFomularioDiligenciadoxDocenciaCaracterTecnicoComercial()' >Carácter tecnico comercial</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarFomularioDiligenciadoxDocenciaCaracterTecnicoIndustrial()' >Carácter tecnico industrial</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarFormacionEspecificaPracticasPedagogicas()' >Cursos de formación especifica en sus practicas pedagogicas</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='ParticipoProyectosInvestifacionDinstitucion()' >Participo en grupos de investigación dentro INS</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarModalidadProyectoDinstitucion()' >Modalidad de proyecto dentro INS</a></li>";

        ca += "</ul>";
        ca += "</div>";


        ca += "<h3>Perfil Estudiante</h3>";
        ca += "<div>";
        ca += "<ul>";

        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='totalEstudiantesMujeres()'>Estudiantes Mujeres</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='EstudiantesconDiscapacidad()'>Estudiantes con discapacidad o capacidad excepcional</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarEstudiantexGrupoEtnico()'>Estudiantes pertenecientes a un grupo etnico</a></li>";
        ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='cargarEstudianteVictimaConflicto()'>Estudiantes victimas del conflicto</a></li>";

        ca += "</ul>";
        ca += "</div>";

        return ca;
    }

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        Page page = new Page();
        HtmlForm form = new HtmlForm();


        // Deshabilitar la validación de eventos, sólo asp.net 2
        page.EnableEventValidation = false;

        // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
        page.DesignerInitialize();

        page.Controls.Add(form);
        form.Controls.Add(panelResultado);//PanelTablaEncuesta, va el nombre del panel que contiene los resultados de las tablas

        page.RenderControl(htw);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=Export_Encuesta" + DateTime.Now.ToShortTimeString() + ".xls");
        Response.Charset = "UTF-8";
        Response.ContentEncoding = Encoding.Default;
        Response.Write(sb.ToString());
        Response.End();

    }
    public override void VerifyRenderingInServerForm(Control control)
   {
       /// Verifies that the control is rendered /
   }
    protected void btnCurriculo_Click(object sender, EventArgs e)
    {
        //btnEnfasisCurriculo.Visible = true;
        //btnSedesxMunicipioCurriculo.Visible = true;
        //btnModeloEducativoCurriculo.Visible = true;
        //btnPEIProcesoInstitucionalEstudiantes.Visible = true;
        //btnPEIInvestigacion.Visible = true;
        //btnPEIUsoTIC.Visible = true;
        //btnUsoTICCurriculo.Visible = true;
        //btnUsoTICCurriculoCompentencias.Visible = true;
        //btnSedesxUbicacion.Visible = true;
        //btnDocentesUltimoNivelEducativoAprobado.Visible = true;

    }
    protected void btnEnfasisCurriculo_Click(object sender, EventArgs e)
    {
        //cargarCurriculo();
    }

    //[WebMethod(EnableSession = true)]
    //public static string totalsedesxubicacion()
    //{
    //    string ca;

    //    ca = cargarCurriculo();

    //    return ca;
    //}
    //private void cargarCurriculo()
     [WebMethod(EnableSession = true)]
     public static string cargarCurriculo()
     {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable datos = lb.cargarSedesxEnfasisPEI();

        if(datos != null && datos.Rows.Count > 0)
        {
            int ciencia = 0;
            int innovacion = 0;
            int tecnologia = 0;
            int tic = 0;
            int na = 0;
            int investigacion = 0;
            //ca +="<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>SEDES QUE INCLUYEN ENFASIS FORMATIVOS EN EL PROYECTO EDUCATIVO  INSTITUCIONAL PEI</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Número total de sedes educativas</th>";
            ca += "<th>TOTAL</th>";
            ca += "</tr>";
            for(int i = 0; i < datos.Rows.Count; i++)
            {
                if (datos.Rows[i]["respuesta"].ToString() == "Ciencia")
                {
                    ca += "<tr>";
                    ca += "<td>En Ciencia</td>";
                    ca += "<td align='right'>" + datos.Rows[i]["total"].ToString() + "</td>";
                    ca += "</tr>";
                }
                else
                {
                    ciencia++;
                }

                if (datos.Rows[i]["respuesta"].ToString() == "Innovación")
                {
                    ca += "<tr>";
                    ca += "<td>En Innovación</td>";
                    ca += "<td align='right'>" + datos.Rows[i]["total"].ToString() + "</td>";
                    ca += "</tr>";
                }
                else
                {
                    innovacion++;
                }

                if (datos.Rows[i]["respuesta"].ToString() == "Investigación")
                {
                    ca += "<tr>";
                    ca += "<td>En Investigación</td>";
                    ca += "<td align='right'>" + datos.Rows[i]["total"].ToString() + "</td>";
                    ca += "</tr>";
                }
                else
                {
                    investigacion++;
                }

                if (datos.Rows[i]["respuesta"].ToString() == "TIC")
                {
                    ca += "<tr>";
                    ca += "<td>En TIC</td>";
                    ca += "<td align='right'>" + datos.Rows[i]["total"].ToString() + "</td>";
                    ca += "</tr>";
                }
                else
                {
                    tic++;
                }

                if (datos.Rows[i]["respuesta"].ToString() == "Tecnología")
                {
                    ca += "<tr>";
                    ca += "<td>En Tecnología</td>";
                    ca += "<td align='right'>" + datos.Rows[i]["total"].ToString() + "</td>";
                    ca += "</tr>";
                }
                else
                {
                    tecnologia++;
                }

                if (datos.Rows[i]["respuesta"].ToString() == "No aplica")
                {
                    ca += "<tr>";
                    ca += "<td>No aplica</td>";
                    ca += "<td align='right'>" + datos.Rows[i]["total"].ToString() + "</td>";
                    ca += "</tr>";
                }
                else
                {
                    na++;
                }
               
            }
            if(ciencia == 0)
            {
                ca += "<tr>";
                ca += "<td>En Ciencia</td>";
                ca += "<td>0</td>";
                ca += "</tr>";
            }
            if (innovacion == 0)
            {
                ca += "<tr>";
                ca += "<td>En Innovación</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            if (investigacion == 0)
            {
                ca += "<tr>";
                ca += "<td>En Investigación</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            if (tic == 0)
            {
                ca += "<tr>";
                ca += "<td>En TIC</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            if (tecnologia == 0)
            {
                ca += "<tr>";
                ca += "<td>En Tecnología</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            if (na == 0)
            {
                ca += "<tr>";
                ca += "<td>No aplica</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            //ca +="</table>";
        }

        return ca;

        ////lblResultado.Text = ca;

    }

    protected void btnSedesxMunicipioCurriculo_Click(object sender, EventArgs e)
    {
        //cargarSedesxMunicipioCurriculo();
    }

     [WebMethod(EnableSession = true)]
    public static string sedesxmunicipio()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        Institucion inst = new Institucion();
        DataTable datos = lb.cargarSedesxMunicipioDiligenciandoForm();
        DataTable municipio = inst.cargarciudadxDepartamento("20");

        if (datos != null && datos.Rows.Count > 0)
        {
          
            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<th>Municipio</th>";
            ca += "<th>Total de sedes educativas por municipio</th>";
            ca += "</tr>";

            if (municipio != null && municipio.Rows.Count > 0)
            {
                int contadorsedes = 0;
                for (int i = 0; i < municipio.Rows.Count; i++)
                {
                    int contador = 0;
                    for (int j = 0; j < datos.Rows.Count; j++)
                    {
                        if (municipio.Rows[i]["nombre"].ToString() == datos.Rows[j]["municipio"].ToString())
                        {
                            contador++;
                            contadorsedes++;
                        }
                    }
                    if (contador > 0)
                    {
                        if (municipio.Rows[i]["nombre"].ToString() == "PLATO")
                        {
                            ca += "<tr>";
                            ca += "<td>" + municipio.Rows[i]["nombre"].ToString() + "</td>";
                            ca += "<td align='right'>29</td>";
                            ca += "</tr>";
                        }
                        else if (municipio.Rows[i]["nombre"].ToString() == "EL RETÉN")
                        {
                            ca += "<tr>";
                            ca += "<td>" + municipio.Rows[i]["nombre"].ToString() + "</td>";
                            ca += "<td align='right'>6</td>";
                            ca += "</tr>";
                        }
                        else if (municipio.Rows[i]["nombre"].ToString() == "ZAPAYÁN")
                        {
                            ca += "<tr>";
                            ca += "<td>" + municipio.Rows[i]["nombre"].ToString() + "</td>";
                            ca += "<td align='right'>6</td>";
                            ca += "</tr>";
                        }
                        else if (municipio.Rows[i]["nombre"].ToString() == "ZONA BANANERA")
                        {
                            ca += "<tr>";
                            ca += "<td>" + municipio.Rows[i]["nombre"].ToString() + "</td>";
                            ca += "<td align='right'>35</td>";
                            ca += "</tr>";
                        }
                        else
                        {
                            ca += "<tr>";
                            ca += "<td>" + municipio.Rows[i]["nombre"].ToString() + "</td>";
                            ca += "<td align='right'>" + contador + "</td>";
                            ca += "</tr>";
                        }
                        
                    }
                    else
                    {
                        ca += "<tr>";
                        ca += "<td>" + municipio.Rows[i]["nombre"].ToString() + "</td>";
                        ca += "<td align='right'>0</td>";
                        ca += "</tr>";
                    }
                }
                ca += "<tr>";
                ca += "<th>TOTAL SEDES</th>";
                ca += "<td align='right' style='font-weight:bold;'>320</td>";
                //ca += "<td align='right' style='font-weight:bold;'>" + contadorsedes + "</td>";
                ca += "</tr>";
            }
        }

        return ca;
        ////lblResultado.Text = ca;

    }

    protected void btnModeloEducativoCurriculo_Click(object sender, EventArgs e)
    {
        //cargarModeloEducativo();
    }
    [WebMethod(EnableSession = true)]
    public static string cargarModeloEducativo()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        Institucion inst = new Institucion();
        DataTable datos = lb.cargarSedesxModeloEducativo();
        DataTable municipios = inst.cargarciudad();

        if (datos != null && datos.Rows.Count > 0)
        {
            int aceleracion = 0;
            int Telesecundara = 0;
            int sat = 0;
            int Escuela_Nueva = 0;
            int ser = 0;
            int na = 0;
            int crecer = 0;
            int Postprimaria = 0;
            int cafam = 0;
            string MunAceleracion = "";
            string MunTelesecundara = "";
            string MunSAT = "";
            string MunEscuelaNueva = "";
            string MunPostprimaria = "";
            string MunSER = "";
            string MunCRECER = "";
            string MunCAFAM = "";
            string MunNA = "";

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='3' style='text-align:center;font-weight:bold;'>SEDES QUE INCLUYEN MODELOS EDUCATIVOS POTENCIALMENTE FAVORABLES A LA INCORPORACIÓN DE LA IEP APOYADA EN TIC</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Municipio </th>";
            ca += "<th>Modelo Educativo </th>";
            ca += "<th>TOTAL</th>";
            ca += "</tr>";
            for (int j = 0; j < municipios.Rows.Count; j++)
            {
                int Validate = 0;
                int ValidateTelesecundara = 0;
                int ValidateSAT = 0;
                int ValidateEscuelaNueva = 0;
                int ValidatePostPrimaria = 0;
                int ValidateSER = 0;
                int ValidateCRECER = 0;
                int ValidateCAFAM = 0;
                int ValidateNA = 0;
                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    if (municipios.Rows[j]["cod"].ToString() == datos.Rows[i]["cod"].ToString())
                    {
                        if (datos.Rows[i]["respuesta"].ToString() == "Aceleración del aprendizaje")
                        {
                            aceleracion++;
                            if(Validate == 0)
                            {
                                MunAceleracion += datos.Rows[i]["nombre"].ToString() + " - ";
                                Validate = 1;
                            }

                            
                        }

                        if (datos.Rows[i]["respuesta"].ToString() == "Telesecundara")
                        {
                            Telesecundara++;
                            if (ValidateTelesecundara == 0)
                            {
                                MunTelesecundara += datos.Rows[i]["nombre"].ToString() + " - ";
                                ValidateTelesecundara = 1;
                            }
                        }

                        if (datos.Rows[i]["respuesta"].ToString() == "Sistema De Educación Tutorial SAT")
                        {
                            sat++;
                            if (ValidateSAT == 0)
                            {
                                MunSAT += datos.Rows[i]["nombre"].ToString() + " - ";
                                ValidateSAT = 1;
                            }
                        }


                        if (datos.Rows[i]["respuesta"].ToString() == "Escuela Nueva")
                        {
                            Escuela_Nueva++;
                            if (ValidateEscuelaNueva == 0)
                            {
                                MunEscuelaNueva += datos.Rows[i]["nombre"].ToString() + " - ";
                                ValidateEscuelaNueva = 1;
                            }
                        }


                        if (datos.Rows[i]["respuesta"].ToString() == "Postprimaria")
                        {
                            Postprimaria++;
                            if (ValidatePostPrimaria == 0)
                            {
                                MunPostprimaria += datos.Rows[i]["nombre"].ToString() + " - ";
                                ValidatePostPrimaria = 1;
                            }
                        }


                        if (datos.Rows[i]["respuesta"].ToString() == "Servicio de educación rural –SER-")
                        {
                            ser++;
                            if (ValidateSER == 0)
                            {
                                MunSER += datos.Rows[i]["nombre"].ToString() + " - ";
                                ValidateSER = 1;
                            }
                        }


                        if (datos.Rows[i]["respuesta"].ToString() == "Propuesta educativa para jóvenes y adultos CRECER")
                        {
                            crecer++;
                            if (ValidateCRECER == 0)
                            {
                                MunCRECER += datos.Rows[i]["nombre"].ToString() + " - ";
                                ValidateCRECER = 1;
                            }
                        }


                        if (datos.Rows[i]["respuesta"].ToString() == "Programa de educación continuada de CAFAM")
                        {
                            cafam++;
                            if (ValidateCAFAM == 0)
                            {
                                MunCAFAM += datos.Rows[i]["nombre"].ToString() + " - ";
                                ValidateCAFAM = 1;
                            }
                        }


                        if (datos.Rows[i]["respuesta"].ToString() == "No aplica")
                        {
                            na++;
                            if (ValidateNA == 0)
                            {
                                MunNA += datos.Rows[i]["nombre"].ToString() + " - ";
                                ValidateNA = 1;
                            }
                        }
                    }
                }
                  
             

            }
            if (aceleracion == 0)
            {
                ca += "<tr>";
                ca += "<td>" + MunAceleracion + "</td>";
                ca += "<td>Aceleración del aprendizaje</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td>" + MunAceleracion + "</td>";
                ca += "<td>Aceleración del aprendizaje</td>";
                ca += "<td align='right'>" + aceleracion + "</td>";
                ca += "</tr>";
            }
            if (Telesecundara == 0)
            {
                ca += "<tr>";
                ca += "<td>" + MunTelesecundara + "</td>";
                ca += "<td>Telesecundara</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td>" + MunTelesecundara + "</td>";
                ca += "<td>Telesecundara</td>";
                ca += "<td align='right'>" + Telesecundara + "</td>";
                ca += "</tr>";
            }
            if (sat == 0)
            {
                ca += "<tr>";
                ca += "<td>" + MunSAT + "</td>";
                ca += "<td>Sistema De Educación Tutorial SAT</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td>" + MunSAT + "</td>";
                ca += "<td>Sistema De Educación Tutorial SAT</td>";
                ca += "<td align='right'>" + sat + "</td>";
                ca += "</tr>";
            }
            if (Escuela_Nueva == 0)
            {
                ca += "<tr>";
                ca += "<td>" + MunEscuelaNueva + "</td>";
                ca += "<td>Escuela Nueva</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td>" + MunEscuelaNueva + "</td>";
                ca += "<td>Escuela Nueva</td>";
                ca += "<td align='right'>" + Escuela_Nueva + "</td>";
                ca += "</tr>";
            }
            if (crecer == 0)
            {
                ca += "<tr>";
                ca += "<td>" + MunCRECER + "</td>";
                ca += "<td>Propuesta educativa para jóvenes y adultos CRECER</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td>" + MunCRECER + "</td>";
                ca += "<td>Propuesta educativa para jóvenes y adultos CRECER</td>";
                ca += "<td align='right'>" + crecer + "</td>";
                ca += "</tr>";
            }
            if (Postprimaria == 0)
            {
                ca += "<tr>";
                ca += "<td>" + MunPostprimaria + "</td>";
                ca += "<td>Postprimaria</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td>" + MunPostprimaria + "</td>";
                ca += "<td>Postprimaria</td>";
                ca += "<td align='right'>" + Postprimaria + "</td>";
                ca += "</tr>";
            }
            if (cafam == 0)
            {
                ca += "<tr>";
                ca += "<td>" + MunCAFAM + "</td>";
                ca += "<td>Programa de educación continuada de CAFAM</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td>" + MunCAFAM + "</td>";
                ca += "<td>Programa de educación continuada de CAFAM</td>";
                ca += "<td align='right'>" + cafam + "</td>";
                ca += "</tr>";
            }
            if (ser == 0)
            {
                ca += "<tr>";
                ca += "<td>" + MunSER + "</td>";
                ca += "<td>Servicio de educación rural –SER-</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td>" + MunSER + "</td>";
                ca += "<td>Servicio de educación rural –SER-</td>";
                ca += "<td align='right'>" + ser + "</td>";
                ca += "</tr>";
            }
            if (na == 0)
            {
                ca += "<tr>";
                ca += "<td>" + MunNA + "</td>";
                ca += "<td>No aplica</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td>" + MunNA + "</td>";
                ca += "<td>No aplica</td>";
                ca += "<td align='right'>" + na + "</td>";
                ca += "</tr>";
            }
            ca += "</table>";
        }

        return ca;
        ////lblResultado.Text = ca;

    }

    protected void btnPEIProcesoInstitucionalEstudiantes_Click(object sender, EventArgs e)
    {
        //cargarPEIProcesoInstitucionalEstudiantes();//Pregunta Nro 3, subpregunta: Uso de Las TIC de los Estudiantes
    }
    [WebMethod(EnableSession = true)]
    public static string cargarPEIProcesoInstitucionalEstudiantes()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable datos = lb.cargarReportePreguntasCerradas("3", "4", "02");

        if (datos != null && datos.Rows.Count > 0)
        {
            int si = 0;
            int no = 0;


            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>PROPORCIÓN SEDES QUE CONSIDERAN EL USO DE TICS EN LOS ESTUDIANTES</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Número total de sedes educativas</th>";
            ca += "<th>TOTAL</th>";
            ca += "</tr>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                if (datos.Rows[i]["respuesta"].ToString() == "Si")
                {
                    si++;
                }

                if (datos.Rows[i]["respuesta"].ToString() == "No")
                {
                    no++;
                }

            }
            if (si == 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>Si</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>Si</td>";
                ca += "<td align='right'>" + si + "</td>";
                ca += "</tr>";
            }
            if (no == 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>No</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>No</td>";
                ca += "<td align='right'>" + no + "</td>";
                ca += "</tr>";
            }

            ca += "</table>";
        }
        return ca;
        ////lblResultado.Text = ca;

    }

   

    protected void btnPEIInvestigacion_Click(object sender, EventArgs e)
    {
        //cargarPEIInvestigacion();//Pregunta No. 5: En el PEI se promueve la investigación dentro de las prácticas institucionales?
    }
    [WebMethod(EnableSession = true)]
    public static string cargarPEIInvestigacion()
    {
        string ca = "";

        LineaBase lb = new LineaBase();
        DataTable datos = lb.cargarReportePreguntasCerradas("5", "0", "02");

        if (datos != null && datos.Rows.Count > 0)
        {
            int si = 0;
            int no = 0;


            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>PROPORCIÓN SEDES EDUCATIVAS QUE TIENEN LA  INVESTIGACIÓN DENTRO DEL PEI O LAS PRÁCTICAS INSTITUCIONALES</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Número total de sedes educativas</th>";
            ca += "<th>TOTAL</th>";
            ca += "</tr>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                if (datos.Rows[i]["respuesta"].ToString() == "Si")
                {
                    si++;
                }

                if (datos.Rows[i]["respuesta"].ToString() == "No")
                {
                    no++;
                }

            }
            if (si == 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>Si</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>Si</td>";
                ca += "<td align='right'>" + si + "</td>";
                ca += "</tr>";
            }
            if (no == 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>No</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>No</td>";
                ca += "<td align='right'>" + no + "</td>";
                ca += "</tr>";
            }

            ca += "</table>";
        }
        return ca;
        ////lblResultado.Text = ca;

    }

    protected void btnPEIUsoTIC_Click(object sender, EventArgs e)
    {
        //cargarPEIUsoTIC();//Pregunta No. 6: En el PEI se promueve el uso de las TICs como parte de las prácticas institucionales?
    }
    [WebMethod(EnableSession = true)]
    public static string cargarPEIUsoTIC()
    {
        string ca = "";

        LineaBase lb = new LineaBase();
        DataTable datos = lb.cargarReportePreguntasCerradas("6", "0", "02");

        if (datos != null && datos.Rows.Count > 0)
        {
            int PC = 0;
            int Tableta = 0;
            int Tablero_inteligente = 0;
            int Wikis = 0;
            int Foros = 0;
            int Portátil = 0;
            int Correo_electrónico = 0;
            int Software_educativo = 0;
            int Blogs = 0;
            int Otras = 0;

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>PROPORCIÓN SEDES EDUCATIVAS QUE TIENEN EN EL PEI Y/O PRÁCTICAS INSTITUCIONALES EL USO DE LAS TICS</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Número total de sedes educativas </th>";
            ca += "<th>TOTAL</th>";
            ca += "</tr>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                if (datos.Rows[i]["respuesta"].ToString() == "PC")
                {
                    PC++;
                }


                if (datos.Rows[i]["respuesta"].ToString() == "Tableta")
                {
                    Tableta++;
                }


                if (datos.Rows[i]["respuesta"].ToString() == "Tablero inteligente")
                {
                    Tablero_inteligente++;
                }


                if (datos.Rows[i]["respuesta"].ToString() == "Wikis")
                {
                    Wikis++;
                }


                if (datos.Rows[i]["respuesta"].ToString() == "Foros")
                {
                    Foros++;
                }


                if (datos.Rows[i]["respuesta"].ToString() == "Portátil")
                {
                    Portátil++;
                }


                if (datos.Rows[i]["respuesta"].ToString() == "Correo electrónico")
                {
                    Correo_electrónico++;
                }


                if (datos.Rows[i]["respuesta"].ToString() == "Software educativo")
                {
                    Software_educativo++;
                }

                if (datos.Rows[i]["respuesta"].ToString() == "Blogs")
                {
                    Blogs++;
                }

                if (datos.Rows[i]["respuesta"].ToString() == "Otras")
                {
                    Otras++;
                }


            }
            if (PC == 0)
            {
                ca += "<tr>";
                ca += "<td>PC</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td>PC</td>";
                ca += "<td align='right'>" + PC + "</td>";
                ca += "</tr>";
            }
            if (Tableta == 0)
            {
                ca += "<tr>";
                ca += "<td>Tableta</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td>Tableta</td>";
                ca += "<td align='right'>" + Tableta + "</td>";
                ca += "</tr>";
            }
            if (Tablero_inteligente == 0)
            {
                ca += "<tr>";
                ca += "<td>Tablero inteligente</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td>Tablero inteligente</td>";
                ca += "<td align='right'>" + Tablero_inteligente + "</td>";
                ca += "</tr>";
            }
            if (Wikis == 0)
            {
                ca += "<tr>";
                ca += "<td>Wikis</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td>Wikis</td>";
                ca += "<td align='right'>" + Wikis + "</td>";
                ca += "</tr>";
            }
            if (Foros == 0)
            {
                ca += "<tr>";
                ca += "<td>Foros</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td>Foros</td>";
                ca += "<td align='right'>" + Foros + "</td>";
                ca += "</tr>";
            }
            if (Portátil == 0)
            {
                ca += "<tr>";
                ca += "<td>Portátil</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td>Portátil</td>";
                ca += "<td align='right'>" + Portátil + "</td>";
                ca += "</tr>";
            }
            if (Correo_electrónico == 0)
            {
                ca += "<tr>";
                ca += "<td>Correo electrónico</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td>Correo electrónico</td>";
                ca += "<td align='right'>" + Correo_electrónico + "</td>";
                ca += "</tr>";
            }
            if (Software_educativo == 0)
            {
                ca += "<tr>";
                ca += "<td>Software educativo</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td>Software educativo</td>";
                ca += "<td align='right'>" + Software_educativo + "</td>";
                ca += "</tr>";
            }
            if (Blogs == 0)
            {
                ca += "<tr>";
                ca += "<td>Blogs</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td>Blogs</td>";
                ca += "<td align='right'>" + Blogs + "</td>";
                ca += "</tr>";
            }
            if (Otras == 0)
            {
                ca += "<tr>";
                ca += "<td>Otras</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td>Otras</td>";
                ca += "<td align='right'>" + Otras + "</td>";
                ca += "</tr>";
            }
            ca += "</table>";
        }
        return ca;
        ////lblResultado.Text = ca;

    }

    protected void btnUsoTICCurriculo_Click(object sender, EventArgs e)
    {
        //cargarUsoTICCurriculo();
    }
    [WebMethod(EnableSession = true)]
    public static string cargarUsoTICCurriculo()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable datos = lb.cargarReportePreguntasCerradas("7", "0", "02");

        if (datos != null && datos.Rows.Count > 0)
        {
            int si = 0;
            int no = 0;


            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>PROPORCIÓN DE SEDES EDUCATIVAS QUE TIENEN CURRÍCULOS QUE FORMAN EN COMPETENCIAS SOBRE APROPIACIÓN DE TIC</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Número total de sedes educativas</th>";
            ca += "<th>TOTAL</th>";
            ca += "</tr>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                if (datos.Rows[i]["respuesta"].ToString() == "Si")
                {
                    si++;
                }

                if (datos.Rows[i]["respuesta"].ToString() == "No")
                {
                    no++;
                }

            }
            if (si == 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>Si</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>Si</td>";
                ca += "<td align='right'>" + si + "</td>";
                ca += "</tr>";
            }
            if (no == 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>No</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>No</td>";
                ca += "<td align='right'>" + no + "</td>";
                ca += "</tr>";
            }

            ca += "</table>";
        }
        return ca;
        ////lblResultado.Text = ca;

    }

    protected void btnUsoTICCurriculoCompentencias_Click(object sender, EventArgs e)
    {
        //cargarCompetenciasApropiacionTICPropuestaMen();//Pregunta No. 8: ¿Cuáles competencias en apropiación de TIC pretende formar el currículo, según la propuesta del MEN?
    }
    protected void btnSedesxUbicacion_Click(object sender, EventArgs e)
    {
        //cargarSedesxUbicacion();
    }
    [WebMethod(EnableSession = true)]
    public static string cargarSedesxUbicacion()
    {
        string ca = "";
        int total = 0;
        LineaBase lb = new LineaBase();
        DataTable datos = lb.SedesxUbicacion();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Sedes por ubicación</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>UBICACIÓN </th>";
            ca += "<th>TOTAL</th>";
            ca += "</tr>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + datos.Rows[i]["nombre"].ToString() + "</td>";
                ca += "<td align='right'></td>";
                ca += "</tr>";
                total += Convert.ToInt32(datos.Rows[i]["total"].ToString());
                total++;
            }
            ca += "<tr>";
            ca += "<th>TOTAL SEDES</th>";
            ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
            ca += "</tr>";
            ca += "</table>";
        }


        return ca;
       

      ////lblResultado.Text = ca;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarCompetenciasApropiacionTICPropuestaMen()
    {
        string ca = "";

        LineaBase lb = new LineaBase();
        DataTable datos = lb.cargarReportePreguntasCerradas("8", "0", "02");

        if (datos != null && datos.Rows.Count > 0)
        {
            int Pedagógica = 0;
            int Tecnológica = 0;
            int Investigativa = 0;
            int Comunicativa = 0;
            int Gestión = 0;
        

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>PROPORCIÓN DE SEDES EDUCATIVAS CON CURRÍCULOS QUE PRETENDEN FORMAR COMPETENCIAS PEDAGÓGICAS</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Número total de sedes educativas </th>";
            ca += "<th>TOTAL</th>";
            ca += "</tr>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                if (datos.Rows[i]["respuesta"].ToString() == "Pedagógica")
                {
                    Pedagógica++;
                }


                if (datos.Rows[i]["respuesta"].ToString() == "Tecnológica")
                {
                    Tecnológica++;
                }


                if (datos.Rows[i]["respuesta"].ToString() == "Investigativa")
                {
                    Investigativa++;
                }


                if (datos.Rows[i]["respuesta"].ToString() == "Comunicativa")
                {
                    Comunicativa++;
                }


                if (datos.Rows[i]["respuesta"].ToString() == "Gestión")
                {
                    Gestión++;
                }

            }
            if (Pedagógica == 0)
            {
                ca += "<tr>";
                ca += "<td>Pedagógica</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td>Pedagógica</td>";
                ca += "<td align='right'>" + Pedagógica + "</td>";
                ca += "</tr>";
            }
            if (Tecnológica == 0)
            {
                ca += "<tr>";
                ca += "<td>Tecnológica</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td>Tecnológica</td>";
                ca += "<td align='right'>" + Tecnológica + "</td>";
                ca += "</tr>";
            }
            if (Investigativa == 0)
            {
                ca += "<tr>";
                ca += "<td>Investigativa</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td>Investigativa</td>";
                ca += "<td align='right'>" + Investigativa + "</td>";
                ca += "</tr>";
            }
            if (Comunicativa == 0)
            {
                ca += "<tr>";
                ca += "<td>Comunicativa</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td>Comunicativa</td>";
                ca += "<td align='right'>" + Comunicativa + "</td>";
                ca += "</tr>";
            }
            if (Gestión == 0)
            {
                ca += "<tr>";
                ca += "<td>Gestión</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td>Gestión</td>";
                ca += "<td align='right'>" + Gestión + "</td>";
                ca += "</tr>";
            }
           
            ca += "</table>";
        }
        return ca;
        ////lblResultado.Text = ca;

    }

    protected void btnEquipamiento_Click(object sender, EventArgs e)
    {
        //btnEnfasisCurriculo.Visible = false;
        //btnSedesxMunicipioCurriculo.Visible = false;
        //btnModeloEducativoCurriculo.Visible = false;
        //btnPEIProcesoInstitucionalEstudiantes.Visible = false;
        //btnPEIInvestigacion.Visible = false;
        //btnPEIUsoTIC.Visible = false;
        //btnUsoTICCurriculo.Visible = false;
        //btnUsoTICCurriculoCompentencias.Visible = false;

        //btnSedesxEquiposInformaticoEquipamiento.Visible = true;
        //btnSedesxMunicipioEquipamiento.Visible = true;
        //btnSedesxEquiposInformaticodesagregadoGrado.Visible = true;
        //btnSedesxEquiposInformaticoFueraEscuela.Visible = true;
        //btnSedesxSoftwareEducativo.Visible = true;
        //btnSedesxHerramientaWeb.Visible = true;
        //btnSedesxFormacionDocenteUsoTIC.Visible = true;
        //btnSedesxPlanMejoramientoTIC.Visible = true;

        
    }

    protected void btnSedesxMunicipioEquipamiento_Click(object sender, EventArgs e)
    {
        //cargarSedesxMuicipioEquipamiento();
    }
    [WebMethod(EnableSession = true)]
    public static string cargarSedesxMuicipioEquipamiento()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        Institucion inst = new Institucion();
        /* select s.nombre as nomsede, (SUM(et.conpc) + SUM(et.sinpc)) as pc, (SUM(et.conportatil) + SUM(et.sinportatil)) as portatil, (SUM(et.contablet) + SUM(et.sintablet)) as tablet, (SUM(et.contableros) + SUM(et.sintableros)) as tableros from lbase_equipostics et right join lbase_sedeasesor sa on sa.codigo=et.codsedeasesor right join ins_sede s on s.codigo=sa.codsede inner join geo_municipios m on m.cod=s.codmunicipio where et.codinstrumento='3' and et.codpregunta='1.1' group by s.nombre, s.codinstitucion  order by s.codinstitucion ASC */

        DataTable datos = lb.cargarSedesxMunicipioEquipamiento();
        DataTable municipio = inst.cargarciudadxDepartamento("20");

        if (datos != null && datos.Rows.Count > 0)
        {

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<th>Municipio</th>";
            ca += "<th>Total de sedes educativas</th>";
            ca += "</tr>";

            if (municipio != null && municipio.Rows.Count > 0)
            {
                int contadorsedes = 0;
                for (int i = 0; i < municipio.Rows.Count; i++)
                {
                    int contador = 0;
                    for (int j = 0; j < datos.Rows.Count; j++)
                    {
                        if (municipio.Rows[i]["nombre"].ToString() == datos.Rows[j]["municipio"].ToString())
                        {
                            contador++;
                            contadorsedes++;
                        }
                    }
                    if (contador > 0)
                    {
                        ca += "<tr>";
                        ca += "<td>" + municipio.Rows[i]["nombre"].ToString() + "</td>";
                        ca += "<td align='right'>" + contador + "</td>";
                        ca += "</tr>";
                    }
                    else
                    {
                        ca += "<tr>";
                        ca += "<td>" + municipio.Rows[i]["nombre"].ToString() + "</td>";
                        ca += "<td align='right'>0</td>";
                        ca += "</tr>";
                    }
                }
                ca += "<tr>";
                ca += "<th>TOTAL SEDES</th>";
                ca += "<td align='right' style='font-weight:bold;'>" + contadorsedes + "</td>";
                ca += "</tr>";
            }
        }
        return ca;

        ////lblResultado.Text = ca;

    }

     protected void btnSedesxEquiposInformaticoEquipamiento_Click(object sender, EventArgs e)
    {
        //cargarEquiposInformaticosXSedes();
    }
    [WebMethod(EnableSession = true)]
     public static string cargarEquiposInformaticosXSedes()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         
         DataTable datos = lb.cargarEquiposInformaticosXSedes("3","1.1");


         if (datos != null && datos.Rows.Count > 0)
         {

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<th>Municipio</th>";
             ca += "<th>Sede</th>";
             ca += "<th>Personal</th>";
             ca += "<th>Con PC</th>";
             ca += "<th>Sin PC</th>";
             ca += "<th>Con Portátil</th>";
             ca += "<th>Sin Portátil</th>";
             ca += "<th>Con Tablet</th>";
             ca += "<th>Sin Tablet</th>";
             ca += "<th>Con Tableros</th>";
             ca += "<th>Sin Tableros</th>";
             ca += "</tr>";

           
                     for (int j = 0; j < datos.Rows.Count; j++)
                     {
                        
                             ca += "<tr>";
                             ca += "<td>" + datos.Rows[j]["municipio"].ToString() + "</td>";
                            ca += "<td>" + datos.Rows[j]["nomsede"].ToString() + "</td>";
                            ca += "<td>" + datos.Rows[j]["respuesta"].ToString() + "</td>";
                             ca += "<td align='right'>" + datos.Rows[j]["conpc"].ToString() + "</td>";
                             ca += "<td align='right'>" + datos.Rows[j]["sinpc"].ToString() + "</td>";
                             ca += "<td align='right'>" + datos.Rows[j]["conportatil"].ToString() + "</td>";
                             ca += "<td align='right'>" + datos.Rows[j]["sinportatil"].ToString() + "</td>";
                             ca += "<td align='right'>" + datos.Rows[j]["contablet"].ToString() + "</td>";
                             ca += "<td align='right'>" + datos.Rows[j]["sintablet"].ToString() + "</td>";
                             ca += "<td align='right'>" + datos.Rows[j]["contableros"].ToString() + "</td>";
                             ca += "<td align='right'>" + datos.Rows[j]["sintableros"].ToString() + "</td>";
                             ca += "</tr>";
                         }
       
                 }
                 //ca += "<tr>";
                 //ca += "<th>TOTAL SEDES</th>";
                 //ca += "<td align='right' style='font-weight:bold;'>" + contadorsedes + "</td>";
                 //ca += "</tr>";
         return ca;
         ////lblResultado.Text = ca;
     }
     protected void btnSedesxEquiposInformaticodesagregadoGrado_Click(object sender, EventArgs e)
     {
         //cargarSedesxEquiposInformaticodesagregadoGrado();
     }
    [WebMethod(EnableSession = true)]
     public static string cargarSedesxEquiposInformaticodesagregadoGrado()
     {
         string ca = "";

         LineaBase lb = new LineaBase();
         DataTable datos = lb.cargarEquiposInformaticosXSedes("3","111");


         if (datos != null && datos.Rows.Count > 0)
         {

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<th>Municipio</th>";
             ca += "<th>Sede</th>";
             ca += "<th>Nivel Educativo</th>";
             ca += "<th>PC con Conexión</th>";
             ca += "<th>PC sin Conexión</th>";
             ca += "<th>Portátil con Conexión</th>";
             ca += "<th>Portátil sin Conexión</th>";
             ca += "<th>Tablet con Conexión</th>";
             ca += "<th>Tablet sin Conexión</th>";
             ca += "</tr>";


             for (int j = 0; j < datos.Rows.Count; j++)
             {

                 ca += "<tr>";
                 ca += "<td>" + datos.Rows[j]["municipio"].ToString() + "</td>";
                 ca += "<td>" + datos.Rows[j]["nomsede"].ToString() + "</td>";
                 ca += "<td>" + datos.Rows[j]["respuesta"].ToString() + "</td>";
                 ca += "<td align='right'>" + datos.Rows[j]["conpc"].ToString() + "</td>";
                 ca += "<td align='right'>" + datos.Rows[j]["sinpc"].ToString() + "</td>";
                 ca += "<td align='right'>" + datos.Rows[j]["conportatil"].ToString() + "</td>";
                 ca += "<td align='right'>" + datos.Rows[j]["sinportatil"].ToString() + "</td>";
                 ca += "<td align='right'>" + datos.Rows[j]["contablet"].ToString() + "</td>";
                 ca += "<td align='right'>" + datos.Rows[j]["sintablet"].ToString() + "</td>";
                 ca += "</tr>";
             }

         }
         //ca += "<tr>";
         //ca += "<th>TOTAL SEDES</th>";
         //ca += "<td align='right' style='font-weight:bold;'>" + contadorsedes + "</td>";
         //ca += "</tr>";
         return ca;
         ////lblResultado.Text = ca;
     }
     protected void btnSedesxEquiposInformaticoFueraEscuela_Click(object sender, EventArgs e)
     {
         //cargarSedesxEquiposInformaticoFueraEscuela();
     }
    [WebMethod(EnableSession = true)]
     public static string cargarSedesxEquiposInformaticoFueraEscuela()
     {
         string ca = "";

         LineaBase lb = new LineaBase();
         DataTable datos = lb.cargarEquiposInformaticosXSedes("3", "112");


         if (datos != null && datos.Rows.Count > 0)
         {

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<th>Municipio</th>";
             ca += "<th>Sede</th>";
             ca += "<th>Nivel Educativo</th>";
             ca += "<th>PC con Conexión</th>";
             ca += "<th>PC sin Conexión</th>";
             ca += "<th>Portátil con Conexión</th>";
             ca += "<th>Portátil sin Conexión</th>";
             ca += "<th>Tablet con Conexión</th>";
             ca += "<th>Tablet sin Conexión</th>";
             ca += "</tr>";


             for (int j = 0; j < datos.Rows.Count; j++)
             {

                 ca += "<tr>";
                 ca += "<td>" + datos.Rows[j]["municipio"].ToString() + "</td>";
                 ca += "<td>" + datos.Rows[j]["nomsede"].ToString() + "</td>";
                 ca += "<td>" + datos.Rows[j]["respuesta"].ToString() + "</td>";
                 ca += "<td align='right'>" + datos.Rows[j]["conpc"].ToString() + "</td>";
                 ca += "<td align='right'>" + datos.Rows[j]["sinpc"].ToString() + "</td>";
                 ca += "<td align='right'>" + datos.Rows[j]["conportatil"].ToString() + "</td>";
                 ca += "<td align='right'>" + datos.Rows[j]["sinportatil"].ToString() + "</td>";
                 ca += "<td align='right'>" + datos.Rows[j]["contablet"].ToString() + "</td>";
                 ca += "<td align='right'>" + datos.Rows[j]["sintablet"].ToString() + "</td>";
                 ca += "</tr>";
             }

         }
         //ca += "<tr>";
         //ca += "<th>TOTAL SEDES</th>";
         //ca += "<td align='right' style='font-weight:bold;'>" + contadorsedes + "</td>";
         //ca += "</tr>";
         return ca;
         ////lblResultado.Text = ca;
     }

     protected void btnSedesxSoftwareEducativo_Click(object sender, EventArgs e)
     {
         //cargarSedesxSoftwareEducativo();
     }
    [WebMethod(EnableSession = true)]
     public static string cargarSedesxSoftwareEducativo()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable datos = lb.cargarSedesConSoftwareEducativo();


         if (datos != null && datos.Rows.Count > 0)
         {

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='3' style='text-align:center;font-weight:bold;'>IE con software educativo</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Número total de sedes educativas que tienen software educativo</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<td align='center'>SI</td>";
             ca += "<td align='right'>" + datos.Rows.Count + "</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<td align='center'>NO</td>";
             ca += "<td align='right'>" + (320 - datos.Rows.Count) + "</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>TOTAL SEDES</th>";
             ca += "<td align='right' style='font-weight:bold;'>320</td>";
             ca += "</tr>";
             ca += "</table>";


             //for (int j = 0; j < datos.Rows.Count; j++)
             //{

             //    ca += "<tr>";
             //    ca += "<td>" + datos.Rows[j]["municipio"].ToString() + "</td>";
             //    ca += "<td>" + datos.Rows[j]["nomsede"].ToString() + "</td>";
             //    //ca += "<td>" + datos.Rows[j]["respuesta"].ToString() + "</td>";
             //    ca += "<td align='right'>" + datos.Rows[j]["conpc"].ToString() + "</td>";
             //    ca += "<td align='right'>" + datos.Rows[j]["sinpc"].ToString() + "</td>";
             //    ca += "<td align='right'>" + datos.Rows[j]["conportatil"].ToString() + "</td>";
             //    ca += "<td align='right'>" + datos.Rows[j]["sinportatil"].ToString() + "</td>";
             //    ca += "<td align='right'>" + datos.Rows[j]["contablet"].ToString() + "</td>";
             //    ca += "<td align='right'>" + datos.Rows[j]["sintablet"].ToString() + "</td>";
             //    ca += "</tr>";
             //}

         }
         //ca += "<tr>";
         //ca += "<th>TOTAL SEDES</th>";
         //ca += "<td align='right' style='font-weight:bold;'>" + contadorsedes + "</td>";
         //ca += "</tr>";
         return ca;
         ////lblResultado.Text = ca;
     }

     protected void btnSedesxHerramientaWeb_Click(object sender, EventArgs e)
     {
         //cargarSedesxHerramientaWeb();
     }
    [WebMethod(EnableSession = true)]
     public static string cargarSedesxHerramientaWeb()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable datos = lb.SedesxHerramientaWeb();

         if (datos != null && datos.Rows.Count > 0)
         {
             int paginaWeb = 0;
             int wikis = 0;
             int foros = 0;
             int blogs = 0;
             int redesSociales = 0;
             int pedagogico = 0;

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='3' style='text-align:center;font-weight:bold;'>IE con herramientas WEB</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Número total de sedes que cuentan como herramienta WEB</th>";
             ca += "<th>Total</th>";
             ca += "<th></th>";
             ca += "</tr>";

             for (int i = 0; i < datos.Rows.Count; i++)
             {
                 if (datos.Rows[i]["tipo"].ToString() == "Página de internet")
                 {
                     paginaWeb++;
                 }
                 if (datos.Rows[i]["tipo"].ToString() == "Blogs")
                 {
                     blogs++;
                 }
                 if (datos.Rows[i]["tipo"].ToString() == "Wikis")
                 {
                     wikis++;
                 }
                 if (datos.Rows[i]["tipo"].ToString() == "Foros")
                 {
                     foros++;
                 }
                 if (datos.Rows[i]["tipo"].ToString() == "Redes sociales")
                 {
                     redesSociales++;
                 }
                 if (datos.Rows[i]["tipo"].ToString() == "Pedagógicos")
                 {
                     pedagogico++;
                 }
             }

             if (paginaWeb == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Pagina de internet</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "<td align='right'><a onclick='alert(\"Sin registros para mostrar\")' href='javascript:void(0)'><img src='images/detalles.png' />Ver</a></td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Pagina de internet</td>";
                 ca += "<td align='right'>"+paginaWeb+"</td>";
                 ca += "<td align='right'><a href='replineabasegeneraldet.aspx?tipo=pagweb&pregunta=1_4'><img src='images/detalles.png' />Ver</a></td>";
                 ca += "</tr>";
             }
             if (wikis == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Wikis</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "<td align='right'><a onclick='alert(\"Sin registros para mostrar\")' href='javascript:void(0)'><img src='images/detalles.png' />Ver</a></td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Wikis</td>";
                 ca += "<td align='right'>" + wikis + "</td>";
                 ca += "<td align='right'><a href='replineabasegeneraldet.aspx?tipo=wikis&pregunta=1_4'><img src='images/detalles.png' />Ver</a></td>";
                 ca += "</tr>";
             }
             if (foros == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Foros</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "<td align='right'><a onclick='alert(\"Sin registros para mostrar\")' href='javascript:void(0)'><img src='images/detalles.png' />Ver</a></td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Foros</td>";
                 ca += "<td align='right'>" + foros + "</td>";
                 ca += "<td align='right'><a href='replineabasegeneraldet.aspx?tipo=foros&pregunta=1_4'><img src='images/detalles.png' />Ver</a></td>";
                 ca += "</tr>";
             }
             if (blogs == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Blogs</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "<td align='right'><a onclick='alert(\"Sin registros para mostrar\")' href='javascript:void(0)'><img src='images/detalles.png' />Ver</a></td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Blogs</td>";
                 ca += "<td align='right'>" + blogs + "</td>";
                 ca += "<td align='right'><a href='replineabasegeneraldet.aspx?tipo=blog&pregunta=1_4'><img src='images/detalles.png' />Ver</a></td>";
                 ca += "</tr>";
             }
             if (redesSociales == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Redes sociales</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "<td align='right'><a onclick='alert(\"Sin registros para mostrar\")' href='javascript:void(0)'><img src='images/detalles.png' />Ver</a></td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Redes sociales</td>";
                 ca += "<td align='right'>" + redesSociales + "</td>";
                 ca += "<td align='right'><a href='replineabasegeneraldet.aspx?tipo=reds&pregunta=1_4'><img src='images/detalles.png' />Ver</a></td>";
                 ca += "</tr>";
             }
             if (pedagogico == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Pedagógicos</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "<td align='right'><a onclick='alert(\"Sin registros para mostrar\")' href='javascript:void(0)'><img src='images/detalles.png' />Ver</a></td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Pedagógicos</td>";
                 ca += "<td align='right'>" + pedagogico + "</td>";
                 ca += "<td align='right'><a href='replineabasegeneraldet.aspx?tipo=pedag&pregunta=1_4'><img src='images/detalles.png' />Ver</a></td>";
                 ca += "</tr>";
             }

             ca += "</table>";
         }
         return ca;
         ////lblResultado.Text = ca;
     }

     protected void btnSedesxFormacionDocenteUsoTIC_Click(object sender, EventArgs e)
     {
         //cargarSedesxFormacionDocenteUsoTIC();
     }
    [WebMethod(EnableSession = true)]
     public static string cargarSedesxFormacionDocenteUsoTIC()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable datos = lb.SedesxFormacionDocenteUsoTIC();


         if (datos != null && datos.Rows.Count > 0)
         {
             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='3' style='text-align:center;font-weight:bold;'>IE con procesos de formación docentes en uso TIC</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Número total de sedes educativas que han participado en procesos de formación docentes en uso de TICS</th>";
             ca += "<th>Total</th>";
             ca += "<th></th>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<td align='center'>SI</td>";
             ca += "<td align='right'>" + datos.Rows.Count + "</td>";
             ca += "<td align='right'><a href='replineabasegeneraldet.aspx?resp=si&pregunta=211'><img src='images/detalles.png' />Ver</a></td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<td align='center'>NO</td>";
             ca += "<td align='right'>" + (320 - datos.Rows.Count) + "</td>";
             ca += "<td align='right'><a href='replineabasegeneraldet.aspx?resp=no&pregunta=211'><img src='images/detalles.png' />Ver</a></td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>TOTAL SEDES</th>";
             ca += "<td align='right' style='font-weight:bold;'>320</td>";
             ca += "</tr>";
             ca += "</table>";
         }
         return ca;
         ////lblResultado.Text = ca;
     }

     protected void btnSedesxPlanMejoramientoTIC_Click(object sender, EventArgs e)
     {
         //cargarSedesxPlanMejoramientoTIC();
     }
    [WebMethod(EnableSession = true)]
     public static string cargarSedesxPlanMejoramientoTIC()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable datos = lb.SedesxPlanMejoramientoTIC();


         if (datos != null && datos.Rows.Count > 0)
         {
             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='3' style='text-align:center;font-weight:bold;'>IE con planes de mejoramiento TIC</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Número total de sedes educativas que han incluido TIC en sus planes de mejoramiento</th>";
             ca += "<th>Total</th>";
             ca += "<th></th>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<td align='center'>SI</td>";
             ca += "<td align='right'>" + datos.Rows.Count + "</td>";
             ca += "<td align='right'><a href='replineabasegeneraldet.aspx?resp=si&pregunta=221'><img src='images/detalles.png' />Ver</a></td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<td align='center'>NO</td>";
             ca += "<td align='right'>" + (320 - datos.Rows.Count) + "</td>";
             ca += "<td align='right'><a href='replineabasegeneraldet.aspx?resp=no&pregunta=221'><img src='images/detalles.png' />Ver</a></td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>TOTAL SEDES</th>";
             ca += "<td align='right' style='font-weight:bold;'>320</td>";
             ca += "</tr>";
             ca += "</table>";
         }
         return ca;
         ////lblResultado.Text = ca;
     }

     protected void btnPerfilDocente_Click(object sender, EventArgs e)
     {
         //btnFormulariosxMunicipio.Visible = true;
         //btnFormulariosxSedes.Visible = true;
         //btnFormulariosxRespondiente.Visible = true;
         //btnFormularioDiligenciadoxNivelEducativo.Visible = true;
         //btnFormularioDiligenciadoxDocencia.Visible = true;
         //btnFormacionEspecificaPracticasPedagogicas.Visible = true;
         //btnParticipoProyectosInvestifacionDinstitucion.Visible = true;
         //btnModalidadProyectoDinstitucion.Visible = true;
         //btnNivelObtenidoDocente.Visible = true;
     }

     protected void btnFormulariosxMunicipio_Click(object sender, EventArgs e)
     {
         //cargarFormulariosxMunicipio();
         //btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarFormulariosxMunicipio()
     {
         string ca = "";

         LineaBase lb = new LineaBase();
         Institucion inst = new Institucion();
         //DataTable datos = lb.cargarSedesxMunicipioDiligenciandoForm();
         DataTable datos = lb.formulariosxMunicipioDiligenciados("1", "0", "5");
         DataTable municipio = inst.cargarciudadxDepartamento("20");

         if (datos != null && datos.Rows.Count > 0)
         {

             //ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Formularios diligenciados por municipio</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Municipio</th>";
             ca += "<th>Total de formularios diligenciados por municipio</th>";
             ca += "</tr>";

             if (municipio != null && municipio.Rows.Count > 0)
             {
                 int contadorsedes = 0;
                 for (int i = 0; i < municipio.Rows.Count; i++)
                 {
                     int contador = 0;
                     for (int j = 0; j < datos.Rows.Count; j++)
                     {
                         if (municipio.Rows[i]["nombre"].ToString() == datos.Rows[j]["municipio"].ToString())
                         {
                             contador++;
                             contadorsedes++;
                         }
                     }
                     if (contador > 0)
                     {
                         ca += "<tr>";
                         ca += "<td>" + municipio.Rows[i]["nombre"].ToString() + "</td>";
                         ca += "<td align='right'>"+contador+"</td>";
                         ca += "</tr>";
                     }
                     else
                     {
                         ca += "<tr>";
                         ca += "<td>" + municipio.Rows[i]["nombre"].ToString() + "</td>";
                         ca += "<td align='right'>0</td>";
                         ca += "</tr>";
                     }
                 }
                 ca += "<tr>";
                 ca += "<th>TOTAL FORMULARIOS DILIGENCIADOS</th>";
                 ca += "<td align='right' style='font-weight:bold;'>" + datos.Rows.Count + " / 3386</td>";
                 //ca += "<td align='right' style='font-weight:bold;'>" + contadorsedes + "</td>";
                 ca += "</tr>";

             }
             //ca += "</table>";
         }

         return ca;
         //lblResultado.Text = ca;

     }

     protected void btnFormulariosxSedes_Click(object sender, EventArgs e)
     {
         //cargarFormulariosDiligenciadosxSedes();
         //btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarFormulariosDiligenciadosxSedes()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         Institucion inst = new Institucion();
         DataTable sedes = inst.cargarTodasSedes();
         DataTable datos = lb.formulariosxSedeDiligenciados("1", "0", "5");

         if (datos != null && datos.Rows.Count > 0)
         {
             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>formularios diligenciados por sedes</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Sedes</th>";
             ca += "<th>Total de formularios diligenciados por sedes</th>";
             ca += "</tr>";

             if (sedes != null && sedes.Rows.Count > 0)
             {
                 for (int i = 0; i < sedes.Rows.Count; i++)
                 {
                     int contador = 0;
                     for (int j = 0; j < datos.Rows.Count; j++)
                     {
                         if (sedes.Rows[i]["nombre"].ToString() == datos.Rows[j]["sede"].ToString())
                         {
                             contador++;
                         }
                     }
                     if (contador > 0)
                     {
                         ca += "<tr>";
                         ca += "<td>" + sedes.Rows[i]["nombre"].ToString() + "</td>";
                         ca += "<td align='right'>" + contador + "</td>";
                         ca += "</tr>";
                     }
                     else
                     {
                         ca += "<tr>";
                         ca += "<td>" + sedes.Rows[i]["nombre"].ToString() + "</td>";
                         ca += "<td align='right'>0</td>";
                         ca += "</tr>";
                     }
                 }
                 ca += "<tr>";
                 ca += "<th>TOTAL FORMULARIOS DILIGENCIADOS</th>";
                 ca += "<td align='right' style='font-weight:bold;'>" + datos.Rows.Count + " / 3386</td>";
                 //ca += "<td align='right' style='font-weight:bold;'>" + contadorsedes + "</td>";
                 ca += "</tr>";
             }
             ca += "</table>";
         }
         //lblResultado.Text = ca;

         return ca;
     }

     protected void btnNivelObtenidoDocente_Click(object sender, EventArgs e)
     {
         //cargarNivelObtenidoDocente();
         //btnExportExcel.Visible = true;
     }
     [WebMethod(EnableSession = true)]
     public static string cargarNivelObtenidoDocente()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
         if (docentes != null && docentes.Rows.Count > 0)
         {
             int bachipedagogico = 0; int Normalista_Superior = 0; int Otro_bachillerato = 0; int Técnico_tecnológico = 0; int Otro_Técnico_tecnológico = 0;
             int Profesional_pedagógico = 0; int Especialización = 0; int Otro_profesional = 0; int Maestría_en_educación_pedagogía = 0; int Otra_Maestría = 0;
             int Doctorado_en_educación_pedagogía = 0; int Otro_doctorado = 0;
             for (int i = 0; i < docentes.Rows.Count; i++)
             {
                 DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento05OFFSET(docentes.Rows[i]["codigo"].ToString(), "2", "0", "5", "12");
                 if (respuestas != null && respuestas.Rows.Count > 0)
                 {
                     for (int k = 0; k < respuestas.Rows.Count; k++)
                     {
                         if (respuestas.Rows[k]["respuesta"].ToString() != "")
                         {
                             if (k == 0)
                                 bachipedagogico++;
                             else if (k == 1)
                                 Normalista_Superior++;
                             else if (k == 2)
                                 Otro_bachillerato++;
                             else if (k == 3)
                                 Técnico_tecnológico++;
                             else if (k == 4)
                                 Otro_Técnico_tecnológico++;
                             else if (k == 5)
                                 Profesional_pedagógico++;
                             else if (k == 6)
                                 Especialización++;
                             else if (k == 7)
                                 Otro_profesional++;
                             else if (k == 8)
                                 Maestría_en_educación_pedagogía++;
                             else if (k == 9)
                                 Otra_Maestría++;
                             else if (k == 10)
                                 Doctorado_en_educación_pedagogía++;
                             else if (k == 11)
                                 Otro_doctorado++;
                         }
                        
                     }
                 }

             }

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Ultimo nivel de formación obtenido</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Respuestas</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";

             if (bachipedagogico != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>Bachillerato pedagógico.</td>";
                 ca += "<td align='right'>" + bachipedagogico + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>Bachillerato pedagógico.</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (Normalista_Superior != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>Normalista Superior.</td>";
                 ca += "<td align='right'>" + Normalista_Superior + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>Normalista Superior.</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (Otro_bachillerato != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>Otro bachillerato.</td>";
                 ca += "<td align='right'>" + Otro_bachillerato + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>Otro bachillerato.</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (Técnico_tecnológico != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>Técnico o tecnológico.</td>";
                 ca += "<td align='right'>" + Técnico_tecnológico + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>Técnico o tecnológico.</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (Otro_Técnico_tecnológico != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>Otro Técnico o tecnológico.</td>";
                 ca += "<td align='right'>" + Otro_Técnico_tecnológico + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>Otro Técnico o tecnológico.</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (Profesional_pedagógico != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>Profesional pedagógico.</td>";
                 ca += "<td align='right'>" + Profesional_pedagógico + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>Profesional pedagógico.</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (Especialización != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>Especialización.</td>";
                 ca += "<td align='right'>" + Especialización + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>Especialización.</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             if (Otro_profesional != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>Otro profesional.</td>";
                 ca += "<td align='right'>" + Otro_profesional + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>Otro profesional.</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             if (Maestría_en_educación_pedagogía != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>Maestría en educación o pedagogía.</td>";
                 ca += "<td align='right'>" + Maestría_en_educación_pedagogía + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>Maestría en educación o pedagogía.</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             if (Otra_Maestría != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>Otra Maestría.</td>";
                 ca += "<td align='right'>" + Otra_Maestría + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>Otra Maestría.</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             if (Doctorado_en_educación_pedagogía != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>Doctorado en educación o pedagogía.</td>";
                 ca += "<td align='right'>" + Doctorado_en_educación_pedagogía + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>Doctorado en educación o pedagogía.</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             if (Otro_doctorado != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>Otro doctorado.</td>";
                 ca += "<td align='right'>" + Otro_doctorado + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>Otro doctorado.</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             //lblResultado.Text = ca;
         }
         return ca;
     }


     protected void btnFormulariosxRespondiente_Click(object sender, EventArgs e)
     {
         //cargarFormulariosxRespondiente();
         //btnExportExcel.Visible = true;
     }
     [WebMethod(EnableSession = true)]
     public static string cargarFormulariosxRespondiente()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable datos = lb.formulariosxRespondiente("1", "0", "5");
         if (datos != null && datos.Rows.Count > 0)
         {
             int directivoDocente = 0;
             int docente = 0;
             int docenteEducacionespecial = 0;
             int docenteEtnoeducacion = 0;
             int consejeros = 0;
             int medicos = 0;
             int administrativos = 0;
             int profesionales = 0;
             int tutores = 0;
             int directivos = 0;
             int auxiliar = 0;

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>formularios diligenciados por respondientes</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Respondientes</th>";
             ca += "<th>Total de formularios diligenciados por respondientes</th>";
             ca += "</tr>";

             for (int i = 0; i < datos.Rows.Count; i++)
             {
                 if (datos.Rows[i]["respuesta"].ToString() == "Directivo docente")
                 {
                     directivoDocente++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Docentes (no incluya educadores especiales ni etnoeducadores)  ")
                 {
                     docente++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Docentes de educación especial ")
                 {
                     docenteEducacionespecial++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Docentes de etnoeducación")
                 {
                     docenteEtnoeducacion++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Consejeros escolares, capellanes, orientadores, sicólogos y trabajadores sociales")
                 {
                     consejeros++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Médicos, odontólogos, nutricionistas, terapeutas y enfermeros ")
                 {
                     medicos++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Administrativos (de apoyo y personal de servicios generales)")
                 {
                     administrativos++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Profesionales de apoyo en el aula para estudiantes con discapacidad o capacidades excepcionales (intérpretes, tiflólogos, etc.)")
                 {
                     profesionales++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Tutores")
                 {
                     tutores++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Directivos (rectores, directores, coordinadores, supervisores, secretarios académicos)")
                 {
                     directivos++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Auxiliar de aula")
                 {
                     auxiliar++;
                 }
             }

             if (directivoDocente == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Directivo docente</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Directivo docente</td>";
                 ca += "<td align='right'>"+directivoDocente+"</td>";
                 ca += "</tr>";
             }
             if (docente == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Docentes (no incluya educadores especiales ni etnoeducadores)</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Docentes (no incluya educadores especiales ni etnoeducadores)</td>";
                 ca += "<td align='right'>" + docente + "</td>";
                 ca += "</tr>";
             }
             if (docenteEducacionespecial == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Docentes de educación especial</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Docentes de educación especial</td>";
                 ca += "<td align='right'>" + docenteEducacionespecial + "</td>";
                 ca += "</tr>";
             }
             if (docenteEtnoeducacion == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Docentes de etnoeducación</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Docentes de etnoeducación</td>";
                 ca += "<td align='right'>" + docenteEtnoeducacion + "</td>";
                 ca += "</tr>";
             }
             if (consejeros == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Consejeros escolares, capellanes, orientadores, sicólogos y trabajadores sociales</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Consejeros escolares, capellanes, orientadores, sicólogos y trabajadores sociales</td>";
                 ca += "<td align='right'>" + consejeros + "</td>";
                 ca += "</tr>";
             }
             if (medicos == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Médicos, odontólogos, nutricionistas, terapeutas y enfermeros</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Médicos, odontólogos, nutricionistas, terapeutas y enfermeros</td>";
                 ca += "<td align='right'>" + medicos + "</td>";
                 ca += "</tr>";
             }
             if (administrativos == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Administrativos (de apoyo y personal de servicios generales)</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Administrativos (de apoyo y personal de servicios generales)</td>";
                 ca += "<td align='right'>" + administrativos + "</td>";
                 ca += "</tr>";
             }
             if (profesionales == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Profesionales de apoyo en el aula para estudiantes con discapacidad o capacidades excepcionales (intérpretes, tiflólogos, etc.)</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Profesionales de apoyo en el aula para estudiantes con discapacidad o capacidades excepcionales (intérpretes, tiflólogos, etc.)</td>";
                 ca += "<td align='right'>" + profesionales + "</td>";
                 ca += "</tr>";
             }
             if (tutores == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Tutores</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Tutores</td>";
                 ca += "<td align='right'>" + tutores + "</td>";
                 ca += "</tr>";
             }
             if (directivos == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Directivos (rectores, directores, coordinadores, supervisores, secretarios académicos)</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Directivos (rectores, directores, coordinadores, supervisores, secretarios académicos)</td>";
                 ca += "<td align='right'>" + directivos + "</td>";
                 ca += "</tr>";
             }
             if (auxiliar == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Auxiliar de aula</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Auxiliar de aula</td>";
                 ca += "<td align='right'>" + auxiliar + "</td>";
                 ca += "</tr>";
             }
             ca += "<tr>";
             ca += "<th>TOTAL FORMULARIOS DILIGENCIADOS</th>";
             ca += "<td align='right' style='font-weight:bold;'>" + datos.Rows.Count + " / 3386</td>";
             //ca += "<td align='right' style='font-weight:bold;'>" + contadorsedes + "</td>";
             ca += "</tr>";
             ca += "</table>";
         }
         //lblResultado.Text = ca;

         return ca;
     }

     protected void btnFormularioDiligenciadoxNivelEducativo_Click(object sender, EventArgs e)
     {
         //cargarFormularioDiligenciadoxNivelEducativo();
         //btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarFormularioDiligenciadoxNivelEducativo()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable datos = lb.formulariosxRespondiente("3", "0", "5");

         if (datos != null && datos.Rows.Count > 0)
         {
             int preescolar = 0;
             int primaria = 0;
             int secundaria = 0;

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>formularios diligenciados por nivel de trabajo educativo</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Nivel educativo</th>";
             ca += "<th>Total de formularios diligenciados por nivel de trabajo educativo</th>";
             ca += "</tr>";

             for (int i = 0; i < datos.Rows.Count; i++)
             {
                 if (datos.Rows[i]["respuesta"].ToString() == "Preescolar")
                 {
                     preescolar++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Básica Primaria")
                 {
                     primaria++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Básica Secundaria y Media")
                 {
                     secundaria++;
                 }
             }

             if (preescolar == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Preescolar</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Preescolar</td>";
                 ca += "<td align='right'>"+preescolar+"</td>";
                 ca += "</tr>";
             }
             if (primaria == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Básica Primaria</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Básica Primaria</td>";
                 ca += "<td align='right'>" + primaria + "</td>";
                 ca += "</tr>";
             }
             if (preescolar == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Básica Secundaria y Media</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Básica Secundaria y Media</td>";
                 ca += "<td align='right'>" + secundaria + "</td>";
                 ca += "</tr>";
             }
             ca += "<tr>";
             ca += "<th>TOTAL FORMULARIOS DILIGENCIADOS</th>";
             ca += "<td align='right' style='font-weight:bold;'>" + datos.Rows.Count + " / 3386</td>";
             ca += "</tr>";
             ca += "</table>";
         }
         //lblResultado.Text = ca;
         return ca;
     }

     protected void btnFormularioDiligenciadoxDocencia_Click(object sender, EventArgs e)
     {
         //btnCaracterAcademico.Visible = true;
         //btnCaracterTecnicoAgropecuario.Visible = true;
         //btnCaracterTecnicoComercial.Visible = true;
         //btnCaracterTecnicoIndustrial.Visible = true;
     }

     protected void btnCaracterAcademico_Click(object sender, EventArgs e)
     {
         //cargarFomularioDiligenciadoxDocenciaCaracterAcademico();
         //btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarFomularioDiligenciadoxDocenciaCaracterAcademico()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable datos = lb.formulariosxRespondiente("4", "1", "5");

         if (datos != null && datos.Rows.Count > 0)
         {
             int todasAreas = 0;
             int naturales = 0;
             int sociales = 0;
             int artistica = 0;
             int etica = 0;
             int fisica = 0;
             int religion = 0;
             int humaninades = 0;
             int matematica = 0;
             int informatica = 0;
             int economia = 0;
             int politica = 0;
             int filosofia = 0;
             int otra = 0;

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>formularios diligenciados por desarrollo de docencia caracter academico</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Docencia</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";

             for (int i = 0; i < datos.Rows.Count; i++)
             {
                 if (datos.Rows[i]["respuesta"].ToString() == "Todas las áreas")
                 {
                     todasAreas++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Ciencias naturales y educación ambiental")
                 {
                     naturales++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Ciencias sociales, historia, geografía, constitución política y democracia")
                 {
                     sociales++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Educación artística")
                 {
                     artistica++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Educación ética y en valores humanos")
                 {
                     etica++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Educación física, recreación y deportes")
                 {
                     fisica++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Educación religiosa")
                 {
                     religion++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Humanidades, lengua castellana e idiomas extranjeros")
                 {
                     humaninades++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Matemáticas")
                 {
                     matematica++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Tecnología e informática")
                 {
                     informatica++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Ciencias económicas")
                 {
                     economia++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Ciencias políticas")
                 {
                     politica++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Filosofía")
                 {
                     filosofia++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Otra, ¿cuál?")
                 {
                     otra++;
                 }
             }

             if (todasAreas == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Todas las áreas</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Todas las áreas</td>";
                 ca += "<td align='right'>" + todasAreas + "</td>";
                 ca += "</tr>";
             }
             if (naturales == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Ciencias naturales y educación ambiental</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Ciencias naturales y educación ambiental</td>";
                 ca += "<td align='right'>" + naturales + "</td>";
                 ca += "</tr>";
             }
             if (sociales == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Ciencias sociales, historia, geografía, constitución política y democracia</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Ciencias sociales, historia, geografía, constitución política y democracia</td>";
                 ca += "<td align='right'>" + sociales + "</td>";
                 ca += "</tr>";
             }
             if (artistica == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Educación artística</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Educación artística</td>";
                 ca += "<td align='right'>" + artistica + "</td>";
                 ca += "</tr>";
             }
             if (etica == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Educación ética y en valores humanos</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Educación ética y en valores humanos</td>";
                 ca += "<td align='right'>" + etica + "</td>";
                 ca += "</tr>";
             }
             if (fisica == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Educación física, recreación y deportes</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Educación física, recreación y deportes</td>";
                 ca += "<td align='right'>" + fisica + "</td>";
                 ca += "</tr>";
             }
             if (religion == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Educación religiosa</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Educación religiosa</td>";
                 ca += "<td align='right'>" + religion + "</td>";
                 ca += "</tr>";
             }
             if (humaninades == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Humanidades, lengua castellana e idiomas extranjeros</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Humanidades, lengua castellana e idiomas extranjeros</td>";
                 ca += "<td align='right'>" + humaninades + "</td>";
                 ca += "</tr>";
             }
             if (matematica == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Matemáticas</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Matemáticas</td>";
                 ca += "<td align='right'>" + matematica + "</td>";
                 ca += "</tr>";
             }
             if (informatica == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Tecnología e informática</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Tecnología e informática</td>";
                 ca += "<td align='right'>" + informatica + "</td>";
                 ca += "</tr>";
             }
             if (economia == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Ciencias económicas</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Ciencias económicas</td>";
                 ca += "<td align='right'>" + economia + "</td>";
                 ca += "</tr>";
             }
             if (politica == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Ciencias políticas</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Ciencias políticas</td>";
                 ca += "<td align='right'>" + politica + "</td>";
                 ca += "</tr>";
             }
             if (filosofia == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Filosofía</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Filosofía</td>";
                 ca += "<td align='right'>" + filosofia + "</td>";
                 ca += "</tr>";
             }
             if (otra == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Otra, ¿cuál?</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Otra, ¿cuál?</td>";
                 ca += "<td align='right'>" + otra + "</td>";
                 ca += "</tr>";
             }
             ca += "<tr>";
             ca += "<th>TOTAL FORMULARIOS DILIGENCIADOS</th>";
             ca += "<td align='right' style='font-weight:bold;'>" + datos.Rows.Count + " / 3386</td>";
             ca += "</tr>";
             ca += "</table>";
         }
         //lblResultado.Text = ca;
         return ca;
     }

    //Tecnico agropecuario
     protected void btnCaracterTecnicoAgropecuario_Click(object sender, EventArgs e)
     {
         //cargarFomularioDiligenciadoxDocenciaCaracterTecnicoAgropecuario();
         //btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarFomularioDiligenciadoxDocenciaCaracterTecnicoAgropecuario()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable datos = lb.formulariosxRespondiente("4", "2", "5");

         if (datos != null && datos.Rows.Count > 0)
         {
             int pecuaria = 0;
             int agricola = 0;
             int otra = 0;

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>formularios diligenciados por desarrollo de docencia caracter tecnico agropecuario</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Docencia</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";

             for (int i = 0; i < datos.Rows.Count; i++)
             {
                 if (datos.Rows[i]["respuesta"].ToString() == "Pecuario")
                 {
                     pecuaria++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Agrícola")
                 {
                     agricola++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Otra ¿cuál?")
                 {
                     otra++;
                 }
             }

             if (pecuaria == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Pecuario</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Pecuario</td>";
                 ca += "<td align='right'>" + pecuaria + "</td>";
                 ca += "</tr>";
             }
             if (agricola == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Agrícola</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Agrícola</td>";
                 ca += "<td align='right'>" + agricola + "</td>";
                 ca += "</tr>";
             }
             if (otra == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Otra ¿cuál?</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Otra ¿cuál?</td>";
                 ca += "<td align='right'>" + otra + "</td>";
                 ca += "</tr>";
             }
             ca += "<tr>";
             ca += "<th>TOTAL FORMULARIOS DILIGENCIADOS</th>";
             ca += "<td align='right' style='font-weight:bold;'>" + datos.Rows.Count + " / 3386</td>";
             ca += "</tr>";
             ca += "</table>";
         }
         //lblResultado.Text = ca;
         return ca;
     }

    //tecnico comercial
     protected void btnCaracterTecnicoComercial_Click(object sender, EventArgs e)
     {
         //cargarFomularioDiligenciadoxDocenciaCaracterTecnicoComercial();
         //btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarFomularioDiligenciadoxDocenciaCaracterTecnicoComercial()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable datos = lb.formulariosxRespondiente("4", "3", "5");

         if (datos != null && datos.Rows.Count > 0)
         {
             int contabilidad = 0;
             int finanza = 0;
             int gestion = 0;
             int administracion = 0;
             int ambiental = 0;
             int salud = 0;
             int otra = 0;

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>formularios diligenciados por desarrollo de docencia caracter tecnico comercial y servicios</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Docencia</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";

             for (int i = 0; i < datos.Rows.Count; i++ )
             {
                 if (datos.Rows[i]["respuesta"].ToString() == "Contabilidad")
                 {
                     contabilidad++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Finanzas")
                 {
                     finanza++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Gestión")
                 {
                     gestion++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Administración")
                 {
                     administracion++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Ambiental")
                 {
                     ambiental++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Salud")
                 {
                     salud++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Otra ¿cuál?")
                 {
                     otra++;
                 }
             }

             if (contabilidad == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Contabilidad</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Contabilidad</td>";
                 ca += "<td align='right'>" + contabilidad + "</td>";
                 ca += "</tr>";
             }
             if (finanza == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Finanzas</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Finanzas</td>";
                 ca += "<td align='right'>" + finanza + "</td>";
                 ca += "</tr>";
             }
             if (gestion == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Gestión</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Gestión</td>";
                 ca += "<td align='right'>" + gestion + "</td>";
                 ca += "</tr>";
             }
             if (administracion == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Administración</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Administración</td>";
                 ca += "<td align='right'>" + administracion + "</td>";
                 ca += "</tr>";
             }
             if (ambiental == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Ambiental</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Ambiental</td>";
                 ca += "<td align='right'>" + ambiental + "</td>";
                 ca += "</tr>";
             }
             if (salud == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Salud</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Salud</td>";
                 ca += "<td align='right'>" + salud + "</td>";
                 ca += "</tr>";
             }
             if (otra == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Otra ¿cuál?</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Otra ¿cuál?</td>";
                 ca += "<td align='right'>" + otra + "</td>";
                 ca += "</tr>";
             }

             ca += "<tr>";
             ca += "<th>TOTAL FORMULARIOS DILIGENCIADOS</th>";
             ca += "<td align='right' style='font-weight:bold;'>" + datos.Rows.Count + " / 3386</td>";
             ca += "</tr>";
             ca += "</table>";
         }
         //lblResultado.Text = ca;
         return ca;
     }

    //tecnico industrial
     protected void btnCaracterTecnicoIndustrial_Click(object sender, EventArgs e)
     {
         //cargarFomularioDiligenciadoxDocenciaCaracterTecnicoIndustrial();
         //btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarFomularioDiligenciadoxDocenciaCaracterTecnicoIndustrial()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable datos = lb.formulariosxRespondiente("4", "4", "5");

         if (datos != null && datos.Rows.Count > 0)
         {
             int electricidad = 0;
             int electronica = 0;
             int mindustrial = 0;
             int mautomotriz = 0;
             int metalisteria = 0;
             int metalmecanica = 0;
             int ebanisteria = 0;
             int fundicion = 0;
             int construccion = 0;
             int dmecanico = 0;
             int dgrafico = 0;
             int darquitectonico = 0;
             int otra = 0;

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>formularios diligenciados por desarrollo de docencia caracter tecnico industrial</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Docencia</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";

             for (int i = 0; i < datos.Rows.Count; i++)
             {
                 if (datos.Rows[i]["respuesta"].ToString() == "Electricidad")
                 {
                     electricidad++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Electrónica")
                 {
                     electronica++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Mecánica industrial")
                 {
                     mindustrial++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Mecánica automotriz")
                 {
                     mautomotriz++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Metalistería")
                 {
                     metalisteria++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Metalmecánica")
                 {
                     metalmecanica++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Ebanistería")
                 {
                     ebanisteria++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Fundición")
                 {
                     fundicion++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Construcciones civiles")
                 {
                     construccion++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Diseño mecánico")
                 {
                     dmecanico++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Diseño gráfico")
                 {
                     dgrafico++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Diseño arquitectónico")
                 {
                     darquitectonico++;
                 }
                 if (datos.Rows[i]["respuesta"].ToString() == "Otra ¿cuál?")
                 {
                     otra++;
                 }
             }

             if (electricidad == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Electricidad</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Electricidad</td>";
                 ca += "<td align='right'>" + electricidad + "</td>";
                 ca += "</tr>";
             }
             if (electronica == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Electrónica</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Electrónica</td>";
                 ca += "<td align='right'>" + electronica + "</td>";
                 ca += "</tr>";
             }
             if (mindustrial == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Mecánica industrial</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Mecánica industrial</td>";
                 ca += "<td align='right'>" + mindustrial + "</td>";
                 ca += "</tr>";
             }
             if (mautomotriz == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Mecánica automotriz</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Mecánica automotriz</td>";
                 ca += "<td align='right'>" + mautomotriz + "</td>";
                 ca += "</tr>";
             }
             if (metalisteria == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Metalistería</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Metalistería</td>";
                 ca += "<td align='right'>" + metalisteria + "</td>";
                 ca += "</tr>";
             }
             if (metalmecanica == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Metalmecánica</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Metalmecánica</td>";
                 ca += "<td align='right'>" + metalmecanica + "</td>";
                 ca += "</tr>";
             }
             if (ebanisteria == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Ebanistería</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Ebanistería</td>";
                 ca += "<td align='right'>" + ebanisteria + "</td>";
                 ca += "</tr>";
             }
             if (fundicion == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Fundición</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Fundición</td>";
                 ca += "<td align='right'>" + fundicion + "</td>";
                 ca += "</tr>";
             }
             if (construccion == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Construcciones civiles</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Construcciones civiles</td>";
                 ca += "<td align='right'>" + construccion + "</td>";
                 ca += "</tr>";
             }
             if (dmecanico == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Diseño mecánico</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Diseño mecánico</td>";
                 ca += "<td align='right'>" + dmecanico + "</td>";
                 ca += "</tr>";
             }
             if (dgrafico == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Diseño gráfico</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Diseño gráfico</td>";
                 ca += "<td align='right'>" + dgrafico + "</td>";
                 ca += "</tr>";
             }
             if (darquitectonico == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Diseño arquitectónico</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Diseño arquitectónico</td>";
                 ca += "<td align='right'>" + darquitectonico + "</td>";
                 ca += "</tr>";
             }
             if (otra == 0)
             {
                 ca += "<tr>";
                 ca += "<td>Otra ¿cuál?</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td>Otra ¿cuál?</td>";
                 ca += "<td align='right'>" + otra + "</td>";
                 ca += "</tr>";
             }
             ca += "<tr>";
             ca += "<th>TOTAL FORMULARIOS DILIGENCIADOS</th>";
             ca += "<td align='right' style='font-weight:bold;'>" + datos.Rows.Count + " / 3386</td>";
             ca += "</tr>";
             ca += "</table>";
         }
         return ca;
         //lblResultado.Text = ca;
     }

     protected void btnFormacionEspecificaPracticasPedagogicas_Click(object sender, EventArgs e)
     {
         //cargarFormacionEspecificaPracticasPedagogicas();
         //btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarFormacionEspecificaPracticasPedagogicas()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable datos = lb.formacionEspecificaPracticasPedagogicas("5", "5");
         if (datos != null && datos.Rows.Count > 0)
         {
             int si = 0;

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Cursos de formación especifica en sus practicas pedagogicas</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Contribución</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";

             for (int i = 0; i < datos.Rows.Count; i++)
             {
                 if (datos.Rows[i]["respuesta"].ToString() == "Si")
                 {
                     si++;
                 }
             }

             if (si == 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>SI</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>SI</td>";
                 ca += "<td align='right'>"+si+"</td>";
                 ca += "</tr>";
             }

             ca += "<tr>";
             ca += "<td align='center'>NO</td>";
             ca += "<td align='right'>" + (datos.Rows.Count - si) + "</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>TOTAL FORMULARIOS DILIGENCIADOS</th>";
             ca += "<td align='right' style='font-weight:bold;'>" + datos.Rows.Count + " / 3386</td>";
             ca += "</tr>";
             ca += "</table>";
         }
         //lblResultado.Text = ca;
         return ca;
     }

     protected void btnParticipoProyectosInvestifacionDinstitucion_Click(object sender, EventArgs e)
     {
         //ParticipoProyectosInvestifacionDinstitucion();
         //btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string ParticipoProyectosInvestifacionDinstitucion()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable datos = lb.formulariosxRespondiente("6", "0", "5");
         if (datos != null && datos.Rows.Count > 0)
         {
             int si = 0;

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Participo en grupos de investigación dentro de la institución</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Participación</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";

             for (int i = 0; i < datos.Rows.Count; i++)
             {
                 if (datos.Rows[i]["respuesta"].ToString() == "Si")
                 {
                     si++;
                 }
             }

             if (si == 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>SI</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>SI</td>";
                 ca += "<td align='right'>" + si + "</td>";
                 ca += "</tr>";
             }

             ca += "<tr>";
             ca += "<td align='center'>NO</td>";
             ca += "<td align='right'>" + (datos.Rows.Count - si) + "</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>TOTAL FORMULARIOS DILIGENCIADOS</th>";
             ca += "<td align='right' style='font-weight:bold;'>" + datos.Rows.Count + " / 3386</td>";
             ca += "</tr>";
             ca += "</table>";
         }
         //lblResultado.Text = ca;
         return ca;
     }

     protected void btnModalidadProyectoDinstitucion_Click(object sender, EventArgs e)
     {
         //cargarModalidadProyectoDinstitucion();
         //btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarModalidadProyectoDinstitucion()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable datos = lb.formulariosxRespondiente("6", "1", "5");

         if (datos != null && datos.Rows.Count > 0)
         {
             int deaula = 0;
             int transversales = 0;
             int interdiciplinarios = 0;

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Modalidad de proyectos dentro de la institución</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Modalidad</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";

             for (int i = 0; i < datos.Rows.Count; i++)
             {
                 if (datos.Rows[i]["respuesta"].ToString() == "De aula")
                 {
                     deaula++;
                 }


                 if (datos.Rows[i]["respuesta"].ToString() == "Transversales")
                 {
                     transversales++;
                 }


                 if (datos.Rows[i]["respuesta"].ToString() == "Interdisciplinarios")
                 {
                     interdiciplinarios++;
                 }
                     
             }

             if(deaula == 0)
             {
                 ca += "<tr>";
                 ca += "<td align=''>De aula</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align=''>De aula</td>";
                 ca += "<td align='right'>"+deaula+"</td>";
                 ca += "</tr>";
             }
             if (transversales == 0)
             {
                 ca += "<tr>";
                 ca += "<td align=''>Transversales</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align=''>Transversales</td>";
                 ca += "<td align='right'>" + transversales + "</td>";
                 ca += "</tr>";
             }
             if (interdiciplinarios == 0)
             {
                 ca += "<tr>";
                 ca += "<td align=''>Interdisciplinarios</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align=''>Interdisciplinarios</td>";
                 ca += "<td align='right'>" + interdiciplinarios + "</td>";
                 ca += "</tr>";
             }
             ca += "<th>TOTAL FORMULARIOS DILIGENCIADOS</th>";
             ca += "<td align='right' style='font-weight:bold;'>" + datos.Rows.Count + " / 3386</td>";
             ca += "</tr>";
             ca += "</table>";
         }
         //lblResultado.Text = ca;
         return ca;
     }

    
     protected void btnFormulariosRespondidosxMunicipio_Click(object sender, EventArgs e)
     {
         cargarFormulariosRespondidosxMunicipio();
         btnExportExcel.Visible = true;
     }

     private void cargarFormulariosRespondidosxMunicipio()
     {

     }

     protected void btnFormulariosRespondidoxDocente_Click(object sender, EventArgs e)
     {
         cargarFormularioRespondidoxDocente();
         btnExportExcel.Visible = true;
     }

     private void cargarFormularioRespondidoxDocente()
     {
         string ca = "";
         DataTable datos = lb.formularioRespondidoxDocente("4", "0");
     }



    //Estudiantes

     protected void btnPerfilEstudiante_Click(object sender, EventArgs e)
     {
         //btnEstudiantesMujeres.Visible = true;
         //btnEstudiantesconDiscapacidad.Visible = true;
         //btnEstudiantesPertenecientesGrupoEtnico.Visible = true;
         //btnEstudianteVictimaConflicto.Visible = true;
     }

     protected void btnEstudiantesMujeres_Click(object sender, EventArgs e)
     {
         //totalEstudiantesMujeres();
         //btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string totalEstudiantesMujeres()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataRow datos = lb.numeroEstudiantesMujeres();

         if (datos != null)
         {
             //ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Numero de estudiantes mujeres</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th></th>";
             ca += "<th>Total</th>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<td align=''>Mujeres</td>";
             ca += "<td align='right'>" + datos["tmujer"].ToString() + "</td>";
             ca += "</tr>";
             //ca += "</table>";
         }
         return ca;
         //lblResultado.Text = ca;
     }

     protected void btnEstudiantesconDiscapacidad_Click(object sender, EventArgs e)
     {
         //EstudiantesconDiscapacidad();
         //btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string EstudiantesconDiscapacidad()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable datos = lb.numeroEstudiantesConDiscapacidad("Integrados");
         DataTable datos2 = lb.numeroEstudiantesConDiscapacidad("No Integrados");
        
        int total_i= 0;
        int total_ni= 0;

        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Numero estudiantes con capacidad excepcional o discapacidad</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Capacidad excepcional o discapacidad</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";
            ca += "<td colspan='2' style='font-weight:bold;text-align:center;'>Integradas</td>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + datos.Rows[i]["categoria"].ToString() + "</td>";
                //ca += "<td>" + datos.Rows[i]["subcategoria"].ToString() + "</td>";
                ca += "<td align='right'>" + datos.Rows[i]["sum"].ToString() + "</td>";
                ca += "</tr>";
                total_i += Convert.ToInt32(datos.Rows[i]["sum"].ToString());
            }
            ca += "<th>TOTAL</th>";
            ca += "<td align='right' style='font-weight:bold;'>" + total_i + "</td>";
            ca += "</tr>";
        }

        if (datos2 != null && datos2.Rows.Count > 0)
        {
            ca += "<td colspan='3' style='font-weight:bold;text-align:center;'>No Integradas</td>";
            for (int i = 0; i < datos2.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + datos2.Rows[i]["categoria"].ToString() + "</td>";
                //ca += "<td>" + datos2.Rows[i]["subcategoria"].ToString() + "</td>";
                ca += "<td align='right'>" + datos2.Rows[i]["sum"].ToString() + "</td>";
                ca += "</tr>";
                total_ni += Convert.ToInt32(datos2.Rows[i]["sum"].ToString());
            }
            ca += "<th>TOTAL</th>";
            ca += "<td align='right' style='font-weight:bold;'>" + total_ni + "</td>";
            ca += "</tr>";
        }
        ca += "</table>";
         //if (datos != null && datos.Rows.Count > 0)
         //{
         //    int total_i = 0;
         //    int total_ni = 0;
             //int auditiva1 = 0;
             //int visual1 = 0;
             //int motora1 = 0;
             //int cognitiva1 = 0;
             //int autismo1 = 0;
             //int multiple1 = 0;
             //int otra1 = 0;

             //int auditiva2 = 0;
             //int visual2 = 0;
             //int motora2 = 0;
             //int cognitiva2 = 0;
             //int autismo2 = 0;
             //int multiple2 = 0;
             //int otra2 = 0;

             //ca += "<table class='mGridTesoreria'>";
             //ca += "<tr>";
             //ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Numero estudiantes con capacidad excepcional o discapacidad</td>";
             //ca += "</tr>";
             //ca += "<tr>";
             //ca += "<th>Capacidad excepcional o discapacidad</th>";
             //ca += "<th>Total</th>";
             //ca += "</tr>";

             //for (int i = 0; i < datos.Rows.Count; i++)
             //{
             //    switch (datos.Rows[i]["subcategoria"].ToString())
             //    {
             //        case "Integrados":
             //            ca += "<tr>";
             //            ca += "<td>" + datos.Rows[i]["categoria"].ToString() + "</td>";
             //            ca += "<td>" + datos.Rows[i]["subcategoria"].ToString() + "</td>";
             //            ca += "<td>" + datos.Rows[i]["sum"].ToString() + "</td>";
             //            ca += "</tr>";
             //            total_i += Convert.ToInt32(datos.Rows[i]["sum"].ToString());

                        
             //            break;
             //       case "No Integrados":
             //            ca += "<tr>";
             //            ca += "<td>" + datos.Rows[i]["categoria"].ToString() + "</td>";
             //            ca += "<td>" + datos.Rows[i]["subcategoria"].ToString() + "</td>";
             //            ca += "<td>" + datos.Rows[i]["sum"].ToString() + "</td>";
             //            ca += "</tr>";
             //            total_ni += Convert.ToInt32(datos.Rows[i]["sum"].ToString());

             //            ca += "<th>TOTAL</th>";
             //            ca += "<td align='right' style='font-weight:bold;'>" + total_ni + "</td>";
             //            ca += "</tr>";
             //            break;
             //    }
                 

             //    if (datos.Rows[i]["subcategoria"].ToString() == "Integrados")
             //    {
             //        if (datos.Rows[i]["categoria"].ToString() == "Auditiva")
             //        {
             //            auditiva1++;
             //        }
             //        if (datos.Rows[i]["categoria"].ToString() == "Visual")
             //        {
             //            visual1++;
             //        }
             //        if (datos.Rows[i]["categoria"].ToString() == "Motora")
             //        {
             //            motora1++;
             //        }
             //        if (datos.Rows[i]["categoria"].ToString() == "Cognitiva")
             //        {
             //            cognitiva1++;
             //        }
             //        if (datos.Rows[i]["categoria"].ToString() == "Autismo")
             //        {
             //            autismo1++;
             //        }
             //        if (datos.Rows[i]["categoria"].ToString() == "Múltiple")
             //        {
             //            multiple1++;
             //        }
             //        if (datos.Rows[i]["categoria"].ToString() == "Otra")
             //        {
             //            otra1++;
             //        }
             //    }

             //    if (datos.Rows[i]["subcategoria"].ToString() == "No Integrados")
             //    {
             //        if (datos.Rows[i]["categoria"].ToString() == "Auditiva")
             //        {
             //            auditiva2++;
             //        }
             //        if (datos.Rows[i]["categoria"].ToString() == "Visual")
             //        {
             //            visual2++;
             //        }
             //        if (datos.Rows[i]["categoria"].ToString() == "Motora")
             //        {
             //            motora2++;
             //        }
             //        if (datos.Rows[i]["categoria"].ToString() == "Cognitiva")
             //        {
             //            cognitiva2++;
             //        }
             //        if (datos.Rows[i]["categoria"].ToString() == "Autismo")
             //        {
             //            autismo2++;
             //        }
             //        if (datos.Rows[i]["categoria"].ToString() == "Múltiple")
             //        {
             //            multiple2++;
             //        }
             //        if (datos.Rows[i]["categoria"].ToString() == "Otra")
             //        {
             //            otra2++;
             //        }
             //    }
             //}

             //if (auditiva1 == 0)
             //{
             //    ca += "<tr>";
             //    ca += "<td colspan ='2' style='text-align:center;font-weight:bold;'>Integrados</td>";
             //    ca += "</tr>";
             //    ca += "<tr>";
             //    ca += "<td align=''>Auditiva</td>";
             //    ca += "<td align='right'>0</td>";
             //    ca += "</tr>";
             //}
             //else
             //{
             //    ca += "<tr>";
             //    ca += "<td colspan ='2' style='text-align:center;font-weight:bold;'>Integrados</td>";
             //    ca += "</tr>";
             //    ca += "<tr>";
             //    ca += "<td align=''>Auditiva</td>";
             //    ca += "<td align='right'>" + auditiva1 + "</td>";
             //    ca += "</tr>";
             //}

             //if (visual1 == 0)
             //{
             //    ca += "<tr>";
             //    ca += "<td align=''>Visual</td>";
             //    ca += "<td align='right'>0</td>";
             //    ca += "</tr>";
             //}
             //else
             //{
             //    ca += "<tr>";
             //    ca += "<td align=''>Visual</td>";
             //    ca += "<td align='right'>"+visual1+"</td>";
             //    ca += "</tr>";
             //}
             //if (motora1 == 0)
             //{
             //    ca += "<tr>";
             //    ca += "<td align=''>Notora</td>";
             //    ca += "<td align='right'>0</td>";
             //    ca += "</tr>";
             //}
             //else
             //{
             //    ca += "<tr>";
             //    ca += "<td align=''>Motora</td>";
             //    ca += "<td align='right'>" + motora1 + "</td>";
             //    ca += "</tr>";
             //}
             //if (cognitiva1 == 0)
             //{
             //    ca += "<tr>";
             //    ca += "<td align=''>Cognitiva</td>";
             //    ca += "<td align='right'>0</td>";
             //    ca += "</tr>";
             //}
             //else
             //{
             //    ca += "<tr>";
             //    ca += "<td align=''>Cognitiva</td>";
             //    ca += "<td align='right'>" + cognitiva1 + "</td>";
             //    ca += "</tr>";
             //}
             //if (autismo1 == 0)
             //{
             //    ca += "<tr>";
             //    ca += "<td align=''>Autismo</td>";
             //    ca += "<td align='right'>0</td>";
             //    ca += "</tr>";
             //}
             //else
             //{
             //    ca += "<tr>";
             //    ca += "<td align=''>Autismo</td>";
             //    ca += "<td align='right'>" + autismo1 + "</td>";
             //    ca += "</tr>";
             //}
             //if (multiple1 == 0)
             //{
             //    ca += "<tr>";
             //    ca += "<td align=''>Múltiple</td>";
             //    ca += "<td align='right'>0</td>";
             //    ca += "</tr>";
             //}
             //else
             //{
             //    ca += "<tr>";
             //    ca += "<td align=''>Múltiple</td>";
             //    ca += "<td align='right'>" + multiple1 + "</td>";
             //    ca += "</tr>";
             //}
             //if (otra1 == 0)
             //{
             //    ca += "<tr>";
             //    ca += "<td align=''>Otra</td>";
             //    ca += "<td align='right'>0</td>";
             //    ca += "</tr>";
             //}
             //else
             //{
             //    ca += "<tr>";
             //    ca += "<td align=''>Otra</td>";
             //    ca += "<td align='right'>" + otra1 + "</td>";
             //    ca += "</tr>";
             //}
             //ca += "<th>TOTAL</th>";
             //ca += "<td align='right' style='font-weight:bold;'>" + (auditiva1+visual1+motora1+cognitiva1+autismo1+multiple1+otra1) + "</td>";
             //ca += "</tr>";


             //if (auditiva2 == 0)
             //{
             //    ca += "<tr>";
             //    ca += "<td colspan ='2' style='text-align:center;font-weight:bold;'>No Integrados</td>";
             //    ca += "</tr>";
             //    ca += "<tr>";
             //    ca += "<td align=''>Auditiva</td>";
             //    ca += "<td align='right'>0</td>";
             //    ca += "</tr>";
             //}
             //else
             //{
             //    ca += "<tr>";
             //    ca += "<td colspan ='2' style='text-align:center;font-weight:bold;'>No Integrados</td>";
             //    ca += "</tr>";
             //    ca += "<tr>";
             //    ca += "<td align=''>Auditiva</td>";
             //    ca += "<td align='right'>" + auditiva2 + "</td>";
             //    ca += "</tr>";
             //}

             //if (visual2 == 0)
             //{
             //    ca += "<tr>";
             //    ca += "<td align=''>Visual</td>";
             //    ca += "<td align='right'>0</td>";
             //    ca += "</tr>";
             //}
             //else
             //{
             //    ca += "<tr>";
             //    ca += "<td align=''>Visual</td>";
             //    ca += "<td align='right'>" + visual2 + "</td>";
             //    ca += "</tr>";
             //}
             //if (motora2 == 0)
             //{
             //    ca += "<tr>";
             //    ca += "<td align=''>Notora</td>";
             //    ca += "<td align='right'>0</td>";
             //    ca += "</tr>";
             //}
             //else
             //{
             //    ca += "<tr>";
             //    ca += "<td align=''>Motora</td>";
             //    ca += "<td align='right'>" + motora2 + "</td>";
             //    ca += "</tr>";
             //}
             //if (cognitiva2 == 0)
             //{
             //    ca += "<tr>";
             //    ca += "<td align=''>Cognitiva</td>";
             //    ca += "<td align='right'>0</td>";
             //    ca += "</tr>";
             //}
             //else
             //{
             //    ca += "<tr>";
             //    ca += "<td align=''>Cognitiva</td>";
             //    ca += "<td align='right'>" + cognitiva2 + "</td>";
             //    ca += "</tr>";
             //}
             //if (autismo2 == 0)
             //{
             //    ca += "<tr>";
             //    ca += "<td align=''>Autismo</td>";
             //    ca += "<td align='right'>0</td>";
             //    ca += "</tr>";
             //}
             //else
             //{
             //    ca += "<tr>";
             //    ca += "<td align=''>Autismo</td>";
             //    ca += "<td align='right'>" + autismo2 + "</td>";
             //    ca += "</tr>";
             //}
             //if (multiple2 == 0)
             //{
             //    ca += "<tr>";
             //    ca += "<td align=''>Múltiple</td>";
             //    ca += "<td align='right'>0</td>";
             //    ca += "</tr>";
             //}
             //else
             //{
             //    ca += "<tr>";
             //    ca += "<td align=''>Múltiple</td>";
             //    ca += "<td align='right'>" + multiple2 + "</td>";
             //    ca += "</tr>";
             //}
             //if (otra2 == 0)
             //{
             //    ca += "<tr>";
             //    ca += "<td align=''>Otra</td>";
             //    ca += "<td align='right'>0</td>";
             //    ca += "</tr>";
             //}
             //else
             //{
             //    ca += "<tr>";
             //    ca += "<td align=''>Otra</td>";
             //    ca += "<td align='right'>" + otra2 + "</td>";
             //    ca += "</tr>";
            // }
            
             //ca += "</table>";
        // }
         //lblResultado.Text = ca;
         return ca;
     }

     protected void btnEstudiantesPertenecientesGrupoEtnico_Click(object sender, EventArgs e)
     {
         //cargarEstudiantexGrupoEtnico();
         //btnExportExcel.Visible = true;
     }

    [WebMethod(EnableSession = true)]
     public static string cargarEstudiantexGrupoEtnico()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable datos = lb.numeroEstudianteGrupoEtnico();

         if (datos != null && datos.Rows.Count > 0)
         {
             int indigenas1 = 0;
             int rom1 = 0;
             int afro1 = 0;
             int raizal1 = 0;
             int palenquero1 = 0;

             //int indigenas2 = 0;
             //int rom2 = 0;
             //int afro2 = 0;
             //int raizal2 = 0;
             //int palenquero2 = 0;

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Numero estudiantes pertenecientes a un grupo etnico</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Grupo Etnico</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";

             for (int i = 0; i < datos.Rows.Count; i++)
             {
                 if (datos.Rows[i]["categoria"].ToString() == "Indígenas")
                 {
                     indigenas1 = (indigenas1 + Int32.Parse(datos.Rows[i]["total"].ToString()));
                 }

                 if (datos.Rows[i]["categoria"].ToString() == "Rom (gitanos)")
                 {
                     rom1 += Int32.Parse(datos.Rows[i]["total"].ToString());
                 }

                 if (datos.Rows[i]["categoria"].ToString() == "Afrocolombianos, afrodecendientes, negro o mulato.")
                 {
                     afro1 += Int32.Parse(datos.Rows[i]["total"].ToString());
                 }

                 if (datos.Rows[i]["categoria"].ToString() == "Raizal del archipiélago de San Andrés, Providencia y Santa Catalina")
                 {
                     raizal1 += Int32.Parse(datos.Rows[i]["total"].ToString());
                 }

                 if (datos.Rows[i]["categoria"].ToString() == "Palenquero de San Basilio")
                 {
                     palenquero1 += Int32.Parse(datos.Rows[i]["total"].ToString());
                 }
             }

             if (indigenas1 == 0)
             {
                 ca += "<tr>";
                 ca += "<td align=''>Indígenas</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align=''>Indígenas</td>";
                 ca += "<td align='right'>" + indigenas1 + "</td>";
                 ca += "</tr>";
             }
             if (rom1 == 0)
             {
                 ca += "<tr>";
                 ca += "<td align=''>Rom (gitanos)</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align=''>Rom (gitanos)</td>";
                 ca += "<td align='right'>" + rom1 + "</td>";
                 ca += "</tr>";
             }
             if (afro1 == 0)
             {
                 ca += "<tr>";
                 ca += "<td align=''>Afrocolombianos, afrodecendientes, negro o mulato.</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align=''>Afrocolombianos, afrodecendientes, negro o mulato.</td>";
                 ca += "<td align='right'>" + afro1 + "</td>";
                 ca += "</tr>";
             }
             if (raizal1 == 0)
             {
                 ca += "<tr>";
                 ca += "<td align=''>Raizal del archipiélago de San Andrés, Providencia y Santa Catalina</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align=''>Raizal del archipiélago de San Andrés, Providencia y Santa Catalina</td>";
                 ca += "<td align='right'>" + raizal1 + "</td>";
                 ca += "</tr>";
             }
             if (palenquero1 == 0)
             {
                 ca += "<tr>";
                 ca += "<td align=''>Palenquero de San Basilio</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align=''>Palenquero de San Basilio</td>";
                 ca += "<td align='right'>" + palenquero1 + "</td>";
                 ca += "</tr>";
             }

             ca += "</table>";
         }
         //lblResultado.Text = ca;
         return ca;
     }

     protected void btnEstudianteVictimaConflicto_Click(object sender, EventArgs e)
     {
         cargarEstudianteVictimaConflicto();
         btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarEstudianteVictimaConflicto()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable datos = lb.numeroEstudianteVictimasConflicto();

         if (datos != null && datos.Rows.Count > 0)
         {
             int desplazamiento = 0;
             int desmovilizados = 0;
             int desvinculados = 0;

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Numero estudiantes victimas del conflicto</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Categoria</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";

             for (int i = 0; i < datos.Rows.Count; i++)
             {
                 if (datos.Rows[i]["categoria"].ToString() == "En situación de desplazamiento")
                 {
                     desplazamiento += Int32.Parse(datos.Rows[i]["total"].ToString());
                 }
                 if (datos.Rows[i]["categoria"].ToString() == "Hijos de adultos desmovilizados")
                 {
                     desmovilizados += Int32.Parse(datos.Rows[i]["total"].ToString());
                 }
                 if (datos.Rows[i]["categoria"].ToString() == "Desvinculados de organizaciones armadas al margen de la Ley")
                 {
                     desvinculados += Int32.Parse(datos.Rows[i]["total"].ToString());
                 }
             }

             if (desplazamiento == 0)
             {
                 ca += "<tr>";
                 ca += "<td align=''>En situación de desplazamiento</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align=''>En situación de desplazamiento</td>";
                 ca += "<td align='right'>"+desplazamiento+"</td>";
                 ca += "</tr>";
             }

             if (desmovilizados == 0)
             {
                 ca += "<tr>";
                 ca += "<td align=''>Hijos de adultos desmovilizados</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align=''>Hijos de adultos desmovilizados</td>";
                 ca += "<td align='right'>" + desmovilizados + "</td>";
                 ca += "</tr>";
             }

             if (desvinculados == 0)
             {
                 ca += "<tr>";
                 ca += "<td align=''>Desvinculados de organizaciones armadas al margen de la Ley</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align=''>Desvinculados de organizaciones armadas al margen de la Ley</td>";
                 ca += "<td align='right'>" + desvinculados + "</td>";
                 ca += "</tr>";
             }

             ca += "</table>";
         }

         //lblResultado.Text = ca;
         return ca;
     }

    //Autopercepcion Formularios por municipios docente
     protected void btnAutoPercepcionDocente_Click(object sender, EventArgs e)
     {
         //btnFormulariosxMunicipioAutopercepcion.Visible = true;
         ////btnSedesxMunicipioAutopercepcion.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo1.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo2.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo3.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo4.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo5.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo6.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo7.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo8.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo9.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo10.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo11.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo12.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo13.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo14.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo15.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo16.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo17.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo18.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo19.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo20.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo21.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo22.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo23.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo24.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo25.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo26.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo27.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo28.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo29.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo30.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo41.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo42.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo43.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo44.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo45.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo46.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo47.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo48.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo49.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo50.Visible = true;
         //btnAutoPercepcionDocentePreguntaNo51.Visible = true;

         //btnExportExcel.Visible = true;
     }

     protected void btnAutoPercepcionDocentePreguntaNo1_Click(object sender, EventArgs e)
     {
         //cargarAutoPercepcionDocentePreguntaNo1();
         //btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarAutoPercepcionDocentePreguntaNo1()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
         if(docentes != null && docentes.Rows.Count  > 0)
         {
             int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for(int i = 0; i < docentes.Rows.Count; i++)
            {
                    DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "1", "0", "4", "0");
                    if (respuestas != null && respuestas.Rows.Count > 0)
                    {
                        for (int k = 0; k < respuestas.Rows.Count; k++)
                        {
                            if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                            {
                                respuestaNo1++;
                            }
                            else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                            {
                                respuestaNo2++;
                            }
                            else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                            {
                                respuestaNo3++;
                            }
                            else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                            {
                                respuestaNo4++;
                            }
                            else
                            {
                                respuestaNo5++;
                            }
                        }
                    }
             
            }

            //ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 1: Identifico las características, usos y oportunidades que ofrecen herramientas tecnológicas y medios audiovisuales, en los procesos educativos </td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

             if(respuestaNo1 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>" + respuestaNo1 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo2 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>" + respuestaNo2 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo3 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>" + respuestaNo3 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo4 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>" + respuestaNo4 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo5 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>" + respuestaNo5 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             
            ////lblResultado.Text = ca;
         }
        return ca;
        
     }

     protected void btnAutoPercepcionDocentePreguntaNo2_Click(object sender, EventArgs e)
     {
         //cargarAutoPercepcionDocentePreguntaNo2();
         //btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarAutoPercepcionDocentePreguntaNo2()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
         if (docentes != null && docentes.Rows.Count > 0)
         {
             int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
             for (int i = 0; i < docentes.Rows.Count; i++)
             {
                 DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "1", "0", "4", "1");
                 if (respuestas != null && respuestas.Rows.Count > 0)
                 {
                     for (int k = 0; k < respuestas.Rows.Count; k++)
                     {
                         if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                         {
                             respuestaNo1++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                         {
                             respuestaNo2++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                         {
                             respuestaNo3++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                         {
                             respuestaNo4++;
                         }
                         else
                         {
                             respuestaNo5++;
                         }
                     }
                 }

             }

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 2: Elaboro actividades de aprendizaje utilizando aplicativos, contenidos, herramientas informáticas y medios audiovisuales </td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Respuestas</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";

             if (respuestaNo1 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>" + respuestaNo1 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo2 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>" + respuestaNo2 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo3 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>" + respuestaNo3 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo4 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>" + respuestaNo4 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo5 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>" + respuestaNo5 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             
             ////lblResultado.Text = ca;
         }
        return ca;
     }

     protected void btnAutoPercepcionDocentePreguntaNo3_Click(object sender, EventArgs e)
     {
         //cargarAutoPercepcionDocentePreguntaNo3();
         //btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarAutoPercepcionDocentePreguntaNo3()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
         if (docentes != null && docentes.Rows.Count > 0)
         {
             int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
             for (int i = 0; i < docentes.Rows.Count; i++)
             {
                 DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "1", "0", "4", "2");
                 if (respuestas != null && respuestas.Rows.Count > 0)
                 {
                     for (int k = 0; k < respuestas.Rows.Count; k++)
                     {
                         if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                         {
                             respuestaNo1++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                         {
                             respuestaNo2++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                         {
                             respuestaNo3++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                         {
                             respuestaNo4++;
                         }
                         else
                         {
                             respuestaNo5++;
                         }
                     }
                 }

             }

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 3: Evalúo la calidad, pertinencia y veracidad de la información disponible en diversos medios como portales educativos y especializados, motores de búsqueda y material </td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Respuestas</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";

             if (respuestaNo1 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>" + respuestaNo1 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo2 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>" + respuestaNo2 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo3 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>" + respuestaNo3 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo4 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>" + respuestaNo4 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo5 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>" + respuestaNo5 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             ////lblResultado.Text = ca;
         }
         return ca;
     }

     protected void btnAutoPercepcionDocentePreguntaNo4_Click(object sender, EventArgs e)
     {
         //cargarAutoPercepcionDocentePreguntaNo4();
         //btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarAutoPercepcionDocentePreguntaNo4()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
         if (docentes != null && docentes.Rows.Count > 0)
         {
             int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
             for (int i = 0; i < docentes.Rows.Count; i++)
             {
                 DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "2", "0", "4", "0");
                 if (respuestas != null && respuestas.Rows.Count > 0)
                 {
                     for (int k = 0; k < respuestas.Rows.Count; k++)
                     {
                         if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                         {
                             respuestaNo1++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                         {
                             respuestaNo2++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                         {
                             respuestaNo3++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                         {
                             respuestaNo4++;
                         }
                         else
                         {
                             respuestaNo5++;
                         }
                     }
                 }

             }

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 4: Combino una amplia variedad de herramientas tecnológicas para mejorar la planeación e implementación de mis prácticas educativas </td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Respuestas</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";

             if (respuestaNo1 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>" + respuestaNo1 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo2 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>" + respuestaNo2 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo3 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>" + respuestaNo3 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo4 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>" + respuestaNo4 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo5 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>" + respuestaNo5 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             ////lblResultado.Text = ca;
         }
         return ca;
     }

     protected void btnAutoPercepcionDocentePreguntaNo5_Click(object sender, EventArgs e)
     {
         //cargarAutoPercepcionDocentePreguntaNo5();
         //btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarAutoPercepcionDocentePreguntaNo5()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
         if (docentes != null && docentes.Rows.Count > 0)
         {
             int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
             for (int i = 0; i < docentes.Rows.Count; i++)
             {
                 DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "2", "0", "4", "1");
                 if (respuestas != null && respuestas.Rows.Count > 0)
                 {
                     for (int k = 0; k < respuestas.Rows.Count; k++)
                     {
                         if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                         {
                             respuestaNo1++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                         {
                             respuestaNo2++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                         {
                             respuestaNo3++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                         {
                             respuestaNo4++;
                         }
                         else
                         {
                             respuestaNo5++;
                         }
                     }
                 }

             }

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 5: Diseño y publico contenidos digitales u objetos virtuales de aprendizaje mediante el uso adecuado de herramientas tecnológicas. </td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Respuestas</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";

             if (respuestaNo1 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>" + respuestaNo1 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo2 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>" + respuestaNo2 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo3 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>" + respuestaNo3 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo4 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>" + respuestaNo4 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo5 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>" + respuestaNo5 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             ////lblResultado.Text = ca;
         }
         return ca;
     }

     protected void btnAutoPercepcionDocentePreguntaNo6_Click(object sender, EventArgs e)
     {
         //cargarAutoPercepcionDocentePreguntaNo6();
         //btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarAutoPercepcionDocentePreguntaNo6()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
         if (docentes != null && docentes.Rows.Count > 0)
         {
             int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
             for (int i = 0; i < docentes.Rows.Count; i++)
             {
                 DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "2", "0", "4", "2");
                 if (respuestas != null && respuestas.Rows.Count > 0)
                 {
                     for (int k = 0; k < respuestas.Rows.Count; k++)
                     {
                         if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                         {
                             respuestaNo1++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                         {
                             respuestaNo2++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                         {
                             respuestaNo3++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                         {
                             respuestaNo4++;
                         }
                         else
                         {
                             respuestaNo5++;
                         }
                     }
                 }

             }

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 6: Analizo los riesgos y potencialidades de publicar y compartir distintos tipos de información a través de Internet </td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Respuestas</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";

             if (respuestaNo1 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>" + respuestaNo1 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo2 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>" + respuestaNo2 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo3 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>" + respuestaNo3 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo4 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>" + respuestaNo4 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo5 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>" + respuestaNo5 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }
             
             ////lblResultado.Text = ca;
         }
         return ca;
     }

     protected void btnAutoPercepcionDocentePreguntaNo7_Click(object sender, EventArgs e)
     {
         cargarAutoPercepcionDocentePreguntaNo7();
         btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarAutoPercepcionDocentePreguntaNo7()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
         if (docentes != null && docentes.Rows.Count > 0)
         {
             int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
             for (int i = 0; i < docentes.Rows.Count; i++)
             {
                 DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "3", "0", "4", "0");
                 if (respuestas != null && respuestas.Rows.Count > 0)
                 {
                     for (int k = 0; k < respuestas.Rows.Count; k++)
                     {
                         if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                         {
                             respuestaNo1++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                         {
                             respuestaNo2++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                         {
                             respuestaNo3++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                         {
                             respuestaNo4++;
                         }
                         else
                         {
                             respuestaNo5++;
                         }
                     }
                 }

             }

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 7: Utilizo herramientas tecnológicas complejas o especializadas para diseñar ambientes virtuales de aprendizaje que favorecen el desarrollo de competencias en mis estudiantes y la conformación de comunidades y/o redes de aprendizaje </td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Respuestas</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";

             if (respuestaNo1 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>" + respuestaNo1 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo2 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>" + respuestaNo2 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo3 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>" + respuestaNo3 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo4 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>" + respuestaNo4 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo5 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>" + respuestaNo5 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             //lblResultado.Text = ca;
         }
         return ca;
     }

     protected void btnAutoPercepcionDocentePreguntaNo8_Click(object sender, EventArgs e)
     {
         cargarAutoPercepcionDocentePreguntaNo8();
         btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarAutoPercepcionDocentePreguntaNo8()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
         if (docentes != null && docentes.Rows.Count > 0)
         {
             int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
             for (int i = 0; i < docentes.Rows.Count; i++)
             {
                 DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "3", "0", "4", "1");
                 if (respuestas != null && respuestas.Rows.Count > 0)
                 {
                     for (int k = 0; k < respuestas.Rows.Count; k++)
                     {
                         if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                         {
                             respuestaNo1++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                         {
                             respuestaNo2++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                         {
                             respuestaNo3++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                         {
                             respuestaNo4++;
                         }
                         else
                         {
                             respuestaNo5++;
                         }
                     }
                 }

             }

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 8: Utilizo herramientas tecnológicas para ayudar a mis estudiantes a construir aprendizajes significativos y desarrollar pensamiento crítico</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Respuestas</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";

             if (respuestaNo1 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>" + respuestaNo1 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo2 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>" + respuestaNo2 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo3 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>" + respuestaNo3 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo4 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>" + respuestaNo4 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo5 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>" + respuestaNo5 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             //lblResultado.Text = ca;
         }
         return ca;
     }

     protected void btnAutoPercepcionDocentePreguntaNo9_Click(object sender, EventArgs e)
     {
         cargarAutoPercepcionDocentePreguntaNo9();
         btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarAutoPercepcionDocentePreguntaNo9()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
         if (docentes != null && docentes.Rows.Count > 0)
         {
             int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
             for (int i = 0; i < docentes.Rows.Count; i++)
             {
                 DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "3", "0", "4", "2");
                 if (respuestas != null && respuestas.Rows.Count > 0)
                 {
                     for (int k = 0; k < respuestas.Rows.Count; k++)
                     {
                         if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                         {
                             respuestaNo1++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                         {
                             respuestaNo2++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                         {
                             respuestaNo3++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                         {
                             respuestaNo4++;
                         }
                         else
                         {
                             respuestaNo5++;
                         }
                     }
                 }

             }

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 9: Aplico las normas de propiedad intelectual y licenciamiento existentes, referentes al uso de información ajena y propia</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Respuestas</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";

             if (respuestaNo1 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>" + respuestaNo1 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo2 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>" + respuestaNo2 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo3 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>" + respuestaNo3 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo4 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>" + respuestaNo4 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo5 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>" + respuestaNo5 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             //lblResultado.Text = ca;
         }
         return ca;
     }

     protected void btnAutoPercepcionDocentePreguntaNo10_Click(object sender, EventArgs e)
     {
         cargarAutoPercepcionDocentePreguntaNo10();
         btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarAutoPercepcionDocentePreguntaNo10()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
         if (docentes != null && docentes.Rows.Count > 0)
         {
             int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
             for (int i = 0; i < docentes.Rows.Count; i++)
             {
                 DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "4", "0", "4", "0");
                 if (respuestas != null && respuestas.Rows.Count > 0)
                 {
                     for (int k = 0; k < respuestas.Rows.Count; k++)
                     {
                         if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                         {
                             respuestaNo1++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                         {
                             respuestaNo2++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                         {
                             respuestaNo3++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                         {
                             respuestaNo4++;
                         }
                         else
                         {
                             respuestaNo5++;
                         }
                     }
                 }

             }

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 10: Utilizo las TIC para aprender por iniciativa personal y para actualizar los conocimientos y prácticas propios de mi disciplina</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Respuestas</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";

             if (respuestaNo1 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>" + respuestaNo1 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo2 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>" + respuestaNo2 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo3 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>" + respuestaNo3 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo4 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>" + respuestaNo4 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo5 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>" + respuestaNo5 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             //lblResultado.Text = ca;
         }
         return ca;
     }

     

     protected void btnAutoPercepcionDocentePreguntaNo11_Click(object sender, EventArgs e)
     {
         cargarAutoPercepcionDocentePreguntaNo11();
         btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarAutoPercepcionDocentePreguntaNo11()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
         if (docentes != null && docentes.Rows.Count > 0)
         {
             int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
             for (int i = 0; i < docentes.Rows.Count; i++)
             {
                 DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "4", "0", "4", "1");
                 if (respuestas != null && respuestas.Rows.Count > 0)
                 {
                     for (int k = 0; k < respuestas.Rows.Count; k++)
                     {
                         if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                         {
                             respuestaNo1++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                         {
                             respuestaNo2++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                         {
                             respuestaNo3++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                         {
                             respuestaNo4++;
                         }
                         else
                         {
                             respuestaNo5++;
                         }
                     }
                 }

             }

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 11: Identifico problemáticas educativas en mi práctica docente y las oportunidades, implicaciones y riesgos del uso de las TIC para atenderlas</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Respuestas</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";

             if (respuestaNo1 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>" + respuestaNo1 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo2 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>" + respuestaNo2 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo3 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>" + respuestaNo3 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo4 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>" + respuestaNo4 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo5 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>" + respuestaNo5 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             //lblResultado.Text = ca;
         }
         return ca;
     }

     protected void btnAutoPercepcionDocentePreguntaNo12_Click(object sender, EventArgs e)
     {
         cargarAutoPercepcionDocentePreguntaNo12();
         btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarAutoPercepcionDocentePreguntaNo12()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
         if (docentes != null && docentes.Rows.Count > 0)
         {
             int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
             for (int i = 0; i < docentes.Rows.Count; i++)
             {
                 DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "4", "0", "4", "2");
                 if (respuestas != null && respuestas.Rows.Count > 0)
                 {
                     for (int k = 0; k < respuestas.Rows.Count; k++)
                     {
                         if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                         {
                             respuestaNo1++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                         {
                             respuestaNo2++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                         {
                             respuestaNo3++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                         {
                             respuestaNo4++;
                         }
                         else
                         {
                             respuestaNo5++;
                         }
                     }
                 }

             }

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 12: Conozco una variedad de estrategias y metodologías apoyadas por las TIC, para planear y hacer seguimiento a mi labor docente</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Respuestas</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";

             if (respuestaNo1 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>" + respuestaNo1 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo2 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>" + respuestaNo2 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo3 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>" + respuestaNo3 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo4 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>" + respuestaNo4 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo5 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>" + respuestaNo5 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             //lblResultado.Text = ca;
         }
         return ca;
     }

     protected void btnAutoPercepcionDocentePreguntaNo13_Click(object sender, EventArgs e)
     {
         cargarAutoPercepcionDocentePreguntaNo13();
         btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarAutoPercepcionDocentePreguntaNo13()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
         if (docentes != null && docentes.Rows.Count > 0)
         {
             int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
             for (int i = 0; i < docentes.Rows.Count; i++)
             {
                 DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "5", "0", "4", "0");
                 if (respuestas != null && respuestas.Rows.Count > 0)
                 {
                     for (int k = 0; k < respuestas.Rows.Count; k++)
                     {
                         if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                         {
                             respuestaNo1++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                         {
                             respuestaNo2++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                         {
                             respuestaNo3++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                         {
                             respuestaNo4++;
                         }
                         else
                         {
                             respuestaNo5++;
                         }
                     }
                 }

             }

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 13: Incentivo en mis estudiantes el aprendizaje autónomo y el aprendizaje colaborativo apoyados por TIC</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Respuestas</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";

             if (respuestaNo1 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>" + respuestaNo1 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo2 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>" + respuestaNo2 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo3 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>" + respuestaNo3 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo4 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>" + respuestaNo4 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo5 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>" + respuestaNo5 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             //lblResultado.Text = ca;
         }
         return ca;
     }

     protected void btnAutoPercepcionDocentePreguntaNo14_Click(object sender, EventArgs e)
     {
         cargarAutoPercepcionDocentePreguntaNo14();
         btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarAutoPercepcionDocentePreguntaNo14()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
         if (docentes != null && docentes.Rows.Count > 0)
         {
             int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
             for (int i = 0; i < docentes.Rows.Count; i++)
             {
                 DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "5", "0", "4", "1");
                 if (respuestas != null && respuestas.Rows.Count > 0)
                 {
                     for (int k = 0; k < respuestas.Rows.Count; k++)
                     {
                         if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                         {
                             respuestaNo1++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                         {
                             respuestaNo2++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                         {
                             respuestaNo3++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                         {
                             respuestaNo4++;
                         }
                         else
                         {
                             respuestaNo5++;
                         }
                     }
                 }

             }

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 14: Utilizo TIC con mis estudiantes para atender sus necesidades e intereses y proponer soluciones a problemas de aprendizaje</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Respuestas</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";

             if (respuestaNo1 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>" + respuestaNo1 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo2 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>" + respuestaNo2 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo3 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>" + respuestaNo3 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo4 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>" + respuestaNo4 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo5 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>" + respuestaNo5 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             //lblResultado.Text = ca;
         }
         return ca;
     }

     protected void btnAutoPercepcionDocentePreguntaNo15_Click(object sender, EventArgs e)
     {
         cargarAutoPercepcionDocentePreguntaNo15();
         btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarAutoPercepcionDocentePreguntaNo15()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
         if (docentes != null && docentes.Rows.Count > 0)
         {
             int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
             for (int i = 0; i < docentes.Rows.Count; i++)
             {
                 DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "5", "0", "4", "2");
                 if (respuestas != null && respuestas.Rows.Count > 0)
                 {
                     for (int k = 0; k < respuestas.Rows.Count; k++)
                     {
                         if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                         {
                             respuestaNo1++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                         {
                             respuestaNo2++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                         {
                             respuestaNo3++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                         {
                             respuestaNo4++;
                         }
                         else
                         {
                             respuestaNo5++;
                         }
                     }
                 }

             }

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 15: Implemento estrategias didácticas mediadas por TIC, para fortalecer en mis estudiantes aprendizajes que les permitan resolver problemas de la vida real</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Respuestas</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";

             if (respuestaNo1 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>" + respuestaNo1 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo2 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>" + respuestaNo2 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo3 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>" + respuestaNo3 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo4 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>" + respuestaNo4 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo5 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>" + respuestaNo5 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             //lblResultado.Text = ca;
         }
         return ca;
     }

     protected void btnAutoPercepcionDocentePreguntaNo16_Click(object sender, EventArgs e)
     {
         cargarAutoPercepcionDocentePreguntaNo16();
         btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarAutoPercepcionDocentePreguntaNo16()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
         if (docentes != null && docentes.Rows.Count > 0)
         {
             int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
             for (int i = 0; i < docentes.Rows.Count; i++)
             {
                 DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "6", "0", "4", "0");
                 if (respuestas != null && respuestas.Rows.Count > 0)
                 {
                     for (int k = 0; k < respuestas.Rows.Count; k++)
                     {
                         if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                         {
                             respuestaNo1++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                         {
                             respuestaNo2++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                         {
                             respuestaNo3++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                         {
                             respuestaNo4++;
                         }
                         else
                         {
                             respuestaNo5++;
                         }
                     }
                 }

             }

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 16: Diseño ambientes de aprendizaje mediados por TIC de acuerdo con el desarrollo cognitivo, físico, psicológico y social de mis estudiantes para fomentar el desarrollo de sus competencias</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Respuestas</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";

             if (respuestaNo1 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>" + respuestaNo1 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo2 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>" + respuestaNo2 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo3 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>" + respuestaNo3 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo4 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>" + respuestaNo4 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo5 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>" + respuestaNo5 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             //lblResultado.Text = ca;
         }
         return ca;
     }

     

     protected void btnAutoPercepcionDocentePreguntaNo17_Click(object sender, EventArgs e)
     {
         cargarAutoPercepcionDocentePreguntaNo17();
         btnExportExcel.Visible = true;
     }
    [WebMethod(EnableSession = true)]
     public static string cargarAutoPercepcionDocentePreguntaNo17()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
         if (docentes != null && docentes.Rows.Count > 0)
         {
             int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
             for (int i = 0; i < docentes.Rows.Count; i++)
             {
                 DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "6", "0", "4", "1");
                 if (respuestas != null && respuestas.Rows.Count > 0)
                 {
                     for (int k = 0; k < respuestas.Rows.Count; k++)
                     {
                         if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                         {
                             respuestaNo1++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                         {
                             respuestaNo2++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                         {
                             respuestaNo3++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                         {
                             respuestaNo4++;
                         }
                         else
                         {
                             respuestaNo5++;
                         }
                     }
                 }

             }

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 17: Propongo proyectos educativos mediados con TIC, que permiten la reflexión sobre el aprendizaje propio y la producción de conocimiento</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Respuestas</th>";
             ca += "<th>Total</th>";
             ca += "</tr>";

             if (respuestaNo1 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>" + respuestaNo1 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>1</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo2 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>" + respuestaNo2 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>2</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo3 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>" + respuestaNo3 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>3</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo4 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>" + respuestaNo4 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>4</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             if (respuestaNo5 != 0)
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>" + respuestaNo5 + "</td>";
                 ca += "</tr>";
             }
             else
             {
                 ca += "<tr>";
                 ca += "<td align='center'>5</td>";
                 ca += "<td align='right'>0</td>";
                 ca += "</tr>";
             }

             //lblResultado.Text = ca;
         }
         return ca;
     }

    protected void btnAutoPercepcionDocentePreguntaNo18_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo18();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo18()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "6", "0", "4", "2");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 18: Evalúo los resultados obtenidos con la implementación de estrategias que hacen uso educativo de TIC y promuevo una cultura de seguimiento, retroalimentación y mejoramiento permanente</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo19_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo19();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo19()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "7", "0", "4", "0");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 19: Me comunico adecuadamente con mis estudiantes y sus familiares, mis colegas e investigadores usando TIC de manera sincrónica y asincrónica</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo20_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo20();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo20()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "7", "0", "4", "1");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 20: Navego eficientemente en Internet integrando fragmentos de información presentados de forma no lineal</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo21_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo21();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo21()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "7", "0", "4", "2");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 21: Evalúo la pertinencia de compartir información a través de canales públicos y masivos, respetando las normas de propiedad intelectual y licenciamiento</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }



    protected void btnAutoPercepcionDocentePreguntaNo22_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo22();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo22()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "8", "0", "4", "0");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 22: Participo activamente en redes y comunidades de práctica mediadas por TIC y facilito la participación de mis estudiantes en las mismas, de una forma pertinente y respetuosa</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo23_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo23();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo23()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "8", "0", "4", "1");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 23: Sistematizo y hago seguimiento a experiencias significativas de uso de TIC</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo24_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo24();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo24()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "8", "0", "4", "2");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 24: Promuevo en la comunidad educativa comunicaciones efectivas que aportan al mejoramiento de los procesos de convivencia escolar</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo25_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo25();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo25()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "9", "0", "4", "0");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 25: Utilizo variedad de textos e interfaces para transmitir información y expresar ideas propias combinando texto, audio, imágenes estáticas o dinámicas, videos y gestos</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo26_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo26();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo26()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "9", "0", "4", "1");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 26: Interpreto y produzco íconos, símbolos y otras formas de representación de la información, para ser utilizados con propósitos educativos</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo27_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo27();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo27()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "9", "0", "4", "2");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 27: Contribuyo con mis conocimientos y los de mis estudiantes a repositorios de la humanidad de Internet, con textos de diversa naturaleza</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo28_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo28();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo28()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "10", "0", "4", "0");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 28: Identifico los elementos de la gestión escolar que pueden ser mejorados con el uso de las TIC, en las diferentes actividades institucionales</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo29_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo29();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo29()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "10", "0", "4", "1");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 29: Conozco políticas escolares para el uso de las TIC que contemplan la privacidad, el impacto ambiental y la salud de los usuarios</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo30_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo30();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo30()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "10", "0", "4", "2");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 30: Identifico mis necesidades de desarrollo profesional para la innovación educativa con TIC</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo31_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo31();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo31()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "11", "0", "4", "0");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 31: Propongo y desarrollo procesos de mejoramiento y seguimiento del uso de TIC en la gestión escolar</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo32_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo32();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo32()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "11", "0", "4", "0");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 32: Adopto políticas escolares existentes para el uso de las TIC en mi institución que contemplan la privacidad, el impacto ambiental y la salud de los usuarios</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo33_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo33();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo33()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "11", "0", "4", "1");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 33: Adopto políticas escolares existentes para el uso de las TIC en mi institución que contemplan la privacidad, el impacto ambiental y la salud de los usuarios</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo34_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo34();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo34()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "11", "0", "4", "2");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 34: Selecciono y accedo a programas de formación, apropiados para mis necesidades de desarrollo profesional, para la innovación educativa con TIC</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo35_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo35();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo35()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "12", "0", "4", "0");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 35: Evalúo los beneficios y utilidades de herramientas TIC en la gestión escolar y en la proyección del PEI dando respuesta a las necesidades de mi institución</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo36_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo36();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo36()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "12", "0", "4", "1");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 36: Desarrollo políticas escolares para el uso de las TIC en mi institución que contemplan la privacidad, el impacto ambiental y la salud de los usuarios</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo37_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo37();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo37()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "12", "0", "4", "2");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 37: Dinamizo la formación de mis colegas y los apoyo para que integren las TIC de forma innovadora en sus prácticas pedagógicas</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo38_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo38();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo38()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "13", "0", "4", "0");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 38: Documento observaciones de mi entorno y mi practica con el apoyo de TIC</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo39_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo39();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo39()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "13", "0", "4", "1");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 39: Identifico redes, bases de datos y fuentes de información que facilitan mis procesos de investigación</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo40_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo40();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo40()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "13", "0", "4", "2");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 40: Sé buscar, ordenar, filtrar, conectar y analizar información disponible en Internet</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo41_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo41();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo41()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "14", "0", "4", "0");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 41: Represento e interpreto datos e información de mis investigaciones en diversos formatos digitales</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo42_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo42();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo42()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "14", "0", "4", "1");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 42: Utilizo redes profesionales y plataformas especializadas en el desarrollo de mis investigaciones</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo43_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo43();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo43()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "14", "0", "4", "2");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 43: Contrasto y analizo con mis estudiantes información proveniente de múltiples fuentes digitales</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo44_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo44();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo44()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "15", "0", "4", "0");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 44: Divulgo los resultados de mis investigaciones utilizando las herramientas que me ofrecen las TIC</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo45_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo45();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo45()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "15", "0", "4", "1");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 45: Participo activamente en redes y comunidades de práctica, para la construcción colectiva de conocimientos con estudiantes y colegas, con el apoyo de TIC</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo46_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo46();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo46()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "15", "0", "4", "2");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 46: Utilizo la información disponible en Internet con una actitud crítica y reflexiva</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo47_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo47();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo47()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "16", "0", "4", "0");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 47: Comprendo las posibilidades de las TIC para potenciar procesos de participación democrática</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo48_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo48();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo48()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "16", "0", "4", "1");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 48: Identifico los riesgos de publicar y compartir distintos tipos de información a través de Internet</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo49_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo49();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo49()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "16", "0", "4", "2");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 49: Utilizo las TIC teniendo en cuenta recomendaciones básicas de salud</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;
    }

    protected void btnAutoPercepcionDocentePreguntaNo50_Click(object sender, EventArgs e)
    {
        cargarAutoPercepcionDocentePreguntaNo50();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo50()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "16", "0", "4", "3");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 50: Examino y aplico las normas de propiedad intelectual y licenciamiento existentes, referentes al uso de información ajena y propia</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            //lblResultado.Text = ca;
        }
        return ca;

    }

    protected void btnAutoPercepcionDocentePreguntaNo51_Click(object sender, EventArgs e)
    {
        //cargarAutoPercepcionDocentePreguntaNo51();
        btnExportExcel.Visible = true;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAutoPercepcionDocentePreguntaNo51()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
        if (docentes != null && docentes.Rows.Count > 0)
        {
            int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "16", "0", "4", "4");
                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int k = 0; k < respuestas.Rows.Count; k++)
                    {
                        if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                        {
                            respuestaNo1++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                        {
                            respuestaNo2++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                        {
                            respuestaNo3++;
                        }
                        else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                        {
                            respuestaNo4++;
                        }
                        else
                        {
                            respuestaNo5++;
                        }
                    }
                }

            }

            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 51: Me comunico de manera respetuosa con los demás</td>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Respuestas</th>";
            ca += "<th>Total</th>";
            ca += "</tr>";

            if (respuestaNo1 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>" + respuestaNo1 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>1</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo2 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>" + respuestaNo2 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>2</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo3 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>" + respuestaNo3 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>3</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo4 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>" + respuestaNo4 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>4</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }

            if (respuestaNo5 != 0)
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>" + respuestaNo5 + "</td>";
                ca += "</tr>";
            }
            else
            {
                ca += "<tr>";
                ca += "<td align='center'>5</td>";
                ca += "<td align='right'>0</td>";
                ca += "</tr>";
            }
            ////lblResultado.Text = ca;
        }
        return ca;
    }

     [WebMethod(EnableSession = true)]
     public static string cargarAutoPercepcionDocentePreguntaNo1AJAX()
     {
         LineaBase lb = new LineaBase();
         string ca = "";

         DataTable respuestas = lb.cargarRespuestasCerradasReporte("1","0","4");

         if (respuestas != null && respuestas.Rows.Count > 0)
         {
             int pregunta1 = 0;
             int pregunta2 = 1;
             int pregunta3 = 2;
             int respuestaNo1_1 = 0; int respuestaNo1_2 = 0; int respuestaNo1_3 = 0; int respuestaNo1_4 = 0; int respuestaNo1_5 = 0;
             int respuestaNo2_1 = 0; int respuestaNo2_2 = 0; int respuestaNo2_3 = 0; int respuestaNo2_4 = 0; int respuestaNo2_5 = 0;
             int respuestaNo3_1 = 0; int respuestaNo3_2 = 0; int respuestaNo3_3 = 0; int respuestaNo3_4 = 0; int respuestaNo3_5 = 0;
             int contador = 0;

             //int total = 0;

             string coddocenteasesor = respuestas.Rows[0]["coddocenteasesor"].ToString();
             for (int k = 0; k < respuestas.Rows.Count; k++)
             {

                 if (coddocenteasesor == respuestas.Rows[k]["coddocenteasesor"].ToString())
                 {
                         if (pregunta1 == contador)
                         {
                             if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                             {
                                 respuestaNo1_1++;
                             }
                             else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                             {
                                 respuestaNo1_2++;
                             }
                             else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                             {
                                 respuestaNo1_3++;
                             }
                             else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                             {
                                 respuestaNo1_4++;
                             }
                             else
                             {
                                 respuestaNo1_5++;
                             }
                         }
                         if (pregunta2 == contador)
                         {
                             if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                             {
                                 respuestaNo2_1++;
                             }
                             else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                             {
                                 respuestaNo2_2++;
                             }
                             else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                             {
                                 respuestaNo2_3++;
                             }
                             else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                             {
                                 respuestaNo2_4++;
                             }
                             else
                             {
                                 respuestaNo2_5++;
                             }
                         }
                         if (pregunta3 == contador)
                         {
                             if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                             {
                                 respuestaNo3_1++;
                             }
                             else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                             {
                                 respuestaNo3_2++;
                             }
                             else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                             {
                                 respuestaNo3_3++;
                             }
                             else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                             {
                                 respuestaNo3_4++;
                             }
                             else
                             {
                                 respuestaNo3_5++;
                             }
                         }
                         if (contador == 2)
                         {
                             contador = 0;
                         }
                         else
                             contador++;

                       
                 }
                 else
                 {
                     coddocenteasesor = respuestas.Rows[k]["coddocenteasesor"].ToString();

                     if (pregunta1 == contador)
                     {
                         if (respuestas.Rows[k]["respuesta"].ToString() == "1")
                         {
                             respuestaNo1_1++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
                         {
                             respuestaNo1_2++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
                         {
                             respuestaNo1_3++;
                         }
                         else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
                         {
                             respuestaNo1_4++;
                         }
                         else
                         {
                             respuestaNo1_5++;
                         }
                     }
                     contador++;
                   
                 }

             }
             //total = respuestaNo1_5 + respuestaNo1_4 + respuestaNo1_3 + respuestaNo1_2 + respuestaNo1_1 + respuestaNo2_5 + respuestaNo2_4 + respuestaNo2_3 + respuestaNo2_2 + respuestaNo2_1 + respuestaNo1_5 + respuestaNo1_4 + respuestaNo1_3 + respuestaNo1_2 + respuestaNo1_1;
             if(pregunta1 == 0)
             {
                     ca += "<tr>";
                     ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 1: Identifico las características, usos y oportunidades que ofrecen herramientas tecnológicas y medios audiovisuales, en los procesos educativos</td>";
                     ca += "</tr>";
                     ca += "<tr>";
                     ca += "<th>Respuestas</th>";
                     ca += "<th>Total</th>";
                     ca += "</tr>";

                     if (respuestaNo1_1 != 0)
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>1</td>";
                         ca += "<td align='right'>" + (respuestaNo1_1 * 3) + "</td>";
                         ca += "</tr>";
                     }
                     else
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>1</td>";
                         ca += "<td align='right'>0</td>";
                         ca += "</tr>";
                     }

                     if (respuestaNo1_2 != 0)
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>2</td>";
                         ca += "<td align='right'>" + (respuestaNo1_2* 3) + "</td>";
                         ca += "</tr>";
                     }
                     else
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>2</td>";
                         ca += "<td align='right'>0</td>";
                         ca += "</tr>";
                     }

                     if (respuestaNo1_3 != 0)
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>3</td>";
                         ca += "<td align='right'>" + (respuestaNo1_3 * 3) + "</td>";
                         ca += "</tr>";
                     }
                     else
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>3</td>";
                         ca += "<td align='right'>0</td>";
                         ca += "</tr>";
                     }

                     if (respuestaNo1_4 != 0)
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>4</td>";
                         ca += "<td align='right'>" + (respuestaNo1_4* 3) + "</td>";
                         ca += "</tr>";
                     }
                     else
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>4</td>";
                         ca += "<td align='right'>0</td>";
                         ca += "</tr>";
                     }

                     if (respuestaNo1_5 != 0)
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>5</td>";
                         ca += "<td align='right'>" + (respuestaNo1_5* 3) + "</td>";
                         ca += "</tr>";
                     }
                     else
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>5</td>";
                         ca += "<td align='right'>0</td>";
                         ca += "</tr>";
                     }
                     //ca += "<tr>";
                     //ca += "<td align='center'>total</td>";
                     //ca += "<td align='right'>" + total + "</td>";
                     //ca += "</tr>";

                 }

             if(pregunta2 == 1)
             {
                     ca += "<tr>";
                     ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 2: Elaboro actividades de aprendizaje utilizando aplicativos, contenidos, herramientas informáticas y medios audiovisuales</td>";
                     ca += "</tr>";
                     ca += "<tr>";
                     ca += "<th>Respuestas</th>";
                     ca += "<th>Total</th>";
                     ca += "</tr>";

                     if (respuestaNo2_1 != 0)
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>1</td>";
                         ca += "<td align='right'>" + (respuestaNo2_1* 3) + "</td>";
                         ca += "</tr>";
                     }
                     else
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>1</td>";
                         ca += "<td align='right'>0</td>";
                         ca += "</tr>";
                     }

                     if (respuestaNo2_2 != 0)
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>2</td>";
                         ca += "<td align='right'>" + (respuestaNo2_2* 3) + "</td>";
                         ca += "</tr>";
                     }
                     else
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>2</td>";
                         ca += "<td align='right'>0</td>";
                         ca += "</tr>";
                     }

                     if (respuestaNo2_3 != 0)
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>3</td>";
                         ca += "<td align='right'>" + (respuestaNo2_3* 3) + "</td>";
                         ca += "</tr>";
                     }
                     else
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>3</td>";
                         ca += "<td align='right'>0</td>";
                         ca += "</tr>";
                     }

                     if (respuestaNo2_4 != 0)
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>4</td>";
                         ca += "<td align='right'>" + (respuestaNo2_4* 3) + "</td>";
                         ca += "</tr>";
                     }
                     else
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>4</td>";
                         ca += "<td align='right'>0</td>";
                         ca += "</tr>";
                     }

                     if (respuestaNo2_5 != 0)
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>5</td>";
                         ca += "<td align='right'>" + (respuestaNo2_5* 3) + "</td>";
                         ca += "</tr>";
                     }
                     else
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>5</td>";
                         ca += "<td align='right'>0</td>";
                         ca += "</tr>";
                     }


                 }

             if(pregunta3 == 2)
             {
                     ca += "<tr>";
                     ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 3: Evalúo la calidad, pertinencia y veracidad de la información disponible en diversos medios como portales educativos y especializados, motores de búsqueda y material</td>";
                     ca += "</tr>";
                     ca += "<tr>";
                     ca += "<th>Respuestas</th>";
                     ca += "<th>Total</th>";
                     ca += "</tr>";

                     if (respuestaNo3_1 != 0)
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>1</td>";
                         ca += "<td align='right'>" + (respuestaNo3_1* 3) + "</td>";
                         ca += "</tr>";
                     }
                     else
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>1</td>";
                         ca += "<td align='right'>0</td>";
                         ca += "</tr>";
                     }

                     if (respuestaNo3_2 != 0)
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>2</td>";
                         ca += "<td align='right'>" + (respuestaNo3_2* 3) + "</td>";
                         ca += "</tr>";
                     }
                     else
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>2</td>";
                         ca += "<td align='right'>0</td>";
                         ca += "</tr>";
                     }

                     if (respuestaNo3_3 != 0)
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>3</td>";
                         ca += "<td align='right'>" + (respuestaNo3_3* 3) + "</td>";
                         ca += "</tr>";
                     }
                     else
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>3</td>";
                         ca += "<td align='right'>0</td>";
                         ca += "</tr>";
                     }

                     if (respuestaNo3_4 != 0)
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>4</td>";
                         ca += "<td align='right'>" + (respuestaNo3_4* 3) + "</td>";
                         ca += "</tr>";
                     }
                     else
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>4</td>";
                         ca += "<td align='right'>0</td>";
                         ca += "</tr>";
                     }

                     if (respuestaNo3_5 != 0)
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>5</td>";
                         ca += "<td align='right'>" + (respuestaNo3_5* 3) + "</td>";
                         ca += "</tr>";
                     }
                     else
                     {
                         ca += "<tr>";
                         ca += "<td align='center'>5</td>";
                         ca += "<td align='right'>0</td>";
                         ca += "</tr>";
                     }


                 }
             }

         


         //DataTable docentes = lb.cargarDocentesxAsesorLineaBase();
         //if (docentes != null && docentes.Rows.Count > 0)
         //{
         //    int respuestaNo1 = 0; int respuestaNo2 = 0; int respuestaNo3 = 0; int respuestaNo4 = 0; int respuestaNo5 = 0;
         //    for (int i = 0; i < docentes.Rows.Count; i++)
         //    {
         //        DataTable respuestas = lb.cargarRespuestasDePreguntasInstrumento04OFFSET(docentes.Rows[i]["codigo"].ToString(), "16", "0", "4", "4");

         //        if (respuestas != null && respuestas.Rows.Count > 0)
         //        {
         //            for (int k = 0; k < respuestas.Rows.Count; k++)
         //            {
         //                if (respuestas.Rows[k]["respuesta"].ToString() == "1")
         //                {
         //                    respuestaNo1++;
         //                }
         //                else if (respuestas.Rows[k]["respuesta"].ToString() == "2")
         //                {
         //                    respuestaNo2++;
         //                }
         //                else if (respuestas.Rows[k]["respuesta"].ToString() == "3")
         //                {
         //                    respuestaNo3++;
         //                }
         //                else if (respuestas.Rows[k]["respuesta"].ToString() == "4")
         //                {
         //                    respuestaNo4++;
         //                }
         //                else
         //                {
         //                    respuestaNo5++;
         //                }
         //            }
         //        }

         //    }

             
         //    ca += "<tr>";
         //    ca += "<td colspan='2' style='text-align:center;font-weight:bold;'>Pregunta No 51: Me comunico de manera respetuosa con los demás</td>";
         //    ca += "</tr>";
         //    ca += "<tr>";
         //    ca += "<th>Respuestas</th>";
         //    ca += "<th>Total</th>";
         //    ca += "</tr>";

         //    if (respuestaNo1 != 0)
         //    {
         //        ca += "<tr>";
         //        ca += "<td align='center'>1</td>";
         //        ca += "<td align='right'>" + respuestaNo1 + "</td>";
         //        ca += "</tr>";
         //    }
         //    else
         //    {
         //        ca += "<tr>";
         //        ca += "<td align='center'>1</td>";
         //        ca += "<td align='right'>0</td>";
         //        ca += "</tr>";
         //    }

         //    if (respuestaNo2 != 0)
         //    {
         //        ca += "<tr>";
         //        ca += "<td align='center'>2</td>";
         //        ca += "<td align='right'>" + respuestaNo2 + "</td>";
         //        ca += "</tr>";
         //    }
         //    else
         //    {
         //        ca += "<tr>";
         //        ca += "<td align='center'>2</td>";
         //        ca += "<td align='right'>0</td>";
         //        ca += "</tr>";
         //    }

         //    if (respuestaNo3 != 0)
         //    {
         //        ca += "<tr>";
         //        ca += "<td align='center'>3</td>";
         //        ca += "<td align='right'>" + respuestaNo3 + "</td>";
         //        ca += "</tr>";
         //    }
         //    else
         //    {
         //        ca += "<tr>";
         //        ca += "<td align='center'>3</td>";
         //        ca += "<td align='right'>0</td>";
         //        ca += "</tr>";
         //    }

         //    if (respuestaNo4 != 0)
         //    {
         //        ca += "<tr>";
         //        ca += "<td align='center'>4</td>";
         //        ca += "<td align='right'>" + respuestaNo4 + "</td>";
         //        ca += "</tr>";
         //    }
         //    else
         //    {
         //        ca += "<tr>";
         //        ca += "<td align='center'>4</td>";
         //        ca += "<td align='right'>0</td>";
         //        ca += "</tr>";
         //    }

         //    if (respuestaNo5 != 0)
         //    {
         //        ca += "<tr>";
         //        ca += "<td align='center'>5</td>";
         //        ca += "<td align='right'>" + respuestaNo5 + "</td>";
         //        ca += "</tr>";
         //    }
         //    else
         //    {
         //        ca += "<tr>";
         //        ca += "<td align='center'>5</td>";
         //        ca += "<td align='right'>0</td>";
         //        ca += "</tr>";
         //    }

           
         //}
        

         return ca;

     }
     protected void btnFormulariosxMunicipioAutopercepcion_Click(object sender, EventArgs e)
     {
         //cargarFormulariosxMunicipioAutopercepcion();
     }
    [WebMethod(EnableSession = true)]
     public static string cargarFormulariosxMunicipioAutopercepcion()
     {
         string ca = "";

         LineaBase lb = new LineaBase();
         Institucion inst = new Institucion();
         DataTable datos = lb.cargarSedesxMunicipioDiligenciandoAutopercepcion();
         DataTable municipio = inst.cargarciudadxDepartamento("20");

         if (datos != null && datos.Rows.Count > 0)
         {

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<th>Municipio</th>";
             ca += "<th>Total de formularios diligenciados por municipio</th>";
             ca += "</tr>";

             if (municipio != null && municipio.Rows.Count > 0)
             {
                 int contadorsedes = 0;
                 for (int i = 0; i < municipio.Rows.Count; i++)
                 {
                     int contador = 0;
                     for (int j = 0; j < datos.Rows.Count; j++)
                     {
                         if (municipio.Rows[i]["nombre"].ToString() == datos.Rows[j]["nombre"].ToString())
                         {
                             contador++;
                             contadorsedes++;
                         }
                     }
                     if (contador > 0)
                     {
                         //if (municipio.Rows[i]["nombre"].ToString() == "PLATO")
                         //{
                         //    ca += "<tr>";
                         //    ca += "<td>" + municipio.Rows[i]["nombre"].ToString() + "</td>";
                         //    ca += "<td align='right'>29</td>";
                         //    ca += "</tr>";
                         //}
                         //else if (municipio.Rows[i]["nombre"].ToString() == "EL RETÉN")
                         //{
                         //    ca += "<tr>";
                         //    ca += "<td>" + municipio.Rows[i]["nombre"].ToString() + "</td>";
                         //    ca += "<td align='right'>6</td>";
                         //    ca += "</tr>";
                         //}
                         //else if (municipio.Rows[i]["nombre"].ToString() == "ZAPAYÁN")
                         //{
                         //    ca += "<tr>";
                         //    ca += "<td>" + municipio.Rows[i]["nombre"].ToString() + "</td>";
                         //    ca += "<td align='right'>6</td>";
                         //    ca += "</tr>";
                         //}
                         //else if (municipio.Rows[i]["nombre"].ToString() == "ZONA BANANERA")
                         //{
                         //    ca += "<tr>";
                         //    ca += "<td>" + municipio.Rows[i]["nombre"].ToString() + "</td>";
                         //    ca += "<td align='right'>35</td>";
                         //    ca += "</tr>";
                         //}
                         //else
                         //{
                             ca += "<tr>";
                             ca += "<td>" + municipio.Rows[i]["nombre"].ToString() + "</td>";
                             ca += "<td align='right'>" + contador + "</td>";
                             ca += "</tr>";
                         //}

                     }
                     else
                     {
                         ca += "<tr>";
                         ca += "<td>" + municipio.Rows[i]["nombre"].ToString() + "</td>";
                         ca += "<td align='right'>0</td>";
                         ca += "</tr>";
                     }
                 }
                 ca += "<tr>";
                 ca += "<th>TOTAL SEDES</th>";
                 //ca += "<td align='right' style='font-weight:bold;'>320</td>";
                 ca += "<td align='right' style='font-weight:bold;'>" + contadorsedes + "</td>";
                 ca += "</tr>";
             }
         }

         return ca;
         ////lblResultado.Text = ca;

     }

     protected void btnSedesxMunicipioAutopercepcion_Click(object sender, EventArgs e)
     {
         //cargarSedesxMunicipioAutopercepcion();
     }
    [WebMethod(EnableSession = true)]
     public static string cargarSedesxMunicipioAutopercepcion()
     {
         string ca = "";
         LineaBase lb = new LineaBase();
         Institucion inst = new Institucion();
         DataTable datos = lb.cargarSedesxMunicipioDiligenciandoAutopercepcion();
         DataTable municipio = inst.cargarciudadxDepartamento("20");

         if (datos != null && datos.Rows.Count > 0)
         {

             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<th>Municipio</th>";
             ca += "<th>Total de sedes educativas por municipio</th>";
             ca += "</tr>";

             if (municipio != null && municipio.Rows.Count > 0)
             {
                 int contadorsedes = 0;
                 for (int i = 0; i < municipio.Rows.Count; i++)
                 {
                     int contador = 0;
                     for (int j = 0; j < datos.Rows.Count; j++)
                     {
                         if (municipio.Rows[i]["nombre"].ToString() == datos.Rows[j]["nombre"].ToString())
                         {
                             contador++;
                             contadorsedes++;
                         }
                     }
                     if (contador > 0)
                     {
                         //if (municipio.Rows[i]["nombre"].ToString() == "PLATO")
                         //{
                         //    ca += "<tr>";
                         //    ca += "<td>" + municipio.Rows[i]["nombre"].ToString() + "</td>";
                         //    ca += "<td align='right'>29</td>";
                         //    ca += "</tr>";
                         //}
                         //else if (municipio.Rows[i]["nombre"].ToString() == "EL RETÉN")
                         //{
                         //    ca += "<tr>";
                         //    ca += "<td>" + municipio.Rows[i]["nombre"].ToString() + "</td>";
                         //    ca += "<td align='right'>6</td>";
                         //    ca += "</tr>";
                         //}
                         //else if (municipio.Rows[i]["nombre"].ToString() == "ZAPAYÁN")
                         //{
                         //    ca += "<tr>";
                         //    ca += "<td>" + municipio.Rows[i]["nombre"].ToString() + "</td>";
                         //    ca += "<td align='right'>6</td>";
                         //    ca += "</tr>";
                         //}
                         //else if (municipio.Rows[i]["nombre"].ToString() == "ZONA BANANERA")
                         //{
                         //    ca += "<tr>";
                         //    ca += "<td>" + municipio.Rows[i]["nombre"].ToString() + "</td>";
                         //    ca += "<td align='right'>35</td>";
                         //    ca += "</tr>";
                         //}
                         //else
                         //{
                         ca += "<tr>";
                         ca += "<td>" + municipio.Rows[i]["nombre"].ToString() + "</td>";
                         ca += "<td align='right'>" + contador + "</td>";
                         ca += "</tr>";
                         //}

                     }
                     else
                     {
                         ca += "<tr>";
                         ca += "<td>" + municipio.Rows[i]["nombre"].ToString() + "</td>";
                         ca += "<td align='right'>0</td>";
                         ca += "</tr>";
                     }
                 }
                 ca += "<tr>";
                 ca += "<th>TOTAL SEDES</th>";
                 //ca += "<td align='right' style='font-weight:bold;'>320</td>";
                 ca += "<td align='right' style='font-weight:bold;'>" + contadorsedes + "</td>";
                 ca += "</tr>";
             }
         }

         return ca;
         ////lblResultado.Text = ca;

     }

     protected void btnDocentesUltimoNivelEducativoAprobado_Click(object sender, EventArgs e)
     {
         //cargarDocentesUltimoNivelEducativoAprobado();
     }
     [WebMethod(EnableSession = true)]
     public static string cargarDocentesUltimoNivelEducativoAprobado()
     {
         string ca = "";

         LineaBase lb = new LineaBase();
         DataTable datos = lb.cargarDocentesUltimoNivelEducativoAprobado();

         if (datos != null && datos.Rows.Count > 0)
         {
             
             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='3' style='text-align:center;font-weight:bold;'>Total de personal docente según último nivel educativo aprobado</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Último nivel educativo aprobado por el docente</th>";
             ca += "<th>Nivel educativo en el que dicta el docente</th>";
             ca += "<th>TOTAL DOCENTES</th>";
             ca += "</tr>";
             for (int i = 0; i < datos.Rows.Count; i++)
             {
                 ca += "<tr>";
                 ca += "<td>" + datos.Rows[i]["categoria"].ToString() + "</td>";
                 ca += "<td>" + datos.Rows[i]["subcategoria"].ToString() + "</td>";
                 ca += "<td align='right'>" + datos.Rows[i]["total"].ToString() + "</td>";
                 ca += "</tr>";
             }
             ca += "</table>";
         }
         return ca;
         ////lblResultado.Text = ca;

     }

     protected void btnPersonasSegunFuncion_Click(object sender, EventArgs e)
     {
         cargarPersonasSegunFuncion();
     }

     private void cargarPersonasSegunFuncion()
     {
         string ca = "";

         DataTable datos = lb.cargarDocentesUltimoNivelEducativoAprobado();

         if (datos != null && datos.Rows.Count > 0)
         {
             int ciencia = 0;
             int innovacion = 0;
             int tecnologia = 0;
             int tic = 0;
             int na = 0;
             int investigacion = 0;
             ca += "<table class='mGridTesoreria'>";
             ca += "<tr>";
             ca += "<td colspan='3' style='text-align:center;font-weight:bold;'>Total de personal docente según último nivel educativo aprobado</td>";
             ca += "</tr>";
             ca += "<tr>";
             ca += "<th>Último nivel educativo aprobado por el docente</th>";
             ca += "<th>Nivel educativo en el que dicta el docente</th>";
             ca += "<th>TOTAL DOCENTES</th>";
             ca += "</tr>";
             for (int i = 0; i < datos.Rows.Count; i++)
             {
                 ca += "<tr>";
                 ca += "<td>" + datos.Rows[i]["categoria"].ToString() + "</td>";
                 ca += "<td>" + datos.Rows[i]["subcategoria"].ToString() + "</td>";
                 ca += "<td align='right'>" + datos.Rows[i]["total"].ToString() + "</td>";
                 ca += "</tr>";
             }
             ca += "</table>";
         }

         //lblResultado.Text = ca;

     }

    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    

}