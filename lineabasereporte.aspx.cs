using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class lineabasereporte : System.Web.UI.Page
{
    protected void Page_PreInit(Object sender, EventArgs e)
    {
        if (Session["codperfil"] != null)
        {

        }
        else
            Response.Redirect("Default.aspx");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        mensaje.Attributes.Add("style", "display:none");// este es el mensaje 
        if (!IsPostBack)
        {
            lblStylePrint02.Text = StylePrint();
            lblStylePrint04.Text = StylePrint();
            lblStylePrint05.Text = StylePrint();
            lblStylePrint06.Text = StylePrint();
        }
    }
    private string StylePrint()
    {
        string co = "";

        co += " <style media='print'>";
        co += "    body {";
        co += "       background-color: #fff;";
        co += "    }";
        co += "    @media print {";
        co += "        @page {";
        co += "            size: auto letter;";
        co += "       }";

        /*thead {
            display: table-header-group;
        }*/

        co += "    }";

        co += "    .contenidoImpresion {";
        co += "        color: #4cff00;";
        co += "        font-family: Courier New;";
        co += "   }";

        co += "   .mGridTesoreria {";
        co += "      width: 99%;";
        co += "      font-family: 'Lato', Helvetica, sans-serif !important;";
        co += "      border: solid 1px #ccc;";
        co += "       border-collapse: collapse;";
        co += "  }";

        co += "      .mGridTesoreria th {";
        co += "          padding: 2px;";
        co += "        border: solid 1px #ccc;";
        co += "      border-collapse: collapse;";
        co += "         color: #000;";
        co += "        font-size: 13px;";
        co += "       background-color: #004b96;";
        co += "    }";

        co += "    .mGridTesoreria td {";
        co += "        padding: 2px;";
        co += "        border: solid 1px #ccc;";
        co += "     border-collapse: collapse;";
        co += "        color: #000;";
        co += "        font-size: 11px;";
        co += "    }";

        co += "    #mGridTesoreria td{";
        co += "        font-size:12px;";
        co += "    }";
        co += "</style>";

        return co;
    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    protected void btncargarReporteLineaBase02_Onclick(object sender, EventArgs e)
    {
        cargarLineaBase02();
        PanelReporteLineaBase02.Visible = true;
        PanelReporteLineaBase04.Visible = false;
        PanelReporteLineaBase05.Visible = false;
        PanelReporteLineaBase06.Visible = false;
    }

    protected void btncargarReporteLineaBase04_Onclick(object sender, EventArgs e)
    {
        cargarLineaBase04();
        PanelReporteLineaBase02.Visible = false;
        PanelReporteLineaBase04.Visible = true;
        PanelReporteLineaBase05.Visible = false;
        PanelReporteLineaBase06.Visible = false;
    }

    protected void btncargarReporteLineaBase05_Onclick(object sender, EventArgs e)
    {
        cargarLineaBase05();
        PanelReporteLineaBase02.Visible = false;
        PanelReporteLineaBase04.Visible = false;
        PanelReporteLineaBase05.Visible = true;
        PanelReporteLineaBase06.Visible = false;
    }

    protected void btncargarReporteLineaBase06_Onclick(object sender, EventArgs e)
    {
        cargarLineaBase06();
        PanelReporteLineaBase02.Visible = false;
        PanelReporteLineaBase04.Visible = false;
        PanelReporteLineaBase05.Visible = false;
        PanelReporteLineaBase06.Visible = true;

    }

    private void cargarLineaBase02()
    {
        string co = "";
        co += "<h2 style='text-decoration: underline;'>Indicadores 02 - Currículo</h2><br/>";
        co += "<table class='mGridTesoreria'>";
        co += "<thead>";
        co += "<tr>";
        co += "<th>INSTRUMENTO</th>";
        co += "<th colspan='2'>ITEM DEL INSTRUMENTO</th>";
        co += "<th>INDICADOR/ES RELACIONADO/S/LINEA BASE</th>";
        co += "<th>CÓDIGO ACTIVIDAD</th>";
        co += "<th>CÓDIGO INDICADOR</th>";
        //co += "<th>PARAMETRIZACIÓN Nivel 1</th>";
        //co += "<th>PARAMETRIZACIÓN Nivel 2</th>";
        //co += "<th>PARAMETRIZACIÓN Nivel 3</th>";
        //co += "<th>PARAMETRIZACIÓN Nivel 4</th>";
        //co += "<th>TIPO</th>";
        //co += "<th>INDICADOR IMPACTO</th>";
        //co += "<th>APLICACIÓN</th>";
        //co += "<th>FECHA DE CARGUE DE LA INFORMACIÓN</th>";
        //co += "<th>RESPONSABLE EN SIEP</th>";
        //co += "<th>ACTIVIDAD</th>";
        //co += "<th>VERIFICA Y VALIDA</th>";
        //co += "<th>ACTIVIDAD</thth>";
        co += "<th>DETALLE</th>";
        co += "</tr>";
        co += "<thead>";

        co += "<tr>";
        co += "<td rowspan='20'>Instrumento No. 02 Perfil curricular institucional Caracterización de Currículos de las IEs Proyecto Ciclón</td>";
        co += "<td colspan='2'>Identificación: Institución sede, Responsable Institución Educativa, Responsable del diligenciamiento</td>";
        co += "<td align='center'>Número de sedes educativas con información de currículos: <b>" + NumSedesConCurriculos() + "</b></td>";
        co += "<td align='center'>E6A03</td>";
        co += "<td align='center'></td>";
        co += "<td align='center'><a href='lineabasereportedet.aspx?cins=2&cind=1'><img src='Imagenes/ver.png' /></a></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'>1. Cuál es el énfasis formativo del Proyecto Educativo Institucional – PEI?</td>";
        co += "<td>Número Sedes que incluyen Ciencia, tecnología e Innovación, Investigación, TIC en sus enfasis formativos: <b>" + NumSedesConEnfasis() + "<b></td>";
        co += "<td align='center'>E6A03</td>";
        co += "<td align='center'>E6A03CU0101</td>";
        co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'>2.Cuál es el modelo educativo de la sede beneficiada, teniendo en cuenta la clasificación del  –MEN y describa si el modelo educativo seleccionado favorece la incorporación de la IEP en su sede educativa?</td>";
        co += "<td>Número Sedes que incluyen Modelos educativos potencialmente favorables a la incorporación de la IEP: <b>" + NumSedesConModeloEducativo() + "<b></td>";
        co += "<td align='center'>E6A03</td>";
        co += "<td align='center'>E6A03CU0201</td>";
        co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='5'>3. En el PEI y/o en los procesos institucionales se considera alguno de los siguientes aspectos:</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>La investigación docente</td>";
        co += "<td>Número sedes que consideran en sus PEI y/o procesos institucionales la investigación docente: <b>" + NumSedesConInvestigacionDocente() + "</b> </td>";
        co += "<td align='center'>E6A03</td>";
        co += "<td align='center'>E6A03CU0301</td>";
        co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>La investigación de los estudiantes</td>";
        co += "<td>Número sedes que consideran en sus consideran en sus PEI y/o procesos institucionales la investigación de los estudiantes: <b>" + NumSedesConInvestigacionEstudiante() + "</b></td>";
        co += "<td align='center'>E6A03</td>";
        co += "<td align='center'>E6A03CU0302</td>";
        co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>Uso de Las TICs de los Docentes</td>";
        co += "<td>Número sedes que consideran en sus  consideran en sus PEI y/o procesos institucionales el uso de TICS por los docentes: <b>" + NumSedesConTICDocente() + "</b></td>";
        co += "<td align='center'>E6A03</td>";
        co += "<td align='center'>E6A03CU0303</td>";
        co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>Uso de TICS con los estudiantes</td>";
        co += "<td>Número sedes que consideran el uso de TICS en los estudiantes: <b>" + NumSedesConTICEstudiante() + "<b></td>";
        co += "<td align='center'>E6A03</td>";
        co += "<td align='center'>E6A03CU0303</td>";
        co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'>4. ¿ Cuáles son las principales prácticas de innovación educativa que se realizan en la sede beneficiada?</td>";
        co += "<td align='center'>Número de sedes educativas que realizan prácticas  pedagógicas de indagación e investigación: <b>" + NumSedesConPrincipalesPrecticasInnovacion() + "</b></td>";
        co += "<td align='center'>E6A03</td>";
        co += "<td align='center'>E6A03CU0401</td>";
        co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td >5. ¿En el PEI se promueve la investigación dentro de las prácticas instucionales?</td>";
        co += "<td align='center'>S/N</td>";
        co += "<td align='center'><b>" + NumSedesConPrincipalesPracticas() + "</b></td>";
        co += "<td align='center'>E6A03</td>";
        co += "<td align='center'>E6A03CU0501</td>";
        co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='3'>6. ¿En el PEI se promueve el uso de las TIC como parte de las prácticas institucionales?</td>";
        co += " </tr>";

        co += " <tr>";
        co += " <td> S/N Cómo</td>";
        co += "<td align='center'>Número sedes educativas que tienen en el PEI y/o prácticas institucionales el uso de las TICS: <b>" + NumSedesConUsoTIC() + "</b></td>";
        co += "<td align='center'>E6A03</td>";
        co += "<td align='center'>E6A03CU601</td>";
        co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
        co += " </tr>";

        co += " <tr>";
        co += " <td>";
        co += " ¿Cuáles TIC?s</td>";
        co += " <td> " + UsoTIC() + "</td>";
        co += "<td align='center'>E6A03</td>";
        co += "<td align='center'>E6A03CU602</td>";
        co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
        co += "</tr>";

        co += " <tr>";
        co += "<td > 7. El currículo pretende formar en competencias para el uso y apropiación de la TIC? </td>";
        co += "  <td>S/N</td>";
        co += "  <td align='center'><b>" + NumSedesCompetenciasTIC() + "<b></td>";
        co += "<td align='center'>E6A03</td>";
        co += "<td align='center'>E6A03CU701</td>";
        co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
        co += " </tr>";

        co += "  <tr>";
        co += "  <td rowspan='9'> ";
        co += " 8.¿Cuáles competencias en i apropiación de TIC pretende formar el currículo?";

        co += "  </td>";
        co += "  </tr>";

        co += NumSedesApropiacionTIC(); ;



        co += "</table>";

        lblResultado02.Text = co;
    }

    private string NumSedesConCurriculos()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataRow dato = lb.contarSedesConCurriculo();

        if (dato != null)
        {
            ca = dato["count"].ToString();
        }
        else
        {
            ca = "0";
        }

        return ca;
    }

    private string NumSedesConEnfasis()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataTable datos = lb.cargarSedesEnLineaBase();

        if (datos != null && datos.Rows.Count > 0)
        {
            int cont = 0;
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                DataTable enfasis = lb.cargarRespuestasCerradasxInstrumento02(datos.Rows[i]["codigo"].ToString(), "1", "0", "2");

                if (enfasis != null)
                {
                    cont++;
                }
                ca = Convert.ToString(cont);
            }
        }

        return ca;
    }

    private string NumSedesConModeloEducativo()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataTable datos = lb.cargarSedesEnLineaBase();

        if (datos != null && datos.Rows.Count > 0)
        {
            int cont = 0;
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                DataTable enfasis = lb.cargarRespuestasCerradasxInstrumento02(datos.Rows[i]["codigo"].ToString(), "2", "0", "2");

                if (enfasis != null)
                {
                    cont++;
                }
                ca = Convert.ToString(cont);
            }
        }

        return ca;
    }

    private string NumSedesConInvestigacionDocente()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataTable datos = lb.cargarSedesEnLineaBase();

        if (datos != null && datos.Rows.Count > 0)
        {
            int si = 0;
            int no = 0;
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                DataTable enfasis = lb.cargarRespuestasCerradasxInstrumento02(datos.Rows[i]["codigo"].ToString(), "3", "1", "2");

                if (enfasis != null)
                {
                    for (int j = 0; j < enfasis.Rows.Count; j++)
                    {
                        if (enfasis.Rows[j]["respuesta"].ToString() == "Si")
                        {
                            si++;
                        }
                        else
                        {
                            no++;
                        }
                    }
                }
            }
            ca = "Si: " + Convert.ToString(si) + ", No: " + Convert.ToString(no);
        }

        return ca;
    }

    private string NumSedesConInvestigacionEstudiante()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataTable datos = lb.cargarSedesEnLineaBase();

        if (datos != null && datos.Rows.Count > 0)
        {
            int si = 0;
            int no = 0;
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                DataTable enfasis = lb.cargarRespuestasCerradasxInstrumento02(datos.Rows[i]["codigo"].ToString(), "3", "2", "2");

                if (enfasis != null)
                {
                    for (int j = 0; j < enfasis.Rows.Count; j++)
                    {
                        if (enfasis.Rows[j]["respuesta"].ToString() == "Si")
                        {
                            si++;
                        }
                        else
                        {
                            no++;
                        }
                    }
                }
            }
            ca = "Si: " + Convert.ToString(si) + ", No: " + Convert.ToString(no);
        }

        return ca;
    }

    private string NumSedesConTICDocente()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataTable datos = lb.cargarSedesEnLineaBase();

        if (datos != null && datos.Rows.Count > 0)
        {
            int si = 0;
            int no = 0;
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                DataTable enfasis = lb.cargarRespuestasCerradasxInstrumento02(datos.Rows[i]["codigo"].ToString(), "3", "3", "2");

                if (enfasis != null)
                {
                    for (int j = 0; j < enfasis.Rows.Count; j++)
                    {
                        if (enfasis.Rows[j]["respuesta"].ToString() == "Si")
                        {
                            si++;
                        }
                        else
                        {
                            no++;
                        }
                    }
                }
            }
            ca = "Si: " + Convert.ToString(si) + ", No: " + Convert.ToString(no);
        }

        return ca;
    }

    private string NumSedesConTICEstudiante()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataTable datos = lb.cargarSedesEnLineaBase();

        if (datos != null && datos.Rows.Count > 0)
        {
            int si = 0;
            int no = 0;
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                DataTable enfasis = lb.cargarRespuestasCerradasxInstrumento02(datos.Rows[i]["codigo"].ToString(), "3", "4", "2");

                if (enfasis != null)
                {
                    for (int j = 0; j < enfasis.Rows.Count; j++)
                    {
                        if (enfasis.Rows[j]["respuesta"].ToString() == "Si")
                        {
                            si++;
                        }
                        else
                        {
                            no++;
                        }
                    }
                }
            }
            ca = "Si: " + Convert.ToString(si) + ", No: " + Convert.ToString(no);
        }

        return ca;
    }

    private string NumSedesConPrincipalesPrecticasInnovacion()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataTable datos = lb.cargarSedesEnLineaBase();

        if (datos != null && datos.Rows.Count > 0)
        {
            int si = 0;
            int no = 0;
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                DataTable enfasis = lb.cargarRespuestasAbiertasxInstrumento02(datos.Rows[i]["codigo"].ToString(), "4", "2");

                if (enfasis != null)
                {
                    si++;
                }
                ca = Convert.ToString(si);
            }
        }

        return ca;
    }

    private string NumSedesConPrincipalesPracticas()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataTable datos = lb.cargarSedesEnLineaBase();

        if (datos != null && datos.Rows.Count > 0)
        {
            int si = 0;
            int no = 0;
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                DataTable enfasis = lb.cargarRespuestasCerradasxInstrumento02(datos.Rows[i]["codigo"].ToString(), "5", "0", "2");

                if (enfasis != null)
                {
                    for (int j = 0; j < enfasis.Rows.Count; j++)
                    {
                        if (enfasis.Rows[j]["respuesta"].ToString() == "Si")
                        {
                            si++;
                        }
                        else
                        {
                            no++;
                        }
                    }
                }
                ca = "Si: " + Convert.ToString(si) + ", No: " + Convert.ToString(no);
            }
        }

        return ca;
    }

    private string NumSedesConUsoTIC()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataTable datos = lb.cargarSedesEnLineaBase();

        if (datos != null && datos.Rows.Count > 0)
        {
            int si = 0;
            int no = 0;
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                DataTable enfasis = lb.cargarRespuestasCerradasxInstrumento02(datos.Rows[i]["codigo"].ToString(), "6", "0", "2");

                if (enfasis != null)
                {
                    si++;
                }
                else
                {
                    no++;
                }
                ca = "Si: " + Convert.ToString(si) + ", No: " + Convert.ToString(no);
            }
        }

        return ca;
    }

    private string UsoTIC()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataTable datos = lb.cargarSedesEnLineaBase();

        if (datos != null && datos.Rows.Count > 0)
        {
            int PC = 0;
            int Tableta = 0;
            int Tablerointeligente = 0;
            int Wikis = 0;
            int Foros = 0;
            int Portátil = 0;
            int Correoelectronico = 0;
            int Softwareeducativo = 0;
            int Blogs = 0;

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                DataTable tic = lb.cargarRespuestasCerradasxInstrumento02GroupBY(datos.Rows[i]["codigo"].ToString(), "6", "0", "2");

                if (tic != null)
                {
                    for (int j = 0; j < tic.Rows.Count; j++)
                    {
                        if (tic.Rows[j]["respuesta"].ToString() == "PC")
                        {
                            if (PC == 0)
                            {
                                ca += "PC <br/>";
                                PC = 1;
                            }
                        }
                        if (tic.Rows[j]["respuesta"].ToString() == "Tableta")
                        {
                            if (Tableta == 0)
                            {
                                ca += "Tableta <br/>";
                                Tableta = 1;
                            }
                        }
                        if (tic.Rows[j]["respuesta"].ToString() == "Tablero inteligente")
                        {
                            if (Tablerointeligente == 0)
                            {
                                ca += "Tablero inteligente <br/>";
                                Tablerointeligente = 1;
                            }
                        }
                        if (tic.Rows[j]["respuesta"].ToString() == "Wikis")
                        {
                            if (Wikis == 0)
                            {
                                ca += "Wikis <br/>";
                                Wikis = 1;
                            }
                        }
                        if (tic.Rows[j]["respuesta"].ToString() == "Foros")
                        {
                            if (Foros == 0)
                            {
                                ca += "Foros <br/>";
                                Foros = 1;
                            }
                        }
                        if (tic.Rows[j]["respuesta"].ToString() == "Portátil")
                        {
                            if (Portátil == 0)
                            {
                                ca += "Portátil <br/>";
                                Portátil = 1;
                            }
                        }
                        if (tic.Rows[j]["respuesta"].ToString() == "Correo electrónico")
                        {
                            if (Softwareeducativo == 0)
                            {
                                ca += "Correo electrónico <br/>";
                                Softwareeducativo = 1;
                            }
                        }
                        if (tic.Rows[j]["respuesta"].ToString() == "Software educativo")
                        {
                            if (Softwareeducativo == 0)
                            {
                                ca += "Software educativo <br/>";
                                Softwareeducativo = 1;
                            }
                        }
                        if (tic.Rows[j]["respuesta"].ToString() == "Blogs")
                        {
                            if (Blogs == 0)
                            {
                                ca += "Blogs <br/>";
                                Blogs = 1;
                            }
                        }
                    }
                }
            }
        }

        return ca;
    }

    private string NumSedesCompetenciasTIC()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataTable datos = lb.cargarSedesEnLineaBase();

        if (datos != null && datos.Rows.Count > 0)
        {
            int si = 0;
            int no = 0;
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                DataTable enfasis = lb.cargarRespuestasCerradasxInstrumento02(datos.Rows[i]["codigo"].ToString(), "7", "0", "2");

                if (enfasis != null)
                {
                    si++;
                }
                else
                {
                    no++;
                }
                ca = "Si: " + Convert.ToString(si) + ", No: " + Convert.ToString(no);
            }
        }

        return ca;
    }

    private string NumSedesApropiacionTICPedagogica()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataTable datos = lb.cargarSedesEnLineaBase();

        if (datos != null && datos.Rows.Count > 0)
        {
            int si = 0;
            int no = 0;
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                DataTable enfasis = lb.cargarRespuestasCerradasxInstrumento02(datos.Rows[i]["codigo"].ToString(), "8", "0", "2");

                if (enfasis != null)
                {
                    for (int j = 0; j < enfasis.Rows.Count; j++)
                    {
                        if (enfasis.Rows[j]["respuesta"].ToString() == "Pedagógica")
                        {
                            si++;
                        }
                        else
                        {
                            no++;
                        }
                    }

                }
                ca = "Si: " + Convert.ToString(si) + ", No: " + Convert.ToString(no);
            }
        }

        return ca;
    }

    private string NumSedesApropiacionTICTecnologica()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataTable datos = lb.cargarSedesEnLineaBase();

        if (datos != null && datos.Rows.Count > 0)
        {
            int si = 0;
            int no = 0;
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                DataTable enfasis = lb.cargarRespuestasCerradasxInstrumento02(datos.Rows[i]["codigo"].ToString(), "8", "0", "2");

                if (enfasis != null)
                {
                    for (int j = 0; j < enfasis.Rows.Count; j++)
                    {
                        if (enfasis.Rows[j]["respuesta"].ToString() == "Tecnológica")
                        {
                            si++;
                        }
                        else
                        {
                            no++;
                        }
                    }

                }
                ca = "Si: " + Convert.ToString(si) + ", No: " + Convert.ToString(no);
            }
        }

        return ca;
    }

    private string NumSedesApropiacionTICInvestigativa()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataTable datos = lb.cargarSedesEnLineaBase();

        if (datos != null && datos.Rows.Count > 0)
        {
            int si = 0;
            int no = 0;
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                DataTable enfasis = lb.cargarRespuestasCerradasxInstrumento02(datos.Rows[i]["codigo"].ToString(), "8", "0", "2");

                if (enfasis != null)
                {
                    for (int j = 0; j < enfasis.Rows.Count; j++)
                    {
                        if (enfasis.Rows[j]["respuesta"].ToString() == "Investigativa")
                        {
                            si++;
                        }
                        else
                        {
                            no++;
                        }
                    }

                }
                ca = "Si: " + Convert.ToString(si) + ", No: " + Convert.ToString(no);
            }
        }

        return ca;
    }

    private string NumSedesApropiacionTICComunicativa()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataTable datos = lb.cargarSedesEnLineaBase();

        if (datos != null && datos.Rows.Count > 0)
        {
            int si = 0;
            int no = 0;
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                DataTable enfasis = lb.cargarRespuestasCerradasxInstrumento02(datos.Rows[i]["codigo"].ToString(), "8", "0", "2");

                if (enfasis != null)
                {
                    for (int j = 0; j < enfasis.Rows.Count; j++)
                    {
                        if (enfasis.Rows[j]["respuesta"].ToString() == "Comunicativa")
                        {
                            si++;
                        }
                        else
                        {
                            no++;
                        }
                    }

                }
                ca = "Si: " + Convert.ToString(si) + ", No: " + Convert.ToString(no);
            }
        }

        return ca;
    }

    private string NumSedesApropiacionTICGestion()
    {
        string ca = "";
        LineaBase lb = new LineaBase();

        DataTable datos = lb.cargarSedesEnLineaBase();

        if (datos != null && datos.Rows.Count > 0)
        {
            int si = 0;
            int no = 0;
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                DataTable enfasis = lb.cargarRespuestasCerradasxInstrumento02(datos.Rows[i]["codigo"].ToString(), "8", "0", "2");

                if (enfasis != null)
                {
                    for (int j = 0; j < enfasis.Rows.Count; j++)
                    {
                        if (enfasis.Rows[j]["respuesta"].ToString() == "Gestión")
                        {
                            si++;
                        }
                        else
                        {
                            no++;
                        }
                    }

                }

            }
            ca = "Si: " + Convert.ToString(si) + ", No: " + Convert.ToString(no);
        }

        return ca;
    }

    private string NumSedesApropiacionTIC()
    {
        string co = "";

        LineaBase lb = new LineaBase();
        DataTable datos = lb.cargarSedesEnLineaBase();

        if (datos != null && datos.Rows.Count > 0)
        {
            int siPedagogica = 0;
            int siTecnologica = 0;
            int siInvestigativa = 0;
            int siComunicativa = 0;
            int siGestion = 0;

            int noPedagogica = 0;

            for (int i = 0; i < datos.Rows.Count; i++)
            {
                DataTable enfasis = lb.cargarRespuestasCerradasxInstrumento02(datos.Rows[i]["codigo"].ToString(), "8", "0", "2");

                if (enfasis != null)
                {
                    for (int j = 0; j < enfasis.Rows.Count; j++)
                    {
                        if (enfasis.Rows[j]["respuesta"].ToString() == "Pedagógica")
                        {
                            siPedagogica++;
                        }
                        else if (enfasis.Rows[j]["respuesta"].ToString() == "Tecnológica ")
                        {
                            siTecnologica++;
                        }
                        else if (enfasis.Rows[j]["respuesta"].ToString() == "Investigativa ")
                        {
                            siInvestigativa++;
                        }
                        else if (enfasis.Rows[j]["respuesta"].ToString() == "Comunicativa ")
                        {
                            siComunicativa++;
                        }
                        else if (enfasis.Rows[j]["respuesta"].ToString() == "Gestión")
                        {
                            siGestion++;
                        }
                    }
                }
            }
            co += "  <tr>";
            co += "  <td>Pedagógica</td>";
            int tPedagogica = datos.Rows.Count - siPedagogica;
            co += "  <td align='center'><b>Si: " + siPedagogica + " - No: " + tPedagogica + "<b></td>";
            co += "<td align='center'>E6A03</td>";
            co += "<td align='center'>E6A03CU0801</td>";
            co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
            co += " </tr>";

            co += " <tr>";
            co += "  <td> Tecnológica</td>";
            int tTecnologica = datos.Rows.Count - siTecnologica;
            co += "  <td align='center'><b> Si: " + siTecnologica + " - No: " + tTecnologica + "<b></td>";
            co += "<td align='center'>E6A03</td>";
            co += "<td align='center'>E6A03CU0802</td>";
            co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
            co += " </tr>";

            co += " <tr>";
            co += " <td> Investigativa</td>";
            int tInvestigativa = datos.Rows.Count - siInvestigativa;
            co += "  <td align='center'><b>Si: " + siInvestigativa + " - No: " + tInvestigativa + "<b></td>";
            co += "<td align='center'>E6A03</td>";
            co += "<td align='center'>E6A03CU0803</td>";
            co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
            co += " </tr>";

            co += " <tr>";
            co += " <td> Comunicativa</td>";
            int tComunicativa = datos.Rows.Count - siComunicativa;
            co += "  <td align='center'><b>Si: " + siComunicativa + " - No: " + tComunicativa + "<b></td>";
            co += "<td align='center'>E6A03</td>";
            co += "<td align='center'>E6A03CU0804</td>";
            co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
            co += " </tr>";

            co += " <tr>";
            co += " <td>Gestión</td>";
            int tGestion = datos.Rows.Count - siGestion;
            co += "  <td align='center'><b>Si: " + siGestion + " - No: " + tGestion + "<b></td>";
            co += "<td align='center'>E6A03</td>";
            co += "<td align='center'>E6A03CU0805</td>";
            co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
            co += " </tr>";
        }



        return co;
    }


    /*  LINEA BASE, 04 - AUTOPERCECIÓN DOCENTE  */

    private void cargarLineaBase04()
    {
        string co = "";
        co += "<h2 style='text-decoration: underline;'>Indicadores 04 - Autopercepción</h2><br/>";
        co += "<table class='mGridTesoreria'>";
        co += "  <tr>";
        co += "  <thead>";
        co += " <th>INSTRUMENTO</th>";
        co += " <th colspan='3'>ITEM DEL INSTRUMENTO</th>";
        co += "  <th>INDICADOR/ES RELACIONADO/S/LINEA BASE</th>";
        co += "  <th>CÓDIGO ACTIVIDAD</th>";
        co += "  <th>CÓDIGO INDICADOR</th>";
        co += "  </thead>";
        co += "  </tr>";

        co += "  <tr>";
        co += "  <td rowspan='67'>Instrumento No. 04 Autopercepción de los docentes de las sedes educativas sobre sus competencias en NTICs e investigacion Formulario de autopercepción sobre Competencias pedagógicas de los docentes en el uso de TICs</td>";
        co += "  <td rowspan='2'>Identificación</td>";
        co += "  <td colspan='2'>Institución/Sede </td>";
        co += "  <td>Total sedes educativas con información de docentes que participan en CICLÓN sobre competencias en Ntics e investigativas: <b>" + NumSedesConAutopercepcion() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td></td>";
        co += "  </tr>";

        co += "  <tr>";
        co += "  <td colspan='2'> Del/la docente</td>";
        co += "  <td>Contar número de docentes que responden el instrumemnto sobre autopercepción de competencias en TIC e investigativas: <b>" + NumDocentesConAutopercepcion() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td></td>";
        co += "  </tr>";

        co += "	<tr>";
        co += "	<td rowspan='12'>1. Técnicas y tecnológicas: Capacidad para seleccionar y utilizar de forma pertinente, responsable y eficiente una variedad de herramientas tecnológicas entendiendo los principios que las rigen, la forma de combinarlas y las licencias que las amparan. </td>";
        co += "<td rowspan='4'>1.1 Reconoce un amplio espectro de herramientas tecnológicas y algunas formas de integrarlas a la práctica educativa.              1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre</td>";
        co += "	</tr>";

        co += "	<tr>";
        co += "	<td>Identifico las características, usos y oportunidades que ofrecen herramientas tecnológicas y medios audiovisuales, en los procesos educativos</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta1Item1() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0101</td>";
        co += "		</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Elaboro actividades de aprendizaje utilizando aplicativos, contenidos, herramientas informáticas y medios audiovisuales</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta1Item2() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0102</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Evalúo la calidad, pertinencia y veracidad de la información disponible en diversos medios como portales educativos y especializados, motores de búsqueda y material audiovisual.</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta1Item3() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0103</td>";
        co += "	</tr>";

        co += "		<tr>";
        co += "		<td rowspan='4'>";
        co += "		1.2. Utiliza herramientas tecnológicas en los procesos educativos, de acuerdo a su rol, área de formación, nivel y contexto en el que se desempeña.                            1= Nunca;  2= Casi nunca; 3= Algunas veces; 4= Casi siempre; 5= Siempre";
        co += "		</td>";
        co += "		</tr>";

        co += "	<tr>";
        co += "		<td>";
        co += "		Combino una amplia variedad de herramientas tecnológicas para mejorar la planeación e implementación de mis prácticas educativas.";
        co += "		</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta2Item1() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0104</td>";
        co += "		</tr>";

        co += "		<tr>";
        co += "		<td>";
        co += "		Diseño y publico contenidos digitales u objetos virtuales de aprendizaje mediante el uso adecuado de herramientas tecnológicas.";
        co += "		</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta2Item2() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0105</td>";
        co += "		</tr>";

        co += "		<tr>";
        co += "		<td>";
        co += "Analizo los riesgos y potencialidades de publicar y compartir distintos tipos de información a través de Internet";
        co += "		</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta2Item3() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0106</td>";
        co += "		</tr>";

        co += "		<tr>";
        co += "		<td rowspan='4'>";
        co += "		1.3. Aplica el conocimiento de una amplia variedad de tecnologías en el diseño de ambientes de aprendizaje  innovadores y para plantear soluciones a problemas identificados en el contexto.  1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre";

        co += "		</td>";
        co += "		</tr>";

        co += "		<tr>";
        co += "<td>";
        co += "Utilizo herramientas tecnológicas complejas o especializadas para diseñar ambientes virtuales de aprendizaje que favorecen el desarrollo de competencias en mis estudiantes y la conformación de comunidades y/o redes de aprendizaje.";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta3Item1() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0107</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Utilizo herramientas tecnológicas para ayudar a mis estudiantes a construir aprendizajes significativos y desarrollar pensamiento crítico.";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta3Item2() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0108</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Aplico las normas de propiedad intelectual y licenciamiento existentes, referentes al uso de información ajena y propia";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta3Item3() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0109</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='12'>";
        co += "2. Pedagógicas: Capacidad de utilizar las TIC para fortalecer los procesos de enseñanza y aprendizaje, reconociendo alcances y limitaciones de la incorporación de estas tecnologías en la formación integral de los estudiantes y en su propio desarrollo profesional.";

        co += "</td>";
        co += "<td rowspan='4'>";
        co += "2.1.    Identifica nuevas estrategias y metodologías mediadas por las TIC, como  herramienta para su desempeño profesional.            1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre";

        co += "</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Utilizo las TIC para aprender por iniciativa personal y para actualizar los conocimientos y prácticas propios de mi disciplina. ";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta4Item1() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0201</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Identifico problemáticas educativas en mi práctica docente y las oportunidades, implicaciones y riesgos del uso de las TIC para atenderlas.";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta4Item2() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0202</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Conozco una variedad de estrategias y metodologías apoyadas por las TIC, para planear y hacer seguimiento a mi labor docente.";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta4Item3() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0203</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='4'>";
        co += "2.2. Propone proyectos y estrategias de aprendizaje con el uso de TIC para potenciar el aprendizaje de los estudiantes   1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre";
        co += "		</td>";
        co += "</tr>";

        co += "			<tr>";
        co += "		<td>";
        co += "Incentivo en mis estudiantes el aprendizaje autónomo y el aprendizaje colaborativo apoyados por TIC.";

        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta5Item1() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0204</td>";
        co += "</tr>";

        co += "		<tr>";
        co += "<td>";
        co += "Utilizo TIC con mis estudiantes para atender sus necesidades e intereses y proponer soluciones a problemas de aprendizaje.";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta5Item2() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0205</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Implemento estrategias didácticas mediadas por TIC, para fortalecer en mis estudiantes aprendizajes que les permitan resolver problemas de la vida real";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta5Item3() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0206</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='4'>";
        co += "2.3 Lidera experiencias significativas que involucran ambientes de aprendizaje diferenciados de acuerdo a las necesidades e intereses propias y de los estudiantes.           1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre";
        co += "</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Diseño ambientes de aprendizaje mediados por TIC de acuerdo con el desarrollo cognitivo, físico, psicológico y social de mis estudiantes para fomentar el desarrollo de sus competencias.";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta6Item1() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0207</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Propongo proyectos educativos mediados con TIC, que permiten la reflexión sobre el aprendizaje propio y la producción de conocimiento.";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta6Item2() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0208</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Evalúo los resultados obtenidos con la implementación de estrategias que hacen uso educativo de TIC y promuevo una cultura de seguimiento, retroalimentación y mejoramiento permanente";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta6Item3() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0209</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='12'>";
        co += "3. Comunicativa y colaborativas: Capacidad para expresarse, establecer contacto y relacionarse en espacios virtuales y audiovisuales a través de diversos medios y con el manejo de múl¬tiples lenguajes, de manera sincrónica y asincrónica.";
        co += "</td>";
        co += "<td rowspan='4'>";
        co += "3.1 Emplea diversos canales y lenguajes propios de las TIC para comunicarse con la comunidad educativa. 1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre";
        co += "</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Me comunico adecuadamente con mis estudiantes y sus familiares, mis colegas e investigadores usando TIC de manera sincrónica y asincrónica.";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta7Item1() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0301</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Navego eficientemente en Internet integrando fragmentos de información presentados de forma no lineal.";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta7Item2() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0302</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Evalúo la pertinencia de compartir información a través de canales públicos y masivos, respetando las normas de propiedad intelectual y licenciamiento.";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta7Item3() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0303</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='4'>";
        co += "3.2 Desarrolla estrategias de trabajo colaborativo en el contexto escolar a partir de su participación en redes y comunidades con el uso de las TIC.                 1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre";
        co += "</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Participo activamente en redes y comunidades de práctica mediadas por TIC y facilito la participación de mis estudiantes en las mismas, de una forma pertinente y respetuosa";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta8Item1() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0304</td>";
        co += "</tr>";

        co += "		<tr>";
        co += "		<td>";
        co += "		Sistematizo y hago seguimiento a experiencias significativas de uso de TIC.";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta8Item2() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0305</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Promuevo en la comunidad educativa comunicaciones efectivas que aportan al mejoramiento de los procesos de convivencia escolar.";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta8Item3() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0306</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='4'>";
        co += "3.3. Participa en comunidades y publica sus producciones textuales en diversos espacios virtuales y a través de múltiples medios digitales, usando los lenguajes que posibilitan las TIC. 1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre";
        co += "</td>";
        co += "</tr>";

        co += "	<tr>";
        co += "<td>";
        co += "Utilizo variedad de textos e interfaces para transmitir información y expresar ideas propias combinando texto, audio, imágenes estáticas o dinámicas, videos y gestos.";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta9Item1() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0307</td>";
        co += "</tr>";

        co += "<tr>";
        co += "		<td>";
        co += "Interpreto y produzco íconos, símbolos y otras formas de representación de la información, para ser utilizados con propósitos educativos";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta9Item2() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0308</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Contribuyo con mis conocimientos y los de mis estudiantes a repositorios de la humanidad de Internet, con textos de diversa naturaleza.";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta9Item3() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0309</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='12'>";
        co += "4.0 De gestión escolar";
        co += "	</td>";
        co += "<td rowspan='4'>";
        co += "4.1. Organiza actividades propias de su quehacer profesional con el uso de las TIC   1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre";
        co += "</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Identifico los elementos de la gestión escolar que pueden ser mejorados con el uso de las TIC, en las diferentes actividades institucionales.";
        co += "		</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta10Item1() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0401</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Conozco políticas escolares para el uso de las TIC que contemplan la privacidad, el impacto ambiental y la salud de los usuarios.";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta10Item2() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0402</td>";
        co += "</tr>";

        co += "	<tr>";
        co += "<td>";
        co += "Identifico mis necesidades de desarrollo profesional para la innovación educativa con TIC";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta10Item3() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0403</td>";
        co += "</tr>";

        co += "		<tr>";
        co += "<td rowspan='4'>";
        co += "		4.2.  Integra las TIC en procesos de dinamización de las gestiones directiva, académica, administrativa y comunitaria de su institución.                                1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre";
        co += "</td>";
        co += "</tr>";

        co += "<tr>";
        co += "		<td>";
        co += "			Propongo y desarrollo procesos de mejoramiento y seguimiento del uso de TIC en la gestión escolar.";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta11Item1() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0404</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Adopto políticas escolares existentes para el uso de las TIC en mi institución que contemplan la privacidad, el impacto ambiental y la salud de los usuarios.";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta11Item2() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0405</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Selecciono y accedo a programas de formación, apropiados para mis necesidades de desarrollo profesional, para la innovación educativa con TIC.";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta11Item3() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0406</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='4'>";
        co += "4.3. Propone y lidera acciones para optimizar procesos integrados de   la gestión escolar.            1= Nunca;  2= Casi nunca; 3= Algunas veces; 4= Casi siempre; 5= Siempre";
        co += "	</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Evalúo los beneficios y utilidades de herramientas TIC en la gestión escolar y en la proyección del PEI dando respuesta a las necesidades de mi institución.";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta12Item3() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0407</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Desarrollo políticas escolares para el uso de las TIC en mi institución que contemplan la privacidad, el impacto ambiental y la salud de los usuarios.";
        co += "	</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta12Item2() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0408</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "		Dinamizo la formación de mis colegas y los apoyo para que integren las TIC de forma innovadora en sus prácticas pedagógicas.";
        co += "		</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta12Item3() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0409</td>";
        co += "		</tr>";

        co += "		<tr>";
        co += "<td rowspan='12'>";
        co += "		5. Investigativa       Capacidad de utilizar las TIC para la transformación del saber y la generación de nuevos conocimientos. ";
        co += "		</td>";
        co += "		<td rowspan='4'>";
        co += "		5.1. Usa las TIC para hacer registro y seguimiento de lo que vive y observa en su práctica, su contexto y el de sus estudiantes.   1= Nunca;  2= Casi nunca; 3= Algunas veces; 4= Casi siempre; 5= Siempre ";
        co += "		</td>";
        co += "		</tr>";

        co += "	<tr>";
        co += "<td>";
        co += "Documento observaciones de mi entorno y mi practica con el apoyo de TIC. ";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta13Item1() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0501</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Identifico redes, bases de datos y fuentes de información que facilitan mis procesos de investigación";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta13Item2() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0502</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Sé buscar, ordenar, filtrar, conectar y analizar información disponible en Internet.";
        co += "	</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta13Item3() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0503</td>";
        co += "</tr>";

        co += "<tr>";
        co += "	<td rowspan='4'>";
        co += "5.2. Lidera proyectos de investigación propia y con sus estudiantes.  1= Nunca;  2= Casi nunca; 3= Algunas veces; 4= Casi siempre; 5= Siempre";
        co += "	</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Represento e interpreto datos e información de mis investigaciones en diversos formatos digitales.";
        co += "		</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta14Item1() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0504</td>";
        co += "</tr>";

        co += "<tr>";
        co += "	<td>";
        co += "Utilizo redes profesionales y plataformas especializadas en el desarrollo de mis investigaciones.";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta14Item2() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0505</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Contrasto y analizo con mis estudiantes información proveniente de múltiples fuentes digitales.";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta14Item3() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0506</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='4'>";
        co += "5.3. Construye estrategias educativas innovadoras que incluyen la generación colectiva de conocimientos.              1= Nunca;  2= Casi nunca; 3= Algunas veces; 4= Casi siempre; 5= Siempre";
        co += "</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Divulgo los resultados de mis investigaciones utilizando las herramientas que me ofrecen las TIC.";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta15Item1() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0507</td>";
        co += "</tr>";

        co += "	<tr>";
        co += "<td>";
        co += "Participo activamente en redes y comunidades de práctica, para la construcción colectiva de conocimientos con estudiantes y colegas, con el apoyo de TIC";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta15Item2() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0508</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Utilizo la información disponible en Internet con una actitud crítica y reflexiva.";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta15Item3() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0509</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='6'>";
        co += "6. Eticas";

        co += "</td>";
        co += "<td rowspan='5'>";
        co += "6.1 Comprender las oportunidades, implicaciones y riesgos de la utilización de TIC para mi práctica docente y el desarrollo humano. 1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre";
        co += "</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Comprendo las posibilidades de las TIC para potenciar procesos de participación democrática";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta16Item1() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0601</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "		Identifico los riesgos de publicar y compartir distintos tipos de información a través de Internet";
        co += "		</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta16Item2() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0602</td>";
        co += "</tr>";

        co += "		<tr>";
        co += "<td>";
        co += "Utilizo las TIC teniendo en cuenta recomendaciones básicas de salud";
        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta16Item3() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0603</td>";
        co += "		</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Examino y aplico las normas de propiedad intelectual y licenciamiento existentes, referentes al uso de información ajena y propia";

        co += "</td>";
        co += "  <td>Promedio: <b>" + PromCalificacionIntrumento04Pregunta16Item4() + "</b></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0604</td>";
        co += "</tr>";


        co += "</table>";

        lblResultado04.Text = co;
    }

    private string NumSedesConAutopercepcion()
    {
        string co = "";
        LineaBase lb = new LineaBase();

        DataTable datos = lb.cargarRespuestasNumSedesInstrumento04GroupBY("4");

        if (datos != null && datos.Rows.Count > 0)
        {
            int cont = 0;
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                cont++;
            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocentesConAutopercepcion()
    {
        string co = "";
        LineaBase lb = new LineaBase();

        DataTable datos = lb.cargarRespuestasNumDocentesInstrumento04GroupBY("4");

        if (datos != null && datos.Rows.Count > 0)
        {
            int cont = 0;
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                cont++;
            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta1Item1()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "1", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            prom += Convert.ToInt32(datos.Rows[0]["respuesta"].ToString());
                            cont++;
                        }

                    }

                }
            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;

    }

    private string PromCalificacionIntrumento04Pregunta1Item2()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "1", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 1)
                        {
                            prom += Convert.ToInt32(datos.Rows[1]["respuesta"].ToString());
                            cont++;
                        }

                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta1Item3()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "1", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 2)
                        {
                            prom += Convert.ToInt32(datos.Rows[2]["respuesta"].ToString());
                            cont++;
                        }

                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta2Item1()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "2", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            prom += Convert.ToInt32(datos.Rows[0]["respuesta"].ToString());
                            cont++;
                        }

                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;

    }

    private string PromCalificacionIntrumento04Pregunta2Item2()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "2", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 1)
                        {
                            prom += Convert.ToInt32(datos.Rows[1]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta2Item3()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "2", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 2)
                        {
                            prom += Convert.ToInt32(datos.Rows[2]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta3Item1()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "3", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            prom += Convert.ToInt32(datos.Rows[0]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;

    }

    private string PromCalificacionIntrumento04Pregunta3Item2()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "3", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 1)
                        {
                            prom += Convert.ToInt32(datos.Rows[1]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta3Item3()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "3", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 2)
                        {
                            prom += Convert.ToInt32(datos.Rows[2]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta4Item1()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "4", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            prom += Convert.ToInt32(datos.Rows[0]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta4Item2()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "4", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 1)
                        {
                            prom += Convert.ToInt32(datos.Rows[1]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;

    }

    private string PromCalificacionIntrumento04Pregunta4Item3()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "4", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 2)
                        {
                            prom += Convert.ToInt32(datos.Rows[2]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;

    }

    private string PromCalificacionIntrumento04Pregunta5Item1()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "5", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            prom += Convert.ToInt32(datos.Rows[0]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;

    }

    private string PromCalificacionIntrumento04Pregunta5Item2()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "5", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 1)
                        {
                            prom += Convert.ToInt32(datos.Rows[1]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta5Item3()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "5", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 2)
                        {
                            prom += Convert.ToInt32(datos.Rows[2]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta6Item1()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "6", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            prom += Convert.ToInt32(datos.Rows[0]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta6Item2()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "6", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 1)
                        {
                            prom += Convert.ToInt32(datos.Rows[1]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta6Item3()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "6", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 2)
                        {
                            prom += Convert.ToInt32(datos.Rows[2]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta7Item1()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "7", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            prom += Convert.ToInt32(datos.Rows[0]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta7Item2()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "7", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 1)
                        {
                            prom += Convert.ToInt32(datos.Rows[1]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta7Item3()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "7", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 2)
                        {
                            prom += Convert.ToInt32(datos.Rows[2]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta8Item1()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "8", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            prom += Convert.ToInt32(datos.Rows[0]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta8Item2()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "8", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 1)
                        {
                            prom += Convert.ToInt32(datos.Rows[1]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta8Item3()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "8", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 2)
                        {
                            prom += Convert.ToInt32(datos.Rows[2]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta9Item1()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "9", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            prom += Convert.ToInt32(datos.Rows[0]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta9Item2()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "9", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 1)
                        {
                            prom += Convert.ToInt32(datos.Rows[1]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;

    }

    private string PromCalificacionIntrumento04Pregunta9Item3()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "9", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 2)
                        {
                            prom += Convert.ToInt32(datos.Rows[2]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta10Item1()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "10", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            prom += Convert.ToInt32(datos.Rows[0]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta10Item2()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "10", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 1)
                        {
                            prom += Convert.ToInt32(datos.Rows[1]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta10Item3()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "10", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 2)
                        {
                            prom += Convert.ToInt32(datos.Rows[2]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta11Item1()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "11", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            prom += Convert.ToInt32(datos.Rows[0]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta11Item2()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "11", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 1)
                        {
                            prom += Convert.ToInt32(datos.Rows[1]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta11Item3()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "11", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 2)
                        {
                            prom += Convert.ToInt32(datos.Rows[2]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta12Item1()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "12", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            prom += Convert.ToInt32(datos.Rows[0]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;

    }

    private string PromCalificacionIntrumento04Pregunta12Item2()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "12", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 1)
                        {
                            prom += Convert.ToInt32(datos.Rows[1]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta12Item3()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "12", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 2)
                        {
                            prom += Convert.ToInt32(datos.Rows[2]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta13Item1()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "13", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 1)
                        {
                            prom += Convert.ToInt32(datos.Rows[0]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }
            }

            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta13Item2()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "13", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 1)
                        {
                            prom += Convert.ToInt32(datos.Rows[1]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }
            }

            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta13Item3()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "13", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 2)
                        {
                            prom += Convert.ToInt32(datos.Rows[2]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta14Item1()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "14", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            prom += Convert.ToInt32(datos.Rows[0]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta14Item2()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "14", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 1)
                        {
                            prom += Convert.ToInt32(datos.Rows[1]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta14Item3()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "14", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 2)
                        {
                            prom += Convert.ToInt32(datos.Rows[2]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta15Item1()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "15", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            prom += Convert.ToInt32(datos.Rows[0]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta15Item2()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "15", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 1)
                        {
                            prom += Convert.ToInt32(datos.Rows[1]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta15Item3()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "15", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 2)
                        {
                            prom += Convert.ToInt32(datos.Rows[2]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;
    }

    private string PromCalificacionIntrumento04Pregunta16Item1()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "16", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            prom += Convert.ToInt32(datos.Rows[0]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;

    }

    private string PromCalificacionIntrumento04Pregunta16Item2()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "16", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 1)
                        {
                            prom += Convert.ToInt32(datos.Rows[1]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;

    }

    private string PromCalificacionIntrumento04Pregunta16Item3()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "16", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 2)
                        {
                            prom += Convert.ToInt32(datos.Rows[2]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;

    }

    private string PromCalificacionIntrumento04Pregunta16Item4()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "16", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 3)
                        {
                            prom += Convert.ToInt32(datos.Rows[3]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;

    }

    private string PromCalificacionIntrumento04Pregunta16Item5()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            double prom = 0;
            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "16", "0", "4");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 4)
                        {
                            prom += Convert.ToInt32(datos.Rows[4]["respuesta"].ToString());
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(Math.Round(prom / cont, 2));
        }

        return co;

    }

    /*  LINEA BASE, 05 - PERFIL DOCENTE  */

    private void cargarLineaBase05()
    {
        string co = "";
        co += "<h2 style='text-decoration: underline;'>Indicadores 05 - Perfil Docente</h2><br/>";
        co += "  <table class='mGridTesoreria'>";
        co += "     <tr>";
        co += "	  <thead>";
        co += "    <th>INSTRUMENTO</th>";
        co += "      <th colspan='3'>ITEM DEL INSTRUMENTO</th>";
        co += "<th>INDICADOR/ES RELACIONADO/S/LINEA BASE</th>";
        co += "<th>CÓDIGO ACTIVIDAD</th>";
        co += "      <th>CÓDIGO INDICADOR</th>";
        co += "</thead>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='114'>";
        co += "Intrumento No. 5: Perfil, formación y experiencia de los/las docentes vinculados al proyecto  en NTICs, CTeI e investigación Perfil, formación y experiencia de los/las docentes vinculados al proyecto  en NTICs, CTeI e investigación";
        co += "</td>";
        co += "<td rowspan='2'>Identificación</td>";
        co += "<td colspan='2'>Institución/Sede </td>";
        co += "<td>Total de sedes educativas con información sobre perfil de los docentes del Programa Ciclón: <b>" + NumSedesConPerfilDocente() + "</b></td>";
        co += "		<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'> Del/la docente</td>";
        co += "<td>Total de docentes con información sobre su perfil en TIC, e investigación: <b>" + NumDocentesConPerfilDocente() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "	 <td rowspan='12'>";
        co += "1. CLASE DE FUNCIONARIO";
        co += "</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'> Directivo docente</td>";
        co += "<td>Total: <b>" + NumDocentesDirectivoDocente() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6A03PD0101</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'> Docentes (no incluya educadorese speciales ni etnoeducadores)</td>";
        co += "<td>Total: <b>" + NumDocentesNoIncluyeEducadores() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6A03PD0102</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'>Docentes de educación especial</td>";
        co += "<td>Total: <b>" + NumDocentesEducacionEspecial() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6A03PD0103</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'>Docentes de etnoeducación</td>";
        co += "<td>Total: <b>" + NumDocentesEtnoeducacion() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6A03PD0104</td>";
        co += "</tr>";

        co += "<tr>";
        co += "	 <td colspan='2'>Consejeros escolares, capellanes, orientadores, sicólogos y trabajadores sociales</td>";
        co += "<td>Total: <b>" + NumDocentesConsejerosEspeciales() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6A03PD0105</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'> Médicos, odontólogos, nutricionistas, terapeutas y enfermeros</td>";
        co += "<td>Total: <b>" + NumDocentesMedicosOdontologicos() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6A03PD0106</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'> Administrativos (de apoyo y personal de servicios generales)</td>";
        co += "<td>Total: <b>" + NumDocentesAdministrativos() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "	 <td>E6A03PD0107</td>";
        co += "	 </tr>";

        co += "	  <tr>";
        co += "<td colspan='2'> Profesionales de apoyo en el aula para estudiantes con discapacidad o capacidades excepcionales</td>";
        co += "<td>Total: <b>" + NumDocentesProfesionales() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6A03PD0108</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'> Tutores</td>";
        co += "<td>Total: <b>" + NumDocentesTutores() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6A03PD0109</td>";
        co += "</tr>";

        co += "	  <tr>";
        co += "	 <td colspan='2'> Directivos (rectores, directores, coordinadores, supervisores, secretarios académicos)</td>";
        co += "<td>Total: <b>" + NumDocentesDirectivos() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6A03PD010</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'> Auxiliar de aula</td>";
        co += "<td>Total: <b>" + NumDocentesAuxiliar() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6A03PD0111</td>";
        co += "</tr>";

        co += "	   <tr>";
        co += "<td rowspan='12'>";
        co += "2. Último nivel de formación obtenido";
        co += "	 </td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'> Bachillerato pedagógico </td>";
        co += "<td>Total: <b>" + NumDocenteNivelBachilleratoPedagogico() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0201</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'> Normalista Superior</td>";
        co += "<td>Total: <b>" + NumDocentesNormalistaSuperior() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0203</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'> Otro bachillerato</td>";
        co += "<td>Total: <b>" + NumDocentesOtroBachillerato() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0204</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'> Técnico o tecnológico </td>";
        co += "<td>Total: <b>" + NumDocentesTecnico() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0206</td>";
        co += "	 </tr>";

        co += "<tr>";
        co += "<td colspan='2'> Otro Técnico o tecnológico</td>";
        co += "<td>Total: <b>" + NumDocentesOtroTecnico() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0207</td>";
        co += "		 </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Profesional pedagógico</td>";
        co += "<td>Total: <b>" + NumDocentesProfesionalPedagogico() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0209</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'>Otro profesional</td>";
        co += "<td>Total: <b>" + NumDocentesOtroProfesionalPedagogico() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0210</td>";
        co += "</tr>";

        co += "<tr>";
        co += " <td colspan='2'>Maestría en educación o pedagogía</td>";
        co += "<td>Total: <b>" + NumDocentesMaestria() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0212</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'>Otra Maestría </td>";
        co += "<td>Total: <b>" + NumDocentesOtraMaestria() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0213</td>";
        co += "</tr>";

        co += "  <tr>";
        co += "	 <td colspan='2'>Doctorado en educación o pedagogía</td>";
        co += "<td>Total: <b>" + NumDocentesDoctorado() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0215</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'>Otro doctorado</td>";
        co += "<td>Total: <b>" + NumDocentesOtroDoctorado() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0216</td>";
        co += "</tr>";

        //co += "	  <tr>";
        //co += "<td colspan='2'>Año profesional pedagógico</td>";
        //co += "<td>Total: <b></b></td>";
        //co += "<td>E6A03</td>";
        //co += "<td>E6AA03PD0218</td>";
        //co += "</tr>";

        //co += "<tr>";
        //co += "<td >Nivel otro profesional</td>";
        //co += "<td></td>";
        //co += "<td>Total: <b></b></td>";
        //co += "<td>E6A03</td>";
        //co += "<td>E6AA03PD0219</td>";
        //co += "	 </tr>";

        //co += "<tr>";
        //co += "<td >Año otro profesional</td>";
        //co += "<td></td>";
        //co += "<td>Total: <b></b></td>";
        //co += "<td>E6A03</td>";
        //co += "<td>E6AA03PD0221</td>";
        //co += "</tr>";

        //co += "<tr>";
        //co += "<td >Nivel maestría en educación</td>";
        //co += "<td></td>";
        //co += "<td>Total: <b></b></td>";
        //co += "<td>E6A03</td>";
        //co += "<td>E6AA03PD0222</td>";
        //co += " </tr>";

        //co += "<tr>";
        //co += "<td colspan='2'>Año Maestría en educación</td>";
        //co += "<td>Total: <b></b></td>";
        //co += "<td>E6A03</td>";
        //co += "<td>E6AA03PD0224</td>";
        //co += " </tr>";

        //co += "<tr>";
        //co += "<td colspan='2'>Nivel otra maestría</td>";
        //co += "<td>Total: <b></b></td>";
        //co += "<td>E6A03</td>";
        //co += "<td>E6AA03PD0225</td>";
        //co += " </tr>";

        //co += "<tr>";
        //co += "<td colspan='2'>Año  otra maestría</td>";
        //co += "<td>Total: <b></b></td>";
        //co += "<td>E6A03</td>";
        //co += "<td>E6AA03PD0227</td>";
        //co += " </tr>";

        //co += "<tr>";
        //co += "<td colspan='2'>Nivel doctorado en educación o pedagógia</td>";
        //co += "<td>Total: <b></b></td>";
        //co += "<td>E6A03</td>";
        //co += "<td>E6AA03PD0228</td>";
        //co += " </tr>";

        //co += "<tr>";
        //co += "<td colspan='2'>Año doctorado en educación o pedagogía</td>";
        //co += "<td>Total: <b></b></td>";
        //co += "<td>E6A03</td>";
        //co += "<td>E6AA03PD0230</td>";
        //co += " </tr>";

        //co += "<tr>";
        //co += "<td colspan='2'>Nivel otro doctorado</td>";
        //co += "<td>Total: <b></b></td>";
        //co += "<td>E6A03</td>";
        //co += "<td>E6AA03PD0231</td>";
        //co += " </tr>";

        //co += "<tr>";
        //co += "<td >Año otro doctorado</td>";
        //co += "<td></td>";
        //co += "<td>Total: <b></b></td>";
        //co += "<td>E6A03</td>";
        //co += "<td>E6AA03PD0233</td>";
        //co += " </tr>";

        co += "<tr>";
        co += "<td rowspan='4'>";
        co += "3.Nivel educativo en el que trabaja";
        co += "</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'>Preescolar</td>";
        co += "<td >Total: <b>" + NumDocentesPreescolar() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0301</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Básica Primaria</td>";
        co += "<td >Total: <b>" + NumDocentesPrimaria() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0302</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Básica Secundaria y Media    </td>";
        co += "<td >Total: <b>" + NumDocentesSecundaria() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0303</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td rowspan='8'>";
        co += "4. Áreas de enseñanza en las que desarrolla la docencia</td>";
        co += "<td colspan='2'>Carecter Académico</td>";
        co += "<td>Total docentes participantes en el Programa CICLÓN, según el área de enseñanza en la que desarrolla la docencia para el Carácter Académico: <b>" + NumDocentesCaracterAcademico() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0401</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='7' colspan='2'>Carácter técnico</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td>Total docentes participantes en el Programa CICLÓN, según el área de enseñanza en que desarrolla la docencia para el carácter técnico: <b>" + NumDocentesCaracterTecnico() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0402</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>Otra cual especialidad industrial: <b>" + NumDocentesIndustrial() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0403</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>Otra cual especialidad Pedagógica: <b>" + NumDocentesEspcialidadPedagogica() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0404</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>Otra cual especialidad Promoción social: <b>" + NumDocentesPromocionSocial() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0405</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>Otra cuál especialidad informática: <b>" + NumDocentesInformatica() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0406</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>Otra, ¿cuál? Espécialidad: <b>" + NumDocentesOtraCualIntrumento05() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0407</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='17'>";
        co += "5. Ha recibido formación específica investigación?";
        co += "</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'>Tipo 1</td>";
        co += "<td>" + NumDocentesFormacionInvestigacionDuracionHoras() + "</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0501</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>nombre 1</td>";
        co += "<td></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0502</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Duración (horas)1</td>";
        co += "<td></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0503</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Año 1</td>";
        co += "<td></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0504</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Modalidad 1</td>";
        co += "<td></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0505</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Tipo 2</td>";
        co += "<td></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0506</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>nombre 2</td>";
        co += "<td></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0507</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Duración (horas)2</td>";
        co += "<td></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0508</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Año 2</td>";
        co += "<td></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0509</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Modalidad 2</td>";
        co += "<td></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0510</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Tipo 3</td>";
        co += "<td></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0511</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>nombre 3</td>";
        co += "<td></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0512</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Duración (horas)3</td>";
        co += "<td></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0513</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Año 3</td>";
        co += "<td></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0514</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Modalidad 3</td>";
        co += "<td></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0515</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Esta formación contribuyó a cambiar sus prácticas pedagógicas?  SI-Cómo/NO</td>";
        co += "<td></td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0516</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td rowspan='6'>";
        co += "6. Ha participado en proyecto de investigación dentro de la Institución Educativa  ";
        co += "</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'>SI/NO </td>";
        co += "<td >Total de docentes participantes en el Programa CICLÓN  que han participado en proyectos de investigación dentro de la institución educativa: " + NumDocentesProyectoInvestigacion() + "</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0601</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Cuáles</td>";
        co += "<td>" + NumDocentesProyectoInvestigacionCuales() + "</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0602</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>De aula</td>";
        co += "<td>" + NumDocentesProyectoInvestigacionAula() + "</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0603</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Transversales</td>";
        co += "<td>" + NumDocentesProyectoInvestigacionTransversales() + "</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0604</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Interdisciplinarios</td>";
        co += "<td>" + NumDocentesProyectoInvestigacionInterdisciplinarios() + "</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0605</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td rowspan='2'>";
        co += "7. Ha participado en proyecto de investigación Fuera de la Institución Educativa";
        co += "</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'>SI/NO Cuáles</td>";
        co += "<td>Total de docentes participantes en el Programa CICLÓN  que han participado en proyectos de investigación fuera de la institución educativa:" + NumDocentesProyectoInvestigacionFueraInstitucion() + "</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0701</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='6'>";
        co += "8. Ha Realizado proyecto e investigación con niños, Niñas y  Jóvenes como práctica pedagógica?";
        co += "</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'>SI/NO </td>";
        co += "<td rowspan='6'>Total de docentes participantes en el Programa CICLÓN  que han realizado proyectos de investigación con niños/as y jóvenes como práctica pedagógica" + NumDocentesProyectoInvestigacionNinosyNinias() + "</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0801</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Cuáles</td>";
        co += "<td>" + NumDocentesProyectoInvestigacionCualesNinosyNinias() + "</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0602</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>De aula</td>";
        co += "<td>" + NumDocentesProyectoInvestigacionAulaNinosyNinias() + "</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0603</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Transversales</td>";
        co += "<td>" + NumDocentesProyectoInvestigacionTransversalesNinosyNinias() + "</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0604</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Interdisciplinarios</td>";
        co += "<td>" + NumDocentesProyectoInvestigacionInterdisciplinariosNinosyNinias() + "</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0605</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td rowspan='17'>";
        co += "9. Ha recibido formación específica en Ciencia, Tecnología e Innovación?";
        co += "</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'>Tipo 1</td>";
        co += "<td rowspan='17'>Total de docentes participantes en el Programa CICLÓN que han recibido formación específica en CTeI, según tipo de curso.</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0901</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>nombre 1</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0902</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Duración (horas)1</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0903</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Año 1</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0904</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Modalidad 1</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0905</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Tipo 2</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0906</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>nombre 2</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0907</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Duración (horas)2</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0908</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Año 2</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0909</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Modalidad 2</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0910</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Tipo 3</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0911</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>nombre 3</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0912</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Duración (horas)3</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0913</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Año 3</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0914</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Modalidad 3</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0915</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Esta formación contribuyó a cambiar sus prácticas pedagógicas?  SI-Cómo/NO</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD0916</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td rowspan='17'>";
        co += "10. Ha recibido formación específica en TICs?";
        co += "</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'>Tipo 1</td>";
        co += "<td rowspan='15'>Total de docentes participantes en el Programa CICLÓN que han recibido formación específica en TIC según tipo.</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD1001</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>nombre 1</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD1002</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Duración (horas)1</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD1003</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Año 1</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD1004</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Modalidad 1</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD1005</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Tipo 2</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD1006</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>nombre 2</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD1007</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Duración (horas)2</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD1008</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Año 2</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD1009</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Modalidad 2</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD1010</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Tipo 3</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD1011</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>nombre 3</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD1012</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Duración (horas)3</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD1013</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Año 3</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD1014</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Modalidad 3</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD1015</td>";
        co += " </tr>";

        co += "<tr>";
        co += "<td colspan='2'>Esta formación contribuyó a cambiar sus prácticas pedagógicas?  SI-Cómo/NO</td>";
        co += "<td>Total de docentes participantes en el Programa CICLÓN que perciben que la formación en TIC contribuyó a cambiar sus prácticas pedagógicas.</td>";
        co += "<td>E6A03</td>";
        co += "<td>E6AA03PD1016</td>";
        co += " </tr>";

        co += "</table>";

        lblResultado05.Text = co;
    }

    private string NumSedesConPerfilDocente()
    {
        string co = "";
        LineaBase lb = new LineaBase();

        DataTable datos = lb.cargarRespuestasNumSedesInstrumento04GroupBY("5");

        if (datos != null && datos.Rows.Count > 0)
        {
            int cont = 0;
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                cont++;
            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocentesConPerfilDocente()
    {
        string co = "";
        LineaBase lb = new LineaBase();

        DataTable datos = lb.cargarRespuestasNumDocentesInstrumento04GroupBY("5");

        if (datos != null && datos.Rows.Count > 0)
        {
            int cont = 0;
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                cont++;
            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocentesDirectivoDocente()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "1", "0", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (datos.Rows[i]["respuesta"].ToString() == "Directivo Docente")
                        {
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocentesNoIncluyeEducadores()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "1", "0", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (datos.Rows[i]["respuesta"].ToString() == "Docentes (no incluya educadores especiales ni etnoeducadores)")
                        {
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocentesEducacionEspecial()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "1", "0", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (datos.Rows[i]["respuesta"].ToString() == "Docentes de educación especial")
                        {
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocentesEtnoeducacion()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "1", "0", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (datos.Rows[i]["respuesta"].ToString() == "Docentes de etnoeducación")
                        {
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocentesConsejerosEspeciales()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "1", "0", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (datos.Rows[i]["respuesta"].ToString() == "Consejeros escolares, capellanes, orientadores, sicólogos y trabajadores sociales")
                        {
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocentesMedicosOdontologicos()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "1", "0", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (datos.Rows[i]["respuesta"].ToString() == "Médicos, odontólogos, nutricionistas, terapeutas y enfermeros")
                        {
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocentesAdministrativos()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "1", "0", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (datos.Rows[i]["respuesta"].ToString() == "Administrativos (de apoyo y personal de servicios generales)")
                        {
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocentesProfesionales()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "1", "0", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (datos.Rows[i]["respuesta"].ToString() == "Profesionales de apoyo en el aula para estudiantes con discapacidad o capacidades excepcionales (intérpretes, tiflólogos, etc.)")
                        {
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocentesTutores()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "1", "0", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (datos.Rows[i]["respuesta"].ToString() == "Tutores")
                        {
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocentesDirectivos()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "1", "0", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (datos.Rows[i]["respuesta"].ToString() == "Directivos (rectores, directores, coordinadores, supervisores, secretarios académicos)")
                        {
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocentesAuxiliar()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "1", "0", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (datos.Rows[i]["respuesta"].ToString() == "Auxiliar de aula")
                        {
                            cont++;
                        }
                    }

                }

            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocenteNivelBachilleratoPedagogico()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "2", "0", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            if (datos.Rows[0]["respuesta"].ToString() != "")
                            {
                                cont++;
                            }
                        }

                    }

                }

            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocentesNormalistaSuperior()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "2", "0", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 1)
                        {
                            if (datos.Rows[1]["respuesta"].ToString() != "")
                            {
                                cont++;
                            }
                        }

                    }

                }

            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocentesOtroBachillerato()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "2", "0", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 2)
                        {
                            if (datos.Rows[2]["respuesta"].ToString() != "")
                            {
                                cont++;
                            }
                        }

                    }

                }

            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocentesTecnico()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "2", "0", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 3)
                        {
                            if (datos.Rows[3]["respuesta"].ToString() != "")
                            {
                                cont++;
                            }
                        }

                    }

                }

            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocentesOtroTecnico()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "2", "0", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 4)
                        {
                            if (datos.Rows[4]["respuesta"].ToString() != "")
                            {
                                cont++;
                            }
                        }

                    }

                }

            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocentesProfesionalPedagogico()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "2", "0", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 5)
                        {
                            if (datos.Rows[5]["respuesta"].ToString() != "")
                            {
                                cont++;
                            }
                        }

                    }

                }

            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocentesOtroProfesionalPedagogico()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "2", "0", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 6)
                        {
                            if (datos.Rows[6]["respuesta"].ToString() != "")
                            {
                                cont++;
                            }
                        }

                    }

                }

            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocentesMaestria()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "2", "0", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 7)
                        {
                            if (datos.Rows[7]["respuesta"].ToString() != "")
                            {
                                cont++;
                            }
                        }

                    }

                }

            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocentesOtraMaestria()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "2", "0", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 8)
                        {
                            if (datos.Rows[8]["respuesta"].ToString() != "")
                            {
                                cont++;
                            }
                        }

                    }

                }

            }
            co = Convert.ToString(cont);
        }

        return co;
    }


    private string NumDocentesDoctorado()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "2", "0", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 9)
                        {
                            if (datos.Rows[9]["respuesta"].ToString() != "")
                            {
                                cont++;
                            }
                        }

                    }

                }

            }
            co = Convert.ToString(cont);
        }

        return co;
    }
    private string NumDocentesOtroDoctorado()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "2", "0", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (i == 10)
                        {
                            if (datos.Rows[10]["respuesta"].ToString() != "")
                            {
                                cont++;
                            }
                        }

                    }

                }

            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocentesPreescolar()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "3", "0", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (datos.Rows[i]["respuesta"].ToString() == "Preescolar")
                        {
                            cont++;
                        }

                    }

                }

            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocentesPrimaria()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "3", "0", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (datos.Rows[i]["respuesta"].ToString() == "Básica Primaria")
                        {
                            cont++;
                        }

                    }

                }

            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocentesSecundaria()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "3", "0", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (datos.Rows[i]["respuesta"].ToString() == "Básica Secundaria y Media")
                        {
                            cont++;
                        }

                    }

                }

            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocentesCaracterAcademico()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "4", "1", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (datos.Rows[i]["respuesta"].ToString() == "Todas las áreas" || datos.Rows[i]["respuesta"].ToString() == "Ciencias naturales y educación ambiental" || datos.Rows[i]["respuesta"].ToString() == "Ciencias sociales, historia, geografía, constitución política y democracia" || datos.Rows[i]["respuesta"].ToString() == "Educación artística" || datos.Rows[i]["respuesta"].ToString() == "Educación ética y en valores humanos" || datos.Rows[i]["respuesta"].ToString() == "Educación física, recreación y deportes" || datos.Rows[i]["respuesta"].ToString() == "Educación religiosa" || datos.Rows[i]["respuesta"].ToString() == "Humanidades, lengua castellana e idiomas extranjeros" || datos.Rows[i]["respuesta"].ToString() == "Matemáticas" || datos.Rows[i]["respuesta"].ToString() == "Tecnología e informática" || datos.Rows[i]["respuesta"].ToString() == "Ciencias económicas" || datos.Rows[i]["respuesta"].ToString() == "Ciencias políticas" || datos.Rows[i]["respuesta"].ToString() == "Filosofía" || datos.Rows[i]["respuesta"].ToString() == "Otra, ¿cuál?")
                        {
                            cont++;
                        }

                    }

                }

            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumDocentesCaracterTecnico()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        double total = 0;

        if (sede != null && sede.Rows.Count > 0)
        {

            double cont = 0;
            double cont2 = 0;

            for (int j = 0; j < sede.Rows.Count; j++)
            {

                DataTable datos = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "4", "2", "5");

                if (datos != null && datos.Rows.Count > 0)
                {

                    for (int i = 0; i < datos.Rows.Count; i++)
                    {
                        if (datos.Rows[i]["respuesta"].ToString() == "Agrícola" || datos.Rows[i]["respuesta"].ToString() == "Pecuario" || datos.Rows[i]["respuesta"].ToString() == "Otra ¿cuál?")
                        {
                            cont++;
                        }

                    }

                }

                DataTable datos2 = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "4", "3", "5");

                if (datos2 != null && datos2.Rows.Count > 0)
                {

                    for (int i = 0; i < datos2.Rows.Count; i++)
                    {
                        if (datos2.Rows[i]["respuesta"].ToString() == "Contabilidad" || datos2.Rows[i]["respuesta"].ToString() == "Finanzas" || datos2.Rows[i]["respuesta"].ToString() == "Gestión" || datos2.Rows[i]["respuesta"].ToString() == "Gestión" || datos2.Rows[i]["respuesta"].ToString() == "Administración" || datos2.Rows[i]["respuesta"].ToString() == "Ambiental" || datos2.Rows[i]["respuesta"].ToString() == "Salud" || datos2.Rows[i]["respuesta"].ToString() == "Otra ¿cuál?")
                        {
                            cont2++;
                        }

                    }

                }



                total = cont + cont2;

            }
            co = Convert.ToString(total);
        }

        return co;
    }

    private string NumDocentesIndustrial()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();
        double cont3 = 0;

        if (sede != null && sede.Rows.Count > 0)
        {
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos3 = lb.cargarRespuestasDePreguntasInstrumento04(sede.Rows[j]["codigo"].ToString(), "4", "4", "5");

                if (datos3 != null && datos3.Rows.Count > 0)
                {

                    for (int i = 0; i < datos3.Rows.Count; i++)
                    {
                        if (datos3.Rows[i]["respuesta"].ToString() == "Electricidad" || datos3.Rows[i]["respuesta"].ToString() == "Electrónica" || datos3.Rows[i]["respuesta"].ToString() == "Mecánica industrial" || datos3.Rows[i]["respuesta"].ToString() == "Mecánica automotriz" || datos3.Rows[i]["respuesta"].ToString() == "Metalistería" || datos3.Rows[i]["respuesta"].ToString() == "Metalmecánica" || datos3.Rows[i]["respuesta"].ToString() == "Ebanistería" || datos3.Rows[i]["respuesta"].ToString() == "Fundición" || datos3.Rows[i]["respuesta"].ToString() == "Construcciones civiles" || datos3.Rows[i]["respuesta"].ToString() == "Diseño mecánico" || datos3.Rows[i]["respuesta"].ToString() == "Diseño gráfico" || datos3.Rows[i]["respuesta"].ToString() == "Diseño arquitectónico" || datos3.Rows[i]["respuesta"].ToString() == "Otra ¿cuál?")
                        {
                            cont3++;
                        }

                    }

                }
            }
        }

        co = Convert.ToString(cont3);


        return co;
    }

    private string NumDocentesEspcialidadPedagogica()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();
        double cont3 = 0;

        if (sede != null && sede.Rows.Count > 0)
        {
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos3 = lb.cargarRespuestasCerradasInstrumento06(sede.Rows[j]["codigo"].ToString(), "4.5", "5");

                if (datos3 != null && datos3.Rows.Count > 0)
                {

                    cont3++;

                }
            }
        }

        co = Convert.ToString(cont3);


        return co;
    }

    private string NumDocentesPromocionSocial()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();
        double cont3 = 0;

        if (sede != null && sede.Rows.Count > 0)
        {
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos3 = lb.cargarRespuestasCerradasInstrumento06(sede.Rows[j]["codigo"].ToString(), "4.6", "5");

                if (datos3 != null && datos3.Rows.Count > 0)
                {

                    cont3++;

                }
            }
        }

        co = Convert.ToString(cont3);


        return co;
    }

    private string NumDocentesInformatica()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();
        double cont3 = 0;

        if (sede != null && sede.Rows.Count > 0)
        {
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos3 = lb.cargarRespuestasCerradasInstrumento06(sede.Rows[j]["codigo"].ToString(), "4.7", "5");

                if (datos3 != null && datos3.Rows.Count > 0)
                {

                    cont3++;

                }
            }
        }

        co = Convert.ToString(cont3);


        return co;
    }

    private string NumDocentesOtraCualIntrumento05()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();
        double cont3 = 0;

        if (sede != null && sede.Rows.Count > 0)
        {
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos3 = lb.cargarRespuestasCerradasInstrumento06(sede.Rows[j]["codigo"].ToString(), "4.8", "5");

                if (datos3 != null && datos3.Rows.Count > 0)
                {

                    cont3++;

                }
            }
        }

        co = Convert.ToString(cont3);


        return co;
    }

    private string NumDocentesFormacionInvestigacion()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();
        double cursocorto = 0;
        double Diplomado = 0;
        double Especializacion = 0;
        double Pregrado = 0;
        double MaestriayDoctorado = 0;

        if (sede != null && sede.Rows.Count > 0)
        {
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos3 = lb.cargarFormacionPerfilDocente(sede.Rows[j]["codigo"].ToString(), "5", "5");

                if (datos3 != null && datos3.Rows.Count > 0)
                {
                    for (int i = 0; i < datos3.Rows.Count; i++)
                    {
                        if (datos3.Rows[i]["tipo"].ToString() == "Curso Corto")
                            cursocorto++;
                        else if (datos3.Rows[i]["tipo"].ToString() == "Diplomado")
                            Diplomado++;
                        else if (datos3.Rows[i]["tipo"].ToString() == "Especialización")
                            Especializacion++;
                        else if (datos3.Rows[i]["tipo"].ToString() == "Pregrado")
                            Pregrado++;
                        else if (datos3.Rows[i]["tipo"].ToString() == "Maestría y Doctorado")
                            MaestriayDoctorado++;
                    }

                }
            }
        }

        co = Convert.ToString("<b>Curso Corto:</b> " + cursocorto + "<br/><b>Diplomado:</b> " + Diplomado + "<br/><b>Especialización:</b> " + Especializacion + "<br/><b>Pregrado:</b> " + Pregrado + "<br/><b>Maestría y Doctorado:</b> " + MaestriayDoctorado + "<br/>");


        return co;
    }

    private string NumDocentesFormacionInvestigacionDuracionHoras()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();
        double cursocorto = 0;
        double Diplomado = 0;
        double Especializacion = 0;
        double Pregrado = 0;
        double MaestriayDoctorado = 0;
        double NA = 0;

        if (sede != null && sede.Rows.Count > 0)
        {
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos3 = lb.cargarFormacionPerfilDocente(sede.Rows[j]["codigo"].ToString(), "5", "5");
                int Validate = 0;
                if (datos3 != null && datos3.Rows.Count > 0)
                {
                    for (int i = 0; i < datos3.Rows.Count; i++)
                    {
                        if (datos3.Rows[i]["tipo"].ToString() == "Curso Corto")
                            cursocorto++;
                        else if (datos3.Rows[i]["tipo"].ToString() == "Diplomado")
                            Diplomado++;
                        else if (datos3.Rows[i]["tipo"].ToString() == "Especialización")
                            Especializacion++;
                        else if (datos3.Rows[i]["tipo"].ToString() == "Pregrado")
                            Pregrado++;
                        else if (datos3.Rows[i]["tipo"].ToString() == "Maestría y Doctorado")
                            MaestriayDoctorado++;
                        else if (datos3.Rows[i]["tipo"].ToString() == "N/A")
                        {
                            if (Validate == 0)
                            {
                                NA++;
                                Validate = 1;
                            }

                        }

                    }

                }
            }
        }

        co = Convert.ToString("<br/><b>Curso Corto:</b> " + cursocorto + "<br/><b>Diplomado:</b> " + Diplomado + "<br/><b>Especialización:</b> " + Especializacion + "<br/><b>Pregrado:</b> " + Pregrado + "<br/><b>Maestría y Doctorado:</b> " + MaestriayDoctorado + "<br/>" + "<b>N/A:</b> " + NA);


        return co;
    }

    private string NumDocentesProyectoInvestigacion()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();
        double si = 0;
        double no = 0;

        if (sede != null && sede.Rows.Count > 0)
        {
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos3 = lb.cargarRespuestasCerradasxInstrumento05(sede.Rows[j]["codigo"].ToString(), "6", "0", "5");
                if (datos3 != null && datos3.Rows.Count > 0)
                {
                    for (int i = 0; i < datos3.Rows.Count; i++)
                    {
                        if (datos3.Rows[i]["respuesta"].ToString() == "Si")
                            si++;
                        else
                            no++;
                    }

                }
            }
        }

        co = Convert.ToString("<b>Si:</b> " + si + "<br/><b>No:</b> " + no);


        return co;
    }

    private string NumDocentesProyectoInvestigacionCuales()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataRow datos3 = lb.cargarRespuestasAbiertasxIntrumento05(sede.Rows[j]["codigo"].ToString(), "6", "5");
                if (datos3 != null)
                {
                    if (datos3["comentario"].ToString() != "")
                        co += datos3["comentario"].ToString() + "<br/>";
                }
            }
        }


        return co;
    }

    private string NumDocentesProyectoInvestigacionAula()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();
        double cont = 0;


        if (sede != null && sede.Rows.Count > 0)
        {
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos3 = lb.cargarRespuestasCerradasxInstrumento05(sede.Rows[j]["codigo"].ToString(), "6", "1", "5");
                if (datos3 != null && datos3.Rows.Count > 0)
                {
                    for (int i = 0; i < datos3.Rows.Count; i++)
                    {
                        if (datos3.Rows[i]["respuesta"].ToString() == "Aula")
                            cont++;
                    }

                }
            }
        }

        co = Convert.ToString("Total: <b>" + cont + "</b>");


        return co;
    }

    private string NumDocentesProyectoInvestigacionTransversales()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();
        double cont = 0;


        if (sede != null && sede.Rows.Count > 0)
        {
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos3 = lb.cargarRespuestasCerradasxInstrumento05(sede.Rows[j]["codigo"].ToString(), "6", "2", "5");
                if (datos3 != null && datos3.Rows.Count > 0)
                {
                    for (int i = 0; i < datos3.Rows.Count; i++)
                    {
                        if (datos3.Rows[i]["respuesta"].ToString() == "Aula")
                            cont++;
                    }

                }
            }
        }

        co = Convert.ToString("Total: <b>" + cont + "</b>");


        return co;
    }

    private string NumDocentesProyectoInvestigacionInterdisciplinarios()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();
        double cont = 0;


        if (sede != null && sede.Rows.Count > 0)
        {
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos3 = lb.cargarRespuestasCerradasxInstrumento05(sede.Rows[j]["codigo"].ToString(), "6", "3", "5");
                if (datos3 != null && datos3.Rows.Count > 0)
                {
                    for (int i = 0; i < datos3.Rows.Count; i++)
                    {
                        if (datos3.Rows[i]["respuesta"].ToString() == "Aula")
                            cont++;
                    }

                }
            }
        }

        co = Convert.ToString("Total: <b>" + cont + "</b>");


        return co;
    }

    private string NumDocentesProyectoInvestigacionFueraInstitucion()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();
        double si = 0;
        double no = 0;

        if (sede != null && sede.Rows.Count > 0)
        {
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos3 = lb.cargarRespuestasCerradasxInstrumento05(sede.Rows[j]["codigo"].ToString(), "7", "0", "5");
                if (datos3 != null && datos3.Rows.Count > 0)
                {
                    for (int i = 0; i < datos3.Rows.Count; i++)
                    {
                        if (datos3.Rows[i]["respuesta"].ToString() == "Si")
                            si++;
                        else
                            no++;
                    }

                }
            }
        }

        co = Convert.ToString("<b>Si:</b> " + si + "<br/><b>No:</b> " + no);


        return co;
    }

    private string NumDocentesProyectoInvestigacionNinosyNinias()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();
        double si = 0;
        double no = 0;

        if (sede != null && sede.Rows.Count > 0)
        {
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos3 = lb.cargarRespuestasCerradasxInstrumento05(sede.Rows[j]["codigo"].ToString(), "8", "0", "5");
                if (datos3 != null && datos3.Rows.Count > 0)
                {
                    for (int i = 0; i < datos3.Rows.Count; i++)
                    {
                        if (datos3.Rows[i]["respuesta"].ToString() == "Si")
                            si++;
                        else
                            no++;
                    }

                }
            }
        }

        co = Convert.ToString("<b>Si:</b> " + si + "<br/><b>No:</b> " + no);


        return co;
    }

    private string NumDocentesProyectoInvestigacionCualesNinosyNinias()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();

        if (sede != null && sede.Rows.Count > 0)
        {
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataRow datos3 = lb.cargarRespuestasAbiertasxIntrumento05(sede.Rows[j]["codigo"].ToString(), "8", "5");
                if (datos3 != null)
                {
                    if (datos3["comentario"].ToString() != "")
                        co += datos3["comentario"].ToString() + "<br/>";
                }
            }
        }


        return co;
    }

    private string NumDocentesProyectoInvestigacionAulaNinosyNinias()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();
        double cont = 0;


        if (sede != null && sede.Rows.Count > 0)
        {
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos3 = lb.cargarRespuestasCerradasxInstrumento05(sede.Rows[j]["codigo"].ToString(), "8", "1", "5");
                if (datos3 != null && datos3.Rows.Count > 0)
                {
                    for (int i = 0; i < datos3.Rows.Count; i++)
                    {
                        if (datos3.Rows[i]["respuesta"].ToString() == "Aula")
                            cont++;
                    }

                }
            }
        }

        co = Convert.ToString("Total: <b>" + cont + "</b>");


        return co;
    }

    private string NumDocentesProyectoInvestigacionTransversalesNinosyNinias()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();
        double cont = 0;


        if (sede != null && sede.Rows.Count > 0)
        {
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos3 = lb.cargarRespuestasCerradasxInstrumento05(sede.Rows[j]["codigo"].ToString(), "8", "2", "5");
                if (datos3 != null && datos3.Rows.Count > 0)
                {
                    for (int i = 0; i < datos3.Rows.Count; i++)
                    {
                        if (datos3.Rows[i]["respuesta"].ToString() == "Aula")
                            cont++;
                    }

                }
            }
        }

        co = Convert.ToString("Total: <b>" + cont + "</b>");


        return co;
    }

    private string NumDocentesProyectoInvestigacionInterdisciplinariosNinosyNinias()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();
        double cont = 0;


        if (sede != null && sede.Rows.Count > 0)
        {
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataTable datos3 = lb.cargarRespuestasCerradasxInstrumento05(sede.Rows[j]["codigo"].ToString(), "8", "3", "5");
                if (datos3 != null && datos3.Rows.Count > 0)
                {
                    for (int i = 0; i < datos3.Rows.Count; i++)
                    {
                        if (datos3.Rows[i]["respuesta"].ToString() == "Aula")
                            cont++;
                    }

                }
            }
        }

        co = Convert.ToString("Total: <b>" + cont + "</b>");


        return co;
    }

    /*  LINEA BASE, 06 - PERFIL ESTUDIANTE  */

    private void cargarLineaBase06()
    {
        string co = "";
        co += "<h2 style='text-decoration: underline;'>Indicadores 06 - Perfil Estudiante</h2><br/>";
        co += " <table class='mGridTesoreria'>";
        co += "	  <tr>";
        co += "	  <thead>";
        co += "      <th>INSTRUMENTO</th>";
        co += "     <th colspan='3'>ITEM DEL INSTRUMENTO</th>";
        co += "     <th>INDICADOR/ES RELACIONADO/S/LINEA BASE</th>";
        co += "     <th>CÓDIGO ACTIVIDAD</th>";
        co += "     <th>CÓDIGO INDICADOR</th>";
        co += "	  </thead>";
        co += "     </tr>";

        co += "		  <tr>";
        co += "<td rowspan='133'>Instrumento No.6: Perfil, y grado de formación de los estudiantes de grupos de investigación abiertos y preestructurados y de las redes temáticas </td>";
        co += "<td colspan='3'>Identificación institución / sede</td>";
        co += "<td>Total sedes educativas con información sobre el perfil de los estudiantes de los  grupos de investigación y las redes temáticas institucionales: <b>" + NumSedesConPerfilEstudiante() + "</b></td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='5'>De los/as estudiantes</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2' >Nombre</td>";
        co += "<td rowspan='5'>Total de estudiantes vinculados a grupos de investigación y redes temáticas institucionales según edad, género y grado:" + NumEstudiantesEnProyecto() + "</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'>Edad</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'>Género</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td colspan='2'>Grado</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='3'>1. En el grupo  se incluyen estudiantes con discapacidad o capacidades excepcionales</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>Si</td>";
        co += "<td></td>";
        co += "<td rowspan='2'>" + NumEstudiantesConDisCapacidad() + "</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>No</td>";
        co += "<td></td>";
        co += "<td></td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='16'>2. Número de estudiantes del grupo de investigación con discapacidad o capacidades excepcionales, integrados* a la educación formal, según género.</td>";
        co += "<td rowspan='8'>Con discapacidad</td>";
        co += "</tr>";


        co += "<tr>";
        co += "<td>hombres preescolar</td>";
        co += "<td rowspan='7'>Total de estudiantes con discapacidad  vinculados a grupos de investigacióny redes temáticas institucionales según género y grado.</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres preescolar</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres basica primaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres básica primaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres basica secundaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres media</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres media</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='8'>Con capacidades excepcionales</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres preescolar</td>";
        co += "<td rowspan='7'>>Total de estudiantes con capacidades excepcionales  vinculados a grupos de investigación y redes temáticas institucionales según género y grado.</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres preescolar</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres basica primaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres básica primaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres basica secundaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres media</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres media</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='30'>3. Número de estudiantes con discapacidad, integrados y no integrados que hacen parte del grupo de investigación, por categoría y género</td>";
        co += "<td rowspan='5'>Auditiva </td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>Hombres integrados</td>";
        co += "<td rowspan='30'>Total de estudiantes con discapacidad  vinculados a grupos de investigación y redes temáticas institucionales  según tipo de discapacidad, género y grado.</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres integradas</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres no integrados</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeresno  integradas</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='5'>Visual</td>";
        co += "</tr>";

        co += "		   <tr>";
        co += "<td>Hombres integrados</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres integradas</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres no integrados</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeresno  integradas</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='5'>Motora </td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>Hombres integrados</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres integradas</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres no integrados</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres no  integradas</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='5'>Cognitiva</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>Hombres integrados</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres integradas</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres no integrados</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeresno  integradas</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='5'>Autismo </td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>Hombres integrados</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres integradas</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres no integrados</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeresno  integradas</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='5'>Otra, ¿cuál? </td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>Hombres integrados</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres integradas</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres no integrados</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeresno  integradas</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='3'>4. Se incluyen estudiantes de grupos étnicos</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>Si</td>";
        co += "<td></td>";
        co += "<td></td>";
        co += "<td></td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>No</td>";
        co += "<td></td>";
        co += "<td></td>";
        co += "<td></td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='45'>5.Distribución según grupo, nivel educativo y género</td>";
        co += "<td rowspan='9'>Indígenas </td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres preescolar</td>";
        co += "<td rowspan='44'>Total de estudiantes de grupos étnicos vinculados a grupos de investigación y redes temáticas institucionales según comunidad, género y nivel educativo.</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres preescolar</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres basica primaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres básica primaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres basica secundaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres basica secundaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres media</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres media</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='9'>Rom (Gitanos) </td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres preescolar</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres preescolar</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres basica primaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres básica primaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres basica secundaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres basica secundaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres media</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres media</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='9'>Afrocolombianos, afrodecendientes, negro o mulato. </td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres preescolar</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres preescolar</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres basica primaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres básica primaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres basica secundaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres basica secundaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres media</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres media</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='9'>Raizal dl archipiélago de San Andrés, Providencia y Santa Catalina</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres preescolar</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres preescolar</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres basica primaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres básica primaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres basica secundaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres basica secundaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres media</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres media</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='9'>Palenquero de San Basilio </td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres preescolar</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres preescolar</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres basica primaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres básica primaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres basica secundaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres basica secundaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres media</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres media</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='3'>6. Se incluyen estudiantes víctimas del conflicto</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>Si</td>";
        co += "<td></td>";
        co += "<td></td>";
        co += "<td></td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>No</td>";
        co += "<td></td>";
        co += "<td></td>";
        co += "<td></td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='45'>7. Estudiantes  víctima del conflicto según género, grado</td>";
        co += "<td rowspan='9'>En situación de desplazamiento </td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres preescolar</td>";
        co += "<td rowspan='35'>Total de estudiantes víctimas del conflicto armado  vinculados a grupos de investigación y redes temáticas institucionales, según situación, género y grado.</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres preescolar</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres basica primaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres básica primaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres basica secundaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres basica secundaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres media</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres media</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='9'>Desvinculados de organizaciones armadas al margen de la Ley </td>";

        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres preescolar</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres preescolar</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres basica primaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres básica primaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres basica secundaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres basica secundaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres media</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres media</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td rowspan='9'>Hijos de adultos desmovilizados </td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres preescolar</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres preescolar</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres basica primaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres básica primaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "	  <tr>";
        co += "<td>hombres basica secundaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres basica secundaria</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>hombres media</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>mujeres media</td>";
        co += "<td>E6A03</td>";
        co += "<td></td>";
        co += "</tr>";


        co += "</table>";

        lblResultado06.Text = co;
    }

    private string NumSedesConPerfilEstudiante()
    {
        string co = "";
        LineaBase lb = new LineaBase();

        DataTable datos = lb.cargarRespuestasNumSedesInstrumento04GroupBY("6");

        if (datos != null && datos.Rows.Count > 0)
        {
            int cont = 0;
            for (int i = 0; i < datos.Rows.Count; i++)
            {
                cont++;
            }
            co = Convert.ToString(cont);
        }

        return co;
    }

    private string NumEstudiantesEnProyecto()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        int valor = 0;

        DataRow dato = lb.cargarEstudiantesEnProyecto();

        if (dato != null)
        {
            valor = Convert.ToInt32(dato["count"].ToString());

        }
        co = Convert.ToString("<b>" + valor + "</b>");
        return co;
    }

    private string NumEstudiantesConDisCapacidad()
    {
        string co = "";
        LineaBase lb = new LineaBase();
        DataTable sede = lb.cargarSedesEnLineaBase();
        double thombre = 0;
        double tmujer = 0;

        if (sede != null && sede.Rows.Count > 0)
        {
            for (int j = 0; j < sede.Rows.Count; j++)
            {
                DataRow datos3 = lb.cargarRespuestasEstudiantesInstrumento06(sede.Rows[j]["codigo"].ToString(), "2", "0", "6");

                if (datos3 != null)
                {
                    if (datos3["thombre"].ToString() != "")
                        thombre += Convert.ToInt32(datos3["thombre"].ToString());

                    if (datos3["tmujer"].ToString() != "")
                        tmujer += Convert.ToInt32(datos3["tmujer"].ToString());
                }
            }
        }

        co = Convert.ToString("Total Hombres: <b>" + thombre + "</b><br/>Total Mujeres: <b>" + tmujer + "</b>");


        return co;
    }

    protected void btnExportar02_Click(Object sender, EventArgs e)
    {
        Response.Clear(); Response.AddHeader("content-disposition", "attachment; filename=Reporte_02-Currículo.xls"); Response.Charset = ""; Response.ContentType = "application/vnd.xls"; System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite =
        new HtmlTextWriter(stringWrite);

        lblResultado02.RenderControl(htmlWrite);

        Response.Write(stringWrite.ToString()); Response.End();
    }
    protected void btnImprimir02_Click(Object sender, EventArgs e)
    {
        //consulto el modo de impresion activo
        //lleno el lbl (tradicional o mini) con el return del metodo, de acuerdo al modo de impresión
        //en el Session["impresion"] guardo el panel del modo impresion activo.
        Session["impresion"] = PanelImprimir02;
        Control ctrl = (Control)Session["impresion"];
        PrintHelper.PrintWebControl(ctrl);
    }

    protected void btnExportar04_Click(Object sender, EventArgs e)
    {
        Response.Clear(); Response.AddHeader("content-disposition", "attachment; filename=Reporte_04-Autopercepción.xls"); Response.Charset = ""; Response.ContentType = "application/vnd.xls"; System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite =
        new HtmlTextWriter(stringWrite);

        lblResultado04.RenderControl(htmlWrite);

        Response.Write(stringWrite.ToString()); Response.End();
    }
    protected void btnImprimir04_Click(Object sender, EventArgs e)
    {
        //consulto el modo de impresion activo
        //lleno el lbl (tradicional o mini) con el return del metodo, de acuerdo al modo de impresión
        //en el Session["impresion"] guardo el panel del modo impresion activo.
        Session["impresion"] = PanelImprimir04;
        Control ctrl = (Control)Session["impresion"];
        PrintHelper.PrintWebControl(ctrl);
    }
    protected void btnExportar05_Click(Object sender, EventArgs e)
    {
        Response.Clear(); Response.AddHeader("content-disposition", "attachment; filename=Reporte_05-PerfilDocente.xls"); Response.Charset = ""; Response.ContentType = "application/vnd.xls"; System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite =
        new HtmlTextWriter(stringWrite);

        lblResultado05.RenderControl(htmlWrite);

        Response.Write(stringWrite.ToString()); Response.End();
    }
    protected void btnImprimir05_Click(Object sender, EventArgs e)
    {
        //consulto el modo de impresion activo
        //lleno el lbl (tradicional o mini) con el return del metodo, de acuerdo al modo de impresión
        //en el Session["impresion"] guardo el panel del modo impresion activo.
        Session["impresion"] = PanelImprimir05;
        Control ctrl = (Control)Session["impresion"];
        PrintHelper.PrintWebControl(ctrl);
    }
    protected void btnExportar06_Click(Object sender, EventArgs e)
    {
        Response.Clear(); Response.AddHeader("content-disposition", "attachment; filename=Reporte_06-Estudiante.xls"); Response.Charset = ""; Response.ContentType = "application/vnd.xls"; System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite =
        new HtmlTextWriter(stringWrite);

        lblResultado06.RenderControl(htmlWrite);

        Response.Write(stringWrite.ToString()); Response.End();
    }
    protected void btnImprimir06_Click(Object sender, EventArgs e)
    {
        //consulto el modo de impresion activo
        //lleno el lbl (tradicional o mini) con el return del metodo, de acuerdo al modo de impresión
        //en el Session["impresion"] guardo el panel del modo impresion activo.
        Session["impresion"] = PanelImprimir06;
        Control ctrl = (Control)Session["impresion"];
        PrintHelper.PrintWebControl(ctrl);
    }
}