<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="confisolicitudes.aspx.cs" Inherits="confisolicitudes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        .primeracolumna {
            text-align: right;
            font-weight: bold;
        }

        .auto-style1 {
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
    <div id="mensaje" runat="server"></div>
    <h2 style="text-decoration: underline;">Gestion de Solicitudes y ANS</h2>
    <br />
    <fieldset>
        <legend>Agregar Solicitud
        </legend>
        <table class="cajafiltroCentrado">
            <tr>
                <td class="primeracolumna">Nombre:<span class="auto-style1">*</span>
                </td>
                <td colspan="3">
                    <asp:TextBox ID="txtNombreSolicitud" runat="server" CssClass="TextBox" Width="450px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVtxtNombreSolicitud" runat="server" ErrorMessage="Digite Nombre"
                        Text="*" Display="None" ControlToValidate="txtNombreSolicitud"
                        ValidationGroup="addPerfil"></asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVtxtNombreSolicitud"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <td class="primeracolumna">Prioridad:<span class="auto-style1">*</span>
                </td>
                <td>
                    <asp:DropDownList ID="dropPrioridad" runat="server" CssClass="TextBox"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RFVdropPrioridad" runat="server" ErrorMessage="Seleccione la prioridad" InitialValue="Seleccione"
                        Text="*" Display="None" ControlToValidate="dropPrioridad"
                        ValidationGroup="addPerfil"></asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RFVdropPrioridad"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
                <td class="primeracolumna">ANS:<span class="auto-style1">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtANS" runat="server" CssClass="TextBox"></asp:TextBox>
                    (Horas)
                        <ajx:FilteredTextBoxExtender ID="txtANS_FilteredTextBoxExtender" runat="server" Enabled="True" TargetControlID="txtANS" FilterType="Custom, Numbers" ValidChars=""></ajx:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RFVtxtANS" runat="server" ErrorMessage="Digite el ANS"
                        Text="*" Display="None" ControlToValidate="txtANS"
                        ValidationGroup="addPerfil"></asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="RFVtxtANS"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <td colspan="4" style="text-align: center">
                    <asp:Button ID="btnAgregarSolicitud" ValidationGroup="addPerfil" runat="server" Text="Agregar Solicitud" CssClass="btn btn-success" OnClick="btnAgregarSolicitud_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend>Listado de Solicitudes</legend>
        <asp:GridView ID="GridSolicitudes" runat="server" CellPadding="4" DataKeyNames="cod"
            EmptyDataText="No Existen Solicitudes"
            EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"
            ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto"
            GridLines="None" OnRowDeleting="GridSolicitudes_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="No.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex +1 %>
                    </ItemTemplate>
                    <ItemStyle Width="40px" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="cod" HeaderText="Cod" HeaderStyle-CssClass="ocultarcell">
                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nombre" HeaderText="Proveedor">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="codprioridad" HeaderText="CodPrioridad" HeaderStyle-CssClass="ocultarcell">
                    <ItemStyle HorizontalAlign="Left" CssClass="ocultarcell" />
                </asp:BoundField>
                <asp:BoundField DataField="nombrep" HeaderText="Prioridad">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="ans" HeaderText="ANS (Horas)">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Select" ImageUrl="~/Imagenes/edit.png" Height="20px" Width="20px" OnClick="ImageButton1_Click" />
                    </ItemTemplate>
                    <ItemStyle Width="20px" />
                </asp:TemplateField>
                <asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/Imagenes/delete.png">
                    <ItemStyle Width="20px" />
                </asp:CommandField>
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
        <legend>Agregar Causas Incidente</legend>
        <table cellpadding="4" align="center">
            <tr>
                <td>Nombre
                </td>
                <td>
                    <asp:TextBox ID="txtNombreIncidente" runat="server" CssClass="TextBox" Width="200px" MaxLength="50"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVtxtNombreIncidente" runat="server" ErrorMessage="Digite Nombre"
                        Text="*" Display="None" ControlToValidate="txtNombreIncidente"
                        ValidationGroup="add"></asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True" TargetControlID="RFVtxtNombreIncidente"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
                <td>
                    <asp:Button ID="btnAgregarCausa" runat="server" Text="Agregar Causa " OnClick="btnAgregarCausa_Click1"
                        CssClass="botones" ValidationGroup="add" />
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend>Listado de Causas Incidente</legend>

        <asp:GridView ID="GridCausaIncidente" runat="server" CellPadding="4" DataKeyNames="cod"
            EmptyDataText="No Existen Causas de incidente"
            EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"
            ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto"
            GridLines="None" OnRowDeleting="GridCausaIncidente_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="No.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex +1 %>
                    </ItemTemplate>
                    <ItemStyle Width="40px" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="cod" HeaderText="Cod" HeaderStyle-CssClass="ocultarcell">
                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nombre" HeaderText="Causas Incidente">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:CommandField ShowDeleteButton="True" ButtonType="Image" DeleteImageUrl="~/Imagenes/delete.png">
                    <ItemStyle Width="20px" />
                </asp:CommandField>
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
    <asp:Button ID="btnShow" runat="server" Style="display: none" />
    <ajx:ModalPopupExtender ID="PanelVerDependencias_ModalPopupExtender" runat="server" Enabled="True"
        TargetControlID="btnShow" PopupControlID="PanelVerDependencias" CancelControlID="btnCancelar"
        BackgroundCssClass="modalBackground">
    </ajx:ModalPopupExtender>

    <asp:Panel ID="PanelVerDependencias" runat="server" CssClass="modalPopup">
        <asp:Label ID="lblCodSolicitud" runat="server" Visible="false"></asp:Label>

        <fieldset>
            <legend>Edicion de Solicitud</legend>
            <table cellpadding="4" align="center">
                <tr>
                    <td class="primeracolumna">Nombre<span class="auto-style1">*</span>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtNombre2" runat="server" CssClass="TextBox" Width="450"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVtxtNombre2" runat="server" ErrorMessage="Digite nombre"
                            Text="*" Display="None" ControlToValidate="txtNombre2"
                            ValidationGroup="editUsuario"></asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" Enabled="True" TargetControlID="RFVtxtNombre2"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>

                </tr>
                <tr>
                    <td class="primeracolumna">Prioridad<span class="auto-style1">*</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="dropPrioridad2" runat="server" CssClass="TextBox"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVdropPrioridad2" runat="server" ErrorMessage="Seleccione la prioridad" InitialValue="Seleccione"
                            Text="*" Display="None" ControlToValidate="dropPrioridad2"
                            ValidationGroup="editUsuario"></asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" Enabled="True" TargetControlID="RFVdropPrioridad2"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                    <td>ANS<span class="auto-style1">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtANS2" runat="server" CssClass="TextBox" Width="50px"></asp:TextBox>
                        <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True" TargetControlID="txtANS2" FilterType="Custom, Numbers" ValidChars=""></ajx:FilteredTextBoxExtender>
                        <asp:RequiredFieldValidator ID="RFVtxtANS2" runat="server" ErrorMessage="Digite el ANS en Horas"
                            Text="*" Display="None" ControlToValidate="txtANS2"
                            ValidationGroup="editUsuario"></asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True" TargetControlID="RFVtxtANS2"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                        (Horas)
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align: center">
                        <asp:Button ID="btnEditar" runat="server" Text="Guardar Cambios" ValidationGroup="editUsuario"
                            CssClass="btn btn-success" OnClick="btnEditar_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="botones" />
                    </td>
                </tr>
            </table>
        </fieldset>


    </asp:Panel>



   <%-- </table>--%>



        </table>



</asp:Content>

