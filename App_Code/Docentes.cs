using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Cliente
/// </summary>
public class Docentes
{
    public Docentes()
	{
		//
		// TODO: Agregar aquí la lógica del constructor prueba de cambios en la nube
		//
	}

    public DataTable cargarTipoDocumento()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM con_tipodocumento c;";
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

    public bool agregarDocente(string nombre, string apellido, string identificacion, string sexo, string fecha_nacimiento, string telefono, string direccion, string email, string codtipodocumento)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO ins_docente (nombre,apellido,identificacion,sexo,fecha_nacimiento,telefono,direccion,email,codtipodocumento) VALUES (@nombre,@apellido,@identificacion,@sexo,@fecha_nacimiento,@telefono,@direccion,@email,@codtipodocumento)";
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

    public DataRow agregarDocenteDR(string nombre, string apellido, string identificacion, string sexo, string fecha_nacimiento, string telefono, string direccion, string email, string codtipodocumento)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO ins_docente (nombre,apellido,identificacion,sexo,fecha_nacimiento,telefono,direccion,email,codtipodocumento) VALUES (@nombre,@apellido,@identificacion,@sexo,@fecha_nacimiento,@telefono,@direccion,@email,@codtipodocumento) RETURNING codigo";
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
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public bool agregarDocenteGrado(string identificacion, string codsede, string codanio)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO ins_gradodocente (identificacion,codsede,codanio) VALUES (@identificacion,@codsede,@codanio)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@codanio", codanio);
        return conector.guardadata();
    }

    public DataRow buscarGradoDocente(string codsede, string identificacion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT cod FROM ins_gradodocente WHERE identificacion=@identificacion AND codsede=@codsede";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscarDocenteMatriculado(string identificacion, string codanio)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT cod FROM ins_gradodocente WHERE identificacion=@identificacion and codanio=@codanio";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@codanio", codanio);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscarDocenteMatriculadoxID(string identificacion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT cod FROM ins_gradodocente WHERE identificacion=@identificacion order by cod asc limit 1";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscarDocenteIngresado(string identificacion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM ins_docente c WHERE c.identificacion=@identificacion";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscarDocenteRedTematica(string codgradodocente, string codredtematicasede)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM rt_redtematicadocente WHERE codgradodocente=@codgradodocente and codredtematicasede=@codredtematicasede";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        conector.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataTable cargarDocentesWhere(string where)
    {
        Conexion conector = new Conexion();
        string consulta = "select gd.cod,d.identificacion, CONCAT_WS(' ', d.nombre,d.apellido) as nombrecompleto, d.direccion, d.telefono, d.sexo,d.email, s.dane,s.nombre as nomsede, s.sede, m.nombre as municipio from ins_institucion i inner join ins_sede s on i.codigo=s.codinstitucion inner join ins_gradodocente gd on gd.codsede=s.codigo inner join ins_docente d on d.identificacion=gd.identificacion inner join geo_municipios m on m.cod=s.codmunicipio " + where;
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

    public DataTable cargarDocentes()
    {
        Conexion conector = new Conexion();
        string consulta = "select d.codigo, CONCAT_WS(' ',d.identificacion,'-',d.nombre,d.apellido) as nombrecompleto from ins_gradodocente gd inner join ins_docente d on gd.identificacion=d.identificacion inner join ins_sede s on s.codigo=gd.codsede ";
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

    public DataRow buscarDocenteIngresadoxCod(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT identificacion FROM ins_docente WHERE codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow buscarDocentexInstitucion(string codsede, string identificacion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM ins_gradodocente WHERE codsede=@codsede AND identificacion=@identificacion";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataTable cargarDocentesxSede(string codsede, string codanio)
    {
        Conexion conector = new Conexion();
        string consulta = "select gd.cod as codgradodocente,d.identificacion,concat_ws(' ',d.nombre,d.apellido) as nomdocente, gd.codanio from ins_gradodocente gd inner join ins_docente d on d.identificacion=gd.identificacion where gd.codsede=@codsede and gd.codanio=@codanio order by d.nombre ASC;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
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

    public DataTable cargarDocentesEspacioApropiacion(string codespacioapro)
    {
        Conexion conector = new Conexion();//est_estra1espacioapropiaciondocentes
        string consulta = "select gd.cod as codgradodocente,d.identificacion,concat_ws(' ',d.nombre,d.apellido) as nomdocente, gd.codanio from ins_gradodocente gd inner join ins_docente d on d.identificacion=gd.identificacion inner join est_estra1espacioapropiaciondocentes ea on ea.codgradodocente=gd.cod where ea.codespacioapro=@codespacioapro order by d.nombre ASC;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codespacioapro", codespacioapro);
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

    public DataRow buscarDocentesEspacioApropiacion(string codespacioapro, string codgradodocente)
    {
        Conexion conector = new Conexion();
        string consulta = "select gd.cod as codgradodocente,d.identificacion,concat_ws(' ',d.nombre,d.apellido) as nomdocente, gd.codanio from ins_gradodocente gd inner join ins_docente d on d.identificacion=gd.identificacion inner join est_estra1espacioapropiaciondocentes ea on ea.codgradodocente=gd.cod where ea.codespacioapro=@codespacioapro and ea.codgradodocente=@codgradodocente order by d.nombre ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        conector.AsignarParametroCadena("@codespacioapro", codespacioapro);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow buscarDocentesPaticipacionFerias(string codparticipantesferias, string codgradodocente)
    {
        Conexion conector = new Conexion();
        string consulta = "select gd.cod as codgradodocente,d.identificacion,concat_ws(' ',d.nombre,d.apellido) as nomdocente, gd.codanio from ins_gradodocente gd inner join ins_docente d on d.identificacion=gd.identificacion inner join est_estra1participantesferiasdocentes ea on ea.codgradodocente=gd.cod where ea.codparticipantesferias=@codparticipantesferias and ea.codgradodocente=@codgradodocente order by d.nombre ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        conector.AsignarParametroCadena("@codparticipantesferias", codparticipantesferias);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow buscarDocentesS002Estra1(string codestra2instrumento_s002, string codgradodocente)
    {
        Conexion conector = new Conexion();
        string consulta = "select gd.cod as codgradodocente,d.identificacion,concat_ws(' ',d.nombre,d.apellido) as nomdocente, gd.codanio from ins_gradodocente gd inner join ins_docente d on d.identificacion=gd.identificacion inner join est_estra2instrumento_s002docentes ea on ea.codgradodocente=gd.cod where ea.codestra2instrumento_s002=@codestra2instrumento_s002 and ea.codgradodocente=@codgradodocente order by d.nombre ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        conector.AsignarParametroCadena("@codestra2instrumento_s002", codestra2instrumento_s002);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public bool MoverDocenteDeSede(string codsede, string codgradodocente, string codanio)
    {
        Conexion conectar = new Conexion();
        string consulta = "update ins_gradodocente set codsede=@codsede where cod=@codgradodocente and codanio=@codanio";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@codsede", codsede);
        conectar.AsignarParametroCadena("@codgradodocente", codgradodocente);
        conectar.AsignarParametroCadena("@codanio", codanio);
        return conectar.guardadata();
    }

    public DataRow buscarCodAnioActual(string nombre)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo FROM ins_anio c  WHERE c.nombre=@nombre";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow buscarCodAnioActualxCodigo(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM ins_anio c  WHERE c.codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public bool matriculaDocenteEspacioApro(string codespacioapro, string codgradodocente)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra1espacioapropiaciondocentes (codespacioapro,codgradodocente) VALUES (@codespacioapro,@codgradodocente)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codespacioapro", codespacioapro);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        return conector.guardadata();
    }

    public bool matriculaDocenteParticipacionFerias(string codparticipantesferias, string codgradodocente)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra1participantesferiasdocentes (codparticipantesferias,codgradodocente) VALUES (@codparticipantesferias,@codgradodocente)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codparticipantesferias", codparticipantesferias);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        return conector.guardadata();
    }

    public bool matriculaDocenteS002Estra1(string codestra2instrumento_s002, string codgradodocente)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estra2instrumento_s002docentes (codestra2instrumento_s002,codgradodocente) VALUES (@codestra2instrumento_s002,@codgradodocente)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestra2instrumento_s002", codestra2instrumento_s002);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        return conector.guardadata();
    }

    public DataRow buscarDocenteEnEspacioApro(string codespacioapro)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM est_estra1espacioapropiaciondocentes c  WHERE c.codespacioapro=@codespacioapro LIMIT 1 ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codespacioapro", codespacioapro);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow buscarDocenteEnParticipantesFerias(string codparticipantesferias)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM est_estra1participantesferiasdocentes c  WHERE c.codparticipantesferias=@codparticipantesferias LIMIT 1 ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codparticipantesferias", codparticipantesferias);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow buscarDocenteEnS002Estra1(string codestra2instrumento_s002)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM est_estra2instrumento_s002docentes c  WHERE c.codestra2instrumento_s002=@codestra2instrumento_s002 LIMIT 1 ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestra2instrumento_s002", codestra2instrumento_s002);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow buscarDocentesxCodigo(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM ins_gradodocente c  WHERE c.cod=@cod LIMIT 1 ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public bool deleteDocentesEspacioApropiacion(string codespacioapro)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1espacioapropiaciondocentes WHERE codespacioapro=@codespacioapro";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codespacioapro", codespacioapro);
        return conector.guardadata();
    }

    public bool deleteDocentesParticipantesFerias(string codparticipantesferias)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra1participantesferiasdocentes WHERE codparticipantesferias=@codparticipantesferias";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codparticipantesferias", codparticipantesferias);
        return conector.guardadata();
    }

    public bool deleteDocentesS002Estra1(string codestra2instrumento_s002)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM est_estra2instrumento_s002docentes WHERE codestra2instrumento_s002=@codestra2instrumento_s002";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestra2instrumento_s002", codestra2instrumento_s002);
        return conector.guardadata();
    }

}