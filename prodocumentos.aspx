<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="prodocumentos.aspx.cs" Inherits="prodocumentos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div>
<h2 style="text-decoration: underline;">Creación de documentos para Proyectos</h2><br />
<fieldset>
<legend>Agregar Documento</legend>
<table cellpadding="4" align="center">
<tr>
    <td>
        Nombre
    </td>
    <td>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="TextBox" Width="200px" MaxLength="50"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RFVtxtNombre" runat="server" ErrorMessage="Digite Nombre"
            Text="*" Display="None" ControlToValidate="txtNombre"
            ValidationGroup="addPerfil"></asp:RequiredFieldValidator>
        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVtxtNombre" 
            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
        </ajx:ValidatorCalloutExtender>
    </td>
    <td>
        Proyecto
    </td>    
    <td>
        <asp:DropDownList ID="dropProyecto" runat="server" CssClass="TextBox" ></asp:DropDownList>
           <asp:RequiredFieldValidator ID="RFVdropProyecto" runat="server" ErrorMessage="Seleccione el proyecto" InitialValue="Seleccione"
            Text="*" Display="None" ControlToValidate="dropProyecto"
            ValidationGroup="addPerfil"></asp:RequiredFieldValidator>
        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RFVdropProyecto" 
            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
        </ajx:ValidatorCalloutExtender>
    </td>
    <td>
        <asp:Button ID="btnAgregarDocumento" runat="server" Text="Agregar Documento" 
            CssClass="botones" ValidationGroup="addPerfil" 
            onclick="btnAgregarDocumento_Click" />
    </td>    
</tr>
</table>
</fieldset>
    <fieldset>
<legend>Listado de Documentos</legend>

    <asp:GridView ID="GridDocumentos" runat="server" CellPadding="4"
        EmptyDataText="No Existen Documentos" 
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
            <asp:BoundField DataField="cod" HeaderText="Cod Perfil" HeaderStyle-CssClass="ocultarcell">
                <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="nombre" HeaderText="Documento">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="codproyecto" HeaderText="codProyecto" HeaderStyle-CssClass="ocultarcell">
                <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:BoundField DataField="proyecto" HeaderText="Proyecto">
                <ItemStyle HorizontalAlign="Left" />
            </asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="imgEditar" runat="server" CommandName="Select" ImageUrl="~/Imagenes/edit.png" Height="20px" Width="20px" OnClick="imgEditar_Click" />

                </ItemTemplate>
                <ItemStyle Width="20px" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="imgDlete" runat="server" CommandName="Select" ImageUrl="~/Imagenes/delete.png" Height="20px" Width="20px" OnClick="imgDlete_Click" />

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
</fieldset>
     <asp:Button ID="btnShow2" runat="server" Text="Button" style="display:none" />
<ajx:modalpopupextender id="PanelEditar_Modalpopupextender" runat="server" enabled="True"
    targetcontrolid="btnShow2" popupcontrolid="PanelEditar" cancelcontrolid="btnCerrarEditar"
    backgroundcssclass="modalBackground">
</ajx:modalpopupextender>

<asp:Panel ID="PanelEditar" runat="server" CssClass="modalPopup">    
    <header class="headerpopup">        
        <div style="float:left;margin-right:15px" id="Div1">
            Edición de Proyecto
        </div>
        <div style="float:right;">
            <asp:Label ID="btnCerrarEditar" runat="server" Text="Cerrar" CssClass="botones" ></asp:Label>
        </div>
    </header>
    <section class="sectionpopup">     
        <asp:Label ID="lblCodProyecto" runat="server" Visible="false" ></asp:Label>   
        <fieldset>
            <legend>Editar municipio</legend>        
            <table align="center" cellpadding="4">
                <tr>
                    <td>
                        Nombre:
                    </td>            
                    <td colspan="3">
                        <asp:TextBox ID="txtNombreEditar" runat="server" CssClass="TextBox"  Width="400px" MaxLength="50"></asp:TextBox>                    
                        <asp:RequiredFieldValidator ID="RFVtxtNombreEditar" runat="server" ErrorMessage="Digite nombre"
                            Text="*" Display="None" ControlToValidate="txtNombreEditar"
                            ValidationGroup="Editar"></asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True" TargetControlID="RFVtxtNombreEditar" 
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>            
                </tr>   
             
                <tr>
                    <td>
                        Proyecto:
                    </td>
                    <td>
                        <asp:DropDownList ID="dropProyectoEditar" runat="server" CssClass="TextBox" ></asp:DropDownList>     
                        <asp:RequiredFieldValidator ID="RFVdropProyectoEditar" runat="server" ErrorMessage="Seleccione el proyecto" InitialValue="Seleccione"
                            Text="*" Display="None" ControlToValidate="dropProyectoEditar" 
                            ValidationGroup="Editar"></asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" Enabled="True" TargetControlID="RFVdropProyectoEditar" 
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>               
                    </td>
              
                </tr>
      
            </table> 
          
        </fieldset>  
    </section>
    <footer class="footerpopup">        
        <div style="text-align:center">
            <asp:Button ID="btnEditarProyecto" runat="server" Text="Editar" CssClass="btn btn-success" ValidationGroup="Editar" OnClick="btnEditarProyecto_Click" />                          
        </div>
    </footer>   
</asp:Panel>
</asp:Content>

