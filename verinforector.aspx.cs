using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class verinforector : System.Web.UI.Page
{
    Cliente client = new Cliente();
    Usuario user = new Usuario();
    Localidad local = new Localidad();
    Equipo equ = new Equipo();
    Proyecto pro = new Proyecto();

    Institucion inst = new Institucion();

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
            obtenerGET();
            lblCodUsuarioRol.Text = Session["codusuariorol"].ToString();

            if (lblIDRector.Text != string.Empty)
            {
                buscarRector(lblIDRector.Text);
            }
            else
            {
                mostrarmensaje("error", "ERROR: No se recibieron los parametros");
            }
        }
       
    }
    private void obtenerGET()
    {
        try
        {
            lblIDRector.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["id"]);
            lblCodSede.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["cc"]);       
        }
        catch
        {
            throw new HttpException(500, "Error Interno");
        }
    }
    private void buscarRector(string codcliente)
    {
        string ca = "";
        DataRow rector = inst.buscarDatosRector(lblIDRector.Text);
        if (rector != null)
        {
            ca = "<table class='mGridTesoreria'><thead><tr><th>Identificación</th>";
            ca += "<th>Nombre</th>";
            ca += "<th>Apellido</th>";
            ca += "<th>Teléfono</th>";
            ca += "<th>Celular</th>";
            ca += "<th>Email</th></tr></thead>";

            ca += "<tbody>";
            ca += "<tr><td>" + rector["identificacion"].ToString() + "</td>";
            ca += "<td>" + rector["nombre"].ToString() + "</td>";
            ca += "<td>" + rector["apellido"].ToString() + "</td>";
            ca += "<td>" + rector["telefono"].ToString() + "</td>";
            ca += "<td>" + rector["celular"].ToString() + "</td>";
            ca += "<td>" + rector["email"].ToString() + "</td></tr>";
            ca += "</tbody>";
            ca += "</table>";
        }
        else
        {
            ca = "<tr><td colspan='6'>No existen datos para esta institución.</td></tr>";
        }
        lblDatosRector.Text = ca;
    }
    private void ddSolicitudes(DropDownList drop, bool add)
    {
        Cliente cli = new Cliente();
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
}