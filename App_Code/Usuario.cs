using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Usuario
/// </summary>
public class Usuario
{
	public Usuario()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public DataRow usuariointer(string cod)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM usu_usuario WHERE cod='106679'";
        conector.CrearComando(consulta);
        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
  
    public DataRow buscarUsuario(string cod)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM usu_usuario WHERE cod=@cod";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public DataRow buscarUsuarioAsesorxCodAsesorCoordinador(string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT u.* FROM usu_usuario u inner join est_asesor a on CAST(u.identificacion as bigint)=a.identificacion inner join est_asesorcoordinador ac on a.codigo=ac.codasesor where ac.codigo=@codasesorcoordinador";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public DataRow buscarRolxCod(string codusuario)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM usu_usuariorol WHERE codusuario=@codusuario";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public DataRow buscarUsuarioxCodUsuarioRol(string codusuariorol)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM usu_usuariorol ur INNER JOIN usu_usuario u ON ur.codusuario=u.cod WHERE ur.cod=@codusuariorol";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuariorol", codusuariorol);
        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public DataRow verificarUsuario(string usuario, string pass)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM usu_usuario WHERE usuario=@usuario AND pass=MD5(@pass)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@usuario", usuario);
        conector.AsignarParametroCadena("@pass", pass);
        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public DataTable cargarRoles()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM usu_roles ORDER BY nombre ASC";
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
    public DataTable cargarRolesPerfiles()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT r.cod as codrol,r.nombre as nomrol,p.cod as codperfil,p.nombre as nomperfil FROM usu_roles r INNER JOIN usu_usuarioperfil p ON r.codperfil=p.cod ORDER BY r.nombre ASC";
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
    public long agregarUsuario(String usuario, String pass,string identificacion, string pnombre, string snombre, string papellido, string sapellido,string telefono,string celular,string email)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO usu_usuario (usuario,pass,identificacion,pnombre,snombre,papellido,sapellido,email,telefono,celular) "+
            "VALUES (@usuario,MD5(@pass),@identificacion,@pnombre,@snombre,@papellido,@sapellido,@email,@telefono,@celular);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@usuario", usuario);
        conector.AsignarParametroCadena("@pass", pass);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@pnombre", pnombre.ToUpper());
        conector.AsignarParametroCadena("@snombre", snombre.ToUpper());
        conector.AsignarParametroCadena("@papellido", papellido.ToUpper());
        conector.AsignarParametroCadena("@sapellido", sapellido.ToUpper());
        conector.AsignarParametroCadena("@email", email.ToLower());
        conector.AsignarParametroCadena("@telefono", telefono);
        conector.AsignarParametroCadena("@celular", celular);
        long resp = conector.guardadataid();
        return resp;
    }
    public bool agregarUsuarioBool(String usuario, String pass, string identificacion, string pnombre, string snombre, string papellido, string sapellido, string telefono, string celular, string email, string dane)
    {
        Conexion conector = new Conexion();

        if(dane == "")
        {
            string consulta = "INSERT INTO usu_usuario (usuario,pass,identificacion,pnombre,snombre,papellido,sapellido,email,telefono,celular,estado,dane) " +
           "VALUES (@usuario,MD5(@pass),@identificacion,@pnombre,@snombre,@papellido,@sapellido,@email,@telefono,@celular,'On','0');";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@usuario", usuario);
            conector.AsignarParametroCadena("@pass", pass);
            conector.AsignarParametroCadena("@identificacion", identificacion);
            conector.AsignarParametroCadena("@pnombre", pnombre.ToUpper());
            conector.AsignarParametroCadena("@snombre", snombre.ToUpper());
            conector.AsignarParametroCadena("@papellido", papellido.ToUpper());
            conector.AsignarParametroCadena("@sapellido", sapellido.ToUpper());
            conector.AsignarParametroCadena("@email", email.ToLower());
            conector.AsignarParametroCadena("@telefono", telefono);
            conector.AsignarParametroCadena("@celular", celular);
          
        }
        else
        {
            string consulta = "INSERT INTO usu_usuario (usuario,pass,identificacion,pnombre,snombre,papellido,sapellido,email,telefono,celular,estado,dane) " +
           "VALUES (@usuario,MD5(@pass),@identificacion,@pnombre,@snombre,@papellido,@sapellido,@email,@telefono,@celular,'On',@dane);";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@usuario", usuario);
            conector.AsignarParametroCadena("@pass", pass);
            conector.AsignarParametroCadena("@identificacion", identificacion);
            conector.AsignarParametroCadena("@pnombre", pnombre.ToUpper());
            conector.AsignarParametroCadena("@snombre", snombre.ToUpper());
            conector.AsignarParametroCadena("@papellido", papellido.ToUpper());
            conector.AsignarParametroCadena("@sapellido", sapellido.ToUpper());
            conector.AsignarParametroCadena("@email", email.ToLower());
            conector.AsignarParametroCadena("@telefono", telefono);
            conector.AsignarParametroCadena("@celular", celular);
            conector.AsignarParametroCadena("@dane", dane);
        }
       
        return conector.guardadata();
    }
    public DataRow agregarUsuarioPG(String usuario, String pass, string identificacion, string pnombre, string snombre, string papellido, string sapellido, string telefono, string celular, string email, string estado, string dane)
    {
        Conexion conector = new Conexion();

        if(dane == "")
        {
            string consulta = "INSERT INTO usu_usuario (usuario,pass,identificacion,pnombre,snombre,papellido,sapellido,email,telefono,celular,estado) " +
          "VALUES (@usuario,MD5(@pass),@identificacion,@pnombre,@snombre,@papellido,@sapellido,@email,@telefono,@celular,'On') RETURNING cod;";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@usuario", usuario);
            conector.AsignarParametroCadena("@pass", pass);
            conector.AsignarParametroCadena("@identificacion", identificacion);
            conector.AsignarParametroCadena("@pnombre", pnombre.ToUpper());
            conector.AsignarParametroCadena("@snombre", snombre.ToUpper());
            conector.AsignarParametroCadena("@papellido", papellido.ToUpper());
            conector.AsignarParametroCadena("@sapellido", sapellido.ToUpper());
            conector.AsignarParametroCadena("@email", email.ToLower());
            conector.AsignarParametroCadena("@telefono", telefono);
            conector.AsignarParametroCadena("@celular", celular);
        }
        else
        {
            string consulta = "INSERT INTO usu_usuario (usuario,pass,identificacion,pnombre,snombre,papellido,sapellido,email,telefono,celular,estado,dane) " +
          "VALUES (@usuario,MD5(@pass),@identificacion,@pnombre,@snombre,@papellido,@sapellido,@email,@telefono,@celular,'On',@dane) RETURNING cod;";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@usuario", usuario);
            conector.AsignarParametroCadena("@pass", pass);
            conector.AsignarParametroCadena("@identificacion", identificacion);
            conector.AsignarParametroCadena("@pnombre", pnombre.ToUpper());
            conector.AsignarParametroCadena("@snombre", snombre.ToUpper());
            conector.AsignarParametroCadena("@papellido", papellido.ToUpper());
            conector.AsignarParametroCadena("@sapellido", sapellido.ToUpper());
            conector.AsignarParametroCadena("@email", email.ToLower());
            conector.AsignarParametroCadena("@telefono", telefono);
            conector.AsignarParametroCadena("@celular", celular);
            conector.AsignarParametroCadena("@dane", dane);
        }
     
           



  
        DataRow datos = conector.guardadataidPG();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public bool relacionarUsuarioRol(String codusuario, String codrol)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO usu_usuariorol (codusuario,codrol ) VALUES (@codusuario,@codrol);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@codrol", codrol);
        return  conector.guardadata();
    }
    public bool AgregarRolPerfiles(String nombre, String codperfil)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO usu_roles (nombre,codperfil ) VALUES (@nombre,@codperfil);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@codperfil", codperfil);
        return conector.guardadata();
    }
    public Boolean eliminarUsuario(String coduser)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM usu_usuario WHERE cod=@coduser";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coduser", coduser);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarRolesUsuario(String cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM usu_usuariorol WHERE cod = @cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean editarPass(String codusuario, String pass)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE usu_usuario SET pass=MD5(@pass) WHERE cod=@codusuario";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@pass", pass);
        return conector.guardadata();
    }
    public DataTable cargarUsuarios()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT u.*,concat_ws(' ',u.pnombre,u.snombre) as nombres,concat_ws(' ',u.papellido,u.sapellido) as apellidos FROM usu_usuario u WHERE usuario!='superadmin' ORDER BY usuario ASC";
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
    public DataTable cargarUsuariosxRol(string codrol)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT u.*,CONCAT_WS(' ',u.pnombre,u.snombre) as nombres,CONCAT_WS(' ',u.papellido,u.sapellido) as apellidos FROM usu_usuario u INNER JOIN usu_usuariorol ur ON ur.codusuario=u.cod WHERE ur.codrol=@codrol AND  usuario!='superadmin' ORDER BY usuario ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codrol",codrol);
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
    public DataTable cargarRolesUsuarios(string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM (usu_usuariorol u INNER JOIN usu_roles r on u.codrol=r.cod)  WHERE u.codusuario=@codusuario";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
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
    public DataRow buscarUsuarioxRolxCod(string codusuario,string codrol)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM (usu_usuariorol u INNER JOIN usu_roles r ON u.codrol=r.cod)  WHERE u.codusuario=@codusuario AND u.codrol=@codrol LIMIT 1;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@codrol", codrol);
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
    public DataTable cargarRolesxCodUsuarioSinCodUsuario(string codusuario, string codrol)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM (usu_usuariorol u INNER JOIN usu_roles r ON u.codrol=r.cod)  WHERE u.codusuario=@codusuario AND u.codrol<>@codrol;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@codrol", codrol);
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

    public Boolean editarUsuario(string usuario, String identificacion, string pnombre, String snombre, String papellido, string sapellido, String email, String telefono, string celular, String estado,string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE usu_usuario SET  usuario =@usuario,identificacion = @identificacion,pnombre =@pnombre,snombre = @snombre,papellido =@papellido,sapellido = @sapellido,email = @email,telefono =@telefono,celular = @celular,estado = @estado WHERE cod = @cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@usuario", usuario);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@pnombre", pnombre);
        conector.AsignarParametroCadena("@snombre", snombre);
        conector.AsignarParametroCadena("@papellido", papellido);
        conector.AsignarParametroCadena("@sapellido", sapellido);
        conector.AsignarParametroCadena("@email", email);
        conector.AsignarParametroCadena("@telefono", telefono);
        conector.AsignarParametroCadena("@celular", celular);
        conector.AsignarParametroCadena("@estado", estado);
        conector.AsignarParametroCadena("@cod", cod);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean editarUsuario(String identificacion, string pnombre, String snombre, String papellido, string sapellido, String email, String telefono, string celular, string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE usu_usuario SET  identificacion = @identificacion,pnombre =@pnombre,snombre = @snombre,papellido =@papellido,sapellido = @sapellido,email = @email,telefono =@telefono,celular = @celular WHERE cod = @cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@pnombre", pnombre);
        conector.AsignarParametroCadena("@snombre", snombre);
        conector.AsignarParametroCadena("@papellido", papellido);
        conector.AsignarParametroCadena("@sapellido", sapellido);
        conector.AsignarParametroCadena("@email", email);
        conector.AsignarParametroCadena("@telefono", telefono);
        conector.AsignarParametroCadena("@celular", celular);
         conector.AsignarParametroCadena("@cod", cod);
        bool resp = conector.guardadata();
        return resp;
    }

    public DataTable cargarPerfiles()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM usu_usuarioperfil ORDER BY nombre ASC";
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

    public bool agregarCodigoVerificacion(String identificacion, String code)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO usu_codigoverificacion (identificacion,code ) VALUES (@identificacion,@code);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@code", code);
        return conector.guardadata();
    }

    public DataRow buscarCorreoRemitente()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM usu_emailremitente LIMIT 1";
        conector.CrearComando(consulta);
        //conector.AsignarParametroCadena("@cod", cod);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataRow buscarUsuarioxIdentificacion(string identificacion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM usu_usuario WHERE identificacion=@identificacion LIMIT 1";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataRow buscarCodigoVerificacionxDocente(string identificacion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM usu_codigoverificacion WHERE identificacion=@identificacion LIMIT 1";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public Boolean editarUsuarioDocente(String identificacion, String nombre, string apellido, string email, string telefono)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE usu_usuario SET pnombre=@nombre, papellido=@apellido, email=@email, telefono=@telefono WHERE usuario=@identificacion";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@apellido", apellido);
        conector.AsignarParametroCadena("@email", email);
        conector.AsignarParametroCadena("@telefono", telefono);
        return conector.guardadata();
    }

    public bool agregarAsesor(String identificacion, String nombre, string apellido, string telefono, string email)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_asesor (identificacion,nombre,apellido,telefono,email) VALUES (@identificacion,@nombre,@apellido,@telefono,@email);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@apellido", apellido);
        conector.AsignarParametroCadena("@telefono", telefono);
        conector.AsignarParametroCadena("@email", email);
        return conector.guardadata();
    }









































    public DataTable cargarCoordinadores()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT u.cod,CONCAT_WS(' ',u.papellido,u.pnombre)'nombre' FROM usu_usuariorol ur INNER JOIN usu_usuario u ON ur.codusuario=u.cod WHERE ur.codrol='2' ORDER BY u.papellido,u.sapellido ASC";
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
    public DataTable cargarTecnicos()
    {
        Conexion conector = new Conexion();
        string consulta = " SELECT u.cod,CONCAT_WS(' ',u.papellido,u.pnombre)'nombre' FROM usu_usuariorol ur INNER JOIN usu_usuario u ON ur.codusuario=u.cod WHERE ur.codrol='5' ORDER BY u.papellido,u.sapellido ASC";
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
    public DataTable cargarTecnicosxCoordinadorxProyecto(string codusuario,string codproyecto)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT ur.cod,CONCAT_WS(' ',u.papellido,u.pnombre)'nombre'  FROM act_asignaciones asig INNER JOIN usu_usuario u ON asig.codusuariosub=u.cod INNER JOIN usu_usuariorol ur ON u.cod=ur.codusuario WHERE asig.codproyecto=@codproyecto AND asig.codusuario=@codusuario AND ur.codrol='5' ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
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
    public DataTable cargarCargos()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM con_cargos ORDER BY nombre ASC";
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
    public Boolean eliminarPerfil(String cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM usu_roles WHERE cod=@cod";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarCargo(String cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM con_cargos WHERE cod=@cod";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean agregarPerfiles(String nombreperfil)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO usu_usuarioperfil (nombre) VALUES (@nombreperfil)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombreperfil", nombreperfil);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean agregarCargo(String nombreperfil)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT con_cargos (nombre) VALUES (@nombreperfil)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombreperfil", nombreperfil);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean editarPreferenciaRol(String preferencia,string usuario,string rol)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE usu_usuariorol SET preferencia = @preferencia WHERE  codusuario =@usuario AND  codrol = @rol;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@preferencia", preferencia);
        conector.AsignarParametroCadena("@usuario", usuario);
        conector.AsignarParametroCadena("@rol", rol);
        bool resp = conector.guardadata();
        return resp;
    }
    public long agregarVisita(string usuario, string codrol)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO usu_estacceso (codusuario,codrol) VALUES (@usuario,@codrol);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@usuario", usuario);
        conector.AsignarParametroCadena("@codrol", codrol);
        long resp = conector.guardadataid();
        return resp;
    }
    public DataRow buscarImagenUsuario(string codUsuario)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM usu_imagenperfil WHERE codusuario=@codusuario LIMIT 1;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codUsuario);
        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public bool agregarVisitaPagina(string codsession, string url)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO usu_estaccesopag (codestacceso,paginaurl) VALUES (@codsession,@url);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsession", codsession);
        conector.AsignarParametroCadena("@url", url);
        bool resp = conector.guardadata();
        return resp;
    }
    public DataRow verificarUsuario2(string codusuario, string pass)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM usu_usuario WHERE cod=@codusuario AND pass=MD5(@pass)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@pass", pass);
        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public Boolean agregarArchivoResposi(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO usu_imagenperfil (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroDouble("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fechacreado);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean borrarImagenUsuario(String codUsuario)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM usu_imagenperfil WHERE codusuario=@codUsuario";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codUsuario", codUsuario);
        bool resp = conector.guardadata();
        return resp;
    }

    public DataTable cargarTecnicosxCoordinador(string codusuariocoord, string codproyecto)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT u.cod'cod',CONCAT_WS(' ',u.papellido,u.pnombre)'nombre' FROM usu_usuario u INNER JOIN usu_usuariorol ur ON u.cod=ur.codusuario LEFT JOIN act_asignaciones a ON a.codusuariosub=u.cod WHERE a.codrol='2' AND a.codproyecto=@codproyecto AND a.codusuario=@codusuariocoord";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuariocoord", codusuariocoord);
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

    public DataRow buscarTecnicoxCoordinador(string codtec, string codcoor, string codproyecto)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM act_asignaciones WHERE codusuariosub=@codtec AND codproyecto=@codproyecto AND codusuario=@codcoor";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyecto", codproyecto);
        conector.AsignarParametroCadena("@codtec", codtec);
        conector.AsignarParametroCadena("@codcoor", codcoor);
        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public Boolean EliminarTecnicoxCordinador(String codasignacion)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM act_asignaciones WHERE cod=@codasignacion";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasignacion", codasignacion);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean eliminarCoordinadoryProyecto(String codproyecto, string codcoord)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM act_asignaciones WHERE codproyecto=@codproyecto AND codusuario=@codcoord";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyecto", codproyecto);
        conector.AsignarParametroCadena("@codcoord", codcoord);
        bool resp = conector.guardadata();
        return resp;
    }
    public DataRow buscarNombrePerfilRol(string codperfil)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM usu_usuarioperfil WHERE cod=@codperfil";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codperfil", codperfil);
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

    public DataRow buscarUltimoUsuarioAgregado()
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM usu_usuario ORDER BY cod DESC LIMIT 1";
        conector.CrearComando(consulta);
        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public DataTable cargarCodigosUsuarios()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM usu_codigoverificacion ORDER BY identificacion ASC";
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

    public Boolean editarEstadoCodeVerificacion(String estado, string identificacion)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE usu_codigoverificacion SET estado=@estado WHERE identificacion=@identificacion";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@estado", estado);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        return conector.guardadata();
    }

    public bool agregarlogUsuario(String identificacion)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO usu_usuariolog (identificacion,fecha ) VALUES (@identificacion,now());";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        return conector.guardadata();
    }

    public DataRow buscarUltimoAccesoUsuarioLog(string identificacion)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT fecha FROM usu_usuariolog where identificacion=@identificacion ORDER BY codigo DESC LIMIT 1";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

}