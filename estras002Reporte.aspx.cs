using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.IO;

public partial class estras002reporte : System.Web.UI.Page
{
    Estrategias est = new Estrategias();
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
            obtenerGET();
            if (Session["codrol"].ToString() == "2" || Session["codrol"].ToString() == "15" || Session["codrol"].ToString() == "11")//Coordinador / asesor CUC
            {
                lblTipoGrupo.Text = "Grupo de investigación";
            }
            else if (Session["codrol"].ToString() == "2" || Session["codrol"].ToString() == "15")//Coordinador / asesor FUNTICS
            {
                lblTipoGrupo.Text = "Red Temática";
            }
            // if (Session["identificacion"] != null)
            //{
            //    Estrategias estra = new Estrategias();
            //    DataRow dato = estra.buscarCodEstraAsesorxCoordinador(Session["identificacion"].ToString());

            //    if (dato != null)
            //    {
            //        Session["CodAsesorCoordinador"] = dato["codigo"].ToString();
                   
            //    }
            //}
        }
    }
    public void obtenerGET()
    {
        Session["e"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["e"]);
        Session["m"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        Session["s"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
        

      
        if (Session["e"] != null || Session["m"] != null || Session["s"] != null )
        {
            lblEstrategia.Text = Session["e"].ToString();
            lblMomento.Text = Session["m"].ToString();
            lblSesion.Text = Session["s"].ToString();
            if(Session["a"] != null)
                Session["a"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["a"]);
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
            

    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        if (Session["e"].ToString() == "1")
            Response.Redirect("estramomentos.aspx?m=" + lblMomento.Text);
        else if (Session["e"].ToString() == "2")
            Response.Redirect("estradosmomentos.aspx?m=" + lblMomento.Text + "&s=" + lblSesion.Text);
    }

    [WebMethod(EnableSession = true)]
    public static string cargarDepartamentoMagdalena()
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarDepartamentoMagdalena();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<option value='0' disabled selected>Seleccione departamento</option>";

            //ca += "@" + datoUsuario["cod"].ToString();
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
                //ca += datos.Rows[i]["codigo"].ToString() + "@" + datos.Rows[i]["nombre"].ToString();
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarMunicipios(string coddepartamento)
    {

        //Funciones fun = new Funciones();

        //fun.convertFechaAño();

        string ca = "";

        Institucion inst = new Institucion();

        DataTable municipios = inst.cargarciudadxDepartamento(coddepartamento);

        if (municipios != null && municipios.Rows.Count > 0)
        {
            ca = "municipio@";
            ca += "<option value='' disabled selected>Seleccione municipio...</option>";
            for (int i = 0; i < municipios.Rows.Count; i++)
            {
                ca += "<option value='" + municipios.Rows[i]["cod"].ToString() + "'>" + municipios.Rows[i]["nombre"].ToString() + "</option>";
            }
        }
        else
        {
            ca = "vacio@<option value='sin' disabled selected>Sin municipios</option>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarInstituciones(string codmunicipio)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarInstitucionxMunicipio(codmunicipio);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<option value='0' disabled selected>Seleccione institución</option>";

            //ca += "@" + datoUsuario["cod"].ToString();
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
                //ca += datos.Rows[i]["codigo"].ToString() + "@" + datos.Rows[i]["nombre"].ToString();
            }
        }
        else
        {
            ca = "vacio@<option value='sin' disabled selected>Sin institución</option>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarSedesInstitucion(string codInstitucion)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarSedesInstitucion(codInstitucion);
        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<option value='0' disabled selected>Seleccione sede</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarLineaInvestigacion(string codSede)
    {
        string ca = "";

        Institucion inst = new Institucion();

        Estrategias est = new Estrategias();

        if (HttpContext.Current.Session["codrol"] != null)
        {
            if (HttpContext.Current.Session["codrol"].ToString() == "10" || HttpContext.Current.Session["codrol"].ToString() == "11" || HttpContext.Current.Session["codrol"].ToString() == "2" || HttpContext.Current.Session["codrol"].ToString() == "15")//Coordinador / asesor UniMag - CUC
            {
                //Carga los grupos de investigación
                DataTable datos = est.cargarLineaInvestigacionxAsesor(codSede, HttpContext.Current.Session["CodAsesorCoordinador"].ToString());

                if (datos != null && datos.Rows.Count > 0)
                {
                    //ca = "redtematica@";
                    ca += "<option value='' disabled selected>Seleccione grupo de investigación</option>";
                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombregrupo"].ToString() + "</option>";
                    }
                }
            }
            else if (HttpContext.Current.Session["codrol"].ToString() == "12" || HttpContext.Current.Session["codrol"].ToString() == "13")//Coordinador / asesor FUNTICS
            {
                DataTable datos = inst.proccargarRedtematica(codSede, HttpContext.Current.Session["CodAsesorCoordinador"].ToString());

                if (datos != null && datos.Rows.Count > 0)
                {
                    //ca = "redtematica@";
                    ca += "<option value='' disabled selected>Seleccione Red Temática</option>";
                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["redtematica"].ToString() + "</option>";
                    }
                }
            }

        }

        return ca;
    }

    [WebMethod(EnableSession=true)]
    public static string cargarAsesores()
    {
        string ca = "";

        Estrategias estra = new Estrategias();

        DataTable datos = estra.cargarAsesores(HttpContext.Current.Session["CodAsesorCoordinador"].ToString());
        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<option value='0' disabled selected>Seleccione Asesor</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + " " + datos.Rows[i]["apellido"].ToString() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string encabezado(string codProyecto, string codAsesor, string noAsesoria, string fechaVisita, string duracionHoras, string tipoAcompaniamiento, string motivoAsesoria, string objetivo, string noproyectadas, string noasistentes)
    {
        string ca = "";
        Estrategias estra = new Estrategias();
        Funciones fun = new Funciones();
        HttpContext.Current.Session["codredtematicasede"] = codProyecto;
        DataRow row = estra.encabezadoS002(codProyecto, codAsesor, noAsesoria, fun.convertFechaAño(fechaVisita), duracionHoras, tipoAcompaniamiento, motivoAsesoria, objetivo, HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString(), noproyectadas, noasistentes);
        if (row != null)
        {
            ca += row["codigo"];
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string actividades(string codEstraS002, string actividad, string noactividad)
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        if (estra.guardarActividades(codEstraS002, actividad, noactividad))
        {
            ca += "Datos almacenados exitosamente";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string compromisos(string codEstraS002, string compromiso, string fechaCumplimiento, string responsable, string nocompromiso)
    {
        string ca = "";
        Estrategias estra = new Estrategias();
        Funciones fun = new Funciones();

        if (estra.guardarCompromisos(codEstraS002, compromiso, fun.convertFechaAño(fechaCumplimiento), responsable, nocompromiso))
        {
            ca += "Datos almacenados exitosamente";
        }

        return ca;
    }

   

    

    /*2016-10-24 05:08 pm JONNY PACHECO metodo para  listar instrumento s002*/

    [WebMethod(EnableSession = true)]
    public static string listarInstrumentos002(string codasesorcoordinador)
    {
        Institucion inst = new Institucion();
        string ca = "";
        Funciones fun = new Funciones();

        DataTable datos = inst.listarInstrumentos002(codasesorcoordinador, HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString());
        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["departamento"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombregrupo"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["noasistentes"].ToString() + "</td>";
                ca += "<td>" + fun.convertFechaDia(datos.Rows[i]["fechavisita"].ToString()) + "</td>";
                ca += "<td>" + datos.Rows[i]["asesor"].ToString() + "</td>";
                ca += "<td style='padding:5px;text-align:center;' ><a class='btn btn-success' onclick=\"$('#evidencias').hide(),$('#table').hide(), $('#form').fadeIn(500), loadSelectInstrumentos002(" + datos.Rows[i]["codProyecto"].ToString() + "),cargarInstrumentos002(" + datos.Rows[i]["codigo"].ToString() + "),listaractividadess002(" + datos.Rows[i]["codigo"].ToString() + "),listarcompromisoss002(" + datos.Rows[i]["codigo"].ToString() + ") \">Ver</a><br/ ><br/ ><a href='estras002evidencias.aspx?codestras002=" + datos.Rows[i]["codigo"].ToString() + "&a=" + codasesorcoordinador + "' class='btn btn-primary'>Evidencias</a><br/ ><br/ ></td>";
                ca += "</tr>";
            }
        }
        else
        {
            ca += "<tr><td colspan='10'>No se encontraron Registros por parte del asesor.</td></tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string listarInstrumentos002Regresar()
    {
        Institucion inst = new Institucion();
        string ca = "";
        Funciones fun = new Funciones();

        DataTable datos = inst.listarInstrumentos002(HttpContext.Current.Session["a"].ToString(), HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString());
        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["departamento"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombregrupo"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["noasistentes"].ToString() + "</td>";
                ca += "<td>" + fun.convertFechaDia(datos.Rows[i]["fechavisita"].ToString()) + "</td>";
                ca += "<td>" + datos.Rows[i]["asesor"].ToString() + "</td>";
                ca += "<td style='padding:5px;text-align:center;' ><a class='btn btn-success' onclick=\"$('#evidencias').hide(),$('#table').hide(), $('#form').fadeIn(500), loadSelectInstrumentos002(" + datos.Rows[i]["codProyecto"].ToString() + "),cargarInstrumentos002(" + datos.Rows[i]["codigo"].ToString() + "),listaractividadess002(" + datos.Rows[i]["codigo"].ToString() + "),listarcompromisoss002(" + datos.Rows[i]["codigo"].ToString() + ") \">Ver</a><br/ ><br/ ><a href='estras002evidencias.aspx?codestras002=" + datos.Rows[i]["codigo"].ToString() + "&a=" + HttpContext.Current.Session["a"].ToString() + "' class='btn btn-primary'>Evidencias</a><br/ ><br/ ></td>";
                ca += "</tr>";
            }
        }
        else
        {
            ca += "<tr><td colspan='10'>No se encontraron Registros por parte del asesor.</td></tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadSelectInstrumentos002(string codProyecto)
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataRow dato = estra.loadSelectInstrumentos002(codProyecto);
        if (dato != null)
        {
            ca += "loadSelect@";
            ca += "<option value='" + dato["codigodepartamento"].ToString() + "'>" + dato["nombredepartamento"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigomunicipio"].ToString() + "'>" + dato["nombremunicipio"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigoinstitucion"].ToString() + "'>" + dato["nombreinstitucion"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigosede"].ToString() + "'>" + dato["nombresede"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigogrupoinvestigacion"].ToString() + "'>" + dato["nombregrupoinvestigacion"].ToString() + "</option>@";
            ca += "<option value='" + dato["codasesor"].ToString() + "'>" + dato["nombre"].ToString() + " " + dato["apellido"].ToString() + "</option>";
        }
        return ca;
    }
    /*2016-10-26  07:14 pm JONNY PACHECO*/
    [WebMethod(EnableSession = true)]
    public static string cargarInstrumentos002(string codigo)
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        Docentes doc = new Docentes();

        DataRow dato = estra.cargarInstrumentos002(codigo);
        if (dato != null)
        {
            ca += "load@";
            ca += dato["noasesoria"].ToString() + "@";
            ca += dato["noproyectadas"].ToString() + "@";
            ca += dato["fechavisita"].ToString() + "@";
            ca += dato["duracion_horas"].ToString() + "@";
            ca += dato["tipoasesoria"].ToString() + "@";
            ca += dato["motivoasesoria"].ToString() + "@";
            ca += dato["objetivo"].ToString() + "@";
            ca += dato["noasistentes"].ToString() + "@";

            DataRow doce = doc.buscarDocenteEnS002Estra1(codigo);

            if (doce != null)
            {

                DataRow bdoc = doc.buscarDocentesxCodigo(doce["codgradodocente"].ToString());

                if (bdoc != null)
                {
                    ca += bdoc["codanio"].ToString() + "@" + bdoc["codsede"].ToString();
                }
            }
        }
        return ca;
    }
    /*2016-10-26  09:31 pm*/
    [WebMethod(EnableSession = true)]
    public static string listaractividadess002(string codigo)
    {
        string ca = "load@";
        Estrategias estra = new Estrategias();

        DataTable datos = estra.listaractividadess002(codigo);
        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                
                ca += datos.Rows[i]["actividades"].ToString() + "@";
            }
        }
        

        return ca;

    }
    /*2016-10-28 8:50 am*/
    [WebMethod(EnableSession = true)]
    public static string listarcompromisoss002(string codigo)
    {
        string ca = "load@";
        Estrategias estra = new Estrategias();

        DataTable datos = estra.listarcompromisoss002(codigo);
        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {

                ca += datos.Rows[i]["compromiso"].ToString() + "|";
                ca += datos.Rows[i]["fechacumplimiento"].ToString() + "|";
                ca += datos.Rows[i]["responsable"].ToString() + "@";
            }
        }


        return ca;

    }

    [WebMethod(EnableSession=true)]
    public static string deleteactividadess002(string codinstrumento)
    {
        Estrategias estra = new Estrategias();
        string ca = "";

        long delete = estra.deleteactividadess002(codinstrumento);
        if (delete != -1)
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al eliminar actividades@";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string deletecompromisoss002(string codinstrumento)
    {
        Estrategias estra = new Estrategias();
        string ca = "";

        long delete = estra.deletecompromisoss002(codinstrumento);
        if (delete != -1)
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al eliminar actividades@";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string updates002(string codestrategia, string noasesoria, string noproyectadas, string fechavisita, string duracionhoras, string tipoacompaniamiento, string motivoasesoria, string objetivo, string noasistentes)
    {
        Estrategias estra = new Estrategias();
        Funciones fun = new Funciones();
        string ca = "";
        if (estra.actualizarEncabezadoS002(codestrategia, noasesoria, fechavisita, duracionhoras, tipoacompaniamiento, motivoasesoria, objetivo, noproyectadas, noasistentes))
        {
            ca += "true@";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadactividadess002(string codigo)
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataTable actividades = estra.listaractividadess002(codigo);
        if (actividades != null && actividades.Rows.Count > 0)
        {
            ca += "loadactividad@";
            int total = 1;
            for (int i = 0; i < actividades.Rows.Count; i++)
            {
                ca += "<tr id=\"campus" + total + "\">";
                ca += "<td>" + total + ". </td>";
                ca += "<td ><input type=\"text\"  id =\"actividad" + total + "\" name =\"actividad" + total + "\"  class=\"TextBox\" value=\"" + actividades.Rows[i]["actividades"].ToString() + "\" >";

                if (i == actividades.Rows.Count - 1)
                {
                    ca += "<button id=\"remove\" class=\"btn btn-danger\" onclick=\"fRemove(" + total + ")\" > - </button></td>";
                }
                else
                {
                    ca += "</td>";
                    total++;
                }
                ca += "</tr>";
            }
            ca += "@" + total;
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string evidencias(string codigo)
    {
        string ca = "";
        HttpContext.Current.Session["cods002evidencia"] = codigo;

        //estras002 est = new estras002();
        //est.gvCargarEvidencias();

        ca = codigo;
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string deleteestras002(string codigoestrategia)
    {
        string ca = "";

        Estrategias estra = new Estrategias();

        estra.deleteactividadess002(codigoestrategia);
        estra.deletecompromisoss002(codigoestrategia);
        estra.deleteencabezados002(codigoestrategia);
        estra.borrarEvidenciaEstrategia1S002xCodestrategia(codigoestrategia);

        ca = "delete@";

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarDocentes(string codsede, string codanio)
    {
        string ca = "";
        Docentes estu = new Docentes();

        DataTable lista = estu.cargarDocentesxSede(codsede, codanio);
        if (lista != null && lista.Rows.Count > 0)
        {
            ca += "datos@";
            for (int i = 0; i < lista.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + lista.Rows[i]["identificacion"].ToString() + "</td>";
                ca += "<td>" + lista.Rows[i]["nomdocente"].ToString() + "</td>";
                ca += "<td><label class='switch'><input type='checkbox' checked value='" + lista.Rows[i]["codgradodocente"].ToString() + "' /><div class='slider round'></div></label></td>";
                ca += "</tr>";
            }
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargaranios()
    {
        string ca = "";

        Institucion ins = new Institucion();

        DataTable datos = ins.cargarAnios();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "anio@";
            ca += "<option value='0' disabled selected>Seleccione año</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string matricularDocentes(string codestras002, string codgradodocente)
    {
        string ca = "";
        Docentes estu = new Docentes();

        string[] codgdocente = codgradodocente.Split('@');

        for (int i = 0; i < codgdocente.Length; i++)
        {
            bool response = estu.matriculaDocenteS002Estra1(codestras002, codgdocente[i].ToString());
            if (response)
            {
                ca = "matricula@Se matricularon " + (codgdocente.Length - 1) + " docentes exitosamente";
            }
            else
            {
                ca = "vacio@Error al matricular los docentes";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string listardocentesmatriculados(string codestra2instrumento_s002, string codsede, string codanio)
    {
        string ca = "";
        Docentes estu = new Docentes();

        DataTable lista2 = estu.cargarDocentesxSede(codsede, codanio);

        if (lista2 != null && lista2.Rows.Count > 0)
        {
            ca += lista2.Rows[0]["codanio"].ToString() + "@";
            ca += "datos@";
            for (int j = 0; j < lista2.Rows.Count; j++)
            {

                DataRow lista = estu.buscarDocentesS002Estra1(codestra2instrumento_s002, lista2.Rows[j]["codgradodocente"].ToString());

                if (lista != null)
                {
                    ca += "<tr>";
                    ca += "<td>" + (j + 1) + "</td>";
                    ca += "<td>" + lista["identificacion"].ToString() + "</td>";
                    ca += "<td>" + lista["nomdocente"].ToString() + "</td>";
                    //ca += "<td><label class='switch'><input type='checkbox' value='" + lista["codgradodocente"].ToString() + "' checked/><div class='slider round'></div></label></td>";
                }
                else
                {
                    ca += "<tr>";
                    ca += "<td>" + (j + 1) + "</td>";
                    ca += "<td>" + lista2.Rows[j]["identificacion"].ToString() + "</td>";
                    ca += "<td>" + lista2.Rows[j]["nomdocente"].ToString() + "</td>";
                    //ca += "<td><label class='switch'><input type='checkbox' value='" + lista2.Rows[j]["codgradodocente"].ToString() + "' /><div class='slider round'></div></label></td>";
                }
                ca += "</tr>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string deletematriculaDocente(string codinstrumento)
    {
        string ca = "";
        Docentes estu = new Docentes();

        if (estu.deleteDocentesS002Estra1(codinstrumento))
        {

            ca = "true@";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarlistasesores()
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataTable asesores = estra.listarAsesores("1");

        if (asesores != null && asesores.Rows.Count > 0)
        {
            ca += "<option value='0' selected disabled>Seleccione asesor...</option>";
            for (int i = 0; i < asesores.Rows.Count; i++)
            {
                ca += "<option value='" + asesores.Rows[i]["codigo"].ToString() + "'>" + asesores.Rows[i]["asesor"].ToString().ToUpper() + "</option>";
            }
        }

        return ca;
    }

   
}