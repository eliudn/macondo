<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="confiuser.aspx.cs" Inherits="confiuser" %>

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
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div><br /><br />
<h2 style="text-decoration: underline;">CONFIGURACIÓN DE USUARIOS</h2><br />
<fieldset>
<legend>Agregar Usuario</legend>

<table align="center" style="background-color: #ECECEC; padding: 10px; border-radius: 5px;">
    <tr style="border-top:1px solid #ccc;">
        <td>
            Usuario <span class="auto-style1">*</span>
        </td>
        <td>
            <asp:TextBox ID="txtUser" runat="server"  CssClass="TextBox" Width="200px" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFVtxtUser" runat="server" ErrorMessage="Digite Nombre Del Usuario"
                Text="*" Display="None" ControlToValidate="txtUser"
                ValidationGroup="addUsuario"></asp:RequiredFieldValidator>
            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True" TargetControlID="RFVtxtUser" 
                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
            </ajx:ValidatorCalloutExtender>
        </td>
        <td>
            Contraseña <span class="auto-style1">*</span>
        </td>
        <td>
            <asp:TextBox ID="txtPass" runat="server" CssClass="TextBox" Width="200px" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFVtxtPass" runat="server" ErrorMessage="Digite la constraseña"
                Text="*" Display="None" ControlToValidate="txtPass"
                ValidationGroup="addUsuario"></asp:RequiredFieldValidator>
            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True" TargetControlID="RFVtxtPass" 
                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
            </ajx:ValidatorCalloutExtender>
        </td>      
    </tr>
    <tr>
        <td colspan="4">
            <hr />
        </td>
    </tr>
    <tr>  
        <td>
           Identificación <span class="auto-style1">*</span>
        </td>
        <td>
             <asp:TextBox ID="txtIdentificacion" runat="server" CssClass="TextBox" Width="200px" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFVtxtIdentificacion" runat="server" ErrorMessage="Digite la identificación"
                Text="*" Display="None" ControlToValidate="txtIdentificacion"
                ValidationGroup="addUsuario"></asp:RequiredFieldValidator>
            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RFVtxtIdentificacion" 
                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
            </ajx:ValidatorCalloutExtender>
        </td> 
    </tr>
    
    <tr>  
        <td>
            Primer Nombre <span class="auto-style1">*</span>
        </td>
        <td>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="TextBox" Width="200px" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFVtxtNombre" runat="server" ErrorMessage="Digite su nombre"
                Text="*" Display="None" ControlToValidate="txtNombre"
                ValidationGroup="addUsuario"></asp:RequiredFieldValidator>
            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="RFVtxtNombre" 
                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
            </ajx:ValidatorCalloutExtender>
        </td>
        <td>
            Segundo Nombre
        </td>
        <td>
            <asp:TextBox ID="txtSNombre" runat="server" CssClass="TextBox" Width="200px" MaxLength="50"></asp:TextBox>
        </td>         
    </tr>
    <tr>
        <td>
           Primer Apellido <span class="auto-style1">*</span>
        </td>
        <td>
            <asp:TextBox ID="txtApellidos" runat="server" CssClass="TextBox" Width="200px" MaxLength="50"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFVtxtApellidos" runat="server" ErrorMessage="Digite sus apellidos"
                Text="*" Display="None" ControlToValidate="txtApellidos"
                ValidationGroup="addUsuario"></asp:RequiredFieldValidator>
            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" Enabled="True" TargetControlID="RFVtxtApellidos" 
                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
            </ajx:ValidatorCalloutExtender>
        </td>
             <td>
           Segundo Apellido
        </td>
        <td>
            <asp:TextBox ID="txtSApellido" runat="server" CssClass="TextBox" Width="200px" MaxLength="50"></asp:TextBox>
    
        </td>  
          
    </tr>
    <tr>
        <td>
            Teléfono
        </td>
        <td>
           <asp:TextBox ID="txtTelefono" runat="server" CssClass="TextBox" Width="200px" MaxLength="20"></asp:TextBox>
        </td> 
         <td>
            Celular
        </td>
        <td>
            <asp:TextBox ID="txtCelular" runat="server" CssClass="TextBox" Width="200px" MaxLength="100"></asp:TextBox>
        </td>
    </tr>
    <tr>
       <td>
            E-mail 
        </td>
        <td colspan="3">
            <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBox" Width="525px" MaxLength="100"></asp:TextBox>
            <asp:RegularExpressionValidator ID="REVtxtEmail" runat="server" ErrorMessage="Email Incorrecto" Display="None"
                ControlToValidate="txtEmail" ValidationGroup="addUsuario"
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                Style="color: #FF0000"></asp:RegularExpressionValidator>
            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender21"
                runat="server" Enabled="True" TargetControlID="REVtxtEmail"
                HighlightCssClass="Highlight" PopupPosition="BottomLeft"
                Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
            </ajx:ValidatorCalloutExtender>
        </td>
    </tr>
    <tr>
        <td>
            Rol <span class="auto-style1">*</span>
        </td>
        <td colspan="3" style="text-align:center">
            <asp:DropDownList ID="DropRolesAdd" CssClass="TextBox" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropRolesAdd_OnSelectedIndexChanged"></asp:DropDownList>
             <asp:RequiredFieldValidator ID="RFVDropRolesAdd" runat="server" InitialValue="Seleccione" ErrorMessage="Seleccione un rol"
                Text="*" Display="None" ControlToValidate="DropRolesAdd"
                ValidationGroup="addUsuario"></asp:RequiredFieldValidator>
            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" Enabled="True" TargetControlID="RFVDropRolesAdd" 
                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
            </ajx:ValidatorCalloutExtender>
            <%--<asp:CheckBoxList ID="cblRoles" runat="server" RepeatColumns="5" CssClass="TextBox">
                    </asp:CheckBoxList>--%>
        </td>
    </tr>
    
    <tr>
        <td colspan="4">
            <fieldset>
                <legend>Unificar</legend>

                  <asp:Panel ID="PanelEstraCoordinador" Visible="false" runat="server">
                <table align="center">
                    <tr>
                        <td>Estrategia</td>
                        <td><asp:DropDownList ID="dropEstrategias" runat="server" CssClass="TextBox" AutoPostBack="true" OnSelectedIndexChanged="dropEstrategias_OnSelectedIndexChanged"></asp:DropDownList></td>
                        <td>Coordinador</td>
                        <td><asp:DropDownList ID="dropCoordinador" runat="server" CssClass="TextBox"></asp:DropDownList></td>
                    </tr>
                </table>
           </asp:Panel>
        <asp:Panel ID="PanelEstrategias" Visible="false" runat="server">
                <table align="center">
                    <tr>
                        <td>Estrategia</td>
                        <td><asp:DropDownList ID="dropEstrategia2" runat="server" CssClass="TextBox"></asp:DropDownList></td>
                    </tr>
                </table>
           </asp:Panel>

            </fieldset>
         

        </td>
    </tr>
  
    <tr>
    <td colspan="6" style="text-align:center">
        <asp:Button ID="btnAgregarUsuario" runat="server" Text="Agregar Usuario"  ValidationGroup="addUsuario"
            CssClass="btn btn-success" OnClick="btnAgregarUsuario_Click" />
    </td>
</tr>
   
</table>
</fieldset>
   
<fieldset>
<legend>Listado de Usuarios</legend>

    <table class="cajafiltroCentrado"><tr><td>Filtrar</td><td><asp:DropDownList id="dropRoles" runat="server" CssClass="TextBox" AutoPostBack="true" OnSelectedIndexChanged="dropRoles_SelectedIndexChanged"></asp:DropDownList></td>  </tr></table>
        <center>
    <asp:Label ID="lblNoDatos" runat="server" 
        style="font-weight: 700; color: #CC0000"></asp:Label></center>
    <p style="text-align:center;margin:0 auto">Para buscar un usuario, presione la tecla <b>F3</b> o <b>Ctrl + F</b>.</p>
    <asp:GridView ID="GridUsuarios" runat="server" CellPadding="4" DataKeyNames="cod"
        ForeColor="#333333" AutoGenerateColumns="false" style="margin:0 auto"
        GridLines="None" onrowdatabound="GridUsuarios_RowDataBound" EmptyDataText="No se encontraron Usuarios" 
        onrowdeleting="GridUsuarios_RowDeleting">
        <Columns>
            <asp:TemplateField HeaderText="No.">
                <ItemTemplate>
                    <%# Container.DataItemIndex +1 %>
                </ItemTemplate>        
                <ItemStyle Width="40px" HorizontalAlign="Center" />      
            </asp:TemplateField> 
            <asp:BoundField DataField="usuario" HeaderText="Usuario" ><ItemStyle HorizontalAlign="Left" /></asp:BoundField>  
            <asp:BoundField DataField="nombres" HeaderText="Nombres" ><ItemStyle HorizontalAlign="Left" /></asp:BoundField>  
            <asp:BoundField DataField="apellidos" HeaderText="Apellidos" ><ItemStyle HorizontalAlign="Left" /></asp:BoundField> 
            <asp:BoundField DataField="identificacion" HeaderText="Identificacion" ><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
            <asp:BoundField DataField="email" HeaderText="E-Mail"><ItemStyle HorizontalAlign="Left" /></asp:BoundField>  
            <asp:BoundField DataField="celular" HeaderText="Celular"><ItemStyle HorizontalAlign="Right" /></asp:BoundField> 
            <asp:BoundField DataField="telefono" HeaderText="Telefono"><ItemStyle HorizontalAlign="Right" /></asp:BoundField> 
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Select" ImageUrl="~/Imagenes/edit.png" Height="20px" Width="20px" OnClick="ImageButton1_Click" />
                </ItemTemplate>
                <ItemStyle Width="20px" />
            </asp:TemplateField>   
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

</fieldset>

<asp:Button ID="btnShow" runat="server" style="display:none"/>
<ajx:modalpopupextender id="PanelVerDependencias_ModalPopupExtender" runat="server" enabled="True"
    targetcontrolid="btnShow" popupcontrolid="PanelVerDependencias" cancelcontrolid="btnCancelar"
    backgroundcssclass="modalBackground">
</ajx:modalpopupextender>

<asp:Panel ID="PanelVerDependencias" runat="server" CssClass="modalPopup">
    <asp:Label ID="lblCodUsuario" runat="server" Visible="false" ></asp:Label>
     <asp:Label ID="lblID" runat="server" Visible="false" ></asp:Label>

<fieldset>
<legend>Edicion de Usuario</legend>
<table cellpadding="4" align="center">
<tr>
    <td class="primeracolumna">
        Usuario<span class="auto-style1">*</span>
    </td>
    <td >
        <asp:TextBox ID="txtUsuario2" runat="server" CssClass="TextBox" Width="185px" ></asp:TextBox>
        <asp:RequiredFieldValidator ID="RFVtxtUsuario2" runat="server" ErrorMessage="Digite Usuario De Acceso"
            Text="*" Display="None" ControlToValidate="txtUsuario2"
            ValidationGroup="editUsuario"></asp:RequiredFieldValidator>
        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" Enabled="True" TargetControlID="RFVtxtUsuario2" 
            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
        </ajx:ValidatorCalloutExtender>
    </td>
    <td>
        Contraseña
    </td>
    <td>
        <asp:LinkButton ID="lnkReestablecerContra" runat="server" 
            onclick="lnkReestablecerContra_Click">Reestablecer Contraseña</asp:LinkButton>
    </td>
</tr>
<tr>
    <td class="primeracolumna">
       Primer Nombre<span class="auto-style1">*</span>
    </td>
    <td>
        <asp:TextBox ID="txtNombre2" runat="server" CssClass="TextBox" Width="185px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RFVtxtNombres2" runat="server" ErrorMessage="Digite Nombres"
            Text="*" Display="None" ControlToValidate="txtNombre2"
            ValidationGroup="editUsuario"></asp:RequiredFieldValidator>
        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" Enabled="True" TargetControlID="RFVtxtNombres2" 
            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
        </ajx:ValidatorCalloutExtender>
    </td>    
    <td>
       Segundo Nombre
    </td>
    <td>
          <asp:TextBox ID="txtSNombre2" runat="server" CssClass="TextBox" Width="185px"></asp:TextBox>
    
    </td>
</tr>
<tr>
    <td class="primeracolumna">
        Primer Apellido<span class="auto-style1">*</span>
    </td>
    <td>
        <asp:TextBox ID="txtApellido2" runat="server" CssClass="TextBox" Width="185px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFVtxtApellido2" runat="server" ErrorMessage="Digite Apellido"
            Text="*" Display="None" ControlToValidate="txtApellido2"
            ValidationGroup="editUsuario"></asp:RequiredFieldValidator>
        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVtxtApellido2" 
            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
        </ajx:ValidatorCalloutExtender>
    </td>
    <td>
        Segundo Apellido
    </td>
    <td>
      <asp:TextBox ID="txtSApellido2" runat="server" CssClass="TextBox" Width="185px"></asp:TextBox>
    </td>
</tr>
<tr>
    <td class="primeracolumna">
        Identificación:<span class="auto-style1">*</span>
    </td>
    <td>
       <asp:TextBox ID="txtIdentificacion2" runat="server" CssClass="TextBox" Width="185px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RFVtxtIdentificacion2" runat="server" ErrorMessage="Digite Identificacion"
            Text="*" Display="None" ControlToValidate="txtIdentificacion2"
            ValidationGroup="editUsuario"></asp:RequiredFieldValidator>
        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True" TargetControlID="RFVtxtIdentificacion2" 
            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
        </ajx:ValidatorCalloutExtender>
    </td>
     <td>
        Estado:
    </td>
    <td>
       <asp:DropDownList ID="dropEstado" runat="server" >
           <asp:ListItem Value="On">ON</asp:ListItem>
           <asp:ListItem Value="Off">OFF</asp:ListItem>
       </asp:DropDownList>
    </td>
</tr>
    <tr>
    <td >
        Email:
    </td>
    <td>
        <asp:TextBox ID="txtEmail2" runat="server" CssClass="TextBox" Width="185px"></asp:TextBox>
        <asp:RegularExpressionValidator ID="REVtxtEmail2" runat="server" ErrorMessage="Email Incorrecto" Display="None"
            ControlToValidate="txtEmail2" ValidationGroup="editUsuario"
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
            Style="color: #FF0000"></asp:RegularExpressionValidator>
        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender9"
            runat="server" Enabled="True" TargetControlID="REVtxtEmail2"
            HighlightCssClass="Highlight" PopupPosition="BottomLeft"
            Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
        </ajx:ValidatorCalloutExtender>

    </td>
     <td>
        Celular:
    </td>
    <td>
     <asp:TextBox ID="txtCelular2" runat="server" CssClass="TextBox" Width="185px"></asp:TextBox>
    </td>
</tr>
  <tr>
    <td>
        Telefono:
    </td>
    <td>
       <asp:TextBox ID="txtTelefono2" runat="server" CssClass="TextBox" Width="185px"></asp:TextBox>
        
    </td>
        <td>
            Rol
        </td>
      <td>
          <asp:DropDownList ID="DropRolesEdit" CssClass="TextBox" runat="server"></asp:DropDownList>
             <asp:RequiredFieldValidator ID="RFVDropRolesEdit" runat="server" InitialValue="Seleccione" ErrorMessage="Seleccione un rol"
                Text="*" Display="None" ControlToValidate="DropRolesEdit"
                ValidationGroup="editUsuario"></asp:RequiredFieldValidator>
            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" Enabled="True" TargetControlID="RFVDropRolesEdit" 
                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
            </ajx:ValidatorCalloutExtender>
          <%--<asp:CheckBoxList ID="cblRol2" CssClass="TextBox" runat="server" RepeatDirection="Horizontal" RepeatColumns="2"></asp:CheckBoxList>--%>
      </td>
</tr>
    <tr>
    <td colspan="4">
        <asp:GridView ID="GridImplicados" runat="server" CellPadding="4" DataKeyNames="cod"
                            EmptyDataText="No Existen Roles Asociados"
                            EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"
                            ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto"
                            GridLines="None">
            <Columns>
                <asp:BoundField DataField="cod" HeaderText="cod" HeaderStyle-CssClass="ocultarcell">
                    <ItemStyle HorizontalAlign="Left" CssClass="ocultarcell" />
                </asp:BoundField>
                <asp:BoundField DataField="nombre" HeaderText="Rol">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEliminarRol" runat="server" CommandName="Select" ImageUrl="~/Imagenes/delete.png" Height="20px" Width="20px" OnClick="imgEliminarRol_Click" />
                    </ItemTemplate>
                    <ItemStyle Width="20px" />
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
    </td>
  
</tr>
<tr>
    <td colspan="4" style="text-align:center">
        <asp:Button ID="btnEditar" runat="server" Text="Guardar Cambios"  ValidationGroup="editUsuario"
            CssClass="btn btn-success" onclick="btnEditar_Click"/>
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="botones" 
            onclick="btnCancelar_Click"/>
    </td>
</tr>
</table>
</fieldset>

<asp:Panel ID="PanelNuevaContra" runat="server" Visible="false">    
<fieldset>
<legend>Cambio de Contraseña</legend>
<table style="border-color:Red" align="center">
<tr>
    <td>
        Nueva Contraseña
    </td>
    <td>
        <asp:TextBox ID="txtNuevaContra" runat="server" CssClass="TextBox"></asp:TextBox>
    </td>
</tr>
<tr>
    <td>
        Repita Nueva Contraseña
    </td>
    <td>
        <asp:TextBox ID="txtNuevaContra2" runat="server" CssClass="TextBox"></asp:TextBox>
    </td>
</tr>
<tr>
    <td colspan="2" style="text-align:center">
        <asp:Label ID="lblerrorcontra" runat="server" Text="Contraseñas No Coinciden" 
            style="font-weight: 700; color: #FF0000" Visible="false"></asp:Label><br />
        <asp:Button ID="btnGuardarcontra" runat="server" Text="Guardar"  
            CssClass="btn btn-success" onclick="btnGuardarcontra_Click"/>
        <asp:Button ID="btnCancelar2" runat="server" Text="Cancelar" CssClass="botones" 
            onclick="btnCancelar2_Click"/>
    </td>
</tr>
</table>
</fieldset>
</asp:Panel>
</asp:Panel>


</asp:Content>

