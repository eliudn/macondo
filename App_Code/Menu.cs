using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de Menu
/// </summary>
public class Menu
{
    Funciones fun = new Funciones();
    public Menu()
    {

    }
    public DataSet cargarMenu()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT a.cod,a.nombre,a.nivel,a.orden,a.nombresuperior,a.codsuperior,a.link  FROM (SELECT m.cod, m.nombre,m.nivel,m.orden,m.link, (SELECT nombre FROM usu_menu WHERE cod=m.codsuperior) AS nombresuperior, (SELECT cod FROM usu_menu WHERE cod=m.codsuperior) AS codsuperior FROM usu_menu m ORDER BY m.nivel,m.codsuperior,m.orden) AS a";
        conector.CrearComando(consulta);
        DataSet resp = conector.traerset();
        if (resp != null)
            return resp;
        else
            return null;
    }
    public DataRow buscarOrdenNivel1(String nivel)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT MAX(m.orden)'nivelmax' FROM usu_menu m WHERE m.nivel=@nivel";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nivel", nivel);
        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public Boolean agregarMenu(String nombre, String nivel, String orden, String link)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO usu_menu (nombre,nivel,orden,codsuperior,link) VALUES (@nombre,@nivel,@orden,NULL,@link)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@nivel", nivel);
        conector.AsignarParametroCadena("@orden", orden);
        conector.AsignarParametroCadena("@link", link);
        bool resp = conector.guardadata();
        return resp;
    }
    public DataTable cargarCodSuperior(String nivel)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT cod,nombre FROM usu_menu m WHERE m.nivel=@nivel";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nivel", nivel);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }
    public DataRow buscarOrdenNivel2(String nivel, String codsuperior)
    {
        Conexion conector = new Conexion();
        String consulta = "SELECT MAX(m.orden) AS nivelmax FROM usu_menu m WHERE m.nivel=@nivel AND m.codsuperior=@codsuperior";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nivel", nivel);
        conector.AsignarParametroCadena("@codsuperior", codsuperior);
        DataRow datos = conector.traerfila();
        if (datos != null)
            return datos;
        else
            return null;
    }
    public Boolean agregarMenu(String nombre, String nivel, String orden, String codsuperior, String link)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO usu_menu (nombre,nivel,orden,codsuperior,link) VALUES (@nombre,@nivel,@orden,@codsuperior,@link)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", fun.colocarPalabraenMayuscula(nombre));
        conector.AsignarParametroCadena("@nivel", nivel);
        conector.AsignarParametroCadena("@orden", orden);
        conector.AsignarParametroCadena("@codsuperior", codsuperior);
        conector.AsignarParametroCadena("@link", link);
        return conector.guardadata();
    }
    public DataSet cargarMenudePerfilHenry(String codperfil)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT u.consecutivo,(SELECT nombre FROM usu_menu WHERE cod=m.codsuperior) AS modulo,m.nombre AS menu,m.link FROM usu_usuarioacceso u INNER JOIN usu_menu m  ON u.codmenu=m.cod  WHERE u.codperfil=@codperfil ORDER BY m.nivel,m.codsuperior,m.orden";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codperfil", codperfil);
        DataSet resp = conector.traerset();
        if (resp != null)
            return resp;
        else
            return null;
    }
    public DataSet cargarMenuHenry(String codperfil)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT m.cod,(SELECT nombre FROM usu_menu WHERE cod=m.codsuperior) AS modulo,m.nombre,m.link FROM usu_menu m WHERE NOT EXISTS (SELECT 1 FROM usu_usuarioacceso u WHERE m.cod=u.codmenu AND u.codperfil=@codperfil) ORDER BY m.nivel,m.codsuperior,m.orden";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codperfil", codperfil);
        DataSet resp = conector.traerset();
        if (resp != null)
            return resp;
        else
            return null;
    }
    public Boolean asignarMenuaPerfil(String codmenu, String codperfil)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO usu_usuarioacceso (codmenu,codperfil) VALUES (@codmenu,@codperfil)";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codmenu", codmenu);
        conector.AsignarParametroCadena("@codperfil", codperfil);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean quitarMenudePerfil(String consecutivo)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM usu_usuarioacceso WHERE consecutivo=@consecutivo";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@consecutivo", consecutivo);
        bool resp = conector.guardadata();
        return resp;
    }
    public DataTable cargarMenuSuperior(String codperfil)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM usu_menu m INNER JOIN usu_usuarioacceso u ON m.cod=u.codmenu WHERE m.nivel='1' AND u.codperfil=@codperfil ORDER BY orden ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codperfil", codperfil);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }
    public DataTable cargarMenu2Nivel(String codmenu, String codperfil)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM usu_menu m INNER JOIN usu_usuarioacceso u ON m.cod=u.codmenu WHERE m.codsuperior=@codmenu AND u.codperfil=@codperfil ORDER BY m.orden ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codmenu", codmenu);
        conector.AsignarParametroCadena("@codperfil", codperfil);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }

}