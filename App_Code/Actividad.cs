using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Net.Mail;

/// <summary>
/// Descripción breve de Actividad
/// </summary>
public class Actividad
{
    Funciones fun = new Funciones();
    public string title { get; set; }
    public string start { get; set; }
    public string end { get; set; }
    public string color { get; set; }
	public Actividad()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}
    public DataTable cargarActividadesAgendadas(string where)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT a.*,ac.nombre 'actividad',e.* ,p.nombre'proyecto', CONCAT('',s.nombre,' - ',s.nit)'cliente', (SELECT m.nombre FROM con_municipios m WHERE m.cod=s.codmunicipio)'municipio' FROM act_agenda a INNER JOIN con_actividades ac ON a.codtipoactividad = ac.cod INNER JOIN con_estado e ON a.codestado = e.cod INNER JOIN pro_proyectos p ON a.codproyecto=p.cod INNER JOIN cli_sedes s ON s.cod=a.codcliente " + where + " ORDER BY a.createdday DESC";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
              return resp;
        else
              return null;
        
    }
    public DataTable cargarActividadesAgendadasSinResuelto(string where)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT a.*,ac.nombre 'actividad',e.* ,p.nombre'proyecto', CONCAT('',s.nombre,' - ',s.nit)'cliente', (SELECT m.nombre FROM con_municipios m WHERE m.cod=s.codmunicipio)'municipio' FROM act_agenda a INNER JOIN con_actividades ac ON a.codtipoactividad = ac.cod INNER JOIN con_estado e ON a.codestado = e.cod INNER JOIN pro_proyectos p ON a.codproyecto=p.cod INNER JOIN cli_sedes s ON s.cod=a.codcliente " + where + " AND e.nombre!='Resuelto' ORDER BY a.createdday DESC";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarActividadesAgendadasxCoordinador(string where)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT a.*,ac.nombre 'actividad',e.* ,p.nombre'proyecto', CONCAT('',s.nombre,' - ',s.nit)'cliente', (SELECT m.nombre FROM con_municipios m WHERE m.cod=s.codmunicipio)'municipio' FROM act_agenda a INNER JOIN con_actividades ac ON a.codtipoactividad = ac.cod INNER JOIN con_estado e ON a.codestado = e.cod INNER JOIN pro_proyectos p ON a.codproyecto=p.cod INNER JOIN cli_sedes s ON s.cod=a.codcliente " + where + "  ORDER BY a.createdday DESC";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarActividadesAgendadasxCoordinadorSinResuelto(string where)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT a.*,ac.nombre 'actividad',e.* ,p.nombre'proyecto', CONCAT('',s.nombre,' - ',s.nit)'cliente', (SELECT m.nombre FROM con_municipios m WHERE m.cod=s.codmunicipio)'municipio' FROM act_agenda a INNER JOIN con_actividades ac ON a.codtipoactividad = ac.cod INNER JOIN con_estado e ON a.codestado = e.cod INNER JOIN pro_proyectos p ON a.codproyecto=p.cod INNER JOIN cli_sedes s ON s.cod=a.codcliente " + where + " AND e.nombre!='Resuelto' ORDER BY a.createdday DESC";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarActividadesAgendadasxTecnico(string where)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT a.*,ac.nombre 'actividad',e.* ,p.nombre'proyecto', CONCAT('',s.nombre,' - ',s.nit)'cliente', (SELECT m.nombre FROM con_municipios m WHERE m.cod=s.codmunicipio)'municipio' FROM  act_agendaparti ap INNER JOIN act_agenda a ON ap.codagenda=a.cod INNER JOIN con_actividades ac ON a.codtipoactividad = ac.cod  INNER JOIN con_estado e ON a.codestado = e.cod INNER JOIN pro_proyectos p ON a.codproyecto=p.cod INNER JOIN cli_sedes s ON s.cod=a.codcliente " + where + " ORDER BY a.createdday DESC";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarActividadesAgendadasxTecnicoSinResuelto(string where)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT a.*,ac.nombre 'actividad',e.* ,p.nombre'proyecto', CONCAT('',s.nombre,' - ',s.nit)'cliente', (SELECT m.nombre FROM con_municipios m WHERE m.cod=s.codmunicipio)'municipio' FROM  act_agendaparti ap INNER JOIN act_agenda a ON ap.codagenda=a.cod INNER JOIN con_actividades ac ON a.codtipoactividad = ac.cod  INNER JOIN con_estado e ON a.codestado = e.cod INNER JOIN pro_proyectos p ON a.codproyecto=p.cod INNER JOIN cli_sedes s ON s.cod=a.codcliente " + where + " AND e.nombre!='Resuelto' ORDER BY a.createdday DESC";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarEstados()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM con_estado ORDER BY nombre ASC";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarActividades()
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM con_actividades ORDER BY nombre ASC";
        conector.CrearComando(consulta);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataRow buscarActividad(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT * FROM con_actividades WHERE cod=@cod";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataRow buscarActividadAgendada(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT a.*,CONCAT_WS(' ',u.papellido,u.pnombre)'usuario',p.nombre'proyecto',(SELECT mu.nombre FROM con_municipios mu WHERE mu.cod=s.codmunicipio)'nomunicipio',e.nombre'estado',s.nombre'cliente',act.nombre'actividad' FROM act_agenda a INNER JOIN usu_usuariorol ur ON a.codusuariorol=ur.cod INNER JOIN usu_usuario u ON ur.codusuario=u.cod INNER JOIN pro_proyectos p ON a.codproyecto=p.cod INNER JOIN con_estado e ON a.codestado=e.cod INNER JOIN con_actividades act ON a.codtipoactividad=act.cod LEFT JOIN cli_sedes s ON a.codcliente=s.cod WHERE a.cod=@cod";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        DataRow resp = conector.traerfila();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarParticipantesActividadAgendada(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT CONCAT_WS(' ',u.papellido,u.pnombre)'tecnico',ur.cod, r.nombre'rol' FROM act_agendaparti ap INNER JOIN usu_usuariorol ur ON ap.codusuariorol=ur.cod INNER JOIN usu_usuario u ON ur.codusuario=u.cod INNER JOIN usu_roles r ON r.cod=ur.codrol WHERE ap.codagenda=@cod ORDER BY u.papellido,u.sapellido,u.pnombre,u.snombre ASC;";
        /*string consulta = "SELECT CONCAT_WS(' ',u.papellido,u.pnombre)'tecnico',ur.cod FROM act_agendaparti ap INNER JOIN usu_usuariorol ur ON ap.codusuariorol=ur.cod INNER JOIN usu_usuario u ON ur.codusuario=u.cod WHERE ap.codagenda=@cod ORDER BY u.papellido,u.sapellido,u.pnombre,u.snombre ASC";*/
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public bool agregarActividad(string nombre,string ans)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO con_actividades (nombre,ans) VALUES (@nombre,@ans);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@ans",ans);
        return conector.guardadata();

    }
    public bool eliminarActividad(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM con_actividades WHERE cod = @cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();

    }
    public bool agregarTecnicosAgenda(string codagenda, string codusuariorol)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO act_agendaparti (codagenda, codusuariorol) VALUES (@codagenda,@codusuariorol);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codagenda", codagenda);
        conector.AsignarParametroCadena("@codusuariorol", codusuariorol);
        return conector.guardadata();

    }
  
    public bool editarActividad(string cod,string nombre,string ans)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE con_actividades SET nombre = @nombre,ans = @ans  WHERE cod =@cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        conector.AsignarParametroCadena("@nombre", nombre);
        conector.AsignarParametroCadena("@ans", ans);
        return conector.guardadata();

    }

    public long agregarActividadAgendada(string codusuariorol, string descripcion, string startday, string endday, string codproyecto, string codcliente, string codtipoactividad, string createdday, string codestado)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO act_agenda (codusuariorol, descripcion, startday, endday,codproyecto,codcliente, codtipoactividad, createdday,codestado) "
        + "VALUES (@codusuariorol,@descripcion,@startday,@endday,@codproyecto,@codcliente,@codtipoactividad,@createdday,@codestado);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codusuariorol", codusuariorol);
        conector.AsignarParametroCadena("@descripcion", descripcion);
        conector.AsignarParametroCadena("@startday", startday);
        conector.AsignarParametroCadena("@endday", endday);
        conector.AsignarParametroCadena("@codproyecto", codproyecto);
        conector.AsignarParametroCadena("@codcliente", codcliente);
        conector.AsignarParametroCadena("@codtipoactividad", codtipoactividad);
        conector.AsignarParametroCadena("@createdday", createdday);
        conector.AsignarParametroCadena("@codestado", codestado);
        return conector.guardadataid();

    }
    public DataTable cargarSeguimientosActividades(string codactividad)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT ag.*,CONCAT_WS(' ',u.papellido,u.pnombre)'usuario',e.nombre'estado',e.hex, r.nombre'rol' FROM act_agendaseg ag INNER JOIN usu_usuariorol ur ON ag.codusuariorol=ur.cod INNER JOIN usu_usuario u ON ur.codusuario=u.cod INNER JOIN con_estado e ON e.cod=ag.codestado INNER JOIN usu_roles r ON r.cod=ur.codrol WHERE ag.codagenda=@codactividad ORDER BY ag.fechahora ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codactividad", codactividad);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarPruebasActividades(string codactividad)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT p.*,CONCAT_WS(' ',u.papellido,u.pnombre)'usuario', r.nombre'rol' FROM act_pruebas p INNER JOIN usu_usuariorol ur ON p.codusuariorol=ur.cod INNER JOIN usu_usuario u ON ur.codusuario=u.cod INNER JOIN usu_roles r ON r.cod=ur.codrol WHERE p.codagenda=@codactividad ORDER BY p.createdday ASC";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codactividad", codactividad);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    public DataTable cargarEvidenciaActividades(string codactividad)
    {
        Conexion conector = new Conexion();
        string consulta = "SELECT ag.*,CONCAT_WS(' ', u.papellido, u.pnombre) 'usuario', r.nombre'rol' FROM act_agendaevi ag INNER JOIN usu_usuariorol ur ON ag.codusuariorol = ur.cod INNER JOIN usu_usuario u ON ur.codusuario = u.cod INNER JOIN usu_roles r ON r.cod=ur.codrol WHERE ag.codagenda =@codactividad  ORDER BY ag.fechacreado ASC ";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codactividad", codactividad);
        DataTable resp = conector.traerdata();
        if (resp != null)
            return resp;
        else
            return null;

    }
    /// <summary>
    /// Este metodo agrega un seguimiento a las actividades programadas por un coordinador,
    /// el estado que ingreses en el seguimiento sera actualizados en la tabla act_agenda de acuerdo
    /// al parametro codagenda; Nombre del triguuer : actualizarEstadoActividad
    /// </summary>
    /// <param name="codagenda"></param>
    /// <param name="codusuariorol"></param>
    /// <param name="descripcion"></param>
    /// <param name="codestado"></param>
    /// <returns></returns>
    public bool agregarSeguimientoActividad(string codagenda, string codusuariorol, string descripcion, string codestado)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO act_agendaseg (codagenda, codusuariorol,descripcion, fechahora, codestado) VALUES (@codagenda,@codusuariorol,@descripcion,@fechahora,@codestado);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codagenda", codagenda);
        conector.AsignarParametroCadena("@codusuariorol", codusuariorol);
        conector.AsignarParametroCadena("@descripcion", descripcion);
        conector.AsignarParametroCadena("@fechahora", fun.getFechaAñoHoraActual());
        conector.AsignarParametroCadena("@codestado", codestado);
        return conector.guardadata();

    }
    /// <summary>
    /// Agregar Una prueba
    /// </summary>
    /// <param name="codagenda"></param>
    /// <param name="sm"></param>
    /// <param name="ccq"></param>
    /// <param name="ttlnodo"></param>
    /// <param name="ttlweb"></param>
    /// <param name="ancho"></param>
    /// <param name="descripcion"></param>
    /// <param name="codusuariorol"></param>
    /// <param name="createdday"></param>
    /// <returns></returns>
    public bool agregarPrueba(string codagenda, string sm, string ccq, string ttlnodo, string ttlweb, string ancho, string descripcion,string resultado, string codusuariorol)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO act_pruebas (codagenda,sm, ccq,ttlnodo,ttlweb, ancho,descripcion, resultado, codusuariorol,createdday) "
                           + "VALUES (@codagenda,@sm,@ccq,@ttlnodo,@ttlweb,@ancho,@descripcion,@resultado,@codusuariorol,@createdday);";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codagenda", codagenda);
        conector.AsignarParametroCadena("@sm", sm);
        conector.AsignarParametroCadena("@ccq", ccq);
        conector.AsignarParametroCadena("@ttlnodo", ttlnodo);
        conector.AsignarParametroCadena("@ttlweb", ttlweb);
        conector.AsignarParametroCadena("@ancho", ancho);
        conector.AsignarParametroCadena("@descripcion", descripcion);
        conector.AsignarParametroCadena("@resultado", resultado);

        conector.AsignarParametroCadena("@codusuariorol", codusuariorol);
        conector.AsignarParametroCadena("@createdday", fun.getFechaAñoHoraActual());
        return conector.guardadata();

    }

    public bool agregarEvidenciaActividad(string codagenda, string codusuariorol, string nombrearchivo, string nombreguardado, string contentType, string ext, string path, string tamano)
    {
        Conexion conector = new Conexion();
        string consulta = "INSERT INTO act_agendaevi ( codagenda, codusuariorol, nombrearchivo, nombreguardado,  contentType, ext,  path,tamano,fechacreado) "
                                                  + "VALUES (@codagenda,@codusuariorol,@nombrearchivo,@nombreguardado,@contentType,@ext,@path,@tamano,@fechacreado);";
        Funciones fun = new Funciones();
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@codagenda", codagenda);
        conector.AsignarParametroCadena("@codusuariorol", codusuariorol);
        conector.AsignarParametroCadena("@nombrearchivo", nombrearchivo);
        conector.AsignarParametroCadena("@nombreguardado", nombreguardado);
        conector.AsignarParametroCadena("@contentType", contentType);
        conector.AsignarParametroCadena("@ext", ext);
        conector.AsignarParametroCadena("@path", path);
        conector.AsignarParametroCadena("@tamano", tamano);
        conector.AsignarParametroCadena("@fechacreado", fun.getFechaAñoHoraActual());
        return conector.guardadata();
    }


    public bool eliminarAgenda(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM act_agenda WHERE cod = @cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();
    }

    public bool eliminarEvidenciaAgenda(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM act_agendaevi WHERE codagenda = @cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();

    }

    public bool eliminarParticiantesAgenda(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM act_agendaparti WHERE  codagenda= @cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();

    }

    public bool eliminarSeguimientoAgenda(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM act_agendaseg WHERE  codagenda= @cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();

    }
    public bool eliminarPruebasAgenda(string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "DELETE FROM act_pruebas WHERE  codagenda= @cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();

    }
    public bool editarActividadAgendada(string codusuariorol, string descripcion, string startday, string endday, string codproyecto, string codcliente, string codtipoactividad, string cod)
    {
        Conexion conector = new Conexion();
        string consulta = "UPDATE act_agenda SET codusuariorol = @usuariorol,descripcion = @descripcion,startday = @startday,endday =@endday,codproyecto = @proyecto,codcliente = @cliente,codtipoactividad = @tipoactividad WHERE cod = @cod;";
        conector.CrearComando(consulta);
        conector.AsignarParametroCadena("@usuariorol", codusuariorol);
        conector.AsignarParametroCadena("@descripcion", descripcion);
        conector.AsignarParametroCadena("@startday", startday);
        conector.AsignarParametroCadena("@endday", endday);
        conector.AsignarParametroCadena("@proyecto", codproyecto);
        conector.AsignarParametroCadena("@cliente", codcliente);
        conector.AsignarParametroCadena("@tipoactividad", codtipoactividad);
        conector.AsignarParametroCadena("@cod", cod);
        return conector.guardadata();

    }

    public bool enviarMensajeporcorreo(string mensaje, string destino, string codActividad)
    {
        Email ema = new Email();
        DataRow dato = ema.buscarRemitente("3");
        DataTable datos = ema.cargarCorreosCC();
        if (dato != null && dato["envio"].ToString() == "si")
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

            msg.To.Add(destino); //destinatario

            string[] email;
            if (datos != null && datos.Rows.Count > 0)
            {
                email = new string[datos.Rows.Count];

                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    MailAddress cc = new MailAddress(datos.Rows[i]["email"].ToString());//Con Copia    
                    email[i] = Convert.ToString(cc);
                }

                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    msg.Bcc.Add(email[i]);
                }
            }
            //lblEmailCC.text = ca;
            msg.From = new MailAddress(dato["email"].ToString(), dato["nombre"].ToString(), System.Text.Encoding.UTF8); //correo emisor, nombre emisor

            DataRow datoActividad = buscarActividadAgendada(codActividad);
            msg.Subject = dato["asunto"].ToString() + " - Actividad #: " + datoActividad["cod"].ToString() + ", Cliente: " + datoActividad["cliente"].ToString() + ", Municipio: " + datoActividad["nomunicipio"].ToString(); // asunto
            msg.SubjectEncoding = System.Text.Encoding.UTF8;

            msg.Body = mensaje;

            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;

            //Aquí es donde se hace lo especial       
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(dato["email"].ToString().Trim(), dato["pass"].ToString().Trim());

            client.Port = Convert.ToInt32(dato["port"].ToString());
            client.Host = dato["servidorsmtp"].ToString();
            client.EnableSsl = Convert.ToBoolean(dato["seguridadssl"].ToString());
            client.Timeout = 5000;
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
    public string armarCuerpoDelMensajeActividad(string codigoAct, int num)
       // public string armarCuerpoDelMensajeActividad(string codigoUsu, string codigoAct, int num)
    {
       
        //string nombreUsuario = getNombreUsuario(codigoUsu);
        string ca = "";
        string titulo = "<div><img src='http://www.siagu.co/helpdeskfuntics/Imagenes/correo.png' alt='soporte_tecnico_header' />";
        titulo += "  <div style='max-width:650px;background-color:#fff;color:#000; padding:8px 15px 13px 15px; width:626px;'>";
        string saludoEstudiante = "";

        string preambulo = "";
        switch (num)
        {
            case 1:
                //saludoEstudiante = "<h2>Hola, " + nombreUsuario + "</h2>";
                preambulo = " <br />Se ha generado la respuesta a tu solicitud de la Actividad: #" + codigoAct + " <br />";
                break;
            case 2:
                saludoEstudiante = "<h2>SOPORTE TÉCNICO:</h2>";
                //preambulo = " <br />Se ha generado un nuevo escalamiento de solicitud para el Ticket : #" + nombreUsuario + " <br />";
                preambulo = " <br />Se ha generado el resultado de la actividad, los detalles a continuación: <br />";
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
    private string cargarDetalles(string codactividad)
    {
        Actividad act = new Actividad();
        DataRow datoActividad = buscarActividadAgendada(codactividad);
        if (datoActividad != null)
        {
            string ca = "";
 
            ca += " <table class='mGridTesoreria'>";
            ca += "    <tr>";
            ca += "       <th>N° Actividad</th>";
            ca += "       <td>" + codactividad + "</td>";
            ca += "    </tr>";
            ca += "    <tr>";
            ca += "       <th>USUARIO</th>";
            ca += "       <td>" + datoActividad["usuario"].ToString() + "</td>";
            ca += "    </tr>";
            ca += "     <tr>";
            ca += "        <th>FECHA CREACIÓN</th>";
            ca += "        <td>" + datoActividad["createdday"].ToString() + "</td>";
            ca += "    </tr>";
            ca += "     <tr>";
            ca += "        <th>ACTIVIDAD</th>";
            ca += "        <td>" + datoActividad["actividad"].ToString() + "</td>";
            ca += "    </tr>";
            ca += "     <tr>";
            ca += "        <th>DESCRIPCIÓN</th>";
            ca += "        <td>" + datoActividad["descripcion"].ToString() + "</td>";
            ca += "    </tr>";
            ca += "     <tr>";
            ca += "        <th>PROYECTO</th>";
            ca += "        <td>" + datoActividad["proyecto"].ToString() + "</td>";
            ca += "    </tr>";
            ca += "     <tr>";
            ca += "        <th>MUNICIPIO</th>";
            ca += "        <td>" + datoActividad["nomunicipio"].ToString() + "</td>";
            ca += "    </tr>";
            ca += "     <tr>";
            ca += "        <th>CLIENTE</th>";
            ca += "        <td>" + datoActividad["cliente"].ToString() + "</td>";
            ca += "    </tr>";
            DataTable part = cargarParticipantesActividadAgendada(codactividad);
            if (part != null)
            {
                ca += "     <tr>";
                ca += "        <th>TÉCNICOS</th>";
                ca += "        <td>";
                ca += "<ul>";
                for (int i = 0; i < part.Rows.Count; i++)
                {
                    ca += "<li>" + part.Rows[i]["tecnico"].ToString() + "</li>";
                }
                ca += "</ul>";
                ca += "</td>";
                ca += "</tr>";
            }
            DataTable pru = cargarPruebasActividades(codactividad);
            if(pru != null)
            {
                ca += "     <tr>";
                ca += "        <th>PRUEBAS</th>";
                ca += "        <td>";
                ca += "<ul>";
                for (int j = 0; j < part.Rows.Count; j++)
                {
                    ca += "<li>" + "Fecha: " + part.Rows[j]["createdday"].ToString() + "</li>";
                    ca += "<li>" + "Usuario: " + part.Rows[j]["usuario"].ToString() + "</li>";
                    ca += "<li>" + "SM: " + part.Rows[j]["sm"].ToString() + "</li>";
                    ca += "<li>" + "CCQ: " + part.Rows[j]["ccq"].ToString() + "</li>";
                    ca += "<li>" + "TTL Nodo: " + part.Rows[j]["ttlnodo"].ToString() + "</li>";
                    ca += "<li>" + "TTL Web " + part.Rows[j]["ttlweb"].ToString() + "</li>";
                    ca += "<li>" + "Ancho: " + part.Rows[j]["ancho"].ToString() + "</li>";
                    ca += "<li>" + "Descripción: " + part.Rows[j]["descripcion"].ToString() + "</li>";
                    ca += "<li>" + "Resultado: " + part.Rows[j]["resultado"].ToString() + "</li>";
                    ca += "<br/>";
                }
                ca += "</ul>";
                ca += "</td>";
                ca += "</tr>";
            }
           
            ca += "  </table>";

            return ca;
        }
        return "";
    } 
}
