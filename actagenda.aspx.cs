using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class actagenda : System.Web.UI.Page
{
    Funciones fun = new Funciones();
    Actividad act = new Actividad();
    Proyecto pro = new Proyecto();
    Usuario user = new Usuario();
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
            PanelAgregarEvento.Attributes.Add("style", "display:none");
            PanelListadoUsuario.Attributes.Add("style", "display:none");

            lblCodUsuarioRol.Text = Session["codusuariorol"].ToString();
            lblCodUsuario.Text = Session["codusuario"].ToString();
            lblTipoUsuario.Text = Session["codrol"].ToString();

            obtenerGETOriginal();
            obtenerSessionOriginal();
            cerrarSessiones();
            if (lblTipoUsuario.Text == "2")//Si es un coordinador cargo los drops que él va a usar
            {
                ddActividades(dropTipoActividad);
                ddProyectosCoordinador(dropProyectos);
            }
            if (lblTipoUsuario.Text == "1" || lblTipoUsuario.Text == "3")//Si es un administrador o agente le muestro los filtros
            {
                PanelFiltros.Visible = true;
                ddProyectos(dropProyectoFiltrar);
                ddEstados(dropEstadoFiltrar);
            }
            ddEstados(dropEstadoLista);
            cargarScript(lblTipoUsuario.Text);
            lblColores.Text = cargarColores();

            if (lblOperacion.Text == "u")
            {
                Actividad activity = new Actividad();
                DataRow datoEvento = activity.buscarActividadAgendada(lblCodEvento.Text);
                if (datoEvento != null)
                {
                    llenarFormulario(datoEvento);
                    this.PanelAgregarEvento_Modalpopupextender2.Show();
                }
                else
                {
                    this.PanelAgregarEvento_Modalpopupextender2.Show();
                    mostrarmensaje("error", "ERROR: Actividad no encontrada");
                }
            }
          
           
        }
    }
    private void llenarFormulario(DataRow datoEvento)
    {
       
        dropTipoActividad.SelectedValue = datoEvento["codtipoactividad"].ToString();
        dropTipoActividad_SelectedIndexChanged(null, null);
        txtDescripción.Text = datoEvento["descripcion"].ToString();
               
        string fechahoraini = datoEvento["startday"].ToString();
        string[] split = fechahoraini.Split(new Char[] { ' ', ':' });
        txtFechaIni.Text = split[0].Replace("/", "-");

        if (Convert.ToInt16(split[1]) < 9)
            dropHoraini.SelectedValue = "0" + split[1];
        else
            dropHoraini.SelectedValue = split[1];

        dropMinutosini.SelectedValue = split[2];

        string fechahorafin = datoEvento["endday"].ToString();

        string[] split2 = fechahorafin.Split(new Char[] { ' ', ':' });
        txtFechaFin.Text = split2[0].Replace("/", "-");
        if (Convert.ToInt16(split2[1]) <= 9)
            dropHorafin.SelectedValue = "0" + split2[1];
        else
            dropHorafin.SelectedValue = split2[1];

        dropMinutosfin.SelectedValue = split2[2];

        dropProyectos.SelectedValue = datoEvento["codproyecto"].ToString();

        //Cargamos los proyectos que tiene el coordiandor para ver si hizo el selectedIndexChange - 
        // con el metodo  ddProyectosCoordinador(dropProyectos); en la linea 50
        DataTable datosProyectos = pro.cargarProyectosxCoordinador(lblCodUsuario.Text, lblTipoUsuario.Text);
        if (datosProyectos != null && datosProyectos.Rows.Count>0)
        {
            if (datosProyectos.Rows.Count == 1)
                dropCliente.SelectedValue = datoEvento["codcliente"].ToString();
            else
            {
                dropProyectos_SelectedIndexChanged(null, null);
                dropCliente.SelectedValue = datoEvento["codcliente"].ToString();
            }
        }

            DataTable datosTecnicos =  act.cargarParticipantesActividadAgendada(datoEvento["cod"].ToString());
            if (datoEvento != null && datosTecnicos.Rows.Count > 0)
            {
                //Ya el radiobuttonList esta lleno
                //En en selectedindexchange del drop proyectos.
                for (int i = 0; i < cblTecnicos.Items.Count; i++)
                    for (int j = 0; j < datosTecnicos.Rows.Count; j++)
                        if (cblTecnicos.Items[i].Value == datosTecnicos.Rows[j]["cod"].ToString())
                            cblTecnicos.Items[i].Selected = true;
                             
                         
                     
            }

        btnAddEvento.Visible = false;
        btnEditar.Visible = true;

      
    }
    public void obtenerGETOriginal()
    {

        if (Session["o"] == null)//p Pago, r Recibo, v Volver al defecto
        {

            Session["c"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["c"]);//codevento
            lblOperacion.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["o"]);

            if (lblOperacion.Text != "")
            {
                Session["o"] = lblOperacion.Text;
                Response.Redirect("actagenda.aspx"); // para eliminarlos de la URL
            }

        }

    }
    public void obtenerSessionOriginal()
    {
        //Capturamos los parametros
        if (Session["c"] != null)
            lblCodEvento.Text = Session["c"].ToString();
        if (Session["o"] != null)
            lblOperacion.Text = Session["o"].ToString();
        else
            lblOperacion.Text = "";
    }
    public void cerrarSessiones()
    {
        Session["c"] = null;
        Session["o"] = null;
    }
    private string cargarColores()
    {
        string ca = "";
        DataTable datosEstado = act.cargarEstados();
        if (datosEstado != null && datosEstado.Rows.Count > 0)
        {
            for (int i = 0; i < datosEstado.Rows.Count; i++)
            {
                ca += "<div style='width:35px; height:16px; background-color:" + datosEstado.Rows[i]["hex"].ToString() + "; color:#fff; padding:2px; margin-right:2px; text-align:center'>";
                ca += "<a href='javascript:void(0);' style='color:#ffffff' class='decorLink' title='" + datosEstado.Rows[i]["nombre"].ToString() + "'>" + datosEstado.Rows[i]["nombre"].ToString().Substring(0,3) + "</a>";
                ca += "</div>";
            }

        }
        else
        {
            ca = "ERROR: No se han creado los estados";
        }
        return ca;
    }
    private void ddProyectos(DropDownList drop)
    {
        DataTable datosProyectos = pro.cargarProyectos();
        drop.DataSource = datosProyectos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos"));
    }
    private void ddEstados(DropDownList drop)
    {
        DataTable datosProyectos = act.cargarEstados();
        drop.DataSource = datosProyectos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos"));
    }
    private void rblTecnicos(CheckBoxList rbl)
    {
        rbl.DataSource = user.cargarTecnicosxCoordinadorxProyecto(lblCodUsuario.Text, dropProyectos.SelectedValue);
        rbl.DataTextField = "nombre";
        rbl.DataValueField = "cod";
        rbl.DataBind();
    }
    private void ddActividades(DropDownList drop)
    {
        drop.DataSource = act.cargarActividades();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddAClientesxProyecto(DropDownList drop, string codproyecto)
    {
        drop.DataSource = pro.cargarClienteInProyecto(codproyecto);
        drop.DataTextField = "nombrenit";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));

        string script = "buscar();";
        if (ScriptManager1.IsInAsyncPostBack)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "scriptkey", script, true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), script, true);
        }
    }
    //private void ddAClientesxProyecto(string codproyecto)
    //{
    //    gridcblClientes.DataSource = pro.cargarClienteInProyecto(codproyecto);
    //    gridcblClientes.DataBind();
    //    gridcblClientes.UseAccessibleHeader = true;
    //    if (gridcblClientes.HeaderRow != null)
    //    {
    //        gridcblClientes.HeaderRow.TableSection = TableRowSection.TableHeader;
    //    }
    //    if (gridcblClientes.ShowFooter)
    //        gridcblClientes.FooterRow.TableSection = TableRowSection.TableFooter;
    //}
    //protected void gridcblClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    gridcblClientes.PageIndex = e.NewPageIndex;
    //    ddAClientesxProyecto(dropProyectos.SelectedValue);

    //}
    private void ddProyectosCoordinador(DropDownList drop)
    {
        DataTable datosProyectos = pro.cargarProyectosxCoordinador(lblCodUsuario.Text, lblTipoUsuario.Text);
        drop.DataSource = datosProyectos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));

        if (datosProyectos != null && datosProyectos.Rows.Count == 1)
        {
            drop.SelectedIndex = 1;
            drop.Enabled = false;
            dropProyectos_SelectedIndexChanged(null, null);
        }
        else if (datosProyectos.Rows.Count == 0)
        {
            mostrarmensaje("error", "ERROR: No tienes proyectos asignados, No podras crear actividades.");
            imgAddGeneral.Visible = false;
        }
        else
        {
            dropProyectos_SelectedIndexChanged(null, null);
            //mostrarmensaje("error", Convert.ToString(datosProyectos.Rows.Count));
        }
        
    }
    private void cargarScript(string tipousuario)
    {
        string ca = "";
        string activarGooCalendar = "no";
        ca += "  <script type='text/javascript'>";
        ca += "     $(document).ready(function () {";
        ca += "           $('#calendar').fullCalendar({";
        ca += "                  theme: true,";
        ca += " lang: 'es',";
        ca += " header: {";
        ca += " left: 'prev,next today',";
        ca += " center: 'title',";
        ca += " right: 'month,agendaWeek,agendaDay'";
        ca += " },";
        ca += " defaultDate: '" + fun.convertFechaAño(DateTime.Now.ToString()) + "',";
        ca += "  selectable: 'true',";
        ca += "	selectHelper: 'true',";
        //ca += agregarAlert();
        //ca += " editable: true,";
        ca += " eventLimit: true,";
        if (activarGooCalendar == "si")
        {
            ca += "googleCalendarApiKey: 'AIzaSyDcnW6WejpTOCffshGDDb4neIrXVUA1EAE',";
            ca += "  eventSources: [";
            ca += " {";
            ca += "     googleCalendarId: 'es.co#holiday@group.v.calendar.google.com'";
            ca += "  },";
            ca += "   {";
            ca += " events: ";
            string va1 = buscarEventos(tipousuario);
            ca += va1;
            ca += "  }]";
        }
        else
        {
            ca += " events: ";
            ca += buscarEventos(tipousuario);
        }

        ca += " });";
        ca += " });";
        ca += " </script>";
        ltrScript.Text = ca;
    }
    private void cargarScriptFiltrado(string tipousuario,string where)
    {
        string ca = "";
        string activarGooCalendar = "no";
        ca += "  <script type='text/javascript'>";
        ca += "     $(document).ready(function () {";
        ca += "           $('#calendar').fullCalendar({";
        ca += "                  theme: true,";
        ca += " lang: 'es',";
        ca += " header: {";
        ca += " left: 'prev,next today',";
        ca += " center: 'title',";
        ca += " right: 'month,agendaWeek,agendaDay'";
        ca += " },";
        ca += " defaultDate: '" + fun.convertFechaAño(DateTime.Now.ToString()) + "',";
        ca += "  selectable: 'true',";
        ca += "	selectHelper: 'true',";
        //ca += agregarAlert();
        //ca += " editable: true,";
        ca += " eventLimit: true,";
        if (activarGooCalendar == "si")
        {
            ca += "googleCalendarApiKey: 'AIzaSyDcnW6WejpTOCffshGDDb4neIrXVUA1EAE',";
            ca += "  eventSources: [";
            ca += " {";
            ca += "     googleCalendarId: 'es.co#holiday@group.v.calendar.google.com'";
            ca += "  },";
            ca += "   {";
            ca += " events: ";
            string va1 = buscarEventosFiltrado(tipousuario,where);
            ca += va1;
            ca += "  }]";
        }
        else
        {
            ca += " events: ";
            ca += buscarEventosFiltrado(tipousuario,where);
        }

        ca += " });";
        ca += " });";
        ca += " </script>";
        ltrScript.Text = ca;
    }
    private string buscarEventosFiltrado(string tipousuario, string where)
    {
        string ca = "";
        if (tipousuario == "1" || tipousuario=="3")//Administradro o  agente
        {
            DataTable datosEventos = act.cargarActividadesAgendadas(where);
            if (datosEventos != null && datosEventos.Rows.Count > 0)
            {
                ca += crearJson(datosEventos, tipousuario);
            }
            else
            {
                mostrarmensaje("error", "No se encontraron actividades con este filtro.");
            }

        }
        else
        {
            PanelAgregarAct.Visible = false;
            refrescar.Visible = false;
            imgListaEventos.Visible = false;
            mostrarmensaje("error", "El rol de usuario actual no esta permitido para este modulo.");
        }
        return ca;
    }
    private string buscarEventos(string tipousuario)
    {
        string ca = "";
        if (tipousuario == "1" || tipousuario=="3")//Administrador o Agente
        {
            DataTable datosEventos = act.cargarActividadesAgendadas("");
            if (datosEventos != null && datosEventos.Rows.Count > 0)
            {
                ca += crearJson(datosEventos, tipousuario);
            }
          
        }
        else if (tipousuario == "2")//Coordinador
        {
            PanelAgregarAct.Visible = true;
            
            DataTable datosEventos = act.cargarActividadesAgendadasxCoordinador("WHERE a.codusuariorol='"+lblCodUsuarioRol.Text+"'");
            if (datosEventos != null && datosEventos.Rows.Count > 0)
            {
                ca += crearJson(datosEventos, tipousuario);
            }

        }
        else if (tipousuario == "5")//Tecnico
        {
            DataTable datosEventos = act.cargarActividadesAgendadasxTecnico("WHERE ap.`codusuariorol`='"+lblCodUsuarioRol.Text+"'");
            if (datosEventos != null && datosEventos.Rows.Count > 0)
            {
                ca += crearJson(datosEventos, tipousuario);
            }

        }
        else
        {
            PanelAgregarAct.Visible = false;
            refrescar.Visible = false;
            imgListaEventos.Visible = false;
            mostrarmensaje("error", "El rol de usuario actual no esta permitido para este modulo.");
        }
        return ca;
    }
    private String crearJson(DataTable datosEventos, string tipousuario)
    {
        String jsonString = "";
        List<Actividad> listaEventos = new List<Actividad>();
        DataTable datos = new DataTable();
        for (int i = 0; i < datosEventos.Rows.Count; i++)
        {
            Actividad ev = new Actividad();
            ev.title = (cargarTitleEvento(datosEventos.Rows[i], tipousuario));
            ev.start = (fun.convertFechaAñoMesDiaHora(datosEventos.Rows[i]["startday"].ToString()).Replace(" ", "T"));
            ev.end = (fun.convertFechaAñoMesDiaHora(datosEventos.Rows[i]["endday"].ToString()).Replace(" ", "T"));
            ev.color = datosEventos.Rows[i]["hex"].ToString();
            listaEventos.Add(ev);
        }
        var jsonSerialiser = new JavaScriptSerializer();
        jsonString = jsonSerialiser.Serialize(listaEventos);
        return jsonString;
    }
    private string cargarTitleEvento(DataRow datoEvento, string tipousuario)
    {
        string title = "Titulo";
        try
        {
            title = " #" + datoEvento["cod"].ToString() + " - " + datoEvento["proyecto"].ToString() + " --> " + datoEvento["actividad"].ToString() + " : " + datoEvento["descripcion"].ToString();
        }
        catch { }
        return title;
    }
    protected void imgAddGeneral_Click(object sender, ImageClickEventArgs e)
    {
        limpiarCampos();
        this.PanelAgregarEvento_Modalpopupextender2.Show();

       
        
    }
    protected void imgListaEventos_Click(object sender, ImageClickEventArgs e)
    {
        lblMiLista_BETA.Text = cargarEventosParaMiLista(lblTipoUsuario.Text,false);
        this.PanelListadoUsuario_Modalpopupextender.Show();
    }
    int sw = 0;
    protected void dropProyectos_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropProyectos.SelectedIndex > 0)
        {
            cblTecnicos.Items.Clear();
            ddAClientesxProyecto(dropCliente, dropProyectos.SelectedValue);
            //ddAClientesxProyecto(dropProyectos.SelectedValue);
            rblTecnicos(cblTecnicos);
            //lblvalidador.Text = "dropProyectos";
            //string script = "cargarDataTable();";
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "scriptkey", script, true);
        }
        else 
        {
            if(sw == 0)
            {
                dropProyectos.SelectedIndex = 1;
                string pro = dropProyectos.SelectedValue; 
                ddAClientesxProyecto(dropCliente, pro);
                //ddAClientesxProyecto(dropCliente, dropProyectos.SelectedValue);
                rblTecnicos(cblTecnicos);
                //lblvalidador.Text = "sw";
                sw = 1;
            }
            else 
            {
                
                ddAClientesxProyecto(dropCliente, dropProyectos.SelectedValue);
                rblTecnicos(cblTecnicos);
            }
            
            //mostrarmensaje("exito", "");
        }
    }
    protected void btnAddEvento_Click(object sender, EventArgs e)
    {
        if(validarTecnico(cblTecnicos))
        {
            DateTime ini = Convert.ToDateTime(txtFechaIni.Text + " " + dropHoraini.SelectedValue + ":" + dropMinutosini.SelectedValue);
            DateTime fin = Convert.ToDateTime(txtFechaFin.Text + " " + dropHorafin.SelectedValue + ":" + dropMinutosfin.SelectedValue);
            int result = DateTime.Compare(ini, fin);
            if (result <= 0)
            {
                long id = act.agregarActividadAgendada(lblCodUsuarioRol.Text, txtDescripción.Text, fun.convertFechaAñoMesDiaHora(ini.ToString()), fun.convertFechaAñoMesDiaHora(fin.ToString()), dropProyectos.SelectedValue, dropCliente.SelectedValue, dropTipoActividad.SelectedValue, fun.getFechaAñoHoraActual(), "1");
                if (id != -1)
                {
                    relacionarTecnicos(id.ToString(), cblTecnicos);
                    mostrarmensaje("exito", "Actividad Agregada Correctamente");
                    cargarScript(lblTipoUsuario.Text);
                    limpiarCampos();
                }
                else
                {
                    mostrarmensaje("error", "ERROR: No se logro agregar la actividad.");
                    this.PanelAgregarEvento_Modalpopupextender2.Show();
                }
            }
            else
            {
                mostrarmensaje("error", "ERROR: Fechas Invalidas.");
                this.PanelAgregarEvento_Modalpopupextender2.Show();
            }
           
        }
        else
        {
            mostrarmensaje("error", "ERROR: Debe elegir minimo UN Tecnico");
            this.PanelAgregarEvento_Modalpopupextender2.Show();
        }
    }
    private void limpiarCampos()
    {
        dropTipoActividad.SelectedIndex = 0;
        txtDescripción.Text = string.Empty;
        txtFechaIni.Text = string.Empty;
        dropHoraini.SelectedIndex = 0;
        dropMinutosini.SelectedIndex = 0;
        txtFechaFin.Text = string.Empty;
        dropHorafin.SelectedIndex = 0;
        dropMinutosini.SelectedIndex = 0;
        rblTecnicos(cblTecnicos);
    }
    private bool validarTecnico(CheckBoxList combo)
    {
        bool eligio = false;
        for (int i = 0; i < combo.Items.Count; i++)
           if (combo.Items[i].Selected)
               eligio = true;
        return eligio;
    }
    private void relacionarTecnicos(string id, CheckBoxList combo)
    {
        for (int i = 0; i < combo.Items.Count; i++)
           if (combo.Items[i].Selected)
              act.agregarTecnicosAgenda(id, combo.Items[i].Value);
    }
    private void editarTecnicos(string codactividad,CheckBoxList combo)
    {
        act.eliminarParticiantesAgenda(codactividad);  //Eliminamos todos los tecnicos que existian y agrego los que acabo de eligir
        for (int i = 0; i < combo.Items.Count; i++)
            if (combo.Items[i].Selected)
                act.agregarTecnicosAgenda(codactividad, combo.Items[i].Value);
    }
    protected void txtFechaIni_TextChanged(object sender, EventArgs e)
    {
        txtFechaFin.Text = txtFechaIni.Text;
    }
    protected void dropTipoActividad_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataRow datoTipoActividad = act.buscarActividad(dropTipoActividad.SelectedValue);
        if (datoTipoActividad != null)
        {
            lblAns.Text = datoTipoActividad["ans"].ToString();
            lblColorFiltro.Text = "<div style='display:inline;width:35px; height:16px; background-color:#ccc; color:#fff; padding:2px; margin-right:2px; text-align:center'>ANS: " + datoTipoActividad["ans"].ToString() + "</div>";
        }
        else
            lblColorFiltro.Text = "";
        
    }
    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
        cargarScriptFiltrado(lblTipoUsuario.Text, llenarWhere());
    }
    private string llenarWhere()
    {
        int numero = 2;
        string[] cond;
        cond = new string[numero];
       
        cond[0] = string.Empty;  //codproyecto
        cond[1] = string.Empty;  //estado

        if (dropProyectoFiltrar.SelectedIndex > 0)
        {
            cond[0] = "  a.`codproyecto`='" + dropProyectoFiltrar.SelectedValue + "'";
        }
        if (dropEstadoFiltrar.SelectedIndex>0)
        {
            cond[1] = "a.`codestado`='" + dropEstadoFiltrar.SelectedValue + "'";
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
        return where;
    }
    private string llenarWhereLista(string tipousuario,string codusuariorol)
    {
        int numero = 4;
        string[] cond;
        cond = new string[numero];

        cond[0] = string.Empty;  //codproyecto
        cond[1] = string.Empty;  //estado
        cond[2] = string.Empty;  //fechas
        cond[3] = string.Empty; // Filtros adicionales solo para visualizar las actividades de coordinador o un tecnico

        if (dropProyectoLista.SelectedIndex > 0)
        {
            cond[0] = "  a.`codproyecto`='" + dropProyectoLista.SelectedValue + "'";
        }

        if (dropEstadoLista.SelectedIndex > 0)
        {
            cond[1] = "a.`codestado`='" + dropEstadoLista.SelectedValue + "'";
        }

        if (txtFechaIniFiltro.Text != string.Empty && txtFechaFinFiltro.Text != string.Empty)
        {
            cond[2] = "DATE_FORMAT(a.`startday`,'%Y-%m-%d') BETWEEN DATE_FORMAT('" + fun.convertFechaAño(txtFechaIniFiltro.Text) + "','%Y-%m-%d') AND DATE_FORMAT('" + fun.convertFechaAño(txtFechaFinFiltro.Text) + "','%Y-%m-%d')";
        }
        else if (txtFechaIniFiltro.Text != string.Empty)
        {
            cond[2] = "DATE_FORMAT(a.`startday`,'%Y-%m-%d') >= DATE_FORMAT('" + fun.convertFechaAño(txtFechaIniFiltro.Text) + "','%Y-%m-%d')";

        }
        else if (txtFechaFinFiltro.Text != string.Empty)
        {
            cond[2] = "DATE_FORMAT(a.`startday`,'%Y-%m-%d') <= DATE_FORMAT('" + fun.convertFechaAño(txtFechaFinFiltro.Text) + "','%Y-%m-%d')";
        }

        if (tipousuario.Equals("2"))//Coordinador
        {
            cond[3] = "a.codusuariorol='"+codusuariorol+"'";
        }
        else if (tipousuario.Equals("5"))//Tecnico
        {
            cond[3] = "ap.`codusuariorol`='" + codusuariorol + "'";
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
        return where;
    }
    protected void dropHoraini_SelectedIndexChanged(object sender, EventArgs e)
    {
            int ans = Convert.ToInt16(lblAns.Text);
            int horainicio = Convert.ToInt16(dropHoraini.SelectedValue);
            int suma = horainicio + ans;
            string horafin = "00";
            if (suma < 10)
            {
                horafin = "0" + suma.ToString();
            }

            if (suma <23)
            {
                dropHorafin.SelectedValue = horafin;
            }
            else
            {
                dropHorafin.SelectedValue = "23";
            }
    }
    protected void btnFiltrarLista_Click(object sender, EventArgs e)
    {
        lblMiLista_BETA.Text = cargarEventosParaMiLista(lblTipoUsuario.Text,true);
        this.PanelListadoUsuario_Modalpopupextender.Show();
    }

    private string cargarEventosParaMiLista(string codtipousuario,bool filtro)
    {
        string ca = "";
        switch (codtipousuario)
        {
            case "1": //administrador           
                DataTable datosEventosA = act.cargarActividadesAgendadas(llenarWhereLista(codtipousuario,lblCodUsuarioRol.Text));
                if (datosEventosA != null && datosEventosA.Rows.Count > 0)
                {
                    ca = armarCadenaMiLista(datosEventosA, codtipousuario, filtro);
                }
                else
                {
                    ca = "No se encontro ningúna actividad.";
                }
                break;
             case "3": //Agente           
                DataTable datosEventosAg = act.cargarActividadesAgendadas(llenarWhereLista(codtipousuario,lblCodUsuarioRol.Text));
                if (datosEventosAg != null && datosEventosAg.Rows.Count > 0)
                {
                    ca = armarCadenaMiLista(datosEventosAg, codtipousuario, filtro);
                }
                else
                {
                    ca = "No se encontro ningúna actividad.";
                }
                break;
            case "2"://Coordinador
                DataTable datosEventosE = act.cargarActividadesAgendadasxCoordinador(llenarWhereLista(codtipousuario, lblCodUsuarioRol.Text));
              if (datosEventosE != null && datosEventosE.Rows.Count > 0)
              {
                  ca = armarCadenaMiLista(datosEventosE, codtipousuario, filtro);
              }
              else
              {
                    ca = "No se encontro ningúna actividad.";
              }
               
                break;
            case "5": //Tecnico
                DataTable datosEventosD = act.cargarActividadesAgendadasxTecnico(llenarWhereLista(codtipousuario, lblCodUsuarioRol.Text));
                if (datosEventosD != null && datosEventosD.Rows.Count > 0)
                {
                    ca = armarCadenaMiLista(datosEventosD, codtipousuario, filtro);
                }
                else
                {
                    ca = "No se encontro ningún evento";
                }
                break;
         
            default:
                mostrarmensaje("error", "ERROR: Tipo de usuario no encontrado para mi lista " + codtipousuario);
                ca = "ERROR: Tipo de usuario no encontrado para mi lista " + codtipousuario;
                break;
        }
        return ca;
    }

    private string armarCadenaMiLista(DataTable datosEventos, string codtipoUsuario,bool filtro)
    {
        int sumar = 0;
        string ca = "";
        //obtener los proyectos
        DataTable dtCodProyectos= new DataTable();
        dtCodProyectos.Columns.AddRange(new DataColumn[2] { new DataColumn("codproyecto"), new DataColumn("proyecto") });
        string[] categorias = new string[datosEventos.Rows.Count];
        for (int i = 0; i < datosEventos.Rows.Count; i++)
        {
            if (i == 0)
            {
                dtCodProyectos.Rows.Add(datosEventos.Rows[i]["codproyecto"].ToString(),datosEventos.Rows[i]["proyecto"].ToString());
                categorias[sumar] = datosEventos.Rows[i]["codproyecto"].ToString();
                sumar += 1;
            }
            else
            {
                if (categorias[sumar - 1] != datosEventos.Rows[i]["codproyecto"].ToString())
                {
                    dtCodProyectos.Rows.Add(datosEventos.Rows[i]["codproyecto"].ToString(), datosEventos.Rows[i]["proyecto"].ToString());
                    categorias[sumar] = datosEventos.Rows[i]["codproyecto"].ToString();
                    sumar += 1;
                }
            }
        }

        if (dtCodProyectos != null && dtCodProyectos.Rows.Count > 0)
        {
            if (!filtro)
            {
                ddProyectoFiltro(dropProyectoLista, dtCodProyectos);
            }
           
            for (int i = 0; i < dtCodProyectos.Rows.Count; i++)
            {
                string codProyecto = dtCodProyectos.Rows[i]["codproyecto"].ToString();
                string nombreProyecto = dtCodProyectos.Rows[i]["proyecto"].ToString();
           
                ca += "<fieldset class='fieldset'>";
                ca += "<legend><b>" + nombreProyecto + "</b></legend>";

                DataRow[] foundRowsEventos = datosEventos.Select("codproyecto = '" + codProyecto + "'", "startday");
                if (foundRowsEventos != null && foundRowsEventos.Length > 0)
                {
                    for (int r = 0; r < foundRowsEventos.Length; r++)
                    {
                            ca += "<div class='evento_gnral' id='div" + foundRowsEventos[r]["cod"].ToString() + "' style='border-left:4px solid " + foundRowsEventos[r]["hex"].ToString() + ";'> ";
                            ca += "<div class='evento_titulo'>";
                            ca += "<p style='display:inline; font-weight:normal; font-size:80%;margin-right:2px;'>";
                            ca += "<a href='javascript:void(0);' class='decorLink' title='FI: " + convertFechaHoraMinDia(foundRowsEventos[r]["startday"].ToString()) + " - FF: " + convertFechaHoraMinDia(foundRowsEventos[r]["endday"].ToString()) + "'>" + fun.convertFechaDia(foundRowsEventos[r]["startday"].ToString()).Replace("-",".") + "</a></p>";
                            ca += "&nbsp;&nbsp;&nbsp;" + foundRowsEventos[r]["actividad"].ToString();
                            ca += armarOperaciones(foundRowsEventos[r]["cod"].ToString(), codtipoUsuario);
                            ca += "</div>";
                            if (foundRowsEventos[r]["descripcion"].ToString() != "")
                            {
                                ca += "<div class='evento_descripcion'>" + "<i>" + buscarNombreUsuario(foundRowsEventos[r]["codusuariorol"].ToString()) + " dice \"" + foundRowsEventos[r]["descripcion"].ToString() + "\" <a href='actdetalle.aspx?ca=" + foundRowsEventos[r]["cod"].ToString() + "' class='evento_img'><img src='Imagenes/details.png' /></a> </i></div>";

                            }
                            else
                            {
                                ca += "<div class='evento_descripcion'>" + "<i>" + buscarNombreUsuario(foundRowsEventos[r]["codusuariorol"].ToString()) + " creado \"" + convertFechaHoraMinDia(foundRowsEventos[r]["createdday"].ToString()).Replace("-", ".") + "\" <a href='actdetalle.aspx?ca=" + foundRowsEventos[r]["cod"].ToString() + "' class='evento_img'><img src='Imagenes/details.png' /></a> </i></div>";
                            }
                            ca += "</div>";
                     }
                }
                ca += "</fieldset>";
            }
        }
        return ca;
    }
    private string armarOperaciones(string codevento, string tipousuario)//revisar ESTO!!!, que esa generalizado.
    {
        string ca = "";
            if (tipousuario == "4" || tipousuario.Equals("1"))// y Administrador
            {
                //ca += "<a href='agemiagenda.aspx?c=" + codevento + "&o=up' title='Editar evento'><img src='Imagenes/edit.png' style='padding-left:4px;width:18px' /></a>";
                //ca += "<img alt='Eliminar' title='Eliminar Evento Para Este Curso' id='img" + codeventocursos + "'  onclick='eliminar(this);' src='Imagenes/delete.png' style='padding-left:4px;width:18px' />";
                //ca += "<a href='agemiagenda.aspx?c=" + codevento + "&o=de' title='Eliminar evento'><img  src='Imagenes/delete.png' style='padding-left:30px;width:18px' /></a>";
            }
            else if (tipousuario == "2")//Coordinador
            {
                ca += "<a href='actagenda.aspx?c=" + codevento + "&o=u' title='Editar evento'><img src='Imagenes/edit.png' style='padding-left:4px;width:18px' /></a>";
                ca += "<img  onclick='eliminar(this);' id='img" + codevento + "'  src='Imagenes/delete.png' style='padding-left:4px;width:18px' alt='Eliminar' title='Eliminar Actividad' />";
            }
        
        return ca;
    }
    public string convertFechaHoraMinDia(string fechahoraaño)
    {
        if (fechahoraaño != "")
        {
            string fecha = String.Format("{0:dd-MM-yyyy HH:mm}", Convert.ToDateTime(fechahoraaño));
            return fecha;
        }
        else
        {
            return fechahoraaño = "";
        }
    }
    private void ddProyectoFiltro(DropDownList drop, DataTable datos)
    {
        drop.DataSource = datos;
        drop.DataTextField = "proyecto";
        drop.DataValueField = "codproyecto";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos"));
    }
    private string buscarNombreUsuario(string codusuariorol)
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
    [WebMethod]
    public static string eliminarEvento(String cod)
    {
        Actividad activity = new Actividad();
        activity.eliminarEvidenciaAgenda(cod);
        activity.eliminarParticiantesAgenda(cod);
        activity.eliminarPruebasAgenda(cod);
        activity.eliminarSeguimientoAgenda(cod);
        if (activity.eliminarAgenda(cod))
              return "1";
        else
              return "-1";
    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        Actividad activity = new Actividad();
        if (validarTecnico(cblTecnicos))
        {
            DateTime ini = Convert.ToDateTime(txtFechaIni.Text + " " + dropHoraini.SelectedValue + ":" + dropMinutosini.SelectedValue);
            DateTime fin = Convert.ToDateTime(txtFechaFin.Text + " " + dropHorafin.SelectedValue + ":" + dropMinutosfin.SelectedValue);
            int result = DateTime.Compare(ini, fin);
            if (result <= 0)
            {
                if (activity.editarActividadAgendada(lblCodUsuarioRol.Text, txtDescripción.Text, fun.convertFechaAñoMesDiaHora(ini.ToString()), fun.convertFechaAñoMesDiaHora(fin.ToString()), dropProyectos.SelectedValue, dropCliente.SelectedValue, dropTipoActividad.SelectedValue, lblCodEvento.Text))
                {
                    editarTecnicos(lblCodEvento.Text, cblTecnicos);
                    mostrarmensaje("exito", "Actividad Editada Correctamente");
                    cargarScript(lblTipoUsuario.Text);
                    limpiarCampos();
                }
                else
                {
                    mostrarmensaje("error", "ERROR: No se logró editar la actividad.");
                    this.PanelAgregarEvento_Modalpopupextender2.Show();
                }
          
            }
            else
            {
                mostrarmensaje("error", "ERROR: Fechas Invalidas.");
                this.PanelAgregarEvento_Modalpopupextender2.Show();
            }

        }
        else
        {
            mostrarmensaje("error", "ERROR: Debe elegir minimo UN Tecnico");
            this.PanelAgregarEvento_Modalpopupextender2.Show();
        }
    }
}