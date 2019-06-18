using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Services;
using System.Drawing;

public partial class estras006 : System.Web.UI.Page
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
            DataRow dato = est.buscarCodEstraAsesorxCoordinador(Session["identificacion"].ToString());

            if (dato != null)
            {
                Session["CodAsesorCoordinador"] = dato["codigo"].ToString();

            }
        }
    }
    public void obtenerGET()
    {
        Session["e"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["e"]);
        Session["m"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        Session["s"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
        Session["a"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["a"]);

        if (Session["e"] != null || Session["m"] != null || Session["s"] != null)
        {
            lblEstrategia.Text = Session["e"].ToString();
            lblMomento.Text = Session["m"].ToString();
            lblSesion.Text = Session["s"].ToString();
            if (Session["a"] != null)
                lblActividad.Text = Session["a"].ToString();
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
        }

        return ca;
    }

    
    [WebMethod(EnableSession = true)]
    public static string insertests006(string sede, string nombresesion, string temasesion, string informacionadicional, string fechaelaboracion, string horasesion, string nombresapellidosmoderador, string nombresapellidosrelator, string aspectosdesarrollados, string conclusiones, string bibliografia)
    {

        Institucion inst = new Institucion();
        string ca = "";
        Funciones fun = new Funciones();


        DataRow insert = inst.procinsertests006(sede, nombresesion, temasesion, informacionadicional, fun.convertFechaAño(fechaelaboracion), horasesion, nombresapellidosmoderador, nombresapellidosrelator, aspectosdesarrollados, conclusiones, bibliografia, HttpContext.Current.Session["CodAsesorCoordinador"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString(), HttpContext.Current.Session["a"].ToString());
        if (insert != null)
        {
            ca = "true@";
            ca += insert["codigo"].ToString();
        }
        else
        {
            ca = "Ocurrio un error al insertar estras001@";
        }

        return ca;
    }

    
    [WebMethod(EnableSession = true)]
    public static string loadestras006(string codigosede)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataRow datosinstrumento = inst.procloadestras006(codigosede);

        if (datosinstrumento != null)
        {
            //codigo, nomsesion, temasesion, horasesion, nommoredador, nomrelator, aspectosdesarrollados, conclusiones, bibliografia, momento,sesion, actividad, fechaelaboracion
            ca = "datosintrumento@";
            ca += datosinstrumento["codigo"].ToString()
            + "@" + datosinstrumento["nomsesion"].ToString()
            + "@" + datosinstrumento["temasesion"].ToString()
            + "@" + datosinstrumento["informacionadicional"].ToString()
            + "@" + datosinstrumento["fechaelaboracion"].ToString()
            + "@" + datosinstrumento["horasesion"].ToString()
            + "@" + datosinstrumento["nommoredador"].ToString()
            + "@" + datosinstrumento["nomrelator"].ToString()
            + "@" + datosinstrumento["aspectosdesarrollados"].ToString()
            + "@" + datosinstrumento["conclusiones"].ToString()
            + "@" + datosinstrumento["bibliografia"].ToString();
        }
        else
        {
            ca = "vacio@";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string updateests006(string codigoestrategia, string nombresesion, string temasesion, string informacionadicional, string fechaelaboracion, string horasesion, string nombresapellidosmoderador, string nombresapellidosrelator, string aspectosdesarrollados, string conclusiones, string bibliografia)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        long update = inst.procupdateests006(codigoestrategia, nombresesion, temasesion, informacionadicional, fun.convertFechaAño(fechaelaboracion), horasesion, nombresapellidosmoderador, nombresapellidosrelator, aspectosdesarrollados, conclusiones, bibliografia);
        if (update != -1)
        {
            ca = "true@";
        }
        else
        {
            ca = "false@";
            ca += "Ocurrio un error al actualizar datos de estras001 " + codigoestrategia + "@";
        }
        return ca;
    }

    //expositores
    [WebMethod(EnableSession = true)]
    public static string deleteExpositoress006(string codigoestrategia)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        long delete = inst.procdeleteExpositoress006(codigoestrategia);
        if (delete != -1)
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al eliminar Expositores@";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string insertExpositoress006(string codigoestrategia, string numero, string nombresapellidosexpositores, string correoexpositores)
    {

        Institucion inst = new Institucion();
        string ca = "";

        DataRow insert = inst.procinsertExpositoress006(codigoestrategia, numero, nombresapellidosexpositores, correoexpositores);
        if (insert != null)
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al insertar expositor " + numero + "@";
        }

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string loadExpositoress006(string codigoestrategia, int total)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.procloadExpositoress006(codigoestrategia);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "exp&";
            ca += "<tr>";
            ca += "<th width=\"5%\"> No. </th>";
            ca += "<th width=\"50%\"> Nombres y apellidos de los expositores</th>";
            ca += "<th>Correo electrónico de los expositores</th>";
            ca += "</tr>";
            
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr id=\"campus" + total + "\">";
                ca += "<td>" + total + ". </td>";
                ca += "<td><input type=\"text\"  id =\"nombresapellidosexpositores" + total + "\" name =\"nombresapellidosexpositores" + total + "\"  class=\"width-90 TextBox\" value=\"" + datos.Rows[i]["nombreapellidoexpositores"].ToString() + "\" ></td>";
                ca += "<td id=\"radiotr" + total + "\"><input type=\"text\"  id =\"correoexpositores" + total + "\" name =\"correoexpositores" + total + "\"  class=\"width-90 TextBox\" value=\"" + datos.Rows[i]["emailexpositores"].ToString() + "\" >";

                if (i == datos.Rows.Count - 1)
                {
                    ca += "<button id=\"remove\" class=\"btn btn-danger\" onclick=\"fRemove(" + total + ")\" > - </button></td>";
                }
                else
                {
                    ca += "</td>";
                    total = total + 1;
                }
                ca += "</tr>";


            }
            ca += "&" + total;
        }
        else
        {
            ca = "vacio&";
            ca += "<tr><th width=\"5%\"> No. </th>";
            ca += "<th width=\"50%\"> Nombres y apellidos de los expositores</th>";
            ca += "<th>Correo electrónico de los expositores</th>";
            ca += "</tr> ";
            ca += "<tr>";
            ca += "<td>1.</td>";
            ca += "<td><input type=\"text\" id=\"nombresapellidosexpositores1\" name=\"nombresapellidosexpositores1\" class=\"width-90 TextBox\"></td>";
            ca += "<td><input type=\"text\" id=\"correoexpositores1\" name=\"correoexpositores1\" class=\"width-90 TextBox\"></td>";
            ca += "</tr>";
        }

        return ca;
    }


    //integrantes
    [WebMethod(EnableSession = true)]
    public static string deleteIntegrantess006(string codigoestrategia)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        long delete = inst.procdeleteIntegrantess006(codigoestrategia);
        if (delete != -1)
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al eliminar Integrantes@";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string insertIntegrantess006(string codigoestrategia, string numero, string nombreapellidosintegrantes, string correointegrantes)
    {

        Institucion inst = new Institucion();
        string ca = "";

        DataRow insert = inst.procinsertIntegrantess006(codigoestrategia, numero, nombreapellidosintegrantes, correointegrantes);
        if (insert != null)
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al insertar Integrantes " + numero + "@";
        }

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string loadIntegrantess006(string codigoestrategia, int total)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.procloadIntegrantess006(codigoestrategia);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "exp&";
            ca += "<tr>";
            ca += "<th width=\"5%\"> No. </th>";
            ca += "<th width=\"50%\"> Nombres y apellidos de los integrantes del grupo </th>";
            ca += "<th>Correo electrónico de los integrantes del grupo</th>";
            ca += "</tr>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr id=\"oCampus" + total + "\">";
                ca += "<td>" + total + ". </td>";
                ca += "<td><input type=\"text\"  id =\"nombreapellidosintegrantes" + total + "\" name =\"nombreapellidosintegrantes" + total + "\"  class=\"width-90 TextBox\" value=\"" + datos.Rows[i]["nombreapellidointegrantes"].ToString() + "\" ></td>";
                ca += "<td id=\"oRadiotr" + total + "\"><input type=\"text\"  id =\"correointegrantes" + total + "\" name =\"correointegrantes" + total + "\"  class=\"width-90 TextBox\" value=\"" + datos.Rows[i]["emailintegrantes"].ToString() + "\" >";

                if (i == datos.Rows.Count - 1)
                {
                    ca += "<button id=\"oRemove\" class=\"btn btn-danger\" onclick=\"foRemove(" + total + ")\" > - </button></td>";
                }
                else
                {
                    ca += "</td>";
                    total = total + 1;
                }
                ca += "</tr>";


            }
            ca += "&" + total;
        }
        else
        {
            ca = "vacio&";
            ca += "<tr>";
            ca += "<th width=\"5%\"> No. </th>";
            ca += "<th width=\"50%\"> Nombres y apellidos de los integrantes del grupo </th>";
            ca += "<th>Correo electrónico de los integrantes del grupo</th>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<td>1.</td>";
            ca += "<td><input type=\"text\" id=\"nombreapellidosintegrantes1\" name=\"nombreapellidosintegrantes1\" class=\"width-90 TextBox\"></td>";
            ca += "<td><input type=\"text\" id=\"correointegrantes1\" name=\"correointegrantes1\" class=\"width-90 TextBox\"></td>";
            ca += "</tr>";
        }

        return ca;
    }




    //preguntas
    [WebMethod(EnableSession = true)]
    public static string deletePreguntass006(string codigoestrategia)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        long delete = inst.procdeletePreguntass006(codigoestrategia);
        if (delete != -1)
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al eliminar Preguntas@";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string insertPreguntass006(string codigoestrategia, string nopregunta, string pregunta)
    {

        Institucion inst = new Institucion();
        string ca = "";

        DataRow insert = inst.procinsertPreguntass006(codigoestrategia, nopregunta, pregunta);
        if (insert != null)
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al insertar Preguntas " + nopregunta + "@";
        }

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string loadPreguntass006(string codigoestrategia, int total)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.procloadPreguntass006(codigoestrategia);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "preg&";
            ca += "<tr>";
            ca += "<th width=\"5%\"> No. </th>";
            ca += "<th>Pregunta</th>";
            ca += "</tr>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr id=\"campus12" + total + "\">";
                ca += "<td>" + total + ". </td>";
                ca += "<td id=\"radiotr1" + total + "\"><input type=\"text\"  id =\"pregunta" + total + "\" name =\"pregunta" + total + "\"  class=\"width-90 TextBox\" value=\"" + datos.Rows[i]["pregunta"].ToString() + "\" >";

                if (i == datos.Rows.Count - 1)
                {
                    ca += "<button id=\"remove1\" class=\"btn btn-danger\" onclick=\"fRemove1(" + total + ")\" > - </button></td>";
                }
                else
                {
                    ca += "</td>";
                    total = total + 1;
                }
                ca += "</tr>";
            }
            ca += "&" + total;
        }
        else
        {
            ca = "vacio&";
            ca += "<tr>";
            ca += "<th width=\"5%\"> No. </th>";
            ca += "<th>Pregunta</th>";
            ca += "</tr>";
            ca += "<tr>";
            ca += "<td>1.</td>";
            ca += "<td><input type=\"text\" id=\"pregunta1\" name=\"pregunta1\" class=\"width-90 TextBox\"></td>";
            ca += "</tr>";
        }

        return ca;
    }
}