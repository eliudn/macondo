using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Cliente
/// </summary>
public class Institucion
{
	public Institucion()
	{
		//
		// TODO: Agregar aquí la lógica del constructor prueba de cambios en la nube
		//
	}
	public DataTable cargarGrupoInvestigacionxCodSede(string codsede)
    {
        Conexion conector = new Conexion();
        string consulta = "select ps.*, a.identificacion from pro_proyectosede ps left join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor where ps.codsede=@codsede order by ps.nombregrupo asc ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
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
    public DataTable cargarTodoRedTematicayGrupo()
    {
        Conexion conector = new Conexion();
        string consulta = "select rts.codigo as codredtematicasede, CONCAT_WS(' ',rt.nombre,rts.consecutivogrupo) as nombre from rt_redtematicasede rts inner join rt_redtematica rt on rt.codigo=rts.codredtematica;";
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
    public DataTable cargarTodasInstituciones()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * From ins_institucion";
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
    public DataTable cargarTodasSedes()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * From ins_sede";
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
    public DataTable cargarTodoGrupoInvestigacion()
    {
        Conexion conector = new Conexion();
        string consulta = "select ps.*, a.identificacion from pro_proyectosede ps left join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor order by ps.nombregrupo asc ";
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
    public DataTable cargarTodoLineaInvestigacion()
    {
        Conexion conector = new Conexion();
        string consulta = "select * from pro_linea_investigacion";
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
    public DataTable cargarLineaInvestigacionxGrupo(string codgrupoInvestigacion)
    {
        Conexion conector = new Conexion();
        string consulta = "select ps.codigo as codproyectosede, ps.codasesorcoordinador, lv.codigo, lv.nombre from pro_proyectosede ps inner join pro_linea_investigacion lv on ps.codlineainvestigacion=lv.codigo where ps.codigo= '" + codgrupoInvestigacion + "'";
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
    public DataTable cargarGruposInvestigacionBitacoras(string codsede, string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM pro_proyectosede WHERE codsede='" + codsede + "' AND codasesorcoordinador='" + codasesorcoordinador + "' ORDER BY nombregrupo ASC";
        conector.CrearComando(consulta);
        //conector.AsignarParametroCadena("@codsede", codsede);
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
    public Boolean borrarEvidenciaFerias(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositorioferia WHERE cod=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }
    public DataRow buscarEvidenciaFerias(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_repositorioferia WHERE cod=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public DataRow buscarDocenteMatriculado(string identificacion, string codsede, string codanio)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM ins_gradodocente WHERE identificacion=@identificacion and codanio=@codanio and codsede=@codsede;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@codanio", codanio);
        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public DataTable cargarEvidenciasGruposFerias(string codsede)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, CONCAT_WS(' ',u.pnombre,u.papellido) as nombreusuario FROM est_repositorioferia r inner join usu_usuario u on u.cod=r.codusuario WHERE codsede=@codsede ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
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
    public Boolean agregarArchivoRespositorioFerias(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string codsede)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO est_repositorioferia (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,codsede) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@codsede)";

        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroDouble("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fechacreado);
        conector.AsignarParametroCadena("@codsede", codsede);

        bool resp = conector.guardadata();
        return resp;
    }
    public DataRow buscarEvidenciaGrupoInvestigacion(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM gr_repositorio WHERE cod=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public Boolean borrarEvidenciaGrupoInvestigacion(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM gr_repositorio WHERE cod=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }
    public bool agregarConvocatoriaGrupos(string asesor, string municipio, string institucion, string sede, string docentes, string pregunta, string estudiantes, string linea, string area)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO gr_convocatoriasgrupos (asesor,municipio,institucion,sede,docentes,pregunta,estudiantes,linea,area) VALUES (@asesor,@municipio,@institucion,@sede,@docentes,@pregunta,@estudiantes,@linea,@area)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@asesor", asesor);
        conector.AsignarParametroCadena("@municipio", municipio);
        conector.AsignarParametroCadena("@institucion", institucion);
        conector.AsignarParametroCadena("@sede", sede);
        conector.AsignarParametroCadena("@docentes", docentes);
        conector.AsignarParametroCadena("@pregunta", pregunta);
        conector.AsignarParametroCadena("@estudiantes", estudiantes);
        conector.AsignarParametroCadena("@linea", linea);
        conector.AsignarParametroCadena("@area", area);
        return conector.guardadata();
    }
    public DataTable cargarEvidenciasGruposInvestigacion(string codconvocatoriasgrupos)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, CONCAT_WS(' ',u.pnombre,u.papellido) as nombreusuario FROM gr_repositorio r inner join usu_usuario u on u.cod=r.codusuario WHERE codconvocatoriasgrupos=@codconvocatoriasgrupos ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codconvocatoriasgrupos", codconvocatoriasgrupos);
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
   
    public DataTable cargarGruposInvestigacion()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM gr_convocatoriasgrupos ORDER BY municipio ASC";
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

    public DataTable cargarListaEntregaTablets()
    {
        Conexion conector = new Conexion();
        string consulta = "select t.*, s.nombre as sede, i.nombre as institucion, m.nombre as municipio from est_estra4entregatablets t left join ins_sede s on s.dane=t.dane inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio order by m.nombre";
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

    public DataTable cargarListaEntregaTabletsSUM()
    {
        Conexion conector = new Conexion();
        string consulta = "select sum(t.total) as total from est_estra4entregatablets t ";
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

    public DataTable cargarMatriculadosEstra5()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM est_estrainstrumento_s004coord_matriculados ORDER BY apellido ASC";
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
    public DataTable cargarGruposInvestigacionConvocatoriasxMunicipios()
    {
        Conexion conector = new Conexion();
        string consulta = "select count(*) total, municipio  from gr_convocatoriasgrupos group by municipio order by municipio";
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
    public DataTable cargarGruposInvestigacionConvocatoriasxInstituciones()
    {
        Conexion conector = new Conexion();
        string consulta = "select count(*) total, municipio, institucion  from gr_convocatoriasgrupos group by municipio, institucion order by municipio, institucion";
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
    public DataTable cargarGruposInvestigacionConvocatoriasxSedes()
    {
        Conexion conector = new Conexion();
        string consulta = "select count(*) total, municipio, institucion, sede  from gr_convocatoriasgrupos group by municipio, institucion, sede order by municipio, institucion, sede";
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
    public Boolean agregarArchivoRespositorioEstrategia(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string codconvocatoriasgrupos)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO gr_repositorio (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,codconvocatoriasgrupos) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@codconvocatoriasgrupos)";

        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroDouble("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fechacreado);
        conector.AsignarParametroCadena("@codconvocatoriasgrupos", codconvocatoriasgrupos);

        bool resp = conector.guardadata();
        return resp;
    }
    public DataTable cargarTipoGrupo()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM ins_tipogrupo ORDER BY nombre ASC";
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

    public DataTable cargarciudad()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM geo_municipios WHERE coddepartamento='20' ORDER BY nombre ASC";
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

    public DataTable cargarDepartamento()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM geo_departamentos d ORDER BY d.nombre ASC";
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
    public DataTable cargarDepartamentoMagdalena()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM geo_departamentos d where cod='20' ORDER BY d.nombre ASC";
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

    public DataTable cargarciudadxDepartamento(string codddepartamento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT m.cod,m.nombre FROM geo_municipios m inner join geo_departamentos d on m.coddepartamento=d.cod WHERE d.cod=@codddepartamento ORDER BY m.nombre ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codddepartamento", codddepartamento);
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
    public DataTable cargarRectores()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, CONCAT_WS(' ', identificacion,'-', nombre, apellido) as nombrecompleto FROM ins_rector ORDER BY apellido ASC";
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
    public DataRow buscarRectorEnInstitucion(string idrector)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM ins_institucion WHERE idrector=@idrector ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@idrector", idrector);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscarEstumatriculaxEstudiante(string id)
    {
        Conexion conector = new Conexion();
        string consulta = "select em.codigo as codestumatricula, * from ins_estudiante e inner join ins_estumatricula em on e.codigo=em.codestudiante WHERE identificacion=@id ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@id", id);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscartipoGrupo(string nombre)
    {
        Conexion conector = new Conexion();
        string consulta = "select  * from ins_tipogrupo e inner join ins_estumatricula em on e.codigo=em.codestudiante WHERE nombre ilike '%" + nombre + "%' ";
        conector.CrearComando(consulta);
        //conector.AsignarParametroCadena("@nombre", nombre);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscarDatosRector(string idrector)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM ins_rector WHERE identificacion=@idrector ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@idrector", idrector);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public bool editarGradoDocenteSede(string identificacion, string codsede, string codanio)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE ins_gradodocente SET  codsede=@codsede  WHERE identificacion=@identificacion AND codanio=@codanio ;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@codanio", codanio);
        return conector.guardadata();
    }
    public bool editarDocenteNombres(string identificacion, string nombre, string apellido)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE ins_docente SET  nombre=@nombre, apellido=@apellido  WHERE identificacion=@identificacion;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@apellido", apellido);
        return conector.guardadata();
    }
    public bool editarDatoInstitucionRector(string idrector, string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE ins_institucion SET  idrector = @idrector  WHERE codigo = @codigo ;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        conector.AsignarParametroCadena("@idrector", idrector);
       
        return conector.guardadata();
    }
    public DataRow buscarDepartamentoxCiudad(string codciudad)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT d.cod,d.nombre FROM geo_municipios m inner join geo_departamentos d on m.coddepartamento=d.cod WHERE m.cod=@codciudad ORDER BY d.nombre ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codciudad", codciudad);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataTable cargarPropiedadJuridica()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM ins_propiedadjuridica ";
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

    public DataRow buscarInstitucionxNit(string dane)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo FROM ins_institucion c  WHERE c.dane=@dane";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@dane", dane);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscarInstitucionxNitTodo(string dane)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM ins_institucion c  WHERE c.dane=@dane";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@dane", dane);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscarSedexNit(string dane)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo FROM ins_sede c  WHERE c.dane=@dane";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@dane", dane);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscarSedexCod(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo FROM ins_sede c  WHERE c.codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscarDatosRectorInstitucion(string identificacion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo FROM ins_rector c  WHERE c.identificacion=@identificacion";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscarDatosRectorConSuInstitucion(string dane)
    {
        Conexion conector = new Conexion();
        string consulta = "select i.*, r.nombre as nrector, r.apellido as arector, r.identificacion, r.sexo, r.fecha_nacimiento, r.sexo, r.celular as celerector, r.telefono as telerector, r.email as cerector, r.codtipodocumento, r.codigo as codrector from ins_rector r inner join ins_institucion i on r.identificacion=i.idrector where i.dane=@dane";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@dane", dane);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscarTipoInstitucionxNombre(string nombre)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM ins_tipoinstitucion c  WHERE c.nombre ilike '%"+nombre+"%'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscarClaseInstitucionxNombre(string nombre)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM ins_claseinstitucion c  WHERE c.nombre ilike '%"+ nombre +"%'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscarZonaxNombre(string nombre)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM ins_zona c  WHERE c.nombre ilike '%"+nombre+"%'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscarPropiedadJuridicaxNombre(string nombre)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM ins_propiedadjuridica c  WHERE c.nombre ilike '%" + nombre + "%'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscarUltimaInstitucionIngresada()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo FROM ins_institucion c  ORDER BY codigo DESC LIMIT 1";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow buscarEtniaxNombre(string nombre)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo FROM ins_etnia c  WHERE c.nombre=@nombre";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public long agregarInstitucion(String dane,string nombre, String idrector, string codtipoinstitucion, string telefono, string fax, string email, string codclaseinstitucion)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO ins_institucion (nombre, dane,idrector,telefono, fax,email,codtipoinstitucion,codclaseinstitucion)  " +
            "VALUES (@nombre,@dane,@idrector,@telefono,@fax,@email,@codtipoinstitucion,@codclaseinstitucion);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@dane", dane);
        conector.AsignarParametroCadena("@idrector", idrector);
        conector.AsignarParametroCadena("@telefono", telefono);
        conector.AsignarParametroCadena("@fax", fax);
        conector.AsignarParametroCadena("@email", email);
        conector.AsignarParametroCadena("@codtipoinstitucion", codtipoinstitucion);
        conector.AsignarParametroCadena("@codclaseinstitucion", codclaseinstitucion);
        long resp = conector.guardadataid();
        return resp;
    }
    public bool agregarSedexInstitucion(string nombre, string dane, string consesede, string direccion, string codzona, string codmunicipio, string sede, string codinstitucion)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO ins_sede (nombre,dane,direccion,codinstitucion,codzona,codmunicipio,consesede,sede) VALUES (@nombre,@dane,@direccion,@codinstitucion,@codzona,@codmunicipio,@consesede,@sede)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@dane", dane);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@consesede", consesede);
        conector.AsignarParametroCadena("@direccion", direccion);
        conector.AsignarParametroCadena("@codzona", codzona);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        conector.AsignarParametroCadena("@sede", sede);
        conector.AsignarParametroCadena("@codinstitucion", codinstitucion);
        return conector.guardadata();
    }

    public bool agregarInstitucionbool(String dane, string nombre, String idrector, string codtipoinstitucion, string telefono, string fax, string email, string codclaseinstitucion)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO ins_institucion (nombre, dane,idrector,telefono, fax,email,codtipoinstitucion,codclaseinstitucion)  " +
            "VALUES (@nombre,@dane,@idrector,@telefono,@fax,@email,@codtipoinstitucion,@codclaseinstitucion);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@dane", dane);
        conector.AsignarParametroCadena("@idrector", idrector);
        conector.AsignarParametroCadena("@telefono", telefono);
        conector.AsignarParametroCadena("@fax", fax);
        conector.AsignarParametroCadena("@email", email);
        conector.AsignarParametroCadena("@codtipoinstitucion", codtipoinstitucion);
        conector.AsignarParametroCadena("@codclaseinstitucion", codclaseinstitucion);
        return conector.guardadata();
    }
    public bool agregarRector(string nombre, string apellido, string identificacion, string sexo, string fecha_nacimiento, string telefono, string email, string codtipodocumento, string celular)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO ins_rector (nombre,apellido,identificacion,sexo,fecha_nacimiento,telefono,email,codtipodocumento,celular) VALUES (@nombre,@apellido,@identificacion,@sexo,@fecha_nacimiento,@telefono,@email,@codtipodocumento,@celular)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre.ToUpper());
        conector.AsignarParametroCadena("@apellido", apellido.ToUpper());
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@sexo", sexo);
        conector.AsignarParametroCadena("@fecha_nacimiento", fecha_nacimiento);
        conector.AsignarParametroCadena("@telefono", telefono);
        conector.AsignarParametroCadena("@email", email);
        conector.AsignarParametroCadena("@codtipodocumento", codtipodocumento);
        conector.AsignarParametroCadena("@celular", celular);
        return conector.guardadata();
    }
    public DataRow agregarInstitucionPG(String dane, string nombre, String idrector, string codtipoinstitucion, string telefono, string fax, string email, string codclaseinstitucion, string direccion, string web, string codzona, string codmunicipio, string nrosedesactivas, string nrosedesinactivas, string codpropiedadjuridica)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO ins_institucion (nombre, dane,idrector,telefono, fax,email,codtipoinstitucion,codclaseinstitucion,direccion,web,codmunicipio,codzona,nrosedesactivas,nrosedesinactivas,codpropiedadjuridica)  " +
            "VALUES (@nombre,@dane,@idrector,@telefono,@fax,@email,@codtipoinstitucion,@codclaseinstitucion,@direccion,@web,@codmunicipio,@codzona,@nrosedesactivas,@nrosedesinactivas,@codpropiedadjuridica) RETURNING codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@dane", dane);
        conector.AsignarParametroCadena("@idrector", idrector);
        conector.AsignarParametroCadena("@telefono", telefono);
        conector.AsignarParametroCadena("@fax", fax);
        conector.AsignarParametroCadena("@email", email);
        conector.AsignarParametroCadena("@codtipoinstitucion", codtipoinstitucion);
        conector.AsignarParametroCadena("@codclaseinstitucion", codclaseinstitucion);

        conector.AsignarParametroCadena("@direccion", direccion);
        conector.AsignarParametroCadena("@web", web);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        conector.AsignarParametroCadena("@codzona", codzona);
        conector.AsignarParametroCadena("@nrosedesactivas", nrosedesactivas);
        conector.AsignarParametroCadena("@nrosedesinactivas", nrosedesinactivas);
        conector.AsignarParametroCadena("@codpropiedadjuridica", codpropiedadjuridica);
        DataRow dato = conector.guardadataidPG();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataTable cargarInstitucionesWhere(string where)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT s.codigo as cod, s.dane, s.nombre, i.idrector, m.nombre as nommunicipio, s.telefono, s.email,ti.nombre as tipoins, ci.nombre as claseins,  z.nombre as ruralurbana FROM ins_institucion i INNER JOIN ins_tipoinstitucion ti ON ti.codigo=i.codtipoinstitucion INNER JOIN ins_claseinstitucion ci ON ci.codigo=i.codclaseinstitucion INNER JOIN ins_sede s ON s.codinstitucion=i.codigo INNER JOIN ins_zona z on z.codigo=s.codzona INNER JOIN geo_municipios m on m.cod=i.codmunicipio " + where;
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

    public DataTable cargarZonas()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * From ins_zona";
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

    public DataTable cargarEtnia()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * From ins_etnia";
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

    public DataRow buscarAnioON()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo FROM ins_anio WHERE estado='On' LIMIT 1";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataTable cargarGrados()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * From ins_grado";
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

    /*  Agregar Institución en Línea Base */

    public DataRow agregarRegistroInstitucionalLineaBase(String codinstitucion, string nomcoordinador, string cargo, string fecharegistro, string codsede, string codasesor, string codgradodocente)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO lbase_reginstitucion (codinstitucion, nomcoordinador,cargo,fecharegistro,codsede, codgradodocente, codasesor)  " +
            "VALUES (@codinstitucion,@nomcoordinador,@cargo,@fecharegistro,@codsede,@codgradodocente,@codasesor) RETURNING codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstitucion", codinstitucion);
        conector.AsignarParametroCadena("@nomcoordinador", nomcoordinador.ToUpper());
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@fecharegistro", fecharegistro);
        conector.AsignarParametroCadena("@cargo", cargo);
        conector.AsignarParametroCadena("@codasesor", codasesor);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        DataRow dato = conector.guardadataidPG();
        if (dato != null)
            return dato;
        else
            return null;
    }

    /* Cargar Respuestas Linea Base Instrumento 02 */
    public DataRow cargarRespuestasInstrumento02(string codinstitucion, string codsede, string codasesor, string codgradodocente)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM lbase_reginstitucion WHERE codinstitucion=@codinstitucion AND codsede=@codsede AND codasesor=@codasesor AND codgradodocente=@codgradodocente LIMIT 1";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@codinstitucion", codinstitucion);
        conector.AsignarParametroCadena("@codasesor", codasesor);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataTable cargarRespuestasCerradasxInstrumento02(string codreginstitucion, string codpregunta, string codsubpregunta, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "select respuesta from lbase_respuesta where codreginstitucion=@codreginstitucion and codpregunta=@codpregunta and codsubpregunta=@codsubpregunta and codinstrumento=@codinstrumento ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codreginstitucion", codreginstitucion);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codsubpregunta", codsubpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
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
    public DataRow cargarRespuestasAbiertasxIntrumento02(string codreginstitucion, string codpregunta, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM lbase_respuestaabierta WHERE codreginstitucion=@codreginstitucion AND codpregunta=@codpregunta AND codinstrumento=@codinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codreginstitucion", codreginstitucion);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataTable cargarTipoDocumento()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM con_tipodocumento ORDER BY nombre ASC";
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

    public DataRow buscarDocenteCompleto(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM ins_docente WHERE codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public bool editarDocente(string codtipodocumento, string identificacion, string nombre, string apellido, string sexo, string direccion, string telefono, string fecha_nacimiento, string email)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE ins_docente SET  codtipodocumento = @codtipodocumento ,nombre = @nombre, apellido = @apellido, sexo = @sexo, direccion=@direccion, telefono = @telefono, fecha_nacimiento = @fecha_nacimiento, email = @email  WHERE identificacion = @identificacion ;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codtipodocumento", codtipodocumento);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@apellido", apellido);
        conector.AsignarParametroCadena("@sexo", sexo);
        conector.AsignarParametroCadena("@telefono", telefono);
        conector.AsignarParametroCadena("@direccion", direccion);
        conector.AsignarParametroCadena("@fecha_nacimiento", fecha_nacimiento);
        conector.AsignarParametroCadena("@email", email);
        return conector.guardadata();
    }

    public DataRow buscarSedexInstitucion(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "select s.codigo as codsede, s.nombre as nomsede, i.codigo as codinstitucion, i.nombre as nominstitucion from ins_sede s inner join ins_institucion i on s.codinstitucion=i.codigo where s.codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }





    //other code g006
    public DataRow cargarDatosSede(string idsede)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT isd.codigo, isd.nombre,  isd.dane, isd.direccion, isd.codinstitucion,isd.codzona, isd.codmunicipio, isd.consesede, isd.sede, isd.telefono, isd.email, gm.nombre as nombremunicipio, gdp.nombre as nombredepartamento, gdp.cod as coddepartamento FROM ins_sede isd INNER JOIN geo_municipios gm ON gm.cod = isd.codmunicipio INNER JOIN geo_departamentos gdp ON gdp.cod = gm.coddepartamento WHERE codigo = @idsede";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@idsede", idsede);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataTable cargarGruposInvestigacion(string codsede, string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM pro_proyectosede WHERE codsede='" + codsede + "' AND codasesorcoordinador='" + codasesorcoordinador + "' ORDER BY nombregrupo ASC";
        conector.CrearComando(consulta);
        //conector.AsignarParametroCadena("@idsede", idsede);
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

    public long updateSede(string codigo, string telefono, string email, string direccion)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE ins_sede SET telefono = @telefono, email = @email, direccion = @direccion WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@telefono", telefono);
        conector.AsignarParametroCadena("@email", email);
        conector.AsignarParametroCadena("@direccion", direccion);
        conector.AsignarParametroCadena("@codigo", codigo);
        long resp = conector.guardadataid();
        return resp;
    }

    public DataRow procinsertIntrumento(string fechaentregamaterial, string codsede, string nombrequienrecibe, string codestracoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra2instrumento_g006 (codestracoordinador,fechaentregamaterial,codsede,nombrequienrecibe) VALUES(@codestracoordinador,@fechaentregamaterial,@codsede,@nombrequienrecibe) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
        conector.AsignarParametroCadena("@fechaentregamaterial", fechaentregamaterial);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@nombrequienrecibe", nombrequienrecibe);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow procinsertIntrumentoEstra1(string fechaentregamaterial, string codsede, string nombrequienrecibe, string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra1instrumento_g006 (codasesorcoordinador,fechaentregamaterial,codsede,nombrequienrecibe) VALUES(@codasesorcoordinador,@fechaentregamaterial,@codsede,@nombrequienrecibe) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@fechaentregamaterial", fechaentregamaterial);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@nombrequienrecibe", nombrequienrecibe);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow procinsertIntrumentoEstra4(string fechaentregamaterial, string codsede, string nombrequienrecibe, string codestracoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra4instrumento_g006 (codestracoordinador,fechaentregamaterial,codsede,nombrequienrecibe) VALUES(@codestracoordinador,@fechaentregamaterial,@codsede,@nombrequienrecibe) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
        conector.AsignarParametroCadena("@fechaentregamaterial", fechaentregamaterial);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@nombrequienrecibe", nombrequienrecibe);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow cargarDatosInstrumento(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo,codestracoordinador,codsede,nombrequienrecibe,to_char(fechaentregamaterial, 'DD/MM/YYYY') as fechaentregamaterial FROM est_estra2instrumento_g006 WHERE codigo =  @codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow cargarDatosInstrumentoEstra1(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo,codasesorcoordinador,codsede,nombrequienrecibe,to_char(fechaentregamaterial, 'DD/MM/YYYY') as fechaentregamaterial FROM est_estra1instrumento_g006 WHERE codigo =  @codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow cargarDatosInstrumentoEstra4(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo,codestracoordinador,codsede,nombrequienrecibe,to_char(fechaentregamaterial, 'DD/MM/YYYY') as fechaentregamaterial FROM est_estra4instrumento_g006 WHERE codigo =  @codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public long updateInstrumento(string fechaentregamaterial, string nombrequienrecibe, string codigoinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra2instrumento_g006 SET nombrequienrecibe = @nombrequienrecibe, fechaentregamaterial = @fechaentregamaterial WHERE codigo = @codigoinstrumento;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombrequienrecibe", nombrequienrecibe);
        conector.AsignarParametroCadena("@fechaentregamaterial", fechaentregamaterial);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        long resp = conector.guardadataid();
        return resp;
    }

    public long updateInstrumentoEstra1(string fechaentregamaterial, string nombrequienrecibe, string codigoinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra1instrumento_g006 SET nombrequienrecibe = @nombrequienrecibe, fechaentregamaterial = @fechaentregamaterial WHERE codigo = @codigoinstrumento;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombrequienrecibe", nombrequienrecibe);
        conector.AsignarParametroCadena("@fechaentregamaterial", fechaentregamaterial);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        long resp = conector.guardadataid();
        return resp;
    }

    public long updateInstrumentoEstra4(string fechaentregamaterial, string nombrequienrecibe, string codigoinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra4instrumento_g006 SET nombrequienrecibe = @nombrequienrecibe, fechaentregamaterial = @fechaentregamaterial WHERE codigo = @codigoinstrumento;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombrequienrecibe", nombrequienrecibe);
        conector.AsignarParametroCadena("@fechaentregamaterial", fechaentregamaterial);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        long resp = conector.guardadataid();
        return resp;
    }

    public DataRow insertMaterial(string codigoinstrumento, string nombrematerial, string cantidad, string estado)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra2instrumento_g006material (codestrainstrumento_g006, nombrematerial, cantidad, estado) VALUES (@codigoinstrumento,@nombrematerial,@cantidad,@estado) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        conector.AsignarParametroCadena("@nombrematerial", nombrematerial);
        conector.AsignarParametroCadena("@cantidad", cantidad);
        conector.AsignarParametroCadena("@estado", estado);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow insertMaterialEstra1(string codigoinstrumento, string nombrematerial, string cantidad, string estado)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra1instrumento_g006material (codestrainstrumento_g006, nombrematerial, cantidad, estado) VALUES (@codigoinstrumento,@nombrematerial,@cantidad,@estado) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        conector.AsignarParametroCadena("@nombrematerial", nombrematerial);
        conector.AsignarParametroCadena("@cantidad", cantidad);
        conector.AsignarParametroCadena("@estado", estado);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow insertMaterialEstra4(string codigoinstrumento, string nombrematerial, string cantidad, string estado, string orden)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra4instrumento_g006material (codestrainstrumento_g006, nombrematerial, cantidad, estado, orden) VALUES (@codigoinstrumento,@nombrematerial,@cantidad,@estado,@orden) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        conector.AsignarParametroCadena("@nombrematerial", nombrematerial);
        conector.AsignarParametroCadena("@cantidad", cantidad);
        conector.AsignarParametroCadena("@estado", estado);
        conector.AsignarParametroCadena("@orden", orden);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public long deleteMaterial(string codigoinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2instrumento_g006material WHERE codestrainstrumento_g006 = @codigoinstrumento;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        long resp = conector.guardadataid();
        return resp;
    }

    public long deleteMaterialEstra1(string codigoinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1instrumento_g006material WHERE codestrainstrumento_g006 = @codigoinstrumento;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        long resp = conector.guardadataid();
        return resp;
    }

    public long deleteMaterialEstra4(string codigoinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra4instrumento_g006material WHERE codestrainstrumento_g006 = @codigoinstrumento;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        long resp = conector.guardadataid();
        return resp;
    }

    public DataTable procloadMaterial(string codigoinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, codestrainstrumento_g006, nombrematerial, cantidad, estado FROM est_estra2instrumento_g006material WHERE codestrainstrumento_g006 = @codigoinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
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

    public DataTable procloadMaterialEstra1(string codigoinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, codestrainstrumento_g006, nombrematerial, cantidad, estado FROM est_estra1instrumento_g006material WHERE codestrainstrumento_g006 = @codigoinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
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

    public DataTable procloadMaterialEstra4(string codigoinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, codestrainstrumento_g006, nombrematerial, cantidad, estado FROM est_estra4instrumento_g006material WHERE codestrainstrumento_g006 = @codigoinstrumento order by orden ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
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

    //code s001
    //funcion para cargar docentes de sede
    public DataTable procloadDocentes(string codsede)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT id.codigo,UPPER(nombre) as nombre,UPPER(apellido) as apellido, id.identificacion, id.sexo, id.fecha_nacimiento, id.telefono, id.direccion, id.email, id.codtipodocumento, id.expedidaen, id.lugarnacimiento, id.celular, id.profesion, id.edad, id.municipiodireccion FROM ins_docente id INNER JOIN ins_gradodocente igd ON id.identificacion = igd.identificacion WHERE igd.codsede = @codsede ORDER BY id.nombre ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
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

    public DataRow procDatosDocente(string identificaciondocente)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo,initcap(nombre) as nombre,initcap(apellido) as apellido,identificacion,sexo,to_char(fecha_nacimiento, 'DD/MM/YYYY') as fecha_nacimiento,telefono,direccion,email,codtipodocumento,expedidaen,lugarnacimiento,municipiodireccion,celular,profesion,edad FROM ins_docente WHERE identificacion =  @identificaciondocente";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificaciondocente", identificaciondocente);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public long procupdateDocente(string codigodocente, string apellidos, string nombres, string expedidaen, string lugarnacimiento, string fechanacimiento, string edad, string direccion, string departamento, string municipio, string telefono, string celular, string email, string profesion)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE ins_docente SET apellido = @apellidos, nombre = @nombres, expedidaen = @expedidaen, lugarnacimiento = @lugarnacimiento, fecha_nacimiento = @fechanacimiento, edad=@edad, direccion=@direccion, municipiodireccion=@municipio, telefono=@telefono, celular=@celular,email=@email, profesion=@profesion  WHERE identificacion = @identificacion;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@apellidos", apellidos);
        conector.AsignarParametroCadena("@nombres", nombres);
        conector.AsignarParametroCadena("@expedidaen", expedidaen);
        conector.AsignarParametroCadena("@lugarnacimiento", lugarnacimiento);
        conector.AsignarParametroCadena("@fechanacimiento", fechanacimiento);
        conector.AsignarParametroCadena("@edad", edad);
        conector.AsignarParametroCadena("@direccion", direccion);
        conector.AsignarParametroCadena("@municipio", municipio);
        conector.AsignarParametroCadena("@telefono", telefono);
        conector.AsignarParametroCadena("@celular", celular);
        conector.AsignarParametroCadena("@email", email);
        conector.AsignarParametroCadena("@profesion", profesion);
        conector.AsignarParametroCadena("@identificacion", codigodocente);
        long resp = conector.guardadataid();
        return resp;
    }

    public DataRow cargardepartamentoxmunicipio(string codmunicipio)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT gd.* FROM geo_municipios gm INNER JOIN geo_departamentos gd ON gd.cod = gm.coddepartamento WHERE gm.cod = @codmunicipio";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow cargarDatosinstitucion(string idinstitucion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM ins_institucion WHERE codigo = @idinstitucion";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@idinstitucion", idinstitucion);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataRow procinsertests001(string introduccion, string propositos, string numeroperfilparticipantes, string metodologia, string criterioevaluacion, string cargo, string informacionadicional, string codestracoordinador, string momento, string sesion, string actividad, string coddocente)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra2instrumento_s001 (codestracoordinador, introduccion, propositos, nroperfilestudiante, metodologia, criterios, iddocente, cargo, infoadicional, momento, sesion, actividad) VALUES (@codestracoordinador, @introduccion, @propositos, @numeroperfilparticipantes, @metodologia, @criterioevaluacion, @coddocente, @cargo, @informacionadicional, @momento, @sesion, @actividad) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
        conector.AsignarParametroCadena("@introduccion", introduccion);
        conector.AsignarParametroCadena("@propositos", propositos);
        conector.AsignarParametroCadena("@numeroperfilparticipantes", numeroperfilparticipantes);
        conector.AsignarParametroCadena("@metodologia", metodologia);
        conector.AsignarParametroCadena("@criterioevaluacion", criterioevaluacion);
        conector.AsignarParametroCadena("@coddocente", coddocente);
        conector.AsignarParametroCadena("@cargo", cargo);
        conector.AsignarParametroCadena("@informacionadicional", informacionadicional);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@actividad", actividad);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow procloadestras001(string coddocente)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, codestracoordinador, introduccion, propositos, nroperfilestudiante, metodologia, criterios, iddocente, cargo, infoadicional, momento, sesion, actividad FROM est_estra2instrumento_s001 WHERE iddocente = @coddocente";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocente", coddocente);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public long procupdateestras001(string codigoestrategia, string introduccion, string propositos, string numeroperfilparticipantes, string metodologia, string criterioevaluacion, string cargo, string informacionadicional)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra2instrumento_s001 SET introduccion = @introduccion, propositos = @propositos, nroperfilestudiante = @numeroperfilparticipantes, metodologia = @metodologia, criterios = @criterioevaluacion, cargo = @cargo, infoadicional = @informacionadicional  WHERE codigo = @codigoestrategia;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);
        conector.AsignarParametroCadena("@introduccion", introduccion);
        conector.AsignarParametroCadena("@propositos", propositos);
        conector.AsignarParametroCadena("@numeroperfilparticipantes", numeroperfilparticipantes);
        conector.AsignarParametroCadena("@metodologia", metodologia);
        conector.AsignarParametroCadena("@criterioevaluacion", criterioevaluacion);
        conector.AsignarParametroCadena("@cargo", cargo);
        conector.AsignarParametroCadena("@informacionadicional", informacionadicional);
        long resp = conector.guardadataid();
        return resp;
    }


    //g008
    public DataTable cargarGruposInvestigacionGroup(string idsede)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT pp.codigo as codigoproyecto, pp.nombre as nombreproyecto FROM pro_proyectosede as ps INNER JOIN pro_proyecto as pp ON ps.codproyecto = pp.codigo WHERE ps.codsede = @idsede  group by pp.codigo,pp.nombre";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@idsede", idsede);
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

    public DataRow procinsertestrag008(string grupoinvestigacion, string firmatesorero, string voboasesor, string fechadiligenciamiento, string codestracoordinador, string estrategia, string momento, string sesion, string actividad)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra2instrumento_g008 (codestracoordinador, codproyecto, firmamaestrotesorero, voboasesor, fechadiligenciamiento,estrategia,momento,sesion,actividad) VALUES (@codestracoordinador, @grupoinvestigacion, @firmatesorero, @voboasesor, @fechadiligenciamiento,@estrategia,@momento,@sesion,@actividad) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
        conector.AsignarParametroCadena("@grupoinvestigacion", grupoinvestigacion);
        conector.AsignarParametroCadena("@firmatesorero", firmatesorero);
        conector.AsignarParametroCadena("@voboasesor", voboasesor);
        conector.AsignarParametroCadena("@fechadiligenciamiento", fechadiligenciamiento);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@actividad", actividad);

        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public long procupdateestrag008(string codigoinstrumento, string grupoinvestigacion, string firmatesorero, string voboasesor, string fechadiligenciamiento, string estrategia, string momento, string sesion, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra2instrumento_g008 SET firmamaestrotesorero = @firmamaestrotesorero, voboasesor = @voboasesor, fechadiligenciamiento = @fechadiligenciamiento WHERE codigo  = @codigoinstrumento;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@firmamaestrotesorero", firmatesorero);
        conector.AsignarParametroCadena("@voboasesor", voboasesor);
        conector.AsignarParametroCadena("@fechadiligenciamiento", fechadiligenciamiento);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@actividad", actividad);
        long resp = conector.guardadataid();
        return resp;
    }

    public DataRow procloadInstrumentoestrag008(string codproyecto)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo,codestracoordinador,codproyecto, firmamaestrotesorero,voboasesor, to_char(fechadiligenciamiento, 'DD/MM/YYYY') AS fechadiligenciamiento FROM est_estra2instrumento_g008 WHERE codproyecto = @codproyecto";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyecto", codproyecto);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public long procdeleteMaterialestrag008(string codigoinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2instrumento_g008material WHERE codestrainstrumento_g008 = @codigoinstrumento;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        long resp = conector.guardadataid();
        return resp;
    }


    public DataRow procinsertMaterialestrag008(string codigoinstrumento, string fechagasto, string nombreproveedor, string descripciongasto, string valorunitario, string valortotal)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra2instrumento_g008material (codestrainstrumento_g008, fechagasto, nombreproveedor, valorunitario, valortotal, descripciongasto) VALUES (@codigoinstrumento,@fechagasto,@nombreproveedor,@valorunitario,@valortotal,@descripciongasto) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        conector.AsignarParametroCadena("@fechagasto", fechagasto);
        conector.AsignarParametroCadena("@nombreproveedor", nombreproveedor);
        conector.AsignarParametroCadena("@valorunitario", valorunitario);
        conector.AsignarParametroCadena("@valortotal", valortotal);
        conector.AsignarParametroCadena("@descripciongasto", descripciongasto);

        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataTable procloadMaterialestrag008(string codigoinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, codestrainstrumento_g008, to_char(fechagasto, 'DD/MM/YYYY') AS fechagasto, nombreproveedor, valorunitario, valortotal, descripciongasto FROM est_estra2instrumento_g008material WHERE codestrainstrumento_g008 = @codigoinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
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

    //CODE BITACORA 2
    public DataRow procinsertbitacora2(string grupoinvestigacion, string preguntainvestigacion, string resumen, string estrategia, string momento, string sesion)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra1bitacora2 (codproyecto, fechadiligenciamiento, preguntainvestigacion, resumen, estrategia, momento,sesion)  VALUES (@grupoinvestigacion, @fechadiligenciamiento, @preguntainvestigacion, @resumen, @estrategia, @momento, @sesion) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@grupoinvestigacion", grupoinvestigacion);
        conector.AsignarParametroCadena("@fechadiligenciamiento", "NOW()");
        conector.AsignarParametroCadena("@preguntainvestigacion", preguntainvestigacion);
        conector.AsignarParametroCadena("@resumen", resumen);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
        //conector.AsignarParametroCadena("@relato", relato);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public long procupdatebitacora2(string codigobitacora, string grupoinvestigacion, string preguntainvestigacion, string resumen)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra1bitacora2 SET preguntainvestigacion = @preguntainvestigacion, resumen = @resumen WHERE codigo = @codigobitacora;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@preguntainvestigacion", preguntainvestigacion);
        conector.AsignarParametroCadena("@resumen", resumen);
        conector.AsignarParametroCadena("@codigobitacora", codigobitacora);
        //conector.AsignarParametroCadena("@relato", relato);
        long resp = conector.guardadataid();
        return resp;
    }

    public DataRow procloadBitacora2(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT b.*, d.nombre as departamento, m.nombre as municipio, p.nombregrupo, a.nombre as area, li.nombre as linea, concat_ws(' ',ase.nombre,ase.apellido) as asesor FROM est_estra1bitacora2 b inner join pro_proyectosede p on p.codigo=b.codproyecto inner join pro_areas a on a.codigo=p.codarea inner join pro_linea_investigacion li on li.codigo=p.codlineainvestigacion inner join est_asesorcoordinador ac on ac.codigo=p.codasesorcoordinador inner join est_asesor ase on ase.codigo=ac.codasesor inner join ins_sede s on s.codigo=p.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento WHERE b.codigo = @codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public long procdeletePreguntas(string codigobitacora)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora2pregunta WHERE codest_estra1bitacora2 = @codigobitacora;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigobitacora", codigobitacora);
        long resp = conector.guardadataid();
        return resp;
    }

    public DataRow procinsertPreguntas(string codigobitacora, string pregunta, string numpregunta)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra1bitacora2pregunta (codest_estra1bitacora2, pregunta,numpregunta) VALUES (@codigobitacora,@pregunta,@numpregunta) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigobitacora", codigobitacora);
        conector.AsignarParametroCadena("@pregunta", pregunta);
        conector.AsignarParametroCadena("@numpregunta", numpregunta);

        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow procinsertRespuesta(string codigopregunta, string respuesta, string fuente, string numrespuesta)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra1bitacora2respuestas (codest_estra1bitacora2pregunta, respuesta, fuente, numrespuesta) VALUES (@codigopregunta, @respuesta, @fuente, @numrespuesta) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigopregunta", codigopregunta);
        conector.AsignarParametroCadena("@respuesta", respuesta);
        conector.AsignarParametroCadena("@fuente", fuente);
        conector.AsignarParametroCadena("@numrespuesta", numrespuesta);

        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public long procdeleteRespuestas(string codigopregunta)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora2respuestas WHERE codest_estra1bitacora2pregunta = @codigopregunta;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigopregunta", codigopregunta);
        long resp = conector.guardadataid();
        return resp;
    }

    public DataTable procloadpreguntas(string codigobitacora)
    {
        Conexion conector = new Conexion();

        string consulta = "SELECT * FROM est_estra1bitacora2pregunta WHERE codest_estra1bitacora2 = @codigobitacora ORDER BY numpregunta ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigobitacora", codigobitacora);
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

    public DataTable procloadRespuestas(string codpregunta)
    {
        Conexion conector = new Conexion();

        string consulta = "SELECT codigo, codest_estra1bitacora2pregunta, respuesta, fuente, numrespuesta FROM est_estra1bitacora2respuestas WHERE codest_estra1bitacora2pregunta = @codpregunta ORDER BY numrespuesta ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
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

    //codigo bitacora3
    public DataRow procinsertIntrumentobitacora3(string codproyecto, string respuestapregunta1, string respuestapregunta2, string estrategia, string momento, string sesion, string codasesorestracoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra1bitacora3 (fechaejecucion,codproyecto,respuestapregunta1,respuestapregunta2, estrategia,momento,sesion,codasesorestracoordinador) VALUES(@fechaejecucion,@codproyecto,@respuestapregunta1,@respuestapregunta2,@estrategia,@momento,@sesion,@codasesorestracoordinador) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@fechaejecucion", "NOW()");
        conector.AsignarParametroCadena("@codproyecto", codproyecto);
        conector.AsignarParametroCadena("@respuestapregunta1", respuestapregunta1);
        conector.AsignarParametroCadena("@respuestapregunta2", respuestapregunta2);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@codasesorestracoordinador", codasesorestracoordinador);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow procinsertIntrumentobitacora7(string codproyecto, string proyeccion, string estrategia, string momento, string sesion)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra1bitacora7 (fechacreacion,codproyectosede,proyeccion,estrategia,momento,sesion) VALUES(@fechaejecucion,@codproyecto,@proyeccion,@estrategia,@momento,@sesion) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@fechaejecucion", "NOW()");
        conector.AsignarParametroCadena("@codproyecto", codproyecto);
        conector.AsignarParametroCadena("@proyeccion", proyeccion);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow procinsertJornadasFormacion(string codsede, string codanio, string nroasistentes, string momento, string jornada, string codestracoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra1jornadasformacion (codsede,codanio,nroasistentes,momento,jornada,fecharealizacion,codestracoordinador) VALUES(@codsede,@codanio,@nroasistentes,@momento,@jornada,@fecharealizacion,@codestracoordinador) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@fecharealizacion", "NOW()");
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@codanio", codanio);
        conector.AsignarParametroCadena("@nroasistentes", nroasistentes);
        conector.AsignarParametroCadena("@jornada", jornada);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow procinsertIntrumentoPreestructurados(string codproyectosede, string preestructurado, string estrategia, string momento)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra1preestructurados (codproyectosede,fechacreacion,preestructurado,estrategia,momento) VALUES (@codproyectosede,NOW(),@preestructurado,@estrategia,@momento) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@preestructurado", preestructurado);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow procinsertEspaciosApropiacion(string codproyectosede, string fecharealizacion, string nroestudiantes, string nrodocentes, string estrategia, string momento)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra1espacioapropiacion (codproyectosede,fecharealizacion,nroestudiantes,nrodocentes,estrategia,momento) VALUES(@codproyectosede,@fecharealizacion,@nroestudiantes,@nrodocentes,@estrategia,@momento) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
        conector.AsignarParametroCadena("@fecharealizacion", fecharealizacion);
        conector.AsignarParametroCadena("@nroestudiantes", nroestudiantes);
        conector.AsignarParametroCadena("@nrodocentes", nrodocentes);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow procinsertParticipantesFerias(string codsede, string codasesorcoordinador, string codanio)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra1participantesferias (codsede,codasesorcoordinador,fecharealizacion, codanio) VALUES(@codsede,@codasesorcoordinador,NOW(), @codanio) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@codanio", codanio);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow procinsertIntrumentos008(string codproyecto, string resumen, string relato, string perturbacion, string superposicion, string sintesis, string aprendizaje, string conclusiones, string fuentes, string estrategia, string momento)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra1instrumento_s008 (fechacreacion, codproyectosede, resumen, relato, perturbacion, superposicion, sintesis, aprendizaje, conclusiones, fuentes, estrategia, momento) VALUES(@fechaejecucion, @codproyecto, @resumen, @relato, @perturbacion, @superposicion, @sintesis, @aprendizaje, @conclusiones, @fuentes,@estrategia,@momento) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@fechaejecucion", "NOW()");
        conector.AsignarParametroCadena("@codproyecto", codproyecto);
        conector.AsignarParametroCadena("@resumen", resumen);
        conector.AsignarParametroCadena("@relato", relato);
        conector.AsignarParametroCadena("@perturbacion", perturbacion);
        conector.AsignarParametroCadena("@superposicion", superposicion);
        conector.AsignarParametroCadena("@sintesis", sintesis);
        conector.AsignarParametroCadena("@aprendizaje", aprendizaje);
        conector.AsignarParametroCadena("@conclusiones", conclusiones);
        conector.AsignarParametroCadena("@fuentes", fuentes);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    //CODE S004
    public DataRow insertestras004(string redtematica, string nombresesion, string temasesion, string informacionadicional, string fechaelaboracion, string nombrerelator, string horasesion, string horasesionfinal, string codestracoordinador, string aspectosdesarrollados, string conclusiones, string bibliografia, string desarrollo1, string compromisos, string evaluacionsesion, string estrategia, string momento, string sesion, string nohoras)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra2instrumento_s004_redt (codasesorcoordinador, nombresesion, codredtematicasede, temasesion, informacionadicional, fechaelaboracion, nombrerelator, horasesion, horasesionfinal, aspectosdesarrollados, conclusiones, bibliografia, desarrollo1, compromisos, evaluacionsesion, estrategia, momento, sesion, nohoras) VALUES (@codestracoordinador,  @nombresesion, @redtematica, @temasesion, @informacionadicional, @fechaelaboracion, @nombrerelator, @horasesion, @horasesionfinal, @aspectosdesarrollados, @conclusiones, @bibliografia, @desarrollo1, @compromisos, @evaluacionsesion, @estrategia, @momento, @sesion, @nohoras) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
        conector.AsignarParametroCadena("@redtematica", redtematica);
        conector.AsignarParametroCadena("@nombresesion", nombresesion);
        conector.AsignarParametroCadena("@temasesion", temasesion);
        conector.AsignarParametroCadena("@informacionadicional", informacionadicional);
        conector.AsignarParametroCadena("@fechaelaboracion", fechaelaboracion);

        conector.AsignarParametroCadena("@nombrerelator", nombrerelator);
        conector.AsignarParametroCadena("@horasesion", horasesion);
        conector.AsignarParametroCadena("@horasesionfinal", horasesionfinal);
        conector.AsignarParametroCadena("@aspectosdesarrollados", aspectosdesarrollados);
        conector.AsignarParametroCadena("@conclusiones", conclusiones);
        conector.AsignarParametroCadena("@bibliografia", bibliografia);
        conector.AsignarParametroCadena("@desarrollo1", desarrollo1);
        conector.AsignarParametroCadena("@compromisos", compromisos);
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

    public DataRow insertestras004Sedes(string codsede, string nombresesion, string temasesion, string informacionadicional, string fechaelaboracion, string nombrerelator, string horasesion, string horasesionfinal, string codasesorcoordinador, string aspectosdesarrollados, string conclusiones, string bibliografia, string estrategia, string momento, string sesion, string jornada, string desarrollo1, string desarrollo3, string actividadesytareas, string aspectos)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra2instrumento_s004_sede (codsede, nombresesion, temasesion, informacionadicional, fechaelaboracion, nombrerelator, codasesorcoordinador, aspectosdesarrollados, conclusiones, bibliografia, estrategia, momento, sesion, jornada, desarrollo1, desarrollo3, actividadesytareas, aspectos, horasesion, horasesionfinal) VALUES (@codsede, @nombresesion, @temasesion, @informacionadicional, @fechaelaboracion, @nombrerelator, @codasesorcoordinador, @aspectosdesarrollados, @conclusiones, @bibliografia, @estrategia, @momento, @sesion, @jornada, @desarrollo1, @desarrollo3, @actividadesytareas, @aspectos, @horasesion, @horasesionfinal) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@nombresesion", nombresesion);
        conector.AsignarParametroCadena("@temasesion", temasesion);
        conector.AsignarParametroCadena("@informacionadicional", informacionadicional);
        conector.AsignarParametroCadena("@fechaelaboracion", fechaelaboracion);
        conector.AsignarParametroCadena("@horasesion", horasesion);
        conector.AsignarParametroCadena("@horasesionfinal", horasesionfinal);
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
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    //editada 8/11/2016
    public DataRow proloadestras004(string codigoestra, string estrategia, string momento, string sesion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, codasesorcoordinador, nombresesion, temasesion, informacionadicional, fechaelaboracion, nombrerelator, horasesion, horasesionfinal, aspectosdesarrollados, conclusiones, bibliografia, desarrollo1, compromisos, evaluacionsesion, nohoras, nosesiones FROM est_estra2instrumento_s004_redt WHERE codigo = @codigoestra and estrategia=@estrategia and momento=@momento and sesion=@sesion";
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

    public DataRow proloadestras004_estra5(string codigoestra)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM est_estrainstrumento_s004coord WHERE codigo = @codigoestra ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoestra", codigoestra);

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


    public DataRow proloadestras004Sede(string codigo, string estrategia, string momento, string sesion, string jornada)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM est_estra2instrumento_s004_sede WHERE codigo = @codigo and estrategia=@estrategia and momento=@momento and sesion=@sesion and jornada=@jornada";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@jornada", jornada);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public long procupdateestras004(string codigoestrategia, string redtematica, string nombresesion, string temasesion, string informacionadicional, string fechaelaboracion, string nombrerelator, string horasesion, string horasesionfinal, string aspectosdesarrollados, string conclusiones, string bibliografia, string desarrollo1, string compromisos, string evaluacionsesion, string nohoras)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra2instrumento_s004_redt SET nombresesion = @nombresesion, temasesion = @temasesion, informacionadicional=@informacionadicional, fechaelaboracion = @fechaelaboracion, nombrerelator=@nombrerelator, horasesion=@horasesion, horasesionfinal=@horasesionfinal, aspectosdesarrollados=@aspectosdesarrollados, conclusiones=@conclusiones, bibliografia=@bibliografia, desarrollo1=@desarrollo1, compromisos=@compromisos, evaluacionsesion=@evaluacionsesion, codredtematicasede=@codredtematicasede, nohoras=@nohoras WHERE codigo = @codigoestrategia";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombresesion", nombresesion);
        conector.AsignarParametroCadena("@temasesion", temasesion);
        conector.AsignarParametroCadena("@informacionadicional", informacionadicional);
        conector.AsignarParametroCadena("@fechaelaboracion", fechaelaboracion);
        conector.AsignarParametroCadena("@nombrerelator", nombrerelator);
        conector.AsignarParametroCadena("@horasesion", horasesion);
        conector.AsignarParametroCadena("@horasesionfinal", horasesionfinal);
        conector.AsignarParametroCadena("@aspectosdesarrollados", aspectosdesarrollados);
        conector.AsignarParametroCadena("@conclusiones", conclusiones);
        conector.AsignarParametroCadena("@bibliografia", bibliografia);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);
        conector.AsignarParametroCadena("@desarrollo1", desarrollo1);
        conector.AsignarParametroCadena("@compromisos", compromisos);
        conector.AsignarParametroCadena("@evaluacionsesion", evaluacionsesion);
        conector.AsignarParametroCadena("@codredtematicasede", redtematica);
        conector.AsignarParametroCadena("@nohoras", nohoras);
        long resp = conector.guardadataid();
        return resp;
    }
     public long procupdateestras004Sede(string codigoestrategia, string nombresesion, string temasesion, string informacionadicional, string fechaelaboracion, string nombrerelator, string horasesion, string horasesionfinal, string aspectosdesarrollados, string conclusiones, string bibliografia, string desarrollo1, string desarrollo3, string actividadesytareas, string aspectos)
     {
         Conexion conector = new Conexion();
         string consulta = "UPDATE est_estra2instrumento_s004_sede SET nombresesion = @nombresesion, temasesion = @temasesion, informacionadicional=@informacionadicional, fechaelaboracion = @fechaelaboracion, nombrerelator=@nombrerelator, horasesion=@horasesion, horasesionfinal=@horasesionfinal, aspectosdesarrollados=@aspectosdesarrollados, conclusiones=@conclusiones, bibliografia=@bibliografia, desarrollo1=@desarrollo1, desarrollo3=@desarrollo3, actividadesytareas=@actividadesytareas, aspectos=@aspectos WHERE codigo = @codigoestrategia";
         conector.CrearComando(consulta);
         conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);
         conector.AsignarParametroCadena("@nombresesion", nombresesion);
         conector.AsignarParametroCadena("@temasesion", temasesion);
         conector.AsignarParametroCadena("@informacionadicional", informacionadicional);
         conector.AsignarParametroCadena("@fechaelaboracion", fechaelaboracion);
         conector.AsignarParametroCadena("@nombrerelator", nombrerelator);
         conector.AsignarParametroCadena("@horasesion", horasesion);
         conector.AsignarParametroCadena("@horasesionfinal", horasesionfinal);
         conector.AsignarParametroCadena("@aspectosdesarrollados", aspectosdesarrollados);
         conector.AsignarParametroCadena("@conclusiones", conclusiones);
         conector.AsignarParametroCadena("@bibliografia", bibliografia);

         conector.AsignarParametroCadena("@desarrollo1", desarrollo1);
         conector.AsignarParametroCadena("@desarrollo3", desarrollo3);
         conector.AsignarParametroCadena("@actividadesytareas", actividadesytareas);
         conector.AsignarParametroCadena("@aspectos", aspectos);


         long resp = conector.guardadataid();
         return resp;
     }

    public long procdeletePreguntass004(string codigoestrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2instrumento_s004_preguntas_redt WHERE codestrainstrumento_s004_redt = @codigoestrategia;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);
        long resp = conector.guardadataid();
        return resp;
    }

    public long procdeletePreguntass004Sede(string codigoestrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2instrumento_s004_preguntas_sede WHERE codestrainstrumento_s004_sede = @codigoestrategia;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);
        long resp = conector.guardadataid();
        return resp;
    }

    public DataRow procinsertPreguntass004(string codigoestrategia, string nopregunta, string pregunta)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra2instrumento_s004_preguntas_redt (codestrainstrumento_s004_redt, pregunta, nopregunta) VALUES (@codigoestrategia,@pregunta,@nopregunta) RETURNING codigo";
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

    public DataRow procinsertPreguntass004Sedes(string codigoestrategia, string nopregunta, string pregunta)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra2instrumento_s004_preguntas_sede (codestrainstrumento_s004_sede, pregunta, nopregunta) VALUES (@codigoestrategia,@pregunta,@nopregunta) RETURNING codigo";
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

    public DataTable procloadPreguntass004(string codigoestrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, codestrainstrumento_s004_redt, pregunta, nopregunta FROM est_estra2instrumento_s004_preguntas_redt WHERE codestrainstrumento_s004_redt = @codigoestrategia ORDER BY nopregunta ASC";
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

    public DataTable procloadPreguntass004_2016(string codigoestrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, codestrainstrumento_s004_redt, pregunta, nopregunta FROM est_estra2instrumento_s004_preguntas_redt WHERE codestrainstrumento_s004_redt = @codigoestrategia ORDER BY nopregunta ASC";
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

    public DataTable procloadPreguntass004Sede(string codigoestrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, codestrainstrumento_s004_sede, pregunta, nopregunta FROM est_estra2instrumento_s004_preguntas_sede WHERE codestrainstrumento_s004_sede = @codigoestrategia ORDER BY nopregunta ASC";
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

    public DataTable proccargarRedtematica(string codsede, string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "select rts.codigo, concat_ws(' ', rt.nombre,rts.consecutivogrupo) as redtematica from rt_redtematicasede rts inner join rt_redtematica rt on rts.codredtematica=rt.codigo where rts.codsede=@codsede and rts.codasesorcoordinador=@codasesorcoordinador and rts.aniored!='2016' order by rts.codigo asc";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
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

    public DataTable proccargarRedtematica_2016(string codsede, string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "select rts.codigo, concat_ws(' ', rt.nombre,rts.consecutivogrupo) as redtematica from rt_redtematicasede rts inner join rt_redtematica rt on rts.codredtematica=rt.codigo where rts.codsede=@codsede and rts.codasesorcoordinador=@codasesorcoordinador and rts.aniored='2016' order by rts.codigo asc";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
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

    //Code s006
    public DataRow procinsertests006(string sede, string nombresesion, string temasesion, string informacionadicional, string fechaelaboracion, string horasesion, string nombresapellidosmoderador, string nombresapellidosrelator, string aspectosdesarrollados, string conclusiones, string bibliografia, string codestracoordinador, string momento, string sesion, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra2instrumento_s006 (codestracoordinador, codsede, nomsesion, temasesion, horasesion, nommoredador, nomrelator, aspectosdesarrollados, conclusiones, bibliografia, momento,sesion, actividad, fechaelaboracion, informacionadicional) VALUES (@codestracoordinador, @sede, @nombresesion, @temasesion, @horasesion, @nombresapellidosmoderador, @nombresapellidosrelator, @aspectosdesarrollados, @conclusiones, @bibliografia, @momento, @sesion, @actividad, @fechaelaboracion, @informacionadicional) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
        conector.AsignarParametroCadena("@sede", sede);
        conector.AsignarParametroCadena("@nombresesion", nombresesion);
        conector.AsignarParametroCadena("@temasesion", temasesion);
        conector.AsignarParametroCadena("@horasesion", horasesion);
        conector.AsignarParametroCadena("@nombresapellidosmoderador", nombresapellidosmoderador);
        conector.AsignarParametroCadena("@nombresapellidosrelator", nombresapellidosrelator);

        conector.AsignarParametroCadena("@aspectosdesarrollados", aspectosdesarrollados);
        conector.AsignarParametroCadena("@conclusiones", conclusiones);
        conector.AsignarParametroCadena("@bibliografia", bibliografia);

        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@actividad", actividad);
        conector.AsignarParametroCadena("@fechaelaboracion", fechaelaboracion);
        conector.AsignarParametroCadena("@informacionadicional", informacionadicional);

        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow procloadestras006(string codigosede)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, nomsesion, temasesion, informacionadicional, fechaelaboracion, horasesion, nommoredador, nomrelator, aspectosdesarrollados, conclusiones, bibliografia, momento,sesion, actividad FROM est_estra2instrumento_s006 WHERE codsede = @codsede";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codigosede);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public long procupdateests006(string codigoestrategia, string nombresesion, string temasesion, string informacionadicional, string fechaelaboracion, string horasesion, string nombresapellidosmoderador, string nombresapellidosrelator, string aspectosdesarrollados, string conclusiones, string bibliografia)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra2instrumento_s006 SET nomsesion = @nombresesion, temasesion = @temasesion, informacionadicional=@informacionadicional, fechaelaboracion = @fechaelaboracion, horasesion = @horasesion, nommoredador=@nombremoderador, nomrelator=@nombrerelator, aspectosdesarrollados=@aspectosdesarrollados, conclusiones=@conclusiones, bibliografia=@bibliografia WHERE codigo = @codigoestrategia;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombresesion", nombresesion);
        conector.AsignarParametroCadena("@temasesion", temasesion);
        conector.AsignarParametroCadena("@informacionadicional", informacionadicional);
        conector.AsignarParametroCadena("@fechaelaboracion", fechaelaboracion);
        conector.AsignarParametroCadena("@horasesion", horasesion);
        conector.AsignarParametroCadena("@nombremoderador", nombresapellidosmoderador);
        conector.AsignarParametroCadena("@nombrerelator", nombresapellidosrelator);
        conector.AsignarParametroCadena("@aspectosdesarrollados", aspectosdesarrollados);
        conector.AsignarParametroCadena("@conclusiones", conclusiones);
        conector.AsignarParametroCadena("@bibliografia", bibliografia);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);

        long resp = conector.guardadataid();
        return resp;
    }

    public long procdeleteExpositoress006(string codigoestrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2instrumento_s006_expositores WHERE codestra2instrumento_s006 = @codigoestrategia;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);
        long resp = conector.guardadataid();
        return resp;
    }
    public DataRow procinsertExpositoress006(string codigoestrategia, string numero, string nombresapellidosexpositores, string correoexpositores)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra2instrumento_s006_expositores (codestra2instrumento_s006, nombreapellidoexpositores, emailexpositores, numero) VALUES (@codigoestrategia, @nombreapellidoexpositores, @correoexpositores, @numero) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);
        conector.AsignarParametroCadena("@nombreapellidoexpositores", nombresapellidosexpositores);
        conector.AsignarParametroCadena("@correoexpositores", correoexpositores);
        conector.AsignarParametroCadena("@numero", numero);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataTable procloadExpositoress006(string codigoestrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, codestra2instrumento_s006, nombreapellidoexpositores, emailexpositores, numero FROM est_estra2instrumento_s006_expositores WHERE codestra2instrumento_s006 = @codigoestrategia ORDER BY numero ASC";
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

    //integrantes
    public long procdeleteIntegrantess006(string codigoestrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2instrumento_s006_integrantes WHERE codestra2instrumento_s006 = @codigoestrategia;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);
        long resp = conector.guardadataid();
        return resp;
    }
    public DataRow procinsertIntegrantess006(string codigoestrategia, string numero, string nombreapellidosintegrantes, string correointegrantes)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra2instrumento_s006_integrantes (codestra2instrumento_s006, nombreapellidointegrantes, emailintegrantes, numero) VALUES (@codigoestrategia, @nombreapellidointegrantes, @correointegrantes, @numero) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);
        conector.AsignarParametroCadena("@nombreapellidointegrantes", nombreapellidosintegrantes);
        conector.AsignarParametroCadena("@correointegrantes", correointegrantes);
        conector.AsignarParametroCadena("@numero", numero);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataTable procloadIntegrantess006(string codigoestrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, codestra2instrumento_s006, nombreapellidointegrantes, emailintegrantes, numero FROM est_estra2instrumento_s006_integrantes WHERE codestra2instrumento_s006 = @codigoestrategia ORDER BY numero ASC";
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



    //preguntas
    public long procdeletePreguntass006(string codigoestrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2instrumento_s006_preguntas WHERE codestra2instrumento_s006 = @codigoestrategia;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);
        long resp = conector.guardadataid();
        return resp;
    }
    public DataRow procinsertPreguntass006(string codigoestrategia, string nopregunta, string pregunta)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra2instrumento_s006_preguntas (codestra2instrumento_s006, pregunta, nopregunta) VALUES (@codigoestrategia, @pregunta, @nopregunta) RETURNING codigo";
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

    public DataTable procloadPreguntass006(string codigoestrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, codestra2instrumento_s006, pregunta, nopregunta FROM est_estra2instrumento_s006_preguntas WHERE codestra2instrumento_s006 = @codigoestrategia ORDER BY nopregunta ASC";
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

    //CODE S015
    public DataRow procinsertests015(string grupoinvestigacion, string nombrevalorador, string profesionvalorador, string lineatematica, string firmavalorador, string observaciones)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estrainstrumento_s015 (nombrevalorador, profesionvalorador, lineatematica, firmavalorador, observaciones, codproyecto) VALUES (@nombrevalorador, @profesionvalorador, @lineatematica, @firmavalorador, @observaciones, @grupoinvestigacion) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombrevalorador", nombrevalorador);
        conector.AsignarParametroCadena("@profesionvalorador", profesionvalorador);
        conector.AsignarParametroCadena("@lineatematica", lineatematica);
        conector.AsignarParametroCadena("@firmavalorador", firmavalorador);
        conector.AsignarParametroCadena("@observaciones", observaciones);
        conector.AsignarParametroCadena("@grupoinvestigacion", grupoinvestigacion);
        DataRow dato = conector.traerfila();

        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataRow procloadestras015(string codproyecto)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, nombrevalorador, profesionvalorador, lineatematica, firmavalorador, observaciones FROM est_estrainstrumento_s015 WHERE codproyecto = @codproyecto";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyecto", codproyecto);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataTable procloadPuntajesEstras015(string codigoinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, numpuntaje, puntaje FROM est_estrainstrumento_s015puntajes WHERE codestrainstrumento_s015 = @codigoinstrumento ORDER BY numpuntaje ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
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

    public long procdeletePuntajess015(string codigoestrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estrainstrumento_s015puntajes WHERE codestrainstrumento_s015 = @codigoestrategia;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);
        long resp = conector.guardadataid();
        return resp;
    }

    public DataRow procinsertPuntajess015(string codigoestrategia, string numero, string puntaje)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estrainstrumento_s015puntajes (codestrainstrumento_s015, numpuntaje, puntaje) VALUES (@codigoestrategia, @numpuntaje, @puntaje) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);
        conector.AsignarParametroCadena("@numpuntaje", numero);
        conector.AsignarParametroCadena("@puntaje", puntaje);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public long procupdateests015(string codigoestrategia, string nombrevalorador, string profesionvalorador, string lineatematica, string firmavalorador, string observaciones)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estrainstrumento_s015 SET nombrevalorador = @nombrevalorador, profesionvalorador=@profesionvalorador, lineatematica = @lineatematica, firmavalorador = @firmavalorador, observaciones = @observaciones WHERE codigo = @codigoestrategia;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombrevalorador", nombrevalorador);
        conector.AsignarParametroCadena("@profesionvalorador", profesionvalorador);
        conector.AsignarParametroCadena("@lineatematica", lineatematica);
        conector.AsignarParametroCadena("@firmavalorador", firmavalorador);
        conector.AsignarParametroCadena("@observaciones", observaciones);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);

        long resp = conector.guardadataid();
        return resp;
    }

    //CODE S016
    public DataRow procinsertests016(string grupoinvestigacion, string nombrevalorador, string profesionvalorador, string lineatematica, string firmavalorador, string observaciones)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estrainstrumento_s016 (nombrevalorador, profesionvalorador, lineatematica, firmavalorador, observaciones, codproyecto) VALUES (@nombrevalorador, @profesionvalorador, @lineatematica, @firmavalorador, @observaciones, @grupoinvestigacion) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombrevalorador", nombrevalorador);
        conector.AsignarParametroCadena("@profesionvalorador", profesionvalorador);
        conector.AsignarParametroCadena("@lineatematica", lineatematica);
        conector.AsignarParametroCadena("@firmavalorador", firmavalorador);
        conector.AsignarParametroCadena("@observaciones", observaciones);
        conector.AsignarParametroCadena("@grupoinvestigacion", grupoinvestigacion);
        DataRow dato = conector.traerfila();

        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataRow procloadestras016(string codproyecto)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, nombrevalorador, profesionvalorador, lineatematica, firmavalorador, observaciones FROM est_estrainstrumento_s016 WHERE codproyecto = @codproyecto";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyecto", codproyecto);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataTable procloadPuntajesEstras016(string codigoinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, numpuntaje, puntaje FROM est_estrainstrumento_s016puntajes WHERE codestrainstrumento_s016 = @codigoinstrumento ORDER BY numpuntaje ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
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

    public long procdeletePuntajess016(string codigoestrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estrainstrumento_s016puntajes WHERE codestrainstrumento_s016 = @codigoestrategia;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);
        long resp = conector.guardadataid();
        return resp;
    }

    public DataRow procinsertPuntajess016(string codigoestrategia, string numero, string puntaje)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estrainstrumento_s016puntajes (codestrainstrumento_s016, numpuntaje, puntaje) VALUES (@codigoestrategia, @numpuntaje, @puntaje) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);
        conector.AsignarParametroCadena("@numpuntaje", numero);
        conector.AsignarParametroCadena("@puntaje", puntaje);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public long procupdateests016(string codigoestrategia, string nombrevalorador, string profesionvalorador, string lineatematica, string firmavalorador, string observaciones)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estrainstrumento_s016 SET nombrevalorador = @nombrevalorador, profesionvalorador=@profesionvalorador, lineatematica = @lineatematica, firmavalorador = @firmavalorador, observaciones = @observaciones WHERE codigo = @codigoestrategia;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombrevalorador", nombrevalorador);
        conector.AsignarParametroCadena("@profesionvalorador", profesionvalorador);
        conector.AsignarParametroCadena("@lineatematica", lineatematica);
        conector.AsignarParametroCadena("@firmavalorador", firmavalorador);
        conector.AsignarParametroCadena("@observaciones", observaciones);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);

        long resp = conector.guardadataid();
        return resp;
    }

    //CODE S017
    public DataRow procinsertests017(string grupoinvestigacion, string nombrevalorador, string profesionvalorador, string lineatematica, string observaciones1, string observaciones2, string observaciones3, string observaciones4, string observaciones5, string observaciones)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estrainstrumento_s017 (nombrevalorador, profesionvalorador, lineatematica, observaciones1, observaciones2, observaciones3, observaciones4, observaciones5, observaciones, codproyecto) VALUES (@nombrevalorador, @profesionvalorador, @lineatematica, @observaciones1, @observaciones2, @observaciones3, @observaciones4, @observaciones5, @observaciones, @grupoinvestigacion) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombrevalorador", nombrevalorador);
        conector.AsignarParametroCadena("@profesionvalorador", profesionvalorador);
        conector.AsignarParametroCadena("@lineatematica", lineatematica);
        conector.AsignarParametroCadena("@observaciones1", observaciones1);
        conector.AsignarParametroCadena("@observaciones2", observaciones2);
        conector.AsignarParametroCadena("@observaciones3", observaciones3);
        conector.AsignarParametroCadena("@observaciones4", observaciones4);
        conector.AsignarParametroCadena("@observaciones5", observaciones5);
        conector.AsignarParametroCadena("@observaciones", observaciones);
        conector.AsignarParametroCadena("@grupoinvestigacion", grupoinvestigacion);
        DataRow dato = conector.traerfila();

        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataRow procloadestras017(string codproyecto)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, nombrevalorador, profesionvalorador, lineatematica, observaciones1, observaciones2, observaciones3, observaciones4, observaciones5, observaciones FROM est_estrainstrumento_s017 WHERE codproyecto = @codproyecto";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyecto", codproyecto);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public long procupdateests017(string codigoestrategia, string nombrevalorador, string profesionvalorador, string lineatematica, string observaciones1, string observaciones2, string observaciones3, string observaciones4, string observaciones5, string observaciones)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estrainstrumento_s017 SET nombrevalorador = @nombrevalorador, profesionvalorador=@profesionvalorador, lineatematica = @lineatematica, observaciones1 = @observaciones1, observaciones2 = @observaciones2, observaciones3 = @observaciones3, observaciones4 = @observaciones4, observaciones5 = @observaciones5, observaciones = @observaciones WHERE codigo = @codigoestrategia;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombrevalorador", nombrevalorador);
        conector.AsignarParametroCadena("@profesionvalorador", profesionvalorador);
        conector.AsignarParametroCadena("@lineatematica", lineatematica);
        conector.AsignarParametroCadena("@observaciones1", observaciones1);
        conector.AsignarParametroCadena("@observaciones2", observaciones2);
        conector.AsignarParametroCadena("@observaciones3", observaciones3);
        conector.AsignarParametroCadena("@observaciones4", observaciones4);
        conector.AsignarParametroCadena("@observaciones5", observaciones5);
        conector.AsignarParametroCadena("@observaciones", observaciones);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);

        long resp = conector.guardadataid();
        return resp;
    }

    //code s003

    public DataTable proccargarInstitucionxMunicipio(string codmunicipio)
    {
        Conexion conector = new Conexion();
        string consulta = "select codigo, CONCAT_WS(' ',nombre,' - ',dane) as nombre from ins_institucion WHERE codmunicipio=@codmunicipio ORDER BY nombre ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
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


    public DataRow procinsertestras003(string codgrupoinvestigaciondocentes, string introduccion, string objetivogeneral, string objetivosespecificos, string perturbaciononda, string superposiciononda, string trayectoriaindagacion, string reflexiononda, string bibliografia, string anexoevidencias, string hallazgosyresultados, string bibliografiayfuentes)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra2instrumento_s003 (codgrupoinvestigaciondocentes, introduccion, objetivogeneral, objetivosespecificos, perturbaciononda, superposiciononda, trayectoriaindagacion, reflexiononda, bibliografia, anexoevidencias, hallazgosyresultados, bibliografiayfuentes) VALUES (@codgrupoinvestigaciondocentes, @introduccion, @objetivogeneral, @objetivosespecificos, @perturbaciononda, @superposiciononda, @trayectoriaindagacion, @reflexiononda, @bibliografia, @anexoevidencias, @hallazgosyresultados, @bibliografiayfuentes) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgrupoinvestigaciondocentes", codgrupoinvestigaciondocentes);
        conector.AsignarParametroCadena("@introduccion", introduccion);
        conector.AsignarParametroCadena("@objetivogeneral", objetivogeneral);
        conector.AsignarParametroCadena("@objetivosespecificos", objetivosespecificos);
        conector.AsignarParametroCadena("@perturbaciononda", perturbaciononda);
        conector.AsignarParametroCadena("@superposiciononda", superposiciononda);
        conector.AsignarParametroCadena("@trayectoriaindagacion", trayectoriaindagacion);
        conector.AsignarParametroCadena("@reflexiononda", reflexiononda);
        conector.AsignarParametroCadena("@bibliografia", bibliografia);
        conector.AsignarParametroCadena("@anexoevidencias", anexoevidencias);
        conector.AsignarParametroCadena("@hallazgosyresultados", hallazgosyresultados);
        conector.AsignarParametroCadena("@bibliografiayfuentes", bibliografiayfuentes);

        DataRow dato = conector.traerfila();

        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow procinsertestras003_Estrategia1(string codproyectosede, string introduccion, string objetivogeneral, string objetivosespecificos, string perturbaciononda, string superposiciononda, string trayectoriaindagacion, string reflexiononda, string bibliografia, string anexoevidencias, string hallazgosyresultados, string bibliografiayfuentes)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra1instrumento_s003 (codproyectosede, introduccion, objetivogeneral, objetivosespecificos, perturbaciononda, superposiciononda, trayectoriaindagacion, reflexiononda, bibliografia, anexoevidencias, hallazgosyresultados, bibliografiayfuentes,fechacreacion) VALUES (@codproyectosede, @introduccion, @objetivogeneral, @objetivosespecificos, @perturbaciononda, @superposiciononda, @trayectoriaindagacion, @reflexiononda, @bibliografia, @anexoevidencias, @hallazgosyresultados, @bibliografiayfuentes,NOW()) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
        conector.AsignarParametroCadena("@introduccion", introduccion);
        conector.AsignarParametroCadena("@objetivogeneral", objetivogeneral);
        conector.AsignarParametroCadena("@objetivosespecificos", objetivosespecificos);
        conector.AsignarParametroCadena("@perturbaciononda", perturbaciononda);
        conector.AsignarParametroCadena("@superposiciononda", superposiciononda);
        conector.AsignarParametroCadena("@trayectoriaindagacion", trayectoriaindagacion);
        conector.AsignarParametroCadena("@reflexiononda", reflexiononda);
        conector.AsignarParametroCadena("@bibliografia", bibliografia);
        conector.AsignarParametroCadena("@anexoevidencias", anexoevidencias);
        conector.AsignarParametroCadena("@hallazgosyresultados", hallazgosyresultados);
        conector.AsignarParametroCadena("@bibliografiayfuentes", bibliografiayfuentes);

        DataRow dato = conector.traerfila();

        if (dato != null)
            return dato;
        else
            return null;
    }


    public long procupdateestras003(string codigoestrategia, string introduccion, string objetivogeneral, string objetivosespecificos, string perturbaciononda, string superposiciononda, string trayectoriaindagacion, string reflexiononda, string bibliografia, string anexoevidencias, string hallazgosyresultados, string bibliografiayfuentes)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra2instrumento_s003 SET introduccion = @introduccion, objetivogeneral=@objetivogeneral, objetivosespecificos = @objetivosespecificos, perturbaciononda = @perturbaciononda, superposiciononda = @superposiciononda, trayectoriaindagacion = @trayectoriaindagacion, reflexiononda = @reflexiononda, bibliografia = @bibliografia, anexoevidencias = @anexoevidencias, hallazgosyresultados = @hallazgosyresultados, bibliografiayfuentes = @bibliografiayfuentes WHERE codigo = @codigoestrategia;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@introduccion", introduccion);
        conector.AsignarParametroCadena("@objetivogeneral", objetivogeneral);
        conector.AsignarParametroCadena("@objetivosespecificos", objetivosespecificos);
        conector.AsignarParametroCadena("@perturbaciononda", perturbaciononda);
        conector.AsignarParametroCadena("@superposiciononda", superposiciononda);
        conector.AsignarParametroCadena("@trayectoriaindagacion", trayectoriaindagacion);
        conector.AsignarParametroCadena("@reflexiononda", reflexiononda);
        conector.AsignarParametroCadena("@bibliografia", bibliografia);
        conector.AsignarParametroCadena("@anexoevidencias", anexoevidencias);
        conector.AsignarParametroCadena("@hallazgosyresultados", hallazgosyresultados);
        conector.AsignarParametroCadena("@bibliografiayfuentes", bibliografiayfuentes);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);

        long resp = conector.guardadataid();
        return resp;
    }

    public long procupdateestras003_Estrategia1(string codigoestrategia, string introduccion, string objetivogeneral, string objetivosespecificos, string perturbaciononda, string superposiciononda, string trayectoriaindagacion, string reflexiononda, string bibliografia, string anexoevidencias, string hallazgosyresultados, string bibliografiayfuentes)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra1instrumento_s003 SET introduccion = @introduccion, objetivogeneral=@objetivogeneral, objetivosespecificos = @objetivosespecificos, perturbaciononda = @perturbaciononda, superposiciononda = @superposiciononda, trayectoriaindagacion = @trayectoriaindagacion, reflexiononda = @reflexiononda, bibliografia = @bibliografia, anexoevidencias = @anexoevidencias, hallazgosyresultados = @hallazgosyresultados, bibliografiayfuentes = @bibliografiayfuentes WHERE codigo = @codigoestrategia;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@introduccion", introduccion);
        conector.AsignarParametroCadena("@objetivogeneral", objetivogeneral);
        conector.AsignarParametroCadena("@objetivosespecificos", objetivosespecificos);
        conector.AsignarParametroCadena("@perturbaciononda", perturbaciononda);
        conector.AsignarParametroCadena("@superposiciononda", superposiciononda);
        conector.AsignarParametroCadena("@trayectoriaindagacion", trayectoriaindagacion);
        conector.AsignarParametroCadena("@reflexiononda", reflexiononda);
        conector.AsignarParametroCadena("@bibliografia", bibliografia);
        conector.AsignarParametroCadena("@anexoevidencias", anexoevidencias);
        conector.AsignarParametroCadena("@hallazgosyresultados", hallazgosyresultados);
        conector.AsignarParametroCadena("@bibliografiayfuentes", bibliografiayfuentes);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);

        long resp = conector.guardadataid();
        return resp;
    }


    public DataRow procloadestras003(string grupoinvestigacion, string estrategia, string momento, string sesion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, codproyecto, introduccion, objetivogeneral, objetivosespecificos, perturbaciononda, superposiciononda, trayectoriaindagacion, reflexiononda, bibliografia, anexoevidencias, momento, sesion, estrategia  FROM est_estra2instrumento_s003 WHERE codproyecto = @grupoinvestigacion and estrategia=@estrategia and momento=@momento and sesion=@sesion";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@grupoinvestigacion", grupoinvestigacion);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);

        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    /*2016-10-24 JONNY PACHECO metodo para  listar las bitacoras 2*/
    public DataTable listarBitacoraDos(String codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT eeb.*, pps.nombregrupo ,s.nombre as nombresede,i.nombre as nombreinstitucion,m.nombre as nombremunicipio,d.nombre as nombredepartamento FROM est_estra1bitacora2 eeb inner join pro_proyectosede pps on pps.codigo=eeb.codproyecto inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where pps.codasesorcoordinador=@codasesorcoordinador order by eeb.fechadiligenciamiento DESC";
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

        public DataTable listarBitacoraDosSupervision()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT eeb.*, pps.nombregrupo ,s.nombre as nombresede,i.nombre as nombreinstitucion,m.nombre as nombremunicipio,d.nombre as nombredepartamento FROM est_estra1bitacora2 eeb inner join pro_proyectosede pps on pps.codigo=eeb.codproyecto inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento order by eeb.fechadiligenciamiento DESC";
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
    public bool editarInstitucion(string dane, string nombre, string nomrector, string telefono, string fax, string email, string codtipoinstitucion, string codclaseinstitucion, string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE ins_institucion SET  dane = @dane, nombre = @nombre, nomrector = @nomrector, telefono = @telefono, fax =@fax, email=@email, codtipoinstitucion=@codtipoinstitucion, codclaseinstitucion=@codclaseinstitucion WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@dane", dane);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@nomrector", nomrector);
        conector.AsignarParametroCadena("@telefono", telefono);
        conector.AsignarParametroCadena("@fax", fax);
        conector.AsignarParametroCadena("@email", email);
        conector.AsignarParametroCadena("@codtipoinstitucion", codtipoinstitucion);
        conector.AsignarParametroCadena("@codclaseinstitucion", codclaseinstitucion);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();
    }
    
    
    public bool actualizarDatosInstitucion(string dane, string nombre, string idrector, string direccion, string telefono, string fax, string email, string web, string codmunicipio, string codzona, string codpropiedadjuridica, string nrosedesactivas, string nrosedesinactivas)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE ins_institucion SET  dane = @dane, nombre = @nombre, idrector = @idrector, telefono = @telefono, fax =@fax, email=@email, direccion=@direccion, web=@web, codmunicipio=@codmunicipio, codzona=@codzona, codpropiedadjuridica=@codpropiedadjuridica, nrosedesactivas=@nrosedesactivas, nrosedesinactivas=@nrosedesinactivas WHERE dane = @dane2;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@dane", dane);
        conector.AsignarParametroCadena("@dane2", dane);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@idrector", idrector);
        conector.AsignarParametroCadena("@direccion", direccion);
        conector.AsignarParametroCadena("@telefono", telefono);
        conector.AsignarParametroCadena("@fax", fax);
        conector.AsignarParametroCadena("@email", email);
        conector.AsignarParametroCadena("@web", web);
        conector.AsignarParametroCadena("@codzona", codzona);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        conector.AsignarParametroCadena("@codpropiedadjuridica", codpropiedadjuridica);
        conector.AsignarParametroCadena("@nrosedesactivas", nrosedesactivas);
        conector.AsignarParametroCadena("@nrosedesinactivas", nrosedesinactivas);
        return conector.guardadata();
    }
    public long agregarSedeInstitucion(string dane, string codinstitucion, String nombre, String codzona, string direccion, string codmunicipio, string consesede, string sede)
    {
        Conexion conector = new Conexion();
        string consulta = " INSERT INTO ins_sede (nombre,dane,direccion, codinstitucion,codzona,codmunicipio,consesede,sede)  " +
            "VALUES (@nombre,@dane,@direccion,@codinstitucion,@codzona,@codmunicipio,@consesede,@sede);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@dane", dane);
        conector.AsignarParametroCadena("@codinstitucion", codinstitucion);
        conector.AsignarParametroCadena("@nombre", nombre.ToUpper());
        conector.AsignarParametroCadena("@codzona", codzona);
        conector.AsignarParametroCadena("@direccion", direccion);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        conector.AsignarParametroCadena("@sede", sede);
        conector.AsignarParametroCadena("@consesede", consesede);
        long resp = conector.guardadataid();
        return resp;
    }
    public bool agregarSedeInstitucionBool(string dane, string codinstitucion, String nombre, String codzona, string direccion, string codmunicipio, string consesede, string sede)
    {
        Conexion conector = new Conexion();
        string consulta = " INSERT INTO ins_sede (nombre,dane,direccion, codinstitucion,codzona,codmunicipio,consesede,sede)  " +
            "VALUES (@nombre,@dane,@direccion,@codinstitucion,@codzona,@codmunicipio,@consesede,@sede);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@dane", dane);
        conector.AsignarParametroCadena("@codinstitucion", codinstitucion);
        conector.AsignarParametroCadena("@nombre", nombre.ToUpper());
        conector.AsignarParametroCadena("@codzona", codzona);
        conector.AsignarParametroCadena("@direccion", direccion);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        conector.AsignarParametroCadena("@sede", sede);
        conector.AsignarParametroCadena("@consesede", consesede);
        return conector.guardadata();
    }
    public bool editarSedeInstitucion(string consesede, string dane, string nombre, string zona, string direccion, string codmunicipio, string sede, string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE ins_sede SET  nombre=@nombre, dane = @dane,codzona = @zona,direccion =@direccion,codmunicipio = @codmunicipio, sede=@sede, consesede=@consesede WHERE codigo = @cod ;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@dane", dane);
        conector.AsignarParametroCadena("@zona", zona);
        conector.AsignarParametroCadena("@direccion", direccion);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        conector.AsignarParametroCadena("@sede", sede);
        conector.AsignarParametroCadena("@consesede", consesede);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();
    }
    public DataTable cargarInstitucion()
    {
        Conexion conector = new Conexion();
        string consulta = "select codigo, CONCAT_WS(' ',nombre,' - ',dane) as nombre from ins_institucion ORDER BY nombre ASC";
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
    public DataTable cargarInstitucionxMunicipio(string codmunicipio)
    {
        Conexion conector = new Conexion();
        string consulta = "select codigo, CONCAT_WS(' ',nombre,' - ',dane) as nombre from ins_institucion WHERE codmunicipio=@codmunicipio ORDER BY nombre ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
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
    public DataTable cargarSedesInstitucion(string codcliente)
    {
        Conexion conector = new Conexion();
        string consulta = "select s.codigo as cod, s.dane as nit, s.nombre as nombre, s.direccion as direccion, s.codmunicipio as codmunicipio, m.nombre as nombrem, s.sede,s.consesede, z.codigo as codzona ,z.nombre as nomzona, i.codigo as codinstitucion  from ins_sede s left join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join ins_zona z on s.codzona=z.codigo  where s.codinstitucion=@codcliente ORDER BY s.nombre ASC";
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

    public DataRow cargarSedesInstitucionxCodSede(string codcliente)
    {
        Conexion conector = new Conexion();
        string consulta = "select s.codigo as cod, s.dane as nit, s.nombre as nombre, s.direccion as direccion, s.codmunicipio as codmunicipio, m.nombre as nombrem, s.sede,s.consesede, z.codigo as codzona ,z.nombre as nomzona, i.codigo as codinstitucion  from ins_sede s left join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join ins_zona z on s.codzona=z.codigo  where s.codigo=@codcliente ORDER BY s.nombre ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codcliente", codcliente);
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

    public DataTable cargarSedesInstitucionTodo()
    {
        Conexion conector = new Conexion();
        string consulta = "select s.codigo as cod, CONCAT_WS(' ' ,s.dane,'-',s.nombre) as nombrecompleto from ins_sede s left join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join ins_zona z on s.codzona=z.codigo ORDER BY s.nombre ASC";
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
        string consulta = "SELECT c.*,p.cod'codproyecto',tc.nombre'tipocliente',m.nombre'nombrem',d.nombre'nombred',p.nombre'nombrep',s.nombre FROM pro_clientes c INNER JOIN cli_sedes s ON c.cod=s.codclienteINNER JOIN con_municipios m ON s.codmunicipio=m.cod INNER JOIN con_departamentos d ON m.coddepartamento=d.cod INNER JOIN con_tipocliente tc ON c.codtipocliente=tc.cod LEFT JOIN pro_clienteproyecto cp ON cp.codclisede=s.cod LEFT JOIN pro_proyectos p ON cp.codproyecto=p.cod " + where + " ORDER BY s.nombre ASC";
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
        string consulta = "SELECT * FROM ins_institucion c WHERE c.codigo=@cod";
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

    public Boolean agregarTipoInstitucion(string nombre)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO con_tipocliente (nombre)  " +
            "VALUES (@nombre);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        return conector.guardadata();
    }

    public DataTable cargarClaseInstitucion()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM ins_claseinstitucion ORDER BY nombre ASC";
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
    public DataTable cargarTipoInstitucion()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM ins_tipoinstitucion ORDER BY nombre ASC";
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
    public DataTable cargarEstudiantexDocente(string iddocente)
    {
        Conexion conector = new Conexion();
        string consulta = "select em.codigo as codestumatricula,CONCAT_WS('',e.nombre,' ',e.apellido) as nombrecompleto, e.fecha_nacimiento, e.sexo, g.nombre as grado from ins_estumatricula em inner join ins_estudiante e on em.codestudiante=e.codigo inner join ins_gradodocente gd on gd.cod=em.codgradodocente inner join ins_grado g on g.codigo=em.codgrado where gd.cod=@iddocente AND em.codtipogrupo='2'";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@iddocente", iddocente);
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
    public DataTable cargarEstudiantexDocenteRT(string iddocente)
    {
        Conexion conector = new Conexion();
        string consulta = "select em.codigo as codestumatricula,CONCAT_WS('',e.nombre,' ',e.apellido) as nombrecompleto, e.fecha_nacimiento, e.sexo, g.nombre as grado from ins_estumatricula em inner join ins_estudiante e on em.codestudiante=e.codigo inner join ins_gradodocente gd on gd.cod=em.codgradodocente inner join ins_grado g on g.codigo=em.codgrado where gd.cod=@iddocente AND em.codtipogrupo='1'";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@iddocente", iddocente);
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

    //code S012
    public DataTable gruposInvestigacionDocente(string coddocente)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT pro.codigo, pro.nombre FROM pro_proyectodocente as ppd INNER JOIN pro_proyecto as pro ON pro.codigo = ppd.codproyectomatricula WHERE codgradodocente = @coddocente";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocente", coddocente);
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

    public DataRow procinsertests012(string grupoinvestigacion, string nombreponencia, string nombrevalorador, string profesionvalorador, string lineatematica, string observaciones)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estrainstrumento_s012 (nombreponencia, nombrevalorador, profesionvalorador, lineatematica, observaciones, codproyecto) VALUES (@nombreponencia, @nombrevalorador, @profesionvalorador, @lineatematica, @observaciones, @grupoinvestigacion) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombreponencia", nombreponencia);
        conector.AsignarParametroCadena("@nombrevalorador", nombrevalorador);
        conector.AsignarParametroCadena("@profesionvalorador", profesionvalorador);
        conector.AsignarParametroCadena("@lineatematica", lineatematica);
        conector.AsignarParametroCadena("@observaciones", observaciones);
        conector.AsignarParametroCadena("@grupoinvestigacion", grupoinvestigacion);
        DataRow dato = conector.traerfila();

        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataRow procloadestras012(string codproyecto)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, nombreponencia, nombrevalorador, profesionvalorador, lineatematica, observaciones FROM est_estrainstrumento_s012 WHERE codproyecto = @codproyecto";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyecto", codproyecto);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataTable procloadPuntajesEstras012(string codigoinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, numpuntaje,  puntaje, observacion FROM est_estrainstrumento_s012puntajes WHERE codestrainstrumento_s012 = @codigoinstrumento ORDER BY numpuntaje ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
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


    public long procdeletePuntajess012(string codigoestrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estrainstrumento_s012puntajes WHERE codestrainstrumento_s012 = @codigoestrategia;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);
        long resp = conector.guardadataid();
        return resp;
    }

    public DataRow procinsertPuntajess012(string codigoestrategia, string numero, string puntaje, string observacion)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estrainstrumento_s012puntajes (codestrainstrumento_s012, numpuntaje, puntaje, observacion) VALUES (@codigoestrategia, @numpuntaje, @puntaje, @observacion) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);
        conector.AsignarParametroCadena("@numpuntaje", numero);
        conector.AsignarParametroCadena("@puntaje", puntaje);
        conector.AsignarParametroCadena("@observacion", observacion);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public long procupdateests012(string codigoestrategia, string nombreponencia, string nombrevalorador, string profesionvalorador, string lineatematica, string observaciones)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estrainstrumento_s012 SET nombreponencia = @nombreponencia, nombrevalorador = @nombrevalorador, profesionvalorador=@profesionvalorador, lineatematica = @lineatematica, observaciones = @observaciones WHERE codigo = @codigoestrategia;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombreponencia", nombreponencia);
        conector.AsignarParametroCadena("@nombrevalorador", nombrevalorador);
        conector.AsignarParametroCadena("@profesionvalorador", profesionvalorador);
        conector.AsignarParametroCadena("@lineatematica", lineatematica);
        conector.AsignarParametroCadena("@observaciones", observaciones);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);

        long resp = conector.guardadataid();
        return resp;
    }

    //CODE S014
    public DataRow procinsertests014(string grupoinvestigacion, string nombrevalorador, string profesionvalorador, string lineatematica, string firmavalorador, string observaciones)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estrainstrumento_s014 (nombrevalorador, profesionvalorador, lineatematica, firmavalorador, observaciones, codproyecto) VALUES (@nombrevalorador, @profesionvalorador, @lineatematica, @firmavalorador, @observaciones, @grupoinvestigacion) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombrevalorador", nombrevalorador);
        conector.AsignarParametroCadena("@profesionvalorador", profesionvalorador);
        conector.AsignarParametroCadena("@lineatematica", lineatematica);
        conector.AsignarParametroCadena("@firmavalorador", firmavalorador);
        conector.AsignarParametroCadena("@observaciones", observaciones);
        conector.AsignarParametroCadena("@grupoinvestigacion", grupoinvestigacion);
        DataRow dato = conector.traerfila();

        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataRow procloadestras014(string codproyecto)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, nombrevalorador, profesionvalorador, lineatematica, firmavalorador, observaciones FROM est_estrainstrumento_s014 WHERE codproyecto = @codproyecto";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyecto", codproyecto);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataTable procloadPuntajesEstras014(string codigoinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, numpuntaje,  puntaje FROM est_estrainstrumento_s014puntajes WHERE codestrainstrumento_s014 = @codigoinstrumento ORDER BY numpuntaje ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
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


    public long procdeletePuntajess014(string codigoestrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estrainstrumento_s014puntajes WHERE codestrainstrumento_s014 = @codigoestrategia;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);
        long resp = conector.guardadataid();
        return resp;
    }

    public DataRow procinsertPuntajess014(string codigoestrategia, string numero, string puntaje)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estrainstrumento_s014puntajes (codestrainstrumento_s014, numpuntaje, puntaje) VALUES (@codigoestrategia, @numpuntaje, @puntaje) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);
        conector.AsignarParametroCadena("@numpuntaje", numero);
        conector.AsignarParametroCadena("@puntaje", puntaje);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public long procupdateests014(string codigoestrategia, string nombrevalorador, string profesionvalorador, string lineatematica, string firmavalorador, string observaciones)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estrainstrumento_s014 SET nombrevalorador = @nombrevalorador, profesionvalorador=@profesionvalorador, lineatematica = @lineatematica, firmavalorador = @firmavalorador, observaciones = @observaciones WHERE codigo = @codigoestrategia;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombrevalorador", nombrevalorador);
        conector.AsignarParametroCadena("@profesionvalorador", profesionvalorador);
        conector.AsignarParametroCadena("@lineatematica", lineatematica);
        conector.AsignarParametroCadena("@firmavalorador", firmavalorador);
        conector.AsignarParametroCadena("@observaciones", observaciones);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);

        long resp = conector.guardadataid();
        return resp;
    }

    /*2016-10-25 JONNY PACHECO metodo para  listar las bitacoras 3*/
    public DataTable listarBitacoraTres(String codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT eeb.*, pps.nombregrupo ,s.nombre as nombresede,i.nombre as nombreinstitucion,m.nombre as nombremunicipio,d.nombre as nombredepartamento FROM est_estra1bitacora3 eeb inner join pro_proyectosede pps on pps.codigo=eeb.codproyecto inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where pps.codasesorcoordinador=@codasesorcoordinador order by eeb.fechaejecucion DESC";
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

    public DataTable listarBitacoraSiete(String codasesorcoordinador, string estrategia, string momento, string sesion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT eeb.*, pps.nombregrupo ,s.nombre as nombresede,i.nombre as nombreinstitucion,m.nombre as nombremunicipio,d.nombre as nombredepartamento FROM est_estra1bitacora7 eeb inner join pro_proyectosede pps on pps.codigo=eeb.codproyectosede inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where pps.codasesorcoordinador=@codasesorcoordinador and eeb.estrategia=@estrategia and eeb.momento=@momento order by eeb.fechacreacion DESC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
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

    public DataTable listarAreas()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT a.codigo, a.nombre, (select count(*) from pro_proyectosede where codarea=a.codigo) as total from pro_areas a";
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

    public DataTable listarEncaJornadasFormacion(String codestracoordinador, string momento, string jornada)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT eeb.*, s.nombre as nombresede,i.nombre as nombreinstitucion,m.nombre as nombremunicipio,d.nombre as nombredepartamento FROM est_estra1jornadasformacion eeb inner join ins_sede s on s.codigo = eeb.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where eeb.codestracoordinador=@codestracoordinador and eeb.momento=@momento and eeb.jornada=@jornada order by eeb.fecharealizacion DESC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
        conector.AsignarParametroCadena("@jornada", jornada);
        conector.AsignarParametroCadena("@momento", momento);
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

    public DataTable listarEncaJornadasFormacionTodos(string momento, string jornada)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT eeb.*, s.nombre as nombresede,i.nombre as nombreinstitucion,m.nombre as nombremunicipio,d.nombre as nombredepartamento FROM est_estra1jornadasformacion eeb inner join ins_sede s on s.codigo = eeb.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where eeb.momento=@momento and eeb.jornada=@jornada order by eeb.fecharealizacion DESC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@jornada", jornada);
        conector.AsignarParametroCadena("@momento", momento);
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

    public DataTable listarPreestructurados(String codasesorcoordinador, string estrategia, string momento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT eeb.*, pps.nombregrupo ,s.nombre as nombresede,i.nombre as nombreinstitucion,m.nombre as nombremunicipio,d.nombre as nombredepartamento FROM est_estra1preestructurados eeb inner join pro_proyectosede pps on pps.codigo=eeb.codproyectosede inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where pps.codasesorcoordinador=@codasesorcoordinador and eeb.estrategia=@estrategia and eeb.momento=@momento order by eeb.fechacreacion DESC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
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

    public DataTable listarPreestructuradosConPre(String codasesorcoordinador, string estrategia, string momento, string preestructurado)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT eeb.*, pps.nombregrupo ,s.nombre as nombresede,i.nombre as nombreinstitucion,m.nombre as nombremunicipio,d.nombre as nombredepartamento FROM est_estra1preestructurados eeb inner join pro_proyectosede pps on pps.codigo=eeb.codproyectosede inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where pps.codasesorcoordinador=@codasesorcoordinador and eeb.estrategia=@estrategia and eeb.momento=@momento and preestructurado=@preestructurado order by eeb.fechacreacion DESC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@preestructurado", preestructurado);
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

    public DataTable listarEspaciosApropiacion(String codasesorcoordinador, string estrategia, string momento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT eeb.*, pps.nombregrupo ,s.nombre as nombresede,i.nombre as nombreinstitucion,m.nombre as nombremunicipio,d.nombre as nombredepartamento FROM est_estra1espacioapropiacion eeb inner join pro_proyectosede pps on pps.codigo=eeb.codproyectosede inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where pps.codasesorcoordinador=@codasesorcoordinador and eeb.estrategia=@estrategia and eeb.momento=@momento order by eeb.fecharealizacion DESC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
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
    
    public DataTable feriasinst()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT eeb.*, pps.nombregrupo ,s.nombre as nombresede,i.nombre as nombreinstitucion,m.nombre as nombremunicipio,d.nombre as nombredepartamento FROM est_estra1espacioapropiacion eeb inner join pro_proyectosede pps on pps.codigo=eeb.codproyectosede inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento and eeb.estrategia='1' and eeb.momento='5' order by eeb.fecharealizacion DESC";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp!=null)
        {
            return resp;
        }
        else
        {
            return null;
        }
    }

    public DataTable listarParticipantesFerias(String codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT eeb.*, s.nombre as nombresede,i.nombre as nombreinstitucion,m.nombre as nombremunicipio,d.nombre as nombredepartamento FROM est_estra1participantesferias eeb inner join ins_sede s on s.codigo = eeb.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where eeb.codasesorcoordinador=@codasesorcoordinador order by eeb.fecharealizacion DESC";
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

    public DataTable listarS008(String codasesorcoordinador, string estrategia, string momento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT eeb.*, pps.nombregrupo ,s.nombre as nombresede,i.nombre as nombreinstitucion,m.nombre as nombremunicipio,d.nombre as nombredepartamento FROM est_estra1instrumento_s008 eeb inner join pro_proyectosede pps on pps.codigo=eeb.codproyectosede inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where pps.codasesorcoordinador=@codasesorcoordinador and eeb.estrategia=@estrategia and eeb.momento=@momento order by eeb.fechacreacion DESC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
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

    /*2016-10-25 egragar update para bitacora 3*/
    public bool updateIntrumentobitacora3(string codigoinstrumento, string codproyecto, string respuestapregunta1, string respuestapregunta2)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra1bitacora3 SET  respuestapregunta1=@respuestapregunta1, respuestapregunta2=@respuestapregunta2 WHERE codigo=@codigoinstrumento";
        conector.CrearComando(consulta);

        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        conector.AsignarParametroCadena("@respuestapregunta1", respuestapregunta1);
        conector.AsignarParametroCadena("@respuestapregunta2", respuestapregunta2);
        return conector.guardadata();
    }

    public bool updateIntrumentobitacora7(string codigoinstrumento, string codproyecto, string proyeccion)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra1bitacora7 SET  proyeccion=@proyeccion WHERE codigo=@codigoinstrumento";
        conector.CrearComando(consulta);

        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        conector.AsignarParametroCadena("@proyeccion", proyeccion);
        return conector.guardadata();
    }

    public bool updateIntrumentoJornadasFormacion(string codigoinstrumento, string nroasistentes)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra1jornadasformacion SET  nroasistentes=@nroasistentes WHERE codigo=@codigoinstrumento";
        conector.CrearComando(consulta);

        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        conector.AsignarParametroCadena("@nroasistentes", nroasistentes);
        return conector.guardadata();
    }

    public bool updateIntrumentoPreestructurados(string codigoinstrumento, string preestructurado)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra1preestructurados SET  preestructurado=@preestructurado WHERE codigo=@codigoinstrumento";
        conector.CrearComando(consulta);

        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        conector.AsignarParametroCadena("@preestructurado", preestructurado);
        return conector.guardadata();
    }

    public bool updateEspacioApropiacion(string codigoinstrumento, string fecharealizacion, string nroestudiantes, string nrodocentes)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra1espacioapropiacion SET  fecharealizacion=@fecharealizacion, nroestudiantes=@nroestudiantes, nrodocentes=@nrodocentes WHERE codigo=@codigoinstrumento";
        conector.CrearComando(consulta);

        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        conector.AsignarParametroCadena("@fecharealizacion", fecharealizacion);
        conector.AsignarParametroCadena("@nroestudiantes", nroestudiantes);
        conector.AsignarParametroCadena("@nrodocentes", nrodocentes);
        return conector.guardadata();
    }

    public bool updateIntrumentos008(string codigoinstrumento, string resumen, string relato, string perturbacion, string superposicion, string sintesis, string aprendizaje, string conclusiones, string fuentes)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra1instrumento_s008 SET  resumen=@resumen, relato=@relato, perturbacion=@perturbacion, superposicion=@superposicion, sintesis=@sintesis, aprendizaje=@aprendizaje, conclusiones=@conclusiones, fuentes=@fuentes  WHERE codigo=@codigoinstrumento";
        conector.CrearComando(consulta);

        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        conector.AsignarParametroCadena("@resumen", resumen);
        conector.AsignarParametroCadena("@relato", relato);
        conector.AsignarParametroCadena("@perturbacion", perturbacion);
        conector.AsignarParametroCadena("@superposicion", superposicion);
        conector.AsignarParametroCadena("@sintesis", sintesis);
        conector.AsignarParametroCadena("@aprendizaje", aprendizaje);
        conector.AsignarParametroCadena("@conclusiones", conclusiones);
        conector.AsignarParametroCadena("@fuentes", fuentes);
        return conector.guardadata();
    }

    public bool eliminarMemoriaS004(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2instrumento_s004_redt WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();
    }

    public bool eliminarMemoriaS004Sedes(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2instrumento_s004_sede WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();
    }

    public bool eliminarAsistenciaS004Sedes(string codinstrumento_s004_sede)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_inasistenciasinstrumento_g001_doc WHERE codinstrumento_s004_sede = @codinstrumento_s004_sede;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstrumento_s004_sede", codinstrumento_s004_sede);
        return conector.guardadata();
    }

    public DataTable buscarAsistenciasS004Sedes(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_inasistenciasinstrumento_g001_doc WHERE codinstrumento_s004_sede=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataTable datos = conector.traerdata();
        if (datos != null)
            return datos;
        else
            return null;
    }
	
	 /*2016-10-25 04:21 pm Jonny Pacheco listar Instrumento s002*/
    public DataTable listarInstrumentos002(String codasesorcoordinador, string estrategia, string momento, string sesion)
    {
        Conexion conector = new Conexion();
        // string consulta = "select ei2.*,ea.nombre,ea.apellido,pps.nombregrupo ,s.nombre as nombresede,i.nombre as nombreinstitucion,m.nombre as nombremunicipio,d.nombre as nombredepartamento  from est_estra2instrumento_s002 ei2 inner join pro_proyectosede pps on pps.codigo=ei2.codproyecto inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento inner join est_asesorcoordinador eac on eac.codigo=ei2.codasesor inner join est_asesor ea on ea.codigo=eac.codasesor where pps.codasesorcoordinador=@codasesorcoordinador and ei2.estrategia = @estrategia and ei2.momento = @momento and ei2.sesion = @sesion order by order by ei2.fechavisita DESC";
        string consulta = "select es002.*, pps.nombregrupo, s.nombre as sede, i.nombre as institucion, m.nombre as municipio, d.nombre as departamento, (ea.nombre || ' ' || ea.apellido) as asesor from est_estra2instrumento_s002 es002 inner join pro_proyectosede pps on pps.codigo = es002.codproyecto inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento inner join est_asesorcoordinador eac on eac.codigo = es002.codasesor inner join est_asesor ea on ea.codigo = eac.codasesor where es002.codasesor = @codasesorcoordinador and es002.estrategia = @estrategia and es002.momento = @momento and es002.sesion = @sesion order by es002.fechavisita DESC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
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
    public DataTable listarInstrumentos002_docentes(String codasesorcoordinador, string estrategia, string momento, string sesion)
    {
        Conexion conector = new Conexion();
        //string consulta = "select ei2.*,ea.nombre,ea.apellido,pps.nombregrupo ,s.nombre as nombresede,i.nombre as nombreinstitucion,m.nombre as nombremunicipio,d.nombre as nombredepartamento  from est_estra2instrumento_s002 ei2 inner join pro_proyectosede pps on pps.codigo=ei2.codproyecto inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento inner join est_asesorcoordinador eac on eac.codigo=ei2.codasesor inner join est_asesor ea on ea.codigo=eac.codasesor where pps.codasesorcoordinador=@codasesorcoordinador order by ei2.fechavisita DESC";
        string consulta = "select es002.*, pps.nombregrupo, s.nombre as sede, i.nombre as institucion, m.nombre as municipio, d.nombre as departamento, (ea.nombre || ' ' || ea.apellido) as asesor from est_estra2instrumento_s002regase es002 inner join pro_grupoinvestigaciondocentes pps on pps.codigo = es002.codproyectodocente inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento inner join est_asesorcoordinador eac on eac.codigo = es002.codasesor inner join est_asesor ea on ea.codigo = eac.codasesor where es002.codasesor = @codasesorcoordinador and es002.estrategia = @estrategia and es002.momento = @momento and es002.sesion = @sesion order by es002.fechavisita DESC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
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
    public DataTable listarInstrumentos002SinSesionConAnio(String codasesorcoordinador, string estrategia, string momento, string anio)
    {
        Conexion conector = new Conexion();
        //string consulta = "select ei2.*,ea.nombre,ea.apellido,pps.nombregrupo ,s.nombre as nombresede,i.nombre as nombreinstitucion,m.nombre as nombremunicipio,d.nombre as nombredepartamento  from est_estra2instrumento_s002 ei2 inner join pro_proyectosede pps on pps.codigo=ei2.codproyecto inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento inner join est_asesorcoordinador eac on eac.codigo=ei2.codasesor inner join est_asesor ea on ea.codigo=eac.codasesor where pps.codasesorcoordinador=@codasesorcoordinador order by ei2.fechavisita DESC";
        string consulta = "select es002.*, pps.nombregrupo, s.nombre as sede, i.nombre as institucion, m.nombre as municipio, d.nombre as departamento, (ea.nombre || ' ' || ea.apellido) as asesor from est_estra2instrumento_s002 es002 inner join pro_proyectosede pps on pps.codigo = es002.codproyecto inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento inner join est_asesorcoordinador eac on eac.codigo = es002.codasesor inner join est_asesor ea on ea.codigo = eac.codasesor where es002.codasesor = @codasesorcoordinador and es002.estrategia = @estrategia and es002.momento = @momento order by es002.fechavisita DESC";
        //and extract(year from fechavisita)=@anio
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
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
    public DataTable cargarGruposInvestigacionBitacorasSupervision(string codsede)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM pro_proyectosede WHERE codsede='" + codsede + "' ORDER BY nombregrupo ASC";
        conector.CrearComando(consulta);
        //conector.AsignarParametroCadena("@codsede", codsede);
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

    public DataTable cargarGruposInvestigacionSupervision(string codsede)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM pro_proyectosede WHERE codsede='" + codsede + "'  ORDER BY nombregrupo ASC";
        conector.CrearComando(consulta);
        //conector.AsignarParametroCadena("@idsede", idsede);
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

    public DataTable cargarInfoGruposInvestigacionxCodSede(string codsede)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT ps.*, s.nombre as sede, i.nombre as institucion, m.nombre as municipio FROM pro_proyectosede ps inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio WHERE ps.codsede='" + codsede + "'  ORDER BY ps.nombregrupo ASC";
        conector.CrearComando(consulta);
        //conector.AsignarParametroCadena("@idsede", idsede);
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

    public DataRow agregarGruposxFeriaMunicipal(string codferiamunicipal, string codproyectosede)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO ep_feriasmunicipales_grupos (codferiamunicipal, codproyectosede) VALUES (@codferiamunicipal, @codproyectosede) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codferiamunicipal", codferiamunicipal);
        conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataTable cargarGruposFeriaMunicipial(string codferiamunicipal)
    {
        Conexion conector = new Conexion();
        string consulta = "select g.*, ps.nombregrupo as grupo, s.nombre as sede, i.nombre as institucion, m.nombre as municipio from ep_feriasmunicipales_grupos g inner join ep_feriasmunicipales fm on fm.codigo=g.codferiamunicipal inner join pro_proyectosede ps on ps.codigo=codproyectosede inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio where g.codferiamunicipal=@codferiamunicipal";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codferiamunicipal", codferiamunicipal);
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

    public DataTable listarBitacoraTresSupervision(string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT eeb.*, pps.nombregrupo ,s.nombre as nombresede,i.nombre as nombreinstitucion,m.nombre as nombremunicipio,d.nombre as nombredepartamento FROM est_estra1bitacora3 eeb inner join pro_proyectosede pps on pps.codigo=eeb.codproyecto inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where codasesorcoordinador=@codasesorcoordinador order by eeb.fechaejecucion DESC";
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

    public DataTable listarInstrumentos002Supervision(string codasesorcoordinador, string estrategia, string momento, string sesion)
    {
        Conexion conector = new Conexion();
        //string consulta = "select ei2.*,ea.nombre,ea.apellido,pps.nombregrupo ,s.nombre as nombresede,i.nombre as nombreinstitucion,m.nombre as nombremunicipio,d.nombre as nombredepartamento  from est_estra2instrumento_s002 ei2 inner join pro_proyectosede pps on pps.codigo=ei2.codproyecto inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento inner join est_asesorcoordinador eac on eac.codigo=ei2.codasesor inner join est_asesor ea on ea.codigo=eac.codasesor where pps.codasesorcoordinador=@codasesorcoordinador order by ei2.fechavisita DESC";
        string consulta = "select es002.*, pps.nombregrupo, s.nombre as sede, i.nombre as institucion, m.nombre as municipio, d.nombre as departamento, (ea.nombre || ' ' || ea.apellido) as asesor from est_estra2instrumento_s002 es002 inner join pro_proyectosede pps on pps.codigo = es002.codproyecto inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento inner join est_asesorcoordinador eac on eac.codigo = es002.codasesor inner join est_asesor ea on ea.codigo = eac.codasesor where es002.estrategia = @estrategia and es002.momento = @momento and es002.sesion = @sesion and es002.codasesor=@codasesorcoordinador order by es002.fechavisita DESC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@sesion", sesion);
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

    public DataTable cargarAnios()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * from ins_anio  order by codigo DESC";
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

    public DataTable cargarareasintroiep()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * from est_estra2introieparea  order by nombre ASC";
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

    public DataTable cargarListadoMaterialesxCoordinador(string codestracoordinador, string offset, string limit)
    {
        Conexion conector = new Conexion();
        string consulta = "select g006.*, concat_ws(' ',a.nombre,a.apellido) as coordinador,  s.nombre as sede, i.nombre as institucion, m.nombre as municipio from est_estra2instrumento_g006 g006 inner join est_estracoordinador ac on g006.codestracoordinador=ac.codigo inner join est_coordinador a on a.codigo=ac.codcoordinador inner join ins_sede s on s.codigo=g006.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio where g006.codestracoordinador=@codestracoordinador offset @offset limit  @limit";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
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

    public DataTable cargarListadoMaterialessinCoordinador(string offset, string limit)
    {
        Conexion conector = new Conexion();
        string consulta = "select g006.*, concat_ws(' ',a.nombre,a.apellido) as coordinador,  s.nombre as sede, i.nombre as institucion, m.nombre as municipio from est_estra2instrumento_g006 g006 inner join est_estracoordinador ac on g006.codestracoordinador=ac.codigo inner join est_coordinador a on a.codigo=ac.codcoordinador inner join ins_sede s on s.codigo=g006.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio offset @offset limit  @limit";
        conector.CrearComando(consulta);
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

    public DataTable cargarListadoMaterialesxAsesorEstra1(string codasesorcoordinador, string offset, string limit)
    {
        Conexion conector = new Conexion();
        string consulta = "select g006.*, concat_ws(' ',a.nombre,a.apellido) as asesor,  s.nombre as sede, i.nombre as institucion, m.nombre as municipio from est_estra1instrumento_g006 g006 inner join est_asesorcoordinador ac on g006.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=g006.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio where g006.codasesorcoordinador=@codasesorcoordinador offset @offset limit  @limit";
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

    public DataTable cargarListadoMaterialesxAsesorEstra1Count(string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "select g006.*, concat_ws(' ',a.nombre,a.apellido) as asesor,  s.nombre as sede, i.nombre as institucion, m.nombre as municipio from est_estra1instrumento_g006 g006 inner join est_asesorcoordinador ac on g006.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=g006.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio where g006.codasesorcoordinador=@codasesorcoordinador";
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

    public DataTable cargarListadoMaterialesxAsesorEstra4(string codestracoordinador, string offset, string limit)
    {
        Conexion conector = new Conexion();
        string consulta = "select g006.*, concat_ws(' ',a.nombre,a.apellido) as asesor,  s.nombre as sede, i.nombre as institucion, m.nombre as municipio from est_estra4instrumento_g006 g006 inner join est_estracoordinador ac on g006.codestracoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=g006.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio where g006.codestracoordinador=@codestracoordinador offset @offset limit  @limit";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
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

    public DataTable cargarListadoMaterialesxAsesorEstra4Todo(string codestracoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "select g006.*, concat_ws(' ',a.nombre,a.apellido) as asesor,  s.nombre as sede, i.nombre as institucion, m.nombre as municipio from est_estra4instrumento_g006 g006 inner join est_estracoordinador ac on g006.codestracoordinador=ac.codigo inner join est_coordinador a on a.codigo=ac.codcoordinador inner join ins_sede s on s.codigo=g006.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio where g006.codestracoordinador=@codestracoordinador ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
        //conector.AsignarParametroCadena("@offset", offset);
        //conector.AsignarParametroCadena("@limit", limit);
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

    public DataTable cargarListadoMaterialesxAsesorEstra4TodoSin()
    {
        Conexion conector = new Conexion();
        string consulta = "select g006.*, concat_ws(' ',a.nombre,a.apellido) as asesor,  s.nombre as sede, i.nombre as institucion, m.nombre as municipio from est_estra4instrumento_g006 g006 inner join est_estracoordinador ac on g006.codestracoordinador=ac.codigo inner join est_coordinador a on a.codigo=ac.codcoordinador inner join ins_sede s on s.codigo=g006.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio ";
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

    public DataTable cargarListadoMaterialesxAsesorxAnio(string codasesorcoordinador, string anio)
    {
        Conexion conector = new Conexion();
        string consulta = "select g006.*, concat_ws(' ',a.nombre,a.apellido) as asesor,  s.nombre as sede, i.nombre as institucion, m.nombre as municipio from est_estra2instrumento_g006 g006 inner join est_asesorcoordinador ac on g006.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=g006.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio where g006.codasesorcoordinador=@codasesorcoordinador and extract(year from g006.fechaentregamaterial)=@anio  ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@anio", anio);

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

    public DataTable cargarListadoMaterialesxSedexAnio(string codsede, string anio)
    {
        Conexion conector = new Conexion();
        string consulta = "select g006.*, concat_ws(' ',a.nombre,a.apellido) as asesor,  s.nombre as sede, i.nombre as institucion, m.nombre as municipio from est_estra2instrumento_g006 g006 inner join est_asesorcoordinador ac on g006.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=g006.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio where g006.codsede=@codsede and extract(year from g006.fechaentregamaterial)=@anio  ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@anio", anio);

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

    public DataTable cargarListadoMaterialesxCoordinadorCount(string codestracoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "select count(*) from est_estra2instrumento_g006 g006 inner join est_estracoordinador ac on g006.codestracoordinador=ac.codigo inner join est_coordinador a on a.codigo=ac.codcoordinador inner join ins_sede s on s.codigo=g006.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio where g006.codestracoordinador=@codestracoordinador ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);

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

    public DataTable cargarListadoMaterialessinCoordinadorCount()
    {
        Conexion conector = new Conexion();
        string consulta = "select count(*) from est_estra2instrumento_g006 g006 inner join est_estracoordinador ac on g006.codestracoordinador=ac.codigo inner join est_coordinador a on a.codigo=ac.codcoordinador inner join ins_sede s on s.codigo=g006.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio ";
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
    

    public DataTable cargarListadoMaterialesxAsesorCountEstra1(string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "select count(*) from est_estra1instrumento_g006 g006 inner join est_asesorcoordinador ac on g006.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=g006.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio where g006.codasesorcoordinador=@codasesorcoordinador ";
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

    public DataTable cargarListadoMaterialesxAsesorCountEstra4(string codestracoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "select count(*) from est_estra4instrumento_g006 g006 inner join est_estracoordinador ac on g006.codestracoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=g006.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio where g006.codestracoordinador=@codestracoordinador ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);

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

    public DataTable cargarListadoMaterialesxAsesorCountEstra4Sin()
    {
        Conexion conector = new Conexion();
        string consulta = "select count(*) from est_estra4instrumento_g006 g006 inner join est_estracoordinador ac on g006.codestracoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=g006.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio ";
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

    public bool eliminarEncabezadoEntregaMaterial(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2instrumento_g006 WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();
    }

    public bool eliminarEncabezadoEntregaMaterialEstra1(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1instrumento_g006 WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();
    }

    public bool eliminarEncabezadoEntregaMaterialEstra4(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra4instrumento_g006 WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();
    }

    public bool eliminarDetalleMaterialEstra4(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra4instrumento_g006material WHERE codestrainstrumento_g006 = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();
    }

    public bool eliminarEncabezadoBitacora4punto1(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora4punto1 WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();
    }

    public bool eliminarDetalleBitacora4punto1_correo(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora4punto1_correointernet WHERE codbitacora4punto1 = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();
    }

    public bool eliminarDetalleBitacora4punto1_insumos(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora4punto1_insumos WHERE codbitacora4punto1 = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();
    }

    public bool eliminarDetalleBitacora4punto1_materialdivulgacion(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora4punto1_materialdivulgacion WHERE codbitacora4punto1 = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();
    }

    public bool eliminarDetalleBitacora4punto1_papeleria(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora4punto1_papeleria WHERE codbitacora4punto1 = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();
    }

    public bool eliminarDetalleBitacora4punto1_refrigerios(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora4punto1_refrigerios WHERE codbitacora4punto1 = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();
    }

    public bool eliminarDetalleBitacora4punto1_transporte(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora4punto1_transporte WHERE codbitacora4punto1 = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();
    }

    public bool eliminarEvidenciasEntregaMaterial(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositorioasesor_g006 WHERE codinstrumento = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();
    }

    public bool eliminarEvidenciasEntregaMaterialEstra1(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositorioasesor_g006_estra1 WHERE codinstrumento = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();
    }

    public bool eliminarEvidenciasEntregaMaterialEstra4(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_repositorioasesor_g006_estra4 WHERE codinstrumento = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();
    }

    public DataTable cargarListadoAsesoresxCoordinador(string codcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "select ac.codigo as codasesorcoordinador, concat_ws(' ', a.nombre,a.apellido) as nomasesor from est_asesor a inner join est_asesorcoordinador ac on a.codigo=ac.codasesor inner join est_estracoordinador ec on ec.codigo=ac.codestracoordinador inner join est_coordinador c on c.codigo=ec.codcoordinador where ec.codcoordinador=@codcoordinador";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codcoordinador", codcoordinador);
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

    public DataTable cargarListadoAsesoresxCoordinadorSeguimiento(string codcoordinador, string anio)
    {
        Conexion conector = new Conexion();
        string consulta = "select ac.codigo as codasesorcoordinador, concat_ws(' ', a.nombre,a.apellido) as nomasesor from est_asesor a inner join est_asesorcoordinador ac on a.codigo=ac.codasesor inner join est_estracoordinador ec on ec.codigo=ac.codestracoordinador inner join est_coordinador c on c.codigo=ec.codcoordinador inner join est_asesorestado ae on ae.codasesor=a.codigo where ec.codcoordinador=@codcoordinador and ae.anio=@anio";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codcoordinador", codcoordinador);
        conector.AsignarParametroCadena("@anio", anio);
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

    public DataTable cargarListadoAsesoresxCoordinadorGI(string codcoordinador, string anio)
    {
        Conexion conector = new Conexion();
        string consulta = "select ac.codigo as codasesorcoordinador, concat_ws(' ', a.nombre,a.apellido) as nomasesor from est_asesor a inner join est_asesorcoordinador ac on a.codigo=ac.codasesor inner join est_estracoordinador ec on ec.codigo=ac.codestracoordinador inner join est_coordinador c on c.codigo=ec.codcoordinador where ec.codcoordinador=@codcoordinador and ae.anio=@anio";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codcoordinador", codcoordinador);
        conector.AsignarParametroCadena("@anio", anio);
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


    /////////////
    public long procupdateestras004_2016(string codigoestrategia, string redtematica, string nombresesion, string temasesion, string informacionadicional, string fechaelaboracion, string nombrerelator, string horasesion, string aspectosdesarrollados, string conclusiones, string bibliografia)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra2instrumento_s004_redt_2016 SET nombresesion = @nombresesion, temasesion = @temasesion, informacionadicional=@informacionadicional, fechaelaboracion = @fechaelaboracion, nombrerelator=@nombrerelator, aspectosdesarrollados=@aspectosdesarrollados, conclusiones=@conclusiones, bibliografia=@bibliografia WHERE codigo = @codigoestrategia";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombresesion", nombresesion);
        conector.AsignarParametroCadena("@temasesion", temasesion);
        conector.AsignarParametroCadena("@informacionadicional", informacionadicional);
        conector.AsignarParametroCadena("@fechaelaboracion", fechaelaboracion + " " + horasesion + ":00");
        conector.AsignarParametroCadena("@nombrerelator", nombrerelator);
        conector.AsignarParametroCadena("@aspectosdesarrollados", aspectosdesarrollados);
        conector.AsignarParametroCadena("@conclusiones", conclusiones);
        conector.AsignarParametroCadena("@bibliografia", bibliografia);
        conector.AsignarParametroCadena("@codigoestrategia", codigoestrategia);

        long resp = conector.guardadataid();
        return resp;
    }

    public DataRow insertestras004_2016(string redtematica, string nombresesion, string temasesion, string informacionadicional, string fechaelaboracion, string nombrerelator, string horasesion, string codestracoordinador, string aspectosdesarrollados, string conclusiones, string bibliografia, string estrategia, string momento, string sesion)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra2instrumento_s004_redt_2016 (codasesorcoordinador, nombresesion, codredtematicasede, temasesion, informacionadicional, fechaelaboracion, nombrerelator, aspectosdesarrollados, conclusiones, bibliografia, estrategia, momento, sesion) VALUES (@codestracoordinador,  @nombresesion, @redtematica, @temasesion, @informacionadicional, @fechaelaboracion, @nombrerelator, @aspectosdesarrollados, @conclusiones, @bibliografia, @estrategia,@momento, @sesion) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
        conector.AsignarParametroCadena("@redtematica", redtematica);
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
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow proloadestras004_2016(string codigoestra, string estrategia, string momento, string sesion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, codasesorcoordinador, nombresesion, temasesion, informacionadicional, fechaelaboracion, nombrerelator, aspectosdesarrollados, conclusiones, bibliografia FROM est_estra2instrumento_s004_redt_2016 WHERE codigo = @codigoestra and estrategia=@estrategia and momento=@momento and sesion=@sesion";
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


    public bool eliminarMemoriaS004_2016(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2instrumento_s004_redt_2016 WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();
    }

    //codigo bitacora 4_1

    public DataRow procloadBitacora4_1(string codigoinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT  eb4_1.codigo as codigoinstrumento, eb4_1.*, gdep.nombre as nombredepartamento, gmun.cod as codigomunicipio, gmun.nombre as nombremunicipio, isede.codigo as codigosede, isede.nombre as nombresede, iin.codigo as codigoinstitucion, iin.nombre as nombreins, pps.nombregrupo FROM est_estra1bitacora4punto1 eb4_1 INNER JOIN pro_proyectosede pps ON pps.codigo = eb4_1.codproyectosede INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio  INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE eb4_1.codigo = @codigoinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow procinsertbitacora4_1(string grupoinvestigacion, string firmamaestro, string firmanino, string fechadiligenciamiento, string firmaasesor, string desembolso, string codasesor)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra1bitacora4punto1 (codproyectosede, fechadiligenciamiento, firmamaestro, firmanino, firmaasesor,desembolso, codasesor) VALUES (@grupoinvestigacion, @fechadiligenciamiento, @firmamaestro, @firmanino, @firmaasesor, @desembolso, @codasesor) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@grupoinvestigacion", grupoinvestigacion);
        conector.AsignarParametroCadena("@firmamaestro", firmamaestro);
        conector.AsignarParametroCadena("@firmanino", firmanino);
        conector.AsignarParametroCadena("@fechadiligenciamiento", fechadiligenciamiento);
        conector.AsignarParametroCadena("@firmaasesor", firmaasesor);
        conector.AsignarParametroCadena("@desembolso", desembolso);
        conector.AsignarParametroCadena("@codasesor", codasesor);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow buscarinsertbitacora4_1(string grupoinvestigacion, string codasesor, string desembolso)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT 1 from est_estra1bitacora4punto1 where codproyectosede=@grupoinvestigacion and desembolso=@desembolso and codasesor=@codasesor ;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@grupoinvestigacion", grupoinvestigacion);
        conector.AsignarParametroCadena("@desembolso", desembolso);
        conector.AsignarParametroCadena("@codasesor", codasesor);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public long procupdatebitacora4_1(string codigoinstrumento, string firmamaestro, string firmanino, string fechadiligenciamiento, string firmaasesor)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra1bitacora4punto1 SET  fechadiligenciamiento=@fechadiligenciamiento, firmamaestro=@firmamaestro, firmanino=@firmanino, firmaasesor=@firmaasesor WHERE codigo=@codigoinstrumento";
        conector.CrearComando(consulta);

        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        conector.AsignarParametroCadena("@firmamaestro", firmamaestro);
        conector.AsignarParametroCadena("@firmanino", firmanino);
        conector.AsignarParametroCadena("@fechadiligenciamiento", fechadiligenciamiento);
        conector.AsignarParametroCadena("@firmaasesor", firmaasesor);
        long resp = conector.guardadataid();
        return resp;
    }

    public DataTable proclistarBitacora4_1(string codasesorcoordinador, string desembolso)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT eb4_1.codigo as codigoinstrumento, eb4_1.*, gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, isede.nombre as nombresede, iin.nombre as nombreins, pps.nombregrupo FROM est_estra1bitacora4punto1 eb4_1 INNER JOIN pro_proyectosede pps ON pps.codigo = eb4_1.codproyectosede INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio  INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE pps.codasesorcoordinador = @codasesor and desembolso=@desembolso ORDER BY eb4_1.codigo DESC ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesor", codasesorcoordinador);
        conector.AsignarParametroCadena("@desembolso", desembolso);
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

    public long procDeleteRubrosInsumos(string codigoinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora4punto1_insumos WHERE codbitacora4punto1 = @codigoinstrumento;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        long resp = conector.guardadataid();
        return resp;
    }
    public long procDeleteRubrosPapeleria(string codigoinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora4punto1_papeleria WHERE codbitacora4punto1 = @codigoinstrumento;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        long resp = conector.guardadataid();
        return resp;
    }

    public long procDeleteRubrosTransporte(string codigoinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora4punto1_transporte WHERE codbitacora4punto1 = @codigoinstrumento;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        long resp = conector.guardadataid();
        return resp;
    }

    public long procDeleteRubrosCorreo(string codigoinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora4punto1_correointernet WHERE codbitacora4punto1 = @codigoinstrumento;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        long resp = conector.guardadataid();
        return resp;
    }

    public long procDeleteRubrosMaterial(string codigoinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora4punto1_materialdivulgacion WHERE codbitacora4punto1 = @codigoinstrumento;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        long resp = conector.guardadataid();
        return resp;
    }

    public long procDeleteRubrosRefrigerios(string codigoinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora4punto1_refrigerios WHERE codbitacora4punto1 = @codigoinstrumento;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        long resp = conector.guardadataid();
        return resp;
    }

    public DataRow procInsertRubro(string tabla, string codigoinstrumento, string fechagasto, string nombreproveedor, string ccnit, string cantidad, string descripciongasto, string valorunitario, string valortotal)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO " + tabla + " (codbitacora4punto1, fechagasto, nombreproveedor, ccnit, cantidad, descripcion, valorunitario, valortotal) VALUES (@codigoinstrumento, @fechagasto, @nombreproveedor, @ccnit, @cantidad, @descripcion, @valorunitario, @valortotal) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
        conector.AsignarParametroCadena("@fechagasto", fechagasto);
        conector.AsignarParametroCadena("@nombreproveedor", nombreproveedor);
        conector.AsignarParametroCadena("@ccnit", ccnit);
        conector.AsignarParametroCadena("@cantidad", cantidad);
        conector.AsignarParametroCadena("@descripcion", descripciongasto);
        conector.AsignarParametroCadena("@valorunitario", valorunitario);
        conector.AsignarParametroCadena("@valortotal", valortotal);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataTable procloadRubro(string tabla, string codigoinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, codbitacora4punto1, fechagasto, nombreproveedor, ccnit, cantidad, descripcion, valorunitario, valortotal FROM " + tabla + " WHERE codbitacora4punto1=@codigoinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoinstrumento", codigoinstrumento);
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

    public DataTable cargarIndicadoresMunicipioxDepartamento(string coddepartamento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT gmun.cod as codigomunicipio, gmun.nombre as nombremunicipio, SUM(ind.totalesturedestematicas) as totalestu FROM est_indicadoresestudiantes ind INNER JOIN ins_sede isede ON isede.codigo = ind.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE gdep.cod = @coddepartamento GROUP BY gmun.cod, gmun.nombre";
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

    public DataRow totalesturedestematicasxDepartamento(string coddepartamento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT sum(ind.totalesturedestematicas) as totalesturedes  FROM est_indicadoresestudiantes ind INNER JOIN ins_sede isede ON isede.codigo = ind.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE gdep.cod = @coddepartamento GROUP BY gdep.cod ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddepartamento", coddepartamento);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataTable proccargarInstitucionxMunicipiosoloNombre(string codmunicipio)
    {
        Conexion conector = new Conexion();
        string consulta = "select codigo, nombre, dane from ins_institucion WHERE codmunicipio=@codmunicipio ORDER BY nombre ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
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

    public DataTable proccargarInstitucionxMunicipiosoloNombreSinMuni()
    {
        Conexion conector = new Conexion();
        string consulta = "select codigo, nombre, dane from ins_institucion  ORDER BY nombre ASC";
        conector.CrearComando(consulta);
        //conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
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

    public DataRow totalesturedestematicas(string codmunicipio)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT sum(ind.totalesturedestematicas) as totalesturedes  FROM est_indicadoresestudiantes ind INNER JOIN ins_sede isede ON isede.codigo = ind.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE ind.codmunicipio = @codmunicipio GROUP BY ind.codmunicipio ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataTable cargarIndicadoresSedesInstitucion(string codinstitucion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT isede.codigo as codigosede, isede.nombre as nombresede, ind.totalesturedestematicas FROM est_indicadoresestudiantes ind INNER JOIN ins_sede isede ON isede.codigo = ind.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE ind.codinstitucion = @codinstitucion ORDER BY ind.codigo ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstitucion", codinstitucion);
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
    //cargar total de grupos de investigacion x sede
    public DataRow loadTotalesIndicadoresxSede(string codsede)
    {

        Conexion conector = new Conexion();
        String consulta = "SELECT codigo, codmunicipio, codinstitucion, codsede, totalesturedestematicas, totalgrupos, totalasistentesasesorias, metanoasesoria, numeroredes, totalsesionpresencial, totalsesionvirtual, totalkits FROM est_indicadoresestudiantes WHERE codsede = @codsede";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public DataRow loadTotalesIndicadoresxSedeSUM(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {

        Conexion conector = new Conexion();

        int numero = 4;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;


        if (codmunicipio != "" && codmunicipio != null)
        {
            cond[1] = "codmunicipio='" + codmunicipio + "'";
        }
        if (codinstitucion != "" && codinstitucion != "null")
        {
            cond[2] = "codinstitucion='" + codinstitucion + "'";
        }
        if (codsede != "" && codsede != "null")
        {
            cond[3] = "codsede='" + codsede + "'";
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

        String consulta = "SELECT SUM(totalesturedestematicas) totalesturedestematicas, SUM(totalgrupos) totalgrupos, SUM(totalasistentesasesorias) totalasistentesasesorias, SUM(metanoasesoria) metanoasesoria, SUM(numeroredes) numeroredes, SUM(totalsesionpresencial) totalsesionpresencial, SUM(totalsesionvirtual) totalsesionvirtual, SUM(totalkits) totalkits, SUM(totaltablets) totaltablets FROM est_indicadoresestudiantes " + where;
        conector.CrearComando(consulta);
        
        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public DataRow proccargardatosinsxcod(string codinstitucion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM ins_institucion WHERE codigo =  @codinstitucion";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstitucion", codinstitucion);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow proccargardatosmunicipioxcod(string codmunicipio)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM geo_municipios WHERE cod =  @codmunicipio";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow loadTotalesIndicadoresxMunicipio(string codmunicipio)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT gmun.cod as codigomunicipio, gmun.nombre as nombremunicipio, SUM(ind.totalesturedestematicas) as totalestu FROM est_indicadoresestudiantes ind INNER JOIN ins_sede isede ON isede.codigo = ind.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE gmun.cod = @codmunicipio GROUP BY gmun.cod, gmun.nombre";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;

    }

    //total grupos de investigacion por municipio
    public DataRow totalgpxMunicipio(string codmunicipio)
    {
        Conexion conector = new Conexion();

        int numero = 2;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        cond[1] = string.Empty;
       
        if (codmunicipio != "" && codmunicipio != null)
        {
            cond[1] = "iin.codmunicipio='" + codmunicipio + "'";
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

        string consulta = "SELECT sum(ind.totalgrupos) as totalgrupos FROM est_indicadoresestudiantes ind INNER JOIN ins_sede isede ON isede.codigo = ind.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where;
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    //NUEVO CODIGOO
   
   

    public DataTable cargarListadoSesionVirtualEstraDos(string sesion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT a.*, s.nombre as sede, i.nombre as institucion, m.nombre as municipio from est_estra2sesionvirtual a inner join ins_sede s on s.codigo=a.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio where sesion=@sesion";
        //string consulta = "SELECT a.*, (select count(*) from est_estra2sesionvirtualdetalle where a.codigo=codsesionvirtual) as nroasistentes, s.nombre as sede, i.nombre as institucion, m.nombre as municipio, concat_ws('',a.nombre,a.apellido) as coordinador from est_estra2sesionvirtual a inner join ins_sede s on s.codigo=a.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codinstitucion inner join est_estracoordinador ec on a.codestracoordinador=ec.codigo inner join est_coordinador c on c.codigo=ec.codcoordinador  order by a.fecha DESC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@sesion", sesion);
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

    public DataTable cargarListadoSesionComiteDepartamental()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT c.*, m.nombre as municipio from est_estra5comitedepartamental c inner join geo_municipios m on m.cod=c.codmunicipio ";
        conector.CrearComando(consulta);
        //conector.AsignarParametroCadena("@sesion", sesion);
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

    public DataTable cargarListadoSesionComiteRegional()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT c.*, m.nombre as municipio from est_estra5comiteregional c inner join geo_municipios m on m.cod=c.codmunicipio ";
        conector.CrearComando(consulta);
        //conector.AsignarParametroCadena("@sesion", sesion);
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

    public DataTable cargarListadoSesionComiteRedApoyo()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT c.*, m.nombre as municipio from est_estra5comiteredapoyo c inner join geo_municipios m on m.cod=c.codmunicipio ";
        conector.CrearComando(consulta);
        //conector.AsignarParametroCadena("@sesion", sesion);
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

    public DataTable cargarListadoGruposInvestigacionDesembolso()
    {
        Conexion conector = new Conexion();
        string consulta = "select ps.codigo, m.nombre municipio, i.nombre institucion, s.nombre sede, ps.nombregrupo, (select preguntainvestigacion from est_estra1bitacora2 where ps.codigo=codproyecto limit 1), (select recibido as primerdesembolso from est_estra1bitacora4punto1 where codproyectosede=ps.codigo and desembolso='1'), (select recibido as segundodesembolso from est_estra1bitacora4punto1 where codproyectosede=ps.codigo and desembolso='2'), (select recibido as tercerdesembolso from est_estra1bitacora4punto1 where codproyectosede=ps.codigo and desembolso='3') from pro_proyectosede ps inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio";
        //string consulta = "select ps.codigo, m.nombre municipio, i.nombre institucion, s.nombre sede, ps.nombregrupo, (select preguntainvestigacion from est_estra1bitacora2 where ps.codigo=codproyecto limit 1), (select actividad as primerdesembolso from est_estra1bitacora4punto1_evi where codproyectosede=ps.codigo and desembolso='1'), (select actividad as segundodesembolso from est_estra1bitacora4punto1_evi where codproyectosede=ps.codigo and desembolso='2'), (select actividad as tercerdesembolso from est_estra1bitacora4punto1_evi where codproyectosede=ps.codigo and desembolso='3') from pro_proyectosede ps inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio";
        //string consulta = "select b1.codigo, b1.codproyectosede, m.nombre municipio, i.nombre institucion, s.nombre sede, ps.nombregrupo, (select preguntainvestigacion from est_estra1bitacora2 where ps.codigo=codproyecto), (select recibido primerdesembolso from est_estra1bitacora4punto1 where codigo=b1.codigo and desembolso='1'), (select recibido segundodesembolso from est_estra1bitacora4punto1 where codigo=b1.codigo and desembolso='2'), (select recibido tercerdesembolso from est_estra1bitacora4punto1 where codigo=b1.codigo and desembolso='3') from est_estra1bitacora4punto1 b1 inner join pro_proyectosede ps on ps.codigo=b1.codproyectosede inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio";
        conector.CrearComando(consulta);
        //conector.AsignarParametroCadena("@sesion", sesion);
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

    public DataTable cargarListadointroiepEstraDos()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT a.*, s.nombre as sede, i.nombre as institucion, m.nombre as municipio, (select count(*) from est_estra2introiepdetalle where codestra2introiep=a.codigo) as nroasistentes from est_estra2introiep a inner join ins_sede s on s.codigo=a.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio";
        //string consulta = "SELECT a.*, (select count(*) from est_estra2sesionvirtualdetalle where a.codigo=codsesionvirtual) as nroasistentes, s.nombre as sede, i.nombre as institucion, m.nombre as municipio, concat_ws('',a.nombre,a.apellido) as coordinador from est_estra2sesionvirtual a inner join ins_sede s on s.codigo=a.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codinstitucion inner join est_estracoordinador ec on a.codestracoordinador=ec.codigo inner join est_coordinador c on c.codigo=ec.codcoordinador  order by a.fecha DESC";
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

    public DataTable cargarListadocontenidodigitalEstraDos()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT a.*, s.nombre as sede, i.nombre as institucion, m.nombre as municipio, (select count(*) from est_estra2contedigitaldetalle where codestra2contedigital=a.codigo) as nroasistentes from est_estra2contedigital a inner join ins_sede s on s.codigo=a.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio";
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

    public DataTable cargarListadocontenidodigitalEstraDosActualizado()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT a.*, concat_ws(' ',c.nombre,c.apellido) as coordinador, an.nombre as anio from est_estra2contedigital a inner join est_estracoordinador ec on ec.codigo=a.codestracoordinador inner join est_coordinador c on c.codigo=ec.codcoordinador inner join ins_anio an on an.codigo=a.codanio";
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

    public DataRow buscarSesionVirtualEstraDos(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT a.*, s.nombre as sede, i.nombre as institucion, m.nombre as municipio from est_estra2sesionvirtual a inner join ins_sede s on s.codigo=a.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio where a.codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
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

    public DataRow buscarSesionComiteDepartamental(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT a.* from est_estra5comitedepartamental a inner join geo_municipios m on m.cod=a.codmunicipio where a.codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
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

    public DataRow buscarSesionComiteRegional(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT a.* from est_estra5comiteregional a inner join geo_municipios m on m.cod=a.codmunicipio where a.codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
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

    public DataRow buscarSesionComiteRedApoyo(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT a.* from est_estra5comiteredapoyo a inner join geo_municipios m on m.cod=a.codmunicipio where a.codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
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

    public DataRow buscarbitacorapuntunoxcodproyectosede(string codproyectosede, string desembolso)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT a.*, ps.nombregrupo from est_estra1bitacora4punto1 a inner join pro_proyectosede ps on ps.codigo=a.codproyectosede where a.codproyectosede=@codigo and desembolso=@desembolso";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codproyectosede);
        conector.AsignarParametroCadena("@desembolso", desembolso);
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

    public DataRow buscarintroiepEstraDos(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT a.*, s.nombre as sede, i.nombre as institucion, m.nombre as municipio, m.cod as codmunicipio, i.codigo as codinstitucion, area.nombre as nomarea from est_estra2introiep a inner join ins_sede s on s.codigo=a.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio inner join est_estra2introieparea area on area.codigo=a.codintroieparea where a.codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
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

    public DataRow buscarcontenidodigitalEstraDos(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT a.*, s.nombre as sede, i.nombre as institucion, m.nombre as municipio, m.cod as codmunicipio, i.codigo as codinstitucion, area.nombre as nomarea from est_estra2contedigital a inner join ins_sede s on s.codigo=a.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio inner join est_estra2introieparea area on area.codigo=a.codintroieparea where a.codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
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

    public DataTable buscardocentesintroiepestrados(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT det.*, concat_ws('',d.nombre,d.apellido) as docente, d.identificacion, gd.codanio, a.nombre from est_estra2introiepdetalle det inner join ins_gradodocente gd on gd.cod=det.codgradodocente inner join ins_docente d on d.identificacion=gd.identificacion inner join ins_anio a on a.codigo=gd.codanio where det.codestra2introiep=@codigo";
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

    public DataTable buscardocentescontenidodigitalestrados(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT det.*, concat_ws('',d.nombre,d.apellido) as docente, d.identificacion, gd.codanio, a.nombre from est_estra2contedigitaldetalle det inner join ins_gradodocente gd on gd.cod=det.codgradodocente inner join ins_docente d on d.identificacion=gd.identificacion inner join ins_anio a on a.codigo=gd.codanio where det.codestra2contedigital=@codigo";
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

    public Boolean actualizarasistentessesionvirtual(String codigo, string nroasistentes, string autoformacion, string produccion)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra2sesionvirtual SET nroasistentes=@nroasistentes, autoformacion=@autoformacion, produccion=@produccion where codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        conector.AsignarParametroCadena("@nroasistentes", nroasistentes);
        conector.AsignarParametroCadena("@autoformacion", autoformacion);
        conector.AsignarParametroCadena("@produccion", produccion);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean actualizarcomitedepartamental(String codigo, string codmunicipio, string fecha, string lugar, string hora, string participantes, string entidades, string objetivos, string desarrollo)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra5comitedepartamental SET codmunicipio=@codmunicipio, fecha=@fecha, lugar=@lugar, hora=@hora, participantes=@participantes, entidades=@entidades, desarrollo=@desarrollo, objetivo=@objetivos where codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        conector.AsignarParametroCadena("@fecha", fecha);
        conector.AsignarParametroCadena("@lugar", lugar);
        conector.AsignarParametroCadena("@hora", hora);
        conector.AsignarParametroCadena("@participantes", participantes);
        conector.AsignarParametroCadena("@entidades", entidades);
        conector.AsignarParametroCadena("@objetivos", objetivos);
        conector.AsignarParametroCadena("@desarrollo", desarrollo);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean actualizarcomiteregional(String codigo, string codmunicipio, string fecha, string lugar, string hora, string participantes, string entidades, string objetivos, string desarrollo)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra5comiteregional SET codmunicipio=@codmunicipio, fecha=@fecha, lugar=@lugar, hora=@hora, participantes=@participantes, entidades=@entidades, desarrollo=@desarrollo, objetivo=@objetivos where codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        conector.AsignarParametroCadena("@fecha", fecha);
        conector.AsignarParametroCadena("@lugar", lugar);
        conector.AsignarParametroCadena("@hora", hora);
        conector.AsignarParametroCadena("@participantes", participantes);
        conector.AsignarParametroCadena("@entidades", entidades);
        conector.AsignarParametroCadena("@objetivos", objetivos);
        conector.AsignarParametroCadena("@desarrollo", desarrollo);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean actualizarcomiteredapoyo(String codigo, string codmunicipio, string fecha, string lugar, string hora, string participantes, string entidades, string objetivos, string desarrollo)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_estra5comiteredapoyo SET codmunicipio=@codmunicipio, fecha=@fecha, lugar=@lugar, hora=@hora, participantes=@participantes, entidades=@entidades, desarrollo=@desarrollo, objetivo=@objetivos where codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        conector.AsignarParametroCadena("@fecha", fecha);
        conector.AsignarParametroCadena("@lugar", lugar);
        conector.AsignarParametroCadena("@hora", hora);
        conector.AsignarParametroCadena("@participantes", participantes);
        conector.AsignarParametroCadena("@entidades", entidades);
        conector.AsignarParametroCadena("@objetivos", objetivos);
        conector.AsignarParametroCadena("@desarrollo", desarrollo);
        bool resp = conector.guardadata();
        return resp;
    }

   

    public DataTable cargarIndicadoresxMunicipio(string codmunicipio)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT ind.codigo as codigopri, isede.codigo as codigosede, isede.nombre as nombresede, iin.codigo as codigoins, iin.nombre nombreins,  totalesturedestematicas,totalgrupos,totalasistentesasesorias, metanoasesoria, numeroredes, totalsesionpresencial,  totalsesionvirtual FROM est_indicadoresestudiantes ind INNER JOIN ins_sede isede ON isede.codigo = ind.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE gmun.cod = @codmunicipio ORDER BY isede.codigo ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
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


    public long updateDatosIndicadoresGenerals(string codigo, string esturedestematicas, string totalgrupoinv, string asistentesasesoria, string metaasesoria, string numeroredes, string sesionpresencial, string sesionvirtual)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_indicadoresestudiantes SET totalesturedestematicas = @esturedestematicas, totalgrupos = @totalgrupoinv, totalasistentesasesorias = @asistentesasesoria, metanoasesoria = @metaasesoria, numeroredes = @numeroredes, totalsesionpresencial = @sesionpresencial, totalsesionvirtual = @sesionvirtual WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        conector.AsignarParametroCadena("@esturedestematicas", esturedestematicas);
        conector.AsignarParametroCadena("@totalgrupoinv", totalgrupoinv);
        conector.AsignarParametroCadena("@asistentesasesoria", asistentesasesoria);
        conector.AsignarParametroCadena("@metaasesoria", metaasesoria);
        conector.AsignarParametroCadena("@numeroredes", numeroredes);
        conector.AsignarParametroCadena("@sesionpresencial", sesionpresencial);
        conector.AsignarParametroCadena("@sesionvirtual", sesionvirtual);
        long resp = conector.guardadataid();
        return resp;
    }


    public DataTable cargarInstitucionySedexMunicipio(string codmunicipio)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT iin.codigo codigoins, iin.nombre nombreins , isede.codigo as codsede, isede.nombre as nombresede FROM ins_sede isede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE gmun.cod = @codmunicipio ORDER BY isede.codigo ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
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


    public DataRow procinsertDatos(string codmunicipio, string codigoins, string codigosede, string esturedestematicas, string totalgrupoinv, string asistentesasesoria, string metaasesoria, string numeroredes, string sesionpresencial, string sesionvirtual)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_indicadoresestudiantes (codmunicipio, codinstitucion, codsede, totalesturedestematicas, totalgrupos, totalasistentesasesorias, metanoasesoria, numeroredes, totalsesionpresencial, totalsesionvirtual) VALUES (@codmunicipio, @codigoins, @codigosede, @esturedestematicas, @totalgrupoinv, @asistentesasesoria, @metaasesoria, @numeroredes, @sesionpresencial, @sesionvirtual) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        conector.AsignarParametroCadena("@codigoins", codigoins);
        conector.AsignarParametroCadena("@codigosede", codigosede);
        conector.AsignarParametroCadena("@esturedestematicas", esturedestematicas);
        conector.AsignarParametroCadena("@totalgrupoinv", totalgrupoinv);
        conector.AsignarParametroCadena("@asistentesasesoria", asistentesasesoria);
        conector.AsignarParametroCadena("@metaasesoria", metaasesoria);
        conector.AsignarParametroCadena("@numeroredes", numeroredes);
        conector.AsignarParametroCadena("@sesionpresencial", sesionpresencial);
        conector.AsignarParametroCadena("@sesionvirtual", sesionvirtual);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


    //maestro
    public DataTable cargarIndicadoresMaestrosxMunicipio(string codmunicipio)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT ind.codigo as codigopri, isede.codigo as codigosede, isede.nombre as nombresede, iin.codigo as codigoins, iin.nombre nombreins,  totalmaestros, totalsesion, totaljornadas, totalmesas FROM est_indicadoresmaestros ind INNER JOIN ins_sede isede ON isede.codigo = ind.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE gmun.cod = @codmunicipio ORDER BY isede.codigo ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
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


    public DataRow procinsertDatosMaestros(string codmunicipio, string codigoins, string codigosede, string totalmaestros, string totalsesion, string totaljornadas, string totalmesas)
    {

        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_indicadoresmaestros (codmunicipio, codinstitucion, codsede, totalmaestros, totalsesion, totaljornadas, totalmesas) VALUES (@codmunicipio, @codigoins, @codigosede, @totalmaestros, @totalsesion, @totaljornadas, @totalmesas) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        conector.AsignarParametroCadena("@codigoins", codigoins);
        conector.AsignarParametroCadena("@codigosede", codigosede);
        conector.AsignarParametroCadena("@totalmaestros", totalmaestros);
        conector.AsignarParametroCadena("@totalsesion", totalsesion);
        conector.AsignarParametroCadena("@totaljornadas", totaljornadas);
        conector.AsignarParametroCadena("@totalmesas", totalmesas);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public long updateDatosIndicadoresGeneralsMaestros(string codigo, string totalmaestros, string totalsesion, string totaljornadas, string totalmesas)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_indicadoresmaestros SET totalmaestros = @totalmaestros, totalsesion = @totalsesion, totaljornadas = @totaljornadas, totalmesas = @totalmesas WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        conector.AsignarParametroCadena("@totalmaestros", totalmaestros);
        conector.AsignarParametroCadena("@totalsesion", totalsesion);
        conector.AsignarParametroCadena("@totaljornadas", totaljornadas);
        conector.AsignarParametroCadena("@totalmesas", totalmesas);
        long resp = conector.guardadataid();
        return resp;
    }

    //maestro
    public DataTable cargarIndicadoresMunicipioxDepartamentoMaestros(string coddepartamento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT gmun.cod as codigomunicipio, gmun.nombre as nombremunicipio, SUM(ind.totalmaestros) as totalmaestros FROM est_indicadoresmaestros ind INNER JOIN ins_sede isede ON isede.codigo = ind.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE gdep.cod = @coddepartamento GROUP BY gmun.cod, gmun.nombre";
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


    public DataRow totalmaestrosxDepartamento(string coddepartamento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT sum(ind.totalmaestros) as sumatotalmaestros FROM est_indicadoresmaestros ind INNER JOIN ins_sede isede ON isede.codigo = ind.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE gdep.cod = @coddepartamento GROUP BY gdep.cod ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddepartamento", coddepartamento);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataRow totalmaestrosxMunicipio(string codmunicipio)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT sum(ind.totalmaestros) as totalmaestros  FROM est_indicadoresmaestros ind INNER JOIN ins_sede isede ON isede.codigo = ind.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE ind.codmunicipio = @codmunicipio GROUP BY ind.codmunicipio ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataTable cargarIndicadoresSedesInstitucionMaestros(string codinstitucion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT isede.codigo as codigosede, isede.nombre as nombresede, ind.totalmaestros, totalsesion, totaljornadas, totalmesas  FROM est_indicadoresmaestros ind INNER JOIN ins_sede isede ON isede.codigo = ind.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE ind.codinstitucion = @codinstitucion ORDER BY ind.codigo ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstitucion", codinstitucion);
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


    public DataRow loadTotalesIndicadoresxSedeMaestros(string codsede)
    {

        Conexion conector = new Conexion();
        String consulta = "SELECT codigo, codmunicipio, codinstitucion, codsede, totalmaestros, totalsesion, totaljornadas, totalmesas  FROM est_indicadoresmaestros WHERE codsede = @codsede";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public DataRow loadTotalesIndicadoresxSedeMaestrosSUM(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {

        Conexion conector = new Conexion();

        int numero = 4;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;

        
        if (codmunicipio != "" && codmunicipio != null)
        {
            cond[1] = "codmunicipio='" + codmunicipio + "'";
        }
        if (codinstitucion != "" && codinstitucion != "null")
        {
            cond[2] = "codinstitucion='" + codinstitucion + "'";
        }
        if (codsede != "" && codsede != "null")
        {
            cond[3] = "codsede='" + codsede + "'";
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

        String consulta = "SELECT SUM(totalmaestros) totalmaestros, SUM(totalsesion) totalsesion, SUM(totaljornadas) totaljornadas, SUM(totalmesas) totalmesas, SUM(s003) s003, SUM(introiep) introiep, SUM(cajah) cajah  FROM est_indicadoresmaestros " + where;
        conector.CrearComando(consulta);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    //Guardar encanbezado sesion virtual
    public DataRow insertencabezadosesionvirtualdoc(string codsede, string nroasistentes, string codestracoordinador, string sesion, string autoformacion, string produccion, string fecha)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra2sesionvirtual (codsede, codestracoordinador, nroasistentes, sesion, autoformacion, produccion, fecha) VALUES (@codsede, @codestracoordinador, @nroasistentes, @sesion, @autoformacion, @produccion, @fecha)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
        conector.AsignarParametroCadena("@nroasistentes", nroasistentes);
        conector.AsignarParametroCadena("@sesion", sesion);
        conector.AsignarParametroCadena("@autoformacion", autoformacion);
        conector.AsignarParametroCadena("@produccion", produccion);
        conector.AsignarParametroCadena("@fecha", fecha);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow insertcomitedepartamental(string codmunicipio, string fecha, string lugar, string hora, string participantes, string entidades, string objetivo, string desarrollo, string codestracoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra5comitedepartamental (codestracoordinador, codmunicipio, fecha, lugar, hora, participantes, entidades, objetivo, desarrollo) VALUES (@codestracoordinador, @codmunicipio, @fecha, @lugar, @hora, @participantes, @entidades, @objetivo, @desarrollo)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        conector.AsignarParametroCadena("@fecha", fecha);
        conector.AsignarParametroCadena("@lugar", lugar);
        conector.AsignarParametroCadena("@hora", hora);
        conector.AsignarParametroCadena("@participantes", participantes);
        conector.AsignarParametroCadena("@entidades", entidades);
        conector.AsignarParametroCadena("@objetivo", objetivo);
        conector.AsignarParametroCadena("@desarrollo", desarrollo);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow insertcomiteregional(string codmunicipio, string fecha, string lugar, string hora, string participantes, string entidades, string objetivo, string desarrollo, string codestracoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra5comiteregional (codestracoordinador, codmunicipio, fecha, lugar, hora, participantes, entidades, objetivo, desarrollo) VALUES (@codestracoordinador, @codmunicipio, @fecha, @lugar, @hora, @participantes, @entidades, @objetivo, @desarrollo)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        conector.AsignarParametroCadena("@fecha", fecha);
        conector.AsignarParametroCadena("@lugar", lugar);
        conector.AsignarParametroCadena("@hora", hora);
        conector.AsignarParametroCadena("@participantes", participantes);
        conector.AsignarParametroCadena("@entidades", entidades);
        conector.AsignarParametroCadena("@objetivo", objetivo);
        conector.AsignarParametroCadena("@desarrollo", desarrollo);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow insertcomiteredapoyo(string codmunicipio, string fecha, string lugar, string hora, string participantes, string entidades, string objetivo, string desarrollo, string codestracoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra5comiteredapoyo (codestracoordinador, codmunicipio, fecha, lugar, hora, participantes, entidades, objetivo, desarrollo) VALUES (@codestracoordinador, @codmunicipio, @fecha, @lugar, @hora, @participantes, @entidades, @objetivo, @desarrollo)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        conector.AsignarParametroCadena("@fecha", fecha);
        conector.AsignarParametroCadena("@lugar", lugar);
        conector.AsignarParametroCadena("@hora", hora);
        conector.AsignarParametroCadena("@participantes", participantes);
        conector.AsignarParametroCadena("@entidades", entidades);
        conector.AsignarParametroCadena("@objetivo", objetivo);
        conector.AsignarParametroCadena("@desarrollo", desarrollo);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow buscarentregarecurso(string codproyectosede, string desembolso)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from est_estra1bitacora4punto1 where codproyectosede=@codproyectosede and desembolso=@desembolso";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
        conector.AsignarParametroCadena("@desembolso", desembolso);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public Boolean actualizarentregadesembolso(String codproyectosede, string recibido, string fechainicio_desembolso, string fechafin_desembolso, string desembolso, string codestracoordinador)
    {
        Conexion conector = new Conexion();
        bool resp = false;
        string consulta;

        if (fechainicio_desembolso != "" && fechafin_desembolso == "")
        {
            consulta = "UPDATE est_estra1bitacora4punto1 SET recibido=@recibido, fechainicio_desembolso=@fechainicio_desembolso, codestracoordinador=@codestracoordinador where codproyectosede=@codproyectosede and desembolso=@desembolso";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
            conector.AsignarParametroCadena("@recibido", recibido);
            conector.AsignarParametroCadena("@fechainicio_desembolso", fechainicio_desembolso);
            conector.AsignarParametroCadena("@desembolso", desembolso);
            conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
            resp = conector.guardadata();
        } 
        else if (fechainicio_desembolso == "" && fechafin_desembolso != "")
        {
            consulta = "UPDATE est_estra1bitacora4punto1 SET recibido=@recibido, fechafin_desembolso=@fechafin_desembolso,  codestracoordinador=@codestracoordinador where codproyectosede=@codproyectosede and desembolso=@desembolso";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
            conector.AsignarParametroCadena("@recibido", recibido);
            conector.AsignarParametroCadena("@fechafin_desembolso", fechafin_desembolso);
            conector.AsignarParametroCadena("@desembolso", desembolso);
            conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
            resp = conector.guardadata();
        } 
        else if (fechainicio_desembolso != "" && fechafin_desembolso != "")
        {
            consulta = "UPDATE est_estra1bitacora4punto1 SET recibido=@recibido, fechainicio_desembolso=@fechainicio_desembolso, fechafin_desembolso=@fechafin_desembolso, codestracoordinador=@codestracoordinador where codproyectosede=@codproyectosede and desembolso=@desembolso";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
            conector.AsignarParametroCadena("@recibido", recibido);
            conector.AsignarParametroCadena("@fechafin_desembolso", fechafin_desembolso);
            conector.AsignarParametroCadena("@fechainicio_desembolso", fechainicio_desembolso);
            conector.AsignarParametroCadena("@desembolso", desembolso);
            conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
            resp = conector.guardadata();
        }
        else if (fechainicio_desembolso == "" && fechafin_desembolso == "")
        {
            consulta = "UPDATE est_estra1bitacora4punto1 SET recibido=@recibido, fechainicio_desembolso=null, fechafin_desembolso=null,  codestracoordinador=@codestracoordinador where codproyectosede=@codproyectosede and desembolso=@desembolso";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
            conector.AsignarParametroCadena("@recibido", recibido);
            conector.AsignarParametroCadena("@desembolso", desembolso);
            conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
            resp = conector.guardadata();
        }

       
        
        return resp;
    }

    public Boolean insertarentregadesembolso(String codproyectosede, string recibido, string fechainicio_desembolso, string fechafin_desembolso, string desembolso, string codestracoordinador)
    {
        Conexion conector = new Conexion();
        bool resp = false;
        string consulta;

        if (fechainicio_desembolso != "" && fechafin_desembolso == "")
        {
            consulta = "INSERT INTO est_estra1bitacora4punto1 (recibido, fechainicio_desembolso, codestracoordinador, codproyectosede, desembolso) VALUES (@recibido, @fechainicio_desembolso, @codestracoordinador,  @codproyectosede, @desembolso)";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
            conector.AsignarParametroCadena("@recibido", recibido);
            conector.AsignarParametroCadena("@fechainicio_desembolso", fechainicio_desembolso);
            conector.AsignarParametroCadena("@desembolso", desembolso);
            conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
            resp = conector.guardadata();
        }
        else if (fechainicio_desembolso == "" && fechafin_desembolso != "")
        {
            consulta = "INSERT INTO est_estra1bitacora4punto1 (recibido, fechafin_desembolso,  codestracoordinador, codproyectosede, desembolso) VALUES (@recibido, @fechafin_desembolso, @codestracoordinador, @codproyectosede, @desembolso)";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
            conector.AsignarParametroCadena("@recibido", recibido);
            conector.AsignarParametroCadena("@fechafin_desembolso", fechafin_desembolso);
            conector.AsignarParametroCadena("@desembolso", desembolso);
            conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
            resp = conector.guardadata();
        }
        else if (fechainicio_desembolso != "" && fechafin_desembolso != "")
        {
            consulta = "INSERT INTO est_estra1bitacora4punto1 (recibido, fechainicio_desembolso, fechafin_desembolso, codestracoordinador, codproyectosede, desembolso) VALUES (@recibido, @fechainicio_desembolso, @fechafin_desembolso, @codestracoordinador, @codproyectosede, @desembolso)";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
            conector.AsignarParametroCadena("@recibido", recibido);
            conector.AsignarParametroCadena("@fechafin_desembolso", fechafin_desembolso);
            conector.AsignarParametroCadena("@fechainicio_desembolso", fechainicio_desembolso);
            conector.AsignarParametroCadena("@desembolso", desembolso);
            conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
            resp = conector.guardadata();
        }
        else if (fechainicio_desembolso == "" && fechafin_desembolso == "")
        {
            consulta = "INSERT INTO est_estra1bitacora4punto1 (recibido, codestracoordinador, codproyectosede, desembolso) VALUES (@recibido, @codestracoordinador, @codproyectosede, @desembolso)";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
            conector.AsignarParametroCadena("@recibido", recibido);
            conector.AsignarParametroCadena("@desembolso", desembolso);
            conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
            resp = conector.guardadata();
        }



        return resp;
    }

    public Boolean insertinasistenciadocente(String codgradodocente, string codsesionvirtual)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra2sesionvirtualdetalle (codsesionvirtual, codgradodocente) VALUES (@codsesionvirtual, @codgradodocente)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        conector.AsignarParametroCadena("@codsesionvirtual", codsesionvirtual);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean insertinasistenciadocenteintroiep(String codgradodocente, string codestra2introiep)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra2introiepdetalle (codestra2introiep, codgradodocente) VALUES (@codestra2introiep, @codgradodocente)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        conector.AsignarParametroCadena("@codestra2introiep", codestra2introiep);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean insertinasistenciadocentecontenidodigital(String codgradodocente, string codestra2contedigital)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra2contedigitaldetalle (codestra2contedigital, codgradodocente) VALUES (@codestra2contedigital, @codgradodocente)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        conector.AsignarParametroCadena("@codestra2contedigital", codestra2contedigital);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean eliminarinasistenciasdetalleesionvirtual(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2sesionvirtualdetalle where codsesionvirtual=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean eliminarinasistenciasdetalleintroiep(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2introiepdetalle where codestra2introiep=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean eliminarinasistenciasdetallecontenidodigital(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2contedigitaldetalle where codestra2contedigital=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean eliminarinasistenciasesionvirtual(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2sesionvirtual where codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean eliminarincomitedepartamental(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra5comitedepartamental where codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean eliminarincomiteregional(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra5comiteregional where codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean eliminarincomiteredapoyo(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra5comiteredapoyo where codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean eliminarevidenciaporcodcomitedepartamental(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra5comitedepartamental_evi where codcomitedep=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean eliminarevidenciaporcodcomiteregional(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra5comiteregional_evi where codcomitereg=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean eliminarevidenciaporcodcomiteredapoyo(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra5comiteredapoyo_evi where codcomitered=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean eliminarinasistenciaintroiep(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2introiep where codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean eliminarinasistenciacontenidodigital(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2contedigital where codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public DataTable cargarSedesxMunicipio(string codmunicipio)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT isede.codigo as codigosede, isede.nombre as nombresede, gmun.nombre as municipios, iin.nombre as institucion FROM ins_sede isede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE iin.codmunicipio = @codmunicipio ORDER BY gmun.nombre ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
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

    public DataRow agregarareaintroiep(string nombre)
    {
        Conexion conector = new Conexion();
        String consulta = "INSERT INTO est_estra2introieparea (nombre) VALUES (@nombre) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public DataRow agregarintroiep(string codsede, string codestracoordinador, string fecha, string codintroieparea, string sesion)
    {
        Conexion conector = new Conexion();
        String consulta = "INSERT INTO est_estra2introiep (codsede, codestracoordinador, fecha, codintroieparea, sesion) VALUES (@codsede, @codestracoordinador, @fecha, @codintroieparea, @sesion) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
        conector.AsignarParametroCadena("@fecha", fecha);
        conector.AsignarParametroCadena("@codintroieparea", codintroieparea);
        conector.AsignarParametroCadena("@sesion", sesion);
        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public DataRow agregarcontenidodigital(string codsede, string codestracoordinador, string fecha, string codintroieparea, string sesion)
    {
        Conexion conector = new Conexion();
        String consulta = "INSERT INTO est_estra2contedigital (codsede, codestracoordinador, fecha, codintroieparea, sesion) VALUES (@codsede, @codestracoordinador, @fecha, @codintroieparea, @sesion) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
        conector.AsignarParametroCadena("@fecha", fecha);
        conector.AsignarParametroCadena("@codintroieparea", codintroieparea);
        conector.AsignarParametroCadena("@sesion", sesion);
        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public DataRow agregarcontenidodigitalActualizado(string codanio, string codestracoordinador, string fecha, string tematica)
    {
        Conexion conector = new Conexion();
        String consulta = "INSERT INTO est_estra2contedigital (codanio, codestracoordinador, fecha, tematica) VALUES (@codanio, @codestracoordinador, @fecha, @tematica) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codanio", codanio);
        conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
        conector.AsignarParametroCadena("@fecha", fecha);
        conector.AsignarParametroCadena("@tematica", tematica);
        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public Boolean agregarArchivoinstroiepestrados(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string codinstrumento, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO est_estra2introiep_evi (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,codinstrumento,actividad) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@codinstrumento,@actividad)";


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

    public Boolean agregarArchivocontenidodigitalestrados(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string codinstrumento, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO est_estra2contedigital_evi (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,codinstrumento,actividad) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@codinstrumento,@actividad)";


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

    public Boolean agregarArchivoPresupuestoDesembolso(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string codgrupoinv, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO est_estra2presupuestodesembolso_evi (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,codgrupoinv,actividad) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@codgrupoinv,@actividad)";


        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroDouble("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fechacreado);

        conector.AsignarParametroCadena("@codgrupoinv", codgrupoinv);
        conector.AsignarParametroCadena("@actividad", actividad);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean agregarArchivoEntregaRecursos(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string codproyectosede, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO est_estra1bitacora4punto1_evi (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,codproyectosede,actividad) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@codproyectosede,@actividad)";


        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroDouble("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fechacreado);

        conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
        conector.AsignarParametroCadena("@actividad", actividad);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean agregarArchivoComiteDepartamental(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string codcomitedep, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO est_estra5comitedepartamental_evi (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,codcomitedep,actividad) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@codcomitedep,@actividad)";


        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroDouble("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fechacreado);

        conector.AsignarParametroCadena("@codcomitedep", codcomitedep);
        conector.AsignarParametroCadena("@actividad", actividad);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean agregarArchivoComiteRegional(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string codcomitereg, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO est_estra5comiteregional_evi (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,codcomitereg,actividad) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@codcomitereg,@actividad)";


        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroDouble("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fechacreado);

        conector.AsignarParametroCadena("@codcomitereg", codcomitereg);
        conector.AsignarParametroCadena("@actividad", actividad);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean agregarArchivoComiteRedApoyo(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string codcomitered, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO est_estra5comiteredapoyo_evi (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,codcomitered,actividad) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@codcomitered,@actividad)";


        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroDouble("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fechacreado);

        conector.AsignarParametroCadena("@codcomitered", codcomitered);
        conector.AsignarParametroCadena("@actividad", actividad);
        bool resp = conector.guardadata();
        return resp;
    }

    public DataTable cargarEvidenciasinstroiepestrados(string codinstrumento, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_estra2introiep_evi rc inner join usu_usuario u on u.cod=rc.codusuario WHERE codusuario=@codusuario and codinstrumento=@codinstrumento ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarEvidenciascontenidodigitalestrados(string codinstrumento, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_estra2contedigital_evi rc inner join usu_usuario u on u.cod=rc.codusuario WHERE codusuario=@codusuario and codinstrumento=@codinstrumento ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarEvidenciasPresupuestoDesembolso(string codgrupoinv, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_estra2presupuestodesembolso_evi rc inner join usu_usuario u on u.cod=rc.codusuario WHERE codusuario=@codusuario and codgrupoinv=@codgrupoinv ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@codgrupoinv", codgrupoinv);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarEvidenciasPresupuestoDesembolsoI(string codgrupoinv)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_estra2presupuestodesembolso_evi rc inner join usu_usuario u on u.cod=rc.codusuario WHERE codgrupoinv=@codgrupoinv ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgrupoinv", codgrupoinv);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarEvidenciasEntregaRecursos(string codproyectosede, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_estra1bitacora4punto1_evi rc inner join usu_usuario u on u.cod=rc.codusuario WHERE codusuario=@codusuario and codproyectosede=@codproyectosede ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarEvidenciasComiteDepartamental(string codcomitedep, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_estra5comitedepartamental_evi rc inner join usu_usuario u on u.cod=rc.codusuario WHERE codusuario=@codusuario and codcomitedep=@codcomitedep ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@codcomitedep", codcomitedep);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarEvidenciasComiteRegional(string codcomitereg, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_estra5comiteregional_evi rc inner join usu_usuario u on u.cod=rc.codusuario WHERE codusuario=@codusuario and codcomitereg=@codcomitereg ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@codcomitereg", codcomitereg);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarEvidenciasComiteRedApoyo(string codcomitered, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_estra5comiteredapoyo_evi rc inner join usu_usuario u on u.cod=rc.codusuario WHERE codusuario=@codusuario and codcomitered=@codcomitered ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        conector.AsignarParametroCadena("@codcomitered", codcomitered);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataRow buscarEvidenciainstroiepestrados(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_estra2introiep_evi WHERE cod=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public DataRow buscarEvidenciacontenidodigitalestrados(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_estra2contedigital_evi WHERE cod=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public DataRow buscarEvidenciaPresupuestoDesembolsoestrados(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_estra2presupuestodesembolso_evi WHERE cod=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public DataRow buscarEvidenciaEntregaRecursosCod(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_estra1bitacora4punto1_evi WHERE cod=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public DataRow buscarEvidenciaComiteDepartamental(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_estra5comitedepartamental_evi WHERE cod=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public DataRow buscarEvidenciaComiteRegional(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_estra5comiteregional_evi WHERE cod=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public DataRow buscarEvidenciaComiteRedApoyo(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_estra5comiteredapoyo_evi WHERE cod=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public Boolean borrarEvidenciainstroiepestrados(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2introiep_evi WHERE cod=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean borrarEvidenciacontenidodigitalestrados(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2contedigital_evi WHERE cod=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean borrarEvidenciaPresupuestoDesembolsoestrados(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2presupuestodesembolso_evi WHERE cod=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean borrarEvidenciaEntregaRecursosxCod(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora4punto1_evi WHERE cod=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean borrarEvidenciaEntregaRecursosxCodBitacora(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora4punto1_evi WHERE codbitacora4punto1=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean borrarEvidenciaComiteDepartamental(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra5comitedepartamental_evi WHERE cod=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean borrarEvidenciaComiteRegional(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra5comiteregional_evi WHERE cod=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean borrarEvidenciaComiteRedApoyo(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra5comiteredapoyo_evi WHERE cod=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public DataRow contardocentesxsede(string codsede, string codanio)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT count(*) as cantdocente FROM ins_gradodocente WHERE codsede=@codsede and codanio=@codanio;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@codanio", codanio);
        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }


    //--------------- NUEVO CODIGO ----------------------
    public DataTable totalmunicipioInd(string coddep)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT(ind.codmunicipio) as totalmuni, gmun.nombre as municipio FROM est_indicadoresestudiantes ind INNER JOIN ins_sede isede ON isede.codigo = ind.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE gdep.cod = @coddep";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddep", coddep);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable totalSedesInd(string coddep)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT(ind.codsede) as totalmuni, isede.nombre as sede, iin.nombre as institucion, gmun.nombre as municipio FROM est_indicadoresestudiantes ind INNER JOIN ins_sede isede ON isede.codigo = ind.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE gdep.cod = @coddep";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddep", coddep);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }


    public DataTable totalMaestrosInd(string coddep)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT SUM(ind.totalmaestros) as totalmaestros FROM est_indicadoresmaestros ind INNER JOIN ins_sede isede ON isede.codigo = ind.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE gdep.cod = @coddep;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddep", coddep);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable totalEstuInd(string coddep)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT SUM(ind.totalesturedestematicas) as totalestu FROM est_indicadoresestudiantes ind INNER JOIN ins_sede isede ON isede.codigo = ind.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE gdep.cod = @coddep;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddep", coddep);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable loadeventos(string codferiasmunicipales)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, tipoevento, fecha, horainicio, horafin, codferiasmunicipales FROM ep_feriasmunicipales_evento WHERE codferiasmunicipales = @codferiasmunicipales ORDER BY codigo DESC;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codferiasmunicipales", codferiasmunicipales);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }


    public DataRow insertferiaEvento(string codferiamunicipal, string tipoevento, string fecha, string horainicio, string horafin)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO ep_feriasmunicipales_evento (tipoevento,fecha,horainicio,horafin,codferiasmunicipales) VALUES (@tipoevento, @fecha, @horainicio, @horafin, @codferiamunicipal) RETURNING codigo;";

        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codferiamunicipal", codferiamunicipal);
        conector.AsignarParametroCadena("@tipoevento", tipoevento);
        conector.AsignarParametroCadena("@fecha", fecha);
        conector.AsignarParametroCadena("@horainicio", horainicio);
        conector.AsignarParametroCadena("@horafin", horafin);
        DataRow dato = conector.guardadataidPG();
        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataRow insertDocentesFeria(string codencabezado, string codgradodocente)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO ep_feriasmunicipales_evento_detalle (codencabezado,codgradodocente) VALUES (@codencabezado, @codgradodocente) RETURNING codigo;";

        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codencabezado", codencabezado);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        DataRow dato = conector.guardadataidPG();
        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataRow loaddetallesevento(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "SELECT codigo, tipoevento, fecha, horainicio, horafin, codferiasmunicipales FROM ep_feriasmunicipales_evento WHERE codigo = @cod;";

        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        DataRow dato = conector.guardadataidPG();
        if (dato != null)
            return dato;
        else
            return null;
    }



    public DataTable cargarDocentesSeleccionados(string codencabezado)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT evd.*, igd.*, gmun.cod as codmun, gmun.nombre as mun, iin.codigo as codins, iin.nombre as nombreins, iin.dane as daneins, isede.codigo as codsede, isede.nombre as nombresede, isede.dane as danesede, id.nombre as nombredoc, id.apellido as apellidodoc  FROM ep_feriasmunicipales_evento_detalle evd INNER JOIN ins_gradodocente igd ON evd.codgradodocente = igd.cod INNER JOIN ins_docente id ON igd.identificacion = id.identificacion INNER JOIN ins_sede isede ON isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio WHERE codencabezado =  @codencabezado;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codencabezado", codencabezado);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }


    public long updateEventoEspacio(string codigoencabezado, string tipoevento, string fecha, string horainicio, string horafin)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE ep_feriasmunicipales_evento SET tipoevento = @tipoevento, fecha = @fecha, horainicio=@horainicio, horafin = @horafin WHERE codigo = @codigoencabezado";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigoencabezado", codigoencabezado);
        conector.AsignarParametroCadena("@tipoevento", tipoevento);
        conector.AsignarParametroCadena("@fecha", fecha);
        conector.AsignarParametroCadena("@horainicio", horainicio);
        conector.AsignarParametroCadena("@horafin", horafin);
        long resp = conector.guardadataid();
        return resp;
    }

    public long deleteDocentesSeleccionado(string codencabezado)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM ep_feriasmunicipales_evento_detalle WHERE codencabezado = @codencabezado;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codencabezado", codencabezado);
        long resp = conector.guardadataid();
        return resp;
    }

    public DataTable loadespaciosapropiacion(string tipo)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT ea.*, an.nombre as anio, a.nombre as area, ps.nombregrupo, s.nombre as sede, i.nombre as institucion, m.nombre as municipio from ep_espaciosapropiacion ea INNER JOIN pro_proyectosede ps ON ps.codigo=ea.codproyectosede INNER JOIN pro_areas a ON a.codigo=ps.codarea INNER JOIN ins_sede s ON s.codigo=ps.codsede INNER JOIN ins_institucion i ON i.codigo=s.codinstitucion INNER JOIN geo_municipios m ON m.cod=i.codmunicipio INNER JOIN ins_anio an ON an.codigo=ea.codanio WHERE ea.tipo=@tipo ORDER BY ea.codigo DESC;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@tipo", tipo);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public long deleteespacioapropiacion(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM ep_espaciosapropiacion WHERE codigo = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        long resp = conector.guardadataid();
        return resp;
    }

    public long deleteespacioapropiacion_evi(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM ep_espaciosapropiacion_evi WHERE codapropiacion = @codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        long resp = conector.guardadataid();
        return resp;
    }

    public DataRow insertGrupoEspacioApropiacion(string codproyectosede, string tipo, string codanio)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        consulta = "INSERT INTO ep_espaciosapropiacion (codproyectosede,tipo,codanio) VALUES (@codproyectosede, @tipo, @codanio) RETURNING codigo;";

        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
        conector.AsignarParametroCadena("@tipo", tipo);
        conector.AsignarParametroCadena("@codanio", codanio);
        DataRow dato = conector.guardadataidPG();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow buscardatosApropiacion(string codigo)
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

    public Boolean editarDatosApropiacionEvidencia(String codigo, string fechainicio, string fechafin, string horainicio, string horafin, string lugar, string nodocentes, string noestudiantes)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE ep_espaciosapropiacion_evi SET fechainicio=@fechainicio, fechafin=@fechafin, horainicio=@horainicio, horafin=@horafin, lugar=@lugar, nodocentes=@nodocentes, noestudiantes=@noestudiantes WHERE cod=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
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

    public Boolean agregarArchivoRespositorioBitacora4punto1(String codusuario, string nombrearchivo, string nombreguardado, string ext, string contentType, string path, int tamano, string fechacreado, string actividad, string desembolso, string codproyectosede)
    {
        Conexion conector = new Conexion();
        string consulta = "";


        consulta = "INSERT INTO est_estra1bitacora4punto1_evi (codusuario,nombrearchivo,nombreguardado,contentType,ext,path,tamano,fechacreado,actividad,desembolso,codproyectosede) VALUES (@codusuario,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado,@actividad,@desembolso,@codproyectosede)";


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
        conector.AsignarParametroCadena("@desembolso", desembolso);
        conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
        bool resp = conector.guardadata();
        return resp;
    }

    public DataTable cargarEvidenciasBitacora4punto1(string desembolso, string codusuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT rc.*, concat_ws(' ', u.pnombre,u.papellido) as nombre, s.nombre as sede, i.nombre as institucion, m.nombre as municipio, ps.nombregrupo FROM est_estra1bitacora4punto1_evi rc inner join usu_usuario u on u.cod=rc.codusuario inner join pro_proyectosede ps on ps.codigo=rc.codproyectosede inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio WHERE rc.desembolso=@desembolso and codusuario=@codusuario ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@desembolso", desembolso);
        conector.AsignarParametroCadena("@codusuario", codusuario);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataRow buscarEvidenciaBitacora4punto1(string codigo)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT * FROM est_estra1bitacora4punto1_evi WHERE cod=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);

        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public Boolean borrarEvidenciaBitacora4punto1(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1bitacora4punto1_evi WHERE cod=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }
	
	public DataTable listarEspaciosApropiacionSinAsesor(string estrategia, string momento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT eeb.*, pps.nombregrupo ,s.nombre as nombresede,i.nombre as nombreinstitucion,m.nombre as nombremunicipio,d.nombre as nombredepartamento FROM est_estra1espacioapropiacion eeb inner join pro_proyectosede pps on pps.codigo=eeb.codproyectosede inner join ins_sede s on s.codigo = pps.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento where eeb.estrategia=@estrategia and eeb.momento=@momento order by eeb.fecharealizacion DESC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
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
	
	public bool editarDatosRector(string identificacion, string nombre, string apellido, string celular, string email)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE ins_rector SET nombre=@nombre,apellido=@apellido, celular=@celular, email=@email WHERE identificacion=@identificacion";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@apellido", apellido);
        conector.AsignarParametroCadena("@celular", celular);
        conector.AsignarParametroCadena("@email", email);
        
        return conector.guardadata();
    }

//CODIGO NUEVO


       public DataTable cargarPlataformasPedagogicas()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT comentario FROM lbase_respuestaabiertasede lbr WHERE codpregunta = '1.2' and codinstrumento = '3' and fase = 'intermedia' AND comentario != '' GROUP BY comentario ORDER BY comentario ASC";
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


   /**
     * INTERMEDIA
     *  consulta de total de tableta a estudiantes por sede
     * 
     * 
     */

       public DataTable totalTabletaEstudiante(string coddepartamento,string codmunicipio,string  codinstitucion)
       {
           string where = "";

           if (coddepartamento != "")
           {
               if (coddepartamento != "null")
               {
                   where = " AND d.cod = '" + coddepartamento + "'";

                   if (codmunicipio != "")
                   {
                       if (codmunicipio != "null")
                       {
                           where = where + " AND  M.cod = " + codmunicipio;

                           if (codinstitucion != "")
                           {
                               if (codinstitucion != "null")
                               {
                                   where = where + " AND  i.codigo = " + codinstitucion;

                               }
                           }
                       }
                   }
               }
           }
           Conexion conector = new Conexion();
           string consulta = "select T.*,s.nombre AS sede,d.nombre AS departamento,s.dane As sdane,i.nombre AS institucion,i.dane As idane, M.nombre AS municipio FROM est_estra4entregatablets T LEFT JOIN ins_sede s ON s.dane = T.dane INNER JOIN ins_institucion i ON i.codigo = s.codinstitucion INNER JOIN geo_municipios M ON M.cod = i.codmunicipio     INNER JOIN geo_departamentos D ON D.cod = M.coddepartamento"+ where;
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
}