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

public partial class estraunos008reporte : System.Web.UI.Page
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

            //Estrategias estra = new Estrategias();
            //DataRow dato = estra.buscarCodEstraAsesorxCoordinador(Session["identificacion"].ToString());

            //if (dato != null)
            //{
            //    Session["CodAsesorEstraCoordinador"] = dato["codigo"].ToString();

            //}
            //else
            //{
            //    mostrarmensaje("error", "ERROR: Ud. No es asesor de esta estrategía.");
            //}

        }
    }
    public void obtenerGET()
    {
        Session["e"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["e"]);
        Session["m"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        //Session["s"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);

    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("estramomentos.aspx?m=1");
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



        DataTable gruposinvestigacion = inst.cargarGruposInvestigacion(codigosede, HttpContext.Current.Session["CodAsesorEstraCoordinador"].ToString());

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
    public static string insertInstrumento(string codproyecto, string resumen, string relato, string perturbacion, string superposicion, string sintesis, string aprendizaje, string conclusiones, string fuentes)
    {
        

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();

        string ca = "";

        //string coord = HttpContext.Current.Session["CodEstraCoordinador"].ToString();
        DataRow insert = inst.procinsertIntrumentos008(codproyecto, resumen, relato, perturbacion, superposicion, sintesis, aprendizaje, conclusiones, fuentes, HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString());
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
    public static string updateInstrumento(string codigoinstrumento, string resumen, string relato, string perturbacion, string superposicion, string sintesis, string aprendizaje, string conclusiones, string fuentes)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        if (inst.updateIntrumentos008(codigoinstrumento, resumen, relato, perturbacion, superposicion, sintesis, aprendizaje, conclusiones, fuentes))
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
    public static string listarBitacora(string codasesorcoordinador)
    {
        Institucion inst = new Institucion();
        string ca = "";

        DataTable datos = inst.listarS008(codasesorcoordinador, HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString());
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
                ca += "<td>" + datos.Rows[i]["nombregrupo"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["fechacreacion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["momento"].ToString() + "</td>";
                ca += "<td style='padding:5px;' ><a class='btn btn-success' onclick=\"$('#table').hide(), $('#form').fadeIn(500),  loadSelectBitacoraSeis(" + datos.Rows[i]["codproyectosede"].ToString() + "), loadInstrumentosSeis(" + datos.Rows[i]["codigo"].ToString() + ") \">Ver</a><br/><br/></td>";
                ca += "</tr>";
            }
        }
        else
        {
            ca += "<tr><td colspan='10'>No se encontraron memorias registradas por parte del asesor.</td></tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadInstrumento(string codigo)
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataRow dato = estra.loadInstrumentoS008(codigo);
        if (dato != null)
        {
            ca += "true@";
            ca += dato["codigo"].ToString() + "@";
            ca += dato["resumen"].ToString() + "@";
            ca += dato["relato"].ToString() + "@";
            ca += dato["perturbacion"].ToString() + "@";
            ca += dato["superposicion"].ToString() + "@";
            ca += dato["sintesis"].ToString() + "@";
            ca += dato["aprendizaje"].ToString() + "@";
            ca += dato["conclusiones"].ToString() + "@";
            ca += dato["fuentes"].ToString();
         
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadSelectBitacoraSeis(string codigo)
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataRow dato = estra.loadSelectS008(codigo);
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
    public static string eliminar(string codigo)
    {
        Estrategias estra = new Estrategias();
        string ca = "";



        estra.deleteS008(codigo);

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarlistasesores()
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

