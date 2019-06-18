using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;
using System.Web.Services;

public partial class estracincocomiteregional : System.Web.UI.Page
{
    Funciones fun = new Funciones();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 
        if (!IsPostBack)
        {
            if (Session["codrol"] != null)
            {
                //obtenerGET();
                Estrategias est = new Estrategias();
                DataRow dato = est.buscarCodEstrategiaxCoordinador(Session["identificacion"].ToString());

                if (dato != null)
                {
                    Session["codestracoordinador"] = dato["codigo"].ToString();

                }
            }
            else
            {
                Response.Redirect("bienvenida.aspx");
            }
        }
    }
    public void obtenerGET()
    {
        Session["s"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
        lblSesion.Text = Session["s"].ToString();
    }

    //buscar docentes
    [WebMethod(EnableSession = true)]
    public static string listar()
    {
        string ca = "";

        Institucion inst = new Institucion();
        Funciones fun = new Funciones();

        DataTable datos = inst.cargarListadoSesionComiteRegional();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "encontro@";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                //ca += "<td>" + datos.Rows[i]["coordinador"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td align='center'>" + fun.convertFechaDia(datos.Rows[i]["fecha"].ToString()) + "</td>";
                ca += "<td align='center'>" + datos.Rows[i]["hora"].ToString() + "</td>";
                ca += "<td align='center'>" + datos.Rows[i]["lugar"].ToString() + "</td>";
                ca += "<td align='center'>" + datos.Rows[i]["participantes"].ToString() + "</td>";
                ca += "<td align='center'>" + datos.Rows[i]["entidades"].ToString() + "</td>";
                ca += "<td align='center'><br /><a href='javascript:void(0)' onclick='loadinstrumento(\"" + datos.Rows[i]["codigo"].ToString() + "\")' class='btn btn-success'>Ver</a><br/><br /><a href='estracincocomiteregionalevi.aspx?cod=" + datos.Rows[i]["codigo"].ToString() + "' class='btn btn-primary'>Evidencia</a><br/><br /><a href='javascript:void(0)' onclick='eliminar(\"" + datos.Rows[i]["codigo"].ToString() + "\")' class='btn btn-danger'>Eliminar</a><br /><br /></td>";
                ca += "</tr>";
            }
        }
        else
        {
            ca += "<tr><td colspan='9'>No se encontraron registros</td></tr>";
        }
        ca += "encontro@" + HttpContext.Current.Session["codrol"].ToString();
        return ca;
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
            ca += "<option value='' selected>Seleccione</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
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
            //ca += "<option value='' selected>Todos</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option selected value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
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
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
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

    //buscar docentes
    [WebMethod(EnableSession = true)]
    public static string buscar(string codmunicipio, string codanio)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarSedesxMunicipio(codmunicipio);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "_sedes@";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td style='display:none'>" + datos.Rows[i]["codigosede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["municipios"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombresede"].ToString() + "</td>";

                DataRow docentes = inst.contardocentesxsede(datos.Rows[i]["codigosede"].ToString(), codanio);

                if (docentes != null)
                {
                    ca += "<td align='center'><input value='" + docentes["cantdocente"].ToString() + "' onkeypress='return isNumberKey(event);' class='TextBox' type='text' id='txt_" + (i + 1) + "' style='width:50px;'  /></td>";
                }
                else
                {
                    ca += "<td align='center'><input onkeypress='return isNumberKey(event);' class='TextBox' type='text' id='txt_" + (i + 1) + "' style='width:50px;'  /></td>";
                }
                ca += "<td align='center'><input onkeypress='return isNumberKey(event);' class='TextBox' type='text' id='autoformacion_" + (i + 1) + "' style='width:50px;'  /></td>";
                ca += "<td align='center'><input onkeypress='return isNumberKey(event);' class='TextBox' type='text' id='produccion_" + (i + 1) + "' style='width:50px;'  /></td>";

                ca += "</tr>";
            }
        }
        else
        {
            ca = "<tr><td>No se encontraron docentes para esta sede</td></tr>";
        }

        //Docentes doc = new Docentes();

        //DataTable datos = doc.cargarDocentesxSede(codsede, codanio);

        //if (datos != null && datos.Rows.Count > 0)
        //{
        //    ca = "docentes@";

        //    for (int i = 0; i < datos.Rows.Count; i++)
        //    {
        //        ca += "<tr>";
        //        ca += "<td>" + (i+1) + "</td>";
        //        ca += "<td>" + datos.Rows[i]["identificacion"].ToString() + "</td>";
        //        ca += "<td>" + datos.Rows[i]["nomdocente"].ToString() + "</td>";
        //        ca += "<td align='center'><input type='checkbox' value='" + datos.Rows[i]["codgradodocente"].ToString() + "' checked/></td>";
        //        ca += "</tr>";
        //    }
        //}
        //else
        //{
        //    ca = "<tr><td>No se encontraron docentes para esta sede</td></tr>";
        //}

        return ca;
    }

    //guardar encabezado
    [WebMethod(EnableSession = true)]
    public static string encabezado(string codmunicipio, string fecha, string lugar, string hora, string participantes, string entidades, string objetivo, string desarrollo)
    {
        string ca = "";

        Institucion inst = new Institucion();
        Funciones fun = new Funciones();
        string coor = HttpContext.Current.Session["codestracoordinador"].ToString();


        DataRow dato = inst.insertcomiteregional(codmunicipio, fecha, lugar, hora, participantes, entidades, objetivo, desarrollo, coor);

        if (dato != null)
        {
            ca = "true_insert@";
        }

        return ca;
    }

    //guardar inasistencia docentes
    [WebMethod(EnableSession = true)]
    public static string inasistenciadocentes(string codencabezado, string codgradodocente)
    {
        string ca = "";

        Institucion inst = new Institucion();

        inst.insertinasistenciadocente(codgradodocente, codencabezado);

        return ca;
    }

    //eliminar inasistencia docentes
    [WebMethod(EnableSession = true)]
    public static string delete(string codigo)
    {
        string ca = "";

        Institucion inst = new Institucion();

        //inst.eliminarinasistenciasdetalleesionvirtual(codigo);
        inst.eliminarevidenciaporcodcomiteregional(codigo);
        inst.eliminarincomiteregional(codigo);

        return ca;
    }

    //cargar un registro
    [WebMethod(EnableSession = true)]
    public static string load(string codigo)
    {
        string ca = "";

        Institucion inst = new Institucion();
        Funciones fun = new Funciones();

        DataRow dat = inst.buscarSesionComiteRegional(codigo);

        if (dat != null)
        {
            ca += "true_load@" + dat["codmunicipio"].ToString();//0 - 1
            ca += "_load@" + fun.convertFechaDia(dat["fecha"].ToString());//2
            ca += "_load@" + dat["lugar"].ToString();//3
            ca += "_load@" + dat["hora"].ToString();//4
            ca += "_load@" + dat["participantes"].ToString();//5
            ca += "_load@" + dat["entidades"].ToString();//6
            ca += "_load@" + dat["objetivo"].ToString();//7
            ca += "_load@" + dat["desarrollo"].ToString();//8
            ca += "_load@" + codigo;//9
            ca += "_load@" + HttpContext.Current.Session["codrol"].ToString();//10
        }

        return ca;
    }

    //cargar un registro
    [WebMethod(EnableSession = true)]
    public static string update(string codigo, string codmunicipio, string fecha, string lugar, string hora, string participantes, string entidades, string objetivo, string desarrollo)
    {
        string ca = "";

        Institucion inst = new Institucion();
        Funciones fun = new Funciones();

        if (inst.actualizarcomiteregional(codigo, codmunicipio, fun.convertFechaAño(fecha), lugar, hora, participantes, entidades, objetivo, desarrollo))
        {
            ca = "true_update@";
        }
        else
        {
            ca = "false_update@";
        }

        

        return ca;
    }

}