using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Services;

public partial class estra2lineastematicas : System.Web.UI.Page
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
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 
        if (!IsPostBack)
        {
            if (Session["codrol"] != null)
            {
                obtenerGET();
 
                buscarUsuario();
            }
        }
    }
    public void obtenerGET()
    {
        Session["fechaini"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["fechaini"]);
        Session["fechafin"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["fechafin"]);
    }
    private string encabezado()
    {
        string ca = "";

        //ca += "<b>Momento: </b>" + lblMomento.Text + " - " + "<b>Sesión:</b> " + lblSesion.Text + "<br/> ";

        return ca;
    }
    private void buscarUsuario()
    {
        Usuario usu = new Usuario();
        DataRow dato = usu.buscarUsuario(Session["codusuario"].ToString());
        if (dato != null)
        {
            lblCodUsuario.Text = dato["cod"].ToString();
        
        }

    }


    [WebMethod(EnableSession = true)]
    public static string estra2lineastematicas_()
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable estra2lineastematicas = est.estra2LineasTematicas("", "", "", "");


        if (estra2lineastematicas != null && estra2lineastematicas.Rows.Count > 0)
        {
            int total = estra2lineastematicas.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < estra2lineastematicas.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + estra2lineastematicas.Rows[i]["nombre"].ToString() + " </td>";
                ca += "</tr>";
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td></td>";
            ca += "<td style=\"text-align:center;\">Sin resultados</td>";
            ca += "</tr>";
        }

        return ca;
    }

  
 
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("estra2disenolineamientos.aspx?m=0&e=2");
    }
    
}