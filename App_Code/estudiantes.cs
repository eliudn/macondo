using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Cliente
/// </summary>
public class Estudiantes
{
    public Estudiantes()
	{
		//
		// TODO: Agregar aquí la lógica del constructor prueba de cambios en la nube
		//
	}

    public DataTable cargarEstudiantesTodo()
    {
        Conexion conector = new Conexion();
        string consulta = "select e.*,td.abr,et.nombre from ins_estudiante e inner join con_tipodocumento td on e.codtipodocumento=td.cod inner join ins_etnia et on et.codigo=e.codetnia order by e.apellido asc";
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

    public DataTable cargarEstudiantesTodoOFFSET(string offset, string limit)
    {
        Conexion conector = new Conexion();
        string consulta = "select e.*,td.abr,et.nombre as etnia from ins_estudiante e inner join con_tipodocumento td on e.codtipodocumento=td.cod inner join ins_etnia et on et.codigo=e.codetnia order by e.apellido asc offset @offset limit @limit";
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

    public DataRow buscarTipoDocumentoxAbr(string abr)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT cod FROM con_tipodocumento c  WHERE c.abr=@abr";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@abr", abr);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscarGradoxNombre(string nombre)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo FROM ins_grado c  WHERE c.nombre=@nombre";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow buscarEstudianteUltimo()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo FROM ins_estudiante c  ORDER BY c.codigo DESC LIMIT 1";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscarEstudianteIngresado(string identificacion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM ins_estudiante c WHERE c.identificacion=@identificacion";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public bool agregarEstudiante(string nombre, string apellido, string identificacion, string sexo, string fecha_nacimiento, string telefono, string direccion, string email, string codtipodocumento)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO ins_estudiante (nombre,apellido,identificacion,sexo,fecha_nacimiento,telefono,direccion,email,codtipodocumento) VALUES (@nombre,@apellido,@identificacion,@sexo,@fecha_nacimiento,@telefono,@direccion,@email,@codtipodocumento) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@apellido", apellido);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@sexo", sexo);
        conector.AsignarParametroCadena("@fecha_nacimiento", fecha_nacimiento);
        conector.AsignarParametroCadena("@telefono", telefono);
        conector.AsignarParametroCadena("@direccion", direccion);
        conector.AsignarParametroCadena("@email", email);
        conector.AsignarParametroCadena("@codtipodocumento", codtipodocumento);
        return conector.guardadata();
    }
    public bool ActualizarEstudiante(string idOld, string identificacionEstudiante, string nombreEstudiante, string apellidoEstudiante, string fnacimientoEstudiante, string sexoEstudiante, string telefonoEstudiante, string direccionEstudiante, string emailEstudiante)
    {
        Conexion conectar = new Conexion();
        string consulta = "update ins_estudiante set nombre=@nombreEstudiante, apellido=@apellidoEstudiante, identificacion=@identificacionEstudiante, sexo=@sexoEstudiante, fecha_nacimiento=@fnacimientoEstudiante, telefono=@telefonoEstudiante, direccion=@direccionEstudiante, email=@emailEstudiante where identificacion=@idOld";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@nombreEstudiante", nombreEstudiante);
        conectar.AsignarParametroCadena("@apellidoEstudiante", apellidoEstudiante);
        conectar.AsignarParametroCadena("@identificacionEstudiante", identificacionEstudiante);
        conectar.AsignarParametroCadena("@idOld", idOld);
        conectar.AsignarParametroCadena("@fnacimientoEstudiante", fnacimientoEstudiante);
        conectar.AsignarParametroCadena("@telefonoEstudiante", telefonoEstudiante);
        conectar.AsignarParametroCadena("@direccionEstudiante", direccionEstudiante);
        conectar.AsignarParametroCadena("@emailEstudiante", emailEstudiante);
        conectar.AsignarParametroCadena("@sexoEstudiante", sexoEstudiante);
        return conectar.guardadata();
    }
    public bool editarDatosEstudiante(string identificacionEstudiante, string nombreEstudiante, string apellidoEstudiante, string sexoEstudiante, string fnacimientoEstudiante)
    {
        Conexion conectar = new Conexion();
        string consulta = "update ins_estudiante set nombre=@nombreEstudiante, apellido=@apellidoEstudiante, sexo=@sexoEstudiante, fecha_nacimiento=@fnacimientoEstudiante where identificacion=@identificacionEstudiante";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@nombreEstudiante", nombreEstudiante);
        conectar.AsignarParametroCadena("@apellidoEstudiante", apellidoEstudiante);
        conectar.AsignarParametroCadena("@identificacionEstudiante", identificacionEstudiante);
        conectar.AsignarParametroCadena("@fnacimientoEstudiante", fnacimientoEstudiante);
        conectar.AsignarParametroCadena("@sexoEstudiante", sexoEstudiante);
        return conectar.guardadata();
    }
    public DataRow buscarMatriculado(string codsede, string codestudiante, string codanio, string codgrado, string codtipogrupo, string grupo)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM ins_estumatricula WHERE codtipogrupo=@codtipogrupo and codestudiante=@codestudiante and codanio=@codanio and codgrado=@codgrado and codsede=@codsede and grupo=@grupo order by codigo desc";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codtipogrupo", codtipogrupo);
        conector.AsignarParametroCadena("@codestudiante", codestudiante);
        conector.AsignarParametroCadena("@codanio", codanio);
        conector.AsignarParametroCadena("@codgrado", codgrado);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@grupo", grupo);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscarMatriculadoxIDEstudiante(string identificacion, string codanio)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT em.* FROM ins_estumatricula em inner join ins_estudiante e on e.codigo=em.codestudiante WHERE e.identificacion=@identificacion and em.codanio=@codanio";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@codanio", codanio);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscarEstudianteRedTematica(string codestumatricula, string codredtematicasede)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM rt_redtematicamatricula WHERE codestumatricula=@codestumatricula and codredtematicasede=@codredtematicasede";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestumatricula", codestumatricula);
        conector.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow agregarEstudiantePG(string nombre, string apellido, string identificacion, string sexo, string fecha_nacimiento, string telefono, string direccion, string email, string codtipodocumento, string codetnia)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO ins_estudiante (nombre,apellido,identificacion,sexo,fecha_nacimiento,telefono,direccion,email,codtipodocumento,codetnia) VALUES (@nombre,@apellido,@identificacion,@sexo,@fecha_nacimiento,@telefono,@direccion,@email,@codtipodocumento,@codetnia) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@apellido", apellido);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@sexo", sexo);
        conector.AsignarParametroCadena("@fecha_nacimiento", fecha_nacimiento);
        conector.AsignarParametroCadena("@telefono", telefono);
        conector.AsignarParametroCadena("@direccion", direccion);
        conector.AsignarParametroCadena("@email", email);
        conector.AsignarParametroCadena("@codtipodocumento", codtipodocumento);
        conector.AsignarParametroCadena("@codetnia", codetnia);
        DataRow dato = conector.guardadataidPG();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public int agregarEstudianteInt(string nombre, string apellido, string identificacion, string sexo, string fecha_nacimiento, string telefono, string direccion, string email, string codtipodocumento)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO ins_estudiante (nombre,apellido,identificacion,sexo,fecha_nacimiento,telefono,direccion,email,codtipodocumento) VALUES (@nombre,@apellido,@identificacion,@sexo,@fecha_nacimiento,@telefono,@direccion,@email,@codtipodocumento)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@apellido", apellido);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@sexo", sexo);
        conector.AsignarParametroCadena("@fecha_nacimiento", fecha_nacimiento);
        conector.AsignarParametroCadena("@telefono", telefono);
        conector.AsignarParametroCadena("@direccion", direccion);
        conector.AsignarParametroCadena("@email", email);
        conector.AsignarParametroCadena("@codtipodocumento", codtipodocumento);
        int resp = conector.guardadataid();
        return resp;
    }
    public bool agregarEstuMatricula(string codsede, string codestudiante, string codanio, string fecha_matricula, string codgrado, string codtipogrupo, string grupo)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO ins_estumatricula (codsede,codestudiante,codanio,fecha_matricula,codgrado,codtipogrupo, grupo) VALUES (@codsede,@codestudiante,@codanio,@fecha_matricula,@codgrado,@codtipogrupo,@grupo)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@codestudiante", codestudiante);
        conector.AsignarParametroCadena("@codanio", codanio);
        conector.AsignarParametroCadena("@fecha_matricula", fecha_matricula);
        conector.AsignarParametroCadena("@codgrado", codgrado);
        conector.AsignarParametroCadena("@codtipogrupo", codtipogrupo);
        conector.AsignarParametroCadena("@grupo", grupo);
        return conector.guardadata();
    }
    public DataTable cargarEstudiantesWhere(string where)
    {
        Conexion conector = new Conexion();
        string consulta = "select em.codigo as cod,CONCAT_WS(' ',e.nombre,e.apellido) as nombrecompleto, e.identificacion, e.sexo, e.email, i.nombre as nominstitucion, s.dane, s.nombre as nomsede, (SELECT(CASE WHEN em.codtipogrupo = 1 THEN 'Grupo de investigación' ELSE 'Red Temática' END)) AS tipogrupo, g.nombre as grado  from ins_estudiante e inner join ins_estumatricula em on e.codigo=em.codestudiante inner join ins_sede s on s.codigo=em.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join ins_grado g on g.codigo=em.codgrado " + where;
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
    public DataTable cargarTipoDocumento()
    {
        Conexion conector = new Conexion();
        string consulta = "select * from con_tipodocumento";
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

    public DataTable cargarEstudiantexSedexGrado(string codsede, string codgrado, string codtipogrupo, string codanio, string grupo)
    {
        Conexion conector = new Conexion();
        string consulta = "Select em.codigo as codestumatricula, e.identificacion, e.codigo as codestudiante, concat_ws(' ' ,e.apellido, e.nombre) as nombre, g.nombre as nomgrado, em.fecha_matricula from ins_estumatricula em inner join ins_sede s on em.codsede=s.codigo inner join ins_grado g on em.codgrado=g.codigo inner join ins_estudiante e on e.codigo=em.codestudiante where em.codgrado=@codgrado and em.codsede=@codsede and em.codtipogrupo=@codtipogrupo and em.codanio=@codanio and grupo=@grupo order by e.nombre ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@codgrado", codgrado);
        conector.AsignarParametroCadena("@codtipogrupo", codtipogrupo);
        conector.AsignarParametroCadena("@codanio", codanio);
        conector.AsignarParametroCadena("@grupo", grupo);
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

    public DataTable cargarEstudiantexSedexGradoSinGrupo(string codsede, string codgrado, string codtipogrupo, string codanio)
    {
        Conexion conector = new Conexion();
        string consulta = "Select em.codigo as codestumatricula, e.identificacion, e.codigo as codestudiante, concat_ws(' ' ,e.apellido, e.nombre) as nombre, g.nombre as nomgrado, em.fecha_matricula, em.codanio from ins_estumatricula em inner join ins_sede s on em.codsede=s.codigo inner join ins_grado g on em.codgrado=g.codigo inner join ins_estudiante e on e.codigo=em.codestudiante where em.codgrado=@codgrado and em.codsede=@codsede and em.codtipogrupo=@codtipogrupo and em.codanio=@codanio order by e.nombre ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@codgrado", codgrado);
        conector.AsignarParametroCadena("@codtipogrupo", codtipogrupo);
        conector.AsignarParametroCadena("@codanio", codanio);
        
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

    public bool editarEstuMatricula(string codsede, string codestudiante, string codanio, string codgrado, string codtipogrupo, string grupo)
    {
        Conexion conectar = new Conexion();
        string consulta = "update ins_estumatricula set codsede=@codsede, codanio=@codanio, codgrado=@codgrado, codtipogrupo=@codtipogrupo, grupo=@grupo where codestudiante=@codestudiante and codanio=@codanio2";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codsede", codsede);
        conectar.AsignarParametroCadena("@codanio", codanio);
        conectar.AsignarParametroCadena("@codanio2", codanio);
        conectar.AsignarParametroCadena("@codestudiante", codestudiante);
        conectar.AsignarParametroCadena("@codtipogrupo", codtipogrupo);
        conectar.AsignarParametroCadena("@codgrado", codgrado);
        conectar.AsignarParametroCadena("@grupo", grupo);
        return conectar.guardadata();
    }
    //Redes Temática
    public DataTable cargarRedesTematicas()
    {
        Conexion conector = new Conexion();
        string consulta = "select * from rt_redtematica order by nombre ASC";
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
    public DataRow buscarUltimaRedTematicaxSede(string codredtematica, string codsede, string anio)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM rt_redtematicasede  WHERE codredtematica=@codredtematica AND codsede=@codsede AND extract(year from fechacreacion)=@anio ORDER BY codigo DESC LIMIT 1";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codredtematica", codredtematica);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@anio", anio);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow agregarRedTematicaxSede(string codredtematica, string codsede, string consecutivogrupo, string codasesorcoordinador, string aniored)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO rt_redtematicasede (codredtematica,codsede,consecutivogrupo,codasesorcoordinador,fechacreacion,aniored) VALUES (@codredtematica,@codsede,@consecutivogrupo,@codasesorcoordinador,NOW(),@aniored) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codredtematica", codredtematica);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@consecutivogrupo", consecutivogrupo);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@aniored", aniored);
        DataRow dato = conector.guardadataidPG();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow agregarEstudiantexRedTematica(string codredtematicasede, string codestumatricula)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO rt_redtematicamatricula (codredtematicasede,codestumatricula) VALUES (@codredtematicasede,@codestumatricula) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        conector.AsignarParametroCadena("@codestumatricula", codestumatricula);
        DataRow dato = conector.guardadataidPG();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public bool agregarDocentexRedTematica(string codgradodocente, string codredtematicasede)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO rt_redtematicadocente (codgradodocente,codredtematicasede) VALUES (@codgradodocente,@codredtematicasede)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        conector.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        return conector.guardadata();
    }

    public DataRow buscarDocenteRedTematica(string codgradodocente, string codredtematicasede)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM rt_redtematicadocente  where codgradodocente=@codgradodocente and codredtematicasede=@codredtematicasede";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        conector.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        DataRow dato = conector.guardadataidPG();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataTable cargarEstudiantesxRedTematica(string codredtematicasede)
    {
        Conexion conector = new Conexion();
        string consulta = "select pm.codigo as rt_codproyectomatricula,pm.codestumatricula, e.identificacion,concat_ws(' ',e.nombre,e.apellido) as nombre,g.nombre as nomgrado, em.codanio from rt_redtematicamatricula pm inner join ins_estumatricula em on em.codigo=pm.codestumatricula inner join ins_estudiante e on e.codigo=em.codestudiante inner join ins_grado g on g.codigo=em.codgrado where pm.codredtematicasede=@codredtematicasede";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
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

    public DataTable cargarDocentesxRedTematica(string codredtematicasede)
    {
        Conexion conector = new Conexion();
        string consulta = "select pd.codigo as codredtematicadocente, concat_ws(' ',d.nombre,d.apellido) as nombre, gd.identificacion, pd.codgradodocente, gd.codanio from rt_redtematicadocente pd inner join ins_gradodocente gd on gd.cod=pd.codgradodocente inner join ins_docente d on d.identificacion=gd.identificacion  where pd.codredtematicasede=@codredtematicasede";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
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

    public DataTable cargarAsesorxRedTematica(string codrectematicasede)
    {
        Conexion conector = new Conexion();
        string consulta = "select ps.codigo as codredtematicasede, ps.codasesorcoordinador, concat_ws(' ',a.nombre,a.apellido) as nombre, a.identificacion from rt_redtematicasede ps inner join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor where ps.codigo=@codrectematicasede";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codrectematicasede", codrectematicasede);
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
    public DataTable buscarDatoS004(string codredtematicasede)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from est_estra2instrumento_s004_redt where codredtematicasede=@codredtematicasede";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        DataTable dato = conector.traerdata();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public Boolean eliminarPreguntasS004(String codestrainstrumento_s004_redt)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2instrumento_s004_preguntas_redt WHERE codestrainstrumento_s004_redt=@codestrainstrumento_s004_redt ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestrainstrumento_s004_redt", codestrainstrumento_s004_redt);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarRedTematicaSede(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM rt_redtematicasede WHERE codigo=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarEstudianteRedTematica(String codredtematicasede)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM rt_redtematicamatricula WHERE codredtematicasede=@codredtematicasede ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarDocenteRedTematica(String codredtematicasede)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM rt_redtematicadocente WHERE codredtematicasede=@codredtematicasede ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarMatriculaEstudianteRedTematica(string codestumatricula)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM rt_redtematicamatricula WHERE codestumatricula=@codestumatricula";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestumatricula", codestumatricula);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarMatriculaDocenteRedTematica(string codgradodocente)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM rt_redtematicadocente WHERE codgradodocente=@codgradodocente";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarMatriculaAsesorRedTematica(string codrectematicasede)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE rt_redtematicasede SET codasesorcoordinador='0' WHERE codigo=@codrectematicasede";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codrectematicasede", codrectematicasede);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean agregarMatriculaAsesorRedTematica(string codasesorcoordinador, string codrectematicasede)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE rt_redtematicasede SET codasesorcoordinador=@codasesorcoordinador WHERE codigo=@codrectematicasede";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@codrectematicasede", codrectematicasede);
        bool resp = conector.guardadata();
        return resp;
    }
    public DataRow buscarEstudianteRedTematica(string codredtematicamatricula)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT pd.codigo as codredtematica, pm.codestumatricula FROM rt_redtematicamatricula pm inner join rt_redtematicadocente pd on pd.codredtematicamatricula=pm.codigo where pm.codigo=@rcodredtematicamatricula";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codredtematicamatricula", codredtematicamatricula);
        DataRow dato = conector.guardadataidPG();
        if (dato != null)
            return dato;
        else
            return null;
    }

    //Grupos de Investigación
    public DataTable cargarLineaInvestigacion()
    {
        Conexion conector = new Conexion();
        string consulta = "select * from pro_linea_investigacion order by nombre ASC";
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
    public DataRow agregarGrupoInvestigacionxSede( string codsede, string fechacreacion, string codasesorcoordinador, string codlineainvestigacion, string codarea, string nombregrupo)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO pro_proyectosede (codsede,fechacreacion,codasesorcoordinador,codlineainvestigacion,codarea,nombregrupo) VALUES (@codsede,@fechacreacion,@codasesorcoordinador,@codlineainvestigacion,@codarea,@nombregrupo) RETURNING codigo";
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
    public DataRow agregarEstudiantexGrupoInvestigacion(string codproyectosede, string codestumatricula)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO pro_proyectomatricula (codproyectosede,codestumatricula) VALUES (@codproyectosede,@codestumatricula) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
        conector.AsignarParametroCadena("@codestumatricula", codestumatricula);
        DataRow dato = conector.guardadataidPG();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public bool agregarDocentexGrupoInvestigacion(string codgradodocente, string codproyectosede)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO pro_proyectodocente (codgradodocente,codproyectosede) VALUES (@codgradodocente,@codproyectosede)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
        return conector.guardadata();
    }
    public DataTable cargarAreas()
    {
        Conexion conector = new Conexion();
        string consulta = "select * from pro_areas order by nombre ASC";
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

    public DataTable cargarEstudiantesxGrupoInvestigacion(string codproyectosede)
    {
        Conexion conector = new Conexion();
        string consulta = "select pm.codigo as pro_proyectomatricula, e.identificacion,concat_ws('',e.nombre,e.apellido) as nombre,g.nombre as nomgrado, em.codanio, a.nombre as anio from pro_proyectomatricula pm inner join ins_estumatricula em on em.codigo=pm.codestumatricula inner join ins_estudiante e on e.codigo=em.codestudiante inner join ins_grado g on g.codigo=em.codgrado inner join ins_anio a on a.codigo=em.codanio where pm.codproyectosede=@codproyectosede order by e.nombre ASC";
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
    public DataTable cargarAsesorxEstrategia(string codestrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "select ac.codigo as codasesorcoordinador, a.identificacion, CONCAT_WS(' ',a.nombre,a.apellido) as nombre from est_asesor a inner join est_asesorcoordinador ac on ac.codasesor=a.codigo inner join est_estracoordinador ec on ec.codigo=ac.codestracoordinador where ec.codestrategia=@codestrategia";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestrategia", codestrategia);
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

    public DataTable cargarDocentesxGrupoInvestigacion(string codproyectosede)
    {
        Conexion conector = new Conexion();
        string consulta = "select pd.codigo as codproyectodocente, concat_ws(' ',d.nombre,d.apellido) as nombre, gd.identificacion, pd.codgradodocente  from pro_proyectodocente pd inner join ins_gradodocente gd on gd.cod=pd.codgradodocente inner join ins_docente d on d.identificacion=gd.identificacion where pd.codproyectosede=@codproyectosede";
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

    public DataTable cargarAsesorxGrupoInvestigacion(string codproyectosede)
    {
        Conexion conector = new Conexion();
        string consulta = "select ps.codigo as codproyectosede, ps.codasesorcoordinador, concat_ws(' ',a.nombre,a.apellido) as nombre, a.identificacion from pro_proyectosede ps inner join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor where ps.codigo=@codproyectosede";
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

    public Boolean eliminarEstudiantesGrupoInvestigacionTodo(String codproyectosede)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM pro_proyectomatricula WHERE codproyectosede=@codproyectosede ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarDocentesGrupoInvestigacionTodo(String codproyectosede)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM pro_proyectodocente WHERE codproyectosede=@codproyectosede ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarGrupoInvestigacionSede(String codproyectosede)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM pro_proyectosede WHERE codigo=@codproyectosede ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean eliminarEstudianteGrupoInvestigacion(String codproyectodocente)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM pro_proyectodocente WHERE codigo=@codproyectodocente ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyectodocente", codproyectodocente);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarMatriculaEstudianteGrupoInvestigacion(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM pro_proyectomatricula WHERE codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarMatriculaDocenteGrupoInvestigacion(string codproyectodocente)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM pro_proyectodocente WHERE codigo=@codproyectodocente";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyectodocente", codproyectodocente);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarMatriculaAsesorGrupoInvestigacion(string codproyectosede)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE pro_proyectosede SET codasesorcoordinador='0' WHERE codigo=@codproyectosede";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarMatriculaDocenteMesaTrabajo(string codmesadetrabajo, string codgradodocente)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM pro_mesadetrabajodocente WHERE codgradodocente=@codgradodocente AND codmesadetrabajo=@codmesadetrabajo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codmesadetrabajo", codmesadetrabajo);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean agregarMatriculaAsesorGrupoInvestigacion(string codasesorcoordinador, string codproyectosede)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE pro_proyectosede SET codasesorcoordinador=@codasesorcoordinador WHERE codigo=@codproyectosede";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
        bool resp = conector.guardadata();
        return resp;
    }
    public DataRow buscarEstudianteGrupoInvestigacion(string codproyectomatricula)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT pd.codigo as codproyectodocente, pm.codestumatricula FROM pro_proyectomatricula pm inner join pro_proyectodocente pd on pd.codproyectomatricula=pm.codigo where pm.codigo=@codproyectomatricula";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyectomatricula", codproyectomatricula);
        DataRow dato = conector.guardadataidPG();
        if (dato != null)
            return dato;
        else
            return null;
    }

    //Estu matricula
	 public DataTable buscarEstudianteNoMatricula(String valor)
    {
        Conexion conectar = new Conexion();
        string sql = "select e.codigo, e.identificacion, (e.nombre || ' ' || e.apellido) estudiante from ins_estudiante e left join ins_estumatricula m on m.codestudiante = e.codigo where m.codigo is null ";
      
        /*verifico si la cadena es un numero*/
        long number1 = 0;
        bool canConvert = long.TryParse(valor, out number1);
        if (canConvert == true){
            sql += " AND e.identificacion::text ILIKE '%" + valor + "%' limit 50";
        }else {
            sql += " AND (e.nombre || ' ' || e.apellido) ILIKE '%" + valor.ToUpper() + "%' limit 50";
        }

             
        conectar.CrearComando(sql);
        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return null;
    }
	
    public DataTable listarEstudianteNoMatricula()
    {
        Conexion conectar = new Conexion();
        string sql = "select e.codigo, e.identificacion, (e.nombre || ' ' || e.apellido) estudiante from ins_estudiante e left join ins_estumatricula m on m.codestudiante = e.codigo where m.codigo is null limit 100";
        conectar.CrearComando(sql);
        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public Boolean matricularEstudiante(string codestudiante, string codsede, string codgrado)
    {
        Conexion conectar = new Conexion();
        string sql = "insert into ins_estumatricula (codsede, codestudiante, codanio, fecha_matricula, codgrado, codtipogrupo) values (@codsede, @codestudiante, 1, NOW(), @codgrado, 1), (@codsede2, @codestudiante2, 1, NOW(), @codgrado2, 2)";
        conectar.CrearComando(sql);
        conectar.AsignarParametroCadena("@codsede", codsede);
        conectar.AsignarParametroCadena("@codestudiante", codestudiante);
        conectar.AsignarParametroCadena("@codgrado", codgrado);
        conectar.AsignarParametroCadena("@codsede2", codsede);
        conectar.AsignarParametroCadena("@codestudiante2", codestudiante);
        conectar.AsignarParametroCadena("@codgrado2", codgrado);
        bool response = conectar.guardadata();
        return response;
    }
    public DataRow buscarestumatriculaRedTematica(string codestumatricula)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM rt_redtematicamatricula where codestumatricula=@codestumatricula";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestumatricula", codestumatricula);
        DataRow dato = conector.guardadataidPG();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public Boolean eliminarestumatriculaRedTematica(string codestumatricula)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM rt_redtematicamatricula WHERE codestumatricula=@codestumatricula";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestumatricula", codestumatricula);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarEstumatricula(string codestumatricula, string codtipogrupo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM ins_estumatricula WHERE codigo=@codestumatricula and codtipogrupo=@codtipogrupo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestumatricula", codestumatricula);
        conector.AsignarParametroCadena("@codtipogrupo", codtipogrupo);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarEstumatriculaxAnio(string codestumatricula, string codtipogrupo, string codanio, string grupo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM ins_estumatricula WHERE codigo=@codestumatricula and codtipogrupo=@codtipogrupo and codanio=@codanio and grupo=@grupo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestumatricula", codestumatricula);
        conector.AsignarParametroCadena("@codtipogrupo", codtipogrupo);
        conector.AsignarParametroCadena("@codanio", codanio);
        conector.AsignarParametroCadena("@grupo", grupo);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarEstudiante(string codestudiante)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM ins_estudiante WHERE codigo=@codestudiante";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestudiante", codestudiante);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarEstudianteID(string identificacion)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM ins_estudiante WHERE identificacion=@identificacion";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarMatriculaDocenteMesadeTrabajo(string codgradodocente)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM pro_mesadetrabajodocente WHERE codgradodocente=@codgradodocente";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        bool resp = conector.guardadata();
        return resp;
    }

    public DataTable cargarmunicipios(string coddepartamento)
    {
        Conexion conector = new Conexion();
        string consulta = "Select d.cod as coddepartamento, m.cod as cod, m.nombre as nombre, m.tipo as tipo from geo_municipios m inner join geo_departamentos d on d.cod=m.coddepartamento where m.coddepartamento=@coddepartamento order by m.nombre ASC";
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

    public DataTable cargarmunicipiosxFerias(string coddepartamento, string codferiamunicipal)
    {
        Conexion conector = new Conexion();
        string consulta = "Select fm.coddepartamento, m.cod as cod, m.nombre as nombre, m.tipo as tipo from geo_municipios m inner join ep_municipiomatricula mm on m.cod=mm.codmunicipiomatricula inner join ep_feriasmunicipales fm on fm.coddepartamento=m.coddepartamento where fm.coddepartamento=@coddepartamento and mm.codferiamunicipal=@codferiamunicipal group by fm.coddepartamento, m.cod, m.nombre, m.tipo order by m.nombre ASC ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddepartamento", coddepartamento);
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

    public DataRow agregarFeriaMunicipalxMunicipio(string coddepartamento, string nombreferiamunicipal, string numeroasistentes, string numerogrupos, string fechaelaboracion, string horaferia, string horaferiafinal)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO ep_feriasmunicipales (coddepartamento, nombreferiamunicipal, numeroasistentes, numerogrupos, fechaelaboracion, horaferia, horaferiafinal) VALUES (@coddepartamento, @nombreferiamunicipal, @numeroasistentes, @numerogrupos, @fechaelaboracion, @horaferia, @horaferiafinal) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddepartamento", coddepartamento);
        conector.AsignarParametroCadena("@nombreferiamunicipal", nombreferiamunicipal);
        conector.AsignarParametroCadena("@numeroasistentes", numeroasistentes);
        conector.AsignarParametroCadena("@numerogrupos", numerogrupos);
        conector.AsignarParametroCadena("@fechaelaboracion", fechaelaboracion);
        conector.AsignarParametroCadena("@horaferia", horaferia);
        conector.AsignarParametroCadena("@horaferiafinal", horaferiafinal);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataRow agregarMunicipioxFeriaMunicipal(string codferiamunicipal, string codmunicipiomatricula)
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

    public Boolean eliminarferiamunicipal(String codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM ep_feriasmunicipales WHERE codigo=@codigo ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean eliminarMunicipioFeriaMunicipal(String codferiamunicipal)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM ep_municipiomatricula WHERE codferiamunicipal=@codferiamunicipal ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codferiamunicipal", codferiamunicipal);
        bool resp = conector.guardadata();
        return resp;
    }

    public DataTable cargarmunicipiosmatriculados(string codferiamunicipal)
    {
        Conexion conector = new Conexion();
        string consulta = "Select m.coddepartamento as coddepartamento, m.cod as cod, m.nombre as nombre, m.tipo as tipo from geo_municipios m inner join ep_municipiomatricula mm on mm.codmunicipiomatricula=m.cod inner join ep_feriasmunicipales fm on fm.codigo=mm.codferiamunicipal where fm.codigo=@codferiamunicipal order by m.nombre ASC";
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


    //Metodos agregados por Alvaro Rodriguez
        //FeriaDepartamental
        public Boolean eliminarferiadepartamental(String codigo)
        {
            Conexion conector = new Conexion();
            string consulta = "DELETE FROM ep_feriasdepa WHERE codigo=@codigo ";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@codigo", codigo);
            bool resp = conector.guardadata();
            return resp;
        }

        public DataRow agregarFeriaMunicipalxDepartamento(string coddepartamento, string nombreferiamunicipal, string numeroasistentes, string numerogrupos, string numerodocentes, string fechaelaboracion, string horaferia, string horaferiafinal, string fechaelaboracioncierre, string horaferiacierre, string horaferiafinalcierre)
        {
            Conexion conector = new Conexion();
            string consulta = "INSERT INTO ep_feriasdepa (coddepartamento, nombreferiamunicipal, numeroasistentes, numerogrupos, numerodocentes, fechaelaboracion, horaferia, horaferiafinal, fechaelaboracioncierre, horaferiacierre, horaferiafinalcierre) VALUES (@coddepartamento, @nombreferiamunicipal, @numeroasistentes, @numerogrupos, @numerodocentes, @fechaelaboracion, @horaferia, @horaferiafinal, @fechaelaboracioncierre, @horaferiacierre, @horaferiafinalcierre) RETURNING codigo";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@coddepartamento", coddepartamento);
            conector.AsignarParametroCadena("@nombreferiamunicipal", nombreferiamunicipal);
            conector.AsignarParametroCadena("@numeroasistentes", numeroasistentes);
            conector.AsignarParametroCadena("@numerogrupos", numerogrupos);
            conector.AsignarParametroCadena("@numerodocentes", numerodocentes);
            conector.AsignarParametroCadena("@fechaelaboracion", fechaelaboracion);
            conector.AsignarParametroCadena("@horaferia", horaferia);
            conector.AsignarParametroCadena("@horaferiafinal", horaferiafinal);
            conector.AsignarParametroCadena("@fechaelaboracioncierre", fechaelaboracioncierre);
            conector.AsignarParametroCadena("@horaferiacierre", horaferiacierre);
            conector.AsignarParametroCadena("@horaferiafinalcierre", horaferiafinalcierre);
            DataRow dato = conector.traerfila();
            if (dato != null)
                return dato;
            else
                return null;
        }

        //FeriaRegional
        public Boolean eliminarferiaregional(String codigo)
        {
            Conexion conector = new Conexion();
            string consulta = "DELETE FROM ep_feriasreg WHERE codigo=@codigo ";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@codigo", codigo);
            bool resp = conector.guardadata();
            return resp;
        }

        public DataRow agregarFeriaMunicipalxRegional(string coddepartamento, string nombreferiamunicipal, string numeroasistentes, string numerogrupos, string numerodocentes, string fechaelaboracion, string horaferia, string horaferiafinal, string fechaelaboracioncierre, string horaferiacierre, string horaferiafinalcierre)
        {
            Conexion conector = new Conexion();
            string consulta = "INSERT INTO ep_feriasreg (coddepartamento, nombreferiamunicipal, numeroasistentes, numerogrupos, numerodocentes, fechaelaboracion, horaferia, horaferiafinal, fechaelaboracioncierre, horaferiacierre, horaferiafinalcierre) VALUES (@coddepartamento, @nombreferiamunicipal, @numeroasistentes, @numerogrupos, @numerodocentes, @fechaelaboracion, @horaferia, @horaferiafinal, @fechaelaboracioncierre, @horaferiacierre, @horaferiafinalcierre) RETURNING codigo";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@coddepartamento", coddepartamento);
            conector.AsignarParametroCadena("@nombreferiamunicipal", nombreferiamunicipal);
            conector.AsignarParametroCadena("@numeroasistentes", numeroasistentes);
            conector.AsignarParametroCadena("@numerogrupos", numerogrupos);
            conector.AsignarParametroCadena("@numerodocentes", numerodocentes);
            conector.AsignarParametroCadena("@fechaelaboracion", fechaelaboracion);
            conector.AsignarParametroCadena("@horaferia", horaferia);
            conector.AsignarParametroCadena("@horaferiafinal", horaferiafinal);
            conector.AsignarParametroCadena("@fechaelaboracioncierre", fechaelaboracioncierre);
            conector.AsignarParametroCadena("@horaferiacierre", horaferiacierre);
            conector.AsignarParametroCadena("@horaferiafinalcierre", horaferiafinalcierre);
            DataRow dato = conector.traerfila();
            if (dato != null)
                return dato;
            else
                return null;
        }

        //FeriaNacional
        public Boolean eliminarferianacional(String codigo)
        {
            Conexion conector = new Conexion();
            string consulta = "DELETE FROM ep_feriasnac WHERE codigo=@codigo ";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@codigo", codigo);
            bool resp = conector.guardadata();
            return resp;
        }

        public DataRow agregarFeriaMunicipalxNacional(string coddepartamento, string nombreferiamunicipal, string numeroasistentes, string numerogrupos, string numerodocentes, string fechaelaboracion, string horaferia, string horaferiafinal, string fechaelaboracioncierre, string horaferiacierre, string horaferiafinalcierre)
        {
            Conexion conector = new Conexion();
            string consulta = "INSERT INTO ep_feriasnac (coddepartamento, nombreferiamunicipal, numeroasistentes, numerogrupos, numerodocentes, fechaelaboracion, horaferia, horaferiafinal, fechaelaboracioncierre, horaferiacierre, horaferiafinalcierre) VALUES (@coddepartamento, @nombreferiamunicipal, @numeroasistentes, @numerogrupos, @numerodocentes, @fechaelaboracion, @horaferia, @horaferiafinal, @fechaelaboracioncierre, @horaferiacierre, @horaferiafinalcierre) RETURNING codigo";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@coddepartamento", coddepartamento);
            conector.AsignarParametroCadena("@nombreferiamunicipal", nombreferiamunicipal);
            conector.AsignarParametroCadena("@numeroasistentes", numeroasistentes);
            conector.AsignarParametroCadena("@numerogrupos", numerogrupos);
            conector.AsignarParametroCadena("@numerodocentes", numerodocentes);
            conector.AsignarParametroCadena("@fechaelaboracion", fechaelaboracion);
            conector.AsignarParametroCadena("@horaferia", horaferia);
            conector.AsignarParametroCadena("@horaferiafinal", horaferiafinal);
            conector.AsignarParametroCadena("@fechaelaboracioncierre", fechaelaboracioncierre);
            conector.AsignarParametroCadena("@horaferiacierre", horaferiacierre);
            conector.AsignarParametroCadena("@horaferiafinalcierre", horaferiafinalcierre);
            DataRow dato = conector.traerfila();
            if (dato != null)
                return dato;
            else
                return null;
        }

        //FeriaInternacional
        public Boolean eliminarferiainternacional(String codigo)
        {
            Conexion conector = new Conexion();
            string consulta = "DELETE FROM ep_feriasint WHERE codigo=@codigo ";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@codigo", codigo);
            bool resp = conector.guardadata();
            return resp;
        }

        public DataRow agregarFeriaMunicipalxInternacional(string coddepartamento, string nombreferiamunicipal, string numeroasistentes, string numerogrupos, string numerodocentes, string fechaelaboracion, string horaferia, string horaferiafinal, string fechaelaboracioncierre, string horaferiacierre, string horaferiafinalcierre, string lugar)
        {
            Conexion conector = new Conexion();
            string consulta = "INSERT INTO ep_feriasint (coddepartamento, nombreferiamunicipal, numeroasistentes, numerogrupos, numerodocentes, fechaelaboracion, horaferia, horaferiafinal, fechaelaboracioncierre, horaferiacierre, horaferiafinalcierre, lugar) VALUES (@coddepartamento, @nombreferiamunicipal, @numeroasistentes, @numerogrupos, @numerodocentes, @fechaelaboracion, @horaferia, @horaferiafinal, @fechaelaboracioncierre, @horaferiacierre, @horaferiafinalcierre, @lugar) RETURNING codigo";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@coddepartamento", coddepartamento);
            conector.AsignarParametroCadena("@nombreferiamunicipal", nombreferiamunicipal);
            conector.AsignarParametroCadena("@numeroasistentes", numeroasistentes);
            conector.AsignarParametroCadena("@numerogrupos", numerogrupos);
            conector.AsignarParametroCadena("@numerodocentes", numerodocentes);
            conector.AsignarParametroCadena("@fechaelaboracion", fechaelaboracion);
            conector.AsignarParametroCadena("@horaferia", horaferia);
            conector.AsignarParametroCadena("@horaferiafinal", horaferiafinal);
            conector.AsignarParametroCadena("@fechaelaboracioncierre", fechaelaboracioncierre);
            conector.AsignarParametroCadena("@horaferiacierre", horaferiacierre);
            conector.AsignarParametroCadena("@horaferiafinalcierre", horaferiafinalcierre);
            conector.AsignarParametroCadena("@lugar", lugar);
            DataRow dato = conector.traerfila();
            if (dato != null)
                return dato;
            else
                return null;
        }
    //Fin de Metodos agregados por Alvaro Rodriguez


}