using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.IO;
using System.Collections;
using System.Net;
using System.Linq;
using System.Xml.Linq;
using iTextSharp.text.html.simpleparser;

public partial class repseguimiento : System.Web.UI.Page
{
    Proyecto pro = new Proyecto();
    Funciones fun = new Funciones();
    Estrategias est = new Estrategias();
    Institucion inst = new Institucion();
    Usuario usu = new Usuario();

    int totalgrupospre;
    int totalgruposabi;
    int totals002;
    int totalb1;
    int totalb2;
    int totalb3;
    int totalb4;
    int totalb5;
    int totalb6;
    int totalpre;
    int totalplan;
    int totals003;
    int totalbitacora7;
    int total4_1;
    int total4_2;
    int total4_3;
    int totalespacio;
    int totals008;
    int totalmaestrosferias;

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
        mensaje.Attributes.Add("style", "display:none");
        if (!IsPostBack)
        {
            ddMomentos(dropMomentos);
            //ddAnio(dropAnio);
        }
    }

    private void ddAnio(DropDownList drop)
    {
        drop.DataSource = inst.cargarAnios();
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }

    private void ddMomentos(DropDownList drop)
    {
        drop.DataSource = est.cargarMomentosEstra1();
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }

    protected void lnkBuscar_Click(object sender, EventArgs e)
    {
        //cargarSeguimiento(dropAnio.SelectedItem.ToString(), dropMomentos.SelectedValue);
        cargarSeguimiento("", dropMomentos.SelectedValue);
    }

    private void cargarSeguimiento(string codanio, string codmomento)
    {
        string ca = "";
        DataRow anio = est.buscarCodAnioxNombre(codanio);

        DataTable asesores = est.listarAsesoresSeguimiento("1");

        if (asesores != null && asesores.Rows.Count > 0)
        {
            ca += lineaEncabezado();
            ca += "<tbody>";
            for (int i = 0; i < asesores.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i+1) + "</td>";
                ca += "<td>" + asesores.Rows[i]["asesor"].ToString().ToUpper() + "</td>";
                ca += "<td align='center'>" + dropMomentos.SelectedItem.ToString() + "</td>";
                //ca += "<td align='center'>" + gruposInvestigacionAbi(asesores.Rows[i]["codigo"].ToString()) + "</td>";
                //ca += "<td align='center'>" + gruposInvestigacionPre(asesores.Rows[i]["codigo"].ToString()) + "</td>";
                if (dropMomentos.SelectedValue != "5")
                {
                    ca += "<td align='center'>" + registroAsesoria(asesores.Rows[i]["codigo"].ToString(), codanio, codmomento) + "</td>";
                }
                
                if (dropMomentos.SelectedValue == "1")
                {
                    ca += "<td align='center'>" + bitacora1(asesores.Rows[i]["codigo"].ToString(), codanio, codmomento) + "</td>";
                    ca += "<td align='center'>" + bitacora2(asesores.Rows[i]["codigo"].ToString(), codanio, codmomento) + "</td>";
                    ca += "<td align='center'>" + bitacora3(asesores.Rows[i]["codigo"].ToString(), codanio, codmomento) + "</td>";
                    ca += "<td align='center'> Medio Ambiente: " + preestructurados(asesores.Rows[i]["codigo"].ToString(), "1", codmomento, "Medio Ambiente") + "<br/>";
                    ca += "Bienestar Infantil y juvenil: " + preestructurados(asesores.Rows[i]["codigo"].ToString(), "1", codmomento, "Bienestar Infantil y juvenil") + " <br/>";
                    ca += "Energía para el Futuro: " + preestructurados(asesores.Rows[i]["codigo"].ToString(), "1", codmomento, "Energía para el Futuro") + " <br/>";
                    ca += "Historia: " + preestructurados(asesores.Rows[i]["codigo"].ToString(), "1", codmomento, "Historia") + " <br/>";
                    ca += "</td>";
                }

                if (dropMomentos.SelectedValue == "3")
                {
                    ca += "<td align='center'>" + bitacora4(asesores.Rows[i]["codigo"].ToString(), codanio, codmomento) + "</td>";
                    ca += "<td align='center'>" + bitacora5(asesores.Rows[i]["codigo"].ToString(), codanio, codmomento) + "</td>";
                    ca += "<td align='center'>" + bitacora6(asesores.Rows[i]["codigo"].ToString(), codanio, codmomento) + "</td>";
                    ca += "<td align='center'> Medio Ambiente: " + preestructurados(asesores.Rows[i]["codigo"].ToString(), "1", codmomento, "Medio Ambiente") + "<br/>";
                    ca += "Bienestar Infantil y juvenil: " + preestructurados(asesores.Rows[i]["codigo"].ToString(), "1", codmomento, "Bienestar Infantil y juvenil") + " <br/>";
                    ca += "Energía para el Futuro: " + preestructurados(asesores.Rows[i]["codigo"].ToString(), "1", codmomento, "Energía para el Futuro") + " <br/>";
                    ca += "Historia: " + preestructurados(asesores.Rows[i]["codigo"].ToString(), "1", codmomento, "Historia") + " <br/>"; 
                    ca += "</td>";
                }

                if (dropMomentos.SelectedValue == "4")
                {
                    ca += "<td align='center'>" + s003(asesores.Rows[i]["codigo"].ToString()) + "<br/>";
                    ca += "<td align='center'>" + bitacora7(asesores.Rows[i]["codigo"].ToString(), "1",codmomento) + "<br/>";
                    ca += "<td align='center'>" + bitacora4_1(asesores.Rows[i]["identificacion"].ToString(), "1") + "<br/>";
                    ca += "<td align='center'>" + bitacora4_2(asesores.Rows[i]["identificacion"].ToString(), "2") + "<br/>";
                    ca += "<td align='center'>" + bitacora4_3(asesores.Rows[i]["identificacion"].ToString(), "3") + "<br/>";
                    ca += "<td align='center'> Medio Ambiente: " + preestructurados(asesores.Rows[i]["codigo"].ToString(), "1", codmomento, "Medio Ambiente") + "<br/>";
                    ca += "Bienestar Infantil y juvenil: " + preestructurados(asesores.Rows[i]["codigo"].ToString(), "1", codmomento, "Bienestar Infantil y juvenil") + " <br/>";
                    ca += "Energía para el Futuro: " + preestructurados(asesores.Rows[i]["codigo"].ToString(), "1", codmomento, "Energía para el Futuro") + " <br/>";
                    ca += "Historia: " + preestructurados(asesores.Rows[i]["codigo"].ToString(), "1", codmomento, "Historia") + " <br/>";
                    ca += "</td>";
                }

                if (dropMomentos.SelectedValue == "5")
                {
                    ca += "<td align='center'>" + EspacioApropiacion(asesores.Rows[i]["codigo"].ToString(), "1", codmomento) + "</td>";
                    ca += "<td align='center'>" + s008(asesores.Rows[i]["codigo"].ToString(), "1", codmomento) + "</td>";
                    ca += "<td align='center'>" + maestrosferias(asesores.Rows[i]["codigo"].ToString()) + "</td>";
                }

                ca += "<td align='center'>" + plandetrabajo(asesores.Rows[i]["identificacion"].ToString(), codmomento) + "</td>";
                ca += "<td align='center'>" + usuariolog(asesores.Rows[i]["identificacion"].ToString()) + "</td>";

            }
            ca += "<tr style='font-weight:bold;'>";
            ca += "<td colspan='3' align='center'>TOTAL: </td>";
            //ca +="<td align='center'>" + totalgruposabi + "</td>";
            //ca += "<td align='center'>" + totalgrupospre + "</td>";

            if (dropMomentos.SelectedValue != "5")
            {
                ca += "<td align='center'>" + totals002 + "</td>";
            }
           

            if (dropMomentos.SelectedValue == "1")
            {
                ca += "<td align='center'>" + totalb1 + "</td>";
                ca += "<td align='center'>" + totalb2 + "</td>";
                ca += "<td align='center'>" + totalb3 + "</td>";
            }

            if (dropMomentos.SelectedValue == "3")
            {
                ca += "<td align='center'>" + totalb4 + "</td>";
                ca += "<td align='center'>" + totalb5 + "</td>";
                ca += "<td align='center'>" + totalb6 + "</td>";
            }

            if (dropMomentos.SelectedValue == "4")
            {
                ca += "<td align='center'>" + totals003 + "</td>";
                ca += "<td align='center'>" + totalbitacora7 + "</td>";
                ca += "<td align='center'>" + total4_1 + "</td>";
                ca += "<td align='center'>" + total4_2 + "</td>";
                ca += "<td align='center'>" + total4_3 + "</td>";
            }
            if (dropMomentos.SelectedValue == "5")
            {
                ca += "<td align='center'>" + totalespacio + "</td>";
                ca += "<td align='center'>" + totals008 + "</td>";
                ca += "<td align='center'>" + totalmaestrosferias + "</td>";
            }
            ca += "<td align='center'>" + totalpre + "</td>";
            ca += "<td align='center'>" + totalplan + "</td>";
            ca += "</tr>";
            ca += "</tbody>";
            ca += "</table>";
        }
        lblResultado.Text = ca;
    }

    private string lineaEncabezado()
    {
        string ca = "";

        ca += "<table class='mGridTesoreria'><tr>";
        ca += "<thead>";
        ca += "<th>No.</th>";
        ca += "<th>Nombre Asesor</th>";
        ca += "<th>Momento Pedagógico</th>";
        //ca += "<th>Grupos de investigación Abierta</th>";
        //ca += "<th>Grupos de investigación Pre-Estructurado</th>";
        if (dropMomentos.SelectedValue != "5")
        {
            ca += "<th>Registros de asesorías: S002</th>";
        }
        

        if (dropMomentos.SelectedValue == "1")
        {
            ca += "<th>Bitácora 01</th>";
            ca += "<th>Bitácora 02</th>";
            ca += "<th>Bitácora 03</th>";
            ca += "<th>Pre-Estructurado</th>";
        }

        if(dropMomentos.SelectedValue == "3")
        {
            ca += "<th>Bitácora 04</th>";
            ca += "<th>Bitácora 05</th>";
            ca += "<th>Bitácora 06</th>";
            ca += "<th>Preestructurados</th>";
        }

        if (dropMomentos.SelectedValue == "4")
        {
            ca += "<th>S003: Informe de investigación </th>";
            ca += "<th>Bitácora 7 proyección </th>";
            ca += "<th>Bitácora 4.1 informe financiero </th>";
            ca += "<th>Bitácora 4.2 informe financiero </th>";
            ca += "<th>Bitácora 4.3 informe financiero </th>";
            ca += "<th>Evidencias Prestructurados</th>";
        }

        if (dropMomentos.SelectedValue == "5")
        {
            ca += "<th>Espacios de apropiación institucional </th>";
            ca += "<th>S008 resumen artículo de investigación </th>";
            ca += "<th>Maestros participantes en comité de ferias</th>";
           
        }
       
        ca += "<th>Plan de trabajo</th>";
        ca += "<th>Fecha ultimo ingreso</th>";
        ca += "</thead>";
        ca += "</tr>";

        return ca;
    }

    private string s003(string codasesorcoordinador)
    {
        string ca = "";

        int gt = 0; ;

        DataTable count = est.cargarInstrmentoS003_Estrategia1(codasesorcoordinador, "0", "10000");//Abierta



        if (count != null && count.Rows.Count > 0)
        {
            ca += count.Rows.Count.ToString();

            gt += count.Rows.Count;
        }
        else
        {
            ca += "0";
        }

        totals003 += gt;
        return ca;
    }

    private string bitacora4_1(string idasesor, string desembolso)
    {
        string ca = "";

        int gt = 0; ;

        DataRow usuario = est.buscarCodUsuarioxIDAsesor(idasesor);

        if (usuario != null)
        {
            DataTable count = inst.cargarEvidenciasBitacora4punto1(desembolso, usuario["cod"].ToString());

            if (count != null && count.Rows.Count > 0)
            {
                ca = count.Rows.Count.ToString();
            }
            else
            {
                ca = "0";
            }
            total4_1 += count.Rows.Count;
        }

        return ca;
    }

    private string bitacora4_2(string idasesor, string desembolso)
    {
        string ca = "";

        int gt = 0; ;

        DataRow usuario = est.buscarCodUsuarioxIDAsesor(idasesor);

        if (usuario != null)
        {
            DataTable count = inst.cargarEvidenciasBitacora4punto1(desembolso, usuario["cod"].ToString());

            if (count != null && count.Rows.Count > 0)
            {
                ca = count.Rows.Count.ToString();
            }
            else
            {
                ca = "0";
            }
            total4_1 += count.Rows.Count;
        }

        return ca;
    }

    private string bitacora4_3(string idasesor, string desembolso)
    {
        string ca = "";

        int gt = 0; ;

        DataRow usuario = est.buscarCodUsuarioxIDAsesor(idasesor);

        if (usuario != null)
        {
            DataTable count = inst.cargarEvidenciasBitacora4punto1(desembolso, usuario["cod"].ToString());

            if (count != null && count.Rows.Count > 0)
            {
                ca = count.Rows.Count.ToString();
            }
            else
            {
                ca = "0";
            }
            total4_1 += count.Rows.Count;
        }

        return ca;
    }

    private string bitacora7(string codasesorcoordinador, string estrategia, string momento)
    {
        string ca = "";

        int gt = 0; ;

        DataTable count = inst.listarBitacoraSiete(codasesorcoordinador, estrategia, momento, "0");



        if (count != null && count.Rows.Count > 0)
        {
            ca += count.Rows.Count.ToString();

            gt += count.Rows.Count;
        }
        else
        {
            ca += "0";
        }

        totalbitacora7 += gt;
        return ca;
    }

    private string EspacioApropiacion(string codasesorcoordinador, string estrategia, string momento)
    {
        string ca = "";

        int gt = 0; ;

        DataTable count = inst.listarEspaciosApropiacion(codasesorcoordinador, estrategia, momento);



        if (count != null && count.Rows.Count > 0)
        {
            ca += count.Rows.Count.ToString();

            gt += count.Rows.Count;
        }
        else
        {
            ca += "0";
        }

        totalespacio += gt;
        return ca;
    }

    private string s008(string codasesorcoordinador, string estrategia, string momento)
    {
        string ca = "";

        int gt = 0; ;

        DataTable count = inst.listarS008(codasesorcoordinador, estrategia, momento);



        if (count != null && count.Rows.Count > 0)
        {
            ca += count.Rows.Count.ToString();

            gt += count.Rows.Count;
        }
        else
        {
            ca += "0";
        }

        totals008 += gt;
        return ca;
    }

    private string maestrosferias(string codasesorcoordinador)
    {
        string ca = "";

        int gt = 0; ;

        DataTable count = inst.listarParticipantesFerias(codasesorcoordinador);



        if (count != null && count.Rows.Count > 0)
        {
            ca += count.Rows.Count.ToString();

            gt += count.Rows.Count;
        }
        else
        {
            ca += "0";
        }

        totalmaestrosferias += gt;
        return ca;
    }
    
    private string gruposInvestigacionAbi(string codasesorcoordinador)
    {
        string ca = "";

        int gt = 0; ;

        DataTable count = est.cargarGruposInvestigacionxAsesorLinea(codasesorcoordinador, "2");//Abierta


   
        if(count != null && count.Rows.Count > 0)
        {
            ca += count.Rows.Count.ToString();

            gt += count.Rows.Count;
        }
        else
        {
            ca += "0";
        }

        totalgruposabi += gt;
        return ca;
    }

    private string gruposInvestigacionPre(string codasesorcoordinador)
    {
        string ca = "";
        int g2 = 0;

        DataTable count2 = est.cargarGruposInvestigacionxAsesorLinea(codasesorcoordinador, "3");//Pre-estructurado

     

        if (count2 != null && count2.Rows.Count > 0)
        {
         
            ca +=  count2.Rows.Count.ToString() ;
            g2 = count2.Rows.Count;
        }
        else
        {
           
            ca += "0";
        }
        totalgrupospre += g2;
        return ca;
    }

    private string registroAsesoria(string codasesorcoordinador, string codanio, string codmomento)
    {
        string ca = "";

        DataTable count = inst.listarInstrumentos002SinSesionConAnio(codasesorcoordinador, "1", codmomento, codanio);

        if (count != null && count.Rows.Count > 0)
        {
            ca = count.Rows.Count.ToString();
        }
        else
        {
            ca = "0";
        }
        totals002 += count.Rows.Count;
        return ca;
    }

    private string bitacora1(string codasesorcoordinador, string codanio, string codmomento)
    {
        string ca = "";

        DataTable count = est.cargarbitacoraunoxAsesorxMomento(codasesorcoordinador, codmomento, codanio);

        if (count != null && count.Rows.Count > 0)
        {
            ca = count.Rows.Count.ToString();
        }
        else
        {
            ca = "0";
        }
        totalb1 += count.Rows.Count;
        return ca;
    }

    private string bitacora2(string codasesorcoordinador, string codanio, string codmomento)
    {
        string ca = "";

        DataTable count = est.listarBitacoraDosxMomentoxAnio(codasesorcoordinador, codmomento, codanio);

        if (count != null && count.Rows.Count > 0)
        {
            ca = count.Rows.Count.ToString();
        }
        else
        {
            ca = "0";
        }
        totalb2 += count.Rows.Count;
        return ca;
    }

    private string bitacora3(string codasesorcoordinador, string codanio, string codmomento)
    {
        string ca = "";

        DataTable count = est.listarBitacoraTresxAsesorxMomento(codasesorcoordinador, codmomento, codanio);

        if (count != null && count.Rows.Count > 0)
        {
            ca = count.Rows.Count.ToString();
        }
        else
        {
            ca = "0";
        }
        totalb3 += count.Rows.Count;
        return ca;
    }

    private string bitacora4(string codasesorcoordinador, string codanio, string codmomento)
    {
        string ca = "";

        DataTable count = est.listarBitacoraCuatroxAsesorxMomento(codasesorcoordinador, codmomento, codanio);

        if (count != null && count.Rows.Count > 0)
        {
            ca = count.Rows.Count.ToString();
        }
        else
        {
            ca = "0";
        }
        totalb4 += count.Rows.Count;
        return ca;
    }

    private string bitacora5(string codasesorcoordinador, string codanio, string codmomento)
    {
        string ca = "";

        DataTable count = est.listarBitacoraCincoxAsesorxMomento(codasesorcoordinador, codmomento, codanio);

        if (count != null && count.Rows.Count > 0)
        {
            ca = count.Rows.Count.ToString();
        }
        else
        {
            ca = "0";
        }
        totalb5 += count.Rows.Count;
        return ca;
    }

    private string bitacora6(string codasesorcoordinador, string codanio, string codmomento)
    {
        string ca = "";

        DataTable count = est.listarBitacoraSeisxAsesorxMomento(codasesorcoordinador, codmomento, codanio);

        if (count != null && count.Rows.Count > 0)
        {
            ca = count.Rows.Count.ToString();
        }
        else
        {
            ca = "0";
        }
        totalb6 += count.Rows.Count;
        return ca;
    }

    private string preestructurados(string codasesorcoordinador, string estrategia, string momento, string actividad)
    {
        string ca = "";

        //DataRow usuario = est.buscarCodUsuarioxIDAsesor(idasesor);

        //if(usuario != null)
        //{
            DataTable count = inst.listarPreestructuradosConPre(codasesorcoordinador, estrategia, momento, actividad);

            if (count != null && count.Rows.Count > 0)
            {
                ca = count.Rows.Count.ToString();
            }
            else
            {
                ca = "0";
            }
            totalpre += count.Rows.Count;
        //}

       

        return ca;
    }

    private string usuariolog(string codusuariorol)
    {
        string ca = "";

        DataRow usuario = usu.buscarUltimoAccesoUsuarioLog(codusuariorol);

        if (usuario != null)
        {
            ca = usuario["fecha"].ToString();
        }



        return ca;
    }

    private string plandetrabajo(string idasesor, string momento)
    {
        string ca = "";

      
        DataRow usuario = est.buscarCodUsuarioxIDAsesor(idasesor);

        if (usuario != null)
        {
            DataTable count = est.cargarEvidenciasEstrategiaplanxActividadSeguimiento("1", usuario["cod"].ToString());

            if (count != null && count.Rows.Count > 0)
            {
                ca = count.Rows.Count.ToString();
            }
            else
            {
                ca = "0";
            }
            totalplan += count.Rows.Count;
        }

        return ca;
    }

    protected void btnExportar_Click(object sender, EventArgs e)
    {
        Response.ContentEncoding = System.Text.Encoding.Default;
        Response.Clear();
        Response.Buffer = true;
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Charset = "";
        //string FileName = "Documento exportado" + DateTime.Now + ".doc";
        StringWriter strwritter = new StringWriter();
        HtmlTextWriter htmltextwrtter = new HtmlTextWriter(strwritter);


        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.ms-xls";
        Response.AddHeader("content-disposition", string.Format("attachment; filename=repseguimiento.xls"));
        //PanelFactor.GridLines = GridLines.Both;
        //PanelFactor.HeaderStyle.Font.Bold = true;
        export.RenderControl(htmltextwrtter);
        Response.Write(strwritter.ToString());
        Response.End();


    }


    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
}