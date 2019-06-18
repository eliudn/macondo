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

public partial class estra2recorridotrayectorias : System.Web.UI.Page
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

        ////if(Session["a"] != null)
        //{
            //lblActividad.Text = Session["a"].ToString();
        //}
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


        DataTable estra2JornadaFormacion5 = est.estra2JornadaFormacion("", "", "", "", "4", "3", "5");
        DataTable estra2SedesAsistencias5 = est.estra2SedesAsistencias("", "", "", "", "4", "3", "5");
        DataTable estra2RelatoriasInstitucionales5 = est.estra2RelatoriasInstitucionales("", "", "", "", "4", "3", "5");
        DataTable jornadasFormacionEvaluadas5 = est.jornadasFormacionEvaluadas("", "", "", "", "4", "3", "5");
        DataTable estra2AsistentesFormacion5 = est.estra2AsistentesFormacion_("", "", "", "", "4", "3", "5");

        //Jornada de formación No. 5 realizadas
        double meta1 = 0;
        int count1 = 0;
        int total1 = 320;
        if (estra2JornadaFormacion5 != null && estra2JornadaFormacion5.Rows.Count > 0)
        {
            count1 = estra2JornadaFormacion5.Rows.Count;
            meta1 = ((double)count1 / (double)total1) * 100;
            meta1 = Math.Round(meta1, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}
            count1 = estra2JornadaFormacion5.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>1.</b> Jornada de formación No. 5 realizadas  </td>";
        ca += "<td class='center'>" + count1 + " de " + total1 + "</td>";
        ca += "<td class='center'>" + meta1 + "%</td>";
        ca += "<td class='noExl center'><a href='estra2jornadaformacion.aspx?m=4&s=3&j=5'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";

        //Sedes con asistencia cargadas de la sesión de formación No. 5
        double meta2 = 0;
        int count2 = 0;
        int total2 = 320;
        if (estra2SedesAsistencias5 != null && estra2SedesAsistencias5.Rows.Count > 0)
        {
            count2 = estra2SedesAsistencias5.Rows.Count;
            meta2 = ((double)count2 / (double)total2) * 100;
            meta2 = Math.Round(meta2, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}
            count2 = estra2SedesAsistencias5.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>2.</b> Sedes con asistencia cargadas de la sesión de formación No. 5 </td>";
        ca += "<td class='center'>" + count2 + " de " + total2 + "</td>";
        ca += "<td class='center'>" + meta2 + "%</td>";
        ca += "<td class='noExl center'><a href='estra2sedesasistencias.aspx?m=4&s=3&j=5'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";


        //Relatorías institucionales elaboradas jornada 5
        double meta3 = 0;
        int count3 = 0;
        int total3 = 320;
        if (estra2RelatoriasInstitucionales5 != null && estra2RelatoriasInstitucionales5.Rows.Count > 0)
        {
            count3 = estra2RelatoriasInstitucionales5.Rows.Count;
            meta3 = ((double)count3 / (double)total3) * 100;
            meta3 = Math.Round(meta3, 2);
            //if (meta3 > 100)
            //{
            //    meta3 = 100;
            //}
            count3 = estra2RelatoriasInstitucionales5.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>3.</b> Relatorías institucionales elaboradas jornada 5 </td>";
        ca += "<td class='center'>" + count3 + " de " + total3 + "</td>";
        ca += "<td class='center'>" + meta3 + "%</td>";
        ca += "<td class='noExl center'><a href='estra2relatoriasinstitucionales.aspx?m=4&s=3&j=5'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";

        //Jornada de formación  No. 5 evaluadas y subidas a la plataforma de Ciclón
        double meta4 = 0;
        int count4 = 0;
        int total4 = 320;
        if (jornadasFormacionEvaluadas5 != null && jornadasFormacionEvaluadas5.Rows.Count > 0)
        {
            count4 = jornadasFormacionEvaluadas5.Rows.Count;
            meta4 = ((double)count4 / (double)total4) * 100;
            meta4 = Math.Round(meta4, 2);
            //if (meta4 > 100)
            //{
            //    meta4 = 100;
            //}
            count4 = jornadasFormacionEvaluadas5.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>4.</b> Jornada de formación  No. 5 evaluadas y subidas a la plataforma de Ciclón </td>";
        ca += "<td class='center'>" + count4 + " de " + total4 + "</td>";
        ca += "<td class='center'>" + meta4 + "%</td>";
        ca += "<td class='noExl center'><a href='estra2jornadasformacionevaluadas.aspx?m=4&s=3&j=5'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";


        //Asistentes a la sesión de formación 5
        double meta9 = 0;
        int count9 = 0;
        int total9 = 3386;
        if (estra2AsistentesFormacion5 != null && estra2AsistentesFormacion5.Rows.Count > 0)
        {
            count9 = estra2AsistentesFormacion5.Rows.Count;
            meta9 = ((double)count9 / (double)total9) * 100;
            meta9 = Math.Round(meta9, 2);
            //if (meta9 > 100)
            //{
            //    meta9 = 100;
            //}
            count9 = estra2AsistentesFormacion5.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>5.</b> Asistentes a la sesión de formación 5 </td>";
        ca += "<td class='center'>" + count9 + " de " + total9 + "</td>";
        ca += "<td class='center'>" + meta9 + "%</td>";
        ca += "<td class='noExl center'><a href='estra2asistentesformacion_.aspx?m=4&s=3&j=5'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";

        //JORNADA 4
        DataTable estra2JornadaFormacion6 = est.estra2JornadaFormacion("", "", "", "", "4", "3", "6");
        DataTable estra2SedesAsistencias6 = est.estra2SedesAsistencias("", "", "", "", "4", "3", "6");
        DataTable estra2RelatoriasInstitucionales6 = est.estra2RelatoriasInstitucionales("", "", "", "", "4", "3", "6");
        DataTable jornadasFormacionEvaluadas6 = est.jornadasFormacionEvaluadas("", "", "", "", "4", "3", "6");
        DataTable estra2AsistentesFormacion6 = est.estra2AsistentesFormacion_("", "", "", "", "4", "3", "6");

        //Jornada de formación No. 6 realizadas
        double meta5 = 0;
        int count5 = 0;
        int total5 = 320;
        if (estra2JornadaFormacion6 != null && estra2JornadaFormacion6.Rows.Count > 0)
        {
            count5 = estra2JornadaFormacion6.Rows.Count;
            meta5 = ((double)count5 / (double)total5) * 100;
            meta5 = Math.Round(meta5, 2);
            //if (meta5 > 100)
            //{
            //    meta5 = 100;
            //}
            count5 = estra2JornadaFormacion6.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>6.</b> Jornada de formación No. 6 realizadas  </td>";
        ca += "<td class='center'>" + count5 + " de " + total5 + "</td>";
        ca += "<td class='center'>" + meta5 + "%</td>";
        ca += "<td class='noExl center'><a href='estra2jornadaformacion.aspx?m=4&s=3&j=6'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";

        //Sedes con asistencia cargadas de la sesión de formación No. 6
        double meta6 = 0;
        int count6 = 0;
        int total6 = 320;
        if (estra2SedesAsistencias6 != null && estra2SedesAsistencias6.Rows.Count > 0)
        {
            count6 = estra2SedesAsistencias6.Rows.Count;
            meta6 = ((double)count6 / (double)total6) * 100;
            meta6 = Math.Round(meta6, 2);
            //if (meta6 > 100)
            //{
            //    meta6 = 100;
            //}
            count6 = estra2SedesAsistencias6.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>7.</b> Sedes con asistencia cargadas de la sesión de formación No. 6 </td>";
        ca += "<td class='center'>" + count6 + " de " + total6 + "</td>";
        ca += "<td class='center'>" + meta6 + "%</td>";
        ca += "<td class='noExl center'><a href='estra2sedesasistencias.aspx?m=4&s=3&j=6'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";


        //Relatorías institucionales elaboradas jornada 6
        double meta7 = 0;
        int count7 = 0;
        int total7 = 320;
        if (estra2RelatoriasInstitucionales6 != null && estra2RelatoriasInstitucionales6.Rows.Count > 0)
        {
            count7 = estra2RelatoriasInstitucionales6.Rows.Count;
            meta7 = ((double)count7 / (double)total7) * 100;
            meta7 = Math.Round(meta7, 2);
            //if (meta7 > 100)
            //{
            //    meta7 = 100;
            //}
            count7 = estra2RelatoriasInstitucionales6.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>8.</b> Relatorías institucionales elaboradas jornada 6 </td>";
        ca += "<td class='center'>" + count7 + " de " + total7 + "</td>";
        ca += "<td class='center'>" + meta7 + "%</td>";
        ca += "<td class='noExl center'><a href='estra2relatoriasinstitucionales.aspx?m=4&s=3&j=6'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";

        //Jornada de formación  No. 6 evaluadas y subidas a la plataforma de Ciclón
        double meta8 = 0;
        int count8 = 0;
        int total8 = 320;
        if (jornadasFormacionEvaluadas6 != null && jornadasFormacionEvaluadas6.Rows.Count > 0)
        {
            count8 = jornadasFormacionEvaluadas6.Rows.Count;
            meta8 = ((double)count8 / (double)total8) * 100;
            meta8 = Math.Round(meta8, 2);
            //if (meta8 > 100)
            //{
            //    meta8 = 100;
            //}
            count8 = jornadasFormacionEvaluadas6.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>9.</b> Jornada de formación  No. 6 evaluadas y subidas a la plataforma de Ciclón </td>";
        ca += "<td class='center'>" + count8 + " de " + total8 + "</td>";
        ca += "<td class='center'>" + meta8 + "%</td>";
        ca += "<td class='noExl center'><a href='estra2jornadasformacionevaluadas.aspx?m=4&s=3&j=6'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";

        //Asistentes a la sesión de formación 6
        double meta10 = 0;
        int count10 = 0;
        int total10 = 3386;
        if (estra2AsistentesFormacion6 != null && estra2AsistentesFormacion6.Rows.Count > 0)
        {
            count10 = estra2AsistentesFormacion6.Rows.Count;
            meta10 = ((double)count10 / (double)total10) * 100;
            meta10 = Math.Round(meta10, 2);
            //if (meta10 > 100)
            //{
            //    meta10 = 100;
            //}
            count10 = estra2AsistentesFormacion6.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>10.</b> Asistentes a la sesión de formación 6 </td>";
        ca += "<td class='center'>" + count10 + " de " + total10 + "</td>";
        ca += "<td class='center'>" + meta10 + "%</td>";
        ca += "<td class='noExl center'><a href='estra2asistentesformacion_.aspx?m=4&s=3&j=6'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";

        return ca;
    }


    

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("reporteindicadores.aspx");
    }

}