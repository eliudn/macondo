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

public partial class actmonitor : System.Web.UI.Page
{
    Actividad act = new Actividad();
    Funciones fun = new Funciones();
    Usuario user = new Usuario();
    Proyecto pro = new Proyecto();
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
            lblCodUsuarioRol.Text = Session["codusuariorol"].ToString();
            lblCodUsuario.Text = Session["codusuario"].ToString();
            lblTipoUsuario.Text = Session["codrol"].ToString();
            //GridActividades.PageSize = 30;
            cargarEventosParaMiListaSinResuelto(lblTipoUsuario.Text,false);
            ddEstados(dropEstadoLista);

            cargarDrops();

            //if (lblOperacion.Text == "v")
            //{
            //    dropProyectoLista.SelectedValue = lblCodProyecto.Text;
            //    dropEstadoLista.SelectedValue = lblCodEstado.Text;
                      
            //   // lblValidador.Text = "true";

            //}
            cerrarSessiones();

        }
    }
    private void cargarDrops()
    {
        ddEstados(dropEstadoLista);
        ddProyectos(dropProyectoLista,false);
    }
    private void ddProyectos(DropDownList drop, bool add)
    {
        DataTable datosProyectos = pro.cargarProyectos();
        drop.DataSource = datosProyectos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        if (add)
            drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
        else
            drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos"));
    }
    public void obtenerGETOriginal()
    {
        if (Session["o"] == null)
        {
            Session["ca"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["ca"]);//CodActividad
            Session["cp"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["cp"]);//CodProyecto
            Session["ce"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["ce"]);//CodEstado
            lblOperacion.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["o"]);//Operacion;

            if (lblOperacion.Text != "")
            {
                Session["o"] = lblOperacion.Text;
                Response.Redirect("actmonitor.aspx");
            }

            // Response.Redirect("ticdetalle.aspx");

        }
    }
    public void obtenerSessionOriginal()
    {
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
    private void ddEstados(DropDownList drop)
    {
        DataTable datosProyectos = act.cargarEstados();
        drop.DataSource = datosProyectos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos"));
    }
   
    protected void btnFiltrarLista_Click(object sender, EventArgs e)
    {
        cargarEventosParaMiLista(lblTipoUsuario.Text, false);
        if (dropProyectoLista.SelectedIndex > 0)
            lblCodProyecto.Text = dropProyectoLista.SelectedValue;
        if (dropEstadoLista.SelectedIndex > 0)
            lblCodEstado.Text = dropEstadoLista.SelectedValue;
    }
    protected void GridActividades_Sorting(object sender, GridViewSortEventArgs e)
    {
        ordenar2Sorting(e, GridActividades);
        cargarEventosParaMiLista(lblTipoUsuario.Text, true);
    }
    protected void GridActividades_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridActividades.PageIndex = e.NewPageIndex;
        cargarEventosParaMiLista(lblTipoUsuario.Text, true);
    }
    protected void imgVer_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codactivity = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);// Codigo de la actividad
        Server.Transfer("actdetalle.aspx?ca=" + codactivity + "&cp=" + lblCodProyecto.Text + "&ce=" + lblCodEstado.Text, true);
        //Response.Redirect("actdetalle.aspx?ca=" + codactivity + "&cp=" + lblCodProyecto.Text + "&ce=" + lblCodEstado.Text, true);
    }
    private void cargarEventosParaMiLista(string codtipousuario, bool filtro)
    {
        switch (codtipousuario)
        {
            case "1": //administrador           
                DataTable datosEventosA = act.cargarActividadesAgendadas(llenarWhereLista(codtipousuario, lblCodUsuarioRol.Text));
                if (datosEventosA != null && datosEventosA.Rows.Count > 0)
                {
                    //if (!filtro)
                    //{
                    //    ddProyectoFiltro(dropProyectoLista, datosEventosA);
                    //}
                    GridActividades.DataSource = datosEventosA;
                    GridActividades.DataBind();
                    GridActividades.UseAccessibleHeader = true;
                    if (GridActividades.HeaderRow != null)
                    {
                        GridActividades.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    if (GridActividades.ShowFooter)
                        GridActividades.FooterRow.TableSection = TableRowSection.TableFooter;

                   // lblNroRegistros.Text = "<b>Nro. Registros:</b>"+GridActividades.Rows.Count+"";
                   
                }
                else
                {
                   // lblNroRegistros.Text = "<b>Nro. Registros:</b>"+0;
                    GridActividades.DataBind();//Para Vaciarlo
                }
                break;
            case "3": //Agente           
                DataTable datosEventosAg = act.cargarActividadesAgendadas(llenarWhereLista(codtipousuario, lblCodUsuarioRol.Text));
                if (datosEventosAg != null && datosEventosAg.Rows.Count > 0)
                {
                    //if (!filtro)
                    //{
                    //    ddProyectoFiltro(dropProyectoLista, datosEventosAg);
                    //}
                    GridActividades.DataSource = datosEventosAg;
                    GridActividades.DataBind();

                    GridActividades.UseAccessibleHeader = true;
                    if (GridActividades.HeaderRow != null)
                    {
                        GridActividades.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    if (GridActividades.ShowFooter)
                        GridActividades.FooterRow.TableSection = TableRowSection.TableFooter;

                  //  lblNroRegistros.Text = "<b>Nro. Registros:</b>" + GridActividades.Rows.Count + "";

                }
                else
                {
                  //  lblNroRegistros.Text = "<b>Nro. Registros:</b>" + 0;
                    GridActividades.DataBind();//Para Vaciarlo
                }
                break;
            case "2"://Coordinador
                DataTable datosEventosE = act.cargarActividadesAgendadasxCoordinador(llenarWhereLista(codtipousuario, lblCodUsuarioRol.Text));
                if (datosEventosE != null && datosEventosE.Rows.Count > 0)
                {
                    //if (!filtro)
                    //{
                    //    ddProyectoFiltro(dropProyectoLista, datosEventosE);
                    //}
                    GridActividades.DataSource = datosEventosE;
                    GridActividades.DataBind();

                    GridActividades.UseAccessibleHeader = true;
                    if (GridActividades.HeaderRow != null)
                    {
                        GridActividades.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    if (GridActividades.ShowFooter)
                        GridActividades.FooterRow.TableSection = TableRowSection.TableFooter;

                   // lblNroRegistros.Text = "<b>Nro. Registros:</b>" + GridActividades.Rows.Count + "";
                }
                else
                {
                  //  lblNroRegistros.Text = "<b>Nro. Registros:</b>" + 0;
                    GridActividades.DataBind();//Para Vaciarlo
                }

                break;
            case "5": //Tecnico
                DataTable datosEventosD = act.cargarActividadesAgendadasxTecnico(llenarWhereLista(codtipousuario, lblCodUsuarioRol.Text));
                if (datosEventosD != null && datosEventosD.Rows.Count > 0)
                {
                    //if (!filtro)
                    //{
                    //    ddProyectoFiltro(dropProyectoLista, datosEventosD);
                    //}
                    GridActividades.DataSource = datosEventosD;
                    GridActividades.DataBind();

                    GridActividades.UseAccessibleHeader = true;
                    if (GridActividades.HeaderRow != null)
                    {
                        GridActividades.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    if (GridActividades.ShowFooter)
                        GridActividades.FooterRow.TableSection = TableRowSection.TableFooter;

                  //  lblNroRegistros.Text = "<b>Nro. Registros:</b>" + GridActividades.Rows.Count + "";
                }
                else
                {
                  //  lblNroRegistros.Text = "<b>Nro. Registros:</b>" + 0;
                    GridActividades.DataBind();//Para Vaciarlo
                }
                break;

            default:
                mostrarmensaje("error", "ERROR: Tipo de usuario no encontrado para mi lista " + codtipousuario);
                lblNroRegistros.Text = "ERROR: Tipo de usuario no encontrado para mi lista " + codtipousuario;
                GridActividades.Visible = false;
                break;
        }
    }
    private void cargarEventosParaMiListaSinResuelto(string codtipousuario, bool filtro)
    {
        switch (codtipousuario)
        {
            case "1": //administrador           
                DataTable datosEventosA = act.cargarActividadesAgendadasSinResuelto(llenarWhereLista(codtipousuario, lblCodUsuarioRol.Text));
                if (datosEventosA != null && datosEventosA.Rows.Count > 0)
                {
                    //if (!filtro)
                    //{
                    //    ddProyectoFiltro(dropProyectoLista, datosEventosA);
                    //}
                    GridActividades.DataSource = datosEventosA;
                    GridActividades.DataBind();
                    GridActividades.UseAccessibleHeader = true;
                    if (GridActividades.HeaderRow != null)
                    {
                        GridActividades.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    if (GridActividades.ShowFooter)
                        GridActividades.FooterRow.TableSection = TableRowSection.TableFooter;

                  //  lblNroRegistros.Text = "<b>Nro. Registros:</b>" + GridActividades.Rows.Count + "";

                }
                else
                {
                   // lblNroRegistros.Text = "<b>Nro. Registros:</b>" + 0;
                    GridActividades.DataBind();//Para Vaciarlo
                }
                break;
            case "3": //Agente           
                DataTable datosEventosAg = act.cargarActividadesAgendadasSinResuelto(llenarWhereLista(codtipousuario, lblCodUsuarioRol.Text));
                if (datosEventosAg != null && datosEventosAg.Rows.Count > 0)
                {
                    //if (!filtro)
                    //{
                    //    ddProyectoFiltro(dropProyectoLista, datosEventosAg);
                    //}
                    GridActividades.DataSource = datosEventosAg;
                    GridActividades.DataBind();

                    GridActividades.UseAccessibleHeader = true;
                    if (GridActividades.HeaderRow != null)
                    {
                        GridActividades.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    if (GridActividades.ShowFooter)
                        GridActividades.FooterRow.TableSection = TableRowSection.TableFooter;

                   // lblNroRegistros.Text = "<b>Nro. Registros:</b>" + GridActividades.Rows.Count + "";

                }
                else
                {
                  //  lblNroRegistros.Text = "<b>Nro. Registros:</b>" + 0;
                    GridActividades.DataBind();//Para Vaciarlo
                }
                break;
            case "2"://Coordinador
                DataTable datosEventosE = act.cargarActividadesAgendadasxCoordinadorSinResuelto(llenarWhereLista(codtipousuario, lblCodUsuarioRol.Text));
                if (datosEventosE != null && datosEventosE.Rows.Count > 0)
                {
                    //if (!filtro)
                    //{
                    //    ddProyectoFiltro(dropProyectoLista, datosEventosE);
                    //}
                    GridActividades.DataSource = datosEventosE;
                    GridActividades.DataBind();

                    GridActividades.UseAccessibleHeader = true;
                    if (GridActividades.HeaderRow != null)
                    {
                        GridActividades.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    if (GridActividades.ShowFooter)
                        GridActividades.FooterRow.TableSection = TableRowSection.TableFooter;

                  //  lblNroRegistros.Text = "<b>Nro. Registros:</b>" + GridActividades.Rows.Count + "";
                }
                else
                {
                 //   lblNroRegistros.Text = "<b>Nro. Registros:</b>" + 0;
                    GridActividades.DataBind();//Para Vaciarlo
                }

                break;
            case "5": //Tecnico
                DataTable datosEventosD = act.cargarActividadesAgendadasxTecnicoSinResuelto(llenarWhereLista(codtipousuario, lblCodUsuarioRol.Text));
                if (datosEventosD != null && datosEventosD.Rows.Count > 0)
                {
                    //if (!filtro)
                    //{
                    //    ddProyectoFiltro(dropProyectoLista, datosEventosD);
                    //}
                    GridActividades.DataSource = datosEventosD;
                    GridActividades.DataBind();

                    GridActividades.UseAccessibleHeader = true;
                    if (GridActividades.HeaderRow != null)
                    {
                        GridActividades.HeaderRow.TableSection = TableRowSection.TableHeader;
                    }
                    if (GridActividades.ShowFooter)
                        GridActividades.FooterRow.TableSection = TableRowSection.TableFooter;

                 //   lblNroRegistros.Text = "<b>Nro. Registros:</b>" + GridActividades.Rows.Count + "";
                }
                else
                {
                 //   lblNroRegistros.Text = "<b>Nro. Registros:</b>" + 0;
                    GridActividades.DataBind();//Para Vaciarlo
                }
                break;

            default:
                mostrarmensaje("error", "ERROR: Tipo de usuario no encontrado para mi lista " + codtipousuario);
                lblNroRegistros.Text = "ERROR: Tipo de usuario no encontrado para mi lista " + codtipousuario;
                GridActividades.Visible = false;
                break;
        }
    }
    private void ddProyectoFiltro(DropDownList drop, DataTable datos)
    {
        drop.DataSource = depuararTabla(datos);
        drop.DataTextField = "proyecto";
        drop.DataValueField = "codproyecto";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos"));
    }
    /// <summary>
    /// Saca los proyectos repetidos en el datatable.
    /// </summary>
    /// <param name="datosEventos"></param>
    /// <returns></returns>
    private DataTable depuararTabla(DataTable datosEventos)
    {
        DataTable dtCodProyectos = new DataTable();
        dtCodProyectos.Columns.AddRange(new DataColumn[2] { new DataColumn("codproyecto"), new DataColumn("proyecto") });
        string[] categorias = new string[datosEventos.Rows.Count];
        int sumar = 0;
        for (int i = 0; i < datosEventos.Rows.Count; i++)
        {
            if (i == 0)
            {
                dtCodProyectos.Rows.Add(datosEventos.Rows[i]["codproyecto"].ToString(), datosEventos.Rows[i]["proyecto"].ToString());
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
        return dtCodProyectos;
    }
    private string llenarWhereLista(string tipousuario, string codusuariorol)
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
            cond[3] = "a.codusuariorol='" + codusuariorol + "'";
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
    private void ordenar2Sorting(GridViewSortEventArgs e, GridView grid)
    {
        if (ViewState["SortDirection"] == null || ViewState["SortExpression"].ToString() != e.SortExpression)
        {
            ViewState["SortDirection"] = "ASC";
            grid.PageIndex = 0;
        }
        else if (ViewState["SortDirection"].ToString() == "ASC")
        {
            ViewState["SortDirection"] = "DESC";
        }
        else if (ViewState["SortDirection"].ToString() == "DESC")
        {
            ViewState["SortDirection"] = "ASC";
        }
        ViewState["SortExpression"] = e.SortExpression;
    }
    protected void GridActividades_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string hexret = "#e8a7ab";
        string hexres = "#b4cc38";
        Color _colorret = System.Drawing.ColorTranslator.FromHtml(hexret);
        Color _colorres = System.Drawing.ColorTranslator.FromHtml(hexres);
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string tipo;
            tipo = DataBinder.Eval(e.Row.DataItem, "nombre").ToString();
            if (tipo == "Retrasado")
            {
                e.Row.Cells[6].BackColor = _colorret;
            }
            if (tipo == "Resuelto")
            {
                e.Row.Cells[6].BackColor = _colorres;
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

        GridActividades.EnableViewState = false;

        GridActividades.Columns[0].Visible = false;
        GridActividades.Columns[11].Visible = false;

       
        // Deshabilitar la validación de eventos, sólo asp.net 2
        page.EnableEventValidation = false;

        // Realiza las inicializaciones de la instancia de la clase Page que requieran los diseñadores RAD.
        page.DesignerInitialize();

        page.Controls.Add(form);
        form.Controls.Add(GridActividades);

        page.RenderControl(htw);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=ExportActividades" + DateTime.Now.ToShortTimeString() + ".xls");
        Response.Charset = "UTF-8";
        Response.ContentEncoding = Encoding.Default;
        Response.Write(sb.ToString());
        Response.End();

    }

    protected void imgCorreo_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string cod = GridActividades.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        //string codusuariorol = HttpUtility.HtmlDecode(gvrow.Cells[7].Text);

        //enviarCorreoActividad(cod, codusuariorol);
        enviarCorreoActividad(cod);
    }
    private void enviarCorreoActividad(string codactividad)
    //    private void enviarCorreoActividad(string codactividad, string codUsuario)
    {
        bool envio1 = false;
        Email ema = new Email();
        Actividad tic = new Actividad();
        //Envio de correos.

        //string mensaje = tic.armarCuerpoDelMensajeActividad(codUsuario, codactividad, 2);
        string mensaje = tic.armarCuerpoDelMensajeActividad(codactividad, 2);
        //string email2 = tic.buscarReceptor();
        string email = "";
        //email = tic.getEmailUsuarioCoord(codUsuario);
        DataRow datorec = ema.buscarRemitente("3");//tipo Receptor


        string receptor = "";
        if (datorec != null)
        {
            receptor = datorec["email"].ToString();
        }

        if (email != "" && fun.email_bien_escrito(email))
        {
            envio1 = tic.enviarMensajeporcorreo(mensaje, email, codactividad);//Mensaje al coordinador.
        }


        if (envio1)
        {
            mostrarmensaje("exito", "Actividad Agregada Correctamente");
        }
        else if (!envio1)
        {
            mostrarmensaje("exito", "Actividad Agregada Correctamente: Error enviando correo a Cliente");
        }
    }
}