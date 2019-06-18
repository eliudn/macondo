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

public partial class grupostrayectoriaindagacion : System.Web.UI.Page
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

        DataTable sedesGPBitacora4 = est.sedesGPBitacora4("","","");
        DataTable gruposInvestigacionBitacora4 = est.gruposInvestigacionBitacora4("","","","","");
        DataTable gruposInvestigacionRecursosB4 = est.gruposInvestigacionRecursosB4("","","","","");

        DataTable sedesGPBitacora5 = est.sedesGPBitacora5("","","");
        DataTable gruposInvestigacionBitacora5 = est.gruposInvestigacionBitacora5("","","","");
        
        double meta1 = 0;
        int count1 = 0;
        int total1 = 320;
        if (sedesGPBitacora4 != null && sedesGPBitacora4.Rows.Count > 0)
        {
            count1 = sedesGPBitacora4.Rows.Count;
            meta1 = ((double)count1 / (double)total1) * 100;
            meta1 = Math.Round(meta1, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}
            count1 = sedesGPBitacora4.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>1.</b> Sedes educativas con grupos infantiles y juveniles que diligenciaron la bitácora 04: presupuesto</td>";
        ca += "<td class='center'>" + count1 + " de " + total1 + "</td>";
        ca += "<td class='center'>" + meta1 + "%</td>";
        ca += "<td class='noExl center'><a href='detallesedesgpbitacora4.aspx'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0
        ca += "</tr>";

        double meta2 = 0;
        int count2 = 0;
        int total2 = 420;
        if (gruposInvestigacionBitacora4 != null && gruposInvestigacionBitacora4.Rows.Count > 0)
        {
            count2 = gruposInvestigacionBitacora4.Rows.Count;
            meta2 = ((double)count2 / (double)total2) * 100;
            meta2 = Math.Round(meta2, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}
            count2 = gruposInvestigacionBitacora4.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>2.</b> Grupos de investigación infantiles y juveniles con la bitácora 04 de presupuesto diligenciada  </td>";
        ca += "<td class='center'>" + count2 + " de " + total2 + "</td>";
        ca += "<td class='center'>" + meta2 + "%</td>";
        ca += "<td class='noExl center'><a href='detallegruposinvestigacionbitacora4.aspx'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0
        ca += "</tr>";


        double meta3 = 0;
        int count3 = 0;
        int total3 = 420;
        if (gruposInvestigacionRecursosB4 != null && gruposInvestigacionRecursosB4.Rows.Count > 0)
        {
            count3 = gruposInvestigacionRecursosB4.Rows.Count;
            meta3 = ((double)count3 / (double)total3) * 100;
            meta3 = Math.Round(meta3, 2);
            //if (meta3 > 100)
            //{
            //    meta3 = 100;
            //}
            count3 = gruposInvestigacionRecursosB4.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>3.</b>  Grupos de investigación con recursos aprobados por ciclón</td>";
        ca += "<td class='center'>" + count3 + " de " + total3 + "</td>";
        ca += "<td class='center'>" + meta3 + "%</td>";
        ca += "<td class='noExl center'><a href='detallegruposinvestigacionrecursosb4.aspx'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0
        ca += "</tr>";


        double meta4 = 0;
        int count4 = 0;
        int total4 = 320;
        if (sedesGPBitacora5 != null && sedesGPBitacora5.Rows.Count > 0)
        {
            count4 = sedesGPBitacora5.Rows.Count;
            meta4 = ((double)count4 / (double)total4) * 100;
            meta4 = Math.Round(meta4, 2);
            //if (meta4 > 100)
            //{
            //    meta4 = 100;
            //}
            count4 = sedesGPBitacora5.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>4.</b> Sedes educativas con grupos de investigación infantiles y juveniles que diligenciaron la Bitácora 05: Trayectorias de indagación</td>";
        ca += "<td class='center'>" + count4 + " de " + total4 + "</td>";
        ca += "<td class='center'>" + meta4 + "%</td>";
        ca += "<td class='noExl center'><a href='detallesedesgpbitacora5.aspx'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0
        ca += "</tr>";


        double meta5 = 0;
        int count5 = 0;
        int total5 = 420;
        if (gruposInvestigacionBitacora5 != null && gruposInvestigacionBitacora5.Rows.Count > 0)
        {
            count5 = gruposInvestigacionBitacora5.Rows.Count;
            meta5 = ((double)count5 / (double)total5) * 100;
            meta5 = Math.Round(meta5, 2);
            //if (meta5 > 100)
            //{
            //    meta5 = 100;
            //}
            count5 = gruposInvestigacionBitacora5.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>5.</b> Grupos de investigación infantiles y juveniles con trayectorias de indagación diseñadas </td>";
        ca += "<td class='center'>" + count5 + " de " + total5 + "</td>";
        ca += "<td class='center'>" + meta5 + "%</td>";
        ca += "<td class='noExl center'><a href='detallegruposinvestigacionbitacora5.aspx'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0
        ca += "</tr>";
        return ca;
    }




    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("reporteindicadores.aspx");
    }

}