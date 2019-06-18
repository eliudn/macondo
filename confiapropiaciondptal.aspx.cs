using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using ClosedXML.Excel;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Web.Services;

public partial class confiapropiaciondptal : System.Web.UI.Page
{

    LineaBase lb = new LineaBase();
    Institucion inst = new Institucion();
    Docentes doc = new Docentes();

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
            if (lblCodApropiacion.Text != "")
            {
                switch (lblCodApropiacion.Text)
                {
                    case "d":
                        lblApropiacion.Text = "Departamental";
                        break;
                    case "r":
                        lblApropiacion.Text = "Regional";
                        break;
                    case "n":
                        lblApropiacion.Text = "Nacional";
                        break;
                    case "i":
                        lblApropiacion.Text = "Internacional";
                        break;
                }
            }
        }
    }

    public void obtenerGET()
    {
       lblCodApropiacion.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["tipo"]);
    }

    //cargar años
    [WebMethod(EnableSession = true)]
    public static string cargaranios()
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarAnios();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "anio@";
            ca += "<option value='' selected>Seleccione año</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
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
            ca += "<option value='' selected>Seleccione</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                if(datos.Rows[i]["cod"].ToString() != "338")
                {
                    ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
                }
                
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
            ca += "<option value='' selected>Seleccione</option>";

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
            ca += "<option value='' selected>Seleccione</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    //cargar Grupos
    [WebMethod(EnableSession = true)]
    public static string cargarGrupoInvestigacion(string codsede, string municipio, string institucion, string sede)
    {
        string ca = "";

        Institucion doc = new Institucion();

        DataTable datos = doc.cargarGruposInvestigacionBitacorasSupervision(codsede);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "full@";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>"+(i+1)+"</td>";
                ca += "<td>" + municipio + "</td>";
                ca += "<td>" + institucion + "</td>";
                ca += "<td>" + sede + "</td>";
                ca += "<td>" + datos.Rows[i]["nombregrupo"].ToString() + "</td>";
                ca += "<td align='center'><input name=\"chkGrupo\" value=" + datos.Rows[i]["codigo"].ToString() + " type=\"checkbox\"></td>";
                ca += "</tr>";
            }
        }

        return ca;
    }


    //Cargar datos
    [WebMethod(EnableSession = true)]
    public static string loadData(string dataID)
    {
        string ca = "";

        Institucion ins = new Institucion();
        Funciones fun = new Funciones();

        DataTable datos = ins.loadespaciosapropiacion(dataID);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "full@";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>"+(i+1)+"</td>";
                ca += "<td>" + datos.Rows[i]["anio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombregrupo"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["area"].ToString() + "</td>";
                //ca += "<td align='center'><a class=\"btn btn-success\" onclick=\"fedit(" + datos.Rows[i]["codigo"].ToString() + ")\">Editar</a> <br><br> <a href='confiapropiaciondptalevi.aspx?cod=" + datos.Rows[i]["codigo"].ToString() + "' class=\"btn btn-primary\">Evidencias</a></td>";
                ca += "<td align='center'><a href='confiapropiaciondptalevi.aspx?cod=" + datos.Rows[i]["codigo"].ToString() + "&tipo=" + dataID + "' class=\"btn btn-primary\">Evidencias</a><br /><br /><a href='javascript:void(0)' onclick='eliminar(" + datos.Rows[i]["codigo"].ToString() + ")' class=\"btn btn-danger\">Eliminar</a></td>";
                ca += "</tr>";
            }
        }

        return ca;
    }


    
    [WebMethod(EnableSession = true)]
    public static string loaddetallesevento(string cod)
    {
        string ca = "";

        Institucion ins = new Institucion();
        Funciones fun = new Funciones();
        DataRow datos = ins.loaddetallesevento(cod);

        if (datos != null)
        {
            ca += "full@";
            ca += datos["codigo"].ToString() + "@";
            ca += datos["tipoevento"].ToString() + "@";
            ca += fun.convertFechaAño(datos["fecha"].ToString()) + "@";
            ca += datos["horainicio"].ToString() + "@";
            ca += datos["horafin"].ToString();
        }
        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string insertData(string codferiamunicipal, string tipoevento, string fecha, string horainicio, string horafin)
    {

        Institucion inst = new Institucion();
        string ca = "";

        DataRow insert = inst.insertferiaEvento(codferiamunicipal, tipoevento, fecha, horainicio, horafin);
        if (insert != null)
        {
            ca += "true@";
            ca += insert["codigo"].ToString();
        }
        else
        {
            ca = "Ocurrio un error al insertar@";
        }


        return ca;
    }

    
    [WebMethod(EnableSession = true)]
    public static string insertEspacioApropiacion(string tipo, string anio, string codgrupo)
    {

        Institucion inst = new Institucion();
        string ca = "";

        DataRow insert = inst.insertGrupoEspacioApropiacion(codgrupo, tipo, anio);
        if (insert != null)
        {
            ca += "true@";
            ca += insert["codigo"].ToString();
        }
        else
        {
            ca = "Ocurrio un error al insertar@";
        }


        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string cargarDocentesSeleccionados(string codencabezado)
    {
        string ca = "";

        Institucion ins = new Institucion();

        DataTable datos = ins.cargarDocentesSeleccionados(codencabezado);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "full@";
            string id = "";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                
                ca += "<tr id=\"tr" + datos.Rows[i]["codgradodocente"].ToString() + "\">";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["mun"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombreins"].ToString() + "-" + datos.Rows[i]["daneins"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombresede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["identificacion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombredoc"].ToString() + " " + datos.Rows[i]["apellidodoc"].ToString() + "</td>";//
                ca += "<td align='center'><img src='Imagenes/delete.png' alt='Eliminar docente' onclick='deletee(" + datos.Rows[i]["codgradodocente"].ToString() + ")' /></td>";
                ca += "</tr>";
                id += datos.Rows[i]["codgradodocente"].ToString() + "&";
            }
            ca += "@"+id;
        }

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string update(string codencabezado, string tipoevento, string fecha, string horainicio, string horafin)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        long update = inst.updateEventoEspacio(codencabezado, tipoevento, fecha, horainicio, horafin);
        if (update != -1)
        {
            ca = "true@";
        }
        else
        {
            ca = "false@";
            ca += "Ocurrio un error al actualizar datos@";
        }
        return ca;
    }


    

    [WebMethod(EnableSession = true)]
    public static string deleteDocentesSeleccionado(string codencabezado)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        long delete = inst.deleteDocentesSeleccionado(codencabezado);
        if (delete != -1)
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al eliminar docentes@";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string eliminar(string codigo)
    {

        Institucion inst = new Institucion();
        string ca = "";

        long delete = inst.deleteespacioapropiacion(codigo);
        if (delete != -1)
        {
            inst.deleteespacioapropiacion_evi(codigo);
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al eliminar docentes@";
        }
        return ca;
    }

    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    

}
