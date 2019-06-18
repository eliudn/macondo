using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Web.Script.Serialization;
using System.Web.Services;

public partial class verestraunobitacoracuatro : System.Web.UI.Page
{
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
            //obtenerGET();
            if (Session["identificacion"] != null)
            {
               
            }
        }
    }
    public void obtenerGET()
    {
        Session["e"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["e"]);
        Session["m"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        Session["s"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);

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
            Response.Redirect("estramomentos.aspx?m=3");
        else if (Session["e"].ToString() == "2")
            Response.Redirect("estradosmomentos.aspx?g007=true");
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
            ca += "<option value='0' disabled selected>Seleccione institucion</option>";
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

        Estrategias estra = new Estrategias();

        DataTable datos = estra.cargarLineaInvestigacion(codSede);
        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<option value='0' disabled selected>Seleccione grupo investigacion</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombregrupo"].ToString() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string guardarRubros(string codGrupoInvestigacion, string valInsumo, string valPapeleria, string valTransporte, string valMaterial, string valRefrigerio, string valOtros)
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        //DataRow row = estra.buscarRubros(HttpContext.Current.Session["CodEstraAsesorCoordinador"].ToString(), codGrupoInvestigacion, HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString());

        //if (row != null)
        //{
        //    if (estra.actualizarRubros(HttpContext.Current.Session["CodEstraAsesorCoordinador"].ToString(), codGrupoInvestigacion, valInsumo, valPapeleria, valTransporte, valMaterial, valRefrigerio, valOtros, HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString()))
        //    {
        //        ca += "Rubros actualizados exitosamente";
        //    }
        //}
        //else
        //{
            if (estra.agregarRubros(HttpContext.Current.Session["CodEstraAsesorCoordinador"].ToString(), codGrupoInvestigacion, valInsumo, valPapeleria, valTransporte, valMaterial, valRefrigerio, valOtros, HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString()))
            {
                ca += "Rubros Almacenados exitosamente";
            }
        //}

        return ca;
    }

    [WebMethod(EnableSession=true)]
    public static string searchRubros(string codigo)
    {
        string ca = "";

        Estrategias estra = new Estrategias();
        

        DataRow dato = estra.loadRubros(codigo);
        if(dato != null){

            ca += dato["insumo"].ToString() + "-";
            ca += dato["papeleria"].ToString() + "-";
            ca += dato["transporte"].ToString() + "-";
            ca += dato["material"].ToString() + "-";
            ca += dato["refrigerios"].ToString() + "-";
            ca += dato["otro"].ToString();

        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string listadobitacora4(string codasesorcoordinador)
    {
        string ca = "";

        Estrategias estra = new Estrategias();

        DataTable datos = estra.listarBitacoraCuatroSupervision(codasesorcoordinador);
        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["nombredepartamento"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombremunicipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombreinstitucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombresede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombregrupo"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["fechadiligenciamiento"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["asesor"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["momento"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["sesion"].ToString() + "</td>";
                ca += "<td style='padding:5px;text-align:center' ><a class='btn btn-success' onclick=\"$('#table').hide(), $('#form').fadeIn(500),  loadSelectBitacoraCuatro(" + datos.Rows[i]["codigo"].ToString() + "), loadRubros(" + datos.Rows[i]["codigo"].ToString() + ") \">Ver</a></td>";
                ca += "</tr>";
            }
        }
        else
        {
            ca += "<tr><td colspan='11'>No se encontraron registros por parte del asesor.</td></tr>";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadSelectBitacoraCuatro(string codigo)
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataRow dato = estra.loadSelectBitacoraCuatro(codigo);
        if (dato != null)
        {
            ca += "loadSelect@";
            ca += "<option value='" + dato["codigodepartamento"].ToString() + "'>" + dato["nombredepartamento"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigomunicipio"].ToString() + "'>" + dato["nombremunicipio"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigoinstitucion"].ToString() + "'>" + dato["nombreinstitucion"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigosede"].ToString() + "'>" + dato["nombresede"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigogrupoinvestigacion"].ToString() + "'>" + dato["nombregrupoinvestigacion"].ToString() + "</option>";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargaranios(string codProyecto)
    {
        string ca = "";
        Institucion inst = new Institucion();
        Estudiantes estu = new Estudiantes();

        DataTable estudiantes = estu.cargarEstudiantesxGrupoInvestigacion(codProyecto);
        if (estudiantes != null && estudiantes.Rows.Count > 0)
        {
            ca += "<option value='" + estudiantes.Rows[0]["codanio"].ToString() + "'>" + estudiantes.Rows[0]["anio"].ToString() + "</option>";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string deletebitacora(string codigo)
    {
        string ca = "";
        Estrategias inst = new Estrategias();

        if (inst.eliminarBitacoraCuatro(codigo))
        {

            ca = "delete@";
        }
        else
        {
            ca = "vacio@";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarasesores()
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