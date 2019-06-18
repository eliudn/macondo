<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="confirol.aspx.cs" Inherits="confirol" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div>
<h2 style="text-decoration: underline;">Configuración de Roles</h2><br />
<fieldset>
<legend>Agregar Roles De Usuarios</legend>
<table cellpadding="4" align="center">
<tr>
   <td>Perfil</td>
    <td>
         <asp:DropDownList ID="DropPerfil" runat="server" CssClass="TextBox" 
            Width="235px">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RFVDropPerfil" runat="server" ErrorMessage="Seleccione Perfil"
            Text="*" Display="None" ControlToValidate="DropPerfil" InitialValue="Seleccione..."
            ValidationGroup="addRol"></asp:RequiredFieldValidator>
        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="RFVDropPerfil" 
            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
        </ajx:ValidatorCalloutExtender>
    </td>   
     <td>
        Rol
    </td>
    <td>
        <asp:TextBox ID="txtNombreRol" runat="server" CssClass="TextBox" Width="200px" MaxLength="50"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RFVtxtNombreRol" runat="server" ErrorMessage="Digite Nombre Del Rol"
            Text="*" Display="None" ControlToValidate="txtNombreRol"
            ValidationGroup="addRol"></asp:RequiredFieldValidator>
        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVtxtNombreRol" 
            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
        </ajx:ValidatorCalloutExtender>
    </td> 
    <td>
        <asp:Button ID="btnAgregartxtNombreRol" runat="server" Text="Agregar Rol" 
            CssClass="botones" ValidationGroup="addRol" 
            onclick="btnAgregarRol_Click" />
    </td>    
</tr>
</table>
</fieldset>

<fieldset>
<legend>Listado de Roles con Perfiles</legend>

    <asp:GridView ID="GridRolPerfiles" runat="server" CellPadding="4" DataKeyNames="codrol"
        EmptyDataText="No Existen Roles con Perfiles asociados" 
        EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"        
        ForeColor="#333333" AutoGenerateColumns="false" style="margin:0 auto"
        GridLines="None" onrowdeleting="GridRolPerfiles_RowDeleting" onrowdatabound="GridRolPerfiles_RowDataBound" >
        <Columns>
            <asp:BoundField DataField="codrol" HeaderText="Cod Rol" HeaderStyle-CssClass="ocultarcell"><ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" /></asp:BoundField> 
            <asp:BoundField DataField="nomrol" HeaderText="Rol" ><ItemStyle HorizontalAlign="Left" /></asp:BoundField> 
            <asp:BoundField DataField="codperfil" HeaderText="Cod Perfil" HeaderStyle-CssClass="ocultarcell"><ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" /></asp:BoundField> 
            <asp:BoundField DataField="nomperfil" HeaderText="Perfil de acceso" ><ItemStyle HorizontalAlign="Left" /></asp:BoundField> 
            <asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/Imagenes/delete.png"><ItemStyle Width="20px" /></asp:CommandField>      
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
    <br /><p align="center"><i>En este listado se asocia que <b>Rol</b> tiene acceso a que <b>Perfil</b> para la asignación de los menús, recuerde que en la asociación los nombre deben ser iguales. </i></p>
</fieldset>
    <fieldset>
        <legend>Disponibles</legend>
        <table cellpadding="4" align="center">
<tr>
    <td>
        Seleccione Rol:
    </td>
    <td>
        <asp:DropDownList ID="DropRol" runat="server" CssClass="TextBox" 
            Width="235px">
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RFVDropRol" runat="server" ErrorMessage="Seleccione Rol"
            Text="*" Display="None" ControlToValidate="DropRol" InitialValue="Seleccione..."
            ValidationGroup="Usuario"></asp:RequiredFieldValidator>
        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RFVDropRol" 
            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
        </ajx:ValidatorCalloutExtender>
        <asp:Label ID="lblPerfilEsc" runat="server" Visible="false"></asp:Label>
    </td>
    <td>
        <asp:Button ID="btnSeleccioneRol" runat="server" Text="Seleccionar" 
            CssClass="botones" ValidationGroup="Usuario" 
            onclick="btnSeleccioneRol_Click" />
    </td>
</tr>
</table>
       </fieldset>
        <fieldset>
            <legend>Asociar Rol con Perfil</legend>
        
<asp:Panel ID="PanelPerfiles" runat="server" Visible="False" style="margin-top:10px;">
   
        
<table align="center">
<tr>
    <td>
        Menus del Perfil: 
        <asp:Label ID="lblPerfil" runat="server" style="font-weight: 700"></asp:Label><br />
      <%--  <asp:ListBox ID="lbMenusPerfil" runat="server" Height="400px" Width="100%" style="font-size:15px"></asp:ListBox>--%>
        <div style="height:400px;  overflow-y:scroll">
         <asp:GridView ID="GridMenuPerfil" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" style="margin:0 auto;font-size:13px"
        EmptyDataText="No Hay Menus Para este perfil" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red" DataKeyNames="consecutivo"
        AutoGenerateColumns="false"   Width="450px" >
             <Columns>
                 <asp:TemplateField>
                     <ItemTemplate>
                         <asp:CheckBox ID="cbItem" runat="server" />
                     </ItemTemplate>
                     <ItemStyle Width="50px" HorizontalAlign="Center" />
                 </asp:TemplateField>
                 <asp:BoundField SortExpression="consecutivo" DataField="consecutivo" HeaderText="Cod Menu" HeaderStyle-CssClass="ocultarcell">
                     <ItemStyle CssClass="ocultarcell" HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField SortExpression="modulo" DataField="modulo" HeaderText="Modulo">
                     <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                  <asp:BoundField SortExpression="menu" DataField="menu" HeaderText="Menu">
                     <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                  <asp:BoundField SortExpression="link" DataField="link" HeaderText="Link">
                     <ItemStyle HorizontalAlign="Center" />
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
            </div>
    </td>
     
    <td>
        <asp:Button ID="btnPasar" runat="server" Text="<< Pasar" CssClass="botones" 
            onclick="btnPasar_Click" />
        <br /><br />
        <asp:Button ID="btnEliminardePerfil" runat="server" Text="Quitar >>"  CssClass="botones"
            onclick="btnEliminardePerfil_Click" />
    </td>
    <td>
        Menus Disponibles en la Plataforma
        <br />
<%--        <asp:ListBox ID="lbMenus" runat="server" Height="400px" Width="100%"  style="font-size:15px"></asp:ListBox>--%>
        <div style="height:400px;  overflow-y:scroll">
          <asp:GridView ID="GridMenus" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" style="margin:0 auto;font-size:13px"
        EmptyDataText="No Hay Menus Para este perfil" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red" DataKeyNames="cod"
        AutoGenerateColumns="false"  Width="450px" >
             <Columns>
                 <asp:TemplateField>
                     <ItemTemplate>
                         <asp:CheckBox ID="cbDisponibles" runat="server" />
                     </ItemTemplate>
                     <ItemStyle Width="50px" HorizontalAlign="Center" />
                 </asp:TemplateField>
                 <asp:BoundField SortExpression="cod" DataField="cod" HeaderText="Cod Menu" HeaderStyle-CssClass="ocultarcell">
                     <ItemStyle CssClass="ocultarcell" HorizontalAlign="Center" />
                 </asp:BoundField>
                   <asp:BoundField SortExpression="modulo" DataField="modulo" HeaderText="Modulo">
                     <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                 <asp:BoundField SortExpression="nombre" DataField="nombre" HeaderText="Menu">
                     <ItemStyle HorizontalAlign="Center" />
                 </asp:BoundField>
                <asp:BoundField SortExpression="link" DataField="link" HeaderText="Link">
                     <ItemStyle HorizontalAlign="Center" />
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
            </div>
    </td>
</tr>

</table>
        
    </asp:Panel>
    </fieldset>

</asp:Content>

