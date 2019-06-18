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

public partial class estra5sesiones : System.Web.UI.Page
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

                if (Session["s"].ToString() == "1")
                {
                    sesion.Text = "Primera";
                }
                if (Session["s"].ToString() == "2")
                {
                    sesion.Text = "Segunda";
                }
                if (Session["s"].ToString() == "3")
                {
                    sesion.Text = "Tercera";
                }
                
            }
        
        }
    }
    public void obtenerGET()
    {
       //lblMomento.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        Session["m"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        Session["e"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["e"]);
        //lblSesion.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
        Session["s"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
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
        string Nosesion = "";
        if (HttpContext.Current.Session["s"].ToString() == "1")
        {
            Nosesion = "Primera";
        }
        if (HttpContext.Current.Session["s"].ToString() == "2")
        {
            Nosesion = "Segunda";
        }
        if (HttpContext.Current.Session["s"].ToString() == "3")
        {
            Nosesion = "Tercera";
        }

        string ca = "";
        Estrategias est = new Estrategias();

        //DataTable asistencia = est.est_EvidenciasEstras004CoordinadorConMemorias("", "", "", "", "5", "G001: Registro de asistencia a eventos", HttpContext.Current.Session["s"].ToString());

        DataTable asistencia = est.est_Estras004CoordinadorDias("", "", "", "", "5", HttpContext.Current.Session["s"].ToString());

        //DataTable relatos = est.est_EvidenciasEstras004CoordinadorConMemorias("", "", "", "", "5", "S005: Relato individual de sistematización", HttpContext.Current.Session["s"].ToString());

        DataTable relatoria = est.est_EvidenciasEstras004CoordinadorConMemoriasDosActividades("", "", "", "", "5", "S006: Relatoría institucional", "S005: Relato individual de sistematización", HttpContext.Current.Session["s"].ToString());

        DataTable sesion = est.est_s004CoordinadorConMemorias("", "", "", "", "5", HttpContext.Current.Session["s"].ToString());

        DataTable formato = est.est_EvidenciasEstras004CoordinadorConMemorias("", "", "", "", "5", "G002: Formato de evaluación de eventos de formación", HttpContext.Current.Session["s"].ToString());
                   


        //asistencia
        double meta1 = 0;
        int count1 = 0;
        int total1 = 5;
        if (asistencia != null && asistencia.Rows.Count > 0)
        {
            count1 = Convert.ToInt32(asistencia.Rows[0]["dias"].ToString());
            meta1 = ((double)count1 / (double)total1) * 100;
            meta1 = Math.Round(meta1, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}
            count1 = Convert.ToInt32(asistencia.Rows[0]["dias"].ToString());
        }
        ca += "<tr>";
        ca += "<td><b>1.</b> Días de formación de la " + Nosesion + " sesión registradas </td>";
        ca += "<td class='center'>" + count1 + " de " + total1 + "</td>";
        ca += "<td class='center'>" + meta1 + "%</td>";
        ca += "<td class='noExl center'>";
        ca += "<a href='estra5memoriascoord.aspx?s=" + HttpContext.Current.Session["s"].ToString() + "'><img src='images/detalles.png'>Ver</a>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</td></tr>";

        //relatos
        double meta2 = 0;
        int count2 = 0;
        int total2 = 40;
        //if (relatos != null && relatos.Rows.Count > 0)
        //{
            //count2 = relatos.Rows.Count;
            count2 = 8 * count1;
            meta2 = ((double)count2 / (double)total2) * 100;
            meta2 = Math.Round(meta2, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}
            //count2 = relatos.Rows.Count;
            count2 = 8 * count1;
        //}
        ca += "<tr>";
        ca += "<td><b>2.</b> Horas de Formación " + Nosesion + " Sesión   </td>";
        ca += "<td class='center'>" + count2 + " de " + total2 + "</td>";
        ca += "<td class='center'>" + meta2 + "%</td>";
        ca += "<td class='noExl center'>";
        ca += "<a href='estra5memoriascoord.aspx?s=" + HttpContext.Current.Session["s"].ToString() + "'><img src='images/detalles.png'>Ver</a>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</td></tr>";

        //relatoria
        double meta3 = 0;
        int count3 = 0;
        int total3 = 20;
        if (relatoria != null && relatoria.Rows.Count > 0)
        {
            count3 = relatoria.Rows.Count;
            meta3 = ((double)count3 / (double)total3) * 100;
            meta3 = Math.Round(meta3, 2);
            //if (meta3 > 100)
            //{
            //    meta3 = 100;
            //}
            count3 = relatoria.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>3.</b>  Relatorias y/o Memorias Elaboradas en la sesión </td>";
        ca += "<td class='center'>" + count3 + " de " + total3 + "</td>";
        ca += "<td class='center'>" + meta3 + "%</td>";
        ca += "<td class='noExl center'><a href='estra5sesionesrelatorias.aspx?s=" + HttpContext.Current.Session["s"].ToString() + "'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";

        //memorias
        double meta4 = 0;
        int count4 = 0;
        int total4 = 1;
        if (sesion != null && sesion.Rows.Count > 0)
        {
            count4 = sesion.Rows.Count;
            meta4 = ((double)count4 / (double)total4) * 100;
            meta4 = Math.Round(meta4, 2);
            //if (meta4 > 100)
            //{
            //    meta4 = 100;
            //}
            count4 = sesion.Rows.Count;
        }
        //ca += "<tr>";
        //ca += "<td><b>4.</b> Memorias de plenaria elaboradas y subidas a la plataforma Ciclón </td>";
        //ca += "<td class='center'>" + count4 + " de " + total4 + "</td>";
        //ca += "<td class='center'>" + meta4 + "%</td>";
        //ca += "<td class='noExl center'><a href='estra5sesionesmemorias.aspx?s=" + HttpContext.Current.Session["s"].ToString() + "'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        //ca += "</tr>";

        //Evaluaciones
        double meta5 = 0;
        int count5 = 0;
        int total5 = 20;
        if (formato != null && formato.Rows.Count > 0)
        {
            count5 = formato.Rows.Count;
            meta5 = ((double)count5 / (double)total5) * 100;
            meta5 = Math.Round(meta5, 2);
            //if (meta5 > 100)
            //{
            //    meta5 = 100;
            //}
            count5 = formato.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>4.</b> Evaluación de la Sesión Subidas a la plataforma.</td>";
        ca += "<td class='center'>" + count5 + " de " + total5 + "</td>";
        ca += "<td class='center'>" + meta5 + "%</td>";
        ca += "<td class='noExl center'><a href='estra5sesionesevaluacion.aspx?s=" + HttpContext.Current.Session["s"].ToString() + "'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
        ca += "</tr>";

        return ca;
    }


    

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("reporteindicadores.aspx");
    }

}