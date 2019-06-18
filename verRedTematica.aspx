<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="verRedTematica.aspx.cs" Inherits="verRedTematica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
   
      <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css"/>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div><br /><br />
<h2 >Redes Temáticas conformadas por Asesor</h2>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             Seleccione el año:
            <asp:DropDownList runat="server" ID="dropAnio" CssClass="TextBox"></asp:DropDownList>
              <asp:RequiredFieldValidator ID="RFVdropAnio" runat="server" ErrorMessage="Seleccione el año"
                Text="*" Display="None" ControlToValidate="dropAnio" InitialValue="Seleccione"
                ValidationGroup="Buscar"></asp:RequiredFieldValidator>
            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVdropAnio"
                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
            </ajx:ValidatorCalloutExtender>

            Seleccione el asesor:
            <asp:DropDownList runat="server" ID="dropAsesor" CssClass="TextBox" AutoPostBack="true" OnSelectedIndexChanged="dropAsesor_SelectedIndexChanged"></asp:DropDownList>
              <asp:RequiredFieldValidator ID="RFVdropAsesor" runat="server" ErrorMessage="Seleccione el asesor"
                Text="*" Display="None" ControlToValidate="dropAsesor" InitialValue="Seleccione"
                ValidationGroup="Buscar"></asp:RequiredFieldValidator>
            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True" TargetControlID="RFVdropAsesor"
                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
            </ajx:ValidatorCalloutExtender>
            <br /><br />
            <asp:GridView ID="GridRedTematica" runat="server" CellPadding="4" 
                    ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto"
                    EmptyDataText="No existen Redes Temáticas." CssClass="mGridTesoreria"
                    GridLines="None">
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex +1 %>
                            </ItemTemplate>
                            <ItemStyle Width="40px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="codredtematicasede" HeaderText="codredtematicasede" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                        </asp:BoundField>
                          <asp:BoundField DataField="departamento" HeaderText="Departamento">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="municipio" HeaderText="Municipio">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nominstitucion" HeaderText="Institución">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nomsede" HeaderText="Sede">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="nomasesor" HeaderText="Docente asesor">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nombre" HeaderText="Red Temática">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="aniored" HeaderText="Año de la red" >
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>

                           <asp:BoundField DataField="cantestudiantes" HeaderText="Cantidad Estudiantes" >
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>

                           <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                Integrantes
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgVerEstudiantes" runat="server" CommandName="Select" ImageUrl="~/Imagenes/ver.png" Height="20px" Width="20px" OnClick="imgVerEstudiantes_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:BoundField DataField="cantdocente" HeaderText="Cantidad Docentes" >
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>

                         <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                Docentes acompañantes
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgVerDocentes" runat="server" CommandName="Select" ImageUrl="~/Imagenes/ver.png" Height="20px" Width="20px" OnClick="imgVerDocentes_Click" />
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

             <div id="dialog-formEstudiantes" style="display:none;" title="Estudiante">
                 <div style="height: 450px !important;overflow-y: scroll;"> 
                        <asp:Label ID="lblEstudiantes" runat="server" Visible="true"></asp:Label>
                 </div>
                

                 </div>

            <div id="dialog-formDocentes" style="display:none;" title="Docentes">
                 <div style="height: 450px !important;overflow-y: scroll;"> 
                        <asp:Label ID="lblDocentes" runat="server" Visible="true"></asp:Label>
                 </div>
               

                 </div>
        </ContentTemplate>
    </asp:UpdatePanel>

      <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
          <ProgressTemplate>
              <div class="BackgroundPanel"></div>
                <div class="ProgressPanel">
                   
                </div>
          </ProgressTemplate>
      </asp:UpdateProgress>

   

</asp:Content>

