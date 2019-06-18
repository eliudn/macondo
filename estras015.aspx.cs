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

public partial class estras015 : System.Web.UI.Page
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
            if (Session["identificacion"] != null)
            {
                   
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
           

        }
    }
    public void obtenerGET()
    {
        //Session["e"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["e"]);
        //lblMomento.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        //lblSesion.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);

    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("estramomentos.aspx");
    }

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

            //ca += "@" + datoUsuario["cod"].ToString();
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
                //ca += datos.Rows[i]["codigo"].ToString() + "@" + datos.Rows[i]["nombre"].ToString();
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
            ca = "sedes@";
            ca += "<option value='' disabled selected>Seleccione Sede</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string datosSedes(string codigosede)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataRow datossede = inst.cargarDatosSede(codigosede);

        if (datossede != null)
        {
            ca = "datossede&";
            ca += "<option value='0' disabled>Seleccione departamento...</option>"
                + "<option value = '" + datossede["coddepartamento"].ToString() + "' selected>" + datossede["nombredepartamento"].ToString() + "</option>"
                + "&<option value='0' disabled>Seleccione municipio...</option>"
                + "<option value = '" + datossede["codmunicipio"].ToString() + "' selected>" + datossede["nombremunicipio"].ToString() + "</option>"
                + "&" + datossede["telefono"].ToString()
                + "&" + datossede["email"].ToString()
                + "&" + datossede["direccion"].ToString();
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string grupoInvestigacion(string coddocente)
    {

        //Funciones fun = new Funciones();

        //fun.convertFechaAño();

        string ca = "";

        Institucion inst = new Institucion();

        DataTable gruposinvestigacion = inst.gruposInvestigacionDocente(coddocente);

        if (gruposinvestigacion != null && gruposinvestigacion.Rows.Count > 0)
        {
            ca = "gruposinvestigacion@";
            ca += "<option value='' disabled selected>Seleccione grupo investigación...</option>";
            for (int i = 0; i < gruposinvestigacion.Rows.Count; i++)
            {
                ca += "<option value='" + gruposinvestigacion.Rows[i]["codigo"].ToString() + "'>" + gruposinvestigacion.Rows[i]["nombre"].ToString() + "</option>";
            }
        }
        else
        {
            ca = "vacio@<option value='sin' disabled selected>Sin grupos de investigación</option>";
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
    public static string insertests015(string grupoinvestigacion, string nombrevalorador, string profesionvalorador, string lineatematica, string firmavalorador, string observaciones)
    {

        Institucion inst = new Institucion();
        string ca = "";

        DataRow insert = inst.procinsertests015(grupoinvestigacion, nombrevalorador, profesionvalorador, lineatematica, firmavalorador, observaciones);
        if (insert != null)
        {
            ca = "true@";
            ca += insert["codigo"].ToString();
        }
        else
        {
            ca = "Ocurrio un error al insertar ests015@";
        }

        return ca;
    }



    [WebMethod(EnableSession = true)]
    public static string loadestras015(string codproyecto)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataRow datosinstrumento = inst.procloadestras015(codproyecto);

        if (datosinstrumento != null)
        {
            //codigo, nombrevalorador, profesionvalorador, lineatematica, firmavalorador, observaciones
            ca = "datosintrumento@";
            ca += datosinstrumento["codigo"].ToString()
            + "@" + datosinstrumento["nombrevalorador"].ToString()
            + "@" + datosinstrumento["profesionvalorador"].ToString()
            + "@" + datosinstrumento["lineatematica"].ToString()
            + "@" + datosinstrumento["firmavalorador"].ToString()
            + "@" + datosinstrumento["observaciones"].ToString();

            DataTable puntajes = inst.procloadPuntajesEstras015(datosinstrumento["codigo"].ToString());

            if (puntajes != null && puntajes.Rows.Count > 0)
            {
                for (int i = 0; i < puntajes.Rows.Count; i++)
                {
                    //"@" + puntajes.Rows[i]["numpuntaje"].ToString()
                    //+ 
                    ca += "@" + puntajes.Rows[i]["puntaje"].ToString();
                }
            }
            else
            {
                ca += "@vacio";
            }

        }
        else
        {
            ca = "vacio@";
        }

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string deletePuntajess015(string codigoestrategia)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        long delete = inst.procdeletePuntajess015(codigoestrategia);
        if (delete != -1)
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al eliminar Puntajes@";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string insertPuntajess015(string codigoestrategia, string numero, string puntaje)
    {

        Institucion inst = new Institucion();
        string ca = "";

        DataRow insert = inst.procinsertPuntajess015(codigoestrategia, numero, puntaje);
        if (insert != null)
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al insertar Puntaje " + numero + "@";
        }

        return ca;
    }



    [WebMethod(EnableSession = true)]
    public static string updateests015(string codigoestrategia, string nombrevalorador, string profesionvalorador, string lineatematica, string firmavalorador, string observaciones)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        long update = inst.procupdateests015(codigoestrategia, nombrevalorador, profesionvalorador, lineatematica, firmavalorador, observaciones);
        if (update != -1)
        {
            ca = "true@";
        }
        else
        {
            ca = "false@";
            ca += "Ocurrio un error al actualizar datos de estras015 " + codigoestrategia + "@";
        }
        return ca;
    }

}


