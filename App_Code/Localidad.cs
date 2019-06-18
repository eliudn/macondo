using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Localidad
/// </summary>
public class Localidad
{
	public Localidad()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    public DataTable cargarDepartamentos()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM geo_departamentos ORDER BY nombre ASC";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
        {
            return resp;
        }
        else
        {
            return null;
        }
    }
    public DataTable cargarMunicipios()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT m.*,d.nombre AS nombred FROM (geo_municipios m INNER JOIN geo_departamentos d ON m.coddepartamento=d.cod) ORDER BY m.nombre ASC";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
        {
            return resp;
        }
        else
        {
            return null;
        }
    }
    public DataTable cargarMunicipiosSinCodSuperior(string coddepartamento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT m.* FROM (geo_municipios m) WHERE m.codsuperior='0' AND m.coddepartamento=@coddepartamento ORDER BY m.nombre ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddepartamento", coddepartamento);
        DataTable resp = conector.traerdata();
        if (resp != null)
        {
            return resp;
        }
        else
        {
            return null;
        }
    }
    public DataRow buscarMunicipioxCod(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM geo_municipios WHERE cod=@cod";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        DataRow resp = conector.traerfila();
        if (resp != null)
        {
            return resp;
        }
        else
        {
            return null;
        }
    }
    public DataRow buscarMunicipioxNombre(string nombre)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM geo_municipios WHERE UPPER(nombre) ilike UPPER('%" + nombre + "%')";
        conector.CrearComando(consulta);
        DataRow resp = conector.traerfila();
        if (resp != null)
        {
            return resp;
        }
        else
        {
            return null;
        }
    }
    public Boolean agregarDepartamento(String nombre)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO geo_departamentos (nombre) VALUES (@nombre)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean agregarMunicipio(String nombre, string tipo, string codsuperior, string coddepartamento)
    {
        Conexion conector = new Conexion();
        string consulta = " INSERT INTO geo_municipios (nombre, tipo,codsuperior,coddepartamento) VALUES (@nombre, @tipo,@codsuperior,@coddepartamento);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@tipo", tipo);
        conector.AsignarParametroCadena("@codsuperior", codsuperior);
        conector.AsignarParametroCadena("@coddepartamento", coddepartamento);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarDepartamento(String cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM geo_departamentos WHERE cod=@cod";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarMunicipio(String cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM geo_municipios WHERE cod=@cod";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean editarMunicipio(string nombre, String tipo, string superior, string departamento,string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "    UPDATE geo_municipios SET nombre = @nombre,tipo = @tipo,codsuperior = @superior,coddepartamento = @departamento WHERE cod = @cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@tipo", tipo);
        conector.AsignarParametroCadena("@superior", superior);
        conector.AsignarParametroCadena("@departamento", departamento);
        conector.AsignarParametroCadena("@cod", cod);
        bool resp = conector.guardadata();
        return resp;
    }
}