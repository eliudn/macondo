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

public partial class estra4memoriasesion1docasistentesdist : System.Web.UI.Page
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
                        titulo.Text = "Conformación de la comunidad de estudiantes que se gozan la ciencia";
                        subtitulo.Text = "Maestros y maestras que asisten  a la sesión ";
                        //descripcion.Text = "S004: Memorias 2016";
                    }
                }
            }
        }
        //if (Session["m"].ToString() != null)
        //    {
        //        if (Session["m"].ToString() == "3")
        //        {
        //            if (Session["s"].ToString() != null)
        //            {
        //                if (Session["s"].ToString() == "2")
        //                {
        //                    titulo.Text = "Sesión de formación  No. 2. Contexto mundial de la educación";
        //                    subtitulo.Text = "Sesiones de formación evaluadas y subidas a la plataforma de Ciclón";
        //                    descripcion.Text = "G002: Formato de evaluación de eventos de formación";
        //                }
        //            }
        //        }

        //    }
        //     if (Session["m"].ToString() != null)
        //    {
        //        if (Session["m"].ToString() == "4")
        //        {
        //            if (Session["s"].ToString() != null)
        //            {
        //                if (Session["s"].ToString() == "3")
        //                {
        //                    titulo.Text = "Recorrido de las trayectorias de indagación. ";
        //                    subtitulo.Text = "Sesiones de formación evaluadas y subidas a la plataforma de Ciclón";
        //                    descripcion.Text = "G002: Formato de evaluación de eventos de formación";
        //                }
        //            }
        //        }

        //    }
            
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
    public static string estra4memoriassesio1_docente()
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable estra4memoriasesion1 = est.est_estra2instrumento_s004_redt_2016_docentesDistinct("", "", "", "", "1");


        if (estra4memoriasesion1 != null && estra4memoriasesion1.Rows.Count > 0)
        {
            int total = estra4memoriasesion1.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < estra4memoriasesion1.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + estra4memoriasesion1.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + estra4memoriasesion1.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + estra4memoriasesion1.Rows[i]["dane"].ToString() + " - " + estra4memoriasesion1.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + estra4memoriasesion1.Rows[i]["danesede"].ToString() + " - " + estra4memoriasesion1.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + estra4memoriasesion1.Rows[i]["identificacion"].ToString() + " - " + estra4memoriasesion1.Rows[i]["apellido"].ToString() + " " + estra4memoriasesion1.Rows[i]["nombre"].ToString() + "</td>";
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
    public static string realizarBusquedaestra4memoriasesion1_docente(string coddepartamento, string codmuncipio, string codinstitucion, string codsede)
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable estra4memoriasesion1 = est.est_estra2instrumento_s004_redt_2016_docentesDistinct(coddepartamento, codmuncipio, codinstitucion, codsede, HttpContext.Current.Session["s"].ToString());

        if (estra4memoriasesion1 != null && estra4memoriasesion1.Rows.Count > 0)
        {
            int total = estra4memoriasesion1.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < estra4memoriasesion1.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + estra4memoriasesion1.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + estra4memoriasesion1.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + estra4memoriasesion1.Rows[i]["dane"].ToString() + " - " + estra4memoriasesion1.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + estra4memoriasesion1.Rows[i]["danesede"].ToString() + " - " + estra4memoriasesion1.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + estra4memoriasesion1.Rows[i]["identificacion"].ToString() + " - " + estra4memoriasesion1.Rows[i]["apellido"].ToString() + " " + estra4memoriasesion1.Rows[i]["nombre"].ToString() + "</td>";
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
                         Response.Redirect("estra4memorias004_2016.aspx?m=1&s=1&e=4");
                     }
                 }
             }
         }
         //if (Session["m"].ToString() != null)
         //{
         //    if (Session["m"].ToString() == "3")
         //    {
         //        if (Session["s"].ToString() != null)
         //        {
         //            if (Session["s"].ToString() == "2")
         //            {
         //                Response.Redirect("estra2sesionformacion2.aspx?m=3&e=2");
         //            }
         //        }
         //    }

         //}
         //if (Session["m"].ToString() != null)
         //{
         //    if (Session["m"].ToString() == "4")
         //    {
         //        if (Session["s"].ToString() != null)
         //        {
         //            if (Session["s"].ToString() == "3")
         //            {
         //                Response.Redirect("estra2recorridotrayectorias.aspx?m=4&e=2");
         //            }
         //        }
         //    }

         //}

     }
    
}