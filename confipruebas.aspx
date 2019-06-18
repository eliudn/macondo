<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="confipruebas.aspx.cs" Inherits="confipruebas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div>
<h2 style="text-decoration: underline;">Configuración de Pruebas.</h2><br />

<fieldset>
<legend>Variables Para entrega de servicio.</legend>
<table align="center" class="cajafiltroCentrado">
<tr>
    <td>
        SM:
    </td>
    <td>
        <asp:TextBox ID="txtSm" runat="server" CssClass="TextBox" Width="40px" required></asp:TextBox>
          <ajx:FilteredTextBoxExtender ID="txtNota1_FilteredTextBoxExtender" runat="server" Enabled="True" TargetControlID="txtSm" FilterType="Custom, Numbers" ValidChars="-.">
                            </ajx:FilteredTextBoxExtender>
    </td>
    <td>
        CCQ:
    </td>
    <td>
        <asp:TextBox ID="txtCCQ" runat="server" CssClass="TextBox" Width="40px" required></asp:TextBox>
            %<ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True" TargetControlID="txtCCQ" FilterType="Custom, Numbers" ValidChars=".">
                            </ajx:FilteredTextBoxExtender>
    </td>
</tr>
<tr>
    <td>
        TTL Nodo:
    </td>
    <td>
        <asp:TextBox ID="txtTtlNodo" runat="server" CssClass="TextBox" Width="40px" required></asp:TextBox>
                    <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True" TargetControlID="txtTtlNodo" FilterType="Custom, Numbers" ValidChars=".">
                            </ajx:FilteredTextBoxExtender>
        MS</td>
    <td>
        TTL Web:
    </td>
    <td>
        <asp:TextBox ID="txtTtlWeb" runat="server" CssClass="TextBox" Width="40px" required></asp:TextBox>
             MS<ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" Enabled="True" TargetControlID="txtTtlWeb" FilterType="Custom, Numbers" ValidChars=".">
                            </ajx:FilteredTextBoxExtender>
    </td>    
</tr>
    <tr>
        <td>
            Ancho de Banda:
        </td>
        <td colspan="2" style="text-align:center">
            <asp:TextBox ID="txtAnchoBanda" runat="server" CssClass="TextBox" Width="40px" required> </asp:TextBox>
               %<ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" Enabled="True" TargetControlID="txtAnchoBanda" FilterType="Custom, Numbers" ValidChars=".">
                            </ajx:FilteredTextBoxExtender>
        </td>
    
    </tr>
<tr>
    <td colspan="4" style="text-align:center">
        <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="botones" 
            onclick="btnEditar_Click" />
        <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="botones" OnClick="btnAgregar_Click"  />
    </td>
</tr>
</table>

</fieldset>
</asp:Content>

