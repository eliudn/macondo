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

public partial class menusegproducto : System.Web.UI.Page
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
        Consultas c = new Consultas();
        Funciones fun = new Funciones();
        Estrategias est = new Estrategias();
        Institucion ins = new Institucion();


        DataTable maestrofor = est.cargardocentesformados();
        DataTable datosdocentes = c.cargarDocentesBeneficiadosEnSesionesJornadas();
        DataTable datossedesconectadas = c.cargarSedesConectadasxMunicipio("", "", "", "");
        DataTable datosredes = c.cargarTablaRedTematicaTodo();
        DataTable datosgrupos = ins.cargarTodoGrupoInvestigacion();
        DataTable datosferias = est.cargarFeriasMunicipalesMaferpi();
        DataRow datostabletas = c.sumTotalTabletas();

        if (datosdocentes != null && maestrofor.Rows.Count > 0)
        {
            double totaldocporcentaje = ((double)Convert.ToInt32(maestrofor.Rows.Count)/3386) * 100;
            ca += "<tr><td>Maestros formados</td><td>3386</td>";
            ca += "<td>" + maestrofor.Rows.Count + "</td>";
            ca += "<td>" + Math.Round(totaldocporcentaje,2) +"%</td>";
            ca += "<td> <a href='#'>Ver detalles</a></td></tr>";
        }
        else
        {
            ca += "<tr><td>Maestros formados</td><td>3600</td>";
            ca += "<td>0</td>";
            ca += "<td>0</td>";
            ca += "<td></td></tr>";
        }

        if (datossedesconectadas != null && datossedesconectadas.Rows.Count > 0)
        {
            double totalsedesconporcentaje = ((double)Convert.ToInt32(datossedesconectadas.Rows.Count) / 320) * 100;
            ca += "<tr><td>IE Conectadas</td><td>320</td>";
            ca += "<td>" + datossedesconectadas.Rows.Count + "</td>";
            ca += "<td>" + Math.Round(totalsedesconporcentaje, 2) + "%</td>";
            ca += "<td style> <a href='javascript:void(0)' onclick=\"verConsultas('seconectadas');\">Ver detalles</a></td></tr>";
        }
        else
        {
            ca += "<tr><td>IE Conectadas</td><td>320</td>";
            ca += "<td>0</td>";
            ca += "<td>0</td>";
            ca += "<td>0</td>";
            ca += "<td></td></tr>";
        }

        if (datosredes != null && datosredes.Rows.Count > 0)
        {
            double totalredesporcentaje = ((double)Convert.ToInt32(datosredes.Rows.Count) / 3227) * 100;
            ca += "<tr><td>Redes Temáticas</td><td>3227</td>";
            ca += "<td>" + datosredes.Rows.Count + "</td>";
            ca += "<td>" + Math.Round(totalredesporcentaje, 2) + "%</td>";
            ca += "<td style> <a href='javascript:void(0)' onclick=\"verConsultas('redes');\">Ver detalles</a></td></tr>";
        }
        else
        {
            ca += "<tr><td>Redes Temáticas</td><td>3227</td>";
            ca += "<td>0</td>";
            ca += "<td>0</td>";
            ca += "<td>0</td>";
            ca += "<td></td></tr>";
        }

        if (datosgrupos != null && datosgrupos.Rows.Count > 0)
        {
            double totalgruposporcentaje = ((double)Convert.ToInt32(datosgrupos.Rows.Count) / 420) * 100;
            ca += "<tr><td>Grupos de investigación</td><td>420</td>";
            ca += "<td>" + datosgrupos.Rows.Count + "</td>";
            ca += "<td>" + Math.Round(totalgruposporcentaje, 2) + "%</td>";
            ca += "<td style> <a href='javascript:void(0)' onclick=\"verConsultas('gijuveniles');\">Ver detalles</a></td></tr>";
        }
        else
        {
            ca += "<tr><td>Grupos de investigación</td><td>420</td>";
            ca += "<td>0</td>";
            ca += "<td>0</td>";
            ca += "<td>0</td>";
            ca += "<td></td></tr>";
        }

        if (datosferias != null && datosferias.Rows.Count > 0)
        {
            double totalferiasporcentaje = ((double)Convert.ToInt32(datosferias.Rows.Count) / 720) * 100;
            ca += "<tr><td>Ferias</td><td>720</td>";
            ca += "<td>" + datosferias.Rows.Count + "</td>";
            ca += "<td>" + Math.Round(totalferiasporcentaje, 2) + "%</td>";
            ca += "<td style> <a href='javascript:void(0)' onclick=\"(cargarFerias());\">Ver detalles</a></td></tr>";
        }
        else
        {
            ca += "<tr><td>Ferias</td><td>720</td>";
            ca += "<td>0</td>";
            ca += "<td>0</td>";
            ca += "<td>0</td>";
            ca += "<td></td></tr>";
        }

        if (datostabletas != null)
        {
            double totaltabletasporcentaje = ((double)Convert.ToInt32(datostabletas["total"].ToString()) / 28000) * 100;
            ca += "<tr><td>Tabletas por IE</td><td>28000</td>";
            ca += "<td>" + datostabletas["total"].ToString() + "</td>";
            ca += "<td>" + Math.Round(totaltabletasporcentaje, 2) + "%</td>";
            ca += "<td style> <a href='javascript:void(0)' onclick=\"verConsultas('setabletas');\">Ver detalles</a></td></tr>";
        }
        else
        {
            ca += "<tr><td>Ferias</td><td>28000</td>";
            ca += "<td>0</td>";
            ca += "<td>0</td>";
            ca += "<td>0</td>";
            ca += "<td></td></tr>";
        }


        return ca;

    }

    [WebMethod(EnableSession = true)]
    public static string cargarFerias()
    {

        string ca = "table@";
        Consultas c = new Consultas();
        Funciones fun = new Funciones();
        DataTable datos = null;

        datos = c.cargarFeriasMunicipales();

        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {

                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>MAGDALENA</td>";
                ca += "<td>" + datos.Rows[i]["nombreferiamunicipal"].ToString() + "</td>";
                ca += "<td>" + fun.convertFechaDia(datos.Rows[i]["fechaelaboracion"].ToString()) + "</td>";
                ca += "<td>" + datos.Rows[i]["horaferia"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["horaferiafinal"].ToString() + "</td>";
                ca += "<td align='right'>" + datos.Rows[i]["numerogrupos"].ToString() + "</td>";
                ca += "<td align='right'>" + datos.Rows[i]["numeroasistentes"].ToString() + "</td>";
                ca += "</tr>";

            }
        }
        else
        {
            ca += "<tr>";
            ca += "<td colspan='15' style='padding:15px;'><center>No se encontraron resultados</center></td>";
            ca += "</tr>";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarRedes()
    {

        string ca = "";
        Consultas c = new Consultas();
        Funciones fun = new Funciones();
        DataTable datos = null;

        datos = c.cargarRedes();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "red@";
            ca += "<option value=''  selected>Todos</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarRedesTematicas(string codMunicipio, string codInstitucion, string codSede, string redtematica)
    {

        string ca = "table@";
        Consultas c = new Consultas();
        Funciones fun = new Funciones();
        DataTable datos = null;

        datos = c.cargarTablaRedTematicaTodoWhere(codMunicipio, codInstitucion, codSede, redtematica);

        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {

                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["dane"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["red"].ToString() + "</td>";
                ca += "</tr>";

            }
        }
        else
        {
            ca += "<tr>";
            ca += "<td colspan='15' style='padding:15px;'><center>No se encontraron resultados</center></td>";
            ca += "</tr>";
        }
        return ca;
    }
   

}