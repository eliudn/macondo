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

public partial class menusegestrategia3 : System.Web.UI.Page
{
    Funciones fun = new Funciones();
    Estrategias est = new Estrategias();
    protected void Page_Load(object sender, EventArgs e)
    {
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 
        if (!IsPostBack)
        {
            if (Session["codrol"] != null)
            {
               
                if (Session["codrol"].ToString() == "18")//Asesor CUC
                {
                    accordion.InnerHtml = MenuAcordeonGerencia();

                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }

    //Menú Gerencia
    private string MenuAcordeonGerencia()
    {
        string ca = "";

        //ca += "<h3>Estrategia </h3>";
        //ca += "<div>";
        //ca += "<ul style='margin-left:40px;'>"; //Submenu 
        //ca += "<li style='list-style-type: disc;' ><a href=''> Conformación grupos de investigación</a></li>";
        //ca += "</ul>"; //Fin Submenu
        //ca += "</div>";

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargardatos()
    {
        string ca = "";
        double pesototal = 0;
        int num = 0;
        Estrategias est = new Estrategias();
        Consultas c = new Consultas();


        // Definir los lineamientos metodológicos para el diseño e implementación de un sistema abierto y flexible de información, monitoreo, seguimiento, y evaluación, permanente apoyado en las TIC, de la línea de base y de los instrumentos respectivos, siguiendo los definidos por Colciencias y el Obervatorio Nacional de CT+I, anexos al Proyecto.
        DataTable listado = c.cargarEvidenciasEstrategia3("p","");
        double meta = 0;
        int count = 0;
        int total = 1;
        double pesototalv = 20.65;
        double peso = 0;
        if (listado != null && listado.Rows.Count > 0)
        {
            count = listado.Rows.Count;
            meta = ((double)count / (double)total) * 100;
            meta = Math.Round(meta, 2);
            //if (meta > 100)
            //{
            //    meta = 100;
            //}

            peso = ((double)count / (double)total) * pesototalv;
            peso = Math.Round(peso, 4);
            if (peso > pesototalv)
            {
                peso = pesototalv;
            }
            pesototal = pesototal + peso;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b>  Definir los lineamientos metodológicos para el diseño e implementación de un sistema abierto y flexible de información, monitoreo, seguimiento, y evaluación, permanente apoyado en las TIC, de la línea de base y de los instrumentos respectivos, siguiendo los definidos por Colciencias y el Obervatorio Nacional de CT+I, anexos al Proyecto. </td>";
        ca += "<td class='center'>" + count + " de " + total + "</td>";
        ca += "<td class='center'>" + meta + "%</td>";
        ca += "<td class='center'>" + peso + "%</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Diseñar y sacar a producción el sistema abierto y flexible de información, monitoreo, seguimiento, y evaluación y su dispositivo digital-
        DataTable listadoas = c.cargarEvidenciasEstrategia3("p", "");
        double metaas = 0;
        int countas = 0;
        int totalas = 1;
        double pesototalvas = 12.23;
        double pesoas = 0;
        if (listadoas != null && listadoas.Rows.Count > 0)
        {
            countas = listadoas.Rows.Count;
            metaas = ((double)countas / (double)totalas) * 100;
            metaas = Math.Round(metaas, 2);
            //if (meta > 100)
            //{
            //    meta = 100;
            //}

            pesoas = ((double)countas / (double)totalas) * pesototalvas;
            pesoas = Math.Round(pesoas, 4);
            if (pesoas > pesototalvas)
            {
                pesoas = pesototalvas;
            }
            pesototal = pesototal + pesoas;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Diseñar y sacar a producción el sistema abierto y flexible de información, monitoreo, seguimiento, y evaluación y su dispositivo digital- </td>";
        ca += "<td class='center'>" + countas + " de " + totalas + "</td>";
        ca += "<td class='center'>" + metaas + "%</td>";
        ca += "<td class='center'>" + pesoas + "%</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //lenvantar la Línea base del proyecto con información de  las 320 sedes de educativas en los procesos de investigación apoyados en las TIC-
        DataTable listado2 = c.cargarEvidenciasEstrategia3("e","Informe de línea de base" );
        double meta2 = 0;
        int count2 = 0;
        int total2 = 1;
        double pesototalv2 = 20.90;
        double peso2 = 0;
        if (listado2 != null && listado2.Rows.Count > 0)
        {
            count2 = listado2.Rows.Count;
            meta2 = ((double)count2 / (double)total2) * 100;
            meta2 = Math.Round(meta2, 2);
            //if (meta > 100)
            //{
            //    meta = 100;
            //}

            peso2 = ((double)count2 / (double)total2) * pesototalv2;
            peso2 = Math.Round(peso2, 4);
            if (peso2 > pesototalv2)
            {
                peso = pesototalv2;
            }
            pesototal = pesototal + peso2;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Lenvantar la Línea base del proyecto con información de  las 320 sedes de educativas en los procesos de investigación apoyados en las TIC- </td>";
        ca += "<td class='center'>" + count2 + " de " + total2 + "</td>";
        ca += "<td class='center'>" + meta2 + "%</td>";
        ca += "<td class='center'>" + peso2 + "%</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Formación del equipo de la Gobernación para generar la transferencia del conocimiento y la tecnología.
        DataTable listadoas2 = c.cargarEvidenciasEstrategia3("ac_2","");
        double metaas2 = 0;
        int countas2 = 0;
        int totalas2 = 5;
        double pesototalvas2 = 1.38;
        double pesoas2 = 0;
        if (listadoas2 != null && listadoas2.Rows.Count > 0)
        {   totalas2 =  listadoas2.Rows.Count;
            countas2 = listadoas2.Rows.Count;
            metaas2 = ((double)countas2 / (double)totalas2) * 100;
            metaas2 = Math.Round(metaas2, 2);
            //if (meta > 100)
            //{
            //    meta = 100;
            //}

            pesoas2 = ((double)countas2 / (double)totalas2) * pesototalvas2;
            pesoas2 = Math.Round(pesoas2, 4);
            if (pesoas2 > pesototalvas2)
            {
                pesoas2 = pesototalvas2;
            }
            pesototal = pesototal + pesoas2;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Formación del equipo de la Gobernación para generar la transferencia del conocimiento y la tecnología. </td>";
        ca += "<td class='center'>" + countas2 + " de " + totalas2 + "</td>";
        ca += "<td class='center'>" + metaas2 + "%</td>";
        ca += "<td class='center'>" + pesoas2 + "%</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Diseñar y realizar la evaluación intermedia y 2 monitoreo durante los 18  meses de ejecución del proyecto.
        DataTable listado3 = c.cargarEvidenciasEstrategia3_triple("e_2","m", "m_2");
        double meta3 = 0;
        int count3 = 0;
        int total3 = 3;
        double pesototalv3 = 30.46;
        double peso3 = 0;
        if (listado3 != null && listado3.Rows.Count > 0)
        {
            count3 = listado3.Rows.Count ;
            if(count3 > total3)
            {
                count3 = total3;
            }
            meta3 = ((double)count3 / (double)total3) * 100;
            meta3 = Math.Round(meta3, 2);
            if (meta3 > 100)
            {
                meta3 = 100;
            }

            peso3 = ((double)count3 / (double)total3) * pesototalv3;
            peso3 = Math.Round(peso3, 4);
            if (peso3 > pesototalv3)
            {
                peso3 = pesototalv3;
            }
            pesototal = pesototal + peso3;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Diseñar y realizar la evaluación intermedia y 2 monitoreo durante los 18  meses de ejecución del proyecto. </td>";
        ca += "<td class='center'>" + count3  + " de " + total3 + "</td>";
        ca += "<td class='center'>" + meta3 + "%</td>";
        ca += "<td class='center'>" + peso3 + "%</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Diseñar y realizar la evaluación  de impacto y 1 monitoreos durante los 36  meses de ejecución del proyecto.
        DataTable listadoas3 = c.cargarEvidenciasEstrategia3_doble("e_3", "m_3");
        DataTable listadoas31 = c.cargarEvidenciasEstrategia3_doble2("e_3", "m_3");
        DataTable listadoas32 = c.cargarEvidenciasEstrategia3_doble3();
        double metaas3 = 0;
        int countas3 = 0;
        int totalas3 = 6;
        double pesototalvas3 = 14.38;
        double pesoas3 = 0;
        if (listadoas31 != null && listadoas31.Rows.Count > 0)
        {
            countas3 = listadoas31.Rows.Count;
            metaas3 = ((double)countas3 / (double)totalas3) * 100;
            metaas3 = Math.Round(metaas3, 2);
            //if (meta > 100)
            //{
            //    meta = 100;
            //}

            pesoas3 = ((double)countas3 / (double)totalas3) * pesototalvas3;
            pesoas3 = Math.Round(pesoas3, 4);
            if (pesoas3 > pesototalvas3)
            {
                pesoas = pesototalvas3;
            }
            pesototal = pesototal + pesoas3;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Diseñar y realizar la evaluación  de impacto y 1 monitoreos durante los 36  meses de ejecución del proyecto. </td>";
        ca += "<td class='center'>" + countas3 + " de " + totalas3 + "</td>";
        ca += "<td class='center'>" + metaas3 + "%</td>";
        ca += "<td class='center'>" + pesoas3 + "%</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        /*---------------*/

        ca += "<tr>";
        ca += "<td></td>";
        ca += "<td></td>";
        ca += "<td>TOTAL</td>";
        ca += "<td>" + pesototal + "</td>";
        ca += "<td class='noExl center'><a href='#?sg=true'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        return ca;
    }
   

}