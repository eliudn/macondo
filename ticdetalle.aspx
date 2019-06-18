<%@ Page Title="" Language="C#" MasterPageFile="~/General.master" AutoEventWireup="true" CodeFile="ticdetalle.aspx.cs" Inherits="ticdetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css">
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <link rel="stylesheet" href="/resources/demos/style.css">
    <script>
        $(document).ready(function () {
              $("#accordion").accordion({
                      heightStyle: "content",
                      active: 0 //Colocas comillas para que no se abra ninguno, quitas comillas y colocas un numero si quieres que se visualize algun panel
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
        function eliminar(img) {
            if (!confirm('Desea eliminar el evento señalado?')) {
            } else {

                //var tipousuario = document.getElementById('MainContent_lblTipoUsuario').textContent;
                var res = img.id.substring(3);

                $.ajax({
                    type: "POST",
                    url: "actagenda.aspx/eliminarEvento",
                    data: "{cod:" + res + "}",
                    contentType: "application/json",
                    dataType: "json",
                    success: function (msg) {
                        if (msg.d != "-1") {
                            $("#div" + res).fadeOut(200);
                        } else {
                            alert('ERROR');
                        }
                    },
                    error: function (msg) {
                        alert(msg.d);
                    }
                });

            }


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
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

     <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
    <div id="mensaje" runat="server"></div>
    <asp:Label ID="lblCodUsuarioRol" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblCodUsuario" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblTipoUsuario" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCodActividad" runat="server" Visible="False"></asp:Label>

    <asp:Label ID="lblOperacion" runat="server" Visible="False"></asp:Label>

    <asp:Label ID="lblCodProyecto" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCodEstado" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCodPrioridad" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCodSolicitud" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCodCliente" runat="server" Visible="False"></asp:Label>
    <asp:Label ID="lblCodUsuarioS" runat="server" Visible="False"></asp:Label>
    

    <div class="header">
        <div style="float: left; margin-right: 15px">
            <asp:Label ID="lbldatos" runat="server" Visible="false">
            <h2>Seguimiento de Ticket  </asp:Label></h2>
        </div>

        <div style="float: right;">
            <a href='javascript:window.history.back()' runat="server" id="btnRegresar" class="btn btn-primary">Volver</a>
            <%--<a href='<%# getVolver() %>' runat="server" id="btnRegresar" class="btn btn-primary">Volver</a>--%>
        </div>
    </div>
    <div id="accordion" style="visibility:hidden;"> 
         <h3>Detalles del Tickets</h3>
        <div>
           <div style="margin: 0 auto; text-align: center">
                <asp:Label ID="lblDetalles" runat="server" ></asp:Label>
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

                        <td class="primeracolumna">Estado<span class="auto-style1">*</span>
                        <td align="left">
                            <asp:DropDownList ID="dropEstadoLista" runat="server" CssClass="TextBox" Style="max-width: 250px" Visible="true">
                            </asp:DropDownList><asp:Label ID="lblestadolista" runat="server" Visible="false" Text="Resuelto"></asp:Label>
                        </td>
                    </tr>
                    <tr>

                        <td class="primeracolumna">Causa:<span class="auto-style1">*</span>
                        <td align="left">
                            <asp:DropDownList ID="dropCausaIncidente" runat="server" CssClass="TextBox" Style="max-width: 250px" Visible="true">
                            </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFVdropCausaIncidente" runat="server" ErrorMessage="Seleccione La Causa del incidente"
                                Text="*" Display="None" InitialValue="Seleccione" ControlToValidate="dropCausaIncidente" ValidationGroup="addSeguimiento">
                            </asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" Enabled="True" TargetControlID="RFVdropCausaIncidente"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>

                            <%--  --%>

                            <asp:DropDownList ID="dropCausaIncidente2" runat="server" CssClass="TextBox" Style="max-width: 250px" Visible="false">
                            </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RFVdropCausaIncidente2" runat="server" ErrorMessage="Seleccione La Causa del incidente"
                                Text="*" Display="None" InitialValue="Seleccione" ControlToValidate="dropCausaIncidente2" ValidationGroup="addSeguimiento">
                            </asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" Enabled="True" TargetControlID="RFVdropCausaIncidente2"
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
                        <asp:BoundField DataField="cod" HeaderText="cod" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="fechahora" HeaderText="Fecha" DataFormatString="{0:f}">
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="usuario" HeaderText="Usuario">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="nombre" HeaderText="Estado">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="descripcion" HeaderText="Descripción">
                            <ItemStyle HorizontalAlign="Left" Width="200px" />
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
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" 
                                CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2"><i>El tamaño máximo para el cargue de los archivos es de <b>5MB</b></i></td>
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
                        <asp:BoundField DataField="cod" HeaderText="cod" HeaderStyle-CssClass="ocultarcell">
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
        <h3>Time Off</h3>
        <div>
            <asp:UpdatePanel ID="pnlTimeOff" runat="server">
                <ContentTemplate>
                    <div style="margin: 0 auto; text-align: center; padding-top: 5px; margin-top: 5px;">
                <table cellpadding="4" align="center" class="cajafiltroCentrado">
                    <tr>
                        <td runat="server" colspan="3" id="respuesta"></td>
                    </tr>
                    <tr>
                        <td class="primeracolumna">Descripción  <span class="auto-style1">*</span></td>
                        <td style="text-align: center" colspan="3">
                            <asp:TextBox ID="txtDescripcionOff" TextMode="multiline" Rows="5" runat="server" Style="resize: vertical" Width="350px" CssClass="TextBox" />
                            <asp:RequiredFieldValidator ID="RFVtxtDescripcionOff" runat="server" ErrorMessage="Digite la descripción"
                                Text="*" Display="None" ControlToValidate="txtDescripcionOff" ValidationGroup="addTimeOff">
                            </asp:RequiredFieldValidator>
                            <ajx:ValidatorCalloutExtender ID="VCEtxtDescripcionOff" runat="server" Enabled="True" TargetControlID="RFVtxtDescripcionOff"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender> 
                        </td>
                    </tr>
                    <tr>
                        <td class="primeracolumna">Fecha de Inicio  <span class="auto-style1">*</span></td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtFechaI"  placeholder="dd-mm-aaaa"></asp:TextBox>
                            <ajx:FilteredTextBoxExtender ID="filtro" runat="server" TargetControlID="txtFechaI" FilterType="Custom, Numbers" ValidChars="-">
                             </ajx:FilteredTextBoxExtender>
                            <ajx:CalendarExtender ID="txtFechaI_CalendarExtender" runat="server"
                                DefaultView="Days" Enabled="True" Format="dd-MM-yyyy"
                                TargetControlID="txtFechaI">
                            </ajx:CalendarExtender>
                            <asp:RegularExpressionValidator ID="REVtxtFechaI" runat="server" ErrorMessage="Fecha Incorrecta: dd-MM-yyyy" Display="None"
                                ControlToValidate="txtFechaI" ValidationGroup="addTimeOff"
                                ValidationExpression="(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d"
                                Style="color: #FF0000"></asp:RegularExpressionValidator>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="REVtxtFechaI"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Enabled="True" 
                                Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="primeracolumna">Hora <span class="auto-style1">*</span></td>
                        <td align="left">
                            <asp:DropDownList runat="server" ID="cmbHoras"></asp:DropDownList>:<asp:DropDownList runat="server" ID="cmbMinutos" ></asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="primeracolumna">Cantidad de Horas  <span class="auto-style1">*</span></td>
                        <td align="left">
                            <asp:TextBox runat="server" ID="txtCantidadHoras"  MaxLength="4"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RFVtxtCantidadHoras" runat="server" ErrorMessage="Digite Cantidad de horas"
                                Text="*" Display="None" ControlToValidate="txtCantidadHoras" ValidationGroup="addTimeOff">
                            </asp:RequiredFieldValidator>
                            <ajx:FilteredTextBoxExtender ID="txtCantidadHoras_FilteredTextBoxExtender" runat="server" Enabled="True" 
                                                         TargetControlID="txtCantidadHoras" FilterType="Custom, Numbers" ValidChars="">
                            </ajx:FilteredTextBoxExtender>
                            <ajx:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" Enabled="True" TargetControlID="RFVtxtCantidadHoras"
                                HighlightCssClass="Highlight" PopupPosition="BottomLeft" Width="250px" WarningIconImageUrl="Imagenes/error3.png" CssClass="CustomValidatorCalloutStyle">
                            </ajx:ValidatorCalloutExtender> 
                        </td>
                    </tr>
                    <tr>
                        <td class="primeracolumna">Fecha de Finalización</td>
                        <td align="left">
                            <asp:Label runat="server" ID="lblFechaFinal" Text=""></asp:Label>
                            <asp:Button runat="server" ID="btnCalcular" CssClass="btn btn-primary redonda" Text="Calcular" OnClick="btnCalcular_Click"/>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" style="text-align: center">
                            <asp:Button ID="btnAddTimeOff" runat="server" ValidationGroup="addTimeOff" CssClass="btn btn-success" Text="Agregar Time Off" OnClick="btnAddTimeOff_Click" />
                        </td>
                    </tr>
                </table>
            </div>
                   
                     <div style="margin: 0 auto; text-align: center; padding-top: 5px; margin-top: 5px;"><asp:Label ID="lblprueba" runat="server" Visible="true"></asp:Label>
                <asp:GridView ID="GridTimeOff" runat="server" CellPadding="4" DataKeyNames="cod"
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
                        <asp:BoundField DataField="cod" HeaderText="cod" HeaderStyle-CssClass="ocultarcell">
                            <ItemStyle CssClass="ocultarcell" HorizontalAlign="Left" />
                        </asp:BoundField>
                         <asp:BoundField DataField="usuario" HeaderText="Usuario">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                       <asp:BoundField DataField="descripcion" HeaderText="Descripción">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="cantidad" HeaderText="Duración Horas">
                            <ItemStyle HorizontalAlign="Center"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="startday" HeaderText="Fecha Comienzo" DataFormatString="{0:f}">
                            <ItemStyle HorizontalAlign="Center"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="endday" HeaderText="Fecha Final" DataFormatString="{0:f}">
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:BoundField>
                        <asp:BoundField DataField="createdday" HeaderText="Fecha Creación" DataFormatString="{0:f}">
                            <ItemStyle HorizontalAlign="Left"/>
                        </asp:BoundField>
                         <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgDeleteTimeOff" runat="server" CommandName="Select" ImageUrl="~/Imagenes/delete.png" Height="20px" Width="20px" OnClick="imgDeleteTimeOff_Click" onclientclick="if(!confirm('¿Está seguro en eliminar el Time Off?')){return false;};" />
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
                    </ContentTemplate>
                    
            </asp:UpdatePanel>
        </div>
    </div>
   
</asp:Content>

