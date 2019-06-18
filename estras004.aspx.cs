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



public partial class estras004 : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            obtenerGET();
            DataRow dato = est.buscarCodEstraAsesorxCoordinador(Session["identificacion"].ToString());

            if (dato != null)
            {
                Session["CodAsesorEstraCoordinador"] = dato["codigo"].ToString();
                buscarUsuario();
                Session["nombreasesor"] = dato["nombre"].ToString();
                //gvCargarEvidencias();
            }

            if (Session["codrol"].ToString() == "10" || Session["codrol"].ToString() == "11" || Session["codrol"].ToString() == "2" || Session["codrol"].ToString() == "15")//Coordinador / asesor UniMag - CUC
            {
                lblTipoGrupo.Text = "Grupo de investigación";
            } 
            else  if (Session["codrol"].ToString() == "12" || Session["codrol"].ToString() == "13")//Coordinador / asesor FUNTICS
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
    public static string cargarInstituciones(string codMunicipio)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.proccargarInstitucionxMunicipio(codMunicipio);

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
    public static string insertestras004(string redtematica, string nombresesion, string temasesion, string informacionadicional, string fechaelaboracion, string nombrerelator, string horasesion, string horasesionfinal, string aspectosdesarrollados, string conclusiones, string bibliografia, string desarrollo1, string compromisos, string evaluacionsesion, string nohoras)
    {

        Institucion inst = new Institucion();
        string ca = "";
        estras004 estra = new estras004();
        Funciones fun = new Funciones();

        DataRow insert = inst.insertestras004(redtematica, nombresesion, temasesion, informacionadicional, fun.convertFechaAño(fechaelaboracion), nombrerelator, horasesion, horasesionfinal, HttpContext.Current.Session["CodAsesorEstraCoordinador"].ToString(), aspectosdesarrollados, conclusiones, bibliografia, desarrollo1, compromisos, evaluacionsesion, HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString(), nohoras);

        if (insert != null)
        {
            ca += "true@";
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
    public static string loadestras004(string codigo)
    {
        string ca = "";
        Funciones fun = new Funciones();
        Institucion inst = new Institucion();

        DataRow datosinstrumento = inst.proloadestras004(codigo, HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString());

        if (datosinstrumento != null)
        {
            //HttpContext.Current.Session["codredtematicasede"] = redtematica;
            //codigo, codestracoordinador, nombresesion,temasesion, informacionadicional, fechaelaboracion, nombrerelator, aspectosdesarrollados, conclusiones, bibliografia
            ca = "datosintrumentoestras004p";
            ca += datosinstrumento["codigo"].ToString()
            + "estras004p" + datosinstrumento["nombresesion"].ToString()
            + "estras004p" + datosinstrumento["temasesion"].ToString()
            + "estras004p" + datosinstrumento["informacionadicional"].ToString()
            + "estras004p" + datosinstrumento["fechaelaboracion"].ToString()
            + "estras004p" + datosinstrumento["nombrerelator"].ToString()
            + "estras004p" + datosinstrumento["aspectosdesarrollados"].ToString()
            + "estras004p" + datosinstrumento["conclusiones"].ToString()
            + "estras004p" + datosinstrumento["bibliografia"].ToString()
            + "estras004p" + datosinstrumento["desarrollo1"].ToString()
            + "estras004p" + datosinstrumento["compromisos"].ToString()
            + "estras004p" + datosinstrumento["evaluacionsesion"].ToString()
            + "estras004p" + datosinstrumento["horasesion"].ToString()
            + "estras004p" + datosinstrumento["horasesionfinal"].ToString()
            + "estras004p" + datosinstrumento["nohoras"].ToString();
            //+ "@" + datosinstrumento["nosesiones"].ToString();

        }
        else
        {
            ca = "vacio@";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string updateestras004(string codigoestrategia, string redtematica, string nombresesion, string temasesion, string informacionadicional, string fechaelaboracion, string nombrerelator, string horasesion, string horasesionfinal, string aspectosdesarrollados, string conclusiones, string bibliografia, string desarrollo1, string compromisos, string evaluacionsesion, string nohoras)
    {

        Funciones fun = new Funciones();

        Institucion inst = new Institucion();
        string ca = "";

        long update = inst.procupdateestras004(codigoestrategia, redtematica, nombresesion, temasesion, informacionadicional, fechaelaboracion, nombrerelator, horasesion, horasesionfinal, aspectosdesarrollados, conclusiones, bibliografia, desarrollo1, compromisos, evaluacionsesion, nohoras);
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
    public static string deleteestras004(string codigo)
    {
        string ca = "";
        Institucion inst = new Institucion();
        Estrategias est = new Estrategias();
        if (inst.eliminarMemoriaS004(codigo))
        {
            DataTable datos = est.buscarEvidenciaEstrategia4AsesorRedTematicaxUsuario(codigo, HttpContext.Current.Session["codusuarioev"].ToString());

            if(datos != null && datos.Rows.Count > 0)
            {
                for (int i = 0; i < datos.Rows.Count; i++)
                {
                    if (est.borrarEvidenciaEstrategia4AsesorRedTematica(datos.Rows[i]["cod"].ToString()))
                    {

                        if (File.Exists(HttpContext.Current.Server.MapPath(datos.Rows[i]["path"].ToString())))
                        {
                            try
                            {
                                File.Delete(HttpContext.Current.Server.MapPath(datos.Rows[i]["path"].ToString()));
                            }
                            catch
                            {
                            }
                        }

                    }
                }
                    
            }

           

            DataRow dat = est.buscarG001_Estrategia4(codigo);

            if(dat != null)
            {
                est.eliminarDetalleG001_Estrategia4(dat["codigo"].ToString());
                est.eliminarG001_Estrategia4(codigo);
            }

            
         
            ca = "delete@";
        }
        else
        {
            ca = "vacio@";
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

        DataTable datos = inst.procloadPreguntass004(codigoestrategia);

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
    public static string cargarRedtematica(string codsede)
    {
        string ca = "";

        Institucion inst = new Institucion();

        Estrategias est = new Estrategias();

        if(HttpContext.Current.Session["codrol"] != null)
        {
            if (HttpContext.Current.Session["codrol"].ToString() == "10" || HttpContext.Current.Session["codrol"].ToString() == "11" || HttpContext.Current.Session["codrol"].ToString() == "2" || HttpContext.Current.Session["codrol"].ToString() == "15")//Coordinador / asesor UniMag - CUC
            {
                //Carga los grupos de investigación
                DataTable datos = est.cargarLineaInvestigacionxAsesor(codsede, HttpContext.Current.Session["CodAsesorEstraCoordinador"].ToString());

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
                DataTable datos = inst.proccargarRedtematica(codsede, HttpContext.Current.Session["CodAsesorEstraCoordinador"].ToString());

                if (datos != null && datos.Rows.Count > 0)
                {
                    ca = "redtematica@";
                    //ca += "<option value='' disabled selected>Seleccione Red Temática</option>";
                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        ca += "<input type='checkbox' id='redtematica_" + (i+1) + "' name='redestematicas' value='" + datos.Rows[i]["codigo"].ToString() + "' />" + datos.Rows[i]["redtematica"].ToString();
                        //ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["redtematica"].ToString() + "</option>";
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
            Session["codusuarioev"] = lblCodUsuario.Text;
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
                        string fileNameSave = horares + "_" + Session["codusuario"].ToString() + fileExtension;
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
        //DataTable datos = est.cargarEvidenciasEstrategia4AsesorRedTematica(HttpContext.Current.Session["codredtematicasede"].ToString());
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

        //    //string script = "cargarDataTable();";
        //    //if (ScriptManager1.IsInAsyncPostBack)
        //    //{
        //    //    ScriptManager.RegisterStartupScript(this, typeof(Page), "scriptkey", script, true);
        //    //}
        //    //else
        //    //{
        //    //    ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), script, true);
        //    //}
        //}
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
        DataRow dato = usu.buscarEvidenciaEstrategia4AsesorRedTematica(cod);
        if (usu.borrarEvidenciaEstrategia4AsesorRedTematica(cod))
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
               GridEvidencias.Visible = true;
               gvCargarEvidencias();
               lblDatos.Text = HttpContext.Current.Session["codredtematicasede"].ToString();
               string script = @"<script type='text/javascript'>
                               $('#evidencias').show();$('#formTable').hide();$('#listTable').hide();
                        </script>";

               ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);  
              
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

    protected void btnVolver_Onclik(object sender, EventArgs e)
    {
        string script = @"<script type='text/javascript'>
                               $('#evidencias').hide();$('#formTable').hide();$('#listTable').fadeIn(500);
                        </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);

      
        GridEvidencias.Visible = false;
    }

    //Listado de memorias por asesor
    [WebMethod(EnableSession = true)]
    public static string cargarListadoMemoriaAsesor()
    {
        //int pagint = Convert.ToInt32(page);
        //int rowsint = 10;
        //int offset = (pagint - 1) * rowsint;

        string ca = "";
        string backward = "";
        string info = "";
        string forward = "";
        Funciones fun = new Funciones();
        Estrategias estra = new Estrategias();

        DataTable datos = estra.cargarListadoMemoriasS004Todo(HttpContext.Current.Session["CodAsesorEstraCoordinador"].ToString(), HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString());

        if (datos != null && datos.Rows.Count > 0)
        {
            DataTable datosCount = estra.cargarListadoMemoriasCount(HttpContext.Current.Session["CodAsesorEstraCoordinador"].ToString(), HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString());//Saber la cantidad de registros en la consulta

            double cant = datosCount.Rows.Count;
            double val = Math.Ceiling(cant / 10);

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
                ca += "<td>" + fun.convertFechaAño(datos.Rows[i]["fechaelaboracion"].ToString()) + "</td>";
                ca += "<td>" + datos.Rows[i]["momento"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["sesion"].ToString() + "</td>";
                ca += "<td align=\"center\"><br /><a class='btn btn-success' onclick=\"$('#listTable').hide(), $('#formTable').fadeIn(500), loadInstrumento(" + datos.Rows[i]["codigo"].ToString() + ")\">Editar</a><br/ ><br /><a target=\"_blank\" href=\"estras004Evidencia.aspx?codinstrumentos004=" + datos.Rows[i]["codigo"].ToString() + " \" class=\"btn btn-primary\">Evidencias</a><br/ ><br /><a href=\"estrag001_estrategia4.aspx?codinstrumentos004=" + datos.Rows[i]["codigo"].ToString() + "&codredtematicasede=" + datos.Rows[i]["codredtematicasede"].ToString() + " \" class=\"btn btn-success\">Asistencias</a><br/ ><br /><a onclick=\"eliminar(" + datos.Rows[i]["codigo"].ToString() + ")\" class=\"btn btn-danger\">Eliminar</a><br /><br /><a class='btn btn-primary' onclick=\"$('#listTable').hide(), $('#modificarsesion').fadeIn(500);$('#formTable').hide();buscarSesionMemoria(" + datos.Rows[i]["codigo"].ToString() + ")\">Modificar Sesión</a><br/ ><br /></td>";
                ca += "</tr>";
            }
            ca += "@";

            //if (offset == 0)
            //{
            //    backward = "<li><a href='javascript:void(0);'><img src='Imagenes/flechaIn.png' /></a></li>";
            //}
            //else
            //{
            //    backward = "<li><a href='javascript:void(0);' onclick='cargarListadoMemorias(\"" + (pagint - 1) + "\")'><img src='Imagenes/flechaIn.png' /></a></li>";
            //    //HttpContext.Current.Session["pageS004Ant"] = (pagint - 1);
            //}

            //if ((offset + rowsint) <= Convert.ToInt32(cant))
            //{
            //    info = "<li><a href='javascript:void(0);'>" + (offset + 1) + " - " + (offset + rowsint) + " de " + cant + "</a></li>";
            //}
            //else if (cant == 0)
            //{
            //    info = "<li><a href='javascript:void(0);'> <p>0 - 0 de 0</p></a></li>";
            //}
            //else
            //{
            //    info = "<li><a href='javascript:void(0);'><p>" + (offset + 1) + " - " + cant + " de " + cant + "</p></a></li>";
            //}

            //if ((offset + rowsint) >= Convert.ToInt32(cant))
            //{
            //    forward = "<li><a href='javascript:void(0);'><li><img src='Imagenes/flechaOut.png' /></a></li>";
            //}
            //else
            //{
            //    forward = "<li><a href='javascript:void(0);' onclick='cargarListadoMemorias(\"" + (pagint + 1) + "\")' ><img src='Imagenes/flechaOut.png' /></a></li>";
            //    //HttpContext.Current.Session["pageS004Sig"] = (pagint + 1);
            //}

            //ca += backward + info + forward;
        }
        else
        {
            ca += "<tr><td colspan='11' align='center'>No se encontraron memorias registradas por parte del asesor.</td></tr>";
        }

        return ca;
    }


    //Cargar Departamento
    [WebMethod(EnableSession = true)]
    public static string cargarDepartamentoMagdalena()
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarDepartamentoMagdalena();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "departamento@";
            ca += "<option value='' disabled selected>Seleccione departamento</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    //Cargar municipios
    [WebMethod(EnableSession = true)]
    public static string cargarMunicipioMagdalena(string codDepartamento)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarciudadxDepartamento(codDepartamento);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "municipio@";
            ca += "<option value='' disabled selected>Seleccione municipio</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadSelectInstrumento(string codigo)
    {
        string ca = "";
        Estrategias estra = new Estrategias();
        Institucion inst = new Institucion();

        DataRow dato = estra.loadSelectInstrumentos004(codigo);
        if (dato != null)
        {
            ca += "loadSelect@";
            ca += "<option value='" + dato["codigodepartamento"].ToString() + "'>" + dato["nombredepartamento"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigomunicipio"].ToString() + "'>" + dato["nombremunicipio"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigoinstitucion"].ToString() + "'>" + dato["nombreinstitucion"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigosede"].ToString() + "'>" + dato["nombresede"].ToString() + "</option>@";

            if (HttpContext.Current.Session["codrol"] != null)
            {
                if (HttpContext.Current.Session["codrol"].ToString() == "10" || HttpContext.Current.Session["codrol"].ToString() == "11" || HttpContext.Current.Session["codrol"].ToString() == "2" || HttpContext.Current.Session["codrol"].ToString() == "15")//Coordinador / asesor UniMag - CUC
                {
                    //Carga los grupos de investigación
                    DataTable datos = estra.cargarLineaInvestigacion(dato["codigosede"].ToString());

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
                    DataTable datos = inst.proccargarRedtematica(dato["codigosede"].ToString(), HttpContext.Current.Session["CodAsesorEstraCoordinador"].ToString());

                    if (datos != null && datos.Rows.Count > 0)
                    {
                        //ca += "<option value='' disabled>Seleccione Red Temática</option>";
                        for (int i = 0; i < datos.Rows.Count; i++)
                        {
                            if (datos.Rows[i]["codigo"].ToString() == dato["codigoredtematica"].ToString())
                            {
                                ca += "<input type='checkbox' id='redtematica_" + (i + 1) + "' name='redestematicas' value='" + datos.Rows[i]["codigo"].ToString() + "' disabled checked/>" + datos.Rows[i]["redtematica"].ToString();
                                ca += "@" + (i + 1);
                            }
                                
                                //ca += "<option value='" + dato["codigoredtematica"].ToString() + "' selected>" + dato["redtematica"].ToString() + "</option>";
                            //else
                                //ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["redtematica"].ToString() + "</option>";
                        }
                    }
                }

            }

           
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string regresar()
    {
        string ca = "";

        ca = HttpContext.Current.Session["e"].ToString() + "@" + HttpContext.Current.Session["m"].ToString() + "@" + HttpContext.Current.Session["s"].ToString();

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadEvidencias(string codigo)
    {
        string ca = "";
        //Estrategias estra = new Estrategias();
        //DataTable datos = estra.cargarEvidenciasEstrategia4AsesorRedTematica( codigo);

        //if (datos != null && datos.Rows.Count > 0)
        //{
        //    ca += "evidencias@";
        //    for (int i = 0; i < datos.Rows.Count; i++)
        //    {
        //        ca += "<tr>";
        //        ca += "<td>" + (i + 1) + "</td>";
        //        ca += "<td>" + datos.Rows[i]["nombrearchivo"].ToString() + "</td>";
        //        ca += "<td>" + datos.Rows[i]["ext"].ToString() + "</td>";
        //        ca += "<td>" + datos.Rows[i]["tamano"].ToString() + "</td>";
        //        ca += "<td>" + datos.Rows[i]["fechacreado"].ToString() + "</td>";
        //        ca += "<td>" + datos.Rows[i]["pnombre"].ToString() + " " + datos.Rows[i]["papellido"].ToString() + "</td>";
        //        ca += "<td style='padding:7px;'><a class=''><img src='Imagenes/down.png' title='Descargar archivo' style='cursor:pointer;'></a></td>";
        //        ca += "</tr>";
        //    }
        //}
        //else
        //{
        //    ca += "vacio@";
        //    ca += "<tr><td colspan='5'>No se encontraron evidencias registradas por parte del asesor.</td></tr>";
        //}

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string evidencias(string codigo)
    {
        string ca = "";
        ca = codigo;
        HttpContext.Current.Session["codredtematicasede"] = codigo;

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string verificarPaginado()
    {
        string ca = "";

        if (HttpContext.Current.Session["pageS004"] == null)
            ca = "1";
        else
            ca = HttpContext.Current.Session["pageS004"].ToString();

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string buscarSesionMemoria(string codigo)
    {
        string ca = "";

        Estrategias est = new Estrategias();

        DataRow memoria = est.buscarDatosMemoria(codigo);

        if (memoria != null)
        {
            ca = memoria["sesion"].ToString() + "@<tr>";
            ca += "<td>" + memoria["redtematica"].ToString() + "</td>";
            ca += "<td>" + memoria["sesion"].ToString() + "</td>";
            ca += "</tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string guardarSesion(string codmemoria, string sesion)
    {
        string ca = "";

        Estrategias est = new Estrategias();

       if(est.actualizarSesionenMemoria(codmemoria, sesion))
       {
           
       }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarTemas()
    {
        string ca = "";

        switch (HttpContext.Current.Session["s"].ToString())
        {
            case "2":
                ca = "Preparándome para el proceso Gózate la ciencia y mejora tus capacidades investigativas a través de comunidades virtuales.";
                break;

            case "3":
                ca = "Las rutas para gozarme la ciencia y mejorar mis capacidades investigativas a través de comunidades virtuales.";
                break;

            case "4":
                ca = "Encarrílate con la investigación.";
                break;

            case "5":
                ca = "Haciéndole el juego a la ciencia desde la virtualidad.";
                break;

            case "6":
                ca = "Pa ciencia con las herramientas.";
                break;

            case "7":
                ca = "En las ferias la investigación es una fiesta.";
                break;

            case "8":
                ca = "Gocémonos la ciencia respetando los derechos de autor.";
                break;

            case "9":
                ca = "El goce de preparar el informe de nuestra investigación.";
                break;

            case "10":
                ca = "Las niñas, los niños y los jóvenes nos gozamos la ciencia divulgando nuestro trabajo.";
                break;

        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarnomasesor()
    {
        string ca = "";

        if (HttpContext.Current.Session["nombreasesor"] != null)
        {
            ca = "nombre@" + HttpContext.Current.Session["nombreasesor"].ToString();
        }

        return ca;
    }
}