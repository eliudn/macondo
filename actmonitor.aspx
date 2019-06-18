<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="actmonitor.aspx.cs" Inherits="actmonitor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
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
            $('#GridActividades').DataTable({
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

    <script type = "text/javascript">
        function SetTarget() {
            document.forms[0].target = "_blank";
        }
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
     <div id="mensaje" runat="server"></div>
       <asp:Label ID="lblCodUsuarioRol" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblCodUsuario" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblTipoUsuario" runat="server" Visible="False"></asp:Label>
        <div class="header">
            <div style="float: left; margin-right: 15px">
                <h2>Monitor de actividades</h2>
            </div>
          
            <div style="float: right;">
                <a href="actagenda.aspx" runat="server" id="btnMiAgenda" class="btn btn-primary">Mi Agenda</a>
            </div>
        </div>
    <fieldset>
        <legend>Listado completo de actividades registradas en el sistema.</legend> 
        <fieldset>
            <legend>Filtros</legend>

            <table align="center" style="width:50%">
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
                    <td rowspan="2" style="vertical-align:middle">
                        <asp:Button ID="btnFiltrarLista" runat="server" CssClass="btn btn-primary" OnClick="btnFiltrarLista_Click" Text="Filtrar" ValidationGroup="Filtrar" />
                    </td>
                </tr>
                <tr>
                    <td>Proyecto: </td>
                    <td>
                        <asp:DropDownList ID="dropProyectoLista" runat="server" CssClass="TextBox" style="max-width:250px">
                        </asp:DropDownList>
                    </td>
                    <td>Estado: </td>
                    <td>
                        <asp:DropDownList ID="dropEstadoLista" runat="server" CssClass="TextBox" style="max-width:250px" Visible="true">
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>

        </fieldset>
        <fieldset>
            <legend>Listado De Actividades</legend>
                <asp:Panel ID="PanelImpresion" runat="server">
        <div id="muestra">
            <link href="Styles/General.css" rel="stylesheet" />
            <link href="Styles/boletin.css" rel="stylesheet" />
            <style type="text/css" media="print">
                @media print {
                    @page {size: landscape;}
                    thead {display: table-header-group;}
                    .cuadroEncabezado{
                        display:block;
                    } 
                    .impresionInfo{
                        display:block;
                    }
                }           
            
                .cuadroplanilla{
                    overflow-x:no-display;
                }
                body{
                    font-size:90%;
                    background-color:!important;
                    background-color:#fff;
                
                }
                .cuadroEncabezado{
                    margin:0 auto;
                }
                .mGridTesoreria{

                }
            </style>
            <asp:Label ID="lblEncabezado" runat="server"></asp:Label>
            <asp:Label ID="lblCodEstado" runat="server" Visible="false"></asp:Label>
            <asp:Label ID="lblCodProyecto" runat="server" Visible="false"></asp:Label>
             <asp:Label ID="lblOperacion" runat="server" Visible="false"></asp:Label>


             <div class="impresionInfo">
                <asp:Label ID="lblImprimirInfo" runat="server" ></asp:Label>
            </div> 
            <table align="center">
                <tr>
                    <td>
                        <asp:Button ID="btnExportExcel" runat="server" Text="Exportar" CssClass="btn btn-success" OnClick="btnExportExcel_Click" />
                    </td>
                </tr>
            </table> 
            <br />
            <div style="margin:0 auto;text-align:center">
                <asp:Label ID="lblNroRegistros" runat="server"></asp:Label>
            </div>  
           
            <asp:GridView ID="GridActividades" runat="server" CellPadding="4" DataKeyNames="cod" CssClass="mGridTesoreria" UseAccessibleHeader="true" ClientIDMode="Static"
                EmptyDataText="No Hay Actividades Registradas." EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"
                ForeColor="#333333" AutoGenerateColumns="false" style="margin:0 auto"  OnSorting="GridActividades_Sorting" AllowSorting="true"
                GridLines="None" OnRowDataBound="GridActividades_RowDataBound" OnPageIndexChanging="GridActividades_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText="No." HeaderStyle-CssClass="ocultarcell" >
                        <ItemTemplate>
                            <%# Container.DataItemIndex +1 %>
                        </ItemTemplate>        
                        <ItemStyle Width="40px" HorizontalAlign="Center" CssClass="ocultarcell"  />      
                    </asp:TemplateField>
                    <asp:BoundField DataField="cod" HeaderText="Order de Trabajo" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="proyecto" HeaderText="Proyecto" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:BoundField DataField="actividad"  SortExpression="actividad" HeaderText="Actividad" ><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
                    <asp:BoundField DataField="municipio" HeaderText="Municipio" ><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
                    <asp:BoundField DataField="cliente" HeaderText="Cliente" ><ItemStyle HorizontalAlign="Left" /></asp:BoundField>
                    <asp:BoundField DataField="nombre" HeaderText="Estado" ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            Creador
                        </HeaderTemplate>
                        <ItemTemplate>
                         <asp:Label ID="lblCreador" runat="server" Text='<%#buscarNombreUsuario(Eval("codusuariorol").ToString()) %>'>' ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="createdday" HeaderText="Creado" DataFormatString="{0:d}"  ><ItemStyle HorizontalAlign="Left"  /></asp:BoundField>
                    <asp:BoundField DataField="startday" HeaderText="Inicio"  ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                     <asp:BoundField DataField="endday" HeaderText="Fin"  ><ItemStyle HorizontalAlign="Center" /></asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgVer" ToolTip="Ver Detalles" runat="server" CommandName="Select" ImageUrl="~/Imagenes/details.png" Height="20px" Width="20px" OnClick="imgVer_Click" OnClientClick = "SetTarget();" />
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
                    </asp:TemplateField>   
                      <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="imgCorreo" ToolTip="Enviar Correo" runat="server" CommandName="Select" ImageUrl="~/Imagenes/email.png" Height="20px" Width="20px" OnClick="imgCorreo_Click" />
                        </ItemTemplate>
                        <ItemStyle Width="20px" />
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
        </div>
    </asp:Panel>
        </fieldset>
    </fieldset>
  
</asp:Content>

