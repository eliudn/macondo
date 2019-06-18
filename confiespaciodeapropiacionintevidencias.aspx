<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="confiespaciodeapropiacionintevidencias.aspx.cs" Inherits="confiespaciodeapropiacionevidencias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
  
 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
     <div id="mensaje" runat="server"></div>
    <br /><br />
  <h2>Estrategia No 1 - Cargue de evidencias Espacio de apropiación por Feria Internacional</h2>
     
        <asp:Label runat="server" Visible="false" ID="lblCodUsuario"></asp:Label>
        <asp:Label runat="server" Visible="false" ID="lblCodDepartamento"></asp:Label>
        <asp:Label runat="server" Visible="false" ID="lblCodEspacio"></asp:Label>
         
  <%--  <table>
        <tr>
            <td>Municipios</td>
            <td>
                <asp:DropDownList runat="server" ID="DropMunicipiosCargar" CssClass="TextBox" ></asp:DropDownList>
                  <asp:RequiredFieldValidator ID="RFVDropMunicipiosCargar" runat="server" ErrorMessage="Seleccione el Municipio para la evidencia" InitialValue="Seleccione"
                        Text="*" Display="None" ControlToValidate="DropMunicipiosCargar"
                        ValidationGroup="addPerfil"></asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RFVDropMunicipiosCargar"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
            </td>
        </tr>
    </table>--%>

        <section class="sectionpopup">
            <fieldset>
                <legend>Subir Imagen</legend>

                 <fieldset>
                <legend>Actividades</legend>
                <asp:Label ID="lblEncabezados" runat="server" Visible="true" ></asp:Label>
         <asp:Panel runat="server" ID="PanelMomento0" Visible="true">
              <asp:RadioButtonList runat="server" ID="rbtActividades">
                    <asp:ListItem>Agenda</asp:ListItem>  
                    <asp:ListItem>Fotos</asp:ListItem>
                    <asp:ListItem>Informe de ferias</asp:ListItem>
                    <asp:ListItem>Formato de evaluación</asp:ListItem>
                    
                </asp:RadioButtonList>
         </asp:Panel>
          
         <asp:RequiredFieldValidator runat="server" ID="rbtValideActividades" Display="Dynamic" ControlToValidate="rbtActividades" ValidationGroup="addEvidencia">
             <img src="Imagenes/error3.png" width="15" /><b style="color:red"> Debe seleccionar una opción</b>
         </asp:RequiredFieldValidator>
  
         </fieldset>

                <asp:FileUpload ID="trepador" runat="server" />
                <p>Tamaño máximo: 4 MB</p>
            </fieldset>
        </section>
        <footer >
            <div style="text-align: center">
                <asp:Button ID="Button1" runat="server" Text="Cargar" CssClass="btn btn-success" ValidationGroup="addEvidencia" OnClick="btnActualizarDatosTutoria_Click" />
               <asp:Button runat="server" Text="Regresar" OnClick="btnRegresar_click" ID="btnRegresar" CssClass="btn btn-primary" />
            </div>
        </footer>
    <%--</asp:Panel>--%>
  
     <fieldset>
     <legend>Listado de evidencias</legend>
         <table>
            <%-- <tr>
                 <td>Municipio</td>
             </tr>
             <tr> <td> <asp:DropDownList runat="server" ID="DropMunicipiosBuscar" CssClass="TextBox"></asp:DropDownList></td></tr>--%>
             <tr>
                 <td>
                     <asp:RadioButtonList runat="server" ID="rbtActividadesBuscar"  AutoPostBack="true" OnSelectedIndexChanged="rbtActividadesBuscar_OnSelectedIndexChanged">
                        <asp:ListItem>Agenda</asp:ListItem>  
                        <asp:ListItem>Fotos</asp:ListItem>
                        <asp:ListItem>Informe de ferias</asp:ListItem>
                        <asp:ListItem>Formato de evaluación</asp:ListItem>
                     </asp:RadioButtonList>
                 </td>
             </tr>
         </table>
        
           
        
      <asp:GridView ID="GridEvidencias" runat="server" CellPadding="4" DataKeyNames="cod" CssClass="mGridTesoreria"  UseAccessibleHeader="true" ClientIDMode="Static"
                        EmptyDataText="No se encontraron Datos" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"
                        ForeColor="#333333"  AutoGenerateColumns="false" Style="margin: 0 auto" 
                        GridLines="None" >
                        <Columns>
                            <asp:TemplateField HeaderText="No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex +1 %>
                                </ItemTemplate>
                                <ItemStyle Width="40px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="nombrearchivo" HeaderText="Nombre archivo">
                                <ItemStyle HorizontalAlign="Center" Width="120px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="tamano"  HeaderText="Tamaño" >
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            
                            <asp:BoundField DataField="actividad" HeaderText="Actividad">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                              <asp:BoundField DataField="fechacreado" HeaderText="Fecha subida">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                              <asp:BoundField DataField="nombre" HeaderText="Nombre">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nombreguardado" HeaderText="Guardado" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle HorizontalAlign="Center" CssClass="ocultarcell" />
                            </asp:BoundField>
                            <asp:BoundField DataField="path" HeaderText="Path" HeaderStyle-CssClass="ocultarcell">
                                <ItemStyle HorizontalAlign="Left" CssClass="ocultarcell" />
                            </asp:BoundField>


                            <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgDescargar" runat="server" CommandName="Select" ImageUrl="~/Imagenes/down.png" Height="20px" Width="20px" OnClick="imgDescargar_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                             <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/delete.png" Height="20px" Width="20px" OnClientClick="if(!confirm('¿Está Seguro en eliminar este registro?')){ return false; };" OnClick="DeleteButton_Click" />
                                 </ItemTemplate> 

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

