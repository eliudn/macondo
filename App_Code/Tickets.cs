using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Descripción breve de Tickets
/// </summary>
public class Tickets
{
    Funciones fun = new Funciones();
	public Tickets()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    public DataTable cargarTickets(string where)
    {
        Conexion conector = new Conexion();
        //string consulta = "SELECT i.*,e.nombre'estado',p.nombre'proyecto',s.nombre'solicitud',s.ans,pri.nombre'prioridad',CONCAT_WS(' ',u.papellido,u.pnombre)'usuario',se.nombre'cliente', esc.codigo 'escalar', iseg.descripcion'descseg', iseg.fechahora'fechahora' FROM tic_incidencia i INNER JOIN con_estado e ON i.codestado=e.cod INNER JOIN con_solicitudes s ON s.cod=i.codsolicitud INNER JOIN con_prioridad pri ON s.codprioridad=pri.cod INNER JOIN pro_proyectos p ON p.cod=i.codproyecto INNER JOIN usu_usuariorol ur ON ur.cod=i.codusuariorol INNER JOIN usu_usuario u ON ur.codusuario=u.cod INNER JOIN cli_sedes se ON se.cod=i.codclisede LEFT JOIN tic_escala esc ON esc.codincidencia=i.cod LEFT JOIN tic_incidenciaseg iseg ON iseg.codincidencia=i.cod LEFT JOIN con_municipios m ON p.codmunicipio=m.cod  " + where + "  GROUP BY i.cod ORDER BY pri.nombre ASC";
        string consulta = "SELECT i.*,e.nombre'estado',p.nombre'proyecto',(SELECT isg.descripcion FROM tic_incidenciaseg isg WHERE isg.codincidencia=i.cod ORDER BY isg.cod DESC LIMIT 1)'descseg',(SELECT isg.fechahora FROM tic_incidenciaseg isg WHERE isg.codincidencia=i.cod ORDER BY isg.cod DESC LIMIT 1)'fechahora',s.nombre'solicitud',s.ans,pri.nombre'prioridad',CONCAT_WS(' ',u.papellido,u.pnombre)'usuario',se.nombre'cliente', esc.codigo 'escalar', (SELECT mu.nombre FROM con_municipios mu WHERE mu.cod=se.codmunicipio)'nomunicipio',(SELECT cain.nombre FROM tic_incidenciaseg isg INNER JOIN con_causasincidente cain ON cain.cod=isg.codcausaincidente WHERE isg.codincidencia=i.cod ORDER BY isg.cod DESC LIMIT 1)'causa', (SELECT CONCAT(uuu.pnombre,' ',uuu.papellido) FROM tic_escala tices INNER JOIN usu_usuariorol uur ON tices.codusuariorolcor=cod INNER JOIN usu_usuario uuu ON uuu.cod=uur.codusuario WHERE tices.codincidencia=i.cod ORDER BY tices.codigo DESC LIMIT 1)'escalado' FROM tic_incidencia i INNER JOIN con_estado e ON i.codestado=e.cod INNER JOIN con_solicitudes s ON s.cod=i.codsolicitud INNER JOIN con_prioridad pri ON s.codprioridad=pri.cod INNER JOIN pro_proyectos p ON p.cod=i.codproyecto INNER JOIN usu_usuariorol ur ON ur.cod=i.codusuariorol INNER JOIN usu_usuario u ON ur.codusuario=u.cod INNER JOIN cli_sedes se ON se.cod=i.codclisede LEFT JOIN tic_escala esc ON esc.codincidencia=i.cod LEFT JOIN tic_incidenciaseg iseg ON iseg.codincidencia=i.cod LEFT JOIN con_municipios m ON p.codmunicipio=m.cod LEFT JOIN con_causasincidente ci ON iseg.codcausaincidente=ci.cod  " + where + "  GROUP BY i.cod ORDER BY i.createdday DESC, pri.nombre ASC";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }
    public DataTable cargarTicketsSinResuelto()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT i.*,e.nombre'estado',p.nombre'proyecto',(SELECT isg.descripcion FROM tic_incidenciaseg isg WHERE isg.codincidencia=i.cod ORDER BY isg.cod DESC LIMIT 1)'descseg',(SELECT isg.fechahora FROM tic_incidenciaseg isg WHERE isg.codincidencia=i.cod ORDER BY isg.cod DESC LIMIT 1)'fechahora',s.nombre'solicitud',s.ans,pri.nombre'prioridad',CONCAT_WS(' ',u.papellido,u.pnombre)'usuario',se.nombre'cliente', esc.codigo 'escalar', (SELECT mu.nombre FROM con_municipios mu WHERE mu.cod=se.codmunicipio)'nomunicipio',(SELECT cain.nombre FROM tic_incidenciaseg isg INNER JOIN con_causasincidente cain ON cain.cod=isg.codcausaincidente WHERE isg.codincidencia=i.cod ORDER BY isg.cod DESC LIMIT 1)'causa',(SELECT CONCAT(uuu.pnombre,' ',uuu.papellido) FROM tic_escala tices INNER JOIN usu_usuariorol uur ON tices.codusuariorolcor=cod INNER JOIN usu_usuario uuu ON uuu.cod=uur.codusuario WHERE tices.codincidencia=i.cod ORDER BY tices.codigo DESC LIMIT 1)'escalado' FROM tic_incidencia i INNER JOIN con_estado e ON i.codestado=e.cod INNER JOIN con_solicitudes s ON s.cod=i.codsolicitud INNER JOIN con_prioridad pri ON s.codprioridad=pri.cod INNER JOIN pro_proyectos p ON p.cod=i.codproyecto INNER JOIN usu_usuariorol ur ON ur.cod=i.codusuariorol INNER JOIN usu_usuario u ON ur.codusuario=u.cod INNER JOIN cli_sedes se ON se.cod=i.codclisede LEFT JOIN tic_escala esc ON esc.codincidencia=i.cod LEFT JOIN tic_incidenciaseg iseg ON iseg.codincidencia=i.cod LEFT JOIN con_municipios m ON p.codmunicipio=m.cod LEFT JOIN con_causasincidente ci ON iseg.codcausaincidente=ci.cod WHERE e.nombre!='Resuelto' GROUP BY i.cod ORDER BY i.createdday DESC, pri.nombre ASC;";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }
    public DataTable cargarTicketsCooriAgent(string where)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT i.*,e.nombre'estado',p.nombre'proyecto',(SELECT isg.descripcion FROM tic_incidenciaseg isg WHERE isg.codincidencia=i.cod ORDER BY isg.cod DESC LIMIT 1)'descseg',(SELECT isg.fechahora FROM tic_incidenciaseg isg WHERE isg.codincidencia=i.cod ORDER BY isg.cod DESC LIMIT 1)'fechahora',s.nombre'solicitud',s.ans,pri.nombre'prioridad',CONCAT_WS(' ',u.papellido,u.pnombre)'usuario',se.nombre'cliente', esc.codigo 'escalar', (SELECT mu.nombre FROM con_municipios mu WHERE mu.cod=se.codmunicipio)'nomunicipio',(SELECT cain.nombre FROM tic_incidenciaseg isg INNER JOIN con_causasincidente cain ON cain.cod=isg.codcausaincidente WHERE isg.codincidencia=i.cod ORDER BY isg.cod DESC LIMIT 1)'causa',(SELECT CONCAT(uuu.pnombre,' ',uuu.papellido) FROM tic_escala tices INNER JOIN usu_usuariorol uur ON tices.codusuariorolcor=cod INNER JOIN usu_usuario uuu ON uuu.cod=uur.codusuario WHERE tices.codincidencia=i.cod ORDER BY tices.codigo DESC LIMIT 1)'escalado' FROM tic_incidencia i INNER JOIN con_estado e ON i.codestado=e.cod INNER JOIN con_solicitudes s ON s.cod=i.codsolicitud INNER JOIN con_prioridad pri ON s.codprioridad=pri.cod INNER JOIN pro_proyectos p ON p.cod=i.codproyecto INNER JOIN usu_usuariorol ur ON ur.cod=i.codusuariorol INNER JOIN usu_usuario u ON ur.codusuario=u.cod INNER JOIN cli_sedes se ON se.cod=i.codclisede INNER JOIN tic_escala esc ON esc.codincidencia=i.cod " + where + " GROUP BY i.cod ORDER BY i.createdday DESC, pri.nombre ASC";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }
    public DataTable cargarParticipantesTickets(string codincidencia)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT CONCAT_WS(' ',u.papellido,u.pnombre)'emisor',r.nombre'rolemisor',CONCAT_WS(' ',us.papellido,us.pnombre)'receptor',ro.nombre'rolreceptor' FROM tic_escala e INNER JOIN usu_usuariorol ur ON e.codusuariorol=ur.cod INNER JOIN usu_roles r ON ur.codrol=r.cod INNER JOIN usu_usuario u ON u.cod=ur.codusuario INNER JOIN usu_usuariorol url ON e.codusuariorolcor=url.cod INNER JOIN usu_roles ro ON url.codrol=ro.cod INNER JOIN usu_usuario us ON us.cod=url.codusuario WHERE e.codincidencia=@codincidencia ORDER BY e.createdday ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codincidencia", codincidencia);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;
    }
    
    public DataTable cargarMisTickets(string codUsuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT i.*,e.nombre'estado',p.nombre'proyecto',s.nombre'solicitud',s.ans,pri.nombre'prioridad',CONCAT_WS(' ',u.papellido,u.pnombre)'usuario',se.nombre'cliente' FROM tic_incidencia i INNER JOIN con_estado e ON i.codestado=e.cod INNER JOIN con_solicitudes s ON s.cod=i.codsolicitud INNER JOIN con_prioridad pri ON s.codprioridad=pri.cod INNER JOIN pro_proyectos p ON p.cod=i.codproyecto INNER JOIN usu_usuariorol ur ON ur.cod=i.codusuariorol INNER JOIN usu_usuario u ON ur.codusuario=u.cod INNER JOIN cli_sedes se ON se.cod=i.codclisede WHERE u.cod=@codU ORDER BY pri.nombre ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codU", codUsuario);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarTicketsClientes(string codUsuario)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT i.*, e.nombre 'estado', p.nombre 'proyecto', s.nombre 'solicitud', s.ans, pri.nombre 'prioridad', CONCAT_WS(' ', u.papellido, u.pnombre) 'usuario',  se.nombre 'cliente' FROM  tic_incidencia i   INNER JOIN con_estado e     ON i.codestado = e.cod   INNER JOIN con_solicitudes s     ON s.cod = i.codsolicitud   INNER JOIN con_prioridad pri     ON s.codprioridad = pri.cod   INNER JOIN pro_proyectos p     ON p.cod = i.codproyecto   INNER JOIN cli_sedes se     ON se.cod = i.codclisede   INNER JOIN pro_clientes pc    ON pc.cod = se.codcliente  INNER  JOIN usu_usuario u    ON pc.codusuario = u.cod WHERE pc.codusuario =@codU ORDER BY pri.nombre ASC ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codU", codUsuario);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataRow validarAsignacionesTecnicos(string codUsuarioCor, string codTicket)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM tic_escala WHERE codusuariorol=@codCor AND codincidencia=@codTicket";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codCor", codUsuarioCor);
        conector.AsignarParametroCadena("@codTicket", codTicket);
        DataRow resp = conector.traerfila();
        if (resp != null )
            return resp;
        else
            return null;

    }
    public long agregarTickets(string codusuariorol, String codsolicitud, String descripcion, string codestado, String codproyecto, String codclisede)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO tic_incidencia (codusuariorol,  codsolicitud, descripcion, codestado, codproyecto,codclisede, createdday) "
        + " VALUES (@codusuariorol,@codsolicitud,@descripcion,@codestado,@codproyecto,@codclisede,@createdday);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuariorol", codusuariorol);
        conector.AsignarParametroCadena("@codsolicitud", codsolicitud);
        conector.AsignarParametroCadena("@descripcion", descripcion);
        conector.AsignarParametroCadena("@codestado", codestado);
        conector.AsignarParametroCadena("@codproyecto", codproyecto);
        conector.AsignarParametroCadena("@codclisede", codclisede);
        conector.AsignarParametroCadena("@createdday",fun.getFechaAñoHoraActual());
        return conector.guardadataid();
    }

    public DataTable cargarCoordinadoresDeTicket(string codigo) 
    {
        Conexion con = new Conexion();
        string consulta = "SELECT DISTINCT usurol.cod, CONCAT(usu.pnombre, ' ', usu.papellido) AS nombre " +
                        "FROM tic_incidencia inc INNER JOIN " +
                             "act_asignaciones asig ON asig.codproyecto=inc.codproyecto INNER JOIN " +
                             "usu_usuariorol usurol ON asig.codusuario=usurol.codusuario INNER JOIN " +
                             "usu_usuario usu ON usurol.codusuario=usu.cod " +
                        "WHERE inc.cod=@codigo AND usurol.codrol=2";
        con.CrearComando(consulta);
        con.AsignarParametroCadena("@codigo", codigo);
        return con.traerdata();
    }
    public DataTable cargarSeguimientoTicket(string codigo){
        Conexion con = new Conexion();
        string consulta = "SELECT seg.cod,seg.fechahora,usu.usuario,seg.descripcion, con.nombre,seg.codcausaincidente " +
                        "FROM tic_incidenciaseg AS seg INNER JOIN " +
                             "usu_usuariorol AS usurol ON seg.codusuariorol=usurol.cod INNER JOIN " +
                             "usu_usuario AS usu ON usurol.codusuario=usu.cod INNER JOIN " +
                             "con_estado AS con ON seg.estado=con.cod " +
                        "WHERE seg.codincidencia=@cod";
        con.CrearComando(consulta);
        con.AsignarParametroCadena("@cod", codigo);
        return con.traerdata();
    }

    public DataTable cargarEvidenciaTicket(string codigo){

        Conexion con = new Conexion();
        string consulta="SELECT evi.cod, usu.usuario, evi.nombrearchivo, evi.nombreguardado, evi.path  "+
                        "FROM tic_incidenciaevi AS evi INNER JOIN  "+
                            "usu_usuariorol AS usurol ON evi.codusuariorol=usurol.cod INNER JOIN "+
                            "usu_usuario AS usu ON usurol.codusuario=usu.cod "+
                        "WHERE evi.codincidencia=@cod";
        con.CrearComando(consulta);
        con.AsignarParametroCadena("@cod", codigo);
        return con.traerdata();
    }

    public DataTable cargarTimeOffTicket(string codigo){
        Conexion con = new Conexion();
        string consulta = "SELECT off.cod,usu.usuario,off.descripcion,off.startday,off.endday,off.createdday, off.cantidad " +
                          "FROM tic_timeoff AS off INNER JOIN " +
                               "usu_usuariorol AS usurol ON off.codusuariorol=usurol.cod INNER JOIN " +
                               "usu_usuario AS usu ON usurol.codusuario=usu.cod " +
                          "WHERE off.codincidencia=@cod ";
        con.CrearComando(consulta);
        con.AsignarParametroCadena("@cod", codigo);
        return con.traerdata();
    }

    public DataRow buscarTicket(string codtick)
    {
         Conexion conector = new Conexion();
         string consulta = "SELECT   a.*,  CONCAT_WS(' ', u.papellido, u.pnombre) 'usuario',  p.nombre 'proyecto', (SELECT mu.nombre FROM con_municipios mu WHERE mu.cod=s.codmunicipio)'nomunicipio', e.nombre 'estado',  s.nombre 'cliente',  act.nombre 'actividad',(SELECT isg.descripcion FROM tic_incidenciaseg isg WHERE isg.codincidencia=a.cod ORDER BY isg.cod DESC LIMIT 1)'descseg' FROM  tic_incidencia a   INNER JOIN usu_usuariorol ur     ON a.codusuariorol = ur.cod   INNER JOIN usu_usuario u     ON ur.codusuario = u.cod   INNER JOIN pro_proyectos p     ON a.codproyecto = p.cod   INNER JOIN con_estado e     ON a.codestado = e.cod   INNER JOIN con_solicitudes act     ON a.codsolicitud = act.cod   INNER JOIN cli_sedes s     ON a.codclisede = s.cod WHERE a.cod = @cod";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", codtick);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;
    }

  
    public bool agregarEvidencia(string codEvidencia, string codUsuarioRol, string nombreArchivo, string nombreGuardado, string extencion, string tipo, string ruta, string tamano)
    {
        Conexion con = new Conexion();
        Funciones fun = new Funciones();
        string fecha = fun.getFechaAñoHoraActual();
        string consulta = "INSERT INTO tic_incidenciaevi (codincidencia, codusuariorol, nombrearchivo, nombreguardado, contentType, ext, path, tamano, fechacreado) "+
                          "VALUES (@evidencia, @rol, @nombreA, @nombreG, @tipo, @extencion, @ruta, @tamano, @fecha)";
        con.CrearComando(consulta);
        con.AsignarParametroCadena("@evidencia", codEvidencia);
        con.AsignarParametroCadena("@rol", codUsuarioRol);
        con.AsignarParametroCadena("@nombreA", nombreArchivo);
        con.AsignarParametroCadena("@nombreG", nombreGuardado);
        con.AsignarParametroCadena("@tipo", tipo);
        con.AsignarParametroCadena("@extencion", extencion);
        con.AsignarParametroCadena("@ruta", ruta);
        con.AsignarParametroCadena("@tamano", tamano);
        con.AsignarParametroCadena("@fecha", fecha);
        return con.guardadata();
    }

    public bool agregarTimeOff(string codTimeoff, string codUsuRol, string descripcion, string fechaI, string fechaC, string cantidad)
    {
        Conexion con = new Conexion();
        Funciones fun = new Funciones();
        string consulta = "INSERT INTO tic_timeoff (codincidencia, codusuariorol, descripcion, startday, endday, createdday, cantidad) " +
                          " VALUES(@timeoff, @codusurol, @descripcion, @startday, @endday, @createdday, @cantidad) ";
        con.CrearComando(consulta);
        con.AsignarParametroCadena("@timeoff", codTimeoff);
        con.AsignarParametroCadena("@codusurol", codUsuRol);
        con.AsignarParametroCadena("@descripcion", descripcion);
        con.AsignarParametroCadena("@startday", fechaI);
        con.AsignarParametroCadena("@endday", fechaC);
        con.AsignarParametroCadena("@createdday", fun.getFechaAñoHoraActual());
        con.AsignarParametroCadena("@cantidad", cantidad);
        return con.guardadata();
    }
    public bool agregarEscala(string codUsu, string codTicket, string codCor)
    {
        Conexion con = new Conexion();
        Funciones fun = new Funciones();
        string consulta = "INSERT INTO tic_escala (codusuariorol, codincidencia, codusuariorolcor, createdday) " +
                          "VALUES(@codUsu, @codTicket, @codCor , @fecha )  ";
        con.CrearComando(consulta);
        con.AsignarParametroCadena("@codUsu", codUsu);
        con.AsignarParametroCadena("@codTicket",codTicket);
        con.AsignarParametroCadena("@codCor", codCor);
        con.AsignarParametroCadena("@fecha", fun.getFechaAñoHoraActual());        
        return con.guardadata();
    }
    public bool agregarAsignacionesTecnicos(string codUsu, string codTicket, string codTecnico)
    {
        Conexion con = new Conexion();
        Funciones fun = new Funciones();
        string consulta = "INSERT INTO tic_escala (codusuariorol, codincidencia, codusuariorolcor, createdday) " +
                          "VALUES(@codUsu, @codTicket, @codTec , @fecha )  ";
        con.CrearComando(consulta);
        con.AsignarParametroCadena("@codUsu", codUsu);
        con.AsignarParametroCadena("@codTicket", codTicket);
        con.AsignarParametroCadena("@codTec", codTecnico);
        con.AsignarParametroCadena("@fecha", fun.getFechaAñoHoraActual());
        return con.guardadata();
    }
    //public DataRow buscarRemitente()
    //{
    //    Conexion conector = new Conexion();
    //    string consulta = "SELECT * FROM emailremitente WHERE tipo=1 LIMIT 1";
    //    conector.CrearComando(consulta);
    //    DataRow datos = conector.traerfila();
    //    return datos;
    //}
    public bool enviarMensajeporcorreo(string mensaje, string destino, string codTicket)
    {
        Email ema = new Email();
        DataRow dato = ema.buscarRemitente("1");
        DataTable datos = ema.cargarCorreosCC();
        if (dato != null && dato["envio"].ToString() == "si")
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

            msg.To.Add(destino); //destinatario
            
            string[] email;
            if(datos != null && datos.Rows.Count > 0)
            {
                email = new string[datos.Rows.Count];

                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    MailAddress cc = new MailAddress(datos.Rows[i]["email"].ToString());//Con Copia    
                     email[i]= Convert.ToString(cc);
                }
                
                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    msg.Bcc.Add(email[i]);
                }
            }
            //lblEmailCC.text = ca;
            msg.From = new MailAddress(dato["email"].ToString(), dato["nombre"].ToString(), System.Text.Encoding.UTF8); //correo emisor, nombre emisor

            DataRow datoActividad = buscarTicket(codTicket);
            msg.Subject = dato["asunto"].ToString() + " - Ticket #: " + datoActividad["cod"].ToString() + ", Cliente: " + datoActividad["cliente"].ToString() + ", Municipio: " + datoActividad["nomunicipio"].ToString(); // asunto
            msg.SubjectEncoding = System.Text.Encoding.UTF8;

            msg.Body = mensaje;

            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;

            //Aquí es donde se hace lo especial       
            //SmtpClient client = new SmtpClient();
            //client.Credentials = new System.Net.NetworkCredential(dato["email"].ToString().Trim(), dato["pass"].ToString().Trim());

            //client.Port = Convert.ToInt32(dato["port"].ToString());
            //client.Host = dato["servidorsmtp"].ToString();
            //client.EnableSsl = Convert.ToBoolean(dato["seguridadssl"].ToString());
            //client.Timeout = 5000;
            try
            {
                //client.Send(msg);
                return true;
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                return false;
                //Console.WriteLine(ex.Message);
                //Console.ReadLine();
            }
        }
        return false;
    }
    /// <summary>
    /// Este metodo agrega un seguimiento a los tickets creados por los agentes de la mesa de ayuda,
    /// el estado que recibe como parametro sera actualizado en la tabla tic_incidencia
    /// automaticamente gracias al triguuer : actualizarestadoTickets
    /// </summary>
    /// <param name="codSeguimiento"></param>
    /// <param name="codUsuRol"></param>
    /// <param name="descripcion"></param>
    /// <param name="estado"></param>
    /// <returns></returns>
    public bool agregarSeguimiento(string codSeguimiento, string codUsuRol, string descripcion, string estado, string codcausaincidente, string fecha)
    {
        Conexion con = new Conexion();
        //string fecha = fun.getFechaAñoHoraActual();
        string consulta = "INSERT INTO tic_incidenciaseg (codincidencia, codusuariorol, descripcion, fechahora, estado,codcausaincidente) " +
                          " VALUES (@incidencia, @rol, @descripcion , @fecha, @estado,@codcausaincidente)";
        con.CrearComando(consulta);
        con.AsignarParametroCadena("@incidencia", codSeguimiento);
        con.AsignarParametroCadena("@rol", codUsuRol);
        con.AsignarParametroCadena("@descripcion", descripcion);
        con.AsignarParametroCadena("@fecha", fecha);
        con.AsignarParametroCadena("@estado", estado);
        con.AsignarParametroCadena("@codcausaincidente", codcausaincidente);
        return con.guardadata();
    }
    private string cargarDetalles(string codactividad)
    {
        Actividad act = new Actividad();
        DataRow datoActividad = buscarTicket(codactividad);
        if (datoActividad != null)
        {
            string ca = "";
            //ca += "  <center>";
            ca += " <table class='mGridTesoreria'>";
            ca += "    <tr>";
            ca += "       <th>N° TICKET</th>";
            ca += "       <td>" + codactividad + "</td>";
            ca += "    </tr>";
            ca += "    <tr>";
            ca += "       <th>USUARIO</th>";
            ca += "       <td>" + datoActividad["usuario"].ToString() + "</td>";
            ca += "    </tr>";
            ca += "     <tr>";
            ca += "        <th>CREACIÓN</th>";
            ca += "        <td>" + datoActividad["createdday"].ToString() + "</td>";
            ca += "    </tr>";
            ca += "     <tr>";
            ca += "        <th>TIPO</th>";
            ca += "        <td>" + datoActividad["actividad"].ToString() + "</td>";
            ca += "    </tr>";
            ca += "     <tr>";
            ca += "        <th>PROYECTO</th>";
            ca += "        <td>" + datoActividad["proyecto"].ToString() + "</td>";
            ca += "    </tr>";
            if (datoActividad["cliente"] != null && datoActividad["cliente"].ToString() != "")
            {
                ca += "     <tr>";
                ca += "        <th>CLIENTE</th>";
                ca += "        <td>" + datoActividad["cliente"].ToString() + "</td>";
                ca += "    </tr>";
            }
            ca += "     <tr>";
            ca += "        <th>ESTADO ACTUAL</th>";
            ca += "        <td>" + datoActividad["estado"].ToString() + "</td>";
            ca += "    </tr>";
            ca += "     <tr>";
            ca += "        <th>DESCRIPCIÓN</th>";
            ca += "        <td >";
            ca += datoActividad["descripcion"].ToString();
            ca += "       </td>";
            ca += "     </tr>";
            if (datoActividad["descseg"] != null && datoActividad["descseg"].ToString() != "")
            {
                ca += "     <tr>";
                ca += "        <th>OBSERVACIÓN FINAL DEL TICKET</th>";
                ca += "        <td>" + datoActividad["descseg"].ToString() + "</td>";
                ca += "    </tr>";
            }
            //DataTable datosTecnicos = act.cargarParticipantesActividadAgendada(codactividad);
            //if (datosTecnicos != null && datosTecnicos.Rows.Count > 0)
            //{
            //    ca += "     <tr>";
            //    ca += "        <th>CUADRILLA</th>";
            //    ca += "        <td>";
            //    ca += "<ul>";
            //    for (int i = 0; i < datosTecnicos.Rows.Count; i++)
            //    {
            //        ca += "<li>" + datosTecnicos.Rows[i]["tecnico"].ToString() + "</li>";
            //    }
            //    ca += "</ul>";
            //    ca += "   </td> </tr>";
            //}

            ca += "  </table>";
            //ca += "  <center>";
            return ca;
        }
        return "";
    } 
    public string armarCuerpoDelMensaje(string codigoUsu, string codigoAct, int num)
    {
        string nombreUsuario = getNombreUsuario(codigoUsu);
        string ca = "";
        string titulo = "<div><img src='http://www.siagu.co/helpdeskfuntics/Imagenes/correo.png' alt='soporte_tecnico_header' />";
        titulo += "  <div style='max-width:650px;background-color:#fff;color:#000; padding:8px 15px 13px 15px; width:626px;'>";
        string saludoEstudiante = "";

        string preambulo = "";
        switch (num){
            case 1:
                saludoEstudiante = "<h2>Hola, " + nombreUsuario + "</h2>";
                preambulo = " <br />Se ha generado tu solicitud de Ticket: #"+codigoAct+" <br />";
             break;
            case 2:
                saludoEstudiante = "<h2>SOPORTE TECNICO :</h2>";
                preambulo = " <br />Se ha generado una nueva solicitud de Ticket : #" + nombreUsuario + " <br />";
            break;
        }
        string actividades = cargarDetalles(codigoAct);

        string despedida = " </div><div style='background-color:#333333;color:#999999;opacity:0,5;width:626px;height:50px;padding:8px 15px 13px 15px;'>";
        despedida += "<br /> <p style='margin:0 auto;text-align:center'>Copyright © 2015 CloudNets. Todos los derechos reservados. <a href='http://www.funtics.org/'";
        despedida += "style='text-decoration:none;background-color:#333333;color:#999999;' target='_blank'>www.funtics.org.</a> </p></div></div>";

        ca = titulo + saludoEstudiante + preambulo + actividades + despedida;
        return ca;
    }
    public string armarCuerpoDelMensajeEscalar(string codigoUsu, string codigoAct, int num)
    {
        string nombreUsuario = getNombreUsuario(codigoUsu);
        string ca = "";
        string titulo = "<div><img src='http://www.siagu.co/helpdeskfuntics/Imagenes/correo.png' alt='soporte_tecnico_header' />";
        titulo += "  <div style='max-width:650px;background-color:#fff;color:#000; padding:8px 15px 13px 15px; width:626px;'>";
        string saludoEstudiante = "";

        string preambulo = "";
        switch (num)
        {
            case 1:
                saludoEstudiante = "<h2>Hola, " + nombreUsuario + "</h2>";
                preambulo = " <br />Se ha generado tu solicitud de Ticket: #" + codigoAct + " <br />";
                break;
            case 2:
                saludoEstudiante = "<h2>SOPORTE TÉCNICO:</h2>";
                //preambulo = " <br />Se ha generado un nuevo escalamiento de solicitud para el Ticket : #" + nombreUsuario + " <br />";
                preambulo = " <br />Se ha generado un nuevo escalamiento de solicitud, los detalles a continuación: <br />";
                break;
        }
        string actividades = cargarDetalles(codigoAct);

        string despedida = " </div><div style='background-color:#333333;color:#999999;opacity:0,5;width:626px;height:50px;padding:8px 15px 13px 15px;'>";
        despedida += "<br /> <p style='margin:0 auto;text-align:center'>Copyright © 2015 CloudNets. Todos los derechos reservados. <a href='http://www.funtics.org/'";
        despedida += "style='text-decoration:none;background-color:#333333;color:#999999;' target='_blank'>www.funtics.org.</a> </p></div></div>";

        ca = titulo + saludoEstudiante + preambulo + actividades + despedida;
        return ca;
    }
    private string getNombreUsuario(string codUsuario) 
    {
        Conexion con = new Conexion();
        string consulta = "SELECT CONCAT(pnombre,' ', snombre, ' ', papellido) as nombre " +
                          "FROM usu_usuario WHERE cod=@cod";
        con.CrearComando(consulta);
        con.AsignarParametroCadena("@cod", codUsuario);
        DataRow fila = con.traerfila();
        if (fila != null) 
        {
            return fila["nombre"].ToString();
        }
        return "";
    }

    //public string buscarReceptor()
    //{
    //    Conexion conector = new Conexion();
    //    string consulta = "SELECT email FROM emailremitente WHERE tipo=2 LIMIT 1";
    //    conector.CrearComando(consulta);
    //    DataRow datos = conector.traerfila();
    //    if (datos!=null) 
    //    {
    //        return datos["email"].ToString();
    //    }
    //    return "";
    //}
    public string getEmailUsuario(string codUsuario)
    {
        Conexion con = new Conexion();
        string consulta = "SELECT email " +
                          "FROM usu_usuario WHERE cod=@cod";
        con.CrearComando(consulta);
        con.AsignarParametroCadena("@cod", codUsuario);
        DataRow fila = con.traerfila();
        if (fila != null)
        {
            return fila["email"].ToString();
        }
        return "";
    }
    public string getEmailUsuarioCoord(string codUsuario)
    {
        Conexion con = new Conexion();
        string consulta = "SELECT email FROM usu_usuario u INNER JOIN usu_usuariorol ur ON u.cod=ur.codusuario WHERE ur.cod=@cod";
        con.CrearComando(consulta);
        con.AsignarParametroCadena("@cod", codUsuario);
        DataRow fila = con.traerfila();
        if (fila != null)
        {
            return fila["email"].ToString();
        }
        return "";
    }

    public Boolean eliminarEscala(String codincidencia)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM tic_escala WHERE codincidencia=@codincidencia";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codincidencia", codincidencia);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarEvidencia(String codincidencia)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM tic_incidenciaevi WHERE codincidencia=@codincidencia";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codincidencia", codincidencia);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarSeguimiento(String codincidencia)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM tic_incidenciaseg WHERE codincidencia=@codincidencia";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codincidencia", codincidencia);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarTimeOff(String codincidencia)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM tic_timeoff WHERE codincidencia=@codincidencia";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codincidencia", codincidencia);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarTimeOffxCod(String cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM tic_timeoff WHERE cod=@cod";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        bool resp = conector.guardadata();
        return resp;
    }
    public Boolean eliminarIncidencia(String codincidencia)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM tic_incidencia WHERE cod=@codincidencia";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codincidencia", codincidencia);
        bool resp = conector.guardadata();
        return resp;
    }

    public Boolean editarIncidenciaEstado(String codincidencia,string estado)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE tic_incidencia SET codestado=@estado WHERE cod=@codincidencia";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codincidencia", codincidencia);
        conector.AsignarParametroCadena("@estado", estado);
        bool resp = conector.guardadata();
        return resp;
    }

    public DataRow buscarIncidente(string codTicket)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM tic_incidenciaseg isg WHERE isg.codincidencia=@codTicket";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codTicket", codTicket);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;

    }

    public DataRow CargarTicketAbiertoxCliente(string codclisede)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM tic_incidencia WHERE codclisede=@codclisede AND codestado!=3";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codclisede", codclisede);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;
    }

}