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

public partial class asesoriascpm3e1 : System.Web.UI.Page
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
    public static string asesoriasGPm3e1()
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable asesoriasGPm3e1 = est.asesoriasGPm3e1("", "", "", "","");

        if (asesoriasGPm3e1 != null && asesoriasGPm3e1.Rows.Count > 0)
        {
            int total = asesoriasGPm3e1.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < asesoriasGPm3e1.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + asesoriasGPm3e1.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPm3e1.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPm3e1.Rows[i]["dane"].ToString() + " - " + asesoriasGPm3e1.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPm3e1.Rows[i]["danesede"].ToString() + " - " + asesoriasGPm3e1.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPm3e1.Rows[i]["nombregrupo"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPm3e1.Rows[i]["objetivo"].ToString() + " </td>";
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
    public static string realizarBusquedaasesoriasGPm3e1(string coddepartamento, string codmuncipio, string codinstitucion, string codsede, string codgrupoinvestigacion)
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable asesoriasGPm3e1 = est.asesoriasGPm3e1(coddepartamento, codmuncipio, codinstitucion, codsede, codgrupoinvestigacion);

        if (asesoriasGPm3e1 != null && asesoriasGPm3e1.Rows.Count > 0)
        {
            int total = asesoriasGPm3e1.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < asesoriasGPm3e1.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + asesoriasGPm3e1.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPm3e1.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPm3e1.Rows[i]["dane"].ToString() + " - " + asesoriasGPm3e1.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPm3e1.Rows[i]["danesede"].ToString() + " - " + asesoriasGPm3e1.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPm3e1.Rows[i]["nombregrupo"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPm3e1.Rows[i]["objetivo"].ToString() + " </td>";
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
    public static string asesoriasGPCiclon()
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable asesoriasGPCiclon = est.asesoriasGPCiclon("", "", "", "", "");

        if (asesoriasGPCiclon != null && asesoriasGPCiclon.Rows.Count > 0)
        {
            int total = asesoriasGPCiclon.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < asesoriasGPCiclon.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + asesoriasGPCiclon.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPCiclon.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPCiclon.Rows[i]["dane"].ToString() + " - " + asesoriasGPCiclon.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPCiclon.Rows[i]["danesede"].ToString() + " - " + asesoriasGPCiclon.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPCiclon.Rows[i]["nombregrupo"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPCiclon.Rows[i]["nombrearchivo"].ToString() + " </td>";
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
    public static string realizarBusquedaasesoriasGPCiclon(string coddepartamento, string codmuncipio, string codinstitucion, string codsede, string codgrupoinvestigacion)
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable asesoriasGPCiclon = est.asesoriasGPCiclon(coddepartamento, codmuncipio, codinstitucion, codsede, codgrupoinvestigacion);

        if (asesoriasGPCiclon != null && asesoriasGPCiclon.Rows.Count > 0)
        {
            int total = asesoriasGPCiclon.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < asesoriasGPCiclon.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + asesoriasGPCiclon.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPCiclon.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPCiclon.Rows[i]["dane"].ToString() + " - " + asesoriasGPCiclon.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPCiclon.Rows[i]["danesede"].ToString() + " - " + asesoriasGPCiclon.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPCiclon.Rows[i]["nombregrupo"].ToString() + " </td>";
                ca += "<td>" + asesoriasGPCiclon.Rows[i]["nombrearchivo"].ToString() + " </td>";
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
        Response.Redirect("asesorgruposinvestigacion.aspx?m=3&e=1");
    }

}