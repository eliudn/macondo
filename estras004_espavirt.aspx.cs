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



public partial class estras004_espavirt : System.Web.UI.Page
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
            DataRow dato = est.buscarCodEstraAsesorxCoordinador(Session["identificacion"].ToString());

            if (dato != null)
            {
                Session["CodAsesorEstraCoordinador"] = dato["codigo"].ToString();
                Session["nombreasesor"] = dato["nombre"].ToString();
            }

            if (Session["codrol"].ToString() == "10" || Session["codrol"].ToString() == "11" || Session["codrol"].ToString() == "2" || Session["codrol"].ToString() == "15")//Coordinador / asesor UniMag - CUC
            {
                lblTipoGrupo.Text = "Grupo de investigación";
            } 
            else  if (Session["codrol"].ToString() == "12" || Session["codrol"].ToString() == "13")//Coordinador / asesor FUNTICS
            {
                lblTipoGrupo.Text = "Red Temática";
            }
        }
    }
    public void obtenerGET()
    {
        Session["e"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["e"]);
        Session["m"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        Session["s"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
        lblEstrategia.Text = Session["e"].ToString();
        lblMomento.Text = Session["m"].ToString();
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
    public static string insertestras004(string redtematica, string nombresesion, string temasesion, string fechaelaboracion, string nombrerelator, string horasesion, string horasesionfinal, string acompanamiento, string herramientas, string evaluacionsesion, string nohoras)
    {

        Estrategias inst = new Estrategias();
        string ca = "";
        Funciones fun = new Funciones();

        DataRow insert = inst.insertestras004_EspVirtual(redtematica, nombresesion, temasesion, fun.convertFechaAño(fechaelaboracion), nombrerelator, horasesion, horasesionfinal, HttpContext.Current.Session["CodAsesorEstraCoordinador"].ToString(), acompanamiento, herramientas, evaluacionsesion, HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString(), nohoras);

        if (insert != null)
        {
            ca += "true@";
            ca += insert["codigo"].ToString();
            HttpContext.Current.Session["codredtematicasede"] = redtematica;
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
        Estrategias inst = new Estrategias();

        DataRow datosinstrumento = inst.proloadestras004_EspVirtual(codigo, HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString());

        if (datosinstrumento != null)
        {
            //HttpContext.Current.Session["codredtematicasede"] = redtematica;
            //codigo, codestracoordinador, nombresesion,temasesion, informacionadicional, fechaelaboracion, nombrerelator, aspectosdesarrollados, conclusiones, bibliografia
            ca = "datosintrumento@";
            ca += datosinstrumento["codigo"].ToString()
            + "@" + datosinstrumento["nombresesion"].ToString()
            + "@" + datosinstrumento["temasesion"].ToString()

            + "@" + datosinstrumento["fechaelaboracion"].ToString()
            + "@" + datosinstrumento["nombrerelator"].ToString()
            + "@" + datosinstrumento["acompanamiento"].ToString()
            + "@" + datosinstrumento["herramientas"].ToString()

            + "@" + datosinstrumento["evaluacionsesion"].ToString()
            + "@" + datosinstrumento["horasesion"].ToString()
            + "@" + datosinstrumento["horasesionfinal"].ToString()
            + "@" + datosinstrumento["nohoras"].ToString();
            //+ "@" + datosinstrumento["nosesiones"].ToString();

        }
        else
        {
            ca = "vacio@";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string updateestras004(string codigoestrategia, string nombresesion, string temasesion, string fechaelaboracion, string nombrerelator, string horasesion, string horasesionfinal, string acompanamiento, string herramientas, string evaluacionsesion, string nohoras)
    {

        Funciones fun = new Funciones();

        Estrategias inst = new Estrategias();
        string ca = "";

        long update = inst.procupdateestras004_EspVirtual(codigoestrategia, nombresesion, temasesion, fechaelaboracion, nombrerelator, horasesion, horasesionfinal, acompanamiento, herramientas, evaluacionsesion, nohoras);
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

        if (est.eliminarMemoriaS004_EspVirtual(codigo))
        {

            ca = "delete@";
        }
        else
        {
            ca = "vacio@";
        }

        return ca;
    }
   

    [WebMethod(EnableSession = true)]
    public static string cargarRedtematica(string codsede)
    {
        string ca = "";

        Institucion inst = new Institucion();

        Estrategias est = new Estrategias();

        if(HttpContext.Current.Session["codrol"] != null)
        {
            if (HttpContext.Current.Session["codrol"].ToString() == "10" || HttpContext.Current.Session["codrol"].ToString() == "11" || HttpContext.Current.Session["codrol"].ToString() == "2" || HttpContext.Current.Session["codrol"].ToString() == "15")//Coordinador / asesor UniMag - CUC
            {
                //Carga los grupos de investigación
                DataTable datos = est.cargarLineaInvestigacion(codsede);

                if (datos != null && datos.Rows.Count > 0)
                {
                    ca = "redtematica@";
                    ca += "<option value='' disabled selected>Seleccione grupo de investigación</option>";
                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombregrupo"].ToString() + "</option>";
                    }
                }
            }
            else if (HttpContext.Current.Session["codrol"].ToString() == "12" || HttpContext.Current.Session["codrol"].ToString() == "13")//Coordinador / asesor FUNTICS
            {
                DataTable datos = inst.proccargarRedtematica(codsede, HttpContext.Current.Session["CodAsesorEstraCoordinador"].ToString());

                if (datos != null && datos.Rows.Count > 0)
                {
                    ca = "redtematica@";
                    //ca += "<option value='' disabled selected>Seleccione Red Temática</option>";
                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        ca += "<input type='checkbox' id='redtematica_" + (i + 1) + "' name='redestematicas' value='" + datos.Rows[i]["codigo"].ToString() + "' />" + datos.Rows[i]["redtematica"].ToString();
                        //ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["redtematica"].ToString() + "</option>";
                    }
                }
            }
            
        }
  
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarTemas()
    {
        string ca = "";

        switch (HttpContext.Current.Session["s"].ToString())
        {
            case "2":
                ca = "Preparándome para el proceso Gózate la ciencia y mejora tus capacidades investigativas a través de comunidades virtuales.";
                break;

            case "3":
                ca = "Las rutas para gozarme la ciencia y mejorar mis capacidades investigativas a través de comunidades virtuales.";
                break;

            case "4":
                ca = "Encarrílate con la investigación.";
                break;

            case "5":
                ca = "Haciéndole el juego a la ciencia desde la virtualidad.";
                break;

            case "6":
                ca = "Pa ciencia con las herramientas.";
                break;

            case "7":
                ca = "En las ferias la investigación es una fiesta.";
                break;

            case "8":
                ca = "Gocémonos la ciencia respetando los derechos de autor.";
                break;

            case "9":
                ca = "El goce de preparar el informe de nuestra investigación.";
                break;

            case "10":
                ca = "Las niñas, los niños y los jóvenes nos gozamos la ciencia divulgando nuestro trabajo.";
                break;

        }

        return ca;
    }

    //Listado de memorias por asesor
    [WebMethod(EnableSession = true)]
    public static string cargarListadoMemoriaAsesor()
    {
        //int pagint = Convert.ToInt32(page);
        //int rowsint = 10;
        //int offset = (pagint - 1) * rowsint;

        string ca = "";
        string backward = "";
        string info = "";
        string forward = "";

        Estrategias estra = new Estrategias();
        Funciones fun = new Funciones();

        DataTable datos = estra.cargarListadoMemoriasS004_EspVirtualesTodo(HttpContext.Current.Session["CodAsesorEstraCoordinador"].ToString(), HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString());

        if (datos != null && datos.Rows.Count > 0)
        {
            DataTable datosCount = estra.cargarListadoMemoriasCount_EspVirtual(HttpContext.Current.Session["CodAsesorEstraCoordinador"].ToString(), HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString());//Saber la cantidad de registros en la consulta

            double cant = datosCount.Rows.Count;
            double val = Math.Ceiling(cant / 10);

            for (int i = 0; i < datos.Rows.Count; i++)
            {
               
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["nombredepartamento"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombremunicipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombreinstitucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombresede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombresesion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombre"].ToString() + " " + datos.Rows[i]["consecutivogrupo"].ToString() + "</td>";
                ca += "<td>" + fun.convertFechaDia(datos.Rows[i]["fechaelaboracion"].ToString()) + "</td>";
                ca += "<td>" + datos.Rows[i]["momento"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["sesion"].ToString() + "</td>";
                ca += "<td align=\"center\"><br /><a class='btn btn-success' onclick=\"$('#listTable').hide(), $('#formTable').fadeIn(500), loadInstrumento(" + datos.Rows[i]["codigo"].ToString() + ")\">Editar</a><br/ ><br /><a target=\"_blank\" href=\"estras004_espavirtEvidencia.aspx?cod=" + datos.Rows[i]["codigo"].ToString() + "\" class=\"btn btn-primary\">Evidencias</a><br/ ><br /><a href=\"estrag001_estrategia4_ev.aspx?codinstrumentos004=" + datos.Rows[i]["codigo"].ToString() + "&codredtematicasede=" + datos.Rows[i]["codredtematicasede"].ToString() + " \" class=\"btn btn-success\">Asistencias</a><br/ ><br /><a onclick=\"eliminar(" + datos.Rows[i]["codigo"].ToString() + ")\" class=\"btn btn-danger\">Eliminar</a><br /><br /><a class='btn btn-primary' onclick=\"$('#listTable').hide(), $('#modificarsesion').fadeIn(500);$('#formTable').hide();buscarSesionMemoria(" + datos.Rows[i]["codigo"].ToString() + ")\">Modificar Sesión</a><br/ ><br /></td>";
                ca += "</tr>";
            }
            //ca += "@";

            //if (offset == 0)
            //{
            //    backward = "<li><a href='javascript:void(0);'><img src='Imagenes/flechaIn.png' /></a></li>";
            //}
            //else
            //{

            //    backward = "<li><a href='javascript:void(0);' onclick='cargarListadoMemorias(\"" + (pagint - 1) + "\")'><img src='Imagenes/flechaIn.png' /></a></li>";
            //}

            //if ((offset + rowsint) <= Convert.ToInt32(cant))
            //{
            //    info = "<li><a href='javascript:void(0);'>" + (offset + 1) + " - " + (offset + rowsint) + " de " + cant + "</a></li>";
            //}
            //else if (cant == 0)
            //{
            //    info = "<li><a href='javascript:void(0);'> <p>0 - 0 de 0</p></a></li>";
            //}
            //else
            //{
            //    info = "<li><a href='javascript:void(0);'><p>" + (offset + 1) + " - " + cant + " de " + cant + "</p></a></li>";
            //}

            //if ((offset + rowsint) >= Convert.ToInt32(cant))
            //{
            //    forward = "<li><a href='javascript:void(0);'><li><img src='Imagenes/flechaOut.png' /></a></li>";
            //}
            //else
            //{
            //    forward = "<li><a href='javascript:void(0);' onclick='cargarListadoMemorias(\"" + (pagint + 1) + "\")' ><img src='Imagenes/flechaOut.png' /></a></li>";
            //}

            //ca += backward + info + forward;
        }
        else
        {
            ca += "<tr><td colspan='11' align='center'>No se encontraron memorias registradas por parte del asesor.</td></tr>";
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

        DataRow dato = estra.loadSelectInstrumentos004_EspVirtual(codigo);
        if (dato != null)
        {
            ca += "loadSelect@";
            ca += "<option value='" + dato["codigodepartamento"].ToString() + "'>" + dato["nombredepartamento"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigomunicipio"].ToString() + "'>" + dato["nombremunicipio"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigoinstitucion"].ToString() + "'>" + dato["nombreinstitucion"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigosede"].ToString() + "'>" + dato["nombresede"].ToString() + "</option>@";
            //ca += "<option value='" + dato["codigoredtematica"].ToString() + "'>" + dato["redtematica"].ToString() + "</option>";
            ca += "<input type='checkbox' name='redestematicas' value='" + dato["codigoredtematica"].ToString() + "' disabled checked/>" + dato["redtematica"].ToString();
            //ca += "@" + (i + 1);
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string buscarSesionMemoria(string codigo)
    {
        string ca = "";

        Estrategias est = new Estrategias();

        DataRow memoria = est.buscarDatosMemoria_ev(codigo);

        if (memoria != null)
        {
            ca = memoria["sesion"].ToString() + "@<tr>";
            ca += "<td>" + memoria["redtematica"].ToString() + "</td>";
            ca += "<td>" + memoria["sesion"].ToString() + "</td>";
            ca += "</tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string guardarSesion(string codmemoria, string sesion)
    {
        string ca = "";

        Estrategias est = new Estrategias();

        if (est.actualizarSesionenMemoria_ev(codmemoria, sesion))
        {

        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string regresar()
    {
        string ca = "";

        ca = HttpContext.Current.Session["e"].ToString() + "@" + HttpContext.Current.Session["m"].ToString() + "@" + HttpContext.Current.Session["s"].ToString();

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarnomasesor()
    {
        string ca = "";

        if (HttpContext.Current.Session["nombreasesor"] != null)
        {
            ca = "nombre@" + HttpContext.Current.Session["nombreasesor"].ToString();
        }

        return ca;
    }
   
}