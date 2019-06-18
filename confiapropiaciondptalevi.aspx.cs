using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.IO;

public partial class confiapropiaciondptalevi : System.Web.UI.Page
{
    Funciones fun = new Funciones();
    Estrategias est = new Estrategias();
    Institucion inst = new Institucion();
    Estudiantes estu = new Estudiantes();
    protected void Page_Load(object sender, EventArgs e)
    {
        PanelEditarDatos.Attributes.Add("style", "display:none");
        PanelUpload.Attributes.Add("style", "display:none");
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 
        if (!IsPostBack)
        {
            if (Session["codrol"] != null)
            {
                buscarUsuario();
                ObtenerGet();
                gvCargarEvidencias();
            }
            else
            {
                Response.Redirect("bienvenida.aspx");
            }
        }
    }

   
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    private void ObtenerGet()
    {
        lblCodEspacio.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["cod"]);
        lblTipo.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["tipo"]);
    }
    //Evidencias
    
    protected void btnSubirFirmaPop_Click(object sender, EventArgs e)
    {
        Response.Write("Esta ingresando al boton");
    }
    protected void btnRegresar_click(object sender, EventArgs e)
    {
        Response.Redirect("confiapropiaciondptal.aspx?tipo=" + lblTipo.Text);
    }
    protected void btnActualizarDatosTutoria_Click(object sender, EventArgs e)
    {

        string[] variables = subirArchivo(trepador);

        if (variables[0] == "error")
        {
            mostrarmensaje(variables[0], variables[1]);
        }
        else if (variables[0] == "exito")
        {
            Estrategias est = new Estrategias();
            //Reposi rep = new Reposi();

            //if (dato == null)
            //{


            if (est.agregarArchivoRespositorioEspacioApropiacion(lblCodUsuario.Text, variables[2], variables[3], variables[4], variables[5], variables[7], Convert.ToInt32(variables[8]), fun.getFechaAñoHoraActual(), lblCodEspacio.Text, rbtActividades.SelectedValue, fun.convertFechaAño(txtFechaIni.Text), fun.convertFechaAño(txtFechaFin.Text), drophorainicio.SelectedValue, drophorafin.SelectedValue, txtLugar.Text, txtDocentes.Text, txtEstudiantes.Text))
            {
                gvCargarEvidencias();
                //lblCodImgPerfil.Text = "1";
                trepador.PostedFile.SaveAs(variables[6]);
                mostrarmensaje("exito", "Se ha cargado con éxito.");
                //imgPerfil.ImageUrl = variables[7];
                //btnSubirFirmaPop.Text = "Cambiar Imagen";
            }
            else
            {
                mostrarmensaje("error", "Error al Guardar");
            }

            //}
            //else
            //{

            //    //Procedimiento de borrar

            //}
        }
        else
        {
            mostrarmensaje("error", "ERROR: Verifique la imagen.");
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
        long tamanopermitido = 4194304;//Este dato está en bytes. 4194304 es 4MB, revisar el tamaño en el web.config (maxRequestLength) (kb). 31.700.160KB

        string contentType;
        string pathsinmap = "";
        if (HttpContext.Current.Request.ApplicationPath.Remove(0, 1) == "")
            pathsinmap = "~/Ferias_municipales/";
        else
            pathsinmap = "~/Ferias_municipales/" + HttpContext.Current.Request.ApplicationPath.Remove(0, 1) + "/";
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
                        string fileNameSave = horares + "_" + lblCodUsuario.Text + fileExtension;
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
    public String[] funallowedExtensions()
    {
        String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg", ".doc", ".docx", ".xls", ".xlsx", ".pdf", ".rar", ".zip", ".mp3", ".gsm" };
        return allowedExtensions;
    }

    private void gvCargarEvidencias()
    {
        DataTable datos = est.cargarEvidenciasEspacioApropiacion(lblCodEspacio.Text, lblCodUsuario.Text);
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

            //string script = "cargarDataTable();";
            //if (ScriptManager1.IsInAsyncPostBack)
            //{
            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "scriptkey", script, true);
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), script, true);
            //}
        }
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
        DataRow dato = usu.buscarEvidenciaEspacioApropiacion(cod);
        if (usu.borrarEvidenciaEspacioApropiacion(cod))
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


    protected void imgDescargar_Click(object sender, ImageClickEventArgs e)
    {
        // mostrarmensaje("error", "");
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string filepath = Server.MapPath(HttpUtility.HtmlDecode(gvrow.Cells[7].Text));
        string filename = HttpUtility.HtmlDecode(gvrow.Cells[6].Text);
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

    protected void imgEditar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string cod = GridEvidencias.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        lblID.Text = cod;
        llenarCampos(cod);


        this.PanelEditarDatos_ModalPopupExtender.Show();
    }
    private void llenarCampos(string cod)
    {
        DataRow dat = inst.buscardatosApropiacion(cod);

        if (dat != null)
        {
            txtFechainicioedit.Text = fun.convertFechaDia(dat["fechainicio"].ToString());
            txtFechafinedit.Text = fun.convertFechaDia(dat["fechafin"].ToString());
            drophorainicioedit.SelectedValue = dat["horainicio"].ToString();
            drophorafinedit.SelectedValue = dat["horafin"].ToString();
            txtLugarEdit.Text = dat["lugar"].ToString();
            txtDocentesEdit.Text = dat["nodocentes"].ToString();
            txtEstudiantesEdit.Text = dat["noestudiantes"].ToString();
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        PanelEditarDatos_ModalPopupExtender.Hide();
    }
    protected void btnEditar_Click(object sender, EventArgs e)
    {
        if (inst.editarDatosApropiacionEvidencia(lblID.Text, fun.convertFechaDia(txtFechainicioedit.Text), fun.convertFechaDia(txtFechafinedit.Text), drophorainicioedit.SelectedValue, drophorafinedit.SelectedValue, txtLugarEdit.Text, txtDocentesEdit.Text, txtEstudiantesEdit.Text))
      {
          mostrarmensaje("exito","Editado correctamente");
          gvCargarEvidencias();
      }
        else
        {
            mostrarmensaje("error", "Error al Editar");
        }
    }
    private void buscarUsuario()
    {
        Usuario usu = new Usuario();
        DataRow dato = usu.buscarUsuario(Session["codusuario"].ToString());
        if (dato != null)
        {
            lblCodUsuario.Text = dato["cod"].ToString();
        }

    }

    protected void rbtActividadesBuscar_OnSelectedIndexChanged(object sender, EventArgs e)
    {
        gvCargarEvidencias();
    }

    protected void imgSubir_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton btndetails = sender as ImageButton;
        GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        string cod = GridEvidencias.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        lblID.Text = cod;
        llenarCampos(cod);


        this.PanelUpload_ModalPopupExtender.Show();
    }

    protected void btnCancelar2_Click(object sender, EventArgs e)
    {
        PanelEditarDatos_ModalPopupExtender.Hide();
    }

}