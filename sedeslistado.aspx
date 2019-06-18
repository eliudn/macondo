<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="sedeslistado.aspx.cs" Inherits="sedeslistado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        function imprSelec(muestra) {
            var ficha = document.getElementById(muestra);
            var ventimp = window.open(' ', 'popimpr');
            ventimp.document.write(ficha.innerHTML);
            ventimp.document.close();
            ventimp.print();
            ventimp.close();
        }
    </script>
    <style type="text/css">
        .cuadroEncabezado {
            display: none;
        }

        .impresionInfo {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" runat="server"></asp:ScriptManager>
    <asp:Label ID="lblTipoUsuario" runat="server" Visible="false"></asp:Label>
    <div id="mensaje" runat="server"></div>
    <div class="header">
        <div style="float: left; margin-right: 15px">
           
        </div>
        <div style="float: right;">
            <%--    <a href="estureg.aspx" class="btn btn-primary">Nuevo Estudiante</a>
            <a href="estumatricula.aspx" class="btn btn-primary">Matricular Estudiante</a>--%>
        </div>
    </div> <br /><br />
    <h2>Lista de Instituciones</h2>
    <fieldset>
        <legend>Listado completo de Sedes registrados en el sistema.</legend>
        <fieldset>
            <legend>Filtros</legend>
            <asp:Panel ID="PanelBusquedaGeneral" runat="server">
                <table cellpadding="4" align="center" class="cajafiltroCentrado">
                <tr>
                    <td>Búsqueda:
                    </td>
                    <td colspan="5">
                        <asp:TextBox ID="txtBusqueda" runat="server" CssClass="TextBox" Width="500px"
                            AutoPostBack="True" OnTextChanged="txtBusqueda_TextChanged"></asp:TextBox>
                        <ajx:AutoCompleteExtender ID="txtBusqueda_AutoCompleteExtender" runat="server"
                            DelimiterCharacters="" Enabled="True" ServicePath="WebAutoComplete.asmx" TargetControlID="txtBusqueda"
                            CompletionListCssClass="completionList"
                            CompletionListHighlightedItemCssClass="itemHighlighted"
                            CompletionListItemCssClass="listItem"
                            CompletionInterval="200" MinimumPrefixLength="3" ServiceMethod="GetListaClientes" UseContextKey="True">
                        </ajx:AutoCompleteExtender>
                    </td>
                 
                </tr>
            
                </table>

                <div style="margin: 0 auto; text-align: center; padding: 5px" id="Div1" runat="server">
                <div style="clear: both"></div>
                <table class="cajafiltroCentrado">
                    <tr>
                        <td>
                            <asp:DropDownList ID="dropDepartamento" runat="server" CssClass="TextBox" AutoPostBack="true" OnSelectedIndexChanged="dropDepartamento_OnSelectedIndexChanged"></asp:DropDownList>
                         </td>
                     </tr>
                    <tr>
                        <td>
                           <asp:DropDownList ID="dropMunicipios" runat="server" CssClass="TextBox" AutoPostBack="true" OnSelectedIndexChanged="dropCiudad_OnSelectedIndexChanged"></asp:DropDownList> 
                         </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="dropInstitucion" runat="server" CssClass="TextBox"></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Button ID="btnBuscar" runat="server" CssClass="btn btn-success" Text="Buscar" OnClick="btnBuscar_Click" /></td>
                    </tr>
                </table>
            </div>
            </asp:Panel>
            </fieldset>
        <fieldset>
            <legend>Listado</legend>
         <div style="margin: 0 auto; text-align: center; padding: 5px" visible="false" id="botones" runat="server">
                <div style="clear: both"></div>
                <table class="cajafiltroCentrado">
                    <tr>
                        <td style="padding-right:12px">
                            <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" CssClass="btn btn-primary" OnClick="btnImprimir_Click" />
                         </td>
                        <td>
                            <asp:Button ID="btnExportExcel" runat="server" Text="Exportar" CssClass="btn btn-success" OnClick="btnExportExcel_Click" />
                         </td>

                    </tr>
                </table>
            </div>

            <asp:Panel ID="PanelImpresion" runat="server">
                <div id="muestra">
                    <link href="Styles/General.css" rel="stylesheet" />
                    <link href="Styles/boletin.css" rel="stylesheet" />
                    <style type="text/css" media="print">
                        @media print {
                            @page {
                                size: landscape;
                            }

                            thead {
                                display: table-header-group;
                            }

                            .cuadroEncabezado {
                                display: block;
                            }

                            .impresionInfo {
                                display: block;
                            }
                        }

                        .cuadroplanilla {
                            overflow-x: no-display;
                        }

                        body {
                            font-size: 90%;
                            background-color: !important;
                            background-color: #fff;
                        }

                        .cuadroEncabezado {
                            margin: 0 auto;
                        }

                        .mGridTesoreria {
                        }
                    </style>
                   
                    <div style="margin: 0 auto; text-align: center">
                        <asp:Label ID="lblNroRegistros" runat="server"></asp:Label>
                    </div>

                    <asp:GridView ID="GridClientes" runat="server" CellPadding="4" DataKeyNames="cod" CssClass="mGridTesoreria"
                        EmptyDataText="No se encontraron Establecimiento con este filtro" EmptyDataRowStyle-HorizontalAlign="Center" EmptyDataRowStyle-ForeColor="Red"
                        ForeColor="#333333" PageSize="20"  AutoGenerateColumns="false" Style="margin: 0 auto" OnSorting="GridClientes_Sorting" AllowSorting="true"
                        GridLines="None" AllowPaging="True" OnPageIndexChanging="GridClientes_PageIndexChanging">
                        <Columns>
                            <asp:TemplateField HeaderText="No.">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex +1 %>
                                </ItemTemplate>
                                <ItemStyle Width="40px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="dane" HeaderText="DANE">
                                <ItemStyle HorizontalAlign="Center" Width="120px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="nombre" SortExpression="nombrecompleto" HeaderText="Nombre Institución" >
                                <ItemStyle HorizontalAlign="left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="idrector" HeaderText="ID Rector">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                              <asp:BoundField DataField="nommunicipio" HeaderText="Municipio" >
                                <ItemStyle HorizontalAlign="left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="telefono"  HeaderText="Teléfono">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="email" HeaderText="Email">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="claseins" HeaderText="Clase de Institución">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                             <asp:BoundField DataField="ruralurbana" HeaderText="Rural/Urbana">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEditar" runat="server" ToolTip="Ver datos del rector" CommandName="Select" ImageUrl="~/Imagenes/ver.png" Height="20px" Width="20px" OnClick="imgEditar_Click" />
                                </ItemTemplate>
                                <ItemStyle Width="20px" />
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                             <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Imagenes/delete.png" Height="20px" Width="20px" OnClientClick="if(!confirm('Si borras la Principal se borraran las sedes, ¿Estas Seguro?')){ return false; };" OnClick="DeleteButton_Click" />
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
                </div>
            </asp:Panel>
           </fieldset>
        </fieldset>

</asp:Content>

