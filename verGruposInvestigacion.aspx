<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="verGruposInvestigacion.aspx.cs" Inherits="verGruposInvestigacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
   
      <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
     <link rel="stylesheet" href="//code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css"/>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>

<div id="mensaje" runat="server"></div><br /><br />
<h2 >Grupos de investigación conformados por Asesor</h2>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <table>
                <tr>
                    <td>Asesor</td>
                    <td>
                          <asp:UpdatePanel runat="server" ID="UpdatePanel13" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="dropAsesor" CssClass="TextBox" AutoPostBack="true" OnSelectedIndexChanged="dropAsesor_OnSelectedIndexChanged"></asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="RFVdropAsesor" runat="server" ErrorMessage="Seleccione el Asesor"
                                        Text="*" Display="None" ControlToValidate="dropAsesor" InitialValue="Seleccione"
                                        ValidationGroup="Buscar"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" Enabled="True" TargetControlID="RFVdropAsesor"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                    </ContentTemplate>
                              </asp:UpdatePanel>

                    </td>
                </tr>
            </table>
            <div style="text-align:right;margin:10px;">
                <input type="text" class="TextBox" id="buscar" placeholder="Buscar..."  onkeyup="doSearch('buscar','MainContent_GridGrupo');"/>
            </div>
            <asp:GridView ID="GridGrupo" runat="server" CellPadding="4" 
                    ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto"
                    EmptyDataText="No existen Grupos de investigación."
                    GridLines="None">
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex +1 %>
                            </ItemTemplate>
                            <ItemStyle Width="40px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="codproyectosede" HeaderText="codproyectosede" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nomasesor" HeaderText="Asesor">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="nomdepartamento" HeaderText="Departamento">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="nommunicipio" HeaderText="Municipio">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="nominstitucion" HeaderText="Institución">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="nomsede" HeaderText="Sede">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nombregrupo" HeaderText="Grupo">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>

                           <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                Integrantes
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgVerEstudiantes" runat="server" CommandName="Select" ImageUrl="~/Imagenes/ver.png" Height="20px" Width="20px" OnClick="imgVerEstudiantes_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>

                         <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                            <HeaderTemplate>
                                Docentes acompañantes
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgVerDocentes" runat="server" CommandName="Select" ImageUrl="~/Imagenes/ver.png" Height="20px" Width="20px" OnClick="imgVerDocentes_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="nomarea" HeaderText="Línea de Investigación">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nomlinea" HeaderText="Tipo de Investigación" >
                            <ItemStyle HorizontalAlign="Center"  />
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

             <div id="dialog-formEstudiantes" style="display:none;" title="Estudiante">

                 <asp:Label ID="lblEstudiantes" runat="server" Visible="true"></asp:Label>

                 </div>

            <div id="dialog-formDocentes" style="display:none;" title="Docentes">

                <asp:Label ID="lblDocentes" runat="server" Visible="true"></asp:Label>

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

