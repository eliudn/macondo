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

public partial class indicadoresgeneral : System.Web.UI.Page
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
       coddepartamento = "20";
       codmuncipio = "";
       codinstitucion = "null";
       codsede = "null";
        string ca = "";
        
        Estrategias est = new Estrategias();

        Institucion inst = new Institucion();

        /* DataTable municipios = inst.cargarIndicadoresMunicipioxDepartamento(coddepartamento);
        //DataTable municipiosM = inst.cargarIndicadoresMunicipioxDepartamentoMaestros(coddepartamento);

        DataRow totalesturedestematicas = inst.totalesturedestematicasxDepartamento(coddepartamento);

        DataRow sumatotalmaestros = inst.totalmaestrosxDepartamento(coddepartamento);

        int num = 1;
        double sumpeso = 0, sumpesoM=0;
        double sumporc = 0, sumporcmaestro = 0;
        int totalestuxMuni = 0, totalMaestrosxMuni = 0;
        int totalllevaestu = 0, totalllevamaestros = 0;
        if (municipios != null && municipios.Rows.Count > 0)
        {
            ca += "lleno@";
            for (int i = 0; i < municipios.Rows.Count; i++)
            {

                ca += "<tr>";
                ca += "<td>" + num + "</td>";
                ca += "<td>" + municipios.Rows[i]["nombremunicipio"].ToString() + "</td>";

                    DataTable muniestured = est.esturedtematicasxanio(coddepartamento, municipios.Rows[i]["codigomunicipio"].ToString(), "", "", "2017");
                    double metaporc = 0;
                    double pesomuni = ((double)Convert.ToInt32(muniestured.Rows.Count) / (double)Convert.ToInt32(totalesturedestematicas["totalesturedes"].ToString()));
                    double pesomunifinal = ((double)Convert.ToInt32(municipios.Rows[i]["totalestu"].ToString()) / (double)Convert.ToInt32(totalesturedestematicas["totalesturedes"].ToString()));
                    totalestuxMuni = totalestuxMuni + Convert.ToInt32(municipios.Rows[i]["totalestu"].ToString());
                    totalllevaestu = totalllevaestu + Convert.ToInt32(muniestured.Rows.Count);
                    metaporc = ((double)muniestured.Rows.Count / (double)Convert.ToInt32(municipios.Rows[i]["totalestu"].ToString())) * 100;
                    metaporc = Math.Round(metaporc, 2);
                    if (metaporc > 100)
                    {
                        metaporc = 100;
                    }
                    string stotal = pesomuni.ToString("N2");
                    string sPesoMunifinal = pesomunifinal.ToString("N2");
                    if (pesomuni > pesomunifinal)
                    {
                        stotal = sPesoMunifinal;
                        pesomuni = pesomunifinal;
                    }
                    sumpeso = sumpeso + pesomuni;
                    DataRow totalmaestrosxMunicipio = inst.totalmaestrosxMunicipio(municipios.Rows[i]["codigomunicipio"].ToString());
                    double metaporcxMunicipio = 0;
                    metaporcxMunicipio = ((double)muniestured.Rows.Count / (double)Convert.ToInt32(totalesturedestematicas["totalesturedes"].ToString())) * 100;
                    metaporcxMunicipio = Math.Round(metaporcxMunicipio, 2);
                    if (metaporcxMunicipio > 100)
                    {
                        metaporcxMunicipio = 100;
                    }
                    sumporc = sumporc + metaporcxMunicipio;

                    //-----------------
                    DataTable munimaestros = est.maestrosxanio(coddepartamento, municipios.Rows[i]["codigomunicipio"].ToString(), "", "", "2017");
                    double metaporcM = 0;
                    double pesomuniM = ((double)Convert.ToInt32(munimaestros.Rows.Count) / (double)Convert.ToInt32(sumatotalmaestros["sumatotalmaestros"].ToString()));
                    double pesomunifinalM = ((double)Convert.ToInt32(totalmaestrosxMunicipio["totalmaestros"].ToString()) / (double)Convert.ToInt32(sumatotalmaestros["sumatotalmaestros"].ToString()));
                    totalMaestrosxMuni = totalMaestrosxMuni + Convert.ToInt32(totalmaestrosxMunicipio["totalmaestros"].ToString());
                    totalllevamaestros = totalllevamaestros + Convert.ToInt32(munimaestros.Rows.Count);
                    metaporcM = ((double)munimaestros.Rows.Count / (double)Convert.ToInt32(totalmaestrosxMunicipio["totalmaestros"].ToString())) * 100;
                    metaporcM = Math.Round(metaporcM, 2);
                    if (metaporcM > 100)
                    {
                        metaporcM = 100;
                    }

                    string stotalM = pesomuniM.ToString("N2");
                    string sPesoMunifinalM = pesomunifinalM.ToString("N2");
                    if (pesomuniM > pesomunifinalM)
                    {
                        stotal = sPesoMunifinal;
                        pesomuniM = pesomunifinalM;
                    }

                    sumpesoM = sumpesoM + pesomuniM;

                    double metaporcxMunicipioM = 0;
                    metaporcxMunicipioM = ((double)munimaestros.Rows.Count / (double)Convert.ToInt32(sumatotalmaestros["sumatotalmaestros"].ToString())) * 100;
                    metaporcxMunicipioM = Math.Round(metaporcxMunicipioM, 2);
                    if (metaporcxMunicipioM > 100)
                    {
                        metaporcxMunicipioM = 100;
                    }
                    sumporcmaestro = sumporcmaestro + metaporcxMunicipioM;

                    
                    //ca += "<td style='text-align:center'>" + municipios.Rows[i]["totalestu"].ToString() + "</td>";
                    ca += "<td style='text-align:center'>" + muniestured.Rows.Count + "</td>";
                    ca += "<td style='text-align:center'>" + metaporc + "%</td>";
                    //ca += "<td style='text-align:center'>" + totalmaestrosxMunicipio["totalmaestros"].ToString() + "</td>";
                    ca += "<td style='text-align:center'>" + munimaestros.Rows.Count + "</td>";
                    ca += "<td style='text-align:center'>" + metaporcM + "%</td>";

                    //ca += "<td style='text-align:center;'>" + stotal + " de " + sPesoMunifinal + "</td>";
                    ca += "<td class='noExl center'><a href='indicadoresmunicipal.aspx?mun=" + municipios.Rows[i]["codigomunicipio"].ToString() + "&dep=" + coddepartamento + "'><img src='images/detalles.png'>Ver</a></td>";
                    ca += "</tr>";
                

                num++;
            }
            totalestuxMuni = 110880;


            sumpeso = (sumpeso / 2) * 100 ;
            if (sumpeso > 50.0)
            {
                sumpeso = 50.0;
            }

            sumpesoM = (sumpesoM / 2) * 100;
            if (sumpesoM > 50)
            {
                sumpesoM = 50.0;
            }
            double total = sumpeso + sumpesoM;
            ca += "@" + sumpeso + "@" + sumpesoM + "@" + total;
        }*/

        double metaMuni = 28;
        DataTable totalmunicipio = inst.totalmunicipioInd(coddepartamento);

        double metaporcxMunicipioM = ((double)Convert.ToInt32(totalmunicipio.Rows.Count) / (double) metaMuni);
        metaporcxMunicipioM = Math.Round(metaporcxMunicipioM, 2);
        metaporcxMunicipioM = (metaporcxMunicipioM / 5) * 100;
        if (metaporcxMunicipioM > 20)
        {
            metaporcxMunicipioM = 20.0;
        }


        double metaSedes = 320;
        DataTable totalSedes = inst.totalSedesInd(coddepartamento);
        double metaporcxSedeM = ((double)Convert.ToInt32(totalSedes.Rows.Count) / (double)metaSedes);
        metaporcxSedeM = Math.Round(metaporcxSedeM, 2);
        metaporcxSedeM = (metaporcxSedeM / 5) * 100;
        if (metaporcxSedeM > 20)
        {
            metaporcxSedeM = 20.0;
        }

        //MAESTROS
        double metaMaestros = 3386;
        //DataTable totalMaestros = inst.totalMaestrosInd(coddepartamento);
        DataTable totalMaestros = est.maestrosxanio(coddepartamento,"", "", "", "2017");
        double metaporcxMaestrosM = (Convert.ToInt32(totalMaestros.Rows.Count) / metaMaestros);
        metaporcxMaestrosM = Math.Round(metaporcxMaestrosM, 2);
        metaporcxMaestrosM = (metaporcxMaestrosM / 5) * 100;
        if (metaporcxMaestrosM > 20)
        {
            metaporcxMaestrosM = 20;
        }

        //ESTUDIANTES
        double metaEstu = 110880;
        //DataTable totalEstu = inst.totalEstuInd(coddepartamento); 
        DataTable totalEstu = est.esturedtematicasxanio(coddepartamento, "", "", "", "2018");
        double metaporcxEstuM = (Convert.ToInt32(totalEstu.Rows.Count) / metaEstu);
        metaporcxEstuM = Math.Round(metaporcxEstuM, 2);
        metaporcxEstuM = (metaporcxEstuM / 5) * 100;
        if (metaporcxEstuM > 20)
        {
            metaporcxEstuM = 20;
        }

        ca += "lleno@";
        ca += "<tr>";
        ca += "<td>1</td>";
        ca += "<td>Municipios impactados.</td>";
        ca += "<td>" + totalmunicipio.Rows.Count + " de " + metaMuni + "</td>";
        ca += "<td> <a href='javascript:void(0)' onclick='$(\"#detmunicipios\").show();$(\"#detsede\").hide();$(\"#detalle\").hide();'>Ver detalle</a></td>";
        ca += "</tr>";
        //----------
        ca += "<tr>";
        ca += "<td>2</td>";
        ca += "<td>Sedes educativas públicas beneficiadas.</td>";
        ca += "<td>" + totalSedes.Rows.Count + " de " + metaSedes + "</td>";
        ca += "<td> <a href='javascript:void(0)' onclick='$(\"#detmunicipios\").hide();$(\"#detsede\").show();$(\"#detalle\").hide();'>Ver detalles</a></td>";
        ca += "</tr>";
        //----------
        ca += "<tr>";
        ca += "<td>3</td>";
        ca += "<td>Maestros(as) de las intituciones educativas participantes.</td>";
        ca += "<td>" + totalMaestros.Rows.Count + " de " + metaMaestros + "</td>";
        ca += "<td> <a href='indicadoresmaestros.aspx'>Ver detalles</a></td>";
        ca += "</tr>";
        //----------
        ca += "<tr>";
        ca += "<td>4</td>";
        ca += "<td>Niños(as) y jóvenes participantes.</td>";
        ca += "<td>" + totalEstu.Rows.Count + " de " + metaEstu + "</td>";
        ca += "<td> <a href='indicadoresestudiantes.aspx'>ver detalles</a></td>";
        ca += "</tr>";
        //----------
        ca += "<tr>";
        ca += "<td>5</td>";
        ca += "<td>Publicaciones de los resultados anuales del proyecto.</td>";
        ca += "<td> 0 de 0 </td>";
        ca += "<td> <a href='#'>Ver detalles</a></td>";
        ca += "</tr>";

        //////////////PARA LA GRÁFICA//////////////////
        Institucion ins = new Institucion();
        Consultas c = new Consultas();

        double pesototal = 0;



        //total grupos de investigacion por municipio
        DataRow totalgpxMunicipio = ins.totalgpxMunicipio(codmuncipio);

        DataTable gpSeleccionadosconvocatoria = est.gpSeleccionadosconvocatoria(coddepartamento, codmuncipio, codinstitucion, codsede);

        double meta1 = 0;
        int count1 = 0;

        DataRow loadTotalesIndicadoresxSede = ins.loadTotalesIndicadoresxSedeSUM(coddepartamento, codmuncipio, codinstitucion, codsede);
        int total1 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalgrupos"].ToString());
        double peso1 = 2.20;
        double pesoAct1 = 0;

        if (gpSeleccionadosconvocatoria != null && gpSeleccionadosconvocatoria.Rows.Count > 0)
        {
            count1 = gpSeleccionadosconvocatoria.Rows.Count;
            meta1 = ((double)count1 / (double)total1) * 100;
            meta1 = Math.Round(meta1, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesoAct1 = ((double)count1 / (double)total1) * peso1;
            pesoAct1 = Math.Round(pesoAct1, 4);
            if (pesoAct1 > peso1)
            {
                pesoAct1 = peso1;
            }
            pesototal = pesototal + pesoAct1;
        }
      


        // ---------------------- NUEVO CODIGO --------------
        //28) Grupos de investigación infantiles y juveniles que se inscribieron en la convocatoria de Ciclón 
        DataTable gpinscritosconvocatoriaciclon = est.gpinscritosconvocatoriaciclon(coddepartamento, codmuncipio, codinstitucion, codsede, "1");
        double meta28 = 0;
        int count28 = 0;
        int total28 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalgrupos"].ToString());
        double peso28 = 2.20;
        double pesoAct28 = 0;
        if (gpinscritosconvocatoriaciclon != null && gpinscritosconvocatoriaciclon.Rows.Count > 0)
        {
            count28 = gpinscritosconvocatoriaciclon.Rows.Count;
            meta28 = ((double)count28 / (double)total28) * 100;
            meta28 = Math.Round(meta28, 2);
            //if (meta28 > 100)
            //{
            //    meta28 = 100;
            //}
            pesoAct28 = ((double)count28 / (double)total28) * peso28;
            pesoAct28 = Math.Round(pesoAct28, 4);
            if (pesoAct28 > peso28)
            {
                pesoAct28 = peso28;
            }
            pesototal = pesototal + pesoAct28;
        }
       


        //29) Grupos de investigación con recursos aportados por  Ciclón
        //DataTable gprecursosaprortados = est.gprecursosaprortados(coddepartamento, codmuncipio, codinstitucion, codsede, "1");
        DataTable gprecursosaprortados = c.cargarGruposInvestigacionRecursosAportadosCiclón(coddepartamento, codmuncipio, codinstitucion, codsede);
        double meta29 = 0;
        int count29 = 0;
        int total29 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalgrupos"].ToString());
        double peso29 = 12.31;
        double pesoAct29 = 0;
        if (gprecursosaprortados != null && gprecursosaprortados.Rows.Count > 0)
        {
            count29 = gprecursosaprortados.Rows.Count;
            meta29 = ((double)count29 / (double)total29) * 100;
            meta29 = Math.Round(meta29, 2);
            //if (meta29 > 100)
            //{
            //    meta29 = 100;
            //}
            pesoAct29 = ((double)count29 / (double)total29) * peso29;
            pesoAct29 = Math.Round(pesoAct29, 4);

            if (pesoAct29 > peso29)
            {
                pesoAct29 = peso29;
            }
            pesototal = pesototal + pesoAct29;
        }
       
        //30) Total grupos de investigación con registro de avance del presupuesto
        DataTable gpregistroavance = est.gpregistroavance(coddepartamento, codmuncipio, codinstitucion, codsede);
        double meta30 = 0;
        int count30 = 0;
        int total30 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalgrupos"].ToString());
        double peso30 = 2.20;
        double pesoAct30 = 0;
        if (gpregistroavance != null && gpregistroavance.Rows.Count > 0)
        {
            count30 = gpregistroavance.Rows.Count;
            meta30 = ((double)count30 / (double)total30) * 100;
            meta30 = Math.Round(meta30, 2);
            //if (meta30 > 100)
            //{
            //    meta30 = 100;
            //}
            pesoAct30 = ((double)count30 / (double)total30) * peso30;
            pesoAct30 = Math.Round(pesoAct30, 4);
            if (pesoAct30 > peso30)
            {
                pesoAct30 = peso30;
            }
            pesototal = pesototal + pesoAct30;
        }
      

        //31)  Informes de investigación elaborados por los grupos de investigación infantiles y juveniles
        DataTable informesinvelavoradosgp = est.informesinvelavoradosgp(coddepartamento, codmuncipio, codinstitucion, codsede);
        double meta31 = 0;
        int count31 = 0;
        int total31 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalgrupos"].ToString());
        double peso31 = 0.31;
        double pesoAct31 = 0;
        if (informesinvelavoradosgp != null && informesinvelavoradosgp.Rows.Count > 0)
        {
            count31 = informesinvelavoradosgp.Rows.Count;
            meta31 = ((double)count31 / (double)total31) * 100;
            meta31 = Math.Round(meta31, 2);
            //if (meta31 > 100)
            //{
            //    meta31 = 100;
            //}
            pesoAct31 = ((double)count31 / (double)total31) * peso31;
            pesoAct31 = Math.Round(pesoAct31, 4);
            if (pesoAct31 > peso31)
            {
                pesoAct31 = peso31;
            }
            pesototal = pesototal + pesoAct31;
        }
       


        //32) Resumenes del proyecto de investigación elaborados por los grupos infantiles y juveniles.
        DataTable resumenesproyectoinv = est.resumenesproyectoinv(coddepartamento, codmuncipio, codinstitucion, codsede);
        double meta32 = 0;
        int count32 = 0;
        int total32 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalgrupos"].ToString());
        double peso32 = 2.20;
        double pesoAct32 = 0;
        if (resumenesproyectoinv != null && resumenesproyectoinv.Rows.Count > 0)
        {
            count32 = resumenesproyectoinv.Rows.Count;
            meta32 = ((double)count32 / (double)total32) * 100;
            meta32 = Math.Round(meta32, 2);
            //if (meta32 > 100)
            //{
            //    meta32 = 100;
            //}
            pesoAct32 = ((double)count32 / (double)total32) * peso32;
            pesoAct32 = Math.Round(pesoAct32, 4);
            if (pesoAct32 > peso32)
            {
                pesoAct32 = peso32;
            }
            pesototal = pesototal + pesoAct32;
        }
      

        //---------------------------------------------




        //Niños, niñas y jóvenes inscritos en grupos de investigación infantiles y juveniles en la convocatoria Ciclón 
        DataTable estudianesengp = est.estudianesengp(coddepartamento, codmuncipio, codinstitucion, codsede);
        double meta2 = 0;
        int count2 = 0;
        int total2 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalasistentesasesorias"].ToString());
        double peso2 = 2.20;
        double pesoAct2 = 0;

        if (estudianesengp != null && estudianesengp.Rows.Count > 0)
        {
            count2 = estudianesengp.Rows.Count;
            meta2 = ((double)count2 / (double)total2) * 100;
            meta2 = Math.Round(meta2, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}
            pesoAct2 = ((double)count2 / (double)total2) * peso2;
            pesoAct2 = Math.Round(pesoAct2, 4);
            if (pesoAct2 > peso2)
            {
                pesoAct2 = peso2;
            }
            pesototal = pesototal + pesoAct2;
        }
       


        // Grupos de investigación con preguntas de investigación formuladas en la convocartoria de Ciclón
        DataTable totalGPHicieronPreguntas = est.totalGPHicieronPreguntas(coddepartamento, codmuncipio, codinstitucion, codsede);
        double meta3 = 0;
        int count3 = 0;
        int total3 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalgrupos"].ToString());
        double peso3 = 2.20;
        double pesoAct3 = 0;

        if (totalGPHicieronPreguntas != null && totalGPHicieronPreguntas.Rows.Count > 0)
        {
            count3 = totalGPHicieronPreguntas.Rows.Count;
            meta3 = ((double)count3 / (double)total3) * 100;
            meta3 = Math.Round(meta3, 2);
            //if (meta3 > 100)
            //{
            //    meta3 = 100;
            //}
            pesoAct3 = ((double)count3 / (double)total3) * peso3;
            pesoAct3 = Math.Round(pesoAct3, 4);
            if (pesoAct3 > peso3)
            {
                pesoAct3 = peso3;
            }
            pesototal = pesototal + pesoAct3;
        }
       

        //Total grupos de investigación con problemas de investigación planteados en la convocatoria de Ciclón
        DataTable totalGPHicieronPreguntasB3 = est.totalGPHicieronPreguntasB3(coddepartamento, codmuncipio, codinstitucion, codsede);
        double meta4 = 0;
        int count4 = 0;
        int total4 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalgrupos"].ToString());
        double peso4 = 2.20;
        double pesoAct4 = 0;

        if (totalGPHicieronPreguntasB3 != null && totalGPHicieronPreguntasB3.Rows.Count > 0)
        {
            count4 = totalGPHicieronPreguntasB3.Rows.Count;
            meta4 = ((double)count4 / (double)total4) * 100;
            meta4 = Math.Round(meta4, 2);
            //if (meta4 > 100)
            //{
            //    meta4 = 100;
            //}
            pesoAct4 = ((double)count4 / (double)total4) * peso4;
            pesoAct4 = Math.Round(pesoAct4, 4);
            if (pesoAct4 > peso4)
            {
                pesoAct4 = peso4;
            }
            pesototal = pesototal + pesoAct4;
        }
      

        //5) Grupos de investigación infantiles y juveniles con la bitácora 04 de presupuesto diligenciada
        DataTable gpbitacora4 = est.gpbitacora4(coddepartamento, codmuncipio, codinstitucion, codsede, "1");
        double meta5 = 0;
        int count5 = 0;
        int total5 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalgrupos"].ToString());
        double peso5 = 2.20;
        double pesoAct5 = 0;

        if (gpbitacora4 != null && gpbitacora4.Rows.Count > 0)
        {
            count5 = gpbitacora4.Rows.Count;
            meta5 = ((double)count5 / (double)total5) * 100;
            meta5 = Math.Round(meta5, 2);
            //if (meta5 > 100)
            //{
            //    meta5 = 100;
            //}
            pesoAct5 = ((double)count5 / (double)total5) * peso5;
            pesoAct5 = Math.Round(pesoAct5, 4);
            if (pesoAct5 > peso5)
            {
                pesoAct5 = peso5;
            }
            pesototal = pesototal + pesoAct5;
        }
       

        //6) Grupos de investigación infantiles y juveniles con trayectorias de indagación diseñadas
        DataTable gruposInvestigacionBitacora5 = est.gruposInvestigacionBitacora5(coddepartamento, codmuncipio, codinstitucion, codsede);
        double meta6 = 0;
        int count6 = 0;
        int total6 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalgrupos"].ToString());
        double peso6 = 2.20;
        double pesoAct6 = 0;

        if (gruposInvestigacionBitacora5 != null && gruposInvestigacionBitacora5.Rows.Count > 0)
        {
            count6 = gruposInvestigacionBitacora5.Rows.Count;
            meta6 = ((double)count6 / (double)total6) * 100;
            meta6 = Math.Round(meta6, 2);
            //if (meta6 > 100)
            //{
            //    meta6 = 100;
            //}
            pesoAct6 = ((double)count6 / (double)total6) * peso6;
            pesoAct6 = Math.Round(pesoAct6, 4);
            if (pesoAct6 > peso6)
            {
                pesoAct6 = peso6;
            }
            pesototal = pesototal + pesoAct6;
        }
       

        //7) Asistentes a la sesión de asesoría a grupos infantiles y juveniles
        DataRow asistentesesionasesoriaxestrategia = est.asistentesesionasesoriaxestrategia(coddepartamento, codmuncipio, codinstitucion, codsede, "1");


        double meta7 = 0;
        int count7 = 0;
        int total7 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalasistentesasesorias"].ToString());
        double peso7 = 2.20;
        double pesoAct7 = 0;

        if (asistentesesionasesoriaxestrategia["total"].ToString() != "")
        {
            count7 = Int32.Parse(asistentesesionasesoriaxestrategia["total"].ToString());
            meta7 = ((double)count7 / (double)total7) * 100;
            meta7 = Math.Round(meta7, 2);
            //if (meta7 > 100)
            //{
            //    meta7 = 100;
            //}
            pesoAct7 = ((double)count7 / (double)total7) * peso7;
            pesoAct7 = Math.Round(pesoAct7, 4);
            if (pesoAct7 > peso7)
            {
                pesoAct7 = peso7;
            }
            pesototal = pesototal + pesoAct7;
        }
       
        //8) Asesorias realizadas a cada uno de los grupos de investigación 
        DataTable noAsesoriasGP = est.noAsesoriasGP(coddepartamento, codmuncipio, codinstitucion, codsede);
        double meta8 = 0;
        int count8 = 0;
        int total8 = Convert.ToInt32(loadTotalesIndicadoresxSede["metanoasesoria"].ToString()) * Convert.ToInt32(loadTotalesIndicadoresxSede["totalgrupos"].ToString());
        double peso8 = 2.20;
        double pesoAct8 = 0;

        if (noAsesoriasGP != null && noAsesoriasGP.Rows.Count > 0)
        {
            count8 = noAsesoriasGP.Rows.Count;
            meta8 = ((double)count8 / (double)total8) * 100;
            meta8 = Math.Round(meta8, 2);
            //if (meta8 > 100)
            //{
            //    meta8 = 100;
            //}
            pesoAct8 = ((double)count8 / (double)total8) * peso8;
            pesoAct8 = Math.Round(pesoAct8, 4);
            if (pesoAct8 > peso8)
            {
                pesoAct8 = peso8;
            }
            pesototal = pesototal + pesoAct8;
        }
       

        //9) Kit preestructurados de los 4 documentos del programa Ciclón reimpresos
        DataTable kitpreestructurados = est.kitpreestructurados(coddepartamento, codmuncipio, codinstitucion, codsede);
        double meta9 = 0;
        int count9 = 0;
        int total9 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalkits"].ToString());

        double peso9 = 1.06;
        double pesoAct9 = 0;
        if (kitpreestructurados != null && kitpreestructurados.Rows.Count > 0)
        {
            count9 = kitpreestructurados.Rows.Count;
            meta9 = ((double)count9 / (double)total9) * 100;
            meta9 = Math.Round(meta9, 2);
            //if (meta9 > 100)
            //{
            //    meta9 = 100;
            //}
            pesoAct9 = ((double)count9 / (double)total9) * peso9;
            pesoAct9 = Math.Round(pesoAct9, 4);
            if (pesoAct9 > peso9)
            {
                pesoAct9 = peso9;
            }
            pesototal = pesototal + pesoAct9;
        }
     

        //10)  Estudiantes inscritos en las redes temáticas de la comunidad de práctica, saber, conocimiento y transformación de Ciclón
        DataTable esturedtematicas = est.esturedtematicasxanio(coddepartamento, codmuncipio, codinstitucion, codsede, "2017");
        double meta10 = 0;
        int count10 = 0;
        int total10 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalesturedestematicas"].ToString());
        double peso10 = 1.41;
        double pesoAct10 = 0;

        if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        {
            count10 = esturedtematicas.Rows.Count;
            meta10 = ((double)count10 / (double)total10) * 100;
            meta10 = Math.Round(meta10, 2);
            //if (meta10 > 100)
            //{
            //    meta10 = 100;
            //}
            pesoAct10 = ((double)count10 / (double)total10) * peso10;
            pesoAct10 = Math.Round(pesoAct10, 4);
            if (pesoAct10 > peso10)
            {
                pesoAct10 = peso10;
            }
            pesototal = pesototal + pesoAct10;
        }
      
        //11) Redes temáticas conformadas
        DataTable sederedtematicas = est.sederedtematicas(coddepartamento, codmuncipio, codinstitucion, codsede, "2017");
        double meta11 = 0;
        int count11 = 0;
        int total11 = Convert.ToInt32(loadTotalesIndicadoresxSede["numeroredes"].ToString());
        double peso11 = 1.41;
        double pesoAct11 = 0;
        if (sederedtematicas != null && sederedtematicas.Rows.Count > 0)
        {
            count11 = sederedtematicas.Rows.Count;
            meta11 = ((double)count11 / (double)total11) * 100;
            meta11 = Math.Round(meta11, 2);
            //if (meta11 > 100)
            //{
            //    meta11 = 100;
            //}
            pesoAct11 = ((double)count11 / (double)total11) * peso11;
            pesoAct11 = Math.Round(pesoAct11, 4);
            if (pesoAct11 > peso11)
            {
                pesoAct11 = peso11;
            }
            pesototal = pesototal + pesoAct11;
        }
      
        //12) Sesiones de formación No. 1 presencial realizadas 
        DataTable sesionesformacion2016 = est.sesionesformacion2016(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "1");
        double meta12 = 0;
        int count12 = 0;
        int total12 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesionpresencial"].ToString());
        double peso12 = 1.41;
        double pesoAct12 = 0;
        if (sesionesformacion2016 != null && sesionesformacion2016.Rows.Count > 0)
        {
            count12 = sesionesformacion2016.Rows.Count;
            meta12 = ((double)count12 / (double)total12) * 100;
            meta12 = Math.Round(meta12, 2);
            //if (meta12 > 100)
            //{
            //    meta12 = 100;
            //}
            pesoAct12 = ((double)count12 / (double)total12) * peso12;
            pesoAct12 = Math.Round(pesoAct12, 4);
            if (pesoAct12 > peso12)
            {
                pesoAct12 = peso12;
            }
            pesototal = pesototal + pesoAct12;
        }
      

        //13) Estudiantes inscritos que participan en la primera sesión  de formación presencial/ Nivel 1 juego Gózate la ciencia.
        DataTable esturedtematicas2016 = est.esturedtematicasxanio(coddepartamento, codmuncipio, codinstitucion, codsede, "2016");
        //DataTable estuinscritog001_2016 = est.estuinscritog001_2016(coddepartamento, codmuncipio, codinstitucion, codsede);
        double meta13 = 0;
        int count13 = 0;
        int total13 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalesturedestematicas"].ToString());
        double peso13 = 1.41;
        double pesoAct13 = 0;
        if (esturedtematicas2016 != null && esturedtematicas2016.Rows.Count > 0)
        {
            count13 = esturedtematicas2016.Rows.Count;
            meta13 = ((double)count13 / (double)total13) * 100;
            meta13 = Math.Round(meta13, 2);
            //if (meta13 > 100)
            //{
            //    meta13 = 100;
            //}
            pesoAct13 = ((double)count13 / (double)total13) * peso13;
            pesoAct13 = Math.Round(pesoAct13, 4);
            if (pesoAct13 > peso13)
            {
                pesoAct13 = peso13;
            }
            pesototal = pesototal + pesoAct13;
        }
      


        //14) Sesiones de formación No. 1 virtual realizadas 
        DataTable sesionformacion_vt = est.sesionformacion_vt(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "1");
        double meta14 = 0;
        int count14 = 0;
        int total14 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesionvirtual"].ToString());
        double peso14 = 1.41;
        double pesoAct14 = 0;
        if (sesionformacion_vt != null && sesionformacion_vt.Rows.Count > 0)
        {
            count14 = sesionformacion_vt.Rows.Count;
            meta14 = ((double)count14 / (double)total14) * 100;
            meta14 = Math.Round(meta14, 2);
            //if (meta14 > 100)
            //{
            //    meta14 = 100;
            //}
            pesoAct14 = ((double)count14 / (double)total14) * peso14;
            pesoAct14 = Math.Round(pesoAct14, 4);
            if (pesoAct14 > peso14)
            {
                pesoAct14 = peso14;
            }
            pesototal = pesototal + pesoAct14;
        }
       

        //15) Estudiantes inscritos que participan en la primera sesión  de formación virtual/ Nivel 1 juego Gózate la ciencia.
        DataTable estuinscritossesion_vt = est.estuinscritossesion_vt(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "1");
        double meta15 = 0;
        int count15 = 0;
        int total15 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalesturedestematicas"].ToString());
        double peso15 = 1.41;
        double pesoAct15 = 0;
        //if (estuinscritossesion_vt != null && estuinscritossesion_vt.Rows.Count > 0)
        //{
        //    count15 = estuinscritossesion_vt.Rows.Count;
        //    meta15 = ((double)count15 / (double)total15) * 100;
        //    meta15 = Math.Round(meta15, 2);
        //    if (meta15 > 100)
        //    {
        //        meta15 = 100;
        //    }
        //}
        if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        {
            count15 = esturedtematicas.Rows.Count;
            meta15 = ((double)count15 / (double)total15) * 100;
            meta15 = Math.Round(meta15, 2);
            //if (meta15 > 100)
            //{
            //    meta15 = 100;
            //}
            pesoAct15 = ((double)count15 / (double)total15) * peso15;
            pesoAct15 = Math.Round(pesoAct15, 4);
            if (pesoAct15 > peso15)
            {
                pesoAct15 = peso15;
            }
            pesototal = pesototal + pesoAct15;
        }
       


        //16) Sesiones de formación presencial  No. 2 realizadas 
        DataTable sesionformacion_pre = est.sesionformacion_pre(coddepartamento, codmuncipio, codinstitucion, codsede, 4, 2);
        double meta16 = 0;
        int count16 = 0;
        int total16 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesionpresencial"].ToString());
        double peso16 = 1.41;
        double pesoAct16 = 0;
        if (sesionformacion_pre != null && sesionformacion_pre.Rows.Count > 0)
        {
            count16 = sesionformacion_pre.Rows.Count;
            meta16 = ((double)count16 / (double)total16) * 100;
            meta16 = Math.Round(meta16, 2);
            //if (meta16 > 100)
            //{
            //    meta16 = 100;
            //}
            pesoAct16 = ((double)count16 / (double)total16) * peso16;
            pesoAct16 = Math.Round(pesoAct16, 4);
            if (pesoAct16 > peso16)
            {
                pesoAct16 = peso16;
            }
            pesototal = pesototal + pesoAct16;
        }
       


        //17) Estudiantes inscritos que participan en la segunda sesión  de formación presencial/ Nivel 2 juego Gózate la ciencia.
        DataTable estuinscritossesion_pre = est.estuinscritossesion_pre(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "2");
        double meta17 = 0;
        int count17 = 0;
        int total17 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalesturedestematicas"].ToString());
        double peso17 = 1.41;
        double pesoAct17 = 0;
        //if (estuinscritossesion_pre != null && estuinscritossesion_pre.Rows.Count > 0)
        //{
        //    count17 = estuinscritossesion_pre.Rows.Count;
        //    meta17 = ((double)count17 / (double)total17) * 100;
        //    meta17 = Math.Round(meta17, 2);
        //    if (meta17 > 100)
        //    {
        //        meta17 = 100;
        //    }
        //}
        if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        {
            count17 = esturedtematicas.Rows.Count;
            meta17 = ((double)count17 / (double)total17) * 100;
            meta17 = Math.Round(meta17, 2);
            //if (meta17 > 100)
            //{
            //    meta17 = 100;
            //}
            pesoAct17 = ((double)count17 / (double)total17) * peso17;
            pesoAct17 = Math.Round(pesoAct17, 4);
            if (pesoAct17 > peso17)
            {
                pesoAct17 = peso17;
            }
            pesototal = pesototal + pesoAct17;
        }
       


        //18) Sesiones de formación virtual No. 2 realizadas 
        DataTable sesionformacion_vt_s2 = est.sesionformacion_vt(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "2");
        double meta18 = 0;
        int count18 = 0;
        int total18 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesionvirtual"].ToString());
        double peso18 = 0.31;
        double pesoAct18 = 0;
        if (sesionformacion_vt_s2 != null && sesionformacion_vt_s2.Rows.Count > 0)
        {
            count18 = sesionformacion_vt_s2.Rows.Count;
            meta18 = ((double)count18 / (double)total18) * 100;
            meta18 = Math.Round(meta18, 2);
            //if (meta18 > 100)
            //{
            //    meta18 = 100;
            //}
            pesoAct18 = ((double)count18 / (double)total18) * peso18;
            pesoAct18 = Math.Round(pesoAct18, 4);
            if (pesoAct18 > peso18)
            {
                pesoAct18 = peso18;
            }
            pesototal = pesototal + pesoAct18;
        }
       

        ///19) Estudiantes inscritos que participan en la segunda sesión de formación virtual/ Nivel 2 juego Gózate la ciencia.
        DataTable estuinscritossesion_vt_s2 = est.estuinscritossesion_vt(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "2");
        double meta19 = 0;
        int count19 = 0;
        int total19 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalesturedestematicas"].ToString());
        double peso19 = 1.41;
        double pesoAct19 = 0;
        //if (estuinscritossesion_vt_s2 != null && estuinscritossesion_vt_s2.Rows.Count > 0)
        //{
        //    count19 = estuinscritossesion_vt_s2.Rows.Count;
        //    meta19 = ((double)count19 / (double)total19) * 100;
        //    meta19 = Math.Round(meta19, 2);
        //    if (meta19 > 100)
        //    {
        //        meta19 = 100;
        //    }
        //}
        if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        {
            count19 = esturedtematicas.Rows.Count;
            meta19 = ((double)count19 / (double)total19) * 100;
            meta19 = Math.Round(meta19, 2);
            //if (meta19 > 100)
            //{
            //    meta19 = 100;
            //}
            pesoAct19 = ((double)count19 / (double)total19) * peso19;
            pesoAct19 = Math.Round(pesoAct19, 4);
            if (pesoAct19 > peso19)
            {
                pesoAct19 = peso19;
            }
            pesototal = pesototal + pesoAct19;
        }
       
        //20) Sesiones de formación No. 3 realizadas 
        DataTable sesionformacion_pre_s3 = est.sesionformacion_pre(coddepartamento, codmuncipio, codinstitucion, codsede, 4, 3);
        double meta20 = 0;
        int count20 = 0;
        int total20 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesionpresencial"].ToString());
        double peso20 = 1.41;
        double pesoAct20 = 0;
        if (sesionformacion_pre_s3 != null && sesionformacion_pre_s3.Rows.Count > 0)
        {
            count20 = sesionformacion_pre_s3.Rows.Count;
            meta20 = ((double)count20 / (double)total20) * 100;
            meta20 = Math.Round(meta20, 2);
            //if (meta20 > 100)
            //{
            //    meta20 = 100;
            //}
            pesoAct20 = ((double)count20 / (double)total20) * peso20;
            pesoAct20 = Math.Round(pesoAct20, 4);
            if (pesoAct20 > peso20)
            {
                pesoAct20 = peso20;
            }
            pesototal = pesototal + pesoAct20;
        }
      

        //21) Estudiantes inscritos que participan en la tercera sesión  de formación presencial/ Nivel 3 juego Gózate la ciencia.
        DataTable estuinscritossesion_pre_s3 = est.estuinscritossesion_pre(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "3");
        double meta21 = 0;
        int count21 = 0;
        int total21 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalesturedestematicas"].ToString());
        double peso21 = 1.41;
        double pesoAct21 = 0;
        //if (estuinscritossesion_pre_s3 != null && estuinscritossesion_pre_s3.Rows.Count > 0)
        //{
        //    count21 = estuinscritossesion_pre_s3.Rows.Count;
        //    meta21 = ((double)count21 / (double)total21) * 100;
        //    meta21 = Math.Round(meta21, 2);
        //    if (meta21 > 100)
        //    {
        //        meta21 = 100;
        //    }
        //}
        if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        {
            count21 = esturedtematicas.Rows.Count;
            meta21 = ((double)count21 / (double)total21) * 100;
            meta21 = Math.Round(meta21, 2);
            //if (meta21 > 100)
            //{
            //    meta21 = 100;
            //}
            pesoAct21 = ((double)count21 / (double)total21) * peso21;
            pesoAct21 = Math.Round(pesoAct21, 4);
            if (pesoAct21 > peso21)
            {
                pesoAct21 = peso21;
            }
            pesototal = pesototal + pesoAct21;
        }
       

        //22) Sesiones de formación virtual  No. 3 realizadas 
        DataTable sesionformacion_vt_s3 = est.sesionformacion_vt(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "3");
        double meta22 = 0;
        int count22 = 0;
        int total22 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesionvirtual"].ToString());
        double peso22 = 1.41;
        double pesoAct22 = 0;

        if (sesionformacion_vt_s3 != null && sesionformacion_vt_s3.Rows.Count > 0)
        {
            count22 = sesionformacion_vt_s3.Rows.Count;
            meta22 = ((double)count22 / (double)total22) * 100;
            meta22 = Math.Round(meta22, 2);
            //if (meta22 > 100)
            //{
            //    meta22 = 100;
            //}
            pesoAct22 = ((double)count22 / (double)total22) * peso22;
            pesoAct22 = Math.Round(pesoAct22, 4);
            if (pesoAct22 > peso22)
            {
                pesoAct22 = peso22;
            }
            pesototal = pesototal + pesoAct22;
        }
        

        //23) Estudiantes inscritos que participan en la tercera sesión  de formación virtual/ Nivel 3 juego Gózate la ciencia.
        DataTable estuinscritossesion_vt_s3 = est.estuinscritossesion_vt(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "3");
        double meta23 = 0;
        int count23 = 0;
        int total23 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalesturedestematicas"].ToString());
        double peso23 = 1.41;
        double pesoAct23 = 0;
        //if (estuinscritossesion_vt_s3 != null && estuinscritossesion_vt_s3.Rows.Count > 0)
        //{
        //    count23 = estuinscritossesion_vt_s3.Rows.Count;
        //    meta23 = ((double)count23 / (double)total23) * 100;
        //    meta23 = Math.Round(meta23, 2);
        //    if (meta23 > 100)
        //    {
        //        meta23 = 100;
        //    }
        //}
        if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        {
            count23 = esturedtematicas.Rows.Count;
            meta23 = ((double)count23 / (double)total23) * 100;
            meta23 = Math.Round(meta23, 2);
            //if (meta23 > 100)
            //{
            //    meta23 = 100;
            //}
            pesoAct23 = ((double)count23 / (double)total23) * peso23;
            pesoAct23 = Math.Round(pesoAct23, 4);
            if (pesoAct23 > peso23)
            {
                pesoAct23 = peso23;
            }
            pesototal = pesototal + pesoAct23;
        }
       

        //24) Sesiones de formación No. 4 realizadas
        DataTable sesionformacion_pre_s4 = est.sesionformacion_pre(coddepartamento, codmuncipio, codinstitucion, codsede, 4, 4);
        double meta24 = 0;
        int count24 = 0;
        int total24 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesionpresencial"].ToString());
        double peso24 = 1.41;
        double pesoAct24 = 0;
        if (sesionformacion_pre_s4 != null && sesionformacion_pre_s4.Rows.Count > 0)
        {
            count24 = sesionformacion_pre_s4.Rows.Count;
            meta24 = ((double)count24 / (double)total24) * 100;
            meta24 = Math.Round(meta24, 2);
            //if (meta24 > 100)
            //{
            //    meta24 = 100;
            //}
            pesoAct24 = ((double)count24 / (double)total24) * peso24;
            pesoAct24 = Math.Round(pesoAct24, 4);
            if (pesoAct24 > peso24)
            {
                pesoAct24 = peso24;
            }
            pesototal = pesototal + pesoAct24;
        }
       

        //25) Estudiantes inscritos que participan en la tercera sesión  de formación presencial/ Nivel 4 juego Gózate la ciencia.
        DataTable estuinscritossesion_pre_s4 = est.estuinscritossesion_pre(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "4");
        double meta25 = 0;
        int count25 = 0;
        int total25 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalesturedestematicas"].ToString());
        double peso25 = 1.41;
        double pesoAct25 = 0;
        //if (estuinscritossesion_pre_s4 != null && estuinscritossesion_pre_s4.Rows.Count > 0)
        //{
        //    count25 = estuinscritossesion_pre_s4.Rows.Count;
        //    meta25 = ((double)count25 / (double)total25) * 100;
        //    meta25 = Math.Round(meta25, 2);
        //    if (meta25 > 100)
        //    {
        //        meta25 = 100;
        //    }
        //}
        if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        {
            count25 = esturedtematicas.Rows.Count;
            meta25 = ((double)count25 / (double)total25) * 100;
            meta25 = Math.Round(meta25, 2);
            //if (meta25 > 100)
            //{
            //    meta25 = 100;
            //}
            pesoAct25 = ((double)count25 / (double)total25) * peso25;
            pesoAct25 = Math.Round(pesoAct25, 4);
            if (pesoAct25 > peso25)
            {
                pesoAct25 = peso25;
            }
            pesototal = pesototal + pesoAct25;
        }
      


        //26) Sesiones de formación virtual  No.4 realizadas 
        DataTable sesionformacion_vt_s4 = est.sesionformacion_vt(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "4");
        double meta26 = 0;
        int count26 = 0;
        int total26 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesionvirtual"].ToString());
        double peso26 = 1.41;
        double pesoAct26 = 0;
        if (sesionformacion_vt_s4 != null && sesionformacion_vt_s4.Rows.Count > 0)
        {
            count26 = sesionformacion_vt_s4.Rows.Count;
            meta26 = ((double)count26 / (double)total26) * 100;
            meta26 = Math.Round(meta26, 2);
            //if (meta26 > 100)
            //{
            //    meta26 = 100;
            //}
            pesoAct26 = ((double)count26 / (double)total26) * peso26;
            pesoAct26 = Math.Round(pesoAct26, 4);
            if (pesoAct26 > peso26)
            {
                pesoAct26 = peso26;
            }
            pesototal = pesototal + pesoAct26;
        }
      

        //27) Estudiantes inscritos que participan en la tercera sesión  de formación virtual/ Nivel 4 juego Gózate la ciencia.
        DataTable estuinscritossesion_vt_s4 = est.estuinscritossesion_vt(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "4");
        double meta27 = 0;
        int count27 = 0;
        int total27 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalesturedestematicas"].ToString());
        double peso27 = 1.41;
        double pesoAct27 = 0;
        //if (estuinscritossesion_vt_s4 != null && estuinscritossesion_vt_s4.Rows.Count > 0)
        //{
        //    count27 = estuinscritossesion_vt_s4.Rows.Count;
        //    meta27 = ((double)count27 / (double)total27) * 100;
        //    meta27 = Math.Round(meta27, 2);
        //    if (meta27 > 100)
        //    {
        //        meta27 = 100;
        //    }
        //}
        if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        {
            count27 = esturedtematicas.Rows.Count;
            meta27 = ((double)count27 / (double)total27) * 100;
            meta27 = Math.Round(meta27, 2);
            //if (meta27 > 100)
            //{
            //    meta27 = 100;
            //}
            pesoAct27 = ((double)count27 / (double)total27) * peso27;
            pesoAct27 = Math.Round(pesoAct27, 4);
            if (pesoAct27 > peso27)
            {
                pesoAct27 = peso27;
            }
            pesototal = pesototal + pesoAct27;
        }
       

        //33) Sesiones de formación No. 5 realizadas
        DataTable sesionesformacion5 = est.sesionformacion_pre(coddepartamento, codmuncipio, codinstitucion, codsede, 4, 5);
        double meta33 = 0;
        int count33 = 0;
        int total33 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesionpresencial"].ToString());
        double peso33 = 1.41;
        double pesoAct33 = 0;
        if (sesionesformacion5 != null && sesionesformacion5.Rows.Count > 0)
        {
            count33 = sesionesformacion5.Rows.Count;
            meta33 = ((double)count33 / (double)total33) * 100;
            meta33 = Math.Round(meta33, 2);
            //if (meta33 > 100)
            //{
            //    meta33 = 100;
            //}
            pesoAct33 = ((double)count33 / (double)total33) * peso33;
            pesoAct33 = Math.Round(pesoAct33, 4);
            if (pesoAct33 > peso33)
            {
                pesoAct33 = peso33;
            }
            pesototal = pesototal + pesoAct33;
        }
       

        //34) Estudiantes inscritos que participan en la quinta sesión  de formación presencial/ Nivel 5 juego Gózate la ciencia.
        DataTable estuinscritossesion_pre_s5 = est.estuinscritossesion_pre(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "5");
        double meta34 = 0;
        int count34 = 0;
        int total34 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalesturedestematicas"].ToString());
        double peso34 = 1.41;
        double pesoAct34 = 0;
        //if (estuinscritossesion_pre_s5 != null && estuinscritossesion_pre_s5.Rows.Count > 0)
        //{
        //    count34 = estuinscritossesion_pre_s5.Rows.Count;
        //    meta34 = ((double)count34 / (double)total34) * 100;
        //    meta34 = Math.Round(meta34, 2);
        //    if (meta34 > 100)
        //    {
        //        meta34 = 100;
        //    }
        //}
        if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        {
            count34 = esturedtematicas.Rows.Count;
            meta34 = ((double)count34 / (double)total34) * 100;
            meta34 = Math.Round(meta34, 2);
            //if (meta34 > 100)
            //{
            //    meta34 = 100;
            //}
            pesoAct34 = ((double)count34 / (double)total34) * peso34;
            pesoAct34 = Math.Round(pesoAct34, 4);
            if (pesoAct34 > peso34)
            {
                pesoAct34 = peso34;
            }
            pesototal = pesototal + pesoAct34;
        }
         

        //35) Sesiones de formación virtual No. 5 realizadas 
        DataTable sesionformacion_vt_s5 = est.sesionformacion_vt(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "5");
        double meta35 = 0;
        int count35 = 0;
        int total35 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesionvirtual"].ToString());
        double peso35 = 1.41;
        double pesoAct35 = 0;
        if (sesionformacion_vt_s5 != null && sesionformacion_vt_s5.Rows.Count > 0)
        {
            count35 = sesionformacion_vt_s5.Rows.Count;
            meta35 = ((double)count35 / (double)total35) * 100;
            meta35 = Math.Round(meta35, 2);
            //if (meta35 > 100)
            //{
            //    meta35 = 100;
            //}
            pesoAct35 = ((double)count35 / (double)total35) * peso35;
            pesoAct35 = Math.Round(pesoAct35, 4);
            if (pesoAct35 > peso35)
            {
                pesoAct35 = peso35;
            }
            pesototal = pesototal + pesoAct35;
        }
        


        //36) Estudiantes inscritos que participan en la quinta sesión  de formación virtual/ Nivel 5 juego Gózate la ciencia.
        DataTable estuinscritossesion_vt_s5 = est.estuinscritossesion_vt(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "5");
        double meta36 = 0;
        int count36 = 0;
        int total36 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalesturedestematicas"].ToString());
        double peso36 = 1.41;
        double pesoAct36 = 0;
        //if (estuinscritossesion_vt_s5 != null && estuinscritossesion_vt_s5.Rows.Count > 0)
        //{
        //    count36 = estuinscritossesion_vt_s5.Rows.Count;
        //    meta36 = ((double)count36 / (double)total36) * 100;
        //    meta36 = Math.Round(meta36, 2);
        //    if (meta36 > 100)
        //    {
        //        meta36 = 100;
        //    }
        //}
        if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        {
            count36 = esturedtematicas.Rows.Count;
            meta36 = ((double)count36 / (double)total36) * 100;
            meta36 = Math.Round(meta36, 2);
            //if (meta36 > 100)
            //{
            //    meta36 = 100;
            //}
            pesoAct36 = ((double)count36 / (double)total36) * peso36;
            pesoAct36 = Math.Round(pesoAct36, 4);
            if (pesoAct36 > peso36)
            {
                pesoAct36 = peso36;
            }
            pesototal = pesototal + pesoAct36;
        }
        

        //--------------- SESION 6 ----------------------
        //37) Sesiones de formación No. 6 realizadas 
        DataTable sesionesformacion6 = est.sesionformacion_pre(coddepartamento, codmuncipio, codinstitucion, codsede, 4, 6);
        double meta37 = 0;
        int count37 = 0;
        int total37 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesionpresencial"].ToString());
        double peso37 = 1.41;
        double pesoAct37 = 0;
        if (sesionesformacion6 != null && sesionesformacion6.Rows.Count > 0)
        {
            count37 = sesionesformacion6.Rows.Count;
            meta37 = ((double)count37 / (double)total37) * 100;
            meta37 = Math.Round(meta37, 2);
            //if (meta37 > 100)
            //{
            //    meta37 = 100;
            //}
            pesoAct37 = ((double)count37 / (double)total37) * peso37;
            pesoAct37 = Math.Round(pesoAct37, 4);
            if (pesoAct37 > peso37)
            {
                pesoAct37 = peso37;
            }
            pesototal = pesototal + pesoAct37;
        }
        

        //38) Estudiantes inscritos que participan en la sexta sesión  de formación presencial/ Nivel 6 juego Gózate la ciencia
        DataTable estuinscritossesion_pre_s6 = est.estuinscritossesion_pre(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "6");
        double meta38 = 0;
        int count38 = 0;
        int total38 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalesturedestematicas"].ToString());
        double peso38 = 1.41;
        double pesoAct38 = 0;
        //if (estuinscritossesion_pre_s6 != null && estuinscritossesion_pre_s6.Rows.Count > 0)
        //{
        //    count38 = estuinscritossesion_pre_s6.Rows.Count;
        //    meta38 = ((double)count38 / (double)total38) * 100;
        //    meta38 = Math.Round(meta38, 2);
        //    if (meta38 > 100)
        //    {
        //        meta38 = 100;
        //    }
        //}
        if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        {
            count38 = esturedtematicas.Rows.Count;
            meta38 = ((double)count38 / (double)total38) * 100;
            meta38 = Math.Round(meta38, 2);
            //if (meta38 > 100)
            //{
            //    meta38 = 100;
            //}
            pesoAct38 = ((double)count38 / (double)total38) * peso38;
            pesoAct38 = Math.Round(pesoAct38, 4);
            if (pesoAct38 > peso38)
            {
                pesoAct38 = peso38;
            }
            pesototal = pesototal + pesoAct38;
        }
        

        //39) Sesiones de formación virtual  No. 6 realizadas 
        DataTable sesionformacion_vt_s6 = est.sesionformacion_vt(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "6");
        double meta39 = 0;
        int count39 = 0;
        int total39 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesionvirtual"].ToString());
        double peso39 = 1.41;
        double pesoAct39 = 0;
        if (sesionformacion_vt_s6 != null && sesionformacion_vt_s6.Rows.Count > 0)
        {
            count39 = sesionformacion_vt_s6.Rows.Count;
            meta39 = ((double)count39 / (double)total39) * 100;
            meta39 = Math.Round(meta39, 2);
            //if (meta39 > 100)
            //{
            //    meta39 = 100;
            //}
            pesoAct39 = ((double)count39 / (double)total39) * peso39;
            pesoAct39 = Math.Round(pesoAct39, 4);
            if (pesoAct39 > peso39)
            {
                pesoAct39 = peso39;
            }
            pesototal = pesototal + pesoAct39;
        }
         

        //40)  Estudiantes inscritos que participan en la sexta sesión  de formación virtual/ Nivel 6 juego Gózate la ciencia.
        DataTable estuinscritossesion_vt_s6 = est.estuinscritossesion_vt(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "6");
        double meta40 = 0;
        int count40 = 0;
        int total40 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalesturedestematicas"].ToString());
        double peso40 = 1.41;
        double pesoAct40 = 0;
        //if (estuinscritossesion_vt_s6 != null && estuinscritossesion_vt_s6.Rows.Count > 0)
        //{
        //    count40 = estuinscritossesion_vt_s6.Rows.Count;
        //    meta40 = ((double)count40 / (double)total40) * 100;
        //    meta40 = Math.Round(meta40, 2);
        //    if (meta40 > 100)
        //    {
        //        meta40 = 100;
        //    }
        //}
        if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        {
            count40 = esturedtematicas.Rows.Count;
            meta40 = ((double)count40 / (double)total40) * 100;
            meta40 = Math.Round(meta40, 2);
            //if (meta40 > 100)
            //{
            //    meta40 = 100;
            //}
            pesoAct40 = ((double)count40 / (double)total40) * peso40;
            pesoAct40 = Math.Round(pesoAct40, 4);
            if (pesoAct40 > peso40)
            {
                pesoAct40 = peso40;
            }
            pesototal = pesototal + pesoAct40;
        }
         
        //--------------- SESION 7 ----------------------
        //41) Sesiones de formación No. 7 realizadas 
        DataTable sesionesformacion7 = est.sesionformacion_pre(coddepartamento, codmuncipio, codinstitucion, codsede, 4, 7);
        double meta41 = 0;
        int count41 = 0;
        int total41 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesionpresencial"].ToString());
        double peso41 = 1.41;
        double pesoAct41 = 0;
        if (sesionesformacion7 != null && sesionesformacion7.Rows.Count > 0)
        {
            count41 = sesionesformacion7.Rows.Count;
            meta41 = ((double)count41 / (double)total41) * 100;
            meta41 = Math.Round(meta41, 2);
            //if (meta41 > 100)
            //{
            //    meta41 = 100;
            //}
            pesoAct41 = ((double)count41 / (double)total41) * peso41;
            pesoAct41 = Math.Round(pesoAct41, 4);
            if (pesoAct41 > peso41)
            {
                pesoAct41 = peso41;
            }
            pesototal = pesototal + pesoAct41;
        }
        
        //42) Estudiantes inscritos que participan en la séptima sesión  de formación presencial/ Nivel 1 juego Gózate la ciencia
        DataTable estuinscritossesion_pre_s7 = est.estuinscritossesion_pre(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "7");
        double meta42 = 0;
        int count42 = 0;
        int total42 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalesturedestematicas"].ToString());
        double peso42 = 1.41;
        double pesoAct42 = 0;
        //if (estuinscritossesion_pre_s7 != null && estuinscritossesion_pre_s7.Rows.Count > 0)
        //{
        //    count42 = estuinscritossesion_pre_s7.Rows.Count;
        //    meta42 = ((double)count42 / (double)total42) * 100;
        //    meta42 = Math.Round(meta42, 2);
        //    if (meta42 > 100)
        //    {
        //        meta42 = 100;
        //    }
        //}
        if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        {
            count42 = esturedtematicas.Rows.Count;
            meta42 = ((double)count42 / (double)total42) * 100;
            meta42 = Math.Round(meta42, 2);
            //if (meta42 > 100)
            //{
            //    meta42 = 100;
            //}
            pesoAct42 = ((double)count42 / (double)total42) * peso42;
            pesoAct42 = Math.Round(pesoAct42, 4);
            if (pesoAct42 > peso42)
            {
                pesoAct42 = peso42;
            }
            pesototal = pesototal + pesoAct42;
        }
        

        //43) Sesiones de formación virtual  No. 7 realizadas 
        DataTable sesionformacion_vt_s7 = est.sesionformacion_vt(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "7");
        double meta43 = 0;
        int count43 = 0;
        int total43 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesionvirtual"].ToString());
        double peso43 = 1.41;
        double pesoAct43 = 0;
        if (sesionformacion_vt_s7 != null && sesionformacion_vt_s7.Rows.Count > 0)
        {
            count43 = sesionformacion_vt_s7.Rows.Count;
            meta43 = ((double)count43 / (double)total43) * 100;
            meta43 = Math.Round(meta43, 2);
            //if (meta43 > 100)
            //{
            //    meta43 = 100;
            //}
            pesoAct43 = ((double)count43 / (double)total43) * peso43;
            pesoAct43 = Math.Round(pesoAct43, 4);
            if (pesoAct43 > peso43)
            {
                pesoAct43 = peso43;
            }
            pesototal = pesototal + pesoAct43;
        }
        

        //44) Estudiantes inscritos que participan en la séptima sesión  de formación virtual/ Nivel 7 juego Gózate la ciencia 
        DataTable estuinscritossesion_vt_s7 = est.estuinscritossesion_vt(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "7");
        double meta44 = 0;
        int count44 = 0;
        int total44 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalesturedestematicas"].ToString());
        double peso44 = 1.41;
        double pesoAct44 = 0;
        //if (estuinscritossesion_vt_s7 != null && estuinscritossesion_vt_s7.Rows.Count > 0)
        //{
        //    count44 = estuinscritossesion_vt_s7.Rows.Count;
        //    meta44 = ((double)count44 / (double)total44) * 100;
        //    meta44 = Math.Round(meta44, 2);
        //    if (meta44 > 100)
        //    {
        //        meta44 = 100;
        //    }
        //}
        if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        {
            count44 = esturedtematicas.Rows.Count;
            meta44 = ((double)count44 / (double)total44) * 100;
            meta44 = Math.Round(meta44, 2);
            //if (meta44 > 100)
            //{
            //    meta44 = 100;
            //}
            pesoAct44 = ((double)count44 / (double)total44) * peso44;
            pesoAct44 = Math.Round(pesoAct44, 4);
            if (pesoAct44 > peso44)
            {
                pesoAct44 = peso44;
            }
            pesototal = pesototal + pesoAct44;
        }
       



        //--------------- SESION 8 ----------------------
        //45) Sesiones de formación No. 8 realizadas 
        DataTable sesionesformacion8 = est.sesionformacion_pre(coddepartamento, codmuncipio, codinstitucion, codsede, 4, 8);
        double meta45 = 0;
        int count45 = 0;
        int total45 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesionpresencial"].ToString());
        double peso45 = 1.41;
        double pesoAct45 = 0;
        if (sesionesformacion8 != null && sesionesformacion8.Rows.Count > 0)
        {
            count45 = sesionesformacion8.Rows.Count;
            meta45 = ((double)count45 / (double)total45) * 100;
            meta45 = Math.Round(meta45, 2);
            //if (meta45 > 100)
            //{
            //    meta45 = 100;
            //}
            pesoAct45 = ((double)count45 / (double)total45) * peso45;
            pesoAct45 = Math.Round(pesoAct45, 4);
            if (pesoAct45 > peso45)
            {
                pesoAct45 = peso45;
            }
            pesototal = pesototal + pesoAct45;
        }
       

        //46) Estudiantes inscritos que participan en la  octava sesión  de formación presencial/ Nivel 8 juego Gózate la ciencia
        DataTable estuinscritossesion_pre_s8 = est.estuinscritossesion_pre(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "8");
        double meta46 = 0;
        int count46 = 0;
        int total46 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalesturedestematicas"].ToString());
        double peso46 = 1.41;
        double pesoAct46 = 0;
        //if (estuinscritossesion_pre_s8 != null && estuinscritossesion_pre_s8.Rows.Count > 0)
        //{
        //    count46 = estuinscritossesion_pre_s8.Rows.Count;
        //    meta46 = ((double)count46 / (double)total46) * 100;
        //    meta46 = Math.Round(meta46, 2);
        //    if (meta46 > 100)
        //    {
        //        meta46 = 100;
        //    }
        //}
        if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        {
            count46 = esturedtematicas.Rows.Count;
            meta46 = ((double)count46 / (double)total46) * 100;
            meta46 = Math.Round(meta46, 2);
            //if (meta46 > 100)
            //{
            //    meta46 = 100;
            //}
            pesoAct46 = ((double)count46 / (double)total46) * peso46;
            pesoAct46 = Math.Round(pesoAct46, 4);
            if (pesoAct46 > peso46)
            {
                pesoAct46 = peso46;
            }
            pesototal = pesototal + pesoAct46;
        }
        
        //47) Sesiones de formación virtual No. 8 realizadas 
        DataTable sesionformacion_vt_s8 = est.sesionformacion_vt(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "8");
        double meta47 = 0;
        int count47 = 0;
        int total47 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesionvirtual"].ToString());
        double peso47 = 1.41;
        double pesoAct47 = 0;
        if (sesionformacion_vt_s8 != null && sesionformacion_vt_s8.Rows.Count > 0)
        {
            count47 = sesionformacion_vt_s8.Rows.Count;
            meta47 = ((double)count47 / (double)total47) * 100;
            meta47 = Math.Round(meta47, 2);
            //if (meta47 > 100)
            //{
            //    meta47 = 100;
            //}
            pesoAct47 = ((double)count47 / (double)total47) * peso47;
            pesoAct47 = Math.Round(pesoAct47, 4);
            if (pesoAct47 > peso47)
            {
                pesoAct47 = peso47;
            }
            pesototal = pesototal + pesoAct47;
        }
       

        //48) Estudiantes inscritos que participan en la  octava sesión  de formación virtual/ Nivel 8 juego Gózate la ciencia
        DataTable estuinscritossesion_vt_s8 = est.estuinscritossesion_vt(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "8");
        double meta48 = 0;
        int count48 = 0;
        int total48 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalesturedestematicas"].ToString());
        double peso48 = 1.41;
        double pesoAct48 = 0;
        //if (estuinscritossesion_vt_s8 != null && estuinscritossesion_vt_s8.Rows.Count > 0)
        //{
        //    count48 = estuinscritossesion_vt_s8.Rows.Count;
        //    meta48 = ((double)count48 / (double)total48) * 100;
        //    meta48 = Math.Round(meta48, 2);
        //    if (meta48 > 100)
        //    {
        //        meta48 = 100;
        //    }
        //}
        if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        {
            count48 = esturedtematicas.Rows.Count;
            meta48 = ((double)count48 / (double)total48) * 100;
            meta48 = Math.Round(meta48, 2);
            //if (meta48 > 100)
            //{
            //    meta48 = 100;
            //}
            pesoAct48 = ((double)count48 / (double)total48) * peso48;
            pesoAct48 = Math.Round(pesoAct48, 4);
            if (pesoAct48 > peso48)
            {
                pesoAct48 = peso48;
            }
            pesototal = pesototal + pesoAct48;
        }
        


        //--------------- SESION 9 ----------------------
        //49) Sesiones de formación No. 9 realizadas 
        DataTable sesionesformacion9 = est.sesionformacion_pre(coddepartamento, codmuncipio, codinstitucion, codsede, 4, 9);
        double meta49 = 0;
        int count49 = 0;
        int total49 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesionpresencial"].ToString());
        double peso49 = 1.41;
        double pesoAct49 = 0;
        if (sesionesformacion9 != null && sesionesformacion9.Rows.Count > 0)
        {
            count49 = sesionesformacion9.Rows.Count;
            meta49 = ((double)count49 / (double)total49) * 100;
            meta49 = Math.Round(meta49, 2);
            //if (meta49 > 100)
            //{
            //    meta49 = 100;
            //}
            pesoAct49 = ((double)count49 / (double)total49) * peso49;
            pesoAct49 = Math.Round(pesoAct49, 4);
            if (pesoAct49 > peso49)
            {
                pesoAct49 = peso49;
            }
            pesototal = pesototal + pesoAct49;
        }
       
        //50) Estudiantes inscritos que participan en la  novena sesión  de formación presencial/ Nivel 9 juego Gózate la ciencia
        DataTable estuinscritossesion_pre_s9 = est.estuinscritossesion_pre(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "9");
        double meta50 = 0;
        int count50 = 0;
        int total50 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalesturedestematicas"].ToString());
        double peso50 = 1.41;
        double pesoAct50 = 0;
        //if (estuinscritossesion_pre_s9 != null && estuinscritossesion_pre_s9.Rows.Count > 0)
        //{
        //    count50 = estuinscritossesion_pre_s9.Rows.Count;
        //    meta50 = ((double)count50 / (double)total50) * 100;
        //    meta50 = Math.Round(meta50, 2);
        //    if (meta50 > 100)
        //    {
        //        meta50 = 100;
        //    }
        //}
        if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        {
            count50 = esturedtematicas.Rows.Count;
            meta50 = ((double)count50 / (double)total50) * 100;
            meta50 = Math.Round(meta50, 2);
            //if (meta50 > 100)
            //{
            //    meta50 = 100;
            //}
            pesoAct50 = ((double)count50 / (double)total50) * peso50;
            pesoAct50 = Math.Round(pesoAct50, 4);
            if (pesoAct50 > peso50)
            {
                pesoAct50 = peso50;
            }
            pesototal = pesototal + pesoAct50;
        }
        


        //51) Sesiones de formación virtual No. 9 realizadas 
        DataTable sesionformacion_vt_s9 = est.sesionformacion_vt(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "9");
        double meta51 = 0;
        int count51 = 0;
        int total51 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesionvirtual"].ToString());
        double peso51 = 1.41;
        double pesoAct51 = 0;
        if (sesionformacion_vt_s9 != null && sesionformacion_vt_s9.Rows.Count > 0)
        {
            count51 = sesionformacion_vt_s9.Rows.Count;
            meta51 = ((double)count51 / (double)total51) * 100;
            meta51 = Math.Round(meta51, 2);
            //if (meta51 > 100)
            //{
            //    meta51 = 100;
            //}
            pesoAct51 = ((double)count51 / (double)total51) * peso51;
            pesoAct51 = Math.Round(pesoAct51, 4);
            if (pesoAct51 > peso51)
            {
                pesoAct51 = peso51;
            }
            pesototal = pesototal + pesoAct51;
        }
        

        //52) Estudiantes inscritos que participan en la  novena sesión  de formación virtual/ Nivel 9 juego Gózate la ciencia
        DataTable estuinscritossesion_vt_s9 = est.estuinscritossesion_vt(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "9");
        double meta52 = 0;
        int count52 = 0;
        int total52 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalesturedestematicas"].ToString());
        double peso52 = 1.41;
        double pesoAct52 = 0;
        //if (estuinscritossesion_vt_s9 != null && estuinscritossesion_vt_s9.Rows.Count > 0)
        //{
        //    count52 = estuinscritossesion_vt_s9.Rows.Count;
        //    meta52 = ((double)count52 / (double)total52) * 100;
        //    meta52 = Math.Round(meta52, 2);
        //    if (meta52 > 100)
        //    {
        //        meta52 = 100;
        //    }
        //}
        if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        {
            count52 = esturedtematicas.Rows.Count;
            meta52 = ((double)count52 / (double)total52) * 100;
            meta52 = Math.Round(meta52, 2);
            //if (meta52 > 100)
            //{
            //    meta52 = 100;
            //}
            pesoAct52 = ((double)count52 / (double)total52) * peso52;
            pesoAct52 = Math.Round(pesoAct52, 4);
            if (pesoAct52 > peso52)
            {
                pesoAct52 = peso52;
            }
            pesototal = pesototal + pesoAct52;
        }
        

        //--------------- SESION 10 ----------------------
        //53) Sesiones de formación No. 9 realizadas 
        DataTable sesionesformacion10 = est.sesionformacion_pre(coddepartamento, codmuncipio, codinstitucion, codsede, 4, 10);
        double meta53 = 0;
        int count53 = 0;
        int total53 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesionpresencial"].ToString());
        double peso53 = 1.41;
        double pesoAct53 = 0;
        if (sesionesformacion10 != null && sesionesformacion10.Rows.Count > 0)
        {
            count53 = sesionesformacion10.Rows.Count;
            meta53 = ((double)count53 / (double)total53) * 100;
            meta53 = Math.Round(meta53, 2);
            //if (meta53 > 100)
            //{
            //    meta53 = 100;
            //}
            pesoAct53 = ((double)count53 / (double)total53) * peso53;
            pesoAct53 = Math.Round(pesoAct53, 4);
            if (pesoAct53 > peso53)
            {
                pesoAct53 = peso53;
            }
            pesototal = pesototal + pesoAct53;
        }
        

        //54)  Estudiantes inscritos que participan en la decina sesión  de formación presencial/ Nivel 10 juego Gózate la ciencia
        DataTable estuinscritossesion_pre_s10 = est.estuinscritossesion_pre(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "10");
        double meta54 = 0;
        int count54 = 0;
        int total54 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalesturedestematicas"].ToString());
        double peso54 = 1.41;
        double pesoAct54 = 0;
        //if (estuinscritossesion_pre_s10 != null && estuinscritossesion_pre_s10.Rows.Count > 0)
        //{
        //    count54 = estuinscritossesion_pre_s10.Rows.Count;
        //    meta54 = ((double)count54 / (double)total54) * 100;
        //    meta54 = Math.Round(meta54, 2);
        //    if (meta54 > 100)
        //    {
        //        meta54 = 100;
        //    }
        //}
        if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        {
            count54 = esturedtematicas.Rows.Count;
            meta54 = ((double)count54 / (double)total54) * 100;
            meta54 = Math.Round(meta54, 2);
            //if (meta54 > 100)
            //{
            //    meta54 = 100;
            //}
            pesoAct54 = ((double)count54 / (double)total54) * peso54;
            pesoAct54 = Math.Round(pesoAct54, 4);
            if (pesoAct54 > peso54)
            {
                pesoAct54 = peso54;
            }
            pesototal = pesototal + pesoAct54;
        }
      


        //55) Sesiones de formación virtual No. 10 realizadas 
        DataTable sesionformacion_vt_s10 = est.sesionformacion_vt(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "10");
        double meta55 = 0;
        int count55 = 0;
        int total55 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesionvirtual"].ToString());
        double peso55 = 1.41;
        double pesoAct55 = 0;
        if (sesionformacion_vt_s10 != null && sesionformacion_vt_s10.Rows.Count > 0)
        {
            count55 = sesionformacion_vt_s10.Rows.Count;
            meta55 = ((double)count55 / (double)total55) * 100;
            meta55 = Math.Round(meta55, 2);
            //if (meta55 > 100)
            //{
            //    meta55 = 100;
            //}
            pesoAct55 = ((double)count55 / (double)total55) * peso55;
            pesoAct55 = Math.Round(pesoAct55, 4);
            if (pesoAct55 > peso55)
            {
                pesoAct55 = peso55;
            }
            pesototal = pesototal + pesoAct55;
        }
        


        //56) Estudiantes inscritos que participan en la decina sesión  de formación virtual/ Nivel 10 juego Gózate la ciencia
        DataTable estuinscritossesion_vt_s10 = est.estuinscritossesion_vt(coddepartamento, codmuncipio, codinstitucion, codsede, "4", "10");
        double meta56 = 0;
        int count56 = 0;
        int total56 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalesturedestematicas"].ToString());
        double peso56 = 1.41;
        double pesoAct56 = 0;
        //if (estuinscritossesion_vt_s10 != null && estuinscritossesion_vt_s10.Rows.Count > 0)
        //{
        //    count56 = estuinscritossesion_vt_s10.Rows.Count;
        //    meta56 = ((double)count56 / (double)total56) * 100;
        //    meta56 = Math.Round(meta56, 2);
        //    if (meta56 > 100)
        //    {
        //        meta56 = 100;
        //    }
        //}
        if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        {
            count56 = esturedtematicas.Rows.Count;
            meta56 = ((double)count56 / (double)total56) * 100;
            meta56 = Math.Round(meta56, 2);
            //if (meta56 > 100)
            //{
            //    meta56 = 100;
            //}
            pesoAct56 = ((double)count56 / (double)total56) * peso56;
            pesoAct56 = Math.Round(pesoAct56, 4);
            if (pesoAct56 > peso56)
            {
                pesoAct56 = peso56;
            }
            pesototal = pesototal + pesoAct56;
        }
        

        //57) Estudiantes participantes  en las jornadas de formación en la pregunta como punto de partida y en la ruta metodológica del programa Ciclón 
        DataTable estuinscritossesion_vt_s101 = c.listarEncaJornadasFormacionTodosIndicador(coddepartamento, codmuncipio, codinstitucion, codsede, "1", "1");
        double meta561 = 0;
        int count561 = 0;
        /*Falta el total por sede => */
        int total561 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalesturedestematicas"].ToString());
        double peso561 = 5.28;
        double pesoAct561 = 0;
        //if (estuinscritossesion_vt_s10 != null && estuinscritossesion_vt_s10.Rows.Count > 0)
        //{
        //    count56 = estuinscritossesion_vt_s10.Rows.Count;
        //    meta56 = ((double)count56 / (double)total56) * 100;
        //    meta56 = Math.Round(meta56, 2);
        //    if (meta56 > 100)
        //    {
        //        meta56 = 100;
        //    }
        //}
        if (estuinscritossesion_vt_s101 != null && estuinscritossesion_vt_s101.Rows.Count > 0)
        {
            for (int g = 0; g < estuinscritossesion_vt_s101.Rows.Count; g++)
            {
                count561 += Convert.ToInt32(estuinscritossesion_vt_s101.Rows[g]["nroasistentes"].ToString());
            }
            meta561 = ((double)count561 / (double)total561) * 100;
            meta561 = Math.Round(meta561, 2);
            //if (meta56 > 100)
            //{
            //    meta56 = 100;
            //}
            pesoAct561 = ((double)count561 / (double)total561) * peso561;
            pesoAct561 = Math.Round(pesoAct561, 4);
            if (pesoAct561 > peso561)
            {
                pesoAct561 = peso561;
            }
            pesototal = pesototal + pesoAct561;
        }
        

        //Niños, niñas y jóvenes inscritos en grupos de investigación infantiles y juveniles seleccionados en la convocatoria Ciclón 
        DataTable totalEstudiantesMatriculadosGP = c.totalestudiantesparticipantesgi(coddepartamento, codmuncipio, codinstitucion, codsede, "");
        double meta3_ = 0;
        int count3_ = 0;
        int total3_ = 0;
        double pesototal3_ = 2.20;
        double peso3_ = 0;
        if (totalEstudiantesMatriculadosGP != null && totalEstudiantesMatriculadosGP.Rows.Count > 0)
        {
            count3_ = totalEstudiantesMatriculadosGP.Rows.Count;
            //count3 = 32798;
            meta3_ = ((double)count3_ / (double)total3_) * 100;
            meta3_ = Math.Round(meta3_, 2);
            //if (meta3 > 100)
            //{
            //    meta3 = 100;
            //}
            count3_ = totalEstudiantesMatriculadosGP.Rows.Count;

            peso3_ = ((double)count3_ / (double)total3) * pesototal3_;
            peso3_ = Math.Round(peso3_, 4);
            if (peso3_ > pesototal3_)
            {
                peso3_ = pesototal3_;
            }
            pesototal = pesototal + peso3_;
        }
       

        //Total grupos de investigación con registro de avance del presupuesto
        DataTable gruposInvestigacionPresupuesto = est.gruposInvestigacionPresupuesto(coddepartamento, codmuncipio, codinstitucion, codsede);
        double meta2as = 0;
        int count2as = 0;
        int total2as = 0;
        double pesototal2as = 2.20;
        double peso2as = 0;
        if (gruposInvestigacionPresupuesto != null && gruposInvestigacionPresupuesto.Rows.Count > 0)
        {
            count2as = gruposInvestigacionPresupuesto.Rows.Count;
            meta2as = ((double)count2as / (double)total2as) * 100;
            meta2as = Math.Round(meta2as, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}
            count2as = gruposInvestigacionPresupuesto.Rows.Count;

            peso2as = ((double)count2as / (double)total2as) * pesototal2as;
            peso2as = Math.Round(peso2as, 4);
            if (peso2as > pesototal2as)
            {
                peso2as = pesototal2as;
            }
            pesototal = pesototal + peso2as;
        }
        


        //Informes de investigación elaborados por los grupos de investigación infantiles y juveniles
        double meta1ie = 0;
        int count1ie = 0;
        int total1ie = 420;
        double pesototal1ie = 0.31;
        double peso1ie = 0;
        //if (informesinvestigacion != null && informesinvestigacion.Rows.Count > 0)
        //{
        //count1 = informesinvestigacion.Rows.Count;
        meta1ie = ((double)count1ie / (double)total1ie) * 100;
        meta1ie = Math.Round(meta1ie, 2);
        //if (meta1 > 100)
        //{
        //    meta1 = 100;
        //}
        //}
        peso1ie = ((double)count1ie / (double)total1ie) * pesototal1ie;
        peso1ie = Math.Round(peso1ie, 4);
        if (peso1ie > pesototal1ie)
        {
            peso1ie = pesototal1ie;
        }
        pesototal = pesototal + peso1ie;

        

        //Publicaciones impresas y/o digitales (2  de los procesos y resultados de los grupos de investigación  y  de los resultados de la implementación del proyecto). 
        DataTable guias2 = est.cargarEvidenciasPublicaciones("1");
        double meta1412 = 0;
        int count1412 = 0;
        int total1412 = 0;
        double pesototal1412 = 0.31;
        double peso1412 = 0;
        if (guias2 != null && guias2.Rows.Count > 0)
        {
            count1412 = guias2.Rows.Count;
            meta1412 = ((double)count1412 / (double)total1412) * 100;
            meta1412 = Math.Round(meta1412, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            peso1412 = ((double)count1412 / (double)total1412) * pesototal1412;
            peso1412 = Math.Round(peso1412, 4);
            if (peso1412 > pesototal1412)
            {
                peso1412 = pesototal1412;
            }
            pesototal = pesototal + peso1412;
        }
        

        //Guías de investigación rediseñadas e impresas
        DataTable guias = est.cargarEvidenciasPublicaciones("2");
        double meta141 = 0;
        int count141 = 0;
        int total141 = 0;
        double pesototal141 = 0.73;
        double peso141 = 0;
        if (guias != null && guias.Rows.Count > 0)
        {
            count141 = guias.Rows.Count;
            meta141 = ((double)count141 / (double)total141) * 100;
            meta141 = Math.Round(meta141, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            peso141 = ((double)count141 / (double)total141) * pesototal141;
            peso141 = Math.Round(peso141, 4);
            if (peso141 > pesototal141)
            {
                peso141 = pesototal141;
            }
            pesototal = pesototal + peso141;
        }
        

        //16361 dotaciones y desarrollo del la infraestructura tecnológica y comunicacional 
        DataTable tables = c.EntregaTabletsxSede(coddepartamento, codmuncipio, codinstitucion, codsede);
        double metatables = 0;
        int counttables = 0;
        int totaltables = 260;
        double pesototaltables = 42.16;
        double pesotables = 0;
        if (tables != null && tables.Rows.Count > 0)
        {
            for (int g = 0; g < tables.Rows.Count; g++)
            {
                counttables += Convert.ToInt32(tables.Rows[g]["total"].ToString());
            }
            metatables = ((double)counttables / (double)totaltables) * 100;
            metatables = Math.Round(metatables, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesotables = ((double)counttables / (double)totaltables) * pesototaltables;
            pesotables = Math.Round(pesotables, 4);
            if (pesotables > pesototaltables)
            {
                pesotables = pesototaltables;
            }
            pesototal = pesototal + pesotables;
        }
        

        //////////////////INDICADORES DE MAESTROS PARA LA GRÁFICA//////////////////

        double pesototalM = 0;


        // 1. Maestros y maestras acompañantes / coinvestigadores matriculados en la estrategia  No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica
        double meta1M = 0;
        int count1M = 0;
        DataTable maestrosmatriculadosestra2 = est.maestrosmatriculadosestra2(coddepartamento, codmuncipio, codinstitucion, codsede, "2");
        DataRow loadTotalesIndicadoresxSedeM = ins.loadTotalesIndicadoresxSedeMaestrosSUM(coddepartamento, codmuncipio, codinstitucion, codsede);
        int total1M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso1M = 1.3071;
        double pesoAct1M = 0;

        if (maestrosmatriculadosestra2 != null && maestrosmatriculadosestra2.Rows.Count > 0)
        {
            count1M = maestrosmatriculadosestra2.Rows.Count;
            meta1M = ((double)count1M / (double)total1M) * 100;
            meta1M = Math.Round(meta1M, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesoAct1M = ((double)count1M / (double)total1M) * peso1M;
            pesoAct1M = Math.Round(pesoAct1M, 4);
            if (pesoAct1M > peso1M)
            {
                pesoAct1M = peso1M;
            }
            pesototalM = pesototalM + pesoAct1M;
        }

        //Maestros y maestras  matriculados en la estrategia  No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica
        //DataTable dtm = est.maestrosmatriculadosestra2("","","","","2");
        DataTable dtm = c.cargarDocentesInscritosComitesEspApro(coddepartamento, codmuncipio, codinstitucion, codsede);

        double metadocinsc = 0;
        int countdocinsc = 0;
        int totaldocinsc = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double pesototaldocinsc = 1.3071;
        double pesodocinsc = 0;
        if ((dtm != null && dtm.Rows.Count > 0))
        {
            countdocinsc = dtm.Rows.Count;
            metadocinsc = ((double)countdocinsc / (double)totaldocinsc) * 100;
            metadocinsc = Math.Round(metadocinsc, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesodocinsc = ((double)countdocinsc / (double)totaldocinsc) * pesototaldocinsc;
            pesodocinsc = Math.Round(pesodocinsc, 4);
            if (pesodocinsc > pesototaldocinsc)
            {
                pesodocinsc = pesototaldocinsc;
            }
            pesototalM = pesototalM + pesodocinsc;
        }


        //Maestros y maestras coinvestigadores que se forman en la estrategia No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica

        DataTable dtm2 = null;
        //DataTable dtm2 = c.cargarDocentesBeneficiadosEnSesionesJornadas();

        double metadocinsc2 = 0;
        int countdocinsc2 = 0;
        int totaldocinsc2 = 3386;
        double pesototaldocinsc2 = 1.3071;
        double pesodocinsc2 = 0;
        if ((dtm2 != null && dtm2.Rows.Count > 0))
        {
            countdocinsc2 = dtm2.Rows.Count;
            metadocinsc2 = ((double)countdocinsc2 / (double)totaldocinsc2) * 100;
            metadocinsc2 = Math.Round(metadocinsc2, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesodocinsc2 = ((double)countdocinsc2 / (double)totaldocinsc2) * pesototaldocinsc2;
            pesodocinsc2 = Math.Round(pesodocinsc2, 4);
            if (pesodocinsc2 > pesototaldocinsc2)
            {
                pesodocinsc2 = pesototaldocinsc2;
            }
            pesototalM = pesototalM + pesodocinsc2;
        }


        //Maestros y maestras inscritos en los comités  de  los espacios de apropiacion social institucionales que se forman en estrategia  No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica

        DataTable dtm3 = null;
        //DataTable dtm3 = c.cargarDocentesInscritosComitesEspApro("", "", "", "");

        double metadocinsc3 = 0;
        int countdocinsc3 = 0;
        int totaldocinsc3 = 3386;
        double pesototaldocinsc3 = 1.3071;
        double pesodocinsc3 = 0;
        if ((dtm3 != null && dtm3.Rows.Count > 0))
        {
            countdocinsc3 = dtm3.Rows.Count;
            metadocinsc3 = ((double)countdocinsc3 / (double)totaldocinsc3) * 100;
            metadocinsc3 = Math.Round(metadocinsc3, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesodocinsc3 = ((double)countdocinsc3 / (double)totaldocinsc3) * pesototaldocinsc3;
            pesodocinsc3 = Math.Round(pesodocinsc3, 4);
            if (pesodocinsc3 > pesototaldocinsc3)
            {
                pesodocinsc3 = pesototaldocinsc3;
            }
            pesototalM = pesototalM + pesodocinsc3;
        }


        //Maestros y maestras lideres de las redes temáticas formados en la estrategia  No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica.

        //DataTable maestrosredestematicas2 = null;
        ////DataTable maestrosredestematicas2 = est.maestrosredestematicas("", "", "", "");

        //double metadocred = 0;
        //int countdocred = 0;
        //int totaldocred = 3386;
        //double pesototaldocred = 3.63;
        //double pesodocred = 0;
        //if ((maestrosredestematicas2 != null && maestrosredestematicas2.Rows.Count > 0))
        //{
        //    countdocred = maestrosredestematicas2.Rows.Count;
        //    metadocred = ((double)countdocred / (double)totaldocred) * 100;
        //    metadocred = Math.Round(metadocred, 2);
        //    //if (meta1 > 100)
        //    //{
        //    //    meta1 = 100;
        //    //}

        //    pesodocred = ((double)countdocred / (double)totaldocred) * pesototaldocred;
        //    pesodocred = Math.Round(pesodocred, 4);
        //    if (pesodocred > pesototaldocred)
        //    {
        //        pesodocred = pesototaldocred;
        //    }
        //    pesototalM = pesototalM + pesodocred;
        //}



        // Asistentes a la sesión de asesoría a grupos infantiles y juveniles
        double meta26M = 0;
        int count26M = 0;
        DataTable asistentesgruposinv = est.asistentesgruposinv(coddepartamento, codmuncipio, codinstitucion, codsede);
        int total26M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso26M = 1.3071;
        double pesoAct26M = 0;

        if (asistentesgruposinv != null && asistentesgruposinv.Rows.Count > 0)
        {
            count26M = asistentesgruposinv.Rows.Count;
            meta26M = ((double)count26M / (double)total26M) * 100;
            meta26M = Math.Round(meta26M, 2);
            //if (meta26 > 100)
            //{
            //    meta26 = 100;
            //}

            pesoAct26M = ((double)count26M / (double)total26M) * peso26M;
            pesoAct26M = Math.Round(pesoAct26M, 4);
            if (pesoAct26M > peso26M)
            {
                pesoAct26M = peso26M;
            }
            pesototalM = pesototalM + pesoAct26M;
        }


        // Maestros y maestras lideres de las redes temáticas formados en los lineamientos del Programa Ciclón y su propuesta metodológica
        double meta27M = 0;
        int count27M = 0;
        DataTable maestrosredestematicas = est.maestrosredestematicas(coddepartamento, codmuncipio, codinstitucion, codsede);
        int total27M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso27M = 1.3071;
        double pesoAct27M = 0;

        if (maestrosredestematicas != null && maestrosredestematicas.Rows.Count > 0)
        {
            count27M = maestrosredestematicas.Rows.Count;
            meta27M = ((double)count27M / (double)total27M) * 100;
            meta27M = Math.Round(meta27M, 2);
            //if (meta27 > 100)
            //{
            //    meta27 = 100;
            //}

            pesoAct27M = ((double)count27M / (double)total27M) * peso27M;
            pesoAct27M = Math.Round(pesoAct27M, 4);
            if (pesoAct27M > peso27M)
            {
                pesoAct27M = peso27M;
            }
            pesototalM = pesototalM + pesoAct27M;
        }


        // Sesión de formación No. 1
        double meta2M = 0;
        int count2M = 0;
        DataTable sesionformacionMaestrosS1 = est.sesionformacionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "1", "1");
        int total2M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalsesion"].ToString());
        double peso2M = 1.3071;
        double pesoAct2M = 0;

        if (sesionformacionMaestrosS1 != null && sesionformacionMaestrosS1.Rows.Count > 0)
        {
            count2M = sesionformacionMaestrosS1.Rows.Count;
            meta2M = ((double)count2M / (double)total2M) * 100;
            meta2M = Math.Round(meta2M, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesoAct2M = ((double)count2M / (double)total2M) * peso2M;
            pesoAct2M = Math.Round(pesoAct2M, 4);
            if (pesoAct2M > peso2M)
            {
                pesoAct2M = peso2M;
            }
            pesototalM = pesototalM + pesoAct2M;
        }

        // Asistentes a la sesión de formación No. 1/jornada de actualización No. 1 (5 horas)
        double meta3M = 0;
        int count3M = 0;
        DataTable asistentesSesionMaestrosS1 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "1", "1", "1");
        int total3M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso3M = 1.3071;
        double pesoAct3M = 0;

        if (asistentesSesionMaestrosS1 != null && asistentesSesionMaestrosS1.Rows.Count > 0)
        {
            count3M = asistentesSesionMaestrosS1.Rows.Count;
            meta3M = ((double)count3M / (double)total3M) * 100;
            meta3M = Math.Round(meta3M, 2);
            //if (meta3 > 100)
            //{
            //    meta3 = 100;
            //}

            pesoAct3M = ((double)count3M / (double)total3M) * peso3M;
            pesoAct3M = Math.Round(pesoAct3M, 4);
            if (pesoAct3M > peso3M)
            {
                pesoAct3M = peso3M;
            }
            pesototalM = pesototalM + pesoAct3M;
        }


        // Maestros asistentes a la sesión de formación No. 1/jornada de producción No. 1 (4 horas)
        double meta4M = 0;
        int count4M = 0;
        DataTable asistentesSesionMaestrosS1j2 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "1", "1", "2");
        int total4M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso4M = 1.3071;
        double pesoAct4M = 0;
        if (asistentesSesionMaestrosS1j2 != null && asistentesSesionMaestrosS1j2.Rows.Count > 0)
        {
            count4M = asistentesSesionMaestrosS1j2.Rows.Count;
            meta4M = ((double)count4M / (double)total4M) * 100;
            meta4M = Math.Round(meta4M, 2);
            //if (meta4 > 100)
            //{
            //    meta4 = 100;
            //}

            pesoAct4M = ((double)count4M / (double)total4M) * peso4M;
            pesoAct4M = Math.Round(pesoAct4M, 4);
            if (pesoAct4M > peso4M)
            {
                pesoAct4M = peso4M;
            }
            pesototalM = pesototalM + pesoAct4M;
        }


        // Asistentes a la sesión de formación No. 1/ autoformación (2 horas)
        double meta29M = 0;
        int count29M = 0;
        DataTable asistentessesionformacionAutos1 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "1", "1", "2");
        int total29M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso29M = 1.3071;
        double pesoAct29M = 0;
        if (asistentessesionformacionAutos1 != null && asistentessesionformacionAutos1.Rows.Count > 0)
        {
            count29M = asistentessesionformacionAutos1.Rows.Count;
            meta29M = ((double)count29M / (double)total29M) * 100;
            meta29M = Math.Round(meta29M, 2);
            //if (meta29 > 100)
            //{
            //    meta29 = 100;
            //}

            pesoAct29M = ((double)count29M / (double)total29M) * peso29M;
            pesoAct29M = Math.Round(pesoAct29M, 4);
            if (pesoAct29M > peso29M)
            {
                pesoAct29M = peso29M;
            }
            pesototalM = pesototalM + pesoAct29M;
        }

        // Asistentes a la sesión de formación No. 1/formación virtual (4 horas)
        double meta30M = 0;
        int count30M = 0;
        DataTable asistentessesionvirtual = est.asistentessesionvirtual(coddepartamento, codmuncipio, codinstitucion, codsede, "1");
        int total30M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso30M = 1.3071;
        double pesoAct30M = 0;
        if (asistentessesionvirtual != null && asistentessesionvirtual.Rows.Count > 0)
        {
            count30M = asistentessesionvirtual.Rows.Count;
            meta30M = ((double)count30M / (double)total30M) * 100;
            meta30M = Math.Round(meta30M, 2);
            //if (meta30 > 100)
            //{
            //    meta30 = 100;
            //}

            pesoAct30M = ((double)count30M / (double)total30M) * peso30M;
            pesoAct30M = Math.Round(pesoAct30M, 4);
            if (pesoAct30M > peso30M)
            {
                pesoAct30M = peso30M;
            }
            pesototalM = pesototalM + pesoAct30M;
        }


        // Sesiones de formación evaluadas y subidas a la plataforma de Ciclón
        double meta31M = 0;
        int count31M = 0;
        DataTable sesionesformacionsubidas = est.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "1", "1");
        int total31M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalsesion"].ToString());
        double peso31M = 1.3071;
        double pesoAct31M = 0;
        if (sesionesformacionsubidas != null && sesionesformacionsubidas.Rows.Count > 0)
        {
            count31M = sesionesformacionsubidas.Rows.Count;
            meta31M = ((double)count31M / (double)total31M) * 100;
            meta31M = Math.Round(meta31M, 2);
            //if (meta31 > 100)
            //{
            //    meta31 = 100;
            //}

            pesoAct31M = ((double)count31M / (double)total31M) * peso31M;
            pesoAct31M = Math.Round(pesoAct31M, 4);
            if (pesoAct31M > peso31M)
            {
                pesoAct31M = peso31M;
            }
            pesototalM = pesototalM + pesoAct31M;
        }

        //Sesión 1, Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).

        DataTable sesionesevidenciass1 = c.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "1", "1", "Relatoria institucional");

        double metases1 = 0;
        int countses1 = 0;
        int totalses1 = 1;
        double pesototalses1 = 1.3071;
        double pesoses1 = 0;
        if ((sesionesevidenciass1 != null && sesionesevidenciass1.Rows.Count > 0))
        {
            countses1 = sesionesevidenciass1.Rows.Count;
            metases1 = ((double)countses1 / (double)totalses1) * 100;
            metases1 = Math.Round(metases1, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesoses1 = ((double)countses1 / (double)totalses1) * pesototalses1;
            pesoses1 = Math.Round(pesoses1, 4);
            if (pesoses1 > pesototalses1)
            {
                pesoses1 = pesototalses1;
            }
            pesototalM = pesototalM + pesoses1;
        }

        //Sesión 1, Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.

        DataTable sesionesevidenciasfe1 = c.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "1", "1", "Formato de evaluación");

        double metasfe1 = 0;
        int countsfe1 = 0;
        int totalsfe1 = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalsesion"].ToString());
        double pesototalsfe1 = 1.3071;
        double pesosfe1 = 0;
        if ((sesionesevidenciasfe1 != null && sesionesevidenciasfe1.Rows.Count > 0))
        {
            countsfe1 = sesionesevidenciasfe1.Rows.Count;
            metasfe1 = ((double)countsfe1 / (double)totalsfe1) * 100;
            metasfe1 = Math.Round(metasfe1, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesosfe1 = ((double)countsfe1 / (double)totalsfe1) * pesototalsfe1;
            pesosfe1 = Math.Round(pesosfe1, 4);
            if (pesosfe1 > pesototalsfe1)
            {
                pesosfe1 = pesototalsfe1;
            }
            pesototalM = pesototalM + pesosfe1;
        }

        // Sesiones de formación No. 2 realizadas 
        double meta5M = 0;
        int count5M = 0;
        DataTable sesionformacionMaestrosS2 = est.sesionformacionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "3", "2");
        int total5M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalsesion"].ToString());
        double peso5M = 1.3071;
        double pesoAct5M = 0;
        if (sesionformacionMaestrosS2 != null && sesionformacionMaestrosS2.Rows.Count > 0)
        {
            count5M = sesionformacionMaestrosS2.Rows.Count;
            meta5M = ((double)count5M / (double)total5M) * 100;
            meta5M = Math.Round(meta5M, 2);
            //if (meta5 > 100)
            //{
            //    meta5 = 100;
            //}

            pesoAct5M = ((double)count5M / (double)total5M) * peso5M;
            pesoAct5M = Math.Round(pesoAct5M, 4);
            if (pesoAct5M > peso5M)
            {
                pesoAct5M = peso5M;
            }
            pesototalM = pesototalM + pesoAct5M;
        }

        // Asistentes a la sesión de formación No. 2/jornada de actualización No. 3 (5 horas)
        double meta6M = 0;
        int count6M = 0;
        DataTable asistentesSesionMaestrosS2 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "3", "2", "3");
        int total6M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso6M = 1.3071;
        double pesoAct6M = 0;
        if (asistentesSesionMaestrosS2 != null && asistentesSesionMaestrosS2.Rows.Count > 0)
        {
            count6M = asistentesSesionMaestrosS2.Rows.Count;
            meta6M = ((double)count6M / (double)total6M) * 100;
            meta6M = Math.Round(meta6M, 2);
            //if (meta6 > 100)
            //{
            //    meta6 = 100;
            //}

            pesoAct6M = ((double)count6M / (double)total6M) * peso6M;
            pesoAct6M = Math.Round(pesoAct6M, 4);
            if (pesoAct6M > peso6M)
            {
                pesoAct6M = peso6M;
            }
            pesototalM = pesototalM + pesoAct6M;
        }

        // Asistentes a la sesión de formación No. 2/jornada de producción No. 4 (4 horas)
        double meta7M = 0;
        int count7M = 0;
        DataTable asistentesSesionMaestrosS1j4 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "3", "2", "4");
        int total7M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso7M = 1.3071;
        double pesoAct7M = 0;
        if (asistentesSesionMaestrosS1j4 != null && asistentesSesionMaestrosS1j4.Rows.Count > 0)
        {
            count7M = asistentesSesionMaestrosS1j4.Rows.Count;
            meta7M = ((double)count7M / (double)total7M) * 100;
            meta7M = Math.Round(meta7M, 2);
            //if (meta7 > 100)
            //{
            //    meta7 = 100;
            //}

            pesoAct7M = ((double)count7M / (double)total7M) * peso7M;
            pesoAct7M = Math.Round(pesoAct7M, 4);
            if (pesoAct7M > peso7M)
            {
                pesoAct7M = peso7M;
            }
            pesototalM = pesototalM + pesoAct7M;
        }

        //---------------------------------------------

        // Asistentes a la sesión de formación No. 2/ autoformación (2 horas)
        double meta33M = 0;
        int count33M = 0;
        DataTable asistentessesionformacionAutos2 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "3", "2", "4");
        int total33M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso33M = 1.3071;
        double pesoAct33M = 0;
        if (asistentessesionformacionAutos2 != null && asistentessesionformacionAutos2.Rows.Count > 0)
        {
            count33M = asistentessesionformacionAutos2.Rows.Count;
            meta33M = ((double)count33M / (double)total33M) * 100;
            meta33M = Math.Round(meta33M, 2);
            //if (meta33 > 100)
            //{
            //    meta33 = 100;
            //}

            pesoAct33M = ((double)count33M / (double)total33M) * peso33M;
            pesoAct33M = Math.Round(pesoAct33M, 4);
            if (pesoAct33M > peso33M)
            {
                pesoAct33M = peso33M;
            }
            pesototalM = pesototalM + pesoAct33M;
        }


        // Asistentes a la sesión de formación No. 2/formación virtual (4 horas)
        double meta34M = 0;
        int count34M = 0;
        DataTable asistentessesionvirtuals2 = est.asistentessesionvirtual(coddepartamento, codmuncipio, codinstitucion, codsede, "2");
        int total34M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso34M = 1.3071;
        double pesoAct34M = 0;
        if (asistentessesionvirtuals2 != null && asistentessesionvirtuals2.Rows.Count > 0)
        {
            count34M = asistentessesionvirtuals2.Rows.Count;
            meta34M = ((double)count34M / (double)total34M) * 100;
            meta34M = Math.Round(meta34M, 2);
            //if (meta34 > 100)
            //{
            //    meta34 = 100;
            //}

            pesoAct34M = ((double)count34M / (double)total34M) * peso34M;
            pesoAct34M = Math.Round(pesoAct34M, 4);
            if (pesoAct34M > peso34M)
            {
                pesoAct34M = peso34M;
            }
            pesototalM = pesototalM + pesoAct34;
        }


        // Sesiones de formación evaluadas y subidas a la plataforma de Ciclón N. 2
        double meta35M = 0;
        int count35M = 0;
        DataTable sesionesformacionsubidasS2 = est.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "3", "2");
        int total35M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalsesion"].ToString());
        double peso35M = 1.3071;
        double pesoAct35M = 0;
        if (sesionesformacionsubidasS2 != null && sesionesformacionsubidasS2.Rows.Count > 0)
        {
            count35M = sesionesformacionsubidasS2.Rows.Count;
            meta35M = ((double)count35M / (double)total35M) * 100;
            meta35M = Math.Round(meta35M, 2);
            //if (meta35 > 100)
            //{
            //    meta35 = 100;
            //}

            pesoAct35M = ((double)count35M / (double)total35M) * peso35M;
            pesoAct35M = Math.Round(pesoAct35M, 4);
            if (pesoAct35M > peso35M)
            {
                pesoAct35M = peso35M;
            }
            pesototalM = pesototalM + pesoAct35M;
        }


        //Sesión 2, Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).

        DataTable sesionesevidenciass2 = c.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "3", "2", "Relatoria institucional");

        double metases2 = 0;
        int countses2 = 0;
        int totalses2 = 1;
        double pesototalses2 = 1.3071;
        double pesoses2 = 0;
        if ((sesionesevidenciass2 != null && sesionesevidenciass2.Rows.Count > 0))
        {
            countses2 = sesionesevidenciass2.Rows.Count;
            metases2 = ((double)countses2 / (double)totalses2) * 100;
            metases2 = Math.Round(metases2, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesoses2 = ((double)countses2 / (double)totalses2) * pesototalses2;
            pesoses2 = Math.Round(pesoses2, 4);
            if (pesoses2 > pesototalses2)
            {
                pesoses2 = pesototalses2;
            }
            pesototalM = pesototalM + pesoses2;
        }


        //Sesión 2, Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.

        DataTable sesionesevidenciasfe2 = c.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "3", "2", "Formato de evaluación");

        double metasfe2 = 0;
        int countsfe2 = 0;
        int totalsfe2 = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalsesion"].ToString());
        double pesototalsfe2 = 1.3071;
        double pesosfe2 = 0;
        if ((sesionesevidenciasfe2 != null && sesionesevidenciasfe2.Rows.Count > 0))
        {
            countsfe2 = sesionesevidenciasfe2.Rows.Count;
            metasfe2 = ((double)countsfe2 / (double)totalsfe2) * 100;
            metasfe2 = Math.Round(metasfe2, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesosfe2 = ((double)countsfe2 / (double)totalsfe2) * pesototalsfe2;
            pesosfe2 = Math.Round(pesosfe2, 4);
            if (pesosfe2 > pesototalsfe2)
            {
                pesosfe2 = pesototalsfe2;
            }
            pesototalM = pesototalM + pesosfe2;
        }

        //----------------------------------------------




        // Sesiones de formación No. 3 realizadas 
        double meta8M = 0;
        int count8M = 0;
        DataTable sesionformacionMaestrosS3 = est.sesionformacionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "3");
        int total8M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalsesion"].ToString());
        double peso8M = 1.3071;
        double pesoAct8M = 0;
        if (sesionformacionMaestrosS3 != null && sesionformacionMaestrosS3.Rows.Count > 0)
        {
            count8M = sesionformacionMaestrosS3.Rows.Count;
            meta8M = ((double)count8M / (double)total8M) * 100;
            meta8M = Math.Round(meta8M, 2);
            //if (meta8 > 100)
            //{
            //    meta8 = 100;
            //}

            pesoAct8M = ((double)count8M / (double)total8M) * peso8M;
            pesoAct8M = Math.Round(pesoAct8M, 4);
            if (pesoAct8M > peso8M)
            {
                pesoAct8M = peso8M;
            }
            pesototalM = pesototalM + pesoAct8M;
        }



        // Asistentes a la sesión de formación No. 3/jornada de actualización No. 5 (5 horas)
        double meta9M = 0;
        int count9M = 0;
        DataTable asistentesSesionMaestrosS3 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "3", "5");
        int total9M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso9M = 1.3071;
        double pesoAct9M = 0;
        if (asistentesSesionMaestrosS3 != null && asistentesSesionMaestrosS3.Rows.Count > 0)
        {
            count9M = asistentesSesionMaestrosS3.Rows.Count;
            meta9M = ((double)count9M / (double)total9M) * 100;
            meta9M = Math.Round(meta9M, 2);
            //if (meta9 > 100)
            //{
            //    meta9 = 100;
            //}

            pesoAct9M = ((double)count9M / (double)total9M) * peso9M;
            pesoAct9M = Math.Round(pesoAct9M, 4);
            if (pesoAct9M > peso9M)
            {
                pesoAct9M = peso9M;
            }
            pesototalM = pesototalM + pesoAct9M;
        }


        // Asistentes a la sesión de formación No. 3/jornada de producción No. 6 (4 horas)
        double meta10M = 0;
        int count10M = 0;
        DataTable asistentesSesionMaestrosS1j6 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "3", "6");
        int total10M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso10M = 1.3071;
        double pesoAct10M = 0;
        if (asistentesSesionMaestrosS1j6 != null && asistentesSesionMaestrosS1j6.Rows.Count > 0)
        {
            count10M = asistentesSesionMaestrosS1j6.Rows.Count;
            meta10M = ((double)count10M / (double)total10M) * 100;
            meta10M = Math.Round(meta10M, 2);
            //if (meta10 > 100)
            //{
            //    meta10 = 100;
            //}

            pesoAct10M = ((double)count10M / (double)total10M) * peso10M;
            pesoAct10M = Math.Round(pesoAct10M, 4);
            if (pesoAct10M > peso10M)
            {
                pesoAct10M = peso10M;
            }
            pesototalM = pesototalM + pesoAct10M;
        }

        //---------------------------------------------
        // Asistentes a la sesión de formación No. 3/ autoformación (2 horas)
        double meta37M = 0;
        int count37M = 0;
        DataTable asistentessesionformacionAutos3 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "3", "6");
        int total37M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso37M = 1.3071;
        double pesoAct37M = 0;
        if (asistentessesionformacionAutos3 != null && asistentessesionformacionAutos3.Rows.Count > 0)
        {
            count37M = asistentessesionformacionAutos3.Rows.Count;
            meta37M = ((double)count37M / (double)total37M) * 100;
            meta37M = Math.Round(meta37M, 2);
            //if (meta37 > 100)
            //{
            //    meta37 = 100;
            //}

            pesoAct37M = ((double)count37M / (double)total37M) * peso37M;
            pesoAct37M = Math.Round(pesoAct37M, 4);
            if (pesoAct37M > peso37M)
            {
                pesoAct37M = peso37M;
            }
            pesototalM = pesototalM + pesoAct37M;
        }


        // Asistentes a la sesión de formación No. 3/formación virtual (4 horas)
        double meta38M = 0;
        int count38M = 0;
        DataTable asistentessesionvirtuals3 = est.asistentessesionvirtual(coddepartamento, codmuncipio, codinstitucion, codsede, "3");
        int total38M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso38M = 1.3071;
        double pesoAct38M = 0;
        if (asistentessesionvirtuals3 != null && asistentessesionvirtuals3.Rows.Count > 0)
        {
            count38M = asistentessesionvirtuals3.Rows.Count;
            meta38M = ((double)count38M / (double)total38M) * 100;
            meta38M = Math.Round(meta38M, 2);
            //if (meta38 > 100)
            //{
            //    meta38 = 100;
            //}

            pesoAct38M = ((double)count38M / (double)total38M) * peso38M;
            pesoAct38M = Math.Round(pesoAct38M, 4);
            if (pesoAct38M > peso38M)
            {
                pesoAct38M = peso38M;
            }
            pesototalM = pesototalM + pesoAct38M;
        }


        // Sesiones de formación evaluadas y subidas a la plataforma de Ciclón No. 3
        double meta39M = 0;
        int count39M = 0;
        DataTable sesionesformacionsubidasS3 = est.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "3");
        int total39M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalsesion"].ToString());
        double peso39M = 1.3071;
        double pesoAct39M = 0;
        if (sesionesformacionsubidasS3 != null && sesionesformacionsubidasS3.Rows.Count > 0)
        {
            count39M = sesionesformacionsubidasS3.Rows.Count;
            meta39M = ((double)count39M / (double)total39M) * 100;
            meta39M = Math.Round(meta39M, 2);
            //if (meta39 > 100)
            //{
            //    meta39 = 100;
            //}

            pesoAct39M = ((double)count39M / (double)total39M) * peso39M;
            pesoAct39M = Math.Round(pesoAct39M, 4);
            if (pesoAct39M > peso39M)
            {
                pesoAct39M = peso39M;
            }
            pesototalM = pesototalM + pesoAct39M;
        }

        //Sesión 3, Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).

        DataTable sesionesevidenciass3 = c.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "3", "Relatoria institucional");

        double metases3 = 0;
        int countses3 = 0;
        int totalses3 = 1;
        double pesototalses3 = 1.3071;
        double pesoses3 = 0;
        if ((sesionesevidenciass3 != null && sesionesevidenciass3.Rows.Count > 0))
        {
            countses3 = sesionesevidenciass3.Rows.Count;
            metases3 = ((double)countses3 / (double)totalses3) * 100;
            metases3 = Math.Round(metases3, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesoses3 = ((double)countses3 / (double)totalses3) * pesototalses3;
            pesoses3 = Math.Round(pesoses3, 4);
            if (pesoses3 > pesototalses3)
            {
                pesoses3 = pesototalses3;
            }
            pesototalM = pesototalM + pesoses3;
        }

        //Sesión 3, Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.

        DataTable sesionesevidenciasfe3 = c.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "3", "Formato de evaluación");

        double metasfe3 = 0;
        int countsfe3 = 0;
        int totalsfe3 = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalsesion"].ToString());
        double pesototalsfe3 = 1.3071;
        double pesosfe3 = 0;
        if ((sesionesevidenciasfe3 != null && sesionesevidenciasfe3.Rows.Count > 0))
        {
            countsfe3 = sesionesevidenciasfe3.Rows.Count;
            metasfe3 = ((double)countsfe3 / (double)totalsfe3) * 100;
            metasfe3 = Math.Round(metasfe3, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesosfe3 = ((double)countsfe3 / (double)totalsfe3) * pesototalsfe3;
            pesosfe3 = Math.Round(pesosfe3, 4);
            if (pesosfe3 > pesototalsfe3)
            {
                pesosfe3 = pesototalsfe3;
            }
            pesototalM = pesototalM + pesosfe3;
        }

        //----------------------------------------------






        // Sesiones de formación No. 4 realizadas 
        double meta11M = 0;
        int count11M = 0;
        DataTable sesionformacionMaestrosS4 = est.sesionformacionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "4");
        int total11M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalsesion"].ToString());
        double peso11M = 1.3071;
        double pesoAct11M = 0;
        if (sesionformacionMaestrosS4 != null && sesionformacionMaestrosS4.Rows.Count > 0)
        {
            count11M = sesionformacionMaestrosS4.Rows.Count;
            meta11M = ((double)count11M / (double)total11M) * 100;
            meta11M = Math.Round(meta11M, 2);
            //if (meta11 > 100)
            //{
            //    meta11 = 100;
            //}

            pesoAct11M = ((double)count11M / (double)total11M) * peso11M;
            pesoAct11M = Math.Round(pesoAct11M, 4);
            if (pesoAct11M > peso11M)
            {
                pesoAct11 = peso11;
            }
            pesototalM = pesototalM + pesoAct11M;
        }


        //Asistentes a la sesión de formación No. 4/jornada de actualización No. 7 (5 horas)
        double meta12M = 0;
        int count12M = 0;
        DataTable asistentesSesionMaestrosS4 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "4", "7");
        int total12M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso12M = 1.3071;
        double pesoAct12M = 0;
        if (asistentesSesionMaestrosS4 != null && asistentesSesionMaestrosS4.Rows.Count > 0)
        {
            count12M = asistentesSesionMaestrosS4.Rows.Count;
            meta12M = ((double)count12M / (double)total12M) * 100;
            meta12M = Math.Round(meta12M, 2);
            //if (meta12 > 100)
            //{
            //    meta12 = 100;
            //}

            pesoAct12M = ((double)count12M / (double)total12M) * peso12M;
            pesoAct12M = Math.Round(pesoAct12M, 4);
            if (pesoAct12M > peso12M)
            {
                pesoAct12M = peso12M;
            }
            pesototalM = pesototalM + pesoAct12M;
        }


        // Asistentes a la sesión de formación No. 4/jornada de producción No. 8 (4 horas)
        double meta13M = 0;
        int count13M = 0;
        DataTable asistentesSesionMaestrosS4j8 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "4", "8");
        int total13M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso13M = 1.3071;
        double pesoAct13M = 0;
        if (asistentesSesionMaestrosS4j8 != null && asistentesSesionMaestrosS4j8.Rows.Count > 0)
        {
            count13M = asistentesSesionMaestrosS4j8.Rows.Count;
            meta13M = ((double)count13M / (double)total13M) * 100;
            meta13M = Math.Round(meta13M, 2);
            //if (meta13 > 100)
            //{
            //    meta13 = 100;
            //}

            pesoAct13M = ((double)count13M / (double)total13M) * peso13M;
            pesoAct13M = Math.Round(pesoAct13M, 4);
            if (pesoAct13M > peso13M)
            {
                pesoAct13M = peso13M;
            }
            pesototalM = pesototalM + pesoAct13M;
        }

        //---------------------------------------------
        // Asistentes a la sesión de formación No. 4/ autoformación (2 horas)
        double meta41M = 0;
        int count41M = 0;
        DataTable asistentessesionformacionAutos4 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "4", "8");
        int total41M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso41M = 1.3071;
        double pesoAct41M = 0;
        if (asistentessesionformacionAutos4 != null && asistentessesionformacionAutos4.Rows.Count > 0)
        {
            count41M = asistentessesionformacionAutos4.Rows.Count;
            meta41M = ((double)count41M / (double)total41M) * 100;
            meta41M = Math.Round(meta41M, 2);
            //if (meta41 > 100)
            //{
            //    meta41 = 100;
            //}

            pesoAct41M = ((double)count41M / (double)total41M) * peso41M;
            pesoAct41M = Math.Round(pesoAct41M, 4);
            if (pesoAct41M > peso41M)
            {
                pesoAct41M = peso41M;
            }
            pesototalM = pesototalM + pesoAct41M;
        }


        // Asistentes a la sesión de formación No. 4/formación virtual (4 horas)
        double meta42M = 0;
        int count42M = 0;
        DataTable asistentessesionvirtuals4 = est.asistentessesionvirtual(coddepartamento, codmuncipio, codinstitucion, codsede, "4");
        int total42M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso42M = 1.3071;
        double pesoAct42M = 0;
        if (asistentessesionvirtuals4 != null && asistentessesionvirtuals4.Rows.Count > 0)
        {
            count42M = asistentessesionvirtuals4.Rows.Count;
            meta42M = ((double)count42M / (double)total42M) * 100;
            meta42M = Math.Round(meta42M, 2);
            //if (meta42 > 100)
            //{
            //    meta42 = 100;
            //}

            pesoAct42M = ((double)count42M / (double)total42M) * peso42M;
            pesoAct42M = Math.Round(pesoAct42M, 4);
            if (pesoAct42M > peso42M)
            {
                pesoAct42M = peso42M;
            }
            pesototalM = pesototalM + pesoAct42M;
        }


        // Sesiones de formación  No. 4 evaluadas y subidas a la plataforma de Ciclón
        double meta43M = 0;
        int count43M = 0;
        DataTable sesionesformacionsubidasS4 = est.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "4");
        int total43M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalsesion"].ToString());
        double peso43M = 1.3071;
        double pesoAct43M = 0;
        if (sesionesformacionsubidasS4 != null && sesionesformacionsubidasS4.Rows.Count > 0)
        {
            count43M = sesionesformacionsubidasS4.Rows.Count;
            meta43M = ((double)count43M / (double)total43M) * 100;
            meta43M = Math.Round(meta43M, 2);
            //if (meta43 > 100)
            //{
            //    meta43 = 100;
            //}

            pesoAct43M = ((double)count43M / (double)total43M) * peso43M;
            pesoAct43M = Math.Round(pesoAct43M, 4);
            if (pesoAct43M > peso43M)
            {
                pesoAct43M = peso43M;
            }
            pesototalM = pesototalM + pesoAct43M;
        }




        //Sesión 4, Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).

        DataTable sesionesevidenciass4 = c.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "4", "Relatoria institucional");

        double metases4 = 0;
        int countses4 = 0;
        int totalses4 = 1;
        double pesototalses4 = 1.3071;
        double pesoses4 = 0;
        if ((sesionesevidenciass4 != null && sesionesevidenciass4.Rows.Count > 0))
        {
            countses4 = sesionesevidenciass4.Rows.Count;
            metases4 = ((double)countses4 / (double)totalses4) * 100;
            metases4 = Math.Round(metases4, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesoses4 = ((double)countses4 / (double)totalses4) * pesototalses4;
            pesoses4 = Math.Round(pesoses4, 4);
            if (pesoses4 > pesototalses4)
            {
                pesoses4 = pesototalses4;
            }
            pesototalM = pesototalM + pesoses4;
        }

        //Sesión 4, Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.

        DataTable sesionesevidenciasfe4 = c.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "1", "Formato de evaluación");

        double metasfe4 = 0;
        int countsfe4 = 0;
        int totalsfe4 = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalsesion"].ToString());
        double pesototalsfe4 = 1.3071;
        double pesosfe4 = 0;
        if ((sesionesevidenciasfe4 != null && sesionesevidenciasfe4.Rows.Count > 0))
        {
            countsfe4 = sesionesevidenciasfe4.Rows.Count;
            metasfe4 = ((double)countsfe4 / (double)totalsfe4) * 100;
            metasfe4 = Math.Round(metasfe4, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesosfe4 = ((double)countsfe4 / (double)totalsfe4) * pesototalsfe4;
            pesosfe4 = Math.Round(pesosfe4, 4);
            if (pesosfe4 > pesototalsfe4)
            {
                pesosfe4 = pesototalsfe4;
            }
            pesototalM = pesototalM + pesosfe4;
        }

        //----------------------------------------------





        // Sesiones de formación No. 5 realizadas 
        double meta14M = 0;
        int count14M = 0;
        DataTable sesionformacionMaestrosS5 = est.sesionformacionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "5");
        int total14M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalsesion"].ToString());
        double peso14M = 1.3071;
        double pesoAct14M = 0;
        if (sesionformacionMaestrosS5 != null && sesionformacionMaestrosS5.Rows.Count > 0)
        {
            count14M = sesionformacionMaestrosS5.Rows.Count;
            meta14M = ((double)count14M / (double)total14M) * 100;
            meta14M = Math.Round(meta14M, 2);
            //if (meta14 > 100)
            //{
            //    meta14 = 100;
            //}

            pesoAct14M = ((double)count14M / (double)total14M) * peso14M;
            pesoAct14M = Math.Round(pesoAct14M, 4);
            if (pesoAct14M > peso14M)
            {
                pesoAct14M = peso14M;
            }
            pesototalM = pesototalM + pesoAct14M;
        }




        //Asistentes a la sesión de formación No. 5/jornada de actualización No. 9 (5 horas)
        double meta15M = 0;
        int count15M = 0;
        DataTable asistentesSesionMaestrosS5 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "5", "9");
        int total15M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso15M = 1.3071;
        double pesoAct15M = 0;
        if (asistentesSesionMaestrosS5 != null && asistentesSesionMaestrosS5.Rows.Count > 0)
        {
            count15M = asistentesSesionMaestrosS5.Rows.Count;
            meta15M = ((double)count15M / (double)total15M) * 100;
            meta15M = Math.Round(meta15M, 2);
            //if (meta15 > 100)
            //{
            //    meta15 = 100;
            //}

            pesoAct15M = ((double)count15M / (double)total15M) * peso15M;
            pesoAct15M = Math.Round(pesoAct15M, 4);
            if (pesoAct15M > peso15M)
            {
                pesoAct15M = peso15M;
            }
            pesototalM = pesototalM + pesoAct15M;
        }



        // Asistentes a la sesión de formación No. 5/jornada de producción No. 10 (4 horas)
        double meta16M = 0;
        int count16M = 0;
        DataTable asistentesSesionMaestrosS5j10 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "5", "10");
        int total16M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso16M = 1.3071;
        double pesoAct16M = 0;
        if (asistentesSesionMaestrosS5j10 != null && asistentesSesionMaestrosS5j10.Rows.Count > 0)
        {
            count16M = asistentesSesionMaestrosS5j10.Rows.Count;
            meta16M = ((double)count16M / (double)total16M) * 100;
            meta16M = Math.Round(meta16M, 2);
            //if (meta16 > 100)
            //{
            //    meta16 = 100;
            //}

            pesoAct16M = ((double)count16M / (double)total16M) * peso16M;
            pesoAct16M = Math.Round(pesoAct16M, 4);
            if (pesoAct16M > peso16M)
            {
                pesoAct16M = peso16M;
            }
            pesototalM = pesototalM + pesoAct16M;
        }


        //---------------------------------------------
        // Asistentes a la sesión de formación No. 5/ autoformación (2 horas)
        double meta45M = 0;
        int count45M = 0;
        DataTable asistentessesionformacionAutos5 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "5", "10");
        int total45M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso45M = 1.3071;
        double pesoAct45M = 0;
        if (asistentessesionformacionAutos5 != null && asistentessesionformacionAutos5.Rows.Count > 0)
        {
            count45M = asistentessesionformacionAutos5.Rows.Count;
            meta45M = ((double)count45M / (double)total45M) * 100;
            meta45M = Math.Round(meta45M, 2);
            //if (meta45 > 100)
            //{
            //    meta45 = 100;
            //}

            pesoAct45M = ((double)count45M / (double)total45M) * peso45M;
            pesoAct45M = Math.Round(pesoAct45, 4);
            if (pesoAct45M > peso45M)
            {
                pesoAct45M = peso45M;
            }
            pesototalM = pesototalM + pesoAct45M;
        }


        // Asistentes a la sesión de formación No. 5/formación virtual (4 horas)
        double meta46M = 0;
        int count46M = 0;
        DataTable asistentessesionvirtuals5 = est.asistentessesionvirtual(coddepartamento, codmuncipio, codinstitucion, codsede, "5");
        int total46M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso46M = 1.3071;
        double pesoAct46M = 0;
        if (asistentessesionvirtuals5 != null && asistentessesionvirtuals5.Rows.Count > 0)
        {
            count46M = asistentessesionvirtuals5.Rows.Count;
            meta46M = ((double)count46M / (double)total46M) * 100;
            meta46M = Math.Round(meta46M, 2);
            //if (meta46 > 100)
            //{
            //    meta46 = 100;
            //}

            pesoAct46M = ((double)count46M / (double)total46) * peso46M;
            pesoAct46M = Math.Round(pesoAct46M, 4);
            if (pesoAct46M > peso46M)
            {
                pesoAct46M = peso46M;
            }
            pesototalM = pesototalM + pesoAct46M;
        }


        // Sesiones de formación  No. 5 evaluadas y subidas a la plataforma de Ciclón
        double meta47M = 0;
        int count47M = 0;
        DataTable sesionesformacionsubidasS5 = est.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "5");
        int total47M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalsesion"].ToString());
        double peso47M = 1.3071;
        double pesoAct47M = 0;
        if (sesionesformacionsubidasS5 != null && sesionesformacionsubidasS5.Rows.Count > 0)
        {
            count47M = sesionesformacionsubidasS5.Rows.Count;
            meta47M = ((double)count47M / (double)total47M) * 100;
            meta47M = Math.Round(meta47M, 2);
            //if (meta47 > 100)
            //{
            //    meta47 = 100;
            //}

            pesoAct47M = ((double)count47M / (double)total47M) * peso47M;
            pesoAct47M = Math.Round(pesoAct47M, 4);
            if (pesoAct47M > peso47M)
            {
                pesoAct47M = peso47M;
            }
            pesototalM = pesototalM + pesoAct47M;
        }



        //Sesión 5, Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).

        DataTable sesionesevidenciass5 = c.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "5", "Relatoria institucional");

        double metases5 = 0;
        int countses5 = 0;
        int totalses5 = 1;
        double pesototalses5 = 1.3071;
        double pesoses5 = 0;
        if ((sesionesevidenciass5 != null && sesionesevidenciass5.Rows.Count > 0))
        {
            countses5 = sesionesevidenciass5.Rows.Count;
            metases5 = ((double)countses5 / (double)totalses5) * 100;
            metases5 = Math.Round(metases5, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesoses5 = ((double)countses5 / (double)totalses5) * pesototalses5;
            pesoses5 = Math.Round(pesoses5, 4);
            if (pesoses5 > pesototalses5)
            {
                pesoses5 = pesototalses5;
            }
            pesototalM = pesototalM + pesoses5;
        }


        //Sesión 5, Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.

        DataTable sesionesevidenciasfe5 = c.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "5", "Formato de evaluación");

        double metasfe5 = 0;
        int countsfe5 = 0;
        int totalsfe5 = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalsesion"].ToString());
        double pesototalsfe5 = 1.3071;
        double pesosfe5 = 0;
        if ((sesionesevidenciasfe5 != null && sesionesevidenciasfe5.Rows.Count > 0))
        {
            countsfe5 = sesionesevidenciasfe5.Rows.Count;
            metasfe5 = ((double)countsfe5 / (double)totalsfe5) * 100;
            metasfe5 = Math.Round(metasfe5, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesosfe5 = ((double)countsfe5 / (double)totalsfe5) * pesototalsfe5;
            pesosfe5 = Math.Round(pesosfe5, 4);
            if (pesosfe5 > pesototalsfe5)
            {
                pesosfe5 = pesototalsfe5;
            }
            pesototalM = pesototalM + pesosfe5;
        }

        //----------------------------------------------




        // Sesiones de formación No. 6 realizadas 
        double meta17M = 0;
        int count17M = 0;
        DataTable sesionformacionMaestrosS6 = est.sesionformacionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "6");
        int total17M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalsesion"].ToString());
        double peso17M = 1.3071;
        double pesoAct17M = 0;
        if (sesionformacionMaestrosS6 != null && sesionformacionMaestrosS6.Rows.Count > 0)
        {
            count17M = sesionformacionMaestrosS6.Rows.Count;
            meta17M = ((double)count17M / (double)total17M) * 100;
            meta17M = Math.Round(meta17M, 2);
            //if (meta17 > 100)
            //{
            //    meta17 = 100;
            //}

            pesoAct17M = ((double)count17M / (double)total17M) * peso17M;
            pesoAct17M = Math.Round(pesoAct17M, 4);
            if (pesoAct17M > peso17M)
            {
                pesoAct17M = peso17M;
            }
            pesototalM = pesototalM + pesoAct17M;
        }


        //Asistentes a la sesión de formación No. 6/jornada de actualización No. 11 (5 horas)
        double meta18M = 0;
        int count18M = 0;
        DataTable asistentesSesionMaestrosS6 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "6", "11");
        int total18M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso18M = 1.3071;
        double pesoAct18M = 0;
        if (asistentesSesionMaestrosS6 != null && asistentesSesionMaestrosS6.Rows.Count > 0)
        {
            count18M = asistentesSesionMaestrosS6.Rows.Count;
            meta18M = ((double)count18M / (double)total18M) * 100;
            meta18M = Math.Round(meta18M, 2);
            //if (meta18 > 100)
            //{
            //    meta18 = 100;
            //}

            pesoAct18M = ((double)count18M / (double)total18M) * peso18M;
            pesoAct18M = Math.Round(pesoAct18M, 4);
            if (pesoAct18M > peso18M)
            {
                pesoAct18M = peso18M;
            }
            pesototalM = pesototalM + pesoAct18M;
        }


        // Asistentes a la sesión de formación No. 6/jornada de producción No. 12 (4 horas)
        double meta19M = 0;
        int count19M = 0;
        DataTable asistentesSesionMaestrosS6j12 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "6", "12");
        int total19M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso19M = 1.3071;
        double pesoAct19M = 0;
        if (asistentesSesionMaestrosS6j12 != null && asistentesSesionMaestrosS6j12.Rows.Count > 0)
        {
            count19M = asistentesSesionMaestrosS6j12.Rows.Count;
            meta19M = ((double)count19M / (double)total19M) * 100;
            meta19M = Math.Round(meta19M, 2);
            //if (meta19 > 100)
            //{
            //    meta19 = 100;
            //}

            pesoAct19M = ((double)count19M / (double)total19M) * peso19M;
            pesoAct19M = Math.Round(pesoAct19M, 4);
            if (pesoAct19M > peso19M)
            {
                pesoAct19M = peso19M;
            }
            pesototalM = pesototalM + pesoAct19M;
        }


        //---------------------------------------------
        // Asistentes a la sesión de formación No. 6/ autoformación (2 horas)
        double meta49M = 0;
        int count49M = 0;
        DataTable asistentessesionformacionAutos6 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "6", "12");
        int total49M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso49M = 1.3071;
        double pesoAct49M = 0;
        if (asistentessesionformacionAutos6 != null && asistentessesionformacionAutos6.Rows.Count > 0)
        {
            count49M = asistentessesionformacionAutos6.Rows.Count;
            meta49M = ((double)count49M / (double)total49M) * 100;
            meta49M = Math.Round(meta49M, 2);
            //if (meta49 > 100)
            //{
            //    meta49 = 100;
            //}

            pesoAct49M = ((double)count49M / (double)total49M) * peso49M;
            pesoAct49M = Math.Round(pesoAct49M, 4);
            if (pesoAct49M > peso49M)
            {
                pesoAct49M = peso49M;
            }
            pesototalM = pesototalM + pesoAct49M;
        }


        // Asistentes a la sesión de formación No. 6/formación virtual (4 horas)
        double meta50M = 0;
        int count50M = 0;
        DataTable asistentessesionvirtuals6 = est.asistentessesionvirtual(coddepartamento, codmuncipio, codinstitucion, codsede, "6");
        int total50M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso50M = 1.3071;
        double pesoAct50M = 0;
        if (asistentessesionvirtuals6 != null && asistentessesionvirtuals6.Rows.Count > 0)
        {
            count50M = asistentessesionvirtuals6.Rows.Count;
            meta50M = ((double)count50M / (double)total50M) * 100;
            meta50M = Math.Round(meta50M, 2);
            //if (meta50 > 100)
            //{
            //    meta50 = 100;
            //}

            pesoAct50M = ((double)count50M / (double)total50M) * peso50M;
            pesoAct50M = Math.Round(pesoAct50M, 4);
            if (pesoAct50M > peso50M)
            {
                pesoAct50M = peso50M;
            }
            pesototalM = pesototalM + pesoAct50M;
        }


        // Sesiones de formación  No. 6 evaluadas y subidas a la plataforma de Ciclón
        double meta51M = 0;
        int count51M = 0;
        DataTable sesionesformacionsubidasS6 = est.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "6");
        int total51M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalsesion"].ToString());
        double peso51M = 1.3071;
        double pesoAct51M = 0;
        if (sesionesformacionsubidasS6 != null && sesionesformacionsubidasS6.Rows.Count > 0)
        {
            count51M = sesionesformacionsubidasS6.Rows.Count;
            meta51M = ((double)count51M / (double)total51M) * 100;
            meta51M = Math.Round(meta51M, 2);
            //if (meta51 > 100)
            //{
            //    meta51 = 100;
            //}

            pesoAct51M = ((double)count51M / (double)total51M) * peso51M;
            pesoAct51M = Math.Round(pesoAct51M, 4);
            if (pesoAct51M > peso51M)
            {
                pesoAct51M = peso51M;
            }
            pesototalM = pesototalM + pesoAct51M;
        }


        //Sesión 6, Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).

        DataTable sesionesevidenciass6 = c.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "6", "Relatoria institucional");

        double metases6 = 0;
        int countses6 = 0;
        int totalses6 = 1;
        double pesototalses6 = 1.3071;
        double pesoses6 = 0;
        if ((sesionesevidenciass6 != null && sesionesevidenciass6.Rows.Count > 0))
        {
            countses6 = sesionesevidenciass6.Rows.Count;
            metases6 = ((double)countses6 / (double)totalses6) * 100;
            metases6 = Math.Round(metases6, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesoses6 = ((double)countses6 / (double)totalses6) * pesototalses6;
            pesoses6 = Math.Round(pesoses6, 4);
            if (pesoses6 > pesototalses6)
            {
                pesoses6 = pesototalses6;
            }
            pesototalM = pesototalM + pesoses6;
        }

        //Sesión 6, Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.

        DataTable sesionesevidenciasfe6 = c.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "6", "Formato de evaluación");

        double metasfe6 = 0;
        int countsfe6 = 0;
        int totalsfe6 = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalsesion"].ToString());
        double pesototalsfe6 = 1.3071;
        double pesosfe6 = 0;
        if ((sesionesevidenciasfe6 != null && sesionesevidenciasfe6.Rows.Count > 0))
        {
            countsfe6 = sesionesevidenciasfe6.Rows.Count;
            metasfe6 = ((double)countsfe6 / (double)totalsfe6) * 100;
            metasfe6 = Math.Round(metasfe6, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesosfe6 = ((double)countsfe6 / (double)totalsfe6) * pesototalsfe6;
            pesosfe6 = Math.Round(pesosfe6, 4);
            if (pesosfe6 > pesototalsfe6)
            {
                pesosfe6 = pesototalsfe6;
            }
            pesototalM = pesototalM + pesosfe6;
        }

        //----------------------------------------------





        // Sesiones de formación No. 7 realizadas 
        double meta20M = 0;
        int count20M = 0;
        DataTable sesionformacionMaestrosS7 = est.sesionformacionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "5", "7");
        int total20M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalsesion"].ToString());
        double peso20M = 1.3071;
        double pesoAct20M = 0;
        if (sesionformacionMaestrosS7 != null && sesionformacionMaestrosS7.Rows.Count > 0)
        {
            count20M = sesionformacionMaestrosS7.Rows.Count;
            meta20M = ((double)count20M / (double)total20M) * 100;
            meta20M = Math.Round(meta20M, 2);
            //if (meta20 > 100)
            //{
            //    meta20 = 100;
            //}

            pesoAct20M = ((double)count20M / (double)total20M) * peso20M;
            pesoAct20M = Math.Round(pesoAct20M, 4);
            if (pesoAct20M > peso20M)
            {
                pesoAct20M = peso20M;
            }
            pesototalM = pesototalM + pesoAct20M;
        }




        //Asistentes a la sesión de formación No. 7/jornada de actualización No. 13 (5 horas)
        double meta21M = 0;
        int count21M = 0;
        DataTable asistentesSesionMaestrosS7 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "5", "7", "13");
        int total21M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso21M = 1.3071;
        double pesoAct21M = 0;
        if (asistentesSesionMaestrosS7 != null && asistentesSesionMaestrosS7.Rows.Count > 0)
        {
            count21M = asistentesSesionMaestrosS7.Rows.Count;
            meta21M = ((double)count21M / (double)total21M) * 100;
            meta21M = Math.Round(meta21M, 2);
            //if (meta21 > 100)
            //{
            //    meta21 = 100;
            //}

            pesoAct21M = ((double)count21M / (double)total21M) * peso21M;
            pesoAct21M = Math.Round(pesoAct21M, 4);
            if (pesoAct21M > peso21M)
            {
                pesoAct21M = peso21M;
            }
            pesototalM = pesototalM + pesoAct21M;
        }




        // Asistentes a la sesión de formación No. 7/jornada de producción No. 14 (4 horas)
        double meta22M = 0;
        int count22M = 0;
        DataTable asistentesSesionMaestrosS7j14 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "5", "7", "14");
        int total22M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso22M = 1.3071;
        double pesoAct22M = 0;
        if (asistentesSesionMaestrosS7j14 != null && asistentesSesionMaestrosS7j14.Rows.Count > 0)
        {
            count22M = asistentesSesionMaestrosS7j14.Rows.Count;
            meta22M = ((double)count22M / (double)total22M) * 100;
            meta22M = Math.Round(meta22M, 2);
            //if (meta22 > 100)
            //{
            //    meta22 = 100;
            //}

            pesoAct22M = ((double)count22M / (double)total22M) * peso22M;
            pesoAct22M = Math.Round(pesoAct22M, 4);
            if (pesoAct22M > peso22M)
            {
                pesoAct22M = peso22M;
            }
            pesototalM = pesototalM + pesoAct22M;
        }


        //---------------------------------------------
        // Asistentes a la sesión de formación No. 7/ autoformación (2 horas)
        double meta53M = 0;
        int count53M = 0;
        DataTable asistentessesionformacionAutos7 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "5", "7", "14");
        int total53M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso53M = 1.3071;
        double pesoAct53M = 0;
        if (asistentessesionformacionAutos7 != null && asistentessesionformacionAutos7.Rows.Count > 0)
        {
            count53M = asistentessesionformacionAutos7.Rows.Count;
            meta53M = ((double)count53M / (double)total53M) * 100;
            meta53M = Math.Round(meta53M, 2);
            //if (meta53 > 100)
            //{
            //    meta53 = 100;
            //}

            pesoAct53M = ((double)count53M / (double)total53M) * peso53M;
            pesoAct53M = Math.Round(pesoAct53M, 4);
            if (pesoAct53M > peso53M)
            {
                pesoAct53M = peso53M;
            }
            pesototalM = pesototalM + pesoAct53M;
        }


        // Asistentes a la sesión de formación No. 7/formación virtual (4 horas)
        double meta54M = 0;
        int count54M = 0;
        DataTable asistentessesionvirtuals7 = est.asistentessesionvirtual(coddepartamento, codmuncipio, codinstitucion, codsede, "7");
        int total54M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso54M = 1.3071;
        double pesoAct54M = 0;
        if (asistentessesionvirtuals7 != null && asistentessesionvirtuals7.Rows.Count > 0)
        {
            count54M = asistentessesionvirtuals7.Rows.Count;
            meta54M = ((double)count54M / (double)total54M) * 100;
            meta54M = Math.Round(meta54M, 2);
            //if (meta54 > 100)
            //{
            //    meta54 = 100;
            //}

            pesoAct54M = ((double)count54M / (double)total54M) * peso54M;
            pesoAct54M = Math.Round(pesoAct54M, 4);
            if (pesoAct54M > peso54M)
            {
                pesoAct54M = peso54M;
            }
            pesototalM = pesototalM + pesoAct54M;
        }


        // Sesiones de formación  No. 7 evaluadas y subidas a la plataforma de Ciclón
        double meta55M = 0;
        int count55M = 0;
        DataTable sesionesformacionsubidasS7 = est.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "5", "7");
        int total55M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalsesion"].ToString());
        double peso55M = 1.3071;
        double pesoAct55M = 0;
        if (sesionesformacionsubidasS7 != null && sesionesformacionsubidasS7.Rows.Count > 0)
        {
            count55M = sesionesformacionsubidasS7.Rows.Count;
            meta55M = ((double)count55M / (double)total55M) * 100;
            meta55M = Math.Round(meta55M, 2);
            //if (meta55 > 100)
            //{
            //    meta55 = 100;
            //}

            pesoAct55M = ((double)count55M / (double)total55M) * peso55M;
            pesoAct55M = Math.Round(pesoAct55M, 4);
            if (pesoAct55M > peso55M)
            {
                pesoAct55M = peso55M;
            }
            pesototalM = pesototalM + pesoAct55M;
        }


        //Sesión 7, Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).

        DataTable sesionesevidenciass7 = c.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "5", "7", "Relatoria institucional");

        double metases7 = 0;
        int countses7 = 0;
        int totalses7 = 1;
        double pesototalses7 = 1.3071;
        double pesoses7 = 0;
        if ((sesionesevidenciass7 != null && sesionesevidenciass7.Rows.Count > 0))
        {
            countses7 = sesionesevidenciass3.Rows.Count;
            metases7 = ((double)countses7 / (double)totalses7) * 100;
            metases7 = Math.Round(metases7, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesoses7 = ((double)countses7 / (double)totalses7) * pesototalses7;
            pesoses7 = Math.Round(pesoses7, 4);
            if (pesoses7 > pesototalses7)
            {
                pesoses7 = pesototalses7;
            }
            pesototalM = pesototalM + pesoses7;
        }


        //Sesión 7, Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.

        DataTable sesionesevidenciasfe7 = c.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "5", "7", "Formato de evaluación");

        double metasfe7 = 0;
        int countsfe7 = 0;
        int totalsfe7 = 320;
        double pesototalsfe7 = 1.3071;
        double pesosfe7 = 0;
        if ((sesionesevidenciasfe7 != null && sesionesevidenciasfe7.Rows.Count > 0))
        {
            countsfe7 = sesionesevidenciasfe7.Rows.Count;
            metasfe7 = ((double)countsfe7 / (double)totalsfe7) * 100;
            metasfe7 = Math.Round(metasfe7, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesosfe7 = ((double)countsfe7 / (double)totalsfe7) * pesototalsfe7;
            pesosfe7 = Math.Round(pesosfe7, 4);
            if (pesosfe7 > pesototalsfe7)
            {
                pesosfe7 = pesototalsfe7;
            }
            pesototalM = pesototalM + pesosfe7;
        }



        //----------------------------------------------




        // Sesiones de formación No. 8 realizadas 
        double meta23M = 0;
        int count23M = 0;
        DataTable sesionformacionMaestrosS8 = est.sesionformacionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "6", "8");
        int total23M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalsesion"].ToString());
        double peso23M = 1.3071;
        double pesoAct23M = 0;
        if (sesionformacionMaestrosS8 != null && sesionformacionMaestrosS8.Rows.Count > 0)
        {
            count23M = sesionformacionMaestrosS8.Rows.Count;
            meta23M = ((double)count23M / (double)total23M) * 100;
            meta23M = Math.Round(meta23M, 2);
            //if (meta23 > 100)
            //{
            //    meta23 = 100;
            //}

            pesoAct23M = ((double)count23M / (double)total23M) * peso23M;
            pesoAct23M = Math.Round(pesoAct23M, 4);
            if (pesoAct23M > peso23M)
            {
                pesoAct23M = peso23M;
            }
            pesototalM = pesototalM + pesoAct23;
        }


        //Asistentes a la sesión de formación No. 8/jornada de actualización No. 15 (5 horas)
        double meta24M = 0;
        int count24M = 0;
        DataTable asistentesSesionMaestrosS8 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "6", "8", "15");
        int total24M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso24M = 1.3071;
        double pesoAct24M = 0;
        if (asistentesSesionMaestrosS8 != null && asistentesSesionMaestrosS8.Rows.Count > 0)
        {
            count24M = asistentesSesionMaestrosS8.Rows.Count;
            meta24M = ((double)count24M / (double)total24M) * 100;
            meta24M = Math.Round(meta24M, 2);
            //if (meta24 > 100)
            //{
            //    meta24 = 100;
            //}

            pesoAct24M = ((double)count24M / (double)total24M) * peso24M;
            pesoAct24M = Math.Round(pesoAct24M, 4);
            if (pesoAct24M > peso24M)
            {
                pesoAct24M = peso24M;
            }
            pesototalM = pesototalM + pesoAct24;
        }

        // Asistentes a la sesión de formación No. 8/jornada de producción No. 16 (4 horas)
        double meta25M = 0;
        int count25M = 0;
        DataTable asistentesSesionMaestrosS8j16 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "6", "8", "16");
        int total25M = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso25M = 1.3071;
        double pesoAct25M = 0;
        if (asistentesSesionMaestrosS8j16 != null && asistentesSesionMaestrosS8j16.Rows.Count > 0)
        {
            count25M = asistentesSesionMaestrosS8j16.Rows.Count;
            meta25M = ((double)count25M / (double)total25M) * 100;
            meta25M = Math.Round(meta25M, 2);
            //if (meta25 > 100)
            //{
            //    meta25 = 100;
            //}

            pesoAct25M = ((double)count25M / (double)total25M) * peso25M;
            pesoAct25M = Math.Round(pesoAct25M, 4);
            if (pesoAct25M > peso25M)
            {
                pesoAct25M = peso25M;
            }
            pesototalM = pesototalM + pesoAct25M;
        }



        //---------------------------------------------
        // Asistentes a la sesión de formación No. 8/ autoformación (2 horas)
        double meta57 = 0;
        int count57 = 0;
        DataTable asistentessesionformacionAutos8 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "6", "8", "16");
        int total57 = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso57 = 1.3071;
        double pesoAct57 = 0;
        if (asistentessesionformacionAutos8 != null && asistentessesionformacionAutos8.Rows.Count > 0)
        {
            count57 = asistentessesionformacionAutos8.Rows.Count;
            meta57 = ((double)count57 / (double)total57) * 100;
            meta57 = Math.Round(meta57, 2);
            //if (meta57 > 100)
            //{
            //    meta57 = 100;
            //}

            pesoAct57 = ((double)count57 / (double)total57) * peso57;
            pesoAct57 = Math.Round(pesoAct57, 4);
            if (pesoAct57 > peso57)
            {
                pesoAct57 = peso57;
            }
            pesototalM = pesototalM + pesoAct57;
        }


        // Asistentes a la sesión de formación No. 8/formación virtual (4 horas)
        double meta58 = 0;
        int count58 = 0;
        DataTable asistentessesionvirtuals8 = est.asistentessesionvirtual(coddepartamento, codmuncipio, codinstitucion, codsede, "8");
        int total58 = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalmaestros"].ToString());
        double peso58 = 1.3071;
        double pesoAct58 = 0;
        if (asistentessesionvirtuals8 != null && asistentessesionvirtuals8.Rows.Count > 0)
        {
            count58 = asistentessesionvirtuals8.Rows.Count;
            meta58 = ((double)count58 / (double)total58) * 100;
            meta58 = Math.Round(meta58, 2);
            //if (meta58 > 100)
            //{
            //    meta58 = 100;
            //}

            pesoAct58 = ((double)count58 / (double)total58) * peso58;
            pesoAct58 = Math.Round(pesoAct58, 4);
            if (pesoAct58 > peso58)
            {
                pesoAct58 = peso58;
            }
            pesototalM = pesototalM + pesoAct58;
        }


        // Sesiones de formación  No. 8 evaluadas y subidas a la plataforma de Ciclón
        double meta59 = 0;
        int count59 = 0;
        DataTable sesionesformacionsubidasS8 = est.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "6", "8");
        int total59 = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalsesion"].ToString());
        double peso59 = 1.3071;
        double pesoAct59 = 0;
        if (sesionesformacionsubidasS8 != null && sesionesformacionsubidasS8.Rows.Count > 0)
        {
            count59 = sesionesformacionsubidasS8.Rows.Count;
            meta59 = ((double)count59 / (double)total59) * 100;
            meta59 = Math.Round(meta59, 2);
            //if (meta59 > 100)
            //{
            //    meta59 = 100;
            //}

            pesoAct59 = ((double)count59 / (double)total59) * peso59;
            pesoAct59 = Math.Round(pesoAct59, 4);
            if (pesoAct59 > peso59)
            {
                pesoAct59 = peso59;
            }
            pesototalM = pesototalM + pesoAct59;
        }

        // Proyectos de investigación de maestros y maestras con avance en su elaboración
        double meta60 = 0;
        int count60 = 0;
        DataTable proyectosinvestigacionmaestross8 = est.proyectosinvestigacionmaestros(coddepartamento, codmuncipio, codinstitucion, codsede);
        int total60 = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalsesion"].ToString());
        double peso60 = 1.3071;
        double pesoAct60 = 0;
        if (proyectosinvestigacionmaestross8 != null && proyectosinvestigacionmaestross8.Rows.Count > 0)
        {
            count60 = proyectosinvestigacionmaestross8.Rows.Count;
            meta60 = ((double)count60 / (double)total60) * 100;
            meta60 = Math.Round(meta60, 2);
            //if (meta60 > 100)
            //{
            //    meta60 = 100;
            //}

            pesoAct60 = ((double)count60 / (double)total60) * peso60;
            pesoAct60 = Math.Round(pesoAct60, 4);
            if (pesoAct60 > peso60)
            {
                pesoAct60 = peso60;
            }
            pesototalM = pesototalM + pesoAct60;
        }

        //Sesión 8, Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).

        DataTable sesionesevidenciass8 = c.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "6", "8", "Relatoria institucional");

        double metases8 = 0;
        int countses8 = 0;
        int totalses8 = 1;
        double pesototalses8 = 1.3071;
        double pesoses8 = 0;
        if ((sesionesevidenciass8 != null && sesionesevidenciass8.Rows.Count > 0))
        {
            countses8 = sesionesevidenciass8.Rows.Count;
            metases8 = ((double)countses8 / (double)totalses8) * 100;
            metases8 = Math.Round(metases8, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesoses8 = ((double)countses8 / (double)totalses8) * pesototalses8;
            pesoses8 = Math.Round(pesoses8, 4);
            if (pesoses8 > pesototalses8)
            {
                pesoses8 = pesototalses8;
            }
            pesototalM = pesototalM + pesoses8;
        }


        //Sesión 8, Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.

        DataTable sesionesevidenciasfe8 = c.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "6", "8", "Formato de evaluación");

        double metasfe8 = 0;
        int countsfe8 = 0;
        int totalsfe8 = Convert.ToInt32(loadTotalesIndicadoresxSedeM["totalsesion"].ToString());
        double pesototalsfe8 = 1.3071;
        double pesosfe8 = 0;
        if ((sesionesevidenciasfe8 != null && sesionesevidenciasfe8.Rows.Count > 0))
        {
            countsfe8 = sesionesevidenciasfe8.Rows.Count;
            metasfe8 = ((double)countsfe8 / (double)totalsfe8) * 100;
            metasfe8 = Math.Round(metasfe8, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesosfe8 = ((double)countsfe8 / (double)totalsfe8) * pesototalsfe8;
            pesosfe8 = Math.Round(pesosfe8, 4);
            if (pesosfe8 > pesototalsfe8)
            {
                pesosfe8 = pesototalsfe8;
            }
            pesototalM = pesototalM + pesosfe8;
        }

        //----------------------------------------------




        //Documentos de introducción de la IEP apoyada en TIC en los currículos de las sedes educativas.
        DataTable introiep = c.cargarListadointroiepEstraDos(coddepartamento, codmuncipio, codinstitucion, codsede);

        double metaiep = 0;
        int countiep = 0;
        int totaliep = 1;
        double pesototaliep = 1.3071;
        double pesoiep = 0;
        if ((introiep != null && introiep.Rows.Count > 0))
        {
            countiep = introiep.Rows.Count;

            metaiep = ((double)countiep / (double)totaliep) * 100;
            metaiep = Math.Round(metaiep, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesoiep = ((double)countiep / (double)totaliep) * pesototaliep;
            pesoiep = Math.Round(pesoiep, 4);
            if (pesoiep > pesototaliep)
            {
                pesoiep = pesototaliep;
            }
            pesototalM = pesototalM + pesoiep;
        }

        //Espacios de reflexión, producción y apropiación de maestros que aprenden de maestros, denominados: “El maestro tiene la palabra”.
        DataTable docenteapropiacion = c.cargarApropiacionDocentesSeleccionados(coddepartamento, codmuncipio, codinstitucion, codsede);

        double metaapro = 0;
        int countapro = 0;
        int totalapro = 2;
        double pesototalapro = 3.63;
        double pesoapro = 0;
        if ((docenteapropiacion != null && docenteapropiacion.Rows.Count > 0))
        {
            countapro = docenteapropiacion.Rows.Count;
            metaapro = ((double)countapro / (double)totalapro) * 100;
            metaapro = Math.Round(metaapro, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesoapro = ((double)countapro / (double)totalapro) * pesototalapro;
            pesoapro = Math.Round(pesoapro, 4);
            if (pesoapro > pesototalapro)
            {
                pesoapro = pesototalapro;
            }
            pesototalM = pesototalM + pesoapro;
        }

        //Ponencias de maestros y maestras inscritas para participación en ferias.
        //DataTable docenteapropiacion2 = c.cargarApropiacionDocentesSeleccionados("", "", "", "");

        double metaapro2 = 0;
        int countapro2 = 0;
        int totalapro2 = 2;
        double pesototalapro2 = 3.63;
        double pesoapro2 = 0;
        if ((docenteapropiacion != null && docenteapropiacion.Rows.Count > 0))
        {
            countapro2 = docenteapropiacion.Rows.Count;
            metaapro2 = ((double)countapro2 / (double)totalapro2) * 100;
            metaapro2 = Math.Round(metaapro2, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesoapro2 = ((double)countapro2 / (double)totalapro2) * pesototalapro2;
            pesoapro2 = Math.Round(pesoapro2, 4);
            if (pesoapro2 > pesototalapro2)
            {
                pesoapro2 = pesototalapro2;
            }
            pesototalM = pesototalM + pesoapro2;
        }

        //Ejemplares de la caja de herramientas  que soporta la formación de maestros(as)  del Proyecto Ciclón, impresos.

        DataTable cajah = c.cargarEntregaMaterialesCoordEstra2(coddepartamento, codmuncipio, codinstitucion, codsede, "Caja de herramientas para maestros");

        double metacajah = 0;
        int countcajah = 0;
        int totalcajah = 1;
        double pesototalcajah = 1.1400;
        double pesocajah = 0;
        if ((cajah != null && cajah.Rows.Count > 0))
        {
            countcajah = cajah.Rows.Count;

            metacajah = ((double)countcajah / (double)totalcajah) * 100;
            metacajah = Math.Round(metacajah, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesocajah = ((double)countcajah / (double)totalcajah) * pesototalcajah;
            pesocajah = Math.Round(pesocajah, 4);
            if (pesocajah > pesototalcajah)
            {
                pesocajah = pesototalcajah;
            }
            pesototalM = pesototalM + pesocajah;
        }


        //Sistematizaciones y/o Investigaciones de grupos de maestros(as) acompañantes investigadores siguiendo lo definido por  el programa Ondas.

        DataTable s003 = c.cargarInstrmentoS003(coddepartamento, codmuncipio, codinstitucion, codsede);

        double metas003 = 0;
        int counts003 = 0;
        int totals003 = 1;
        double pesototals003 = 4.570;
        double pesos003 = 0;
        if ((s003 != null && s003.Rows.Count > 0))
        {
            counts003 = s003.Rows.Count;

            metas003 = ((double)counts003 / (double)totals003) * 100;
            metas003 = Math.Round(metas003, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesos003 = ((double)counts003 / (double)totals003) * pesototals003;
            pesos003 = Math.Round(pesos003, 4);
            if (pesos003 > pesototals003)
            {
                pesos003 = pesototals003;
            }
            pesototalM = pesototalM + pesos003;
        }

        //Publicaciones impresas y/o digitales de los procesos y resultados de los equipos pedagógicos institucionales y grupos de investigación de los maestros y maestras.

        DataTable publicaciones = c.cargarEntregaMaterialesCoordEstra2(coddepartamento, codmuncipio, codinstitucion, codsede, "Publicaciones");

        double metapub = 0;
        int countpub = 0;
        int totalpub = 1;
        double pesototalpub = 1.1400;
        double pesopub = 0;
        if ((publicaciones != null && publicaciones.Rows.Count > 0))
        {
            countpub = publicaciones.Rows.Count;

            metapub = ((double)countpub / (double)totalpub) * 100;
            metapub = Math.Round(metapub, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesopub = ((double)countpub / (double)totalpub) * pesototalcajah;
            pesopub = Math.Round(pesopub, 4);
            if (pesopub > pesototalpub)
            {
                pesopub = pesototalpub;
            }
            pesototalM = pesototalM + pesopub;
        }

        //Contenidos educativos digitales para introducir la investigación en cada una de las 6 areas del curriculo para 10 niveles escolares. Contrapartida CUC.
        DataTable contenidosdig = c.cargarApropiacionDocentesSeleccionados(coddepartamento, codmuncipio, codinstitucion, codsede);

        double metadg = 0;
        int countdg = 0;
        int totaldg = 60;
        double pesototaldg = 1.7100;
        double pesodg = 0;
        if ((contenidosdig != null && contenidosdig.Rows.Count > 0))
        {
            countdg = docenteapropiacion.Rows.Count;
            metadg = ((double)countdg / (double)totaldg) * 100;
            metadg = Math.Round(metadg, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesodg = ((double)countdg / (double)totaldg) * pesototaldg;
            pesodg = Math.Round(pesodg, 4);
            if (pesodg > pesototaldg)
            {
                pesodg = pesototaldg;
            }
            pesototalM = pesototalM + pesodg;
        }

        //Maestros y maestras  acompañantes de los grupos de investigación infantiles y juveniles pero que no están en la estrategia No 2. de formación.
        DataTable acompanante = c.cargarDocentesEstra1_Estra2Where(coddepartamento, codmuncipio, codinstitucion, codsede);

        double metad = 0;
        int countd = 0;
        int totald = 60;
        double pesototald = 1.7100;
        double pesod = 0;
        if ((acompanante != null && acompanante.Rows.Count > 0))
        {
            countd = acompanante.Rows.Count;
            metad = ((double)countd / (double)totald) * 100;
            metad = Math.Round(metad, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesod = ((double)countd / (double)totald) * pesototald;
            pesod = Math.Round(pesod, 4);
            if (pesod > pesototald)
            {
                pesod = pesototald;
            }
            pesototalM = pesototalM + pesod;
        }


        //Maestros y maestras  acompañantes de las redes temáticas infantiles y juveniles pero que no están en la estrategia No 2. de formación.
        DataTable acompanante2 = c.cargarDocentesRedestematicasWhere(coddepartamento, codmuncipio, codinstitucion, codsede);

        double metad2 = 0;
        int countd2 = 0;
        int totald2 = 60;
        double pesototald2 = 1.7100;
        double pesod2 = 0;
        if ((acompanante2 != null && acompanante2.Rows.Count > 0))
        {
            countd2 = acompanante2.Rows.Count;
            metad2 = ((double)countd2 / (double)totald2) * 100;
            metad2 = Math.Round(metad2, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesod2 = ((double)countd2 / (double)totald2) * pesototald2;
            pesod2 = Math.Round(pesod2, 4);
            if (pesod2 > pesototald2)
            {
                pesod2 = pesototald2;
            }
            pesototalM = pesototalM + pesod2;
        }


        //Maestros y maestras  acompañantes de procesos de apropiación social pero que no están en la estrategia No 2. de formación.
        DataTable acompanante3 = c.cargarDocentesApropiacionSocialWhere(coddepartamento, codmuncipio, codinstitucion, codsede);

        double metad3 = 0;
        int countd3 = 0;
        int totald3 = 60;
        double pesototald3 = 1.7100;
        double pesod3 = 0;
        if ((acompanante3 != null && acompanante3.Rows.Count > 0))
        {
            countd3 = acompanante3.Rows.Count;
            metad3 = ((double)countd3 / (double)totald3) * 100;
            metad3 = Math.Round(metad3, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesod3 = ((double)countd3 / (double)totald3) * pesototald3;
            pesod3 = Math.Round(pesod3, 4);
            if (pesod3 > pesototald3)
            {
                pesod3 = pesototald3;
            }
            pesototalM = pesototalM + pesod3;
        }



        ///////////////////////////////////////////////////////////////////////////
        double porcentaje = Math.Round(pesototal, 2);
        porcentaje = Math.Round(porcentaje / 5, 2);


        double porcentajeM = Math.Round(pesototalM, 2);
        porcentajeM = Math.Round(porcentajeM / 5, 2);


        //ca += "@" + porcentajeM + "@" + porcentaje + "@";
        ca += "@" + metaporcxMunicipioM + "@" + metaporcxSedeM + "@" + porcentajeM + "@" + porcentaje + "@0@";
        //ca += "@" + metaporcxMunicipioM + "@" + metaporcxSedeM + "@" + metaporcxMaestrosM + "@" + metaporcxEstuM + "@0@" ;

        if (totalmunicipio != null && totalmunicipio.Rows.Count > 0)
        {
            for (int i = 0; i < totalmunicipio.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + totalmunicipio.Rows[i]["municipio"].ToString() + "</td>";
                ca += "</tr>";
            }
        }
        ca += "@";
        if (totalSedes != null && totalSedes.Rows.Count > 0)
        {
            for (int i = 0; i < totalSedes.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + totalSedes.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + totalSedes.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + totalSedes.Rows[i]["sede"].ToString() + "</td>";
                ca += "</tr>";
            }
        }
        //ca += "@";
        //if (totalMaestros != null && totalMaestros.Rows.Count > 0)
        //{
        //    for (int i = 0; i < totalMaestros.Rows.Count; i++)
        //    {
        //        ca += "<tr>";
        //        ca += "<td>" + (i + 1) + "</td>";
        //        ca += "<td>" + totalMaestros.Rows[i]["municipio"].ToString() + "</td>";
        //        ca += "<td>" + totalMaestros.Rows[i]["institucion"].ToString() + "</td>";
        //        ca += "<td>" + totalMaestros.Rows[i]["sede"].ToString() + "</td>";
        //        ca += "<td>" + totalMaestros.Rows[i]["identificacion"].ToString() + "</td>";
        //        ca += "<td>" + totalMaestros.Rows[i]["nombre"].ToString() + "</td>";
        //        ca += "</tr>";
        //    }
        //}

        return ca;
    }
    

    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("informedesarrollo.aspx");
    }
    
}