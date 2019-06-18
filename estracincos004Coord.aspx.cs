using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using System.Web.Services;
using System.IO;



public partial class estracincos004Coord : System.Web.UI.Page
{

    Estrategias est = new Estrategias();


    protected void Page_PreInit(object sender, EventArgs e)
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
            DataRow dato = est.buscarCodEstrategiaxCoordinador(Session["identificacion"].ToString());

            if (dato != null)
            {
                Session["codestracoordinador"] = dato["codigo"].ToString();
            }

        }
    }
    public void obtenerGET()
    {
        Session["e"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["e"]);
        //Session["m"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        Session["s"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
        lblEstrategia.Text = Session["e"].ToString();
        //lblMomento.Text = Session["m"].ToString();
        lblSesion.Text = Session["s"].ToString();
    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        if (Session["e"] != null || Session["m"] != null || Session["s"] != null)
        {
            if (Session["e"].ToString() == "2")
                Response.Redirect("estradosmomentos.aspx?m=" + lblMomento.Text +"&s=" + lblSesion.Text);
            else if (Session["e"].ToString() == "4")
                Response.Redirect("estracuatromomentos.aspx?m=" + lblMomento.Text);
            else if (Session["e"].ToString() == "5")
                Response.Redirect("estracincomomentos.aspx");
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
       
    }


    [WebMethod(EnableSession = true)]
    public static string cargarInstituciones(string codMunicipio)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.proccargarInstitucionxMunicipio(codMunicipio);

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
            ca += "<option value='' disabled selected>Seleccione Sede</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }



    [WebMethod(EnableSession = true)]
    public static string insertestras004(string municipio, string lugar, string nombreactividad, string descripcion, string sintesis, string producto, string recursos, string evaluacion, string fechaelaboracion, string horainicio, string horafin, string fechaelaboracionini)
    {

        Estrategias est = new Estrategias();
        string ca = "";
        Funciones fun = new Funciones();

        DataRow insert = est.insertestras004Estra5(municipio, nombreactividad, descripcion, sintesis, producto, recursos, evaluacion, fun.convertFechaAño(fechaelaboracion), HttpContext.Current.Session["codestracoordinador"].ToString(), HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["s"].ToString(), lugar, horainicio, horafin, fechaelaboracionini);

        if (insert != null)
        {
            ca += "true@";
            ca += insert["codigo"].ToString();
        }
        else
        {
            ca = "Ocurrio un error al insertar ests004@";
        }


        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string loadestras004(string codigo)
    {
        string ca = "";
        Funciones fun = new Funciones();
        Estrategias est = new Estrategias();

        DataRow datosinstrumento = est.proloadestras004Estr5(codigo);

        if (datosinstrumento != null)
        {
            ca = "datosintrumento@";
            ca += datosinstrumento["codigo"].ToString()
            + "@" + datosinstrumento["actividad"].ToString()
            + "@" + datosinstrumento["descripcion"].ToString()
            + "@" + datosinstrumento["sintesis"].ToString()
            + "@" + datosinstrumento["producto"].ToString()
            + "@" + datosinstrumento["recursos"].ToString()
            + "@" + datosinstrumento["evaluacion"].ToString()
            + "@" + fun.convertFechaDia(datosinstrumento["fechaelaboracion"].ToString())
            + "@" + datosinstrumento["lugar"].ToString()
            + "@" + datosinstrumento["horainicio"].ToString()
            + "@" + datosinstrumento["horafin"].ToString()
            + "@" + fun.convertFechaDia(datosinstrumento["fechaelaboracionini"].ToString())
            + "@" + HttpContext.Current.Session["codrol"].ToString();

        }
        else
        {
            ca = "vacio@";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string updateestras004(string codigoestrategia, string nombreactividad, string descripcion, string sintesis, string producto, string recursos, string evaluacion, string fechaelaboracion, string lugar, string horainicio, string horafin, string fechaelaboracionini, string codmunicipio)
    {

        Funciones fun = new Funciones();

        Estrategias est = new Estrategias();
        string ca = "";

        long update = est.procupdateestras004Estra5(codigoestrategia, nombreactividad, descripcion, sintesis, producto, recursos, evaluacion, fechaelaboracion, lugar, horainicio, horafin, fechaelaboracionini, codmunicipio);
        if (update != -1)
        {
            ca = "true@";
        }
        else
        {
            ca = "false@";
            ca += "Ocurrio un error al actualizar datos de estras004@";
        }
        return ca;
    }
    [WebMethod(EnableSession = true)]
    public static string deleteestras004(string codigo)
    {
        string ca = "";
        Estrategias est = new Estrategias();

        DataRow dat = est.buscarCodAsistenciaEstra5(codigo);

        if (dat != null)
        {
            est.eliminarasistencia_Estrategia5(dat["codigo"].ToString());
            est.eliminarDetalleasistencia_Estrategia5(dat["codigo"].ToString());
        }

        if (est.eliminarMemoriaS004Estra5(codigo))
        {

            ca = "delete@";
            est.eliminarEvidenciasMemoriaS004Estra5(codigo);

           

        }
        else
        {
            ca = "vacio@";
        }

        return ca;
    }
  
    //Listado de memorias por Coord
    [WebMethod(EnableSession = true)]
    public static string cargarListadoMemoriaCoord(string page)
    {
        int pagint = Convert.ToInt32(page);
        int rowsint = 10;
        int offset = (pagint - 1) * rowsint;

        string ca = "";
        string backward = "";
        string info = "";
        string forward = "";

        Estrategias estra = new Estrategias();
        Funciones fun = new Funciones();

        DataTable datos = null;
        DataTable datosCount = null;

        if (HttpContext.Current.Session["codrol"].ToString() == "12")
        {
            datos = estra.cargarListadoMemoriasS004Estra5(HttpContext.Current.Session["codestracoordinador"].ToString(), HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["s"].ToString(), Convert.ToString(offset), Convert.ToString(rowsint));
            datosCount = estra.cargarListadoMemoriasCountS004Estra5(HttpContext.Current.Session["codestracoordinador"].ToString(), HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["s"].ToString());//Saber la cantidad de registros en la consulta
        }
        else
        {
            datos = estra.cargarListadoMemoriasS004Estra5(HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["s"].ToString(), Convert.ToString(offset), Convert.ToString(rowsint));
            datosCount = estra.cargarListadoMemoriasCountS004Estra5(HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["s"].ToString());//Saber la cantidad de registros en la consulta
        }

     

        if (datos != null && datos.Rows.Count > 0)
        {
           

            double cant = datosCount.Rows.Count;
            double val = Math.Ceiling(cant / 10);

            for (int i = 0; i < datos.Rows.Count; i++)
            {
               
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["nombredepartamento"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombremunicipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["lugar"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["actividad"].ToString() + "</td>";
                ca += "<td>" + fun.convertFechaDia(datos.Rows[i]["fechaelaboracionini"].ToString()) + "</td>";
                ca += "<td>" + fun.convertFechaDia(datos.Rows[i]["fechaelaboracion"].ToString()) + "</td>";
                ca += "<td>" + datos.Rows[i]["sesion"].ToString() + "</td>";

                ca += "<td align=\"center\"><br /><a class='btn btn-success' onclick=\"$('#listTable').hide(), $('#formTable').fadeIn(500), loadInstrumento(" + datos.Rows[i]["codigo"].ToString() + ")\">Editar</a><br/ ><br /><a href=\"estracincos004CoordEvidencia.aspx?cod=" + datos.Rows[i]["codigo"].ToString() + "\" class=\"btn btn-primary\">Evidencias</a><br/ ><br /><a href=\"estracincos004Coordasistencia.aspx?cod=" + datos.Rows[i]["codigo"].ToString() + "\" class=\"btn btn-success\">Asistencia</a><br/ ><br />";
                if (HttpContext.Current.Session["codrol"].ToString() == "12")
                    ca +="<a onclick=\"eliminar(" + datos.Rows[i]["codigo"].ToString() + ")\" class=\"btn btn-danger\">Eliminar</a><br /><br /></td>";

                ca += "</tr>";
            }
            ca += "@";

            if (offset == 0)
            {
                backward = "<li><a href='javascript:void(0);'><img src='Imagenes/flechaIn.png' /></a></li>";
            }
            else
            {

                backward = "<li><a href='javascript:void(0);' onclick='cargarListadoMemorias(\"" + (pagint - 1) + "\")'><img src='Imagenes/flechaIn.png' /></a></li>";
            }

            if ((offset + rowsint) <= Convert.ToInt32(cant))
            {
                info = "<li><a href='javascript:void(0);'>" + (offset + 1) + " - " + (offset + rowsint) + " de " + cant + "</a></li>";
            }
            else if (cant == 0)
            {
                info = "<li><a href='javascript:void(0);'> <p>0 - 0 de 0</p></a></li>";
            }
            else
            {
                info = "<li><a href='javascript:void(0);'><p>" + (offset + 1) + " - " + cant + " de " + cant + "</p></a></li>";
            }

            if ((offset + rowsint) >= Convert.ToInt32(cant))
            {
                forward = "<li><a href='javascript:void(0);'><li><img src='Imagenes/flechaOut.png' /></a></li>";
            }
            else
            {
                forward = "<li><a href='javascript:void(0);' onclick='cargarListadoMemorias(\"" + (pagint + 1) + "\")' ><img src='Imagenes/flechaOut.png' /></a></li>";
            }

            ca += backward + info + forward;
        }
        else
        {
            ca += "<tr><td colspan='11' align='center'>No se encontraron memorias registradas por parte del coordinador.</td></tr>";
        }

        return ca;
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
            ca += "<option value='' disabled selected>Seleccione departamento</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    //Cargar municipios
    [WebMethod(EnableSession = true)]
    public static string cargarMunicipioMagdalena(string codDepartamento)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarciudadxDepartamento(codDepartamento);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "municipio@";
            ca += "<option value='' disabled selected>Seleccione municipio</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadSelectInstrumento(string codigo)
    {
        string ca = "";
        Estrategias estra = new Estrategias();
        Institucion inst = new Institucion();

        DataRow dato = estra.loadSelectInstrumentoEstra5_s004(codigo);
        if (dato != null)
        {
            ca += "loadSelect@";
            ca += "<option value='" + dato["codigodepartamento"].ToString() + "'>" + dato["nombredepartamento"].ToString() + "</option>@";

           

            DataTable datos = inst.cargarciudadxDepartamento("20");

            if (datos != null && datos.Rows.Count > 0)
            {
                //ca = "municipio@";
                ca += "<option value='' disabled selected>Seleccione municipio</option>";
                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    if (datos.Rows[i]["cod"].ToString() == dato["codigomunicipio"].ToString())
                    {
                        ca += "<option value='" + dato["codigomunicipio"].ToString() + "' selected>" + dato["nombremunicipio"].ToString() + "</option>";
                    }
                    else
                    {
                        ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
                    }
                }
            }

            
           
        }
        return ca;
    }

   
}