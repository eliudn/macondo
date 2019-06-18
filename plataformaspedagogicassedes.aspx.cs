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
using System.Text;

public partial class plataformaspedagogicassedes : System.Web.UI.Page
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
        Session["resp"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["resp"]);

        titulo.Text = "Acceso de los estudiantes y maestros beneficiarios a las tabletas entregadas por el Proyecto a las sedes educativas beneficiadas";
        subtitulo.Text = "Indicador: Plataformas pedagógicas de las sedes educativas.";
        descripcion.Text = "";

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

    
    [WebMethod(EnableSession = true)]
    public static string cargarPlataformasPedagogicas()
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarPlataformasPedagogicas();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "plataformas@";
            //ca += "<option value='' selected>Todos</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                if (i==0)
                {
                    ca += "<option selected value=''>Todas</option>";
                }
                else
                {
                    ca += "<option value='" + datos.Rows[i]["comentario"].ToString() + "'>" + datos.Rows[i]["comentario"].ToString() + "</option>";
                }
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


    public static void Decode(string path)
    {
        var data = new List<byte>();
        using (var sr = new StreamReader(path))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
                data.Add(Byte.Parse(line));
        }
        using (var sw = new StreamWriter(path))
        {
            sw.Write(Encoding.UTF8.GetString(data.ToArray()));
        }
    }

    [WebMethod(EnableSession = true)]
    public static string plataformaspedagogicassedes_(string respuesta)
    {

        string ca = "";
        var lb = new LineaBase();

        var respuesta1 = HttpUtility.UrlDecode(respuesta);

        DataTable plataformaspedagogicassedes = lb.detallePlataformasPedagogicasSedes("", "", "", "", "", respuesta);


        if (plataformaspedagogicassedes != null && plataformaspedagogicassedes.Rows.Count > 0)
        {
            int total = plataformaspedagogicassedes.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < plataformaspedagogicassedes.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + plataformaspedagogicassedes.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + plataformaspedagogicassedes.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + plataformaspedagogicassedes.Rows[i]["dane"].ToString() + " - " + plataformaspedagogicassedes.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + plataformaspedagogicassedes.Rows[i]["danesede"].ToString() + " - " + plataformaspedagogicassedes.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + plataformaspedagogicassedes.Rows[i]["comentario"].ToString() + " </td>";
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
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "</tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string realizarBusquedaplataformaspedagogicassedes_(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string respuesta, string opc)
    {
        string ca = "";
        var lb = new LineaBase();

        DataTable plataformaspedagogicassedes = lb.detallePlataformasPedagogicasSedes(coddepartamento, codmunicipio, codinstitucion, codsede, respuesta, opc);


        if (plataformaspedagogicassedes != null && plataformaspedagogicassedes.Rows.Count > 0)
        {
            int total = plataformaspedagogicassedes.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < plataformaspedagogicassedes.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + plataformaspedagogicassedes.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + plataformaspedagogicassedes.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + plataformaspedagogicassedes.Rows[i]["dane"].ToString() + " - " + plataformaspedagogicassedes.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + plataformaspedagogicassedes.Rows[i]["danesede"].ToString() + " - " + plataformaspedagogicassedes.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + plataformaspedagogicassedes.Rows[i]["comentario"].ToString() + " </td>";
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
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "</tr>";
        }

        return ca;
    }


    protected void btnRegresar_Click(object sender, EventArgs e)
    {

        Response.Redirect("evalintermediaGeneral.aspx");

    }

}