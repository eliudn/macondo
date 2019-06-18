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

public partial class indicadoresdepartamentalmaestros : System.Web.UI.Page
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
        Session["fechaini"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["fechaini"]);
        Session["fechafin"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["fechafin"]);
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


    [WebMethod(EnableSession = true)]
    public static string loadreport()
    {
        string ca = "";
        Estrategias est = new Estrategias();

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string realizarBusquedaloadreport(string coddepartamento, string codmuncipio, string codinstitucion, string codsede)
    {
       
        string ca = "";
        string ca2 = "";
        double totalpeso = 0;
        Estrategias est = new Estrategias();

        Institucion inst = new Institucion();

        DataTable municipios = inst.cargarIndicadoresMunicipioxDepartamentoMaestros(coddepartamento);

        DataRow sumatotalmaestros = inst.totalmaestrosxDepartamento(coddepartamento);

        int num = 1;
        double sumpeso = 0;
        double sumporc = 0;
        int totalMaestrosxMuni = 0;
        int totalllevamaestros = 0;
        if (municipios != null && municipios.Rows.Count > 0)
        {
            ca += "lleno@";
            for (int i = 0; i < municipios.Rows.Count; i++)
            {

                ca += "<tr>";
                ca += "<td>" + num + "</td>";
                ca += "<td>" + municipios.Rows[i]["nombremunicipio"].ToString() + "</td>";

                DataTable munimaestros = est.maestrosxanio(coddepartamento, municipios.Rows[i]["codigomunicipio"].ToString(), "", "", "2017");
                    double metaporc = 0;
                    double pesomuni = ((double)Convert.ToInt32(munimaestros.Rows.Count) / (double)Convert.ToInt32(sumatotalmaestros["sumatotalmaestros"].ToString()));
                    double pesomunifinal = ((double)Convert.ToInt32(municipios.Rows[i]["totalmaestros"].ToString()) / (double)Convert.ToInt32(sumatotalmaestros["sumatotalmaestros"].ToString()));
                    totalMaestrosxMuni = totalMaestrosxMuni + Convert.ToInt32(municipios.Rows[i]["totalmaestros"].ToString());
                    totalllevamaestros = totalllevamaestros + Convert.ToInt32(munimaestros.Rows.Count);
                    metaporc = ((double)munimaestros.Rows.Count / (double)Convert.ToInt32(municipios.Rows[i]["totalmaestros"].ToString())) * 100;
                    metaporc = Math.Round(metaporc, 2);
                    //if (metaporc > 100)
                    //{
                    //    metaporc = 100;
                    //}

                    string stotal = pesomuni.ToString("N2");
                    string sPesoMunifinal = pesomunifinal.ToString("N2");
                    if (pesomuni > pesomunifinal)
                    {
                        stotal = sPesoMunifinal;
                        pesomuni = pesomunifinal;
                    }

                    sumpeso = sumpeso + pesomuni;

                    double metaporcxMunicipio = 0;
                    metaporcxMunicipio = ((double)munimaestros.Rows.Count / (double)Convert.ToInt32(sumatotalmaestros["sumatotalmaestros"].ToString())) * 100;
                    metaporcxMunicipio = Math.Round(metaporcxMunicipio, 2);
                    //if (metaporcxMunicipio > 100)
                    //{
                    //    metaporcxMunicipio = 100;
                    //}
                    sumporc = sumporc + metaporcxMunicipio;

                    ca += "<td style='text-align:center'>" + municipios.Rows[i]["totalmaestros"].ToString() + "</td>";
                    ca += "<td style='text-align:center'>" + munimaestros.Rows.Count + "</td>";
                    ca += "<td style='text-align:center'>" + metaporc + "%</td>";
                    ca += "<td style='text-align:center;'>" + stotal + " de " + sPesoMunifinal + "</td>";
                    ca += "<td class='noExl center'><a href='indicadoresmunicipalmaestros.aspx?mun=" + municipios.Rows[i]["codigomunicipio"].ToString() + "&dep=" + coddepartamento + "'><img src='images/detalles.png'>Ver</a></td>";
                    ca += "</tr>";
                

                num++;
            }


            sumpeso = sumpeso * 100;
            //totalMaestrosxMuni = 110880;
            ca += "@" + sumpeso + "@" + totalllevamaestros + "@" + totalMaestrosxMuni;
        }

        return ca;
    }
    

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("informedesarrollo.aspx");
    }
    
}