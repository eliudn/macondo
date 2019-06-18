using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using System.Web.Services;
using System.IO;

public partial class estras003 : System.Web.UI.Page
{

    Estrategias est = new Estrategias();


    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["codperfil"] != null)
        {

        }
        else
            Response.Redirect("Default.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 
        if (!IsPostBack)
        {
           if( Session["codgrupoinvestigacion"] != null)
           {
               
           }
           else
           {
               mostrarmensaje("error","No se recibieron los parámetros.");
           }
            //DataRow dato = est.buscarCodEstraAsesorxCoordinador(Session["identificacion"].ToString());

            //if (dato != null)
            //{
            //    Session["CodAsesorEstraCoordinador"] = dato["codigo"].ToString();
            //}
        }
    }
   
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        if (Session["e"] != null || Session["m"] != null || Session["s"] != null)
        {
            if (Session["e"].ToString() == "2")
                Response.Redirect("estradosmomentos.aspx?m=" + lblMomento.Text +"&s=" + lblSesion.Text);
            else if (Session["e"].ToString() == "4")
                Response.Redirect("estracuatromomentos.aspx?m=" + lblMomento.Text);
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
       
    }


    [WebMethod(EnableSession = true)]
    public static string cargarListadoS003(string page, string rows)
    {
        string ca = "";

        int pagint = Convert.ToInt32(page);
        int rowsint = Convert.ToInt32(rows);
        int offset = (pagint - 1) * rowsint;

        Estrategias est = new Estrategias();

        DataTable datos = est.cargarInstrmentoS003(HttpContext.Current.Session["codgrupoinvestigacion"].ToString(), Convert.ToString(offset), rows);

        if (datos != null && datos.Rows.Count > 0)
        {
            DataTable datosCount = est.cargarInstrmentoS003Count(HttpContext.Current.Session["codgrupoinvestigacion"].ToString());//Saber la cantidad de registros en la consulta

            double cant = datosCount.Rows.Count;
            double val = Math.Ceiling(cant / 10);

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + ((offset++) + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["objetivogeneral"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["perturbaciononda"].ToString() + "</td>";
                ca += "<td align=\"center\"><br /><a class='btn btn-success' onclick=\"$('#lista').hide(), $('#form').fadeIn(500), loadInstrumento(" + datos.Rows[i]["codigo"].ToString() + ")\">Editar</a><br/ ><br /><a onclick=\"eliminar(" + datos.Rows[i]["codigo"].ToString() + ")\" class=\"btn btn-danger\">Eliminar</a><br /><br /></td>";
                ca += "</tr>";
            }
            ca += "@S3p4";
            for (int j = 0; j < val; j++)
            {
                if (pagint == (j + 1))
                {
                    ca += " <span id='span" + (j + 1) + "' class=\"item current\" onclick='cargarListadoS003(\"" + (j + 1) + "\",\"10\")'>" + (j + 1) + "</span>";
                }
                else
                {
                    ca += " <span id='span" + (j + 1) + "' class=\"item\" onclick='cargarListadoS003(\"" + (j + 1) + "\",\"10\")'>" + (j + 1) + "</span>";
                }
            }
        }
        else
        {
            ca += "<tr><td colspan='11' align='center'>No se encontraron S003 registradas por parte del asesor.</td></tr>";
        }

        return ca;
    }

  

    //[WebMethod(EnableSession = true)]
    [System.Web.Services.WebMethod(EnableSession = true)]
    public static string insertestras003(string introduccion, string objetivogeneral, string objetivosespecificos, string perturbaciononda, string superposiciononda, string trayectoriaindagacion, string reflexiononda, string bibliografia, string anexoevidencias, string hallazgosyresultados, string bibliografiayfuentes)
    {

        Institucion inst = new Institucion();
        string ca = "";
        Funciones fun = new Funciones();

        DataRow insert = inst.procinsertestras003(HttpContext.Current.Session["codgrupoinvestigacion"].ToString(), introduccion, objetivogeneral, objetivosespecificos, perturbaciononda, superposiciononda, trayectoriaindagacion, reflexiononda, bibliografia, anexoevidencias, hallazgosyresultados, bibliografiayfuentes);

        if (insert != null)
        {
            ca = "true_insert@";
            ca += insert["codigo"].ToString();
        }
        else
        {
            ca = "Ocurrio un error al insertar ests003@";
        }


        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string updateestras003(string codigoestrategia, string introduccion, string objetivogeneral, string objetivosespecificos, string perturbaciononda, string superposiciononda, string trayectoriaindagacion, string reflexiononda, string bibliografia, string anexoevidencias, string hallazgosyresultados, string bibliografiayfuentes)
    {


        Institucion inst = new Institucion();
        string ca = "";

        long update = inst.procupdateestras003(codigoestrategia, introduccion, objetivogeneral, objetivosespecificos, perturbaciononda, superposiciononda, trayectoriaindagacion, reflexiononda, bibliografia, anexoevidencias, hallazgosyresultados, bibliografiayfuentes);
        if (update != -1)
        {
            ca = "true_update@";
        }
        else
        {
            ca = "Ocurrio un error al actualizar estras003@";
        }
        return ca;
    }

   

    [WebMethod(EnableSession = true)]
    public static string cargarDepartamentoMagdalena()
    {
        string ca = "";
        Institucion inst = new Institucion();
        DataTable datos = inst.cargarDepartamentoMagdalena();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "muni@";
            ca += "<option value='' disabled selected>Seleccione departamento...</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }
        else
        {
            ca = "vacio@";
        }
        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string cargarMunicipios(string coddepartamento)
    {
        string ca = "";
        Institucion inst = new Institucion();
        DataTable datos = inst.cargarciudadxDepartamento(coddepartamento);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "muni@";
            ca += "<option value='' disabled selected>Seleccione municipio...</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }
        else
        {
            ca = "vacio@";
        }
        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string cargarInstitucionesxMunicipio(string codmunicipio)
    {
        string ca = "";
        Institucion inst = new Institucion();
        DataTable datos = inst.proccargarInstitucionxMunicipio(codmunicipio);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "inst@";
            ca += "<option value='' disabled selected>Seleccione institución...</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }
        else
        {
            ca = "vacio@";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string grupoInvestigacion(string codsede)
    {

        string ca = "";

        Institucion inst = new Institucion();

        DataTable gruposinvestigacion = inst.cargarGruposInvestigacion(codsede, HttpContext.Current.Session["CodAsesorEstraCoordinador"].ToString());

        if (gruposinvestigacion != null && gruposinvestigacion.Rows.Count > 0)
        {
            ca = "gruposinvestigacion@";
            ca += "<option value='' disabled selected>Seleccione grupo investigación...</option>";
            for (int i = 0; i < gruposinvestigacion.Rows.Count; i++)
            {
                ca += "<option value='" + gruposinvestigacion.Rows[i]["codigo"].ToString() + "'>" + gruposinvestigacion.Rows[i]["nombregrupo"].ToString() + "</option>";
            }
        }
        else
        {
            ca = "vacio@<option value='sin' disabled selected>Sin grupos de investigación</option>";
        }

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string deleteestras003(string codigo)
    {
        string ca = "";
        Estrategias inst = new Estrategias();

        if (inst.eliminarS003(codigo))
        {

            ca = "delete@";
        }
        else
        {
            ca = "vacio@";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadestras003(string codigo)
    {
        string ca = "";
        Funciones fun = new Funciones();
        Estrategias inst = new Estrategias();

        DataRow datosinstrumento = inst.proloadestras003(codigo);

        if (datosinstrumento != null)
        {
            //HttpContext.Current.Session["codigo"] = codigo;
            //codigo, codestracoordinador, nombresesion,temasesion, informacionadicional, fechaelaboracion, nombrerelator, aspectosdesarrollados, conclusiones, bibliografia, desarrollo1, desarrollo3, actividadesytareas, aspectos
            ca = "datosintrumento_load@";
            ca += datosinstrumento["codigo"].ToString()//resp[1]
            + "_load@" + datosinstrumento["introduccion"].ToString()//resp[2]
            + "_load@" + datosinstrumento["objetivogeneral"].ToString()//resp[3]
            + "_load@" + datosinstrumento["objetivosespecificos"].ToString()//resp[4]
            + "_load@" + datosinstrumento["perturbaciononda"].ToString()//resp[5]
            + "_load@" + datosinstrumento["superposiciononda"].ToString()//resp[6]
            + "_load@" + datosinstrumento["trayectoriaindagacion"].ToString()//resp[7]
            + "_load@" + datosinstrumento["reflexiononda"].ToString()//resp[8]
            + "_load@" + datosinstrumento["bibliografia"].ToString()//resp[9]
            + "_load@" + datosinstrumento["anexoevidencias"].ToString()//resp[10]
            + "_load@" + datosinstrumento["hallazgosyresultados"].ToString()//resp[11]
            + "_load@" + datosinstrumento["bibliografiayfuentes"].ToString();//resp[12]
           
        }
        else
        {
            ca = "vacio@";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string borrarsesion()
    {
        string ca = "";

       

        return ca;
    }

}