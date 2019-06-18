using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class ticmonitor : System.Web.UI.Page
{
    Actividad act = new Actividad();
    Funciones fun = new Funciones();
    Usuario user = new Usuario();
    Proyecto pro = new Proyecto();
    Cliente cli = new Cliente();
    Tickets tic = new Tickets();

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
            
            PanelAgregarTickets.Attributes.Add("style", "display:none");
            PanelEscalar.Attributes.Add("style", "display:none");
            lblCodUsuarioRol.Text = Session["codusuariorol"].ToString();
            lblCodUsuario.Text = Session["codusuario"].ToString();
            lblTipoUsuario.Text = Session["codrol"].ToString();
            //GridTickets.PageSize = 30;
            cargarDrops();
              //gvCargarTickets();
            gvCargarTicketsSinResuelto();
            DataTable dtEstImplicados = new DataTable();
            dtEstImplicados = CreateDataTableEstImplicados();
            Session["myDatatableImplicados"] = dtEstImplicados;

            if (lblOperacion.Text == "v")
            {
               
                dropProyectoLista.SelectedValue = lblCodProyecto.Text;
                dropEstadoLista.SelectedValue = lblCodEstado.Text;
                dropProyectoLista_SelectedIndexChanged(null, null);
                dropClienteLista.SelectedValue = lblCodCliente.Text;
                dropPrioridadLista.SelectedValue = lblCodPrioridad.Text;
                dropSolicitudLista.SelectedValue = lblCodSolicitud.Text;
                dropUsuarios.SelectedValue = lblCodUsuarioS.Text;

                lblValidador.Text = "true";

                //if (lblCodCliente.Text != "0")
                //{
                //    DataTable datosClientes = pro.cargarClienteInProyecto(dropProyectoLista.SelectedValue);
                //    dropClienteLista.DataSource = datosClientes;
                //    dropClienteLista.DataTextField = "nombrenit";
                //    dropClienteLista.DataValueField = "cod";
                //    dropClienteLista.DataBind();
                //}
                //else
                //{
                //    dropClienteLista.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos"));
                //}


            }
            cerrarSessiones();
        }
    }
    private DataTable CreateDataTableEstImplicados()
    {
        DataTable myDataTable = new DataTable();
        myDataTable.Columns.AddRange(new DataColumn[2] { new DataColumn("cod"), new DataColumn("nombre") });
        return myDataTable;
    }
    private void AddDataToTableImplicados(string cod, string nombre,DataTable myTable)
    {
        if (myTable == null)
          CreateDataTableEstImplicados();

        myTable.Rows.Add(cod, nombre);
    }
    private void cargarDrops()
    {
        ddEstados(dropEstadoLista);
        ddProyectos(dropProyectoLista,false);
        ddProyectos(dropProyectosAdd, true);
        ddSolicitudes(dropSolicitudLista,false);
        ddSolicitudes(dropSolicitudAdd, true);
        ddPrioridad(dropPrioridadLista);
        ddUsuarios(dropUsuarios);
    }
    private void cargas()
    {
        
    }
    private void ddPrioridad(DropDownList drop)
    {
        DataTable datosPrioridades = cli.cargarPrioridades();
        drop.DataSource = datosPrioridades;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos"));
    }
    private void ddUsuarios(DropDownList drop)
    {
        DataTable datosUsuarios = cli.cargarUsuariosTicMonitor();
        drop.DataSource = datosUsuarios;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos"));
    }
    private void ddEstados(DropDownList drop)
    {
        DataTable datosEstados = act.cargarEstados();
        drop.DataSource = datosEstados;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos"));
    }
    private bool ddCoordinador(DropDownList drop, string codigo)
    {
        DataTable datosCoordinador = tic.cargarCoordinadoresDeTicket(codigo);
        if (datosCoordinador != null && datosCoordinador.Rows.Count > 0)
        {
            drop.DataSource = datosCoordinador;
            drop.DataTextField = "nombre";
            drop.DataValueField = "cod";
            drop.DataBind();
            return true;
        }
        else {
            mostrarmensaje("error", "ERROR: Este Ticket no se puede Escalar debido a que no existen Coordinadores para este Proyecto");
        }
        //drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos"));
        return false;
    }
    private void ddProyectos(DropDownList drop, bool add)
    {
        DataTable datosProyectos = pro.cargarProyectos();
        drop.DataSource = datosProyectos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        if(add)
            drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
        else
            drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos"));

    }
    private void ddSolicitudes(DropDownList drop,bool add)
    {
        DataTable datosSolicitudes = cli.cargarSolicitudes();
        drop.DataSource = datosSolicitudes;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        if (add)
            drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
        else
            drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos"));
    }
    private void ddClientes(DropDownList drop)
    {
        DataTable datosClientes = pro.cargarClienteInProyecto(dropProyectoLista.SelectedValue);
        drop.DataSource = datosClientes;
        drop.DataTextField = "nombrenit";
        drop.DataValueField = "cod";
        drop.DataBind();
        //if (add)
        //    drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
        //else
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos"));
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
            lblOperacion.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["o"]);//Operacion;

            if (lblOperacion.Text != "")
            {
                Session["o"] = lblOperacion.Text;
                Response.Redirect("ticmonitor.aspx");
            }
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
            lblCodPrioridad.Text = Session["cpri"].ToString();
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
    protected void dropProyectoLista_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddClientes(dropClienteLista);
        if (lblOperacion.Text != "v")
        {
            string script = "cargarDataTable();";
            if (ScriptManager1.IsInAsyncPostBack)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "scriptkey", script, true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), script, true);
            }
        }
    }
    protected void GridTickets_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void GridTickets_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
            GridTickets.PageIndex = e.NewPageIndex;
            gvCargarTickets();

    }
    protected void gridcblClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //gridcblClientes.PageIndex = e.NewPageIndex;
        ddAClientesxProyecto(dropProyectosAdd.SelectedValue);

    }
    private void gvCargarTickets()
    {
        GridTickets.DataSource = tic.cargarTickets(llenarWhereLista());
        GridTickets.DataBind();
        GridTickets.Columns[13].Visible = true;
        GridTickets.Columns[14].Visible = true;
        GridTickets.Columns[21].Visible = false;//Invisible editar

        if (lblTipoUsuario.Text == "3")
        {
            GridTickets.Columns[22].Visible = false;//Invisible eliminar
        }

        GridTickets.UseAccessibleHeader = true;
        if (GridTickets.HeaderRow != null)
        {
            GridTickets.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        if (GridTickets.ShowFooter)
            GridTickets.FooterRow.TableSection = TableRowSection.TableFooter;

        if (GridTickets.Rows.Count > 0)
        {
            btnExportExcel.Visible = true;
            if (GridTickets.Rows.Count == 1)
            {
                //lblNroRegistros.Text = "<b>Se encontró un registro.</b>";
            }
            else
            {
              //  lblNroRegistros.Text = "<b>Se encontraron " + GridTickets.Rows.Count + " registros.</b>";
            }
        }
        else
        {
            lblNroRegistros.Text = "<b>No se encontraron registros.</b>";
            btnExportExcel.Visible = false;
        }
        //string script = "cargarDataTable();";
        //if (ScriptManager1.IsInAsyncPostBack)
        //{
        //    ScriptManager.RegisterStartupScript(this, typeof(Page), "scriptkey", script, true);
        //}
        //else
        //{
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), script, true);
        //}
    }
    private string llenarWhereLista()
    {
        int numero = 8;
        string[] cond;
        cond = new string[numero];

        cond[0] = string.Empty;  //codproyecto
        cond[1] = string.Empty;  //estado
        cond[2] = string.Empty;  //fechas
        cond[3] = string.Empty; // Prioridad
        cond[4] = string.Empty; // Solicitud
        cond[5] = string.Empty; // Solicitud
        cond[6] = string.Empty; // Usuarios
        cond[7] = string.Empty; // Clientes

        if (dropProyectoLista.SelectedIndex > 0)
        {
            cond[0] = "  i.`codproyecto`='" + dropProyectoLista.SelectedValue + "'";
        }

        if (dropEstadoLista.SelectedIndex > 0)
        {
            cond[1] = "  i.`codestado`='" + dropEstadoLista.SelectedValue + "'";
        }

        if (txtFechaIniFiltro.Text != string.Empty && txtFechaFinFiltro.Text != string.Empty)
        {
            cond[2] = "DATE_FORMAT(i.`createdday`,'%Y-%m-%d') BETWEEN DATE_FORMAT('" + fun.convertFechaAño(txtFechaIniFiltro.Text) + "','%Y-%m-%d') AND DATE_FORMAT('" + fun.convertFechaAño(txtFechaFinFiltro.Text) + "','%Y-%m-%d')";
        }
        else if (txtFechaIniFiltro.Text != string.Empty)
        {
            cond[2] = "DATE_FORMAT(i.`createdday`,'%Y-%m-%d') >= DATE_FORMAT('" + fun.convertFechaAño(txtFechaIniFiltro.Text) + "','%Y-%m-%d')";

        }
        else if (txtFechaFinFiltro.Text != string.Empty)
        {
            cond[2] = "DATE_FORMAT(i.`createdday`,'%Y-%m-%d') <= DATE_FORMAT('" + fun.convertFechaAño(txtFechaFinFiltro.Text) + "','%Y-%m-%d')";
        }

        if (dropPrioridadLista.SelectedIndex > 0)
        {
            cond[3] = "pri.`cod`='"+dropPrioridadLista.SelectedValue+"'";
        }

        if (dropSolicitudLista.SelectedIndex > 0)
        {
            cond[4] = " i.`codsolicitud`='"+dropSolicitudLista.SelectedValue+"'";
        }
        if (dropClienteLista.SelectedIndex > 0)
        {
            cond[5] = "i.`codclisede`='" + dropClienteLista.SelectedValue + "'";
        }
        if (dropUsuarios.SelectedIndex > 0)
        {
            cond[6] = "i.`codusuariorol`='" + dropUsuarios.SelectedValue + "'";
        }
    //cod
      //  if(txtFiltro.)
        if (txtFilto.Value != string.Empty) 
        {
            cond[7] = " i.`cod`LIKE'" + txtFilto.Value + "%'";
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

    private void gvCargarTicketsSinResuelto()
    {
        GridTickets.DataSource = tic.cargarTicketsSinResuelto();
        GridTickets.DataBind();
        GridTickets.Columns[13].Visible = true;
        GridTickets.Columns[14].Visible = true;
        GridTickets.Columns[21].Visible = false;//Invisible editar

        if (lblTipoUsuario.Text == "3")
        {
            GridTickets.Columns[22].Visible = false;//Invisible eliminar para agentes
        }

        GridTickets.UseAccessibleHeader = true;
        if (GridTickets.HeaderRow != null)
        {
            GridTickets.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        if (GridTickets.ShowFooter)
            GridTickets.FooterRow.TableSection = TableRowSection.TableFooter;

        if (GridTickets.Rows.Count > 0)
        {
            btnExportExcel.Visible = true;
            if (GridTickets.Rows.Count == 1)
            {
               // lblNroRegistros.Text = "<b>Se encontró un registro.</b>";
            }
            else
            {
              //  lblNroRegistros.Text = "<b>Se encontraron " + GridTickets.Rows.Count + " registros.</b>";
            }
        }
        else
        {
            lblNroRegistros.Text = "<b>No se encontraron registros.</b>";
            btnExportExcel.Visible = false;
        }
    }
    protected void imgVer_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codactivity = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);// Codigo de la actividad
        Server.Transfer("ticdetalle.aspx?ct=" + codactivity + "&cp=" + lblCodProyecto.Text + "&ce=" + lblCodEstado.Text + "&cpri=" + lblCodPrioridad.Text + "&cs=" + lblCodSolicitud.Text + "&cc=" + lblCodCliente.Text + "&cu=" + lblCodUsuarioS.Text, true);
        //Response.Redirect("ticdetalle.aspx?ct=" + codactivity + "&cp=" + lblCodProyecto.Text + "&ce=" + lblCodEstado.Text + "&cpri=" + lblCodPrioridad.Text + "&cs=" + lblCodSolicitud.Text + "&cc=" + lblCodCliente.Text +"&cu=" + lblCodUsuarioS.Text, true);
        //Response.Redirect("ticdetalle.aspx?ct=" + codactivity, true);
    }
    protected void btnFiltrarLista_Click(object sender, EventArgs e)
    {
        gvCargarTickets();
        txtFechaFinFiltro.Text = "";
        txtFechaIniFiltro.Text = "";
        lblcodclientesede.Text = dropClienteLista.SelectedValue;

        if (dropProyectoLista.SelectedIndex > 0)
            lblCodProyecto.Text = dropProyectoLista.SelectedValue;
        if (dropEstadoLista.SelectedIndex > 0)
            lblCodEstado.Text = dropEstadoLista.SelectedValue;
        if (dropSolicitudLista.SelectedIndex > 0)
            lblCodPrioridad.Text = dropPrioridadLista.SelectedValue;
        if (dropSolicitudLista.SelectedIndex > 0)
            lblCodSolicitud.Text = dropSolicitudLista.SelectedValue;
        if (dropUsuarios.SelectedIndex > 0)
            lblCodUsuarioS.Text = dropUsuarios.SelectedValue;
        if (dropClienteLista.SelectedIndex > 0)
            lblCodCliente.Text = dropClienteLista.SelectedValue;
        else
            lblCodCliente.Text = "0";

    }

    protected void dropSolicitudAdd_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropSolicitudAdd.SelectedIndex > 0)
        {
            //DataRow datoTipoSolicitud = cli.buscarTipoSolicitud(dropSolicitudAdd.SelectedValue);
            //if (datoTipoSolicitud != null)
            //{
            //    lblColorFiltro.Text = "<div style='display:inline;width:35px; height:16px; background-color:#ccc; color:#fff; padding:2px; margin-right:2px; text-align:center'><table><tr><th>Prioridad</th><th>ANS</th></tr><tr><td>" + datoTipoSolicitud["nombrep"].ToString() + "</td><td>Prioridad: " + datoTipoSolicitud["ans"].ToString() + "</td></tr></table></div>";
            //}
            //else
            //{
            //    lblColorFiltro.Text = "";
            //}
        }
        string script = "cargarDataTable();";
        if (ScriptManager1.IsInAsyncPostBack)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "scriptkey", script, true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), script, true);
        }
    }
    protected void dropProyectosAdd_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropProyectosAdd.SelectedIndex > 0)
        {
            //ddAClientesxProyecto(dropCliente, dropProyectosAdd.SelectedValue);//Carga el droplist de clientes al seleccionar tipocliente
            //ddAClientesxProyecto(cblClientes, dropProyectosAdd.SelectedValue);//Carga el checklist de clientes al seleccionar tipocliente multiple
            ddAClientesxProyecto(dropProyectosAdd.SelectedValue);
            //string script = "cambiarClientes();";
            //ScriptManager.RegisterStartupScript(this, typeof(Page), "scriptkey", script, true);
        }
        string script1 = "cargarDataTable();";
        if (ScriptManager1.IsInAsyncPostBack)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "scriptkey", script1, true);
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), script1, true);
        }
    }
    private void ddAClientesxProyecto(DropDownList drop, string codproyecto)
    {
        drop.DataSource = pro.cargarClienteInProyecto(codproyecto);
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    //private void ddAClientesxProyecto(CheckBoxList chkLista, string codproyecto) //Carga el checklist de clientes al seleccionar tipocliente multiple
    //{
    //    cblClientes.DataSource = pro.cargarClienteInProyecto(codproyecto);
    //    cblClientes.DataTextField = "nombre";
    //    cblClientes.DataValueField = "cod";
    //    cblClientes.DataBind();
    //    //cblClientes.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    //}
    private void ddAClientesxProyecto(string codproyecto)
    {
        dropCliente.DataSource = pro.cargarClienteInProyecto(codproyecto);
        dropCliente.DataTextField = "nombrenit";
        dropCliente.DataValueField = "cod";
        dropCliente.DataBind();

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
    private void enviarCorreoTicked(long cod, string codUsuario)
    {
        bool envio1 = false;
        bool envio2 = false;
                Email ema = new Email();
                //Envio de correos.
                
                string mensaje = tic.armarCuerpoDelMensaje(lblCodUsuario.Text, cod.ToString(), 1);
                string mensaje2 = tic.armarCuerpoDelMensaje(lblCodUsuario.Text, cod.ToString(), 2);

                //string email2 = tic.buscarReceptor();
                string email="";
                    email = tic.getEmailUsuario(codUsuario);
                DataRow datorec = ema.buscarRemitente("2");//tipo Receptor


                string receptor = "";
                if (datorec != null)
                {
                    receptor = datorec["email"].ToString();
                }

                if (email != "" && fun.email_bien_escrito(email))
                {
                    envio1 = tic.enviarMensajeporcorreo(mensaje, email, cod.ToString());//Mensaje al cliente.
                }

                if (receptor != "" && fun.email_bien_escrito(receptor))
                {
                    envio2 = tic.enviarMensajeporcorreo(mensaje2, receptor, cod.ToString());//Mesa de ayuda
                }

                if (envio1 && envio2)
                {
                    mostrarmensaje("exito", "Ticket Agregado Correctamente");
                }
                else if(envio1 && !envio2)
                {
                    mostrarmensaje("exito", "Ticket Agregado Correctamente: Error enviando correo a Mesa de ayuda");
                }
                else if (!envio1 && envio2)
                {
                    mostrarmensaje("exito", "Ticket Agregado Correctamente: Error enviando correo a Cliente");
                }
                else if (!envio1 && !envio2)
                {
                    mostrarmensaje("exito", "Ticket Agregado Correctamente: Error enviando correos");
                }
    }
    private void enviarCorreoTickedEscalar(string codticket, string codUsuario)
    {
        bool envio1 = false;
        Email ema = new Email();
        //Envio de correos.

        string mensaje = tic.armarCuerpoDelMensajeEscalar(codUsuario, codticket, 2);
        //string email2 = tic.buscarReceptor();
        string email = "";
        email = tic.getEmailUsuarioCoord(codUsuario);
        DataRow datorec = ema.buscarRemitente("1");//tipo Receptor


        string receptor = "";
        if (datorec != null)
        {
            receptor = datorec["email"].ToString();
        }

        if (email != "" && fun.email_bien_escrito(email))
        {
           // envio1 = tic.enviarMensajeporcorreo(mensaje, email, codticket);//Mensaje al coordinador.
        }

        
        if (envio1)
        {
            mostrarmensaje("exito", "Ticket Agregado Correctamente");
        }
        else if (!envio1)
        {
            mostrarmensaje("exito", "Ticket Agregado Correctamente: Error enviando correo a Cliente");
        }
    }
    protected void btnAddTickets_Click(object sender, EventArgs e)
    {
        //mostrarmensaje("exito", "Listo jefe.");
        string ca ="";
        string tick = "";
        long nroticket= 0;
        int cont = 0;
             DataTable clientes = (DataTable)Session["myDatatableImplicados"];
             if (clientes != null && clientes.Rows.Count > 0)
             {
                 for (int i = 0; i < clientes.Rows.Count; i++)
                 {
                     DataRow TicCliente = tic.CargarTicketAbiertoxCliente(clientes.Rows[i]["cod"].ToString());
                     if (TicCliente == null )
                     {
                         DataRow datoCliente = cli.buscarClientexCodSede(clientes.Rows[i]["cod"].ToString());
                         if (datoCliente != null)
                         {
                             long cod = tic.agregarTickets(lblCodUsuarioRol.Text, dropSolicitudAdd.SelectedValue, txtDescripciónAdd.Text, "1", dropProyectosAdd.SelectedValue, clientes.Rows[i]["cod"].ToString());
                             nroticket = cod;
                             tick += " #" + cod.ToString() + " " ;
                             cont++;
                             //if (cod != -1)
                             //    enviarCorreoTicked(cod, datoCliente["codusuario"].ToString());
                         }
                         else
                             mostrarmensaje("error", "ERROR: Cliente no encontrado.");

                     }
                     else
                     {
                         ca += clientes.Rows[i]["nombre"].ToString() + "<br/>"; 
                     }
                     
                 }
             }
             else
             {
                 mostrarmensaje("error", "ERROR: Debe seleccionar minimo un cliente.");
                 this.PanelAgregarEvento_Modalpopupextender2.Show();
             }
             if (ca != "")
             {
                 mostrarmensaje("error","Este cliente ya cuenta con un Ticket abierto.");
                 //lblClientesTicketAbierto.Text = "Esta(s) institucion(es) ya cuenta(n) con un Ticket abierto: " + ca;
             }
             if(tick != "")
             {
                 if (cont > 1)
                 {
                     lblTicketCreado.Text = "<br/><b>Ticket(s) creado(s): </b>" + tick + "<br/>";
                 }
                 else
                 {
                     int time = 1;
                     Response.AppendHeader("Refresh", time + "; Url=ticdetalle.aspx?ct=" + nroticket.ToString() + "");
                 }
             }

        #region anterior
        /*
        string error = "";
                    
                //if (radUnico.Checked && dropCliente.SelectedIndex > 0)//Valida al seleccionar el radio buton de tipo cliente unico
                //{
                //    DataRow datoCliente = cli.buscarClientexCodSede(dropCliente.SelectedValue);
                //    if (datoCliente != null)
                //    {
                //            long cod = tic.agregarTickets(lblCodUsuarioRol.Text, dropSolicitudAdd.SelectedValue, txtDescripciónAdd.Text, "1", dropProyectosAdd.SelectedValue, dropCliente.SelectedValue);
                //            if (cod != -1)
                //            {
                //                enviarCorreoTicked(cod, datoCliente["codusuario"].ToString());
                //            }
                //    }
                //    else
                //    {
                //        error = "ERROR: Cliente no encontrado.";// mostrarmensaje("error", "ERROR: Cliente no encontrado.");
                //    }
                //}
                //else
                //{
                //    if (radMultiple.Checked) //Valida al seleccionar el radio buton de tipo cliente multiple
                //    {
                        bool resp = true;
                        foreach (GridViewRow row in gridcblClientes.Rows)
                        {
                            CheckBox check = row.FindControl("cblClientes") as CheckBox;

                            if (check.Checked)
                            {
                                //aqui la fila esta marcada
                                string codigo = row.Cells[0].Text;
                                resp = false;
                                DataRow datoCliente = cli.buscarClientexCodSede(codigo);
                                if (datoCliente != null)
                                {
                                    long cod = tic.agregarTickets(lblCodUsuarioRol.Text, dropSolicitudAdd.SelectedValue, txtDescripciónAdd.Text, "1", dropProyectosAdd.SelectedValue, codigo);
                                    if (cod != -1)
                                    {
                                        mostrarmensaje("exito", "Ticket agregado correctamente.");
                                       // enviarCorreoTicked(cod, datoCliente["codusuario"].ToString());
                                    }
                                }
                                else
                                {
                                    error = "ERROR: Algunos Clientes no se encontraron.";//mostrarmensaje("error", "ERROR: Cliente no encontrado.");
                                }
                            }
                        }
                        if (resp)
                        {
                            mostrarmensaje("error", "ERROR: Debe elegir el cliente.");
                            this.PanelAgregarEvento_Modalpopupextender2.Show();
                        }
                        //bool resp=true;//Checklist sin gridview
                        //for(int i=0; i<cblClientes.Items.Count; i++)
                        //{
                        //    if (cblClientes.Items[i].Selected) 
                        //    {
                        //        resp=false;
                        //        DataRow datoCliente = cli.buscarClientexCodSede(cblClientes.Items[i].Value);
                        //        if (datoCliente != null)
                        //        {
                        //            long cod = tic.agregarTickets(lblCodUsuarioRol.Text, dropSolicitudAdd.SelectedValue, txtDescripciónAdd.Text, "1", dropProyectosAdd.SelectedValue, cblClientes.Items[i].Value);
                        //            if (cod != -1)
                        //            {
                        //                enviarCorreoTicked(cod, datoCliente["codusuario"].ToString());
                        //            }
                        //        }
                        //        else
                        //        {
                        //            error = "ERROR: Algunos Clientes no se encontraron.";//mostrarmensaje("error", "ERROR: Cliente no encontrado.");
                        //        }
                        //    }
                        //}
                        //if(resp){
                        //    mostrarmensaje("error", "ERROR: Debe elegir el cliente.");
                        //    this.PanelAgregarEvento_Modalpopupextender2.Show();
                        //}
                                               
                //    }else
                //        {
                //            mostrarmensaje("error", "ERROR: Debe elegir el cliente.");
                //            this.PanelAgregarEvento_Modalpopupextender2.Show();
                //        }
                //}
            if(error!="")
            {
                mostrarmensaje("error", error);
            }
            txtDescripciónAdd.Text = string.Empty;
            dropSolicitudAdd.SelectedIndex = 0;
            dropProyectosAdd.SelectedIndex = 0;
            //dropCliente.SelectedIndex = 0;
            //cblClientes.Items.Clear();
            //radUnico.Checked = true;
            //radMultiple.Checked = false;
            gvCargarTickets();
            string open = "cambiarClientes();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);*/
#endregion
    }
    protected bool evaluarEscalar(object escalar) 
    {
        if (escalar.ToString() == "")
        {
            return true;
        }
        return false;
    }
    protected void imgEscalar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string cod = GridTickets.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        if (ddCoordinador(cmbCoordinadores, cod)) { 
        lblTicket.Text = cod;
        PanelEscalar_ModalPopupExtender1.Show();
        }
    }
    protected void btnEscalarC_Click(object sender, EventArgs e)
    {
        string codUsuRolCor=cmbCoordinadores.SelectedValue;
        string codusuRol = lblCodUsuarioRol.Text;
        string codTicket = lblTicket.Text;
        
        if (tic.agregarEscala(codusuRol, codTicket, codUsuRolCor))
        {
                lblTicket.Text = string.Empty;
                enviarCorreoTickedEscalar(codTicket,codUsuRolCor);
                gvCargarTickets();
                mostrarmensaje("exito", "Agregado Correctamente");
                int time = 1;
                Response.AppendHeader("Refresh", time + "; Url=ticmonitor.aspx");
        }
        else
        {
            mostrarmensaje("error", "ERROR: Debe elegir el cliente.");
            PanelEscalar_ModalPopupExtender1.Show();
        }

    }
    protected void GridTickets_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string hexret = "#e8a7ab";
        string hexres = "#b4cc38";
        Color _colorret = System.Drawing.ColorTranslator.FromHtml(hexret);
        Color _colorres = System.Drawing.ColorTranslator.FromHtml(hexres);
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string tipo;
            tipo = DataBinder.Eval(e.Row.DataItem, "estado").ToString();
            if (tipo == "Retrasado")
            {
                e.Row.Cells[12].BackColor = _colorret;
            }
            if (tipo == "Resuelto")
            {

                e.Row.Cells[12].BackColor = _colorres;
                GridTickets.Columns[19].Visible = false;
                //GridTickets.Columns[22].Visible = false;
            }
        }
    }
    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        Page page = new Page();
        HtmlForm form = new HtmlForm();

        GridTickets.EnableViewState = false;

        GridTickets.Columns[0].Visible = false;

        GridTickets.Columns[13].Visible = true;
        GridTickets.Columns[14].Visible = true;

        GridTickets.Columns[3].Visible = false;
        GridTickets.Columns[7].Visible = false;
        GridTickets.Columns[10].Visible = false;

        GridTickets.Columns[19].Visible = false;
        GridTickets.Columns[20].Visible = false;
        GridTickets.Columns[21].Visible = false;
        GridTickets.Columns[22].Visible = false;
        
        // Deshabilitar la validación de eventos, sólo asp.net 2
        page.EnableEventValidation = false;

        // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
        page.DesignerInitialize();

        page.Controls.Add(form);
        form.Controls.Add(GridTickets);

        page.RenderControl(htw);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=ExportTickets" + DateTime.Now.ToShortTimeString() + ".xls");
        Response.Charset = "UTF-8";
        Response.ContentEncoding = Encoding.Default;
        Response.Write(sb.ToString());
        Response.End();

         }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }
    protected void UpdatePanel3_Load(object sender, EventArgs e)
    {
        if (ScriptManager1.IsInAsyncPostBack)
        {
            updatePanel();
        }
    }

    private void updatePanel() 
    {
        gvCargarTicketsSinResuelto();
    }
    protected void GridImplicados_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ((DataTable)Session["myDatatableImplicados"]).Rows[e.RowIndex].Delete();
        mostrarmensaje("exito", "Eliminado correctamente");
        gvCargarImplicados();
    }
    protected void btnAddClientes_Click(object sender, EventArgs e)
    {
       // if (dropCliente.SelectedIndex > 0)
       // {
            AddDataToTableImplicados(dropCliente.SelectedValue, dropCliente.SelectedItem.Text, (DataTable)Session["myDatatableImplicados"]);
            gvCargarImplicados();
       // }
    }
    private void gvCargarImplicados()
    {
        GridImplicados.DataSource = (DataTable)Session["myDatatableImplicados"];
        GridImplicados.DataBind();
    
    }

    protected void imgEliminar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string cod = GridTickets.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  

        eliminarTicket(cod);

    }

    private void eliminarTicket(string codincidencia)
    {
        Tickets tic = new Tickets();

        if(tic.eliminarEscala(codincidencia))
        {
            //Buscar el archivo en la tabla evidencia y borrar el/los archivo(s) que se almacena(n)

            //DataTable pic = tic.buscarEvidenciaFotos(codincidencia);

            //if (pic != null && pic.Rows.Count > 0)
            //{
            //    for (int i = 0; i < pic.Rows.Count; i++)
            //    {
            //        if (System.IO.File.Exists(@"C:\Users\Public\DeleteTest\test.txt"))
            //        {
            //            try
            //            {
            //                System.IO.File.Delete(@"C:\Users\Public\DeleteTest\test.txt");
            //            }
            //            catch (System.IO.IOException e)
            //            {
            //                Console.WriteLine(e.Message);
            //                return;
            //            }
            //        }
            //    }
            //}

            if(tic.eliminarEvidencia(codincidencia))
            {
                if(tic.eliminarSeguimiento(codincidencia))
                {
                    if (tic.eliminarTimeOff(codincidencia))
                    {
                        if (tic.eliminarIncidencia(codincidencia))
                        {
                            gvCargarTicketsSinResuelto();
                            mostrarmensaje("exito", "Operación realizada con éxito.");
                        }
                    }
                }
            }

        }
 
    }

    protected void imgEditar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string cod = GridTickets.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string codsolicitud = HttpUtility.HtmlDecode(gvrow.Cells[10].Text);
        string txtDescripcion = HttpUtility.HtmlDecode(gvrow.Cells[15].Text);
        string codproyecto = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
        string codclisede = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);

        dropSolicitudAdd.SelectedValue = codsolicitud;
        txtDescripciónAdd.Text = txtDescripcion;
        dropProyectosAdd.SelectedValue = codproyecto;
        dropCliente.SelectedValue = codclisede;

        btnAddTickets.Visible = false;
        btnEditarTickets.Visible = true;

        editarTicket(cod);
        this.PanelAgregarEvento_Modalpopupextender2.Show();
    }

    private void editarTicket(string codindidencia)
    {
        
        
        Tickets tic = new Tickets();
        
    }


}