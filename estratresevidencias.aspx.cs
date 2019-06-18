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

public partial class estratresevidencias : System.Web.UI.Page
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
                if (lblProceso.Text != "" || lblProceso.Text != null)
                {
                    ddAnio(dropanio);
                    lblEncabezados.Text = encabezado();

                    if (Session["codrol"].ToString() == "20")
                    {
                        btnActualizarDatosTutoria.Visible = false;
                        trepador.Visible = false;
                        this.GridEvidencias.Columns[9].Visible = false;
                        gvCargarEvidenciasI();
                    }
                    else
                    {
                        buscarUsuario();
                        gvCargarEvidencias();
                    }
                }
                else
                {
                    mostrarmensaje("error","No se recibieron los parámetros");
                }
            }
        
        }
    }
    public void obtenerGET()
    {
       lblProceso.Text = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["p"]);
    }
    private string encabezado()
    {
        string ca = "";

        switch (lblProceso.Text)
        {
            case "p":
                ca = "Planeación";
                planeacion.Visible = true;
                break;
            case "p_2":
                ca = "Planeación";
                planeacion_2.Visible = true;
                break;
            case "p_3":
                ca = "Planeación";
                planeacion_3.Visible = true;
                break;
            case "p_4":
                ca = "Planeación";
                planeacion_4.Visible = true;
                break;
            case "e":
                ca = "Evaluación";
                evaluacion.Visible = true;
                break;
            case "e_2":
                ca = "Evaluación intermedia";
                evaluacion_2.Visible = true;
                break;
            case "e_3":
                ca = "Evaluación final";
                evaluacion_3.Visible = true;
                break;
            case "m":
                ca = "Primer monitoreo";
                monitoreo.Visible = true;
                break;
            case "m_2":
                ca = "Segundo monitoreo";
                monitoreo_2.Visible = true;
                break;
            case "m_3":
                ca = "Tercer monitoreo";
                monitoreo_3.Visible = true;
                break;
            case "s":
                ca = "Seguimiento";
                seguimiento.Visible = true;
                break;
            case "ac":
                ca = "Apropiación y Comunicación";
                apropiacion.Visible = true;
                break;
            case "ac_2":
                ca = "Apropiación y Comunicación";
                apropiacion_2.Visible = true;
                break;
            case "si":
                ca = "Sistematización";
                sistematizacion.Visible = true;
                break;
        }

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

    private void ddAnio( DropDownList item)
    {
        Institucion est = new Institucion();
        DataTable datos = est.cargarAnios();
        item.DataSource = datos;
        item.DataValueField = "codigo";
        item.DataTextField = "nombre";
        item.DataBind();
        item.Items.Insert(0, new System.Web.UI.WebControls.ListItem("Seleccione"));
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

            switch (lblProceso.Text)
            {
                case "p":
                    if (usu.agregarArchivoRespositorioEstrategia3(lblCodUsuario.Text, variables[2], variables[3], variables[4], variables[5], variables[7], Convert.ToInt32(variables[8]), fun.getFechaAñoHoraActual(), dropanio.SelectedValue, rbtPlaneacion.SelectedValue, lblProceso.Text))
                    {
                        trepador.PostedFile.SaveAs(variables[6]);
                        mostrarmensaje("exito", "Se ha cargado con éxito.");
                    }
                    else
                    {
                        mostrarmensaje("error", "Error al subir archivo.");
                    }
                    break;
                case "p_2":
                    if (usu.agregarArchivoRespositorioEstrategia3(lblCodUsuario.Text, variables[2], variables[3], variables[4], variables[5], variables[7], Convert.ToInt32(variables[8]), fun.getFechaAñoHoraActual(), dropanio.SelectedValue, rbtPlaneacion_2.SelectedValue, lblProceso.Text))
                    {
                        trepador.PostedFile.SaveAs(variables[6]);
                        mostrarmensaje("exito", "Se ha cargado con éxito.");
                    }
                    else
                    {
                        mostrarmensaje("error", "Error al subir archivo.");
                    }
                    break;
                case "p_3":
                    if (usu.agregarArchivoRespositorioEstrategia3(lblCodUsuario.Text, variables[2], variables[3], variables[4], variables[5], variables[7], Convert.ToInt32(variables[8]), fun.getFechaAñoHoraActual(), dropanio.SelectedValue, rbtPlaneacion_3.SelectedValue, lblProceso.Text))
                    {
                        trepador.PostedFile.SaveAs(variables[6]);
                        mostrarmensaje("exito", "Se ha cargado con éxito.");
                    }
                    else
                    {
                        mostrarmensaje("error", "Error al subir archivo.");
                    }
                    break;
                case "p_4":
                    if (usu.agregarArchivoRespositorioEstrategia3(lblCodUsuario.Text, variables[2], variables[3], variables[4], variables[5], variables[7], Convert.ToInt32(variables[8]), fun.getFechaAñoHoraActual(), dropanio.SelectedValue, rbtPlaneacion_4.SelectedValue, lblProceso.Text))
                    {
                        trepador.PostedFile.SaveAs(variables[6]);
                        mostrarmensaje("exito", "Se ha cargado con éxito.");
                    }
                    else
                    {
                        mostrarmensaje("error", "Error al subir archivo.");
                    }
                    break;
                case "e":
                    if (usu.agregarArchivoRespositorioEstrategia3(lblCodUsuario.Text, variables[2], variables[3], variables[4], variables[5], variables[7], Convert.ToInt32(variables[8]), fun.getFechaAñoHoraActual(), dropanio.SelectedValue, rbtEvaluacion.SelectedValue, lblProceso.Text))
                    {
                        trepador.PostedFile.SaveAs(variables[6]);
                        mostrarmensaje("exito", "Se ha cargado con éxito.");
                    }
                    else
                    {
                        mostrarmensaje("error", "Error al subir archivo.");
                    }
                    break;
                case "e_2":
                    if (usu.agregarArchivoRespositorioEstrategia3(lblCodUsuario.Text, variables[2], variables[3], variables[4], variables[5], variables[7], Convert.ToInt32(variables[8]), fun.getFechaAñoHoraActual(), dropanio.SelectedValue, rbtEvaluacion_2.SelectedValue, lblProceso.Text))
                    {
                        trepador.PostedFile.SaveAs(variables[6]);
                        mostrarmensaje("exito", "Se ha cargado con éxito.");
                    }
                    else
                    {
                        mostrarmensaje("error", "Error al subir archivo.");
                    }
                    break;
                case "e_3":
                    if (usu.agregarArchivoRespositorioEstrategia3(lblCodUsuario.Text, variables[2], variables[3], variables[4], variables[5], variables[7], Convert.ToInt32(variables[8]), fun.getFechaAñoHoraActual(), dropanio.SelectedValue, rbtEvaluacion_3.SelectedValue, lblProceso.Text))
                    {
                        trepador.PostedFile.SaveAs(variables[6]);
                        mostrarmensaje("exito", "Se ha cargado con éxito.");
                    }
                    else
                    {
                        mostrarmensaje("error", "Error al subir archivo.");
                    }
                    break;
                case "m":
                    if (usu.agregarArchivoRespositorioEstrategia3(lblCodUsuario.Text, variables[2], variables[3], variables[4], variables[5], variables[7], Convert.ToInt32(variables[8]), fun.getFechaAñoHoraActual(), dropanio.SelectedValue, rbtMonitoreo.SelectedValue, lblProceso.Text))
                    {
                        trepador.PostedFile.SaveAs(variables[6]);
                        mostrarmensaje("exito", "Se ha cargado con éxito.");
                    }
                    else
                    {
                        mostrarmensaje("error", "Error al subir archivo.");
                    }
                    break;
                case "m_2":
                    if (usu.agregarArchivoRespositorioEstrategia3(lblCodUsuario.Text, variables[2], variables[3], variables[4], variables[5], variables[7], Convert.ToInt32(variables[8]), fun.getFechaAñoHoraActual(), dropanio.SelectedValue, rbtMonitoreo_2.SelectedValue, lblProceso.Text))
                    {
                        trepador.PostedFile.SaveAs(variables[6]);
                        mostrarmensaje("exito", "Se ha cargado con éxito.");
                    }
                    else
                    {
                        mostrarmensaje("error", "Error al subir archivo.");
                    }
                    break;
                case "m_3":
                    if (usu.agregarArchivoRespositorioEstrategia3(lblCodUsuario.Text, variables[2], variables[3], variables[4], variables[5], variables[7], Convert.ToInt32(variables[8]), fun.getFechaAñoHoraActual(), dropanio.SelectedValue, rbtMonitoreo_3.SelectedValue, lblProceso.Text))
                    {
                        trepador.PostedFile.SaveAs(variables[6]);
                        mostrarmensaje("exito", "Se ha cargado con éxito.");
                    }
                    else
                    {
                        mostrarmensaje("error", "Error al subir archivo.");
                    }
                    break;
                case "s":
                    if (usu.agregarArchivoRespositorioEstrategia3(lblCodUsuario.Text, variables[2], variables[3], variables[4], variables[5], variables[7], Convert.ToInt32(variables[8]), fun.getFechaAñoHoraActual(), dropanio.SelectedValue, rbtSeguimiento.SelectedValue, lblProceso.Text))
                    {
                        trepador.PostedFile.SaveAs(variables[6]);
                        mostrarmensaje("exito", "Se ha cargado con éxito.");
                    }
                    else
                    {
                        mostrarmensaje("error", "Error al subir archivo.");
                    }
                    break;
                case "ac":
                    if (usu.agregarArchivoRespositorioEstrategia3(lblCodUsuario.Text, variables[2], variables[3], variables[4], variables[5], variables[7], Convert.ToInt32(variables[8]), fun.getFechaAñoHoraActual(), dropanio.SelectedValue, rbtApropiacion.SelectedValue, lblProceso.Text))
                    {
                        trepador.PostedFile.SaveAs(variables[6]);
                        mostrarmensaje("exito", "Se ha cargado con éxito.");
                    }
                    else
                    {
                        mostrarmensaje("error", "Error al subir archivo.");
                    }
                    break;
                case "ac_2":
                    if (usu.agregarArchivoRespositorioEstrategia3(lblCodUsuario.Text, variables[2], variables[3], variables[4], variables[5], variables[7], Convert.ToInt32(variables[8]), fun.getFechaAñoHoraActual(), dropanio.SelectedValue, rbtApropiacion_2.SelectedValue, lblProceso.Text))
                    {
                        trepador.PostedFile.SaveAs(variables[6]);
                        mostrarmensaje("exito", "Se ha cargado con éxito.");
                    }
                    else
                    {
                        mostrarmensaje("error", "Error al subir archivo.");
                    }
                    break;
                case "si":
                    if (usu.agregarArchivoRespositorioEstrategia3(lblCodUsuario.Text, variables[2], variables[3], variables[4], variables[5], variables[7], Convert.ToInt32(variables[8]), fun.getFechaAñoHoraActual(), dropanio.SelectedValue, rbtSistematizacion.SelectedValue, lblProceso.Text))
                    {
                        trepador.PostedFile.SaveAs(variables[6]);
                        mostrarmensaje("exito", "Se ha cargado con éxito.");
                    }
                    else
                    {
                        mostrarmensaje("error", "Error al subir archivo.");
                    }
                    break;
            }
            gvCargarEvidencias();
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
        long tamanopermitido = 4194304; // Este dato está en bytes. 4194304 es 4MB, revisar el tamaño en el web.config (maxRequestLength) (kb). 31.700.160KB

        string contentType;
        string pathsinmap = "";
        if (HttpContext.Current.Request.ApplicationPath.Remove(0, 1) == "")
            pathsinmap = "~/Estrategia_3/";
        else
            pathsinmap = "~/Estrategia_3/" + HttpContext.Current.Request.ApplicationPath.Remove(0, 1) + "/";
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

  
    private void gvCargarEvidencias()
    {
        DataTable datos = est.cargarEvidenciasEstrategia3(lblProceso.Text, lblCodUsuario.Text);
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

    private void gvCargarEvidenciasI()
    {
        DataTable datos = est.cargarEvidenciasEstrategia3I(lblProceso.Text);
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
        DataRow dato = usu.buscarEvidenciaEstrategia3(cod);
        if (usu.borrarEvidenciaEstrategia3(cod))
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
        Response.Redirect("estratresmomentos.aspx");
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
}