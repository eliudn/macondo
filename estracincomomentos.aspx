<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estracincomomentos.aspx.cs" Inherits="estracincomomentos" %>

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

        $(document).ready(function () {
            $("#MainContent_accordion2").accordion({
                heightStyle: "content",
                active: "1" //Colocas comillas para que no se abra ninguno, quitas comillas y colocas un numero si quieres que se visualize algun panel
            });
            $("#MainContent_accordion2").attr("style", "visibility:visible;");

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
                 $("#MainContent_accordion2").accordion({
                     heightStyle: "content",
                     active: p
                 });
             });
         }
    </script>

 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
     <div id="mensaje" runat="server"></div>
    <asp:Label runat="server" ID="lblBack" Visible="false" ></asp:Label>
 <br /><br />
    <h2>Estrategia No. 5</h2>
    <%--<p><b>OBJETIVO ESPECÍFICO:</b> Contribuir al desarrollo de capacidades, habilidades y competencias científicas, tecnológicas y de innovación en 320 sedes educativas del Magdalena, siguiendo los lineamentos del programa Ciclón</p>--%>

    <asp:Label runat="server" ID="lblCodg007" Visible="false"></asp:Label>

    <asp:Label runat="server" ID="lblMomento" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblSesion" Visible="false"></asp:Label>


     <div id="accordion" runat="server" >
         
     </div>

    <div id="accordion2" runat="server" >
         
     </div>

    <table align="left" style="display:none">
        <tr>
            <td>
                 <!-- UniMag, Estrategia Nro. 5 Momento 0 -->
                <asp:button runat="server" ID="btnSesion0" CssClass="btn btn-primary" Text="Sesión 0: Gestión y desarrollo de la estrategias del proyecto" Width="610" OnClick="btnSesion0_Click" /><br />
                <asp:Button runat="server" ID="btnG004Sesion0" CssClass="btn btn-success" Text="Informe de avance para la Supervisión y/o interventoría" Width="610" Visible="false" OnClick="btnG004Sesion0_Click" />
                <asp:Button runat="server" ID="btnG009Sesion0" CssClass="btn btn-success" Text="Informe de producción de sistematización" Visible="false" Width="610" OnClick="btnG009Sesion0_Click" />
                <br />
                <asp:button runat="server" ID="btnSesion0Consolidacion" CssClass="btn btn-primary" Text="Sesión 0: Consolidación del comité departamental" Width="610" OnClick="btnSesion0Consolidacion_Click" /><br />
                <asp:Button runat="server" ID="btnSesion0G003Consolidacion" CssClass="btn btn-success" Text="Carta de compromiso y/o intensión de particpación en el Comité Departamental" Width="610" Visible="false" OnClick="btnSesion0G003Consolidacion_Click" />
                <asp:Button runat="server" ID="btnSesion0S10Consolidacion" CssClass="btn btn-success" Text="Acta de reunión" Visible="false" Width="610" OnClick="btnSesion0S10Consolidacion_Click" />
                <asp:Button runat="server" ID="btnSesion0G001Consolidacion" CssClass="btn btn-success" Text="Registro de asistencia a eventos" Visible="false" Width="610" OnClick="btnSesion0G001Consolidacion_Click" />
                <br />
                <asp:button runat="server" ID="btnSesion0ComitesSugregionales" CssClass="btn btn-primary" Text="Sesión 0: Creación de los comites subregionales" Width="610" OnClick="btnSesion0ComitesSugregionales_Click" /><br />
                <asp:Button runat="server" ID="btnSesion0G003ComitesSugregionales" CssClass="btn btn-success" Text="Carta de compromiso y/o intensión de particpación en el Comité Departamental" Visible="false" Width="610" OnClick="btnSesion0G003ComitesSugregionales_Click" />
                <asp:Button runat="server" ID="btnSesion0S10ComitesSugregionales" CssClass="btn btn-success" Text="Acta de reunión" Visible="false" Width="610" OnClick="btnSesion0S10ComitesSugregionales_Click" />
                <asp:Button runat="server" ID="btnSesion0G001ComitesSugregionales" CssClass="btn btn-success" Text="Registro de asistencia a eventos" Visible="false" Width="610" OnClick="btnSesion0G001ComitesSugregionales_Click" />
                <br />
                <asp:button runat="server" ID="btnSesion0ApoyoGruposInvestigacion" CssClass="btn btn-primary" Text="Sesión 0: Creacion, fortalecimiento y desarrollo de la red de apoyo de los grupos de investigación" Width="610" OnClick="btnSesion0ApoyoGruposInvestigacion_Click" /><br />
                <asp:Button runat="server" ID="btnSesion0S10ApoyoGruposInvestigacion" CssClass="btn btn-success" Text="Acta de reunión" Visible="false" Width="610" OnClick="btnSesion0S10ApoyoGruposInvestigacion_Click" />
                <asp:Button runat="server" ID="btnSesion0G001ApoyoGruposInvestigacion" CssClass="btn btn-success" Text="Registro de asistencia a eventos" Visible="false" Width="610" OnClick="btnSesion0G001ApoyoGruposInvestigacion_Click" />
                <hr />
            </td>
        </tr>

    </table>

    <table style="display:none">
        <tr>
            <td>
                <asp:button runat="server" ID="btnSesion1FormacionOnda" CssClass="btn btn-primary" Text="Sesión 1: Formación en Ondas y la investigación como estrategia pedagogica" Width="610" OnClick="btnSesion1FormacionOnda_Click" /><br />
                <asp:Button runat="server" ID="btnSesion1Tema1" CssClass="btn btn-success" Text="Sesión 1 - Tema 1: Conocimiento y apropiación del proyecto" Visible="false" Width="610" OnClick="btnSesion1Tema1_Click" />
                <asp:Button runat="server" ID="btnSesion1Tema1G001" CssClass="btn btn-danger" Text="Sesión 1 - Tema 1: Registro asistencia evento" Visible="false" Width="610" OnClick="btnSesion1Tema1G001_Click" />
                <asp:Button runat="server" ID="btnSesion1Tema1S005" CssClass="btn btn-danger" Text="Sesión 1 - Tema 1: Relatos Individuales" Visible="false" Width="610" OnClick="btnSesion1Tema1S005_Click" />
                <asp:Button runat="server" ID="btnSesion1Tema1S006" CssClass="btn btn-danger" Text="Sesión 1 - Tema 1: Relatos institucionales" Visible="false" Width="610" OnClick="btnSesion1Tema1S006_Click" />
                 <asp:Button runat="server" ID="btnSesion1Tema1S004" CssClass="btn btn-danger" Text="Sesión 1 - Tema 1: Memorias de plenarias " Visible="false" Width="610" OnClick="btnSesion1Tema1S004_Click" />
                <asp:Button runat="server" ID="btnSesion1Tema1G002" CssClass="btn btn-danger" Text="Sesión 1 - Tema 1: Memorias de plenarias " Visible="false" Width="610" OnClick="btnSesion1Tema1G002_Click" />
                <hr />
            </td>
        </tr>
    </table>

     <table style="display:none">
        <tr>
            <td>
                <asp:button runat="server" ID="btnSesion2FormacionOnda" CssClass="btn btn-primary" Text="Sesión 2: Formación en Ondas y la investigación como estrategia pedagogica" Width="610" OnClick="btnSesion2FormacionOnda_Click" /><br />
                <asp:Button runat="server" ID="btnSesion2Tema1" CssClass="btn btn-success" Text="Sesión 2 - Tema 1: Ondas y su estrategía metodologica" Visible="false" Width="610" OnClick="btnSesion2Tema1_Click" />
                <asp:Button runat="server" ID="btnSesion2Tema1G001" CssClass="btn btn-danger" Text="Sesión 2 - Tema 1: Registro asistencia evento" Visible="false" Width="610" OnClick="btnSesion2Tema1G001_Click" />
                <asp:Button runat="server" ID="btnSesion2Tema1S005" CssClass="btn btn-danger" Text="Sesión 2 - Tema 1: Relatos Individuales" Visible="false" Width="610" OnClick="btnSesion2Tema1S005_Click" />
                <asp:Button runat="server" ID="btnSesion2Tema1S006" CssClass="btn btn-danger" Text="Sesión 2 - Tema 1: Relatos institucionales" Visible="false" Width="610" OnClick="btnSesion2Tema1S006_Click" />
                 <asp:Button runat="server" ID="btnSesion2Tema1S004" CssClass="btn btn-danger" Text="Sesión 2 - Tema 1: Memorias de plenarias " Visible="false" Width="610" OnClick="btnSesion2Tema1S004_Click" />
                <asp:Button runat="server" ID="btnSesion2Tema1G002" CssClass="btn btn-danger" Text="Sesión 2 - Tema 1: Memorias de plenarias " Visible="false" Width="610" OnClick="btnSesion2Tema1G002_Click" />
                <hr />
            </td>
        </tr>
    </table>

    <%--  <table>
        <tr>
            <td>
                <asp:button runat="server" ID="btnSesion3FormacionOnda" CssClass="btn btn-primary" Text="Sesión 3: Formación en Ondas y la investigación como estrategia pedagogica" Width="610" OnClick="btnSesion3FormacionOnda_Click" /><br />
                <asp:Button runat="server" ID="btnSesion3Tema1" CssClass="btn btn-success" Text="Sesión 3 - Tema 1: Conocimiento y apropiación del proyecto" Visible="false" Width="610" OnClick="btnSesion3Tema1_Click" />
                <asp:Button runat="server" ID="btnSesion3Tema1G001" CssClass="btn btn-danger" Text="Sesión 3 - Tema 1: Registro asistencia evento" Visible="false" Width="610" OnClick="btnSesion3Tema1G001_Click" />
                <asp:Button runat="server" ID="btnSesion3Tema1S005" CssClass="btn btn-danger" Text="Sesión 3 - Tema 1: Relatos Individuales" Visible="false" Width="610" OnClick="btnSesion3Tema1S005_Click" />
                <asp:Button runat="server" ID="btnSesion3Tema1S006" CssClass="btn btn-danger" Text="Sesión 3 - Tema 1: Relatos institucionales" Visible="false" Width="610" OnClick="btnSesion3Tema1S006_Click" />
                 <asp:Button runat="server" ID="btnSesion3Tema1S004" CssClass="btn btn-danger" Text="Sesión 3 - Tema 1: Memorias de plenarias " Visible="false" Width="610" OnClick="btnSesion3Tema1S004_Click" />
                <asp:Button runat="server" ID="btnSesion3Tema1G002" CssClass="btn btn-danger" Text="Sesión 3 - Tema 1: Memorias de plenarias " Visible="false" Width="610" OnClick="btnSesion3Tema1G002_Click" />
                <hr />
            </td>
        </tr>
    </table>--%>
              
</asp:Content>

