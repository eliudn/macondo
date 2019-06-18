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

    public bool editargrupoinvestigaciondocente(string nombregrupo, string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE pro_grupoinvestigaciondocentes SET nombregrupo=@nombregrupo WHERE codigo=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        conector.AsignarParametroCadena("@nombregrupo", nombregrupo);
        return conector.guardadata();

    }

    public bool editarmesadetrabajodocente(string nombregrupo, string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE pro_mesadetrabajo SET nombregrupo=@nombregrupo WHERE codigo=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        conector.AsignarParametroCadena("@nombregrupo", nombregrupo);
        return conector.guardadata();

    }

    public DataRow buscarCodAnioxNombre(string anio)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo FROM ins_anio WHERE nombre=@anio";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@anio", anio);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;
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

    public DataTable cargarEstrategias()
    {
        Conexion conector = new Conexion();
        string consulta = "select * from est_estrategia";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarMomentos()
    {
        Conexion conector = new Conexion();
        string consulta = "select * from act_momento";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarMomentosEstra1()
    {
        Conexion conector = new Conexion();
        string consulta = "select * from act_momento where codigo!=2";
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
        string consulta = "select b.codigo as codbitacora, ps.codigo as codproyectosede, ps.nombregrupo, ps.codlineainvestigacion, m.cod as codmunicipio, m.nombre as municipio, d.cod as coddepartamento, d.nombre as departamento, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, i.nombre as nominstitucion, s.nombre as nomsede, b.fechacreacion from est_estra1bitacora1 b inner join pro_proyectosede ps on b.codproyectosede=ps.codigo inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento inner join est_asesorcoordinador ac on ac.codigo=ps.codasesorcoordinador inner join est_asesor a on a.codigo=ac.codasesor where ps.codasesorcoordinador=@codasesorcoordinador order by b.fechacreacion desc;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarbitacoraunoxAsesorxMomento(string codasesorcoordinador, string momento, string anio)
    {
        Conexion conector = new Conexion();
        string consulta = "select b.codigo as codbitacora, ps.codigo as codproyectosede, ps.nombregrupo, ps.codlineainvestigacion, m.cod as codmunicipio, m.nombre as municipio, d.cod as coddepartamento, d.nombre as departamento, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, i.nombre as nominstitucion, s.nombre as nomsede, b.fechacreacion from est_estra1bitacora1 b inner join pro_proyectosede ps on b.codproyectosede=ps.codigo inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento inner join est_asesorcoordinador ac on ac.codigo=ps.codasesorcoordinador inner join est_asesor a on a.codigo=ac.codasesor where ps.codasesorcoordinador=@codasesorcoordinador and b.momento=@momento";
        //and extract(year from b.fechacreacion)=@anio
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@momento", momento);
        //conector.AsignarParametroCadena("@anio", anio);
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
        string consulta = "select ps.codigo as codredtematicasede, ps.fechacreacion, s.nombre as nomsede, i.nombre as nominstitucion, CONCAT_WS(' ',r.nombre,ps.consecutivogrupo) as nombre, ac.codigo as codasesorcoordinador, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, m.nombre as municipio, d.nombre as departamento, (select count(*) from rt_redtematicamatricula where codredtematicasede=ps.codigo) as cantestudiantes, (select count(*) from rt_redtematicadocente where codredtematicasede=ps.codigo) as cantdocente from rt_redtematicasede ps inner join rt_redtematica r on r.codigo=ps.codredtematica left join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento order by a.apellido asc;";
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
    public DataTable cargarRedTematicaxAsesorAnio(string codasesorcoordinador, string anio)
    {
        Conexion conector = new Conexion();
        string consulta = "select ps.codigo as codredtematicasede, ps.fechacreacion, ps.aniored, s.nombre as nomsede, i.nombre as nominstitucion, CONCAT_WS(' ',r.nombre,ps.consecutivogrupo) as nombre, ac.codigo as codasesorcoordinador, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, m.nombre as municipio, d.nombre as departamento, (select count(*) from rt_redtematicamatricula where codredtematicasede=ps.codigo) as cantestudiantes, (select count(*) from rt_redtematicadocente where codredtematicasede=ps.codigo) as cantdocente from rt_redtematicasede ps inner join rt_redtematica r on r.codigo=ps.codredtematica left join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where ps.codasesorcoordinador=@codasesorcoordinador and ps.aniored=@anio order by a.apellido asc;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@anio", anio);
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

    public DataTable cargarGruposInvestigacionxAsesorLinea(string codasesorcoordinador, string linea)
    {
        Conexion conector = new Conexion();
        string consulta = "select ps.codigo as codproyectosede, i.nombre as nominstitucion, s.nombre as nomsede, ps.nombregrupo, pa.nombre as nomarea, li.nombre as nomlinea, ac.codigo as codasesorcoordinador, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, m.nombre as nommunicipio, d.nombre as nomdepartamento from pro_proyectosede ps left join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join pro_areas pa on pa.codigo=ps.codarea inner join pro_linea_investigacion li on li.codigo=ps.codlineainvestigacion inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where ps.codasesorcoordinador=@codasesorcoordinador and ps.codlineainvestigacion=@linea order by a.apellido asc;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@linea", linea);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarRedesTematicasxAsesor(string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "select rts.codigo as codredtematicasede, i.nombre as nominstitucion, s.nombre as nomsede, concat_ws(' ',rt.nombre,rts.consecutivogrupo) as nombregrupo, rts.fechacreacion, ac.codigo as codasesorcoordinador, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, m.nombre as nommunicipio, d.nombre as nomdepartamento, (select count(*) from rt_redtematicamatricula where codredtematicasede=rts.codigo) as cantestudiantes, (select count(*) from rt_redtematicadocente where codredtematicasede=rts.codigo) as cantdocente, rts.aniored from rt_redtematicasede rts left join est_asesorcoordinador ac on rts.codasesorcoordinador=ac.codigo inner join rt_redtematica rt on rt.codigo=rts.codredtematica inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=rts.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where rts.codasesorcoordinador=@codasesorcoordinador order by a.apellido asc;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarRedesTematicasxAsesorxAnio(string codasesorcoordinador, string anio)
    {
        Conexion conector = new Conexion();
        string consulta = "select rts.codigo as codredtematicasede, i.nombre as nominstitucion, s.nombre as nomsede, concat_ws(' ',rt.nombre,rts.consecutivogrupo) as nombregrupo, rts.fechacreacion, ac.codigo as codasesorcoordinador, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, m.nombre as nommunicipio, d.nombre as nomdepartamento, (select count(*) from rt_redtematicamatricula where codredtematicasede=rts.codigo) as cantestudiantes, (select count(*) from rt_redtematicadocente where codredtematicasede=rts.codigo) as cantdocente, rts.aniored from rt_redtematicasede rts left join est_asesorcoordinador ac on rts.codasesorcoordinador=ac.codigo inner join rt_redtematica rt on rt.codigo=rts.codredtematica inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=rts.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where rts.codasesorcoordinador=@codasesorcoordinador and rts.aniored=@anio order by a.apellido asc;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@anio", anio);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarRedesTematicasxAsesorSeguimiento(string codasesorcoordinador, string anio)
    {
        Conexion conector = new Conexion();
        string consulta = "select rts.codigo as codredtematicasede, i.nombre as nominstitucion, s.nombre as nomsede, concat_ws(' ',rt.nombre,rts.consecutivogrupo) as nombregrupo, rts.fechacreacion, ac.codigo as codasesorcoordinador, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, m.nombre as nommunicipio, d.nombre as nomdepartamento from rt_redtematicasede rts left join est_asesorcoordinador ac on rts.codasesorcoordinador=ac.codigo inner join rt_redtematica rt on rt.codigo=rts.codredtematica inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=rts.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where rts.codasesorcoordinador=@codasesorcoordinador and rts.aniored=@anio order by a.apellido asc;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@anio", anio);
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
        string consulta = "SELECT ac.codigo, concat_ws(' ',a.nombre,a.apellido) as nombre FROM est_asesor a inner join est_asesorcoordinador ac on a.codigo=ac.codasesor WHERE identificacion=@identificacion";
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
    public DataRow buscarEvidenciaEstrategia4(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_repositoriocoordinador_estra4 WHERE cod=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public DataRow buscarEvidenciaEstrategia5Coord(string codigo)
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
    public DataRow buscarEvidenciaEstrategia3(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_estra3repositorio WHERE cod=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public DataRow buscarEvidenciaInfoTecnico(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_repositoriocoordinador_infotecnico WHERE codigo=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public DataRow buscarEvidenciaEstrategia5(string codigo)
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

    public DataRow buscarEvidenciaEstrategia1EspaciosApropiacion(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_repositorioasesor_espaciosapropiacion WHERE cod=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public DataRow buscarEvidenciaEstrategia1Preestructurados(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_repositorioasesor_preestructurados WHERE cod=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public DataRow buscarEvidenciaEstrategia1JornadaFormacion(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_repositoriocoordinador_jornadaformacion WHERE cod=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public DataRow buscarEvidenciaEstrategia1bitacora6(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_repositorioasesor_bitacora6 WHERE cod=@codigo;";
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
    public DataRow buscarEvidenciaCajaHerramientas(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_estra2cajadeherramientas WHERE cod=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public DataRow buscarEvidenciaPublicaciones(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_estra1publicaciones_guias WHERE cod=@codigo;";
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
    public DataTable buscarEvidenciaEstrategia4AsesorRedTematicaxUsuario(string codredtematicasede, string codusuario)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_repositorioasesor_estra4 WHERE codredtematicasede=@codredtematicasede AND codusuario=@codusuario;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        DataTable datos = conector.traerdata();
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
    public Boolean agregarArchivoRespositorioEstrategia5(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string sesion, string actividad, string estrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO est_repositoriocoordinador_estra5 (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,sesion,actividad,estrategia) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@sesion,@actividad,@estrategia)";
       

        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroDouble("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fechacreado);
        
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@actividad", actividad);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean agregarArchivoRespositorioEstrategia3(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string codanio, string actividad, string proceso)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO est_estra3repositorio (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,codanio,actividad,proceso) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@codanio,@actividad,@proceso)";


        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroDouble("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fechacreado);

        conector.AsignarParametroCadena("@codanio", codanio);
        conector.AsignarParametroCadena("@actividad", actividad);
        conector.AsignarParametroCadena("@proceso", proceso);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean agregarArchivoRespositorioInfoTecnico(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string estrategia, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO est_repositoriocoordinador_infotecnico (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,actividad,estrategia) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@actividad,@estrategia)";


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
        conector.AsignarParametroCadena("@estrategia", estrategia);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean agregarArchivoRespositorioEstra5_Lineamientos(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string actividad, string estrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO est_repositoriocoordinador_estra5 (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,actividad,estrategia) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@actividad,@estrategia)";


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
        conector.AsignarParametroCadena("@estrategia", estrategia);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean agregarArchivoRespositorioEstra5_Matricula(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string actividad, string estrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO est_repositoriocoordinador_estra5 (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,actividad,estrategia) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@actividad,@estrategia)";


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
    public Boolean borrarEvidenciaEstrategia4(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositoriocoordinador_estra4 WHERE cod=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean borrarEvidenciaEstrategia5Coord(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositoriocoordinador_estra5 WHERE cod=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean borrarEvidenciaEstrategia3(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra3repositorio WHERE cod=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean borrarEvidenciaInfoTecnico(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositoriocoordinador_infotecnico WHERE codigo=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean borrarEvidenciaEstrategia5(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositoriocoordinador_estra5 WHERE cod=@codigo ";
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
    public Boolean borrarEvidenciaEstrategia1EspaciosApropiacion(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositorioasesor_espaciosapropiacion WHERE cod=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean borrarEvidenciaEstrategia1Preestructurados(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositorioasesor_preestructurados WHERE cod=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean borrarEvidenciaEstrategia1JornadaFormacion(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositoriocoordinador_jornadaformacion WHERE cod=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean borrarEvidenciaEstrategia1bitacora6(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositorioasesor_bitacora6 WHERE cod=@codigo ";
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
    public Boolean borrarEvidenciaCajaHerramientas(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2cajadeherramientas WHERE cod=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean borrarEvidenciaPublicaciones(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1publicaciones_guias WHERE cod=@codigo ";
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
    public DataTable cargarEvidenciasEstrategiaConActividadSinUsuario(string momento, string sesion, string estrategia, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoordinador rc inner join usu_usuario u on u.cod=rc.codusuario WHERE momento=@momento and sesion=@sesion and estrategia=@estrategia and actividad=@actividad ORDER BY fechacreado ASC";
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
    public DataTable cargarEvidenciasEstrategiaI(string momento, string sesion, string estrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoordinador rc inner join usu_usuario u on u.cod=rc.codusuario WHERE momento=@momento and sesion=@sesion and estrategia=@estrategia ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarEvidenciasInfoTecnico(string estrategia, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT rc.*, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoordinador_infotecnico rc inner join usu_usuario u on u.cod=rc.codusuario WHERE estrategia=@estrategia and codusuario=@codusuario ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarEvidenciasInfoTecnico(string estrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT rc.*, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoordinador_infotecnico rc inner join usu_usuario u on u.cod=rc.codusuario WHERE estrategia=@estrategia ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        //conector.AsignarParametroCadena("@codusuario", codusuario);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarEvidenciasEstrategia5(string sesion, string codusuario, string estrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoordinador_estra5 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE codusuario=@codusuario and sesion=@sesion and estrategia=@estrategia ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarEvidenciasEstrategia3(string proceso, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_estra3repositorio rc inner join usu_usuario u on u.cod=rc.codusuario WHERE codusuario=@codusuario and proceso=@proceso ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@proceso", proceso);
  
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarEvidenciasEstrategia3I(string proceso)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_estra3repositorio rc inner join usu_usuario u on u.cod=rc.codusuario WHERE proceso=@proceso ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@proceso", proceso);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarEvidenciasEstrategia5_Lineamientos(string codusuario, string estrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoordinador_estra5 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE codusuario=@codusuario and estrategia=@estrategia and (actividad='Diseño de lineamientos de la estrategia formación' or actividad='Aprobación de los lineamientos de formación') ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarEvidenciasEstrategia5_Lineamientos(string estrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoordinador_estra5 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE estrategia=@estrategia and (actividad='Diseño de lineamientos de la estrategia formación' or actividad='Aprobación de los lineamientos de formación') ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        //conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarEvidenciasEstrategia5_Matricula(string codusuario, string estrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoordinador_estra5 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE codusuario=@codusuario and estrategia=@estrategia and (actividad='Base de datos de los matriculados' or actividad='S001: Formato de inscripción de actores o matrícula') ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarEvidenciasEstrategia5_Matricula(string estrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoordinador_estra5 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE estrategia=@estrategia and (actividad='Base de datos de los matriculados' or actividad='S001: Formato de inscripción de actores o matrícula') ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        //conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarEvidenciasEstrategia4AsesorRedTematica(string codredtematicasede, string codusuario, string sesion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT rc.*, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositorioasesor_estra4 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE  rc.codredtematicasede=@codredtematicasede and rc.codusuario=@codusuario and sesion=@sesion ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        conector.AsignarParametroCadena("@sesion", sesion);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarEvidenciasEstrategia4AsesorRedTematicaCoord(string codredtematicasede, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT rc.*, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositorioasesor_estra4 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE  rc.codredtematicasede=@codredtematicasede and rc.codusuario=@codusuario ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        //conector.AsignarParametroCadena("@sesion", sesion);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarEvidenciasEstrategia4AsesorRedTematicaActiv(string codredtematicasede, string codusuario, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT rc.*, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositorioasesor_estra4 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE  rc.codredtematicasede=@codredtematicasede and rc.codusuario=@codusuario and rc.actividad=@actividad ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        conector.AsignarParametroCadena("@actividad", actividad);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarEvidenciasEstrategia4AsesorRedTematicaSeguimiento(string codredtematicasede, string actividad, string sesion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT rc.*, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositorioasesor_estra4 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE  rc.codredtematicasede=@codredtematicasede and actividad=@actividad and sesion=@sesion ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@actividad", actividad);
        conector.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        conector.AsignarParametroCadena("@sesion", sesion);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarEvidenciasEstrategia4AsesorRedTematicaSeguimientoVirtuales(string codredtematicasede, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT rc.*, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositorioasesor_s004_ev rc inner join usu_usuario u on u.cod=rc.codusuario WHERE  rc.codinstrumento=@codredtematicasede and actividad=@actividad  ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@actividad", actividad);
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
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre, CASE WHEN rc.subactividad=1 THEN 'Lineamientos de la estrategia' WHEN rc.subactividad=2 THEN 'Acta de aprobación cómite técnico' WHEN rc.subactividad=1 THEN 'Ruta metodológica' end as nomactividad FROM est_repositoriocoordinador_estra4 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE momento=@momento and sesion=@sesion and estrategia=@estrategia and actividad=@actividad ORDER BY fechacreado ASC";
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
    public DataTable cargarEvidenciasEstrategia4Acti2(string momento, string sesion, string actividad, string estrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre, CASE WHEN rc.subactividad=1 THEN 'Planes de trabajo de las sesiones presenciales/virtuales' WHEN rc.subactividad=2 THEN 'Cronogramas de trabajo' WHEN rc.subactividad=1 THEN 'Acta de aprobación cómite técnico' end as nomactividad FROM est_repositoriocoordinador_estra4 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE momento=@momento and sesion=@sesion and estrategia=@estrategia and actividad=@actividad ORDER BY fechacreado ASC";
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

        if (actividad == "50&51")
            consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoordinador rc inner join usu_usuario u on u.cod=rc.codusuario WHERE estrategia=@estrategia and momento=@momento and sesion=@sesion and (actividad='50' OR actividad='51' ) ORDER BY fechacreado ASC";
        else if(actividad != "")
            consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoordinador rc inner join usu_usuario u on u.cod=rc.codusuario WHERE estrategia=@estrategia and momento=@momento and sesion=@sesion and actividad=@actividad ORDER BY fechacreado ASC";
        else
            consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoordinador rc inner join usu_usuario u on u.cod=rc.codusuario WHERE estrategia=@estrategia and momento=@momento and sesion=@sesion ORDER BY fechacreado ASC";

        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);

        if (actividad != "" && actividad != "50&51")
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

    public DataRow loadSelectBitacoraSeis(string codigo)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s.codigo as codigosede, s.nombre as nombresede, i.codigo as codigoinstitucion, i.nombre as nombreinstitucion, m.cod as codigomunicipio, m.nombre as nombremunicipio, d.cod as codigodepartamento, d.nombre as nombredepartamento, eeb.codproyectosede as codigogrupoinvestigacion, pps.nombregrupo as nombregrupoinvestigacion  from est_estra1bitacora6 eeb inner join pro_proyectosede pps on pps.codigo = eeb.codproyectosede inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where eeb.codigo = @codigo";
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

    public DataTable listarBitacoraCuatroxAsesorxMomento(string codasesorcoordinador, string momento, string anio)
    {
        Conexion conector = new Conexion();
        string sql = "select g.*, d.nombre as nombredepartamento, m.nombre as nombremunicipio, i.nombre as nombreinstitucion, s.nombre as nombresede, p.nombregrupo, concat_ws(' ',a.nombre,a.apellido) as asesor from est_estra2instrumento_g007 g inner join pro_proyectosede p on p.codigo=g.codproyecto inner join est_asesorcoordinador ac on ac.codigo=p.codasesorcoordinador inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=p.codsede inner join ins_institucion i on s.codinstitucion=i.codigo inner join geo_municipios m on i.codmunicipio=m.cod inner join geo_departamentos d on d.cod=m.coddepartamento where g.codasesorcoordinador=@codasesorcoordinador and g.momento=@momento  order by g.fechadiligenciamiento desc";
        //and extract(year from g.fechadiligenciamiento)=@anio
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@momento", momento);
        //conector.AsignarParametroCadena("@anio", anio);
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

    public DataTable cargarLineaInvestigacionxAsesor(string codSede, string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string sql = "SELECT * FROM pro_proyectosede WHERE codsede='" + codSede + "' AND codasesorcoordinador='" + codasesorcoordinador + "' ORDER BY nombregrupo ASC";
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

    public bool updateEncabezado(string valFecha, string valtActividad, string valTema, string valFacilitador, string valhInicio, string valhFin, string codigo)
    {
        Conexion conector = new Conexion();
        string sql = "UPDATE est_inasistenciasinstrumento_g001 SET fecha=@valFecha, tipoactividad=@valtActividad, tema=@valTema, facilitador=@valFacilitador, horainicio=@valhInicio, horafinal=@valhFin WHERE codigo=@codigo";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@valFecha", valFecha);
        conector.AsignarParametroCadena("@valtActividad", valtActividad);
        conector.AsignarParametroCadena("@valTema", valTema);
        conector.AsignarParametroCadena("@valFacilitador", valFacilitador);
        conector.AsignarParametroCadena("@valhInicio", valhInicio);
        conector.AsignarParametroCadena("@valhFin", valhFin);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool dato = conector.guardadata();
        return dato;

    }

    public bool eliminarinasistenciasg001estra4(string codigo)
    {
        Conexion conector = new Conexion();
        string sql = "DELETE FROM est_inasistenciasinstrumento_g001detalle WHERE codinasistenciainstrumento_g001=@codigo";
        conector.CrearComando(sql);
       
        conector.AsignarParametroCadena("@codigo", codigo);
        bool dato = conector.guardadata();
        return dato;

    }

    public DataRow guardarEncabezadoS004_estra5coord(string valFecha, string actividad, string valhInicio, string valhFin, string codestras004)
    {
        Conexion conector = new Conexion();
        string sql = "INSERT INTO est_estrainstrumento_s004coord_asist (fecha, actividad, horainicio, horafin, codestras004) VALUES ( @valFecha, @actividad, @valhInicio, @valhFin, @codestras004) RETURNING codigo";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@valFecha", valFecha);
        conector.AsignarParametroCadena("@actividad", actividad);
        conector.AsignarParametroCadena("@valhInicio", valhInicio);
        conector.AsignarParametroCadena("@valhFin", valhFin);
        conector.AsignarParametroCadena("@codestras004", codestras004);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;

    }
    public DataRow guardarEncabezado_2016(string valFecha, string valtActividad, string valTema, string valFacilitador, string valhInicio, string valhFin, string codinstrumentos004)
    {
        Conexion conector = new Conexion();
        string sql = "INSERT INTO est_inasistenciasinstrumento_g001_2016 (fecha, tipoactividad, tema, facilitador, horainicio, horafinal, codinstrumentos004_2016) VALUES ( @valFecha, @valtActividad, @valTema, @valFacilitador, @valhInicio, @valhFin, @codinstrumentos004) RETURNING codigo";
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

    public bool guardarEstudianteInasistenteS004_estra5(string codInasistencia, string codEstudiante)
    {

        Conexion conector = new Conexion();
        string sql = "INSERT INTO est_estrainstrumento_s004coord_asistdetalle (codestras004coord_asist, cods004matriculado) VALUES (@codInasistencia, @codEstudiante)";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codInasistencia", codInasistencia);
        conector.AsignarParametroCadena("@codEstudiante", codEstudiante);
        return conector.guardadata();

    }

    public bool guardarEstudianteInasistente_2016(string codInasistencia, string codEstudiante)
    {

        Conexion conector = new Conexion();
        string sql = "INSERT INTO est_inasistenciasinstrumento_g001detalle_2016 (codinasistenciainstrumento_g001, codestumatricula) VALUES (@codInasistencia, @codEstudiante)";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codInasistencia", codInasistencia);
        conector.AsignarParametroCadena("@codEstudiante", codEstudiante);
        return conector.guardadata();

    }

    /* End Funciones Instrumento G001 */

    public DataTable cargarAsesores(string codasesor)
    {
        Conexion conector = new Conexion();
        string sql = "SELECT ac.codigo, a.nombre, a.apellido FROM est_asesor a INNER JOIN est_asesorcoordinador ac ON ac.codasesor = a.codigo INNER JOIN est_estracoordinador sc ON sc.codigo = ac.codestracoordinador WHERE ac.codigo = @codasesor ";
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
        string sql = "SELECT a.codigo, a.nombre, a.apellido FROM est_asesor a INNER JOIN est_asesorcoordinador ac ON ac.codasesor = a.codigo INNER JOIN est_estracoordinador sc ON sc.codigo = ac.codestracoordinador WHERE ac.codestracoordinador= @codestracoordinador ";
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
    public DataRow encabezadoS002_docentes(string codProyecto, string codAsesor, string noAsesoria, string fechaVisita, string duracionHoras, string tipoAcompaniamiento, string motivoAsesoria, string objetivo, string estrategia, string momento, string sesion, string noproyectadas, string noasistentes)
    //public DataRow encabezadoS002(string codProyecto, string codAsesor, string nomInvestigacion, string noAsesoria, string fechaVisita, string duracionHoras, string tipoAcompaniamiento, string motivoAsesoria, string objetivo, string estrategia, string momento, string sesion)
    {
        Conexion conector = new Conexion();
        string sql = "INSERT INTO est_estra2instrumento_s002regase (codproyectodocente, codasesorcoordinador, nominvestigacion, noasesoria, fechavisita duracion_horas, tipoasesoria, motivoasesoria, objetivo, sesion, jornada, noproyectadas, noasistentes) VALUES (@codproyectodocente, @codasesorcoordinador, @nominvestigacion, @noasesoria, @fechavisita, @duracionHoras, @tipoAcompaniamiento, @motivoAsesoria, @objetivo,@sesion, @jornada, @noproyectadas, @noasistentes) RETURNING codigo";
        //string sql = "INSERT INTO est_estra2instrumento_s002 (codproyecto, codasesor, nominvestigacion, noasesoria, fechavisita, duracion_horas, tipoasesoria, motivoasesoria, objetivo, estrategia, momento, sesion) VALUES (@codProyecto, @codAsesor, @nomInvestigacion, @noAsesoria, @fechaVisita, @duracionHoras, @tipoAcompaniamiento, @motivoAsesoria, @objetivo,@estrategia,@momento, @sesion) RETURNING codigo";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codproyectodocente", codProyecto);
        conector.AsignarParametroCadena("@codasesorcoordinador", codAsesor);
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
        string sql = "SELECT a.codigo, a.nombre, a.apellido FROM est_asesor a INNER JOIN est_asesorcoordinador ac ON ac.codasesor = a.codigo INNER JOIN est_asesorcoordocente acd ON acd.codasesorcoordinador = ac.codigo WHERE acd.codgradodocente = @codDocente ";
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
        string consulta = "select rtm.codigo as codestumatred,* from ins_estudiante e  inner join ins_estumatricula em on em.codestudiante = e.codigo inner join rt_redtematicamatricula rtm on rtm.codestumatricula = em.codigo inner join rt_redtematicasede rts on rts.codigo=rtm.codredtematicasede inner join rt_redtematica rt on rt.codigo=rts.codredtematica where rtm.codredtematicasede =@codRedTematica";
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

    public DataRow buscarEstudianteRedesTematicasInasistencias(string codigo, string codestumatricula)
    {
        Conexion conectar = new Conexion();
        string consulta = "select * from est_inasistenciasinstrumento_g001detalle where codinasistenciainstrumento_g001 =@codigo and codestumatricula=@codestumatricula";
        conectar.CrearComando(consulta);

        conectar.AsignarParametroCadena("@codigo", codigo);
        conectar.AsignarParametroCadena("@codestumatricula", codestumatricula);
        DataRow datos = conectar.traerfila();
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
        string consulta = "delete from rt_redtematicamatricula where codigo = @codEstudiante";
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

    public bool deleteRedTematicaGrados(string codredtematicasede)
    {
        Conexion conectar = new Conexion();
        string consulta = "delete from rt_redtematicagrados where codredtematicasede = @codredtematicasede";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        return conectar.guardadata();
    }

    /* funciones Bitacora 6 */
    public DataRow encabezadoBitacora6(string codProyecto, string trayecto1, string trayecto2, string trayecto3, string trayecto4, string conclusion1, string conclusion2, string conclusion3, string conclusion4, string dificultades, string fortalezas, string caracteristicas, string acciones, string estrategia, string momento)
    {
        Conexion conectar = new Conexion();
        string sql = "INSERT INTO est_estra1bitacora6 (codproyectosede, trayecto1, trayecto2, trayecto3, trayecto4, conclusion1, conclusion2, conclusion3, conclusion4, dificultades, fortalezas, caracteristicas, acciones, estrategia, momento, fechacreacion) VALUES (@codProyecto, @trayecto1, @trayecto2, @trayecto3, @trayecto4, @conclusion1, @conclusion2, @conclusion3, @conclusion4, @dificultades, @fortalezas, @caracteristicas, @acciones, @estrategia, @momento, NOW()) RETURNING codigo";
        conectar.CrearComando(sql);
        conectar.AsignarParametroCadena("@codProyecto", codProyecto);
        conectar.AsignarParametroCadena("@trayecto1", trayecto1);
        conectar.AsignarParametroCadena("@trayecto2", trayecto2);
        conectar.AsignarParametroCadena("@trayecto3", trayecto3);
        conectar.AsignarParametroCadena("@trayecto4", trayecto4);
        conectar.AsignarParametroCadena("@conclusion1", conclusion1);
        conectar.AsignarParametroCadena("@conclusion2", conclusion2);
        conectar.AsignarParametroCadena("@conclusion3", conclusion3);
        conectar.AsignarParametroCadena("@conclusion4", conclusion4);
        conectar.AsignarParametroCadena("@dificultades", dificultades);
        conectar.AsignarParametroCadena("@fortalezas", fortalezas);
        conectar.AsignarParametroCadena("@caracteristicas", caracteristicas);
        conectar.AsignarParametroCadena("@acciones", acciones);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        conectar.AsignarParametroCadena("@momento", momento);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public bool bitacora6Detalles(string codEstraBitacora, string actividad, string herramienta, string resultado, string presupuesto)
    {
        Conexion conectar = new Conexion();
        string consulta = "INSERT INTO est_estra1bitacora6_detalle (codestraunobitacoraseis, actividad, herramienta, resultado, presupuesto) VALUES (@codEstraBitacora, @actividad, @herramienta, @resultado, @presupuesto)";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codEstraBitacora", codEstraBitacora);
        conectar.AsignarParametroCadena("@actividad", actividad);
        conectar.AsignarParametroCadena("@herramienta", herramienta);
        conectar.AsignarParametroCadena("@resultado", resultado);
        conectar.AsignarParametroCadena("@presupuesto", presupuesto);
        return conectar.guardadata();
    }
    public bool bitacora6Detalles_2do(string codEstraBitacora, string actividad, string herramienta, string resultado, string presupuesto)
    {
        Conexion conectar = new Conexion();
        string consulta = "INSERT INTO est_estra1bitacora6_detalle_2 (codestraunobitacoraseis, actividad, herramienta, resultado, presupuesto) VALUES (@codEstraBitacora, @actividad, @herramienta, @resultado, @presupuesto)";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codEstraBitacora", codEstraBitacora);
        conectar.AsignarParametroCadena("@actividad", actividad);
        conectar.AsignarParametroCadena("@herramienta", herramienta);
        conectar.AsignarParametroCadena("@resultado", resultado);
        conectar.AsignarParametroCadena("@presupuesto", presupuesto);
        return conectar.guardadata();
    }
    public bool bitacora6Detalles_3ro(string codEstraBitacora, string actividad, string herramienta, string resultado, string presupuesto)
    {
        Conexion conectar = new Conexion();
        string consulta = "INSERT INTO est_estra1bitacora6_detalle_3 (codestraunobitacoraseis, actividad, herramienta, resultado, presupuesto) VALUES (@codEstraBitacora, @actividad, @herramienta, @resultado, @presupuesto)";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codEstraBitacora", codEstraBitacora);
        conectar.AsignarParametroCadena("@actividad", actividad);
        conectar.AsignarParametroCadena("@herramienta", herramienta);
        conectar.AsignarParametroCadena("@resultado", resultado);
        conectar.AsignarParametroCadena("@presupuesto", presupuesto);
        return conectar.guardadata();
    }
    public bool bitacora6Detalles_4to(string codEstraBitacora, string actividad, string herramienta, string resultado, string presupuesto)
    {
        Conexion conectar = new Conexion();
        string consulta = "INSERT INTO est_estra1bitacora6_detalle_4 (codestraunobitacoraseis, actividad, herramienta, resultado, presupuesto) VALUES (@codEstraBitacora, @actividad, @herramienta, @resultado, @presupuesto)";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codEstraBitacora", codEstraBitacora);
        conectar.AsignarParametroCadena("@actividad", actividad);
        conectar.AsignarParametroCadena("@herramienta", herramienta);
        conectar.AsignarParametroCadena("@resultado", resultado);
        conectar.AsignarParametroCadena("@presupuesto", presupuesto);
        return conectar.guardadata();
    }
    /* funciones Bitacora 5 */
    public DataRow encabezadoBitacora5(string codProyecto, string objetivoFinal, string nomTrayectoIndagacion, string dificultadesFortalezas, string principalesCaracteristicas, string importanciaInvestigacion, string importanciaIEP, string general, string especifico, string estrategia, string momento, string sesion, string nomTrayectoIndagacion2, string nomTrayectoIndagacion3, string nomTrayectoIndagacion4, string nomTrayectoIndagacion5, string nomTrayectoIndagacion6, string nomTrayectoIndagacion7, string nomTrayectoIndagacion8)
    {
        Conexion conectar = new Conexion();
        string sql = "INSERT INTO est_estra1bitacora5 (codproyecto, objetivofinal, nomtrayectoindagacion, dificultadesfortalezas, principalescaracteristicas, importanciasinvestigacion, importanciaiep,general,especifico, estrategia,momento,sesion, nomTrayectoIndagacion2, nomTrayectoIndagacion3,fechacreado, nomtrayectoindagacion4, nomtrayectoindagacion5, nomtrayectoindagacion6, nomtrayectoindagacion7, nomtrayectoindagacion8) VALUES (@codProyecto, @objetivoFinal, @nomTrayectoIndagacion, @dificultadesFortalezas, @principalesCaracteristicas, @importanciaInvestigacion, @importanciaIEP,@general,@especifico,@estrategia,@momento,@sesion, @nomTrayectoIndagacion2,@nomTrayectoIndagacion3,NOW(), @nomtrayectoindagacion4, @nomtrayectoindagacion5, @nomtrayectoindagacion6, @nomtrayectoindagacion7, @nomtrayectoindagacion8 ) RETURNING codigo";
        conectar.CrearComando(sql);
        conectar.AsignarParametroCadena("@codProyecto", codProyecto);
        conectar.AsignarParametroCadena("@objetivoFinal", objetivoFinal);
        conectar.AsignarParametroCadena("@nomTrayectoIndagacion", nomTrayectoIndagacion);
        conectar.AsignarParametroCadena("@nomTrayectoIndagacion2", nomTrayectoIndagacion2);
        conectar.AsignarParametroCadena("@nomTrayectoIndagacion3", nomTrayectoIndagacion3);
        conectar.AsignarParametroCadena("@nomtrayectoindagacion4", nomTrayectoIndagacion4);
        conectar.AsignarParametroCadena("@nomtrayectoindagacion5", nomTrayectoIndagacion5);
        conectar.AsignarParametroCadena("@nomtrayectoindagacion6", nomTrayectoIndagacion6);
        conectar.AsignarParametroCadena("@nomtrayectoindagacion7", nomTrayectoIndagacion7);
        conectar.AsignarParametroCadena("@nomtrayectoindagacion8", nomTrayectoIndagacion8);
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

    public bool bitacora5Detalles_4to(string codEstraBitacora, string actividad, string herramienta, string responsable, string duracion, string presupuesto)
    {
        Conexion conectar = new Conexion();
        string consulta = "INSERT INTO est_estra1bitacora5_detalle_4 (codestraunobitacoracinco, actividades, herramientas, responsable, duracionmeses, presupuestorequerido) VALUES (@codEstraBitacora, @actividad, @herramienta, @responsable, @duracion, @presupuesto)";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codEstraBitacora", codEstraBitacora);
        conectar.AsignarParametroCadena("@actividad", actividad);
        conectar.AsignarParametroCadena("@herramienta", herramienta);
        conectar.AsignarParametroCadena("@responsable", responsable);
        conectar.AsignarParametroCadena("@duracion", duracion);
        conectar.AsignarParametroCadena("@presupuesto", presupuesto);
        return conectar.guardadata();
    }

    public bool bitacora5Detalles_5to(string codEstraBitacora, string actividad, string herramienta, string responsable, string duracion, string presupuesto)
    {
        Conexion conectar = new Conexion();
        string consulta = "INSERT INTO est_estra1bitacora5_detalle_5 (codestraunobitacoracinco, actividades, herramientas, responsable, duracionmeses, presupuestorequerido) VALUES (@codEstraBitacora, @actividad, @herramienta, @responsable, @duracion, @presupuesto)";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codEstraBitacora", codEstraBitacora);
        conectar.AsignarParametroCadena("@actividad", actividad);
        conectar.AsignarParametroCadena("@herramienta", herramienta);
        conectar.AsignarParametroCadena("@responsable", responsable);
        conectar.AsignarParametroCadena("@duracion", duracion);
        conectar.AsignarParametroCadena("@presupuesto", presupuesto);
        return conectar.guardadata();
    }

    public bool bitacora5Detalles_6to(string codEstraBitacora, string actividad, string herramienta, string responsable, string duracion, string presupuesto)
    {
        Conexion conectar = new Conexion();
        string consulta = "INSERT INTO est_estra1bitacora5_detalle_6 (codestraunobitacoracinco, actividades, herramientas, responsable, duracionmeses, presupuestorequerido) VALUES (@codEstraBitacora, @actividad, @herramienta, @responsable, @duracion, @presupuesto)";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codEstraBitacora", codEstraBitacora);
        conectar.AsignarParametroCadena("@actividad", actividad);
        conectar.AsignarParametroCadena("@herramienta", herramienta);
        conectar.AsignarParametroCadena("@responsable", responsable);
        conectar.AsignarParametroCadena("@duracion", duracion);
        conectar.AsignarParametroCadena("@presupuesto", presupuesto);
        return conectar.guardadata();
    }

    public bool bitacora5Detalles_7mo(string codEstraBitacora, string actividad, string herramienta, string responsable, string duracion, string presupuesto)
    {
        Conexion conectar = new Conexion();
        string consulta = "INSERT INTO est_estra1bitacora5_detalle_7 (codestraunobitacoracinco, actividades, herramientas, responsable, duracionmeses, presupuestorequerido) VALUES (@codEstraBitacora, @actividad, @herramienta, @responsable, @duracion, @presupuesto)";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codEstraBitacora", codEstraBitacora);
        conectar.AsignarParametroCadena("@actividad", actividad);
        conectar.AsignarParametroCadena("@herramienta", herramienta);
        conectar.AsignarParametroCadena("@responsable", responsable);
        conectar.AsignarParametroCadena("@duracion", duracion);
        conectar.AsignarParametroCadena("@presupuesto", presupuesto);
        return conectar.guardadata();
    }

    public bool bitacora5Detalles_8vo(string codEstraBitacora, string actividad, string herramienta, string responsable, string duracion, string presupuesto)
    {
        Conexion conectar = new Conexion();
        string consulta = "INSERT INTO est_estra1bitacora5_detalle_8 (codestraunobitacoracinco, actividades, herramientas, responsable, duracionmeses, presupuestorequerido) VALUES (@codEstraBitacora, @actividad, @herramienta, @responsable, @duracion, @presupuesto)";
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

    public DataTable cargarListadoMemorias_2016Coor(string codAsesorCoordinador, string offset, string limit, string anio)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004redt.codigo, s004redt.codredtematicasede, s004redt.nombresesion, rt.nombre, s004redt.fechaelaboracion, rts.consecutivogrupo, s004redt.momento, s004redt.sesion, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estra2instrumento_s004_redt_2016 s004redt inner join rt_redtematicasede rts on rts.codigo = s004redt.codredtematicasede inner join rt_redtematica rt on rt.codigo = rts.codredtematica inner join ins_sede s on s.codigo = rts.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004redt.codasesorcoordinador = @codAsesorCoordinador and extract(year from fechaelaboracion)=@anio offset @offset limit @limit";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codAsesorCoordinador", codAsesorCoordinador);
        conectar.AsignarParametroCadena("@limit", limit);
        conectar.AsignarParametroCadena("@offset", offset);
        conectar.AsignarParametroCadena("@anio", anio);
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

    public DataTable cargarListadoMemoriasCountCoord_2016Coor(string codAsesorCoordinador, string anio)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004redt.codigo, s004redt.codredtematicasede, s004redt.nombresesion, rt.nombre, s004redt.fechaelaboracion, rts.consecutivogrupo, s004redt.momento, s004redt.sesion, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estra2instrumento_s004_redt_2016 s004redt inner join rt_redtematicasede rts on rts.codigo = s004redt.codredtematicasede inner join rt_redtematica rt on rt.codigo = rts.codredtematica inner join ins_sede s on s.codigo = rts.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004redt.codasesorcoordinador = @codAsesorCoordinador and extract(year from fechaelaboracion)=@anio ";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codAsesorCoordinador", codAsesorCoordinador);
        conectar.AsignarParametroCadena("@anio", anio);
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

    public DataRow loadSelectBitacoraSiete(string codproyecto)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s.codigo as codigosede, s.nombre as nombresede, i.codigo as codigoinstitucion, i.nombre as nombreinstitucion, m.cod as codigomunicipio, m.nombre as nombremunicipio, d.cod as codigodepartamento, d.nombre as nombredepartamento, eeb.codproyectosede as codigogrupoinvestigacion, pps.nombregrupo as nombregrupoinvestigacion  from est_estra1bitacora7 eeb inner join pro_proyectosede pps on pps.codigo = eeb.codproyectosede inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where eeb.codproyectosede = @codproyecto";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codproyecto", codproyecto);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return dato;
    }

    public DataRow loadSelectJornadasFormacion(string codsede, string codanio)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s.codigo as codigosede, s.nombre as nombresede, i.codigo as codigoinstitucion, i.nombre as nombreinstitucion, m.cod as codigomunicipio, m.nombre as nombremunicipio, d.cod as codigodepartamento, d.nombre as nombredepartamento from est_estra1jornadasformacion eeb inner join ins_sede s on s.codigo = eeb.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where eeb.codsede = @codsede and eeb.codanio=@codanio";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codsede", codsede);
        conectar.AsignarParametroCadena("@codanio", codanio);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return dato;
    }

    public DataRow loadSelectEspaciosApropiacion(string codproyecto)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s.codigo as codigosede, s.nombre as nombresede, i.codigo as codigoinstitucion, i.nombre as nombreinstitucion, m.cod as codigomunicipio, m.nombre as nombremunicipio, d.cod as codigodepartamento, d.nombre as nombredepartamento, eeb.codproyectosede as codigogrupoinvestigacion, pps.nombregrupo as nombregrupoinvestigacion  from est_estra1espacioapropiacion eeb inner join pro_proyectosede pps on pps.codigo = eeb.codproyectosede inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where eeb.codproyectosede = @codproyecto";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codproyecto", codproyecto);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return dato;
    }

    public DataRow loadSelectParticipantesFerias(string codsede)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s.codigo as codigosede, s.nombre as nombresede, i.codigo as codigoinstitucion, i.nombre as nombreinstitucion, m.cod as codigomunicipio, m.nombre as nombremunicipio, d.cod as codigodepartamento, d.nombre as nombredepartamento from est_estra1participantesferias eeb  inner join ins_sede s on s.codigo = eeb.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where eeb.codsede = @codsede";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codsede", codsede);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return dato;
    }

    public DataRow loadSelectS008(string codproyecto)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s.codigo as codigosede, s.nombre as nombresede, i.codigo as codigoinstitucion, i.nombre as nombreinstitucion, m.cod as codigomunicipio, m.nombre as nombremunicipio, d.cod as codigodepartamento, d.nombre as nombredepartamento, eeb.codproyectosede as codigogrupoinvestigacion, pps.nombregrupo as nombregrupoinvestigacion  from est_estra1instrumento_s008 eeb inner join pro_proyectosede pps on pps.codigo = eeb.codproyectosede inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where eeb.codproyectosede = @codproyecto";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codproyecto", codproyecto);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return dato;
    }

    public DataRow loadSelectS003Estra1(string codproyecto)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s.codigo as codigosede, s.nombre as nombresede, i.codigo as codigoinstitucion, i.nombre as nombreinstitucion, m.cod as codigomunicipio, m.nombre as nombremunicipio, d.cod as codigodepartamento, d.nombre as nombredepartamento, eeb.codproyectosede as codigogrupoinvestigacion, pps.nombregrupo as nombregrupoinvestigacion  from est_estra1instrumento_s003 eeb inner join pro_proyectosede pps on pps.codigo = eeb.codproyectosede inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where eeb.codproyectosede = @codproyecto";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codproyecto", codproyecto);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return dato;
    }

    public DataRow loadInstrumentoSiete(string codigo)
    {
        Conexion conectar = new Conexion();
        string consulta = "select * from est_estra1bitacora7 eeb where eeb.codigo = @codigo";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codigo", codigo);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return dato;
    }

    public DataRow loadInstrumentoJornadasFormacion(string codigo)
    {
        Conexion conectar = new Conexion();
        string consulta = "select * from est_estra1jornadasformacion eeb where eeb.codigo = @codigo";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codigo", codigo);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return dato;
    }

    public DataRow loadEspacioApropiacion(string codigo)
    {
        Conexion conectar = new Conexion();
        string consulta = "select * from est_estra1espacioapropiacion eeb where eeb.codigo = @codigo";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codigo", codigo);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return dato;
    }

    public DataRow loadParticipantesFerias(string codigo)
    {
        Conexion conectar = new Conexion();
        string consulta = "select * from est_estra1participantesferias eeb where eeb.codigo = @codigo";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codigo", codigo);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return dato;
    }

    public DataRow loadInstrumentoS008(string codigo)
    {
        Conexion conectar = new Conexion();
        string consulta = "select * from est_estra1instrumento_s008 eeb where eeb.codigo = @codigo";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codigo", codigo);
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
        string sql = "select distinct ac.codigo, (a.nombre || ' ' || a.apellido) asesor, a.identificacion, a.nombre  from est_asesorcoordinador ac left join est_estracoordinador ec on ac.codestracoordinador=ec.codigo inner join est_coordinador c on c.codigo=ec.codcoordinador inner join est_asesor a on a.codigo=ac.codasesor where ec.codestrategia=@estrategia order by a.nombre asc";
        //string sql = "select distinct ac.codigo, (a.nombre || ' ' || a.apellido) asesor, a.nombre  from est_estracoordinador ec inner join est_asesorcoordinador ac on ac.codestracoordinador = ec.codestrategia inner join est_asesor a on a.codigo = ac.codasesor where ec.codestrategia = @estrategia order by a.nombre asc";
	conectar.CrearComando(sql);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        DataTable asesores = conectar.traerdata();
        if (asesores != null)
            return asesores;
        else
            return null;
    }

    public DataTable listarAsesoresSeguimiento(string estrategia)
    {
        Conexion conectar = new Conexion();
        string sql = "select distinct ac.codigo, (a.nombre || ' ' || a.apellido) asesor, a.identificacion, a.nombre  from est_asesorcoordinador ac left join est_estracoordinador ec on ac.codestracoordinador=ec.codigo inner join est_coordinador c on c.codigo=ec.codcoordinador inner join est_asesor a on a.codigo=ac.codasesor where ec.codestrategia=@estrategia and a.estado='On' order by a.nombre asc";
        //string sql = "select distinct ac.codigo, (a.nombre || ' ' || a.apellido) asesor, a.nombre  from est_estracoordinador ec inner join est_asesorcoordinador ac on ac.codestracoordinador = ec.codestrategia inner join est_asesor a on a.codigo = ac.codasesor where ec.codestrategia = @estrategia order by a.nombre asc";
        conectar.CrearComando(sql);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        DataTable asesores = conectar.traerdata();
        if (asesores != null)
            return asesores;
        else
            return null;
    }

    public DataTable listarAsesoresSeguimientoxAnio(string estrategia, string codanio)
    {
        Conexion conectar = new Conexion();
        string sql = "select distinct ac.codigo, (a.nombre || ' ' || a.apellido) asesor, a.identificacion, a.nombre  from est_asesorcoordinador ac left join est_estracoordinador ec on ac.codestracoordinador=ec.codigo inner join est_coordinador c on c.codigo=ec.codcoordinador inner join est_asesor a on a.codigo=ac.codasesor inner join est_asesoranio aa on aa.codasesor=a.codigo where ec.codestrategia=@estrategia and a.estado='On' and aa.codanio=@codanio order by a.nombre asc";
        //string sql = "select distinct ac.codigo, (a.nombre || ' ' || a.apellido) asesor, a.nombre  from est_estracoordinador ec inner join est_asesorcoordinador ac on ac.codestracoordinador = ec.codestrategia inner join est_asesor a on a.codigo = ac.codasesor where ec.codestrategia = @estrategia order by a.nombre asc";
        conectar.CrearComando(sql);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        conectar.AsignarParametroCadena("@codanio", codanio);
        DataTable asesores = conectar.traerdata();
        if (asesores != null)
            return asesores;
        else
            return null;
    }

    public DataTable listarAsesoresEvidencias(string estrategia)
    {
        Conexion conectar = new Conexion();
        string sql = "select distinct u.cod, ac.codigo, (a.nombre || ' ' || a.apellido) asesor, a.nombre  from est_asesorcoordinador ac left join est_estracoordinador ec on ac.codestracoordinador=ec.codigo inner join est_coordinador c on c.codigo=ec.codcoordinador inner join est_asesor a on a.codigo=ac.codasesor inner join usu_usuario u on CAST(u.identificacion as bigint)=a.identificacion  where ec.codestrategia=@estrategia order by a.nombre asc";
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
        string consulta = "select s004redt.codigo, s004redt.codredtematicasede, s004redt.nombresesion, rt.nombre, s004redt.fechaelaboracion, rts.consecutivogrupo, s004redt.momento, s004redt.sesion, rts.codsede, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estra2instrumento_s004_redt s004redt inner join rt_redtematicasede rts on rts.codigo = s004redt.codredtematicasede inner join rt_redtematica rt on rt.codigo = rts.codredtematica inner join ins_sede s on s.codigo = rts.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004redt.codasesorcoordinador = @codAsesor and s004redt.estrategia = @estrategia and s004redt.momento = @momento and s004redt.sesion = @sesion order by s004redt.fechaelaboracion DESC offset @offset limit @limit ";
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

    public DataTable cargarListadoMemoriasS004Todo(string codAsesor, string estrategia, string momento, string sesion)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004redt.codigo, s004redt.codredtematicasede, s004redt.nombresesion, rt.nombre, s004redt.fechaelaboracion, rts.consecutivogrupo, s004redt.momento, s004redt.sesion, rts.codsede, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estra2instrumento_s004_redt s004redt inner join rt_redtematicasede rts on rts.codigo = s004redt.codredtematicasede inner join rt_redtematica rt on rt.codigo = rts.codredtematica inner join ins_sede s on s.codigo = rts.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where rts.codasesorcoordinador = @codAsesor and s004redt.estrategia = @estrategia and s004redt.momento = @momento and s004redt.sesion = @sesion order by s004redt.fechaelaboracion DESC  ";
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

    public DataTable cargarListadoMemoriasS004Seguimiento(string codAsesor, string estrategia, string momento, string sesion, string anio)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004redt.codigo, s004redt.codredtematicasede, s004redt.nombresesion, rt.nombre, s004redt.fechaelaboracion, rts.consecutivogrupo, s004redt.momento, s004redt.sesion, rts.codsede, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estra2instrumento_s004_redt s004redt inner join rt_redtematicasede rts on rts.codigo = s004redt.codredtematicasede inner join rt_redtematica rt on rt.codigo = rts.codredtematica inner join ins_sede s on s.codigo = rts.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004redt.codasesorcoordinador = @codAsesor and s004redt.estrategia = @estrategia and s004redt.momento = @momento and s004redt.sesion = @sesion and extract(year from s004redt.fechaelaboracion)=@anio";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codAsesor", codAsesor);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        conectar.AsignarParametroCadena("@momento", momento);
        conectar.AsignarParametroCadena("@sesion", sesion);
        conectar.AsignarParametroCadena("@anio", anio);
        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return datos;
    }

    public DataTable cargarListadoMemoriasS004SeguimientoVirtual(string codAsesor, string estrategia, string momento, string sesion, string anio)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004redt.codigo, s004redt.codredtematicasede, s004redt.nombresesion, rt.nombre, s004redt.fechaelaboracion, rts.consecutivogrupo, s004redt.momento, s004redt.sesion, rts.codsede, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estrainstrumento_s004_redt_ev s004redt inner join rt_redtematicasede rts on rts.codigo = s004redt.codredtematicasede inner join rt_redtematica rt on rt.codigo = rts.codredtematica inner join ins_sede s on s.codigo = rts.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004redt.codasesorcoordinador = @codAsesor and s004redt.estrategia = @estrategia and s004redt.momento = @momento and s004redt.sesion = @sesion and extract(year from s004redt.fechaelaboracion)=@anio";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codAsesor", codAsesor);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        conectar.AsignarParametroCadena("@momento", momento);
        conectar.AsignarParametroCadena("@sesion", sesion);
        conectar.AsignarParametroCadena("@anio", anio);
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

    //public DataTable cargarListadoMemoriasS004SedesSeguimiento(string codAsesor, string estrategia, string momento, string sesion, string jornada, string anio)
    public DataTable cargarListadoMemoriasS004SedesSeguimiento(string estrategia, string codsede, string anio)
    {
        if (codsede == "Todos")
        {
            Conexion conectar = new Conexion();
            string consulta = "select COUNT(*) TOTAL, s004sede.codsede, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento, concat_ws('',a.nombre,a.apellido) as asesor, s004sede.codsede from est_estra2instrumento_s004_sede s004sede inner join ins_sede s on s.codigo = s004sede.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento inner join est_asesorcoordinador ac on ac.codigo=s004sede.codasesorcoordinador inner join est_asesor a on a.codigo=ac.codasesor  where   s004sede.estrategia = @estrategia and extract(year from s004sede.fechaelaboracion)=@anio group by s004sede.codsede, s004sede.codsede, s.nombre,  i.nombre, m.nombre, d.nombre, concat_ws('',a.nombre,a.apellido) order by s004sede.codsede";
            conectar.CrearComando(consulta);
            conectar.AsignarParametroCadena("@estrategia", estrategia);
            conectar.AsignarParametroCadena("@anio", anio);
            DataTable datos = conectar.traerdata();
            if (datos != null)
                return datos;
            else
                return datos;
        }
        else
        {
            Conexion conectar = new Conexion();
            string consulta = "select COUNT(*) TOTAL, s004sede.codsede, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento, concat_ws('',a.nombre,a.apellido) as asesor, s004sede.codsede from est_estra2instrumento_s004_sede s004sede inner join ins_sede s on s.codigo = s004sede.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento inner join est_asesorcoordinador ac on ac.codigo=s004sede.codasesorcoordinador inner join est_asesor a on a.codigo=ac.codasesor  where s004sede.codsede=@codsede and  s004sede.estrategia = @estrategia and extract(year from s004sede.fechaelaboracion)=@anio group by s004sede.codsede, s004sede.codsede, s.nombre,  i.nombre, m.nombre, d.nombre, concat_ws('',a.nombre,a.apellido) order by s004sede.codsede";
            //string consulta = "select s004sede.codigo, s004sede.nombresesion, s004sede.fechaelaboracion, s004sede.momento, s004sede.sesion, s004sede.jornada, s004sede.codsede, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento, concat_ws('',a.nombre,a.apellido) as asesor from est_estra2instrumento_s004_sede s004sede inner join ins_sede s on s.codigo = s004sede.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento inner join est_asesorcoordinador ac on ac.codigo=s004sede.codasesorcoordinador inner join est_asesor a on a.codigo=ac.codasesor  where  s004sede.estrategia = @estrategia and s004sede.codsede = @codsede and extract(year from s004sede.fechaelaboracion)=@anio";
            conectar.CrearComando(consulta);
            //conectar.AsignarParametroCadena("@codAsesor", codAsesor);
            conectar.AsignarParametroCadena("@estrategia", estrategia);
            conectar.AsignarParametroCadena("@codsede", codsede);
            //conectar.AsignarParametroCadena("@momento", momento);
            //conectar.AsignarParametroCadena("@sesion", sesion);
            //conectar.AsignarParametroCadena("@jornada", jornada);
            conectar.AsignarParametroCadena("@anio", anio);
            DataTable datos = conectar.traerdata();
            if (datos != null)
                return datos;
            else
                return datos;
        }
        
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
    public DataTable cargarListadoMemoriasS004SedesReporte(string codasesorcoordinador, string estrategia, string momento, string sesion, string offset, string limit, int jornada, string anio)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004sede.codigo, s004sede.codasesorcoordinador,s004sede.nombresesion, s004sede.fechaelaboracion, s004sede.momento, s004sede.sesion, s004sede.jornada, s004sede.codsede, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estra2instrumento_s004_sede s004sede inner join ins_sede s on s.codigo = s004sede.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004sede.codasesorcoordinador=@codasesorcoordinador and s004sede.estrategia = @estrategia and s004sede.momento = @momento and s004sede.sesion = @sesion and extract(year from s004sede.fechaelaboracion)=@anio and s004sede.jornada = " + jornada + " offset @offset limit @limit";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        conectar.AsignarParametroCadena("@momento", momento);
        conectar.AsignarParametroCadena("@sesion", sesion);
        conectar.AsignarParametroCadena("@offset", offset);
        conectar.AsignarParametroCadena("@limit", limit);
        conectar.AsignarParametroCadena("@anio", anio);
        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return datos;
    }
    public DataTable cargarListadoMemoriasCountSedesReporte(string codasesorcoordinador, string estrategia, string momento, string sesion, string jornada, string anio)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004sede.codigo, s004sede.codasesorcoordinador,s004sede.nombresesion, s004sede.fechaelaboracion, s004sede.momento, s004sede.sesion, s004sede.jornada, s004sede.codsede, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estra2instrumento_s004_sede s004sede inner join ins_sede s on s.codigo = s004sede.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004Sede.codasesorcoordinador=@codasesorcoordinador and s004sede.estrategia = @estrategia and s004sede.momento = @momento and s004sede.sesion = @sesion and s004sede.jornada = @jornada and extract(year from s004sede.fechaelaboracion)=@anio";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        conectar.AsignarParametroCadena("@momento", momento);
        conectar.AsignarParametroCadena("@sesion", sesion);
        conectar.AsignarParametroCadena("@jornada", jornada);
        conectar.AsignarParametroCadena("@anio", anio);
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

public Boolean agregarArchivoRespositorioEstrategia1EspacioApropiacion(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string actividad, string codespacioapro)
{
    Conexion conector = new Conexion();
    string consulta = "";


    consulta = "INSERT INTO est_repositorioasesor_espaciosapropiacion (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,actividad,codespacioapro) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@actividad,@codespacioapro)";


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
    conector.AsignarParametroCadena("@codespacioapro", codespacioapro);
    bool resp = conector.guardadata();
    return resp;
}

public Boolean agregarArchivoRespositorioEstrategia1Preestructurados(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string actividad, string codpreestructurados)
{
    Conexion conector = new Conexion();
    string consulta = "";


    consulta = "INSERT INTO est_repositorioasesor_preestructurados (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,actividad,codpreestructurados) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@actividad,@codpreestructurados)";


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
    conector.AsignarParametroCadena("@codpreestructurados", codpreestructurados);
    bool resp = conector.guardadata();
    return resp;
}

public Boolean agregarArchivoRespositorioEstrategia1JornadaFormacion(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string actividad, string codjornadasformacion)
{
    Conexion conector = new Conexion();
    string consulta = "";


    consulta = "INSERT INTO est_repositoriocoordinador_jornadaformacion (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,actividad,codjornadaformacion) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@actividad,@codjornadasformacion)";


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
    conector.AsignarParametroCadena("@codjornadasformacion", codjornadasformacion);
    bool resp = conector.guardadata();
    return resp;
}

public Boolean agregarArchivoRespositorioEstrategia1Asesorbitacora6(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string actividad, string codestrabitacora6)
{
    Conexion conector = new Conexion();
    string consulta = "";


    consulta = "INSERT INTO est_repositorioasesor_bitacora6 (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,actividad,codestrabitacora6) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@actividad,@codestrabitacora6)";


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
    conector.AsignarParametroCadena("@codestrabitacora6", codestrabitacora6);
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

    public Boolean agregarArchivoRespositorioCajasHerramientas(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "";


        consulta = "INSERT INTO est_estra2cajadeherramientas (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,actividad) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@actividad)";


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
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean agregarArchivoRespositorioPublicaciones(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string actividad, string tipo)
    {
        Conexion conector = new Conexion();
        string consulta = "";


        consulta = "INSERT INTO est_estra1publicaciones_guias (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,actividad,tipo) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@actividad,@tipo)";


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
        conector.AsignarParametroCadena("@tipo", tipo);
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

     public DataTable cargarEvidenciasEstrategia1AsesorEspaciosApropiacion(string codespacioapro)
     {
         Conexion conector = new Conexion();
         string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositorioasesor_espaciosapropiacion rc inner join usu_usuario u on u.cod=rc.codusuario WHERE codespacioapro=@codespacioapro  ORDER BY fechacreado ASC";
         conector.CrearComando(consulta);

         conector.AsignarParametroCadena("@codespacioapro", codespacioapro);
         DataTable resp = conector.traerdata();
         if (resp != null)
             return resp;
         else
             return null;

     }

     public DataTable cargarEvidenciasEstrategia1AsesorPreestructurados(string codpreestructurados)
     {
         Conexion conector = new Conexion();
         string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositorioasesor_preestructurados rc inner join usu_usuario u on u.cod=rc.codusuario WHERE codpreestructurados=@codpreestructurados  ORDER BY fechacreado ASC";
         conector.CrearComando(consulta);

         conector.AsignarParametroCadena("@codpreestructurados", codpreestructurados);
         DataTable resp = conector.traerdata();
         if (resp != null)
             return resp;
         else
             return null;

     }

     public DataTable cargarEvidenciasEstrategia1CoordJornadaFormacion(string codjornadaformacion)
     {
         Conexion conector = new Conexion();
         string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoordinador_jornadaformacion rc inner join usu_usuario u on u.cod=rc.codusuario WHERE codjornadaformacion=@codjornadaformacion  ORDER BY fechacreado ASC";
         conector.CrearComando(consulta);

         conector.AsignarParametroCadena("@codjornadaformacion", codjornadaformacion);
         DataTable resp = conector.traerdata();
         if (resp != null)
             return resp;
         else
             return null;

     }

     public DataTable cargarEvidenciasEstrategia1Asesorbitacora6(string codestrabitacora6)
     {
         Conexion conector = new Conexion();
         string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositorioasesor_bitacora6 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE codestrabitacora6=@codestrabitacora6  ORDER BY fechacreado ASC";
         conector.CrearComando(consulta);

         conector.AsignarParametroCadena("@codestrabitacora6", codestrabitacora6);
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

     public DataTable cargarEvidenciasCajasHerramientas()
     {
         Conexion conector = new Conexion();
         string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_estra2cajadeherramientas rc inner join usu_usuario u on u.cod=rc.codusuario ORDER BY fechacreado ASC";
         conector.CrearComando(consulta);

         DataTable resp = conector.traerdata();
         if (resp != null)
             return resp;
         else
             return null;

     }

     public DataTable cargarEvidenciasPublicaciones(string tipo)
     {
         Conexion conector = new Conexion();
         string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_estra1publicaciones_guias rc inner join usu_usuario u on u.cod=rc.codusuario WHERE rc.tipo=@tipo ORDER BY fechacreado ASC";
         conector.CrearComando(consulta);
         conector.AsignarParametroCadena("@tipo", tipo);
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
    public DataTable cargarEvidenciasEstrategiaS004SedesxAsesorxActividad(string codusuario, string actividad, string anio)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositorioasesor_s004Sedes rc inner join usu_usuario u on u.cod=rc.codusuario WHERE codusuario=@codusuario and actividad=@actividad and extract(year from rc.fechacreado)=@anio  ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@actividad", actividad);
        conector.AsignarParametroCadena("@anio", anio);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarEvidenciasEstrategiaS004SedesxCodInstrumentoxActividad(string codsede, string actividad)
    {
        if (codsede == "Todos")
        {
            Conexion conector = new Conexion();
            string consulta = "SELECT count(*) total FROM est_repositorioasesor_s004Sedes rc inner join usu_usuario u on u.cod=rc.codusuario inner join est_estra2instrumento_s004_sede s004 on s004.codigo=rc.codinstrumento where rc.actividad=@actividad";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@actividad", actividad);
            DataTable resp = conector.traerdata();
            if (resp != null)
                return resp;
            else
                return null;
        }
        else
        {
            Conexion conector = new Conexion();
            string consulta = "SELECT count(*) total FROM est_repositorioasesor_s004Sedes rc inner join usu_usuario u on u.cod=rc.codusuario inner join est_estra2instrumento_s004_sede s004 on s004.codigo=rc.codinstrumento where s004.codsede=@codsede and rc.actividad=@actividad";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@codsede", codsede);
            conector.AsignarParametroCadena("@actividad", actividad);
            DataTable resp = conector.traerdata();
            if (resp != null)
                return resp;
            else
                return null;
        }

       

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

    public Boolean borrarEvidenciaEstrategiaS004SedesxCodInstrumento(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositorioasesor_s004sedes WHERE codinstrumento=@codigo ";
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
    public DataTable cargarGruposInvestigacionDocentexSede(string codsede)
    {
        if (codsede == "Todos")
        {
            Conexion conector = new Conexion();
            string consulta = "select ps.codigo as codgrupo, i.nombre as nominstitucion, s.nombre as nomsede, ps.nombregrupo, ac.codigo as codasesorcoordinador, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, m.nombre as nommunicipio, d.nombre as nomdepartamento from pro_grupoinvestigaciondocentes ps left join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento order by a.apellido asc;";
            conector.CrearComando(consulta);
            DataTable resp = conector.traerdata();
            if (resp != null)
                return resp;
            else
                return null;
        }
        else
        {
            Conexion conector = new Conexion();
            string consulta = "select ps.codigo as codgrupo, i.nombre as nominstitucion, s.nombre as nomsede, ps.nombregrupo, ac.codigo as codasesorcoordinador, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, m.nombre as nommunicipio, d.nombre as nomdepartamento from pro_grupoinvestigaciondocentes ps left join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where ps.codsede=@codsede order by a.apellido asc;";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@codsede", codsede);
            DataTable resp = conector.traerdata();
            if (resp != null)
                return resp;
            else
                return null;
        }
       

    }

    public DataTable cargarGruposInvestigacionDocentexAsesorxSede(string codsede, string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "select ps.codigo as codgrupo, i.nombre as nominstitucion, s.nombre as nomsede, ps.nombregrupo, ac.codigo as codasesorcoordinador, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, m.nombre as nommunicipio, d.nombre as nomdepartamento from pro_grupoinvestigaciondocentes ps left join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where ps.codasesorcoordinador=@codasesorcoordinador and ps.codsede=@codsede order by a.apellido asc;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@codsede", codsede);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarGruposInvestigacionDocentexAsesorxAnio(string codasesorcoordinador, string anio)
    {
        Conexion conector = new Conexion();
        string consulta = "select ps.codigo as codgrupo, i.nombre as nominstitucion, s.nombre as nomsede, ps.nombregrupo, ac.codigo as codasesorcoordinador, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, m.nombre as nommunicipio, d.nombre as nomdepartamento from pro_grupoinvestigaciondocentes ps left join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where ps.codasesorcoordinador=@codasesorcoordinador and extract(year from ps.fechacreacion)=@anio order by a.apellido asc;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@anio", anio);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarGruposInvestigacionDocentexSedexAnio(string codsede, string anio)
    {
        if (codsede == "Todos")
        {
            Conexion conector = new Conexion();
            string consulta = "select count (*) as total, i.nombre as nominstitucion, s.nombre as nomsede, m.nombre as nommunicipio, d.nombre as nomdepartamento from pro_grupoinvestigaciondocentes ps left join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where extract(year from ps.fechacreacion)=@anio group by i.nombre, s.nombre, m.nombre, d.nombre;";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@anio", anio);
            DataTable resp = conector.traerdata();
            if (resp != null)
                return resp;
            else
                return null;
        }
        else
        {
            Conexion conector = new Conexion();
            string consulta = "select ps.codigo as codgrupo, i.nombre as nominstitucion, s.nombre as nomsede, ps.nombregrupo, ac.codigo as codasesorcoordinador, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, m.nombre as nommunicipio, d.nombre as nomdepartamento from pro_grupoinvestigaciondocentes ps left join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where ps.codsede=@codsede and extract(year from ps.fechacreacion)=@anio order by a.apellido asc;";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@codsede", codsede);
            conector.AsignarParametroCadena("@anio", anio);
            DataTable resp = conector.traerdata();
            if (resp != null)
                return resp;
            else
                return null;
        }

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
        string consulta = "select d.cod as coddepartamento, m.cod as codmunicipio, i.codigo as codinstitucion, s.codigo as codsede, ps.codigo as codgrupoinvestigaciondocentes, ps.codlineainvestigacion, ps.nombregrupo from pro_grupoinvestigaciondocentes ps inner join ins_sede s on ps.codsede=s.codigo inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where ps.codigo=@grupoinvestigaciondocentes";
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

    public DataTable cargarTodoGrupoInvestigacionSedesSeleccioandos()
    {
        Conexion conector = new Conexion();
        string consulta = "select * from pro_grupoinvestigaciondocentes_selec";
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

    public DataTable cargarInstrmentoS003_Estrategia1(string codasesorcoordinador, string offset, string limit)
    {
        Conexion conector = new Conexion();
        string consulta = "select s003.*, ps.nombregrupo, d.nombre as departamento, m.nombre as municipio, i.nombre as institucion, s.nombre as sede, ps.nombregrupo from est_estra1instrumento_s003 s003 inner join pro_proyectosede ps on ps.codigo=s003.codproyectosede inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where ps.codasesorcoordinador=@codasesorcoordinador order by s003.codigo desc offset @offset limit @limit";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
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

    public DataTable cargarInstrmentoS003Count_Estrategia1(string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "select s003.*, ps.nombregrupo, d.nombre as departamento, m.nombre as municipio, i.nombre as institucion, s.nombre as sede from est_estra1instrumento_s003 s003 inner join pro_proyectosede ps on ps.codigo=s003.codproyectosede inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where ps.codasesorcoordinador=@codasesorcoordinador ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
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

    public bool eliminarS003_Estrategia1(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1instrumento_s003 WHERE codigo = @codigo;";
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

    public DataRow proloadestras003_Estrategia1(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from est_estra1instrumento_s003 where  codigo=@codigo";
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
    public DataTable cargarMesadeTrabajoxAsesorxSede(string codsede)
    {
        if (codsede == "Todos")
        {
            Conexion conector = new Conexion();
            string consulta = "select ps.codigo as codgrupo, i.nombre as nominstitucion, s.nombre as nomsede, ps.nombregrupo, ac.codigo as codasesorcoordinador, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, m.nombre as nommunicipio, d.nombre as nomdepartamento from pro_mesadetrabajo ps left join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento order by a.apellido asc;";
            conector.CrearComando(consulta);
            DataTable resp = conector.traerdata();
            if (resp != null)
                return resp;
            else
                return null;
        }
        else
        {
            Conexion conector = new Conexion();
            string consulta = "select ps.codigo as codgrupo, i.nombre as nominstitucion, s.nombre as nomsede, ps.nombregrupo, ac.codigo as codasesorcoordinador, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, m.nombre as nommunicipio, d.nombre as nomdepartamento from pro_mesadetrabajo ps left join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where ps.codsede=@codsede order by a.apellido asc;";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@codsede", codsede);
            DataTable resp = conector.traerdata();
            if (resp != null)
                return resp;
            else
                return null;
        }

    }
    public DataTable cargarMesadeTrabajoxAsesorxAnio(string codasesorcoordinador, string anio)
    {
        Conexion conector = new Conexion();
        string consulta = "select ps.codigo as codgrupo, i.nombre as nominstitucion, s.nombre as nomsede, ps.nombregrupo, ac.codigo as codasesorcoordinador, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, m.nombre as nommunicipio, d.nombre as nomdepartamento from pro_mesadetrabajo ps left join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where ps.codasesorcoordinador=@codasesorcoordinador and extract(year from ps.fechacreacion)=@anio order by a.apellido asc;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@anio", anio);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarMesadeTrabajoxSedexAnio(string codsede, string anio)
    {
        if (codsede == "Todos")
        {
            Conexion conector = new Conexion();
            string consulta = "select count (*) total, i.nombre as nominstitucion, s.nombre as nomsede, m.nombre as nommunicipio, d.nombre as nomdepartamento from pro_mesadetrabajo ps left join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where  extract(year from ps.fechacreacion)=@anio group by i.nombre, s.nombre, m.nombre, d.nombre;";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@anio", anio);
            DataTable resp = conector.traerdata();
            if (resp != null)
                return resp;
            else
                return null;
        }
        else
        {
            Conexion conector = new Conexion();
            string consulta = "select ps.codigo as codgrupo, i.nombre as nominstitucion, s.nombre as nomsede, ps.nombregrupo, ac.codigo as codasesorcoordinador, CONCAT_WS(' ',a.nombre,a.apellido) as nomasesor, m.nombre as nommunicipio, d.nombre as nomdepartamento from pro_mesadetrabajo ps left join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where ps.codsede=@codsede and extract(year from ps.fechacreacion)=@anio order by a.apellido asc;";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@codsede", codsede);
            conector.AsignarParametroCadena("@anio", anio);
            DataTable resp = conector.traerdata();
            if (resp != null)
                return resp;
            else
                return null;
        }

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
        string consulta = "select d.cod as coddepartamento, m.cod as codmunicipio, i.codigo as codinstitucion, s.codigo as codsede, ps.codigo as codmesadetrabajo, ps.nombregrupo from pro_mesadetrabajo ps inner join ins_sede s on ps.codsede=s.codigo inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where ps.codigo=@codmesadetrabajo";
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
        string consulta = "select ps.codigo as codmesadetrabajo, ps.codasesorcoordinador, concat_ws(' ',a.nombre,a.apellido) as nombre, a.identificacion from pro_mesadetrabajo ps inner join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor where ps.codigo=@codmesadetrabajo ";
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

        consulta = "INSERT INTO est_repositoriocoord_g006 (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,codinstrumento) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@codinstrumento)";


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
    public Boolean agregarArchivoRespositorioEntregaMaterialEstra1(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO est_repositorioasesor_g006_estra1 (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,codinstrumento) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@codinstrumento)";


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

    public Boolean agregarArchivoGrupoDocentesEstra2(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string codinstrumento, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO pro_grupoinvestigaciondocentes_evi (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,codgrupodocente,actividad) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@codinstrumento,@actividad)";


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

    public Boolean agregarArchivoSesionVirtualEstra2(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string actividad, string sesion)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO est_repositoriocoord_sesionvirt (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,sesion,actividad) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@sesion,@actividad)";


        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroDouble("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fechacreado);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@actividad", actividad);


        bool resp = conector.guardadata();
        return resp;
    }
    
    public Boolean agregarArchivoRespositorioEntregaMaterialEstra4(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO est_repositorioasesor_g006_estra4 (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,codinstrumento) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@codinstrumento)";


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
    public DataTable cargarEvidenciasEntregaMaterial(string codinstrumento, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoord_g006 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE rc.codinstrumento=@codinstrumento and codusuario=@codusuario ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarEvidenciasEntregaMaterialI(string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoord_g006 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE rc.codinstrumento=@codinstrumento  ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarEvidenciasEntregaMaterialEstra1(string codinstrumento, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositorioasesor_g006_estra1 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE rc.codinstrumento=@codinstrumento and codusuario=@codusuario ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarEvidenciasGrupoDocentes(string codinstrumento, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM pro_grupoinvestigaciondocentes_evi rc inner join usu_usuario u on u.cod=rc.codusuario WHERE rc.codgrupodocente=@codinstrumento and codusuario=@codusuario ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarEvidenciasSesionVirtualEstra2(string sesion, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoord_sesionvirt rc inner join usu_usuario u on u.cod=rc.codusuario WHERE rc.sesion=@sesion and codusuario=@codusuario ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarEvidenciasSesionVirtualEstra2I(string sesion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoord_sesionvirt rc inner join usu_usuario u on u.cod=rc.codusuario WHERE rc.sesion=@sesion ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@sesion", sesion);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarEvidenciasEntregaMaterialEstra4(string codinstrumento, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositorioasesor_g006_estra4 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE rc.codinstrumento=@codinstrumento and codusuario=@codusuario ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarEvidenciasEntregaMaterialEstra4I(string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositorioasesor_g006_estra4 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE rc.codinstrumento=@codinstrumento ORDER BY fechacreado ASC";
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
        String consulta = "SELECT * FROM est_repositoriocoord_g006 WHERE cod=@cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;

    }
    
    public DataRow buscarEvidenciaEntregaMaterialEstra1(string cod)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_repositorioasesor_g006_estra1 WHERE cod=@cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public DataRow buscarEvidenciaGrupoDocentes(string cod)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM pro_grupoinvestigaciondocentes_evi WHERE cod=@cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public DataRow buscarEvidenciaSesionVirtualEstra2(string cod)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_repositoriocoord_sesionvirt WHERE cod=@cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public DataRow buscarEvidenciaEntregaMaterialEstra4(string cod)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_repositorioasesor_g006_estra4 WHERE cod=@cod;";
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
        string consulta = "DELETE FROM est_repositoriocoord_g006 WHERE cod=@cod ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean borrarEvidenciaEntregaMaterialEstra1(String cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositorioasesor_g006_estra1 WHERE cod=@cod ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean borrarEvidenciaGrupoDocentes(String cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM pro_grupoinvestigaciondocentes_evi WHERE cod=@cod ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean borrarEvidenciaSesionVirtualEstra2(String cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositoriocoord_sesionvirt WHERE cod=@cod ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean borrarEvidenciaEntregaMaterialEstra4(String cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositorioasesor_g006_estra4 WHERE cod=@cod ";
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

    public DataRow loadSelectInstrumentog006Estra1(string codigo)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s.codigo as codigosede, s.nombre as nombresede, i.codigo as codigoinstitucion, i.nombre as nombreinstitucion, m.cod as codigomunicipio, m.nombre as nombremunicipio, d.cod as codigodepartamento, d.nombre as nombredepartamento from est_estra1instrumento_g006 g006 inner join ins_sede s on s.codigo = g006.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where g006.codigo = @codigo";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codigo", codigo);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return dato;
    }

    public DataRow loadSelectInstrumentog006Estra4(string codigo)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s.codigo as codigosede, s.nombre as nombresede, i.codigo as codigoinstitucion, i.nombre as nombreinstitucion, m.cod as codigomunicipio, m.nombre as nombremunicipio, d.cod as codigodepartamento, d.nombre as nombredepartamento from est_estra4instrumento_g006 g006 inner join ins_sede s on s.codigo = g006.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where g006.codigo = @codigo";
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

    //public DataTable cargarTotalEvidenciasEstrategiaConActividad(string momento, string sesion, string estrategia, string actividad, string codusuario)
    //{
    //    Conexion conector = new Conexion();
    //    string consulta = "SELECT rp.*, us.pnombre , us.papellido FROM est_repositoriocoordinador rp INNER JOIN usu_usuario us ON us.cod = rp.codusuario WHERE momento=@momento and sesion=@sesion and estrategia=@estrategia and actividad=@actividad and codusuario=@codusuario";
    //    conector.CrearComando(consulta);
    //    conector.AsignarParametroCadena("@momento", momento);
    //    conector.AsignarParametroCadena("@sesion", sesion);
    //    conector.AsignarParametroCadena("@estrategia", estrategia);
    //    conector.AsignarParametroCadena("@actividad", actividad);
    //    conector.AsignarParametroCadena("@codusuario", codusuario);

    //    DataTable resp = conector.traerdata();
    //    if (resp != null)
    //        return resp;
    //    else
    //        return null;

    //}

    //public DataTable cargarCoordinadoresxEstrategia(string estrategia)
    //{
    //    Conexion conector = new Conexion();
    //    string consulta = "select u.cod, concat_ws(' ',c.nombre,c.apellido) as nombre from est_coordinador c inner join usu_usuario u on CAST(u.identificacion as bigint) =c.identificacion inner join est_estracoordinador ec on ec.codcoordinador=c.codigo where ec.codestrategia = @estrategia";
    //    conector.CrearComando(consulta);
    //    conector.AsignarParametroCadena("@estrategia", estrategia);

    //    DataTable resp = conector.traerdata();
    //    if (resp != null)
    //        return resp;
    //    else
    //        return null;

    //}

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

    public DataTable cargarListadoMemoriasS004_2016Seguimiento(string codAsesor, string estrategia, string momento, string sesion, string anio)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004redt.codigo, s004redt.codredtematicasede, s004redt.nombresesion, rt.nombre, s004redt.fechaelaboracion, rts.consecutivogrupo, s004redt.momento, s004redt.sesion, rts.codsede, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estra2instrumento_s004_redt_2016 s004redt inner join rt_redtematicasede rts on rts.codigo = s004redt.codredtematicasede inner join rt_redtematica rt on rt.codigo = rts.codredtematica inner join ins_sede s on s.codigo = rts.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004redt.codasesorcoordinador = @codAsesor and s004redt.estrategia = @estrategia and s004redt.momento = @momento and s004redt.sesion = @sesion and extract(year from s004redt.fechaelaboracion)=@anio";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codAsesor", codAsesor);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        conectar.AsignarParametroCadena("@momento", momento);
        conectar.AsignarParametroCadena("@sesion", sesion);
        conectar.AsignarParametroCadena("@anio", anio);
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
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoordinador rc inner join usu_usuario u on u.cod=rc.codusuario WHERE estrategia=@estrategia and codusuario=@codusuario and momento is null and sesion is null ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarEvidenciasEstrategiaplanxActividad(string estrategia, string codusuario, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoordinador rc inner join usu_usuario u on u.cod=rc.codusuario WHERE estrategia=@estrategia and codusuario=@codusuario and actividad=@actividad and momento is null and sesion is null ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@actividad", actividad);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarEvidenciasEstrategiaplanxActividadSeguimiento(string estrategia, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoordinador rc inner join usu_usuario u on u.cod=rc.codusuario WHERE estrategia=@estrategia and codusuario=@codusuario and (actividad='1' or actividad='2' or actividad='3') and momento is null and sesion is null ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarNombresRedesTematicas(string codasesorcoordinador, string anio)
    {
        Conexion conector = new Conexion();
        string consulta = "select rts.codigo as codredtematicasede, rts.fechacreacion, rts.codasesorcoordinador, concat_ws(' ',a.nombre,a.apellido) as asesor, d.nombre as departamento, m.nombre as municipio, concat_ws(' ',rt.nombre,rts.consecutivogrupo) as redtematica, i.nombre as institucion, s.nombre as sede, rts.aniored, m.coddepartamento, s.codmunicipio, s.codinstitucion, rts.codsede  from rt_redtematica rt inner join rt_redtematicasede rts on rt.codigo=rts.codredtematica inner join ins_sede s on s.codigo=rts.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento inner join est_asesorcoordinador ac on ac.codigo=rts.codasesorcoordinador inner join est_asesor a on a.codigo=ac.codasesor where rts.codasesorcoordinador=@codasesorcoordinador and aniored=@anio order by rts.codigo desc";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@anio", anio);
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

    public DataTable cargarTablaRedTematicaTodo()
    {
        Conexion conector = new Conexion();
        string consulta = "select rt.codigo, rt.codsede, rt.codasesorcoordinador, rt.aniored, concat_ws(' ', r.nombre, rt.consecutivogrupo) as red from rt_redtematicasede rt inner join rt_redtematica r on r.codigo=rt.codredtematica";
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

    public DataTable listarBitacoraSeisSupervision(string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT b6.*, d.nombre as departamento,m.nombre as municipio, i.nombre as institucion, s.nombre as sede, ps.nombregrupo FROM est_estra1bitacora6 b6 inner join pro_proyectosede ps on ps.codigo=b6.codproyectosede inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento WHERE ps.codasesorcoordinador=@codasesorcoordinador ORDER BY b6.fechacreacion DESC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable listarBitacoraCincoxAsesorxMomento(string codasesorcoordinador, string momento, string anio)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT b5.*, d.nombre as departamento,m.nombre as municipio, i.nombre as institucion, s.nombre as sede, ps.nombregrupo FROM est_estra1bitacora5 b5 inner join pro_proyectosede ps on ps.codigo=b5.codproyecto inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento WHERE ps.codasesorcoordinador=@codasesorcoordinador and b5.momento=@momento  ORDER BY b5.fechacreado ASC";
        //and extract(year from b5.fechacreado)=@anio
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@momento", momento);
        //conector.AsignarParametroCadena("@anio", anio);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataRow loadBitacoraSeis(string codigo)
    {
        Conexion conector = new Conexion();
        string sql = "SELECT * FROM est_estra1bitacora6 WHERE codigo = @codigo ";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codigo", codigo);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return resp;

    }

    public DataTable cargarPrimerTrayectobitacora6(string codestraunobitacoraseis)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from est_estra1bitacora6_detalle where codestraunobitacoraseis=@codestraunobitacoraseis order by codigo ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestraunobitacoraseis", codestraunobitacoraseis);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarSegundoTrayectobitacora6(string codestraunobitacoraseis)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from est_estra1bitacora6_detalle_2 where codestraunobitacoraseis=@codestraunobitacoraseis order by codigo ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestraunobitacoraseis", codestraunobitacoraseis);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarTercerTrayectobitacora6(string codestraunobitacoraseis)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from est_estra1bitacora6_detalle_3 where codestraunobitacoraseis=@codestraunobitacoraseis order by codigo ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestraunobitacoraseis", codestraunobitacoraseis);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarCuartoTrayectobitacora6(string codestraunobitacoraseis)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from est_estra1bitacora6_detalle_4 where codestraunobitacoraseis=@codestraunobitacoraseis order by codigo ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestraunobitacoraseis", codestraunobitacoraseis);
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

    public DataTable cargarCuartoTrayectobitacora5(string codestraunobitacoracinco)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from est_estra1bitacora5_detalle_4 where codestraunobitacoracinco=@codestraunobitacoracinco order by codigo ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestraunobitacoracinco", codestraunobitacoracinco);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarQuintoTrayectobitacora5(string codestraunobitacoracinco)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from est_estra1bitacora5_detalle_5 where codestraunobitacoracinco=@codestraunobitacoracinco order by codigo ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestraunobitacoracinco", codestraunobitacoracinco);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarSextoTrayectobitacora5(string codestraunobitacoracinco)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from est_estra1bitacora5_detalle_6 where codestraunobitacoracinco=@codestraunobitacoracinco order by codigo ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestraunobitacoracinco", codestraunobitacoracinco);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarSeptimoTrayectobitacora5(string codestraunobitacoracinco)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from est_estra1bitacora5_detalle_7 where codestraunobitacoracinco=@codestraunobitacoracinco order by codigo ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestraunobitacoracinco", codestraunobitacoracinco);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarOctavoTrayectobitacora5(string codestraunobitacoracinco)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from est_estra1bitacora5_detalle_8 where codestraunobitacoracinco=@codestraunobitacoracinco order by codigo ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestraunobitacoracinco", codestraunobitacoracinco);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public bool deleteDetalleBitacora6(string codestraunobitacoraseis)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora6_detalle WHERE codestraunobitacoraseis = @codestraunobitacoraseis;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestraunobitacoraseis", codestraunobitacoraseis);
        bool resp = conector.guardadata();
        return resp;
    }

    public bool deleteDetalleBitacora6_2(string codestraunobitacoraseis)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora6_detalle_2 WHERE codestraunobitacoraseis = @codestraunobitacoraseis;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestraunobitacoraseis", codestraunobitacoraseis);
        bool resp = conector.guardadata();
        return resp;
    }

    public bool deleteDetalleBitacora6_3(string codestraunobitacoraseis)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora6_detalle_3 WHERE codestraunobitacoraseis = @codestraunobitacoraseis;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestraunobitacoraseis", codestraunobitacoraseis);
        bool resp = conector.guardadata();
        return resp;
    }

    public bool deleteDetalleBitacora6_4(string codestraunobitacoraseis)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora6_detalle_4 WHERE codestraunobitacoraseis = @codestraunobitacoraseis;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestraunobitacoraseis", codestraunobitacoraseis);
        bool resp = conector.guardadata();
        return resp;
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

    public long deleteDetalleBitacora5_4(string codestraunobitacoracinco)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora5_detalle_4 WHERE codestraunobitacoracinco = @codestraunobitacoracinco;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestraunobitacoracinco", codestraunobitacoracinco);
        long resp = conector.guardadataid();
        return resp;
    }

    public long deleteDetalleBitacora5_5(string codestraunobitacoracinco)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora5_detalle_5 WHERE codestraunobitacoracinco = @codestraunobitacoracinco;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestraunobitacoracinco", codestraunobitacoracinco);
        long resp = conector.guardadataid();
        return resp;
    }

    public long deleteDetalleBitacora5_6(string codestraunobitacoracinco)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora5_detalle_6 WHERE codestraunobitacoracinco = @codestraunobitacoracinco;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestraunobitacoracinco", codestraunobitacoracinco);
        long resp = conector.guardadataid();
        return resp;
    }

    public long deleteDetalleBitacora5_7(string codestraunobitacoracinco)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora5_detalle_7 WHERE codestraunobitacoracinco = @codestraunobitacoracinco;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestraunobitacoracinco", codestraunobitacoracinco);
        long resp = conector.guardadataid();
        return resp;
    }

    public long deleteDetalleBitacora5_8(string codestraunobitacoracinco)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora5_detalle_8 WHERE codestraunobitacoracinco = @codestraunobitacoracinco;";
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
    public long deleteBitacora6(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora6 WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        long resp = conector.guardadataid();
        return resp;
    }
    public long deleteBitacora1(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora1 WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        long resp = conector.guardadataid();
        return resp;
    }

    public long deleteBitacora2(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora2 WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        long resp = conector.guardadataid();
        return resp;
    }
    public long deleteBitacora3(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora3 WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        long resp = conector.guardadataid();
        return resp;
    }
    public long deleteBitacora7(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora7 WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        long resp = conector.guardadataid();
        return resp;
    }

    public long deleteJornadaFormacion(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1jornadasformacion WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        long resp = conector.guardadataid();
        return resp;
    }

    public long deleteJornadaFormacionEvidencia(string codjornadaformacion)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositoriojornadasformacion_evi WHERE codjornadaformacion = @codjornadaformacion;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codjornadaformacion", codjornadaformacion);
        long resp = conector.guardadataid();
        return resp;
    }

    public long deletePreestructurados(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1preestructurados WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        long resp = conector.guardadataid();
        return resp;
    }

    public long deletePreestructuradosEvidencia(string codpreestructurados)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositorioasesor_preestructurados WHERE codpreestructurados = @codpreestructurados;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codpreestructurados", codpreestructurados);
        long resp = conector.guardadataid();
        return resp;
    }

    public long deleteEspacioApropiacion(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1espacioapropiacion WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        long resp = conector.guardadataid();
        return resp;
    }

    public long deleteParticipacionFerias(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1participantesferias WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        long resp = conector.guardadataid();
        return resp;
    }

    public long deleteParticipacionFeriasDocentes(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1participantesferiasdocentes WHERE codparticipantesferias = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        long resp = conector.guardadataid();
        return resp;
    }

    public long deleteS008(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1instrumento_s008 WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        long resp = conector.guardadataid();
        return resp;
    }

    public long deletePreguntasBitacora2(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora2pregunta WHERE codest_estra1bitacora2 = @codigo;";
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

    public long deleteEvidenciaBitacora6(string codestrabitacora6)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositorioasesor_bitacora6 WHERE codestrabitacora6 = @codestrabitacora6;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestrabitacora6", codestrabitacora6);
        long resp = conector.guardadataid();
        return resp;
    }

    public Boolean updateencabezadobitacora5(String codigo, string objetivoFinal, string nomTrayectoIndagacion, string dificultadesFortalezas, string principalesCaracteristicas, string importanciaInvestigacion, string importanciaIEP, string general, string especifico, string nomTrayectoIndagacion2, string nomTrayectoIndagacion3, string nomTrayectoIndagacion4, string nomTrayectoIndagacion5, string nomTrayectoIndagacion6, string nomTrayectoIndagacion7, string nomTrayectoIndagacion8)
    {
        Conexion conectar = new Conexion();
        string consulta = "UPDATE est_estra1bitacora5 SET objetivofinal=@objetivofinal, nomtrayectoindagacion=@nomtrayectoindagacion, dificultadesfortalezas=@dificultadesfortalezas, principalescaracteristicas=@principalescaracteristicas, importanciasinvestigacion=@importanciasinvestigacion, importanciaiep=@importanciaiep,general=@general,especifico=@especifico, nomtrayectoindagacion2=@nomtrayectoindagacion2, nomtrayectoindagacion3=@nomtrayectoindagacion3, nomtrayectoindagacion4=@nomtrayectoindagacion4, nomtrayectoindagacion5=@nomtrayectoindagacion5, nomtrayectoindagacion6=@nomtrayectoindagacion6, nomtrayectoindagacion7=@nomtrayectoindagacion7, nomtrayectoindagacion8=@nomtrayectoindagacion8 WHERE codigo=@codigo ";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codigo", codigo);
        conectar.AsignarParametroCadena("@objetivofinal", objetivoFinal);
        conectar.AsignarParametroCadena("@nomtrayectoindagacion", nomTrayectoIndagacion);
        conectar.AsignarParametroCadena("@nomtrayectoindagacion2", nomTrayectoIndagacion2);
        conectar.AsignarParametroCadena("@nomtrayectoindagacion3", nomTrayectoIndagacion3);
        conectar.AsignarParametroCadena("@nomtrayectoindagacion4", nomTrayectoIndagacion4);
        conectar.AsignarParametroCadena("@nomtrayectoindagacion5", nomTrayectoIndagacion5);
        conectar.AsignarParametroCadena("@nomtrayectoindagacion6", nomTrayectoIndagacion6);
        conectar.AsignarParametroCadena("@nomtrayectoindagacion7", nomTrayectoIndagacion7);
        conectar.AsignarParametroCadena("@nomtrayectoindagacion8", nomTrayectoIndagacion8);
        conectar.AsignarParametroCadena("@dificultadesfortalezas", dificultadesFortalezas);
        conectar.AsignarParametroCadena("@principalescaracteristicas", principalesCaracteristicas);
        conectar.AsignarParametroCadena("@importanciasinvestigacion", importanciaInvestigacion);
        conectar.AsignarParametroCadena("@importanciaiep", importanciaIEP);
        conectar.AsignarParametroCadena("@general", general);
        conectar.AsignarParametroCadena("@especifico", especifico);
        bool resp = conectar.guardadata();
        return resp;
    }
    public Boolean updateencabezadobitacora6(String codigo, string trayecto1, string trayecto2, string trayecto3, string trayecto4, string conclusion1, string conclusion2, string conclusion3, string conclusion4, string dificultades, string fortalezas, string caracteristicas, string acciones)
    {
        Conexion conectar = new Conexion();
        string consulta = "UPDATE est_estra1bitacora6 SET trayecto1=@trayecto1, trayecto2=@trayecto2, trayecto3=@trayecto3, trayecto4=@trayecto4, conclusion1=@conclusion1, conclusion2=@conclusion2,conclusion3=@conclusion3,conclusion4=@conclusion4, dificultades=@dificultades, fortalezas=@fortalezas, caracteristicas=@caracteristicas, acciones=@acciones WHERE codigo=@codigo ";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codigo", codigo);
        conectar.AsignarParametroCadena("@trayecto1", trayecto1);
        conectar.AsignarParametroCadena("@trayecto2", trayecto2);
        conectar.AsignarParametroCadena("@trayecto3", trayecto3);
        conectar.AsignarParametroCadena("@trayecto4", trayecto4);
        conectar.AsignarParametroCadena("@conclusion1", conclusion1);
        conectar.AsignarParametroCadena("@conclusion2", conclusion2);
        conectar.AsignarParametroCadena("@conclusion3", conclusion3);
        conectar.AsignarParametroCadena("@conclusion4", conclusion4);
        conectar.AsignarParametroCadena("@dificultades", dificultades);
        conectar.AsignarParametroCadena("@fortalezas", fortalezas);
        conectar.AsignarParametroCadena("@caracteristicas", caracteristicas);
        conectar.AsignarParametroCadena("@acciones", acciones);
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

    //public DataTable cargarProyectoSedexSedes(string codsede)
    //{
    //    Conexion conector = new Conexion();
    //    string consulta = "SELECT ps.*, concat_ws(' ', a.identificacion,'-',a.nombre,a.apellido)as asesor FROM pro_proyectosede ps inner join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor WHERE ps.codsede=@codsede ORDER BY fechacreacion DESC";
    //    conector.CrearComando(consulta);
    //    conector.AsignarParametroCadena("@codsede", codsede);

    //    DataTable resp = conector.traerdata();
    //    if (resp != null)
    //        return resp;
    //    else
    //        return null;

    //}

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

    public bool agregarGradoRedTematica(string codredtematicasede, string codgrado, string grupo)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO rt_redtematicagrados (codredtematicasede,codgrado, grupo) VALUES (@codredtematicasede,@codgrado,@grupo);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgrado", codgrado);
        conector.AsignarParametroCadena("@grupo", grupo);
        conector.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        bool resp = conector.guardadata();
        return resp;
    }

    public DataTable cargarGradosxRedTematica(string codredtematicasede)
    {
        Conexion conector = new Conexion();
        string consulta = "select rt.codigo,concat_ws(' ',g.nombre,'-',rt.grupo) as nombre from rt_redtematicagrados rt left join ins_grado g on g.codigo=rt.codgrado where rt.codredtematicasede=@codredtematicasede";
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

    public Boolean agregarArchivoRespositorioEspacioAproDocente(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string codevento, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO ep_feriasmunicipales_evento_evi (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,codevento,actividad) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@codevento,@actividad)";

        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroDouble("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fechacreado);
        conector.AsignarParametroCadena("@codevento", codevento);
        conector.AsignarParametroCadena("@actividad", actividad);

        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean agregarArchivoRespositorioEspacioApropiacion(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string codapropiacion, string actividad, string fechainicio, string fechafin, string horainicio, string horafin, string lugar, string nodocentes, string noestudiantes)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO ep_espaciosapropiacion_evi (codusuario, nombrearchivo, nombreguardado,contentType, ext,path,tamano,fechacreado,codapropiacion, actividad, fechainicio, fechafin, horainicio, horafin, lugar, nodocentes, noestudiantes) VALUES (@codusuario, @nombrearchivo, @nombreguardado, @contentType, @ext, @path, @tamano, @fechacreado, @codapropiacion, @actividad, @fechainicio, @fechafin, @horainicio, @horafin, @lugar, @nodocentes, @noestudiantes)";

        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroDouble("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fechacreado);
        conector.AsignarParametroCadena("@codapropiacion", codapropiacion);
        conector.AsignarParametroCadena("@actividad", actividad);

        conector.AsignarParametroCadena("@fechainicio", fechainicio);
        conector.AsignarParametroCadena("@fechafin", fechafin);
        conector.AsignarParametroCadena("@horainicio", horainicio);
        conector.AsignarParametroCadena("@horafin", horafin);
        conector.AsignarParametroCadena("@lugar", lugar);
        conector.AsignarParametroCadena("@nodocentes", nodocentes);
        conector.AsignarParametroCadena("@noestudiantes", noestudiantes);

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

    public DataTable cargarEvidenciasEspacioAproDocente(string codevento, string actividad, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM ep_feriasmunicipales_evento_evi rc inner join usu_usuario u on u.cod=rc.codusuario WHERE codevento=@codevento and actividad=@actividad and codusuario=@codusuario  ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codevento", codevento);
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

    public DataRow buscarEvidenciaEspacioAproDocente(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM ep_feriasmunicipales_evento_evi WHERE cod=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public DataRow buscarEvidenciaEspacioApropiacion(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM ep_espaciosapropiacion_evi WHERE cod=@codigo;";
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

    public Boolean borrarEvidenciaEspacioAproDocente(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM ep_feriasmunicipales_evento_evi WHERE cod=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean borrarEvidenciaEspacioApropiacion(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM ep_espaciosapropiacion_evi WHERE cod=@codigo ";
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
        string consulta = "select d.cod as coddepartamento, fm.codigo as codigo, fm.nombreferiamunicipal as nombreferiamunicipal, fm.numeroasistentes as numeroasistentes, fm.numerogrupos as numerogrupos, fm.fechaelaboracion as fechaelaboracion, fm.horaferia as horaferia, fm.horaferiafinal as horaferiafinal from ep_feriasmunicipales fm left join ep_municipiomatricula fmm on fmm.codferiamunicipal=fm.codigo inner join geo_departamentos d on d.cod=fm.coddepartamento where fm.codigo=@codferiamunicipal";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codferiamunicipal", codferiamunicipal);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public bool actualizarFeriaMunicipal(string coddepartamento, string nombreferiamunicipal, string numeroasistentes, string numerogrupos, string fechaelaboracion, string horaferia, string horaferiafinal, string codigo)
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
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();

    }
    public Boolean eliminarMunicipiosFeriaMunicipalxFeria(string codferiamunicipal)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM ep_municipiomatricula WHERE codferiamunicipal=@codferiamunicipal ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codferiamunicipal", codferiamunicipal);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarGruposFeriaMunicipalxFeria(string codferiamunicipal)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM ep_feriasmunicipales_grupos WHERE codferiamunicipal=@codferiamunicipal ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codferiamunicipal", codferiamunicipal);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarGruposFeriaMunicipalxGrupoxFeria(string codproyectosede, string codferiamunicipal)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM ep_feriasmunicipales_grupos WHERE codproyectosede=@codproyectosede and codferiamunicipal=@codferiamunicipal ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
        conector.AsignarParametroCadena("@codferiamunicipal", codferiamunicipal);
        bool resp = conector.guardadata();
        return resp;
    }
    public DataRow buscarProyectoSedexFeriaMunicipal(string codproyectosede, string codferiamunicipal)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from ep_feriasmunicipales_grupos where codproyectosede=@codproyectosede and codferiamunicipal=@codferiamunicipal";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codferiamunicipal", codferiamunicipal);
        conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
       
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public Boolean eliminarMunicipioFeriaMunicipal(string codmunicipiomatricula, string codferiamunicipal)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM ep_municipiomatricula WHERE codmunicipiomatricula=@codmunicipiomatricula and codferiamunicipal=@codferiamunicipal ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codmunicipiomatricula", codmunicipiomatricula);
        conector.AsignarParametroCadena("@codferiamunicipal", codferiamunicipal);
        bool resp = conector.guardadata();
        return resp;
    }

    public DataTable cargarListadoMemoriasS004Estra5(string codestracoordinador, string estrategia, string sesion, string offset, string limit)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004redt.codigo, s004redt.actividad, s004redt.fechaelaboracion, s004redt.fechaelaboracionini,  s004redt.sesion, s004redt.lugar, m.nombre as nombremunicipio, d.nombre as nombredepartamento  from est_estrainstrumento_s004coord s004redt inner join geo_municipios m on m.cod = s004redt.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004redt.codestracoordinador = @codestracoordinador and s004redt.estrategia = @estrategia and s004redt.sesion = @sesion offset @offset limit @limit";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        conectar.AsignarParametroCadena("@sesion", sesion);
        conectar.AsignarParametroCadena("@offset", offset);
        conectar.AsignarParametroCadena("@limit", limit);
        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return datos;
    }

    public DataTable cargarListadoMemoriasS004Estra5(string estrategia, string sesion, string offset, string limit)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004redt.codigo, s004redt.actividad, s004redt.fechaelaboracion, s004redt.fechaelaboracionini,  s004redt.sesion, s004redt.lugar, m.nombre as nombremunicipio, d.nombre as nombredepartamento  from est_estrainstrumento_s004coord s004redt inner join geo_municipios m on m.cod = s004redt.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004redt.estrategia = @estrategia and s004redt.sesion = @sesion offset @offset limit @limit";
        conectar.CrearComando(consulta);
        //conectar.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        conectar.AsignarParametroCadena("@sesion", sesion);
        conectar.AsignarParametroCadena("@offset", offset);
        conectar.AsignarParametroCadena("@limit", limit);
        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return datos;
    }

    public DataTable cargarListadoMemoriasCountS004Estra5(string codestracoordinador, string estrategia, string sesion)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004redt.actividad, s004redt.fechaelaboracion,  s004redt.sesion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estrainstrumento_s004coord s004redt inner join geo_municipios m on m.cod = s004redt.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004redt.codestracoordinador = @codestracoordinador and s004redt.estrategia = @estrategia and s004redt.sesion = @sesion";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        conectar.AsignarParametroCadena("@sesion", sesion);
        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return datos;
    }

    public DataTable cargarListadoMemoriasCountS004Estra5(string estrategia, string sesion)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004redt.actividad, s004redt.fechaelaboracion,  s004redt.sesion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estrainstrumento_s004coord s004redt inner join geo_municipios m on m.cod = s004redt.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004redt.estrategia = @estrategia and s004redt.sesion = @sesion";
        conectar.CrearComando(consulta);
        //conectar.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
        conectar.AsignarParametroCadena("@estrategia", estrategia);
        conectar.AsignarParametroCadena("@sesion", sesion);
        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return datos;
    }

    public DataRow insertestras004Estra5(string codmunicipio, string actividad, string descripcion, string sintesis, string producto, string recursos, string evaluacion, string fechaelaboracion, string codestracoordinador, string estrategia, string sesion, string lugar, string horainicio, string horafin, string fechaelaboracionini)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estrainstrumento_s004coord (codestracoordinador, actividad, descripcion, sintesis, producto, recursos, evaluacion, fechaelaboracion, estrategia, sesion, codmunicipio, lugar, horainicio, horafin, fechaelaboracionini) VALUES (@codestracoordinador, @actividad, @descripcion, @sintesis, @producto, @recursos, @evaluacion, @fechaelaboracion, @estrategia, @sesion, @codmunicipio, @lugar, @horainicio, @horafin, @fechaelaboracionini) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        conector.AsignarParametroCadena("@actividad", actividad);
        conector.AsignarParametroCadena("@descripcion", descripcion);
        conector.AsignarParametroCadena("@sintesis", sintesis);
        conector.AsignarParametroCadena("@producto", producto);

        conector.AsignarParametroCadena("@recursos", recursos);
        conector.AsignarParametroCadena("@evaluacion", evaluacion);
        conector.AsignarParametroCadena("@fechaelaboracion", fechaelaboracion);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@sesion", sesion);

        conector.AsignarParametroCadena("@lugar", lugar);
        conector.AsignarParametroCadena("@horainicio", horainicio);
        conector.AsignarParametroCadena("@horafin", horafin);
        conector.AsignarParametroCadena("@fechaelaboracionini", fechaelaboracionini);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public long procupdateestras004Estra5(string codigoestrategia, string actividad, string descripcion, string sintesis, string producto, string recursos, string evaluacion, string fechaelaboracion, string lugar, string horainicio, string horafin, string fechaelaboracionini, string codmunicipio)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estrainstrumento_s004coord SET actividad = @actividad, descripcion = @descripcion, sintesis=@sintesis, producto = @producto, recursos=@recursos, evaluacion=@evaluacion, fechaelaboracion=@fechaelaboracion, lugar=@lugar, horainicio=@horainicio, horafin=@horafin, fechaelaboracionini=@fechaelaboracionini, codmunicipio=@codmunicipio WHERE codigo = @codigoestrategia";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@actividad", actividad);
        conector.AsignarParametroCadena("@descripcion", descripcion);
        conector.AsignarParametroCadena("@sintesis", sintesis);
        conector.AsignarParametroCadena("@producto", producto);
        conector.AsignarParametroCadena("@recursos", recursos);
        conector.AsignarParametroCadena("@evaluacion", evaluacion);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);
        conector.AsignarParametroCadena("@fechaelaboracion", fechaelaboracion);
        conector.AsignarParametroCadena("@lugar", lugar);
        conector.AsignarParametroCadena("@horainicio", horainicio);
        conector.AsignarParametroCadena("@horafin", horafin);
        conector.AsignarParametroCadena("@fechaelaboracionini", fechaelaboracionini);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        long resp = conector.guardadataid();
        return resp;
    }

    public bool eliminarMemoriaS004Estra5(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estrainstrumento_s004coord WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();
    }

    public Boolean eliminarEvidenciasMemoriaS004Estra5(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositoriocoord_s004 WHERE codinstrumento=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public DataRow buscarCodAsistenciaEstra5(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT asist.* FROM est_estrainstrumento_s004coord s004 inner join est_estrainstrumento_s004coord_asist asist on asist.codestras004=s004.codigo WHERE s004.codigo = @codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow proloadestras004Estr5(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM est_estrainstrumento_s004coord WHERE codigo = @codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);


        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public Boolean agregarArchivoRespositorioEstra5_S004(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string codinstrumento, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO est_repositoriocoord_s004 (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,codinstrumento,actividad) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@codinstrumento,@actividad)";


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

    public DataTable cargarEvidenciasEstra5_S004(string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoord_s004 rc inner join usu_usuario u on u.cod=rc.codusuario WHERE codinstrumento=@codinstrumento ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataRow buscarEvidenciaEstra5_S004(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_repositoriocoord_s004 WHERE codigo=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public Boolean borrarEvidenciaEstra5_S004(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositoriocoord_s004 WHERE codigo=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public DataRow loadSelectInstrumentoEstra5_s004(string codigo)
    {
        Conexion conectar = new Conexion();
        string consulta = "select m.cod as codigomunicipio, m.nombre as nombremunicipio, d.cod as codigodepartamento, d.nombre as nombredepartamento from est_estrainstrumento_s004coord s004 inner join geo_municipios m on m.cod = s004.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004.codigo = @codigo";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codigo", codigo);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return dato;
    }

    public DataTable cargarListadoMemoriasS004_EspVirtuales(string codAsesor, string estrategia, string momento, string sesion, string offset, string limit)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004redt.*, rt.nombre,  rts.consecutivogrupo, rts.codsede, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estrainstrumento_s004_redt_ev s004redt inner join rt_redtematicasede rts on rts.codigo = s004redt.codredtematicasede inner join rt_redtematica rt on rt.codigo = rts.codredtematica inner join ins_sede s on s.codigo = rts.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004redt.codasesorcoordinador = @codAsesor and s004redt.estrategia = @estrategia and s004redt.momento = @momento and s004redt.sesion = @sesion offset @offset limit @limit";
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

    public DataTable cargarListadoMemoriasS004_EspVirtualesTodo(string codAsesor, string estrategia, string momento, string sesion)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004redt.*, rt.nombre,  rts.consecutivogrupo, rts.codsede, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estrainstrumento_s004_redt_ev s004redt inner join rt_redtematicasede rts on rts.codigo = s004redt.codredtematicasede inner join rt_redtematica rt on rt.codigo = rts.codredtematica inner join ins_sede s on s.codigo = rts.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004redt.codasesorcoordinador = @codAsesor and s004redt.estrategia = @estrategia and s004redt.momento = @momento and s004redt.sesion = @sesion ";
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

    public DataTable cargarListadoMemoriasCount_EspVirtual(string codAsesor, string estrategia, string momento, string sesion)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004redt.*,  rt.nombre, rts.consecutivogrupo, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estrainstrumento_s004_redt_ev s004redt inner join rt_redtematicasede rts on rts.codigo = s004redt.codredtematicasede inner join rt_redtematica rt on rt.codigo = rts.codredtematica inner join ins_sede s on s.codigo = rts.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004redt.codasesorcoordinador = @codAsesor and s004redt.estrategia = @estrategia and s004redt.momento = @momento and s004redt.sesion = @sesion";
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

    public bool eliminarMemoriaS004_EspVirtual(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estrainstrumento_s004_redt_ev WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();
    }

    public long procupdateestras004_EspVirtual(string codigoestrategia, string nombresesion, string temasesion, string fechaelaboracion, string nombrerelator, string horasesion, string horasesionfinal, string acompanamiento, string herramientas, string evaluacionsesion, string nohoras)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estrainstrumento_s004_redt_ev SET nombresesion = @nombresesion, temasesion = @temasesion, fechaelaboracion = @fechaelaboracion, nombrerelator=@nombrerelator, horasesion=@horasesion, horasesionfinal=@horasesionfinal, acompanamiento=@acompanamiento, herramientas=@herramientas, evaluacionsesion=@evaluacionsesion, nohoras=@nohoras WHERE codigo = @codigoestrategia";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombresesion", nombresesion);
        conector.AsignarParametroCadena("@temasesion", temasesion);
        
        conector.AsignarParametroCadena("@fechaelaboracion", fechaelaboracion);
        conector.AsignarParametroCadena("@nombrerelator", nombrerelator);
        conector.AsignarParametroCadena("@horasesion", horasesion);
        conector.AsignarParametroCadena("@horasesionfinal", horasesionfinal);
        conector.AsignarParametroCadena("@acompanamiento", acompanamiento);
        conector.AsignarParametroCadena("@herramientas", herramientas);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);
      
        conector.AsignarParametroCadena("@evaluacionsesion", evaluacionsesion);
        conector.AsignarParametroCadena("@nohoras", nohoras);
        
        long resp = conector.guardadataid();
        return resp;
    }

    public DataRow insertestras004_EspVirtual(string redtematica, string nombresesion, string temasesion, string fechaelaboracion, string nombrerelator, string horasesion, string horasesionfinal, string codestracoordinador, string acompanamiento, string herramientas, string evaluacionsesion, string estrategia, string momento, string sesion, string nohoras)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estrainstrumento_s004_redt_ev (codasesorcoordinador, nombresesion, codredtematicasede, temasesion,  fechaelaboracion, nombrerelator, horasesion, horasesionfinal, acompanamiento, herramientas, evaluacionsesion, estrategia, momento, sesion, nohoras) VALUES (@codestracoordinador,  @nombresesion, @redtematica, @temasesion, @fechaelaboracion, @nombrerelator, @horasesion, @horasesionfinal, @acompanamiento, @herramientas, @evaluacionsesion, @estrategia, @momento, @sesion, @nohoras) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
        conector.AsignarParametroCadena("@redtematica", redtematica);
        conector.AsignarParametroCadena("@nombresesion", nombresesion);
        conector.AsignarParametroCadena("@temasesion", temasesion);
        conector.AsignarParametroCadena("@fechaelaboracion", fechaelaboracion);

        conector.AsignarParametroCadena("@nombrerelator", nombrerelator);
        conector.AsignarParametroCadena("@horasesion", horasesion);
        conector.AsignarParametroCadena("@horasesionfinal", horasesionfinal);
        conector.AsignarParametroCadena("@acompanamiento", acompanamiento);
        conector.AsignarParametroCadena("@herramientas", herramientas);

        conector.AsignarParametroCadena("@evaluacionsesion", evaluacionsesion);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@nohoras", nohoras);
        
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow proloadestras004_EspVirtual(string codigoestra, string estrategia, string momento, string sesion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM est_estrainstrumento_s004_redt_ev WHERE codigo = @codigoestra and estrategia=@estrategia and momento=@momento and sesion=@sesion";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoestra", codigoestra);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);

        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow loadSelectInstrumentos004_EspVirtual(string codRedtematica)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s.codigo as codigosede, s.nombre as nombresede, i.codigo as codigoinstitucion, i.nombre as nombreinstitucion, m.cod as codigomunicipio, m.nombre as nombremunicipio, d.cod as codigodepartamento, d.nombre as nombredepartamento,rts.codigo as codigoredtematica,concat_ws(' ', rt.nombre,rts.consecutivogrupo) as redtematica from est_estrainstrumento_s004_redt_ev s004 inner join rt_redtematicasede rts on rts.codigo = s004.codredtematicasede inner join rt_redtematica rt on rts.codredtematica=rt.codigo inner join ins_sede s on s.codigo = rts.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004.codigo = @codRedtematica";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codRedtematica", codRedtematica);
        DataRow dato = conectar.traerfila();
        if (dato != null)
            return dato;
        else
            return dato;
    }

    public Boolean agregarArchivoRespositorioEstrategiaS004_EspVirtuales(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string codinstrumento, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO est_repositorioasesor_s004_ev (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,codinstrumento,actividad) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@codinstrumento,@actividad)";


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

    public DataTable cargarEvidenciasEstrategiaS004_EspVirtuales(string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositorioasesor_s004_ev rc inner join usu_usuario u on u.cod=rc.codusuario WHERE codinstrumento=@codinstrumento ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataRow buscarEvidenciaEstrategiaS004_EspVirtuales(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_repositorioasesor_s004_ev WHERE codigo=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public Boolean borrarEvidenciaEstrategiaS004_EspVirtuales(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositorioasesor_s004_ev WHERE codigo=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public DataRow buscarRegistroMemoriaS004_EspVirtuales(string codredtematicasede)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004redt.codigo, s004redt.codredtematicasede, s004redt.nombresesion, rt.nombre, s004redt.fechaelaboracion, rts.consecutivogrupo, s004redt.momento, s004redt.sesion, rts.codsede, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estrainstrumento_s004_redt_ev s004redt inner join rt_redtematicasede rts on rts.codigo = s004redt.codredtematicasede inner join rt_redtematica rt on rt.codigo = rts.codredtematica inner join ins_sede s on s.codigo = rts.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where s004redt.codredtematicasede = @codredtematicasede limit 1";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        DataRow asesorias = conectar.traerfila();
        if (asesorias != null)
            return asesorias;
        else
            return null;
    }

    public DataRow guardarEncabezado_EspVirtuales(string valFecha, string valtActividad, string valTema, string valFacilitador, string valhInicio, string valhFin, string codinstrumentos004)
    {
        Conexion conector = new Conexion();
        string sql = "INSERT INTO est_inasistenciasinstrumento_g001_ev (fecha, tipoactividad, tema, facilitador, horainicio, horafinal, codinstrumentos004) VALUES ( @valFecha, @valtActividad, @valTema, @valFacilitador, @valhInicio, @valhFin, @codinstrumentos004) RETURNING codigo";
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

    public bool guardarEstudianteInasistente_EspVirtuales(string codInasistencia, string codEstudiante)
    {

        Conexion conector = new Conexion();
        string sql = "INSERT INTO est_inasistenciasinstrumento_g001detalle_ev (codinasistenciainstrumento_g001, codestumatriculared) VALUES (@codInasistencia, @codEstudiante)";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codInasistencia", codInasistencia);
        conector.AsignarParametroCadena("@codEstudiante", codEstudiante);
        return conector.guardadata();

    }

    public DataTable listarBitacoraDosxMomentoxAnio(String codasesorcoordinador, string codmomento, string anio)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT eeb.*, pps.nombregrupo ,s.nombre as nombresede,i.nombre as nombreinstitucion,m.nombre as nombremunicipio,d.nombre as nombredepartamento FROM est_estra1bitacora2 eeb inner join pro_proyectosede pps on pps.codigo=eeb.codproyecto inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where pps.codasesorcoordinador=@codasesorcoordinador and eeb.momento=@codmomento  order by eeb.fechadiligenciamiento DESC";
        //and extract(year from eeb.fechadiligenciamiento)=@anio
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@codmomento", codmomento);
        //conector.AsignarParametroCadena("@anio", anio);
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

    public DataTable listarBitacoraTresxAsesorxMomento(String codasesorcoordinador, string codmomento, string anio)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT eeb.*, pps.nombregrupo ,s.nombre as nombresede,i.nombre as nombreinstitucion,m.nombre as nombremunicipio,d.nombre as nombredepartamento FROM est_estra1bitacora3 eeb inner join pro_proyectosede pps on pps.codigo=eeb.codproyecto inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where pps.codasesorcoordinador=@codasesorcoordinador and eeb.momento=@codmomento  order by eeb.fechaejecucion DESC";
        //and extract(year from eeb.fechaejecucion)=@anio
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@codmomento", codmomento);
        //conector.AsignarParametroCadena("@anio", anio);
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

    public DataRow buscarCodUsuarioxIDAsesor(string id)
    {
        Conexion conector = new Conexion();
        string sql = "select u.cod from est_asesor a inner join usu_usuario u on CAST(u.identificacion as bigint)=a.identificacion where a.identificacion=@id";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@id", id);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;

    }

    public DataRow buscarCodUsuarioxCodAsesorCoordinador(string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string sql = "select u.cod from est_asesor a inner join usu_usuario u on CAST(u.identificacion as bigint)=a.identificacion inner join est_asesorcoordinador ec on ec.codasesor=a.codigo where ec.codigo=@codasesorcoordinador";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;

    }

    public DataTable cargarDocentesxAnio(string codanio)
    {
        Conexion conector = new Conexion();
        string consulta = "select d.nombre as departamento, m.nombre as municipio, i.dane as daneinstitucion, i.nombre as institucion, s.dane as danesede, s.nombre as sede, doc.identificacion, concat_ws(' ',doc.nombre,doc.apellido) as nomdoc  from ins_gradodocente gd inner join ins_docente doc on doc.identificacion=gd.identificacion inner join ins_sede s on gd.codsede=s.codigo inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where gd.codanio=@codanio";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codanio", codanio);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarInasistenciasEspVirtual(string codintrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from est_inasistenciasinstrumento_g001_ev where codinstrumentos004=@codintrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codintrumento", codintrumento);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarInasistenciasEspPresencial(string codintrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from est_inasistenciasinstrumento_g001 where codinstrumentos004=@codintrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codintrumento", codintrumento);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarInasistenciasEstra5_S004Coord(string codintrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from est_estrainstrumento_s004coord_asist where codestras004=@codintrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codintrumento", codintrumento);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarInasistenciasDocentesEstra2(string codintrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from est_inasistenciasinstrumento_g001_doc where codinstrumento_s004_sede=@codintrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codintrumento", codintrumento);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataRow cargarInasistenciasDocentesEstra2_DR(string codigo)
    {
        Conexion conector = new Conexion();
        string sql = "select * from est_inasistenciasinstrumento_g001_doc where codigo=@codigo";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codigo", codigo);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;

    }

    public DataTable cargarInasistenciasDetalle_EspVirtual(string codigo)
    {
        Conexion conectar = new Conexion();
        string consulta = "select rm.codigo, e.* from est_inasistenciasinstrumento_g001detalle_ev g001 inner join rt_redtematicamatricula rm on rm.codigo=g001.codestumatriculared  inner join ins_estumatricula em on em.codigo=rm.codestumatricula inner join ins_estudiante e on e.codigo=em.codestudiante where g001.codinasistenciainstrumento_g001=@codigo";
        conectar.CrearComando(consulta);

        conectar.AsignarParametroCadena("@codigo", codigo);
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

    public DataTable cargarInasistenciasDetalle_EspPresencial(string codigo)
    {
        Conexion conectar = new Conexion();
        string consulta = "select rm.codigo, e.*, g001.codestumatricula from est_inasistenciasinstrumento_g001detalle g001 inner join rt_redtematicamatricula rm on rm.codigo=g001.codestumatricula  inner join ins_estumatricula em on em.codigo=rm.codestumatricula inner join ins_estudiante e on e.codigo=em.codestudiante where g001.codinasistenciainstrumento_g001=@codigo";
        conectar.CrearComando(consulta);

        conectar.AsignarParametroCadena("@codigo", codigo);
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

    public DataTable cargarMatriculados_Estra5_S004()
    {
        Conexion conectar = new Conexion();
        string consulta = "select * from est_estrainstrumento_s004coord_matriculados order by apellido";
        conectar.CrearComando(consulta);
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

    public DataTable cargariansistenciasMatriculados_Estra5_S004(string codigo)
    {
        Conexion conectar = new Conexion();
        string consulta = "select s004.* from est_estrainstrumento_s004coord_matriculados s004 inner join est_estrainstrumento_s004coord_asistdetalle det on s004.codigo=det.cods004matriculado inner join est_estrainstrumento_s004coord_asist asist on asist.codigo=det.codestras004coord_asist where asist.codigo=@codigo order by apellido";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codigo", codigo);
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

    public DataTable cargarInasistenciasDetalle_DocentesEstra2(string codigo)
    {
        Conexion conectar = new Conexion();
        string consulta = "select g001.codigo, d.* from est_inasistenciasinstrumento_g001detalle_doc g001 inner join ins_gradodocente gd on gd.cod=g001.codgradodocente inner join ins_docente d on d.identificacion=gd.identificacion where g001.codinasistenciainstrumento_g001_doc=@codigo";
        conectar.CrearComando(consulta);

        conectar.AsignarParametroCadena("@codigo", codigo);
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

    public bool eliminarAsistenciaDocentesEstra2(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_inasistenciasinstrumento_g001_doc WHERE codigo = @cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();

    }

    public bool eliminarAsistenciaDetalleDocentesEstra2(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_inasistenciasinstrumento_g001detalle_doc WHERE codinasistenciainstrumento_g001_doc = @cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();

    }

    public DataRow buscarRedTematicaxCodModificarFecha(string codredtematica)
    {
        Conexion conector = new Conexion();
        string sql = "select * from rt_redtematicasede where codigo=@codredtematica";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codredtematica", codredtematica);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;

    }

    public bool ActualizarFechaRedTematica(string codrectematica, string aniored, string fechahoy)
    {

        Conexion conector = new Conexion();
        string sql = "UPDATE rt_redtematicasede SET aniored=@aniored, fechamodificacion=@fechahoy where codigo=@codrectematica ";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@aniored", aniored);
        conector.AsignarParametroCadena("@codrectematica", codrectematica);
        conector.AsignarParametroCadena("@fechahoy", fechahoy);
        return conector.guardadata();

    }

    public bool eliminarGradoGrupo(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM rt_redtematicagrados WHERE codigo = @cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();

    }

    public bool eliminarG001_Estrategia4(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_inasistenciasinstrumento_g001 WHERE codigo = @cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();

    }

    public bool eliminarDetalleG001_Estrategia4(string codinasistenciainstrumento_g001)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_inasistenciasinstrumento_g001detalle WHERE codinasistenciainstrumento_g001 = @codinasistenciainstrumento_g001;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinasistenciainstrumento_g001", codinasistenciainstrumento_g001);
        return conector.guardadata();

    }

    public bool eliminarDetalleasistencia_Estrategia5(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estrainstrumento_s004coord_asistdetalle WHERE codestras004coord_asist = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();

    }

    public bool eliminarasistencia_Estrategia5(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estrainstrumento_s004coord_asist WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();

    }

    public DataRow buscarG001_Estrategia4(string codinstrumentos004)
    {
        Conexion conector = new Conexion();
        string sql = "select * from est_inasistenciasinstrumento_g001 where codinstrumentos004=@codinstrumentos004";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codinstrumentos004", codinstrumentos004);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;

    }

    public DataRow buscarDatosMemoria(string codigo)
    {
        Conexion conector = new Conexion();
        string sql = "select concat_ws(' ',r.nombre,rt.consecutivogrupo) as redtematica, s004.sesion from est_estra2instrumento_s004_redt s004 inner join rt_redtematicasede rt on rt.codigo=s004.codredtematicasede inner join rt_redtematica r on r.codigo=rt.codredtematica where s004.codigo=@codigo";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codigo", codigo);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;

    }

    public bool actualizarSesionenMemoria(string codigo, string sesion)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra2instrumento_s004_redt SET sesion=@sesion WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();

    }

    public DataRow buscarDatosMemoria_ev(string codigo)
    {
        Conexion conector = new Conexion();
        string sql = "select concat_ws(' ',r.nombre,rt.consecutivogrupo) as redtematica, s004.sesion from est_estrainstrumento_s004_redt_ev s004 inner join rt_redtematicasede rt on rt.codigo=s004.codredtematicasede inner join rt_redtematica r on r.codigo=rt.codredtematica where s004.codigo=@codigo";
        conector.CrearComando(sql);
        conector.AsignarParametroCadena("@codigo", codigo);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;

    }

    public bool actualizarSesionenMemoria_ev(string codigo, string sesion)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estrainstrumento_s004_redt_ev SET sesion=@sesion WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();

    }



    /*********************** new code wilber paredes ***********************/
    public DataTable cargarTotalEvidenciasEstrategiaConActividad(string momento, string sesion, string estrategia, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT rp.*, us.pnombre , us.papellido FROM est_repositoriocoordinador rp INNER JOIN usu_usuario us ON us.cod = rp.codusuario WHERE momento=@momento and sesion=@sesion and estrategia=@estrategia and actividad=@actividad";
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


    public DataTable cargarTotalEvidenciasEstrategiaConActividad_(string momento, string sesion, string estrategia, string actividad, string codusuario)
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

    public DataTable cargarTotalEvidenciasEstrategiaConActividad_(string momento, string sesion, string estrategia, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT rp.*, us.pnombre , us.papellido FROM est_repositoriocoordinador rp INNER JOIN usu_usuario us ON us.cod = rp.codusuario WHERE momento=@momento and sesion=@sesion and estrategia=@estrategia and actividad=@actividad ";
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


    //reportes indicadores x Wilber Paredes
    public DataTable totalSedesGrupoInvestigacion(string coddepartamento, string codmunicipio, string codinstitucion)
    {

        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;
                            }
                        }
                    }
                }
            }

        }

        Conexion conector = new Conexion();

        string consulta = "SELECT gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.nombre as nombreins, iin.dane, isede.codigo, isede.nombre FROM ins_sede isede INNER JOIN pro_proyectosede pps ON pps.codsede = isede.codigo INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where + " GROUP BY iin.nombre, isede.codigo, iin.dane, gmun.nombre, gdep.nombre ORDER BY isede.nombre ASC ";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable totalSedesGrupoInvestigacionLineaInvestigacion(string coddepartamento, string codmunicipio, string codinstitucion, string linea)
    {

        int numero = 4;
        string[] cond;
        cond = new string[numero];

        cond[0] = " pps.codlineainvestigacion='" + linea + "'";  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;


        if (coddepartamento != "" && coddepartamento != null)
        {
            cond[1] = "gdep.cod='" + coddepartamento + "'";
        }
        if (codmunicipio != "" && codmunicipio != null)
        {
            cond[2] = "gmun.cod='" + codmunicipio + "'";
        }
        if (codinstitucion != "" && codinstitucion != null)
        {
            cond[3] = "iin.codigo='" + codinstitucion + "'";
        }
      

        string where = "";
        int primero = 0;
        for (int i = 0; i < numero; i++)
        {
            if (cond[i] != string.Empty)
            {
                if (primero == 0)
                {
                    where += "WHERE " + cond[i];
                }
                if (primero > 0)
                {
                    where += " AND " + cond[i];
                }
                if (primero == 0)
                {
                    primero = 1;
                }
            }
        }

        Conexion conector = new Conexion();

        string consulta = "SELECT gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.nombre as nombreins, iin.dane, isede.codigo, isede.nombre FROM ins_sede isede INNER JOIN pro_proyectosede pps ON pps.codsede = isede.codigo INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where + " GROUP BY iin.nombre, isede.codigo, iin.dane, gmun.nombre, gdep.nombre ORDER BY isede.nombre ASC ";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    //total grupos de investigacion 
    public DataTable totalGrupoInvestigacion(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;
                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        Conexion conector = new Conexion();
        string consulta = "SELECT gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.nombre as nombreins, iin.dane, isede.nombre as nombresede, isede.dane as danesede, pps.nombregrupo FROM pro_proyectosede  pps INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where + " ORDER BY pps.nombregrupo, isede.nombre, isede.dane, iin.nombre, iin.dane ASC ";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    //Cuantos niños hay inscritos en los grupos de investigacion
    public DataTable totalEstudiantesMatriculadosGP(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string codgrupoinvestigacion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;

                                        if (codgrupoinvestigacion != "")
                                        {
                                            if (codgrupoinvestigacion != "null")
                                            {
                                                where = where + " AND  pps.codigo = " + codgrupoinvestigacion;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        Conexion conector = new Conexion();
        string consulta = "SELECT gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.nombre as nombreins, iin.dane, isede.nombre as nombresede, isede.dane as danesede, pps.nombregrupo, ppm.codestumatricula, iest.nombre, iest.apellido FROM pro_proyectomatricula ppm INNER JOIN pro_proyectosede pps ON pps.codsede = ppm.codproyectosede INNER JOIN ins_estumatricula ie ON ie.codigo = ppm.codestumatricula INNER JOIN ins_estudiante iest ON iest.codigo = ie.codestudiante INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where + " GROUP BY ppm.codestumatricula, iest.nombre, iest.apellido, isede.nombre, isede.dane, iin.nombre, iin.dane, gdep.nombre, gmun.nombre, pps.nombregrupo  ORDER BY codestumatricula DESC ";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    //Docenes matriculados en los grupos de investigacion
    public DataTable totalDocenesMatriculadosGP(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string codgrupoinvestigacion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;

                                        if (codgrupoinvestigacion != "")
                                        {
                                            if (codgrupoinvestigacion != "null")
                                            {
                                                where = where + " AND  pps.codigo = " + codgrupoinvestigacion;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        Conexion conector = new Conexion();
        string consulta = "SELECT gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.nombre as nombreins, iin.dane, isede.nombre as nombresede, isede.dane as danesede, pps.nombregrupo, codgradodocente, id.nombre, id.apellido FROM pro_proyectodocente ppd INNER JOIN pro_proyectosede pps ON pps.codsede = ppd.codproyectosede INNER JOIN ins_gradodocente igd ON igd.cod= ppd.codgradodocente INNER JOIN ins_docente id ON id.identificacion = igd.identificacion INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where + " GROUP BY codgradodocente, id.nombre, id.apellido, isede.nombre, isede.dane, iin.nombre, iin.dane, gmun.nombre, gdep.nombre, pps.nombregrupo ";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    //Numero de sedes con grupos de investigacon que tengan preguntas
    public DataTable totalSedesGPTenganPreguntas(string coddepartamento, string codmunicipio, string codinstitucion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.nombre as nombreins, iin.dane, isede.nombre as nombresede, isede.dane as danesede, pps.codsede FROM pro_proyectosede pps INNER JOIN est_estra1bitacora2 eeb ON eeb.codproyecto = pps.codigo INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where + " GROUP BY pps.codsede, isede.nombre, isede.dane, iin.nombre, iin.dane, gmun.nombre, gdep.nombre ORDER BY isede.nombre ASC";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    //Número de grupos de investigación hicieron preguntas  bitacora 2
    public DataTable totalGPHicieronPreguntas(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;
                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        Conexion conector = new Conexion();
        string consulta = "SELECT gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.nombre as nombreins, iin.dane, isede.nombre as nombresede, isede.dane as danesede, codproyecto, nombregrupo FROM pro_proyectosede pps INNER JOIN est_estra1bitacora2 eeb ON eeb.codproyecto = pps.codigo INNER JOIN ins_sede isede ON isede.codigo = pps.codsede  INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where + " GROUP BY codproyecto, nombregrupo, isede.nombre, isede.dane, iin.nombre, iin.dane, gmun.nombre, gdep.nombre ORDER BY nombregrupo ASC ";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    //Numero de sedes con grupos de investigacon que tengan preguntas BITACORA 3
    public DataTable totalSedesGPTenganPreguntasB3(string coddepartamento, string codmunicipio, string codinstitucion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.nombre as nombreins, iin.dane, codsede, isede.nombre as nombresede, isede.dane as danesede FROM pro_proyectosede pps INNER JOIN est_estra1bitacora3 eeb ON eeb.codproyecto = pps.codigo INNER JOIN ins_sede isede ON isede.codigo = pps.codsede  INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where + " GROUP BY codsede, isede.nombre, isede.dane, iin.nombre, iin.dane, gmun.nombre, gdep.nombre ORDER BY isede.nombre ";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    //Número de grupos de investigación hicieron preguntas  bitacora 3
    public DataTable totalGPHicieronPreguntasB3(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;
                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;

                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.nombre as nombreins, iin.dane, isede.nombre as nombresede, isede.dane as danesede, codproyecto, nombregrupo FROM pro_proyectosede pps INNER JOIN est_estra1bitacora3 eeb ON eeb.codproyecto = pps.codigo INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where + " GROUP BY codproyecto, nombregrupo, isede.nombre, isede.dane, iin.nombre, iin.dane, gmun.nombre, gdep.nombre ORDER BY nombregrupo ASC ";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    //Número de asesorias de grupos de investigación
    public DataTable noAsesoriasGP(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;
                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;

                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        Conexion conector = new Conexion();
        string consulta = "SELECT gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.nombre as nombreins, iin.dane, isede.nombre as nombresede, isede.dane as danesede, ee2.codproyecto, pps.nombregrupo FROM est_estra2instrumento_s002 ee2 INNER JOIN pro_proyectosede pps ON ee2.codproyecto = pps.codigo INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE ee2.estrategia = 1 " + where + " GROUP BY ee2.codproyecto, pps.nombregrupo, isede.nombre, isede.dane, iin.nombre, iin.dane, gmun.nombre, gdep.nombre ORDER BY pps.nombregrupo ASC";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    //Total de participantes de las asesorias
    public DataRow noParticipantesAsesorias()
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT SUM(noasistentes) AS total FROM est_estra2instrumento_s002";
        conector.CrearComando(consulta);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }


    //Total de evaluación asesoria
    public DataTable totalEvaluacionAsesoria(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string codgrupoinvestigacion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;
                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                        if (codgrupoinvestigacion != "")
                                        {
                                            if (codgrupoinvestigacion != "null")
                                            {
                                                where = where + " AND  pps.codigo = " + codgrupoinvestigacion;

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        Conexion conector = new Conexion();
        string consulta = "SELECT gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.nombre as nombreins, iin.dane, isede.nombre as nombresede, isede.dane as danesede, pps.nombregrupo, ee2.nominvestigacion FROM est_estra2instrumento_s002 ee2 INNER JOIN pro_proyectosede pps ON pps.codigo = ee2.codproyecto INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE estrategia = 1 " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    //Desarrollo de las jornadas de formación
    public DataTable jornadasformacion(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string codgrupoinvestigacion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;

                                        if (codgrupoinvestigacion != "")
                                        {
                                            if (codgrupoinvestigacion != "null")
                                            {
                                                where = where + " AND  pps.codigo = " + codgrupoinvestigacion;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM est_repositoriocoordinador WHERE estrategia = 1 AND momento = 1 AND sesion = 0 AND actividad = '30' OR actividad = '40'  "; //+ where
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    //momento 3
    // Total sedes con grupos de investigación que han llenado bitácora 4
    public DataTable sedesGPBitacora4(string coddepartamento, string codmunicipio, string codinstitucion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;
                            }
                        }
                    }
                }
            }

        }


        Conexion conector = new Conexion();
        string consulta = "SELECT iin.nombre as nombreins, iin.dane, isede.nombre as nombresede, isede.dane as danesede,  gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM est_estra2instrumento_g007 eb4 INNER JOIN pro_proyectosede pps ON pps.codigo = eb4.codproyecto INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where + " GROUP BY isede.codigo, iin.nombre,  iin.dane, isede.nombre, gmun.nombre, gdep.nombre";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    // total de grupos de investigación con bitacora 04 
    public DataTable gruposInvestigacionBitacora4(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string codgrupoinvestigacion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " where gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;

                                        if (codgrupoinvestigacion != "")
                                        {
                                            if (codgrupoinvestigacion != "null")
                                            {
                                                where = where + " AND  pps.codigo = " + codgrupoinvestigacion;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT pps.nombregrupo, iin.nombre as nombreins, iin.dane, isede.nombre as nombresede, isede.dane as danesede,  gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM est_estra2instrumento_g007 eb4 INNER JOIN pro_proyectosede pps ON pps.codigo = eb4.codproyecto INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    //grupos de investigación con recursos aprobados por ciclón
    public DataTable gruposInvestigacionRecursosB4(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string codgrupoinvestigacion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " where gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;

                                        if (codgrupoinvestigacion != "")
                                        {
                                            if (codgrupoinvestigacion != "null")
                                            {
                                                where = where + " AND  pps.codigo = " + codgrupoinvestigacion;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT pps.nombregrupo, iin.nombre as nombreins, iin.dane, isede.nombre as nombresede, isede.dane as danesede,  gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM est_estra2instrumento_g007 eb4 INNER JOIN pro_proyectosede pps ON pps.codigo = eb4.codproyecto INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    // Total sedes con grupos de investigación que han llenado bitácora 5
    public DataTable sedesGPBitacora5(string coddepartamento, string codmunicipio, string codinstitucion)
    {

        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " where gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                            }
                        }
                    }
                }
            }

        }

        Conexion conector = new Conexion();
        string consulta = "SELECT iin.nombre as nombreins, iin.dane, isede.nombre as nombresede, isede.dane as danesede,  gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM est_estra1bitacora5 eb5 INNER JOIN pro_proyectosede pps ON pps.codigo = eb5.codproyecto INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where + " GROUP BY isede.codigo, iin.nombre,  iin.dane, isede.nombre, gmun.nombre, gdep.nombre";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    // total de grupos de investigación con bitacora 05 
    public DataTable gruposInvestigacionBitacora5(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " where gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;

                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT distinct on (pps.nombregrupo) pps.nombregrupo, iin.nombre as nombreins, iin.dane, isede.nombre as nombresede, isede.dane as danesede,  gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM est_estra1bitacora5 eb5 INNER JOIN pro_proyectosede pps ON pps.codigo = eb5.codproyecto INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    public DataTable cargarProyectoSedexSedes(string codsede)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT ps.*, concat_ws(' ', a.identificacion,'-',a.nombre,a.apellido) as asesor, a.identificacion FROM pro_proyectosede ps inner join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor WHERE ps.codsede=@codsede ORDER BY fechacreacion DESC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarProyectoSedexSedesxAsesor(string codsede, string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT ps.*, concat_ws(' ', a.identificacion,'-',a.nombre,a.apellido)as asesor FROM pro_proyectosede ps inner join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor WHERE ps.codsede=@codsede and ps.codasesorcoordinador=@codasesorcoordinador ORDER BY fechacreacion DESC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }



    //El asesor acompaña a los grupos de investigación


    //Asesorías realizadas a los grupos de investigación infantiles y juveniles en el momento pedagógico 3, etapa 4
    public DataTable asesoriasGPm3e1(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string codgrupoinvestigacion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;

                                        if (codgrupoinvestigacion != "")
                                        {
                                            if (codgrupoinvestigacion != "null")
                                            {
                                                where = where + " AND  pps.codigo = " + codgrupoinvestigacion;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT  gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.nombre as nombreins, iin.dane, isede.nombre as nombresede, isede.dane as danesede, pps.nombregrupo, ss2.* FROM est_estra2instrumento_s002 ss2 INNER JOIN pro_proyectosede pps ON pps.codigo = ss2.codproyecto INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE estrategia = 1 AND momento = 3 " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    //Asistentes a la sesión de asesoría
    public DataRow asistentesSesionAsesoria()
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT SUM(noasistentes) AS total FROM est_estra2instrumento_s002 WHERE estrategia = 1 AND momento = 3";
        conector.CrearComando(consulta);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }


    //Asesorías a los grupos infantiles y juveniles  evaluados
    public DataTable asesoriasGPCiclon(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string codgrupoinvestigacion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;

                                        if (codgrupoinvestigacion != "")
                                        {
                                            if (codgrupoinvestigacion != "null")
                                            {
                                                where = where + " AND  pps.codigo = " + codgrupoinvestigacion;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.nombre as nombreins, iin.dane, isede.nombre as nombresede, isede.dane as danesede, pps.nombregrupo, ers2.nombrearchivo FROM est_repositorioasesor_s002 ers2 INNER JOIN est_estra2instrumento_s002 ss2 ON ers2.codestras002 = ss2.codigo INNER JOIN pro_proyectosede pps ON pps.codigo = ss2.codproyecto INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE ss2.estrategia = 1 AND ss2.momento = 3 " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    public DataTable cargarLineasInvestigacionxGrupoInvestigacion(string codGrupoinvestigacion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT pli.codigo, pli.nombre, pli.abr, pps.codigo as codigoproyecto  FROM pro_linea_investigacion pli INNER JOIN pro_proyectosede pps ON pps.codlineainvestigacion = pli.codigo WHERE pps.codigo = @codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codGrupoinvestigacion);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }



    //Asesorías realizadas a los grupos de investigación infantiles y juveniles en el momento pedagógico 3 etapa 5
    public DataTable asesoriasGPEtapa5(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string codgrupoinvestigacion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                        if (codgrupoinvestigacion != "")
                                        {
                                            if (codgrupoinvestigacion != "null")
                                            {
                                                where = where + " AND  pps.codigo = " + codgrupoinvestigacion;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT  gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.nombre as nombreins, iin.dane, isede.nombre as nombresede, isede.dane as danesede, pps.nombregrupo, ss2.* FROM est_estra2instrumento_s002 ss2 INNER JOIN pro_proyectosede pps ON pps.codigo = ss2.codproyecto INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE estrategia = 1 AND momento = 3 " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    //Total grupos de investigación con registro de avance del presupuesto
    public DataTable gruposInvestigacionPresupuesto(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, pps.nombregrupo FROM est_estra1bitacora4punto1 eeb INNER JOIN pro_proyectosede pps ON pps.codigo = eeb.codproyectosede INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where + " GROUP BY eeb.codproyectosede, gdep.nombre, gmun.nombre,  iin.dane, iin.nombre, isede.dane, isede.nombre, pps.nombregrupo ";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    //Asesorías a los grupos infantiles y juveniles evaluadas y subidas a la plataforma de Ciclón
    public DataTable asesoriasGPevaluadas(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string codgrupoinvestigacion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;

                                        if (codgrupoinvestigacion != "")
                                        {
                                            if (codgrupoinvestigacion != "null")
                                            {
                                                where = where + " AND  pps.codigo = " + codgrupoinvestigacion;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, pps.nombregrupo, ers002.nombrearchivo, ers002.actividad, ss2.codproyecto, ss2.objetivo FROM est_repositorioasesor_s002 ers002 INNER JOIN est_estra2instrumento_s002 ss2 ON ers002.codestras002 = ss2.codigo INNER JOIN pro_proyectosede pps ON pps.codigo = ss2.codproyecto INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE ers002.actividad = 'Evaluación de la asesoría' " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    //nuevo codigo
    public DataTable cargarEvidenciasEstrategiaConActividad_(string momento, string sesion, string estrategia, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_repositoriocoordinador rc inner join usu_usuario u on u.cod=rc.codusuario WHERE momento=@momento and sesion=@sesion and estrategia=@estrategia and actividad=@actividad ORDER BY fechacreado ASC";
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

    //Estrategias 2
    public DataTable estra2LineamientosEstrategia(string momento, string estrategia, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT rp.*, us.pnombre , us.papellido FROM est_repositoriocoordinador rp INNER JOIN usu_usuario us ON us.cod = rp.codusuario WHERE momento=@momento and estrategia=@estrategia and actividad=@actividad";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@actividad", actividad);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    //Ejemplares de la caja de herramientas  que soporta la formación de maestros(as)
    public DataTable estra2EjemplaresCajaHerramientas(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, eig6.* FROM est_estra2instrumento_g006 eig6 INNER JOIN ins_sede isede ON isede.codigo = eig6.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable estra2MaestrosMatriculados(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, igd.*, id.nombre, id.apellido FROM ins_gradodocente igd INNER JOIN ins_docente id ON id.identificacion = igd.identificacion INNER JOIN ins_sede isede ON isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento  " + where + " limit 4330";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable estra2MaestrosAsistencia(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT distinct on (igd.identificacion) gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, igd.*, id.nombre, id.apellido FROM ins_gradodocente igd INNER JOIN ins_docente id ON id.identificacion = igd.identificacion INNER JOIN ins_sede isede ON isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento inner join est_inasistenciasinstrumento_g001detalle_doc g001 on g001.codgradodocente=igd.cod  " + where + " ";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    public DataTable estra2MesasTrabajoConstituidas(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, mt.nombregrupo FROM pro_mesadetrabajo mt INNER JOIN ins_sede isede ON isede.codigo = mt.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    public DataTable estra2GrupoInvestigacionMaestros(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, pgi.nombregrupo FROM pro_grupoinvestigaciondocentes pgi INNER JOIN ins_sede isede ON isede.codigo = pgi.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento  " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    public DataTable estra2LineasTematicas(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {

        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM pro_areas ";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    //estrategia 2 momento 1
    public DataTable estra2SesionesFormacion1(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string momento, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT ON(isede.dane)  gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, ees4.nombresesion FROM est_estra2instrumento_s004_sede ees4 INNER JOIN ins_sede isede ON isede.codigo = ees4.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE ees4.estrategia = 2 AND ees4.momento = " + momento + " AND ees4.sesion =" + sesion + " " + where + " ";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable estra2AsistentesFormacion(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string momento, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT ON(isede.dane) gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, ers4.nombrearchivo FROM est_repositorioasesor_s004sedes ers4 INNER JOIN est_estra2instrumento_s004_sede ees4 ON ees4.codigo = ers4.codinstrumento INNER JOIN ins_sede isede ON isede.codigo = ees4.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE ers4.actividad = 'Lista de Asistencia' AND ees4.estrategia = 2 AND ees4.momento = " + momento + " AND ees4.sesion = " + sesion + " " + where + " group by ers4.codinstrumento, gdep.nombre, gmun.nombre, iin.dane, iin.nombre, isede.dane, isede.nombre, ers4.nombrearchivo ";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable estra2RelatoriasInstitucionales(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string momento, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT ON(isede.dane) gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, ers4.nombrearchivo FROM est_repositorioasesor_s004sedes ers4 INNER JOIN est_estra2instrumento_s004_sede ees4 ON ees4.codigo = ers4.codinstrumento INNER JOIN ins_sede isede ON isede.codigo = ees4.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE ers4.actividad = 'Relatoria institucional' AND ees4.estrategia = 2 AND ees4.momento = " + momento + " AND ees4.sesion = " + sesion + " " + where + " group by ers4.codinstrumento, gdep.nombre, gmun.nombre, iin.dane, iin.nombre, isede.dane, isede.nombre, ers4.nombrearchivo ";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    public DataTable estra2SesionesFormacion(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string momento, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT ON(isede.dane) gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, ers4.nombrearchivo FROM est_repositorioasesor_s004sedes ers4 INNER JOIN est_estra2instrumento_s004_sede ees4 ON ees4.codigo = ers4.codinstrumento INNER JOIN ins_sede isede ON isede.codigo = ees4.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE ers4.actividad = 'Formato de evaluación' AND ees4.estrategia = 2 AND ees4.momento = " + momento + " AND ees4.sesion = " + sesion + " " + where + " group by ers4.codinstrumento, gdep.nombre, gmun.nombre, iin.dane, iin.nombre, isede.dane, isede.nombre, ers4.nombrearchivo";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    //Monitoreo Estrategi 4
    public DataTable est_estra2instrumento_s004_redt_2016(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "select gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, rt2016.* from est_estra2instrumento_s004_redt_2016 rt2016 INNER JOIN rt_redtematicasede rts on rts.codigo=rt2016.codredtematicasede INNER JOIN ins_sede isede ON isede.codigo = rts.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento where rt2016.estrategia='4' and rt2016.sesion=" + sesion + " and rts.aniored='2016' " + where + "";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable est_estra2instrumento_s004_redt_2016_estudiantes(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "select gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, e.nombre, e.apellido, e.identificacion from rt_redtematicamatricula rtd inner join rt_redtematicasede rt on rtd.codredtematicasede=rt.codigo INNER JOIN ins_sede isede ON isede.codigo = rt.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento INNER JOIN ins_estumatricula em on em.codigo=rtd.codestumatricula INNER JOIN ins_estudiante e on e.codigo=em.codestudiante where em.codanio='1' " + where + "";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable est_estra2instrumento_s004_redt_2016_estudiantesSedes(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string sesion, string aniored)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "select distinct on (isede.dane) gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, e.nombre, e.apellido, e.identificacion from rt_redtematicamatricula rtd inner join rt_redtematicasede rt on rtd.codredtematicasede=rt.codigo INNER JOIN ins_sede isede ON isede.codigo = rt.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento INNER JOIN ins_estumatricula em on em.codigo=rtd.codestumatricula INNER JOIN ins_estudiante e on e.codigo=em.codestudiante where rt.aniored='" + aniored + "' " + where + "";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable est_estra2instrumento_s004_redt_2016_estudiantesDistinct(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "select distinct on (rtd.codestumatricula) gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, e.nombre, e.apellido, e.identificacion from rt_redtematicamatricula rtd inner join rt_redtematicasede rt on rtd.codredtematicasede=rt.codigo INNER JOIN ins_sede isede ON isede.codigo = rt.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento INNER JOIN ins_estumatricula em on em.codigo=rtd.codestumatricula INNER JOIN ins_estudiante e on e.codigo=em.codestudiante where rt.aniored='2016'" + where + "";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable est_estra2instrumento_s004_redt_2016_docentes(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "select  gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, d.identificacion, d.nombre, d.apellido from rt_redtematicadocente rtd inner join rt_redtematicasede rt on rtd.codredtematicasede=rt.codigo INNER JOIN ins_sede isede ON isede.codigo = rt.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento INNER JOIN ins_gradodocente gd on gd.cod=rtd.codgradodocente INNER JOIN ins_docente d on d.identificacion=gd.identificacion where rt.aniored='2016' " + where + "";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable est_estra2instrumento_s004_redt_2016_docentesSedes(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string sesion, string aniored)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = "AND gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "select distinct on (isede.dane) gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, d.identificacion, d.nombre, d.apellido from rt_redtematicadocente rtd inner join rt_redtematicasede rt on rtd.codredtematicasede=rt.codigo INNER JOIN ins_sede isede ON isede.codigo = rt.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento INNER JOIN ins_gradodocente gd on gd.cod=rtd.codgradodocente INNER JOIN ins_docente d on d.identificacion=gd.identificacion WHERE rt.aniored='" + aniored + "' " + where + "";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable est_estra4instrumento_s004_redt_2016_Evidencias(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string sesion, string actividad, string aniored)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "select gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, ra.* from est_repositorioasesor_estra4 ra inner join rt_redtematicasede rt on ra.codredtematicasede=rt.codigo INNER JOIN ins_sede isede ON isede.codigo = rt.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento where rt.aniored='" + aniored + "' and ra.sesion='" + sesion + "' and ra.estrategia='4' and ra.actividad='" + actividad + "' " + where + "";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable est_estra2instrumento_s004_redt_2016_docentesDistinct(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "select distinct on (rtd.codgradodocente) gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, d.identificacion, d.nombre, d.apellido from rt_redtematicadocente rtd inner join rt_redtematicasede rt on rtd.codredtematicasede=rt.codigo INNER JOIN ins_sede isede ON isede.codigo = rt.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento INNER JOIN ins_gradodocente gd on gd.cod=rtd.codgradodocente INNER JOIN ins_docente d on d.identificacion=gd.identificacion where rt.aniored='2016' " + where + "";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable est_estra2instrumento_s004_redt_2016_docentes_estudiantes(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "select distinct on (isede.dane) gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede from rt_redtematicamatricula rtm inner join rt_redtematicasede rt on rtm.codredtematicasede=rt.codigo INNER JOIN ins_sede isede ON isede.codigo = rt.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento inner join rt_redtematicadocente rtd on rtd.codredtematicasede=rt.codigo where rt.aniored='2016' " + where + "";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable est_estra2instrumento_s004_redt(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string momento, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "select distinct on (rt.codredtematicasede) gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, rt.* from est_estra2instrumento_s004_redt rt INNER JOIN rt_redtematicasede rts on rts.codigo=rt.codredtematicasede INNER JOIN ins_sede isede ON isede.codigo = rts.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento where rt.estrategia='4' and rt.momento=" + momento + " and rt.sesion=" + sesion + " and rts.aniored='2017' " + where + "";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable est_estra2instrumento_s004_redtSedes(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string momento, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "select distinct on (isede.dane) gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, rt.* from est_estra2instrumento_s004_redt rt INNER JOIN rt_redtematicasede rts on rts.codigo=rt.codredtematicasede INNER JOIN ins_sede isede ON isede.codigo = rts.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento where rt.estrategia='4' and rt.momento=" + momento + " and rt.sesion=" + sesion + " and rts.aniored='2017' " + where + "";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable est_estra2instrumento_s004_redt_estudiantes(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string sesion, string codanio)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        //string consulta = "select gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, e.identificacion, e.nombre, e.apellido from rt_redtematicasede rt INNER JOIN ins_sede isede ON isede.codigo = rt.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento INNER JOIN ins_estumatricula em on em.codsede=isede.codigo INNER JOIN ins_estudiante e on e.codigo=em.codestudiante where em.codanio='" + codanio + "' and rt.aniored='2017'" + where + "";
        string consulta = "select distinct on (e.identificacion) gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, e.identificacion, e.nombre, e.apellido from rt_redtematicamatricula rtm inner join ins_estumatricula em on em.codigo=rtm.codestumatricula inner join ins_estudiante e on e.codigo=em.codestudiante inner join rt_redtematicasede rts on rts.codigo=rtm.codredtematicasede INNER JOIN ins_sede isede ON isede.codigo = rts.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento where rts.aniored='2017'" + where + "";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable est_estra2instrumento_s004_redt_docentes(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "select  gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, d.identificacion, d.nombre, d.apellido from rt_redtematicadocente rtd inner join rt_redtematicasede rt on rtd.codredtematicasede=rt.codigo INNER JOIN ins_sede isede ON isede.codigo = rt.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento INNER JOIN ins_gradodocente gd on gd.cod=rtd.codgradodocente INNER JOIN ins_docente d on d.identificacion=gd.identificacion where rt.aniored='2017' " + where + "";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable est_estra2instrumento_s004_redt_docentes_estudiantes(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "select distinct on (isede.dane) gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede from rt_redtematicamatricula rtm inner join rt_redtematicasede rt on rtm.codredtematicasede=rt.codigo INNER JOIN ins_sede isede ON isede.codigo = rt.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento inner join rt_redtematicadocente rtd on rtd.codredtematicasede=rt.codigo where rt.aniored='2017' " + where + "";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable est_estra2instrumento_s004_redt_estudiantesDistinct(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "select distinct on (rtd.codestumatricula) gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, e.identificacion, e.nombre, e.apellido from rt_redtematicamatricula rtd inner join rt_redtematicasede rt on rtd.codredtematicasede=rt.codigo INNER JOIN ins_sede isede ON isede.codigo = rt.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento INNER JOIN ins_estumatricula em on em.codigo=rtd.codestumatricula INNER JOIN ins_estudiante e on e.codigo=em.codestudiante where rt.aniored='2017'" + where + "";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable est_estra2instrumento_s004_redt_docentesDistinct(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "select distinct on (rtd.codgradodocente) gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, d.identificacion, d.nombre, d.apellido from rt_redtematicadocente rtd inner join rt_redtematicasede rt on rtd.codredtematicasede=rt.codigo INNER JOIN ins_sede isede ON isede.codigo = rt.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento INNER JOIN ins_gradodocente gd on gd.cod=rtd.codgradodocente INNER JOIN ins_docente d on d.identificacion=gd.identificacion where rt.aniored='2017' " + where + "";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable est_lineamientosFormacion(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string estrategia, string actividad)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM est_repositoriocoordinador_estra5 WHERE estrategia='" + estrategia + "' AND actividad='" + actividad + "' " + where + "";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable est_EvidenciasEstras004Coordinador(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string estrategia, string actividad)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM est_repositoriocoord_s004 WHERE actividad='" + actividad + "' " + where + "";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable est_matriculafuncionariosCoordinador(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string estrategia, string actividad)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM est_repositoriocoordinador_estra5 WHERE estrategia='" + estrategia + "' AND actividad='" + actividad + "' " + where + "";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable est_EvidenciasEstras004CoordinadorConMemorias(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string estrategia, string actividad, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT rep.* FROM est_estrainstrumento_s004coord s004 left join est_repositoriocoord_s004 rep on s004.codigo=rep.codinstrumento WHERE rep.actividad='" + actividad + "' and s004.estrategia='" + estrategia + "' and s004.sesion='" + sesion + "' " + where + "";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable est_EvidenciasEstras004CoordinadorConMemoriasDosActividades(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string estrategia, string actividad, string actividad2, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT rep.* FROM est_estrainstrumento_s004coord s004 left join est_repositoriocoord_s004 rep on s004.codigo=rep.codinstrumento WHERE (rep.actividad='" + actividad + "' OR rep.actividad='" + actividad2 + "') and s004.estrategia='" + estrategia + "' and s004.sesion='" + sesion + "' " + where + "";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable est_Estras004CoordinadorDias(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string estrategia, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT SUM(date_part('day' ,fechaelaboracion-fechaelaboracionini)+1) as dias from est_estrainstrumento_s004coord where estrategia='" + estrategia + "' and sesion='" + sesion + "' " + where + "";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable est_s004CoordinadorConMemorias(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string estrategia, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, s004.* FROM est_estrainstrumento_s004coord s004 INNER JOIN geo_municipios gmun ON gmun.cod = s004.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE s004.estrategia='" + estrategia + "' and s004.sesion='" + sesion + "' " + where + "";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable est_EvidenciasEstras5Coordinador(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string estrategia, string actividad)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM est_repositoriocoordinador_estra5 WHERE actividad='" + actividad + "' " + where + "";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable est_estra4RepositorioCoordinador(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string momento, string sesion, string actividad, string subactividad)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "select * from est_repositoriocoordinador_estra4 where estrategia='4' AND momento ='" + momento + "' AND sesion='" + sesion + "' AND actividad='" + actividad + "' AND subactividad='" + subactividad + "' " + where + "";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    //ESTRATEGIA 1 MOMENTO 0

    //lineamientos de las ferias municipales
    public DataTable estra1numeroferiasmunicipales(string coddepartamento, string codmunicipio)
    {

        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT efm.*, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM ep_feriasmunicipales efm INNER JOIN ep_municipiomatricula emm ON emm.codferiamunicipal = efm.codigo INNER JOIN geo_municipios gmun ON gmun.cod = emm.codmunicipiomatricula INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    //Sedes educativas con grupos de investigación presentados para evaluación en feria
    public DataTable estra1SedesGruposEvaluacionFeria(string coddepartamento, string codmunicipio)
    {

        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT ere.*, gmun.nombre as nombremunicipio , gdep.nombre as nombredepartamento FROM est_respositorio_espacioapro ere INNER JOIN geo_municipios gmun ON gmun.cod = ERE.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarRedesTematicas(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string aniored)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "select rt.*, gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede from rt_redtematicasede rt INNER JOIN ins_sede isede ON isede.codigo = rt.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE rt.aniored='" + aniored + "' " + where + "";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    //nuevo codigo estrategia 2 momeno 1 sesion 1

    public DataTable estra2JornadaFormacion(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string momento, string sesion, string jornada)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, ers4.temasesion FROM est_estra2instrumento_s004_sede ers4 INNER JOIN ins_sede isede ON isede.codigo = ers4.codsede  INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE ers4.estrategia = '2' AND ers4.momento = '" + momento + "' AND ers4.sesion = '" + sesion + "' AND ers4.jornada='" + jornada + "' " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    //Sedes con asistencia cargadas de la sesión de formación No. 1
    public DataTable estra2SedesAsistencias(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string momento, string sesion, string jornada)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT(eidoc.codsede), gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, eidoc.tema FROM est_inasistenciasinstrumento_g001_doc eidoc INNER JOIN ins_sede isede ON isede.codigo = eidoc.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE eidoc.estrategia = '2' AND eidoc.momento = " + momento + " AND eidoc.sesion = " + sesion + " AND eidoc.jornada=" + jornada + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }
    //Relatorías institucionales elaboradas jornada 1
    public DataTable estra2RelatoriasInstitucionales(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string momento, string sesion, string jornada)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT(ers4.codinstrumento), gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, ers4.nombrearchivo, ers4.path, ers4.ext FROM est_repositorioasesor_s004sedes ers4 INNER JOIN est_estra2instrumento_s004_sede ees4 ON ees4.codigo = ers4.codinstrumento INNER JOIN ins_sede isede ON isede.codigo = ees4.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE ers4.actividad = 'Relatoria institucional' AND ees4.estrategia = 2 AND ees4.momento = '" + momento + "' AND ees4.sesion = '" + sesion + "' AND ees4.jornada = " + jornada + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    //Jornada de formación  No. 1 evaluadas y subidas a la plataforma de Ciclón
    public DataTable jornadasFormacionEvaluadas(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string momento, string sesion, string jornada)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT(ers4.codinstrumento), gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, ers4.nombrearchivo FROM est_repositorioasesor_s004sedes ers4 INNER JOIN est_estra2instrumento_s004_sede ees4 ON ees4.codigo = ers4.codinstrumento INNER JOIN ins_sede isede ON isede.codigo = ees4.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE ers4.actividad = 'Formato de evaluación' AND ees4.estrategia = 2 AND ees4.momento = '" + momento + "' AND ees4.sesion = '" + sesion + "' AND ees4.jornada = " + jornada + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    //Asistentes a la sesión de formación
    public DataTable estra2AsistentesFormacion_(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string momento, string sesion, string jornada)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, eidoc.tema FROM est_inasistenciasinstrumento_g001_doc eidoc INNER JOIN ins_sede isede ON isede.codigo = eidoc.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE eidoc.estrategia = '2' AND eidoc.momento = " + momento + " AND eidoc.sesion = " + sesion + " AND eidoc.jornada=" + jornada + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public bool editarRedTematicaxCodigo(string codigo, string codsede)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE rt_redtematicasede SET codsede=@codsede WHERE codigo=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        conector.AsignarParametroCadena("@codsede", codsede);
        return conector.guardadata();

    }

    //NUEVO CODIGO

    public DataTable gpSeleccionadosconvocatoria(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = " SELECT distinct(eeb1.codproyectosede)  FROM est_estra1bitacora1 eeb1 INNER JOIN pro_proyectosede pps ON pps.codigo = eeb1.codproyectosede INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    public DataTable estudianesengp(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = " SELECT ppm.* FROM pro_proyectomatricula ppm INNER JOIN pro_proyectosede pps ON pps.codigo = ppm.codproyectosede INNER JOIN ins_sede isede ON isede.codigo = pps.codsede  INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion  INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio  INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento  " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    public DataTable gpbitacora4(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string estrategia)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = " SELECT eeig7.* FROM est_estra2instrumento_g007 eeig7 INNER JOIN pro_proyectosede pps ON pps.codigo = eeig7.codproyecto INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE estrategia =  " + estrategia + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    public DataRow asistentesesionasesoriaxestrategia(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string estrategia)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }

        Conexion conector = new Conexion();
        String consulta = "SELECT SUM(ees2.noasistentes) AS total FROM est_estra2instrumento_s002 ees2 INNER JOIN pro_proyectosede pps ON pps.codigo = ees2.codproyecto INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE ees2.estrategia =  " + estrategia + where;
        conector.CrearComando(consulta);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }


    public DataTable kitpreestructurados(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT eig6m.*  FROM est_estra2instrumento_g006material eig6m INNER JOIN est_estra2instrumento_g006 eig6 ON eig6.codigo = eig6m.codestrainstrumento_g006 INNER JOIN ins_sede isede ON isede.codigo = eig6.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE eig6m.nombrematerial = 'Kit preestructurados reimpresos' " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable esturedtematicas(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT rtm.* FROM rt_redtematicamatricula rtm INNER JOIN ins_estumatricula ie ON ie.codigo = rtm.codigo INNER JOIN ins_sede isede ON isede.codigo = ie.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento  " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }



    public DataTable sederedtematicas(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT rtms.* FROM rt_redtematicasede rtms INNER JOIN ins_sede isede ON isede.codigo = rtms.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento  " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    public DataTable sesionesformacion2016(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string estrategia, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT s004.*  FROM est_estra2instrumento_s004_redt_2016 s004 INNER JOIN rt_redtematicasede rts on s004.codredtematicasede= rts.codigo INNER JOIN ins_sede isede on isede.codigo=rts.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE estrategia = " + estrategia + " and sesion = " + sesion + " " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    public DataTable estuinscritog001_2016(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT g001.* FROM est_inasistenciasinstrumento_g001detalle_2016 g001 INNER JOIN ins_estumatricula ie ON ie.codigo = g001.codestumatricula INNER JOIN ins_sede isede ON isede.codigo = ie.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    public DataTable sesionformacion_vt(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string estrategia, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT errv.* FROM est_estrainstrumento_s004_redt_ev errv INNER JOIN rt_redtematicasede rts on errv.codredtematicasede= rts.codigo INNER JOIN ins_sede isede on isede.codigo=rts.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE errv.estrategia = " + estrategia + " AND errv.sesion = " + sesion + " " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    public DataTable estuinscritossesion_vt(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string estrategia, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM est_inasistenciasinstrumento_g001detalle_ev g001detalle INNER JOIN est_inasistenciasinstrumento_g001_ev g001 ON g001.codigo = g001detalle.codinasistenciainstrumento_g001 INNER JOIN est_estrainstrumento_s004_redt_ev s004_ev ON g001.codinstrumentos004 = s004_ev.codigo WHERE s004_ev.estrategia = " + estrategia + " AND s004_ev.sesion = " + sesion + " " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }



    public DataTable sesionformacion_pre(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, int estrategia, int sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM est_estra2instrumento_s004_redt s004 INNER JOIN rt_redtematicasede rts on s004.codredtematicasede= rts.codigo  INNER JOIN ins_sede isede on isede.codigo=rts.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE s004.estrategia = " + estrategia + " AND s004.sesion = " + sesion + " " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }



    public DataTable estuinscritossesion_pre(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string estrategia, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM est_inasistenciasinstrumento_g001detalle g001detalle INNER JOIN est_inasistenciasinstrumento_g001 g001 ON g001.codigo = g001detalle.codinasistenciainstrumento_g001 INNER JOIN est_estra2instrumento_s004_redt s004_pre ON g001.codinstrumentos004 = s004_pre.codigo WHERE s004_pre.estrategia = " + estrategia + " AND s004_pre.sesion = " + sesion + " " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    //---------------------- NUEVO CODIGO 14 DE SEPTIEMBRE---------------------- 
    //28) Grupos de investigación infantiles y juveniles que se inscribieron en la convocatoria de Ciclón 
    public DataTable gpinscritosconvocatoriaciclon(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string estrategia)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT(eeb1.codproyectosede) FROM est_estra1bitacora1 eeb1 INNER JOIN pro_proyectosede pps ON pps.codigo = eeb1.codproyectosede INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE eeb1.estrategia = " + estrategia + " " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    //29) Grupos de investigación con recursos aportados por  Ciclón
    public DataTable gprecursosaprortados(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string estrategia)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT(eeig7.codproyecto) FROM  est_estra2instrumento_g007 eeig7 INNER JOIN pro_proyectosede pps ON pps.codigo = eeig7.codproyecto INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE eeig7.estrategia = " + estrategia + " " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    //30) Total grupos de investigación con registro de avance del presupuesto
    public DataTable gpregistroavance(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT(eeb4p1.codproyectosede) FROM est_estra1bitacora4punto1 eeb4p1 INNER JOIN pro_proyectosede pps ON pps.codigo = eeb4p1.codproyectosede INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento  " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    //31)  Informes de investigación elaborados por los grupos de investigación infantiles y juveniles
    public DataTable informesinvelavoradosgp(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT(s003.codproyectosede) FROM est_estra1instrumento_s003 s003 INNER JOIN pro_proyectosede pps ON pps.codigo = s003.codproyectosede INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable resumenesproyectoinv(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT(s008.codproyectosede) FROM est_estra1instrumento_s008 s008 INNER JOIN pro_proyectosede pps ON pps.codigo = s008.codproyectosede INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio  INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public bool editarCodUsuarioRepositorioS002(string codusuario, string codusuario2)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_repositorioasesor_s002 SET codusuario=" + codusuario2 + " WHERE codusuario=" + codusuario + ";";
        conector.CrearComando(consulta);
        //conector.AsignarParametroCadena("@codusuario", codusuario);
        //conector.AsignarParametroCadena("@codusuario2", codusuario2);
        return conector.guardadata();

    }

    public bool editarCodUsuarioRepositorioPreestructurados(string codusuario, string codusuario2)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_repositorioasesor_preestructurados SET codusuario=" + codusuario2 + " WHERE codusuario=" + codusuario + ";";
        conector.CrearComando(consulta);
        //conector.AsignarParametroCadena("@codusuario", codusuario);
        //conector.AsignarParametroCadena("@codusuario2", codusuario2);
        return conector.guardadata();

    }

    public bool editarCodUsuarioRepositorioEspacioApro(string codusuario, string codusuario2)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_repositorioasesor_espaciosapropiacion SET codusuario=" + codusuario2 + " WHERE codusuario=" + codusuario + ";";
        conector.CrearComando(consulta);
        //conector.AsignarParametroCadena("@codusuario", codusuario);
        //conector.AsignarParametroCadena("@codusuario2", codusuario2);
        return conector.guardadata();

    }

    public bool editarCodUsuarioRepositorioG006_Estra1(string codusuario, string codusuario2)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_repositorioasesor_g006_estra1 SET codusuario=" + codusuario2 + " WHERE codusuario=" + codusuario + ";";
        conector.CrearComando(consulta);
        //conector.AsignarParametroCadena("@codusuario", codusuario);
        //conector.AsignarParametroCadena("@codusuario2", codusuario2);
        return conector.guardadata();

    }

    public bool editarCodUsuarioG006_Estra1(string codasesorcoordinador, string codasesorcoordinador2)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra1instrumento_g006 SET codasesorcoordinador="  + codasesorcoordinador2 + " WHERE codasesorcoordinador="  +codasesorcoordinador + ";";
        conector.CrearComando(consulta);
        //conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        //conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador2);
        return conector.guardadata();

    }

    public bool editarCodUsuarioG007(string codasesorcoordinador, string codasesorcoordinador2)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra2instrumento_g007 SET codasesorcoordinador=" + codasesorcoordinador2 + " WHERE codasesorcoordinador=" + codasesorcoordinador + ";";
        conector.CrearComando(consulta);
        //conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        //conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador2);
        return conector.guardadata();

    }

    public bool editarCodUsuarioBitacora4punto1(string codasesorcoordinador, string codasesorcoordinador2)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra1bitacora4_1 SET codasesor=" + codasesorcoordinador2 + " WHERE codasesor=" + codasesorcoordinador + ";";
        conector.CrearComando(consulta);
        //conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        //conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador2);
        return conector.guardadata();

    }

    public bool editarCodUsuarioS002(string codasesorcoordinador, string codasesorcoordinador2)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra2instrumento_s002 SET codasesor=" + codasesorcoordinador2 + " WHERE codasesor=" + codasesorcoordinador + ";";
        conector.CrearComando(consulta);
        //conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        //conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador2);
        return conector.guardadata();

    }

    public DataRow buscarAnioParticipacionFerias(string codsede)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codanio FROM est_estra1participantesferiasdocentes pfd inner join est_estra1participantesferias pf on pf.codigo=pfd.codparticipantesferias inner join ins_gradodocente gd on gd.cod=pfd.codgradodocente WHERE pf.codsede=@codsede limit 1";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataRow buscarParticipacionFerias(string codsede, string codanio)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT 1 FROM est_estra1participantesferias WHERE codanio=@codanio and codsede=@codsede";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@codanio", codanio);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable loadProyectosLineaTematica(string codarea)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT iin.nombre as nombreins, iin.dane, isede.nombre as nombresede, isede.dane as danesede,  gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento, pps.nombregrupo, a.nombre as area, li.nombre as tipo FROM pro_proyectosede pps INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento inner join pro_areas a on a.codigo=pps.codarea inner join pro_linea_investigacion li on li.codigo=codlineainvestigacion WHERE pps.codarea=@codarea";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codarea", codarea);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarListadoConectividad()
    {
        Conexion conectar = new Conexion();
        string consulta = "select m.nombre as nombremunicipio, c.* from est_conectividad c inner join geo_municipios m on c.codmunicipio=m.cod order by m.nombre ASC";
        conectar.CrearComando(consulta);

        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return datos;
    }

    public DataTable esturedtematicasxanio(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string aniored)
    {
        string where = "";
        string where2 = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;
                where2 = " WHERE  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;
                        where2 = where2 + " AND  gmun.cod = " + codmunicipio;
                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;
                                where2 = where2 + " AND  iin.codigo = " + codinstitucion;
                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                        where2 = where2 + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        string codanio;
        if (aniored == "2017")
        {
            codanio = "2";
        }
        else
        {
            codanio = "1";
        }
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT(rtm.codestumatricula) as estured FROM rt_redtematicamatricula rtm INNER JOIN rt_redtematicasede rs on rtm.codredtematicasede=rs.codigo INNER JOIN ins_estumatricula em on em.codigo=rtm.codestumatricula INNER JOIN ins_sede  isede on  isede.codigo=rs.codsede INNER JOIN ins_institucion iin on iin.codigo= isede.codinstitucion INNER JOIN geo_municipios gmun on gmun.cod=iin.codmunicipio INNER JOIN geo_departamentos gdep on gdep.cod=gmun.coddepartamento WHERE rs.aniored = '" + aniored + "' AND em.codanio = " + codanio + "  " + where + "  UNION SELECT DISTINCT(ppm.codestumatricula)  AS estugrupoinv  FROM pro_proyectomatricula ppm  INNER JOIN pro_proyectosede pps ON pps.codigo = ppm.codproyectosede  INNER JOIN ins_sede isede ON isede.codigo = pps.codsede   INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion   INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio   INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where2;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable sederedtematicas(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string aniored)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT rtms.* FROM rt_redtematicasede rtms INNER JOIN ins_sede isede ON isede.codigo = rtms.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE rtms.aniored = " + aniored + " " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable maestrosxanio(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string anio)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;
                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;
                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        string codanio;
        if (anio == "2017")
        {
            codanio = "2";
        }
        else
        {
            codanio = "1";
        }
        Conexion conector = new Conexion();
        string consulta = "SELECT dg.identificacion, concat_ws(' ',d.nombre,d.apellido) as nombre, isede.nombre as sede, iin.nombre as institucion, gmun.nombre as municipio FROM ins_gradodocente dg INNER JOIN ins_docente d ON d.identificacion = dg.identificacion INNER JOIN ins_sede isede ON isede.codigo = dg.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE dg.codanio = " + codanio + "  " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    public DataTable maestrosmatriculadosestra2(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string codanio)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = " SELECT igd.* FROM ins_gradodocente igd INNER JOIN ins_sede isede ON isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codanio = '" + codanio + "' " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    //-------------------- NUEVO CODIGO 02 DE OCTUBRE  ----------------
    //Sesión de formación No. 1
    public DataTable sesionformacionMaestros(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string estrategia, string momento, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT(eis004.codsede) FROM est_estra2instrumento_s004_sede eis004 INNER JOIN ins_sede isede ON isede.codigo = eis004.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE eis004.estrategia = " + estrategia + " AND momento = " + momento + " AND sesion = " + sesion + " " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    public DataTable asistentesSesionMaestros(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string estrategia, string momento, string sesion, string jornada)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT g001dd.*,  ess.codsede  FROM est_inasistenciasinstrumento_g001detalle_doc g001dd INNER JOIN est_inasistenciasinstrumento_g001_doc gdoc ON g001dd.codinasistenciainstrumento_g001_doc = gdoc.codigo INNER JOIN est_estra2instrumento_s004_sede ess ON gdoc.codinstrumento_s004_sede = ess.codigo INNER JOIN ins_sede isede ON isede.codigo = ess.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE ess.estrategia = " + estrategia + " AND ess.momento = " + momento + " AND ess.sesion = " + sesion + " AND ess.jornada =  " + jornada + " " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    // Asistentes a la sesión de asesoría a grupos infantiles y juveniles
    public DataTable asistentesgruposinv(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT(codgradodocente) FROM pro_proyectodocente ppd INNER JOIN pro_proyectosede pps ON pps.codigo = ppd.codproyectosede INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    // Maestros y maestras lideres de las redes temáticas formados en los lineamientos del Programa Ciclón y su propuesta metodológica
    public DataTable maestrosredestematicas(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT codgradodocente FROM rt_redtematicadocente rrd INNER JOIN rt_redtematicasede rrs ON rrs.codigo = rrd.codredtematicasede INNER JOIN ins_sede isede ON isede.codigo = rrs.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    // Sesión de jornadas de formación realizadas en la sede
    public DataTable sesionjornadasxsede(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string momento, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT ees.codigo FROM est_estra2instrumento_s004_sede ees INNER JOIN ins_sede isede ON isede.codigo = ees.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE ees.momento = " + momento + " AND ees.sesion = " + sesion + "  " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    // Asistentes a la sesión de formación No. 1/formación virtual (4 horas)
    public DataTable asistentessesionvirtual(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT eesv.codigo FROM est_estra2sesionvirtual eesv INNER JOIN ins_sede isede ON isede.codigo = eesv.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE eesv.sesion = " + sesion + "  " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }



    //Sesiones de formación evaluadas y subidas a la plataforma de Ciclón
    public DataTable sesionesformacionevaluadas(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string estrategia, string momento, string sesion)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT ers4.codigo FROM est_repositorioasesor_s004sedes ers4 INNER JOIN est_estra2instrumento_s004_sede ees ON ees.codigo = ers4.codinstrumento INNER JOIN ins_sede isede ON isede.codigo = ees.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE  ers4.actividad = 'Formato de evaluación' AND ees.estrategia = " + estrategia + " AND ees.momento = " + momento + " AND ees.sesion = " + sesion + " " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    // Proyectos de investigación de maestros y maestras con avance en su elaboración
    public DataTable proyectosinvestigacionmaestros(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT(codgrupoinvestigaciondocentes) FROM est_estra2instrumento_s003 " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    // Maestros y maestras  acompañantes de los grupos de investigación infantiles y juveniles pero que no están en la estrategia No 2. de formación
    public DataTable maesstrosgpNOestrategia2(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT(codgrupoinvestigaciondocentes) FROM est_estra2instrumento_s003 " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarEvidenciasEspacioApropiacion(string codapropiacion, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM ep_espaciosapropiacion_evi rc inner join usu_usuario u on u.cod=rc.codusuario WHERE codapropiacion=@codapropiacion and codusuario=@codusuario  ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codapropiacion", codapropiacion);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public bool eliminardetalledocentesinasistencia(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_inasistenciasinstrumento_g001detalle WHERE codinasistenciainstrumento_g001=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();

    }

    public bool eliminardedocentesinasistencia(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_inasistenciasinstrumento_g001 WHERE codigo=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();

    }

    public DataRow noasesorias()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT SUM(noasesoria) noasesorias FROM est_estra2instrumento_s002 WHERE estrategia = 1";
        conector.CrearComando(consulta);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;
    }

    //Asesorías realizadas a los grupos de investigación infantiles y juveniles para elaboración del informe
    public DataTable asesoriasgpinforme(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE  gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;

                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT  DISTINCT(codproyecto), gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, pps.nombregrupo, s002.* FROM est_estra2instrumento_s002 s002 INNER JOIN pro_proyectosede pps ON pps.codigo = s002.codproyecto INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataRow asistentessesionasesoria()
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT SUM(noasistentes) AS total FROM est_estra2instrumento_s002 WHERE estrategia = 1 AND momento = 4 AND sesion = 0";
        conector.CrearComando(consulta);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    // Asesorías a los grupos infantiles y juveniles evaluadas y subidas a la plataforma de Ciclón
    public DataTable asesoriasgpevaluadasm4(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;
                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, pps.nombregrupo, ers002.* FROM est_repositorioasesor_s002 ers002 INNER JOIN est_estra2instrumento_s002 s002 ON s002.codigo = ers002.codestras002 INNER JOIN pro_proyectosede pps ON pps.codigo = s002.codproyecto INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE actividad = 'Registro de la asesoría' AND s002.momento = 4 AND s002.sesion = 0 AND s002.estrategia = 1 " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    //4. Grupos con soporte de ejecución del presupuesto
    public DataTable gpsoportepresupuesto(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        string where = "";
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " WHERE gdep.cod = " + coddepartamento;

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  iin.codigo = " + codinstitucion;
                                if (codsede != "")
                                {
                                    if (codsede != "null")
                                    {
                                        where = where + " AND  isede.codigo = " + codsede;
                                    }
                                }
                            }
                        }
                    }
                }
            }

        }
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT(eb4p1.codbitacora4punto1), gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, eb4p1.*, b4p1.*  FROM est_estra1bitacora4punto1_evi eb4p1 INNER JOIN est_estra1bitacora4punto1 b4p1 ON b4p1.codigo = eb4p1.codbitacora4punto1 INNER JOIN pro_proyectosede pps ON pps.codigo = b4p1.codproyectosede INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    //5. Publicaciones impresas y/o digitales de las experiencias investigativas 
    public DataTable publicacionesimpresas()
    {
        string where = "";

        Conexion conector = new Conexion();
        string consulta = "SELECT eepg.* FROM est_estra1publicaciones_guias eepg";


        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public bool updateProyectoSede(string codigo, string codlineainvestigacion)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE pro_proyectosede SET codlineainvestigacion=@codlineainvestigacion WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codlineainvestigacion", codlineainvestigacion);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

}
