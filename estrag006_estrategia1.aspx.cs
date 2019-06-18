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
using System.IO;

public partial class estrag006_estrategia1 : System.Web.UI.Page
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
            //obtenerGET();
            //if (Session["e"] != null)
            //{
                if (Session["identificacion"] != null)
                {
                    DataRow dato = est.buscarCodEstraAsesorxCoordinador(Session["identificacion"].ToString());

                    if (dato != null)
                    {
                        Session["CodEstraAsesorCoordinador"] = dato["codigo"].ToString();
                      
                    }
                }
         
        }
    }
    public void obtenerGET()
    {
        Session["e"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["e"]);
        lblMomento.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        lblSesion.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);

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
            Response.Redirect("estramomentos.aspx?m=" + lblMomento.Text);
        else if (Session["e"].ToString() == "2")
            Response.Redirect("estradosmomentos.aspx?m=" + lblMomento.Text + "&s=" + lblSesion.Text);
    }
   
    [WebMethod(EnableSession = true)]
    public static string cargarListadoMaterialesAsesor()
    {
        string ca = "";

        Institucion inst = new Institucion();

        //int pagint = Convert.ToInt32(page);
        //int rowsint = Convert.ToInt32(rows);
        //int offset = (pagint - 1) * rowsint;

        DataTable datosmateriales = inst.cargarListadoMaterialesxAsesorEstra1(HttpContext.Current.Session["CodEstraAsesorCoordinador"].ToString(), "0", "1000");

        if (datosmateriales != null && datosmateriales.Rows.Count > 0)
        {
            DataTable datosCount = inst.cargarListadoMaterialesxAsesorCountEstra1(HttpContext.Current.Session["CodEstraAsesorCoordinador"].ToString());

            double cant = datosCount.Rows.Count;
            double val = Math.Ceiling(cant / 10);

            for (int i = 0; i < datosmateriales.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i+1) + "</td>";
                ca += "<td>" + datosmateriales.Rows[i]["asesor"].ToString() + "</td>";
                //ca += "<td>" + datosmateriales.Rows[i]["nombredepartamento"].ToString() + "</td>";
                ca += "<td>" + datosmateriales.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + datosmateriales.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + datosmateriales.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td align=\"center\"><br /><a class='btn btn-success' onclick=\"$('#listTable').hide(), $('#formTable').fadeIn(500), loadInstrumento(" + datosmateriales.Rows[i]["codigo"].ToString() + ")\">Editar</a><br/ ><br /><a href=\"estrag006Evidencia_estra1.aspx?cod=" + datosmateriales.Rows[i]["codigo"].ToString() + "\" class=\"btn btn-primary\">Evidencias</a><br/ ><br /><a onclick=\" eliminar(" + datosmateriales.Rows[i]["codigo"].ToString() + ") \" class=\"btn btn-danger\">Eliminar</a><br/ ><br /></td>";
                ca += "</tr>";
            }

            //ca += "@";
            //for (int j = 0; j < val; j++)
            //{
            //    if (pagint == (j + 1))
            //    {
            //        ca += " <span id='span" + (j + 1) + "' class=\"item current\" onclick='cargarListadoMemorias(\"" + (j + 1) + "\",\"10\")'>" + (j + 1) + "</span>";
            //    }
            //    else
            //    {
            //        ca += " <span id='span" + (j + 1) + "' class=\"item\" onclick='cargarListadoMemorias(\"" + (j + 1) + "\",\"10\")'>" + (j + 1) + "</span>";
            //    }
            //}
        }
        else
        {
            ca += "<tr><td colspan='11' align='center'>No se encontraron registros de materiales por parte del asesor.</td></tr>";
        }
     
        return ca;
    }
    [WebMethod(EnableSession = true)]
    public static string loadSelectInstrumento(string codigo)
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataRow dato = estra.loadSelectInstrumentog006Estra1(codigo);
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
    public static string datosSedes(string codigosede)
    {
        string ca = "";

        Institucion inst = new Institucion();

       
        DataRow datossede = inst.cargarDatosSede(codigosede);

        if (datossede != null)
        {
            ca = "datossede&";
            ca += "<option value='0' disabled>Seleccione departamento...</option>"
                + "<option value = '" + datossede["coddepartamento"].ToString() + "' selected>" + datossede["nombredepartamento"].ToString() + "</option>"
                + "&<option value='0' disabled>Seleccione municipio...</option>"
                + "<option value = '" + datossede["codmunicipio"].ToString() + "' selected>" + datossede["nombremunicipio"].ToString() + "</option>"
                + "&" + datossede["telefono"].ToString()
                + "&" + datossede["email"].ToString()
                + "&" + datossede["direccion"].ToString();

        }

        return ca;
    }

    // [WebMethod(EnableSession = true)]
    // public static string grupoInvestigacion(string codigosede)
    // {

        // //Funciones fun = new Funciones();

        // //fun.convertFechaAño();

        // string ca = "";

        // Institucion inst = new Institucion();

        // estrag006 est = new estrag006();

        // DataTable gruposinvestigacion = inst.cargarGruposInvestigacion(codigosede);

        // if (gruposinvestigacion != null && gruposinvestigacion.Rows.Count > 0)
        // {
            // ca = "gruposinvestigacion@";
            // ca += "<option value='' disabled selected>Seleccione grupo investigación...</option>";
            // for (int i = 0; i < gruposinvestigacion.Rows.Count; i++)
            // {
                // ca += "<option value='" + gruposinvestigacion.Rows[i]["codigo"].ToString() + "'>" + gruposinvestigacion.Rows[i]["nombregrupo"].ToString() + "</option>";
                // HttpContext.Current.Session["codProyectoSede"] = gruposinvestigacion.Rows[i]["codigo"].ToString();
            // }
        // }
        // else
        // {
            // ca = "vacio@<option value='sin' disabled selected>Sin grupos de investigación</option>";
        // }

        // return ca;
    // }

   
    [WebMethod(EnableSession = true)]
    public static string updateDatosSede(string codigo, string telefono,string email, string direccion)
    {

        //Funciones fun = new Funciones();

        //fun.convertFechaAño();

        Institucion inst = new Institucion();
        string ca = "";
        
        long update = inst.updateSede(codigo, telefono, email, direccion);
        if (update != -1)
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al actualizar datos de sedes@";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string insertInstrumento(string fechaentregamaterial, string codsede, string nombrequienrecibe)
    {


        Funciones fun = new Funciones();

        Institucion inst = new Institucion();

        string ca = "";

        string coord = HttpContext.Current.Session["CodEstraAsesorCoordinador"].ToString();
       

        DataRow insert = inst.procinsertIntrumentoEstra1(fun.convertFechaAño(fechaentregamaterial), codsede, nombrequienrecibe, coord);
        if (insert != null)
        {
            ca = "true@";
            ca += insert["codigo"].ToString();
            HttpContext.Current.Session["codProyectoSede"] = codsede;
        }
        else
        {
            ca = "Ocurrio un error al insertar datos de instrumento_g006@";
        }
        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string loadInstrumento(string codigo)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataRow datosinstrumento = inst.cargarDatosInstrumentoEstra1(codigo);
        HttpContext.Current.Session["codProyectoSede"] = codigo;
        if (datosinstrumento != null)
        {
            ca = "true@";
            ca += datosinstrumento["codasesorcoordinador"].ToString()
                + "@" + datosinstrumento["codsede"].ToString()
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

        long update = inst.updateInstrumentoEstra1(fun.convertFechaAño(fechaentregamaterial), nombrequienrecibe, codigoinstrumento);
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

        DataRow insert = inst.insertMaterialEstra1(codigoinstrumento, nombrematerial, cantidad, estado);
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

        long delete = inst.deleteMaterialEstra1(codigoinstrumento);
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

        DataTable datos = inst.procloadMaterialEstra1(codigoinstrumento);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "mat@";
            ca += "<tr><th> Nombre del material</th>";
            ca += "<th> Cantidad </th>";
            ca += "<th> Estado <br>";
            ca += "<table width=\"100%\" >";
            ca += "<tr>";
            ca += "<td width =\"30%\"> Bueno </td>";
            ca += "<td width =\"30%\"> Regular </td>";
            ca += "<td width =\"40%\"> No entregado </td>";
            ca += "</tr>";
            ca += "</table>";
            ca += "</th>";
            ca += "</tr> ";
            //ca += "@" + datoUsuario["cod"].ToString();
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr id=\"campus" + total + "\">";
                ca += "<td align=\"center\" ><input type=\"text\" class=\"TextBox\" id =\"nombrematerial" + total + "\" name =\"nombrematerial" + total + "\" class=\"width-100\" value=\""+ datos.Rows[i]["nombrematerial"].ToString() + "\" style=\"width:350px;\" disabled></td>";
                ca += "<td align=\"center\"><input type=\"text\" class=\"TextBox\" id =\"cantidad" + total + "\" name =\"cantidad" + total + "\"  onkeypress=\"return valideKey(event);\" class=\"width-100\" value=\"" + datos.Rows[i]["cantidad"].ToString() + "\" style=\"width:50px;\" ></td>";

                ca += "<td><table width=\"100%\" ><tr id=\"radiotr" + total + "\" >";
                ca += "<td width=\"30%\" style =\" text -align: center;\" align =\"center\" >";
                
                
                if (datos.Rows[i]["estado"].ToString() == "bueno")
                {
                    ca += "<input type=\"radio\" name =\"estado" + total + "\" checked=\"checked\"  value =\"bueno\" ></td>";
                    ca += "<td width=\"30%\" style =\" text-align: center;\" align =\"center\" >";
                    ca += "<input type=\"radio\" name =\"estado" + total + "\" value =\"regular\"></td>";
                    ca += "<td width=\"40%\" style =\" text-align: center;\" align =\"center\" >";
                    ca += "<input type=\"radio\" name =\"estado" + total + "\" value =\"noentregado\"></td>";
                }
                else if (datos.Rows[i]["estado"].ToString() == "regular")
                {
                    ca += "<input type=\"radio\" name =\"estado" + total + "\" value =\"bueno\" ></td>";
                    ca += "<td width=\"30%\" style =\" text-align: center;\" align =\"center\" >";
                    ca += "<input type=\"radio\" name =\"estado" + total + "\" checked=\"checked\"  value =\"regular\"></td>";
                    ca += "<td width=\"40%\" style =\" text-align: center;\" align =\"center\" >";
                    ca += "<input type=\"radio\" name =\"estado" + total + "\" value =\"noentregado\"></td>";
                }
                else if (datos.Rows[i]["estado"].ToString() == "noentregado")
                {
                    ca += "<input type=\"radio\" name =\"estado" + total + "\" value =\"bueno\" ></td>";
                    ca += "<td width=\"30%\" style =\" text-align: center;\" align =\"center\" >";
                    ca += "<input type=\"radio\" name =\"estado" + total + "\" value =\"regular\"></td>";
                    ca += "<td width=\"40%\" style =\" text-align: center;\" align =\"center\" >";
                    ca += "<input type=\"radio\" name =\"estado" + total + "\" checked=\"checked\" value =\"noentregado\"></td>";
                }
                else{

                }

                if (i == datos.Rows.Count-1)
                {
                    //ca += "<td><button id=\"remove\" class=\"btn btn-danger\" onclick=\"fRemove(" + total + ")\" > -</button></td>";
                }
                else
                {
                    //ca += "<td></td>";
                    total = total + 1;
                }
                ca += "</tr></table></td>";

               
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td align=\"center\">< input type=\"text\" class=\"TextBox\" width=\"350\" id =\"nombrematerial1\" name =\"nombrematerial1\" class=\"width -100\" ></td>";
            ca += "<td align=\"center\">< input type=\"text\" class=\"TextBox\" id =\"cantidad1\" name =\"cantidad1\" class=\"width-100\" ></td>";
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

    [WebMethod(EnableSession = true)]
    public static string deleteestrag006(string codigo)
    {
        string ca = "";
        Institucion inst = new Institucion();

        if (inst.eliminarEncabezadoEntregaMaterialEstra1(codigo))
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
    public static string eliminarEvidenciasEntregaMaterial(string codigo)
    {
        string ca = "";
        Institucion inst = new Institucion();

        if (inst.eliminarEvidenciasEntregaMaterialEstra1(codigo))
        {

            ca = "delete@";
        }
        else
        {
            ca = "vacio@";
        }

        return ca;
    }

}

