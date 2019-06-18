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

public partial class detallesedesgpbitacora4 : System.Web.UI.Page
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
        //Session["fechaini"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["fechaini"]);
        //Session["fechafin"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["fechafin"]);
    }
    private string encabezado()
    {
        string ca = "";

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

    [WebMethod(EnableSession = true)]
    public static string sedesGPBitacora4()
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable sedesGPBitacora4 = est.sedesGPBitacora4("","","");


        if (sedesGPBitacora4 != null && sedesGPBitacora4.Rows.Count > 0)
        {
            int total = sedesGPBitacora4.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < sedesGPBitacora4.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + sedesGPBitacora4.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + sedesGPBitacora4.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + sedesGPBitacora4.Rows[i]["dane"].ToString() + " - " + sedesGPBitacora4.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + sedesGPBitacora4.Rows[i]["danesede"].ToString() + " - " + sedesGPBitacora4.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "</tr>";
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
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
    public static string realizarBusqueda(string coddepartamento, string codmuncipio, string codinstitucion)
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable sedesGPBitacora4 = est.sedesGPBitacora4(coddepartamento, codmuncipio, codinstitucion);


        if (sedesGPBitacora4 != null && sedesGPBitacora4.Rows.Count > 0)
        {
            int total = sedesGPBitacora4.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < sedesGPBitacora4.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + sedesGPBitacora4.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + sedesGPBitacora4.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + sedesGPBitacora4.Rows[i]["dane"].ToString() + " - " + sedesGPBitacora4.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + sedesGPBitacora4.Rows[i]["danesede"].ToString() + " - " + sedesGPBitacora4.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "</tr>";
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td style=\"text-align:center;\">Sin resultados</td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "</tr>";
        }

        return ca;
    }


    //grupos de investigación con Bitácora 04s
    [WebMethod(EnableSession = true)]
    public static string gruposInvestigacionBitacora4()
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable gruposInvestigacionBitacora4 = est.gruposInvestigacionBitacora4("", "", "", "", "");


        if (gruposInvestigacionBitacora4 != null && gruposInvestigacionBitacora4.Rows.Count > 0)
        {
            int total = gruposInvestigacionBitacora4.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < gruposInvestigacionBitacora4.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + gruposInvestigacionBitacora4.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionBitacora4.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionBitacora4.Rows[i]["dane"].ToString() + " - " + gruposInvestigacionBitacora4.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionBitacora4.Rows[i]["danesede"].ToString() + " - " + gruposInvestigacionBitacora4.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionBitacora4.Rows[i]["nombregrupo"].ToString() + " </td>";
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

    //busqueda grupos de investigación con Bitácora 04s
    [WebMethod(EnableSession = true)]
    public static string realizarBusquedagruposInvestigacionBitacora4(string coddepartamento, string codmuncipio, string codinstitucion, string codsede, string codgrupoinvestigacion)
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable gruposInvestigacionBitacora4 = est.gruposInvestigacionBitacora4(coddepartamento, codmuncipio, codinstitucion, codsede, codgrupoinvestigacion);


        if (gruposInvestigacionBitacora4 != null && gruposInvestigacionBitacora4.Rows.Count > 0)
        {
            int total = gruposInvestigacionBitacora4.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < gruposInvestigacionBitacora4.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + gruposInvestigacionBitacora4.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionBitacora4.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionBitacora4.Rows[i]["dane"].ToString() + " - " + gruposInvestigacionBitacora4.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionBitacora4.Rows[i]["danesede"].ToString() + " - " + gruposInvestigacionBitacora4.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionBitacora4.Rows[i]["nombregrupo"].ToString() + " </td>";
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


    //----------------------------------------------------------------------------------------
    //grupos de investigación con recursos aprobados por ciclón
    [WebMethod(EnableSession = true)]
    public static string gruposInvestigacionRecursosB4()
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable gruposInvestigacionRecursosB4 = est.gruposInvestigacionRecursosB4("", "", "", "", "");


        if (gruposInvestigacionRecursosB4 != null && gruposInvestigacionRecursosB4.Rows.Count > 0)
        {
            int total = gruposInvestigacionRecursosB4.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < gruposInvestigacionRecursosB4.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + gruposInvestigacionRecursosB4.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionRecursosB4.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionRecursosB4.Rows[i]["dane"].ToString() + " - " + gruposInvestigacionRecursosB4.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionRecursosB4.Rows[i]["danesede"].ToString() + " - " + gruposInvestigacionRecursosB4.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionRecursosB4.Rows[i]["nombregrupo"].ToString() + " </td>";
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

    //busqueda grupos de investigación con recursos aprobados por ciclón
    [WebMethod(EnableSession = true)]
    public static string realizarBusquedagruposInvestigacionRecursosB4(string coddepartamento, string codmuncipio, string codinstitucion, string codsede, string codgrupoinvestigacion)
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable gruposInvestigacionRecursosB4 = est.gruposInvestigacionRecursosB4(coddepartamento, codmuncipio, codinstitucion, codsede, codgrupoinvestigacion);


        if (gruposInvestigacionRecursosB4 != null && gruposInvestigacionRecursosB4.Rows.Count > 0)
        {
            int total = gruposInvestigacionRecursosB4.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < gruposInvestigacionRecursosB4.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + gruposInvestigacionRecursosB4.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionRecursosB4.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionRecursosB4.Rows[i]["dane"].ToString() + " - " + gruposInvestigacionRecursosB4.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionRecursosB4.Rows[i]["danesede"].ToString() + " - " + gruposInvestigacionRecursosB4.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionRecursosB4.Rows[i]["nombregrupo"].ToString() + " </td>";
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


    //----------------------------------------------------------------------------------------
    //grupos de investigación con Bitácora 05
    [WebMethod(EnableSession = true)]
    public static string sedesGPBitacora5()
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable sedesGPBitacora5 = est.sedesGPBitacora5("", "", "");


        if (sedesGPBitacora5 != null && sedesGPBitacora5.Rows.Count > 0)
        {
            int total = sedesGPBitacora5.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < sedesGPBitacora5.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + sedesGPBitacora5.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + sedesGPBitacora5.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + sedesGPBitacora5.Rows[i]["dane"].ToString() + " - " + sedesGPBitacora5.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + sedesGPBitacora5.Rows[i]["danesede"].ToString() + " - " + sedesGPBitacora5.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "</tr>";
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td style=\"text-align:center;\">Sin resultados</td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "</tr>";
        }

        return ca;
    }

    //busqueda grupos de investigación con Bitácora 05
    [WebMethod(EnableSession = true)]
    public static string realizarBusquedasedesGPBitacora5(string coddepartamento, string codmuncipio, string codinstitucion)
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable sedesGPBitacora5 = est.sedesGPBitacora5(coddepartamento, codmuncipio, codinstitucion);


        if (sedesGPBitacora5 != null && sedesGPBitacora5.Rows.Count > 0)
        {
            int total = sedesGPBitacora5.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < sedesGPBitacora5.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + sedesGPBitacora5.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + sedesGPBitacora5.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + sedesGPBitacora5.Rows[i]["dane"].ToString() + " - " + sedesGPBitacora5.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + sedesGPBitacora5.Rows[i]["danesede"].ToString() + " - " + sedesGPBitacora5.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "</tr>";
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td style=\"text-align:center;\">Sin resultados</td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "</tr>";
        }

        return ca;
    }


    //----------------------------------------------------------------------------------------
    // Total de grupos de investigación con bitacora 5 
    [WebMethod(EnableSession = true)]
    public static string gruposInvestigacionBitacora5()
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable gruposInvestigacionBitacora5 = est.gruposInvestigacionBitacora5("", "", "","");


        if (gruposInvestigacionBitacora5 != null && gruposInvestigacionBitacora5.Rows.Count > 0)
        {
            int total = gruposInvestigacionBitacora5.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < gruposInvestigacionBitacora5.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + gruposInvestigacionBitacora5.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionBitacora5.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionBitacora5.Rows[i]["dane"].ToString() + " - " + gruposInvestigacionBitacora5.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionBitacora5.Rows[i]["danesede"].ToString() + " - " + gruposInvestigacionBitacora5.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionBitacora5.Rows[i]["nombregrupo"].ToString() + " </td>";
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

    //busqueda  Total de grupos de investigación con bitacora 5 
    [WebMethod(EnableSession = true)]
    public static string realizarBusquedagruposInvestigacionBitacora5(string coddepartamento, string codmuncipio, string codinstitucion, string codsede)
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable gruposInvestigacionBitacora5 = est.gruposInvestigacionBitacora5(coddepartamento, codmuncipio, codinstitucion, codsede);


        if (gruposInvestigacionBitacora5 != null && gruposInvestigacionBitacora5.Rows.Count > 0)
        {
            int total = gruposInvestigacionBitacora5.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < gruposInvestigacionBitacora5.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + gruposInvestigacionBitacora5.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionBitacora5.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionBitacora5.Rows[i]["dane"].ToString() + " - " + gruposInvestigacionBitacora5.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionBitacora5.Rows[i]["danesede"].ToString() + " - " + gruposInvestigacionBitacora5.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + gruposInvestigacionBitacora5.Rows[i]["nombregrupo"].ToString() + " </td>";
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

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("grupostrayectoriaindagacion.aspx");
    }
    
}