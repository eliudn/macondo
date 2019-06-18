using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class actdetalle : System.Web.UI.Page
{
    Actividad act = new Actividad();
    Usuario user = new Usuario();
    Email ema = new Email();

    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["codperfil"] != null)
        {

        }
        else
            Response.Redirect("Default.aspx");
    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
  
    protected void Page_Load(object sender, EventArgs e)
    {
        mensaje.Attributes.Add("style", "display:none");
        if (!IsPostBack)
        {
            obtenerGETOriginal();
            obtenerSessionOriginal();
            if (lblCodActividad.Text != "")
            {
                lblCodUsuarioRol.Text = Session["codusuariorol"].ToString();
                lblCodUsuario.Text = Session["codusuario"].ToString();
                lblTipoUsuario.Text = Session["codrol"].ToString();
                if (variablePrueba())
                {
                    ddEstados(dropEstado);
                    cargar(lblCodActividad.Text);
                }
                else
                {
                    mostrarmensaje("error", "ERROR: No se encontrarón las varibles de prueba, Comuniquese con el administrador.");
                }
              
            }
            else
            {
                mostrarmensaje("error", "ERROR: No se recibieron los parametros.");
            }
        }
        //if (Session["anterior"] != null)
        //{
        //    // btnRegresar.HRef=Session["anterior"].ToString();
        //}
        //else
        //{
        //    btnRegresar.HRef = "actmonitor.aspx?cp=" + lblCodProyecto.Text + "&ce=" + lblCodEstado.Text + "&o=v";
        //}
        cerrarSessiones();
    }
    private bool variablePrueba()
    {
        bool existen = false;
        DataRow datoVariables = ema.buscarVariablesPrueba();
        if (datoVariables != null)
        {
            existen = true;
             lblSM.Text = datoVariables["sm"].ToString();
            lblCCQ.Text = datoVariables["ccq"].ToString();
            lblTTLN.Text = datoVariables["ttlnodo"].ToString();
            lblTTLW.Text = datoVariables["ttlweb"].ToString();
            lblAncho.Text = datoVariables["ancho"].ToString();
        }
        return existen;
    }
    public void obtenerGETOriginal()
    {
        Session["ca"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["ca"]);
        Session["cp"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["cp"]);
        Session["ce"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["ce"]);
    }
    public void obtenerSessionOriginal()
    {
        if (Session["ca"] != null)
            lblCodActividad.Text = Session["ca"].ToString();
        if (Session["cp"] != null)
            lblCodProyecto.Text = Session["cp"].ToString();
        if (Session["ce"] != null)
            lblCodEstado.Text = Session["ce"].ToString();
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
        Session["o"] = null;
    }
    private void cargar(string codactividad)
    {
        cargarDetalles(codactividad);
        cargarSeguimiento(codactividad);
        cargarEvidencia(codactividad);
        cargarPruebas(codactividad);
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
    private void cargarDetalles(string codactividad)
    {
        DataRow datoActividad = act.buscarActividadAgendada(codactividad);
        if (datoActividad != null)
        {
            if (datoActividad["estado"].ToString() != "Resuelto")
            {
                lblDetalles.Text = armarTabla(datoActividad, codactividad);
                
            }
            else
            {
                lblDetalles.Text = armarTabla(datoActividad, codactividad);
                BloqueoElementosEstadoResuelto();
            }
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se encontro la actividad."+codactividad);
        }
    }
    private void BloqueoElementosEstadoResuelto()
    {
        txtDescripcion.Enabled = false;
       
        btnAddSeguimiento.Enabled = false;
        btnAddSeguimiento.Visible = false;

        dropEstado.Enabled = false;

        txtSm.Enabled = false;
        txtCCQ.Enabled = false;
        txtTtlNodo.Enabled = false;
        txtTtlWeb.Enabled = false;
        txtAnchoBanda.Enabled = false;
        txtAnchoActual.Enabled = false;
        dropResultado.Visible = false;
        txtDescripcionPrueba.Enabled = false;
        btnAgregarPrueba.Visible = false;
       
        trepador.Enabled = true;
       

        btnAddEvidencia.Visible = true;
    }
    private string armarTabla(DataRow datoActividad,string cod)
    {
        string ca = "";
        ca += "  <center>";
        ca += " <table class='mGridTesoreria'>";
        ca += "    <tr>";
        ca += "       <th>ORDEN DE TRABAJO</th>";
        ca += "       <td style='text-align:center;'>" + datoActividad["cod"].ToString() + "</td>";
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
        ca += "        <th>INICIO</th>";
        ca += "        <td>" + datoActividad["startday"].ToString() + "</td>";
        ca += "    </tr>";
        ca += "     <tr>";
        ca += "        <th>FIN</th>";
        ca += "        <td>" + datoActividad["endday"].ToString() + "</td>";
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
        DataTable datosTecnicos = act.cargarParticipantesActividadAgendada(cod);
        if (datosTecnicos != null && datosTecnicos.Rows.Count > 0)
        {
                ca += "     <tr>";
                ca += "        <th>CUADRILLA</th>";
                ca += "        <td>";
                ca += "<ul>";
                for (int i = 0; i < datosTecnicos.Rows.Count; i++)
                {
                    ca += "<li>"+datosTecnicos.Rows[i]["tecnico"].ToString()+"</li>";
                }
                ca += "</ul>";
                ca += "   </td> </tr>";
        }

        ca += "  </table>";
        ca += "  <center>";
        return ca;
    }
    private void cargarSeguimiento(string codactividad)
    {
        GridSeguimiento.DataSource = act.cargarSeguimientosActividades(codactividad);
        GridSeguimiento.DataBind();

        if (lblTipoUsuario.Text == "1" || lblTipoUsuario.Text == "3")
        {
            dropEstado.Enabled = true;
            btnAddSeguimiento.Enabled = true;
        }
        else
        {
            dropEstado.SelectedIndex = 0;
            dropEstado.Enabled = false;
            btnAddSeguimiento.Enabled = true;
        }
    }
    private void cargarEvidencia(string codactividad)
    {
        GridEvidencia.DataSource = act.cargarEvidenciaActividades(codactividad);
        GridEvidencia.DataBind();
    }
    private void cargarPruebas(string codactividad)
    {
        GridPruebas.DataSource = act.cargarPruebasActividades(codactividad);
        GridPruebas.DataBind();
    }
    protected string buscarNombreUsuario(string codusuariorol)
    {
        string ca = "";
        DataRow datoUsuario = user.buscarUsuarioxCodUsuarioRol(codusuariorol);
        if (datoUsuario != null)
        {
            ca = datoUsuario["papellido"].ToString().ToUpper() + " " + datoUsuario["pnombre"].ToString().ToLower();
        }
        else
        {
            ca = "Usuario No Encontrado";
        }

        return ca;
    }
    protected string getVolver()
    {
        if (Session["anterior"] != null)
        {
            return Session["anterior"].ToString();
        }
        else
        {
            return "ticmonitor.aspx";
        }
    }
    protected void btnAddSeguimiento_Click(object sender, EventArgs e)
    {
        //DataTable dat = act.cargarSeguimientosActividades(lblCodActividad.Text);
        DataTable dat2 = act.cargarEvidenciaActividades(lblCodActividad.Text);

        if (dropEstado.SelectedIndex != 2)
        {
            if (act.agregarSeguimientoActividad(lblCodActividad.Text, lblCodUsuarioRol.Text, txtDescripcion.Text, dropEstado.SelectedValue))
            {
                mostrarmensaje("exito", "Seguimiento Agregado");
                cargarSeguimiento(lblCodActividad.Text);
                cargarDetalles(lblCodActividad.Text);
                txtDescripcion.Text = string.Empty;
                dropEstado.SelectedIndex = 0;
                string open = "abrir(2);";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
            }
            else
            {
                mostrarmensaje("error", "ERROR: No se logro Agregar.");
                string open = "abrir(2);";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
            }
        }
        else
        {
            if (dat2 != null && dat2.Rows.Count >= 2)//Validar mas de dos evidencia por ticket
            {
                if (act.agregarSeguimientoActividad(lblCodActividad.Text, lblCodUsuarioRol.Text, txtDescripcion.Text, dropEstado.SelectedValue))
                {
                    mostrarmensaje("exito", "Seguimiento Agregado");
                    cargarSeguimiento(lblCodActividad.Text);
                    cargarDetalles(lblCodActividad.Text);
                    txtDescripcion.Text = string.Empty;
                    dropEstado.SelectedIndex = 0;
                    string open = "abrir(2);";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
                }
                else
                {
                    mostrarmensaje("error", "ERROR: No se logro Agregar.");
                    string open = "abrir(2);";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
                }
            }
            else
            {
                mostrarmensaje("error", "Error, Debe cargar las Evidencias para esta actividad.");
                string open = "abrir(2);";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
            }
        }
        
        
        
    }
    protected void btnAddEvidencia_Click(object sender, EventArgs e)
    {
        string[] variables = subirArchivo(trepador);
        if (variables[0] == "error")
            mostrarmensaje(variables[0], variables[1]);
        else if (variables[0] == "exito")
        {
            if (act.agregarEvidenciaActividad(lblCodActividad.Text,lblCodUsuarioRol.Text, variables[2], variables[3], variables[4], variables[5], variables[7], variables[8]))
            {
                trepador.PostedFile.SaveAs(variables[6]);
                mostrarmensaje("exito", "Evidencia agregada correctamente.");
                cargarEvidencia(lblCodActividad.Text);
                string open = "abrir(1);";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
            }
            else
            {
                mostrarmensaje("error", "ERROR: No se logró agregar la evidencia.");
                string open = "abrir(1);";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
            }
            
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

    protected void imgDescargar_Click(object sender, ImageClickEventArgs e)
    {
       
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
    
    protected void btnAgregarPrueba_Click(object sender, EventArgs e)
    {
        decimal sm = 0;
        decimal ccq = 0;
        
        if(txtSm.Text != "")
            sm = Convert.ToDecimal(txtSm.Text);
        
        if(txtCCQ.Text != "")
            ccq = Convert.ToDecimal(txtCCQ.Text);

        decimal ttlnodo = Convert.ToDecimal(txtTtlNodo.Text);
        decimal ttlweb = Convert.ToDecimal(txtTtlWeb.Text);
        decimal anchocontratado = Convert.ToDecimal(txtAnchoBanda.Text);
        decimal anchoactual = Convert.ToDecimal(txtAnchoActual.Text);

        Email em = new Email();
        DataRow dat = em.buscarVariablesPrueba();

        if (dat != null)
        {

            decimal dbsm = Convert.ToDecimal(dat["sm"].ToString());
            decimal dbccq = Convert.ToDecimal(dat["ccq"].ToString());
            decimal dbttlnodo = Convert.ToDecimal(dat["ttlnodo"].ToString());
            decimal dbttlweb = Convert.ToDecimal(dat["ttlweb"].ToString());
            
            if (txtSm.Text != "" && txtCCQ.Text != "")
            {
                //validando todos los campos de la vista con los campos de la base de datos 
                if (sm > dbsm && ccq > dbccq && ttlnodo <= dbttlnodo && ttlweb <= dbttlweb && anchoactual >= anchocontratado)
                {
                    dropResultado.SelectedIndex = 1;//Resultado exitoso
                    if (act.agregarPrueba(lblCodActividad.Text, txtSm.Text, txtCCQ.Text, txtTtlNodo.Text, txtTtlWeb.Text, txtAnchoActual.Text, txtDescripcionPrueba.Text, dropResultado.SelectedValue, lblCodUsuarioRol.Text))
                    {
                        txtSm.Text = string.Empty;
                        txtCCQ.Text = string.Empty;
                        txtTtlNodo.Text = string.Empty;
                        txtTtlWeb.Text = string.Empty;
                        txtAnchoBanda.Text = string.Empty;
                        txtAnchoActual.Text = string.Empty;
                        txtDescripcionPrueba.Text = string.Empty;

                        cargarPruebas(lblCodActividad.Text);
                        mostrarmensaje("exito", "Prueba agregada Correctamente.");
                        string open = "abrir(3);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
                    }
                    else
                    {
                        mostrarmensaje("error", "ERROR: No se logró agregar la prueba.");
                        string open = "abrir(3);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
                    }

                }
                else
                {
                    dropResultado.SelectedIndex = 2;//Resultado No exitoso
                    if (act.agregarPrueba(lblCodActividad.Text, txtSm.Text, txtCCQ.Text, txtTtlNodo.Text, txtTtlWeb.Text, txtAnchoActual.Text, txtDescripcionPrueba.Text, dropResultado.SelectedValue, lblCodUsuarioRol.Text))
                    {
                        txtSm.Text = string.Empty;
                        txtCCQ.Text = string.Empty;
                        txtTtlNodo.Text = string.Empty;
                        txtTtlWeb.Text = string.Empty;
                        txtAnchoBanda.Text = string.Empty;
                        txtAnchoActual.Text = string.Empty;
                        txtDescripcionPrueba.Text = string.Empty;

                        cargarPruebas(lblCodActividad.Text);
                        mostrarmensaje("exito", "Prueba agregada Correctamente.");
                        string open = "abrir(3);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
                    }
                    else
                    {
                        mostrarmensaje("error", "ERROR: No se logró agregar la prueba.");
                        string open = "abrir(3);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
                    }
                }
            }
            else if (txtSm.Text == "" && txtCCQ.Text == "")//Campos SM y CCQ vacíos
            {
                //validando todos los campos de la vista con los campos de la base de datos 
                if (ttlnodo <= dbttlnodo && ttlweb <= dbttlweb && anchoactual >= anchocontratado)
                {
                    dropResultado.SelectedIndex = 1;//Resultado exitoso
                    if (act.agregarPrueba(lblCodActividad.Text, "", "", txtTtlNodo.Text, txtTtlWeb.Text, txtAnchoActual.Text, txtDescripcionPrueba.Text, dropResultado.SelectedValue, lblCodUsuarioRol.Text))
                    {
                        txtSm.Text = string.Empty;
                        txtCCQ.Text = string.Empty;
                        txtTtlNodo.Text = string.Empty;
                        txtTtlWeb.Text = string.Empty;
                        txtAnchoBanda.Text = string.Empty;
                        txtAnchoActual.Text = string.Empty;
                        txtDescripcionPrueba.Text = string.Empty;

                        cargarPruebas(lblCodActividad.Text);
                        mostrarmensaje("exito", "Prueba agregada Correctamente.");
                        string open = "abrir(3);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
                    }
                    else
                    {
                        mostrarmensaje("error", "ERROR: No se logró agregar la prueba.");
                        string open = "abrir(3);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
                    }

                }
                else
                {
                    dropResultado.SelectedIndex = 2;//Resultado No exitoso
                    if (act.agregarPrueba(lblCodActividad.Text, "", "", txtTtlNodo.Text, txtTtlWeb.Text, txtAnchoActual.Text, txtDescripcionPrueba.Text, dropResultado.SelectedValue, lblCodUsuarioRol.Text))
                    {
                        txtSm.Text = string.Empty;
                        txtCCQ.Text = string.Empty;
                        txtTtlNodo.Text = string.Empty;
                        txtTtlWeb.Text = string.Empty;
                        txtAnchoBanda.Text = string.Empty;
                        txtAnchoActual.Text = string.Empty;
                        txtDescripcionPrueba.Text = string.Empty;

                        cargarPruebas(lblCodActividad.Text);
                        mostrarmensaje("exito", "Prueba agregada Correctamente.");
                        string open = "abrir(3);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
                    }
                    else
                    {
                        mostrarmensaje("error", "ERROR: No se logró agregar la prueba.");
                        string open = "abrir(3);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
                    }
                }
            }
            else if (txtSm.Text == "")//SM vacío
            {
                //validando todos los campos de la vista con los campos de la base de datos 
                if (ccq > dbccq && ttlnodo <= dbttlnodo && ttlweb <= dbttlweb && anchoactual >= anchocontratado)
                {
                    dropResultado.SelectedIndex = 1;//Resultado exitoso
                    if (act.agregarPrueba(lblCodActividad.Text, "", txtCCQ.Text, txtTtlNodo.Text, txtTtlWeb.Text, txtAnchoActual.Text, txtDescripcionPrueba.Text, dropResultado.SelectedValue, lblCodUsuarioRol.Text))
                    {
                        txtSm.Text = string.Empty;
                        txtCCQ.Text = string.Empty;
                        txtTtlNodo.Text = string.Empty;
                        txtTtlWeb.Text = string.Empty;
                        txtAnchoBanda.Text = string.Empty;
                        txtAnchoActual.Text = string.Empty;
                        txtDescripcionPrueba.Text = string.Empty;

                        cargarPruebas(lblCodActividad.Text);
                        mostrarmensaje("exito", "Prueba agregada Correctamente.");
                        string open = "abrir(3);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
                    }
                    else
                    {
                        mostrarmensaje("error", "ERROR: No se logró agregar la prueba.");
                        string open = "abrir(3);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
                    }

                }
                else
                {
                    dropResultado.SelectedIndex = 2;//Resultado No exitoso
                    if (act.agregarPrueba(lblCodActividad.Text, "", txtCCQ.Text, txtTtlNodo.Text, txtTtlWeb.Text, txtAnchoActual.Text, txtDescripcionPrueba.Text, dropResultado.SelectedValue, lblCodUsuarioRol.Text))
                    {
                        txtSm.Text = string.Empty;
                        txtCCQ.Text = string.Empty;
                        txtTtlNodo.Text = string.Empty;
                        txtTtlWeb.Text = string.Empty;
                        txtAnchoBanda.Text = string.Empty;
                        txtAnchoActual.Text = string.Empty;
                        txtDescripcionPrueba.Text = string.Empty;

                        cargarPruebas(lblCodActividad.Text);
                        mostrarmensaje("exito", "Prueba agregada Correctamente.");
                        string open = "abrir(3);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
                    }
                    else
                    {
                        mostrarmensaje("error", "ERROR: No se logró agregar la prueba.");
                        string open = "abrir(3);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
                    }
                }
            }
            else if (txtCCQ.Text == "")//CCQ vacío
            {
                //validando todos los campos de la vista con los campos de la base de datos 
                if (sm > dbsm && ttlnodo <= dbttlnodo && ttlweb <= dbttlweb && anchoactual >= anchocontratado)
                {
                    dropResultado.SelectedIndex = 1;//Resultado exitoso
                    if (act.agregarPrueba(lblCodActividad.Text, txtSm.Text, "", txtTtlNodo.Text, txtTtlWeb.Text, txtAnchoActual.Text, txtDescripcionPrueba.Text, dropResultado.SelectedValue, lblCodUsuarioRol.Text))
                    {
                        txtSm.Text = string.Empty;
                        txtCCQ.Text = string.Empty;
                        txtTtlNodo.Text = string.Empty;
                        txtTtlWeb.Text = string.Empty;
                        txtAnchoBanda.Text = string.Empty;
                        txtAnchoActual.Text = string.Empty;
                        txtDescripcionPrueba.Text = string.Empty;

                        cargarPruebas(lblCodActividad.Text);
                        mostrarmensaje("exito", "Prueba agregada Correctamente.");
                        string open = "abrir(3);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
                    }
                    else
                    {
                        mostrarmensaje("error", "ERROR: No se logró agregar la prueba.");
                        string open = "abrir(3);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
                    }

                }
                else
                {
                    dropResultado.SelectedIndex = 2;//Resultado No exitoso
                    if (act.agregarPrueba(lblCodActividad.Text, txtSm.Text, "", txtTtlNodo.Text, txtTtlWeb.Text, txtAnchoActual.Text, txtDescripcionPrueba.Text, dropResultado.SelectedValue, lblCodUsuarioRol.Text))
                    {
                        txtSm.Text = string.Empty;
                        txtCCQ.Text = string.Empty;
                        txtTtlNodo.Text = string.Empty;
                        txtTtlWeb.Text = string.Empty;
                        txtAnchoBanda.Text = string.Empty;
                        txtAnchoActual.Text = string.Empty;
                        txtDescripcionPrueba.Text = string.Empty;

                        cargarPruebas(lblCodActividad.Text);
                        mostrarmensaje("exito", "Prueba agregada Correctamente.");
                        string open = "abrir(3);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
                    }
                    else
                    {
                        mostrarmensaje("error", "ERROR: No se logró agregar la prueba.");
                        string open = "abrir(3);";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);
                    }
                }
            }
        }
        else
        {
            mostrarmensaje("error","no hay Variables de Prueba para validar.");
        }
      
    }
  
}