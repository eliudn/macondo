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

public partial class verestras002 : System.Web.UI.Page
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
    protected void Page_Load(object sender, EventArgs e)
    {
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 
        if (!IsPostBack)
        {
            obtenerGET();
            if (Session["codrol"].ToString() == "2" || Session["codrol"].ToString() == "15" || Session["codrol"].ToString() == "11")//Coordinador / asesor CUC
            {
                lblTipoGrupo.Text = "Grupo de investigación";
            }
            else if (Session["codrol"].ToString() == "2" || Session["codrol"].ToString() == "15")//Coordinador / asesor FUNTICS
            {
                lblTipoGrupo.Text = "Red Temática";
            }
             if (Session["identificacion"] != null)
            {
                Estrategias estra = new Estrategias();
                DataRow dato = estra.buscarCodEstraAsesorxCoordinador(Session["identificacion"].ToString());

                if (dato != null)
                {
                    Session["CodAsesorCoordinador"] = dato["codigo"].ToString();
                    buscarUsuario();

                
                }
            }

             if (Session["codrol"].ToString() == "20")
             {
                 trepador.Visible = false;
                 this.GridEvidencias.Columns[12].Visible = false;
             }
        }
    }
    public void obtenerGET()
    {
        Session["e"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["e"]);
        Session["m"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["m"]);
        Session["s"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["s"]);
        Session["a"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["a"]);

      
        if (Session["e"] != null || Session["m"] != null || Session["s"] != null )
        {
            lblEstrategia.Text = Session["e"].ToString();
            lblMomento.Text = Session["m"].ToString();
            lblSesion.Text = Session["s"].ToString();
            if(Session["a"] != null)
                lblActividad.Text = Session["a"].ToString();
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
            

    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        if (Session["e"].ToString() == "1")
            Response.Redirect("estramomentos.aspx?m=" + lblMomento.Text);
        else if (Session["e"].ToString() == "2")
            Response.Redirect("estradosmomentos.aspx?m=" + lblMomento.Text + "&s=" + lblSesion.Text);
    }

    [WebMethod(EnableSession = true)]
    public static string cargarDepartamentoMagdalena()
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarDepartamentoMagdalena();

        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<option value='0' disabled selected>Seleccione departamento</option>";

            //ca += "@" + datoUsuario["cod"].ToString();
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
                //ca += datos.Rows[i]["codigo"].ToString() + "@" + datos.Rows[i]["nombre"].ToString();
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarMunicipios(string coddepartamento)
    {

        //Funciones fun = new Funciones();

        //fun.convertFechaAño();

        string ca = "";

        Institucion inst = new Institucion();

        DataTable municipios = inst.cargarciudadxDepartamento(coddepartamento);

        if (municipios != null && municipios.Rows.Count > 0)
        {
            ca = "municipio@";
            ca += "<option value='' disabled selected>Seleccione municipio...</option>";
            for (int i = 0; i < municipios.Rows.Count; i++)
            {
                ca += "<option value='" + municipios.Rows[i]["cod"].ToString() + "'>" + municipios.Rows[i]["nombre"].ToString() + "</option>";
            }
        }
        else
        {
            ca = "vacio@<option value='sin' disabled selected>Sin municipios</option>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarInstituciones(string codmunicipio)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarInstitucionxMunicipio(codmunicipio);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<option value='0' disabled selected>Seleccione institución</option>";

            //ca += "@" + datoUsuario["cod"].ToString();
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
                //ca += datos.Rows[i]["codigo"].ToString() + "@" + datos.Rows[i]["nombre"].ToString();
            }
        }
        else
        {
            ca = "vacio@<option value='sin' disabled selected>Sin institución</option>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarSedesInstitucion(string codInstitucion)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarSedesInstitucion(codInstitucion);
        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<option value='0' disabled selected>Seleccione sede</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarLineaInvestigacion(string codSede)
    {
        string ca = "";

        Institucion inst = new Institucion();

        Estrategias est = new Estrategias();

        if (HttpContext.Current.Session["codrol"] != null)
        {
            if (HttpContext.Current.Session["codrol"].ToString() == "10" || HttpContext.Current.Session["codrol"].ToString() == "11" || HttpContext.Current.Session["codrol"].ToString() == "2" || HttpContext.Current.Session["codrol"].ToString() == "15")//Coordinador / asesor UniMag - CUC
            {
                //Carga los grupos de investigación
                DataTable datos = est.cargarLineaInvestigacion(codSede);

                if (datos != null && datos.Rows.Count > 0)
                {
                    //ca = "redtematica@";
                    ca += "<option value='' disabled selected>Seleccione grupo de investigación</option>";
                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombregrupo"].ToString() + "</option>";
                    }
                }
            }
            else if (HttpContext.Current.Session["codrol"].ToString() == "12" || HttpContext.Current.Session["codrol"].ToString() == "13")//Coordinador / asesor FUNTICS
            {
                DataTable datos = inst.proccargarRedtematica(codSede, HttpContext.Current.Session["CodAsesorCoordinador"].ToString());

                if (datos != null && datos.Rows.Count > 0)
                {
                    //ca = "redtematica@";
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

    [WebMethod(EnableSession=true)]
    public static string cargarAsesores()
    {
        string ca = "";

        Estrategias estra = new Estrategias();

        DataTable datos = estra.cargarAsesores(HttpContext.Current.Session["CodAsesorCoordinador"].ToString());
        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "<option value='0' disabled selected>Seleccione Asesor</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + " " + datos.Rows[i]["apellido"].ToString() + "</option>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string encabezado(string codProyecto, string codAsesor, string noAsesoria, string fechaVisita, string duracionHoras, string tipoAcompaniamiento, string motivoAsesoria, string objetivo, string noproyectadas)
    {
        string ca = "";
        Estrategias estra = new Estrategias();
        Funciones fun = new Funciones();
        HttpContext.Current.Session["codredtematicasede"] = codProyecto;
        DataRow row = estra.encabezadoS002(codProyecto, codAsesor, noAsesoria, fun.convertFechaAño(fechaVisita), duracionHoras, tipoAcompaniamiento, motivoAsesoria, objetivo, HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString(), noproyectadas,"");
        if (row != null)
        {
            ca += row["codigo"];
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string actividades(string codEstraS002, string actividad, string noactividad)
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        if (estra.guardarActividades(codEstraS002, actividad, noactividad))
        {
            ca += "Datos almacenados exitosamente";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string compromisos(string codEstraS002, string compromiso, string fechaCumplimiento, string responsable, string nocompromiso)
    {
        string ca = "";
        Estrategias estra = new Estrategias();
        Funciones fun = new Funciones();

        if (estra.guardarCompromisos(codEstraS002, compromiso, fun.convertFechaAño(fechaCumplimiento), responsable, nocompromiso))
        {
            ca += "Datos almacenados exitosamente";
        }

        return ca;
    }

    //Evidencias
    Funciones fun = new Funciones();
    protected void btnSubirFirmaPop_Click(object sender, EventArgs e)
    {
        Response.Write("Esta ingresando al boton");
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
            Estrategias usu = new Estrategias();
            //Reposi rep = new Reposi();

            //if (dato == null)
            //{


            if (usu.agregarArchivoRespositorioEstrategia2AsesorS002(lblCodUsuario.Text, variables[2], variables[3], variables[4], variables[5], variables[7], Convert.ToInt32(variables[8]), fun.getFechaAñoHoraActual(), lblMomento.Text, lblSesion.Text, rbtActividades.SelectedValue, lblEstrategia.Text, HttpContext.Current.Session["cods002evidencia"].ToString()))
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
            pathsinmap = "~/Estrategia_2/";
        else
            pathsinmap = "~/Estrategia_2/" + HttpContext.Current.Request.ApplicationPath.Remove(0, 1) + "/";
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
        String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg" };
        return allowedExtensions;
    }

    private void gvCargarEvidencias()
    {
        DataTable datos = est.cargarEvidenciasEstrategia2AsesorS002(lblMomento.Text, lblSesion.Text, lblEstrategia.Text, HttpContext.Current.Session["cods002evidencia"].ToString());
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

    private void buscarUsuario()
    {
        Usuario usu = new Usuario();
        DataRow dato = usu.buscarUsuario(Session["codusuario"].ToString());
        if (dato != null)
        {
            lblCodUsuario.Text = dato["cod"].ToString();
        }

    }

    protected void btnBuscarEvidencias_Onclik(object sender, EventArgs e)
    {
        if (Session["e"] != null || Session["m"] != null || Session["s"] != null)
        {
            if (HttpContext.Current.Session["cods002evidencia"] != null)
            {
                gvCargarEvidencias();
                string script = @"<script type='text/javascript'>
                               $('#evidencias').show();$('#form').hide();$('#table').hide();
                        </script>";

                ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);  
                Session["evidencias"]="OK";
            }
            else
            {
                mostrarmensaje("error", "Seleccione antes el Registro de Asesoría.");
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
                               $('#evidencias').hide();$('#form').hide();$('#table').show();
                        </script>";

        ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, false);
        Session["evidencias"] = "OK";
    }

    /*2016-10-24 05:08 pm JONNY PACHECO metodo para  listar instrumento s002*/

    [WebMethod(EnableSession = true)]
    public static string listarInstrumentos002(string codasesorcoordinador)
    {
        Institucion inst = new Institucion();
        string ca = "";

        DataTable datos = inst.listarInstrumentos002Supervision(codasesorcoordinador, HttpContext.Current.Session["e"].ToString(), HttpContext.Current.Session["m"].ToString(), HttpContext.Current.Session["s"].ToString());
        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["departamento"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombregrupo"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["fechavisita"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["asesor"].ToString() + "</td>";
                ca += "<td style='padding:5px;' ><a class='btn btn-success' onclick=\"$('#evidencias').hide(),$('#table').hide(), $('#form').fadeIn(500), loadSelectInstrumentos002(" + datos.Rows[i]["codProyecto"].ToString() + "),cargarInstrumentos002(" + datos.Rows[i]["codigo"].ToString() + "),listaractividadess002(" + datos.Rows[i]["codigo"].ToString() + "),listarcompromisoss002(" + datos.Rows[i]["codigo"].ToString() + ") \">Ver</a><br/ ><br/ ><a class='btn btn-primary' onclick=\"evidencias(" + datos.Rows[i]["codigo"].ToString() + ")\">Evidencias</a></td>";
                ca += "</tr>";
            }
        }
        else
        {
            ca += "<tr><td colspan='10'>No se encontraron Registros por parte del asesor.</td></tr>";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadSelectInstrumentos002(string codProyecto)
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataRow dato = estra.loadSelectInstrumentos002(codProyecto);
        if (dato != null)
        {
            ca += "loadSelect@";
            ca += "<option value='" + dato["codigodepartamento"].ToString() + "'>" + dato["nombredepartamento"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigomunicipio"].ToString() + "'>" + dato["nombremunicipio"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigoinstitucion"].ToString() + "'>" + dato["nombreinstitucion"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigosede"].ToString() + "'>" + dato["nombresede"].ToString() + "</option>@";
            ca += "<option value='" + dato["codigogrupoinvestigacion"].ToString() + "'>" + dato["nombregrupoinvestigacion"].ToString() + "</option>@";
            ca += "<option value='" + dato["codasesor"].ToString() + "'>" + dato["nombre"].ToString() + " " + dato["apellido"].ToString() + "</option>";
        }
        return ca;
    }
    /*2016-10-26  07:14 pm JONNY PACHECO*/
    [WebMethod(EnableSession = true)]
    public static string cargarInstrumentos002(string codigo)
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataRow dato = estra.cargarInstrumentos002(codigo);
        if (dato != null)
        {
            ca += "load@";
            ca += dato["noasesoria"].ToString() + "@";
            ca += dato["noproyectadas"].ToString() + "@";
            ca += dato["fechavisita"].ToString() + "@";
            ca += dato["duracion_horas"].ToString() + "@";
            ca += dato["tipoasesoria"].ToString() + "@";
            ca += dato["motivoasesoria"].ToString() + "@";
            ca += dato["objetivo"].ToString() + "@";
            ca += dato["noasistentes"].ToString();

        }
        return ca;
    }
    /*2016-10-26  09:31 pm*/
    [WebMethod(EnableSession = true)]
    public static string listaractividadess002(string codigo)
    {
        string ca = "load@";
        Estrategias estra = new Estrategias();

        DataTable datos = estra.listaractividadess002(codigo);
        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                
                ca += datos.Rows[i]["actividades"].ToString() + "@";
            }
        }
        

        return ca;

    }
    /*2016-10-28 8:50 am*/
    [WebMethod(EnableSession = true)]
    public static string listarcompromisoss002(string codigo)
    {
        string ca = "load@";
        Estrategias estra = new Estrategias();

        DataTable datos = estra.listarcompromisoss002(codigo);
        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {

                ca += datos.Rows[i]["compromiso"].ToString() + "|";
                ca += datos.Rows[i]["fechacumplimiento"].ToString() + "|";
                ca += datos.Rows[i]["responsable"].ToString() + "@";
            }
        }


        return ca;

    }

    [WebMethod(EnableSession=true)]
    public static string deleteactividadess002(string codinstrumento)
    {
        Estrategias estra = new Estrategias();
        string ca = "";

        long delete = estra.deleteactividadess002(codinstrumento);
        if (delete != -1)
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al eliminar actividades@";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string deletecompromisoss002(string codinstrumento)
    {
        Estrategias estra = new Estrategias();
        string ca = "";

        long delete = estra.deletecompromisoss002(codinstrumento);
        if (delete != -1)
        {
            ca = "true@";
        }
        else
        {
            ca = "Ocurrio un error al eliminar actividades@";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string updates002(string codestrategia, string noasesoria, string noproyectadas, string fechavisita, string duracionhoras, string tipoacompaniamiento, string motivoasesoria, string objetivo)
    {
        Estrategias estra = new Estrategias();
        Funciones fun = new Funciones();
        string ca = "";
        if (estra.actualizarEncabezadoS002(codestrategia, noasesoria, fechavisita, duracionhoras, tipoacompaniamiento, motivoasesoria, objetivo, noproyectadas,""))
        {
            ca += "true@";
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string loadactividadess002(string codigo)
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataTable actividades = estra.listaractividadess002(codigo);
        if (actividades != null && actividades.Rows.Count > 0)
        {
            ca += "loadactividad@";
            int total = 1;
            for (int i = 0; i < actividades.Rows.Count; i++)
            {
                ca += "<tr id=\"campus" + total + "\">";
                ca += "<td>" + total + ". </td>";
                ca += "<td ><input type=\"text\"  id =\"actividad" + total + "\" name =\"actividad" + total + "\"  class=\"TextBox\" value=\"" + actividades.Rows[i]["actividades"].ToString() + "\" >";

                if (i == actividades.Rows.Count - 1)
                {
                    ca += "<button id=\"remove\" class=\"btn btn-danger\" onclick=\"fRemove(" + total + ")\" > - </button></td>";
                }
                else
                {
                    ca += "</td>";
                    total++;
                }
                ca += "</tr>";
            }
            ca += "@" + total;
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string evidencias(string codigo)
    {
        string ca = "";
        HttpContext.Current.Session["cods002evidencia"] = codigo;

        //estras002 est = new estras002();
        //est.gvCargarEvidencias();

        ca = codigo;
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarasesores()
    {
        string ca = "";
        Estrategias estra = new Estrategias();

        DataTable asesores = estra.listarAsesoresSeguimiento("1");

        if (asesores != null && asesores.Rows.Count > 0)
        {
            ca += "<option value='0' selected disabled>Seleccione asesor...</option>";
            for (int i = 0; i < asesores.Rows.Count; i++)
            {
                ca += "<option value='" + asesores.Rows[i]["codigo"].ToString() + "'>" + asesores.Rows[i]["asesor"].ToString().ToUpper() + "</option>";
            }
        }

        return ca;
    }

}