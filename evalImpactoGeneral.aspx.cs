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
using System.Net;
using System.Collections;

public partial class evalintermediaGeneral : System.Web.UI.Page
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

    public static string URLDecode(string url)
    {
        return HttpUtility.UrlDecode(url, Encoding.UTF7);
    }

    private string MenuAcordeonVisores()
    {
        string ca = "";

        ca += "<h3>1. Docentes beneficiados por el Proyecto que participan en la evaluación Impacto</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type:lower-latin;'><a href='javascript:void(0)' onclick='docentesbeneficiados()'>Total Personal docente y directivo beneficiado por el proyecto que participa en la evaluación Impacto.</a></li>";
        
        ca += "</ul>";
        ca += "</div>";

        //instrumento No 0.1
        ca += "<h3>Instrumentos No. 0.1 </h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type:circle;'><a href='javascript:void(0)' onclick='docentesbeneficiados()'> Indece de calidad de educacion.</a></li>";
        ca += "</ul>";
        ca += "</div>";

        //instrumento No 02.1
        ca += "<h3>Instrumentos No. 02.2</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type:circle;'><a href='javascript:void(0)' onclick='docentesbeneficiados()'>La institución actualizó el PEI entre los meses de mayo de 2016 a la fecha.</a></li>";
        ca += "<li style='list-style-type:circle;'><a href='javascript:void(0)' onclick='docentesEvaluacionintermedia()'>El Proyecto Educativo Institucional – PEI tiene alguno de estos énfasis formativos</a></li>";
        ca += "<li style='list-style-type:circle;'><a href='javascript:void(0)' onclick='docentesEvaluacionintermedia()'>¿Cuál es el modelo educativo de la sede beneficiada?, teniendo en cuenta la clasificación del Ministerio de Educación Nacional –MEN- (marque solo una respuesta): </a></li>";
        ca += "<li style='list-style-type:circle;'><a href='javascript:void(0)' onclick='docentesEvaluacionintermedia()'>¿En el Proyecto Educativo Institucional – PEI- se promueve en las prácticas institucionales alguno de los siguientes aspectos?  </a></li>";
        ca += "<li style='list-style-type:circle;'><a href='javascript:void(0)' onclick='docentesEvaluacionintermedia()'> Si el PEI considera el uso de las TIC en las prácticas institucionales, ¿cuáles de las siguientes TICS hacen parte de las prácticas institucionales que promueven? </a></li>";
        ca += "<li style='list-style-type:circle;'><a href='javascript:void(0)' onclick='docentesEvaluacionintermedia()'>  Identificar en el PEI, ¿cuáles son las prácticas de innovación educativa que se proponen para realizar en la sede beneficiada? </a></li>";
        ca += "<li style='list-style-type:circle;'><a href='javascript:void(0)' onclick='docentesEvaluacionintermedia()'> ¿El PEI pretende formar en competencias para el uso y apropiación de las TIC?  </a></li>";
        ca += "<li style='list-style-type:circle;'><a href='javascript:void(0)' onclick='docentesEvaluacionintermedia()'>  ¿Cuáles competencias en apropiación de TIC pretende formar el currículo, según la propuesta del MEN?  </a></li>";


        ca += "</ul>";
        ca += "</div>";

        //instrumento No 02.2
        ca += "<h3>Instrumentos No. 02.1</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type:decimal;'><a href='javascript:void(0)' onclick='docentesbeneficiados()'>Punto 1.</a></li>";
        ca += "<li style='list-style-type:decimal;'><a href='javascript:void(0)' onclick='docentesEvaluacionintermedia()'>Punto 2.</a></li>";
        ca += "</ul>";
        ca += "</div>";

        //instrumento No 0.3
        ca += "<h3>Instrumentos No. 0.3</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type:circle;'><a href='javascript:void(0)' onclick='docentesEvaluacionintermedia()'> Equipamiento entregado por el programa Ciclón de la Gobernación del Magdalena a las sedes educativas beneficiadas. (Información tomada de las actas de entrega, durante la evaluación intermedia)   </a></li>";
        ca += "<li style='list-style-type:circle;'><a href='javascript:void(0)' onclick='docentesEvaluacionintermedia()'> Otro equipamiento entregado por la Gobernación y Computadores para Educar a la sede educativa en el período 2016-2018, diferentes al proporcionado por el programa Ciclón:   </a></li>";
        ca += "<li style='list-style-type:circle;'><a href='javascript:void(0)' onclick='docentesEvaluacionintermedia()'> ¿Se utilizaron las tabletas entregadas por el Programa en sus espacios de formación, apropiación e investigación y para el trabajo en el aula?   </a></li>";
        ca += "<li style='list-style-type:circle;'><a href='javascript:void(0)' onclick='docentesEvaluacionintermedia()'> Su sede educativa fue beneficiada con el servicio de conectividad entregado por el programa Ciclón de la gobernación del Magdalena, entre los meses de: </a></li>";
        ca += "<li style='list-style-type:circle;'><a href='javascript:void(0)' onclick='docentesEvaluacionintermedia()'> ¿Se utilizó la conectividad en los espacios de formación del Programa y en aula?   </a></li>";
        ca += "</ul>";
        ca += "</div>";

        //instrumento No 0.4
        ca += "<h3>Instrumentos No. 0.4</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type:lower-latin;'><a href='javascript:void(0)' onclick='docentesbeneficiados()'>Punto 1.</a></li>";
        ca += "<li style='list-style-type:lower-latin;'><a href='javascript:void(0)' onclick='docentesEvaluacionintermedia()'>Punto 2.</a></li>";
        ca += "</ul>";
        ca += "</div>";

        //instrumento No 0.5
        ca += "<h3>Instrumentos No. 0.5</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type:lower-latin;'><a href='javascript:void(0)' onclick='docentesbeneficiados()'>Punto 1.</a></li>";
        ca += "<li style='list-style-type:lower-latin;'><a href='javascript:void(0)' onclick='docentesEvaluacionintermedia()'>Punto 2.</a></li>";
        ca += "</ul>";
        ca += "</div>";

        //instrumento No 0.6
        ca += "<h3>Instrumentos No. 0.6</h3>";
        ca += "<div>";
        ca += "<ul>";
        ca += "<li style='list-style-type:lower-latin;'><a href='javascript:void(0)' onclick='docentesbeneficiados()'>Punto 1.</a></li>";
        ca += "<li style='list-style-type:lower-latin;'><a href='javascript:void(0)' onclick='docentesEvaluacionintermedia()'>Punto 2.</a></li>";
        ca += "</ul>";
        ca += "</div>";


        //ca += "<h3>Equipamiento y uso pedagógico de TIC en las sedes educativas</h3>";
        //ca += "<div>";
        //ca += "<ul>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='inventariodequipamiento()'>Inventario del equipamiento de TIC en las sedes educativas.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='inventariotabletasentregadas()'>Inventario de las tabletas entregadas por el Proyecto a las sedes educativas.</a></li>";
        //ca += "</ul>";
        //ca += "</div>";


        //ca += "<h3>Acceso de los estudiantes y maestros beneficiarios a las tabletas entregadas por el Proyecto a las sedes educativas beneficiadas</h3>";
        //ca += "<div>";
        //ca += "<ul>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='accesostabletasformacionmaestros()'>Acceso de las tabletas en la formación de maestros.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='Accesosgrupostabletasentregadas()'>Acceso de los grupos de investigación a las tabletas entregadas por el Proyecto a las sedes educativas beneficiadas.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='accesosredestabletasentregadas()'>Acceso de las redes temáticas a las tabletas entregadas por el Proyecto a las sedes educativas beneficiadas.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='sedeseducativasservicioconectividad()'>Sedes educativas beneficiadas con servicio de conectividad entregado por el Proyecto.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='usoconectividadformacionmaestros()'>Uso de la conectividad en la formación de maestros.</a></li>";
        ////ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='sedesbeneficiadasconectividadentregado()'>Sedes educativas beneficiadas con servicio de conectividad entregado por el Proyecto.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='usoconectividadtrabajoredes()'>Uso de conectividad para el trabajo de las redes temáticas.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='herramientaswebsedes()'>Herramientas web de las sedes educativas.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='plataformasPedagogicasSedes()'>Plataformas pedagógicas de las sedes educativas.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='participacionProcesosFormacionDocentes()'>Participación en procesos de formación de docentes para el uso de las TIC.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='sedesEducativasTresPlanesdeMejoramiento()'>Total sedes educativas que han incluido las TIC en los tres planes de mejoramiento.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='percepcionefectosincorporacionTICsedes()'>Percepción sobre los efectos de la incorporación de TIC en las sedes educativas como herramienta pedagógica.</a></li>";
        //ca += "</ul>";
        //ca += "</div>";



        //ca += "<h3>Introducción de la IEP apoyada en TIC al currículo.</h3>";
        //ca += "<div>";
        //ca += "<ul>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='modificacionescurriculosdirigidas()'>Modificaciones a los currículo dirigidas a introducir la IEP apoyada en TIC.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='modeloeducativoinstitucion()'>Modelo educativo de la institución favorece la incorporación de la IEP apoyada en TIC al currículo</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='docentesmodificaronpracticapedagogica()'>Docentes que modificaron su práctica pedagógica debido a la formación en la Investigación como Estrategia Pedagógica apoyada en TIC bridada por el Proyecto.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='maestrosincluyenelusoTIC()'>Maestros que incluyen el uso de TIC en sus prácticas pedagógicas.</a></li>";

        //ca += "</ul>";
        //ca += "</div>";

        //ca += "<h3>Presencia de las TIC / CT+ I e Investigación en los énfasis formativos de los PEI.</h3>";
        //ca += "<div>";
        //ca += "<ul>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='actualizacionPEI()'>Actualización del PEI.</a></li>";
        //ca += "</ul>";
        //ca += "</div>";


        //ca += "<h3>Acceso de los estudiantes y maestros a la conectividad  entregadas por el Proyecto a las sedes educativas beneficiadas</h3>";
        //ca += "<div>";
        //ca += "<ul>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='sedesincluyenformativos()'>Sedes educativas que incluyen ciencia, innovación, investigación y TIC en los énfasis formativos de sus PEI.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='institucionesincluyenciencia()'>Instituciones educativas que incluyen ciencia en los énfasis formativos de sus PEI.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='sedesincluyentecnologiaspei()'>Sedes educativas que incluyen tecnología en los énfasis formativos de sus PEI.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='sedesincluyeninnovacionpei()'>Sedes educativas que incluyen innovación en los énfasis formativos de sus PEI.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='sedesincluyeninvestigacionpei()'>Sedes educativas que incluyen investigación en los énfasis formativos de sus PEI.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='sedesincluyenTicpei()'>Sedes educativas que incluyen TIC en los énfasis formativos de sus PEI.</a></li>";
        //ca += "</ul>";
        //ca += "</div>";


        //ca += "<h3>Modelo educativo de las instituciones educativas beneficiadas</h3>";
        //ca += "<div>";
        //ca += "<ul>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='modeloseducativosdesedes()'>Modelo educativo de las sedes beneficiadas.</a></li>";
        //ca += "</ul>";
        //ca += "</div>";

        //ca += "<h3>Definición de necesidades sobre TIC, CT+I e investigación en el currículo. Instrumento</h3>";
        //ca += "<div>";
        //ca += "<ul>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='institucionespromueveinvestigaciondocente()'>Instituciones educativas que promueve en el PEI la investigación docente en el currículo.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='institucionespromueveinvestigacionestudiantes()'>Instituciones educativas que desde el PEI promueve la investigación de los estudiantes.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='institucionespromueveusoticdocentes()'>Instituciones educativas que desde el PEI promueve uso de las TIC en los docentes.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='institucionespromueveusoticestudiantes()'>Instituciones educativas que desde el PEI promueve uso de las TIC en los estudiantes.</a></li>";
        //ca += "</ul>";
        //ca += "</div>";

        //ca += "<h3>Realización y promoción de procesos institucionales de investigación y en el uso de TIC en las sedes educativas</h3>";
        //ca += "<div>";
        //ca += "<ul>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='participacionmaestrosproyectosinvestigacion()'>Participación de los maestros en proyectos de investigación en la institución.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='proyectosinvestigacionestudiantespracticapedagogica()'>Proyectos de investigación con los estudiantes como parte de la práctica pedagógica.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='modalidadproyectosestudiantes()'>Modalidad de los proyectos con los estudiantes.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='formacionespecificaenciencia()'>Formación específica en Ciencia, tecnología e innovación.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='formacioncontribuyocambiarpracticaspedagogicas()'>La formación contribuyó a cambiar sus prácticas pedagógicas.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='dequemaneracontribuyocambiarlaspracticaspedagogica()'>De qué manera contribuyó a cambiar las prácticas pedagógica.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='formacionespecificaenTIC()'>Formación específica en TIC.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='formacionprogramaciclon()'>Formación del programa Ciclón.</a></li>";
        //ca += "<li style='list-style-type: square;'><a href='javascript:void(0)' onclick='formacioncicloncontribuyocambiarpracticaspedagogicas()'>La formación en Ciclón contribuyó a cambiar sus prácticas pedagógicas.</a></li>";
        //ca += "</ul>";
        //ca += "</div>";

        return ca;
    }

    public static void Encode(string path)
{
    byte[] bytes;
    using (var sr = new StreamReader(path))
    {
        var text = sr.ReadToEnd();
        bytes = Encoding.UTF8.GetBytes(text);
    }
    using (var sw = new StreamWriter(path))
    {
        foreach (byte b in bytes)
        {
            sw.WriteLine(b);
        }
    }
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

        public int contar(DataTable o)
    {
        int num=0;
        for (int i = 0; i < o.Rows.Count; i++)
        {
            num += 1;
        }
        return num; ;
    }
     [WebMethod(EnableSession = true)]
    public static string docentesbeneficiados()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        Institucion inst = new Institucion();

        DataTable datos = lb.totalImpacto("","","","");
        DataRow totalInstitucion = lb.TotalInstitucionesImpacto();
        DataRow totalsede = lb.TotalSedeImpacto();
        DataRow totalestudiante = lb.TotalEncuestaEstudiantes();
        evalintermediaGeneral eig = new evalintermediaGeneral();

        string total = totalInstitucion["count"].ToString();
        string totasede = totalsede["count"].ToString();
        string totaestudiante = totalestudiante["count"].ToString();

        if (datos != null && datos.Rows.Count > 0)
        {
          
            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<th>Participantes</th>";
            ca += "<th>Total</th>";
         
            ca += "<th>Detalle</th>";
            ca += "</tr>";

            ca += "<tr>";
            ca += "<td>Docentes</th>";
            ca += "<td>"+datos.Rows.Count+"</th>";
          
            ca += "<td align='right'><a href='detalleDocenteImpacto.aspx'>ver detalles</a></td>";
            ca += "</tr>";

            ca += "<tr>";
            ca += "<td>Instituciones</th>";
            ca += "<td>"+total+"</th>";

          
            ca += "<td align='right'><a href='detalleInstitucionImpacto.aspx'>ver detalles</a></td>";
            ca += "</tr>";


            ca += "<tr>";
            ca += "<td>Sede</th>";
            ca += "<td>" + totasede + "</th>";
            ca += "<td align='right'><a href='detalleSedesImpacto.aspx'>ver detalles</a></td>";
            ca += "</tr>";

            ca += "<tr>";
            ca += "<td>Estudiantes</th>";
            ca += "<td>" + totaestudiante + "</th>";
            ca += "<td align='right'><a href='detalleEncuestaEstudiante.aspx'>ver detalles</a></td>";
            ca += "</tr>";
        }
        else
        {
            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<th>Participantes</th>";
            ca += "<th>Total</th>";
            ca += "<th>Pocentaje</th>";
            ca += "<th>Detalle</th>";
            ca += "</tr>";

            ca += "<tr> no hay dato";
             
            ca += "</tr>";
        }


        return ca;
        ////lblResultado.Text = ca;
    }
    public int  n (string t)
    {
        int num = 0;
        switch (t)
        {
            case "Normalista Superior":
                num = 1;
                break;
            case "Bachillerato pedagógico":
                num = 1;
                break;
            case "Otro bachillerato":
                num = 1;
                break;
            case "Otro Técnico o tecnológico":
                num = 2;
                break;
            case "Técnico o tecnológico":
                num = 2;
                break;
            case "Profesional pedagógico":
                num = 3;
                break;
            case "Otro profesional":
                num = 3;
                break;
            case "Especialización":
                num = 4;
                break;
            case "Maestría en educación o pedagogía":
                num = 5;
                break;
            case "Otra maestría":
                num = 5;
                break;
            case "Doctorado en educación o pedagogía":
                num = 6;
                break;
            case "Otro doctorado":
                num = 6;
                break;
        }

        return num;
    }
    public int  total(DataTable t , string n)
    {
        int to = 0;
        for (int i=0; i< t.Rows.Count; i++)
        {
            if (t.Rows[i]["num"].ToString() == n)
            {
                to += 1;
            }

        }


        return to;

    }



    [WebMethod(EnableSession = true)]
    public static string docentesEvaluacionintermedia()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataTable totalDocentes = lb.totalDocentesEvaIntermedia();

        //normalista superior
        DataTable totalDocentesNormalista =             lb.totalDocentesEvaIntermediaxNivelEducativo("Normalista Superior");
        DataTable totalDocentesOtroBachillerato =       lb.totalDocentesEvaIntermediaxNivelEducativo("Otro bachillerato");
        DataTable totalDocentesTecnicoTecnologico =     lb.totalDocentesEvaIntermediaxNivelEducativo("Técnico o tecnológico");
        DataTable totalDocentesOtroTecnicoTecnologico = lb.totalDocentesEvaIntermediaxNivelEducativo("Otro Técnico o tecnológico");
        DataTable totalDocentesProfesionalPedagogico =  lb.totalDocentesEvaIntermediaxNivelEducativo("Profesional pedagógico");
        DataTable totalDocentesOtroProfesional =        lb.totalDocentesEvaIntermediaxNivelEducativo("Otro profesional");
        DataTable totalDocentesEspecializacion =        lb.totalDocentesEvaIntermediaxNivelEducativo("Especialización");
        DataTable totalDocentesMaestriaEducacion =      lb.totalDocentesEvaIntermediaxNivelEducativo("Maestría en educación o pedagogía");
        DataTable totalDocentesOtraMaestria =           lb.totalDocentesEvaIntermediaxNivelEducativo("Otra Maestría");
        DataTable totalDocentesDoctoradoEducacion =     lb.totalDocentesEvaIntermediaxNivelEducativo("Doctorado en educación o pedagogía");
        DataTable totalDocentesOtroDoctorado =          lb.totalDocentesEvaIntermediaxNivelEducativo("Otro Doctorado");

        var totalmet = new evalintermediaGeneral();


        int total = totalmet.total(totalDocentesNormalista, "1")+ totalmet.total(totalDocentesNormalista, "2")+ totalmet.total(totalDocentesNormalista, "3")+ totalmet.total(totalDocentesNormalista, "4")+ totalmet.total(totalDocentesNormalista, "5") + totalmet.total(totalDocentesNormalista, "6")+ totalmet.total(totalDocentesNormalista, "7")+ totalmet.total(totalDocentesNormalista, "8")+ totalmet.total(totalDocentesNormalista, "9") + totalmet.total(totalDocentesNormalista, "10") + totalmet.total(totalDocentesNormalista, "11") + totalmet.total(totalDocentesNormalista, "12");

        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th>Último nivel educativo aprobado</th>";
        ca += "<th>Número de docentes</th>";
        ca += "<th>Porcentaje </th>";
        ca += "<th>Detalle </th>";
        ca += "</tr>";

        var total0 = (((double)totalmet.total(totalDocentesNormalista, "1") / (double)total) * 100);
        var total1 = (((double)totalmet.total(totalDocentesNormalista, "2") / (double)total) * 100);
        var total2 = (((double)totalmet.total(totalDocentesNormalista, "3") / (double)total) * 100);
        var total3 = (((double)totalmet.total(totalDocentesNormalista, "4") / (double)total) * 100);
        var total4 = (((double)totalmet.total(totalDocentesNormalista, "5") / (double)total) * 100);
        var total5 = (((double)totalmet.total(totalDocentesNormalista, "6") / (double)total) * 100);
        var total6 = (((double)totalmet.total(totalDocentesNormalista, "7") / (double)total) * 100);
        var total7 = (((double)totalmet.total(totalDocentesNormalista, "8") / (double)total) * 100);
        var total8 = (((double)totalmet.total(totalDocentesNormalista, "9") / (double)total) * 100);
        var total9 = (((double)totalmet.total(totalDocentesNormalista, "10") / (double)total) * 100);
        var total10 = (((double)totalmet.total(totalDocentesNormalista, "11") / (double)total) * 100);
        var total11 = (((double)totalmet.total(totalDocentesNormalista, "12") / (double)total) * 100);
        total0 = Math.Round(total0, 2);
        total1 = Math.Round(total1, 2);
        ca += "<tr>";
        ca += "<td>Bachillerato pedagógico</td>";
        ca += "<td align='right'>" + totalmet.total(totalDocentesNormalista, "1") + "</td>";
        ca += "<td align='right'> " + total0 + "%</td>";

        ca += "<td align='right'><a href='docentesEvaluacionintermedia.aspx?resp=Bachillerato pedagógico'>ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td>Normalista Superior</td>";
        ca += "<td align='right'>"+totalmet.total(totalDocentesNormalista, "2") + "</td>";
        ca += "<td align='right'> "+ total1 + "%</td>";

        ca += "<td align='right'><a href='docentesEvaluacionintermedia.aspx?resp=Normalista Superior'>ver detalles</a></td>";
        ca += "</tr>";

      
        total2 = Math.Round(total2, 2);
        ca += "<tr>";
        ca += "<td>Otro bachillerato</td>";
        ca += "<td align='right'>" + totalmet.total(totalDocentesNormalista, "3") + "</td>";
        ca += "<td align='right'> " + total2 + "%</td>";
        ca += "<td align='right'><a href='docentesEvaluacionintermedia.aspx?resp=Otro bachillerato'>ver detalles</a></td>";
        ca += "</tr>";

        
        total3 = Math.Round(total3, 2);
        ca += "<tr>";
        ca += "<td>Técnico o tecnológico</td>";
        ca += "<td align='right'>" + totalmet.total(totalDocentesNormalista, "4") + "</td>";
        ca += "<td align='right'> " + total3 + "%</td>";

        ca += "<td align='right'><a href='docentesEvaluacionintermedia.aspx?resp=Técnico o tecnológico'>ver detalles</a></td>";
        ca += "</tr>";

       
        total4 = Math.Round(total4, 2);
        ca += "<tr>";
        ca += "<td>Otro Técnico o tecnológico</td>";
        ca += "<td align='right'>" + totalmet.total(totalDocentesNormalista, "5") + "</td>";
        ca += "<td align='right'> " + total4 + "%</td>";
        ca += "<td align='right'><a href='docentesEvaluacionintermedia.aspx?resp=Otro Técnico o tecnológico'>ver detalles</a></td>";
        ca += "</tr>";

        total5 = Math.Round(total5, 2);
        ca += "<tr>";
        ca += "<td>Profesional pedagógico</td>";
        ca += "<td align='right'>" + totalmet.total(totalDocentesNormalista, "6") + "</td>";
        ca += "<td align='right'> " + total5 + "%</td>";
        ca += "<td align='right'><a href='docentesEvaluacionintermedia.aspx?resp=Profesional pedagógico'>ver detalles</a></td>";
        ca += "</tr>";


       
        total6 = Math.Round(total6, 2);
        ca += "<tr>";
        ca += "<td>Otro profesional</td>";
        ca += "<td align='right'>" + totalmet.total(totalDocentesNormalista, "7") + "</td>";
        ca += "<td align='right'> " + total6 + "%</td>";
        ca += "<td align='right'><a href='docentesEvaluacionintermedia.aspx?resp=Otro profesional'>ver detalles</a></td>";
        ca += "</tr>";


        
        total7 = Math.Round(total7, 2);
        ca += "<tr>";
        ca += "<td>Especialización</td>";
        ca += "<td align='right'>" + totalmet.total(totalDocentesNormalista, "8") + "</td>";
        ca += "<td align='right'> " + total7 + "%</td>";
        ca += "<td align='right'><a href='docentesEvaluacionintermedia.aspx?resp=Especialización'>ver detalles</a></td>";
        ca += "</tr>";

        
        total8 = Math.Round(total8, 2);
        ca += "<tr>";
        ca += "<td>Maestría en educación o pedagogía</td>";
        ca += "<td align='right'>" + totalmet.total(totalDocentesNormalista, "9") + "</td>";
        ca += "<td align='right'> " + total8 + "%</td>";
        ca += "<td align='right'><a href='docentesEvaluacionintermedia.aspx?resp=Maestría en educación o pedagogía'>ver detalles</a></td>";
        ca += "</tr>";

        
        total9 = Math.Round(total9, 2);
        ca += "<tr>";
        ca += "<td>Otra maestría</td>";
        ca += "<td align='right'>" + totalmet.total(totalDocentesNormalista, "10") + "</td>";
        ca += "<td align='right'> " + total9 + "%</td>";
        ca += "<td align='right'><a href='docentesEvaluacionintermedia.aspx?resp=Otra Maestría'>ver detalles</a></td>";
        ca += "</tr>";

            
       
        total10 = Math.Round(total10, 2);
        ca += "<tr>";
        ca += "<td>Doctorado en educación o pedagogía</td>";
        ca += "<td align='right'>" + totalmet.total(totalDocentesNormalista, "11") + "</td>";
        ca += "<td align='right'> " + total10 + "%</td>";
        ca += "<td align='right'><a href='docentesEvaluacionintermedia.aspx?resp=Doctorado en educación o pedagogía'>ver detalles</a></td>";
        ca += "</tr>";


        
        total11 = Math.Round(total11, 2);
        ca += "<tr>";
        ca += "<td>Otro doctorado</td>";
        ca += "<td align='right'>" + totalmet.total(totalDocentesNormalista, "12") + "</td>";
        ca += "<td align='right'> " + total11 + "%</td>";
        ca += "<td align='right'><a href='docentesEvaluacionintermedia.aspx?resp=Otro Doctorado'>ver detalles</a></td>";
        ca += "</tr>";



        var totalporcentaje = total0+total1 + total2 + total3 + total4 + total5 + total6 + total7 + total8 + total9 + total10 + total11;
        totalporcentaje = Math.Round(totalporcentaje);
        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>"+ total + "</td>";
        ca += "<td align='right' style='font-weight:bold;'> "+ totalporcentaje + "% </td>";
        ca += "</tr>";


        return ca;
        
    }

    [WebMethod(EnableSession = true)]
    public static string inventariodequipamiento()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        //normalista superior
        DataRow totalDocentesInventarios = lb.totalInventariosxUsuario("Docentes");
        DataRow totalEstudiantesInventarios = lb.totalInventariosxUsuario("Estudiantes");

        //docente
        var totalconexion = (Convert.ToInt32(totalDocentesInventarios["conpc"].ToString()) + Convert.ToInt32(totalDocentesInventarios["conportatil"].ToString()) + Convert.ToInt32(totalDocentesInventarios["contablet"].ToString()) + Convert.ToInt32(totalDocentesInventarios["contableros"].ToString()));
        var totalsinconexion = (Convert.ToInt32(totalDocentesInventarios["sinpc"].ToString()) + Convert.ToInt32(totalDocentesInventarios["sinportatil"].ToString()) + Convert.ToInt32(totalDocentesInventarios["sintablet"].ToString()) + Convert.ToInt32(totalDocentesInventarios["sintableros"].ToString()));
        //estudiante
        var totalconexionEst = (Convert.ToInt32(totalEstudiantesInventarios["conpc"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["conportatil"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["contablet"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["contableros"].ToString()));
        var totalsinconexionEst = (Convert.ToInt32(totalEstudiantesInventarios["sinpc"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["sinportatil"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["sintablet"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["sintableros"].ToString()));

        var totalTCo = (Convert.ToInt32(totalconexion) + Convert.ToInt32(totalconexionEst));
        var totalTSin = (Convert.ToInt32(totalsinconexion) + Convert.ToInt32(totalsinconexionEst));
        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th rowspan='2'>Usuarios</th>";
        ca += "<th colspan='2'>No. PC </th>";
        ca += "<th colspan='2'>No. Portátiles </th>";
        ca += "<th colspan='2'>No. Tablet</th>";
        ca += "<th colspan='2'>No. Tableros inteligentes</th>";
        ca += "<th colspan='4'>Total equipamiento </th>";
        ca += "<th>Detalles</th>";
        ca += "</tr>";
        ca += "<tr>";
        ca += "<th>Con conexión</th>";
        ca += "<th>Sin conexión</th>";
        ca += "<th>Con conexión</th>";
        ca += "<th>Sin conexión</th>";
        ca += "<th>Con conexión</th>";
        ca += "<th>Sin conexión</th>";
        ca += "<th>Con conexión</th>";
        ca += "<th>Sin conexión</th>";

        ca += "<th>Total equipamiento con conexión</th>";
        ca += "<th>Porcentaje equipamiento con conexión</th>";
        ca += "<th>Total equipamiento sin conexión</th>";
        ca += "<th>Porcentaje de equipamiento sin conexión</th>";
        ca += "<td rowspan='4' style='font-weight:bold;'><a href='inventariodequipamiento.aspx'>Ver detalles</a></td>";

        ca += "</tr>";

        ca += "<tr>";
        ca += "<td>Docentes </td>";
        ca += "<td align='right'>" + totalDocentesInventarios["conpc"].ToString() + "</td>";
        ca += "<td align='right'>" + totalDocentesInventarios["sinpc"].ToString() + "</td>";
        ca += "<td align='right'>" + totalDocentesInventarios["conportatil"].ToString() + "</td>";
        ca += "<td align='right'>" + totalDocentesInventarios["sinportatil"].ToString() + "</td>";
        ca += "<td align='right'>" + totalDocentesInventarios["contablet"].ToString() + "</td>";
        ca += "<td align='right'>" + totalDocentesInventarios["sintablet"].ToString() + "</td>";
        ca += "<td align='right'>" + totalDocentesInventarios["contableros"].ToString() + "</td>";
        ca += "<td align='right'>" + totalDocentesInventarios["sintableros"].ToString() + "</td>";

        //--
        
        ca += "<td align='right'>" + totalconexion + "</td>";

        var porcentajeConexionDoc = Math.Round((((double)totalconexion / (double)totalTCo) * 100), 2);
        ca += "<td align='right'>" + porcentajeConexionDoc + "% </td>";

        var porcentajeSinConexionDoc = Math.Round((((double)totalsinconexion / (double)totalTSin) * 100), 2);
        ca += "<td align='right'>" + totalsinconexion + "</td>";
        ca += "<td align='right'>" + porcentajeSinConexionDoc + "% </td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td>Estudiantes </td>";
        ca += "<td align='right'>" + totalEstudiantesInventarios["conpc"].ToString() + "</td>";
        ca += "<td align='right'>" + totalEstudiantesInventarios["sinpc"].ToString() + "</td>";
        ca += "<td align='right'>" + totalEstudiantesInventarios["conportatil"].ToString() + "</td>";
        ca += "<td align='right'>" + totalEstudiantesInventarios["sinportatil"].ToString() + "</td>";
        ca += "<td align='right'>" + totalEstudiantesInventarios["contablet"].ToString() + "</td>";
        ca += "<td align='right'>" + totalEstudiantesInventarios["sintablet"].ToString() + "</td>";
        ca += "<td align='right'>" + totalEstudiantesInventarios["contableros"].ToString() + "</td>";
        ca += "<td align='right'>" + totalEstudiantesInventarios["sintableros"].ToString() + "</td>";
        //--
        
        ca += "<td align='right'>" + totalconexionEst + "</td>";

        var porcentajeConexionEst = Math.Round((((double)totalconexionEst / totalTCo) * 100), 2);
        ca += "<td align='right'>" + porcentajeConexionEst + "% </td>";
        ca += "<td align='right'>" + totalsinconexionEst + "</td>";

        var porcentajeSinConexionEst = Math.Round((((double)totalsinconexionEst / totalTSin) * 100), 2);
        ca += "<td align='right'>" + porcentajeSinConexionEst + "% </td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalDocentesInventarios["conpc"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["conpc"].ToString())) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalDocentesInventarios["sinpc"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["sinpc"].ToString())) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalDocentesInventarios["conportatil"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["conportatil"].ToString())) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalDocentesInventarios["sinportatil"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["sinportatil"].ToString())) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalDocentesInventarios["contablet"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["contablet"].ToString())) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalDocentesInventarios["sintablet"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["sintablet"].ToString())) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalDocentesInventarios["contableros"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["contableros"].ToString())) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalDocentesInventarios["sintableros"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["sintableros"].ToString())) + "</td>";

        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalconexion) + Convert.ToInt32(totalconexionEst)) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (porcentajeConexionDoc + porcentajeConexionEst) + "%</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalsinconexion) + Convert.ToInt32(totalsinconexionEst)) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (porcentajeSinConexionDoc + porcentajeSinConexionEst) + "%</td>";

        ca += "</tr>";

        return ca;

    }

    
    [WebMethod(EnableSession = true)]
    public static string inventariotabletasentregadas()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataRow totalEntregadas = lb.totalTabletsEntregadasxRespuesta("si");
        DataRow totalNoEntregadas = lb.totalTabletsEntregadasxRespuesta("no");
        var total = Convert.ToInt32(totalEntregadas["total"].ToString()) + Convert.ToInt32(totalNoEntregadas["total"].ToString());

        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th>Tabletas entregadas</th>";
        ca += "<th>Número de sedes</th>";
        ca += "<th>Detalle</th>";

        ca += "</tr>";
         
        ca += "<tr>";
        ca += "<td align='right'> SI </td>";
        ca += "<td align='right'>" + totalEntregadas["total"].ToString() + "</td>";
        ca += "<td rowspan='3' style='font-weight:bold;'><a href='inventariotabletasentregadas.aspx'>Ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> NO </td>";
        ca += "<td align='right'>" + totalNoEntregadas["total"].ToString() + "</td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        ca += "</tr></table>";

        return ca;
    }


    
    [WebMethod(EnableSession = true)]
    public static string accesostabletasformacionmaestros()
    {
        string ca = "";
        int total = 0;
        LineaBase lb = new LineaBase();
        DataTable datos = lb.cargarSedesxMunicipioDiligenciandoForm();

      DataTable totalFrecuenciaSiempre = lb.totalAccesostabletasxFrecuencia("Siempre");
      DataTable totalFrecuenciaCasiSiempre = lb.totalAccesostabletasxFrecuencia("Casi Siempre");
      DataTable totalFrecuenciaAlgunasVeces = lb.totalAccesostabletasxFrecuencia("Algunas Veces");
      DataTable totalFrecuenciaMuyPocasVeces = lb.totalAccesostabletasxFrecuencia("Muy pocas Veces");
       DataTable totalFrecuenciaNunca = lb.totalAccesostabletasxFrecuencia("Nunca");

         total = totalFrecuenciaSiempre.Rows.Count + totalFrecuenciaCasiSiempre.Rows.Count + totalFrecuenciaAlgunasVeces.Rows.Count + totalFrecuenciaMuyPocasVeces.Rows.Count + totalFrecuenciaNunca.Rows.Count;
        // var total = (Convert.ToInt32(totalFrecuenciaSiempre["total"].ToString()) + Convert.ToInt32(totalFrecuenciaCasiSiempre["total"].ToString()) + Convert.ToInt32(totalFrecuenciaAlgunasVeces["total"].ToString()) + Convert.ToInt32(totalFrecuenciaNunca["total"].ToString()) + Convert.ToInt32(totalFrecuenciaMuyPocasVeces["total"].ToString()));

        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<table class='mGridTesoreria'>";
            ca += "<tr>";
            ca += "<th colspan='4'>Acceso de las tabletas en la formación de docentes</th>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<th>Frecuencia</th>";
            ca += "<th>Número de sedes</th>";
            ca += "<th>Porcentaje</th>";
            ca += "<th>Ver detalle</th>";
            ca += "</tr>";

            ca += "<tr>";
            ca += "<td align='right'> Siempre </td>";
            ca += "<td align='right'>" + totalFrecuenciaSiempre.Rows.Count + "</td>";
            var porcentajeSiempre = (((double) Convert.ToInt32(totalFrecuenciaSiempre.Rows.Count) / (double) total) * 100);
            ca += "<td align='right'>" + Math.Round(porcentajeSiempre, 2) + "% </td>";
            ca += "<td align='right'> <a href='accesostabletasformacionmaestros.aspx?resp=Siempre'>Ver detalle </a></td>";
            ca += "</tr>";

            ca += "<tr>";
            ca += "<td align='right'> Casi siempre </td>";
            ca += "<td align='right'>" + totalFrecuenciaCasiSiempre.Rows.Count + "</td>";
            var porcentajeCasiSiempre = (((double) Convert.ToInt32(totalFrecuenciaCasiSiempre.Rows.Count) / (double) total) * 100);
            ca += "<td align='right'>" + Math.Round(porcentajeCasiSiempre, 2) + "% </td>";
            ca += "<td align='right'> <a href='accesostabletasformacionmaestros.aspx?resp=Casi Siempre'>Ver detalle </a></td>";
            ca += "</tr>";


            ca += "<tr>";
            ca += "<td align='right'> Algunas veces </td>";
            ca += "<td align='right'>" + totalFrecuenciaAlgunasVeces.Rows.Count + "</td>";
            var porcentajeAlgunasVeces = (((double)Convert.ToInt32(totalFrecuenciaAlgunasVeces.Rows.Count) / (double)total) * 100);
            ca += "<td align='right'>" + Math.Round(porcentajeAlgunasVeces, 2) + "% </td>";
            ca += "<td align='right'> <a href='accesostabletasformacionmaestros.aspx?resp=Algunas Veces'>Ver detalle </a></td>";
            ca += "</tr>";


            ca += "<tr>";
            ca += "<td align='right'> Muy pocas veces </td>";
            ca += "<td align='right'>" + totalFrecuenciaMuyPocasVeces.Rows.Count + "</td>";
            var porcentajeMuyPocasVeces = (((double)Convert.ToInt32(totalFrecuenciaMuyPocasVeces.Rows.Count) / (double)total) * 100);
            ca += "<td align='right'>" + Math.Round(porcentajeMuyPocasVeces, 2) + "% </td>";
            ca += "<td align='right'> <a href='accesostabletasformacionmaestros.aspx?resp=Muy pocas Veces'>Ver detalle </a></td>";
            ca += "</tr>";


            ca += "<tr>";
            ca += "<td align='right'> Nunca </td>";
            ca += "<td align='right'>" + totalFrecuenciaNunca.Rows.Count + "</td>";
            var porcentajeNunca = (((double)Convert.ToInt32(totalFrecuenciaNunca.Rows.Count) / (double)total) * 100);
            ca += "<td align='right'>" + Math.Round(porcentajeNunca, 2) + "% </td>";
            ca += "<td align='right'> <a href='accesostabletasformacionmaestros.aspx?resp=Nunca'>Ver detalle </a></td>";
            ca += "</tr>";


             var totalporcentaje = (porcentajeSiempre + porcentajeCasiSiempre + porcentajeAlgunasVeces + porcentajeMuyPocasVeces + porcentajeNunca);
            ca += "<tr>";
            ca += "<th>TOTAL</th>";
            ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
            ca += "<td align='right' style='font-weight:bold;'>"+ totalporcentaje + "% </td>";
            ca += "<td align='right' style='font-weight:bold;'></td>";
            ca += "</tr>";

        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string Accesosgrupostabletasentregadas()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataRow totalFrecuenciaSiempre = lb.totalAccesostabletasGruposxFrecuencia("Siempre");
        DataRow totalFrecuenciaCasiSiempre = lb.totalAccesostabletasGruposxFrecuencia("Casi Siempre");
        DataRow totalFrecuenciaAlgunasVeces = lb.totalAccesostabletasGruposxFrecuencia("Algunas Veces");
        DataRow totalFrecuenciaMuyPocasVeces = lb.totalAccesostabletasGruposxFrecuencia("Muy pocas Veces");
        DataRow totalFrecuenciaNunca = lb.totalAccesostabletasGruposxFrecuencia("Nunca");

        var total = (Convert.ToInt32(totalFrecuenciaSiempre["total"].ToString()) + Convert.ToInt32(totalFrecuenciaCasiSiempre["total"].ToString()) + Convert.ToInt32(totalFrecuenciaAlgunasVeces["total"].ToString()) + Convert.ToInt32(totalFrecuenciaMuyPocasVeces["total"].ToString()) + Convert.ToInt32(totalFrecuenciaNunca["total"].ToString()));

        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th colspan='4'>Sedes educativas  y uso de tabletas por parte de grupos de investigación</th>";
        ca += "</tr>";
  

        ca += "<tr>";
        ca += "<th>Frecuencia</th>";
        ca += "<th>Número de sedes</th>";
        ca += "<th>Porcentaje</th>";
        ca += "<th>Ver detalle</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> Siempre </td>";
        ca += "<td align='right'>" + totalFrecuenciaSiempre["total"].ToString() + "</td>";
        var porcentajeSiempre = (((double)Convert.ToInt32(totalFrecuenciaSiempre["total"].ToString()) / (double)total) * 100);
        ca += "<td align='right'>" + Math.Round(porcentajeSiempre, 2) + "% </td>";
        ca += "<td align='right'> <a href='accesosgrupostabletasentregadas.aspx?resp=Siempre'>Ver detalle </a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> Casi siempre </td>";
        ca += "<td align='right'>" + totalFrecuenciaCasiSiempre["total"].ToString() + "</td>";
        var porcentajeCasiSiempre = (((double)Convert.ToInt32(totalFrecuenciaCasiSiempre["total"].ToString()) / (double)total) * 100);
        ca += "<td align='right'>" + Math.Round(porcentajeCasiSiempre, 2) + "% </td>";
        ca += "<td align='right'> <a href='accesosgrupostabletasentregadas.aspx?resp=Casi Siempre'>Ver detalle </a></td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td align='right'> Algunas veces </td>";
        ca += "<td align='right'>" + totalFrecuenciaAlgunasVeces["total"].ToString() + "</td>";
        var porcentajeAlgunasVeces = (((double)Convert.ToInt32(totalFrecuenciaAlgunasVeces["total"].ToString()) / (double)total) * 100);
        ca += "<td align='right'>" + Math.Round(porcentajeAlgunasVeces, 2) + "% </td>";
        ca += "<td align='right'> <a href='accesosgrupostabletasentregadas.aspx?resp=Algunas Veces'>Ver detalle </a></td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td align='right'> Muy pocas veces </td>";
        ca += "<td align='right'>" + totalFrecuenciaMuyPocasVeces["total"].ToString() + "</td>";
        var porcentajeMuyPocasVeces = (((double)Convert.ToInt32(totalFrecuenciaMuyPocasVeces["total"].ToString()) / (double)total) * 100);
        ca += "<td align='right'>" + Math.Round(porcentajeMuyPocasVeces,2) + "% </td>";
        ca += "<td align='right'> <a href='accesosgrupostabletasentregadas.aspx?resp=Muy pocas Veces'>Ver detalle </a></td>";
        ca += "</tr>"; 


         ca += "<tr>";
        ca += "<td align='right'> Nunca </td>";
        ca += "<td align='right'>" + totalFrecuenciaNunca["total"].ToString() + "</td>";
        var porcentajeNunca = (((double)Convert.ToInt32(totalFrecuenciaNunca["total"].ToString()) / (double)total) * 100);
        ca += "<td align='right'>" + Math.Round(porcentajeNunca,2) + "% </td>";
        ca += "<td align='right'> <a href='accesosgrupostabletasentregadas.aspx?resp=Nunca'>Ver detalle </a></td>";
        ca += "</tr>";


         var totalporcentaje = (porcentajeSiempre + porcentajeCasiSiempre + porcentajeAlgunasVeces + porcentajeMuyPocasVeces + porcentajeNunca);
        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>"+ totalporcentaje + "%</td>";
        ca += "<td align='right' style='font-weight:bold;'></td>";
        ca += "</tr>";

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string accesosredestabletasentregadas()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataRow totalFrecuenciaSiempre = lb.totalAccesostabletasRedesxFrecuencia("Siempre");
        DataRow totalFrecuenciaCasiSiempre = lb.totalAccesostabletasRedesxFrecuencia("Casi Siempre");
        DataRow totalFrecuenciaAlgunasVeces = lb.totalAccesostabletasRedesxFrecuencia("Algunas Veces");
        DataRow totalFrecuenciaMuyPocasVeces = lb.totalAccesostabletasRedesxFrecuencia("Muy pocas Veces");
        DataRow totalFrecuenciaNunca = lb.totalAccesostabletasRedesxFrecuencia("Nunca");

        var total = (Convert.ToInt32(totalFrecuenciaSiempre["total"].ToString()) + Convert.ToInt32(totalFrecuenciaCasiSiempre["total"].ToString()) + Convert.ToInt32(totalFrecuenciaAlgunasVeces["total"].ToString()) + Convert.ToInt32(totalFrecuenciaNunca["total"].ToString()) + Convert.ToInt32(totalFrecuenciaMuyPocasVeces["total"].ToString())); //

        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th colspan='4'>Sedes educativa y uso de tabletas por parte de las redes temáticas</th>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<th>Frecuencia</th>";
        ca += "<th>Número de sedes</th>";
        ca += "<th>Porcentaje</th>";
        ca += "<th>Ver detalle</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> Siempre </td>";
        ca += "<td align='right'>" + totalFrecuenciaSiempre["total"].ToString() + "</td>";
        var porcentajeSiempre = (((double)Convert.ToInt32(totalFrecuenciaSiempre["total"].ToString()) / (double)total) * 100);
        ca += "<td align='right'>" + Math.Round(porcentajeSiempre, 2) + "% </td>";
        ca += "<td align='right'> <a href='accesosredestabletasentregadas.aspx?resp=Siempre'>Ver detalle </a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> Casi siempre </td>";
        ca += "<td align='right'>" + totalFrecuenciaCasiSiempre["total"].ToString() + "</td>";
        var porcentajeCasiSiempre = (((double)Convert.ToInt32(totalFrecuenciaCasiSiempre["total"].ToString()) / (double)total) * 100);
        ca += "<td align='right'>" + Math.Round(porcentajeCasiSiempre, 2) + "% </td>";
        ca += "<td align='right'> <a href='accesosredestabletasentregadas.aspx?resp=Casi Siempre'>Ver detalle </a></td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td align='right'> Algunas veces </td>";
        ca += "<td align='right'>" + totalFrecuenciaAlgunasVeces["total"].ToString() + "</td>";
        var porcentajeAlgunasVeces = (((double)Convert.ToInt32(totalFrecuenciaAlgunasVeces["total"].ToString()) / (double)total) * 100);
        ca += "<td align='right'>" + Math.Round(porcentajeAlgunasVeces, 2) + "% </td>";
        ca += "<td align='right'> <a href='accesosredestabletasentregadas.aspx?resp=Algunas Veces'>Ver detalle </a></td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td align='right'> Muy pocas veces </td>";
        ca += "<td align='right'>" + totalFrecuenciaMuyPocasVeces["total"].ToString() + "</td>";
        var porcentajeMuyPocasVeces = (((double)Convert.ToInt32(totalFrecuenciaMuyPocasVeces["total"].ToString()) / (double)total) * 100);
        ca += "<td align='right'>" + Math.Round(porcentajeMuyPocasVeces, 2) + "% </td>";
        ca += "<td align='right'> <a href='accesosredestabletasentregadas.aspx?resp=Muy pocas Veces'>Ver detalle </a></td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td align='right'> Nunca </td>";
        ca += "<td align='right'>" + totalFrecuenciaNunca["total"].ToString() + "</td>";
        var porcentajeNunca = (((double)Convert.ToInt32(totalFrecuenciaNunca["total"].ToString()) / (double)total) * 100);
        ca += "<td align='right'>" + Math.Round(porcentajeNunca, 2) + "% </td>";
        ca += "<td align='right'> <a href='accesosredestabletasentregadas.aspx?resp=Nunca'>Ver detalle </a></td>";
        ca += "</tr>";


        var totalporcentaje = (porcentajeSiempre + porcentajeCasiSiempre + porcentajeAlgunasVeces + porcentajeMuyPocasVeces + porcentajeNunca);
        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>"+ totalporcentaje + "%</td>";
        ca += "<td align='right' style='font-weight:bold;'></td>";
        ca += "</tr>";

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string sedeseducativasservicioconectividad()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataRow totalConConexion = lb.totalsedeseducativasservicioconectividad("si");
        DataRow totalSinConexion = lb.totalsedeseducativasservicioconectividad("no");

        var total = Convert.ToInt32(totalConConexion["total"].ToString()) + Convert.ToInt32(totalSinConexion["total"].ToString());

        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th>Conectividad en las sedes</th>";
        ca += "<th>Número</th>";
        ca += "<th>Porcentaje</th>";
        ca += "<th>Detalles</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> SI </td>";
        ca += "<td align='right'>" + totalConConexion["total"].ToString() + "</td>";
        var porcentajeSi = (((double)Convert.ToInt32(totalConConexion["total"].ToString()) / (double)total) * 100);
        ca += "<td align='right'>" + Math.Round(porcentajeSi, 2) + "%</td>";
        ca += "<td align='right'><a href='sedeseducativasservicioconectividad.aspx?resp=si'>Ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> NO </td>";
        ca += "<td align='right'>" + totalSinConexion["total"].ToString() + "</td>";
        var porcentajeNo = (((double)Convert.ToInt32(totalSinConexion["total"].ToString()) / (double)total) * 100);
        ca += "<td align='right'>" + Math.Round(porcentajeNo, 2) + "%</td>";
        ca += "<td align='right'><a href='sedeseducativasservicioconectividad.aspx?resp=no'>Ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        var porcentajeTotal = (porcentajeSi + porcentajeNo);
        ca += "<td align='right' style='font-weight:bold;'>" + porcentajeTotal + "%</td>";
        ca += "</tr>";

        return ca;
    }

    

    [WebMethod(EnableSession = true)]
    public static string usoconectividadformacionmaestros()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataRow totalFrecuenciaSiempre = lb.totalUsoconectividadformacionmaestrosxFrecuencia("Siempre");
        DataRow totalFrecuenciaCasiSiempre = lb.totalUsoconectividadformacionmaestrosxFrecuencia("Casi Siempre");
        DataRow totalFrecuenciaAlgunasVeces = lb.totalUsoconectividadformacionmaestrosxFrecuencia("Algunas Veces");
        DataRow totalFrecuenciaMuyPocasVeces = lb.totalUsoconectividadformacionmaestrosxFrecuencia("Muy pocas Veces");
        DataRow totalFrecuenciaNunca = lb.totalUsoconectividadformacionmaestrosxFrecuencia("Nunca");

        var total = (Convert.ToInt32(totalFrecuenciaSiempre["total"].ToString()) + Convert.ToInt32(totalFrecuenciaCasiSiempre["total"].ToString()) + Convert.ToInt32(totalFrecuenciaAlgunasVeces["total"].ToString()) + Convert.ToInt32(totalFrecuenciaNunca["total"].ToString()) + Convert.ToInt32(totalFrecuenciaMuyPocasVeces["total"].ToString()));

        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th colspan='4'>Sedes educativa y uso de conectividad en la formación de maestros</th>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<th>Frecuencia</th>";
        ca += "<th>Número</th>";
        ca += "<th>Porcentaje</th>";
        ca += "<th>Ver detalle</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> Siempre </td>";
        ca += "<td align='right'>" + totalFrecuenciaSiempre["total"].ToString() + "</td>";
        var porcentajeSiempre = (((double)Convert.ToInt32(totalFrecuenciaSiempre["total"].ToString()) / (double)total) * 100);
        ca += "<td align='right'>" + Math.Round(porcentajeSiempre, 2) + "% </td>";
        ca += "<td align='right'> <a href='usoconectividadformacionmaestros.aspx?resp=Siempre'>Ver detalle </a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> Casi siempre </td>";
        ca += "<td align='right'>" + totalFrecuenciaCasiSiempre["total"].ToString() + "</td>";
        var porcentajeCasiSiempre = (((double)Convert.ToInt32(totalFrecuenciaCasiSiempre["total"].ToString()) / (double)total) * 100);
        ca += "<td align='right'>" + Math.Round(porcentajeCasiSiempre, 2) + "% </td>";
        ca += "<td align='right'> <a href='usoconectividadformacionmaestros.aspx?resp=Casi Siempre'>Ver detalle </a></td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td align='right'> Algunas veces </td>";
        ca += "<td align='right'>" + totalFrecuenciaAlgunasVeces["total"].ToString() + "</td>";
        var porcentajeAlgunasVeces = (((double)Convert.ToInt32(totalFrecuenciaAlgunasVeces["total"].ToString()) / (double)total) * 100);
        ca += "<td align='right'>" + Math.Round(porcentajeAlgunasVeces, 2) + "% </td>";
        ca += "<td align='right'> <a href='usoconectividadformacionmaestros.aspx?resp=Algunas Veces'>Ver detalle </a></td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td align='right'> Muy pocas veces </td>";
        ca += "<td align='right'>" + totalFrecuenciaMuyPocasVeces["total"].ToString() + "</td>";
        var porcentajeMuyPocasVeces = (((double)Convert.ToInt32(totalFrecuenciaMuyPocasVeces["total"].ToString()) / (double)total) * 100);
        ca += "<td align='right'>" + Math.Round(porcentajeMuyPocasVeces, 2) + "% </td>";
        ca += "<td align='right'> <a href='usoconectividadformacionmaestros.aspx?resp=Muy pocas Veces'>Ver detalle </a></td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td align='right'> Nunca </td>";
        ca += "<td align='right'>" + totalFrecuenciaNunca["total"].ToString() + "</td>";
        var porcentajeNunca = (((double)Convert.ToInt32(totalFrecuenciaNunca["total"].ToString()) / (double)total) * 100);
        ca += "<td align='right'>" + Math.Round(porcentajeNunca, 2) + "% </td>";
        ca += "<td align='right'> <a href='usoconectividadformacionmaestros.aspx?resp=Nunca'>Ver detalle </a></td>";
        ca += "</tr>";

        var totalporcentaje = (porcentajeSiempre + porcentajeCasiSiempre + porcentajeAlgunasVeces + porcentajeMuyPocasVeces + porcentajeNunca);
        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>"+ totalporcentaje + "%</td>";
        ca += "<td align='right' style='font-weight:bold;'></td>";
        ca += "</tr>";

        return ca;
    }


    
    [WebMethod(EnableSession = true)]
    public static string sedesbeneficiadasconectividadentregado()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataRow totalConConexion = lb.totalSedesbeneficiadasconectividadentregado("si");
        DataRow totalSinConexion = lb.totalSedesbeneficiadasconectividadentregado("no");

        var total = Convert.ToInt32(totalConConexion["total"].ToString()) + Convert.ToInt32(totalSinConexion["total"].ToString());

        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th>Conectividad en las sedes</th>";
        ca += "<th>Número</th>";
        ca += "<th>Porcentaje</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> SI </td>";
        ca += "<td align='right'>" + totalConConexion["total"].ToString() + "</td>";
        var porcentajeSi = (((double)Convert.ToInt32(totalConConexion["total"].ToString()) / (double)total) * 100);
        ca += "<td align='right'>" + Math.Round(porcentajeSi, 2) + "%</td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> NO </td>";
        ca += "<td align='right'>" + totalSinConexion["total"].ToString() + "</td>";
        var porcentajeNo = (((double)Convert.ToInt32(totalSinConexion["total"].ToString()) / (double)total) * 100);
        ca += "<td align='right'>" + Math.Round(porcentajeNo, 2) + "%</td>";
        
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        var porcentajeTotal = (porcentajeSi + porcentajeNo);
        ca += "<td align='right' style='font-weight:bold;'>" + porcentajeTotal + "%</td>";

        ca += "</tr>";

        return ca;
    }


    
    [WebMethod(EnableSession = true)]
    public static string usoconectividadtrabajoredes()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataRow totalFrecuenciaSiempre = lb.totalUsoconectividadtrabajoredesxFrecuencia("Siempre");
        DataRow totalFrecuenciaCasiSiempre = lb.totalUsoconectividadtrabajoredesxFrecuencia("Casi Siempre");
        DataRow totalFrecuenciaAlgunasVeces = lb.totalUsoconectividadtrabajoredesxFrecuencia("Algunas Veces");
        DataRow totalFrecuenciaMuyPocasVeces = lb.totalUsoconectividadtrabajoredesxFrecuencia("Muy pocas Veces");
        DataRow totalFrecuenciaNunca = lb.totalUsoconectividadtrabajoredesxFrecuencia("Nunca");

        var total = (Convert.ToInt32(totalFrecuenciaSiempre["total"].ToString()) + Convert.ToInt32(totalFrecuenciaCasiSiempre["total"].ToString()) + Convert.ToInt32(totalFrecuenciaAlgunasVeces["total"].ToString()) + Convert.ToInt32(totalFrecuenciaMuyPocasVeces["total"].ToString()) + Convert.ToInt32(totalFrecuenciaNunca["total"].ToString()));

        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th colspan='4'>Sedes educativa y uso de conectividad para el trabajo de las redes temáticas</th>";
        ca += "</tr>";
        ca += "<tr>";
        ca += "<th>Frecuencia</th>";
        ca += "<th>Número</th>";
        ca += "<th>Porcentaje</th>";
        ca += "<th>Ver detalle</th>";
        ca += "</tr>";
        ca += "<tr>";
        ca += "<td align='right'> Siempre </td>";
        ca += "<td align='right'>" + totalFrecuenciaSiempre["total"].ToString() + "</td>";
        var porcentajeSiempre = Math.Round((((double)Convert.ToInt32(totalFrecuenciaSiempre["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeSiempre + "% </td>";
        ca += "<td align='right'> <a href='usoconectividadtrabajoredes.aspx?resp=Siempre'>Ver detalle </a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> Casi siempre </td>";
        ca += "<td align='right'>" + totalFrecuenciaCasiSiempre["total"].ToString() + "</td>";
        var porcentajeCasiSiempre = Math.Round((((double)Convert.ToInt32(totalFrecuenciaCasiSiempre["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeCasiSiempre + "% </td>";
        ca += "<td align='right'> <a href='usoconectividadtrabajoredes.aspx?resp=Casi Siempre'>Ver detalle </a></td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td align='right'> Algunas veces </td>";
        ca += "<td align='right'>" + totalFrecuenciaAlgunasVeces["total"].ToString() + "</td>";
        var porcentajeAlgunasVeces = Math.Round((((double)Convert.ToInt32(totalFrecuenciaAlgunasVeces["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeAlgunasVeces + "% </td>";
        ca += "<td align='right'> <a href='usoconectividadtrabajoredes.aspx?resp=Algunas Veces'>Ver detalle </a></td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td align='right'> Muy pocas veces </td>";
        ca += "<td align='right'>" + totalFrecuenciaMuyPocasVeces["total"].ToString() + "</td>";
        var porcentajeMuyPocasVeces = Math.Round((((double)Convert.ToInt32(totalFrecuenciaMuyPocasVeces["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeMuyPocasVeces + "% </td>";
        ca += "<td align='right'> <a href='usoconectividadtrabajoredes.aspx?resp=Muy pocas Veces'>Ver detalle </a></td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td align='right'> Nunca </td>";
        ca += "<td align='right'>" + totalFrecuenciaNunca["total"].ToString() + "</td>";
        var porcentajeNunca = Math.Round((((double)Convert.ToInt32(totalFrecuenciaNunca["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeNunca + "% </td>";
        ca += "<td align='right'> <a href='usoconectividadtrabajoredes.aspx?resp=Nunca'>Ver detalle </a></td>";
        ca += "</tr>";


         var totalporcentaje = (porcentajeSiempre + porcentajeCasiSiempre + porcentajeAlgunasVeces + porcentajeMuyPocasVeces + porcentajeNunca);
        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>"+ totalporcentaje + "%</td>";
        ca += "<td align='right' style='font-weight:bold;'></td>";
        ca += "</tr>";

        return ca;
    }



    [WebMethod(EnableSession = true)]
    public static string herramientaswebsedes()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataRow totalHerramientaRedesSociales = lb.totalHerramientaswebsedesxHerramienta("Redes sociales");
        DataRow totalHerramientaWikis = lb.totalHerramientaswebsedesxHerramienta("Wikis");
        DataRow totalHerramientaBlogs = lb.totalHerramientaswebsedesxHerramienta("Blogs");
        DataRow totalHerramientaForos = lb.totalHerramientaswebsedesxHerramienta("Foros");
        DataRow totalHerramientaPagina = lb.totalHerramientaswebsedesxHerramienta("Página de internet");

        DataRow totalHerramientaNN = lb.totalHerramientaswebsedesxHerramienta("N / A");


        var total = (Convert.ToInt32(totalHerramientaRedesSociales["total"].ToString()) + Convert.ToInt32(totalHerramientaWikis["total"].ToString()) + Convert.ToInt32(totalHerramientaBlogs["total"].ToString()) + Convert.ToInt32(totalHerramientaForos["total"].ToString()) + Convert.ToInt32(totalHerramientaPagina["total"].ToString()) + Convert.ToInt32(totalHerramientaNN["total"].ToString()));


        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th colspan='4'>Herramientas web de las sedes educativas</th>";
        ca += "</tr>";
        ca += "<tr>";
        ca += "<th>Frecuencia</th>";
        ca += "<th>Número</th>";
        ca += "<th>Porcentaje</th>";
        ca += "<th>Ver detalle</th>";
        ca += "</tr>";
        ca += "<tr>";
        ca += "<td align='right'> Redes sociales </td>";
        ca += "<td align='right'>" + totalHerramientaRedesSociales["total"].ToString() + "</td>";
        var porcentajeHerramientaRedesSociales = Math.Round((((double)Convert.ToInt32(totalHerramientaRedesSociales["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeHerramientaRedesSociales + "% </td>";
        ca += "<td align='right'> <a href='herramientaswebsedes.aspx?resp=Redes sociales'>Ver detalle </a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> Wikis </td>";
        ca += "<td align='right'>" + totalHerramientaWikis["total"].ToString() + "</td>";
        var porcentajeHerramientaWikis = Math.Round((((double)Convert.ToInt32(totalHerramientaWikis["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeHerramientaWikis + "% </td>";
        ca += "<td align='right'> <a href='herramientaswebsedes.aspx?resp=Wikis'>Ver detalle </a></td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td align='right'> Blogs </td>";
        ca += "<td align='right'>" + totalHerramientaBlogs["total"].ToString() + "</td>";
        var porcentajeHerramientaBlogs = Math.Round((((double)Convert.ToInt32(totalHerramientaBlogs["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeHerramientaBlogs + "% </td>";
        ca += "<td align='right'> <a href='herramientaswebsedes.aspx?resp=Blogs'>Ver detalle </a></td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td align='right'> Foros </td>";
        ca += "<td align='right'>" + totalHerramientaForos["total"].ToString() + "</td>";
        var porcentajeHerramientaForos = Math.Round((((double)Convert.ToInt32(totalHerramientaForos["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeHerramientaForos + "% </td>";
        ca += "<td align='right'> <a href='herramientaswebsedes.aspx?resp=Foros'>Ver detalle </a></td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td align='right'> Página de internet </td>";
        ca += "<td align='right'>" + totalHerramientaPagina["total"].ToString() + "</td>";
        var porcentajeHerramientaPagina = Math.Round((((double)Convert.ToInt32(totalHerramientaPagina["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeHerramientaPagina + "% </td>";
        ca += "<td align='right'> <a href='herramientaswebsedes.aspx?resp=Página de internet'>Ver detalle </a></td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td align='right'> N / A </td>";
        ca += "<td align='right'>" + totalHerramientaNN["total"].ToString() + "</td>";
        var porcentajeHerramientaNN = Math.Round((((double)Convert.ToInt32(totalHerramientaNN["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeHerramientaNN + "% </td>";
        ca += "<td align='right'> <a href='herramientaswebsedes.aspx?resp=N / A'>Ver detalle </a></td>";
        ca += "</tr>";


         var totalporcentaje = (porcentajeHerramientaRedesSociales + porcentajeHerramientaWikis + porcentajeHerramientaBlogs + porcentajeHerramientaForos + porcentajeHerramientaPagina + porcentajeHerramientaNN);
        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>"+ totalporcentaje + "%</td>";
        ca += "<td align='right' style='font-weight:bold;'></td>";
        ca += "</tr>";

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string plataformasPedagogicasSedes()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataRow totalConConexion = lb.totalPlataformasPedagogicasSedesSi();
        DataRow totalSinConexion = lb.totalPlataformasPedagogicasSedesNo();

        var total = Convert.ToInt32(totalConConexion["total"].ToString()) + Convert.ToInt32(totalSinConexion["total"].ToString());

        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th>Plataformas pedagógica</th>";
        ca += "<th>Número</th>";
        ca += "<th>Porcentaje</th>";
        ca += "<th>Detalle</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> SI </td>";
        ca += "<td align='right'>" + totalConConexion["total"].ToString() + "</td>";
        var porcentajeSi = Math.Round((((double)Convert.ToInt32(totalConConexion["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeSi + "%</td>";
        ca += "<td align='right'><a href='plataformaspedagogicassedes.aspx?resp=si'>Ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> NO </td>";
        ca += "<td align='right'>" + totalSinConexion["total"].ToString() + "</td>";
        var porcentajeNo = Math.Round((((double)Convert.ToInt32(totalSinConexion["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeNo + "%</td>";
        ca += "<td align='right'><a href='plataformaspedagogicassedes.aspx?resp=no'>Ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        var totalPorcentaje = (porcentajeSi + porcentajeNo);
        ca += "<td align='right' style='font-weight:bold;'>"+ totalPorcentaje + "%</td>";
        ca += "<td align='right' style='font-weight:bold;'></td>";
        ca += "</tr>";

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string participacionProcesosFormacionDocentes()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataRow totalConConexion = lb.totalParticipacionProcesosFormacionDocentesSi();
        DataRow totalSinConexion = lb.totalParticipacionProcesosFormacionDocentesNo();

        var total = Convert.ToInt32(totalConConexion["total"].ToString()) + Convert.ToInt32(totalSinConexion["total"].ToString());

        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th>Participación en proceso de formación sobre TIC</th>";
        ca += "<th>Número</th>";
        ca += "<th>Porcentaje</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> SI </td>";
        ca += "<td align='right'>" + totalConConexion["total"].ToString() + "</td>";
        var porcentajeSi = Math.Round((((double)Convert.ToInt32(totalConConexion["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeSi + "%</td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> NO </td>";
        ca += "<td align='right'>" + totalSinConexion["total"].ToString() + "</td>";
        var porcentajeNo = Math.Round((((double)Convert.ToInt32(totalSinConexion["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeNo + "%</td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        var totalPorcentaje = (porcentajeSi + porcentajeNo);

        ca += "<td align='right' style='font-weight:bold;'>"+ totalPorcentaje + "%</td>";
        ca += "</tr>";

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string sedesEducativasTresPlanesdeMejoramiento()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataRow totalConConexion = lb.totalsedesEducativasTresPlanesdeMejoramientoSi();
        DataRow totalSinConexion = lb.totalsedesEducativasTresPlanesdeMejoramientoNo();

        var total = Convert.ToInt32(totalConConexion["total"].ToString()) + Convert.ToInt32(totalSinConexion["total"].ToString());

        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th>Inclusión de las TIC </th>";
        ca += "<th>Número de sedes educativas</th>";
        ca += "<th>Porcentaje</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> SI </td>";
        ca += "<td align='right'>" + totalConConexion["total"].ToString() + "</td>";
        var porcentajeSi = Math.Round((((double)Convert.ToInt32(totalConConexion["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeSi + "% </td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> NO </td>";
        ca += "<td align='right'>" + totalSinConexion["total"].ToString() + "</td>";
        var porcentajeNo = Math.Round((((double)Convert.ToInt32(totalSinConexion["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeNo + "% </td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        var totalPorcentaje = (porcentajeSi + porcentajeNo);

        ca += "<td align='right' style='font-weight:bold;'>"+ totalPorcentaje + "%</td>";
        ca += "</tr>";

        return ca;
    }




    [WebMethod(EnableSession = true)]
    public static string percepcionefectosincorporacionTICsedes()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataRow totalConConexion = lb.totalpercepcionefectosincorporacionTICsedesSi();
        DataRow totalSinConexion = lb.totalpercepcionefectosincorporacionTICsedesNo();

        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th>Inclusión de las TIC </th>";
        ca += "<th>Número de sedes educativas</th>";
        ca += "<th>Porcentaje</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> SI </td>";
        ca += "<td align='right'>" + totalConConexion["total"].ToString() + "</td>";
        var porcentajeSi = Math.Round((((double)Convert.ToInt32(totalConConexion["total"].ToString()) / (double)320) * 100), 2);
        ca += "<td align='right'>" + porcentajeSi + "% </td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> NO </td>";
        ca += "<td align='right'>" + totalSinConexion["total"].ToString() + "</td>";
        var porcentajeNo = Math.Round((((double)Convert.ToInt32(totalSinConexion["total"].ToString()) / (double)320) * 100), 2);
        ca += "<td align='right'>" + porcentajeNo + "% </td>";
        ca += "</tr>";

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string modificacionescurriculosdirigidas()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataRow totalConConexion = lb.totalCurriculosModificados();
        DataRow totalSinConexion = lb.totalCurriculosNoModificados();

        var total = Convert.ToInt32(totalConConexion["total"].ToString()) + Convert.ToInt32(totalSinConexion["total"].ToString());

        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th>Modificaciones al currículo</th>";
        ca += "<th>Número de docentes</th>";
        ca += "<th>Porcentaje</th>";
        //ca += "<th>Detalle</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> SI </td>";
        ca += "<td align='right'>" + totalConConexion["total"].ToString() + "</td>";
        var porcentajeSi = Math.Round((((double)Convert.ToInt32(totalConConexion["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeSi + "% </td>";
        //ca += "<td align='right'><a href='#!'>Ver detalle</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> NO </td>";
        ca += "<td align='right'>" + totalSinConexion["total"].ToString() + "</td>";
        var porcentajeNo = Math.Round((((double)Convert.ToInt32(totalSinConexion["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeNo + "% </td>";
        //ca += "<td align='right'><a href='#!'>Ver detalle</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        var totalPorcentaje = (porcentajeSi + porcentajeNo);

        ca += "<td align='right' style='font-weight:bold;'>"+totalPorcentaje+"%</td>";
        //ca += "<td align='right' style='font-weight:bold;'></td>";
        ca += "</tr>";

        return ca;
    }

    
    [WebMethod(EnableSession = true)]
    public static string modeloeducativoinstitucion()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataRow totalConConexion = lb.totalFavoreceElModeloxRespuesta("si");
        DataRow totalSinConexion = lb.totalFavoreceElModeloxRespuesta("no");

        var total = Convert.ToInt32(totalConConexion["total"].ToString()) + Convert.ToInt32(totalSinConexion["total"].ToString());

        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th>Favorece el modelo pedagógico la incorporación de la IEP</th>";
        ca += "<th>Número de docentes</th>";
        ca += "<th>Porcentaje</th>";
        ca += "<th>Detalle</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> SI </td>";
        ca += "<td align='right'>" + totalConConexion["total"].ToString() + "</td>";
        var porcentajeSi = Math.Round((((double)Convert.ToInt32(totalConConexion["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeSi + "% </td>";
        ca += "<td align='right'><a href='modeloeducativoinstitucion.aspx?resp=si'>Ver detalle</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> NO </td>";
        ca += "<td align='right'>" + totalSinConexion["total"].ToString() + "</td>";
        var porcentajeNo = Math.Round((((double)Convert.ToInt32(totalSinConexion["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeNo + "% </td>";
        ca += "<td align='right'><a href='modeloeducativoinstitucion.aspx?resp=no'>Ver detalle</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        var totalPorcentaje = (porcentajeSi + porcentajeNo);

        ca += "<td align='right' style='font-weight:bold;'>"+totalPorcentaje+"%</td>";
        ca += "<td align='right' style='font-weight:bold;'></td>";
        ca += "</tr>";

        return ca;
    }


    
    [WebMethod(EnableSession = true)]
    public static string docentesmodificaronpracticapedagogica()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataRow totalConConexion = lb.totaldocentesModificaronPracticaxRespuesta("si");
        DataRow totalSinConexion = lb.totaldocentesModificaronPracticaxRespuesta("no");

        var total = Convert.ToInt32(totalConConexion["total"].ToString()) + Convert.ToInt32(totalSinConexion["total"].ToString());

        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th colspan='4'>Se modificó la práctica pedagógica a partir de la formación en la IEP poyada en TIC</th>";
        ca += "</tr>";
        ca += "<tr>";
        ca += "<th></th>";
        ca += "<th>Número</th>";
        ca += "<th>Porcentaje</th>";
        ca += "<th>Detalle</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> SI </td>";
        ca += "<td align='right'>" + totalConConexion["total"].ToString() + "</td>";
        var porcentajeSi = Math.Round((((double)Convert.ToInt32(totalConConexion["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeSi + "% </td>";
        ca += "<td align='right'><a href='docentesmodificaronpracticapedagogica.aspx?resp=si'>Ver detalle</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> NO </td>";
        ca += "<td align='right'>" + totalSinConexion["total"].ToString() + "</td>";
        var porcentajeNo = Math.Round((((double)Convert.ToInt32(totalSinConexion["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeNo + "% </td>";
        ca += "<td align='right'><a href='docentesmodificaronpracticapedagogica.aspx?resp=no'>Ver detalle</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        var totalPorcentaje = (porcentajeSi + porcentajeNo);

        ca += "<td align='right' style='font-weight:bold;'>"+totalPorcentaje+"%</td>";
        ca += "<td align='right' style='font-weight:bold;'></td>";
        ca += "</tr>";

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string maestrosincluyenelusoTIC()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataRow totalTicPC = lb.totalMaestrosIncluyentexTIC("PC");
        DataRow totalTicPortatil = lb.totalMaestrosIncluyentexTIC("Portátil");
        DataRow totalTicTableta = lb.totalMaestrosIncluyentexTIC("Tableta");
        DataRow totalTicCorreo = lb.totalMaestrosIncluyentexTIC("Correo electrónico");
        DataRow totalTicTablero = lb.totalMaestrosIncluyentexTIC("Tablero inteligente");

        DataRow totalTicSoftwareEducativo = lb.totalHerramientaswebsedesxHerramienta("Software educativo");
        DataRow totalTicWikis = lb.totalHerramientaswebsedesxHerramienta("Wikis");
        DataRow totalTicBlog = lb.totalHerramientaswebsedesxHerramienta("Blog");
        DataRow totalTicForos = lb.totalHerramientaswebsedesxHerramienta("Foros");
        DataRow totalTicOtras = lb.totalHerramientaswebsedesxHerramienta("Otras");

        var total = (Convert.ToInt32(totalTicPC["total"].ToString()) + Convert.ToInt32(totalTicPortatil["total"].ToString()) + Convert.ToInt32(totalTicTableta["total"].ToString()) + Convert.ToInt32(totalTicCorreo["total"].ToString()) + Convert.ToInt32(totalTicTablero["total"].ToString()) + Convert.ToInt32(totalTicSoftwareEducativo["total"].ToString()) + Convert.ToInt32(totalTicWikis["total"].ToString()) + Convert.ToInt32(totalTicBlog["total"].ToString()) + Convert.ToInt32(totalTicForos["total"].ToString()) + Convert.ToInt32(totalTicOtras["total"].ToString()));


        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th>Herramientas TIC que hacen parte de las prácticas</th>";
        ca += "<th>Número</th>";
        ca += "<th>Porcentaje</th>";
        ca += "</tr>";
        ca += "<tr>";
        ca += "<td align='right'> PC </td>";
        ca += "<td align='right'>" + totalTicPC["total"].ToString() + "</td>";
        var porcentajeTicPC = Math.Round((((double)Convert.ToInt32(totalTicPC["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeTicPC + "% </td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> Portátil </td>";
        ca += "<td align='right'>" + totalTicPortatil["total"].ToString() + "</td>";
        var porcentajeTicPortatil = Math.Round((((double)Convert.ToInt32(totalTicPortatil["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeTicPortatil + "% </td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td align='right'> Tableta </td>";
        ca += "<td align='right'>" + totalTicTableta["total"].ToString() + "</td>";
        var porcentajeTicTableta = Math.Round((((double)Convert.ToInt32(totalTicTableta["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeTicTableta + "% </td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td align='right'> Correo eléctronico </td>";
        ca += "<td align='right'>" + totalTicCorreo["total"].ToString() + "</td>";
        var porcentajeTicCorreo = Math.Round((((double)Convert.ToInt32(totalTicCorreo["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeTicCorreo + "% </td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td align='right'> Tablero inteligente </td>";
        ca += "<td align='right'>" + totalTicTablero["total"].ToString() + "</td>";
        var porcentajeTicTablero = Math.Round((((double)Convert.ToInt32(totalTicTablero["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeTicTablero + "% </td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td align='right'> Software educativo </td>";
        ca += "<td align='right'>" + totalTicSoftwareEducativo["total"].ToString() + "</td>";
        var porcentajeTicSoftwareEducativo = Math.Round((((double)Convert.ToInt32(totalTicSoftwareEducativo["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeTicSoftwareEducativo + "% </td>";
        ca += "</tr>";


  
        ca += "<tr>";
        ca += "<td align='right'> Wikis </td>";
        ca += "<td align='right'>" + totalTicWikis["total"].ToString() + "</td>";
        var porcentajeTicWikis = Math.Round((((double)Convert.ToInt32(totalTicWikis["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeTicWikis + "% </td>";
        ca += "</tr>";

        

        ca += "<tr>";
        ca += "<td align='right'> Blogs </td>";
        ca += "<td align='right'>" + totalTicBlog["total"].ToString() + "</td>";
        var porcentajeTicBlog = Math.Round((((double)Convert.ToInt32(totalTicBlog["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeTicBlog + "% </td>";
        ca += "</tr>";


        
        ca += "<tr>";
        ca += "<td align='right'> Foros </td>";
        ca += "<td align='right'>" + totalTicForos["total"].ToString() + "</td>";
        var porcentajeTicForos = Math.Round((((double)Convert.ToInt32(totalTicForos["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeTicForos + "% </td>";
        ca += "</tr>";



        ca += "<tr>";
        ca += "<td align='right'> Otras </td>";
        ca += "<td align='right'>" + totalTicOtras["total"].ToString() + "</td>";
        var porcentajeTicOtras = Math.Round((((double)Convert.ToInt32(totalTicOtras["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeTicOtras + "% </td>";
        ca += "</tr>";



        var totalporcentaje = (porcentajeTicPC + porcentajeTicPortatil + porcentajeTicTableta + porcentajeTicCorreo + porcentajeTicTablero + porcentajeTicSoftwareEducativo + porcentajeTicWikis + porcentajeTicBlog + porcentajeTicForos + porcentajeTicOtras);
        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>"+totalporcentaje+"%</td>";
        ca += "</tr>";

        return ca;
    }




    [WebMethod(EnableSession = true)]
    public static string actualizacionPEI()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataRow totalConConexion = lb.totalActualizacionPEISi();
        DataRow totalSinConexion = lb.totalActualizacionPEINo();

        var total = Convert.ToInt32(totalConConexion["total"].ToString()) + Convert.ToInt32(totalSinConexion["total"].ToString());

        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th>Actualización del PEI</th>";
        ca += "<th>Después de 01/12/2017</th>";
        ca += "<th>Porcentaje</th>";
        ca += "<th>Detalle</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> SI </td>";
        ca += "<td align='right'>" + totalConConexion["total"].ToString() + "</td>";
        var porcentajeSi = Math.Round((((double)Convert.ToInt32(totalConConexion["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeSi + "% </td>";
        ca += "<td align='right'><a href='actualizacionpei.aspx?resp=si'>Ver detalle</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> NO </td>";
        ca += "<td align='right'>" + totalSinConexion["total"].ToString() + "</td>";
        var porcentajeNo = Math.Round((((double)Convert.ToInt32(totalSinConexion["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeNo + "% </td>";
        ca += "<td align='right'><a href='actualizacionpei.aspx?resp=no'>Ver detalle</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        var totalPorcentaje = (porcentajeSi + porcentajeNo);

        ca += "<td align='right' style='font-weight:bold;'>"+totalPorcentaje+"%</td>";
        ca += "<td align='right' style='font-weight:bold;'></td>";
        ca += "</tr>";

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string sedesincluyenformativos()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        

        DataRow totalSI = lb.totalSedesIncluyenFormativosSI();
        DataRow totalNO = lb.totalSedesIncluyenFormativosNO();

        var total = Convert.ToInt32(totalSI["total"].ToString()) + Convert.ToInt32(totalNO["total"].ToString());

        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th>Ciencia, tecnología, Innovación, investigación</th>";
        ca += "<th>Número de instituciones educativas</th>";
        ca += "<th>Porcentaje</th>";
        ca += "<th>Detalles</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> SI </td>";
        ca += "<td align='right'>" + totalSI["total"].ToString() + "</td>";
        var porcentajeSI = Math.Round((((double)Convert.ToInt32(totalSI["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeSI + "%</td>";
        ca += "<td align='right'> <a href='sedesincluyenformativos.aspx?resp=si'>ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> NO </td>";
        ca += "<td align='right'>" + totalNO["total"].ToString() + "</td>";
        var porcentajeNO = Math.Round((((double)Convert.ToInt32(totalNO["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeNO + "%</td>";
        ca += "<td align='right'> <a href='sedesincluyenformativos.aspx?resp=no'>ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        var totalPorcentaje = (porcentajeSI + porcentajeNO);

        ca += "<td align='right' style='font-weight:bold;'>"+totalPorcentaje+"%</td>";
        ca += "<td align='right' style='font-weight:bold;'></td>";
        ca += "</tr>";
        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string institucionesincluyenciencia()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataRow totalSI = lb.totalInstitucionesincluyenxRespuestaSI("Ciencia");
        DataRow totalNO = lb.totalInstitucionesincluyenxRespuestaNO("Ciencia");

        int total = Convert.ToInt32(totalSI["total"].ToString()) + Convert.ToInt32(totalNO["total"].ToString());


        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th>Instituciones educativas que incluyen la ciencia</th>";
        ca += "<th>Número de instituciones educativas</th>";
        ca += "<th>Porcentaje</th>";
        ca += "<th>Detalles</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> SI </td>";
        ca += "<td align='right'>" + totalSI["total"].ToString() + "</td>";
        var porcentajeSI = Math.Round((((double)Convert.ToInt32(totalSI["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeSI + "%</td>";
        ca += "<td align='right'> <a href='institucionesincluyenciencia.aspx?resp=Ciencia&opc=si'>ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> NO </td>";
        ca += "<td align='right'>" + totalNO["total"].ToString() + "</td>";
        var porcentajeNO = Math.Round((((double)Convert.ToInt32(totalNO["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeNO + "%</td>";
        ca += "<td align='right'> <a href='institucionesincluyenciencia.aspx?resp=Ciencia&opc=no'>ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        var totalPorcentaje = (porcentajeSI + porcentajeNO);

        ca += "<td align='right' style='font-weight:bold;'>"+totalPorcentaje+"%</td>";
        ca += "<td align='right' style='font-weight:bold;'></td>";
        ca += "</tr>";

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string sedesincluyentecnologiaspei()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataRow totalSI = lb.totalInstitucionesincluyenxRespuestaSI("Tecnología");
        DataRow totalNO = lb.totalInstitucionesincluyenxRespuestaNO("Tecnología");

        int total = Convert.ToInt32(totalSI["total"].ToString()) + Convert.ToInt32(totalNO["total"].ToString());

        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th>Instituciones educativas que incluyen la tecnología</th>";
        ca += "<th>Número de instituciones educativas</th>";
        ca += "<th>Porcentaje</th>";
        ca += "<th>Detalles</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> SI </td>";
        ca += "<td align='right'>" + totalSI["total"].ToString() + "</td>";
        var porcentajeSI = Math.Round((((double)Convert.ToInt32(totalSI["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeSI + "%</td>";
        ca += "<td align='right'> <a href='sedesincluyentecnologiaspei.aspx?resp=Tecnología&opc=si'>ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> NO </td>";
        ca += "<td align='right'>" + totalNO["total"].ToString() + "</td>";
        var porcentajeNO = Math.Round((((double)Convert.ToInt32(totalNO["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeNO + "%</td>";
        ca += "<td align='right'> <a href='sedesincluyentecnologiaspei.aspx?resp=Tecnología&opc=no'>ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        var totalPorcentaje = (porcentajeSI + porcentajeNO);

        ca += "<td align='right' style='font-weight:bold;'>"+totalPorcentaje+"%</td>";
        ca += "<td align='right' style='font-weight:bold;'></td>";
        ca += "</tr>";

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string sedesincluyeninnovacionpei()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataRow totalSI = lb.totalInstitucionesincluyenxRespuestaSI("Innovación");
        DataRow totalNO = lb.totalInstitucionesincluyenxRespuestaNO("Innovación");

        int total = Convert.ToInt32(totalSI["total"].ToString()) + Convert.ToInt32(totalNO["total"].ToString());


        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th>Instituciones educativas que incluyen la innovación</th>";
        ca += "<th>Número de instituciones educativas</th>";
        ca += "<th>Porcentaje</th>";
        ca += "<th>Detalles</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> SI </td>";
        ca += "<td align='right'>" + totalSI["total"].ToString() + "</td>";
        var porcentajeSI = Math.Round((((double)Convert.ToInt32(totalSI["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeSI + "%</td>";
        ca += "<td align='right'> <a href='sedesincluyeninnovacionpei.aspx?resp=Innovación&opc=si'>ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> NO </td>";
        ca += "<td align='right'>" + totalNO["total"].ToString() + "</td>";
        var porcentajeNO = Math.Round((((double)Convert.ToInt32(totalNO["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeNO + "%</td>";
        ca += "<td align='right'> <a href='sedesincluyeninnovacionpei.aspx?resp=Innovación&opc=no'>ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        var totalPorcentaje = (porcentajeSI + porcentajeNO);

        ca += "<td align='right' style='font-weight:bold;'>"+totalPorcentaje+"%</td>";
        ca += "<td align='right' style='font-weight:bold;'></td>";
        ca += "</tr>";

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string sedesincluyeninvestigacionpei()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataRow totalSI = lb.totalInstitucionesincluyenxRespuestaSI("Investigación");
        DataRow totalNO = lb.totalInstitucionesincluyenxRespuestaNO("Investigación");

        int total = Convert.ToInt32(totalSI["total"].ToString()) + Convert.ToInt32(totalNO["total"].ToString());


        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th>Instituciones educativas que incluyen la investigación</th>";
        ca += "<th>Número de instituciones educativas</th>";
        ca += "<th>Porcentaje</th>";
        ca += "<th>Detalles</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> SI </td>";
        ca += "<td align='right'>" + totalSI["total"].ToString() + "</td>";
        var porcentajeSI = Math.Round((((double)Convert.ToInt32(totalSI["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeSI + "% </td>";
        ca += "<td align='right'> <a href='sedesincluyeninvestigacionpei.aspx?resp=Investigación&opc=si'>ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> NO </td>";
        ca += "<td align='right'>" + totalNO["total"].ToString() + "</td>";
        var porcentajeNO = Math.Round((((double)Convert.ToInt32(totalNO["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeNO + "%</td>";
        ca += "<td align='right'> <a href='sedesincluyeninvestigacionpei.aspx?resp=Investigación&opc=no'>ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        var totalPorcentaje = (porcentajeSI + porcentajeNO);

        ca += "<td align='right' style='font-weight:bold;'>"+totalPorcentaje+"%</td>";
        ca += "<td align='right' style='font-weight:bold;'></td>";
        ca += "</tr>";

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string sedesincluyenTicpei()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataRow totalSI = lb.totalInstitucionesincluyenxRespuestaSI("TIC");
        DataRow totalNO = lb.totalInstitucionesincluyenxRespuestaNO("TIC");

        int total = Convert.ToInt32(totalSI["total"].ToString()) + Convert.ToInt32(totalNO["total"].ToString());


        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th>Instituciones educativas que incluyen la TIC</th>";
        ca += "<th>Número de instituciones educativas</th>";
        ca += "<th>Porcentaje</th>";
        ca += "<th>Detalles</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> SI </td>";
        ca += "<td align='right'>" + totalSI["total"].ToString() + "</td>";
        var porcentajeSI = Math.Round((((double)Convert.ToInt32(totalSI["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeSI + "% </td>";
        ca += "<td align='right'> <a href='sedesincluyenticpei.aspx?resp=TIC&opc=si'>ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> NO </td>";
        ca += "<td align='right'>" + totalNO["total"].ToString() + "</td>";
        var porcentajeNO = Math.Round((((double)Convert.ToInt32(totalNO["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeNO + "% </td>";
        ca += "<td align='right'> <a href='sedesincluyenticpei.aspx?resp=TIC&opc=no'>ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        var totalPorcentaje = (porcentajeSI + porcentajeNO);

        ca += "<td align='right' style='font-weight:bold;'>"+totalPorcentaje+"%</td>";
        ca += "<td align='right' style='font-weight:bold;'></td>";
        ca += "</tr>";

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string modeloseducativosdesedes()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataRow totalAceleracion = lb.totalModelosEducativosdeSedesxRespuesta("Aceleración");
        DataRow totalEscuela = lb.totalModelosEducativosdeSedesxRespuesta("Escuela");
        DataRow totalPost = lb.totalModelosEducativosdeSedesxRespuesta("Post");
        DataRow totalTelesecundaria = lb.totalModelosEducativosdeSedesxRespuesta("Telesecundaria");
        DataRow totalSER = lb.totalModelosEducativosdeSedesxRespuesta("SER");
        DataRow totalCAFAM = lb.totalModelosEducativosdeSedesxRespuesta("CAFAM");
        DataRow totalSAT = lb.totalModelosEducativosdeSedesxRespuesta("SAT");
        DataRow totalCrecer = lb.totalModelosEducativosdeSedesxRespuesta("Crecer");
        DataRow totalOtro = lb.totalModelosEducativosdeSedesxRespuesta("Otro");

        var total = Convert.ToInt32(totalAceleracion["total"].ToString()) + Convert.ToInt32(totalEscuela["total"].ToString()) + Convert.ToInt32(totalPost["total"].ToString()) + Convert.ToInt32(totalTelesecundaria["total"].ToString()) + Convert.ToInt32(totalSER["total"].ToString()) + Convert.ToInt32(totalCAFAM["total"].ToString()) + Convert.ToInt32(totalSAT["total"].ToString()) + Convert.ToInt32(totalCrecer["total"].ToString()) + Convert.ToInt32(totalOtro["total"].ToString());


        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th>No.</th>";
        ca += "<th>Modelo educativo</th>";
        ca += "<th>Número de instituciones</th>";
        ca += "<th>Porcentaje</th>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td> 1. </td>";
        ca += "<td align='right'> Aceleración del aprendizaje </td>";
        ca += "<td align='right'>" + totalAceleracion["total"].ToString() + "</td>";
        var porcentajeAceleracion = Math.Round((((double)Convert.ToInt32(totalAceleracion["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeAceleracion + "% </td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td> 2. </td>";
        ca += "<td align='right'> Escuela Nueva </td>";
        ca += "<td align='right'>" + totalEscuela["total"].ToString() + "</td>";
        var porcentajeEscuela = Math.Round((((double)Convert.ToInt32(totalEscuela["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeEscuela + "% </td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td> 3. </td>";
        ca += "<td align='right'> Post primaria </td>";
        ca += "<td align='right'>" + totalPost["total"].ToString() + "</td>";
        var porcentajePost = Math.Round((((double)Convert.ToInt32(totalPost["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajePost + "% </td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td> 4. </td>";
        ca += "<td align='right'> Telesecundaria </td>";
        ca += "<td align='right'>" + totalTelesecundaria["total"].ToString() + "</td>";
        var porcentajeTelesecundaria = Math.Round((((double)Convert.ToInt32(totalTelesecundaria["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeTelesecundaria + "% </td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td> 5. </td>";
        ca += "<td align='right'> Servicio de educación rural –SER- </td>";
        ca += "<td align='right'>" + totalSER["total"].ToString() + "</td>";
        var porcentajeSER = Math.Round((((double)Convert.ToInt32(totalSER["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeSER + "% </td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td> 6. </td>";
        ca += "<td align='right'> Programa de educación continuada de CAFAM </td>";
        ca += "<td align='right'>" + totalCAFAM["total"].ToString() + "</td>";
        var porcentajeCAFAM = Math.Round((((double)Convert.ToInt32(totalCAFAM["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeCAFAM + "% </td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td> 7. </td>";
        ca += "<td align='right'> Sistema De Educación Tutorial SAT </td>";
        ca += "<td align='right'>" + totalSAT["total"].ToString() + "</td>";
        var porcentajeSAT = Math.Round((((double)Convert.ToInt32(totalSAT["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeSAT + "% </td>";
        ca += "</tr>";

        
        ca += "<tr>";
        ca += "<td> 8. </td>";
        ca += "<td align='right'> Propuesta educativa para jóvenes y adultos A CRECER </td>";
        ca += "<td align='right'>" + totalCrecer["total"].ToString() + "</td>";
        var porcentajeCrecer = Math.Round((((double)Convert.ToInt32(totalCrecer["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeCrecer + "% </td>";
        ca += "</tr>";


        
        ca += "<tr>";
        ca += "<td> 9. </td>";
        ca += "<td align='right'> Otro </td>";
        ca += "<td align='right'>" + totalOtro["total"].ToString() + "</td>";
        var porcentajeOtro = Math.Round((((double)Convert.ToInt32(totalOtro["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeOtro + "% </td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<th colspan='2'>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        var totalPorcentaje = (porcentajeAceleracion + porcentajeEscuela + porcentajePost + porcentajeTelesecundaria + porcentajeSER + porcentajeCAFAM + porcentajeSAT + porcentajeCrecer + porcentajeOtro);
        ca += "<td align='right' style='font-weight:bold;'>"+ totalPorcentaje + "%</td>";
        ca += "</tr>";

        return ca;
    }


    
   [WebMethod(EnableSession = true)]
    public static string institucionespromueveinvestigaciondocente()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataRow totalSI = lb.totalinstitucionespromueveinvestigaciondocentexRespuesta("si");
        DataRow totalNO = lb.totalinstitucionespromueveinvestigaciondocentexRespuesta("no");

        int total = Convert.ToInt32(totalSI["total"].ToString()) + Convert.ToInt32(totalNO["total"].ToString());


        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th>La investigación docente  en el currículo</th>";
        ca += "<th>Número de instituciones educativas</th>";
        ca += "<th>Porcentaje</th>";
        ca += "<th>Detalles</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> SI </td>";
        ca += "<td align='right'>" + totalSI["total"].ToString() + "</td>";
        var porcentajeSI = Math.Round((((double)Convert.ToInt32(totalSI["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeSI + "% </td>";
        ca += "<td align='right'> <a href='institucionespromueveinvestigaciondocente.aspx?resp=si'>ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> NO </td>";
        ca += "<td align='right'>" + totalNO["total"].ToString() + "</td>";
        var porcentajeNO = Math.Round((((double)Convert.ToInt32(totalNO["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeNO + "% </td>";
        ca += "<td align='right'> <a href='institucionespromueveinvestigaciondocente.aspx?resp=no'>ver detalles</a></td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        var totalPorcentaje = (porcentajeSI + porcentajeNO);

        ca += "<td align='right' style='font-weight:bold;'>"+totalPorcentaje+"%</td>";
        ca += "<td align='right' style='font-weight:bold;'></td>";
        ca += "</tr>";

        return ca;
    }


    
    [WebMethod(EnableSession = true)]
    public static string institucionespromueveinvestigacionestudiantes()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataRow totalSI = lb.totalinstitucionespromueveinvestigacionestudiantesxRespuesta("si");
        DataRow totalNO = lb.totalinstitucionespromueveinvestigacionestudiantesxRespuesta("no");

        int total = Convert.ToInt32(totalSI["total"].ToString()) + Convert.ToInt32(totalNO["total"].ToString());


        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th>La investigación estudiantes  en el currículo</th>";
        ca += "<th>Número de instituciones educativas</th>";
        ca += "<th>Porcentaje</th>";
        ca += "<th>Detalles</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> SI </td>";
        ca += "<td align='right'>" + totalSI["total"].ToString() + "</td>";
        var porcentajeSI = Math.Round((((double)Convert.ToInt32(totalSI["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeSI + "% </td>";
        ca += "<td align='right'> <a href='institucionespromueveinvestigacionestudiantes.aspx?resp=si'>ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> NO </td>";
        ca += "<td align='right'>" + totalNO["total"].ToString() + "</td>";
        var porcentajeNO = Math.Round((((double)Convert.ToInt32(totalNO["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeNO + "% </td>";
        ca += "<td align='right'> <a href='institucionespromueveinvestigacionestudiantes.aspx?resp=no'>ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        var totalPorcentaje = (porcentajeSI + porcentajeNO);

        ca += "<td align='right' style='font-weight:bold;'>"+totalPorcentaje+"%</td>";
        ca += "<td align='right' style='font-weight:bold;'></td>";
        ca += "</tr>";

        return ca;
    }

    

    [WebMethod(EnableSession = true)]
    public static string institucionespromueveusoticdocentes()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataRow totalSI = lb.totalinstucionesPromueveUsoTicDocentesxRespuesta("si");
        DataRow totalNO = lb.totalinstucionesPromueveUsoTicDocentesxRespuesta("no");

        int total = Convert.ToInt32(totalSI["total"].ToString()) + Convert.ToInt32(totalNO["total"].ToString());


        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th>Uso de las TIC de  los docentes</th>";
        ca += "<th>Número de instituciones educativas</th>";
        ca += "<th>Porcentaje</th>";
        ca += "<th>Detalles</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> SI </td>";
        ca += "<td align='right'>" + totalSI["total"].ToString() + "</td>";
        var porcentajeSI = Math.Round((((double)Convert.ToInt32(totalSI["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeSI + "% </td>";
        ca += "<td align='right'> <a href='institucionespromueveusoticdocentes.aspx?resp=si'>ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> NO </td>";
        ca += "<td align='right'>" + totalNO["total"].ToString() + "</td>";
        var porcentajeNO = Math.Round((((double)Convert.ToInt32(totalNO["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeNO + "% </td>";
        ca += "<td align='right'> <a href='institucionespromueveusoticdocentes.aspx?resp=no'>ver detalles</a></td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        var totalPorcentaje = (porcentajeSI + porcentajeNO);

        ca += "<td align='right' style='font-weight:bold;'>"+totalPorcentaje+"%</td>";
        ca += "<td align='right' style='font-weight:bold;'></td>";
        ca += "</tr>";

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string institucionespromueveusoticestudiantes()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataRow totalSI = lb.totalinstucionesPromueveUsoTicEstudiantesxRespuesta("si");
        DataRow totalNO = lb.totalinstucionesPromueveUsoTicEstudiantesxRespuesta("no");

        int total = Convert.ToInt32(totalSI["total"].ToString()) + Convert.ToInt32(totalNO["total"].ToString());

        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th>Uso de las TIC de  los estudiantes</th>";
        ca += "<th>Número de instituciones educativas</th>";
        ca += "<th>Porcentaje</th>";
        ca += "<th>Detalles</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> SI </td>";
        ca += "<td align='right'>" + totalSI["total"].ToString() + "</td>";
        var porcentajeSI = Math.Round((((double)Convert.ToInt32(totalSI["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeSI + "% </td>";
        ca += "<td align='right'> <a href='institucionespromueveusoticestudiantes.aspx?resp=si'>ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> NO </td>";
        ca += "<td align='right'>" + totalNO["total"].ToString() + "</td>";
        var porcentajeNO = Math.Round((((double)Convert.ToInt32(totalNO["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeNO + "% </td>";
        ca += "<td align='right'> <a href='institucionespromueveusoticestudiantes.aspx?resp=no'>ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        var totalPorcentaje = (porcentajeSI + porcentajeNO);
        ca += "<td align='right' style='font-weight:bold;'>"+totalPorcentaje+"%</td>";
        ca += "<td align='right' style='font-weight:bold;'></td>";
        ca += "</tr>";

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string participacionmaestrosproyectosinvestigacion()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataRow totalSI = lb.totalparticipacionMaestrosProyectosInvestigacionSI();
        DataRow totalNO = lb.totalparticipacionMaestrosProyectosInvestigacionNO();

        int total = Convert.ToInt32(totalSI["total"].ToString()) + Convert.ToInt32(totalNO["total"].ToString());

        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th style='max-width: 200px;'>Participación en proyectos de investigación en la institución</th>";
        ca += "<th>Número de docentes</th>";
        ca += "<th>Porcentaje</th>";
        ca += "<th>Detalles</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> SI </td>";
        ca += "<td align='right'>" + totalSI["total"].ToString() + "</td>";
        var porcentajeSI = Math.Round((((double)Convert.ToInt32(totalSI["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeSI + "% </td>";
        ca += "<td align='right'> <a href='participacionmaestrosproyectosinvestigacion.aspx?resp=si'>ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> NO </td>";
        ca += "<td align='right'>" + totalNO["total"].ToString() + "</td>";
        var porcentajeNO = Math.Round((((double)Convert.ToInt32(totalNO["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeNO + "% </td>";
        ca += "<td align='right'> <a href='participacionmaestrosproyectosinvestigacion.aspx?resp=no'>ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        var totalPorcentaje = (porcentajeSI + porcentajeNO);
        ca += "<td align='right' style='font-weight:bold;'>" + totalPorcentaje + "%</td>";
        ca += "<td align='right' style='font-weight:bold;'></td>";
        ca += "</tr>";

        return ca;
    }


    
    [WebMethod(EnableSession = true)]
    public static string proyectosinvestigacionestudiantespracticapedagogica()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataRow totalSI = lb.totalproyectosInvestigacionEstudiantesPracticaPedagogicaSI();
        DataRow totalNO = lb.totalproyectosInvestigacionEstudiantesPracticaPedagogicaNO();

        int total = Convert.ToInt32(totalSI["total"].ToString()) + Convert.ToInt32(totalNO["total"].ToString());

        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th style='max-width: 200px;'>Proyectos de investigación con los estudiantes como parte de la práctica pedagógica</th>";
        ca += "<th>Número de docentes</th>";
        ca += "<th>Porcentaje</th>";
        ca += "<th>Detalles</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> SI </td>";
        ca += "<td align='right'>" + totalSI["total"].ToString() + "</td>";
        var porcentajeSI = Math.Round((((double)Convert.ToInt32(totalSI["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeSI + "% </td>";
        ca += "<td align='right'> <a href='proyectosinvestigacionestudiantespracticapedagogica.aspx?resp=si'>ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> NO </td>";
        ca += "<td align='right'>" + totalNO["total"].ToString() + "</td>";
        var porcentajeNO = Math.Round((((double)Convert.ToInt32(totalNO["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeNO + "% </td>";
        ca += "<td align='right'> <a href='proyectosinvestigacionestudiantespracticapedagogica.aspx?resp=no'>ver detalles</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        var totalPorcentaje = (porcentajeSI + porcentajeNO);
        ca += "<td align='right' style='font-weight:bold;'>" + totalPorcentaje + "%</td>";
        ca += "<td align='right' style='font-weight:bold;'></td>";
        ca += "</tr>";

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string modalidadproyectosestudiantes()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataRow totalModalidadDeAula = lb.totalModalidadProyectosEstudiantesxRespuesta("De aula");
        DataRow totalModalidadTransversales = lb.totalModalidadProyectosEstudiantesxRespuesta("Transversales");
        DataRow totalModalidadInterdisciplinarios = lb.totalModalidadProyectosEstudiantesxRespuesta("Interdisciplinarios");

        int total = Convert.ToInt32(totalModalidadDeAula["total"].ToString()) + Convert.ToInt32(totalModalidadTransversales["total"].ToString()) + Convert.ToInt32(totalModalidadInterdisciplinarios["total"].ToString());

        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th style='max-width: 200px;'>Modalidad de los proyectos</th>";
        ca += "<th>Número de proyectos</th>";
        ca += "<th>Porcentaje</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> De aula </td>";
        ca += "<td align='right'>" + totalModalidadDeAula["total"].ToString() + "</td>";
        var porcentajeModalidadDeAula = Math.Round((((double)Convert.ToInt32(totalModalidadDeAula["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeModalidadDeAula + "% </td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> Transversales </td>";
        ca += "<td align='right'>" + totalModalidadTransversales["total"].ToString() + "</td>";
        var porcentajeModalidadTransversales = Math.Round((((double)Convert.ToInt32(totalModalidadTransversales["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeModalidadTransversales + "% </td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> Interdisciplinarios </td>";
        ca += "<td align='right'>" + totalModalidadInterdisciplinarios["total"].ToString() + "</td>";
        var porcentajeModalidadInterdisciplinarios = Math.Round((((double)Convert.ToInt32(totalModalidadInterdisciplinarios["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeModalidadInterdisciplinarios + "% </td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        var totalPorcentaje = (porcentajeModalidadDeAula + porcentajeModalidadTransversales + porcentajeModalidadInterdisciplinarios);
        ca += "<td align='right' style='font-weight:bold;'>" + totalPorcentaje + "%</td>";
        ca += "</tr>";

        return ca;
    }

    
    [WebMethod(EnableSession = true)]
    public static string formacionespecificaenciencia()
    {
        string ca = "Pendiente por hacer - falta la consulta.";
        LineaBase lb = new LineaBase();

        //DataRow totalModalidadDeAula = lb.totalModalidadProyectosEstudiantesxRespuesta("De aula");
        //DataRow totalModalidadTransversales = lb.totalModalidadProyectosEstudiantesxRespuesta("Transversales");
        //DataRow totalModalidadInterdisciplinarios = lb.totalModalidadProyectosEstudiantesxRespuesta("Interdisciplinarios");

        //int total = Convert.ToInt32(totalModalidadDeAula["total"].ToString()) + Convert.ToInt32(totalModalidadTransversales["total"].ToString()) + Convert.ToInt32(totalModalidadInterdisciplinarios["total"].ToString());

        //ca += "<table class='mGridTesoreria'>";
        //ca += "<tr>";
        //ca += "<th style='max-width: 200px;'>Modalidad de los proyectos</th>";
        //ca += "<th>Número de proyectos</th>";
        //ca += "<th>Porcentaje</th>";
        //ca += "</tr>";

        //ca += "<tr>";
        //ca += "<td align='right'> De aula </td>";
        //ca += "<td align='right'>" + totalModalidadDeAula["total"].ToString() + "</td>";
        //var porcentajeModalidadDeAula = Math.Round((((double)Convert.ToInt32(totalModalidadDeAula["total"].ToString()) / (double)total) * 100), 2);
        //ca += "<td align='right'>" + porcentajeModalidadDeAula + "% </td>";
        //ca += "</tr>";

        //ca += "<tr>";
        //ca += "<td align='right'> Transversales </td>";
        //ca += "<td align='right'>" + totalModalidadTransversales["total"].ToString() + "</td>";
        //var porcentajeModalidadTransversales = Math.Round((((double)Convert.ToInt32(totalModalidadTransversales["total"].ToString()) / (double)total) * 100), 2);
        //ca += "<td align='right'>" + porcentajeModalidadTransversales + "% </td>";
        //ca += "</tr>";

        //ca += "<tr>";
        //ca += "<td align='right'> Interdisciplinarios </td>";
        //ca += "<td align='right'>" + totalModalidadInterdisciplinarios["total"].ToString() + "</td>";
        //var porcentajeModalidadInterdisciplinarios = Math.Round((((double)Convert.ToInt32(totalModalidadInterdisciplinarios["total"].ToString()) / (double)total) * 100), 2);
        //ca += "<td align='right'>" + porcentajeModalidadInterdisciplinarios + "% </td>";
        //ca += "</tr>";

        //ca += "<tr>";
        //ca += "<th>TOTAL</th>";
        //ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        //var totalPorcentaje = (porcentajeModalidadDeAula + porcentajeModalidadTransversales + porcentajeModalidadInterdisciplinarios);
        //ca += "<td align='right' style='font-weight:bold;'>" + totalPorcentaje + "%</td>";
        //ca += "</tr>";

        return ca;
    }

    
    [WebMethod(EnableSession = true)]
    public static string formacioncontribuyocambiarpracticaspedagogicas()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataRow totalSI = lb.totalformacionContribuyoCambiarPracticasPedagogicasSI();
        DataRow totalNO = lb.totalformacionContribuyoCambiarPracticasPedagogicasNO();

        int total = Convert.ToInt32(totalSI["total"].ToString()) + Convert.ToInt32(totalNO["total"].ToString());

        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th style='max-width: 200px;'>Contribuyó a cambiar sus prácticas</th>";
        ca += "<th>Número</th>";
        ca += "<th>Porcentaje</th>";
        ca += "<th>Detalle</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> SI </td>";
        ca += "<td align='right'>" + totalSI["total"].ToString() + "</td>";
        var porcentajeSI = Math.Round((((double)Convert.ToInt32(totalSI["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeSI + "% </td>";
        ca += "<td align='right'> <a href='#!'>ver detalle</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> NO </td>";
        ca += "<td align='right'>" + totalNO["total"].ToString() + "</td>";
        var porcentajeNO = Math.Round((((double)Convert.ToInt32(totalNO["total"].ToString()) / (double)total) * 100), 2);
        ca += "<td align='right'>" + porcentajeNO + "% </td>";
        ca += "<td align='right'> <a href='#!'>ver detalle</a></td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        var totalPorcentaje = (porcentajeSI + porcentajeNO);
        ca += "<td align='right' style='font-weight:bold;'>" + totalPorcentaje + "%</td>";
        ca += "<td align='right' style='font-weight:bold;'></td>";
        ca += "</tr>";

        return ca;
    }

    
    [WebMethod(EnableSession = true)]
    public static string dequemaneracontribuyocambiarlaspracticaspedagogica()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataTable datos = lb.totaldequemaneracontribuyocambiarlaspracticaspedagogica();
        int total = datos.Rows.Count;

        ca += "<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th style='max-width: 200px;'>Docente</th>";
        ca += "<th>Respuesta</th>";
        ca += "</tr>";
        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td align='left'> " + datos.Rows[i]["nombredocente"].ToString() + " </td>";
                ca += "<td align='left'>" + datos.Rows[i]["comentario"].ToString() + "</td>";
                ca += "</tr>";
            }
        }
        else
        {
            ca += "<tr>";
            ca += "<td align='left'> Sin datos </td>";
            ca += "<td align='left'></td>";
            ca += "</tr>";
        }
        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='left' style='font-weight:bold;'>" + total + "</td>";
        ca += "</tr>";
        ca += "</table>";
        return ca;
    }

    
    [WebMethod(EnableSession = true)]
    public static string formacionespecificaenTIC()
    {
        string ca = "Pendiente por realizar - falta la consulta.";
        LineaBase lb = new LineaBase();

        //DataRow totalModalidadDeAula = lb.totalModalidadProyectosEstudiantesxRespuesta("De aula");
        //DataRow totalModalidadTransversales = lb.totalModalidadProyectosEstudiantesxRespuesta("Transversales");
        //DataRow totalModalidadInterdisciplinarios = lb.totalModalidadProyectosEstudiantesxRespuesta("Interdisciplinarios");

        //int total = Convert.ToInt32(totalModalidadDeAula["total"].ToString()) + Convert.ToInt32(totalModalidadTransversales["total"].ToString()) + Convert.ToInt32(totalModalidadInterdisciplinarios["total"].ToString());

        //ca += "<table class='mGridTesoreria'>";
        //ca += "<tr>";
        //ca += "<th style='max-width: 200px;'>Modalidad de los proyectos</th>";
        //ca += "<th>Número de proyectos</th>";
        //ca += "<th>Porcentaje</th>";
        //ca += "</tr>";

        //ca += "<tr>";
        //ca += "<td align='right'> De aula </td>";
        //ca += "<td align='right'>" + totalModalidadDeAula["total"].ToString() + "</td>";
        //var porcentajeModalidadDeAula = Math.Round((((double)Convert.ToInt32(totalModalidadDeAula["total"].ToString()) / (double)total) * 100), 2);
        //ca += "<td align='right'>" + porcentajeModalidadDeAula + "% </td>";
        //ca += "</tr>";

        //ca += "<tr>";
        //ca += "<td align='right'> Transversales </td>";
        //ca += "<td align='right'>" + totalModalidadTransversales["total"].ToString() + "</td>";
        //var porcentajeModalidadTransversales = Math.Round((((double)Convert.ToInt32(totalModalidadTransversales["total"].ToString()) / (double)total) * 100), 2);
        //ca += "<td align='right'>" + porcentajeModalidadTransversales + "% </td>";
        //ca += "</tr>";

        //ca += "<tr>";
        //ca += "<td align='right'> Interdisciplinarios </td>";
        //ca += "<td align='right'>" + totalModalidadInterdisciplinarios["total"].ToString() + "</td>";
        //var porcentajeModalidadInterdisciplinarios = Math.Round((((double)Convert.ToInt32(totalModalidadInterdisciplinarios["total"].ToString()) / (double)total) * 100), 2);
        //ca += "<td align='right'>" + porcentajeModalidadInterdisciplinarios + "% </td>";
        //ca += "</tr>";

        //ca += "<tr>";
        //ca += "<th>TOTAL</th>";
        //ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        //var totalPorcentaje = (porcentajeModalidadDeAula + porcentajeModalidadTransversales + porcentajeModalidadInterdisciplinarios);
        //ca += "<td align='right' style='font-weight:bold;'>" + totalPorcentaje + "%</td>";
        //ca += "</tr>";

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string formacionprogramaciclon()
    {
        string ca = "Pendiente por realizar - falta la consulta.";
        LineaBase lb = new LineaBase();

        //DataRow totalModalidadDeAula = lb.totalModalidadProyectosEstudiantesxRespuesta("De aula");
        //DataRow totalModalidadTransversales = lb.totalModalidadProyectosEstudiantesxRespuesta("Transversales");
        //DataRow totalModalidadInterdisciplinarios = lb.totalModalidadProyectosEstudiantesxRespuesta("Interdisciplinarios");

        //int total = Convert.ToInt32(totalModalidadDeAula["total"].ToString()) + Convert.ToInt32(totalModalidadTransversales["total"].ToString()) + Convert.ToInt32(totalModalidadInterdisciplinarios["total"].ToString());

        //ca += "<table class='mGridTesoreria'>";
        //ca += "<tr>";
        //ca += "<th style='max-width: 200px;'>Modalidad de los proyectos</th>";
        //ca += "<th>Número de proyectos</th>";
        //ca += "<th>Porcentaje</th>";
        //ca += "</tr>";

        //ca += "<tr>";
        //ca += "<td align='right'> De aula </td>";
        //ca += "<td align='right'>" + totalModalidadDeAula["total"].ToString() + "</td>";
        //var porcentajeModalidadDeAula = Math.Round((((double)Convert.ToInt32(totalModalidadDeAula["total"].ToString()) / (double)total) * 100), 2);
        //ca += "<td align='right'>" + porcentajeModalidadDeAula + "% </td>";
        //ca += "</tr>";

        //ca += "<tr>";
        //ca += "<td align='right'> Transversales </td>";
        //ca += "<td align='right'>" + totalModalidadTransversales["total"].ToString() + "</td>";
        //var porcentajeModalidadTransversales = Math.Round((((double)Convert.ToInt32(totalModalidadTransversales["total"].ToString()) / (double)total) * 100), 2);
        //ca += "<td align='right'>" + porcentajeModalidadTransversales + "% </td>";
        //ca += "</tr>";

        //ca += "<tr>";
        //ca += "<td align='right'> Interdisciplinarios </td>";
        //ca += "<td align='right'>" + totalModalidadInterdisciplinarios["total"].ToString() + "</td>";
        //var porcentajeModalidadInterdisciplinarios = Math.Round((((double)Convert.ToInt32(totalModalidadInterdisciplinarios["total"].ToString()) / (double)total) * 100), 2);
        //ca += "<td align='right'>" + porcentajeModalidadInterdisciplinarios + "% </td>";
        //ca += "</tr>";

        //ca += "<tr>";
        //ca += "<th>TOTAL</th>";
        //ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        //var totalPorcentaje = (porcentajeModalidadDeAula + porcentajeModalidadTransversales + porcentajeModalidadInterdisciplinarios);
        //ca += "<td align='right' style='font-weight:bold;'>" + totalPorcentaje + "%</td>";
        //ca += "</tr>";

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string formacioncicloncontribuyocambiarpracticaspedagogicas()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataTable datos = lb.totalformacioncicloncontribuyocambiarpracticaspedagogicas();
        int total = datos.Rows.Count;

        ca += "<a href='formacioncicloncontribuyocambiarpracticaspedagogicas.aspx?resp=si' style='font-size:20px;padding:5px;'>Ver detalles</a><table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th style='max-width: 200px;'>Docente</th>";
        ca += "<th>Respuesta</th>";
        ca += "</tr>";
        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td align='left'> " + datos.Rows[i]["nombredocente"].ToString() + " </td>";
                ca += "<td align='left'>" + datos.Rows[i]["comentario"].ToString() + "</td>";
                ca += "</tr>";
            }
        }
        else
        {
            ca += "<tr>";
            ca += "<td align='left'> Sin datos </td>";
            ca += "<td align='left'></td>";
            ca += "</tr>";
        }
        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='left' style='font-weight:bold;'>" + total + "</td>";
        ca += "</tr>";
        ca += "</table>";
        return ca;
    }


}
