<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="confiredtematicaagregar.aspx.cs" Inherits="confiredtematicaagregar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
   
   
 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
   <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
     <div id="mensaje" runat="server"></div>
        <br /><br />
    <h2>Creación de Redes Temáticas</h2>

    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>

            <div style="float: right;margin-top:-20px;">
                <a href="confiredtematicalistado.aspx" class="btn btn-primary">Volver</a>
                <%--<asp:Button ID="lnkVolver" runat="server" CssClass="btn btn-primary" OnClick="lnkVolver_Click" Text="Volver" />--%>
            </div>
            <br />

          

               <table>
                    <tr>
              <td>Año de la red</td>
               <td>
                             <asp:UpdatePanel runat="server" ID="UpdatePanel5" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="dropAniored" CssClass="TextBox"></asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="RFVdropAniored" runat="server" ErrorMessage="Seleccione el anio de la red"
                                        Text="*" Display="None" ControlToValidate="dropAniored" InitialValue="Seleccione"
                                        ValidationGroup="Buscar"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" Enabled="True" TargetControlID="RFVdropAniored"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                 </ContentTemplate>
                             </asp:UpdatePanel>
                </td>
            </tr>
                       <tr>
              <td>Departamento</td>
               <td>
                             <asp:UpdatePanel runat="server" ID="UpdatePanel11" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="dropDepartamento" CssClass="TextBox" AutoPostBack="true" OnSelectedIndexChanged="dropDepartamento_SelectedIndexChanged" ></asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="RFVdropDepartamento" runat="server" ErrorMessage="Seleccione el departamento"
                                        Text="*" Display="None" ControlToValidate="dropDepartamento" InitialValue="Seleccione"
                                        ValidationGroup="Buscar"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True" TargetControlID="RFVdropDepartamento"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                 </ContentTemplate>
                             </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                         <td>Municipio:</td>
                         <td>

                               <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional">
                                 <ContentTemplate>
                                     <asp:DropDownList runat="server" ID="dropMunicipio" CssClass="TextBox" UpdateMode="Conditional" AutoPostBack="true" OnSelectedIndexChanged="dropMunicipio_SelectedIndexChanged" ></asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="RFVdropMunicipio" runat="server" ErrorMessage="Seleccione el municipio"
                                        Text="*" Display="None" ControlToValidate="dropMunicipio" InitialValue="Seleccione"
                                        ValidationGroup="Buscar"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True" TargetControlID="RFVdropMunicipio"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="dropDepartamento" EventName="SelectedIndexChanged" />
                                </Triggers>
                             </asp:UpdatePanel>

                         </td>
                     </tr>
                     <tr>
                        <td>Institución:</td>
                        <td>
                             <asp:UpdatePanel runat="server" ID="UpdatePanel2" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList runat="server" ID="dropInstituciones" CssClass="TextBox" AutoPostBack="true" OnSelectedIndexChanged="dropInstituciones_SelectedIndexChanged" ></asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="RFVdropInstituciones" runat="server" ErrorMessage="Seleccione la institución"
                                        Text="*" Display="None" ControlToValidate="dropInstituciones" InitialValue="Seleccione"
                                        ValidationGroup="Buscar"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVdropInstituciones"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                 </ContentTemplate>
                                  <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="dropMunicipio" EventName="SelectedIndexChanged" />
                                </Triggers>
                             </asp:UpdatePanel>
                        </td>
                    </tr>
                     <tr>
                         <td>Sede:</td>
                         <td>

                               <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                                 <ContentTemplate>
                                     <asp:DropDownList runat="server" ID="dropSedes" CssClass="TextBox" UpdateMode="Conditional" ></asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="RFVdropSedes" runat="server" ErrorMessage="Seleccione la sede"
                                        Text="*" Display="None" ControlToValidate="dropSedes" InitialValue="Seleccione"
                                        ValidationGroup="Buscar"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RFVdropSedes"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="dropInstituciones" EventName="SelectedIndexChanged" />
                                </Triggers>
                             </asp:UpdatePanel>

                         </td>
                     </tr>
                   <tr>
                       <td>Asesor</td>
                       <td>
                             <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                 <ContentTemplate>
                                     <asp:DropDownList runat="server" ID="dropAsesor" CssClass="TextBox" UpdateMode="Conditional" ></asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="RFVdropAsesor" runat="server" ErrorMessage="Seleccione el asesor"
                                        Text="*" Display="None" ControlToValidate="dropAsesor" InitialValue="Seleccione"
                                        ValidationGroup="Buscar"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="RFVdropAsesor"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                </ContentTemplate>
                              </asp:UpdatePanel>
                       </td>
                   </tr>
                   <tr>
                       <td>Red Temática</td>
                       <td>
                           <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                                 <ContentTemplate>
                                     <asp:DropDownList runat="server" ID="dropRedTematica" CssClass="TextBox" UpdateMode="Conditional" ></asp:DropDownList>
                                      <asp:RequiredFieldValidator ID="RFVdropRedTematica" runat="server" ErrorMessage="Seleccione la Red Temática"
                                        Text="*" Display="None" ControlToValidate="dropRedTematica" InitialValue="Seleccione"
                                        ValidationGroup="Buscar"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True" TargetControlID="RFVdropRedTematica"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                </ContentTemplate>
                              </asp:UpdatePanel>
                       </td>
                   </tr>
                <%--   <tr>
                       <td>Cantidad de grupos a crear</td>
                       <td>
                           <asp:DropDownList ID="dropCantidad" runat="server" CssClass="TextBox">
                               <asp:ListItem>1</asp:ListItem>
                               <asp:ListItem>2</asp:ListItem>
                               <asp:ListItem>3</asp:ListItem>
                               <asp:ListItem>4</asp:ListItem>
                               <asp:ListItem>5</asp:ListItem>
                               <asp:ListItem>6</asp:ListItem>
                               <asp:ListItem>7</asp:ListItem>
                               <asp:ListItem>8</asp:ListItem>
                               <asp:ListItem>9</asp:ListItem>
                               <asp:ListItem>10</asp:ListItem>
                               <asp:ListItem>11</asp:ListItem>
                               <asp:ListItem>12</asp:ListItem>
                               <asp:ListItem>13</asp:ListItem>
                               <asp:ListItem>14</asp:ListItem>
                               <asp:ListItem>15</asp:ListItem>
                               <asp:ListItem>16</asp:ListItem>
                               <asp:ListItem>17</asp:ListItem>
                               <asp:ListItem>18</asp:ListItem>
                               <asp:ListItem>19</asp:ListItem>
                               <asp:ListItem>20</asp:ListItem>
                           </asp:DropDownList>
                       </td>
                   </tr>--%>
                   <tr>
                       <td>Selecione los Grupos de <br />los Grados participantes</td>
                       <td>
                             <asp:GridView ID="GridGrados" runat="server" CellPadding="4" DataKeyNames="codigo"
                                    ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto"
                                    EmptyDataText="No existen grados"
                                    GridLines="None">
                                    <Columns>
                                         <asp:BoundField DataField="nombre" HeaderText="Grados participantes">
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:BoundField>

                                           <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                            <HeaderTemplate>
                                                Grupos
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                 <asp:CheckBoxList runat="server" ID="chkGrupos" RepeatDirection="Horizontal">
                                                     <asp:ListItem>1</asp:ListItem>
                                                     <asp:ListItem>2</asp:ListItem>
                                                     <asp:ListItem>3</asp:ListItem>
                                                     <asp:ListItem>4</asp:ListItem>
                                                     <asp:ListItem>5</asp:ListItem>
                                                     <asp:ListItem>6</asp:ListItem>
                                                     <asp:ListItem>7</asp:ListItem>
                                                     <asp:ListItem>8</asp:ListItem>
                                                     <asp:ListItem>9</asp:ListItem>
                                                 </asp:CheckBoxList>
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
                          
                       </td>
                   </tr>
                   <tr>
                       <td>
                           <asp:LinkButton runat="server" ID="lnkAgregar" CssClass="btn btn-success" Text="Agregar" OnClick="lnkAgregar_Click" ></asp:LinkButton>
                       </td>
                   </tr>
               </table>

                <asp:Label runat="server" ID="lblResultado" Visible="true"></asp:Label>
                <asp:Label runat="server" ID="lblCodDepartamento" Visible="false"></asp:Label>
                <asp:Label runat="server" ID="lblCodRed" Visible="false"></asp:Label>
                <asp:Label runat="server" ID="lblCodMunicipio" Visible="false"></asp:Label>
                <asp:Label runat="server" ID="lblCodInstitucion" Visible="false"></asp:Label>
                <asp:Label runat="server" ID="lblCodSede" Visible="false"></asp:Label>
                <asp:Label runat="server" ID="lblCodAnio" Visible="false"></asp:Label>

        </ContentTemplate>
    </asp:UpdatePanel>
   
</asp:Content>

