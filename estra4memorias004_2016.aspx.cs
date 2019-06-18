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

public partial class estra4memorias004_2016 : System.Web.UI.Page
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

        DataTable sesiones = est.est_estra2instrumento_s004_redt_2016("","","","","1");//Modificar la consulta, tiene que ser por memorias y no por sede
        DataTable estudiantesasis = est.est_estra2instrumento_s004_redt_2016_estudiantes("", "", "", "", "1");
        DataTable docentesasis = est.est_estra2instrumento_s004_redt_2016_docentes("", "", "", "", "1");
        DataTable docentestudianteasis = est.est_estra2instrumento_s004_redt_2016_docentes_estudiantes("", "", "", "", "1");
        DataTable estudiantesasisdict = est.est_estra2instrumento_s004_redt_2016_estudiantes("", "", "", "", "1");
        DataTable docentesasisDistinct = est.est_estra2instrumento_s004_redt_2016_docentes("", "", "", "", "1");

        DataTable redescreadas = est.cargarRedesTematicas("","","","","2016");
        DataTable redesestudiantesSedes = est.est_estra2instrumento_s004_redt_2016_estudiantesSedes("", "", "", "", "1", "2016");
        DataTable redesdocentessSedes = est.est_estra2instrumento_s004_redt_2016_docentesSedes("", "", "", "", "1", "2016");

        DataTable formatoevaluacion = est.est_estra4instrumento_s004_redt_2016_Evidencias("", "", "", "", "1", "Formatos de evaluación", "2016");

        //Sesiones de formación No. 1 2016 realizadas
        double meta1 = 0;
        int count1 = 0;
        int total1 = 2772;
        if (sesiones != null && sesiones.Rows.Count > 0)
        {
            count1 = sesiones.Rows.Count;
            meta1 = ((double)count1 / (double)total1) * 100;
            meta1 = Math.Round(meta1, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}
            count1 = sesiones.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>1.</b> Sesiones No. 1 realizadas </td>";
        ca += "<td class='center'>" + count1 + " de " + total1 + "</td>";
        ca += "<td class='center'>" + meta1 + "%</td>";
        ca += "<td class='noExl center'><a href='estra4memoriasesion1.aspx?m=1&s=1'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";

        //Asistentes estudiantes a la sesión de formación No. 1 2016
        double meta2 = 0;
        int count2 = 0;
        int total2 = 110880;
        if (estudiantesasis != null && estudiantesasis.Rows.Count > 0)
        {
            count2 = estudiantesasis.Rows.Count;
            meta2 = ((double)count2 / (double)total2) * 100;
            meta2 = Math.Round(meta2, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}
            count2 = estudiantesasis.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>2.</b> Niños, niñas y jóvenes matriculados en redes temáticas  </td>";
        ca += "<td class='center'>" + count2 + " de " + total2 + "</td>";
        ca += "<td class='center'>" + meta2 + "%</td>";
        //ca += "<td class='noExl center'><a href='estra4memoriasesion1estuasistentes.aspx?m=1&s=1'><img src='images/detalles.png'>Ver</a></td>";
        ca += "<td class='noExl center'><a href='#' ><a href='#' onclick='alert(\"Este detalle no se puede visualizar por la cantidad de registros a mostrar\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        ////Docentes inscritos en una red temática
        double meta3 = 0;
        int count3 = 0;
        int total3 = 2772;
        if (docentesasis != null && docentesasis.Rows.Count > 0)
        {
            count3 = docentesasis.Rows.Count;
            meta3 = ((double)count3 / (double)total3) * 100;
            meta3 = Math.Round(meta3, 2);
            //if (meta3 > 100)
            //{
            //    meta3 = 100;
            //}
            count3 = docentesasis.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>3.</b> Docentes que están inscritos en las redes temáticas   </td>";
        ca += "<td class='center'>" + count3 + " de " + total3 + "</td>";
        ca += "<td class='center'>" + meta3 + "%</td>";
        ca += "<td class='noExl center'><a href='estra4memoriasesion1docasistentes.aspx?m=1&s=1'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";

        //Sedes educativas con Docentes y estudiantes relacionados en la estrategia 4
        double meta4 = 0;
        int count4 = 0;
        int total4 = 320;
        if (docentestudianteasis != null && docentestudianteasis.Rows.Count > 0)
        {
            count4 = docentestudianteasis.Rows.Count;
            meta4 = ((double)count4 / (double)total4) * 100;
            meta4 = Math.Round(meta4, 2);
            //if (meta4 > 100)
            //{
            //    meta4 = 100;
            //}
            count4 = docentestudianteasis.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>4.</b> Sedes educativas con niños, niñas, jóvenes y maestros acompañantes incritos en la estrategia 4 en plataforma Ciclón  </td>";
        ca += "<td class='center'>" + count4 + " de " + total4 + "</td>";
        ca += "<td class='center'>" + meta4 + "%</td>";
        ca += "<td class='noExl center'><a href='estra4memoriasesion1sedesinscritas.aspx?m=1&s=1'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";


        //MFormato de evaluación de eventos de formación por sede
        double meta8 = 0;
        int count8 = 0;
        int total8 = 320;
        if (formatoevaluacion != null && formatoevaluacion.Rows.Count > 0)
        {
            count8 = formatoevaluacion.Rows.Count;
            meta8 = ((double)count8 / (double)total8) * 100;
            meta8 = Math.Round(meta8, 2);
            //if (meta8 > 100)
            //{
            //    meta8 = 100;
            //}
            count8 = formatoevaluacion.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>5.</b> Sesiones No. 1 evaluadas y subidas a la plataforma de Ciclón </td>";
        ca += "<td class='center'>" + count8 + " de " + total8 + "</td>";
        ca += "<td class='center'>" + meta8 + "%</td>";
        ca += "<td class='noExl center'><a href='estra4memoriasesionevaluadas1.aspx?m=1&s=1&anio=2016'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a a>
        ca += "</tr>";

         //Redes creadas en la plataforma
        double meta5 = 0;
        int count5 = 0;
        int total5 = 2772;
        if (redescreadas != null && redescreadas.Rows.Count > 0)
        {
            count5 = redescreadas.Rows.Count;
            meta5 = ((double)count5 / (double)total5) * 100;
            meta5 = Math.Round(meta5, 2);
            //if (meta5 > 100)
            //{
            //    meta5 = 100;
            //}
            count5 = redescreadas.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>6.</b> Redes Creadas en Plataforma </td>";
        ca += "<td class='center'>" + count5 + " de " + total5 + "</td>";
        ca += "<td class='center'>" + meta5 + "%</td>";
        ca += "<td class='noExl center'><a href='estra4redescreadas.aspx?anio=2016'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a a>
        ca += "</tr>";

        // Sedes educativas con niños inscritos
        double meta6 = 0;
        int count6 = 0;
        int total6 = 320;
        if (redesestudiantesSedes != null && redesestudiantesSedes.Rows.Count > 0)
        {
            count6 = redesestudiantesSedes.Rows.Count;
            meta6 = ((double)count6 / (double)total6) * 100;
            meta6 = Math.Round(meta6, 2);
            //if (meta6 > 100)
            //{
            //    meta6 = 100;
            //}
            count6 = redesestudiantesSedes.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>7.</b> Sedes Educativas con niños, niñas y jóvenes en Redes Temáticas </td>";
        ca += "<td class='center'>" + count6 + " de " + total6 + "</td>";
        ca += "<td class='center'>" + meta6 + "%</td>";
        ca += "<td class='noExl center'><a href='estra4redesestudiantes.aspx?anio=2016'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0a>
        ca += "</tr>";

        // Sedes educativas con docentes inscritos
        double meta7 = 0;
        int count7 = 0;
        int total7 = 320;
        if (redesdocentessSedes != null && redesdocentessSedes.Rows.Count > 0)
        {
            count7 = redesdocentessSedes.Rows.Count;
            meta7 = ((double)count7 / (double)total7) * 100;
            meta7 = Math.Round(meta7, 2);
            //if (meta7 > 100)
            //{
            //    meta7 = 100;
            //}
            count7 = redesdocentessSedes.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>8.</b> Sedes Educativas con docentes lideres en Redes </td>";
        ca += "<td class='center'>" + count7 + " de " + total7 + "</td>";
        ca += "<td class='center'>" + meta7 + "%</td>";
        ca += "<td class='noExl center'><a href='estra4redesdocentes.aspx?anio=2016'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a a>
        ca += "</tr>";

        return ca;
    }


    

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("reporteindicadores.aspx");
    }

}