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

public partial class inventariodequipamiento : System.Web.UI.Page
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
        subtitulo.Text = "Indicador: Inventario del equipamiento de TIC en las sedes educativas.";
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
    public static string inventariodequipamiento_()
    {

        string ca = "";
        var lb = new LineaBase();        

        //normalista superior
        DataRow totalDocentesInventarios = lb.detalleInventariosxUsuario("", "", "", "", "Docentes");
        DataRow totalEstudiantesInventarios = lb.detalleInventariosxUsuario("", "", "", "", "Estudiantes");

        //docente
        var totalconexion = (Convert.ToInt32(totalDocentesInventarios["conpc"].ToString()) + Convert.ToInt32(totalDocentesInventarios["conportatil"].ToString()) + Convert.ToInt32(totalDocentesInventarios["contablet"].ToString()) + Convert.ToInt32(totalDocentesInventarios["contableros"].ToString()));
        var totalsinconexion = (Convert.ToInt32(totalDocentesInventarios["sinpc"].ToString()) + Convert.ToInt32(totalDocentesInventarios["sinportatil"].ToString()) + Convert.ToInt32(totalDocentesInventarios["sintablet"].ToString()) + Convert.ToInt32(totalDocentesInventarios["sintableros"].ToString()));
        //estudiante
        var totalconexionEst = (Convert.ToInt32(totalEstudiantesInventarios["conpc"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["conportatil"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["contablet"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["contableros"].ToString()));
        var totalsinconexionEst = (Convert.ToInt32(totalEstudiantesInventarios["sinpc"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["sinportatil"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["sintablet"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["sintableros"].ToString()));

        var totalTCo = (Convert.ToInt32(totalconexion) + Convert.ToInt32(totalconexionEst));
        var totalTSin = (Convert.ToInt32(totalsinconexion) + Convert.ToInt32(totalsinconexionEst));
        ca += "lleno@<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th rowspan='2'>Usuarios</th>";
        ca += "<th colspan='2'>No. PC </th>";
        ca += "<th colspan='2'>No. Portátiles </th>";
        ca += "<th colspan='2'>No. Tablet</th>";
        ca += "<th colspan='2'>No. Tableros inteligentes</th>";
        ca += "<th colspan='4'>Total equipamiento </th>";
        ca += "</tr>";
        ca += "<tr>";
        ca += "<th>Con conexión</th>";
        ca += "<th>Sin conexión</th>";
        ca += "<th>Con conexión</th>";
        ca += "<th>Sin conexión</th>";
        ca += "<th>Con conexión</th>";
        ca += "<th>Sin conexión</th>";
        ca += "<th>Con conexión</th>";
        ca += "<th>Sin conexión</th>";

        ca += "<th>Total equipamiento con conexión</th>";
        ca += "<th>Porcentaje equipamiento con conexión</th>";
        ca += "<th>Total equipamiento sin conexión</th>";
        ca += "<th>Porcentaje de equipamiento sin conexión</th>";


        ca += "</tr>";

        ca += "<tr>";
        ca += "<td>Docentes </td>";
        ca += "<td align='right'>" + totalDocentesInventarios["conpc"].ToString() + "</td>";
        ca += "<td align='right'>" + totalDocentesInventarios["sinpc"].ToString() + "</td>";
        ca += "<td align='right'>" + totalDocentesInventarios["conportatil"].ToString() + "</td>";
        ca += "<td align='right'>" + totalDocentesInventarios["sinportatil"].ToString() + "</td>";
        ca += "<td align='right'>" + totalDocentesInventarios["contablet"].ToString() + "</td>";
        ca += "<td align='right'>" + totalDocentesInventarios["sintablet"].ToString() + "</td>";
        ca += "<td align='right'>" + totalDocentesInventarios["contableros"].ToString() + "</td>";
        ca += "<td align='right'>" + totalDocentesInventarios["sintableros"].ToString() + "</td>";

        //--

        ca += "<td align='right'>" + totalconexion + "</td>";

        var porcentajeConexionDoc = Math.Round((((double)totalconexion / (double)totalTCo) * 100), 2);
        ca += "<td align='right'>" + porcentajeConexionDoc + "% </td>";

        var porcentajeSinConexionDoc = Math.Round((((double)totalsinconexion / (double)totalTSin) * 100), 2);
        ca += "<td align='right'>" + totalsinconexion + "</td>";
        ca += "<td align='right'>" + porcentajeSinConexionDoc + "% </td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td>Estudiantes </td>";
        ca += "<td align='right'>" + totalEstudiantesInventarios["conpc"].ToString() + "</td>";
        ca += "<td align='right'>" + totalEstudiantesInventarios["sinpc"].ToString() + "</td>";
        ca += "<td align='right'>" + totalEstudiantesInventarios["conportatil"].ToString() + "</td>";
        ca += "<td align='right'>" + totalEstudiantesInventarios["sinportatil"].ToString() + "</td>";
        ca += "<td align='right'>" + totalEstudiantesInventarios["contablet"].ToString() + "</td>";
        ca += "<td align='right'>" + totalEstudiantesInventarios["sintablet"].ToString() + "</td>";
        ca += "<td align='right'>" + totalEstudiantesInventarios["contableros"].ToString() + "</td>";
        ca += "<td align='right'>" + totalEstudiantesInventarios["sintableros"].ToString() + "</td>";
        //--

        ca += "<td align='right'>" + totalconexionEst + "</td>";

        var porcentajeConexionEst = Math.Round((((double)totalconexionEst / totalTCo) * 100), 2);
        ca += "<td align='right'>" + porcentajeConexionEst + "% </td>";
        ca += "<td align='right'>" + totalsinconexionEst + "</td>";

        var porcentajeSinConexionEst = Math.Round((((double)totalsinconexionEst / totalTSin) * 100), 2);
        ca += "<td align='right'>" + porcentajeSinConexionEst + "% </td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalDocentesInventarios["conpc"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["conpc"].ToString())) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalDocentesInventarios["sinpc"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["sinpc"].ToString())) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalDocentesInventarios["conportatil"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["conportatil"].ToString())) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalDocentesInventarios["sinportatil"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["sinportatil"].ToString())) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalDocentesInventarios["contablet"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["contablet"].ToString())) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalDocentesInventarios["sintablet"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["sintablet"].ToString())) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalDocentesInventarios["contableros"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["contableros"].ToString())) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalDocentesInventarios["sintableros"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["sintableros"].ToString())) + "</td>";

        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalconexion) + Convert.ToInt32(totalconexionEst)) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (porcentajeConexionDoc + porcentajeConexionEst) + "%</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalsinconexion) + Convert.ToInt32(totalsinconexionEst)) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (porcentajeSinConexionDoc + porcentajeSinConexionEst) + "%</td>";

        ca += "</tr></table>";



        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string realizarBusquedainventariodequipamiento_(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string ca = "";
        var lb = new LineaBase();

        //normalista superior
        DataRow totalDocentesInventarios = lb.detalleInventariosxUsuario(coddepartamento, codmunicipio, codinstitucion, codsede, "Docentes");
        DataRow totalEstudiantesInventarios = lb.detalleInventariosxUsuario(coddepartamento, codmunicipio, codinstitucion, codsede, "Estudiantes");

        //docente
        var totalconexion = (Convert.ToInt32(totalDocentesInventarios["conpc"].ToString()) + Convert.ToInt32(totalDocentesInventarios["conportatil"].ToString()) + Convert.ToInt32(totalDocentesInventarios["contablet"].ToString()) + Convert.ToInt32(totalDocentesInventarios["contableros"].ToString()));
        var totalsinconexion = (Convert.ToInt32(totalDocentesInventarios["sinpc"].ToString()) + Convert.ToInt32(totalDocentesInventarios["sinportatil"].ToString()) + Convert.ToInt32(totalDocentesInventarios["sintablet"].ToString()) + Convert.ToInt32(totalDocentesInventarios["sintableros"].ToString()));
        //estudiante
        var totalconexionEst = (Convert.ToInt32(totalEstudiantesInventarios["conpc"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["conportatil"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["contablet"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["contableros"].ToString()));
        var totalsinconexionEst = (Convert.ToInt32(totalEstudiantesInventarios["sinpc"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["sinportatil"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["sintablet"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["sintableros"].ToString()));

        var totalTCo = (Convert.ToInt32(totalconexion) + Convert.ToInt32(totalconexionEst));
        var totalTSin = (Convert.ToInt32(totalsinconexion) + Convert.ToInt32(totalsinconexionEst));
        ca += "lleno@<table class='mGridTesoreria'>";
        ca += "<tr>";
        ca += "<th rowspan='2'>Usuarios</th>";
        ca += "<th colspan='2'>No. PC </th>";
        ca += "<th colspan='2'>No. Portátiles </th>";
        ca += "<th colspan='2'>No. Tablet</th>";
        ca += "<th colspan='2'>No. Tableros inteligentes</th>";
        ca += "<th colspan='4'>Total equipamiento </th>";
        ca += "</tr>";
        ca += "<tr>";
        ca += "<th>Con conexión</th>";
        ca += "<th>Sin conexión</th>";
        ca += "<th>Con conexión</th>";
        ca += "<th>Sin conexión</th>";
        ca += "<th>Con conexión</th>";
        ca += "<th>Sin conexión</th>";
        ca += "<th>Con conexión</th>";
        ca += "<th>Sin conexión</th>";

        ca += "<th>Total equipamiento con conexión</th>";
        ca += "<th>Porcentaje equipamiento con conexión</th>";
        ca += "<th>Total equipamiento sin conexión</th>";
        ca += "<th>Porcentaje de equipamiento sin conexión</th>";


        ca += "</tr>";

        ca += "<tr>";
        ca += "<td>Docentes </td>";
        ca += "<td align='right'>" + totalDocentesInventarios["conpc"].ToString() + "</td>";
        ca += "<td align='right'>" + totalDocentesInventarios["sinpc"].ToString() + "</td>";
        ca += "<td align='right'>" + totalDocentesInventarios["conportatil"].ToString() + "</td>";
        ca += "<td align='right'>" + totalDocentesInventarios["sinportatil"].ToString() + "</td>";
        ca += "<td align='right'>" + totalDocentesInventarios["contablet"].ToString() + "</td>";
        ca += "<td align='right'>" + totalDocentesInventarios["sintablet"].ToString() + "</td>";
        ca += "<td align='right'>" + totalDocentesInventarios["contableros"].ToString() + "</td>";
        ca += "<td align='right'>" + totalDocentesInventarios["sintableros"].ToString() + "</td>";

        //--

        ca += "<td align='right'>" + totalconexion + "</td>";

        var porcentajeConexionDoc = Math.Round((((double)totalconexion / (double)totalTCo) * 100), 2);
        ca += "<td align='right'>" + porcentajeConexionDoc + "% </td>";

        var porcentajeSinConexionDoc = Math.Round((((double)totalsinconexion / (double)totalTSin) * 100), 2);
        ca += "<td align='right'>" + totalsinconexion + "</td>";
        ca += "<td align='right'>" + porcentajeSinConexionDoc + "% </td>";
        ca += "</tr>";


        ca += "<tr>";
        ca += "<td>Estudiantes </td>";
        ca += "<td align='right'>" + totalEstudiantesInventarios["conpc"].ToString() + "</td>";
        ca += "<td align='right'>" + totalEstudiantesInventarios["sinpc"].ToString() + "</td>";
        ca += "<td align='right'>" + totalEstudiantesInventarios["conportatil"].ToString() + "</td>";
        ca += "<td align='right'>" + totalEstudiantesInventarios["sinportatil"].ToString() + "</td>";
        ca += "<td align='right'>" + totalEstudiantesInventarios["contablet"].ToString() + "</td>";
        ca += "<td align='right'>" + totalEstudiantesInventarios["sintablet"].ToString() + "</td>";
        ca += "<td align='right'>" + totalEstudiantesInventarios["contableros"].ToString() + "</td>";
        ca += "<td align='right'>" + totalEstudiantesInventarios["sintableros"].ToString() + "</td>";
        //--

        ca += "<td align='right'>" + totalconexionEst + "</td>";

        var porcentajeConexionEst = Math.Round((((double)totalconexionEst / totalTCo) * 100), 2);
        ca += "<td align='right'>" + porcentajeConexionEst + "% </td>";
        ca += "<td align='right'>" + totalsinconexionEst + "</td>";

        var porcentajeSinConexionEst = Math.Round((((double)totalsinconexionEst / totalTSin) * 100), 2);
        ca += "<td align='right'>" + porcentajeSinConexionEst + "% </td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<th>TOTAL</th>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalDocentesInventarios["conpc"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["conpc"].ToString())) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalDocentesInventarios["sinpc"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["sinpc"].ToString())) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalDocentesInventarios["conportatil"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["conportatil"].ToString())) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalDocentesInventarios["sinportatil"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["sinportatil"].ToString())) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalDocentesInventarios["contablet"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["contablet"].ToString())) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalDocentesInventarios["sintablet"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["sintablet"].ToString())) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalDocentesInventarios["contableros"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["contableros"].ToString())) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalDocentesInventarios["sintableros"].ToString()) + Convert.ToInt32(totalEstudiantesInventarios["sintableros"].ToString())) + "</td>";

        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalconexion) + Convert.ToInt32(totalconexionEst)) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (porcentajeConexionDoc + porcentajeConexionEst) + "%</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (Convert.ToInt32(totalsinconexion) + Convert.ToInt32(totalsinconexionEst)) + "</td>";
        ca += "<td align='right' style='font-weight:bold;'>" + (porcentajeSinConexionDoc + porcentajeSinConexionEst) + "%</td>";

        ca += "</tr></table>";


        return ca;
    }


    protected void btnRegresar_Click(object sender, EventArgs e)
    {

        Response.Redirect("evalintermediaGeneral.aspx");

    }

}