using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;

public partial class estraunobitacoracuatrouno : System.Web.UI.Page
{
    
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["codperfil"] != null)
        {

        }
        else
            Response.Redirect("Default.aspx",true);
    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
       
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 

        if (!IsPostBack)
        {
            if (Session["identificacion"] != null)
            {
                Estrategias estra = new Estrategias();
                DataRow dato = estra.buscarCodEstrategiaxCoordinador(Session["identificacion"].ToString());

                if (dato != null)
                {
                    Session["codEstraAsesorCoordinador"] = dato["codigo"].ToString();

                }
            }
         
        }
    }
    private void cblRoles2(CheckBoxList rol)
    {
        Usuario usu = new Usuario();
        DataTable datos = usu.cargarRoles();
        rol.DataSource = datos;
        rol.DataTextField = "nombre";
        rol.DataValueField = "cod";
        rol.DataBind();
    }
    private void ddRoles(DropDownList drop)
    {
        Usuario usu = new Usuario();
        DataTable datos = usu.cargarRoles();
        drop.DataSource = datos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
   
 
    protected void GridUsuarios_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
       
    }
    protected void GridUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       
    }
 
    protected void btnEditar_Click(object sender, EventArgs e)
    {
       
    
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
       
    }
    protected void lnkReestablecerContra_Click(object sender, EventArgs e)
    {
       
    }
    protected void btnGuardarcontra_Click(object sender, EventArgs e)
    {
       
    }
    protected void btnCancelar2_Click(object sender, EventArgs e)
    {
       
    }
    protected void btnAgregarUsuario_Click(object sender, EventArgs e)
    {
           
    }
   
    private bool validarRoles(CheckBoxList combo)
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
    private void relacionarUsuarioRoles(string id,CheckBoxList combo)
    {
        Usuario user = new Usuario();
        for (int i = 0; i < combo.Items.Count; i++)
        {
            if (combo.Items[i].Selected)
            {
                user.relacionarUsuarioRol(id, combo.Items[i].Value);
            }
        }
    }
    private void limpiarCampos(string tipo)
    {
        
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
     
    }
    private void llenarCampos(string codusuario)
    {
       
    }
    private void cargarRolesDeusuaario()
    {
      
    }
  
    protected void imgEliminarRol_Click(object sender, ImageClickEventArgs e)
    {
       
    }
    protected void dropRoles_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("estramomentos.aspx?bitacora=true");
    }

    protected void cargarEvidencias_Click(object sender, EventArgs e)
    {
        PanelEdicion_ModalPopupExtender.Show();
    }

    [WebMethod(EnableSession = true)]
    public static string cargarInstituciones()
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarInstitucion();
        if (datos != null && datos.Rows.Count > 0)
        {
            //ca = "inst@";
            ca += "<option value='0' disabled selected>Seleccione institucion</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
            
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarSedesInstitucion(string codInstitucion)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarSedesInstitucion(codInstitucion);
        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<option value='0' disabled selected>Seleccione institucion</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarLineaInvestigacion(string codSede)
    {
        string ca = "";

        Estrategias estra = new Estrategias();

        DataTable datos = estra.cargarLineaInvestigacion(codSede);
        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<option value='0' disabled selected>Seleccione grupo investigacion</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession=true)]
    public static string guardarInformefinanciero(string codProyecto, string rubros, string fechaGasto, string nombreProveedor, string descripcionGasto, string valorTotal)
    {
        string ca = "";
        Estrategias estra = new Estrategias();
        Funciones fun = new Funciones();
        if (estra.guardarInformeFinanciero(codProyecto, rubros, fun.convertFechaAño(fechaGasto), nombreProveedor, descripcionGasto, valorTotal))
        {
            ca += "Datos almacenados exitosamente";
        }
        return ca;
    }

}