using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Web.Services;

public partial class verestraunobitacorados : System.Web.UI.Page
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
    protected void Page_Load(object sender, EventArgs e)
    {
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 
        if (!IsPostBack)
        {
            obtenerGET();
            //DataRow dato = est.buscarCodEstraAsesorxCoordinador(Session["identificacion"].ToString());

            //if (dato != null)
            //{
            //    Session["CodAsesorEstraCoordinador"] = dato["codigo"].ToString();
            //    buscarUsuario();
            //    //gvCargarEvidencias();
            //}

            //if (Session["codrol"].ToString() == "10" || Session["codrol"].ToString() == "11" || Session["codrol"].ToString() == "2" || Session["codrol"].ToString() == "15")//Coordinador / asesor UniMag - CUC
            //{
            //    lblTipoGrupo.Text = "Grupo de investigación";
            //}
            //else if (Session["codrol"].ToString() == "12" || Session["codrol"].ToString() == "13")//Coordinador / asesor FUNTICS
            //{
            //    lblTipoGrupo.Text = "Red Temática";
            //}

        }
    }
    public void obtenerGET()
    {
        Session["e"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["e"]);
        Session["m"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        Session["s"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);

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
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("estramomentos.aspx?m=1");
    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarDepartamentoMagdalena()
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarDepartamentoMagdalena();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "depar@";
            ca += "<option value='0' disabled selected>Seleccione departamento</option>";

            //ca += "@" + datoUsuario["cod"].ToString();
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
                //ca += datos.Rows[i]["codigo"].ToString() + "@" + datos.Rows[i]["nombre"].ToString();
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarMunicipios(string departamento)
    {

        //Funciones fun = new Funciones();

        //fun.convertFechaAño();

        string ca = "";

        Institucion inst = new Institucion();

        DataTable municipios = inst.cargarciudadxDepartamento(departamento);

        if (municipios != null && municipios.Rows.Count > 0)
        {
            ca = "municipio@";
            ca += "<option value='' disabled selected>Seleccione municipio...</option>";
            for (int i = 0; i < municipios.Rows.Count; i++)
            {
                ca += "<option value='" + municipios.Rows[i]["cod"].ToString() + "'>" + municipios.Rows[i]["nombre"].ToString() + "</option>";
            }
        }
        else
        {
            ca = "vacio@<option value='sin' disabled selected>Sin municipios</option>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarInstituciones(string codmunicipio)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarInstitucionxMunicipio(codmunicipio);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "inst@";
            ca += "<option value='0' disabled selected>Seleccione institución</option>";

            //ca += "@" + datoUsuario["cod"].ToString();
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
                //ca += datos.Rows[i]["codigo"].ToString() + "@" + datos.Rows[i]["nombre"].ToString();
            }
        }
        else
        {
            ca = "vacio@<option value='sin' disabled selected>Sin institución</option>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarsedes(string codigoins)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarSedesInstitucion(codigoins);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "sedes@";
            ca += "<option value='' disabled selected>Seleccione sede</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string grupoInvestigacion(string codigosede)
    {

        //Funciones fun = new Funciones();

        //fun.convertFechaAño();

        string ca = "";

        Institucion inst = new Institucion();

        DataTable gruposinvestigacion = inst.cargarGruposInvestigacionSupervision(codigosede);

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
    public static string insertbitacora2(string grupoinvestigacion, string preguntainvestigacion, string resumen)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();

        string ca = "";

        DataRow insert = inst.procinsertbitacora2(grupoinvestigacion, preguntainvestigacion, resumen, HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString());
        if (insert != null)
        {
            ca = "true@";
            ca += insert["codigo"].ToString();
        }
        else
        {
            ca = "Ocurrio un error al insertar datos de Bitacora 2@";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string updatebitacora2(string codigobitacora, string grupoinvestigacion, string preguntainvestigacion, string resumen)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        long update = inst.procupdatebitacora2(codigobitacora, grupoinvestigacion, preguntainvestigacion, resumen);
        if (update != -1)
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al actualizar datos de bitacora@";
        }
        return ca;
    }

    
    [WebMethod(EnableSession = true)]
    public static string loadBitacora2(string codigo)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataRow datosbitacora = inst.procloadBitacora2(codigo);

        if (datosbitacora != null)
        {
            ca += "true@";
            ca += "<tr>";
            ca += datosbitacora["codigo"].ToString()
                + "@" + datosbitacora["departamento"].ToString()
                + "@" + datosbitacora["municipio"].ToString()
                + "@" + datosbitacora["nombregrupo"].ToString()
                + "@" + datosbitacora["preguntainvestigacion"].ToString()
                + "@" + datosbitacora["nombregrupo"].ToString()
                + "@" + datosbitacora["area"].ToString()
                + "@" + datosbitacora["linea"].ToString()
                + "@" + datosbitacora["estrategia"].ToString()
                + "@" + datosbitacora["momento"].ToString()
                + "@" + datosbitacora["sesion"].ToString()
                + "@" + datosbitacora["resumen"].ToString();
            ca += "</tr>";
        }
        else
        {
            ca = "vacio@";
        }

        return ca;
    }

    //preguntas
    
    [WebMethod(EnableSession = true)]
    public static string deletePreguntas(string codigobitacora)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        DataTable preguntas = inst.procloadpreguntas(codigobitacora);

        if (preguntas != null && preguntas.Rows.Count > 0)
        {

            for (int i = 0; i < preguntas.Rows.Count; i++)
            {
                long delete1 = inst.procdeleteRespuestas(preguntas.Rows[i]["codigo"].ToString());
                if (delete1 != -1)
                {
                    long delete = inst.procdeletePreguntas(codigobitacora);
                    if (delete != -1)
                    {
                        ca = "true@";
                    }
                    else
                    {
                        ca = "Ocurrio un error al eliminar preguntas@";
                    }
                }
                else
                {
                    ca = "Ocurrio un error al eliminar preguntas@";
                }

            }
        }else
        {
            ca = "true@";
        }

       
        return ca;
    }
    
    
    [WebMethod(EnableSession = true)]
    public static string insertPreguntas(string codigobitacora, string pregunta, string numpregunta)
    {

        Institucion inst = new Institucion();
        string ca = "";

        DataRow insert = inst.procinsertPreguntas(codigobitacora, pregunta, numpregunta);
        if (insert != null)
        {
            ca = "true@"+ insert["codigo"].ToString();
        }
        else
        {
            ca = "Ocurrio un error al insertar preguntas@";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string insertRespuesta(string codigopregunta, string respuesta, string fuente, string numrespuesta)
    {

        Institucion inst = new Institucion();
        string ca = "";

        DataRow insert = inst.procinsertRespuesta(codigopregunta, respuesta, fuente, numrespuesta);
        if (insert != null)
        {
            ca = "true@" + insert["codigo"].ToString();
        }
        else
        {
            ca = "Ocurrio un error al insertar respuesta@";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadpreguntas(string codigobitacora)
    {

        Institucion inst = new Institucion();
        string ca = "";

        DataTable preguntas = inst.procloadpreguntas(codigobitacora);

        if (preguntas != null && preguntas.Rows.Count > 0)
        {
            ca = "true@";
            for (int i = 0; i < preguntas.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td> "+ preguntas.Rows[i]["numpregunta"].ToString() + ".</td>";
                ca += "<td>";
                ca += "<input type=\"text\" class=\"TextBox\" runat=\"server\"  id=\"pregunta"+ preguntas.Rows[i]["numpregunta"].ToString()+"\" name=\"pregunta" + preguntas.Rows[i]["numpregunta"].ToString() +"\" style=\"width: 350px;\" value=\""+ preguntas.Rows[i]["pregunta"].ToString() + "\"> ";
                ca += "</td>";
                ca += "</tr>";
            }
        }
        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string loadRespuestas(string codigobitacora)
    {

        Institucion inst = new Institucion();
        string ca = "";

        DataTable preguntas = inst.procloadpreguntas(codigobitacora);

        if (preguntas != null && preguntas.Rows.Count > 0)
        {
            ca = "true@";
            for (int i = 0; i < preguntas.Rows.Count; i++)
            {
                DataTable respuestas = inst.procloadRespuestas(preguntas.Rows[i]["codigo"].ToString());

                ca += "<tr >";
                ca += "    <td style='font-weight:bold;'>Pregunta formulada "+ preguntas.Rows[i]["numpregunta"].ToString()+".</td>";
                ca += "</tr>";
                ca += "<tr>";
                ca += "    <td>";
                ca += "        <table border=\"0\">";
                ca += "         <tr  style='color:White;background-color:#507CD1;font-weight:bold;'>";
                ca += "           <td>Respuesta que se encontraron</td>";
                ca += "           <td>Fuente (documento, persona) o lugar donde se encontró</td>";
                ca += "         </tr>";

                if (respuestas != null && respuestas.Rows.Count > 0)
                {
                    for (int j = 0; j < respuestas.Rows.Count; j++)
                    {
                        ca += "<tr>";
                        ca += "    <td><input type=\"text\" class=\"TextBox\" id =\"p" + preguntas.Rows[i]["numpregunta"].ToString() + "respuesta" + respuestas.Rows[j]["numrespuesta"].ToString() + "\" name =\"p" + preguntas.Rows[i]["numpregunta"].ToString() + "respuesta" + respuestas.Rows[j]["numrespuesta"].ToString() + "\" style=\"width: 98%;\" value=\"" + respuestas.Rows[j]["respuesta"].ToString()  + "\"></td>";
                        ca += "    <td><input type=\"text\" class=\"TextBox\" id=\"p" + preguntas.Rows[i]["numpregunta"].ToString() + "fuente" + respuestas.Rows[j]["numrespuesta"].ToString() + "\" name =\"p" + preguntas.Rows[i]["numpregunta"].ToString() + "fuente" + respuestas.Rows[j]["numrespuesta"].ToString() + "\" style=\"width: 98%;\" value=\"" + respuestas.Rows[j]["fuente"].ToString() + "\"></td>";
                        ca += "</tr>";
                    }
                }
                ca += " </table>";
                ca += "    </td>";
                ca += "</tr>";
                ca += "@";
            }
        }
        return ca;
    }
    /*2016-10-24 JONNY PACHECO metodo para  listar las bitacoras*/
    [WebMethod(EnableSession = true)]
    public static string listarBitacoraDos(string codasesorcoordinador)
    {
        Institucion inst = new Institucion();

        string ca = "";

        DataTable datos = inst.listarBitacoraDos(codasesorcoordinador);
        if (datos != null && datos.Rows.Count > 0)
        {
           
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["nombredepartamento"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombremunicipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombreinstitucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombresede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["preguntainvestigacion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombregrupo"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["fechadiligenciamiento"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["momento"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["sesion"].ToString() + "</td>";
                ca += "<td style='padding:5px;' ><a class='btn btn-success' onclick=\"$('#table').hide(), $('#form').fadeIn(500), cargarBitacora2(" + datos.Rows[i]["codigo"].ToString() + "), loadSelectBitacoraDos(" + datos.Rows[i]["codProyecto"].ToString() + ")\">Ver</a></td>";
                ca += "</tr>";
            }
        }
        else
        {
            ca += "<tr><td colspan='7'>No se encontraron memorias registradas.</td></tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadSelectBitacoraDos(string codProyecto)
    {
        string ca = "";
        Estrategias estra = new Estrategias();
        

        DataRow dato = estra.loadSelectBitacoraDos(codProyecto);
        if (dato != null)
        {
            ca += "loadSelect@";
            ca += "<option value='" + dato["codigodepartamento"].ToString() + "'>" + dato["nombredepartamento"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigomunicipio"].ToString() + "'>" + dato["nombremunicipio"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigoinstitucion"].ToString() + "'>" + dato["nombreinstitucion"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigosede"].ToString() + "'>" + dato["nombresede"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigogrupoinvestigacion"].ToString() + "'>" + dato["nombregrupoinvestigacion"].ToString() + "</option>";
           
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargaranios(string codProyecto)
    {
        string ca = "";
        Institucion inst = new Institucion();
        Estudiantes estu = new Estudiantes();

        DataTable estudiantes = estu.cargarEstudiantesxGrupoInvestigacion(codProyecto);
        if (estudiantes != null && estudiantes.Rows.Count > 0)
        {
            ca += "<option value='" + estudiantes.Rows[0]["codanio"].ToString() + "'>" + estudiantes.Rows[0]["anio"].ToString() + "</option>";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarasesores()
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataTable asesores = estra.listarAsesoresSeguimiento("1");

        if (asesores != null && asesores.Rows.Count > 0)
        {
            ca += "<option value='0' selected disabled>Seleccione asesor...</option>";
            for (int i = 0; i < asesores.Rows.Count; i++)
            {
                ca += "<option value='" + asesores.Rows[i]["codigo"].ToString() + "'>" + asesores.Rows[i]["asesor"].ToString().ToUpper() + "</option>";
            }
        }

        return ca;
    }
}