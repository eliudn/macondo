using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;

public partial class verestraunobitacoracinco : System.Web.UI.Page
{
    
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["codperfil"] != null)
        {

        }
        else
            Response.Redirect("Default.aspx",true);
    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 

        if (!IsPostBack)
        {
            obtenerGET();
            if (Session["identificacion"] != null)
            {
                Estrategias estra = new Estrategias();
                DataRow dato = estra.buscarCodEstraAsesorxCoordinador(Session["identificacion"].ToString());

                if (dato != null)
                {
                    Session["codEstraAsesorCoordinador"] = dato["codigo"].ToString();

                }
            }
         
        }
    }

    public void obtenerGET()
    {
        Session["e"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["e"]);
        Session["m"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        Session["s"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);

    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("estramomentos.aspx");
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
        ca +=  HttpContext.Current.Session["e"].ToString() + "@" + HttpContext.Current.Session["m"].ToString() + "@" + HttpContext.Current.Session["s"].ToString();
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
    public static string cargarMunicipios(string coddepartamento)
    {

        //Funciones fun = new Funciones();

        //fun.convertFechaAño();

        string ca = "";

        Institucion inst = new Institucion();

        DataTable municipios = inst.cargarciudadxDepartamento(coddepartamento);

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
    public static string cargarSedesInstitucion(string codInstitucion)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarSedesInstitucion(codInstitucion);
        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<option value='0' disabled selected>Seleccione institucion</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarLineaInvestigacion(string codSede)
    {
        string ca = "";

        Estrategias estra = new Estrategias();

        DataTable datos = estra.cargarLineaInvestigacionxAsesor(codSede, HttpContext.Current.Session["codEstraAsesorCoordinador"].ToString());
        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<option value='0' disabled selected>Seleccione grupo investigacion</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombregrupo"].ToString() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession=true)]
    public static string encabezado(string codProyecto, string objetivoFinal, string nomTrayectoIndagacion, string dificultadesFortalezas, string principalesCaracteristicas, string importanciaInvestigacion, string importanciaIEP, string general, string especifico, string nomTrayectoIndagacion2do, string nomTrayectoIndagacion3ro, string nomTrayectoIndagacion4to, string nomTrayectoIndagacion5to, string nomTrayectoIndagacion6to, string nomTrayectoIndagacion7mo, string nomTrayectoIndagacion8vo)
    {
        string ca = "";
        Estrategias estra = new Estrategias();
        DataRow dato = estra.encabezadoBitacora5(codProyecto, objetivoFinal, nomTrayectoIndagacion, dificultadesFortalezas, principalesCaracteristicas, importanciaInvestigacion, importanciaIEP, general, especifico, HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString(), nomTrayectoIndagacion2do, nomTrayectoIndagacion3ro, nomTrayectoIndagacion4to, nomTrayectoIndagacion5to, nomTrayectoIndagacion6to, nomTrayectoIndagacion7mo, nomTrayectoIndagacion8vo);
        if (dato != null)
        {
            ca += dato["codigo"] + "@" + HttpContext.Current.Session["e"].ToString() + "@" + HttpContext.Current.Session["m"].ToString() + "@" + HttpContext.Current.Session["s"].ToString();
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string detalleBitacora5(string codEstraBitacora, string actividad, string herramienta, string responsable, string duracion, string presupuesto)
    {
        string ca = "";
        Estrategias estra = new Estrategias();
        if (estra.bitacora5Detalles(codEstraBitacora, actividad, herramienta, responsable, duracion, presupuesto))
        {
            ca = "true1";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string detalleBitacora5_2do(string codEstraBitacora, string actividad, string herramienta, string responsable, string duracion, string presupuesto)
    {
        string ca = "";
        Estrategias estra = new Estrategias();
        if (estra.bitacora5Detalles_2do(codEstraBitacora, actividad, herramienta, responsable, duracion, presupuesto))
        {
            ca = "true2";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string detalleBitacora5_3ro(string codEstraBitacora, string actividad, string herramienta, string responsable, string duracion, string presupuesto)
    {
        string ca = "";
        Estrategias estra = new Estrategias();
        if (estra.bitacora5Detalles_3ro(codEstraBitacora, actividad, herramienta, responsable, duracion, presupuesto))
        {
            ca = "true3";
        }

        return ca;
    }
     [WebMethod(EnableSession = true)]
    public static string detalleBitacora5_4to(string codEstraBitacora, string actividad, string herramienta, string responsable, string duracion, string presupuesto)
    {
        string ca = "";
        Estrategias estra = new Estrategias();
        if (estra.bitacora5Detalles_4to(codEstraBitacora, actividad, herramienta, responsable, duracion, presupuesto))
        {
            ca = "true4";
        }

        return ca;
    }
     [WebMethod(EnableSession = true)]
    public static string detalleBitacora5_5to(string codEstraBitacora, string actividad, string herramienta, string responsable, string duracion, string presupuesto)
    {
        string ca = "";
        Estrategias estra = new Estrategias();
        if (estra.bitacora5Detalles_5to(codEstraBitacora, actividad, herramienta, responsable, duracion, presupuesto))
        {
            ca = "true5";
        }

        return ca;
    }
     [WebMethod(EnableSession = true)]
    public static string detalleBitacora5_6to(string codEstraBitacora, string actividad, string herramienta, string responsable, string duracion, string presupuesto)
    {
        string ca = "";
        Estrategias estra = new Estrategias();
        if (estra.bitacora5Detalles_6to(codEstraBitacora, actividad, herramienta, responsable, duracion, presupuesto))
        {
            ca = "true6";
        }

        return ca;
    }
     [WebMethod(EnableSession = true)]
    public static string detalleBitacora5_7mo(string codEstraBitacora, string actividad, string herramienta, string responsable, string duracion, string presupuesto)
    {
        string ca = "";
        Estrategias estra = new Estrategias();
        if (estra.bitacora5Detalles_7mo(codEstraBitacora, actividad, herramienta, responsable, duracion, presupuesto))
        {
            ca = "true7";
        }

        return ca;
    }
     [WebMethod(EnableSession = true)]
    public static string detalleBitacora5_8vo(string codEstraBitacora, string actividad, string herramienta, string responsable, string duracion, string presupuesto)
    {
        string ca = "";
        Estrategias estra = new Estrategias();
        if (estra.bitacora5Detalles_8vo(codEstraBitacora, actividad, herramienta, responsable, duracion, presupuesto))
        {
            ca = "true8";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
     public static string listadobitacora5(string codasesorcoordinador)
    {
        string ca = "";

        Estrategias estra = new Estrategias();

        DataTable datos = estra.listarBitacoraCincoSupervision(codasesorcoordinador);
        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["departamento"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombregrupo"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["fechacreado"].ToString() + "</td>";
                ca += "<td style='padding:5px;text-align:center' ><a class='btn btn-success' onclick=\"$('#table').hide(), $('#form').fadeIn(500),  loadSelectBitacoraCinco(" + datos.Rows[i]["codigo"].ToString() + "), loadBitacora(" + datos.Rows[i]["codigo"].ToString() + ") \">Ver</a><br /><br /><a href='estraunobitacoracincoevidencias.aspx?codestrabitacora5=" + datos.Rows[i]["codigo"].ToString() + "' class='btn btn-primary'>Evidencias</a><br /><br /></td>";
                ca += "</tr>";
            }
        }
        else
        {
            ca += "<tr><td colspan='11'>No se encontraron registros por parte del asesor.</td></tr>";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadSelectBitacoraCinco(string codigo)
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataRow dato = estra.loadSelectBitacoraCinco(codigo);
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
    public static string loadBitacora(string codigo)
    {
        string ca = "";

        Estrategias estra = new Estrategias();

        DataRow dato = estra.loadBitacoraCinco(codigo);
        if (dato != null)
        {

            ca += dato["objetivofinal"].ToString() + "-";
            ca += dato["nomtrayectoindagacion"].ToString() + "-";
            ca += dato["dificultadesfortalezas"].ToString() + "-";
            ca += dato["principalescaracteristicas"].ToString() + "-";
            ca += dato["importanciasinvestigacion"].ToString() + "-";
            ca += dato["importanciaiep"].ToString() + "-";

            ca += dato["general"].ToString() + "-";
            ca += dato["especifico"].ToString() + "-";
            ca += dato["nomtrayectoindagacion2"].ToString() + "-";
            ca += dato["nomtrayectoindagacion3"].ToString() + "-";
            ca += dato["nomtrayectoindagacion4"].ToString() + "-";
            ca += dato["nomtrayectoindagacion5"].ToString() + "-";
            ca += dato["nomtrayectoindagacion6"].ToString() + "-";
            ca += dato["nomtrayectoindagacion7"].ToString() + "-";
            ca += dato["nomtrayectoindagacion8"].ToString() + "-";

        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadPrimerTrayecto(string codigoinstrumento)
    {
        string html = "";
        int total = 1;
        Estrategias est = new Estrategias();

        DataTable datos = est.cargarPrimerTrayectobitacora5(codigoinstrumento);

        if (datos != null && datos.Rows.Count > 0)
        {
            html = "mat@";
            html += "<tr><th> Actividades</th>";
            html += "<th> Herramientas necesarias para desarrollar la actividad </th>";
            html += "<th> Responsable de la actividad </th>";
            html += "<th> Duración en meses </th>";
            html += "<th> Presupuesto requerido </th>";
            html += "</tr> ";
            //ca += "@" + datoUsuario["cod"].ToString();
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                html += "<tr id='oCampus" + total + "'>";
                html += "<td><input type='text' id='actividad" + total + "' value='" + datos.Rows[i]["actividades"].ToString() + "'  class='TextBox' style='width: 98%;'></td>";
                html += "<td><input type='text' id='herramienta" + total + "' value='" + datos.Rows[i]["herramientas"].ToString() + "'  class='TextBox' style='width: 98%;'></td>";
                html += "<td><input type='text' id='responsable" + total + "' value='" + datos.Rows[i]["responsable"].ToString() + "'  class='TextBox' style='width: 98%;'></td>";
                html += "<td><input type='number' id='duracion" + total + "'  value='" + datos.Rows[i]["duracionmeses"].ToString() + "' class='TextBox' style='width: 98%;' min='0' onkeypress='return isNumberKey(event);'/></td>";
                html += "<td id='oRadiotr" + total + "'><input type='text' id='presupuesto" + total + "' value='" + datos.Rows[i]["presupuestorequerido"].ToString() + "'  class='TextBox' style='width: 98%;' onkeypress='return isNumberKey(event);'  />";

                if (i == datos.Rows.Count - 1)
                {
                        html += "<input type='button' id='remove1' class='btn btn-danger' onclick='fRemove1(" + total + ");' value='-'/>";
                }
                else
                {
                    //html += "<td></td>";
                    total = total + 1;
                }
                html += "</td></tr>";


            }
            html += "@" + total;
        }
        else
        {
            //ca += "<tr>";
            //ca += "<td align=\"center\">< input type=\"text\" class=\"TextBox\" width=\"350\" id =\"nombrematerial1\" name =\"nombrematerial1\" class=\"width -100\" ></td>";
            //ca += "<td align=\"center\">< input type=\"text\" class=\"TextBox\" id =\"cantidad1\" name =\"cantidad1\" class=\"width-100\" ></td>";
            //ca += "<td>";
            //ca += "<table width=\"100%\"> ";
            //ca += " <tr>";
            //ca += "<td width=\"50%\" style =\"text-align: center;\" ><input type = \"radio\" name =\"estado1\" value =\"bueno\" ></td>";
            //ca += "<td width = \"50%\" style =\"text-align: center;\" ><input type = \"radio\" name =\"estado1\" value =\"regular\" ></td>";
            //ca += "</tr>";
            //ca += "</table>";
            //ca += "</td>";
            //ca += "</tr>";
        }

        return html;
    }

    [WebMethod(EnableSession = true)]
    public static string loadSegundoTrayecto(string codigoinstrumento)
    {
        string html = "";
        int total = 1;
        Estrategias est = new Estrategias();

        DataTable datos = est.cargarSegundoTrayectobitacora5(codigoinstrumento);

        if (datos != null && datos.Rows.Count > 0)
        {
            html = "mat@";
            html += "<tr><th> Actividades</th>";
            html += "<th> Herramientas necesarias para desarrollar la actividad </th>";
            html += "<th> Responsable de la actividad </th>";
            html += "<th> Duración en meses </th>";
            html += "<th> Presupuesto requerido </th>";
            html += "</tr> ";
            //ca += "@" + datoUsuario["cod"].ToString();
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                html += "<tr id='oCampus2do" + total + "'>";
                html += "<td><input type='text' id='actividad2do" + total + "' value='" + datos.Rows[i]["actividades"].ToString() + "'  class='TextBox' style='width: 98%;'></td>";
                html += "<td><input type='text' id='herramienta2do" + total + "' value='" + datos.Rows[i]["herramientas"].ToString() + "'  class='TextBox' style='width: 98%;'></td>";
                html += "<td><input type='text' id='responsable2do" + total + "' value='" + datos.Rows[i]["responsable"].ToString() + "'  class='TextBox' style='width: 98%;'></td>";
                html += "<td><input type='number' id='duracion2do" + total + "'  value='" + datos.Rows[i]["duracionmeses"].ToString() + "' class='TextBox' style='width: 98%;' min='0' onkeypress='return isNumberKey(event);'/></td>";
                html += "<td id='oRadiotr2do" + total + "'><input type='text' id='presupuesto2do" + total + "' value='" + datos.Rows[i]["presupuestorequerido"].ToString() + "'  class='TextBox' style='width: 98%;' onkeypress='return isNumberKey(event);'  />";

                if (i == datos.Rows.Count - 1)
                {
                    html += "<input type='button' id='remove12do' class='btn btn-danger' onclick='fRemove12do(" + total + ");' value='-'/>";
                }
                else
                {
                    //html += "<td></td>";
                    total = total + 1;
                }
                html += "</td></tr>";


            }
            html += "@" + total;
        }
        else
        {
            //ca += "<tr>";
            //ca += "<td align=\"center\">< input type=\"text\" class=\"TextBox\" width=\"350\" id =\"nombrematerial1\" name =\"nombrematerial1\" class=\"width -100\" ></td>";
            //ca += "<td align=\"center\">< input type=\"text\" class=\"TextBox\" id =\"cantidad1\" name =\"cantidad1\" class=\"width-100\" ></td>";
            //ca += "<td>";
            //ca += "<table width=\"100%\"> ";
            //ca += " <tr>";
            //ca += "<td width=\"50%\" style =\"text-align: center;\" ><input type = \"radio\" name =\"estado1\" value =\"bueno\" ></td>";
            //ca += "<td width = \"50%\" style =\"text-align: center;\" ><input type = \"radio\" name =\"estado1\" value =\"regular\" ></td>";
            //ca += "</tr>";
            //ca += "</table>";
            //ca += "</td>";
            //ca += "</tr>";
        }

        return html;
    }

    [WebMethod(EnableSession = true)]
    public static string loadTercerTrayecto(string codigoinstrumento)
    {
        string html = "";
        int total = 1;
        Estrategias est = new Estrategias();

        DataTable datos = est.cargarTercerTrayectobitacora5(codigoinstrumento);

        if (datos != null && datos.Rows.Count > 0)
        {
            html = "mat@";
            html += "<tr><th> Actividades</th>";
            html += "<th> Herramientas necesarias para desarrollar la actividad </th>";
            html += "<th> Responsable de la actividad </th>";
            html += "<th> Duración en meses </th>";
            html += "<th> Presupuesto requerido </th>";
            html += "</tr> ";
            //ca += "@" + datoUsuario["cod"].ToString();
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                html += "<tr id='oCampus3ro" + total + "'>";
                html += "<td><input type='text' id='actividad3ro" + total + "' value='" + datos.Rows[i]["actividades"].ToString() + "'  class='TextBox' style='width: 98%;'></td>";
                html += "<td><input type='text' id='herramienta3ro" + total + "' value='" + datos.Rows[i]["herramientas"].ToString() + "'  class='TextBox' style='width: 98%;'></td>";
                html += "<td><input type='text' id='responsable3ro" + total + "' value='" + datos.Rows[i]["responsable"].ToString() + "'  class='TextBox' style='width: 98%;'></td>";
                html += "<td><input type='number' id='duracion3ro" + total + "'  value='" + datos.Rows[i]["duracionmeses"].ToString() + "' class='TextBox' style='width: 98%;' min='0' onkeypress='return isNumberKey(event);'/></td>";
                html += "<td id='oRadiotr3ro" + total + "'><input type='text' id='presupuesto3ro" + total + "' value='" + datos.Rows[i]["presupuestorequerido"].ToString() + "'  class='TextBox' style='width: 98%;' onkeypress='return isNumberKey(event);'  />";

                if (i == datos.Rows.Count - 1)
                {
                    html += "<input type='button' id='remove13ro' class='btn btn-danger' onclick='fRemove13ro(" + total + ");' value='-'/>";
                }
                else
                {
                    //html += "<td></td>";
                    total = total + 1;
                }
                html += "</td></tr>";


            }
            html += "@" + total;
        }
        else
        {
            //ca += "<tr>";
            //ca += "<td align=\"center\">< input type=\"text\" class=\"TextBox\" width=\"350\" id =\"nombrematerial1\" name =\"nombrematerial1\" class=\"width -100\" ></td>";
            //ca += "<td align=\"center\">< input type=\"text\" class=\"TextBox\" id =\"cantidad1\" name =\"cantidad1\" class=\"width-100\" ></td>";
            //ca += "<td>";
            //ca += "<table width=\"100%\"> ";
            //ca += " <tr>";
            //ca += "<td width=\"50%\" style =\"text-align: center;\" ><input type = \"radio\" name =\"estado1\" value =\"bueno\" ></td>";
            //ca += "<td width = \"50%\" style =\"text-align: center;\" ><input type = \"radio\" name =\"estado1\" value =\"regular\" ></td>";
            //ca += "</tr>";
            //ca += "</table>";
            //ca += "</td>";
            //ca += "</tr>";
        }

        return html;
    }

    [WebMethod(EnableSession = true)]
    public static string loadCuartoTrayecto(string codigoinstrumento)
    {
        string html = "";
        int total = 1;
        Estrategias est = new Estrategias();

        DataTable datos = est.cargarCuartoTrayectobitacora5(codigoinstrumento);

        if (datos != null && datos.Rows.Count > 0)
        {
            html = "mat@";
            html += "<tr><th> Actividades</th>";
            html += "<th> Herramientas necesarias para desarrollar la actividad </th>";
            html += "<th> Responsable de la actividad </th>";
            html += "<th> Duración en meses </th>";
            html += "<th> Presupuesto requerido </th>";
            html += "</tr> ";
            //ca += "@" + datoUsuario["cod"].ToString();
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                html += "<tr id='oCampus4to" + total + "'>";
                html += "<td><input type='text' id='actividad4to" + total + "' value='" + datos.Rows[i]["actividades"].ToString() + "'  class='TextBox' style='width: 98%;'></td>";
                html += "<td><input type='text' id='herramienta4to" + total + "' value='" + datos.Rows[i]["herramientas"].ToString() + "'  class='TextBox' style='width: 98%;'></td>";
                html += "<td><input type='text' id='responsable4to" + total + "' value='" + datos.Rows[i]["responsable"].ToString() + "'  class='TextBox' style='width: 98%;'></td>";
                html += "<td><input type='number' id='duracion4to" + total + "'  value='" + datos.Rows[i]["duracionmeses"].ToString() + "' class='TextBox' style='width: 98%;' min='0' onkeypress='return isNumberKey(event);'/></td>";
                html += "<td id='oRadiotr4to" + total + "'><input type='text' id='presupuesto4to" + total + "' value='" + datos.Rows[i]["presupuestorequerido"].ToString() + "'  class='TextBox' style='width: 98%;' onkeypress='return isNumberKey(event);'  />";

                if (i == datos.Rows.Count - 1)
                {
                    html += "<input type='button' id='remove14to' class='btn btn-danger' onclick='fRemove14to(" + total + ");' value='-'/>";
                }
                else
                {
                    //html += "<td></td>";
                    total = total + 1;
                }
                html += "</td></tr>";


            }
            html += "@" + total;
        }
        else
        {
            //ca += "<tr>";
            //ca += "<td align=\"center\">< input type=\"text\" class=\"TextBox\" width=\"350\" id =\"nombrematerial1\" name =\"nombrematerial1\" class=\"width -100\" ></td>";
            //ca += "<td align=\"center\">< input type=\"text\" class=\"TextBox\" id =\"cantidad1\" name =\"cantidad1\" class=\"width-100\" ></td>";
            //ca += "<td>";
            //ca += "<table width=\"100%\"> ";
            //ca += " <tr>";
            //ca += "<td width=\"50%\" style =\"text-align: center;\" ><input type = \"radio\" name =\"estado1\" value =\"bueno\" ></td>";
            //ca += "<td width = \"50%\" style =\"text-align: center;\" ><input type = \"radio\" name =\"estado1\" value =\"regular\" ></td>";
            //ca += "</tr>";
            //ca += "</table>";
            //ca += "</td>";
            //ca += "</tr>";
        }

        return html;
    }
     [WebMethod(EnableSession = true)]
    public static string loadQuintoTrayecto(string codigoinstrumento)
    {
        string html = "";
        int total = 1;
        Estrategias est = new Estrategias();

        DataTable datos = est.cargarQuintoTrayectobitacora5(codigoinstrumento);

        if (datos != null && datos.Rows.Count > 0)
        {
            html = "mat@";
            html += "<tr><th> Actividades</th>";
            html += "<th> Herramientas necesarias para desarrollar la actividad </th>";
            html += "<th> Responsable de la actividad </th>";
            html += "<th> Duración en meses </th>";
            html += "<th> Presupuesto requerido </th>";
            html += "</tr> ";
            //ca += "@" + datoUsuario["cod"].ToString();
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                html += "<tr id='oCampus5to" + total + "'>";
                html += "<td><input type='text' id='actividad5to" + total + "' value='" + datos.Rows[i]["actividades"].ToString() + "'  class='TextBox' style='width: 98%;'></td>";
                html += "<td><input type='text' id='herramienta5to" + total + "' value='" + datos.Rows[i]["herramientas"].ToString() + "'  class='TextBox' style='width: 98%;'></td>";
                html += "<td><input type='text' id='responsable5to" + total + "' value='" + datos.Rows[i]["responsable"].ToString() + "'  class='TextBox' style='width: 98%;'></td>";
                html += "<td><input type='number' id='duracion5to" + total + "'  value='" + datos.Rows[i]["duracionmeses"].ToString() + "' class='TextBox' style='width: 98%;' min='0' onkeypress='return isNumberKey(event);'/></td>";
                html += "<td id='oRadiotr5to" + total + "'><input type='text' id='presupuesto5to" + total + "' value='" + datos.Rows[i]["presupuestorequerido"].ToString() + "'  class='TextBox' style='width: 98%;' onkeypress='return isNumberKey(event);'  />";

                if (i == datos.Rows.Count - 1)
                {
                    html += "<input type='button' id='remove15to' class='btn btn-danger' onclick='fRemove15to(" + total + ");' value='-'/>";
                }
                else
                {
                    //html += "<td></td>";
                    total = total + 1;
                }
                html += "</td></tr>";


            }
            html += "@" + total;
        }
        else
        {
            //ca += "<tr>";
            //ca += "<td align=\"center\">< input type=\"text\" class=\"TextBox\" width=\"350\" id =\"nombrematerial1\" name =\"nombrematerial1\" class=\"width -100\" ></td>";
            //ca += "<td align=\"center\">< input type=\"text\" class=\"TextBox\" id =\"cantidad1\" name =\"cantidad1\" class=\"width-100\" ></td>";
            //ca += "<td>";
            //ca += "<table width=\"100%\"> ";
            //ca += " <tr>";
            //ca += "<td width=\"50%\" style =\"text-align: center;\" ><input type = \"radio\" name =\"estado1\" value =\"bueno\" ></td>";
            //ca += "<td width = \"50%\" style =\"text-align: center;\" ><input type = \"radio\" name =\"estado1\" value =\"regular\" ></td>";
            //ca += "</tr>";
            //ca += "</table>";
            //ca += "</td>";
            //ca += "</tr>";
        }

        return html;
    }
     [WebMethod(EnableSession = true)]
    public static string loadSextoTrayecto(string codigoinstrumento)
    {
        string html = "";
        int total = 1;
        Estrategias est = new Estrategias();

        DataTable datos = est.cargarSextoTrayectobitacora5(codigoinstrumento);

        if (datos != null && datos.Rows.Count > 0)
        {
            html = "mat@";
            html += "<tr><th> Actividades</th>";
            html += "<th> Herramientas necesarias para desarrollar la actividad </th>";
            html += "<th> Responsable de la actividad </th>";
            html += "<th> Duración en meses </th>";
            html += "<th> Presupuesto requerido </th>";
            html += "</tr> ";
            //ca += "@" + datoUsuario["cod"].ToString();
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                html += "<tr id='oCampus6to" + total + "'>";
                html += "<td><input type='text' id='actividad6to" + total + "' value='" + datos.Rows[i]["actividades"].ToString() + "'  class='TextBox' style='width: 98%;'></td>";
                html += "<td><input type='text' id='herramienta6to" + total + "' value='" + datos.Rows[i]["herramientas"].ToString() + "'  class='TextBox' style='width: 98%;'></td>";
                html += "<td><input type='text' id='responsable6to" + total + "' value='" + datos.Rows[i]["responsable"].ToString() + "'  class='TextBox' style='width: 98%;'></td>";
                html += "<td><input type='number' id='duracion6to" + total + "'  value='" + datos.Rows[i]["duracionmeses"].ToString() + "' class='TextBox' style='width: 98%;' min='0' onkeypress='return isNumberKey(event);'/></td>";
                html += "<td id='oRadiotr6to" + total + "'><input type='text' id='presupuesto6to" + total + "' value='" + datos.Rows[i]["presupuestorequerido"].ToString() + "'  class='TextBox' style='width: 98%;' onkeypress='return isNumberKey(event);'  />";

                if (i == datos.Rows.Count - 1)
                {
                    html += "<input type='button' id='remove16to' class='btn btn-danger' onclick='fRemove16to(" + total + ");' value='-'/>";
                }
                else
                {
                    //html += "<td></td>";
                    total = total + 1;
                }
                html += "</td></tr>";


            }
            html += "@" + total;
        }
        else
        {
            //ca += "<tr>";
            //ca += "<td align=\"center\">< input type=\"text\" class=\"TextBox\" width=\"350\" id =\"nombrematerial1\" name =\"nombrematerial1\" class=\"width -100\" ></td>";
            //ca += "<td align=\"center\">< input type=\"text\" class=\"TextBox\" id =\"cantidad1\" name =\"cantidad1\" class=\"width-100\" ></td>";
            //ca += "<td>";
            //ca += "<table width=\"100%\"> ";
            //ca += " <tr>";
            //ca += "<td width=\"50%\" style =\"text-align: center;\" ><input type = \"radio\" name =\"estado1\" value =\"bueno\" ></td>";
            //ca += "<td width = \"50%\" style =\"text-align: center;\" ><input type = \"radio\" name =\"estado1\" value =\"regular\" ></td>";
            //ca += "</tr>";
            //ca += "</table>";
            //ca += "</td>";
            //ca += "</tr>";
        }

        return html;
    }
     [WebMethod(EnableSession = true)]
    public static string loadSeptimoTrayecto(string codigoinstrumento)
    {
        string html = "";
        int total = 1;
        Estrategias est = new Estrategias();

        DataTable datos = est.cargarSeptimoTrayectobitacora5(codigoinstrumento);

        if (datos != null && datos.Rows.Count > 0)
        {
            html = "mat@";
            html += "<tr><th> Actividades</th>";
            html += "<th> Herramientas necesarias para desarrollar la actividad </th>";
            html += "<th> Responsable de la actividad </th>";
            html += "<th> Duración en meses </th>";
            html += "<th> Presupuesto requerido </th>";
            html += "</tr> ";
            //ca += "@" + datoUsuario["cod"].ToString();
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                html += "<tr id='oCampus7mo" + total + "'>";
                html += "<td><input type='text' id='actividad7mo" + total + "' value='" + datos.Rows[i]["actividades"].ToString() + "'  class='TextBox' style='width: 98%;'></td>";
                html += "<td><input type='text' id='herramienta7mo" + total + "' value='" + datos.Rows[i]["herramientas"].ToString() + "'  class='TextBox' style='width: 98%;'></td>";
                html += "<td><input type='text' id='responsable7mo" + total + "' value='" + datos.Rows[i]["responsable"].ToString() + "'  class='TextBox' style='width: 98%;'></td>";
                html += "<td><input type='number' id='duracion7mo" + total + "'  value='" + datos.Rows[i]["duracionmeses"].ToString() + "' class='TextBox' style='width: 98%;' min='0' onkeypress='return isNumberKey(event);'/></td>";
                html += "<td id='oRadiotr7mo" + total + "'><input type='text' id='presupuesto7mo" + total + "' value='" + datos.Rows[i]["presupuestorequerido"].ToString() + "'  class='TextBox' style='width: 98%;' onkeypress='return isNumberKey(event);'  />";

                if (i == datos.Rows.Count - 1)
                {
                    html += "<input type='button' id='remove17mo' class='btn btn-danger' onclick='fRemove17mo(" + total + ");' value='-'/>";
                }
                else
                {
                    //html += "<td></td>";
                    total = total + 1;
                }
                html += "</td></tr>";


            }
            html += "@" + total;
        }
        else
        {
            //ca += "<tr>";
            //ca += "<td align=\"center\">< input type=\"text\" class=\"TextBox\" width=\"350\" id =\"nombrematerial1\" name =\"nombrematerial1\" class=\"width -100\" ></td>";
            //ca += "<td align=\"center\">< input type=\"text\" class=\"TextBox\" id =\"cantidad1\" name =\"cantidad1\" class=\"width-100\" ></td>";
            //ca += "<td>";
            //ca += "<table width=\"100%\"> ";
            //ca += " <tr>";
            //ca += "<td width=\"50%\" style =\"text-align: center;\" ><input type = \"radio\" name =\"estado1\" value =\"bueno\" ></td>";
            //ca += "<td width = \"50%\" style =\"text-align: center;\" ><input type = \"radio\" name =\"estado1\" value =\"regular\" ></td>";
            //ca += "</tr>";
            //ca += "</table>";
            //ca += "</td>";
            //ca += "</tr>";
        }

        return html;
    }
     [WebMethod(EnableSession = true)]
    public static string loadOctavoTrayecto(string codigoinstrumento)
    {
        string html = "";
        int total = 1;
        Estrategias est = new Estrategias();

        DataTable datos = est.cargarOctavoTrayectobitacora5(codigoinstrumento);

        if (datos != null && datos.Rows.Count > 0)
        {
            html = "mat@";
            html += "<tr><th> Actividades</th>";
            html += "<th> Herramientas necesarias para desarrollar la actividad </th>";
            html += "<th> Responsable de la actividad </th>";
            html += "<th> Duración en meses </th>";
            html += "<th> Presupuesto requerido </th>";
            html += "</tr> ";
            //ca += "@" + datoUsuario["cod"].ToString();
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                html += "<tr id='oCampus8vo" + total + "'>";
                html += "<td><input type='text' id='actividad8vo" + total + "' value='" + datos.Rows[i]["actividades"].ToString() + "'  class='TextBox' style='width: 98%;'></td>";
                html += "<td><input type='text' id='herramienta8vo" + total + "' value='" + datos.Rows[i]["herramientas"].ToString() + "'  class='TextBox' style='width: 98%;'></td>";
                html += "<td><input type='text' id='responsable8vo" + total + "' value='" + datos.Rows[i]["responsable"].ToString() + "'  class='TextBox' style='width: 98%;'></td>";
                html += "<td><input type='number' id='duracion8vo" + total + "'  value='" + datos.Rows[i]["duracionmeses"].ToString() + "' class='TextBox' style='width: 98%;' min='0' onkeypress='return isNumberKey(event);'/></td>";
                html += "<td id='oRadiotr8vo" + total + "'><input type='text' id='presupuesto8vo" + total + "' value='" + datos.Rows[i]["presupuestorequerido"].ToString() + "'  class='TextBox' style='width: 98%;' onkeypress='return isNumberKey(event);'  />";

                if (i == datos.Rows.Count - 1)
                {
                    html += "<input type='button' id='remove18vo' class='btn btn-danger' onclick='fRemove18vo(" + total + ");' value='-'/>";
                }
                else
                {
                    //html += "<td></td>";
                    total = total + 1;
                }
                html += "</td></tr>";


            }
            html += "@" + total;
        }
        else
        {
            //ca += "<tr>";
            //ca += "<td align=\"center\">< input type=\"text\" class=\"TextBox\" width=\"350\" id =\"nombrematerial1\" name =\"nombrematerial1\" class=\"width -100\" ></td>";
            //ca += "<td align=\"center\">< input type=\"text\" class=\"TextBox\" id =\"cantidad1\" name =\"cantidad1\" class=\"width-100\" ></td>";
            //ca += "<td>";
            //ca += "<table width=\"100%\"> ";
            //ca += " <tr>";
            //ca += "<td width=\"50%\" style =\"text-align: center;\" ><input type = \"radio\" name =\"estado1\" value =\"bueno\" ></td>";
            //ca += "<td width = \"50%\" style =\"text-align: center;\" ><input type = \"radio\" name =\"estado1\" value =\"regular\" ></td>";
            //ca += "</tr>";
            //ca += "</table>";
            //ca += "</td>";
            //ca += "</tr>";
        }

        return html;
    }

    [WebMethod(EnableSession = true)]
    public static string deleteBitacoraCinco(string codigo)
    {
        string ca = "";

        Estrategias e = new Estrategias();

        e.deleteDetalleBitacora5(codigo);
        e.deleteDetalleBitacora5_2(codigo);
        e.deleteDetalleBitacora5_3(codigo);
        e.deleteDetalleBitacora5_4(codigo);
        e.deleteDetalleBitacora5_5(codigo);
        e.deleteDetalleBitacora5_6(codigo);
        e.deleteDetalleBitacora5_7(codigo);
        e.deleteDetalleBitacora5_8(codigo);

        e.deleteEvidenciaBitacora5(codigo);
        e.deleteBitacora5(codigo);

        ca = "delete@";

        return ca;
    }
    

    [WebMethod(EnableSession = true)]
    public static string updateencabezado(string codigoinstrumento, string objetivoFinal, string nomTrayectoIndagacion, string dificultadesFortalezas, string principalesCaracteristicas, string importanciaInvestigacion, string importanciaIEP, string general, string especifico, string nomTrayectoIndagacion2do, string nomTrayectoIndagacion3ro, string nomTrayectoIndagacion4to, string nomTrayectoIndagacion5to, string nomTrayectoIndagacion6to, string nomTrayectoIndagacion7mo, string nomTrayectoIndagacion8vo)
    {
        string ca = "";

        Estrategias e = new Estrategias();

        if (e.updateencabezadobitacora5(codigoinstrumento, objetivoFinal, nomTrayectoIndagacion, dificultadesFortalezas, principalesCaracteristicas, importanciaInvestigacion, importanciaIEP, general, especifico, nomTrayectoIndagacion2do, nomTrayectoIndagacion3ro, nomTrayectoIndagacion4to, nomTrayectoIndagacion5to, nomTrayectoIndagacion6to, nomTrayectoIndagacion7mo, nomTrayectoIndagacion8vo))
        {
            ca = "update@";
        }
      
       

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string deletedetalleBitacora5(string codigoinstrumento, string nodetalle)
    {
        string ca = "";

        Estrategias e = new Estrategias();

        if(nodetalle == "1")
            e.deleteDetalleBitacora5(codigoinstrumento);
        else if(nodetalle == "2")
            e.deleteDetalleBitacora5_2(codigoinstrumento);
        else if (nodetalle == "3")
            e.deleteDetalleBitacora5_3(codigoinstrumento);
        else if (nodetalle == "4")
            e.deleteDetalleBitacora5_4(codigoinstrumento);
        else if (nodetalle == "5")
            e.deleteDetalleBitacora5_5(codigoinstrumento);
        else if (nodetalle == "6")
            e.deleteDetalleBitacora5_6(codigoinstrumento);
        else if (nodetalle == "7")
            e.deleteDetalleBitacora5_7(codigoinstrumento);
        else if (nodetalle == "8")
            e.deleteDetalleBitacora5_8(codigoinstrumento);

            ca ="delete@";
        return ca;
    }

}