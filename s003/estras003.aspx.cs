using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class estras003 : System.Web.UI.Page
{
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["codperfil"] != null)
        {

        }
        else
            Response.Redirect("Default.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            obtenerGET();
        }
    }
    public void obtenerGET()
    {
        //Session["momento"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        Session["e"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["e"]);
        lblMomento.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        lblSesion.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);

    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        if (Session["e"].ToString() == "1")
            Response.Redirect("../estramomentos.aspx?m=" + lblMomento.Text);
        else if (Session["e"].ToString() == "2")
            Response.Redirect("../estradosmomentos.aspx?m=" + lblMomento.Text + "&s=" + lblSesion.Text);

        
        //if (Session["momento"].ToString() == "1" && Session["sesion"].ToString() == "1")
        //{
        //    Response.Redirect("../estradosmomentos.aspx?s003Momento=1&s003Sesion=1");
        //}
        //else if (Session["momento"].ToString() == "3" && Session["sesion"].ToString() == "2")
        //{
        //    Response.Redirect("../estradosmomentos.aspx?s003Momento=3&s003Sesion=2");
        //}
        //else if (Session["momento"].ToString() == "3" && Session["sesion"].ToString() == "3")
        //{
        //    Response.Redirect("../estradosmomentos.aspx?s003Momento=3&s003Sesion=3");
        //}
    }
}