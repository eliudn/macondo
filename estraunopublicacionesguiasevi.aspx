<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="estraunopublicacionesguiasevi.aspx.cs" Inherits="estraunopublicacionesguiasevi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
  
 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
     <div id="mensaje" runat="server"></div>
    <br /><br />
  <h2>Estrategia No 1 - Cargue de evidencias <asp:Label runat="server" ID="lbltitulo" Visible="true"></asp:Label></h2>
     
        <asp:Label runat="server" Visible="false" ID="lblCodUsuario"></asp:Label>
     <asp:Label runat="server" Visible="false" ID="lblCodAsesor"></asp:Label>
     <asp:Label runat="server" Visible="false" ID="lblTipo"></asp:Label>
         <asp:Button runat="server" Text="Regresar" OnClick="btnRegresar_click" ID="btnRegresar" Visible="false" CssClass="btn btn-primary" />
        <section class="sectionpopup">
            <fieldset>
                <legend>Subir Imagen</legend>

                 <fieldset>
                <legend>Documentos</legend>
                <asp:Label ID="lblEncabezados" runat="server" Visible="false" ></asp:Label>
         <asp:Panel runat="server" ID="PanelMomento0" Visible="true">
              <asp:RadioButtonList runat="server" ID="rbtActividades">
                    <asp:ListItem Value="La Pola, Toño y sus amigos">La Pola, Toño y sus amigos</asp:ListItem>  
                    <asp:ListItem Value="Los navegantes de las fuentes hídricas">Los navegantes de las fuentes hídricas</asp:ListItem>
                    <asp:ListItem Value="Nacho Derecho en la Onda de nuestros derechos">Nacho Derecho en la Onda de nuestros derechos</asp:ListItem>
                  <asp:ListItem Value="Sofía, Inti y sus amigos en la onda de la energía para el futuro">Sofía, Inti y sus amigos en la onda de la energía para el futuro</asp:ListItem>
                </asp:RadioButtonList>
              <asp:RequiredFieldValidator runat="server" ID="rbtValideActividades" Display="Dynamic" ControlToValidate="rbtActividades" ValidationGroup="addEvidencia">
                 <img src="Imagenes/error3.png" width="15" /><b style="color:red"> Debe seleccionar una opción</b>
             </asp:RequiredFieldValidator>
         </asp:Panel>

          <asp:Panel runat="server" ID="Panel2" Visible="false">
              <asp:RadioButtonList runat="server" ID="rbtActividades2">
                    <asp:ListItem Value="Publicaciones">Publicaciones</asp:ListItem>  
                </asp:RadioButtonList>
              <asp:RequiredFieldValidator runat="server" ID="rbtValideActividades2" Display="Dynamic" ControlToValidate="rbtActividades2" ValidationGroup="addEvidencia">
                 <img src="Imagenes/error3.png" width="15" /><b style="color:red"> Debe seleccionar una opción</b>
             </asp:RequiredFieldValidator>
         </asp:Panel>

        <asp:Panel runat="server" ID="Panel3" Visible="false">
              <asp:RadioButtonList runat="server" ID="rbtActividades3">
                    <asp:ListItem Value="Guías de investigación rediseñadas">Guías de investigación rediseñadas</asp:ListItem>  
                </asp:RadioButtonList>
              <asp:RequiredFieldValidator runat="server" ID="rbtValideActividades3" Display="Dynamic" ControlToValidate="rbtActividades3" ValidationGroup="addEvidencia">
                 <img src="Imagenes/error3.png" width="15" /><b style="color:red"> Debe seleccionar una opción</b>
             </asp:RequiredFieldValidator>
         </asp:Panel>
          
        
  
         </fieldset>

                <asp:FileUpload ID="trepador" runat="server" />
                <p>Tamaño máximo: 4 MB</p>
            </fieldset>
        </section>
        <footer >
            <div style="text-align: center">
                <asp:Button ID="Button1" runat="server" Text="Subir Imagen" CssClass="btn btn-success" ValidationGroup="addEvidencia" OnClick="btnActualizarDatosTutoria_Click" />
               <%--<asp:Button runat="server" Text="Regresar" OnClick="btnRegresar_click" ID="btnRegresar" CssClass="btn btn-primary" />--%>
            </div>
        </footer>
    <%--</asp:Panel>--%>
  
     <fieldset>
     <legend>Listado de evidencias</legend>
        
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

