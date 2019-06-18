<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="lineabaseconfi.aspx.cs" Inherits="lineabaseconfi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style>
       .primeracolumna{
            text-align:right;
            font-weight:bold;
        }
    
        .auto-style1 {
            color: #FF0000;
        }
    </style>
   <script src="js/confi_generalLB.js" type="text/javascript"></script>

    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

    <div id="Chkmensajes" class="exito" style="display:none;" ></div>
<div id="mensaje" runat="server"></div><br /><br />
<h2 style="text-decoration: underline;">Configuración General de Línea Base</h2><br />

    <fieldset>
        <legend>Detalles de la configuración</legend>
        <table>
            <tr>
                <td>
                    Instrumento
                </td>
                <td>
                    <asp:DropDownList ID="dropInstrumento" runat="server" CssClass="TextBox">
                        <asp:ListItem Value="0">001A - Información básica IE</asp:ListItem>
                        <asp:ListItem Value="1">01 - Información básica IE</asp:ListItem>
                        <asp:ListItem Value="2">02 - Caracterización del Currículo</asp:ListItem>
                         <asp:ListItem Value="3">03 - Disponibilidad, acceso y uso de Tics </asp:ListItem>
                        <asp:ListItem Value="4">04 - Autopercepción docentes  CTEi-INV-NTICS </asp:ListItem>
                        <asp:ListItem Value="5">05 - Perfil Docente</asp:ListItem>
                        <asp:ListItem Value="6">06 - Estudiantes - Grupos de investigación </asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    Fecha Inicio:
                </td>
                <td>
                     <asp:TextBox ID="txtFechaIni" runat="server" CssClass="TextBox" Width="90px"></asp:TextBox>
                    <ajx:CalendarExtender ID="txtFechaIni_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFechaIni">
                    </ajx:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RFVtxtFechaIni" runat="server" Display="None" ErrorMessage="Digite Fecha Inicio" 
                        ControlToValidate="txtFechaIni" Text="*" ValidationGroup="configeneral"></asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RFVtxtFechaIni"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True" 
                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
                </tr>
            <tr>
                <td>
                    Fecha Fin:
                </td>
                <td>
                    <asp:TextBox ID="txtFechaFin" runat="server" CssClass="TextBox" Width="90px"></asp:TextBox>
                    <ajx:CalendarExtender ID="txtFechaFin_CalendarExtender" runat="server" 
                        Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFechaFin">
                    </ajx:CalendarExtender>
                    <asp:RequiredFieldValidator ID="RFVtxtFechaFin" runat="server" Display="None" ErrorMessage="Digite Fecha Final" 
                        ControlToValidate="txtFechaFin" Text="*" ValidationGroup="configeneral"></asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RFVtxtFechaFin"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True" 
                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
                    <asp:Button ID="btnGuardarConfi" runat="server" Text="Guardar" CssClass="btn btn-success" ValidationGroup="configeneral" OnClick="btnGuardarConfi_Click" />
                </td>
            </tr>
        </table>
 </fieldset>

     <fieldset>
        <legend>Detalles de la configuración del tiempo</legend>

        <table>
            <tr>
                <td>
                    <asp:CheckBox ID="chkActivarTiempo" runat="server" onClick="return time(this,event,0);" />Activar Tiempo de ejecución
                </td>
            </tr>
               <tr>
                <td>
                    Tiempo de ejecución para los instrumentos:
                </td>
                <td>
                     <asp:TextBox ID="txtTiempoejecucion" runat="server" CssClass="TextBox" Width="50"></asp:TextBox>
                     <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True" TargetControlID="txtTiempoejecucion" FilterType="Custom, Numbers" ValidChars=""></ajx:FilteredTextBoxExtender>
                <asp:RequiredFieldValidator ID="RFVtxtTiempoejecucion" runat="server" ErrorMessage="Digite el tiempo de ejecución para los instrumentos"
                Text="*" Display="None" ControlToValidate="txtTiempoejecucion" ValidationGroup="confitiempo" >
            </asp:RequiredFieldValidator>
            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="RFVtxtTiempoejecucion"
                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
            </ajx:ValidatorCalloutExtender>
                    <span class="auto-style1">*</span>El tiempo a digitar debe ser en minutos
                </td>
               
            </tr>

             <tr>
                <td colspan="4" align="center">
                    <asp:Button ID="btnGuardarConfiTiempo" runat="server" Text="Guardar" CssClass="btn btn-success" ValidationGroup="confitiempo" OnClick="btnGuardarConfiTiempo_Click" />
                </td>
            </tr>

        </table>
       
   </fieldset>
 

</asp:Content>

