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

public partial class estulistado : System.Web.UI.Page
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
            ddDepartamento(dropDepartamento);
            ddAnio(dropAnio);
        }
        lblTipoUsuario.Text = Session["codrol"].ToString();
        if (lblTipoUsuario.Text == "2" || lblTipoUsuario.Text == "3" || lblTipoUsuario.Text == "4" || lblTipoUsuario.Text == "5" || lblTipoUsuario.Text == "6")
        {
            GridClientes.Columns[10].Visible = false;
        }
    }
    private void ddAnio(DropDownList drop)
    {
        drop.DataSource = ins.cargarAnios();
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
    }
    private void ddDepartamento(DropDownList drop)
    {
        drop.DataSource = ins.cargarDepartamentoMagdalena();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione Departamento"));
    }
    private void ddMunicipio(DropDownList drop, string coddepartamento)
    {
        drop.DataSource = ins.cargarciudadxDepartamento(coddepartamento);
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione Municipio"));
    }
    private void ddInstituciones(DropDownList drop, string codmunicipio)
    {
        drop.DataSource = ins.cargarInstitucionxMunicipio(codmunicipio);
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigo";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione Institución"));
    }

    protected void dropDepartamento_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        ddMunicipio(dropMunicipios, dropDepartamento.SelectedValue);
    }
    protected void dropCiudad_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        ddInstituciones(dropInstitucion, dropMunicipios.SelectedValue);
    }
    private DataTable gvDatosClientesWhere()
    {
        return est.cargarEstudiantesWhere(llenarWhere());
    }
    private void gvCargarCliente()
    {
        GridClientes.DataSource = gvDatosClientesWhere();
        GridClientes.DataBind();
        if (GridClientes.Rows.Count > 0)
        {
            botones.Visible = true;
            GridClientes.UseAccessibleHeader = true;
            if (GridClientes.HeaderRow != null)
            {
                GridClientes.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (GridClientes.ShowFooter)
                GridClientes.FooterRow.TableSection = TableRowSection.TableFooter;
        }
        else
        {
            botones.Visible = false;
        }
    }
    protected void imgEditar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string cod = GridClientes.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        string codproyecto = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);// IP Antena
        Response.Redirect("editcliente.aspx?cc=" + cod + "&cp=" + codproyecto + "", true);
    }
  
    protected void GridClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridClientes.PageIndex = e.NewPageIndex;
        gvCargarCliente();
    }
    protected void GridClientes_Sorting(object sender, GridViewSortEventArgs e)
    {

    }
    protected void txtBusqueda_TextChanged(object sender, EventArgs e)
    {
        //dropDepartamentos.SelectedIndex = 0;
        //PanelMunicipio.Visible = false;
        //dropProyectos.SelectedIndex = 0;
        gvCargarCliente();
    }
    private string llenarWhere()
    {
        int numero = 6;
        string[] cond;
        cond = new string[numero];

        cond[0] = string.Empty;  //coddepartamento
        cond[1] = string.Empty;  //codmunicipio
        cond[2] = string.Empty;  //codinstitucion
        cond[3] = string.Empty;  //codanio
        cond[4] = string.Empty;  //Red temática - grupo de investigación
        cond[5] = string.Empty;  //like

       
            if (dropDepartamento.SelectedIndex > 0)
            {
                if (dropMunicipios.SelectedIndex > 0)
                {
                    if (dropInstitucion.SelectedIndex > 0)
                    {
                        cond[0] = string.Empty;
                        cond[1] = string.Empty;
                        cond[2] = "s.codinstitucion='" + dropInstitucion.SelectedValue + "' AND em.codanio='" + dropAnio.SelectedValue + "' AND em.codtipogrupo='" + dropTipoGrupo.SelectedValue + "'";
                        cond[3] = string.Empty;
                        cond[4] = string.Empty;
                        cond[5] = string.Empty;
                    }
                    else
                    {
                        cond[0] = string.Empty;
                        cond[1] = "s.codmunicipio='" + dropMunicipios.SelectedValue + "' AND em.codanio='" + dropAnio.SelectedValue + "' AND em.codtipogrupo='" + dropTipoGrupo.SelectedValue + "'";
                        cond[2] = string.Empty;
                        cond[3] = string.Empty;
                        cond[4] = string.Empty;
                        cond[5] = string.Empty;
                    }
                }
                else
                {
                    cond[0] = "m.coddepartamento='" + dropDepartamento.SelectedValue + "' AND em.codanio='" + dropAnio.SelectedValue + "' AND em.codtipogrupo='" + dropTipoGrupo.SelectedValue + "'";
                    cond[1] = string.Empty;
                    cond[2] = string.Empty;
                    cond[3] = string.Empty;
                    cond[4] = string.Empty;
                    cond[5] = string.Empty;
                }

            }



            if (txtBusqueda.Text != "")
            {
                cond[0] = string.Empty;
                cond[1] = string.Empty;
                cond[2] = string.Empty;
                cond[3] = string.Empty;
                cond[4] = string.Empty;
                cond[5] = "CONCAT_WS(' ',e.nombre,e.apellido,e.identificacion) ILIKE '%" + txtBusqueda.Text + "%'";
            }
     
        string where = "";
        int primero = 0;
        for (int i = 0; i < numero; i++)
        {
            if (cond[i] != string.Empty)
            {
                if (primero == 0)
                {
                    where += "WHERE " + cond[i];
                }
                if (primero > 0)
                {
                    where += " AND " + cond[i];
                }
                if (primero == 0)
                {
                    primero = 1;
                }
            }
        }
        return where;
    }
    protected void btnExportExcel_Click(object sender, EventArgs e)
    {
        ClosedXML.Excel.XLWorkbook libro = new ClosedXML.Excel.XLWorkbook();
        //hoja = libro.Worksheets.Add("Listado de Clientes");
        DataTable datosCliente = gvDatosClientesWhere();
        datosCliente.TableName = "Listado Clientes";
        hoja = libro.Worksheets.Add(datosCliente);
        hoja.Column(1).Delete();
        hoja.Column(1).Delete();
        hoja.Column(4).Delete();

        hoja.Cell("A1").Value = "NIT";
        hoja.Cell("E1").Value = "MUNICIPIO";
        hoja.Cell("F1").Value = "DEPARTAMENTO";
        hoja.Cell("G1").Value = "PROYECTO";

        //Session["LibroExcel"] = libro;
        //XLWorkbook libro = new ClosedXML.Excel.XLWorkbook();
        //libro = (XLWorkbook)Session["LibroExcel"];
        //Session["LibroExcel"] = null;
        Response.Clear();
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=\"Listado Clientes.xlsx\"");
        using (var memoryStream = new MemoryStream())
        {
            libro.SaveAs(memoryStream);
            memoryStream.WriteTo(Response.OutputStream);
        }
        Response.End();
        

        
    }
    protected void DeleteButton_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string cod = GridClientes.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        DataTable datosSedes = cli.cargarSedesCliente(cod);
        if (datosSedes != null && datosSedes.Rows.Count > 0)
        {
            int k = 0;
            for (int i = 0; i < datosSedes.Rows.Count; i++)
            {
                if (cli.eliminarSedeCliente(datosSedes.Rows[i]["cod"].ToString()))
                    k++;
            }
            if (k == datosSedes.Rows.Count)
            {
                mostrarmensaje("exito", "Cliente y sedes borrado correctamente.");
                gvCargarCliente();
            }
            else
                mostrarmensaje("error", "ERROR: No se logró borrar las sedes de este cliente.");

        
        }
        else
        {
            //No tiene sedes se borra el cliente
            if (cli.eliminarCliente(cod))
            {
                mostrarmensaje("exito", "Cliente  borrado correctamente.");
                //if (dropDepartamentos.SelectedIndex > 0)
                //{
                //    gvCargarCliente();
                //}
                //else
                //{
                //    dropProyectos_SelectedIndexChanged(null, null);
                //}
          
            }
            else
            {
                mostrarmensaje("error", "ERROR: Este cliente no se puede borrar, tiene información relacionada.");
            }
        }

    }
    protected void dropMunicipio_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (dropMunicipio.SelectedIndex > 0)
        //{
        //    dropProyectos.SelectedIndex = 0;
        //    txtBusqueda.Text = string.Empty;
        //    gvCargarCliente();
        //}
    }
    protected void btnImprimir_Click(object sender, EventArgs e)
    {
        Session["impresion"] = PanelImpresion;
        Control ctrl = (Control)Session["impresion"];
        PrintHelper.PrintWebControl(ctrl);
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        gvCargarCliente();
    }
 
}