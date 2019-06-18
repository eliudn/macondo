<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="verinforector.aspx.cs" Inherits="verinforector" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <meta charset="utf-8">
    <title>Hoja de vida Cliente</title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script>
        $(document).ready(function () {
            $("#accordion").accordion({
                heightStyle: "content",
                active: "1" //Colocas comillas para que no se abra ninguno, quitas comillas y colocas un numero si quieres que se visualize algun panel
            });
            $("#accordion").attr("style", "visibility:visible;");

        });

    </script>
    <script>
        function abrir(panel) {
            var p = parseInt(panel);
            $(function () {
                $("#accordion").accordion({
                    heightStyle: "content",
                    active: p
                });
            });
        }
    </script>
    <script>
        //Funcion que muestra información al clicar en checkbox
        function mostrarCapa(elem) {
            if (elem.checked) {
                document.getElementById('MainContent_txtIpRouterAdd').value = 'NO APLICA';
                document.getElementById('MainContent_txtIpRouterAdd').disabled = true;
            } else {
                document.getElementById('MainContent_txtIpRouterAdd').value = '';
                document.getElementById('MainContent_txtIpRouterAdd').disabled = false;
                document.getElementById('MainContent_txtIpRouterAdd').focus();
            }
        }
        function mostrarCapa2(elem) {
            if (elem.checked) {
                document.getElementById('MainContent_txtIpAntenaAdd').value = 'NO APLICA';
                document.getElementById('MainContent_txtIpAntenaAdd').disabled = true;
            } else {
                document.getElementById('MainContent_txtIpAntenaAdd').value = '';
                document.getElementById('MainContent_txtIpAntenaAdd').disabled = false;
                document.getElementById('MainContent_txtIpAntenaAdd').focus();
            }
        }
        function mostrarCapa3(elem) {
            if (elem.checked) {
                document.getElementById('MainContent_txtIpRouteEdit').value = 'NO APLICA';
                document.getElementById('MainContent_txtIpRouteEdit').disabled = true;
            } else {
                document.getElementById('MainContent_txtIpRouteEdit').value = '';
                document.getElementById('MainContent_txtIpRouteEdit').disabled = false;
                document.getElementById('MainContent_txtIpRouteEdit').focus();
            }
        }
        function mostrarCapa4(elem) {
            if (elem.checked) {
                document.getElementById('MainContent_txtIpAntenaEdit').value = 'NO APLICA';
                document.getElementById('MainContent_txtIpAntenaEdit').disabled = true;
            } else {
                document.getElementById('MainContent_txtIpAntenaEdit').value = '';
                document.getElementById('MainContent_txtIpAntenaEdit').disabled = false;
                document.getElementById('MainContent_txtIpAntenaEdit').focus();
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" runat="server"></asp:ScriptManager>
     <asp:Label ID="lblTipoUsuario" runat="server" Visible="false"></asp:Label>
    <div id="mensaje" runat="server"></div><br /><br />
    <div class="header">
        <div style="float: left; margin-right: 15px">
            <h2>Información del rector</h2>
        </div>
        <div style="float: right;">
            <a href="sedeslistado.aspx" id="btnRegresar" runat="server" class="btn btn-primary">Volver</a>
        </div>
    </div><br /><br /><br />
  
    <fieldset>
        <legend>Información</legend>
      
       <asp:Label ID="lblDatosRector" runat="server"></asp:Label>

    </fieldset>
   
    <asp:Label ID="lblIDRector" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblCodUsuarioRol" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblCodSede" runat="server" Visible="false"></asp:Label>

</asp:Content>

