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
using System.Web.Services;
using System.Text;

public partial class detalleDocenteInteermedia : System.Web.UI.Page
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

                buscarUsuario();
            }
        }
    }
    public void obtenerGET()
    {
        Session["resp"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["resp"]);

        
        titulo.Text = "Docentes beneficiados por el Proyecto que participan en la evaluación intermedia";
        subtitulo.Text = "Indicador: total de docentes que participaron en la evaluación intermedia según último nivel educativo aprobado. ";
        descripcion.Text = "";
                       
       
   


    }
    private string encabezado()
    {
        string ca = "";

        //ca += "<b>Momento: </b>" + lblMomento.Text + " - " + "<b>Sesión:</b> " + lblSesion.Text + "<br/> ";

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
            //ca += "<option value='' selected>Todos</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option selected value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    //Cargar municipios
    [WebMethod(EnableSession = true)]
    public static string cargarMunicipios(string codDepartamento)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarciudadxDepartamento(codDepartamento);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "municipio@";
            ca += "<option value='' selected>Todos</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    //cargar instituciones
    [WebMethod(EnableSession = true)]
    public static string cargarInstituciones(string codMunicipio)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.proccargarInstitucionxMunicipio(codMunicipio);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "inst@";
            ca += "<option value='' selected>Todas</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    //cargar sedes
    [WebMethod(EnableSession = true)]
    public static string cargarSedesxInstitucion(string codInstitucion)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarSedesInstitucion(codInstitucion);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "sede@";
            ca += "<option value='' selected>Todas</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
            }
        }

        return ca;
    }

    //cargar grupos de investigación
    [WebMethod(EnableSession = true)]
    public static string cargarGruposInvestigacionxSede(string codSede)
    {
        string ca = "";

        Estrategias est = new Estrategias();

        DataTable datos = est.cargarProyectoSedexSedes(codSede);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "grupoinvestigacion@";
            ca += "<option value='' selected>Todos</option>";

  for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombregrupo"].ToString() + "</option>";
            }
        }

        return ca;
    }


    public static void Decode(string path)
    {
        var data = new List<byte>();
        using (var sr = new StreamReader(path))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
                data.Add(Byte.Parse(line));
        }
        using (var sw = new StreamWriter(path))
        {
            sw.Write(Encoding.UTF8.GetString(data.ToArray()));
        }
    }

    [WebMethod(EnableSession = true)]
    public static string docentesEvaluacionintermedia_(string respuesta)
    {
        detalleDocenteInteermedia d = new detalleDocenteInteermedia();
        string ca = "";
        var lb = new LineaBase();

        var respuesta1 = HttpUtility.UrlDecode(respuesta);

        //DataTable docentesEvaluacionintermedia = lb.detalleDocentesEvaIntermediaxNivelEducativo2("", "", "", "", respuesta1);
        DataTable docentesEvaluacionintermedia = lb.totalIntermedia("", "", "", "");

        if (docentesEvaluacionintermedia != null && docentesEvaluacionintermedia.Rows.Count > 0)
        {
            int total = docentesEvaluacionintermedia.Rows.Count;
            ca = "lleno@";
            for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
            {
                var f = i + 1;
                ca += "<tr>";
                ca += "<td><b>" + f + ".</b> </td>";
                ca += "<td><b>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + ".</b> </td>";
                ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";

                ca += "</tr>";
            }
            ca += "@" + total;
        }
        else
        {
            ca += "<tr>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td style=\"text-align:center;\">Sin resultados</td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "<td ></td>";
            ca += "</tr>";
        }

        return ca;
    }
    public string valres(string a)
    { string respuesta = "";
        if(a.Length>0)
        {
            respuesta = "Si";
        }
        else
        {
            respuesta = "No";
        }
        return respuesta;
    }
    [WebMethod(EnableSession = true)]
    public static string realizarBusquedadocentesEvaluacionintermedia_(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string instrumento)
    {
        string ca = "";
        var lb = new LineaBase();
        

        //  DataTable docentesEvaluacionintermedia = lb.detalleDocentesEvaIntermediaxNivelEducativo2(coddepartamento, codmunicipio, codinstitucion, codsede, respuesta);
           

        switch (instrumento)
        {
            case "Si_2_1":
                DataTable docentesEvaluacionintermedia = lb.Instrumento21(coddepartamento, codmunicipio, codinstitucion, codsede);
                if (docentesEvaluacionintermedia != null && docentesEvaluacionintermedia.Rows.Count > 0)
                {
                    int total = docentesEvaluacionintermedia.Rows.Count;
                    ca = "lleno@";
                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        var f = i + 1;
                        ca += "<tr>";
                        ca += "<td><b>" + f + ".</b> </td>";
                        ca += "<td><b>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + ".</b> </td>";
                        ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                        ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                        ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                        ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";
                       
                        ca += "</tr>";
                    }
                    ca += "@" + total;
                }
                else
                {
                    ca += "<tr>";
                    ca += "<td></td>";
                    ca += "<td></td>";
                    ca += "<td style=\"text-align:center;\">Sin resultados</td>";
                    ca += "<td ></td>";
                    ca += "<td ></td>";
                    ca += "<td ></td>";
                    ca += "</tr>";
                }
               
                break;
            case "No_2_1":
                DataTable docentesEvaluacionintermedi = lb.noInstrumento21(coddepartamento, codmunicipio, codinstitucion, codsede);
              
                if (docentesEvaluacionintermedi != null && docentesEvaluacionintermedi.Rows.Count > 0)
                {
                    int total = docentesEvaluacionintermedi.Rows.Count;
                    ca = "lleno@";
                    for (int i = 0; i < docentesEvaluacionintermedi.Rows.Count; i++)
                    {
                       
                        
                          
                                var f = i + 1;
                                ca += "<tr>";
                                ca += "<td><b>" + f + ".</b> </td>";
                                ca += "<td><b>" + docentesEvaluacionintermedi.Rows[i]["nombredocente"].ToString() + ".</b> </td>";
                                ca += "<td>" + docentesEvaluacionintermedi.Rows[i]["nombredepartamento"].ToString() + " </td>";
                                ca += "<td>" + docentesEvaluacionintermedi.Rows[i]["nombremunicipio"].ToString() + " </td>";
                                ca += "<td>" + docentesEvaluacionintermedi.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedi.Rows[i]["nombreins"].ToString() + " </td>";
                                ca += "<td>" + docentesEvaluacionintermedi.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedi.Rows[i]["nombresede"].ToString() + " </td>";

                                ca += "</tr>";
                         

                        
                       
                    }
                    ca += "@" + total;
                }
                else
                {
                    ca += "<tr>";
                    ca += "<td></td>";
                    ca += "<td></td>";
                    ca += "<td  style=\"text-align:center;\">Sin resultados</td>";
                    ca += "<td></td>";
                    ca += "<td></td>";
                    ca += "<td></td>";
                    ca += "</tr>";
                }
               
                break;
            case "Si_5":
                DataTable docentesEvaluacionintermedia5 = lb.Instrumento5(coddepartamento, codmunicipio, codinstitucion, codsede);
                if (docentesEvaluacionintermedia5 != null && docentesEvaluacionintermedia5.Rows.Count > 0)
                {
                    int total = docentesEvaluacionintermedia5.Rows.Count;
                    ca = "lleno@";
                    for (int i = 0; i < docentesEvaluacionintermedia5.Rows.Count; i++)
                    {
                        var f = i + 1;
                        ca += "<tr>";
                        ca += "<td><b>" + f + ".</b> </td>";
                        ca += "<td>" + docentesEvaluacionintermedia5.Rows[i]["nombredocente"].ToString() + " </td>";
                        ca += "<td>" + docentesEvaluacionintermedia5.Rows[i]["nombredepartamento"].ToString() + " </td>";
                        ca += "<td>" + docentesEvaluacionintermedia5.Rows[i]["nombremunicipio"].ToString() + " </td>";
                        ca += "<td>" + docentesEvaluacionintermedia5.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia5.Rows[i]["nombreins"].ToString() + " </td>";
                        ca += "<td>" + docentesEvaluacionintermedia5.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia5.Rows[i]["nombresede"].ToString() + " </td>";
                        
                        ca += "</tr>";
                    }
                    ca += "@" + total;
                }
                else
                {
                    ca += "<tr>";
                    ca += "<td></td>";
                    ca += "<td></td>";
                    ca += "<td style=\"text-align:center;\">Sin resultados</td>";
                    ca += "<td ></td>";
                    ca += "<td ></td>";
                    ca += "<td ></td>";
                    ca += "</tr>";
                }
                break;


            case "No_5":
                DataTable docentesEvaluacionintermedian5 = lb.noInstrumento5(coddepartamento, codmunicipio, codinstitucion, codsede);

                if (docentesEvaluacionintermedian5!= null && docentesEvaluacionintermedian5.Rows.Count > 0)
                {
                    int total = docentesEvaluacionintermedian5.Rows.Count;
                    ca = "lleno@";
                    for (int i = 0; i < docentesEvaluacionintermedian5.Rows.Count; i++)
                    {
                        var f = i + 1;
                        ca += "<tr>";
                        ca += "<td><b>" + f + ".</b> </td>";
                        ca += "<td><b>" + docentesEvaluacionintermedian5.Rows[i]["nombredocente"].ToString() + ".</b> </td>";
                        ca += "<td>" + docentesEvaluacionintermedian5.Rows[i]["nombredepartamento"].ToString() + " </td>";
                        ca += "<td>" + docentesEvaluacionintermedian5.Rows[i]["nombremunicipio"].ToString() + " </td>";
                        ca += "<td>" + docentesEvaluacionintermedian5.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedian5.Rows[i]["nombreins"].ToString() + " </td>";
                        ca += "<td>" + docentesEvaluacionintermedian5.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedian5.Rows[i]["nombresede"].ToString() + " </td>";
                    
                        ca += "</tr>";
                    }
                    ca += "@" + total;
                }
                else
                {
                    ca += "<tr>";
                    ca += "<td></td>";
                    ca += "<td></td>";
                    ca += "<td style=\"text-align:center;\">Sin resultados</td>";
                    ca += "<td ></td>";
                    ca += "<td ></td>";
                    ca += "<td ></td>";
                    ca += "</tr>";
                }
                break;
            case "":
                DataTable docentesEvaluacionintermediat = lb.totalIntermedia(coddepartamento, codmunicipio, codinstitucion, codsede);
               
                if (docentesEvaluacionintermediat != null && docentesEvaluacionintermediat.Rows.Count > 0)
                {
                    int total = docentesEvaluacionintermediat.Rows.Count;
                    ca = "lleno@";
                    for (int i = 0; i < docentesEvaluacionintermediat.Rows.Count; i++)
                    {
                        var f = i + 1;
                        ca += "<tr>";
                        ca += "<td><b>" + f + ".</b> </td>";
                        ca += "<td><b>" + docentesEvaluacionintermediat.Rows[i]["nombredocente"].ToString() + ".</b> </td>";
                        ca += "<td>" + docentesEvaluacionintermediat.Rows[i]["nombredepartamento"].ToString() + " </td>";
                        ca += "<td>" + docentesEvaluacionintermediat.Rows[i]["nombremunicipio"].ToString() + " </td>";
                        ca += "<td>" + docentesEvaluacionintermediat.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermediat.Rows[i]["nombreins"].ToString() + " </td>";
                        ca += "<td>" + docentesEvaluacionintermediat.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermediat.Rows[i]["nombresede"].ToString() + " </td>";
                       
                        ca += "</tr>";
                    }
                    ca += "@" + total;
                }
                else
                {
                    ca += "<tr>";
                    ca += "<td></td>";
                    ca += "<td></td>";
                    ca += "<td style=\"text-align:center;\">Sin resultados</td>";
                    ca += "<td ></td>";
                    ca += "<td ></td>";
                    ca += "<td ></td>";
                    ca += "</tr>";
                }
                break;

        }




        return ca;
    }


    protected void btnRegresar_Click(object sender, EventArgs e)
    {

        Response.Redirect("evalintermediaGeneral.aspx");

    }

}