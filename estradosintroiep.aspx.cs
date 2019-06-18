using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;
using System.Web.Services;

public partial class estradosintroiep : System.Web.UI.Page
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
                    Session["codestracoordinador"] = dato["codestracoordinador"].ToString();

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
        //lblSesion.Text = Session["s"].ToString();
    }

    //buscar docentes
    [WebMethod(EnableSession = true)]
    public static string listar()
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarListadointroiepEstraDos();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "encontro@";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                //ca += "<td>" + datos.Rows[i]["coordinador"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["sede"].ToString() + "</td>";
                //ca += "<td>" + datos.Rows[i]["sesion"].ToString() + "</td>";
                ca += "<td align='center'>" + datos.Rows[i]["nroasistentes"].ToString() + "</td>";
                ca += "<td align='center'><br /><a href='javascript:void(0)' onclick='loadinstrumento(\"" + datos.Rows[i]["codigo"].ToString() + "\")' class='btn btn-success'>Ver</a><br/><br /><a href='estradosintroiep_evi.aspx?cod=" + datos.Rows[i]["codigo"].ToString() + "' class='btn btn-primary'>Evidencia</a><br/><br /><a href='javascript:void(0)' onclick='eliminar(\"" + datos.Rows[i]["codigo"].ToString() + "\")' class='btn btn-danger'>Eliminar</a><br /><br /></td>";
                ca += "</tr>";
            }
        }
        else
        {
            ca += "<tr><td colspan='9'>No se encontraron registros</td></tr>";
        }

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

    //cargar años
    [WebMethod(EnableSession = true)]
    public static string cargarareas()
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarareasintroiep();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "area@";
            ca += "<option value='' selected disabled>Seleccione</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
            ca += "<option value='Otra' >Otra, cuál?</option>";
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
    public static string buscar(string codanio, string codsede)
    {
        string ca = "";

        Institucion inst = new Institucion();
        Docentes doc = new Docentes();

        DataTable datos = doc.cargarDocentesxSede(codsede, codanio);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "_sedes@";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["identificacion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nomdocente"].ToString() + "</td>";
                ca += "<td align='center'><input type='checkbox' id='chkdoc_" + (i + 1) + "' value='" + datos.Rows[i]["codgradodocente"].ToString() + "'  checked/></td>";
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
    public static string encabezado(string codsede, string codintroieparea, string txtotra)
    {
        string ca = "";
        Institucion inst = new Institucion();
        Funciones func = new Funciones();
        string coor = HttpContext.Current.Session["codestracoordinador"].ToString();

        if (codintroieparea == "Otra" && txtotra != "")
        {
            DataRow area = inst.agregarareaintroiep(txtotra);

            if (area != null)
            {
                DataRow introiep = inst.agregarintroiep(codsede, HttpContext.Current.Session["codestracoordinador"].ToString(), func.getFechaAñoHoraActual(), area["codigo"].ToString(), "0");

                if (introiep != null)
                {
                    ca = "true_insert@" + introiep["codigo"].ToString();
                }
            }
        }
        else
        {
            DataRow introiep = inst.agregarintroiep(codsede, HttpContext.Current.Session["codestracoordinador"].ToString(), func.getFechaAñoHoraActual(), codintroieparea, "0");

            if (introiep != null)
            {
                ca = "true_insert@" + introiep["codigo"].ToString();
            }
        }

        
      

        return ca;
    }

    //guardar inasistencia docentes
    [WebMethod(EnableSession = true)]
    public static string inasistenciadocentes(string codencabezado, string codgradodocente)
    {
        string ca = "";

        Institucion inst = new Institucion();

        inst.insertinasistenciadocenteintroiep(codgradodocente, codencabezado);

        return ca;
    }

    //eliminar inasistencia docentes
    [WebMethod(EnableSession = true)]
    public static string delete(string codigo)
    {
        string ca = "";

        Institucion inst = new Institucion();

        inst.eliminarinasistenciasdetalleintroiep(codigo);
        inst.eliminarinasistenciaintroiep(codigo);

        return ca;
    }

    //cargar un registro
    [WebMethod(EnableSession = true)]
    public static string load(string codigo)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataRow dat = inst.buscarintroiepEstraDos(codigo);

        if (dat != null)
        {
            ca += "true_load@";
            ca += "<option value='" + dat["codmunicipio"].ToString() + "'>" + dat["municipio"].ToString() + "</option>_load@";
            ca += "<option value='" + dat["codinstitucion"].ToString() + "'>" + dat["institucion"].ToString() + "</option>_load@";
            ca += "<option value='" + dat["codsede"].ToString() + "'>" + dat["sede"].ToString() + "</option>_load@";
            ca += "<option value='" + dat["codintroieparea"].ToString() + "'>" + dat["nomarea"].ToString() + "</option>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string buscardocentes(string codigo)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable dat = inst.buscardocentesintroiepestrados(codigo);

        if (dat != null && dat.Rows.Count>0)
        {
            ca += "true_load@<option value='" + dat.Rows[0]["codanio"].ToString() + "'>" + dat.Rows[0]["nombre"].ToString() + "</option>_load@";
            for (int i = 0; i < dat.Rows.Count; i++ )
            {
                ca += "<tr><td>" + (i+1) + "</td><td>" + dat.Rows[i]["identificacion"].ToString() + "</td><td>" + dat.Rows[i]["docente"].ToString() + "</td><td align='center'><input type='checkbox' disabled checked /></td></tr>";
            }
        }

        return ca;
    }

    //cargar un registro
    [WebMethod(EnableSession = true)]
    public static string update(string codigo, string nroasistente)
    {
        string ca = "";

        //Institucion inst = new Institucion();

        //if (inst.actualizarasistentessesionvirtual(codigo, nroasistente))
        //{
        //    ca = "true_update@";
        //}
        //else
        //{
        //    ca = "false_update@";
        //}

        

        return ca;
    }

}