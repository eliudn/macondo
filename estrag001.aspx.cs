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
using System.Web.Script.Serialization;
using System.Web.Services;

public partial class estrag001 : System.Web.UI.Page
{
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
            lblEncabezado.Text = encabezado();
            if (Session["identificacion"] != null)
            {
                Estrategias estra = new Estrategias();
                DataRow dato = estra.buscarCodEstraAsesorxCoordinador(Session["identificacion"].ToString());

                if (dato != null)
                {
                    Session["CodEstraAsesorCoordinador"] = dato["codigo"].ToString();

                }
            }
        }
    }

    private string encabezado()
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataRow sede = inst.buscarSedexInstitucion(Session["codsede"].ToString());

        if(sede != null)
        {
            ca = "<b>Institución: </b>" + sede["nominstitucion"].ToString();
            ca += "<br /><b>Sede: </b>" + sede["nomsede"].ToString();
        }

        return ca;
    }
    public void obtenerGET()
    {
        //Session["m"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        //Session["s"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
        //Session["a"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["a"]);
        Session["codinstrumento"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["cod"]);
        Session["codsede"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["codsede"]);


    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("estras004Sedes.aspx?e=" + Session["e"].ToString() + "&m=" + Session["m"].ToString() + "&s=" + Session["s"].ToString() + "&j=" + Session["j"].ToString());
    }

    [WebMethod(EnableSession = true)]
    public static string cargarAnios()
    {
        string ca = "";
        Institucion inst = new Institucion();
        DataTable datos = inst.cargarAnios();
        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<option value='0' disabled selected>Seleccione año</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }
        return ca;
    }

    [WebMethod(EnableSession=true)]
    public static string cargarDepartamento()
    {
        string ca = "";
        Institucion inst = new Institucion();
        DataTable datos = inst.cargarDepartamentoMagdalena();
        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<option value='0' disabled selected>Seleccione departamento</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarMunicipio(string codDepartamento)
    {
        string ca = "";
        Institucion inst = new Institucion();
        DataTable datos = inst.cargarciudadxDepartamento(codDepartamento);
        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<option value='0' disabled selected>Seleccione municipio</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarInstitucionesxMunicipio(string codMunicipio)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarInstitucionxMunicipio(codMunicipio);
        if (datos != null && datos.Rows.Count > 0)
        {
            //ca = "inst@";
            ca += "<option value='0' disabled selected>Seleccione institucion</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }

        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarSedesInstitucion(string codInstitucion)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarSedesInstitucion(codInstitucion);
        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<option value='0' disabled selected>Seleccione sede</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]

    
    //public static string cargarDocentesxSede(string codSede)
    public static string cargarDocentesxSede(string codanio)
    {
        string ca = "";
        int no = 0;


        Docentes inst = new Docentes();
        Funciones fun = new Funciones();
        //DataRow anio = inst.buscarCodAnioActual(fun.getAñoActual());
        DataRow anio = inst.buscarCodAnioActualxCodigo(codanio);

        if(anio != null)
        {
            // DataTable datos = inst.cargarDocentesxSede(codSede);
            DataTable datos = inst.cargarDocentesxSede(HttpContext.Current.Session["codsede"].ToString(), anio["codigo"].ToString());
            if (datos != null && datos.Rows.Count > 0)
            {
                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    no += 1;
                    ca += "<tr>";
                    ca += "<td>" + no + "</td>";
                    ca += "<td>" + datos.Rows[i]["identificacion"].ToString() + "</td>";
                    ca += "<td>" + datos.Rows[i]["nomdocente"].ToString() + "</td>";
                    ca += "<td><input type='checkbox' name='asistencia" + no + "' checked value='" + datos.Rows[i]["codgradodocente"].ToString() + "'/></td>";
                    ca += "</tr>";
                    //ca += "<option value='" + datos.Rows[i]["codgradodocente"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
                }
            }
        }


        

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarRedTematica(string codSede)
    {
        string ca = "";

        //Institucion inst = new Institucion();
        Estrategias estra = new Estrategias();

        //DataTable datos = inst.cargarSedesInstitucion(codInstitucion);
        DataTable datos = estra.cargarRedTematicaDocente(codSede);
        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<option value='0' disabled selected>Seleccione red tematica</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["redtematica"].ToString() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarDocente(string codanio)
    {
        string ca = "";
        int no = 0;
        Docentes estra = new Docentes();
        DataTable datos = estra.cargarDocentesxSede(HttpContext.Current.Session["codsede"].ToString(), codanio);
        if (datos != null && datos.Rows.Count > 0)
        {

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                no += 1;
                ca += "<tr>";
                ca += "<td>" + no + "</td>";
                ca += "<td>" + datos.Rows[i]["identificacion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nomdocente"].ToString() + "</td>";
                ca += "<td><input type='checkbox' name='asistencia" + no + "' checked value='" + datos.Rows[i]["codgradodocente"].ToString() + "'/></td>";
                ca += "</tr>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession=true)]
    public static string encabezado(string valFecha, string valtActividad, string valTema, string valFacilitador, string valhInicio, string valhFin)
    {
        string ca = "";
        Estrategias estra = new Estrategias();
        Funciones fun = new Funciones();
        int estrategia = 2;
        DataRow row = estra.guardarEncabezadoDoc(HttpContext.Current.Session["CodEstraAsesorCoordinador"].ToString(), fun.convertFechaAño(valFecha), valtActividad, valTema, valFacilitador, valhInicio, valhFin, estrategia.ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString(), HttpContext.Current.Session["codsede"].ToString(), HttpContext.Current.Session["codinstrumento"].ToString(), HttpContext.Current.Session["j"].ToString());
        if (row != null)
        {
            ca += row["codigo"];
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string docenteInasistente(string codInasistencia, string codDocente)
    {
        string ca = "";
        Estrategias estra = new Estrategias();
        Funciones fun = new Funciones();

        if (estra.guardarDocenteInasistente(codInasistencia, codDocente))
        {
            ca += "Datos almacenados exitosamente";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadSelectInstrumento()
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataRow dato = estra.loadSelectInstrumentos004Sedes(HttpContext.Current.Session["codsede"].ToString());
        if (dato != null)
        {
            ca += "loadSelect@";
            ca += "<option value='" + dato["codigodepartamento"].ToString() + "'>" + dato["nombredepartamento"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigomunicipio"].ToString() + "'>" + dato["nombremunicipio"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigoinstitucion"].ToString() + "'>" + dato["nombreinstitucion"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigosede"].ToString() + "'>" + dato["nombresede"].ToString() + "</option>@";
            //ca += "<option value='" + dato["codigoredtematica"].ToString() + "'>" + dato["redtematica"].ToString() + "</option>";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarEncabezados()
    {
        string ca = "";
        Institucion inst = new Institucion();
        Funciones fun = new Funciones();
        DataRow datosinstrumento = inst.proloadestras004Sede(HttpContext.Current.Session["codinstrumento"].ToString(), HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString(), HttpContext.Current.Session["j"].ToString());

        if (datosinstrumento != null)
        {
            ca = "datosintrumento@";//0
            ca += datosinstrumento["codigo"].ToString()//1
            + "@" + datosinstrumento["temasesion"].ToString()//2
            + "@" + fun.convertFechaAño(datosinstrumento["fechaelaboracion"].ToString())//3
            + "@" + datosinstrumento["nombrerelator"].ToString()//4
            + "@" + datosinstrumento["horasesion"].ToString()//5
            + "@" + datosinstrumento["horasesionfinal"].ToString();//6
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarListado()
    {
        string ca = "";
        Funciones fun = new Funciones();
        Estrategias est = new Estrategias();

        DataTable datos = est.cargarInasistenciasDocentesEstra2(HttpContext.Current.Session["codinstrumento"].ToString());

        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["tipoactividad"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["tema"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["facilitador"].ToString() + "</td>";
                ca += "<td>" + fun.convertFechaDia(datos.Rows[i]["fecha"].ToString()) + "</td>";
                ca += "<td>" + datos.Rows[i]["horainicio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["horafinal"].ToString() + "</td>";
                ca += "<td><a href='javascript:void(0)' class='btn btn-success' onclick='loadinstrumento(" + datos.Rows[i]["codigo"].ToString() + ")'>Ver</a><br/><br/><a href='javascript:void(0)' class='btn btn-danger' onclick='eliminar(" + datos.Rows[i]["codigo"].ToString() + ")'>Eliminar</a><br/><br/></td>";
                ca += "</tr>";
            }
        }
        else
        {
            ca += "<tr><td colspan='6'>No existe registros de asistencia</td></tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarEncabezado(string codigo)
    {
        string ca ="";
        Estrategias estra = new Estrategias();

         DataRow dato = estra.cargarInasistenciasDocentesEstra2_DR(codigo);

        if (dato != null)
        {
            ca = dato["tipoactividad"].ToString();
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string eliminar(string codigo)
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        estra.eliminarAsistenciaDocentesEstra2(codigo);
        estra.eliminarAsistenciaDetalleDocentesEstra2(codigo);

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadinstrumento(string codigo)
    {
        string ca = "";
        int no = 0;
        Estrategias estra = new Estrategias();

        DataTable datos = estra.cargarInasistenciasDetalle_DocentesEstra2(codigo);
        if (datos != null && datos.Rows.Count > 0)
        {

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                no += 1;
                ca += "<tr>";
                ca += "<td>" + no + "</td>";
                ca += "<td>" + datos.Rows[i]["identificacion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombre"].ToString() + " " + datos.Rows[i]["apellido"].ToString() + "</td>";
                //ca += "<td><input type='checkbox' name='asistencia" + no + "' checked value='" + datos.Rows[i]["codestumatred"].ToString() + "'/></td>";
                //ca += "<td><input type='button' value='Editar' class='btn btn-primary' onclick='editarEstudiante(\"" + datos.Rows[i]["codigo"].ToString() + "\", \"" + datos.Rows[i]["nombre"].ToString() + "\", \"" + datos.Rows[i]["apellido"].ToString() + "\", \"" + datos.Rows[i]["identificacion"].ToString() + "\", \"" + datos.Rows[i]["sexo"].ToString() + "\", \"" + datos.Rows[i]["fecha_nacimiento"].ToString() + "\", \"" + datos.Rows[i]["telefono"].ToString() + "\", \"" + datos.Rows[i]["direccion"].ToString() + "\", \"" + datos.Rows[i]["email"].ToString() + "\", \"" + datos.Rows[i]["codtipodocumento"].ToString() + "\")'/></td>";
                //ca += "<td><input type='button' value='Eliminar' class='btn btn-danger' onclick='eliminarEstudiante(\"" + datos.Rows[i]["codigo"].ToString() + "\")' /></td>";
                ca += "</tr>";
            }
        }

        return ca;
    }

}