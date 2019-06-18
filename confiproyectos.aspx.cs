using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class confiproyectos : System.Web.UI.Page
{
    Localidad loc = new Localidad();
    Proyecto pro = new Proyecto();
    Funciones fun = new Funciones();
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
            PanelEditar.Attributes.Add("style", "display:none");
            ddDepartamento(dropDepartamento);
            ddDepartamento(dropDepartamentoEditar);
            ddLineaInvestigacion(dropLInvestigacion);
            gvcargarProyectos();
        }
    }
    private void ddDepartamento(DropDownList drop)
    {
        drop.DataSource = loc.cargarDepartamentos();
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    protected void dropDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropDepartamento.SelectedIndex > 0)
        {
            ddMunicipios(dropMunicipio, dropDepartamento.SelectedValue);
        }
    }
    private void ddMunicipios(DropDownList drop,string coddepartamento)
    {
        drop.DataSource = loc.cargarMunicipiosSinCodSuperior(coddepartamento);
        drop.DataTextField = "nombre";
        drop.DataValueField = "cod";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void ddLineaInvestigacion(DropDownList drop)
    {
        drop.DataSource = pro.cargarLineasInvestigacion();
        drop.DataTextField = "nombre";
        drop.DataValueField = "codigos";
        drop.DataBind();
        drop.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
    }
    private void gvcargarProyectos()
    {
        GridProyectos.DataSource = pro.cargarProyectos();
        GridProyectos.DataBind();
    }
    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        if (validarFechas(txtFechaIni.Text, txtFechaFin.Text))
        {
            if (dropMunicipio.SelectedIndex > 0)
            {
                if (pro.agregarProyecto(txtNombre.Text, dropDepartamento.SelectedValue, dropMunicipio.SelectedValue, fun.convertFechaAño(txtFechaIni.Text), fun.convertFechaAño(txtFechaFin.Text)))
                {
                    gvcargarProyectos();
                    limpiarCampos();
                    mostrarmensaje("exito", "Proyecto Agregado Correctamente.");
                }
                else
                {
                    mostrarmensaje("error", "ERROR: No se logró agregar el proyecto");
                }
            }
            else
            {
                if (pro.agregarProyecto(txtNombre.Text, dropDepartamento.SelectedValue, "0", fun.convertFechaAño(txtFechaIni.Text), fun.convertFechaAño(txtFechaFin.Text)))
                {
                    gvcargarProyectos();
                    limpiarCampos();
                    mostrarmensaje("exito", "Proyecto Agregado Correctamente.");
                }
                else
                {
                    mostrarmensaje("error", "ERROR: No se logró agregar el proyecto");
                }
            }
        }
        else
        {
            mostrarmensaje("error", "ERROR: La fecha de cierre debe ser mayor que la de inicio.");
        }
       
    }
    private void limpiarCampos()
    {
        txtNombre.Text = string.Empty;
        txtFechaIni.Text = string.Empty;
        txtFechaFin.Text = string.Empty;
        dropDepartamento.SelectedIndex = 0;
        dropMunicipio.SelectedIndex = 0;
    }
    protected void imgEditar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string cod = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
        string nombre = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
        string coddepartamento = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
        string fechaini = HttpUtility.HtmlDecode(gvrow.Cells[7].Text);
        string fechafin = HttpUtility.HtmlDecode(gvrow.Cells[8].Text);
        string codmunicipio = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);
        string estado = HttpUtility.HtmlDecode(gvrow.Cells[9].Text);
        lblCodProyecto.Text = cod;
        cargarAnexos(lblCodProyecto.Text);
        txtProyectoEditar.Text = nombre;
        dropDepartamentoEditar.SelectedValue = coddepartamento;
        txtFechaIniEditar.Text = fechaini;
        txtFechaFinEditar.Text = fechafin;
        dropEstado.SelectedValue = estado;
        if (codmunicipio != "0")
        {
            dropDepartamentoEditar_SelectedIndexChanged(null, null);
            dropMunicipioEditar.SelectedValue = codmunicipio;
        }
 
        this.PanelEditar_Modalpopupextender.Show();
    }
    private void cargarAnexos(string codocumento)
    {
        GridDocumentos.DataSource = pro.cargarAnexosProyecto(codocumento);
        GridDocumentos.DataBind();
    }
    protected void btnEditarProyecto_Click(object sender, EventArgs e)
    {
        if (validarFechas(txtFechaIniEditar.Text, txtFechaFinEditar.Text))
        {
            if (dropMunicipioEditar.SelectedIndex > 0)
            {
                if (pro.editarProyecto(txtProyectoEditar.Text, dropDepartamentoEditar.SelectedValue, dropMunicipioEditar.SelectedValue, fun.convertFechaAño(txtFechaIniEditar.Text), fun.convertFechaAño(txtFechaFinEditar.Text), lblCodProyecto.Text,dropEstado.SelectedValue))
                {
                    if (trepador.HasFile)
                    {
                        string[] variables = subirArchivo(trepador);
                        if (variables[0] == "error")
                        {
                            mostrarmensaje(variables[0], variables[1]);
                        }
                        else if (variables[0] == "exito")
                        {
                            if (pro.agregarAnexoProyecto(lblCodProyecto.Text, variables[2], variables[3], variables[4], variables[5], variables[7], variables[8]))
                            {
                                trepador.PostedFile.SaveAs(variables[6]);
                                //mostrarmensaje("exito", "Documento agregado correctamente.");
                            }
                            else
                            {
                                mostrarmensaje("error", "ERROR: No se logró agregar el documento.");
                            }
                        }
                    }
                    mostrarmensaje("exito", "Proyecto editado correctamente.");
                    gvcargarProyectos();
                }
                else
                {
                    mostrarmensaje("error", "ERROR: No se logro editar el proyecto.");
                    this.PanelEditar_Modalpopupextender.Show();
                }
            }
            else
            {
               
                if (pro.editarProyecto(txtProyectoEditar.Text, dropDepartamentoEditar.SelectedValue, "0", fun.convertFechaAño(txtFechaIniEditar.Text), fun.convertFechaAño(txtFechaFinEditar.Text), lblCodProyecto.Text, dropEstado.SelectedValue))
                {
                    if (trepador.HasFile)
                    {
                        string[] variables = subirArchivo(trepador);
                        if (variables[0] == "error")
                        {
                            mostrarmensaje(variables[0], variables[1]);
                        }
                        else if (variables[0] == "exito")
                        {
                            if (pro.agregarAnexoProyecto(lblCodProyecto.Text, variables[2], variables[3], variables[4], variables[5], variables[7], variables[8]))
                            {
                                trepador.PostedFile.SaveAs(variables[6]);
                                //mostrarmensaje("exito", "Documento agregado correctamente.");
                            }
                            else
                            {
                                mostrarmensaje("error", "ERROR: No se logró agregar el documento.");
                            }
                        }
                    }
                    gvcargarProyectos();
                    mostrarmensaje("exito", "Proyecto editado correctamente.");
                }
                else
                {
                    mostrarmensaje("error", "ERROR: No se logro editar el proyecto.");
                    this.PanelEditar_Modalpopupextender.Show();
                }
            }
        }
        else
        {
            this.PanelEditar_Modalpopupextender.Show();
            mostrarmensaje("error", "ERROR: La fecha de cierre debe ser mayor que la de inicio.");
        }
      
    }
    protected void dropDepartamentoEditar_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (dropDepartamentoEditar.SelectedIndex > 0)
        {
            ddMunicipios(dropMunicipioEditar, dropDepartamentoEditar.SelectedValue);
        }
    }
    private bool validarFechas(string fechaini,string fechafin)
    {
        bool valido = false;
        DateTime fechainidate = Convert.ToDateTime(fechaini);
        DateTime fechafindate = Convert.ToDateTime(fechafin);
        int var1 = DateTime.Compare(fechainidate, fechafindate);
        if (var1 < 0)
        {
            valido = true;
        }
        return valido;
    }
    protected void imgDlete_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string cod = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
       
        if (pro.eliminarProyecto(cod))
        {
            mostrarmensaje("exito", "Eliminado correctamente.");
            gvcargarProyectos();
        }
        else
        {
            mostrarmensaje("error", "ERROR: Este proyecto esta siendo usado");
        }
    }
    private string[] subirArchivo(FileUpload trepador)
    {
        string[] variables = new string[9];
        variables[0] = string.Empty; //estado mensaje
        variables[1] = string.Empty; //mensaje 
        variables[2] = string.Empty; //fileName    
        variables[3] = string.Empty; //fileNameSave
        variables[4] = string.Empty; //fileExtension
        variables[5] = string.Empty; //contentType
        variables[6] = string.Empty; //pathSave
        variables[7] = string.Empty; //pathsinmapSave
        variables[8] = string.Empty; //ContentLength

        //Calculadora de bytes: http://es.calcuworld.com/informatica/calculadora-de-bytes/
        int tamanofile;
        long tamanopermitido = 5242880;//Este dato está en bytes. 5242880 es 5MB, revisar el tamaño en el web.config (maxRequestLength) (kb). 31.700.160KB

        string contentType;
        string pathsinmap = "~/Documentos/";
        string path = Server.MapPath(pathsinmap);
        if (trepador.HasFile)
        {
            try
            {
                bool directorio = false;
                if (!Directory.Exists(path))
                {
                    try
                    {
                        Directory.CreateDirectory(path);
                        directorio = true;
                    }
                    catch (Exception exd)
                    {
                        variables[0] = "error"; // estado mensaje
                        variables[1] = "Error : " + exd.Message; //mensaje  
                        return variables;
                        //mostrarmensaje("error", "Error : " + exd.Message);    
                    }
                }
                else
                    directorio = true; //Ya existe el directorio                

                if (directorio == true)
                {
                    tamanofile = trepador.PostedFile.ContentLength;
                    contentType = trepador.PostedFile.ContentType;

                    if (tamanofile > 0 && tamanofile < tamanopermitido)
                    {
                        DateTime localDateTime = DateTime.Now;
                        DateTime utcDateTime = localDateTime.ToUniversalTime().AddHours(-5);
                        string horares = utcDateTime.ToString("yyyy-MM-dd_HHmmss");

                        string fileExtension = System.IO.Path.GetExtension(trepador.FileName).ToLower();
                        string fileName = System.IO.Path.GetFileName(trepador.PostedFile.FileName).Replace(",", " ");
                        string fileNameSave = horares + "_" +  fileExtension;
                        string pathSave = path + fileNameSave;
                        string pathsinmapSave = pathsinmap + fileNameSave;

                        String[] allowedExtensions = funallowedExtensions();
                        bool extOK = false;
                        for (int i = 0; i < allowedExtensions.Length; i++)
                        {
                            if (fileExtension == allowedExtensions[i])
                            {
                                extOK = true;
                                //para quitar el punto "." de la extension
                                string exte = trepador.PostedFile.FileName;
                                fileExtension = (exte.Substring(exte.LastIndexOf(".") + 1).ToLower());
                            }
                        }


                        if (extOK == false)
                        {
                            variables[0] = "error"; // estado mensaje
                            variables[1] = "Error: No se permite el formato " + fileExtension; //mensaje  
                            return variables;
                            //mostrarmensaje("error", "Error: No se permite el formato " + fileExtension);
                        }
                        else
                        {
                            variables[0] = "exito"; // estado mensaje
                            variables[1] = ""; //mensaje  
                            variables[2] = fileName;  //fileName    
                            variables[3] = fileNameSave; //fileNameSave
                            variables[4] = fileExtension; //fileExtension
                            variables[5] = contentType; //contentType
                            variables[6] = pathSave; //pathSave
                            variables[7] = pathsinmapSave; //pathsinmapSave
                            variables[8] = trepador.PostedFile.ContentLength.ToString(); //ContentLength

                            return variables;

                        }

                    }
                    else
                    {
                        long tan = (tamanopermitido / 1024) / 1024;
                        mostrarmensaje("error", "Tamaño no permitido, solo se aceptan: " + tan.ToString() + " MB");
                    }
                }
            }
            catch (Exception ex)
            {
                mostrarmensaje("error", "Error : " + ex.Message);
            }
        }
        else
        {
            variables[0] = "error"; // estado mensaje
            variables[1] = "Error: Debes seleccionar un archivo"; //mensaje  
            return variables;
            //mostrarmensaje("error", "Error: Debes seleccionar un archivo");
        }
        return variables;
    }
    private String[] funallowedExtensions()
    {
        String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg", ".doc", ".docx", "xlsx", "xls", ".rar", ".txt", ".pdf" };
        return allowedExtensions;
    }



    protected void imgDescargar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string filepath = Server.MapPath(HttpUtility.HtmlDecode(gvrow.Cells[4].Text));
        string filename = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
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
    protected void GridDocumentos_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string cod= GridDocumentos.Rows[e.RowIndex].Cells[1].Text;
        string savename = GridDocumentos.Rows[e.RowIndex].Cells[3].Text;

        if (pro.eliminarAnexoProyecto(cod))
        {
            if (System.IO.File.Exists(savename))
            {
                try
                {
                    System.IO.File.Delete(savename);
                     mostrarmensaje("exito", "Eliminado Correctamente");
                }
                catch (System.IO.IOException ex)
                {
                    mostrarmensaje("error", ex.Message);
                }
            }
            else
            {
                mostrarmensaje("exito", "Eliminado Correctamente");
            }

        }
        else
        {
            mostrarmensaje("error", "ERROR: No se logró eliminar el documento.");
        }
    }
}