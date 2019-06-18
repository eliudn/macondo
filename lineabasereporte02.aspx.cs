using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

public partial class lineabasereporte02 : System.Web.UI.Page
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
            cargarTabla();
        }
    }
    private void mostrarmensaje(string estado, string texto)
    {
        mensaje.Attributes.Add("style", "display:block");// este es el mensaje 
        mensaje.Attributes.Add("class", estado + " mensajes");
        mensaje.InnerText = texto;
    }
    private void cargarTabla()
    {
        string co = "";

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

         co +="<tr>";
		  co +="<td rowspan='20'>Instrumento No. 02 Perfil curricular institucional Caracterización de Currículos de las IEs Proyecto Ciclón</td>";
		  co +="<td colspan='2'>Identificación: Institución sede, Responsable Institución Educativa, Responsable del diligenciamiento</td>";
          co += "<td align='center'>Número de sedes educativas con información de currículos: <b>" + NumSedesConCurriculos() + "</b></td>";
          co += "<td align='center'>E6A03</td>";
          co += "<td align='center'></td>";
          co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
		  co +="</tr>";
		  
		  co +="<tr>";
		  co +="<td colspan='2'>1. Cuál es el énfasis formativo del Proyecto Educativo Institucional – PEI?</td>";
          co += "<td>Número Sedes que incluyen Ciencia, tecnología e Innovación, Investigación, TIC en sus enfasis formativos: <b>" + NumSedesConEnfasis() + "<b></td>";
          co += "<td align='center'>E6A03</td>";
          co += "<td align='center'>E6A03CU0101</td>";
          co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
		  co +="</tr>";
		  
		  co +="<tr>";
		  co +="<td colspan='2'>2.Cuál es el modelo educativo de la sede beneficiada, teniendo en cuenta la clasificación del  –MEN y describa si el modelo educativo seleccionado favorece la incorporación de la IEP en su sede educativa?</td>";
		  co +="<td>Número Sedes que incluyen Modelos educativos potencialmente favorables a la incorporación de la IEP: <b>" + NumSedesConModeloEducativo() + "<b></td>";
          co += "<td align='center'>E6A03</td>";
          co += "<td align='center'>E6A03CU0201</td>";
          co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
		  co +="</tr>";
		  
		  co +="<tr>";
		  co +="<td rowspan='5'>3. En el PEI y/o en los procesos institucionales se considera alguno de los siguientes aspectos:</td>";
		  co +="</tr>";
		  
		  co +="<tr>";
		  co +="<td>La investigación docente</td>";
		  co +="<td>Número sedes que consideran en sus PEI y/o procesos institucionales la investigación docente: <b>" + NumSedesConInvestigacionDocente() + "</b> </td>";
          co += "<td align='center'>E6A03</td>";
          co += "<td align='center'>E6A03CU0301</td>";
          co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
		  co +="</tr>";
		  
		  co +="<tr>";
		  co +="<td>La investigación de los estudiantes</td>";
		  co +="<td>Número sedes que consideran en sus consideran en sus PEI y/o procesos institucionales la investigación de los estudiantes: <b>" + NumSedesConInvestigacionEstudiante() + "</b></td>";
          co += "<td align='center'>E6A03</td>";
          co += "<td align='center'>E6A03CU0302</td>";
          co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
		  co +="</tr>";

		  co +="<tr>";
		  co +="<td>Uso de Las TICs de los Docentes</td>";
		  co +="<td>Número sedes que consideran en sus  consideran en sus PEI y/o procesos institucionales el uso de TICS por los docentes: <b>" + NumSedesConTICDocente() + "</b></td>";
          co += "<td align='center'>E6A03</td>";
          co += "<td align='center'>E6A03CU0303</td>";
          co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
		  co +="</tr>";

		  co +="<tr>";
		  co +="<td>Uso de TICS con los estudiantes</td>";
          co += "<td>Número sedes que consideran el uso de TICS en los estudiantes: <b>" + NumSedesConTICEstudiante() + "<b></td>";
          co += "<td align='center'>E6A03</td>";
          co += "<td align='center'>E6A03CU0303</td>";
          co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
		  co +="</tr>";

		  co +="<tr>";
		  co +="<td colspan='2'>4. ¿ Cuáles son las principales prácticas de innovación educativa que se realizan en la sede beneficiada?</td>";
          co += "<td align='center'>Número de sedes educativas que realizan prácticas  pedagógicas de indagación e investigación: <b>" + NumSedesConPrincipalesPrecticasInnovacion() + "</b></td>";  
          co += "<td align='center'>E6A03</td>";
          co += "<td align='center'>E6A03CU0401</td>";
          co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
		  co +="</tr>";
		  
		  co +="<tr>";
		  co +="<td >5. ¿En el PEI se promueve la investigación dentro de las prácticas instucionales?</td>";
          co += "<td align='center'>S/N</td>";  
          co += "<td align='center'><b>" + NumSedesConPrincipalesPracticas() + "</b></td>";
          co += "<td align='center'>E6A03</td>";
          co += "<td align='center'>E6A03CU0501</td>";
          co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
		  co +="</tr>";
		  
		  co +="<tr>";
		  co +="<td rowspan='3'>6. ¿En el PEI se promueve el uso de las TIC como parte de las prácticas institucionales?</td>";
		  co +=" </tr>";
		  
		  co +=" <tr>";
		  co +=" <td> S/N Cómo</td>";
          co += "<td align='center'>Número sedes educativas que tienen en el PEI y/o prácticas institucionales el uso de las TICS: <b>" + NumSedesConUsoTIC() + "</b></td>";
          co += "<td align='center'>E6A03</td>";
          co += "<td align='center'>E6A03CU601</td>";
          co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
		 co +=" </tr>";
		  
		 co +=" <tr>";
		 co +=" <td>";
		 co +=" ¿Cuáles TIC?s</td>";
         co += " <td> " + UsoTIC() + "</td>";
         co += "<td align='center'>E6A03</td>";
         co += "<td align='center'>E6A03CU602</td>";
         co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
		  co +="</tr>";
		  
		  co +=" <tr>";
		  co +="<td > 7. El currículo pretende formar en competencias para el uso y apropiación de la TIC? </td>";
		co +="  <td>S/N</td>";
        co += "  <td align='center'><b>" + NumSedesCompetenciasTIC() + "<b></td>";
        co += "<td align='center'>E6A03</td>";
        co += "<td align='center'>E6A03CU701</td>";
        co += "<td align='center'><a href='#'><img src='Imagenes/ver.png' /></a></td>";
		 co +=" </tr>";
		  
		co +="  <tr>";
		co +="  <td rowspan='9'> ";
		co +=" 8.¿Cuáles competencias en i apropiación de TIC pretende formar el currículo?";

		co +="  </td>";
		co +="  </tr>";

        co += NumSedesApropiacionTIC(); ;
		  
		
	
        co += "</table>";

        lblResultado.Text = co;
    }
    
   private string NumSedesConCurriculos()
    {
        string ca = "";
        LineaBase lb = new LineaBase();
        DataRow dato = lb.contarSedesConCurriculo();

       if(dato != null)
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

       if(datos != null && datos.Rows.Count>0)
       {
           int cont = 0;
           for(int i = 0; i < datos.Rows.Count; i++)
           {
               DataTable enfasis = lb.cargarRespuestasCerradasxInstrumento02(datos.Rows[i]["codigo"].ToString(),"1","0","2");

               if(enfasis != null)
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
                      if(enfasis.Rows[j]["respuesta"].ToString() == "Si")
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
                           if(PC == 0)
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
                   for (int j = 0; j < enfasis.Rows.Count; j++ )
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
}