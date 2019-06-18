<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="ticcoormonitor.aspx.cs" Inherits="ticcoormonitor" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
        .tabla td{
            padding:5px;
        }
           .auto-style1 {
            color: #FF0000;
        }

        .primeracolumna {
            text-align: right;
            font-weight: bold;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
    <div id="mensaje" runat="server"></div>
    <asp:Label ID="lblCodUsuarioRol" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblCodUsuario" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblTipoUsuario" runat="server" Visible="False"></asp:Label>
    <div class="header">
        <div style="float: left; margin-right: 15px">
            <h2>Monitor de Tickets</h2>
        </div>

        <div style="float: right;">
            <%--<a href="actagenda.aspx" runat="server" id="btnMiAgenda" class="btn btn-primary">Mi Agenda</a>--%>
        </div>
    </div>
    <fieldset>
        <legend>Listado completo de tickets registrados en el sistema.</legend>
        <fieldset>
            <legend>Filtros</legend>

            <table align="center" class="tabla" style="width: 50%">
                <tr>
                    <td>Desde: </td>
                    <td>
                        <asp:TextBox ID="txtFechaIniFiltro" runat="server" CssClass="TextBox" MaxLength="10" placeholder="dd-mm-aaaa" Width="90px"></asp:TextBox>
                        <ajx:FilteredTextBoxExtender ID="filtro" runat="server" FilterType="Custom, Numbers" TargetControlID="txtFechaIniFiltro" ValidChars="-" />
                        <ajx:CalendarExtender ID="txtFechaIniFiltro_CalendarExtender" runat="server" DefaultView="Days" Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFechaIniFiltro" />
                        <asp:RegularExpressionValidator ID="REVtxtFechaIniFiltro" runat="server" ControlToValidate="txtFechaIniFiltro" Display="None" ErrorMessage="Fecha Incorrecta: dd-MM-yyyy" Style="color: #FF0000" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ValidationGroup="Filtrar"></asp:RegularExpressionValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" CssClass="CustomValidatorCalloutStyle" Enabled="True" HighlightCssClass="Highlight" PopupPosition="BottomLeft" TargetControlID="REVtxtFechaIniFiltro" WarningIconImageUrl="Imagenes/error3.png" Width="250px">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                    <td>Hasta: </td>
                    <td>
                        <asp:TextBox ID="txtFechaFinFiltro" runat="server" CssClass="TextBox" MaxLength="10" placeholder="dd-mm-aaaa" Width="90px"></asp:TextBox>
                        <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" FilterType="Custom, Numbers" TargetControlID="txtFechaFinFiltro" ValidChars="-" />
                        <ajx:CalendarExtender ID="txtFechaFinFiltro_CalendarExtender" runat="server" DefaultView="Days" Enabled="True" Format="dd-MM-yyyy" TargetControlID="txtFechaFinFiltro" />
                        <asp:RegularExpressionValidator ID="REVtxtFechaFinFiltro" runat="server" ControlToValidate="txtFechaFinFiltro" Display="None" ErrorMessage="Fecha Incorrecta: dd-MM-yyyy" Style="color: #FF0000" ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d" ValidationGroup="Filtrar"></asp:RegularExpressionValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" CssClass="CustomValidatorCalloutStyle" Enabled="True" HighlightCssClass="Highlight" PopupPosition="BottomLeft" TargetControlID="REVtxtFechaFinFiltro" WarningIconImageUrl="Imagenes/error3.png" Width="250px">
                        </ajx:ValidatorCalloutExtender>
                    </td>

                </tr>
                <tr>
                    <td>Estado: </td>
                    <td>
                        <asp:DropDownList ID="dropEstadoLista" runat="server" CssClass="TextBox" Style="max-width: 250px" Visible="true">
                        </asp:DropDownList>
                    </td>
                     <td>Solicitud: </td>
                    <td>
                        <asp:DropDownList ID="dropSolicitudLista" runat="server" CssClass="TextBox" Style="max-width: 250px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Prioridad:
                    </td>
                    <td>
                        <asp:DropDownList ID="dropPrioridadLista" runat="server" CssClass="TextBox"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="vertical-align: middle; text-align: center">
                        <asp:Button ID="btnFiltrarLista" runat="server" CssClass="btn btn-primary" OnClick="btnFiltrarLista_Click" Text="Filtrar" ValidationGroup="Filtrar" />
                    </td>
                </tr>

            </table>

        </fieldset>
        <fieldset>
            <legend>Listado De Tickets</legend>

            <div style="margin: 0 auto; text-align: center;padding:5px">
                <asp:Label ID="lblNroRegistros" runat="server"></asp:Label>
                  <div style="clear:both"></div>
                <asp:ImageButton ID="imgAddTickets" runat="server"  ImageUrl="~/Imagenes/add.png"   ToolTip="Agregar Tickets"  Width="40px" Height="40px" Visible="false" />
            </div>

            <asp:GridView ID="GridTickets" runat="server" CellPadding="4" DataKeyNames="cod" CssClass="mGridTesoreria"
                EmptyDataText="No se encontraron Tickets Registrados." EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"
                ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto" OnSorting="GridTickets_Sorting" AllowSorting="true"
                GridLines="None" OnRowDataBound="GridTickets_RowDataBound" AllowPaging="True" OnPageIndexChanging="GridTickets_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="No.">
                        <ItemTemplate>
                            <%# Container.DataItemIndex +1 %>
                        </ItemTemplate>
                        <ItemStyle Width="40px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                   <asp:BoundField DataField="cod" HeaderText="Tickets">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="createdday" HeaderText="Creado" DataFormatString="{0:d}">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="codproyecto" HeaderText="codproyecto" HeaderStyle-CssClass="ocultarcell">
                        <ItemStyle HorizontalAlign="Left" CssClass="ocultarcell" />
                    </asp:BoundField>
                     <asp:BoundField DataField="proyecto" HeaderText="Proyecto">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="nomunicipio" HeaderText="Municipio">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="usuario" HeaderText="Usuario">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="codclisede" HeaderText="codclisede" HeaderStyle-CssClass="ocultarcell">
                        <ItemStyle HorizontalAlign="Left" CssClass="ocultarcell" />
                    </asp:BoundField>
                    <asp:BoundField DataField="cliente" HeaderText="Cliente">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="causa" HeaderText="Causa">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="codsolicitud" HeaderText="codSolicitud" HeaderStyle-CssClass="ocultarcell">
                        <ItemStyle HorizontalAlign="Left" CssClass="ocultarcell" />
                    </asp:BoundField>
                    <asp:BoundField DataField="solicitud" SortExpression="solicitud" HeaderText="Solicitud">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="estado" HeaderText="Estado">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ans" HeaderText="ANS">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="prioridad" HeaderText="Prioridad">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                   <asp:BoundField DataField="descripcion" HeaderText="Descripción">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="descseg" HeaderText="Observación final del ticket">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fechahora" HeaderText="Fecha de cierre" DataFormatString="{0:d}">
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                     <asp:TemplateField>
                        <HeaderTemplate>
                            Escalar
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgEscalar" runat="server" ToolTip="Escalar" CommandName="Select" ImageUrl="~/Imagenes/redir.png" Height="20px" Width="20px" OnClick="imgEscalar_Click" Visible='<%#evaluarEscalar(Eval("cod"))%>'/>
                        </ItemTemplate>
                        <ItemStyle Width="20px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Detalle
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgVer" ToolTip="Ver Detalles" runat="server" CommandName="Select" ImageUrl="~/Imagenes/details.png" Height="20px" Width="20px" OnClick="imgVer_Click" />
                        </ItemTemplate>
                        <ItemStyle Width="20px" HorizontalAlign="Center" />
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
    </fieldset>

     <ajx:ModalPopupExtender ID="PanelAgregarEvento_Modalpopupextender2" runat="server" Enabled="True"
        TargetControlID="imgAddTickets" PopupControlID="PanelAgregarTickets" CancelControlID="btnCerrarAgregarEvento"
        BackgroundCssClass="modalBackground">
    </ajx:ModalPopupExtender>

    <asp:Panel ID="PanelAgregarTickets" runat="server" CssClass="modalPopup">
        <header class="headerpopup">
            <div style="float: left; margin-right: 15px" id="Div2">
                Agregar Tickets
            </div>
            <div style="float: right;">
                <asp:Label ID="btnCerrarAgregarEvento" runat="server" Text="Cerrar" CssClass="botones"></asp:Label>
            </div>
        </header>
        <section class="sectionpopup">
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
                            <asp:TextBox ID="txtDescripciónAdd" runat="server" CssClass="TextBox" placeholder="Describa la actividad." Width="300px" TextMode="MultiLine" Rows="3" Style="resize: none"></asp:TextBox>
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
        </section>
        <footer class="footerpopup">
            <div style="text-align: center">
                <asp:Button ID="btnAddTickets" runat="server" Text="Agregar Tickets" CssClass="btn btn-success"
                    ValidationGroup="AgregarR" OnClick="btnAddTickets_Click" />
            </div>
        </footer>
    </asp:Panel>

    <asp:Button ID="btnShow" runat="server" Text="Button" Style="display: none" />
    <ajx:ModalPopupExtender ID="PanelEscalar_ModalPopupExtender1" runat="server" Enabled="True"
        TargetControlID="btnShow" PopupControlID="PanelEscalar" CancelControlID="btnCerrarEscalar"
        BackgroundCssClass="modalBackground">
    </ajx:ModalPopupExtender>

    <asp:Panel ID="PanelEscalar" runat="server" CssClass="modalPopup">
        <header class="headerpopup">
            <div style="float: left; margin-right: 15px" id="Div2">
                Agregar Tickets
            </div>
            <div style="float: right;">
                <asp:Label ID="btnCerrarEscalar" runat="server" Text="Cerrar" CssClass="botones"></asp:Label>
            </div>
        </header>
        <section class="sectionpopup">
            <fieldset>
                <legend>Campos obligatorios  <span class="auto-style1">*</span></legend>
                <asp:Label runat="server" ID="lblTicket" Visible="false" ></asp:Label>
                <table align="center" cellpadding="4">
                    <tr>
                        <td class="primeracolumna">Tecnicos: <span class="auto-style1">*</span>
                        </td>
                        <td colspan="3">
                            <asp:CheckBoxList ID="cblTecnicos" runat="server" RepeatColumns="5" CssClass="TextBox">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                 </table>
                <br />
                <br />

            </fieldset>
        </section>
        <footer class="footerpopup">
            <div style="text-align: center">
                <asp:Button ID="btnEscalarC" runat="server" Text="Asignar Tecnicos" CssClass="btn btn-success"
                    ValidationGroup="" OnClick="btnEscalarC_Click" />
            </div>
        </footer>
    </asp:Panel>

</asp:Content>


