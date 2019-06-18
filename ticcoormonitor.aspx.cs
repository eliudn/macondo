using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ticcoormonitor : System.Web.UI.Page
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
            PanelAgregarTickets.Attributes.Add("style", "display:none");
            PanelEscalar.Attributes.Add("style", "display:none");
            lblCodUsuarioRol.Text = Session["codusuariorol"].ToString();
            lblCodUsuario.Text = Session["codusuario"].ToString();
            lblTipoUsuario.Text = Session["codrol"].ToString();
            GridTickets.PageSize = 30;
            cargarDrops();
            gvCargarTickets();
        }
    }
    private void cargarDrops()
    {
        ddEstados(dropEstadoLista);
        ddSolicitudes(dropSolicitudLista, false);
        ddSolicitudes(dropSolicitudAdd, true);
        ddPrioridad(dropPrioridadLista);
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
    private void ddEstados(DropDownList drop)
    {
        DataTable datosEstados = act.cargarEstados();
        drop.DataSource = datosEstados;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos"));
    }
    private void ddCoordinador(DropDownList drop, string codigo)
    {
        DataTable datosCoordinador = tic.cargarCoordinadoresDeTicket(codigo);
        drop.DataSource = datosCoordinador;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        //drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Todos"));
    }
    private void ddSolicitudes(DropDownList drop, bool add)
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
    protected void GridTickets_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void GridTickets_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
    private void gvCargarTickets()
    {
        GridTickets.DataSource = tic.cargarTicketsCooriAgent(llenarWhereLista());
        GridTickets.DataBind();
        if (GridTickets.Rows.Count > 0)
        {
            if (GridTickets.Rows.Count == 1)
            {
                lblNroRegistros.Text = "<b>Se encontró un registro.</b>";
            }
            else
            {
                lblNroRegistros.Text = "<b>Se encontraron " + GridTickets.Rows.Count + " registros.</b>";
            }
        }
        else
        {
            lblNroRegistros.Text = "<b>No se encontraron registros.</b>";
        }
    }
    private string llenarWhereLista()
    {
        int numero = 6;
        string[] cond;
        cond = new string[numero];

        cond[0] = string.Empty;  //codproyecto
        cond[1] = string.Empty;  //estado
        cond[2] = string.Empty;  //fechas
        cond[3] = string.Empty; // Prioridad
        cond[4] = string.Empty; // Solicitud
        cond[5] = " esc.codusuariorolcor='"+lblCodUsuarioRol.Text+"'"; // Solicitud

        if (dropEstadoLista.SelectedIndex > 0)
        {
            cond[1] = "  i.`codestado`='" + dropEstadoLista.SelectedValue + "'";
        }

        if (txtFechaIniFiltro.Text != string.Empty && txtFechaFinFiltro.Text != string.Empty)
        {
            cond[2] = "DATE_FORMAT(i.`startday`,'%Y-%m-%d') BETWEEN DATE_FORMAT('" + fun.convertFechaAño(txtFechaIniFiltro.Text) + "','%Y-%m-%d') AND DATE_FORMAT('" + fun.convertFechaAño(txtFechaFinFiltro.Text) + "','%Y-%m-%d')";
        }
        else if (txtFechaIniFiltro.Text != string.Empty)
        {
            cond[2] = "DATE_FORMAT(i.`startday`,'%Y-%m-%d') >= DATE_FORMAT('" + fun.convertFechaAño(txtFechaIniFiltro.Text) + "','%Y-%m-%d')";

        }
        else if (txtFechaFinFiltro.Text != string.Empty)
        {
            cond[2] = "DATE_FORMAT(i.`startday`,'%Y-%m-%d') <= DATE_FORMAT('" + fun.convertFechaAño(txtFechaFinFiltro.Text) + "','%Y-%m-%d')";
        }

        if (dropPrioridadLista.SelectedIndex > 0)
        {
            cond[3] = "pri.`cod`='" + dropPrioridadLista.SelectedValue + "'";
        }

        if (dropSolicitudLista.SelectedIndex > 0)
        {
            cond[4] = " i.`codsolicitud`='" + dropSolicitudLista.SelectedValue + "'";
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
    protected void imgVer_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string codactivity = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);// Codigo de la actividad
        Session["anterior"] = "ticcoormonitor.aspx";
        Response.Redirect("ticdetalle.aspx?ct=" + codactivity, true);
    }
    protected void btnFiltrarLista_Click(object sender, EventArgs e)
    {
        gvCargarTickets();
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
    }
    protected void dropProyectosAdd_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropProyectosAdd.SelectedIndex > 0)
        {
            ddAClientesxProyecto(dropCliente, dropProyectosAdd.SelectedValue);
        }
    }
    private void ddAClientesxProyecto(DropDownList drop, string codproyecto)
    {
        drop.DataSource = pro.cargarClienteInProyecto(codproyecto);
        drop.DataTextField = "nombrenit";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    protected void btnAddTickets_Click(object sender, EventArgs e)
    {
        if (dropCliente.SelectedIndex > 0)
        {
            long id = tic.agregarTickets(lblCodUsuarioRol.Text, dropSolicitudAdd.SelectedValue, txtDescripciónAdd.Text, "1", dropProyectosAdd.SelectedValue, dropCliente.SelectedValue);
            if (id != -1)
            {
                txtDescripciónAdd.Text = string.Empty;
                dropSolicitudAdd.SelectedIndex = 0;
                dropProyectosAdd.SelectedIndex = 0;
                dropCliente.SelectedIndex = 0;
                gvCargarTickets();
                string mensaje = tic.armarCuerpoDelMensaje(lblCodUsuario.Text, id.ToString(), 1);
                string mensaje2 = tic.armarCuerpoDelMensaje(lblCodUsuario.Text, id.ToString(), 2);
                string email = tic.getEmailUsuario(lblCodUsuario.Text);
                //string email2 = tic.buscarReceptor();
                string receptor = "";
                Email ema = new Email();
                DataRow datorec = ema.buscarRemitente("2");//tipo Receptor
                if (datorec != null)
                {
                    receptor = datorec["email"].ToString();
                }
                tic.enviarMensajeporcorreo(mensaje, email, id.ToString());
                tic.enviarMensajeporcorreo(mensaje2, receptor, id.ToString());
                mostrarmensaje("exito", "Agregado Correctamente");
            }
        }
        else
        {
            mostrarmensaje("error", "ERROR: Debe elegir el cliente.");
            this.PanelAgregarEvento_Modalpopupextender2.Show();
        }
    }
    protected bool evaluarEscalar(object escalar)
    {
      if(tic.validarAsignacionesTecnicos(lblCodUsuarioRol.Text, escalar.ToString())==null)
            return true;
       return false;
    }
    protected void imgEscalar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string cod = GridTickets.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string codProyecto = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);

        cblTecnicos.DataSource = user.cargarTecnicosxCoordinadorxProyecto(lblCodUsuario.Text, codProyecto );
        cblTecnicos.DataTextField = "nombre";
        cblTecnicos.DataValueField = "cod";
        cblTecnicos.DataBind();
        
        lblTicket.Text = cod;
        PanelEscalar_ModalPopupExtender1.Show();
    }
    protected void btnEscalarC_Click(object sender, EventArgs e)
    {
        if (validarTecnico(cblTecnicos)) 
        {
            string codusuRol = lblCodUsuarioRol.Text;
            string codTicket = lblTicket.Text;
            relacionarTecnicos(codusuRol, codTicket, cblTecnicos);
            lblTicket.Text = string.Empty;
            gvCargarTickets();
            mostrarmensaje("exito", "Tecnicos Agregados Correctamente");
        }
        else
        {
            mostrarmensaje("error", "ERROR: Debe elegir el cliente.");
            PanelEscalar_ModalPopupExtender1.Show();
        }
    }
    private void relacionarTecnicos(string codUsuRol, string codTick, CheckBoxList combo)
    {
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                tic.agregarAsignacionesTecnicos(codUsuRol, codTick, combo.Items[i].Value);
            }
        }
    }
    private bool validarTecnico(CheckBoxList combo)
    {
        bool eligio = false;
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                eligio = true;
            }
        }
        return eligio;
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
            }
        }
    }
}