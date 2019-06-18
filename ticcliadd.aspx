<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="ticcliadd.aspx.cs" Inherits="ticcliadd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
    <div id="mensaje" runat="server"></div>
     <asp:Label ID="lblCodUsuarioRol" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblCodUsuario" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblTipoUsuario" runat="server" Visible="False"></asp:Label>
     <div class="header">
        <div style="float: left; margin-right: 15px">
            <h2>Agregar Tickets</h2>
        </div>

        <div style="float: right;">
            <%--<a href="actagenda.aspx" runat="server" id="btnMiAgenda" class="btn btn-primary">Mi Agenda</a>--%>
        </div>
    </div>
     <fieldset>
                <legend>Campos obligatorios  <span class="auto-style1">*</span></legend>
                <table align="center" cellpadding="4">
                    <tr>
                        <td class="primeracolumna">Solicitud: <span class="auto-style1">*</span>
                        </td>
                        <td colspan="3">
                            <asp:DropDownList ID="dropSolicitudAdd" runat="server" CssClass="TextBox" AutoPostBack="True" OnSelectedIndexChanged="dropSolicitudAdd_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFVdropSolicitudAdd" runat="server" Display="None" ErrorMessage="Selecciones el tipo de solicitud"
                                ControlToValidate="dropSolicitudAdd" Text="*" ValidationGroup="AgregarR" InitialValue="Seleccione"></asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" TargetControlID="RFVdropSolicitudAdd"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                                Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional" style="display: inline">
                                <ContentTemplate>
                                    <asp:Label ID="lblColorFiltro" runat="server" Style="display: inline;"></asp:Label>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="dropSolicitudAdd" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;" class="primeracolumna">Descripción :
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtDescripcionAdd" runat="server" CssClass="TextBox" placeholder="Describa la actividad." Width="300px" TextMode="MultiLine" Rows="3" Style="resize: none"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFVtxtDescripcionAdd" runat="server" ErrorMessage="Digite la descripción"
                                Text="*" Display="None" ControlToValidate="txtDescripcionAdd" ValidationGroup="AgregarR">
                            </asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="VCEtxtDescripcionAdd" runat="server" Enabled="True" TargetControlID="RFVtxtDescripcionAdd"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender> 
                        </td>
                    </tr>
                
                    <tr>
                        <td class="primeracolumna">Proyecto: <span class="auto-style1">*</span>
                        </td>
                        <td colspan="3">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList ID="dropProyectosAdd" runat="server" AutoPostBack="true" OnSelectedIndexChanged="dropProyectosAdd_SelectedIndexChanged" CssClass="TextBox"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RFVdropProyectosAdd" runat="server" Display="None" ErrorMessage="Selecciones el proyecto"
                                        ControlToValidate="dropProyectosAdd" Text="*" ValidationGroup="AgregarR" InitialValue="Seleccione"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" TargetControlID="RFVdropProyectosAdd"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr>
                        <td class="primeracolumna">Cliente:  <span class="auto-style1">*</span>
                        </td>
                        <td colspan="3">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:DropDownList ID="dropCliente" runat="server" CssClass="TextBox"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RFVdropCliente" runat="server" Display="None" ErrorMessage="Selecciones el cliente"
                                        ControlToValidate="dropCliente" Text="*" ValidationGroup="AgregarR" InitialValue="Seleccione"></asp:RequiredFieldValidator>
                                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RFVdropCliente"
                                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                                        Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                                    </ajx:ValidatorCalloutExtender>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="dropProyectosAdd" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                 </table>
                <br />
                <br />

            </fieldset>
             <div style="text-align: center">
                <asp:Button ID="btnAddTickets" runat="server" Text="Agregar Tickets" CssClass="btn btn-success"
                    ValidationGroup="AgregarR" OnClick="btnAddTickets_Click" />
            </div>
</asp:Content>

