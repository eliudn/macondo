using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Net.Mail;

/// <summary>
/// Descripción breve de Actividad
/// </summary>
public class Estrategias
{
    Funciones fun = new Funciones();
    public string title { get; set; }
    public string start { get; set; }
    public string end { get; set; }
    public string color { get; set; }
    public Estrategias()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public DataTable cargarMemoriasxAsesorSedesOld()
    {
        Conexion conector = new Conexion();
        string consulta = "select * from est_estra2instrumento_s004_sede si inner join ins_sede s on s.codigo=si.codsede";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarbitacoraunoxAsesor(string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "select b.codigo as codbitacora, ps.codigo as codproyectosede, ps.nombregrupo, ps.codlineainvestigacion, m.cod as codmunicipio, m.nombre as municipio, d.cod as coddepartamento, d.nombre as departamento, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, i.nombre as nominstitucion, s.nombre as nomsede, b.fechacreacion from est_estra1bitacora1 b inner join pro_proyectosede ps on b.codproyectosede=ps.codigo inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento inner join est_asesorcoordinador ac on ac.codigo=ps.codasesorcoordinador inner join est_asesor a on a.codigo=ac.codasesor where ps.codasesorcoordinador=@codasesorcoordinador;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataRow buscarDatoBitacorauno(string codbitacora)
    {
        Conexion conector = new Conexion();
        string consulta = "select b.codigo as codbitacora, b.relato, ps.codigo as codproyectosede, ps.nombregrupo, ps.codlineainvestigacion, m.cod as codmunicipio, m.nombre as municipio, d.cod as coddepartamento, d.nombre as departamento, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, i.codigo as codinstitucion, i.nombre as nominstitucion, s.codigo as codsede, s.nombre as nomsede, b.fechacreacion from est_estra1bitacora1 b inner join pro_proyectosede ps on b.codproyectosede=ps.codigo inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento inner join est_asesorcoordinador ac on ac.codigo=ps.codasesorcoordinador inner join est_asesor a on a.codigo=ac.codasesor where b.codigo=@codbitacora";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codbitacora", codbitacora);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public bool editarbitacorauno(string codigo, string relato)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra1bitacora1 SET relato=@relato WHERE codigo=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        conector.AsignarParametroCadena("@relato", relato);
        return conector.guardadata();

    }
    public DataRow buscarRedTematicaxCod(string codredtematicasede)
    {
        Conexion conector = new Conexion();
        string consulta = "select d.cod as coddepartamento, m.cod as codmunicipio, i.codigo as codinstitucion, s.codigo as codsede, rt.codigo as codredtematicasede from rt_redtematicasede rt inner join rt_redtematica r on r.codigo=rt.codredtematica inner join ins_sede s on rt.codsede=s.codigo inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where rt.codigo=@codredtematicasede";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarRedTematicaxAsesor()
    {
        Conexion conector = new Conexion();
        string consulta = "select ps.codigo as codredtematicasede, s.nombre as nomsede, i.nombre as nominstitucion, CONCAT_WS(' ',r.nombre,ps.consecutivogrupo) as nombre, ac.codigo as codasesorcoordinador, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, m.nombre as municipio, d.nombre as departamento from rt_redtematicasede ps inner join rt_redtematica r on r.codigo=ps.codredtematica left join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento order by a.apellido asc;";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarRedTematicaxAsesor(string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "select ps.codigo as codredtematicasede, s.nombre as nomsede, i.nombre as nominstitucion, CONCAT_WS(' ',r.nombre,ps.consecutivogrupo) as nombre, ac.codigo as codasesorcoordinador, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, m.nombre as municipio, d.nombre as departamento from rt_redtematicasede ps inner join rt_redtematica r on r.codigo=ps.codredtematica left join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where ps.codasesorcoordinador=@codasesorcoordinador order by a.apellido asc;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarGruposInvestigacionxAsesor()
    {
        Conexion conector = new Conexion();
        string consulta = "select ps.codigo as codproyectosede, i.nombre as nominstitucion, s.nombre as nomsede, ps.nombregrupo, pa.nombre as nomarea, li.nombre as nomlinea, ac.codigo as codasesorcoordinador, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor from pro_proyectosede ps left join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join pro_areas pa on pa.codigo=ps.codarea inner join pro_linea_investigacion li on li.codigo=ps.codlineainvestigacion inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion order by a.apellido asc;";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarGruposInvestigacionxAsesor(string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "select ps.codigo as codproyectosede, i.nombre as nominstitucion, s.nombre as nomsede, ps.nombregrupo, pa.nombre as nomarea, li.nombre as nomlinea, ac.codigo as codasesorcoordinador, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, m.nombre as nommunicipio, d.nombre as nomdepartamento from pro_proyectosede ps left join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join pro_areas pa on pa.codigo=ps.codarea inner join pro_linea_investigacion li on li.codigo=ps.codlineainvestigacion inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where ps.codasesorcoordinador=@codasesorcoordinador order by a.apellido asc;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarRedesTematicasxAsesor(string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "select rts.codigo as codredtematicasede, i.nombre as nominstitucion, s.nombre as nomsede, concat_ws(' ',rt.nombre,rts.consecutivogrupo) as nombregrupo, ac.codigo as codasesorcoordinador, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, m.nombre as nommunicipio, d.nombre as nomdepartamento from rt_redtematicasede rts left join est_asesorcoordinador ac on rts.codasesorcoordinador=ac.codigo inner join rt_redtematica rt on rt.codigo=rts.codredtematica inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=rts.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where rts.codasesorcoordinador=@codasesorcoordinador order by a.apellido asc;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataRow buscarGrupoInvestigacionxCod(string codproyectosede)
    {
        Conexion conector = new Conexion();
        string consulta = "select d.cod as coddepartamento, m.cod as codmunicipio, i.codigo as codinstitucion, s.codigo as codsede, ps.codigo as codproyectosede, ps.codlineainvestigacion from pro_proyectosede ps inner join ins_sede s on ps.codsede=s.codigo inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where ps.codigo=@codproyectosede";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataRow cargarInstrumentoS002RedTematica(string codredtematica, string estrategia, string momento, string sesion)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from est_estra2instrumento_s002  WHERE codproyecto=@codredtematica and estrategia=@estrategia and momento=@momento and sesion=@sesion";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codredtematica", codredtematica);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarActividadesS002(string codestra2instrumento_s002)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM est_estra2instrumento_s002actividades where  codestra2instrumento_s002=@codestra2instrumento_s002";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestra2instrumento_s002", codestra2instrumento_s002);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarCompromisosS002(string codestra2instrumento_s002)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM est_estra2instrumento_s002compromisos where  codestra2instrumento_s002=@codestra2instrumento_s002";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestra2instrumento_s002", codestra2instrumento_s002);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarEstados()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM con_estado ORDER BY nombre ASC";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataRow buscarCodEstrategiaxCoordinador(string identificacion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT ec.codigo as codestracoordinador,* FROM est_coordinador c inner join est_estracoordinador ec on c.codigo=ec.codcoordinador WHERE identificacion=@identificacion";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataRow buscarCodEstraAsesorxCoordinador(string identificacion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT ac.codigo FROM est_asesor a inner join est_asesorcoordinador ac on a.codigo=ac.codasesor WHERE identificacion=@identificacion";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataRow buscarCodDocente(string identificacion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT gd.cod FROM ins_gradodocente gd INNER JOIN ins_docente d ON d.identificacion = gd.identificacion WHERE gd.identificacion=@identificacion";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;
    }
    public bool agregarActividad(string nombre,string ans)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO con_actividades (nombre,ans) VALUES (@nombre,@ans);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@ans",ans);
        return conector.guardadata();

    }
    public bool eliminarActividad(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM con_actividades WHERE cod = @cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();

    }
    
    public long agregarActividadAgendada(string codusuariorol, string descripcion, string startday, string endday, string codproyecto, string codcliente, string codtipoactividad, string createdday, string codestado)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO act_agenda (codusuariorol, descripcion, startday, endday,codproyecto,codcliente, codtipoactividad, createdday,codestado) "
        + "VALUES (@codusuariorol,@descripcion,@startday,@endday,@codproyecto,@codcliente,@codtipoactividad,@createdday,@codestado);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuariorol", codusuariorol);
        conector.AsignarParametroCadena("@descripcion", descripcion);
        conector.AsignarParametroCadena("@startday", startday);
        conector.AsignarParametroCadena("@endday", endday);
        conector.AsignarParametroCadena("@codproyecto", codproyecto);
        conector.AsignarParametroCadena("@codcliente", codcliente);
        conector.AsignarParametroCadena("@codtipoactividad", codtipoactividad);
        conector.AsignarParametroCadena("@createdday", createdday);
        conector.AsignarParametroCadena("@codestado", codestado);
        return conector.guardadataid();

    }


    //Repositorio Coordinador

    public DataRow buscarEvidenciaEstrategia(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_repositoriocoordinador WHERE cod=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public DataRow buscarEvidenciaEstrategia1S002(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_repositorioasesor_s002 WHERE cod=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public DataRow buscarEvidenciaEstrategia1bitacora5(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_repositorioasesor_bitacora5 WHERE cod=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public DataRow buscarEvidenciaEstrategia1g007(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_repositorioasesor_g007 WHERE cod=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public DataRow buscarEvidenciaEstrategia4AsesorRedTematica(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_repositorioasesor_estra4 WHERE cod=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    //Asesor
    public Boolean agregarArchivoRespositorioEstrategiaAsesores(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string momento, string sesion, string actividad, string estrategia, string codproyectosede)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO est_repositorioasesor_estra4 (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,momento,sesion,actividad,estrategia,codredtematicasede) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@momento,@sesion,@actividad,@estrategia,@codproyectosede)";

        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroDouble("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fechacreado);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);

        conector.AsignarParametroCadena("@actividad", actividad);

        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean agregarArchivoRespositorioEstrategia(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string momento, string sesion, string actividad, string estrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "";

          if(actividad != "")
            consulta = "INSERT INTO est_repositoriocoordinador (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,momento,sesion,actividad,estrategia) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@momento,@sesion,@actividad,@estrategia)";
          else
              consulta = "INSERT INTO est_repositoriocoordinador (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,momento,sesion,estrategia) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@momento,@sesion,@estrategia)";

        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroDouble("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fechacreado);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);

        if(actividad != "")
            conector.AsignarParametroCadena("@actividad", actividad);
               
        conector.AsignarParametroCadena("@estrategia", estrategia);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean agregarArchivoRespositorioEstrategia5(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string sesion, string actividad, string subactividad, string estrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO est_repositoriocoordinador_estra5 (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,subactividad,sesion,actividad,estrategia) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@subactividad,@sesion,@actividad,@estrategia)";
       

        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroDouble("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fechacreado);
        conector.AsignarParametroCadena("@subactividad", subactividad);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@actividad", actividad);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean agregarArchivoRespositorioEstrategia4AsesorRedTemaica(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string momento, string sesion, string actividad, string estrategia, string codredtematica)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO est_repositorioasesor_estra4 (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,momento,sesion,actividad,estrategia,codredtematicasede) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@momento,@sesion,@actividad,@estrategia,@codredtematica)";
       
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroDouble("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fechacreado);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);

        conector.AsignarParametroCadena("@actividad", actividad);

        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@codredtematica", codredtematica);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean agregarArchivoRespositorioEstrategia4(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string momento, string sesion, string actividad, string subactividad, string estrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "";

            consulta = "INSERT INTO est_repositoriocoordinador_estra4 (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,momento,sesion,actividad,subactividad,estrategia) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@momento,@sesion,@actividad,@subactividad,@estrategia)";


        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroDouble("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fechacreado);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@actividad", actividad);
        conector.AsignarParametroCadena("@subactividad", subactividad);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean borrarEvidenciaEstrategia(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositoriocoordinador WHERE cod=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean borrarEvidenciaEstrategia1S002(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositorioasesor_s002 WHERE cod=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean borrarEvidenciaEstrategia1bitacora5(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositorioasesor_bitacora5 WHERE cod=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean borrarEvidenciaEstrategia1g007(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositorioasesor_g007 WHERE cod=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean borrarEvidenciaEstrategia1S002xCodestrategia(String codestras002)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositorioasesor_s002 WHERE codestras002=@codestras002 ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestras002", codestras002);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean borrarEvidenciaEstrategia1g007xCodestrategia(String codestrag007)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositorioasesor_g007 WHERE codestrag007=@codestrag007 ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestrag007", codestrag007);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean borrarEvidenciaEstrategia4AsesorRedTematica(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositorioasesor_estra4 WHERE cod=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }
    public DataTable cargarEvidenciasEstrategiaConActividad(string momento, string sesion, string estrategia, string actividad, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoordinador rc inner join usu_usuario u on u.cod=rc.codusuario WHERE momento=@momento and sesion=@sesion and estrategia=@estrategia and actividad=@actividad and codusuario=@codusuario ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@actividad", actividad);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarEvidenciasEstrategia(string momento, string sesion, string estrategia, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoordinador rc inner join usu_usuario u on u.cod=rc.codusuario WHERE momento=@momento and sesion=@sesion and estrategia=@estrategia and codusuario=@codusuario ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@estrategia", estrategia);
	conector.AsignarParametroCadena("@codusuario", codusuario);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarEvidenciasEstrategia5(string sesion, string subactividad, string estrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoordinador_estra5 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE subactividad=@subactividad and sesion=@sesion and estrategia=@estrategia ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@subactividad", subactividad);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarEvidenciasEstrategia4AsesorRedTematica(string codredtematicasede)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT rc.*, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositorioasesor_estra4 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE  rc.codredtematicasede=@codredtematicasede  ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        //conector.AsignarParametroCadena("@momento", momento);
        //conector.AsignarParametroCadena("@sesion", sesion);
        //conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarEvidenciasEstrategia4AsesorRedTematicaSinUsuario(string momento, string sesion, string estrategia, string codredtematicasede)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositorioasesor_estra4 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE momento=@momento and sesion=@sesion and estrategia=@estrategia and codredtematicasede=@codredtematicasede ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarEvidenciasEstrategia4(string momento, string sesion, string actividad, string estrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoordinador_estra4 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE momento=@momento and sesion=@sesion and estrategia=@estrategia and actividad=@actividad ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@actividad", actividad);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarEvidenciasEstrategiaxMomentoxSesionxActividad(string estrategia, string momento, string sesion, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        if(actividad != "")
            consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoordinador rc inner join usu_usuario u on u.cod=rc.codusuario WHERE estrategia=@estrategia and momento=@momento and sesion=@sesion and actividad=@actividad ORDER BY fechacreado ASC";
        else
            consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoordinador rc inner join usu_usuario u on u.cod=rc.codusuario WHERE estrategia=@estrategia and momento=@momento and sesion=@sesion ORDER BY fechacreado ASC";

        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);

        if (actividad != "")
            conector.AsignarParametroCadena("@actividad", actividad);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    /*function add Giancarlo.. Carga de grupos de investigacion por sede*/

    /* Funciones Instrumento G007 */

    public bool eliminarBitacoraCuatro(string codigo)
    {
        Conexion conectar = new Conexion();
        string consulta = "delete from est_estra2instrumento_g007 where codigo = @codigo";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codigo", codigo);
        return conectar.guardadata();
    }

    public DataRow loadSelectBitacoraCuatro(string codigo)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s.codigo as codigosede, s.nombre as nombresede, i.codigo as codigoinstitucion, i.nombre as nombreinstitucion, m.cod as codigomunicipio, m.nombre as nombremunicipio, d.cod as codigodepartamento, d.nombre as nombredepartamento, eeb.codproyecto as codigogrupoinvestigacion, pps.nombregrupo as nombregrupoinvestigacion  from est_estra2instrumento_g007 eeb inner join pro_proyectosede pps on pps.codigo = eeb.codproyecto inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where eeb.codigo = @codigo";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codigo", codigo);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return dato;
    }

    public DataRow loadSelectBitacoraCinco(string codigo)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s.codigo as codigosede, s.nombre as nombresede, i.codigo as codigoinstitucion, i.nombre as nombreinstitucion, m.cod as codigomunicipio, m.nombre as nombremunicipio, d.cod as codigodepartamento, d.nombre as nombredepartamento, eeb.codproyecto as codigogrupoinvestigacion, pps.nombregrupo as nombregrupoinvestigacion  from est_estra1bitacora5 eeb inner join pro_proyectosede pps on pps.codigo = eeb.codproyecto inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where eeb.codigo = @codigo";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codigo", codigo);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return dato;
    }

    public DataTable listarBitacoraCuatroSupervision(string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string sql = "select g.*, d.nombre as nombredepartamento, m.nombre as nombremunicipio, i.nombre as nombreinstitucion, s.nombre as nombresede, p.nombregrupo, concat_ws(' ',a.nombre,a.apellido) as asesor from est_estra2instrumento_g007 g inner join pro_proyectosede p on p.codigo=g.codproyecto inner join est_asesorcoordinador ac on ac.codigo=p.codasesorcoordinador inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=p.codsede inner join ins_institucion i on s.codinstitucion=i.codigo inner join geo_municipios m on i.codmunicipio=m.cod inner join geo_departamentos d on d.cod=m.coddepartamento where g.codasesorcoordinador=@codasesorcoordinador order by g.fechadiligenciamiento desc";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return resp;
    }

    public DataTable cargarLineaInvestigacion(string codSede)
    {
        Conexion conector = new Conexion();
        string sql = "SELECT * FROM pro_proyectosede WHERE codsede='" + codSede + "' ORDER BY nombregrupo ASC";
        //string sql = "select rts.codigo, concat_ws(' ', rt.nombre,rts.consecutivogrupo) as redtematica from rt_redtematicasede rts inner join rt_redtematica rt on rts.codredtematica=rt.codigo where rts.codsede=@codSede order by rts.codigo asc";
        conector.CrearComando(sql);
        //conector.AsignarParametroCadena("@codSede", codSede);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataRow buscarRubros(string codEstrategiaxAsesorCoordinador, string codGrupoInvestigacion, string estrategia, string momento, string sesion)
    {
        Conexion conector = new Conexion();
        string sql = "SELECT * FROM est_estra2instrumento_g007 WHERE codproyecto = @codGrupoInvestigacion AND codasesorcoordinador = @codEstrategiaxAsesorCoordinador AND estrategia=@estrategia AND momento=@momento AND sesion=@sesion";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codGrupoInvestigacion", codGrupoInvestigacion);
        conector.AsignarParametroCadena("@codEstrategiaxAsesorCoordinador", codEstrategiaxAsesorCoordinador);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
        //conector.AsignarParametroCadena("@actividad", actividad);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return resp;

    }

    public DataRow loadRubros(string codigo)
    {
        Conexion conector = new Conexion();
        string sql = "SELECT * FROM est_estra2instrumento_g007 WHERE codigo = @codigo ";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codigo", codigo);
     
        //conector.AsignarParametroCadena("@actividad", actividad);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return resp;

    }

    public bool agregarRubros(string codEstrategiaxAsesorCoordinador, string codGrupoInvestigacion, string valInsumo, string valPapeleria, string valTransporte, string valMaterial, string valRefrigerio, string valOtros, string estrategia, string momento, string sesion, string valInsumo2do, string valPapeleria2do, string valTransporte2do, string valMaterial2do, string valRefrigerio2do, string valOtros2do, string valInsumo3ro, string valPapeleria3ro, string valTransporte3ro, string valMaterial3ro, string valRefrigerio3ro, string valOtros3ro)
    {
        Conexion conector = new Conexion();
        string sql = "INSERT INTO est_estra2instrumento_g007 (codproyecto, codasesorcoordinador, insumo, papeleria, transporte, material, refrigerios, otro,fechadiligenciamiento,estrategia,momento,sesion, insumo2do, papeleria2do, transporte2do, material2do, refrigerios2do, otro2do, insumo3ro, papeleria3ro, transporte3ro, material3ro, refrigerios3ro, otro3ro) VALUES (@codGrupoInvestigacion, @codEstrategiaxAsesorCoordinador, @valInsumo, @valPapeleria, @valTransporte, @valMaterial, @valRefrigerio, @valOtros,NOW(),@estrategia,@momento,@sesion, @valInsumo2do, @valPapeleria2do, @valTransporte2do, @valMaterial2do, @valRefrigerio2do, @valOtros2do, @valInsumo3ro, @valPapeleria3ro, @valTransporte3ro, @valMaterial3ro, @valRefrigerio3ro, @valOtros3ro)";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codGrupoInvestigacion", codGrupoInvestigacion);
        conector.AsignarParametroCadena("@codEstrategiaxAsesorCoordinador", codEstrategiaxAsesorCoordinador);
        conector.AsignarParametroCadena("@valInsumo", valInsumo);
        conector.AsignarParametroCadena("@valPapeleria", valPapeleria);
        conector.AsignarParametroCadena("@valTransporte", valTransporte);
        conector.AsignarParametroCadena("@valMaterial", valMaterial);
        conector.AsignarParametroCadena("@valRefrigerio", valRefrigerio);
        conector.AsignarParametroCadena("@valOtros", valOtros);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@valInsumo2do", valInsumo2do);
        conector.AsignarParametroCadena("@valPapeleria2do", valPapeleria2do);
        conector.AsignarParametroCadena("@valTransporte2do", valTransporte2do);
        conector.AsignarParametroCadena("@valMaterial2do", valMaterial2do);
        conector.AsignarParametroCadena("@valRefrigerio2do", valRefrigerio2do);
        conector.AsignarParametroCadena("@valOtros2do", valOtros2do);

        conector.AsignarParametroCadena("@valInsumo3ro", valInsumo3ro);
        conector.AsignarParametroCadena("@valPapeleria3ro", valPapeleria3ro);
        conector.AsignarParametroCadena("@valTransporte3ro", valTransporte3ro);
        conector.AsignarParametroCadena("@valMaterial3ro", valMaterial3ro);
        conector.AsignarParametroCadena("@valRefrigerio3ro", valRefrigerio3ro);
        conector.AsignarParametroCadena("@valOtros3ro", valOtros3ro);
        //conector.AsignarParametroCadena("@actividad", actividad);
        return conector.guardadata();
    }

    public bool actualizarRubros(string codigoestrategia, string valInsumo, string valPapeleria, string valTransporte, string valMaterial, string valRefrigerio, string valOtros, string valInsumo2do, string valPapeleria2do, string valTransporte2do, string valMaterial2do, string valRefrigerio2do, string valOtros2do, string valInsumo3ro, string valPapeleria3ro, string valTransporte3ro, string valMaterial3ro, string valRefrigerio3ro, string valOtros3ro)
    {
        Conexion conector = new Conexion();
        string sql = "UPDATE est_estra2instrumento_g007 SET insumo = @valInsumo, papeleria = @valPapeleria, transporte = @valTransporte, material = @valMaterial, refrigerios = @valRefrigerio, otro = @valOtros, insumo2do = @valInsumo2do, papeleria2do= @valPapeleria2do, transporte2do = @valTransporte2do, material2do = @valMaterial2do, refrigerios2do = @valRefrigerio2do, otro2do = @valOtros2do, insumo3ro = @valInsumo3ro, papeleria3ro = @valPapeleria3ro, transporte3ro = @valTransporte3ro, material3ro = @valMaterial3ro, refrigerios3ro = @valRefrigerio3ro, otro3ro = @valOtros3ro, fechadiligenciamiento = NOW() WHERE codigo = @codigoestrategia";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);
        conector.AsignarParametroCadena("@valInsumo", valInsumo);
        conector.AsignarParametroCadena("@valPapeleria", valPapeleria);
        conector.AsignarParametroCadena("@valTransporte", valTransporte);
        conector.AsignarParametroCadena("@valMaterial", valMaterial);
        conector.AsignarParametroCadena("@valRefrigerio", valRefrigerio);
        conector.AsignarParametroCadena("@valOtros", valOtros);

        conector.AsignarParametroCadena("@valInsumo2do", valInsumo2do);
        conector.AsignarParametroCadena("@valPapeleria2do", valPapeleria2do);
        conector.AsignarParametroCadena("@valTransporte2do", valTransporte2do);
        conector.AsignarParametroCadena("@valMaterial2do", valMaterial2do);
        conector.AsignarParametroCadena("@valRefrigerio2do", valRefrigerio2do);
        conector.AsignarParametroCadena("@valOtros2do", valOtros2do);

        conector.AsignarParametroCadena("@valInsumo3ro", valInsumo3ro);
        conector.AsignarParametroCadena("@valPapeleria3ro", valPapeleria3ro);
        conector.AsignarParametroCadena("@valTransporte3ro", valTransporte3ro);
        conector.AsignarParametroCadena("@valMaterial3ro", valMaterial3ro);
        conector.AsignarParametroCadena("@valRefrigerio3ro", valRefrigerio3ro);
        conector.AsignarParametroCadena("@valOtros3ro", valOtros3ro);
       
        //conector.AsignarParametroCadena("@actividad", actividad);
        return conector.guardadata();
    }

    /* End Funciones Instrumento G007 */


    /* Funciones Instrumento G001 */
    /* Funciones Instrumento G001 */

    public DataTable cargarRedTematicaDocente(string codSede)
    {
        Conexion conector = new Conexion();
        string sql = "select rts.codigo, concat_ws(' ', rt.nombre,rts.consecutivogrupo) as redtematica from rt_redtematicasede rts inner join rt_redtematica rt on rts.codredtematica=rt.codigo where rts.codsede=@codSede order by rts.codigo asc";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codSede", codSede);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return resp;
    }
    public DataTable cargarDocentes(string codRedTematicaSede)
    {
        Conexion conector = new Conexion();
        string sql = "select d.nombre, d.apellido, d.identificacion, gd.cod from rt_redtematicadocente rtd inner join ins_gradodocente gd on gd.cod = rtd.codgradodocente inner join ins_docente d on d.codigo = gd.cod where rtd.codredtematicasede = @codRedTematicaSede";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codRedTematicaSede", codRedTematicaSede);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return resp;
    }

    public DataRow guardarEncabezado(string valFecha, string valtActividad, string valTema, string valFacilitador, string valhInicio, string valhFin, string codinstrumentos004)
    {
        Conexion conector = new Conexion();
        string sql = "INSERT INTO est_inasistenciasinstrumento_g001 (fecha, tipoactividad, tema, facilitador, horainicio, horafinal, codinstrumentos004) VALUES ( @valFecha, @valtActividad, @valTema, @valFacilitador, @valhInicio, @valhFin, @codinstrumentos004) RETURNING codigo";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@valFecha", valFecha);
        conector.AsignarParametroCadena("@valtActividad", valtActividad);
        conector.AsignarParametroCadena("@valTema", valTema);
        conector.AsignarParametroCadena("@valFacilitador", valFacilitador);
        conector.AsignarParametroCadena("@valhInicio", valhInicio);
        conector.AsignarParametroCadena("@valhFin", valhFin);
        conector.AsignarParametroCadena("@codinstrumentos004", codinstrumentos004);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;

    }

    public DataRow guardarEncabezadoDoc(string codEstrategiaxAsesorCoordinador, string valFecha, string valtActividad, string valTema, string valFacilitador, string valhInicio, string valhFin, string estrategia, string momento, string sesion, string codsede, string codinstrumento_s004_sede, string jornada)
    {
        Conexion conector = new Conexion();
        string sql = "INSERT INTO est_inasistenciasinstrumento_g001_doc (codasesorcoordinador, fecha, tipoactividad, tema, facilitador, horainicio, horafinal, estrategia, momento, sesion, codsede, codinstrumento_s004_sede, jornada) VALUES (@codEstrategiaxAsesorCoordinador, @valFecha, @valtActividad, @valTema, @valFacilitador, @valhInicio, @valhFin, @estrategia, @momento, @sesion, @codsede, @codinstrumento_s004_sede, @jornada) RETURNING codigo";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codEstrategiaxAsesorCoordinador", codEstrategiaxAsesorCoordinador);
        conector.AsignarParametroCadena("@valFecha", valFecha);
        conector.AsignarParametroCadena("@valtActividad", valtActividad);
        conector.AsignarParametroCadena("@valTema", valTema);
        conector.AsignarParametroCadena("@valFacilitador", valFacilitador);
        conector.AsignarParametroCadena("@valhInicio", valhInicio);
        conector.AsignarParametroCadena("@valhFin", valhFin);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@codinstrumento_s004_sede", codinstrumento_s004_sede);
        conector.AsignarParametroCadena("@jornada", jornada);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;

    }

    public bool guardarDocenteInasistente(string codInasistencia, string codDocente)
    {
        Conexion conector = new Conexion();
        string sql = "INSERT INTO est_inasistenciasinstrumento_g001detalle_doc (codinasistenciainstrumento_g001_doc, codgradodocente) VALUES (@codInasistencia, @codDocente)";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codInasistencia", codInasistencia);
        conector.AsignarParametroCadena("@codDocente", codDocente);
        return conector.guardadata();

    }

    public bool guardarEstudianteInasistente(string codInasistencia, string codEstudiante)
    {

        Conexion conector = new Conexion();
        string sql = "INSERT INTO est_inasistenciasinstrumento_g001detalle (codinasistenciainstrumento_g001, codestumatricula) VALUES (@codInasistencia, @codEstudiante)";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codInasistencia", codInasistencia);
        conector.AsignarParametroCadena("@codEstudiante", codEstudiante);
        return conector.guardadata();

    }

    /* End Funciones Instrumento G001 */

    public DataTable cargarAsesores(string codasesor)
    {
        Conexion conector = new Conexion();
        string sql = "SELECT ac.codigo, a.nombre, a.apellido FROM est_asesor a INNER JOIN est_asesorcoordinador ac ON ac.codasesor = a.codigo INNER JOIN est_estracoordinador sc ON sc.codigo = ac.codestracoordinador WHERE ac.codigo = @codasesor";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codasesor", codasesor);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return resp;
    }
    public DataTable cargarAsesoresxCoordinador(string codestracoordinador)
    {
        Conexion conector = new Conexion();
        string sql = "SELECT a.codigo, a.nombre, a.apellido FROM est_asesor a INNER JOIN est_asesorcoordinador ac ON ac.codasesor = a.codigo INNER JOIN est_estracoordinador sc ON sc.codigo = ac.codestracoordinador WHERE ac.codestracoordinador= @codestracoordinador";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return resp;
    }
    public DataRow encabezadoS002(string codProyecto, string codAsesor, string noAsesoria, string fechaVisita, string duracionHoras, string tipoAcompaniamiento, string motivoAsesoria, string objetivo, string estrategia, string momento, string sesion, string noproyectadas, string noasistentes)
        //public DataRow encabezadoS002(string codProyecto, string codAsesor, string nomInvestigacion, string noAsesoria, string fechaVisita, string duracionHoras, string tipoAcompaniamiento, string motivoAsesoria, string objetivo, string estrategia, string momento, string sesion)
    {
        Conexion conector = new Conexion();
        string sql = "INSERT INTO est_estra2instrumento_s002 (codproyecto, codasesor, noasesoria, fechavisita, duracion_horas, tipoasesoria, motivoasesoria, objetivo, estrategia, momento, sesion,noproyectadas, noasistentes) VALUES (@codProyecto, @codAsesor, @noAsesoria, @fechaVisita, @duracionHoras, @tipoAcompaniamiento, @motivoAsesoria, @objetivo,@estrategia,@momento, @sesion, @noproyectadas, @noasistentes) RETURNING codigo";
        //string sql = "INSERT INTO est_estra2instrumento_s002 (codproyecto, codasesor, nominvestigacion, noasesoria, fechavisita, duracion_horas, tipoasesoria, motivoasesoria, objetivo, estrategia, momento, sesion) VALUES (@codProyecto, @codAsesor, @nomInvestigacion, @noAsesoria, @fechaVisita, @duracionHoras, @tipoAcompaniamiento, @motivoAsesoria, @objetivo,@estrategia,@momento, @sesion) RETURNING codigo";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codProyecto", codProyecto);
        conector.AsignarParametroCadena("@codAsesor", codAsesor);
        //conector.AsignarParametroCadena("@nomInvestigacion", nomInvestigacion);
        conector.AsignarParametroCadena("@noAsesoria", noAsesoria);
        conector.AsignarParametroCadena("@fechaVisita", fechaVisita);
        conector.AsignarParametroCadena("@duracionHoras", duracionHoras);
        conector.AsignarParametroCadena("@tipoAcompaniamiento", tipoAcompaniamiento);
        conector.AsignarParametroCadena("@motivoAsesoria", motivoAsesoria);
        conector.AsignarParametroCadena("@objetivo", objetivo);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
		conector.AsignarParametroCadena("@noproyectadas", noproyectadas);
        conector.AsignarParametroCadena("@noasistentes", noasistentes);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow encabezadoEvalAsesoria(string codGrupoInvestigacion, string codAsesor, string codGradoDocente, string codEntidad, string tema, string fecha)
    {
        Conexion conectar = new Conexion();
        string sql = "INSERT INTO est_estra1evalasesoria (codasesor, codentidad, codproyecto, codgradodocente, tema, fechaevaluacion) VALUES (@codAsesor, @codEntidad, @codGrupoInvestigacion, @codGradoDocente, @tema, @fecha) RETURNING codigo";
        conectar.CrearComando(sql);
        conectar.AsignarParametroCadena("@codAsesor", codAsesor);
        conectar.AsignarParametroCadena("@codEntidad", codEntidad);
        conectar.AsignarParametroCadena("@codGrupoInvestigacion", codGrupoInvestigacion);
        conectar.AsignarParametroCadena("@codGradoDocente", codGradoDocente);
        conectar.AsignarParametroCadena("@tema", tema);
        conectar.AsignarParametroCadena("@fecha", fecha);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public bool resEvalAsesoriapCerrada(string codEstraEvalAsesoria, string codPregunta, string Calificacion)
    {
        Conexion conectar = new Conexion();
        string sql = "INSERT INTO est_estra1evalasesoria_pcerrada (codevalasesoria, codpregunta, calificacion) VALUES (@codEstraEvalAsesoria, @codPregunta, @Calificacion)";
        conectar.CrearComando(sql);
        conectar.AsignarParametroCadena("@codEstraEvalAsesoria", codEstraEvalAsesoria);
        conectar.AsignarParametroCadena("@codPregunta", codPregunta);
        conectar.AsignarParametroCadena("@Calificacion", Calificacion);
        return conectar.guardadata();
    }

    public bool resEvalAsesoriapAbierta(string codEstraEvalAsesoria, string sugerencias)
    {
        Conexion conectar = new Conexion();
        string sql = "INSERT INTO est_estra1evalasesoria_pabierta (codevalasesoria, sugerencia) VALUES (@codEstraEvalAsesoria, @sugerencias)";
        conectar.CrearComando(sql);
        conectar.AsignarParametroCadena("@codEstraEvalAsesoria", codEstraEvalAsesoria);
        conectar.AsignarParametroCadena("@sugerencias", sugerencias);
        return conectar.guardadata();
    }

    public DataTable cargarAsesorDocente(string codDocente)
    {
        Conexion conector = new Conexion();
        string sql = "SELECT a.codigo, a.nombre, a.apellido FROM est_asesor a INNER JOIN est_asesorcoordinador ac ON ac.codasesor = a.codigo INNER JOIN est_asesorcoordocente acd ON acd.codasesorcoordinador = ac.codigo WHERE acd.codgradodocente = @codDocente";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codDocente", codDocente);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return resp;
    }

    public DataTable cargarGrupoInvestigacion(string codGradoDocente)
    {
        Conexion conector = new Conexion();
        string sql = "SELECT pro.nombre, pro.codigo FROM pro_proyecto pro INNER JOIN pro_proyectosede pros ON pros.codproyecto = pro.codigo  WHERE pros.codgradodocente = @codGradoDocente";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codGradoDocente", codGradoDocente);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataRow cargarOperadorCoordinador(string codAsesorCoordinador)
    {
        Conexion conectar = new Conexion();
        string sql = "SELECT oc.codigo, oc.nombre FROM est_coordinador c INNER JOIN est_estracoordinador ec ON ec.codcoordinador = c.codigo INNER JOIN est_asesorcoordinador ac ON ac.codestracoordinador = ec.codigo INNER JOIN est_asesorcoordocente acd ON acd.codasesorcoordinador = ac.codigo inner join est_operadorcoordinador oc on oc.codigo=c.codoperadorcoordinador where acd.codasesorcoordinador = @codAsesorCoordinador GROUP BY oc.codigo, oc.nombre";
        //string sql = "SELECT c.codigo, c.nombre, c.apellido FROM est_coordinador c INNER JOIN est_estracoordinador ec ON ec.codcoordinador = c.codigo INNER JOIN est_asesorcoordinador ac ON ac.codestracoordinador = ec.codigo INNER JOIN est_asesorcoordocente acd ON acd.codasesorcoordinador = ac.codigo where acd.codasesorcoordinador = @codAsesorCoordinador GROUP BY c.codigo, c.nombre, c.apellido";
        conectar.CrearComando(sql);
        conectar.AsignarParametroCadena("@codAsesorCoordinador", codAsesorCoordinador);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    /* nueva function add giancarlo g001 estrategia 4*/

    public DataTable cargarRedTematica(string codSede)
    {
        string estado = "On";
        Conexion conectar = new Conexion();
        //string consulta = "SELECT rt.codigo, rt.nombre FROM rt_redtematica rt INNER JOIN rt_redtematicasede rts ON rts.codredtematica = rt.codigo WHERE rts.codsede = @codSede AND rt.estado = @estado GROUP BY rt.codigo, rt.nombre, rt.estado";
        string consulta = "select rts.codigo, concat_ws(' ',rt.nombre,rts.consecutivogrupo) as nombre from rt_redtematicasede rts left join rt_redtematica rt on rts.codredtematica=rt.codigo WHERE rts.codsede = @codSede AND rt.estado = @estado order by rts.codigo ASC";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codSede", codSede);
        conectar.AsignarParametroCadena("@estado", estado);
        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public DataTable cargarEstudiante(string codRedTematica, string codSede)
    {
        Conexion conectar = new Conexion();
        string consulta = "select * from ins_estudiante e  inner join ins_estumatricula em on em.codestudiante = e.codigo inner join rt_redtematicamatricula rtm on rtm.codestumatricula = em.codigo inner join rt_redtematicasede rts on rts.codigo=rtm.codredtematicasede inner join rt_redtematica rt on rt.codigo=rts.codredtematica where rts.codsede = @codSede and rtm.codredtematicasede =@codRedTematica";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codSede", codSede);
        conectar.AsignarParametroCadena("@codRedTematica", codRedTematica);
        DataTable datos = conectar.traerdata();
        if (datos != null)
        {
            return datos;
        }
        else
        {
            return null;
        }
    }

    public DataTable cargarEstudianteRedesTematicas(string codRedTematica)
    {
        Conexion conectar = new Conexion();
        string consulta = "select * from ins_estudiante e  inner join ins_estumatricula em on em.codestudiante = e.codigo inner join rt_redtematicamatricula rtm on rtm.codestumatricula = em.codigo inner join rt_redtematicasede rts on rts.codigo=rtm.codredtematicasede inner join rt_redtematica rt on rt.codigo=rts.codredtematica where rtm.codredtematicasede =@codRedTematica";
        conectar.CrearComando(consulta);
        
        conectar.AsignarParametroCadena("@codRedTematica", codRedTematica);
        DataTable datos = conectar.traerdata();
        if (datos != null)
        {
            return datos;
        }
        else
        {
            return null;
        }
    }

    public bool updateEstudiante(string codEstudiante, string tdocumentoEstudiante, string nombreEstudiante, string apellidoEstudiante, string identificacionEstudiante, string sexoEstudiante, string fnacimientoEstudiante, string telefonoEstudiante, string direccionEstudiante, string emailEstudiante)
    {
        Conexion conectar = new Conexion();
        string consulta = "update ins_estudiante set nombre=@nombreEstudiante, apellido=@apellidoEstudiante, identificacion=@identificacionEstudiante, sexo=@sexoEstudiante, fecha_nacimiento=@fnacimientoEstudiante, telefono=@telefonoEstudiante, direccion=@direccionEstudiante, email=@emailEstudiante, codtipodocumento=@tdocumentoEstudiante where codigo=@codEstudiante";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@nombreEstudiante", nombreEstudiante);
        conectar.AsignarParametroCadena("@apellidoEstudiante", apellidoEstudiante);
        conectar.AsignarParametroCadena("@identificacionEstudiante", identificacionEstudiante);
        conectar.AsignarParametroCadena("@sexoEstudiante", sexoEstudiante);
        conectar.AsignarParametroCadena("@fnacimientoEstudiante", fnacimientoEstudiante);
        conectar.AsignarParametroCadena("@telefonoEstudiante", telefonoEstudiante);
        conectar.AsignarParametroCadena("@direccionEstudiante", direccionEstudiante);
        conectar.AsignarParametroCadena("@emailEstudiante", emailEstudiante);
        conectar.AsignarParametroCadena("@tdocumentoEstudiante", tdocumentoEstudiante);
        conectar.AsignarParametroCadena("@codEstudiante", codEstudiante);
        return conectar.guardadata();
    }

    public bool deleteEstudiante(string codEstudiante)
    {
        Conexion conectar = new Conexion();
        string consulta = "delete from rt_redtematicamatricula where codestumatricula = @codEstudiante";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codEstudiante", codEstudiante);
        return conectar.guardadata();
    }


    public bool deleteEstudianteRedTematicaSede(string codredtematicasede)
    {
        Conexion conectar = new Conexion();
        string consulta = "delete from rt_redtematicamatricula where codredtematicasede = @codredtematicasede";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        return conectar.guardadata();
    }

    public bool deleteDocenteRedTematicaSede(string codredtematicasede)
    {
        Conexion conectar = new Conexion();
        string consulta = "delete from rt_redtematicadocente where codredtematicasede = @codredtematicasede";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        return conectar.guardadata();
    }

    public bool deleteRedTematicaSede(string codigo)
    {
        Conexion conectar = new Conexion();
        string consulta = "delete from rt_redtematicasede where codigo = @codigo";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codigo", codigo);
        return conectar.guardadata();
    }

    /* funciones Bitacora 5 */
    public DataRow encabezadoBitacora5(string codProyecto, string objetivoFinal, string nomTrayectoIndagacion, string dificultadesFortalezas, string principalesCaracteristicas, string importanciaInvestigacion, string importanciaIEP, string general, string especifico, string estrategia, string momento, string sesion, string nomTrayectoIndagacion2, string nomTrayectoIndagacion3)
    {
        Conexion conectar = new Conexion();
        string sql = "INSERT INTO est_estra1bitacora5 (codproyecto, objetivofinal, nomtrayectoindagacion, dificultadesfortalezas, principalescaracteristicas, importanciasinvestigacion, importanciaiep,general,especifico, estrategia,momento,sesion, nomTrayectoIndagacion2, nomTrayectoIndagacion3,fechacreado) VALUES (@codProyecto, @objetivoFinal, @nomTrayectoIndagacion, @dificultadesFortalezas, @principalesCaracteristicas, @importanciaInvestigacion, @importanciaIEP,@general,@especifico,@estrategia,@momento,@sesion, @nomTrayectoIndagacion2,@nomTrayectoIndagacion3,NOW() ) RETURNING codigo";
        conectar.CrearComando(sql);
        conectar.AsignarParametroCadena("@codProyecto", codProyecto);
        conectar.AsignarParametroCadena("@objetivoFinal", objetivoFinal);
        conectar.AsignarParametroCadena("@nomTrayectoIndagacion", nomTrayectoIndagacion);
        conectar.AsignarParametroCadena("@nomTrayectoIndagacion2", nomTrayectoIndagacion2);
        conectar.AsignarParametroCadena("@nomTrayectoIndagacion3", nomTrayectoIndagacion3);
        conectar.AsignarParametroCadena("@dificultadesFortalezas", dificultadesFortalezas);
        conectar.AsignarParametroCadena("@principalesCaracteristicas", principalesCaracteristicas);
        conectar.AsignarParametroCadena("@importanciaInvestigacion", importanciaInvestigacion);
        conectar.AsignarParametroCadena("@importanciaIEP", importanciaIEP);
        conectar.AsignarParametroCadena("@general", general);
        conectar.AsignarParametroCadena("@especifico", especifico);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        conectar.AsignarParametroCadena("@momento", momento);
        conectar.AsignarParametroCadena("@sesion", sesion);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public bool bitacora5Detalles(string codEstraBitacora, string actividad, string herramienta, string responsable, string duracion, string presupuesto)
    {
        Conexion conectar = new Conexion();
        string consulta = "INSERT INTO est_estra1bitacora5_detalle (codestraunobitacoracinco, actividades, herramientas, responsable, duracionmeses, presupuestorequerido) VALUES (@codEstraBitacora, @actividad, @herramienta, @responsable, @duracion, @presupuesto)";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codEstraBitacora", codEstraBitacora);
        conectar.AsignarParametroCadena("@actividad", actividad);
        conectar.AsignarParametroCadena("@herramienta", herramienta);
        conectar.AsignarParametroCadena("@responsable", responsable);
        conectar.AsignarParametroCadena("@duracion", duracion);
        conectar.AsignarParametroCadena("@presupuesto", presupuesto);
        return conectar.guardadata();
    }
    public bool bitacora5Detalles_2do(string codEstraBitacora, string actividad, string herramienta, string responsable, string duracion, string presupuesto)
    {
        Conexion conectar = new Conexion();
        string consulta = "INSERT INTO est_estra1bitacora5_detalle_2 (codestraunobitacoracinco, actividades, herramientas, responsable, duracionmeses, presupuestorequerido) VALUES (@codEstraBitacora, @actividad, @herramienta, @responsable, @duracion, @presupuesto)";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codEstraBitacora", codEstraBitacora);
        conectar.AsignarParametroCadena("@actividad", actividad);
        conectar.AsignarParametroCadena("@herramienta", herramienta);
        conectar.AsignarParametroCadena("@responsable", responsable);
        conectar.AsignarParametroCadena("@duracion", duracion);
        conectar.AsignarParametroCadena("@presupuesto", presupuesto);
        return conectar.guardadata();
    }

    public bool bitacora5Detalles_3ro(string codEstraBitacora, string actividad, string herramienta, string responsable, string duracion, string presupuesto)
    {
        Conexion conectar = new Conexion();
        string consulta = "INSERT INTO est_estra1bitacora5_detalle_3 (codestraunobitacoracinco, actividades, herramientas, responsable, duracionmeses, presupuestorequerido) VALUES (@codEstraBitacora, @actividad, @herramienta, @responsable, @duracion, @presupuesto)";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codEstraBitacora", codEstraBitacora);
        conectar.AsignarParametroCadena("@actividad", actividad);
        conectar.AsignarParametroCadena("@herramienta", herramienta);
        conectar.AsignarParametroCadena("@responsable", responsable);
        conectar.AsignarParametroCadena("@duracion", duracion);
        conectar.AsignarParametroCadena("@presupuesto", presupuesto);
        return conectar.guardadata();
    }

    //Bitacora 1
    public bool agregarBitacora1Estrategia1(string codproyectosede, string relato, string fechacreacion, string codasesor, string estrategia, string momento, string sesion)
    {
        Conexion conectar = new Conexion();
        string consulta = "INSERT INTO est_estra1bitacora1 (codproyectosede, relato, fechacreacion, codasesorcoordinador, estrategia, momento, sesion) VALUES (@codproyectosede,@relato,@fechacreacion,@codasesor,@estrategia,@momento,@sesion)";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codproyectosede", codproyectosede);
        conectar.AsignarParametroCadena("@relato", relato);
        conectar.AsignarParametroCadena("@fechacreacion", fechacreacion);
        conectar.AsignarParametroCadena("@codasesor", codasesor);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        conectar.AsignarParametroCadena("@momento", momento);
        conectar.AsignarParametroCadena("@sesion", sesion);
        return conectar.guardadata();
    }

    //Listado de memorias Instrumento S004 Estrategia 4

    public DataTable cargarListadoMemorias(string codAsesorCoordinador, string offset, string limit)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004redt.codigo, s004redt.codredtematicasede, s004redt.nombresesion, rt.nombre, s004redt.fechaelaboracion, rts.consecutivogrupo, s004redt.momento, s004redt.sesion, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estra2instrumento_s004_redt s004redt inner join rt_redtematicasede rts on rts.codigo = s004redt.codredtematicasede inner join rt_redtematica rt on rt.codigo = rts.codredtematica inner join ins_sede s on s.codigo = rts.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004redt.codasesorcoordinador = @codAsesorCoordinador offset @offset limit @limit";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codAsesorCoordinador", codAsesorCoordinador);
        conectar.AsignarParametroCadena("@limit", limit);
        conectar.AsignarParametroCadena("@offset", offset);
        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return datos;
    }

    public DataTable cargarListadoMemorias_2016(string codAsesorCoordinador, string offset, string limit)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004redt.codigo, s004redt.codredtematicasede, s004redt.nombresesion, rt.nombre, s004redt.fechaelaboracion, rts.consecutivogrupo, s004redt.momento, s004redt.sesion, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estra2instrumento_s004_redt_2016 s004redt inner join rt_redtematicasede rts on rts.codigo = s004redt.codredtematicasede inner join rt_redtematica rt on rt.codigo = rts.codredtematica inner join ins_sede s on s.codigo = rts.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004redt.codasesorcoordinador = @codAsesorCoordinador offset @offset limit @limit";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codAsesorCoordinador", codAsesorCoordinador);
        conectar.AsignarParametroCadena("@limit", limit);
        conectar.AsignarParametroCadena("@offset", offset);
        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return datos;
    }

    public DataTable cargarListadoMemoriasCountCoord(string codAsesorCoordinador)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004redt.codigo, s004redt.codredtematicasede, s004redt.nombresesion, rt.nombre, s004redt.fechaelaboracion, rts.consecutivogrupo, s004redt.momento, s004redt.sesion, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estra2instrumento_s004_redt s004redt inner join rt_redtematicasede rts on rts.codigo = s004redt.codredtematicasede inner join rt_redtematica rt on rt.codigo = rts.codredtematica inner join ins_sede s on s.codigo = rts.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004redt.codasesorcoordinador = @codAsesorCoordinador ";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codAsesorCoordinador", codAsesorCoordinador);
        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return datos;
    }

    public DataTable cargarListadoMemoriasCountCoord_2016(string codAsesorCoordinador)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004redt.codigo, s004redt.codredtematicasede, s004redt.nombresesion, rt.nombre, s004redt.fechaelaboracion, rts.consecutivogrupo, s004redt.momento, s004redt.sesion, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estra2instrumento_s004_redt_2016 s004redt inner join rt_redtematicasede rts on rts.codigo = s004redt.codredtematicasede inner join rt_redtematica rt on rt.codigo = rts.codredtematica inner join ins_sede s on s.codigo = rts.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004redt.codasesorcoordinador = @codAsesorCoordinador ";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codAsesorCoordinador", codAsesorCoordinador);
        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return datos;
    }

    public DataRow loadSelectInstrumentos004(string codRedtematica)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s.codigo as codigosede, s.nombre as nombresede, i.codigo as codigoinstitucion, i.nombre as nombreinstitucion, m.cod as codigomunicipio, m.nombre as nombremunicipio, d.cod as codigodepartamento, d.nombre as nombredepartamento,rts.codigo as codigoredtematica,concat_ws(' ', rt.nombre,rts.consecutivogrupo) as redtematica from est_estra2instrumento_s004_redt s004 inner join rt_redtematicasede rts on rts.codigo = s004.codredtematicasede inner join rt_redtematica rt on rts.codredtematica=rt.codigo inner join ins_sede s on s.codigo = rts.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004.codigo = @codRedtematica";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codRedtematica", codRedtematica);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return dato;
    }


    //Evaluciona de asesoria S007

    public DataTable loadEntidad()
    {
        Conexion conectar = new Conexion();
        string consulta = "select codigo, nombre as entidad from est_operadorcoordinador";
        conectar.CrearComando(consulta);
        DataTable dato = conectar.traerdata();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataTable loadAsesores(string codEntidad)
    {
        Conexion conectar = new Conexion();
        string consulta = "Select ac.codigo, concat_ws(' ', a.nombre, a.apellido) as asesor from est_asesor a inner join est_asesorcoordinador ac on ac.codasesor = a.codigo inner join est_coordinador c on c.codigo = ac.codestracoordinador inner join est_operadorcoordinador oc on oc.codigo = c.codoperadorcoordinador where oc.codigo = @codEntidad";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codEntidad", codEntidad);
        DataTable dato = conectar.traerdata();
        if (dato != null)
            return dato;
        else
            return null;
    }
    /*2016-10-24 JONNY PACHECO metodo para  llenar los select municipios,sedes...*/
    public DataRow loadSelectBitacoraDos(string codproyecto)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s.codigo as codigosede, s.nombre as nombresede, i.codigo as codigoinstitucion, i.nombre as nombreinstitucion, m.cod as codigomunicipio, m.nombre as nombremunicipio, d.cod as codigodepartamento, d.nombre as nombredepartamento, eeb.codproyecto as codigogrupoinvestigacion, pps.nombregrupo as nombregrupoinvestigacion  from est_estra1bitacora2 eeb inner join pro_proyectosede pps on pps.codigo = eeb.codproyecto inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where eeb.codproyecto = @codproyecto";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codproyecto", codproyecto);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return dato;
    }
    public DataRow loadSelectBitacoraTres(string codproyecto)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s.codigo as codigosede, s.nombre as nombresede, i.codigo as codigoinstitucion, i.nombre as nombreinstitucion, m.cod as codigomunicipio, m.nombre as nombremunicipio, d.cod as codigodepartamento, d.nombre as nombredepartamento, eeb.codproyecto as codigogrupoinvestigacion, pps.nombregrupo as nombregrupoinvestigacion  from est_estra1bitacora3 eeb inner join pro_proyectosede pps on pps.codigo = eeb.codproyecto inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where eeb.codproyecto = @codproyecto";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codproyecto", codproyecto);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return dato;
    }

    public DataRow traerPreguntasTres(string codproyecto)
    {
        Conexion conectar = new Conexion();
        string consulta = "select codigo,respuestapregunta1,respuestapregunta2  from est_estra1bitacora3 where codigo=@codproyecto";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codproyecto", codproyecto);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return dato;
    }

    // funciones s005

    public DataTable cargarListadoRelatos(string codAsesorCoordinador)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s005.codigo, s005.nombresesion, s005.temasesion, s005.fechaelaboracion, s005.momento, s005.sesion, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estra2instrumento_s005 s005 inner join ins_sede s on s.codigo = s005.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s005.codasesorcoordinador = @codAsesorCoordinador";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codAsesorCoordinador", codAsesorCoordinador);
        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return datos;
    }

    public DataRow insertS005(string codAsesorCoordinador, string nombreSesion, string temaSesion, string fechaElaboracion, string horaSesion, string nombreRelator, string emailRelator, string productoSolicitado, string bibliografia, string estrategia, string momento, string sesion, string codSede)
    {
        Conexion conectar = new Conexion();
        string sql = "insert into est_estra2instrumento_s005 (codasesorcoordinador, nombresesion, temasesion, fechaelaboracion, horasesion, nombrerelator, emailrelator, productosolicitados, bibliografia, estrategia, momento, sesion, codsede) values (@codAsesorCoordinador, @nombreSesion, @temaSesion, @fechaElaboracion, @horaSesion, @nombreRelator, @emailRelator, @productoSolicitado, @bibliografia, @estrategia, @momento, @sesion, @codSede) returning codigo";
        conectar.CrearComando(sql);
        conectar.AsignarParametroCadena("@codAsesorCoordinador", codAsesorCoordinador);
        conectar.AsignarParametroCadena("@nombreSesion", nombreSesion);
        conectar.AsignarParametroCadena("@temaSesion", temaSesion);
        conectar.AsignarParametroCadena("@fechaElaboracion", fechaElaboracion);
        conectar.AsignarParametroCadena("@horaSesion", horaSesion);
        conectar.AsignarParametroCadena("@nombreRelator", nombreRelator);
        conectar.AsignarParametroCadena("@emailRelator", emailRelator);
        conectar.AsignarParametroCadena("@productoSolicitado", productoSolicitado);
        conectar.AsignarParametroCadena("@bibliografia", bibliografia);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        conectar.AsignarParametroCadena("@momento", momento);
        conectar.AsignarParametroCadena("@sesion", sesion);
        conectar.AsignarParametroCadena("@codSede", codSede);
        DataRow codigo = conectar.traerfila();
        if (codigo != null)
            return codigo;
        else
            return null;
    }

    public long deletePreguntasS005(string codigoEstrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2instrumento_s005_preguntas WHERE codestrainstrumento_s005 = @codigoEstrategia;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoEstrategia", codigoEstrategia);
        long resp = conector.guardadataid();
        return resp;
    }

    public DataRow insertPreguntass005(string codigoestrategia, string nopregunta, string pregunta)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra2instrumento_s005_preguntas (codestrainstrumento_s005, pregunta, nopregunta) VALUES (@codigoestrategia,@pregunta,@nopregunta) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);
        conector.AsignarParametroCadena("@pregunta", pregunta);
        conector.AsignarParametroCadena("@nopregunta", nopregunta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow loadestras005(string codigo, string estrategia, string momento, string sesion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, codasesorcoordinador, nombresesion, temasesion, horasesion, nombrerelator, emailrelator, productosolicitados, bibliografia FROM est_estra2instrumento_s005 WHERE codigo = @codigo and estrategia=@estrategia and momento=@momento and sesion=@sesion";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);

        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow loadSelectInstrumentos005(string codigo)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s.codigo as codigosede, s.nombre as nombresede, i.codigo as codigoinstitucion, i.nombre as nombreinstitucion, m.cod as codigomunicipio, m.nombre as nombremunicipio, d.cod as codigodepartamento, d.nombre as nombredepartamento from est_estra2instrumento_s005 s005 inner join ins_sede s on s.codigo = s005.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s005.codigo = @codigo";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codigo", codigo);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return dato;
    }

    public DataTable procloadPreguntass005(string codigoestrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, codestrainstrumento_s005, pregunta, nopregunta FROM est_estra2instrumento_s005_preguntas WHERE codestrainstrumento_s005 = @codigoestrategia ORDER BY nopregunta ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);
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

    public long procupdateestras005(string codigoestrategia, string nombresesion, string temasesion, string nombrerelator, string emailrelator, string horasesion, string productossolicitados, string bibliografia)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra2instrumento_s005 SET nombresesion = @nombresesion, temasesion = @temasesion, fechaelaboracion = NOW(), horasesion = @horasesion, nombrerelator=@nombrerelator, emailrelator=@emailrelator, productosolicitados=@productossolicitados, bibliografia=@bibliografia WHERE codigo = @codigoestrategia";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombresesion", nombresesion);
        conector.AsignarParametroCadena("@temasesion", temasesion);
        conector.AsignarParametroCadena("@emailrelator", emailrelator);
        conector.AsignarParametroCadena("@horasesion", horasesion);
        conector.AsignarParametroCadena("@nombrerelator", nombrerelator);
        conector.AsignarParametroCadena("@productossolicitados", productossolicitados);
        conector.AsignarParametroCadena("@bibliografia", bibliografia);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);

        long resp = conector.guardadataid();
        return resp;
    }

    public bool guardarInformeFinanciero(string codestraunobitacoracuatrouno, string rubros, string fechaGasto, string nombreProveedor, string descripcionGasto, string valorTotal)
    {
        Conexion conectar = new Conexion();
        string consulta = "insert into est_estra1bitacora4_1detalle (codestraunobitacoracuatrouno, rubros, fechagasto, nombreproveedor, descripciongasto, valortotal) values (@codEstraAsesorCoordinador, @rubros, @fechaGasto, @nombreProveedor, @descripcionGasto, @valorTotal)";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codestraunobitacoracuatrouno", codestraunobitacoracuatrouno);
        conectar.AsignarParametroCadena("@rubros", rubros);
        conectar.AsignarParametroCadena("@fechaGasto", fechaGasto);
        conectar.AsignarParametroCadena("@nombreProveedor", nombreProveedor);
        conectar.AsignarParametroCadena("@descripcionGasto", descripcionGasto);
        conectar.AsignarParametroCadena("@valorTotal", valorTotal);
        bool response = conectar.guardadata();
        return response;
    }


    //S006 listado de relatoria por asesor

    public DataTable listarrelatorias(string codasesorcoordinador, string momento, string sesion, string estrategia)
    {
        Conexion conectar = new Conexion();
        string sql = "select s006.*, s.codigo as codsede, s.nombre as sede, i.codigo as codinstitucion, i.nombre as institucion, d.nombre as departamento, m.nombre as municipio from est_estra2instrumento_s006 s006 inner join ins_sede s on s.codigo = s006.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where codasesorcoordinador = @codasesorcoordinador and momento = @momento and sesion = @sesion and estrategia = @estrategia";
        conectar.CrearComando(sql);
        conectar.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conectar.AsignarParametroCadena("@momento", momento);
        conectar.AsignarParametroCadena("@sesion", sesion);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        DataTable relatos = conectar.traerdata();
        if (relatos != null)
            return relatos;
        else
            return null;
    }

    //s004  coordinadores añadida 8/11/2016

    public DataTable listarAsesores(string estrategia)
    {
        Conexion conectar = new Conexion();
        string sql = "select distinct ac.codigo, (a.nombre || ' ' || a.apellido) asesor, a.nombre  from est_asesorcoordinador ac left join est_estracoordinador ec on ac.codestracoordinador=ec.codigo inner join est_coordinador c on c.codigo=ec.codcoordinador inner join est_asesor a on a.codigo=ac.codasesor where ec.codestrategia=@estrategia order by a.nombre asc";
        //string sql = "select distinct ac.codigo, (a.nombre || ' ' || a.apellido) asesor, a.nombre  from est_estracoordinador ec inner join est_asesorcoordinador ac on ac.codestracoordinador = ec.codestrategia inner join est_asesor a on a.codigo = ac.codasesor where ec.codestrategia = @estrategia order by a.nombre asc";
	conectar.CrearComando(sql);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        DataTable asesores = conectar.traerdata();
        if (asesores != null)
            return asesores;
        else
            return null;
    }

    //Listado de memorias Instrumento S004 Estrategia 4

    public DataTable cargarListadoMemoriasS004(string codAsesor, string estrategia, string momento, string sesion, string offset, string limit)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004redt.codigo, s004redt.codredtematicasede, s004redt.nombresesion, rt.nombre, s004redt.fechaelaboracion, rts.consecutivogrupo, s004redt.momento, s004redt.sesion, rts.codsede, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estra2instrumento_s004_redt s004redt inner join rt_redtematicasede rts on rts.codigo = s004redt.codredtematicasede inner join rt_redtematica rt on rt.codigo = rts.codredtematica inner join ins_sede s on s.codigo = rts.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004redt.codasesorcoordinador = @codAsesor and s004redt.estrategia = @estrategia and s004redt.momento = @momento and s004redt.sesion = @sesion offset @offset limit @limit";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codAsesor", codAsesor);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        conectar.AsignarParametroCadena("@momento", momento);
        conectar.AsignarParametroCadena("@sesion", sesion);
        conectar.AsignarParametroCadena("@offset", offset);
        conectar.AsignarParametroCadena("@limit", limit);
        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return datos;
    }

    public DataTable cargarListadoMemoriasCount(string codAsesor, string estrategia, string momento, string sesion)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004redt.codigo, s004redt.codredtematicasede, s004redt.nombresesion, rt.nombre, s004redt.fechaelaboracion, rts.consecutivogrupo, s004redt.momento, s004redt.sesion, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estra2instrumento_s004_redt s004redt inner join rt_redtematicasede rts on rts.codigo = s004redt.codredtematicasede inner join rt_redtematica rt on rt.codigo = rts.codredtematica inner join ins_sede s on s.codigo = rts.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004redt.codasesorcoordinador = @codAsesor and s004redt.estrategia = @estrategia and s004redt.momento = @momento and s004redt.sesion = @sesion";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codAsesor", codAsesor);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        conectar.AsignarParametroCadena("@momento", momento);
        conectar.AsignarParametroCadena("@sesion", sesion);
        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return datos;
    }
    public DataTable cargarListadoMemoriasCount_2016(string codAsesor, string estrategia, string momento, string sesion)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004redt.codigo, s004redt.codredtematicasede, s004redt.nombresesion, rt.nombre, s004redt.fechaelaboracion, rts.consecutivogrupo, s004redt.momento, s004redt.sesion, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estra2instrumento_s004_redt_2016 s004redt inner join rt_redtematicasede rts on rts.codigo = s004redt.codredtematicasede inner join rt_redtematica rt on rt.codigo = rts.codredtematica inner join ins_sede s on s.codigo = rts.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004redt.codasesorcoordinador = @codAsesor and s004redt.estrategia = @estrategia and s004redt.momento = @momento and s004redt.sesion = @sesion";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codAsesor", codAsesor);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        conectar.AsignarParametroCadena("@momento", momento);
        conectar.AsignarParametroCadena("@sesion", sesion);
        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return datos;
    }
    public DataRow buscarRegistroMemoriaS004(string codredtematicasede)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004redt.codigo, s004redt.codredtematicasede, s004redt.nombresesion, rt.nombre, s004redt.fechaelaboracion, rts.consecutivogrupo, s004redt.momento, s004redt.sesion, rts.codsede, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estra2instrumento_s004_redt s004redt inner join rt_redtematicasede rts on rts.codigo = s004redt.codredtematicasede inner join rt_redtematica rt on rt.codigo = rts.codredtematica inner join ins_sede s on s.codigo = rts.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004redt.codredtematicasede = @codredtematicasede limit 1";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        DataRow asesorias = conectar.traerfila();
        if (asesorias != null)
            return asesorias;
        else
            return null;
    }
    //Listado de memorias Instrumento S004 Estrategia 2

    public long procupdateestras004Sede(string codsede, string nombresesion, string temasesion, string informacionadicional, string fechaelaboracion, string nombrerelator, string horasesion, string codasesorcoordinador, string aspectosdesarrollados, string conclusiones, string bibliografia, string estrategia, string momento, string sesion, string jornada, string desarrollo1, string desarrollo3, string actividadesytareas, string aspectos, string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra2instrumento_s004_sede SET codsede = @codsede, nombresesion = @nombresesion, temasesion = @temasesion, informacionadicional=@informacionadicional, fechaelaboracion = @fechaelaboracion, nombrerelator=@nombrerelator, codasesorcoordinador=@codasesorcoordinador, aspectosdesarrollados=@aspectosdesarrollados, conclusiones=@conclusiones, bibliografia=@bibliografia, estrategia=@estrategia, momento=@momento, sesion=@sesion, jornada=@jornada, desarrollo1=@desarrollo1, desarrollo3=@desarrollo3, actividadesytareas=@actividadesytareas, aspectos=@aspectos WHERE codigo = @codigoestrategia";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@nombresesion", nombresesion);
        conector.AsignarParametroCadena("@temasesion", temasesion);
        conector.AsignarParametroCadena("@informacionadicional", informacionadicional);
        conector.AsignarParametroCadena("@fechaelaboracion", fechaelaboracion + " " + horasesion + ":00");
        conector.AsignarParametroCadena("@nombrerelator", nombrerelator);
        conector.AsignarParametroCadena("@aspectosdesarrollados", aspectosdesarrollados);
        conector.AsignarParametroCadena("@conclusiones", conclusiones);
        conector.AsignarParametroCadena("@bibliografia", bibliografia);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@jornada", jornada);
        conector.AsignarParametroCadena("@desarrollo1", desarrollo1);
        conector.AsignarParametroCadena("@desarrollo3", desarrollo3);
        conector.AsignarParametroCadena("@actividadesytareas", actividadesytareas);
        conector.AsignarParametroCadena("@aspectos", aspectos);


        long resp = conector.guardadataid();
        return resp;
    }

    public DataTable cargarListadoMemoriasS004Sedes(string codAsesor, string estrategia, string momento, string sesion, string offset, string limit, string jornada)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004sede.codigo, s004sede.nombresesion, s004sede.fechaelaboracion, s004sede.momento, s004sede.sesion, s004sede.jornada, s004sede.codsede, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estra2instrumento_s004_sede s004sede inner join ins_sede s on s.codigo = s004sede.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento  where s004sede.codasesorcoordinador = @codAsesor and s004sede.estrategia = @estrategia and s004sede.momento = @momento and s004sede.sesion = @sesion and jornada=@jornada offset @offset limit @limit";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codAsesor", codAsesor);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        conectar.AsignarParametroCadena("@momento", momento);
        conectar.AsignarParametroCadena("@sesion", sesion);
        conectar.AsignarParametroCadena("@offset", offset);
        conectar.AsignarParametroCadena("@limit", limit);
        conectar.AsignarParametroCadena("@jornada", jornada);
        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return datos;
    }

    public DataTable cargarListadoMemoriasCountSedes(string codAsesor, string estrategia, string momento, string sesion, string jornada)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004sede.codigo, s004sede.nombresesion, s004sede.fechaelaboracion, s004sede.momento, s004sede.sesion, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estra2instrumento_s004_sede s004sede inner join ins_sede s on s.codigo = s004sede.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento  where s004sede.codasesorcoordinador = @codAsesor and s004sede.estrategia = @estrategia and s004sede.momento = @momento and s004sede.sesion = @sesion and jornada=@jornada";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codAsesor", codAsesor);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        conectar.AsignarParametroCadena("@momento", momento);
        conectar.AsignarParametroCadena("@sesion", sesion);
        conectar.AsignarParametroCadena("@jornada", jornada);
        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return datos;
    }
    public DataTable cargarListadoMemoriasS004SedesReporte(string codasesorcoordinador, string estrategia, string momento, string sesion, string offset, string limit, int jornada)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004sede.codigo, s004sede.codasesorcoordinador,s004sede.nombresesion, s004sede.fechaelaboracion, s004sede.momento, s004sede.sesion, s004sede.jornada, s004sede.codsede, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estra2instrumento_s004_sede s004sede inner join ins_sede s on s.codigo = s004sede.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004sede.codasesorcoordinador=@codasesorcoordinador and s004sede.estrategia = @estrategia and s004sede.momento = @momento and s004sede.sesion = @sesion and s004sede.jornada = " + jornada + " offset @offset limit @limit";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        conectar.AsignarParametroCadena("@momento", momento);
        conectar.AsignarParametroCadena("@sesion", sesion);
        conectar.AsignarParametroCadena("@offset", offset);
        conectar.AsignarParametroCadena("@limit", limit);
        //conectar.AsignarParametroEntero("@jornada", jornada);
        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return datos;
    }
    public DataTable cargarListadoMemoriasCountSedesReporte(string codasesorcoordinador, string estrategia, string momento, string sesion, string jornada)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004sede.codigo, s004sede.codasesorcoordinador,s004sede.nombresesion, s004sede.fechaelaboracion, s004sede.momento, s004sede.sesion, s004sede.jornada, s004sede.codsede, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estra2instrumento_s004_sede s004sede inner join ins_sede s on s.codigo = s004sede.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004Sede.codasesorcoordinador=@codasesorcoordinador and s004sede.estrategia = @estrategia and s004sede.momento = @momento and s004sede.sesion = @sesion and s004sede.jornada = @jornada";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        conectar.AsignarParametroCadena("@momento", momento);
        conectar.AsignarParametroCadena("@sesion", sesion);
        conectar.AsignarParametroCadena("@jornada", jornada);
        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return datos;
    }
    // funcion añadida 11/11/2016 G001 Reportes
    public DataTable listarcontrolasistencia(string codinstrumentos004, string codsede, string estrategia, string momento, string sesion, string jornada)
    {
        Conexion conectar = new Conexion();
        string sql = "select g001r.*, i.nombre as institucion, s.nombre as sede from est_inasistenciasinstrumento_g001_doc g001r inner join ins_sede s on s.codigo = g001r.codsede inner join ins_institucion i on i.codigo = s.codinstitucion where g001r.codinstrumento_s004_sede = @codinstrumentos004 and g001r.estrategia=@estrategia and g001r.momento=@momento and g001r.sesion=@sesion and g001r.jornada=@jornada and g001r.codsede=@codsede ";
        conectar.CrearComando(sql);
        conectar.AsignarParametroCadena("@codinstrumentos004", codinstrumentos004);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        conectar.AsignarParametroCadena("@momento", momento);
        conectar.AsignarParametroCadena("@sesion", sesion);
        conectar.AsignarParametroCadena("@jornada", jornada);
        conectar.AsignarParametroCadena("@codsede", codsede);
        DataTable listado = conectar.traerdata();
        if (listado != null)
            return listado;
        else
            return null;
    }

    public DataTable detalledocenteasistentes(string codigo)
    {
        Conexion conectar = new Conexion();
        string sql = "select (d.nombre || ' ' || d.apellido) as docente from est_inasistenciasinstrumento_g001detalle_doc g001docd inner join ins_gradodocente gd on gd.cod = g001docd.codgradodocente inner join ins_docente d on d.identificacion = gd.identificacion where g001docd.codinasistenciainstrumento_g001_doc = @codigo";
        conectar.CrearComando(sql);
        conectar.AsignarParametroCadena("@codigo", codigo);
        DataTable listado = conectar.traerdata();
        if (listado != null)
            return listado;
        else
            return null;
    }

    //Reporte general estrategia no. 4

    public DataRow numeroAsesoriasRealizadas()
    {
        Conexion conectar = new Conexion();
        string sql = "select count(nombresesion) as asesorias from est_estra2instrumento_s004_redt";
        conectar.CrearComando(sql);
        DataRow asesorias = conectar.traerfila();
        if (asesorias != null)
            return asesorias;
        else
            return null;
    }

    public DataRow numeroAsesoriasEvaluadas()
    {
        Conexion conectar = new Conexion();
        string sql = "select count(*) as evalasesoria from est_repositorioasesor_estra4 where actividad = 'Formatos de evaluación';";
        conectar.CrearComando(sql);
        DataRow evalasesoria = conectar.traerfila();
        if (evalasesoria != null)
            return evalasesoria;
        else
            return null;
    }

public Boolean agregarArchivoRespositorioEstrategia2AsesorS002(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string momento, string sesion, string actividad, string estrategia, string codestras002)
    {
        Conexion conector = new Conexion();
        string consulta = "";


        consulta = "INSERT INTO est_repositorioasesor_s002 (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,momento,sesion,actividad,estrategia,codestras002) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@momento,@sesion,@actividad,@estrategia,@codestras002)";
       

        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroDouble("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fechacreado);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);

            conector.AsignarParametroCadena("@actividad", actividad);

        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@codestras002", codestras002);
        bool resp = conector.guardadata();
        return resp;
    }

public Boolean agregarArchivoRespositorioEstrategia1AsesorS002(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string actividad, string codestras002)
{
    Conexion conector = new Conexion();
    string consulta = "";


    consulta = "INSERT INTO est_repositorioasesor_s002 (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,actividad,codestras002) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@actividad,@codestras002)";


    conector.CrearComando(consulta);
    conector.AsignarParametroCadena("@codusuario", codusuario);
    conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
    conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
    conector.AsignarParametroCadena("@ext", ext);
    conector.AsignarParametroCadena("@contentType", contentType);
    conector.AsignarParametroCadena("@path", path);
    conector.AsignarParametroDouble("@tamano", tamano);
    conector.AsignarParametroCadena("@fechacreado", fechacreado);
    conector.AsignarParametroCadena("@actividad", actividad);
    conector.AsignarParametroCadena("@codestras002", codestras002);
    bool resp = conector.guardadata();
    return resp;
}
public Boolean agregarArchivoRespositorioEstrategia1Asesorbitacora5(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string actividad, string codestrabitacora5)
{
    Conexion conector = new Conexion();
    string consulta = "";


    consulta = "INSERT INTO est_repositorioasesor_bitacora5 (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,actividad,codestrabitacora5) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@actividad,@codestrabitacora5)";


    conector.CrearComando(consulta);
    conector.AsignarParametroCadena("@codusuario", codusuario);
    conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
    conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
    conector.AsignarParametroCadena("@ext", ext);
    conector.AsignarParametroCadena("@contentType", contentType);
    conector.AsignarParametroCadena("@path", path);
    conector.AsignarParametroDouble("@tamano", tamano);
    conector.AsignarParametroCadena("@fechacreado", fechacreado);
    conector.AsignarParametroCadena("@actividad", actividad);
    conector.AsignarParametroCadena("@codestrabitacora5", codestrabitacora5);
    bool resp = conector.guardadata();
    return resp;
}


    public Boolean agregarArchivoRespositorioEstrategia1Asesorg007(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string actividad, string codestrag007)
{
    Conexion conector = new Conexion();
    string consulta = "";


    consulta = "INSERT INTO est_repositorioasesor_g007 (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,actividad,codestrag007) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@actividad,@codestrag007)";


    conector.CrearComando(consulta);
    conector.AsignarParametroCadena("@codusuario", codusuario);
    conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
    conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
    conector.AsignarParametroCadena("@ext", ext);
    conector.AsignarParametroCadena("@contentType", contentType);
    conector.AsignarParametroCadena("@path", path);
    conector.AsignarParametroDouble("@tamano", tamano);
    conector.AsignarParametroCadena("@fechacreado", fechacreado);
    conector.AsignarParametroCadena("@actividad", actividad);
    conector.AsignarParametroCadena("@codestrag007", codestrag007);
    bool resp = conector.guardadata();
    return resp;
}
	
	 public DataTable cargarEvidenciasEstrategia2AsesorS002(string momento, string sesion, string estrategia, string codestras002)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositorioasesor_s002 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE momento=@momento and sesion=@sesion and estrategia=@estrategia and codestras002=@codestras002  ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@codestras002", codestras002);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

     public DataTable cargarEvidenciasEstrategia1AsesorS002(string codestras002)
     {
         Conexion conector = new Conexion();
         string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositorioasesor_s002 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE codestras002=@codestras002  ORDER BY fechacreado ASC";
         conector.CrearComando(consulta);
        
         conector.AsignarParametroCadena("@codestras002", codestras002);
         DataTable resp = conector.traerdata();
         if (resp != null)
             return resp;
         else
             return null;

     }

     public DataTable cargarEvidenciasEstrategia1Asesorbitacora5(string codestrabitacora5)
     {
         Conexion conector = new Conexion();
         string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositorioasesor_bitacora5 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE codestrabitacora5=@codestrabitacora5  ORDER BY fechacreado ASC";
         conector.CrearComando(consulta);

         conector.AsignarParametroCadena("@codestrabitacora5", codestrabitacora5);
         DataTable resp = conector.traerdata();
         if (resp != null)
             return resp;
         else
             return null;

     }

     public DataTable cargarEvidenciasEstrategia1Asesorg007(string codestrag007)
     {
         Conexion conector = new Conexion();
         string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositorioasesor_g007 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE codestrag007=@codestrag007  ORDER BY fechacreado ASC";
         conector.CrearComando(consulta);

         conector.AsignarParametroCadena("@codestrag007", codestrag007);
         DataTable resp = conector.traerdata();
         if (resp != null)
             return resp;
         else
             return null;

     }
	
	 /*2016-10-25 09:09 pm*/
    public DataRow loadSelectInstrumentos002(string codproyecto)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s.codigo as codigosede, s.nombre as nombresede, i.codigo as codigoinstitucion, i.nombre as nombreinstitucion, m.cod as codigomunicipio, m.nombre as nombremunicipio, d.cod as codigodepartamento, d.nombre as nombredepartamento, ei2.codproyecto as codigogrupoinvestigacion, pps.nombregrupo as nombregrupoinvestigacion,ei2.codasesor, a.nombre,a.apellido from est_estra2instrumento_s002 ei2 inner join pro_proyectosede pps on pps.codigo=ei2.codproyecto inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento inner join est_asesorcoordinador eac on eac.codasesor=ei2.codasesor inner join est_asesorcoordinador ea on ea.codigo=eac.codasesor inner join est_asesor a on a.codigo=ea.codasesor where ei2.codproyecto = @codproyecto";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codproyecto", codproyecto);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return dato;
    }

    /*2016-10-26 06:56 pm*/
    public DataRow cargarInstrumentos002(string codigo)
    {
        Conexion conectar = new Conexion();
        string consulta = "SELECT noasesoria,noproyectadas,to_char(fechavisita,'yyyy-MM-dd') AS fechavisita,duracion_horas,tipoasesoria,motivoasesoria,objetivo, noasistentes FROM est_estra2instrumento_s002 WHERE codigo=@codigo";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codigo", codigo);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return dato;
    }
	
	 /*2016-10-26 08:58 pm*/
    public DataTable listaractividadess002(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT actividades FROM est_estra2instrumento_s002actividades WHERE codestra2instrumento_s002=@codigo order by noactividad ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
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

    /*2016-10-26 08:58 pm*/
    public DataTable listarcompromisoss002(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT compromiso,to_char(fechacumplimiento,'yyyy-MM-dd') AS fechacumplimiento,responsable FROM est_estra2instrumento_s002compromisos WHERE codestra2instrumento_s002=@codigo order by nocompromiso ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
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
	
	public long deleteactividadess002(string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2instrumento_s002actividades WHERE codestra2instrumento_s002 = @codinstrumento;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        long resp = conector.guardadataid();
        return resp;
    }

    public long deletecompromisoss002(string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2instrumento_s002compromisos WHERE codestra2instrumento_s002 = @codinstrumento;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        long resp = conector.guardadataid();
        return resp;
    }

    public long deleteencabezados002(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2instrumento_s002 WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        long resp = conector.guardadataid();
        return resp;
    }

    public Boolean actualizarEncabezadoS002(string codigo, string noAsesoria, string fechaVisita, string duracionHoras, string tipoAcompaniamiento, string motivoAsesoria, string objetivo, string noproyectadas, string noasistentes)
    {
        Conexion conector = new Conexion();
        string sql = "UPDATE est_estra2instrumento_s002 SET  noasesoria=@noAsesoria, fechavisita=@fechaVisita, duracion_horas=@duracionHoras, tipoasesoria=@tipoAcompaniamiento, motivoAsesoria=@motivoAsesoria,objetivo=@objetivo, noproyectadas=@noproyectadas, noasistentes=@noasistentes WHERE codigo=@codigo";

        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@noAsesoria", noAsesoria);
        conector.AsignarParametroCadena("@fechaVisita", fechaVisita);
        conector.AsignarParametroCadena("@duracionHoras", duracionHoras);
        conector.AsignarParametroCadena("@tipoAcompaniamiento", tipoAcompaniamiento);
        conector.AsignarParametroCadena("@motivoAsesoria", motivoAsesoria);
        conector.AsignarParametroCadena("@objetivo", objetivo);
        conector.AsignarParametroCadena("@noproyectadas", noproyectadas);
        conector.AsignarParametroCadena("@codigo", codigo);
        conector.AsignarParametroCadena("@noasistentes", noasistentes);
        bool resp = conector.guardadata();

        return resp;
    }

    public bool guardarActividades(string codEstraS002, string actividad, string noactividad)
    {
        Conexion conector = new Conexion();
        string sql = "INSERT INTO est_estra2instrumento_s002actividades (codestra2instrumento_s002, actividades, noactividad) VALUES (@codEstraS002, @actividad, @noactividad)";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codEstraS002", codEstraS002);
        conector.AsignarParametroCadena("@actividad", actividad);
        conector.AsignarParametroCadena("@noactividad", noactividad);
        return conector.guardadata();
    }
    public bool guardarCompromisos(string codEstraS002, string compromiso, string fechaCumplimiento, string responsable, string nocompromiso)
    {
        Conexion conector = new Conexion();
        string sql = "INSERT INTO est_estra2instrumento_s002compromisos (codestra2instrumento_s002, compromiso, fechacumplimiento, responsable, nocompromiso) VALUES (@codEstraS002, @compromiso, @fechaCumplimiento, @responsable, @nocompromiso)";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codEstraS002", codEstraS002);
        conector.AsignarParametroCadena("@compromiso", compromiso);
        conector.AsignarParametroCadena("@fechaCumplimiento", fechaCumplimiento);
        conector.AsignarParametroCadena("@responsable", responsable);
        conector.AsignarParametroCadena("@nocompromiso", nocompromiso);
        return conector.guardadata();
    }

   public Boolean agregarArchivoRespositorioEstrategiaUnoS007(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string momento, string sesion, string actividad, string estrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "";
        consulta = "INSERT INTO est_repositorioasesor_s007 (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,momento,sesion,actividad,estrategia) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@momento,@sesion,@actividad,@estrategia)";
       

        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroDouble("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fechacreado);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@actividad", actividad);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        bool resp = conector.guardadata();
        return resp;
    }

    public DataTable cargarEvidenciasEstrategiaUnoS007(string momento, string sesion, string estrategia, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositorioasesor_s007 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE rc.momento=@momento and rc.sesion=@sesion and rc.estrategia=@estrategia and rc.codusuario=@codusuario ORDER BY rc.fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataRow buscarEvidenciaEstrategiaUnoS007(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_repositorioasesor_s007 WHERE codigo=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public Boolean borrarEvidenciaEstrategiaUnoS007(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositorioasesor_s007 WHERE codigo=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public DataTable cargarbitacoraunoSupervisor()
    {
        Conexion conector = new Conexion();
        string consulta = "select b.codigo as codbitacora, ps.codigo as codproyectosede, ps.nombregrupo, ps.codlineainvestigacion, m.cod as codmunicipio, m.nombre as municipio, d.cod as coddepartamento, d.nombre as departamento, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, i.nombre as nominstitucion, s.nombre as nomsede, b.fechacreacion from est_estra1bitacora1 b inner join pro_proyectosede ps on b.codproyectosede=ps.codigo inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento inner join est_asesorcoordinador ac on ac.codigo=ps.codasesorcoordinador inner join est_asesor a on a.codigo=ac.codasesor;";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarbitacoraunoSupervisorxAsesor(string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "select b.codigo as codbitacora, ps.codigo as codproyectosede, ps.nombregrupo, ps.codlineainvestigacion, m.cod as codmunicipio, m.nombre as municipio, d.cod as coddepartamento, d.nombre as departamento, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, i.nombre as nominstitucion, s.nombre as nomsede, b.fechacreacion from est_estra1bitacora1 b inner join pro_proyectosede ps on b.codproyectosede=ps.codigo inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento inner join est_asesorcoordinador ac on ac.codigo=ps.codasesorcoordinador inner join est_asesor a on a.codigo=ac.codasesor where ps.codasesorcoordinador=@codasesorcoordinador;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    

    public DataRow loadSelectInstrumentos004Sedes(string codigo)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s.codigo as codigosede, s.nombre as nombresede, i.codigo as codigoinstitucion, i.nombre as nombreinstitucion, m.cod as codigomunicipio, m.nombre as nombremunicipio, d.cod as codigodepartamento, d.nombre as nombredepartamento from est_estra2instrumento_s004_sede s004 inner join ins_sede s on s.codigo = s004.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004.codigo = @codigo";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codigo", codigo);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return dato;
    }

    public Boolean agregarArchivoRespositorioEstrategiaS004Sedes(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string codinstrumento, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO est_repositorioasesor_s004Sedes (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,codinstrumento,actividad) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@codinstrumento,@actividad)";


        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroDouble("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fechacreado);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);

        conector.AsignarParametroCadena("@actividad", actividad);

        bool resp = conector.guardadata();
        return resp;
    }

    public DataTable cargarEvidenciasEstrategiaS004Sedes(string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositorioasesor_s004Sedes rc inner join usu_usuario u on u.cod=rc.codusuario WHERE codinstrumento=@codinstrumento ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataRow buscarEvidenciaEstrategiaS004Sedes(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_repositorioasesor_s004sedes WHERE codigo=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public Boolean borrarEvidenciaEstrategiaS004Sedes(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositorioasesor_s004sedes WHERE codigo=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public DataRow agregarGrupoInvestigacionxSedeDocente(string codsede, string fechacreacion, string codasesorcoordinador, string codlineainvestigacion, string codarea, string nombregrupo)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO pro_grupoinvestigaciondocentes (codsede,fechacreacion,codasesorcoordinador,codlineainvestigacion,codarea,nombregrupo) VALUES (@codsede,@fechacreacion,@codasesorcoordinador,@codlineainvestigacion,@codarea,@nombregrupo) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@fechacreacion", fechacreacion);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@codlineainvestigacion", codlineainvestigacion);
        conector.AsignarParametroCadena("@codarea", codarea);
        conector.AsignarParametroCadena("@nombregrupo", nombregrupo);
        DataRow dato = conector.guardadataidPG();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public bool agregarDocentexSedexGrupoInvestigacion(string codgradodocente, string codgrupoinvestigaciondocentes)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO pro_grupoinvestigacionmatriculadocentes (codgradodocente,codgrupoinvestigaciondocentes) VALUES (@codgradodocente,@codgrupoinvestigaciondocentes)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        conector.AsignarParametroCadena("@codgrupoinvestigaciondocentes", codgrupoinvestigaciondocentes);
        return conector.guardadata();
    }
    public DataTable cargarGruposInvestigacionDocentexAsesor(string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "select ps.codigo as codgrupo, i.nombre as nominstitucion, s.nombre as nomsede, ps.nombregrupo, ac.codigo as codasesorcoordinador, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, m.nombre as nommunicipio, d.nombre as nomdepartamento from pro_grupoinvestigaciondocentes ps left join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where ps.codasesorcoordinador=@codasesorcoordinador order by a.apellido asc;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarDocentesxSedexGrupoInvestigacion(string codgrupoinvestigaciondocentes)
    {
        Conexion conector = new Conexion();
        string consulta = "select pd.codigo as codgrupoinvestigaciondocentes, concat_ws(' ',d.nombre,d.apellido) as nombre, gd.identificacion, pd.codgradodocente, gd.codanio  from pro_grupoinvestigacionmatriculadocentes pd inner join ins_gradodocente gd on gd.cod=pd.codgradodocente inner join ins_docente d on d.identificacion=gd.identificacion where pd.codgrupoinvestigaciondocentes=@codgrupoinvestigaciondocentes";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgrupoinvestigaciondocentes", codgrupoinvestigaciondocentes);
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

    public DataTable cargarDocentesxSedexGrupoInvestigacionUnimag(string codproyectosede)
    {
        Conexion conector = new Conexion();
        string consulta = "select pd.codigo as codproyectodocente, concat_ws(' ',d.nombre,d.apellido) as nombre, gd.identificacion, pd.codgradodocente, gd.codanio  from pro_proyectodocente pd inner join ins_gradodocente gd on gd.cod=pd.codgradodocente inner join ins_docente d on d.identificacion=gd.identificacion where pd.codproyectosede=@codproyectosede";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
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

    public Boolean eliminarDocentesxSedexGrupoInvestigacionTodo(String codgrupoinvestigaciondocentes)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM pro_grupoinvestigacionmatriculadocentes WHERE codgrupoinvestigaciondocentes=@codgrupoinvestigaciondocentes  ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgrupoinvestigaciondocentes", codgrupoinvestigaciondocentes);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarGrupoInvestigacionxsSede(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM pro_grupoinvestigaciondocentes WHERE codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public DataRow buscarGrupoInvestigacionSedexCod(string grupoinvestigaciondocentes)
    {
        Conexion conector = new Conexion();
        string consulta = "select d.cod as coddepartamento, m.cod as codmunicipio, i.codigo as codinstitucion, s.codigo as codsede, ps.codigo as codgrupoinvestigaciondocentes, ps.codlineainvestigacion from pro_grupoinvestigaciondocentes ps inner join ins_sede s on ps.codsede=s.codigo inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where ps.codigo=@grupoinvestigaciondocentes";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@grupoinvestigaciondocentes", grupoinvestigaciondocentes);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarAsesorxGrupoInvestigacionxSede(string codgrupoinvestigaciondocentes)
    {
        Conexion conector = new Conexion();
        string consulta = "select ps.codigo as codgrupoinvestigaciondocentes, ps.codasesorcoordinador, concat_ws(' ',a.nombre,a.apellido) as nombre, a.identificacion from pro_grupoinvestigaciondocentes ps inner join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor where ps.codigo=@codgrupoinvestigaciondocentes";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgrupoinvestigaciondocentes", codgrupoinvestigaciondocentes);
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
    public DataTable cargarTodoGrupoInvestigacionSedes()
    {
        Conexion conector = new Conexion();
        string consulta = "select * from pro_grupoinvestigaciondocentes ";
        conector.CrearComando(consulta);
        //conector.AsignarParametroCadena("@codgrupoInvestigacion", codgrupoInvestigacion);
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

    public DataTable cargarInstrmentoS003(string codgrupoinvestigaciondocentes, string offset, string limit)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from est_estra2instrumento_s003 where  codgrupoinvestigaciondocentes=@codgrupoinvestigaciondocentes  order by codigo desc offset @offset limit @limit";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgrupoinvestigaciondocentes", codgrupoinvestigaciondocentes);
        conector.AsignarParametroCadena("@offset", offset);
        conector.AsignarParametroCadena("@limit", limit);
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

    public DataTable cargarInstrmentoS003Count(string codgrupoinvestigaciondocentes)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from est_estra2instrumento_s003 where  codgrupoinvestigaciondocentes=@codgrupoinvestigaciondocentes ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgrupoinvestigaciondocentes", codgrupoinvestigaciondocentes);
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

    public bool eliminarS003(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2instrumento_s003 WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();

    }

    public DataRow proloadestras003(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from est_estra2instrumento_s003 where  codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public Boolean eliminarDocentesS003GrupoInvestigacionTodo(String codgrupoinvestigaciondocentes)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM pro_grupoinvestigacionmatriculadocentes WHERE codgrupoinvestigaciondocentes=@codgrupoinvestigaciondocentes ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgrupoinvestigaciondocentes", codgrupoinvestigaciondocentes);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminaS003rGrupoInvestigacionSede(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM pro_grupoinvestigaciondocentes WHERE codigo=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }
    public bool eliminarS003xGrupo(string codgrupoinvestigaciondocentes)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2instrumento_s003 WHERE codgrupoinvestigaciondocentes = @codgrupoinvestigaciondocentes;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgrupoinvestigaciondocentes", codgrupoinvestigaciondocentes);
        return conector.guardadata();

    }

    //Mesa de trabajo
    public DataRow agregarMesadeTrabajoxSedeDocente(string codsede, string fechacreacion, string codasesorcoordinador,  string nombregrupo)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO pro_mesadetrabajo (codsede,fechacreacion,codasesorcoordinador,nombregrupo) VALUES (@codsede,@fechacreacion,@codasesorcoordinador,@nombregrupo) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@fechacreacion", fechacreacion);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        
        conector.AsignarParametroCadena("@nombregrupo", nombregrupo);
        DataRow dato = conector.guardadataidPG();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public bool agregarDocentexSedexMesdeTrabajo(string codgradodocente, string codmesadetrabajo)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO pro_mesadetrabajodocente (codgradodocente,codmesadetrabajo) VALUES (@codgradodocente,@codmesadetrabajo)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        conector.AsignarParametroCadena("@codmesadetrabajo", codmesadetrabajo);
        return conector.guardadata();
    }
    public DataTable cargarMesadeTrabajoxAsesor(string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "select ps.codigo as codgrupo, i.nombre as nominstitucion, s.nombre as nomsede, ps.nombregrupo, ac.codigo as codasesorcoordinador, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, m.nombre as nommunicipio, d.nombre as nomdepartamento from pro_mesadetrabajo ps left join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where ps.codasesorcoordinador=@codasesorcoordinador order by a.apellido asc;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarDocentesxSedexMesadeTrabajo(string codmesadetrabajo)
    {
        Conexion conector = new Conexion();
        string consulta = "select pd.codigo as codmesadetrabajo, concat_ws(' ',d.nombre,d.apellido) as nombre, gd.identificacion, pd.codgradodocente, gd.codanio  from pro_mesadetrabajodocente pd inner join ins_gradodocente gd on gd.cod=pd.codgradodocente inner join ins_docente d on d.identificacion=gd.identificacion where pd.codmesadetrabajo=@codmesadetrabajo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codmesadetrabajo", codmesadetrabajo);
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
    public Boolean eliminaMesadeTrabajoDocente(String codmesadetrabajo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM pro_mesadetrabajodocente WHERE codmesadetrabajo=@codmesadetrabajo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codmesadetrabajo", codmesadetrabajo);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminaMesadeTrabajo(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM pro_mesadetrabajo WHERE codigo=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminaMesadeTrabajoEvidencias(String codmesadetrabajo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_respositorio_mesatrabajo WHERE codmesatrabajo=@codmesadetrabajo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codmesadetrabajo", codmesadetrabajo);
        bool resp = conector.guardadata();
        return resp;
    }
    public DataRow buscarMesadeTrabajoSedexCod(string codmesadetrabajo)
    {
        Conexion conector = new Conexion();
        string consulta = "select d.cod as coddepartamento, m.cod as codmunicipio, i.codigo as codinstitucion, s.codigo as codsede, ps.codigo as codmesadetrabajo from pro_mesadetrabajo ps inner join ins_sede s on ps.codsede=s.codigo inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where ps.codigo=@codmesadetrabajo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codmesadetrabajo", codmesadetrabajo);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarTodoMesadeTrabajo()
    {
        Conexion conector = new Conexion();
        string consulta = "select * from pro_mesadetrabajo ";
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
    public DataTable cargarAsesorxMesadeTrabajoxSede(string codmesadetrabajo)
    {
        Conexion conector = new Conexion();
        string consulta = "select ps.codigo as codmesadetrabajo, ps.codasesorcoordinador, concat_ws(' ',a.nombre,a.apellido) as nombre, a.identificacion from pro_mesadetrabajo ps inner join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor where ps.codigo=@codmesadetrabajo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codmesadetrabajo", codmesadetrabajo);
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

    public Boolean agregarArchivoRespositorioMesaTrabajo(String codgradodocente, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string codmesatrabajo)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO est_respositorio_mesatrabajo (codgradodocente,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,codmesatrabajo) VALUES (@codgradodocente,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@codmesatrabajo)";


        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroDouble("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fechacreado);
        conector.AsignarParametroCadena("@codmesatrabajo", codmesatrabajo);

        

        bool resp = conector.guardadata();
        return resp;
    }
    public DataTable cargarEvidenciasMesaTrabajo(string codmesatrabajo, string codgradodocente)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT rc.*, concat_ws(' ', d.nombre,d.apellido) as nombre FROM est_respositorio_mesatrabajo rc inner join ins_gradodocente u on u.cod=rc.codgradodocente inner join ins_docente d on d.identificacion=u.identificacion WHERE codmesatrabajo=@codmesatrabajo and codgradodocente=@codgradodocente ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codmesatrabajo", codmesatrabajo);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataRow buscarEvidenciaMesaTrabajo(string cod)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_respositorio_mesatrabajo WHERE cod=@cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public Boolean borrarEvidenciaMesaTrabajo(String cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_respositorio_mesatrabajo WHERE cod=@cod ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        bool resp = conector.guardadata();
        return resp;
    }

    //Entrega de materiales, evidencia
    public Boolean agregarArchivoRespositorioEntregaMaterial(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO est_repositorioasesor_g006 (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,codinstrumento) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@codinstrumento)";


        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroDouble("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fechacreado);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);



        bool resp = conector.guardadata();
        return resp;
    }
    public DataTable cargarEvidenciasEntregaMaterial(string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositorioasesor_g006 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE rc.codinstrumento=@codinstrumento ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataRow buscarEvidenciaEntregaMaterial(string cod)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_repositorioasesor_g006 WHERE cod=@cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public Boolean borrarEvidenciaEntregaMaterial(String cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositorioasesor_g006 WHERE cod=@cod ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        bool resp = conector.guardadata();
        return resp;
    }
    public DataRow loadSelectInstrumentog006(string codigo)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s.codigo as codigosede, s.nombre as nombresede, i.codigo as codigoinstitucion, i.nombre as nombreinstitucion, m.cod as codigomunicipio, m.nombre as nombremunicipio, d.cod as codigodepartamento, d.nombre as nombredepartamento from est_estra2instrumento_g006 g006 inner join ins_sede s on s.codigo = g006.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where g006.codigo = @codigo";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codigo", codigo);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return dato;
    }
	
	public DataRow buscarEvidenciaEstrategiacinco(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_repositoriocoordinador_estra5 WHERE cod=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
	
	public Boolean borrarEvidenciaEstrategiacinco(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositoriocoordinador_estra5 WHERE cod=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public DataTable cargarTotalEvidenciasEstrategiaConActividad(string momento, string sesion, string estrategia, string actividad, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT rp.*, us.pnombre , us.papellido FROM est_repositoriocoordinador rp INNER JOIN usu_usuario us ON us.cod = rp.codusuario WHERE momento=@momento and sesion=@sesion and estrategia=@estrategia and actividad=@actividad and codusuario=@codusuario";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@actividad", actividad);
        conector.AsignarParametroCadena("@codusuario", codusuario);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarCoordinadoresxEstrategia(string estrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "select u.cod, concat_ws(' ',c.nombre,c.apellido) as nombre from est_coordinador c inner join usu_usuario u on CAST(u.identificacion as bigint) =c.identificacion inner join est_estracoordinador ec on ec.codcoordinador=c.codigo where ec.codestrategia = @estrategia";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@estrategia", estrategia);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    ////////////

    public DataTable cargarEvidenciasEstrategia4AsesorRedTematica_2016(string momento, string sesion, string estrategia, string codredtematicasede, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositorioasesor_estra4 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE momento=@momento and sesion=@sesion and estrategia=@estrategia and codredtematicasede=@codredtematicasede and codusuario=@codusuario ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataRow loadSelectInstrumentos004_2016(string codRedtematica)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s.codigo as codigosede, s.nombre as nombresede, i.codigo as codigoinstitucion, i.nombre as nombreinstitucion, m.cod as codigomunicipio, m.nombre as nombremunicipio, d.cod as codigodepartamento, d.nombre as nombredepartamento,rts.codigo as codigoredtematica,concat_ws(' ', rt.nombre,rts.consecutivogrupo) as redtematica from est_estra2instrumento_s004_redt_2016 s004 inner join rt_redtematicasede rts on rts.codigo = s004.codredtematicasede inner join rt_redtematica rt on rts.codredtematica=rt.codigo inner join ins_sede s on s.codigo = rts.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004.codigo = @codRedtematica";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codRedtematica", codRedtematica);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return dato;
    }


    public DataTable cargarListadoMemoriasS004_2016(string codAsesor, string estrategia, string momento, string sesion, string offset, string limit)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004redt.codigo, s004redt.codredtematicasede, s004redt.nombresesion, rt.nombre, s004redt.fechaelaboracion, rts.consecutivogrupo, s004redt.momento, s004redt.sesion, rts.codsede, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estra2instrumento_s004_redt_2016 s004redt inner join rt_redtematicasede rts on rts.codigo = s004redt.codredtematicasede inner join rt_redtematica rt on rt.codigo = rts.codredtematica inner join ins_sede s on s.codigo = rts.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004redt.codasesorcoordinador = @codAsesor and s004redt.estrategia = @estrategia and s004redt.momento = @momento and s004redt.sesion = @sesion offset @offset limit @limit";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codAsesor", codAsesor);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        conectar.AsignarParametroCadena("@momento", momento);
        conectar.AsignarParametroCadena("@sesion", sesion);
        conectar.AsignarParametroCadena("@offset", offset);
        conectar.AsignarParametroCadena("@limit", limit);
        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return datos;
    }

    public DataRow buscarRegistroMemoriaS004_2016(string codredtematicasede)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004redt.codigo, s004redt.codredtematicasede, s004redt.nombresesion, rt.nombre, s004redt.fechaelaboracion, rts.consecutivogrupo, s004redt.momento, s004redt.sesion, rts.codsede, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estra2instrumento_s004_redt_2016 s004redt inner join rt_redtematicasede rts on rts.codigo = s004redt.codredtematicasede inner join rt_redtematica rt on rt.codigo = rts.codredtematica inner join ins_sede s on s.codigo = rts.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004redt.codredtematicasede = @codredtematicasede limit 1";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        DataRow asesorias = conectar.traerfila();
        if (asesorias != null)
            return asesorias;
        else
            return null;
    }

    //////////////////PLAN DE TRABAJO////////////////////////
    public Boolean agregarArchivoRespositorioplan(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string actividad, string estrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        if (actividad != "")
            consulta = "INSERT INTO est_repositoriocoordinador (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,actividad,estrategia) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@actividad,@estrategia)";
        else
            consulta = "INSERT INTO est_repositoriocoordinador (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,estrategia) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@estrategia)";

        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroDouble("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fechacreado);

        if (actividad != "")
            conector.AsignarParametroCadena("@actividad", actividad);

        conector.AsignarParametroCadena("@estrategia", estrategia);
        bool resp = conector.guardadata();
        return resp;
    }

    public DataTable cargarEvidenciasEstrategiaConActividadplan(string estrategia, string actividad, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoordinador rc inner join usu_usuario u on u.cod=rc.codusuario WHERE estrategia=@estrategia and actividad=@actividad and codusuario=@codusuario ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@actividad", actividad);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarEvidenciasEstrategiaplan(string estrategia, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoordinador rc inner join usu_usuario u on u.cod=rc.codusuario WHERE estrategia=@estrategia and codusuario=@codusuario ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarNombresRedesTematicas(string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "select rts.codigo as codredtematicasede, rts.fechacreacion, rts.codasesorcoordinador, concat_ws(' ',a.nombre,a.apellido) as asesor, d.nombre as departamento, m.nombre as municipio, concat_ws(' ',rt.nombre,rts.consecutivogrupo) as redtematica, i.nombre as institucion, s.nombre as sede  from rt_redtematica rt inner join rt_redtematicasede rts on rt.codigo=rts.codredtematica inner join ins_sede s on s.codigo=rts.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento inner join est_asesorcoordinador ac on ac.codigo=rts.codasesorcoordinador inner join est_asesor a on a.codigo=ac.codasesor where rts.codasesorcoordinador=@codasesorcoordinador order by rts.codigo desc";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarTablaRedTematica()
    {
        Conexion conector = new Conexion();
        string consulta = "select * from rt_redtematica";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable listarBitacoraCincoSupervision(string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT b5.*, d.nombre as departamento,m.nombre as municipio, i.nombre as institucion, s.nombre as sede, ps.nombregrupo FROM est_estra1bitacora5 b5 inner join pro_proyectosede ps on ps.codigo=b5.codproyecto inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento WHERE ps.codasesorcoordinador=@codasesorcoordinador ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataRow loadBitacoraCinco(string codigo)
    {
        Conexion conector = new Conexion();
        string sql = "SELECT * FROM est_estra1bitacora5 WHERE codigo = @codigo ";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codigo", codigo);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return resp;

    }

    public DataTable cargarPrimerTrayectobitacora5(string codestraunobitacoracinco)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from est_estra1bitacora5_detalle where codestraunobitacoracinco=@codestraunobitacoracinco order by codigo ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestraunobitacoracinco", codestraunobitacoracinco);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarSegundoTrayectobitacora5(string codestraunobitacoracinco)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from est_estra1bitacora5_detalle_2 where codestraunobitacoracinco=@codestraunobitacoracinco order by codigo DESC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestraunobitacoracinco", codestraunobitacoracinco);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarTercerTrayectobitacora5(string codestraunobitacoracinco)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from est_estra1bitacora5_detalle_3 where codestraunobitacoracinco=@codestraunobitacoracinco order by codigo ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestraunobitacoracinco", codestraunobitacoracinco);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public bool deleteDetalleBitacora5(string codestraunobitacoracinco)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora5_detalle WHERE codestraunobitacoracinco = @codestraunobitacoracinco;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestraunobitacoracinco", codestraunobitacoracinco);
        bool resp = conector.guardadata();
        return resp;
    }

    public long deleteDetalleBitacora5_2(string codestraunobitacoracinco)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora5_detalle_2 WHERE codestraunobitacoracinco = @codestraunobitacoracinco;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestraunobitacoracinco", codestraunobitacoracinco);
        long resp = conector.guardadataid();
        return resp;
    }
    

    public long deleteDetalleBitacora5_3(string codestraunobitacoracinco)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora5_detalle_3 WHERE codestraunobitacoracinco = @codestraunobitacoracinco;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestraunobitacoracinco", codestraunobitacoracinco);
        long resp = conector.guardadataid();
        return resp;
    }

    public long deleteBitacora5(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora5 WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        long resp = conector.guardadataid();
        return resp;
    }

    public long deleteEvidenciaBitacora5(string codestrabitacora5)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositorioasesor_bitacora5 WHERE codestrabitacora5 = @codestrabitacora5;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestrabitacora5", codestrabitacora5);
        long resp = conector.guardadataid();
        return resp;
    }

    public Boolean updateencabezadobitacora5(String codigo, string objetivoFinal, string nomTrayectoIndagacion, string dificultadesFortalezas, string principalesCaracteristicas, string importanciaInvestigacion, string importanciaIEP, string general, string especifico, string nomTrayectoIndagacion2, string nomTrayectoIndagacion3)
    {
        Conexion conectar = new Conexion();
        string consulta = "UPDATE est_estra1bitacora5 SET objetivofinal=@objetivofinal, nomtrayectoindagacion=@nomtrayectoindagacion, dificultadesfortalezas=@dificultadesfortalezas, principalescaracteristicas=@principalescaracteristicas, importanciasinvestigacion=@importanciasinvestigacion, importanciaiep=@importanciaiep,general=@general,especifico=@especifico, nomtrayectoindagacion2=@nomtrayectoindagacion2, nomtrayectoindagacion3=@nomtrayectoindagacion3 WHERE codigo=@codigo ";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codigo", codigo);
        conectar.AsignarParametroCadena("@objetivofinal", objetivoFinal);
        conectar.AsignarParametroCadena("@nomtrayectoindagacion", nomTrayectoIndagacion);
        conectar.AsignarParametroCadena("@nomtrayectoindagacion2", nomTrayectoIndagacion2);
        conectar.AsignarParametroCadena("@nomtrayectoindagacion3", nomTrayectoIndagacion3);
        conectar.AsignarParametroCadena("@dificultadesfortalezas", dificultadesFortalezas);
        conectar.AsignarParametroCadena("@principalescaracteristicas", principalesCaracteristicas);
        conectar.AsignarParametroCadena("@importanciasinvestigacion", importanciaInvestigacion);
        conectar.AsignarParametroCadena("@importanciaiep", importanciaIEP);
        conectar.AsignarParametroCadena("@general", general);
        conectar.AsignarParametroCadena("@especifico", especifico);
        bool resp = conectar.guardadata();
        return resp;
    }
    //Proceso de sistematización
    public Boolean agregarArchivoRespositorioProcesoSistematizacion(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string estrategia, string momento, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO est_repositoriocoord_sistematizacion (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,estrategia,momento,actividad) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@estrategia,@momento,@actividad)";


        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroDouble("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fechacreado);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@actividad", actividad);


        bool resp = conector.guardadata();
        return resp;
    }
    public DataTable cargarEvidenciasProcesoSistematizacion(string codusuario, string estrategia, string momento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoord_sistematizacion rc inner join usu_usuario u on u.cod=rc.codusuario WHERE rc.codusuario=@codusuario and estrategia=@estrategia and momento=@momento ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataRow buscarEvidenciaProcesoSistematizacion(string cod)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_repositoriocoord_sistematizacion WHERE cod=@cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public Boolean borrarEvidenciaProcesoSistematizacion(String cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositoriocoord_sistematizacion WHERE cod=@cod ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        bool resp = conector.guardadata();
        return resp;
    }

    public DataTable cargarProyectoSedexSedes(string codsede)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT ps.*, concat_ws(' ', a.identificacion,'-',a.nombre,a.apellido)as asesor FROM pro_proyectosede ps inner join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor WHERE ps.codsede=@codsede ORDER BY fechacreacion DESC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public bool editarAsesorEnGrupoInvestigacion(string codasesorcoordinador, string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE pro_proyectosede SET codasesorcoordinador=@codasesorcoordinador WHERE codigo=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public DataTable cargarRedesSedexSedes(string codsede)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT ps.codigo, concat_ws(' ', r.nombre,ps.consecutivogrupo) as redtematica, ps.codasesorcoordinador, concat_ws(' ', a.identificacion,'-',a.nombre,a.apellido) as asesor FROM rt_redtematicasede ps inner join rt_redtematica r on r.codigo=ps.codredtematica inner join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor WHERE ps.codsede=@codsede ORDER BY fechacreacion DESC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public bool editarAsesorEnRedesTematicas(string codasesorcoordinador, string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE rt_redtematicasede SET codasesorcoordinador=@codasesorcoordinador WHERE codigo=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public DataTable cargarFeriasMunicipalesMaferpi()
    {
        Conexion conector = new Conexion();
        string consulta = "select fm.codigo as codferiamunicipal, fm.nombreferiamunicipal as nomferiamunicipal, fm.numeroasistentes as asistentes, fm.fechaelaboracion as fecha, fm.horaferia as hora, df.nombre as nomdepartamento, fm.coddepartamento FROM ep_feriasmunicipales fm inner join geo_departamentos df on df.cod=fm.coddepartamento";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public bool agregarGradoRedTematica(string codredtematicasede, string codgrado)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO rt_redtematicagrados (codredtematicasede,codgrado) VALUES (@codredtematicasede,@codgrado);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgrado", codgrado);
        conector.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        bool resp = conector.guardadata();
        return resp;
    }

    public DataTable cargarGradosxRedTematica(string codredtematicasede)
    {
        Conexion conector = new Conexion();
        string consulta = "select g.nombre from rt_redtematicagrados rt left join ins_grado g on g.codigo=rt.codgrado where rt.codredtematicasede=@codredtematicasede";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public Boolean agregarArchivoRespositorioEspacioxMunicipio(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string codespacio, string codmunicipio, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO est_respositorio_espacioapro (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,codespacio,codmunicipio,actividad) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@codespacio,@codmunicipio,@actividad)";

        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroDouble("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fechacreado);
        conector.AsignarParametroCadena("@codespacio", codespacio);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        conector.AsignarParametroCadena("@actividad", actividad);

        bool resp = conector.guardadata();
        return resp;
    }

    public DataTable cargarEvidenciasEspacioxMunicipio(string codespacio, string codmunicipio, string actividad, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_respositorio_espacioapro rc inner join usu_usuario u on u.cod=rc.codusuario WHERE codespacio=@codespacio and codmunicipio=@codmunicipio and actividad=@actividad and codusuario=@codusuario  ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codespacio", codespacio);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        conector.AsignarParametroCadena("@actividad", actividad);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataRow buscarEvidenciaEspacioxMunicipio(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_respositorio_espacioapro WHERE cod=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public Boolean borrarEvidenciaEspacioxMunicipio(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_respositorio_espacioapro WHERE cod=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public DataRow actualizarMunicipiosxFeriaMunicipal(string codferiamunicipal, string codmunicipiomatricula)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO ep_municipiomatricula (codferiamunicipal, codmunicipiomatricula) VALUES (@codferiamunicipal, @codmunicipiomatricula) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codferiamunicipal", codferiamunicipal);
        conector.AsignarParametroCadena("@codmunicipiomatricula", codmunicipiomatricula);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow buscarFeriaMunicipalxcodigo(string codferiamunicipal)
    {
        Conexion conector = new Conexion();
        string consulta = "select d.cod as coddepartamento, fm.codigo as codigo, fm.nombreferiamunicipal as nombreferiamunicipal, fm.numeroasistentes as numeroasistentes, fm.numerogrupos as numerogrupos, fm.fechaelaboracion as fechaelaboracion, fm.horaferia as horaferia, fm.horaferiafinal as horaferiafinal from ep_feriasmunicipales fm inner join ep_municipiomatricula fmm on fmm.codferiamunicipal=fm.codigo inner join geo_departamentos d on d.cod=fm.coddepartamento where fm.codigo=@codferiamunicipal";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codferiamunicipal", codferiamunicipal);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public bool actualizarFeriaMunicipal(string coddepartamento, string nombreferiamunicipal, string numeroasistentes, string numerogrupos, string fechaelaboracion, string horaferia, string horaferiafinal)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE ep_feriasmunicipales SET coddepartamento = @coddepartamento, nombreferiamunicipal = @nombreferiamunicipal, numeroasistentes=@numeroasistentes, numerogrupos = @numerogrupos, fechaelaboracion=@fechaelaboracion, horaferia=@horaferia, horaferiafinal=@horaferiafinal WHERE codigo = @codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddepartamento", coddepartamento);
        conector.AsignarParametroCadena("@nombreferiamunicipal", nombreferiamunicipal);
        conector.AsignarParametroCadena("@numeroasistentes", numeroasistentes);
        conector.AsignarParametroCadena("@numerogrupos", numerogrupos);
        conector.AsignarParametroCadena("@fechaelaboracion", fechaelaboracion);
        conector.AsignarParametroCadena("@horaferia", horaferia);
        conector.AsignarParametroCadena("@horaferiafinal", horaferiafinal);

        return conector.guardadata();

    }
    public Boolean eliminarMunicipioFeriaMunicipal(string codmunicipiomatricula)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM ep_municipiomatricula WHERE codmunicipiomatricula=@codmunicipiomatricula ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codmunicipiomatricula", codmunicipiomatricula);
        bool resp = conector.guardadata();
        return resp;
    }
}
