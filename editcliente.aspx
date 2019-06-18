<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="editcliente.aspx.cs" Inherits="editcliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <meta charset="utf-8">
    <title>Hoja de vida Cliente</title>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script>
        $(document).ready(function () {
            $("#accordion").accordion({
                heightStyle: "content",
                active: "1" //Colocas comillas para que no se abra ninguno, quitas comillas y colocas un numero si quieres que se visualize algun panel
            });
            $("#accordion").attr("style", "visibility:visible;");

        });

    </script>
    <script>
        function abrir(panel) {
            var p = parseInt(panel);
            $(function () {
                $("#accordion").accordion({
                    heightStyle: "content",
                    active: p
                });
            });
        }
    </script>
    <script>
        //Funcion que muestra información al clicar en checkbox
        function mostrarCapa(elem) {
            if (elem.checked) {
                document.getElementById('MainContent_txtIpRouterAdd').value = 'NO APLICA';
                document.getElementById('MainContent_txtIpRouterAdd').disabled = true;
            } else {
                document.getElementById('MainContent_txtIpRouterAdd').value = '';
                document.getElementById('MainContent_txtIpRouterAdd').disabled = false;
                document.getElementById('MainContent_txtIpRouterAdd').focus();
            }
        }
        function mostrarCapa2(elem) {
            if (elem.checked) {
                document.getElementById('MainContent_txtIpAntenaAdd').value = 'NO APLICA';
                document.getElementById('MainContent_txtIpAntenaAdd').disabled = true;
            } else {
                document.getElementById('MainContent_txtIpAntenaAdd').value = '';
                document.getElementById('MainContent_txtIpAntenaAdd').disabled = false;
                document.getElementById('MainContent_txtIpAntenaAdd').focus();
            }
        }
        function mostrarCapa3(elem) {
            if (elem.checked) {
                document.getElementById('MainContent_txtIpRouteEdit').value = 'NO APLICA';
                document.getElementById('MainContent_txtIpRouteEdit').disabled = true;
            } else {
                document.getElementById('MainContent_txtIpRouteEdit').value = '';
                document.getElementById('MainContent_txtIpRouteEdit').disabled = false;
                document.getElementById('MainContent_txtIpRouteEdit').focus();
            }
        }
        function mostrarCapa4(elem) {
            if (elem.checked) {
                document.getElementById('MainContent_txtIpAntenaEdit').value = 'NO APLICA';
                document.getElementById('MainContent_txtIpAntenaEdit').disabled = true;
            } else {
                document.getElementById('MainContent_txtIpAntenaEdit').value = '';
                document.getElementById('MainContent_txtIpAntenaEdit').disabled = false;
                document.getElementById('MainContent_txtIpAntenaEdit').focus();
            }
        }
    </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" runat="server"></asp:ScriptManager>
     <asp:Label ID="lblTipoUsuario" runat="server" Visible="false"></asp:Label>
    <div id="mensaje" runat="server"></div><br /><br />
    <div class="header">
        <div style="float: left; margin-right: 15px">
            <h2>Edición de Sedes</h2>
        </div>
        <div style="float: right;">
            <a href="sedeslistado.aspx" id="btnRegresar" runat="server" class="btn btn-primary">Volver</a>
        </div>
    </div><br /><br /><br />
    <fieldset>
        <legend>Datos del cliente</legend>
        <asp:Label ID="lblCodCliente" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblCodUsuario" runat="server" Visible="false"></asp:Label>

        <table class="cajafiltroCentrado">
            <tr>
                <td>NIT
                </td>
                <td>
                    <asp:TextBox ID="txtNit" runat="server" CssClass="TextBox" Width="300px"></asp:TextBox>
                    <ajx:FilteredTextBoxExtender ID="txtNit_FilteredTextBoxExtender" runat="server" Enabled="True" TargetControlID="txtNit" FilterType="Custom, Numbers" ValidChars=""></ajx:FilteredTextBoxExtender>
                    <asp:RequiredFieldValidator ID="RFVtxtNit" runat="server" ErrorMessage="Digite Nit Del Cliente"
                        Text="*" Display="None" ControlToValidate="txtNit" ValidationGroup="add">
                    </asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True" TargetControlID="RFVtxtNit"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
                <td>Tipo
                </td>
                <td>
                    <asp:DropDownList ID="dropTipoCliente" runat="server" CssClass="TextBox"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RFVdropTipoCliente" runat="server" ErrorMessage="Seleccione el tipo de Cliente" InitialValue="Seleccione"
                        Text="*" Display="None" ControlToValidate="dropTipoCliente" ValidationGroup="add">
                    </asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVdropTipoCliente"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
            </tr>
            <tr>
                <td>Nombre
                </td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="TextBox" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVtxtNombre" runat="server" ErrorMessage="Digite el nombre del Cliente"
                        Text="*" Display="None" ControlToValidate="txtNombre" ValidationGroup="add">
                    </asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RFVtxtNombre"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
                <td>Segundo
                </td>
                <td>
                    <asp:TextBox ID="txtSNombre" runat="server" CssClass="TextBox" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Apellido
                </td>
                <td>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="TextBox" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVtxtApellido" runat="server" ErrorMessage="Digite el apellido del Cliente"
                        Text="*" Display="None" ControlToValidate="txtApellido" ValidationGroup="add">
                    </asp:RequiredFieldValidator>
                    <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="RFVtxtApellido"
                        HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                    </ajx:ValidatorCalloutExtender>
                </td>
                <td>Segundo
                </td>
                <td>
                    <asp:TextBox ID="txtSApellido" runat="server" CssClass="TextBox" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Celular
                </td>
                <td>
                    <asp:TextBox ID="txtCelular" runat="server" CssClass="TextBox" Width="150px"></asp:TextBox>
                </td>
                <td>Telefono
                </td>
                <td>
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="TextBox" Width="150px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="text-align: center">Email
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="TextBox" Width="300px"></asp:TextBox>

                </td>
                <td colspan="2" style="text-align: center">
                    <asp:Button ID="btnEditarCliente" ValidationGroup="add" runat="server" CssClass="btn btn-success" Text="Actualizar" OnClick="btnEditarCliente_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
    <fieldset>
        <legend>Listado de sedes</legend>
        <div style="margin: 0 auto; text-align: center">
            <asp:Button ID="btnAgregarSede1" runat="server" Text="Agregar" CssClass="botones" OnClick="btnAgregarSede_Click" />
        </div>
        <asp:GridView ID="GridSedes" runat="server" CellPadding="4" DataKeyNames="cod"
            ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto" EmptyDataText="No existen sedes para este cliente."
            GridLines="None" OnRowDeleting="GridSedes_RowDeleting">
            <Columns>
                <asp:TemplateField HeaderText="No.">
                    <ItemTemplate>
                        <%# Container.DataItemIndex +1 %>
                    </ItemTemplate>
                    <ItemStyle Width="40px" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:BoundField DataField="cod" HeaderText="codSede" HeaderStyle-CssClass="ocultarcell" >
                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nit" HeaderText="NIT">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="nombre" HeaderText="Nombre">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="telefono" HeaderText="Telefono">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="direccion" HeaderText="Direccion">
                    <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="codmunicipio" HeaderText="codMunicipio" HeaderStyle-CssClass="ocultarcell">
                    <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="nombrem" HeaderText="Municipio" />
                <asp:BoundField DataField="sede" HeaderText="Sede">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        Ver
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgVer" runat="server" CommandName="Select" ImageUrl="~/Imagenes/ver.png" Height="20px" Width="20px" OnClick="imgVer_Click" />
                    </ItemTemplate>
                    <ItemStyle Width="20px" HorizontalAlign="Center" />
                </asp:TemplateField>
                 <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgAgregarTicket" runat="server" CommandName="Select" ImageUrl="~/Imagenes/ticket.png" Height="20px" Width="20px" OnClick="imgAgregarTicket_Click" />
                    </ItemTemplate>
                    <ItemStyle Width="20px" HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <HeaderTemplate>
                        <asp:Button ID="btnAgregarSede" runat="server" Text="Agregar" CssClass="botones" OnClick="btnAgregarSede_Click" />
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgEditar" runat="server" CommandName="Select" ImageUrl="~/Imagenes/edit.png" Height="20px" Width="20px" OnClick="imgEditar_Click" />

                    </ItemTemplate>
                    <ItemStyle Width="20px" HorizontalAlign="Center" />
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
    <asp:Panel ID="PanelDatosSede" runat="server" Visible="false">
        <div id="accordion" style="visibility: hidden;">
            <h3>Equipos</h3>
            <div>
                <asp:Label ID="lblCodClienteProyectoEquipo" runat="server" Visible="false"></asp:Label>
                <div style="margin: 0 auto; text-align: center">
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnAgregarEquipo" runat="server" Text="Agregar" CssClass="botones" Visible="false" OnClick="btnAgregarEquipo_Click" />
                            </td>
                            <td>
                                <asp:DropDownList ID="dropProyectoEquipos" runat="server" CssClass="TextBox" AutoPostBack="true" Visible="false" OnSelectedIndexChanged="dropProyectoEquipos_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>
                    </table>

                </div>
                <asp:GridView ID="GridEquipos" runat="server" CellPadding="4" DataKeyNames="cod"
                    ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto" EmptyDataText="No Tiene Equipos Asignados"
                    GridLines="None" OnRowDeleting="GridEquipos_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex +1 %>
                            </ItemTemplate>
                            <ItemStyle Width="40px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="cod" HeaderText="codcliequipo" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="codequipo" HeaderText="codequipo" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle CssClass="ocultarcell" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nombre" HeaderText="Equipo">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="descripcion" HeaderText="Descripción">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="serial" HeaderText="Serial">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="categoria" HeaderText="Categoria">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="fabricante" HeaderText="Fabricante">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="iprouter" HeaderText="IpRouter" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ipantena" HeaderText="Ip Antena" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="observacion" HeaderText="Descripcion" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Button ID="btnAgregarEquipo" runat="server" Text="Agregar" CssClass="botones" OnClick="btnAgregarEquipo_Click" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgEditarEquipo" runat="server" CommandName="Select" ImageUrl="~/Imagenes/edit.png" Height="20px" Width="20px" OnClick="imgEditarEquipo_Click" />
                                <asp:ImageButton ID="imgVerEquipo" runat="server" CommandName="Select" ImageUrl="~/Imagenes/ver.png" Height="20px" Width="20px" OnClick="imgVerEquipo_Click" />
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
            </div>
            <h3>Documentos</h3>
            <div>
                <asp:Label ID="lblCodClienteProyectoDocumento" runat="server" Visible="false"></asp:Label>
                <div style="margin: 0 auto; text-align: center">
                    <table>
                        <tr>
                            <td>
                                <asp:Button ID="btnAgregarDocumento" runat="server" Text="Agregar" CssClass="botones" Visible="false" OnClick="btnAgregarDocumento_Click" />
                            </td>
                            <td>
                                <asp:DropDownList ID="dropProyectoDocumento" runat="server" CssClass="TextBox" AutoPostBack="true" Visible="false" OnSelectedIndexChanged="dropProyectoDocumento_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>
                    </table>

                </div>
                <asp:GridView ID="GridDocumentos" runat="server" CellPadding="4" DataKeyNames="cod"
                    ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto" EmptyDataText="No Tiene Documentos Asignados"
                    GridLines="None" OnRowDeleting="GridDocumentos_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex +1 %>
                            </ItemTemplate>
                            <ItemStyle Width="40px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="cod" HeaderText="codclidocumento" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nombre" HeaderText="Documento">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nombrearchivo" HeaderText="Anexo">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nombreguardado" HeaderText="Guardado" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle HorizontalAlign="Center" CssClass="ocultarcell" />
                        </asp:BoundField>
                        <asp:BoundField DataField="path" HeaderText="Path" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle HorizontalAlign="Left" CssClass="ocultarcell" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                Descargar
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgDescargar" runat="server" CommandName="Select" ImageUrl="~/Imagenes/down.png" Height="20px" Width="20px" OnClick="imgDescargar_Click" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Button ID="btnAgregarDocumento" runat="server" Text="Agregar" CssClass="botones" OnClick="btnAgregarDocumento_Click" />
                            </HeaderTemplate>
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
            </div>
            <h3>Contactos</h3>
            <div>
                <asp:Label ID="lblCodContacto" runat="server" Visible="false"></asp:Label>
                <div style="margin: 0 auto; text-align: center">
                    <asp:Button ID="btnAgregarContacto1" runat="server" Text="Agregar" CssClass="botones" OnClick="btnAgregarContacto_Click" />
                </div>
                <asp:GridView ID="GridContacto" Width="80%" runat="server" CellPadding="4" DataKeyNames="cod"
                    ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto" EmptyDataText="No existen Contactos"
                    GridLines="None" OnRowDeleting="GridContacto_RowDeleting">
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex +1 %>
                            </ItemTemplate>
                            <ItemStyle Width="40px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="cod" HeaderText="codContacto" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="identificacion" HeaderText="Identificacion">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nombres" HeaderText="Nombres">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="apellidos" HeaderText="Apellidos">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="telefono" HeaderText="Telefono">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="celular" HeaderText="Celular">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="codcargo" HeaderText="codCargo" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="cargo" HeaderText="Cargo" />
                        <asp:BoundField DataField="email" HeaderText="Email" />
                        <asp:BoundField DataField="descripcion" HeaderText="Descripcion">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <asp:Button ID="btnAgregarContacto" runat="server" Text="Agregar" CssClass="botones" OnClick="btnAgregarContacto_Click" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgEditarContacto" runat="server" CommandName="Select" ImageUrl="~/Imagenes/edit.png" Height="20px" Width="20px" OnClick="imgEditarContacto_Click" />
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
            </div>

        </div>




    </asp:Panel>

    <asp:Button ID="btnShow" runat="server" Style="display: none" />
    <ajx:ModalPopupExtender ID="PanelVerDependencias_ModalPopupExtender" runat="server" Enabled="True"
        TargetControlID="btnShow" PopupControlID="PanelEditarSede" CancelControlID="btnCancelar"
        BackgroundCssClass="modalBackground">
    </ajx:ModalPopupExtender>

    <asp:Panel ID="PanelEditarSede" runat="server" CssClass="modalPopup">
        <asp:Label ID="lblCodSede" runat="server" Visible="false"></asp:Label>

        <fieldset>
            <legend>Edicion de Sede</legend>
            <table cellpadding="4" align="center" class="cajafiltroCentrado">
                <tr>
                    <td>NIT
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtNitSede" Width="400px" runat="server" CssClass="TextBox"></asp:TextBox>
                        <ajx:FilteredTextBoxExtender ID="txtNitSede_FilteredTextBoxExtender" runat="server" Enabled="True" TargetControlID="txtNitSede" FilterType="Custom, Numbers" ValidChars=".-"></ajx:FilteredTextBoxExtender>

                    </td>
                </tr>
                <tr>
                    <td>Nombre
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtNombreSede" Width="400px" runat="server" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVtxtNombreSede" runat="server" ErrorMessage="Digite el nombre del Cliente"
                            Text="*" Display="None" ControlToValidate="txtNombreSede" ValidationGroup="editSede">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True" TargetControlID="RFVtxtNombreSede"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>Telefono
                    </td>
                    <td>
                        <asp:TextBox ID="txtTelefonoSede" runat="server" CssClass="TextBox" Width="150px"></asp:TextBox></td>
                    <td>Direccion
                    </td>
                    <td>
                        <asp:TextBox ID="txtDireccionSede" runat="server" CssClass="TextBox" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Municipio
                    </td>
                    <td>
                        <asp:DropDownList ID="dropMunicipio" runat="server" CssClass="TextBox"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVdropMunicipio" runat="server" ErrorMessage="Seleccione el municipio" InitialValue="Seleccione"
                            Text="*" Display="None" ControlToValidate="dropMunicipio" ValidationGroup="editSede">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True" TargetControlID="RFVdropMunicipio"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                    <td>Sede
                    </td>
                    <td>
                        <asp:DropDownList ID="dropTipoSede" runat="server" CssClass="TextBox">
                            <asp:ListItem>Principal</asp:ListItem>
                            <asp:ListItem>Sede</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btnEditarSede" runat="server" ValidationGroup="editSede" CssClass="btn btn-success" Text="Editar Sede" OnClick="btnEditarSede_Click" />
                    </td>
                    <td colspan="2">
                        <asp:Label ID="btnCancelar" runat="server" CssClass="botones" Text="Cancelar"></asp:Label>
                    </td>
                </tr>
            </table>

        </fieldset>
    </asp:Panel>

    <asp:Button ID="btnAddSedeShow" runat="server" Style="display: none" />
    <ajx:ModalPopupExtender ID="PanelAgregarSede_ModalPopupExtender" runat="server" Enabled="True"
        TargetControlID="btnAddSedeShow" PopupControlID="PanelAgregarSede" CancelControlID="btnCancelar2"
        BackgroundCssClass="modalBackground">
    </ajx:ModalPopupExtender>

    <asp:Panel ID="PanelAgregarSede" runat="server" CssClass="modalPopup">
        <fieldset>
            <legend>Agregar Sede</legend>
            <table cellpadding="4" align="center" class="cajafiltroCentrado">
                <tr>
                    <td>NIT
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtNitAddSede" Width="400px" runat="server" CssClass="TextBox"></asp:TextBox>
                        <ajx:FilteredTextBoxExtender ID="txtNitAddSede_FilteredTextBoxExtender1" runat="server" Enabled="True" TargetControlID="txtNitAddSede" FilterType="Custom, Numbers" ValidChars=".-"></ajx:FilteredTextBoxExtender>

                    </td>
                </tr>
                <tr>
                    <td>Nombre
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtNombreAddSede" Width="400px" runat="server" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVtxtNombreAddSede" runat="server" ErrorMessage="Digite el nombre del Cliente"
                            Text="*" Display="None" ControlToValidate="txtNombreAddSede" ValidationGroup="addSede">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" Enabled="True" TargetControlID="RFVtxtNombreAddSede"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>Telefono
                    </td>
                    <td>
                        <asp:TextBox ID="txtTelefonoAddSede" runat="server" CssClass="TextBox" Width="150px"></asp:TextBox></td>
                    <td>Direccion
                    </td>
                    <td>
                        <asp:TextBox ID="txtDireccionAddSede" runat="server" CssClass="TextBox" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Municipio
                    </td>
                    <td>
                        <asp:DropDownList ID="dropMunicipioAddSede" runat="server" CssClass="TextBox"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVdropMunicipioAddSede" runat="server" ErrorMessage="Seleccione el municipio" InitialValue="Seleccione"
                            Text="*" Display="None" ControlToValidate="dropMunicipioAddSede" ValidationGroup="addSede">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" Enabled="True" TargetControlID="RFVdropMunicipioAddSede"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                    <td>Sede
                    </td>
                    <td>
                        <asp:DropDownList ID="dropTipoAddSede" runat="server" CssClass="TextBox">
                            <asp:ListItem>Principal</asp:ListItem>
                            <asp:ListItem>Sede</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btnAddSede" runat="server" CssClass="btn btn-success" ValidationGroup="addSede" Text="Agregar Sede" OnClick="btnAddSede_Click" />
                    </td>
                    <td colspan="2">
                        <asp:Label ID="btnCancelar2" runat="server" CssClass="botones" Text="Cancelar"></asp:Label>
                    </td>
                </tr>
            </table>

        </fieldset>
    </asp:Panel>


    <asp:Button ID="btnAddContactoShow" runat="server" Style="display: none" />
    <ajx:ModalPopupExtender ID="PanelAddContacto_ModalPopupExtender" runat="server" Enabled="True"
        TargetControlID="btnAddContactoShow" PopupControlID="PanelAddContacto" CancelControlID="btnCancelar3"
        BackgroundCssClass="modalBackground">
    </ajx:ModalPopupExtender>

    <asp:Panel ID="PanelAddContacto" runat="server" CssClass="modalPopup">
        <fieldset>
            <legend>Agregar Contacto</legend>
            <table cellpadding="4" align="center" class="cajafiltroCentrado">
                <tr>
                    <td>Identificacion
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtIdContacto" Width="150px" runat="server" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVtxtIdContacto" runat="server" ErrorMessage="Digite el id del contacto"
                            Text="*" Display="None" ControlToValidate="txtIdContacto" ValidationGroup="addContacto">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender9" runat="server" Enabled="True" TargetControlID="RFVtxtIdContacto"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>Nombres
                    </td>
                    <td>
                        <asp:TextBox ID="txtNombreContacto" runat="server" CssClass="TextBox" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVtxtNombreContacto" runat="server" ErrorMessage="Digite el nombre del contacto"
                            Text="*" Display="None" ControlToValidate="txtNombreContacto" ValidationGroup="addContacto">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender11" runat="server" Enabled="True" TargetControlID="RFVtxtNombreContacto"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                    <td>Apellidos
                    </td>
                    <td>
                        <asp:TextBox ID="txtApellidosContacto" runat="server" CssClass="TextBox" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVtxtApellidosContacto" runat="server" ErrorMessage="Digite el apellido del contacto"
                            Text="*" Display="None" ControlToValidate="txtApellidosContacto" ValidationGroup="addContacto">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" Enabled="True" TargetControlID="RFVtxtApellidosContacto"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>Telefono
                    </td>
                    <td>
                        <asp:TextBox ID="txtTelefonoContacto" runat="server" CssClass="TextBox" Width="150px"></asp:TextBox></td>
                    <td>Celular
                    </td>
                    <td>
                        <asp:TextBox ID="txtCelularContacto" runat="server" CssClass="TextBox" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Email
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmailContacto" runat="server" CssClass="TextBox" Width="200px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="REVtxtEmailContacto" runat="server" ErrorMessage="Email Invalido" Display="None"
                            ControlToValidate="txtEmailContacto" ValidationGroup="addContacto"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            Style="color: #FF0000"></asp:RegularExpressionValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender21"
                            runat="server" Enabled="True" TargetControlID="REVtxtEmailContacto"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft"
                            Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                    <td>Cargo
                    </td>
                    <td>
                        <asp:DropDownList ID="dropCargoContacto" runat="server" CssClass="TextBox"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVdropCargoContacto" runat="server" ErrorMessage="Seleccione el cargo" InitialValue="Seleccione"
                            Text="*" Display="None" ControlToValidate="dropCargoContacto" ValidationGroup="addContacto">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender10" runat="server" Enabled="True" TargetControlID="RFVdropCargoContacto"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>Descripción 
                    </td>
                    <td colspan="3" style="text-align: center">
                        <asp:TextBox ID="txtDescripcionContacto" TextMode="multiline" Rows="5" runat="server" Style="resize: vertical" Width="350px" CssClass="TextBox" />

                    </td>


                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btnAddContacto" runat="server" ValidationGroup="addContacto" CssClass="btn btn-success" Text="Agregar Contacto" OnClick="btnAddContacto_Click" />
                    </td>
                    <td colspan="2" style="text-align: center">
                        <asp:Label ID="btnCancelar3" runat="server" CssClass="botones" Text="Cancelar"></asp:Label>
                    </td>
                </tr>
            </table>

        </fieldset>
    </asp:Panel>

    <asp:Button ID="btnEditContactoShow" runat="server" Style="display: none" />
    <ajx:ModalPopupExtender ID="PanelEditContacto_ModalPopupExtender" runat="server" Enabled="True"
        TargetControlID="btnEditContactoShow" PopupControlID="PanelEditContacto" CancelControlID="btnCancelar4"
        BackgroundCssClass="modalBackground">
    </ajx:ModalPopupExtender>

    <asp:Panel ID="PanelEditContacto" runat="server" CssClass="modalPopup">
        <fieldset>
            <legend>Editar Contacto</legend>
            <table cellpadding="4" align="center" class="cajafiltroCentrado">
                <tr>
                    <td>Identificacion
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtIdContactoEdit" Width="150px" runat="server" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVtxtEditContacto" runat="server" ErrorMessage="Digite el id del contacto"
                            Text="*" Display="None" ControlToValidate="txtIdContactoEdit" ValidationGroup="editContacto">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender13" runat="server" Enabled="True" TargetControlID="RFVtxtEditContacto"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>Nombres
                    </td>
                    <td>
                        <asp:TextBox ID="txtNombreContactoEdit" runat="server" CssClass="TextBox" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVtxtNombreContactoEdit" runat="server" ErrorMessage="Digite el nombre del contacto"
                            Text="*" Display="None" ControlToValidate="txtNombreContactoEdit" ValidationGroup="editContacto">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender14" runat="server" Enabled="True" TargetControlID="RFVtxtNombreContactoEdit"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                    <td>Apellidos
                    </td>
                    <td>
                        <asp:TextBox ID="txtApellidosContactoEdit" runat="server" CssClass="TextBox" Width="150px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVtxtApellidosContactoEdit" runat="server" ErrorMessage="Digite el apellido del contacto"
                            Text="*" Display="None" ControlToValidate="txtApellidosContactoEdit" ValidationGroup="editContacto">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender15" runat="server" Enabled="True" TargetControlID="RFVtxtApellidosContactoEdit"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>Telefono
                    </td>
                    <td>
                        <asp:TextBox ID="txtTelefonoContactoEdit" runat="server" CssClass="TextBox" Width="150px"></asp:TextBox></td>
                    <td>Celular
                    </td>
                    <td>
                        <asp:TextBox ID="txtCelularContactoEdit" runat="server" CssClass="TextBox" Width="150px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>Email
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmailContactoEdit" runat="server" CssClass="TextBox" Width="200px"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="REVtxtEmailContactoEdit" runat="server" ErrorMessage="Email Invalido" Display="None"
                            ControlToValidate="txtEmailContactoEdit" ValidationGroup="editContacto"
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            Style="color: #FF0000"></asp:RegularExpressionValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender16"
                            runat="server" Enabled="True" TargetControlID="REVtxtEmailContactoEdit"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft"
                            Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                    <td>Cargo
                    </td>
                    <td>
                        <asp:DropDownList ID="dropCargoContactoEdit" runat="server" CssClass="TextBox"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVdropCargoContactoEdit" runat="server" ErrorMessage="Seleccione el cargo" InitialValue="Seleccione"
                            Text="*" Display="None" ControlToValidate="dropCargoContactoEdit" ValidationGroup="editContacto">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender17" runat="server" Enabled="True" TargetControlID="RFVdropCargoContactoEdit"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>Descripción 
                    </td>
                    <td colspan="3" style="text-align: center">
                        <asp:TextBox ID="txtDescripcionContactoEdit" TextMode="multiline" Rows="5" runat="server" Style="resize: vertical" Width="350px" CssClass="TextBox" />

                    </td>


                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btnEditContacto" runat="server" ValidationGroup="editContacto" CssClass="btn btn-success" Text="Editar Contacto" OnClick="btnEditContacto_Click" />
                    </td>
                    <td colspan="2" style="text-align: center">
                        <asp:Label ID="btnCancelar4" runat="server" CssClass="botones" Text="Cancelar"></asp:Label>
                    </td>
                </tr>
            </table>

        </fieldset>
    </asp:Panel>

    <asp:Button ID="btnShowAgregarEquipo" runat="server" Style="display: none" />
    <ajx:ModalPopupExtender ID="PanelAgregaEquipo_ModalPopupExtender" runat="server" Enabled="True"
        TargetControlID="btnShowAgregarEquipo" PopupControlID="PanelAgregaEquipo" CancelControlID="btnCancelar5"
        BackgroundCssClass="modalBackground">
    </ajx:ModalPopupExtender>

    <asp:Panel ID="PanelAgregaEquipo" runat="server" CssClass="modalPopup">


        <fieldset>
            <legend>Agregar Equipo</legend>
            <table cellpadding="4" align="center" class="cajafiltroCentrado">
                <tr>
                    <td>Serial
                    </td>
                    <td>
                        <asp:TextBox ID="txtSerial" Width="400px" runat="server" CssClass="TextBox" placeholder="MAC: 9C-AD-97-7B-24-01,Serial: NXMN2AL004428169177600 "></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVtxtSerial" runat="server" ErrorMessage="Digite el serial equipo"
                            Text="*" Display="None" ControlToValidate="txtSerial" ValidationGroup="addEquipo">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender18" runat="server" Enabled="True" TargetControlID="RFVtxtSerial"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>Equipo
                    </td>
                    <td>
                        <asp:DropDownList ID="dropEquipo" runat="server" CssClass="TextBox"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVdropEquipo" runat="server" ErrorMessage="Seleccione el equipo" InitialValue="Seleccione"
                            Text="*" Display="None" ControlToValidate="dropEquipo" ValidationGroup="addEquipo">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender20" runat="server" Enabled="True" TargetControlID="RFVdropEquipo"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>

                    </td>

                </tr>
                <tr>
                    <td>IP Router
                    </td>
                    <td>
                        <asp:TextBox ID="txtIpRouterAdd" runat="server" CssClass="TextBox"></asp:TextBox>
                        No Aplica
                        <asp:CheckBox ID="chbIpRouteAdd" runat="server" onClick="mostrarCapa(this)" />
                    </td>

                </tr>
                <tr>
                    <td>IP Antena
                    </td>
                    <td>
                        <asp:TextBox ID="txtIpAntenaAdd" runat="server" CssClass="TextBox"></asp:TextBox>
                        No Aplica
                        <asp:CheckBox ID="chbIpAntenaAdd" runat="server" onClick="mostrarCapa2(this)" />
                    </td>

                </tr>
                <tr>
                    <td>Descripción 
                    </td>
                    <td style="text-align: center">
                        <asp:TextBox ID="txtDescripcionEquipoAdd" TextMode="multiline" Rows="5" runat="server" Style="resize: vertical" Width="350px" CssClass="TextBox" />

                    </td>


                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btnAddEquipo" runat="server" ValidationGroup="addEquipo" CssClass="btn btn-success" Text="Agregar Equipo" OnClick="btnAddEquipo_Click" />

                        &nbsp;&nbsp;&nbsp;&nbsp;
                
                    <asp:Label ID="btnCancelar5" runat="server" CssClass="botones" Text="Cancelar"></asp:Label>
                    </td>
                </tr>
            </table>

        </fieldset>
    </asp:Panel>

    <asp:Button ID="btnShowEditEquipo" runat="server" Style="display: none" />
    <ajx:ModalPopupExtender ID="PanelEditEquipo_ModalPopupExtender" runat="server" Enabled="True"
        TargetControlID="btnShowEditEquipo" PopupControlID="PanelEditEquipo" CancelControlID="btnCancelar6"
        BackgroundCssClass="modalBackground">
    </ajx:ModalPopupExtender>

    <asp:Panel ID="PanelEditEquipo" runat="server" CssClass="modalPopup">
        <asp:Label ID="lblCodClienteProyectoEquipoEditar" runat="server" Visible="false"></asp:Label>

        <fieldset>
            <legend>Editar Equipo</legend>
            <table cellpadding="4" align="center" class="cajafiltroCentrado">
                <tr>
                    <td>Serial
                    </td>
                    <td>
                        <asp:TextBox ID="txtSerialEdit" Width="400px" runat="server" CssClass="TextBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVtxtSerialEdit" runat="server" ErrorMessage="Digite el serial equipo"
                            Text="*" Display="None" ControlToValidate="txtSerialEdit" ValidationGroup="editEquipo">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender19" runat="server" Enabled="True" TargetControlID="RFVtxtSerialEdit"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>Equipo
                    </td>
                    <td>
                        <asp:DropDownList ID="dropEquipoEditar" runat="server" CssClass="TextBox"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVdropEquipoEditar" runat="server" ErrorMessage="Seleccione el equipo" InitialValue="Seleccione"
                            Text="*" Display="None" ControlToValidate="dropEquipoEditar" ValidationGroup="editEquipo">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender22" runat="server" Enabled="True" TargetControlID="RFVdropEquipoEditar"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>

                    </td>

                </tr>
                <tr>
                    <td>IP Router
                    </td>
                    <td>
                        <asp:TextBox ID="txtIpRouteEdit" runat="server" CssClass="TextBox"></asp:TextBox>
                        No Aplica
                        <asp:CheckBox ID="cbIpRouterEdit" runat="server" onClick="mostrarCapa3(this)" />
                    </td>

                </tr>
                <tr>
                    <td>IP Antena
                    </td>
                    <td>
                        <asp:TextBox ID="txtIpAntenaEdit" runat="server" CssClass="TextBox"></asp:TextBox>
                        No Aplica
                        <asp:CheckBox ID="cbIpAntenaEdit" runat="server" onClick="mostrarCapa4(this)" />
                    </td>

                </tr>
                <tr>
                    <td>Descripción 
                    </td>
                    <td style="text-align: center">
                        <asp:TextBox ID="txtDescripcionEdit" TextMode="multiline" Rows="5" runat="server" Style="resize: vertical" Width="350px" CssClass="TextBox" />
                    </td>


                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; padding 2px;">
                        <asp:Button ID="btnEditarEquipo" runat="server" ValidationGroup="editEquipo" CssClass="btn btn-success" Text="Guardar Cambios" OnClick="btnEditarEquipo_Click" />

                        <asp:Label ID="btnCancelar6" runat="server" CssClass="botones" Text="Cancelar"></asp:Label>
                    </td>
                </tr>
            </table>

        </fieldset>
    </asp:Panel>

    <asp:Button ID="btnShowAddDocumento" runat="server" Style="display: none" />
    <ajx:ModalPopupExtender ID="PanelDocumentoAdd_ModalPopupExtender" runat="server" Enabled="True"
        TargetControlID="btnAddSedeShow" PopupControlID="PanelDocumentoAdd" CancelControlID="btnCancelar7"
        BackgroundCssClass="modalBackground">
    </ajx:ModalPopupExtender>

    <asp:Panel ID="PanelDocumentoAdd" runat="server" CssClass="modalPopup">
        <fieldset>
            <legend>Agregar Documento</legend>
            <table cellpadding="4" align="center" class="cajafiltroCentrado">
                <tr>
                    <td>Subir Archivo:
                    </td>
                    <td colspan="3">
                        <asp:FileUpload ID="trepador" runat="server" />
                        <asp:RequiredFieldValidator ID="RFVtrepador" runat="server" ErrorMessage="Debe seleccionar un archivo"
                            Text="*" Display="None" ControlToValidate="trepador" ValidationGroup="addDocumento">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender24" runat="server" Enabled="True" TargetControlID="RFVtrepador"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td>Documento
                    </td>
                    <td colspan="3">
                        <asp:DropDownList ID="dropDocumentoAdd" runat="server" CssClass="TextBox"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RFVdropDocumentoAdd" runat="server" ErrorMessage="Seleccione el documento" InitialValue="Seleccione"
                            Text="*" Display="None" ControlToValidate="dropDocumentoAdd" ValidationGroup="addDocumento">
                        </asp:RequiredFieldValidator>
                        <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender23" runat="server" Enabled="True" TargetControlID="RFVdropDocumentoAdd"
                            HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                        </ajx:ValidatorCalloutExtender>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="btnAddDocumento" runat="server" CssClass="btn btn-success" ValidationGroup="addDocumento" Text="Agregar Documento" OnClick="btnAddDocumento_Click" />
                    </td>
                    <td colspan="2">
                        <asp:Label ID="btnCancelar7" runat="server" CssClass="botones" Text="Cancelar"></asp:Label>
                    </td>
                </tr>
            </table>

        </fieldset>
    </asp:Panel>

    <asp:Button ID="btnShowEquipo" runat="server" Style="display: none" />
    <ajx:ModalPopupExtender ID="PanelDescripcionEquipo_ModalPopupExtender1" runat="server" Enabled="True"
        TargetControlID="btnShowEquipo" PopupControlID="PanelDescripcionEquipo" CancelControlID="btnCerrar"
        BackgroundCssClass="modalBackground">
    </ajx:ModalPopupExtender>

    <asp:Panel ID="PanelDescripcionEquipo" runat="server" CssClass="modalPopup">
        <fieldset>
            <legend>Datos del equipo</legend>
            <asp:Label ID="lblDescripcionEquipo" runat="server"></asp:Label>
            <div style="margin: 0 auto; text-align: center; padding-top: 10px; margin-top: 5px">
                <asp:Label ID="btnCerrar" runat="server" CssClass="botones" Text="Cerrar"></asp:Label>
            </div>
        </fieldset>
    </asp:Panel>


    <!-- Agregar Ticket a Cliente -->
    <asp:Button ID="PanelShowAgregarTicket" runat="server" style="display:none"/>
     <ajx:ModalPopupExtender ID="PanelAgregarTickets_Modalpopupextender" runat="server" Enabled="True"
        TargetControlID="PanelShowAgregarTicket" PopupControlID="PanelAgregarTickets" CancelControlID="btnCerrarAgregarEvento"
        BackgroundCssClass="modalBackground">
    </ajx:ModalPopupExtender>

    <asp:Panel ID="PanelAgregarTickets" runat="server" CssClass="modalPopup">
        <asp:Label ID="lblCodProyecto" runat="server" Visible="false"></asp:Label>
        <asp:Label ID="lblCodUsuarioRol" runat="server" Visible="false"></asp:Label>
        <header class="headerpopup">
            <div style="float: left; margin-right: 15px" id="Div2">
                Agregar Ticket
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
                            <asp:DropDownList ID="dropSolicitudAdd" runat="server" CssClass="TextBox" >
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFVdropSolicitudAdd" runat="server" Display="None" ErrorMessage="Selecciones el tipo de solicitud"
                                ControlToValidate="dropSolicitudAdd" Text="*" ValidationGroup="AgregarR" InitialValue="Seleccione"></asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender25" runat="server" TargetControlID="RFVdropSolicitudAdd"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True"
                                Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="vertical-align: top;" class="primeracolumna">Descripción :
                        </td>
                        <td colspan="3">
                            <asp:TextBox ID="txtDescripciónAdd" runat="server" CssClass="TextBox" placeholder="Describa la actividad." Width="300px" TextMode="MultiLine" Rows="3" Style="resize: none"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <br />
                <br />

            </fieldset>
        </section>
        <footer class="footerpopup">
            <div style="text-align: center">
                <asp:Button ID="btnAddTickets" runat="server" Text="Agregar Ticket" CssClass="btn btn-success"
                    ValidationGroup="AgregarR" OnClick="btnAddTickets_Click" />
            </div>
        </footer>
    </asp:Panel>

</asp:Content>

