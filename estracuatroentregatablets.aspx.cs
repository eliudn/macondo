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

public partial class estracuatroentregatablets : System.Web.UI.Page
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
        int total = 0;
        Institucion ins = new Institucion();

        DataTable datos = ins.cargarListaEntregaTablets();

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
                ca += "<td>" + datos.Rows[i]["dane"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["total"].ToString() + "</td>";
                ca += "</tr>";
                total += Convert.ToInt32(datos.Rows[i]["total"].ToString());
            }
            ca += "_list@<b style='float:right;'>Total de tabletas entregadas: " + total.ToString("N0") + "</b>";
        }
        return ca;
    }

}