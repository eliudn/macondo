<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="actdetalle.aspx.cs" Inherits="actdetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script src="Scripts/pruebas.js"></script>
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
    <asp:Label ID="lblCodUsuarioRol" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblCodUsuario" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblTipoUsuario" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCodActividad" runat="server" Visible="False"></asp:Label>

     <asp:Label ID="lblCodProyecto" runat="server" Visible="False"></asp:Label>
     <asp:Label ID="lblCodEstado" runat="server" Visible="False"></asp:Label>
     <asp:Label ID="lblOperacion" runat="server" Visible="False"></asp:Label>

    <div style="display:none">
        <asp:Label ID="lblSM"  runat="server" ></asp:Label>
        <asp:Label ID="lblCCQ" runat="server"></asp:Label>
        <asp:Label ID="lblTTLN" runat="server" ></asp:Label>
        <asp:Label ID="lblTTLW" runat="server" ></asp:Label>
        <asp:Label ID="lblAncho" runat="server" ></asp:Label>
    </div>

    <div class="header">
        <div style="float: left; margin-right: 15px">
            <h2>Seguimiento de actividad</h2>
        </div>

        <div style="float: right;">
            <%--<a href='<%# getVolver() %>' runat="server" id="btnRegresar" class="btn btn-primary">Volver</a>--%>
            <a href='javascript:window.history.back()' runat="server" id="btnRegresar" class="btn btn-primary">Volver</a>
        </div>
    </div>
 <%--style="visibility:hidden;"--%>
    <div id="accordion"  >
        <h3>Detalles de la actividad</h3>
        <div>
            <div style="margin: 0 auto; text-align: center">
                <asp:Label ID="lblDetalles" runat="server"></asp:Label>
            </div>
        </div>
        <h3>Evidencias</h3>
        <div>
            <div style="margin: 0 auto; text-align: center">
                <table cellpadding="4" align="center" class="cajafiltroCentrado">
                    <tr>
                        <td class="primeracolumna">Subir Archivo: <span class="auto-style1">*</span>
                        </td>
                        <td>
                            <asp:FileUpload ID="trepador" runat="server" />
                            <asp:RequiredFieldValidator ID="RFVtrepador" runat="server" ErrorMessage="Debe seleccionar un archivo"
                                Text="*" Display="None" ControlToValidate="trepador" ValidationGroup="addEvidencia">
                            </asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender24" runat="server" Enabled="True" TargetControlID="RFVtrepador"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:Button ID="btnAddEvidencia" runat="server" ValidationGroup="addEvidencia" CssClass="btn btn-success" Text="Agregar Evidencia" OnClick="btnAddEvidencia_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="margin: 0 auto; text-align: center; padding-top: 5px; margin-top: 5px;">
                <asp:GridView ID="GridEvidencia" runat="server" CellPadding="4" DataKeyNames="cod"
                    ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto"
                    EmptyDataText="No existen evidencia para esta actividad."
                    GridLines="None">
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
                        <asp:BoundField DataField="usuario" HeaderText="Usuario">
                            <ItemStyle HorizontalAlign="Left" />
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
        <h3>Seguimiento</h3>
        <div>
            <div style="margin: 0 auto; text-align: center">
                <table cellpadding="4" align="center" class="cajafiltroCentrado">
                    <tr>
                        <td class="primeracolumna">Descripción  <span class="auto-style1">*</span>
                        </td>
                        <td style="text-align: center">
                            <asp:TextBox ID="txtDescripcion" TextMode="multiline" Rows="5" runat="server" Style="resize: vertical" Width="350px" CssClass="TextBox" />
                            <asp:RequiredFieldValidator ID="RFVtxtDescripcion" runat="server" ErrorMessage="Digite la descripción"
                                Text="*" Display="None" ControlToValidate="txtDescripcion" ValidationGroup="addSeguimiento">
                            </asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender12" runat="server" Enabled="True" TargetControlID="RFVtxtDescripcion"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="primeracolumna">Estado  <span class="auto-style1">*</span>
                        </td>
                        <td style="text-align: center">
                            <asp:DropDownList ID="dropEstado" runat="server" CssClass="TextBox"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RFVdropEstado" runat="server" ErrorMessage="Seleccione el estado"
                                Text="*" Display="None" ControlToValidate="dropEstado" ValidationGroup="addSeguimiento">
                            </asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVdropEstado"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center">
                            <asp:Button ID="btnAddSeguimiento" runat="server" ValidationGroup="addSeguimiento" CssClass="btn btn-success" Text="Agregar Seguimiento" OnClick="btnAddSeguimiento_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="margin: 0 auto; text-align: center; padding-top: 5px; margin-top: 5px;">
                <asp:GridView ID="GridSeguimiento" runat="server" CellPadding="4" DataKeyNames="cod"
                    ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto" EmptyDataText="No existen seguimientos para esta actividad."
                    GridLines="None">
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex +1 %>
                            </ItemTemplate>
                            <ItemStyle Width="40px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="cod" HeaderText="codSeguimiento" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="fechahora" HeaderText="Fecha" DataFormatString="{0:f}">
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="usuario" HeaderText="Usuario">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="estado" HeaderText="Estado">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="descripcion" HeaderText="Descripción">
                            <ItemStyle HorizontalAlign="Left" Width="300px" />
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
        </div>
        <h3>Pruebas</h3>
        <div>
            <div style="margin: 0 auto; text-align: center">
                <table align="center" class="cajafiltroCentrado">
                    <tr>
                        <td>SM:
                        </td>
                        <td>
                            <asp:TextBox ID="txtSm" onBlur="return nose(this);" runat="server" CssClass="TextBox" Width="40px"></asp:TextBox>
                            <%--<ajx:FilteredTextBoxExtender ID="txtNota1_FilteredTextBoxExtender" runat="server" Enabled="True" TargetControlID="txtSm" FilterType="Custom, Numbers" ValidChars="-."></ajx:FilteredTextBoxExtender>
                                <asp:RequiredFieldValidator ID="RFVtxtSm" runat="server" ErrorMessage="Digite SM"
                                Text="*" Display="None" ControlToValidate="txtSm" >
                            </asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RFVtxtSm"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>--%>
                        </td>
                        <td id="imgSM">

                        </td>
                     
                        <td>CCQ:
                        </td>
                        <td>
                            <asp:TextBox ID="txtCCQ"  onBlur="return nose(this);" runat="server" CssClass="TextBox" Width="40px"></asp:TextBox>
                            %<%--<ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" Enabled="True" TargetControlID="txtCCQ" FilterType="Custom, Numbers" ValidChars="."></ajx:FilteredTextBoxExtender>
                               <asp:RequiredFieldValidator ID="RFVtxtCCQ" runat="server" ErrorMessage="Digite CCQ"
                                Text="*" Display="None" ControlToValidate="txtCCQ" >
                            </asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="RFVtxtCCQ"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>--%>
                        </td>
                           <td id="imgCCQ">

                        </td>
                    </tr>
                    <tr>
                        <td>TTL Nodo:
                        </td>
                        <td>
                            <asp:TextBox ID="txtTtlNodo" onBlur="return nose(this);" runat="server" CssClass="TextBox" Width="40px" ></asp:TextBox>
                            <ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" Enabled="True" TargetControlID="txtTtlNodo" FilterType="Custom, Numbers" ValidChars="."></ajx:FilteredTextBoxExtender>
                             <asp:RequiredFieldValidator ID="RFVtxtTtlNodo" runat="server" ErrorMessage="Digite TTL Al Nodo"
                                Text="*" Display="None" ControlToValidate="txtTtlNodo" ValidationGroup="addPrueba">
                            </asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" Enabled="True" TargetControlID="RFVtxtTtlNodo"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>
                            MS</td>
                             <td id="imgTTLN">

                        </td>
                        <td>TTL Web:
                        </td>
                        <td>
                            <asp:TextBox ID="txtTtlWeb" onBlur="return nose(this);" runat="server" CssClass="TextBox" Width="40px"></asp:TextBox>
                            MS<ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" Enabled="True" TargetControlID="txtTtlWeb" FilterType="Custom, Numbers" ValidChars="."></ajx:FilteredTextBoxExtender>
                                <asp:RequiredFieldValidator ID="RFVtxtTtlWeb" runat="server" ErrorMessage="Digite TTL A La Web"
                                Text="*" Display="None" ControlToValidate="txtTtlWeb" ValidationGroup="addPrueba">
                            </asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" Enabled="True" TargetControlID="RFVtxtTtlWeb"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>
                        </td>
                            <td id="imgTTLW">

                        </td>
                    </tr>
                    <tr>
                        <td>Ancho Contratado:
                        </td>
                        <td style="text-align: center">
                            <asp:TextBox ID="txtAnchoBanda" runat="server" CssClass="TextBox" Width="40px"> </asp:TextBox>
                            %<ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" Enabled="True" TargetControlID="txtAnchoBanda" FilterType="Custom, Numbers" ValidChars="."></ajx:FilteredTextBoxExtender>
                             <asp:RequiredFieldValidator ID="RFVtxtAnchoBanda" runat="server" ErrorMessage="Digite Ancho de Banda Contratado"
                                Text="*" Display="None" ControlToValidate="txtAnchoBanda" ValidationGroup="addPrueba">
                            </asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" Enabled="True" TargetControlID="RFVtxtAnchoBanda"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>
                        </td>
                       <td>Ancho Actual:
                        </td>
                        <td style="text-align: center">
                            <asp:TextBox ID="txtAnchoActual" onBlur="return nose(this);" runat="server" CssClass="TextBox" Width="40px" > </asp:TextBox>
                            %<ajx:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" Enabled="True" TargetControlID="txtAnchoActual" FilterType="Custom, Numbers" ValidChars="."></ajx:FilteredTextBoxExtender>
                                <asp:RequiredFieldValidator ID="RFVtxtAnchoActual" runat="server" ErrorMessage="Digite Ancho de Banda Actual"
                                Text="*" Display="None" ControlToValidate="txtAnchoActual" ValidationGroup="addPrueba">
                            </asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" Enabled="True" TargetControlID="RFVtxtAnchoActual"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>
                        </td>
                        <td colspan="2" id="imgAncho">

                        </td>
                        </tr>
                    <tr>
                     <td></td>
                        <td style="text-align: center">
                        <asp:DropDownList ID="dropResultado" runat="server" CssClass="TextBox" Visible="false" Enabled="false">
                            <asp:ListItem Value="sinresultado">Sin Resultado</asp:ListItem>
                            <asp:ListItem Value="exitosa">Exitosa</asp:ListItem>
                            <asp:ListItem Value="no exitosa">No exitosa</asp:ListItem>
                        </asp:DropDownList>  </td>
                    <td >Descripción
                        </td>
                        <td style="text-align: center"  colspan="3">
                            <asp:TextBox ID="txtDescripcionPrueba" TextMode="multiline" Rows="5" runat="server" Style="resize: vertical" Width="350px" CssClass="TextBox" />
                           
                        </td>
                    </tr>
                    <tr>
                        <td colspan="6" style="text-align: center">
                            <asp:Button ID="btnAgregarPrueba"  ValidationGroup="addPrueba" runat="server" Text="Registrar Prueba" CssClass="botones" OnClick="btnAgregarPrueba_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div style="margin: 0 auto; text-align: center; padding-top: 5px; margin-top: 5px;">
                <asp:GridView ID="GridPruebas" runat="server" CellPadding="4" DataKeyNames="cod"
                    ForeColor="#333333" AutoGenerateColumns="false" Style="margin: 0 auto" EmptyDataText="No existen pruebas para esta actividad."
                    GridLines="None">
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
                        <asp:BoundField DataField="createdday" HeaderText="Fecha" DataFormatString="{0:f}">
                            <ItemStyle HorizontalAlign="Center"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="usuario" HeaderText="Usuario">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="sm" HeaderText="SM">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ccq" HeaderText="CCQ">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                            <asp:BoundField DataField="ttlnodo" HeaderText="TTL Nodo">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ttlweb" HeaderText="TTL Web">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                            <asp:BoundField DataField="ancho" HeaderText="Ancho de Banda">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                           <asp:BoundField DataField="descripcion" HeaderText="Descripción">
                            <ItemStyle HorizontalAlign="Left" Width="200px" />
                        </asp:BoundField>
                       <asp:BoundField DataField="resultado" HeaderText="Resultado">
                            <ItemStyle HorizontalAlign="Center" />
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
        </div>
    </div>

</asp:Content>

