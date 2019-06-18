using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using System.Web.Services;
using System.IO;

public partial class ginvestigacionlistado : System.Web.UI.Page
{

    Estrategias est = new Estrategias();
    Institucion ins = new Institucion();

    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["codperfil"] != null)
        {

        }
        else
            Response.Redirect("Default.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 

        if (!IsPostBack)
        {

        }
    }
    //cargar  registros
    [WebMethod(EnableSession = true)]
    public static string cargarlista()
    {
        string ca = "";

        Institucion ins = new Institucion();

        DataTable datos = ins.cargarGruposInvestigacion();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "true_list@";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i+1) + "</td>";
                ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["pregunta"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["tipo"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["linea"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["concepto"].ToString() + "</td>";
                ca += "<td><a href='ginvestigacionlistado_evi.aspx?cod=" + datos.Rows[i]["codigo"].ToString() + "' ><img src='Imagenes/upload.png' width='20' /></a></td>";
                ca += "</tr>";
            }
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarlistamunicipios()
    {
        string ca = "";

        Institucion ins = new Institucion();

        DataTable datos = ins.cargarGruposInvestigacionConvocatoriasxMunicipios();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "true_list@";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["total"].ToString() + "</td>";
                ca += "</tr>";
            }
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarlistainstituciones()
    {
        string ca = "";

        Institucion ins = new Institucion();

        DataTable datos = ins.cargarGruposInvestigacionConvocatoriasxInstituciones();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "true_list@";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["total"].ToString() + "</td>";
                ca += "</tr>";
            }
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarlistasedes()
    {
        string ca = "";

        Institucion ins = new Institucion();

        DataTable datos = ins.cargarGruposInvestigacionConvocatoriasxSedes();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "true_list@";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["total"].ToString() + "</td>";
                ca += "</tr>";
            }
        }
        return ca;
    }

    //Ver evidencias
    [WebMethod(EnableSession = true)]
    public static string ver(string codigo)
    {
        string ca = "";

        Institucion ins = new Institucion();

        DataTable datos = ins.cargarEvidenciasGruposInvestigacion(codigo);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "true_see@";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + datos.Rows[i]["nombrearchivo"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["tamano"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["fechacreado"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombreusuario"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombreguardado"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["path"].ToString() + "</td>";
                ca += "</tr>";
            }
        }
        return ca;
    }

}