using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using System.IO;
using System.Collections;
using System.Net;
using System.Linq;
using System.Xml.Linq;
using iTextSharp.text.html.simpleparser;
using System.Web.Services;
using System.Text;

public partial class repdocentes : System.Web.UI.Page
{
    Proyecto pro = new Proyecto();
    Funciones fun = new Funciones();
    Cliente cli = new Cliente();
    Equipo equi = new Equipo();
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
            ddAnios(dropAnio);
        }
    }

    private void ddAnios(DropDownList drop)
    {
        Institucion inst = new Institucion();

        DataTable datos = inst.cargarAnios();
        drop.DataSource = datos;
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }

    protected void dropAnio_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        cargardocentes(dropAnio.SelectedValue);
        btnExportar.Visible = true;
        lblAnio.Text = dropAnio.SelectedItem.ToString();
    }

    private void cargardocentes(string codanio)
    {
        Estrategias est = new Estrategias();

        DataTable datos = est.cargarDocentesxAnio(codanio);
        GridDocentes.DataSource = datos;
        GridDocentes.DataBind();
    }

    //[WebMethod(EnableSession = true)]
    //public static string cargaranios()
    //{
    //    string ca = "";

    //    Institucion inst = new Institucion();

    //     DataTable datos = inst.cargarAnios();

    //    if(datos != null && datos.Rows.Count > 0)
    //    {
    //        ca += "<option value='0' disabled selected>Seleccione el año</option>";
    //        for(int i = 0; i < datos.Rows.Count; i++)
    //        {
    //            ca += "<option value=" + datos.Rows[i]["codigo"].ToString() + ">" + datos.Rows[i]["nombre"].ToString() + "</option>";
    //        }
    //    }

    //    return ca;
    //}

    //[WebMethod(EnableSession = true)]
    //public static string cargardocentes(string codanio)
    //{
    //    string ca = "";

    //    Estrategias est = new Estrategias();

    //    DataTable datos = est.cargarDocentesxAnio(codanio);

    //    if (datos != null && datos.Rows.Count > 0)
    //    {
    //        //ca += "docentes@";
    //        for (int i = 0; i < datos.Rows.Count; i++)
    //        {
    //            ca += "<tr>";
    //            ca += "<td>" + datos.Rows[i]["departamento"].ToString() + "</td>";
    //            ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
    //            ca += "<td>" + datos.Rows[i]["departamento"].ToString() + "</td>";
    //            ca += "<td>" + datos.Rows[i]["daneinstitucion"].ToString() + "</td>";
    //            ca += "<td>" + datos.Rows[i]["institucion"].ToString() + "</td>";
    //            ca += "<td>" + datos.Rows[i]["danesede"].ToString() + "</td>";
    //            ca += "<td>" + datos.Rows[i]["sede"].ToString() + "</td>";
    //            ca += "<td>" + datos.Rows[i]["identificacion"].ToString() + "</td>";
    //            ca += "<td>" + datos.Rows[i]["nomdoc"].ToString() + "</td>";
    //            ca += "</tr>";
    //        }
    //    }
    //    else
    //    {
    //        ca += "<tr><td colspan='8'>No hay docentes registrados en este año</td></tr>";
    //    }

    //    return ca;
    //}

    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);
        Page page = new Page();
        HtmlForm form = new HtmlForm();

        GridDocentes.EnableViewState = false;
        page.EnableEventValidation = false;
        page.DesignerInitialize();
        page.Controls.Add(form);
        form.Controls.Add(GridDocentes);
        page.RenderControl(htw);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment; filename= InformeDocentes_" + dropAnio.SelectedItem.ToString() + ".xls");
        Response.Charset = "UTF-8";
        Response.ContentEncoding = Encoding.Default;
        Response.Write(sb.ToString());
        Response.End();        
    }
}