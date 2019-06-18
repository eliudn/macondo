using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Services;

/// <summary>
/// Descripción breve de Consultas
/// </summary>
public class Consultas
{
	public Consultas()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public DataTable totalGruposInvestigacionInscritos()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM gr_convocatoriasgrupos";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable totalespaciosapropiacion()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT ea.*, an.nombre as anio, a.nombre as area, ps.nombregrupo, s.nombre as sede, i.nombre as institucion, m.nombre as municipio from ep_espaciosapropiacion ea INNER JOIN pro_proyectosede ps ON ps.codigo=ea.codproyectosede INNER JOIN pro_areas a ON a.codigo=ps.codarea INNER JOIN ins_sede s ON s.codigo=ps.codsede INNER JOIN ins_institucion i ON i.codigo=s.codinstitucion INNER JOIN geo_municipios m ON m.cod=i.codmunicipio INNER JOIN ins_anio an ON an.codigo=ea.codanio ORDER BY ea.codigo DESC;";
        conector.CrearComando(consulta);
        //conector.AsignarParametroCadena("@tipo", tipo);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable totalKitPreestructurados(string estrategia, string momento, string actividad)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT est_repositoriocoordinador where  estrategia=@estrategia and momento=@momento and actividad=@actividad";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@estrategia", estrategia);
        conector.AsignarParametroCadena("@momento", momento);
        conector.AsignarParametroCadena("@actividad", actividad);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable totalestudiantesparticipantesgi(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string codgrupoinv)
    {
        Conexion conector = new Conexion();

        int numero = 6;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        cond[1] = string.Empty;  //sin municipio
        cond[2] = string.Empty;  //sin insittiucion
        cond[3] = string.Empty;  //sin sede
        cond[4] = string.Empty;  //sin sede
        cond[5] = string.Empty;  //sin sede

        if (coddepartamento != "" && coddepartamento != null)
        {
            cond[1] = "gmun.coddepartamento='" + coddepartamento + "'";  //con municipio
        }
        if (codmunicipio != "" && codmunicipio != null)
        {
            cond[2] = "iin.codmunicipio='" + codmunicipio + "'";  //con institución
        }
        if (codinstitucion != "" && codinstitucion != null)
        {
            cond[3] = "isede.codinstitucion='" + codinstitucion + "'";  //con sede
        }
        if (codinstitucion != "" && codinstitucion != null)
        {
            cond[4] = "pps.codsede='" + codsede + "'";  //con sede
        }
        if (codgrupoinv != "" && codgrupoinv != null)
        {
            cond[5] = "ppm.codproyectosede='" + codgrupoinv + "'";  //con sede
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

        string consulta = "SELECT DISTINCT(ppm.codestumatricula)  AS estugrupoinv, gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.nombre as nombreins, iin.dane, isede.nombre as nombresede, isede.dane as danesede, pps.nombregrupo, ppm.codestumatricula, iest.nombre, iest.apellido FROM pro_proyectomatricula ppm INNER JOIN pro_proyectosede pps ON pps.codigo = ppm.codproyectosede INNER JOIN ins_sede isede ON isede.codigo = pps.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento INNER JOIN ins_estumatricula em on em.codigo=ppm.codestumatricula INNER JOIN ins_estudiante iest on iest.codigo=em.codestudiante " + where;
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarInstEduBeneficiadas(string codMunicipio,string codZona)
    {
        Conexion conector = new Conexion();
        string where ="";

        if (codZona != "")
        {
            if (codMunicipio != "" && codMunicipio != null)
            {
                where = "where i.codmunicipio=" + codMunicipio + " AND i.codzona=" + codZona;
            }
            else
            {
                where = "where i.codzona=" + codZona;
            }
        }
        else 
        {
            if (codMunicipio != "" && codMunicipio != null)
            {
                where = "where i.codmunicipio=" + codMunicipio;
            }
            
        }

        string consulta = "select i.codigo as codinstitucion, d.nombre as departamento, m.nombre as municipio, i.nombre as institucion, i.dane, i.direccion, i.telefono, i.email, z.nombre as zona, concat_ws(' ',r.nombre,r.apellido) as nomrector, r.identificacion as iderector, r.telefono as telerector, r.email as emailrector from ins_institucion i inner join geo_municipios m on i.codmunicipio=m.cod inner join geo_departamentos d on d.cod=m.coddepartamento inner join ins_zona z on z.codigo=i.codzona inner join ins_rector r on r.identificacion=i.idrector left join lbase_institucionasesor ia on ia.codinstitucion=i.codigo " + where + " group by i.codigo, d.nombre, m.nombre, i.nombre, i.dane, i.direccion, i.telefono, i.email, z.nombre, r.nombre, r.apellido, r.identificacion, r.telefono, r.email order by i.nombre asc";
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

    public DataTable cargarSedesEduBeneficiadas(string codMunicipio,string codInstitucion, string codZona)
    {
        Conexion conector = new Conexion();
        
        int numero = 4;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        cond[1] = string.Empty;  //sin municipio
        cond[2] = string.Empty;  //sin insittiucion
        cond[3] = string.Empty;  //sin sede

        if (codMunicipio != "" && codMunicipio != null)
        {
            cond[1] = "s.codmunicipio='" + codMunicipio + "'";  //con municipio
        }
        if (codInstitucion != "" && codInstitucion != null)
        {
            cond[2] = "s.codinstitucion='" + codInstitucion + "'";  //con institución
        }
        if (codZona != "" && codZona != null)
        {
            cond[3] = "s.codZona='" + codZona + "'";  //con sede
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

        string consulta = "select s.codigo as codsede,d.nombre as departamento,m.nombre as municipio,i.nombre as institucion,s.nombre as sede,s.dane,s.direccion,s.telefono,s.email,z.nombre as zona from ins_sede s inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on s.codmunicipio=m.cod inner join geo_departamentos d on d.cod=m.coddepartamento inner join ins_zona z on z.codigo=s.codzona " + where + " order by m.nombre,i.nombre,s.nombre asc";
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




    public DataTable cargarJornadasEduBeneficiadas(string codinstitucion, string jornada)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        string Mañana = "";
        string Tarde = "";
        string Nocturna = "";
        string FinDeSemana = "";

        switch (jornada)
        {
            case "":
                Mañana = "Mañana";
                Tarde = "Tarde";
                Nocturna = "Nocturna";
                FinDeSemana = "Fin de semana";
                break;
            case "Mañana":
                Mañana = "Mañana";
                Tarde = "";
                Nocturna = "";
                FinDeSemana = "";
                break;
            case "Tarde":
                Mañana = "";
                Tarde = "Tarde";
                Nocturna = "";
                FinDeSemana = "";
                break;
            case "Nocturna":
                Mañana = "";
                Tarde = "";
                Nocturna = "Nocturna";
                FinDeSemana = "";
                break;
            case "Fin de semana":
                Mañana = "";
                Tarde = "";
                Nocturna = "";
                FinDeSemana = "Fin de semana";
                break;
        }


        consulta = "select ri.respuesta as jornada from lbase_institucionasesor ia left join lbase_respuestainstitucional ri on ri.codinstiasesor=ia.codigo where ia.codinstitucion=@codinstitucion and ri.codpregunta='3' and (ri.respuesta='" + Mañana + "' or ri.respuesta='" + Tarde + "' or ri.respuesta='" + Nocturna + "' or ri.respuesta='" + FinDeSemana + "') and fase is null ";
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

    public DataTable cargarJornadasSedesBeneficiadas(string codsede, string jornada)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        string Mañana = "";
        string Tarde = "";
        string Nocturna = "";
        string FinDeSemana = "";

        switch (jornada)
        {
            case "":
                Mañana = "Mañana";
                Tarde = "Tarde";
                Nocturna = "Nocturna";
                FinDeSemana = "Fin de semana";
                break;
            case "Mañana":
                Mañana = "Mañana";
                Tarde = "";
                Nocturna = "";
                FinDeSemana = "";
                break;
            case "Tarde":
                Mañana = "";
                Tarde = "Tarde";
                Nocturna = "";
                FinDeSemana = "";
                break;
            case "Nocturna":
                Mañana = "";
                Tarde = "";
                Nocturna = "Nocturna";
                FinDeSemana = "";
                break;
            case "Fin de semana":
                Mañana = "";
                Tarde = "";
                Nocturna = "";
                FinDeSemana = "Fin de semana";
                break;
        }


        consulta = "select rs.respuesta as jornada from lbase_respuestasede rs inner join lbase_sedeasesor sa on sa.codigo=rs.codsedeasesor where sa.codsede=@codsede and codinstrumento='C600B' and codpregunta='1' and codsubpregunta='0' and fase is null and (rs.respuesta='" + Mañana + "' or rs.respuesta='" + Tarde + "' or rs.respuesta='" + Nocturna + "' or rs.respuesta='" + FinDeSemana + "')";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codsede",codsede);
        DataTable resp = conector.traerdata();
        if (resp != null)
        {
            return resp;
        }
        else
        {
            return null;
        }
    }


    public DataTable cargarNivelesEduBeneficiadas(string codinstitucion, string nivel)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        string Preescolar = "";
        string Básica_primaria = "";
        string Básica_secundaria = "";
        string Media = "";

        switch (nivel)
        {
            case "":
                Preescolar = "Preescolar";
                Básica_primaria = "Básica primaria";
                Básica_secundaria = "Básica secundaria";
                Media = "Media";
                break;
            case "Preescolar":
                Preescolar = "Preescolar";
                Básica_primaria = "";
                Básica_secundaria = "";
                Media = "";
                break;
            case "Básica primaria":
                Preescolar = "";
                Básica_primaria = "Básica primaria";
                Básica_secundaria = "";
                Media = "";
                break;
            case "Básica secundaria":
                Preescolar = "";
                Básica_primaria = "";
                Básica_secundaria = "Básica secundaria";
                Media = "";
                break;
            case "Media":
                Preescolar = "";
                Básica_primaria = "";
                Básica_secundaria = "";
                Media = "Media";
                break;
        }


        consulta = "select ri.respuesta as niveles from lbase_institucionasesor ia left join lbase_respuestainstitucional ri on ri.codinstiasesor=ia.codigo where ia.codinstitucion=@codinstitucion and ri.codpregunta='1' and (ri.respuesta='" + Preescolar + "' or ri.respuesta='" + Básica_primaria + "' or ri.respuesta='" + Básica_secundaria + "' or ri.respuesta='" + Media + "') and fase is null ";
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

    public DataTable cargarNivelesSedesBeneficiadas(string codsede, string nivel)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        string Preescolar = "";
        string Básica_primaria = "";
        string Básica_secundaria = "";
        string Media = "";

        switch (nivel)
        {
            case "":
                Preescolar = "Preescolar";
                Básica_primaria = "Básica primaria";
                Básica_secundaria = "Básica secundaria";
                Media = "Media";
                break;
            case "Preescolar":
                Preescolar = "Preescolar";
                Básica_primaria = "";
                Básica_secundaria = "";
                Media = "";
                break;
            case "Básica primaria":
                Preescolar = "";
                Básica_primaria = "Básica primaria";
                Básica_secundaria = "";
                Media = "";
                break;
            case "Básica secundaria":
                Preescolar = "";
                Básica_primaria = "";
                Básica_secundaria = "Básica secundaria";
                Media = "";
                break;
            case "Media":
                Preescolar = "";
                Básica_primaria = "";
                Básica_secundaria = "";
                Media = "Media";
                break;
        }


        consulta = "select rs.respuesta as niveles from lbase_respuestasede rs inner join lbase_sedeasesor sa on sa.codigo=rs.codsedeasesor where sa.codsede=@codsede and codinstrumento='C600B' and codpregunta='3' and codsubpregunta='0'  and (rs.respuesta='" + Preescolar + "' or rs.respuesta='" + Básica_primaria + "' or rs.respuesta='" + Básica_secundaria + "' or rs.respuesta='" + Media + "') and fase is null ";
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

    public DataTable cargarEspecialidadesEduBeneficiadas(string codinstitucion, string especialidad)
    {
        Conexion conector = new Conexion();
        string consulta = "";

        string Académica = "";
        string Técnica = "";
        string Otras = "";

        switch (especialidad)
        {
            case "":
                Académica = "Académica";
                Técnica = "Técnica (Incluye la Comercial, Industrial, Pedagógica, Promoción social, Agropecuario)";
                Otras = "Otras";
                break;
            case "Académica":
                Académica = "Académica";
                Técnica = "";
                Otras = "";
                break;
            case "Técnica (Incluye la Comercial, Industrial, Pedagógica, Promoción social, Agropecuario)":
                Académica = "";
                Técnica = "Técnica (Incluye la Comercial, Industrial, Pedagógica, Promoción social, Agropecuario)";
                Otras = "";
                break;
            case "Otras":
                Académica = "";
                Técnica = "";
                Otras = "Otras";
                break;
        }


        consulta = "select distinct on (ri.respuesta) ri.respuesta as especialidades from lbase_sedeasesor ia left join lbase_respuestasede ri on ri.codsedeasesor=ia.codigo inner join ins_sede s on s.codigo=ia.codsede where s.codinstitucion=@codinstitucion and codpregunta='3' and codsubpregunta='0' and codinstrumento='01' and fase is null and (ri.respuesta='" + Académica + "' or ri.respuesta='" + Técnica + "' or ri.respuesta='" + Otras + "') ";
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

    public DataRow sumTotalTabletas()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT SUM(total) AS total FROM est_estra4entregatablets";
        conector.CrearComando(consulta);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarGrados()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo,nombre FROM ins_grado WHERE estado='On'";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarEstuRedTematicas(string codMunicipio, string codinstitucion, string codsede, string sexo, string grado)
    {

        int numero = 6;
        string[] cond;
        cond = new string[numero];

        cond[0] = " rs.aniored = '2017' AND em.codanio = '2' ";  //todo
        cond[1] = string.Empty;  
        cond[2] = string.Empty;  
        cond[3] = string.Empty;  
        cond[4] = string.Empty;  
        cond[5] = string.Empty;  
        if (codMunicipio != "" && codMunicipio != null)
        {
            cond[1] = "iin.codmunicipio='" + codMunicipio + "'";  
        }
        if (codinstitucion != "" && codinstitucion != null)
        {
            cond[2] = "isede.codinstitucion='" + codinstitucion + "'";  
        }
        if (codsede != "" && codsede != null)
        {
            cond[3] = "isede.codigo='" + codsede + "'";  
        }
        if (sexo != "" && sexo != null)
        {
            cond[4] = "e.sexo='" + sexo + "'";  
        }
        if (grado != "" && grado != null)
        {
            cond[5] = "m.codgrado='" + grado + "'";  
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

        //string where = " WHERE mu.cod='" + codmunicipio + "' AND i.codigo='" + codinstitucion + "' AND s.codigo='" + codsede + "' AND m.codanio='2' ";

        //if (sexo != "")
        //{
        //    where += " AND e.sexo='"+sexo+"'";
        //}

        //if (grado != "")
        //{
        //    where += " AND m.codgrado='" + grado + "'";
        //}

        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT(rtm.codestumatricula) as estured, mu.nombre as municipio,iin.nombre as institucion,isede.nombre as sede,e.apellido,e.nombre,e.sexo,g.nombre AS grado FROM rt_redtematicamatricula rtm INNER JOIN rt_redtematicasede rs on rtm.codredtematicasede=rs.codigo INNER JOIN ins_estumatricula em on em.codigo=rtm.codestumatricula INNER JOIN ins_sede  isede on  isede.codigo=rs.codsede INNER JOIN ins_institucion iin on iin.codigo= isede.codinstitucion INNER JOIN geo_municipios gmun on gmun.cod=iin.codmunicipio INNER JOIN geo_departamentos gdep on gdep.cod=gmun.coddepartamento INNER JOIN geo_municipios mu ON mu.cod = iin.codmunicipio INNER JOIN ins_estumatricula m on m.codigo=rtm.codestumatricula INNER JOIN ins_estudiante e on e.codigo=m.codestudiante inner join ins_grado g on g.codigo=m.codgrado " + where;
        //string consulta = "SELECT DISTINCT rtm.codestumatricula, d.nombre as departamento,mu.nombre as municipio,i.nombre as institucion,s.nombre as sede,e.apellido,e.nombre,e.sexo,g.nombre AS grado FROM rt_redtematicamatricula rtm inner join ins_estumatricula m on m.codigo = rtm.codestumatricula inner join ins_estudiante e on e.codigo = m.codestudiante inner join ins_grado g on g.codigo = m.codgrado inner join ins_sede s on s.codigo = m.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios mu on mu.cod = i.codmunicipio inner join geo_departamentos d on d.cod = mu.coddepartamento " + where + " ORDER BY d.nombre,mu.nombre,i.nombre,s.nombre,e.apellido asc";
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }


    public DataTable cargarEstuGruInvestigacion(string codMunicipio, string codinstitucion, string codsede, string sexo, string grado)
    {
        int numero = 6;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;
        cond[4] = string.Empty;
        cond[5] = string.Empty;
        if (codMunicipio != "" && codMunicipio != null)
        {
            cond[1] = "iin.codmunicipio='" + codMunicipio + "'";
        }
        if (codinstitucion != "" && codinstitucion != null)
        {
            cond[2] = "s.codinstitucion='" + codinstitucion + "'";
        }
        if (codsede != "" && codsede != null)
        {
            cond[3] = "s.codigo='" + codsede + "'";
        }
        if (sexo != "" && sexo != null)
        {
            cond[4] = "e.sexo='" + sexo + "'";
        }
        if (grado != "" && grado != null)
        {
            cond[5] = "m.codgrado='" + grado + "'";
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

        //string where = " WHERE mu.cod='" + codmunicipio + "' AND i.codigo='" + codinstitucion + "' AND s.codigo='" + codsede + "' ";

        //if (sexo != "")
        //{
        //    where += " AND e.sexo='" + sexo + "'";
        //}

        //if (grado != "")
        //{
        //    where += " AND m.codgrado='" + grado + "'";
        //}

        Conexion conector = new Conexion();
        string consulta = "SELECT DISTINCT(ppm.codestumatricula)  AS estugrupoinv, mu.nombre as municipio,iin.nombre as institucion,s.nombre as sede,e.apellido,e.nombre,e.sexo,g.nombre AS grado FROM pro_proyectomatricula ppm  INNER JOIN pro_proyectosede pps ON pps.codigo = ppm.codproyectosede  INNER JOIN ins_sede s ON s.codigo = pps.codsede   INNER JOIN ins_institucion iin ON iin.codigo = s.codinstitucion   INNER JOIN geo_municipios mu ON mu.cod = iin.codmunicipio   INNER JOIN geo_departamentos gdep ON gdep.cod = mu.coddepartamento INNER JOIN ins_estumatricula m on m.codigo=ppm.codestumatricula INNER JOIN ins_estudiante e on e.codigo=m.codestudiante inner join ins_grado g on g.codigo=m.codgrado " + where;
        //string consulta = "SELECT DISTINCT gi.codestumatricula, d.nombre as departamento,mu.nombre as municipio,i.nombre as institucion,s.nombre as sede,e.apellido,e.nombre,e.sexo,g.nombre AS grado FROM pro_proyectomatricula gi inner join ins_estumatricula m on m.codigo = gi.codestumatricula inner join ins_estudiante e on e.codigo = m.codestudiante inner join ins_grado g on g.codigo = m.codgrado inner join ins_sede s on s.codigo = m.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios mu on mu.cod = i.codmunicipio inner join geo_departamentos d on d.cod = mu.coddepartamento " + where + " ORDER BY d.nombre,mu.nombre,i.nombre,s.nombre,e.apellido asc";
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
        string consulta = "select rt.codigo, rt.codsede, rt.codasesorcoordinador, rt.aniored, concat_ws(' ', r.nombre, rt.consecutivogrupo) as red from rt_redtematicasede rt inner join rt_redtematica r on r.codigo=rt.codredtematica where rt.aniored='2017'";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarSedesConectadas()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM est_conectividad";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarSedesConectadasxMunicipio(String codMunicipio, String dane, String zona, String bw)
    {
        Conexion conector = new Conexion();
       
        int numero = 5;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        cond[1] = string.Empty;  //sin municipio
        cond[2] = string.Empty;  //sin dane
        cond[3] = string.Empty;  //sin zona
        cond[4] = string.Empty;  //sin bw
        if (codMunicipio != "" && codMunicipio != null)
        {
            cond[1] = "c.codmunicipio=" + codMunicipio;  //con municipio
        }
        if (dane != "" && dane != null)
        {
            cond[2] = "c.dane='" + dane + "'";  //con dane
        }
        if (zona != "" && zona != null)
        {
            cond[3] = "c.zona='" + zona + "'";  //con dane
        }
        if (bw != "" && bw != null)
        {
            cond[4] = "c.bw='" + bw + "'";  //con dane
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
 
        string consulta = "SELECT c.*, m.nombre as municipio FROM est_conectividad c inner join geo_municipios m on c.codmunicipio=m.cod " + where;
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }
    public DataTable cargarDocentesBeneficiados(String codMunicipio, string codInstitucion, string codSede, string sexodocente, string areas, string formacion, string tipomaestro)
    {
        Conexion conector = new Conexion();

        ///////////////////////

        int numero2 = 5;
        string[] cond2;
        cond2 = new string[numero2];

        cond2[0] = "";  //todo
        cond2[1] = string.Empty;  //sin municipio
        cond2[2] = string.Empty;  //sin dane
        cond2[3] = string.Empty;  //sin zona
        cond2[4] = string.Empty;  //sin bw



        if (codMunicipio != "" && codMunicipio != null)
        {
            cond2[1] = "i2.codmunicipio=" + codMunicipio;  //con municipio
        }
        if (codInstitucion != "" && codInstitucion != null)
        {
            cond2[2] = "s2.codinstitucion='" + codInstitucion + "'";  //con dane
        }
        if (codSede != "" && codSede != "null")
        {
            cond2[3] = "s2.codigo='" + codSede + "'";  //con dane
        }
        if (sexodocente != "" && sexodocente != null)
        {
            cond2[4] = "d2.sexo='" + sexodocente + "'";  //con dane
        }
        //if (areas != "" && areas != null)
        //{
        //    cond[5] = "c.bw='" + areas + "'";  //con dane
        //}
        if (formacion != "" && formacion != null)
        {
            cond2[6] = "res.respuesta='" + sexodocente + "'";  //con dane
        }


        string where2 = "";
        int primero2 = 0;
        for (int i = 0; i < numero2; i++)
        {
            if (cond2[i] != string.Empty)
            {
                if (primero2 == 0)
                {
                    where2 += "WHERE " + cond2[i];
                }
                if (primero2 > 0)
                {
                    where2 += " AND " + cond2[i];
                }
                if (primero2 == 0)
                {
                    primero2 = 1;
                }
            }
        }

        //////////////////////

        int numero3 = 5;
        string[] cond3;
        cond3 = new string[numero3];

        cond3[0] = "";  //todo
        cond3[1] = string.Empty;  //sin municipio
        cond3[2] = string.Empty;  //sin dane
        cond3[3] = string.Empty;  //sin zona
        cond3[4] = string.Empty;  //sin bw



        if (codMunicipio != "" && codMunicipio != null)
        {
            cond3[1] = "i3.codmunicipio=" + codMunicipio;  //con municipio
        }
        if (codInstitucion != "" && codInstitucion != null)
        {
            cond3[2] = "s3.codinstitucion='" + codInstitucion + "'";  //con dane
        }
        if (codSede != "" && codSede != null)
        {
            cond3[3] = "s3.codigo='" + codSede + "'";  //con dane
        }
        if (sexodocente != "" && sexodocente != null)
        {
            cond3[4] = "d3.sexo='" + sexodocente + "'";  //con dane
        }
        //if (areas != "" && areas != null)
        //{
        //    cond[5] = "c.bw='" + areas + "'";  //con dane
        //}
        if (formacion != "" && formacion != null)
        {
            cond3[6] = "res.respuesta='" + sexodocente + "'";  //con dane
        }


        string where3 = "";
        int primero3 = 0;
        for (int i = 0; i < numero3; i++)
        {
            if (cond3[i] != string.Empty)
            {
                if (primero3 == 0)
                {
                    where3 += "WHERE " + cond3[i];
                }
                if (primero3 > 0)
                {
                    where3 += " AND " + cond3[i];
                }
                if (primero3 == 0)
                {
                    primero3 = 1;
                }
            }
        }

        //////////////////////

        int numero4 = 5;
        string[] cond4;
        cond4 = new string[numero4];

        cond4[0] = "";  //todo
        cond4[1] = string.Empty;  //sin municipio
        cond4[2] = string.Empty;  //sin dane
        cond4[3] = string.Empty;  //sin zona
        cond4[4] = string.Empty;  //sin bw



        if (codMunicipio != "" && codMunicipio != null)
        {
            cond4[1] = "i4.codmunicipio=" + codMunicipio;  //con municipio
        }
        if (codInstitucion != "" && codInstitucion != null)
        {
            cond4[2] = "s4.codinstitucion='" + codInstitucion + "'";  //con dane
        }
        if (codSede != "" && codSede != null)
        {
            cond4[3] = "s4.codigo='" + codSede + "'";  //con dane
        }
        if (sexodocente != "" && sexodocente != null)
        {
            cond4[4] = "d4.sexo='" + sexodocente + "'";  //con dane
        }
        //if (areas != "" && areas != null)
        //{
        //    cond[5] = "c.bw='" + areas + "'";  //con dane
        //}
        if (formacion != "" && formacion != null)
        {
            cond4[6] = "res.respuesta='" + sexodocente + "'";  //con dane
        }


        string where4 = "";
        int primero4 = 0;
        for (int i = 0; i < numero4; i++)
        {
            if (cond4[i] != string.Empty)
            {
                if (primero4 == 0)
                {
                    where4 += "WHERE " + cond4[i];
                }
                if (primero4 > 0)
                {
                    where4 += " AND " + cond4[i];
                }
                if (primero4 == 0)
                {
                    primero4 = 1;
                }
            }
        }

        string consulta = "";

        switch (tipomaestro)
        {
            case "undefined":

                consulta = "select distinct (d2.identificacion), concat_ws(' ', d2.nombre, d2.apellido) as nombre, d2.identificacion, d2.sexo, d2.email, s2.nombre as sede, i2.nombre as institucion, m2.nombre as municipio from pro_mesadetrabajodocente mt inner join ins_gradodocente gd2 on gd2.cod=mt.codgradodocente inner join ins_docente d2 on d2.identificacion=gd2.identificacion inner join ins_sede s2 on s2.codigo=gd2.codsede inner join ins_institucion i2 on i2.codigo=s2.codinstitucion inner join geo_municipios m2 on m2.cod=i2.codmunicipio " + where2 + " union select distinct (d3.identificacion), concat_ws(' ', d3.nombre, d3.apellido) as nombre, d3.identificacion, d3.sexo, d3.email, s3.nombre as sede, i3.nombre as institucion, m3.nombre as municipio from pro_proyectodocente ps inner join ins_gradodocente gd3 on gd3.cod=ps.codgradodocente inner join ins_docente d3 on d3.identificacion=gd3.identificacion inner join ins_sede s3 on s3.codigo=gd3.codsede inner join ins_institucion i3 on i3.codigo=s3.codinstitucion inner join geo_municipios m3 on m3.cod=i3.codmunicipio " + where3 + " union select distinct (d4.identificacion), concat_ws(' ', d4.nombre, d4.apellido) as nombre, d4.identificacion, d4.sexo, d4.email, s4.nombre as sede, i4.nombre as institucion, m4.nombre as municipio from rt_redtematicadocente rd inner join ins_gradodocente gd4 on gd4.cod=rd.codgradodocente inner join ins_docente d4 on d4.identificacion=gd4.identificacion inner join ins_sede s4 on s4.codigo=gd4.codsede inner join ins_institucion i4 on i4.codigo=s4.codinstitucion inner join geo_municipios m4 on m4.cod=i4.codmunicipio " + where4;
                break;
            case "participantes":



                consulta = "select distinct (d2.identificacion), concat_ws(' ', d2.nombre, d2.apellido) as nombre, d2.identificacion, d2.sexo, d2.email, s2.nombre as sede, i2.nombre as institucion, m2.nombre as municipio from pro_mesadetrabajodocente mt inner join ins_gradodocente gd2 on gd2.cod=mt.codgradodocente inner join ins_docente d2 on d2.identificacion=gd2.identificacion inner join ins_sede s2 on s2.codigo=gd2.codsede inner join ins_institucion i2 on i2.codigo=s2.codinstitucion inner join geo_municipios m2 on m2.cod=i2.codmunicipio" + where2;
                break;
            case "grupos":


                consulta = "select distinct (d3.identificacion), concat_ws(' ', d3.nombre, d3.apellido) as nombre, d3.identificacion, d3.sexo, d3.email, s3.nombre as sede, i3.nombre as institucion, m3.nombre as municipio, p.nombregrupo, (select respuesta from lbase_docenteasesor da inner join lbase_respuesta res on da.codigo=res.coddocenteasesor where da.codgradodocente=ps.codgradodocente and res.codpregunta='11' and res.codsubpregunta='0' and codinstrumento='5' order by res.codigo desc limit 1) as formacion from pro_proyectodocente ps inner join ins_gradodocente gd3 on gd3.cod=ps.codgradodocente inner join ins_docente d3 on d3.identificacion=gd3.identificacion inner join ins_sede s3 on s3.codigo=gd3.codsede inner join ins_institucion i3 on i3.codigo=s3.codinstitucion inner join geo_municipios m3 on m3.cod=i3.codmunicipio inner join pro_proyectosede p on p.codigo=ps.codproyectosede" + where3;
                break;

            case "redes":



                consulta = "select distinct (d4.identificacion), concat_ws(' ', d4.nombre, d4.apellido) as nombre, d4.identificacion, d4.sexo, d4.email, s4.nombre as sede, i4.nombre as institucion, m4.nombre as municipio, concat_ws(' ',r.nombre,rts.consecutivogrupo) as nombregrupo, (select respuesta from lbase_docenteasesor da inner join lbase_respuesta res on da.codigo=res.coddocenteasesor where da.codgradodocente=rd.codgradodocente and res.codpregunta='11' and res.codsubpregunta='0' and res.codinstrumento='5' limit 1) as formacion from rt_redtematicadocente rd inner join ins_gradodocente gd4 on gd4.cod=rd.codgradodocente inner join ins_docente d4 on d4.identificacion=gd4.identificacion inner join ins_sede s4 on s4.codigo=gd4.codsede inner join ins_institucion i4 on i4.codigo=s4.codinstitucion inner join geo_municipios m4 on m4.cod=i4.codmunicipio inner join rt_redtematicasede rts on rts.codigo=rd.codredtematicasede inner join rt_redtematica r on r.codigo=rts.codredtematica" + where4;
                break;
        }

        

        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }
    public DataTable cargarSedesConTabletsxMunicipio(String codMunicipio, String dane, String zona)
    {
        Conexion conector = new Conexion();

        int numero = 4;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        cond[1] = string.Empty;  //sin municipio
        cond[2] = string.Empty;  //sin dane
        cond[3] = string.Empty;  //sin zona

        if (codMunicipio != "" && codMunicipio != null)
        {
            cond[1] = "s.codmunicipio=" + codMunicipio;  //con municipio
        }
        if (dane != "" && dane != null)
        {
            cond[2] = "t.dane='" + dane + "'";  //con dane
        }
        if (zona != "" && zona != null)
        {
            cond[3] = "s.codzona='" + zona + "'";  //con zona
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

        string consulta = "SELECT t.*, i.nombre as institucion, s.nombre as sede, m.nombre as municipio, z.nombre as zona FROM est_estra4entregatablets t inner join ins_sede s on s.dane=t.dane inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on s.codmunicipio=m.cod inner join ins_zona z on z.codigo=s.codzona " + where + " order by m.nombre";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }
    public DataTable cargarsedesxMunicipio(string codmunicipio)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo, sede, dane FROM est_conectividad where codmunicipio=@codmunicipio";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codmunicipio", codmunicipio);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarDocentesBeneficiadosRedesGruposMesas()
    {
        Conexion conector = new Conexion();
        string consulta = "select mt.codgradodocente from pro_mesadetrabajodocente mt inner join ins_gradodocente gd2 on gd2.cod=mt.codgradodocente union select ps.codgradodocente from pro_proyectodocente ps inner join ins_gradodocente gd3 on gd3.cod=ps.codgradodocente where gd3.codanio='2'union select rd.codgradodocente from rt_redtematicadocente rd inner join ins_gradodocente gd3 on gd3.cod=rd.codgradodocente where gd3.codanio='2'";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarDocentesBeneficiadosEnSesionesJornadas()
    {
        Conexion conector = new Conexion();
        string consulta = "select doc.identificacion, doc.nombre, doc.apellido, d.codgradodocente, g.codanio, s.nombre as sede, i.nombre as institucion, m.nombre  from est_inasistenciasinstrumento_g001detalle_doc d inner join est_inasistenciasinstrumento_g001_doc g001 on g001.codigo=d.codinasistenciainstrumento_g001_doc inner join  ins_gradodocente g on g.cod=d.codgradodocente inner join ins_docente doc on doc.identificacion=g.identificacion inner join ins_sede s on s.codigo=g.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio where g.codanio='2' and jornada is not null group by doc.identificacion, doc.nombre, doc.apellido, d.codgradodocente, g.codanio, s.nombre, i.nombre, m.nombre";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarDocentesBeneficiadosIndicador3()
    {
        Conexion conector = new Conexion();
        string consulta = "select md.codgradodocente from pro_grupoinvestigacionmatriculadocentes md inner join pro_proyectodocente pd on md.codgradodocente=pd.codgradodocente ";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarDocentesEnSesionesJornadasEstra2(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string estrategia, string momento, string sesion)
    {
        Conexion conector = new Conexion();

        int numero = 7;
        string[] cond;
        cond = new string[numero];

        cond[0] = " g.codanio='2' and g001.jornada is not null ";  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;
        cond[4] = string.Empty;
        cond[5] = string.Empty;
        cond[6] = string.Empty;

        if (coddepartamento != "" && coddepartamento != null)
        {
            cond[1] = "m.coddepartamento='" + coddepartamento + "'";
        }
        if (codmunicipio != "" && codmunicipio != null)
        {
            cond[2] = "i.codmunicipio='" + codmunicipio + "'";
        }
        if (codinstitucion != "" && codinstitucion != null)
        {
            cond[3] = "s.codinstitucion='" + codinstitucion + "'";
        }
        if (codsede != "" && codsede != null)
        {
            cond[4] = "s004.codsede='" + codsede + "'";
        }
        if (sesion != "" && sesion != null)
        {
            cond[5] = "s004.sesion='" + sesion + "'";
        }
        if (momento != "" && momento != null)
        {
            cond[6] = "s004.momento='" + momento + "'";
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

        string consulta = "select distinct d.codgradodocente, doc.identificacion, doc.nombre, doc.apellido, d.codgradodocente, g.codanio, s.nombre as sede, i.nombre as institucion, m.nombre from est_inasistenciasinstrumento_g001detalle_doc d inner join est_inasistenciasinstrumento_g001_doc g001 on g001.codigo=d.codinasistenciainstrumento_g001_doc inner join est_estra2instrumento_s004_sede s004 on s004.codigo=g001.codinstrumento_s004_sede inner join  ins_gradodocente g on g.cod=d.codgradodocente inner join ins_docente doc on doc.identificacion=g.identificacion inner join ins_sede s on s.codigo=g.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio " + where;
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarLineaInvestigacion()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT codigo,nombre FROM pro_areas order by nombre";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarSedesConGruposJuveniles(String codMunicipio, string codInstitucion, String codSede, String lineainvestigacion, string tipoproyecto)
    {
        Conexion conector = new Conexion();

        int numero = 6;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        cond[1] = string.Empty;  //sin municipio
        cond[2] = string.Empty;  //sin insittiucion
        cond[3] = string.Empty;  //sin sede
        cond[4] = string.Empty;  //sin linea
        cond[5] = string.Empty;  //sin tipo proyecto

     
        if (codMunicipio != "" && codMunicipio != null)
        {
            cond[1] = "s.codmunicipio='" + codMunicipio + "'";  //con municipio
        }
        if (codInstitucion != "" && codInstitucion != null)
        {
            cond[2] = "s.codinstitucion='" + codInstitucion + "'";  //con institución
        }
        if (codSede != "" && codSede != null)
        {
            cond[3] = "ps.codsede='" + codSede + "'";  //con sede
        }
        if (lineainvestigacion != "" && lineainvestigacion != null)
        {
            cond[4] = "ps.codarea='" + lineainvestigacion + "'";  //con linea
        }
        if (tipoproyecto != "" && tipoproyecto != null)
        {
            cond[5] = "ps.codlineainvestigacion='" + tipoproyecto + "'";  //con tipo proyecto
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

        string consulta = "select ps.codigo as codproyectosede, i.nombre as nominstitucion, s.nombre as nomsede, s.dane, ps.nombregrupo, pa.nombre as nomarea, li.nombre as nomlinea, z.nombre as zona, m.nombre as nommunicipio, d.nombre as nomdepartamento from pro_proyectosede ps left join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join pro_areas pa on pa.codigo=ps.codarea inner join pro_linea_investigacion li on li.codigo=ps.codlineainvestigacion inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento inner join ins_zona z on z.codigo=s.codzona " + where;
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarSedesConGruposMaestros(String codMunicipio, string codInstitucion, String codSede, string tipoproyecto)
    {
        Conexion conector = new Conexion();

        int numero = 5;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        cond[1] = string.Empty;  //sin municipio
        cond[2] = string.Empty;  //sin insittiucion
        cond[3] = string.Empty;  //sin sede
        cond[4] = string.Empty;  //sin tipo proyecto


        if (codMunicipio != "" && codMunicipio != null)
        {
            cond[1] = "s.codmunicipio='" + codMunicipio + "'";  //con municipio
        }
        if (codInstitucion != "" && codInstitucion != null)
        {
            cond[2] = "s.codinstitucion='" + codInstitucion + "'";  //con institución
        }
        if (codSede != "" && codSede != null)
        {
            cond[3] = "ps.codsede='" + codSede + "'";  //con sede
        }
        if (tipoproyecto != "" && tipoproyecto != null)
        {
            cond[4] = "ps.codlineainvestigacion='" + tipoproyecto + "'";  //con tipo proyecto
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

        string consulta = "select ps.codigo as codgrupo, i.nombre as nominstitucion, s.nombre as nomsede, ps.nombregrupo, m.nombre as nommunicipio, d.nombre as nomdepartamento, li.nombre as nomlinea, z.nombre as zona, s.dane, (select perturbaciononda from est_estra2instrumento_s003 where codgrupoinvestigaciondocentes=ps.codigo limit 1) as pregunta from pro_grupoinvestigaciondocentes ps left join est_asesorcoordinador ac on ps.codasesorcoordinador=ac.codigo inner join est_asesor a on a.codigo=ac.codasesor inner join ins_sede s on s.codigo=ps.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=s.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento inner join pro_linea_investigacion li on li.codigo=ps.codlineainvestigacion inner join ins_zona z on z.codigo=s.codzona; " + where;
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarFeriasMunicipales()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM ep_feriasmunicipales ";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarRedes()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM rt_redtematica ";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarTablaRedTematicaTodoWhere(string codMunicipio, string codInstitucion, string codSede, string redtematica)
    {
        Conexion conector = new Conexion();

        int numero = 5;
        string[] cond;
        cond = new string[numero];

        cond[0] = " rt.aniored='2017' ";  //todo
        cond[1] = string.Empty;  //sin municipio
        cond[2] = string.Empty;  //sin insittiucion
        cond[3] = string.Empty;  //sin sede
        cond[4] = string.Empty;  //sin tipo proyecto



        if (codMunicipio != "" && codMunicipio != null)
        {
            cond[1] = "s.codmunicipio='" + codMunicipio + "'";  //con municipio
        }
        if (codInstitucion != "" && codInstitucion != null)
        {
            cond[2] = "s.codinstitucion='" + codInstitucion + "'";  //con institución
        }
        if (codSede != "" && codSede != null)
        {
            cond[3] = "rt.codsede='" + codSede + "'";  //con sede
        }
        if (redtematica != "" && redtematica != null)
        {
            cond[4] = "rt.codredtematica='" + redtematica + "'";  //con tipo proyecto
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

        string consulta = "select rt.codigo, rt.codsede, rt.codasesorcoordinador, rt.aniored, concat_ws(' ', r.nombre, rt.consecutivogrupo) as red, s.nombre as sede, s.dane, i.nombre as institucion, m.nombre as municipio from rt_redtematicasede rt inner join rt_redtematica r on r.codigo=rt.codredtematica inner join ins_sede s on s.codigo=rt.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio " + where + " order by m.nombre ASC";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    //Sesiones de formación estrategia 2
    public DataTable estra2SesionesFormacion(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string momento, string sesion, string jornada1, string jornada2)
    {
        int numero = 9;
        string[] cond;
        cond = new string[numero];

        cond[0] = " ers4.estrategia='2' ";  //todo
        cond[1] = string.Empty;  
        cond[2] = string.Empty;  
        cond[3] = string.Empty;  
        cond[4] = string.Empty;
        cond[5] = string.Empty;
        cond[6] = string.Empty;
        cond[7] = string.Empty;
        cond[8] = string.Empty;

        if (coddepartamento != "" && coddepartamento != null)
        {
            cond[1] = "gmun.coddepartamento='" + coddepartamento + "'";  
        }
        if (codmunicipio != "" && codmunicipio != null)
        {
            cond[2] = "iin.codmunicipio='" + codmunicipio + "'";  
        }
        if (codinstitucion != "" && codinstitucion != null)
        {
            cond[3] = "isede.codinstitucion='" + codinstitucion + "'";  
        }
        if (codsede != "" && codsede != null)
        {
            cond[4] = "ers4.codsede='" + codsede + "'";  
        }
        if (momento != "" && momento != null)
        {
            cond[5] = "ers4.momento='" + momento + "'";  
        }
        if (sesion != "" && sesion != null)
        {
            cond[6] = "ers4.sesion='" + sesion + "'";  
        }
        if (jornada1 != "" && jornada1 != null)
        {
            cond[7] = "ers4.jornada='" + jornada1 + "'";
        }
        if (jornada2 != "" && jornada2 != null)
        {
            cond[8] = "ers4.jornada='" + jornada2 + "'";
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
        string consulta = "SELECT gdep.nombre as nombredepartamento, gmun.nombre as nombremunicipio, iin.dane, iin.nombre as nombreins, isede.dane as danesede, isede.nombre as nombresede, ers4.temasesion FROM est_estra2instrumento_s004_sede ers4 INNER JOIN ins_sede isede ON isede.codigo = ers4.codsede  INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarListadoSesionVirtualEstraDos(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string sesion, string general)
    {
        Conexion conector = new Conexion();

        int numero = 6;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;
        cond[4] = string.Empty;
        cond[5] = string.Empty;
       
        if (coddepartamento != "" && coddepartamento != null)
        {
            cond[1] = "m.coddepartamento='" + coddepartamento + "'";
        }
        if (codmunicipio != "" && codmunicipio != null)
        {
            cond[2] = "m.codmunicipio='" + codmunicipio + "'";
        }
        if (codinstitucion != "" && codinstitucion != null)
        {
            cond[3] = "s.codinstitucion='" + codinstitucion + "'";
        }
        if (codsede != "" && codsede != null)
        {
            cond[4] = "a.codsede='" + codsede + "'";
        }
        if (sesion != "" && sesion != null)
        {
            cond[5] = "a.sesion='" + sesion + "'";
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
        string consulta = "";

        switch (general)
        {
            case "g":
                consulta = "SELECT COALESCE(sum(a.nroasistentes),0) as virtual, COALESCE(sum(a.autoformacion),0) as autoformacion, COALESCE(sum(a.produccion),0) as produccion from est_estra2sesionvirtual a inner join ins_sede s on s.codigo=a.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio " + where;
                break;
            case "d":
                consulta = "SELECT a.*, s.nombre as sede, i.nombre as institucion, m.nombre as municipio from est_estra2sesionvirtual a inner join ins_sede s on s.codigo=a.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio " + where;
                break;
        }

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

    //Sesiones de formación evaluadas y subidas a la plataforma de Ciclón
    public DataTable sesionesformacionevaluadas(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string estrategia, string momento, string sesion, string actividad)
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
        string consulta = "SELECT distinct ees.codsede FROM est_repositorioasesor_s004sedes ers4 INNER JOIN est_estra2instrumento_s004_sede ees ON ees.codigo = ers4.codinstrumento INNER JOIN ins_sede isede ON isede.codigo = ees.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio INNER JOIN geo_departamentos gdep ON gdep.cod = gmun.coddepartamento WHERE  ers4.actividad = '" + actividad + "' AND ees.estrategia = " + estrategia + " AND ees.momento = " + momento + " AND ees.sesion = " + sesion + " " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarListadointroiepEstraDos(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        Conexion conector = new Conexion();

        int numero = 6;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;
        cond[4] = string.Empty;

        if (coddepartamento != "" && coddepartamento != null)
        {
            cond[1] = "m.coddepartamento='" + coddepartamento + "'";
        }
        if (codmunicipio != "" && codmunicipio != null)
        {
            cond[2] = "i.codmunicipio='" + codmunicipio + "'";
        }
        if (codinstitucion != "" && codinstitucion != null)
        {
            cond[3] = "s.codinstitucion='" + codinstitucion + "'";
        }
        if (codsede != "" && codsede != null)
        {
            cond[4] = "iep.codsede='" + codsede + "'";
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

        string consulta = "SELECT distinct rc.codinstrumento, iep.codsede FROM est_estra2introiep_evi rc inner join est_estra2introiep iep on iep.codigo=rc.codinstrumento inner join ins_sede s on s.codigo=iep.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio inner join geo_departamentos d on d.cod=m.coddepartamento where rc.actividad='Introducción de la IEP al currículo'";

        //string consulta = "SELECT a.*, s.nombre as sede, i.nombre as institucion, m.nombre as municipio, (select count(*) from est_estra2introiepdetalle where codestra2introiep=a.codigo) as nroasistentes from est_estra2introiep a inner join ins_sede s on s.codigo=a.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio";
        
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

    public DataTable cargarEntregaMaterialesCoordEstra2(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string material)
    {
        Conexion conector = new Conexion();

        int numero = 5;
        string[] cond;
        cond = new string[numero];

        cond[0] = " gm.nombrematerial='" + material + "' ";  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;
        cond[4] = string.Empty;

        if (coddepartamento != "" && coddepartamento != null)
        {
            cond[1] = "m.coddepartamento='" + coddepartamento + "'";
        }
        if (codmunicipio != "" && codmunicipio != null)
        {
            cond[2] = "i.codmunicipio='" + codmunicipio + "'";
        }
        if (codinstitucion != "" && codinstitucion != "null")
        {
            cond[3] = "s.codinstitucion='" + codinstitucion + "'";
        }
        if (codsede != "" && codsede != "null")
        {
            cond[4] = "g006.codsede='" + codsede + "'";
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

        
        string consulta = "select distinct s.codigo, g006.*, concat_ws(' ',a.nombre,a.apellido) as coordinador,  s.nombre as sede, i.nombre as institucion, m.nombre as municipio from est_estra2instrumento_g006 g006 inner join est_estracoordinador ac on g006.codestracoordinador=ac.codigo inner join est_coordinador a on a.codigo=ac.codcoordinador inner join ins_sede s on s.codigo=g006.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio inner join est_estra2instrumento_g006material gm on gm.codestrainstrumento_g006=g006.codigo " + where;
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

    public DataTable cargarInstrmentoS003(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        Conexion conector = new Conexion();

        int numero = 5;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;
        cond[4] = string.Empty;

        if (coddepartamento != "" && coddepartamento != "null")
        {
            cond[1] = "m.coddepartamento='" + coddepartamento + "'";
        }
        if (codmunicipio != "" && codmunicipio != "null")
        {
            cond[2] = "s.codmunicipio='" + codmunicipio + "'";
        }
        if (codinstitucion != "" && codinstitucion != "null")
        {
            cond[3] = "s.codinstitucion='" + codinstitucion + "'";
        }
        if (codsede != "" && codsede != "null")
        {
            cond[4] = "gid.codsede='" + codsede + "'";
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

        string consulta = "select * from est_estra2instrumento_s003 s003 inner join pro_grupoinvestigaciondocentes gid on gid.codigo=s003.codgrupoinvestigaciondocentes inner join ins_sede s on s.codigo=gid.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio " + where;
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

    public DataTable cargarListadoMemoriasS004_EspVirtualesTodo(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string estrategia, string momento, string sesion)
    {
        Conexion conectar = new Conexion();

        int numero = 8;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;
        cond[4] = string.Empty;
        cond[5] = string.Empty;
        cond[6] = string.Empty;
        cond[7] = string.Empty;

        if (coddepartamento != "" && coddepartamento != null)
        {
            cond[1] = "m.coddepartamento='" + coddepartamento + "'";
        }
        if (codmunicipio != "" && codmunicipio != null)
        {
            cond[2] = "m.codmunicipio='" + codmunicipio + "'";
        }
        if (codinstitucion != "" && codinstitucion != null)
        {
            cond[3] = "s.codinstitucion='" + codinstitucion + "'";
        }
        if (codsede != "" && codsede != null)
        {
            cond[4] = "rts.codsede='" + codsede + "'";
        }
        if (estrategia != "" && estrategia != null)
        {
            cond[5] = "s004redt.estrategia='" + estrategia + "'";
        }
        if (momento != "" && momento != null)
        {
            cond[6] = "s004redt.momento='" + momento + "'";
        }
        if (sesion != "" && sesion != null)
        {
            cond[7] = "s004redt.sesion='" + sesion + "'";
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

        string consulta = "select s004redt.*, rt.nombre,  rts.consecutivogrupo, rts.codsede, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estrainstrumento_s004_redt_ev s004redt inner join rt_redtematicasede rts on rts.codigo = s004redt.codredtematicasede inner join rt_redtematica rt on rt.codigo = rts.codredtematica inner join ins_sede s on s.codigo = rts.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento " + where;
        conectar.CrearComando(consulta);
       
        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return datos;
    }

    public DataTable cargarAsistentesMemoriasS004_EspVirtualesTodo(string estrategia, string momento, string sesion)
    {
        Conexion conectar = new Conexion();

        int numero = 4;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;
        //cond[4] = string.Empty;
        //cond[5] = string.Empty;
        //cond[6] = string.Empty;
        //cond[7] = string.Empty;

        //if (coddepartamento != "" && coddepartamento != null)
        //{
        //    cond[1] = "m.coddepartamento='" + coddepartamento + "'";
        //}
        //if (codmunicipio != "" && codmunicipio != null)
        //{
        //    cond[2] = "m.codmunicipio='" + codmunicipio + "'";
        //}
        //if (codinstitucion != "" && codinstitucion != null)
        //{
        //    cond[3] = "s.codinstitucion='" + codinstitucion + "'";
        //}
        //if (codsede != "" && codsede != null)
        //{
        //    cond[4] = "rts.codsede='" + codsede + "'";
        //}
        if (estrategia != "" && estrategia != null)
        {
            cond[1] = "s004redt.estrategia='" + estrategia + "'";
        }
        if (momento != "" && momento != null)
        {
            cond[2] = "s004redt.momento='" + momento + "'";
        }
        if (sesion != "" && sesion != null)
        {
            cond[3] = "s004redt.sesion='" + sesion + "'";
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

        string consulta = "select g001d.* from est_estrainstrumento_s004_redt_ev s004redt inner join est_inasistenciasinstrumento_g001_ev g001 on g001.codinstrumentos004=s004redt.codigo inner join est_inasistenciasinstrumento_g001detalle_ev g001d on g001.codigo=g001d.codinasistenciainstrumento_g001 " + where;
        conectar.CrearComando(consulta);

        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return datos;
    }

    public DataTable cargarListadoMemoriasS004Todo(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string estrategia, string momento, string sesion)
    {
        Conexion conectar = new Conexion();

        int numero = 8;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;
        cond[4] = string.Empty;
        cond[5] = string.Empty;
        cond[6] = string.Empty;
        cond[7] = string.Empty;

        if (coddepartamento != "" && coddepartamento != null)
        {
            cond[1] = "m.coddepartamento='" + coddepartamento + "'";
        }
        if (codmunicipio != "" && codmunicipio != null)
        {
            cond[2] = "m.codmunicipio='" + codmunicipio + "'";
        }
        if (codinstitucion != "" && codinstitucion != null)
        {
            cond[3] = "s.codinstitucion='" + codinstitucion + "'";
        }
        if (codsede != "" && codsede != null)
        {
            cond[4] = "rts.codsede='" + codsede + "'";
        }
        if (estrategia != "" && estrategia != null)
        {
            cond[5] = "s004redt.estrategia='" + estrategia + "'";
        }
        if (momento != "" && momento != null)
        {
            cond[6] = "s004redt.momento='" + momento + "'";
        }
        if (sesion != "" && sesion != null)
        {
            cond[7] = "s004redt.sesion='" + sesion + "'";
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

        string consulta = "select s004redt.codigo, s004redt.codredtematicasede, s004redt.nombresesion, rt.nombre, s004redt.fechaelaboracion, rts.consecutivogrupo, s004redt.momento, s004redt.sesion, rts.codsede, s.nombre as nombresede, i.nombre as nombreinstitucion, m.nombre as nombremunicipio, d.nombre as nombredepartamento from est_estra2instrumento_s004_redt s004redt inner join rt_redtematicasede rts on rts.codigo = s004redt.codredtematicasede inner join rt_redtematica rt on rt.codigo = rts.codredtematica inner join ins_sede s on s.codigo = rts.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento " + where;
        conectar.CrearComando(consulta);
      
        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return datos;
    }

    public DataTable cargarAsistentesMemoriasS004_Todo(string estrategia, string momento, string sesion)
    {
        Conexion conectar = new Conexion();

        int numero = 4;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;
        //cond[4] = string.Empty;
        //cond[5] = string.Empty;
        //cond[6] = string.Empty;
        //cond[7] = string.Empty;

        //if (coddepartamento != "" && coddepartamento != null)
        //{
        //    cond[1] = "m.coddepartamento='" + coddepartamento + "'";
        //}
        //if (codmunicipio != "" && codmunicipio != null)
        //{
        //    cond[2] = "m.codmunicipio='" + codmunicipio + "'";
        //}
        //if (codinstitucion != "" && codinstitucion != null)
        //{
        //    cond[3] = "s.codinstitucion='" + codinstitucion + "'";
        //}
        //if (codsede != "" && codsede != null)
        //{
        //    cond[4] = "rts.codsede='" + codsede + "'";
        //}
        if (estrategia != "" && estrategia != null)
        {
            cond[1] = "s004redt.estrategia='" + estrategia + "'";
        }
        if (momento != "" && momento != null)
        {
            cond[2] = "s004redt.momento='" + momento + "'";
        }
        if (sesion != "" && sesion != null)
        {
            cond[3] = "s004redt.sesion='" + sesion + "'";
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

        string consulta = "select g001d.codestumatricula from est_estra2instrumento_s004_redt s004redt inner join est_inasistenciasinstrumento_g001 g001 on g001.codinstrumentos004=s004redt.codigo inner join est_inasistenciasinstrumento_g001detalle g001d on g001.codigo=g001d.codinasistenciainstrumento_g001   " + where;
        conectar.CrearComando(consulta);

        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return datos;
    }

    public DataTable cargarListadoMemoriasS004Estra5(string coddepartamento, string codmunicipio, string estrategia, string sesion)
    {
        Conexion conectar = new Conexion();

        int numero = 5;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;
        cond[4] = string.Empty;
       

        if (coddepartamento != "" && coddepartamento != null)
        {
            cond[1] = "m.coddepartamento='" + coddepartamento + "'";
        }
        if (codmunicipio != "" && codmunicipio != null)
        {
            cond[2] = "m.codmunicipio='" + codmunicipio + "'";
        }
        if (estrategia != "" && estrategia != null)
        {
            cond[3] = "s004redt.estrategia='" + estrategia + "'";
        }
        if (sesion != "" && sesion != null)
        {
            cond[4] = "s004redt.sesion='" + sesion + "'";
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

        string consulta = "select s004redt.codigo, s004redt.actividad, s004redt.fechaelaboracion, s004redt.fechaelaboracionini,  s004redt.sesion, s004redt.lugar, m.nombre as nombremunicipio, d.nombre as nombredepartamento  from est_estrainstrumento_s004coord s004redt inner join geo_municipios m on m.cod = s004redt.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento " + where;
        conectar.CrearComando(consulta);
        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return datos;
    }

    public DataTable cargarAsistenciaMemoriasS004Estra5(string codmunicipio, string estrategia, string sesion)
    {
        Conexion conectar = new Conexion();

        int numero = 4;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;
  


        if (codmunicipio != "" && codmunicipio != null)
        {
            cond[1] = "s.codmunicipio='" + codmunicipio + "'";
        }
        if (estrategia != "" && estrategia != null)
        {
            cond[2] = "s.estrategia='" + estrategia + "'";
        }
        if (sesion != "" && sesion != null)
        {
            cond[3] = "s.sesion='" + sesion + "'";
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

        string consulta = "select ad.cods004matriculado from  est_estrainstrumento_s004coord_asist a inner join est_estrainstrumento_s004coord_asistdetalle ad on ad.codestras004coord_asist=a.codigo inner join est_estrainstrumento_s004coord s on s.codigo=a.codestras004 " + where;
        conectar.CrearComando(consulta);
        DataTable datos = conectar.traerdata();
        if (datos != null)
            return datos;
        else
            return datos;
    }

    public DataTable cargarDocentesInscritosComitesEspApro(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        Conexion conector = new Conexion();

        int numero = 5;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        //cond[0] = " g.codanio='2' and jornada is not null ";  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;
        cond[4] = string.Empty;


        if (coddepartamento != "" && coddepartamento != null)
        {
            cond[1] = "m.coddepartamento='" + coddepartamento + "'";
        }
        if (codmunicipio != "" && codmunicipio != null)
        {
            cond[2] = "i.codmunicipio='" + codmunicipio + "'";
        }
        if (codinstitucion != "" && codinstitucion != "null")
        {
            cond[3] = "s.codinstitucion='" + codinstitucion + "'";
        }
        if (codsede != "" && codsede != "null")
        {
            cond[4] = "g.codsede='" + codsede + "'";
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

        string consulta = "select doc.identificacion, doc.nombre, doc.apellido, ead.codgradodocente, g.codanio, s.nombre as sede, i.nombre as institucion, m.nombre from est_estra1espacioapropiaciondocentes ead inner join  ins_gradodocente g on g.cod=ead.codgradodocente inner join ins_docente doc on doc.identificacion=g.identificacion inner join ins_sede s on s.codigo=g.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio inner join pro_grupoinvestigacionmatriculadocentes md on md.codgradodocente=g.cod " + where;
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarApropiacionDocentesSeleccionados(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        Conexion conector = new Conexion();

        int numero = 5;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;
        cond[4] = string.Empty;


        if (coddepartamento != "" && coddepartamento != null)
        {
            cond[1] = "gmun.coddepartamento='" + coddepartamento + "'";
        }
        if (codmunicipio != "" && codmunicipio != null)
        {
            cond[2] = "iin.codmunicipio='" + codmunicipio + "'";
        }
        if (codinstitucion != "" && codinstitucion != null)
        {
            cond[3] = "isede.codinstitucion='" + codinstitucion + "'";
        }
        if (codsede != "" && codsede != null)
        {
            cond[4] = "igd.codsede='" + codsede + "'";
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

        string consulta = "SELECT evd.*, igd.*, gmun.cod as codmun, gmun.nombre as mun, iin.codigo as codins, iin.nombre as nombreins, iin.dane as daneins, isede.codigo as codsede, isede.nombre as nombresede, isede.dane as danesede, id.nombre as nombredoc, id.apellido as apellidodoc  FROM ep_feriasmunicipales_evento_detalle evd INNER JOIN ins_gradodocente igd ON evd.codgradodocente = igd.cod INNER JOIN ins_docente id ON igd.identificacion = id.identificacion INNER JOIN ins_sede isede ON isede.codigo = igd.codsede INNER JOIN ins_institucion iin ON iin.codigo = isede.codinstitucion INNER JOIN geo_municipios gmun ON gmun.cod = iin.codmunicipio " + where;
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarApropiacionDocentesEncabezado(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        Conexion conector = new Conexion();

        int numero = 5;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;
        cond[4] = string.Empty;


        if (coddepartamento != "" && coddepartamento != null)
        {
            cond[1] = "gmun.coddepartamento='" + coddepartamento + "'";
        }
        if (codmunicipio != "" && codmunicipio != null)
        {
            cond[2] = "iin.codmunicipio='" + codmunicipio + "'";
        }
        if (codinstitucion != "" && codinstitucion != null)
        {
            cond[3] = "isede.codinstitucion='" + codinstitucion + "'";
        }
        if (codsede != "" && codsede != null)
        {
            cond[4] = "igd.codsede='" + codsede + "'";
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

        string consulta = "SELECT * from ep_feriasmunicipales_evento ";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarApropiacionDocentesSeleccionadosPonencias(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        Conexion conector = new Conexion();

        //int numero = 5;
        //string[] cond;
        //cond = new string[numero];

        //cond[0] = "";  //todo
        //cond[1] = string.Empty;
        //cond[2] = string.Empty;
        //cond[3] = string.Empty;
        //cond[4] = string.Empty;


        //if (coddepartamento != "" && coddepartamento != null)
        //{
        //    cond[1] = "gmun.coddepartamento='" + coddepartamento + "'";
        //}
        //if (codmunicipio != "" && codmunicipio != null)
        //{
        //    cond[2] = "iin.codmunicipio='" + codmunicipio + "'";
        //}
        //if (codinstitucion != "" && codinstitucion != null)
        //{
        //    cond[3] = "isede.codinstitucion='" + codinstitucion + "'";
        //}
        //if (codsede != "" && codsede != null)
        //{
        //    cond[4] = "igd.codsede='" + codsede + "'";
        //}

        //string where = "";
        //int primero = 0;
        //for (int i = 0; i < numero; i++)
        //{
        //    if (cond[i] != string.Empty)
        //    {
        //        if (primero == 0)
        //        {
        //            where += "WHERE " + cond[i];
        //        }
        //        if (primero > 0)
        //        {
        //            where += " AND " + cond[i];
        //        }
        //        if (primero == 0)
        //        {
        //            primero = 1;
        //        }
        //    }
        //}

        string consulta = "SELECT ev.* from ep_feriasmunicipales_evento_evi ev inner join ep_feriasmunicipales_evento e on e.codigo=ev.codevento inner join ep_feriasmunicipales f on f.codigo=e.codferiasmunicipales where ev.actividad='Ponencias y presentaciones'";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarContenidosDigitales()
    {
        Conexion conector = new Conexion();
        string consulta = "select cd.* from est_estra2contedigital cd left join est_estra2contedigital_evi cde on cde.codinstrumento=cd.codigo";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarDocentesEstra1_Estra2()
    {
        Conexion conector = new Conexion();
        string consulta = "select codgradodocente from pro_grupoinvestigacionmatriculadocentes union select d.codgradodocente  from est_inasistenciasinstrumento_g001detalle_doc d inner join est_inasistenciasinstrumento_g001_doc g001 on g001.codigo=d.codinasistenciainstrumento_g001_doc inner join  ins_gradodocente g on g.cod=d.codgradodocente inner join ins_docente doc on doc.identificacion=g.identificacion inner join ins_sede s on s.codigo=g.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio where g.codanio='2' and jornada is not null group by doc.identificacion, doc.nombre, doc.apellido, d.codgradodocente, g.codanio, s.nombre, i.nombre, m.nombre";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarDocentesEstra1_Estra2Where(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        Conexion conector = new Conexion();

        int numero = 5;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;
        cond[4] = string.Empty;


        if (coddepartamento != "" && coddepartamento != null)
        {
            cond[1] = "m.coddepartamento='" + coddepartamento + "'";
        }
        if (codmunicipio != "" && codmunicipio != null)
        {
            cond[2] = "i.codmunicipio='" + codmunicipio + "'";
        }
        if (codinstitucion != "" && codinstitucion != "null")
        {
            cond[3] = "s.codinstitucion='" + codinstitucion + "'";
        }
        if (codsede != "" && codsede != "null")
        {
            cond[4] = "g.codsede='" + codsede + "'";
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
        string consulta = "select distinct (codgradodocente) from pro_proyectodocente d inner join ins_gradodocente g on g.cod=d.codgradodocente inner join ins_docente doc on doc.identificacion=g.identificacion inner join ins_sede s on s.codigo=g.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio " + where;
        //string consulta = "select codgradodocente from pro_grupoinvestigacionmatriculadocentes union select d.codgradodocente  from pro_proyectosede d inner join ins_gradodocente g on g.cod=d.codgradodocente inner join ins_docente doc on doc.identificacion=g.identificacion inner join ins_sede s on s.codigo=g.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio " + where + " group by doc.identificacion, doc.nombre, doc.apellido, d.codgradodocente, g.codanio, s.nombre, i.nombre, m.nombre ";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarDocentesRedestematicas()
    {
        Conexion conector = new Conexion();
        string consulta = "select * from rt_redtematicadocente";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarDocentesRedestematicasWhere(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        Conexion conector = new Conexion();

        int numero = 5;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        //cond[0] = " g.codanio='2' ";  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;
        cond[4] = string.Empty;


        if (coddepartamento != "" && coddepartamento != null)
        {
            cond[1] = "m.coddepartamento='" + coddepartamento + "'";
        }
        if (codmunicipio != "" && codmunicipio != null)
        {
            cond[2] = "i.codmunicipio='" + codmunicipio + "'";
        }
        if (codinstitucion != "" && codinstitucion != "null")
        {
            cond[3] = "s.codinstitucion='" + codinstitucion + "'";
        }
        if (codsede != "" && codsede != "null")
        {
            cond[4] = "igd.codsede='" + codsede + "'";
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
        string consulta = "SELECT  (codgradodocente) FROM rt_redtematicadocente rrd INNER JOIN ins_gradodocente igd ON igd.cod=rrd.codgradodocente inner join ins_docente doc on doc.identificacion=igd.identificacion inner join ins_sede s on s.codigo=igd.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio ";
        //string consulta = "select codgradodocente from rt_redtematicadocente rtd inner join  ins_gradodocente g on g.cod=rtd.codgradodocente inner join ins_docente doc on doc.identificacion=g.identificacion inner join ins_sede s on s.codigo=g.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio " + where + " group by doc.identificacion, doc.nombre, doc.apellido, rtd.codgradodocente, g.codanio, s.nombre, i.nombre, m.nombre ";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarDocentesApropiacionSocial()
    {
        Conexion conector = new Conexion();
        string consulta = "select * from est_estra1espacioapropiaciondocentes";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarDocentesApropiacionSocialWhere(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        Conexion conector = new Conexion();

        int numero = 5;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;
        cond[4] = string.Empty;


        if (coddepartamento != "" && coddepartamento != null)
        {
            cond[1] = "m.coddepartamento='" + coddepartamento + "'";
        }
        if (codmunicipio != "" && codmunicipio != null)
        {
            cond[2] = "i.codmunicipio='" + codmunicipio + "'";
        }
        if (codinstitucion != "" && codinstitucion != "null")
        {
            cond[3] = "s.codinstitucion='" + codinstitucion + "'";
        }
        if (codsede != "" && codsede != "null")
        {
            cond[4] = "g.codsede='" + codsede + "'";
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
        string consulta = "select doc.identificacion, doc.nombre, doc.apellido, ead.codgradodocente, g.codanio, s.nombre as sede, i.nombre as institucion, m.nombre from est_estra1espacioapropiaciondocentes ead inner join  ins_gradodocente g on g.cod=ead.codgradodocente inner join ins_docente doc on doc.identificacion=g.identificacion inner join ins_sede s on s.codigo=g.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio " + where;
        //string consulta = "select codgradodocente from est_estra1espacioapropiaciondocentes rtd inner join  ins_gradodocente g on g.cod=rtd.codgradodocente inner join ins_docente doc on doc.identificacion=g.identificacion inner join ins_sede s on s.codigo=g.codsede inner join ins_institucion i on i.codigo=s.codinstitucion inner join geo_municipios m on m.cod=i.codmunicipio " + where + " group by doc.identificacion, doc.nombre, doc.apellido, rtd.codgradodocente, g.codanio, s.nombre, i.nombre, m.nombre ";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarEvidenciasEstrategia3(string proceso)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_estra3repositorio rc inner join usu_usuario u on u.cod=rc.codusuario WHERE  proceso=@proceso ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@proceso", proceso);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargarEvidenciasEstrategia3_doble(string proceso, string proceso2)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT *, concat_ws(' ', u.pnombre,u.papellido) as nombre FROM est_estra3repositorio rc inner join usu_usuario u on u.cod=rc.codusuario WHERE  proceso=@proceso or proceso=@proceso2 ORDER BY fechacreado ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@proceso", proceso);
        conector.AsignarParametroCadena("@proceso2", proceso2);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable cargargruposinscritos(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        Conexion conector = new Conexion();

        int numero = 5;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;
        cond[4] = string.Empty;


        if (coddepartamento != "" && coddepartamento != null)
        {
            cond[1] = "m.coddepartamento='" + coddepartamento + "'";
        }
        if (codmunicipio != "" && codmunicipio != null)
        {
            cond[2] = "i.codmunicipio='" + codmunicipio + "'";
        }
        if (codinstitucion != "" && codinstitucion != null)
        {
            cond[3] = "s.codinstitucion='" + codinstitucion + "'";
        }
        if (codsede != "" && codsede != null)
        {
            cond[4] = "ps.codsede='" + codsede + "'";
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

        string consulta = "select * from gr_convocatoriasgrupos " + where;
        conector.CrearComando(consulta);

        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataTable listarEncaJornadasFormacionTodosIndicador(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string momento, string jornada)
    {
        Conexion conector = new Conexion();

         int numero = 5;
        string[] cond;
        cond = new string[numero];

        cond[0] = " eeb.momento=" + momento + " and eeb.jornada=" + jornada;  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;
        cond[4] = string.Empty;


        if (coddepartamento != "" && coddepartamento != null)
        {
            cond[1] = "m.coddepartamento='" + coddepartamento + "'";
        }
        if (codmunicipio != "" && codmunicipio != null)
        {
            cond[2] = "i.codmunicipio='" + codmunicipio + "'";
        }
        if (codinstitucion != "" && codinstitucion != "null")
        {
            cond[3] = "s.codinstitucion='" + codinstitucion + "'";
        }
        if (codsede != "" && codsede != "null")
        {
            cond[4] = "eeb.codsede='" + codsede + "'";
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

        string consulta = "SELECT eeb.*, s.nombre as nombresede,i.nombre as nombreinstitucion,m.nombre as nombremunicipio,d.nombre as nombredepartamento FROM est_estra1jornadasformacion eeb inner join ins_sede s on s.codigo = eeb.codsede inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento " + where + " order by eeb.fecharealizacion DESC";
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

    public DataTable EntregaTabletsxSede(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        Conexion conector = new Conexion();

        int numero = 5;
        string[] cond;
        cond = new string[numero];

        cond[0] = "" ;  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;
        cond[4] = string.Empty;


        if (coddepartamento != "" && coddepartamento != null)
        {
            cond[1] = "m.coddepartamento='" + coddepartamento + "'";
        }
        if (codmunicipio != "" && codmunicipio != null)
        {
            cond[2] = "i.codmunicipio='" + codmunicipio + "'";
        }
        if (codinstitucion != "" && codinstitucion != "null")
        {
            cond[3] = "s.codinstitucion='" + codinstitucion + "'";
        }
        if (codsede != "" && codsede != "null")
        {
            cond[4] = "s.codigo='" + codsede + "'";
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

        string consulta = "SELECT t.*, s.nombre as nombresede,i.nombre as nombreinstitucion,m.nombre as nombremunicipio,d.nombre as nombredepartamento from est_estra4entregatablets t inner join ins_sede s on s.dane = t.dane inner join ins_institucion i on i.codigo = s.codinstitucion inner join geo_municipios m on m.cod = i.codmunicipio inner join geo_departamentos d on d.cod = m.coddepartamento " + where;
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

    public DataRow buscarFormacionDocente(string identificacion, string pregunta, string subpregunta, string instrumento)
    {
        Conexion conector = new Conexion();
        string consulta = "select respuesta from lbase_docenteasesor da inner join lbase_respuesta res on da.codigo=res.coddocenteasesor INNER JOIN ins_gradodocente gd on gd.cod=da.codgradodocente where gd.identificacion=@identificacion and res.codpregunta=@pregunta and res.codsubpregunta=@subpregunta and res.codinstrumento=@instrumento limit 1";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@pregunta", pregunta);
        conector.AsignarParametroCadena("@subpregunta", subpregunta);
        conector.AsignarParametroCadena("@instrumento", instrumento);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;
    }

    public DataTable cargarGruposInvestigacion(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        Conexion conector = new Conexion();

        int numero = 5;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;
        cond[4] = string.Empty;


        if (coddepartamento != "" && coddepartamento != null)
        {
            cond[1] = "m.coddepartamento='" + coddepartamento + "'";
        }
        if (codmunicipio != "" && codmunicipio != null)
        {
            cond[2] = "i.codmunicipio='" + codmunicipio + "'";
        }
        if (codinstitucion != "" && codinstitucion != null)
        {
            cond[3] = "s.codinstitucion='" + codinstitucion + "'";
        }
        if (codsede != "" && codsede != null)
        {
            cond[4] = "s.codigo='" + codsede + "'";
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

    public DataTable cargarGruposInvestigacionRecursosAportadosCiclón(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        Conexion conector = new Conexion();

        int numero = 5;
        string[] cond;
        cond = new string[numero];

        cond[0] = "";  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;
        cond[4] = string.Empty;


        if (coddepartamento != "" && coddepartamento != null)
        {
            cond[1] = "m.coddepartamento='" + coddepartamento + "'";
        }
        if (codmunicipio != "" && codmunicipio != null)
        {
            cond[2] = "i.codmunicipio='" + codmunicipio + "'";
        }
        if (codinstitucion != "" && codinstitucion != "null")
        {
            cond[3] = "s.codinstitucion='" + codinstitucion + "'";
        }
        if (codsede != "" && codsede != "null")
        {
            cond[4] = "s.codigo='" + codsede + "'";
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

        string consulta = "SELECT eb1.codproyectosede, ps.nombregrupo, s.nombre as sede, i.nombre as institucion, m.nombre as municipio FROM est_estra1bitacora4punto1 eb1 INNER JOIN pro_proyectosede ps ON ps.codigo=eb1.codproyectosede INNER JOIN ins_sede s ON s.codigo=ps.codsede INNER JOIN ins_institucion i ON i.codigo=s.codinstitucion INNER JOIN geo_municipios m ON m.cod=i.codmunicipio " + where + " group by eb1.codproyectosede, ps.nombregrupo, s.nombre, i.nombre, m.nombre";
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

    public DataTable totalgruposinvestigacionfinanciados(string coddepartamento, string codmunicipio, string codinstitucion, string codsede)
    {
        Conexion conector = new Conexion();

        int numero = 5;
        string[] cond;
        cond = new string[numero];

        cond[0] = " financiado='Si' ";  //todo
        cond[1] = string.Empty;
        cond[2] = string.Empty;
        cond[3] = string.Empty;
        cond[4] = string.Empty;


        if (coddepartamento != "" && coddepartamento != null)
        {
            cond[1] = "m.coddepartamento='" + coddepartamento + "'";
        }
        if (codmunicipio != "" && codmunicipio != null)
        {
            cond[2] = "i.codmunicipio='" + codmunicipio + "'";
        }
        if (codinstitucion != "" && codinstitucion != "null")
        {
            cond[3] = "s.codinstitucion='" + codinstitucion + "'";
        }
        if (codsede != "" && codsede != "null")
        {
            cond[4] = "s.codigo='" + codsede + "'";
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

        string consulta = "SELECT gi.* FROM pro_grupoinvestigaciondocentes gi inner join ins_sede s on s.codigo=gi.codsede INNER JOIN ins_institucion i ON i.codigo=s.codinstitucion INNER JOIN geo_municipios m ON m.cod=i.codmunicipio " + where;
        conector.CrearComando(consulta);
        //conector.AsignarParametroCadena("@tipo", tipo);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

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
}