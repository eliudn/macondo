using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class docenteedit : System.Web.UI.Page
{
    Usuario user = new Usuario();
    Funciones fun = new Funciones();
    Institucion ins = new Institucion();

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
    private void ocultarPaneles()
    {
        
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        mensaje.Attributes.Add("style", "display:none");

        if (!IsPostBack)
        {
            ocultarPaneles();
            obtenerGET();

           

            if (lblCodCliente.Text != string.Empty)
            {
                if (Session["codrol"].ToString() == "1")
                {
                    ddTipoDocumento(dropTipoDocumento);
                    buscarCliente(lblCodCliente.Text);
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
            else
            {
                mostrarmensaje("error", "ERROR: No se recibieron los parametros");
                txtidentificacion.Enabled = false;
                txtNombre.Enabled = false;
                txtApellido.Enabled = false;
                dropTipoDocumento.Enabled = false;
                dropSexo.Enabled = false;
                txtFechaIni.Enabled = false;
                txtTelefono.Enabled = false;
                txtDireccion.Enabled = false;
                txtEmail.Enabled = false;
            }
        }
       
    }
    private void obtenerGET()
    {
        try
        {
            lblCodCliente.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["cod"]);
            lblCodDANE.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["cd"]);
            lblCC.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["cc"]); 
        }
        catch
        {
            throw new HttpException(500, "Error Interno");
        }
    }
    private void buscarCliente(string codcliente)
    {
        llenarDatos(ins.buscarDocenteCompleto(codcliente));
    }
    private void ddZonas(DropDownList drop)
    {
        Institucion cli = new Institucion();
        DataTable datosSolicitudes = cli.cargarZonas();
        drop.DataSource = datosSolicitudes;
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
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
    
    private void llenarDatos(DataRow datoDocente)
    {
        if (datoDocente != null)
        {
            lblCodCliente.Text = datoDocente["codigo"].ToString();
            txtidentificacion.Text = datoDocente["identificacion"].ToString();
            txtidentificacion.Enabled = false;
            dropTipoDocumento.SelectedValue = datoDocente["codtipodocumento"].ToString(); 
            dropSexo.SelectedValue = datoDocente["sexo"].ToString(); 
            
            txtNombre.Text = datoDocente["nombre"].ToString();
            txtApellido.Text = datoDocente["apellido"].ToString();
            txtFechaIni.Text = fun.convertFechaDia(datoDocente["fecha_nacimiento"].ToString());
            txtTelefono.Text = datoDocente["telefono"].ToString();
            txtEmail.Text = datoDocente["email"].ToString();
            txtDireccion.Text = datoDocente["direccion"].ToString();
        }
        else
        {
            mostrarmensaje("error", "ERROR: No se enontro el cliente.");
        }
    }
    private void ddTipoDocumento(DropDownList drop)
    {
        drop.DataSource = ins.cargarTipoDocumento();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
   
    protected void btnEditarCliente_Click(object sender, EventArgs e)
    {
        if(ins.editarDocente(dropTipoDocumento.SelectedValue,lblCC.Text,txtNombre.Text,txtApellido.Text,dropSexo.SelectedValue,txtDireccion.Text,txtTelefono.Text,fun.convertFechaAño(txtFechaIni.Text),txtEmail.Text))
        {
            if(user.editarUsuarioDocente(lblCC.Text,txtNombre.Text,txtApellido.Text,txtEmail.Text,txtTelefono.Text))
            {
                mostrarmensaje("exito","Docente editado correctamente.");
            }
        }
    }
  

}