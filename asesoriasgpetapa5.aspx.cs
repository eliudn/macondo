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

public partial class asesoriasgpetapa5 : System.Web.UI.Page
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


    //Cargar Departamento
    [WebMethod(EnableSession = true)]
    public static string cargarDepartamentoMagdalena()
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarDepartamentoMagdalena();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "departamento@";
            //ca += "<option value='' selected>Todos</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option selected value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    //Cargar municipios
    [WebMethod(EnableSession = true)]
    public static string cargarMunicipios(string codDepartamento)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarciudadxDepartamento(codDepartamento);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "municipio@";
            ca += "<option value='' selected>Todos</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    //cargar instituciones
    [WebMethod(EnableSession = true)]
    public static string cargarInstituciones(string codMunicipio)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.proccargarInstitucionxMunicipio(codMunicipio);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "inst@";
            ca += "<option value='' selected>Todas</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    //cargar sedes
    [WebMethod(EnableSession = true)]
    public static string cargarSedesxInstitucion(string codInstitucion)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarSedesInstitucion(codInstitucion);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "sede@";
            ca += "<option value='' selected>Todas</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    //cargar grupos de investigación
    [WebMethod(EnableSession = true)]
    public static string cargarGruposInvestigacionxSede(string codSede)
    {
        string ca = "";

        Estrategias est = new Estrategias();

        DataTable datos = est.cargarProyectoSedexSedes(codSede);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "grupoinvestigacion@";
            ca += "<option value='' selected>Todos</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombregrupo"].ToString() + "</option>";
            }
        }

        return ca;
    }

   
    Funciones fun = new Funciones();
   
    [WebMethod(EnableSession = true)]
    public static string asesoriasGPEtapa5()
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable asesoriasGPEtapa5 = est.asesoriasGPEtapa5("", "", "", "", "");

        if (asesoriasGPEtapa5 != null && asesoriasGPEtapa5.Rows.Count > 0)
        {
            int total = asesoriasGPEtapa5.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < asesoriasGPEtapa5.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + asesoriasGPEtapa5.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPEtapa5.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPEtapa5.Rows[i]["dane"].ToString() + " - " + asesoriasGPEtapa5.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPEtapa5.Rows[i]["danesede"].ToString() + " - " + asesoriasGPEtapa5.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPEtapa5.Rows[i]["nombregrupo"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPEtapa5.Rows[i]["objetivo"].ToString() + " </td>";
                ca += "</tr>";
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td style=\"text-align:center;\">Sin resultados</td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "</tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string realizarBusquedaasesoriasGPEtapa5(string coddepartamento, string codmuncipio, string codinstitucion, string codsede, string codgrupoinvestigacion)
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable asesoriasGPEtapa5 = est.asesoriasGPEtapa5(coddepartamento, codmuncipio, codinstitucion, codsede, codgrupoinvestigacion);

        if (asesoriasGPEtapa5 != null && asesoriasGPEtapa5.Rows.Count > 0)
        {
            int total = asesoriasGPEtapa5.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < asesoriasGPEtapa5.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + asesoriasGPEtapa5.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPEtapa5.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPEtapa5.Rows[i]["dane"].ToString() + " - " + asesoriasGPEtapa5.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPEtapa5.Rows[i]["danesede"].ToString() + " - " + asesoriasGPEtapa5.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPEtapa5.Rows[i]["nombregrupo"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPEtapa5.Rows[i]["objetivo"].ToString() + " </td>";
                ca += "</tr>";
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td style=\"text-align:center;\">Sin resultados</td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "</tr>";
        }

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string gruposInvestigacionPresupuesto()
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable gruposInvestigacionPresupuesto = est.gruposInvestigacionPresupuesto("", "", "", "");

        if (gruposInvestigacionPresupuesto != null && gruposInvestigacionPresupuesto.Rows.Count > 0)
        {
            int total = gruposInvestigacionPresupuesto.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < gruposInvestigacionPresupuesto.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + gruposInvestigacionPresupuesto.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionPresupuesto.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionPresupuesto.Rows[i]["dane"].ToString() + " - " + gruposInvestigacionPresupuesto.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionPresupuesto.Rows[i]["danesede"].ToString() + " - " + gruposInvestigacionPresupuesto.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionPresupuesto.Rows[i]["nombregrupo"].ToString() + " </td>";
                ca += "</tr>";
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td style=\"text-align:center;\">Sin resultados</td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "</tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string realizarBusquedagruposInvestigacionPresupuesto(string coddepartamento, string codmuncipio, string codinstitucion, string codsede)
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable gruposInvestigacionPresupuesto = est.gruposInvestigacionPresupuesto(coddepartamento, codmuncipio, codinstitucion, codsede);

        if (gruposInvestigacionPresupuesto != null && gruposInvestigacionPresupuesto.Rows.Count > 0)
        {
            int total = gruposInvestigacionPresupuesto.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < gruposInvestigacionPresupuesto.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + gruposInvestigacionPresupuesto.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionPresupuesto.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionPresupuesto.Rows[i]["dane"].ToString() + " - " + gruposInvestigacionPresupuesto.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionPresupuesto.Rows[i]["danesede"].ToString() + " - " + gruposInvestigacionPresupuesto.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionPresupuesto.Rows[i]["nombregrupo"].ToString() + " </td>";
                ca += "</tr>";
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td style=\"text-align:center;\">Sin resultados</td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "</tr>";
        }

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string asesoriasGPevaluadas()
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable asesoriasGPevaluadas = est.asesoriasGPevaluadas("", "", "", "", "");

        if (asesoriasGPevaluadas != null && asesoriasGPevaluadas.Rows.Count > 0)
        {
            int total = asesoriasGPevaluadas.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < asesoriasGPevaluadas.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + asesoriasGPevaluadas.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPevaluadas.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPevaluadas.Rows[i]["dane"].ToString() + " - " + asesoriasGPevaluadas.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPevaluadas.Rows[i]["danesede"].ToString() + " - " + asesoriasGPevaluadas.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPevaluadas.Rows[i]["nombregrupo"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPevaluadas.Rows[i]["objetivo"].ToString() + " </td>";
                ca += "</tr>";
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td style=\"text-align:center;\">Sin resultados</td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "</tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string realizarBusquedaasesoriasGPevaluadas(string coddepartamento, string codmuncipio, string codinstitucion, string codsede, string codgrupoinvestigacion)
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable asesoriasGPevaluadas = est.asesoriasGPevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, codgrupoinvestigacion);

        if (asesoriasGPevaluadas != null && asesoriasGPevaluadas.Rows.Count > 0)
        {
            int total = asesoriasGPevaluadas.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < asesoriasGPevaluadas.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + asesoriasGPevaluadas.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPevaluadas.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPevaluadas.Rows[i]["dane"].ToString() + " - " + asesoriasGPevaluadas.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPevaluadas.Rows[i]["danesede"].ToString() + " - " + asesoriasGPevaluadas.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPevaluadas.Rows[i]["nombregrupo"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPevaluadas.Rows[i]["objetivo"].ToString() + " </td>";
                ca += "</tr>";
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td style=\"text-align:center;\">Sin resultados</td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "</tr>";
        }

        return ca;
    }

  
  

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("asesorgruposinvestigacionetapa5.aspx?m=3&e=1");
    }

}