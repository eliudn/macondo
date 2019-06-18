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

public partial class estumatricula : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [WebMethod(EnableSession = true)]
    public static string cargarDepartamentoMagdalena()
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarDepartamentoMagdalena();

        if (datos != null && datos.Rows.Count > 0)
        {
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
            ca += "<option value='0' disabled selected>Seleccione municipio...</option>";
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
            ca += "<option value='0' disabled selected>Seleccione sede</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarGrado()
    {
        string ca = "";
        Institucion inst = new Institucion();
        DataTable datos = inst.cargarGrados();
        if(datos != null && datos.Rows.Count > 0)
        {
            ca += "<option value='0' disabled selected>Seleccione grado</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession=true)]
    public static string listarEstudianteNoMatricula()
    {
        string ca = "";
        Estudiantes estu = new Estudiantes();

        DataTable lista = estu.listarEstudianteNoMatricula();
        if (lista != null && lista.Rows.Count > 0)
        {
            ca += "lista@";
            for (int i = 0; i < lista.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + lista.Rows[i]["identificacion"].ToString() + "</td>";
                ca += "<td>" + lista.Rows[i]["estudiante"].ToString() + "</td>";
                ca += "<td><label class='switch'><input type='checkbox' value='"+ lista.Rows[i]["codigo"].ToString() +"' /><div class='slider round'></div></label></td>";
                ca += "</tr>";
            }
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string buscarEstudianteNoMatricula( String valor)
    {
        string ca = "";
        Estudiantes estu = new Estudiantes();

        DataTable lista = estu.buscarEstudianteNoMatricula(valor);
        if (lista != null && lista.Rows.Count > 0)
        {
            ca += "lista@";
            for (int i = 0; i < lista.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + lista.Rows[i]["identificacion"].ToString() + "</td>";
                ca += "<td>" + lista.Rows[i]["estudiante"].ToString() + "</td>";
                ca += "<td><label class='switch'><input type='checkbox' value='" + lista.Rows[i]["codigo"].ToString() + "' /><div class='slider round'></div></label></td>";
                ca += "</tr>";
            }
        }
        return ca;
    }

    [WebMethod(EnableSession=true)]
    public static string matricularEstudiante(string codestudiante, string codsede, string codgrado)
    {
        string ca = "";
        Estudiantes estu = new Estudiantes();

        string[] codigo = codestudiante.Split('@');

        for (int i = 0; i < codigo.Length; i++)
        {
            bool response = estu.matricularEstudiante(codigo[i].ToString(), codsede, codgrado);
            if (response)
            {
                ca = "matricula@Se matricularon " + (codigo.Length - 1) + " estudiantes exitosamente";
            }
            else 
            {
                ca = "vacio@Error al matricular los estudiantes";
            }
        }

        return ca;
    }
}