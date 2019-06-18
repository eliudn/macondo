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

public partial class lineabaseconficode : System.Web.UI.Page
{
    Funciones fun = new Funciones();
    LineaBase lb = new LineaBase();
    Usuario usu = new Usuario();
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["codrol"] != null)
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
            if (Session["codrol"].ToString() != "1")
            {
                  Response.Redirect("Default.aspx");
            }
            else
            {
                buscarCodes();
                lblStylePrint02.Text = StylePrint();
            }
          
        }
    }

    private void buscarCodes()
    {
        string co = "";
        DataTable code = usu.cargarCodigosUsuarios();

        if (code != null && code.Rows.Count > 0)
        {

                co += "<table class='mGridTesoreria'>";
                co += "<tr><th>Nro.</th><th>ID. USUARIO </th><th>CÓDIGO DE VERIFICACIÓN </th></tr>";
                for (int i = 0; i < code.Rows.Count; i++)
                {
                    co += "<tr>";
                    co += "<td>" + (i+1) + "</td>";
                    co += "<td>" + code.Rows[i]["identificacion"].ToString() + "</td>";
                    //co += "<td>" + code.Rows[i]["pnombre"].ToString() + " " + code.Rows[i]["papellido"].ToString() + "</td>";
                    co += "<td align='center'>" + code.Rows[i]["code"].ToString() + "</td>";
                    co += "</tr>";
                }
                co += "</table>";

        }
        else
        {
            co = "El sistema no tiene códigos generados.";
        }

        

       
        lblcodes.Text = co;
    }

    private string generarCodes(string id)
    {
        string ca = "";

        Usuario usu = new Usuario();

        Random rdn = new Random();

        int num = rdn.Next(10000000, 90000000);

        string code = Convert.ToString(num);

        if (usu.agregarCodigoVerificacion(id, code))
        {
       
        }

        return ca;

    }
    protected void btnActivacionCode_Click(object sender, EventArgs e)
    {
        string co = "";
        DataTable user = usu.cargarUsuarios();


        if (user != null && user.Rows.Count > 0)
        {
            for (int i = 0; i < user.Rows.Count; i++)
            {
                if (user.Rows[i]["usuario"].ToString() != "superadmin")
                {
                    DataRow bcode = usu.buscarCodigoVerificacionxDocente(user.Rows[i]["identificacion"].ToString());
                    if (bcode == null)
                    {
                        co += generarCodes(user.Rows[i]["identificacion"].ToString());
                    }
                }
            }

        }
        buscarCodes();
    }

    protected void btnExportar02_Click(Object sender, EventArgs e)
    {
        Response.Clear(); Response.AddHeader("content-disposition", "attachment; filename=Reporte_CódigosVerificación.xls"); Response.Charset = ""; Response.ContentType = "application/vnd.xls"; System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite =
        new HtmlTextWriter(stringWrite);

        lblcodes.RenderControl(htmlWrite);

        Response.Write(stringWrite.ToString()); Response.End();
    }
    protected void btnImprimir02_Click(Object sender, EventArgs e)
    {
        //consulto el modo de impresion activo
        //lleno el lbl (tradicional o mini) con el return del metodo, de acuerdo al modo de impresión
        //en el Session["impresion"] guardo el panel del modo impresion activo.
        Session["impresion"] = PanelGeneracion;
        Control ctrl = (Control)Session["impresion"];
        PrintHelper.PrintWebControl(ctrl);
    }

    private string StylePrint()
    {
        string co = "";

        co += " <style media='print'>";
        co += "    body {";
        co += "       background-color: #fff;";
        co += "    }";
        co += "    @media print {";
        co += "        @page {";
        co += "            size: auto letter;";
        co += "       }";

        /*thead {
            display: table-header-group;
        }*/

        co += "    }";

        co += "    .contenidoImpresion {";
        co += "        color: #4cff00;";
        co += "        font-family: Courier New;";
        co += "   }";

        co += "   .mGridTesoreria {";
        co += "      width: 99%;";
        co += "      font-family: 'Lato', Helvetica, sans-serif !important;";
        co += "      border: solid 1px #ccc;";
        co += "       border-collapse: collapse;";
        co += "  }";

        co += "      .mGridTesoreria th {";
        co += "          padding: 2px;";
        co += "        border: solid 1px #ccc;";
        co += "      border-collapse: collapse;";
        co += "         color: #000;";
        co += "        font-size: 13px;";
        co += "       background-color: #004b96;";
        co += "    }";

        co += "    .mGridTesoreria td {";
        co += "        padding: 2px;";
        co += "        border: solid 1px #ccc;";
        co += "     border-collapse: collapse;";
        co += "        color: #000;";
        co += "        font-size: 11px;";
        co += "    }";

        co += "    #mGridTesoreria td{";
        co += "        font-size:12px;";
        co += "    }";
        co += "</style>";

        return co;
    }
}