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

public partial class estraunoparticipantesferiasreporte : System.Web.UI.Page
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

            //Estrategias estra = new Estrategias();
            //DataRow dato = estra.buscarCodEstraAsesorxCoordinador(Session["identificacion"].ToString());

            //if (dato != null)
            //{
            //    Session["CodAsesorEstraCoordinador"] = dato["codigo"].ToString();

            //}
            //else
            //{
            //    mostrarmensaje("error", "ERROR: Ud. No es asesor de esta estrategía.");
            //}

        }
    }
    public void obtenerGET()
    {
        Session["e"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["e"]);
        Session["m"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);

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
    public static string cargartipoid()
    {
        string ca = "";

        Docentes ins = new Docentes();

        DataTable datos = ins.cargarTipoDocumento();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "tipo@";
            ca += "<option value='0' disabled selected>Seleccione tipo documento</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }



    [WebMethod(EnableSession = true)]
    public static string cargaranios()
    {
        string ca = "";

        Institucion ins = new Institucion();

        DataTable datos = ins.cargarAnios();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "anio@";
            ca += "<option value='0' disabled selected>Seleccione año</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarDocentes(string codsede, string codanio)
    {
        string ca = "";
        Docentes estu = new Docentes();
        Estrategias estr = new Estrategias();

        DataRow dato = estr.buscarParticipacionFerias(codsede, codanio);

        if (dato == null)
        {
            DataTable lista = estu.cargarDocentesxSede(codsede, codanio);
            if (lista != null && lista.Rows.Count > 0)
            {
                ca += "datos@";
                for (int i = 0; i < lista.Rows.Count; i++)
                {
                    ca += "<tr>";
                    ca += "<td>" + (i + 1) + "</td>";
                    ca += "<td>" + lista.Rows[i]["identificacion"].ToString() + "</td>";
                    ca += "<td>" + lista.Rows[i]["nomdocente"].ToString() + "</td>";
                    ca += "<td><label class='switch'><input type='checkbox' checked value='" + lista.Rows[i]["codgradodocente"].ToString() + "' /><div class='slider round'></div></label></td>";
                    ca += "</tr>";
                }
            }
        }
      
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string guardardocente(string tipoid, string identificacion, string nombre, string apellido, string sexo, string fechanacimiento, string telefono, string direccion, string email, string codsede, string codanio)
    {
        string ca = "";

        Docentes ins = new Docentes();

        DataRow insert = ins.agregarDocenteDR(nombre, apellido, identificacion, sexo, fechanacimiento, telefono, direccion, email, tipoid);

        if (insert != null)
        {
            if (ins.agregarDocenteGrado(identificacion, codsede, codanio))
            {
                ca = "true";
            }
            else
            {
                ca = "false";
            }
        }
        else
        {
            ca = "false2";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string listardocentesmatriculados(string codparticipantesferias, string codanio, string codsede)
    {
        string ca = "";
        Docentes estu = new Docentes();

        DataTable lista2 = estu.cargarDocentesxSede(codsede, codanio);

        if (lista2 != null && lista2.Rows.Count > 0)
        {
            ca += lista2.Rows[0]["codanio"].ToString() + "@";
            ca += "datos@";
            for (int j = 0; j < lista2.Rows.Count; j++)
            {

                DataRow lista = estu.buscarDocentesPaticipacionFerias(codparticipantesferias, lista2.Rows[j]["codgradodocente"].ToString());

                if (lista != null)
                {
                    ca += "<tr>";
                    ca += "<td>" + (j + 1) + "</td>";
                    ca += "<td>" + lista["identificacion"].ToString() + "</td>";
                    ca += "<td>" + lista["nomdocente"].ToString() + "</td>";
                    ca += "<td><label class='switch'><input type='checkbox' value='" + lista["codgradodocente"].ToString() + "' checked/><div class='slider round'></div></label></td>";
                }
                else
                {
                    ca += "<tr>";
                    ca += "<td>" + (j + 1) + "</td>";
                    ca += "<td>" + lista2.Rows[j]["identificacion"].ToString() + "</td>";
                    ca += "<td>" + lista2.Rows[j]["nomdocente"].ToString() + "</td>";
                    ca += "<td><label class='switch'><input type='checkbox' value='" + lista2.Rows[j]["codgradodocente"].ToString() + "' /><div class='slider round'></div></label></td>";
                }
                ca += "</tr>";
            }
        }
       
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string matricularDocentes(string codparticipantesferias, string codgradodocente)
    {
        string ca = "";
        Docentes estu = new Docentes();

        string[] codgdocente = codgradodocente.Split('@');

        for (int i = 0; i < codgdocente.Length; i++)
        {
            bool response = estu.matriculaDocenteParticipacionFerias(codparticipantesferias, codgdocente[i].ToString());
            if (response)
            {
                ca = "matricula@Se matricularon " + (codgdocente.Length - 1) + " docentes exitosamente";
            }
            else
            {
                ca = "vacio@Error al matricular los docentes";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string deletematriculaDocente(string codespacioapro)
    {
        string ca = "";
        Docentes estu = new Docentes();

        if (estu.deleteDocentesParticipantesFerias(codespacioapro))
        {

           ca = "true@";
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
    public static string insertInstrumento(string codsede, string codanio)
    {
        

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();

        string ca = "";

        //string coord = HttpContext.Current.Session["CodEstraCoordinador"].ToString();
        DataRow insert = inst.procinsertParticipantesFerias(codsede, HttpContext.Current.Session["CodAsesorEstraCoordinador"].ToString(), codanio);
        if (insert != null)
        {
            ca = "true@";
            ca += insert["codigo"].ToString();
        }
        else
        {
            ca = "Ocurrio un error al insertar datos de instrumento@";
        }
        return ca;
    }


  
    /*2016-10-25 modificado*/
    [WebMethod(EnableSession = true)]
    public static string updateInstrumento(string codigoinstrumento)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        //if (inst.updateEspacioApropiacion(codigoinstrumento, fecharealizacion, nroestudiantes, nrodocentes))
        //{
        //    ca = "true@";
        //}
        //else
        //{
        //    ca = "Ocurrio un error al actualizar datos de instrumento@";
        //}
        return ca;
    }

  

    /*2016-10-24 JONNY PACHECO metodo para  listar las bitacoras 3*/
   
    [WebMethod(EnableSession = true)]
    public static string listarParticipantesFerias(string codasesorcoordinador)
    {
        Institucion inst = new Institucion();
        Funciones fun = new Funciones();
        string ca = "";

        DataTable datos = inst.listarParticipantesFerias(codasesorcoordinador);
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
                ca += "<td>" + fun.convertFechaAño(datos.Rows[i]["fecharealizacion"].ToString()) + "</td>";
                ca += "<td style='padding:5px;' ><a class='btn btn-success' onclick=\"$('#table').hide(), $('#form').fadeIn(500),  loadSelectParticipantesFerias(" + datos.Rows[i]["codsede"].ToString() + "), loadInstrumentosParticipantesFerias(" + datos.Rows[i]["codigo"].ToString() + ") \">Ver</a><br/><br/></td>";
                //ca += "<td style='padding:5px;' ><a class='btn btn-success' onclick=\"$('#table').hide(), $('#form').fadeIn(500),  loadSelectEspaciosApropiacion(" + datos.Rows[i]["codproyectosede"].ToString() + "), loadInstrumentosEspaciosApro(" + datos.Rows[i]["codigo"].ToString() + ") \">Editar</a><br/><br/><a class='btn btn-primary' href='estraunoespaciosaproevi.aspx?cod=" + datos.Rows[i]["codigo"].ToString() + "'>Evidencias</a><br/><br/><a class='btn btn-danger' onclick='eliminar(" + datos.Rows[i]["codigo"].ToString() + ")'>Eliminar</a><br/></td>";
                ca += "</tr>";
            }
        }
        else
        {
            ca += "<tr><td colspan='10'>No se encontraron registros por parte del asesor.</td></tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadInstrumento(string codigo)
    {
        string ca = "";
        Estrategias estra = new Estrategias();
        Docentes doc = new Docentes();
        Funciones fun = new Funciones();

        DataRow dato = estra.loadParticipantesFerias(codigo);
        if (dato != null)
        {
            ca += "true@";
            ca += dato["codigo"].ToString() + "@";
            //ca += fun.convertFechaAño(dato["fecharealizacion"].ToString()) + "@";
            //ca += (dato["nroestudiantes"].ToString()) + "@";
            //ca += (dato["nrodocentes"].ToString()) + "@";

            DataRow doce = doc.buscarDocenteEnParticipantesFerias(codigo);

            if (doce != null)
            {
                //ca += doce["codgradodocente"].ToString();

                DataRow bdoc = doc.buscarDocentesxCodigo(doce["codgradodocente"].ToString());

                if (bdoc != null)
                {
                    ca += bdoc["codanio"].ToString() + "@" + bdoc["codsede"].ToString();
                }
            }
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadSelectParticipantesFerias(string codigo)
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataRow dato = estra.loadSelectParticipantesFerias(codigo);
        if (dato != null)
        {
            ca += "loadSelect@";
            ca += "<option value='" + dato["codigodepartamento"].ToString() + "'>" + dato["nombredepartamento"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigomunicipio"].ToString() + "'>" + dato["nombremunicipio"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigoinstitucion"].ToString() + "'>" + dato["nombreinstitucion"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigosede"].ToString() + "'>" + dato["nombresede"].ToString() + "</option>@";

            DataRow dat = estra.buscarAnioParticipacionFerias(codigo);

            if (dat != null)
            {
                ca += "anio@";
                ca += dat["codanio"].ToString();
            }
        }
        return ca;
    }
   

    [WebMethod(EnableSession = true)]
    public static string eliminar(string codigo)
    {
        Estrategias estra = new Estrategias();
        string ca = "";



        estra.deleteParticipacionFerias(codigo);
        estra.deleteParticipacionFeriasDocentes(codigo);

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarlistasesores()
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataTable asesores = estra.listarAsesoresSeguimiento("1");

        if (asesores != null && asesores.Rows.Count > 0)
        {
            ca += "<option value='0' selected disabled>Seleccione asesor...</option>";
            for (int i = 0; i < asesores.Rows.Count; i++)
            {
                ca += "<option value='" + asesores.Rows[i]["codigo"].ToString() + "'>" + asesores.Rows[i]["asesor"].ToString().ToUpper() + "</option>";
            }
        }

        return ca;
    }

}

