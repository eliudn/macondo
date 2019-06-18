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

public partial class menusegestrategia5 : System.Web.UI.Page
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


        //Sesiones de formación de funcionarios No. 1 realizadas 
        DataTable listado = c.cargarListadoMemoriasS004Estra5("", "", "5","1");
        double meta = 0;
        int count = 0;
        int total = 1;
        //double pesototalv = 1.41;
        double pesototalv =6.061;
        double peso = 0;
        if (listado != null && listado.Rows.Count > 0)
        {
            count = listado.Rows.Count;
            meta = ((double)count / (double)total) * 100;
            meta = Math.Round(meta, 2);
            //if (meta > 100)
            //{
            //    meta = 100;
            //}

            peso = ((double)count / (double)total) * pesototalv;
            peso = Math.Round(peso, 4);
            if (peso > pesototalv)
            {
                peso = pesototalv;
            }
            pesototal = pesototal + peso;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Sesiones de formación de funcionarios No. 1 realizadas </td>";
        ca += "<td class='center'>" + count + " de " + total + "</td>";
        ca += "<td class='center'>" + meta + "%</td>";
        ca += "<td class='center'>" + peso + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Funcionadios inscritos que participan en la primera sesión  de formación
        DataTable listadoas = c.cargarAsistenciaMemoriasS004Estra5("", "5", "1");
        double metaas = 0;
        int countas = 0;
        int totalas = 100;
        double pesototalvas = 6.061;
        double pesoas = 0;
        if (listadoas != null && listadoas.Rows.Count > 0)
        {
            countas = listadoas.Rows.Count;
            metaas = ((double)countas / (double)totalas) * 100;
            metaas = Math.Round(metaas, 2);
            //if (meta > 100)
            //{
            //    meta = 100;
            //}

            pesoas = ((double)countas / (double)totalas) * pesototalvas;
            pesoas = Math.Round(pesoas, 4);
            if (pesoas > pesototalvas)
            {
                pesoas = pesototalvas;
            }
            pesototal = pesototal + pesoas;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Funcionarios inscritos que participan en la primera sesión  de formación </td>";
        ca += "<td class='center'>" + countas + " de " + totalas + "</td>";
        ca += "<td class='center'>" + metaas + "%</td>";
        ca += "<td class='center'>" + pesoas + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesiones de formación de funcionarios No. 2 realizadas 
        DataTable listado2 = c.cargarListadoMemoriasS004Estra5("", "", "5", "2");
        double meta2 = 0;
        int count2 = 0;
        int total2 = 1;
        //double pesototalv2 = 1.41;
        double pesototalv2 = 6.061;
        double peso2 = 0;
        if (listado2 != null && listado2.Rows.Count > 0)
        {
            count2 = listado2.Rows.Count;
            meta2 = ((double)count2 / (double)total2) * 100;
            meta2 = Math.Round(meta2, 2);
            //if (meta > 100)
            //{
            //    meta = 100;
            //}

            peso2 = ((double)count2 / (double)total2) * pesototalv2;
            peso2 = Math.Round(peso2, 4);
            if (peso2 > pesototalv2)
            {
                peso = pesototalv2;
            }
            pesototal = pesototal + peso2;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Sesiones de formación de funcionarios No. 2 realizadas </td>";
        ca += "<td class='center'>" + count2 + " de " + total2 + "</td>";
        ca += "<td class='center'>" + meta2 + "%</td>";
        ca += "<td class='center'>" + peso2 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Funcionadios inscritos que participan en la segunda sesión  de formación
        DataTable listadoas2 = c.cargarAsistenciaMemoriasS004Estra5("", "5", "2");
        double metaas2 = 0;
        int countas2 = 0;
        int totalas2 = 100;
        double pesototalvas2 = 6.061;
        double pesoas2 = 0;
        if (listadoas2 != null && listadoas2.Rows.Count > 0)
        {
            countas2 = listadoas2.Rows.Count;
            metaas2 = ((double)countas2 / (double)totalas2) * 100;
            metaas2 = Math.Round(metaas2, 2);
            //if (meta > 100)
            //{
            //    meta = 100;
            //}

            pesoas2 = ((double)countas2 / (double)totalas2) * pesototalvas2;
            pesoas2 = Math.Round(pesoas2, 4);
            if (pesoas2 > pesototalvas2)
            {
                pesoas2 = pesototalvas2;
            }
            pesototal = pesototal + pesoas2;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Funcionarios inscritos que participan en la segunda sesión  de formación </td>";
        ca += "<td class='center'>" + countas2 + " de " + totalas2 + "</td>";
        ca += "<td class='center'>" + metaas2 + "%</td>";
        ca += "<td class='center'>" + pesoas2 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesiones de formación de funcionarios No. 3 realizadas 
        DataTable listado3 = c.cargarListadoMemoriasS004Estra5("", "", "5", "3");
        double meta3 = 0;
        int count3 = 0;
        int total3 = 1;
        //double pesototalv3 = 1.41;
        double pesototalv3 = 6.061;
        double peso3 = 0;
        if (listado3 != null && listado3.Rows.Count > 0)
        {
            count3 = listado3.Rows.Count;
            meta3 = ((double)count3 / (double)total3) * 100;
            meta3 = Math.Round(meta3, 2);
            //if (meta > 100)
            //{
            //    meta = 100;
            //}

            peso3 = ((double)count3 / (double)total3) * pesototalv3;
            peso3 = Math.Round(peso3, 4);
            if (peso3 > pesototalv3)
            {
                peso3 = pesototalv3;
            }
            pesototal = pesototal + peso3;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Sesiones de formación de funcionarios No. 3 realizadas </td>";
        ca += "<td class='center'>" + count3 + " de " + total3 + "</td>";
        ca += "<td class='center'>" + meta3 + "%</td>";
        ca += "<td class='center'>" + peso3 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Funcionadios inscritos que participan en la tercera sesión  de formación
        DataTable listadoas3 = c.cargarAsistenciaMemoriasS004Estra5("", "5", "1");
        double metaas3 = 0;
        int countas3 = 0;
        int totalas3 = 100;
        double pesototalvas3 = 6.061;
        double pesoas3 = 0;
        if (listadoas3 != null && listadoas3.Rows.Count > 0)
        {
            countas3 = listadoas3.Rows.Count;
            metaas3 = ((double)countas3 / (double)totalas3) * 100;
            metaas3 = Math.Round(metaas3, 2);
            //if (meta > 100)
            //{
            //    meta = 100;
            //}

            pesoas3 = ((double)countas3 / (double)totalas3) * pesototalvas3;
            pesoas3 = Math.Round(pesoas3, 4);
            if (pesoas3 > pesototalvas3)
            {
                pesoas3 = pesototalvas3;
            }
            pesototal = pesototal + pesoas3;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Funcionarios inscritos que participan en la tercera sesión  de formación </td>";
        ca += "<td class='center'>" + countas3 + " de " + totalas3 + "</td>";
        ca += "<td class='center'>" + metaas3 + "%</td>";
        ca += "<td class='center'>" + pesoas3 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesiones de formación de funcionarios No. 4 realizadas 
        DataTable listado4 = c.cargarListadoMemoriasS004Estra5("", "", "5", "4");
        double meta4 = 0;
        int count4 = 0;
        int total4 = 1;
        //double pesototalv4 = 1.41;
        double pesototalv4 = 6.061;
        double peso4 = 0;
        if (listado4 != null && listado4.Rows.Count > 0)
        {
            count4 = listado4.Rows.Count;
            meta4 = ((double)count4 / (double)total4) * 100;
            meta4 = Math.Round(meta4, 2);
            //if (meta > 100)
            //{
            //    meta = 100;
            //}

            peso4 = ((double)count4 / (double)total4) * pesototalv4;
            peso4 = Math.Round(peso4, 4);
            if (peso4 > pesototalv)
            {
                peso4 = pesototalv4;
            }
            pesototal = pesototal + peso4;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Sesiones de formación de funcionarios No. 4 realizadas </td>";
        ca += "<td class='center'>" + count4 + " de " + total4 + "</td>";
        ca += "<td class='center'>" + meta4 + "%</td>";
        ca += "<td class='center'>" + peso4 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Funcionadios inscritos que participan en la cuarta sesión  de formación
        DataTable listadoas4 = c.cargarAsistenciaMemoriasS004Estra5("", "5", "4");
        double metaas4 = 0;
        int countas4 = 0;
        int totalas4 = 100;
        double pesototalvas4 = 6.061;
        double pesoas4 = 0;
        if (listadoas4 != null && listadoas4.Rows.Count > 0)
        {
            countas4 = listadoas4.Rows.Count;
            metaas4 = ((double)countas4 / (double)totalas4) * 100;
            metaas4 = Math.Round(metaas4, 2);
            //if (meta > 100)
            //{
            //    meta = 100;
            //}

            pesoas4 = ((double)countas4 / (double)totalas4) * pesototalvas4;
            pesoas4 = Math.Round(pesoas4, 4);
            if (pesoas4 > pesototalvas4)
            {
                pesoas4 = pesototalvas4;
            }
            pesototal = pesototal + pesoas4;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Funcionarios inscritos que participan en la cuarta sesión  de formación </td>";
        ca += "<td class='center'>" + countas4 + " de " + totalas4 + "</td>";
        ca += "<td class='center'>" + metaas4 + "%</td>";
        ca += "<td class='center'>" + pesoas4 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Sesiones de formación de funcionarios No. 5 realizadas 
        DataTable listado5 = c.cargarListadoMemoriasS004Estra5("", "", "5", "5");
        double meta5 = 0;
        int count5 = 0;
        int total5 = 1;
        //double pesototalv5 = 1.41;
        double pesototalv5 = 6.061;
        double peso5 = 0;
        if (listado5 != null && listado5.Rows.Count > 0)
        {
            count5 = listado5.Rows.Count;
            meta5 = ((double)count5 / (double)total5) * 100;
            meta5 = Math.Round(meta5, 2);
            //if (meta > 100)
            //{
            //    meta = 100;
            //}

            peso5 = ((double)count5 / (double)total5) * pesototalv5;
            peso5 = Math.Round(peso5, 4);
            if (peso5 > pesototalv5)
            {
                peso5 = pesototalv5;
            }
            pesototal = pesototal + peso5;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Sesiones de formación de funcionarios No. 5 realizadas </td>";
        ca += "<td class='center'>" + count5 + " de " + total5 + "</td>";
        ca += "<td class='center'>" + meta5 + "%</td>";
        ca += "<td class='center'>" + peso5 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

        //Funcionadios inscritos que participan en la quinta sesión  de formación
        DataTable listadoas5 = c.cargarAsistenciaMemoriasS004Estra5("", "5", "5");
        double metaas5 = 0;
        int countas5 = 0;
        int totalas5 = 100;
        double pesototalvas5 = 6.061;
        double pesoas5 = 0;
        if (listadoas5 != null && listadoas5.Rows.Count > 0)
        {
            countas5 = listadoas5.Rows.Count;
            metaas5 = ((double)countas5 / (double)totalas5) * 100;
            metaas5 = Math.Round(metaas5, 2);
            //if (meta > 100)
            //{
            //    meta = 100;
            //}

            pesoas5 = ((double)countas5 / (double)totalas5) * pesototalvas5;
            pesoas5 = Math.Round(pesoas5, 4);
            if (pesoas5 > pesototalvas5)
            {
                pesoas5 = pesototalvas5;
            }
            pesototal = pesototal + pesoas5;
        }
        num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b> Funcionarios inscritos que participan en la quinta sesión  de formación </td>";
        ca += "<td class='center'>" + countas5 + " de " + totalas5 + "</td>";
        ca += "<td class='center'>" + metaas5 + "%</td>";
        ca += "<td class='center'>" + pesoas5 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";
       

        /*---------------*/

        /**
            Nueva iten fecha 28/01/2019

         */
        Institucion inst = new Institucion();
         DataTable listadoas6 = inst.cargarListadoSesionComiteDepartamental();
        double metaas6 = 0;
        int countas6 = 0;
        int totalas6 = 10;
        double pesototalvas6 = 1.818;
        double pesoas6 =0;
        if (listadoas6 != null && listadoas6.Rows.Count > 0)
        {
            countas6 = listadoas6.Rows.Count;
            metaas6 = ((double)countas6 / (double)totalas6) * 100;
            metaas6 = Math.Round(metaas6, 2);

             pesoas6 = ((double)countas6 / (double)totalas6) * pesototalvas6;
            pesoas6 = Math.Round(pesoas6, 4);
            if (pesoas6 > pesototalvas6)
            {
                pesoas6 = pesototalvas6;
            }
            pesototal = pesototal + pesoas6;
        }
         
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b>Numero de comités Departamentales realizados 	</td>";
        ca += "<td class='center'>" + countas6 + " de " + totalas6 + "</td>";
        ca += "<td class='center'>" + metaas6 + "%</td>";
        ca += "<td class='center'>" + pesoas6 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";

         DataTable listadoas7 = inst.cargarListadoSesionComiteRegional();
        double metaas7 = 0;
        int countas7 = 0;
        int totalas7 = 40;
        double pesototalvas7 = 7.272;
        double pesoas7 =0;
        if (listadoas7 != null && listadoas7.Rows.Count > 0)
        {
            countas7 = listadoas7.Rows.Count;
            metaas7 = ((double)countas7 / (double)totalas7) * 100;
            metaas7 = Math.Round(metaas7, 2);

            pesoas7 = ((double)countas7 / (double)totalas7) * pesototalvas7;
            pesoas7 = Math.Round(pesoas7, 4);
            if (pesoas7 > pesototalvas7)
            {
                pesoas7 = pesototalvas7;
            }
            pesototal = pesototal + pesoas7;
        }
        
         num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b>Numero de comités Subregionales realizados</td>";
        ca += "<td class='center'>" + countas7 + " de " + totalas7 + "</td>";
        ca += "<td class='center'>" + metaas7 + "%</td>";
        ca += "<td class='center'>" + pesoas7 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";


         DataTable listadoas8 =inst.cargarListadoSesionComiteRedApoyo();
        double metaas8 = 0;
        int countas8 = 0;
        int totalas8 = 4;
        double pesototalvas8 = 30.3;
        double pesoas8 = 0;
         if (listadoas8 != null && listadoas8.Rows.Count > 0)
        {
            countas8 = listadoas8.Rows.Count;
            metaas8 = ((double)countas8 / (double)totalas8) * 100;
            metaas8 = Math.Round(metaas8, 2);

             pesoas8 = ((double)countas8 / (double)totalas8) * pesototalvas8;
            pesoas8 = Math.Round(pesoas8, 4);
            if (pesoas8 > pesototalvas8)
            {
                pesoas8 = pesototalvas8;
            }
            pesototal = pesototal + pesoas8;
        }
        
         num++;
        ca += "<tr>";
        ca += "<td><b>" + num + ".</b>Encuentros Red de Apoyo</td>";
        ca += "<td class='center'>" + countas8 + " de " + totalas8 + "</td>";
        ca += "<td class='center'>" + metaas8+ "%</td>";
        ca += "<td class='center'>" + pesoas8 + "</td>";
        ca += "<td class='noExl center'><a href='#'><img src='images/detalles.png'>Ver</a></td>";
        ca += "</tr>";
        
        /**
            fin  fecha 28/01/2019

         */


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