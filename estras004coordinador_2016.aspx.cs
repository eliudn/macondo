using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Drawing;
using System.Web.Services;
using System.IO;

public partial class estras004coordinador_2016 : System.Web.UI.Page
{

    Estrategias est = new Estrategias();


    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["codperfil"] != null)
        {

        }
        else
            Response.Redirect("Default.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 
        PanelEdicion.Attributes.Add("style", "display:none");
        if (!IsPostBack)
        {
            obtenerGET();
            DataRow dato = est.buscarCodEstraAsesorxCoordinador(Session["identificacion"].ToString());

            if (dato != null)
            {
                Session["CodAsesorEstraCoordinador"] = dato["codigo"].ToString();
                buscarUsuario();
                //gvCargarEvidencias();
            }

            if (Session["codrol"].ToString() == "10" || Session["codrol"].ToString() == "11" || Session["codrol"].ToString() == "2" || Session["codrol"].ToString() == "15")//Coordinador / asesor UniMag - CUC
            {
                lblTipoGrupo.Text = "Grupo de investigación";
            }
            else if (Session["codrol"].ToString() == "12" || Session["codrol"].ToString() == "13" || Session["codrol"].ToString() == "20")//Coordinador / asesor FUNTICS
            {
                lblTipoGrupo.Text = "Red Temática";
            }
        }
    }
    public void obtenerGET()
    {
        Session["e"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["e"]);
        Session["m"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        Session["s"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
        lblEstrategia.Text = Session["e"].ToString();
        lblMomento.Text = Session["m"].ToString();
        lblSesion.Text = Session["s"].ToString();
    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        if (Session["e"] != null || Session["m"] != null || Session["s"] != null)
        {
            if (Session["e"].ToString() == "2")
                Response.Redirect("estradosmomentos.aspx?m=" + lblMomento.Text +"&s=" + lblSesion.Text);
            else if (Session["e"].ToString() == "4")
                Response.Redirect("estracuatromomentos.aspx?m=" + lblMomento.Text);
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
       
    }


    [WebMethod(EnableSession = true)]
    public static string cargarInstituciones()
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarInstitucion();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "inst@";
            ca += "<option value='0' disabled selected>Seleccione institución</option>";

            //ca += "@" + datoUsuario["cod"].ToString();
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
                //ca += datos.Rows[i]["codigo"].ToString() + "@" + datos.Rows[i]["nombre"].ToString();
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarsedes(string codigoins)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarSedesInstitucion(codigoins);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "sedes@";
            ca += "<option value='' disabled selected>Seleccione Sede</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }



    [WebMethod(EnableSession = true)]
    public static string insertestras004(string redtematica, string nombresesion, string temasesion, string informacionadicional, string fechaelaboracion, string nombrerelator, string horasesion, string aspectosdesarrollados, string conclusiones, string bibliografia)
    {

        Institucion inst = new Institucion();
        string ca = "";
        Funciones fun = new Funciones();

        DataRow insert = inst.insertestras004(redtematica, nombresesion, temasesion, informacionadicional, fun.convertFechaAño(fechaelaboracion), nombrerelator, horasesion, HttpContext.Current.Session["CodAsesorEstraCoordinador"].ToString(), aspectosdesarrollados, conclusiones, bibliografia, HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString(),"","","","","");

        if (insert != null)
        {
            ca = "true@";
            ca += insert["codigo"].ToString();
            HttpContext.Current.Session["codredtematicasede"] = redtematica;
        }
        else
        {
            ca = "Ocurrio un error al insertar ests004@";
        }


        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string loadestras004(string codigoestra)
    {
        string ca = "";
        Funciones fun = new Funciones();
        Institucion inst = new Institucion();

        DataRow datosinstrumento = inst.proloadestras004_2016(codigoestra, HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString());

        if (datosinstrumento != null)
        {
            //HttpContext.Current.Session["codredtematicasede"] = redtematica;
            //codigo, codestracoordinador, nombresesion,temasesion, informacionadicional, fechaelaboracion, nombrerelator, aspectosdesarrollados, conclusiones, bibliografia
            ca = "datosintrumento@";
            ca += datosinstrumento["codigo"].ToString()
            + "@" + datosinstrumento["nombresesion"].ToString()
            + "@" + datosinstrumento["temasesion"].ToString()
            + "@" + datosinstrumento["informacionadicional"].ToString()
            + "@" + datosinstrumento["fechaelaboracion"].ToString()
            + "@" + datosinstrumento["nombrerelator"].ToString()
            + "@" + datosinstrumento["aspectosdesarrollados"].ToString()
            + "@" + datosinstrumento["conclusiones"].ToString()
            + "@" + datosinstrumento["bibliografia"].ToString();

        }
        else
        {
            ca = "vacio@";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string updateestras004(string codigoestrategia, string redtematica, string nombresesion, string temasesion, string informacionadicional, string fechaelaboracion, string nombrerelator, string horasesion, string aspectosdesarrollados, string conclusiones, string bibliografia)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        long update = inst.procupdateestras004(codigoestrategia, redtematica, nombresesion, temasesion, informacionadicional, fechaelaboracion, nombrerelator, horasesion, aspectosdesarrollados, conclusiones, bibliografia,"","","","","");
        if (update != -1)
        {
            ca = "true@";
        }
        else
        {
            ca = "false@";
            ca += "Ocurrio un error al actualizar datos de estras004@";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string deletePreguntass004(string codigoestrategia)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        long delete = inst.procdeletePreguntass004(codigoestrategia);
        if (delete != -1)
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al eliminar preguntas@";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string insertPreguntas(string codigoestrategia, string nopregunta, string pregunta)
    {

        Institucion inst = new Institucion();
        string ca = "";

        DataRow insert = inst.procinsertPreguntass004(codigoestrategia, nopregunta, pregunta);
        if (insert != null)
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al insertar preguntas " + nopregunta + "@";
        }

        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string loadPreguntass004(string codigoestrategia, int total)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.procloadPreguntass004_2016(codigoestrategia);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "mat@";
            ca += "<tr><th width=\"5%\"> No. </th>";
            ca += "<th> Pregunta </th>";
            ca += "</tr> ";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr id=\"campus" + total + "\">";
                ca += "<td>" + total + ". </td>";
                ca += "<td ><input type=\"text\"  id =\"pregunta" + total + "\" name =\"pregunta" + total + "\"  class=\"width-90 TextBox\" value=\"" + datos.Rows[i]["pregunta"].ToString() + "\" >";

                if (i == datos.Rows.Count - 1)
                {
                    ca += "<button id=\"remove\" class=\"btn btn-danger\" onclick=\"fRemove(" + total + ")\" > - </button></td>";
                }
                else
                {
                    ca += "</td>";
                    total = total + 1;
                }
                ca += "</tr>";


            }
            ca += "@" + total;
        }
        else
        {
            ca = "vacio@";
            ca += "<tr><th width=\"5%\"> No. </th>";
            ca += "<th> Pregunta </th>";
            ca += "</tr> ";
            ca += "<tr>";
            ca += "<td>1.</td>";
            ca += "<td ><input type=\"text\" class=\"TextBox width-90\" id=\"pregunta1\" name=\"pregunta1\" ></td>";
            ca += "</tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarRedtematica(string codsede, string codasesorcoordinador)
    {
        string ca = "";

        Institucion inst = new Institucion();

        Estrategias est = new Estrategias();

        if(HttpContext.Current.Session["codrol"] != null)
        {
            if (HttpContext.Current.Session["codrol"].ToString() == "10" || HttpContext.Current.Session["codrol"].ToString() == "11" || HttpContext.Current.Session["codrol"].ToString() == "2" || HttpContext.Current.Session["codrol"].ToString() == "15")//Coordinador / asesor UniMag - CUC
            {
                //Carga los grupos de investigación
                DataTable datos = est.cargarLineaInvestigacion(codsede);

                if (datos != null && datos.Rows.Count > 0)
                {
                    ca = "redtematica@";
                    ca += "<option value='' disabled selected>Seleccione grupo de investigación</option>";
                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombregrupo"].ToString() + "</option>";
                    }
                }
            }
            else if (HttpContext.Current.Session["codrol"].ToString() == "12" || HttpContext.Current.Session["codrol"].ToString() == "13")//Coordinador / asesor FUNTICS
            {
                DataTable datos = inst.proccargarRedtematica(codsede, codasesorcoordinador);

                if (datos != null && datos.Rows.Count > 0)
                {
                    ca = "redtematica@";
                    ca += "<option value='' disabled selected>Seleccione Red Temática</option>";
                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["redtematica"].ToString() + "</option>";
                    }
                }
            }
            
        }
  
        return ca;
    }

    //cargue de evidencias

    protected void btnSubirFirmaPop_Click(object sender, EventArgs e)
    {
        Response.Write("Esta ingresando al boton");
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
            if (HttpContext.Current.Session["codredtematicasede"] != null)
            {
                if (usu.agregarArchivoRespositorioEstrategia4AsesorRedTemaica(lblCodUsuario.Text, variables[2], variables[3], variables[4], variables[5], variables[7], Convert.ToInt32(variables[8]), fun.getFechaAñoHoraActual(), lblMomento.Text, lblSesion.Text, rbtActividades.SelectedValue, "4", HttpContext.Current.Session["codredtematicasede"].ToString()))
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
            else
            {
                string script = @"<script type='text/javascript'>
                                alert('Debe Diligenciar el instrumento.');
                        </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false); 
            }
            //else if (lblMomento.Text == "1")
            //{
            //    if (usu.agregarArchivoRespositorioEstrategia(lblCodUsuario.Text, variables[2], variables[3], variables[4], variables[5], variables[7], Convert.ToInt32(variables[8]), fun.getFechaAñoHoraActual(), lblMomento.Text, lblSesion.Text, rbtMomento1.SelectedValue, "1"))
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
        //DataTable datos = est.cargarEvidenciasEstrategia4AsesorRedTematica(lblMomento.Text, lblSesion.Text, "4", HttpContext.Current.Session["codredtematicasede"].ToString(), lblCodUsuario.Text);
        //GridEvidencias.DataSource = datos;
        //GridEvidencias.DataBind();

        //if (datos != null && datos.Rows.Count > 0)
        //{
        //    GridEvidencias.UseAccessibleHeader = true;
        //    if (GridEvidencias.HeaderRow != null)
        //    {
        //        GridEvidencias.HeaderRow.TableSection = TableRowSection.TableHeader;
        //    }
        //    if (GridEvidencias.ShowFooter)
        //        GridEvidencias.FooterRow.TableSection = TableRowSection.TableFooter;

          
        //}
    }

    protected void imgEditar_Click(object sender, ImageClickEventArgs e)
    {
        //ImageButton btndetails = sender as ImageButton;
        //GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        //string cod = GridEvidencias.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  
        //string cc = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);// IP Antena
        //string coddane = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);// IP Antena

    }

    protected void DeleteButton_Click(object sender, ImageClickEventArgs e)
    {
        //ImageButton btndetails = sender as ImageButton;
        //GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
        //string cod = GridEvidencias.DataKeys[gvrow.RowIndex].Value.ToString(); //Obtener del DataKey de la Row  

        //borrarImagen(cod);

    }

    private void borrarImagen(string cod)
    {
        Estrategias usu = new Estrategias();
        DataRow dato = usu.buscarEvidenciaEstrategia(cod);
        if (usu.borrarEvidenciaEstrategia(cod))
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

    protected void btnBuscarEvidencias_Onclik(object sender, EventArgs e)
    {
        if (Session["e"] != null || Session["m"] != null || Session["s"] != null)
        {
            if (HttpContext.Current.Session["codredtematicasede"] != null)
           {
               gvCargarEvidencias();
              
           }
           else
           {
               string script = @"<script type='text/javascript'>
                                alert('Debe Diligenciar el instrumento.');
                        </script>";

               ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);  
           }
        }
        else
        {
            Response.Redirect("estracuatromomentos.aspx");
        }

    }

    //Listado de memorias por asesor
    [WebMethod(EnableSession = true)]
    public static string cargarListadoMemoriaAsesor(string codAsesor, string page, string anio)
    {
        string ca = "";
        string backward = "";
        string info = "";
        string forward = "";

        Estrategias estra = new Estrategias();
        Funciones fun = new Funciones();

        string codusuario ="";
        Usuario usu = new Usuario();
        DataRow dato = usu.buscarUsuarioAsesorxCodAsesorCoordinador(codAsesor);
        if (dato != null)
        {
            codusuario = dato["cod"].ToString();

        }


        int pagint = Convert.ToInt32(page);
        int rowsint = 10;
        int offset = (pagint - 1) * rowsint;

        DataTable datos = estra.cargarListadoMemorias_2016Coor(codAsesor, Convert.ToString(offset), Convert.ToString(rowsint), anio);

        HttpContext.Current.Session["codasesor"] = codAsesor;

        if (datos != null && datos.Rows.Count > 0)
        {

            DataTable datosCount = estra.cargarListadoMemoriasCountCoord_2016Coor(codAsesor, anio);

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["nombredepartamento"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombremunicipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombreinstitucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombresede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombresesion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombre"].ToString() + " " + datos.Rows[i]["consecutivogrupo"].ToString() + "</td>";
                ca += "<td>" + fun.convertFechaDia(datos.Rows[i]["fechaelaboracion"].ToString()) + "</td>";
                ca += "<td>" + datos.Rows[i]["momento"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["sesion"].ToString() + "</td>";
                ca += "<td align='center'><a class='btn btn-success' onclick=\"$('#listTable').hide(), $('#formTable').fadeIn(500), loadInstrumento(" + datos.Rows[i]["codigo"].ToString() + ")\">Ver</a><br/><br/><a class='btn btn-primary' href='estras004CoordEvidencia.aspx?cod=" + datos.Rows[i]["codigo"].ToString() + "&cu=" + codusuario + "' >Evidencias</a></td>";
             
                ca += "</tr>";
            }

            double cant = datosCount.Rows.Count;
            double val = Math.Ceiling(cant / 10);

            ca += "@";

            if (offset == 0)
            {
                backward = "<li><a href='javascript:void(0);'><img src='Imagenes/flechaIn.png' /></a></li>";
            }
            else
            {

                backward = "<li><a href='javascript:void(0);'  onclick='cargarListadoMemorias(\"" + codAsesor + "\",\"" + (pagint + 1) + "\",\"" + anio + "\")'><img src='Imagenes/flechaIn.png' /></a></li>";
            }

            if ((offset + rowsint) <= Convert.ToInt32(cant))
            {
                info = "<li><a href='javascript:void(0);'>" + (offset + 1) + " - " + (offset + rowsint) + " de " + cant + "</a></li>";
            }
            else if (cant == 0)
            {
                info = "<li><a href='javascript:void(0);'> <p>0 - 0 de 0</p></a></li>";
            }
            else
            {
                info = "<li><a href='javascript:void(0);'><p>" + (offset + 1) + " - " + cant + " de " + cant + "</p></a></li>";
            }

            if ((offset + rowsint) >= Convert.ToInt32(cant))
            {
                forward = "<li><a href='javascript:void(0);'><li><img src='Imagenes/flechaOut.png' /></a></li>";
            }
            else
            {
                forward = "<li><a href='javascript:void(0);' onclick='cargarListadoMemorias(\"" + codAsesor + "\",\"" + (pagint + 1) + "\",\"" + anio + "\")' ><img src='Imagenes/flechaOut.png' /></a></li>";
            }

            ca += backward + info + forward;

        }
        else
        {
            ca += "<tr><td colspan='10'>No se encontraron memorias registradas por parte del asesor.</td></tr>";
        }

        return ca;
    }
    [WebMethod(EnableSession = true)]
    public static string cargarAnios()
    {
        string ca = "";
        Institucion inst = new Institucion();

        DataTable anios = inst.cargarAnios();

        if (anios != null && anios.Rows.Count > 0)
        {
            ca += "<option value='0' selected disabled>Seleccione año</option>";
            for (int i = 0; i < anios.Rows.Count; i++)
            {
                if (anios.Rows[i]["nombre"].ToString().ToUpper() == "2016")
                {
                    ca += "<option value='" + anios.Rows[i]["codigo"].ToString() + "'>" + anios.Rows[i]["nombre"].ToString().ToUpper() + "</option>";
                }
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarAsesores()
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataTable asesores = estra.listarAsesores(HttpContext.Current.Session["e"].ToString());

        if (asesores != null && asesores.Rows.Count > 0)
        {
            ca += "<option value='0' selected disabled>Seleccione asesor</option>";
            for (int i = 0; i < asesores.Rows.Count; i++)
            {
                ca += "<option value='" + asesores.Rows[i]["codigo"].ToString() + "'>" + asesores.Rows[i]["asesor"].ToString().ToUpper() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadSelectInstrumento(string codigo)
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataRow dato = estra.loadSelectInstrumentos004_2016(codigo);
        if (dato != null)
        {
            ca += "loadSelect@";
            ca += "<option value='" + dato["codigodepartamento"].ToString() + "'>" + dato["nombredepartamento"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigomunicipio"].ToString() + "'>" + dato["nombremunicipio"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigoinstitucion"].ToString() + "'>" + dato["nombreinstitucion"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigosede"].ToString() + "'>" + dato["nombresede"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigoredtematica"].ToString() + "'>" + dato["redtematica"].ToString() + "</option>";
        }
        return ca;
    }

}