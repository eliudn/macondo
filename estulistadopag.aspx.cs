using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ClosedXML;
using ClosedXML.Excel;
using System.Web.Services;


public partial class estulistadopag : System.Web.UI.Page
{
    private ClosedXML.Excel.XLWorkbook libro;
    private ClosedXML.Excel.IXLWorksheet hoja;
    Proyecto pro = new Proyecto();
    Cliente cli = new Cliente();
    Localidad loc = new Localidad();
    Institucion ins = new Institucion();
    Estudiantes est = new Estudiantes();
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
        mensaje.Attributes.Add("style", "display:none");
        if (!IsPostBack)
        {
           
        }
       
    }

    [WebMethod(EnableSession = true)]
    public static string cargarListadoEstudiantes(string page, string rows)
    {
        Estudiantes est = new Estudiantes();
        Funciones fun = new Funciones();

        int pagint = Convert.ToInt32(page);
        int rowsint = Convert.ToInt32(rows);
        int offset = (pagint - 1) * rowsint;

        DataTable estudiantes = est.cargarEstudiantesTodoOFFSET(Convert.ToString(offset), rows);

        string ca = "";

      
        if (estudiantes != null && estudiantes.Rows.Count > 0)
        {
            DataTable estudiantesCount = est.cargarEstudiantesTodo();

            double cant = estudiantesCount.Rows.Count;
            double val = Math.Ceiling(cant / 100);


            for (int i = 0; i < estudiantes.Rows.Count; i++)
            {

                ca += "<tr>";
                ca += "<td>" + ((offset++) + 1) + "</td>";
                ca += "<td align='center'>" + estudiantes.Rows[i]["abr"].ToString() + "</td>";
                ca += "<td>" + estudiantes.Rows[i]["identificacion"].ToString() + "</td>";
                ca += "<td>" + estudiantes.Rows[i]["apellido"].ToString() + "</td>";
                ca += "<td>" + estudiantes.Rows[i]["nombre"].ToString() + "</td>";
                ca += "<td align='center'>" + estudiantes.Rows[i]["sexo"].ToString() + "</td>";
                ca += "<td>" + fun.convertFechaAño(estudiantes.Rows[i]["fecha_nacimiento"].ToString()) + "</td>";
                ca += "<td>" + estudiantes.Rows[i]["telefono"].ToString() + "</td>";
                ca += "<td>" + estudiantes.Rows[i]["direccion"].ToString() + "</td>";
                ca += "<td>" + estudiantes.Rows[i]["email"].ToString() + "</td>";
                ca += "<td>" + estudiantes.Rows[i]["etnia"].ToString() + "</td>";
                ca += "</tr>";
            }
            ca += "&";
            if((pagint - 1) > 0)
            {
                ca += " <span id='span" + (pagint - 1) + "' class=\"item \" onclick='cargarListadoEstudiantes(\"" + (pagint - 1) + "\",\"100\")'><</span>";
            }
            for (int j = 0; j < Convert.ToInt32(rows); j++)
            {
                if (pagint == (j + 1))
                {
                    ca += " <span id='span" + (j + 1) + "' class=\"item current\" onclick='cargarListadoEstudiantes(\"" + (j + 1) + "\",\"100\")'>" + (j + 1) + "</span>";
                }
                else
                {
                    ca += " <span id='span" + (j + 1) + "' class=\"item\" onclick='cargarListadoEstudiantes(\"" + (j + 1) + "\",\"200\")'>" + (j + 1) + "</span>";
                }

            }
            if ((pagint + 1) <= Convert.ToInt32(rows)) 
            {
                if (Convert.ToInt32(rows) != (pagint + 1))
                {
                    ca += " <span id='span" + (pagint + 1) + "' class=\"item \" onclick='cargarListadoEstudiantes(\"" + (pagint + 1) + "\",\"100\")'>></span>";
                }
            } 
            
        }
      
        return ca;

    }
  
   
    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        //ClosedXML.Excel.XLWorkbook libro = new ClosedXML.Excel.XLWorkbook();
        ////hoja = libro.Worksheets.Add("Listado de Clientes");
        //DataTable datosCliente = gvDatosClientesWhere();
        //datosCliente.TableName = "Listado Clientes";
        //hoja = libro.Worksheets.Add(datosCliente);
        //hoja.Column(1).Delete();
        //hoja.Column(1).Delete();
        //hoja.Column(4).Delete();

        //hoja.Cell("A1").Value = "NIT";
        //hoja.Cell("E1").Value = "MUNICIPIO";
        //hoja.Cell("F1").Value = "DEPARTAMENTO";
        //hoja.Cell("G1").Value = "PROYECTO";

        ////Session["LibroExcel"] = libro;
        ////XLWorkbook libro = new ClosedXML.Excel.XLWorkbook();
        ////libro = (XLWorkbook)Session["LibroExcel"];
        ////Session["LibroExcel"] = null;
        //Response.Clear();
        //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //Response.AddHeader("content-disposition", "attachment;filename=\"Listado Clientes.xlsx\"");
        //using (var memoryStream = new MemoryStream())
        //{
        //    libro.SaveAs(memoryStream);
        //    memoryStream.WriteTo(Response.OutputStream);
        //}
        //Response.End();
        

        
    }
  
 
}