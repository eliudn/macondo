using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using ClosedXML.Excel;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Web.Services;

public partial class replineabasegeneraldet : System.Web.UI.Page
{

    LineaBase lb = new LineaBase();
    Institucion inst = new Institucion();
    Docentes doc = new Docentes();

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
            if (Session["codrol"].ToString() == "9" || Session["codrol"].ToString() == "1" || Session["codrol"].ToString() == "18")
            {
                obtenerGET();
            }          
        }
    }

    public void obtenerGET()
    {
        Session["pregunta"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["pregunta"]);

        if (Session["pregunta"] != null)
        {
            switch (Session["pregunta"].ToString())
            {
                case "1_4":
                    Session["tipo"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["tipo"]);
                    break;
                case "211":
                    Session["resp"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["resp"]);
                    break;
                case "221":
                    Session["resp"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["resp"]);
                    break;
            }
        }

        
    }

    [WebMethod(EnableSession = true)]
    public static string validarpregunta()
    {
        string ca = "";

        LineaBase lb = new LineaBase();

        string pregunta = HttpContext.Current.Session["pregunta"].ToString();


        switch (pregunta)
        {
            case "1_4":
                string tipo = HttpContext.Current.Session["tipo"].ToString();
                switch (tipo)
                {
                    case "pagweb":
                        tipo = "Página de internet";
                        break;
                    case "blog":
                        tipo = "Blogs";
                        break;
                    case "wikis":
                        tipo = "Wikis";
                        break;
                    case "foros":
                        tipo = "Foros";
                        break;
                    case "reds":
                        tipo = "Redes sociales";
                        break;
                    case "pedag":
                        tipo = "Pedagógicos";
                        break;
                }
                DataTable datos = lb.cargarDetalleHerramientasWebLineaBase(tipo);

                if (datos != null && datos.Rows.Count > 0)
                {
                    ca += "<thead>";
                    ca += "<tr>";
                    ca += "<th>MUNICIPIO</th>";
                    ca += "<th>INSTITUCIÓN</th>";
                    ca += "<th>SEDE</th>";
                    ca += "<th>PÁGINA DE INTERNET <br /> DIRECCIÓN</th>";
                    ca += "</tr>";
                    ca += "</thead>";
                    ca += "</tbody>";
                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        ca += "<tr>";
                        ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
                        ca += "<td>" + datos.Rows[i]["institucion"].ToString() + "</td>";
                        ca += "<td>" + datos.Rows[i]["sede"].ToString() + "</td>";
                        ca += "<td>" + datos.Rows[i]["direccion"].ToString() + "</td>";
                        ca += "</tr>";
                    }
                    ca += "<tbody>";
                }

                break;
            case "211":
                string resp = HttpContext.Current.Session["resp"].ToString();
                DataTable datos211 = null;
                switch (resp)
                {
                    case "si":
                         datos211 = lb.SedesxFormacionDocenteUsoTIC();
                        break;
                    case "no":
                        datos211 = lb.SedesxFormacionDocenteUsoTIC_NA();
                        break;
                }
                if (datos211 != null && datos211.Rows.Count > 0)
                {
                    ca += "<thead>";
                    ca += "<tr>";
                    ca += "<th>MUNICIPIO</th>";
                    ca += "<th>INSTITUCIÓN</th>";
                    ca += "<th>SEDE</th>";
                    if(resp == "si")
                        ca += "<th>PROCESO</th>";
                    ca += "</tr>";
                    ca += "</thead>";
                    ca += "</tbody>";
                    for (int i = 0; i < datos211.Rows.Count; i++)
                    {
                        ca += "<tr>";
                        ca += "<td>" + datos211.Rows[i]["municipio"].ToString() + "</td>";
                        ca += "<td>" + datos211.Rows[i]["institucion"].ToString() + "</td>";
                        ca += "<td>" + datos211.Rows[i]["sede"].ToString() + "</td>";
                        if (resp == "si")
                            ca += "<td>" + datos211.Rows[i]["comentario"].ToString() + "</td>";
                        ca += "</tr>";
                    }
                    ca += "<tbody>";
                }
                break;
            case "221":
                string resp221 = HttpContext.Current.Session["resp"].ToString();
                DataTable datos221 = null;
                switch (resp221)
                {
                    case "si":
                        datos221 = lb.SedesxPlanMejoramientoTIC();
                        break;
                    case "no":
                        datos221 = lb.SedesxPlanMejoramientoTIC_NA();
                        break;
                }
                if (datos221 != null && datos221.Rows.Count > 0)
                {
                    ca += "<thead>";
                    ca += "<tr>";
                    ca += "<th>MUNICIPIO</th>";
                    ca += "<th>INSTITUCIÓN</th>";
                    ca += "<th>SEDE</th>";
                    if(resp221 == "si")
                        ca += "<th>PROCESO</th>";
                    ca += "</tr>";
                    ca += "</thead>";
                    ca += "</tbody>";
                    for (int i = 0; i < datos221.Rows.Count; i++)
                    {
                        ca += "<tr>";
                        ca += "<td>" + datos221.Rows[i]["municipio"].ToString() + "</td>";
                        ca += "<td>" + datos221.Rows[i]["institucion"].ToString() + "</td>";
                        ca += "<td>" + datos221.Rows[i]["sede"].ToString() + "</td>";
                        if (resp221 == "si")
                            ca += "<td>" + datos221.Rows[i]["comentario"].ToString() + "</td>";
                        ca += "</tr>";
                    }
                    ca += "<tbody>";
                }
                break;
        }

        return ca;
    }
  

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        Page page = new Page();
        HtmlForm form = new HtmlForm();


        // Deshabilitar la validación de eventos, sólo asp.net 2
        page.EnableEventValidation = false;

        // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
        page.DesignerInitialize();

        page.Controls.Add(form);
        //form.Controls.Add(panelResultado);//PanelTablaEncuesta, va el nombre del panel que contiene los resultados de las tablas

        page.RenderControl(htw);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=Export_Encuesta" + DateTime.Now.ToShortTimeString() + ".xls");
        Response.Charset = "UTF-8";
        Response.ContentEncoding = Encoding.Default;
        Response.Write(sb.ToString());
        Response.End();

    }
    public override void VerifyRenderingInServerForm(Control control)
   {
       /// Verifies that the control is rendered /
   }
  
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    

}