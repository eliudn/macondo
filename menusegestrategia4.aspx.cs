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

public partial class menusegestrategia4 : System.Web.UI.Page
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


        //Estudiantes inscritos en las redes temáticas de la comunidad de práctica, saber, conocimiento y transformación de Ciclón
        DataTable niniosredestematicas = est.esturedtematicasxanio("20", "", "", "", "2018");
        double meta2 = 0;
        int count2 = 0;
        int total2 = 110880;
        double pesototalninio = 1.41;
        double pesoninio = 0;
        if (niniosredestematicas != null && niniosredestematicas.Rows.Count > 0)
        {
            count2 = niniosredestematicas.Rows.Count;
            meta2 = ((double)count2 / (double)total2) * 100;
            meta2 = Math.Round(meta2, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesoninio = ((double)count2 / (double)total2) * pesototalninio;
            pesoninio = Math.Round(pesoninio, 4);
            if (pesoninio > pesototalninio)
            {
                pesoninio = pesototalninio;
            }
            pesototal = pesototal + pesoninio;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Estudiantes inscritos en las redes temáticas de la comunidad de práctica, saber, conocimiento y transformación de Ciclón </td>";
        ca += "<td class='center'>" + count2 + " de " + total2 + "</td>";
        ca += "<td class='center'>" + meta2 + "%</td>";
        ca += "<td class='center'>" + pesoninio + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Redes temáticas conformadas
        DataTable redes = c.cargarTablaRedTematicaTodo();
        double metaredes = 0;
        int countredes = 0;
        int totalredes = 3227;
        double pesototalredes = 1.41;
        double pesoredes = 0;
        if (redes != null && redes.Rows.Count > 0)
        {
            countredes = redes.Rows.Count;
            metaredes = ((double)countredes / (double)totalredes) * 100;
            metaredes = Math.Round(metaredes, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesoredes = ((double)countredes / (double)totalredes) * pesototalredes;
            pesoredes = Math.Round(pesoredes, 4);
            if (pesoredes > pesototalredes)
            {
                pesoninio = pesototalredes;
            }
            pesototal = pesototal + pesoredes;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Redes temáticas conformadas </td>";
        ca += "<td class='center'>" + countredes + " de " + totalredes + "</td>";
        ca += "<td class='center'>" + metaredes + "%</td>";
        ca += "<td class='center'>" + pesoredes + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Sesiones de formación No. 1 presencial realizadas 
        DataTable sesion1 = est.sesionesformacion2016("", "", "", "", "4", "1");//Modificar la consulta, tiene que ser por memorias y no por sede
        double metas1 = 0;
        int counts1 = 0;
        int totals1 = 3227;
        double pesototals1 = 1.41;
        double pesos1 = 0;
        if (sesion1 != null && sesion1.Rows.Count > 0)
        {
            counts1 = sesion1.Rows.Count;
            metas1 = ((double)counts1 / (double)totals1) * 100;
            metas1 = Math.Round(metas1, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesos1 = ((double)counts1 / (double)totals1) * pesototals1;
            pesos1 = Math.Round(pesos1, 4);
            if (pesos1 > pesototals1)
            {
                pesos1 = pesototals1;
            }
            pesototal = pesototal + pesos1;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Sesiones de formación No. 1 presencial realizadas  </td>";
        ca += "<td class='center'>" + counts1 + " de " + totals1 + "</td>";
        ca += "<td class='center'>" + metas1 + "%</td>";
        ca += "<td class='center'>" + pesos1 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Estudiantes inscritos que participan en la primera sesión  de formación presencial/ Nivel 1 juego Gózate la ciencia.
        DataTable estudiantesasis = est.est_estra2instrumento_s004_redt_2016_estudiantes("", "", "", "", "1");
        double metaes1 = 0;
        int countes1 = 0;
        int totales1 = 110880;
        double pesototales1 = 1.41;
        double pesoes1 = 0;
        if (estudiantesasis != null && estudiantesasis.Rows.Count > 0)
        {
            countes1 = estudiantesasis.Rows.Count;
            metaes1 = ((double)countes1 / (double)totales1) * 100;
            metaes1 = Math.Round(metaes1, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesoes1 = ((double)countes1 / (double)totales1) * pesototales1;
            pesoes1 = Math.Round(pesoes1, 4);
            if (pesoes1 > pesototales1)
            {
                pesoes1 = pesototales1;
            }
            pesototal = pesototal + pesoes1;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Estudiantes inscritos que participan en la primera sesión  de formación presencial/ Nivel 1 juego Gózate la ciencia.  </td>";
        ca += "<td class='center'>" + countes1 + " de " + totales1 + "</td>";
        ca += "<td class='center'>" + metaes1 + "%</td>";
        ca += "<td class='center'>" + pesoes1 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesiones de formación No. 1 virtual realizadas
        DataTable sesionvirtual1 = c.cargarListadoMemoriasS004_EspVirtualesTodo("", "", "", "", "4","1","1");
        double metasv1 = 0;
        int countsv1 = 0;
        int totalsv1 = 3227;
        double pesototalsv1 = 1.41;
        double pesosv1 = 0;
        if (sesionvirtual1 != null && sesionvirtual1.Rows.Count > 0)
        {
            countsv1 = sesionvirtual1.Rows.Count;
            metasv1 = ((double)countsv1 / (double)totalsv1) * 100;
            metasv1 = Math.Round(metasv1, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesosv1 = ((double)countsv1 / (double)totalsv1) * pesototalsv1;
            pesosv1 = Math.Round(pesosv1, 4);
            if (pesosv1 > pesototalsv1)
            {
                pesosv1 = pesototalsv1;
            }
            pesototal = pesototal + pesosv1;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Sesiones de formación No. 1 virtual realizadas  </td>";
        ca += "<td class='center'>" + countsv1 + " de " + totalsv1 + "</td>";
        ca += "<td class='center'>" + metasv1 + "%</td>";
        ca += "<td class='center'>" + pesosv1 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Estudiantes inscritos que participan en la primera sesión  de formación virtual/ Nivel 1 juego Gózate la ciencia.
        DataTable sesionasistvirtual1 = est.estuinscritossesion_vt("", "", "", "", "4", "1");
        double metasva1 = 0;
        int countsva1 = 0;
        int totalsva1 = 3227;
        double pesototalsva1 = 1.41;
        double pesosva1 = 0;
        if (sesionasistvirtual1 != null && sesionasistvirtual1.Rows.Count > 0)
        {
            countsva1 = sesionasistvirtual1.Rows.Count;
            metasva1 = ((double)countsva1 / (double)totalsv1) * 100;
            metasva1 = Math.Round(metasva1, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesosva1 = ((double)countsva1 / (double)totalsva1) * pesototalsva1;
            pesosva1 = Math.Round(pesosva1, 4);
            if (pesosva1 > pesototalsva1)
            {
                pesosva1 = pesototalsva1;
            }
            pesototal = pesototal + pesosva1;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Estudiantes inscritos que participan en la primera sesión  de formación virtual/ Nivel 1 juego Gózate la ciencia.  </td>";
        ca += "<td class='center'>" + countsva1 + " de " + totalsva1 + "</td>";
        ca += "<td class='center'>" + metasva1 + "%</td>";
        ca += "<td class='center'>" + pesosva1 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesiones de formación presencial  No. 2 realizadas 
        DataTable sesion2 = c.cargarListadoMemoriasS004Todo("", "", "", "", "4", "1", "2");
        double metas2 = 0;
        int counts2 = 0;
        int totals2 = 3227;
        double pesototals2 = 1.41;
        double pesos2 = 0;
        if (sesion2 != null && sesion2.Rows.Count > 0)
        {
            counts2 = sesion2.Rows.Count;
            metas2 = ((double)counts2 / (double)totals2) * 100;
            metas2 = Math.Round(metas2, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesos2 = ((double)counts2 / (double)totals2) * pesototals2;
            pesos2 = Math.Round(pesos2, 4);
            if (pesos2 > pesototals2)
            {
                pesos2 = pesototals2;
            }
            pesototal = pesototal + pesos2;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Sesiones de formación No. 2 presencial realizadas  </td>";
        ca += "<td class='center'>" + counts2 + " de " + totals2 + "</td>";
        ca += "<td class='center'>" + metas2 + "%</td>";
        ca += "<td class='center'>" + pesos2 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Estudiantes inscritos que participan en la segunda sesión  de formación presencial/ Nivel 2 juego Gózate la ciencia.
        DataTable estudiantesasis2 = c.cargarAsistentesMemoriasS004_Todo("4", "1", "2");
        double metaes2 = 0;
        int countes2 = 0;
        int totales2 = 110880;
        double pesototales2 = 1.41;
        double pesoes2 = 0;
        if (estudiantesasis2 != null && estudiantesasis2.Rows.Count > 0)
        {
            countes2 = estudiantesasis2.Rows.Count;
            metaes2 = ((double)countes2 / (double)totales2) * 100;
            metaes2 = Math.Round(metaes2, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesoes2 = ((double)countes2 / (double)totales2) * pesototales2;
            pesoes2 = Math.Round(pesoes2, 4);
            if (pesoes2 > pesototales2)
            {
                pesoes2 = pesototales2;
            }
            pesototal = pesototal + pesoes2;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Estudiantes inscritos que participan en la segunda sesión  de formación presencial/ Nivel 2 juego Gózate la ciencia.  </td>";
        ca += "<td class='center'>" + countes2 + " de " + totales2 + "</td>";
        ca += "<td class='center'>" + metaes2 + "%</td>";
        ca += "<td class='center'>" + pesoes2 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesiones de formación No. 2 virtual realizadas
        DataTable sesionvirtual2 = c.cargarListadoMemoriasS004_EspVirtualesTodo("", "", "", "", "4", "1", "2");
        double metasv2 = 0;
        int countsv2 = 0;
        int totalsv2 = 3227;
        double pesototalsv2 = 1.41;
        double pesosv2 = 0;
        if (sesionvirtual2 != null && sesionvirtual2.Rows.Count > 0)
        {
            countsv2 = sesionvirtual2.Rows.Count;
            metasv2 = ((double)countsv2 / (double)totalsv2) * 100;
            metasv2 = Math.Round(metasv2, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesosv2 = ((double)countsv2 / (double)totalsv2) * pesototalsv2;
            pesosv2 = Math.Round(pesosv2, 4);
            if (pesosv2 > pesototalsv2)
            {
                pesosv2 = pesototalsv2;
            }
            pesototal = pesototal + pesosv2;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Sesiones de formación No. 2 virtual realizadas  </td>";
        ca += "<td class='center'>" + countsv2 + " de " + totalsv2 + "</td>";
        ca += "<td class='center'>" + metasv2 + "%</td>";
        ca += "<td class='center'>" + pesosv2 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Estudiantes inscritos que participan en la primera sesión  de formación virtual/ Nivel 2 juego Gózate la ciencia.
        DataTable sesionasistvirtual2 = c.cargarAsistentesMemoriasS004_EspVirtualesTodo("4", "1", "2");
        double metasva2 = 0;
        int countsva2 = 0;
        int totalsva2 = 3227;
        double pesototalsva2 = 1.41;
        double pesosva2 = 0;
        if (sesionasistvirtual2 != null && sesionasistvirtual2.Rows.Count > 0)
        {
            countsva2 = sesionasistvirtual2.Rows.Count;
            metasva2 = ((double)countsva2 / (double)totalsv2) * 100;
            metasva2 = Math.Round(metasva2, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesosva2 = ((double)countsva2 / (double)totalsva2) * pesototalsva2;
            pesosva2 = Math.Round(pesosva2, 4);
            if (pesosva2 > pesototalsva2)
            {
                pesosva2 = pesototalsva2;
            }
            pesototal = pesototal + pesosva2;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Estudiantes inscritos que participan en la primera sesión  de formación virtual/ Nivel 2 juego Gózate la ciencia.  </td>";
        ca += "<td class='center'>" + countsva2 + " de " + totalsva2 + "</td>";
        ca += "<td class='center'>" + metasva2 + "%</td>";
        ca += "<td class='center'>" + pesosva2 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesiones de formación presencial  No. 3 realizadas 
        DataTable sesion3 = c.cargarListadoMemoriasS004Todo("", "", "", "", "4", "1", "3");
        double metas3 = 0;
        int counts3 = 0;
        int totals3 = 3227;
        double pesototals3 = 1.41;
        double pesos3 = 0;
        if (sesion3 != null && sesion3.Rows.Count > 0)
        {
            counts3 = sesion3.Rows.Count;
            metas3 = ((double)counts3 / (double)totals3) * 100;
            metas3 = Math.Round(metas3, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesos3 = ((double)counts3 / (double)totals3) * pesototals3;
            pesos3 = Math.Round(pesos3, 4);
            if (pesos3 > pesototals3)
            {
                pesos3 = pesototals3;
            }
            pesototal = pesototal + pesos3;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Sesiones de formación No. 3 presencial realizadas  </td>";
        ca += "<td class='center'>" + counts3 + " de " + totals3 + "</td>";
        ca += "<td class='center'>" + metas3 + "%</td>";
        ca += "<td class='center'>" + pesos3 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Estudiantes inscritos que participan en la segunda sesión  de formación presencial/ Nivel 3 juego Gózate la ciencia.
        DataTable estudiantesasis3 = c.cargarAsistentesMemoriasS004_Todo("4", "1", "3");
        double metaes3 = 0;
        int countes3 = 0;
        int totales3 = 110880;
        double pesototales3 = 1.41;
        double pesoes3 = 0;
        if (estudiantesasis3 != null && estudiantesasis3.Rows.Count > 0)
        {
            countes3 = estudiantesasis3.Rows.Count;
            metaes3 = ((double)countes3 / (double)totales3) * 100;
            metaes3 = Math.Round(metaes3, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesoes3 = ((double)countes3 / (double)totales3) * pesototales3;
            pesoes3 = Math.Round(pesoes3, 4);
            if (pesoes3 > pesototales3)
            {
                pesoes3 = pesototales3;
            }
            pesototal = pesototal + pesoes3;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Estudiantes inscritos que participan en la segunda sesión  de formación presencial/ Nivel 3 juego Gózate la ciencia.  </td>";
        ca += "<td class='center'>" + countes3 + " de " + totales3 + "</td>";
        ca += "<td class='center'>" + metaes3 + "%</td>";
        ca += "<td class='center'>" + pesoes3 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesiones de formación No. 3 virtual realizadas
        DataTable sesionvirtual3 = c.cargarListadoMemoriasS004_EspVirtualesTodo("", "", "", "", "4", "1", "3");
        double metasv3 = 0;
        int countsv3 = 0;
        int totalsv3 = 3227;
        double pesototalsv3 = 1.41;
        double pesosv3 = 0;
        if (sesionvirtual3 != null && sesionvirtual3.Rows.Count > 0)
        {
            countsv3 = sesionvirtual3.Rows.Count;
            metasv3 = ((double)countsv3 / (double)totalsv3) * 100;
            metasv3 = Math.Round(metasv3, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesosv3 = ((double)countsv3 / (double)totalsv3) * pesototalsv3;
            pesosv3 = Math.Round(pesosv3, 4);
            if (pesosv3 > pesototalsv3)
            {
                pesosv3 = pesototalsv3;
            }
            pesototal = pesototal + pesosv3;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Sesiones de formación No. 3 virtual realizadas  </td>";
        ca += "<td class='center'>" + countsv3 + " de " + totalsv3 + "</td>";
        ca += "<td class='center'>" + metasv3 + "%</td>";
        ca += "<td class='center'>" + pesosv3 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Estudiantes inscritos que participan en la primera sesión  de formación virtual/ Nivel 3 juego Gózate la ciencia.
        DataTable sesionasistvirtual3 = c.cargarAsistentesMemoriasS004_EspVirtualesTodo("4", "1", "3");
        double metasva3 = 0;
        int countsva3 = 0;
        int totalsva3 = 3227;
        double pesototalsva3 = 1.41;
        double pesosva3 = 0;
        if (sesionasistvirtual3 != null && sesionasistvirtual3.Rows.Count > 0)
        {
            countsva3 = sesionasistvirtual3.Rows.Count;
            metasva3 = ((double)countsva3 / (double)totalsv3) * 100;
            metasva3 = Math.Round(metasva3, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesosva3 = ((double)countsva3 / (double)totalsva3) * pesototalsva3;
            pesosva3 = Math.Round(pesosva3, 4);
            if (pesosva3 > pesototalsva3)
            {
                pesosva3 = pesototalsva3;
            }
            pesototal = pesototal + pesosva3;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Estudiantes inscritos que participan en la primera sesión  de formación virtual/ Nivel 3 juego Gózate la ciencia.  </td>";
        ca += "<td class='center'>" + countsva3 + " de " + totalsva3 + "</td>";
        ca += "<td class='center'>" + metasva3 + "%</td>";
        ca += "<td class='center'>" + pesosva3 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Sesiones de formación presencial  No. 4 realizadas 
        DataTable sesion4 = c.cargarListadoMemoriasS004Todo("", "", "", "", "4", "1", "4");
        double metas4 = 0;
        int counts4 = 0;
        int totals4 = 3227;
        double pesototals4 = 1.41;
        double pesos4 = 0;
        if (sesion4 != null && sesion4.Rows.Count > 0)
        {
            counts4 = sesion4.Rows.Count;
            metas4 = ((double)counts4 / (double)totals4) * 100;
            metas4 = Math.Round(metas4, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesos4 = ((double)counts4 / (double)totals4) * pesototals4;
            pesos4 = Math.Round(pesos4, 4);
            if (pesos4 > pesototals4)
            {
                pesos4 = pesototals4;
            }
            pesototal = pesototal + pesos4;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Sesiones de formación No. 4 presencial realizadas  </td>";
        ca += "<td class='center'>" + counts4 + " de " + totals4 + "</td>";
        ca += "<td class='center'>" + metas4 + "%</td>";
        ca += "<td class='center'>" + pesos4 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Estudiantes inscritos que participan en la segunda sesión  de formación presencial/ Nivel 4 juego Gózate la ciencia.
        DataTable estudiantesasis4 = c.cargarAsistentesMemoriasS004_Todo("4", "1", "4");
        double metaes4 = 0;
        int countes4 = 0;
        int totales4 = 110880;
        double pesototales4 = 1.41;
        double pesoes4 = 0;
        if (estudiantesasis4 != null && estudiantesasis4.Rows.Count > 0)
        {
            countes4 = estudiantesasis4.Rows.Count;
            metaes4 = ((double)countes4 / (double)totales4) * 100;
            metaes4 = Math.Round(metaes4, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesoes4 = ((double)countes4 / (double)totales4) * pesototales4;
            pesoes4 = Math.Round(pesoes4, 4);
            if (pesoes4 > pesototales4)
            {
                pesoes4 = pesototales4;
            }
            pesototal = pesototal + pesoes4;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Estudiantes inscritos que participan en la segunda sesión  de formación presencial/ Nivel 4 juego Gózate la ciencia.  </td>";
        ca += "<td class='center'>" + countes4 + " de " + totales4 + "</td>";
        ca += "<td class='center'>" + metaes4 + "%</td>";
        ca += "<td class='center'>" + pesoes4 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesiones de formación No. 4 virtual realizadas
        DataTable sesionvirtual4 = c.cargarListadoMemoriasS004_EspVirtualesTodo("", "", "", "", "4", "1", "4");
        double metasv4 = 0;
        int countsv4 = 0;
        int totalsv4 = 3227;
        double pesototalsv4 = 1.41;
        double pesosv4 = 0;
        if (sesionvirtual4 != null && sesionvirtual4.Rows.Count > 0)
        {
            countsv4 = sesionvirtual4.Rows.Count;
            metasv4 = ((double)countsv4 / (double)totalsv4) * 100;
            metasv4 = Math.Round(metasv4, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesosv4 = ((double)countsv4 / (double)totalsv4) * pesototalsv4;
            pesosv4 = Math.Round(pesosv4, 4);
            if (pesosv4 > pesototalsv4)
            {
                pesosv4 = pesototalsv4;
            }
            pesototal = pesototal + pesosv4;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Sesiones de formación No. 4 virtual realizadas  </td>";
        ca += "<td class='center'>" + countsv4 + " de " + totalsv4 + "</td>";
        ca += "<td class='center'>" + metasv4 + "%</td>";
        ca += "<td class='center'>" + pesosv4 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Estudiantes inscritos que participan en la primera sesión  de formación virtual/ Nivel 4 juego Gózate la ciencia.
        DataTable sesionasistvirtual4 = c.cargarAsistentesMemoriasS004_EspVirtualesTodo("4", "1", "4");
        double metasva4 = 0;
        int countsva4 = 0;
        int totalsva4 = 3227;
        double pesototalsva4 = 1.41;
        double pesosva4 = 0;
        if (sesionasistvirtual4 != null && sesionasistvirtual4.Rows.Count > 0)
        {
            countsva4 = sesionasistvirtual4.Rows.Count;
            metasva4 = ((double)countsva4 / (double)totalsv4) * 100;
            metasva4 = Math.Round(metasva4, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesosva4 = ((double)countsva4 / (double)totalsva4) * pesototalsva4;
            pesosva4 = Math.Round(pesosva4, 4);
            if (pesosva4 > pesototalsva4)
            {
                pesosva4 = pesototalsva4;
            }
            pesototal = pesototal + pesosva4;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Estudiantes inscritos que participan en la primera sesión  de formación virtual/ Nivel 4 juego Gózate la ciencia.  </td>";
        ca += "<td class='center'>" + countsva4 + " de " + totalsva4 + "</td>";
        ca += "<td class='center'>" + metasva4 + "%</td>";
        ca += "<td class='center'>" + pesosva4 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Sesiones de formación presencial  No. 5 realizadas 
        DataTable sesion5 = c.cargarListadoMemoriasS004Todo("", "", "", "", "4", "1", "5");
        double metas5 = 0;
        int counts5 = 0;
        int totals5 = 3227;
        double pesototals5 = 1.41;
        double pesos5 = 0;
        if (sesion5 != null && sesion5.Rows.Count > 0)
        {
            counts5 = sesion5.Rows.Count;
            metas5 = ((double)counts5 / (double)totals5) * 100;
            metas5 = Math.Round(metas5, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesos5 = ((double)counts5 / (double)totals5) * pesototals5;
            pesos5 = Math.Round(pesos5, 4);
            if (pesos5 > pesototals5)
            {
                pesos2 = pesototals5;
            }
            pesototal = pesototal + pesos5;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Sesiones de formación No. 5 presencial realizadas  </td>";
        ca += "<td class='center'>" + counts5 + " de " + totals5 + "</td>";
        ca += "<td class='center'>" + metas5 + "%</td>";
        ca += "<td class='center'>" + pesos5 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Estudiantes inscritos que participan en la segunda sesión  de formación presencial/ Nivel 5 juego Gózate la ciencia.
        DataTable estudiantesasis5 = c.cargarAsistentesMemoriasS004_Todo("4", "1", "5");
        double metaes5 = 0;
        int countes5 = 0;
        int totales5 = 110880;
        double pesototales5 = 1.41;
        double pesoes5 = 0;
        if (estudiantesasis2 != null && estudiantesasis2.Rows.Count > 0)
        {
            countes5 = estudiantesasis5.Rows.Count;
            metaes5 = ((double)countes5 / (double)totales5) * 100;
            metaes5 = Math.Round(metaes5, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesoes5 = ((double)countes5 / (double)totales5) * pesototales5;
            pesoes5 = Math.Round(pesoes5, 4);
            if (pesoes5 > pesototales5)
            {
                pesoes5 = pesototales5;
            }
            pesototal = pesototal + pesoes5;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Estudiantes inscritos que participan en la segunda sesión  de formación presencial/ Nivel 5 juego Gózate la ciencia.  </td>";
        ca += "<td class='center'>" + countes5 + " de " + totales5 + "</td>";
        ca += "<td class='center'>" + metaes5 + "%</td>";
        ca += "<td class='center'>" + pesoes5 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesiones de formación No. 5 virtual realizadas
        DataTable sesionvirtual5 = c.cargarListadoMemoriasS004_EspVirtualesTodo("", "", "", "", "4", "1", "5");
        double metasv5 = 0;
        int countsv5 = 0;
        int totalsv5 = 3227;
        double pesototalsv5 = 1.41;
        double pesosv5 = 0;
        if (sesionvirtual5 != null && sesionvirtual5.Rows.Count > 0)
        {
            countsv5 = sesionvirtual5.Rows.Count;
            metasv5 = ((double)countsv5 / (double)totalsv5) * 100;
            metasv5 = Math.Round(metasv5, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesosv2 = ((double)countsv2 / (double)totalsv2) * pesototalsv2;
            pesosv2 = Math.Round(pesosv2, 4);
            if (pesosv5 > pesototalsv5)
            {
                pesosv5 = pesototalsv5;
            }
            pesototal = pesototal + pesosv5;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Sesiones de formación No. 5 virtual realizadas  </td>";
        ca += "<td class='center'>" + countsv5 + " de " + totalsv5 + "</td>";
        ca += "<td class='center'>" + metasv5 + "%</td>";
        ca += "<td class='center'>" + pesosv5 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Estudiantes inscritos que participan en la primera sesión  de formación virtual/ Nivel 5 juego Gózate la ciencia.
        DataTable sesionasistvirtual5 = c.cargarAsistentesMemoriasS004_EspVirtualesTodo("4", "1", "5");
        double metasva5 = 0;
        int countsva5 = 0;
        int totalsva5 = 3227;
        double pesototalsva5 = 1.41;
        double pesosva5 = 0;
        if (sesionasistvirtual5 != null && sesionasistvirtual5.Rows.Count > 0)
        {
            countsva5 = sesionasistvirtual5.Rows.Count;
            metasva5 = ((double)countsva5 / (double)totalsva5) * 100;
            metasva5 = Math.Round(metasva5, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesosva5 = ((double)countsva5 / (double)totalsva5) * pesototalsva5;
            pesosva5 = Math.Round(pesosva5, 4);
            if (pesosva5 > pesototalsva5)
            {
                pesosva2 = pesototalsva5;
            }
            pesototal = pesototal + pesosva5;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Estudiantes inscritos que participan en la primera sesión  de formación virtual/ Nivel 5 juego Gózate la ciencia.  </td>";
        ca += "<td class='center'>" + countsva5 + " de " + totalsva5 + "</td>";
        ca += "<td class='center'>" + metasva5 + "%</td>";
        ca += "<td class='center'>" + pesosva5 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Sesiones de formación presencial  No. 6 realizadas 
        DataTable sesion6 = c.cargarListadoMemoriasS004Todo("", "", "", "", "4", "1", "6");
        double metas6 = 0;
        int counts6 = 0;
        int totals6 = 3227;
        double pesototals6 = 1.41;
        double pesos6 = 0;
        if (sesion6 != null && sesion6.Rows.Count > 0)
        {
            counts6 = sesion6.Rows.Count;
            metas6 = ((double)counts6 / (double)totals6) * 100;
            metas6 = Math.Round(metas6, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesos6 = ((double)counts6 / (double)totals6) * pesototals6;
            pesos6 = Math.Round(pesos6, 4);
            if (pesos6 > pesototals6)
            {
                pesos2 = pesototals6;
            }
            pesototal = pesototal + pesos6;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Sesiones de formación No. 6 presencial realizadas  </td>";
        ca += "<td class='center'>" + counts6 + " de " + totals6 + "</td>";
        ca += "<td class='center'>" + metas6 + "%</td>";
        ca += "<td class='center'>" + pesos6 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Estudiantes inscritos que participan en la segunda sesión  de formación presencial/ Nivel 6 juego Gózate la ciencia.
        DataTable estudiantesasis6 = c.cargarAsistentesMemoriasS004_Todo("4", "1", "6");
        double metaes6 = 0;
        int countes6 = 0;
        int totales6 = 110880;
        double pesototales6 = 1.41;
        double pesoes6 = 0;
        if (estudiantesasis6 != null && estudiantesasis6.Rows.Count > 0)
        {
            countes6 = estudiantesasis6.Rows.Count;
            metaes6 = ((double)countes6 / (double)totales6) * 100;
            metaes6 = Math.Round(metaes6, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesoes6 = ((double)countes6 / (double)totales6) * pesototales6;
            pesoes6 = Math.Round(pesoes6, 4);
            if (pesoes6 > pesototales6)
            {
                pesoes6 = pesototales6;
            }
            pesototal = pesototal + pesoes6;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Estudiantes inscritos que participan en la segunda sesión  de formación presencial/ Nivel 6 juego Gózate la ciencia.  </td>";
        ca += "<td class='center'>" + countes6 + " de " + totales6 + "</td>";
        ca += "<td class='center'>" + metaes6 + "%</td>";
        ca += "<td class='center'>" + pesoes6 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesiones de formación No. 6 virtual realizadas
        DataTable sesionvirtual6 = c.cargarListadoMemoriasS004_EspVirtualesTodo("", "", "", "", "4", "1", "6");
        double metasv6 = 0;
        int countsv6 = 0;
        int totalsv6 = 3227;
        double pesototalsv6 = 1.41;
        double pesosv6 = 0;
        if (sesionvirtual6 != null && sesionvirtual6.Rows.Count > 0)
        {
            countsv6 = sesionvirtual6.Rows.Count;
            metasv6 = ((double)countsv6 / (double)totalsv6) * 100;
            metasv6 = Math.Round(metasv6, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesosv6 = ((double)countsv6 / (double)totalsv6) * pesototalsv6;
            pesosv6 = Math.Round(pesosv6, 4);
            if (pesosv6 > pesototalsv6)
            {
                pesosv6 = pesototalsv6;
            }
            pesototal = pesototal + pesosv6;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Sesiones de formación No. 6 virtual realizadas  </td>";
        ca += "<td class='center'>" + countsv6 + " de " + totalsv6 + "</td>";
        ca += "<td class='center'>" + metasv6 + "%</td>";
        ca += "<td class='center'>" + pesosv6 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Estudiantes inscritos que participan en la primera sesión  de formación virtual/ Nivel 6 juego Gózate la ciencia.
        DataTable sesionasistvirtual6 = c.cargarAsistentesMemoriasS004_EspVirtualesTodo("4", "1", "6");
        double metasva6 = 0;
        int countsva6 = 0;
        int totalsva6 = 3227;
        double pesototalsva6 = 1.41;
        double pesosva6 = 0;
        if (sesionasistvirtual6 != null && sesionasistvirtual6.Rows.Count > 0)
        {
            countsva6 = sesionasistvirtual6.Rows.Count;
            metasva6 = ((double)countsva6 / (double)totalsva6) * 100;
            metasva6 = Math.Round(metasva6, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesosva6 = ((double)countsva6 / (double)totalsva6) * pesototalsva6;
            pesosva6 = Math.Round(pesosva6, 4);
            if (pesosva6 > pesototalsva6)
            {
                pesosva6 = pesototalsva6;
            }
            pesototal = pesototal + pesosva6;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Estudiantes inscritos que participan en la primera sesión  de formación virtual/ Nivel 6 juego Gózate la ciencia.  </td>";
        ca += "<td class='center'>" + countsva6 + " de " + totalsva6 + "</td>";
        ca += "<td class='center'>" + metasva6 + "%</td>";
        ca += "<td class='center'>" + pesosva6 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesiones de formación presencial  No. 7 realizadas 
        DataTable sesion7 = c.cargarListadoMemoriasS004Todo("", "", "", "", "4", "1", "7");
        double metas7 = 0;
        int counts7 = 0;
        int totals7 = 3227;
        double pesototals7 = 1.41;
        double pesos7 = 0;
        if (sesion7 != null && sesion7.Rows.Count > 0)
        {
            counts7 = sesion7.Rows.Count;
            metas7 = ((double)counts7 / (double)totals7) * 100;
            metas7 = Math.Round(metas7, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesos7 = ((double)counts7 / (double)totals7) * pesototals7;
            pesos7 = Math.Round(pesos7, 4);
            if (pesos7 > pesototals7)
            {
                pesos7 = pesototals7;
            }
            pesototal = pesototal + pesos7;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Sesiones de formación No. 7 presencial realizadas  </td>";
        ca += "<td class='center'>" + counts7 + " de " + totals7 + "</td>";
        ca += "<td class='center'>" + metas7 + "%</td>";
        ca += "<td class='center'>" + pesos7 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Estudiantes inscritos que participan en la segunda sesión  de formación presencial/ Nivel 7 juego Gózate la ciencia.
        DataTable estudiantesasis7 = c.cargarAsistentesMemoriasS004_Todo("4", "1", "7");
        double metaes7 = 0;
        int countes7 = 0;
        int totales7 = 110880;
        double pesototales7 = 1.41;
        double pesoes7 = 0;
        if (estudiantesasis7 != null && estudiantesasis7.Rows.Count > 0)
        {
            countes7 = estudiantesasis7.Rows.Count;
            metaes7 = ((double)countes7 / (double)totales7) * 100;
            metaes7 = Math.Round(metaes7, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesoes7 = ((double)countes7 / (double)totales7) * pesototales7;
            pesoes7 = Math.Round(pesoes7, 4);
            if (pesoes7 > pesototales7)
            {
                pesoes7 = pesototales7;
            }
            pesototal = pesototal + pesoes7;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Estudiantes inscritos que participan en la segunda sesión  de formación presencial/ Nivel 7 juego Gózate la ciencia.  </td>";
        ca += "<td class='center'>" + countes7 + " de " + totales7 + "</td>";
        ca += "<td class='center'>" + metaes7 + "%</td>";
        ca += "<td class='center'>" + pesoes7 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesiones de formación No. 7 virtual realizadas
        DataTable sesionvirtual7 = c.cargarListadoMemoriasS004_EspVirtualesTodo("", "", "", "", "4", "1", "7");
        double metasv7 = 0;
        int countsv7 = 0;
        int totalsv7 = 3227;
        double pesototalsv7 = 1.41;
        double pesosv7 = 0;
        if (sesionvirtual7 != null && sesionvirtual7.Rows.Count > 0)
        {
            countsv7 = sesionvirtual7.Rows.Count;
            metasv7 = ((double)countsv7 / (double)totalsv7) * 100;
            metasv7 = Math.Round(metasv7, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesosv7 = ((double)countsv7 / (double)totalsv7) * pesototalsv7;
            pesosv7 = Math.Round(pesosv7, 4);
            if (pesosv7 > pesototalsv7)
            {
                pesosv7 = pesototalsv7;
            }
            pesototal = pesototal + pesosv7;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Sesiones de formación No. 7 virtual realizadas  </td>";
        ca += "<td class='center'>" + countsv7+ " de " + totalsv7 + "</td>";
        ca += "<td class='center'>" + metasv7 + "%</td>";
        ca += "<td class='center'>" + pesosv7 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Estudiantes inscritos que participan en la primera sesión  de formación virtual/ Nivel 7 juego Gózate la ciencia.
        DataTable sesionasistvirtual7 = c.cargarAsistentesMemoriasS004_EspVirtualesTodo("4", "1", "7");
        double metasva7 = 0;
        int countsva7 = 0;
        int totalsva7 = 3227;
        double pesototalsva7 = 1.41;
        double pesosva7 = 0;
        if (sesionasistvirtual7 != null && sesionasistvirtual7.Rows.Count > 0)
        {
            countsva7 = sesionasistvirtual7.Rows.Count;
            metasva7 = ((double)countsva7 / (double)totalsva7) * 100;
            metasva7 = Math.Round(metasva7, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesosva7 = ((double)countsva7 / (double)totalsva7) * pesototalsva7;
            pesosva7= Math.Round(pesosva7, 4);
            if (pesosva7 > pesototalsva7)
            {
                pesosva7 = pesototalsva7;
            }
            pesototal = pesototal + pesosva7;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Estudiantes inscritos que participan en la primera sesión  de formación virtual/ Nivel 7 juego Gózate la ciencia.  </td>";
        ca += "<td class='center'>" + countsva7 + " de " + totalsva7 + "</td>";
        ca += "<td class='center'>" + metasva7 + "%</td>";
        ca += "<td class='center'>" + pesosva7 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesiones de formación presencial  No. 8 realizadas 
        DataTable sesion8 = c.cargarListadoMemoriasS004Todo("", "", "", "", "4", "1", "8");
        double metas8 = 0;
        int counts8 = 0;
        int totals8 = 3227;
        double pesototals8 = 1.41;
        double pesos8 = 0;
        if (sesion8 != null && sesion8.Rows.Count > 0)
        {
            counts8 = sesion8.Rows.Count;
            metas8 = ((double)counts8 / (double)totals8) * 100;
            metas8 = Math.Round(metas8, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesos8 = ((double)counts8 / (double)totals8) * pesototals8;
            pesos8 = Math.Round(pesos8, 4);
            if (pesos8 > pesototals8)
            {
                pesos8 = pesototals8;
            }
            pesototal = pesototal + pesos8;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Sesiones de formación No. 8 presencial realizadas  </td>";
        ca += "<td class='center'>" + counts8 + " de " + totals8 + "</td>";
        ca += "<td class='center'>" + metas8 + "%</td>";
        ca += "<td class='center'>" + pesos8 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Estudiantes inscritos que participan en la segunda sesión  de formación presencial/ Nivel 8 juego Gózate la ciencia.
        DataTable estudiantesasis8 = c.cargarAsistentesMemoriasS004_Todo("4", "1", "8");
        double metaes8 = 0;
        int countes8 = 0;
        int totales8 = 110880;
        double pesototales8 = 1.41;
        double pesoes8 = 0;
        if (estudiantesasis8 != null && estudiantesasis8.Rows.Count > 0)
        {
            countes8 = estudiantesasis8.Rows.Count;
            metaes8 = ((double)countes8 / (double)totales8) * 100;
            metaes8 = Math.Round(metaes8, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesoes8 = ((double)countes8 / (double)totales8) * pesototales8;
            pesoes8 = Math.Round(pesoes8, 4);
            if (pesoes8 > pesototales8)
            {
                pesoes8 = pesototales8;
            }
            pesototal = pesototal + pesoes8;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Estudiantes inscritos que participan en la segunda sesión  de formación presencial/ Nivel 8 juego Gózate la ciencia.  </td>";
        ca += "<td class='center'>" + countes8 + " de " + totales8 + "</td>";
        ca += "<td class='center'>" + metaes8 + "%</td>";
        ca += "<td class='center'>" + pesoes8 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesiones de formación No. 8 virtual realizadas
        DataTable sesionvirtual8 = c.cargarListadoMemoriasS004_EspVirtualesTodo("", "", "", "", "4", "1", "8");
        double metasv8 = 0;
        int countsv8 = 0;
        int totalsv8 = 3227;
        double pesototalsv8 = 1.41;
        double pesosv8 = 0;
        if (sesionvirtual8 != null && sesionvirtual8.Rows.Count > 0)
        {
            countsv8 = sesionvirtual8.Rows.Count;
            metasv8 = ((double)countsv8 / (double)totalsv8) * 100;
            metasv8 = Math.Round(metasv8, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesosv8= ((double)countsv8 / (double)totalsv8) * pesototalsv8;
            pesosv8 = Math.Round(pesosv8, 4);
            if (pesosv8 > pesototalsv8)
            {
                pesosv2 = pesototalsv8;
            }
            pesototal = pesototal + pesosv8;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Sesiones de formación No. 8 virtual realizadas  </td>";
        ca += "<td class='center'>" + countsv8 + " de " + totalsv8 + "</td>";
        ca += "<td class='center'>" + metasv8 + "%</td>";
        ca += "<td class='center'>" + pesosv8 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Estudiantes inscritos que participan en la primera sesión  de formación virtual/ Nivel 8 juego Gózate la ciencia.
        DataTable sesionasistvirtual8 = c.cargarAsistentesMemoriasS004_EspVirtualesTodo("4", "1", "8");
        double metasva8 = 0;
        int countsva8 = 0;
        int totalsva8 = 3227;
        double pesototalsva8 = 1.41;
        double pesosva8 = 0;
        if (sesionasistvirtual8 != null && sesionasistvirtual8.Rows.Count > 0)
        {
            countsva8 = sesionasistvirtual8.Rows.Count;
            metasva8 = ((double)countsva8 / (double)totalsva8) * 100;
            metasva8 = Math.Round(metasva8, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesosva8 = ((double)countsva8 / (double)totalsva8) * pesototalsva8;
            pesosva8 = Math.Round(pesosva8, 4);
            if (pesosva8 > pesototalsva8)
            {
                pesosva8 = pesototalsva8;
            }
            pesototal = pesototal + pesosva8;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Estudiantes inscritos que participan en la primera sesión  de formación virtual/ Nivel 8juego Gózate la ciencia.  </td>";
        ca += "<td class='center'>" + countsva8 + " de " + totalsva8 + "</td>";
        ca += "<td class='center'>" + metasva8 + "%</td>";
        ca += "<td class='center'>" + pesosva8 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesiones de formación presencial  No. 9 realizadas 
        DataTable sesion9 = c.cargarListadoMemoriasS004Todo("", "", "", "", "4", "1", "9");
        double metas9 = 0;
        int counts9 = 0;
        int totals9 = 3227;
        double pesototals9 = 1.41;
        double pesos9 = 0;
        if (sesion9 != null && sesion9.Rows.Count > 0)
        {
            counts9 = sesion9.Rows.Count;
            metas9 = ((double)counts9 / (double)totals9) * 100;
            metas9 = Math.Round(metas9, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesos9 = ((double)counts9 / (double)totals9) * pesototals9;
            pesos9 = Math.Round(pesos9, 4);
            if (pesos9 > pesototals9)
            {
                pesos9 = pesototals9;
            }
            pesototal = pesototal + pesos9;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Sesiones de formación No. 9 presencial realizadas  </td>";
        ca += "<td class='center'>" + counts9 + " de " + totals9 + "</td>";
        ca += "<td class='center'>" + metas9 + "%</td>";
        ca += "<td class='center'>" + pesos9 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Estudiantes inscritos que participan en la segunda sesión  de formación presencial/ Nivel 9 juego Gózate la ciencia.
        DataTable estudiantesasis9 = c.cargarAsistentesMemoriasS004_Todo("4", "1", "9");
        double metaes9= 0;
        int countes9 = 0;
        int totales9 = 110880;
        double pesototales9 = 1.41;
        double pesoes9 = 0;
        if (estudiantesasis9 != null && estudiantesasis9.Rows.Count > 0)
        {
            countes9 = estudiantesasis9.Rows.Count;
            metaes9 = ((double)countes9 / (double)totales9) * 100;
            metaes9 = Math.Round(metaes9, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesoes9 = ((double)countes9 / (double)totales9) * pesototales9;
            pesoes9 = Math.Round(pesoes9, 4);
            if (pesoes9 > pesototales9)
            {
                pesoes9 = pesototales9;
            }
            pesototal = pesototal + pesoes9;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Estudiantes inscritos que participan en la segunda sesión  de formación presencial/ Nivel 9 juego Gózate la ciencia.  </td>";
        ca += "<td class='center'>" + countes9 + " de " + totales9 + "</td>";
        ca += "<td class='center'>" + metaes9 + "%</td>";
        ca += "<td class='center'>" + pesoes9 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesiones de formación No. 9 virtual realizadas
        DataTable sesionvirtual9 = c.cargarListadoMemoriasS004_EspVirtualesTodo("", "", "", "", "4", "1", "9");
        double metasv9 = 0;
        int countsv9 = 0;
        int totalsv9 = 3227;
        double pesototalsv9 = 1.41;
        double pesosv9 = 0;
        if (sesionvirtual9 != null && sesionvirtual9.Rows.Count > 0)
        {
            countsv9 = sesionvirtual9.Rows.Count;
            metasv9 = ((double)countsv9 / (double)totalsv9) * 100;
            metasv9 = Math.Round(metasv9, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesosv9 = ((double)countsv9 / (double)totalsv9) * pesototalsv9;
            pesosv9 = Math.Round(pesosv9, 4);
            if (pesosv9 > pesototalsv9)
            {
                pesosv9 = pesototalsv9;
            }
            pesototal = pesototal + pesosv9;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Sesiones de formación No. 9 virtual realizadas  </td>";
        ca += "<td class='center'>" + countsv9 + " de " + totalsv9 + "</td>";
        ca += "<td class='center'>" + metasv9 + "%</td>";
        ca += "<td class='center'>" + pesosv9 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Estudiantes inscritos que participan en la primera sesión  de formación virtual/ Nivel 9 juego Gózate la ciencia.
        DataTable sesionasistvirtual9 = c.cargarAsistentesMemoriasS004_EspVirtualesTodo("4", "1", "9");
        double metasva9 = 0;
        int countsva9 = 0;
        int totalsva9 = 3227;
        double pesototalsva9 = 1.41;
        double pesosva9 = 0;
        if (sesionasistvirtual9 != null && sesionasistvirtual9.Rows.Count > 0)
        {
            countsva9 = sesionasistvirtual9.Rows.Count;
            metasva9 = ((double)countsva9 / (double)totalsva9) * 100;
            metasva9 = Math.Round(metasva9, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesosva9 = ((double)countsva9 / (double)totalsva9) * pesototalsva9;
            pesosva9 = Math.Round(pesosva9, 4);
            if (pesosva9 > pesototalsva9)
            {
                pesosva9 = pesototalsva9;
            }
            pesototal = pesototal + pesosva9;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Estudiantes inscritos que participan en la primera sesión  de formación virtual/ Nivel 9 juego Gózate la ciencia.  </td>";
        ca += "<td class='center'>" + countsva9 + " de " + totalsva9 + "</td>";
        ca += "<td class='center'>" + metasva9 + "%</td>";
        ca += "<td class='center'>" + pesosva9 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesiones de formación presencial  No. 10 realizadas 
        DataTable sesion10 = c.cargarListadoMemoriasS004Todo("", "", "", "", "4", "1", "10");
        double metas10 = 0;
        int counts10 = 0;
        int totals10 = 3227;
        double pesototals10 = 1.41;
        double pesos10 = 0;
        if (sesion10 != null && sesion10.Rows.Count > 0)
        {
            counts10 = sesion10.Rows.Count;
            metas10 = ((double)counts10 / (double)totals10) * 100;
            metas10 = Math.Round(metas10, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesos10 = ((double)counts10 / (double)totals10) * pesototals10;
            pesos10 = Math.Round(pesos10, 4);
            if (pesos10 > pesototals10)
            {
                pesos10 = pesototals10;
            }
            pesototal = pesototal + pesos10;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Sesiones de formación No. 10 presencial realizadas  </td>";
        ca += "<td class='center'>" + counts10 + " de " + totals10 + "</td>";
        ca += "<td class='center'>" + metas10 + "%</td>";
        ca += "<td class='center'>" + pesos10 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Estudiantes inscritos que participan en la segunda sesión  de formación presencial/ Nivel 10 juego Gózate la ciencia.
        DataTable estudiantesasis10 = c.cargarAsistentesMemoriasS004_Todo("4", "1", "10");
        double metaes10 = 0;
        int countes10 = 0;
        int totales10 = 110880;
        double pesototales10 = 1.41;
        double pesoes10 = 0;
        if (estudiantesasis10 != null && estudiantesasis10.Rows.Count > 0)
        {
            countes10 = estudiantesasis10.Rows.Count;
            metaes10 = ((double)countes10 / (double)totales10) * 100;
            metaes10 = Math.Round(metaes10, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesoes10 = ((double)countes10 / (double)totales2) * pesototales10;
            pesoes10 = Math.Round(pesoes10, 4);
            if (pesoes10 > pesototales10)
            {
                pesoes10 = pesototales10;
            }
            pesototal = pesototal + pesoes10;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Estudiantes inscritos que participan en la segunda sesión  de formación presencial/ Nivel 10 juego Gózate la ciencia.  </td>";
        ca += "<td class='center'>" + countes10 + " de " + totales10 + "</td>";
        ca += "<td class='center'>" + metaes10 + "%</td>";
        ca += "<td class='center'>" + pesoes10 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesiones de formación No. 10 virtual realizadas
        DataTable sesionvirtual10 = c.cargarListadoMemoriasS004_EspVirtualesTodo("", "", "", "", "4", "1", "10");
        double metasv10 = 0;
        int countsv10 = 0;
        int totalsv10 = 3227;
        double pesototalsv10 = 1.41;
        double pesosv10 = 0;
        if (sesionvirtual10 != null && sesionvirtual10.Rows.Count > 0)
        {
            countsv10 = sesionvirtual2.Rows.Count;
            metasv10 = ((double)countsv2 / (double)totalsv2) * 100;
            metasv10 = Math.Round(metasv2, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesosv10 = ((double)countsv10 / (double)totalsv10) * pesototalsv10;
            pesosv10 = Math.Round(pesosv10, 4);
            if (pesosv10 > pesototalsv10)
            {
                pesosv10 = pesototalsv10;
            }
            pesototal = pesototal + pesosv10;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Sesiones de formación No. 10 virtual realizadas  </td>";
        ca += "<td class='center'>" + countsv10 + " de " + totalsv10 + "</td>";
        ca += "<td class='center'>" + metasv10 + "%</td>";
        ca += "<td class='center'>" + pesosv10 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


        //Estudiantes inscritos que participan en la primera sesión  de formación virtual/ Nivel 10 juego Gózate la ciencia.
        DataTable sesionasistvirtual10 = c.cargarAsistentesMemoriasS004_EspVirtualesTodo("4", "1", "10");
        double metasva10 = 0;
        int countsva10 = 0;
        int totalsva10 = 3227;
        double pesototalsva10 = 1.41;
        double pesosva10 = 0;
        if (sesionasistvirtual10 != null && sesionasistvirtual10.Rows.Count > 0)
        {
            countsva10 = sesionasistvirtual10.Rows.Count;
            metasva10 = ((double)countsva10 / (double)totalsva10) * 100;
            metasva10 = Math.Round(metasva10, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesosva10 = ((double)countsva10 / (double)totalsva10) * pesototalsva10;
            pesosva10 = Math.Round(pesosva10, 4);
            if (pesosva10 > pesototalsva10)
            {
                pesosva10 = pesototalsva10;
            }
            pesototal = pesototal + pesosva10;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Estudiantes inscritos que participan en la primera sesión  de formación virtual/ Nivel 10 juego Gózate la ciencia.  </td>";
        ca += "<td class='center'>" + countsva10 + " de " + totalsva10 + "</td>";
        ca += "<td class='center'>" + metasva10 + "%</td>";
        ca += "<td class='center'>" + pesosva10 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //16361 dotaciones y desarrollo del la infraestructura tecnológica y comunicacional 
        DataTable tablets = ins.cargarListaEntregaTabletsSUM();
        double metasva101 = 0;
        int countsva101 = 0;
        int totalsva101 = 28000;
        double pesototalsva101 = 42.16;
        double pesosva101 = 0;
        if (tablets != null && tablets.Rows.Count > 0)
        {
            countsva101 = Convert.ToInt32(tablets.Rows[0]["total"].ToString());
            metasva101 = ((double)countsva101 / (double)totalsva101) * 100;
            metasva101 = Math.Round(metasva101, 2);
            //if (meta2 > 100)
            //{
            //    meta2 = 100;
            //}

            pesosva101 = ((double)countsva101 / (double)totalsva101) * pesototalsva101;
            pesosva101 = Math.Round(pesosva101, 4);
            if (pesosva101 > pesototalsva101)
            {
                pesosva101 = pesototalsva101;
            }
            pesototal = pesototal + pesosva101;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> 16361 dotaciones y desarrollo del la infraestructura tecnológica y comunicacional .  </td>";
        ca += "<td class='center'>" + countsva101 + " de " + totalsva101 + "</td>";
        ca += "<td class='center'>" + metasva101 + "%</td>";
        ca += "<td class='center'>" + pesosva101 + "%</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        /*---------------*/

        ca += "<tr>";
        ca += "<td></td>";
        ca += "<td></td>";
        ca += "<td>TOTAL</td>";
        ca += "<td>" + pesototal + "</td>";
        ca += "<td class='noExl center'><a href='#?sg=true'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        return ca;
    }
   

}