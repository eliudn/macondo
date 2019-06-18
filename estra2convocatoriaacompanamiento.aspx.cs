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

public partial class estra2convocatoriaacompanamiento : System.Web.UI.Page
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
        //lblSesion.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
        //Session["s"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
        //Session["a"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["a"]);
    }
    private string encabezado()
    {
        string ca = "";

        ca += "<b>Desarrollo de las jornadas de formación </b><br/> ";
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
            Session["codusuario"] = dato["cod"].ToString();
        }

    }

   
    Funciones fun = new Funciones();
   
    [WebMethod(EnableSession = true)]
    public static string loadReport()
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable estra2JornadaFormacion1 = est.estra2JornadaFormacion("", "", "", "", "1", "1", "1");
        DataTable estra2SedesAsistencias1 = est.estra2SedesAsistencias("", "", "", "", "1", "1", "1");
        DataTable estra2RelatoriasInstitucionales1 = est.estra2RelatoriasInstitucionales("", "", "", "", "1", "1", "1");
        DataTable jornadasFormacionEvaluadas1 = est.jornadasFormacionEvaluadas("", "", "", "", "1", "1", "1");

        //Jornada de formación No. 1 realizadas
        double meta1 = 0;
        int count1 = 0;
        int total1 = 320;
        if (estra2JornadaFormacion1 != null && estra2JornadaFormacion1.Rows.Count > 0)
        {
            count1 = estra2JornadaFormacion1.Rows.Count;
            meta1 = ((double)count1 / (double)total1) * 100;
            meta1 = Math.Round(meta1, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}
            count1 = estra2JornadaFormacion1.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>1.</b> Jornada de formación No. 1 realizadas  </td>";
        ca += "<td class='center'>" + count1 + " de " + total1 + "</td>";
        ca += "<td class='center'>" + meta1 + "%</td>";
        ca += "<td class='noExl center'><a href='estra2jornadaformacion.aspx?m=1&s=1&j=1'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";

        //Sedes con asistencia cargadas de la sesión de formación No. 1
        double meta2 = 0;
        int count2 = 0;
        int total2 = 320;
        if (estra2SedesAsistencias1 != null && estra2SedesAsistencias1.Rows.Count > 0)
        {
            count2 = estra2SedesAsistencias1.Rows.Count;
            meta2 = ((double)count2 / (double)total2) * 100;
            meta2 = Math.Round(meta2, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}
            count2 = estra2SedesAsistencias1.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>2.</b> Sedes con asistencia cargadas de la sesión de formación No. 1 </td>";
        ca += "<td class='center'>" + count2 + " de " + total2 + "</td>";
        ca += "<td class='center'>" + meta2 + "%</td>";
        ca += "<td class='noExl center'><a href='estra2sedesasistencias.aspx?m=1&s=1&j=1'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";


        //Relatorías institucionales elaboradas jornada 1
        double meta3 = 0;
        int count3 = 0;
        int total3 = 320;
        if (estra2RelatoriasInstitucionales1 != null && estra2RelatoriasInstitucionales1.Rows.Count > 0)
        {
            count3 = estra2RelatoriasInstitucionales1.Rows.Count;
            meta3 = ((double)count3 / (double)total3) * 100;
            meta3 = Math.Round(meta3, 2);
            //if (meta3 > 100)
            //{
            //    meta3 = 100;
            //}
            count3 = estra2RelatoriasInstitucionales1.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>3.</b> Relatorías institucionales elaboradas jornada 1 </td>";
        ca += "<td class='center'>" + count3 + " de " + total3 + "</td>";
        ca += "<td class='center'>" + meta3 + "%</td>";
        ca += "<td class='noExl center'><a href='estra2relatoriasinstitucionales.aspx?m=1&s=1&j=1'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";

        //Jornada de formación  No. 1 evaluadas y subidas a la plataforma de Ciclón
        double meta4 = 0;
        int count4 = 0;
        int total4 = 320;
        if (jornadasFormacionEvaluadas1 != null && jornadasFormacionEvaluadas1.Rows.Count > 0)
        {
            count4 = jornadasFormacionEvaluadas1.Rows.Count;
            meta4 = ((double)count4 / (double)total4) * 100;
            meta4 = Math.Round(meta4, 2);
            //if (meta4 > 100)
            //{
            //    meta4 = 100;
            //}
            count4 = jornadasFormacionEvaluadas1.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>4.</b> Jornada de formación  No. 1 evaluadas y subidas a la plataforma de Ciclón </td>";
        ca += "<td class='center'>" + count4 + " de " + total4 + "</td>";
        ca += "<td class='center'>" + meta4 + "%</td>";
        ca += "<td class='noExl center'><a href='estra2jornadasformacionevaluadas.aspx?m=1&s=1&j=1'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";


        //JORNADA 2
        DataTable estra2JornadaFormacion2 = est.estra2JornadaFormacion("", "", "", "", "1", "1", "2");
        DataTable estra2SedesAsistencias2 = est.estra2SedesAsistencias("", "", "", "", "1", "1", "2");
        DataTable estra2RelatoriasInstitucionales2 = est.estra2RelatoriasInstitucionales("", "", "", "", "1", "1", "2");
        DataTable jornadasFormacionEvaluadas2 = est.jornadasFormacionEvaluadas("", "", "", "", "1", "1", "2");

        //Jornada de formación No. 1 realizadas
        double meta5 = 0;
        int count5 = 0;
        int total5 = 320;
        if (estra2JornadaFormacion2 != null && estra2JornadaFormacion2.Rows.Count > 0)
        {
            count5 = estra2JornadaFormacion2.Rows.Count;
            meta5 = ((double)count5 / (double)total5) * 100;
            meta5 = Math.Round(meta5, 2);
            //if (meta5 > 100)
            //{
            //    meta5 = 100;
            //}
            count5 = estra2JornadaFormacion2.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>5.</b> Jornada de formación No. 2 realizadas  </td>";
        ca += "<td class='center'>" + count5 + " de " + total5 + "</td>";
        ca += "<td class='center'>" + meta5 + "%</td>";
        ca += "<td class='noExl center'><a href='estra2jornadaformacion.aspx?m=1&s=1&j=2'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";

        //Sedes con asistencia cargadas de la sesión de formación No. 2
        double meta6 = 0;
        int count6 = 0;
        int total6 = 320;
        if (estra2SedesAsistencias2 != null && estra2SedesAsistencias2.Rows.Count > 0)
        {
            count6 = estra2SedesAsistencias2.Rows.Count;
            meta6 = ((double)count6 / (double)total6) * 100;
            meta6 = Math.Round(meta6, 2);
            //if (meta6 > 100)
            //{
            //    meta6 = 100;
            //}
            count6 = estra2SedesAsistencias2.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>6.</b> Sedes con asistencia cargadas de la sesión de formación No. 2 </td>";
        ca += "<td class='center'>" + count6 + " de " + total6 + "</td>";
        ca += "<td class='center'>" + meta6 + "%</td>";
        ca += "<td class='noExl center'><a href='estra2sedesasistencias.aspx?m=1&s=1&j=2'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";


        //Relatorías institucionales elaboradas jornada 2
        double meta7 = 0;
        int count7 = 0;
        int total7 = 320;
        if (estra2RelatoriasInstitucionales2 != null && estra2RelatoriasInstitucionales2.Rows.Count > 0)
        {
            count7 = estra2RelatoriasInstitucionales2.Rows.Count;
            meta7 = ((double)count7 / (double)total7) * 100;
            meta7 = Math.Round(meta7, 2);
            //if (meta7 > 100)
            //{
            //    meta7 = 100;
            //}
            count7 = estra2RelatoriasInstitucionales2.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>7.</b> Relatorías institucionales elaboradas jornada 2 </td>";
        ca += "<td class='center'>" + count7 + " de " + total7 + "</td>";
        ca += "<td class='center'>" + meta7 + "%</td>";
        ca += "<td class='noExl center'><a href='estra2relatoriasinstitucionales.aspx?m=1&s=1&j=2'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";

        //Jornada de formación  No. 2 evaluadas y subidas a la plataforma de Ciclón
        double meta8 = 0;
        int count8 = 0;
        int total8 = 320;
        if (jornadasFormacionEvaluadas2 != null && jornadasFormacionEvaluadas2.Rows.Count > 0)
        {
            count8 = jornadasFormacionEvaluadas2.Rows.Count;
            meta8 = ((double)count8 / (double)total8) * 100;
            meta8 = Math.Round(meta8, 2);
            //if (meta8 > 100)
            //{
            //    meta8 = 100;
            //}
            count8 = jornadasFormacionEvaluadas2.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>8.</b> Jornada de formación  No. 2 evaluadas y subidas a la plataforma de Ciclón </td>";
        ca += "<td class='center'>" + count8 + " de " + total8 + "</td>";
        ca += "<td class='center'>" + meta8 + "%</td>";
        ca += "<td class='noExl center'><a href='estra2jornadasformacionevaluadas.aspx?m=1&s=1&j=2'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";

        return ca;
    }


    

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("reporteindicadores.aspx");
    }

}