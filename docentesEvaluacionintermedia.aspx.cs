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

public partial class docentesEvaluacionintermedia : System.Web.UI.Page
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
    public string respuesta  (string n)
    {
        string resp = "";
        switch (n){
            case "1":
                resp = "Bachillerato pedagógico";
                break;
            case "2":
                resp = "Normalista Superior";
                break;
            case "3":
                resp = "Otro bachillerato";
                break;
            case "4":
                resp = "Técnico o tecnológico";
                break;
            case "5":
                resp = "Otro Técnico o tecnológico";
                break;
            case "6":
                resp = "Profesional pedagógico";
                break;
            case "7":
                resp = "Otro profesional";
                break;
            case "8":
                resp = "Especialización";
                break;
            case "9":
                resp = "Maestría en educación o pedagogía";
                break;
            case "10":
                resp = "Otra Maestría";
                break;
            case "11":
                resp = "Doctorado en educación o pedagogía";
                break;
            case "12":
                resp = "Otro Doctorado";
                break;
        }

        return resp;
    }

    [WebMethod(EnableSession = true)]
    public static string docentesEvaluacionintermedia_(string respuesta)
    {

        string ca = "";
        var lb = new LineaBase();
        var res = new docentesEvaluacionintermedia();
        var respuesta1 = HttpUtility.UrlDecode(respuesta);

        DataTable docentesEvaluacionintermedia = lb.detalleDocentesEvaIntermediaxNivelEducativo2("", "", "", "", respuesta1);


        if (docentesEvaluacionintermedia != null && docentesEvaluacionintermedia.Rows.Count > 0)
        {
            int total = docentesEvaluacionintermedia.Rows.Count;
            ca = "lleno@";
            switch(respuesta){
                case "":

                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        var f = i + 1;
                        ca += "<tr>";
                        ca += "<td><b>" + f + ".</b> </td>";
                        ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + " </td>";
                        ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                        ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                        ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                        ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";
                        ca += "<td>" + res.respuesta(docentesEvaluacionintermedia.Rows[i]["num"].ToString()) + " </td>";
                        ca += "</tr>";
                    }
                    ca += "@" + total;

                    break;
                case "Bachillerato pedagógico":

                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        if (docentesEvaluacionintermedia.Rows[i]["num"].ToString() == "1")
                        {
                            var f = i + 1;
                            ca += "<tr>";
                            ca += "<td><b>" + f + ".</b> </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";

                            ca += "<td>" + res.respuesta(docentesEvaluacionintermedia.Rows[i]["num"].ToString()) + " </td>";

                            ca += "</tr>";
                        }
                    }
                    ca += "@" + total;

                    break;
                case "Normalista Superior":

                   
                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        if (docentesEvaluacionintermedia.Rows[i]["num"].ToString() == "2")
                        {
                            var f = i + 1;
                            ca += "<tr>";
                            ca += "<td><b>" + f + ".</b> </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";
                            ca += "<td>" + res.respuesta(docentesEvaluacionintermedia.Rows[i]["num"].ToString()) + " </td>";
                            ca += "</tr>";
                        }


                    }
                    ca += "@" + total;

                    break;
                case "Otro bachillerato":


                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        if (docentesEvaluacionintermedia.Rows[i]["num"].ToString() == "3")
                        {
                            var f = i + 1;
                            ca += "<tr>";
                            ca += "<td><b>" + f + ".</b> </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";
                            ca += "<td>" + res.respuesta(docentesEvaluacionintermedia.Rows[i]["num"].ToString()) + " </td>";
                            ca += "</tr>";
                        }


                    }
                    ca += "@" + total;

                    break;
                case "Técnico o tecnológico":


                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        if (docentesEvaluacionintermedia.Rows[i]["num"].ToString() == "4")
                        {
                            var f = i + 1;
                            ca += "<tr>";
                            ca += "<td><b>" + f + ".</b> </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";
                            ca += "<td>" + res.respuesta(docentesEvaluacionintermedia.Rows[i]["num"].ToString()) + " </td>";
                            ca += "</tr>";
                        }


                    }
                    ca += "@" + total;

                    break;
                case "Otro Técnico o tecnológico":


                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        if (docentesEvaluacionintermedia.Rows[i]["num"].ToString() == "5")
                        {
                            var f = i + 1;
                            ca += "<tr>";
                            ca += "<td><b>" + f + ".</b> </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";
                            ca += "<td>" + res.respuesta(docentesEvaluacionintermedia.Rows[i]["num"].ToString()) + " </td>";
                            ca += "</tr>";
                        }


                    }
                    ca += "@" + total;

                    break;
                case "Profesional pedagógico":


                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        if (docentesEvaluacionintermedia.Rows[i]["num"].ToString() == "6")
                        {
                            var f = i + 1;
                            ca += "<tr>";
                            ca += "<td><b>" + f + ".</b> </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";
                            ca += "<td>" + res.respuesta(docentesEvaluacionintermedia.Rows[i]["num"].ToString()) + " </td>";
                            ca += "</tr>";
                        }


                    }
                    ca += "@" + total;

                    break;
                case "Otro profesional":


                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        if (docentesEvaluacionintermedia.Rows[i]["num"].ToString() == "7")
                        {
                            var f = i + 1;
                            ca += "<tr>";
                            ca += "<td><b>" + f + ".</b> </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";
                            ca += "<td>" + res.respuesta(docentesEvaluacionintermedia.Rows[i]["num"].ToString()) + " </td>";
                            ca += "</tr>";
                        }


                    }
                    ca += "@" + total;

                    break;

                case "Especialización":


                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        if (docentesEvaluacionintermedia.Rows[i]["num"].ToString() == "8")
                        {
                            var f = i + 1;
                            ca += "<tr>";
                            ca += "<td><b>" + f + ".</b> </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";
                            ca += "<td>" + res.respuesta(docentesEvaluacionintermedia.Rows[i]["num"].ToString()) + " </td>";
                            ca += "</tr>";
                        }


                    }
                    ca += "@" + total;

                    break;
                case "Maestría en educación o pedagogía":


                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        if (docentesEvaluacionintermedia.Rows[i]["num"].ToString() == "9")
                        {
                            var f = i + 1;
                            ca += "<tr>";
                            ca += "<td><b>" + f + ".</b> </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";
                            ca += "<td>" + res.respuesta(docentesEvaluacionintermedia.Rows[i]["num"].ToString()) + " </td>";
                            ca += "</tr>";
                        }


                    }
                    ca += "@" + total;

                    break;
                case "Otra maestría":


                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        if (docentesEvaluacionintermedia.Rows[i]["num"].ToString() == "10")
                        {
                            var f = i + 1;
                            ca += "<tr>";
                            ca += "<td><b>" + f + ".</b> </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";
                            ca += "<td>" + res.respuesta(docentesEvaluacionintermedia.Rows[i]["num"].ToString()) + " </td>";
                            ca += "</tr>";
                        }


                    }
                    ca += "@" + total;

                    break;
                case "Doctorado en educación o pedagogía":


                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        if (docentesEvaluacionintermedia.Rows[i]["num"].ToString() == "11")
                        {
                            var f = i + 1;
                            ca += "<tr>";
                            ca += "<td><b>" + f + ".</b> </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";
                            ca += "<td>" + res.respuesta(docentesEvaluacionintermedia.Rows[i]["num"].ToString()) + " </td>";
                            ca += "</tr>";
                        }


                    }
                    ca += "@" + total;

                    break;
                case "Otro doctorado":


                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        if (docentesEvaluacionintermedia.Rows[i]["num"].ToString() == "12")
                        {
                            var f = i + 1;
                            ca += "<tr>";
                            ca += "<td><b>" + f + ".</b> </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";
                            ca += "<td>" + res.respuesta(docentesEvaluacionintermedia.Rows[i]["num"].ToString()) + " </td>";
                            ca += "</tr>";
                        }


                    }
                    ca += "@" + total;

                    break;
             

            }

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

    [WebMethod(EnableSession = true)]
    public static string realizarBusquedadocentesEvaluacionintermedia_(string coddepartamento, string codmunicipio, string codinstitucion, string codsede, string respuesta)
    {
        string ca = "";
        var lb = new LineaBase();
        var res = new docentesEvaluacionintermedia();
        DataTable docentesEvaluacionintermedia = lb.detalleDocentesEvaIntermediaxNivelEducativo2(coddepartamento, codmunicipio, codinstitucion, codsede, respuesta);


        if (docentesEvaluacionintermedia != null && docentesEvaluacionintermedia.Rows.Count > 0)
        {
            int total = docentesEvaluacionintermedia.Rows.Count;
            ca = "lleno@";

            switch (respuesta)
            {
                case "":

                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        var f = i + 1;
                        ca += "<tr>";
                        ca += "<td><b>" + f + ".</b> </td>";
                        ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + " </td>";
                        ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                        ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                        ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                        ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";
                        ca += "<td>" + res.respuesta(docentesEvaluacionintermedia.Rows[i]["num"].ToString()) + " </td>";
                        ca += "</tr>";
                    }
                    ca += "@" + total;

                    break;
                case "Bachillerato pedagógico":

                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        if (docentesEvaluacionintermedia.Rows[i]["num"].ToString() == "1")
                        {
                            var f = i + 1;
                            ca += "<tr>";
                            ca += "<td><b>" + f + ".</b> </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";

                            ca += "<td>" + res.respuesta(docentesEvaluacionintermedia.Rows[i]["num"].ToString()) + " </td>";

                            ca += "</tr>";
                        }
                    }
                    ca += "@" + total;

                    break;
                case "Normalista Superior":


                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        if (docentesEvaluacionintermedia.Rows[i]["num"].ToString() == "2")
                        {
                            var f = i + 1;
                            ca += "<tr>";
                            ca += "<td><b>" + f + ".</b> </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";
                            ca += "<td>" + res.respuesta(docentesEvaluacionintermedia.Rows[i]["num"].ToString()) + " </td>";
                            ca += "</tr>";
                        }


                    }
                    ca += "@" + total;

                    break;
                case "Otro bachillerato":


                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        if (docentesEvaluacionintermedia.Rows[i]["num"].ToString() == "3")
                        {
                            var f = i + 1;
                            ca += "<tr>";
                            ca += "<td><b>" + f + ".</b> </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";
                            ca += "<td>" + res.respuesta(docentesEvaluacionintermedia.Rows[i]["num"].ToString()) + " </td>";
                            ca += "</tr>";
                        }


                    }
                    ca += "@" + total;

                    break;
                case "Técnico o tecnológico":


                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        if (docentesEvaluacionintermedia.Rows[i]["num"].ToString() == "4")
                        {
                            var f = i + 1;
                            ca += "<tr>";
                            ca += "<td><b>" + f + ".</b> </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";
                            ca += "<td>" + res.respuesta(docentesEvaluacionintermedia.Rows[i]["num"].ToString()) + " </td>";
                            ca += "</tr>";
                        }


                    }
                    ca += "@" + total;

                    break;
                case "Otro Técnico o tecnológico":


                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        if (docentesEvaluacionintermedia.Rows[i]["num"].ToString() == "5")
                        {
                            var f = i + 1;
                            ca += "<tr>";
                            ca += "<td><b>" + f + ".</b> </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";
                            ca += "<td>" + res.respuesta(docentesEvaluacionintermedia.Rows[i]["num"].ToString()) + " </td>";
                            ca += "</tr>";
                        }


                    }
                    ca += "@" + total;

                    break;
                case "Profesional pedagógico":


                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        if (docentesEvaluacionintermedia.Rows[i]["num"].ToString() == "6")
                        {
                            var f = i + 1;
                            ca += "<tr>";
                            ca += "<td><b>" + f + ".</b> </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";
                            ca += "<td>" + res.respuesta(docentesEvaluacionintermedia.Rows[i]["num"].ToString()) + " </td>";
                            ca += "</tr>";
                        }


                    }
                    ca += "@" + total;

                    break;
                case "Otro profesional":


                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        if (docentesEvaluacionintermedia.Rows[i]["num"].ToString() == "7")
                        {
                            var f = i + 1;
                            ca += "<tr>";
                            ca += "<td><b>" + f + ".</b> </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";
                            ca += "<td>" + res.respuesta(docentesEvaluacionintermedia.Rows[i]["num"].ToString()) + " </td>";
                            ca += "</tr>";
                        }


                    }
                    ca += "@" + total;

                    break;

                case "Especialización":


                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        if (docentesEvaluacionintermedia.Rows[i]["num"].ToString() == "8")
                        {
                            var f = i + 1;
                            ca += "<tr>";
                            ca += "<td><b>" + f + ".</b> </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";
                            ca += "<td>" + res.respuesta(docentesEvaluacionintermedia.Rows[i]["num"].ToString()) + " </td>";
                            ca += "</tr>";
                        }


                    }
                    ca += "@" + total;

                    break;
                case "Maestría en educación o pedagogía":


                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        if (docentesEvaluacionintermedia.Rows[i]["num"].ToString() == "9")
                        {
                            var f = i + 1;
                            ca += "<tr>";
                            ca += "<td><b>" + f + ".</b> </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";
                            ca += "<td>" + res.respuesta(docentesEvaluacionintermedia.Rows[i]["num"].ToString()) + " </td>";
                            ca += "</tr>";
                        }


                    }
                    ca += "@" + total;

                    break;
                case "Otra maestría":


                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        if (docentesEvaluacionintermedia.Rows[i]["num"].ToString() == "10")
                        {
                            var f = i + 1;
                            ca += "<tr>";
                            ca += "<td><b>" + f + ".</b> </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";
                            ca += "<td>" + res.respuesta(docentesEvaluacionintermedia.Rows[i]["num"].ToString()) + " </td>";
                            ca += "</tr>";
                        }


                    }
                    ca += "@" + total;

                    break;
                case "Doctorado en educación o pedagogía":


                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        if (docentesEvaluacionintermedia.Rows[i]["num"].ToString() == "11")
                        {
                            var f = i + 1;
                            ca += "<tr>";
                            ca += "<td><b>" + f + ".</b> </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";
                            ca += "<td>" + res.respuesta(docentesEvaluacionintermedia.Rows[i]["num"].ToString()) + " </td>";
                            ca += "</tr>";
                        }


                    }
                    ca += "@" + total;

                    break;
                case "Otro doctorado":


                    for (int i = 0; i < docentesEvaluacionintermedia.Rows.Count; i++)
                    {
                        if (docentesEvaluacionintermedia.Rows[i]["num"].ToString() == "12")
                        {
                            var f = i + 1;
                            ca += "<tr>";
                            ca += "<td><b>" + f + ".</b> </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredocente"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombredepartamento"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["nombremunicipio"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["dane"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombreins"].ToString() + " </td>";
                            ca += "<td>" + docentesEvaluacionintermedia.Rows[i]["danesede"].ToString() + " - " + docentesEvaluacionintermedia.Rows[i]["nombresede"].ToString() + " </td>";
                            ca += "<td>" + res.respuesta(docentesEvaluacionintermedia.Rows[i]["num"].ToString()) + " </td>";
                            ca += "</tr>";
                        }


                    }
                    ca += "@" + total;

                    break;


            }


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


    protected void btnRegresar_Click(object sender, EventArgs e)
    {

        Response.Redirect("evalintermediaGeneral.aspx");

    }

}