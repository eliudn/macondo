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

public partial class lineabasereporte05 : System.Web.UI.Page
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
co += "<td>Total de sedes educativas con información sobre perfil de los docentes del Programa Ciclón</td>";
co += "		<td>E6A03</td>";
co += "<td></td>";
co += "</tr>";
		  
co += "<tr>";
co += "<td colspan='2'> Del/la docente</td>";
co += "<td>Total de docentes con información sobre su perfil en TIC, e investigación</td>";
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
co += "<td rowspan='12'>Total de  docentes participantes en el Programa CICLÓN según clase de funcionario </td>";
co += "<td>E6A03</td>";
co += "<td>E6A03PD0101</td>";
co += "</tr>";
		 
co += "<tr>";
co += "<td colspan='2'> Docentes (no incluya educadorese speciales ni etnoeducadores)</td>";
co += "<td>E6A03</td>";
co += "<td>E6A03PD0102</td>";
co += "</tr>";
		 
co += "<tr>";
co += "<td colspan='2'>Docentes de educación especial</td>";
co += "<td>E6A03</td>";
co += "<td>E6A03PD0103</td>";
co += "</tr>";
		 
co += "<tr>";
co += "<td colspan='2'>Docentes de etnoeducación</td>";
co += "<td>E6A03</td>";
co += "<td>E6A03PD0104</td>";
co += "</tr>";
		  
co += "<tr>";
	co += "	 <td colspan='2'>Consejeros escolares, capellanes, orientadores, sicólogos y trabajadores sociales</td>";
co += "<td>E6A03</td>";
co += "<td>E6A03PD0105</td>";
co += "</tr>";
		 
co += "<tr>";
co += "<td colspan='2'> Médicos, odontólogos, nutricionistas, terapeutas y enfermeros</td>";
co += "<td>E6A03</td>";
co += "<td>E6A03PD0106</td>";
co += "</tr>";
		 
co += "<tr>";
co += "<td colspan='2'> Administrativos (de apoyo y personal de servicios generales)</td>";
co += "<td>E6A03</td>";
co += "	 <td>E6A03PD0107</td>";
co += "	 </tr>";
		 
co += "	  <tr>";
co += "<td colspan='2'> Profesionales de apoyo en el aula para estudiantes con discapacidad o capacidades excepcionales</td>";
co += "<td>E6A03</td>";
co += "<td>E6A03PD0108</td>";
co += "</tr>";
		 
co += "<tr>";
co += "<td colspan='2'> Tutores</td>";
co += "<td>E6A03</td>";
co += "<td>E6A03PD0109</td>";
co += "</tr>";
		 
co += "	  <tr>";
co += "	 <td colspan='2'> Directivos (rectores, directores, coordinadores, supervisores, secretarios académicos)</td>";
co += "<td>E6A03</td>";
co += "<td>E6A03PD010</td>";
co += "</tr>";
		 
co += "<tr>";
co += "<td colspan='2'> Auxiliar de aula</td>";
co += "<td>E6A03</td>";
co += "<td>E6A03PD0111</td>";
co += "</tr>";
		  
co += "	   <tr>";
co += "<td rowspan='23'>";
co += "2. Último nivel de formación obtenido";
co += "	 </td>";
co += "</tr>";
		 
co += "<tr>";
co += "<td colspan='2'> Nivel bachillerato pedagógico</td>";
co += "<td rowspan='23'>Total de docentes participantes en el Programa CICLÓN, según ultimo nivel de formación alcanzado, título y año</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0201</td>";
co += "</tr>";
		 
co += "<tr>";
co += "<td colspan='2'> Año bachillerato pedagógico</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0203</td>";
co += "</tr>";
		 
co += "<tr>";
co += "<td colspan='2'> Nivel normalista superior</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0204</td>";
co += "</tr>";
		 
co += "<tr>";
co += "<td colspan='2'> Año Normalista superior</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0206</td>";
	co += "	 </tr>";
		 
co += "<tr>";
co += "<td colspan='2'> Nivel otro bachillerato</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0207</td>";
co += "		 </tr>";
		 
co += "<tr>";
co += "<td colspan='2'> Año otro bachillerato</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0209</td>";
co += "</tr>";
		 
co += "<tr>";
co += "<td colspan='2'>Nivel técnico o tecnológico pedagógico</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0210</td>";
co += "</tr>";
		 
co += "<tr>";
co += " <td colspan='2'>Año tecnico o tecnológico pedagógico</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0212</td>";
co += "</tr>";
		 
co += "<tr>";
co += "<td colspan='2'>Nivel otro técnico o tecnológico</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0213</td>";
co += "</tr>";
		 
co += "  <tr>";
co += "	 <td colspan='2'>Año otro tecnico o tecnológico</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0215</td>";
co += "</tr>";
		 
co += "<tr>";
co += "<td colspan='2'>Tíulo profesional pedagógico</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0216</td>";
co += "</tr>";
		 
co += "	  <tr>";
co += "<td colspan='2'>Año profesional pedagógico</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0218</td>";
co += "</tr>";
		 
co += "<tr>";
co += "<td >Nivel otro profesional</td>";
co += "<td></td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0219</td>";
co += "	 </tr>";
		 
co += "<tr>";
co += "<td >Año otro profesional</td>";
co += "<td></td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0221</td>";
co += "</tr>";
		 
co += "<tr>";
co += "<td >Nivel maestría en educación</td>";
co += "<td></td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0222</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>Año Maestría en educación</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0224</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>Nivel otra maestría</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0225</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>Año  otra maestría</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0227</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>Nivel doctorado en educación o pedagógia</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0228</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>Año doctorado en educación o pedagogía</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0230</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>Nivel otro doctorado</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0231</td>";
co += " </tr>";

co += "<tr>";
co += "<td >Año otro doctorado</td>";
co += "<td></td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0233</td>";
co += " </tr>";

co += "<tr>";
co += "<td rowspan='4'>";
co += "3.Nivel educativo en el que trabaja";
co += "</td>";
co += "</tr>";

co += "<tr>";
co += "<td colspan='2'>1  Preescolar</td>";
co += "<td rowspan='3'>Total de docentes participantes en el Programa CICLÓN según el nivel educativo en que trabaja.</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0301</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>2  Básica Primaria</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0302</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>3  Básica Secundaria y Media    </td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0303</td>";
co += " </tr>";

co += "<tr>";
co += "<td rowspan='8'>";
co += "4. Áreas de enseñanza en las que desarrolla la docencia</td>";
co += "<td colspan='2'>Carecter Académico</td>";
co += "<td>Total docentes participantes en el Programa CICLÓN, según el área de enseñanza en la que desarrolla la docencia para el Carácter Académico</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0401</td>";
co += "</tr>";

co += "<tr>";
co += "<td rowspan='7' colspan='2'>Carácter técnico</td>";
co += " </tr>";

co += "<tr>";
co += "<td>Total docentes participantes en el Programa CICLÓN, según el área de enseñanza en que desarrolla la docencia para el carácter técnico</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0402</td>";
co += "</tr>";

co += "<tr>";
co += "<td>Otra cual especialidad industrial</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0403</td>";
co += "</tr>";

co += "<tr>";
co += "<td>Otra cual especialidad Pedagógica</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0404</td>";
co += "</tr>";

co += "<tr>";
co += "<td>Otra cual especialidad Promoción social</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0405</td>";
co += "</tr>";

co += "<tr>";
co += "<td>Otra cuál especialidad informática</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0406</td>";
co += "</tr>";

co += "<tr>";
co += "<td>Otra, ¿cuál? Espécialidad.</td>";
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
co += "<td rowspan='17'>Total de docentes participantes en el Programa CICLÓN que han recibido formación específica en investigación.</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0501</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>nombre 1</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0502</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>Duración (horas)1</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0503</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>Año 1</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0504</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>Modalidad 1</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0505</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>Tipo 2</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0506</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>nombre 2</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0507</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>Duración (horas)2</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0508</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>Año 2</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0509</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>Modalidad 2</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0510</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>Tipo 3</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0511</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>nombre 3</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0512</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>Duración (horas)3</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0513</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>Año 3</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0514</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>Modalidad 3</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0515</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>Esta formación contribuyó a cambiar sus prácticas pedagógicas?  SI-Cómo/NO</td>";
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
co += "<td rowspan='6'>Total de docentes participantes en el Programa CICLÓN  que han participado en proyectos de investigación dentro de la institución educativa</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0601</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>Cuáles</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0602</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>De aula</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0603</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>Transversales</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0604</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>Interdisciplinarios</td>";
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
co += "<td>Total de docentes participantes en el Programa CICLÓN  que han participado en proyectos de investigación fuera de la institución educativa</td>";
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
co += "<td rowspan='6'>Total de docentes participantes en el Programa CICLÓN  que han realizado proyectos de investigación con niños/as y jóvenes como práctica pedagógica</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0801</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>Cuáles</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0802</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>De aula</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0803</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>Transversales</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0804</td>";
co += " </tr>";

co += "<tr>";
co += "<td colspan='2'>Interdisciplinarios</td>";
co += "<td>E6A03</td>";
co += "<td>E6AA03PD0805</td>";
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

        lblResultado.Text = co;
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
}