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

public partial class menusegestrategia1 : System.Web.UI.Page
{
    Funciones fun = new Funciones();
    Estrategias est = new Estrategias();
    Consultas c = new Consultas();
    protected void Page_Load(object sender, EventArgs e)
    {
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 
        if (!IsPostBack)
        {
            if (Session["codrol"] != null)
            {
               
                if (Session["codrol"].ToString() == "18")//Asesor CUC
                {
                    accordion.InnerHtml = MenuAcordeonGerencia();

                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }

    //Menú Gerencia
    private string MenuAcordeonGerencia()
    {
        string ca = "";

        //ca += "<h3>Estrategia </h3>";
        //ca += "<div>";
        //ca += "<ul style='margin-left:40px;'>"; //Submenu 
        //ca += "<li style='list-style-type: disc;' ><a href=''> Conformación grupos de investigación</a></li>";
        //ca += "</ul>"; //Fin Submenu
        //ca += "</div>";

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargardatos()
    {
        string ca = "";
        double pesototal = 0;
        int num = 0;
        Estrategias est = new Estrategias();
        Consultas c = new Consultas();
        Institucion ins = new Institucion();

        DataRow loadTotalesIndicadoresxSede = ins.loadTotalesIndicadoresxSedeSUM("", "", "", "");

        DataTable totalSedesGrupoInvestigacion = est.totalSedesGrupoInvestigacion("", "", "");
        
        
        DataTable totalGrupoInvestigacion = est.totalGrupoInvestigacion("", "", "", "");
        DataTable totalEstudiantesMatriculadosGP = c.totalestudiantesparticipantesgi("", "", "", "", "");
        //DataTable totalEstudiantesMatriculadosGP = est.totalEstudiantesMatriculadosGP("", "", "", "", "");
        DataTable totalDocenesMatriculadosGP = est.totalDocenesMatriculadosGP("", "", "", "", "");
        DataTable totalSedesGPTenganPreguntas = est.totalSedesGPTenganPreguntas("", "", "");
        
        DataTable totalSedesGPTenganPreguntasB3 = est.totalSedesGPTenganPreguntasB3("", "", "");
        
        
        
        DataTable totalKitPreestructurados = c.totalKitPreestructurados("1","1","22");


        //57) Estudiantes participantes  en las jornadas de formación en la pregunta como punto de partida y en la ruta metodológica del programa Ciclón 
        DataTable estuinscritossesion_vt_s101 = c.listarEncaJornadasFormacionTodosIndicador("", "", "", "", "", "");
        double meta561 = 0;
        int count561 = 0;
        /*Falta el total por sede => */
        int total561 = 84800;//Convert.ToInt32(loadTotalesIndicadoresxSede["totalesturedestematicas"].ToString());
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
            pesoAct561 = ((double)peso561 / (double)total561) * count561;
            pesoAct561 = Math.Round(pesoAct561, 4);
            if (pesoAct561 > peso561)
            {
                pesoAct561 = peso561;
            }
            pesototal = pesototal + pesoAct561;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b> Estudiantes participantes en las jornadas de formación en la pregunta como punto de partida y en la ruta metodológica del programa Ciclón  </td>";
        ca += "<td class='center'>" + total561 + "</td>";
        ca += "<td class='center'>" + count561 + "</td>";
        ca += "<td class='center'>" + meta561 + "%</td>";
        ca += "<td class='center'>" + pesoAct561 + "</td>";
        ca += "<td class='center'>-</td>";
        ca += "</tr>";

        //total grupos de investigación 
        double meta2 = 0;
        int count2 = 0;
        int total2 = 420;
        double pesototalgi = 2.00;
        double pesogi = 0;
        if (totalGrupoInvestigacion != null && totalGrupoInvestigacion.Rows.Count > 0)
        {
            count2 = totalGrupoInvestigacion.Rows.Count;
            meta2 = ((double)count2 / (double)total2) * 100;
            meta2 = Math.Round(meta2, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}
            count2 = totalGrupoInvestigacion.Rows.Count;

            pesogi = ((double)count2 / (double)total2) * pesototalgi;
            pesogi = Math.Round(pesogi, 4);
            if (pesogi > pesototalgi)
            {
                pesogi = pesototalgi;
            }
            pesototal = pesototal + pesogi;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Grupos de investigación infantiles y juveniles seleccionados en la convocatoria de Ciclón  </td>";
        ca += "<td class='center'>" + total2 + "</td>";
        ca += "<td class='center'>" + count2 + "</td>";
        ca += "<td class='center'>" + meta2 + "%</td>";
        ca += "<td class='center'>" + pesogi + "</td>";
        ca += "<td class='noExl center'><a href='totalgrupoinvestigacion.aspx?sg=true&ln='><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //total grupos de investigación Abierta
        DataTable totalSedesGrupoInvestigacionAb = est.totalSedesGrupoInvestigacionLineaInvestigacion("", "", "", "2");
        double meta2a = 0;
        int count2a = 0;
        int total2a = 260;
        double pesototalgia = 2.00;
        double pesogia = 0;
        if (totalSedesGrupoInvestigacionAb != null && totalSedesGrupoInvestigacionAb.Rows.Count > 0)
        {
            count2a = totalSedesGrupoInvestigacionAb.Rows.Count;
            meta2a = ((double)count2a / (double)total2a) * 100;
            meta2a = Math.Round(meta2a, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesogia = ((double)count2a / (double)total2a) * pesototalgia;
            pesogia = Math.Round(pesogia, 4);
            if (pesogia > pesototalgia)
            {
                pesogia = pesototalgia;
            }
            //pesototal = pesototal + pesogia;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Grupos de investigación Abiertos </td>";
        ca += "<td class='center'>" + total2a + "</td>";
        ca += "<td class='center'>" + count2a + "</td>";
        ca += "<td class='center'>" + meta2a + "%</td>";
        ca += "<td class='center'>-</td>";
        ca += "<td class='noExl center'><a href='totalgrupoinvestigacion.aspx?sg=true&ln=2'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //total grupos de investigación preestructurados
        DataTable totalSedesGrupoInvestigacionPr = est.totalSedesGrupoInvestigacionLineaInvestigacion("", "", "", "3");
        double meta2p = 0;
        int count2p = 0;
        int total2p = 160;
        double pesototalgip = 2.00;
        double pesogip = 0;
        if (totalSedesGrupoInvestigacionPr != null && totalSedesGrupoInvestigacionPr.Rows.Count > 0)
        {
            count2p = totalSedesGrupoInvestigacionPr.Rows.Count;
            meta2p = ((double)count2p / (double)total2p) * 100;
            meta2p = Math.Round(meta2p, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesogip = ((double)count2p / (double)total2p) * pesototalgip;
            pesogip = Math.Round(pesogip, 4);
            if (pesogip > pesototalgip)
            {
                pesogip = pesototalgip;
            }
            //pesototal = pesototal + pesogip;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Grupos de investigación Preestructurados  </td>";
        ca += "<td class='center'>" + total2p + "</td>";
        ca += "<td class='center'>" + count2p + "</td>";
        ca += "<td class='center'>" + meta2p + "%</td>";
        ca += "<td class='center'>-</td>";
        ca += "<td class='noExl center'><a href='totalgrupoinvestigacion.aspx?sg=true&ln=3'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Grupos de investigación infantiles y juveniles que se inscribieron en la convocatoria de Ciclón 
        DataTable totalgrupoinveinscritos = c.totalGruposInvestigacionInscritos();
        double meta12 = 0;
        int count12 = 0;
        int total12 = 638;
        double pesototal12 = 2.00;
        double peso12 = 0;
        if (totalgrupoinveinscritos != null && totalgrupoinveinscritos.Rows.Count > 0)
        {
            count12 = totalgrupoinveinscritos.Rows.Count;
            meta12 = ((double)count12 / (double)total12) * 100;
            meta12 = Math.Round(meta12, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            peso12 = ((double)count12 / (double)total12) * pesototal12;
            peso12 = Math.Round(peso12, 4);
            if (peso12 > pesototal12)
            {
                peso12 = pesototal12;
            }
            pesototal = pesototal + peso12;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Grupos de investigación infantiles y juveniles que se inscribieron en la convocatoria de Ciclón </td>";
        ca += "<td class='center'>" + total12 + "</td>";
        ca += "<td class='center'>" + count12 + "</td>";
        ca += "<td class='center'>" + meta12 + "%</td>";
        ca += "<td class='center'>" + peso12 + "</td>";
        ca += "<td class='noExl center'><a href='javascript:void(0)' onclick='inscribieronconvocatoria()'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Niños, niñas y jóvenes inscritos en grupos de investigación infantiles y juveniles en la convocatoria Ciclón 
        DataTable estudianesengp = est.estudianesengp("", "", "", "");
        double meta2est = 0;
        int count2est = 0;
        int total2est = Convert.ToInt32(loadTotalesIndicadoresxSede["totalasistentesasesorias"].ToString());
        double peso2est = 2.0;
        double pesoAct2est = 0;

        if (estudianesengp != null && estudianesengp.Rows.Count > 0)
        {
            count2est = estudianesengp.Rows.Count;
            meta2est = ((double)count2est / (double)total2est) * 100;
            meta2est = Math.Round(meta2est, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}
            pesoAct2est = ((double)count2est / (double)total2est) * peso2est;
            pesoAct2est = Math.Round(pesoAct2est, 4);
            if (pesoAct2est > peso2est)
            {
                pesoAct2est = peso2est;
            }
            pesototal = pesototal + pesoAct2est;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b> Niños, niñas y jóvenes inscritos en grupos de investigación infantiles y juveniles en la convocatoria Ciclón </td>";
        ca += "<td class='center'>" + total2est + "</td>";
        ca += "<td class='center'>" + count2est + "</td>";
        ca += "<td class='center'>" + meta2est + "%</td>";
        ca += "<td class='center'>" + pesoAct2est + "</td>";
        ca += "<td class='noExl center'>-</td>";
        //ca += "<td class='noExl center'><a href='javascript:void(0)' onclick='ninosinscribieronconvocatoria()'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        ////Niños, niñas y jóvenes inscritos en grupos de investigación infantiles y juveniles seleccionados en la convocatoria Ciclón 
        //double meta3 = 0;
        //int count3 = 0;
        //int total3 = 42400;
        //double pesototal3 = 2.00;
        //double peso3 = 0;
        //if (totalEstudiantesMatriculadosGP != null && totalEstudiantesMatriculadosGP.Rows.Count > 0)
        //{
        //    count3 = totalEstudiantesMatriculadosGP.Rows.Count;
        //    //count3 = 32798;
        //    meta3 = ((double)count3 / (double)total3) * 100;
        //    meta3 = Math.Round(meta3, 2);
        //    //if (meta3 > 100)
        //    //{
        //    //    meta3 = 100;
        //    //}
        //    count3 = totalEstudiantesMatriculadosGP.Rows.Count;

        //    peso3 = ((double)count3 / (double)total3) * pesototal3;
        //    peso3 = Math.Round(peso3, 4);
        //    if (peso3 > pesototal3)
        //    {
        //        peso3 = pesototal3;
        //    }
        //    pesototal = pesototal + peso3;
        //}
        //num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + ".</b> Niños, niñas y jóvenes inscritos en grupos de investigación infantiles y juveniles seleccionados en la convocatoria Ciclón  </td>";
        //ca += "<td class='center'>" + count3 + " de " + total3 + "</td>";
        //ca += "<td class='center'>" + meta3 + "%</td>";
        //ca += "<td class='center'>" + peso3 + "%</td>";
        //ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png' />Ver</a></td>";
        //ca += "</tr>";

        // Grupos de investigación con preguntas y grupos preestructurados con avances
        DataTable totalGPHicieronPreguntas = est.totalGPHicieronPreguntas("", "", "", "");
        double meta3 = 0;
        int count3 = 0;
        int total3 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalgrupos"].ToString());
        double peso3 = 2.0;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b> Grupos de investigación con preguntas y grupos preestructurados con avances</td>";
        ca += "<td class='center'>" + total3 + "</td>";
        ca += "<td class='center'>" + count3 + "</td>";
        ca += "<td class='center'>" + meta3 + "%</td>";
        ca += "<td class='center'>" + pesoAct3 + "</td>";
        ca += "<td class='noExl center'><a href='javascript:void(0)' onclick='grupoinvestigacionpregunta()'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        ////Grupos de investigación con preguntas y grupos preestructurados con avances
        //DataTable totalGPHicieronPreguntas = est.totalGPHicieronPreguntasTODO("", "", "", "");
        //double meta6 = 0;
        //int count6 = 0;
        //int total6 = 420;
        //double pesototal6 = 2.00;
        //double peso6 = 0;
        //if (totalGPHicieronPreguntas != null && totalGPHicieronPreguntas.Rows.Count > 0)
        //{
        //    count6 = totalGPHicieronPreguntas.Rows.Count;
        //    meta6 = ((double)count6 / (double)total6) * 100;
        //    meta6 = Math.Round(meta6, 2);
        //    //if (meta6 > 100)
        //    //{
        //    //    meta6 = 100;
        //    //}
        //    count6 = totalGPHicieronPreguntas.Rows.Count;

        //    peso6 = ((double)count6 / (double)total6) * pesototal6;
        //    peso6 = Math.Round(peso6, 4);
        //    if (peso6 > pesototal6)
        //    {
        //        peso6 = pesototal6;
        //    }
        //    pesototal = pesototal + peso6;
        //}
        //num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + ".</b> Grupos de investigación con preguntas y grupos preestructurados con avances. </td>";
        //ca += "<td class='center'>" + count6 + " de " + total6 + "</td>";
        //ca += "<td class='center'>" + meta6 + "%</td>";
        //ca += "<td class='center'>" + peso6 + "%</td>";
        //ca += "<td class='noExl center'><a href='totalgphicieronpreguntas.aspx?sg=true'><img src='images/detalles.png'>Ver</a></td>";
        //ca += "</tr>";

        //Grupos de investigación con problemas y grupos preestructurados con avances
        DataTable totalGPHicieronPreguntasB3 = est.totalGPHicieronPreguntasB3("", "", "", "");
        double meta4 = 0;
        int count4 = 0;
        int total4 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalgrupos"].ToString());
        double peso4 = 2.0;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b> Grupos de investigación con problemas y grupos preestructurados con avances</td>";
        ca += "<td class='center'>" + total4 + "</td>";
        ca += "<td class='center'>" + count4 + "</td>";
        ca += "<td class='center'>" + meta4 + "%</td>";
        ca += "<td class='center'>" + pesoAct4 + "</td>";
        ca += "<td class='noExl center'><a href='javascript:void(0)' onclick='grupoinvestigacionproblema()'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        ////Número de grupos de investigación hicieron preguntas  bitacora 3
        //DataTable totalGPHicieronPreguntasB3 = est.totalGPHicieronPreguntasB3TODO("", "", "", "");
        //double meta8 = 0;
        //int count8 = 0;
        //int total8 = 420;
        //double pesototal8 = 2.00;
        //double peso8 = 0;
        //if (totalGPHicieronPreguntasB3 != null && totalGPHicieronPreguntasB3.Rows.Count > 0)
        //{
        //    count8 = totalGPHicieronPreguntasB3.Rows.Count;
        //    meta8 = ((double)count8 / (double)total8) * 100;
        //    meta8 = Math.Round(meta8, 2);
        //    //if (meta8 > 100)
        //    //{
        //    //    meta8 = 100;
        //    //}
        //    count8 = totalGPHicieronPreguntasB3.Rows.Count;

        //    peso8 = ((double)count8 / (double)total8) * pesototal8;
        //    peso8 = Math.Round(peso8, 4);
        //    if (peso8 > pesototal8)
        //    {
        //        peso8 = pesototal8;
        //    }
        //    pesototal = pesototal + peso8;

        //}
        //num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + ".</b> Grupos de investigación con problemas y grupos preestructurados con avances</td>";
        //ca += "<td class='center'>" + count8 + " de " + total8 + "</td>";
        //ca += "<td class='center'>" + meta8 + "%</td>";
        //ca += "<td class='center'>" + peso8 + "%</td>";
        //ca += "<td class='noExl center'><a href='totalgphicieronpreguntasb3.aspx?sg=true'><img src='images/detalles.png'>Ver</a></td>";
        //ca += "</tr>";

        /*----------------------------*/

        DataTable gruposInvestigacionBitacora4 = est.gruposInvestigacionBitacora4("", "", "", "", "");
        DataTable gruposInvestigacionRecursosB4 = est.gruposInvestigacionRecursosB4("", "", "", "", "");
        DataTable gruposInvestigacionBitacora5 = est.gruposInvestigacionBitacora5("", "", "", "");

        double meta2gi = 0;
        int count2gi = 0;
        int total2gi = 420;
        double pesototal2gi = 2.00;
        double peso2gi = 0;
        if (gruposInvestigacionBitacora4 != null && gruposInvestigacionBitacora4.Rows.Count > 0)
        {
            count2gi = gruposInvestigacionBitacora4.Rows.Count;
            meta2gi = ((double)count2gi / (double)total2gi) * 100;
            meta2gi = Math.Round(meta2gi, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}
            count2gi = gruposInvestigacionBitacora4.Rows.Count;

            peso2gi = ((double)count2gi / (double)total2gi) * pesototal2gi;
            peso2gi = Math.Round(peso2gi, 4);
            if (peso2gi > pesototal2gi)
            {
                peso2gi = pesototal2gi;
            }
            pesototal = pesototal + peso2gi;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Grupos de investigación infantiles y juveniles con la bitácora 04 de presupuesto diligenciada   </td>";
        ca += "<td class='center'>" + total2gi + "</td>";
        ca += "<td class='center'>" + count2gi + "</td>";
        ca += "<td class='center'>" + meta2gi + "%</td>";
        ca += "<td class='center'>" + peso2gi + "</td>";
        ca += "<td class='noExl center'><a href='detallegruposinvestigacionbitacora4.aspx?sg=true'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0
        ca += "</tr>";

        //29) Grupos de investigación con recursos aportados por Ciclón
        DataTable gprecursosaprortados = c.cargarGruposInvestigacionRecursosAportadosCiclón("", "", "", "");
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b> Grupos de investigación con recursos aportados por Ciclón</td>";
        ca += "<td class='center'>" + total29 + "</td>";
        ca += "<td class='center'>" + count29 + "</td>";
        ca += "<td class='center'>" + meta29 + "%</td>";
        ca += "<td class='center'>" + pesoAct29 + "</td>";
        ca += "<td class='noExl center'><a href='javascript:void(0)' onclick='grupoinvestigacionrecursos()'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //double meta3gi = 0;
        //int count3gi = 0;
        //int total3gi = 420;
        //double pesototal3gi = 12.31;
        //double peso3gi = 0;
        //if (gruposInvestigacionRecursosB4 != null && gruposInvestigacionRecursosB4.Rows.Count > 0)
        //{
        //    count3gi = gruposInvestigacionRecursosB4.Rows.Count;
        //    meta3gi = ((double)count3gi / (double)total3gi) * 100;
        //    meta3gi = Math.Round(meta3gi, 2);
        //    //if (meta3 > 100)
        //    //{
        //    //    meta3 = 100;
        //    //}
        //    count3 = gruposInvestigacionRecursosB4.Rows.Count;

        //    peso3gi = ((double)count3gi / (double)total3gi) * pesototal3gi;
        //    peso3gi = Math.Round(peso3gi, 4);
        //    if (peso3gi > pesototal3gi)
        //    {
        //        peso3gi = pesototal3gi;
        //    }
        //    pesototal = pesototal + peso3gi;
        //}
        //num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + ".</b>  Grupos de investigación con recursos aportados por Ciclón</td>";
        //ca += "<td class='center'>" + count3gi + " de " + total3gi + "</td>";
        //ca += "<td class='center'>" + meta3gi + "%</td>";
        //ca += "<td class='center'>" + peso3gi + "%</td>";
        //ca += "<td class='noExl center'><a href='detallegruposinvestigacionrecursosb4.aspx?sg=true'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0
        //ca += "</tr>";



        double meta5gi = 0;
        int count5gi = 0;
        int total5gi = 420;
        double pesototal5gi = 2.0;
        double peso5gi = 0;
        if (gruposInvestigacionBitacora5 != null && gruposInvestigacionBitacora5.Rows.Count > 0)
        {
            count5gi = gruposInvestigacionBitacora5.Rows.Count;
            meta5gi = ((double)count5gi / (double)total5gi) * 100;
            meta5gi = Math.Round(meta5gi, 2);
            //if (meta5 > 100)
            //{
            //    meta5 = 100;
            //}
            count5gi = gruposInvestigacionBitacora5.Rows.Count;

            peso5gi = ((double)count5gi / (double)total5gi) * pesototal5gi;
            peso5gi = Math.Round(peso5gi, 4);
            if (peso5gi > pesototal5gi)
            {
                peso5gi = pesototal5gi;
            }
            pesototal = pesototal + peso5gi;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Grupos de investigación con trayectorias y proyectos preestructurados con avances </td>";
        ca += "<td class='center'>" + total5gi + "</td>";
        ca += "<td class='center'>" + count5gi + "</td>";
        ca += "<td class='center'>" + meta5gi + "%</td>";
        ca += "<td class='center'>" + peso5gi + "</td>";
        ca += "<td class='noExl center'><a href='detallegruposinvestigacionbitacora5.aspx?sg=true'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0
        ca += "</tr>";


        //Total grupos de investigación con registro de avance del presupuesto
        DataTable gruposInvestigacionPresupuesto = est.gruposInvestigacionPresupuestoEvidencias("", "", "", "");
        double meta2as = 0;
        int count2as = 0;
        int total2as = 420;
        double pesototal2as = 0.66;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Grupos de investigación con registro de avance primer desembolso</td>";
        ca += "<td class='center'>" + total2as + "</td>";
        ca += "<td class='center'>" + count2as + "</td>";
        ca += "<td class='center'>" + meta2as + "%</td>";
        ca += "<td class='center'>" + peso2as + "</td>";
        ca += "<td class='noExl center'><a href='javascript:void(0)' onclick='grupoinvestigacionavancepresupuesto()'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0
        ca += "</tr>";

        //Grupos de investigación con registro de avance segundo desembolso
        DataTable gpregistroavance_2 = c.cargarGruposInformeFinancieroDesembolso("", "", "", "", "2");
        double meta30_2 = 0;
        int count30_2 = 0;
        int total30_2 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalgrupos"].ToString());
        double peso30_2 = 0.66;
        double pesoAct30_2 = 0;
        if (gpregistroavance_2 != null && gpregistroavance_2.Rows.Count > 0)
        {
            count30_2 = gpregistroavance_2.Rows.Count;
            meta30_2 = ((double)count30_2 / (double)total30_2) * 100;
            meta30_2 = Math.Round(meta30_2, 2);
            //if (meta30 > 100)
            //{
            //    meta30 = 100;
            //}
            pesoAct30_2 = ((double)count30_2 / (double)total30_2) * peso30_2;
            pesoAct30_2 = Math.Round(pesoAct30_2, 4);
            if (pesoAct30_2 > peso30_2)
            {
                pesoAct30_2 = peso30_2;
            }
            pesototal = pesototal + pesoAct30_2;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>Grupos de investigación con registro de avance segundo desembolso</td>";
        ca += "<td class='center'>" + total30_2 + "</td>";
        ca += "<td class='center'>" + count30_2 + "</td>";
        ca += "<td class='center'>" + meta30_2 + "%</td>";
        ca += "<td class='center'>" + pesoAct30_2 + "</td>";
        ca += "<td class='noExl center'><a href='javascript:void(0)' onclick='grupoinvestigacionavancepresupuesto2desembolso()'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Grupos de investigación con registro de avance tercer desembolso
        DataTable gpregistroavance_3 = c.cargarGruposInformeFinancieroDesembolso("", "", "", "", "3");
        double meta30_3 = 0;
        int count30_3 = 0;
        int total30_3 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalgrupos"].ToString());
        double peso30_3 = 0.66;
        double pesoAct30_3 = 0;
        if (gpregistroavance_3 != null && gpregistroavance_3.Rows.Count > 0)
        {
            count30_3 = gpregistroavance_3.Rows.Count;
            meta30_3 = ((double)count30_3 / (double)total30_3) * 100;
            meta30_3 = Math.Round(meta30_3, 2);
            //if (meta30 > 100)
            //{
            //    meta30 = 100;
            //}
            pesoAct30_3 = ((double)count30_3 / (double)total30_3) * peso30_3;
            pesoAct30_3 = Math.Round(pesoAct30_3, 4);
            if (pesoAct30_3 > peso30_3)
            {
                pesoAct30_3 = peso30_3;
            }
            pesototal = pesototal + pesoAct30_3;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>Grupos de investigación con registro de avance tercer desembolso</td>";
        ca += "<td class='center'>" + total30_3 + "</td>";
        ca += "<td class='center'>" + count30_3 + "</td>";
        ca += "<td class='center'>" + meta30_3 + "%</td>";
        ca += "<td class='center'>" + pesoAct30_3 + "</td>";
        ca += "<td class='noExl center'><a href='javascript:void(0)' onclick='grupoinvestigacionavancepresupuesto3desembolso()'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        /*---------------*/
        //DataTable informesinvestigacion = est.informesinvestigacion("", "", "", "", "");
        //DataTable resumenproyectoinvestigacion = est.resumenproyectoinvestigacion("", "", "", "", "");


        //double meta1ie = 0;
        //int count1ie = 0;
        //int total1ie = 420;
        //double pesototal1ie = 0.0200;
        //double peso1ie = 0;
        ////if (informesinvestigacion != null && informesinvestigacion.Rows.Count > 0)
        ////{
        ////count1 = informesinvestigacion.Rows.Count;
        //meta1ie = ((double)count1ie / (double)total1ie) * 100;
        //meta1ie = Math.Round(meta1ie, 2);
        ////if (meta1 > 100)
        ////{
        ////    meta1 = 100;
        ////}
        ////}
        //peso1ie = ((double)count1ie / (double)total1ie) * pesototal1ie;
        //peso1ie = Math.Round(peso1ie, 4);
        //if (peso1ie > pesototal1ie)
        //{
        //    peso1ie = pesototal1ie;
        //}
        //pesototal = pesototal + peso1ie;

        //num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + ".</b> Informes de investigación elaborados por los grupos de investigación infantiles y juveniles</td>";
        //ca += "<td class='center'>" + total1ie + "</td>";
        //ca += "<td class='center'>" + count1ie + "</td>";
        //ca += "<td class='center'>" + meta1ie + "</td>";
        //ca += "<td class='center'>" + meta1ie + "%</td>";
        
        //ca += "</tr>";


        ////Asistentes a la sesión de asesoría a grupos infantiles y juveniles
        //DataRow noasesorias = est.noasesorias();
        //double meta3as = 0;
        //int count3as = 0;
        //int total3as = 44200;
        //double pesototal3as = 2.00;
        //double peso3as = 0;
        //if (noasesorias != null)
        //{
        //    count3as = Convert.ToInt32(noasesorias["noasesorias"].ToString());
        //    meta3 = ((double)count3as / (double)total3as) * 100;
        //    meta3 = Math.Round(meta3as, 2);
        //    //if (meta3 > 100)
        //    //{
        //    //    meta3 = 100;
        //    //}

        //    peso3as = ((double)count3as / (double)total3as) * pesototal3as;
        //    peso3as = Math.Round(peso3as, 4);
        //    if (peso3as > pesototal3as)
        //    {
        //        peso3as = pesototal3as;
        //    }
        //    pesototal = pesototal + peso3as;
        //}
        //num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + ".</b> Asistentes a la sesión de asesoría a grupos infantiles y juveniles</td>";
        //ca += "<td class='center'>" + total3as + "</td>";
        //ca += "<td class='center'>" + count3as + "%</td>";
        //ca += "<td class='center'>" + meta3as + "%</td>";
        //ca += "<td class='center'>" + peso3as + "%</td>";
        //ca += "<td class='noExl center'>Sin detalles</td>";
        //ca += "</tr>";

        //31)  Informes de investigación elaborados por los grupos de investigación infantiles y juveniles
        DataTable informesinvelavoradosgp = c.informeinvestipree();
        double meta31 = 0;
        int count31 = 0;
        int total31 = 160;
        double peso31 = 1;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b> Informes de investigación preestructurados</td>";
        ca += "<td class='center'>" + total31 + "</td>";
        ca += "<td class='center'>" + count31 + "</td>";
        ca += "<td class='center'>" + meta31 + "%</td>";
        ca += "<td class='center'>" + pesoAct31 + "</td>";
        ca += "<td class='noExl center'><a href='javascript:void(0)' onclick='grupoinvestigacioninformesinvestigacion()'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        DataTable inforinvestiabiertos = c.informeinvestiabierto();
        double meta32 = 0;
        int count32 = 0;
        int total32 = 260;
        double peso32 = 1;
        double pesoAct32 = 0;
        if (inforinvestiabiertos != null && inforinvestiabiertos.Rows.Count > 0)
        {
            count31 = inforinvestiabiertos.Rows.Count;
            meta32 = ((double)count32 / (double)total32) * 100;
            meta32 = Math.Round(meta32, 2);
            //if (meta31 > 100)
            //{
            //    meta31 = 100;
            //}
            pesoAct32 = ((double)count32 / (double)total32) * peso32;
            pesoAct32 = Math.Round(pesoAct32, 4);
            if (pesoAct32 > peso32)
            {
                pesoAct32 = peso32;
            }
            pesototal = pesototal + pesoAct32;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b> Informe de investigación abiertos</td>";
        ca += "<td class='center'>" + total32 + "</td>";
        ca += "<td class='center'>" + count32 + "</td>";
        ca += "<td class='center'>" + meta32 + "%</td>";
        ca += "<td class='center'>" + pesoAct32 + "</td>";
        ca += "<td class='noExl center'><a href='javascript:void(0)' onclick='grupoinvestigacioninformesinvestigacionabierto()'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";
        ////Asesorias realizadas a cada uno de los grupos de investigación 
        //DataTable asesoriasGPEtapa5 = est.asesoriasGPEtapa5TodoMomentos("", "", "", "", "");
       
        //double meta1as = 0;
        //int count1as = 0;
        //int total1as = 3360;
        //double pesototal1as = 0.0200;
        //double peso1as = 0;
        //if (asesoriasGPEtapa5 != null && asesoriasGPEtapa5.Rows.Count > 0)
        //{
        //    count1as = asesoriasGPEtapa5.Rows.Count;
        //    meta1as = ((double)count1as / (double)total1as) * 100;
        //    meta1as = Math.Round(meta1as, 2);
        //    //if (meta1 > 100)
        //    //{
        //    //    meta1 = 100;
        //    //}
        //    count1as = asesoriasGPEtapa5.Rows.Count;

        //    peso1as = ((double)count1as / (double)total1as) * pesototal1as;
        //    peso1as = Math.Round(peso1as, 4);
        //    if (peso1as > pesototal1as)
        //    {
        //        peso1as = pesototal1as;
        //    }
        //    pesototal = pesototal + peso1as;
        //}
        //num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + ".</b> Asesorias realizadas a cada uno de los grupos de investigación </td>";
        //ca += "<td class='center'>" + count1as + " de " + total1as + "</td>";
        //ca += "<td class='center'>" + meta1as + "%</td>";
        //ca += "<td class='center'>" + peso1as + "</td>";
        //ca += "<td class='noExl center'><a href='asesoriasgpetapa5.aspx?sg=true'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0
        //ca += "</tr>";

        //7) Asistentes a la sesión de asesoría a grupos infantiles y juveniles
        DataRow asistentesesionasesoriaxestrategia = est.asistentesesionasesoriaxestrategia("", "", "", "", "1");


        double meta7 = 0;
        int count7 = 0;
        int total7 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalasistentesasesorias"].ToString());
        double peso7 = 2.0;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b> Asistentes a la sesión de asesoría a grupos infantiles y juveniles</td>";
        ca += "<td class='center'>" + total7 + "</td>";
        ca += "<td class='center'>" + count7 + "</td>";
        ca += "<td class='center'>" + meta7 + "%</td>";
        ca += "<td class='center'>" + pesoAct7 + "</td>";
        ca += "<td class='noExl center'>-</td>";

        ////Espacio de apropición social a nivel institucional, municipal, departamental, regional, internacional realizados, faltó municipal
        //DataTable totalespaciosapropiacion = c.totalespaciosapropiacion();
        //double meta13 = 0;
        //int count13 = 0;
        //int total13 = 719;
        //double pesototal13 = 40.97;
        //double peso13 = 0;
        //if (totalespaciosapropiacion != null && totalespaciosapropiacion.Rows.Count > 0)
        //{
        //    count13 = totalespaciosapropiacion.Rows.Count;
        //    meta13 = ((double)count13 / (double)total13) * 100;
        //    meta13 = Math.Round(meta13, 2);
        //    //if (meta2 > 100)
        //    //{
        //    //    meta2 = 100;
        //    //}

        //    peso13 = ((double)count13 / (double)total13) * pesototal13;
        //    peso13 = Math.Round(peso13, 4);
        //    if (peso13 > pesototal13)
        //    {
        //        peso13 = pesototal13;
        //    }
        //    pesototal = pesototal + peso13;
        //}
        //num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + ".</b> Espacio de apropición social a nivel institucional, municipal, departamental, regional, internacional realizados</td>";
        //ca += "<td class='center'>" + count13 + " de " + total13 + "</td>";
        //ca += "<td class='center'>" + meta13 + "%</td>";
        //ca += "<td class='center'>" + peso13 + "</td>";
        //ca += "<td class='noExl center'><a href='#?sg=true'><img src='images/detalles.png'>Ver</a></td>";
        //ca += "</tr>";

        //8) Asesorias realizadas a cada uno de los grupos de investigación 
        DataTable noAsesoriasGP = est.noAsesoriasGP("", "", "", "");
        double meta8 = 0;
        int count8 = 0;
        int total8 = 0;
        total8 = Convert.ToInt32(loadTotalesIndicadoresxSede["metanoasesoria"].ToString());
        //int total8 = Convert.ToInt32(loadTotalesIndicadoresxSede["metanoasesoria"].ToString()) * Convert.ToInt32(loadTotalesIndicadoresxSede["totalgrupos"].ToString());
        double peso8 = 2.0;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b> Asesorias realizadas a cada uno de los grupos de investigación </td>";
        ca += "<td class='center'>" + total8 + "</td>";
        ca += "<td class='center'>" + count8 + "</td>";
        ca += "<td class='center'>" + meta8 + "%</td>";
        ca += "<td class='center'>" + pesoAct8 + "</td>";
        ca += "<td class='noExl center'><a href='javascript:void(0)' onclick='gruposinvestigacionasesoriasrealizadas()'><img src='images/detalles.png'>Ver</a></td>";
        //ca += "</tr>";
        ca += "</tr>";

        ////Kit preestructurados de los 4 documentos del programa Ciclón reimpresos
        //double meta14 = 0;
        //int count14 = 0;
        //int total14 = 1;
        //double pesototal14 = 1.06;
        //double peso14 = 0;
        //if (totalKitPreestructurados != null && totalKitPreestructurados.Rows.Count > 0)
        //{
        //    count14 = totalKitPreestructurados.Rows.Count;
        //    meta14 = ((double)count14 / (double)total14) * 100;
        //    meta14 = Math.Round(meta14, 2);
        //    //if (meta2 > 100)
        //    //{
        //    //    meta2 = 100;
        //    //}

        //    peso14 = ((double)count14 / (double)total14) * pesototal14;
        //    peso14 = Math.Round(peso14, 4);
        //    if (peso14 > pesototal14)
        //    {
        //        peso14 = pesototal14;
        //    }
        //    pesototal = pesototal + peso14;
        //}
        //num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + ".</b> Kit preestructurados de los 4 documentos del programa Ciclón reimpresos</td>";
        //ca += "<td class='center'>" + count14 + " de " + total14 + "</td>";
        //ca += "<td class='center'>" + meta14 + "%</td>";
        //ca += "<td class='center'>" + peso14 + "</td>";
        //ca += "<td class='noExl center'><a href='#?sg=true'><img src='images/detalles.png'>Ver</a></td>";
        //ca += "</tr>";

        //9) Kit preestructurados de los 4 documentos del programa Ciclón reimpresos
        //DataTable kitpreestructurados = est.kitpreestructurados(coddepartamento, codmuncipio, codinstitucion, codsede);
        DataTable kitpreestructurados = est.cargarEvidenciasPublicaciones("1");
        double meta9 = 0;
        int count9 = 0;
        int total9 = 15;
        //int total9 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalkits"].ToString());

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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b> Kit preestructurados de los 4 documentos del programa Ciclón reimpresos </td>";
        ca += "<td class='center'>" + total9 + "</td>";
        ca += "<td class='center'>" + count9 + "</td>";
        ca += "<td class='center'>" + meta9 + "%</td>";
        ca += "<td class='center'>" + pesoAct9 + "</td>";
        ca += "<td class='noExl center'><a href='estraunopublicacionesguiasevi.aspx?t=1&sg=true'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Publicaciones impresas y/o digitales (2  de los procesos y resultados de los grupos de investigación  y  de los resultados de la implementación del proyecto). 
        DataTable guias2 = est.cargarEvidenciasPublicaciones("2");
        double meta1412 = 0;
        int count1412 = 0;
        int total1412 = 3;
        double pesototal1412 = 0.92;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b> Publicaciones impresas y/o digitales (2  de los procesos y resultados de los grupos de investigación  y  de los resultados de la implementación del proyecto). </td>";
        ca += "<td class='center'>" + total1412 + "</td>";
        ca += "<td class='center'>" + count1412 + "</td>";
        ca += "<td class='center'>" + meta1412 + "%</td>";
        ca += "<td class='center'>" + peso1412 + "</td>";
        ca += "<td class='noExl center'><a href='estraunopublicacionesguiasevi.aspx?t=2&sg=true'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Guías de investigación rediseñadas e impresas
        DataTable guias = est.cargarEvidenciasPublicaciones("3");
        double meta141 = 0;
        int count141 = 0;
        int total141 = 1;
        double pesototal141 = 0.73;
        double peso141 = 0;
        if (guias != null && guias.Rows.Count > 0)
        {
            if (guias.Rows.Count > 1)
                count141 = 1;
            else
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b> Guías de investigación rediseñadas e impresas</td>";
        ca += "<td class='center'>" + total141 + "</td>";
        ca += "<td class='center'>" + count141 + "</td>";
        ca += "<td class='center'>" + meta141 + "%</td>";
        ca += "<td class='center'>" + peso141 + "</td>";
        ca += "<td class='noExl center'><a href='estraunopublicacionesguiasevi.aspx?t=3&sg=true'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Espacio de apropiación social a nivel institucional, municipal, departamental, regional, internacional realizados
        DataTable feriasins = ins.feriasinst();
        DataTable feriasMun = est.cargarFeriasMunicipalesMaferpi();
        DataTable feriasDep = est.cargarFeriasDptalesMaferpi();
        DataTable feriasReg = est.FeriasRegionalesMaferpi();
        DataTable feriasNac = est.FeriasNacionalesMaferpi();
        DataTable feriasInt = est.FeriasInternacionalMaferpi();


        double metaespacio = 0;
        int countespacio = 0;
        int totalespacio = 720;
        double pesototalespacio = 40.97;
        double pesoespacio = 0;
        if (feriasins != null && feriasins.Rows.Count > 0)
        {
            countespacio = feriasins.Rows.Count + feriasMun.Rows.Count + feriasDep.Rows.Count + feriasReg.Rows.Count + feriasNac.Rows.Count + feriasInt.Rows.Count;
            metaespacio = ((double)countespacio / (double)totalespacio) * 100;
            metaespacio = Math.Round(metaespacio, 2);
            pesoespacio = ((double)countespacio / (double)totalespacio) * pesototalespacio;
            pesoespacio = Math.Round(pesoespacio, 4);
            if (pesoespacio > pesototalespacio)
            {
                pesoespacio = pesototalespacio;
            }





            pesototal = pesototal + pesoespacio;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b> Espacio de apropiación social a nivel institucional, municipal, departamental, regional, internacional realizados</td>";
        ca += "<td class='center'>" + totalespacio + "</td>";
        ca += "<td class='center'>" + countespacio + "</td>";
        ca += "<td class='center'>" + metaespacio + "%</td>";
        ca += "<td class='center'>" + pesoespacio + "</td>";
        ca += "<td class='noExl center'>-</td>";
        ca += "</tr>";

        //CONTRAPARTIDA UNIMAG
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b> CONTRAPARTIDA UNIMAG (Cumplimiento del indicador, previa aprobación de la interventoría)</td>";
        ca += "<td class='center'>10,49</td>";
        ca += "<td class='center'>-</td>";
        ca += "<td class='center'>-</td>";
        ca += "<td class='center'>-</td>";
        ca += "<td class='noExl center'>-</td>";
        ca += "</tr>";

        //CONTRAPARTIDA UNIMAG
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b> CONTRAPARTIDA MAFERPI (Cumplimiento del indicador, previa aprobación de la interventoría)</td>";
        ca += "<td class='center'>6,30</td>";
        ca += "<td class='center'>-</td>";
        ca += "<td class='center'>-</td>";
        ca += "<td class='center'>-</td>";
        ca += "<td class='noExl center'>-</td>";
        ca += "</tr>";

        ////Guías de investigación rediseñadas e impresas
        //DataTable guias = est.cargarEvidenciasPublicaciones("2");
        //double meta141 = 0;
        //int count141 = 0;
        //int total141 = 1;
        //double pesototal141 = 0.73;
        //double peso141 = 0;
        //if (guias != null && guias.Rows.Count > 0)
        //{
        //    count141 = guias.Rows.Count;
        //    meta141 = ((double)count141 / (double)total141) * 100;
        //    meta141 = Math.Round(meta141, 2);
        //    //if (meta2 > 100)
        //    //{
        //    //    meta2 = 100;
        //    //}

        //    peso141 = ((double)count141 / (double)total141) * pesototal141;
        //    peso141 = Math.Round(peso141, 4);
        //    if (peso141 > pesototal141)
        //    {
        //        peso141 = pesototal141;
        //    }
        //    pesototal = pesototal + peso141;
        //}
        //num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + ".</b> Guías de investigación rediseñadas e impresas</td>";
        //ca += "<td class='center'>" + count141 + " de " + total141 + "</td>";
        //ca += "<td class='center'>" + meta141 + "%</td>";
        //ca += "<td class='center'>" + peso141 + "</td>";
        //ca += "<td class='noExl center'><a href='#?sg=true'><img src='images/detalles.png'>Ver</a></td>";
        //ca += "</tr>";

        ////Publicaciones impresas y/o digitales (2  de los procesos y resultados de los grupos de investigación  y  de los resultados de la implementación del proyecto). 
        //DataTable guias2 = est.cargarEvidenciasPublicaciones("1");
        //double meta1412 = 0;
        //int count1412 = 0;
        //int total1412 = 1;
        //double pesototal1412 = 0.92;
        //double peso1412 = 0;
        //if (guias2 != null && guias2.Rows.Count > 0)
        //{
        //    count1412 = guias2.Rows.Count;
        //    meta1412 = ((double)count1412 / (double)total1412) * 100;
        //    meta1412 = Math.Round(meta1412, 2);
        //    //if (meta2 > 100)
        //    //{
        //    //    meta2 = 100;
        //    //}

        //    peso1412 = ((double)count1412 / (double)total1412) * pesototal1412;
        //    peso1412 = Math.Round(peso1412, 4);
        //    if (peso1412 > pesototal1412)
        //    {
        //        peso1412 = pesototal1412;
        //    }
        //    pesototal = pesototal + peso1412;
        //}
        //num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + ".</b> Publicaciones impresas y/o digitales (2  de los procesos y resultados de los grupos de investigación  y  de los resultados de la implementación del proyecto). </td>";
        //ca += "<td class='center'>" + count1412 + " de " + total1412 + "</td>";
        //ca += "<td class='center'>" + meta1412 + "%</td>";
        //ca += "<td class='center'>" + peso1412 + "</td>";
        //ca += "<td class='noExl center'><a href='#?sg=true'><img src='images/detalles.png'>Ver</a></td>";
        //ca += "</tr>";


       

        

       

        

        /*---------------*/

        ca += "<tr>";
        ca += "<td></td>";
        ca += "<td></td>";
        ca += "<td></td>";
        ca += "<td>TOTAL</td>";
        ca += "<td>" + pesototal + "</td>";

        ca += "</tr>";

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string inscribieronconvocatoria()
    {
        string ca = "";
        Consultas c = new Consultas();
        DataTable totalgrupoinveinscritos = c.totalGruposInvestigacionInscritos();

        if (totalgrupoinveinscritos != null && totalgrupoinveinscritos.Rows.Count > 0)
        {
            for (int i = 0; i < totalgrupoinveinscritos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i+1) + "</td>";
                ca += "<td>" + totalgrupoinveinscritos.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + totalgrupoinveinscritos.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + totalgrupoinveinscritos.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + totalgrupoinveinscritos.Rows[i]["pregunta"].ToString() + "</td>";
                ca += "<td>" + totalgrupoinveinscritos.Rows[i]["tipo"].ToString() + "</td>";
                ca += "<td>" + totalgrupoinveinscritos.Rows[i]["linea"].ToString() + "</td>";
                ca += "<td>" + totalgrupoinveinscritos.Rows[i]["concepto"].ToString() + "</td>";
                ca += "</tr>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string ninosinscribieronconvocatoria(string codDepartamento, string codMunicipio, string codInstitucion, string codSede)
    {
        string ca = "";
        Estrategias est = new Estrategias();
        DataTable datos = est.estudianesengp(codDepartamento, codMunicipio, codInstitucion, codSede);

        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["identificacion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombre"].ToString() + "</td>";
                ca += "</tr>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string grupoinvestigacionpregunta(string codDepartamento, string codMunicipio, string codInstitucion, string codSede)
    {
        string ca = "";
        Estrategias est = new Estrategias();
        DataTable datos = est.totalGPHicieronPreguntas(codDepartamento, codMunicipio, codInstitucion, codSede);

        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["nombremunicipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombreins"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombresede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombregrupo"].ToString() + "</td>";
                ca += "</tr>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string grupoinvestigacionproblema(string codDepartamento, string codMunicipio, string codInstitucion, string codSede)
    {
        string ca = "";
        Estrategias est = new Estrategias();
        DataTable datos = est.totalGPHicieronPreguntasB3(codDepartamento, codMunicipio, codInstitucion, codSede);

        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["nombremunicipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombreins"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombresede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombregrupo"].ToString() + "</td>";
                ca += "</tr>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string grupoinvestigacionrecursos(string codDepartamento, string codMunicipio, string codInstitucion, string codSede)
    {
        string ca = "";
        Consultas c = new Consultas();
        DataTable datos = c.cargarGruposInvestigacionRecursosAportadosCiclón(codDepartamento, codMunicipio, codInstitucion, codSede);

        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombregrupo"].ToString() + "</td>";
                ca += "</tr>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string grupoinvestigacionavancepresupuesto(string codDepartamento, string codMunicipio, string codInstitucion, string codSede)
    {
        string ca = "";
        Estrategias c = new Estrategias();
        DataTable datos = c.gruposInvestigacionPresupuestoEvidencias(codDepartamento, codMunicipio, codInstitucion, codSede);

        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["nombremunicipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombreins"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombresede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombregrupo"].ToString() + "</td>";
                ca += "</tr>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string grupoinvestigacionavancepresupuesto2desembolso(string codDepartamento, string codMunicipio, string codInstitucion, string codSede)
    {
        string ca = "";
        Consultas c = new Consultas();
        DataTable datos = c.cargarGruposInformeFinancieroDesembolso(codDepartamento, codMunicipio, codInstitucion, codSede, "2");

        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombregrupo"].ToString() + "</td>";
                ca += "</tr>";
            }
        }

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string grupoinvestigacionavancepresupuesto3desembolso(string codDepartamento, string codMunicipio, string codInstitucion, string codSede)
    {
        string ca = "";
        Consultas c = new Consultas();
        DataTable datos = c.cargarGruposInformeFinancieroDesembolso(codDepartamento, codMunicipio, codInstitucion, codSede, "3");

        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombregrupo"].ToString() + "</td>";
                ca += "</tr>";
            }
        }

        return ca;
    }
   
   
       [WebMethod(EnableSession = true)]
    public static string grupoinvestigacioninformesinvestigacion(string codDepartamento, string codMunicipio, string codInstitucion, string codSede)
    {
        string ca = "";
        Estrategias c = new Estrategias();
        DataTable datos = c.informesinvelavoradosgp(codDepartamento, codMunicipio, codInstitucion, codSede);

        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombregrupo"].ToString() + "</td>";
                ca += "</tr>";
            }
        }

        return ca;
    }

           [WebMethod(EnableSession = true)]
    public static string grupoinvestigacioninformesinvestigacionabierto(string codDepartamento, string codMunicipio, string codInstitucion, string codSede)
    {
        string ca = "";
        Estrategias c = new Estrategias();
        DataTable datos = c.informeinvestiabierto();

        if (datos != null && datos.Rows.Count > 0)
        {
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + (i + 1) + "</td>";
                ca += "<td>" + datos.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + datos.Rows[i]["nombregrupo"].ToString() + "</td>";
                ca += "</tr>";
            }
        }

        return ca;
    }

       [WebMethod(EnableSession = true)]
       public static string gruposinvestigacionasesoriasrealizadas(string codDepartamento, string codMunicipio, string codInstitucion, string codSede)
       {
           string ca = "";
           Estrategias c = new Estrategias();
           DataTable datos = c.noAsesoriasGP(codDepartamento, codMunicipio, codInstitucion, codSede);

           if (datos != null && datos.Rows.Count > 0)
           {
               for (int i = 0; i < datos.Rows.Count; i++)
               {
                   ca += "<tr>";
                   ca += "<td>" + (i + 1) + "</td>";
                   ca += "<td>" + datos.Rows[i]["nombremunicipio"].ToString() + "</td>";
                   ca += "<td>" + datos.Rows[i]["nombreins"].ToString() + "</td>";
                   ca += "<td>" + datos.Rows[i]["nombresede"].ToString() + "</td>";
                   ca += "<td>" + datos.Rows[i]["nombregrupo"].ToString() + "</td>";
                   ca += "</tr>";
               }
           }

           return ca;
       }

       //cargar municipios
       [WebMethod(EnableSession = true)]
       public static string cargarInsMun(string codDepartamento)
       {
           string ca = "";

           Institucion inst = new Institucion();

           

           DataTable datos = inst.cargarciudadxDepartamento(codDepartamento);
           if (datos != null && datos.Rows.Count > 0)
           {
               ca += "mun@";
               ca += "<option value='' selected>Todos</option>";
               for (int i = 0; i < datos.Rows.Count; i++)
               {
                   ca += "<option value='" + datos.Rows[i]["cod"].ToString() + "'>" + datos.Rows[i]["nombre"].ToString() + "</option>";
               }
           }

           return ca;
       }
}