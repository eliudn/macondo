<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="conficargos.aspx.cs" Inherits="conficargos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div>
<h2 style="text-decoration: underline;">Configuración de Cargos</h2><br />
    <fieldset>
<legend>Agregar Cargo</legend>
<table cellpadding="4" align="center">
<tr>
    <td>
        Nombre
    </td>
    <td>
        <asp:TextBox ID="txtNombrePerfil" runat="server" CssClass="TextBox" Width="200px" MaxLength="50"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RFVtxtNombrePerfil" runat="server" ErrorMessage="Digite Nombre Del Cargo"
            Text="*" Display="None" ControlToValidate="txtNombrePerfil"
            ValidationGroup="addPerfil"></asp:RequiredFieldValidator>
        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVtxtNombrePerfil" 
            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
        </ajx:ValidatorCalloutExtender>
    </td>    
    <td>
        <asp:Button ID="btnAgregarPerfil" runat="server" Text="Agregar Cargo" 
            CssClass="botones" ValidationGroup="addPerfil" 
            onclick="btnAgregarPerfil_Click" />
    </td>    
</tr>
</table>
</fieldset>
    <fieldset>
<legend>Listado de Cargos</legend>

    <asp:GridView ID="GridPerfiles" runat="server" CellPadding="4" DataKeyNames="cod"
        EmptyDataText="No Existen Perfiles" 
        EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"        
        ForeColor="#333333" AutoGenerateColumns="false" style="margin:0 auto"
        GridLines="None" >
        <Columns>
           <asp:TemplateField HeaderText="No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex +1 %>
                        </ItemTemplate>        
                        <ItemStyle Width="40px" HorizontalAlign="Center" />      
           </asp:TemplateField>
            <asp:BoundField DataField="cod" HeaderText="Cod Perfil" HeaderStyle-CssClass="ocultarcell"><ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" /></asp:BoundField> 
            <asp:BoundField DataField="nombre" HeaderText="Cargo" ><ItemStyle HorizontalAlign="Left" /></asp:BoundField> 
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="ImgEliminar" runat="server" ImageUrl="~/Imagenes/delete.png" Height="20px" Width="20px" OnClientClick="if(!confirm('Desea eliminar el cargo señalado?')){ return false; };" OnClick="ImgEliminar_Click" />
                  </ItemTemplate>
                <ItemStyle Width="50px" HorizontalAlign="Center" />
            </asp:TemplateField> 

        </Columns>
        <AlternatingRowStyle BackColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
</fieldset>
</asp:Content>

