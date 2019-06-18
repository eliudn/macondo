<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="confiemail.aspx.cs" Inherits="confiemail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div>
<h2 style="text-decoration: underline;">Configuración de Email Remitente</h2><br />

<fieldset>
<legend>Configuración de Email Remitente</legend>
    <asp:Label ID="lblEmailViejo" runat="server" Visible="false"></asp:Label>
<table align="center">
<tr>
    <td>
        Usuario:
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
        Contraseña:
    </td>
    <td>
        <asp:TextBox ID="txtPass" runat="server" CssClass="TextBox"></asp:TextBox>
    </td>
    <td>
        
    </td>
    <td>
        
    </td>
</tr>
<tr>
    <td>
        Nombre Emisor:
    </td>
    <td>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="TextBox" Width="320px"></asp:TextBox>
    </td>
    <td>
        Asunto Mensaje:
    </td>
    <td colspan="3">
        <asp:TextBox ID="txtAsunto" runat="server" CssClass="TextBox" Width="350px"></asp:TextBox>
    </td>    
</tr>
    <tr>
        <td>
            Servidor SMTP:
        </td>
        <td>
            <asp:TextBox ID="txtSMTP" runat="server" CssClass="TextBox" Width="200px" ></asp:TextBox>
        </td>
        <td>
            Puerto:
        </td>
        <td>
            <asp:TextBox ID="txtPuerto" runat="server" CssClass="TextBox" Text="25" Width="50px"></asp:TextBox>
        </td>        
     
    </tr>
    <tr>
        <td>Ssl:
        </td>
        <td>
            <asp:DropDownList ID="dropSsl" runat="server" CssClass="TextBox">
                <asp:ListItem>false</asp:ListItem>
                <asp:ListItem>true</asp:ListItem>
            </asp:DropDownList>
        </td>
        <td>Tipo:
        </td>
        <td>
            <asp:DropDownList ID="dropTipo" runat="server" CssClass="TextBox">
                <asp:ListItem Value="1">Emisor</asp:ListItem>
                <asp:ListItem Value="2">Receptor</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
<tr>
    <td colspan="4" style="text-align:center">
     <%--   <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="botones" 
            onclick="btnEditar_Click" />--%>
        <asp:Button ID="btnAgregar" runat="server"  ValidationGroup="addPerfil" Text="Agregar" CssClass="botones" OnClick="btnAgregar_Click" 
            />
    </td>
</tr>
</table>

</fieldset>
    Recomendaciones:<br />
    <ul>
        <li>
            GMAIL: smtp:  smtp.gmail.com, port: 25, ssl: true.
        </li>
        <li>
            HOTMAIL: smtp: smtp.live.com, port:25, ssl: true.
        </li>
        <li>
            GODADDY: smtp: smtpout.europe.secureserver.net, port:25, ssl: false.
        </li>
        <li>
            DONGEE: smtp: smtp.sismag.co, port: 25, ssl:false.
        </li>
    </ul>

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
            <asp:BoundField DataField="cod" HeaderText="Cod Correo" HeaderStyle-CssClass="ocultarcell"><ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" /></asp:BoundField> 
            <asp:BoundField DataField="email" HeaderText="Email" ><ItemStyle HorizontalAlign="Left" /></asp:BoundField> 
            <asp:BoundField DataField="port" HeaderText="Puerto" ><ItemStyle HorizontalAlign="Left" /></asp:BoundField> 
            <asp:BoundField DataField="servidorsmtp" HeaderText="SMTP" ><ItemStyle HorizontalAlign="Left" /></asp:BoundField> 
            <asp:BoundField DataField="tipo" HeaderText="CodTipo" HeaderStyle-CssClass="ocultarcell"><ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" /></asp:BoundField> 
          
             <asp:TemplateField>
                 <HeaderTemplate>
                     Tipo
                 </HeaderTemplate>
                <ItemTemplate>
                  <asp:Label ID="lblTipoCorreo" runat="server"></asp:Label> 
                </ItemTemplate>
                <ItemStyle Width="50px" HorizontalAlign="Center" />
            </asp:TemplateField>

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

