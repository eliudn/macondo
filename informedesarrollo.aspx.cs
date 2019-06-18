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

public partial class informedesarrollo : System.Web.UI.Page
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
        //Session["m"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
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

        ca += "<b>Informe del desarrollo de las Etapas 1, 2  y 3 </b><br/> ";
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

        DataTable totalSedesGrupoInvestigacion = est.totalSedesGrupoInvestigacion("","","");
        DataTable totalGrupoInvestigacion = est.totalGrupoInvestigacion("","","","");
        DataTable totalEstudiantesMatriculadosGP = est.totalEstudiantesMatriculadosGP("","","","","");
        DataTable totalDocenesMatriculadosGP = est.totalDocenesMatriculadosGP("","","","","");
        DataTable totalSedesGPTenganPreguntas = est.totalSedesGPTenganPreguntas("","","");
        DataTable totalGPHicieronPreguntas = est.totalGPHicieronPreguntas("","","","");
        DataTable totalSedesGPTenganPreguntasB3 = est.totalSedesGPTenganPreguntasB3("","","");
        DataTable totalGPHicieronPreguntasB3 = est.totalGPHicieronPreguntasB3("","","","");
        
        double meta1 = 0;
        int count1 = 0;
        int total1 = 320;
        if (totalSedesGrupoInvestigacion != null && totalSedesGrupoInvestigacion.Rows.Count > 0)
        {
            count1 = totalSedesGrupoInvestigacion.Rows.Count;
            meta1 = ((double)count1 / (double)total1) * 100;
            meta1 = Math.Round(meta1, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}
            count1 = totalSedesGrupoInvestigacion.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>1.</b> Sedes educativas con grupo de investigación Seleccionados</td>";
        ca += "<td class='center'>" + count1 + " de " + total1 + "</td>";
        ca += "<td class='center'>" + meta1 + "%</td>";
        ca += "<td class='noExl center'><a href='detallesdesarrollo.aspx?fechaini=0&fechafin=0'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //total grupos de investigación 
        double meta2 = 0;
        int count2 = 0;
        int total2 = 420;
        if (totalGrupoInvestigacion != null && totalGrupoInvestigacion.Rows.Count > 0)
        {
            count2 = totalGrupoInvestigacion.Rows.Count;
            meta2 = ((double)count2 / (double)total2) * 100;
            meta2 = Math.Round(meta2, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}
            count2 = totalGrupoInvestigacion.Rows.Count;
        }
        ca += "<tr>";
        //ca += "<td><b>2.</b> Grupos de investigación infantiles y juveniles que se inscribieron en la convocatoria de Ciclón </td>";
        ca += "<td><b>2.</b> Numero de Grupos de investigación infantiles y juveniles seleccionados </td>";
        ca += "<td class='center'>" + count2 + " de " + total2 + "</td>";
        ca += "<td class='center'>" + meta2 + "%</td>";
        ca += "<td class='noExl center'><a href='totalgrupoinvestigacion.aspx'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Cuantos niños hay inscritos en los grupos de investigacion 
        double meta3 = 0;
        int count3 = 0;
        int total3 = 42400;
        if (totalEstudiantesMatriculadosGP != null && totalEstudiantesMatriculadosGP.Rows.Count > 0)
        {
            //count3 = totalEstudiantesMatriculadosGP.Rows.Count;
            count3 = 32798;
            meta3 = ((double)count3 / (double)total3) * 100;
            meta3 = Math.Round(meta3, 2);
            //if (meta3 > 100)
            //{
            //    meta3 = 100;
            //}
            count3 = totalEstudiantesMatriculadosGP.Rows.Count;
        }
        ca += "<tr>";
        //ca += "<td><b>3.</b> Niños, niñas y jóvenes participante en grupos de investigación infantiles y juveniles en la convocatoria Ciclón </td>";
        ca += "<td><b>3.</b> Niños, niñas y jovenes participantes en grupos de investigacion seleccionados </td>";
        //ca += "<td class='center'>" + count3 + " de " + total3 + "</td>";
        ca += "<td class='center'>32798 de " + total3 + "</td>";
        ca += "<td class='center'>" + meta3 + "%</td>";
        //ca += "<td class='noExl center'><a href='totalestudiantesmatriculadosgp.aspx'><img src='images/detalles.png'>Ver</a></td>";
        ca += "<td class='noExl center'><a href='#' onclick='alert(\"Este detalle no se puede visualizar por la cantidad de registros a mostrar\")'><img src='images/detalles.png' />Ver</a></td>";
        ca += "</tr>";

        //Docenes matriculados en los grupos de investigacion
        double meta4 = 0;
        int count4 = 0;
        //int total4 = 3386;
        int total4 = 1360;
        if (totalDocenesMatriculadosGP != null && totalDocenesMatriculadosGP.Rows.Count > 0)
        {
            count4 = totalDocenesMatriculadosGP.Rows.Count;
            meta4 = ((double)count4 / (double)total4) * 100;
            meta4 = Math.Round(meta4, 2);
            //if (meta4 > 100)
            //{
            //    meta4 = 100;
            //}
            count4 = totalDocenesMatriculadosGP.Rows.Count;
        }
        ca += "<tr>";
        //ca += "<td><b>4.</b> Maestros y maestras  acompañantes de los grupos de investigación infantiles y juveniles inscritos en la convocatoria de Ciclón</td>";
        ca += "<td><b>4.</b> Maestros y Maestras en grupos de investigacion seleccionados</td>";
        ca += "<td class='center'>" + count4 + " de " + total4 + "</td>";
        ca += "<td class='center'>" + meta4 + "%</td>";
        ca += "<td class='noExl center'><a href='totaldocenesmatriculadosgp.aspx'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Numero de sedes con grupos de investigacon que tengan preguntas
        double meta5 = 0;
        int count5 = 0;
        int total5 = 320;
        if (totalSedesGPTenganPreguntas != null && totalSedesGPTenganPreguntas.Rows.Count > 0)
        {
            count5 = totalSedesGPTenganPreguntas.Rows.Count;
            meta5 = ((double)count5 / (double)total5) * 100;
            meta5 = Math.Round(meta5, 2);
            //if (meta5 > 100)
            //{
            //    meta5 = 100;
            //}
            count5 = totalSedesGPTenganPreguntas.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>5.</b> Sedes educativas seleccionadas con grupos de investigación infantiles y juveniles que formularon preguntas de investigación </td>";
        ca += "<td class='center'>" + count5 + " de " + total5 + "</td>";
        ca += "<td class='center'>" + meta5 + "%</td>";
        ca += "<td class='noExl center'><a href='totalsedesgptenganpreguntas.aspx'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Número de grupos de investigación hicieron preguntas 
        double meta6 = 0;
        int count6 = 0;
        int total6 = 420;
        if (totalGPHicieronPreguntas != null && totalGPHicieronPreguntas.Rows.Count > 0)
        {
            count6 = totalGPHicieronPreguntas.Rows.Count;
            meta6 = ((double)count6 / (double)total6) * 100;
            meta6 = Math.Round(meta6, 2);
            //if (meta6 > 100)
            //{
            //    meta6 = 100;
            //}
            count6 = totalGPHicieronPreguntas.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>6.</b> Grupos de investigación  seleccionados con preguntas de investigación formuladas </td>";
        ca += "<td class='center'>" + count6 + " de " + total6 + "</td>";
        ca += "<td class='center'>" + meta6 + "%</td>";
        ca += "<td class='noExl center'><a href='totalgphicieronpreguntas.aspx'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Número de grupos de investigación hicieron preguntas 
        double meta7 = 0;
        int count7 = 0;
        int total7 = 320;
        if (totalSedesGPTenganPreguntasB3 != null && totalSedesGPTenganPreguntasB3.Rows.Count > 0)
        {
            count7 = totalSedesGPTenganPreguntasB3.Rows.Count;
            meta7 = ((double)count7 / (double)total7) * 100;
            meta7 = Math.Round(meta7, 2);
            //if (meta7 > 100)
            //{
            //    meta7 = 100;
            //}
            count7 = totalSedesGPTenganPreguntasB3.Rows.Count;
        }
        ca += "<tr>";
        ca += "<td><b>7.</b> Sedes educativas con grupos de investigación infantiles y juveniles seleccionados  con problemas de investigación </td>";
        ca += "<td class='center'>" + count7 + " de " + total7 + "</td>";
        ca += "<td class='center'>" + meta7 + "%</td>";
        ca += "<td class='noExl center'><a href='totalsedesgptenganpreguntasb3.aspx'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Número de grupos de investigación hicieron preguntas  bitacora 3
        double meta8 = 0;
        int count8 = 0;
        int total8 = 420;
        if (totalGPHicieronPreguntasB3 != null && totalGPHicieronPreguntasB3.Rows.Count > 0)
        {
            count8 = totalGPHicieronPreguntasB3.Rows.Count;
            meta8 = ((double)count8 / (double)total8) * 100;
            meta8 = Math.Round(meta8, 2);
            //if (meta8 > 100)
            //{
            //    meta8 = 100;
            //}
            count8 = totalGPHicieronPreguntasB3.Rows.Count;

        }
        ca += "<tr>";
        ca += "<td><b>8.</b> Total grupos de investigación seleccionados con problemas de investigación</td>";
        ca += "<td class='center'>" + count8 + " de " + total8 + "</td>";
        ca += "<td class='center'>" + meta8 + "%</td>";
        ca += "<td class='noExl center'><a href='totalgphicieronpreguntasb3.aspx'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";
        
        return ca;
    }
    
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("reporteindicadores.aspx");
    }

}