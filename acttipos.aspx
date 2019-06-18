<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="acttipos.aspx.cs" Inherits="acttipos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
    <div id="mensaje" runat="server"></div>
    <h2 style="text-decoration: underline;">Tipos de actividades</h2>
    <br />
    <fieldset>
        <legend>Agregar Tipo
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
                 <td class="primeracolumna">ANS:<span class="auto-style1">*</span>
                </td>
                <td>
                    <asp:TextBox ID="txtANS" MaxLength="2"  Width="50" runat="server" CssClass="TextBox"></asp:TextBox>
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
                    <asp:Button ID="btnAgregarActividad" ValidationGroup="addPerfil" runat="server" Text="Agregar" CssClass="btn btn-success" OnClick="btnAgregarActividad_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend>Listado de Solicitudes</legend>
        <asp:GridView ID="GridActividades" runat="server" CellPadding="4" DataKeyNames="cod"
            EmptyDataText="No Existen Actividades"
            EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"
            ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto"
            GridLines="None" OnRowDeleting="GridActividades_RowDeleting">
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
                <asp:BoundField DataField="nombre" HeaderText="Nombre">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="ans" HeaderText="ANS (Horas)">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEdit" runat="server" CommandName="Select" ImageUrl="~/Imagenes/edit.png" Height="20px" Width="20px" OnClick="imgEdit_Click" />
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

        <asp:Button ID="btnShow" runat="server" Style="display: none" />
    <ajx:ModalPopupExtender ID="PanelVerDependencias_ModalPopupExtender" runat="server" Enabled="True"
        TargetControlID="btnShow" PopupControlID="PanelVerDependencias" CancelControlID="btnCancelar"
        BackgroundCssClass="modalBackground">
    </ajx:ModalPopupExtender>

    <asp:Panel ID="PanelVerDependencias" runat="server" CssClass="modalPopup">
        <asp:Label ID="lblCodSolicitud" runat="server" Visible="false"></asp:Label>

        <fieldset>
            <legend>Edicion de Actividad</legend>
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
                   <td class="primeracolumna">ANS<span class="auto-style1">*</span>
                    </td>
                    <td>
                        <asp:TextBox ID="txtANS2" MaxLength="2" runat="server" CssClass="TextBox" Width="50px"></asp:TextBox>
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
</asp:Content>

