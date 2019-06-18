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

public partial class detallesdesarrollo : System.Web.UI.Page
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
        Session["fechaini"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["fechaini"]);
        Session["fechafin"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["fechafin"]);
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
    public static string totalSedesGrupoInvestigacion()
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable totalSedesGrupoInvestigacion = est.totalSedesGrupoInvestigacion("", "", "");


        if (totalSedesGrupoInvestigacion != null && totalSedesGrupoInvestigacion.Rows.Count > 0)
        {
            int total = totalSedesGrupoInvestigacion.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < totalSedesGrupoInvestigacion.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + totalSedesGrupoInvestigacion.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + totalSedesGrupoInvestigacion.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + totalSedesGrupoInvestigacion.Rows[i]["dane"].ToString() + " - " + totalSedesGrupoInvestigacion.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + totalSedesGrupoInvestigacion.Rows[i]["nombre"].ToString() + " </td>";
                ca += "</tr>";
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td colspan=\"5\" style=\"text-align:center;\">Sin resultados</td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "</tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string realizarBusquedaTotalSedesGrupoInvestigacion(string coddepartamento, string codmuncipio, string codinstitucion)
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable totalSedesGrupoInvestigacion = est.totalSedesGrupoInvestigacion(coddepartamento, codmuncipio, codinstitucion);


        if (totalSedesGrupoInvestigacion != null && totalSedesGrupoInvestigacion.Rows.Count > 0)
        {
            int total = totalSedesGrupoInvestigacion.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < totalSedesGrupoInvestigacion.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + totalSedesGrupoInvestigacion.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + totalSedesGrupoInvestigacion.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + totalSedesGrupoInvestigacion.Rows[i]["dane"].ToString() + " - " + totalSedesGrupoInvestigacion.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + totalSedesGrupoInvestigacion.Rows[i]["nombre"].ToString() + " </td>";
                ca += "</tr>";
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td colspan=\"5\" style=\"text-align:center;\">Sin resultados</td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "</tr>";
        }

        return ca;
    }
    

    [WebMethod(EnableSession = true)]
    public static string totalGrupoInvestigacion(string linea)
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable totalGrupoInvestigacion = null;

        if (linea != null && linea != "")
        {
            totalGrupoInvestigacion = est.totalGrupoInvestigacionSeg("", "", "", "", linea);
        }
        else
        {
            totalGrupoInvestigacion = est.totalGrupoInvestigacion("", "", "", "");
        }
        


        if (totalGrupoInvestigacion != null && totalGrupoInvestigacion.Rows.Count > 0)
        {
            int total = totalGrupoInvestigacion.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < totalGrupoInvestigacion.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + totalGrupoInvestigacion.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + totalGrupoInvestigacion.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + totalGrupoInvestigacion.Rows[i]["dane"].ToString() + " - " + totalGrupoInvestigacion.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + totalGrupoInvestigacion.Rows[i]["danesede"].ToString() + " - " + totalGrupoInvestigacion.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + totalGrupoInvestigacion.Rows[i]["nombregrupo"].ToString() + " </td>";
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
    public static string realizarBusquedatotalGrupoInvestigacion(string coddepartamento, string codmuncipio, string codinstitucion, string codsede, string linea)
    {
        string ca = "";
        Estrategias est = new Estrategias();
        
         DataTable totalGrupoInvestigacion = null;

        if (linea != null && linea != "")
        {
             totalGrupoInvestigacion = est.totalGrupoInvestigacionSeg(coddepartamento, codmuncipio, codinstitucion, codsede, linea);
        }
        else
        {
             totalGrupoInvestigacion = est.totalGrupoInvestigacion(coddepartamento, codmuncipio, codinstitucion, codsede);
        }

        


        if (totalGrupoInvestigacion != null && totalGrupoInvestigacion.Rows.Count > 0)
        {
            int total = totalGrupoInvestigacion.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < totalGrupoInvestigacion.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td>" + totalGrupoInvestigacion.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + totalGrupoInvestigacion.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + totalGrupoInvestigacion.Rows[i]["dane"].ToString() + " - " + totalGrupoInvestigacion.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + totalGrupoInvestigacion.Rows[i]["danesede"].ToString() + " - " + totalGrupoInvestigacion.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + totalGrupoInvestigacion.Rows[i]["nombregrupo"].ToString() + " </td>";
                ca += "</tr>";
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td style=\"text-align:center;\">Sin resultados</td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "</tr>";
        }

        return ca;
    }
    
    
    
    [WebMethod(EnableSession = true)]
    public static string totalEstudiantesMatriculadosGP()
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable totalEstudiantesMatriculadosGP = est.totalEstudiantesMatriculadosGP("","","","","");

        if (totalEstudiantesMatriculadosGP != null && totalEstudiantesMatriculadosGP.Rows.Count > 0)
        {
            int total = totalEstudiantesMatriculadosGP.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < totalEstudiantesMatriculadosGP.Rows.Count; i++)
            {
                //var f = ;
                try {
                    ca += "<tr>";
                    ca += "<td><b>" + (i + 1) + ".</b> </td>";
                    ca += "<td>" + totalEstudiantesMatriculadosGP.Rows[i]["nombredepartamento"].ToString() + " </td>";
                    ca += "<td>" + totalEstudiantesMatriculadosGP.Rows[i]["nombremunicipio"].ToString() + " </td>";
                    ca += "<td>" + totalEstudiantesMatriculadosGP.Rows[i]["dane"].ToString() + " - " + totalEstudiantesMatriculadosGP.Rows[i]["nombreins"].ToString() + " </td>";
                    ca += "<td>" + totalEstudiantesMatriculadosGP.Rows[i]["danesede"].ToString() + " - " + totalEstudiantesMatriculadosGP.Rows[i]["nombresede"].ToString() + " </td>";
                    ca += "<td>" + totalEstudiantesMatriculadosGP.Rows[i]["nombregrupo"].ToString() + " </td>";
                    ca += "<td>" + totalEstudiantesMatriculadosGP.Rows[i]["nombre"].ToString() + " " + totalEstudiantesMatriculadosGP.Rows[i]["apellido"].ToString() + " </td>";
                    ca += "</tr>";
                }
                catch { }
                
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td style=\"text-align:center;\">Sin resultados</td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "</tr>";
        }

        return ca;
    }
    [WebMethod(EnableSession = true)]
    public static string realizarBusquedatotalEstudiantesMatriculadosGP(string coddepartamento, string codmuncipio, string codinstitucion, string codsede, string codgrupoinvestigacion)
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable totalEstudiantesMatriculadosGP = est.totalEstudiantesMatriculadosGP( coddepartamento, codmuncipio, codinstitucion, codsede, codgrupoinvestigacion);

        if (totalEstudiantesMatriculadosGP != null && totalEstudiantesMatriculadosGP.Rows.Count > 0)
        {
            int total = totalEstudiantesMatriculadosGP.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < totalEstudiantesMatriculadosGP.Rows.Count; i++)
            {
                //var f = ;
                try
                {
                    ca += "<tr>";
                    ca += "<td><b>" + (i + 1) + ".</b> </td>";
                    ca += "<td>" + totalEstudiantesMatriculadosGP.Rows[i]["nombredepartamento"].ToString() + " </td>";
                    ca += "<td>" + totalEstudiantesMatriculadosGP.Rows[i]["nombremunicipio"].ToString() + " </td>";
                    ca += "<td>" + totalEstudiantesMatriculadosGP.Rows[i]["dane"].ToString() + " - " + totalEstudiantesMatriculadosGP.Rows[i]["nombreins"].ToString() + " </td>";
                    ca += "<td>" + totalEstudiantesMatriculadosGP.Rows[i]["danesede"].ToString() + " - " + totalEstudiantesMatriculadosGP.Rows[i]["nombresede"].ToString() + " </td>";
                    ca += "<td>" + totalEstudiantesMatriculadosGP.Rows[i]["nombregrupo"].ToString() + " </td>";
                    ca += "<td>" + totalEstudiantesMatriculadosGP.Rows[i]["nombre"].ToString() + " " + totalEstudiantesMatriculadosGP.Rows[i]["apellido"].ToString() + " </td>";
                    ca += "</tr>";
                }
                catch { }

            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td style=\"text-align:center;\">Sin resultados</td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "</tr>";
        }

        return ca;
    }
    

    [WebMethod(EnableSession = true)]
    public static string totalDocenesMatriculadosGP()
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable totalDocenesMatriculadosGP = est.totalDocenesMatriculadosGP("","","","","");

        if (totalDocenesMatriculadosGP != null && totalDocenesMatriculadosGP.Rows.Count > 0)
        {
            int total = totalDocenesMatriculadosGP.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < totalDocenesMatriculadosGP.Rows.Count; i++)
            {
                //var f = ;
                ca += "<tr>";
                ca += "<td><b>" + (i+1) + ".</b> </td>";
                ca += "<td>" + totalDocenesMatriculadosGP.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + totalDocenesMatriculadosGP.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + totalDocenesMatriculadosGP.Rows[i]["dane"].ToString() + " - " + totalDocenesMatriculadosGP.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + totalDocenesMatriculadosGP.Rows[i]["danesede"].ToString() + " - " + totalDocenesMatriculadosGP.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + totalDocenesMatriculadosGP.Rows[i]["nombregrupo"].ToString() + " </td>";
                ca += "<td>" + totalDocenesMatriculadosGP.Rows[i]["nombre"].ToString() + " " + totalDocenesMatriculadosGP.Rows[i]["apellido"].ToString() + " </td>";
                ca += "</tr>";
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td style=\"text-align:center;\">Sin resultados</td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "</tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string realizarBusquedatotalDocenesMatriculadosGP(string coddepartamento, string codmuncipio, string codinstitucion, string codsede, string codgrupoinvestigacion)
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable totalDocenesMatriculadosGP = est.totalDocenesMatriculadosGP(coddepartamento, codmuncipio, codinstitucion, codsede, codgrupoinvestigacion);

        if (totalDocenesMatriculadosGP != null && totalDocenesMatriculadosGP.Rows.Count > 0)
        {
            int total = totalDocenesMatriculadosGP.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < totalDocenesMatriculadosGP.Rows.Count; i++)
            {
                //var f = ;
                ca += "<tr>";
                ca += "<td><b>" + (i + 1) + ".</b> </td>";
                ca += "<td>" + totalDocenesMatriculadosGP.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + totalDocenesMatriculadosGP.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + totalDocenesMatriculadosGP.Rows[i]["dane"].ToString() + " - " + totalDocenesMatriculadosGP.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + totalDocenesMatriculadosGP.Rows[i]["danesede"].ToString() + " - " + totalDocenesMatriculadosGP.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + totalDocenesMatriculadosGP.Rows[i]["nombregrupo"].ToString() + " </td>";
                ca += "<td>" + totalDocenesMatriculadosGP.Rows[i]["nombre"].ToString() + " " + totalDocenesMatriculadosGP.Rows[i]["apellido"].ToString() + " </td>";
                ca += "</tr>";
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td style=\"text-align:center;\">Sin resultados</td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "</tr>";
        }

        return ca;
    }

    //bitacora 2
    [WebMethod(EnableSession = true)]
    public static string totalSedesGPTenganPreguntas()
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable totalSedesGPTenganPreguntas = est.totalSedesGPTenganPreguntas("","","");

        if (totalSedesGPTenganPreguntas != null && totalSedesGPTenganPreguntas.Rows.Count > 0)
        {
            int total = totalSedesGPTenganPreguntas.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < totalSedesGPTenganPreguntas.Rows.Count; i++)
            {
                //var f = ;
                ca += "<tr>";
                ca += "<td><b>" + (i + 1) + ".</b> </td>";
                ca += "<td>" + totalSedesGPTenganPreguntas.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + totalSedesGPTenganPreguntas.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + totalSedesGPTenganPreguntas.Rows[i]["dane"].ToString() + " - " + totalSedesGPTenganPreguntas.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + totalSedesGPTenganPreguntas.Rows[i]["nombresede"].ToString() +" </td>";
                ca += "</tr>";
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td style=\"text-align:center;\">Sin resultados</td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "</tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string realizarBusquedatotalSedesGPTenganPreguntas(string coddepartamento, string codmuncipio, string codinstitucion)
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable totalSedesGPTenganPreguntas = est.totalSedesGPTenganPreguntas(coddepartamento, codmuncipio, codinstitucion);

        if (totalSedesGPTenganPreguntas != null && totalSedesGPTenganPreguntas.Rows.Count > 0)
        {
            int total = totalSedesGPTenganPreguntas.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < totalSedesGPTenganPreguntas.Rows.Count; i++)
            {
                //var f = ;
                ca += "<tr>";
                ca += "<td><b>" + (i + 1) + ".</b> </td>";
                ca += "<td>" + totalSedesGPTenganPreguntas.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + totalSedesGPTenganPreguntas.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + totalSedesGPTenganPreguntas.Rows[i]["dane"].ToString() + " - " + totalSedesGPTenganPreguntas.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + totalSedesGPTenganPreguntas.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "</tr>";
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td style=\"text-align:center;\">Sin resultados</td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "</tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string totalGPHicieronPreguntas()
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable totalGPHicieronPreguntas = est.totalGPHicieronPreguntas("","","","");

        if (totalGPHicieronPreguntas != null && totalGPHicieronPreguntas.Rows.Count > 0)
        {
            int total = totalGPHicieronPreguntas.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < totalGPHicieronPreguntas.Rows.Count; i++)
            {
                //var f = ;
                ca += "<tr>";
                ca += "<td><b>" + (i + 1) + ".</b> </td>";
                ca += "<td>" + totalGPHicieronPreguntas.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + totalGPHicieronPreguntas.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + totalGPHicieronPreguntas.Rows[i]["dane"].ToString() + " - " + totalGPHicieronPreguntas.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + totalGPHicieronPreguntas.Rows[i]["danesede"].ToString() + " - " + totalGPHicieronPreguntas.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + totalGPHicieronPreguntas.Rows[i]["nombregrupo"].ToString() + " </td>";
                ca += "</tr>";
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td style=\"text-align:center;\">Sin resultados</td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "</tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string realizarBusquedatotalGPHicieronPreguntas(string coddepartamento, string codmuncipio, string codinstitucion, string codsede)
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable totalGPHicieronPreguntas = est.totalGPHicieronPreguntas(coddepartamento, codmuncipio, codinstitucion, codsede);

        if (totalGPHicieronPreguntas != null && totalGPHicieronPreguntas.Rows.Count > 0)
        {
            int total = totalGPHicieronPreguntas.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < totalGPHicieronPreguntas.Rows.Count; i++)
            {
                //var f = ;
                ca += "<tr>";
                ca += "<td><b>" + (i + 1) + ".</b> </td>";
                ca += "<td>" + totalGPHicieronPreguntas.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + totalGPHicieronPreguntas.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + totalGPHicieronPreguntas.Rows[i]["dane"].ToString() + " - " + totalGPHicieronPreguntas.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + totalGPHicieronPreguntas.Rows[i]["danesede"].ToString() + " - " + totalGPHicieronPreguntas.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + totalGPHicieronPreguntas.Rows[i]["nombregrupo"].ToString() + " </td>";
                ca += "</tr>";
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td style=\"text-align:center;\">Sin resultados</td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "</tr>";
        }

        return ca;
    }

    //Bitacora 3
    [WebMethod(EnableSession = true)]
    public static string totalSedesGPTenganPreguntasB3()
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable totalSedesGPTenganPreguntasB3 = est.totalSedesGPTenganPreguntasB3("","","");

        if (totalSedesGPTenganPreguntasB3 != null && totalSedesGPTenganPreguntasB3.Rows.Count > 0)
        {
            int total = totalSedesGPTenganPreguntasB3.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < totalSedesGPTenganPreguntasB3.Rows.Count; i++)
            {
                //var f = ;
                ca += "<tr>";
                ca += "<td><b>" + (i + 1) + ".</b> </td>";
                ca += "<td>" + totalSedesGPTenganPreguntasB3.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + totalSedesGPTenganPreguntasB3.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + totalSedesGPTenganPreguntasB3.Rows[i]["dane"].ToString() + " - " + totalSedesGPTenganPreguntasB3.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + totalSedesGPTenganPreguntasB3.Rows[i]["danesede"].ToString() + " - " + totalSedesGPTenganPreguntasB3.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "</tr>";
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td style=\"text-align:center;\">Sin resultados</td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "</tr>";
        }

        return ca;
    }


    //Bitacora 3
    [WebMethod(EnableSession = true)]
    public static string realizarBusquedatotalSedesGPTenganPreguntasB3(string coddepartamento, string codmuncipio, string codinstitucion)
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataTable totalSedesGPTenganPreguntasB3 = est.totalSedesGPTenganPreguntasB3(coddepartamento, codmuncipio, codinstitucion);

        if (totalSedesGPTenganPreguntasB3 != null && totalSedesGPTenganPreguntasB3.Rows.Count > 0)
        {
            int total = totalSedesGPTenganPreguntasB3.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < totalSedesGPTenganPreguntasB3.Rows.Count; i++)
            {
                //var f = ;
                ca += "<tr>";
                ca += "<td><b>" + (i + 1) + ".</b> </td>";
                ca += "<td>" + totalSedesGPTenganPreguntasB3.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + totalSedesGPTenganPreguntasB3.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + totalSedesGPTenganPreguntasB3.Rows[i]["dane"].ToString() + " - " + totalSedesGPTenganPreguntasB3.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + totalSedesGPTenganPreguntasB3.Rows[i]["danesede"].ToString() + " - " + totalSedesGPTenganPreguntasB3.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "</tr>";
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td style=\"text-align:center;\">Sin resultados</td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "</tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string totalGPHicieronPreguntasB3()
    {

        string ca = "";
        Estrategias est = new Estrategias();

        DataTable totalGPHicieronPreguntasB3 = est.totalGPHicieronPreguntasB3("","","","");

        if (totalGPHicieronPreguntasB3 != null && totalGPHicieronPreguntasB3.Rows.Count > 0)
        {
            int total = totalGPHicieronPreguntasB3.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < totalGPHicieronPreguntasB3.Rows.Count; i++)
            {
                //var f = ;
                ca += "<tr>";
                ca += "<td><b>" + (i + 1) + ".</b> </td>";
                ca += "<td>" + totalGPHicieronPreguntasB3.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + totalGPHicieronPreguntasB3.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + totalGPHicieronPreguntasB3.Rows[i]["dane"].ToString() + " - " + totalGPHicieronPreguntasB3.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + totalGPHicieronPreguntasB3.Rows[i]["danesede"].ToString() + " - " + totalGPHicieronPreguntasB3.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + totalGPHicieronPreguntasB3.Rows[i]["nombregrupo"].ToString() + " </td>";
                ca += "</tr>";
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td style=\"text-align:center;\">Sin resultados</td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "</tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string realizarBusquedatotalGPHicieronPreguntasB3(string coddepartamento, string codmuncipio, string codinstitucion, string codsede)
    {

        string ca = "";
        Estrategias est = new Estrategias();

        DataTable totalGPHicieronPreguntasB3 = est.totalGPHicieronPreguntasB3(coddepartamento, codmuncipio, codinstitucion, codsede);

        if (totalGPHicieronPreguntasB3 != null && totalGPHicieronPreguntasB3.Rows.Count > 0)
        {
            int total = totalGPHicieronPreguntasB3.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < totalGPHicieronPreguntasB3.Rows.Count; i++)
            {
                //var f = ;
                ca += "<tr>";
                ca += "<td><b>" + (i + 1) + ".</b> </td>";
                ca += "<td>" + totalGPHicieronPreguntasB3.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + totalGPHicieronPreguntasB3.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + totalGPHicieronPreguntasB3.Rows[i]["dane"].ToString() + " - " + totalGPHicieronPreguntasB3.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + totalGPHicieronPreguntasB3.Rows[i]["danesede"].ToString() + " - " + totalGPHicieronPreguntasB3.Rows[i]["nombresede"].ToString() + " </td>";
                ca += "<td>" + totalGPHicieronPreguntasB3.Rows[i]["nombregrupo"].ToString() + " </td>";
                ca += "</tr>";
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td style=\"text-align:center;\">Sin resultados</td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "</tr>";
        }

        return ca;
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        //if (lblSeguimiento.Text == "true")
        //{
        //    Response.Redirect("menusegestrategia.aspx");
        //}
        //else
        //{
        //    Response.Redirect("informedesarrollo.aspx");
        //}
        
    }
    
}