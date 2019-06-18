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

public partial class estrag001reportes : System.Web.UI.Page
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
            obtenerGET();
            //if (Session["identificacion"] != null)
            //{
            //    Estrategias estra = new Estrategias();
            //    DataRow dato = estra.buscarCodEstraAsesorxCoordinador(Session["identificacion"].ToString());

            //    if (dato != null)
            //    {
            //        Session["CodEstraAsesorCoordinador"] = dato["codigo"].ToString();

            //    }
            //}
        }
    }
    public void obtenerGET()
    {
        Session["cod"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["cod"]);
        Session["codsede"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["codsede"]);
        //Session["m"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        //Session["s"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
        //Session["a"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["a"]);

    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("estras004SedesReporte.aspx?e=" + Session["e"].ToString() + "&m=" + Session["m"].ToString() + "&s=" + Session["s"].ToString() + "&j=" + Session["j"].ToString());
    }


    [WebMethod(EnableSession = true)]
    public static string cargarAsesores()
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataTable asesores = estra.listarAsesores(HttpContext.Current.Session["e"].ToString());

        if (asesores != null && asesores.Rows.Count > 0)
        {
            ca += "<option value='0' selected disabled>Seleccione asesor</option>";
            for (int i = 0; i < asesores.Rows.Count; i++)
            {
                ca += "<option value='" + asesores.Rows[i]["codigo"].ToString() + "'>" + asesores.Rows[i]["asesor"].ToString().ToUpper() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession=true)]
    public static string listarcontrolasistencia()
    {
        string ca = "";
        Estrategias estra = new Estrategias();
        Funciones fun = new Funciones();

        DataTable listado = estra.listarcontrolasistencia(HttpContext.Current.Session["cod"].ToString(), HttpContext.Current.Session["codsede"].ToString(), HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString(), HttpContext.Current.Session["j"].ToString());
        if (listado != null && listado.Rows.Count > 0)
        {
            for (int i = 0; i < listado.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + listado.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + listado.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + listado.Rows[i]["tipoactividad"].ToString() + "</td>";
                ca += "<td>" + listado.Rows[i]["tema"].ToString() + "</td>";
                ca += "<td>" + listado.Rows[i]["facilitador"].ToString() + "</td>";
                ca += "<td>" + listado.Rows[i]["horainicio"].ToString() + " - " + listado.Rows[i]["horafinal"].ToString() + "</td>";
                ca += "<td>" + fun.convertFechaDia(listado.Rows[i]["fecha"].ToString()) + "</td>";
                ca += "<td>" + listado.Rows[i]["momento"].ToString() + "</td>";
                ca += "<td>" + listado.Rows[i]["sesion"].ToString() + "</td>";
                ca += "<td>" + listado.Rows[i]["jornada"].ToString() + "</td>";
                ca += "<td><a class = 'btn btn-success' onclick='detalles(" + listado.Rows[i]["codigo"].ToString() + ")'>Ver</a></td>";
                ca += "</tr>";
            }
        }
        else
        {
            ca += "<tr>";
            ca += "<td colspan = '10'>No se encontraron datos registrados por parte de este asesor</td>";
            ca += "</tr>";
        }
        return ca;
    }

    [WebMethod(EnableSession=true)]
    public static string detalledocentesasistentes(string codigo)
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataTable docentes = estra.detalledocenteasistentes(codigo);
        if (docentes != null && docentes.Rows.Count > 0)
        {
            for (int i = 0; i < docentes.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + docentes.Rows[i]["docente"].ToString() + "</td>";
                ca += "</tr>";
            }
        }
        return ca;
    }

}