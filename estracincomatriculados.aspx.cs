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

public partial class estracincomatriculados : System.Web.UI.Page
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

        DataTable datos = ins.cargarMatriculadosEstra5();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "true_list@";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i+1) + "</td>";
                ca += "<td>" + datos.Rows[i]["nombre"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["apellido"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["identificacion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["direccion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["telefono"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["correo"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["cargo"].ToString() + "</td>";
                ca += "</tr>";
            }
        }
        return ca;
    }

   
}