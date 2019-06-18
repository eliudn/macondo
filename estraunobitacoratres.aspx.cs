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

public partial class estraunobitacoratres : System.Web.UI.Page
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
                Session["CodAsesorEstraCoordinador"] = dato["codigo"].ToString();

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

        //string coord = HttpContext.Current.Session["CodEstraCoordinador"].ToString();
        DataRow insert = inst.procinsertIntrumentobitacora3(codproyecto, respuestapregunta1, respuestapregunta2, HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString(), HttpContext.Current.Session["CodAsesorEstraCoordinador"].ToString());
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
    /*2016-10-25 modificado*/
    [WebMethod(EnableSession = true)]
    public static string updateInstrumento(string codigoinstrumento, string codproyecto, string respuestapregunta1, string respuestapregunta2)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        if (inst.updateIntrumentobitacora3(codigoinstrumento,codproyecto,respuestapregunta1,respuestapregunta2))
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

    /*2016-10-24 JONNY PACHECO metodo para  listar las bitacoras 3*/
   
    [WebMethod(EnableSession = true)]
    public static string listarBitacoraTres()
    {
        Institucion inst = new Institucion();
        string ca = "";

        DataTable datos = inst.listarBitacoraTres(HttpContext.Current.Session["CodAsesorEstraCoordinador"].ToString());
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
                ca += "<td>" + datos.Rows[i]["fechaejecucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["momento"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["sesion"].ToString() + "</td>";
                ca += "<td style='padding:5px;' ><a class='btn btn-success' onclick=\"$('#table').hide(), $('#form').fadeIn(500),  loadSelectBitacoraTres(" + datos.Rows[i]["codProyecto"].ToString() + "), traerPreguntasTres(" + datos.Rows[i]["codigo"].ToString() + ") \">Editar</a><br/><br/><a href='estraunobitacora3evi.aspx?codestrabitacora5=" + datos.Rows[i]["codigo"].ToString() + "' class='btn btn-primary'>Historial Bitácora</a><br /><br /><a class='btn btn-danger' onclick='eliminar(" + datos.Rows[i]["codigo"].ToString() + ")'>Eliminar</a><br/></td>";
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
    public static string loadSelectBitacoraTres(string codProyecto)
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataRow dato = estra.loadSelectBitacoraTres(codProyecto);
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
    public static string traerPreguntasTres(string codigo){
        string ca = "";
        Estrategias estra = new Estrategias();
        DataRow dato = estra.traerPreguntasTres(codigo);
        if (dato != null)
        {
            ca += "loadpreguntas@";
            ca += dato["codigo"].ToString()+"@"+dato["respuestapregunta1"].ToString() + "@" + dato["respuestapregunta2"].ToString();
        }
        return ca;
     }

    [WebMethod(EnableSession = true)]
    public static string eliminar(string codigo)
    {
        Estrategias estra = new Estrategias();
        string ca = "";



        estra.deleteBitacora3(codigo);

        return ca;
    }

}

