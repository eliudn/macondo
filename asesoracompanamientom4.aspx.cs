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

public partial class asesoracompanamientom4 : System.Web.UI.Page
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
       //lblMomento.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        Session["m"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        Session["e"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["e"]);
        //Session["s"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
        //Session["a"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["a"]);
    }
    private string encabezado()
    {
        string ca = "";

        

        return ca;
    }

    private void buscarUsuario()
    {
        Usuario usu = new Usuario();
        DataRow dato = usu.buscarUsuario(Session["codusuario"].ToString());
        if (dato != null)
        {
            lblCodUsuario.Text = dato["cod"].ToString();
            Session["codusuario"] = dato["cod"].ToString();
        }

    }

   
    Funciones fun = new Funciones();

    [WebMethod(EnableSession = true)]
    public static string loadReport()
    {
        string ca = "";
        Estrategias est = new Estrategias();

        //Asesorías realizadas a los grupos de investigación infantiles y juveniles para elaboración del informe
        DataTable asesoriasgpinforme = est.asesoriasgpinforme("", "", "", "");
        //DataTable resumenproyectoinvestigacion = est.resumenproyectoinvestigacion("", "", "", "", "");
        double meta1 = 0;
        int count1 = 0;
        int total1 = 420;
        if (asesoriasgpinforme != null && asesoriasgpinforme.Rows.Count > 0)
        {
            count1 = asesoriasgpinforme.Rows.Count;
            meta1 = ((double)count1 / (double)total1) * 100;
            meta1 = Math.Round(meta1, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}
        }
        ca += "<tr>";
        ca += "<td><b>1.</b> Asesorías realizadas a los grupos de investigación infantiles y juveniles para elaboración del informe</td>";
        ca += "<td class='center'>" + count1 + " de " + total1 + "</td>";
        ca += "<td class='center'>" + meta1 + "%</td>";
        ca += "<td class='noExl center'><a href='asesoriasgpinforme.aspx'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0
        ca += "</tr>";



        //2. Asistentes a la sesión de asesoría a grupos infantiles y juveniles
        DataRow asistentessesionasesoria = est.asistentessesionasesoria();
        //DataTable resumenproyectoinvestigacion = est.resumenproyectoinvestigacion("", "", "", "", "");
        double meta2 = 0;
        int count2 = 0;
        int total2 = 42400;
        if (asistentessesionasesoria != null)
        {
            count2 = Convert.ToInt32(asistentessesionasesoria["total"].ToString());
            meta2 = ((double)count2 / (double)total2) * 100;
            meta2 = Math.Round(meta2, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}
        }
        ca += "<tr>";
        ca += "<td><b>2.</b> Sedes educativas con grupos de investigación infantiles y juveniles que eleboran su informe de investgación.</td>";
        ca += "<td class='center'>" + count2 + " de " + total2 + "</td>";
        ca += "<td class='center'>" + meta2 + "%</td>";
        ca += "<td class='noExl center'>Sin detalles</td>";//?fechaini=0&fechafin=0
        ca += "</tr>";


        //3. Asesorías a los grupos infantiles y juveniles evaluadas y subidas a la plataforma de Ciclón
        DataTable asesoriasgpevaluadasm4 = est.asesoriasgpevaluadasm4("", "", "", "");
        //DataTable resumenproyectoinvestigacion = est.resumenproyectoinvestigacion("", "", "", "", "");
        double meta3 = 0;
        int count3 = 0;
        int total3 = 420;
        if (asesoriasgpevaluadasm4 != null && asesoriasgpevaluadasm4.Rows.Count > 0)
        {
            count3 = asesoriasgpevaluadasm4.Rows.Count;
            meta3 = ((double)count3 / (double)total3) * 100;
            meta3 = Math.Round(meta3, 2);
            //if (meta3 > 100)
            //{
            //    meta3 = 100;
            //}
        }
        ca += "<tr>";
        ca += "<td><b>3.</b> Asesorías a los grupos infantiles y juveniles evaluadas y subidas a la plataforma de Ciclón</td>";
        ca += "<td class='center'>" + count3 + " de " + total3 + "</td>";
        ca += "<td class='center'>" + meta3 + "%</td>";
        ca += "<td class='noExl center'><a href='asesoriasgpevaluadasm4.aspx'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0
        ca += "</tr>";


        //4. Grupos con soporte de ejecución del presupuesto
        DataTable gpsoportepresupuesto = est.gpsoportepresupuesto("", "", "", "");
        //DataTable resumenproyectoinvestigacion = est.resumenproyectoinvestigacion("", "", "", "", "");
        double meta4 = 0;
        int count4 = 0;
        int total4 = 420;
        if (gpsoportepresupuesto != null && gpsoportepresupuesto.Rows.Count > 0)
        {
            count4 = gpsoportepresupuesto.Rows.Count;
            meta4 = ((double)count4 / (double)total4) * 100;
            meta4 = Math.Round(meta4, 2);
            //if (meta4 > 100)
            //{
            //    meta4 = 100;
            //}
        }
        ca += "<tr>";
        ca += "<td><b>4.</b> Grupos con soporte de ejecución del presupuesto</td>";
        ca += "<td class='center'>" + count4 + " de " + total4 + "</td>";
        ca += "<td class='center'>" + meta4 + "%</td>";
        ca += "<td class='noExl center'><a href='gpsoportepresupuesto.aspx'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0
        ca += "</tr>";


        //5. Publicaciones impresas y/o digitales de las experiencias investigativas 
        DataTable publicacionesimpresas = est.publicacionesimpresas();
        //DataTable resumenproyectoinvestigacion = est.resumenproyectoinvestigacion("", "", "", "", "");
        double meta5 = 0;
        int count5 = 0;
        int total5 = 1;
        if (publicacionesimpresas != null && publicacionesimpresas.Rows.Count > 0)
        {
            count5 = publicacionesimpresas.Rows.Count;
            meta5 = ((double)count5 / (double)total5) * 100;
            meta5 = Math.Round(meta5, 2);
            //if (meta5 > 100)
            //{
            //    meta5 = 100;
            //}
        }
        ca += "<tr>";
        ca += "<td><b>5.</b> Publicaciones impresas y/o digitales de las experiencias investigativas </td>";
        ca += "<td class='center'>" + count5 + " de " + total5 + "</td>";
        ca += "<td class='center'>" + meta5 + "%</td>";
        ca += "<td class='noExl center'>Sin detalles</td>";//?fechaini=0&fechafin=0
        ca += "</tr>";



        return ca;
    }




    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("reporteindicadores.aspx");
    }

}