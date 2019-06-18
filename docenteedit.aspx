<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="docenteedit.aspx.cs" Inherits="docenteedit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <meta charset="utf-8">
    <title>Hoja de vida Docente</title>
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
            <h2>Edición de Docentes</h2>
        </div>
        <div style="float: right;margin-top: 20px">
            <a href="docenteslistado.aspx" id="btnRegresar" runat="server" class="btn btn-primary">Volver</a>
        </div>
    </div><br /><br /><br />
    <fieldset>
        <legend>Datos del docente</legend>
        <asp:Label ID="lblCodCliente" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblCodUsuario" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblCodDANE" runat="server" Visible="false"></asp:Label>
         <asp:Label ID="lblCC" runat="server" Visible="false"></asp:Label>

        <table class="cajafiltroCentrado" >
            <tr>
                <td>
                    Tipo de Documento
                </td>
                <td>
                    <asp:DropDownList ID="dropTipoDocumento" runat="server" CssClass="TextBox">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Identificación
                </td>
                <td>
                    <asp:TextBox ID="txtidentificacion" runat="server" CssClass="TextBox" Width="200px"></asp:TextBox>
                    <ajx:FilteredTextBoxExtender ID="txtidentificacion_FilteredTextBoxExtender" runat="server" Enabled="True" TargetControlID="txtidentificacion" FilterType="Custom, Numbers" ValidChars=""></ajx:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RFVtxtidentificacion" runat="server" ErrorMessage="Digite la Identificacion Del Docente"
                        Text="*" Display="None" ControlToValidate="txtidentificacion" ValidationGroup="add">
                    </asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True" TargetControlID="RFVtxtidentificacion"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
                <td>Nombre
                </td>
                <td>
                  <asp:TextBox ID="txtNombre" runat="server" CssClass="TextBox" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVtxtNombre" runat="server" ErrorMessage="Digite el Nombre del Docente"
                        Text="*" Display="None" ControlToValidate="txtNombre" ValidationGroup="add">
                    </asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVtxtNombre"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
                <td>Apellido</td>
                 <td>
                   <asp:TextBox ID="txtApellido" runat="server" CssClass="TextBox" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVtxtApellido" runat="server" ErrorMessage="Digite el Apellido del Docente"
                        Text="*" Display="None" ControlToValidate="txtApellido" ValidationGroup="add">
                    </asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender26" runat="server" Enabled="True" TargetControlID="RFVtxtApellido"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <td>Sexo
                </td>
                <td>
                    <asp:DropDownList ID="dropSexo" runat="server" CssClass="TextBox">
                        <asp:ListItem>M</asp:ListItem>
                        <asp:ListItem>F</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>Fecha de Nacimiento
                </td>
                <td>
                     <asp:TextBox ID="txtFechaIni" runat="server" CssClass="TextBox" Width="90px"></asp:TextBox>
                    <ajx:CalendarExtender ID="txtFechaIni_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFechaIni">
                    </ajx:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RFVtxtFechaIni" runat="server" Display="None" ErrorMessage="Digite Fecha Nacimiento" 
                        ControlToValidate="txtFechaIni" Text="*" ValidationGroup="configeneral"></asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RFVtxtFechaIni"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True" 
                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
                  <td>Telefono
                </td>
                <td>
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="TextBox" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
              
               <td>Email
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBox" Width="250px"></asp:TextBox>

                </td>
                <td>Dirección</td>
                 <td >
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="TextBox" Width="150px"></asp:TextBox>
                </td>
                  <td style="text-align: center" colspan="2">
                    <asp:Button ID="Button1" ValidationGroup="add" runat="server" CssClass="btn btn-success" Text="Actualizar" OnClick="btnEditarCliente_Click" />
                </td>
            </tr>
    
        </table>
    </fieldset>
  
</asp:Content>

