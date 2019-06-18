<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="confiemailcc.aspx.cs" Inherits="confiemailcc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div>
<h2 style="text-decoration: underline;">Configuración de Email Con Copia Oculta</h2><br />

<fieldset>
<legend>Agregar Email Con Copia Oculta</legend>
    <asp:Label ID="lblEmailViejo" runat="server" Visible="false"></asp:Label>
<table align="center">
<tr>
    <td>
        Nombre:
    </td>
    <td>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="TextBox"></asp:TextBox>
    </td>
    <td>
        Correo:
    </td>
    <td>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBox" Width="320px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFVtxtEmail" runat="server" ErrorMessage="Digite el correo"
            Text="*" Display="None" ControlToValidate="txtEmail"
            ValidationGroup="addPerfil"></asp:RequiredFieldValidator>
        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVtxtEmail" 
            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
        </ajx:ValidatorCalloutExtender>
    </td>
    <td>
        
    </td>
    <td>
        
    </td>
</tr>

<tr>
    <td colspan="4" style="text-align:center">

        <asp:Button ID="btnAgregar" runat="server"  ValidationGroup="addPerfil" Text="Agregar" CssClass="botones" OnClick="btnAgregar_Click" 
            />
    </td>
</tr>
</table>

</fieldset>
   
    <fieldset>
        <legend>Listado de correos actuales</legend>
         <asp:GridView ID="GridCorreo" runat="server" CellPadding="4" 
        EmptyDataText="No Existen Correos" 
        EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"        
        ForeColor="#333333" OnRowDataBound="GridCorreo_RowDataBound" AutoGenerateColumns="false" style="margin:0 auto"
        GridLines="None" >
        <Columns>
            <asp:TemplateField HeaderText="No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex +1 %>
                        </ItemTemplate>        
                        <ItemStyle Width="40px" HorizontalAlign="Center" />      
           </asp:TemplateField>
            <asp:BoundField DataField="codigo" HeaderText="Cod Correo" HeaderStyle-CssClass="ocultarcell"><ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" /></asp:BoundField> 
            <asp:BoundField DataField="nombre" HeaderText="Nombre" ><ItemStyle HorizontalAlign="Left" /></asp:BoundField> 
            <asp:BoundField DataField="email" HeaderText="Email" ><ItemStyle HorizontalAlign="Left" /></asp:BoundField> 
          
               <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="ImgEliminar" runat="server" ImageUrl="~/Imagenes/delete.png" Height="20px" Width="20px" OnClientClick="if(!confirm('Desea eliminar el correo señalado?')){ return false; };" OnClick="ImgEliminar_Click" />
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

