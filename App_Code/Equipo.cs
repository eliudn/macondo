using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Equipo
/// </summary>
public class Equipo
{
	public Equipo()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    public DataTable cargarCategoriaEquipos()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM inv_categorias ORDER BY nombre ASC";
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
    public DataTable cargarEquiposxCliEquipo(string codcliequipo)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT ce.*,e.nombre,e.descripcion,f.nombre'fabricante',c.nombre'categoria' FROM pro_cliequipos ce INNER JOIN inv_equipos e ON ce.codequipo=e.cod INNER JOIN inv_fabricante f ON e.codfabricante=f.cod INNER JOIN inv_categorias c ON e.codcategoria=c.cod WHERE ce.codcliproyecto=@codcliequipo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codcliequipo", codcliequipo);
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
    public DataTable cargarEquiposxCliEquipoxProyecto(string codclisede, string codproyecto)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM pro_clienteproyecto cp INNER JOIN pro_cliequipos ce ON ce.codcliproyecto=cp.cod INNER JOIN inv_equipos e ON ce.codequipo=e.cod WHERE cp.codclisede=@codclisede AND cp.codproyecto=@codproyecto ORDER BY e.nombre ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codclisede", codclisede);
        conector.AsignarParametroCadena("@codproyecto", codproyecto);
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
    public DataTable cargarProveedoresEquipos()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM inv_fabricante ORDER BY nombre ASC";
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
    public DataTable cargarEquipos()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT e.*,c.nombre'categoria',f.nombre'fabricante' FROM inv_equipos e INNER JOIN inv_fabricante f ON e.codfabricante=f.cod INNER JOIN inv_categorias c ON c.cod=e.codcategoria ORDER BY c.nombre ASC";
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
    public bool agregarCategoriaEquipo(string nombre)
    {
        Conexion conector = new Conexion();
        string consulta = " INSERT INTO inv_categorias (nombre) VALUES (@nombre)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        return conector.guardadata();
    }

    public bool agregarEquipoCliente(string codcliproyecto, string codequipo, string serial, string iprouter, string ipantena, string observacion)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO pro_cliequipos  ( codcliproyecto,  codequipo, serial,  iprouter, ipantena, observacion) "
        + "VALUES (@codcliproyecto,@codequipo,@serial,@iprouter,@ipantena,@observacion);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codcliproyecto", codcliproyecto);
        conector.AsignarParametroCadena("@codequipo", codequipo);
        conector.AsignarParametroCadena("@serial", serial);
        conector.AsignarParametroCadena("@iprouter", iprouter);
        conector.AsignarParametroCadena("@ipantena", ipantena);
        conector.AsignarParametroCadena("@observacion", observacion);
        return conector.guardadata();
    }
    public bool agregarProveedorEquipo(string nombre,string telefono,string email)
    {
        Conexion conector = new Conexion();
        string consulta = " INSERT INTO inv_fabricante(nombre, telefono, email) VALUES (@nombre,@telefono,@email);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@telefono", telefono);
        conector.AsignarParametroCadena("@email", email);
        return conector.guardadata();
    }
    public bool agregarEquipo(string nombre, string descripcion, string codcategoria, string codfabricante)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO inv_equipos (nombre, descripcion, codcategoria,codfabricante) VALUES (@nombre,@descripcion,@codcategoria,@codfabricante);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@descripcion", descripcion);
        conector.AsignarParametroCadena("@codcategoria", codcategoria);
        conector.AsignarParametroCadena("@codfabricante", codfabricante);
        return conector.guardadata();
    }
    public bool eliminarCategoriaEquipo(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM inv_categorias WHERE cod=@cod ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();
    }
    public bool eliminarProveedorEquipo(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM inv_fabricante WHERE cod=@cod ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();
    }
    public bool eliminarEquipo(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM inv_equipos WHERE cod=@cod ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();
    }
    public bool eliminarEquipoCliente(string codcliequipo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM pro_cliequipos WHERE cod = @cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", codcliequipo);
        return conector.guardadata();
    }
    public bool editarEquipoCliente(string equipo, string serial, string codcliequipo, string iprouter, string ipantena, string observacion)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE pro_cliequipos SET  codequipo = @equipo,serial = @serial ,iprouter = @iprouter, ipantena = @ipantena, observacion = @observacion WHERE cod = @codcliequipo ;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@equipo", equipo);
        conector.AsignarParametroCadena("@serial", serial);
        conector.AsignarParametroCadena("@codcliequipo", codcliequipo);
        conector.AsignarParametroCadena("@iprouter", iprouter);
        conector.AsignarParametroCadena("@ipantena", ipantena);
        conector.AsignarParametroCadena("@observacion", observacion);
        return conector.guardadata();
    }
  
}