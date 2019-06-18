using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.Script.Serialization;
using System.Web.Services;

public partial class estraunojornadaformacion : System.Web.UI.Page
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

            Estrategias estra = new Estrategias();
            DataRow dato = estra.buscarCodEstrategiaxCoordinador(Session["identificacion"].ToString());

            if (dato != null)
            {
                Session["codestracoordinador"] = dato["codestracoordinador"].ToString();

            }
           
        }
    }
    public void obtenerGET()
    {
        //Session["e"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["e"]);
        Session["m"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        Session["j"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["j"]);

        if(Session["j"] != null)
            if(Session["j"].ToString() == "1")
                lblJornada.Text = "La pregunta como punto de partida";
            else
                lblJornada.Text = "En la ruta metodológica";
    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("estramomentos.aspx");
    }

    [WebMethod(EnableSession = true)]
    public static string cargaranios()
    {
        string ca = "";

        Institucion ins = new Institucion();

        DataTable datos = ins.cargarAnios();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "anio@";
            ca += "<option value='0' disabled selected>Seleccione año</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
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



        DataTable gruposinvestigacion = inst.cargarGruposInvestigacion(codigosede, HttpContext.Current.Session["codestracoordinador"].ToString());

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
    public static string insertInstrumento(string codsede, string asistentes, string codanio)
    {
        

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();

        string ca = "";

        //string coord = HttpContext.Current.Session["CodEstraCoordinador"].ToString();
        DataRow insert = inst.procinsertJornadasFormacion(codsede, codanio, asistentes, HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["j"].ToString(), HttpContext.Current.Session["codestracoordinador"].ToString());
        if (insert != null)
        {
            ca = "true@";
            ca += insert["codigo"].ToString();
        }
        else
        {
            ca = "Ocurrio un error al insertar datos de instrumento_b06@";
        }
        return ca;
    }


  
    /*2016-10-25 modificado*/
    [WebMethod(EnableSession = true)]
    public static string updateInstrumento(string codigoinstrumento, string asistentes)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        if (inst.updateIntrumentoJornadasFormacion(codigoinstrumento, asistentes))
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al actualizar datos de instrumento@";
        }
        return ca;
    }

  

    /*2016-10-24 JONNY PACHECO metodo para  listar las bitacoras 3*/
   
    [WebMethod(EnableSession = true)]
    public static string listarJornadasFormacion()
    {
        Institucion inst = new Institucion();
        string ca = "";

        DataTable datos = null;

        if (HttpContext.Current.Session["codrol"].ToString() == "20")
        {
            datos = inst.listarEncaJornadasFormacionTodos(HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["j"].ToString());
        }
        else
        {
            datos = inst.listarEncaJornadasFormacion(HttpContext.Current.Session["codestracoordinador"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["j"].ToString());
        }

        
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
                ca += "<td>" + datos.Rows[i]["fecharealizacion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["momento"].ToString() + "</td>";
                ca += "<td style='padding:5px;' ><a class='btn btn-success' onclick=\"$('#table').hide(), $('#form').fadeIn(500),  loadSelectJornadasFormacion(" + datos.Rows[i]["codsede"].ToString() + ", " + datos.Rows[i]["codanio"].ToString() + "), loadInstrumentosJornadas(" + datos.Rows[i]["codigo"].ToString() + ") \">Editar</a><br/><br/><a class='btn btn-primary' href='estraunojornadaformacionevi.aspx?cod=" + datos.Rows[i]["codigo"].ToString() + "'>Evidencias</a><br/><br/><a class='btn btn-danger' onclick='eliminar(" + datos.Rows[i]["codigo"].ToString() + ")'>Eliminar</a><br/></td>";
                ca += "</tr>";
            }
        }
        else
        {
            ca += "<tr><td colspan='10'>No se encontraron memorias registradas por parte del usuario.</td></tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadInstrumento(string codigo)
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataRow dato = estra.loadInstrumentoJornadasFormacion(codigo);
        if (dato != null)
        {
            ca += "true@";
            ca += dato["codigo"].ToString() + "@";
            ca += dato["nroasistentes"].ToString() + "@" + HttpContext.Current.Session["codrol"].ToString();
         
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadSelectJornadasFormacion(string codigo, string codanio)
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataRow dato = estra.loadSelectJornadasFormacion(codigo, codanio);
        if (dato != null)
        {
            ca += "loadSelect@";
            ca += "<option value='" + dato["codigodepartamento"].ToString() + "'>" + dato["nombredepartamento"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigomunicipio"].ToString() + "'>" + dato["nombremunicipio"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigoinstitucion"].ToString() + "'>" + dato["nombreinstitucion"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigosede"].ToString() + "'>" + dato["nombresede"].ToString() + "</option>@";
        }
        return ca;
    }
   

    [WebMethod(EnableSession = true)]
    public static string eliminar(string codigo)
    {
        Estrategias estra = new Estrategias();
        string ca = "";

        estra.deleteJornadaFormacion(codigo);
        estra.deleteJornadaFormacionEvidencia(codigo);

        return ca;
    }

}

