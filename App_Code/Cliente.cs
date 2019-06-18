using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Cliente
/// </summary>
public class Cliente
{
	public Cliente()
	{
		//
		// TODO: Agregar aquí la lógica del constructor prueba de cambios en la nube
		//
	}
    public long agregarCliente(string codusuario, String nit, String pnombre, string papellido, string codtipocliente)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO pro_clientes (codusuario, nit,pnombre,papellido, codtipocliente)  " +
            "VALUES (@codusuario,@nit,@pnombre,@papellido,@codtipocliente);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@nit", nit);
        conector.AsignarParametroCadena("@pnombre", pnombre.ToUpper());
        conector.AsignarParametroCadena("@papellido", papellido.ToUpper());
        conector.AsignarParametroCadena("@codtipocliente", codtipocliente);
        long resp = conector.guardadataid();
        return resp;
    }
    //public bool editarCliente(string nit, string pnombre, string snombre, string papellido, string sapellido, string tipocliente, string cod)
    public bool editarCliente(string nit, string pnombre, string papellido, string tipocliente, string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "    UPDATE pro_clientes SET  nit = @nit, pnombre = @pnombre, papellido = @papellido, codtipocliente = @tipocliente WHERE cod = @cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nit", nit);
        conector.AsignarParametroCadena("@pnombre", pnombre);
        //conector.AsignarParametroCadena("@snombre", snombre);
        conector.AsignarParametroCadena("@papellido", papellido);
        //conector.AsignarParametroCadena("@sapellido", sapellido);
        conector.AsignarParametroCadena("@tipocliente", tipocliente);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();
    }
    public long agregarSedeCliente(string nit,string codcliente, String nombre, String telefono, string direccion, string codmunicipio, string sede)
    {
        Conexion conector = new Conexion();
        string consulta = " INSERT INTO cli_sedes (nit,codcliente,nombre, telefono,direccion,codmunicipio, sede)  " +
            "VALUES (@nit,@codcliente,@nombre,@telefono,@direccion,@codmunicipio,@sede);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nit", nit);
        conector.AsignarParametroCadena("@codcliente", codcliente);
        conector.AsignarParametroCadena("@nombre", nombre.ToUpper());
        conector.AsignarParametroCadena("@telefono", telefono);
        conector.AsignarParametroCadena("@direccion", direccion);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        conector.AsignarParametroCadena("@sede", sede);
        long resp = conector.guardadataid();
        return resp;
    }
    public bool editarSedeCliente(string nit, string nombre, string telefono, string direccion, string codmunicipio, string sede, string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE cli_sedes SET  nit=@nit, nombre = @nombre,telefono = @telefono,direccion = @direccion,codmunicipio =@codmunicipio,sede = @sede WHERE cod = @cod ;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nit", nit);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@telefono", telefono);
        conector.AsignarParametroCadena("@direccion", direccion);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        conector.AsignarParametroCadena("@sede", sede);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();
    }
    public DataTable cargarSedesCliente(string codcliente)
    {
        Conexion conector = new Conexion();
        string consulta = " SELECT s.*,m.nombre'nombrem' FROM cli_sedes s INNER JOIN con_municipios m ON s.codmunicipio=m.cod WHERE s.codcliente=@codcliente ORDER BY s.nombre ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codcliente", codcliente);
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
    public DataTable cargarProyectosxCliente(string codclisede)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT cp.*,p.nombre FROM pro_clienteproyecto cp INNER JOIN pro_proyectos p ON cp.codproyecto=p.cod WHERE cp.codclisede=@codclisede ORDER BY p.nombre ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codclisede", codclisede);
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
   
    public DataTable cargarTiposCliente()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM con_tipocliente ORDER BY nombre ASC";
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
    public DataTable cargarContactosxCliente(string codcliente)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT c.*,ca.nombre'cargo' FROM pro_contactos c INNER JOIN con_cargos ca ON c.codcargo=ca.cod WHERE c.codcliente=@codcliente ORDER BY c.identificacion ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codcliente", codcliente);
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
    public DataTable cargarContactosxSede(string codclisede)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT pc.*,ca.nombre'cargo',s.cod FROM cli_sedes s INNER JOIN pro_clientes c ON s.codcliente=c.cod INNER JOIN pro_contactos pc ON pc.codcliente=c.cod INNER JOIN con_cargos ca ON pc.codcargo=ca.cod WHERE s.cod=@codclisede ORDER BY cargo ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codclisede", codclisede);
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
    public DataTable cargarClientesxCodProyecto(string codproyecto)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT c.*,p.cod'codproyecto',p.nombre'nombrep',tc.nombre'tipocliente',m.nombre'nombrem',d.nombre'nombred' , s.nombre'nombres' FROM pro_clienteproyecto cp INNER JOIN cli_sedes s ON cp.codclisede=s.cod INNER JOIN pro_clientes c ON s.codcliente=c.cod INNER JOIN pro_proyectos p ON p.cod=cp.codproyecto INNER JOIN con_tipocliente tc ON c.codtipocliente=tc.cod INNER JOIN con_municipios m ON m.cod=s.codmunicipio INNER JOIN con_departamentos d ON m.coddepartamento=d.cod  WHERE cp.codproyecto=@codproyecto ORDER BY s.nombre ASC";
        conector.CrearComando(consulta);
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
    public DataTable cargarClientesWhere(string where)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT s.codigo as cod, i.dane as daneins, i.nombre as nombreins, i.nomrector as nomrector, s.consesede as consesede, s.dane as danesed, s.nombre as nomsed, m.nombre as nommunipio FROM ((ins_institucion i INNER JOIN ins_sede s on i.codigo=s.codinstitucion) INNER JOIN geo_municipios m on m.cod=s.codmunicipio)" + where + " ORDER BY m.nombre;";
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
    public long agregarContacto(string codcliente, String identificacion, String nombres, string apellidos, string telefono,string celular,string email, string codcargo,string descripcion)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO pro_contactos (codcliente, identificacion, nombres, apellidos, telefono, celular,email,codcargo,descripcion) " +
            "VALUES (@codcliente,@identificacion,@nombres,@apellidos,@telefono,@celular,@email,@codcargo,@descripcion);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codcliente", codcliente);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@nombres", nombres);
        conector.AsignarParametroCadena("@apellidos", apellidos);
        conector.AsignarParametroCadena("@telefono", telefono);
        conector.AsignarParametroCadena("@celular", celular);
        conector.AsignarParametroCadena("@email", email);
        conector.AsignarParametroCadena("@codcargo", codcargo);
        conector.AsignarParametroCadena("@descripcion", descripcion);
        long resp = conector.guardadataid();
        return resp;
    }
    public DataTable cargarSolicitudes()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT s.*,p.nombre'nombrep' FROM (con_solicitudes s INNER JOIN con_prioridad p ON s.codprioridad=p.cod) ORDER BY s.nombre ASC";
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
    public DataRow buscarTipoSolicitud(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT s.*,p.nombre'nombrep' FROM (con_solicitudes s INNER JOIN con_prioridad p ON s.codprioridad=p.cod) WHERE s.cod=@cod ORDER BY s.nombre ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        DataRow resp = conector.traerfila();
        if (resp != null)
           return resp;
        else
           return null;
    }
    public DataTable cargarPrioridades()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM con_prioridad ORDER BY nombre ASC";
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
    public DataTable cargarUsuariosTicMonitor()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT ur.cod, CONCAT('',u.usuario,' - ',u.papellido,' ', u.pnombre)'nombre' FROM usu_usuario u INNER JOIN usu_usuariorol ur ON u.cod=ur.codusuario WHERE ur.codrol!='4' AND u.usuario!='superadmin'";
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
    public bool agregarTipoSolicitud(string nombre, String codprioridad, String ans)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO con_solicitudes ( nombre, codprioridad,ans) VALUES (@nombre,@codprioridad,@ans);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@codprioridad", codprioridad);
        conector.AsignarParametroCadena("@ans", ans);
        return conector.guardadata();
    }
    /// <summary>
    /// Este metodo Unifica la tabla de clientes con el usuario que le corresponde con el fin de traer los datos de contacto.
    /// </summary>
    /// <param name="cod"></param>
    /// <returns></returns>
    public DataRow buscarClienteCompleto(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM pro_clientes c INNER JOIN usu_usuario u ON c.codusuario=u.cod WHERE c.cod=@cod";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    /// <summary>
    /// Busca si un cliente existe.
    /// </summary>
    /// <param name="nit"></param>
    /// <returns></returns>
    public DataRow buscarClientexNit(string nit)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM pro_clientes c  WHERE c.nit=@nit";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nit", nit);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    /// <summary>
    /// Busca el codigo 
    /// </summary>
    /// <param name="codclisede"></param>
    /// <returns></returns>
    public DataRow buscarClientexCodSede(string codclisede)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM cli_sedes s INNER JOIN pro_clientes c ON s.codcliente=c.cod WHERE s.cod=@codclisede LIMIT 1;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codclisede", codclisede);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscarTipoClientexNombre(string nombre)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM con_tipocliente c  WHERE UPPER(c.nombre)=@nombre";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre.ToUpper());
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public bool eliminarTipoSolicitud(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM con_solicitudes WHERE cod=@cod";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();
    }
    public bool editarTipoSolicitud(string nombre,string prioridad,string ans,string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE con_solicitudes SET nombre = @nombre,codprioridad = @prioridad, ans = @ans WHERE cod = @cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@prioridad", prioridad);
        conector.AsignarParametroCadena("@ans", ans);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();
    }
    public bool agregarCausaIncidente(string nombre)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO con_causasincidente (nombre) VALUES (@nombre)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        return conector.guardadata();
    }
    public DataTable cargarCausaIncidente()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM con_causasincidente ORDER BY nombre ASC";
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
    public bool eliminarCausaIncidente(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM con_causasincidente WHERE cod=@cod";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();
    }
    public bool eliminarCliente(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM pro_clientes WHERE cod = @cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();
    }
    public bool eliminarClientexUsuario(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM pro_clientes WHERE nit = @cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();
    }
    public bool eliminarSedeProyecto(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM pro_clienteproyecto WHERE codclisede=@cod";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();
    }
    public bool eliminarSedeCliente(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM cli_sedes WHERE cod = @cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();
    }
    public bool eliminarContacto(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM pro_contactos WHERE cod = @cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();
    }
    public bool editarContacto(string identificacion, string nombres, string apellidos, string telefono, string celular, string email, string codcargo, string descripcion,string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE pro_contactos SET identificacion = @identificacion, nombres = @nombres,apellidos = @apellidos,telefono = @telefono, celular = @celular,email = @email,codcargo = @codcargo,descripcion = @descripcion WHERE cod = @cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@nombres", nombres);
        conector.AsignarParametroCadena("@apellidos", apellidos);
        conector.AsignarParametroCadena("@telefono", telefono);
        conector.AsignarParametroCadena("@celular", celular);
        conector.AsignarParametroCadena("@email", email);
        conector.AsignarParametroCadena("@codcargo", codcargo);
        conector.AsignarParametroCadena("@descripcion", descripcion);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();
    }

    public Boolean agregarTipoCliente(string nombre)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO con_tipocliente (nombre)  " +
            "VALUES (@nombre);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        return conector.guardadata();
    }
}