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

public partial class estra2asistentesformacion : System.Web.UI.Page
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
        Session["m"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        Session["s"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);

        if (Session["m"].ToString() != null)
        {
            if (Session["m"].ToString() == "1")
            {
                if (Session["s"].ToString() != null)
                {
                    if (Session["s"].ToString() == "1")
                    {
                        titulo.Text = "Convocatoria y acompañamiento para la conformación de los grupos";
                        subtitulo.Text = "Asistentes a la sesión de formación No. 1 ";
                        descripcion.Text = "G001: Asistencia a eventos <br/>   S002: Registro de asesoría, acompañamiento y formación.";
                    }
                }
            }
        }
        if (Session["m"].ToString() != null)
            {
                if (Session["m"].ToString() == "3")
                {
                    if (Session["s"].ToString() != null)
                    {
                        if (Session["s"].ToString() == "2")
                        {
                            titulo.Text = "Sesión de formación  No. 2. Contexto mundial de la educación";
                            subtitulo.Text = "Asistentes a la sesión de formación No. 2 ";
                            descripcion.Text = "G001: Asistencia a eventos <br/>  S002: Registro de asesoría, acompañamiento y formación.";
                        }
                    }
                }

            }
            if (Session["m"].ToString() != null)
            {
                if (Session["m"].ToString() != "4")
                {
                    if (Session["s"].ToString() != null)
                    {
                        if (Session["s"].ToString() != "3")
                        {
                            titulo.Text = "Recorrido de las trayectorias de indagación. ";
                            subtitulo.Text = "Asistentes a la sesión de formación No. 3 ";
                            descripcion.Text = "G001: Asistencia a eventos <br/>  S002: Registro de asesoría, acompañamiento y formación.";
                        }
                    }
                }
            }
            
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


    [WebMethod(EnableSession = true)]
    public static string estra2asistentesformacion_()
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable estra2asistentesformacion = est.estra2AsistentesFormacion("", "", "", "", HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString());


        if (estra2asistentesformacion != null && estra2asistentesformacion.Rows.Count > 0)
        {
            int total = estra2asistentesformacion.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < estra2asistentesformacion.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + estra2asistentesformacion.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + estra2asistentesformacion.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + estra2asistentesformacion.Rows[i]["dane"].ToString() + " - " + estra2asistentesformacion.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + estra2asistentesformacion.Rows[i]["danesede"].ToString() + " - " + estra2asistentesformacion.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + estra2asistentesformacion.Rows[i]["nombrearchivo"].ToString() + " </td>";
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
    public static string realizarBusquedaestra2asistentesformacion_(string coddepartamento, string codmuncipio, string codinstitucion, string codsede)
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable estra2asistentesformacion = est.estra2AsistentesFormacion(coddepartamento, codmuncipio, codinstitucion, codsede, HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString());

        if (estra2asistentesformacion != null && estra2asistentesformacion.Rows.Count > 0)
        {
            int total = estra2asistentesformacion.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < estra2asistentesformacion.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + estra2asistentesformacion.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + estra2asistentesformacion.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + estra2asistentesformacion.Rows[i]["dane"].ToString() + " - " + estra2asistentesformacion.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + estra2asistentesformacion.Rows[i]["danesede"].ToString() + " - " + estra2asistentesformacion.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + estra2asistentesformacion.Rows[i]["nombrearchivo"].ToString() + " </td>";
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
         if (Session["m"].ToString() != null)
         {
             if (Session["m"].ToString() == "1")
             {
                 if (Session["s"].ToString() != null)
                 {
                     if (Session["s"].ToString() == "1")
                     {
                         Response.Redirect("estra2convocatoriaacompanamiento.aspx?m=1&e=2");
                     }
                 }
             }
         }
         if (Session["m"].ToString() != null)
         {
             if (Session["m"].ToString() == "3")
             {
                 if (Session["s"].ToString() != null)
                 {
                     if (Session["s"].ToString() == "2")
                     {
                         Response.Redirect("estra2sesionformacion2.aspx?m=3&e=2");
                     }
                 }
             }

         }
         if (Session["m"].ToString() != null)
         {
             if (Session["m"].ToString() == "4")
             {
                 if (Session["s"].ToString() != null)
                 {
                     if (Session["s"].ToString() == "3")
                     {
                         Response.Redirect("estra2recorridotrayectorias.aspx?m=4&e=2");
                     }
                 }
             }

         }

     }
        
    
}