<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="menu.aspx.cs" Inherits="menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>


<div id="mensaje" runat="server"></div><br /><br />
<h2 style="text-decoration: underline;">Menús</h2><br />
<fieldset>
<legend>Nuevo Item de Menú</legend>
<table cellpadding="4" align="center">
<tr>
    <td>
        Nombre
    </td>
    <td>
        <asp:TextBox ID="txtNombreItem" runat="server" CssClass="TextBox"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RFVtxtNombreItem" runat="server" ErrorMessage="Digite Nombre Del Item"
            Text="*" Display="None" ControlToValidate="txtNombreItem"
            ValidationGroup="Perf"></asp:RequiredFieldValidator>
        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RFVtxtNombreItem" 
            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
        </ajx:ValidatorCalloutExtender>
    </td>
    <td>
        Nivel
    </td>
    <td>
        <asp:DropDownList ID="DropNivelItem" runat="server" CssClass="TextBox">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
        </asp:DropDownList>
    </td>
    <td>
        Link
    </td>
    <td>
        <asp:TextBox ID="txtLinkItem" runat="server" CssClass="TextBox"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RFVtxtLinkItem" runat="server" ErrorMessage="Digite Link del Item"
            Text="*" Display="None" ControlToValidate="txtLinkItem"
            ValidationGroup="Perf"></asp:RequiredFieldValidator>
        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVtxtLinkItem" 
            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
        </ajx:ValidatorCalloutExtender>
    </td>

    <td>
        <asp:Button ID="btnPosicionar" runat="server" Text="Posicionar"  ValidationGroup="Perf"
            CssClass="botones" onclick="btnPosicionar_Click" />
    </td>
</tr>
</table>
<asp:Panel ID="Panel2Nivel" runat="server" Visible="false">
<table cellpadding="4" align="center">
<tr>
    <td>
        Debajo de:
    </td>
    <td>
        <asp:DropDownList ID="DropCodSuperior" runat="server" CssClass="TextBox">
        </asp:DropDownList>
    </td>
    <td>
        <asp:Button ID="btnPosicionar2" runat="server" Text="Guardar Item" 
            CssClass="botones" onclick="btnPosicionar2_Click" ValidationGroup="Perf"/>
    </td>
</tr>
</table>
</asp:Panel>
</fieldset>
    <center>
        <asp:GridView ID="GridMenu" runat="server" CellPadding="4" ForeColor="#333333"
            AutoGenerateColumns="false" AllowSorting="true"
            EmptyDataText="No Hay Resultados"
            EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"
            GridLines="None">
            <Columns>
                <asp:BoundField DataField="cod" HeaderText="COD" HeaderStyle-CssClass="ocultarcell">
                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nombre" HeaderText="Nombre Menu">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nivel" HeaderText="Nivel">
                    <ItemStyle Width="50px" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="orden" HeaderText="Orden">
                    <ItemStyle Width="50px" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="codsuperior" HeaderText="Cod Superior" HeaderStyle-CssClass="ocultarcell">
                    <ItemStyle CssClass="ocultarcell" Width="120px" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nombresuperior" HeaderText="Padre">
                    <ItemStyle Width="120px" HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="link" HeaderText="Link">
                    <ItemStyle HorizontalAlign="Right" Width="300px" />
                </asp:BoundField>
       
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
    </center>
    



</asp:Content>

