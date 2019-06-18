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

public partial class indicadoresmunicipalmaestros : System.Web.UI.Page
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
        if (HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["mun"]) == null)
        {
            Response.Redirect("indicadoresdepartamentalmaestros.aspx?dep=" + HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["dep"]));
        }
        if (HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["dep"]) == null)
        {
            Response.Redirect("indicadoresdepartamentalmaestros.aspx?dep=20");
        }
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


    //cargar institucion seleccionada y municipio
    [WebMethod(EnableSession = true)]
    public static string cargarInsMun(string codMunicipio, string codDepartamento)
    {
        string ca = "";

        //Institucion inst = new Institucion();

        //DataRow municipio = inst.proccargardatosmunicipioxcod(codMunicipio);

        //if (municipio != null)
        //{
        //    ca += "inst@";
        //    ca += "<option value='" + municipio["cod"].ToString() + "'   selected>" + municipio["nombre"].ToString() + "</option>";
        //}
        Institucion inst = new Institucion();

        DataTable datos = inst.cargarciudadxDepartamento(codDepartamento);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "municipio@";
            //ca += "<option value='' selected>Todos</option>";
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                if (datos.Rows[i]["cod"].ToString() == codMunicipio)
                {
                    ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "' selected>" + datos.Rows[i]["nombre"].ToString() + "</option>";
                }
                else
                {
                    ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
                }
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

        int totalMaestroxMuni = 0;
        int totalllevamaestro = 0;

        Estrategias est = new Estrategias();

        Institucion inst = new Institucion();

        DataTable institucion = inst.proccargarInstitucionxMunicipiosoloNombre(codmuncipio);


        DataRow totalmaestrosxMuni = inst.totalmaestrosxMunicipio(codmuncipio);

        int num = 1;
        double sumpeso = 0;
        double sumporc = 0;
        if (institucion != null && institucion.Rows.Count > 0)
        {
            ca += "lleno@";
            for (int i = 0; i < institucion.Rows.Count; i++)
            {
                DataTable sedes = inst.cargarIndicadoresSedesInstitucionMaestros(institucion.Rows[i]["codigo"].ToString());
                ca += "<tr>";
                ca += "<td rowspan='" + sedes.Rows.Count + "'>" + num + "</td>";
                ca += "<td rowspan='" + sedes.Rows.Count + "'>" + institucion.Rows[i]["nombre"].ToString() + "</td>";

                if (sedes != null && sedes.Rows.Count > 0)
                {
                    ca2 = "";
                    double metaporc = 0;
                    for (int j = 0; j < sedes.Rows.Count; j++)
                    {
                        DataRow totalxsede = inst.loadTotalesIndicadoresxSedeMaestros(sedes.Rows[j]["codigosede"].ToString());
                        DataTable totamaestrosxSede = est.maestrosxanio(coddepartamento, codmuncipio, institucion.Rows[i]["codigo"].ToString(), sedes.Rows[j]["codigosede"].ToString(), "2017");
                        double totalmaestros = ((double)Convert.ToInt32(totamaestrosxSede.Rows.Count) / (double)Convert.ToInt32(totalmaestrosxMuni["totalmaestros"].ToString()));
                        double pesofinal = ((double)Convert.ToInt32(totalxsede["totalmaestros"].ToString()) / (double)Convert.ToInt32(totalmaestrosxMuni["totalmaestros"].ToString()));

                        //totalMaestroxMuni = totalMaestroxMuni + Convert.ToInt32(totalesturedestematicas["totalmaestros"].ToString());
                        totalllevamaestro = totalllevamaestro + Convert.ToInt32(totamaestrosxSede.Rows.Count);



                        metaporc = ((double)totamaestrosxSede.Rows.Count / (double)Convert.ToInt32(totalxsede["totalmaestros"].ToString())) * 100;
                        metaporc = Math.Round(metaporc, 2);
                        //if (metaporc > 100)
                        //{
                        //    metaporc = 100;
                        //}

                        
                        string stotal = totalmaestros.ToString("N2");
                        string spesofinal = pesofinal.ToString("N2");
                        if (totalmaestros > pesofinal)
                        {
                            stotal = spesofinal;
                        }
                        sumpeso = sumpeso + totalmaestros;


                        double metaporcxMunicipio = 0;
                        double totalmaestroxsede = 0;
                        if(totamaestrosxSede.Rows.Count > Convert.ToInt32(totalmaestrosxMuni["totalmaestros"].ToString())){

                            totalmaestroxsede = Convert.ToInt32(totalmaestrosxMuni["totalmaestros"].ToString());
                        }else{
                            totalmaestroxsede = totamaestrosxSede.Rows.Count;
                        }
                        metaporcxMunicipio = ((double)totalmaestroxsede / (double)Convert.ToInt32(totalmaestrosxMuni["totalmaestros"].ToString())) * 100;
                        metaporcxMunicipio = Math.Round(metaporcxMunicipio, 2);
                        //if (metaporcxMunicipio > 100)
                        //{
                        //    metaporcxMunicipio = 100;
                        //}
                        sumporc = sumporc + metaporcxMunicipio;


                        ca += "<td> " + sedes.Rows[j]["codigosede"].ToString()+ " - "+ sedes.Rows[j]["nombresede"].ToString() + "</td>";
                        ca += "<td style='text-align:center'>" + sedes.Rows[j]["totalmaestros"].ToString() + "</td>";
                        ca += "<td style='text-align:center'>" + totamaestrosxSede.Rows.Count + "</td>";
                        ca += "<td style='text-align:center'>" + metaporc + "%</td>";
                        ca += "<td style='text-align:center'>" + stotal + " de " + spesofinal + "</td>";
                        //if (j == 0)
                        //{
                        ca += "<td  class='noExl center'><a href='indicadoresinstitucion.aspx?tipo=mae&ins=" + institucion.Rows[i]["codigo"].ToString() + "&mun=" + codmuncipio + "&dep=" + coddepartamento + "&sed=" + sedes.Rows[j]["codigosede"].ToString() + "'><img src='images/detalles.png'>Ver</a></td>";
                        //}rowspan='" + sedes.Rows.Count + "'
                        ca += "</tr>";
                        //ca2 += "</tr>";
                    }
                    //ca2 += "</table>";
                }
                
                //ca += "<td>" + ca2 + "</td>";
                //ca += ca2;
                //ca += "<td>totalestu</td>";
                //ca += "<td>peso</td>";

                

                num++;
            }
            ca += "@" + sumporc + "@" + totalllevamaestro + "@" + totalmaestrosxMuni["totalmaestros"].ToString();
        }

        return ca;
    }
    

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("informedesarrollo.aspx");
    }
    
}