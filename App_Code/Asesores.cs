using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Usuario
/// </summary>
public class Asesores
{
    public Asesores()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    public DataRow buscarCodDocenteAsesor(string codasesor, string identificacion)
    {
        Conexion conector = new Conexion();
        String consulta = "select da.*, concat_ws(' ',a.nombre,a.apellido) as nombre from lbase_docenteasesor da inner join ins_gradodocente gd on da.codgradodocente=gd.cod inner join ins_asesor a on a.codigo=da.codasesor WHERE gd.identificacion=@identificacion and da.codasesor=@codasesor limit 1 ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@codasesor", codasesor);
        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public DataRow buscarAsesorCoordinadorEstrategiaxIdentificacion(string identificacion)
    {
        Conexion conector = new Conexion();
        String consulta = "select ec.codigo as codestracoordinador from est_coordinador c inner join est_estracoordinador ec on ec.codcoordinador=c.codigo where c.identificacion=@identificacion";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public DataRow buscarAsesorxEstrategiaxIdentificacion(string identificacion)
    {
        Conexion conector = new Conexion();
        String consulta = "select ac.codigo as codasesorcoordinador from est_asesorcoordinador ac inner join est_asesor a on ac.codasesor=a.codigo where a.identificacion=@identificacion";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public DataTable cargarAsesores()
    {
        Conexion conector = new Conexion();
        string consulta = "select codigo, CONCAT_WS(' ',identificacion, ' - ',nombre,apellido) AS nombre from ins_asesor where estado='On' order by apellido ASC";
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


    public bool agregarUsuarioBool(String usuario, String pass, string identificacion, string pnombre, string snombre, string papellido, string sapellido, string telefono, string celular, string email)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO usu_usuario (usuario,pass,identificacion,pnombre,snombre,papellido,sapellido,email,telefono,celular,estado) " +
            "VALUES (@usuario,MD5(@pass),@identificacion,@pnombre,@snombre,@papellido,@sapellido,@email,@telefono,@celular,'On');";
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
        return conector.guardadata();
    }
    public DataRow agregarUsuarioPG(String usuario, String pass, string identificacion, string pnombre, string snombre, string papellido, string sapellido, string telefono, string celular, string email)
    {
        Conexion conector = new Conexion();
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
        DataRow datos = conector.guardadataidPG();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public DataRow agregarAsesor(String identificacion, String nombre, string apellido, string telefono, string email)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_asesor (identificacion,nombre,apellido,telefono,email) " +
            "VALUES (@identificacion,@nombre,@apellido,@telefono,@email) RETURNING codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@nombre", nombre.ToUpper());
        conector.AsignarParametroCadena("@apellido", apellido);
        conector.AsignarParametroCadena("@telefono", telefono);
        conector.AsignarParametroCadena("@email", email);
     
        DataRow datos = conector.guardadataidPG();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public bool agregarAsesorcoordinador(String codasesor, String codestracoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_asesorcoordinador (codasesor,codestracoordinador) " +
            "VALUES (@codasesor,@codestracoordinador);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesor", codasesor);
        conector.AsignarParametroCadena("@codestracoordinador", codestracoordinador);
        return conector.guardadata();
    }

    public DataRow agregarCoordinador(String identificacion, String nombre, string apellido, string telefono, string email)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_coordinador (identificacion,nombre,apellido,telefono,email) " +
            "VALUES (@identificacion,@nombre,@apellido,@telefono,@email) RETURNING codigo;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@nombre", nombre.ToUpper());
        conector.AsignarParametroCadena("@apellido", apellido);
        conector.AsignarParametroCadena("@telefono", telefono);
        conector.AsignarParametroCadena("@email", email);

        DataRow datos = conector.guardadataidPG();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public bool agregarEstraCoordinador(String codestrategia, String codcoordinador)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO est_estracoordinador (codestrategia,codcoordinador) " +
            "VALUES (@codestrategia,@codcoordinador);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codestrategia", codestrategia);
        conector.AsignarParametroCadena("@codcoordinador", codcoordinador);
        return conector.guardadata();
    }

    public DataTable cargarAsesoresCoordinador()
    {
        Conexion conector = new Conexion();
        string consulta = "select ac.codigo as codasesorcoordinador, CONCAT_WS(' ',a.nombre,a.apellido) as nombre from est_asesor a inner join est_asesorcoordinador ac on ac.codasesor=a.codigo ";
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

    public DataTable cargarAsesoresxEstrategia(string codestrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "select ac.codigo as codasesorcoordinador, CONCAT_WS(' ',a.nombre,a.apellido) as nombre from est_asesor a inner join est_asesorcoordinador ac on ac.codasesor=a.codigo inner join est_estracoordinador ec on ec.codigo=ac.codestracoordinador where ec.codestrategia=@codestrategia ";
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

    public DataTable cargarCoordinadoresxEstrategia(string codestrategia)
    {
        Conexion conector = new Conexion();
        string consulta = "select ec.*, concat_ws(' ', c.nombre,c.apellido) as nombre from est_estracoordinador ec inner join est_coordinador c on c.codigo=ec.codcoordinador where ec.codestrategia=@codestrategia ";
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

    public DataRow buscarCodUserxIdentificacionAsesor(string idbuscar)
    {
        Conexion conector = new Conexion();
        String consulta = "select cod from usu_usuario where identificacion=@idbuscar";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@idbuscar", idbuscar);
        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public DataRow buscarCodUserxIdentificacionAsesorCoord(string codasesorcoordinador)
    {
        Conexion conector = new Conexion();
        String consulta = "select u.cod from usu_usuario u inner join est_asesor a on cast(a.identificacion as varchar)=u.identificacion inner join est_asesorcoordinador ac on ac.codasesor=a.codigo where ac.codigo=@codasesorcoordinador";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codasesorcoordinador", codasesorcoordinador);
        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public Boolean editarDatosAsesor(String identificacion, string nombre, String apellido, String telefono, string email, string id)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_asesor SET  identificacion = @identificacion,nombre =@nombre, apellido =@apellido,telefono = @telefono,email = @email WHERE identificacion = @id;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@id", id);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@apellido", apellido);
        conector.AsignarParametroCadena("@email", email);
        conector.AsignarParametroCadena("@telefono", telefono);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean editarDatosCoordinador(String identificacion, string nombre, String apellido, String telefono, string email, string id)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE est_coordinador SET  identificacion = @identificacion,nombre =@nombre, apellido =@apellido,telefono = @telefono,email = @email WHERE identificacion = @id;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@id", id);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@apellido", apellido);
        conector.AsignarParametroCadena("@email", email);
        conector.AsignarParametroCadena("@telefono", telefono);
        bool resp = conector.guardadata();
        return resp;
    }

    public DataRow buscarasesorlineabase(string dane)
    {
        Conexion conector = new Conexion();
        String consulta = "select ia.* from lbase_institucionasesor ia inner join ins_institucion i on ia.codinstitucion=i.codigo where i.dane=@dane";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@dane", dane);
        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public DataRow buscarinsasesor(string codinstitucion)
    {
        Conexion conector = new Conexion();
        String consulta = "select * from lbase_institucionasesor  where codinstitucion=@codinstitucion";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstitucion", codinstitucion);
        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }

    public bool editarinsasesor(string codasesor, string codinstitucion)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE lbase_institucionasesor SET codasesor = @codasesor WHERE codinstitucion = @codinstitucion;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codinstitucion", codinstitucion);
        conector.AsignarParametroCadena("@codasesor", codasesor);
        return conector.guardadata();
    }

    public bool editarInstitucionIntermedia(string nombre, string telefono, string fax, string email, string direccion, string web, string dane)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE ins_institucion SET nombre = @nombre, web = @web, telefono = @telefono, fax =@fax, email=@email, direccion=@direccion WHERE dane = @dane;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@dane", dane);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@telefono", telefono);
        conector.AsignarParametroCadena("@fax", fax);
        conector.AsignarParametroCadena("@email", email);
        conector.AsignarParametroCadena("@web", web);
        conector.AsignarParametroCadena("@direccion", direccion);
        return conector.guardadata();
    }
	
    public bool editarInstitucionImpacto(string nombre, string telefono, string fax, string email, string direccion, string web, string dane, string sedesbeneficidas, string is16, string is17, string is18, string is16s, string is17s, string is18s, string is16m, string is17m, string is18m)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE ins_institucion SET nombre = @nombre, web = @web, telefono = @telefono, fax =@fax, email=@email, direccion=@direccion, sedesbeneficidas=@sedesbeneficidas, isce16=@is16, isce17=@is17, isce18=@is18, isce16s=@is16s, isce17s=@is17s, isce18s=@is18s, isce16m=@is16m, isce17m=@is17m, isce18m=@is18m  WHERE dane = @dane;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@dane", dane);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@telefono", telefono);
        conector.AsignarParametroCadena("@fax", fax);
        conector.AsignarParametroCadena("@email", email);
        conector.AsignarParametroCadena("@web", web);
        conector.AsignarParametroCadena("@direccion", direccion);

        conector.AsignarParametroCadena("@sedesbeneficidas", sedesbeneficidas);
        conector.AsignarParametroCadena("@is16", is16);
        conector.AsignarParametroCadena("@is17", is17);
        conector.AsignarParametroCadena("@is18", is18);
        conector.AsignarParametroCadena("@is16s", is16s);
        conector.AsignarParametroCadena("@is17s", is17s);
        conector.AsignarParametroCadena("@is18s", is18s);
        conector.AsignarParametroCadena("@is16m", is16m);
        conector.AsignarParametroCadena("@is17m", is17m);
        conector.AsignarParametroCadena("@is18m", is18m);
        return conector.guardadata();
    }

	/*** metodo Eliud 
     te trae la codigo, identificacion y nombre  del asesor en la tabla lbase_respuesta
     	*/

        public DataRow cargarAsesorInstrumento2(string identificacion,string fases,string codinstrumento)
    {
        Conexion conector = new Conexion();
        string consulta ="select ia.codigo, CONCAT_WS(' ',ia.identificacion, ' - ',ia.nombre,ia.apellido) as nombre from ins_asesor ia inner join lbase_docenteasesor lbda on lbda.codasesor=ia.codigo inner join ins_gradodocente ig on ig.cod=lbda.codgradodocente inner join lbase_respuesta lbr on lbr.coddocenteasesor=lbda.codigo where ig.identificacion=@identificacion and lbr.fase=@fases and lbr.codinstrumento=@codinstrumento";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@identificacion", identificacion);
        conector.AsignarParametroCadena("@fases", fases);
        conector.AsignarParametroCadena("@codinstrumento", codinstrumento);
        DataRow resp=conector.traerfila();
        if(resp != null){
            return resp;
        }else{
            return null;
        }/**fin */
    }

	

}