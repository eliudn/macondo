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

public partial class menusegestrategia2 : System.Web.UI.Page
{
    Funciones fun = new Funciones();
    Estrategias est = new Estrategias();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 
        if (!IsPostBack)
        {
            if (Session["codrol"] != null)
            {
               
                if (Session["codrol"].ToString() == "18")//Asesor CUC
                {
                   // accordion.InnerHtml = MenuAcordeonGerencia();

                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }

    //[WebMethod(EnableSession = true)]
    //public static string cargardatos()
    //{
    //    string ca = "";
    //    int num = 0;
    //    double pesototal = 0;
    //    Estrategias est = new Estrategias();
    //    Consultas c = new Consultas();

    //    DataTable estra2JornadaFormacion1 = est.estra2JornadaFormacion("", "", "", "", "1", "1", "1");
    //    DataTable estra2JornadaFormacion2 = est.estra2JornadaFormacion("", "", "", "", "1", "1", "2");

    //    int jornada1 = estra2JornadaFormacion1.Rows.Count;
    //    int jornada2 = estra2JornadaFormacion2.Rows.Count;
    //    int jornadatotal1y2 = 0;
    //    if (jornada1 < jornada2)
    //    {
    //        jornadatotal1y2 = jornada1;
    //    }
    //    else
    //    {
    //        jornadatotal1y2 = jornada2;
    //    }
       

    //    Sesiones de formación No. 1 realizadas
    //    double meta1 = 0;
    //    int count1 = 0;
    //    int total1 = 320;
    //    double pesototal1 = 1.3071;
    //    double peso1 = 0;
    //    if ((estra2JornadaFormacion1 != null && estra2JornadaFormacion1.Rows.Count > 0) || (estra2JornadaFormacion2 != null && estra2JornadaFormacion2.Rows.Count > 0))
    //    {
    //        count1 = jornadatotal1y2;
    //        meta1 = ((double)count1 / (double)total1) * 100;
    //        meta1 = Math.Round(meta1, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }
    //        count1 = estra2JornadaFormacion1.Rows.Count;

    //        peso1 = ((double)count1 / (double)total1) * pesototal1;
    //        peso1 = Math.Round(peso1, 4);
    //        if (peso1 > pesototal1)
    //        {
    //            peso1 = pesototal1;
    //        }
    //        pesototal = pesototal + peso1;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Sesión No. 1, Jornada No. 1 y No. 2 realizadas  </td>";
    //    ca += "<td class='center'>" + jornadatotal1y2 + " de " + total1 + "</td>";
    //    ca += "<td class='center'>" + meta1 + "%</td>";
    //    ca += "<td class='center'>" + peso1 + "%</td>";
    //    ca += "<td class='noExl center'><a href='estra2jornadaformacion.aspx?m=1&s=1&j=1'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 1/jornada de actualización No. 1 (5 horas)
    //    double metasja1 = 0;
    //    int countsja1 = 0;
    //    DataTable sesionvirtualsja1 = c.cargarDocentesEnSesionesJornadasEstra2("", "", "", "", "2", "1","1");
    //    int totalsja1 = 3386;
    //    double pesosja1 = 1.3071;
    //    double pesoActsja1 = 0;
    //    if (sesionvirtualsja1 != null && sesionvirtualsja1.Rows.Count > 0)
    //    {
    //        countsja1 = sesionvirtualsja1.Rows.Count;


    //        metasja1 = ((double)countsja1 / (double)totalsja1) * 100;
    //        metasja1 = Math.Round(metasja1, 2);

    //        pesoActsja1 = ((double)countsja1 / (double)totalsja1) * pesosja1;
    //        pesoActsja1 = Math.Round(pesoActsja1, 4);
    //        if (pesoActsja1 > pesosja1)
    //        {
    //            pesoActsja1 = pesosja1;
    //        }
    //        pesototal = pesototal + pesoActsja1;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 1/jornada de actualización No. 1 (5 horas)</td>";
    //    ca += "<td class='center'>" + countsja1 + " de " + totalsja1 + "</td>";
    //    ca += "<td class='center'>" + metasja1 + "%</td>";
    //    ca += "<td class='center'>" + pesoActsja1 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 1/formación virtual (4 horas)
    //    double metas1 = 0;
    //    int counts1 = 0;
    //    DataTable sesionvirtuals1 = c.cargarListadoSesionVirtualEstraDos("", "", "", "", "1", "g");
    //    int totals1 = 3386;
    //    double pesos1 = 1.3071;
    //    double pesoActs1 = 0;
    //    if (sesionvirtuals1 != null && sesionvirtuals1.Rows.Count > 0)
    //    {
    //        if (sesionvirtuals1.Rows[0]["virtual"].ToString() != "0")
    //            counts1 = Convert.ToInt32(sesionvirtuals1.Rows[0]["virtual"].ToString());


    //        metas1 = ((double)counts1 / (double)totals1) * 100;
    //        metas1 = Math.Round(metas1, 2);

    //        pesoActs1 = ((double)counts1 / (double)totals1) * pesos1;
    //        pesoActs1 = Math.Round(pesoActs1, 4);
    //        if (pesoActs1 > pesos1)
    //        {
    //            pesoActs1 = pesos1;
    //        }
    //        pesototal = pesototal + pesoActs1;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 1/formación virtual (4 horas)</td>";
    //    ca += "<td class='center'>" + counts1 + " de " + totals1 + "</td>";
    //    ca += "<td class='center'>" + metas1 + "%</td>";
    //    ca += "<td class='center'>" + pesoActs1 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//Esto no tiene el detalle para calcular los docentes asistidos 
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 1/ autoformación (2 horas)
    //    double metasa1 = 0;
    //    int countsa1 = 0;
    //    DataTable sesionvirtualsa1 = c.cargarListadoSesionVirtualEstraDos("", "", "", "", "1", "g");
    //    int totalsa1 = 3386;
    //    double pesosa1 = 1.3071;
    //    double pesoActsa1 = 0;
    //    if (sesionvirtualsa1 != null && sesionvirtualsa1.Rows.Count > 0)
    //    {
    //        if (sesionvirtualsa1.Rows[0]["autoformacion"].ToString() != "0")
    //            countsa1 = Convert.ToInt32(sesionvirtualsa1.Rows[0]["autoformacion"].ToString());


    //        metasa1 = ((double)countsa1 / (double)totalsa1) * 100;
    //        metasa1 = Math.Round(metasa1, 2);

    //        pesoActsa1 = ((double)countsa1 / (double)totalsa1) * pesosa1;
    //        pesoActsa1 = Math.Round(pesoActsa1, 4);
    //        if (pesoActsa1 > pesosa1)
    //        {
    //            pesoActsa1 = pesosa1;
    //        }
    //        pesototal = pesototal + pesoActsa1;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 1/ autoformación (2 horas)</td>";
    //    ca += "<td class='center'>" + countsa1 + " de " + totalsa1 + "</td>";
    //    ca += "<td class='center'>" + metasa1 + "%</td>";
    //    ca += "<td class='center'>" + pesoActsa1 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//Esto no tiene el detalle para calcular los docentes asistidos 
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 1/ producción (2 horas)
    //    double metasp1 = 0;
    //    int countsp1 = 0;
    //    DataTable sesionvirtualsp1 = c.cargarListadoSesionVirtualEstraDos("", "", "", "", "1", "g");
    //    DataTable sesionvirtualsp1 = est.estra2JornadaFormacion("", "", "", "", "1", "1", "2");
    //    int totalsp1 = 3386;
    //    double pesosp1 = 1.3071;
    //    double pesoActsp1 = 0;
    //    if (sesionvirtualsp1 != null && sesionvirtualsp1.Rows.Count > 0)
    //    {
    //        if (sesionvirtualsp1.Rows[0]["produccion"].ToString() != "0")
    //            countsp1 = Convert.ToInt32(sesionvirtualsp1.Rows[0]["produccion"].ToString());
    //        countsp1 = sesionvirtualsp1.Rows.Count;

    //        metasp1 = ((double)countsp1 / (double)totalsp1) * 100;
    //        metasp1 = Math.Round(metasp1, 2);

    //        pesoActsp1 = ((double)countsp1 / (double)totalsp1) * pesosp1;
    //        pesoActsp1 = Math.Round(pesoActsp1, 4);
    //        if (pesoActsp1 > pesosp1)
    //        {
    //            pesoActsp1 = pesosp1;
    //        }
    //        pesototal = pesototal + pesoActsp1;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 1/ producción (4 horas)</td>";
    //    ca += "<td class='center'>" + countsp1 + " de " + totalsp1 + "</td>";
    //    ca += "<td class='center'>" + metasp1 + "%</td>";
    //    ca += "<td class='center'>" + pesoActsp1 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//Esto no tiene el detalle para calcular los docentes asistidos
    //    ca += "</tr>";

    //    Sesión 1, Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).

    //    DataTable sesionesevidenciass1 = c.sesionesformacionevaluadas("", "", "", "", "2", "1", "1", "Relatoria institucional");

    //    double metases1 = 0;
    //    int countses1 = 0;
    //    int totalses1 = 320;
    //    double pesototalses1 = 1.3071;
    //    double pesoses1 = 0;
    //    if ((sesionesevidenciass1 != null && sesionesevidenciass1.Rows.Count > 0))
    //    {
    //        countses1 = sesionesevidenciass1.Rows.Count;
    //        metases1 = ((double)countses1 / (double)totalses1) * 100;
    //        metases1 = Math.Round(metases1, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesoses1 = ((double)countses1 / (double)totalses1) * pesototalses1;
    //        pesoses1 = Math.Round(pesoses1, 4);
    //        if (pesoses1 > pesototalses1)
    //        {
    //            pesoses1 = pesototalses1;
    //        }
    //        pesototal = pesototal + pesoses1;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).</td>";
    //    ca += "<td class='center'>" + countses1 + " de " + totalses1 + "</td>";
    //    ca += "<td class='center'>" + metases1 + "%</td>";
    //    ca += "<td class='center'>" + pesoses1 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";

    //    Sesión 1, Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.

    //    DataTable sesionesevidenciasfe1 = c.sesionesformacionevaluadas("", "", "", "", "2", "1", "1", "Formato de evaluación");

    //    double metasfe1 = 0;
    //    int countsfe1 = 0;
    //    int totalsfe1 = 320;
    //    double pesototalsfe1 = 1.3071;
    //    double pesosfe1 = 0;
    //    if ((sesionesevidenciasfe1 != null && sesionesevidenciasfe1.Rows.Count > 0))
    //    {
    //        countsfe1 = sesionesevidenciasfe1.Rows.Count;
    //        metasfe1 = ((double)countsfe1 / (double)totalsfe1) * 100;
    //        metasfe1 = Math.Round(metasfe1, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesosfe1 = ((double)countsfe1 / (double)totalsfe1) * pesototalsfe1;
    //        pesosfe1 = Math.Round(pesosfe1, 4);
    //        if (pesosfe1 > pesototalsfe1)
    //        {
    //            pesosfe1 = pesototalsfe1;
    //        }
    //        pesototal = pesototal + pesosfe1;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.</td>";
    //    ca += "<td class='center'>" + countsfe1 + " de " + totalsfe1 + "</td>";
    //    ca += "<td class='center'>" + metasfe1 + "%</td>";
    //    ca += "<td class='center'>" + pesosfe1 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";
        

    //    Sesiones de formación No. 2 realizadas
    //    DataTable estra2JornadaFormacion3 = est.estra2JornadaFormacion("", "", "", "", "3", "2", "3");
    //    DataTable estra2JornadaFormacion4 = est.estra2JornadaFormacion("", "", "", "", "3", "2", "4");

    //    int jornada3 = estra2JornadaFormacion3.Rows.Count;
    //    int jornada4 = estra2JornadaFormacion4.Rows.Count;
    //    int jornadatotal3y4 = 0;
    //    if (jornada3 < jornada4)
    //    {
    //        jornadatotal3y4 = jornada3;
    //    }
    //    else
    //    {
    //        jornadatotal3y4 = jornada4;
    //    }

    //    double meta1f3 = 0;
    //    int count1f3 = 0;
    //    int total1f3 = 320;
    //    double pesototalf3 = 1.3071;
    //    double pesof3 = 0;
    //    if ((estra2JornadaFormacion3 != null && estra2JornadaFormacion3.Rows.Count > 0) || estra2JornadaFormacion4 != null && estra2JornadaFormacion4.Rows.Count > 0)
    //    {
    //        count1f3 = jornadatotal3y4;
    //        meta1f3 = ((double)count1f3 / (double)total1f3) * 100;
    //        meta1f3 = Math.Round(meta1f3, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }
    //        count1f3 = estra2JornadaFormacion3.Rows.Count;

    //        pesof3 = ((double)count1f3 / (double)total1f3) * pesototalf3;
    //        pesof3 = Math.Round(pesof3, 4);
    //        if (pesof3 > pesototalf3)
    //        {
    //            pesof3 = pesototalf3;
    //        }
    //        pesototal = pesototal + pesof3;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num +".</b> Sesión No. 2, Jornada No. 3 y No. 4 realizadas  </td>";
    //    ca += "<td class='center'>" + jornadatotal3y4 + " de " + total1f3 + "</td>";
    //    ca += "<td class='center'>" + meta1f3 + "%</td>";
    //    ca += "<td class='center'>" + pesof3 + "%</td>";
    //    ca += "<td class='noExl center'><a href='estra2jornadaformacion.aspx?m=3&s=2&j=3'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
    //    ca += "</tr>";


    //     Asistentes a la sesión de formación No. 2/jornada de actualización No. 1 (5 horas)
    //    double metasja2 = 0;
    //    int countsja2 = 0;
    //    DataTable sesionvirtualsja2 = c.cargarDocentesEnSesionesJornadasEstra2("", "", "", "", "2", "3", "2");
    //    int totalsja2 = 3386;
    //    double pesosja2 = 1.3071;
    //    double pesoActsja2 = 0;
    //    if (sesionvirtualsja2 != null && sesionvirtualsja2.Rows.Count > 0)
    //    {
    //        countsja2 = sesionvirtualsja2.Rows.Count;


    //        metasja2 = ((double)countsja2 / (double)totalsja2) * 100;
    //        metasja2 = Math.Round(metasja2, 2);

    //        pesoActsja2 = ((double)countsja2 / (double)totalsja2) * pesosja2;
    //        pesoActsja2 = Math.Round(pesoActsja2, 4);
    //        if (pesoActsja2 > pesosja2)
    //        {
    //            pesoActsja2 = pesosja2;
    //        }
    //        pesototal = pesototal + pesoActsja2;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 2/jornada de actualización No. 3 (5 horas)</td>";
    //    ca += "<td class='center'>" + countsja2 + " de " + totalsja2 + "</td>";
    //    ca += "<td class='center'>" + metasja2 + "%</td>";
    //    ca += "<td class='center'>" + pesoActsja2 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";


    //     Asistentes a la sesión de formación No. 1/formación virtual (4 horas)
    //    double metas2 = 0;
    //    int counts2 = 0;
    //    DataTable sesionvirtuals2 = c.cargarListadoSesionVirtualEstraDos("", "", "", "", "2", "g");
    //    int totals2 = 3386;
    //    double pesos2 = 1.3071;
    //    double pesoActs2 = 0;
    //    if (sesionvirtuals2 != null && sesionvirtuals2.Rows.Count > 0)
    //    {
    //        if (sesionvirtuals2.Rows[0]["virtual"].ToString() != "0")
    //            counts2 = Convert.ToInt32(sesionvirtuals1.Rows[0]["virtual"].ToString());


    //        metas2 = ((double)counts2 / (double)totals2) * 100;
    //        metas2 = Math.Round(metas2, 2);

    //        pesoActs2 = ((double)counts2 / (double)totals2) * pesos2;
    //        pesoActs2 = Math.Round(pesoActs2, 4);
    //        if (pesoActs2 > pesos2)
    //        {
    //            pesoActs2 = pesos2;
    //        }
    //        pesototal = pesototal + pesoActs2;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 2/formación virtual (4 horas)</td>";
    //    ca += "<td class='center'>" + counts2 + " de " + totals2 + "</td>";
    //    ca += "<td class='center'>" + metas2 + "%</td>";
    //    ca += "<td class='center'>" + pesoActs2 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//Esto no tiene el detalle para calcular los docentes asistidos 
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 2/ autoformación (2 horas)
    //    double metasa2 = 0;
    //    int countsa2 = 0;
    //    DataTable sesionvirtualsa2 = c.cargarListadoSesionVirtualEstraDos("", "", "", "", "2", "g");
    //    int totalsa2 = 3386;
    //    double pesosa2 = 1.3071;
    //    double pesoActsa2 = 0;
    //    if (sesionvirtualsa2 != null && sesionvirtualsa2.Rows.Count > 0)
    //    {
    //        if (sesionvirtualsa2.Rows[0]["autoformacion"].ToString() != "0")
    //            countsa2 = Convert.ToInt32(sesionvirtualsa2.Rows[0]["autoformacion"].ToString());


    //        metasa2 = ((double)countsa2 / (double)totalsa2) * 100;
    //        metasa2 = Math.Round(metasa2, 2);

    //        pesoActsa2 = ((double)countsa2 / (double)totalsa2) * pesosa2;
    //        pesoActsa2 = Math.Round(pesoActsa2, 4);
    //        if (pesoActsa2 > pesosa2)
    //        {
    //            pesoActsa2 = pesosa2;
    //        }
    //        pesototal = pesototal + pesoActsa2;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 2/ autoformación (2 horas)</td>";
    //    ca += "<td class='center'>" + countsa2 + " de " + totalsa2 + "</td>";
    //    ca += "<td class='center'>" + metasa2 + "%</td>";
    //    ca += "<td class='center'>" + pesoActsa2 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//Esto no tiene el detalle para calcular los docentes asistidos 
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 2/ producción (2 horas)
    //    double metasp2 = 0;
    //    int countsp2 = 0;
    //    DataTable sesionvirtualsp2 = c.cargarListadoSesionVirtualEstraDos("", "", "", "", "2", "g");
    //    DataTable sesionvirtualsp2 = est.estra2JornadaFormacion("", "", "", "", "3", "2", "4");
    //    int totalsp2 = 3386;
    //    double pesosp2 = 1.3071;
    //    double pesoActsp2 = 0;
    //    if (sesionvirtualsp2 != null && sesionvirtualsp2.Rows.Count > 0)
    //    {
    //        if (sesionvirtualsp2.Rows[0]["produccion"].ToString() != "0")
    //            countsp2 = Convert.ToInt32(sesionvirtualsp2.Rows[0]["produccion"].ToString());
    //        countsp2 = sesionvirtualsp2.Rows.Count;

    //        metasp2 = ((double)countsp2 / (double)totalsp2) * 100;
    //        metasp2 = Math.Round(metasp2, 2);

    //        pesoActsp2 = ((double)countsp2 / (double)totalsp2) * pesosp2;
    //        pesoActsp2 = Math.Round(pesoActsp2, 4);
    //        if (pesoActsp2 > pesosp2)
    //        {
    //            pesoActsp2 = pesosp2;
    //        }
    //        pesototal = pesototal + pesoActsp2;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 2/ producción (4 horas)</td>";
    //    ca += "<td class='center'>" + countsp2 + " de " + totalsp2 + "</td>";
    //    ca += "<td class='center'>" + metasp2 + "%</td>";
    //    ca += "<td class='center'>" + pesoActsp2 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//Esto no tiene el detalle para calcular los docentes asistidos
    //    ca += "</tr>";

    //    Sesión 2, Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).

    //    DataTable sesionesevidenciass2 = c.sesionesformacionevaluadas("", "", "", "", "2", "3", "2", "Relatoria institucional");

    //    double metases2 = 0;
    //    int countses2 = 0;
    //    int totalses2 = 320;
    //    double pesototalses2 = 1.3071;
    //    double pesoses2 = 0;
    //    if ((sesionesevidenciass2 != null && sesionesevidenciass2.Rows.Count > 0))
    //    {
    //        countses2 = sesionesevidenciass2.Rows.Count;
    //        metases2 = ((double)countses2 / (double)totalses2) * 100;
    //        metases2 = Math.Round(metases2, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesoses2 = ((double)countses2 / (double)totalses2) * pesototalses2;
    //        pesoses2 = Math.Round(pesoses2, 4);
    //        if (pesoses2 > pesototalses2)
    //        {
    //            pesoses2 = pesototalses2;
    //        }
    //        pesototal = pesototal + pesoses2;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).</td>";
    //    ca += "<td class='center'>" + countses2 + " de " + totalses2 + "</td>";
    //    ca += "<td class='center'>" + metases2 + "%</td>";
    //    ca += "<td class='center'>" + pesoses2 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";

    //    Sesión 2, Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.

    //    DataTable sesionesevidenciasfe2 = c.sesionesformacionevaluadas("", "", "", "", "2", "3", "2", "Formato de evaluación");

    //    double metasfe2 = 0;
    //    int countsfe2 = 0;
    //    int totalsfe2 = 320;
    //    double pesototalsfe2 = 1.3071;
    //    double pesosfe2 = 0;
    //    if ((sesionesevidenciasfe2 != null && sesionesevidenciasfe2.Rows.Count > 0))
    //    {
    //        countsfe2 = sesionesevidenciasfe2.Rows.Count;
    //        metasfe2 = ((double)countsfe2 / (double)totalsfe2) * 100;
    //        metasfe2 = Math.Round(metasfe2, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesosfe2 = ((double)countsfe2 / (double)totalsfe2) * pesototalsfe2;
    //        pesosfe2 = Math.Round(pesosfe2, 4);
    //        if (pesosfe2 > pesototalsfe2)
    //        {
    //            pesosfe2 = pesototalsfe2;
    //        }
    //        pesototal = pesototal + pesosfe2;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.</td>";
    //    ca += "<td class='center'>" + countsfe2 + " de " + totalsfe2 + "</td>";
    //    ca += "<td class='center'>" + metasfe2 + "%</td>";
    //    ca += "<td class='center'>" + pesosfe2 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";

    //    Sesión 3 de formación No. 5 y 6 realizadas
    //    DataTable estra2JornadaFormacion5 = est.estra2JornadaFormacion("", "", "", "", "4", "3", "5");
    //    DataTable estra2JornadaFormacion6 = est.estra2JornadaFormacion("", "", "", "", "4", "3", "6");

    //    int jornada5 = estra2JornadaFormacion5.Rows.Count;
    //    int jornada6 = estra2JornadaFormacion6.Rows.Count;
    //    int jornadatotal5y6 = 0;
    //    if (jornada5 < jornada6)
    //    {
    //        jornadatotal5y6 = jornada5;
    //    }
    //    else
    //    {
    //        jornadatotal5y6 = jornada6;
    //    }

    //    double meta1f5 = 0;
    //    int count1f5 = 0;
    //    int total1f5 = 320;
    //    double pesototal1f5 = 1.3071;
    //    double peso1f5 = 0;
    //    if ((estra2JornadaFormacion5 != null && estra2JornadaFormacion5.Rows.Count > 0) || estra2JornadaFormacion6 != null && estra2JornadaFormacion6.Rows.Count > 0)
    //    {
    //        count1f5 = jornadatotal5y6;
    //        meta1f5 = ((double)count1f5 / (double)total1f5) * 100;
    //        meta1f5 = Math.Round(meta1f5, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }
    //        peso1f5 = ((double)count1f5 / (double)total1f5) * pesototal1f5;
    //        peso1f5 = Math.Round(peso1f5, 4);
    //        if (peso1f5 > pesototal1f5)
    //        {
    //            peso1f5 = pesototal1f5;
    //        }
    //        pesototal = pesototal + peso1f5;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Sesión No. 3, Jornada No. 5 y No. 6 realizadas  </td>";
    //    ca += "<td class='center'>" + jornadatotal5y6 + " de " + total1f5 + "</td>";
    //    ca += "<td class='center'>" + meta1f5 + "%</td>";
    //    ca += "<td class='center'>" + peso1f5 + "%</td>";
    //    ca += "<td class='noExl center'><a href='estra2jornadaformacion.aspx?m=4&s=3&j=5'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
    //    ca += "</tr>";


    //     Asistentes a la sesión de formación No. 3/jornada de actualización No. 5 (5 horas)
    //    double metasja3 = 0;
    //    int countsja3 = 0;
    //    DataTable sesionvirtualsja3 = c.cargarDocentesEnSesionesJornadasEstra2("", "", "", "", "2", "4", "3");
    //    int totalsja3 = 3386;
    //    double pesosja3 = 1.3071;
    //    double pesoActsja3 = 0;
    //    if (sesionvirtualsja3 != null && sesionvirtualsja3.Rows.Count > 0)
    //    {
    //        countsja3 = sesionvirtualsja3.Rows.Count;


    //        metasja3 = ((double)countsja3 / (double)totalsja3) * 100;
    //        metasja3 = Math.Round(metasja3, 2);

    //        pesoActsja3 = ((double)countsja3 / (double)totalsja3) * pesosja3;
    //        pesoActsja3 = Math.Round(pesoActsja3, 4);
    //        if (pesoActsja3 > pesosja3)
    //        {
    //            pesoActsja3 = pesosja3;
    //        }
    //        pesototal = pesototal + pesoActsja3;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 3/jornada de actualización No. 5 (5 horas)</td>";
    //    ca += "<td class='center'>" + countsja3 + " de " + totalsja3 + "</td>";
    //    ca += "<td class='center'>" + metasja3 + "%</td>";
    //    ca += "<td class='center'>" + pesoActsja3 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";


    //     Asistentes a la sesión de formación No. 3/formación virtual (4 horas)
    //    double metas3 = 0;
    //    int counts3 = 0;
    //    DataTable sesionvirtuals3 = c.cargarListadoSesionVirtualEstraDos("", "", "", "", "3", "g");
    //    int totals3 = 3386;
    //    double pesos3 = 1.3071;
    //    double pesoActs3 = 0;
    //    if (sesionvirtuals3 != null && sesionvirtuals3.Rows.Count > 0)
    //    {
    //        if (sesionvirtuals3.Rows[0]["virtual"].ToString() != "0")
    //            counts3 = Convert.ToInt32(sesionvirtuals3.Rows[0]["virtual"].ToString());


    //        metas3 = ((double)counts3 / (double)totals3) * 100;
    //        metas3 = Math.Round(metas3, 2);

    //        pesoActs3 = ((double)counts3 / (double)totals3) * pesos3;
    //        pesoActs3 = Math.Round(pesoActs3, 4);
    //        if (pesoActs3 > pesos3)
    //        {
    //            pesoActs3 = pesos3;
    //        }
    //        pesototal = pesototal + pesoActs3;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 3/formación virtual (4 horas)</td>";
    //    ca += "<td class='center'>" + counts3 + " de " + totals3 + "</td>";
    //    ca += "<td class='center'>" + metas3 + "%</td>";
    //    ca += "<td class='center'>" + pesoActs3 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//Esto no tiene el detalle para calcular los docentes asistidos 
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 3/ autoformación (2 horas)
    //    double metasa3 = 0;
    //    int countsa3 = 0;
    //    DataTable sesionvirtualsa3 = c.cargarListadoSesionVirtualEstraDos("", "", "", "", "3", "g");
    //    int totalsa3 = 3386;
    //    double pesosa3 = 1.3071;
    //    double pesoActsa3 = 0;
    //    if (sesionvirtualsa3 != null && sesionvirtualsa3.Rows.Count > 0)
    //    {
    //        if (sesionvirtualsa3.Rows[0]["autoformacion"].ToString() != "0")
    //            countsa2 = Convert.ToInt32(sesionvirtualsa3.Rows[0]["autoformacion"].ToString());


    //        metasa3 = ((double)countsa3 / (double)totalsa3) * 100;
    //        metasa3 = Math.Round(metasa3, 2);

    //        pesoActsa3 = ((double)countsa3 / (double)totalsa3) * pesosa3;
    //        pesoActsa3 = Math.Round(pesoActsa3, 4);
    //        if (pesoActsa3 > pesosa3)
    //        {
    //            pesoActsa3 = pesosa3;
    //        }
    //        pesototal = pesototal + pesoActsa3;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 3/ autoformación (2 horas)</td>";
    //    ca += "<td class='center'>" + countsa3 + " de " + totalsa3 + "</td>";
    //    ca += "<td class='center'>" + metasa3 + "%</td>";
    //    ca += "<td class='center'>" + pesoActsa3 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//Esto no tiene el detalle para calcular los docentes asistidos 
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 3/ producción (2 horas)
    //    double metasp3 = 0;
    //    int countsp3 = 0;
    //    DataTable sesionvirtualsp3 = c.cargarListadoSesionVirtualEstraDos("", "", "", "", "3", "g");
    //    DataTable sesionvirtualsp3 = est.estra2JornadaFormacion("", "", "", "", "4", "3", "6");
    //    int totalsp3 = 3386;
    //    double pesosp3 = 1.3071;
    //    double pesoActsp3 = 0;
    //    if (sesionvirtualsp3 != null && sesionvirtualsp3.Rows.Count > 0)
    //    {
    //        if (sesionvirtualsp3.Rows[0]["produccion"].ToString() != "0")
    //            countsp3 = Convert.ToInt32(sesionvirtualsp3.Rows[0]["produccion"].ToString());

    //        countsp3 = sesionvirtualsp3.Rows.Count;


    //        metasp3 = ((double)countsp3 / (double)totalsp3) * 100;
    //        metasp3 = Math.Round(metasp3, 2);

    //        pesoActsp3 = ((double)countsp3 / (double)totalsp3) * pesosp3;
    //        pesoActsp3 = Math.Round(pesoActsp3, 4);
    //        if (pesoActsp3 > pesosp3)
    //        {
    //            pesoActsp3 = pesosp3;
    //        }
    //        pesototal = pesototal + pesoActsp3;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 3/ producción (4 horas)</td>";
    //    ca += "<td class='center'>" + countsp2 + " de " + totalsp2 + "</td>";
    //    ca += "<td class='center'>" + metasp2 + "%</td>";
    //    ca += "<td class='center'>" + pesoActsp2 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//Esto no tiene el detalle para calcular los docentes asistidos
    //    ca += "</tr>";

    //    Sesión 3, Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).

    //    DataTable sesionesevidenciass3 = c.sesionesformacionevaluadas("", "", "", "", "2", "4", "3", "Relatoria institucional");

    //    double metases3 = 0;
    //    int countses3 = 0;
    //    int totalses3 = 320;
    //    double pesototalses3 = 1.3071;
    //    double pesoses3 = 0;
    //    if ((sesionesevidenciass3 != null && sesionesevidenciass3.Rows.Count > 0))
    //    {
    //        countses3 = sesionesevidenciass3.Rows.Count;
    //        metases3 = ((double)countses3 / (double)totalses3) * 100;
    //        metases3 = Math.Round(metases3, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesoses3 = ((double)countses3 / (double)totalses3) * pesototalses3;
    //        pesoses3 = Math.Round(pesoses3, 4);
    //        if (pesoses3 > pesototalses3)
    //        {
    //            pesoses3 = pesototalses3;
    //        }
    //        pesototal = pesototal + pesoses3;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).</td>";
    //    ca += "<td class='center'>" + countses3 + " de " + totalses3 + "</td>";
    //    ca += "<td class='center'>" + metases3 + "%</td>";
    //    ca += "<td class='center'>" + pesoses3 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";

    //    Sesión 3, Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.

    //    DataTable sesionesevidenciasfe3 = c.sesionesformacionevaluadas("", "", "", "", "2", "4", "3", "Formato de evaluación");

    //    double metasfe3 = 0;
    //    int countsfe3 = 0;
    //    int totalsfe3 = 320;
    //    double pesototalsfe3 = 1.3071;
    //    double pesosfe3 = 0;
    //    if ((sesionesevidenciasfe3 != null && sesionesevidenciasfe3.Rows.Count > 0))
    //    {
    //        countsfe3 = sesionesevidenciasfe3.Rows.Count;
    //        metasfe3 = ((double)countsfe3 / (double)totalsfe3) * 100;
    //        metasfe3 = Math.Round(metasfe3, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesosfe3 = ((double)countsfe3 / (double)totalsfe3) * pesototalsfe3;
    //        pesosfe3 = Math.Round(pesosfe3, 4);
    //        if (pesosfe3 > pesototalsfe3)
    //        {
    //            pesosfe3 = pesototalsfe3;
    //        }
    //        pesototal = pesototal + pesosfe3;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.</td>";
    //    ca += "<td class='center'>" + countsfe3 + " de " + totalsfe3 + "</td>";
    //    ca += "<td class='center'>" + metasfe3 + "%</td>";
    //    ca += "<td class='center'>" + pesosfe3 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";

    //    Sesión 4 de formación No. 7 y 8 realizadas
    //    DataTable estra2JornadaFormacion7 = est.estra2JornadaFormacion("", "", "", "", "4", "4", "7");
    //    DataTable estra2JornadaFormacion8 = est.estra2JornadaFormacion("", "", "", "", "4", "4", "8");

    //    int jornada7 = estra2JornadaFormacion7.Rows.Count;
    //    int jornada8 = estra2JornadaFormacion8.Rows.Count;
    //    int jornadatotal7y8 = 0;
    //    if (jornada7 < jornada8)
    //    {
    //        jornadatotal7y8 = jornada7;
    //    }
    //    else
    //    {
    //        jornadatotal7y8 = jornada8;
    //    }

    //    double meta7y8 = 0;
    //    int count7y8 = 0;
    //    int total7y8 = 320;
    //    double pesototal7y8 = 1.3071;
    //    double peso7y8 = 0;
    //    if ((estra2JornadaFormacion7 != null && estra2JornadaFormacion7.Rows.Count > 0) || estra2JornadaFormacion8 != null && estra2JornadaFormacion8.Rows.Count > 0)
    //    {
    //        count7y8 = jornadatotal7y8;
    //        meta7y8 = ((double)count7y8 / (double)total7y8) * 100;
    //        meta7y8 = Math.Round(meta7y8, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        peso7y8 = ((double)count7y8 / (double)total7y8) * pesototal7y8;
    //        peso7y8 = Math.Round(peso7y8, 4);
    //        if (peso7y8 > pesototal7y8)
    //        {
    //            peso7y8 = pesototal7y8;
    //        }
    //        pesototal = pesototal + peso7y8;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Sesión No. 4, Jornada No. 7 y No. 8 realizadas  </td>";
    //    ca += "<td class='center'>" + jornadatotal7y8 + " de " + total7y8 + "</td>";
    //    ca += "<td class='center'>" + meta7y8 + "%</td>";
    //    ca += "<td class='center'>" + peso7y8 + "%</td>";
    //    ca += "<td class='noExl center'><a href='estra2jornadaformacion.aspx?m=4&s=4&j=7'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 4/jornada de actualización No. 7 (5 horas)
    //    double metasja4 = 0;
    //    int countsja4 = 0;
    //    DataTable sesionvirtualsja4 = c.cargarDocentesEnSesionesJornadasEstra2("", "", "", "", "2", "4", "4");
    //    int totalsja4 = 3386;
    //    double pesosja4 = 1.3071;
    //    double pesoActsja4 = 0;
    //    if (sesionvirtualsja4 != null && sesionvirtualsja4.Rows.Count > 0)
    //    {
    //        countsja4 = sesionvirtualsja4.Rows.Count;


    //        metasja4 = ((double)countsja4 / (double)totalsja4) * 100;
    //        metasja4 = Math.Round(metasja4, 2);

    //        pesoActsja4 = ((double)countsja4 / (double)totalsja4) * pesosja4;
    //        pesoActsja4 = Math.Round(pesoActsja4, 4);
    //        if (pesoActsja4 > pesosja4)
    //        {
    //            pesoActsja3 = pesosja4;
    //        }
    //        pesototal = pesototal + pesoActsja4;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 4/jornada de actualización No. 7 (5 horas)</td>";
    //    ca += "<td class='center'>" + countsja4 + " de " + totalsja4 + "</td>";
    //    ca += "<td class='center'>" + metasja4 + "%</td>";
    //    ca += "<td class='center'>" + pesoActsja4 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 4/formación virtual (4 horas)
    //    double metas4 = 0;
    //    int counts4 = 0;
    //    DataTable sesionvirtuals4 = c.cargarListadoSesionVirtualEstraDos("", "", "", "", "4", "g");
    //    int totals4 = 3386;
    //    double pesos4 = 1.3071;
    //    double pesoActs4 = 0;
    //    if (sesionvirtuals4 != null && sesionvirtuals4.Rows.Count > 0)
    //    {
    //        if (sesionvirtuals4.Rows[0]["virtual"].ToString() != "0")
    //            counts4 = Convert.ToInt32(sesionvirtuals4.Rows[0]["virtual"].ToString());


    //        metas4 = ((double)counts4 / (double)totals4) * 100;
    //        metas4 = Math.Round(metas4, 2);

    //        pesoActs4 = ((double)counts4 / (double)totals4) * pesos4;
    //        pesoActs4 = Math.Round(pesoActs4, 4);
    //        if (pesoActs4 > pesos4)
    //        {
    //            pesoActs4 = pesos4;
    //        }
    //        pesototal = pesototal + pesoActs4;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 4/formación virtual (4 horas)</td>";
    //    ca += "<td class='center'>" + counts4 + " de " + totals4 + "</td>";
    //    ca += "<td class='center'>" + metas4 + "%</td>";
    //    ca += "<td class='center'>" + pesoActs4 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//Esto no tiene el detalle para calcular los docentes asistidos 
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 4/ autoformación (2 horas)
    //    double metasa4 = 0;
    //    int countsa4 = 0;
    //    DataTable sesionvirtualsa4 = c.cargarListadoSesionVirtualEstraDos("", "", "", "", "4", "g");
    //    int totalsa4 = 3386;
    //    double pesosa4 = 1.3071;
    //    double pesoActsa4 = 0;
    //    if (sesionvirtualsa4 != null && sesionvirtualsa4.Rows.Count > 0)
    //    {
    //        if (sesionvirtualsa4.Rows[0]["autoformacion"].ToString() != "0")
    //            countsa4 = Convert.ToInt32(sesionvirtualsa4.Rows[0]["autoformacion"].ToString());


    //        metasa4 = ((double)countsa4 / (double)totalsa4) * 100;
    //        metasa4 = Math.Round(metasa4, 2);

    //        pesoActsa4 = ((double)countsa4 / (double)totalsa4) * pesosa2;
    //        pesoActsa4 = Math.Round(pesoActsa4, 4);
    //        if (pesoActsa4 > pesosa4)
    //        {
    //            pesoActsa4 = pesosa4;
    //        }
    //        pesototal = pesototal + pesoActsa4;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 4/ autoformación (2 horas)</td>";
    //    ca += "<td class='center'>" + countsa4 + " de " + totalsa4 + "</td>";
    //    ca += "<td class='center'>" + metasa4 + "%</td>";
    //    ca += "<td class='center'>" + pesoActsa4 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//Esto no tiene el detalle para calcular los docentes asistidos 
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 4/ producción (2 horas)
    //    double metasp4 = 0;
    //    int countsp4 = 0;
    //    DataTable sesionvirtualsp4 = c.cargarListadoSesionVirtualEstraDos("", "", "", "", "4", "g");
    //    DataTable sesionvirtualsp4 = est.estra2JornadaFormacion("", "", "", "", "4", "4", "8");
    //    int totalsp4 = 3386;
    //    double pesosp4 = 1.3071;
    //    double pesoActsp4 = 0;
    //    if (sesionvirtualsp4 != null && sesionvirtualsp4.Rows.Count > 0)
    //    {
    //        if (sesionvirtualsp4.Rows[0]["produccion"].ToString() != "0")
    //            countsp4 = Convert.ToInt32(sesionvirtualsp4.Rows[0]["produccion"].ToString());

    //            countsp4 = sesionvirtualsp4.Rows.Count;


    //        metasp4 = ((double)countsp4 / (double)totalsp4) * 100;
    //        metasp4 = Math.Round(metasp4, 2);

    //        pesoActsp4 = ((double)countsp4 / (double)totalsp4) * pesosp4;
    //        pesoActsp4 = Math.Round(pesoActsp4, 4);
    //        if (pesoActsp4 > pesosp4)
    //        {
    //            pesoActsp4 = pesosp4;
    //        }
    //        pesototal = pesototal + pesoActsp4;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 4/ producción (4 horas)</td>";
    //    ca += "<td class='center'>" + countsp4 + " de " + totalsp4 + "</td>";
    //    ca += "<td class='center'>" + metasp4 + "%</td>";
    //    ca += "<td class='center'>" + pesoActsp4 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//Esto no tiene el detalle para calcular los docentes asistidos
    //    ca += "</tr>";

    //    Sesión 4, Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).

    //    DataTable sesionesevidenciass4 = c.sesionesformacionevaluadas("", "", "", "", "2", "4", "4", "Relatoria institucional");

    //    double metases4 = 0;
    //    int countses4 = 0;
    //    int totalses4 = 320;
    //    double pesototalses4 = 1.3071;
    //    double pesoses4 = 0;
    //    if ((sesionesevidenciass4 != null && sesionesevidenciass4.Rows.Count > 0))
    //    {
    //        countses4 = sesionesevidenciass4.Rows.Count;
    //        metases4 = ((double)countses4 / (double)totalses4) * 100;
    //        metases4 = Math.Round(metases4, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesoses4 = ((double)countses4 / (double)totalses4) * pesototalses4;
    //        pesoses4 = Math.Round(pesoses4, 4);
    //        if (pesoses4 > pesototalses4)
    //        {
    //            pesoses4 = pesototalses4;
    //        }
    //        pesototal = pesototal + pesoses4;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).</td>";
    //    ca += "<td class='center'>" + countses4 + " de " + totalses4 + "</td>";
    //    ca += "<td class='center'>" + metases4 + "%</td>";
    //    ca += "<td class='center'>" + pesoses4 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";

    //    Sesión 4, Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.

    //    DataTable sesionesevidenciasfe4 = c.sesionesformacionevaluadas("", "", "", "", "2", "4", "1", "Formato de evaluación");

    //    double metasfe4 = 0;
    //    int countsfe4 = 0;
    //    int totalsfe4 = 320;
    //    double pesototalsfe4 = 1.3071;
    //    double pesosfe4 = 0;
    //    if ((sesionesevidenciasfe4 != null && sesionesevidenciasfe4.Rows.Count > 0))
    //    {
    //        countsfe4 = sesionesevidenciasfe4.Rows.Count;
    //        metasfe4 = ((double)countsfe4 / (double)totalsfe4) * 100;
    //        metasfe4 = Math.Round(metasfe4, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesosfe4 = ((double)countsfe4 / (double)totalsfe4) * pesototalsfe4;
    //        pesosfe4 = Math.Round(pesosfe4, 4);
    //        if (pesosfe4 > pesototalsfe4)
    //        {
    //            pesosfe4 = pesototalsfe4;
    //        }
    //        pesototal = pesototal + pesosfe4;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.</td>";
    //    ca += "<td class='center'>" + countsfe4 + " de " + totalsfe4 + "</td>";
    //    ca += "<td class='center'>" + metasfe4 + "%</td>";
    //    ca += "<td class='center'>" + pesosfe4 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";
        
    //    Sesión 5 de formación No. 9 y 10 realizadas
    //    DataTable estra2JornadaFormacion9 = est.estra2JornadaFormacion("", "", "", "", "4", "5", "9");
    //    DataTable estra2JornadaFormacion10 = est.estra2JornadaFormacion("", "", "", "", "4", "5", "10");

    //    int jornada9 = estra2JornadaFormacion9.Rows.Count;
    //    int jornada10 = estra2JornadaFormacion10.Rows.Count;
    //    int jornadatotal9y10 = 0;
    //    if (jornada9 < jornada10)
    //    {
    //        jornadatotal9y10 = jornada9;
    //    }
    //    else
    //    {
    //        jornadatotal9y10 = jornada10;
    //    }

    //    double meta9y10 = 0;
    //    int count9y10 = 0;
    //    int total9y10 = 320;
    //    double pesototal9y10 = 1.3071;
    //    double peso9y10 = 0;
    //    if ((estra2JornadaFormacion9 != null && estra2JornadaFormacion9.Rows.Count > 0) || estra2JornadaFormacion10 != null && estra2JornadaFormacion10.Rows.Count > 0)
    //    {
    //        count9y10 = jornadatotal9y10;
    //        meta9y10 = ((double)count9y10 / (double)total9y10) * 100;
    //        meta9y10 = Math.Round(meta9y10, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        peso9y10 = ((double)count9y10 / (double)total9y10) * pesototal9y10;
    //        peso9y10 = Math.Round(peso9y10, 4);
    //        if (peso9y10 > pesototal9y10)
    //        {
    //            peso9y10 = pesototal9y10;
    //        }
    //        pesototal = pesototal + peso9y10;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Sesión No. 5, Jornada No. 9 y No. 10 realizadas  </td>";
    //    ca += "<td class='center'>" + jornadatotal9y10 + " de " + total9y10 + "</td>";
    //    ca += "<td class='center'>" + meta9y10 + "%</td>";
    //    ca += "<td class='center'>" + peso9y10 + "%</td>";
    //    ca += "<td class='noExl center'><a href='estra2jornadaformacion.aspx?m=4&s=5&j=9'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 5/jornada de actualización No. 9 (5 horas)
    //    double metasja5 = 0;
    //    int countsja5 = 0;
    //    DataTable sesionvirtualsja5 = c.cargarDocentesEnSesionesJornadasEstra2("", "", "", "", "2", "4", "5");
    //    int totalsja5 = 3386;
    //    double pesosja5 = 1.3071;
    //    double pesoActsja5 = 0;
    //    if (sesionvirtualsja5 != null && sesionvirtualsja5.Rows.Count > 0)
    //    {
    //        countsja5 = sesionvirtualsja5.Rows.Count;


    //        metasja5 = ((double)countsja5 / (double)totalsja5) * 100;
    //        metasja5 = Math.Round(metasja5, 2);

    //        pesoActsja5 = ((double)countsja5 / (double)totalsja5) * pesosja5;
    //        pesoActsja5 = Math.Round(pesoActsja5, 4);
    //        if (pesoActsja5 > pesosja5)
    //        {
    //            pesoActsja5 = pesosja5;
    //        }
    //        pesototal = pesototal + pesoActsja5;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 5/jornada de actualización No. 9 (5 horas)</td>";
    //    ca += "<td class='center'>" + countsja5 + " de " + totalsja5 + "</td>";
    //    ca += "<td class='center'>" + metasja5 + "%</td>";
    //    ca += "<td class='center'>" + pesoActsja5 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";


    //     Asistentes a la sesión de formación No. 5/formación virtual (4 horas)
    //    double metas5 = 0;
    //    int counts5 = 0;
    //    DataTable sesionvirtuals5 = c.cargarListadoSesionVirtualEstraDos("", "", "", "", "5", "g");
    //    int totals5 = 3386;
    //    double pesos5 = 1.3071;
    //    double pesoActs5 = 0;
    //    if (sesionvirtuals4 != null && sesionvirtuals4.Rows.Count > 0)
    //    {
    //        if (sesionvirtuals5.Rows[0]["virtual"].ToString() != "0")
    //            counts5 = Convert.ToInt32(sesionvirtuals5.Rows[0]["virtual"].ToString());


    //        metas5 = ((double)counts5 / (double)totals5) * 100;
    //        metas5 = Math.Round(metas5, 2);

    //        pesoActs5 = ((double)counts5 / (double)totals5) * pesos5;
    //        pesoActs5 = Math.Round(pesoActs5, 4);
    //        if (pesoActs5 > pesos5)
    //        {
    //            pesoActs5 = pesos5;
    //        }
    //        pesototal = pesototal + pesoActs5;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 5/formación virtual (4 horas)</td>";
    //    ca += "<td class='center'>" + counts5 + " de " + totals5 + "</td>";
    //    ca += "<td class='center'>" + metas5 + "%</td>";
    //    ca += "<td class='center'>" + pesoActs5 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//Esto no tiene el detalle para calcular los docentes asistidos 
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 5/ autoformación (2 horas)
    //    double metasa5 = 0;
    //    int countsa5 = 0;
    //    DataTable sesionvirtualsa5 = c.cargarListadoSesionVirtualEstraDos("", "", "", "", "5", "g");
    //    int totalsa5 = 3386;
    //    double pesosa5 = 1.3071;
    //    double pesoActsa5 = 0;
    //    if (sesionvirtualsa5 != null && sesionvirtualsa5.Rows.Count > 0)
    //    {
    //        if (sesionvirtualsa5.Rows[0]["autoformacion"].ToString() != "0")
    //            countsa5 = Convert.ToInt32(sesionvirtualsa5.Rows[0]["autoformacion"].ToString());


    //        metasa5 = ((double)countsa5 / (double)totalsa5) * 100;
    //        metasa5 = Math.Round(metasa5, 2);

    //        pesoActsa5 = ((double)countsa5 / (double)totalsa5) * pesosa5;
    //        pesoActsa5 = Math.Round(pesoActsa5, 4);
    //        if (pesoActsa5 > pesosa5)
    //        {
    //            pesoActsa5 = pesosa5;
    //        }
    //        pesototal = pesototal + pesoActsa5;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 5/ autoformación (2 horas)</td>";
    //    ca += "<td class='center'>" + countsa5 + " de " + totalsa5 + "</td>";
    //    ca += "<td class='center'>" + metasa5 + "%</td>";
    //    ca += "<td class='center'>" + pesoActsa5 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//Esto no tiene el detalle para calcular los docentes asistidos 
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 5/ producción (2 horas)
    //    double metasp5 = 0;
    //    int countsp5 = 0;
    //    DataTable sesionvirtualsp5 = c.cargarListadoSesionVirtualEstraDos("", "", "", "", "5", "g");
    //    DataTable sesionvirtualsp5 = est.estra2JornadaFormacion("", "", "", "", "4", "5", "10");
    //    int totalsp5 = 3386;
    //    double pesosp5 = 1.3071;
    //    double pesoActsp5 = 0;
    //    if (sesionvirtualsp5 != null && sesionvirtualsp5.Rows.Count > 0)
    //    {
    //        if (sesionvirtualsp5.Rows[0]["produccion"].ToString() != "0")
    //            countsp5 = Convert.ToInt32(sesionvirtualsp5.Rows[0]["produccion"].ToString());

    //            countsp5 = sesionvirtualsp5.Rows.Count;


    //        metasp5 = ((double)countsp5 / (double)totalsp5) * 100;
    //        metasp5 = Math.Round(metasp5, 2);

    //        pesoActsp5 = ((double)countsp5 / (double)totalsp5) * pesosp5;
    //        pesoActsp5 = Math.Round(pesoActsp5, 4);
    //        if (pesoActsp5 > pesosp5)
    //        {
    //            pesoActsp5 = pesosp5;
    //        }
    //        pesototal = pesototal + pesoActsp5;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 5/ producción (4 horas)</td>";
    //    ca += "<td class='center'>" + countsp5 + " de " + totalsp5 + "</td>";
    //    ca += "<td class='center'>" + metasp5 + "%</td>";
    //    ca += "<td class='center'>" + pesoActsp5 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//Esto no tiene el detalle para calcular los docentes asistidos
    //    ca += "</tr>";

    //    Sesión 5, Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).

    //    DataTable sesionesevidenciass5 = c.sesionesformacionevaluadas("", "", "", "", "2", "4", "5", "Relatoria institucional");

    //    double metases5 = 0;
    //    int countses5 = 0;
    //    int totalses5 = 320;
    //    double pesototalses5= 1.3071;
    //    double pesoses5 = 0;
    //    if ((sesionesevidenciass5 != null && sesionesevidenciass5.Rows.Count > 0))
    //    {
    //        countses5 = sesionesevidenciass5.Rows.Count;
    //        metases5 = ((double)countses5 / (double)totalses5) * 100;
    //        metases5 = Math.Round(metases5, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesoses5 = ((double)countses5 / (double)totalses5) * pesototalses5;
    //        pesoses5 = Math.Round(pesoses5, 4);
    //        if (pesoses5 > pesototalses5)
    //        {
    //            pesoses5 = pesototalses5;
    //        }
    //        pesototal = pesototal + pesoses5;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).</td>";
    //    ca += "<td class='center'>" + countses5 + " de " + totalses5 + "</td>";
    //    ca += "<td class='center'>" + metases5 + "%</td>";
    //    ca += "<td class='center'>" + pesoses5 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";

    //    Sesión 5, Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.

    //    DataTable sesionesevidenciasfe5 = c.sesionesformacionevaluadas("", "", "", "", "2", "4", "5", "Formato de evaluación");

    //    double metasfe5 = 0;
    //    int countsfe5 = 0;
    //    int totalsfe5 = 320;
    //    double pesototalsfe5 = 1.3071;
    //    double pesosfe5 = 0;
    //    if ((sesionesevidenciasfe5 != null && sesionesevidenciasfe5.Rows.Count > 0))
    //    {
    //        countsfe5 = sesionesevidenciasfe5.Rows.Count;
    //        metasfe5 = ((double)countsfe5 / (double)totalsfe5) * 100;
    //        metasfe5 = Math.Round(metasfe5, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesosfe5 = ((double)countsfe5 / (double)totalsfe5) * pesototalsfe5;
    //        pesosfe5 = Math.Round(pesosfe5, 4);
    //        if (pesosfe5 > pesototalsfe5)
    //        {
    //            pesosfe5 = pesototalsfe5;
    //        }
    //        pesototal = pesototal + pesosfe5;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.</td>";
    //    ca += "<td class='center'>" + countsfe5 + " de " + totalsfe5 + "</td>";
    //    ca += "<td class='center'>" + metasfe5 + "%</td>";
    //    ca += "<td class='center'>" + pesosfe5 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";


    //    Sesión 6 de formación No. 11 y 12 realizadas
    //    DataTable estra2JornadaFormacion11 = est.estra2JornadaFormacion("", "", "", "", "4", "6", "11");
    //    DataTable estra2JornadaFormacion12 = est.estra2JornadaFormacion("", "", "", "", "4", "6", "12");

    //    int jornada11 = estra2JornadaFormacion11.Rows.Count;
    //    int jornada12 = estra2JornadaFormacion12.Rows.Count;
    //    int jornadatotal11y12 = 0;
    //    if (jornada11 < jornada12)
    //    {
    //        jornadatotal11y12 = jornada11;
    //    }
    //    else
    //    {
    //        jornadatotal11y12 = jornada12;
    //    }

    //    double meta11y12 = 0;
    //    int count11y12 = 0;
    //    int total11y12 = 320;
    //    double pesototal11y12 = 1.3071;
    //    double peso11y12 = 0;
    //    if ((estra2JornadaFormacion11 != null && estra2JornadaFormacion11.Rows.Count > 0) || estra2JornadaFormacion12 != null && estra2JornadaFormacion12.Rows.Count > 0)
    //    {
    //        count11y12 = jornadatotal11y12;
    //        meta11y12 = ((double)count11y12 / (double)total11y12) * 100;
    //        meta11y12 = Math.Round(meta11y12, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        peso11y12 = ((double)count11y12 / (double)total11y12) * pesototal11y12;
    //        peso11y12 = Math.Round(peso11y12, 4);
    //        if (peso11y12 > pesototal11y12)
    //        {
    //            peso11y12 = pesototal11y12;
    //        }
    //        pesototal = pesototal + peso11y12;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Sesión No. 6, Jornada No. 11 y No. 12 realizadas  </td>";
    //    ca += "<td class='center'>" + jornadatotal11y12 + " de " + total11y12 + "</td>";
    //    ca += "<td class='center'>" + meta11y12 + "%</td>";
    //    ca += "<td class='center'>" + peso11y12 + "%</td>";
    //    ca += "<td class='noExl center'><a href='estra2jornadaformacion.aspx?m=4&s=6&j=11'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 3/jornada de actualización No. 5 (5 horas)
    //    double metasja6 = 0;
    //    int countsja6 = 0;
    //    DataTable sesionvirtualsja6 = c.cargarDocentesEnSesionesJornadasEstra2("", "", "", "", "2", "4", "6");
    //    int totalsja6 = 3386;
    //    double pesosja6 = 1.3071;
    //    double pesoActsja6 = 0;
    //    if (sesionvirtualsja6 != null && sesionvirtualsja6.Rows.Count > 0)
    //    {
    //        countsja6 = sesionvirtualsja6.Rows.Count;


    //        metasja6 = ((double)countsja6 / (double)totalsja6) * 100;
    //        metasja6 = Math.Round(metasja6, 2);

    //        pesoActsja6 = ((double)countsja6 / (double)totalsja6) * pesosja6;
    //        pesoActsja6 = Math.Round(pesoActsja6, 4);
    //        if (pesoActsja6 > pesosja6)
    //        {
    //            pesoActsja3 = pesosja6;
    //        }
    //        pesototal = pesototal + pesoActsja6;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 6/jornada de actualización No. 11 (5 horas)</td>";
    //    ca += "<td class='center'>" + countsja6 + " de " + totalsja6 + "</td>";
    //    ca += "<td class='center'>" + metasja6 + "%</td>";
    //    ca += "<td class='center'>" + pesoActsja6 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 6/formación virtual (4 horas)
    //    double metas6 = 0;
    //    int counts6 = 0;
    //    DataTable sesionvirtuals6 = c.cargarListadoSesionVirtualEstraDos("", "", "", "", "6", "g");
    //    int totals6 = 3386;
    //    double pesos6 = 1.3071;
    //    double pesoActs6 = 0;
    //    if (sesionvirtuals6 != null && sesionvirtuals6.Rows.Count > 0)
    //    {
    //        if (sesionvirtuals6.Rows[0]["virtual"].ToString() != "0")
    //            counts6 = Convert.ToInt32(sesionvirtuals6.Rows[0]["virtual"].ToString());


    //        metas6 = ((double)counts6 / (double)totals6) * 100;
    //        metas6 = Math.Round(metas6, 2);

    //        pesoActs6 = ((double)counts6 / (double)totals6) * pesos6;
    //        pesoActs6 = Math.Round(pesoActs6, 4);
    //        if (pesoActs6 > pesos6)
    //        {
    //            pesoActs6 = pesos6;
    //        }
    //        pesototal = pesototal + pesoActs6;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 6/formación virtual (4 horas)</td>";
    //    ca += "<td class='center'>" + counts6 + " de " + totals6 + "</td>";
    //    ca += "<td class='center'>" + metas6 + "%</td>";
    //    ca += "<td class='center'>" + pesoActs6 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//Esto no tiene el detalle para calcular los docentes asistidos 
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 6/ autoformación (2 horas)
    //    double metasa6 = 0;
    //    int countsa6 = 0;
    //    DataTable sesionvirtualsa6 = c.cargarListadoSesionVirtualEstraDos("", "", "", "", "6", "g");
    //    int totalsa6 = 3386;
    //    double pesosa6 = 1.3071;
    //    double pesoActsa6 = 0;
    //    if (sesionvirtualsa6 != null && sesionvirtualsa6.Rows.Count > 0)
    //    {
    //        if (sesionvirtualsa6.Rows[0]["autoformacion"].ToString() != "0")
    //            countsa6 = Convert.ToInt32(sesionvirtualsa6.Rows[0]["autoformacion"].ToString());


    //        metasa6 = ((double)countsa6 / (double)totalsa6) * 100;
    //        metasa6 = Math.Round(metasa6, 2);

    //        pesoActsa6 = ((double)countsa6 / (double)totalsa6) * pesosa6;
    //        pesoActsa6 = Math.Round(pesoActsa6, 4);
    //        if (pesoActsa6 > pesosa6)
    //        {
    //            pesoActsa4 = pesosa6;
    //        }
    //        pesototal = pesototal + pesoActsa6;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 6/ autoformación (2 horas)</td>";
    //    ca += "<td class='center'>" + countsa6 + " de " + totalsa6 + "</td>";
    //    ca += "<td class='center'>" + metasa6 + "%</td>";
    //    ca += "<td class='center'>" + pesoActsa6 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//Esto no tiene el detalle para calcular los docentes asistidos 
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 6/ producción (2 horas)
    //    double metasp6 = 0;
    //    int countsp6 = 0;
    //    DataTable sesionvirtualsp6 = c.cargarListadoSesionVirtualEstraDos("", "", "", "", "6", "g");
    //    DataTable sesionvirtualsp6 = est.estra2JornadaFormacion("", "", "", "", "4", "6", "12");
    //    int totalsp6 = 3386;
    //    double pesosp6 = 1.3071;
    //    double pesoActsp6 = 0;
    //    if (sesionvirtualsp6 != null && sesionvirtualsp6.Rows.Count > 0)
    //    {
    //        if (sesionvirtualsp6.Rows[0]["produccion"].ToString() != "0")
    //            countsp6 = Convert.ToInt32(sesionvirtualsp6.Rows[0]["produccion"].ToString());


    //        countsp6 = sesionvirtualsp6.Rows.Count;

    //        metasp6 = ((double)countsp6 / (double)totalsp6) * 100;
    //        metasp6 = Math.Round(metasp6, 2);

    //        pesoActsp6 = ((double)countsp6 / (double)totalsp6) * pesosp6;
    //        pesoActsp6 = Math.Round(pesoActsp6, 4);
    //        if (pesoActsp6 > pesosp6)
    //        {
    //            pesoActsp4 = pesosp6;
    //        }
    //        pesototal = pesototal + pesoActsp6;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 6/ producción (4 horas)</td>";
    //    ca += "<td class='center'>" + countsp6 + " de " + totalsp6 + "</td>";
    //    ca += "<td class='center'>" + metasp6 + "%</td>";
    //    ca += "<td class='center'>" + pesoActsp6 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//Esto no tiene el detalle para calcular los docentes asistidos
    //    ca += "</tr>";

    //    Sesión 6, Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).

    //    DataTable sesionesevidenciass6 = c.sesionesformacionevaluadas("", "", "", "", "2", "4", "6", "Relatoria institucional");

    //    double metases6 = 0;
    //    int countses6 = 0;
    //    int totalses6 = 320;
    //    double pesototalses6 = 1.3071;
    //    double pesoses6 = 0;
    //    if ((sesionesevidenciass6 != null && sesionesevidenciass6.Rows.Count > 0))
    //    {
    //        countses6 = sesionesevidenciass6.Rows.Count;
    //        metases6 = ((double)countses6 / (double)totalses6) * 100;
    //        metases6 = Math.Round(metases6, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesoses6 = ((double)countses6 / (double)totalses6) * pesototalses6;
    //        pesoses6 = Math.Round(pesoses6, 4);
    //        if (pesoses6 > pesototalses6)
    //        {
    //            pesoses6 = pesototalses6;
    //        }
    //        pesototal = pesototal + pesoses6;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).</td>";
    //    ca += "<td class='center'>" + countses6 + " de " + totalses6 + "</td>";
    //    ca += "<td class='center'>" + metases6 + "%</td>";
    //    ca += "<td class='center'>" + pesoses6 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";

    //    Sesión 6, Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.

    //    DataTable sesionesevidenciasfe6 = c.sesionesformacionevaluadas("", "", "", "", "2", "4", "6", "Formato de evaluación");

    //    double metasfe6 = 0;
    //    int countsfe6 = 0;
    //    int totalsfe6 = 320;
    //    double pesototalsfe6 = 1.3071;
    //    double pesosfe6 = 0;
    //    if ((sesionesevidenciasfe6 != null && sesionesevidenciasfe6.Rows.Count > 0))
    //    {
    //        countsfe6 = sesionesevidenciasfe6.Rows.Count;
    //        metasfe6 = ((double)countsfe6 / (double)totalsfe6) * 100;
    //        metasfe6 = Math.Round(metasfe6, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesosfe6 = ((double)countsfe6 / (double)totalsfe6) * pesototalsfe6;
    //        pesosfe6 = Math.Round(pesosfe6, 4);
    //        if (pesosfe6 > pesototalsfe6)
    //        {
    //            pesosfe6 = pesototalsfe6;
    //        }
    //        pesototal = pesototal + pesosfe6;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.</td>";
    //    ca += "<td class='center'>" + countsfe6 + " de " + totalsfe6 + "</td>";
    //    ca += "<td class='center'>" + metasfe6 + "%</td>";
    //    ca += "<td class='center'>" + pesosfe6 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";


    //    Sesión 7 de formación No. 13 y 14 realizadas
    //    DataTable estra2JornadaFormacion13 = est.estra2JornadaFormacion("", "", "", "", "5", "7", "13");
    //    DataTable estra2JornadaFormacion14 = est.estra2JornadaFormacion("", "", "", "", "5", "7", "14");

    //    int jornada13 = estra2JornadaFormacion13.Rows.Count;
    //    int jornada14 = estra2JornadaFormacion14.Rows.Count;
    //    int jornadatotal13y14 = 0;
    //    if (jornada13 < jornada14)
    //    {
    //        jornadatotal13y14 = jornada13;
    //    }
    //    else
    //    {
    //        jornadatotal13y14 = jornada14;
    //    }

    //    double meta13y14 = 0;
    //    int count13y14 = 0;
    //    int total13y14 = 320;
    //    double pesototal13y14 = 1.3071;
    //    double peso13y14 = 0;
    //    if ((estra2JornadaFormacion13 != null && estra2JornadaFormacion13.Rows.Count > 0) || estra2JornadaFormacion14 != null && estra2JornadaFormacion14.Rows.Count > 0)
    //    {
    //        count13y14 = jornadatotal13y14;
    //        meta13y14 = ((double)count13y14 / (double)total13y14) * 100;
    //        meta13y14 = Math.Round(meta13y14, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        peso13y14 = ((double)count13y14 / (double)total13y14) * pesototal13y14;
    //        peso13y14 = Math.Round(peso13y14, 4);
    //        if (peso13y14 > pesototal13y14)
    //        {
    //            peso13y14 = pesototal13y14;
    //        }
    //        pesototal = pesototal + peso13y14;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Sesión No. 7, Jornada No. 13 y No. 14 realizadas  </td>";
    //    ca += "<td class='center'>" + jornadatotal13y14 + " de " + total13y14 + "</td>";
    //    ca += "<td class='center'>" + meta13y14 + "%</td>";
    //    ca += "<td class='center'>" + peso13y14 + "%</td>";
    //    ca += "<td class='noExl center'><a href='estra2jornadaformacion.aspx?m=5&s=7&j=13'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 3/jornada de actualización No. 5 (5 horas)
    //    double metasja7 = 0;
    //    int countsja7 = 0;
    //    DataTable sesionvirtualsja7 = c.cargarDocentesEnSesionesJornadasEstra2("", "", "", "", "2", "5", "7");
    //    int totalsja7 = 3386;
    //    double pesosja7 = 1.3071;
    //    double pesoActsja7 = 0;
    //    if (sesionvirtualsja7 != null && sesionvirtualsja7.Rows.Count > 0)
    //    {
    //        countsja7 = sesionvirtualsja7.Rows.Count;


    //        metasja7 = ((double)countsja7 / (double)totalsja7) * 100;
    //        metasja7 = Math.Round(metasja7, 2);

    //        pesoActsja7 = ((double)countsja7 / (double)totalsja7) * pesosja7;
    //        pesoActsja7 = Math.Round(pesoActsja7, 4);
    //        if (pesoActsja7 > pesosja7)
    //        {
    //            pesoActsja7 = pesosja7;
    //        }
    //        pesototal = pesototal + pesoActsja7;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 7/jornada de actualización No. 13 (5 horas)</td>";
    //    ca += "<td class='center'>" + countsja7 + " de " + totalsja7 + "</td>";
    //    ca += "<td class='center'>" + metasja7 + "%</td>";
    //    ca += "<td class='center'>" + pesoActsja7 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 4/formación virtual (4 horas)
    //    double metas7 = 0;
    //    int counts7 = 0;
    //    DataTable sesionvirtuals7 = c.cargarListadoSesionVirtualEstraDos("", "", "", "", "7", "g");
    //    int totals7 = 3386;
    //    double pesos7 = 1.3071;
    //    double pesoActs7 = 0;
    //    if (sesionvirtuals7 != null && sesionvirtuals7.Rows.Count > 0)
    //    {
    //        if (sesionvirtuals7.Rows[0]["virtual"].ToString() != "0")
    //            counts7 = Convert.ToInt32(sesionvirtuals7.Rows[0]["virtual"].ToString());


    //        metas7 = ((double)counts7 / (double)totals7) * 100;
    //        metas7 = Math.Round(metas7, 2);

    //        pesoActs7 = ((double)counts7 / (double)totals7) * pesos7;
    //        pesoActs7 = Math.Round(pesoActs7, 4);
    //        if (pesoActs7 > pesos7)
    //        {
    //            pesoActs7 = pesos7;
    //        }
    //        pesototal = pesototal + pesoActs7;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 7/formación virtual (4 horas)</td>";
    //    ca += "<td class='center'>" + counts7 + " de " + totals7 + "</td>";
    //    ca += "<td class='center'>" + metas7 + "%</td>";
    //    ca += "<td class='center'>" + pesoActs7 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//Esto no tiene el detalle para calcular los docentes asistidos 
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 7/ autoformación (2 horas)
    //    double metasa7 = 0;
    //    int countsa7 = 0;
    //    DataTable sesionvirtualsa7 = c.cargarListadoSesionVirtualEstraDos("", "", "", "", "7", "g");
    //    int totalsa7 = 3386;
    //    double pesosa7 = 1.3071;
    //    double pesoActsa7 = 0;
    //    if (sesionvirtualsa7 != null && sesionvirtualsa7.Rows.Count > 0)
    //    {
    //        if (sesionvirtualsa7.Rows[0]["autoformacion"].ToString() != "0")
    //            countsa7 = Convert.ToInt32(sesionvirtualsa7.Rows[0]["autoformacion"].ToString());


    //        metasa7 = ((double)countsa7 / (double)totalsa7) * 100;
    //        metasa7 = Math.Round(metasa7, 2);

    //        pesoActsa7 = ((double)countsa7 / (double)totalsa7) * pesosa7;
    //        pesoActsa7 = Math.Round(pesoActsa7, 4);
    //        if (pesoActsa7 > pesosa7)
    //        {
    //            pesoActsa4 = pesosa7;
    //        }
    //        pesototal = pesototal + pesoActsa7;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 7/ autoformación (2 horas)</td>";
    //    ca += "<td class='center'>" + countsa7 + " de " + totalsa7 + "</td>";
    //    ca += "<td class='center'>" + metasa7 + "%</td>";
    //    ca += "<td class='center'>" + pesoActsa7 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//Esto no tiene el detalle para calcular los docentes asistidos 
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 4/ producción (2 horas)
    //    double metasp7 = 0;
    //    int countsp7 = 0;
    //    DataTable sesionvirtualsp7 = c.cargarListadoSesionVirtualEstraDos("", "", "", "", "7", "g");
    //    DataTable sesionvirtualsp7 = est.estra2JornadaFormacion("", "", "", "", "5", "7", "14");
    //    int totalsp7 = 3386;
    //    double pesosp7 = 1.3071;
    //    double pesoActsp7 = 0;
    //    if (sesionvirtualsp7 != null && sesionvirtualsp7.Rows.Count > 0)
    //    {
    //        if (sesionvirtualsp7.Rows[0]["produccion"].ToString() != "0")
    //            countsp7 = Convert.ToInt32(sesionvirtualsp7.Rows[0]["produccion"].ToString());

    //        countsp7 = sesionvirtualsp7.Rows.Count;


    //        metasp7 = ((double)countsp7 / (double)totalsp7) * 100;
    //        metasp7 = Math.Round(metasp7, 2);

    //        pesoActsp7 = ((double)countsp7 / (double)totalsp7) * pesosp7;
    //        pesoActsp7 = Math.Round(pesoActsp7, 4);
    //        if (pesoActsp7 > pesosp7)
    //        {
    //            pesoActsp4 = pesosp7;
    //        }
    //        pesototal = pesototal + pesoActsp7;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 7/ producción (4 horas)</td>";
    //    ca += "<td class='center'>" + countsp7 + " de " + totalsp7 + "</td>";
    //    ca += "<td class='center'>" + metasp7 + "%</td>";
    //    ca += "<td class='center'>" + pesoActsp7 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//Esto no tiene el detalle para calcular los docentes asistidos
    //    ca += "</tr>";

    //    Sesión 7, Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).

    //    DataTable sesionesevidenciass7 = c.sesionesformacionevaluadas("", "", "", "", "2", "5", "7", "Relatoria institucional");

    //    double metases7 = 0;
    //    int countses7 = 0;
    //    int totalses7 = 320;
    //    double pesototalses7 = 1.3071;
    //    double pesoses7 = 0;
    //    if ((sesionesevidenciass7 != null && sesionesevidenciass7.Rows.Count > 0))
    //    {
    //        countses7 = sesionesevidenciass3.Rows.Count;
    //        metases7 = ((double)countses7 / (double)totalses7) * 100;
    //        metases7 = Math.Round(metases7, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesoses7 = ((double)countses7 / (double)totalses7) * pesototalses7;
    //        pesoses7 = Math.Round(pesoses7, 4);
    //        if (pesoses7 > pesototalses7)
    //        {
    //            pesoses7 = pesototalses7;
    //        }
    //        pesototal = pesototal + pesoses7;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).</td>";
    //    ca += "<td class='center'>" + countses7 + " de " + totalses7 + "</td>";
    //    ca += "<td class='center'>" + metases7 + "%</td>";
    //    ca += "<td class='center'>" + pesoses7 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";

    //    Sesión 7, Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.

    //    DataTable sesionesevidenciasfe7 = c.sesionesformacionevaluadas("", "", "", "", "2", "5", "7", "Formato de evaluación");

    //    double metasfe7 = 0;
    //    int countsfe7 = 0;
    //    int totalsfe7 = 320;
    //    double pesototalsfe7 = 1.3071;
    //    double pesosfe7 = 0;
    //    if ((sesionesevidenciasfe7 != null && sesionesevidenciasfe7.Rows.Count > 0))
    //    {
    //        countsfe7 = sesionesevidenciasfe7.Rows.Count;
    //        metasfe7 = ((double)countsfe7 / (double)totalsfe7) * 100;
    //        metasfe7 = Math.Round(metasfe7, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesosfe7 = ((double)countsfe7 / (double)totalsfe7) * pesototalsfe7;
    //        pesosfe7 = Math.Round(pesosfe7, 4);
    //        if (pesosfe7 > pesototalsfe7)
    //        {
    //            pesosfe7 = pesototalsfe7;
    //        }
    //        pesototal = pesototal + pesosfe7;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.</td>";
    //    ca += "<td class='center'>" + countsfe7 + " de " + totalsfe7 + "</td>";
    //    ca += "<td class='center'>" + metasfe7 + "%</td>";
    //    ca += "<td class='center'>" + pesosfe7 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";


    //    Sesión 8 de formación No. 15 y 16 realizadas
    //    DataTable estra2JornadaFormacion15 = est.estra2JornadaFormacion("", "", "", "", "6", "8", "15");
    //    DataTable estra2JornadaFormacion16 = est.estra2JornadaFormacion("", "", "", "", "6", "8", "16");

    //    int jornada15 = estra2JornadaFormacion15.Rows.Count;
    //    int jornada16 = estra2JornadaFormacion16.Rows.Count;
    //    int jornadatotal15y16 = 0;
    //    if (jornada15 < jornada16)
    //    {
    //        jornadatotal15y16 = jornada15;
    //    }
    //    else
    //    {
    //        jornadatotal15y16 = jornada16;
    //    }

    //    double meta15y16 = 0;
    //    int count15y16 = 0;
    //    int total15y16 = 320;
    //    double pesototal15y16 = 1.3071;
    //    double peso15y16 = 0;
    //    if ((estra2JornadaFormacion15 != null && estra2JornadaFormacion15.Rows.Count > 0) || estra2JornadaFormacion16 != null && estra2JornadaFormacion16.Rows.Count > 0)
    //    {
    //        count15y16 = jornadatotal15y16;
    //        meta15y16 = ((double)count15y16 / (double)total15y16) * 100;
    //        meta15y16 = Math.Round(meta15y16, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        peso15y16 = ((double)count15y16 / (double)total15y16) * pesototal15y16;
    //        peso15y16 = Math.Round(peso15y16, 4);
    //        if (peso15y16 > pesototal15y16)
    //        {
    //            peso15y16 = pesototal15y16;
    //        }
    //        pesototal = pesototal + peso15y16;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Sesión No. 8, Jornada No. 15 y No. 16 realizadas  </td>";
    //    ca += "<td class='center'>" + jornadatotal15y16 + " de " + total15y16 + "</td>";
    //    ca += "<td class='center'>" + meta15y16 + "%</td>";
    //    ca += "<td class='center'>" + peso15y16 + "%</td>";
    //    ca += "<td class='noExl center'><a href='estra2jornadaformacion.aspx?m=6&s=8&j=15'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 8/jornada de actualización No. 15 (5 horas)
    //    double metasja8 = 0;
    //    int countsja8 = 0;
    //    DataTable sesionvirtualsja8 = c.cargarDocentesEnSesionesJornadasEstra2("", "", "", "", "2", "6", "8");
    //    int totalsja8 = 3386;
    //    double pesosja8 = 1.3071;
    //    double pesoActsja8 = 0;
    //    if (sesionvirtualsja8 != null && sesionvirtualsja8.Rows.Count > 0)
    //    {
    //        countsja8 = sesionvirtualsja8.Rows.Count;


    //        metasja8 = ((double)countsja8 / (double)totalsja8) * 100;
    //        metasja8 = Math.Round(metasja8, 2);

    //        pesoActsja8 = ((double)countsja8 / (double)totalsja8) * pesosja8;
    //        pesoActsja8 = Math.Round(pesoActsja8, 4);
    //        if (pesoActsja8 > pesosja8)
    //        {
    //            pesoActsja3 = pesosja8;
    //        }
    //        pesototal = pesototal + pesoActsja8;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 8/jornada de actualización No. 15 (5 horas)</td>";
    //    ca += "<td class='center'>" + countsja8 + " de " + totalsja8 + "</td>";
    //    ca += "<td class='center'>" + metasja8 + "%</td>";
    //    ca += "<td class='center'>" + pesoActsja8 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 4/formación virtual (4 horas)
    //    double metas8 = 0;
    //    int counts8 = 0;
    //    DataTable sesionvirtuals8 = c.cargarListadoSesionVirtualEstraDos("", "", "", "", "8", "g");
    //    int totals8 = 3386;
    //    double pesos8 = 1.3071;
    //    double pesoActs8 = 0;
    //    if (sesionvirtuals8 != null && sesionvirtuals8.Rows.Count > 0)
    //    {
    //        if (sesionvirtuals8.Rows[0]["virtual"].ToString() != "0")
    //            counts8 = Convert.ToInt32(sesionvirtuals8.Rows[0]["virtual"].ToString());


    //        metas8 = ((double)counts8 / (double)totals8) * 100;
    //        metas8 = Math.Round(metas8, 2);

    //        pesoActs8 = ((double)counts8 / (double)totals8) * pesos8;
    //        pesoActs8 = Math.Round(pesoActs8, 4);
    //        if (pesoActs8 > pesos8)
    //        {
    //            pesoActs8 = pesos8;
    //        }
    //        pesototal = pesototal + pesoActs8;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 8/formación virtual (4 horas)</td>";
    //    ca += "<td class='center'>" + counts8 + " de " + totals8 + "</td>";
    //    ca += "<td class='center'>" + metas8 + "%</td>";
    //    ca += "<td class='center'>" + pesoActs8 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//Esto no tiene el detalle para calcular los docentes asistidos 
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 4/ autoformación (2 horas)
    //    double metasa8 = 0;
    //    int countsa8 = 0;
    //    DataTable sesionvirtualsa8 = c.cargarListadoSesionVirtualEstraDos("", "", "", "", "8", "g");
    //    int totalsa8 = 3386;
    //    double pesosa8 = 1.3071;
    //    double pesoActsa8 = 0;
    //    if (sesionvirtualsa8 != null && sesionvirtualsa8.Rows.Count > 0)
    //    {
    //        if (sesionvirtualsa8.Rows[0]["autoformacion"].ToString() != "0")
    //            countsa8 = Convert.ToInt32(sesionvirtualsa8.Rows[0]["autoformacion"].ToString());


    //        metasa8 = ((double)countsa8 / (double)totalsa8) * 100;
    //        metasa8 = Math.Round(metasa8, 2);

    //        pesoActsa8 = ((double)countsa8 / (double)totalsa8) * pesosa8;
    //        pesoActsa8 = Math.Round(pesoActsa8, 4);
    //        if (pesoActsa8 > pesosa8)
    //        {
    //            pesoActsa8 = pesosa8;
    //        }
    //        pesototal = pesototal + pesoActsa8;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 8/ autoformación (2 horas)</td>";
    //    ca += "<td class='center'>" + countsa8 + " de " + totalsa4 + "</td>";
    //    ca += "<td class='center'>" + metasa8 + "%</td>";
    //    ca += "<td class='center'>" + pesoActsa8 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//Esto no tiene el detalle para calcular los docentes asistidos 
    //    ca += "</tr>";

    //     Asistentes a la sesión de formación No. 8/ producción (2 horas)
    //    double metasp8 = 0;
    //    int countsp8 = 0;
    //    DataTable sesionvirtualsp8 = c.cargarListadoSesionVirtualEstraDos("", "", "", "", "8", "g");
    //    DataTable sesionvirtualsp8 = est.estra2JornadaFormacion("", "", "", "", "6", "8", "16");
    //    int totalsp8 = 3386;
    //    double pesosp8 = 1.3071;
    //    double pesoActsp8 = 0;
    //    if (sesionvirtualsp8 != null && sesionvirtualsp8.Rows.Count > 0)
    //    {
    //        if (sesionvirtualsp4.Rows[0]["produccion"].ToString() != "0")
    //            countsp8 = Convert.ToInt32(sesionvirtualsp8.Rows[0]["produccion"].ToString());

    //        countsp8 = sesionvirtualsp8.Rows.Count;


    //        metasp8 = ((double)countsp8 / (double)totalsp8) * 100;
    //        metasp8 = Math.Round(metasp8, 2);

    //        pesoActsp8 = ((double)countsp8 / (double)totalsp8) * pesosp8;
    //        pesoActsp8 = Math.Round(pesoActsp8, 4);
    //        if (pesoActsp8 > pesosp8)
    //        {
    //            pesoActsp8 = pesosp8;
    //        }
    //        pesototal = pesototal + pesoActsp8;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ". </b>Asistentes a la sesión de formación No. 8/ producción (4 horas)</td>";
    //    ca += "<td class='center'>" + countsp8 + " de " + totalsp8 + "</td>";
    //    ca += "<td class='center'>" + metasp8 + "%</td>";
    //    ca += "<td class='center'>" + pesoActsp8 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//Esto no tiene el detalle para calcular los docentes asistidos
    //    ca += "</tr>";

    //    Sesión 8, Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).

    //    DataTable sesionesevidenciass8 = c.sesionesformacionevaluadas("", "", "", "", "2", "6", "8", "Relatoria institucional");

    //    double metases8 = 0;
    //    int countses8 = 0;
    //    int totalses8 = 320;
    //    double pesototalses8 = 1.3071;
    //    double pesoses8 = 0;
    //    if ((sesionesevidenciass8 != null && sesionesevidenciass8.Rows.Count > 0))
    //    {
    //        countses8 = sesionesevidenciass8.Rows.Count;
    //        metases8 = ((double)countses8 / (double)totalses8) * 100;
    //        metases8 = Math.Round(metases8, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesoses8 = ((double)countses8 / (double)totalses8) * pesototalses8;
    //        pesoses8 = Math.Round(pesoses8, 4);
    //        if (pesoses8 > pesototalses8)
    //        {
    //            pesoses8 = pesototalses8;
    //        }
    //        pesototal = pesototal + pesoses8;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).</td>";
    //    ca += "<td class='center'>" + countses8 + " de " + totalses8 + "</td>";
    //    ca += "<td class='center'>" + metases8 + "%</td>";
    //    ca += "<td class='center'>" + pesoses8 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";

    //    Sesión 8, Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.

    //    DataTable sesionesevidenciasfe8 = c.sesionesformacionevaluadas("", "", "", "", "2", "6", "8", "Formato de evaluación");

    //    double metasfe8 = 0;
    //    int countsfe8 = 0;
    //    int totalsfe8 = 320;
    //    double pesototalsfe8 = 1.3071;
    //    double pesosfe8 = 0;
    //    if ((sesionesevidenciasfe8 != null && sesionesevidenciasfe8.Rows.Count > 0))
    //    {
    //        countsfe8 = sesionesevidenciasfe8.Rows.Count;
    //        metasfe8 = ((double)countsfe8 / (double)totalsfe8) * 100;
    //        metasfe8 = Math.Round(metasfe8, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesosfe8 = ((double)countsfe8 / (double)totalsfe8) * pesototalsfe8;
    //        pesosfe8 = Math.Round(pesosfe8, 4);
    //        if (pesosfe8 > pesototalsfe8)
    //        {
    //            pesosfe8 = pesototalsfe8;
    //        }
    //        pesototal = pesototal + pesosfe8;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.</td>";
    //    ca += "<td class='center'>" + countsfe8 + " de " + totalsfe8 + "</td>";
    //    ca += "<td class='center'>" + metasfe8 + "%</td>";
    //    ca += "<td class='center'>" + pesosfe8 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";

    //    Documentos de introducción de la IEP apoyada en TIC en los currículos de las sedes educativas.

    //    DataTable introiep = c.cargarListadointroiepEstraDos("", "", "", "");

    //    double metaiep = 0;
    //    int countiep = 0;
    //    int totaliep = 320;
    //    double pesototaliep = 1.3071;
    //    double pesoiep = 0;
    //    if ((introiep != null && introiep.Rows.Count > 0))
    //    {
    //        countiep = introiep.Rows.Count;

    //        metaiep = ((double)countiep / (double)totaliep) * 100;
    //        metaiep = Math.Round(metaiep, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesoiep = ((double)countiep / (double)totaliep) * pesototaliep;
    //        pesoiep = Math.Round(pesoiep, 4);
    //        if (pesoiep > pesototaliep)
    //        {
    //            pesoiep = pesototaliep;
    //        }
    //        pesototal = pesototal + pesoiep;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Documentos de introducción de la IEP apoyada en TIC en los currículos de las sedes educativas.</td>";
    //    ca += "<td class='center'>" + countiep + " de " + totaliep + "</td>";
    //    ca += "<td class='center'>" + metaiep + "%</td>";
    //    ca += "<td class='center'>" + pesoiep + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
    //    ca += "</tr>";

    //    Ejemplares de la caja de herramientas  que soporta la formación de maestros(as)  del Proyecto Ciclón, impresos.

    //    DataTable cajah = c.cargarEntregaMaterialesCoordEstra2("","","","", "Caja de herramientas para maestros");

    //    double metacajah = 0;
    //    int countcajah = 0;
    //    int totalcajah = 320;
    //    double pesototalcajah = 1.1400;
    //    double pesocajah = 0;
    //    if ((cajah != null && cajah.Rows.Count > 0))
    //    {
    //        countcajah = cajah.Rows.Count;

    //        metacajah = ((double)countcajah / (double)totalcajah) * 100;
    //        metacajah = Math.Round(metacajah, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesocajah = ((double)countcajah / (double)totalcajah) * pesototalcajah;
    //        pesocajah = Math.Round(pesocajah, 4);
    //        if (pesocajah > pesototalcajah)
    //        {
    //            pesocajah = pesototalcajah;
    //        }
    //        pesototal = pesototal + pesocajah;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Ejemplares de la caja de herramientas  que soporta la formación de maestros(as)  del Proyecto Ciclón, impresos.</td>";
    //    ca += "<td class='center'>" + countcajah + " de " + totalcajah + "</td>";
    //    ca += "<td class='center'>" + metacajah + "%</td>";
    //    ca += "<td class='center'>" + pesocajah + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";

    //    Sistematizaciones y/o Investigaciones de grupos de maestros(as) acompañantes investigadores siguiendo lo definido por  el programa Ondas.

    //    DataTable s003 = c.cargarInstrmentoS003("", "", "", "");

    //    double metas003 = 0;
    //    int counts003 = 0;
    //    int totals003 = 320;
    //    double pesototals003 = 4.570;
    //    double pesos003 = 0;
    //    if ((s003 != null && s003.Rows.Count > 0))
    //    {
    //        counts003 = s003.Rows.Count;

    //        metas003 = ((double)counts003 / (double)totals003) * 100;
    //        metas003 = Math.Round(metas003, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesos003 = ((double)counts003 / (double)totals003) * pesototals003;
    //        pesos003 = Math.Round(pesos003, 4);
    //        if (pesos003 > pesototals003)
    //        {
    //            pesos003 = pesototals003;
    //        }
    //        pesototal = pesototal + pesos003;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Sistematizaciones y/o Investigaciones de grupos de maestros(as) acompañantes investigadores siguiendo lo definido por el programa Ondas.</td>";
    //    ca += "<td class='center'>" + counts003 + " de " + totals003 + "</td>";
    //    ca += "<td class='center'>" + metas003 + "%</td>";
    //    ca += "<td class='center'>" + pesos003 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";

    //    Publicaciones impresas y/o digitales de los procesos y resultados de los equipos pedagógicos institucionales y grupos de investigación de los maestros y maestras.

    //    DataTable publicaciones = c.cargarEntregaMaterialesCoordEstra2("", "", "", "", "Publicaciones");

    //    double metapub = 0;
    //    int countpub = 0;
    //    int totalpub = 320;
    //    double pesototalpub = 1.1400;
    //    double pesopub = 0;
    //    if ((publicaciones != null && publicaciones.Rows.Count > 0))
    //    {
    //        countpub = publicaciones.Rows.Count;

    //        metapub = ((double)countpub / (double)totalpub) * 100;
    //        metapub = Math.Round(metapub, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesopub = ((double)countpub / (double)totalpub) * pesototalcajah;
    //        pesopub = Math.Round(pesopub, 4);
    //        if (pesopub > pesototalpub)
    //        {
    //            pesopub = pesototalpub;
    //        }
    //        pesototal = pesototal + pesopub;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Publicaciones impresas y/o digitales de los procesos y resultados de los equipos pedagógicos institucionales y grupos de investigación de los maestros y maestras.</td>";
    //    ca += "<td class='center'>" + countpub + " de " + totalpub + "</td>";
    //    ca += "<td class='center'>" + metapub + "%</td>";
    //    ca += "<td class='center'>" + pesopub + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";

    //    Maestros y maestras  matriculados en la estrategia  No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica
    //    DataTable dtm = est.maestrosmatriculadosestra2("","","","","2");
    //    DataTable dtm = c.cargarDocentesInscritosComitesEspApro("","","","");

    //    double metadocinsc = 0;
    //    int countdocinsc = 0;
    //    int totaldocinsc = 3386;
    //    double pesototaldocinsc = 1.3071;
    //    double pesodocinsc = 0;
    //    if ((dtm != null && dtm.Rows.Count > 0))
    //    {
    //        countdocinsc = dtm.Rows.Count;
    //        metadocinsc = ((double)countdocinsc / (double)totaldocinsc) * 100;
    //        metadocinsc = Math.Round(metadocinsc, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesodocinsc = ((double)countdocinsc / (double)totaldocinsc) * pesototaldocinsc;
    //        pesodocinsc = Math.Round(pesodocinsc, 4);
    //        if (pesodocinsc > pesototaldocinsc)
    //        {
    //            pesodocinsc = pesototaldocinsc;
    //        }
    //        pesototal = pesototal + pesodocinsc;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Maestros y maestras  matriculados en la estrategia  No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica</td>";
    //    ca += "<td rowspan='4' class='center'>" + dtm.Rows.Count + " de " + totaldocinsc + "</td>";
    //    ca += "<td rowspan='4' class='center'>" + metadocinsc + "%</td>";
    //    ca += "<td rowspan='4' class='center'>" + pesodocinsc + "%</td>";
    //    ca += "<td rowspan='4' class='noExl center'></td>";
    //    ca += "</tr>";

    //    Maestros y maestras coinvestigadores que se forman en la estrategia No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica

    //    DataTable dtm2 = c.cargarDocentesBeneficiadosEnSesionesJornadas();

    //    double metadocinsc2 = 0;
    //    int countdocinsc2 = 0;
    //    int totaldocinsc2 = 3386;
    //    double pesototaldocinsc2 = 1.3071;
    //    double pesodocinsc2 = 0;
    //    if ((dtm2 != null && dtm2.Rows.Count > 0))
    //    {
    //        countdocinsc2 = dtm2.Rows.Count;
    //        metadocinsc2 = ((double)countdocinsc2 / (double)totaldocinsc2) * 100;
    //        metadocinsc2 = Math.Round(metadocinsc2, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesodocinsc2 = ((double)countdocinsc2 / (double)totaldocinsc2) * pesototaldocinsc2;
    //        pesodocinsc2 = Math.Round(pesodocinsc2, 4);
    //        if (pesodocinsc2 > pesototaldocinsc2)
    //        {
    //            pesodocinsc2 = pesototaldocinsc2;
    //        }
    //        pesototal = pesototal + pesodocinsc2;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Maestros y maestras coinvestigadores que se forman en la estrategia No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica</td>";
    //    ca += "<td class='center'>" + dtm2.Rows.Count + " de " + totaldocinsc2 + "</td>";
    //    ca += "<td class='center'>" + metadocinsc2 + "%</td>";
    //    ca += "<td class='center'>" + pesodocinsc2 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
    //    ca += "</tr>";

    //    Maestros y maestras inscritos en los comités  de  los espacios de apropiacion social institucionales que se forman en estrategia  No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica

    //    DataTable dtm3 = c.cargarDocentesInscritosComitesEspApro("","","","");

    //    double metadocinsc3 = 0;
    //    int countdocinsc3 = 0;
    //    int totaldocinsc3 = 3386;
    //    double pesototaldocinsc3 = 1.3071;
    //    double pesodocinsc3 = 0;
    //    if ((dtm3 != null && dtm3.Rows.Count > 0))
    //    {
    //        countdocinsc3 = dtm3.Rows.Count;
    //        metadocinsc3 = ((double)countdocinsc3 / (double)totaldocinsc3) * 100;
    //        metadocinsc3 = Math.Round(metadocinsc3, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesodocinsc3 = ((double)countdocinsc3 / (double)totaldocinsc3) * pesototaldocinsc3;
    //        pesodocinsc3 = Math.Round(pesodocinsc3, 4);
    //        if (pesodocinsc3 > pesototaldocinsc3)
    //        {
    //            pesodocinsc3 = pesototaldocinsc3;
    //        }
    //        pesototal = pesototal + pesodocinsc3;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Maestros y maestras inscritos en los comités  de  los espacios de apropiacion social institucionales que se forman en estrategia  No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica</td>";
    //    ca += "<td class='center'>" + dtm3.Rows.Count + " de " + totaldocinsc3 + "</td>";
    //    ca += "<td class='center'>" + metadocinsc3 + "%</td>";
    //    ca += "<td class='center'>" + pesodocinsc3 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";//?fechaini=0&fechafin=0 <a href='detallejornadasformacion.aspx'><img src='images/detalles.png'></a>
    //    ca += "</tr>";

    //    Maestros y maestras lideres de las redes temáticas formados en la estrategia  No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica.

    //    DataTable maestrosredestematicas = est.maestrosredestematicas("", "", "", "");

    //    double metadocred = 0;
    //    int countdocred = 0;
    //    int totaldocred = 3386;
    //    double pesototaldocred = 3.63;
    //    double pesodocred = 0;
    //    if ((maestrosredestematicas != null && maestrosredestematicas.Rows.Count > 0))
    //    {
    //        countdocred = maestrosredestematicas.Rows.Count;
    //        metadocred = ((double)countdocred / (double)totaldocred) * 100;
    //        metadocred = Math.Round(metadocred, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesodocred = ((double)countdocred / (double)totaldocred) * pesototaldocred;
    //        pesodocred = Math.Round(pesodocred, 4);
    //        if (pesodocred > pesototaldocred)
    //        {
    //            pesodocred = pesototaldocred;
    //        }
    //        pesototal = pesototal + pesodocred;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Maestros y maestras lideres de las redes temáticas formados en la estrategia  No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica.</td>";
    //    ca += "<td class='center'>" + countdocred + " de " + totaldocred + "</td>";
    //    ca += "<td class='center'>" + metadocred + "%</td>";
    //    ca += "<td class='center'>" + pesodocred + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";


    //    Espacios de reflexión, producción y apropiación de maestros que aprenden de maestros, denominados: “El maestro tiene la palabra”.
    //    DataTable docenteapropiacion = c.cargarApropiacionDocentesSeleccionados("", "", "", "");

    //    double metaapro = 0;
    //    int countapro = 0;
    //    int totalapro = 56;
    //    double pesototalapro = 3.63;
    //    double pesoapro = 0;
    //    if ((docenteapropiacion != null && docenteapropiacion.Rows.Count > 0))
    //    {
    //        countapro = docenteapropiacion.Rows.Count;
    //        metaapro = ((double)countapro / (double)totalapro) * 100;
    //        metaapro = Math.Round(metaapro, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesoapro = ((double)countapro / (double)totalapro) * pesototalapro;
    //        pesoapro = Math.Round(pesoapro, 4);
    //        if (pesoapro > pesototalapro)
    //        {
    //            pesoapro = pesototalapro;
    //        }
    //        pesototal = pesototal + pesoapro;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Espacios de reflexión, producción y apropiación de maestros que aprenden de maestros, denominados: “El maestro tiene la palabra”.</td>";
    //    ca += "<td class='center'>" + countapro + " de " + totalapro + "</td>";
    //    ca += "<td class='center'>" + metaapro + "%</td>";
    //    ca += "<td class='center'>" + pesoapro + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";

    //    Ponencias de maestros y maestras inscritas para participación en ferias.
    //    DataTable docenteapropiacion2 = c.cargarApropiacionDocentesSeleccionados("", "", "", "");

    //    double metaapro2 = 0;
    //    int countapro2 = 0;
    //    int totalapro2 = 56;
    //    double pesototalapro2 = 3.63;
    //    double pesoapro2 = 0;
    //    if ((docenteapropiacion != null && docenteapropiacion.Rows.Count > 0))
    //    {
    //        countapro2 = docenteapropiacion.Rows.Count;
    //        metaapro2 = ((double)countapro2 / (double)totalapro2) * 100;
    //        metaapro2 = Math.Round(metaapro2, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesoapro2 = ((double)countapro2 / (double)totalapro2) * pesototalapro2;
    //        pesoapro2 = Math.Round(pesoapro2, 4);
    //        if (pesoapro2 > pesototalapro2)
    //        {
    //            pesoapro2 = pesototalapro2;
    //        }
    //        pesototal = pesototal + pesoapro2;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Ponencias de maestros y maestras inscritas para participación en ferias.</td>";
    //    ca += "<td class='center'>" + countapro2 + " de " + totalapro2 + "</td>";
    //    ca += "<td class='center'>" + metaapro2 + "%</td>";
    //    ca += "<td class='center'>" + pesoapro2 + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";

    //    Contenidos educativos digitales para introducir la investigación en cada una de las 6 areas del curriculo para 10 niveles escolares. Contrapartida CUC.
    //    DataTable contenidosdig = c.cargarApropiacionDocentesSeleccionados("", "", "", "");

    //    double metadg = 0;
    //    int countdg = 0;
    //    int totaldg = 60;
    //    double pesototaldg = 1.7100;
    //    double pesodg = 0;
    //    if ((contenidosdig != null && contenidosdig.Rows.Count > 0))
    //    {
    //        countdg = docenteapropiacion.Rows.Count;
    //        metadg = ((double)countdg / (double)totaldg) * 100;
    //        metadg = Math.Round(metadg, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesodg = ((double)countdg / (double)totaldg) * pesototaldg;
    //        pesodg = Math.Round(pesodg, 4);
    //        if (pesodg > pesototaldg)
    //        {
    //            pesodg = pesototaldg;
    //        }
    //        pesototal = pesototal + pesodg;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Contenidos educativos digitales para introducir la investigación en cada una de las 6 areas del curriculo para 10 niveles escolares. Contrapartida CUC.</td>";
    //    ca += "<td class='center'>" + countdg + " de " + totaldg + "</td>";
    //    ca += "<td class='center'>" + metadg + "%</td>";
    //    ca += "<td class='center'>" + pesodg + "%</td>";
    //    ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
    //    ca += "</tr>";

    //    Maestros y maestras  acompañantes de los grupos de investigación infantiles y juveniles pero que no están en la estrategia No 2. de formación.
    //    DataTable acompanante = c.cargarDocentesEstra1_Estra2();

    //    double metad = 0;
    //    int countd = 0;
    //    int totald = 60;
    //    double pesototald = 1.7100;
    //    double pesod = 0;
    //    if ((acompanante != null && acompanante.Rows.Count > 0))
    //    {
    //        countd = acompanante.Rows.Count;
    //        metad = ((double)countd / (double)totald) * 100;
    //        metad = Math.Round(metad, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesod = ((double)countd / (double)totald) * pesototald;
    //        pesod = Math.Round(pesod, 4);
    //        if (pesod > pesototald)
    //        {
    //            pesod = pesototald;
    //        }
    //        pesototal = pesototal + pesod;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Maestros y maestras  acompañantes de los grupos de investigación infantiles y juveniles pero que no están en la estrategia No 2. de formación.</td>";
    //    ca += "<td class='center'>" + countd + "</td>";
    //    ca += "<td class='center'></td>";
    //    ca += "<td class='center'></td>";
    //    ca += "<td class='noExl center'></td>";
    //    ca += "</tr>";

    //    Maestros y maestras  acompañantes de las redes temáticas infantiles y juveniles pero que no están en la estrategia No 2. de formación.
    //    DataTable acompanante2 = c.cargarDocentesRedestematicas();

    //    double metad2 = 0;
    //    int countd2 = 0;
    //    int totald2 = 60;
    //    double pesototald2 = 1.7100;
    //    double pesod2 = 0;
    //    if ((acompanante2 != null && acompanante2.Rows.Count > 0))
    //    {
    //        countd2 = acompanante2.Rows.Count;
    //        metad2 = ((double)countd2 / (double)totald2) * 100;
    //        metad2 = Math.Round(metad2, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesod2 = ((double)countd2 / (double)totald2) * pesototald2;
    //        pesod2 = Math.Round(pesod2, 4);
    //        if (pesod2 > pesototald2)
    //        {
    //            pesod2 = pesototald2;
    //        }
    //        pesototal = pesototal + pesod2;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Maestros y maestras  acompañantes de las redes temáticas infantiles y juveniles pero que no están en la estrategia No 2. de formación.</td>";
    //    ca += "<td class='center'>" + countd2 + "</td>";
    //    ca += "<td class='center'></td>";
    //    ca += "<td class='center'></td>";
    //    ca += "<td class='noExl center'></td>";
    //    ca += "</tr>";

    //    Maestros y maestras  acompañantes de procesos de apropiación social pero que no están en la estrategia No 2. de formación.
    //    DataTable acompanante3 = c.cargarDocentesApropiacionSocial();

    //    double metad3 = 0;
    //    int countd3 = 0;
    //    int totald3 = 60;
    //    double pesototald3 = 1.7100;
    //    double pesod3 = 0;
    //    if ((acompanante3 != null && acompanante3.Rows.Count > 0))
    //    {
    //        countd3 = acompanante3.Rows.Count;
    //        metad3 = ((double)countd3 / (double)totald3) * 100;
    //        metad3 = Math.Round(metad3, 2);
    //        if (meta1 > 100)
    //        {
    //            meta1 = 100;
    //        }

    //        pesod3 = ((double)countd3 / (double)totald3) * pesototald3;
    //        pesod3 = Math.Round(pesod3, 4);
    //        if (pesod3 > pesototald3)
    //        {
    //            pesod3 = pesototald3;
    //        }
    //        pesototal = pesototal + pesod3;
    //    }
    //    num++;
    //    ca += "<tr>";
    //    ca += "<td><b>" + num + ".</b> Maestros y maestras  acompañantes de procesos de apropiación social pero que no están en la estrategia No 2. de formación.</td>";
    //    ca += "<td class='center'>" + countd3 + "</td>";
    //    ca += "<td class='center'></td>";
    //    ca += "<td class='center'></td>";
    //    ca += "<td class='noExl center'></td>";
    //    ca += "</tr>";
       


    //    /*---------------*/

    //    ca += "<tr>";
    //    ca += "<td></td>";
    //    ca += "<td></td>";
    //    ca += "<td>TOTAL</td>";
    //    ca += "<td>" + pesototal + "%</td>";
    //    ca += "<td class='noExl center'></td>";
    //    ca += "</tr>";

    //    return ca;
    //}

    [WebMethod(EnableSession = true)]
    public static string cargardatos()
    {
        string ca = "lleno@";
        Estrategias est = new Estrategias();
        Institucion ins = new Institucion();
        Consultas c = new Consultas();

        double pesototal = 0;
        int num = 0;


        // 1. Maestros y maestras acompañantes / coinvestigadores matriculados en la estrategia  No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica
        double meta1 = 0;
        int count1 = 0;
        DataTable maestrosmatriculadosestra2 = est.maestrosmatriculadosestra2("", "", "", "", "2");
        //DataTable maestrosmatriculadosestra2 = c.cargarDocentesBeneficiados(codmuncipio, codinstitucion, codsede, "", "", "", "participantes");
        DataRow loadTotalesIndicadoresxSede = ins.loadTotalesIndicadoresxSedeMaestrosSUM("", "", "", "");
        int total1 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso1 = 1.3071;
        double pesoAct1 = 0;

        if (maestrosmatriculadosestra2 != null && maestrosmatriculadosestra2.Rows.Count > 0)
        {
            count1 = maestrosmatriculadosestra2.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b> Maestros y maestras matriculados en la estrategia  No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica </td>";
        ca += "<td class='center'>" + total1 + "</td>";
        ca += "<td class='center'>" + count1 + "</td>";
        ca += "<td class='center'>" + meta1 + "%</td>";
        ca += "<td class='center'>" + pesoAct1 + "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='maestrosmatriculadosestra2()'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Maestros y maestras  matriculados en la estrategia  No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica
        DataTable dtm = est.maestrosmatriculadosestra2Det("", "", "", "", "2");
        //DataTable dtm = c.cargarDocentesInscritosComitesEspApro(coddepartamento, codmuncipio, codinstitucion, codsede);

        double metadocinsc = 0;
        int countdocinsc = 0;

        int totaldocinsc = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double pesototaldocinsc = 0.3267;
        double pesodocinsc = 0;
        if ((dtm != null && dtm.Rows.Count > 0))
        {
            countdocinsc = dtm.Rows.Count;
            totaldocinsc = dtm.Rows.Count;
            //countdocinsc = 3386;
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
            pesototal = pesototal + pesodocinsc;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Maestros y maestras acompañantes / investigadores matriculados en la estrategia  No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica</td>";
        ca += "<td  class='center'>" + totaldocinsc + "</td>";
        ca += "<td class='center' >" + countdocinsc + "</td>";
        ca += "<td  class='center'>" + metadocinsc + "%</td>";
        ca += "<td  class='center'>" + pesodocinsc + "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='maestrosmatriculadosestra2Det()'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Maestros y maestras coinvestigadores que se forman en la estrategia No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica

        //DataTable dtm2 = null;
        DataTable dtm2 = c.cargarDocentesBeneficiadosIndicador3();

        double metadocinsc2 = 0;
        int countdocinsc2 = 0;
        int totaldocinsc2 = 0;
        double pesototaldocinsc2 = 0.3267;
        double pesodocinsc2 = 0;
        if ((dtm2 != null && dtm2.Rows.Count > 0))
        {
            totaldocinsc2 = dtm2.Rows.Count;
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
            pesototal = pesototal + pesodocinsc2;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b>  Maestros y maestras coinvestigadores que se forman en la estrategia No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica</td>";
        ca += "<td class='center'>" + dtm2.Rows.Count + "</td>";
        ca += "<td  class='center'>" + dtm2.Rows.Count + "</td>";
        ca += "<td  class='center'>" + metadocinsc2 + "%</td>";
        ca += "<td  class='center'>" + pesodocinsc2 + "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='cargarDocentesBeneficiadosIndicador3()'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Maestros y maestras inscritos en los comités  de  los espacios de apropiacion social institucionales que se forman en estrategia  No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica

        //DataTable dtm3 = null;
        DataTable dtm3 = c.cargarDocentesInscritosComitesEspApro("", "", "", "");

        double metadocinsc3 = 0;
        int countdocinsc3 = 0;
        int totaldocinsc3 = 0;
        double pesototaldocinsc3 = 0.3267;
        double pesodocinsc3 = 0;
        if ((dtm3 != null && dtm3.Rows.Count > 0))
        {
            totaldocinsc3 = dtm3.Rows.Count;
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
            pesototal = pesototal + pesodocinsc3;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b>  Maestros y maestras inscritos en los comités  de  los espacios de apropiacion social institucionales que se forman en estrategia  No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica</td>";
        ca += "<td class='center'>" + dtm3.Rows.Count + "</td>";
        ca += "<td class='center'>" + dtm3.Rows.Count + "</td>";
        ca += "<td class='center'>" + metadocinsc3 + "%</td>";
        ca += "<td  class='center'>" + pesodocinsc3 + "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='cargarDocentesInscritosComitesEspApro()'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Maestros y maestras lideres de las redes temáticas formados en la estrategia  No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica.

        //DataTable maestrosredestematicas2 = null;
        DataTable maestrosredestematicas2 = est.maestrosredestematicasIndicador5("", "", "", "");

        double metadocred = 0;
        int countdocred = 0;
        int totaldocred = 0;
        double pesototaldocred = 0.3267;
        double pesodocred = 0;
        if ((maestrosredestematicas2 != null && maestrosredestematicas2.Rows.Count > 0))
        {
            countdocred = maestrosredestematicas2.Rows.Count;
            totaldocred = maestrosredestematicas2.Rows.Count;
            metadocred = ((double)countdocred / (double)totaldocred) * 100;
            metadocred = Math.Round(metadocred, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesodocred = ((double)countdocred / (double)totaldocred) * pesototaldocred;
            pesodocred = Math.Round(pesodocred, 4);
            if (pesodocred > pesototaldocred)
            {
                pesodocred = pesototaldocred;
            }
            pesototal = pesototal + pesodocred;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b>  Maestros y maestras lideres de las redes temáticas formados en la estrategia  No. 2 de autoformación, formación de saber y conocimiento y apropiación en los lineamientos del Programa Ciclón y su propuesta metodológica.</td>";
        ca += "<td class='center'>" + countdocred + "</td>";
        ca += "<td class='center'>" + countdocred + "</td>";
        ca += "<td class='center'>" + metadocred + "%</td>";
        ca += "<td  class='center'>" + pesodocred + "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='maestrosredestematicasIndicador5()'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        // Asistentes a la sesión de asesoría a grupos infantiles y juveniles
        //double meta26 = 0;
        //int count26 = 0;
        //DataTable asistentesgruposinv = est.asistentesgruposinv(coddepartamento, codmuncipio, codinstitucion, codsede);
        //int total26 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        //double peso26 = 1.3071;
        //double pesoAct26 = 0;

        //if (asistentesgruposinv != null && asistentesgruposinv.Rows.Count > 0)
        //{
        //    count26 = asistentesgruposinv.Rows.Count;
        //    meta26 = ((double)count26 / (double)total26) * 100;
        //    meta26 = Math.Round(meta26, 2);
        //    //if (meta26 > 100)
        //    //{
        //    //    meta26 = 100;
        //    //}

        //    pesoAct26 = ((double)count26 / (double)total26) * peso26;
        //    pesoAct26 = Math.Round(pesoAct26, 4);
        //    if (pesoAct26 > peso26)
        //    {
        //        pesoAct26 = peso26;
        //    }
        //    pesototal = pesototal + pesoAct26;
        //}
        //num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Maestros asistentes a la sesión de asesorías</td>";
        //ca += "<td class='center'>" + total26 + "</td>";
        //ca += "<td class='center'>" + count26 + "</td>";
        //ca += "<td class='center'>" + meta26 + "%</td>";
        //ca += "<td class='center'>" + pesoAct26 + " de " + peso26 + "</td>";
        //ca += "</tr>";


        // Maestros y maestras lideres de las redes temáticas formados en los lineamientos del Programa Ciclón y su propuesta metodológica
        //double meta27 = 0;
        //int count27 = 0;
        //DataTable maestrosredestematicas = est.maestrosredestematicas(coddepartamento, codmuncipio, codinstitucion, codsede);
        //int total27 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        //double peso27 = 1.3071;
        //double pesoAct27 = 0;

        //if (maestrosredestematicas != null && maestrosredestematicas.Rows.Count > 0)
        //{
        //    count27 = maestrosredestematicas.Rows.Count;
        //    meta27 = ((double)count27 / (double)total27) * 100;
        //    meta27 = Math.Round(meta27, 2);
        //    //if (meta27 > 100)
        //    //{
        //    //    meta27 = 100;
        //    //}

        //    pesoAct27 = ((double)count27 / (double)total27) * peso27;
        //    pesoAct27 = Math.Round(pesoAct27, 4);
        //    if (pesoAct27 > peso27)
        //    {
        //        pesoAct27 = peso27;
        //    }
        //    pesototal = pesototal + pesoAct27;
        //}
        //num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Maestros y maestras líderes de las redes temáticas formados en la estrategia No. 2</td>";
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
        DataTable sesionformacionMaestrosS1 = est.sesionformacionMaestros("", "", "", "", "2", "1", "1");
        int total2 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso2 = 1.3071;
        double pesoAct2 = 0;

        if (sesionformacionMaestrosS1 != null && sesionformacionMaestrosS1.Rows.Count > 0)
        {
            count2 = sesionformacionMaestrosS1.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Sesión de formación No. 1</td>";
        ca += "<td class='center'>" + total2 + "</td>";
        ca += "<td class='center'>" + count2 + "</td>";
        ca += "<td class='center'>" + meta2 + "%</td>";
        ca += "<td class='center'>" + pesoAct2 + "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='sesionformacionMaestros(\"1\",\"1\",\"Sesión de formación No. 1\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        // Asistentes a la sesión de formación No. 1/jornada de actualización No. 1 (5 horas)
        double meta3 = 0;
        int count3 = 0;
        DataTable asistentesSesionMaestrosS1 = est.asistentesSesionMaestros("", "", "", "", "2", "1", "1", "1");
        int total3 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso3 = 1.3071;
        double pesoAct3 = 0;

        if (asistentesSesionMaestrosS1 != null && asistentesSesionMaestrosS1.Rows.Count > 0)
        {
            count3 = asistentesSesionMaestrosS1.Rows.Count;
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
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 1/jornada de actualización No. 1 (5 horas)</td>";
        ca += "<td class='center'>" + total3 + "</td>";
        ca += "<td class='center'>" + count3 + "</td>";
        ca += "<td class='center'>" + meta3 + "%</td>";
        ca += "<td class='center'>" + pesoAct3 + "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='asistentesSesionMaestros(\"1\",\"1\",\"1\",\"Asistentes a la sesión de formación No. 1/jornada de actualización No. 1 (5 horas)\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";




        // Maestros asistentes a la sesión de formación No. 1/jornada de producción No. 1 (4 horas)
        double meta4 = 0;
        int count4 = 0;
        DataTable asistentesSesionMaestrosS1j2 = est.asistentesSesionMaestros("", "", "", "", "2", "1", "1", "2");
        int total4 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso4 = 1.3071;
        double pesoAct4 = 0;
        if (asistentesSesionMaestrosS1j2 != null && asistentesSesionMaestrosS1j2.Rows.Count > 0)
        {
            count4 = asistentesSesionMaestrosS1j2.Rows.Count;
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
        ca += "<td><b>" + num + "</b>  Maestros asistentes a la sesión de formación No. 1/jornada de producción No. 1 (4 horas)</td>";
        ca += "<td class='center'>" + total4 + "</td>";
        ca += "<td class='center'>" + count4 + "</td>";
        ca += "<td class='center'>" + meta4 + "%</td>";
        ca += "<td class='center'>" + pesoAct4 + "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='asistentesSesionMaestros(\"1\",\"1\",\"2\",\"Maestros asistentes a la sesión de formación No. 1/jornada de producción No. 1 (4 horas)\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        // Asistentes a la sesión de formación No. 1/ autoformación (2 horas)
        double meta29 = 0;
        int count29 = 0;
        DataTable asistentessesionformacionAutos1 = est.asistentesSesionMaestros("", "", "", "", "2", "1", "1", "2");
        int total29 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso29 = 1.3071;
        double pesoAct29 = 0;
        if (asistentessesionformacionAutos1 != null && asistentessesionformacionAutos1.Rows.Count > 0)
        {
            count29 = asistentessesionformacionAutos1.Rows.Count;
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
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 1/ autoformación (2 horas)</td>";
        ca += "<td class='center'>" + total29 + "</td>";
        ca += "<td class='center'>" + count29 + "</td>";
        ca += "<td class='center'>" + meta29 + "%</td>";
        ca += "<td class='center'>" + pesoAct29 + "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='asistentesSesionMaestros(\"1\",\"1\",\"2\",\"Asistentes a la sesión de formación No. 1/ autoformación (2 horas)\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        // Asistentes a la sesión de formación No. 1/formación virtual (4 horas)
        double meta30 = 0;
        int count30 = 0;
        DataTable asistentessesionvirtual = est.asistentessesionvirtual("", "", "", "", "1");
        int total30 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso30 = 1.3071;
        double pesoAct30 = 0;
        if (asistentessesionvirtual != null && asistentessesionvirtual.Rows.Count > 0)
        {
            if (asistentessesionvirtual.Rows[0]["asistentes"].ToString() != "")
            {
                count30 = Convert.ToInt32(asistentessesionvirtual.Rows[0]["asistentes"].ToString());
                meta30 = ((double)count30 / (double)total30) * 100;
                meta30 = Math.Round(meta30, 2);

            }
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 1/formación virtual (4 horas)</td>";
        ca += "<td class='center'>" + total30 + "</td>";
        ca += "<td class='center'>" + count30 + "</td>";
        ca += "<td class='center'>" + meta30 + "%</td>";
        ca += "<td class='center'>" + pesoAct30 + "</td>";
        ca += "<td class='center'>-</td>";
        ca += "</tr>";

        // Sesiones de formación evaluadas y subidas a la plataforma de Ciclón
        double meta31 = 0;
        int count31 = 0;
        DataTable sesionesformacionsubidas = est.sesionesformacionevaluadas("", "", "", "", "2", "1", "1");
        int total31 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso31 = 1.3071;
        double pesoAct31 = 0;
        if (sesionesformacionsubidas != null && sesionesformacionsubidas.Rows.Count > 0)
        {
            count31 = sesionesformacionsubidas.Rows.Count;
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
        ca += "<td><b>" + num + "</b>  Sesiones de formación No. 1 evaluadas y subidas a la plataforma de Ciclón</td>";
        ca += "<td class='center'>" + total31 + "</td>";
        ca += "<td class='center'>" + count31 + "</td>";
        ca += "<td class='center'>" + meta31 + "%</td>";
        ca += "<td class='center'>" + pesoAct31 + "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='sesionesformacionevaluadas(\"1\",\"1\",\"Sesiones de formación No. 1 evaluadas y subidas a la plataforma de Ciclón\",\"1\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        /*
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b></td><td> Proyectos de investigación de maestros y maestras con avance en su elaboración</td>";
        ca += "<td class='center'>" + total32 + "</td>";
        ca += "<td class='center'>" + count32 + "</td>";
        ca += "<td class='center'>" + meta32 + "%</td>";
        ca += "<td class='center'>" + pesoAct32 + " de " + peso32 + "</td>";
        ca += "</tr>";
        */


        //Sesión 1, Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).

        DataTable sesionesevidenciass1 = c.sesionesformacionevaluadas("", "", "", "", "2", "1", "1", "Relatoria institucional");

        double metases1 = 0;
        int countses1 = 0;
        int totalses1 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
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
            pesototal = pesototal + pesoses1;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b>  Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).</td>";
        ca += "<td class='center'>" + totalses1 + "</td>";
        ca += "<td class='center'>" + countses1 + "</td>";
        ca += "<td class='center'>" + metases1 + "%</td>";
        ca += "<td class='center'>" + pesoses1 + "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='sesionesformacionevaluadas(\"1\",\"1\",\"Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas)\",\"2\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesión 1, Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.

        //DataTable sesionesevidenciasfe1 = c.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "1", "1", "Formato de evaluación");

        //double metasfe1 = 0;
        //int countsfe1 = 0;
        //int totalsfe1 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        //double pesototalsfe1 = 1.3071;
        //double pesosfe1 = 0;
        //if ((sesionesevidenciasfe1 != null && sesionesevidenciasfe1.Rows.Count > 0))
        //{
        //    countsfe1 = sesionesevidenciasfe1.Rows.Count;
        //    metasfe1 = ((double)countsfe1 / (double)totalsfe1) * 100;
        //    metasfe1 = Math.Round(metasfe1, 2);
        //    //if (meta1 > 100)
        //    //{
        //    //    meta1 = 100;
        //    //}

        //    pesosfe1 = ((double)countsfe1 / (double)totalsfe1) * pesototalsfe1;
        //    pesosfe1 = Math.Round(pesosfe1, 4);
        //    if (pesosfe1 > pesototalsfe1)
        //    {
        //        pesosfe1 = pesototalsfe1;
        //    }
        //    pesototal = pesototal + pesosfe1;
        //}
        //num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + ".</b></td><td> Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.</td>";
        //ca += "<td class='center'>" + totalsfe1 + "</td>";
        //ca += "<td class='center'>" + countsfe1 + "</td>";
        //ca += "<td class='center'>" + metasfe1 + "</td>";
        //ca += "<td class='center'>" + pesosfe1 + " de " + pesototalsfe1 + "</td>";
        //ca += "</tr>";



        // Sesiones de formación No. 2 realizadas 
        double meta5 = 0;
        int count5 = 0;
        DataTable sesionformacionMaestrosS2 = est.sesionformacionMaestros("", "", "", "", "2", "3", "2");
        int total5 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso5 = 1.3071;
        double pesoAct5 = 0;
        if (sesionformacionMaestrosS2 != null && sesionformacionMaestrosS2.Rows.Count > 0)
        {
            count5 = sesionformacionMaestrosS2.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Sesiones de formación No. 2 realizadas</td>";
        ca += "<td class='center'>" + total5 + "</td>";
        ca += "<td class='center'>" + count5 + "</td>";
        ca += "<td class='center'>" + meta5 + "%</td>";
        ca += "<td class='center'>" + pesoAct5 + "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='sesionformacionMaestros(\"3\",\"2\",\"Sesiones de formación No. 2 realizadas\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";



        // Asistentes a la sesión de formación No. 2/jornada de actualización No. 3 (5 horas)
        double meta6 = 0;
        int count6 = 0;
        DataTable asistentesSesionMaestrosS2 = est.asistentesSesionMaestros("", "", "", "", "2", "3", "2", "3");
        int total6 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso6 = 1.3071;
        double pesoAct6 = 0;
        if (asistentesSesionMaestrosS2 != null && asistentesSesionMaestrosS2.Rows.Count > 0)
        {
            count6 = asistentesSesionMaestrosS2.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b> Asistentes a la sesión de formación No. 2/jornada de actualización No. 3 (5 horas)</td>";
        ca += "<td class='center'>" + total6 + "</td>";
        ca += "<td class='center'>" + count6 + "</td>";
        ca += "<td class='center'>" + meta6 + "%</td>";
        ca += "<td class='center'>" + pesoAct6 + "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='asistentesSesionMaestros(\"3\",\"2\",\"3\",\"Asistentes a la sesión de formación No. 2/jornada de actualización No. 3 (5 horas)\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";



        // Asistentes a la sesión de formación No. 2/jornada de producción No. 4 (4 horas)
        double meta7 = 0;
        int count7 = 0;
        DataTable asistentesSesionMaestrosS1j4 = est.asistentesSesionMaestros("", "", "", "", "2", "3", "2", "4");
        int total7 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso7 = 1.3071;
        double pesoAct7 = 0;
        if (asistentesSesionMaestrosS1j4 != null && asistentesSesionMaestrosS1j4.Rows.Count > 0)
        {
            count7 = asistentesSesionMaestrosS1j4.Rows.Count;
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
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 2/jornada de producción No. 4 (4 horas)</td>";
        ca += "<td class='center'>" + total7 + "</td>";
        ca += "<td class='center'>" + count7 + "</td>";
        ca += "<td class='center'>" + meta7 + "%</td>";
        ca += "<td class='center'>" + pesoAct7 + "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='asistentesSesionMaestros(\"3\",\"2\",\"4\",\"Asistentes a la sesión de formación No. 2/jornada de producción No. 4 (4 horas)\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //---------------------------------------------

        // Asistentes a la sesión de formación No. 2/ autoformación (2 horas)
        double meta33 = 0;
        int count33 = 0;
        DataTable asistentessesionformacionAutos2 = est.asistentesSesionMaestros("", "", "", "", "2", "3", "2", "4");
        int total33 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso33 = 1.3071;
        double pesoAct33 = 0;
        if (asistentessesionformacionAutos2 != null && asistentessesionformacionAutos2.Rows.Count > 0)
        {
            count33 = asistentessesionformacionAutos2.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 2/ autoformación (2 horas)</td>";
        ca += "<td class='center'>" + total33 + "</td>";
        ca += "<td class='center'>" + count33 + "</td>";
        ca += "<td class='center'>" + meta33 + "%</td>";
        ca += "<td class='center'>" + pesoAct33 + "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='asistentesSesionMaestros(\"3\",\"2\",\"4\",\"Asistentes a la sesión de formación No. 2/ autoformación (2 horas)\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        // Asistentes a la sesión de formación No. 2/formación virtual (4 horas)
        double meta34 = 0;
        int count34 = 0;
        DataTable asistentessesionvirtuals2 = est.asistentessesionvirtual("", "", "", "", "2");
        int total34 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso34 = 1.3071;
        double pesoAct34 = 0;
        if (asistentessesionvirtuals2 != null && asistentessesionvirtuals2.Rows.Count > 0)
        {
            if (asistentessesionvirtuals2.Rows[0]["asistentes"].ToString() != "")
            {
                count34 = Convert.ToInt32(asistentessesionvirtuals2.Rows[0]["asistentes"].ToString());
                meta34 = ((double)count34 / (double)total34) * 100;
                meta34 = Math.Round(meta34, 2);
            }
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 2/formación virtual (4 horas)</td>";
        ca += "<td class='center'>" + total34 + "</td>";
        ca += "<td class='center'>" + count34 + "</td>";
        ca += "<td class='center'>" + meta34 + "%</td>";
        ca += "<td class='center'>" + pesoAct34 + "</td>";
        ca += "<td class='center'>-</td>";
        ca += "</tr>";

        // Sesiones de formación evaluadas y subidas a la plataforma de Ciclón N. 2
        double meta35 = 0;
        int count35 = 0;
        DataTable sesionesformacionsubidasS2 = est.sesionesformacionevaluadas("", "", "", "", "2", "3", "2");
        int total35 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso35 = 1.3071;
        double pesoAct35 = 0;
        if (sesionesformacionsubidasS2 != null && sesionesformacionsubidasS2.Rows.Count > 0)
        {
            count35 = sesionesformacionsubidasS2.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Sesiones de formación No. 2 evaluadas y subidas a la plataforma de Ciclón </td>";
        ca += "<td class='center'>" + total35 + "</td>";
        ca += "<td class='center'>" + count35 + "</td>";
        ca += "<td class='center'>" + meta35 + "%</td>";
        ca += "<td class='center'>" + pesoAct35 + "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='sesionesformacionevaluadas(\"3\",\"2\",\"Sesiones de formación No. 2 evaluadas y subidas a la plataforma de Ciclón\",\"1\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        /*
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b></td><td> Proyectos de investigación de maestros y maestras con avance en su elaboración</td>";
        ca += "<td class='center'>" + total36 + "</td>";
        ca += "<td class='center'>" + count36 + "</td>";
        ca += "<td class='center'>" + meta36 + "%</td>";
        ca += "<td class='center'>" + pesoAct36 + " de " + peso36 + "</td>";
        ca += "</tr>";
        */


        //Sesión 2, Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).

        DataTable sesionesevidenciass2 = c.sesionesformacionevaluadas("", "", "", "", "2", "3", "2", "Relatoria institucional");

        double metases2 = 0;
        int countses2 = 0;
        int totalses2 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
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
            pesototal = pesototal + pesoses2;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b>  Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).</td>";
        ca += "<td class='center'>" + totalses2 + "</td>";
        ca += "<td class='center'>" + countses2 + "</td>";
        ca += "<td class='center'>" + metases2 + "%</td>";
        ca += "<td class='center'>" + pesoses2 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='sesionesformacionevaluadas(\"3\",\"2\",\"Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).\",\"2\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesión 2, Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.

        // DataTable sesionesevidenciasfe2 = c.sesionesformacionevaluadas("", "", "", "", "2", "3", "2", "Formato de evaluación");

        // double metasfe2 = 0;
        // int countsfe2 = 0;
        // int totalsfe2 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        // double pesototalsfe2 = 1.3071;
        // double pesosfe2 = 0;
        // if ((sesionesevidenciasfe2 != null && sesionesevidenciasfe2.Rows.Count > 0))
        // {
        //     countsfe2 = sesionesevidenciasfe2.Rows.Count;
        //     metasfe2 = ((double)countsfe2 / (double)totalsfe2) * 100;
        //     metasfe2 = Math.Round(metasfe2, 2);
        //     //if (meta1 > 100)
        //     //{
        //     //    meta1 = 100;
        //     //}

        //     pesosfe2 = ((double)countsfe2 / (double)totalsfe2) * pesototalsfe2;
        //     pesosfe2 = Math.Round(pesosfe2, 4);
        //     if (pesosfe2 > pesototalsfe2)
        //     {
        //         pesosfe2 = pesototalsfe2;
        //     }
        //     pesototal = pesototal + pesosfe2;
        // }
        // num++;
        // ca += "<tr>";
        // ca += "<td><b>" + num + ".</b>  Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.</td>";
        // ca += "<td class='center'>" + totalsfe2 + "</td>";
        // ca += "<td class='center'>" + countsfe2 + "</td>";
        // ca += "<td class='center'>" + metasfe2 + "</td>";
        // ca += "<td class='center'>" + pesosfe2 +  "</td>";
        // ca += "<td class='center'><a href='javascript:void(0)' onclick='sesionesformacionevaluadas(\"3\",\"2\",\"Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.\",\"3\")'><img src='images/detalles.png'>Ver</a></td>";
        //----------------------------------------------




        // Sesiones de formación No. 3 realizadas 
        double meta8 = 0;
        int count8 = 0;
        DataTable sesionformacionMaestrosS3 = est.sesionformacionMaestros("", "", "", "", "2", "4", "3");
        int total8 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso8 = 1.3071;
        double pesoAct8 = 0;
        if (sesionformacionMaestrosS3 != null && sesionformacionMaestrosS3.Rows.Count > 0)
        {
            count8 = sesionformacionMaestrosS3.Rows.Count;
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
        ca += "<td><b>" + num + "</b>  Sesiones de formación No. 3 realizadas</td>";
        ca += "<td class='center'>" + total8 + "</td>";
        ca += "<td class='center'>" + count8 + "</td>";
        ca += "<td class='center'>" + meta8 + "%</td>";
        ca += "<td class='center'>" + pesoAct8 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='sesionformacionMaestros(\"4\",\"3\",\"Sesiones de formación No. 3 realizadas\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";



        // Asistentes a la sesión de formación No. 3/jornada de actualización No. 5 (5 horas)
        double meta9 = 0;
        int count9 = 0;
        DataTable asistentesSesionMaestrosS3 = est.asistentesSesionMaestros("", "", "", "", "2", "4", "3", "5");
        int total9 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso9 = 1.3071;
        double pesoAct9 = 0;
        if (asistentesSesionMaestrosS3 != null && asistentesSesionMaestrosS3.Rows.Count > 0)
        {
            count9 = asistentesSesionMaestrosS3.Rows.Count;
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
        ca += "<td><b>" + num + "</b> Asistentes a la sesión de formación No. 3/jornada de actualización No. 5 (5 horas)</td>";
        ca += "<td class='center'>" + total9 + "</td>";
        ca += "<td class='center'>" + count9 + "</td>";
        ca += "<td class='center'>" + meta9 + "%</td>";
        ca += "<td class='center'>" + pesoAct9 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='asistentesSesionMaestros(\"4\",\"3\",\"5\",\"Asistentes a la sesión de formación No. 3/jornada de actualización No. 5 (5 horas)\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";



        // Asistentes a la sesión de formación No. 3/jornada de producción No. 6 (4 horas)
        double meta10 = 0;
        int count10 = 0;
        DataTable asistentesSesionMaestrosS1j6 = est.asistentesSesionMaestros("", "", "", "", "2", "4", "3", "6");
        int total10 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso10 = 1.3071;
        double pesoAct10 = 0;
        if (asistentesSesionMaestrosS1j6 != null && asistentesSesionMaestrosS1j6.Rows.Count > 0)
        {
            count10 = asistentesSesionMaestrosS1j6.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 3/jornada de producción No. 6 (4 horas)</td>";
        ca += "<td class='center'>" + total10 + "</td>";
        ca += "<td class='center'>" + count10 + "</td>";
        ca += "<td class='center'>" + meta10 + "%</td>";
        ca += "<td class='center'>" + pesoAct10 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='asistentesSesionMaestros(\"4\",\"3\",\"6\",\"Asistentes a la sesión de formación No. 3/jornada de producción No. 6 (4 horas)\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //---------------------------------------------
        // Asistentes a la sesión de formación No. 3/ autoformación (2 horas)
        double meta37 = 0;
        int count37 = 0;
        DataTable asistentessesionformacionAutos3 = est.asistentesSesionMaestros("", "", "", "", "2", "4", "3", "6");
        int total37 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso37 = 1.3071;
        double pesoAct37 = 0;
        if (asistentessesionformacionAutos3 != null && asistentessesionformacionAutos3.Rows.Count > 0)
        {
            count37 = asistentessesionformacionAutos3.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 3/ autoformación (2 horas)</td>";
        ca += "<td class='center'>" + total37 + "</td>";
        ca += "<td class='center'>" + count37 + "</td>";
        ca += "<td class='center'>" + meta37 + "%</td>";
        ca += "<td class='center'>" + pesoAct37 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='asistentesSesionMaestros(\"4\",\"3\",\"6\",\"Asistentes a la sesión de formación No. 3/ autoformación (2 horas)\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        // Asistentes a la sesión de formación No. 3/formación virtual (4 horas)
        double meta38 = 0;
        int count38 = 0;
        DataTable asistentessesionvirtuals3 = est.asistentessesionvirtual("", "", "", "", "3");
        int total38 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso38 = 1.3071;
        double pesoAct38 = 0;
        if (asistentessesionvirtuals3 != null && asistentessesionvirtuals3.Rows.Count > 0)
        {
            if (asistentessesionvirtuals3.Rows[0]["asistentes"].ToString() != "")
            {
                count38 = Convert.ToInt32(asistentessesionvirtuals3.Rows[0]["asistentes"].ToString());
                meta38 = ((double)count38 / (double)total38) * 100;
                meta38 = Math.Round(meta38, 2);
            }

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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 3/formación virtual (4 horas)</td>";
        ca += "<td class='center'>" + total38 + "</td>";
        ca += "<td class='center'>" + count38 + "</td>";
        ca += "<td class='center'>" + meta38 + "%</td>";
        ca += "<td class='center'>" + pesoAct38 +  "</td>";
        ca += "<td class='center'>-</td>";
        ca += "</tr>";

        // Sesiones de formación evaluadas y subidas a la plataforma de Ciclón No. 3
        double meta39 = 0;
        int count39 = 0;
        DataTable sesionesformacionsubidasS3 = est.sesionesformacionevaluadas("", "", "", "", "2", "4", "3");
        int total39 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso39 = 1.3071;
        double pesoAct39 = 0;
        if (sesionesformacionsubidasS3 != null && sesionesformacionsubidasS3.Rows.Count > 0)
        {
            count39 = sesionesformacionsubidasS3.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Sesiones de formación No. 3 evaluadas y subidas a la plataforma de Ciclón </td>";
        ca += "<td class='center'>" + total39 + "</td>";
        ca += "<td class='center'>" + count39 + "</td>";
        ca += "<td class='center'>" + meta39 + "%</td>";
        ca += "<td class='center'>" + pesoAct39 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='sesionesformacionevaluadas(\"4\",\"3\",\"Sesiones de formación No. 3 evaluadas y subidas a la plataforma de Ciclón\",\"1\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        /*
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b></td><td> Proyectos de investigación de maestros y maestras con avance en su elaboración</td>";
        ca += "<td class='center'>" + total40 + "</td>";
        ca += "<td class='center'>" + count40 + "</td>";
        ca += "<td class='center'>" + meta40 + "%</td>";
        ca += "<td class='center'>" + pesoAct40 + " de " + peso40 + "</td>";
        ca += "</tr>";
        */

        //Sesión 3, Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).

        DataTable sesionesevidenciass3 = c.sesionesformacionevaluadas("", "", "", "", "2", "4", "3", "Relatoria institucional");

        double metases3 = 0;
        int countses3 = 0;
        int totalses3 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
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
            pesototal = pesototal + pesoses3;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b>  Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).</td>";
        ca += "<td class='center'>" + totalses3 + "</td>";
        ca += "<td class='center'>" + countses3 + "</td>";
        ca += "<td class='center'>" + metases3 + "%</td>";
        ca += "<td class='center'>" + pesoses3 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='sesionesformacionevaluadas(\"4\",\"3\",\"Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas)\",\"2\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesión 3, Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.

        //DataTable sesionesevidenciasfe3 = c.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "3", "Formato de evaluación");

        //double metasfe3 = 0;
        //int countsfe3 = 0;
        //int totalsfe3 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        //double pesototalsfe3 = 1.3071;
        //double pesosfe3 = 0;
        //if ((sesionesevidenciasfe3 != null && sesionesevidenciasfe3.Rows.Count > 0))
        //{
        //    countsfe3 = sesionesevidenciasfe3.Rows.Count;
        //    metasfe3 = ((double)countsfe3 / (double)totalsfe3) * 100;
        //    metasfe3 = Math.Round(metasfe3, 2);
        //    //if (meta1 > 100)
        //    //{
        //    //    meta1 = 100;
        //    //}

        //    pesosfe3 = ((double)countsfe3 / (double)totalsfe3) * pesototalsfe3;
        //    pesosfe3 = Math.Round(pesosfe3, 4);
        //    if (pesosfe3 > pesototalsfe3)
        //    {
        //        pesosfe3 = pesototalsfe3;
        //    }
        //    pesototal = pesototal + pesosfe3;
        //}
        //num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + ".</b></td><td> Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.</td>";
        //ca += "<td class='center'>" + totalsfe3 + "</td>";
        //ca += "<td class='center'>" + countsfe3 + "</td>";
        //ca += "<td class='center'>" + metasfe3 + "</td>";
        //ca += "<td class='center'>" + pesosfe3 + " de " + pesototalsfe3 + "</td>";
        //ca += "</tr>";
        //----------------------------------------------






        // Sesiones de formación No. 4 realizadas 
        double meta11 = 0;
        int count11 = 0;
        DataTable sesionformacionMaestrosS4 = est.sesionformacionMaestros("", "", "", "", "2", "4", "4");
        int total11 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso11 = 1.3071;
        double pesoAct11 = 0;
        if (sesionformacionMaestrosS4 != null && sesionformacionMaestrosS4.Rows.Count > 0)
        {
            count11 = sesionformacionMaestrosS4.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Sesiones de formación No. 4 realizadas </td>";
        ca += "<td class='center'>" + total11 + "</td>";
        ca += "<td class='center'>" + count11 + "</td>";
        ca += "<td class='center'>" + meta11 + "%</td>";
        ca += "<td class='center'>" + pesoAct11 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='sesionformacionMaestros(\"4\",\"4\",\"Sesión de formación No. 4 realizadas\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";



        //Asistentes a la sesión de formación No. 4/jornada de actualización No. 7 (5 horas)
        double meta12 = 0;
        int count12 = 0;
        DataTable asistentesSesionMaestrosS4 = est.asistentesSesionMaestros("", "", "", "", "2", "4", "4", "7");
        int total12 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());

        double peso12 = 1.3071;
        double pesoAct12 = 0;
        if (asistentesSesionMaestrosS4 != null && asistentesSesionMaestrosS4.Rows.Count > 0)
        {
            count12 = asistentesSesionMaestrosS4.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 4/jornada de actualización No. 7 (5 horas)</td>";
        ca += "<td class='center'>" + total12 + "</td>";
        ca += "<td class='center'>" + count12 + "</td>";
        ca += "<td class='center'>" + meta12 + "%</td>";
        ca += "<td class='center'>" + pesoAct12 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='asistentesSesionMaestros(\"4\",\"4\",\"7\",\"Asistentes a la sesión de formación No. 4/jornada de actualización No. 7 (5 horas)\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";



        // Asistentes a la sesión de formación No. 4/jornada de producción No. 8 (4 horas)
        double meta13 = 0;
        int count13 = 0;
        DataTable asistentesSesionMaestrosS4j8 = est.asistentesSesionMaestros("", "", "", "", "2", "4", "4", "8");
        int total13 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso13 = 1.3071;
        double pesoAct13 = 0;
        if (asistentesSesionMaestrosS4j8 != null && asistentesSesionMaestrosS4j8.Rows.Count > 0)
        {
            count13 = asistentesSesionMaestrosS4j8.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 4/jornada de producción No. 8 (4 horas)</td>";
        ca += "<td class='center'>" + total13 + "</td>";
        ca += "<td class='center'>" + count13 + "</td>";
        ca += "<td class='center'>" + meta13 + "%</td>";
        ca += "<td class='center'>" + pesoAct13 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='asistentesSesionMaestros(\"4\",\"4\",\"8\",\"Asistentes a la sesión de formación No. 4/jornada de producción No. 8 (4 horas)\"'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";




        //---------------------------------------------
        // Asistentes a la sesión de formación No. 4/ autoformación (2 horas)
        double meta41 = 0;
        int count41 = 0;
        DataTable asistentessesionformacionAutos4 = est.asistentesSesionMaestros("", "", "", "", "2", "4", "4", "8");
        int total41 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso41 = 1.3071;
        double pesoAct41 = 0;
        if (asistentessesionformacionAutos4 != null && asistentessesionformacionAutos4.Rows.Count > 0)
        {
            count41 = asistentessesionformacionAutos4.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 4/ autoformación (2 horas)</td>";
        ca += "<td class='center'>" + total41 + "</td>";
        ca += "<td class='center'>" + count41 + "</td>";
        ca += "<td class='center'>" + meta41 + "%</td>";
        ca += "<td class='center'>" + pesoAct41 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='asistentesSesionMaestros(\"4\",\"4\",\"8\",\"Asistentes a la sesión de formación No. 4/ autoformación (2 horas)\"'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        // Asistentes a la sesión de formación No. 4/formación virtual (4 horas)
        double meta42 = 0;
        int count42 = 0;
        DataTable asistentessesionvirtuals4 = est.asistentessesionvirtual("", "", "", "", "4");
        int total42 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso42 = 1.3071;
        double pesoAct42 = 0;
        if (asistentessesionvirtuals4 != null && asistentessesionvirtuals4.Rows.Count > 0)
        {
            if (asistentessesionvirtuals4.Rows[0]["asistentes"].ToString() != "")
            {
                count42 = Convert.ToInt32(asistentessesionvirtuals4.Rows[0]["asistentes"].ToString());
                meta42 = ((double)count42 / (double)total42) * 100;
                meta42 = Math.Round(meta42, 2);
            }
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 4/formación virtual (4 horas)</td>";
        ca += "<td class='center'>" + total42 + "</td>";
        ca += "<td class='center'>" + count42 + "</td>";
        ca += "<td class='center'>" + meta42 + "%</td>";
        ca += "<td class='center'>" + pesoAct42 + "</td>";
        ca += "<td class='center'>-</td>";
        ca += "</tr>";

        // Sesiones de formación  No. 4 evaluadas y subidas a la plataforma de Ciclón
        double meta43 = 0;
        int count43 = 0;
        DataTable sesionesformacionsubidasS4 = est.sesionesformacionevaluadas("", "", "", "", "2", "4", "4");
        int total43 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso43 = 1.3071;
        double pesoAct43 = 0;
        if (sesionesformacionsubidasS4 != null && sesionesformacionsubidasS4.Rows.Count > 0)
        {
            count43 = sesionesformacionsubidasS4.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Sesiones de formación No. 4 evaluadas y subidas a la plataforma de Ciclón </td>";
        ca += "<td class='center'>" + total43 + "</td>";
        ca += "<td class='center'>" + count43 + "</td>";
        ca += "<td class='center'>" + meta43 + "%</td>";
        ca += "<td class='center'>" + pesoAct43 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='sesionesformacionevaluadas(\"4\",\"4\",\"Sesiones de formación No. 4 evaluadas y subidas a la plataforma de Ciclón\",\"1\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        /*
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b></td><td> Proyectos de investigación de maestros y maestras con avance en su elaboración</td>";
        ca += "<td class='center'>" + total44 + "</td>";
        ca += "<td class='center'>" + count44 + "</td>";
        ca += "<td class='center'>" + meta44 + "%</td>";
        ca += "<td class='center'>" + pesoAct44 + " de " + peso44 + "</td>";
        ca += "</tr>";
        */

        //Sesión 4, Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).

        DataTable sesionesevidenciass4 = c.sesionesformacionevaluadas("", "", "", "", "2", "4", "4", "Relatoria institucional");

        double metases4 = 0;
        int countses4 = 0;
        int totalses4 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
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
            pesototal = pesototal + pesoses4;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b>  Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).</td>";
        ca += "<td class='center'>" + totalses4 + "</td>";
        ca += "<td class='center'>" + countses4 + "</td>";
        ca += "<td class='center'>" + metases4 + "%</td>";
        ca += "<td class='center'>" + pesoses4 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='sesionesformacionevaluadas(\"4\",\"4\",\"Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas)\",\"2\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesión 4, Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.

        //DataTable sesionesevidenciasfe4 = c.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "1", "Formato de evaluación");

        //double metasfe4 = 0;
        //int countsfe4 = 0;
        //int totalsfe4 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        //double pesototalsfe4 = 1.3071;
        //double pesosfe4 = 0;
        //if ((sesionesevidenciasfe4 != null && sesionesevidenciasfe4.Rows.Count > 0))
        //{
        //    countsfe4 = sesionesevidenciasfe4.Rows.Count;
        //    metasfe4 = ((double)countsfe4 / (double)totalsfe4) * 100;
        //    metasfe4 = Math.Round(metasfe4, 2);
        //    //if (meta1 > 100)
        //    //{
        //    //    meta1 = 100;
        //    //}

        //    pesosfe4 = ((double)countsfe4 / (double)totalsfe4) * pesototalsfe4;
        //    pesosfe4 = Math.Round(pesosfe4, 4);
        //    if (pesosfe4 > pesototalsfe4)
        //    {
        //        pesosfe4 = pesototalsfe4;
        //    }
        //    pesototal = pesototal + pesosfe4;
        //}
        //num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + ".</b></td><td> Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.</td>";
        //ca += "<td class='center'>" + totalsfe4 + "</td>";
        //ca += "<td class='center'>" + countsfe4 + "</td>";
        //ca += "<td class='center'>" + metasfe4 + "</td>";
        //ca += "<td class='center'>" + pesosfe4 + " de " + pesototalsfe4 + "</td>";
        //ca += "</tr>";
        //----------------------------------------------





        // Sesiones de formación No. 5 realizadas 
        double meta14 = 0;
        int count14 = 0;
        DataTable sesionformacionMaestrosS5 = est.sesionformacionMaestros("", "", "", "", "2", "4", "5");
        int total14 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso14 = 1.3071;
        double pesoAct14 = 0;
        if (sesionformacionMaestrosS5 != null && sesionformacionMaestrosS5.Rows.Count > 0)
        {
            count14 = sesionformacionMaestrosS5.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Sesiones de formación No. 5 realizadas </td>";
        ca += "<td class='center'>" + total14 + "</td>";
        ca += "<td class='center'>" + count14 + "</td>";
        ca += "<td class='center'>" + meta14 + "%</td>";
        ca += "<td class='center'>" + pesoAct14 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='sesionformacionMaestros(\"4\",\"5\",\"Sesión de formación No. 5 realizadas\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";



        //Asistentes a la sesión de formación No. 5/jornada de actualización No. 9 (5 horas)
        double meta15 = 0;
        int count15 = 0;
        DataTable asistentesSesionMaestrosS5 = est.asistentesSesionMaestros("", "", "", "", "2", "4", "5", "9");
        int total15 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso15 = 1.3071;
        double pesoAct15 = 0;
        if (asistentesSesionMaestrosS5 != null && asistentesSesionMaestrosS5.Rows.Count > 0)
        {
            count15 = asistentesSesionMaestrosS5.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 5/jornada de actualización No. 9 (5 horas)</td>";
        ca += "<td class='center'>" + total15 + "</td>";
        ca += "<td class='center'>" + count15 + "</td>";
        ca += "<td class='center'>" + meta15 + "%</td>";
        ca += "<td class='center'>" + pesoAct15  + "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='asistentesSesionMaestros(\"4\",\"5\",\"9\",\"Asistentes a la sesión de formación No. 5/jornada de actualización No. 9 (5 horas)\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";



        // Asistentes a la sesión de formación No. 5/jornada de producción No. 10 (4 horas)
        double meta16 = 0;
        int count16 = 0;
        DataTable asistentesSesionMaestrosS5j10 = est.asistentesSesionMaestros("", "", "", "", "2", "4", "5", "10");
        int total16 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso16 = 1.3071;
        double pesoAct16 = 0;
        if (asistentesSesionMaestrosS5j10 != null && asistentesSesionMaestrosS5j10.Rows.Count > 0)
        {
            count16 = asistentesSesionMaestrosS5j10.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 5/jornada de producción No. 10 (4 horas)</td>";
        ca += "<td class='center'>" + total16 + "</td>";
        ca += "<td class='center'>" + count16 + "</td>";
        ca += "<td class='center'>" + meta16 + "%</td>";
        ca += "<td class='center'>" + pesoAct16 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='asistentesSesionMaestros(\"4\",\"5\",\"10\",\"Asistentes a la sesión de formación No. 5/jornada de producción No. 10 (4 horas)\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";



        //---------------------------------------------
        // Asistentes a la sesión de formación No. 5/ autoformación (2 horas)
        double meta45 = 0;
        int count45 = 0;
        DataTable asistentessesionformacionAutos5 = est.asistentesSesionMaestros("", "", "", "", "2", "4", "5", "10");
        int total45 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso45 = 1.3071;
        double pesoAct45 = 0;
        if (asistentessesionformacionAutos5 != null && asistentessesionformacionAutos5.Rows.Count > 0)
        {
            count45 = asistentessesionformacionAutos5.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 5/ autoformación (2 horas)</td>";
        ca += "<td class='center'>" + total45 + "</td>";
        ca += "<td class='center'>" + count45 + "</td>";
        ca += "<td class='center'>" + meta45 + "%</td>";
        ca += "<td class='center'>" + pesoAct45 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='asistentesSesionMaestros(\"4\",\"5\",\"10\",\"Asistentes a la sesión de formación No. 5/ autoformación (2 horas)\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        // Asistentes a la sesión de formación No. 5/formación virtual (4 horas)
        double meta46 = 0;
        int count46 = 0;
        DataTable asistentessesionvirtuals5 = est.asistentessesionvirtual("", "", "", "", "5");
        int total46 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso46 = 1.3071;
        double pesoAct46 = 0;
        if (asistentessesionvirtuals5 != null && asistentessesionvirtuals5.Rows.Count > 0)
        {
            if (asistentessesionvirtuals5.Rows[0]["asistentes"].ToString() != "")
            {
                count46 = Convert.ToInt32(asistentessesionvirtuals5.Rows[0]["asistentes"].ToString());
                meta46 = ((double)count46 / (double)total46) * 100;
                meta46 = Math.Round(meta46, 2);
            }
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 5/formación virtual (4 horas)</td>";
        ca += "<td class='center'>" + total46 + "</td>";
        ca += "<td class='center'>" + count46 + "</td>";
        ca += "<td class='center'>" + meta46 + "%</td>";
        ca += "<td class='center'>" + pesoAct46 +  "</td>";
        ca += "<td class='center'>-</td>";
        ca += "</tr>";

        // Sesiones de formación  No. 5 evaluadas y subidas a la plataforma de Ciclón
        double meta47 = 0;
        int count47 = 0;
        DataTable sesionesformacionsubidasS5 = est.sesionesformacionevaluadas("", "", "", "", "2", "4", "5");
        int total47 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso47 = 1.3071;
        double pesoAct47 = 0;
        if (sesionesformacionsubidasS5 != null && sesionesformacionsubidasS5.Rows.Count > 0)
        {
            count47 = sesionesformacionsubidasS5.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Sesiones de formación No. 5 evaluadas y subidas a la plataforma de Ciclón </td>";
        ca += "<td class='center'>" + total47 + "</td>";
        ca += "<td class='center'>" + count47 + "</td>";
        ca += "<td class='center'>" + meta47 + "%</td>";
        ca += "<td class='center'>" + pesoAct47 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='sesionesformacionevaluadas(\"4\",\"5\",\"Sesiones de formación No. 5 evaluadas y subidas a la plataforma de Ciclón\",\"1\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        /*
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b></td><td> Proyectos de investigación de maestros y maestras con avance en su elaboración</td>";
        ca += "<td class='center'>" + total48 + "</td>";
        ca += "<td class='center'>" + count48 + "</td>";
        ca += "<td class='center'>" + meta48 + "%</td>";
        ca += "<td class='center'>" + pesoAct48 + " de " + peso48 + "</td>";
        ca += "</tr>";
        */

        //Sesión 5, Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).

        DataTable sesionesevidenciass5 = c.sesionesformacionevaluadas("", "", "", "", "2", "4", "5", "Relatoria institucional");

        double metases5 = 0;
        int countses5 = 0;
        int totalses5 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
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
            pesototal = pesototal + pesoses5;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b>  Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).</td>";
        ca += "<td class='center'>" + totalses5 + "</td>";
        ca += "<td class='center'>" + countses5 + "</td>";
        ca += "<td class='center'>" + metases5 + "%</td>";
        ca += "<td class='center'>" + pesoses5 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='sesionesformacionevaluadas(\"4\",\"5\",\"Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas)\",\"2\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesión 5, Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.

        //DataTable sesionesevidenciasfe5 = c.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "5", "Formato de evaluación");

        //double metasfe5 = 0;
        //int countsfe5 = 0;
        //int totalsfe5 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        //double pesototalsfe5 = 1.3071;
        //double pesosfe5 = 0;
        //if ((sesionesevidenciasfe5 != null && sesionesevidenciasfe5.Rows.Count > 0))
        //{
        //    countsfe5 = sesionesevidenciasfe5.Rows.Count;
        //    metasfe5 = ((double)countsfe5 / (double)totalsfe5) * 100;
        //    metasfe5 = Math.Round(metasfe5, 2);
        //    //if (meta1 > 100)
        //    //{
        //    //    meta1 = 100;
        //    //}

        //    pesosfe5 = ((double)countsfe5 / (double)totalsfe5) * pesototalsfe5;
        //    pesosfe5 = Math.Round(pesosfe5, 4);
        //    if (pesosfe5 > pesototalsfe5)
        //    {
        //        pesosfe5 = pesototalsfe5;
        //    }
        //    pesototal = pesototal + pesosfe5;
        //}
        //num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + ".</b></td><td> Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.</td>";
        //ca += "<td class='center'>" + totalsfe5 + "</td>";
        //ca += "<td class='center'>" + countsfe5 + "</td>";
        //ca += "<td class='center'>" + metasfe5 + "</td>";
        //ca += "<td class='center'>" + pesosfe5 + " de " + pesototalsfe5 + "</td>";
        //ca += "</tr>";
        //----------------------------------------------




        // Sesiones de formación No. 6 realizadas 
        double meta17 = 0;
        int count17 = 0;
        DataTable sesionformacionMaestrosS6 = est.sesionformacionMaestros("", "", "", "", "2", "4", "6");
        int total17 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso17 = 1.3071;
        double pesoAct17 = 0;
        if (sesionformacionMaestrosS6 != null && sesionformacionMaestrosS6.Rows.Count > 0)
        {
            count17 = sesionformacionMaestrosS6.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Sesiones de formación No. 6 realizadas </td>";
        ca += "<td class='center'>" + total17 + "</td>";
        ca += "<td class='center'>" + count17 + "</td>";
        ca += "<td class='center'>" + meta17 + "%</td>";
        ca += "<td class='center'>" + pesoAct17 + "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='sesionformacionMaestros(\"4\",\"6\",\"Sesión de formación No. 6 realizadas\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";



        //Asistentes a la sesión de formación No. 6/jornada de actualización No. 11 (5 horas)
        double meta18 = 0;
        int count18 = 0;
        DataTable asistentesSesionMaestrosS6 = est.asistentesSesionMaestros("", "", "", "", "2", "4", "6", "11");
        int total18 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso18 = 1.3071;
        double pesoAct18 = 0;
        if (asistentesSesionMaestrosS6 != null && asistentesSesionMaestrosS6.Rows.Count > 0)
        {
            count18 = asistentesSesionMaestrosS6.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 6/jornada de actualización No. 11 (5 horas)</td>";
        ca += "<td class='center'>" + total18 + "</td>";
        ca += "<td class='center'>" + count18 + "</td>";
        ca += "<td class='center'>" + meta18 + "%</td>";
        ca += "<td class='center'>" + pesoAct18 + "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='asistentesSesionMaestros(\"4\",\"6\",\"11\",\"Asistentes a la sesión de formación No. 6/jornada de actualización No. 11 (5 horas)\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";



        // Asistentes a la sesión de formación No. 6/jornada de producción No. 12 (4 horas)
        double meta19 = 0;
        int count19 = 0;
        DataTable asistentesSesionMaestrosS6j12 = est.asistentesSesionMaestros("", "", "", "", "2", "4", "6", "12");
        int total19 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());

        double peso19 = 1.3071;
        double pesoAct19 = 0;
        if (asistentesSesionMaestrosS6j12 != null && asistentesSesionMaestrosS6j12.Rows.Count > 0)
        {
            count19 = asistentesSesionMaestrosS6j12.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 6/jornada de producción No. 12 (4 horas)</td>";
        ca += "<td class='center'>" + total19 + "</td>";
        ca += "<td class='center'>" + count19 + "</td>";
        ca += "<td class='center'>" + meta19 + "%</td>";
        ca += "<td class='center'>" + pesoAct19 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='asistentesSesionMaestros(\"4\",\"6\",\"12\",\"Asistentes a la sesión de formación No. 6/jornada de producción No. 12 (4 horas)\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";



        //---------------------------------------------
        // Asistentes a la sesión de formación No. 6/ autoformación (2 horas)
        double meta49 = 0;
        int count49 = 0;
        DataTable asistentessesionformacionAutos6 = est.asistentesSesionMaestros("", "", "", "", "2", "4", "6", "12");
        int total49 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso49 = 1.3071;
        double pesoAct49 = 0;
        if (asistentessesionformacionAutos6 != null && asistentessesionformacionAutos6.Rows.Count > 0)
        {
            count49 = asistentessesionformacionAutos6.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 6/ autoformación (2 horas)</td>";
        ca += "<td class='center'>" + total49 + "</td>";
        ca += "<td class='center'>" + count49 + "</td>";
        ca += "<td class='center'>" + meta49 + "%</td>";
        ca += "<td class='center'>" + pesoAct49 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='asistentesSesionMaestros(\"4\",\"6\",\"12\",\"Asistentes a la sesión de formación No. 6/ autoformación (2 horas)\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        // Asistentes a la sesión de formación No. 6/formación virtual (4 horas)
        double meta50 = 0;
        int count50 = 0;
        DataTable asistentessesionvirtuals6 = est.asistentessesionvirtual("", "", "", "", "6");
        int total50 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso50 = 1.3071;
        double pesoAct50 = 0;
        if (asistentessesionvirtuals6 != null && asistentessesionvirtuals6.Rows.Count > 0)
        {
            if (asistentessesionvirtuals6.Rows[0]["asistentes"].ToString() != "")
            {
                count50 = Convert.ToInt32(asistentessesionvirtuals6.Rows[0]["asistentes"]);
                meta50 = ((double)count50 / (double)total50) * 100;
                meta50 = Math.Round(meta50, 2);
            }
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 6/formación virtual (4 horas)</td>";
        ca += "<td class='center'>" + total50 + "</td>";
        ca += "<td class='center'>" + count50 + "</td>";
        ca += "<td class='center'>" + meta50 + "%</td>";
        ca += "<td class='center'>" + pesoAct50 +  "</td>";
        ca += "<td class='center'>-</td>";
        ca += "</tr>";

        // Sesiones de formación  No. 6 evaluadas y subidas a la plataforma de Ciclón
        double meta51 = 0;
        int count51 = 0;
        DataTable sesionesformacionsubidasS6 = est.sesionesformacionevaluadas("", "", "", "", "2", "4", "6");
        int total51 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso51 = 1.3071;
        double pesoAct51 = 0;
        if (sesionesformacionsubidasS6 != null && sesionesformacionsubidasS6.Rows.Count > 0)
        {
            count51 = sesionesformacionsubidasS6.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Sesiones de formación No. 6 evaluadas y subidas a la plataforma de Ciclón </td>";
        ca += "<td class='center'>" + total51 + "</td>";
        ca += "<td class='center'>" + count51 + "</td>";
        ca += "<td class='center'>" + meta51 + "%</td>";
        ca += "<td class='center'>" + pesoAct51 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='sesionesformacionevaluadas(\"4\",\"6\",\"Sesiones de formación No. 6 evaluadas y subidas a la plataforma de Ciclón\",\"1\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        /*
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b></td><td> Proyectos de investigación de maestros y maestras con avance en su elaboración</td>";
        ca += "<td class='center'>" + total52 + "</td>";
        ca += "<td class='center'>" + count52 + "</td>";
        ca += "<td class='center'>" + meta52 + "%</td>";
        ca += "<td class='center'>" + pesoAct52 + " de " + peso52 + "</td>";
        ca += "</tr>";
        */

        //Sesión 6, Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).

        DataTable sesionesevidenciass6 = c.sesionesformacionevaluadas("", "", "", "", "2", "4", "6", "Relatoria institucional");

        double metases6 = 0;
        int countses6 = 0;
        int totalses6 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
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
            pesototal = pesototal + pesoses6;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b>  Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).</td>";
        ca += "<td class='center'>" + totalses6 + "</td>";
        ca += "<td class='center'>" + countses6 + "</td>";
        ca += "<td class='center'>" + metases6 + "%</td>";
        ca += "<td class='center'>" + pesoses6 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='sesionesformacionevaluadas(\"4\",\"6\",\"Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas)\",\"1\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesión 6, Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.

        //DataTable sesionesevidenciasfe6 = c.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "4", "6", "Formato de evaluación");

        //double metasfe6 = 0;
        //int countsfe6 = 0;
        //int totalsfe6 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        //double pesototalsfe6 = 1.3071;
        //double pesosfe6 = 0;
        //if ((sesionesevidenciasfe6 != null && sesionesevidenciasfe6.Rows.Count > 0))
        //{
        //    countsfe6 = sesionesevidenciasfe6.Rows.Count;
        //    metasfe6 = ((double)countsfe6 / (double)totalsfe6) * 100;
        //    metasfe6 = Math.Round(metasfe6, 2);
        //    //if (meta1 > 100)
        //    //{
        //    //    meta1 = 100;
        //    //}

        //    pesosfe6 = ((double)countsfe6 / (double)totalsfe6) * pesototalsfe6;
        //    pesosfe6 = Math.Round(pesosfe6, 4);
        //    if (pesosfe6 > pesototalsfe6)
        //    {
        //        pesosfe6 = pesototalsfe6;
        //    }
        //    pesototal = pesototal + pesosfe6;
        //}
        //num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + ".</b></td><td> Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.</td>";
        //ca += "<td class='center'>" + totalsfe6 + "</td>";
        //ca += "<td class='center'>" + countsfe6 + "</td>";
        //ca += "<td class='center'>" + metasfe6 + "%</td>";
        //ca += "<td class='center'>" + pesosfe6 + " de " + pesototalsfe6 + "</td>";
        //ca += "</tr>";
        //----------------------------------------------





        // Sesiones de formación No. 7 realizadas 
        double meta20 = 0;
        int count20 = 0;
        DataTable sesionformacionMaestrosS7 = est.sesionformacionMaestros("", "", "", "", "2", "5", "7");
        int total20 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso20 = 1.3071;
        double pesoAct20 = 0;
        if (sesionformacionMaestrosS7 != null && sesionformacionMaestrosS7.Rows.Count > 0)
        {
            count20 = sesionformacionMaestrosS7.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Sesiones de formación No. 7 realizadas </td>";
        ca += "<td class='center'>" + total20 + "</td>";
        ca += "<td class='center'>" + count20 + "</td>";
        ca += "<td class='center'>" + meta20 + "%</td>";
        ca += "<td class='center'>" + pesoAct20 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='sesionformacionMaestros(\"5\",\"7\",\"Sesiones de formación No. 7 realizadas\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";



        //Asistentes a la sesión de formación No. 7/jornada de actualización No. 13 (5 horas)
        double meta21 = 0;
        int count21 = 0;
        DataTable asistentesSesionMaestrosS7 = est.asistentesSesionMaestros("", "", "", "", "2", "5", "7", "13");
        int total21 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso21 = 1.3071;
        double pesoAct21 = 0;
        if (asistentesSesionMaestrosS7 != null && asistentesSesionMaestrosS7.Rows.Count > 0)
        {
            count21 = asistentesSesionMaestrosS7.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 7/jornada de actualización No. 13 (5 horas)</td>";
        ca += "<td class='center'>" + total21 + "</td>";
        ca += "<td class='center'>" + count21 + "</td>";
        ca += "<td class='center'>" + meta21 + "%</td>";
        ca += "<td class='center'>" + pesoAct21 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='asistentesSesionMaestros(\"5\",\"7\",\"13\",\"Asistentes a la sesión de formación No. 7/jornada de actualización No. 13 (5 horas)\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";



        // Asistentes a la sesión de formación No. 7/jornada de producción No. 14 (4 horas)
        double meta22 = 0;
        int count22 = 0;
        DataTable asistentesSesionMaestrosS7j14 = est.asistentesSesionMaestros("", "", "", "", "2", "5", "7", "14");
        int total22 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso22 = 1.3071;
        double pesoAct22 = 0;
        if (asistentesSesionMaestrosS7j14 != null && asistentesSesionMaestrosS7j14.Rows.Count > 0)
        {
            count22 = asistentesSesionMaestrosS7j14.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 7/jornada de producción No. 14 (4 horas)</td>";
        ca += "<td class='center'>" + total22 + "</td>";
        ca += "<td class='center'>" + count22 + "</td>";
        ca += "<td class='center'>" + meta22 + "%</td>";
        ca += "<td class='center'>" + pesoAct22 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='asistentesSesionMaestros(\"5\",\"7\",\"14\",\"Asistentes a la sesión de formación No. 7/jornada de producción No. 14 (4 horas)\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";



        //---------------------------------------------
        // Asistentes a la sesión de formación No. 7/ autoformación (2 horas)
        double meta53 = 0;
        int count53 = 0;
        DataTable asistentessesionformacionAutos7 = est.asistentesSesionMaestros("", "", "", "", "2", "5", "7", "14");
        int total53 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso53 = 1.3071;
        double pesoAct53 = 0;
        if (asistentessesionformacionAutos7 != null && asistentessesionformacionAutos7.Rows.Count > 0)
        {
            count53 = asistentessesionformacionAutos7.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 7/ autoformación (2 horas)</td>";
        ca += "<td class='center'>" + total53 + "</td>";
        ca += "<td class='center'>" + count53 + "</td>";
        ca += "<td class='center'>" + meta53 + "%</td>";
        ca += "<td class='center'>" + pesoAct53 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='asistentesSesionMaestros(\"5\",\"7\",\"14\",\"Asistentes a la sesión de formación No. 7/ autoformación (2 horas)\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        // Asistentes a la sesión de formación No. 7/formación virtual (4 horas)
        double meta54 = 0;
        int count54 = 0;
        DataTable asistentessesionvirtuals7 = est.asistentessesionvirtual("", "", "", "", "7");
        int total54 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso54 = 1.3071;
        double pesoAct54 = 0;
        if (asistentessesionvirtuals7 != null && asistentessesionvirtuals7.Rows.Count > 0)
        {
            if (asistentessesionvirtuals7.Rows[0]["asistentes"].ToString() != "")
            {
                count54 = Convert.ToInt32(asistentessesionvirtuals7.Rows[0]["asistentes"].ToString());
                meta54 = ((double)count54 / (double)total54) * 100;
                meta54 = Math.Round(meta54, 2);
            }
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 7/formación virtual (4 horas)</td>";
        ca += "<td class='center'>" + total54 + "</td>";
        ca += "<td class='center'>" + count54 + "</td>";
        ca += "<td class='center'>" + meta54 + "%</td>";
        ca += "<td class='center'>" + pesoAct54 + "</td>";
        ca += "<td class='center'>-</td>";
        ca += "</tr>";

        // Sesiones de formación  No. 7 evaluadas y subidas a la plataforma de Ciclón
        double meta55 = 0;
        int count55 = 0;
        DataTable sesionesformacionsubidasS7 = est.sesionesformacionevaluadas("", "", "", "", "2", "5", "7");
        int total55 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso55 = 1.3071;
        double pesoAct55 = 0;
        if (sesionesformacionsubidasS7 != null && sesionesformacionsubidasS7.Rows.Count > 0)
        {
            count55 = sesionesformacionsubidasS7.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Sesiones de formación No. 7 evaluadas y subidas a la plataforma de Ciclón </td>";
        ca += "<td class='center'>" + total55 + "</td>";
        ca += "<td class='center'>" + count55 + "</td>";
        ca += "<td class='center'>" + meta55 + "%</td>";
        ca += "<td class='center'>" + pesoAct55 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='sesionesformacionevaluadas(\"5\",\"7\",\"Sesiones de formación No. 7 evaluadas y subidas a la plataforma de Ciclón\",\"1\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        /*
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b></td><td> Proyectos de investigación de maestros y maestras con avance en su elaboración</td>";
        ca += "<td class='center'>" + total56 + "</td>";
        ca += "<td class='center'>" + count56 + "</td>";
        ca += "<td class='center'>" + meta56 + "%</td>";
        ca += "<td class='center'>" + pesoAct56 + " de " + peso56 + "</td>";
        ca += "</tr>";
        */

        //Sesión 7, Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).

        DataTable sesionesevidenciass7 = c.sesionesformacionevaluadas("", "", "", "", "2", "5", "7", "Relatoria institucional");

        double metases7 = 0;
        int countses7 = 0;
        int totalses7 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
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
            pesototal = pesototal + pesoses7;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b>  Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).</td>";
        ca += "<td class='center'>" + totalses7 + "</td>";
        ca += "<td class='center'>" + countses7 + "</td>";
        ca += "<td class='center'>" + metases7 + "%</td>";
        ca += "<td class='center'>" + pesoses7 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='sesionesformacionevaluadas(\"5\",\"7\",\"Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas)\",\"2\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesión 7, Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.

        //DataTable sesionesevidenciasfe7 = c.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "5", "7", "Formato de evaluación");

        //double metasfe7 = 0;
        //int countsfe7 = 0;
        //int totalsfe7 = 320;
        //double pesototalsfe7 = 1.3071;
        //double pesosfe7 = 0;
        //if ((sesionesevidenciasfe7 != null && sesionesevidenciasfe7.Rows.Count > 0))
        //{
        //    countsfe7 = sesionesevidenciasfe7.Rows.Count;
        //    metasfe7 = ((double)countsfe7 / (double)totalsfe7) * 100;
        //    metasfe7 = Math.Round(metasfe7, 2);
        //    //if (meta1 > 100)
        //    //{
        //    //    meta1 = 100;
        //    //}

        //    pesosfe7 = ((double)countsfe7 / (double)totalsfe7) * pesototalsfe7;
        //    pesosfe7 = Math.Round(pesosfe7, 4);
        //    if (pesosfe7 > pesototalsfe7)
        //    {
        //        pesosfe7 = pesototalsfe7;
        //    }
        //    pesototal = pesototal + pesosfe7;
        //}
        //num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + ".</b></td><td> Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.</td>";
        //ca += "<td class='center'>" + totalsfe7 + "</td>";
        //ca += "<td class='center'>" + countsfe7 + "</td>";
        //ca += "<td class='center'>" + metasfe7 + "</td>";
        //ca += "<td class='center'>" + pesosfe7 + " de " + pesototalsfe7 + "</td>";
        //ca += "</tr>";


        //----------------------------------------------




        // Sesiones de formación No. 8 realizadas 
        double meta23 = 0;
        int count23 = 0;
        DataTable sesionformacionMaestrosS8 = est.sesionformacionMaestros("", "", "", "", "2", "6", "8");
        int total23 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        double peso23 = 1.3071;
        double pesoAct23 = 0;
        if (sesionformacionMaestrosS8 != null && sesionformacionMaestrosS8.Rows.Count > 0)
        {
            count23 = sesionformacionMaestrosS8.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Sesiones de formación No. 8 realizadas </td>";
        ca += "<td class='center'>" + total23 + "</td>";
        ca += "<td class='center'>" + count23 + "</td>";
        ca += "<td class='center'>" + meta23 + "%</td>";
        ca += "<td class='center'>" + pesoAct23 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='sesionformacionMaestros(\"6\",\"8\",\"Sesión de formación No. 8 realizadas\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";



        //Asistentes a la sesión de formación No. 8/jornada de actualización No. 15 (5 horas)
        double meta24 = 0;
        int count24 = 0;
        DataTable asistentesSesionMaestrosS8 = est.asistentesSesionMaestros("", "", "", "", "2", "6", "8", "15");
        int total24 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso24 = 1.3071;
        double pesoAct24 = 0;
        if (asistentesSesionMaestrosS8 != null && asistentesSesionMaestrosS8.Rows.Count > 0)
        {
            count24 = asistentesSesionMaestrosS8.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 8/jornada de actualización No. 15 (5 horas)</td>";
        ca += "<td class='center'>" + total24 + "</td>";
        ca += "<td class='center'>" + count24 + "</td>";
        ca += "<td class='center'>" + meta24 + "%</td>";
        ca += "<td class='center'>" + pesoAct24 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='asistentesSesionMaestros(\"6\",\"8\",\"15\",\"Asistentes a la sesión de formación No. 8/jornada de actualización No. 15 (5 horas)\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";



        // Asistentes a la sesión de formación No. 8/jornada de producción No. 16 (4 horas)
        double meta25 = 0;
        int count25 = 0;
        DataTable asistentesSesionMaestrosS8j16 = est.asistentesSesionMaestros("", "", "", "", "2", "6", "8", "16");
        int total25 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso25 = 1.3071;
        double pesoAct25 = 0;
        if (asistentesSesionMaestrosS8j16 != null && asistentesSesionMaestrosS8j16.Rows.Count > 0)
        {
            count25 = asistentesSesionMaestrosS8j16.Rows.Count;
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
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 8/jornada de producción No. 16 (4 horas)</td>";
        ca += "<td class='center'>" + total25 + "</td>";
        ca += "<td class='center'>" + count25 + "</td>";
        ca += "<td class='center'>" + meta25 + "%</td>";
        ca += "<td class='center'>" + pesoAct25 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='asistentesSesionMaestros(\"6\",\"8\",\"16\",\"Asistentes a la sesión de formación No. 8/jornada de actualización No. 16 (4 horas)\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";



        //---------------------------------------------
        // Asistentes a la sesión de formación No. 8/ autoformación (2 horas)
        double meta57 = 0;
        int count57 = 0;
        DataTable asistentessesionformacionAutos8 = est.asistentesSesionMaestros("", "", "", "", "2", "6", "8", "16");
        int total57 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
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
            pesototal = pesototal + pesoAct57;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 8/ autoformación (2 horas)</td>";
        ca += "<td class='center'>" + total57 + "</td>";
        ca += "<td class='center'>" + count57 + "</td>";
        ca += "<td class='center'>" + meta57 + "%</td>";
        ca += "<td class='center'>" + pesoAct57 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='asistentesSesionMaestros(\"6\",\"8\",\"16\",\"Asistentes a la sesión de formación No. 8/ autoformación (2 horas)\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        // Asistentes a la sesión de formación No. 8/formación virtual (4 horas)
        double meta58 = 0;
        int count58 = 0;
        DataTable asistentessesionvirtuals8 = est.asistentessesionvirtual("", "", "", "", "8");
        int total58 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalmaestros"].ToString());
        double peso58 = 1.3071;
        double pesoAct58 = 0;
        if (asistentessesionvirtuals8 != null && asistentessesionvirtuals8.Rows.Count > 0)
        {
            if (asistentessesionvirtuals8.Rows[0]["asistentes"].ToString() != "")
            {
                count58 = Convert.ToInt32(asistentessesionvirtuals8.Rows[0]["asistentes"].ToString());
                meta58 = ((double)count58 / (double)total58) * 100;
                meta58 = Math.Round(meta58, 2);
            }
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
            pesototal = pesototal + pesoAct58;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Asistentes a la sesión de formación No. 8/formación virtual (4 horas)</td>";
        ca += "<td class='center'>" + total58 + "</td>";
        ca += "<td class='center'>" + count58 + "</td>";
        ca += "<td class='center'>" + meta58 + "%</td>";
        ca += "<td class='center'>" + pesoAct58 + "</td>";
        ca += "<td class='center'>-</td>";
        ca += "</tr>";

        // Sesiones de formación  No. 8 evaluadas y subidas a la plataforma de Ciclón
        double meta59 = 0;
        int count59 = 0;
        DataTable sesionesformacionsubidasS8 = est.sesionesformacionevaluadas("", "", "", "", "2", "6", "8");
        int total59 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
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
            pesototal = pesototal + pesoAct59;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + "</b>  Sesiones de formación No. 8 evaluadas y subidas a la plataforma de Ciclón </td>";
        ca += "<td class='center'>" + total59 + "</td>";
        ca += "<td class='center'>" + count59 + "</td>";
        ca += "<td class='center'>" + meta59 + "%</td>";
        ca += "<td class='center'>" + pesoAct59 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='sesionesformacionevaluadas(\"6\",\"8\",\"Sesiones de formación No. 8 evaluadas y subidas a la plataforma de Ciclón\",\"1\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Sesión 8, Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).

        DataTable sesionesevidenciass8 = c.sesionesformacionevaluadas("", "", "", "", "2", "6", "8", "Relatoria institucional");

        double metases8 = 0;
        int countses8 = 0;
        int totalses8 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
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
            pesototal = pesototal + pesoses8;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b>  Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas).</td>";
        ca += "<td class='center'>" + totalses8 + "</td>";
        ca += "<td class='center'>" + countses8 + "</td>";
        ca += "<td class='center'>" + metases8 + "%</td>";
        ca += "<td class='center'>" + pesoses8 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='sesionesformacionevaluadas(\"6\",\"8\",\"Producción de saber y conocimiento - Relatorias institucionales elaboradas y subidas a la plataforma Ciclón (2 horas)\",\"2\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //// Grupos de Investigación Financiados
        //double meta60_f = 0;
        //int count60_f = 0;
        //DataTable proyectosinvestigacionfinanciado = c.totalgruposinvestigacionfinanciados("", "", "", "");
        //int total60_f = 0;
        //double peso60_f = 1.3071;
        //double pesoAct60_f = 0;
        //if (proyectosinvestigacionfinanciado != null && proyectosinvestigacionfinanciado.Rows.Count > 0)
        //{
        //    count60_f = proyectosinvestigacionfinanciado.Rows.Count;
        //    total60_f = proyectosinvestigacionfinanciado.Rows.Count;
        //    meta60_f = ((double)count60_f / (double)total60_f) * 100;
        //    meta60_f = Math.Round(meta60_f, 2);
        //    //if (meta60 > 100)
        //    //{
        //    //    meta60 = 100;
        //    //}

        //    pesoAct60_f = ((double)count60_f / (double)total60_f) * peso60_f;
        //    pesoAct60_f = Math.Round(pesoAct60_f, 4);
        //    if (pesoAct60_f > peso60_f)
        //    {
        //        pesoAct60_f = peso60_f;
        //    }
        //    pesototal = pesototal + pesoAct60_f;
        //}
        //num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b>  Grupos de Investigación Financiados</td>";
        //ca += "<td class='center'>" + total60_f + "</td>";
        //ca += "<td class='center'>" + count60_f + "</td>";
        //ca += "<td class='center'>" + meta60_f + "%</td>";
        //ca += "<td class='center'>" + pesoAct60_f +  "</td>";
        //ca += "<td class='center'><a href='javascript:void(0)' onclick='totalgruposinvestigacionfinanciados()'><img src='images/detalles.png'>Ver</a></td>";
        //ca += "</tr>";

        // Proyectos de investigación de maestros y maestras con avance en su elaboración
        //double meta60 = 0;
        //int count60 = 0;
        //DataTable proyectosinvestigacionmaestross8 = est.proyectosinvestigacionmaestros(coddepartamento, codmuncipio, codinstitucion, codsede);
        //int total60 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        //double peso60 = 1.3071;
        //double pesoAct60 = 0;
        //if (proyectosinvestigacionmaestross8 != null && proyectosinvestigacionmaestross8.Rows.Count > 0)
        //{
        //    count60 = proyectosinvestigacionmaestross8.Rows.Count;
        //    meta60 = ((double)count60 / (double)total60) * 100;
        //    meta60 = Math.Round(meta60, 2);
        //    //if (meta60 > 100)
        //    //{
        //    //    meta60 = 100;
        //    //}

        //    pesoAct60 = ((double)count60 / (double)total60) * peso60;
        //    pesoAct60 = Math.Round(pesoAct60, 4);
        //    if (pesoAct60 > peso60)
        //    {
        //        pesoAct60 = peso60;
        //    }
        //    pesototal = pesototal + pesoAct60;
        //}
        //num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Sistematizaciones y/o Investigaciones de maestros con avances</td>";
        //ca += "<td class='center'>" + total60 + "</td>";
        //ca += "<td class='center'>" + count60 + "</td>";
        //ca += "<td class='center'>" + meta60 + "%</td>";
        //ca += "<td class='center'>" + pesoAct60 + " de " + peso60 + "</td>";
        //ca += "</tr>";



        //Sesión 8, Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.

        //DataTable sesionesevidenciasfe8 = c.sesionesformacionevaluadas(coddepartamento, codmuncipio, codinstitucion, codsede, "2", "6", "8", "Formato de evaluación");

        //double metasfe8 = 0;
        //int countsfe8 = 0;
        //int totalsfe8 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        //double pesototalsfe8 = 1.3071;
        //double pesosfe8 = 0;
        //if ((sesionesevidenciasfe8 != null && sesionesevidenciasfe8.Rows.Count > 0))
        //{
        //    countsfe8 = sesionesevidenciasfe8.Rows.Count;
        //    metasfe8 = ((double)countsfe8 / (double)totalsfe8) * 100;
        //    metasfe8 = Math.Round(metasfe8, 2);
        //    //if (meta1 > 100)
        //    //{
        //    //    meta1 = 100;
        //    //}

        //    pesosfe8 = ((double)countsfe8 / (double)totalsfe8) * pesototalsfe8;
        //    pesosfe8 = Math.Round(pesosfe8, 4);
        //    if (pesosfe8 > pesototalsfe8)
        //    {
        //        pesosfe8 = pesototalsfe8;
        //    }
        //    pesototal = pesototal + pesosfe8;
        //}
        //num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + ".</b></td><td> Sesiones de formación evaluadas y subidas a la plataforma de Ciclón.</td>";
        //ca += "<td class='center'>" + totalsfe8 + "</td>";
        //ca += "<td class='center'>" + countsfe8 + "</td>";
        //ca += "<td class='center'>" + metasfe8 + "%</td>";
        //ca += "<td class='center'>" + pesosfe8 + " de " + pesototalsfe8 + "</td>";
        //ca += "</tr>";
        //----------------------------------------------




        //Documentos de introducción de la IEP apoyada en TIC en los currículos de las sedes educativas.
        DataTable introiep = c.cargarInstrmentoS003("", "", "", "");

        double metaiep = 0;
        int countiep = 0;
        int totaliep = Convert.ToInt32(loadTotalesIndicadoresxSede["s003"].ToString());
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
            pesototal = pesototal + pesoiep;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b>  Documentos de introducción de la IEP apoyada en TIC en los currículos de las sedes educativas.</td>";
        ca += "<td class='center' >" + totaliep + "</td>";
        ca += "<td class='center'>" + countiep + "</td>";
        ca += "<td class='center'>" + metaiep + "%</td>";
        ca += "<td class='center'>" + pesoiep + "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='cargarListadointroiepEstraDos()'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Espacios de reflexión, producción y apropiación de maestros que aprenden de maestros, denominados: “El maestro tiene la palabra”.
        DataTable docenteapropiacion = c.cargarApropiacionDocentesEncabezado("", "", "", "");

        double metaapro = 0;
        int countapro = 0;
        int totalapro = 56;
        double pesototalapro = 1.815;
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
            pesototal = pesototal + pesoapro;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b>  Espacios de reflexión, producción y apropiación de maestros que aprenden de maestros, denominados: “El maestro tiene la palabra”.</td>";
        ca += "<td class='center' >" + totalapro + "</td>";
        ca += "<td class='center'>" + countapro + "</td>";
        ca += "<td class='center'>" + metaapro + "</td>";
        ca += "<td class='center'>" + pesoapro +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='cargarApropiacionDocentesEncabezado()'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Ponencias de maestros y maestras inscritas para participación en ferias.
        DataTable docenteapropiacion2 = c.cargarApropiacionDocentesSeleccionados("", "", "", "");

        double metaapro2 = 0;
        int countapro2 = 0;
        int totalapro2 = 2;
        double pesototalapro2 = 1.815;
        double pesoapro2 = 0;
        if ((docenteapropiacion2 != null && docenteapropiacion2.Rows.Count > 0))
        {
            countapro2 = docenteapropiacion2.Rows.Count;
            metaapro2 = ((double)countapro2 / (double)totalapro2) * 100;
            metaapro2 = Math.Round(metaapro2, 2);
            metaapro2 = 100;
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            pesoapro2 = ((double)countapro2 / (double)totalapro2) * pesototalapro2;
            pesoapro2 = Math.Round(pesoapro2, 4);
            //pesoapro2 = 3.63;
            if (pesoapro2 > pesototalapro2)
            {
                pesoapro2 = pesototalapro2;
            }
            pesototal = pesototal + pesoapro2;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b>  Ponencias realizadas.</td>";
        ca += "<td class='center' >" + countapro2 + "</td>";
        ca += "<td class='center'>" + countapro2 + "</td>";
        ca += "<td class='center'>" + metaapro2 + "%</td>";
        ca += "<td class='center'>" + pesoapro2 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='cargarApropiacionDocentesSeleccionados()'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Ejemplares de la caja de herramientas  que soporta la formación de maestros(as)  del Proyecto Ciclón, impresos.

        DataTable cajah = c.cargarEntregaMaterialesCoordEstra2("", "", "", "", "Caja de herramientas para maestros");

        double metacajah = 0;
        int countcajah = 0;
        int totalcajah = Convert.ToInt32(loadTotalesIndicadoresxSede["cajah"].ToString()); ;
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
            pesototal = pesototal + pesocajah;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b>  Ejemplares de la caja de herramientas que soporta la formación de maestros(as) del Proyecto Ciclón, entregadas.</td>";
        ca += "<td class='center' >" + totalcajah + "</td>";
        ca += "<td class='center'>" + countcajah + "</td>";
        ca += "<td class='center'>" + metacajah + "%</td>";
        ca += "<td class='center'>" + pesocajah +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='cargarEntregaMaterialesCoordEstra2(\"Caja de herramientas para maestros\",\"Ejemplares de la caja de herramientas que soporta la formación de maestros(as) del Proyecto Ciclón, entregadas.\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sistematizaciones y/o Investigaciones de grupos de maestros(as) acompañantes investigadores terminadas.

        DataTable s003 = c.cargarInstrmentoS003("", "", "", "");

        double metas003 = 0;
        int counts003 = 0;
        int totals003 = Convert.ToInt32(loadTotalesIndicadoresxSede["s003"].ToString());
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
            pesototal = pesototal + pesos003;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b>  Sistematizaciones y/o Investigaciones de grupos de maestros(as) acompañantes investigadores terminadas.</td>";
        ca += "<td class='center' >" + totals003 + "</td>";
        ca += "<td class='center'>" + counts003 + "</td>";
        ca += "<td class='center'>" + metas003 + "</td>";
        ca += "<td class='center'>" + pesos003 +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='cargarInstrmentoS003()'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Publicaciones impresas y/o digitales de los procesos y resultados de los equipos pedagógicos institucionales y grupos de investigación de los maestros y maestras.

        DataTable publicaciones = c.cargarEntregaMaterialesCoordEstra2("", "", "", "", "");

        double metapub = 0;
        int countpub = 0;
        int totalpub = 2;
        double pesototalpub = 0.7200;
        double pesopub = 0;

        if ((publicaciones != null && publicaciones.Rows.Count >= 320))
        {
            countpub = 2;

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
            pesototal = pesototal + pesopub;
        }


        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b>  Publicaciones impresas y/o digitales de los procesos y resultados de los equipos pedagógicos institucionales y grupos de investigación de los maestros y maestras.</td>";
        ca += "<td class='center' >" + totalpub + "</td>";
        ca += "<td class='center'>" + countpub + "</td>";
        ca += "<td class='center'>" + metapub + "</td>";
        ca += "<td class='center'>" + pesopub +  "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='cargarEntregaMaterialesCoordEstra2(\"Publicaciones\",\"Publicaciones impresas y/o digitales de los procesos y resultados de los equipos pedagógicos institucionales y grupos de investigación de los maestros y maestras.\")'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Contenidos educativos digitales para introducir la investigación en cada una de las 6 areas del curriculo para 10 niveles escolares. Contrapartida CUC.
        DataTable contenidosdig = c.cargarListadocontenidodigitalEstraDosActualizado();

        double metadg = 0;
        int countdg = 0;
        int totaldg = 320;
        double pesototaldg = 1.7100;
        double pesodg = 0;
        if ((contenidosdig != null && contenidosdig.Rows.Count > 0))
        {
            countdg = contenidosdig.Rows.Count;
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
            pesototal = pesototal + pesodg;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b>  Contenidos educativos digitales para introducir la investigación en cada una de las 6 areas del curriculo para 10 niveles escolares. Contrapartida CUC.</td>";
        ca += "<td class='center' >" + totaldg + "</td>";
        ca += "<td class='center'>" + countdg + "</td>";
        ca += "<td class='center'>" + metadg + "</td>";
        ca += "<td class='center'>" + pesodg + "</td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='cargarListadocontenidodigitalEstraDosActualizado()'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Maestros y maestras acompañantes de los grupos de investigación infantiles y juveniles pero que no están en la estrategia No 2. de formación.
        DataTable acompanante = c.cargarDocentesEstra1_Estra2Where("", "", "", "");

        double metad = 0;
        int countd = 0;
        int totald = 1360;
        double pesototald = 0;
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
            //pesototal = pesototal + pesod;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b>  Maestros y maestras acompañantes de los grupos de investigación infantiles y juveniles que no están en la estrategia No 2. de formación.</td>";
        ca += "<td class='center'>" + totald + "</td>";
        ca += "<td class='center'>" + countd + "</td>";
        ca += "<td class='center'>100%</td>";
        ca += "<td class='center'></td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='cargarDocentesEstra1_Estra2Where()'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Maestros y maestras  acompañantes de las redes temáticas infantiles y juveniles pero que no están en la estrategia No 2. de formación.
        DataTable acompanante2 = c.cargarDocentesRedestematicasWhere("", "", "", "");

        double metad2 = 0;
        int countd2 = 0;
        int totald2 = 1845;
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
            //pesototal = pesototal + pesod2;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b>Maestros y maestras acompañantes de las redes temáticas infantiles y juveniles que no están en la estrategia No 2. de formación.</td>";
        ca += "<td class='center'>" + totald2 + "</td>";
        ca += "<td class='center'>" + countd2 + "</td>";
        ca += "<td class='center'>100%</td>";
        ca += "<td class='center'></td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='cargarDocentesRedestematicasWhere()'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Maestros y maestras  acompañantes de procesos de apropiación social pero que no están en la estrategia No 2. de formación.
        DataTable acompanante3 = c.cargarDocentesApropiacionSocialWhere("", "", "", "");

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
            //pesototal = pesototal + pesod3;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b>  Maestros y maestras  acompañantes de procesos de apropiación social que no están en la estrategia No 2. de formación.</td>";
        ca += "<td class='center'>" + countd3 + "</td>";
        ca += "<td class='center'>" + countd3 + "</td>";
        ca += "<td class='center'>100%</td>";
        ca += "<td class='center'></td>";
        ca += "<td class='center'><a href='javascript:void(0)' onclick='cargarDocentesApropiacionSocialWhere()'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        // Maestros y maestras  acompañantes de los grupos de investigación infantiles y juveniles pero que no están en la estrategia No 2. de formación
        //double meta61 = 0;
        //int count61 = 0;
        //DataTable maesstrosgpNOestrategia2 = est.maesstrosgpNOestrategia2(coddepartamento, codmuncipio, codinstitucion, codsede);
        //int total61 = Convert.ToInt32(loadTotalesIndicadoresxSede["totalsesion"].ToString());
        //double peso61 = 0.008791209;
        //double pesoAct61 = 0;
        //if (maesstrosgpNOestrategia2 != null && maesstrosgpNOestrategia2.Rows.Count > 0)
        //{
        //    count61 = maesstrosgpNOestrategia2.Rows.Count;
        //    meta61 = ((double)count61 / (double)total61) * 100;
        //    meta61 = Math.Round(meta61, 2);
        //    if (meta61 > 100)
        //    {
        //        meta61 = 100;
        //    }

        //    pesoAct61 = ((double)count61 / (double)total61) * peso61;
        //    pesoAct61 = Math.Round(pesoAct61, 4);
        //    if (pesoAct61 > peso61)
        //    {
        //        pesoAct61 = peso61;
        //    }
        //    pesototal = pesototal + pesoAct61;
        //}
        //num++;
        //ca += "<tr>";
        //ca += "<td><b>" + num + "</b></td><td> Maestros y maestras  acompañantes de los grupos de investigación infantiles y juveniles pero que no están en la estrategia No 2. de formación</td>";
        //ca += "<td class='center'>" + total61 + "</td>";
        //ca += "<td class='center'>" + count61 + "</td>";
        //ca += "<td class='center'>" + meta61 + "%</td>";
        //ca += "<td class='center'>" + pesoAct61 + " de " + peso61 + "</td>";
        //ca += "</tr>";

        //////////////////INDICADORES ESTUDIANTES PARA LA GRÁFICA/////////////////////

        //double pesototalE = 0;



        ////total grupos de investigacion por municipio
        //DataRow totalgpxMunicipio = ins.totalgpxMunicipio("");

        //DataTable gpSeleccionadosconvocatoria = est.gpSeleccionadosconvocatoria("", "", "", "");

        //double meta1E = 0;
        //int count1E = 0;

        //DataRow loadTotalesIndicadoresxSedeE = ins.loadTotalesIndicadoresxSedeSUM("", "", "", "");
        //int total1E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalgrupos"].ToString());
        //double peso1E = 2.20;
        //double pesoAct1E = 0;

        //if (gpSeleccionadosconvocatoria != null && gpSeleccionadosconvocatoria.Rows.Count > 0)
        //{
        //    count1E = gpSeleccionadosconvocatoria.Rows.Count;
        //    meta1E = ((double)count1E / (double)total1E) * 100;
        //    meta1E = Math.Round(meta1E, 2);
        //    //if (meta1 > 100)
        //    //{
        //    //    meta1 = 100;
        //    //}

        //    pesoAct1E = ((double)count1E / (double)total1E) * peso1E;
        //    pesoAct1E = Math.Round(pesoAct1E, 4);
        //    if (pesoAct1E > peso1E)
        //    {
        //        pesoAct1E = peso1E;
        //    }
        //    pesototalE = pesototalE + pesoAct1E;
        //}



        //// ---------------------- NUEVO CODIGO --------------
        ////28) Grupos de investigación infantiles y juveniles que se inscribieron en la convocatoria de Ciclón 
        //DataTable gpinscritosconvocatoriaciclon = est.gpinscritosconvocatoriaciclon("", "", "", "", "1");
        //double meta28 = 0;
        //int count28 = 0;
        //int total28 = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalgrupos"].ToString());
        //double peso28 = 2.20;
        //double pesoAct28 = 0;
        //if (gpinscritosconvocatoriaciclon != null && gpinscritosconvocatoriaciclon.Rows.Count > 0)
        //{
        //    count28 = gpinscritosconvocatoriaciclon.Rows.Count;
        //    meta28 = ((double)count28 / (double)total28) * 100;
        //    meta28 = Math.Round(meta28, 2);
        //    //if (meta28 > 100)
        //    //{
        //    //    meta28 = 100;
        //    //}
        //    pesoAct28 = ((double)count28 / (double)total28) * peso28;
        //    pesoAct28 = Math.Round(pesoAct28, 4);
        //    if (pesoAct28 > peso28)
        //    {
        //        pesoAct28 = peso28;
        //    }
        //    pesototalE = pesototalE + pesoAct28;
        //}



        ////29) Grupos de investigación con recursos aportados por  Ciclón
        ////DataTable gprecursosaprortados = est.gprecursosaprortados(coddepartamento, codmuncipio, codinstitucion, codsede, "1");
        //DataTable gprecursosaprortados = c.cargarGruposInvestigacionRecursosAportadosCiclón("", "", "", "");
        //double meta29E = 0;
        //int count29E = 0;
        //int total29E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalgrupos"].ToString());
        //double peso29E = 12.31;
        //double pesoAct29E = 0;
        //if (gprecursosaprortados != null && gprecursosaprortados.Rows.Count > 0)
        //{
        //    count29E = gprecursosaprortados.Rows.Count;
        //    meta29E = ((double)count29E / (double)total29E) * 100;
        //    meta29E = Math.Round(meta29E, 2);
        //    //if (meta29 > 100)
        //    //{
        //    //    meta29 = 100;
        //    //}
        //    pesoAct29E = ((double)count29E / (double)total29E) * peso29E;
        //    pesoAct29E = Math.Round(pesoAct29E, 4);

        //    if (pesoAct29E > peso29E)
        //    {
        //        pesoAct29E = peso29E;
        //    }
        //    pesototalE = pesototalE + pesoAct29E;
        //}

        ////30) Total grupos de investigación con registro de avance del presupuesto
        //DataTable gpregistroavance = est.gpregistroavance("", "", "", "");
        //double meta30E = 0;
        //int count30E = 0;
        //int total30E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalgrupos"].ToString());
        //double peso30E = 2.20;
        //double pesoAct30E = 0;
        //if (gpregistroavance != null && gpregistroavance.Rows.Count > 0)
        //{
        //    count30E = gpregistroavance.Rows.Count;
        //    meta30E = ((double)count30E / (double)total30E) * 100;
        //    meta30E = Math.Round(meta30E, 2);
        //    //if (meta30 > 100)
        //    //{
        //    //    meta30 = 100;
        //    //}
        //    pesoAct30E = ((double)count30E / (double)total30E) * peso30E;
        //    pesoAct30E = Math.Round(pesoAct30E, 4);
        //    if (pesoAct30E > peso30E)
        //    {
        //        pesoAct30E = peso30E;
        //    }
        //    pesototalE = pesototalE + pesoAct30E;
        //}


        ////31)  Informes de investigación elaborados por los grupos de investigación infantiles y juveniles
        //DataTable informesinvelavoradosgp = est.informesinvelavoradosgp("", "", "", "");
        //double meta31E = 0;
        //int count31E = 0;
        //int total31E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalgrupos"].ToString());
        //double peso31E = 0.31;
        //double pesoAct31E = 0;
        //if (informesinvelavoradosgp != null && informesinvelavoradosgp.Rows.Count > 0)
        //{
        //    count31E = informesinvelavoradosgp.Rows.Count;
        //    meta31E = ((double)count31E / (double)total31E) * 100;
        //    meta31E = Math.Round(meta31E, 2);
        //    //if (meta31 > 100)
        //    //{
        //    //    meta31 = 100;
        //    //}
        //    pesoAct31E = ((double)count31E / (double)total31E) * peso31E;
        //    pesoAct31E = Math.Round(pesoAct31E, 4);
        //    if (pesoAct31E > peso31E)
        //    {
        //        pesoAct31E = peso31E;
        //    }
        //    pesototalE = pesototalE + pesoAct31E;
        //}



        ////32) Resumenes del proyecto de investigación elaborados por los grupos infantiles y juveniles.
        //DataTable resumenesproyectoinv = est.resumenesproyectoinv("", "", "", "");
        //double meta32 = 0;
        //int count32 = 0;
        //int total32 = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalgrupos"].ToString());
        //double peso32 = 2.20;
        //double pesoAct32 = 0;
        //if (resumenesproyectoinv != null && resumenesproyectoinv.Rows.Count > 0)
        //{
        //    count32 = resumenesproyectoinv.Rows.Count;
        //    meta32 = ((double)count32 / (double)total32) * 100;
        //    meta32 = Math.Round(meta32, 2);
        //    //if (meta32 > 100)
        //    //{
        //    //    meta32 = 100;
        //    //}
        //    pesoAct32 = ((double)count32 / (double)total32) * peso32;
        //    pesoAct32 = Math.Round(pesoAct32, 4);
        //    if (pesoAct32 > peso32)
        //    {
        //        pesoAct32 = peso32;
        //    }
        //    pesototalE = pesototalE + pesoAct32;
        //}


        ////---------------------------------------------




        ////Niños, niñas y jóvenes inscritos en grupos de investigación infantiles y juveniles en la convocatoria Ciclón 
        //DataTable estudianesengp = est.estudianesengp("", "", "", "");
        //double meta2E = 0;
        //int count2E = 0;
        //int total2E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalasistentesasesorias"].ToString());
        //double peso2E = 2.20;
        //double pesoAct2E = 0;

        //if (estudianesengp != null && estudianesengp.Rows.Count > 0)
        //{
        //    count2E = estudianesengp.Rows.Count;
        //    meta2E = ((double)count2E / (double)total2E) * 100;
        //    meta2E = Math.Round(meta2E, 2);
        //    //if (meta2 > 100)
        //    //{
        //    //    meta2 = 100;
        //    //}
        //    pesoAct2E = ((double)count2E / (double)total2E) * peso2E;
        //    pesoAct2E = Math.Round(pesoAct2E, 4);
        //    if (pesoAct2E > peso2E)
        //    {
        //        pesoAct2E = peso2E;
        //    }
        //    pesototalE = pesototalE + pesoAct2E;
        //}



        //// Grupos de investigación con preguntas de investigación formuladas en la convocartoria de Ciclón
        //DataTable totalGPHicieronPreguntas = est.totalGPHicieronPreguntas("", "", "", "");
        //double meta3E = 0;
        //int count3E = 0;
        //int total3E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalgrupos"].ToString());
        //double peso3E = 2.20;
        //double pesoAct3E = 0;

        //if (totalGPHicieronPreguntas != null && totalGPHicieronPreguntas.Rows.Count > 0)
        //{
        //    count3E = totalGPHicieronPreguntas.Rows.Count;
        //    meta3E = ((double)count3E / (double)total3E) * 100;
        //    meta3E = Math.Round(meta3E, 2);
        //    //if (meta3 > 100)
        //    //{
        //    //    meta3 = 100;
        //    //}
        //    pesoAct3E = ((double)count3E / (double)total3E) * peso3E;
        //    pesoAct3E = Math.Round(pesoAct3E, 4);
        //    if (pesoAct3E > peso3E)
        //    {
        //        pesoAct3E = peso3E;
        //    }
        //    pesototalE = pesototalE + pesoAct3E;
        //}


        ////Total grupos de investigación con problemas de investigación planteados en la convocatoria de Ciclón
        //DataTable totalGPHicieronPreguntasB3 = est.totalGPHicieronPreguntasB3("", "", "", "");
        //double meta4E = 0;
        //int count4E = 0;
        //int total4E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalgrupos"].ToString());
        //double peso4E = 2.20;
        //double pesoAct4E = 0;

        //if (totalGPHicieronPreguntasB3 != null && totalGPHicieronPreguntasB3.Rows.Count > 0)
        //{
        //    count4E = totalGPHicieronPreguntasB3.Rows.Count;
        //    meta4E = ((double)count4E / (double)total4E) * 100;
        //    meta4E = Math.Round(meta4E, 2);
        //    //if (meta4 > 100)
        //    //{
        //    //    meta4 = 100;
        //    //}
        //    pesoAct4E = ((double)count4E / (double)total4E) * peso4E;
        //    pesoAct4E = Math.Round(pesoAct4E, 4);
        //    if (pesoAct4E > peso4E)
        //    {
        //        pesoAct4E = peso4E;
        //    }
        //    pesototalE = pesototalE + pesoAct4E;
        //}


        ////5) Grupos de investigación infantiles y juveniles con la bitácora 04 de presupuesto diligenciada
        //DataTable gpbitacora4 = est.gpbitacora4("", "", "", "", "1");
        //double meta5E = 0;
        //int count5E = 0;
        //int total5E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalgrupos"].ToString());
        //double peso5E = 2.20;
        //double pesoAct5E = 0;

        //if (gpbitacora4 != null && gpbitacora4.Rows.Count > 0)
        //{
        //    count5E = gpbitacora4.Rows.Count;
        //    meta5E = ((double)count5E / (double)total5E) * 100;
        //    meta5E = Math.Round(meta5E, 2);
        //    //if (meta5 > 100)
        //    //{
        //    //    meta5 = 100;
        //    //}
        //    pesoAct5E = ((double)count5E / (double)total5E) * peso5E;
        //    pesoAct5E = Math.Round(pesoAct5E, 4);
        //    if (pesoAct5E > peso5E)
        //    {
        //        pesoAct5E = peso5E;
        //    }
        //    pesototalE = pesototalE + pesoAct5E;
        //}


        ////6) Grupos de investigación infantiles y juveniles con trayectorias de indagación diseñadas
        //DataTable gruposInvestigacionBitacora5 = est.gruposInvestigacionBitacora5("", "", "", "");
        //double meta6E = 0;
        //int count6E = 0;
        //int total6E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalgrupos"].ToString());
        //double peso6E = 2.20;
        //double pesoAct6E = 0;

        //if (gruposInvestigacionBitacora5 != null && gruposInvestigacionBitacora5.Rows.Count > 0)
        //{
        //    count6E = gruposInvestigacionBitacora5.Rows.Count;
        //    meta6E = ((double)count6E / (double)total6E) * 100;
        //    meta6E = Math.Round(meta6E, 2);
        //    //if (meta6 > 100)
        //    //{
        //    //    meta6 = 100;
        //    //}
        //    pesoAct6E = ((double)count6E / (double)total6E) * peso6E;
        //    pesoAct6E = Math.Round(pesoAct6E, 4);
        //    if (pesoAct6E > peso6E)
        //    {
        //        pesoAct6E = peso6E;
        //    }
        //    pesototalE = pesototalE + pesoAct6E;
        //}


        ////7) Asistentes a la sesión de asesoría a grupos infantiles y juveniles
        //DataRow asistentesesionasesoriaxestrategia = est.asistentesesionasesoriaxestrategia("", "", "", "", "1");


        //double meta7E = 0;
        //int count7E = 0;
        //int total7E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalasistentesasesorias"].ToString());
        //double peso7E = 2.20;
        //double pesoAct7E = 0;

        //if (asistentesesionasesoriaxestrategia["total"].ToString() != "")
        //{
        //    count7E = Int32.Parse(asistentesesionasesoriaxestrategia["total"].ToString());
        //    meta7E = ((double)count7E / (double)total7E) * 100;
        //    meta7E = Math.Round(meta7E, 2);
        //    //if (meta7 > 100)
        //    //{
        //    //    meta7 = 100;
        //    //}
        //    pesoAct7E = ((double)count7E / (double)total7E) * peso7E;
        //    pesoAct7E = Math.Round(pesoAct7E, 4);
        //    if (pesoAct7E > peso7E)
        //    {
        //        pesoAct7E = peso7E;
        //    }
        //    pesototalE = pesototalE + pesoAct7E;
        //}

        ////8) Asesorias realizadas a cada uno de los grupos de investigación 
        //DataTable noAsesoriasGP = est.noAsesoriasGP("", "", "", "");
        //double meta8E = 0;
        //int count8E = 0;
        //int total8E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["metanoasesoria"].ToString()) * Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalgrupos"].ToString());
        //double peso8E = 2.20;
        //double pesoAct8E = 0;

        //if (noAsesoriasGP != null && noAsesoriasGP.Rows.Count > 0)
        //{
        //    count8E = noAsesoriasGP.Rows.Count;
        //    meta8E = ((double)count8E / (double)total8E) * 100;
        //    meta8E = Math.Round(meta8E, 2);
        //    //if (meta8 > 100)
        //    //{
        //    //    meta8 = 100;
        //    //}
        //    pesoAct8E = ((double)count8E / (double)total8E) * peso8E;
        //    pesoAct8E = Math.Round(pesoAct8E, 4);
        //    if (pesoAct8E > peso8E)
        //    {
        //        pesoAct8E = peso8E;
        //    }
        //    pesototalE = pesototalE + pesoAct8E;
        //}


        ////9) Kit preestructurados de los 4 documentos del programa Ciclón reimpresos
        //DataTable kitpreestructurados = est.kitpreestructurados("", "", "", "");
        //double meta9E = 0;
        //int count9E = 0;
        //int total9E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalkits"].ToString());

        //double peso9E = 1.06;
        //double pesoAct9E = 0;
        //if (kitpreestructurados != null && kitpreestructurados.Rows.Count > 0)
        //{
        //    count9E = kitpreestructurados.Rows.Count;
        //    meta9E = ((double)count9E / (double)total9E) * 100;
        //    meta9E = Math.Round(meta9E, 2);
        //    //if (meta9 > 100)
        //    //{
        //    //    meta9 = 100;
        //    //}
        //    pesoAct9E = ((double)count9E / (double)total9E) * peso9E;
        //    pesoAct9E = Math.Round(pesoAct9E, 4);
        //    if (pesoAct9E > peso9E)
        //    {
        //        pesoAct9E = peso9E;
        //    }
        //    pesototalE = pesototalE + pesoAct9E;
        //}


        ////10)  Estudiantes inscritos en las redes temáticas de la comunidad de práctica, saber, conocimiento y transformación de Ciclón
        //DataTable esturedtematicas = est.esturedtematicasxanio("", "", "", "", "2017");
        //double meta10E = 0;
        //int count10E = 0;
        //int total10E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalesturedestematicas"].ToString());
        //double peso10E = 1.41;
        //double pesoAct10E = 0;

        //if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        //{
        //    count10E = esturedtematicas.Rows.Count;
        //    meta10E = ((double)count10E / (double)total10E) * 100;
        //    meta10E = Math.Round(meta10E, 2);
        //    //if (meta10 > 100)
        //    //{
        //    //    meta10 = 100;
        //    //}
        //    pesoAct10E = ((double)count10E / (double)total10E) * peso10E;
        //    pesoAct10E = Math.Round(pesoAct10E, 4);
        //    if (pesoAct10E > peso10E)
        //    {
        //        pesoAct10E = peso10E;
        //    }
        //    pesototalE = pesototalE + pesoAct10E;
        //}

        ////11) Redes temáticas conformadas
        //DataTable sederedtematicas = est.sederedtematicas("", "", "", "", "2017");
        //double meta11E = 0;
        //int count11E = 0;
        //int total11E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["numeroredes"].ToString());
        //double peso11E = 1.41;
        //double pesoAct11E = 0;
        //if (sederedtematicas != null && sederedtematicas.Rows.Count > 0)
        //{
        //    count11E = sederedtematicas.Rows.Count;
        //    meta11E = ((double)count11E / (double)total11E) * 100;
        //    meta11E = Math.Round(meta11E, 2);
        //    //if (meta11 > 100)
        //    //{
        //    //    meta11 = 100;
        //    //}
        //    pesoAct11E = ((double)count11E / (double)total11E) * peso11E;
        //    pesoAct11E = Math.Round(pesoAct11E, 4);
        //    if (pesoAct11E > peso11E)
        //    {
        //        pesoAct11E = peso11E;
        //    }
        //    pesototalE = pesototalE + pesoAct11E;
        //}

        ////12) Sesiones de formación No. 1 presencial realizadas 
        //DataTable sesionesformacion2016 = est.sesionesformacion2016("", "", "", "", "4", "1");
        //double meta12E = 0;
        //int count12E = 0;
        //int total12E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalsesionpresencial"].ToString());
        //double peso12E = 1.41;
        //double pesoAct12E = 0;
        //if (sesionesformacion2016 != null && sesionesformacion2016.Rows.Count > 0)
        //{
        //    count12E = sesionesformacion2016.Rows.Count;
        //    meta12E = ((double)count12E / (double)total12E) * 100;
        //    meta12E = Math.Round(meta12E, 2);
        //    //if (meta12 > 100)
        //    //{
        //    //    meta12 = 100;
        //    //}
        //    pesoAct12E = ((double)count12E / (double)total12E) * peso12E;
        //    pesoAct12E = Math.Round(pesoAct12E, 4);
        //    if (pesoAct12E > peso12E)
        //    {
        //        pesoAct12E = peso12E;
        //    }
        //    pesototalE = pesototalE + pesoAct12E;
        //}


        ////13) Estudiantes inscritos que participan en la primera sesión  de formación presencial/ Nivel 1 juego Gózate la ciencia.
        //DataTable esturedtematicas2016 = est.esturedtematicasxanio("", "", "", "", "2016");
        ////DataTable estuinscritog001_2016 = est.estuinscritog001_2016(coddepartamento, codmuncipio, codinstitucion, codsede);
        //double meta13E = 0;
        //int count13E = 0;
        //int total13E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalesturedestematicas"].ToString());
        //double peso13E = 1.41;
        //double pesoAct13E = 0;
        //if (esturedtematicas2016 != null && esturedtematicas2016.Rows.Count > 0)
        //{
        //    count13E = esturedtematicas2016.Rows.Count;
        //    meta13E = ((double)count13E / (double)total13E) * 100;
        //    meta13E = Math.Round(meta13E, 2);
        //    //if (meta13 > 100)
        //    //{
        //    //    meta13 = 100;
        //    //}
        //    pesoAct13E = ((double)count13E / (double)total13E) * peso13E;
        //    pesoAct13E = Math.Round(pesoAct13E, 4);
        //    if (pesoAct13E > peso13E)
        //    {
        //        pesoAct13E = peso13E;
        //    }
        //    pesototalE = pesototalE + pesoAct13E;
        //}



        ////14) Sesiones de formación No. 1 virtual realizadas 
        //DataTable sesionformacion_vt = est.sesionformacion_vt("", "", "", "", "4", "1");
        //double meta14E = 0;
        //int count14E = 0;
        //int total14E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalsesionvirtual"].ToString());
        //double peso14E = 1.41;
        //double pesoAct14E = 0;
        //if (sesionformacion_vt != null && sesionformacion_vt.Rows.Count > 0)
        //{
        //    count14E = sesionformacion_vt.Rows.Count;
        //    meta14E = ((double)count14E / (double)total14E) * 100;
        //    meta14E = Math.Round(meta14E, 2);
        //    //if (meta14 > 100)
        //    //{
        //    //    meta14 = 100;
        //    //}
        //    pesoAct14E = ((double)count14E / (double)total14E) * peso14E;
        //    pesoAct14E = Math.Round(pesoAct14E, 4);
        //    if (pesoAct14E > peso14E)
        //    {
        //        pesoAct14E = peso14E;
        //    }
        //    pesototalE = pesototalE + pesoAct14E;
        //}


        ////15) Estudiantes inscritos que participan en la primera sesión  de formación virtual/ Nivel 1 juego Gózate la ciencia.
        //DataTable estuinscritossesion_vt = est.estuinscritossesion_vt("", "", "", "", "4", "1");
        //double meta15E = 0;
        //int count15E = 0;
        //int total15E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalesturedestematicas"].ToString());
        //double peso15E = 1.41;
        //double pesoAct15E = 0;
        ////if (estuinscritossesion_vt != null && estuinscritossesion_vt.Rows.Count > 0)
        ////{
        ////    count15 = estuinscritossesion_vt.Rows.Count;
        ////    meta15 = ((double)count15 / (double)total15) * 100;
        ////    meta15 = Math.Round(meta15, 2);
        ////    if (meta15 > 100)
        ////    {
        ////        meta15 = 100;
        ////    }
        ////}
        //if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        //{
        //    count15E = esturedtematicas.Rows.Count;
        //    meta15E = ((double)count15E / (double)total15E) * 100;
        //    meta15E = Math.Round(meta15E, 2);
        //    //if (meta15 > 100)
        //    //{
        //    //    meta15 = 100;
        //    //}
        //    pesoAct15E = ((double)count15E / (double)total15E) * peso15E;
        //    pesoAct15E = Math.Round(pesoAct15E, 4);
        //    if (pesoAct15E > peso15E)
        //    {
        //        pesoAct15E = peso15E;
        //    }
        //    pesototalE = pesototalE + pesoAct15E;
        //}



        ////16) Sesiones de formación presencial  No. 2 realizadas 
        //DataTable sesionformacion_pre = est.sesionformacion_pre("", "", "", "", 4, 2);
        //double meta16E = 0;
        //int count16E = 0;
        //int total16E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalsesionpresencial"].ToString());
        //double peso16E = 1.41;
        //double pesoAct16E = 0;
        //if (sesionformacion_pre != null && sesionformacion_pre.Rows.Count > 0)
        //{
        //    count16E = sesionformacion_pre.Rows.Count;
        //    meta16E = ((double)count16E / (double)total16E) * 100;
        //    meta16E = Math.Round(meta16E, 2);
        //    //if (meta16 > 100)
        //    //{
        //    //    meta16 = 100;
        //    //}
        //    pesoAct16E = ((double)count16E / (double)total16E) * peso16E;
        //    pesoAct16E = Math.Round(pesoAct16E, 4);
        //    if (pesoAct16E > peso16E)
        //    {
        //        pesoAct16E = peso16E;
        //    }
        //    pesototalE = pesototalE + pesoAct16E;
        //}



        ////17) Estudiantes inscritos que participan en la segunda sesión  de formación presencial/ Nivel 2 juego Gózate la ciencia.
        //DataTable estuinscritossesion_pre = est.estuinscritossesion_pre("", "", "", "", "4", "2");
        //double meta17E = 0;
        //int count17E = 0;
        //int total17E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalesturedestematicas"].ToString());
        //double peso17E = 1.41;
        //double pesoAct17E = 0;
        ////if (estuinscritossesion_pre != null && estuinscritossesion_pre.Rows.Count > 0)
        ////{
        ////    count17 = estuinscritossesion_pre.Rows.Count;
        ////    meta17 = ((double)count17 / (double)total17) * 100;
        ////    meta17 = Math.Round(meta17, 2);
        ////    if (meta17 > 100)
        ////    {
        ////        meta17 = 100;
        ////    }
        ////}
        //if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        //{
        //    count17E = esturedtematicas.Rows.Count;
        //    meta17E = ((double)count17E / (double)total17E) * 100;
        //    meta17E = Math.Round(meta17E, 2);
        //    //if (meta17 > 100)
        //    //{
        //    //    meta17 = 100;
        //    //}
        //    pesoAct17E = ((double)count17E / (double)total17E) * peso17E;
        //    pesoAct17E = Math.Round(pesoAct17E, 4);
        //    if (pesoAct17E > peso17E)
        //    {
        //        pesoAct17E = peso17E;
        //    }
        //    pesototalE = pesototalE + pesoAct17E;
        //}



        ////18) Sesiones de formación virtual No. 2 realizadas 
        //DataTable sesionformacion_vt_s2 = est.sesionformacion_vt("", "", "", "", "4", "2");
        //double meta18E = 0;
        //int count18E = 0;
        //int total18E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalsesionvirtual"].ToString());
        //double peso18E = 0.31;
        //double pesoAct18E = 0;
        //if (sesionformacion_vt_s2 != null && sesionformacion_vt_s2.Rows.Count > 0)
        //{
        //    count18E = sesionformacion_vt_s2.Rows.Count;
        //    meta18E = ((double)count18E / (double)total18E) * 100;
        //    meta18E = Math.Round(meta18E, 2);
        //    //if (meta18 > 100)
        //    //{
        //    //    meta18 = 100;
        //    //}
        //    pesoAct18E = ((double)count18E / (double)total18E) * peso18E;
        //    pesoAct18E = Math.Round(pesoAct18E, 4);
        //    if (pesoAct18E > peso18E)
        //    {
        //        pesoAct18E = peso18E;
        //    }
        //    pesototalE = pesototalE + pesoAct18E;
        //}


        /////19) Estudiantes inscritos que participan en la segunda sesión de formación virtual/ Nivel 2 juego Gózate la ciencia.
        //DataTable estuinscritossesion_vt_s2 = est.estuinscritossesion_vt("", "", "", "", "4", "2");
        //double meta19E = 0;
        //int count19E = 0;
        //int total19E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalesturedestematicas"].ToString());
        //double peso19E = 1.41;
        //double pesoAct19E = 0;
        ////if (estuinscritossesion_vt_s2 != null && estuinscritossesion_vt_s2.Rows.Count > 0)
        ////{
        ////    count19 = estuinscritossesion_vt_s2.Rows.Count;
        ////    meta19 = ((double)count19 / (double)total19) * 100;
        ////    meta19 = Math.Round(meta19, 2);
        ////    if (meta19 > 100)
        ////    {
        ////        meta19 = 100;
        ////    }
        ////}
        //if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        //{
        //    count19E = esturedtematicas.Rows.Count;
        //    meta19E = ((double)count19E / (double)total19E) * 100;
        //    meta19E = Math.Round(meta19E, 2);
        //    //if (meta19 > 100)
        //    //{
        //    //    meta19 = 100;
        //    //}
        //    pesoAct19E = ((double)count19E / (double)total19E) * peso19E;
        //    pesoAct19E = Math.Round(pesoAct19E, 4);
        //    if (pesoAct19E > peso19E)
        //    {
        //        pesoAct19E = peso19E;
        //    }
        //    pesototalE = pesototalE + pesoAct19E;
        //}

        ////20) Sesiones de formación No. 3 realizadas 
        //DataTable sesionformacion_pre_s3 = est.sesionformacion_pre("", "", "", "", 4, 3);
        //double meta20E = 0;
        //int count20E = 0;
        //int total20E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalsesionpresencial"].ToString());
        //double peso20E = 1.41;
        //double pesoAct20E = 0;
        //if (sesionformacion_pre_s3 != null && sesionformacion_pre_s3.Rows.Count > 0)
        //{
        //    count20E = sesionformacion_pre_s3.Rows.Count;
        //    meta20E = ((double)count20E / (double)total20E) * 100;
        //    meta20E = Math.Round(meta20E, 2);
        //    //if (meta20 > 100)
        //    //{
        //    //    meta20 = 100;
        //    //}
        //    pesoAct20E = ((double)count20E / (double)total20E) * peso20E;
        //    pesoAct20E = Math.Round(pesoAct20E, 4);
        //    if (pesoAct20E > peso20E)
        //    {
        //        pesoAct20E = peso20E;
        //    }
        //    pesototalE = pesototalE + pesoAct20E;
        //}


        ////21) Estudiantes inscritos que participan en la tercera sesión  de formación presencial/ Nivel 3 juego Gózate la ciencia.
        //DataTable estuinscritossesion_pre_s3 = est.estuinscritossesion_pre("", "", "", "", "4", "3");
        //double meta21E = 0;
        //int count21E = 0;
        //int total21E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalesturedestematicas"].ToString());
        //double peso21E = 1.41;
        //double pesoAct21E = 0;
        ////if (estuinscritossesion_pre_s3 != null && estuinscritossesion_pre_s3.Rows.Count > 0)
        ////{
        ////    count21 = estuinscritossesion_pre_s3.Rows.Count;
        ////    meta21 = ((double)count21 / (double)total21) * 100;
        ////    meta21 = Math.Round(meta21, 2);
        ////    if (meta21 > 100)
        ////    {
        ////        meta21 = 100;
        ////    }
        ////}
        //if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        //{
        //    count21E = esturedtematicas.Rows.Count;
        //    meta21E = ((double)count21E / (double)total21E) * 100;
        //    meta21E = Math.Round(meta21E, 2);
        //    //if (meta21 > 100)
        //    //{
        //    //    meta21 = 100;
        //    //}
        //    pesoAct21E = ((double)count21E / (double)total21E) * peso21E;
        //    pesoAct21E = Math.Round(pesoAct21E, 4);
        //    if (pesoAct21E > peso21E)
        //    {
        //        pesoAct21E = peso21E;
        //    }
        //    pesototalE = pesototalE + pesoAct21E;
        //}


        ////22) Sesiones de formación virtual  No. 3 realizadas 
        //DataTable sesionformacion_vt_s3 = est.sesionformacion_vt("", "", "", "", "4", "3");
        //double meta22E = 0;
        //int count22E = 0;
        //int total22E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalsesionvirtual"].ToString());
        //double peso22E = 1.41;
        //double pesoAct22E = 0;

        //if (sesionformacion_vt_s3 != null && sesionformacion_vt_s3.Rows.Count > 0)
        //{
        //    count22E = sesionformacion_vt_s3.Rows.Count;
        //    meta22E = ((double)count22E / (double)total22E) * 100;
        //    meta22E = Math.Round(meta22E, 2);
        //    //if (meta22 > 100)
        //    //{
        //    //    meta22 = 100;
        //    //}
        //    pesoAct22E = ((double)count22E / (double)total22E) * peso22E;
        //    pesoAct22E = Math.Round(pesoAct22E, 4);
        //    if (pesoAct22E > peso22E)
        //    {
        //        pesoAct22E = peso22E;
        //    }
        //    pesototalE = pesototalE + pesoAct22E;
        //}


        ////23) Estudiantes inscritos que participan en la tercera sesión  de formación virtual/ Nivel 3 juego Gózate la ciencia.
        //DataTable estuinscritossesion_vt_s3 = est.estuinscritossesion_vt("", "", "", "", "4", "3");
        //double meta23E = 0;
        //int count23E = 0;
        //int total23E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalesturedestematicas"].ToString());
        //double peso23E = 1.41;
        //double pesoAct23E = 0;
        ////if (estuinscritossesion_vt_s3 != null && estuinscritossesion_vt_s3.Rows.Count > 0)
        ////{
        ////    count23 = estuinscritossesion_vt_s3.Rows.Count;
        ////    meta23 = ((double)count23 / (double)total23) * 100;
        ////    meta23 = Math.Round(meta23, 2);
        ////    if (meta23 > 100)
        ////    {
        ////        meta23 = 100;
        ////    }
        ////}
        //if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        //{
        //    count23E = esturedtematicas.Rows.Count;
        //    meta23E = ((double)count23E / (double)total23E) * 100;
        //    meta23E = Math.Round(meta23E, 2);
        //    //if (meta23 > 100)
        //    //{
        //    //    meta23 = 100;
        //    //}
        //    pesoAct23E = ((double)count23E / (double)total23E) * peso23E;
        //    pesoAct23E = Math.Round(pesoAct23E, 4);
        //    if (pesoAct23E > peso23E)
        //    {
        //        pesoAct23E = peso23E;
        //    }
        //    pesototalE = pesototalE + pesoAct23E;
        //}


        ////24) Sesiones de formación No. 4 realizadas
        //DataTable sesionformacion_pre_s4 = est.sesionformacion_pre("", "", "", "", 4, 4);
        //double meta24E = 0;
        //int count24E = 0;
        //int total24E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalsesionpresencial"].ToString());
        //double peso24E = 1.41;
        //double pesoAct24E = 0;
        //if (sesionformacion_pre_s4 != null && sesionformacion_pre_s4.Rows.Count > 0)
        //{
        //    count24E = sesionformacion_pre_s4.Rows.Count;
        //    meta24E = ((double)count24E / (double)total24E) * 100;
        //    meta24E = Math.Round(meta24E, 2);
        //    //if (meta24 > 100)
        //    //{
        //    //    meta24 = 100;
        //    //}
        //    pesoAct24E = ((double)count24E / (double)total24E) * peso24E;
        //    pesoAct24E = Math.Round(pesoAct24E, 4);
        //    if (pesoAct24E > peso24E)
        //    {
        //        pesoAct24E = peso24E;
        //    }
        //    pesototalE = pesototalE + pesoAct24E;
        //}


        ////25) Estudiantes inscritos que participan en la tercera sesión  de formación presencial/ Nivel 4 juego Gózate la ciencia.
        //DataTable estuinscritossesion_pre_s4 = est.estuinscritossesion_pre("", "", "", "", "4", "4");
        //double meta25E = 0;
        //int count25E = 0;
        //int total25E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalesturedestematicas"].ToString());
        //double peso25E = 1.41;
        //double pesoAct25E = 0;
        ////if (estuinscritossesion_pre_s4 != null && estuinscritossesion_pre_s4.Rows.Count > 0)
        ////{
        ////    count25 = estuinscritossesion_pre_s4.Rows.Count;
        ////    meta25 = ((double)count25 / (double)total25) * 100;
        ////    meta25 = Math.Round(meta25, 2);
        ////    if (meta25 > 100)
        ////    {
        ////        meta25 = 100;
        ////    }
        ////}
        //if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        //{
        //    count25E = esturedtematicas.Rows.Count;
        //    meta25E = ((double)count25E / (double)total25E) * 100;
        //    meta25E = Math.Round(meta25E, 2);
        //    //if (meta25 > 100)
        //    //{
        //    //    meta25 = 100;
        //    //}
        //    pesoAct25E = ((double)count25E / (double)total25E) * peso25E;
        //    pesoAct25E = Math.Round(pesoAct25E, 4);
        //    if (pesoAct25E > peso25E)
        //    {
        //        pesoAct25E = peso25E;
        //    }
        //    pesototalE = pesototalE + pesoAct25E;
        //}



        ////26) Sesiones de formación virtual  No.4 realizadas 
        //DataTable sesionformacion_vt_s4 = est.sesionformacion_vt("", "", "", "", "4", "4");
        //double meta26E = 0;
        //int count26E = 0;
        //int total26E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalsesionvirtual"].ToString());
        //double peso26E = 1.41;
        //double pesoAct26E = 0;
        //if (sesionformacion_vt_s4 != null && sesionformacion_vt_s4.Rows.Count > 0)
        //{
        //    count26E = sesionformacion_vt_s4.Rows.Count;
        //    meta26E = ((double)count26E / (double)total26E) * 100;
        //    meta26E = Math.Round(meta26E, 2);
        //    //if (meta26 > 100)
        //    //{
        //    //    meta26 = 100;
        //    //}
        //    pesoAct26E = ((double)count26E / (double)total26E) * peso26E;
        //    pesoAct26E = Math.Round(pesoAct26E, 4);
        //    if (pesoAct26E > peso26E)
        //    {
        //        pesoAct26E = peso26E;
        //    }
        //    pesototalE = pesototalE + pesoAct26E;
        //}


        ////27) Estudiantes inscritos que participan en la tercera sesión  de formación virtual/ Nivel 4 juego Gózate la ciencia.
        //DataTable estuinscritossesion_vt_s4 = est.estuinscritossesion_vt("", "", "", "", "4", "4");
        //double meta27E = 0;
        //int count27E = 0;
        //int total27E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalesturedestematicas"].ToString());
        //double peso27E = 1.41;
        //double pesoAct27E = 0;
        ////if (estuinscritossesion_vt_s4 != null && estuinscritossesion_vt_s4.Rows.Count > 0)
        ////{
        ////    count27 = estuinscritossesion_vt_s4.Rows.Count;
        ////    meta27 = ((double)count27 / (double)total27) * 100;
        ////    meta27 = Math.Round(meta27, 2);
        ////    if (meta27 > 100)
        ////    {
        ////        meta27 = 100;
        ////    }
        ////}
        //if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        //{
        //    count27E = esturedtematicas.Rows.Count;
        //    meta27E = ((double)count27E / (double)total27E) * 100;
        //    meta27E = Math.Round(meta27E, 2);
        //    //if (meta27 > 100)
        //    //{
        //    //    meta27 = 100;
        //    //}
        //    pesoAct27E = ((double)count27E / (double)total27E) * peso27E;
        //    pesoAct27E = Math.Round(pesoAct27E, 4);
        //    if (pesoAct27E > peso27E)
        //    {
        //        pesoAct27E = peso27E;
        //    }
        //    pesototalE = pesototalE + pesoAct27E;
        //}


        ////33) Sesiones de formación No. 5 realizadas
        //DataTable sesionesformacion5 = est.sesionformacion_pre("", "", "", "", 4, 5);
        //double meta33E = 0;
        //int count33E = 0;
        //int total33E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalsesionpresencial"].ToString());
        //double peso33E = 1.41;
        //double pesoAct33E = 0;
        //if (sesionesformacion5 != null && sesionesformacion5.Rows.Count > 0)
        //{
        //    count33E = sesionesformacion5.Rows.Count;
        //    meta33E = ((double)count33E / (double)total33E) * 100;
        //    meta33E = Math.Round(meta33E, 2);
        //    //if (meta33 > 100)
        //    //{
        //    //    meta33 = 100;
        //    //}
        //    pesoAct33E = ((double)count33E / (double)total33E) * peso33E;
        //    pesoAct33E = Math.Round(pesoAct33E, 4);
        //    if (pesoAct33E > peso33E)
        //    {
        //        pesoAct33E = peso33E;
        //    }
        //    pesototalE = pesototalE + pesoAct33E;
        //}


        ////34) Estudiantes inscritos que participan en la quinta sesión  de formación presencial/ Nivel 5 juego Gózate la ciencia.
        //DataTable estuinscritossesion_pre_s5 = est.estuinscritossesion_pre("", "", "", "", "4", "5");
        //double meta34E = 0;
        //int count34E = 0;
        //int total34E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalesturedestematicas"].ToString());
        //double peso34E = 1.41;
        //double pesoAct34E = 0;
        ////if (estuinscritossesion_pre_s5 != null && estuinscritossesion_pre_s5.Rows.Count > 0)
        ////{
        ////    count34 = estuinscritossesion_pre_s5.Rows.Count;
        ////    meta34 = ((double)count34 / (double)total34) * 100;
        ////    meta34 = Math.Round(meta34, 2);
        ////    if (meta34 > 100)
        ////    {
        ////        meta34 = 100;
        ////    }
        ////}
        //if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        //{
        //    count34E = esturedtematicas.Rows.Count;
        //    meta34E = ((double)count34E / (double)total34E) * 100;
        //    meta34E = Math.Round(meta34E, 2);
        //    //if (meta34 > 100)
        //    //{
        //    //    meta34 = 100;
        //    //}
        //    pesoAct34E = ((double)count34E / (double)total34E) * peso34E;
        //    pesoAct34E = Math.Round(pesoAct34E, 4);
        //    if (pesoAct34E > peso34E)
        //    {
        //        pesoAct34E = peso34E;
        //    }
        //    pesototalE = pesototalE + pesoAct34E;
        //}


        ////35) Sesiones de formación virtual No. 5 realizadas 
        //DataTable sesionformacion_vt_s5 = est.sesionformacion_vt("", "", "", "", "4", "5");
        //double meta35E = 0;
        //int count35E = 0;
        //int total35E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalsesionvirtual"].ToString());
        //double peso35E = 1.41;
        //double pesoAct35E = 0;
        //if (sesionformacion_vt_s5 != null && sesionformacion_vt_s5.Rows.Count > 0)
        //{
        //    count35E = sesionformacion_vt_s5.Rows.Count;
        //    meta35E = ((double)count35E / (double)total35E) * 100;
        //    meta35E = Math.Round(meta35E, 2);
        //    //if (meta35 > 100)
        //    //{
        //    //    meta35 = 100;
        //    //}
        //    pesoAct35E = ((double)count35E / (double)total35E) * peso35E;
        //    pesoAct35E = Math.Round(pesoAct35E, 4);
        //    if (pesoAct35E > peso35E)
        //    {
        //        pesoAct35E = peso35E;
        //    }
        //    pesototalE = pesototalE + pesoAct35E;
        //}



        ////36) Estudiantes inscritos que participan en la quinta sesión  de formación virtual/ Nivel 5 juego Gózate la ciencia.
        //DataTable estuinscritossesion_vt_s5 = est.estuinscritossesion_vt("", "", "", "", "4", "5");
        //double meta36 = 0;
        //int count36 = 0;
        //int total36 = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalesturedestematicas"].ToString());
        //double peso36 = 1.41;
        //double pesoAct36 = 0;
        ////if (estuinscritossesion_vt_s5 != null && estuinscritossesion_vt_s5.Rows.Count > 0)
        ////{
        ////    count36 = estuinscritossesion_vt_s5.Rows.Count;
        ////    meta36 = ((double)count36 / (double)total36) * 100;
        ////    meta36 = Math.Round(meta36, 2);
        ////    if (meta36 > 100)
        ////    {
        ////        meta36 = 100;
        ////    }
        ////}
        //if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        //{
        //    count36 = esturedtematicas.Rows.Count;
        //    meta36 = ((double)count36 / (double)total36) * 100;
        //    meta36 = Math.Round(meta36, 2);
        //    //if (meta36 > 100)
        //    //{
        //    //    meta36 = 100;
        //    //}
        //    pesoAct36 = ((double)count36 / (double)total36) * peso36;
        //    pesoAct36 = Math.Round(pesoAct36, 4);
        //    if (pesoAct36 > peso36)
        //    {
        //        pesoAct36 = peso36;
        //    }
        //    pesototalE = pesototalE + pesoAct36;
        //}


        ////--------------- SESION 6 ----------------------
        ////37) Sesiones de formación No. 6 realizadas 
        //DataTable sesionesformacion6 = est.sesionformacion_pre("", "", "", "", 4, 6);
        //double meta37E = 0;
        //int count37E = 0;
        //int total37E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalsesionpresencial"].ToString());
        //double peso37E = 1.41;
        //double pesoAct37E = 0;
        //if (sesionesformacion6 != null && sesionesformacion6.Rows.Count > 0)
        //{
        //    count37E = sesionesformacion6.Rows.Count;
        //    meta37E = ((double)count37E / (double)total37E) * 100;
        //    meta37E = Math.Round(meta37E, 2);
        //    //if (meta37 > 100)
        //    //{
        //    //    meta37 = 100;
        //    //}
        //    pesoAct37E = ((double)count37E / (double)total37E) * peso37E;
        //    pesoAct37E = Math.Round(pesoAct37E, 4);
        //    if (pesoAct37E > peso37E)
        //    {
        //        pesoAct37E = peso37E;
        //    }
        //    pesototalE = pesototalE + pesoAct37E;
        //}


        ////38) Estudiantes inscritos que participan en la sexta sesión  de formación presencial/ Nivel 6 juego Gózate la ciencia
        //DataTable estuinscritossesion_pre_s6 = est.estuinscritossesion_pre("", "", "", "", "4", "6");
        //double meta38E = 0;
        //int count38E = 0;
        //int total38E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalesturedestematicas"].ToString());
        //double peso38E = 1.41;
        //double pesoAct38E = 0;
        ////if (estuinscritossesion_pre_s6 != null && estuinscritossesion_pre_s6.Rows.Count > 0)
        ////{
        ////    count38 = estuinscritossesion_pre_s6.Rows.Count;
        ////    meta38 = ((double)count38 / (double)total38) * 100;
        ////    meta38 = Math.Round(meta38, 2);
        ////    if (meta38 > 100)
        ////    {
        ////        meta38 = 100;
        ////    }
        ////}
        //if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        //{
        //    count38E = esturedtematicas.Rows.Count;
        //    meta38E = ((double)count38E / (double)total38E) * 100;
        //    meta38E = Math.Round(meta38E, 2);
        //    //if (meta38 > 100)
        //    //{
        //    //    meta38 = 100;
        //    //}
        //    pesoAct38E = ((double)count38E / (double)total38E) * peso38E;
        //    pesoAct38E = Math.Round(pesoAct38E, 4);
        //    if (pesoAct38E > peso38E)
        //    {
        //        pesoAct38E = peso38E;
        //    }
        //    pesototalE = pesototalE + pesoAct38E;
        //}


        ////39) Sesiones de formación virtual  No. 6 realizadas 
        //DataTable sesionformacion_vt_s6 = est.sesionformacion_vt("", "", "", "", "4", "6");
        //double meta39E = 0;
        //int count39E = 0;
        //int total39E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalsesionvirtual"].ToString());
        //double peso39E = 1.41;
        //double pesoAct39E = 0;
        //if (sesionformacion_vt_s6 != null && sesionformacion_vt_s6.Rows.Count > 0)
        //{
        //    count39E = sesionformacion_vt_s6.Rows.Count;
        //    meta39E = ((double)count39E / (double)total39E) * 100;
        //    meta39E = Math.Round(meta39E, 2);
        //    //if (meta39 > 100)
        //    //{
        //    //    meta39 = 100;
        //    //}
        //    pesoAct39E = ((double)count39E / (double)total39E) * peso39E;
        //    pesoAct39E = Math.Round(pesoAct39E, 4);
        //    if (pesoAct39E > peso39E)
        //    {
        //        pesoAct39E = peso39E;
        //    }
        //    pesototalE = pesototalE + pesoAct39E;
        //}


        ////40)  Estudiantes inscritos que participan en la sexta sesión  de formación virtual/ Nivel 6 juego Gózate la ciencia.
        //DataTable estuinscritossesion_vt_s6 = est.estuinscritossesion_vt("", "", "", "", "4", "6");
        //double meta40 = 0;
        //int count40 = 0;
        //int total40 = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalesturedestematicas"].ToString());
        //double peso40 = 1.41;
        //double pesoAct40 = 0;
        ////if (estuinscritossesion_vt_s6 != null && estuinscritossesion_vt_s6.Rows.Count > 0)
        ////{
        ////    count40 = estuinscritossesion_vt_s6.Rows.Count;
        ////    meta40 = ((double)count40 / (double)total40) * 100;
        ////    meta40 = Math.Round(meta40, 2);
        ////    if (meta40 > 100)
        ////    {
        ////        meta40 = 100;
        ////    }
        ////}
        //if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        //{
        //    count40 = esturedtematicas.Rows.Count;
        //    meta40 = ((double)count40 / (double)total40) * 100;
        //    meta40 = Math.Round(meta40, 2);
        //    //if (meta40 > 100)
        //    //{
        //    //    meta40 = 100;
        //    //}
        //    pesoAct40 = ((double)count40 / (double)total40) * peso40;
        //    pesoAct40 = Math.Round(pesoAct40, 4);
        //    if (pesoAct40 > peso40)
        //    {
        //        pesoAct40 = peso40;
        //    }
        //    pesototalE = pesototalE + pesoAct40;
        //}

        ////--------------- SESION 7 ----------------------
        ////41) Sesiones de formación No. 7 realizadas 
        //DataTable sesionesformacion7 = est.sesionformacion_pre("", "", "", "", 4, 7);
        //double meta41E = 0;
        //int count41E = 0;
        //int total41E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalsesionpresencial"].ToString());
        //double peso41E = 1.41;
        //double pesoAct41E = 0;
        //if (sesionesformacion7 != null && sesionesformacion7.Rows.Count > 0)
        //{
        //    count41E = sesionesformacion7.Rows.Count;
        //    meta41E = ((double)count41E / (double)total41E) * 100;
        //    meta41E = Math.Round(meta41E, 2);
        //    //if (meta41 > 100)
        //    //{
        //    //    meta41 = 100;
        //    //}
        //    pesoAct41E = ((double)count41E / (double)total41E) * peso41E;
        //    pesoAct41E = Math.Round(pesoAct41E, 4);
        //    if (pesoAct41E > peso41E)
        //    {
        //        pesoAct41E = peso41E;
        //    }
        //    pesototalE = pesototalE + pesoAct41E;
        //}

        ////42) Estudiantes inscritos que participan en la séptima sesión  de formación presencial/ Nivel 1 juego Gózate la ciencia
        //DataTable estuinscritossesion_pre_s7 = est.estuinscritossesion_pre("", "", "", "", "4", "7");
        //double meta42E = 0;
        //int count42E = 0;
        //int total42E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalesturedestematicas"].ToString());
        //double peso42E = 1.41;
        //double pesoAct42E = 0;
        ////if (estuinscritossesion_pre_s7 != null && estuinscritossesion_pre_s7.Rows.Count > 0)
        ////{
        ////    count42 = estuinscritossesion_pre_s7.Rows.Count;
        ////    meta42 = ((double)count42 / (double)total42) * 100;
        ////    meta42 = Math.Round(meta42, 2);
        ////    if (meta42 > 100)
        ////    {
        ////        meta42 = 100;
        ////    }
        ////}
        //if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        //{
        //    count42E = esturedtematicas.Rows.Count;
        //    meta42E = ((double)count42E / (double)total42E) * 100;
        //    meta42E = Math.Round(meta42E, 2);
        //    //if (meta42 > 100)
        //    //{
        //    //    meta42 = 100;
        //    //}
        //    pesoAct42E = ((double)count42E / (double)total42E) * peso42E;
        //    pesoAct42E = Math.Round(pesoAct42E, 4);
        //    if (pesoAct42E > peso42E)
        //    {
        //        pesoAct42E = peso42E;
        //    }
        //    pesototalE = pesototalE + pesoAct42E;
        //}


        ////43) Sesiones de formación virtual  No. 7 realizadas 
        //DataTable sesionformacion_vt_s7 = est.sesionformacion_vt("", "", "", "", "4", "7");
        //double meta43E = 0;
        //int count43E = 0;
        //int total43E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalsesionvirtual"].ToString());
        //double peso43E = 1.41;
        //double pesoAct43E = 0;
        //if (sesionformacion_vt_s7 != null && sesionformacion_vt_s7.Rows.Count > 0)
        //{
        //    count43E = sesionformacion_vt_s7.Rows.Count;
        //    meta43E = ((double)count43E / (double)total43E) * 100;
        //    meta43E = Math.Round(meta43E, 2);
        //    //if (meta43 > 100)
        //    //{
        //    //    meta43 = 100;
        //    //}
        //    pesoAct43E = ((double)count43E / (double)total43E) * peso43E;
        //    pesoAct43E = Math.Round(pesoAct43E, 4);
        //    if (pesoAct43E > peso43E)
        //    {
        //        pesoAct43E = peso43E;
        //    }
        //    pesototalE = pesototalE + pesoAct43E;
        //}


        ////44) Estudiantes inscritos que participan en la séptima sesión  de formación virtual/ Nivel 7 juego Gózate la ciencia 
        //DataTable estuinscritossesion_vt_s7 = est.estuinscritossesion_vt("", "", "", "", "4", "7");
        //double meta44 = 0;
        //int count44 = 0;
        //int total44 = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalesturedestematicas"].ToString());
        //double peso44 = 1.41;
        //double pesoAct44 = 0;
        ////if (estuinscritossesion_vt_s7 != null && estuinscritossesion_vt_s7.Rows.Count > 0)
        ////{
        ////    count44 = estuinscritossesion_vt_s7.Rows.Count;
        ////    meta44 = ((double)count44 / (double)total44) * 100;
        ////    meta44 = Math.Round(meta44, 2);
        ////    if (meta44 > 100)
        ////    {
        ////        meta44 = 100;
        ////    }
        ////}
        //if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        //{
        //    count44 = esturedtematicas.Rows.Count;
        //    meta44 = ((double)count44 / (double)total44) * 100;
        //    meta44 = Math.Round(meta44, 2);
        //    //if (meta44 > 100)
        //    //{
        //    //    meta44 = 100;
        //    //}
        //    pesoAct44 = ((double)count44 / (double)total44) * peso44;
        //    pesoAct44 = Math.Round(pesoAct44, 4);
        //    if (pesoAct44 > peso44)
        //    {
        //        pesoAct44 = peso44;
        //    }
        //    pesototalE = pesototalE + pesoAct44;
        //}




        ////--------------- SESION 8 ----------------------
        ////45) Sesiones de formación No. 8 realizadas 
        //DataTable sesionesformacion8 = est.sesionformacion_pre("", "", "", "", 4, 8);
        //double meta45E = 0;
        //int count45E = 0;
        //int total45E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalsesionpresencial"].ToString());
        //double peso45E = 1.41;
        //double pesoAct45E = 0;
        //if (sesionesformacion8 != null && sesionesformacion8.Rows.Count > 0)
        //{
        //    count45E = sesionesformacion8.Rows.Count;
        //    meta45E = ((double)count45E / (double)total45E) * 100;
        //    meta45E = Math.Round(meta45E, 2);
        //    //if (meta45 > 100)
        //    //{
        //    //    meta45 = 100;
        //    //}
        //    pesoAct45E = ((double)count45E / (double)total45E) * peso45E;
        //    pesoAct45E = Math.Round(pesoAct45E, 4);
        //    if (pesoAct45E > peso45E)
        //    {
        //        pesoAct45E = peso45E;
        //    }
        //    pesototalE = pesototalE + pesoAct45E;
        //}


        ////46) Estudiantes inscritos que participan en la  octava sesión  de formación presencial/ Nivel 8 juego Gózate la ciencia
        //DataTable estuinscritossesion_pre_s8 = est.estuinscritossesion_pre("", "", "", "", "4", "8");
        //double meta46E = 0;
        //int count46E = 0;
        //int total46E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalesturedestematicas"].ToString());
        //double peso46E = 1.41;
        //double pesoAct46E = 0;
        ////if (estuinscritossesion_pre_s8 != null && estuinscritossesion_pre_s8.Rows.Count > 0)
        ////{
        ////    count46 = estuinscritossesion_pre_s8.Rows.Count;
        ////    meta46 = ((double)count46 / (double)total46) * 100;
        ////    meta46 = Math.Round(meta46, 2);
        ////    if (meta46 > 100)
        ////    {
        ////        meta46 = 100;
        ////    }
        ////}
        //if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        //{
        //    count46E = esturedtematicas.Rows.Count;
        //    meta46E = ((double)count46E / (double)total46E) * 100;
        //    meta46E = Math.Round(meta46E, 2);
        //    //if (meta46 > 100)
        //    //{
        //    //    meta46 = 100;
        //    //}
        //    pesoAct46E = ((double)count46E / (double)total46E) * peso46E;
        //    pesoAct46E = Math.Round(pesoAct46E, 4);
        //    if (pesoAct46E > peso46E)
        //    {
        //        pesoAct46E = peso46E;
        //    }
        //    pesototalE = pesototalE + pesoAct46E;
        //}

        ////47) Sesiones de formación virtual No. 8 realizadas 
        //DataTable sesionformacion_vt_s8 = est.sesionformacion_vt("", "", "", "", "4", "8");
        //double meta47E = 0;
        //int count47E = 0;
        //int total47E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalsesionvirtual"].ToString());
        //double peso47E = 1.41;
        //double pesoAct47E = 0;
        //if (sesionformacion_vt_s8 != null && sesionformacion_vt_s8.Rows.Count > 0)
        //{
        //    count47E = sesionformacion_vt_s8.Rows.Count;
        //    meta47E = ((double)count47E / (double)total47E) * 100;
        //    meta47E = Math.Round(meta47E, 2);
        //    //if (meta47 > 100)
        //    //{
        //    //    meta47 = 100;
        //    //}
        //    pesoAct47E = ((double)count47E / (double)total47E) * peso47E;
        //    pesoAct47E = Math.Round(pesoAct47E, 4);
        //    if (pesoAct47E > peso47E)
        //    {
        //        pesoAct47E = peso47E;
        //    }
        //    pesototalE = pesototalE + pesoAct47E;
        //}


        ////48) Estudiantes inscritos que participan en la  octava sesión  de formación virtual/ Nivel 8 juego Gózate la ciencia
        //DataTable estuinscritossesion_vt_s8 = est.estuinscritossesion_vt("", "", "", "", "4", "8");
        //double meta48 = 0;
        //int count48 = 0;
        //int total48 = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalesturedestematicas"].ToString());
        //double peso48 = 1.41;
        //double pesoAct48 = 0;
        ////if (estuinscritossesion_vt_s8 != null && estuinscritossesion_vt_s8.Rows.Count > 0)
        ////{
        ////    count48 = estuinscritossesion_vt_s8.Rows.Count;
        ////    meta48 = ((double)count48 / (double)total48) * 100;
        ////    meta48 = Math.Round(meta48, 2);
        ////    if (meta48 > 100)
        ////    {
        ////        meta48 = 100;
        ////    }
        ////}
        //if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        //{
        //    count48 = esturedtematicas.Rows.Count;
        //    meta48 = ((double)count48 / (double)total48) * 100;
        //    meta48 = Math.Round(meta48, 2);
        //    //if (meta48 > 100)
        //    //{
        //    //    meta48 = 100;
        //    //}
        //    pesoAct48 = ((double)count48 / (double)total48) * peso48;
        //    pesoAct48 = Math.Round(pesoAct48, 4);
        //    if (pesoAct48 > peso48)
        //    {
        //        pesoAct48 = peso48;
        //    }
        //    pesototalE = pesototalE + pesoAct48;
        //}



        ////--------------- SESION 9 ----------------------
        ////49) Sesiones de formación No. 9 realizadas 
        //DataTable sesionesformacion9 = est.sesionformacion_pre("", "", "", "", 4, 9);
        //double meta49E = 0;
        //int count49E = 0;
        //int total49E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalsesionpresencial"].ToString());
        //double peso49E = 1.41;
        //double pesoAct49E = 0;
        //if (sesionesformacion9 != null && sesionesformacion9.Rows.Count > 0)
        //{
        //    count49E = sesionesformacion9.Rows.Count;
        //    meta49E = ((double)count49E / (double)total49E) * 100;
        //    meta49E = Math.Round(meta49E, 2);
        //    //if (meta49 > 100)
        //    //{
        //    //    meta49 = 100;
        //    //}
        //    pesoAct49E = ((double)count49E / (double)total49E) * peso49E;
        //    pesoAct49E = Math.Round(pesoAct49E, 4);
        //    if (pesoAct49E > peso49E)
        //    {
        //        pesoAct49E = peso49E;
        //    }
        //    pesototalE = pesototalE + pesoAct49E;
        //}

        ////50) Estudiantes inscritos que participan en la  novena sesión  de formación presencial/ Nivel 9 juego Gózate la ciencia
        //DataTable estuinscritossesion_pre_s9 = est.estuinscritossesion_pre("", "", "", "", "4", "9");
        //double meta50E = 0;
        //int count50E = 0;
        //int total50E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalesturedestematicas"].ToString());
        //double peso50E = 1.41;
        //double pesoAct50E = 0;
        ////if (estuinscritossesion_pre_s9 != null && estuinscritossesion_pre_s9.Rows.Count > 0)
        ////{
        ////    count50 = estuinscritossesion_pre_s9.Rows.Count;
        ////    meta50 = ((double)count50 / (double)total50) * 100;
        ////    meta50 = Math.Round(meta50, 2);
        ////    if (meta50 > 100)
        ////    {
        ////        meta50 = 100;
        ////    }
        ////}
        //if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        //{
        //    count50E = esturedtematicas.Rows.Count;
        //    meta50E = ((double)count50E / (double)total50E) * 100;
        //    meta50E = Math.Round(meta50E, 2);
        //    //if (meta50 > 100)
        //    //{
        //    //    meta50 = 100;
        //    //}
        //    pesoAct50E = ((double)count50E / (double)total50E) * peso50E;
        //    pesoAct50E = Math.Round(pesoAct50E, 4);
        //    if (pesoAct50E > peso50E)
        //    {
        //        pesoAct50E = peso50E;
        //    }
        //    pesototalE = pesototalE + pesoAct50E;
        //}



        ////51) Sesiones de formación virtual No. 9 realizadas 
        //DataTable sesionformacion_vt_s9 = est.sesionformacion_vt("", "", "", "", "4", "9");
        //double meta51E = 0;
        //int count51E = 0;
        //int total51E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalsesionvirtual"].ToString());
        //double peso51E = 1.41;
        //double pesoAct51E = 0;
        //if (sesionformacion_vt_s9 != null && sesionformacion_vt_s9.Rows.Count > 0)
        //{
        //    count51E = sesionformacion_vt_s9.Rows.Count;
        //    meta51E = ((double)count51E / (double)total51E) * 100;
        //    meta51E = Math.Round(meta51E, 2);
        //    //if (meta51 > 100)
        //    //{
        //    //    meta51 = 100;
        //    //}
        //    pesoAct51E = ((double)count51E / (double)total51E) * peso51E;
        //    pesoAct51E = Math.Round(pesoAct51E, 4);
        //    if (pesoAct51E > peso51E)
        //    {
        //        pesoAct51E = peso51E;
        //    }
        //    pesototalE = pesototalE + pesoAct51E;
        //}


        ////52) Estudiantes inscritos que participan en la  novena sesión  de formación virtual/ Nivel 9 juego Gózate la ciencia
        //DataTable estuinscritossesion_vt_s9 = est.estuinscritossesion_vt("", "", "", "", "4", "9");
        //double meta52E = 0;
        //int count52E = 0;
        //int total52E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalesturedestematicas"].ToString());
        //double peso52E = 1.41;
        //double pesoAct52E = 0;
        ////if (estuinscritossesion_vt_s9 != null && estuinscritossesion_vt_s9.Rows.Count > 0)
        ////{
        ////    count52 = estuinscritossesion_vt_s9.Rows.Count;
        ////    meta52 = ((double)count52 / (double)total52) * 100;
        ////    meta52 = Math.Round(meta52, 2);
        ////    if (meta52 > 100)
        ////    {
        ////        meta52 = 100;
        ////    }
        ////}
        //if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        //{
        //    count52E = esturedtematicas.Rows.Count;
        //    meta52E = ((double)count52E / (double)total52E) * 100;
        //    meta52E = Math.Round(meta52E, 2);
        //    //if (meta52 > 100)
        //    //{
        //    //    meta52 = 100;
        //    //}
        //    pesoAct52E = ((double)count52E / (double)total52E) * peso52E;
        //    pesoAct52E = Math.Round(pesoAct52E, 4);
        //    if (pesoAct52E > peso52E)
        //    {
        //        pesoAct52E = peso52E;
        //    }
        //    pesototalE = pesototalE + pesoAct52E;
        //}


        ////--------------- SESION 10 ----------------------
        ////53) Sesiones de formación No. 9 realizadas 
        //DataTable sesionesformacion10 = est.sesionformacion_pre("", "", "", "", 4, 10);
        //double meta53E = 0;
        //int count53E = 0;
        //int total53E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalsesionpresencial"].ToString());
        //double peso53E = 1.41;
        //double pesoAct53E = 0;
        //if (sesionesformacion10 != null && sesionesformacion10.Rows.Count > 0)
        //{
        //    count53E = sesionesformacion10.Rows.Count;
        //    meta53E = ((double)count53E / (double)total53E) * 100;
        //    meta53E = Math.Round(meta53E, 2);
        //    //if (meta53 > 100)
        //    //{
        //    //    meta53 = 100;
        //    //}
        //    pesoAct53E = ((double)count53E / (double)total53E) * peso53E;
        //    pesoAct53E = Math.Round(pesoAct53E, 4);
        //    if (pesoAct53E > peso53E)
        //    {
        //        pesoAct53E = peso53E;
        //    }
        //    pesototalE = pesototalE + pesoAct53E;
        //}


        ////54)  Estudiantes inscritos que participan en la decina sesión  de formación presencial/ Nivel 10 juego Gózate la ciencia
        //DataTable estuinscritossesion_pre_s10 = est.estuinscritossesion_pre("", "", "", "", "4", "10");
        //double meta54E = 0;
        //int count54E = 0;
        //int total54E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalesturedestematicas"].ToString());
        //double peso54E = 1.41;
        //double pesoAct54E = 0;
        ////if (estuinscritossesion_pre_s10 != null && estuinscritossesion_pre_s10.Rows.Count > 0)
        ////{
        ////    count54 = estuinscritossesion_pre_s10.Rows.Count;
        ////    meta54 = ((double)count54 / (double)total54) * 100;
        ////    meta54 = Math.Round(meta54, 2);
        ////    if (meta54 > 100)
        ////    {
        ////        meta54 = 100;
        ////    }
        ////}
        //if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        //{
        //    count54E = esturedtematicas.Rows.Count;
        //    meta54E = ((double)count54E / (double)total54E) * 100;
        //    meta54E = Math.Round(meta54E, 2);
        //    //if (meta54 > 100)
        //    //{
        //    //    meta54 = 100;
        //    //}
        //    pesoAct54E = ((double)count54E / (double)total54E) * peso54E;
        //    pesoAct54E = Math.Round(pesoAct54E, 4);
        //    if (pesoAct54E > peso54E)
        //    {
        //        pesoAct54E = peso54E;
        //    }
        //    pesototalE = pesototalE + pesoAct54E;
        //}



        ////55) Sesiones de formación virtual No. 10 realizadas 
        //DataTable sesionformacion_vt_s10 = est.sesionformacion_vt("", "", "", "", "4", "10");
        //double meta55E = 0;
        //int count55E = 0;
        //int total55E = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalsesionvirtual"].ToString());
        //double peso55E = 1.41;
        //double pesoAct55E = 0;
        //if (sesionformacion_vt_s10 != null && sesionformacion_vt_s10.Rows.Count > 0)
        //{
        //    count55E = sesionformacion_vt_s10.Rows.Count;
        //    meta55E = ((double)count55E / (double)total55E) * 100;
        //    meta55E = Math.Round(meta55E, 2);
        //    //if (meta55 > 100)
        //    //{
        //    //    meta55 = 100;
        //    //}
        //    pesoAct55E = ((double)count55E / (double)total55E) * peso55E;
        //    pesoAct55E = Math.Round(pesoAct55E, 4);
        //    if (pesoAct55E > peso55E)
        //    {
        //        pesoAct55E = peso55E;
        //    }
        //    pesototalE = pesototalE + pesoAct55E;
        //}



        ////56) Estudiantes inscritos que participan en la decina sesión  de formación virtual/ Nivel 10 juego Gózate la ciencia
        //DataTable estuinscritossesion_vt_s10 = est.estuinscritossesion_vt("", "", "", "", "4", "10");
        //double meta56 = 0;
        //int count56 = 0;
        //int total56 = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalesturedestematicas"].ToString());
        //double peso56 = 1.41;
        //double pesoAct56 = 0;
        ////if (estuinscritossesion_vt_s10 != null && estuinscritossesion_vt_s10.Rows.Count > 0)
        ////{
        ////    count56 = estuinscritossesion_vt_s10.Rows.Count;
        ////    meta56 = ((double)count56 / (double)total56) * 100;
        ////    meta56 = Math.Round(meta56, 2);
        ////    if (meta56 > 100)
        ////    {
        ////        meta56 = 100;
        ////    }
        ////}
        //if (esturedtematicas != null && esturedtematicas.Rows.Count > 0)
        //{
        //    count56 = esturedtematicas.Rows.Count;
        //    meta56 = ((double)count56 / (double)total56) * 100;
        //    meta56 = Math.Round(meta56, 2);
        //    //if (meta56 > 100)
        //    //{
        //    //    meta56 = 100;
        //    //}
        //    pesoAct56 = ((double)count56 / (double)total56) * peso56;
        //    pesoAct56 = Math.Round(pesoAct56, 4);
        //    if (pesoAct56 > peso56)
        //    {
        //        pesoAct56 = peso56;
        //    }
        //    pesototalE = pesototalE + pesoAct56;
        //}


        ////57) Estudiantes participantes  en las jornadas de formación en la pregunta como punto de partida y en la ruta metodológica del programa Ciclón 
        //DataTable estuinscritossesion_vt_s101 = c.listarEncaJornadasFormacionTodosIndicador("", "", "", "", "1", "1");
        //double meta561 = 0;
        //int count561 = 0;
        ///*Falta el total por sede => */
        //int total561 = Convert.ToInt32(loadTotalesIndicadoresxSedeE["totalesturedestematicas"].ToString());
        //double peso561 = 5.28;
        //double pesoAct561 = 0;
        ////if (estuinscritossesion_vt_s10 != null && estuinscritossesion_vt_s10.Rows.Count > 0)
        ////{
        ////    count56 = estuinscritossesion_vt_s10.Rows.Count;
        ////    meta56 = ((double)count56 / (double)total56) * 100;
        ////    meta56 = Math.Round(meta56, 2);
        ////    if (meta56 > 100)
        ////    {
        ////        meta56 = 100;
        ////    }
        ////}
        //if (estuinscritossesion_vt_s101 != null && estuinscritossesion_vt_s101.Rows.Count > 0)
        //{
        //    for (int g = 0; g < estuinscritossesion_vt_s101.Rows.Count; g++)
        //    {
        //        count561 += Convert.ToInt32(estuinscritossesion_vt_s101.Rows[g]["nroasistentes"].ToString());
        //    }
        //    meta561 = ((double)count561 / (double)total561) * 100;
        //    meta561 = Math.Round(meta561, 2);
        //    //if (meta56 > 100)
        //    //{
        //    //    meta56 = 100;
        //    //}
        //    pesoAct561 = ((double)count561 / (double)total561) * peso561;
        //    pesoAct561 = Math.Round(pesoAct561, 4);
        //    if (pesoAct561 > peso561)
        //    {
        //        pesoAct561 = peso561;
        //    }
        //    pesototalE = pesototalE + pesoAct561;
        //}


        ////Niños, niñas y jóvenes inscritos en grupos de investigación infantiles y juveniles seleccionados en la convocatoria Ciclón 
        //DataTable totalEstudiantesMatriculadosGP = c.totalestudiantesparticipantesgi("", "", "", "", "");
        //double meta3_ = 0;
        //int count3_ = 0;
        //int total3_ = 0;
        //double pesototal3_ = 2.20;
        //double peso3_ = 0;
        //if (totalEstudiantesMatriculadosGP != null && totalEstudiantesMatriculadosGP.Rows.Count > 0)
        //{
        //    count3_ = totalEstudiantesMatriculadosGP.Rows.Count;
        //    //count3 = 32798;
        //    meta3_ = ((double)count3_ / (double)total3_) * 100;
        //    meta3_ = Math.Round(meta3_, 2);
        //    //if (meta3 > 100)
        //    //{
        //    //    meta3 = 100;
        //    //}
        //    count3_ = totalEstudiantesMatriculadosGP.Rows.Count;

        //    peso3_ = ((double)count3_ / (double)total3) * pesototal3_;
        //    peso3_ = Math.Round(peso3_, 4);
        //    if (peso3_ > pesototal3_)
        //    {
        //        peso3_ = pesototal3_;
        //    }
        //    pesototalE = pesototalE + peso3_;
        //}


        ////Total grupos de investigación con registro de avance del presupuesto
        //DataTable gruposInvestigacionPresupuesto = est.gruposInvestigacionPresupuesto("", "", "", "");
        //double meta2as = 0;
        //int count2as = 0;
        //int total2as = 0;
        //double pesototal2as = 2.20;
        //double peso2as = 0;
        //if (gruposInvestigacionPresupuesto != null && gruposInvestigacionPresupuesto.Rows.Count > 0)
        //{
        //    count2as = gruposInvestigacionPresupuesto.Rows.Count;
        //    meta2as = ((double)count2as / (double)total2as) * 100;
        //    meta2as = Math.Round(meta2as, 2);
        //    //if (meta2 > 100)
        //    //{
        //    //    meta2 = 100;
        //    //}
        //    count2as = gruposInvestigacionPresupuesto.Rows.Count;

        //    peso2as = ((double)count2as / (double)total2as) * pesototal2as;
        //    peso2as = Math.Round(peso2as, 4);
        //    if (peso2as > pesototal2as)
        //    {
        //        peso2as = pesototal2as;
        //    }
        //    pesototalE = pesototalE + peso2as;
        //}



        ////Informes de investigación elaborados por los grupos de investigación infantiles y juveniles
        //double meta1ie = 0;
        //int count1ie = 0;
        //int total1ie = 420;
        //double pesototal1ie = 0.31;
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
        //pesototalE = pesototalE + peso1ie;



        ////Publicaciones impresas y/o digitales (2  de los procesos y resultados de los grupos de investigación  y  de los resultados de la implementación del proyecto). 
        //DataTable guias2 = est.cargarEvidenciasPublicaciones("1");
        //double meta1412 = 0;
        //int count1412 = 0;
        //int total1412 = 0;
        //double pesototal1412 = 0.31;
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
        //    pesototalE = pesototalE + peso1412;
        //}


        ////Guías de investigación rediseñadas e impresas
        //DataTable guias = est.cargarEvidenciasPublicaciones("2");
        //double meta141 = 0;
        //int count141 = 0;
        //int total141 = 0;
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
        //    pesototalE = pesototalE + peso141;
        //}


        ////16361 dotaciones y desarrollo del la infraestructura tecnológica y comunicacional 
        //DataTable tables = c.EntregaTabletsxSede("", "", "", "");
        //double metatables = 0;
        //int counttables = 0;
        //int totaltables = 260;
        //double pesototaltables = 42.16;
        //double pesotables = 0;
        //if (tables != null && tables.Rows.Count > 0)
        //{
        //    counttables = tables.Rows.Count;
        //    //for (int g = 0; g < tables.Rows.Count; g++)
        //    //{
        //    //    counttables += Convert.ToInt32(tables.Rows[g]["total"].ToString());
        //    //}
        //    metatables = ((double)counttables / (double)totaltables) * 100;
        //    metatables = Math.Round(metatables, 2);
        //    //if (meta2 > 100)
        //    //{
        //    //    meta2 = 100;
        //    //}

        //    pesotables = ((double)counttables / (double)totaltables) * pesototaltables;
        //    pesotables = Math.Round(pesotables, 4);
        //    if (pesotables > pesototaltables)
        //    {
        //        pesotables = pesototaltables;
        //    }
        //    pesototalE = pesototalE + pesotables;
        //}


        //Documentos de introducción de la IEP apoyada en TIC en los currículos de las sedes educativas.
        DataTable cuc = null;

        double metacuc = 0;
        int countcuc = 0;
        int totalcuc = 0;
        double pesototalcuc = 11.11;
        double pesocuc = 0;
        // if ((cuc != null && cuc.Rows.Count >= 0))
        // {
            // countcuc = cuc.Rows.Count;

            // metacuc = ((double)countcuc / (double)totalcuc) * 100;
            // metacuc = Math.Round(metacuc, 2);
            //if (meta1 > 100)
            //{
            //    meta1 = 100;
            //}

            // pesocuc = ((double)countcuc / (double)totalcuc) * pesototalcuc;
            // pesocuc = Math.Round(pesocuc, 4);
            // if (pesocuc == pesototalcuc)
            // {
            //     pesocuc = pesototalcuc;
            // }
            
        // }

        pesototal = pesototal + pesototalcuc;
        
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b>  CONTRAPARTIDA CUC (Cumplimiento del indicador, previa aprobación de la interventoría )</td>";
        ca += "<td class='center' >" + totalcuc + "</td>";
        ca += "<td class='center'>" + countcuc + "</td>";
        ca += "<td class='center'>" + metacuc + "%</td>";
        ca += "<td class='center'>" + pesototalcuc + "</td>";
        ca += "<td class='center'>-</td>";
        ca += "</tr>";

        ca += "<tr>";
        ca += "<td></td>";
        ca += "<td></td>";
        ca += "<td></td>";
        ca += "<td>TOTAL</td>";
        ca += "<td>" + pesototal +  "</td>";

        ///////////////////////////////////////////////////

        //double porcentaje = Math.Round(pesototal, 2);
        //porcentaje = Math.Round(porcentaje / 2, 2);

        //double porcentajeE = Math.Round(pesototalE, 2);
        //porcentajeE = Math.Round(porcentajeE / 2, 2);

        //ca += "@" + porcentaje + "@" + porcentajeE; ;

        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string maestrosmatriculadosestra2()
    {
        string ca = "lleno@";
        Estrategias est = new Estrategias();
        DataTable maestrosmatriculadosestra2 = est.maestrosmatriculadosestra2("", "", "", "", "2");
        
        if (maestrosmatriculadosestra2 != null && maestrosmatriculadosestra2.Rows.Count > 0)
        {
            for (int i = 0; i < maestrosmatriculadosestra2.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + maestrosmatriculadosestra2.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + maestrosmatriculadosestra2.Rows[i]["institicion"].ToString() + "</td>";
                ca += "<td>" + maestrosmatriculadosestra2.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + maestrosmatriculadosestra2.Rows[i]["identificacion"].ToString() + "</td>";
                ca += "<td>" + maestrosmatriculadosestra2.Rows[i]["nomdocente"].ToString() + "</td>";
                ca += "</tr>";
            }
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string maestrosmatriculadosestra2Det()
    {
        string ca = "lleno@";
        Estrategias est = new Estrategias();
        DataTable maestrosmatriculadosestra2 = est.maestrosmatriculadosestra2Det("", "", "", "", "2");

        if (maestrosmatriculadosestra2 != null && maestrosmatriculadosestra2.Rows.Count > 0)
        {
            for (int i = 0; i < maestrosmatriculadosestra2.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + maestrosmatriculadosestra2.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + maestrosmatriculadosestra2.Rows[i]["institicion"].ToString() + "</td>";
                ca += "<td>" + maestrosmatriculadosestra2.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + maestrosmatriculadosestra2.Rows[i]["identificacion"].ToString() + "</td>";
                ca += "<td>" + maestrosmatriculadosestra2.Rows[i]["nomdocente"].ToString() + "</td>";
                ca += "</tr>";
            }
        }
        return ca;
    }

   [WebMethod(EnableSession = true)]
    public static string cargarDocentesBeneficiadosIndicador3()
    {
        string ca = "lleno@";
        Consultas c = new Consultas();
        DataTable dtm2 = c.cargarDocentesBeneficiadosIndicador3();

        if (dtm2 != null && dtm2.Rows.Count > 0)
        {
            for (int i = 0; i < dtm2.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + dtm2.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["institicion"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["identificacion"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["nomdocente"].ToString() + "</td>";
                ca += "</tr>";
            }
        }
        return ca;
    }

   [WebMethod(EnableSession = true)]
   public static string cargarDocentesInscritosComitesEspApro()
   {
       string ca = "lleno@";
       Consultas c = new Consultas();
       DataTable dtm2 = c.cargarDocentesInscritosComitesEspApro("", "", "", "");

       if (dtm2 != null && dtm2.Rows.Count > 0)
       {
           for (int i = 0; i < dtm2.Rows.Count; i++)
           {
               ca += "<tr>";
               ca += "<td>" + dtm2.Rows[i]["nombre"].ToString() + "</td>";
               ca += "<td>" + dtm2.Rows[i]["institucion"].ToString() + "</td>";
               ca += "<td>" + dtm2.Rows[i]["sede"].ToString() + "</td>";
               ca += "<td>" + dtm2.Rows[i]["identificacion"].ToString() + "</td>";
               ca += "<td>" + dtm2.Rows[i]["nombre"].ToString() + " " + dtm2.Rows[i]["apellido"].ToString() + "</td>";
               ca += "</tr>";
           }
       }
       return ca;
   }

    [WebMethod(EnableSession = true)]
   public static string maestrosredestematicasIndicador5()
   {
       string ca = "lleno@";
       Estrategias c = new Estrategias();
       DataTable dtm2 = c.maestrosredestematicasIndicador5("", "", "", "");

       if (dtm2 != null && dtm2.Rows.Count > 0)
       {
           for (int i = 0; i < dtm2.Rows.Count; i++)
           {
               ca += "<tr>";
               ca += "<td>" + dtm2.Rows[i]["municipio"].ToString() + "</td>";
               ca += "<td>" + dtm2.Rows[i]["institucion"].ToString() + "</td>";
               ca += "<td>" + dtm2.Rows[i]["sede"].ToString() + "</td>";
               ca += "<td>" + dtm2.Rows[i]["identificacion"].ToString() + "</td>";
               ca += "<td>" + dtm2.Rows[i]["nomdocente"].ToString() + "</td>";
               ca += "</tr>";
           }
       }
       return ca;
   }

    [WebMethod(EnableSession = true)]
    public static string sesionformacionMaestros(string momento, string sesion)
    {
        string ca = "lleno@";
        Estrategias est = new Estrategias();
        DataTable dtm2 = est.sesionformacionMaestros("", "", "", "", "2", momento, sesion);

        if (dtm2 != null && dtm2.Rows.Count > 0)
        {
            for (int i = 0; i < dtm2.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + dtm2.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["sede"].ToString() + "</td>";
                ca += "</tr>";
            }
        }
        return ca;
    }

    

    [WebMethod(EnableSession = true)]
    public static string asistentesSesionMaestros(string momento, string sesion, string jornada)
    {
        string ca = "lleno@";
        Estrategias est = new Estrategias();
        DataTable dtm2 = est.asistentesSesionMaestros("", "", "", "", "2", momento, sesion, jornada);

        if (dtm2 != null && dtm2.Rows.Count > 0)
        {
            for (int i = 0; i < dtm2.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + dtm2.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["identificacion"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["nomdocente"].ToString() + "</td>";
                ca += "</tr>";
            }
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string sesionesformacionevaluadas(string momento, string sesion, string tipo)
    {
        string ca = "lleno@";
        Estrategias est = new Estrategias();
        Consultas c = new Consultas();
        DataTable dtm2 = null;

        switch (tipo)
        {
            case "1":
                dtm2 = est.sesionesformacionevaluadas("", "", "", "", "2", momento, sesion);
                break;
            case "2":
                dtm2 = c.sesionesformacionevaluadas("", "", "", "", "2", momento, sesion, "Relatoria institucional");
                break;
            case "3":
                dtm2 = c.sesionesformacionevaluadas("", "", "", "", "2", "3", "2", "Formato de evaluación");
                break;
        }
        

        if (dtm2 != null && dtm2.Rows.Count > 0)
        {
            for (int i = 0; i < dtm2.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + dtm2.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["sede"].ToString() + "</td>";
                ca += "</tr>";
            }
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string totalgruposinvestigacionfinanciados()
    {
        string ca = "lleno@";
        Consultas c = new Consultas();
        DataTable dtm2 = null;

        dtm2 = c.totalgruposinvestigacionfinanciados("", "", "", "");

       

        if (dtm2 != null && dtm2.Rows.Count > 0)
        {
            for (int i = 0; i < dtm2.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + dtm2.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["nombregrupo"].ToString() + "</td>";
                ca += "</tr>";
            }
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarListadointroiepEstraDos()
    {
        string ca = "lleno@";
        Consultas c = new Consultas();
        DataTable dtm2 = null;

        dtm2 = c.cargarListadointroiepEstraDos("", "", "", "");



        if (dtm2 != null && dtm2.Rows.Count > 0)
        {
            for (int i = 0; i < dtm2.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + dtm2.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["sede"].ToString() + "</td>";
                ca += "</tr>";
            }
        }
        else
        {
            ca += "<tr>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "</tr>";
        }
        return ca;
    }


    [WebMethod(EnableSession = true)]
    public static string cargarApropiacionDocentesEncabezado()
    {
        string ca = "lleno@";
        Consultas c = new Consultas();
        DataTable dtm2 = null;

        dtm2 = c.cargarApropiacionDocentesEncabezado("", "", "", "");



        if (dtm2 != null && dtm2.Rows.Count > 0)
        {
            for (int i = 0; i < dtm2.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + dtm2.Rows[i]["tipoevento"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["fecha"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["horainicio"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["horafin"].ToString() + "</td>";
                ca += "</tr>";
            }
        }
        else
        {
            ca += "<tr>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "</tr>";
        }
        return ca;
    }
    
    [WebMethod(EnableSession = true)]
    public static string cargarApropiacionDocentesSeleccionados()
    {
        string ca = "lleno@";
        Consultas c = new Consultas();
        DataTable dtm2 = null;

        dtm2 = c.cargarApropiacionDocentesSeleccionados("", "", "", "");



        if (dtm2 != null && dtm2.Rows.Count > 0)
        {
            for (int i = 0; i < dtm2.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + dtm2.Rows[i]["mun"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["nombreins"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["nombresede"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["identificacion"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["nombredoc"].ToString() + " " + dtm2.Rows[i]["apellidodoc"].ToString() + "</td>";
                ca += "</tr>";
            }
        }
        else
        {
            ca += "<tr>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "</tr>";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarEntregaMaterialesCoordEstra2(string estado)
    {
        string ca = "lleno@";
        Consultas c = new Consultas();
        Funciones fun = new Funciones();
        DataTable dtm2 = null;

        dtm2 = c.cargarEntregaMaterialesCoordEstra2("", "", "", "", estado);



        if (dtm2 != null && dtm2.Rows.Count > 0)
        {
            for (int i = 0; i < dtm2.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + dtm2.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["coordinador"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["nombrequienrecibe"].ToString() + "</td>";
                ca += "<td>" + fun.convertFechaDia(dtm2.Rows[i]["fechaentregamaterial"].ToString()) + "</td>";
                ca += "</tr>";
            }
        }
        else
        {
            ca += "<tr>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "</tr>";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarInstrmentoS003()
    {
        string ca = "lleno@";
        Consultas c = new Consultas();
        Funciones fun = new Funciones();
        DataTable dtm2 = null;

        dtm2 = c.cargarInstrmentoS003("", "", "", "");



        if (dtm2 != null && dtm2.Rows.Count > 0)
        {
            for (int i = 0; i < dtm2.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + dtm2.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["nombregrupo"].ToString() + "</td>";
                ca += "</tr>";
            }
        }
        else
        {
            ca += "<tr>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "</tr>";
        }
        return ca;
    }

    [WebMethod(EnableSession = true)]
    public static string cargarListadocontenidodigitalEstraDosActualizado()
    {
        string ca = "lleno@";
        Consultas c = new Consultas();
        Funciones fun = new Funciones();
        DataTable dtm2 = null;

        dtm2 = c.cargarListadocontenidodigitalEstraDosActualizado();



        if (dtm2 != null && dtm2.Rows.Count > 0)
        {
            for (int i = 0; i < dtm2.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + dtm2.Rows[i]["anio"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["coordinador"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["tematica"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["fecha"].ToString() + "</td>";
                ca += "</tr>";
            }
        }
        else
        {
            ca += "<tr>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "</tr>";
        }
        return ca;
    }
    
    [WebMethod(EnableSession = true)]
    public static string cargarDocentesEstra1_Estra2Where()
    {
        string ca = "lleno@";
        Consultas c = new Consultas();
        Funciones fun = new Funciones();
        DataTable dtm2 = null;

        dtm2 = c.cargarDocentesEstra1_Estra2Where("", "", "", "");



        if (dtm2 != null && dtm2.Rows.Count > 0)
        {
            for (int i = 0; i < dtm2.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + dtm2.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["identificacion"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["docente"].ToString() + "</td>";
                ca += "</tr>";
            }
        }
        else
        {
            ca += "<tr>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "</tr>";
        }
        return ca;
    }
    
    [WebMethod(EnableSession = true)]
    public static string cargarDocentesRedestematicasWhere()
    {
        string ca = "lleno@";
        Consultas c = new Consultas();
        Funciones fun = new Funciones();
        DataTable dtm2 = null;

        dtm2 = c.cargarDocentesRedestematicasWhere("", "", "", "");



        if (dtm2 != null && dtm2.Rows.Count > 0)
        {
            for (int i = 0; i < dtm2.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + dtm2.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["identificacion"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["docente"].ToString() + "</td>";
                ca += "</tr>";
            }
        }
        else
        {
            ca += "<tr>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "</tr>";
        }
        return ca;
    }
    
    [WebMethod(EnableSession = true)]
    public static string cargarDocentesApropiacionSocialWhere()
    {
        string ca = "lleno@";
        Consultas c = new Consultas();
        Funciones fun = new Funciones();
        DataTable dtm2 = null;

        dtm2 = c.cargarDocentesApropiacionSocialWhere("", "", "", "");



        if (dtm2 != null && dtm2.Rows.Count > 0)
        {
            for (int i = 0; i < dtm2.Rows.Count; i++)
            {
                ca += "<tr>";
                ca += "<td>" + dtm2.Rows[i]["municipio"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["institucion"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["sede"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["identificacion"].ToString() + "</td>";
                ca += "<td>" + dtm2.Rows[i]["nombre"].ToString() + " " + dtm2.Rows[i]["apellido"].ToString() + "</td>";
                ca += "</tr>";
            }
        }
        else
        {
            ca += "<tr>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "<td></td>";
            ca += "</tr>";
        }
        return ca;
    }
}