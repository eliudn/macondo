using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

public partial class estraunoevidenciasCoor : System.Web.UI.Page
{
    Estrategias est = new Estrategias();
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
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 
        if (!IsPostBack)
        {
            if (Session["codrol"] != null)
            {
                obtenerGET();
                ddAsesores(dropAsesor);
                //lblEncabezados.Text = encabezado();

                //if (lblMomento.Text == "0"){
                //    PanelMomento0.Visible = true;
                //}else if (lblMomento.Text == "1" && lblActividad.Text != "7" && lblActividad.Text != "8" ){
                //    PanelMomento1.Visible = true;
                //}else if (lblMomento.Text == "2"){
                //    PanelMomento2.Visible = true;
                //}else if (lblMomento.Text == "3" ){
                //    PanelMomento3.Visible = true; lblTitulo.Text ="Diseño de las trayectorias de indagación y presupuesto";
                //}else if (lblMomento.Text == "4"){
                //    PanelMomento4.Visible = true;
                //}else if (lblMomento.Text == "5")
                //{
                //    PanelMomento5.Visible = true;
                //}
                //else if (lblActividad.Text == "7" && lblActividad.Text == "8")
                //{
                //    rbtValideActividades.Visible = false;
                //    rbtValideMomento1.Visible = true;
                //    rbtValideMomento2.Visible = true;
                //    rbtValideMomento3_G001.Visible = true;
                //    rbtValideMomento4_G001.Visible = true;
                //    rbtValideMomento5.Visible = true;
                //}

                if (Session["a"].ToString() == "7" || Session["a"].ToString() == "9" || Session["a"].ToString() == "11" || Session["a"].ToString() == "13")
                {
                    lblTitulo.Text = " - Proyecto Preesctructurado Medio Ambiente";
                }
                else if (Session["a"].ToString() == "8" || Session["a"].ToString() == "10" || Session["a"].ToString() == "12" || Session["a"].ToString() == "14")
                {
                    lblTitulo.Text = " - Proyecto Preesctructurado Bienestar Infantil y juvenil";
                }



                if (Session["codrol"].ToString() == "10")
                {
                    PanelMostrarEvidencias.Visible = true;
                }

            }
        
        }
    }
    public void obtenerGET()
    {
       lblMomento.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
       lblSesion.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
       Session["a"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["a"]);

        if(Session["a"] != null)
        {
            lblActividad.Text = Session["a"].ToString();
        }
    }

    private void ddAsesores(DropDownList drop)
    {
        DataTable asesores = est.listarAsesoresEvidencias("1");
        drop.DataSource = asesores;
        drop.DataTextField = "asesor";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }

    private string encabezado()
    {
        string ca = "";

        ca += "<b>Momento: </b>" + lblMomento.Text + "<br/> ";
        //ca += "<b>Momento: </b>" + lblMomento.Text + " - " + "<b>Sesión:</b> " + lblSesion.Text + "<br/> ";

        return ca;
    }
  

   
    Funciones fun = new Funciones();

    protected void dropAsesor_SelectedIndexChanged(object sender, EventArgs e)
    {
        gvCargarEvidencias();
    }
 
    private void gvCargarEvidencias()
    {
       
             DataTable datos = est.cargarEvidenciasEstrategiaConActividad(lblMomento.Text, "0", "1",lblActividad.Text, dropAsesor.SelectedValue);
            GridEvidencias.DataSource = datos;
            GridEvidencias.DataBind();

            if (datos != null && datos.Rows.Count > 0)
            {
                GridEvidencias.UseAccessibleHeader = true;
                if (GridEvidencias.HeaderRow != null)
                {
                    GridEvidencias.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                if (GridEvidencias.ShowFooter)
                    GridEvidencias.FooterRow.TableSection = TableRowSection.TableFooter;
            }
   
    }

    protected void imgEditar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string cod = GridEvidencias.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string cc = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);// IP Antena
        string coddane = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);// IP Antena
        
    }

    protected void DeleteButton_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string cod = GridEvidencias.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  

        borrarImagen(cod);

    }

    private void borrarImagen(string cod)
    {
        Estrategias usu = new Estrategias();
        DataRow dato = usu.buscarEvidenciaEstrategia(cod);
        if (usu.borrarEvidenciaEstrategia(cod))
        {

            if (File.Exists(Server.MapPath(dato["path"].ToString())))
            {
                try
                {
                    File.Delete(Server.MapPath(dato["path"].ToString()));
                    mostrarmensaje("exito", "Eliminado correctamente");
                    gvCargarEvidencias();
                }
                catch
                {
                }
            }

        }
        else
        {
            mostrarmensaje("error", "Error al borrar imagen de la DB");
            gvCargarEvidencias();
        }
    }

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("estramomentos.aspx?m=" + lblMomento.Text);
    }
    protected void imgDescargar_Click(object sender, ImageClickEventArgs e)
    {
        // mostrarmensaje("error", "");
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string filepath = Server.MapPath(HttpUtility.HtmlDecode(gvrow.Cells[10].Text));
        string filename = HttpUtility.HtmlDecode(gvrow.Cells[9].Text);
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
}