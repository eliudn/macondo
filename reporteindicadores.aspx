<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="reporteindicadores.aspx.cs" Inherits="reporteindicadores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

     <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">

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

        .navegadores {
            background-color: #BECECE;
            float: right;
            border-top:2px solid #8FA9A9;
            border-left:2px solid #8FA9A9;
            border-collapse: collapse;
            border-radius: 4px 4px 4px 4px;
            position: absolute;
            width: 250px;
            bottom: 0;
            right:0;
            font-size:14px;
        }
 
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
     <div id="mensaje" runat="server"></div>
    <asp:Label runat="server" ID="lblBack" Visible="false" ></asp:Label>
 <br /><br />
    <h2>Reporte indicadores</h2>
    <!--<p><b>OBJETIVO ESPECÍFICO:</b> Contribuir al desarrollo de capacidades, habilidades y competencias científicas, tecnológicas y de innovación en 320 sedes educativas del Magdalena, siguiendo los lineamentos del programa Ciclón</p>-->

    <asp:Label runat="server" ID="lblCodg007" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblMomento" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblSesion" Visible="false"></asp:Label>

     <div id="accordion" runat="server" >
         
     </div>

    <table align="left" style="display:none">
        <tr>
            <td>

                 <!-- Reporte 1 -->
                    <asp:button Width="770" runat="server" ID="btnEstrategia1" CssClass="btn btn-primary" Text="Estrategia 1" OnClick="btnEstrategia1_" />

                    <!-- Momento 0 -->
                    <asp:button Width="770" runat="server" ID="btnMomento0" CssClass="btn btn-danger" Text="Momento 0" Visible="false" OnClick="btnMomento0_" />
                    <asp:Button Width="770" runat="server" ID="btnDisenoLineamientos" CssClass="btn btn-success" Text="Diseño de lineamientos y rutas metodológicas" Visible="false" OnClick="btnDisenoLineamientos_Click" />
                    <asp:Button Width="770" runat="server" ID="btnMomento0DisenoAprobacionLineamientos" CssClass="btn btn-success" Text="Diseño y aprobación de lineamientos de las ferias municipales" Visible="false" OnClick="btnMomento0DisenoAprobacionLineamientos_Click" />
                    <asp:Button Width="770" runat="server" ID="btnMomento0EspaciosMunicipales" CssClass="btn btn-success" Text="Organizar 56 espacios municipales de de apropiación social" Visible="false" OnClick="btnMomento0EspaciosMunicipales_Click" />
                    <asp:Button Width="770" runat="server" ID="btnMomento0GruposEvaluacionFeria" CssClass="btn btn-success" Text="Sedes educativas con grupos de investigación presentados para evaluación en feria" Visible="false" OnClick="btnMomento0GruposEvaluacionFeria_Click" />
                <asp:Button Width="770" runat="server" ID="btnMomento0DesarrolloPlaneacionColectiva" CssClass="btn btn-success" Text="desarrollo de la planeación colectiva" Visible="false" OnClick="btnMomento0DesarrolloPlaneacionColectiva_Click" />
                    <!-- Momento 1 -->
                    <asp:button Width="770" runat="server" ID="btnMomento1" CssClass="btn btn-danger" Text="Momento 1" Visible="false" OnClick="btnMomento1_" />
                    <asp:Button Width="770" runat="server" ID="btnDesarrolloJornadas" CssClass="btn btn-success" Text="Desarrollo de las jornadas de formación" Visible="false" OnClick="btnDesarrolloJornadas_Click" />
                    <asp:Button Width="770" runat="server" ID="btnInformeDesarrollo" CssClass="btn btn-success" Text="Informe del desarrollo de las Etapas 1, 2 y 3" Visible="false" OnClick="btnInformeDesarrollo_Click" />
                    <asp:Button Width="770" runat="server" ID="btnInformeAcompanamiento" CssClass="btn btn-success" Text="Informe del acompañamiento de las etapas 1, 2 y 3" Visible="false" OnClick="btnInformeAcompanamiento_Click" />


                    <asp:button Width="770" runat="server" ID="btnMomento3" CssClass="btn btn-danger" Text="Momento 3" Visible="false" OnClick="btnMomento3_" />
                    <asp:Button Width="770" runat="server" ID="btnGruposTrayectoriaIndagacion" CssClass="btn btn-success" Text="Grupos de investigación que elaboran el presupuesto y diseñan las trayectorias de indagación en CICLÓN" Visible="false" OnClick="btnGruposTrayectoriaIndagacion_Click" />
                    <asp:Button Width="770" runat="server" ID="btnAsesorGruposInvestigacion" CssClass="btn btn-success" Text="El asesor acompaña a los grupos de investigación a elaborar el presupuesto y desarrollar la etapa 4 Diseño de las trayectorías de indagación" Visible="false" OnClick="btnAsesorGruposInvestigacion_Click" />
                    <asp:Button Width="770" runat="server" ID="btnAsesorAcompanamiento" CssClass="btn btn-success" Text="El asesor realiza el acompañamiento a los grupos de investigación  en el desarrollo de las investigaciones." Visible="false" OnClick="btnAsesorAcompanamiento_Click" />
                
                    <asp:button Width="770" runat="server" ID="btnMomento4" CssClass="btn btn-danger" Text="Momento 4" Visible="false" OnClick="btnMomento4_" />
                    <asp:Button Width="770" runat="server" ID="btngruposInvestigacionInformesInvestigacion" CssClass="btn btn-success" Text="Los grupos de investigación elaboran el informe de investigación para lo cual retoma todos aquellos registros de las etapas de investigación que han realizado durante su desarrollo, y que de acuerdo al diseño metodológico acordado con el asesor cuentan con instrumentos y formatos de apoyo a la investigación" Visible="false" OnClick="btngruposInvestigacionInformesInvestigacion_Click" />
                    <asp:Button Width="770" runat="server" ID="btnAsesorAcompanamientoM4" CssClass="btn btn-success" Text="El asesor realiza el acompañamiento a los grupos de investigación de  para elaborar sus informes de investigación" Visible="false" OnClick="btnAsesorAcompanamientoM4_Click" />
                
                <!-- estrategia 2 -->
                    <asp:button Width="770" runat="server" ID="btnEstrategia2" CssClass="btn btn-primary" Text="Estrategia 2" OnClick="btnEstrategia2_" />
                    <!-- Momento 0 -->
                    <asp:button Width="770" runat="server" ID="btnEstra2Momento0" CssClass="btn btn-danger" Text="Momento 0" Visible="false"  OnClick="btnEstra2Momento0_Click"/>
                    <asp:Button Width="770" runat="server" ID="btnEstra2Momento0DisenLineamientos" CssClass="btn btn-success" Text="Diseño de lineamientos de la estrategia de autoformación" Visible="false" OnClick="btnEstra2Momento0DisenLineamientos_Click" />
                    <asp:Button Width="770" runat="server" ID="btnEstra2Momento0FormarMaestros" CssClass="btn btn-success" Text="Formar a los maestros(as) acompañantes  coinvestigadores e investigadores en los lineamientos " Visible="false" OnClick="btnEstra2Momento0FormarMaestros_Click" />
                    <asp:Button Width="770" runat="server" ID="btnEstra2Momento0MesasTrabajoSede" CssClass="btn btn-success" Text="Mesas de trabajo en cada una de las sedes educativas beneficiarias" Visible="false" OnClick="btnEstra2Momento0MesasTrabajoSede_Click" />
                    <asp:Button Width="770" runat="server" ID="btnEstra2Momento0InscripcionMaestros" CssClass="btn btn-success" Text="Inscripción de maestros y maestras en las líneas temáticas del Proyecto Ciclón" Visible="false" OnClick="btnEstra2Momento0InscripcionMaestros_Click" />
                    <asp:Button Width="770" runat="server" ID="btnEstra2Momento0RecursosEconomicos" CssClass="btn btn-success" Text="Entrega de recursos económicos " Visible="false" OnClick="btnEstra2Momento0RecursosEconomicos_Click" />
                
                    <!-- Momento 1 -->
                    <asp:button Width="770" runat="server" ID="btnEstra2Momento1" CssClass="btn btn-danger" Text="Momento 1" Visible="false" OnClick="btnEstra2Momento1_Click" />
                    <asp:Button Width="770" runat="server" ID="btnEstra2Momento1ConvocatoriaAcompanamiento" CssClass="btn btn-success" Text="Convocatoria y acompañamiento para la conformación de los grupos" Visible="false" OnClick="btnEstra2Momento1ConvocatoriaAcompanamiento_Click" />

                    <asp:Button Width="770" runat="server" ID="btnEstra2Momento1Session1" CssClass="btn btn-success" Text="Sesión 1" Visible="false" OnClick="btnEstra2Momento1Session1_Click" />
                    <asp:Button Width="770" runat="server" ID="btnEstra2Momento1Session2" CssClass="btn btn-success" Text="Sesión 2" Visible="false" OnClick="btnEstra2Momento1Session2_Click" />
                    <asp:Button Width="770" runat="server" ID="btnEstra2Momento1Session3" CssClass="btn btn-success" Text="Sesión 3" Visible="false" OnClick="btnEstra2Momento1Session3_Click" />

                    <!-- Momento 3 -->
                    <asp:button Width="770" runat="server" ID="btnEstra2Momento3" CssClass="btn btn-danger" Text="Momento 3" Visible="false"  OnClick="btnEstra2Momento3_Click"  />
                    <asp:Button Width="770" runat="server" ID="btnEstra2Momento3SesionFormacion2" CssClass="btn btn-success" Text="Sesión de formación  No. 2. Contexto mundial de la educación" Visible="false" OnClick="btnEstra2Momento3SesionFormacion2_Click" />
                    <!-- Momento 4 -->
                    <asp:button Width="770" runat="server" ID="btnEstra2Momento4" CssClass="btn btn-danger" Text="Momento 4" Visible="false"  OnClick="btnEstra2Momento4_Click"  />
                    <asp:Button Width="770" runat="server" ID="btnEstra2Momento4RecorridoTrayectorias" CssClass="btn btn-success" Text="Recorrido de las trayectorias de indagación. " Visible="false" OnClick="btnEstra2Momento4RecorridoTrayectorias_Click" />


               

                  <!-- estrategia 4 -->
                    <asp:button Width="770" runat="server" ID="btnEstrategia4" CssClass="btn btn-primary" Text="Estrategia 4" OnClick="btnEstrategia4_" />
                    <asp:button Width="770" runat="server" ID="btnMomentoCero" CssClass="btn btn-success" Text="Momento 0" Visible="false" OnClick="btnMomentoCero_Click" />    
                    <asp:button Width="770" runat="server" ID="btnEstra4Sesion1" CssClass="btn btn-success" Text="Sesión 1" Visible="false" OnClick="btnEstra4Sesion1_Click" />
                    <asp:button Width="770" runat="server" ID="btnEstra4Sesion2" CssClass="btn btn-success" Text="Sesión 2" Visible="false" OnClick="btnEstra4Sesion2_Click" />

                  <!-- estrategia 5 -->
                    <asp:button Width="770" runat="server" ID="btnEstrategia5" CssClass="btn btn-primary" Text="Estrategia 5" OnClick="btnEstrategia5_" />
                    <asp:button Width="770" runat="server" ID="btnDisenoLineamientosEstr5" CssClass="btn btn-success" Text="Diseño de lineamientos de la estrategia " Visible="false" OnClick="btnDisenoLineamientosEstr5_Click" />
                    <asp:button Width="770" runat="server" ID="btnFormarFuncionarios" CssClass="btn btn-success" Text="Formar a los funcionarios de la Gobernación" Visible="false" OnClick="btnFormarFuncionarios_Click" />
                    <asp:button Width="770" runat="server" ID="btnPrimeraSesion" CssClass="btn btn-success" Text="Primera sesión: Formación en Ondas y la investigación como estrategia pedagógica  " Visible="false" OnClick="btnPrimeraSesion_Click" />
                <asp:button Width="770" runat="server" ID="btnSegundaSesion" CssClass="btn btn-success" Text="Segunda sesión: Recuperación del acumulado de la experiencia de implementación de la etapa 1  " Visible="false" OnClick="btnSegundaSesion_Click" />
                <asp:button Width="770" runat="server" ID="btnTerceraSesion" CssClass="btn btn-success" Text="Tercera sesión: La sistematización como producción de saber y conocimiento " Visible="false" OnClick="btnTerceraSesion_Click" />

                <hr />
            </td>
        </tr>
        
    </table>
              
</asp:Content>

