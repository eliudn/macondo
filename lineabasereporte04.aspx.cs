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

public partial class lineabasereporte04 : System.Web.UI.Page
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
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td></td>";
        co += "  </tr>";

        co += "  <tr>";
        co += "  <td colspan='2'> Del/la docente</td>";
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td></td>";
        co += "  </tr>";

        co += "	<tr>";
        co += "	<td rowspan='12'>1. Técnicas y tecnológicas: Capacidad para seleccionar y utilizar de forma pertinente, responsable y eficiente una variedad de herramientas tecnológicas entendiendo los principios que las rigen, la forma de combinarlas y las licencias que las amparan. </td>";
        co += "<td rowspan='4'>1.1 Reconoce un amplio espectro de herramientas tecnológicas y algunas formas de integrarlas a la práctica educativa.              1= Nunca;  2= Casi nunca ; 3= Algunas veces; 4= Casi siempre; 5= Siempre</td>";
        co += "	</tr>";

        co += "	<tr>";
        co += "	<td>Identifico las características, usos y oportunidades que ofrecen herramientas tecnológicas y medios audiovisuales, en los procesos educativos</td>";
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0101</td>";
        co += "		</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Elaboro actividades de aprendizaje utilizando aplicativos, contenidos, herramientas informáticas y medios audiovisuales";
        co += "</td>";
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0102</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Evalúo la calidad, pertinencia y veracidad de la información disponible en diversos medios como portales educativos y especializados, motores de búsqueda y material audiovisual.";
        co += "</td>";
        co += "  <td></td>";
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
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0104</td>";
        co += "		</tr>";

        co += "		<tr>";
        co += "		<td>";
        co += "		Diseño y publico contenidos digitales u objetos virtuales de aprendizaje mediante el uso adecuado de herramientas tecnológicas.";
        co += "		</td>";
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0105</td>";
        co += "		</tr>";

        co += "		<tr>";
        co += "		<td>";
        co += "Analizo los riesgos y potencialidades de publicar y compartir distintos tipos de información a través de Internet";
        co += "		</td>";
        co += "  <td></td>";
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
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0107</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Utilizo herramientas tecnológicas para ayudar a mis estudiantes a construir aprendizajes significativos y desarrollar pensamiento crítico.";


        co += "</td>";
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0108</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Aplico las normas de propiedad intelectual y licenciamiento existentes, referentes al uso de información ajena y propia";

        co += "</td>";
        co += "  <td></td>";
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
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0201</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Identifico problemáticas educativas en mi práctica docente y las oportunidades, implicaciones y riesgos del uso de las TIC para atenderlas.";

        co += "</td>";
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0202</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Conozco una variedad de estrategias y metodologías apoyadas por las TIC, para planear y hacer seguimiento a mi labor docente.";

        co += "</td>";
        co += "  <td></td>";
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
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0204</td>";
        co += "</tr>";

        co += "		<tr>";
        co += "<td>";
        co += "Utilizo TIC con mis estudiantes para atender sus necesidades e intereses y proponer soluciones a problemas de aprendizaje.";

        co += "</td>";
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0205</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Implemento estrategias didácticas mediadas por TIC, para fortalecer en mis estudiantes aprendizajes que les permitan resolver problemas de la vida real";

        co += "</td>";
        co += "  <td></td>";
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
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0207</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Propongo proyectos educativos mediados con TIC, que permiten la reflexión sobre el aprendizaje propio y la producción de conocimiento.";

        co += "</td>";
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0208</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Evalúo los resultados obtenidos con la implementación de estrategias que hacen uso educativo de TIC y promuevo una cultura de seguimiento, retroalimentación y mejoramiento permanente";

        co += "</td>";
        co += "  <td></td>";
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
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0301</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Navego eficientemente en Internet integrando fragmentos de información presentados de forma no lineal.";

        co += "</td>";
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0302</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Evalúo la pertinencia de compartir información a través de canales públicos y masivos, respetando las normas de propiedad intelectual y licenciamiento.";

        co += "</td>";
        co += "  <td></td>";
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
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0304</td>";
        co += "</tr>";

        co += "		<tr>";
        co += "		<td>";
        co += "		Sistematizo y hago seguimiento a experiencias significativas de uso de TIC.";

        co += "</td>";
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0305</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Promuevo en la comunidad educativa comunicaciones efectivas que aportan al mejoramiento de los procesos de convivencia escolar.";

        co += "</td>";
        co += "  <td></td>";
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
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0307</td>";
        co += "</tr>";

        co += "<tr>";
        co += "		<td>";
        co += "Interpreto y produzco íconos, símbolos y otras formas de representación de la información, para ser utilizados con propósitos educativos";

        co += "</td>";
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0308</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Contribuyo con mis conocimientos y los de mis estudiantes a repositorios de la humanidad de Internet, con textos de diversa naturaleza.";

        co += "</td>";
        co += "  <td></td>";
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
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0401</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Conozco políticas escolares para el uso de las TIC que contemplan la privacidad, el impacto ambiental y la salud de los usuarios.";

        co += "</td>";
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0402</td>";
        co += "</tr>";

        co += "	<tr>";
        co += "<td>";
        co += "Identifico mis necesidades de desarrollo profesional para la innovación educativa con TIC";

        co += "</td>";
        co += "  <td></td>";
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
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0404</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Adopto políticas escolares existentes para el uso de las TIC en mi institución que contemplan la privacidad, el impacto ambiental y la salud de los usuarios.";

        co += "</td>";
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0405</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Selecciono y accedo a programas de formación, apropiados para mis necesidades de desarrollo profesional, para la innovación educativa con TIC.";

        co += "</td>";
        co += "  <td></td>";
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
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0407</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Desarrollo políticas escolares para el uso de las TIC en mi institución que contemplan la privacidad, el impacto ambiental y la salud de los usuarios.";

        co += "	</td>";
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0408</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "		Dinamizo la formación de mis colegas y los apoyo para que integren las TIC de forma innovadora en sus prácticas pedagógicas.";

        co += "		</td>";
        co += "  <td></td>";
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
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0501</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Identifico redes, bases de datos y fuentes de información que facilitan mis procesos de investigación";

        co += "</td>";
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0502</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Sé buscar, ordenar, filtrar, conectar y analizar información disponible en Internet.";

        co += "	</td>";
        co += "  <td></td>";
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
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0504</td>";
        co += "</tr>";

        co += "<tr>";
        co += "	<td>";
        co += "Utilizo redes profesionales y plataformas especializadas en el desarrollo de mis investigaciones.";

        co += "</td>";
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0505</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Contrasto y analizo con mis estudiantes información proveniente de múltiples fuentes digitales.";

        co += "</td>";
        co += "  <td></td>";
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
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0507</td>";
        co += "</tr>";

        co += "	<tr>";
        co += "<td>";
        co += "Participo activamente en redes y comunidades de práctica, para la construcción colectiva de conocimientos con estudiantes y colegas, con el apoyo de TIC";

        co += "</td>";
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0508</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Utilizo la información disponible en Internet con una actitud crítica y reflexiva.";

        co += "</td>";
        co += "  <td></td>";
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
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0601</td>";
        co += "</tr>";

        co += "<tr>";
        co += "<td>";
        co += "		Identifico los riesgos de publicar y compartir distintos tipos de información a través de Internet";

        co += "		</td>";
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0602</td>";
        co += "</tr>";

        co += "		<tr>";
        co += "<td>";
        co += "Utilizo las TIC teniendo en cuenta recomendaciones básicas de salud";
        co += "</td>";
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0603</td>";
        co += "		</tr>";

        co += "<tr>";
        co += "<td>";
        co += "Examino y aplico las normas de propiedad intelectual y licenciamiento existentes, referentes al uso de información ajena y propia";

        co += "</td>";
        co += "  <td></td>";
        co += "  <td>E6A03</td>";
        co += "  <td>E6A03AU0604</td>";
        co += "</tr>";


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