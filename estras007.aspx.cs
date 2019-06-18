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

public partial class estras007 : System.Web.UI.Page
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
            DataRow dato = estra.buscarCodEstraAsesorxCoordinador(Session["identificacion"].ToString());

            if (dato != null)
            {
                Session["CodEstraAsesorCoordinador"] = dato["codigo"].ToString();

            }
            else
            {
                mostrarmensaje("error", "ERROR: Ud. No es asesor de esta estrategía.");
            }

        }
    }
    public void obtenerGET()
    {
        Session["e"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["e"]);
        Session["m"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        Session["s"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);

    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("estradosmomentos.aspx");
    }

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

    //[WebMethod(EnableSession = true)]
    //public static string datosSedes(string codigosede)
    //{
    //    string ca = "";

    //    Institucion inst = new Institucion();

        

    //    DataRow datossede = inst.cargarDatosSede(codigosede);

    //    if (datossede != null)
    //    {
    //        ca = "datossede&";
    //        ca += "<option value='0' disabled>Seleccione departamento...</option>"
    //            + "<option value = '" + datossede["coddepartamento"].ToString() + "' selected>" + datossede["nombredepartamento"].ToString() + "</option>"
    //            + "&<option value='0' disabled>Seleccione municipio...</option>"
    //            + "<option value = '" + datossede["codmunicipio"].ToString() + "' selected>" + datossede["nombremunicipio"].ToString() + "</option>"
    //            + "&" + datossede["telefono"].ToString()
    //            + "&" + datossede["email"].ToString()
    //            + "&" + datossede["direccion"].ToString();
    //    }

    //    return ca;
    //}

    [WebMethod(EnableSession = true)]
    public static string grupoInvestigacion(string codigosede)
    {

        //Funciones fun = new Funciones();

        //fun.convertFechaAño();

        string ca = "";

        Institucion inst = new Institucion();



        DataTable gruposinvestigacion = inst.cargarGruposInvestigacion(codigosede, HttpContext.Current.Session["CodEstraAsesorCoordinador"].ToString());

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
    public static string insertG006(string codigosede)
    {

        //Funciones fun = new Funciones();

        //fun.convertFechaAño();

        string ca = "";

        Institucion inst = new Institucion();

        


        return ca;
    }

    //[WebMethod(EnableSession = true)]
    //public static string updateDatosSede(string codigo, string respuestapregunta1, string respuestapregunta2)
    //{

    //    //Funciones fun = new Funciones();

    //    //fun.convertFechaAño();

    //    Institucion inst = new Institucion();
    //    string ca = "";

    //    long update = inst.updateSede(codigo, respuestapregunta1, respuestapregunta2);
    //    if (update != -1)
    //    {
    //        ca = "true@";
    //    }
    //    else
    //    {
    //        ca = "Ocurrio un error al actualizar datos de sedes@";
    //    }
    //    return ca;
    //}

    [WebMethod(EnableSession = true)]
    public static string insertInstrumento(string codproyecto, string respuestapregunta1, string respuestapregunta2)
    {
        

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();

        string ca = "";

      
        DataRow insert = inst.procinsertIntrumentobitacora3(codproyecto, respuestapregunta1, respuestapregunta2,HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString(), HttpContext.Current.Session["CodAsesorEstraCoordinador"].ToString());
        if (insert != null)
        {
            ca = "true@";
            ca += insert["codigo"].ToString();
        }
        else
        {
            ca = "Ocurrio un error al insertar datos de instrumento_b03@";
        }
        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string loadInstrumento(string codproyectosede)
    {
        string ca = "";

        Institucion inst = new Institucion();

        

        DataRow datosinstrumento = inst.cargarDatosInstrumento(codproyectosede);

        if (datosinstrumento != null)
        {
            ca = "true@";
            ca += datosinstrumento["codestracoordinador"].ToString()
                + "@" + datosinstrumento["codproyectosede"].ToString()
                + "@" + datosinstrumento["nombrequienrecibe"].ToString()
                + "@" + datosinstrumento["fechaentregamaterial"].ToString()
                + "@" + datosinstrumento["codigo"].ToString();
        }
        else
        {
            ca = "vacio@";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string updateInstrumento(string fechaentregamaterial, string nombrequienrecibe,string codigoinstrumento)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        long update = inst.updateInstrumento(fun.convertFechaAño(fechaentregamaterial), nombrequienrecibe, codigoinstrumento);
        if (update != -1)
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al actualizar datos de instrumento@";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string insertMaterial(string codigoinstrumento, string nombrematerial, string cantidad, string estado)
    {

        Institucion inst = new Institucion();
        string ca = "";

        DataRow insert = inst.insertMaterial(codigoinstrumento, nombrematerial, cantidad, estado);
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
    public static string deleteMaterial(string codigoinstrumento)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        long delete = inst.deleteMaterial(codigoinstrumento);
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
    public static string loadMaterial(string codigoinstrumento,int total)
    {
        string ca = "";
        
        Institucion inst = new Institucion();

        DataTable datos = inst.procloadMaterial(codigoinstrumento);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "mat@";
            ca += "<tr><th> Nombre del materials</th>";
            ca += "<th> Cantidad </th>";
            ca += "<th> Estado <br>";
            ca += "<table width=\"100%\" >";
            ca += "<tr>";
            ca += "<td width =\"50%\"> Bueno </td>";
            ca += "<td width =\"50%\"> Regular </td>";
            ca += "</tr>";
            ca += "</table>";
            ca += "</th>";
            ca += "</tr> ";
            //ca += "@" + datoUsuario["cod"].ToString();
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr id=\"campus" + total + "\">";
                ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox\" id =\"nombrematerial" + total + "\" name =\"nombrematerial" + total + "\" class=\"width-100\" value=\""+ datos.Rows[i]["nombrematerial"].ToString() + "\"></td>";
                ca += "<td align=\"center\"><input type=\"text\" class=\"TextBox\" id =\"cantidad" + total + "\" name =\"cantidad" + total + "\"  onkeypress=\"return valideKey(event);\" class=\"width-100\" value=\"" + datos.Rows[i]["cantidad"].ToString() + "\" ></td>";

                ca += "<td><table width=\"100 %\" ><tr id=\"radiotr" + total + "\" >";
                ca += "<td width=\"50 %\" style =\" text -align: center;\" align =\"center\" >";
                
                
                if (datos.Rows[i]["estado"].ToString() == "bueno")
                {
                    ca += "<input type=\"radio\" name =\"estado" + total + "\" checked=\"checked\"  value =\"bueno\" ></td>";
                    ca += "<td width=\"50 %\" style =\" text-align: center;\" align =\"center\" >";
                    ca += "<input type=\"radio\" name =\"estado" + total + "\" value =\"regular\"></td>";
                }
                else if (datos.Rows[i]["estado"].ToString() == "regular")
                {
                    ca += "<input type=\"radio\" name =\"estado" + total + "\" value =\"bueno\" ></td>";
                    ca += "<td width=\"50 %\" style =\" text-align: center;\" align =\"center\" >";
                    ca += "<input type=\"radio\" name =\"estado" + total + "\" checked=\"checked\"  value =\"regular\"></td>";
                }
                else
                {
                    //ca += "<input type=\"radio\" name =\"estado" + total + "\" checked=\"checked\"  value =\"bueno\" ></td>";
                    //ca += "<td width=\"50 %\" style =\" text-align: center;\" align =\"center\" >";
                    //ca += "<input type=\"radio\" name =\"estado" + total + "\"  value =\"regular\"></td>";
                }

                if (i == datos.Rows.Count-1)
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
            ca += "<tr>";
            ca += "<td align=\"center\"><input type=\"text\" class=\"TextBox\" width=\"350\" id=\"nombrematerial1\" name=\"nombrematerial1\" class=\"width -100\" ></td>";
            ca += "<td align=\"center\"><input type=\"text\" class=\"TextBox\" id=\"cantidad1\" name=\"cantidad1\" class=\"width-100\"></td>";
            ca += "<td>";
            ca += "<table width=\"100%\"> ";
            ca += " <tr>";
            ca += "<td width=\"50%\" style =\"text-align: center;\" ><input type = \"radio\" name =\"estado1\" value =\"bueno\" ></td>";
            ca += "<td width = \"50%\" style =\"text-align: center;\" ><input type = \"radio\" name =\"estado1\" value =\"regular\" ></td>";
            ca += "</tr>";
            ca += "</table>";
            ca += "</td>";
            ca += "</tr>";
        }

        return ca;
    }


}

