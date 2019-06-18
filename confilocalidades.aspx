<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="confilocalidades.aspx.cs" Inherits="confilocalidades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
    <div id="mensaje" runat="server"></div>
<h2 style="text-decoration: underline;">Gestion de Departamentos y Municipios.</h2><br />
<fieldset>
<legend>Agregar Departamento</legend>
<table cellpadding="4" align="center">
<tr>
    <td>
        Nombre Departamento
    </td>
    <td>
        <asp:TextBox ID="txtNombreDepartamento" runat="server" CssClass="TextBox" Width="200px" MaxLength="50"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RFVtxtNombreDepartamento" runat="server" ErrorMessage="Digite Nombre Del Departamento"
            Text="*" Display="None" ControlToValidate="txtNombreDepartamento"
            ValidationGroup="addPerfil"></asp:RequiredFieldValidator>
        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVtxtNombreDepartamento" 
            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
        </ajx:ValidatorCalloutExtender>
    </td>    
    <td>
        <asp:Button ID="btnAgregarDepartamento" runat="server" Text="Agregar Departamento" 
            CssClass="botones" ValidationGroup="addPerfil" 
            onclick="btnAgregarDepartamento_Click" />
    </td>    
</tr>
</table>
</fieldset>
    <fieldset>
<legend>Listado de Departamentos</legend>

    <asp:GridView ID="GridDepartamento" runat="server" CellPadding="4" 
        EmptyDataText="No Existen Departamentos" 
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
            <asp:BoundField DataField="cod" HeaderText="Cod Departamento" HeaderStyle-CssClass="ocultarcell"><ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" /></asp:BoundField> 
            <asp:BoundField DataField="nombre" HeaderText="Departamento" ><ItemStyle HorizontalAlign="Left" /></asp:BoundField> 
               <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="ImgEliminar" runat="server" ImageUrl="~/Imagenes/delete.png" Height="20px" Width="20px" OnClientClick="if(!confirm('Desea eliminar el departamento señalado?')){ return false; };" OnClick="ImgEliminar_Click" />
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
    <fieldset>
<legend>Agregar Municipio</legend>
<table cellpadding="4" align="center">
<tr>
    <td>
        Nombre :
    </td>
    <td>
        <asp:TextBox ID="txtMunicipio" runat="server" CssClass="TextBox" Width="200px" MaxLength="50"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RFVtxtMunicipio" runat="server" ErrorMessage="Digite Nombre Del Municipio"
            Text="*" Display="None" ControlToValidate="txtMunicipio"
            ValidationGroup="addMunicipio"></asp:RequiredFieldValidator>
        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RFVtxtMunicipio" 
            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
        </ajx:ValidatorCalloutExtender>
    </td>   
       <td>
      Departamento
    </td>
    <td>
       <asp:DropDownList ID="dropDepartamento" runat="server" CssClass="TextBox"></asp:DropDownList>
           
    </td> 
    <td>
       Tipo
    </td>
    <td>
        <asp:DropDownList ID="dropTipoMunicipio" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropTipoMunicipio_SelectedIndexChanged">
            <asp:ListItem Value="municipio" Selected="True">Municipio</asp:ListItem>
            <asp:ListItem Value="corregimiento">Corregimiento</asp:ListItem>
            <asp:ListItem Value="vereda">Vereda</asp:ListItem>
        </asp:DropDownList>
    
    </td> 
    <td colspan="2">
        <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="PanelPertenece" runat="server" Visible="false">
                   <asp:DropDownList ID="dropSuperior" runat="server" CssClass="TextBox"></asp:DropDownList>
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="dropTipoMunicipio" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
   
    </td> 
    <td>
        <asp:Button ID="btnAgregarMunicipio" runat="server" Text="Agregar Municipio" 
            CssClass="botones" ValidationGroup="addMunicipio" 
            onclick="btnAgregarMunicipio_Click" />
    </td>    
</tr>
</table>
</fieldset>
    <fieldset>
<legend>Listado de Municipios</legend>

    <asp:GridView ID="GridMunicipios" runat="server" CellPadding="4" 
        EmptyDataText="No Existen Municipios" 
        EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"        
        ForeColor="#333333" AutoGenerateColumns="false" style="margin:0 auto"
        GridLines="None" OnRowDataBound="GridMunicipios_RowDataBound" >
        <Columns>
            <asp:TemplateField HeaderText="No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex +1 %>
                        </ItemTemplate>        
                        <ItemStyle Width="40px" HorizontalAlign="Center" />      
           </asp:TemplateField>
            <asp:BoundField DataField="cod" HeaderText="Cod Municipio" HeaderStyle-CssClass="ocultarcell"><ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" /></asp:BoundField> 
            <asp:BoundField DataField="nombre" HeaderText="Nombre" ><ItemStyle HorizontalAlign="Left" /></asp:BoundField> 
            <asp:BoundField DataField="coddepartamento" HeaderText="Cod Departamento" HeaderStyle-CssClass="ocultarcell"><ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" /></asp:BoundField> 
            <asp:BoundField DataField="nombred" HeaderText="Departamento" ><ItemStyle HorizontalAlign="Left" /></asp:BoundField> 
            <asp:BoundField DataField="tipo" HeaderText="Tipo" ><ItemStyle HorizontalAlign="Left" /></asp:BoundField> 
            <asp:BoundField DataField="codsuperior" HeaderText="Superior" HeaderStyle-CssClass="ocultarcell" ><ItemStyle HorizontalAlign="Left" CssClass="ocultarcell" /></asp:BoundField> 
            <asp:TemplateField ItemStyle-HorizontalAlign="Center">                    
                <HeaderTemplate>
                    Pertenece
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblPertence" runat="server" ></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="ImgEditarMunicipio" runat="server" ImageUrl="~/Imagenes/edit.png" Height="20px" Width="20px" OnClick="ImgEditarMunicipio_Click" />
                    <asp:ImageButton ID="ImgEliminarMunicipio" runat="server" ImageUrl="~/Imagenes/delete.png" Height="20px" Width="20px" OnClientClick="if(!confirm('Desea eliminar el municipio señalado?')){ return false; };" OnClick="ImgEliminarMunicipio_Click" />
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

    <asp:Button ID="btnShow2" runat="server" Text="Button" style="display:none" />
<ajx:modalpopupextender id="PanelEditar_Modalpopupextender" runat="server" enabled="True"
    targetcontrolid="btnShow2" popupcontrolid="PanelEditar" cancelcontrolid="btnCerrarEditar"
    backgroundcssclass="modalBackground">
</ajx:modalpopupextender>

<asp:Panel ID="PanelEditar" runat="server" CssClass="modalPopup">    
    <header class="headerpopup">        
        <div style="float:left;margin-right:15px" id="Div1">
            Edición de Municipio
        </div>
        <div style="float:right;">
            <asp:Label ID="btnCerrarEditar" runat="server" Text="Cerrar" CssClass="botones" ></asp:Label>
        </div>
    </header>
    <section class="sectionpopup">     
        <asp:Label ID="lblCodMunicipio" runat="server" Visible="false" ></asp:Label>   
        <fieldset>
            <legend>Editar municipio</legend>        
            <table align="center" cellpadding="4">
                <tr>
                    <td>
                        Nombre:
                    </td>            
                    <td>
                        <asp:TextBox ID="txtMunicipioEditar" runat="server" CssClass="TextBox"  Width="400px" MaxLength="50"></asp:TextBox>                    
                        <asp:RequiredFieldValidator ID="RFVtxtMunicipioEditar" runat="server" ErrorMessage="Digite nombre del municipio"
                            Text="*" Display="None" ControlToValidate="txtMunicipioEditar"
                            ValidationGroup="Editar"></asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="RFVtxtMunicipioEditar" 
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>            
                </tr>   
                <tr>
                    <td>
                        Departamento:
                    </td>
                    <td>
                        <asp:DropDownList ID="dropDepartamentoEditar" runat="server" CssClass="TextBox"></asp:DropDownList>     
                        <asp:RequiredFieldValidator ID="RFVdropDepartamentoEditar" runat="server" ErrorMessage="Seleccione el departamento"
                            Text="*" Display="None" ControlToValidate="dropDepartamentoEditar" 
                            ValidationGroup="Editar"></asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True" TargetControlID="RFVdropDepartamentoEditar" 
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>               
                    </td>
                </tr>   
                <tr>
                    <td>
                        Tipo:
                    </td>
                    <td>
                        <asp:DropDownList ID="dropTipoEditar" runat="server" CssClass="TextBox" AutoPostBack="true" OnSelectedIndexChanged="dropTipoEditar_SelectedIndexChanged">
                            <asp:ListItem Value="municipio" Selected="True">Municipio</asp:ListItem>
                            <asp:ListItem Value="corregimiento">Corregimiento</asp:ListItem>
                            <asp:ListItem Value="vereda">Vereda</asp:ListItem>
                        </asp:DropDownList>
                    
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Panel ID="PanelPertenceEditar" runat="server" Visible="false">
                                    <asp:DropDownList ID="dropSuperiorEditar" runat="server" CssClass="TextBox"></asp:DropDownList>
                                </asp:Panel>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="dropTipoEditar" EventName="SelectedIndexChanged" />
                            </Triggers>
                        </asp:UpdatePanel>

                    </td>
                </tr>
            </table> 
        </fieldset>  
    </section>
    <footer class="footerpopup">        
        <div style="text-align:center">
            <asp:Button ID="btnEditarMunicipio" runat="server" Text="Editar" CssClass="btn btn-success" ValidationGroup="Editar" OnClick="btnEditarMunicipio_Click" />                          
        </div>
    </footer>   
</asp:Panel>
</asp:Content>

