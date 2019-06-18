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

public partial class indicadoresinstitucion : System.Web.UI.Page
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
        if (HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["ins"]) == null)
        {
            Response.Redirect("indicadoresmunicipal.aspx?mun=" + HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["mun"]) + "&dep=" + HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["dep"]));
        }
        if (HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["tipo"]) != null)
        {
            Session["tipo"] = HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["tipo"]);
        }
        if (HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["mun"]) == null)
        {
            Response.Redirect("indicadoresdepartamental.aspx?dep=" + HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["dep"]));
        }
        if (HttpUtility.UrlDecode(HttpContext.Current.Request.QueryString["dep"]) == null)
        {
            Response.Redirect("indicadoresdepartamental.aspx?dep=20");
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

    //cargar instituciones
    [WebMethod(EnableSession = true)]
    public static string cargarInstituciones(string codDepartamento, string codMunicipio, string codInstitucion)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.proccargarInstitucionxMunicipio(codMunicipio);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "inst@";
            ca += "<option value=''>Seleccione</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                if (codInstitucion == datos.Rows[i]["codigo"].ToString())
                {
                    ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "' selected>" + datos.Rows[i]["nombre"].ToString() + "</option>";
                }
                else
                {
                    ca += "<option value='" + datos.Rows[i]["codigo"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
                }
            }
        }

        return ca;
    }


    //cargar institucion seleccionada y municipio
    [WebMethod(EnableSession = true)]
    public static string cargarInsMun(string codDepartamento, string codMunicipio, string codInstitucion)
    {
        string ca = "";

        Institucion inst = new Institucion();


        DataTable institucion = inst.proccargarInstitucionxMunicipio(codMunicipio);

        if (institucion != null)
        {
            if (institucion != null && institucion.Rows.Count > 0)
            {
                ca = "inst@";
                for (int i = 0; i < institucion.Rows.Count; i++)
                {
                    if (codInstitucion == institucion.Rows[i]["codigo"].ToString())
                    {
                        ca += "<option value='" + institucion.Rows[i]["codigo"].ToString() + "' selected>" + institucion.Rows[i]["nombre"].ToString() + "</option>";
                    }
                    else
                    {
                        ca += "<option value='" + institucion.Rows[i]["codigo"].ToString() + "'>" + institucion.Rows[i]["nombre"].ToString() + "</option>";
                    }
                }
            }
        }

        DataTable datos = inst.cargarciudadxDepartamento(codDepartamento);
        if (datos != null && datos.Rows.Count > 0)
        {
            ca += "@";
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


    //cargar sedes
    [WebMethod(EnableSession = true)]
    public static string cargarSedesxInstitucion(string codInstitucion, string codSede)
    {
        string ca = "";

        Institucion inst = new Institucion();

        DataTable datos = inst.cargarSedesInstitucion(codInstitucion);

        if (datos != null && datos.Rows.Count > 0)
        {
            ca = "sede@";
            ca += "<option value='0'>Seleccione</option>";

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                if (codSede == datos.Rows[i]["cod"].ToString())
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
       

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string realizarBusquedaloadreport(string coddepartamento, string codmuncipio, string codinstitucion, string codsede)
    {
       
        string ca = "lleno@";
        double totalpeso = 0;
        Estrategias est = new Estrategias();
        Institucion ins = new Institucion();
        double pesototal = 0;



        //total grupos de investigacion por municipio
        DataRow totalgpxMunicipio = ins.totalgpxMunicipio(codmuncipio);

        DataTable gpSeleccionadosconvocatoria = est.gpSeleccionadosconvocatoria(coddepartamento, codmuncipio, codinstitucion, codsede);

        double meta1 = 0;
        int count1 = 0;

        DataRow loadTotalesIndicadoresxSede = ins.loadTotalesIndicadoresxSede(codsede);
        int total1 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalgrupos"].ToString());
        double peso1 = 0.02;
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




        //Niños, niñas y jóvenes inscritos en grupos de investigación infantiles y juveniles en la convocatoria Ciclón 
        DataTable estudianesengp = est.estudianesengp(coddepartamento, codmuncipio, codinstitucion, codsede);
        double meta2 = 0;
        int count2 = 0;
        int total2 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalasistentesasesorias"].ToString());
        double peso2 = 0.02;
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
        double peso3 = 0.02;
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
        double peso4 = 0.02;
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
        double peso5 = 0.02;
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
        double peso6 = 0.02;
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
        double peso7 = 0.02;
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
        double peso8 = 0.02;
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
        double peso9 = 0.02;
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
        double peso10 = 0.02;
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
        double peso11 = 0.02;
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
        double peso12 = 0.02;
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
        double peso13 = 0.02;
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
        double peso14 = 0.02;
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
        double peso15 = 0.02;
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
            ////if (meta15 > 100)
            ////{
            ////    meta15 = 100;
            ////}
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
        double peso16 = 0.02;
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
        double peso17 = 0.02;
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
        double peso18 = 0.02;
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
        double peso19 = 0.02;
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
        double peso20 = 0.02;
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
        double peso21 = 0.02;
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
        double peso22 = 0.02;
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
        double peso23 = 0.02;
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
        double peso24 = 0.02;
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
        double peso25 = 0.02;
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
        double peso26 = 0.02;
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
        double peso27 = 0.02;
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

        // ---------------------- NUEVO CODIGO --------------
        //28) Grupos de investigación infantiles y juveniles que se inscribieron en la convocatoria de Ciclón 
        DataTable gpinscritosconvocatoriaciclon = est.gpinscritosconvocatoriaciclon(coddepartamento, codmuncipio, codinstitucion, codsede, "1");
        double meta28 = 0;
        int count28 = 0;
        int total28 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalgrupos"].ToString());
        double peso28 = 0.02;
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
        DataTable gprecursosaprortados = est.gprecursosaprortados(coddepartamento, codmuncipio, codinstitucion, codsede, "1");
        double meta29 = 0;
        int count29 = 0;
        int total29 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalgrupos"].ToString());
        double peso29 = 0.02;
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
        double peso30 = 0.02;
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
        double peso31 = 0.02;
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
        double peso32 = 0.02;
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


        //33) Sesiones de formación No. 5 realizadas
        DataTable sesionesformacion5 = est.sesionformacion_pre(coddepartamento, codmuncipio, codinstitucion, codsede, 4, 5);
        double meta33 = 0;
        int count33 = 0;
        int total33 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesionpresencial"].ToString());
        double peso33 = 0.02;
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
        double peso34 = 0.02;
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
        double peso35 = 0.02;
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
        double peso36 = 0.02;
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
        double peso37 = 0.02;
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
        double peso38 = 0.02;
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
        double peso39 = 0.02;
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
        double peso40 = 0.02;
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
        double peso41 = 0.02;
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
        double peso42 = 0.02;
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
        double peso43 = 0.02;
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
        double peso44 = 0.02;
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
        double peso45 = 0.02;
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
        double peso46 = 0.02;
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
        double peso47 = 0.02;
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
        double peso48 = 0.02;
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
        double peso49 = 0.02;
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
        double peso50 = 0.02;
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
        double peso51 = 0.02;
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
        double peso52 = 0.02;
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
        double peso53 = 0.02;
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
        double peso54 = 0.02;
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
        double peso55 = 0.02;
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
        double peso56 = 0.02;
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

        

        
        //------------------------------------------

        if (HttpContext.Current.Session["tipo"].ToString() == "est")
        {
            double porcentaje = Math.Round(pesototal, 2) * 100;
            porcentaje = Math.Round(porcentaje, 2);
            totalpeso = pesototal;
            ca += "<tr>";
            ca += "<td><b>1</b></td><td> Niños, niñas y jóvenes que son beneficiados por el programa Ciclón de la institución</td>";
            ca += "<td class='center'>" + pesototal + "</td>";
            ca += "<td class='noExl center'><a href='indicadoresestudiantes.aspx?ins=" + codinstitucion + "&mun=" + codmuncipio + "&dep=" + coddepartamento + "&sed=" + codsede + "'><img src='images/detalles.png'>Ver</a></td>";
            ca += "</tr>";
        }
        else
        {
            double pesom = indicadoresMaestros(coddepartamento, codmuncipio, codinstitucion, codsede);
            double pesoMaestros = indicadoresMaestros(coddepartamento, codmuncipio, codinstitucion, codsede) / 2;
            pesoMaestros = Math.Round(pesoMaestros, 2);
            totalpeso = pesoMaestros;
            ca += "<tr>";
            ca += "<td><b>2</b></td><td> Maestros y maestras miembros del programa Ciclón de la institución</td>";
            ca += "<td class='center'>" + pesoMaestros + "</td>";
            ca += "<td class='noExl center'><a href='indicadoresmaestros.aspx?ins=" + codinstitucion + "&mun=" + codmuncipio + "&dep=" + coddepartamento + "&sed=" + codsede + "'><img src='images/detalles.png'>Ver</a></td>";
            ca += "</tr>";
        }


        totalpeso = Math.Round(totalpeso, 2) * 100;

        ca += "@" + totalpeso;
        

        

        return ca;
    }





    public static double indicadoresMaestros(string coddepartamento, string codmuncipio, string codinstitucion, string codsede)
    {
        string ca = "";
        Estrategias est = new Estrategias();
        Institucion ins = new Institucion();
        double pesototal = 0;
        int num = 0;


        // 1. Maestros y maestras acompañantes / coinvestigadores matriculados en la estrategia  No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica
        double meta1 = 0;
        int count1 = 0;
        DataTable maestrosmatriculadosestra2 = est.maestrosmatriculadosestra2(coddepartamento, codmuncipio, codinstitucion, codsede, "2");
        DataRow loadTotalesIndicadoresxSede = ins.loadTotalesIndicadoresxSedeMaestros(codsede);
        int total1 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso1 = 0.008791209;
        double pesoAct1 = 0;

        if (maestrosmatriculadosestra2 != null && maestrosmatriculadosestra2.Rows.Count > 0)
        {
            count1 = maestrosmatriculadosestra2.Rows.Count;
            meta1 = ((double)count1 / (double)total1) * 100;
            meta1 = Math.Round(meta1, 2);
            if (meta1 > 100)
            {
                meta1 = 100;
            }

            pesoAct1 = ((double)count1 / (double)total1) * peso1;
            pesoAct1 = Math.Round(pesoAct1, 4);
            if (pesoAct1 > peso1)
            {
                pesoAct1 = peso1;
            }
            pesototal = pesototal + pesoAct1;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Maestros y maestras acompañantes / coinvestigadores matriculados en la estrategia  No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica</td>";
        //ca += "<td class='center'>" + total1 + "</td>";
        //ca += "<td class='center'>" + count1 + "</td>";
        //ca += "<td class='center'>" + meta1 + "%</td>";
        //ca += "<td class='center'>" + pesoAct1 + " de " + peso1 + "</td>";
        //ca += "</tr>";


        // Asistentes a la sesión de asesoría a grupos infantiles y juveniles
        double meta26 = 0;
        int count26 = 0;
        DataTable asistentesgruposinv = est.asistentesgruposinv(coddepartamento, codmuncipio, codinstitucion, codsede);
        int total26 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso26 = 0.008791209;
        double pesoAct26 = 0;

        if (asistentesgruposinv != null && asistentesgruposinv.Rows.Count > 0)
        {
            count26 = asistentesgruposinv.Rows.Count;
            meta26 = ((double)count26 / (double)total26) * 100;
            meta26 = Math.Round(meta26, 2);
            if (meta26 > 100)
            {
                meta26 = 100;
            }

            pesoAct26 = ((double)count26 / (double)total26) * peso26;
            pesoAct26 = Math.Round(pesoAct26, 4);
            if (pesoAct26 > peso26)
            {
                pesoAct26 = peso26;
            }
            pesototal = pesototal + pesoAct26;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de asesoría a grupos infantiles y juveniles</td>";
        //ca += "<td class='center'>" + total26 + "</td>";
        //ca += "<td class='center'>" + count26 + "</td>";
        //ca += "<td class='center'>" + meta26 + "%</td>";
        //ca += "<td class='center'>" + pesoAct26 + " de " + peso26 + "</td>";
        //ca += "</tr>";


        // Maestros y maestras lideres de las redes temáticas formados en los lineamientos del Programa Ciclón y su propuesta metodológica
        double meta27 = 0;
        int count27 = 0;
        DataTable maestrosredestematicas = est.maestrosredestematicas(coddepartamento, codmuncipio, codinstitucion, codsede);
        int total27 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso27 = 0.008791209;
        double pesoAct27 = 0;

        if (maestrosredestematicas != null && maestrosredestematicas.Rows.Count > 0)
        {
            count27 = maestrosredestematicas.Rows.Count;
            meta27 = ((double)count27 / (double)total27) * 100;
            meta27 = Math.Round(meta27, 2);
            if (meta27 > 100)
            {
                meta27 = 100;
            }

            pesoAct27 = ((double)count27 / (double)total27) * peso27;
            pesoAct27 = Math.Round(pesoAct27, 4);
            if (pesoAct27 > peso27)
            {
                pesoAct27 = peso27;
            }
            pesototal = pesototal + pesoAct27;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Maestros y maestras lideres de las redes temáticas formados en los lineamientos del Programa Ciclón y su propuesta metodológica</td>";
        //ca += "<td class='center'>" + total27 + "</td>";
        //ca += "<td class='center'>" + count27 + "</td>";
        //ca += "<td class='center'>" + meta27 + "%</td>";
        //ca += "<td class='center'>" + pesoAct27 + " de " + peso27 + "</td>";
        //ca += "</tr>";


        // Sesión de jornadas de formación realizadas en la sede
        //double meta28 = 0;
        //int count28 = 0;
        //DataTable sesionjornadasxsede = est.sesionjornadasxsede(coddepartamento, codmuncipio, codinstitucion, codsede, "1", "1");
        //int total28 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        //double peso28 = 0.008791209;
        //double pesoAct28 = 0;

        //if (sesionjornadasxsede != null && sesionjornadasxsede.Rows.Count > 0)
        //{
        //    count28 = sesionjornadasxsede.Rows.Count;
        //    meta28 = ((double)count28 / (double)total28) * 100;
        //    meta28 = Math.Round(meta28, 2);
        //    if (meta28 > 100)
        //    {
        //        meta28 = 100;
        //    }

        //    pesoAct28 = ((double)count28 / (double)total28) * peso28;
        //    pesoAct28 = Math.Round(pesoAct28, 4);
        //    if (pesoAct28 > peso28)
        //    {
        //        pesoAct28 = peso28;
        //    }
        //    pesototal = pesototal + pesoAct28;
        //}
        //num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Sesión de jornadas de formación realizadas en la sede</td>";
        //ca += "<td class='center'>" + total28 + "</td>";
        //ca += "<td class='center'>" + count28 + "</td>";
        //ca += "<td class='center'>" + meta28 + "%</td>";
        //ca += "<td class='center'>" + pesoAct28 + " de " + peso28 + "</td>";
        //ca += "</tr>";


        // Sesión de formación No. 1
        double meta2 = 0;
        int count2 = 0;
        DataTable sesionformacionMaestrosS1 = est.sesionformacionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "1", "1");
        int total2 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso2 = 0.008791209;
        double pesoAct2 = 0;

        if (sesionformacionMaestrosS1 != null && sesionformacionMaestrosS1.Rows.Count > 0)
        {
            count2 = sesionformacionMaestrosS1.Rows.Count;
            meta2 = ((double)count2 / (double)total2) * 100;
            meta2 = Math.Round(meta2, 2);
            if (meta2 > 100)
            {
                meta2 = 100;
            }

            pesoAct2 = ((double)count2 / (double)total2) * peso2;
            pesoAct2 = Math.Round(pesoAct2, 4);
            if (pesoAct2 > peso2)
            {
                pesoAct2 = peso2;
            }
            pesototal = pesototal + pesoAct2;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Sesión de formación No. 1</td>";
        //ca += "<td class='center'>" + total2 + "</td>";
        //ca += "<td class='center'>" + count2 + "</td>";
        //ca += "<td class='center'>" + meta2 + "%</td>";
        //ca += "<td class='center'>" + pesoAct2 + " de " + peso2 + "</td>";
        //ca += "</tr>";


        // Asistentes a la sesión de formación No. 1/jornada de actualización No. 1 (5 horas)
        double meta3 = 0;
        int count3 = 0;
        DataTable asistentesSesionMaestrosS1 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "1", "1", "1");
        int total3 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso3 = 0.008791209;
        double pesoAct3 = 0;

        if (asistentesSesionMaestrosS1 != null && asistentesSesionMaestrosS1.Rows.Count > 0)
        {
            count3 = asistentesSesionMaestrosS1.Rows.Count;
            meta3 = ((double)count3 / (double)total3) * 100;
            meta3 = Math.Round(meta3, 2);
            if (meta3 > 100)
            {
                meta3 = 100;
            }

            pesoAct3 = ((double)count3 / (double)total3) * peso3;
            pesoAct3 = Math.Round(pesoAct3, 4);
            if (pesoAct3 > peso3)
            {
                pesoAct3 = peso3;
            }
            pesototal = pesototal + pesoAct3;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 1/jornada de actualización No. 1 (5 horas)</td>";
        //ca += "<td class='center'>" + total3 + "</td>";
        //ca += "<td class='center'>" + count3 + "</td>";
        //ca += "<td class='center'>" + meta3 + "%</td>";
        //ca += "<td class='center'>" + pesoAct3 + " de " + peso3 + "</td>";
        //ca += "</tr>";




        // Maestros asistentes a la sesión de formación No. 1/jornada de producción No. 1 (4 horas)
        double meta4 = 0;
        int count4 = 0;
        DataTable asistentesSesionMaestrosS1j2 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "1", "1", "2");
        int total4 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso4 = 0.008791209;
        double pesoAct4 = 0;
        if (asistentesSesionMaestrosS1j2 != null && asistentesSesionMaestrosS1j2.Rows.Count > 0)
        {
            count4 = asistentesSesionMaestrosS1j2.Rows.Count;
            meta4 = ((double)count4 / (double)total4) * 100;
            meta4 = Math.Round(meta4, 2);
            if (meta4 > 100)
            {
                meta4 = 100;
            }

            pesoAct4 = ((double)count4 / (double)total4) * peso4;
            pesoAct4 = Math.Round(pesoAct4, 4);
            if (pesoAct4 > peso4)
            {
                pesoAct4 = peso4;
            }
            pesototal = pesototal + pesoAct4;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Maestros asistentes a la sesión de formación No. 1/jornada de producción No. 1 (4 horas)</td>";
        //ca += "<td class='center'>" + total4 + "</td>";
        //ca += "<td class='center'>" + count4 + "</td>";
        //ca += "<td class='center'>" + meta4 + "%</td>";
        //ca += "<td class='center'>" + pesoAct4 + " de " + peso4 + "</td>";
        //ca += "</tr>";

        // Asistentes a la sesión de formación No. 1/ autoformación (2 horas)
        double meta29 = 0;
        int count29 = 0;
        DataTable asistentessesionformacionAutos1 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "1", "1", "2");
        int total29 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso29 = 0.008791209;
        double pesoAct29 = 0;
        if (asistentessesionformacionAutos1 != null && asistentessesionformacionAutos1.Rows.Count > 0)
        {
            count29 = asistentessesionformacionAutos1.Rows.Count;
            meta29 = ((double)count29 / (double)total29) * 100;
            meta29 = Math.Round(meta29, 2);
            if (meta29 > 100)
            {
                meta29 = 100;
            }

            pesoAct29 = ((double)count29 / (double)total29) * peso29;
            pesoAct29 = Math.Round(pesoAct29, 4);
            if (pesoAct29 > peso29)
            {
                pesoAct29 = peso29;
            }
            pesototal = pesototal + pesoAct29;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 1/ autoformación (2 horas)</td>";
        //ca += "<td class='center'>" + total29 + "</td>";
        //ca += "<td class='center'>" + count29 + "</td>";
        //ca += "<td class='center'>" + meta29 + "%</td>";
        //ca += "<td class='center'>" + pesoAct29 + " de " + peso29 + "</td>";
        //ca += "</tr>";

        // Asistentes a la sesión de formación No. 1/formación virtual (4 horas)
        double meta30 = 0;
        int count30 = 0;
        DataTable asistentessesionvirtual = est.asistentessesionvirtual(coddepartamento, codmuncipio, codinstitucion, codsede, "1");
        int total30 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso30 = 0.008791209;
        double pesoAct30 = 0;
        if (asistentessesionvirtual != null && asistentessesionvirtual.Rows.Count > 0)
        {
            count30 = asistentessesionvirtual.Rows.Count;
            meta30 = ((double)count30 / (double)total30) * 100;
            meta30 = Math.Round(meta30, 2);
            if (meta30 > 100)
            {
                meta30 = 100;
            }

            pesoAct30 = ((double)count30 / (double)total30) * peso30;
            pesoAct30 = Math.Round(pesoAct30, 4);
            if (pesoAct30 > peso30)
            {
                pesoAct30 = peso30;
            }
            pesototal = pesototal + pesoAct30;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 1/formación virtual (4 horas)</td>";
        //ca += "<td class='center'>" + total30 + "</td>";
        //ca += "<td class='center'>" + count30 + "</td>";
        //ca += "<td class='center'>" + meta30 + "%</td>";
        //ca += "<td class='center'>" + pesoAct30 + " de " + peso30 + "</td>";
        //ca += "</tr>";

        // Sesiones de formación evaluadas y subidas a la plataforma de Ciclón
        double meta31 = 0;
        int count31 = 0;
        DataTable sesionesformacionsubidas = est.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "1", "1");
        int total31 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso31 = 0.008791209;
        double pesoAct31 = 0;
        if (sesionesformacionsubidas != null && sesionesformacionsubidas.Rows.Count > 0)
        {
            count31 = sesionesformacionsubidas.Rows.Count;
            meta31 = ((double)count31 / (double)total31) * 100;
            meta31 = Math.Round(meta31, 2);
            if (meta31 > 100)
            {
                meta31 = 100;
            }

            pesoAct31 = ((double)count31 / (double)total31) * peso31;
            pesoAct31 = Math.Round(pesoAct31, 4);
            if (pesoAct31 > peso31)
            {
                pesoAct31 = peso31;
            }
            pesototal = pesototal + pesoAct31;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Sesiones de formación No. 1 evaluadas y subidas a la plataforma de Ciclón</td>";
        //ca += "<td class='center'>" + total31 + "</td>";
        //ca += "<td class='center'>" + count31 + "</td>";
        //ca += "<td class='center'>" + meta31 + "%</td>";
        //ca += "<td class='center'>" + pesoAct31 + " de " + peso31 + "</td>";
        //ca += "</tr>";

        // Proyectos de investigación de maestros y maestras con avance en su elaboración
        double meta32 = 0;
        int count32 = 0;
        DataTable proyectosinvestigacionmaestros = est.proyectosinvestigacionmaestros(coddepartamento, codmuncipio, codinstitucion, codsede);
        int total32 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso32 = 0.008791209;
        double pesoAct32 = 0;
        if (proyectosinvestigacionmaestros != null && proyectosinvestigacionmaestros.Rows.Count > 0)
        {
            count32 = proyectosinvestigacionmaestros.Rows.Count;
            meta32 = ((double)count32 / (double)total32) * 100;
            meta32 = Math.Round(meta32, 2);
            if (meta32 > 100)
            {
                meta32 = 100;
            }

            pesoAct32 = ((double)count32 / (double)total32) * peso32;
            pesoAct32 = Math.Round(pesoAct32, 4);
            if (pesoAct32 > peso32)
            {
                pesoAct32 = peso32;
            }
            pesototal = pesototal + pesoAct32;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Proyectos de investigación de maestros y maestras con avance en su elaboración</td>";
        //ca += "<td class='center'>" + total32 + "</td>";
        //ca += "<td class='center'>" + count32 + "</td>";
        //ca += "<td class='center'>" + meta32 + "%</td>";
        //ca += "<td class='center'>" + pesoAct32 + " de " + peso32 + "</td>";
        //ca += "</tr>";



        // Sesiones de formación No. 2 realizadas 
        double meta5 = 0;
        int count5 = 0;
        DataTable sesionformacionMaestrosS2 = est.sesionformacionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "3", "2");
        int total5 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso5 = 0.008791209;
        double pesoAct5 = 0;
        if (sesionformacionMaestrosS2 != null && sesionformacionMaestrosS2.Rows.Count > 0)
        {
            count5 = sesionformacionMaestrosS2.Rows.Count;
            meta5 = ((double)count5 / (double)total5) * 100;
            meta5 = Math.Round(meta5, 2);
            if (meta5 > 100)
            {
                meta5 = 100;
            }

            pesoAct5 = ((double)count5 / (double)total5) * peso5;
            pesoAct5 = Math.Round(pesoAct5, 4);
            if (pesoAct5 > peso5)
            {
                pesoAct5 = peso5;
            }
            pesototal = pesototal + pesoAct5;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Sesiones de formación No. 2 realizadas</td>";
        //ca += "<td class='center'>" + total5 + "</td>";
        //ca += "<td class='center'>" + count5 + "</td>";
        //ca += "<td class='center'>" + meta5 + "%</td>";
        //ca += "<td class='center'>" + pesoAct5 + " de " + peso5 + "</td>";
        //ca += "</tr>";



        // Asistentes a la sesión de formación No. 2/jornada de actualización No. 3 (5 horas)
        double meta6 = 0;
        int count6 = 0;
        DataTable asistentesSesionMaestrosS2 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "3", "2", "3");
        int total6 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso6 = 0.008791209;
        double pesoAct6 = 0;
        if (asistentesSesionMaestrosS2 != null && asistentesSesionMaestrosS2.Rows.Count > 0)
        {
            count6 = asistentesSesionMaestrosS2.Rows.Count;
            meta6 = ((double)count6 / (double)total6) * 100;
            meta6 = Math.Round(meta6, 2);
            if (meta6 > 100)
            {
                meta6 = 100;
            }

            pesoAct6 = ((double)count6 / (double)total6) * peso6;
            pesoAct6 = Math.Round(pesoAct6, 4);
            if (pesoAct6 > peso6)
            {
                pesoAct6 = peso6;
            }
            pesototal = pesototal + pesoAct6;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td>Asistentes a la sesión de formación No. 2/jornada de actualización No. 3 (5 horas)</td>";
        //ca += "<td class='center'>" + total6 + "</td>";
        //ca += "<td class='center'>" + count6 + "</td>";
        //ca += "<td class='center'>" + meta6 + "%</td>";
        //ca += "<td class='center'>" + pesoAct6 + " de " + peso6 + "</td>";
        //ca += "</tr>";



        // Asistentes a la sesión de formación No. 2/jornada de producción No. 4 (4 horas)
        double meta7 = 0;
        int count7 = 0;
        DataTable asistentesSesionMaestrosS1j4 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "3", "2", "4");
        int total7 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso7 = 0.008791209;
        double pesoAct7 = 0;
        if (asistentesSesionMaestrosS1j4 != null && asistentesSesionMaestrosS1j4.Rows.Count > 0)
        {
            count7 = asistentesSesionMaestrosS1j4.Rows.Count;
            meta7 = ((double)count7 / (double)total7) * 100;
            meta7 = Math.Round(meta7, 2);
            if (meta7 > 100)
            {
                meta7 = 100;
            }

            pesoAct7 = ((double)count7 / (double)total7) * peso7;
            pesoAct7 = Math.Round(pesoAct7, 4);
            if (pesoAct7 > peso7)
            {
                pesoAct7 = peso7;
            }
            pesototal = pesototal + pesoAct7;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 2/jornada de producción No. 4 (4 horas)</td>";
        //ca += "<td class='center'>" + total7 + "</td>";
        //ca += "<td class='center'>" + count7 + "</td>";
        //ca += "<td class='center'>" + meta7 + "%</td>";
        //ca += "<td class='center'>" + pesoAct7 + " de " + peso7 + "</td>";
        //ca += "</tr>";

        //---------------------------------------------

        // Asistentes a la sesión de formación No. 2/ autoformación (2 horas)
        double meta33 = 0;
        int count33 = 0;
        DataTable asistentessesionformacionAutos2 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "3", "2", "4");
        int total33 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso33 = 0.008791209;
        double pesoAct33 = 0;
        if (asistentessesionformacionAutos2 != null && asistentessesionformacionAutos2.Rows.Count > 0)
        {
            count33 = asistentessesionformacionAutos2.Rows.Count;
            meta33 = ((double)count33 / (double)total33) * 100;
            meta33 = Math.Round(meta33, 2);
            if (meta33 > 100)
            {
                meta33 = 100;
            }

            pesoAct33 = ((double)count33 / (double)total33) * peso33;
            pesoAct33 = Math.Round(pesoAct33, 4);
            if (pesoAct33 > peso33)
            {
                pesoAct33 = peso33;
            }
            pesototal = pesototal + pesoAct33;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 2/ autoformación (2 horas)</td>";
        //ca += "<td class='center'>" + total33 + "</td>";
        //ca += "<td class='center'>" + count33 + "</td>";
        //ca += "<td class='center'>" + meta33 + "%</td>";
        //ca += "<td class='center'>" + pesoAct33 + " de " + peso33 + "</td>";
        //ca += "</tr>";

        // Asistentes a la sesión de formación No. 2/formación virtual (4 horas)
        double meta34 = 0;
        int count34 = 0;
        DataTable asistentessesionvirtuals2 = est.asistentessesionvirtual(coddepartamento, codmuncipio, codinstitucion, codsede, "2");
        int total34 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso34 = 0.008791209;
        double pesoAct34 = 0;
        if (asistentessesionvirtuals2 != null && asistentessesionvirtuals2.Rows.Count > 0)
        {
            count34 = asistentessesionvirtuals2.Rows.Count;
            meta34 = ((double)count34 / (double)total34) * 100;
            meta34 = Math.Round(meta34, 2);
            if (meta34 > 100)
            {
                meta34 = 100;
            }

            pesoAct34 = ((double)count34 / (double)total34) * peso34;
            pesoAct34 = Math.Round(pesoAct34, 4);
            if (pesoAct34 > peso34)
            {
                pesoAct34 = peso34;
            }
            pesototal = pesototal + pesoAct34;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 2/formación virtual (4 horas)</td>";
        //ca += "<td class='center'>" + total34 + "</td>";
        //ca += "<td class='center'>" + count34 + "</td>";
        //ca += "<td class='center'>" + meta34 + "%</td>";
        //ca += "<td class='center'>" + pesoAct34 + " de " + peso34 + "</td>";
        //ca += "</tr>";

        // Sesiones de formación evaluadas y subidas a la plataforma de Ciclón N. 2
        double meta35 = 0;
        int count35 = 0;
        DataTable sesionesformacionsubidasS2 = est.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "3", "2");
        int total35 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso35 = 0.008791209;
        double pesoAct35 = 0;
        if (sesionesformacionsubidasS2 != null && sesionesformacionsubidasS2.Rows.Count > 0)
        {
            count35 = sesionesformacionsubidasS2.Rows.Count;
            meta35 = ((double)count35 / (double)total35) * 100;
            meta35 = Math.Round(meta35, 2);
            if (meta35 > 100)
            {
                meta35 = 100;
            }

            pesoAct35 = ((double)count35 / (double)total35) * peso35;
            pesoAct35 = Math.Round(pesoAct35, 4);
            if (pesoAct35 > peso35)
            {
                pesoAct35 = peso35;
            }
            pesototal = pesototal + pesoAct35;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Sesiones de formación No. 2 evaluadas y subidas a la plataforma de Ciclón </td>";
        //ca += "<td class='center'>" + total35 + "</td>";
        //ca += "<td class='center'>" + count35 + "</td>";
        //ca += "<td class='center'>" + meta35 + "%</td>";
        //ca += "<td class='center'>" + pesoAct35 + " de " + peso35 + "</td>";
        //ca += "</tr>";

        // Proyectos de investigación de maestros y maestras con avance en su elaboración
        double meta36 = 0;
        int count36 = 0;
        DataTable proyectosinvestigacionmaestross2 = est.proyectosinvestigacionmaestros(coddepartamento, codmuncipio, codinstitucion, codsede);
        int total36 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso36 = 0.008791209;
        double pesoAct36 = 0;
        if (proyectosinvestigacionmaestross2 != null && proyectosinvestigacionmaestross2.Rows.Count > 0)
        {
            count36 = proyectosinvestigacionmaestross2.Rows.Count;
            meta36 = ((double)count36 / (double)total36) * 100;
            meta36 = Math.Round(meta36, 2);
            if (meta36 > 100)
            {
                meta36 = 100;
            }

            pesoAct36 = ((double)count36 / (double)total36) * peso36;
            pesoAct36 = Math.Round(pesoAct36, 4);
            if (pesoAct36 > peso36)
            {
                pesoAct36 = peso36;
            }
            pesototal = pesototal + pesoAct36;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Proyectos de investigación de maestros y maestras con avance en su elaboración</td>";
        //ca += "<td class='center'>" + total36 + "</td>";
        //ca += "<td class='center'>" + count36 + "</td>";
        //ca += "<td class='center'>" + meta36 + "%</td>";
        //ca += "<td class='center'>" + pesoAct36 + " de " + peso36 + "</td>";
        //ca += "</tr>";
        //----------------------------------------------




        // Sesiones de formación No. 3 realizadas 
        double meta8 = 0;
        int count8 = 0;
        DataTable sesionformacionMaestrosS3 = est.sesionformacionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "3");
        int total8 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso8 = 0.008791209;
        double pesoAct8 = 0;
        if (sesionformacionMaestrosS3 != null && sesionformacionMaestrosS3.Rows.Count > 0)
        {
            count8 = sesionformacionMaestrosS3.Rows.Count;
            meta8 = ((double)count8 / (double)total8) * 100;
            meta8 = Math.Round(meta8, 2);
            if (meta8 > 100)
            {
                meta8 = 100;
            }

            pesoAct8 = ((double)count8 / (double)total8) * peso8;
            pesoAct8 = Math.Round(pesoAct8, 4);
            if (pesoAct8 > peso8)
            {
                pesoAct8 = peso8;
            }
            pesototal = pesototal + pesoAct8;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Sesiones de formación No. 3 realizadas</td>";
        //ca += "<td class='center'>" + total8 + "</td>";
        //ca += "<td class='center'>" + count8 + "</td>";
        //ca += "<td class='center'>" + meta8 + "%</td>";
        //ca += "<td class='center'>" + pesoAct8 + " de " + peso8 + "</td>";
        //ca += "</tr>";



        // Asistentes a la sesión de formación No. 3/jornada de actualización No. 5 (5 horas)
        double meta9 = 0;
        int count9 = 0;
        DataTable asistentesSesionMaestrosS3 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "3", "5");
        int total9 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso9 = 0.008791209;
        double pesoAct9 = 0;
        if (asistentesSesionMaestrosS3 != null && asistentesSesionMaestrosS3.Rows.Count > 0)
        {
            count9 = asistentesSesionMaestrosS3.Rows.Count;
            meta9 = ((double)count9 / (double)total9) * 100;
            meta9 = Math.Round(meta9, 2);
            if (meta9 > 100)
            {
                meta9 = 100;
            }

            pesoAct9 = ((double)count9 / (double)total9) * peso9;
            pesoAct9 = Math.Round(pesoAct9, 4);
            if (pesoAct9 > peso9)
            {
                pesoAct9 = peso9;
            }
            pesototal = pesototal + pesoAct9;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td>Asistentes a la sesión de formación No. 3/jornada de actualización No. 5 (5 horas)</td>";
        //ca += "<td class='center'>" + total9 + "</td>";
        //ca += "<td class='center'>" + count9 + "</td>";
        //ca += "<td class='center'>" + meta9 + "%</td>";
        //ca += "<td class='center'>" + pesoAct9 + " de " + peso9 + "</td>";
        //ca += "</tr>";



        // Asistentes a la sesión de formación No. 3/jornada de producción No. 6 (4 horas)
        double meta10 = 0;
        int count10 = 0;
        DataTable asistentesSesionMaestrosS1j6 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "3", "6");
        int total10 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso10 = 0.008791209;
        double pesoAct10 = 0;
        if (asistentesSesionMaestrosS1j6 != null && asistentesSesionMaestrosS1j6.Rows.Count > 0)
        {
            count10 = asistentesSesionMaestrosS1j6.Rows.Count;
            meta10 = ((double)count10 / (double)total10) * 100;
            meta10 = Math.Round(meta10, 2);
            if (meta10 > 100)
            {
                meta10 = 100;
            }

            pesoAct10 = ((double)count10 / (double)total10) * peso10;
            pesoAct10 = Math.Round(pesoAct10, 4);
            if (pesoAct10 > peso10)
            {
                pesoAct10 = peso10;
            }
            pesototal = pesototal + pesoAct10;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 3/jornada de producción No. 6 (4 horas)</td>";
        //ca += "<td class='center'>" + total10 + "</td>";
        //ca += "<td class='center'>" + count10 + "</td>";
        //ca += "<td class='center'>" + meta10 + "%</td>";
        //ca += "<td class='center'>" + pesoAct10 + " de " + peso10 + "</td>";
        //ca += "</tr>";

        //---------------------------------------------
        // Asistentes a la sesión de formación No. 3/ autoformación (2 horas)
        double meta37 = 0;
        int count37 = 0;
        DataTable asistentessesionformacionAutos3 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "3", "6");
        int total37 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso37 = 0.008791209;
        double pesoAct37 = 0;
        if (asistentessesionformacionAutos3 != null && asistentessesionformacionAutos3.Rows.Count > 0)
        {
            count37 = asistentessesionformacionAutos3.Rows.Count;
            meta37 = ((double)count37 / (double)total37) * 100;
            meta37 = Math.Round(meta37, 2);
            if (meta37 > 100)
            {
                meta37 = 100;
            }

            pesoAct37 = ((double)count37 / (double)total37) * peso37;
            pesoAct37 = Math.Round(pesoAct37, 4);
            if (pesoAct37 > peso37)
            {
                pesoAct37 = peso37;
            }
            pesototal = pesototal + pesoAct37;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 3/ autoformación (2 horas)</td>";
        //ca += "<td class='center'>" + total37 + "</td>";
        //ca += "<td class='center'>" + count37 + "</td>";
        //ca += "<td class='center'>" + meta37 + "%</td>";
        //ca += "<td class='center'>" + pesoAct37 + " de " + peso37 + "</td>";
        //ca += "</tr>";

        // Asistentes a la sesión de formación No. 3/formación virtual (4 horas)
        double meta38 = 0;
        int count38 = 0;
        DataTable asistentessesionvirtuals3 = est.asistentessesionvirtual(coddepartamento, codmuncipio, codinstitucion, codsede, "3");
        int total38 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso38 = 0.008791209;
        double pesoAct38 = 0;
        if (asistentessesionvirtuals3 != null && asistentessesionvirtuals3.Rows.Count > 0)
        {
            count38 = asistentessesionvirtuals3.Rows.Count;
            meta38 = ((double)count38 / (double)total38) * 100;
            meta38 = Math.Round(meta38, 2);
            if (meta38 > 100)
            {
                meta38 = 100;
            }

            pesoAct38 = ((double)count38 / (double)total38) * peso38;
            pesoAct38 = Math.Round(pesoAct38, 4);
            if (pesoAct38 > peso38)
            {
                pesoAct38 = peso38;
            }
            pesototal = pesototal + pesoAct38;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 3/formación virtual (4 horas)</td>";
        //ca += "<td class='center'>" + total38 + "</td>";
        //ca += "<td class='center'>" + count38 + "</td>";
        //ca += "<td class='center'>" + meta38 + "%</td>";
        //ca += "<td class='center'>" + pesoAct38 + " de " + peso38 + "</td>";
        //ca += "</tr>";

        // Sesiones de formación evaluadas y subidas a la plataforma de Ciclón No. 3
        double meta39 = 0;
        int count39 = 0;
        DataTable sesionesformacionsubidasS3 = est.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "3");
        int total39 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso39 = 0.008791209;
        double pesoAct39 = 0;
        if (sesionesformacionsubidasS3 != null && sesionesformacionsubidasS3.Rows.Count > 0)
        {
            count39 = sesionesformacionsubidasS3.Rows.Count;
            meta39 = ((double)count39 / (double)total39) * 100;
            meta39 = Math.Round(meta39, 2);
            if (meta39 > 100)
            {
                meta39 = 100;
            }

            pesoAct39 = ((double)count39 / (double)total39) * peso39;
            pesoAct39 = Math.Round(pesoAct39, 4);
            if (pesoAct39 > peso39)
            {
                pesoAct39 = peso39;
            }
            pesototal = pesototal + pesoAct39;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Sesiones de formación No. 3 evaluadas y subidas a la plataforma de Ciclón </td>";
        //ca += "<td class='center'>" + total39 + "</td>";
        //ca += "<td class='center'>" + count39 + "</td>";
        //ca += "<td class='center'>" + meta39 + "%</td>";
        //ca += "<td class='center'>" + pesoAct39 + " de " + peso39 + "</td>";
        //ca += "</tr>";

        // Proyectos de investigación de maestros y maestras con avance en su elaboración
        double meta40 = 0;
        int count40 = 0;
        DataTable proyectosinvestigacionmaestross3 = est.proyectosinvestigacionmaestros(coddepartamento, codmuncipio, codinstitucion, codsede);
        int total40 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso40 = 0.008791209;
        double pesoAct40 = 0;
        if (proyectosinvestigacionmaestross3 != null && proyectosinvestigacionmaestross3.Rows.Count > 0)
        {
            count40 = proyectosinvestigacionmaestross3.Rows.Count;
            meta40 = ((double)count40 / (double)total40) * 100;
            meta40 = Math.Round(meta40, 2);
            if (meta40 > 100)
            {
                meta40 = 100;
            }

            pesoAct40 = ((double)count40 / (double)total40) * peso40;
            pesoAct40 = Math.Round(pesoAct40, 4);
            if (pesoAct40 > peso40)
            {
                pesoAct40 = peso40;
            }
            pesototal = pesototal + pesoAct40;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Proyectos de investigación de maestros y maestras con avance en su elaboración</td>";
        //ca += "<td class='center'>" + total40 + "</td>";
        //ca += "<td class='center'>" + count40 + "</td>";
        //ca += "<td class='center'>" + meta40 + "%</td>";
        //ca += "<td class='center'>" + pesoAct40 + " de " + peso40 + "</td>";
        //ca += "</tr>";
        //----------------------------------------------






        // Sesiones de formación No. 4 realizadas 
        double meta11 = 0;
        int count11 = 0;
        DataTable sesionformacionMaestrosS4 = est.sesionformacionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "4");
        int total11 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso11 = 0.008791209;
        double pesoAct11 = 0;
        if (sesionformacionMaestrosS4 != null && sesionformacionMaestrosS4.Rows.Count > 0)
        {
            count11 = sesionformacionMaestrosS4.Rows.Count;
            meta11 = ((double)count11 / (double)total11) * 100;
            meta11 = Math.Round(meta11, 2);
            if (meta11 > 100)
            {
                meta11 = 100;
            }

            pesoAct11 = ((double)count11 / (double)total11) * peso11;
            pesoAct11 = Math.Round(pesoAct11, 4);
            if (pesoAct11 > peso11)
            {
                pesoAct11 = peso11;
            }
            pesototal = pesototal + pesoAct11;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Sesiones de formación No. 4 realizadas </td>";
        //ca += "<td class='center'>" + total11 + "</td>";
        //ca += "<td class='center'>" + count11 + "</td>";
        //ca += "<td class='center'>" + meta11 + "%</td>";
        //ca += "<td class='center'>" + pesoAct11 + " de " + peso11 + "</td>";
        //ca += "</tr>";



        //Asistentes a la sesión de formación No. 4/jornada de actualización No. 7 (5 horas)
        double meta12 = 0;
        int count12 = 0;
        DataTable asistentesSesionMaestrosS4 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "4", "7");
        int total12 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso12 = 0.008791209;
        double pesoAct12 = 0;
        if (asistentesSesionMaestrosS4 != null && asistentesSesionMaestrosS4.Rows.Count > 0)
        {
            count12 = asistentesSesionMaestrosS4.Rows.Count;
            meta12 = ((double)count12 / (double)total12) * 100;
            meta12 = Math.Round(meta12, 2);
            if (meta12 > 100)
            {
                meta12 = 100;
            }

            pesoAct12 = ((double)count12 / (double)total12) * peso12;
            pesoAct12 = Math.Round(pesoAct12, 4);
            if (pesoAct12 > peso12)
            {
                pesoAct12 = peso12;
            }
            pesototal = pesototal + pesoAct12;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 4/jornada de actualización No. 7 (5 horas)</td>";
        //ca += "<td class='center'>" + total12 + "</td>";
        //ca += "<td class='center'>" + count12 + "</td>";
        //ca += "<td class='center'>" + meta12 + "%</td>";
        //ca += "<td class='center'>" + pesoAct12 + " de " + peso12 + "</td>";
        //ca += "</tr>";



        // Asistentes a la sesión de formación No. 4/jornada de producción No. 8 (4 horas)
        double meta13 = 0;
        int count13 = 0;
        DataTable asistentesSesionMaestrosS4j8 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "4", "8");
        int total13 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso13 = 0.008791209;
        double pesoAct13 = 0;
        if (asistentesSesionMaestrosS4j8 != null && asistentesSesionMaestrosS4j8.Rows.Count > 0)
        {
            count13 = asistentesSesionMaestrosS4j8.Rows.Count;
            meta13 = ((double)count13 / (double)total13) * 100;
            meta13 = Math.Round(meta13, 2);
            if (meta13 > 100)
            {
                meta13 = 100;
            }

            pesoAct13 = ((double)count13 / (double)total13) * peso13;
            pesoAct13 = Math.Round(pesoAct13, 4);
            if (pesoAct13 > peso13)
            {
                pesoAct13 = peso13;
            }
            pesototal = pesototal + pesoAct13;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 4/jornada de producción No. 8 (4 horas)</td>";
        //ca += "<td class='center'>" + total13 + "</td>";
        //ca += "<td class='center'>" + count13 + "</td>";
        //ca += "<td class='center'>" + meta13 + "%</td>";
        //ca += "<td class='center'>" + pesoAct13 + " de " + peso13 + "</td>";
        //ca += "</tr>";




        //---------------------------------------------
        // Asistentes a la sesión de formación No. 4/ autoformación (2 horas)
        double meta41 = 0;
        int count41 = 0;
        DataTable asistentessesionformacionAutos4 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "4", "8");
        int total41 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso41 = 0.008791209;
        double pesoAct41 = 0;
        if (asistentessesionformacionAutos4 != null && asistentessesionformacionAutos4.Rows.Count > 0)
        {
            count41 = asistentessesionformacionAutos4.Rows.Count;
            meta41 = ((double)count41 / (double)total41) * 100;
            meta41 = Math.Round(meta41, 2);
            if (meta41 > 100)
            {
                meta41 = 100;
            }

            pesoAct41 = ((double)count41 / (double)total41) * peso41;
            pesoAct41 = Math.Round(pesoAct41, 4);
            if (pesoAct41 > peso41)
            {
                pesoAct41 = peso41;
            }
            pesototal = pesototal + pesoAct41;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 4/ autoformación (2 horas)</td>";
        //ca += "<td class='center'>" + total41 + "</td>";
        //ca += "<td class='center'>" + count41 + "</td>";
        //ca += "<td class='center'>" + meta41 + "%</td>";
        //ca += "<td class='center'>" + pesoAct41 + " de " + peso41 + "</td>";
        //ca += "</tr>";

        // Asistentes a la sesión de formación No. 4/formación virtual (4 horas)
        double meta42 = 0;
        int count42 = 0;
        DataTable asistentessesionvirtuals4 = est.asistentessesionvirtual(coddepartamento, codmuncipio, codinstitucion, codsede, "4");
        int total42 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso42 = 0.008791209;
        double pesoAct42 = 0;
        if (asistentessesionvirtuals4 != null && asistentessesionvirtuals4.Rows.Count > 0)
        {
            count42 = asistentessesionvirtuals4.Rows.Count;
            meta42 = ((double)count42 / (double)total42) * 100;
            meta42 = Math.Round(meta42, 2);
            if (meta42 > 100)
            {
                meta42 = 100;
            }

            pesoAct42 = ((double)count42 / (double)total42) * peso42;
            pesoAct42 = Math.Round(pesoAct42, 4);
            if (pesoAct42 > peso42)
            {
                pesoAct42 = peso42;
            }
            pesototal = pesototal + pesoAct42;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 4/formación virtual (4 horas)</td>";
        //ca += "<td class='center'>" + total42 + "</td>";
        //ca += "<td class='center'>" + count42 + "</td>";
        //ca += "<td class='center'>" + meta42 + "%</td>";
        //ca += "<td class='center'>" + pesoAct42 + " de " + peso42 + "</td>";
        //ca += "</tr>";

        // Sesiones de formación  No. 4 evaluadas y subidas a la plataforma de Ciclón
        double meta43 = 0;
        int count43 = 0;
        DataTable sesionesformacionsubidasS4 = est.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "4");
        int total43 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso43 = 0.008791209;
        double pesoAct43 = 0;
        if (sesionesformacionsubidasS4 != null && sesionesformacionsubidasS4.Rows.Count > 0)
        {
            count43 = sesionesformacionsubidasS4.Rows.Count;
            meta43 = ((double)count43 / (double)total43) * 100;
            meta43 = Math.Round(meta43, 2);
            if (meta43 > 100)
            {
                meta43 = 100;
            }

            pesoAct43 = ((double)count43 / (double)total43) * peso43;
            pesoAct43 = Math.Round(pesoAct43, 4);
            if (pesoAct43 > peso43)
            {
                pesoAct43 = peso43;
            }
            pesototal = pesototal + pesoAct43;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Sesiones de formación No. 4 evaluadas y subidas a la plataforma de Ciclón </td>";
        //ca += "<td class='center'>" + total43 + "</td>";
        //ca += "<td class='center'>" + count43 + "</td>";
        //ca += "<td class='center'>" + meta43 + "%</td>";
        //ca += "<td class='center'>" + pesoAct43 + " de " + peso43 + "</td>";
        //ca += "</tr>";

        // Proyectos de investigación de maestros y maestras con avance en su elaboración
        double meta44 = 0;
        int count44 = 0;
        DataTable proyectosinvestigacionmaestross4 = est.proyectosinvestigacionmaestros(coddepartamento, codmuncipio, codinstitucion, codsede);
        int total44 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso44 = 0.008791209;
        double pesoAct44 = 0;
        if (proyectosinvestigacionmaestross4 != null && proyectosinvestigacionmaestross4.Rows.Count > 0)
        {
            count44 = proyectosinvestigacionmaestross4.Rows.Count;
            meta44 = ((double)count44 / (double)total44) * 100;
            meta44 = Math.Round(meta44, 2);
            if (meta44 > 100)
            {
                meta44 = 100;
            }

            pesoAct44 = ((double)count44 / (double)total44) * peso44;
            pesoAct44 = Math.Round(pesoAct44, 4);
            if (pesoAct44 > peso44)
            {
                pesoAct44 = peso44;
            }
            pesototal = pesototal + pesoAct44;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Proyectos de investigación de maestros y maestras con avance en su elaboración</td>";
        //ca += "<td class='center'>" + total44 + "</td>";
        //ca += "<td class='center'>" + count44 + "</td>";
        //ca += "<td class='center'>" + meta44 + "%</td>";
        //ca += "<td class='center'>" + pesoAct44 + " de " + peso44 + "</td>";
        //ca += "</tr>";
        //----------------------------------------------





        // Sesiones de formación No. 5 realizadas 
        double meta14 = 0;
        int count14 = 0;
        DataTable sesionformacionMaestrosS5 = est.sesionformacionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "5");
        int total14 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso14 = 0.008791209;
        double pesoAct14 = 0;
        if (sesionformacionMaestrosS5 != null && sesionformacionMaestrosS5.Rows.Count > 0)
        {
            count14 = sesionformacionMaestrosS5.Rows.Count;
            meta14 = ((double)count14 / (double)total14) * 100;
            meta14 = Math.Round(meta14, 2);
            if (meta14 > 100)
            {
                meta14 = 100;
            }

            pesoAct14 = ((double)count14 / (double)total14) * peso14;
            pesoAct14 = Math.Round(pesoAct14, 4);
            if (pesoAct14 > peso14)
            {
                pesoAct14 = peso14;
            }
            pesototal = pesototal + pesoAct14;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Sesiones de formación No. 5 realizadas </td>";
        //ca += "<td class='center'>" + total14 + "</td>";
        //ca += "<td class='center'>" + count14 + "</td>";
        //ca += "<td class='center'>" + meta14 + "%</td>";
        //ca += "<td class='center'>" + pesoAct14 + " de " + peso14 + "</td>";
        //ca += "</tr>";



        //Asistentes a la sesión de formación No. 5/jornada de actualización No. 9 (5 horas)
        double meta15 = 0;
        int count15 = 0;
        DataTable asistentesSesionMaestrosS5 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "5", "9");
        int total15 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso15 = 0.008791209;
        double pesoAct15 = 0;
        if (asistentesSesionMaestrosS5 != null && asistentesSesionMaestrosS5.Rows.Count > 0)
        {
            count15 = asistentesSesionMaestrosS5.Rows.Count;
            meta15 = ((double)count15 / (double)total15) * 100;
            meta15 = Math.Round(meta15, 2);
            if (meta15 > 100)
            {
                meta15 = 100;
            }

            pesoAct15 = ((double)count15 / (double)total15) * peso15;
            pesoAct15 = Math.Round(pesoAct15, 4);
            if (pesoAct15 > peso15)
            {
                pesoAct15 = peso15;
            }
            pesototal = pesototal + pesoAct15;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 5/jornada de actualización No. 9 (5 horas)</td>";
        //ca += "<td class='center'>" + total15 + "</td>";
        //ca += "<td class='center'>" + count15 + "</td>";
        //ca += "<td class='center'>" + meta15 + "%</td>";
        //ca += "<td class='center'>" + pesoAct15 + " de " + peso15 + "</td>";
        //ca += "</tr>";



        // Asistentes a la sesión de formación No. 5/jornada de producción No. 10 (4 horas)
        double meta16 = 0;
        int count16 = 0;
        DataTable asistentesSesionMaestrosS5j10 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "5", "10");
        int total16 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso16 = 0.008791209;
        double pesoAct16 = 0;
        if (asistentesSesionMaestrosS5j10 != null && asistentesSesionMaestrosS5j10.Rows.Count > 0)
        {
            count16 = asistentesSesionMaestrosS5j10.Rows.Count;
            meta16 = ((double)count16 / (double)total16) * 100;
            meta16 = Math.Round(meta16, 2);
            if (meta16 > 100)
            {
                meta16 = 100;
            }

            pesoAct16 = ((double)count16 / (double)total16) * peso16;
            pesoAct16 = Math.Round(pesoAct16, 4);
            if (pesoAct16 > peso16)
            {
                pesoAct16 = peso16;
            }
            pesototal = pesototal + pesoAct16;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 5/jornada de producción No. 10 (4 horas)</td>";
        //ca += "<td class='center'>" + total16 + "</td>";
        //ca += "<td class='center'>" + count16 + "</td>";
        //ca += "<td class='center'>" + meta16 + "%</td>";
        //ca += "<td class='center'>" + pesoAct16 + " de " + peso16 + "</td>";
        //ca += "</tr>";



        //---------------------------------------------
        // Asistentes a la sesión de formación No. 5/ autoformación (2 horas)
        double meta45 = 0;
        int count45 = 0;
        DataTable asistentessesionformacionAutos5 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "5", "10");
        int total45 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso45 = 0.008791209;
        double pesoAct45 = 0;
        if (asistentessesionformacionAutos5 != null && asistentessesionformacionAutos5.Rows.Count > 0)
        {
            count45 = asistentessesionformacionAutos5.Rows.Count;
            meta45 = ((double)count45 / (double)total45) * 100;
            meta45 = Math.Round(meta45, 2);
            if (meta45 > 100)
            {
                meta45 = 100;
            }

            pesoAct45 = ((double)count45 / (double)total45) * peso45;
            pesoAct45 = Math.Round(pesoAct45, 4);
            if (pesoAct45 > peso45)
            {
                pesoAct45 = peso45;
            }
            pesototal = pesototal + pesoAct45;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 5/ autoformación (2 horas)</td>";
        //ca += "<td class='center'>" + total45 + "</td>";
        //ca += "<td class='center'>" + count45 + "</td>";
        //ca += "<td class='center'>" + meta45 + "%</td>";
        //ca += "<td class='center'>" + pesoAct45 + " de " + peso45 + "</td>";
        //ca += "</tr>";

        // Asistentes a la sesión de formación No. 5/formación virtual (4 horas)
        double meta46 = 0;
        int count46 = 0;
        DataTable asistentessesionvirtuals5 = est.asistentessesionvirtual(coddepartamento, codmuncipio, codinstitucion, codsede, "5");
        int total46 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso46 = 0.008791209;
        double pesoAct46 = 0;
        if (asistentessesionvirtuals5 != null && asistentessesionvirtuals5.Rows.Count > 0)
        {
            count46 = asistentessesionvirtuals5.Rows.Count;
            meta46 = ((double)count46 / (double)total46) * 100;
            meta46 = Math.Round(meta46, 2);
            if (meta46 > 100)
            {
                meta46 = 100;
            }

            pesoAct46 = ((double)count46 / (double)total46) * peso46;
            pesoAct46 = Math.Round(pesoAct46, 4);
            if (pesoAct46 > peso46)
            {
                pesoAct46 = peso46;
            }
            pesototal = pesototal + pesoAct46;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 5/formación virtual (4 horas)</td>";
        //ca += "<td class='center'>" + total46 + "</td>";
        //ca += "<td class='center'>" + count46 + "</td>";
        //ca += "<td class='center'>" + meta46 + "%</td>";
        //ca += "<td class='center'>" + pesoAct46 + " de " + peso46 + "</td>";
        //ca += "</tr>";

        // Sesiones de formación  No. 5 evaluadas y subidas a la plataforma de Ciclón
        double meta47 = 0;
        int count47 = 0;
        DataTable sesionesformacionsubidasS5 = est.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "5");
        int total47 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso47 = 0.008791209;
        double pesoAct47 = 0;
        if (sesionesformacionsubidasS5 != null && sesionesformacionsubidasS5.Rows.Count > 0)
        {
            count47 = sesionesformacionsubidasS5.Rows.Count;
            meta47 = ((double)count47 / (double)total47) * 100;
            meta47 = Math.Round(meta47, 2);
            if (meta47 > 100)
            {
                meta47 = 100;
            }

            pesoAct47 = ((double)count47 / (double)total47) * peso47;
            pesoAct47 = Math.Round(pesoAct47, 4);
            if (pesoAct47 > peso47)
            {
                pesoAct47 = peso47;
            }
            pesototal = pesototal + pesoAct47;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Sesiones de formación No. 5 evaluadas y subidas a la plataforma de Ciclón </td>";
        //ca += "<td class='center'>" + total47 + "</td>";
        //ca += "<td class='center'>" + count47 + "</td>";
        //ca += "<td class='center'>" + meta47 + "%</td>";
        //ca += "<td class='center'>" + pesoAct47 + " de " + peso47 + "</td>";
        //ca += "</tr>";

        // Proyectos de investigación de maestros y maestras con avance en su elaboración
        double meta48 = 0;
        int count48 = 0;
        DataTable proyectosinvestigacionmaestross5 = est.proyectosinvestigacionmaestros(coddepartamento, codmuncipio, codinstitucion, codsede);
        int total48 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso48 = 0.008791209;
        double pesoAct48 = 0;
        if (proyectosinvestigacionmaestross5 != null && proyectosinvestigacionmaestross5.Rows.Count > 0)
        {
            count48 = proyectosinvestigacionmaestross5.Rows.Count;
            meta48 = ((double)count48 / (double)total48) * 100;
            meta48 = Math.Round(meta48, 2);
            if (meta48 > 100)
            {
                meta48 = 100;
            }

            pesoAct48 = ((double)count48 / (double)total48) * peso48;
            pesoAct48 = Math.Round(pesoAct48, 4);
            if (pesoAct48 > peso48)
            {
                pesoAct48 = peso48;
            }
            pesototal = pesototal + pesoAct48;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Proyectos de investigación de maestros y maestras con avance en su elaboración</td>";
        //ca += "<td class='center'>" + total48 + "</td>";
        //ca += "<td class='center'>" + count48 + "</td>";
        //ca += "<td class='center'>" + meta48 + "%</td>";
        //ca += "<td class='center'>" + pesoAct48 + " de " + peso48 + "</td>";
        //ca += "</tr>";
        //----------------------------------------------




        // Sesiones de formación No. 6 realizadas 
        double meta17 = 0;
        int count17 = 0;
        DataTable sesionformacionMaestrosS6 = est.sesionformacionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "6");
        int total17 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso17 = 0.008791209;
        double pesoAct17 = 0;
        if (sesionformacionMaestrosS6 != null && sesionformacionMaestrosS6.Rows.Count > 0)
        {
            count17 = sesionformacionMaestrosS6.Rows.Count;
            meta17 = ((double)count17 / (double)total17) * 100;
            meta17 = Math.Round(meta17, 2);
            if (meta17 > 100)
            {
                meta17 = 100;
            }

            pesoAct17 = ((double)count17 / (double)total17) * peso17;
            pesoAct17 = Math.Round(pesoAct17, 4);
            if (pesoAct17 > peso17)
            {
                pesoAct17 = peso17;
            }
            pesototal = pesototal + pesoAct17;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Sesiones de formación No. 6 realizadas </td>";
        //ca += "<td class='center'>" + total17 + "</td>";
        //ca += "<td class='center'>" + count17 + "</td>";
        //ca += "<td class='center'>" + meta17 + "%</td>";
        //ca += "<td class='center'>" + pesoAct17 + " de " + peso17 + "</td>";
        //ca += "</tr>";



        //Asistentes a la sesión de formación No. 6/jornada de actualización No. 11 (5 horas)
        double meta18 = 0;
        int count18 = 0;
        DataTable asistentesSesionMaestrosS6 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "6", "11");
        int total18 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso18 = 0.008791209;
        double pesoAct18 = 0;
        if (asistentesSesionMaestrosS6 != null && asistentesSesionMaestrosS6.Rows.Count > 0)
        {
            count18 = asistentesSesionMaestrosS6.Rows.Count;
            meta18 = ((double)count18 / (double)total18) * 100;
            meta18 = Math.Round(meta18, 2);
            if (meta18 > 100)
            {
                meta18 = 100;
            }

            pesoAct18 = ((double)count18 / (double)total18) * peso18;
            pesoAct18 = Math.Round(pesoAct18, 4);
            if (pesoAct18 > peso18)
            {
                pesoAct18 = peso18;
            }
            pesototal = pesototal + pesoAct18;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 6/jornada de actualización No. 11 (5 horas)</td>";
        //ca += "<td class='center'>" + total18 + "</td>";
        //ca += "<td class='center'>" + count18 + "</td>";
        //ca += "<td class='center'>" + meta18 + "%</td>";
        //ca += "<td class='center'>" + pesoAct18 + " de " + peso18 + "</td>";
        //ca += "</tr>";



        // Asistentes a la sesión de formación No. 6/jornada de producción No. 12 (4 horas)
        double meta19 = 0;
        int count19 = 0;
        DataTable asistentesSesionMaestrosS6j12 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "6", "12");
        int total19 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso19 = 0.008791209;
        double pesoAct19 = 0;
        if (asistentesSesionMaestrosS6j12 != null && asistentesSesionMaestrosS6j12.Rows.Count > 0)
        {
            count19 = asistentesSesionMaestrosS6j12.Rows.Count;
            meta19 = ((double)count19 / (double)total19) * 100;
            meta19 = Math.Round(meta19, 2);
            if (meta19 > 100)
            {
                meta19 = 100;
            }

            pesoAct19 = ((double)count19 / (double)total19) * peso19;
            pesoAct19 = Math.Round(pesoAct19, 4);
            if (pesoAct19 > peso19)
            {
                pesoAct19 = peso19;
            }
            pesototal = pesototal + pesoAct19;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 6/jornada de producción No. 12 (4 horas)</td>";
        //ca += "<td class='center'>" + total19 + "</td>";
        //ca += "<td class='center'>" + count19 + "</td>";
        //ca += "<td class='center'>" + meta19 + "%</td>";
        //ca += "<td class='center'>" + pesoAct19 + " de " + peso19 + "</td>";
        //ca += "</tr>";



        //---------------------------------------------
        // Asistentes a la sesión de formación No. 6/ autoformación (2 horas)
        double meta49 = 0;
        int count49 = 0;
        DataTable asistentessesionformacionAutos6 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "6", "12");
        int total49 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso49 = 0.008791209;
        double pesoAct49 = 0;
        if (asistentessesionformacionAutos6 != null && asistentessesionformacionAutos6.Rows.Count > 0)
        {
            count49 = asistentessesionformacionAutos6.Rows.Count;
            meta49 = ((double)count49 / (double)total49) * 100;
            meta49 = Math.Round(meta49, 2);
            if (meta49 > 100)
            {
                meta49 = 100;
            }

            pesoAct49 = ((double)count49 / (double)total49) * peso49;
            pesoAct49 = Math.Round(pesoAct49, 4);
            if (pesoAct49 > peso49)
            {
                pesoAct49 = peso49;
            }
            pesototal = pesototal + pesoAct49;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 6/ autoformación (2 horas)</td>";
        //ca += "<td class='center'>" + total49 + "</td>";
        //ca += "<td class='center'>" + count49 + "</td>";
        //ca += "<td class='center'>" + meta49 + "%</td>";
        //ca += "<td class='center'>" + pesoAct49 + " de " + peso49 + "</td>";
        //ca += "</tr>";

        // Asistentes a la sesión de formación No. 6/formación virtual (4 horas)
        double meta50 = 0;
        int count50 = 0;
        DataTable asistentessesionvirtuals6 = est.asistentessesionvirtual(coddepartamento, codmuncipio, codinstitucion, codsede, "6");
        int total50 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso50 = 0.008791209;
        double pesoAct50 = 0;
        if (asistentessesionvirtuals6 != null && asistentessesionvirtuals6.Rows.Count > 0)
        {
            count50 = asistentessesionvirtuals6.Rows.Count;
            meta50 = ((double)count50 / (double)total50) * 100;
            meta50 = Math.Round(meta50, 2);
            if (meta50 > 100)
            {
                meta50 = 100;
            }

            pesoAct50 = ((double)count50 / (double)total50) * peso50;
            pesoAct50 = Math.Round(pesoAct50, 4);
            if (pesoAct50 > peso50)
            {
                pesoAct50 = peso50;
            }
            pesototal = pesototal + pesoAct50;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 6/formación virtual (4 horas)</td>";
        //ca += "<td class='center'>" + total50 + "</td>";
        //ca += "<td class='center'>" + count50 + "</td>";
        //ca += "<td class='center'>" + meta50 + "%</td>";
        //ca += "<td class='center'>" + pesoAct50 + " de " + peso50 + "</td>";
        //ca += "</tr>";

        // Sesiones de formación  No. 6 evaluadas y subidas a la plataforma de Ciclón
        double meta51 = 0;
        int count51 = 0;
        DataTable sesionesformacionsubidasS6 = est.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "6");
        int total51 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso51 = 0.008791209;
        double pesoAct51 = 0;
        if (sesionesformacionsubidasS6 != null && sesionesformacionsubidasS6.Rows.Count > 0)
        {
            count51 = sesionesformacionsubidasS6.Rows.Count;
            meta51 = ((double)count51 / (double)total51) * 100;
            meta51 = Math.Round(meta51, 2);
            if (meta51 > 100)
            {
                meta51 = 100;
            }

            pesoAct51 = ((double)count51 / (double)total51) * peso51;
            pesoAct51 = Math.Round(pesoAct51, 4);
            if (pesoAct51 > peso51)
            {
                pesoAct51 = peso51;
            }
            pesototal = pesototal + pesoAct51;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Sesiones de formación No. 6 evaluadas y subidas a la plataforma de Ciclón </td>";
        //ca += "<td class='center'>" + total51 + "</td>";
        //ca += "<td class='center'>" + count51 + "</td>";
        //ca += "<td class='center'>" + meta51 + "%</td>";
        //ca += "<td class='center'>" + pesoAct51 + " de " + peso51 + "</td>";
        //ca += "</tr>";

        // Proyectos de investigación de maestros y maestras con avance en su elaboración
        double meta52 = 0;
        int count52 = 0;
        DataTable proyectosinvestigacionmaestross6 = est.proyectosinvestigacionmaestros(coddepartamento, codmuncipio, codinstitucion, codsede);
        int total52 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso52 = 0.008791209;
        double pesoAct52 = 0;
        if (proyectosinvestigacionmaestross6 != null && proyectosinvestigacionmaestross6.Rows.Count > 0)
        {
            count52 = proyectosinvestigacionmaestross6.Rows.Count;
            meta52 = ((double)count52 / (double)total52) * 100;
            meta52 = Math.Round(meta52, 2);
            if (meta52 > 100)
            {
                meta52 = 100;
            }

            pesoAct52 = ((double)count52 / (double)total52) * peso52;
            pesoAct52 = Math.Round(pesoAct52, 4);
            if (pesoAct52 > peso52)
            {
                pesoAct52 = peso52;
            }
            pesototal = pesototal + pesoAct52;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Proyectos de investigación de maestros y maestras con avance en su elaboración</td>";
        //ca += "<td class='center'>" + total52 + "</td>";
        //ca += "<td class='center'>" + count52 + "</td>";
        //ca += "<td class='center'>" + meta52 + "%</td>";
        //ca += "<td class='center'>" + pesoAct52 + " de " + peso52 + "</td>";
        //ca += "</tr>";
        //----------------------------------------------





        // Sesiones de formación No. 7 realizadas 
        double meta20 = 0;
        int count20 = 0;
        DataTable sesionformacionMaestrosS7 = est.sesionformacionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "5", "7");
        int total20 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso20 = 0.008791209;
        double pesoAct20 = 0;
        if (sesionformacionMaestrosS7 != null && sesionformacionMaestrosS7.Rows.Count > 0)
        {
            count20 = sesionformacionMaestrosS7.Rows.Count;
            meta20 = ((double)count20 / (double)total20) * 100;
            meta20 = Math.Round(meta20, 2);
            if (meta20 > 100)
            {
                meta20 = 100;
            }

            pesoAct20 = ((double)count20 / (double)total20) * peso20;
            pesoAct20 = Math.Round(pesoAct20, 4);
            if (pesoAct20 > peso20)
            {
                pesoAct20 = peso20;
            }
            pesototal = pesototal + pesoAct20;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Sesiones de formación No. 7 realizadas </td>";
        //ca += "<td class='center'>" + total20 + "</td>";
        //ca += "<td class='center'>" + count20 + "</td>";
        //ca += "<td class='center'>" + meta20 + "%</td>";
        //ca += "<td class='center'>" + pesoAct20 + " de " + peso20 + "</td>";
        //ca += "</tr>";



        //Asistentes a la sesión de formación No. 7/jornada de actualización No. 13 (5 horas)
        double meta21 = 0;
        int count21 = 0;
        DataTable asistentesSesionMaestrosS7 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "5", "7", "13");
        int total21 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso21 = 0.008791209;
        double pesoAct21 = 0;
        if (asistentesSesionMaestrosS7 != null && asistentesSesionMaestrosS7.Rows.Count > 0)
        {
            count21 = asistentesSesionMaestrosS7.Rows.Count;
            meta21 = ((double)count21 / (double)total21) * 100;
            meta21 = Math.Round(meta21, 2);
            if (meta21 > 100)
            {
                meta21 = 100;
            }

            pesoAct21 = ((double)count21 / (double)total21) * peso21;
            pesoAct21 = Math.Round(pesoAct21, 4);
            if (pesoAct21 > peso21)
            {
                pesoAct21 = peso21;
            }
            pesototal = pesototal + pesoAct21;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 7/jornada de actualización No. 13 (5 horas)</td>";
        //ca += "<td class='center'>" + total21 + "</td>";
        //ca += "<td class='center'>" + count21 + "</td>";
        //ca += "<td class='center'>" + meta21 + "%</td>";
        //ca += "<td class='center'>" + pesoAct21 + " de " + peso21 + "</td>";
        //ca += "</tr>";



        // Asistentes a la sesión de formación No. 7/jornada de producción No. 14 (4 horas)
        double meta22 = 0;
        int count22 = 0;
        DataTable asistentesSesionMaestrosS7j14 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "5", "7", "14");
        int total22 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso22 = 0.008791209;
        double pesoAct22 = 0;
        if (asistentesSesionMaestrosS7j14 != null && asistentesSesionMaestrosS7j14.Rows.Count > 0)
        {
            count22 = asistentesSesionMaestrosS7j14.Rows.Count;
            meta22 = ((double)count22 / (double)total22) * 100;
            meta22 = Math.Round(meta22, 2);
            if (meta22 > 100)
            {
                meta22 = 100;
            }

            pesoAct22 = ((double)count22 / (double)total22) * peso22;
            pesoAct22 = Math.Round(pesoAct22, 4);
            if (pesoAct22 > peso22)
            {
                pesoAct22 = peso22;
            }
            pesototal = pesototal + pesoAct22;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 7/jornada de producción No. 14 (4 horas)</td>";
        //ca += "<td class='center'>" + total22 + "</td>";
        //ca += "<td class='center'>" + count22 + "</td>";
        //ca += "<td class='center'>" + meta22 + "%</td>";
        //ca += "<td class='center'>" + pesoAct22 + " de " + peso22 + "</td>";
        //ca += "</tr>";



        //---------------------------------------------
        // Asistentes a la sesión de formación No. 7/ autoformación (2 horas)
        double meta53 = 0;
        int count53 = 0;
        DataTable asistentessesionformacionAutos7 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "5", "7", "14");
        int total53 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso53 = 0.008791209;
        double pesoAct53 = 0;
        if (asistentessesionformacionAutos7 != null && asistentessesionformacionAutos7.Rows.Count > 0)
        {
            count53 = asistentessesionformacionAutos7.Rows.Count;
            meta53 = ((double)count53 / (double)total53) * 100;
            meta53 = Math.Round(meta53, 2);
            if (meta53 > 100)
            {
                meta53 = 100;
            }

            pesoAct53 = ((double)count53 / (double)total53) * peso53;
            pesoAct53 = Math.Round(pesoAct53, 4);
            if (pesoAct53 > peso53)
            {
                pesoAct53 = peso53;
            }
            pesototal = pesototal + pesoAct53;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 7/ autoformación (2 horas)</td>";
        //ca += "<td class='center'>" + total53 + "</td>";
        //ca += "<td class='center'>" + count53 + "</td>";
        //ca += "<td class='center'>" + meta53 + "%</td>";
        //ca += "<td class='center'>" + pesoAct53 + " de " + peso53 + "</td>";
        //ca += "</tr>";

        // Asistentes a la sesión de formación No. 7/formación virtual (4 horas)
        double meta54 = 0;
        int count54 = 0;
        DataTable asistentessesionvirtuals7 = est.asistentessesionvirtual(coddepartamento, codmuncipio, codinstitucion, codsede, "7");
        int total54 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso54 = 0.008791209;
        double pesoAct54 = 0;
        if (asistentessesionvirtuals7 != null && asistentessesionvirtuals7.Rows.Count > 0)
        {
            count54 = asistentessesionvirtuals7.Rows.Count;
            meta54 = ((double)count54 / (double)total54) * 100;
            meta54 = Math.Round(meta54, 2);
            if (meta54 > 100)
            {
                meta54 = 100;
            }

            pesoAct54 = ((double)count54 / (double)total54) * peso54;
            pesoAct54 = Math.Round(pesoAct54, 4);
            if (pesoAct54 > peso54)
            {
                pesoAct54 = peso54;
            }
            pesototal = pesototal + pesoAct54;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 7/formación virtual (4 horas)</td>";
        //ca += "<td class='center'>" + total54 + "</td>";
        //ca += "<td class='center'>" + count54 + "</td>";
        //ca += "<td class='center'>" + meta54 + "%</td>";
        //ca += "<td class='center'>" + pesoAct54 + " de " + peso54 + "</td>";
        //ca += "</tr>";

        // Sesiones de formación  No. 7 evaluadas y subidas a la plataforma de Ciclón
        double meta55 = 0;
        int count55 = 0;
        DataTable sesionesformacionsubidasS7 = est.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "5", "7");
        int total55 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso55 = 0.008791209;
        double pesoAct55 = 0;
        if (sesionesformacionsubidasS7 != null && sesionesformacionsubidasS7.Rows.Count > 0)
        {
            count55 = sesionesformacionsubidasS7.Rows.Count;
            meta55 = ((double)count55 / (double)total55) * 100;
            meta55 = Math.Round(meta55, 2);
            if (meta55 > 100)
            {
                meta55 = 100;
            }

            pesoAct55 = ((double)count55 / (double)total55) * peso55;
            pesoAct55 = Math.Round(pesoAct55, 4);
            if (pesoAct55 > peso55)
            {
                pesoAct55 = peso55;
            }
            pesototal = pesototal + pesoAct55;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Sesiones de formación No. 7 evaluadas y subidas a la plataforma de Ciclón </td>";
        //ca += "<td class='center'>" + total55 + "</td>";
        //ca += "<td class='center'>" + count55 + "</td>";
        //ca += "<td class='center'>" + meta55 + "%</td>";
        //ca += "<td class='center'>" + pesoAct55 + " de " + peso55 + "</td>";
        //ca += "</tr>";

        // Proyectos de investigación de maestros y maestras con avance en su elaboración
        double meta56 = 0;
        int count56 = 0;
        DataTable proyectosinvestigacionmaestross7 = est.proyectosinvestigacionmaestros(coddepartamento, codmuncipio, codinstitucion, codsede);
        int total56 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso56 = 0.008791209;
        double pesoAct56 = 0;
        if (proyectosinvestigacionmaestross7 != null && proyectosinvestigacionmaestross7.Rows.Count > 0)
        {
            count56 = proyectosinvestigacionmaestross7.Rows.Count;
            meta56 = ((double)count56 / (double)total56) * 100;
            meta56 = Math.Round(meta56, 2);
            if (meta56 > 100)
            {
                meta56 = 100;
            }

            pesoAct56 = ((double)count56 / (double)total56) * peso56;
            pesoAct56 = Math.Round(pesoAct56, 4);
            if (pesoAct56 > peso56)
            {
                pesoAct56 = peso56;
            }
            pesototal = pesototal + pesoAct56;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Proyectos de investigación de maestros y maestras con avance en su elaboración</td>";
        //ca += "<td class='center'>" + total56 + "</td>";
        //ca += "<td class='center'>" + count56 + "</td>";
        //ca += "<td class='center'>" + meta56 + "%</td>";
        //ca += "<td class='center'>" + pesoAct56 + " de " + peso56 + "</td>";
        //ca += "</tr>";
        //----------------------------------------------




        // Sesiones de formación No. 8 realizadas 
        double meta23 = 0;
        int count23 = 0;
        DataTable sesionformacionMaestrosS8 = est.sesionformacionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "6", "8");
        int total23 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso23 = 0.008791209;
        double pesoAct23 = 0;
        if (sesionformacionMaestrosS8 != null && sesionformacionMaestrosS8.Rows.Count > 0)
        {
            count23 = sesionformacionMaestrosS8.Rows.Count;
            meta23 = ((double)count23 / (double)total23) * 100;
            meta23 = Math.Round(meta23, 2);
            if (meta23 > 100)
            {
                meta23 = 100;
            }

            pesoAct23 = ((double)count23 / (double)total23) * peso23;
            pesoAct23 = Math.Round(pesoAct23, 4);
            if (pesoAct23 > peso23)
            {
                pesoAct23 = peso23;
            }
            pesototal = pesototal + pesoAct23;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Sesiones de formación No. 8 realizadas </td>";
        //ca += "<td class='center'>" + total23 + "</td>";
        //ca += "<td class='center'>" + count23 + "</td>";
        //ca += "<td class='center'>" + meta23 + "%</td>";
        //ca += "<td class='center'>" + pesoAct23 + " de " + peso23 + "</td>";
        //ca += "</tr>";



        //Asistentes a la sesión de formación No. 8/jornada de actualización No. 15 (5 horas)
        double meta24 = 0;
        int count24 = 0;
        DataTable asistentesSesionMaestrosS8 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "6", "8", "15");
        int total24 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso24 = 0.008791209;
        double pesoAct24 = 0;
        if (asistentesSesionMaestrosS8 != null && asistentesSesionMaestrosS8.Rows.Count > 0)
        {
            count24 = asistentesSesionMaestrosS8.Rows.Count;
            meta24 = ((double)count24 / (double)total24) * 100;
            meta24 = Math.Round(meta24, 2);
            if (meta24 > 100)
            {
                meta24 = 100;
            }

            pesoAct24 = ((double)count24 / (double)total24) * peso24;
            pesoAct24 = Math.Round(pesoAct24, 4);
            if (pesoAct24 > peso24)
            {
                pesoAct24 = peso24;
            }
            pesototal = pesototal + pesoAct24;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 8/jornada de actualización No. 15 (5 horas)</td>";
        //ca += "<td class='center'>" + total24 + "</td>";
        //ca += "<td class='center'>" + count24 + "</td>";
        //ca += "<td class='center'>" + meta24 + "%</td>";
        //ca += "<td class='center'>" + pesoAct24 + " de " + peso24 + "</td>";
        //ca += "</tr>";



        // Asistentes a la sesión de formación No. 8/jornada de producción No. 16 (4 horas)
        double meta25 = 0;
        int count25 = 0;
        DataTable asistentesSesionMaestrosS8j16 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "6", "8", "16");
        int total25 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso25 = 0.008791209;
        double pesoAct25 = 0;
        if (asistentesSesionMaestrosS8j16 != null && asistentesSesionMaestrosS8j16.Rows.Count > 0)
        {
            count25 = asistentesSesionMaestrosS8j16.Rows.Count;
            meta25 = ((double)count25 / (double)total25) * 100;
            meta25 = Math.Round(meta25, 2);
            if (meta25 > 100)
            {
                meta25 = 100;
            }

            pesoAct25 = ((double)count25 / (double)total25) * peso25;
            pesoAct25 = Math.Round(pesoAct25, 4);
            if (pesoAct25 > peso25)
            {
                pesoAct25 = peso25;
            }
            pesototal = pesototal + pesoAct25;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 8/jornada de producción No. 16 (4 horas)</td>";
        //ca += "<td class='center'>" + total25 + "</td>";
        //ca += "<td class='center'>" + count25 + "</td>";
        //ca += "<td class='center'>" + meta25 + "%</td>";
        //ca += "<td class='center'>" + pesoAct25 + " de " + peso25 + "</td>";
        //ca += "</tr>";



        //---------------------------------------------
        // Asistentes a la sesión de formación No. 8/ autoformación (2 horas)
        double meta57 = 0;
        int count57 = 0;
        DataTable asistentessesionformacionAutos8 = est.asistentesSesionMaestros(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "6", "8", "16");
        int total57 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso57 = 0.008791209;
        double pesoAct57 = 0;
        if (asistentessesionformacionAutos8 != null && asistentessesionformacionAutos8.Rows.Count > 0)
        {
            count57 = asistentessesionformacionAutos8.Rows.Count;
            meta57 = ((double)count57 / (double)total57) * 100;
            meta57 = Math.Round(meta57, 2);
            if (meta57 > 100)
            {
                meta57 = 100;
            }

            pesoAct57 = ((double)count57 / (double)total57) * peso57;
            pesoAct57 = Math.Round(pesoAct57, 4);
            if (pesoAct57 > peso57)
            {
                pesoAct57 = peso57;
            }
            pesototal = pesototal + pesoAct57;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 8/ autoformación (2 horas)</td>";
        //ca += "<td class='center'>" + total57 + "</td>";
        //ca += "<td class='center'>" + count57 + "</td>";
        //ca += "<td class='center'>" + meta57 + "%</td>";
        //ca += "<td class='center'>" + pesoAct57 + " de " + peso57 + "</td>";
        //ca += "</tr>";

        // Asistentes a la sesión de formación No. 8/formación virtual (4 horas)
        double meta58 = 0;
        int count58 = 0;
        DataTable asistentessesionvirtuals8 = est.asistentessesionvirtual(coddepartamento, codmuncipio, codinstitucion, codsede, "8");
        int total58 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso58 = 0.008791209;
        double pesoAct58 = 0;
        if (asistentessesionvirtuals8 != null && asistentessesionvirtuals8.Rows.Count > 0)
        {
            count58 = asistentessesionvirtuals8.Rows.Count;
            meta58 = ((double)count58 / (double)total58) * 100;
            meta58 = Math.Round(meta58, 2);
            if (meta58 > 100)
            {
                meta58 = 100;
            }

            pesoAct58 = ((double)count58 / (double)total58) * peso58;
            pesoAct58 = Math.Round(pesoAct58, 4);
            if (pesoAct58 > peso58)
            {
                pesoAct58 = peso58;
            }
            pesototal = pesototal + pesoAct58;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Asistentes a la sesión de formación No. 8/formación virtual (4 horas)</td>";
        //ca += "<td class='center'>" + total58 + "</td>";
        //ca += "<td class='center'>" + count58 + "</td>";
        //ca += "<td class='center'>" + meta58 + "%</td>";
        //ca += "<td class='center'>" + pesoAct58 + " de " + peso58 + "</td>";
        //ca += "</tr>";

        // Sesiones de formación  No. 8 evaluadas y subidas a la plataforma de Ciclón
        double meta59 = 0;
        int count59 = 0;
        DataTable sesionesformacionsubidasS8 = est.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "6", "8");
        int total59 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso59 = 0.008791209;
        double pesoAct59 = 0;
        if (sesionesformacionsubidasS8 != null && sesionesformacionsubidasS8.Rows.Count > 0)
        {
            count59 = sesionesformacionsubidasS8.Rows.Count;
            meta59 = ((double)count59 / (double)total59) * 100;
            meta59 = Math.Round(meta59, 2);
            if (meta59 > 100)
            {
                meta59 = 100;
            }

            pesoAct59 = ((double)count59 / (double)total59) * peso59;
            pesoAct59 = Math.Round(pesoAct59, 4);
            if (pesoAct59 > peso59)
            {
                pesoAct59 = peso59;
            }
            pesototal = pesototal + pesoAct59;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Sesiones de formación No. 8 evaluadas y subidas a la plataforma de Ciclón </td>";
        //ca += "<td class='center'>" + total59 + "</td>";
        //ca += "<td class='center'>" + count59 + "</td>";
        //ca += "<td class='center'>" + meta59 + "%</td>";
        //ca += "<td class='center'>" + pesoAct59 + " de " + peso59 + "</td>";
        //ca += "</tr>";

        // Proyectos de investigación de maestros y maestras con avance en su elaboración
        double meta60 = 0;
        int count60 = 0;
        DataTable proyectosinvestigacionmaestross8 = est.proyectosinvestigacionmaestros(coddepartamento, codmuncipio, codinstitucion, codsede);
        int total60 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso60 = 0.008791209;
        double pesoAct60 = 0;
        if (proyectosinvestigacionmaestross8 != null && proyectosinvestigacionmaestross8.Rows.Count > 0)
        {
            count60 = proyectosinvestigacionmaestross8.Rows.Count;
            meta60 = ((double)count60 / (double)total60) * 100;
            meta60 = Math.Round(meta60, 2);
            if (meta60 > 100)
            {
                meta60 = 100;
            }

            pesoAct60 = ((double)count60 / (double)total60) * peso60;
            pesoAct60 = Math.Round(pesoAct60, 4);
            if (pesoAct60 > peso60)
            {
                pesoAct60 = peso60;
            }
            pesototal = pesototal + pesoAct60;
        }
        num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Proyectos de investigación de maestros y maestras con avance en su elaboración</td>";
        //ca += "<td class='center'>" + total60 + "</td>";
        //ca += "<td class='center'>" + count60 + "</td>";
        //ca += "<td class='center'>" + meta60 + "%</td>";
        //ca += "<td class='center'>" + pesoAct60 + " de " + peso60 + "</td>";
        //ca += "</tr>";
        //----------------------------------------------


        return pesototal;

    }





    


    protected void btnRegresar_Click(object sender, EventArgs e)
    {
        Response.Redirect("informedesarrollo.aspx");
    }
    
}