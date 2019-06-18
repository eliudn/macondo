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

public partial class menusegconectividad : System.Web.UI.Page
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


        //Infraestructura de redes de información, comunicación y telecomunicaciones para 320 sedes educativas públicas del departamento del Magdalena.
        DataTable listado = est.cargarListadoConectividad();
        double meta = 0;
        int count = 0;
        int total = 320;
        double pesototalv = 17.110;
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
        ca += "<td><b>" + num + ".</b> Infraestructura de redes de información, comunicación y telecomunicaciones para 320 sedes educativas públicas del departamento del Magdalena. </td>";
        ca += "<td class='center'>" + count + " de " + total + "</td>";
        ca += "<td class='center'>" + meta + "%</td>";
        ca += "<td class='center'>" + peso + "</td>";
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