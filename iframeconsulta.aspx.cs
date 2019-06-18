using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Services;

public partial class iframeconsulta : System.Web.UI.Page
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
                   // accordion.InnerHtml = MenuAcordeonGerencia();

                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }

    [WebMethod(EnableSession = true)]
    public static string estadoActual()
    {
        Estrategias e = new Estrategias();
        Consultas con = new Consultas();
        DataTable dt = e.esturedtematicasxanio("20","","","","2018");
        int totalEstudiantes = dt.Rows.Count;
        DataTable dtm = e.maestrosxanio("20", "", "", "", "2017");
        //DataTable dtm = con.cargarDocentesBeneficiadosEnSesionesJornadas();
        int totalDocentes = dtm.Rows.Count;
        string ca = "";
        ca += "<li class='list-group-item'>";
        ca += "<span class='badge'>28</span> Municipios";
        ca += "</li>";
        ca += "<li class='list-group-item'>";
        ca += "<span class='badge'>320</span> Sedes educativas";
        ca += "</li>";
        ca += "<li class='list-group-item'>";
        ca += "<span class='badge'>"+totalEstudiantes+"</span> Estudiantes beneficiados";
        ca += "</li>";
        ca += "<li class='list-group-item'>";
        ca += "<span class='badge'>" + totalDocentes + "</span> Maestros beneficiados";
        ca += "</li>";
    
        return ca;
    }
    [WebMethod(EnableSession = true)]
    public static string productos()
    {
        Institucion ins = new Institucion();
        Consultas con = new Consultas();
        Estrategias est = new Estrategias();
        DataTable grupos = ins.cargarTodoGrupoInvestigacion();
        DataTable redes = con.cargarTablaRedTematicaTodo();
        DataRow tabletas = con.sumTotalTabletas();
        DataTable conexionsedes = con.cargarSedesConectadas();
        DataTable gruposdoc = est.cargarTodoGrupoInvestigacionSedes();
        DataTable maestrofor = est.cargardocentesformados();
        DataTable gruposdocSele = est.cargarTodoGrupoInvestigacionSedesSeleccioandos();
        DataTable feriasins = ins.feriasinst();
        DataTable feriasMun = est.cargarFeriasMunicipalesMaferpi();
        DataTable feriasDep = est.cargarFeriasDptalesMaferpi();
        DataTable feriasReg = est.FeriasRegionalesMaferpi();
        DataTable feriasNac = est.FeriasNacionalesMaferpi();
        DataTable feriasInt = est.FeriasInternacionalMaferpi();


        string ca = "";
        ca += "<li class='list-group-item'>";
        ca += "<span class='badge'>" + grupos.Rows.Count + "</span> Grupos de Investigación";
        ca += "</li>";
        ca += "<li class='list-group-item'>";
        ca += "<span class='badge'>" + tabletas["total"].ToString() + "</span> Tabletas Entregadas";
        ca += "</li>";
        ca += "<li class='list-group-item'>";
        ca += "<span class='badge'>" + redes.Rows.Count + "</span> Redes Temáticas Formadas";
        ca += "</li>";
        ca += "<li class='list-group-item'>";
        ca += "<span class='badge'>" + gruposdoc.Rows.Count + "</span> Grupos de investigación de maestros inscritos en convocatoria";
        ca += "</li>";
        ca += "<li class='list-group-item'>";
        ca += "<span class='badge'>" + maestrofor.Rows.Count + "</span> Maestros Formados";
        ca += "</li>";
        ca += "<li class='list-group-item'>";
        ca += "<span class='badge'>" + gruposdocSele.Rows.Count + "</span> Grupos de investigación de maestros seleccionados";
        ca += "</li>";
        ca += "<li class='list-group-item'>";
        ca += "<span class='badge'>" + conexionsedes.Rows.Count + "</span> Sedes Conectadas";
        ca += "</li>";
        ca += "<li class='list-group-item'>";
        ca += "<span class='badge'>" + feriasins.Rows.Count + "</span> Ferias Institucionales";
        ca += "</li>";
        ca += "<li class='list-group-item'>";
        ca += "<span class='badge'>" + feriasMun.Rows.Count + "</span> Ferias Municipales";
        ca += "</li>";
        ca += "<li class='list-group-item'>";
        ca += "<span class='badge'>" + feriasDep.Rows.Count + "</span> Ferias Departamentales";
        ca += "</li>";
        ca += "<li class='list-group-item'>";
        ca += "<span class='badge'>" + feriasReg.Rows.Count + "</span> Ferias Regionales";
        ca += "</li>";
        ca += "<li class='list-group-item'>";
        ca += "<span class='badge'>" + feriasNac.Rows.Count + "</span> Ferias Nacionales";
        ca += "</li>";
        ca += "<li class='list-group-item'>";
        ca += "<span class='badge'>" + feriasInt.Rows.Count + "</span> Ferias Internacionales";
        ca += "</li>";


        return ca;
    }
    [WebMethod(EnableSession = true)]
    public static string tiempoEjecucion()
    {
        Funciones fun = new Funciones();

        decimal meses = MonthDifference(Convert.ToDateTime(fun.getFechaAñoActual()), Convert.ToDateTime("28/01/2016"));
        string ca = "";
        ca += "<li class='list-group-item'>";
        ca += "<span class='badge'>36</span> Duración del proyecto (Meses)";
        ca += "</li>";
        ca += "<li class='list-group-item'>";
        ca += "<span class='badge'>"+meses+"</span> Ejecutado (Meses)";
        ca += "</li>";
      
        return ca;
    }

    public static decimal MonthDifference(DateTime FechaFin, DateTime FechaInicio)
    {
        return Math.Abs((FechaFin.Month - FechaInicio.Month) + 12 * (FechaFin.Year - FechaInicio.Year));

    }

    //Cargar Departamento
    [WebMethod(EnableSession = true)]
    public static string cargarDepartamentoMagdalena()
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarDepartamentoMagdalena();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "departamento@";
            ca += "<option value='' disabled selected>Seleccione departamento</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    //Cargar municipios
    [WebMethod(EnableSession = true)]
    public static string cargarMunicipioMagdalena(string codDepartamento)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarciudadxDepartamento(codDepartamento);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "municipio@";
            ca += "<option value='' selected>Todos</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    //Cargar institución X MUNICIPIO
    [WebMethod(EnableSession = true)]
    public static string cargarInstituciones(string codMunicipio)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.proccargarInstitucionxMunicipio(codMunicipio);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "inst@";
            ca += "<option value=''  selected>Todos</option>";

            //ca += "@" + datoUsuario["cod"].ToString();
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
                //ca += datos.Rows[i]["codigo"].ToString() + "@" + datos.Rows[i]["nombre"].ToString();
            }
        }

        return ca;
    }

    //Cargar sedes x institución
    [WebMethod(EnableSession = true)]
    public static string cargarsedes(string codigoins)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarSedesInstitucion(codigoins);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "sedes@";
            ca += "<option value='' selected>Todos</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    //Cargar sedes x municipios
    [WebMethod(EnableSession = true)]
    public static string cargarsedesxMunicipio(string codMunicipio)
    {
        string ca = "";

        Consultas inst = new Consultas();

        DataTable datos = inst.cargarsedesxMunicipio(codMunicipio);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "sedes@";
            ca += "<option value='' selected>Todos</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["dane"].ToString() + "'>" + datos.Rows[i]["sede"].ToString() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string estadoActualxMunicipio(String sedesEducativas, String codMunicipio)
    {
        Estrategias e = new Estrategias();
        DataTable dt = e.esturedtematicasxanio("20",codMunicipio, "", "", "2017");
        int totalEstudiantes = dt.Rows.Count;
        DataTable dtm = e.maestrosxanio("20",codMunicipio,"", "", "2017");
        int totalDocentes = dtm.Rows.Count;
        string ca = "";

        ca += "<ul class='list-group'>";
        ca += "<li class='list-group-item'>";
        ca += "<span class='badge'>" + sedesEducativas + "</span> Sedes educativas ";
        ca += "</li>";
        ca += "<li class='list-group-item'>";
        ca += "<span class='badge'>" + totalEstudiantes + "</span> Estudiantes beneficiados ";
        ca += "</li>";       
        ca += "<li class='list-group-item'>";
        ca += "<span class='badge'>" + totalDocentes + "</span> Maestros beneficiados ";
        ca += "</li>";
        ca += "</ul>";
        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string cargarInstEduBeneficiadas(String codMunicipio,String codZona,String jornada, String niveles,String especialidad)
    {
        string ca = "table#@";
        Consultas c = new Consultas();
        DataTable datos = c.cargarInstEduBeneficiadas(codMunicipio,codZona);
        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {

                string ulJornadas = cargarJornadas(datos.Rows[i]["codinstitucion"].ToString(), jornada);
                string ulNiveles = cargarNiveles(datos.Rows[i]["codinstitucion"].ToString(), niveles);
                string ulEspecialidades = cargarEspecialidades(datos.Rows[i]["codinstitucion"].ToString(),especialidad);

                if (ulJornadas != "-" && ulNiveles != "-" && ulEspecialidades != "-")
                {
                    ca += "<tr>";
                    ca += "<td>" + (i+1) + "</td>";
                    ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
                    ca += "<td>" + datos.Rows[i]["institucion"].ToString() + "</td>";
                    ca += "<td>" + datos.Rows[i]["dane"].ToString() + "</td>";
                    ca += "<td>" + datos.Rows[i]["direccion"].ToString() + "</td>";
                    ca += "<td>" + datos.Rows[i]["telefono"].ToString() + "</td>";
                    ca += "<td>" + datos.Rows[i]["email"].ToString() + "</td>";
                    ca += "<td>" + datos.Rows[i]["zona"].ToString() + "</td>";
                    ca += "<td>" + ulJornadas + "</td>";
                    ca += "<td>" + ulNiveles + "</td>";
                    ca += "<td>" + ulEspecialidades + "</td>";
                    ca += "<td>" + datos.Rows[i]["nomrector"].ToString() + "</td>";
                    ca += "<td>" + datos.Rows[i]["iderector"].ToString() + "</td>";
                    ca += "<td>" + datos.Rows[i]["telerector"].ToString() + "</td>";
                    ca += "<td>" + datos.Rows[i]["emailrector"].ToString() + "</td>";
                    ca += "</tr>";
                }

            }
        }
        else {
            ca += "<tr>";
            ca += "<td colspan='15' style='padding:15px;'><center>No se encontraron resultados</center></td>";
            ca += "</tr>";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarSedesBeneficiadas(String codMunicipio, String codInstitucion, String codZona, String jornada, String niveles)
    {
        string ca = "table#@";
        Consultas c = new Consultas();
        DataTable datos = c.cargarSedesEduBeneficiadas(codMunicipio,codInstitucion,codZona);
        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                  string ulJornadas = cargarJornadasSedes(datos.Rows[i]["codsede"].ToString(),jornada);
                   string ulNiveles = cargarNivelesSedes(datos.Rows[i]["codsede"].ToString(), niveles);

                  if (ulJornadas != "-" && ulNiveles != "-" )
                   {
                    ca += "<tr>";
                    ca += "<td>" + (i+1) + "</td>";
                    ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
                    ca += "<td>" + datos.Rows[i]["institucion"].ToString() + "</td>";
                    ca += "<td>" + datos.Rows[i]["sede"].ToString() + "</td>";
                    ca += "<td>" + datos.Rows[i]["dane"].ToString() + "</td>";
                    ca += "<td>" + datos.Rows[i]["direccion"].ToString() + "</td>";
                    ca += "<td>" + datos.Rows[i]["telefono"].ToString() + "</td>";
                    ca += "<td>" + datos.Rows[i]["email"].ToString() + "</td>";
                    ca += "<td>" + datos.Rows[i]["zona"].ToString() + "</td>";
                    ca += "<td>" + ulJornadas + "</td>";
                    ca += "<td>" + ulNiveles + "</td>";
                    ca += "</tr>";
                 }

            }
        }
        else
        {
            ca += "<tr>";
            ca += "<td colspan='15' style='padding:15px;'><center>No se encontraron resultados</center></td>";
            ca += "</tr>";
        }
        return ca;
    }

    public static string cargarJornadas(String codinstitucion, string jornada)
    {
        string ca = "";
        Consultas c = new Consultas();
        DataTable jornadas = c.cargarJornadasEduBeneficiadas(codinstitucion, jornada);

        if (jornadas != null && jornadas.Rows.Count > 0)
        {
            ca += "<ul>";
            for (int i = 0; i < jornadas.Rows.Count; i++)
            {
                ca += "<li>-" + jornadas.Rows[i]["jornada"].ToString() + "</li>";
            }
            ca += "</ul>";
        }
        else
        {
            ca += "-";
        }

        return ca;
    }
    public static string cargarJornadasSedes(String codsede, string jornada)
    {
        string ca = "";
        Consultas c = new Consultas();
        DataTable jornadas = c.cargarJornadasSedesBeneficiadas(codsede,jornada);

        if (jornadas != null && jornadas.Rows.Count > 0)
        {
            ca += "<ul>";
            for (int i = 0; i < jornadas.Rows.Count; i++)
            {
                ca += "<li>-" + jornadas.Rows[i]["jornada"].ToString() + "</li>";
            }
            ca += "</ul>";
        }
        else
        {
            ca += "-";
        }

        return ca;
    }

    public static string cargarNiveles(String codinstitucion, string nivel)
    {
        string ca = "";
        Consultas c = new Consultas();
        DataTable niveles = c.cargarNivelesEduBeneficiadas(codinstitucion, nivel);

        if (niveles != null && niveles.Rows.Count > 0)
        {
            ca += "<ul>";
            for (int i = 0; i < niveles.Rows.Count; i++)
            {
                ca += "<li>-" + niveles.Rows[i]["niveles"].ToString() + "</li>";
            }
            ca += "</ul>";
        }
        else
        {
            ca += "-";
        }

        return ca;
    }

    public static string cargarNivelesSedes(String codsede, string nivel)
    {
        string ca = "";
        Consultas c = new Consultas();
        DataTable niveles = c. cargarNivelesSedesBeneficiadas(codsede,nivel);

        if (niveles != null && niveles.Rows.Count > 0)
        {
            ca += "<ul>";
            for (int i = 0; i < niveles.Rows.Count; i++)
            {
                ca += "<li>-" + niveles.Rows[i]["niveles"].ToString() + "</li>";
            }
            ca += "</ul>";
        }
        else
        {
            ca += "-";
        }

        return ca;
    }
   

    public static string cargarEspecialidades(String codinstitucion, string especialidad)
    {
        string ca = "";
        Consultas c = new Consultas();
        DataTable especialidades = c.cargarEspecialidadesEduBeneficiadas(codinstitucion, especialidad);

        if (especialidades != null && especialidades.Rows.Count > 0)
        {
            ca += "<ul>";
            for (int i = 0; i < especialidades.Rows.Count; i++)
            {
                ca += "<li>-" + especialidades.Rows[i]["especialidades"].ToString() + "</li>";
            }
            ca += "</ul>";
        }
        else
        {
            ca += "-";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarGrados()
    {
        string ca = "grados@";
        Consultas c = new Consultas();
        DataTable grados = c.cargarGrados();

        if (grados != null && grados.Rows.Count > 0)
        {
            ca += "<option value='' selected='selected'>Todos</option>";
            for (int i = 0; i < grados.Rows.Count; i++)
            {
                ca += "<option value='" + grados.Rows[i]["codigo"].ToString() + "'>" + grados.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarEstudiantesBeneficiados(String codMunicipio, String codInstitucion, String codSede, String grupos, String sexo, String grado)
    {             
        
        string ca = "table@";
        Consultas c = new Consultas();
        DataTable datos = null;

        if (grupos=="Redes temáticas")
        {
            datos = c.cargarEstuRedTematicas(codMunicipio, codInstitucion, codSede,sexo,grado);
        }else
        {
            datos = c.cargarEstuGruInvestigacion(codMunicipio, codInstitucion, codSede, sexo, grado);
        }

        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
               
                    ca += "<tr>";
                    ca += "<td>" + (i+1) + "</td>";
                    ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
                    ca += "<td>" + datos.Rows[i]["institucion"].ToString() + "</td>";
                    ca += "<td>" + datos.Rows[i]["sede"].ToString() + "</td>";
                    ca += "<td>" + datos.Rows[i]["apellido"].ToString() + " "+ datos.Rows[i]["nombre"].ToString() + "</td>";
                    
                    if (datos.Rows[i]["sexo"].ToString()=="M")
                    {
                        ca += "<td>MASCULINO</td>";
                    }
                    else if (datos.Rows[i]["sexo"].ToString() == "F")
                    {
                        ca += "<td>FEMENINO</td>";
                    }
                    else
                    {
                        ca += "<td> </td>";
                    }
                    ca += "<td>" + datos.Rows[i]["grado"].ToString() + "</td>";
                    ca += "<td>" + grupos.ToUpper() + "</td>";
                    ca += "</tr>";

            }
        }
        else
        {
            ca += "<tr>";
            ca += "<td colspan='15' style='padding:15px;'><center>No se encontraron resultados</center></td>";
            ca += "</tr>";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarSedesConectadas(String codMunicipio, String codSede, String zona, String bw)
    {

        string ca = "table@";
        Consultas c = new Consultas();
        Funciones fun = new Funciones();
        DataTable datos = null;

        datos = c.cargarSedesConectadasxMunicipio(codMunicipio, codSede, zona, bw);

        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {

                ca += "<tr>";
                ca += "<td>" + (i+1) + "</td>";
                ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["dane"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["zona"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["bw"].ToString() + "</td>";
                ca += "<td>" + fun.convertFechaDia(datos.Rows[i]["fecha"].ToString()) + "</td>";
                ca += "</tr>";

            }
        }
        else
        {
            ca += "<tr>";
            ca += "<td colspan='15' style='padding:15px;'><center>No se encontraron resultados</center></td>";
            ca += "</tr>";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarDocentesBeneficiados(String codMunicipio, string codInstitucion, string codSede, string sexodocente, string tipomaestro)
    {

        string ca = "tablesearch@";
        Consultas c = new Consultas();
        Funciones fun = new Funciones();
        DataTable datos = null;

        datos = c.cargarDocentesBeneficiados(codMunicipio, codInstitucion, codSede, sexodocente, "", "", tipomaestro);

        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {

                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombre"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["identificacion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["email"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["sexo"].ToString() + "</td>";
                ca += "<td>" + buscarformacion(datos.Rows[i]["identificacion"].ToString()) + "</td>";
                ca += "<td>" + buscararea(datos.Rows[i]["identificacion"].ToString()) + "</td>";
                ca += "<td>" + buscargrupo(datos.Rows[i]["identificacion"].ToString()) + "</td>";
                ca += "</tr>";

            }
        }
        else
        {
            ca += "<tr>";
            ca += "<td colspan='15' style='padding:15px;'><center>No se encontraron resultados</center></td>";
            ca += "</tr>";
        }
        return ca;
    }

    private static string buscarformacion(string identificacion)
    {
        string ca = "";
        Consultas c = new Consultas();
        DataRow formacion = c.buscarFormacionDocente(identificacion, "11", "0", "5");

        if (formacion != null)
        {
            ca = formacion["respuesta"].ToString();
        }

        return ca;
    }

    private static string buscararea(string identificacion)
    {
        string ca = "";
        Consultas c = new Consultas();
        DataRow formacion = c.buscarFormacionDocente(identificacion, "4", "1", "5");

        if (formacion != null)
        {
            ca = formacion["respuesta"].ToString();
        }

        return ca;
    }

    private static string buscargrupo(string codgradodocente)
    {
        string ca = "";
        Consultas c = new Consultas();
       
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarSedesConTables(String codMunicipio, String codSede, String zona)
    {

        string ca = "table@";
        Consultas c = new Consultas();
        Funciones fun = new Funciones();
        DataTable datos = null;

        datos = c.cargarSedesConTabletsxMunicipio(codMunicipio, codSede, zona);

        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {

                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["dane"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["zona"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["total"].ToString() + "</td>";
                ca += "</tr>";

            }
        }
        else
        {
            ca += "<tr>";
            ca += "<td colspan='15' style='padding:15px;'><center>No se encontraron resultados</center></td>";
            ca += "</tr>";
        }
        return ca;
    }

    //Cargar Departamento
    [WebMethod(EnableSession = true)]
    public static string cargarLineaInvestigacion()
    {
        string ca = "";

        Consultas inst = new Consultas();

        DataTable datos = inst.cargarLineaInvestigacion();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "linea@";
            ca += "<option value='' selected>Todos</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarGruposJuveniles(String codMunicipio, string codInstitucion, String codSede, String lineainvestigacion, string tipoproyecto)
    {

        string ca = "table@";
        Consultas c = new Consultas();
        Funciones fun = new Funciones();
        DataTable datos = null;

        datos = c.cargarSedesConGruposJuveniles(codMunicipio, codInstitucion, codSede, lineainvestigacion, tipoproyecto);

        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {

                ca += "<tr>";
                ca += "<td>" + datos.Rows[i]["nommunicipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nominstitucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["dane"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nomsede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["zona"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombregrupo"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nomarea"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nomlinea"].ToString() + "</td>";
                ca += "</tr>";

            }
        }
        else
        {
            ca += "<tr>";
            ca += "<td colspan='15' style='padding:15px;'><center>No se encontraron resultados</center></td>";
            ca += "</tr>";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarGruposMaestros(String codMunicipio, string codInstitucion, String codSede, string tipoproyecto)
    {

        string ca = "table@";
        Consultas c = new Consultas();
        Funciones fun = new Funciones();
        DataTable datos = null;

        datos = c.cargarSedesConGruposMaestros(codMunicipio, codInstitucion, codSede, tipoproyecto);

        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {

                ca += "<tr>";
                ca += "<td>" + datos.Rows[i]["nommunicipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nominstitucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["dane"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nomsede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["zona"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombregrupo"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["pregunta"].ToString() + "</td>";
                ca += "</tr>";

            }
        }
        else
        {
            ca += "<tr>";
            ca += "<td colspan='15' style='padding:15px;'><center>No se encontraron resultados</center></td>";
            ca += "</tr>";
        }
        return ca;
    }


}