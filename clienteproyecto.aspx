<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="clienteproyecto.aspx.cs" Inherits="clienteproyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
    <div id="mensaje" runat="server"></div>
    <h2 style="text-decoration: underline;">Relacionar Clientes con Proyectos.</h2>
    <br />
    <table cellpadding="4" align="center">
        <tr>
            <td>Seleccione Proyecto:
            </td>
            <td>
                <asp:DropDownList ID="DropProyecto" runat="server" CssClass="TextBox"
                    Width="235px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RFVDropProyecto" runat="server" ErrorMessage="Seleccione Proyecto"
                    Text="*" Display="None" ControlToValidate="DropProyecto" InitialValue="Seleccione"
                    ValidationGroup="Usuario"></asp:RequiredFieldValidator>
                <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RFVDropProyecto"
                    HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                </ajx:ValidatorCalloutExtender>
                <asp:Label ID="lblPerfilEsc" runat="server" Visible="false"></asp:Label>
            </td>
            <td>
                <asp:Button ID="btnSeleccioneProyecto" runat="server" Text="Seleccionar"
                    CssClass="botones" ValidationGroup="Usuario"
                    OnClick="btnSeleccioneProyecto_Click" />
            </td>
        </tr>
    </table>
    <asp:Panel ID="PanelPerfiles" runat="server" Visible="False" Style="margin-top: 10px;">
        <asp:Label ID="lblCodDepartamento" runat="server" Visible="false"></asp:Label>
        <table align="center">
            <tr>
                <td>Clientes en el proyecto: 
        <asp:Label ID="lblProyecto" runat="server" Style="font-weight: 700"></asp:Label><br />
                    <div style="height: 400px; overflow-y: scroll">
                        <asp:GridView ID="GridClienteProyecto" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Style="margin: 0 auto; font-size: 13px"
                            EmptyDataText="No Hay Clientes en este proyecto" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red" 
                            AutoGenerateColumns="false" Width="450px">
                            <Columns>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="cbItem" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle Width="50px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField SortExpression="cod" DataField="cod" HeaderText="Cod" HeaderStyle-CssClass="ocultarcell">
                                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField SortExpression="nit" DataField="nit" HeaderText="NIT">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField SortExpression="nombre" DataField="nombre" HeaderText="Nombre">
                                    <ItemStyle HorizontalAlign="Left" />
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
                        OnClick="btnPasar_Click"  ValidationGroup="Agregar" />
                    <br />
                    <br />
                    <asp:Button ID="btnQuitar" runat="server" Text="Quitar >>" CssClass="botones"
                        OnClick="btnQuitar_Click" />
                </td>
                <td>Clientes Disponibles
                 <br />
                    <div>
                        <table>
                            <tr>
                                <td>Fecha Inicio
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFechaIni" runat="server" CssClass="TextBox" Width="90px" placeholder="dd-mm-aaaa"></asp:TextBox>
                                    <ajx:CalendarExtender ID="txtFechaIni_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtFechaIni"
                                        Format="dd-MM-yyyy" FirstDayOfWeek="Monday"></ajx:CalendarExtender>
                                    <asp:RegularExpressionValidator ID="REVtxtFechaIni" runat="server" ErrorMessage="Fecha Incorrecta: dd-MM-yyyy" Display="None"
                                        ControlToValidate="txtFechaIni" ValidationGroup="Agregar" Text="*"
                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                                        Style="color: #FF0000"></asp:RegularExpressionValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender21"
                                        runat="server" Enabled="True" TargetControlID="REVtxtFechaIni"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft"
                                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="RFVtxtFechaIni" runat="server" Display="None" ErrorMessage="Digite Fecha de Inicio del Periodo"
                                        ControlToValidate="txtFechaIni" Text="*" ValidationGroup="Agregar"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RFVtxtFechaIni"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                </td>
                                <td>Fecha Cierre
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFechaFin" runat="server" CssClass="TextBox" Width="90px" placeholder="dd-mm-aaaa"></asp:TextBox>
                                    <ajx:CalendarExtender ID="txtFechaFin_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtFechaFin"
                                        Format="dd-MM-yyyy" FirstDayOfWeek="Monday"></ajx:CalendarExtender>
                                    <asp:RegularExpressionValidator ID="REVtxtFechaFin" runat="server" ErrorMessage="Fecha Incorrecta: dd-MM-yyyy" Display="None"
                                        ControlToValidate="txtFechaFin" ValidationGroup="Agregar" Text="*"
                                        ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                                        Style="color: #FF0000"></asp:RegularExpressionValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1"
                                        runat="server" Enabled="True" TargetControlID="REVtxtFechaFin"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft"
                                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                    <asp:RequiredFieldValidator ID="RFVtxtFechaFin" runat="server" Display="None" ErrorMessage="Digite Fecha de Cierre del Periodo"
                                        ControlToValidate="txtFechaFin" Text="*" ValidationGroup="Agregar"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RFVtxtFechaFin"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                </td>
                            </tr>
                        </table>
                    </div>
                   <div style="height: 400px; overflow-y: scroll">
                        <asp:GridView ID="GridClientes" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Style="margin: 0 auto; font-size: 13px"
                            EmptyDataText="No Hay Clientes Disponibles" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red" 
                            AutoGenerateColumns="false" Width="450px">
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
                                <asp:BoundField SortExpression="nit" DataField="nit" HeaderText="NIT">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField SortExpression="nombre" DataField="nombre" HeaderText="Nombre">
                                    <ItemStyle HorizontalAlign="Left" />
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

</asp:Content>

