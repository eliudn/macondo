using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Data;

/// <summary>
/// Descripción breve de WebAutoComplete
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Para permitir que se llame a este servicio Web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
[System.Web.Script.Services.ScriptService]
public class WebAutoComplete : System.Web.Services.WebService {

    public WebAutoComplete () {        
    }
    [WebMethod]
    [ScriptMethod]
    public String[] GetEstudiante(string prefixText, int count)
    {
        Conexion con = new Conexion();
        String cadena = "SELECT CONCAT_WS(' ',id,primernombre,segundonombre,primerapellido,segundoapellido) FROM est_estudiantes e WHERE CONCAT_WS(' ',id,primernombre,segundonombre,primerapellido,segundoapellido) LIKE '%" + prefixText + "%'";
        con.CrearComando(cadena);
        DataTable datos = con.traerdata();

        String[] resp = new String[datos.Rows.Count];

        for (int i = 0; i < datos.Rows.Count; i++)
        {
            resp[i] = datos.Rows[i][0].ToString();
        }
        return resp;
    }
  
    [WebMethod]
    [ScriptMethod]
    public String[] GetListaUsuariosEstudiante(string prefixText, int count)
    {
        Conexion con = new Conexion();
        String cadena = "SELECT CONCAT_WS(' ',id,primernombre,segundonombre,primerapellido,segundoapellido) FROM est_estudiantes WHERE CONCAT_WS(' ',id,primernombre,segundonombre,primerapellido,segundoapellido) LIKE '%" + prefixText + "%'";
        con.CrearComando(cadena);
        DataTable datos = con.traerdata();

        String[] resp = new String[datos.Rows.Count];

        for (int i = 0; i < datos.Rows.Count; i++)
        {
            resp[i] = datos.Rows[i][0].ToString();
        }
        return resp;
    }
    [WebMethod]
    [ScriptMethod]
    public String[] GetListaClientes(string prefixText, int count)
    {
        Conexion con = new Conexion();
        String cadena = "SELECT CONCAT_WS(' ',s.dane,s.nombre) FROM (ins_institucion c LEFT JOIN ins_sede s ON c.codigo=s.codinstitucion) WHERE CONCAT_WS(' ',c.dane,c.nombre)  ILIKE '%" + prefixText + "%'";
        con.CrearComando(cadena);
        DataTable datos = con.traerdata();

        String[] resp = new String[datos.Rows.Count];

        for (int i = 0; i < datos.Rows.Count; i++)
        {
            resp[i] = datos.Rows[i][0].ToString();
        }
        return resp;
    }
    [WebMethod]
    [ScriptMethod]
    public String[] GetListaUsuariosTienda(string prefixText, int count)
    {
        Conexion con = new Conexion();
        String cadena = "SELECT CONCAT_WS(' ',identificacion,nombre_completo) FROM tie_usuarios_completos WHERE CONCAT_WS(' ',identificacion,nombre_completo) LIKE '%" + prefixText + "%'";
        con.CrearComando(cadena);
        DataTable datos = con.traerdata();

        String[] resp = new String[datos.Rows.Count];

        for (int i = 0; i < datos.Rows.Count; i++)
        {
            resp[i] = datos.Rows[i][0].ToString();
        }
        return resp;
    }

    [WebMethod]
    [ScriptMethod]
    public String[] GetListaUsuarios(string prefixText, int count)
    {
        Conexion con = new Conexion();
        String cadena = "SELECT CONCAT(nombres,' ',apellidos) FROM usu_usuario WHERE CONCAT(nombres,' ',apellidos) LIKE '%" + prefixText + "%'";
        con.CrearComando(cadena);
        DataTable datos = con.traerdata();

        String[] resp = new String[datos.Rows.Count];

        for (int i = 0; i < datos.Rows.Count; i++)
        {
            resp[i] = datos.Rows[i][0].ToString();
        }
        return resp;
    }
    [WebMethod]
    [ScriptMethod]
    public String[] GetListaUsuariosDocentes(string prefixText, int count)
    {
        Conexion con = new Conexion();
        String cadena = "SELECT CONCAT_WS(' ',id,pnombre,snombre,papellido,sapellido) FROM doc_docentes WHERE CONCAT_WS(' ',id,pnombre,snombre,papellido,sapellido) LIKE '%" + prefixText + "%'";
        con.CrearComando(cadena);
        DataTable datos = con.traerdata();

        String[] resp = new String[datos.Rows.Count];

        for (int i = 0; i < datos.Rows.Count; i++)
        {
            resp[i] = datos.Rows[i][0].ToString();
        }
        return resp;
    }

    [WebMethod]
    [ScriptMethod]
    public String[] GetListaDocentesxInstitucion(string prefixText, int count)
    {
        Conexion con = new Conexion();
        String cadena = "select gd.cod,d.identificacion, CONCAT_WS(' ', d.nombre,d.apellido) as nombrecompleto, d.sexo,d.email, s.dane,s.nombre as nomsede, s.sede, m.nombre as municipio from ins_institucion i inner join ins_sede s on i.codigo=s.codinstitucion inner join ins_gradodocente gd on gd.codsede=s.codigo inner join ins_docente d on d.identificacion=gd.identificacion inner join geo_municipios m on m.cod=s.codmunicipio where CONCAT_WS(' ',s.dane,s.nombre) ILIKE '%" + prefixText + "%'";
        con.CrearComando(cadena);
        DataTable datos = con.traerdata();

        String[] resp = new String[datos.Rows.Count];

        for (int i = 0; i < datos.Rows.Count; i++)
        {
            resp[i] = datos.Rows[i][0].ToString();
        }
        return resp;
    }
}
