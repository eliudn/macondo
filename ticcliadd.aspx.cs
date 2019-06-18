using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ticcliadd : System.Web.UI.Page
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
            lblCodUsuarioRol.Text = Session["codusuariorol"].ToString();
            lblCodUsuario.Text = Session["codusuario"].ToString();
            lblTipoUsuario.Text = Session["codrol"].ToString();
            cargarDrops();
        }
    }

    private void cargarDrops()
    {
        ddSolicitudes(dropSolicitudAdd);
        ddProyectos(dropProyectosAdd);
    }

    private void ddProyectos(DropDownList drop)
    {
        DataTable datosProyectos = pro.cargarProyectosDeUsuario(lblCodUsuario.Text);
        drop.DataSource = datosProyectos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddSolicitudes(DropDownList drop)
    {
        DataTable datosSolicitudes = cli.cargarSolicitudes();
        drop.DataSource = datosSolicitudes;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
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
            ddAClientesxProyecto(dropCliente);
            //ddAClientesxProyecto(dropCliente, dropProyectosAdd.SelectedValue);
        }
    }
    //private void ddAClientesxProyecto(DropDownList drop, string codproyecto)
    private void ddAClientesxProyecto(DropDownList drop)
    {
        //drop.DataSource = pro.cargarClienteInProyecto(codproyecto;
        drop.DataSource = pro.cargarClienteInProyectoDeUsuario(lblCodUsuario.Text);
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    protected void btnAddTickets_Click(object sender, EventArgs e)
    {
        string email = "";
        DataRow dat = tic.CargarTicketAbiertoxCliente(dropCliente.SelectedValue);
        if (dat == null)
        {
            if (dropCliente.SelectedIndex > 0)
            {
                long cod = tic.agregarTickets(lblCodUsuarioRol.Text, dropSolicitudAdd.SelectedValue, txtDescripcionAdd.Text, "1", dropProyectosAdd.SelectedValue, dropCliente.SelectedValue);
                if (cod != -1)
                {
                    txtDescripcionAdd.Text = string.Empty;
                    dropSolicitudAdd.SelectedIndex = 0;
                    dropProyectosAdd.SelectedIndex = 0;
                    dropCliente.SelectedIndex = 0;
                    string mensaje = tic.armarCuerpoDelMensaje(lblCodUsuario.Text, cod.ToString(), 1);
                    email = tic.getEmailUsuario(lblCodUsuario.Text);
                    string mensaje2 = tic.armarCuerpoDelMensaje(lblCodUsuario.Text, cod.ToString(), 2);
                    //string email2 = tic.buscarReceptor();
                    string receptor = "";
                    Email ema = new Email();
                    DataRow datorec = ema.buscarRemitente("2");//tipo Receptor
                    if (datorec != null)
                    {
                        receptor = datorec["email"].ToString();
                    }
                    if (email != "" && fun.email_bien_escrito(email))
                    {
                        tic.enviarMensajeporcorreo(mensaje, email, cod.ToString());
                        tic.enviarMensajeporcorreo(mensaje2, receptor, cod.ToString());
                        mostrarmensaje("exito", "Agregado Correctamente");
                    }
                    else
                    {
                        tic.enviarMensajeporcorreo(mensaje2, receptor, cod.ToString());
                        mostrarmensaje("exito", "Agregado Correctamente, Pero debe configurar su email en Mi Perfil");
                    }
                }
            }
            else
            {
                mostrarmensaje("error", "ERROR: Debe elegir el cliente.");
            }
        }
        else
        {
            mostrarmensaje("error", "Ya cuenta con un Ticket abierto.");
        }
    }
}