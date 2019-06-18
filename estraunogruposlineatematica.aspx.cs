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

public partial class estraunogruposlineatematica : System.Web.UI.Page
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

            //obtenerGET();

            Estrategias estra = new Estrategias();
            DataRow dato = estra.buscarCodEstrategiaxCoordinador(Session["identificacion"].ToString());

            if (dato != null)
            {
                Session["codestracoordinador"] = dato["codestracoordinador"].ToString();

            }
            else
            {
                mostrarmensaje("error", "ERROR: Ud. No es coordinador de esta estrategia.");
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
        Response.Redirect("estramomentos.aspx");
    }


    [WebMethod(EnableSession = true)]
    public static string listarAreas()
    {
        Institucion inst = new Institucion();
        string ca = "";

        DataTable datos = inst.listarAreas();
        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["nombre"].ToString() + "</td>";
                ca += "<td align='center'>" + datos.Rows[i]["total"].ToString() + "</td>";
                ca += "<td style='padding:5px;' ><a class='btn btn-success' onclick=\"$('#table').hide(), $('#form').fadeIn(500),  loadProyectosAsociados(" + datos.Rows[i]["codigo"].ToString() + ") \">Ver Proyectos</a><br/></td>";
                ca += "</tr>";
            }
        }
        else
        {
            ca += "<tr><td colspan='10'>No se encontraron memorias registradas por parte del asesor.</td></tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadProyectos(string codigo)
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataTable datos = estra.loadProyectosLineaTematica(codigo);
        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "loadSelect@";
            ca += datos.Rows[0]["area"].ToString() + "@";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + datos.Rows[i]["nombredepartamento"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombremunicipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombreins"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["danesede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombresede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombregrupo"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["tipo"].ToString() + "</td>";
                ca += "</tr>";
            }
            
        }
        return ca;
    }
   
}

