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

public partial class estrag008 : System.Web.UI.Page
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
            DataRow dato = est.buscarCodEstrategiaxCoordinador(Session["identificacion"].ToString());

            if (dato != null)
            {
                Session["CodEstraCoordinador"] = dato["codigo"].ToString();
                lblCodEstrategia.Text = Session["e"].ToString();
            }

        }
    }
    public void obtenerGET()
    {
        Session["e"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["e"]);
        Session["m"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        Session["s"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
        Session["a"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["a"]);

    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        if (Session["e"].ToString() == "1")
            Response.Redirect("estramomentos.aspx?m=" + Session["m"].ToString());
        else if(Session["e"].ToString() == "2")
            Response.Redirect("estradosmomentos.aspx?m=" + Session["m"].ToString());
    }




    //new code
    [WebMethod(EnableSession = true)]
    public static string cargarInstituciones()
    {
        string ca = "";

        Institucion inst = new Institucion();
        DataTable datos = inst.cargarInstitucion();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "inst@";
            ca += "<option value='0' disabled selected>Seleccione institución</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
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
            ca = "sedes&";
            ca += "<option value='' disabled selected>Seleccione sede...</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }

            DataRow datosInstitucion = inst.cargarDatosinstitucion(codigoins);
            if (datosInstitucion != null)
            {
                ca += "&" + datosInstitucion["email"].ToString() + "&" + datosInstitucion["telefono"].ToString();
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string grupoInvestigacion(string codigosede)
    {

        string ca = "";

        Institucion inst = new Institucion();

        DataTable gruposinvestigacion = inst.cargarGruposInvestigacionGroup(codigosede);

        if (gruposinvestigacion != null && gruposinvestigacion.Rows.Count > 0)
        {
            ca = "gruposinvestigacion@";
            ca += "<option value='' disabled selected>Seleccione grupo investigación...</option>";
            for (int i = 0; i < gruposinvestigacion.Rows.Count; i++)
            {
                ca += "<option value='" + gruposinvestigacion.Rows[i]["codigoproyecto"].ToString() + "'>" + gruposinvestigacion.Rows[i]["nombreproyecto"].ToString() + "</option>";
            }
        }
        else
        {
            ca = "vacio@<option value='sin' disabled selected>Sin grupos de investigación</option>";
        }

        return ca;
    }

    
    [WebMethod(EnableSession = true)]
    public static string insertestrag008(string grupoinvestigacion, string firmatesorero, string voboasesor, string fechadiligenciamiento)
    {
        Funciones fun = new Funciones();
        Institucion inst = new Institucion();
        string ca = "";
        DataRow insert = inst.procinsertestrag008(grupoinvestigacion, firmatesorero, voboasesor, fun.convertFechaAño(fechadiligenciamiento), HttpContext.Current.Session["CodEstraCoordinador"].ToString(), HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString(), HttpContext.Current.Session["a"].ToString());
        if (insert != null)
        {
            ca = "true@";
            ca += insert["codigo"].ToString();
        }
        else
        {
            ca = "Ocurrio un error al insertar estrag008@";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string updateestrag008(string codigoinstrumento, string grupoinvestigacion, string firmatesorero, string voboasesor, string fechadiligenciamiento)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        long update = inst.procupdateestrag008(codigoinstrumento, grupoinvestigacion, firmatesorero, voboasesor, fun.convertFechaAño(fechadiligenciamiento),HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString(), HttpContext.Current.Session["a"].ToString());
        if (update != -1)
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al actualizar datos de instrumento estrag008@";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadInstrumento(string codproyecto)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataRow datosinstrumento = inst.procloadInstrumentoestrag008(codproyecto);

        if (datosinstrumento != null)
        {
            ca = "true@";
            ca += datosinstrumento["codigo"].ToString()
                + "@" + datosinstrumento["firmamaestrotesorero"].ToString()
                + "@" + datosinstrumento["voboasesor"].ToString()
                + "@" + datosinstrumento["fechadiligenciamiento"].ToString();
        }
        else
        {
            ca = "vacio@";
            ca += "<tr><th> Fecha del gasto</th>";
            ca += "<th> Nombre del proveedor </th>";
            ca += "<th> Descripción del gasto </th>";
            ca += "<th> Valor unitario </th>";
            ca += "<th> Valor total </th>";
            ca += "</tr> ";
            ca += "<tr>";
            ca += "<td align=\"center\"><input type=\"text\" class=\"TextBox width-100\"  id =\"fechagasto1\" name =\"fechagasto1\"></td>";
            ca += "<td align=\"center\"><input type=\"text\" class=\"TextBox width-100\" id =\"nombreproveedor1\" name =\"nombreproveedor1\" ></td>";
            ca += "<td align=\"center\"><input type=\"text\" class=\"TextBox width-100\" id =\"descripciongasto1\" name =\"descripciongasto1\" ></td>";
            ca += "<td align=\"center\"><input type=\"text\" class=\"TextBox width-100\" id =\"valorunitario1\" name =\"valorunitario1\" onkeypress=\"return valideKey(event);\" ></td>";
            ca += "<td align=\"center\"><input type=\"text\" class=\"TextBox width-100\" id =\"valortotal1\" name =\"valortotal1\" onkeypress=\"return valideKey(event);\"  ></td>";
            ca += "</tr>";
        }

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string deleteMaterialestrag008(string codigoinstrumento)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        long delete = inst.procdeleteMaterialestrag008(codigoinstrumento);
        if (delete != -1)
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al eliminar materiales@";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string insertMaterialestrag008(string codigoinstrumento, string fechagasto, string nombreproveedor, string descripciongasto, string valorunitario, string valortotal)
    {

        Institucion inst = new Institucion();
        Funciones fun = new Funciones();
        string ca = "";

        DataRow insert = inst.procinsertMaterialestrag008(codigoinstrumento, fun.convertFechaAño(fechagasto), nombreproveedor, descripciongasto, valorunitario, valortotal);
        if (insert != null)
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al insertar material@";

        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadMaterialestrag008(string codigoinstrumento, int total)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.procloadMaterialestrag008(codigoinstrumento);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "mat@";
            ca += "<tr><th> Fecha del gasto</th>";
            ca += "<th> Nombre del proveedor </th>";
            ca += "<th> Descripción del gasto </th>";
            ca += "<th> Valor unitario </th>";
            ca += "<th> Valor total </th>";
            ca += "</tr> ";
            //ca += "@" + datoUsuario["cod"].ToString();
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr id=\"campus" + total + "\">";
                ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"fechagasto" + total + "\" name =\"fechagasto" + total + "\"  value=\"" + datos.Rows[i]["fechagasto"].ToString() + "\"></td>";
                ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"nombreproveedor" + total + "\" name =\"nombreproveedor" + total + "\"  value=\"" + datos.Rows[i]["nombreproveedor"].ToString() + "\"></td>";
                ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"descripciongasto" + total + "\" name =\"descripciongasto" + total + "\" value=\"" + datos.Rows[i]["descripciongasto"].ToString() + "\"></td>";
                ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox width-100\" id =\"valorunitario" + total + "\" name =\"valorunitario" + total + "\" onkeypress=\"return valideKey(event);\" value=\"" + datos.Rows[i]["valorunitario"].ToString() + "\"></td>";

                ca += "<td><table width=\"100%\"><tr id=\"radiotr" + total + "\"><td><input type=\"text\" id =\"valortotal" + total + "\" name =\"valortotal" + total + "\"  onkeypress =\"return valideKey(event);\" value=\"" + datos.Rows[i]["valortotal"].ToString() + "\" /></td>";

                if (i == datos.Rows.Count - 1)
                {
                    ca += "<td><button id=\"remove\" class=\"btn btn-danger\" onclick=\"fRemove(" + total + ")\" > -</button></td>";
                }
                else
                {
                    ca += "<td></td>";
                    total = total + 1;
                }
                ca += "</tr></table></td>";


            }
            ca += "@" + total;
        }
        else
        {
            ca = "<tr><th> Fecha del gasto</th>";
            ca += "<th> Nombre del proveedor </th>";
            ca += "<th> Descripción del gasto </th>";
            ca += "<th> Valor unitario </th>";
            ca += "<th> Valor total </th>";
            ca += "</tr> ";
            ca += "<tr>";
            ca += "<td align=\"center\"><input type=\"text\" class=\"TextBox width-100\"  id =\"fechagasto1\" name =\"fechagasto1\"></td>";
            ca += "<td align=\"center\"><input type=\"text\" class=\"TextBox width-100\" id =\"nombreproveedor1\" name =\"nombreproveedor1\"  ></td>";
            ca += "<td align=\"center\"><input type=\"text\" class=\"TextBox width-100\" id =\"descripciongasto1\" name =\"descripciongasto1\"  ></td>";
            ca += "<td align=\"center\"><input type=\"text\" class=\"TextBox width-100\" id =\"valorunitario1\" name =\"valorunitario1\" onkeypress=\"return valideKey(event);\" ></td>";
            ca += "<td align=\"center\"><input type=\"text\" class=\"TextBox width-100\" id =\"valortotal1\" name =\"valortotal1\" onkeypress=\"return valideKey(event);\" ></td>";
            ca += "</tr>";
        }

        return ca;
    }
    

}