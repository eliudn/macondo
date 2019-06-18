<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="equicategorias.aspx.cs" Inherits="equicategorias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
<div id="mensaje" runat="server"></div>
<h2 style="text-decoration: underline;">Gestion de Categoria y Fabricante de Equipos</h2><br />
    <fieldset>
<legend>Agregar Categorias</legend>
<table cellpadding="4" align="center">
<tr>
    <td>
        Nombre Categorias
    </td>
    <td>
        <asp:TextBox ID="txtNombreCategorias" runat="server" CssClass="TextBox" Width="200px" MaxLength="50"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RFVtxtNombreCategorias" runat="server" ErrorMessage="Digite Nombre"
            Text="*" Display="None" ControlToValidate="txtNombreCategorias"
            ValidationGroup="addPerfil"></asp:RequiredFieldValidator>
        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVtxtNombreCategorias" 
            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
        </ajx:ValidatorCalloutExtender>
    </td>    
    <td>
        <asp:Button ID="btnAgregarCategorai" runat="server" Text="Agregar Categoria" 
            CssClass="botones" ValidationGroup="addPerfil" 
            onclick="btnAgregarCategorai_Click" />
    </td>    
</tr>
</table>
</fieldset>
<fieldset>
<legend>Listado de Categorias</legend>

    <asp:GridView ID="GridCategorias" runat="server" CellPadding="4" DataKeyNames="cod"
        EmptyDataText="No Existen Categorias" 
        EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"        
        ForeColor="#333333" AutoGenerateColumns="false" style="margin:0 auto"
        GridLines="None" onrowdeleting="GridCategorias_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="No.">
                <ItemTemplate>
                    <%# Container.DataItemIndex +1 %>
                </ItemTemplate>
                <ItemStyle Width="40px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="cod" HeaderText="Cod" HeaderStyle-CssClass="ocultarcell">
                <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="nombre" HeaderText="Categoria">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/Imagenes/delete.png">
                <ItemStyle Width="20px" />
            </asp:CommandField>
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
    <fieldset>
        <legend>Agregar Fabricantes o Proveedores</legend>
        <table class="cajafiltroCentrado">
            <tr>
                <td>
                    Nombre:
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtNombreProve" runat="server" CssClass="TextBox" Width="410px" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVtxtNombreProve" runat="server" ErrorMessage="Digite Nombre"
                        Text="*" Display="None" ControlToValidate="txtNombreProve"
                        ValidationGroup="agregarPro"></asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RFVtxtNombreProve"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
                </tr>
            <tr>
                <td>Telefono:</td>
                <td>
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="TextBox" Width="150px"></asp:TextBox>
                </td>
                  <td>Email:</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBox" Width="200px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align:center">
                    <asp:Button ID="btnAgregarProveedor" runat="server" Text="Agregar Proveedor" ValidationGroup="agregarPro" CssClass="btn btn-primary" OnClick="btnAgregarProveedor_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend>Listado de Proveedores</legend>
         <asp:GridView ID="GridProveedores" runat="server" CellPadding="4" DataKeyNames="cod"
        EmptyDataText="No Existen Proveedores" 
        EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"        
        ForeColor="#333333" AutoGenerateColumns="false" style="margin:0 auto"
        GridLines="None" onrowdeleting="GridProveedores_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="No.">
                <ItemTemplate>
                    <%# Container.DataItemIndex +1 %>
                </ItemTemplate>
                <ItemStyle Width="40px" HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="cod" HeaderText="Cod" HeaderStyle-CssClass="ocultarcell">
                <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="nombre" HeaderText="Proveedor">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
                 <asp:BoundField DataField="telefono" HeaderText="Telefono">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
              <asp:BoundField DataField="email" HeaderText="Email">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/Imagenes/delete.png">
                <ItemStyle Width="20px" />
            </asp:CommandField>
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

