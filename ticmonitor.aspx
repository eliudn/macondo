<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="ticmonitor.aspx.cs" Inherits="ticmonitor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">


    <link href="Scripts/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            color: #f00;
            font-size: 95%;
        }
    </style>
    <script src="Scripts/DataTables/js/jquery.dataTables.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            cargarDataTable();
        });

        function cargarDataTable() {
            $('#GridTickets').DataTable({
                "language": {
                    "url": "dataTables.spanish.lang",
                    "sProcessing": "Procesando...",
                    "sLengthMenu": "Mostrar _MENU_ registros",
                    "sZeroRecords": "No se encontraron resultados",
                    "sEmptyTable": "NingÃºn dato disponible en esta tabla",
                    "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                    "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                    "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                    "sInfoPostFix": "",
                    "sSearch": "Buscar:",
                    "sUrl": "",
                    "sInfoThousands": ",",
                    "sLoadingRecords": "Cargando...",
                    "oPaginate": {
                        "sFirst": "Primero",
                        "sLast": "Ãšltimo",
                        "sNext": "Siguiente",
                        "sPrevious": "Anterior"
                    },
                    "oAria": {
                        "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                        "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                    }
                }
            });

        }
    </script>
    <script type="text/javascript">

        function buscar() {
            //alert("Si este es");
            jQuery.fn.filterByText = function (textbox, selectSingleMatch) {
                return this.each(function () {
                    var select = this;
                    var options = [];
                    $(select).find('option').each(function () {
                        options.push({ value: $(this).val(), text: $(this).text() });
                    });
                    $(select).data('options', options);
                    $(textbox).bind('change keyup', function () {
                        var options = $(select).empty().data('options');
                        var search = $(this).val().trim();
                        var regex = new RegExp(search, "gi");

                        $.each(options, function (i) {
                            var option = options[i];
                            if (option.text.match(regex) !== null) {
                                $(select).append(
                                   $('<option>').text(option.text).val(option.value)
                                );
                            }
                        });
                        if (selectSingleMatch === true && $(select).children().length === 1) {
                            $(select).children().get(0).selected = true;
                        }
                    });
                });
            };

            $(function () {
                $('#dropCliente').filterByText($('#textbox'), false);
                $("#dropCliente option").click(function () {
                    alert(1);
                });
            });
        }
    </script>

    <script type = "text/javascript">
        function SetTarget() {
            document.forms[0].target = "_blank";
        }
</script>

    <style>
        .tabla td {
            padding: 5px;
        }

        .auto-style1 {
            color: #FF0000;
        }

        .primeracolumna {
            text-align: right;
            font-weight: bold;
        }

        .modalPopup {
            position: fixed !important;
            z-index: 10001 !important;
            width: 1500px !important;
            left: 244.5px !important;
            top: 50px !important;
        }
    </style>
    <script>


        function filtrar() {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm._doPostBack('MainContent_UpdatePanel3', '');
            return false;
        }

        function cambiarClientes() {
            //Para validar los radio button en tipocliente
            //var unico = document.getElementById('MainContent_radUnico');
            //var multiple = document.getElementById('MainContent_radMultiple');
            //if (unico.checked == true) {
            //    document.getElementById('cliente').style.display = "block";
            //    document.getElementById('tipoClientes').style.display = "none";
            //} else
            //{
            //    if (multiple.checked)
            //    {
            //        document.getElementById('cliente').style.display = "none";
            //        document.getElementById('tipoClientes').style.display = "block";

            $('#gridcblClientes').DataTable({
                "language": {
                    "url": "dataTables.spanish.lang",
                    "sProcessing": "Procesando...",
                    "sLengthMenu": "Mostrar _MENU_ registros",
                    "sZeroRecords": "No se encontraron resultados",
                    "sEmptyTable": "NingÃºn dato disponible en esta tabla",
                    "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                    "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                    "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                    "sInfoPostFix": "",
                    "sSearch": "Buscar:",
                    "sUrl": "",
                    "sInfoThousands": ",",
                    "sLoadingRecords": "Cargando...",
                    "oPaginate": {
                        "sFirst": "Primero",
                        "sLast": "Ãšltimo",
                        "sNext": "Siguiente",
                        "sPrevious": "Anterior"
                    },
                    "oAria": {
                        "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
                        "sSortDescending": ": Activar para ordenar la columna de manera descendente"
                    }
                }
            });

            //    }
            //}
        }
        
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
    <div id="mensaje" runat="server"></div>
    <asp:Label ID="lblCodUsuarioRol" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblCodUsuario" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblTipoUsuario" runat="server" Visible="False"></asp:Label>

    <asp:Label ID="lblCodActividad" runat="server" Visible="false"></asp:Label>

    <asp:Label ID="lblOperacion" runat="server" Visible="false"></asp:Label>

    <asp:Label ID="lblCodProyecto" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblCodEstado" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblCodPrioridad" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblCodSolicitud" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblCodCliente" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblCodUsuarioS" runat="server" Visible="false"></asp:Label>

    <asp:Label ID="lblValidador" runat="server" Visible="false"></asp:Label>

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

            <table align="center" class="tabla" style="width: 50%" border="0">
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
                    <td>Proyecto: </td>
                    <td>
                         <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                         <asp:DropDownList ID="dropProyectoLista" runat="server" CssClass="TextBox" Style="max-width: 250px" OnSelectedIndexChanged="dropProyectoLista_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                                </ContentTemplate>
                             </asp:UpdatePanel>
                    </td>
                    <td>Estado: </td>
                    <td>
                        <asp:DropDownList ID="dropEstadoLista" runat="server" CssClass="TextBox" Style="max-width: 250px" Visible="true">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Cliente:</td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:DropDownList ID="dropClienteLista" runat="server" CssClass="TextBox" Style="max-width: 250px">
                                </asp:DropDownList>
                                </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="dropProyectoLista" EventName="SelectedIndexChanged" />
                            </Triggers>
                       </asp:UpdatePanel>
                    </td>
                    <td>Prioridad:
                    </td>
                    <td>
                        <asp:DropDownList ID="dropPrioridadLista" runat="server" CssClass="TextBox"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Solicitud: </td>
                    <td>
                        <asp:DropDownList ID="dropSolicitudLista" runat="server" CssClass="TextBox" Style="max-width: 250px">
                        </asp:DropDownList>
                    </td>
                    <td>Usuario: </td>
                    <td><asp:DropDownList ID="dropUsuarios" runat="server" CssClass="TextBox" Style="max-width: 250px">
                        </asp:DropDownList></td>
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
            <asp:Label ID="lblcodclientesede" Visible="false" runat="server"></asp:Label>
            <div style="margin: 0 auto; text-align: center; padding: 5px">
                <asp:Label ID="lblNroRegistros" runat="server"></asp:Label>
                <div style="clear: both"></div>
                <table class="cajafiltroCentrado">
                    <tr>
                        <td style="padding-right: 12px">
                            <asp:ImageButton ID="imgAddTickets" runat="server" ImageUrl="~/Imagenes/add.png" ToolTip="Agregar Tickets" Width="40px" Height="40px" />
                        </td>
                        <td>
                            <asp:Button ID="btnExportExcel" runat="server" Visible="false" Text="Exportar" CssClass="btn btn-success" OnClick="btnExportExcel_Click" />
                        </td>

                    </tr>
                </table>
            </div>
            <div style="margin-bottom: 20px">
                <label>
                    <b>No. Ticket</b>
                </label>
                <input runat="server" id="txtFilto" type="text" onkeyup="filtrar(); return false;" class="TextBox" value="" size="10" />
            </div>
            <asp:UpdatePanel ID="UpdatePanel3" runat="server" OnLoad="UpdatePanel3_Load">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td>
                                 <asp:Label ID="lblClientesTicketAbierto" runat="server" visible="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblTicketCreado" runat="server" visible="true"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <thead id="titulos"></thead>
                    </table>
                    <asp:GridView ID="GridTickets" runat="server" CellPadding="4" DataKeyNames="cod" CssClass="filtrar" UseAccessibleHeader="true" ClientIDMode="Static" 
                EmptyDataText="No se encontraron Tickets Registrados." EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"
                ForeColor="#333333" OnRowDataBound="GridTickets_RowDataBound" AutoGenerateColumns="false" Style="margin: 0 auto" OnSorting="GridTickets_Sorting" AllowSorting="true"
                GridLines="None"  OnPageIndexChanging="GridTickets_PageIndexChanging" >
                <Columns>
                    <asp:TemplateField HeaderText="No." HeaderStyle-CssClass="ocultarcell">
                        <ItemTemplate>
                            <%# Container.DataItemIndex +1 %>
                        </ItemTemplate>
                        <ItemStyle Width="40px" HorizontalAlign="Center" CssClass="ocultarcell" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="cod" HeaderText="Tickets">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="createdday" HeaderText="Creado" >
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
                    <asp:BoundField DataField="fechahora" HeaderText="Fecha de cierre" >
                        <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                      <asp:BoundField DataField="escalado" HeaderText="Escalado a">
                        <ItemStyle HorizontalAlign="center" />
                    </asp:BoundField>
                     <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgEscalar" ToolTip="Escalar" runat="server" CommandName="Select" ImageUrl="~/Imagenes/redir.png" Height="20px" Width="20px" OnClick="imgEscalar_Click" Visible='<%#evaluarEscalar(Eval("escalar"))%>'/>
                        </ItemTemplate>
                        <ItemStyle Width="20px" HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgVer" ToolTip="Ver Detalles" runat="server" CommandName="Select" ImageUrl="~/Imagenes/details.png" Height="20px" Width="20px" OnClick="imgVer_Click" OnClientClick = "window.document.forms[0].target='_blank';" />
                        </ItemTemplate>
                        <ItemStyle Width="20px" HorizontalAlign="Center"/>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgEditar" ToolTip="Editar Ticket" runat="server" CommandName="Select" ImageUrl="~/Imagenes/edit.png" Height="20px" Width="20px" OnClick="imgEditar_Click" />
                        </ItemTemplate>
                        <ItemStyle Width="20px" HorizontalAlign="Center"/>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgEliminar" ToolTip="Eliminar Ticket" runat="server" CommandName="Select" ImageUrl="~/Imagenes/delete.png" Height="20px" Width="20px" OnClick="imgEliminar_Click" onclientclick="if(!confirm('¿Está seguro en eliminar este Ticket?, Si lo hace se eliminarán las Escalas, Evidencias y Seguimientos que lo relacionen')){return false;};" />
                        </ItemTemplate>
                        <ItemStyle Width="20px" HorizontalAlign="Center"/>
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
                 </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="GridTickets" />
                    <asp:AsyncPostBackTrigger ControlID="btnFiltrarLista" EventName="Click" />
                </Triggers>
          </asp:UpdatePanel>

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
                        <td colspan="2">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table>
                                        <tr>
                                            <td>Filtrar</td>
                                            <td>
                                                <input id="textbox" type="text" class="TextBox" style="width: 200px" placeholder="Digita Nombre, NIT o Municipio" /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:DropDownList ID="dropCliente" style="max-width:300px" ClientIDMode="Static" runat="server" CssClass="TextBox"></asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>


                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="dropProyectosAdd" EventName="SelectedIndexChanged" />
                                </Triggers>
                            </asp:UpdatePanel>
                            
                        </td>
                         <td>
                                    <asp:Button ID="btnAddClientes" runat="server" Text="Añadir cliente" CssClass="botones"  OnClick="btnAddClientes_Click" />
                                </td>
                    </tr>
                      <tr>
                                <td colspan="4">
                                           <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                  <asp:GridView ID="GridImplicados" runat="server" CellPadding="4" DataKeyNames="cod"
                            EmptyDataText="No se han agregado los clientes"
                            EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"
                            ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto"
                            GridLines="None" OnRowDeleting="GridImplicados_RowDeleting">
                            <Columns>
                                   <asp:TemplateField HeaderText="No.">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex +1 %>
                                                </ItemTemplate>        
                                                <ItemStyle Width="40px" HorizontalAlign="Center" />      
                                            </asp:TemplateField> 
                                <asp:BoundField DataField="cod" HeaderText="cod" HeaderStyle-CssClass="ocultarcell">
                                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="nombre" HeaderText="Clinte">
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
                                       </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="btnAddClientes" EventName="Click" />
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
                <asp:Button ID="btnEditarTickets" runat="server" Text="Editar Tickets" CssClass="btn btn-primary" ValidationGroup="AgregarR"  Visible="false" />
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
                <asp:Label runat="server" ID="lblTicket" Visible="false"></asp:Label>
                <table align="center" cellpadding="4">
                    <tr>
                        <td class="primeracolumna">Coordinador: <span class="auto-style1">*</span>
                        </td>
                        <td colspan="3">
                            <asp:DropDownList runat="server" ID="cmbCoordinadores"></asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <br />
                <br />

            </fieldset>
        </section>
        <footer class="footerpopup">
            <div style="text-align: center">
                <asp:Button ID="btnEscalarC" runat="server" Text="Escalar Coordinador" CssClass="btn btn-success"
                    ValidationGroup="" OnClick="btnEscalarC_Click" />
            </div>
        </footer>
    </asp:Panel>

</asp:Content>

