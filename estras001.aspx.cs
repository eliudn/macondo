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

public partial class estras001 : System.Web.UI.Page
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
            DataRow dato = est.buscarCodEstrategiaxCoordinador(Session["identificacion"].ToString());

            if (dato != null)
            {
                Session["CodEstraCoordinador"] = dato["codigo"].ToString();

            }
        }
    }
    public void obtenerGET()
    {
        Session["m"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        Session["s"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
        Session["a"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["a"]);

    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("estradosmomentos.aspx?s001=true");
    }

    protected void btnEnviarestras001_Click(object sender, EventArgs e)
    {
        //mostrarmensaje("exito", "Rector asociado con la institución.");
    }

    //new code
    [WebMethod(EnableSession = true)]
    public static string cargarInstituciones()
    {
        string ca = "";

        Institucion inst = new Institucion();
        DataTable datos = inst.cargarInstitucion();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "inst@";
            ca += "<option value='0' disabled selected>Seleccione institución</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarsedes(string codigoins)
    {
        string ca = "";
        Institucion inst = new Institucion();
        DataTable datos = inst.cargarSedesInstitucion(codigoins);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "sedes&";
            ca += "<option value='' disabled selected>Seleccione sede...</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }

            DataRow datosInstitucion = inst.cargarDatosinstitucion(codigoins);
            if (datosInstitucion != null)
            {
                ca += "&" + datosInstitucion["email"].ToString() + "&" + datosInstitucion["telefono"].ToString();
            }
        }

        return ca;
    }
    [WebMethod(EnableSession = true)]
    public static string loadDocentes(string codigosede)
    {
        string ca = "";
        Institucion inst = new Institucion();
        DataTable datos = inst.procloadDocentes(codigosede);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "docentes@";
            ca += "<option value='' disabled selected>Seleccione docente...</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["identificacion"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + " " + datos.Rows[i]["apellido"].ToString() + "</option>";
            }
        }
        else
        {
            ca = "vacio@";
        }
        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string loadDatosDocente(string identificaciondocente)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataRow datosdocente = inst.procDatosDocente(identificaciondocente);

        if (datosdocente != null)
        {
            ca = "datosdocente&";
            ca += datosdocente["apellido"].ToString()
            + "&" + datosdocente["nombre"].ToString()
            + "&" + datosdocente["identificacion"].ToString()
            + "&" + datosdocente["expedidaen"].ToString()
            + "&" + datosdocente["lugarnacimiento"].ToString()
            + "&" + datosdocente["fecha_nacimiento"].ToString()
            + "&" + datosdocente["edad"].ToString()
            + "&" + datosdocente["direccion"].ToString()
            + "&" + datosdocente["municipiodireccion"].ToString()
            + "&" + datosdocente["telefono"].ToString()
            + "&" + datosdocente["celular"].ToString()
            + "&" + datosdocente["email"].ToString()
            + "&" + datosdocente["profesion"].ToString();
            if (datosdocente["municipiodireccion"].ToString() != "")
            {
                DataRow datosdepartamento = inst.cargardepartamentoxmunicipio(datosdocente["municipiodireccion"].ToString());
                if (datosdepartamento != null)
                {
                    ca += "&" + datosdepartamento["cod"].ToString();
                }
            }
        }

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string cargarMunicipios(string coddepartamento)
    {
        string ca = "";
        Institucion inst = new Institucion();
        DataTable datos = inst.cargarciudadxDepartamento(coddepartamento);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "muni@";
            ca += "<option value='' disabled selected>Seleccione municipio...</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }
        else
        {
            ca = "vacio@";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarDepartamentos()
    {
        string ca = "";
        Institucion inst = new Institucion();
        DataTable datos = inst.cargarDepartamento();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "muni@";
            ca += "<option value='' disabled selected>Seleccione departamento...</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre1"].ToString() + "</option>";
            }
        }
        else
        {
            ca = "vacio@";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string updateDocente(string codigodocente, string apellidos, string nombres, string expedidaen, string lugarnacimiento, string fechanacimiento,string edad, string direccion, string departamento, string municipio, string telefono, string celular, string email, string profesion)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        long update = inst.procupdateDocente(codigodocente, apellidos, nombres, expedidaen, lugarnacimiento, fun.convertFechaAño(fechanacimiento), edad, direccion, departamento, municipio, telefono, celular, email, profesion);
        if (update != -1)
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al actualizar datos de docente@";
        }
        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string insertests001(string introduccion, string propositos, string numeroperfilparticipantes, string metodologia, string criterioevaluacion, string cargo, string informacionadicional, string coddocente)
    {

        Institucion inst = new Institucion();
        string ca = "";

        DataRow insert = inst.procinsertests001(introduccion, propositos, numeroperfilparticipantes, metodologia, criterioevaluacion, cargo, informacionadicional, HttpContext.Current.Session["CodEstraCoordinador"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString(), HttpContext.Current.Session["a"].ToString(), coddocente);
        if (insert != null)
        {
            ca = "true@";
            ca += insert["codigo"].ToString();
        }
        else
        {
            ca = "Ocurrio un error al insertar ests001@";
        }

        return ca;
    }

    

    [WebMethod(EnableSession = true)]
    public static string loadestras001(string coddocente)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataRow datosinstrumento = inst.procloadestras001(coddocente);

        if (datosinstrumento != null)
        {
            //codigo, codestracoordinador, introduccion, propositos, nroperfilestudiante, metodologia, criterios, iddocente, cargo, infoadicional, momento, sesion, actividad
            ca = "datosintrumento@";
            ca += datosinstrumento["codigo"].ToString()
            + "@" + datosinstrumento["introduccion"].ToString()
            + "@" + datosinstrumento["propositos"].ToString()
            + "@" + datosinstrumento["nroperfilestudiante"].ToString()
            + "@" + datosinstrumento["metodologia"].ToString()
            + "@" + datosinstrumento["criterios"].ToString()
            + "@" + datosinstrumento["cargo"].ToString()
            + "@" + datosinstrumento["infoadicional"].ToString();
        }
        else
        {
            ca = "vacio@";
        }

        return ca;
    }


    
    [WebMethod(EnableSession = true)]
    public static string updateests001(string codigoestrategia, string introduccion, string propositos, string numeroperfilparticipantes, string metodologia, string criterioevaluacion, string cargo, string informacionadicional)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        long update = inst.procupdateestras001(codigoestrategia, introduccion, propositos, numeroperfilparticipantes, metodologia, criterioevaluacion, cargo, informacionadicional);
        if (update != -1)
        {
            ca = "true@";
        }
        else
        {
            ca = "false@";
            ca += "Ocurrio un error al actualizar datos de estras001 "+ codigoestrategia + "@";
        }
        return ca;
    }

}
