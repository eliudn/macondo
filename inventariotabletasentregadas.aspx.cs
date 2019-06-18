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

public partial class inventariotabletasentregadas : System.Web.UI.Page
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

        
        titulo.Text = "Equipamiento y uso pedagógico de TIC en las sedes educativas";
        subtitulo.Text = "Indicador: Inventario de las tabletas entregadas por el Proyecto a las sedes educativas.";
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
    public static string inventariotabletasentregadas_()
    {

        string ca = "";
        var lb = new LineaBase();

        DataRow totalEntregadas = lb.detalleTabletsEntregadasxRespuesta("","","","", "si");
        DataRow totalNoEntregadas = lb.detalleTabletsEntregadasxRespuesta("", "", "", "", "no");
        var total = Convert.ToInt32(totalEntregadas["total"].ToString()) + Convert.ToInt32(totalNoEntregadas["total"].ToString());

        ca += "lleno@<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th>Tabletas entregadas</th>";
        ca += "<th>Número de sedes</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> SI </td>";
        ca += "<td align='right'>" + totalEntregadas["total"].ToString() + "</td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> NO </td>";
        ca += "<td align='right'>" + totalNoEntregadas["total"].ToString() + "</td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        ca += "</tr></table>";

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string realizarBusquedainventariotabletasentregadas_(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string ca = "";
        var lb = new LineaBase();

        DataRow totalEntregadas = lb.detalleTabletsEntregadasxRespuesta(coddepartamento, codmunicipio, codinstitucion, codsede, "si");
        DataRow totalNoEntregadas = lb.detalleTabletsEntregadasxRespuesta(coddepartamento, codmunicipio, codinstitucion, codsede, "no");
        var total = Convert.ToInt32(totalEntregadas["total"].ToString()) + Convert.ToInt32(totalNoEntregadas["total"].ToString());

        ca += "lleno@<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th>Tabletas entregadas</th>";
        ca += "<th>Número de sedes</th>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> SI </td>";
        ca += "<td align='right'>" + totalEntregadas["total"].ToString() + "</td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td align='right'> NO </td>";
        ca += "<td align='right'>" + totalNoEntregadas["total"].ToString() + "</td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + total + "</td>";
        ca += "</tr></table>";

        return ca;
    }


    protected void btnRegresar_Click(object sender, EventArgs e)
    {

        Response.Redirect("evalintermediaGeneral.aspx");

    }

}