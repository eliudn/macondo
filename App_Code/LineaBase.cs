using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Equipo
/// </summary>
public class LineaBase
{
	public LineaBase()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public DataRow buscarConfiIntrumento(string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM lbase_confinstrumento WHERE codinstrumento=@codinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public bool agregarFechaInstrumento(string codinstrumento, string fechainicio, string fechafinal, string usuario)
    {
        Conexion conector = new Conexion();
        string consulta = " INSERT INTO lbase_confinstrumento (codinstrumento,fechainicio,fechafinal,usuario) VALUES (@codinstrumento,@fechainicio,@fechafinal,@usuario)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@fechainicio", fechainicio);
        conector.AsignarParametroCadena("@fechafinal", fechafinal);
       // conector.AsignarParametroCadena("@tiempoejecucion", tiempoejecucion);
        conector.AsignarParametroCadena("@usuario", usuario);
        return conector.guardadata();
    }

    public bool ActualizarFechaInstrumento(string codinstrumento, string fechainicio, string fechafinal, string usuario)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE lbase_confinstrumento SET  fechainicio = @fechainicio,fechafinal = @fechafinal,usuario = @usuario WHERE codinstrumento = @codinstrumento ;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@fechainicio", fechainicio);
        conector.AsignarParametroCadena("@fechafinal", fechafinal);
//        conector.AsignarParametroCadena("@tiempoejecucion", tiempoejecucion);
        conector.AsignarParametroCadena("@usuario", usuario);
        return conector.guardadata();
    }

    public DataRow buscarConfiTiempo()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM lbase_confitiempo";
        conector.CrearComando(consulta);
       
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public bool agregarTiempoEjecucion(string tiempo, string usuario)
    {
        Conexion conector = new Conexion();
        string consulta = " INSERT INTO lbase_confitiempo (tiempo,usuario) VALUES (@tiempo,@usuario)";
        conector.CrearComando(consulta);

        conector.AsignarParametroCadena("@tiempo", tiempo);
        conector.AsignarParametroCadena("@usuario", usuario);
        return conector.guardadata();
    }

    public bool ActualizarTiempoEjecucion(string tiempo, string usuario)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE lbase_confitiempo SET  tiempo = @tiempo,usuario = @usuario";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@tiempo", tiempo);
        conector.AsignarParametroCadena("@usuario", usuario);
        return conector.guardadata();
    }

    //Para el contador del tiempo
    public string contador(decimal s)
    {
        decimal seg = s;
        string segundos = "00";
        string minutos = "00";
        if (seg <= 59)
        {
            segundos = Convert.ToString(seg);
            segundos = agregacero(segundos);
        }
        else if (seg > 59)
        {
            segundos = Convert.ToString(seg % 60);
            segundos = agregacero(segundos);
            minutos = Convert.ToString(Math.Floor(seg / 60));
        }
        seg--;
        HttpContext.Current.Session["tiempo"] = seg;
        string res = minutos + ":" + segundos;
        return res;
    }
    public string agregacero(string n)
    {
        if (n.ToString().Length < 2)
        {
            return '0' + n;
        }
        else
        {
            return n;
        }
    }
    //Fin contador del tiempo

    public bool agregarRegistroInstitucional(string codinstitucion, string nomcoordinador, string cargo, string nomasesor, string fecharegistro, string codsede)
    {
        Conexion conector = new Conexion();
        string consulta = " INSERT INTO lbase_reginstitucion (codinstitucion,nomcoordinador,cargo,nomasesor,fecharegistro,codsede) VALUES (@codinstitucion,@nomcoordinador,@cargo,@nomasesor,@fecharegistro,@codsede)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstitucion", codinstitucion);
        conector.AsignarParametroCadena("@nomcoordinador", nomcoordinador);
        conector.AsignarParametroCadena("@cargo", cargo);
        conector.AsignarParametroCadena("@nomasesor", nomasesor);
        conector.AsignarParametroCadena("@fecharegistro", fecharegistro);
        conector.AsignarParametroCadena("@codsede", codsede);
        return conector.guardadata();
    }

    public DataRow buscarUltimoRegistroLB()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM lbase_reginstitucion ORDER BY codigo DESC LIMIT 1";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscarInstitucionLB(string codinstitucion)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM lbase_reginstitucion WHERE codinstitucion=@codinstitucion";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstitucion", codinstitucion);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscarInstitucionLineaBase(string codinstitucion, string codsede, string codasesor, string codgradodocente)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM lbase_reginstitucion WHERE codinstitucion=@codinstitucion AND codsede=@codsede AND codasesor=@codasesor AND codgradodocente=@codgradodocente";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstitucion", codinstitucion);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@codasesor", codasesor);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow buscarDocentexSedexInstitucion(string identificacion)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from ins_gradodocente gd inner join ins_sede s on gd.codsede= s.codigo where gd.identificacion=@identificacion";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
    
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow cargarDatosDocenteAsesor(string codgradodocente)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from lbase_docenteasesor where codgradodocente=@codgradodocente";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public bool actualizarCodDocenteAsesorxDocente(string codigo, string codasesor)
    {
        Conexion conector = new Conexion();
        string consulta = " UPDATE lbase_docenteasesor SET codasesor=@codasesor WHERE codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        conector.AsignarParametroCadena("@codasesor", codasesor);
        return conector.guardadata();
    }

    public bool AgregarRespuestaCerrada(string coddocenteasesor, string codpregunta, string codsubpregunta, string respuesta, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = " INSERT INTO lbase_respuesta (coddocenteasesor,codpregunta,codsubpregunta,respuesta,codinstrumento) VALUES (@coddocenteasesor,@codpregunta,@codsubpregunta,@respuesta,@codinstrumento)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codsubpregunta", codsubpregunta);
        conector.AsignarParametroCadena("@respuesta", respuesta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        return conector.guardadata();
    }

    public bool AgregarRespuestaCerrada_Fase(string coddocenteasesor, string codpregunta, string codsubpregunta, string respuesta, string codinstrumento, string fase)
    {
        Conexion conector = new Conexion();
        string consulta = " INSERT INTO lbase_respuesta (coddocenteasesor,codpregunta,codsubpregunta,respuesta,codinstrumento, fase) VALUES (@coddocenteasesor,@codpregunta,@codsubpregunta,@respuesta,@codinstrumento, @fase)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codsubpregunta", codsubpregunta);
        conector.AsignarParametroCadena("@respuesta", respuesta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@fase", fase);
        return conector.guardadata();
    }

    public bool AgregarRespuestaCerradaInstitucional_Fase(string codinstiasesor, string codpregunta, string codsubpregunta, string respuesta, string codinstrumento, string fase)
    {
        Conexion conector = new Conexion();
        string consulta = " INSERT INTO lbase_respuestainstitucional (codinstiasesor,codpregunta,codsubpregunta,respuesta,codinstrumento, fase) VALUES (@codinstiasesor,@codpregunta,@codsubpregunta,@respuesta,@codinstrumento, @fase)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstiasesor", codinstiasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codsubpregunta", codsubpregunta);
        conector.AsignarParametroCadena("@respuesta", respuesta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@fase", fase);
        return conector.guardadata();
    }

    public bool AgregarRespuestaAbierta(string coddocenteasesor, string codpregunta, string comentario, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = " INSERT INTO lbase_respuestaabierta (codpregunta,comentario,coddocenteasesor,codinstrumento) VALUES (@codpregunta,@comentario,@coddocenteasesor,@codinstrumento)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@comentario", comentario);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        return conector.guardadata();
    }

    public bool AgregarRespuestaAbierta_Fase(string coddocenteasesor, string codpregunta, string comentario, string codinstrumento, string fase)
    {
        Conexion conector = new Conexion();
        string consulta = " INSERT INTO lbase_respuestaabierta (codpregunta,comentario,coddocenteasesor,codinstrumento,fase) VALUES (@codpregunta,@comentario,@coddocenteasesor,@codinstrumento,@fase)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@comentario", comentario);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@fase", fase);
        return conector.guardadata();
    }

    public bool AgregarRespuestaAbiertaInstitucional_Fase(string codinstiasesor, string codpregunta, string comentario, string codinstrumento, string fase)
    {
        Conexion conector = new Conexion();
        string consulta = " INSERT INTO lbase_respuestaabiertainstitucional (codpregunta,comentario,codinstiasesor,codinstrumento,fase) VALUES (@codpregunta,@comentario,@codinstiasesor,@codinstrumento,@fase)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstiasesor", codinstiasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@comentario", comentario);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@fase", fase);
        return conector.guardadata();
    }

    public bool eliminarRespuestaCerrada(string coddocenteasesor, string codpregunta, string codsubpregunta, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM lbase_respuesta WHERE coddocenteasesor=@coddocenteasesor AND codpregunta=@codpregunta AND codsubpregunta=@codsubpregunta AND codinstrumento=@codinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codsubpregunta", codsubpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        return conector.guardadata();
    }
    public bool eliminarRespuestaCerrada_Fase(string coddocenteasesor, string codpregunta, string codsubpregunta, string codinstrumento, string fase)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM lbase_respuesta WHERE coddocenteasesor=@coddocenteasesor AND codpregunta=@codpregunta AND codsubpregunta=@codsubpregunta AND codinstrumento=@codinstrumento and fase=@fase";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codsubpregunta", codsubpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@fase", fase);
        return conector.guardadata();
    }
    public bool eliminarRespuestaCerradaInstitucional_Fase(string codinstiasesor, string codpregunta, string codsubpregunta, string codinstrumento, string fase)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM lbase_respuestainstitucional WHERE codinstiasesor=@codinstiasesor AND codpregunta=@codpregunta AND codsubpregunta=@codsubpregunta AND codinstrumento=@codinstrumento and fase=@fase";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstiasesor", codinstiasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codsubpregunta", codsubpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@fase", fase);
        return conector.guardadata();
    }
    public bool eliminarRespuestaAbierta(string coddocenteasesor, string codpregunta, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM lbase_respuestaabierta WHERE coddocenteasesor=@coddocenteasesor AND codpregunta=@codpregunta AND codinstrumento=@codinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        return conector.guardadata();
    }

    public bool eliminarRespuestaAbierta_Fase(string coddocenteasesor, string codpregunta, string codinstrumento, string fase)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM lbase_respuestaabierta WHERE coddocenteasesor=@coddocenteasesor AND codpregunta=@codpregunta AND codinstrumento=@codinstrumento and fase=@fase";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@fase", fase);
        return conector.guardadata();
    }

    public bool eliminarRespuestaAbiertaInstitucional_Fase(string codinstiasesor, string codpregunta, string codinstrumento, string fase)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM lbase_respuestaabiertainstitucional WHERE codinstiasesor=@codinstiasesor AND codpregunta=@codpregunta AND codinstrumento=@codinstrumento and fase=@fase";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstiasesor", codinstiasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@fase", fase);
        return conector.guardadata();
    }

    public bool editarNomCargoCoordinador(string codigo, string nomcoordinador, string cargo)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE lbase_reginstitucion SET  nomcoordinador = @nomcoordinador,cargo = @cargo WHERE codigo = @codigo ;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        conector.AsignarParametroCadena("@nomcoordinador", nomcoordinador);
        conector.AsignarParametroCadena("@cargo", cargo);
        return conector.guardadata();
    }


    /* Validar intentos de docentes en Linea Base */

    public DataRow buscarDocenteEnSede(string iddocente)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from ins_gradodocente where identificacion=@iddocente";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@iddocente", iddocente);
  
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow buscarIntentosDocente(string codsede, string iddocente, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from lbase_intentos where iddocente=@iddocente and codsede=@codsede and codinstrumento=@codinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@iddocente", iddocente);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public bool agregarIntentosDocente(string codsede, string iddocente, string fechaingreso, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = " INSERT INTO lbase_intentos (codsede,iddocente,fechaingreso,codinstrumento) VALUES (@codsede,@iddocente,@fechaingreso,@codinstrumento)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@iddocente", iddocente);
        conector.AsignarParametroCadena("@fechaingreso", fechaingreso);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        return conector.guardadata();
    }

    /* Carga de respuestas Instrumento Nro 4 */
    public DataTable cargarRespuestasInstrumento04(string coddocenteasesor, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM lbase_respuesta WHERE coddocenteasesor=@coddocenteasesor AND codinstrumento=@codinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
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
    public DataTable cargarRespuestasNumSedesInstrumento04GroupBY(string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "select codsede from lbase_respuesta r left join lbase_reginstitucion rg on r.coddocenteasesor=rg.codigo WHERE codinstrumento=@codinstrumento group by rg.codsede;";
        conector.CrearComando(consulta);
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

    public DataTable cargarRespuestasNumDocentesInstrumento04GroupBY(string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "select codreginstitucion from lbase_respuesta r left join lbase_reginstitucion rg on r.coddocenteasesor=rg.codigo WHERE codinstrumento=@codinstrumento group by r.coddocenteasesor";
        conector.CrearComando(consulta);
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

    public DataTable cargarRespuestasDePreguntasInstrumento04(string coddocenteasesor, string codpregunta, string codsubpregunta, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT respuesta FROM lbase_respuesta WHERE coddocenteasesor=@coddocenteasesor AND codpregunta=@codpregunta AND codsubpregunta=@codsubpregunta AND codinstrumento=@codinstrumento order by codigo asc offset 0 limit 1;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
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

    public DataTable cargarFormacionPerfilDocente(string coddocenteasesor, string codpregunta, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM lbase_perfildocente WHERE coddocenteasesor=@coddocenteasesor AND codpregunta=@codpregunta AND codinstrumento=@codinstrumento order by codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
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

    /* Instrumento Nro 5 */
    public DataTable cargarDocenteXSede(string codsede)
    {
        Conexion conector = new Conexion();
        string consulta = "select gd.cod as codigo, CONCAT_WS(' ',d.identificacion,' - ',d.nombre,d.apellido) as nombre from ins_gradodocente gd inner join ins_docente d on d.identificacion=gd.identificacion where gd.codsede=@codsede";
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

    public bool ActualizarDatosInstitucionalDocente(string codigo, string codgradodocente)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE lbase_reginstitucion SET  codgradodocente = @codgradodocente WHERE codigo = @codigo ;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        return conector.guardadata();
    }

    public bool AgregarRespuestaAbierta(string codpregunta, string coddocenteasesor, string tipo, string nombre, string duracion, string anio, string modalidad, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = " INSERT INTO lbase_perfildocente (codpregunta,coddocenteasesor,tipo,nombre,duracion,anio,modalidad,codinstrumento) VALUES (@codpregunta,@coddocenteasesor,@tipo,@nombre,@duracion,@anio,@modalidad,@codinstrumento)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@tipo", tipo);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@duracion", duracion);
        conector.AsignarParametroCadena("@anio", anio);
        conector.AsignarParametroCadena("@modalidad", modalidad);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        return conector.guardadata();
    }
    // public DataRow agregarDocenteAsesor(string codgradodocente, string codasesor)
    // {
    //     Conexion conector = new Conexion();
    //     string consulta = " INSERT INTO lbase_docenteasesor (codgradodocente,codasesor) VALUES (@codgradodocente,@codasesor) RETURNING codigo";
    //     conector.CrearComando(consulta);
    //     conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
    //     conector.AsignarParametroCadena("@codasesor", codasesor);

    //     DataRow dato = conector.traerfila();
    //     if (dato != null)
    //         return dato;
    //     else
    //         return null;
    // }

    public bool AgregarRespuestaPerfilDocente(string codpregunta, string coddocenteasesor, string tipo, string nombre, string duracion, string anio, string modalidad, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = " INSERT INTO lbase_perfildocente (codpregunta,coddocenteasesor,tipo,nombre,duracion,anio,modalidad,codinstrumento) VALUES (@codpregunta,@coddocenteasesor,@tipo,@nombre,@duracion,@anio,@modalidad,@codinstrumento)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@tipo", tipo);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@duracion", duracion);
        conector.AsignarParametroCadena("@anio", anio);
        conector.AsignarParametroCadena("@modalidad", modalidad);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        return conector.guardadata();
    }

    public bool eliminarRespuestaPerfilDocentes(string coddocenteasesor, string codpregunta, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM lbase_perfildocente WHERE coddocenteasesor=@coddocenteasesor AND codpregunta=@codpregunta AND codinstrumento=@codinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        return conector.guardadata();
    }

   

    public DataRow buscarDocenteInstrumento05(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "select d.codigo from lbase_docenteasesor rg inner join ins_gradodocente gd on rg.codgradodocente=gd.cod inner join ins_docente d on d.identificacion=gd.identificacion where rg.codigo=@cod";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataTable cargarRespuestasCerradasxInstrumento05(string coddocenteasesor, string codpregunta, string codsubpregunta, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "select respuesta from lbase_respuesta where coddocenteasesor=@coddocenteasesor and codpregunta=@codpregunta and codsubpregunta=@codsubpregunta and codinstrumento=@codinstrumento order by codigo asc";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
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
    public DataRow cargarRespuestasAbiertasxIntrumento05(string coddocenteasesor, string codpregunta, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM lbase_respuestaabierta WHERE coddocenteasesor=@coddocenteasesor AND codpregunta=@codpregunta AND codinstrumento=@codinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataTable cargarRespuestasPerfilDocentexInstrumento05(string coddocenteasesor, string codpregunta, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM lbase_perfildocente WHERE coddocenteasesor=@coddocenteasesor AND codpregunta=@codpregunta AND codinstrumento=@codinstrumento order by codigo asc";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
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


    /* Reporte Instrumento 02 */
    public DataRow contarSedesConCurriculo()
    {
        Conexion conector = new Conexion();
        string consulta = "select count(*) from lbase_reginstitucion";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataTable cargarSedesConCurriculo()
    {
        Conexion conector = new Conexion();
        string consulta = "select s.dane,s.nombre from lbase_reginstitucion rg inner join lbase_respuesta r on rg.codigo=r.coddocenteasesor inner join ins_sede s on s.codigo=rg.codsede group by s.nombre, s.dane";
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
    public DataTable cargarSedesEnLineaBase()
    {
        Conexion conector = new Conexion();
        string consulta = "select * from lbase_reginstitucion";
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

    public DataTable cargarRespuestasCerradasxInstrumento02(string coddocenteasesor, string codpregunta, string codsubpregunta, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "select respuesta from lbase_respuesta where coddocenteasesor=@coddocenteasesor and codpregunta=@codpregunta and codsubpregunta=@codsubpregunta and codinstrumento=@codinstrumento ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
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
    public DataTable cargarRespuestasCerradasxInstrumento02_Fase(string coddocenteasesor, string codpregunta, string codsubpregunta, string codinstrumento, string fase)
    {
        Conexion conector = new Conexion();
        string consulta = "select respuesta from lbase_respuesta  where coddocenteasesor=@coddocenteasesor and codpregunta=@codpregunta and codsubpregunta=@codsubpregunta and codinstrumento=@codinstrumento and fase=@fase";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codsubpregunta", codsubpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@fase", fase);
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
    public DataTable cargarRespuestasCerradasInstitucional_Fase(string codinstiasesor, string codpregunta, string codsubpregunta, string codinstrumento, string fase)
    {
        Conexion conector = new Conexion();
        string consulta = "select respuesta from lbase_respuestainstitucional where codinstiasesor=@codinstiasesor and codpregunta=@codpregunta and codsubpregunta=@codsubpregunta and codinstrumento=@codinstrumento and fase=@fase";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstiasesor", codinstiasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codsubpregunta", codsubpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@fase", fase);
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
    public DataTable cargarRespuestasAbiertasxInstrumento02(string coddocenteasesor, string codpregunta, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "select comentario from lbase_respuestaabierta where coddocenteasesor=@coddocenteasesor and codpregunta=@codpregunta and codinstrumento=@codinstrumento ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
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
    public DataTable cargarRespuestasAbiertasxInstrumento02_Fase(string coddocenteasesor, string codpregunta, string codinstrumento, string fase)
    {
        Conexion conector = new Conexion();
        string consulta = "select comentario from lbase_respuestaabierta where coddocenteasesor=@coddocenteasesor and codpregunta=@codpregunta and codinstrumento=@codinstrumento and fase=@fase";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@fase", fase);
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
    public DataTable cargarRespuestasCerradasxInstrumento02GroupBY(string coddocenteasesor, string codpregunta, string codsubpregunta, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "select respuesta from lbase_respuesta where coddocenteasesor=@coddocenteasesor and codpregunta=@codpregunta and codsubpregunta=@codsubpregunta and codinstrumento=@codinstrumento group by respuesta";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
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


    /* Instrumento 06 Estudiantes */
    public DataRow agregarNomProyecto(string nombre, String fechainicio, string fechafin)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO pro_proyecto (nombre, fechainicio,fechafin)  " +
            "VALUES (@nombre,@fechainicio,@fechafin) RETURNING codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@fechainicio", fechainicio);
        conector.AsignarParametroCadena("@fechafin", fechafin);
   
        DataRow dato = conector.guardadataidPG();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow agregarNomProyectoRT(string nombre, String fechainicio, string fechafin)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO rt_redtematica (nombre, fechainicio,fechafin)  " +
            "VALUES (@nombre,@fechainicio,@fechafin) RETURNING codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@fechainicio", fechainicio);
        conector.AsignarParametroCadena("@fechafin", fechafin);

        DataRow dato = conector.guardadataidPG();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow agregarProyectoSede(string codproyecto, String codsede, string codgradodocente)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO pro_proyectosede (codproyecto, codsede, codgradodocente)  " +
            "VALUES (@codproyecto,@codsede,@codgradodocente) RETURNING codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyecto", codproyecto);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);

         DataRow dato = conector.guardadataidPG();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow agregarProyectoSedeRT(string codredtematica, String codsede, string codgradodocente)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO rt_redtematicasede (codredtematica, codsede, codgradodocente)  " +
            "VALUES (@codredtematica,@codsede,@codgradodocente) RETURNING codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codredtematica", codredtematica);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        DataRow dato = conector.guardadataidPG();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public bool agregarProyectoMatricula(string codproyectosede, string codestumatricula)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO pro_proyectomatricula (codproyectosede, codestumatricula)  " +
           "VALUES (@codproyectosede,@codestumatricula);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
        conector.AsignarParametroCadena("@codestumatricula", codestumatricula);
        //conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        return conector.guardadata();
    }

    public bool agregarProyectoMatriculaRT(string codredtematicasede, string codestumatricula)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO rt_redtematicamatricula (codredtematicasede, codestumatricula)  " +
           "VALUES (@codproyectosede,@codestumatricula);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        conector.AsignarParametroCadena("@codestumatricula", codestumatricula);
        //conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        return conector.guardadata();
    }

    public bool eliminarEstudianteXDocente(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM ins_estumatricula WHERE codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();
    }

    public bool AgregarRespuestaPreguntasIntrumento06(string coddocenteasesor, string codpregunta, string codinstrumento, string categoria, string subcategoria, string thombre, string tmujer)
    {
        Conexion conector = new Conexion();

        if(thombre == "" && tmujer == "")
        {
            string consulta = "INSERT INTO lbase_respuestaestudiantes (coddocenteasesor, codpregunta,codinstrumento,categoria,subcategoria,thombre,tmujer)  " +
          "VALUES (@coddocenteasesor, @codpregunta,@codinstrumento,@categoria,@subcategoria,'0','0');";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
            conector.AsignarParametroCadena("@codpregunta", codpregunta);
            conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
            conector.AsignarParametroCadena("@categoria", categoria);
            conector.AsignarParametroCadena("@subcategoria", subcategoria);
        }
        if(thombre == "" && tmujer != "")
        {
            string consulta = "INSERT INTO lbase_respuestaestudiantes (coddocenteasesor, codpregunta,codinstrumento,categoria,subcategoria,thombre,tmujer)  " +
           "VALUES (@coddocenteasesor, @codpregunta,@codinstrumento,@categoria,@subcategoria,'0',@tmujer);";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
            conector.AsignarParametroCadena("@codpregunta", codpregunta);
            conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
            conector.AsignarParametroCadena("@categoria", categoria);
            conector.AsignarParametroCadena("@subcategoria", subcategoria);
            conector.AsignarParametroCadena("@tmujer", tmujer);
        }

        if (thombre != "" && tmujer == "")
        {
            string consulta = "INSERT INTO lbase_respuestaestudiantes (coddocenteasesor, codpregunta,codinstrumento,categoria,subcategoria,thombre,tmujer)  " +
          "VALUES (@coddocenteasesor, @codpregunta,@codinstrumento,@categoria,@subcategoria,@thombre,'0');";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
            conector.AsignarParametroCadena("@codpregunta", codpregunta);
            conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
            conector.AsignarParametroCadena("@categoria", categoria);
            conector.AsignarParametroCadena("@subcategoria", subcategoria);
            conector.AsignarParametroCadena("@thombre", thombre);
        }

        if (thombre != "" && tmujer != "")
        {
            string consulta = "INSERT INTO lbase_respuestaestudiantes (coddocenteasesor, codpregunta,codinstrumento,categoria,subcategoria,thombre,tmujer)  " +
          "VALUES (@coddocenteasesor, @codpregunta,@codinstrumento,@categoria,@subcategoria,@thombre,@tmujer);";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
            conector.AsignarParametroCadena("@codpregunta", codpregunta);
            conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
            conector.AsignarParametroCadena("@categoria", categoria);
            conector.AsignarParametroCadena("@subcategoria", subcategoria);
            conector.AsignarParametroCadena("@thombre", thombre);
            conector.AsignarParametroCadena("@tmujer", tmujer);
        }
       
        return conector.guardadata();
    }

    public DataRow buscarNomProyectoInvestigacionxDocentexSede(string codsede, String codgradodocente)
    {
        Conexion conector = new Conexion();
        string consulta = "select ps.codproyecto as codproyecto,* from pro_proyectosede ps inner join pro_proyecto p on p.codigo=ps.codproyecto where ps.codgradodocente=@codgradodocente and ps.codsede=@codsede limit 1";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscarNomProyectoInvestigacionxDocentexSedeRT(string codsede, String codgradodocente)
    {
        Conexion conector = new Conexion();
        string consulta = "select ps.codredtematica as codredtematicasede,* from rt_redtematicasede ps inner join rt_redtematica p on p.codigo=ps.codredtematica where ps.codgradodocente=@codgradodocente and ps.codsede=@codsede limit 1";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscarNomProyectoInvestigacionxDocentexSedeDeleteRT(string codsede, String codgradodocente)
    {
        Conexion conector = new Conexion();
        string consulta = "select ps.codigo as codproyectosede, p.codigo as codproyecto,* from rt_redtematicasede ps inner join rt_redtematica p on p.codigo=ps.codredtematica where ps.codgradodocente=@codgradodocente and ps.codsede=@codsede limit 1";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
    public DataRow buscarNomProyectoInvestigacionxDocentexSedeDelete(string codsede, String codgradodocente)
    {
        Conexion conector = new Conexion();
        //string consulta = "select pm.codproyectosede as codproyectosede, ps.codproyecto as codproyecto from pro_proyectomatricula pm inner join pro_proyectosede ps on pm.codproyectosede=ps.codigo inner join pro_proyecto p on p.codigo=ps.codproyecto where pm.codgradodocente=@codgradodocente and ps.codsede=@codsede limit 1";
        string consulta = "select ps.codigo as codproyectosede, p.codigo as codproyecto,* from pro_proyectosede ps inner join pro_proyecto p on p.codigo=ps.codproyecto where ps.codgradodocente=@codgradodocente and ps.codsede=@codsede limit 1";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public bool eliminarRespuestasPreguntasInstrumento06(string coddocenteasesor, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM lbase_respuestaestudiantes WHERE coddocenteasesor=@coddocenteasesor AND codinstrumento=@codinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        return conector.guardadata();
    }

    public DataTable cargarRespuestasCerradasInstrumento06(string coddocenteasesor, string codpregunta, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from lbase_respuestaestudiantes where coddocenteasesor=@coddocenteasesor and codpregunta=@codpregunta and codinstrumento=@codinstrumento ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
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

    public bool eliminarEstudiantesxProyectoSede(string codproyectosede, string codestumatricula)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM pro_proyectomatricula WHERE codproyectosede=@codproyectosede AND codestumatricula=@codestumatricula";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyectosede", codproyectosede);
        conector.AsignarParametroCadena("@codestumatricula", codestumatricula);
        //conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        return conector.guardadata();
    }
    public bool eliminarEstudiantesxProyectoSedeRT(string codredtematicasede, string codestumatricula)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM rt_redtematicamatricula WHERE codredtematicasede=@codredtematicasede AND codestumatricula=@codestumatricula ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codredtematicasede", codredtematicasede);
        conector.AsignarParametroCadena("@codestumatricula", codestumatricula);
        //conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        return conector.guardadata();
    }

    public bool eliminarProyectoSede(string codproyecto)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM pro_proyectosede WHERE codproyecto=@codproyecto";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyecto", codproyecto);
        return conector.guardadata();
    }
    public bool eliminarProyectoSedeRT(string codredtematica)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM rt_redtematicasede WHERE codredtematica=@codredtematica";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codredtematica", codredtematica);
        return conector.guardadata();
    }

    public bool eliminarProyecto(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM pro_proyecto WHERE codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();
    }
    public bool eliminarProyectoRT(string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM rt_redtematica WHERE codigo=@codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codigo", codigo);
        return conector.guardadata();
    }

    public DataRow cargarEstudiantesEnProyecto()
    {
        Conexion conector = new Conexion();
        string consulta = "select count(*) from pro_proyectomatricula";
        conector.CrearComando(consulta);

        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow cargarRespuestasEstudiantesInstrumento06(string coddocenteasesor, string codpregunta, string subcategoria, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "select SUM(thombre) as thombre, SUM(tmujer) as tmujer from lbase_respuestaestudiantes where coddocenteasesor=@coddocenteasesor and codpregunta=@codpregunta and subcategoria=@subcategoria and codinstrumento=@codinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@subcategoria", subcategoria);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow buscarValidacionInstrumento(string iddocente, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from lbase_intentos where iddocente=@iddocente and codinstrumento=@codinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@iddocente", iddocente);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
      
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow buscarFechaInstrumento(string codinstrumento, string fechahoy)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from lbase_confinstrumento where (@fechahoy BETWEEN fechainicio AND fechafinal) and codinstrumento=@codinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@fechahoy", fechahoy);

        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow buscarconfiSINOTiempo()
    {
        Conexion conector = new Conexion();
        string consulta = "select tiempoenlineabase from con_configeneral";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public bool ActualizarEstadoTiempoLineaBase(string tiempoenlineabase)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE con_configeneral SET  tiempoenlineabase = @tiempoenlineabase";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@tiempoenlineabase", tiempoenlineabase);
        return conector.guardadata();
    }


    /* Instrumento 03 */

    public bool eliminarRespuestasInstrumento03TICS(string codsedeasesor, string codinstrumento, string codpregunta)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM lbase_equipostics WHERE codsedeasesor=@codsedeasesor AND codinstrumento=@codinstrumento AND codpregunta=@codpregunta";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        return conector.guardadata();
    }

    public bool eliminarRespuestasInstrumento03TICS_Fase(string codsedeasesor, string codinstrumento, string codpregunta, string fase)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM lbase_equipostics WHERE codsedeasesor=@codsedeasesor AND codinstrumento=@codinstrumento AND codpregunta=@codpregunta AND fase=@fase";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@fase", fase);
        return conector.guardadata();
    }

    public bool agregarRespuestaInstrumento03TICS(string codsedeasesor, string codinstrumento, string codpregunta, string nombre, string conpc, string sinpc, string conportatil, string sinportatil, string contablet, string sintablet, string contableros, string sintableros)
    {
        Conexion conector = new Conexion();


        string consulta = "INSERT INTO lbase_equipostics (nombre, conpc,sinpc,conportatil,sinportatil,contablet,sintablet,contableros,sintableros,codsedeasesor,codinstrumento,codpregunta)  " +
          "VALUES (@nombre,@conpc,@sinpc,@conportatil,@sinportatil,@contablet,@sintablet,@contableros,@sintableros,@codsedeasesor,@codinstrumento,@codpregunta);";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
            conector.AsignarParametroCadena("@codpregunta", codpregunta);
            conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
            conector.AsignarParametroCadena("@nombre", nombre);
            conector.AsignarParametroCadena("@conpc", conpc);
            conector.AsignarParametroCadena("@sinpc", sinpc);
            conector.AsignarParametroCadena("@conportatil", conportatil);
            conector.AsignarParametroCadena("@sinportatil", sinportatil);
            conector.AsignarParametroCadena("@contablet", contablet);
            conector.AsignarParametroCadena("@sintablet", sintablet);
            conector.AsignarParametroCadena("@contableros", contableros);
            conector.AsignarParametroCadena("@sintableros", sintableros);
           
         
        return conector.guardadata();
    }

    public bool agregarRespuestaInstrumento03TICS_Fase(string codsedeasesor, string codinstrumento, string codpregunta, string nombre, string conpc, string sinpc, string conportatil, string sinportatil, string contablet, string sintablet, string contableros, string sintableros, string fase)
    {
        Conexion conector = new Conexion();


        string consulta = "INSERT INTO lbase_equipostics (nombre, conpc,sinpc,conportatil,sinportatil,contablet,sintablet,contableros,sintableros,codsedeasesor,codinstrumento,codpregunta,fase)  " +
          "VALUES (@nombre,@conpc,@sinpc,@conportatil,@sinportatil,@contablet,@sintablet,@contableros,@sintableros,@codsedeasesor,@codinstrumento,@codpregunta,@fase);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@conpc", conpc);
        conector.AsignarParametroCadena("@sinpc", sinpc);
        conector.AsignarParametroCadena("@conportatil", conportatil);
        conector.AsignarParametroCadena("@sinportatil", sinportatil);
        conector.AsignarParametroCadena("@contablet", contablet);
        conector.AsignarParametroCadena("@sintablet", sintablet);
        conector.AsignarParametroCadena("@contableros", contableros);
        conector.AsignarParametroCadena("@sintableros", sintableros);
        conector.AsignarParametroCadena("@fase", fase);

        return conector.guardadata();
    }

    public bool eliminarRespuestaInstrumento03TICSPregunta1_2(string codsedeasesor, string codinstrumento, string codpregunta)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM lbase_ubicaequipostics WHERE codsedeasesor=@codsedeasesor AND codinstrumento=@codinstrumento AND codpregunta=@codpregunta";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        return conector.guardadata();
    }

    public bool agregarRespuestaInstrumento03TICSPregunta1_2(string codsedeasesor, string codinstrumento, string codpregunta, string nombre, string ludoteca, string biblioteca, string salones, string aulas, string otros)
    {
        Conexion conector = new Conexion();


        string consulta = "INSERT INTO lbase_ubicaequipostics (nombre, ludoteca,biblioteca,salones,aulas,otros,codsedeasesor,codinstrumento,codpregunta)  " +
      "VALUES (@nombre,@ludoteca,@biblioteca,@salones,@aulas,@otros,@codsedeasesor,@codinstrumento,@codpregunta);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@ludoteca", ludoteca);
        conector.AsignarParametroCadena("@biblioteca", biblioteca);
        conector.AsignarParametroCadena("@salones", salones);
        conector.AsignarParametroCadena("@aulas", aulas);
        conector.AsignarParametroCadena("@otros", otros);
       

        return conector.guardadata();
    }

    public bool eliminarRespuestaInstrumento03SoftEducativo(string codsedeasesor, string codinstrumento, string codpregunta)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM lbase_softeducativo WHERE codsedeasesor=@codsedeasesor AND codinstrumento=@codinstrumento AND codpregunta=@codpregunta";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        return conector.guardadata();
    }

    public bool AgregarRespuestaInstrumento03SoftEducativo(string codsedeasesor, string codpregunta, string codinstrumento, string nombre, string grados, string areas)
    {
        Conexion conector = new Conexion();


        string consulta = "INSERT INTO lbase_softeducativo (nombre,grados,areas,codsedeasesor,codinstrumento,codpregunta)  " +
      "VALUES (@nombre,@grados,@areas,@codsedeasesor,@codinstrumento,@codpregunta);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@grados", grados);
        conector.AsignarParametroCadena("@areas", areas);
          
        return conector.guardadata();
    }

    public bool eliminarRespuestaInstrumento03HerramientasDisponibles(string codsedeasesor, string codinstrumento, string codpregunta)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM lbase_herradisponeie WHERE codsedeasesor=@codsedeasesor AND codinstrumento=@codinstrumento AND codpregunta=@codpregunta";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        return conector.guardadata();
    }

    public bool eliminarRespuestaInstrumento03HerramientasDisponibles_Fase(string codsedeasesor, string codinstrumento, string codpregunta, string fase)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM lbase_herradisponeie WHERE codsedeasesor=@codsedeasesor AND codinstrumento=@codinstrumento AND codpregunta=@codpregunta and fase=@fase";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@fase", fase);
        return conector.guardadata();
    }

    public bool AgregarRespuestaInstrumento03HerramientasDisponibles(string codsedeasesor, string codpregunta, string codinstrumento, string tipo, string direccion)
    {
        Conexion conector = new Conexion();


        string consulta = "INSERT INTO lbase_herradisponeie (tipo, direccion,codsedeasesor,codpregunta,codinstrumento)  " +
      "VALUES (@tipo,@direccion,@codsedeasesor,@codpregunta,@codinstrumento);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@tipo", tipo);
        conector.AsignarParametroCadena("@direccion", direccion);

        return conector.guardadata();
    }

    public bool AgregarRespuestaInstrumento03HerramientasDisponibles_Fase(string codsedeasesor, string codpregunta, string codinstrumento, string tipo, string direccion, string fase)
    {
        Conexion conector = new Conexion();


        string consulta = "INSERT INTO lbase_herradisponeie (tipo, direccion,codsedeasesor,codpregunta,codinstrumento, fase)  " +
      "VALUES (@tipo,@direccion,@codsedeasesor,@codpregunta,@codinstrumento,@fase);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@tipo", tipo);
        conector.AsignarParametroCadena("@direccion", direccion);
        conector.AsignarParametroCadena("@fase", fase);
        return conector.guardadata();
    }

    public DataTable RespuestaInstrumento03UbicaTICS(string coddocenteasesor, string codinstrumento, string codpregunta)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from lbase_ubicaequipostics where coddocenteasesor=@coddocenteasesor and codpregunta=@codpregunta and codinstrumento=@codinstrumento ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
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

    public DataTable RespuestaInstrumento03TICS(string codsedeasesor, string codinstrumento, string codpregunta)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from lbase_equipostics where codsedeasesor=@codsedeasesor and codpregunta=@codpregunta and codinstrumento=@codinstrumento ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
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

    public DataTable RespuestaInstrumento03TICS_Fase(string codsedeasesor, string codinstrumento, string codpregunta, string fase)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from lbase_equipostics where fase=@fase and codsedeasesor=@codsedeasesor and codpregunta=@codpregunta and codinstrumento=@codinstrumento ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@fase", fase);
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

    public DataTable cargarRespuestasCerradasxInstrumento03(string coddocenteasesor, string codpregunta, string codsubpregunta, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "select respuesta from lbase_respuesta where coddocenteasesor=@coddocenteasesor and codpregunta=@codpregunta and codsubpregunta=@codsubpregunta and codinstrumento=@codinstrumento ORDER BY codigo ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
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

    public DataTable RespuestasInstrumento03UbicacionTICS(string codsedeasesor, string codinstrumento, string codpregunta)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from lbase_ubicaequipostics where codsedeasesor=@codsedeasesor and codpregunta=@codpregunta and codinstrumento=@codinstrumento ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
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

    public DataTable RespuestasInstrumento03SoftEducativo(string codsedeasesor, string codinstrumento, string codpregunta)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from lbase_softeducativo where codsedeasesor=@codsedeasesor and codpregunta=@codpregunta and codinstrumento=@codinstrumento ORDER BY codigo ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
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

    public DataTable RespuestasInstrumento03HerramientasDispone(string codsedeasesor, string codinstrumento, string codpregunta)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from lbase_herradisponeie where codsedeasesor=@codsedeasesor and codpregunta=@codpregunta and codinstrumento=@codinstrumento ORDER BY codigo ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
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

    public DataTable RespuestasInstrumento03HerramientasDispone_Fase(string codsedeasesor, string codinstrumento, string codpregunta, string fase)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from lbase_herradisponeie where codsedeasesor=@codsedeasesor and codpregunta=@codpregunta and codinstrumento=@codinstrumento and fase=@fase ORDER BY codigo ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@fase", fase);
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

    //Instrumento 001A

    public bool AgregarRespuestaPreguntasIntrumento001A(string codinsasesor, string codpregunta, string codinstrumento, string categoria, string subcategoria, string thombre, string tmujer)
    {
        Conexion conector = new Conexion();

        if (thombre == "" && tmujer == "")
        {
            string consulta = "INSERT INTO lbase_respuestainstitucionalrh (codinsasesor, codpregunta,codinstrumento,categoria,subcategoria,thombre,tmujer)  " +
          "VALUES (@codinsasesor, @codpregunta,@codinstrumento,@categoria,@subcategoria,'0','0');";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@codinsasesor", codinsasesor);
            conector.AsignarParametroCadena("@codpregunta", codpregunta);
            conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
            conector.AsignarParametroCadena("@categoria", categoria);
            conector.AsignarParametroCadena("@subcategoria", subcategoria);
        }
        if (thombre == "" && tmujer != "")
        {
            string consulta = "INSERT INTO lbase_respuestainstitucionalrh (codinsasesor, codpregunta,codinstrumento,categoria,subcategoria,thombre,tmujer)  " +
           "VALUES (@codinsasesor, @codpregunta,@codinstrumento,@categoria,@subcategoria,'0',@tmujer);";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@codinsasesor", codinsasesor);
            conector.AsignarParametroCadena("@codpregunta", codpregunta);
            conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
            conector.AsignarParametroCadena("@categoria", categoria);
            conector.AsignarParametroCadena("@subcategoria", subcategoria);
            conector.AsignarParametroCadena("@tmujer", tmujer);
        }

        if (thombre != "" && tmujer == "")
        {
            string consulta = "INSERT INTO lbase_respuestainstitucionalrh (codinsasesor, codpregunta,codinstrumento,categoria,subcategoria,thombre,tmujer)  " +
          "VALUES (@codinsasesor, @codpregunta,@codinstrumento,@categoria,@subcategoria,@thombre,'0');";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@codinsasesor", codinsasesor);
            conector.AsignarParametroCadena("@codpregunta", codpregunta);
            conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
            conector.AsignarParametroCadena("@categoria", categoria);
            conector.AsignarParametroCadena("@subcategoria", subcategoria);
            conector.AsignarParametroCadena("@thombre", thombre);
        }

        if (thombre != "" && tmujer != "")
        {
            string consulta = "INSERT INTO lbase_respuestainstitucionalrh (codinsasesor, codpregunta,codinstrumento,categoria,subcategoria,thombre,tmujer)  " +
          "VALUES (@codinsasesor, @codpregunta,@codinstrumento,@categoria,@subcategoria,@thombre,@tmujer);";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@codinsasesor", codinsasesor);
            conector.AsignarParametroCadena("@codpregunta", codpregunta);
            conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
            conector.AsignarParametroCadena("@categoria", categoria);
            conector.AsignarParametroCadena("@subcategoria", subcategoria);
            conector.AsignarParametroCadena("@thombre", thombre);
            conector.AsignarParametroCadena("@tmujer", tmujer);
        }

        return conector.guardadata();
    }
    public bool eliminarRespuestasPreguntasInstrumento001A(string codinsasesor, string codinstrumento, string codpregunta)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM lbase_respuestainstitucionalrh WHERE codinsasesor=@codinsasesor AND codpregunta=@codpregunta AND codinstrumento=@codinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinsasesor", codinsasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        return conector.guardadata();
    }
    public DataRow AgregarDatoInstitucionAsesorLineaBase(string codinstitucion, string codasesor)
    {
        Conexion conector = new Conexion();


        string consulta = "INSERT INTO lbase_institucionasesor (codinstitucion, codasesor)  " +
      "VALUES (@codinstitucion,@codasesor) returning codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstitucion", codinstitucion);
        conector.AsignarParametroCadena("@codasesor", codasesor);
        DataRow dato = conector.guardadataidPG();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow AgregarDatoDocenteAsesorLineaBase(string codasesor, string codgradodocente)
    {
        Conexion conector = new Conexion();


        string consulta = "INSERT INTO lbase_docenteasesor (codgradodocente, codasesor)  " +
      "VALUES (@codgradodocente,@codasesor) returning codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        conector.AsignarParametroCadena("@codasesor", codasesor);
        DataRow dato = conector.guardadataidPG();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow buscarCodDocenteAsesorxDocente(string codgradodocente)
    {
        Conexion conector = new Conexion();


        string consulta = "SELECT * FROM lbase_docenteasesor WHERE codgradodocente=@codgradodocente ;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        
        DataRow dato = conector.guardadataidPG();
        if (dato != null)
            return dato;
        else
            return null;
    }

   
    public DataRow buscarInstitucionxAsesor(string codinstitucion)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from lbase_institucionasesor WHERE codinstitucion=@codinstitucion";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstitucion", codinstitucion);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public bool AgregarRespuestaCerradaInstitucional(string codinstiasesor, string codpregunta, string respuesta, string codinstrumento, string codsubpregunta)
    {
        Conexion conector = new Conexion();
        string consulta = " INSERT INTO lbase_respuestainstitucional (codinstiasesor,codpregunta,respuesta,codinstrumento,codsubpregunta) VALUES (@codinstiasesor,@codpregunta,@respuesta,@codinstrumento,@codsubpregunta)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstiasesor", codinstiasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@respuesta", respuesta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@codsubpregunta", codsubpregunta);
        return conector.guardadata();
    }

    public bool AgregarRespuestaAbiertaInstitucional(string codinstiasesor, string codpregunta, string comentario, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = " INSERT INTO lbase_respuestaabiertainstitucional (codinstiasesor,codpregunta,comentario,codinstrumento) VALUES (@codinstiasesor,@codpregunta,@comentario,@codinstrumento)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstiasesor", codinstiasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@comentario", comentario);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        return conector.guardadata();
    }

    public bool eliminarRespuestaCerradaInstitucional(string codinstiasesor, string codpregunta, string codinstrumento, string codsubpregunta)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM lbase_respuestainstitucional WHERE codinstiasesor=@codinstiasesor AND codpregunta=@codpregunta AND codinstrumento=@codinstrumento AND codsubpregunta=@codsubpregunta";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstiasesor", codinstiasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@codsubpregunta", codsubpregunta);
        return conector.guardadata();
    }
    public bool eliminarRespuestaAbiertaInstitucional(string codinstiasesor, string codpregunta, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM lbase_respuestaabiertainstitucional WHERE codinstiasesor=@codinstiasesor AND codpregunta=@codpregunta AND codinstrumento=@codinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstiasesor", codinstiasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        return conector.guardadata();
    }



    public bool AgregarRespuestaCerradaSede(string codsedeasesor, string codpregunta, string respuesta, string codinstrumento, string codsubpregunta)
    {
        Conexion conector = new Conexion();
        string consulta = " INSERT INTO lbase_respuestasede (codsedeasesor,codpregunta,respuesta,codinstrumento,codsubpregunta) VALUES (@codsedeasesor,@codpregunta,@respuesta,@codinstrumento,@codsubpregunta)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@respuesta", respuesta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@codsubpregunta", codsubpregunta);
        return conector.guardadata();
    }

    public bool AgregarRespuestaCerradaSede_Fase(string codsedeasesor, string codpregunta, string respuesta, string codinstrumento, string codsubpregunta, string fase)
    {
        Conexion conector = new Conexion();
        string consulta = " INSERT INTO lbase_respuestasede (codsedeasesor,codpregunta,respuesta,codinstrumento,codsubpregunta,fase) VALUES (@codsedeasesor,@codpregunta,@respuesta,@codinstrumento,@codsubpregunta,@fase)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@respuesta", respuesta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@codsubpregunta", codsubpregunta);
        conector.AsignarParametroCadena("@fase", fase);
        return conector.guardadata();
    }

    public bool AgregarRespuestaAbiertaSede(string codsedeasesor, string codpregunta, string comentario, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = " INSERT INTO lbase_respuestaabiertasede (codsedeasesor,codpregunta,comentario,codinstrumento) VALUES (@codsedeasesor,@codpregunta,@comentario,@codinstrumento)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@comentario", comentario);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        return conector.guardadata();
    }

    public bool AgregarRespuestaAbiertaSede_Fase(string codsedeasesor, string codpregunta, string comentario, string codinstrumento, string fase)
    {
        Conexion conector = new Conexion();
        string consulta = " INSERT INTO lbase_respuestaabiertasede (codsedeasesor,codpregunta,comentario,codinstrumento,fase) VALUES (@codsedeasesor,@codpregunta,@comentario,@codinstrumento,@fase)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@comentario", comentario);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@fase", fase);
        return conector.guardadata();
    }

    public bool eliminarRespuestaCerradaSede(string codsedeasesor, string codpregunta, string codinstrumento, string codsubpregunta)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM lbase_respuestasede WHERE codsedeasesor=@codsedeasesor AND codpregunta=@codpregunta AND codinstrumento=@codinstrumento AND codsubpregunta=@codsubpregunta";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@codsubpregunta", codsubpregunta);
        return conector.guardadata();
    }
    public bool eliminarRespuestaCerradaSede_Fase(string codsedeasesor, string codpregunta, string codinstrumento, string codsubpregunta, string fase)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM lbase_respuestasede WHERE codsedeasesor=@codsedeasesor AND codpregunta=@codpregunta AND codinstrumento=@codinstrumento AND codsubpregunta=@codsubpregunta AND fase=@fase";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@codsubpregunta", codsubpregunta);
        conector.AsignarParametroCadena("@fase", fase);
        return conector.guardadata();
    }
    public bool eliminarRespuestaCerradaSedeGeneros(string codsedeasesor, string codpregunta, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM lbase_respuestasedesgeneros WHERE codsedeasesor=@codsedeasesor AND codpregunta=@codpregunta AND codinstrumento=@codinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);

        return conector.guardadata();
    }
    public bool eliminarRespuestaAbiertaSede(string codsedeasesor, string codpregunta, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM lbase_respuestaabiertasede WHERE codsedeasesor=@codsedeasesor AND codpregunta=@codpregunta AND codinstrumento=@codinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        return conector.guardadata();
    }

    public bool eliminarRespuestaAbiertaSede_Fase(string codsedeasesor, string codpregunta, string codinstrumento, string fase)
    {
        Conexion conector = new Conexion();
        string consulta = "  DELETE FROM lbase_respuestaabiertasede WHERE codsedeasesor=@codsedeasesor AND codpregunta=@codpregunta AND codinstrumento=@codinstrumento AND fase=@fase";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@fase", fase);
        return conector.guardadata();
    }

    public DataTable cargarRespuestasCerradasInstrumento001A(string codinstiasesor, string codpregunta, string codsubpregunta, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM lbase_respuestainstitucional WHERE codinstiasesor=@codinstiasesor AND codpregunta=@codpregunta AND codsubpregunta=@codsubpregunta AND codinstrumento=@codinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstiasesor", codinstiasesor);
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

    public DataRow buscarRespuestaAbiertaInstrumento001A(string codinstiasesor, string codpregunta, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from lbase_respuestaabiertainstitucional WHERE codinstiasesor=@codinstiasesor AND codpregunta=@codpregunta AND codinstrumento=@codinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstiasesor", codinstiasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow buscarRespuestaAbiertaInstitucional_Fase(string codinstiasesor, string codpregunta, string codinstrumento, string fase)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from lbase_respuestaabiertainstitucional WHERE fase=@fase AND codinstiasesor=@codinstiasesor AND codpregunta=@codpregunta AND codinstrumento=@codinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstiasesor", codinstiasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@fase", fase);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow buscarRespuestaInstitucional_Fase(string codinstiasesor, string codpregunta, string codsubpregunta, string codinstrumento, string fase)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from lbase_respuestainstitucional WHERE fase=@fase AND codinstiasesor=@codinstiasesor AND codpregunta=@codpregunta and codsubpregunta=@codsubpregunta AND codinstrumento=@codinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstiasesor", codinstiasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@fase", fase);
        conector.AsignarParametroCadena("@codsubpregunta", codsubpregunta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataRow cargarRespuestaInstitucionalRecursosH(string codinsasesor, string codpregunta, string codinstrumento, string categoria, string subcategoria)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from lbase_respuestainstitucionalrh WHERE codinsasesor=@codinsasesor AND codpregunta=@codpregunta AND codinstrumento=@codinstrumento AND categoria=@categoria AND subcategoria=@subcategoria";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinsasesor", codinsasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@categoria", categoria);
        conector.AsignarParametroCadena("@subcategoria", subcategoria);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataRow buscarSedexInsasesor(string codsede)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from lbase_sedeasesor WHERE codsede=@codsede";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow agregarSedeInsasesor(string codsede, string codinsasesor)
    {
        Conexion conector = new Conexion();


        string consulta = "INSERT INTO lbase_sedeasesor (codsede, codinsasesor)  " +
      "VALUES (@codsede,@codinsasesor) returning codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@codinsasesor", codinsasesor);
        DataRow dato = conector.guardadataidPG();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public bool AgregarRespuestaPreguntasIntrumentoC600B(string codsedeasesor, string codpregunta, string codinstrumento, string categoria, string subcategoria, string thombre, string tmujer)
    {
        Conexion conector = new Conexion();

        if (thombre == "" && tmujer == "")
        {
            string consulta = "INSERT INTO lbase_respuestasedesgeneros (codsedeasesor, codpregunta,codinstrumento,categoria,subcategoria,thombre,tmujer)  " +
          "VALUES (@codsedeasesor, @codpregunta,@codinstrumento,@categoria,@subcategoria,'0','0');";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
            conector.AsignarParametroCadena("@codpregunta", codpregunta);
            conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
            conector.AsignarParametroCadena("@categoria", categoria);
            conector.AsignarParametroCadena("@subcategoria", subcategoria);
        }
        if (thombre == "" && tmujer != "")
        {
            string consulta = "INSERT INTO lbase_respuestasedesgeneros (codsedeasesor, codpregunta,codinstrumento,categoria,subcategoria,thombre,tmujer)  " +
           "VALUES (@codsedeasesor, @codpregunta,@codinstrumento,@categoria,@subcategoria,'0',@tmujer);";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
            conector.AsignarParametroCadena("@codpregunta", codpregunta);
            conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
            conector.AsignarParametroCadena("@categoria", categoria);
            conector.AsignarParametroCadena("@subcategoria", subcategoria);
            conector.AsignarParametroCadena("@tmujer", tmujer);
        }

        if (thombre != "" && tmujer == "")
        {
            string consulta = "INSERT INTO lbase_respuestasedesgeneros (codsedeasesor, codpregunta,codinstrumento,categoria,subcategoria,thombre,tmujer)  " +
          "VALUES (@codsedeasesor, @codpregunta,@codinstrumento,@categoria,@subcategoria,@thombre,'0');";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
            conector.AsignarParametroCadena("@codpregunta", codpregunta);
            conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
            conector.AsignarParametroCadena("@categoria", categoria);
            conector.AsignarParametroCadena("@subcategoria", subcategoria);
            conector.AsignarParametroCadena("@thombre", thombre);
        }

        if (thombre != "" && tmujer != "")
        {
            string consulta = "INSERT INTO lbase_respuestasedesgeneros (codsedeasesor, codpregunta,codinstrumento,categoria,subcategoria,thombre,tmujer)  " +
          "VALUES (@codsedeasesor, @codpregunta,@codinstrumento,@categoria,@subcategoria,@thombre,@tmujer);";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
            conector.AsignarParametroCadena("@codpregunta", codpregunta);
            conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
            conector.AsignarParametroCadena("@categoria", categoria);
            conector.AsignarParametroCadena("@subcategoria", subcategoria);
            conector.AsignarParametroCadena("@thombre", thombre);
            conector.AsignarParametroCadena("@tmujer", tmujer);
        }

        return conector.guardadata();
    }


    public DataTable cargarRespuestasCerradasInstrumentoC600B(string codsedeasesor, string codpregunta, string codsubpregunta, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM lbase_respuestasede WHERE codsedeasesor=@codsedeasesor AND codpregunta=@codpregunta AND codsubpregunta=@codsubpregunta AND codinstrumento=@codinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
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

    public DataRow cargarRespuestaAbiertaInstrumentoC600B(string codsedeasesor, string codpregunta, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from lbase_respuestaabiertasede WHERE codsedeasesor=@codsedeasesor AND codpregunta=@codpregunta AND codinstrumento=@codinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataTable cargarRespuestaAbierta_Fase(string codsedeasesor, string codpregunta, string codinstrumento, string fase)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from lbase_respuestaabiertasede WHERE codsedeasesor=@codsedeasesor AND codpregunta=@codpregunta AND codinstrumento=@codinstrumento and fase=@fase";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@fase", fase);
        DataTable dato = conector.traerdata();
        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataRow cargarRespuestaSedesGeneros(string codsedeasesor, string codpregunta, string codinstrumento, string categoria, string subcategoria)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from lbase_respuestasedesgeneros WHERE codsedeasesor=@codsedeasesor AND codpregunta=@codpregunta AND codinstrumento=@codinstrumento AND categoria=@categoria AND subcategoria=@subcategoria";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@categoria", categoria);
        conector.AsignarParametroCadena("@subcategoria", subcategoria);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


    public bool editarDatosRector(string codtipodocumento, string identificacion, string nombre, string apellido, string sexo, string fecha_nacimiento, string telefono, string celular, string email, string codigo)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE ins_rector SET  codtipodocumento = @codtipodocumento,identificacion = @identificacion ,nombre = @nombre, apellido = @apellido, sexo = @sexo, fecha_nacimiento=@fecha_nacimiento, telefono = @telefono, celular = @celular,email=@email where codigo=@codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codtipodocumento", codtipodocumento);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@apellido", apellido);
        conector.AsignarParametroCadena("@sexo", sexo);
        conector.AsignarParametroCadena("@fecha_nacimiento", fecha_nacimiento);

        conector.AsignarParametroCadena("@telefono", telefono);
        conector.AsignarParametroCadena("@celular", celular);
        conector.AsignarParametroCadena("@email", email);
        conector.AsignarParametroCadena("@codigo", codigo);
            
        return conector.guardadata();
    }

    /* REPORTES */

    public DataRow contarSedesIntrumento01()
    {
        Conexion conector = new Conexion();
        string consulta = "select count(*) as contsedes from lbase_sedeasesor ";
        conector.CrearComando(consulta);
 
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataTable cargarSedesxJornadaEscolar()
    {
        Conexion conector = new Conexion();
        string consulta = "select * from lbase_respuestasede where codinstrumento='01' and codpregunta='4' and codsubpregunta='0'";
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

    public DataTable cargarGrupoInvestigacionxSede(string dane)
    {
        Conexion conector = new Conexion();
        string consulta = "select p.codigo as codproyecto, p.nombre as nombreproyecto  from pro_proyectosede ps inner join ins_sede s on ps.codsede=s.codigo inner join pro_proyecto p on p.codigo=ps.codproyecto where s.dane=@dane group by p.codigo,p.nombre";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@dane", dane);
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

    public DataTable cargarRedTematicaxSede(string dane)
    {
        Conexion conector = new Conexion();
        string consulta = "select r.codigo as codredtematica, r.nombre as nombreredtematica  from rt_redtematicasede rs inner join ins_sede s on rs.codsede=s.codigo inner join rt_redtematica r on r.codigo=rs.codredtematica where s.dane=@dane group by r.codigo,r.nombre";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@dane", dane);
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

    public DataRow buscarProyectoxDocente(string codgradodocente, string codproyecto)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from pro_proyectosede where codproyecto=@codproyecto and codgradodocente=@codgradodocente ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyecto", codproyecto);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public bool editarDatoProyectoSede(string codproyecto, string codgradodocente)
    {
        Conexion conector = new Conexion();
        string consulta = "  UPDATE pro_proyectosede SET codproyecto=@codproyecto  WHERE codgradodocente=@codgradodocente";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codproyecto", codproyecto);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        return conector.guardadata();
    }

    public DataRow buscarProyectoxDocenteRT(string codredtematica, string codgradodocente)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from rt_redtematicasede where codredtematica=@codredtematica and codgradodocente=@codgradodocente ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codredtematica", codredtematica);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public bool editarDatoProyectoSedeRT(string codredtematica, string codgradodocente)
    {
        Conexion conector = new Conexion();
        string consulta = "  UPDATE rt_redtematicasede SET codredtematica=@codredtematica  WHERE codgradodocente=@codgradodocente";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codredtematica", codredtematica);
        conector.AsignarParametroCadena("@codgradodocente", codgradodocente);
        return conector.guardadata();
    }

    public DataRow contarRectoresInvolucrados()
    {
        Conexion conector = new Conexion();
        string consulta = "select count(*) from lbase_institucionasesor ";
        conector.CrearComando(consulta);

        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow contarCoordinadoresInvolucradas()
    {
        Conexion conector = new Conexion();
        string consulta = "select count(*) from lbase_sedeasesor ";
        conector.CrearComando(consulta);

        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow contarDocentesInvolucrados()
    {
        Conexion conector = new Conexion();
        string consulta = "select count(*) from lbase_docenteasesor ";
        conector.CrearComando(consulta);

        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataTable cargarAsesores()
    {
        Conexion conector = new Conexion();
        string consulta = "select *  from ins_asesor";
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

    public DataTable cargarSedesxInstitucionxAsesor(string codasesor)
    {
        Conexion conector = new Conexion();
        string consulta = "select *  from lbase_institucionasesor where codasesor=@codasesor";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesor", codasesor);
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

    public DataRow contarRectoresInvolucradosxAsesor(string codasesor)
    {
        Conexion conector = new Conexion();
        string consulta = "select count(*) from lbase_institucionasesor where codasesor=@codasesor";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesor", codasesor);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow cargarSedexInsAsesor(string codinsasesor)
    {
        Conexion conector = new Conexion();
        string consulta = "select count(*) from lbase_sedeasesor where codinsasesor=@codinsasesor";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinsasesor", codinsasesor);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow contarDocentesInvolucradosxAsesor(string codasesor)
    {
        Conexion conector = new Conexion();
        string consulta = "select count(*) from lbase_docenteasesor where codasesor=@codasesor ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesor", codasesor);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
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


    public DataTable cargarSedesxEnfasisPEI()
    {
        Conexion conector = new Conexion();
        string consulta = "select count(*) as total, ri.respuesta from lbase_respuestainstitucional ri inner join lbase_institucionasesor ia on ri.codinstiasesor=ia.codigo left join ins_sede s on s.codinstitucion=ia.codinstitucion where codpregunta='1' and codsubpregunta='0' and codinstrumento='02' AND fase is null group by respuesta";
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

    public DataTable cargarSedesxMunicipioDiligenciandoForm()
    {
        Conexion conector = new Conexion();
        string consulta = "select s.nombre, s.dane, m.nombre as municipio from lbase_respuestainstitucional ri inner join lbase_institucionasesor ia on ri.codinstiasesor=ia.codigo left join ins_sede s on s.codinstitucion=ia.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio where ri.codinstrumento='001' and ri.codpregunta='1' and ri.codsubpregunta='0' AND fase is null group by s.nombre, s.dane, m.nombre order by m.nombre ASC";
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

    public DataTable cargarSedesxModeloEducativo()
    {
        Conexion conector = new Conexion();
        //string consulta = "select ri.respuesta, s.codigo from lbase_respuestainstitucional ri inner join lbase_institucionasesor ia on ri.codinstiasesor=ia.codigo left join ins_sede s on s.codinstitucion=ia.codinstitucion where codpregunta='2' and codsubpregunta='0' and codinstrumento='02' group by ri.respuesta, s.codigo";
        string consulta = "select m.cod,m.nombre, ri.respuesta, s.codigo from lbase_respuestainstitucional ri inner join lbase_institucionasesor ia on ri.codinstiasesor=ia.codigo left join ins_sede s on s.codinstitucion=ia.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio where codpregunta='2' and codsubpregunta='0' and codinstrumento='02' AND fase is null group by ri.respuesta, s.codigo, m.nombre,m.cod order by m.nombre, ri.respuesta asc";

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

    public DataTable cargarReportePreguntasCerradas(string codpregunta, string codsubpregunta, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "select ri.respuesta, s.codigo from lbase_respuestainstitucional ri inner join lbase_institucionasesor ia on ri.codinstiasesor=ia.codigo left join ins_sede s on s.codinstitucion=ia.codinstitucion where codpregunta=@codpregunta and codsubpregunta=@codsubpregunta and codinstrumento=@codinstrumento AND fase is null group by ri.respuesta, s.codigo";
        conector.CrearComando(consulta);
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

    public DataTable cargarSedesxMunicipioEquipamiento()
    {
        Conexion conector = new Conexion();
        string consulta = "select distinct(sa.codsede), m.nombre as municipio, s.nombre as nomsede from lbase_equipostics et inner join lbase_sedeasesor sa on sa.codigo=codsedeasesor inner join ins_sede s on s.codigo=sa.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio where et.codinstrumento='3' and et.codpregunta='1.1' AND fase is null order by m.nombre ASC";
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

    public DataTable cargarEquiposInformaticosXSedes(string codinstrumeto, string codpregunta)
    {
        Conexion conector = new Conexion();
        string consulta = "select m.nombre as municipio, s.codigo, s.nombre as nomsede, et.nombre as respuesta,sum(et.conpc) as conpc, sum(et.sinpc) as sinpc, sum(et.conportatil) as conportatil, sum(et.sinportatil) as sinportatil,sum(et.contablet) as contablet,sum(et.sintablet) as sintablet,sum(et.contableros) as contableros,sum(et.sintableros) as sintableros from lbase_equipostics et inner join lbase_sedeasesor sa on sa.codigo=codsedeasesor inner join ins_sede s on s.codigo=sa.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio where et.codinstrumento=@codinstrumeto and et.codpregunta=@codpregunta AND fase is null group by m.nombre, s.nombre, s.codigo, et.nombre order by m.nombre ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstrumeto", codinstrumeto);
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

    public DataTable cargarSedesConSoftwareEducativo()
    {
        Conexion conector = new Conexion();
        string consulta = "select se.nombre, s.nombre as nomsede, m.nombre as municipio from lbase_softeducativo se inner join lbase_sedeasesor sa on sa.codigo=codsedeasesor inner join ins_sede s on s.codigo=sa.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio where se.nombre!='' and se.nombre!='N/A' and se.nombre!='NO' and se.nombre!='no' and se.nombre!='NO APLICA' and se.nombre!='no aplica' and se.nombre!='NA' and se.nombre!='No' and se.nombre!='no hay' and se.nombre!='0' and se.nombre!='00' and se.nombre!='no apliaca' group by s.nombre, m.nombre, se.nombre;";
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

    public DataTable cargarSedesSinSoftwareEducativo()
    {
        Conexion conector = new Conexion();
        string consulta = "select se.nombre, se.codsedeasesor, s.nombre as nomsede, m.nombre as municipio from lbase_softeducativo se inner join lbase_sedeasesor sa on sa.codigo=codsedeasesor inner join ins_sede s on s.codigo=sa.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio where se.nombre!='' and se.nombre!='N/A' and se.nombre!='NO' and se.nombre!='no' and se.nombre!='NO APLICA' and se.nombre!='no aplica' and se.nombre!='NA' and se.nombre!='No' and se.nombre!='no hay' and se.nombre!='0' and se.nombre!='00' group by se.codsedeasesor, s.nombre, m.nombre, se.nombre order by codsedeasesor";
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

    public DataTable SedesxUbicacion()
    {
        Conexion conector = new Conexion();
        string consulta = "select se.nombre, se.codsedeasesor, s.nombre as nomsede, m.nombre as municipio from lbase_softeducativo se inner join lbase_sedeasesor sa on sa.codigo=codsedeasesor inner join ins_sede s on s.codigo=sa.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio where se.nombre!='' and se.nombre!='N/A' and se.nombre!='NO' and se.nombre!='no' and se.nombre!='NO APLICA' and se.nombre!='no aplica' and se.nombre!='NA' and se.nombre!='No' and se.nombre!='no hay' and se.nombre!='0' and se.nombre!='00' group by se.codsedeasesor, s.nombre, m.nombre, se.nombre order by codsedeasesor";
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

    public DataTable SedesxHerramientaWeb()
    {
        Conexion conectar = new Conexion();
        string consulta = "select * from lbase_herradisponeie where tipo != 'N/A' AND fase is null ";
        conectar.CrearComando(consulta);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable SedesxFormacionDocenteUsoTIC()
    {
        Conexion conectar = new Conexion();
        string consulta = "select lbras.*, s.nombre sede, i.nombre institucion, m.nombre municipio from lbase_respuestaabiertasede lbras inner join lbase_sedeasesor lbsa on lbsa.codigo = lbras.codsedeasesor inner join ins_sede s on s.codigo = lbsa.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio where lbras.comentario != '0' and lbras.comentario != 'no' and lbras.comentario != 'no aplica' and lbras.comentario != 'NO APLICA' and lbras.comentario != 'no tengo información de eso' and lbras.comentario != 'N/A' and lbras.comentario != 'NA' and lbras.codinstrumento = '3' and lbras.codpregunta = '211' AND fase is null group by s.nombre, lbras.codigo, lbras.codsedeasesor, lbras.codpregunta, lbras.comentario, lbras.codinstrumento, i.nombre, m.nombre ";
        conectar.CrearComando(consulta);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable SedesxFormacionDocenteUsoTIC_NA()
    {
        Conexion conectar = new Conexion();
        string consulta = "select ss.nombre sede, i.nombre institucion, m.nombre municipio from ins_sede ss inner join ins_institucion i on i.codigo=ss.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio where not exists (select 1 from lbase_respuestaabiertasede lbras inner join lbase_sedeasesor lbsa on lbsa.codigo = lbras.codsedeasesor inner join ins_sede s on s.codigo = lbsa.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio where lbras.comentario != '0' and lbras.comentario != 'no' and lbras.comentario != 'no aplica' and lbras.comentario != 'NO APLICA' and lbras.comentario != 'no tengo información de eso' and lbras.comentario != 'N/A' and lbras.comentario != 'NA' and lbras.codinstrumento = '3' and lbras.codpregunta = '211' AND fase is null and ss.codigo=s.codigo group by s.nombre, lbras.codigo, lbras.codsedeasesor, lbras.codpregunta, lbras.comentario, lbras.codinstrumento, i.nombre, m.nombre )";
        conectar.CrearComando(consulta);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable SedesxPlanMejoramientoTIC()
    {
        Conexion conectar = new Conexion();
        string consulta = "select lbras.*, s.nombre sede, i.nombre institucion, m.nombre municipio from lbase_respuestaabiertasede lbras inner join lbase_sedeasesor lbsa on lbsa.codigo = lbras.codsedeasesor inner join ins_sede s on s.codigo = lbsa.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio where lbras.comentario != 'no se han incluido' and lbras.comentario != 'NO HAN INCLUIDO' and lbras.comentario != 'no se han incluido propuestas de mejoramiento' and lbras.comentario != '0' and lbras.comentario != 'ninguno' and lbras.comentario != 'Ningunos' and lbras.comentario != 'ningun'  and lbras.comentario != 'no' and lbras.comentario != 'NO' and lbras.comentario != 'no aplica' and lbras.comentario != 'No aplica' and lbras.comentario != 'NO APLICA' and lbras.comentario != 'no tengo información de eso' and lbras.comentario != 'N/A' and lbras.comentario != 'NA' and lbras.codinstrumento = '3' and lbras.codpregunta = '221' AND fase is null group by s.nombre, lbras.codigo, lbras.codsedeasesor, lbras.codpregunta, lbras.comentario, lbras.codinstrumento, i.nombre, m.nombre";
        conectar.CrearComando(consulta);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable SedesxPlanMejoramientoTIC_NA()
    {
        Conexion conectar = new Conexion();
        string consulta = "select mm.nombre municipio, ss.nombre sede, ii.nombre institucion from ins_sede ss inner join ins_institucion ii on ii.codigo=ss.codinstitucion inner join geo_municipios mm on mm.cod=ii.codmunicipio where not exists (select 1 from lbase_respuestaabiertasede lbras inner join lbase_sedeasesor lbsa on lbsa.codigo = lbras.codsedeasesor inner join ins_sede s on s.codigo = lbsa.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio where lbras.comentario != 'no se han incluido' and lbras.comentario != 'NO HAN INCLUIDO' and lbras.comentario != 'no se han incluido propuestas de mejoramiento' and lbras.comentario != '0' and lbras.comentario != 'ninguno' and lbras.comentario != 'Ningunos' and lbras.comentario != 'ningun'  and lbras.comentario != 'no' and lbras.comentario != 'NO' and lbras.comentario != 'no aplica' and lbras.comentario != 'No aplica' and lbras.comentario != 'NO APLICA' and lbras.comentario != 'no tengo información de eso' and lbras.comentario != 'N/A' and lbras.comentario != 'NA' and lbras.codinstrumento = '3' and lbras.codpregunta = '221' AND fase is null and ss.codigo=s.codigo group by s.nombre, lbras.codigo, lbras.codsedeasesor, lbras.codpregunta, lbras.comentario, lbras.codinstrumento, i.nombre, m.nombre)";
        conectar.CrearComando(consulta);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    //Esto es nuevo

    public DataTable formulariosxMunicipioDiligenciados(string codPregunta, string codSubpregunta, string codInstrumento)
    {
        Conexion conectar = new Conexion();
        string consulta = "select distinct r.*, da.*, gd.*, s.*, m.nombre as municipio from lbase_respuesta r inner join lbase_docenteasesor da on da.codigo=r.coddocenteasesor inner join ins_gradodocente gd on gd.cod=da.codgradodocente inner join ins_sede s on s.codigo=gd.codsede inner join geo_municipios m on m.cod = s.codmunicipio where fase is null AND r.codpregunta='" + codPregunta + "' and r.codsubpregunta='" + codSubpregunta + "' and r.codinstrumento='" + codInstrumento + "'";
        //conectar.AsignarParametroCadena("@codPregunta", codPregunta);
        //conectar.AsignarParametroCadena("@codSubpregunta", codSubpregunta);
        //conectar.AsignarParametroCadena("@codInstrumento", codInstrumento);
        conectar.CrearComando(consulta);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable formulariosxSedeDiligenciados(string codPregunta, string codSubpregunta, string codInstrumento)
    {
        Conexion conectar = new Conexion();
        string consulta = "select distinct r.*, da.*, gd.*, s.nombre as sede from lbase_respuesta r inner join lbase_docenteasesor da on da.codigo=r.coddocenteasesor inner join ins_gradodocente gd on gd.cod=da.codgradodocente inner join ins_sede s on s.codigo=gd.codsede where fase is null AND r.codpregunta='" + codPregunta + "' and r.codsubpregunta='" + codSubpregunta + "' and r.codinstrumento='" + codInstrumento + "'";
        conectar.CrearComando(consulta);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable formulariosxRespondiente(string codPregunta, string codSubpregunta, string codInstrumento)
    {
        Conexion conectar = new Conexion();
        string consulta = "select distinct * from lbase_respuesta where codpregunta='" + codPregunta + "' and codsubpregunta='" + codSubpregunta + "' and codinstrumento='" + codInstrumento + "' AND fase is null";
        conectar.CrearComando(consulta);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable formularioRespondidoxDocente(string codSubpregunta, string codInstrumento)
    {
        Conexion conectar = new Conexion();
        string consulta = "select * from lbase_respuesta where codinstrumento='" + codInstrumento + "' and codsubpregunta='" + codSubpregunta + "' order by codigo, coddocenteasesor, codpregunta asc";
        conectar.CrearComando(consulta);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable formacionEspecificaPracticasPedagogicas(string codPregunta, string codInstrumento)
    {
        Conexion conectar = new Conexion();
        string consulta = "select distinct * from lbase_respuesta where codpregunta='" + codPregunta + "' and codinstrumento='" + codInstrumento + "' AND fase is null";
        conectar.CrearComando(consulta);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }


    public DataRow numeroEstudiantesMujeres()
    {
        Conexion conectar = new Conexion();
        string consulta = "SELECT SUM(tmujer) as tmujer, SUM(thombre) as thombre FROM lbase_respuestaestudiantes WHERE tmujer !=  '0' and thombre != '0'";
        conectar.CrearComando(consulta);
        DataRow resp = conectar.traerfila();
        if (resp != null)
        {
            return resp;
        }
        else
        {
            return null;
        }
    }

    public DataTable numeroEstudiantesConDiscapacidad(string subcategoria)
    {
        Conexion conectar = new Conexion();
        string consulta = "SELECT categoria, subcategoria, sum(thombre+tmujer) FROM lbase_respuestaestudiantes where  codpregunta = '3' and subcategoria=@subcategoria group by categoria, subcategoria order by subcategoria, categoria asc;";
        conectar.CrearComando(consulta);
        conectar.AsignarParametroCadena("@subcategoria", subcategoria);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable numeroEstudianteGrupoEtnico()
    {
        Conexion conectar = new Conexion();
        string consulta = "SELECT distinct coddocenteasesor, codpregunta, codinstrumento, categoria, subcategoria, tmujer + thombre as total, codigo FROM lbase_respuestaestudiantes where subcategoria = '0' and codpregunta = '5' and tmujer != '0' and thombre != '0'";
        conectar.CrearComando(consulta);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable numeroEstudianteVictimasConflicto()
    {
        Conexion conectar = new Conexion();
        string consulta = "SELECT distinct coddocenteasesor, codpregunta, codinstrumento, categoria, subcategoria, tmujer + thombre as total, codigo FROM lbase_respuestaestudiantes where subcategoria = '0' and codpregunta = '7' and tmujer != '0' and thombre != '0'";
        conectar.CrearComando(consulta);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarDocentesxAsesorLineaBase()
    {
        Conexion conectar = new Conexion();
        string consulta = "SELECT distinct on (da.codgradodocente) da.* from lbase_docenteasesor da INNER JOIN lbase_respuesta lb ON lb.coddocenteasesor=da.codigo where lb.fase is null";
        conectar.CrearComando(consulta);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarRespuestasDePreguntasInstrumento04OFFSET(string coddocenteasesor, string codpregunta, string codsubpregunta, string codinstrumento, string offset)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT respuesta FROM lbase_respuesta WHERE coddocenteasesor=@coddocenteasesor AND codpregunta=@codpregunta AND codsubpregunta=@codsubpregunta AND codinstrumento=@codinstrumento order by codigo asc offset @offset limit 1;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codsubpregunta", codsubpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@offset", offset);
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
    public DataTable cargarRespuestasDePreguntasInstrumento05OFFSET(string coddocenteasesor, string codpregunta, string codsubpregunta, string codinstrumento, string limit)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT respuesta FROM lbase_respuesta WHERE coddocenteasesor=@coddocenteasesor AND codpregunta=@codpregunta AND codsubpregunta=@codsubpregunta AND codinstrumento=@codinstrumento AND fase='' order by codigo asc offset 0 limit @limit;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@coddocenteasesor", coddocenteasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codsubpregunta", codsubpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
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
    public DataTable cargarFormulariosxMunicipioDiligenciandoAutopercepcion()
    {
        Conexion conector = new Conexion();
        string consulta = "select r.coddocenteasesor, gd.codsede, m.nombre from lbase_respuesta r inner join lbase_docenteasesor da on r.coddocenteasesor=da.codigo inner join ins_gradodocente gd on gd.cod=da.codgradodocente inner join ins_sede s on s.codigo=gd.codsede inner join geo_municipios m on m.cod=s.codmunicipio where codinstrumento='4' group by r.coddocenteasesor, gd.codsede, m.nombre order by m.nombre asc";
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
    public DataTable cargarSedesxMunicipioDiligenciandoAutopercepcion()
    {
        Conexion conector = new Conexion();
        string consulta = "select gd.codsede, m.nombre from lbase_respuesta r inner join lbase_docenteasesor da on r.coddocenteasesor=da.codigo inner join ins_gradodocente gd on gd.cod=da.codgradodocente inner join ins_sede s on s.codigo=gd.codsede inner join geo_municipios m on m.cod=s.codmunicipio where codinstrumento='4' AND fase is null group by gd.codsede, m.nombre order by m.nombre asc";
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

    public DataTable cargarDocentesUltimoNivelEducativoAprobado()
    {
        Conexion conector = new Conexion();
        string consulta = "select categoria,subcategoria, (sum(thombre) + sum(tmujer)) as total from lbase_respuestainstitucionalrh where codinstrumento='001A' and codpregunta='5' group by categoria,subcategoria order by categoria,subcategoria asc";
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

    public DataTable cargarRespuestasCerradasReporte(string codpregunta, string codsubpregunta, string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, coddocenteasesor, respuesta FROM lbase_respuesta WHERE codpregunta=@codpregunta AND codsubpregunta=@codsubpregunta AND codinstrumento=@codinstrumento order by coddocenteasesor, codigo asc ";
        conector.CrearComando(consulta);
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

    public bool editarsedeasesor(string codinsasesor, string codsede)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE lbase_sedeasesor SET  codinsasesor = @codinsasesor WHERE codsede = @codsede ;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede", codsede);
        conector.AsignarParametroCadena("@codinsasesor", codinsasesor);
        return conector.guardadata();
    }

    public DataRow cargarRespuestasCerradasInstrumento03_Fase(string codsedeasesor, string codinstrumento, string codpregunta, string codsubpregunta, string fase)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from lbase_respuestasede WHERE codsedeasesor=@codsedeasesor AND codpregunta=@codpregunta AND codsubpregunta=@codsubpregunta AND codinstrumento=@codinstrumento AND fase=@fase";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codsubpregunta", codsubpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@fase", fase);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
	
	public DataTable cargarRespuestasCerradasInstrumento03_FaseDT(string codsedeasesor, string codinstrumento, string codpregunta, string codsubpregunta, string fase)
    {
        Conexion conector = new Conexion();
        string consulta = "select * from lbase_respuestasede WHERE codsedeasesor=@codsedeasesor AND codpregunta=@codpregunta AND codsubpregunta=@codsubpregunta AND codinstrumento=@codinstrumento AND fase=@fase";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsedeasesor", codsedeasesor);
        conector.AsignarParametroCadena("@codpregunta", codpregunta);
        conector.AsignarParametroCadena("@codsubpregunta", codsubpregunta);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        conector.AsignarParametroCadena("@fase", fase);
        DataTable dato = conector.traerdata();
        if (dato != null)
            return dato;
        else
            return null;
    }


     public DataRow buscarDocenteAsesorPorIdDocente(string identificacion)
    {
        Conexion conector = new Conexion();
        string consulta = "select da.*, concat_ws(' ',a.nombre,a.apellido) as nombre from lbase_docenteasesor da inner join ins_gradodocente gd on da.codgradodocente=gd.cod inner join ins_asesor a on a.codigo=da.codasesor WHERE gd.identificacion=@identificacion order by da.codigo desc limit 1;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        //conector.AsignarParametroCadena("@codanio", codanio);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public bool actualizarCodAsesorxInstitucion(string codinstitucion, string codasesor)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE lbase_institucionasesor SET  codasesor = @codasesor where codinstitucion=@codinstitucion";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstitucion", codinstitucion);
        conector.AsignarParametroCadena("@codasesor", codasesor);
        return conector.guardadata();
    }

    public DataTable cargarDetalleHerramientasWebLineaBase(string tipo)
    {
        Conexion conector = new Conexion();
        string consulta = "select m.nombre as municipio, i.nombre as institucion, s.nombre as sede, hie.* from lbase_herradisponeie hie inner join lbase_sedeasesor lsa on lsa.codigo=hie.codsedeasesor inner join ins_sede s on s.codigo=lsa.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio where hie.tipo=@tipo AND fase is null";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@tipo", tipo);
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


//nuevo codigo reporte evaluacion intermedia

   public DataTable totalDocentesEvaIntermedia()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT coddocenteasesor,respuesta FROM lbase_respuesta where codpregunta = '11' and codinstrumento = '5'";
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

    // public DataTable totalDocentesEvaIntermediaxNivelEducativo(string niveleducativo)
    // {
    //     Conexion conector = new Conexion();
    //     string consulta = "SELECT DISTINCT coddocenteasesor,respuesta FROM lbase_respuesta where codpregunta = '11' and codinstrumento = '5' AND respuesta = '" + niveleducativo + "'";
    //     conector.CrearComando(consulta);
    //     DataTable resp = conector.traerdata();
    //     if (resp != null)
    //     {
    //         return resp;
    //     }
    //     else
    //     {
    //         return null;
    //     }
    // }

     public DataTable totalDocentesEvaIntermediaxNivelEducativo(string niveleducativo)
    {
        Conexion conector = new Conexion();
        // string consulta = "SELECT DISTINCT coddocenteasesor,respuesta FROM lbase_respuesta where codpregunta = '11' and codinstrumento = '5' AND respuesta = '" + niveleducativo + "'";
        string consulta = "SELECT  coddocenteasesor,  Max( case WHEN  respuesta='Bachillerato pedagógico' THEN 1    WHEN  respuesta='Normalista Superior' THEN 2    WHEN respuesta='Otro bachillerato' THEN 3   WHEN  respuesta='Técnico o tecnológico'  THEN 4 WHEN respuesta ='Otro Técnico o tecnológico' THEN 5 WHEN  respuesta='Profesional pedagógico' THEN 6 WHEN respuesta ='Otro profesional' THEN 7   WHEN  respuesta='Especialización' THEN 8 WHEN  respuesta='Maestría en educación o pedagogía' THEN 9 WHEN  respuesta ='Otra Maestría' THEN 10 WHEN  respuesta='Doctorado en educación o pedagogía'THEN 11 WHEN respuesta ='Otro Doctorado' THEN 12   END ) num FROM lbase_respuesta where codpregunta = '11' and codinstrumento = '5'  GROUP BY coddocenteasesor";
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




    public DataRow totalInventariosxUsuario(string usuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT SUM(conpc) as conpc, SUM(sinpc) as sinpc, SUM(conportatil) as conportatil, SUM(sinportatil) as sinportatil, SUM(contablet) as contablet, SUM(sintablet) as sintablet, SUM(contableros) as contableros, SUM(sintableros) as sintableros FROM lbase_equipostics WHERE codpregunta = '1.1' and fase = 'intermedia' AND nombre = '" + usuario + "'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow totalTabletsEntregadasxRespuesta(string respuesta)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT COUNT(*) as total FROM lbase_respuestasede WHERE codpregunta = '6' and fase = 'intermedia' AND respuesta =  '" + respuesta + "'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


    // public DataRow totalAccesostabletasxFrecuencia(string frecuencia)
    // {
    //     Conexion conector = new Conexion();
    //     string consulta = "SELECT COUNT (DISTINCT codsedeasesor) as total FROM lbase_respuestasede WHERE codpregunta = '7' and fase = 'intermedia' and codsubpregunta = '3' and respuesta = '" + frecuencia + "'";
    //     conector.CrearComando(consulta);
    //     DataRow dato = conector.traerfila();
    //     if (dato != null)
    //         return dato;
    //     else
    //         return null;
    // }
        public DataTable totalAccesostabletasxFrecuencia(string frecuencia)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT l.* FROM lbase_respuestasede l WHERE l.codigo IN ( SELECT MAX ( codigo ) FROM lbase_respuestasede WHERE codpregunta = '7' AND fase = 'intermedia' AND codsubpregunta = '3' GROUP BY codsedeasesor ) AND respuesta = '"+ frecuencia+"'";
        //string consulta = "SELECT  count(*) from lbase_respuestasede l WHERE l.codigo in (SELECT max(codigo) FROM lbase_respuestasede WHERE codpregunta = '7' and fase = 'intermedia' and codsubpregunta = '3' GROUP BY codsedeasesor) and respuesta =  '" + frecuencia + "'";
        conector.CrearComando(consulta);
        DataTable dato = conector.traerdata();
        if (dato != null)
            return dato;
        else
            return null;
    }
    



    public DataRow totalAccesostabletasGruposxFrecuencia(string frecuencia)
    {
        Conexion conector = new Conexion();
        // string consulta = "SELECT COUNT (DISTINCT codsedeasesor) as total FROM lbase_respuestasede WHERE codpregunta = '7' and fase = 'intermedia' and codsubpregunta = '1'  AND respuesta = '" + frecuencia + "'";
        string consulta = "SELECT  count (l.*) as total FROM lbase_respuestasede l WHERE l.codigo IN ( SELECT MAX ( codigo ) FROM lbase_respuestasede WHERE codpregunta = '7' AND fase = 'intermedia' AND codsubpregunta = '1' GROUP BY codsedeasesor ) AND respuesta = '" + frecuencia + "'";

        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataRow totalAccesostabletasRedesxFrecuencia(string frecuencia)
    {
        Conexion conector = new Conexion();
        // string consulta = "SELECT COUNT (DISTINCT codsedeasesor) as total FROM lbase_respuestasede WHERE codpregunta = '7' and fase = 'intermedia' and codsubpregunta = '2'  AND respuesta = '" + frecuencia + "'";
        string consulta = "SELECT count(l.*) as total FROM lbase_respuestasede l WHERE l.codigo IN ( SELECT MAX ( codigo ) FROM lbase_respuestasede WHERE codpregunta = '7' AND fase = 'intermedia' AND codsubpregunta = '2' GROUP BY codsedeasesor )  AND respuesta = '" + frecuencia + "'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow totalsedeseducativasservicioconectividad(string respuesta)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT COUNT(*) as total FROM lbase_respuestasede WHERE codpregunta = '8' and fase = 'intermedia' AND respuesta = '" + respuesta + "'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataRow totalUsoconectividadformacionmaestrosxFrecuencia(string frecuencia)
    {
        Conexion conector = new Conexion();
        //string consulta = "SELECT COUNT (DISTINCT codsedeasesor) as total FROM lbase_respuestasede WHERE codpregunta = '9' and fase = 'intermedia' and codsubpregunta = '3' AND respuesta = '" + frecuencia + "'";
        string consulta = "SELECT  count (l.*) as total FROM lbase_respuestasede l WHERE l.codigo IN ( SELECT MAX ( codigo ) FROM lbase_respuestasede WHERE codpregunta = '9' AND fase = 'intermedia' AND codsubpregunta = '3' GROUP BY codsedeasesor ) AND respuesta = '" + frecuencia + "'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow totalSedesbeneficiadasconectividadentregado(string respuesta)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT  count (l.*) as total FROM lbase_respuestasede l WHERE l.codigo IN ( SELECT MAX ( codigo ) FROM lbase_respuestasede WHERE codpregunta = '9' AND fase = 'intermedia' AND codsubpregunta = '1' GROUP BY codsedeasesor ) AND respuesta ='" + respuesta + "'";

        //string consulta = "SELECT COUNT (DISTINCT codsedeasesor) as total FROM lbase_respuestasede WHERE codpregunta = '9' and fase = 'intermedia' and codsubpregunta = '1' AND respuesta = '" + respuesta + "'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


        public DataRow totalUsoconectividadtrabajoredesxFrecuencia(string frecuencia)
    {
        Conexion conector = new Conexion();
        //string consulta = "SELECT COUNT (DISTINCT codsedeasesor) as total FROM lbase_respuestasede WHERE codpregunta = '9' and fase = 'intermedia' and codsubpregunta = '2' AND respuesta = '" + frecuencia + "'";
        //string consulta = "SELECT  count (l.*) as total FROM lbase_respuestasede l WHERE l.codigo IN ( SELECT MAX ( codigo ) FROM lbase_respuestasede WHERE codpregunta = '9' AND fase = 'intermedia' AND codsubpregunta = '2' GROUP BY codsedeasesor ) AND respuesta = '" + frecuencia + "'";       
        string consulta = "SELECT  count (l.*) as total FROM lbase_respuestasede l WHERE l.codigo IN ( SELECT MAX ( codigo ) FROM lbase_respuestasede WHERE codpregunta = '9' AND fase = 'intermedia' AND codsubpregunta = '2' GROUP BY codsedeasesor ) AND respuesta = '" + frecuencia + "'";       
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataRow totalHerramientaswebsedesxHerramienta(string tipo)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT COUNT(DISTINCT codsedeasesor) as total from lbase_herradisponeie where codpregunta = '1.2' and codinstrumento = '3' and fase = 'intermedia' AND tipo = '" + tipo + "'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow totalPlataformasPedagogicasSedesSi()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT COUNT(*) as total from lbase_respuestaabiertasede where codpregunta = '1.2' and codinstrumento = '3' and fase = 'intermedia' AND comentario != ''";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow totalPlataformasPedagogicasSedesNo()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT COUNT(*) as total from lbase_respuestaabiertasede where codpregunta = '1.2' and codinstrumento = '3' and fase = 'intermedia' AND comentario = ''";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


    
        public DataRow totalParticipacionProcesosFormacionDocentesSi()
    {
        Conexion conector = new Conexion();
        //string consulta = "SELECT COUNT(*) as total from lbase_respuestaabiertasede where codpregunta = '2.1' and codinstrumento = '3' and fase = 'intermedia' AND  comentario != ''";
        string consulta = "SELECT COUNT( l.* ) AS total FROM	lbase_respuestaabiertasede  l WHERE	l.codigo IN (	SELECT max(codigo)	FROM		lbase_respuestaabiertasede 	WHERE		codpregunta = '2.1' 		AND fase = 'intermedia' 		AND codinstrumento = '3' 		GROUP BY	codsedeasesor) AND comentario!= ''";

        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataRow totalParticipacionProcesosFormacionDocentesNo()
    {
        Conexion conector = new Conexion();
        //string consulta = "SELECT COUNT(*) as total from lbase_respuestaabiertasede where codpregunta = '2.1' and codinstrumento = '3' and fase = 'intermedia' AND  comentario = ''";
        string consulta = "SELECT COUNT( l.* ) AS total FROM	lbase_respuestaabiertasede  l WHERE	l.codigo IN (	SELECT max(codigo)	FROM		lbase_respuestaabiertasede 	WHERE		codpregunta = '2.1' 		AND fase = 'intermedia' 		AND codinstrumento = '3' 		GROUP BY	codsedeasesor) AND comentario = ''";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


        public DataRow totalsedesEducativasTresPlanesdeMejoramientoSi()
    {
        Conexion conector = new Conexion();
        //string consulta = "SELECT COUNT(*) as total from lbase_respuestaabiertasede where codpregunta = '2.1' and codinstrumento = '3' and fase = 'intermedia' AND  comentario != ''";
        string consulta = "SELECT COUNT( l.* ) AS total FROM	lbase_respuestaabiertasede  l WHERE	l.codigo IN (SELECT max(codigo)	FROM lbase_respuestaabiertasede WHERE codpregunta = '2.2' AND fase = 'intermedia' AND codinstrumento = '3' GROUP BY	codsedeasesor) AND comentario != ''";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataRow totalsedesEducativasTresPlanesdeMejoramientoNo()
    {
        Conexion conector = new Conexion();
        //string consulta = "SELECT COUNT(*) as total from lbase_respuestaabiertasede where codpregunta = '2.1' and codinstrumento = '3' and fase = 'intermedia' AND  comentario = ''";
        string consulta = "SELECT COUNT( l.* ) AS total FROM	lbase_respuestaabiertasede  l WHERE	l.codigo IN (SELECT max(codigo)	FROM lbase_respuestaabiertasede WHERE codpregunta = '2.2' AND fase = 'intermedia' AND codinstrumento = '3' GROUP BY	codsedeasesor) AND comentario = ''";      
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow totalpercepcionefectosincorporacionTICsedesSi()
    {
        Conexion conector = new Conexion();
      //  string consulta = "SELECT COUNT(*) as total from lbase_respuestaabiertasede where codpregunta = '2.2' and codinstrumento = '3' and fase = 'intermedia' and comentario != ''";
       	string consulta = "SELECT count( *) as total FROM lbase_respuestainstitucional WHERE  fase = 'intermedia' and codinstrumento ='2.2' and codpregunta = '7' and respuesta = 'si'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow totalpercepcionefectosincorporacionTICsedesNo()
    {
        Conexion conector = new Conexion();
       // string consulta = "SELECT COUNT(*) as total from lbase_respuestaabiertasede where codpregunta = '2.2' and codinstrumento = '3' and fase = 'intermedia' and comentario = ''";
        string consulta = "SELECT count( *) as total FROM lbase_respuestainstitucional WHERE  fase = 'intermedia' and codinstrumento ='2.2' and codpregunta = '7' and respuesta = 'no'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataRow totalCurriculosModificados()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT COUNT(*) as total from lbase_respuesta where codpregunta = '1' and codinstrumento = '2.1' and fase = 'intermedia' AND  respuesta= 'si'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    
    public DataRow totalCurriculosNoModificados()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT COUNT(*) as total from lbase_respuesta where codpregunta = '1' and codinstrumento = '2.1' and fase = 'intermedia' AND  respuesta= 'no'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow totalFavoreceElModeloxRespuesta(string respuesta)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT COUNT(*) as total from lbase_respuesta where codpregunta = '2' and codinstrumento = '2.1' and fase = 'intermedia' and respuesta = '" + respuesta + "'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    
    public DataRow totaldocentesModificaronPracticaxRespuesta(string respuesta)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT COUNT(*) as total from lbase_respuesta where codpregunta = '3' and codinstrumento = '2.1' and fase = 'intermedia' and respuesta = '" + respuesta + "'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    
    public DataRow totalMaestrosIncluyentexTIC(string respuesta)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT COUNT(*) as total from lbase_respuesta where codpregunta = '4' and codinstrumento = '2.1' and fase = 'intermedia' and respuesta = '" + respuesta + "'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataRow totalActualizacionPEISi()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT COUNT (*) AS TOTAL from lbase_respuestaabiertainstitucional where codpregunta = '1' and codinstrumento = '2.2' and fase = 'intermedia' and to_date(comentario, 'DD/MM/YYYY') >= date('01/12/2017')  and comentario != 'undefined'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow totalActualizacionPEINo()
    {
        Conexion conector = new Conexion();
        //string consulta = "SELECT COUNT (*) AS TOTAL from lbase_respuestaabiertainstitucional where codpregunta = '1' and codinstrumento = '2.2' and fase = 'intermedia' and to_date(comentario, 'DD/MM/YYYY') <= date('01/12/2017')";
        //string consulta = "SELECT COUNT (*) AS TOTAL from lbase_respuestaabiertainstitucional where codpregunta = '1' and codinstrumento = '2.2' and fase = 'intermedia' and to_date(comentario, 'DD/MM/YYYY') >= date('01/12/2017')  and comentario != 'undefined'";
        string consulta = "SELECT COUNT (*) AS TOTAL from lbase_respuestaabiertainstitucional where codpregunta = '1' and codinstrumento = '2.2' and fase = 'intermedia' and to_date(comentario, 'DD/MM/YYYY') <= date('01/12/2017')  and comentario != 'undefined'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
     //fin del codigo evaluacion intermedia

    //NUEVO CODIGO 24-07-2018
    public DataRow totalSedesIncluyenFormativosSI()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT COUNT(distinct codinstiasesor) AS total from lbase_respuestainstitucional where codinstrumento= '2.2' and codpregunta='2' AND respuesta != 'N/A'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow totalSedesIncluyenFormativosNO()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT COUNT(distinct codinstiasesor) AS total from lbase_respuestainstitucional where codinstrumento= '2.2' and codpregunta='2' AND respuesta = 'N/A'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataRow totalInstitucionesincluyenxRespuestaSI(string resp)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT COUNT(distinct codinstiasesor) AS total FROM lbase_respuestainstitucional WHERE codinstrumento= '2.2' AND codpregunta='2' AND respuesta='"+ resp + "'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow totalInstitucionesincluyenxRespuestaNO(string resp)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT COUNT(distinct codinstiasesor) AS total FROM lbase_respuestainstitucional WHERE codinstrumento= '2.2' AND codpregunta='2' AND respuesta != '"+ resp + "'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataRow totalModelosEducativosdeSedesxRespuesta(string resp)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT COUNT(respuesta) AS total FROM lbase_respuestainstitucional WHERE codinstrumento = '2.2' AND codpregunta = '3' AND respuesta = '" + resp + "'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }
public DataRow totalinstitucionespromueveinvestigaciondocentexRespuesta(string resp)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT COUNT(*) AS total FROM lbase_respuestainstitucional WHERE codinstrumento= '2.2' AND codpregunta='4' AND codsubpregunta = '1' AND respuesta = '" + resp + "'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }



    public DataRow totalinstitucionespromueveinvestigacionestudiantesxRespuesta(string resp)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT COUNT(*) AS total FROM lbase_respuestainstitucional where codinstrumento= '2.2' and codpregunta='4' and codsubpregunta = '2' AND respuesta = '" + resp + "'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataRow totalinstucionesPromueveUsoTicDocentesxRespuesta(string resp)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT COUNT(*) AS total FROM lbase_respuestainstitucional where codinstrumento= '2.2' and codpregunta='4' and codsubpregunta = '3' AND respuesta = '" + resp + "'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataRow totalinstucionesPromueveUsoTicEstudiantesxRespuesta(string resp)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT COUNT(*) AS total FROM lbase_respuestainstitucional WHERE codinstrumento= '2.2' AND codpregunta='4'  AND codsubpregunta = '4' AND respuesta = '" + resp + "'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    //fin nuevo codigo

    //NUEVO CODIGO 21/08/2018
    public DataRow totalparticipacionMaestrosProyectosInvestigacionSI()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT COUNT(coddocenteasesor) AS total FROM lbase_respuestaabierta WHERE codpregunta='4' AND codinstrumento='5' AND fase='intermedia' AND comentario != ''";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow totalparticipacionMaestrosProyectosInvestigacionNO()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT COUNT(coddocenteasesor) AS total FROM lbase_respuestaabierta WHERE codpregunta='4' AND codinstrumento='5' AND fase='intermedia' AND comentario = ''";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataRow totalproyectosInvestigacionEstudiantesPracticaPedagogicaSI()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT COUNT(coddocenteasesor) AS total FROM lbase_respuestaabierta WHERE codpregunta='6' AND codinstrumento='5' AND fase='intermedia' AND comentario != ''";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataRow totalproyectosInvestigacionEstudiantesPracticaPedagogicaNO()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT COUNT(coddocenteasesor) AS total FROM lbase_respuestaabierta WHERE codpregunta='6' AND codinstrumento='5' AND fase='intermedia' AND comentario = ''";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    
    public DataRow totalModalidadProyectosEstudiantesxRespuesta(string resp)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT COUNT(coddocenteasesor) AS total FROM lbase_respuesta WHERE codinstrumento='5'  AND codpregunta='8' AND codsubpregunta='1' and respuesta= '" + resp + "'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    
    public DataRow totalformacionContribuyoCambiarPracticasPedagogicasSI()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT COUNT(coddocenteasesor) AS total FROM lbase_respuestaabierta WHERE fase = 'intermedia' AND codinstrumento = '5' AND codpregunta = '3' and comentario != ''";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow totalformacionContribuyoCambiarPracticasPedagogicasNO()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT COUNT(coddocenteasesor) AS total FROM lbase_respuestaabierta WHERE fase = 'intermedia' AND codinstrumento = '5' AND codpregunta = '3' and comentario = ''";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


    public DataTable totaldequemaneracontribuyocambiarlaspracticaspedagogica()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT distinct coddocenteasesor, comentario,  initcap(CONCAT(d.nombre, ' ', d.apellido)) as nombredocente FROM lbase_respuestaabierta lra INNER JOIN ins_docente d ON d.codigo = lra.coddocenteasesor WHERE fase = 'intermedia' AND codinstrumento = '5' AND codpregunta = '3' and comentario!= ''";
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

    
    public DataRow totalformacionCiclonContribuyoCambiarPracticasPedagogicasSI()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT distinct COUNT(coddocenteasesor) AS total FROM lbase_respuestaabierta WHERE fase = 'intermedia' AND codinstrumento = '5' AND codpregunta = '10' and comentario!=''";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataRow totalformacionCiclonContribuyoCambiarPracticasPedagogicasNO()
    {
        Conexion conector = new Conexion();
       // string consulta = "SELECT distinct COUNT(coddocenteasesor) AS total FROM lbase_respuestaabierta WHERE fase = 'intermedia' AND codinstrumento = '5' AND codpregunta = '10' and comentario = ''";
        string consulta ="SELECT distinct coddocenteasesor,comentario ,  initcap(CONCAT(d.nombre, ' ', d.apellido)) as nombredocente FROM lbase_respuestaabierta lra INNER JOIN lbase_docenteasesor lda ON lda.codigo = lra.coddocenteasesor INNER JOIN ins_gradodocente igd ON igd.cod= lda.codgradodocente INNER JOIN ins_docente d ON d.identificacion= igd.identificacion WHERE fase = 'intermedia' AND codinstrumento = '5' AND codpregunta = '10' and comentario = ''";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

    public DataTable totalformacioncicloncontribuyocambiarpracticaspedagogicas()
    {
        Conexion conector = new Conexion();
       // string consulta = "SELECT distinct coddocenteasesor,comentario ,  initcap(CONCAT(d.nombre, ' ', d.apellido)) as nombredocente FROM lbase_respuestaabierta lra INNER JOIN ins_docente d ON d.codigo = lra.coddocenteasesor WHERE fase = 'intermedia' AND codinstrumento = '5' AND codpregunta = '10' and comentario!= ''";
        string consulta ="SELECT distinct coddocenteasesor,comentario ,  initcap(CONCAT(d.nombre, ' ', d.apellido)) as nombredocente FROM lbase_respuestaabierta lra INNER JOIN lbase_docenteasesor lda ON lda.codigo = lra.coddocenteasesor INNER JOIN ins_gradodocente igd ON igd.cod= lda.codgradodocente INNER JOIN ins_docente d ON d.identificacion= igd.identificacion WHERE fase = 'intermedia' AND codinstrumento = '5' AND codpregunta = '10' and comentario!= ''";
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

 	// NUEVOS METODOS 

    public DataTable detalleDocentesEvaIntermediaxNivelEducativo( string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string respuesta)
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

        if (respuesta != "")
        {
            where = where + " AND respuesta = '" + respuesta + "' ";
        }

        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT(coddocenteasesor), lb.*, lda.*, id.identificacion, id.nombre, id.apellido, isede.dane as danesede, isede.nombre nombresede, iin.dane, iin.nombre as nombreins, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento  FROM lbase_respuesta lb INNER JOIN lbase_docenteasesor lda ON lda.codigo = lb.coddocenteasesor INNER JOIN ins_gradodocente igd ON lda.codgradodocente = igd.cod INNER JOIN ins_docente id ON igd.identificacion = id.identificacion INNER JOIN ins_sede isede on isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento where codpregunta = '11' and codinstrumento = '5'  "+where;
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

/**Metodo modificado docenteEvaluacionIntermedia
*  la modifcacion se realizon en la consulta 
*/
    //  public DataTable detalleDocentesEvaIntermediaxNivelEducativo2( string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string respuesta)
    // {

    //     string where = "";
    //     if (coddepartamento != "")
    //     {
    //         if (coddepartamento != "null")
    //         {
    //             where = " AND gdep.cod = " + coddepartamento;

    //             if (codmunicipio != "")
    //             {
    //                 if (codmunicipio != "null")
    //                 {
    //                     where = where + " AND  gmun.cod = " + codmunicipio;

    //                     if (codinstitucion != "")
    //                     {
    //                         if (codinstitucion != "null")
    //                         {
    //                             where = where + " AND  iin.codigo = " + codinstitucion;
    //                             if (codsede != "")
    //                             {
    //                                 if (codsede != "null")
    //                                 {
    //                                     where = where + " AND  isede.codigo = " + codsede;
                                        
    //                                 }
    //                             }
    //                         }
    //                     }
    //                 }
    //             }
    //         }

    //     }

    //     if (respuesta != "")
    //     {
    //         where = where + " AND respuesta = '" + respuesta + "' ";
    //     }

    //     Conexion conector = new Conexion();
    //     string consulta = "SELECT  DISTINCT lb.coddocenteasesor,gdep.nombre as nombredepartamento,gmun.nombre as nombremunicipio,iin.dane,iin.nombre as nombreins,lb.respuesta, isede.dane as danesede,isede.nombre nombresede FROM lbase_respuesta lb INNER JOIN lbase_docenteasesor lda ON lda.codigo = lb.coddocenteasesor INNER JOIN ins_gradodocente igd ON lda.codgradodocente = igd.cod INNER JOIN ins_docente id ON igd.identificacion = id.identificacion INNER JOIN ins_sede isede on isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento where codpregunta = '11' and codinstrumento = '5' "+where;
    //     conector.CrearComando(consulta);
    //     DataTable resp = conector.traerdata();
    //     if (resp != null)
    //     {
    //         return resp;
    //     }
    //     else
    //     {
    //         return null;
    //     }
    // }
        
public DataTable detalleDocentesEvaIntermediaxNivelEducativo2( string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string respuesta)
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
        string consulta = "SELECT lb1.coddocenteasesor, MAX (CASE WHEN lb1.respuesta = 'Bachillerato pedagógico' THEN 1 WHEN lb1.respuesta = 'Normalista Superior' THEN 2 WHEN lb1.respuesta = 'Otro bachillerato' THEN 3 WHEN lb1.respuesta = 'Técnico o tecnológico' THEN 4 WHEN lb1.respuesta = 'Otro Técnico o tecnológico' THEN 5 WHEN lb1.respuesta = 'Profesional pedagógico' THEN 6 WHEN lb1.respuesta = 'Otro profesional' THEN 7 WHEN lb1.respuesta = 'Especialización' THEN 8 WHEN lb1.respuesta = 'Maestría en educación o pedagogía' THEN 9 WHEN lb1.respuesta = 'Otra Maestría' THEN 10 WHEN lb1.respuesta = 'Doctorado en educación o pedagogía' THEN 11 WHEN lb1.respuesta = 'Otro Doctorado' THEN 12 END ) num ,gdep.nombre AS nombredepartamento, gmun.nombre AS nombremunicipio, iin.dane, iin.nombre AS nombreins, initcap(CONCAT ( ID.nombre, ' ', ID.apellido )) AS nombredocente, isede.dane AS danesede,isede.nombre nombresede FROM lbase_respuesta AS lb1 INNER JOIN lbase_docenteasesor lda ON lda.codigo = lb1.coddocenteasesor INNER JOIN ins_gradodocente igd ON lda.codgradodocente = igd.cod INNER JOIN ins_docente ID ON igd.identificacion = ID.identificacion INNER JOIN ins_sede isede ON isede.codigo = igd.codsede    INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codpregunta = '11' AND codinstrumento = '5' "+ where + " GROUP BY  coddocenteasesor,gdep.nombre,iin.dane,ID.nombre,ID.apellido,isede.dane,isede.nombre,gmun.nombre,iin.nombre";
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

/**fin metodo docenteEvaluacionIntermedia*/    

    public DataRow detalleInventariosxUsuario(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string nombre)
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

        if(nombre != "")
        {
            where = where + "AND lbe.nombre = '" + nombre + "'";
        }

        Conexion conector = new Conexion();
        string consulta = "SELECT COALESCE(SUM(conpc), 0) as conpc, COALESCE(SUM(sinpc),0) as sinpc, COALESCE(SUM(conportatil),0) as conportatil, COALESCE(SUM(sinportatil),0) as sinportatil, COALESCE(SUM(contablet),0) as contablet, COALESCE(SUM(sintablet), 0) as sintablet, COALESCE(SUM(contableros),0) as contableros, COALESCE(SUM(sintableros), 0) as sintableros FROM lbase_equipostics lbe INNER JOIN lbase_sedeasesor lbs ON lbs.codigo = lbe.codsedeasesor INNER JOIN ins_sede isede on isede.codigo = lbs.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codpregunta = '1.1' and fase = 'intermedia'   " + where;
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }


 
    public DataRow detalleTabletsEntregadasxRespuesta(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string respuesta)
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

        if(respuesta != "")
        {
            where = where + " AND lbr.respuesta = '" + respuesta + "' ";
        }

        Conexion conector = new Conexion();
        string consulta = "SELECT COALESCE(COUNT(*),0) as total FROM lbase_respuestasede lbr INNER JOIN lbase_sedeasesor lbs ON lbs.codigo = lbr.codsedeasesor INNER JOIN ins_sede isede on isede.codigo = lbs.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codpregunta = '6' and fase = 'intermedia'   " + where;
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }



   

    // public DataTable detalleAccesostabletasxFrecuencia(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string respuesta)
    // {

    //     string where = "";
    //     if (coddepartamento != "")
    //     {
    //         if (coddepartamento != "null")
    //         {
    //             where = " AND gdep.cod = " + coddepartamento;

    //             if (codmunicipio != "")
    //             {
    //                 if (codmunicipio != "null")
    //                 {
    //                     where = where + " AND  gmun.cod = " + codmunicipio;

    //                     if (codinstitucion != "")
    //                     {
    //                         if (codinstitucion != "null")
    //                         {
    //                             where = where + " AND  iin.codigo = " + codinstitucion;
    //                             if (codsede != "")
    //                             {
    //                                 if (codsede != "null")
    //                                 {
    //                                     where = where + " AND  isede.codigo = " + codsede;

    //                                 }
    //                             }
    //                         }
    //                     }
    //                 }
    //             }
    //         }

    //     }

    //     if (respuesta != "")
    //     {
    //         where = where + " AND lbr.respuesta = '" + respuesta + "' ";
    //     }

    //     Conexion conector = new Conexion();
    //    // string consulta = "SELECT lbr.*, isede.dane as danesede, isede.nombre nombresede, iin.dane, iin.nombre as nombreins, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM lbase_respuestasede as lbr INNER JOIN lbase_sedeasesor lbs ON lbs.codigo = lbr.codsedeasesor INNER JOIN ins_sede isede on isede.codigo = lbs.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codpregunta = '7' and fase = 'intermedia' " + where;
    //     string consulta = "SELECT DISTINCT lbr.codsedeasesor,lbr.respuesta, isede.dane as danesede, isede.nombre nombresede, iin.dane, iin.nombre as nombreins, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM lbase_respuestasede  lbr INNER JOIN lbase_sedeasesor lbs ON lbs.codigo = lbr.codsedeasesor INNER JOIN ins_sede isede on isede.codigo = lbs.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codpregunta = '7' and codsubpregunta='3' and fase = 'intermedia' " + where;
    //     conector.CrearComando(consulta);
    //     DataTable resp = conector.traerdata();
    //     if (resp != null)
    //     {
    //         return resp;
    //     }
    //     else
    //     {
    //         return null;
    //     }
    // }

public DataTable detalleAccesostabletasxFrecuencia(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string respuesta)
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

        if (respuesta != "")
        {
            where = where + " AND lbr.respuesta = '" + respuesta + "' ";
        }

        Conexion conector = new Conexion();
        // string consulta = "SELECT lbr.*, isede.dane as danesede, isede.nombre nombresede, iin.dane, iin.nombre as nombreins, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM lbase_respuestasede as lbr INNER JOIN lbase_sedeasesor lbs ON lbs.codigo = lbr.codsedeasesor INNER JOIN ins_sede isede on isede.codigo = lbs.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codpregunta = '7' and fase = 'intermedia' " + where;
        //string consulta = "SELECT DISTINCT(lbr.codsedeasesor),lbr.respuesta, isede.dane as danesede, isede.nombre nombresede, iin.dane, iin.nombre as nombreins, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM lbase_respuestasede as lbr INNER JOIN lbase_sedeasesor lbs ON lbs.codigo = lbr.codsedeasesor INNER JOIN ins_sede isede on isede.codigo = lbs.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codpregunta = '7' and codsubpregunta='3' and fase = 'intermedia' " + where;
        string consulta = "SELECT  lbr.codsedeasesor ,  lbr.respuesta,  isede.dane AS danesede, isede.nombre nombresede,    iin.dane,   iin.nombre AS nombreins,    gmun.nombre AS nombremunicipio, gdep.nombre AS nombredepartamento FROM lbase_respuestasede AS lbr   INNER JOIN lbase_sedeasesor lbs ON lbs.codigo = lbr.codsedeasesor   INNER JOIN ins_sede isede ON isede.codigo = lbs.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE lbr.codigo IN ( SELECT MAX ( codigo ) FROM lbase_respuestasede WHERE codpregunta = '7' AND fase = 'intermedia' AND codsubpregunta = '3' GROUP BY codsedeasesor ) "+ where;
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






    public DataTable detalleAccesostabletasGruposxFrecuencia(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string respuesta)
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

        if (respuesta != "")
        {
            where = where + " AND lbr.respuesta = '" + respuesta + "' ";
        }

        Conexion conector = new Conexion();
        String consulta = "SELECT  lbr.codsedeasesor ,  lbr.respuesta,  isede.dane AS danesede, isede.nombre nombresede,    iin.dane,   iin.nombre AS nombreins,    gmun.nombre AS nombremunicipio, gdep.nombre AS nombredepartamento FROM lbase_respuestasede AS lbr   INNER JOIN lbase_sedeasesor lbs ON lbs.codigo = lbr.codsedeasesor   INNER JOIN ins_sede isede ON isede.codigo = lbs.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE lbr.codigo IN ( SELECT MAX ( codigo ) FROM lbase_respuestasede WHERE codpregunta = '7' AND fase = 'intermedia' AND codsubpregunta = '1' GROUP BY codsedeasesor )"+ where;

        //string consulta = "SELECT lbr.*, isede.dane as danesede, isede.nombre nombresede, iin.dane, iin.nombre as nombreins, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM lbase_respuestasede lbr INNER JOIN lbase_sedeasesor lbs ON lbs.codigo = lbr.codsedeasesor INNER JOIN ins_sede isede on isede.codigo = lbs.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codpregunta = '7' and fase = 'intermedia' and codsubpregunta = '1'  " + where;
        

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


  
    public DataTable detalleAccesostabletasRedesxFrecuencia(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string respuesta)
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

        if (respuesta != "")
        {
            where = where + " AND lbr.respuesta = '" + respuesta + "' ";
        }

        Conexion conector = new Conexion();
        //string consulta = "SELECT lbr.*, isede.dane as danesede, isede.nombre nombresede, iin.dane, iin.nombre as nombreins, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM lbase_respuestasede lbr INNER JOIN lbase_sedeasesor lbs ON lbs.codigo = lbr.codsedeasesor INNER JOIN ins_sede isede on isede.codigo = lbs.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codpregunta = '7' and fase = 'intermedia' and codsubpregunta = '2'  " + where;
       // string consulta = "SELECT distinct lbr.codsedeasesor, lbr.respuesta, isede.dane as danesede, isede.nombre nombresede, iin.dane, iin.nombre as nombreins, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM lbase_respuestasede lbr INNER JOIN lbase_sedeasesor lbs ON lbs.codigo = lbr.codsedeasesor INNER JOIN ins_sede isede on isede.codigo = lbs.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codpregunta = '7' and fase = 'intermedia' and codsubpregunta = '2'  " + where;
       //String consulta = "SELECT lbr.codsedeasesor ,    lbr.respuesta,  isede.dane AS danesede, isede.nombre nombresede, iin.dane,  iin.nombre AS nombreins,    gmun.nombre AS nombremunicipio, gdep.nombre AS nombredepartamento FROM lbase_respuestasede AS lbr INNER JOIN lbase_sedeasesor lbs ON lbs.codigo = lbr.codsedeasesor   INNER JOIN ins_sede isede ON isede.codigo = lbs.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE lbr.codigo IN(SELECT MAX (codigo ) FROM lbase_respuestasede WHERE codpregunta = '7' AND fase = 'intermedia' AND codsubpregunta = '2' GROUP BY codsedeasesor )"+ where;
        string consulta = "	SELECT  lbr.codsedeasesor ,  lbr.respuesta,  isede.dane AS danesede, isede.nombre nombresede, iin.dane,   iin.nombre AS nombreins,    gmun.nombre AS nombremunicipio, gdep.nombre AS nombredepartamento FROM lbase_respuestasede AS lbr   INNER JOIN lbase_sedeasesor lbs ON lbs.codigo = lbr.codsedeasesor INNER JOIN ins_sede isede ON isede.codigo = lbs.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE lbr.codigo IN ( SELECT MAX ( codigo ) FROM lbase_respuestasede WHERE codpregunta = '7' AND fase = 'intermedia' AND codsubpregunta = '2' GROUP BY codsedeasesor ) "+ where;
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




    public DataTable detallesedeseducativasservicioconectividad(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string respuesta)
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

        if (respuesta != "")
        {
            where = where + " AND lbr.respuesta = '" + respuesta + "' ";
        }

        Conexion conector = new Conexion();
        //string consulta = "SELECT lbr.*, isede.dane as danesede, isede.nombre nombresede, iin.dane, iin.nombre as nombreins, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM lbase_respuestasede lbr INNER JOIN lbase_sedeasesor lbs ON lbs.codigo = lbr.codsedeasesor INNER JOIN ins_sede isede on isede.codigo = lbs.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codpregunta = '8' and fase = 'intermedia'  " + where;
        string consulta = "SELECT distinct lbr.codsedeasesor,lbr.respuesta, isede.dane as danesede, isede.nombre nombresede, iin.dane, iin.nombre as nombreins, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM lbase_respuestasede lbr INNER JOIN lbase_sedeasesor lbs ON lbs.codigo = lbr.codsedeasesor INNER JOIN ins_sede isede on isede.codigo = lbs.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codpregunta = '8' and fase = 'intermedia'  "+where;
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




    public DataTable detalleUsoconectividadformacionmaestrosxFrecuencia(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string respuesta)
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

        if (respuesta != "")
        {
            where = where + " AND lbr.respuesta = '" + respuesta + "' ";
        }

        Conexion conector = new Conexion();
        //string consulta = "SELECT distinct lbr.codsedeasesor,lbr.respuesta, isede.dane as danesede, isede.nombre nombresede, iin.dane, iin.nombre as nombreins, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM lbase_respuestasede  lbr INNER JOIN lbase_sedeasesor lbs ON lbs.codigo = lbr.codsedeasesor INNER JOIN ins_sede isede on isede.codigo = lbs.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codpregunta = '9' and fase = 'intermedia' and codsubpregunta = '3' " + where;
        String consulta = "SELECT lbr.codsedeasesor ,   lbr.respuesta,  isede.dane AS danesede, isede.nombre nombresede, iin.dane,  iin.nombre AS nombreins,    gmun.nombre AS nombremunicipio, gdep.nombre AS nombredepartamento FROM lbase_respuestasede AS lbr INNER JOIN lbase_sedeasesor lbs ON lbs.codigo = lbr.codsedeasesor   INNER JOIN ins_sede isede ON isede.codigo = lbs.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE lbr.codigo IN(SELECT MAX (codigo ) FROM lbase_respuestasede WHERE codpregunta = '9' AND fase = 'intermedia' AND codsubpregunta = '3' GROUP BY codsedeasesor )" + where;
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


   
    public DataTable detalleUsoconectividadtrabajoredesxFrecuencia(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string respuesta)
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

        if (respuesta != "")
        {
            where = where + " AND lbr.respuesta = '" + respuesta + "' ";
        }

        Conexion conector = new Conexion();
        //String consulta = "SELECT lbr.codsedeasesor ,   lbr.respuesta,  isede.dane AS danesede, isede.nombre nombresede, iin.dane,  iin.nombre AS nombreins,    gmun.nombre AS nombremunicipio, gdep.nombre AS nombredepartamento FROM lbase_respuestasede AS lbr INNER JOIN lbase_sedeasesor lbs ON lbs.codigo = lbr.codsedeasesor   INNER JOIN ins_sede isede ON isede.codigo = lbs.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE lbr.codigo IN(SELECT MAX (codigo ) FROM lbase_respuestasede WHERE codpregunta = '9' AND fase = 'intermedia' AND codsubpregunta = '2' GROUP BY codsedeasesor )" + where;
        string consulta = "SELECT  lbr.codsedeasesor ,  lbr.respuesta,  isede.dane AS danesede, isede.nombre nombresede,    iin.dane,   iin.nombre AS nombreins,    gmun.nombre AS nombremunicipio, gdep.nombre AS nombredepartamento FROM lbase_respuestasede AS lbr   INNER JOIN lbase_sedeasesor lbs ON lbs.codigo = lbr.codsedeasesor   INNER JOIN ins_sede isede ON isede.codigo = lbs.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE lbr.codigo IN ( SELECT MAX ( codigo ) FROM lbase_respuestasede WHERE codpregunta = '9' AND fase = 'intermedia' AND codsubpregunta = '2' "+where+" GROUP BY codsedeasesor) " ;
        //string consulta = "SELECT distinct lbr.codsedeasesor,lbr.respuesta, isede.dane as danesede, isede.nombre nombresede, iin.dane, iin.nombre as nombreins, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM lbase_respuestasede lbr INNER JOIN lbase_sedeasesor lbs ON lbs.codigo = lbr.codsedeasesor INNER JOIN ins_sede isede on isede.codigo = lbs.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codpregunta = '9' and fase = 'intermedia' and codsubpregunta = '2' " + where;
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



    public DataTable detalleHerramientaswebsedesxHerramienta(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string respuesta)
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

        if (respuesta != "")
        {
            where = where + " AND lbr.tipo = '" + respuesta + "' ";
        }

        Conexion conector = new Conexion();
        string consulta = "SELECT distinct lbr.codsedeasesor,lbr.tipo, isede.dane as danesede, isede.nombre nombresede, iin.dane, iin.nombre as nombreins, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento from lbase_herradisponeie lbr INNER JOIN lbase_sedeasesor lbs ON lbs.codigo = lbr.codsedeasesor INNER JOIN ins_sede isede on isede.codigo = lbs.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento where codpregunta = '1.2' and codinstrumento = '3' and fase = 'intermedia' " + where;
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



   
    public DataTable detallePlataformasPedagogicasSedes(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string respuesta, string opc)
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

        if (respuesta != "")
        {
            where = where + " AND lbr.comentario = '" + respuesta + "' ";
        }
        else
        {
            if (opc == "si")
            {
                where = where + " AND comentario != '' ";

            }
            else
            {
                where = where + " AND comentario = '' ";

            }


        }

        Conexion conector = new Conexion();
        string consulta = "SELECT distinct lbr.codsedeasesor,lbr.comentario , isede.dane as danesede, isede.nombre nombresede, iin.dane, iin.nombre as nombreins, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM lbase_respuestaabiertasede lbr INNER JOIN lbase_sedeasesor lbs ON lbs.codigo = lbr.codsedeasesor INNER JOIN ins_sede isede on isede.codigo = lbs.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codpregunta = '1.2' and codinstrumento = '3' and fase = 'intermedia' " + where;
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









    public DataTable detalleFavoreceElModeloxRespuesta(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string respuesta)
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

        if (respuesta != "")
        {
            where = where + " AND lbr.respuesta = '" + respuesta + "' ";
        }

        Conexion conector = new Conexion();
        string consulta = "SELECT COUNT(*) as total, lbr.respuesta, isede.dane as danesede, isede.nombre nombresede, iin.dane, iin.nombre as nombreins, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM lbase_respuesta lbr INNER JOIN lbase_docenteasesor lda ON lda.codigo = lbr.coddocenteasesor INNER JOIN ins_gradodocente igd ON lda.codgradodocente = igd.cod INNER JOIN ins_docente id ON igd.identificacion = id.identificacion INNER JOIN ins_sede isede on isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codpregunta = '2' and codinstrumento = '2.1' and fase = 'intermedia' " + where + " GROUP BY isede.dane, isede.nombre, iin.dane, iin.nombre, gmun.nombre, gdep.nombre, lbr.respuesta ORDER BY isede.nombre ASC;";
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





    public DataTable detalledocentesModificaronPracticaxRespuesta(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string respuesta)
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

        if (respuesta != "")
        {
            where = where + " AND lbr.respuesta = '" + respuesta + "' ";
        }

        Conexion conector = new Conexion();
        string consulta = "SELECT COALESCE(COUNT(*),0) as total, isede.dane as danesede, isede.nombre nombresede, iin.dane, iin.nombre as nombreins, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento from lbase_respuesta lbr INNER JOIN lbase_docenteasesor lda ON lda.codigo = lbr.coddocenteasesor INNER JOIN ins_gradodocente igd ON lda.codgradodocente = igd.cod INNER JOIN ins_docente id ON igd.identificacion = id.identificacion INNER JOIN ins_sede isede on isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento where codpregunta = '3' and codinstrumento = '2.1' and fase = 'intermedia' "+where+" GROUP BY isede.dane, isede.nombre, iin.dane, iin.nombre, gmun.nombre, gdep.nombre, lbr.respuesta; ";
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





    public DataTable detalleActualizacionPEI(string coddepartamento, string codmunicipio, string codinstitucion, string respuesta)
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
                            }
                        }
                    }
                }
            }

        }

        if (respuesta != "")
        {
            if(respuesta == "si")
            {
                where = where + "and to_date(comentario, 'DD/MM/YYYY') >= date('01/12/2017') ";
            }
            else
            {
                where = where + "and to_date(comentario, 'DD/MM/YYYY') <= date('01/12/2017') ";
            }
        }

        Conexion conector = new Conexion();
        string consulta = "SELECT lbr.*, iin.dane, iin.nombre as nombreins, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM lbase_respuestaabiertainstitucional lbr INNER JOIN lbase_institucionasesor lbi ON lbi.codigo = lbr.codinstiasesor INNER JOIN ins_institucion iin ON iin.codigo = lbi.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codpregunta = '1' AND codinstrumento = '2.2' AND fase = 'intermedia' and comentario != 'undefined' " + where;
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




    public DataTable detalleSedesIncluyenFormativos(string coddepartamento, string codmunicipio, string codinstitucion, string respuesta)
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
                            }
                        }
                    }
                }
            }

        }

        if (respuesta != "")
        {
            if (respuesta == "si")
            {
                where = where + " AND respuesta != 'N/A' ";
            }
            else
            {
                where = where + " AND respuesta = 'N/A' ";
            }
        }

        Conexion conector = new Conexion();
        string consulta = "SELECT distinct(codinstiasesor), iin.dane, iin.nombre as nombreins, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM lbase_respuestainstitucional lbr INNER JOIN lbase_institucionasesor lbi ON lbi.codigo = lbr.codinstiasesor INNER JOIN ins_institucion iin ON iin.codigo = lbi.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codinstrumento = '2.2' AND codpregunta = '2' " + where;
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




    public DataTable detalleInstitucionesincluyenxRespuesta(string coddepartamento, string codmunicipio, string codinstitucion, string respuesta, string opc)
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
                            }
                        }
                    }
                }
            }

        }

        if (opc != "")
        {
            if (opc == "si")
            {
                where = where + " AND lbr.respuesta = '"+respuesta+"' ";
            }
            else
            {
                where = where + " AND lbr.respuesta != '"+respuesta+"' ";
            }
        }

        Conexion conector = new Conexion();
        string consulta = "SELECT distinct codinstiasesor, iin.dane, iin.nombre as nombreins, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM lbase_respuestainstitucional lbr INNER JOIN lbase_institucionasesor lbi ON lbi.codigo = lbr.codinstiasesor INNER JOIN ins_institucion iin ON iin.codigo = lbi.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codinstrumento = '2.2' AND codpregunta = '2' " + where;
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







    public DataTable detalleinstitucionespromueveinvestigaciondocentexRespuesta(string coddepartamento, string codmunicipio, string codinstitucion, string respuesta)
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
                            }
                        }
                    }
                }
            }

        }

        if (respuesta != "")
        {
            where = where + " AND lbr.respuesta = '" + respuesta + "' ";
        }

        Conexion conector = new Conexion();
        string consulta = "SELECT lbr.*, iin.dane, iin.nombre as nombreins, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM lbase_respuestainstitucional lbr INNER JOIN lbase_institucionasesor lbi ON lbi.codigo = lbr.codinstiasesor INNER JOIN ins_institucion iin ON iin.codigo = lbi.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codinstrumento = '2.2' AND codpregunta = '4' AND codsubpregunta = '1' " + where;
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


    public DataTable detalleinstitucionespromueveinvestigacionestudiantesxRespuesta(string coddepartamento, string codmunicipio, string codinstitucion, string respuesta)
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
                            }
                        }
                    }
                }
            }
        }

        if (respuesta != "")
        {
            where = where + " AND lbr.respuesta = '" + respuesta + "' ";
        }

        Conexion conector = new Conexion();
        string consulta = "SELECT lbr.*, iin.dane, iin.nombre as nombreins, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM lbase_respuestainstitucional lbr INNER JOIN lbase_institucionasesor lbi ON lbi.codigo = lbr.codinstiasesor INNER JOIN ins_institucion iin ON iin.codigo = lbi.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codinstrumento = '2.2' AND codpregunta = '4' AND codsubpregunta = '2'  " + where;
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




    public DataTable detalleinstucionesPromueveUsoTicDocentesxRespuesta(string coddepartamento, string codmunicipio, string codinstitucion, string respuesta)
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
                            }
                        }
                    }
                }
            }

        }

        if (respuesta != "")
        {
            where = where + " AND lbr.respuesta = '" + respuesta + "' ";
        }

        Conexion conector = new Conexion();
        string consulta = "SELECT lbr.*, iin.dane, iin.nombre as nombreins, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM lbase_respuestainstitucional lbr INNER JOIN lbase_institucionasesor lbi ON lbi.codigo = lbr.codinstiasesor INNER JOIN ins_institucion iin ON iin.codigo = lbi.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codinstrumento = '2.2' AND codpregunta = '4' AND codsubpregunta = '3'  " + where;
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


  

    public DataTable detalleinstucionesPromueveUsoTicEstudiantesxRespuesta(string coddepartamento, string codmunicipio, string codinstitucion, string respuesta)
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
                            }
                        }
                    }
                }
            }

        }

        if (respuesta != "")
        {
            where = where + " AND lbr.respuesta = '" + respuesta + "' ";
        }

        Conexion conector = new Conexion();
        string consulta = "SELECT lbr.*, iin.dane, iin.nombre as nombreins, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM lbase_respuestainstitucional lbr INNER JOIN lbase_institucionasesor lbi ON lbi.codigo = lbr.codinstiasesor INNER JOIN ins_institucion iin ON iin.codigo = lbi.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codinstrumento = '2.2' AND codpregunta = '4' AND codsubpregunta = '4' " + where;
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

  
   
    public DataTable detalleparticipacionMaestrosProyectosInvestigacion(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string respuesta)
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

        if (respuesta != "")
        {
            if (respuesta == "si")
            {
                where = where + " AND lb.comentario != '' ";
            }
            else
            {
                where = where + " AND lb.comentario = '' ";
            }
        }

        Conexion conector = new Conexion();
        string consulta = "SELECT lb.coddocenteasesor, lb.comentario, concat(id.nombre, ' ', id.apellido) nombredocente, isede.dane as danesede, isede.nombre nombresede, iin.dane, iin.nombre as nombreins, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM lbase_respuestaabierta lb INNER JOIN lbase_docenteasesor lda ON lda.codigo = lb.coddocenteasesor INNER JOIN ins_gradodocente igd ON lda.codgradodocente = igd.cod INNER JOIN ins_docente id ON igd.identificacion = id.identificacion INNER JOIN ins_sede isede on isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codpregunta = '4' AND codinstrumento = '5' AND fase = 'intermedia' " + where + " GROUP BY lb.coddocenteasesor, lb.comentario, id.nombre, id.apellido, isede.dane, isede.nombre, iin.dane, iin.nombre, gmun.nombre, gdep.nombre";
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


   

    public DataTable detalleproyectosInvestigacionEstudiantesPracticaPedagogica(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string respuesta)
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

        if (respuesta != "")
        {
            if (respuesta == "si")
            {
                where = where + " AND lb.comentario != '' ";
            }
            else
            {
                where = where + " AND lb.comentario = '' ";
            }
        }

        Conexion conector = new Conexion();
        string consulta = "SELECT lb.coddocenteasesor, lb.comentario, concat(id.nombre, ' ', id.apellido) nombredocente, isede.dane as danesede, isede.nombre nombresede, iin.dane, iin.nombre as nombreins, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM lbase_respuestaabierta lb INNER JOIN lbase_docenteasesor lda ON lda.codigo = lb.coddocenteasesor INNER JOIN ins_gradodocente igd ON lda.codgradodocente = igd.cod INNER JOIN ins_docente id ON igd.identificacion = id.identificacion INNER JOIN ins_sede isede on isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codpregunta = '6' AND codinstrumento = '5' AND fase = 'intermedia' " + where + " GROUP BY lb.coddocenteasesor, lb.comentario, id.nombre, id.apellido, isede.dane, isede.nombre, iin.dane, iin.nombre, gmun.nombre, gdep.nombre";
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


   

    


    public DataTable detalleformacioncicloncontribuyocambiarpracticaspedagogicas(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string respuesta)
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

        if (respuesta != "")
        {
            if (respuesta == "si")
            {
                where = where + " AND lb.comentario != '' ";
            }
            else
            {
                where = where + " AND lb.comentario = '' ";
            }
        }

        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT lb.coddocenteasesor, lb.comentario, concat(id.nombre, ' ', id.apellido) nombredocente, isede.dane as danesede, isede.nombre nombresede, iin.dane, iin.nombre as nombreins, gmun.nombre as nombremunicipio, gdep.nombre as nombredepartamento FROM lbase_respuestaabierta lb INNER JOIN lbase_docenteasesor lda ON lda.codigo = lb.coddocenteasesor INNER JOIN ins_gradodocente igd ON lda.codgradodocente = igd.cod INNER JOIN ins_docente id ON igd.identificacion = id.identificacion INNER JOIN ins_sede isede on isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codpregunta = '10' AND codinstrumento = '5' AND fase = 'intermedia' " + where + " GROUP BY lb.coddocenteasesor, lb.comentario, id.nombre, id.apellido, isede.dane, isede.nombre, iin.dane, iin.nombre, gmun.nombre, gdep.nombre";
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

	     /*** Metodo eliud 
        Trae el codigo de la tabla Coddocenteasesor 
        */
        public DataRow cargarDatoCasCodDocenteAsesor(string identificacion,string codasesor)
        {
            Conexion conector = new Conexion();
            string consulta = "select lbda.codigo from lbase_docenteasesor lbda inner join ins_gradodocente ig on ig.cod=lbda.codgradodocente where ig.identificacion=@identificacion and lbda.codasesor=@codasesor";
            conector.CrearComando(consulta);
            conector.AsignarParametroCadena("@identificacion", identificacion);
            conector.AsignarParametroCadena("@codasesor", codasesor);
            DataRow dato = conector.traerfila();
            if (dato != null)
                return dato;
            else
                return null;
        }

	
	  /***
    metodo eliud
        se  crea el coddosenteasesor 
        --------------------------------
        el docente se consulta por año de ingraso  que es codificao en la tabla  ins_gradodocente la columna codanio 
        siendo 2 el año 2017
     */
    public DataRow agregarDocenteAsesor(string identificacion, string codasesor)
    {
        Conexion conector = new Conexion();
        string consulta = " INSERT INTO lbase_docenteasesor (codgradodocente,codasesor) VALUES ((select cod from ins_gradodocente where identificacion=@identificacion and codanio='2'),@codasesor) RETURNING codigo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion",identificacion);
        conector.AsignarParametroCadena("@codasesor", codasesor);

        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }/*fin */

        public DataTable evidenciaDescarga()
    {
        Conexion conectar = new Conexion();
        string consulta = "select ers.nombrearchivo, ers.nombreguardado, ees.momento, ees.sesion, ees.jornada from est_repositorioasesor_s004sedes ers inner join est_estra2instrumento_s004_sede ees on ers.codinstrumento=ees.codigo where ees.estrategia='2' and ees.momento='1' and ees.sesion='1' and ees.jornada='2' and ers.actividad='Relatoria institucional'";
        conectar.CrearComando(consulta);


        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }
  /** 
  * Consulta intermedia
  */
	public DataTable totalIntermedia(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        Conexion conectar = new Conexion();
        string where = "";
        string consulta = "";
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
      

        // string consulta = "SELECT DISTINCT  lb1.coddocenteasesor as coddocenteasesor2_1, lb2.coddocenteasesor as coddocenteaseso_r5 FROM lbase_respuesta as lb1 full OUTER JOIN lbase_respuesta as lb2 on lb1.coddocenteasesor = lb2.coddocenteasesor and lb2.fase = 'intermedia' and lb2.codinstrumento = '5' WHERE lb1.fase = 'intermedia' and lb1.codinstrumento = '2.1'";
         consulta = "SELECT DISTINCT    lb1.coddocenteasesor AS coddocenteasesor2_1,    gdep.nombre AS nombredepartamento,  gmun.nombre AS nombremunicipio, iin.dane,   iin.nombre AS nombreins,    initcap(    CONCAT ( ID.nombre, ' ', ID.apellido )) AS nombredocente,   isede.dane AS danesede, isede.nombre nombresede FROM    lbase_respuesta AS lb1  INNER JOIN lbase_docenteasesor lda ON lda.codigo = lb1.coddocenteasesor     INNER JOIN ins_gradodocente igd ON lda.codgradodocente = igd.cod    INNER JOIN ins_docente ID ON igd.identificacion = ID.identificacion INNER JOIN ins_sede isede ON isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio   INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE  lb1.fase = 'intermedia'" + where;
        conectar.CrearComando(consulta);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }
    

    public DataRow totalRectoresIntermedia()
    {
        Conexion conectar = new Conexion();
        string consulta = "SELECT count (DISTINCT codinstiasesor) from lbase_respuestainstitucional as lri WHERE fase = 'intermedia' and codinstrumento = '2.2'";
        conectar.CrearComando(consulta);
        DataRow total = conectar.traerfila();
        return total;
    }

   public DataTable noInstrumento5(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        Conexion conectar = new Conexion();
        string where = "";
        string consulta = "";
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


        // string consulta = "SELECT DISTINCT  lb1.coddocenteasesor as coddocenteasesor2_1, lb2.coddocenteasesor as coddocenteaseso_r5 FROM lbase_respuesta as lb1 full OUTER JOIN lbase_respuesta as lb2 on lb1.coddocenteasesor = lb2.coddocenteasesor and lb2.fase = 'intermedia' and lb2.codinstrumento = '5' WHERE lb1.fase = 'intermedia' and lb1.codinstrumento = '2.1'";
        consulta = "SELECT DISTINCT     lb1.coddocenteasesor AS coddocenteasesor2_1,    lb2.coddocenteasesor AS coddocenteasesor_5, gdep.nombre AS nombredepartamento,  gmun.nombre AS nombremunicipio, iin.dane,   iin.nombre AS nombreins,    initcap(    CONCAT ( ID.nombre, ' ', ID.apellido )) AS nombredocente,   isede.dane AS danesede, isede.nombre nombresede FROM    lbase_respuesta AS lb1  LEFT JOIN lbase_respuesta AS lb2 ON lb1.coddocenteasesor = lb2.coddocenteasesor     AND lb2.fase = 'intermedia'     AND lb2.codinstrumento = '5'    INNER JOIN lbase_docenteasesor lda ON lda.codigo = lb1.coddocenteasesor INNER JOIN ins_gradodocente igd ON lda.codgradodocente = igd.cod    INNER JOIN ins_docente ID ON igd.identificacion = ID.identificacion INNER JOIN ins_sede isede ON isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio   INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE  lb1.fase = 'intermedia'         and lb2.coddocenteasesor is null" + where;
        conectar.CrearComando(consulta);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

      public DataTable Instrumento5(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        Conexion conectar = new Conexion();
        string where = "";
        string consulta = "";
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


        // string consulta = "SELECT DISTINCT  lb1.coddocenteasesor as coddocenteasesor2_1, lb2.coddocenteasesor as coddocenteaseso_r5 FROM lbase_respuesta as lb1 full OUTER JOIN lbase_respuesta as lb2 on lb1.coddocenteasesor = lb2.coddocenteasesor and lb2.fase = 'intermedia' and lb2.codinstrumento = '5' WHERE lb1.fase = 'intermedia' and lb1.codinstrumento = '2.1'";
        consulta = "SELECT DISTINCT     lb1.coddocenteasesor AS coddocenteasesor2_1,    gdep.nombre AS nombredepartamento,  gmun.nombre AS nombremunicipio, iin.dane,   iin.nombre AS nombreins,    initcap(    CONCAT ( ID.nombre, ' ', ID.apellido )) AS nombredocente,   isede.dane AS danesede, isede.nombre nombresede FROM    lbase_respuesta AS lb1  INNER JOIN lbase_docenteasesor lda ON lda.codigo = lb1.coddocenteasesor     INNER JOIN ins_gradodocente igd ON lda.codgradodocente = igd.cod    INNER JOIN ins_docente ID ON igd.identificacion = ID.identificacion INNER JOIN ins_sede isede ON isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio   INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE  lb1.fase = 'intermedia' and lb1.codinstrumento ='5'         " + where;
        conectar.CrearComando(consulta);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

     public DataTable Instrumento21(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        Conexion conectar = new Conexion();
        string where = "";
        string consulta = "";
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


        // string consulta = "SELECT DISTINCT  lb1.coddocenteasesor as coddocenteasesor2_1, lb2.coddocenteasesor as coddocenteaseso_r5 FROM lbase_respuesta as lb1 full OUTER JOIN lbase_respuesta as lb2 on lb1.coddocenteasesor = lb2.coddocenteasesor and lb2.fase = 'intermedia' and lb2.codinstrumento = '5' WHERE lb1.fase = 'intermedia' and lb1.codinstrumento = '2.1'";
        consulta = "SELECT DISTINCT     lb1.coddocenteasesor AS coddocenteasesor2_1,    gdep.nombre AS nombredepartamento,  gmun.nombre AS nombremunicipio, iin.dane,   iin.nombre AS nombreins,    initcap(    CONCAT ( ID.nombre, ' ', ID.apellido )) AS nombredocente,   isede.dane AS danesede, isede.nombre nombresede FROM    lbase_respuesta AS lb1  INNER JOIN lbase_docenteasesor lda ON lda.codigo = lb1.coddocenteasesor     INNER JOIN ins_gradodocente igd ON lda.codgradodocente = igd.cod    INNER JOIN ins_docente ID ON igd.identificacion = ID.identificacion INNER JOIN ins_sede isede ON isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio   INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE  lb1.fase = 'intermedia' and lb1.codinstrumento ='2.1' " + where;
        conectar.CrearComando(consulta);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


     public DataTable noInstrumento21(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        Conexion conectar = new Conexion();
        string where = "";
        string consulta = "";
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


        // string consulta = "SELECT DISTINCT  lb1.coddocenteasesor as coddocenteasesor2_1, lb2.coddocenteasesor as coddocenteaseso_r5 FROM lbase_respuesta as lb1 full OUTER JOIN lbase_respuesta as lb2 on lb1.coddocenteasesor = lb2.coddocenteasesor and lb2.fase = 'intermedia' and lb2.codinstrumento = '5' WHERE lb1.fase = 'intermedia' and lb1.codinstrumento = '2.1'";
        consulta = "SELECT DISTINCT     lb1.coddocenteasesor AS coddocenteasesor2_1,    lb2.coddocenteasesor AS coddocenteasesor_5, gdep.nombre AS nombredepartamento,  gmun.nombre AS nombremunicipio, iin.dane,   iin.nombre AS nombreins,    initcap(    CONCAT ( ID.nombre, ' ', ID.apellido )) AS nombredocente,   isede.dane AS danesede, isede.nombre nombresede FROM    lbase_respuesta AS lb1  LEFT JOIN lbase_respuesta AS lb2 ON lb1.coddocenteasesor = lb2.coddocenteasesor     AND lb2.fase = 'intermedia'     AND lb2.codinstrumento = '2.1'  INNER JOIN lbase_docenteasesor lda ON lda.codigo = lb1.coddocenteasesor INNER JOIN ins_gradodocente igd ON lda.codgradodocente = igd.cod    INNER JOIN ins_docente ID ON igd.identificacion = ID.identificacion INNER JOIN ins_sede isede ON isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio   INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE  lb1.fase = 'intermedia'         and lb2.coddocenteasesor is null " + where;
        conectar.CrearComando(consulta);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

     public DataTable detalleRectorIntermedia()   
    {
        Conexion conectar = new Conexion();
        string consulta = "SELECT DISTINCT  codinstiasesor, ii.dane as daneins, codinstrumento, ii.nombre as nombrein,  gmun.nombre AS nombremunicipio, gdep.nombre as nombredepartamento   FROM  lbase_respuestainstitucional AS lri   INNER JOIN lbase_institucionasesor lia ON lia.codigo = lri.codinstiasesor   INNER JOIN ins_institucion ii ON ii.codigo = lia.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = ii.codmunicipio    INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE lri.fase = 'intermedia' ORDER BY nombrein asc";
        conectar.CrearComando(consulta);
        DataTable total = conectar.traerdata();
        if (total != null)
            return total;
        else
            return null;
    }


     public DataTable busquedadetalleRectorIntermedia(string coddepartamento, string codmunicipio,string codinstitucion)
    {
        string where = "";
       
        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND gdep.cod = '" +coddepartamento+"'";

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  ii.codigo = " + codinstitucion;
                              
                            }
                        }
                    }
                }
            }
        }
        Conexion conectar = new Conexion();
        string consulta = "SELECT DISTINCT  codinstiasesor, ii.dane as daneins, codinstrumento, ii.nombre as nombrein,  gmun.nombre AS nombremunicipio, gdep.nombre as nombredepartamento   FROM  lbase_respuestainstitucional AS lri   INNER JOIN lbase_institucionasesor lia ON lia.codigo = lri.codinstiasesor   INNER JOIN ins_institucion ii ON ii.codigo = lia.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = ii.codmunicipio    INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE lri.fase = 'intermedia'  "+ where;
        conectar.CrearComando(consulta);
        DataTable total = conectar.traerdata();
        if (total != null)
            return total;
        else
            return null;
    }
    
     public DataTable destalleSedetableta(string coddepartamento, string codmunicipio, string codinstitucion,string respuesta)
     {
         string where = "";

         if (coddepartamento != "")
         {
             if (coddepartamento != "null")
             {
                 where = " AND gdep.cod = '" + coddepartamento + "'";

                 if (codmunicipio != "")
                 {
                     if (codmunicipio != "null")
                     {
                         where = where + " AND  gmun.cod = " + codmunicipio;

                         if (codinstitucion != "")
                         {
                             if (codinstitucion != "null")
                             {
                                 where = where + " AND  ii.codigo = " + codinstitucion;

                             }
                         }
                     }
                 }
             }
         }
         if(respuesta == "si"){
             where = where + "AND respuesta = 'si'";

         }
         else if (respuesta == "no")
         {
             where = where + "AND respuesta = 'no'";
         }
         Conexion conectar = new Conexion();
         string consulta = "SELECT gdep.nombre as nombredepartamento,gmun.nombre as nombremunicipio,iin.dane ,iin.nombre as nombreins,isede.dane as sededane, isede.nombre as sedenombre, lbr.respuesta FROM lbase_respuestasede lbr INNER JOIN lbase_sedeasesor lbs ON lbs.codigo = lbr.codsedeasesor INNER JOIN ins_sede isede ON isede.codigo = lbs.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE codpregunta = '6' AND fase = 'intermedia' and respuesta != 'undefined' " + where;
         conectar.CrearComando(consulta);
         DataTable total = conectar.traerdata();
         if (total != null)
             return total;
         else
             return null;
     }


public DataTable modcorriculo(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string respuesta)
    {
        Conexion conectar = new Conexion();
        string where = "";
        string consulta = "";
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
         if(respuesta == "si"){
             where = where + " and lr.respuesta = 'si' ";
         }
         else if (respuesta == "no")
         {
             where = where + " and lr.respuesta = 'no' ";
         }
       // consulta = "SELECT lbcd.codgradodocente, initcap(CONCAT ( ID.nombre, ' ', ID.apellido )) AS nombredocente,ID.identificacion, gdep.nombre AS nombredepartamento, gmun.nombre AS nombremunicipio, iin.dane, iin.nombre AS nombreins, isede.dane AS danesede,    isede.nombre as nombresede FROM lbase_docenteasesor lbcd INNER JOIN lbase_respuesta lr ON lr.coddocenteasesor = lbcd.codigo INNER JOIN ins_gradodocente igd ON lbcd.codgradodocente = igd.cod INNER JOIN ins_docente ID ON igd.identificacion = ID.identificacion INNER JOIN ins_sede isede ON isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE lr.fase = 'impacto' " + where + "   GROUP BY lbcd.codgradodocente,nombredocente,nombredepartamento, nombremunicipio,iin.dane,nombreins,danesede,danesede,nombresede,ID.identificacion ";
         consulta = "SELECT gdep.nombre AS nombredepartamento,  gmun.nombre AS nombremunicipio, iin.dane,   iin.nombre AS nombreins,    isede.dane AS danesede, isede.nombre AS nombresede, count(lr.respuesta), lr.respuesta FROM  lbase_docenteasesor lbcd    INNER JOIN lbase_respuesta lr ON lr.coddocenteasesor = lbcd.codigo  INNER JOIN ins_gradodocente igd ON lbcd.codgradodocente = igd.cod   INNER JOIN ins_docente ID ON igd.identificacion = ID.identificacion INNER JOIN ins_sede isede ON isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio   INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE  lr.codpregunta = '1'    AND lr.codinstrumento = '2.1'   AND lr.fase = 'intermedia' " + where + " GROUP BY    nombredepartamento,nombremunicipio,iin.dane,nombreins,danesede,nombresede,lr.respuesta";
       conectar.CrearComando(consulta);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }



   /** 
   fin
    Consulta intermedia
    */
 
  /**
     * Consultas Evaluacion Impacto
     */
    public DataTable totalImpacto(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        Conexion conectar = new Conexion();
        string where = "";
        string consulta = "";
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
        consulta ="Select distinct t.* from (SELECT initcap(    CONCAT ( ID.nombre, ' ', ID.apellido )) AS nombredocente,   ID.identificacion,  gdep.nombre AS nombredepartamento,  gmun.nombre AS nombremunicipio, iin.dane,   iin.nombre AS nombreins,    isede.dane AS danesede, isede.nombre AS nombresede FROM lbase_docenteasesor lbcd    INNER JOIN lbase_respuesta lr ON lr.coddocenteasesor = lbcd.codigo  INNER JOIN ins_gradodocente igd ON lbcd.codgradodocente = igd.cod   INNER JOIN ins_docente ID ON igd.identificacion = ID.identificacion INNER JOIN ins_sede isede ON isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio   INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE  lr.fase = 'impacto' " + where + "GROUP BY  lbcd.codgradodocente,   nombredocente,  nombredepartamento, nombremunicipio,    iin.dane,   nombreins,  danesede,   danesede,   nombresede,     ID.identificacion order by ID.identificacion asc) t";
        //consulta = "SELECT lbcd.codgradodocente, initcap(CONCAT ( ID.nombre, ' ', ID.apellido )) AS nombredocente,ID.identificacion, gdep.nombre AS nombredepartamento, gmun.nombre AS nombremunicipio, iin.dane, iin.nombre AS nombreins, isede.dane AS danesede,    isede.nombre as nombresede FROM lbase_docenteasesor lbcd INNER JOIN lbase_respuesta lr ON lr.coddocenteasesor = lbcd.codigo INNER JOIN ins_gradodocente igd ON lbcd.codgradodocente = igd.cod INNER JOIN ins_docente ID ON igd.identificacion = ID.identificacion INNER JOIN ins_sede isede ON isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE lr.fase = 'impacto' " + where + "   GROUP BY lbcd.codgradodocente,nombredocente,nombredepartamento, nombremunicipio,iin.dane,nombreins,danesede,danesede,nombresede,ID.identificacion ";

       // consulta = "SELECT DISTINCT lb1.coddocenteasesor AS coddocenteasesor2_1, gdep.nombre AS nombredepartamento, gmun.nombre AS nombremunicipio, iin.dane, iin.nombre AS nombreins, initcap(CONCAT ( ID.nombre, ' ', ID.apellido )) AS nombredocente, isede.dane AS danesede, isede.nombre nombresede  FROM lbase_respuesta AS lb1 INNER JOIN lbase_docenteasesor lda ON lda.codigo = lb1.coddocenteasesor INNER JOIN ins_gradodocente igd ON lda.codgradodocente = igd.cod INNER JOIN ins_docente ID ON igd.identificacion = ID.identificacion INNER JOIN ins_sede isede ON isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE lb1.fase = 'impacto' " + where;
        
        //consulta = "SELECT DISTINCT   lb1.coddocenteasesor AS coddocenteasesor2_1,    gdep.nombre AS nombredepartamento,  gmun.nombre AS nombremunicipio, iin.dane,   iin.nombre AS nombreins,    initcap(    CONCAT ( ID.nombre, ' ', ID.apellido )) AS nombredocente,   isede.dane AS danesede, isede.nombre nombresede FROM    lbase_respuesta AS lb1  INNER JOIN lbase_docenteasesor lda ON lda.codigo = lb1.coddocenteasesor     INNER JOIN ins_gradodocente igd ON lda.codgradodocente = igd.cod    INNER JOIN ins_docente ID ON igd.identificacion = ID.identificacion INNER JOIN ins_sede isede ON isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio   INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE  lb1.fase = 'intermedia'" + where;
        conectar.CrearComando(consulta);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }



    public DataRow TotalInstitucionesImpacto()
    {
        Conexion conectar = new Conexion();
        string consulta = "SELECT count (DISTINCT codinstiasesor) from lbase_respuestainstitucional as lri WHERE fase = 'impacto' ";
        conectar.CrearComando(consulta);
        DataRow total = conectar.traerfila();
        return total;

    }

    public DataRow TotalSedeImpacto()
    {
        Conexion conectar = new Conexion();
        string consulta = "SELECT count(Distinct codsedeasesor) from lbase_respuestasede as lri WHERE fase = 'impacto'";
        conectar.CrearComando(consulta);
        DataRow total = conectar.traerfila();
        return total;

    }

    public DataRow TotalEncuestaEstudiantes()
    {
        Conexion conectar = new Conexion();
        string consulta = "select count(codpregunta) from lbase_respuestainstitucional  where fase = 'impacto' and codinstrumento ='6' and codpregunta ='1'";
        conectar.CrearComando(consulta);
        DataRow total = conectar.traerfila();
        return total;

    }

     public DataTable InstrumentoImpacto21(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        Conexion conectar = new Conexion();
        string where = "";
        string consulta = "";
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

        consulta = "    Select distinct t.* from (SELECT    initcap(    CONCAT ( ID.nombre, ' ', ID.apellido )) AS nombredocente,   ID.identificacion,  gdep.nombre AS nombredepartamento,  gmun.nombre AS nombremunicipio, iin.dane,   iin.nombre AS nombreins,    isede.dane AS danesede, isede.nombre AS nombresede FROM lbase_docenteasesor lbcd    INNER JOIN lbase_respuesta lr ON lr.coddocenteasesor = lbcd.codigo  INNER JOIN ins_gradodocente igd ON lbcd.codgradodocente = igd.cod   INNER JOIN ins_docente ID ON igd.identificacion = ID.identificacion INNER JOIN ins_sede isede ON isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio   INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE  lr.fase = 'impacto'  and lr.codinstrumento ='2.1'  "+where+" GROUP BY  lbcd.codgradodocente,   nombredocente,  nombredepartamento, nombremunicipio,    iin.dane,   nombreins,  danesede,   danesede,   nombresede,     ID.identificacion order by ID.identificacion asc) t";
        // string consulta = "SELECT DISTINCT  lb1.coddocenteasesor as coddocenteasesor2_1, lb2.coddocenteasesor as coddocenteaseso_r5 FROM lbase_respuesta as lb1 full OUTER JOIN lbase_respuesta as lb2 on lb1.coddocenteasesor = lb2.coddocenteasesor and lb2.fase = 'intermedia' and lb2.codinstrumento = '5' WHERE lb1.fase = 'intermedia' and lb1.codinstrumento = '2.1'";
       //consulta = "SELECT DISTINCT    lb1.coddocenteasesor AS coddocenteasesor2_1,    gdep.nombre AS nombredepartamento,  gmun.nombre AS nombremunicipio, iin.dane,   iin.nombre AS nombreins,    initcap(    CONCAT ( ID.nombre, ' ', ID.apellido )) AS nombredocente,   isede.dane AS danesede, isede.nombre nombresede FROM    lbase_respuesta AS lb1  INNER JOIN lbase_docenteasesor lda ON lda.codigo = lb1.coddocenteasesor     INNER JOIN ins_gradodocente igd ON lda.codgradodocente = igd.cod    INNER JOIN ins_docente ID ON igd.identificacion = ID.identificacion INNER JOIN ins_sede isede ON isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio   INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE  lb1.fase = 'impacto' and lb1.codinstrumento ='2.1' " + where;
        conectar.CrearComando(consulta);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable noInstrumentoImpacto21(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        Conexion conectar = new Conexion();
        string where = "";
        string consulta = "";
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


        // string consulta = "SELECT DISTINCT  lb1.coddocenteasesor as coddocenteasesor2_1, lb2.coddocenteasesor as coddocenteaseso_r5 FROM lbase_respuesta as lb1 full OUTER JOIN lbase_respuesta as lb2 on lb1.coddocenteasesor = lb2.coddocenteasesor and lb2.fase = 'intermedia' and lb2.codinstrumento = '5' WHERE lb1.fase = 'intermedia' and lb1.codinstrumento = '2.1'";
        consulta = "SELECT DISTINCT     lb1.coddocenteasesor AS coddocenteasesor2_1,    lb2.coddocenteasesor AS coddocenteasesor_5, gdep.nombre AS nombredepartamento,  gmun.nombre AS nombremunicipio, iin.dane,   iin.nombre AS nombreins,    initcap(    CONCAT ( ID.nombre, ' ', ID.apellido )) AS nombredocente,   isede.dane AS danesede, isede.nombre nombresede FROM    lbase_respuesta AS lb1  LEFT JOIN lbase_respuesta AS lb2 ON lb1.coddocenteasesor = lb2.coddocenteasesor     AND lb2.fase = 'impacto'    AND lb2.codinstrumento = '2.1'  INNER JOIN lbase_docenteasesor lda ON lda.codigo = lb1.coddocenteasesor INNER JOIN ins_gradodocente igd ON lda.codgradodocente = igd.cod    INNER JOIN ins_docente ID ON igd.identificacion = ID.identificacion INNER JOIN ins_sede isede ON isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio   INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE  lb1.fase = 'impacto'        and lb2.coddocenteasesor is null " + where;
        conectar.CrearComando(consulta);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    public DataTable InstrumentoImpacto5(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        Conexion conectar = new Conexion();
        string where = "";
        string consulta = "";
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

        consulta = "    Select distinct t.* from (SELECT    initcap(    CONCAT ( ID.nombre, ' ', ID.apellido )) AS nombredocente,   ID.identificacion,  gdep.nombre AS nombredepartamento,  gmun.nombre AS nombremunicipio, iin.dane,   iin.nombre AS nombreins,    isede.dane AS danesede, isede.nombre AS nombresede FROM lbase_docenteasesor lbcd    INNER JOIN lbase_respuesta lr ON lr.coddocenteasesor = lbcd.codigo  INNER JOIN ins_gradodocente igd ON lbcd.codgradodocente = igd.cod   INNER JOIN ins_docente ID ON igd.identificacion = ID.identificacion INNER JOIN ins_sede isede ON isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio   INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE  lr.fase = 'impacto'  and lr.codinstrumento ='5'  "+where+" GROUP BY  lbcd.codgradodocente,   nombredocente,  nombredepartamento, nombremunicipio,    iin.dane,   nombreins,  danesede,   danesede,   nombresede,     ID.identificacion order by ID.identificacion asc) t";
        // string consulta = "SELECT DISTINCT  lb1.coddocenteasesor as coddocenteasesor2_1, lb2.coddocenteasesor as coddocenteaseso_r5 FROM lbase_respuesta as lb1 full OUTER JOIN lbase_respuesta as lb2 on lb1.coddocenteasesor = lb2.coddocenteasesor and lb2.fase = 'intermedia' and lb2.codinstrumento = '5' WHERE lb1.fase = 'intermedia' and lb1.codinstrumento = '2.1'";
       // consulta = "SELECT DISTINCT   lb1.coddocenteasesor AS coddocenteasesor2_1,    lb2.coddocenteasesor AS coddocenteasesor_5, gdep.nombre AS nombredepartamento,  gmun.nombre AS nombremunicipio, iin.dane,   iin.nombre AS nombreins,    initcap(    CONCAT ( ID.nombre, ' ', ID.apellido )) AS nombredocente,   isede.dane AS danesede, isede.nombre nombresede FROM    lbase_respuesta AS lb1  LEFT JOIN lbase_respuesta AS lb2 ON lb1.coddocenteasesor = lb2.coddocenteasesor     AND lb2.fase = 'impacto'    AND lb2.codinstrumento = '5'    INNER JOIN lbase_docenteasesor lda ON lda.codigo = lb1.coddocenteasesor INNER JOIN ins_gradodocente igd ON lda.codgradodocente = igd.cod    INNER JOIN ins_docente ID ON igd.identificacion = ID.identificacion INNER JOIN ins_sede isede ON isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio   INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE  lb1.fase = 'impacto'        and lb2.coddocenteasesor is null " + where;
        conectar.CrearComando(consulta);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable noInstrumentoImpacto4(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        Conexion conectar = new Conexion();
        string where = "";
        string consulta = "";
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


        // string consulta = "SELECT DISTINCT  lb1.coddocenteasesor as coddocenteasesor2_1, lb2.coddocenteasesor as coddocenteaseso_r5 FROM lbase_respuesta as lb1 full OUTER JOIN lbase_respuesta as lb2 on lb1.coddocenteasesor = lb2.coddocenteasesor and lb2.fase = 'intermedia' and lb2.codinstrumento = '5' WHERE lb1.fase = 'intermedia' and lb1.codinstrumento = '2.1'";
        consulta = "SELECT DISTINCT     lb1.coddocenteasesor AS coddocenteasesor2_1,    lb2.coddocenteasesor AS coddocenteasesor_5, gdep.nombre AS nombredepartamento,  gmun.nombre AS nombremunicipio, iin.dane,   iin.nombre AS nombreins,    initcap(    CONCAT ( ID.nombre, ' ', ID.apellido )) AS nombredocente,   isede.dane AS danesede, isede.nombre nombresede FROM    lbase_respuesta AS lb1  LEFT JOIN lbase_respuesta AS lb2 ON lb1.coddocenteasesor = lb2.coddocenteasesor     AND lb2.fase = 'impacto'    AND lb2.codinstrumento = '4'    INNER JOIN lbase_docenteasesor lda ON lda.codigo = lb1.coddocenteasesor INNER JOIN ins_gradodocente igd ON lda.codgradodocente = igd.cod    INNER JOIN ins_docente ID ON igd.identificacion = ID.identificacion INNER JOIN ins_sede isede ON isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio   INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE  lb1.fase = 'impacto'        and lb2.coddocenteasesor is null " + where;
        conectar.CrearComando(consulta);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable noInstrumentoImpacto5(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        Conexion conectar = new Conexion();
        string where = "";
        string consulta = "";
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


        // string consulta = "SELECT DISTINCT  lb1.coddocenteasesor as coddocenteasesor2_1, lb2.coddocenteasesor as coddocenteaseso_r5 FROM lbase_respuesta as lb1 full OUTER JOIN lbase_respuesta as lb2 on lb1.coddocenteasesor = lb2.coddocenteasesor and lb2.fase = 'intermedia' and lb2.codinstrumento = '5' WHERE lb1.fase = 'intermedia' and lb1.codinstrumento = '2.1'";
        consulta = "select  Distinct t.* from (SELECT DISTINCT     lb1.coddocenteasesor AS coddocenteasesor2_1,    gdep.nombre AS nombredepartamento,  gmun.nombre AS nombremunicipio, iin.dane,   iin.nombre AS nombreins,    initcap(    CONCAT ( ID.nombre, ' ', ID.apellido )) AS nombredocente,   isede.dane AS danesede, isede.nombre nombresede FROM    lbase_respuesta AS lb1  INNER JOIN lbase_docenteasesor lda ON lda.codigo = lb1.coddocenteasesor     INNER JOIN ins_gradodocente igd ON lda.codgradodocente = igd.cod    INNER JOIN ins_docente ID ON igd.identificacion = ID.identificacion INNER JOIN ins_sede isede ON isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio   INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE  lb1.fase = 'impacto' and lb1.codinstrumento ='5' " + where+") t";
        conectar.CrearComando(consulta);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    public DataTable InstrumentoImpacto4(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        Conexion conectar = new Conexion();
        string where = "";
        string consulta = "";
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

        consulta = "    Select distinct t.* from (SELECT    initcap(    CONCAT ( ID.nombre, ' ', ID.apellido )) AS nombredocente,   ID.identificacion,  gdep.nombre AS nombredepartamento,  gmun.nombre AS nombremunicipio, iin.dane,   iin.nombre AS nombreins,    isede.dane AS danesede, isede.nombre AS nombresede FROM lbase_docenteasesor lbcd    INNER JOIN lbase_respuesta lr ON lr.coddocenteasesor = lbcd.codigo  INNER JOIN ins_gradodocente igd ON lbcd.codgradodocente = igd.cod   INNER JOIN ins_docente ID ON igd.identificacion = ID.identificacion INNER JOIN ins_sede isede ON isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio   INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE  lr.fase = 'impacto'  and lr.codinstrumento ='4' "+where+" GROUP BY  lbcd.codgradodocente,   nombredocente,  nombredepartamento, nombremunicipio,    iin.dane,   nombreins,  danesede,   danesede,   nombresede,     ID.identificacion order by ID.identificacion asc) t";
        // string consulta = "SELECT DISTINCT  lb1.coddocenteasesor as coddocenteasesor2_1, lb2.coddocenteasesor as coddocenteaseso_r5 FROM lbase_respuesta as lb1 full OUTER JOIN lbase_respuesta as lb2 on lb1.coddocenteasesor = lb2.coddocenteasesor and lb2.fase = 'intermedia' and lb2.codinstrumento = '5' WHERE lb1.fase = 'intermedia' and lb1.codinstrumento = '2.1'";
       // consulta = "SELECT DISTINCT   lb1.coddocenteasesor AS coddocenteasesor2_1,    gdep.nombre AS nombredepartamento,  gmun.nombre AS nombremunicipio, iin.dane,   iin.nombre AS nombreins,    initcap(    CONCAT ( ID.nombre, ' ', ID.apellido )) AS nombredocente,   isede.dane AS danesede, isede.nombre nombresede FROM    lbase_respuesta AS lb1  INNER JOIN lbase_docenteasesor lda ON lda.codigo = lb1.coddocenteasesor     INNER JOIN ins_gradodocente igd ON lda.codgradodocente = igd.cod    INNER JOIN ins_docente ID ON igd.identificacion = ID.identificacion INNER JOIN ins_sede isede ON isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio   INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE  lb1.fase = 'impacto' and lb1.codinstrumento ='4' " + where;
        conectar.CrearComando(consulta);
        DataTable resp = conectar.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    /**
     * Institucion
     */
    public DataTable detalleInstitucionImpacto()
    {
        Conexion conectar = new Conexion();
        string consulta = "SELECT DISTINCT codinstiasesor, ii.dane AS daneins, ii.nombre AS nombrein, gmun.nombre AS nombremunicipio, gdep.nombre AS nombredepartamento FROM lbase_respuestainstitucional AS lri    INNER JOIN lbase_institucionasesor lia ON lia.codigo = lri.codinstiasesor INNER JOIN ins_institucion ii ON ii.codigo = lia.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = ii.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE lri.fase = 'impacto' ";
        conectar.CrearComando(consulta);
        DataTable total = conectar.traerdata();
        if (total != null)
            return total;
        else
            return null;
    }

    public DataTable busquedadetalleInstitucion(string coddepartamento, string codmunicipio, string codinstitucion)
    {
        string where = "";

        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND gdep.cod = '" + coddepartamento + "'";

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  ii.codigo = " + codinstitucion;

                            }
                        }
                    }
                }
            }
        }
        Conexion conectar = new Conexion();
        string consulta = "SELECT DISTINCT codinstiasesor, ii.dane AS daneins, ii.nombre AS nombrein, gmun.nombre AS nombremunicipio, gdep.nombre AS nombredepartamento FROM lbase_respuestainstitucional AS lri    INNER JOIN lbase_institucionasesor lia ON lia.codigo = lri.codinstiasesor INNER JOIN ins_institucion ii ON ii.codigo = lia.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = ii.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE lri.fase = 'impacto'  " + where;
        conectar.CrearComando(consulta);
        DataTable total = conectar.traerdata();
        if (total != null)
            return total;
        else
            return null;
    }

    /**
     * Fin institucion
     */

    /**
     * Sede
     */
    public DataTable detalleSedesImpacto()
    {
        Conexion conectar = new Conexion();
        string consulta = "SELECT DISTINCT (codsedeasesor),ii.dane AS daneins,ii.nombre AS nombrein,ins.dane as danesede, ins.nombre as monbresede,gmun.nombre AS nombremunicipio,gdep.nombre AS nombredepartamento from lbase_respuestasede as lr INNER JOIN lbase_sedeasesor ls on ls.codigo = lr.codsedeasesor INNER JOIN ins_sede ins on ins.codigo = ls.codsede INNER JOIN ins_institucion ii ON ii.codigo = ins.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = ii.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE fase = 'impacto'  ";
        conectar.CrearComando(consulta);
        DataTable total = conectar.traerdata();
        if (total != null)
            return total;
        else
            return null;
    }

    public DataTable busquedadetalleSede(string coddepartamento, string codmunicipio, string codinstitucion)
    {
        string where = "";

        if (coddepartamento != "")
        {
            if (coddepartamento != "null")
            {
                where = " AND gdep.cod = '" + coddepartamento + "'";

                if (codmunicipio != "")
                {
                    if (codmunicipio != "null")
                    {
                        where = where + " AND  gmun.cod = " + codmunicipio;

                        if (codinstitucion != "")
                        {
                            if (codinstitucion != "null")
                            {
                                where = where + " AND  ii.codigo = " + codinstitucion;

                            }
                        }
                    }
                }
            }
        }
        Conexion conectar = new Conexion();
        string consulta = "SELECT DISTINCT (codsedeasesor),ii.dane AS daneins,ii.nombre AS nombrein,ins.dane as danesede, ins.nombre as monbresede,gmun.nombre AS nombremunicipio,gdep.nombre AS nombredepartamento from lbase_respuestasede as lr INNER JOIN lbase_sedeasesor ls on ls.codigo = lr.codsedeasesor INNER JOIN ins_sede ins on ins.codigo = ls.codsede INNER JOIN ins_institucion ii ON ii.codigo = ins.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = ii.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE fase = 'impacto'   " + where;
        conectar.CrearComando(consulta);
        DataTable total = conectar.traerdata();
        if (total != null)
            return total;
        else
            return null;
    }

    /**
     * fin Sede
     */
    /**
     * Encuesta Estudiante
     */
      public DataTable detalleEstudiantes()
    {
        Conexion conectar = new Conexion();
       string consulta ="SELECT ii.dane AS daneins, ii.nombre AS nombrein,  gmun.nombre AS nombremunicipio, gdep.nombre AS nombredepartamento,  count(codpregunta) FROM lbase_respuestainstitucional AS lri INNER JOIN lbase_institucionasesor lia ON lia.codigo = lri.codinstiasesor   INNER JOIN ins_institucion ii ON ii.codigo = lia.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = ii.codmunicipio    INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE  fase = 'impacto'    AND codinstrumento = '6'    AND codpregunta = '2'   GROUP BY daneins,nombrein,nombremunicipio,nombredepartamento";
          conectar.CrearComando(consulta);
        DataTable total = conectar.traerdata();
        if (total != null)
            return total;
        else
            return null;
    }

      public DataTable busquedadetalleEstudiantes(string coddepartamento, string codmunicipio, string codinstitucion)
      {
          string where = "";

          if (coddepartamento != "")
          {
              if (coddepartamento != "null")
              {
                  where = " AND gdep.cod = '" + coddepartamento + "'";

                  if (codmunicipio != "")
                  {
                      if (codmunicipio != "null")
                      {
                          where = where + " AND  gmun.cod = " + codmunicipio;

                          if (codinstitucion != "")
                          {
                              if (codinstitucion != "null")
                              {
                                  where = where + " AND  ii.codigo = " + codinstitucion;

                              }
                          }
                      }
                  }
              }
          }
          Conexion conectar = new Conexion();
          string consulta = "SELECT ii.dane AS daneins, ii.nombre AS nombrein,  gmun.nombre AS nombremunicipio, gdep.nombre AS nombredepartamento,  count(codpregunta) FROM lbase_respuestainstitucional AS lri INNER JOIN lbase_institucionasesor lia ON lia.codigo = lri.codinstiasesor   INNER JOIN ins_institucion ii ON ii.codigo = lia.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = ii.codmunicipio    INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE  fase = 'impacto'    AND codinstrumento = '6'    AND codpregunta = '2'   "+where+" GROUP BY daneins,nombrein,nombremunicipio,nombredepartamento";

          conectar.CrearComando(consulta);
          DataTable total = conectar.traerdata();
          if (total != null)
              return total;
          else
              return null;
      }
    /**
     * Fin Enciensta Estudiantes 
     * /


    /**
     * Fin 
     * Consultas Evaluacion Impacto
     */

         public DataRow totalUsoconectividadformacionestudiantesxFrecuencia(string frecuencia)
    {
        Conexion conector = new Conexion();
        //string consulta = "SELECT COUNT (DISTINCT codsedeasesor) as total FROM lbase_respuestasede WHERE codpregunta = '9' and fase = 'intermedia' and codsubpregunta = '3' AND respuesta = '" + frecuencia + "'";
        string consulta = "SELECT  count (l.*) as total FROM lbase_respuestasede l WHERE l.codigo IN ( SELECT MAX ( codigo ) FROM lbase_respuestasede WHERE codpregunta = '9' AND fase = 'intermedia' AND codsubpregunta = '1' GROUP BY codsedeasesor ) AND respuesta = '" + frecuencia + "'";
        conector.CrearComando(consulta);
        DataRow dato = conector.traerfila();
        if (dato != null)
            return dato;
        else
            return null;
    }

     public DataTable detalleUsoconectividadformacionestudiantesxFrecuencia(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string respuesta)
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

        if (respuesta != "")
        {
            where = where + " AND lbr.respuesta = '" + respuesta + "' ";
        }

        Conexion conector = new Conexion();
        string consulta = "SELECT  lbr.codsedeasesor ,  lbr.respuesta,  isede.dane AS danesede, isede.nombre nombresede,    iin.dane,   iin.nombre AS nombreins,    gmun.nombre AS nombremunicipio, gdep.nombre AS nombredepartamento FROM lbase_respuestasede AS lbr   INNER JOIN lbase_sedeasesor lbs ON lbs.codigo = lbr.codsedeasesor   INNER JOIN ins_sede isede ON isede.codigo = lbs.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE lbr.codigo IN ( SELECT MAX ( codigo ) FROM lbase_respuestasede WHERE codpregunta = '9' AND fase = 'intermedia' AND codsubpregunta = '1' GROUP BY codsedeasesor) " + where;
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