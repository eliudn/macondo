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

public partial class estra2evidenciasactividad : System.Web.UI.Page
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
		        buscarUsuario();

                if (Session["codrol"].ToString() == "10")
                {
                    PanelMostrarEvidencias.Visible = true;
                }
                else if (Session["codrol"].ToString() == "9")
                {
                    PanelMostrarEvidencias.Visible = false;
                }

                gvCargarEvidencias();
 
                
            }
        
        }
    }
    public void obtenerGET()
    {
       lblMomento.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
       //lblSesion.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
       Session["a"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["a"]);
       lblActividad.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["a"]);
       lblCodUsuario.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["cod"]);

        if(Session["a"] != null)
        {
            lblActividad.Text = Session["a"].ToString();
        }else if (Session["a"].ToString() == "1")
        {
            actividadactual.Text = "<h2>1. Lineamientos de la estrategia de autoformación</h2>";
        }
        else if (Session["a"].ToString() == "2")
        {
            actividadactual.Text = "<h2>2. Ruta metodológica de la estrategia de autoformación</h2>";
        }
        else if (Session["a"].ToString() == "3")
        {
            actividadactual.Text = "<h2>3. Cronogramas de trabajo aprobados y subidos a la plataforma</h2>";
        }
    }
    private string encabezado()
    {
        string ca = "";

        ca += "<b>Momento: </b>" + lblMomento.Text + "<br/> ";
        //ca += "<b>Momento: </b>" + lblMomento.Text + " - " + "<b>Sesión:</b> " + lblSesion.Text + "<br/> ";

        return ca;
    }
    private void buscarUsuario()
    {
        Usuario usu = new Usuario();
        DataRow dato = usu.buscarUsuario(Session["codusuario"].ToString());
        if (dato != null)
        {
            //lblCodUsuario.Text = dato["cod"].ToString();

        }

    }

   
    Funciones fun = new Funciones();
   


    private void gvCargarEvidencias()
    {
        if(lblActividad.Text == "7" || lblActividad.Text == "8")
        {
            DataTable datos = est.estra2LineamientosEstrategia(lblMomento.Text, "2", lblActividad.Text);
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
        else
        {
            DataTable datos2 = est.estra2LineamientosEstrategia(lblMomento.Text, "2", lblActividad.Text);//(string momento, string sesion, string estrategia, string actividad, string codusuario)
            GridEvidencias.DataSource = datos2;
            GridEvidencias.DataBind();

            if (datos2 != null && datos2.Rows.Count > 0)
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

 
    }

    protected void imgEditar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string cod = GridEvidencias.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string cc = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);// IP Antena
        string coddane = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);// IP Antena
        
    }


    protected void btnRegresar_Click(object sender, EventArgs e)
    {

        Response.Redirect("estra2disenolineamientos.aspx?m=0&e=2");
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