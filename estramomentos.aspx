<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estramomentos.aspx.cs" Inherits="estramomentos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">


    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">
    <%--<script src="Scripts/pruebas.js"></script>--%>

     <script>
        $(document).ready(function () {
            $("#MainContent_accordion").accordion({
                heightStyle: "content",
                active: "1" //Colocas comillas para que no se abra ninguno, quitas comillas y colocas un numero si quieres que se visualize algun panel
            });
            $("#MainContent_accordion").attr("style", "visibility:visible;");

        });

    </script>
     <script>
         function abrir(panel) {
             var p = parseInt(panel);
             $(function () {
                 $("#MainContent_accordion").accordion({
                     heightStyle: "content",
                     active: p
                 });
             });
         }
    </script>


    <style type="text/css">
        img.res {
            width: 100%;
            max-width: 600px;
        }
 
    </style>



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
     <div id="mensaje" runat="server"></div>
    <asp:Label runat="server" ID="lblBack" Visible="false" ></asp:Label>
 <br /><br />
    <h2>Estrategía No. 1 - Momentos Pedagógicos</h2>
    <p><b>OBJETIVO ESPECÍFICO:</b> Contribuir al desarrollo de capacidades, habilidades y competencias científicas, tecnológicas y de innovación en 320 sedes educativas del Magdalena, siguiendo los lineamentos del programa Ondas</p>

    <asp:Label runat="server" ID="lblCodg007" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblMomento" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblSesion" Visible="false"></asp:Label>

     <div id="accordion" runat="server" >
         
     </div>

    



    <table align="left" style="display:none">
        <tr>
            <td>
                 <!-- UniMag, Estrategia Nro. 1 Momento 0 -->
                <asp:button Width="770" runat="server" ID="btnMomento0" CssClass="btn btn-primary" Text="Momento pedagógico 0: La planeación colectiva" OnClick="btnMomento0_Click" /><br />
                <asp:Button Width="770" runat="server" ID="btnCargarEvidencias" CssClass="btn btn-success" Text="Lineamientos y rutas metodológicas" Visible="false" OnClick="btnCargarEvidencias_Click" />
                <asp:Button Width="770" runat="server" ID="btnMomento0g008" CssClass="btn btn-success" Text="Formato  plan operativo" Visible="false" OnClick="btnMomento0g008_Click" />
                
                <!-- Unimag, Estrategia Nro. 2 Momento 0-->
                 <asp:Button Width="770" runat="server" ID="btnMomento0EjecucionFinanciera" CssClass="btn btn-danger" Text="Ejecución financiera de recursos" Visible="false" OnClick="btnMomento0EjecucionFinanciera_Click" />
                <asp:Button Width="770" runat="server" ID="btnMomento0ProduccionSistematizacion" CssClass="btn btn-danger" Text="Informe de producción de la sistematización" Enabled="false" Visible="false" />
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                  <!-- UniMag Momento 1-->
                <asp:button Width="770" runat="server" ID="btnMomento1" CssClass="btn btn-primary" Text="Momento pedagógico 1: Convocatoria y acompañamiento para la conformación del grupo" OnClick="btnMomento1_Click" /><br />
                <asp:Button Width="770" runat="server" ID="btnConformacionGrupos" CssClass="btn btn-success" Text="Conformación de los Grupos de Investigación" Visible="false" OnClick="btnConformacionGrupos_Click" />
                <asp:Button Width="770" runat="server" ID="btnMomento1CargarEvidencias" CssClass="btn btn-success" Text="Planeación y divulgación de la convocatoria" Visible="false" OnClick="btnMomento1CargarEvidencias_Click" />
                <asp:Button Width="770" runat="server" ID="btnMomento1g006" CssClass="btn btn-danger" Text="G006: Entrega de material pedagógico" Visible="false" OnClick="btnMomento1g006_Click" />
                <asp:button Width="770" runat="server" ID="btnVerGruposInvestigacion" CssClass="btn btn-danger" Text="Ver Conformación Grupos de Investigación" Visible="false" OnClick="btnVerGruposInvestigacion_Click" /><br />
                <asp:Button Width="770" runat="server" ID="btnMomento1s002" CssClass="btn btn-danger" Text="S002: Registro de asesoría, acompañamiento y formación - Certificado de cumplimiento" Visible="false" OnClick="btnMomento1s002_Click" />
                <asp:Button Width="770" runat="server" ID="btnMomento1Bitacora1" CssClass="btn btn-danger" Text="B01: Estar en Ciclón es la vía" Visible="false" OnClick="btnMomento1Bitacora1_Click" />
                <!--agregado 22-11-2016 por Jonny Pacheco-->
				<asp:Button Width="770" runat="server" ID="btnVerMomento1Bitacora1" CssClass="btn btn-danger" Text="Ver B01: Estar en Ciclón es la vía" Visible="false" OnClick="btnVerMomento1Bitacora1_Click" />
          
				<asp:Button Width="770" runat="server" ID="btnMomento1Bitacora2" CssClass="btn btn-danger" Text="B02: Perturbación de la Onda en Ciclón" Visible="false" OnClick="btnMomento1Bitacora2_Click" />
                <asp:Button Width="770" runat="server" ID="btnMomento1Bitacora3" CssClass="btn btn-danger" Text="B03: Superposición de la Onda" Visible="false" OnClick="btnMomento1Bitacora3_Click" />
                <asp:Button Width="770" runat="server" ID="btnMomento1s002Sesion4" CssClass="btn btn-danger" Text="S002: Registro de asesoría, acompañamiento y formación - Desarrollo del momento" Visible="false" OnClick="btnMomento1s002Sesion4_Click" />
                <asp:button Width="770" runat="server" ID="btnMomento1s007" CssClass="btn btn-danger" Text="S007: Evaluación de la asesoría" OnClick="btnMomento1s007_Click" Visible="false" /><br />
                <asp:button Width="770" runat="server" ID="btnMomento1Preestructurados" CssClass="btn btn-primary" Text="Preestructurados" Visible="false" OnClick="btnMomento1Preestructurados_Click" /><br />
                <asp:button Width="770" runat="server" ID="btnMomento1PreestructuradosMedioAmbiente" CssClass="btn btn-danger" Text="Medio Ambiente" Visible="false" OnClick="btnMomento1PreestructuradosMedioAmbiente_Click" /><br />
                <asp:button Width="770" runat="server" ID="btnMomento1PreestructuradosBienestar" CssClass="btn btn-danger" Text="Bienestar Infantil y juvenil" Visible="false" OnClick="btnMomento1PreestructuradosBienestar_Click" /><br />
                
                <hr />
            </td>
        </tr>
        <tr>
            <td>
                 <!-- Momento 2 -->
                <asp:button Width="770" runat="server" ID="btnMomento2" CssClass="btn btn-primary" Text="Momento pedagógico 2: Definición de la linea de investigación y del tipo de asesoria" OnClick="btnMomento2_Click" /><br />
                 <asp:Button Width="770" runat="server" ID="btnCargarEvidenciasMomento2" CssClass="btn btn-success" Text="Cargar Evidencias" Visible="false" OnClick="btnCargarEvidenciasMomento2_Click" />
                <hr />
            </td>
       </tr>
        <tr>
            <td>
                <!-- Momento 3 -->
                <asp:button Width="770" runat="server" ID="btnMomento3" CssClass="btn btn-primary" Text="Momento pedagógico 3: Acompañamiento para el desarrollo de las etapas, diseño y recorrido de las trayectorias de indagación" OnClick="btnMomento3_Click" /><br />
                <asp:Button Width="770" runat="server" ID="btnCargarEvidenciasMomento3" CssClass="btn btn-success" Text="Cargar Evidencias" Visible="false" OnClick="btnCargarEvidenciasMomento3_Click" />
                <asp:button Width="770" runat="server" ID="btnMomento3Bitacora4" CssClass="btn btn-danger" Text="B04: Acompañamiento para el desarrollo de las etapas, diseño y recorrido de las trayectorias de indagación" OnClick="btnMomento3Bitacora4_Click" Visible="false" /><br />
                <asp:button Width="770" runat="server" ID="btnMomento3Bitacora5" CssClass="btn btn-danger" Text="B05: Trayectorías de indagación" OnClick="btnMomento3Bitacora5_Click" Visible="false" />
                <asp:Button Width="770" runat="server" ID="btnMomento3s002Sesion1" CssClass="btn btn-danger" Text="S002: Registro de asesoría" Visible="false" OnClick="btnMomento3s002Sesion1_Click" />
                <asp:button Width="770" runat="server" ID="btnMomento3s007" CssClass="btn btn-danger" Text="S007: Evaluación de la asesoría" OnClick="btnMomento3s007_Click" Visible="false" /><br />
             
                <asp:button Width="770" runat="server" ID="btnMomento3Preestructurados" CssClass="btn btn-primary" Text="Preestructurados" Visible="false" OnClick="btnMomento3Preestructurados_Click" /><br />
                <asp:button Width="770" runat="server" ID="btnMomento3PreestructuradosMedioAmbiente" CssClass="btn btn-danger" Text="Medio Ambiente" Visible="false" OnClick="btnMomento3PreestructuradosMedioAmbiente_Click" /><br />
                <asp:button Width="770" runat="server" ID="btnMomento3PreestructuradosBienestar" CssClass="btn btn-danger" Text="Bienestar Infantil y juvenil" Visible="false" OnClick="btnMomento3PreestructuradosBienestar_Click" /><br />

                <hr />
            </td>
        </tr>
        <tr>
            <td>
                <!-- Momento 4 -->
                <asp:button Width="770" runat="server" ID="btnMomento4" CssClass="btn btn-primary" Text="Momento pedagógico 4: Acompañamiento para la reflexión de Ciclón" OnClick="btnMomento4_Click" /><br />
                <asp:Button Width="770" runat="server" ID="btnCargarEvidenciasMomento4" CssClass="btn btn-success" Text="Cargar Evidencias" Visible="false" OnClick="btnCargarEvidenciasMomento4_Click" />
                <asp:Button Width="770" runat="server" ID="btnMomento4s002" CssClass="btn btn-danger" Text="S002: Registro de asesoría" Visible="false" OnClick="btnMomento4s002_Click" />
                <asp:button Width="770" runat="server" ID="btnMomento4s007" CssClass="btn btn-danger" Text="S007: Evaluación de la asesoría" OnClick="btnMomento4s007_Click" Visible="false" />
                <asp:button Width="770" runat="server" ID="btnMomento4s003" CssClass="btn btn-danger" Text="S003: Informe de investigación grupos de investigación" OnClick="btnMomento4s003_Click" Visible="false" /><br />

                <asp:button Width="770" runat="server" ID="btnMomento4Preestructurados" CssClass="btn btn-primary" Text="Preestructurados" Visible="false" OnClick="btnMomento4Preestructurados_Click" /><br />
                <asp:button Width="770" runat="server" ID="btnMomento4PreestructuradosMedioAmbiente" CssClass="btn btn-danger" Text="Medio Ambiente" Visible="false" OnClick="btnMomento4PreestructuradosMedioAmbiente_Click" /><br />
                <asp:button Width="770" runat="server" ID="btnMomento4PreestructuradosBienestar" CssClass="btn btn-danger" Text="Bienestar Infantil y juvenil" Visible="false" OnClick="btnMomento4PreestructuradosBienestar_Click" /><br />

                 <hr />
            </td>
        </tr>
        <tr>
            <td>
                <asp:button Width="770" runat="server" ID="btnMomento5" CssClass="btn btn-primary" Text="Momento pedagógico 5: Acompañamiento para la propagación de Ciclón" OnClick="btnMomento5_Click" /><br />
                <asp:Button Width="770" runat="server" ID="btnCargarEvidenciasMomento5" CssClass="btn btn-success" Text="Carga de evidencias" Visible="false" OnClick="btnCargarEvidenciasMomento5_Click" />
                <asp:Button Width="770" runat="server" ID="btnInscripcionGruposEvidenciasMomento5" CssClass="btn btn-success" Text="Inscripción de grupos de investigación y maestros a las ferias" Visible="false" OnClick="btnInscripcionGruposEvidenciasMomento5_Click" />
                <asp:Button Width="770" runat="server" ID="btnActadeReunionMomento5" CssClass="btn btn-danger" Text="Acta de reunión" Visible="false" OnClick="btnActadeReunionMomento5_Click" />
                <%--<asp:Button Width="770" runat="server" ID="btnCargarEvidenciasMomento5Apropiacion1" CssClass="btn btn-success" Text="Espacio de apropiacion municipales" Visible="false" OnClick="btnCargarEvidenciasMomento5Apropiacion1_Click" />
                <asp:Button Width="770" runat="server" ID="btnCargarEvidenciasMomento5Apropiacion2" CssClass="btn btn-success" Text="Espacio de apropiacion departamentales" Visible="false" OnClick="btnCargarEvidenciasMomento5Apropiacion2_Click" />
                <asp:Button Width="770" runat="server" ID="btnCargarEvidenciasMomento5Apropiacion3" CssClass="btn btn-success" Text="Espacio de apropiacion regionales" Visible="false" OnClick="btnCargarEvidenciasMomento5Apropiacion3_Click" />--%>

                <asp:button Width="770" runat="server" ID="btnMomento5Preestructurados" CssClass="btn btn-primary" Text="Preestructurados" Visible="false" OnClick="btnMomento5Preestructurados_Click" /><br />
                <asp:button Width="770" runat="server" ID="btnMomento5PreestructuradosMedioAmbiente" CssClass="btn btn-danger" Text="Medio Ambiente" Visible="false" OnClick="btnMomento5PreestructuradosMedioAmbiente_Click" /><br />
                <asp:button Width="770" runat="server" ID="btnMomento5PreestructuradosBienestar" CssClass="btn btn-danger" Text="Bienestar Infantil y juvenil" Visible="false" OnClick="btnMomento5PreestructuradosBienestar_Click" /><br />
            </td>
        </tr>
    </table>

    <table align="center">
        <tr>
            <td>
               
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button Width="770" runat="server" ID="btnMomento1Etapa123" CssClass="btn btn-danger" Text="Etapa 1, 2, 3" Visible="false" OnClick="btnMomento1Etapa123_Click" />
                <asp:Button Width="770" runat="server" ID="btnMomento1EvaluacionAsesoria" CssClass="btn btn-danger" Text="Evaluación Asesoría" Visible="false" OnClick="btnMomento1EvaluacionAsesoria_Click" />
                <asp:Button Width="770" runat="server" ID="btnMomento1Eventos" CssClass="btn btn-danger" Text="Eventos" Visible="false" />
                <asp:Button Width="770" runat="server" ID="btnMomento1RegistroVisita" CssClass="btn btn-danger" Text="Registro Visita" Visible="false" />
            </td>
        </tr>
    </table>

              
</asp:Content>

