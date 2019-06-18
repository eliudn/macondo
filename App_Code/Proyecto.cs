using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Proyecto
/// </summary>
public class Proyecto
{
    public Proyecto()
    {
        //
        // TODO: Agregar aquí la lógica del constructor
        //
    }
    public DataTable cargarProyectos()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT p.*,d.nombre'nombred',m.nombre'nombrem' FROM pro_proyectos p INNER JOIN con_departamentos d ON p.coddepartamento=d.cod LEFT JOIN con_municipios m ON p.codmunicipio=m.cod ORDER BY m.nombre ASC";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }
    public DataTable cargarAnexosProyecto(string codproyecto)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM pro_anexos a  WHERE a.codproyecto=@codproyecto";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyecto", codproyecto);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }
    public DataTable cargarProyectosDeUsuario(string codUsuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT   p.*, d.nombre 'nombred',  m.nombre 'nombrem' FROM  pro_proyectos p INNER JOIN pro_clienteproyecto pc ON p.cod=pc.codproyecto INNER JOIN cli_sedes sd ON pc.codclisede= sd.cod INNER JOIN  pro_clientes c ON sd.codcliente= c.cod INNER JOIN  usu_usuario us ON c.codusuario= us.cod INNER JOIN  con_departamentos d ON p.coddepartamento = d.cod LEFT JOIN   con_municipios m ON p.codmunicipio = m.cod WHERE us.cod=@codigo ORDER BY m.nombre ASC ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codUsuario);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }
    public DataTable cargarDocumentoProyectos()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT d.*,p.nombre'proyecto' FROM pro_documentos d INNER JOIN pro_proyectos p ON d.codproyecto=p.cod ORDER BY p.nombre ASC";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }
    public DataTable cargarProyectosxCoordinador(string codusuario,string codrol)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT p.cod,p.nombre FROM act_asignaciones asig INNER JOIN pro_proyectos p ON asig.codproyecto=p.cod WHERE asig.codusuario=@codusuario AND asig.codrol=@codrol GROUP BY p.cod";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@codrol", codrol);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }
    public DataTable cargarDocumentoProyectosxClienteSede(string codcliproyecto)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT cd.*,d.nombre FROM pro_clidocumentos cd INNER JOIN pro_documentos d ON cd.codprodocumento=d.cod INNER JOIN pro_proyectos p ON d.codproyecto=p.cod WHERE cd.codcliproyecto=@codcliproyecto ORDER BY d.nombre ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codcliproyecto", codcliproyecto);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }
    public DataTable cargarDocumentosxProyectoxCliSede(string codclisede, string codproyecto)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM pro_clienteproyecto cp INNER JOIN pro_clidocumentos cd ON cd.codcliproyecto=cp.cod INNER JOIN pro_documentos d ON cd.codprodocumento=d.cod WHERE cp.codclisede=@codclisede AND cp.codproyecto=@codproyecto ORDER BY d.nombre ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codclisede", codclisede);
        conector.AsignarParametroCadena("@codproyecto", codproyecto);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }
    public DataTable cargarDocumentoDeUnProyecto(string codcliproyecto)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT d.* FROM pro_documentos d INNER JOIN pro_proyectos p ON d.codproyecto=p.cod INNER JOIN pro_clienteproyecto cp ON cp.codproyecto=p.cod WHERE cp.cod=@codcliproyecto ORDER BY d.nombre ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codcliproyecto", codcliproyecto);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }
    public DataTable cargarClienteInProyectoDeUsuario(string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT s.cod,s.nombre,pc.nit,pc.cod'codcliente', CONCAT_WS(' ',s.nombre,' - ',pc.nit,' - ', m.nombre)'nombrenit' FROM usu_usuario u INNER JOIN pro_clientes pc ON u.cod=pc.codusuario INNER JOIN cli_sedes s ON s.codcliente=pc.cod INNER JOIN pro_clienteproyecto cp ON cp.codclisede=s.cod INNER JOIN con_municipios m ON m.cod=s.codmunicipio WHERE u.cod=@codusuario";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }
    public DataTable cargarClienteInProyecto(string codproyecto)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT s.cod,s.nombre,c.nit,c.cod'codcliente', CONCAT_WS(' ',s.nombre,' - ',c.nit,' - ', m.nombre)'nombrenit' FROM pro_clienteproyecto cp INNER JOIN cli_sedes s ON cp.codclisede=s.cod INNER JOIN pro_clientes c ON s.codcliente=c.cod INNER JOIN con_municipios m ON m.cod=s.codmunicipio  WHERE cp.codproyecto=@codproyecto ORDER BY s.nombreASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyecto", codproyecto);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }
    public DataTable cargarClienteOUTProyecto(string codproyecto, string coddepartamento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT s.cod,s.nombre,c.nit FROM pro_clientes c INNER JOIN cli_sedes s ON s.codcliente=c.cod INNER JOIN con_municipios muni ON s.codmunicipio=muni.cod WHERE NOT EXISTS (SELECT 1 FROM pro_clienteproyecto cp WHERE s.cod=cp.codclisede AND cp.codproyecto=@codproyecto) AND muni.coddepartamento=@coddepartamento;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyecto", codproyecto);
        conector.AsignarParametroCadena("@coddepartamento", coddepartamento);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }
    public DataRow buscarProyecto(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM pro_proyectos WHERE cod=@cod";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;
    }
    public Boolean agregarProyecto(String nombre, string coddepartamento, string codmunicipio, string fechani, string fechafin)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO pro_proyectos ( nombre,coddepartamento, codmunicipio,fechaini,fechafin) VALUES (@nombre,@coddepartamento,@codmunicipio,@fechani,@fechafin);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@coddepartamento", coddepartamento);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        conector.AsignarParametroCadena("@fechani", fechani);
        conector.AsignarParametroCadena("@fechafin", fechafin);
        return conector.guardadata();
    }
    public Boolean agregarDocumentoProyecto(String codproyecto, string nombre)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO pro_documentos (codproyecto,nombre) VALUES (@codproyecto,@nombre);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyecto", codproyecto);
        conector.AsignarParametroCadena("@nombre", nombre);
        return conector.guardadata();
    }
    public Boolean agregarClientexProyecto(String codclisede, string codproyecto, string fechani, string fechafin)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO pro_clienteproyecto (codclisede, codproyecto,fechaini,fechafin) VALUES (@codclisede,@codproyecto,@fechani,@fechafin);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codclisede", codclisede);
        conector.AsignarParametroCadena("@codproyecto", codproyecto);
        conector.AsignarParametroCadena("@fechani", fechani);
        conector.AsignarParametroCadena("@fechafin", fechafin);
        return conector.guardadata();
    }
    public Boolean eliminarClientexProyecto(String codclisede, string codproyecto)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM pro_clienteproyecto WHERE codclisede=@codclisede AND codproyecto=@codproyecto;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codclisede", codclisede);
        conector.AsignarParametroCadena("@codproyecto", codproyecto);
        return conector.guardadata();
    }
    public Boolean editarProyecto(String nombre, string departamento, string municipio, string fechani, string fechafin, string proyecto, string estado)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE pro_proyectos SET nombre = @nombre, coddepartamento =@departamento,codmunicipio =@municipio,fechaini =@fechani, fechafin = @fechafin, estado=@estado  WHERE cod = @proyecto;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@departamento", departamento);
        conector.AsignarParametroCadena("@municipio", municipio);
        conector.AsignarParametroCadena("@fechani", fechani);
        conector.AsignarParametroCadena("@fechafin", fechafin);
        conector.AsignarParametroCadena("@proyecto", proyecto);
        conector.AsignarParametroCadena("@estado", estado);
        return conector.guardadata();
    }
    public Boolean eliminarProyecto(string proyecto)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM pro_proyectos WHERE cod = @proyecto;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@proyecto", proyecto);
        return conector.guardadata();
    }
    public Boolean eliminarDocumentoProyecto(string proyecto)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM pro_documentos WHERE cod = @proyecto;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@proyecto", proyecto);
        return conector.guardadata();
    }
    public Boolean editarDocumentoProyecto(string proyecto, string nombre, string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE pro_documentos SET codproyecto =@proyecto,nombre = @nombre  WHERE cod = @cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@proyecto", proyecto);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();
    }
    public Boolean agregarTecnicoCuadrilla(string coordiandor, string tecnico, string proyecto)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO act_asignaciones(codusuario,  codrol, codusuariosub, codrolsub, codproyecto) VALUES (@coordiandor,'2',@tecnico,'5',@proyecto);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coordiandor", coordiandor);
        conector.AsignarParametroCadena("@tecnico", tecnico);
        conector.AsignarParametroCadena("@proyecto", proyecto);
        return conector.guardadata();
    }
    public bool eliminarDocumentoCliente(string codclidocumento)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM pro_clidocumentos WHERE cod = @codclidocumento;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codclidocumento", codclidocumento);
        return conector.guardadata();
    }
    public bool eliminarAnexoProyecto(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM pro_anexos WHERE cod = @cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();
    }
    public bool agregarDocumentoCliente(string codprodocumento, string codcliproyecto, string nombrearchivo, string nombreguardado, string contentType, string ext, string path, string tamano)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO pro_clidocumentos (codprodocumento,codcliproyecto, nombrearchivo,nombreguardado,contentType,  ext, path,tamano,fechacreado) "
                                                  + "VALUES (@codprodocumento,@codcliproyecto,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado);";
        Funciones fun = new Funciones ();
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codprodocumento", codprodocumento);
        conector.AsignarParametroCadena("@codcliproyecto", codcliproyecto);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroCadena("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado",fun.getFechaAñoHoraActual());
        return conector.guardadata();
    }
    public bool agregarAnexoProyecto(string codproyecto, string nombrearchivo, string nombreguardado, string contentType, string ext, string path, string tamano)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO pro_anexos (codproyecto, nombrearchivo,nombreguardado,contentType,  ext, path,tamano,fechacreado) "
                        + "VALUES (@codproyecto,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado);";
        Funciones fun = new Funciones();
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyecto", codproyecto);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroCadena("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fun.getFechaAñoHoraActual());
        return conector.guardadata();
    }
    public DataTable cargarTecnicosProyecto(string where)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT p.*,asig.* ,CONCAT_WS(' ',u.papellido,u.pnombre)'tecnicos',(SELECT CONCAT_WS(' ',papellido,pnombre)'coord' FROM usu_usuario WHERE cod=asig.codusuario)'nombrecoord' FROM pro_proyectos p INNER JOIN act_asignaciones asig ON p.cod = asig.codproyecto INNER JOIN usu_usuario u ON asig.codusuariosub=u.cod " + where + " GROUP BY p.cod,asig.codusuariosub ORDER BY p.cod,asig.codusuario ";//se AGRUPA por proyecto y por tecnicos, se ordena por proyecto, despues por coordinador
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }
    public DataTable cargarIntegrantesTecnicos(string where)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT asig.*,CONCAT_WS(' ',u.papellido,u.pnombre)'tecnico' FROM act_asignaciones asig INNER JOIN usu_usuario u ON asig.codusuariosub=u.cod "+where;
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    //SIEP
    public DataTable cargarLineasInvestigacion()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM pro_linea_investigacion ORDER BY nombre ASC";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }
}