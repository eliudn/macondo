using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class menu : System.Web.UI.Page
{
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        //if (Session["codperfil"] != null)
        //{
        //    string linkpagina = Request.Url.Segments[Request.Url.Segments.Length - 1];
        //    int contador = 0;
        //    Usuarios usu = new Usuarios();
        //    DataRow dato = usu.verificarUsuarioAcceso(linkpagina, Session["codperfil"].ToString());
        //    if (dato == null)
        //        contador = 1;
        //    DataRow dato2 = usu.verificarUsuarioAcceso(linkpagina + ".aspx", Session["codperfil"].ToString());
        //    if (dato2 == null)
        //        contador = 1;

        //    if (contador == 0)
        //    {
        //        Response.Redirect("bienvenida.aspx");
        //    }
        //}
        //else
        //    Response.Redirect("Default.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje         
        if (!IsPostBack)
        {
            cargarGridMenu();
        }
    }
    private void cargarGridMenu()
    {
        Menu men = new Menu();
        DataSet datos = men.cargarMenu();
        string sortDirection = "", sortExpression = "";
        if (datos!= null && datos.Tables.Count > 0)
        {
            DataView dv = datos.Tables[0].DefaultView;
            if (ViewState["SortDirection"] != null)
            {
                sortDirection = ViewState["SortDirection"].ToString();
            }
            if (ViewState["SortExpression"] != null)
            {
                sortExpression = ViewState["SortExpression"].ToString();
                dv.Sort = string.Concat(sortExpression, " ", sortDirection);
            }
            GridMenu.DataSource = dv;
          
        }
        GridMenu.DataBind();
    }
    private void ddCodSuperior(DropDownList drop)
    {
        string nivel = (Convert.ToDouble(DropNivelItem.SelectedValue) - 1).ToString();
        Menu men = new Menu();
        DataTable datos = men.cargarCodSuperior(nivel);
        drop.DataSource = datos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
    }
    protected void btnPosicionar_Click(object sender, EventArgs e)
    {
        //Si el nivel es 1
        if (DropNivelItem.SelectedIndex == 0)
        {
            if (txtLinkItem.Text == "")
                txtLinkItem.Text = "#";
            Menu men = new Menu();
            int nivelsumado = 1;
            DataRow dato = men.buscarOrdenNivel1(DropNivelItem.SelectedValue);
            if (dato != null && dato["nivelmax"].ToString()!= "")
            {
                nivelsumado = (Convert.ToInt16(dato["nivelmax"].ToString()) + 1);
            }
        
       
            if (men.agregarMenu(txtNombreItem.Text, DropNivelItem.SelectedValue, nivelsumado.ToString(), txtLinkItem.Text))
            {
                mostrarmensaje("exito", "Item Guardado Correctamente");
                cargarGridMenu();
                txtNombreItem.Text = "";
                txtLinkItem.Text = "";
            }
            else
            {
                mostrarmensaje("error", "Error al Guardar Item");
            }
        }
        else
        {
            //Si el nivel es 2
            ddCodSuperior(DropCodSuperior);
            Panel2Nivel.Visible = true;
            btnPosicionar.Enabled = false;
        }
    }
    protected void btnPosicionar2_Click(object sender, EventArgs e)
    {
        double nivelsumado = 0;
        Menu men = new Menu();
        DataRow dato = men.buscarOrdenNivel2(DropNivelItem.SelectedValue, DropCodSuperior.SelectedValue);
        if (dato!=null && dato["nivelmax"].ToString() != "")
            nivelsumado = Convert.ToDouble(dato["nivelmax"].ToString()) + 1;
        else
            nivelsumado = 1;

        if (men.agregarMenu(txtNombreItem.Text, DropNivelItem.SelectedValue, nivelsumado.ToString(), DropCodSuperior.SelectedValue, txtLinkItem.Text))
        {
            mostrarmensaje("exito", "Item Guardado Correctamente");
            cargarGridMenu();
            txtNombreItem.Text = "";
            DropNivelItem.SelectedIndex = 0;
            txtLinkItem.Text = "";
            Panel2Nivel.Visible = false;
        }
        else
        {
            mostrarmensaje("error", "Error al Guardar Item");
        }
    }
}