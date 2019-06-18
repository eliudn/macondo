using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Email
/// </summary>
public class Email
{
	public Email()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    public DataRow buscarRemitente(string tipo)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM emailremitente WHERE tipo=@tipo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@tipo", tipo);
        DataRow datos = conector.traerfila();
        return datos;
    }
    public DataTable  cargarCorreos()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM emailremitente";
        conector.CrearComando(consulta);
        DataTable datos = conector.traerdata();
        return datos;
    }
    public DataTable cargarCorreosCC()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM emailcc";
        conector.CrearComando(consulta);
        DataTable datos = conector.traerdata();
        return datos;
    }
    public DataRow buscarVariablesPrueba()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM con_pruebas LIMIT 1;";
        conector.CrearComando(consulta);
        DataRow datos = conector.traerfila();
        return datos;
    }
    public Boolean editarRemitente(String emailnuevo, String pass, String nombre, String asunto, string port, string servidorsmtp, string seguridadssl, String emailviejo)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE emailremitente SET email=@emailnuevo,pass=@pass,nombre=@nombre,asunto=@asunto,port=@port,servidorsmtp=@servidorsmtp,seguridadssl=@seguridadssl WHERE email=@emailviejo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@emailnuevo", emailnuevo);
        conector.AsignarParametroCadena("@pass", pass);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@asunto", asunto);
        conector.AsignarParametroCadena("@port", port);
        conector.AsignarParametroCadena("@servidorsmtp", servidorsmtp);
        conector.AsignarParametroCadena("@seguridadssl", seguridadssl);
        conector.AsignarParametroCadena("@emailviejo", emailviejo);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean agregarRemitente(string emailnuevo, string pass, string nombre, string asunto, string port, string servidorsmtp, string seguridadssl, string tipo)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT emailremitente (email,pass,nombre,asunto,port,servidorsmtp,seguridadssl,tipo) VALUES (@emailnuevo,@pass,@nombre,@asunto,@port,@servidorsmtp,@seguridadssl,@tipo)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@emailnuevo", emailnuevo);
        conector.AsignarParametroCadena("@pass", pass);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@asunto", asunto);
        conector.AsignarParametroCadena("@port", port);
        conector.AsignarParametroCadena("@servidorsmtp", servidorsmtp);
        conector.AsignarParametroCadena("@seguridadssl", seguridadssl);
        conector.AsignarParametroCadena("@tipo", tipo);

        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean agregarEmailCC(string emailnuevo, string nombre)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT emailcc (nombre,email) VALUES (@nombre,@emailnuevo)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@emailnuevo", emailnuevo);
        conector.AsignarParametroCadena("@nombre", nombre);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarRemitente(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM emailremitente WHERE cod=@cod ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarEmailCC(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM emailcc WHERE codigo=@cod ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean agregarVariables(string sm, string ccq, string ttlnodo, string ttlweb, string ancho)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO con_pruebas (sm, ccq, ttlnodo, ttlweb, ancho) VALUES (@sm,@ccq,@ttlnodo,@ttlweb,@ancho);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@sm", sm);
        conector.AsignarParametroCadena("@ccq", ccq);
        conector.AsignarParametroCadena("@ttlnodo", ttlnodo);
        conector.AsignarParametroCadena("@ttlweb", ttlweb);
        conector.AsignarParametroCadena("@ancho", ancho);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean editarVariables(string sm, string ccq, string ttlnodo, string ttlweb, string ancho)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE con_pruebas SET sm = @sm, ccq = @ccq,ttlnodo = @ttlnodo,ttlweb = @ttlweb, ancho = @ancho";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@sm", sm);
        conector.AsignarParametroCadena("@ccq", ccq);
        conector.AsignarParametroCadena("@ttlnodo", ttlnodo);
        conector.AsignarParametroCadena("@ttlweb", ttlweb);
        conector.AsignarParametroCadena("@ancho", ancho);
        bool resp = conector.guardadata();
        return resp;
    }
}