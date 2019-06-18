using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class ticdetalle : System.Web.UI.Page
{
    private Tickets ticket;
    private string codTicket;
    Actividad act = new Actividad();
    Cliente cli = new Cliente();
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["codperfil"] != null)
        {

        }
        else
            Response.Redirect("Default.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        mensaje.Attributes.Add("style", "display:none");
        if (Request.Params["ct"] != null)
        {
            obtenerGETOriginal();
            obtenerSessionOriginal();
            cerrarSessiones();
            codTicket = Request.Params["ct"].ToString();
            lblCodUsuarioRol.Text = Session["codusuariorol"].ToString();
            lblCodUsuario.Text = Session["codusuario"].ToString();
            lblTipoUsuario.Text = Session["codrol"].ToString();
            if (Session["anterior"] != null)
            {
                // btnRegresar.HRef=Session["anterior"].ToString();
            }
            else
            {
                btnRegresar.HRef = "ticmonitor.aspx?cp=" + lblCodProyecto.Text + "&ce=" + lblCodEstado.Text + "&cpri=" + lblCodPrioridad.Text + "&cs=" + lblCodSolicitud.Text + "&cc=" + lblCodCliente.Text + "&cu=" + lblCodUsuarioS.Text + "&o=v";
            }
        }
        else 
        {
            Response.Redirect("ticmonitor.aspx");
        }
        if (!IsPostBack) 
        {
            cargarGrillas();
            cargarTiempo();
            cargarDrops();
        }
        cerrarSessiones();
    }

    private void cargarDrops()
    {
        DataRow datoActividad = ticket.buscarTicket(codTicket);
        DataRow datoIncidencia = ticket.buscarIncidente(codTicket);

        if (lblTipoUsuario.Text == "1" || lblTipoUsuario.Text == "3")
        {
            dropEstadoLista.Enabled = true;
        }
        else
        {
            dropEstadoLista.Enabled = false;
        }

        if (datoActividad != null && datoActividad["estado"].ToString() == "Resuelto")
        {
            BloqueoElementosEstadoResuelto(datoActividad["codsolicitud"].ToString());
            cargarSeguimiento();
        }

        ddEstados(dropEstadoLista);

        if(datoIncidencia != null)
        {
            lbldatos.Text = "True";
            ddCausasIncidente(dropCausaIncidente);
            //mostrarmensaje("error", "2da vez");
        }
        else//Entra por primera vez al detalle ticket
        {
            dropCausaIncidente.Visible = false;
            dropCausaIncidente2.Visible = true;
            ddCausasIncidente(dropCausaIncidente2);
            //mostrarmensaje("error", "1era vez");
        }
        
        //    lblcodCausaIncidente.Text = "valor2";
    }

    private void BloqueoElementosEstadoResuelto(string codsolicitud)
    {
        txtDescripcion.Enabled = false;
        dropEstadoLista.Visible = false;
        dropCausaIncidente.SelectedValue = codsolicitud;
        lblestadolista.Visible = true;
        dropCausaIncidente.Enabled = false;
        btnAddSeguimiento.Enabled = false;
        btnAddSeguimiento.Visible = false;

        txtDescripcionOff.Enabled = false;
        txtFechaI.Enabled = false;
        cmbHoras.Enabled = false;
        cmbMinutos.Enabled = false;
        txtCantidadHoras.Enabled = false;
        btnCalcular.Visible = false;
        trepador.Enabled = true;
        btnAddTimeOff.Visible = false;
        
        btnAddEvidencia.Visible = true;
    }

    private void ddCausasIncidente(DropDownList drop)
    {
        DataTable datosCausas = cli.cargarCausaIncidente();
        drop.DataSource = datosCausas;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }

    public void obtenerGETOriginal()
    {
        if (Session["o"] == null)
        {
            Session["ca"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["ca"]);//CodActividad
            Session["cp"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["cp"]);//CodProyecto
            Session["ce"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["ce"]);//CodEstado
            Session["cpri"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["cpri"]);//CodPrioridad
            Session["cs"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["cs"]);//CodSolicitud
            Session["cc"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["cc"]);//CodCliente
            Session["cu"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["cu"]);//CodUsuario

           // Response.Redirect("ticdetalle.aspx");
           
        }
    }
    public void obtenerSessionOriginal()
    {
        if (Session["ca"] != null)
            lblCodActividad.Text = Session["ca"].ToString();
        if (Session["cp"] != null)
            lblCodProyecto.Text = Session["cp"].ToString();
        if (Session["ce"] != null)
            lblCodEstado.Text = Session["ce"].ToString();
        if (Session["cpri"] != null)
            lblCodPrioridad.Text = Session["cp"].ToString();
        if (Session["cs"] != null)
            lblCodSolicitud.Text = Session["cs"].ToString();
        if (Session["cc"] != null)
            lblCodCliente.Text = Session["cc"].ToString();
        if (Session["cu"] != null)
            lblCodUsuarioS.Text = Session["cu"].ToString();
        if (Session["o"] != null)
            lblOperacion.Text = Session["o"].ToString();
        else
            lblOperacion.Text = "";
    }
    public void cerrarSessiones()
    {
        Session["ca"] = null;
        Session["cp"] = null;
        Session["ce"] = null;
        Session["cpri"] = null;
        Session["cs"] = null;
        Session["cc"] = null;
        Session["cu"] = null;
        Session["o"] = null;
    }
      
    private string armarTabla(DataRow datoActividad, string cod)
    {
        string ca = "";
        ca += "  <center>";
        ca += " <table class='mGridTesoreria'>";
        ca += "    <tr>";
        ca += "       <th>Nro. Tickets</th>";
        ca += "       <td style='text-align:center'>" + cod + "</td>";
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
        ca += "     <tr>";
        ca += "        <th>MUNICIPIO</th>";
        ca += "        <td>" + datoActividad["nomunicipio"].ToString() + "</td>";
        ca += "    </tr>";
        ca += "     <tr>";
            ca += "        <th>CLIENTE</th>";
            ca += "        <td>" + datoActividad["cliente"].ToString() + "</td>";
            ca += "    </tr>";
        
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
        DataTable datosTecnicos = ticket.cargarParticipantesTickets(cod);
        if (datosTecnicos != null && datosTecnicos.Rows.Count > 0)
        {
            ca += "     <tr>";
            ca += "        <th>ESCALA</th>";
            ca += "        <td>";
            ca += "<ul>";
            for (int i = 0; i < datosTecnicos.Rows.Count; i++)
            {
                ca += "<li>" + datosTecnicos.Rows[i]["emisor"].ToString() + " (" + datosTecnicos.Rows[i]["rolemisor"].ToString().Substring(0, 3) + ") -->" + datosTecnicos.Rows[i]["receptor"].ToString() + " (" + datosTecnicos.Rows[i]["rolreceptor"].ToString().Substring(0, 3) + ") </li>";
            }
            ca += "</ul>";
            ca += "   </td> </tr>";
        }

        ca += "  </table>";
        ca += "  <center>";
        return ca;
    }
    private void ddEstados(DropDownList drop)
    {
        DataTable datosEstados = act.cargarEstados();
        drop.DataSource = datosEstados;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        //drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos"));
    }

    private void cargarGrillas()
    {
        cargarSeguimiento();
        cargarEvidencia();
        cargarTimeOff();
        cargarDetalles();
       
    }
    private void cargarSeguimiento()
    {
        ticket = new Tickets();
        DataTable seguimiento = ticket.cargarSeguimientoTicket(codTicket);
        if (seguimiento != null)
        {
            GridSeguimiento.DataSource = seguimiento;
            GridSeguimiento.DataBind();
            string val = "";
            for(int i =0; i<seguimiento.Rows.Count;i++)
            {
                val = seguimiento.Rows[i]["codcausaincidente"].ToString();
                
            }
        }
    }
    private void cargarEvidencia()
    {
        ticket = new Tickets();
        DataTable evidencia = ticket.cargarEvidenciaTicket(codTicket);
        if (evidencia != null)
        {
            GridEvidencia.DataSource = evidencia;
            GridEvidencia.DataBind();
        }
    }
    private void cargarTimeOff()
    {
        ticket = new Tickets();
        DataTable timeoff = ticket.cargarTimeOffTicket(codTicket);
        if (timeoff != null)
        {
            GridTimeOff.DataSource = timeoff;
            GridTimeOff.DataBind();

            if (lblTipoUsuario.Text == "1")
            {
                GridTimeOff.Columns[8].Visible = true;
            }
            else
            {
                GridTimeOff.Columns[8].Visible = false;
            }
        }
    }
    private void cargarDetalles()
    {

        DataRow datoActividad = ticket.buscarTicket(codTicket);
        if (datoActividad != null)
        {
            lblDetalles.Text = armarTabla(datoActividad, codTicket);
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se encontro la actividad." + codTicket);
        }
    }
    private void cargarTiempo() 
    {
        for (int i = 0; i < 23; i++)
        {
            string hora = "0" + i;
            cmbHoras.Items.Add(hora.Substring(hora.Length-2));
        }
        for (int i = 0; i < 6; i++)
        {
            cmbMinutos.Items.Add(i + "0");
        }
        cmbHoras.DataBind();
        cmbMinutos.DataBind();
    }

  
    
    protected void btnAddEvidencia_Click(object sender, EventArgs e)
    {
        ticket = new Tickets();
        string codusurol =lblCodUsuarioRol.Text;
        string[] variables = subirArchivo(trepador);
        if (variables[0] == "error")
            mostrarmensaje(variables[0], variables[1]);
        else if (variables[0] == "exito")
        {
            if (ticket.agregarEvidencia(codTicket,codusurol, variables[2], variables[3], variables[4], variables[5], variables[7], variables[8]))
            {
                trepador.PostedFile.SaveAs(variables[6]);
                mostrarmensaje("exito", "Evidencia agregada correctamente.");
                cargarEvidencia();
                string open = "abrir(2);";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
            }
            else
                mostrarmensaje("error", "ERROR: No se logró agregar la evidencia.");
        }
    }
    protected void btnAddSeguimiento_Click(object sender, EventArgs e)
    {
        int time = 1;
         string descripcion=txtDescripcion.Text;
        string codRolUsuario = lblCodUsuarioRol.Text;
        ticket = new Tickets();

        DateTime localDateTime = DateTime.Now;
        DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
        string horares = utcDateTime.ToString("yyyy-MM-dd HH:mm:ss");

        DataTable dat = ticket.cargarEvidenciaTicket(codTicket);
       if(dropEstadoLista.SelectedIndex != 2)
       {
           if (dropEstadoLista.SelectedValue == "3" && dropCausaIncidente.SelectedValue == "46")//Estado Resuelto y Causa es diferente a Pendiente
           {
               mostrarmensaje("error", "Error al cambiar de estado, escoja otra causa.");
           }
           else
           {
               if (ticket.editarIncidenciaEstado(codTicket, dropEstadoLista.SelectedValue))
               {
                   if (lbldatos.Text == "True")//Valida si el primer dropCausaIncidente está lleno en el gridview
                   {
                      // mostrarmensaje("exito", "true");
                       if (ticket.agregarSeguimiento(codTicket, codRolUsuario, descripcion, dropEstadoLista.SelectedValue, dropCausaIncidente.SelectedValue, horares))
                       {
                           mostrarmensaje("exito", "Seguimiento añadido correctamente");
                           Response.AppendHeader("Refresh", time + "; Url=" + Request.RawUrl + "");
                           txtDescripcion.Text = "";
                           dropCausaIncidente.SelectedIndex = 0;
                           //dropCausaIncidente2.SelectedIndex = 0;
                           cargarSeguimiento();
                           string open = "abrir(1);";
                           ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
                       }
                   }
                   else
                   {
                      // mostrarmensaje("error", "false");
                       if (ticket.agregarSeguimiento(codTicket, codRolUsuario, descripcion, dropEstadoLista.SelectedValue, dropCausaIncidente2.SelectedValue, horares))
                       {
                           mostrarmensaje("exito", "Seguimiento añadido correctamente");
                           Response.AppendHeader("Refresh", time + "; Url=" + Request.RawUrl + "");
                           txtDescripcion.Text = "";
                           dropCausaIncidente.Visible = true;
                           dropCausaIncidente2.Visible = false;
                           //dropCausaIncidente.SelectedIndex = 0;
                           dropCausaIncidente2.SelectedIndex = 0;
                           cargarSeguimiento();
                           string open = "abrir(1);";
                           ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
                       }
                   }

               }
               else
               {
                   mostrarmensaje("error", "Error al cambiar estado en el ticket.");
               }


           }
       }
       else
       {
           if (dat != null && dat.Rows.Count >= 2)//Validar mas de dos evidencia por ticket
           {
               if (dropEstadoLista.SelectedValue == "3" && dropCausaIncidente.SelectedValue == "46")//Estado Resuelto y Causa es diferente a Pendiente
               {
                   mostrarmensaje("error", "Error al cambiar de estado, escoja otra causa.");
               }
               else
               {
                   if (ticket.editarIncidenciaEstado(codTicket, dropEstadoLista.SelectedValue))
                   {
                       if (lbldatos.Text == "True")//Valida si el primer dropCausaIncidente está lleno en el gridview
                       {
                           //mostrarmensaje("exito", "true");
                           if (ticket.agregarSeguimiento(codTicket, codRolUsuario, descripcion, dropEstadoLista.SelectedValue, dropCausaIncidente.SelectedValue, horares))
                           {
                               mostrarmensaje("exito", "Seguimiento añadido correctamente");
                               Response.AppendHeader("Refresh", time + "; Url=" + Request.RawUrl + "");
                               txtDescripcion.Text = "";
                               dropCausaIncidente.SelectedIndex = 0;
                               //dropCausaIncidente2.SelectedIndex = 0;
                               cargarSeguimiento();
                               string open = "abrir(1);";
                               ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
                           }
                       }
                       else
                       {
                          // mostrarmensaje("error", "false");
                           if (ticket.agregarSeguimiento(codTicket, codRolUsuario, descripcion, dropEstadoLista.SelectedValue, dropCausaIncidente2.SelectedValue, horares))
                           {
                               mostrarmensaje("exito", "Seguimiento añadido correctamente");
                               Response.AppendHeader("Refresh", time + "; Url=" + Request.RawUrl + "");
                               txtDescripcion.Text = "";
                               dropCausaIncidente.Visible = true;
                               dropCausaIncidente2.Visible = false;
                               //dropCausaIncidente.SelectedIndex = 0;
                               dropCausaIncidente2.SelectedIndex = 0;
                               cargarSeguimiento();
                               string open = "abrir(1);";
                               ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
                           }
                       }
                       Response.AppendHeader("Refresh", time + "; Url=" + Request.RawUrl + "");
                   }
                   else
                   {
                       mostrarmensaje("error", "Error al cambiar estado en el ticket.");
                   }


               }
           }
           else
           {
               mostrarmensaje("error", "Error debe cargar la Evidencia para este Ticket.");
           }
       }
       

    }
    protected void imgDescargar_Click(object sender, ImageClickEventArgs e)
    {
       // mostrarmensaje("error", "");
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string filepath = Server.MapPath(HttpUtility.HtmlDecode(gvrow.Cells[5].Text));
        string filename = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
        if (!File.Exists(filepath))
        {
            mostrarmensaje("error", "Lo sentimos el archivo: " + filename + " no existe");
        }
        else
        {
            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + filename);
            Response.ContentType = "application/octet-stream";
            Response.Flush();
            Response.WriteFile(filepath);
            Response.End();
        }
    }
    protected string getVolver() 
    {
        if (Session["anterior"] != null)
        {
            return Session["anterior"].ToString();
        }
        else {
            return "ticmonitor.aspx";
        }
    }
    private string[] subirArchivo(FileUpload trepador)
    {
        string[] variables = new string[9];
        variables[0] = string.Empty; //estado mensaje
        variables[1] = string.Empty; //mensaje 
        variables[2] = string.Empty; //fileName    
        variables[3] = string.Empty; //fileNameSave
        variables[4] = string.Empty; //fileExtension
        variables[5] = string.Empty; //contentType
        variables[6] = string.Empty; //pathSave
        variables[7] = string.Empty; //pathsinmapSave
        variables[8] = string.Empty; //ContentLength

        //Calculadora de bytes: http://es.calcuworld.com/informatica/calculadora-de-bytes/
        int tamanofile;
        long tamanopermitido = 5242880;//Este dato está en bytes. 5242880 es 5MB, revisar el tamaño en el web.config (maxRequestLength) (kb). 31.700.160KB

        string contentType;
        string pathsinmap = "~/Documentos/";
        string path = Server.MapPath(pathsinmap);
        if (trepador.HasFile)
        {
            try
            {
                bool directorio = false;
                if (!Directory.Exists(path))
                {
                    try
                    {
                        Directory.CreateDirectory(path);
                        directorio = true;
                    }
                    catch (Exception exd)
                    {
                        variables[0] = "error"; // estado mensaje
                        variables[1] = "Error : " + exd.Message; //mensaje  
                        return variables;
                        //mostrarmensaje("error", "Error : " + exd.Message);    
                    }
                }
                else
                    directorio = true; //Ya existe el directorio                

                if (directorio == true)
                {
                    tamanofile = trepador.PostedFile.ContentLength;
                    contentType = trepador.PostedFile.ContentType;

                    if (tamanofile > 0 && tamanofile < tamanopermitido)
                    {
                        DateTime localDateTime = DateTime.Now;
                        DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
                        string horares = utcDateTime.ToString("yyyy-MM-dd_HHmmss");

                        string fileExtension = System.IO.Path.GetExtension(trepador.FileName).ToLower();
                        string fileName = System.IO.Path.GetFileName(trepador.PostedFile.FileName).Replace(",", " ");
                        string fileNameSave = horares + "_" + lblCodUsuario.Text + fileExtension;
                        string pathSave = path + fileNameSave;
                        string pathsinmapSave = pathsinmap + fileNameSave;

                        String[] allowedExtensions = funallowedExtensions();
                        bool extOK = false;
                        for (int i = 0; i < allowedExtensions.Length; i++)
                        {
                            if (fileExtension == allowedExtensions[i])
                            {
                                extOK = true;
                                //para quitar el punto "." de la extension
                                string exte = trepador.PostedFile.FileName;
                                fileExtension = (exte.Substring(exte.LastIndexOf(".") + 1).ToLower());
                            }
                        }


                        if (extOK == false)
                        {
                            variables[0] = "error"; // estado mensaje
                            variables[1] = "Error: No se permite el formato " + fileExtension; //mensaje  
                            return variables;
                            //mostrarmensaje("error", "Error: No se permite el formato " + fileExtension);
                        }
                        else
                        {
                            variables[0] = "exito"; // estado mensaje
                            variables[1] = ""; //mensaje  
                            variables[2] = fileName;  //fileName    
                            variables[3] = fileNameSave; //fileNameSave
                            variables[4] = fileExtension; //fileExtension
                            variables[5] = contentType; //contentType
                            variables[6] = pathSave; //pathSave
                            variables[7] = pathsinmapSave; //pathsinmapSave
                            variables[8] = trepador.PostedFile.ContentLength.ToString(); //ContentLength

                            return variables;

                        }

                    }
                    else
                    {
                        long tan = (tamanopermitido / 1024) / 1024;
                        mostrarmensaje("error", "Tamaño no permitido, solo se aceptan: " + tan.ToString() + " MB");
                    }
                }
            }
            catch (Exception ex)
            {
                mostrarmensaje("error", "Error : " + ex.Message);
            }
        }
        else
        {
            variables[0] = "error"; // estado mensaje
            variables[1] = "Error: Debes seleccionar un archivo"; //mensaje  
            return variables;
            //mostrarmensaje("error", "Error: Debes seleccionar un archivo");
        }
        return variables;
    }
    private String[] funallowedExtensions()
    {
        String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg", ".doc", ".docx", "xlsx", "xls", ".rar", ".txt", ".pdf", ".mp3", ".gsm" };
        return allowedExtensions;
    }

    protected void btnAddTimeOff_Click(object sender, EventArgs e)
    {
        ticket = new Tickets();
        Funciones fun = new Funciones();
        string fechaI = Convert.ToDateTime(txtFechaI.Text+" "+cmbHoras.Text+":"+cmbMinutos.Text).ToString();
        string fechaF = calcularFechaFinal();
        string cantidad = txtCantidadHoras.Text;
        if (ticket.agregarTimeOff(codTicket, lblCodUsuarioRol.Text, txtDescripcionOff.Text, fun.convertFechaAñoMesDiaHora(fechaI), fun.convertFechaAñoMesDiaHora(fechaF), cantidad))
        {

            respuesta.Attributes.Add("class", "label-success");
            respuesta.InnerText="Time Off Agregado Correctamente";
            txtDescripcionOff.Text = "";
            txtFechaI.Text = "";
            lblFechaFinal.Text = "";
            txtCantidadHoras.Text = "";
            cargarTiempo();
            cargarTimeOff();
        }
        else 
        {
            respuesta.Attributes.Add("class", "ui-state-error");
            respuesta.InnerText="Time Off Agregado Correctamente";
        }
    }
    protected void btnCalcular_Click(object sender, EventArgs e)
    {
        lblFechaFinal.Text = calcularFechaFinal();
    }

    public string calcularFechaFinal() 
    {
        string fechaI = txtFechaI.Text;
        string hora = cmbHoras.Text;
        string minutos = cmbMinutos.Text;
        int cantidadH = Convert.ToInt32(txtCantidadHoras.Text);

        DateTime fechaA = Convert.ToDateTime(fechaI + " " + hora + ":" + minutos);
        DateTime fechaF = fechaA.AddHours(cantidadH);

        return fechaF.ToString();
    }

    protected void imgDeleteTimeOff_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string consecutivo = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);

        eliminarTimeOff(consecutivo);
    }

    private void eliminarTimeOff(string codtimeoff)
    {
        Tickets tic = new Tickets();
        if (tic.eliminarTimeOffxCod(codtimeoff))
        {
            mostrarmensaje("exito", "Eliminado correctamente.");
            cargarTimeOff();
        }
        else
        {
            mostrarmensaje("error", "Error al eliminar");
        }
    }

    
}