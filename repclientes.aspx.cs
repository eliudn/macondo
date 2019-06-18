using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class repclientes : System.Web.UI.Page
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
            ddProyectos(DropProyecto);
        }
    }
    private void ddProyectos(DropDownList drop)
    {
        drop.DataSource = pro.cargarProyectos();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    protected void btnSeleccioneProyecto_Click(object sender, EventArgs e)
    {
        if (DropProyecto.SelectedIndex > 0)
        {
            cargarClientes(DropProyecto.SelectedValue);
        }
    }
    private void cargarClientes(string proyecto)
    {
       DataTable datosClientes = pro.cargarClienteInProyecto(proyecto);
       if (datosClientes != null && datosClientes.Rows.Count > 0)
       {
           botones.Visible = true;
           lblClientes.Text = "   <table class='mGridTesoreria'>";
           lblClientes.Text += titulosTabla();
           for (int i = 0; i < datosClientes.Rows.Count; i++)
           {
               lblClientes.Text += armarCliente(datosClientes.Rows[i],i,DropProyecto.SelectedValue);
           }
           lblClientes.Text += "</table>";
       }
       else
       {
           botones.Visible = false;
           lblClientes.Text = "No se encontraron cliente en este proyecto: "+DropProyecto.SelectedItem.Text;
       }
    }
    private string titulosTabla()
    {
        string ca = "";
        ca += " <tr>";
        ca += "<th>Nro.</th>";
        ca += "<th>Cliente</th>";
        ca += "<th>Documentos</th>";
        ca += "<th>Equipos</th>";
        ca += "<th>Contactos</th>";
        ca += "<th>Revisar</th>";
        ca += "</tr>";
       return ca;
    }
    private string armarCliente(DataRow datoCliente,int contador,string codproyecto)
    {
        string ca = "";
        ca += "<tr>";
        ca += "<td>"+(contador+1).ToString()+"</td>";
        ca += "<td>" + datoCliente["nombre"].ToString() + "</td>";
        ca += armarDocumentos(datoCliente["cod"].ToString(), codproyecto);
        ca += armarEquipos(datoCliente["cod"].ToString(), codproyecto);
        ca += armarContactos(datoCliente["cod"].ToString());
        ca += "<td  style='text-align:center'><a href='editcliente.aspx?cc=" + datoCliente["codcliente"].ToString() + "' target='_blank'><img src='Imagenes/details.png' /></a></td>";
        ca += "</tr>";
        return ca;
    }
    private string armarDocumentos(string codclisede, string codproyecto)
    {
        string ca = "";
        DataTable datosDocumentos = pro.cargarDocumentosxProyectoxCliSede(codclisede, codproyecto);
        if (datosDocumentos != null && datosDocumentos.Rows.Count > 0)
        {
            ca += "<td  style='text-align:center'>" + datosDocumentos.Rows.Count + "</td>";
        }
        else
        {
            ca += "<td style='background-color:#e96c6c;text-align:center'>0</td>";
        }
        return ca;
    }
    private string armarEquipos(string codclisede, string codproyecto)
    {
        string ca = "";
        DataTable datosEquipos = equi.cargarEquiposxCliEquipoxProyecto(codclisede, codproyecto);
        if (datosEquipos != null && datosEquipos.Rows.Count > 0)
        {
            ca += "<td  style='text-align:center'>" + datosEquipos.Rows.Count + "</td>";
        }
        else
        {
            ca += "<td style='background-color:#e96c6c;text-align:center'>0</td>";
        }
        return ca;
    }
    private string armarContactos(string codclisede)
    {
        string ca = "";
        DataTable datosContactos = cli.cargarContactosxSede(codclisede);
        if (datosContactos != null && datosContactos.Rows.Count > 0)
        {
            ca += "<td  style='text-align:center'>" + datosContactos.Rows.Count + "</td>";
        }
        else
        {
            ca += "<td style='background-color:#e96c6c;text-align:center'>0</td>";
        }
        return ca;
    }

    
    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment;filename=ReporteCientes.xls");
        Response.Charset = "UTF-8";
        Response.ContentEncoding = System.Text.Encoding.Default;
        Response.ContentType = "application/vnd.ms-excel";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        lblClientes.RenderControl(htmlWrite);
      

        Response.Output.Write("\n<body>\n<html>");
        //Response.Output.Write("<table align='center' style='text-align:center;'");
        //Response.Output.Write("<tr><td colspan='2' align='center'><div align='center' style='text-align:center'>" + imagepath + "</div></td></tr>");
        //Response.Output.Write("</table>");
        Response.Write(stringWrite.ToString());
        Response.Output.Write("\n</body>\n</html>");
        Response.End();
    }
}