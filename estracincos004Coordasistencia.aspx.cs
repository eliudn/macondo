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

public partial class estracincos004Coordasistencia : System.Web.UI.Page
{
    Estrategias estra = new Estrategias();
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
            //DataRow dat = estra.buscarRegistroMemoriaS004(Session["cod"].ToString());
            //if(dat != null)
            //{
            //    string ca = "";
            //    ca += "<table style='padding: 10px; border-radius: 5px; background-color: #ECECEC;'>";
            //    ca += "<tr>";
            //    ca += "<td><b>Institución:</b> " + dat["nombreinstitucion"].ToString() + " </td>";
            //    ca += "<td><b>Sede:</b> " + dat["nombresede"].ToString() + " </td>";
            //    ca += "</tr>";
            //    ca += "<tr>";
            //    ca += "<td colspan='2'><b>Nombre Sesión:</b> " + dat["nombresesion"].ToString() + " </td>";
            //    ca += "</tr>";
            //    ca += "</table>";
            //    lblDatosInstitucion.Text = ca;
            //}
            //if (Session["identificacion"] != null)
            //{
            //    Estrategias estra = new Estrategias();
            //    DataRow dato = estra.buscarCodEstraAsesorxCoordinador(Session["identificacion"].ToString());

            //    if (dato != null)
            //    {
            //        Session["CodEstraAsesorCoordinador"] = dato["codigo"].ToString();

            //    }
            //    else
            //    {
            //        mostrarmensaje("error","Este Asesor no pertenece a esta estrategia.");
            //    }
            //}


        }
    }
    public void obtenerGET()
    {
        Session["cod"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["cod"]);
        //Session["codredtematicasede"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["codredtematicasede"]);
        //Session["m"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        //Session["s"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
        //Session["a"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["a"]);

    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("estracincos004Coord.aspx");
    }

    [WebMethod(EnableSession = true)]
    public static string cargarInstituciones()
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarInstitucion();
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
    

    [WebMethod(EnableSession=true)]
    public static string cargarRedTematica(string codSede)
    {
        string ca = "";
        Estrategias estra = new Estrategias();
        DataTable datos = estra.cargarRedTematica(codSede.ToString());
        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<option value='0' disabled selected>Seleccione red tematica</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarEstudiantes()
    {
        string ca = "";
        int no = 0;
        Estrategias estra = new Estrategias();
        DataTable datos = estra.cargarEstudianteRedesTematicas(HttpContext.Current.Session["codredtematicasede"].ToString());
        if (datos != null && datos.Rows.Count > 0)
        {

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                no += 1;
                ca += "<tr>";
                ca += "<td>" + no + "</td>";
                ca += "<td>" + datos.Rows[i]["identificacion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombre"].ToString() + " " + datos.Rows[i]["apellido"].ToString() + "</td>";
                ca += "<td><input type='checkbox' name='asistencia" + no + "' checked value='" + datos.Rows[i]["codestumatred"].ToString() + "'/></td>";
                ca += "<td><input type='button' value='Editar' class='btn btn-primary' onclick='editarEstudiante(\"" + datos.Rows[i]["codigo"].ToString() + "\", \"" + datos.Rows[i]["nombre"].ToString() + "\", \"" + datos.Rows[i]["apellido"].ToString() + "\", \"" + datos.Rows[i]["identificacion"].ToString() + "\", \"" + datos.Rows[i]["sexo"].ToString() + "\", \"" + datos.Rows[i]["fecha_nacimiento"].ToString() + "\", \"" + datos.Rows[i]["telefono"].ToString() + "\", \"" + datos.Rows[i]["direccion"].ToString() + "\", \"" + datos.Rows[i]["email"].ToString() + "\", \"" + datos.Rows[i]["codtipodocumento"].ToString() + "\")'/></td>";
                ca += "<td><input type='button' value='Eliminar' class='btn btn-danger' onclick='eliminarEstudiante(\"" +datos.Rows[i]["codigo"].ToString()+ "\")' /></td>";
                ca += "</tr>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession=true)]
    public static string encabezado(string valFecha, string valtActividad, string valhInicio, string valhFin, string estrategia)
    {
        string ca = "";
        Estrategias estra = new Estrategias();
        Funciones fun = new Funciones();

        DataRow row = estra.guardarEncabezadoS004_estra5coord(fun.convertFechaAño(valFecha), valtActividad, valhInicio, valhFin, HttpContext.Current.Session["cod"].ToString());
        if (row != null)
        {
            ca += row["codigo"];
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string matriculadosInasistente(string codInasistencia, string codEstudiante)
    {
        string ca = "";
        Estrategias estra = new Estrategias();
        Funciones fun = new Funciones();

        if (estra.guardarEstudianteInasistenteS004_estra5(codInasistencia, codEstudiante))
        {
            ca += "Datos almacenados exitosamente";
        }

        return ca;
    }

    [WebMethod(EnableSession=true)]
    public static string actualizarEstudiante(string codEstudiante, string tdocumentoEstudiante, string nombreEstudiante, string apellidoEstudiante, string identificacionEstudiante, string sexoEstudiante, string fnacimientoEstudiante, string telefonoEstudiante, string direccionEstudiante, string emailEstudiante)
    {
        string ca = "";
        Estrategias estra = new Estrategias();
        Funciones fun = new Funciones();
        if (estra.updateEstudiante(codEstudiante, tdocumentoEstudiante, nombreEstudiante, apellidoEstudiante, identificacionEstudiante, sexoEstudiante, fun.convertFechaAño(fnacimientoEstudiante), telefonoEstudiante, direccionEstudiante, emailEstudiante))
        {
            ca += "Datos almacenados exitosamente";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string eliminarEstudiante(string codEstudiante)
    {
        string ca = "";
        Estrategias estra = new Estrategias();
        //Funciones fun = new Funciones();
        if (estra.deleteEstudiante(codEstudiante))
        {
            ca += "El estudiante fue eliminado de la red tematica exitosamente";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarEncabezados()
    {
        string ca = "";
        Institucion inst = new Institucion();
        Funciones fun = new Funciones();
        DataRow datosinstrumento = inst.proloadestras004_estra5(HttpContext.Current.Session["cod"].ToString());

        if (datosinstrumento != null)
        {
            ca = "datosintrumento"//0
            + "@" + datosinstrumento["codigo"].ToString() //1
            + "@" + datosinstrumento["actividad"].ToString()//2
            + "@" + fun.convertFechaAño(datosinstrumento["fechaelaboracionini"].ToString())//3
            + "@" + datosinstrumento["horainicio"].ToString()//4
            + "@" + datosinstrumento["horafin"].ToString()//5
            + "@" + HttpContext.Current.Session["codrol"].ToString();//6
        }
        
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarListado()
    {
        string ca = "";


        Funciones fun = new Funciones();
        Estrategias est = new Estrategias();

        DataTable datos = est.cargarInasistenciasEstra5_S004Coord(HttpContext.Current.Session["cod"].ToString());

        if (datos != null && datos.Rows.Count > 0)
        {
            ca += HttpContext.Current.Session["codrol"].ToString() + "load@";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["actividad"].ToString() + "</td>";
                ca += "<td>" + fun.convertFechaDia(datos.Rows[i]["fecha"].ToString()) + "</td>";
                ca += "<td>" + datos.Rows[i]["horainicio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["horafin"].ToString() + "</td>";
                ca += "<td><a href='javascript:void(0)' class='btn btn-success' onclick='loadinstrumento(" + datos.Rows[i]["codigo"].ToString() + ")'>Ver</a><br/><br/><a href='javascript:void(0)' id='btneliminar' class='btn btn-danger' onclick='eliminar(" + datos.Rows[i]["codigo"].ToString() + ")'>Eliminar</a><br/><br/></td>";
                ca += "</tr>";
            }
        }
        else
        {
            ca += "load@<tr><td colspan='8'>No existe registros de asistencia</td></tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarMatriculados()
    {
        string ca = "";
        int no = 0;
        Estrategias estra = new Estrategias();
        DataTable datos = estra.cargarMatriculados_Estra5_S004();
        if (datos != null && datos.Rows.Count > 0)
        {

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                no += 1;
                ca += "<tr>";
                ca += "<td>" + no + "</td>";
                ca += "<td>" + datos.Rows[i]["identificacion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombre"].ToString() + " " + datos.Rows[i]["apellido"].ToString() + "</td>";
                ca += "<td><input type='checkbox' name='asistencia" + no + "' checked value='" + datos.Rows[i]["codigo"].ToString() + "'/></td>";
                //ca += "<td><input type='button' value='Editar' class='btn btn-primary' onclick='editarEstudiante(\"" + datos.Rows[i]["codigo"].ToString() + "\", \"" + datos.Rows[i]["nombre"].ToString() + "\", \"" + datos.Rows[i]["apellido"].ToString() + "\", \"" + datos.Rows[i]["identificacion"].ToString() + "\", \"" + datos.Rows[i]["sexo"].ToString() + "\", \"" + datos.Rows[i]["fecha_nacimiento"].ToString() + "\", \"" + datos.Rows[i]["telefono"].ToString() + "\", \"" + datos.Rows[i]["direccion"].ToString() + "\", \"" + datos.Rows[i]["email"].ToString() + "\", \"" + datos.Rows[i]["codtipodocumento"].ToString() + "\")'/></td>";
                //ca += "<td><input type='button' value='Eliminar' class='btn btn-danger' onclick='eliminarEstudiante(\"" + datos.Rows[i]["codigo"].ToString() + "\")' /></td>";
                ca += "</tr>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarinasistentes(string codigo)
    {
        string ca = "";
        int no = 0;
        Estrategias estra = new Estrategias();
        DataTable datos = estra.cargariansistenciasMatriculados_Estra5_S004(codigo);
        if (datos != null && datos.Rows.Count > 0)
        {

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                no += 1;
                ca += "<tr>";
                ca += "<td>" + no + "</td>";
                ca += "<td>" + datos.Rows[i]["identificacion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombre"].ToString() + " " + datos.Rows[i]["apellido"].ToString() + "</td>";
                ca += "<td><input type='checkbox' name='asistencia" + no + "' checked value='" + datos.Rows[i]["codigo"].ToString() + "' disabled/></td>";
                ca += "</tr>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string eliminar(string codigo)
    {
        string ca = "";

        Estrategias est = new Estrategias();

        est.eliminarDetalleasistencia_Estrategia5(codigo);
        est.eliminarasistencia_Estrategia5(codigo);

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string validarSesion()
    {
        string ca = "";

        if (HttpContext.Current.Session["codrol"].ToString() == "12")
        {
            ca = "coordinador";
        }

        return ca;
    }

}