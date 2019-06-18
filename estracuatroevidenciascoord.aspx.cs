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

public partial class estracuatroevidenciascoord : System.Web.UI.Page
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
                lblEncabezados.Text = encabezado();

                if (lblMomento.Text == "0" && lblSesion.Text == "0" && lblActividad.Text == "1")
                {
                    PanelMomento0.Visible = true;
                    lblTitulo.Text = "Lineamientos y ruta metodológica de la estrategia";
                }
                else if (lblMomento.Text == "0" && lblSesion.Text == "0" && lblActividad.Text == "2")
                {
                    PanelMomento0Actividad2.Visible = true;
                    lblTitulo.Text = "Desarrollo de la actividad";
                }
                    
              
           

                gvCargarEvidencias();
 
                buscarUsuario();

                if (Session["codrol"].ToString() == "20")
                {
                    btnActualizarDatosTutoria.Visible = false;
                    trepador.Visible = false;
                    this.GridEvidencias.Columns[12].Visible = false;
                }
            }
            else
            {
                Response.Redirect("bienvenida.aspx");
            }
        
        }
    }
    public void obtenerGET()
    {
       lblMomento.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
       lblSesion.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
       lblActividad.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["a"]);
    }
    private string encabezado()
    {
        string ca = "";

        ca += "<b>Momento: </b>" + lblMomento.Text + " - " + "<b>Sesión:</b> " + lblSesion.Text + "<br/> ";

        return ca;
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

   
    Funciones fun = new Funciones();
   
    protected void btnActualizarDatosTutoria_Click(object sender, EventArgs e)
    {

        string[] variables = subirArchivo(trepador);

        if (variables[0] == "error")
        {
            mostrarmensaje(variables[0], variables[1]);
        }
        else if (variables[0] == "exito")
        {
            Estrategias usu = new Estrategias();
            //Reposi rep = new Reposi();

            //if (dato == null)
            //{
            if (lblMomento.Text == "0" && lblSesion.Text == "0" && lblActividad.Text == "1")
            {
                if (usu.agregarArchivoRespositorioEstrategia4(lblCodUsuario.Text, variables[2], variables[3], variables[4], variables[5], variables[7], Convert.ToInt32(variables[8]), fun.getFechaAñoHoraActual(), lblMomento.Text, lblSesion.Text,  lblActividad.Text, rbtActividades.SelectedValue, "4"))
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
                    mostrarmensaje("error", "Error al subir archivo.");
                }
            }
            if (lblMomento.Text == "0" && lblSesion.Text == "0" && lblActividad.Text == "2")
            {
                if (usu.agregarArchivoRespositorioEstrategia4(lblCodUsuario.Text, variables[2], variables[3], variables[4], variables[5], variables[7], Convert.ToInt32(variables[8]), fun.getFechaAñoHoraActual(), lblMomento.Text, lblSesion.Text, lblActividad.Text, rbtActividades2.SelectedValue, "4"))
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
                    mostrarmensaje("error", "Error al subir archivo.");
                }
            }
            //else if (lblMomento.Text == "3")
            //{
            //    if (usu.agregarArchivoRespositorioEstrategia(lblCodUsuario.Text, variables[2], variables[3], variables[4], variables[5], variables[7], Convert.ToInt32(variables[8]), fun.getFechaAñoHoraActual(), lblMomento.Text, lblSesion.Text, rbtMomento3.SelectedValue, "1"))
            //    {
            //        gvCargarEvidencias();
            //        //lblCodImgPerfil.Text = "1";
            //        trepador.PostedFile.SaveAs(variables[6]);
            //        mostrarmensaje("exito", "Se ha cargado con éxito.");
            //        //imgPerfil.ImageUrl = variables[7];
            //        //btnSubirFirmaPop.Text = "Cambiar Imagen";
            //    }
            //    else
            //    {
            //        mostrarmensaje("error", "Error al subir archivo.");
            //    }
            //}
            //else if (lblMomento.Text == "4")
            //{
            //    if (usu.agregarArchivoRespositorioEstrategia(lblCodUsuario.Text, variables[2], variables[3], variables[4], variables[5], variables[7], Convert.ToInt32(variables[8]), fun.getFechaAñoHoraActual(), lblMomento.Text, lblSesion.Text, rbtMomento4.SelectedValue, "1"))
            //    {
            //        gvCargarEvidencias();
            //        //lblCodImgPerfil.Text = "1";
            //        trepador.PostedFile.SaveAs(variables[6]);
            //        mostrarmensaje("exito", "Se ha cargado con éxito.");
            //        //imgPerfil.ImageUrl = variables[7];
            //        //btnSubirFirmaPop.Text = "Cambiar Imagen";
            //    }
            //    else
            //    {
            //        mostrarmensaje("error", "Error al subir archivo.");
            //    }
            //}

                
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
            pathsinmap = "~/Estrategia_4/";
        else
            pathsinmap = "~/Estrategia_4/" + HttpContext.Current.Request.ApplicationPath.Remove(0, 1) + "/";
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
                        string fileNameSave =  horares + "_" + lblCodUsuario.Text + fileExtension;
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
        String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg", ".doc", ".docx", ".xlsx", ".xls", ".rar", ".txt", ".pdf" };
        return allowedExtensions;
    }

    //protected void GridClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GridEvidencias.PageIndex = e.NewPageIndex;

    //    gvCargarEvidencias();

    //}

    private void gvCargarEvidencias()
    {
        DataTable datos = null;

        if (lblActividad.Text == "1")
        {
            datos = est.cargarEvidenciasEstrategia4(lblMomento.Text, lblSesion.Text, lblActividad.Text, "4");
        }
        else if (lblActividad.Text == "2")
        {
            datos = est.cargarEvidenciasEstrategia4Acti2(lblMomento.Text, lblSesion.Text, lblActividad.Text, "4");
        }
        
        
        
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
        DataRow dato = usu.buscarEvidenciaEstrategia4(cod);
        if (usu.borrarEvidenciaEstrategia4(cod))
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
        Response.Redirect("estracuatromomentos.aspx?m=" + lblMomento.Text);
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